Public Class ETAprobacionFirmaMonto
    Private _CodigoAprobacion As Integer
    Private _Usuario As String
    Private _Firma As Boolean
    Private _Cod_Cia As String
    Private _Moneda As String
    Private _TotalDesde As Decimal
    Private _Signo As String
    Private _TotalHasta As Decimal
    Private _Status As String
    Private _Nro_OC As String
    Private _User_Crea As String

    Public Property CodigoAprobacion() As Integer
        Get
            Return _CodigoAprobacion
        End Get
        Set(ByVal value As Integer)
            _CodigoAprobacion = value
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

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Firma() As Boolean
        Get
            Return _Firma
        End Get
        Set(ByVal value As Boolean)
            _Firma = value
        End Set
    End Property

    Public Property Moneda() As String
        Get
            Return _Moneda
        End Get
        Set(ByVal value As String)
            _Moneda = value
        End Set
    End Property


    Public Property TotalDesde() As Decimal
        Get
            Return _TotalDesde
        End Get
        Set(ByVal value As Decimal)
            _TotalDesde = value
        End Set
    End Property

    Public Property Signo() As String
        Get
            Return _Signo
        End Get
        Set(ByVal value As String)
            _Signo = value
        End Set
    End Property

    Public Property TotalHasta() As Decimal
        Get
            Return _TotalHasta
        End Get
        Set(ByVal value As Decimal)
            _TotalHasta = value
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

    Public Property Nro_OC() As String
        Get
            Return _Nro_OC
        End Get
        Set(ByVal value As String)
            _Nro_OC = value
        End Set
    End Property

    Public Property User_crea() As String
        Get
            Return _User_Crea
        End Get
        Set(ByVal value As String)
            _User_Crea = value
        End Set
    End Property

End Class
