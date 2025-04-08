Public Class ETListDocumentosTecnicos
    Private _Codigo As String
    Private _Descripcion As String
    Private _Seleccionar As Boolean

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

    Public Property Seleccionar() As Boolean
        Get
            Return _Seleccionar
        End Get
        Set(ByVal value As Boolean)
            _Seleccionar = value
        End Set
    End Property

End Class
