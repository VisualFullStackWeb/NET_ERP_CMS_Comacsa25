

Public Class ETProveedor
    ' Inherits ETObjecto

    Private _CodCiaProveedor As String = String.Empty
    Private _CodProveedor As String = String.Empty
    Private _DesProveedor As String = String.Empty
    Private _RucProveedor As String = String.Empty

    Public Property CodCiaProveedor() As String
        Get
            Return _CodCiaProveedor
        End Get
        Set(ByVal value As String)
            _CodCiaProveedor = value
        End Set
    End Property

    Public Property CodProveedor() As String
        Get
            Return _CodProveedor
        End Get
        Set(ByVal value As String)
            _CodProveedor = value
        End Set
    End Property
    Public Property DesProveedor() As String
        Get
            Return _DesProveedor
        End Get
        Set(ByVal value As String)
            _DesProveedor = value
        End Set
    End Property
    Public Property RucProveedor() As String
        Get
            Return _RucProveedor
        End Get
        Set(ByVal value As String)
            _RucProveedor = value
        End Set
    End Property

End Class
