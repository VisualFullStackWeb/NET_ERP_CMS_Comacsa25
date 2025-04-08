Public Class ETCheckListDetalle
    Inherits ETObjecto
    Private _Codigo As String = String.Empty
    Private _ParteEquipo As String = String.Empty
    Private _ParteEqID As Long = 0
    Private _Urgente As String = String.Empty
    Private _UrgenciaMantto As String = String.Empty
    Private _Observacion As String = String.Empty
    Private _CheckList As Long = 0
    Private _Status As String = String.Empty
    Private _Nuevo As Boolean = Boolean.FalseString


    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property ParteEq() As String
        Get
            Return _ParteEquipo
        End Get
        Set(ByVal value As String)
            _ParteEquipo = value
        End Set
    End Property
    Public Property Urgente() As String
        Get
            Return _Urgente
        End Get
        Set(ByVal value As String)
            _Urgente = value
        End Set
    End Property
    Public Property UrgenteMantto() As String
        Get
            Return _UrgenciaMantto
        End Get
        Set(ByVal value As String)
            _UrgenciaMantto = value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
        End Set
    End Property
    Public Property ParteEqID() As Long
        Get
            Return _ParteEqID
        End Get
        Set(ByVal value As Long)
            _ParteEqID = value
        End Set
    End Property
    Public Property CheckList() As Long
        Get
            Return _CheckList
        End Get
        Set(ByVal value As Long)
            _CheckList = value
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
    Public Property Nuevo() As Boolean
        Get
            Return _Nuevo
        End Get
        Set(ByVal value As Boolean)
            _Nuevo = value
        End Set
    End Property
End Class
