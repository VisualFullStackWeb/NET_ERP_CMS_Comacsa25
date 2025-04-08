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
Public Class FrmConsultaOrden
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
    Private Sub FrmConsultaOrden_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFecha.Value = "01/01/2021"
        dtFecha2.Value = Now.Date
        cargaData()
    End Sub
    Sub cargaData()
        Dim dtPlanificacion As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.fechaini = dtFecha.Value
        obj_EProyecto.FechaTerminacion = dtFecha2.Value
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_PlanificacionOrden(obj_EProyecto)
        dtPlanificacion = dsData.Tables(0)
        gridProyecto.DataSource = dtPlanificacion
    End Sub
    Sub procesar()
        cargaData()
    End Sub
End Class