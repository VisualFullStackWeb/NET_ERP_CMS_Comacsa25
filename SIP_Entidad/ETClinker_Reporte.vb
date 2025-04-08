Public Class ETClinker_Reporte

    Private _idResumen As String
    Public Property idResumen() As String
        Get
            Return _idResumen
        End Get
        Set(ByVal value As String)
            _idResumen = value
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

    Private _Tipo As String
    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Private _I7 As Decimal
    Public Property I7() As Decimal
        Get
            Return _I7
        End Get
        Set(ByVal value As Decimal)
            _I7 = value
        End Set
    End Property

    Private _K7 As Decimal
    Public Property K7() As Decimal
        Get
            Return _K7
        End Get
        Set(ByVal value As Decimal)
            _K7 = value
        End Set
    End Property


    Private _L7 As Decimal
    Public Property L7() As Decimal
        Get
            Return _L7
        End Get
        Set(ByVal value As Decimal)
            _L7 = value
        End Set
    End Property


    Private _M7 As Decimal
    Public Property M7() As Decimal
        Get
            Return _M7
        End Get
        Set(ByVal value As Decimal)
            _M7 = value
        End Set
    End Property

    Private _N7 As Decimal
    Public Property N7() As Decimal
        Get
            Return _N7
        End Get
        Set(ByVal value As Decimal)
            _N7 = value
        End Set
    End Property


    Private _O7 As Decimal
    Public Property O7() As Decimal
        Get
            Return _O7
        End Get
        Set(ByVal value As Decimal)
            _O7 = value
        End Set
    End Property

    Private _P7 As Decimal
    Public Property P7() As Decimal
        Get
            Return _P7
        End Get
        Set(ByVal value As Decimal)
            _P7 = value
        End Set
    End Property

    Private _Q7 As Decimal
    Public Property Q7() As Decimal
        Get
            Return _Q7
        End Get
        Set(ByVal value As Decimal)
            _Q7 = value
        End Set
    End Property

    Private _R7 As Decimal
    Public Property R7() As Decimal
        Get
            Return _R7
        End Get
        Set(ByVal value As Decimal)
            _R7 = value
        End Set
    End Property

    Private _S7 As Decimal
    Public Property S7() As Decimal
        Get
            Return _S7
        End Get
        Set(ByVal value As Decimal)
            _S7 = value
        End Set
    End Property

    Private _Detalles As List(Of ETClinker_FilaReporte)
    Public Property Detalles() As List(Of ETClinker_FilaReporte)
        Get
            Return _Detalles
        End Get
        Set(ByVal value As List(Of ETClinker_FilaReporte))
            _Detalles = value
        End Set
    End Property

    Public Sub New()
        _idResumen = 0
        _Anio = 0
        _Mes = 0
        _Tipo = String.Empty
        _I7 = 0.0
        _K7 = 0.0
        _L7 = 0.0
        _M7 = 0.0
        _N7 = 0.0
        _O7 = 0.0
        _N7 = 0.0
        _P7 = 0.0
        _Q7 = 0.0
        _R7 = 0.0
        _S7 = 0.0
        _Detalles = New List(Of ETClinker_FilaReporte)
    End Sub

End Class
