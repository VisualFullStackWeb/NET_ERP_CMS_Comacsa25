Public Class ETPresupuestoPlanRecursos
    Inherits ETObjecto
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _Entero As Boolean = Boolean.FalseString
    Private _Dia As String = String.Empty
    Private _Cantidad As Double = 0
    Private _Status As String = String.Empty
    Private _Recurso As Long = 0
    Private _PresupuestoDet As Long = 0
    Private _PresupuestoPlan As Long = 0
    Private _PlanRecurso As Long = 0
    Private _Periodo As String = String.Empty
    Private _Contar As Integer = 0

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
    Public Property Und() As String
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
    Public Property Dias() As String
        Get
            Return _Dia
        End Get
        Set(ByVal value As String)
            _Dia = value
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
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Public Property Recurso() As Long
        Get
            Return _Recurso
        End Get
        Set(ByVal value As Long)
            _Recurso = value
        End Set
    End Property
    Public Property PresupuestoDet() As Long
        Get
            Return _PresupuestoDet
        End Get
        Set(ByVal value As Long)
            _PresupuestoDet = value
        End Set
    End Property
    Public Property PresupuestoPlan() As Long
        Get
            Return _PresupuestoPlan
        End Get
        Set(ByVal value As Long)
            _PresupuestoPlan = value
        End Set
    End Property
    Public Property PlanRecurso() As Long
        Get
            Return _PlanRecurso
        End Get
        Set(ByVal value As Long)
            _PlanRecurso = value
        End Set
    End Property
    Public Overloads Property Periodo() As String
        Get
            Return _Periodo
        End Get
        Set(ByVal value As String)
            _Periodo = value
        End Set
    End Property
    Public Property Contar() As Integer
        Get
            Return _Contar
        End Get
        Set(ByVal value As Integer)
            _Contar = value
        End Set
    End Property
End Class
