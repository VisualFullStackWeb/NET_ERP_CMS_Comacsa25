Public Class Auditoria
    Private _loginUsuario As String = ""
    Public Property loginUsuario() As String
        Get
            Return _loginUsuario
        End Get
        Set(ByVal value As String)
            _loginUsuario = value
        End Set
    End Property

End Class
