Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class FrmAplicaReintegro
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private TipoG As sTate
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private lineacredito As Double = 0
    Dim esDevolucion As Int32 = 0
#End Region

    Private Sub FrmAplicaReintegro_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Call CargarDatos()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
        TabMaestroEntregas.Tabs("Registro").Enabled = False
        TabMaestroEntregas.Tabs("Quitar").Enabled = False
    End Sub
    Private Sub FrmConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarDatos()
    End Sub
    Private Sub CargarDatos()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.TipoOperacion = Ope
        Entidad.Entregas.Usuario = User_Sistema
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Ls_EntregaDetalle = Nothing
        Ls_EntregaDetalle = New List(Of ETEntregas)
        Ls_DetalleComp = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ConsultaEntregas(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.GridConsultas, Source1, Ls_Entrega)
    End Sub

    Private Sub GridConsultas_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridConsultas.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "CodTrabajador" OrElse uColumn.Key = "Motivo" _
                    OrElse uColumn.Key = "NomTrabajador" OrElse uColumn.Key = "montoTotal") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Sub actualizar()
        Call CargarDatos()
    End Sub
    Sub cancelar()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.TipoOperacion = Ope
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Ls_EntregaDetalle = Nothing
        Ls_EntregaDetalle = New List(Of ETEntregas)
        Ls_DetalleComp = New List(Of ETEntregas)
    End Sub

    Private Sub GridConsultas_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridConsultas.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot GridConsultas Then Return

        If e.Row.IsFilterRow Then Return

        'e.Row.Fixed = Boolean.TrueString
        SubProceso_Entregas(e.Row)
    End Sub
    Sub PROCESAR()
        SubProceso_Entregas(GridConsultas.ActiveRow)
    End Sub
    Private Function ValidaLineacredito(ByVal codTrabajador As String) As Boolean
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.CodTrabajador = codTrabajador
        Entidad.MyLista = Negocio.NEntregas.ValidaLineacredito(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Ls_Entrega.Count > 0 Then
            lineacredito = Entidad.MyLista.Ls_Entrega.Item(0).lineacredito
            Return True
        Else
            Return False
        End If
    End Function
    'Dim disponible As Double
    Sub SubProceso_Entregas(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.MyLista = New ETMyLista
        Entidad.Entregas.CodTrabajador = uRow.Cells("CodTrabajador").Value
        lbltrabajador.Text = uRow.Cells("NomTrabajador").Value.ToString.ToUpper
        lbltrabajador2.Text = uRow.Cells("NomTrabajador").Value.ToString.ToUpper
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DtReintegro As DataTable = Nothing
        Dim DtPendiente As DataTable = Nothing
        Dim DtAplicaciones As DataTable = Nothing
        'Dim FUNCION_SQL As String = String.Empty
        'FUNCION_SQL = "FC_TIPOLIQUIDACION"
        oPrvFisN = New NGProveedorFiscalizado
        oPrvFisE = New ETProveedorFiscalizado
        With oPrvFisE
            .Cod_Prov = uRow.Cells("CodTrabajador").Value
            .User_Crea = User_Sistema
        End With
        DtReintegro = oPrvFisN.ListarReintegros(oPrvFisE)
        DtPendiente = oPrvFisN.ListarPendLiquidacion(oPrvFisE)
        DtAplicaciones = oPrvFisN.ListarAplicaciones(oPrvFisE)
        Call CargarUltraGridxBinding(Grid1, Source2, DtReintegro)
        Call CargarUltraGridxBinding(Grid2, Source3, DtPendiente)
        Call CargarUltraGridxBinding(Grid3, Source4, DtAplicaciones)

        For I As Int32 = 0 To Grid1.Rows.Count - 1
            txtxreintegro.Text = txtxreintegro.Text + Grid1.Rows(I).Cells("total").Value
        Next

        For J As Int32 = 0 To Grid2.Rows.Count - 1
            txtpendiente.Text = txtpendiente.Text + Grid2.Rows(J).Cells("SALDO").Value
        Next
        txtxreintegro.Text = CDbl(txtxreintegro.Text).ToString("0.00")
        txtpendiente.Text = CDbl(txtpendiente.Text).ToString("0.00")
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        TabMaestroEntregas.Tabs("Registro").Enabled = True
        TabMaestroEntregas.Tabs("Quitar").Enabled = True

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Private Sub GridConsultaDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "NumSolicitud" OrElse uColumn.Key = "Fecha" OrElse uColumn.Key = "montoParcial" _
                    OrElse uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "Motivo" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "moneda") Then 'OrElse uColumn.Key = "NumDoc"
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Sub SubProceso_Detalle(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If

        'Gpb1.Enabled = False

        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista

        Entidad.MyLista = Negocio.NEntregas.UsuarioAprobacion(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        nroSolicitud = uRow.Cells("NumSolicitud").Value
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        If Entidad.MyLista.Validacion Then Call cargarValoresDetalle(nroSolicitud)
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Sub cargarValoresDetalle(ByVal numsolicitud As String)
        Entidad.Entregas.NumSolicitud = numsolicitud
        Entidad.MyLista = Negocio.NEntregas.Listar_DetalleLiquidacion(Entidad.Entregas)
        Ls_DetalleComp = New List(Of ETEntregas)

        If Entidad.MyLista.Validacion Then
            Ls_DetalleComp = Entidad.MyLista.Ls_Entrega
        End If

    End Sub

    Private Sub gridDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "fechaComp" OrElse uColumn.Key = "TipoDoc" OrElse uColumn.Key = "NumDoc" OrElse _
                    uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Razon" OrElse uColumn.Key = "Serie") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub btnAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicar.Click
        Try
            If Me.Grid2.ActiveRow.Cells("ESTADO").Value.ToString.Trim = "RECEPCIONADO" Then
                MsgBox("La solicitud para aplicar no debe estar recepcionada", MsgBoxStyle.Information, msgComacsa)
                Exit Sub
            End If
            Dim strValorEquivalente As String = "0"
            Dim reg As New Regex("[^a-zA-Z0-9 ]")
            Dim strMoneda1 As String = reg.Replace(Me.Grid1.ActiveRow.Cells("moneda").Value.ToString.Normalize(NormalizationForm.FormD), "")
            Dim strMoneda2 As String = reg.Replace(Me.Grid2.ActiveRow.Cells("moneda").Value.ToString.Normalize(NormalizationForm.FormD), "")
            'If Me.Grid1.ActiveRow.Cells("moneda").Value.ToString.Trim <> Me.Grid2.ActiveRow.Cells("moneda").Value.ToString.Trim Then
            If strMoneda1.Trim <> strMoneda2.Trim Then
                'MsgBox("Las solicitudes deben tener el mismo tipo de moneda", MsgBoxStyle.Information, msgComacsa)
                'Exit Sub
                Dim opcion = InputBox("Ingrese el Tipo de Cambio", msgComacsa)
                If Not IsNumeric(opcion.Trim) Or opcion.Trim = "0" Then
                    MsgBox("No se continuará por que no se ingreso el tipo de cambio", MsgBoxStyle.Information, msgComacsa)
                    Exit Sub
                Else
                    strValorEquivalente = opcion
                End If
            Else
                strValorEquivalente = 1
            End If

            If MsgBox("¿Seguro aplicar reintegro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim iddocinterno As Int32 = 0
            Dim solicitud As String = String.Empty
            Dim dtGrabacion As New DataTable
            Entidad.Entregas = New ETEntregas
            Negocio.NEntregas = New NGEntregas

            iddocinterno = Me.Grid1.ActiveRow.Cells("ID").Value
            solicitud = Me.Grid2.ActiveRow.Cells("NUMSOLICITUD").Value

            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                ._iddocinterno = iddocinterno
                ._numsolicitud = solicitud
                .User_Crea = User_Sistema
                .Saldo = strValorEquivalente 'Valor Equivalente
                ._moneda = IIf(strMoneda1 = "DOLARES", "D", "S")
            End With
            dtGrabacion = oPrvFisN.AplicaReintegros(oPrvFisE)
            If dtGrabacion.Rows.Count > 0 Then
                If dtGrabacion.Rows(0)(0) = "OK" Then
                    MsgBox("Se aplicó correctamente el reintegro", MsgBoxStyle.Information, msgComacsa)
                    PROCESAR()
                Else
                    MsgBox("Error en aplicación", MsgBoxStyle.Information, msgComacsa)
                End If
            Else
                MsgBox("Error en aplicación", MsgBoxStyle.Information, msgComacsa)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnreintegro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreintegro.Click
        Try
            Dim nro_Solicitud As String = String.Empty
            nro_Solicitud = Me.Grid1.ActiveRow.Cells("numsolicitud").Value
            nroSolicitud = nro_Solicitud
            If nroSolicitud.ToString.Trim = "" Then Return
            'If estado.ToString.Trim = "LIQUIDACION APROBADA" Then
            '    MsgBox("La liquidación se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa)
            '    Exit Sub
            'End If
            If verificaReintegro(nro_Solicitud) = False Then
                Exit Sub
            End If
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            StrucForm.FxRxReintegro = New Frm_RptReintegro
            StrucForm.FxRxReintegro.MdiParent = MdiParent
            StrucForm.FxRxReintegro.esDevolucion = esDevolucion
            StrucForm.FxRxReintegro.Show()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Catch ex As Exception

        End Try
    End Sub

    Function verificaReintegro(ByVal nro_Solicitud As String) As Boolean
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.NumSolicitud = nro_Solicitud
        Entidad.MyLista = Negocio.NEntregas.verificaReintegro(Entidad.Entregas)
        If Entidad.MyLista.Ls_Entrega.Count > 0 Then
            MsgBox("El reintegro ya fue cancelado", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If
        Return True
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.Grid3.ActiveRow.Index < 0 Then Exit Sub
            If Me.Grid3.ActiveRow.Cells("ESTADO").Value.ToString.Trim <> "DESEMBOLSADO" Then
                MsgBox("La solicitud N° " & Me.Grid3.ActiveRow.Cells("ENTRANTE").Value.ToString.Trim & " debe encontrarse desembolsada", MsgBoxStyle.Information, msgComacsa)
                Exit Sub
            End If

            If MsgBox("¿Seguro quitar aplicación?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim iddocinterno As Int32 = 0
            Dim idliquidacion As Int32 = 0
            Dim monto As Double = 0
            Dim dtGrabacion As New DataTable
            Entidad.Entregas = New ETEntregas
            Negocio.NEntregas = New NGEntregas

            iddocinterno = Me.Grid3.ActiveRow.Cells("IDDOCINTERNO").Value
            idliquidacion = Me.Grid3.ActiveRow.Cells("IDLIQUIDACIONDET").Value
            monto = Me.Grid3.ActiveRow.Cells("MONTO").Value
            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                ._iddocinterno = iddocinterno
                ._idliquidacion = idliquidacion
                .Saldo = monto
                .User_Crea = User_Sistema
            End With

            dtGrabacion = oPrvFisN.QuitarAplicacion(oPrvFisE)
            If dtGrabacion.Rows.Count > 0 Then
                If dtGrabacion.Rows(0)(0) = "OK" Then
                    MsgBox("Se quito la aplicación correctamente", MsgBoxStyle.Information, msgComacsa)
                    PROCESAR()
                Else
                    MsgBox("Error en aplicación", MsgBoxStyle.Information, msgComacsa)
                End If
            Else
                MsgBox("Error en aplicación", MsgBoxStyle.Information, msgComacsa)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout

    End Sub
End Class