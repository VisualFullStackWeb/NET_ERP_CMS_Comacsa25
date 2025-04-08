Public Class ETOrdenCompra
    Private _Aprobada As String
    Private _Cant_Desp As Decimal
    Private _Cant_Fact As Decimal
    Private _Cod_Cia As String
    Private _Cod_Prod As String
    Private _Fec_Crea As DateTime
    Private _Fec_Entrega As DateTime
    Private _Item As Integer
    Private _Nro_OC As String
    Private _TipoProducto As String
    Private _User_Crea As String

    Public Property Aprobada() As String
        Get
            Return _Aprobada
        End Get
        Set(ByVal value As String)
            _Aprobada = value
        End Set
    End Property

    Public Property Cant_Desp() As Decimal
        Get
            Return _Cant_Desp
        End Get
        Set(ByVal value As Decimal)
            _Cant_Desp = value
        End Set
    End Property

    Public Property Cant_Fact() As Decimal
        Get
            Return _Cant_fact
        End Get
        Set(ByVal value As Decimal)
            _Cant_Fact = value
        End Set
    End Property

    Public Property Cod_Cia() As String
        Get
            Return _Cod_Cia
        End Get
        Set(ByVal value As String)
            _Cod_Cia = value
        End Set
    End Property

    Public Property Cod_Prod() As String
        Get
            Return _Cod_Prod
        End Get
        Set(ByVal value As String)
            _Cod_Prod = value
        End Set
    End Property

    Public Property Fec_Crea() As DateTime
        Get
            Return _Fec_Crea
        End Get
        Set(ByVal value As DateTime)
            _Fec_Crea = value
        End Set
    End Property

    Public Property Fec_Entrega() As DateTime
        Get
            Return _Fec_Entrega
        End Get
        Set(ByVal value As DateTime)
            _Fec_Entrega = value
        End Set
    End Property

    Public Property Item() As Integer
        Get
            Return _Item
        End Get
        Set(ByVal value As Integer)
            _Item = value
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

    Public Property TipoProducto() As String
        Get
            Return _TipoProducto
        End Get
        Set(ByVal value As String)
            _TipoProducto = value
        End Set
    End Property

    Public Property User_Crea() As String
        Get
            Return _User_Crea
        End Get
        Set(ByVal value As String)
            _User_Crea = value
        End Set
    End Property

End Class
