Public Class ETListDetalleAtender
    Private _Codigo As String
    Private _Descripcion As String
    Private _UM As String
    Private _Stock As Double
    Private _StockMinimo As Double
    Private _CantidadSolicitada As Double
    Private _CantidadAtendida As Double
    Private _CantidadRequerida As Double
    Private _Observacion As String
    Private _CantidadAtendida2 As Double
    Private _OC As String

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


    Public Property Stock() As Double
        Get
            Return _Stock
        End Get
        Set(ByVal value As Double)
            _Stock = value
        End Set
    End Property

    Public Property StockMinimo() As Double
        Get
            Return _StockMinimo
        End Get
        Set(ByVal value As Double)
            _StockMinimo = value
        End Set
    End Property

    Public Property CantidadSolicitada() As Double
        Get
            Return _CantidadSolicitada
        End Get
        Set(ByVal value As Double)
            _CantidadSolicitada = value
        End Set
    End Property

    Public Property CantidadAtendida() As Double
        Get
            Return _CantidadAtendida
        End Get
        Set(ByVal value As Double)
            _CantidadAtendida = value
        End Set
    End Property

    Public Property CantidadRequerida() As Double
        Get
            Return _CantidadRequerida
        End Get
        Set(ByVal value As Double)
            _CantidadRequerida = value
        End Set
    End Property

    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
        End Set
    End Property

    Public Property CantidadAtendida2() As Double
        Get
            Return _CantidadAtendida2
        End Get
        Set(ByVal value As Double)
            _CantidadAtendida2 = value
        End Set
    End Property

    Public Property OC() As String
        Get
            Return _OC
        End Get
        Set(ByVal value As String)
            _OC = value
        End Set
    End Property

End Class
