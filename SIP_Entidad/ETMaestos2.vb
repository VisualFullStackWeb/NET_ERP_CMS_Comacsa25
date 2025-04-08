Public Class ETMaestos2
    Private _Usuario As String = String.Empty
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _CiaMaestro As String = String.Empty

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
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

    Public Property CiaMaestro() As String
        Get
            Return _CiaMaestro
        End Get
        Set(ByVal value As String)
            _CiaMaestro = value
        End Set
    End Property

End Class
