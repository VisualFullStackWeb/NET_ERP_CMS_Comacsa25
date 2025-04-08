Public Class frmverBillete
    Public dtBillete As New DataTable
    Private Sub frmverBillete_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarUltraGridxBinding(gridBillete, Source1, dtBillete)
    End Sub

    Private Sub gridBillete_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridBillete.DoubleClickRow
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
End Class