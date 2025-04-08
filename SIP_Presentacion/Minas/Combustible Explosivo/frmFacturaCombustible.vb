Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class frmFacturaCombustible
    Dim dtDetalle As DataTable
    Dim flgtrans As Int32
    Dim tipomov As String
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista
    Private Ls_Anticipo As List(Of ETContratista) = Nothing
#Region "Variables"
    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private ListModulos As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim Ope = 1
#End Region

    Private Sub frmFacturaCombustible_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDesde.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
        dtpHasta.Value = Now.Date
        dtpDesde1.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
        dtpHasta1.Value = Now.Date
        txtayo.Value = Now.Date.Year
        limpiar()
        cargarDatos()
    End Sub
    Sub procesar()
        limpiar()
        cargarDatos()
        Tab1.Tabs("T01").Selected = True
    End Sub
    Sub cargarDatos()
        Try
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad.ID = txtid.Text
            objEntidad._fecha1 = dtpDesde.Value
            objEntidad._fecha2 = dtpHasta.Value
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.LISTA_CE_FACT_COMBUSTIBLE_CAB(objEntidad)
            Call CargarUltraGridxBinding(gridCarga, Source1, dtDatos)
        Catch ex As Exception

        End Try
    End Sub

    Sub Buscar()
        If cmbMes.Enabled = False Then
            Exit Sub
        End If
        If txtalmorigen.Focused = True Then
            txtalmorigen.Clear()
            Dim frm As New frmBuscarAlmacen
            frm.ShowDialog()
            txtalmorigen.Text = frm.gridAlmacen.ActiveRow.Cells("ALMACEN").Value.ToString.Trim
            txtidalmorigen.Text = frm.gridAlmacen.ActiveRow.Cells("COD_ALMACEN").Value.ToString.Trim
            txtcodcanteraori.Text = frm.gridAlmacen.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcanteraori.Text = frm.gridAlmacen.ActiveRow.Cells("CANTERA").Value.ToString.Trim
        End If
        If txtcliente.Focused = True Then
            txtcliente.Clear()
            txtcodcliente.Clear()
            Dim frm As New frmBuscarCliente
            frm.ShowDialog()
            txtcliente.Text = frm.gridCliente.ActiveRow.Cells("RAZON").Value.ToString.Trim
            txtcodcliente.Text = frm.gridCliente.ActiveRow.Cells("COD_CLI").Value.ToString.Trim
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad.ID = txtid.Text
            objEntidad.Anho = txtayo.Value
            objEntidad.Mes = cmbMes.Value
            objEntidad._fecha1 = dtpDesde1.Value
            objEntidad._fecha2 = dtpHasta1.Value
            objEntidad._codcli = txtcodcliente.Text
            objEntidad._codcantera = txtcodcanteraori.Text
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.CTR_ListarCombustible(objEntidad)
            Call CargarUltraGridxBinding(gridProductos, Source2, dtDatos)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chktodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktodo.CheckedChanged
        For i As Int32 = 0 To gridProductos.Rows.Count - 1
            gridProductos.Rows(i).Cells("ACTION").Value = chktodo.Checked
        Next
    End Sub

    Private Sub gridProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridProductos.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridProductos) Then Return
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
                        Totales()
                        'Dim cantidad As Double = 0
                        'Dim precio As Double = 0
                        'Dim total As Double = 0
                        'If gridProductos.ActiveRow.Cells(gridProductos.ActiveCell.Column.Index).Column.Key = "PRECIO" Then
                        '    cantidad = gridProductos.ActiveRow.Cells("CANTIDAD").Value
                        '    precio = gridProductos.ActiveRow.Cells("PRECIO").Value
                        '    total = cantidad * precio
                        '    gridProductos.ActiveRow.Cells("TOTAL").Value = total
                        '    'Total()
                        'End If
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        'btnAgregar.Enabled = True
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub nuevo()
        Tab1.Tabs("T02").Selected = True
        limpiar()
    End Sub
    Sub limpiar()
        txtalmorigen.Clear()
        txtcliente.Clear()
        txtcodcanteraori.Clear()
        txtcanteraori.Clear()
        txtcodcliente.Clear()
        txtcodequipo.Clear()
        txtidalmorigen.Clear()
        txtid.Text = 0
        txtalmorigen.Focus()
        cmbMes.Value = 0
        cmbMes.SelectedIndex = -1
        cmbMes.Enabled = True
        cmbMoneda.Value = "S"
        cmbMoneda.Enabled = False
        txttotal.Text = "0.00"
        Button1_Click(Nothing, Nothing)
    End Sub
    Sub Totales()
        gridProductos.PerformAction(ExitEditMode)
        Dim cantidad As Double = 0
        Dim precio As Double = 0
        Dim subtotal As Double = 0
        Dim total As Double = 0
        For i As Int32 = 0 To gridProductos.Rows.Count - 1
            cantidad = gridProductos.Rows(i).Cells("CANTIDAD").Value
            precio = gridProductos.Rows(i).Cells("PRECIO").Value
            subtotal = cantidad * precio
            gridProductos.Rows(i).Cells("TOTAL").Value = subtotal
            total = total + subtotal
        Next
        txttotal.Text = CDbl(total).ToString("###,##0.00")
    End Sub

    Sub Reporte()
        If Tab1.Tabs("T01").Selected = True Then
            Exit Sub
        End If
        lblmensaje.Visible = True
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Refresh()
        lblmensaje.Update()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        StrucForm.FxRxFactCombustible = New FrmRptFactCombustible
        'StrucForm.FxRxSolicitud.TextReporte = "Cuadro Enlace (Producto - Unidad)"
        StrucForm.FxRxFactCombustible.MdiParent = MdiParent
        StrucForm.FxRxFactCombustible.id = txtid.Text
        StrucForm.FxRxFactCombustible.Show()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        lblmensaje.Visible = False
        lblmensaje.Refresh()
        lblmensaje.Update()
    End Sub

    Sub Eliminar()
        If Tab1.Tabs("T01").Selected = True Then
            Exit Sub
        End If
        If MsgBox("¿Seguro desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return
        End If
        Dim idcab As Integer = 0
        Try
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad.Operacion = 3
            objEntidad.ID = txtid.Text
            objEntidad.Anho = txtayo.Value
            objEntidad.Mes = cmbMes.Value
            objEntidad._fecha1 = dtpDesde1.Value
            objEntidad._fecha2 = dtpHasta1.Value
            objEntidad._codcli = txtcodcliente.Text
            objEntidad._codcantera = txtcodcanteraori.Text
            objEntidad.Total = 0
            objEntidad.moneda = cmbMoneda.Value
            objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.CTR_CE_FACT_COMBUSTIBLE_CAB(objEntidad)
            If dtDatos.Rows.Count > 0 Then
                idcab = dtDatos.Rows(0)(0)
            End If
            MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            procesar()
            Tab1.Tabs("T01").Selected = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub Grabar()
        Totales()
        If txttotal.Text = "" Then txttotal.Text = "0.00"
        If CDbl(txttotal.Text) = 0 Then
            MsgBox("Debe ingresar detalle de factura", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        If MsgBox("¿Seguro desea guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return
        End If
        Dim idcab As Integer = 0
        Try
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad.Operacion = 1
            objEntidad.ID = txtid.Text
            objEntidad.Anho = txtayo.Value
            objEntidad.Mes = cmbMes.Value
            objEntidad._fecha1 = dtpDesde1.Value
            objEntidad._fecha2 = dtpHasta1.Value
            objEntidad._codcli = txtcodcliente.Text
            objEntidad._codcantera = txtcodcanteraori.Text
            objEntidad.Total = CDbl(txttotal.Text)
            objEntidad.moneda = cmbMoneda.Value
            objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.CTR_CE_FACT_COMBUSTIBLE_CAB(objEntidad)
            If dtDatos.Rows.Count > 0 Then
                idcab = dtDatos.Rows(0)(0)
            End If

            For i As Int32 = 0 To gridProductos.Rows.Count - 1
                objNegocio = New NGContratista
                objEntidad = New ETContratista
                objEntidad._idconcepto = gridProductos.Rows(i).Cells("IDDET").Value
                objEntidad.ID = idcab
                objEntidad._codprod = gridProductos.Rows(i).Cells("COD_PROD").Value
                objEntidad.Cantidad = gridProductos.Rows(i).Cells("CANTIDAD").Value
                objEntidad._precio = gridProductos.Rows(i).Cells("PRECIO").Value
                objEntidad.Total = gridProductos.Rows(i).Cells("TOTAL").Value
                objEntidad._idtipomov = gridProductos.Rows(i).Cells("ID").Value
                dtDatos = New DataTable
                dtDatos = objNegocio.CTR_CE_FACT_COMBUSTIBLE_DET(objEntidad)
            Next
            MsgBox("Datos guardados correctamente", MsgBoxStyle.Information, msgComacsa)
            procesar()
            Tab1.Tabs("T01").Selected = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub gridCarga_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridCarga.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = True
            txtid.Text = gridCarga.ActiveRow.Cells("ID").Value
            cmbMes.Value = gridCarga.ActiveRow.Cells("MES").Value
            dtpDesde1.Value = gridCarga.ActiveRow.Cells("FECHA1").Value
            dtpHasta1.Value = gridCarga.ActiveRow.Cells("FECHA2").Value
            txtalmorigen.Text = gridCarga.ActiveRow.Cells("CANTERA").Value
            txtcliente.Text = gridCarga.ActiveRow.Cells("RAZSOC").Value
            txtcodcliente.Text = gridCarga.ActiveRow.Cells("COD_CLI").Value
            txtcodcanteraori.Text = gridCarga.ActiveRow.Cells("CODCANTERA").Value
            cmbMoneda.Value = gridCarga.ActiveRow.Cells("MONEDA").Value.ToString.Trim
            txttotal.Text = gridCarga.ActiveRow.Cells("TOTAL").Value
            cmbMes.Enabled = False
            Button1_Click(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            Dim fecha1 As Date
            Dim fecha2 As Date
            fecha2 = "15/" & cmbMes.Value & "/" & txtayo.Value
            fecha1 = DateAdd(DateInterval.Month, -1, fecha2)
            fecha1 = DateAdd(DateInterval.Day, 1, fecha1)
            dtpDesde1.Value = fecha1
            dtpHasta1.Value = fecha2
            Button1_Click(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub
End Class