Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting
Public Class FrmConfigRuma
    Public Ls_Permisos As New List(Of Integer)
    Dim procesado As Int32
    Dim cierre As Int32 = 0
    Private Ls_RumaSuministro As List(Of ETRuma) = Nothing
    Private CodRuma As String = String.Empty
    Dim _objNegocio_ As NGProducto
    Dim _objEntidad_ As ETProducto
    Public Lista As List(Of ETRuma) = Nothing

    Private Sub FrmConfigRuma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargaData()
    End Sub
    Sub cargaData()
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        Dim dtData As New DataTable
        dtData = _objNegocio_.ListaConfigRuma(lblid.Text)
        gridRuma.DataSource = dtData
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        Try
            If MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
            gridRuma.PerformAction(ExitEditMode)
            Dim dtData As New DataTable
            For i As Int32 = 0 To gridRuma.Rows.Count - 1
                If gridRuma.Rows(i).Cells("SEL").Value = True Then
                    _objNegocio_ = New NGProducto
                    _objEntidad_ = New ETProducto
                    _objEntidad_.ID = lblid.Text
                    _objEntidad_.CODRUMA = gridRuma.Rows(i).Cells("COD_RUMA").Value
                    dtData = _objNegocio_.MantConfigRuma(_objEntidad_)
                End If

            Next
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class