Public Class ETListDetRequisicionAlmacen
    Private _Empleo As String
    Private _Codigo As String
    Private _Descripcion As String
    Private _UM As String
    Private _Cantidad As Decimal
    Private _Activo As String
    Private _Cantera As String
    Private _Tecnicas As String
    Private _Imagenes As String
    Private _CodigoEmpleo As String
    Private _CodigoActivo As String
    Private _CodigoCantera As String
    Private _Aplicacion As String
    Private _CodigoAplicacion As String
    Private _Observaciones As String
    Private _UMCompra As String

    Public Property UMCompra() As String
        Get
            Return _UMCompra
        End Get
        Set(ByVal value As String)
            _UMCompra = value
        End Set
    End Property

    Public Property Observaciones() As String
        Get
            Return _Observaciones
        End Get
        Set(ByVal value As String)
            _Observaciones = value
        End Set
    End Property

    Public Property Empleo() As String
        Get
            Return _Empleo
        End Get
        Set(ByVal Value As String)
            _Empleo = Value
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

    Public Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

    Public Property Activo() As String
        Get
            Return _Activo
        End Get
        Set(ByVal value As String)
            _Activo = value
        End Set
    End Property

    Public Property Cantera() As String
        Get
            Return _Cantera
        End Get
        Set(ByVal value As String)
            _Cantera = value
        End Set
    End Property

    Public Property Tecnicas() As String
        Get
            Return _Tecnicas
        End Get
        Set(ByVal value As String)
            _Tecnicas = value
        End Set
    End Property

    Public Property Imagenes() As String
        Get
            Return _Imagenes
        End Get
        Set(ByVal value As String)
            _Imagenes = value
        End Set
    End Property

    Public Property CodigoEmpleo() As String
        Get
            Return _CodigoEmpleo
        End Get
        Set(ByVal value As String)
            _CodigoEmpleo = value
        End Set
    End Property

    Public Property CodigoActivo() As String
        Get
            Return _CodigoActivo
        End Get
        Set(ByVal value As String)
            _CodigoActivo = value
        End Set
    End Property

    Public Property CodigoCantera() As String
        Get
            Return _CodigoCantera
        End Get
        Set(ByVal value As String)
            _CodigoCantera = value
        End Set
    End Property

    Public Property Aplicacion() As String
        Get
            Return _Aplicacion
        End Get
        Set(ByVal value As String)
            _Aplicacion = value
        End Set
    End Property

    Public Property CodigoAplicacion() As String
        Get
            Return _CodigoAplicacion
        End Get
        Set(ByVal value As String)
            _CodigoAplicacion = value
        End Set
    End Property

End Class
