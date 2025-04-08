Public Class ETAnexo

#Region "Variables"
    Private _Cod_Cia As String
    Private _Nro_Req As String
    Private _Nro_Pedido As String
    Private _Sistema As String
    Private _Codigo_Producto As String
    Private _Item_Pedido As Integer
    Private _Item_Requerimiento As Integer
    Private _Cod_Area As String
    Private _User As String
    Private _Unid_Pedida As String
    Private _Unid_Compra As String
    Private _Cantidad As Decimal
    Private _Cantidad_Atendida As Decimal
    Private _Cantidad_Cancelada As Decimal
    Private _COD_PROV As String
    Private _NRO_OC As String
    Private _COD_LUGENT As String
    Private _status As String

#End Region

#Region " Propiedades"

    Public Property Cod_Prov() As String
        Get
            Return _COD_PROV
        End Get
        Set(ByVal value As String)
            _COD_PROV = value
        End Set
    End Property

    Public Property Nro_OC() As String
        Get
            Return _NRO_OC
        End Get
        Set(ByVal value As String)
            _NRO_OC = value
        End Set
    End Property

    Public Property Cod_LugEnt() As String
        Get
            Return _COD_LUGENT
        End Get
        Set(ByVal value As String)
            _COD_LUGENT = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property


    Public Property Cod_Cia() As String
        Get
            Return _Cod_Cia
        End Get
        Set(ByVal Value As String)
            _Cod_Cia = Value
        End Set
    End Property

    Public Property Nro_Req() As String
        Get
            Return _Nro_Req
        End Get
        Set(ByVal Value As String)
            _Nro_Req = Value
        End Set
    End Property

    Public Property Nro_Pedido() As String
        Get
            Return _Nro_Pedido
        End Get
        Set(ByVal Value As String)
            _Nro_Pedido = Value
        End Set
    End Property

    Public Property Sistema() As String
        Get
            Return _Sistema
        End Get
        Set(ByVal Value As String)
            _Sistema = Value
        End Set
    End Property

    Public Property Codigo_Producto() As String
        Get
            Return _Codigo_Producto
        End Get
        Set(ByVal Value As String)
            _Codigo_Producto = Value
        End Set
    End Property

    Public Property Item_Pedido() As Integer
        Get
            Return _Item_Pedido
        End Get
        Set(ByVal Value As Integer)
            _Item_Pedido = Value
        End Set
    End Property

    Public Property Item_Requerimiento() As Integer
        Get
            Return _Item_Requerimiento
        End Get
        Set(ByVal Value As Integer)
            _Item_Requerimiento = Value
        End Set
    End Property

    Public Property Cod_Area() As String
        Get
            Return _Cod_Area
        End Get
        Set(ByVal Value As String)
            _Cod_Area = Value
        End Set
    End Property


    Public Property User() As String
        Get
            Return _User
        End Get
        Set(ByVal Value As String)
            _User = Value
        End Set
    End Property

    Public Property Unid_Pedida() As String
        Get
            Return _Unid_Pedida
        End Get
        Set(ByVal Value As String)
            _Unid_Pedida = Value
        End Set
    End Property

    Public Property Unid_Compra() As String
        Get
            Return _Unid_Compra
        End Get
        Set(ByVal Value As String)
            _Unid_Compra = Value
        End Set
    End Property

    Public Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal Value As Decimal)
            _Cantidad = Value
        End Set
    End Property

    Public Property Cantidad_Atendida() As Decimal
        Get
            Return _Cantidad_Atendida
        End Get
        Set(ByVal Value As Decimal)
            _Cantidad_Atendida = Value
        End Set
    End Property

    Public Property Cantidad_Cancelada() As Decimal
        Get
            Return _Cantidad_Cancelada
        End Get
        Set(ByVal Value As Decimal)
            _Cantidad_Cancelada = Value
        End Set
    End Property

#End Region

End Class
