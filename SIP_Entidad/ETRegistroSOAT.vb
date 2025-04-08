Public Class ETRegistroSOAT

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _codcia As String
    Public Property codcia() As String
        Get
            Return _codcia
        End Get
        Set(ByVal value As String)
            _codcia = value
        End Set
    End Property

    Private _placa As String
    Public Property placa() As String
        Get
            Return _placa
        End Get
        Set(ByVal value As String)
            _placa = value
        End Set
    End Property

    Private _soat As String
    Public Property soat() As String
        Get
            Return _soat
        End Get
        Set(ByVal value As String)
            _soat = value
        End Set
    End Property

    Private _precio As Decimal
    Public Property precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property

    Private _usuario As String
    Public Property usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Public Sub New()
        ID = 0
        codcia = ""
        placa = ""
        soat = ""
        usuario = ""
        precio = 0.0
    End Sub
End Class
