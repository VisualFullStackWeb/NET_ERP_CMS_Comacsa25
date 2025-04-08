Public Class ETCanteraCosteo

#Region " Variables"
    Private _ID As String = String.Empty
    Private _CodCia As String = String.Empty
    Private _CodEmpleado As String = String.Empty
    Private _Empleado As String = String.Empty
    Private _Ubigeo As String = String.Empty
    Private _DescripcionUbigeo As String = String.Empty
    Private _CodigoCantera As String = String.Empty
    Private _Cantera As String = String.Empty
    Private _Fecha As DateTime = DateTime.MinValue
    Private _FechaInicio As DateTime = DateTime.MinValue
    Private _FechaFin As DateTime = Now
    Private _NroDias As Integer
    Private _Motivo As String = String.Empty
    Private _CodArea As String = String.Empty
    Private _Opcion As Integer
    Private _User As String = String.Empty
    Private _Cod_Equipo As String = String.Empty
    Private _NombreEquipo As String = String.Empty
    Private _Tipo As String = String.Empty
    Private _NombreTipo As String = String.Empty
    Private _Mes As Integer
    Private _Ano As Integer
    Private _MesFin As Integer
    Private _AnoFin As Integer
    Private _TipoCantera As String = "A"
    Private _TipoCosto As String = "T"
    Private _Chk As String = String.Empty
    Private _Moneda As String = String.Empty
    Private _Importe As Decimal = 0
    Private _Importe2 As Decimal = 0
    Private _Importe3 As Decimal = 0
    Private _CodProd As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _UM As String = String.Empty
    Private _Linea As String = String.Empty
    Private _SubLinea As String = String.Empty
    Private _Action As Boolean
    Private _Periodo As String = String.Empty
    Private _NumeroPeriodo As Decimal
    Private _Hora As Decimal
    Private _Movimiento As String = String.Empty
    Private _CodigoProveedor As String = String.Empty
    Private _Proveedor As String = String.Empty
    Private _CodigoMineral As String = String.Empty
    Private _Mineral As String = String.Empty
    Private _Archivo1 As String = String.Empty
    Private _Archivo2 As String = String.Empty
    Private _Archivo3 As String = String.Empty
    Private _TipoTrabajo As String = String.Empty
    Private _DescripTipoTrabajo As String = String.Empty
    Private _TipoPerMin As String = String.Empty
    Private _DescripTipoPerMin As String = String.Empty
    Private _Glosa As String = String.Empty
    Private _MesName As String = String.Empty
    Private _Cantidad As Double = 0
    Private _Cod_Glosa As Integer = 0
    Private _Porcentaje As Double = 0
    Private _Status As String = String.Empty
    Private _Tercero As Boolean = True
    Private _NombreTipoTrabajo As String = String.Empty
    Private _Esquema As String = String.Empty
    Private _ID_Castigo As String = String.Empty
    Private _DT_Lista As DataTable = Nothing
    Private _check As Int32 = 0
    Private _codruma As String = String.Empty
    Private _codagrupacion As String = String.Empty
#End Region

#Region " Propiedades"

    Public Property codagrupacion() As String
        Get
            Return _codagrupacion
        End Get
        Set(ByVal value As String)
            _codagrupacion = value
        End Set
    End Property

    Public Property codruma() As String
        Get
            Return _codruma
        End Get
        Set(ByVal value As String)
            _codruma = value
        End Set
    End Property

    Public Property check() As Int32
        Get
            Return _check
        End Get
        Set(ByVal value As Int32)
            _check = value
        End Set
    End Property
    Public Property DT_Lista() As DataTable
        Get
            Return _DT_Lista
        End Get
        Set(ByVal value As DataTable)
            _DT_Lista = value
        End Set
    End Property

    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal Value As String)
            _ID = Value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal value As DateTime)
            _Fecha = value
        End Set
    End Property

    Public Property CodCia() As String
        Get
            Return _CodCia
        End Get
        Set(ByVal value As String)
            _CodCia = value
        End Set
    End Property

    Public Property CodEmpleado() As String
        Get
            Return _CodEmpleado
        End Get
        Set(ByVal Value As String)
            _CodEmpleado = Value
        End Set
    End Property

    Public Property Empleado() As String
        Get
            Return _Empleado
        End Get
        Set(ByVal value As String)
            _Empleado = value
        End Set
    End Property

    Public Property DescripcionUbigeo() As String
        Get
            Return _DescripcionUbigeo
        End Get
        Set(ByVal value As String)
            _DescripcionUbigeo = value
        End Set
    End Property

    Public Property Ubigeo() As String
        Get
            Return _Ubigeo
        End Get
        Set(ByVal Value As String)
            _Ubigeo = Value
        End Set
    End Property

    Public Property CodigoCantera() As String
        Get
            Return _CodigoCantera
        End Get
        Set(ByVal value As String)
            _CodigoCantera = value
        End Set
    End Property

    Public Property Cantera() As String
        Get
            Return _Cantera
        End Get
        Set(ByVal Value As String)
            _Cantera = Value
        End Set
    End Property

    Public Property FechaInicio() As DateTime
        Get
            Return _FechaInicio
        End Get
        Set(ByVal Value As DateTime)
            _FechaInicio = Value
        End Set
    End Property

    Public Property FechaFin() As DateTime
        Get
            Return _FechaFin
        End Get
        Set(ByVal Value As DateTime)
            _FechaFin = Value
        End Set
    End Property

    Public Property NroDias() As Integer
        Get
            Return _NroDias
        End Get
        Set(ByVal Value As Integer)
            _NroDias = Value
        End Set
    End Property

    Public Property Motivo() As String
        Get
            Return _Motivo
        End Get
        Set(ByVal Value As String)
            _Motivo = Value
        End Set
    End Property

    Public Property CodArea() As String
        Get
            Return _CodArea
        End Get
        Set(ByVal Value As String)
            _CodArea = Value
        End Set
    End Property

    Public Property Opcion() As Integer
        Get
            Return _Opcion
        End Get
        Set(ByVal value As Integer)
            _Opcion = value
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

    Public Property Cod_Equipo() As String
        Get
            Return _Cod_Equipo
        End Get
        Set(ByVal value As String)
            _Cod_Equipo = value
        End Set
    End Property

    Public Property NombreEquipo() As String
        Get
            Return _NombreEquipo
        End Get
        Set(ByVal value As String)
            _NombreEquipo = value
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

    Public Property NombreTipo() As String
        Get
            Return _NombreTipo
        End Get
        Set(ByVal value As String)
            _NombreTipo = value
        End Set
    End Property


    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal value As Integer)
            _Mes = value
        End Set
    End Property

    Public Property Ano() As Integer
        Get
            Return _Ano
        End Get
        Set(ByVal value As Integer)
            _Ano = value
        End Set
    End Property

    Public Property Chk() As String
        Get
            Return _Chk
        End Get
        Set(ByVal value As String)
            _Chk = value
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

    Public Property Importe() As Decimal
        Get
            Return _Importe
        End Get
        Set(ByVal value As Decimal)
            _Importe = value
        End Set
    End Property

    Public Property CodProd() As String
        Get
            Return _CodProd
        End Get
        Set(ByVal value As String)
            _CodProd = value
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

    Public Property UM() As String
        Get
            Return _UM
        End Get
        Set(ByVal value As String)
            _UM = value
        End Set
    End Property

    Public Property Linea() As String
        Get
            Return _Linea
        End Get
        Set(ByVal value As String)
            _Linea = value
        End Set
    End Property

    Public Property SubLinea() As String
        Get
            Return _SubLinea
        End Get
        Set(ByVal value As String)
            _SubLinea = value
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

    Public Property Periodo() As String
        Get
            Return _Periodo
        End Get
        Set(ByVal value As String)
            _Periodo = value
        End Set
    End Property

    Public Property NumeroPeriodo() As Decimal
        Get
            Return _NumeroPeriodo
        End Get
        Set(ByVal value As Decimal)
            _NumeroPeriodo = value
        End Set
    End Property

    Public Property Hora() As Decimal
        Get
            Return _Hora
        End Get
        Set(ByVal value As Decimal)
            _Hora = value
        End Set
    End Property

    Public Property Movimiento() As String
        Get
            Return _Movimiento
        End Get
        Set(ByVal value As String)
            _Movimiento = value
        End Set
    End Property

    Public Property CodigoProveedor() As String
        Get
            Return _CodigoProveedor
        End Get
        Set(ByVal value As String)
            _CodigoProveedor = value
        End Set
    End Property

    Public Property Proveedor() As String
        Get
            Return _Proveedor
        End Get
        Set(ByVal value As String)
            _Proveedor = value
        End Set
    End Property

    Public Property CodigoMineral() As String
        Get
            Return _CodigoMineral
        End Get
        Set(ByVal value As String)
            _CodigoMineral = value
        End Set
    End Property

    Public Property Mineral() As String
        Get
            Return _Mineral
        End Get
        Set(ByVal value As String)
            _Mineral = value
        End Set
    End Property
    Public Property Archivo1() As String
        Get
            Return _Archivo1
        End Get
        Set(ByVal value As String)
            _Archivo1 = value
        End Set
    End Property

    Public Property Archivo2() As String
        Get
            Return _Archivo2
        End Get
        Set(ByVal value As String)
            _Archivo2 = value
        End Set
    End Property

    Public Property Archivo3() As String
        Get
            Return _Archivo3
        End Get
        Set(ByVal value As String)
            _Archivo3 = value
        End Set
    End Property

    Public Property TipoTrabajo() As String
        Get
            Return _TipoTrabajo
        End Get
        Set(ByVal value As String)
            _TipoTrabajo = value
        End Set
    End Property

    Public Property DescripTipoTrabajo() As String
        Get
            Return _DescripTipoTrabajo
        End Get
        Set(ByVal value As String)
            _DescripTipoTrabajo = value
        End Set
    End Property

    Public Property TipoPerMin() As String
        Get
            Return _TipoPerMin
        End Get
        Set(ByVal value As String)
            _TipoPerMin = value
        End Set
    End Property

    Public Property DescripTipoPerMin() As String
        Get
            Return _DescripTipoPerMin
        End Get
        Set(ByVal value As String)
            _DescripTipoPerMin = value
        End Set
    End Property

    Public Property Importe2() As Decimal
        Get
            Return _Importe2
        End Get
        Set(ByVal value As Decimal)
            _Importe2 = value
        End Set
    End Property

    Public Property Importe3() As Decimal
        Get
            Return _Importe3
        End Get
        Set(ByVal value As Decimal)
            _Importe3 = value
        End Set
    End Property

    Public Property Glosa() As String
        Get
            Return _Glosa
        End Get
        Set(ByVal value As String)
            _Glosa = value
        End Set
    End Property

    Public Property MesName() As String
        Get
            Return _MesName
        End Get
        Set(ByVal value As String)
            _MesName = value
        End Set
    End Property

    Public Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Double)
            _Cantidad = value
        End Set
    End Property

    Public Property Cod_Glosa() As Integer
        Get
            Return _Cod_Glosa
        End Get
        Set(ByVal value As Integer)
            _Cod_Glosa = value
        End Set
    End Property
    Public Property Porcentaje() As Double
        Get
            Return _Porcentaje
        End Get
        Set(ByVal value As Double)
            _Porcentaje = value
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

    Public Property Tercero() As Boolean
        Get
            Return _Tercero
        End Get
        Set(ByVal value As Boolean)
            _Tercero = value
        End Set
    End Property

    Public Property NombreTipoTrabajo() As String
        Get
            Return _NombreTipoTrabajo
        End Get
        Set(ByVal value As String)
            _NombreTipoTrabajo = value
        End Set
    End Property

    Public Property Esquema() As String
        Get
            Return _Esquema
        End Get
        Set(ByVal value As String)
            _Esquema = value
        End Set
    End Property

    Public Property ID_Castigo() As String
        Get
            Return _ID_Castigo
        End Get
        Set(ByVal value As String)
            _ID_Castigo = value
        End Set
    End Property

    Public Property Ano_Fin() As Integer
        Get
            Return _AnoFin
        End Get
        Set(ByVal value As Integer)
            _AnoFin = value
        End Set
    End Property

    Public Property Mes_Fin() As Integer
        Get
            Return _MesFin
        End Get
        Set(ByVal value As Integer)
            _MesFin = value
        End Set
    End Property

    Public Property TipoCantera() As String
        Get
            Return _TipoCantera
        End Get
        Set(ByVal value As String)
            _TipoCantera = value
        End Set
    End Property

    Public Property TipoCosto() As String
        Get
            Return _TipoCosto
        End Get
        Set(ByVal value As String)
            _TipoCosto = value
        End Set
    End Property
#End Region
End Class
