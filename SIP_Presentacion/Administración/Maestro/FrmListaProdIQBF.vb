Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmListaProdIQBF
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
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Dim dtDatos As New DataTable
        dtDatos = Negocio.NEntregas.ListaPrudctoIQBF
        Call CargarUltraGridxBinding(Me.gridMotivos, Source1, dtDatos)
    End Sub

    Private Sub FrmListaProdIQBF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarDatos()
    End Sub

    Private Sub gridMotivos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridMotivos.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridMotivos Then Return
        If e.Row.IsFilterRow Then Return
        Me.Close()
    End Sub
End Class