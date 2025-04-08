
Public Class ETProducto

    Inherits ETObjecto

    Private _Cantidad As Decimal = Decimal.Zero
    Private _Clasificacion As String = String.Empty
    Private _Cod_Cia As String = String.Empty
    Private _Cod_ClasConta As String = String.Empty
    Private _Cod_Conversion As String = String.Empty
    Private _Cod_Tiempo_Importacion As String = String.Empty
    Private _Cod_Tiempo_Stock_Seguridad As String = String.Empty
    Private _CodAlmacen As String = String.Empty
    Private _CodCaract As String = String.Empty
    Private _CodLinea As String = String.Empty
    Private _CodNat As String = String.Empty
    Private _CodOrigen As String = String.Empty
    Private _CodPlanta As String = String.Empty
    Private _CodProducto As String = String.Empty
    Private _Accion As String = String.Empty
    Private _CodUnidCpa As String = String.Empty
    Private _CodVenta As String = String.Empty
    Private _Control_Dua As String = String.Empty
    Private _Control_Num As String = String.Empty
    Private _CpaxVol As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _DesTecnica As String = String.Empty
    Private _DifMinxVenta As Decimal = Decimal.Zero
    Private _Empleo As String = String.Empty
    Private _EnProduccion As Decimal = Decimal.Zero
    Private _Entero As String = String.Empty
    Private _Factor As Decimal = Decimal.Zero
    Private _FactorBolsa As Decimal = Decimal.Zero
    Private _FactorConversion As String = String.Empty
    Private _FechaActualizacion As Date = Date.Now
    Private _FechaCreacion As Date = Date.Now
    Private _ID As Int32 = 0
    Private _IDChancadora As String = String.Empty
    Private _IDMolino As String = String.Empty
    Private _Moneda As String = String.Empty
    Private _Muestra As Boolean = Boolean.FalseString
    Private _NoConforme As String = String.Empty
    Private _OpcProd As String = String.Empty
    Private _Opera As String = String.Empty
    Private _ParteMensual As Boolean = Boolean.FalseString
    Private _ParteSemanal As Int32 = 0
    Private _Peso As Decimal = Decimal.Zero
    Private _Proyeccion As Decimal = Decimal.Zero
    Private _QuitarConsultaStock As Boolean = Boolean.FalseString
    Private _Status As String = String.Empty
    Private _StkMin As Decimal = Decimal.Zero
    Private _Stock As Decimal = Decimal.Zero
    Private _StockDespacho As Decimal = Decimal.Zero
    Private _StockMinimo As Decimal = Decimal.Zero
    Private _StockPendiente As Decimal = Decimal.Zero
    Private _StockVenta As Decimal = Decimal.Zero
    Private _Sumi_Consu As String = String.Empty
    Private _Sumi_Critico As String = String.Empty
    Private _Tiempo_Importacion As Decimal = Decimal.Zero
    Private _Tiempo_Stock_Seguridad As Decimal = Decimal.Zero
    Private _Tipo As Int16 = 0
    Private _SubFamilia As String = String.Empty
    Private _Familia As String = String.Empty
    Private _TipoProducto As String = String.Empty
    Private _UbiAlm As String = String.Empty
    Private _Unidad As String = String.Empty
    Private _UnidadDesp As String = String.Empty
    Private _UnidadProduccion As String = String.Empty
    Private _UnidadVentas As String = String.Empty
    Private _Update As Boolean = Boolean.FalseString
    Private _User_Crea As String = String.Empty
    Private _Uso As String = String.Empty
    Private _Ventas As Boolean = Boolean.FalseString
    Private _Cod_Cantera As String = String.Empty
    Private _CodProdPDCObs As String = String.Empty
    Private _Periodo As String = String.Empty
    Private _Estado As String = String.Empty
    Private _Cuenta As String = String.Empty
    Private _codClase As String = String.Empty
    Private _Placa As String = String.Empty
    Private _CodEquipo As String = String.Empty

    Private _Equipo As String = String.Empty
    Private _Proyecto As String = String.Empty
    Private _Area As String = String.Empty
    Private _IDPROYECTO As Int32 = 0
    Private _IDNAVIERA As Int32 = 0
    Private _IDTIPO As Int32 = 0
    Private _tipotarifa As String = String.Empty
    Private _NAVIERA As String = String.Empty
    Private _DESCTIPO As String = String.Empty
    Private _CODRUMA As String = String.Empty
    Private _csStock As String = String.Empty

    Private _RutaConvenio As String = String.Empty
    Private _RutaLetra As String = String.Empty

    Public Property csStock() As String
        Get
            Return _csStock
        End Get
        Set(ByVal value As String)
            _csStock = value
        End Set
    End Property

    Public Property CODRUMA() As String
        Get
            Return _CODRUMA
        End Get
        Set(ByVal value As String)
            _CODRUMA = value
        End Set
    End Property

    Public Property DESCTIPO() As String
        Get
            Return _DESCTIPO
        End Get
        Set(ByVal value As String)
            _DESCTIPO = value
        End Set
    End Property

    Public Overloads Property IDTIPO() As Int32
        Get
            Return _IDTIPO
        End Get
        Set(ByVal value As Int32)
            _IDTIPO = value
        End Set
    End Property

    Public Property NAVIERA() As String
        Get
            Return _NAVIERA
        End Get
        Set(ByVal value As String)
            _NAVIERA = value
        End Set
    End Property

    Public Property tipotarifa() As String
        Get
            Return _tipotarifa
        End Get
        Set(ByVal value As String)
            _tipotarifa = value
        End Set
    End Property

    Public Overloads Property IDNAVIERA() As Int32
        Get
            Return _IDNAVIERA
        End Get
        Set(ByVal value As Int32)
            _IDNAVIERA = value
        End Set
    End Property

    Public Overloads Property IDPROYECTO() As Int32
        Get
            Return _IDPROYECTO
        End Get
        Set(ByVal value As Int32)
            _IDPROYECTO = value
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

    Public Property Proyecto() As String
        Get
            Return _Proyecto
        End Get
        Set(ByVal value As String)
            _Proyecto = value
        End Set
    End Property

    Public Property CodEquipo() As String
        Get
            Return _CodEquipo
        End Get
        Set(ByVal value As String)
            _CodEquipo = value
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

    Public Overloads Property Periodo() As String
        Get
            Return _Periodo
        End Get
        Set(ByVal value As String)
            _Periodo = value
        End Set
    End Property

    Public Property Cod_Conversion() As String
        Get
            Return _Cod_Conversion
        End Get
        Set(ByVal value As String)
            _Cod_Conversion = value
        End Set
    End Property

    Public Property Opera() As String
        Get
            Return _Opera
        End Get
        Set(ByVal value As String)
            _Opera = value
        End Set
    End Property

    Public Property FactorConversion() As String
        Get
            Return _FactorConversion
        End Get
        Set(ByVal value As String)
            _FactorConversion = value
        End Set
    End Property

    Public Property Entero() As String
        Get
            Return _Entero
        End Get
        Set(ByVal value As String)
            _Entero = value
        End Set
    End Property

    Public Property Empleo() As String
        Get
            Return _Empleo
        End Get
        Set(ByVal value As String)
            _Empleo = value
        End Set
    End Property

    Public Property Cod_Cia() As String
        Get
            Return _Cod_Cia
        End Get
        Set(ByVal Value As String)
            _Cod_Cia = Value
        End Set
    End Property

    Public Property CodUnidCpa() As String
        Get
            Return _CodUnidCpa
        End Get
        Set(ByVal Value As String)
            _CodUnidCpa = Value
        End Set
    End Property

    Public Property Moneda() As String
        Get
            Return _Moneda
        End Get
        Set(ByVal Value As String)
            _Moneda = Value
        End Set
    End Property

    Public Property CodLinea() As String
        Get
            Return _CodLinea
        End Get
        Set(ByVal Value As String)
            _CodLinea = Value
        End Set
    End Property

    Public Property CodNat() As String
        Get
            Return _CodNat
        End Get
        Set(ByVal Value As String)
            _CodNat = Value
        End Set
    End Property

    Public Property CodCaract() As String
        Get
            Return _CodCaract
        End Get
        Set(ByVal Value As String)
            _CodCaract = Value
        End Set
    End Property

    Public Property CodOrigen() As String
        Get
            Return _CodOrigen
        End Get
        Set(ByVal Value As String)
            _CodOrigen = Value
        End Set
    End Property

    Public Property OpcProd() As String
        Get
            Return _OpcProd
        End Get
        Set(ByVal Value As String)
            _OpcProd = Value
        End Set
    End Property

    Public Property User_Crea() As String
        Get
            Return _User_Crea
        End Get
        Set(ByVal Value As String)
            _User_Crea = Value
        End Set
    End Property

    Public Property DesTecnica() As String
        Get
            Return _DesTecnica
        End Get
        Set(ByVal Value As String)
            _DesTecnica = Value
        End Set
    End Property

    Public Property CpaxVol() As String
        Get
            Return _CpaxVol
        End Get
        Set(ByVal Value As String)
            _CpaxVol = Value
        End Set
    End Property


    Public Property Control_Num() As String
        Get
            Return _Control_Num
        End Get
        Set(ByVal Value As String)
            _Control_Num = Value
        End Set
    End Property

    Public Property StkMin() As Decimal
        Get
            Return _StkMin
        End Get
        Set(ByVal Value As Decimal)
            _StkMin = Value
        End Set
    End Property
    Public Property Accion() As String
        Get
            Return _Accion
        End Get
        Set(ByVal Value As String)
            _Accion = Value
        End Set
    End Property

    Public Property UbiAlm() As String
        Get
            Return _UbiAlm
        End Get
        Set(ByVal Value As String)
            _UbiAlm = Value
        End Set
    End Property

    Public Property Control_Dua() As String
        Get
            Return _Control_Dua
        End Get
        Set(ByVal Value As String)
            _Control_Dua = Value
        End Set
    End Property

    Public Property Sumi_Critico() As String
        Get
            Return _Sumi_Critico
        End Get
        Set(ByVal Value As String)
            _Sumi_Critico = Value
        End Set
    End Property

    Public Property Tiempo_Stock_Seguridad() As Decimal
        Get
            Return _Tiempo_Stock_Seguridad
        End Get
        Set(ByVal Value As Decimal)
            _Tiempo_Stock_Seguridad = Value
        End Set
    End Property

    Public Property Cod_Tiempo_Stock_Seguridad() As String
        Get
            Return _Cod_Tiempo_Stock_Seguridad
        End Get
        Set(ByVal Value As String)
            _Cod_Tiempo_Stock_Seguridad = Value
        End Set
    End Property


    Public Property Tiempo_Importacion() As Decimal
        Get
            Return _Tiempo_Importacion
        End Get
        Set(ByVal Value As Decimal)
            _Tiempo_Importacion = Value
        End Set
    End Property

    Public Property Cod_Tiempo_Importacion() As String
        Get
            Return _Cod_Tiempo_Importacion
        End Get
        Set(ByVal Value As String)
            _Cod_Tiempo_Importacion = Value
        End Set
    End Property

    Public Property Sumi_Consu() As String
        Get
            Return _Sumi_Consu
        End Get
        Set(ByVal Value As String)
            _Sumi_Consu = Value
        End Set
    End Property

    Public Property Cod_ClasConta() As String
        Get
            Return _Cod_ClasConta
        End Get
        Set(ByVal Value As String)
            _Cod_ClasConta = Value
        End Set
    End Property

    Public Overloads Property Familia() As String
        Get
            Return _Familia
        End Get
        Set(ByVal value As String)
            _Familia = value
        End Set
    End Property

    Public Overloads Property SubFamilia() As String
        Get
            Return _SubFamilia
        End Get
        Set(ByVal value As String)
            _SubFamilia = value
        End Set
    End Property

    Public Overloads Property Tipo() As Int16
        Get
            Return _Tipo
        End Get
        Set(ByVal value As Int16)
            _Tipo = value
        End Set
    End Property
    Public Overloads Property ID() As Int32
        Get
            Return _ID
        End Get
        Set(ByVal value As Int32)
            _ID = value
        End Set
    End Property
    Public Overloads Property Factor() As Decimal
        Get
            Return _Factor
        End Get
        Set(ByVal value As Decimal)
            _Factor = value
        End Set
    End Property
    Public Overloads Property Update() As Boolean
        Get
            Return _Update
        End Get
        Set(ByVal value As Boolean)
            _Update = value
        End Set
    End Property
    Public Property CodVenta() As String
        Get
            Return _CodVenta
        End Get
        Set(ByVal value As String)
            _CodVenta = value
        End Set
    End Property
    Public Property CodProducto() As String
        Get
            Return _CodProducto
        End Get
        Set(ByVal value As String)
            _CodProducto = value
        End Set
    End Property
    Dim _CodTransportista As String
    Public Property CodTransportista() As String
        Get
            Return _CodTransportista
        End Get
        Set(ByVal value As String)
            _CodTransportista = value
        End Set
    End Property
    Dim _CodTrabajador As String
    Public Property CodTrabajador() As String
        Get
            Return _CodTrabajador
        End Get
        Set(ByVal value As String)
            _CodTrabajador = value
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
    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
        End Set
    End Property
    Public Property TipoProducto() As String
        Get
            Return _TipoProducto
        End Get
        Set(ByVal value As String)
            _TipoProducto = value
        End Set
    End Property
    Public Property CodAlmacen() As String
        Get
            Return _CodAlmacen
        End Get
        Set(ByVal value As String)
            _CodAlmacen = value
        End Set
    End Property

    Public Property Cuenta() As String
        Get
            Return _Cuenta
        End Get
        Set(ByVal value As String)
            _Cuenta = value
        End Set
    End Property

    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property

    Public Property codClase() As String
        Get
            Return _codClase
        End Get
        Set(ByVal value As String)
            _codClase = value
        End Set
    End Property

    Public Property IDChancadora() As String
        Get
            Return _IDChancadora
        End Get
        Set(ByVal value As String)
            _IDChancadora = value
        End Set
    End Property

    Public Property IDMolino() As String
        Get
            Return _IDMolino
        End Get
        Set(ByVal value As String)
            _IDMolino = value
        End Set
    End Property

    Public Overloads Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

    Public Overloads Property Unidad() As String
        Get
            Return _Unidad
        End Get
        Set(ByVal value As String)
            _Unidad = value
        End Set
    End Property
    Public Property UnidadDesp() As String
        Get
            Return _UnidadDesp
        End Get
        Set(ByVal value As String)
            _UnidadDesp = value
        End Set
    End Property
    Public Property Peso() As Decimal
        Get
            Return _Peso
        End Get
        Set(ByVal value As Decimal)
            _Peso = value
        End Set
    End Property
    Public Property Stock() As Decimal
        Get
            Return _Stock
        End Get
        Set(ByVal value As Decimal)
            _Stock = value
        End Set
    End Property
    Public Property StockDespacho() As Decimal
        Get
            Return _StockDespacho
        End Get
        Set(ByVal value As Decimal)
            _StockDespacho = value
        End Set
    End Property
    Public Property StockVenta() As Decimal
        Get
            Return _StockVenta
        End Get
        Set(ByVal value As Decimal)
            _StockVenta = value
        End Set
    End Property
    Public Property StockPendiente() As Decimal
        Get
            Return _StockPendiente
        End Get
        Set(ByVal value As Decimal)
            _StockPendiente = value
        End Set
    End Property
    Public Property StockMinimo() As Decimal
        Get
            Return _StockMinimo
        End Get
        Set(ByVal value As Decimal)
            _StockMinimo = value
        End Set
    End Property
    Public Property Proyeccion() As Decimal
        Get
            Return _Proyeccion
        End Get
        Set(ByVal value As Decimal)
            _Proyeccion = value
        End Set
    End Property
    Public Property CodPlanta() As String
        Get
            Return _CodPlanta
        End Get
        Set(ByVal value As String)
            _CodPlanta = value
        End Set
    End Property
    Public Property EnProduccion() As Decimal
        Get
            Return _EnProduccion
        End Get
        Set(ByVal value As Decimal)
            _EnProduccion = value
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
    Public Property Uso() As String
        Get
            Return _Uso
        End Get
        Set(ByVal value As String)
            _Uso = value
        End Set
    End Property
    Public Property FactorBolsa() As Decimal
        Get
            Return _FactorBolsa
        End Get
        Set(ByVal value As Decimal)
            _FactorBolsa = value
        End Set
    End Property
    Public Property ParteMensual() As Boolean
        Get
            Return _ParteMensual
        End Get
        Set(ByVal value As Boolean)
            _ParteMensual = value
        End Set
    End Property
    Public Property QuitarConsultaStock() As Boolean
        Get
            Return _QuitarConsultaStock
        End Get
        Set(ByVal value As Boolean)
            _QuitarConsultaStock = value
        End Set
    End Property
    Public Property UnidadProduccion() As String
        Get
            Return _UnidadProduccion
        End Get
        Set(ByVal value As String)
            _UnidadProduccion = value
        End Set
    End Property
    Public Property Clasificacion() As String
        Get
            Return _Clasificacion
        End Get
        Set(ByVal value As String)
            _Clasificacion = value
        End Set
    End Property
    Public Property NoConforme() As String
        Get
            Return _NoConforme
        End Get
        Set(ByVal value As String)
            _NoConforme = value
        End Set
    End Property
    Public Property Muestra() As Boolean
        Get
            Return _Muestra
        End Get
        Set(ByVal value As Boolean)
            _Muestra = value
        End Set
    End Property
    Public Property Ventas() As Boolean
        Get
            Return _Ventas
        End Get
        Set(ByVal value As Boolean)
            _Ventas = value
        End Set
    End Property
    Public Property UnidadVentas() As String
        Get
            Return _UnidadVentas
        End Get
        Set(ByVal value As String)
            _UnidadVentas = value
        End Set
    End Property
    Public Property FechaCreacion() As Date
        Get
            Return _FechaCreacion
        End Get
        Set(ByVal value As Date)
            _FechaCreacion = value
        End Set
    End Property
    Public Property FechaActualizacion() As Date
        Get
            Return _FechaActualizacion
        End Get
        Set(ByVal value As Date)
            _FechaActualizacion = value
        End Set
    End Property
    Public Property ParteSemanal() As Int32
        Get
            Return _ParteSemanal
        End Get
        Set(ByVal value As Int32)
            _ParteSemanal = value
        End Set
    End Property


    Public Property DifMinxVenta() As Decimal
        Get
            Return _DifMinxVenta
        End Get
        Set(ByVal value As Decimal)
            _DifMinxVenta = value
        End Set
    End Property

    Private _CantidadProducida As Decimal = Decimal.Zero

    Public Property CantidadProducida() As Decimal
        Get
            Return _CantidadProducida
        End Get
        Set(ByVal value As Decimal)
            _CantidadProducida = value
        End Set
    End Property

    Private _CantidadDespachada As Decimal = Decimal.Zero

    Public Property CantidadDespachada() As Decimal
        Get
            Return _CantidadDespachada
        End Get
        Set(ByVal value As Decimal)
            _CantidadDespachada = value
        End Set
    End Property


    Private _tea As Double

    Public Property tea() As Double
        Get
            Return _tea
        End Get
        Set(ByVal value As Double)
            _tea = value
        End Set
    End Property

    Private _ted As Double

    Public Property ted() As Double
        Get
            Return _ted
        End Get
        Set(ByVal value As Double)
            _ted = value
        End Set
    End Property

    Private _CantidadRecomendada As Decimal = Decimal.Zero

    Public Property CantidadRecomendada() As Decimal
        Get
            Return _CantidadRecomendada
        End Get
        Set(ByVal value As Decimal)
            _CantidadRecomendada = value
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

    Public Property CodProdPDCObs() As String
        Get
            Return _CodProdPDCObs
        End Get
        Set(ByVal value As String)
            _CodProdPDCObs = value
        End Set
    End Property

    Dim _tipodoc As String
    Public Property tipodoc() As String
        Get
            Return _tipodoc
        End Get
        Set(ByVal value As String)
            _tipodoc = value
        End Set
    End Property

    Dim _seriedoc As String
    Public Property seriedoc() As String
        Get
            Return _seriedoc
        End Get
        Set(ByVal value As String)
            _seriedoc = value
        End Set
    End Property

    Dim _numdoc As String
    Public Property numdoc() As String
        Get
            Return _numdoc
        End Get
        Set(ByVal value As String)
            _numdoc = value
        End Set
    End Property

    Dim _numbillete As String
    Public Property numbillete() As String
        Get
            Return _numbillete
        End Get
        Set(ByVal value As String)
            _numbillete = value
        End Set
    End Property

    Dim _numconstancia As String
    Public Property numconstancia() As String
        Get
            Return _numconstancia
        End Get
        Set(ByVal value As String)
            _numconstancia = value
        End Set
    End Property

    Dim _check As Int32
    Public Property check() As Int32
        Get
            Return _check
        End Get
        Set(ByVal value As Int32)
            _check = value
        End Set
    End Property

    Dim _iderror As Int32
    Public Property iderror() As Int32
        Get
            Return _iderror
        End Get
        Set(ByVal value As Int32)
            _iderror = value
        End Set
    End Property

    Dim _Transportista As String
    Public Property Transportista() As String
        Get
            Return _Transportista
        End Get
        Set(ByVal value As String)
            _Transportista = value
        End Set
    End Property

    Dim _Observacion As String
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
        End Set
    End Property

    Dim _Configuracion As String
    Public Property Configuracion() As String
        Get
            Return _Configuracion
        End Get
        Set(ByVal value As String)
            _Configuracion = value
        End Set
    End Property

    Dim _Monto As Double
    Public Property Monto() As Double
        Get
            Return _Monto
        End Get
        Set(ByVal value As Double)
            _Monto = value
        End Set
    End Property

    Dim _flgdevolucion As Int32
    Public Property flgdevolucion() As Int32
        Get
            Return _flgdevolucion
        End Get
        Set(ByVal value As Int32)
            _flgdevolucion = value
        End Set
    End Property

    Dim _flgADM As Int32
    Public Property flgADM() As Int32
        Get
            Return _flgADM
        End Get
        Set(ByVal value As Int32)
            _flgADM = value
        End Set
    End Property

    Dim _flgVENTA As Int32
    Public Property flgVENTA() As Int32
        Get
            Return _flgVENTA
        End Get
        Set(ByVal value As Int32)
            _flgVENTA = value
        End Set
    End Property

    Dim _fechadevolucion As Date
    Public Property fechadevolucion() As Date
        Get
            Return _fechadevolucion
        End Get
        Set(ByVal value As Date)
            _fechadevolucion = value
        End Set
    End Property

    'Dim _RutaConvenio As String
    Public Property RutaConvenio() As String
        Get
            Return _RutaConvenio
        End Get
        Set(ByVal value As String)
            _RutaConvenio = value
        End Set
    End Property

    'Dim _RutaLetra As String
    Public Property RutaLetra() As String
        Get
            Return _RutaLetra
        End Get
        Set(ByVal value As String)
            _RutaLetra = value
        End Set
    End Property

End Class
