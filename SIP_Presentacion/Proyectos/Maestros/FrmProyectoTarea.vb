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
Imports System.Data
Public Class FrmProyectoTarea
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
    Dim obj_Proyecto As New NGProyecto
    Dim obj_EProyecto As New ETProyecto

    Private Sub FrmProyectoTarea_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Procesar()
    End Sub
    Sub Procesar()
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        Dim dtDatos As New DataTable
        dtDatos = obj_Proyecto.Lista_Tarea(obj_EProyecto)
        gridTarea.DataSource = dtDatos
    End Sub

    Sub Nuevo()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Txttarea.Focus()
        Limpiar()
    End Sub

    Sub Limpiar()
        Txttarea.Clear()
        txtid.Text = 0
    End Sub

    Sub Grabar()
        If MsgBox("Desea registrar tarea?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        Dim dtDatos As New DataTable
        obj_EProyecto.Operacion = 1
        obj_EProyecto.ID = txtid.Text
        obj_EProyecto.desc_tarea = Txttarea.Text
        obj_EProyecto.Usuario = User_Sistema
        dtDatos = obj_Proyecto.Mant_Tarea(obj_EProyecto)
        If dtDatos.Rows.Count > 0 Then
            If dtDatos.Rows(0)(0) = "OK" Then
                MsgBox("Tarea registrada correctamente", MsgBoxStyle.Information, "Sistema")
                Limpiar()
                Procesar()
                Tab1.Tabs("T01").Selected = Boolean.TrueString
            End If
        End If
    End Sub

    Sub Eliminar()
        If MsgBox("Desea eliminar tarea?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        Dim dtDatos As New DataTable
        obj_EProyecto.Operacion = 3
        obj_EProyecto.ID = txtid.Text
        obj_EProyecto.desc_tarea = Txttarea.Text
        obj_EProyecto.Usuario = User_Sistema
        dtDatos = obj_Proyecto.Mant_Tarea(obj_EProyecto)
        If dtDatos.Rows.Count > 0 Then
            If dtDatos.Rows(0)(0) = "OK" Then
                MsgBox("Tarea eliminada correctamente", MsgBoxStyle.Information, "Sistema")
                Limpiar()
                Procesar()
                Tab1.Tabs("T01").Selected = Boolean.TrueString
            End If
        End If
    End Sub

    Private Sub gridTarea_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridTarea.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = Boolean.TrueString
            txtid.Text = gridTarea.ActiveRow.Cells("ID_TAREA").Value
            Txttarea.Text = gridTarea.ActiveRow.Cells("DESC_TAREA").Value
        Catch ex As Exception

        End Try
    End Sub

End Class