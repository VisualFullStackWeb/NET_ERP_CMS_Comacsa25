Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmBuscarMquina
#Region "Variables"
    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private ListModulos As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Dim Ope = 1
#End Region
    Public Sub CargarDatos()
        Try
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.ListarMaquina()
            Call CargarUltraGridxBinding(gridMaquina, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmBuscarMquina_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub

    Private Sub gridMaquina_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridMaquina.DoubleClickRow
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class