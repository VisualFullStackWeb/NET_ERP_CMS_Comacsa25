Public Class ETUbigeos

    Private IdUbigeoSunatField As String
    Public Property IdUbigeoSunat() As String
        Get
            Return IdUbigeoSunatField
        End Get
        Set(ByVal value As String)
            IdUbigeoSunatField = value
        End Set
    End Property

    Private PaisField As String
    Public Property Pais() As String
        Get
            Return PaisField
        End Get
        Set(ByVal value As String)
            PaisField = value
        End Set
    End Property

    Private DepartamentoField As String
    Public Property Departamento() As String
        Get
            Return DepartamentoField
        End Get
        Set(ByVal value As String)
            DepartamentoField = value
        End Set
    End Property

    Private ProvinciaField As String
    Public Property Provincia() As String
        Get
            Return ProvinciaField
        End Get
        Set(ByVal value As String)
            ProvinciaField = value
        End Set
    End Property

    Private DistritoField As String
    Public Property Distrito() As String
        Get
            Return DistritoField
        End Get
        Set(ByVal value As String)
            DistritoField = value
        End Set
    End Property

    Private UbigeoField As String
    Public Property Ubigeo() As String
        Get
            Return UbigeoField
        End Get
        Set(ByVal value As String)
            UbigeoField = value
        End Set
    End Property

    Private DesUbigeoField As String
    Public Property DesUbigeo() As String
        Get
            DesUbigeoField = Me.PaisField + "-" + Me.DepartamentoField + "-" + Me.ProvinciaField + "-" + Me.DistritoField
            Return Me.DesUbigeoField
        End Get
        Set(ByVal value As String)
            DesUbigeoField = value
        End Set
    End Property

End Class
