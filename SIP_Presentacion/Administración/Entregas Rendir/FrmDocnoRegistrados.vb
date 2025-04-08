Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmDocnoRegistrados

    Private Sub gridConceptos_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "nroruc" OrElse uColumn.Key = "Razon" OrElse uColumn.Key = "TipoDoc" OrElse uColumn.Key = "NumDoc") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub FrmDocnoRegistrados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Ls_DocnoRegistrado.Count > 0 Then
            Call CargarUltraGrid(gridConceptos, Ls_DocnoRegistrado)
        End If
    End Sub
End Class