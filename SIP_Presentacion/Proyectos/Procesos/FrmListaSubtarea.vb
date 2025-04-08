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
Public Class FrmListaSubtarea
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
    Public subtarea As String = ""
    Public idsubtarea As Int32 = 0
    Public numero As String = ""
    Public idtarea As Int32
    Public ejecucion As Int32
    Private Sub FrmListaSubtarea_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.idtarea = idtarea
        obj_EProyecto.ejecucion = ejecucion
        Dim dtDatos As New DataTable
        dtDatos = obj_Proyecto.Lista_Subtarea(obj_EProyecto)
        gridTarea.DataSource = dtDatos
    End Sub

    Private Sub gridTarea_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridTarea.DoubleClickRow
        Try
            idsubtarea = gridTarea.ActiveRow.Cells("ID_SUBTAREA").Value
            subtarea = gridTarea.ActiveRow.Cells("SUBTAREA").Value
            numero = gridTarea.ActiveRow.Cells("NUMERO").Value
            FrmPlanificacion.dtfechasubtarea.Value = Date.Now
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridTarea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridTarea.InitializeLayout

    End Sub
End Class