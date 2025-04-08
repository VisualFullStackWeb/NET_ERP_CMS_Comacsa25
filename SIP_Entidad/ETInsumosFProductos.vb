Public Class ETInsumosFProductos

    'Id_Prod Int NOT NULL,

    Private _Id_Prod As Integer
    Public Property Id_Prod() As Integer
        Get
            Return _Id_Prod
        End Get
        Set(ByVal value As Integer)
            _Id_Prod = value
        End Set
    End Property

    'Cod_Prod Char(8) NOT NULL,

    Private _Cod_Prod As String
    Public Property Cod_Prod() As String
        Get
            Return _Cod_Prod
        End Get
        Set(ByVal value As String)
            _Cod_Prod = value
        End Set
    End Property

    'User_Crea Char(10) NOT NULL,

    Private _User_Crea As String
    Public Property User_Crea() As String
        Get
            Return _User_Crea
        End Get
        Set(ByVal value As String)
            _User_Crea = value
        End Set
    End Property

    'Fecha_Crea Datetime NOT NULL Default Getdate(),

    Private _Fecha_Crea As DateTime
    Public Property Fecha_Crea() As DateTime
        Get
            Return _Fecha_Crea
        End Get
        Set(ByVal value As DateTime)
            _Fecha_Crea = value
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

    'Fecha_Modi datetime	

    Private _Fecha_Modi As DateTime
    Public Property Fecha_Modi() As DateTime
        Get
            Return _Fecha_Modi
        End Get
        Set(ByVal value As DateTime)
            _Fecha_Modi = value
        End Set
    End Property

    Private _DescripcionProd As String
    Public Property DescripcionProd() As String
        Get
            Return _DescripcionProd
        End Get
        Set(ByVal value As String)
            _DescripcionProd = value
        End Set
    End Property


End Class
