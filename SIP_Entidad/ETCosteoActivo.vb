Public Class ETCosteoActivo
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Cantidad As Double = 0
    Private _Status As String = String.Empty
    Private _Usuario As String = String.Empty
    Private _Tipo As Short = 0
    Private _Fecha As Date = Date.Today

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

    Public Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Double)
            _Cantidad = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Tipo() As Short
        Get
            Return _Tipo
        End Get
        Set(ByVal value As Short)
            _Tipo = value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property

End Class
