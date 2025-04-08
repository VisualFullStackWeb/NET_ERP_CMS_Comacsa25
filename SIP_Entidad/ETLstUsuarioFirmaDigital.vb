Public Class ETLstUsuarioFirmaDigital
    Private _Area As String
    Private _AreaID As String
    Private _Aprobar As Boolean
    Private _Item As String
    Private _AprobarRequerimiento As Boolean

    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property

    Public Property AreaID() As String
        Get
            Return _AreaID
        End Get
        Set(ByVal value As String)
            _AreaID = value
        End Set
    End Property

    Public Property Aprobar() As String
        Get
            Return _Aprobar
        End Get
        Set(ByVal value As String)
            _Aprobar = value
        End Set
    End Property

    Public Property Item() As String
        Get
            Return _Item
        End Get
        Set(ByVal value As String)
            _Item = value
        End Set
    End Property

    Public Property AprobarRequerimiento() As Boolean
        Get
            Return _AprobarRequerimiento
        End Get
        Set(ByVal value As Boolean)
            _AprobarRequerimiento = value
        End Set
    End Property

End Class
