
Public Class ETAtributo
    Inherits ETObjecto
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Valor As String = String.Empty
    Private _Und As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _TipoDato As String = String.Empty
    Private _Longitud As String = String.Empty
    Private _Decimal As String = String.Empty
    Private _Estado As String = String.Empty
    Private _Status As String = String.Empty
    Private _IDCatalogo As String = String.Empty
    Private _IDCatalogoOrigen As Long = 0
    Private _Oblig As Boolean = Boolean.FalseString
    Private _Control As Boolean = Boolean.FalseString
    Private _NomEq As Boolean = Boolean.FalseString
    Private _Orden As Integer = 0
    Private _Action As Boolean = Boolean.FalseString
    Private _TipoG As Boolean = Boolean.FalseString
    Private _ParteEq As Long = 0
    Private _ItemParteEq As Integer = 0
    Private _ItemPadreParteEq As Integer = 0
    Private _Level As Integer = 0
    Private _Nuevo As String = String.Empty
    Private _EquipoComp As Long = 0
    Private _EquipoCompPadre As Long = 0
    Private _Nodo As Long = 0
    Private _NodoPadre As Long = 0
    Private _ParteEqRaiz As Long = 0
    Private _ItemRaiz As Long = 0
    Private _Ubicacion As Boolean = Boolean.FalseString
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
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
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
    Public Property UniMed() As String
        Get
            Return _UniMed
        End Get
        Set(ByVal value As String)
            _UniMed = value
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
    Public Property Longitud() As String
        Get
            Return _Longitud
        End Get
        Set(ByVal value As String)
            _Longitud = value
        End Set
    End Property
    Public Property Decimales() As String
        Get
            Return _Decimal
        End Get
        Set(ByVal value As String)
            _Decimal = value
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
    Public Property Oblig() As Boolean
        Get
            Return _Oblig
        End Get
        Set(ByVal value As Boolean)
            _Oblig = value
        End Set
    End Property
    Public Property Control() As Boolean
        Get
            Return _Control
        End Get
        Set(ByVal value As Boolean)
            _Control = value
        End Set
    End Property
    Public Property NomEq() As Boolean
        Get
            Return _NomEq
        End Get
        Set(ByVal value As Boolean)
            _NomEq = value
        End Set
    End Property
    Public Property Orden() As Integer
        Get
            Return _Orden
        End Get
        Set(ByVal value As Integer)
            _Orden = value
        End Set
    End Property
    Public Property Ubicacion() As Boolean
        Get
            Return _Ubicacion
        End Get
        Set(ByVal value As Boolean)
            _Ubicacion = value
        End Set
    End Property
    Public Property IDCatalogo() As Long
        Get
            Return _IDCatalogo
        End Get
        Set(ByVal value As Long)
            _IDCatalogo = value
        End Set
    End Property
    Public Property IDCatalogoOrigen() As Long
        Get
            Return _IDCatalogoOrigen
        End Get
        Set(ByVal value As Long)
            _IDCatalogoOrigen = value
        End Set
    End Property
    Public Property TipoG() As Boolean
        Get
            Return _TipoG
        End Get
        Set(ByVal value As Boolean)
            _TipoG = value
        End Set
    End Property
    Public Property ParteEquipo() As Long
        Get
            Return _ParteEq
        End Get
        Set(ByVal value As Long)
            _ParteEq = value
        End Set
    End Property
    Public Property ItemParteEq() As Integer
        Get
            Return _ItemParteEq
        End Get
        Set(ByVal value As Integer)
            _ItemParteEq = value
        End Set
    End Property
    Public Property ItemPadreParteEq() As Integer
        Get
            Return _ItemPadreParteEq
        End Get
        Set(ByVal value As Integer)
            _ItemPadreParteEq = value
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
    Public Property Nuevo() As String
        Get
            Return _Nuevo
        End Get
        Set(ByVal value As String)
            _Nuevo = value
        End Set
    End Property
    Public Property EquipoComponente() As Long
        Get
            Return _EquipoComp
        End Get
        Set(ByVal value As Long)
            _EquipoComp = value
        End Set
    End Property
    Public Property EquipoSubComponente() As Long
        Get
            Return _EquipoCompPadre
        End Get
        Set(ByVal value As Long)
            _EquipoCompPadre = value
        End Set
    End Property
    Public Property NodoPadre() As Long
        Get
            Return _NodoPadre
        End Get
        Set(ByVal value As Long)
            _NodoPadre = value
        End Set
    End Property
    Public Property Nodo() As Long
        Get
            Return _Nodo
        End Get
        Set(ByVal value As Long)
            _Nodo = value
        End Set
    End Property
    Public Property ParteEquipoRaiz() As Long
        Get
            Return _ParteEqRaiz
        End Get
        Set(ByVal value As Long)
            _ParteEqRaiz = value
        End Set
    End Property
    Public Property ItemRaiz() As Integer
        Get
            Return _ItemRaiz
        End Get
        Set(ByVal value As Integer)
            _ItemRaiz = value
        End Set
    End Property
End Class
