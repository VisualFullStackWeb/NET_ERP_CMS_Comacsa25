Public Class ETListDetalleRequerimiento
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _UM As String = String.Empty
    Private _CantidadSolicitada As Decimal = 0
    Private _CantidadRequerida As Decimal = 0
    Private _Stock As Decimal = 0
    Private _Empleo As String = String.Empty
    Private _Observaciones As String = String.Empty
    Private _CodigoProveedor As String = String.Empty
    Private _RazonSocial As String = String.Empty
    Private _Item As String = String.Empty
    Private _CodigoEmpleo As String = String.Empty

    Private _Nro_Req As String = String.Empty
    Private _Nro_Req_Orig As String = String.Empty
    Private _Item_Req_Orig As String = String.Empty
    Private _Nro_OC As String = String.Empty
    Private _Item_OC As String = String.Empty
    Private _CantidadDist As Decimal = 0
    Private _Status As String = String.Empty
    Private _Usuario As String = String.Empty
    
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

    Public Property CantidadSolicitada() As Decimal
        Get
            Return _CantidadSolicitada
        End Get
        Set(ByVal value As Decimal)
            _CantidadSolicitada = value
        End Set
    End Property

    Public Property CantidadRequerida() As Decimal
        Get
            Return _CantidadRequerida
        End Get
        Set(ByVal value As Decimal)
            _CantidadRequerida = value
        End Set
    End Property

    Public Property Stock() As Decimal
        Get
            Return _Stock
        End Get
        Set(ByVal value As Decimal)
            _Stock = value
        End Set
    End Property

    Public Property Empleo() As String
        Get
            Return _Empleo
        End Get
        Set(ByVal value As String)
            _Empleo = value
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

    Public Property CodigoProveedor() As String
        Get
            Return _CodigoProveedor
        End Get
        Set(ByVal value As String)
            _CodigoProveedor = value
        End Set
    End Property

    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal value As String)
            _RazonSocial = value
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

    Public Property CodigoEmpleo() As String
        Get
            Return _CodigoEmpleo
        End Get
        Set(ByVal value As String)
            _CodigoEmpleo = value
        End Set
    End Property

    Public Property Nro_Req() As String
        Get
            Return _Nro_Req
        End Get
        Set(ByVal value As String)
            _Nro_Req = value
        End Set
    End Property

    Public Property Nro_Req_Orig() As String
        Get
            Return _Nro_Req_Orig
        End Get
        Set(ByVal value As String)
            _Nro_Req_Orig = value
        End Set
    End Property

    Public Property Item_Req_Orig() As String
        Get
            Return _Item_Req_Orig
        End Get
        Set(ByVal value As String)
            _Item_Req_Orig = value
        End Set
    End Property

    Public Property Nro_OC() As String
        Get
            Return _Nro_OC
        End Get
        Set(ByVal value As String)
            _Nro_OC = value
        End Set
    End Property

    Public Property Item_OC() As String
        Get
            Return _Item_OC
        End Get
        Set(ByVal value As String)
            _Item_OC = value
        End Set
    End Property

    Public Property CantidadDist() As Decimal
        Get
            Return _CantidadDist
        End Get
        Set(ByVal value As Decimal)
            _CantidadDist = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
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

End Class
