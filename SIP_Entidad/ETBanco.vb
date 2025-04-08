Public Class ETBanco

    Private _Cod_Cia As String
    Private _Codigo As String
    Private _Descripcion As String
    Private _Login As String
    Private _Descrip As String

    Public Property Cod_Cia() As String
        Get
            Return _Cod_Cia
        End Get
        Set(ByVal value As String)
            _Cod_Cia = value
        End Set
    End Property


    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property


    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property


    Public Property Login() As String
        Get
            Return _Login
        End Get
        Set(ByVal value As String)
            _Login = value
        End Set
    End Property

    Public Property Descrip() As String
        Get
            Return _Descrip
        End Get
        Set(ByVal value As String)
            _Descrip = value
        End Set
    End Property

End Class
