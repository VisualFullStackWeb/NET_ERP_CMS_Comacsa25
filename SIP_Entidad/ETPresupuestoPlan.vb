Public Class ETPresupuestoPlan
    Inherits ETObjecto
    Private _Codigo As String = String.Empty
    Private _Item As Short = 0
    Private _Periodo As String = String.Empty
    Private _Porcentaje As Double = 0
    Private _Status As String = String.Empty
    Private _PresupuestoDet As Long = 0
    Private _PlanID As Long = 0

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property Item() As Short
        Get
            Return _Item
        End Get
        Set(ByVal value As Short)
            _Item = value
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
    Public Overloads Property Porcentaje() As Double
        Get
            Return _Porcentaje
        End Get
        Set(ByVal value As Double)
            _Porcentaje = value
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
    Public Property PresupuestoDet() As Long
        Get
            Return _PresupuestoDet
        End Get
        Set(ByVal value As Long)
            _PresupuestoDet = value
        End Set
    End Property
    Public Property PlanID() As Long
        Get
            Return _PlanID
        End Get
        Set(ByVal value As Long)
            _PlanID = value
        End Set
    End Property
End Class
