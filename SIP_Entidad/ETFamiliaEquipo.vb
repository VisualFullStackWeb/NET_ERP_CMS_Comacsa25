Public Class ETFamiliaEquipo
    Inherits ETObjecto

    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Estado As String = String.Empty
    Private _Foto As Byte()
    Private _Status As String = String.Empty
    Private _IDFamiliaEq As Long
    Private _ExisteFoto As Boolean = Boolean.FalseString

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
    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
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
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Public Property IDFamiliaEq() As Long
        Get
            Return _IDFamiliaEq
        End Get
        Set(ByVal value As Long)
            _IDFamiliaEq = value
        End Set
    End Property
    Public Property IDCatalogo() As Long
        Get
            Return _IDFamiliaEq
        End Get
        Set(ByVal value As Long)
            _IDFamiliaEq = value
        End Set
    End Property
    Public Property ExisteImage() As Boolean
        Get
            Return _ExisteFoto
        End Get
        Set(ByVal value As Boolean)
            _ExisteFoto = value
        End Set
    End Property
End Class
