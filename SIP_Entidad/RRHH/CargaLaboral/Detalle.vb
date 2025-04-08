Public Class Detalle
    Inherits Auditoria

    Private _idCabecera As Integer
    Private _idDetalle As Integer
    Private _empleado As String
    Private _codigoEmpleado As String
    Private _apellidosEmpleado As String
    Public Property idDetalle() As Integer
        Get
            Return _idDetalle
        End Get
        Set(ByVal value As Integer)
            _idDetalle = value
        End Set
    End Property
    Public Property idCabecera() As Integer
        Get
            Return _idCabecera
        End Get
        Set(ByVal value As Integer)
            _idCabecera = value
        End Set
    End Property

    Public Property empleado() As String
        Get
            Return _empleado
        End Get
        Set(ByVal value As String)
            _empleado = value
        End Set
    End Property
    Public Property codigoEmpleado() As String
        Get
            Return _codigoEmpleado
        End Get
        Set(ByVal value As String)
            _codigoEmpleado = value
        End Set
    End Property
    Public Property apellidosEmpleado() As String
        Get
            Return _apellidosEmpleado
        End Get
        Set(ByVal value As String)
            _apellidosEmpleado = value
        End Set
    End Property
End Class
