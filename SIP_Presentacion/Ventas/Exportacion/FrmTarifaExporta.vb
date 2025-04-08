Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class FrmTarifaExporta
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Public ConceptoSeleccionado As String
    Public filtroDescripcion As String = String.Empty
#End Region
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Public aprobado As Int32 = 0
    Private Sub FrmTarifaExporta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Limpiar()
        cargaDatos()
        cmbtipo.Value = "F"
    End Sub
    Sub cargaDatos()
        Dim dtDatos As New DataTable
        dtDatos = New DataTable
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        dtDatos = _objNegocio.LISTA_NAVIERA(_objEntidad)
        Call CargarUltraGridxBinding(Me.gridCampania, Source1, dtDatos)

        Dim dtAprobado As New DataTable
        dtAprobado = New DataTable
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Usuario = User_Sistema
        dtAprobado = _objNegocio.APRUEBA_TARIFA(_objEntidad)
        If dtAprobado.Rows.Count > 0 Then
            aprobado = 1
        Else
            aprobado = 0
        End If
    End Sub

    Private Sub gridCampania_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridCampania.DoubleClickRow
        Try
            txtid.Text = gridCampania.ActiveRow.Cells("ID_NAVIERA").Value            
            CargaTarifa()
            Tab1.Tabs("T02").Selected = Boolean.TrueString
        Catch ex As Exception

        End Try
    End Sub

    Sub CargaTarifa()
        Dim dtDatos As New DataTable
        dtDatos = New DataTable
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.ID = txtid.Text
        dtDatos = _objNegocio.LISTA_TARIFA_NAV(_objEntidad)
        Call CargarUltraGridxBinding(Me.UltraGrid1, Source2, dtDatos)

        If aprobado = 0 Then
            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.ActivateOnly
        Else
            Me.UltraGrid1.DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.AllowEdit
        End If

    End Sub

    Private Sub txttarifa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttarifa.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Sub Grabar()
        Try
            If Tab1.Tabs("T02").Selected = False Then Exit Sub
            UltraGrid1.PerformAction(ExitEditMode)
            If MsgBox("Desea grabar la información?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
            If txttarifa.Text = "" Then txttarifa.Text = 0
            If txtConcepto.Text.Trim <> "" And txttarifa.Text <> 0 Then
                Dim dtDatos As New DataTable
                dtDatos = New DataTable
                _objNegocio = New NGProducto
                _objEntidad = New ETProducto
                _objEntidad.ID = txtidtarifa.Text
                _objEntidad.IDNAVIERA = txtid.Text
                _objEntidad.Descripcion = txtConcepto.Text
                _objEntidad.Moneda = cmbMoneda.Value
                _objEntidad.Total = txttarifa.Text
                _objEntidad.tipotarifa = cmbtipo.Value
                _objEntidad.Factor = txtfactor.Value
                _objEntidad.aprobado = 0
                _objEntidad.Usuario = User_Sistema
                dtDatos = _objNegocio.MANT_TARIFA_NAV(_objEntidad)
            End If


            If aprobado = 1 Then
                For i As Int32 = 0 To UltraGrid1.Rows.Count - 1
                    Dim dtDatos As New DataTable
                    dtDatos = New DataTable
                    _objNegocio = New NGProducto
                    _objEntidad = New ETProducto
                    _objEntidad.ID = UltraGrid1.Rows(i).Cells("ID").Value
                    _objEntidad.aprobado = IIf(UltraGrid1.Rows(i).Cells("ACTION").Value, 1, 0)
                    _objEntidad.Usuario = User_Sistema
                    dtDatos = _objNegocio.APRUEBA_TARIFA_NAV(_objEntidad)
                Next
            End If

            CargaTarifa()
            Limpiar()
        Catch ex As Exception

        End Try
    End Sub

    Sub Nuevo()
        If Tab1.Tabs("T01").Selected = True Then
            Limpiar()
            gbIngreso.Visible = True
            gridCampania.Enabled = False
        End If
    End Sub

    Sub Eliminar()
        If Tab1.Tabs("T01").Selected = False Then Exit Sub
        If MsgBox("Desea eliminar registro?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
        Dim dtDatos As New DataTable
        dtDatos = New DataTable
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Operacion = 3
        _objEntidad.IDNAVIERA = gridCampania.ActiveRow.Cells("ID_NAVIERA").Value
        _objEntidad.IDTIPO = gridCampania.ActiveRow.Cells("ID_TIPO").Value
        _objEntidad.DESCTIPO = gridCampania.ActiveRow.Cells("TIPO").Value
        _objEntidad.NAVIERA = gridCampania.ActiveRow.Cells("PROVEEDOR").Value
        dtDatos = _objNegocio.MANT_NAVIERA(_objEntidad)
        If dtDatos.Rows.Count > 0 Then
            If dtDatos.Rows(0)(0) = "OK" Then
                MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, "Sistema")
                gbIngreso.Visible = False
                gridCampania.Enabled = True
                cargaDatos()
            Else
                MsgBox(dtDatos.Rows(0)(0), MsgBoxStyle.Exclamation, "Sistema")
            End If
        End If
    End Sub
    Sub Modificar()
        gbIngreso.Visible = True
        gridCampania.Enabled = False
        txtidprov.Text = gridCampania.ActiveRow.Cells("ID_NAVIERA").Value
        cmbtipoprov.Value = gridCampania.ActiveRow.Cells("ID_TIPO").Value
        txtproveedor.Text = gridCampania.ActiveRow.Cells("PROVEEDOR").Value
        txtproveedor.Focus()
    End Sub

    Sub Limpiar()
        txtidtarifa.Text = 0
        txtConcepto.Clear()
        txttarifa.Clear()
        txtidtarifa.Text = 0
        txtfactor.Text = 0
        txtidprov.Text = 0
        txtproveedor.Clear()
    End Sub

    Private Sub UltraGrid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles UltraGrid1.DoubleClickRow
        Try
            txtConcepto.Text = UltraGrid1.ActiveRow.Cells("CONCEPTO").Value
            cmbMoneda.Value = UltraGrid1.ActiveRow.Cells("MONEDA").Value
            txttarifa.Text = UltraGrid1.ActiveRow.Cells("TARIFA").Value
            txtidtarifa.Text = UltraGrid1.ActiveRow.Cells("ID").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbtipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipo.ValueChanged
        Try
            If cmbtipo.Value = "V" Then
                lblfactor.Visible = True
                txtfactor.Visible = True
            Else
                lblfactor.Visible = False
                txtfactor.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtfactor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfactor.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtproveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtproveedor.KeyDown
        Try
            If e.KeyCode = 13 Then
                If MsgBox("Desea grabar registro?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
                Dim dtDatos As New DataTable
                dtDatos = New DataTable
                _objNegocio = New NGProducto
                _objEntidad = New ETProducto
                _objEntidad.Operacion = 1
                _objEntidad.IDNAVIERA = txtidprov.Text
                _objEntidad.IDTIPO = cmbtipoprov.Value
                _objEntidad.DESCTIPO = cmbtipoprov.Text
                _objEntidad.NAVIERA = txtproveedor.Text
                dtDatos = _objNegocio.MANT_NAVIERA(_objEntidad)
                If dtDatos.Rows.Count > 0 Then
                    If dtDatos.Rows(0)(0) = "OK" Then
                        MsgBox("Registro grabado correctamente", MsgBoxStyle.Information, "Sistema")
                        gbIngreso.Visible = False
                        gridCampania.Enabled = True
                        cargaDatos()
                    Else
                        MsgBox(dtDatos.Rows(0)(0), MsgBoxStyle.Exclamation, "Sistema")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbtipoprov_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipoprov.ValueChanged
        Try
            txtproveedor.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UltraLabel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel6.Click
        gbIngreso.Visible = False
        gridCampania.Enabled = True
    End Sub
End Class