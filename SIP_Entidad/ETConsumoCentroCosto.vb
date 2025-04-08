Public Class ETConsumoCentroCosto

    Private _CodCia As String
    Public Property CodCia() As String
        Get
            Return _CodCia
        End Get
        Set(ByVal value As String)
            _CodCia = value
        End Set
    End Property

    Private _tipo As Int32
    Public Property tipo() As Int32
        Get
            Return _tipo
        End Get
        Set(ByVal value As Int32)
            _tipo = value
        End Set
    End Property

    Private _opcion As Int32
    Public Property opcion() As Int32
        Get
            Return _opcion
        End Get
        Set(ByVal value As Int32)
            _opcion = value
        End Set
    End Property

    Private _coddpto As String
    Public Property coddpto() As String
        Get
            Return _coddpto
        End Get
        Set(ByVal value As String)
            _coddpto = value
        End Set
    End Property

    Private _coddisto As String
    Public Property coddisto() As String
        Get
            Return _coddisto
        End Get
        Set(ByVal value As String)
            _coddisto = value
        End Set
    End Property

    Private _coddistd As String
    Public Property coddistd() As String
        Get
            Return _coddistd
        End Get
        Set(ByVal value As String)
            _coddistd = value
        End Set
    End Property

    Private _codprov As String
    Public Property codprov() As String
        Get
            Return _codprov
        End Get
        Set(ByVal value As String)
            _codprov = value
        End Set
    End Property

    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property

    Private _precio As Double
    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property

    Private _CodTipo As String
    Public Property CodTipo() As String
        Get
            Return _CodTipo
        End Get
        Set(ByVal value As String)
            _CodTipo = value
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

    Private _CodCentroCosto As String
    Public Property CodCentroCosto() As String
        Get
            Return _CodCentroCosto
        End Get
        Set(ByVal value As String)
            _CodCentroCosto = value
        End Set
    End Property

    Private _Codequipo As String
    Public Property Codequipo() As String
        Get
            Return _Codequipo
        End Get
        Set(ByVal value As String)
            _Codequipo = value
        End Set
    End Property

    Private _CodCentroCostoIni As String
    Public Property CodCentroCostoIni() As String
        Get
            Return _CodCentroCostoIni
        End Get
        Set(ByVal value As String)
            _CodCentroCostoIni = value
        End Set
    End Property

    Private _CodCentroCostoFin As String
    Public Property CodCentroCostoFin() As String
        Get
            Return _CodCentroCostoFin
        End Get
        Set(ByVal value As String)
            _CodCentroCostoFin = value
        End Set
    End Property

    Private _Transferencia As String
    Public Property Transferencia() As String
        Get
            Return _Transferencia
        End Get
        Set(ByVal value As String)
            _Transferencia = value
        End Set
    End Property

    Private _Consumo As Decimal
    Public Property Consumo() As Decimal
        Get
            Return _Consumo
        End Get
        Set(ByVal value As Decimal)
            _Consumo = value
        End Set
    End Property

    Private _Unidad As String
    Public Property Unidad() As String
        Get
            Return _Unidad
        End Get
        Set(ByVal value As String)
            _Unidad = value
        End Set
    End Property

    Private _Observacion As String
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
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

    Public Sub New()
        CodCia = String.Empty
        Id = 0
        CodTipo = String.Empty
        Anio = 0
        Mes = 0
        CodCentroCosto = String.Empty
        Consumo = 0
        Usuario = String.Empty
        Unidad = String.Empty
    End Sub
End Class
