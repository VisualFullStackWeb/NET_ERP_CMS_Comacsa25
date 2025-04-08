Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmProvisionLiquidaciones
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
    Private Ls_EntregaEliminado As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private columna As String
    Private filtroConcepto As String = String.Empty
    Dim esDevolucion As Int32 = 0
    Dim totalPend As Double = 0
    Dim numInterno As String = String.Empty
    Dim idEstado As Int32
    Dim moneda As String = String.Empty
    Dim estado As String = String.Empty
    Dim auxi As String = String.Empty
    Dim flgauxi As Int32 = 0
    Dim tipotabla As Int32 = 0
    Dim estadoContable As Int32 = 0
    Dim anho As Int32
    Dim mes As Int32
    Dim monto As Double
    Dim ruc_Prov As String
#End Region
    Dim oPrvFisN As NGProveedorFiscalizado = Nothing
    Dim oPrvFisE As ETProveedorFiscalizado = Nothing
    Dim dsDatos As DataSet
    Dim dtReporte As DataTable
    Dim dtAnual As DataTable
    'Dim estadoContable As Int32 = 0
    Private Sub FrmProvisionLiquidaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        Me.cmbMes.Value = Month(Now.Date)
        Procesar()
    End Sub
    Sub Procesar()
        cargarDatos()
    End Sub
    Sub cargarDatos()
        dsDatos = New DataSet
        dtReporte = New DataTable
        dtAnual = New DataTable
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            With oPrvFisE
                .año = txtAño.Value
                .mes = cmbMes.Value
                .User_Crea = User_Sistema
            End With
            dsDatos = oPrvFisN.ListadoProvisiones(oPrvFisE)
            dtReporte = dsDatos.Tables(0)
            'dtAnual = dsDatos.Tables(1)
            Call CargarUltraGridxBinding(Grid1, Source1, dtReporte)
        Catch ex As Exception
        End Try
    End Sub
    Sub verificaestadoContable()
        'If chkaprobar.Checked = True Then
        Entidad.Entregas.añocontable = IIf(cmbMes.Value = 1, txtAño.Value - 1, txtAño.Value)
        Entidad.Entregas.mescontable = IIf(cmbMes.Value = 1, 12, cmbMes.Value - 1)
        Entidad.MyLista = Negocio.NEntregas.VerificaCierreContable(Entidad.Entregas)
        lResult = New ETMyLista
        lResult = Entidad.MyLista

        If Entidad.MyLista.Ls_Entrega.Count = 0 Then
            estadoContable = 0
        Else
            estadoContable = Entidad.MyLista.Ls_Entrega.Item(0).estadocontable
        End If
        'End If
    End Sub
    Sub Eliminar()
        Try
            verificaestadoContable()
            If estadoContable = 1 Then
                MsgBox("El mes ya se encuentra cerrado", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If MsgBox("¿Seguro desea eliminar asiento?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Return
            Else                
                Entidad.Entregas = New ETEntregas
                Entidad.Entregas.año = IIf(cmbMes.Value = 1, txtAño.Value - 1, txtAño.Value)
                Entidad.Entregas.Mes = IIf(cmbMes.Value = 1, 12, cmbMes.Value - 1)
                Entidad.Entregas.Usuario = User_Sistema
                Dim dtResultado As New DataTable
                Negocio.NEntregas = New NGEntregas
                dtResultado = Negocio.NEntregas.EliminaProvisionEntregas(Entidad.Entregas)
                If dtResultado.Rows(0)(0) = "OK" Then
                    MsgBox("Asiento eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
                Else
                    MsgBox("No existe asiento ha eliminar", MsgBoxStyle.Information, msgComacsa)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Grabar()
        Try
            Procesar()
            If Grid1.Rows.Count <= 0 Then
                MsgBox("No existen datos", MsgBoxStyle.Information, msgComacsa)
                Exit Sub
            End If
            verificaestadoContable()
            If estadoContable = 1 Then
                MsgBox("El mes ya se encuentra cerrado", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            Dim fecha As Date
            fecha = "01/" & cmbMes.Value & "/" & txtAño.Value
            'fecha = DateAdd(DateInterval.Day, -1, fecha)

            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Return
            Else
                Entidad.Entregas = New ETEntregas
                Entidad.Entregas.fechacontable = Convert.ToDateTime(fecha).ToString("dd/MM/yyyy")
                Entidad.Entregas.Usuario = User_Sistema
                Entidad.Entregas = Negocio.NEntregas.GeneraAsientoEntregasProvision(Entidad.Entregas)
                lResult = New ETMyLista
                lResult = Entidad.MyLista

                If Entidad.Entregas.Validacion Then
                    'If Not Entidad.Entregas.nVoucher.Trim = "" Then
                    'MsgBox("N° de registro generado : " & Entidad.Entregas.nVoucher, MsgBoxStyle.Exclamation, msgComacsa)
                    lblmensaje.Visible = True
                    lblmensaje.Text = "Generando Reporte de Asiento..."
                    lblmensaje.Refresh()
                    lblmensaje.Update()
                    Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                    Dim frm As New Frm_RptAsientoProvision
                    frm.MdiParent = MdiParent
                    frm.esDevolucion = esDevolucion
                    frm.voucherconta = "0317" & Entidad.Entregas.nVoucher.ToString.Trim
                    frm.cgvoucher = "0317" & Entidad.Entregas.nVoucherInerno.ToString.Trim
                    Dim año As String = IIf(cmbMes.Value = 1, txtAño.Value - 1, txtAño.Value)
                    Dim mes As String = IIf(cmbMes.Value = 1, 12, cmbMes.Value - 1)
                    Dim ReportesBL As New NGReportes
                    Dim ds As New DataSet
                    ds = ReportesBL.RptAsientoProvision("", "", año, mes)
                    If ds.Tables(0).Rows.Count = 0 Then
                        MsgBox("No existen datos de asiento", MsgBoxStyle.Information, msgComacsa)
                        Exit Sub
                    End If
                    frm.ds1 = ds
                    frm.Show()
                    Exit Sub
                End If

            End If
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End Try
    End Sub

    Private Sub btnLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiquidacion.Click
        Try
            If Grid1.ActiveRow Is Nothing Then MsgBox("Debe seleccionar un registro", MsgBoxStyle.Information, msgComacsa) : Return
            nroSolicitud = Me.Grid1.ActiveRow.Cells("NUMSOLICITUD").Value.ToString
            If nroSolicitud.ToString.Trim = "" Then Return
            If Not Grid1.ActiveRow.Cells("NumSolicitud").Value.ToString.Substring(0, 4) = "PEND" Then
                esDevolucion = 0
            Else
                esDevolucion = 1
            End If
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            StrucForm.FxRxLiquidacion = New FrmRptLiquidacion
            StrucForm.FxRxLiquidacion.MdiParent = MdiParent
            StrucForm.FxRxLiquidacion.esDevolucion = esDevolucion
            StrucForm.FxRxLiquidacion.tiporeporte = 1
            StrucForm.FxRxLiquidacion.Show()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnVerAsiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerAsiento.Click
        Try
            If Grid1.ActiveRow Is Nothing Then MsgBox("Debe seleccionar un registro", MsgBoxStyle.Information, msgComacsa) : Return
            nroSolicitud = Me.Grid1.ActiveRow.Cells("NUMSOLICITUD").Value.ToString
            Dim NUMASIENTO = Me.Grid1.ActiveRow.Cells("NUMASIENTO").Value.ToString
            If nroSolicitud.ToString.Trim = "" Then Return
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte de Asiento..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Dim frm As New Frm_RptAsientoEntregas
            frm.MdiParent = MdiParent
            frm.esDevolucion = esDevolucion
            frm.voucherconta = "0313" & NUMASIENTO.ToString.Trim
            frm.cgvoucher = ""
            frm.año = Year(Me.Grid1.ActiveRow.Cells("FECHACONTABLE").Value)
            frm.mes = Month(Me.Grid1.ActiveRow.Cells("FECHACONTABLE").Value)
            frm.Show()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        Catch ex As Exception

        End Try

    End Sub
    Sub Reporte()
        Try
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte de Asiento..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Dim frm As New Frm_RptAsientoProvision
            frm.MdiParent = MdiParent
            frm.esDevolucion = esDevolucion
            frm.voucherconta = "0317" & Entidad.Entregas.nVoucher.ToString.Trim
            frm.cgvoucher = "0317" & Entidad.Entregas.nVoucherInerno.ToString.Trim
            Dim año As String = IIf(cmbMes.Value = 1, txtAño.Value - 1, txtAño.Value)
            Dim mes As String = IIf(cmbMes.Value = 1, 12, cmbMes.Value - 1)
            Dim ReportesBL As New NGReportes
            Dim ds As New DataSet
            ds = ReportesBL.RptAsientoProvision("", "", año, mes)
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No existen datos de asiento", MsgBoxStyle.Information, msgComacsa)
                Exit Sub
            End If
            frm.ds1 = ds
            frm.Show()
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End Try


    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Procesar()
    End Sub


End Class