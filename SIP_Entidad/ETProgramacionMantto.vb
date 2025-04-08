Public Class ETProgramacionMantto
    Inherits ETObjecto
    Private _Codigo As String = String.Empty
    Private _Cod_Eq As String = String.Empty
    Private _Cod_Req As String = String.Empty
    Private _Equipo As String = String.Empty
    Private _Observaciones As String = String.Empty
    Private _Estado As String = String.Empty
    Private _Status As String = String.Empty
    Private _RequerimientoID As Long = 0
    Private _EquipoID As Long = 0
    Private _Req_Anterior As Long = 0
    Private _Equipo_Anterior As Long = 0
    Private _Programacion As Long = 0

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property Cod_Req() As String
        Get
            Return _Cod_Req
        End Get
        Set(ByVal value As String)
            _Cod_Req = value
        End Set
    End Property
    Public Property Cod_Eq() As String
        Get
            Return _Cod_Eq
        End Get
        Set(ByVal value As String)
            _Cod_Eq = value
        End Set
    End Property
    Public Property Equipo() As String
        Get
            Return _Equipo
        End Get
        Set(ByVal value As String)
            _Equipo = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return _Observaciones
        End Get
        Set(ByVal value As String)
            _Observaciones = value
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
    Public Property RequerimientoID() As Long
        Get
            Return _RequerimientoID
        End Get
        Set(ByVal value As Long)
            _RequerimientoID = value
        End Set
    End Property
    Public Property EquipoID() As Long
        Get
            Return _EquipoID
        End Get
        Set(ByVal value As Long)
            _EquipoID = value
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
    Public Property Req_Anterior() As Long
        Get
            Return _Req_Anterior
        End Get
        Set(ByVal value As Long)
            _Req_Anterior = value
        End Set
    End Property
    Public Property Equipo_Anterior() As Long
        Get
            Return _Equipo_Anterior
        End Get
        Set(ByVal value As Long)
            _Equipo_Anterior = value
        End Set
    End Property
    Public Property Programacion() As Long
        Get
            Return _Programacion
        End Get
        Set(ByVal value As Long)
            _Programacion = value
        End Set
    End Property
End Class
