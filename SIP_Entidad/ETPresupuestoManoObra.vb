Public Class ETPresupuestoManoObra
    Inherits ETObjecto
    Private _Cod_Cargo As String = String.Empty
    Private _Cargo As String = String.Empty
    Private _Cod_UniMed As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _Entero As Boolean = Boolean.FalseString
    Private _Cuadrilla As Double = 0
    Private _Cantidad As Double = 0
    Private _Precio As Double = 0
    Private _SubTotal As Double = 0
    Private _Planificado As Double = 0
    Private _Disponible As Double = 0
    Private _Status As String = String.Empty
    Private _Cargo_Ant As String = String.Empty
    Private _Presupuesto As Long = 0

    Public Property Cod_Cargo() As String
        Get
            Return _Cod_Cargo
        End Get
        Set(ByVal value As String)
            _Cod_Cargo = value
        End Set
    End Property
    Public Property Cargo() As String
        Get
            Return _Cargo
        End Get
        Set(ByVal value As String)
            _Cargo = value
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
    Public Property Cuadrilla() As Double
        Get
            Return _Cuadrilla
        End Get
        Set(ByVal value As Double)
            _Cuadrilla = value
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
    Public Property Cargo_Ant() As String
        Get
            Return _Cargo_Ant
        End Get
        Set(ByVal value As String)
            _Cargo_Ant = value
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
