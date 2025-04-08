Public Class ETResultado

    Private _Realizo As Boolean = False
    Private _Valida As Boolean = False
    Private _Mensaje As String = ""
    Private _CodAgrupacion As String = ""
    Private _valor = 0
    Private _Rec1 As Int16 = 0
    Private _Rec2 As Int16 = 0
    Private _RIni As Date = Date.Today
    Private _RFin As Date = Date.Today

    Property Realizo() As Boolean
        Get
            Return _Realizo
        End Get
        Set(ByVal Value As Boolean)
            _Realizo = Value
        End Set
    End Property

    Property Valida() As Boolean
        Get
            Return _Valida
        End Get
        Set(ByVal Value As Boolean)
            _Valida = Value
        End Set
    End Property

    Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal Value As String)
            _Mensaje = Value
        End Set
    End Property

    Property CodAgrupacion() As String
        Get
            Return _CodAgrupacion
        End Get
        Set(ByVal Value As String)
            _CodAgrupacion = Value
        End Set
    End Property

    Property Valor() As Integer
        Get
            Return _valor
        End Get
        Set(ByVal value As Integer)
            _valor = value
        End Set
    End Property

    Public Property Rec1() As Int16
        Get
            Return _Rec1
        End Get
        Set(ByVal value As Int16)
            _Rec1 = value
        End Set
    End Property

    Public Property Rec2() As Int16
        Get
            Return _Rec2
        End Get
        Set(ByVal value As Int16)
            _Rec2 = value
        End Set
    End Property

    Public Property RIni() As Date
        Get
            Return _RIni
        End Get
        Set(ByVal value As Date)
            _RIni = value
        End Set
    End Property

    Public Property RFin() As Date
        Get
            Return _RFin
        End Get
        Set(ByVal value As Date)
            _RFin = value
        End Set
    End Property
End Class
