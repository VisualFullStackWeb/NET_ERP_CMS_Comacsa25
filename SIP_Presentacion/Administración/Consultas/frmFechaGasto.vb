Public Class frmFechaGasto
    Public grabado As Int32 = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        grabado = 1
        Me.Close()
    End Sub
End Class