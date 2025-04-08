Public Class ETClinker_FilaReporte

    Private _Dia As Integer
    Public Property Dia() As Integer
        Get
            Return _Dia
        End Get
        Set(ByVal value As Integer)
            _Dia = value
        End Set
    End Property

    Private _De As Nullable(Of DateTime)
    Public Property De() As Nullable(Of DateTime)
        Get
            Return _De
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _De = value
        End Set
    End Property

    Private _A As Nullable(Of DateTime)
    Public Property A() As Nullable(Of DateTime)
        Get
            Return _A
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _A = value
        End Set
    End Property

    Private _TotaHoras As String
    Public Property TotalHoras() As String
        Get
            Return _TotaHoras
        End Get
        Set(ByVal value As String)
            _TotaHoras = value
        End Set
    End Property

    Private _KgPorMin As Decimal
    Public Property KgPorMin() As Decimal
        Get
            Return _KgPorMin
        End Get
        Set(ByVal value As Decimal)
            _KgPorMin = value
        End Set
    End Property

    Private _CrudoRecirculado As Decimal
    Public Property CrudoRecirculado() As Decimal
        Get
            Return _CrudoRecirculado
        End Get
        Set(ByVal value As Decimal)
            _CrudoRecirculado = value
        End Set
    End Property

    Private _Descuento As Decimal
    Public Property Descuento() As Decimal
        Get
            Return _Descuento
        End Get
        Set(ByVal value As Decimal)
            _Descuento = value
        End Set
    End Property

    Private _Merma As Decimal
    Public Property Merma() As Decimal
        Get
            Return _Merma
        End Get
        Set(ByVal value As Decimal)
            _Merma = value
        End Set
    End Property

    Private _ConsumoGas As String
    Public Property ConsumoGas() As String
        Get
            Return _ConsumoGas
        End Get
        Set(ByVal value As String)
            _ConsumoGas = value
        End Set
    End Property

    Private _Fm As Decimal
    Public Property Fm() As Decimal
        Get
            Return _Fm
        End Get
        Set(ByVal value As Decimal)
            _Fm = value
        End Set
    End Property

    Private _Otros As Decimal
    Public Property Otros() As Decimal
        Get
            Return _Otros
        End Get
        Set(ByVal value As Decimal)
            _Otros = value
        End Set
    End Property

    Private _Ciclones As Decimal
    Public Property Ciclones() As Decimal
        Get
            Return _Ciclones
        End Get
        Set(ByVal value As Decimal)
            _Ciclones = value
        End Set
    End Property

    Private _idResumen As Integer
    Public Property idResumen() As Integer
        Get
            Return _idResumen
        End Get
        Set(ByVal value As Integer)
            _idResumen = value
        End Set
    End Property

    Public Sub New()
        Dia = 0
        TotalHoras = String.Empty
        KgPorMin = 0
        CrudoRecirculado = 0.0
        Descuento = 0.0
        Merma = 0.0
        _De = "07:00 AM"
        _A = "07:00 AM"
        _ConsumoGas = 0.0
        _idResumen = 0
        _Otros = 0
        _Ciclones = 0
        _Fm = 0
    End Sub


End Class
