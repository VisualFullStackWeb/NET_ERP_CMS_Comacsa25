Public Class HorarioObrero
    Private _codigoTrabajador As String = ""
    Private _codigoHorario As String = ""
    Private _tipoHorario As String = ""
    Private _fecha As Date
    Public Property codigoTrabajador() As String
        Get
            Return _codigoTrabajador
        End Get
        Set(ByVal value As String)
            _codigoTrabajador = value
        End Set
    End Property
    Public Property codigoHorario() As String
        Get
            Return _codigoHorario
        End Get
        Set(ByVal value As String)
            _codigoHorario = value
        End Set
    End Property
    Public Property tipoHorario() As String
        Get
            Return _tipoHorario
        End Get
        Set(ByVal value As String)
            _tipoHorario = value
        End Set
    End Property
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property
End Class
