Public Class ETAsigCelular

    Private _ID As String
    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
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

    Private _PlaCod As String
    Public Property PlaCod() As String
        Get
            Return _PlaCod
        End Get
        Set(ByVal value As String)
            _PlaCod = value
        End Set
    End Property

    Private _NroCelular As String
    Public Property NroCelular() As String
        Get
            Return _NroCelular
        End Get
        Set(ByVal value As String)
            _NroCelular = value
        End Set
    End Property

    Private _Tarifa As Decimal
    Public Property Tarifa() As Decimal
        Get
            Return _Tarifa
        End Get
        Set(ByVal value As Decimal)
            _Tarifa = value
        End Set
    End Property

    Private _CodBolsa As String
    Public Property CodBolsa() As String
        Get
            Return _CodBolsa
        End Get
        Set(ByVal value As String)
            _CodBolsa = value
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

    Sub New()
        ID = 0
        CodCia = ""
        PlaCod = ""
        NroCelular = ""
        Tarifa = 0.0
        CodBolsa = ""
        Usuario = ""
    End Sub

End Class
