Public Class ETOrdenTrabajo_Mantto
    Inherits ETObjecto

    
    Private _Abrev As String = String.Empty
    Private _Codigo As String = String.Empty
    Private _Cod_Presp As String = String.Empty
    Private _OTOrigen As String = String.Empty
    Private _EncargadoArea As String = String.Empty
    Private _TipoCliente As Boolean = Boolean.FalseString
    Private _Cliente As String = String.Empty
    Private _RUC As String = String.Empty
    Private _AreaInterna As String = String.Empty
    Private _Equipo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _TipoMantto As String = String.Empty
    Private _Atributo As String = String.Empty
    Private _ValorControl As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _Prioridad As String = String.Empty
    Private _Requerimiento As String = String.Empty
    Private _Programacion As String = String.Empty
    Private _Moneda As String = String.Empty
    Private _CostoPresup As Double = 0
    Private _CostoMaterial As Double = 0
    Private _CostoEquipos As Double = 0
    Private _CostoManoObra As Double = 0
    Private _CostoServicios As Double = 0
    Private _CostoBackLog As Double = 0
    Private _CostoTotal As Double = 0
    Private _Estado As String = String.Empty

    Private _Area As String = String.Empty
    Private _Presupuesto As Long = 0
    Private _Cod_EncargadoArea As String = String.Empty
    Private _EncargadoAreaID As Long = 0
    Private _Cod_Cli As String = String.Empty
    Private _Cod_CliInterno As String = String.Empty
    Private _Cod_AreaInt As String = String.Empty
    Private _EquipoID As Long = 0
    Private _TipoProceso As String = String.Empty
    Private _AtributoControl As Long = 0
    Private _Cod_UniMed As String = String.Empty
    Private _TipoDato As String = String.Empty
    Private _Longitud As Short = 0
    Private _Decimales As Short = 0
    Private _Cod_Prioridad As String = String.Empty
    Private _Cod_Requerimiento As Long = 0
    Private _Cod_Programacion As Long = 0
    Private _Status As String = "P"
    Private _OrdenTrabajoOrigen As Long = 0
    Private _OrdenTrabajo As Long = 0

    Private _FechaInicioOTO As Date = Date.Today
    Private _FechaTerminoOTO As Date = Date.Today

    Public Property Abrev() As String
        Get
            Return _Abrev
        End Get
        Set(ByVal value As String)
            _Abrev = value
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

    Public Property Cod_Presp() As String
        Get
            Return _Cod_Presp
        End Get
        Set(ByVal value As String)
            _Cod_Presp = value
        End Set
    End Property

    Public Property OTOrigen() As String
        Get
            Return _OTOrigen
        End Get
        Set(ByVal value As String)
            _OTOrigen = value
        End Set
    End Property

    Public Property EncargadoArea() As String
        Get
            Return _EncargadoArea
        End Get
        Set(ByVal value As String)
            _EncargadoArea = value
        End Set
    End Property

    Public Property TipoCliente() As Boolean
        Get
            Return _TipoCliente
        End Get
        Set(ByVal value As Boolean)
            _TipoCliente = value
        End Set
    End Property

    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

    Public Property RUC() As String
        Get
            Return _RUC
        End Get
        Set(ByVal value As String)
            _RUC = value
        End Set
    End Property

    Public Property AreaInterna() As String
        Get
            Return _AreaInterna
        End Get
        Set(ByVal value As String)
            _AreaInterna = value
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

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property TipoMantto() As String
        Get
            Return _TipoMantto
        End Get
        Set(ByVal value As String)
            _TipoMantto = value
        End Set
    End Property

    Public Property Atributo() As String
        Get
            Return _Atributo
        End Get
        Set(ByVal value As String)
            _Atributo = value
        End Set
    End Property

    Public Property ValorControl() As String
        Get
            Return _ValorControl
        End Get
        Set(ByVal value As String)
            _ValorControl = value
        End Set
    End Property

    Public Property UniMed() As String
        Get
            Return _UniMed
        End Get
        Set(ByVal value As String)
            _UniMed = value
        End Set
    End Property

    Public Property Prioridad() As String
        Get
            Return _Prioridad
        End Get
        Set(ByVal value As String)
            _Prioridad = value
        End Set
    End Property

    Public Property Requerimiento() As String
        Get
            Return _Requerimiento
        End Get
        Set(ByVal value As String)
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

    Public Property Moneda() As String
        Get
            Return _Moneda
        End Get
        Set(ByVal value As String)
            _Moneda = value
        End Set
    End Property

    Public Property CostoPresup() As Double
        Get
            Return _CostoPresup
        End Get
        Set(ByVal value As Double)
            _CostoPresup = value
        End Set
    End Property

    Public Property CostoMaterial() As Double
        Get
            Return _CostoMaterial
        End Get
        Set(ByVal value As Double)
            _CostoMaterial = value
        End Set
    End Property

    Public Property CostoEquipos() As Double
        Get
            Return _CostoEquipos
        End Get
        Set(ByVal value As Double)
            _CostoEquipos = value
        End Set
    End Property

    Public Property CostoManoObra() As Double
        Get
            Return _CostoManoObra
        End Get
        Set(ByVal value As Double)
            _CostoManoObra = value
        End Set
    End Property

    Public Property CostoServicios() As Double
        Get
            Return _CostoServicios
        End Get
        Set(ByVal value As Double)
            _CostoServicios = value
        End Set
    End Property

    Public Property CostoBackLog() As Double
        Get
            Return _CostoBackLog
        End Get
        Set(ByVal value As Double)
            _CostoBackLog = value
        End Set
    End Property

    Public Property CostoTotal() As Double
        Get
            Return _CostoTotal
        End Get
        Set(ByVal value As Double)
            _CostoTotal = value
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

    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property

    Public Property Presupuesto() As Long
        Get
            Return _Presupuesto
        End Get
        Set(ByVal value As Long)
            _Presupuesto = value
        End Set
    End Property

    Public Property Cod_EncargadoArea() As String
        Get
            Return _Cod_EncargadoArea
        End Get
        Set(ByVal value As String)
            _Cod_EncargadoArea = value
        End Set
    End Property

    Public Property EncargadoAreaID() As Long
        Get
            Return _EncargadoAreaID
        End Get
        Set(ByVal value As Long)
            _EncargadoAreaID = value
        End Set
    End Property

    Public Property Cod_Cli() As String
        Get
            Return _Cod_Cli
        End Get
        Set(ByVal value As String)
            _Cod_Cli = value
        End Set
    End Property

    Public Property Cod_CliInterno() As String
        Get
            Return _Cod_CliInterno
        End Get
        Set(ByVal value As String)
            _Cod_CliInterno = value
        End Set
    End Property

    Public Property Cod_AreaInt() As String
        Get
            Return _Cod_AreaInt
        End Get
        Set(ByVal value As String)
            _Cod_AreaInt = value
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

    Public Property TipoProceso() As String
        Get
            Return _TipoProceso
        End Get
        Set(ByVal value As String)
            _TipoProceso = value
        End Set
    End Property

    Public Property AtributoControl() As Long
        Get
            Return _AtributoControl
        End Get
        Set(ByVal value As Long)
            _AtributoControl = value
        End Set
    End Property

    Public Property Cod_UniMed() As String
        Get
            Return _Cod_UniMed
        End Get
        Set(ByVal value As String)
            _Cod_UniMed = value
        End Set
    End Property

    Public Property TipoDato() As String
        Get
            Return _TipoDato
        End Get
        Set(ByVal value As String)
            _TipoDato = value
        End Set
    End Property

    Public Property Longitud() As Short
        Get
            Return _Longitud
        End Get
        Set(ByVal value As Short)
            _Longitud = value
        End Set
    End Property

    Public Property Decimales() As Short
        Get
            Return _Decimales
        End Get
        Set(ByVal value As Short)
            _Decimales = value
        End Set
    End Property

    Public Property Cod_Prioridad() As String
        Get
            Return _Cod_Prioridad
        End Get
        Set(ByVal value As String)
            _Cod_Prioridad = value
        End Set
    End Property

    Public Property Cod_Requerimiento() As Long
        Get
            Return _Cod_Requerimiento
        End Get
        Set(ByVal value As Long)
            _Cod_Requerimiento = value
        End Set
    End Property

    Public Property Cod_Programacion() As Long
        Get
            Return _Cod_Programacion
        End Get
        Set(ByVal value As Long)
            _Cod_Programacion = value
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

    Public Property OrdenTrabajoOrigen() As Long
        Get
            Return _OrdenTrabajoOrigen
        End Get
        Set(ByVal value As Long)
            _OrdenTrabajoOrigen = value
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

    Public Property FechaInicioOTO()
        Get
            Return _FechaInicioOTO
        End Get
        Set(ByVal value)
            _FechaInicioOTO = value
        End Set
    End Property

    Public Property FechaTerminoOTO()
        Get
            Return _FechaTerminoOTO
        End Get
        Set(ByVal value)
            _FechaTerminoOTO = value
        End Set
    End Property
End Class
