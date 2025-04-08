Public Class ETEquipo
    Inherits ETObjecto
    Private _Action As Boolean = Boolean.FalseString
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _LinNeg As String = String.Empty
    Private _LinNegID As Integer = 0
    Private _FamiliaEqDesc As String = String.Empty
    Private _FamiliaEq As Long = 0
    Private _Foto As Byte()
    Private _Plano As Byte()
    Private _CodResponsable As String = String.Empty
    Private _Responsable As String = String.Empty
    Private _CodManipulador As String = String.Empty
    Private _Manipulador As String = String.Empty
    Private _Estado As String = String.Empty
    Private _Status As String = String.Empty
    Private _Equipo As Long = 0
    Private _ExisteFoto As Boolean = Boolean.FalseString
    Private _ExistePlano As Boolean = Boolean.FalseString
    Private _AtribID As Long = 0
    Private _Atributo As String = String.Empty
    Private _Und As String = String.Empty
    Private _TipoDato As Integer = 0
    Private _Longitud As Integer = 0
    Private _Decimales As Integer = 0
    Private _CodigoAnterior As String = String.Empty
    Private _CodigoContabilidad As String = String.Empty

    Public Property Action() As Boolean
        Get
            Return _Action
        End Get
        Set(ByVal value As Boolean)
            _Action = value
        End Set
    End Property
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
    Public Property LinNeg() As String
        Get
            Return _LinNeg
        End Get
        Set(ByVal value As String)
            _LinNeg = value
        End Set
    End Property
    Public Property FamiliaEq() As String
        Get
            Return _FamiliaEqDesc
        End Get
        Set(ByVal value As String)
            _FamiliaEqDesc = value
        End Set
    End Property
    Public Property FamiliaEqID() As Long
        Get
            Return _FamiliaEq
        End Get
        Set(ByVal value As Long)
            _FamiliaEq = value
        End Set
    End Property
    Public Property Foto() As Byte()
        Get
            Return _Foto
        End Get
        Set(ByVal value As Byte())
            _Foto = value
        End Set
    End Property
    Public Property Plano() As Byte()
        Get
            Return _Plano
        End Get
        Set(ByVal value As Byte())
            _Plano = value
        End Set
    End Property
    Public Property CodResponsable() As String
        Get
            Return _CodResponsable
        End Get
        Set(ByVal value As String)
            _CodResponsable = value
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
    Public Property CodManipulador() As String
        Get
            Return _CodManipulador
        End Get
        Set(ByVal value As String)
            _CodManipulador = value
        End Set
    End Property
    Public Property Manipulador() As String
        Get
            Return _Manipulador
        End Get
        Set(ByVal value As String)
            _Manipulador = value
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
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Public Property LinNegID() As Integer
        Get
            Return _LinNegID
        End Get
        Set(ByVal value As Integer)
            _LinNegID = value
        End Set
    End Property
    Public Property Equipo() As Long
        Get
            Return _Equipo
        End Get
        Set(ByVal value As Long)
            _Equipo = value
        End Set
    End Property
    Public Property ExisteFoto() As Boolean
        Get
            Return _ExisteFoto
        End Get
        Set(ByVal value As Boolean)
            _ExisteFoto = value
        End Set
    End Property
    Public Property ExistePlano() As Boolean
        Get
            Return _ExistePlano
        End Get
        Set(ByVal value As Boolean)
            _ExistePlano = value
        End Set
    End Property
    Public Property AtribID() As Long
        Get
            Return _AtribID
        End Get
        Set(ByVal value As Long)
            _AtribID = value
        End Set
    End Property
    Public Property Atributo() As String
        Get
            Return _Atributo
        End Get
        Set(ByVal value As String)
            _Atributo = value
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
    Public Property TipoDato() As Integer
        Get
            Return _TipoDato
        End Get
        Set(ByVal value As Integer)
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
    Public Property CodigoAnterior() As String
        Get
            Return _CodigoAnterior
        End Get
        Set(ByVal value As String)
            _CodigoAnterior = value
        End Set
    End Property
    Public Property CodigoContabilidad() As String
        Get
            Return _CodigoContabilidad
        End Get
        Set(ByVal value As String)
            _CodigoContabilidad = value
        End Set
    End Property
End Class
