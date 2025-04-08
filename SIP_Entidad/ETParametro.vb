Public Class ETParametro
    Private _Parametro As String = String.Empty
    Private _Valor As String = String.Empty

    Public Property Parametro() As String
        Get
            Return _Parametro
        End Get
        Set(ByVal value As String)
            _Parametro = value
        End Set
    End Property

    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property
End Class
