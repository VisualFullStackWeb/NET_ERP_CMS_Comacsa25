Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop
Public Class frmdetalleObligaciones
    Public dtPlanilla As New DataTable
    Public concepto As String
    Private Sub frmdetalleObligaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarUltraGridxBinding(gridPlanilla, Source1, dtPlanilla)
        gridPlanilla.DisplayLayout.Bands(0).Columns("TOTAL").Header.Caption = concepto
        If concepto = "GRATIFICACION" Or concepto = "CTS" Then
            gridPlanilla.DisplayLayout.Bands(0).Columns("TOTALPAGO").Hidden = True
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
End Class