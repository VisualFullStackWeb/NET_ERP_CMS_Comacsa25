Public Class ETPresupuestoPlanRecursosAsignacion
    Inherits ETObjecto
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _HoraInicio As String = String.Empty
    Private _HoraFin As String = String.Empty
    Private _Horas As Double = 0
    Private _Status As String = String.Empty
    Private _Recurso As Long = 0
    Private _PresupuestoDet As Long = 0
    Private _PresupuestoPlan As Long = 0
    Private _PlanRecurso As Long = 0
    Private _PlanRecursoAsignacion As Long = 0

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
    Public Property HoraInicio() As String
        Get
            Return _HoraInicio
        End Get
        Set(ByVal value As String)
            _HoraInicio = value
        End Set
    End Property
    Public Property HoraFin() As String
        Get
            Return _HoraFin
        End Get
        Set(ByVal value As String)
            _HoraFin = value
        End Set
    End Property
    Public Property Horas() As Double
        Get
            Return _Horas
        End Get
        Set(ByVal value As Double)
            _Horas = value
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
    Public Property PlanRecursoAsignacion() As Long
        Get
            Return _PlanRecursoAsignacion
        End Get
        Set(ByVal value As Long)
            _PlanRecursoAsignacion = value
        End Set
    End Property
End Class
