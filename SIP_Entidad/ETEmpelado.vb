Public Class ETEmpelado
    Private _CodPla As String = String.Empty
    Private _Opcion As String = String.Empty
    Private _Accion As String = String.Empty
    Private _Nombres As String = String.Empty
    Private _Motivo As String = String.Empty
    Private _Observaciones As String = String.Empty
    Private _Fecha As DateTime = DateTime.Now
    Private _Usuario As String = String.Empty
    Private _Terminal As String = String.Empty
    Private _Sec As String = String.Empty
    Private _TipoPago As String = String.Empty

    Public Property TipoPago() As String
        Get
            Return _TipoPago
        End Get
        Set(ByVal value As String)
            _TipoPago = value
        End Set
    End Property
    Public Property Sec() As String
        Get
            Return _Sec
        End Get
        Set(ByVal value As String)
            _Sec = value
        End Set
    End Property

    Public Property CodPla() As String
        Get
            Return _CodPla
        End Get
        Set(ByVal value As String)
            _CodPla = value
        End Set
    End Property
    Public Property Opcion() As String
        Get
            Return _Opcion
        End Get
        Set(ByVal value As String)
            _Opcion = value
        End Set
    End Property
    Public Property Accion() As String
        Get
            Return _Accion
        End Get
        Set(ByVal value As String)
            _Accion = value
        End Set
    End Property

    Public Property Nombres() As String
        Get
            Return _Nombres
        End Get
        Set(ByVal value As String)
            _Nombres = value
        End Set
    End Property

    Public Property Motivo() As String
        Get
            Return _Motivo
        End Get
        Set(ByVal value As String)
            _Motivo = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return _Observaciones
        End Get
        Set(ByVal value As String)
            _Observaciones = value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal value As DateTime)
            _Fecha = value
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
    Public Property Terminal() As String
        Get
            Return _Terminal
        End Get
        Set(ByVal value As String)
            _Terminal = value
        End Set
    End Property

End Class
