Public Class ETPresupuestoServicio
    Inherits ETObjecto
    Private _Cod_Ser As String = String.Empty
    Private _Servicio As String = String.Empty
    Private _Cod_UniMed As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _Entero As Boolean = Boolean.FalseString
    Private _Cantidad As Double = 0
    Private _Precio As Double = 0
    Private _SubTotal As Double = 0
    Private _Nro_OC As String = String.Empty
    Private _Planificado As Double = 0
    Private _Disponible As Double = 0
    Private _Status As String = String.Empty
    Private _Servicio_Ant As String = String.Empty
    Private _Presupuesto As Long = 0

    Public Property Cod_Ser() As String
        Get
            Return _Cod_Ser
        End Get
        Set(ByVal value As String)
            _Cod_Ser = value
        End Set
    End Property
    Public Property Servicio() As String
        Get
            Return _Servicio
        End Get
        Set(ByVal value As String)
            _Servicio = value
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
    Public Property UniMed() As String
        Get
            Return _UniMed
        End Get
        Set(ByVal value As String)
            _UniMed = value
        End Set
    End Property
    Public Property Entero() As Boolean
        Get
            Return _Entero
        End Get
        Set(ByVal value As Boolean)
            _Entero = value
        End Set
    End Property
    Public Overloads Property Cantidad() As Double
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
    Public Property Nro_OC() As String
        Get
            Return _Nro_OC
        End Get
        Set(ByVal value As String)
            _Nro_OC = value
        End Set
    End Property
    Public Property Planificado() As Double
        Get
            Return _Planificado
        End Get
        Set(ByVal value As Double)
            _Planificado = value
        End Set
    End Property
    Public Property Disponible() As Double
        Get
            Return _Disponible
        End Get
        Set(ByVal value As Double)
            _Disponible = value
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
    Public Property Servicio_Ant() As String
        Get
            Return _Servicio_Ant
        End Get
        Set(ByVal value As String)
            _Servicio_Ant = value
        End Set
    End Property
    Public Property Presupuesto() As Long
        Get
            Return _Presupuesto
        End Get
        Set(ByVal value As Long)
            _Presupuesto = value
        End Set
    End Property
End Class
