Public Class ETLisMaestroDocumentosTecnicos

    Private _Codigo_Producto As String
    Private _Producto As String
    Private _Cod_DocTecnico As String
    Private _Cod_Cia As String
    Private _Nro_Requi As String
    Private _User_Crea As String
    Private _Estado As String
    Private _Item As Integer

    Public Property Item() As Integer
        Get
            Return _Item
        End Get
        Set(ByVal value As Integer)
            _Item = value
        End Set
    End Property


    Public Property Producto() As String
        Get
            Return _Producto
        End Get
        Set(ByVal value As String)
            _Producto = value
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

    Public Property Codigo_Producto() As String
        Get
            Return _Codigo_Producto
        End Get
        Set(ByVal value As String)
            _Codigo_Producto = value
        End Set
    End Property

    Public Property Cod_DocTecnico() As String
        Get
            Return _Cod_DocTecnico
        End Get
        Set(ByVal value As String)
            _Cod_DocTecnico = value
        End Set
    End Property

    Public Property Cod_Cia() As String
        Get
            Return _Cod_Cia
        End Get
        Set(ByVal value As String)
            _Cod_Cia = value
        End Set
    End Property

    Public Property Nro_Requi() As String
        Get
            Return _Nro_Requi
        End Get
        Set(ByVal value As String)
            _Nro_Requi = value
        End Set
    End Property

    Public Property User_Crea() As String
        Get
            Return _User_Crea
        End Get
        Set(ByVal value As String)
            _User_Crea = value
        End Set
    End Property

End Class