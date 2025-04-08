Public Class ETFacturaTelefonica

    Private _Ope As Integer
    Public Property Ope() As Integer
        Get
            Return _Ope
        End Get
        Set(ByVal value As Integer)
            _Ope = value
        End Set
    End Property

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _CodCia As String
    Public Property CodCia() As String
        Get
            Return _CodCia
        End Get
        Set(ByVal value As String)
            _CodCia = value
        End Set
    End Property

    Private _CodProv As String
    Public Property CodProv() As String
        Get
            Return _CodProv
        End Get
        Set(ByVal value As String)
            _CodProv = value
        End Set
    End Property

    Private _TipoDoc As String
    Public Property TipoDoc() As String
        Get
            Return _TipoDoc
        End Get
        Set(ByVal value As String)
            _TipoDoc = value
        End Set
    End Property

    Private _NroDoc As String
    Public Property NroDoc() As String
        Get
            Return _NroDoc
        End Get
        Set(ByVal value As String)
            _NroDoc = value
        End Set
    End Property

    Private _subtotal As Double
    Public Property subtotal() As Double
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Double)
            _subtotal = value
        End Set
    End Property

    Private _igv As Double
    Public Property igv() As Double
        Get
            Return _igv
        End Get
        Set(ByVal value As Double)
            _igv = value
        End Set
    End Property

    Private _total As Double
    Public Property total() As Double
        Get
            Return _total
        End Get
        Set(ByVal value As Double)
            _total = value
        End Set
    End Property

    Private _lecturaant As Double
    Public Property lecturaant() As Double
        Get
            Return _lecturaant
        End Get
        Set(ByVal value As Double)
            _lecturaant = value
        End Set
    End Property

    Private _lecturaact As Double
    Public Property lecturaact() As Double
        Get
            Return _lecturaact
        End Get
        Set(ByVal value As Double)
            _lecturaact = value
        End Set
    End Property

    Private _volconsumido As Double
    Public Property volconsumido() As Double
        Get
            Return _volconsumido
        End Get
        Set(ByVal value As Double)
            _volconsumido = value
        End Set
    End Property

    Private _factcorrecion As Double
    Public Property factcorrecion() As Double
        Get
            Return _factcorrecion
        End Get
        Set(ByVal value As Double)
            _factcorrecion = value
        End Set
    End Property

    Private _fecha As Date
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property

    Private _condestandar As Double
    Public Property condestandar() As Double
        Get
            Return _condestandar
        End Get
        Set(ByVal value As Double)
            _condestandar = value
        End Set
    End Property

    Private _volfacturado As Double
    Public Property volfacturado() As Double
        Get
            Return _volfacturado
        End Get
        Set(ByVal value As Double)
            _volfacturado = value
        End Set
    End Property

    Private _podcalorifico As Double
    Public Property podcalorifico() As Double
        Get
            Return _podcalorifico
        End Get
        Set(ByVal value As Double)
            _podcalorifico = value
        End Set
    End Property

    Private _mindiario As Double
    Public Property mindiario() As Double
        Get
            Return _mindiario
        End Get
        Set(ByVal value As Double)
            _mindiario = value
        End Set
    End Property

    Private _gasnatural As Double
    Public Property gasnatural() As Double
        Get
            Return _gasnatural
        End Get
        Set(ByVal value As Double)
            _gasnatural = value
        End Set
    End Property

    Private _servtransporte As Double
    Public Property servtransporte() As Double
        Get
            Return _servtransporte
        End Get
        Set(ByVal value As Double)
            _servtransporte = value
        End Set
    End Property

    Private _distvariable As Double
    Public Property distvariable() As Double
        Get
            Return _distvariable
        End Get
        Set(ByVal value As Double)
            _distvariable = value
        End Set
    End Property

    Private _distfijo As Double
    Public Property distfijo() As Double
        Get
            Return _distfijo
        End Get
        Set(ByVal value As Double)
            _distfijo = value
        End Set
    End Property

    Private _comercializacion As Double
    Public Property comercializacion() As Double
        Get
            Return _comercializacion
        End Get
        Set(ByVal value As Double)
            _comercializacion = value
        End Set
    End Property

    Private _otros As Double
    Public Property otros() As Double
        Get
            Return _otros
        End Get
        Set(ByVal value As Double)
            _otros = value
        End Set
    End Property

    Private _redondeoant As Double
    Public Property redondeoant() As Double
        Get
            Return _redondeoant
        End Get
        Set(ByVal value As Double)
            _redondeoant = value
        End Set
    End Property

    Private _redondeoact As Double
    Public Property redondeoact() As Double
        Get
            Return _redondeoact
        End Get
        Set(ByVal value As Double)
            _redondeoact = value
        End Set
    End Property


    Private _Grupo As String
    Public Property Grupo() As String
        Get
            Return _Grupo
        End Get
        Set(ByVal value As String)
            _Grupo = value
        End Set
    End Property

    Private _PlaCod As String
    Public Property PlaCod() As String
        Get
            Return _PlaCod
        End Get
        Set(ByVal value As String)
            _PlaCod = value
        End Set
    End Property

    Private _Usuario As String
    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Private _Anio As Integer
    Public Property Anio() As Integer
        Get
            Return _Anio
        End Get
        Set(ByVal value As Integer)
            _Anio = value
        End Set
    End Property

    Private _Mes As Integer
    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal value As Integer)
            _Mes = value
        End Set
    End Property

    Public Sub New()
        ID = 0
        CodCia = ""
        CodProv = ""
        NroDoc = ""
        Grupo = ""
        PlaCod = ""
        Usuario = ""
        Anio = Now.Year
        Mes = Now.Month
    End Sub
End Class
