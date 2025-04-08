Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Public Class FrmProyectoTrabajador
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim formatoMoneda As String = "#####0.00"
    Dim dtTipos As DataTable
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto

    Private Sub FrmProyectoTrabajador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
        cmbMes.Value = Now.Date.Month
        Procesar()
    End Sub
    Sub Procesar()
        Tab1.Tabs("T01").Selected = True
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        Dim dtdatos As New DataTable
        dtdatos = _objNegocio.ListarProyecto(_objEntidad)
        gridproyecto.DataSource = dtdatos
    End Sub

    Private Sub gridproyecto_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridproyecto.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = True
            txtid.Text = gridproyecto.ActiveRow.Cells("ID").Value
            txtproyecto.Text = gridproyecto.ActiveRow.Cells("PROYECTO").Value
            ListaTrabajadorProyecto()
            Limpiar()
        Catch ex As Exception

        End Try
    End Sub

    Sub Limpiar()
        txtporcentaje.Text = "0.00"
        txtidtrabajador.Text = 0
        TxtCodigoTrabajador.Clear()
        TxtNombresTrabajador.Clear()
        TxtCodigoTrabajador.Focus()
    End Sub

    Private Sub TxtCodigoTrabajador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoTrabajador.KeyPress
        Dim FRM As New FrmListadoPersonal
        FRM.cencos = "961"
        FRM.ShowDialog()
        If codTrabajador.ToString.Trim = "" Then Return
        TxtCodigoTrabajador.Text = codTrabajador.ToString.Trim
        TxtNombresTrabajador.Text = nomTrabajador.ToString.Trim
        txtporcentaje.Focus()
    End Sub

    Private Sub txtporcentaje_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtporcentaje.KeyDown
        If e.KeyValue = 13 Then
            btnAgregar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub UltraTextEditor1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtporcentaje.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            If txtporcentaje.Text.Trim = "" Then txtporcentaje.Text = 0
            If TxtCodigoTrabajador.Text = "" Then MsgBox("Ingrese código de trabajador", MsgBoxStyle.Exclamation, msgComacsa) : txtporcentaje.Focus() : Exit Sub
            If txtporcentaje.Text <= 0 Then MsgBox("Debe ingresar un porcentaje válido mayor a 0%", MsgBoxStyle.Exclamation, msgComacsa) : txtporcentaje.Focus() : Exit Sub
            If txtporcentaje.Text > 100 Then MsgBox("Debe ingresar un porcentaje válido menor a 100%", MsgBoxStyle.Exclamation, msgComacsa) : txtporcentaje.Focus() : Exit Sub

            If MsgBox("Desea grabar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto

            _objEntidad.Operacion = 1
            _objEntidad.ID = txtidtrabajador.Text
            _objEntidad.IDPROYECTO = txtid.Text
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.CodTrabajador = TxtCodigoTrabajador.Text
            _objEntidad.Porcentaje = txtporcentaje.Text
            _objEntidad.Usuario = User_Sistema

            Dim dtdatos As New DataTable
            dtdatos = _objNegocio.MantenimientoProyectoTrabajador(_objEntidad)
            If dtdatos.Rows.Count > 0 Then
                If dtdatos.Rows(0)(0).ToString.Trim.ToUpper = "OK" Then
                    MsgBox("Datos guardados correctamente", MsgBoxStyle.Information, msgComacsa)
                    ListaTrabajadorProyecto()
                    Limpiar()
                Else
                    MsgBox(dtdatos.Rows(0)(0).ToString.Trim.ToUpper(), MsgBoxStyle.Exclamation, msgComacsa)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub ListaTrabajadorProyecto()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.IDPROYECTO = txtid.Text
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        Dim dtdatos As New DataTable
        dtdatos = _objNegocio.ListarProyectoTrabajador(_objEntidad)
        gridTrabajadorProyecto.DataSource = dtdatos
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            ListaTrabajadorProyecto()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtayo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtayo.ValueChanged
        Try
            ListaTrabajadorProyecto()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridTrabajadorProyecto_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridTrabajadorProyecto.ClickCell
        Try
            If gridTrabajadorProyecto.ActiveRow.Cells(gridTrabajadorProyecto.ActiveCell.Column.Index).Column.Key = "ACCION" Then
                If MsgBox("Desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
                _objNegocio = New NGProducto
                _objEntidad = New ETProducto

                _objEntidad.Operacion = 3
                _objEntidad.ID = gridTrabajadorProyecto.ActiveRow.Cells("ID").Value
                _objEntidad.IDPROYECTO = txtid.Text
                _objEntidad.Anho = txtayo.Value
                _objEntidad.Mes = cmbMes.Value
                _objEntidad.CodTrabajador = TxtCodigoTrabajador.Text
                _objEntidad.Porcentaje = txtporcentaje.Text
                _objEntidad.Usuario = User_Sistema

                Dim dtdatos As New DataTable
                dtdatos = _objNegocio.MantenimientoProyectoTrabajador(_objEntidad)
                If dtdatos.Rows.Count > 0 Then
                    If dtdatos.Rows(0)(0).ToString.Trim.ToUpper = "OK" Then
                        MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
                        ListaTrabajadorProyecto()
                        Limpiar()
                    Else
                        MsgBox(dtdatos.Rows(0)(0).ToString.Trim.ToUpper(), MsgBoxStyle.Exclamation, msgComacsa)
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridTrabajadorProyecto_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridTrabajadorProyecto.DoubleClickRow
        Try
            txtidtrabajador.Text = gridTrabajadorProyecto.ActiveRow.Cells("ID").Value
            TxtCodigoTrabajador.Text = gridTrabajadorProyecto.ActiveRow.Cells("COD_TRABAJADOR").Value
            TxtNombresTrabajador.Text = gridTrabajadorProyecto.ActiveRow.Cells("TRABAJADOR").Value
            txtporcentaje.Text = gridTrabajadorProyecto.ActiveRow.Cells("PORCENTAJE").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnreplica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreplica.Click
        If txtid.Text = 0 Then MsgBox("Seleccione proyecto", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub

        If gridTrabajadorProyecto.Rows.Count > 0 Then
            MsgBox("Ya existen datos registrados en el periodo seleccionado", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If MsgBox("Desea replicar datos del mes anterior?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub

        _objNegocio = New NGProducto
        _objEntidad = New ETProducto

        _objEntidad.IDPROYECTO = txtid.Text
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        _objEntidad.Usuario = User_Sistema

        Dim dtdatos As New DataTable
        dtdatos = _objNegocio.ReplicaProyectoTrabajador(_objEntidad)
        If dtdatos.Rows.Count > 0 Then
            If dtdatos.Rows(0)(0).ToString.Trim.ToUpper = "OK" Then
                ListaTrabajadorProyecto()
                Limpiar()
            Else
                MsgBox(dtdatos.Rows(0)(0).ToString.Trim.ToUpper(), MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
    End Sub
End Class