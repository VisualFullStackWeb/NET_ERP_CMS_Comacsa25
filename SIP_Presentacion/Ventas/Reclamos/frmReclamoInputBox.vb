Public Class frmReclamoInputBox
    Public Titulo As String = String.Empty
    Public Comentario As String = String.Empty


    Private Sub frmReclamoInputBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(Titulo) Then
            Me.Text = Titulo
        End If
        If Not String.IsNullOrEmpty(Comentario) Then
            Me.txtComentario.Text = Comentario
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Me.Comentario = txtComentario.Text
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub
End Class