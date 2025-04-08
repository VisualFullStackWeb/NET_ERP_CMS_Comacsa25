Imports System.Configuration
Public Class ETAreaEmpleado
    Private _Cod_Cia As String = String.Empty
    Private _Compania As String = String.Empty
    Private _Codigo As String = String.Empty
    Private _Area As String = String.Empty
    Private _Cod_Emp As String = String.Empty
    Private _ApePaterno As String = String.Empty
    Private _ApeMaterno As String = String.Empty
    Private _Nombres As String = String.Empty
    Private _FechaInicio As Date = Date.Today
    Private _FechaTermino As Date = Date.Today
    Private _FechaInicioTxt As String = String.Empty
    Private _FechaTerminoTxt As String = String.Empty
    Private _Status As String = String.Empty
    Private _Tipo As String = String.Empty
    Private _Usuario As String = Compania
    Private _AreaEmpleado As Long = 0

    Public Property Cia() As String
        Get
            Return _Cod_Cia
        End Get
        Set(ByVal value As String)
            _Cod_Cia = value
        End Set
    End Property
    Public Property Compania() As String
        Get
            Return _Compania
        End Get
        Set(ByVal value As String)
            _Compania = value
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
    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property
    Public Property Cod_Emp() As String
        Get
            Return _Cod_Emp
        End Get
        Set(ByVal value As String)
            _Cod_Emp = value
        End Set
    End Property
    Public Property ApePaterno() As String
        Get
            Return _ApePaterno
        End Get
        Set(ByVal value As String)
            _ApePaterno = value
        End Set
    End Property
    Public Property ApeMaterno() As String
        Get
            Return _ApeMaterno
        End Get
        Set(ByVal value As String)
            _ApeMaterno = value
        End Set
    End Property
    Public Property Nombres() As String
        Get
            Return _Nombres
        End Get
        Set(ByVal value As String)
            _Nombres = value
        End Set
    End Property
    Public Property FechaInicio() As Date
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As Date)
            _FechaInicio = value
        End Set
    End Property
    Public Property FechaTermino() As Date
        Get
            Return _FechaTermino
        End Get
        Set(ByVal value As Date)
            _FechaTermino = value
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
    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
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
    Public Property AreaEmpleado() As Long
        Get
            Return _AreaEmpleado
        End Get
        Set(ByVal value As Long)
            _AreaEmpleado = value
        End Set
    End Property
    Public Property FechaInicioTxt() As String
        Get
            Return _FechaInicioTxt
        End Get
        Set(ByVal value As String)
            _FechaInicioTxt = value
        End Set
    End Property
    Public Property FechaTerminoTxt() As String
        Get
            Return _FechaTerminoTxt
        End Get
        Set(ByVal value As String)
            _FechaTerminoTxt = value
        End Set
    End Property
End Class
