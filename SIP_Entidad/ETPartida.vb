Public Class ETPartida
    Inherits ETObjecto
    Private _Nodo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _LinNeg As Integer = 0
    Private _TipoProceso As Integer = 0
    Private _ValorControl As String = String.Empty
    Private _AtributoControl As Long = 0
    Private _FamiliaEquipo As Long = 0
    Private _ManttoGeneral As Boolean = Boolean.FalseString
    Private _ParteEquipo As Long = 0
    Private _Total As Double = 0
    Private _TipoFactor As String = String.Empty
    Private _Jornada As Double = 0
    Private _UniMed As String = String.Empty
    Private _Level As Integer = 0
    Private _Status As String = String.Empty
    Private _PartidaPadre As Long = 0
    Private _Partida As Long

    Public Property Nodo() As String
        Get
            Return _Nodo
        End Get
        Set(ByVal value As String)
            _Nodo = value
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
    Public Property LinNeg() As Integer
        Get
            Return _LinNeg
        End Get
        Set(ByVal value As Integer)
            _LinNeg = value
        End Set
    End Property
    Public Property TipoProceso() As Integer
        Get
            Return _TipoProceso
        End Get
        Set(ByVal value As Integer)
            _TipoProceso = value
        End Set
    End Property
    Public Property ValorControl() As String
        Get
            Return _ValorControl
        End Get
        Set(ByVal value As String)
            _ValorControl = value
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
    Public Property FamiliaEquipo() As Long
        Get
            Return _FamiliaEquipo
        End Get
        Set(ByVal value As Long)
            _FamiliaEquipo = value
        End Set
    End Property
    Public Property ManttoGeneral() As Boolean
        Get
            Return _ManttoGeneral
        End Get
        Set(ByVal value As Boolean)
            _ManttoGeneral = value
        End Set
    End Property
    Public Property ParteEquipo() As Long
        Get
            Return _ParteEquipo
        End Get
        Set(ByVal value As Long)
            _ParteEquipo = value
        End Set
    End Property
    Public Overloads Property Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = value
        End Set
    End Property
    Public Property TipoFactor() As String
        Get
            Return _TipoFactor
        End Get
        Set(ByVal value As String)
            _TipoFactor = value
        End Set
    End Property
    Public Property Jornada() As Double
        Get
            Return _Jornada
        End Get
        Set(ByVal value As Double)
            _Jornada = value
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
    Public Property Level() As Integer
        Get
            Return _Level
        End Get
        Set(ByVal value As Integer)
            _Level = value
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
    Public Property PartidaPadre() As Long
        Get
            Return _PartidaPadre
        End Get
        Set(ByVal value As Long)
            _PartidaPadre = value
        End Set
    End Property
    Public Property Partida() As Long
        Get
            Return _Partida
        End Get
        Set(ByVal value As Long)
            _Partida = value
        End Set
    End Property
End Class
