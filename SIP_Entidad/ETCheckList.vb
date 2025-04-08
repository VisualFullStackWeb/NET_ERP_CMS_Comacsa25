Public Class ETCheckList
    Inherits ETObjecto
    Private _Codigo As String = String.Empty
    Private _Fecha As Date = Now
    Private _Responsable As String = String.Empty
    Private _TipoChL As Boolean = Boolean.FalseString
    Private _Equipo As String = String.Empty
    Private _Control As String = String.Empty
    Private _ValorControl As String = String.Empty
    Private _Und As String = String.Empty
    Private _Estado As String = String.Empty
    Private _ResponsableID As String = String.Empty
    Private _TipoCL As String = String.Empty
    Private _EquipoID As Long = 0
    Private _AtributoControl As Long = 0
    Private _UniMed As String = String.Empty
    Private _Status As String = String.Empty
    Private _CheckList As Long = 0
    Private _AtribOblig As Boolean = Boolean.FalseString
    Private _TipoDato As String = String.Empty
    Private _Longitud As Integer = 0
    Private _Decimales As Integer = 0

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property Responsable() As String
        Get
            Return _Responsable
        End Get
        Set(ByVal value As String)
            _Responsable = value
        End Set
    End Property
    Public Property TipoCL() As String
        Get
            Return _TipoCL
        End Get
        Set(ByVal value As String)
            _TipoCL = value
        End Set
    End Property
    Public Property Equipo() As String
        Get
            Return _Equipo
        End Get
        Set(ByVal value As String)
            _Equipo = value
        End Set
    End Property
    Public Property Control() As String
        Get
            Return _Control
        End Get
        Set(ByVal value As String)
            _Control = value
        End Set
    End Property
    Public Property Valor() As String
        Get
            Return _ValorControl
        End Get
        Set(ByVal value As String)
            _ValorControl = value
        End Set
    End Property
    Public Property Und() As String
        Get
            Return _Und
        End Get
        Set(ByVal value As String)
            _Und = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
        End Set
    End Property
    Public Property ResponsableID() As String
        Get
            Return _ResponsableID
        End Get
        Set(ByVal value As String)
            _ResponsableID = value
        End Set
    End Property
    Public Property TipoChL() As Boolean
        Get
            Return _TipoChL
        End Get
        Set(ByVal value As Boolean)
            _TipoChL = value
        End Set
    End Property
    Public Property EquipoID() As Long
        Get
            Return _EquipoID
        End Get
        Set(ByVal value As Long)
            _EquipoID = value
        End Set
    End Property
    Public Property AtributoControl() As Long
        Get
            Return _AtributoControl

        End Get
        Set(ByVal value As Long)
            _AtributoControl = value
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
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
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
    Public Property AtribOb() As Boolean
        Get
            Return _AtribOblig
        End Get
        Set(ByVal value As Boolean)
            _AtribOblig = value
        End Set
    End Property
    Public Property TipoDato() As String
        Get
            Return _TipoDato
        End Get
        Set(ByVal value As String)
            _TipoDato = value
        End Set
    End Property
    Public Property Longitud() As Integer
        Get
            Return _Longitud
        End Get
        Set(ByVal value As Integer)
            _Longitud = value
        End Set
    End Property
    Public Property Decimales() As Integer
        Get
            Return _Decimales
        End Get
        Set(ByVal value As Integer)
            _Decimales = value
        End Set
    End Property
End Class
