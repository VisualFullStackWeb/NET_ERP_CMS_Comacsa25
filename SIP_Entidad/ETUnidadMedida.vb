Public Class ETUnidadMedida
    Inherits ETObjecto
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Abrev As String = String.Empty
    Private _Decimales As String = String.Empty
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property Abrev() As String
        Get
            Return _Abrev
        End Get
        Set(ByVal value As String)
            _Abrev = value
        End Set
    End Property
    Public Property Decimales() As String
        Get
            Return _Decimales
        End Get
        Set(ByVal value As String)
            _Decimales = value
        End Set
    End Property
End Class
