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
Public Class FrmPersonalExterno
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
    Public placod As String = ""
    Public trabajador As String = ""
    Public soles_hora As Double = 0

    Private Sub FrmPersonalExterno_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        Dim dtDatos As New DataTable
        dtDatos = obj_Proyecto.Lista_PersonalExt(obj_EProyecto)
        gridTarea.DataSource = dtDatos
        txttrabajador.Focus()
    End Sub

    Private Sub gridTarea_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridTarea.DoubleClickRow
        Try
            placod = gridTarea.ActiveRow.Cells("PLACOD").Value
            trabajador = gridTarea.ActiveRow.Cells("PERSONAL").Value
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttrabajador.KeyDown
        If e.KeyCode = 13 Then
            If MsgBox("Seguro registrar el personal?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            Dim dtDatos As New DataSet
            obj_EProyecto.personal = txttrabajador.Text
            dtDatos = obj_Proyecto.Lista_PersonalExtMant(obj_EProyecto)
            Dim table1 As New DataTable
            Dim table2 As New DataTable
            table1 = dtDatos.Tables(0)
            table2 = dtDatos.Tables(1)
            If table1.Rows(0)(0) = "OK" Then
                placod = table2.Rows(0)("PLACOD")
                trabajador = table2.Rows(0)("PERSONAL")
                Me.Close()
            End If
        End If
    End Sub

End Class