Public Class ETLst_EnvioCantera
    Private _Codigo As String
    Private _Descripcion As String
    Private _UM As String
    Private _Stock As String
    Private _Cantidad As String
    Private _TipoProducto As String
    Private _OrdenCompra As String
    Private _NroBillete As String

    Public Property NroBillete() As String
        Get
            Return _NroBillete
        End Get
        Set(ByVal value As String)
            _NroBillete = value
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

    Public Property UM() As String
        Get
            Return _UM
        End Get
        Set(ByVal value As String)
            _UM = value
        End Set
    End Property

    Public Property Stock() As String
        Get
            Return _Stock
        End Get
        Set(ByVal value As String)
            _Stock = value
        End Set
    End Property

    Public Property Cantidad() As String
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As String)
            _Cantidad = value
        End Set
    End Property
    Public Property TipoProducto() As String
        Get
            Return _TipoProducto
        End Get
        Set(ByVal value As String)
            _TipoProducto = value
        End Set
    End Property

    Public Property OrdenCompra() As String
        Get
            Return _TipoProducto
        End Get
        Set(ByVal value As String)
            _TipoProducto = value
        End Set
    End Property

End Class
