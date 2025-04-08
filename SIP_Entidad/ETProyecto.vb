Public Class ETProyecto
    Inherits ETObjecto
    Dim _ayo As Int32
    Dim _mes As Int32
    Dim _horas As Double
    Dim _desc_tarea As String
    Dim _idplano As String
    Dim _idsubtarea As Int32
    Dim _subtarea As String
    Dim _idproyecto As Int32
    Dim _idtaller As String
    Dim _idequipo As Int32
    Dim _ejecucion As Int32
    Dim _fechaini As Date
    Dim _idplanificacion As Int32
    Dim _idtarea As Int32
    Dim _idplanificacion_tarea As Int32
    Dim _plano As String
    Dim _idplanificacion_plano As Int32
    Dim _codprod As String
    Dim _idsubpersonal As Int32
    Dim _idsubmaterial As Int32
    Dim _idsubservicio As Int32
    Dim _idplanisubtarea As Int32
    Dim _placod As String
    Dim _precio As Double
    Dim _precioestimado As Double
    Dim _cantidad As Double
    Dim _nota As String
    Dim _cierre As Int32
    Dim _personal As String
    Dim _flgpersonal As Int32
    Dim _flgmaterial As Int32
    Dim _flgservicio As Int32
    Dim _avance As Double

    Public Property avance() As Double
        Get
            Return _avance
        End Get
        Set(ByVal value As Double)
            _avance = value
        End Set
    End Property

    Public Property flgpersonal() As Int32
        Get
            Return _flgpersonal
        End Get
        Set(ByVal value As Int32)
            _flgpersonal = value
        End Set
    End Property

    Public Property flgmaterial() As Int32
        Get
            Return _flgmaterial
        End Get
        Set(ByVal value As Int32)
            _flgmaterial = value
        End Set
    End Property

    Public Property flgservicio() As Int32
        Get
            Return _flgservicio
        End Get
        Set(ByVal value As Int32)
            _flgservicio = value
        End Set
    End Property

    Public Property personal() As String
        Get
            Return _personal
        End Get
        Set(ByVal value As String)
            _personal = value
        End Set
    End Property

    Public Property cierre() As Int32
        Get
            Return _cierre
        End Get
        Set(ByVal value As Int32)
            _cierre = value
        End Set
    End Property

    Public Property nota() As String
        Get
            Return _nota
        End Get
        Set(ByVal value As String)
            _nota = value
        End Set
    End Property

    Public Property idsubmaterial() As Int32
        Get
            Return _idsubmaterial
        End Get
        Set(ByVal value As Int32)
            _idsubmaterial = value
        End Set
    End Property

    Public Property idsubservicio() As Int32
        Get
            Return _idsubservicio
        End Get
        Set(ByVal value As Int32)
            _idsubservicio = value
        End Set
    End Property

    Public Property precioestimado() As Double
        Get
            Return _precioestimado
        End Get
        Set(ByVal value As Double)
            _precioestimado = value
        End Set
    End Property

    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property

    Public Property placod() As String
        Get
            Return _placod
        End Get
        Set(ByVal value As String)
            _placod = value
        End Set
    End Property

    Public Property idplanisubtarea() As Int32
        Get
            Return _idplanisubtarea
        End Get
        Set(ByVal value As Int32)
            _idplanisubtarea = value
        End Set
    End Property

    Public Property idsubpersonal() As Int32
        Get
            Return _idsubpersonal
        End Get
        Set(ByVal value As Int32)
            _idsubpersonal = value
        End Set
    End Property

    Public Property codprod() As String
        Get
            Return _codprod
        End Get
        Set(ByVal value As String)
            _codprod = value
        End Set
    End Property

    Public Property idplanificacion_plano() As Int32
        Get
            Return _idplanificacion_plano
        End Get
        Set(ByVal value As Int32)
            _idplanificacion_plano = value
        End Set
    End Property

    Public Property plano() As String
        Get
            Return _plano
        End Get
        Set(ByVal value As String)
            _plano = value
        End Set
    End Property

    Public Property idplanificacion_tarea() As Int32
        Get
            Return _idplanificacion_tarea
        End Get
        Set(ByVal value As Int32)
            _idplanificacion_tarea = value
        End Set
    End Property

    Public Property idtarea() As Int32
        Get
            Return _idtarea
        End Get
        Set(ByVal value As Int32)
            _idtarea = value
        End Set
    End Property

    Public Property idplanificacion() As Int32
        Get
            Return _idplanificacion
        End Get
        Set(ByVal value As Int32)
            _idplanificacion = value
        End Set
    End Property

    Public Property fechaini() As Date
        Get
            Return _fechaini
        End Get
        Set(ByVal value As Date)
            _fechaini = value
        End Set
    End Property

    Public Property subtarea() As String
        Get
            Return _subtarea
        End Get
        Set(ByVal value As String)
            _subtarea = value
        End Set
    End Property

    Public Property ejecucion() As Int32
        Get
            Return _ejecucion
        End Get
        Set(ByVal value As Int32)
            _ejecucion = value
        End Set
    End Property

    Public Property idproyecto() As Int32
        Get
            Return _idproyecto
        End Get
        Set(ByVal value As Int32)
            _idproyecto = value
        End Set
    End Property

    Public Property idtaller() As String
        Get
            Return _idtaller
        End Get
        Set(ByVal value As String)
            _idtaller = value
        End Set
    End Property

    Public Property idequipo() As Int32
        Get
            Return _idequipo
        End Get
        Set(ByVal value As Int32)
            _idequipo = value
        End Set
    End Property

    Public Property idsubtarea() As Int32
        Get
            Return _idsubtarea
        End Get
        Set(ByVal value As Int32)
            _idsubtarea = value
        End Set
    End Property

    Public Property idplano() As String
        Get
            Return _idplano
        End Get
        Set(ByVal value As String)
            _idplano = value
        End Set
    End Property

    Public Property desc_tarea() As String
        Get
            Return _desc_tarea
        End Get
        Set(ByVal value As String)
            _desc_tarea = value
        End Set
    End Property

    Public Property ayo() As Int32
        Get
            Return _ayo
        End Get
        Set(ByVal value As Int32)
            _ayo = value
        End Set
    End Property

    Public Overloads Property mes() As Int32
        Get
            Return _mes
        End Get
        Set(ByVal value As Int32)
            _mes = value
        End Set
    End Property

    Public Property horas() As Double
        Get
            Return _horas
        End Get
        Set(ByVal value As Double)
            _horas = value
        End Set
    End Property

End Class
