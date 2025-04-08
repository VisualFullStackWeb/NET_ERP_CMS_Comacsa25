Public Class ETRequerimiento_ManttoDetalle
    Inherits ETObjecto
    Private _Codigo As String = String.Empty
    Private _Equipo As String = String.Empty
    Private _CheckList As String = String.Empty
    Private _Observacion As String = String.Empty
    Private _Estado As String = String.Empty
    Private _Status As String = String.Empty
    Private _EquipoID As Long = 0
    Private _CheckListID As Long = 0
    Private _Requerimiento As Long = 0
    Private _Programacion As String
    Private _ProgramacionID As Long = 0

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
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
    Public Property CheckList() As String
        Get
            Return _CheckList
        End Get
        Set(ByVal value As String)
            _CheckList = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
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
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
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
    Public Property CheckListID() As Long
        Get
            Return _CheckListID
        End Get
        Set(ByVal value As Long)
            _CheckListID = value
        End Set
    End Property
    Public Property Requerimiento() As Long
        Get
            Return _Requerimiento
        End Get
        Set(ByVal value As Long)
            _Requerimiento = value
        End Set
    End Property
    Public Property Programacion() As String
        Get
            Return _Programacion
        End Get
        Set(ByVal value As String)
            _Programacion = value
        End Set
    End Property
    Public Property ProgramacionID() As Long
        Get
            Return _ProgramacionID
        End Get
        Set(ByVal value As Long)
            _ProgramacionID = value
        End Set
    End Property
End Class
