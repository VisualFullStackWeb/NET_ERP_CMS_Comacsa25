Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.FixedRowIndicator
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmCProveedorFiscalizar

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) _
                              Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If Not VerificarControl(5, Grid1) Then Return

        If e.Row.IsFilterRow Then Return

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

        '        e.Row.Fixed = Not e.Row.Fixed

    End Sub

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not VerificarControl(5, Grid1) Then Return

        If Grid1.Rows.FixedRows.Count = 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.No
            Me.Close()
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

End Class