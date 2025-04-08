Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmFacturaConcepto
#Region "Declarar Variables"
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Private Ls_DetalleFact As List(Of ETContratista) = Nothing
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
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
#End Region

    Private Sub frmFacturaConcepto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        limpiar()
        dtfecha.Value = Now.Date
        Procesar()
    End Sub
    Sub Procesar()
        CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Entidad.Contratista = New ETContratista
        Entidad.Contratista.TipoOperacion = Ope
        Negocio.NContratista = New NGContratista
        Entidad.MyLista = New ETMyLista
        Entidad.Entregas.Usuario = User_Sistema
        Dim dtDatos As New DataTable
        dtDatos = Negocio.NContratista.ListarCTR_Factura()
        Call CargarUltraGridxBinding(Me.GridAnticipo, Source1, dtDatos)
    End Sub
    Sub CargarConceptos(ByVal idfactura As Int32)
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.Listarconceptos_Fact(idfactura)
        Call CargarUltraGridxBinding(gridconceptos, Source2, dtDatos)
    End Sub
    Sub Nuevo()
        Me.TabMaestroEntregas.Tabs("Registro").Selected = True
        Ope = 1
        flgaprobada = 0
        lblestado.Visible = False
        txtcodcontratista.Clear()
        txtcontratista.Clear()
        limpiar()
        txtcodcontratista.Focus()
        txtcomentario.Clear()
        CargarConceptos(0)
    End Sub
    Sub Buscar()
        If Me.TabMaestroEntregas.Tabs("Lista").Selected = True Then Exit Sub
        If txtcodcontratista.Focused = True Then
            If Ope = 2 Then Exit Sub
            limpiar()
            Dim frm As New frmBuscarContratista
            frm.ShowDialog()
            txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            txtcodcontratista.Text = frm.gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            txtcontratista.Text = frm.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
        End If

        If txtcodcantera.Focused = True Then
            If txtcodcontratista.Text.Trim = "" Then
                MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            limpiar()
            Dim frm As New frmBuscarCantera
            frm.codprov = txtcodcontratista.Text
            frm.ShowDialog()
            txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            txtcodcantera.Text = frm.gridcontratista.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcantera.Text = frm.gridcontratista.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
            'btnCanteras.Visible = True
        End If
        If txtsupervisor.Focused = True Then
            If txtcodcantera.Text.Trim = "" Then
                MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            Dim frm As New frmBuscarSupervisor
            frm.codprov = txtcodcontratista.Text
            frm.cod_cantera = txtcodcantera.Text
            frm.ShowDialog()
            If frm.gridcontratista.Rows.Count = 0 Then
                txtidsupervisor.Text = 0
                txtsupervisor.Text = ""
            Else
                txtidsupervisor.Text = frm.gridcontratista.ActiveRow.Cells("ID_SUPERVISOR").Value
                txtsupervisor.Text = frm.gridcontratista.ActiveRow.Cells("SUPERVISOR").Value.ToString.Trim
            End If
        End If
    End Sub

    Sub limpiar()
        txtcodcantera.Clear()
        txtcantera.Clear()
        txtvalorvta.Clear()
        txtigv.Clear()
        txttotal.Clear()
        txtidfactura.Text = 0
        txtidcontratista.Text = 0
        txtidsupervisor.Text = 0
        dtfecha.Value = Now.Date
        txtsupervisor.Clear()
        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            gridconceptos.Rows(i).Cells("TOTAL").Value = "0.00"
        Next
        'btnCanteras.Visible = False
    End Sub
    Private Sub gridconceptos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridconceptos.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridconceptos) Then Return
            With sender
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Down
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Right
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Left
                        .PerformAction(ExitEditMode)
                        .PerformAction(PrevCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Return
                        .PerformAction(ExitEditMode)
                    
                        If gridconceptos.ActiveRow.Cells(gridconceptos.ActiveCell.Column.Index).Column.Key = "TOTAL" Then
                            calcularTotal()
                            .PerformAction(NextCellByTab)
                        End If

                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        'CalcularTotalComprobantes()
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub calcularTotal()
        Dim valor_vta As Double = 0
        Dim igv As Double = 0
        Dim total As Double = 0
        For I As Int32 = 0 To gridconceptos.Rows.Count - 1
            total = total + Math.Round(CDbl(gridconceptos.Rows(I).Cells("TOTAL").Value), 2)
            valor_vta = Math.Round(CDbl(Math.Round(CDbl(gridconceptos.Rows(I).Cells("TOTAL").Value), 2) / 1.18), 2)
            gridconceptos.Rows(I).Cells("SUBTOTAL").Value = valor_vta
            gridconceptos.Rows(I).Cells("IGV").Value = Math.Round(CDbl(gridconceptos.Rows(I).Cells("TOTAL").Value), 2) - valor_vta
        Next
        valor_vta = Math.Round(CDbl(total / 1.18), 2)
        igv = total - valor_vta
        txtvalorvta.Text = CDbl(total - igv).ToString("#,###0.00")
        txtigv.Text = CDbl(igv).ToString("#,###0.00")
        txttotal.Text = total.ToString("#,###0.00")
    End Sub

    Public Sub Grabar()
        Try
            If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
            If Ope = 0 Then
                MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            calcularTotal()
            If Not validaDatos() Then
                Exit Sub
            End If
            Dim idFactura As Int32 = 0

            Dim fechaActual As Date = Now.Date

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            'seteoEntidadDetalle()
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            objNegocio = New NGContratista
            If MsgBox("¿Seguro de grabar registro?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub
            Entidad.Contratista.TipoOperacion = Ope
            Entidad.Contratista.NumSolicitud = NumSolicitud
            If txtidcontratista.Text.ToString.Trim = "" Then txtidcontratista.Text = 0
            If txtidsupervisor.Text.ToString.Trim = "" Then txtidsupervisor.Text = 0
            Entidad.Contratista.ID = txtidfactura.Text
            Entidad.Contratista._idcontratista = txtidcontratista.Text
            Entidad.Contratista.Fecha = dtfecha.Value
            Entidad.Contratista._observacion = txtcomentario.Text
            Entidad.Contratista.IDSUPERVISOR = txtidsupervisor.Text
            Entidad.Contratista._valorvta = txtvalorvta.Value
            Entidad.Contratista._igv = txtigv.Value
            Entidad.Contratista.montoTotal = txttotal.Value
            Entidad.Contratista.Usuario = User_Sistema

            Dim dtDatos As New DataTable
            dtDatos = objNegocio.Mantconceptos_Fact_Cab(Entidad.Contratista)
            idFactura = dtDatos.Rows(0)(0)
            'Entidad.Contratista = Negocio.NContratista.MantenimientoAnticipo(Entidad.Contratista, Ls_DetalleFact)

            Dim num_solicitud As String = Entidad.Contratista.NumSolicitud
            If idFactura <> 0 Then

                If gridconceptos.Rows.Count > 0 Then
                    'MsgBox(IIf(dtCanteras.Rows(0)("Action").ToString = "True", 1, 0))
                    For i As Int32 = 0 To gridconceptos.Rows.Count - 1
                        Entidad.Contratista = New ETContratista
                        Entidad.Contratista.ID = idFactura
                        Entidad.Contratista._idconcepto = gridconceptos.Rows(i).Cells("ID_CONCEPTO").Value
                        Entidad.Contratista._valorvta = gridconceptos.Rows(i).Cells("SUBTOTAL").Value
                        Entidad.Contratista._igv = gridconceptos.Rows(i).Cells("IGV").Value
                        Entidad.Contratista.montoTotal = gridconceptos.Rows(i).Cells("TOTAL").Value
                        dtDatos = New DataTable
                        dtDatos = objNegocio.Mantconceptos_Fact_Det(Entidad.Contratista)
                        'Ls_DetalleFact.Add(Entidad.Contratista)
                    Next
                    'Entidad.Contratista = Negocio.NContratista.InsertaCanteraAnticipo(Ls_DetalleFact)
                End If

                MsgBox("Grabado correctamente", MsgBoxStyle.Information, msgComacsa)
                Call Nuevo()
                CargarDatos()
                TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
            End If
            'MsgBox(Ls_Anticipo.Count)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Public Sub Eliminar()
        Try
            If TabMaestroEntregas.SelectedTab.Key <> "Lista" Then Return
            calcularTotal()
            Dim idFactura As Int32 = 0

            Dim fechaActual As Date = Now.Date

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            'seteoEntidadDetalle()
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            objNegocio = New NGContratista
            If MsgBox("¿Seguro de eliminar registro?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub
            Entidad.Contratista.TipoOperacion = 3
            Entidad.Contratista.NumSolicitud = NumSolicitud
            If txtidcontratista.Text.ToString.Trim = "" Then txtidcontratista.Text = 0
            If txtidsupervisor.Text.ToString.Trim = "" Then txtidsupervisor.Text = 0
            Entidad.Contratista.ID = GridAnticipo.ActiveRow.Cells("ID_FACTURA").Value
            Entidad.Contratista._idcontratista = txtidcontratista.Text
            Entidad.Contratista.Fecha = dtfecha.Value
            Entidad.Contratista._observacion = txtcomentario.Text
            Entidad.Contratista.IDSUPERVISOR = txtidsupervisor.Text
            Entidad.Contratista._valorvta = txtvalorvta.Value
            Entidad.Contratista._igv = txtigv.Value
            Entidad.Contratista.montoTotal = txttotal.Value
            Entidad.Contratista._usuario = User_Sistema

            Dim dtDatos As New DataTable
            dtDatos = objNegocio.Mantconceptos_Fact_Cab(Entidad.Contratista)
            idFactura = dtDatos.Rows(0)(0)
            'Entidad.Contratista = Negocio.NContratista.MantenimientoAnticipo(Entidad.Contratista, Ls_DetalleFact)

            Dim num_solicitud As String = Entidad.Contratista.NumSolicitud
            MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            Call Nuevo()
            CargarDatos()
            TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString

            'MsgBox(Ls_Anticipo.Count)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Function validaDatos() As Boolean
        If txtcodcontratista.Text.ToString.Trim = "" Then
            MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcontratista.Focus()
            Return False
        End If
        If txtcodcantera.Text.ToString.Trim = "" Then
            MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcantera.Focus()
            Return False
        End If

        If txtcomentario.Text.ToString.Trim = "" Then
            MsgBox("Ingrese Comentario", MsgBoxStyle.Exclamation, msgComacsa)
            txtcomentario.Focus()
            Return False
        End If

        If txttotal.Text.ToString.Trim = "" Then txttotal.Text = 0
        If txttotal.Text = 0 Then
            MsgBox("Ingrese monto de la Factura", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If
        Return True
    End Function

    Private Sub GridAnticipo_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridAnticipo.DoubleClickRow
        Try
            txtidfactura.Text = GridAnticipo.ActiveRow.Cells("ID_FACTURA").Value
            txtidcontratista.Text = GridAnticipo.ActiveRow.Cells("IDCONTRATISTA").Value
            txtcodcontratista.Text = GridAnticipo.ActiveRow.Cells("COD_PROV").Value
            txtcontratista.Text = GridAnticipo.ActiveRow.Cells("RAZSOC").Value
            txtcodcantera.Text = GridAnticipo.ActiveRow.Cells("CODCANTERA").Value
            txtcantera.Text = GridAnticipo.ActiveRow.Cells("CANTERA").Value
            txtidsupervisor.Text = GridAnticipo.ActiveRow.Cells("ID_SUPERVISOR").Value
            txtsupervisor.Text = GridAnticipo.ActiveRow.Cells("SUPERVISOR").Value
            dtfecha.Value = GridAnticipo.ActiveRow.Cells("FECHA").Value
            txtcomentario.Text = GridAnticipo.ActiveRow.Cells("OBSERVACION").Value
            txtvalorvta.Text = CDbl(GridAnticipo.ActiveRow.Cells("VALOR_VTA").Value).ToString("#,###0.00")
            txtigv.Text = CDbl(GridAnticipo.ActiveRow.Cells("IGV").Value).ToString("#,###0.00")
            txttotal.Text = CDbl(GridAnticipo.ActiveRow.Cells("TOTAL").Value).ToString("#,###0.00")
            Me.TabMaestroEntregas.Tabs("Registro").Selected = True
            CargarConceptos(txtidfactura.Text)
        Catch ex As Exception

        End Try
    End Sub
End Class