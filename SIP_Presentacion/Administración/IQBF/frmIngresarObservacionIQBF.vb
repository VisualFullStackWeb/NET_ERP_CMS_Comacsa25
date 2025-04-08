Public Class frmIngresarObservacionIQBF
    Public guardado As Boolean = False
    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        guardado = True
        Me.Close()
    End Sub

    Private Sub frmIngresarObservacionIQBF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Txtobservacion.Focus()
    End Sub
End Class