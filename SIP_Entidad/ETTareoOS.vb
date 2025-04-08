Public Class ETTareoOS
    Inherits ETObjecto
    Private _Cod_TareoOS As String = String.Empty
    Private _Cod_OT As String = String.Empty
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _HoraInicio As String = String.Empty
    Private _HoraFin As String = String.Empty
    Private _Horas As Double = 0
    Private _Status As String = String.Empty
    Private _Recurso As Long = 0
    Private _OrdenTrabajo As Long = 0
    Private _TareoOS As Long = 0
    Private _Area As String = String.Empty
    Private _Fecha1 As String = String.Empty
    Private _Fecha2 As String = String.Empty

    Public Property Cod_TareosOS() As String
        Get
            Return _Cod_TareoOS
        End Get
        Set(ByVal value As String)
            _Cod_TareoOS = value
        End Set
    End Property
    Public Property Cod_OT() As String
        Get
            Return _Cod_OT
        End Get
        Set(ByVal value As String)
            _Cod_OT = value
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
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property HoraInicio() As String
        Get
            Return _HoraInicio
        End Get
        Set(ByVal value As String)
            _HoraInicio = value
        End Set
    End Property
    Public Property HoraFin() As String
        Get
            Return _HoraFin
        End Get
        Set(ByVal value As String)
            _HoraFin = value
        End Set
    End Property
    Public Property Horas() As Double
        Get
            Return _Horas
        End Get
        Set(ByVal value As Double)
            _Horas = value
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
    Public Property Recurso() As Long
        Get
            Return _Recurso
        End Get
        Set(ByVal value As Long)
            _Recurso = value
        End Set
    End Property
    Public Property OrdenTrabajo() As Long
        Get
            Return _OrdenTrabajo
        End Get
        Set(ByVal value As Long)
            _OrdenTrabajo = value
        End Set
    End Property
    Public Property TareoOS() As Long
        Get
            Return _TareoOS
        End Get
        Set(ByVal value As Long)
            _TareoOS = value
        End Set
    End Property
    Public Property Area() As String
        Get
            Return _TareoOS
        End Get
        Set(ByVal value As String)
            _TareoOS = value
        End Set
    End Property
    Public Property Fecha1() As String
        Get
            Return _Fecha1
        End Get
        Set(ByVal value As String)
            _Fecha1 = value
        End Set
    End Property
    Public Property Fecha2() As String
        Get
            Return _Fecha2
        End Get
        Set(ByVal value As String)
            _Fecha2 = value
        End Set
    End Property
 
End Class
