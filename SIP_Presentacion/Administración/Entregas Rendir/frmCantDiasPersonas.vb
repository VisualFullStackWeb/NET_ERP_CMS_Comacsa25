
Public Class frmCantDiasPersonas
    Public boton As String = String.Empty
    Public comentario As String = String.Empty
    Private Sub frmCantDiasPersonas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If txtdias.Text = 0 Then txtdias.Text = 1
        If txtpersonas.Text = 0 Then txtpersonas.Text = 1
        txtdias.Focus()
        'btnguardar.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        If txtdias.Text.Trim = "" Then txtdias.Text = 0
        If txtpersonas.Text.Trim = "" Then txtpersonas.Text = 0
        If txtdias.Text <= 0 Then
            MsgBox("Ingrese nro. de días válido", MsgBoxStyle.Exclamation, msgComacsa) : txtdias.Focus() : Exit Sub
        End If
        If txtpersonas.Text <= 0 Then
            MsgBox("Ingrese nro. de días válido", MsgBoxStyle.Exclamation, msgComacsa) : txtpersonas.Focus() : Exit Sub
        End If

        boton = "OK"
        comentario = txtdias.Text & IIf(txtdias.Text > 1, " Dias, ", " Dia, ") & txtpersonas.Text & IIf(txtpersonas.Text > 1, " Personas", " Persona")
        Me.Close()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        boton = "CANCEL"
        comentario = ""
        Me.Close()
    End Sub

    Private Sub txtdias_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdias.KeyPress, txtpersonas.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtdias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdias.KeyDown
        If (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then
            txtpersonas.Focus()
        End If
    End Sub

    Private Sub txtpersonas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpersonas.KeyDown
        If (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then
            btnguardar.Focus()
        End If
    End Sub
End Class