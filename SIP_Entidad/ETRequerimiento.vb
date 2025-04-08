
Public Class ETRequerimiento

    Inherits ETObjecto

    Private _NroReq As String = String.Empty
    Private _FechaLimite As DateTime = DateTime.MinValue
    Private _FechaEmision As DateTime = Date.Now
    Private _Observacion As String = String.Empty
    Private _Prioridad As String = String.Empty
    Private _ID As Int32 = 0

    Private _Aprobada As String
    Private _Area As String
    Private _Cant_Despa As Decimal
    Private _Cantidad As Decimal
    Private _Cantidad_Pedida As Decimal
    Private _Cod_Cia As String
    Private _Cod_DocTecnico As String
    Private _Cod_Prov As String
    Private _CodigoEmpleo As String
    Private _CodigoProducto As String = String.Empty
    Private _DocOri As String
    Private _Empleo As String
    Private _Fec_Aprob As DateTime = Date.Now


    Private _Fin As String
    Private _Inicio As String
    Private _Item As Integer = 0
    Private _Item_Pedido As Integer
    Private _Lugar_Ent As String
    Private _Marca As String
    Private _Memo As String
    Private _Mes As String
    Private _Nom_Prov As String
    Private _Nro_Int As String

    Private _NumDocOri As String
    Private _NumeroDocumento As String

    Private _Oc_Minas As Boolean
    Private _Sistema As String
    Private _Status As String
    Private _TipoProducto As String
    Private _Unidad As String
    Private _Unidad_Pedida As String

    Private _User_Crea As String
    Private _User_Recibe As String
    Private _Ano As String

    Private _Nro_Req_Origen As String



    Public Property FechaLimite() As DateTime
        Get
            Return _FechaLimite
        End Get
        Set(ByVal value As DateTime)
            _FechaLimite = value
        End Set
    End Property

    Public Property FechaEmision() As DateTime
        Get
            Return _FechaEmision
        End Get
        Set(ByVal value As DateTime)
            _FechaEmision = value
        End Set
    End Property


    Public Property Prioridad() As String
        Get
            Return _Prioridad
        End Get
        Set(ByVal value As String)
            _Prioridad = value
        End Set
    End Property

    Public Overloads Property ID() As Int32
        Get
            Return _ID
        End Get
        Set(ByVal value As Int32)
            _ID = value
        End Set
    End Property

    Public Overloads Property NroReq() As String
        Get
            Return _NroReq
        End Get
        Set(ByVal value As String)
            _NroReq = value
        End Set
    End Property

    Public Property Cod_DocTecnico() As String
        Get
            Return _Cod_DocTecnico
        End Get
        Set(ByVal value As String)
            _Cod_DocTecnico = value
        End Set
    End Property

    Public Property Cod_Prov() As String
        Get
            Return _Cod_Prov
        End Get
        Set(ByVal value As String)
            _Cod_Prov = value
        End Set
    End Property

    Public Property Ano() As String
        Get
            Return _Ano
        End Get
        Set(ByVal value As String)
            _Ano = value
        End Set
    End Property

    Public Property Aprobada() As String
        Get
            Return _Aprobada
        End Get
        Set(ByVal value As String)
            _Aprobada = value
        End Set
    End Property

    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property

    Public Property Cant_Despa() As Decimal
        Get
            Return _Cant_Despa
        End Get
        Set(ByVal value As Decimal)
            _Cant_Despa = value
        End Set
    End Property

    Public Overloads Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

    Public Property Cantidad_Pedida() As Decimal
        Get
            Return _Cantidad_Pedida
        End Get
        Set(ByVal value As Decimal)
            _Cantidad_Pedida = value
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


    Public Property CodigoEmpleo() As String
        Get
            Return _CodigoEmpleo
        End Get
        Set(ByVal value As String)
            _CodigoEmpleo = value
        End Set
    End Property

    Public Property CodigoProducto() As String
        Get
            Return _CodigoProducto
        End Get
        Set(ByVal value As String)
            _CodigoProducto = value
        End Set
    End Property

    Public Property DocOri() As String
        Get
            Return _DocOri
        End Get
        Set(ByVal value As String)
            _DocOri = value
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

    Public Property Fec_Aprob() As DateTime
        Get
            Return _Fec_Aprob
        End Get
        Set(ByVal value As DateTime)
            _Fec_Aprob = value
        End Set
    End Property

    Public Property Fin() As String
        Get
            Return _Fin
        End Get
        Set(ByVal value As String)
            _Fin = value
        End Set
    End Property

    Public Property Inicio() As String
        Get
            Return _Inicio
        End Get
        Set(ByVal value As String)
            _Inicio = value
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

    Public Property Item_Pedido() As Integer
        Get
            Return _Item_Pedido
        End Get
        Set(ByVal value As Integer)
            _Item_Pedido = value
        End Set
    End Property

    Public Property Lugar_Ent() As String
        Get
            Return _Lugar_Ent
        End Get
        Set(ByVal value As String)
            _Lugar_Ent = value
        End Set
    End Property

    Public Property Marca() As String
        Get
            Return _Marca
        End Get
        Set(ByVal value As String)
            _Marca = value
        End Set
    End Property

    Public Property Memo() As String
        Get
            Return _Memo
        End Get
        Set(ByVal value As String)
            _Memo = value
        End Set
    End Property

    Public Overloads Property Mes() As String
        Get
            Return _Mes
        End Get
        Set(ByVal value As String)
            _Mes = value
        End Set
    End Property

    Public Property Nom_Prov() As String
        Get
            Return _Nom_Prov
        End Get
        Set(ByVal value As String)
            _Nom_Prov = value
        End Set
    End Property

    Public Property Nro_Int() As String
        Get
            Return _Nro_Int
        End Get
        Set(ByVal value As String)
            _Nro_Int = value
        End Set
    End Property

    Public Property NumDocOri() As String
        Get
            Return _NumDocOri
        End Get
        Set(ByVal value As String)
            _NumDocOri = value
        End Set
    End Property

    Public Property NumeroDocumento() As String
        Get
            Return _NumeroDocumento
        End Get
        Set(ByVal value As String)
            _NumeroDocumento = value
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

    Public Property Oc_Minas() As Boolean
        Get
            Return _Oc_Minas
        End Get
        Set(ByVal value As Boolean)
            _Oc_Minas = value
        End Set
    End Property

    Public Overloads Property Sistema() As String
        Get
            Return _Sistema
        End Get
        Set(ByVal value As String)
            _Sistema = value
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

    Public Property TipoProducto() As String
        Get
            Return _TipoProducto
        End Get
        Set(ByVal value As String)
            _TipoProducto = value
        End Set
    End Property

    Public Overloads Property Unidad() As String
        Get
            Return _Unidad
        End Get
        Set(ByVal value As String)
            _Unidad = value
        End Set
    End Property

    Public Property Unidad_Pedida() As String
        Get
            Return _Unidad_Pedida
        End Get
        Set(ByVal value As String)
            _Unidad_Pedida = value
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

    Public Property User_Recibe() As String
        Get
            Return _User_Recibe
        End Get
        Set(ByVal value As String)
            _User_Recibe = value
        End Set
    End Property

    Public Property Nro_Req_Origen() As String
        Get
            Return _Nro_Req_Origen
        End Get
        Set(ByVal value As String)
            _Nro_Req_Origen = value
        End Set
    End Property
End Class
