Public Class ETParteEquipo
    Inherits ETObjecto
    Private _Action As Boolean
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Estado As String = String.Empty
    Private _CodCompOrigen As String = String.Empty
    Private _CompOrigen As String = String.Empty
    Private _CompID As Long = 0
    Private _Status As String = String.Empty
    Private _Interno As Boolean = Boolean.FalseString
    Private _IDCatalogoOrigen As Long
    Private _Item As Integer = 0
    Private _IDCatalogo As Long

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
    Public Property CodigoOrigen() As String
        Get
            Return _CodCompOrigen
        End Get
        Set(ByVal value As String)
            _CodCompOrigen = value
        End Set
    End Property
    Public Property DescripcionOrigen() As String
        Get
            Return _CompOrigen
        End Get
        Set(ByVal value As String)
            _CompOrigen = value
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
    Public Property Interno() As Boolean
        Get
            Return _Interno
        End Get
        Set(ByVal value As Boolean)
            _Interno = value
        End Set
    End Property
    Public Property Item() As Integer
        Get
            Return _Item
        End Get
        Set(ByVal value As Integer)
            _Item = value
        End Set
    End Property
    Public Property CompOrigen() As Long
        Get
            Return _CompID
        End Get
        Set(ByVal value As Long)
            _CompID = value
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

    Public Property IDCatalogoOrigen() As Long
        Get
            Return _IDCatalogoOrigen
        End Get
        Set(ByVal value As Long)
            _IDCatalogoOrigen = value
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
End Class
