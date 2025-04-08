Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop
Public Class frmnoExistente
    Public dtPlanilla As New DataTable

    Private Sub frmnoExistente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarUltraGridxBinding(gridTrabajador, Source1, dtPlanilla)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
End Class