Public Class ETConfigVehicular

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _ConfigVeh As String
    Public Property ConfigVeh() As String
        Get
            Return _ConfigVeh
        End Get
        Set(ByVal value As String)
            _ConfigVeh = value
        End Set
    End Property

    Private _CargaUtil As Decimal
    Public Property CargaUtil() As Decimal
        Get
            Return _CargaUtil
        End Get
        Set(ByVal value As Decimal)
            _CargaUtil = value
        End Set
    End Property

    Public Sub New()
        _ID = 0
        _ConfigVeh = String.Empty
        _CargaUtil = 0.0
    End Sub

    Public Sub New(ByVal pID As Integer, ByVal pConfigVeh As String, ByVal pCargaUtil As Decimal)
        _ID = pID
        _ConfigVeh = pConfigVeh
        _CargaUtil = pCargaUtil
    End Sub
End Class
