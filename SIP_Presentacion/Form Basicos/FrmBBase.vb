Imports System
Public Class FrmBBase


    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) _
                    Handles MyBase.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Opacity = 0.4
        Size = Screen.PrimaryScreen.Bounds.Size

    End Sub
End Class