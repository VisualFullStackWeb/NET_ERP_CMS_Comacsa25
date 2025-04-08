Public Class ETOTRecursoDetalle
    Private _Billete As String = String.Empty
    Private _Fecha As Date = Date.Today
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _Cantidad As Double = 0
    Private _Precio As Double = 0
    Private _SubTotal As Double = 0

    Public Property Billete() As String
        Get
            Return _Billete
        End Get
        Set(ByVal value As String)
            _Billete = value
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
    Public Property UniMed() As String
        Get
            Return _UniMed
        End Get
        Set(ByVal value As String)
            _UniMed = value
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
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal value As Double)
            _Precio = value
        End Set
    End Property
    Public Property SubTotal() As Double
        Get
            Return _SubTotal
        End Get
        Set(ByVal value As Double)
            _SubTotal = value
        End Set
    End Property
   
End Class
