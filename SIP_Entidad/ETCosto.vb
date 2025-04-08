
Public Class ETCosto

    Inherits ETObjecto

    Private _Descripcion As String = String.Empty

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

End Class
