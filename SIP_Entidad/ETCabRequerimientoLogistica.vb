Public Class ETCabRequerimientoLogistica
#Region " Variables"
    Private _Nro_Requi As String
    Private _Cod_Cia As String
    Private _Fec_CREA As datetime
    Private _Lugar_Ent As String
    Private _Fec_Ent As datetime
    Private _Area As String
    Private _STATUS As String
    Private _Aprobada As String
    Private _Fec_Aprob As datetime
    Private _Nro_Int As String
    Private _Observacion As String
    Private _USER_CREA As String
    Private _USER_MODI As String
    Private _fec_modi As datetime
    Private _urgente As String
    Private _oc_minas As Boolean
#End Region
#Region " Propiedades"
    Public Property Nro_Requi() As String        Get            Return _Nro_Requi        End Get        Set(ByVal Value As String)            _Nro_Requi = Value        End Set    End Property
    Public Property Cod_Cia() As String        Get            Return _Cod_Cia        End Get        Set(ByVal Value As String)            _Cod_Cia = Value        End Set    End Property
    Public Property Fec_CREA() As datetime        Get            Return _Fec_CREA        End Get        Set(ByVal Value As datetime)            _Fec_CREA = Value        End Set    End Property
    Public Property Lugar_Ent() As String        Get            Return _Lugar_Ent        End Get        Set(ByVal Value As String)            _Lugar_Ent = Value        End Set    End Property
    Public Property Fec_Ent() As datetime        Get            Return _Fec_Ent        End Get        Set(ByVal Value As datetime)            _Fec_Ent = Value        End Set    End Property
    Public Property Area() As String        Get            Return _Area        End Get        Set(ByVal Value As String)            _Area = Value        End Set    End Property
    Public Property STATUS() As String        Get            Return _STATUS        End Get        Set(ByVal Value As String)            _STATUS = Value        End Set    End Property
    Public Property Aprobada() As String        Get            Return _Aprobada        End Get        Set(ByVal Value As String)            _Aprobada = Value        End Set    End Property
    Public Property Fec_Aprob() As datetime        Get            Return _Fec_Aprob        End Get        Set(ByVal Value As datetime)            _Fec_Aprob = Value        End Set    End Property
    Public Property Nro_Int() As String        Get            Return _Nro_Int        End Get        Set(ByVal Value As String)            _Nro_Int = Value        End Set    End Property
    Public Property Observacion() As String        Get            Return _Observacion        End Get        Set(ByVal Value As String)            _Observacion = Value        End Set    End Property
    Public Property USER_CREA() As String        Get            Return _USER_CREA        End Get        Set(ByVal Value As String)            _USER_CREA = Value        End Set    End Property
    Public Property USER_MODI() As String        Get            Return _USER_MODI        End Get        Set(ByVal Value As String)            _USER_MODI = Value        End Set    End Property
    Public Property fec_modi() As datetime        Get            Return _fec_modi        End Get        Set(ByVal Value As datetime)            _fec_modi = Value        End Set    End Property
    Public Property urgente() As String        Get            Return _urgente        End Get        Set(ByVal Value As String)            _urgente = Value        End Set    End Property
    Public Property oc_minas() As Boolean        Get            Return _oc_minas        End Get        Set(ByVal Value As Boolean)            _oc_minas = Value        End Set    End Property
#End Region

End Class
