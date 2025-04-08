Public Class ETLstUsersFirma
    Private _Login As String
    Private _Usuario As String
    Private _Item As String
    Private _Firma As Boolean

    Public Property Login() As String
        Get
            Return _Login
        End Get
        Set(ByVal value As String)
            _Login = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Item() As String
        Get
            Return _Item
        End Get
        Set(ByVal value As String)
            _Item = value
        End Set
    End Property

    Public Property Firma() As Boolean
        Get
            Return _Firma
        End Get
        Set(ByVal value As Boolean)
            _Firma = value
        End Set
    End Property


End Class
