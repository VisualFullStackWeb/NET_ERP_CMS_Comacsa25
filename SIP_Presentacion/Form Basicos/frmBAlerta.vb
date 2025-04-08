Public Class frmBAlerta
    Private _Mensaje As String = String.Empty
    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property
    Private Sub frmBAlerta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblMensaje.Text = Mensaje
    End Sub
End Class