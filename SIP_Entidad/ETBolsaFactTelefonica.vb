Public Class ETBolsaFactTelefonica

    Private _CodCia As String
    Public Property CodCia() As String
        Get
            Return _CodCia
        End Get
        Set(ByVal value As String)
            _CodCia = value
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

    Private _Bolsa As String
    Public Property Bolsa() As String
        Get
            Return _Bolsa
        End Get
        Set(ByVal value As String)
            _Bolsa = value
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
        CodCia = ""
        Bolsa = ""
        Usuario = ""
    End Sub


End Class
