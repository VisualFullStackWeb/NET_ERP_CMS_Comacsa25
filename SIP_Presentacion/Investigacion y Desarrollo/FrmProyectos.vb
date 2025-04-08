Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Public Class FrmProyectos
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim formatoMoneda As String = "#####0.00"
    Dim dtTipos As DataTable
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Private Sub FrmProyectos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFecha.Value = Now.Date

        Dim frm As New FrmAuxi3
        frm.tipo = 0
        frm.codarea = "961"
        frm.CargarDatos()

        If frm.gridConceptos.Rows.Count = 1 Then
            txtarea.Text = frm.gridConceptos.Rows(0).Cells("Auxiliar").Value
            txtcodarea.Text = frm.gridConceptos.Rows(0).Cells("codAuxiliar").Value
        End If
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

    Sub Grabar()
        If Tab1.Tabs("T01").Selected = True Then Exit Sub
        If txtproyecto.Text.Trim = "" Then
            MsgBox("Ingrese nombre del proyecto", MsgBoxStyle.Information, msgComacsa) : Exit Sub
        End If

        If txtDescripcion.Text.Trim = "" Then
            MsgBox("Ingrese descripcion del proyecto", MsgBoxStyle.Information, msgComacsa) : Exit Sub
        End If

        If txtcodarea.Text.Trim = "" Then
            MsgBox("Ingrese área relazionada proyecto", MsgBoxStyle.Information, msgComacsa) : Exit Sub
        End If
        If MsgBox("Desea grabar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto

        _objEntidad.Operacion = 1
        _objEntidad.ID = txtid.Text
        _objEntidad.Proyecto = txtproyecto.Text
        _objEntidad.Descripcion = txtDescripcion.Text
        _objEntidad.Fecha = dtFecha.Value
        _objEntidad.Area = txtcodarea.Text
        _objEntidad.Usuario = User_Sistema
        Dim dtdatos As New DataTable
        dtdatos = _objNegocio.MantenimientoProyecto(_objEntidad)
        If dtdatos.Rows.Count > 0 Then
            If dtdatos.Rows(0)(0).ToString.Trim.ToUpper = "OK" Then
                MsgBox("Datos guardados correctamente", MsgBoxStyle.Information, msgComacsa)
                Limpiar()
                Tab1.Tabs("T01").Selected = True
                Procesar()
            End If
        End If
    End Sub

    Sub Eliminar()
        If Tab1.Tabs("T01").Selected = True Then Exit Sub
        If txtid.Text = 0 Then
            MsgBox("Seleccione registro a eliminar", MsgBoxStyle.Information, msgComacsa) : Exit Sub
        End If

        If txtproyecto.Text.Trim = "" Then
            MsgBox("Ingrese nombre del proyecto", MsgBoxStyle.Information, msgComacsa) : Exit Sub
        End If

        If txtDescripcion.Text.Trim = "" Then
            MsgBox("Ingrese descripcion del proyecto", MsgBoxStyle.Information, msgComacsa) : Exit Sub
        End If

        If txtcodarea.Text.Trim = "" Then
            MsgBox("Ingrese área relazionada proyecto", MsgBoxStyle.Information, msgComacsa) : Exit Sub
        End If
        If MsgBox("Desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto

        _objEntidad.Operacion = 3
        _objEntidad.ID = txtid.Text
        _objEntidad.Proyecto = txtproyecto.Text
        _objEntidad.Descripcion = txtDescripcion.Text
        _objEntidad.Fecha = dtFecha.Value
        _objEntidad.Area = txtcodarea.Text
        _objEntidad.Usuario = User_Sistema
        Dim dtdatos As New DataTable
        dtdatos = _objNegocio.MantenimientoProyecto(_objEntidad)
        If dtdatos.Rows.Count > 0 Then
            If dtdatos.Rows(0)(0).ToString.Trim.ToUpper = "OK" Then
                MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
                Limpiar()
                Tab1.Tabs("T01").Selected = True
                Procesar()
            End If
        End If
    End Sub

    Sub Nuevo()
        Tab1.Tabs("T02").Selected = True
        Limpiar()
    End Sub

    Sub Limpiar()
        txtproyecto.Clear()
        txtDescripcion.Clear()
        dtFecha.Value = Now.Date
        txtproyecto.Focus()
        txtid.Text = 0
    End Sub

    Sub buscar()
        Dim frm As New FrmAuxi3
        frm.tipo = 0
        frm.codarea = "961"
        frm.ShowDialog()
        If codAuxiliar.Trim = "" Then Exit Sub
        txtcodarea.Text = codAuxiliar
        txtarea.Text = Auxiliar
        'gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Descripcion").Value = Auxiliar
    End Sub

    Private Sub gridcostopromedio_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridproyecto.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = True
            txtid.Text = gridproyecto.ActiveRow.Cells("ID").Value
            txtproyecto.Text = gridproyecto.ActiveRow.Cells("PROYECTO").Value
            txtDescripcion.Text = gridproyecto.ActiveRow.Cells("DESCRIPCION").Value
            txtcodarea.Text = gridproyecto.ActiveRow.Cells("COD_AREA").Value
            txtarea.Text = gridproyecto.ActiveRow.Cells("DPTO").Value
            dtFecha.Value = gridproyecto.ActiveRow.Cells("FECHA_INI").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridproyecto_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridproyecto.InitializeLayout

    End Sub
End Class