Public Class ETLstFirmaMonto
    Private _Usuario As String
    Private _Firma As Boolean

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

End Class
