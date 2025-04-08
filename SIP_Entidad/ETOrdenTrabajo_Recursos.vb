Public Class ETOrdenTrabajo_Recursos
    Inherits ETObjecto
    Private _Action As Boolean = Boolean.FalseString
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _Cantidad As Decimal = Decimal.Zero
    Private _Precio As Decimal = Decimal.Zero
    Private _SubTotal As Decimal = Decimal.Zero
    Private _Cod_UniMed As String = String.Empty
    Private _OrdenTrabajo As Long = 0
    Private _Recurso As String = String.Empty
    Private _RecursoID As Long = 0
    Private _Status As String = String.Empty
    Private _TipoRecurso As String = String.Empty
    Private _Moneda As String = String.Empty

    Public Property Action() As Boolean
        Get
            Return _Action
        End Get
        Set(ByVal value As Boolean)
            _Action = value
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

    Public Overloads Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

    Public Property Moneda() As String
        Get
            Return _Moneda
        End Get
        Set(ByVal value As String)
            _Moneda = value
        End Set
    End Property

    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal value As Decimal)
            _Precio = value
        End Set
    End Property

    Public Property SubTotal() As Decimal
        Get
            Return _SubTotal
        End Get
        Set(ByVal value As Decimal)
            _SubTotal = value
        End Set
    End Property

    Public Property Cod_UniMed() As String
        Get
            Return _Cod_UniMed
        End Get
        Set(ByVal value As String)
            _Cod_UniMed = value
        End Set
    End Property

    Public Property OrdenTrabajo() As Long
        Get
            Return _OrdenTrabajo
        End Get
        Set(ByVal value As Long)
            _OrdenTrabajo = value
        End Set
    End Property

    Public Property Recurso() As String
        Get
            Return _Recurso
        End Get
        Set(ByVal value As String)
            _Recurso = value
        End Set
    End Property

    Public Property RecursoID() As Long
        Get
            Return _RecursoID
        End Get
        Set(ByVal value As Long)
            _RecursoID = value
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

    Public Property TipoRecurso() As String
        Get
            Return _TipoRecurso
        End Get
        Set(ByVal value As String)
            _TipoRecurso = value
        End Set
    End Property

End Class
