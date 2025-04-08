Public Class ETUsuario

    Inherits ETObjecto

    Private _Usuario As String = String.Empty
    Private _Contrasenha As String = String.Empty
    Private _Tipo As Short = 0
    Private _Formulario As String = String.Empty
    Private _Operacion As String = String.Empty
    Private _Encargado As String = String.Empty
    Private _Email As String = String.Empty
    Private _Estado As String = String.Empty
    Private _Status As Char = Char.MinValue
    Private _Grupo As String = String.Empty
    Private _KeyForm As String = String.Empty
    Private _KeyOpe As String = String.Empty
    Private _Action As Boolean = Boolean.FalseString
    Private _IDSistema As String = String.Empty
    Private _IDGrupo As String = String.Empty
    Private _Sistema As String = String.Empty
    Private _Name_User As String = String.Empty
    Private _Jerarquia As Int32 = 0

    Private _Cod_Cia As String
    Private _Login As String
    Private _Admin As String
    Private _TipoPla As String
    Private _Cargo As String
    Private _Permisos As String
    Private _SegunClave As String
    Private _Iniciales As String
    Private _PrintFla As Boolean
    Private _PlaCod As String
    Private _Oc_Minas As Boolean
    Private _Vi_Stkm As Boolean
    Private _User_Crea As String
    Private _Area As String
    Private _Firma As Byte()
    Private _Opcion As String
    Private _Cod_Almacen As String
    Private _AprobPedido As String
    Private _VerPedidoxArea As String
    Private _ActionArea As String

    Public Property ActionArea() As String
        Get
            Return _ActionArea
        End Get
        Set(ByVal value As String)
            _ActionArea = value
        End Set
    End Property

    Public Property VerPedidoxArea() As String
        Get
            Return _VerPedidoxArea
        End Get
        Set(ByVal value As String)
            _VerPedidoxArea = value
        End Set
    End Property

    Public Property AprobPedido() As String
        Get
            Return _AprobPedido
        End Get
        Set(ByVal value As String)
            _AprobPedido = value
        End Set
    End Property

    Public Property IDSistema() As String
        Get
            Return _IDSistema
        End Get
        Set(ByVal value As String)
            _IDSistema = value
        End Set
    End Property

    Public Property IDGrupo() As String
        Get
            Return _IDGrupo
        End Get
        Set(ByVal value As String)
            _IDGrupo = value
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

    Public Property Admin() As String
        Get
            Return _Admin
        End Get
        Set(ByVal value As String)
            _Admin = value
        End Set
    End Property

    Public Property TipoPla() As String
        Get
            Return _TipoPla
        End Get
        Set(ByVal value As String)
            _TipoPla = value
        End Set
    End Property

    Public Property Cargo() As String
        Get
            Return _Cargo
        End Get
        Set(ByVal value As String)
            _Cargo = value
        End Set
    End Property

    Public Property Permisos() As String
        Get
            Return _Permisos
        End Get
        Set(ByVal value As String)
            _Permisos = value
        End Set
    End Property

    Public Property SegunClave() As String
        Get
            Return _SegunClave
        End Get
        Set(ByVal value As String)
            _SegunClave = value
        End Set
    End Property


    Public Property Iniciales() As String
        Get
            Return _Iniciales
        End Get
        Set(ByVal value As String)
            _Iniciales = value
        End Set
    End Property


    Public Property PrintFla() As Boolean
        Get
            Return _PrintFla
        End Get
        Set(ByVal value As Boolean)
            _PrintFla = value
        End Set
    End Property


    Public Property PlaCod() As String
        Get
            Return _PlaCod
        End Get
        Set(ByVal value As String)
            _PlaCod = value
        End Set
    End Property


    Public Property Oc_Minas() As Boolean
        Get
            Return _Oc_Minas
        End Get
        Set(ByVal value As Boolean)
            _Oc_Minas = value
        End Set
    End Property


    Public Property Vi_Stkm() As Boolean
        Get
            Return _Vi_Stkm
        End Get
        Set(ByVal value As Boolean)
            _Vi_Stkm = value
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


    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property


    Public Property Firma() As Byte()
        Get
            Return _Firma
        End Get
        Set(ByVal value As Byte())
            _Firma = value
        End Set
    End Property


    Public Property Opcion() As String
        Get
            Return _Opcion
        End Get
        Set(ByVal value As String)
            _Opcion = value
        End Set
    End Property


    Public Property Cod_Almacen() As String
        Get
            Return _Cod_Almacen
        End Get
        Set(ByVal value As String)
            _Cod_Almacen = value
        End Set
    End Property

    Public Overloads Property Sistema() As String
        Get
            Return _Sistema
        End Get
        Set(ByVal value As String)
            _Sistema = value
        End Set
    End Property

    Public Property Name_User() As String
        Get
            Return _Name_User
        End Get
        Set(ByVal value As String)
            _Name_User = value
        End Set
    End Property


    Public Overloads Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Contrasenha() As String
        Get
            Return _Contrasenha
        End Get
        Set(ByVal value As String)
            _Contrasenha = value
        End Set
    End Property

    Public Property KeyForm() As String
        Get
            Return _KeyForm
        End Get
        Set(ByVal value As String)
            _KeyForm = value
        End Set
    End Property

    Public Property KeyOpe() As String
        Get
            Return _KeyOpe
        End Get
        Set(ByVal value As String)
            _KeyOpe = value
        End Set
    End Property

    Public Property Action() As Boolean
        Get
            Return _Action
        End Get
        Set(ByVal value As Boolean)
            _Action = value
        End Set
    End Property

    Public Overloads Property Tipo() As Short
        Get
            Return _Tipo
        End Get
        Set(ByVal value As Short)
            _Tipo = value
        End Set
    End Property

    Public Property Jerarquia() As Int32
        Get
            Return _Jerarquia
        End Get
        Set(ByVal value As Int32)
            _Jerarquia = value
        End Set
    End Property



    Public Property Formulario() As String
        Get
            Return _Formulario
        End Get
        Set(ByVal value As String)
            _Formulario = value
        End Set
    End Property

    Public Overloads Property Operacion() As String
        Get
            Return _Operacion
        End Get
        Set(ByVal value As String)
            _Operacion = value
        End Set
    End Property

    Public Property Encargado() As String
        Get
            Return _Encargado
        End Get
        Set(ByVal value As String)
            _Encargado = value
        End Set
    End Property

    Public Overloads Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
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

    Public Property Status() As Char
        Get
            Return _Status
        End Get
        Set(ByVal value As Char)
            _Status = value
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

End Class
