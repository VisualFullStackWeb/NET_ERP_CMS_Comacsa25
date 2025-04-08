
Public Class ETProforma

    Inherits ETObjecto

    Private _NumPedido As String = String.Empty
    Private _CodCliente As String = String.Empty
    Private _DesCliente As String = String.Empty
    Private _FechaEmision As Date = Date.Now
    Private _FechaInicio As Date = Date.Now
    Private _FechaFinal As Date = Date.Now

    Public Property NumPedido() As String
        Get
            Return _NumPedido
        End Get
        Set(ByVal value As String)
            _NumPedido = value
        End Set
    End Property

    Public Property FechaEmision() As Date
        Get
            Return _FechaEmision
        End Get
        Set(ByVal value As Date)
            _FechaEmision = value
        End Set
    End Property

    Public Overloads Property FechaInicio() As Date
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As Date)
            _FechaInicio = value
        End Set
    End Property

    Public Property FechaFinal() As Date
        Get
            Return _FechaFinal
        End Get
        Set(ByVal value As Date)
            _FechaFinal = value
        End Set
    End Property

    Public Property CodCliente() As String
        Get
            Return _CodCliente
        End Get
        Set(ByVal value As String)
            _CodCliente = value
        End Set
    End Property

    Public Property DesCliente() As String
        Get
            Return _DesCliente
        End Get
        Set(ByVal value As String)
            _DesCliente = value
        End Set
    End Property

End Class
