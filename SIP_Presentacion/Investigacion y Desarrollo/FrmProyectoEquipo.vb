Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Public Class FrmProyectoEquipo
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
        TxtCodigoEquipo.Clear()
        TxtEquipo.Clear()
        TxtCodigoEquipo.Focus()
    End Sub

    Private Sub TxtCodigoTrabajador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoEquipo.KeyPress
        Dim FRM As New FrmBuscarEquipo
        FRM.ShowDialog()
        TxtCodigoEquipo.Text = FRM.gridMaquina.ActiveRow.Cells("PLACA").Value.ToString
        TxtEquipo.Text = FRM.gridMaquina.ActiveRow.Cells("DESCRIPCION").Value.ToString
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
            If TxtCodigoEquipo.Text = "" Then MsgBox("Ingrese código de equipo", MsgBoxStyle.Exclamation, msgComacsa) : txtporcentaje.Focus() : Exit Sub
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
            _objEntidad.CodEquipo = TxtCodigoEquipo.Text
            _objEntidad.Porcentaje = txtporcentaje.Text
            _objEntidad.Usuario = User_Sistema

            Dim dtdatos As New DataTable
            dtdatos = _objNegocio.MantenimientoProyectoEquipo(_objEntidad)
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
        dtdatos = _objNegocio.ListarProyectoEquipo(_objEntidad)
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
                _objEntidad.CodEquipo = TxtCodigoEquipo.Text
                _objEntidad.Porcentaje = txtporcentaje.Text
                _objEntidad.Usuario = User_Sistema

                Dim dtdatos As New DataTable
                dtdatos = _objNegocio.MantenimientoProyectoEquipo(_objEntidad)
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

    Private Sub gridTrabajadorProyecto_DoubleClickRow1(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridTrabajadorProyecto.DoubleClickRow
        Try
            txtidtrabajador.Text = gridTrabajadorProyecto.ActiveRow.Cells("ID").Value
            TxtCodigoEquipo.Text = gridTrabajadorProyecto.ActiveRow.Cells("COD_EQUIPO").Value
            TxtEquipo.Text = gridTrabajadorProyecto.ActiveRow.Cells("EQUIPO").Value
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
        dtdatos = _objNegocio.ReplicaProyectoEquipo(_objEntidad)
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