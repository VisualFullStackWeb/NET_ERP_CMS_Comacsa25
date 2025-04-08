Public Class ETInsumosFiscalizados

    'Id_Prod Int not null identity(1,1),

    Private _Id_Prod As Integer
    Public Property Id_Prod() As Integer
        Get
            Return _Id_Prod
        End Get
        Set(ByVal value As Integer)
            _Id_Prod = value
        End Set
    End Property

    'Cod_Cia Char(2) Not Null,

    Private _Cod_Cia As String
    Public Property Cod_Cia() As String
        Get
            Return _Cod_Cia
        End Get
        Set(ByVal value As String)
            _Cod_Cia = value
        End Set
    End Property

    'Cod_Sunat Char(2) not null,

    Private _Cod_Sunat As String
    Public Property Cod_Sunat() As String
        Get
            Return _Cod_Sunat
        End Get
        Set(ByVal value As String)
            _Cod_Sunat = value
        End Set
    End Property

    Private _Cod_Producto As String
    Public Property Cod_Producto() As String
        Get
            Return _Cod_Producto
        End Get
        Set(ByVal value As String)
            _Cod_Producto = value
        End Set
    End Property

    'Des_Sunat VarChar(100) Not Null,

    Private _Des_Sunat As String
    Public Property Des_Sunat() As String
        Get
            Return _Des_Sunat
        End Get
        Set(ByVal value As String)
            _Des_Sunat = value
        End Set
    End Property

    'Presentacion CHAR(6) NOT NULL,

    Private _Presentacion As String
    Public Property Presentacion() As String
        Get
            Return _Presentacion
        End Get
        Set(ByVal value As String)
            _Presentacion = value
        End Set
    End Property

    'UnidadPre CHAR(6)NOT NULL,

    Private _UnidadPre As String
    Public Property UnidadPre() As String
        Get
            Return _UnidadPre
        End Get
        Set(ByVal value As String)
            _UnidadPre = value
        End Set
    End Property

    'CantidadUniPre NUMERIC(10,2) NOT NULL ,

    Private _CantidadUniPre As Double
    Public Property CantidadUniPre() As Double
        Get
            Return _CantidadUniPre
        End Get
        Set(ByVal value As Double)
            _CantidadUniPre = value
        End Set
    End Property

    Private _PesoBruto As Double
    Public Property PesoBruto() As Double
        Get
            Return _PesoBruto
        End Get
        Set(ByVal value As Double)
            _PesoBruto = value
        End Set
    End Property

    'Status Char(1) Not Null Default '',

    Private _Status As String
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

    'User_Crea Char(10) Not Null Default '',

    Private _User_Crea As String
    Public Property User_Crea() As String
        Get
            Return _User_Crea
        End Get
        Set(ByVal value As String)
            _User_Crea = value
        End Set
    End Property

    'Fecha_Crea Datetime Not Null Default Getdate(),

    Private _Fecha_Crea As DateTime
    Public Property Fecha_Crea() As DateTime
        Get
            Return _Fecha_Crea
        End Get
        Set(ByVal value As DateTime)
            _Fecha_Crea = value
        End Set
    End Property

    'User_Modi Char(10) ,

    Private _User_Modi As String
    Public Property User_Modi() As String
        Get
            Return _User_Modi
        End Get
        Set(ByVal value As String)
            _User_Modi = value
        End Set
    End Property

    'Fecha_Modi Char(10)

    Private _Fecha_Modi As DateTime
    Public Property Fecha_Modi() As DateTime
        Get
            Return _Fecha_Modi
        End Get
        Set(ByVal value As DateTime)
            _Fecha_Modi = value
        End Set
    End Property

    Dim _cantidad As Double
    Public Property cantidad() As Double
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Double)
            _cantidad = value
        End Set
    End Property
    Dim _numasociado As String
    Public Property numasociado() As String
        Get
            Return _numasociado
        End Get
        Set(ByVal value As String)
            _numasociado = value
        End Set
    End Property

    Dim _guiacliente As String
    Public Property guiacliente() As String
        Get
            Return _guiacliente
        End Get
        Set(ByVal value As String)
            _guiacliente = value
        End Set
    End Property

    Dim _numguia As String
    Public Property numguia() As String
        Get
            Return _numguia
        End Get
        Set(ByVal value As String)
            _numguia = value
        End Set
    End Property
    Dim _rucproveedor As String
    Public Property rucproveedor() As String
        Get
            Return _rucproveedor
        End Get
        Set(ByVal value As String)
            _rucproveedor = value
        End Set
    End Property
    Dim _ructransportista As String
    Public Property ructransportista() As String
        Get
            Return _ructransportista
        End Get
        Set(ByVal value As String)
            _ructransportista = value
        End Set
    End Property
    Dim _placa As String
    Public Property placa() As String
        Get
            Return _placa
        End Get
        Set(ByVal value As String)
            _placa = value
        End Set
    End Property
    Dim _brevete As String
    Public Property brevete() As String
        Get
            Return _brevete
        End Get
        Set(ByVal value As String)
            _brevete = value
        End Set
    End Property
    Dim _tdremitente As String
    Public Property tdremitente() As String
        Get
            Return _tdremitente
        End Get
        Set(ByVal value As String)
            _tdremitente = value
        End Set
    End Property

    Dim _tdcliente As String
    Public Property tdcliente() As String
        Get
            Return _tdcliente
        End Get
        Set(ByVal value As String)
            _tdcliente = value
        End Set
    End Property

    Dim _tdtransportista As String
    Public Property tdtransportista() As String
        Get
            Return _tdtransportista
        End Get
        Set(ByVal value As String)
            _tdtransportista = value
        End Set
    End Property

    Dim _ayo As Int32
    Public Property ayo() As Int32
        Get
            Return _ayo
        End Get
        Set(ByVal value As Int32)
            _ayo = value
        End Set
    End Property

    Dim _mes As Int32
    Public Property mes() As Int32
        Get
            Return _mes
        End Get
        Set(ByVal value As Int32)
            _mes = value
        End Set
    End Property

    Dim _estado As Int32
    Public Property estado() As Int32
        Get
            Return _estado
        End Get
        Set(ByVal value As Int32)
            _estado = value
        End Set
    End Property

    Dim _observacion As String
    Public Property observacion() As String
        Get
            Return _observacion
        End Get
        Set(ByVal value As String)
            _observacion = value
        End Set
    End Property

    Dim _numsunat As String
    Public Property numsunat() As String
        Get
            Return _numsunat
        End Get
        Set(ByVal value As String)
            _numsunat = value
        End Set
    End Property
End Class
