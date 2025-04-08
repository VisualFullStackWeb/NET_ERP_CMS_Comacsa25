Public Class ETGlosa
    Private _ID As String = String.Empty
    Private _Sistema As String = String.Empty
    Private _Grupo As String = String.Empty
    Private _Modulo As String = String.Empty
    Private _Glosa As String = String.Empty
    Private _Estado As String = String.Empty
    Private _Cod_Sistema As String = String.Empty
    Private _Cod_Grupo As String = String.Empty
    Private _Cod_Modulo As Integer = 0
    Private _Status As String = String.Empty
    Private _Usuario As String = String.Empty
    Private _Tipo As Short = 0

    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
            _ID = value
        End Set
    End Property

    Public Property Sistema() As String
        Get
            Return _Sistema
        End Get
        Set(ByVal value As String)
            _Sistema = value
        End Set
    End Property

    Public Property Grupo() As String
        Get
            Return _Grupo
        End Get
        Set(ByVal value As String)
            _Grupo = value
        End Set
    End Property

    Public Property Modulo() As String
        Get
            Return _Modulo
        End Get
        Set(ByVal value As String)
            _Modulo = value
        End Set
    End Property

    Public Property Glosa() As String
        Get
            Return _Glosa
        End Get
        Set(ByVal value As String)
            _Glosa = value
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

    Public Property Cod_Sistema() As String
        Get
            Return _Cod_Sistema
        End Get
        Set(ByVal value As String)
            _Cod_Sistema = value
        End Set
    End Property

    Public Property Cod_Grupo() As String
        Get
            Return _Cod_Grupo
        End Get
        Set(ByVal value As String)
            _Cod_Grupo = value
        End Set
    End Property

    Public Property Cod_Modulo() As Integer
        Get
            Return _Cod_Modulo
        End Get
        Set(ByVal value As Integer)
            _Cod_Modulo = value
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

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Tipo() As Short
        Get
            Return _Tipo
        End Get
        Set(ByVal value As Short)
            _Tipo = value
        End Set
    End Property


End Class
