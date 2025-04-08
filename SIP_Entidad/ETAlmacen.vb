
Public Class ETAlmacen

    Inherits ETObjecto

    Private _CodUnidad As String = String.Empty
    Private _CodAlmacen As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Abrev As String = String.Empty


    Private _Cert_Inscrip As String
    Private _Cod_Chofer As String
    Private _Cod_Cia As String
    Private _Cod_Transp As String
    Private _Dni_Chofer As String
    Private _Dni_Destinatario As String
    Private _Enviado_a As String
    Private _Lic_Conducir As String
    Private _Login As String
    Private _Marca As String
    Private _Nom_Chofer As String
    Private _Num_Doc As String
    Private _Periodo As String
    Private _Placa As String
    Private _Raz_Soc As String
    Private _Ruc As String
    Private _Tipo_Doc As String
    Private _Tipo_Mov As String
    Private _User_Crea As String


    Public Property Cert_Inscrip() As String
        Get
            Return _Cert_Inscrip
        End Get
        Set(ByVal value As String)
            _Cert_Inscrip = value
        End Set
    End Property

    Public Property Cod_Chofer() As String
        Get
            Return _Cod_Chofer
        End Get
        Set(ByVal value As String)
            _Cod_Chofer = value
        End Set
    End Property

    Public Property Cod_Transp() As String
        Get
            Return _Cod_Transp
        End Get
        Set(ByVal value As String)
            _Cod_Transp = value
        End Set
    End Property

    Public Property Dni_Chofer() As String
        Get
            Return _Dni_Chofer
        End Get
        Set(ByVal value As String)
            _Dni_Chofer = value
        End Set
    End Property

    Public Property Dni_Destinatario() As String
        Get
            Return _Dni_Destinatario
        End Get
        Set(ByVal value As String)
            _Dni_Destinatario = value
        End Set
    End Property

    Public Property Enviado_a() As String
        Get
            Return _Enviado_a
        End Get
        Set(ByVal value As String)
            _Enviado_a = value
        End Set
    End Property

    Public Property Lic_Conducir() As String
        Get
            Return _Lic_Conducir
        End Get
        Set(ByVal value As String)
            _Lic_Conducir = value
        End Set
    End Property

    Public Property Marca() As String
        Get
            Return _Marca
        End Get
        Set(ByVal value As String)
            _Marca = value
        End Set
    End Property

    Public Property Nom_Chofer() As String
        Get
            Return _Nom_Chofer
        End Get
        Set(ByVal value As String)
            _Nom_Chofer = value
        End Set
    End Property

    Public Property Num_Doc() As String
        Get
            Return _Num_Doc
        End Get
        Set(ByVal value As String)
            _Num_Doc = value
        End Set
    End Property

    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property

    Public Property Raz_Soc() As String
        Get
            Return _Raz_Soc
        End Get
        Set(ByVal value As String)
            _Raz_Soc = value
        End Set
    End Property

    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property

    Public Property Tipo_Doc() As String
        Get
            Return _Tipo_Doc
        End Get
        Set(ByVal value As String)
            _Tipo_Doc = value
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


    Public Property Cod_Cia() As String
        Get
            Return _Cod_Cia
        End Get
        Set(ByVal value As String)
            _Cod_Cia = value
        End Set
    End Property

    Public Property Login() As String
        Get
            Return _Login
        End Get
        Set(ByVal value As String)
            _Login = value
        End Set
    End Property

    Public Overloads Property Periodo() As String
        Get
            Return _Periodo
        End Get
        Set(ByVal value As String)
            _Periodo = value
        End Set
    End Property

    Public Property Tipo_Mov() As String
        Get
            Return _Tipo_Mov
        End Get
        Set(ByVal value As String)
            _Tipo_Mov = value
        End Set
    End Property






    Public Property CodAlmacen() As String
        Get
            Return _CodAlmacen
        End Get
        Set(ByVal value As String)
            _CodAlmacen = value
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

    Public Property CodUnidad() As String
        Get
            Return _CodUnidad
        End Get
        Set(ByVal value As String)
            _CodUnidad = value
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

End Class
