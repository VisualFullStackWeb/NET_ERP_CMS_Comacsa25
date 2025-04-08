Public Class ETEmpleoLabor

#Region " Variables"

    Private _Cod_Cia As String = String.Empty
    Private _Cod_Area As String = String.Empty
    Private _Cod_Empleo As String = String.Empty
    Private _Estado As String = String.Empty
    Private _Cod_Tipo_Activo As String = String.Empty
    Private _User As String = String.Empty
    Private _Cod_Activo As String = String.Empty
    Private _Cod_Cantera As String = String.Empty
    Private _Cod_Linea As String = String.Empty
    Private _Cod_SubLinea As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Proveedor As String = String.Empty
    Private _Fecha As Date = Date.Today
    Private _FechaTermino As DateTime = Now
    Private _Anio As Integer = 0
    Public Property Cod_Activo() As String
        Get
            Return _Cod_Activo
        End Get
        Set(ByVal value As String)
            _Cod_Activo = value
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

    Public Property Cod_Area() As String
        Get
            Return _Cod_Area
        End Get
        Set(ByVal value As String)
            _Cod_Area = value
        End Set
    End Property

    Public Property Cod_Empleo() As String
        Get
            Return _Cod_Empleo
        End Get
        Set(ByVal value As String)
            _Cod_Empleo = value
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

    Public Property Cod_Tipo_Activo() As String
        Get
            Return _Cod_Tipo_Activo
        End Get
        Set(ByVal value As String)
            _Cod_Tipo_Activo = value
        End Set
    End Property

    Public Property User() As String
        Get
            Return _User
        End Get
        Set(ByVal value As String)
            _User = value
        End Set
    End Property

    Public Property Cod_Cantera() As String
        Get
            Return _Cod_Cantera
        End Get
        Set(ByVal value As String)
            _Cod_Cantera = value
        End Set
    End Property

    Public Property Cod_Linea() As String
        Get
            Return _Cod_Linea
        End Get
        Set(ByVal value As String)
            _Cod_Linea = value
        End Set
    End Property

    Public Property Cod_SubLinea() As String
        Get
            Return _Cod_SubLinea
        End Get
        Set(ByVal value As String)
            _Cod_SubLinea = value
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

    Public Property Cod_Prov() As String
        Get
            Return _Proveedor
        End Get
        Set(ByVal value As String)
            _Proveedor = value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property Anio() As Integer
        Get
            Return _Anio
        End Get
        Set(ByVal value As Integer)
            _Anio = value
        End Set
    End Property

    Public Property FechaTermino() As DateTime
        Get
            Return _FechaTermino
        End Get
        Set(ByVal value As DateTime)
            _FechaTermino = value
        End Set
    End Property
#End Region

End Class
