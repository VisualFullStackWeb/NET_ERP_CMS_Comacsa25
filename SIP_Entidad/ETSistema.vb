Public Class ETSistema
    Private _Action As Boolean = Boolean.FalseString
    Private _ID As String = String.Empty
    Private _Sistema As String = String.Empty
    Private _Abrev As String = String.Empty
    Private _Grupo As String = String.Empty
    Private _Status As String = String.Empty
    Private _Usuario As String = String.Empty
    Private _Tipo As Short = 0

    Public Property Action() As Boolean
        Get
            Return _Action
        End Get
        Set(ByVal value As Boolean)
            _Action = value
        End Set
    End Property

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

    Public Property Abrev() As String
        Get
            Return _Abrev
        End Get
        Set(ByVal value As String)
            _Abrev = value
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
