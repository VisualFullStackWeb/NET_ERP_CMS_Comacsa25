Public Class frmTrabajadorInputCodigos
    Public listaCodigoTrabajadores As String = ""
    Private Function getCodigos() As String
        Dim value As String = ""

        Dim lineas As String() = txtLista.Lines()

        For Each fila As String In lineas

            If fila.Trim.Length < 5 Then
                Continue For
            End If

            If value.Trim.Length < 1 Then
                value = Trim(fila.Substring(0, 5))
            Else
                value = value & "," & Trim(fila.Substring(0, 5))
            End If

        Next

        Return value
    End Function
    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAceptar.Click

        If Me.Text.Trim.Length < 5 Then
            MessageBox.Show("Ingrese la lista de codigos del trabajador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        listaCodigoTrabajadores = getCodigos()
        Me.DialogResult = DialogResult.OK

    End Sub
End Class