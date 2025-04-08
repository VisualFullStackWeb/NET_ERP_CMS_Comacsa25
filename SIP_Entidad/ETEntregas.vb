Public Class ETEntregas

    Inherits ETObjecto

    Private _CodSolicitud As String = String.Empty
    Private _NumSolicitud As String = String.Empty
    Private _CodTrabajador As String = String.Empty
    Private _NomTrabajador As String = String.Empty

    Private _CodProducto As String = String.Empty
    Private _Producto As String = String.Empty

    Private _JefeArea As String = String.Empty
    Private _ApePaterno As String = String.Empty
    Private _ApeMaterno As String = String.Empty
    Private _Motivo As String = String.Empty
    Private _codArea As String = String.Empty
    Private _Area As String = String.Empty
    Private _Areabd As String = String.Empty
    Private _Estado As String = String.Empty
    Private _idEstado As Int32 = 0
    Private _codCantera As String = String.Empty
    Private _codCanteradet As String = String.Empty
    Private _Cantera As String = String.Empty

    Private _codConcepto As String = String.Empty
    Private _totaldias As Int32 = 0
    Private _montoParcial As Double = 0
    Private _montoTotalParcial As Double = 0
    Private _montoTotal As Double = 0

    Private _fechaSalida As Date = Date.Now
    Private _fechaRetorno As Date = Date.Now
    Private _TipoOperacion As Int32 = 0
    Private _Region As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _codcencos As String = String.Empty
    Private _dni As String = String.Empty

    Private _fechaComp As DateTime
    Private _tipodoc As String = String.Empty
    Private _codtipodoc As String = String.Empty
    Private _numdoc As String = String.Empty
    Private _numdocdevo As String = String.Empty
    Private _razon As String = String.Empty
    Private _nroruc As String = String.Empty
    Private _item As Int32
    Private _codAuxiliar As String = String.Empty
    Private _Concepto As String = String.Empty
    Private _Conceptos As DataTable
    Private _montoDevolucion As Double = 0
    Private _montoReintegro As Double = 0
    Private _idComp As Int32
    Private _fila As Int32

    Private _tipodeposito As String = String.Empty
    Private _nrocta As String = String.Empty
    Private _banco As String = String.Empty
    Private _nrodoc As String = String.Empty
    Private _serie As String = String.Empty
    Private _codmotivoDetalle As String = String.Empty
    Private _motivoDetalle As String = String.Empty
    Private _tipoAprobacion As String = String.Empty
    Private _userlogin As String = String.Empty
    Private _encargado As String = String.Empty
    Private _numinterno As String = String.Empty
    Private _codmoneda As String = String.Empty
    Private _moneda As String = String.Empty

    Private _flgbeneficiario As String = String.Empty
    Private _dnibeneficiario As String = String.Empty
    Private _beneficiario As String = String.Empty
    Private _tipodepobeneficiario As String = String.Empty
    Private _bancobeneficiario As String = String.Empty
    Private _ctabeneficiario As String = String.Empty

    Private _bcotrabajador As String = String.Empty
    Private _ctatrabajador As String = String.Empty

    Private _codbanco As String = String.Empty
    Private _lineacredito As Double = 0
    Private _tipocambio As Double = 0
    Private _tipoconcepto As String = String.Empty
    Private _codCuenta As String = String.Empty
    Private _Cuenta As String = String.Empty
    Private _action As Boolean = False
    Private _check As Int32 = 0
    Private _flgjefe As Int32 = 0
    Private _flgcompra As Int32 = 0
    Private _auxi As String = String.Empty
    Private _tipprod As String = String.Empty
    Private _Auxiliar As String = String.Empty
    Private _tipotabla As Int32 = 0
    Private _Destino As String = String.Empty
    Private _Direccion As String = String.Empty
    Private _fechacontable As Date = Date.Now
    Private _añocontable As Int32
    Private _mescontable As Int32
    Private _estadocontable As Int32
    Private _nVoucher As String = String.Empty
    Private _nVoucherInerno As String = String.Empty
    Private _espendiente As Int32 = 0
    Private _motivoReemplazo As String = String.Empty
    Private _idReemplazo As Int32 = 0
    Private _CodJefe As String = String.Empty
    Private _NomJefe As String = String.Empty
    Private _Cargo As String = String.Empty
    Private _tipofiltro As String = String.Empty
    Private _TipoImpresion As Int32
    Private _flgpermiso As Int32
    Private _dias As Int32
    Private _personas As Int32
    Private _flgprovision As Int32
    Private _flgreal As Int32
    Private _nfila As Int32
    Private _telefono As String
    Private _codprov As String
    Private _placa As String
    Private _tvehiculo As String
    Private _tfacturacion As String
    Private _flgcombustible As Int32
    Private _flgoperador As Int32
    Private _Observacion As String
    Private _flgretencion As Int32
    Private _permiso As Int32
    Private _igv As Double
    Private _igv_ori As Double
    Private _nro_tarjeta As String
    Private _tipo_tarjeta As String
    Private _cod_banco As String
    Private _saldo_ini As Int32
    Private _saldo_ini1 As Int32
    Private _idTarjetaConsumo As Int32
    Private _idTipoTarjetaConsumo As Int32
    Private _nroTarjeta As String

    Private _FechaInicioPeriodo As Date
    Private _FechaFinPeriodo As Date
    Private _DiasPeriodo As Integer
    Private _LimiteCredito As Decimal
    Private _TotalConsumido As Decimal
    Private _SaldoDisponible As Decimal
    Private _EstadoCredito As String


    Public Property nroTarjeta() As String
        Get
            Return _nroTarjeta
        End Get
        Set(ByVal value As String)
            _nroTarjeta = value
        End Set
    End Property

    Public Property idTipoTarjetaConsumo() As Int32
        Get
            Return _idTipoTarjetaConsumo
        End Get
        Set(ByVal value As Int32)
            _idTipoTarjetaConsumo = value
        End Set
    End Property

    Public Property idTarjetaConsumo() As Int32
        Get
            Return _idTarjetaConsumo
        End Get
        Set(ByVal value As Int32)
            _idTarjetaConsumo = value
        End Set
    End Property
    Public Property igv_ori() As Double
        Get
            Return _igv_ori
        End Get
        Set(ByVal value As Double)
            _igv_ori = value
        End Set
    End Property

    Public Property igv() As Double
        Get
            Return _igv
        End Get
        Set(ByVal value As Double)
            _igv = value
        End Set
    End Property

    Public Property permiso() As Int32
        Get
            Return _permiso
        End Get
        Set(ByVal value As Int32)
            _permiso = value
        End Set
    End Property

    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
        End Set
    End Property

    Public Property tvehiculo() As String
        Get
            Return _tvehiculo
        End Get
        Set(ByVal value As String)
            _tvehiculo = value
        End Set
    End Property

    Public Property tfacturacion() As String
        Get
            Return _tfacturacion
        End Get
        Set(ByVal value As String)
            _tfacturacion = value
        End Set
    End Property

    Public Property placa() As String
        Get
            Return _placa
        End Get
        Set(ByVal value As String)
            _placa = value
        End Set
    End Property

    Public Property flgretencion() As Int32
        Get
            Return _flgretencion
        End Get
        Set(ByVal value As Int32)
            _flgretencion = value
        End Set
    End Property

    Public Property flgcombustible() As Int32
        Get
            Return _flgcombustible
        End Get
        Set(ByVal value As Int32)
            _flgcombustible = value
        End Set
    End Property

    Public Property flgoperador() As Int32
        Get
            Return _flgoperador
        End Get
        Set(ByVal value As Int32)
            _flgoperador = value
        End Set
    End Property

    Public Property codprov() As String
        Get
            Return _codprov
        End Get
        Set(ByVal value As String)
            _codprov = value
        End Set
    End Property

    Public Property nfila() As Int32
        Get
            Return _nfila
        End Get
        Set(ByVal value As Int32)
            _nfila = value
        End Set
    End Property

    Public Property flgprovision() As Int32
        Get
            Return _flgprovision
        End Get
        Set(ByVal value As Int32)
            _flgprovision = value
        End Set
    End Property

    Public Property dias() As Int32
        Get
            Return _dias
        End Get
        Set(ByVal value As Int32)
            _dias = value
        End Set
    End Property
    Public Property personas() As Int32
        Get
            Return _personas
        End Get
        Set(ByVal value As Int32)
            _personas = value
        End Set
    End Property
    Public Property flgreal() As Int32
        Get
            Return _flgreal
        End Get
        Set(ByVal value As Int32)
            _flgreal = value
        End Set
    End Property
    Public Property flgpermiso() As Int32
        Get
            Return _flgpermiso
        End Get
        Set(ByVal value As Int32)
            _flgpermiso = value
        End Set
    End Property
    Public Property TipoImpresion() As Int32
        Get
            Return _TipoImpresion
        End Get
        Set(ByVal value As Int32)
            _TipoImpresion = value
        End Set
    End Property
    Public Property tipofiltro() As String
        Get
            Return _tipofiltro
        End Get
        Set(ByVal value As String)
            _tipofiltro = value
        End Set
    End Property

    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Public Property CodJefe() As String
        Get
            Return _CodJefe
        End Get
        Set(ByVal value As String)
            _CodJefe = value
        End Set
    End Property
    Public Property NomJefe() As String
        Get
            Return _NomJefe
        End Get
        Set(ByVal value As String)
            _NomJefe = value
        End Set
    End Property
    Public Property Cargo() As String
        Get
            Return _Cargo
        End Get
        Set(ByVal value As String)
            _Cargo = value
        End Set
    End Property
    Public Property idReemplazo() As Int32
        Get
            Return _idReemplazo
        End Get
        Set(ByVal value As Int32)
            _idReemplazo = value
        End Set
    End Property

    Public Property motivoReemplazo() As String
        Get
            Return _motivoReemplazo
        End Get
        Set(ByVal value As String)
            _motivoReemplazo = value
        End Set
    End Property

    Public Property espendiente() As Int32
        Get
            Return _espendiente
        End Get
        Set(ByVal value As Int32)
            _espendiente = value
        End Set
    End Property

    Public Property nVoucherInerno() As String
        Get
            Return _nVoucherInerno
        End Get
        Set(ByVal value As String)
            _nVoucherInerno = value
        End Set
    End Property

    Public Property nVoucher() As String
        Get
            Return _nVoucher
        End Get
        Set(ByVal value As String)
            _nVoucher = value
        End Set
    End Property

    Public Property estadocontable() As Int32
        Get
            Return _estadocontable
        End Get
        Set(ByVal value As Int32)
            _estadocontable = value
        End Set
    End Property


    Public Property mescontable() As Int32
        Get
            Return _mescontable
        End Get
        Set(ByVal value As Int32)
            _mescontable = value
        End Set
    End Property

    Public Property añocontable() As Int32
        Get
            Return _añocontable
        End Get
        Set(ByVal value As Int32)
            _añocontable = value
        End Set
    End Property

    Public Property fechacontable() As Date
        Get
            Return _fechacontable
        End Get
        Set(ByVal value As Date)
            _fechacontable = value
        End Set
    End Property
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property
    Public Property Destino() As String
        Get
            Return _Destino
        End Get
        Set(ByVal value As String)
            _Destino = value
        End Set
    End Property

    Public Property tipotabla() As Int32
        Get
            Return _tipotabla
        End Get
        Set(ByVal value As Int32)
            _tipotabla = value
        End Set
    End Property

    Public Property Auxiliar() As String
        Get
            Return _Auxiliar
        End Get
        Set(ByVal value As String)
            _Auxiliar = value
        End Set
    End Property
    Private _Combustible As String = String.Empty
    Public Property Combustible() As String
        Get
            Return _Combustible
        End Get
        Set(ByVal value As String)
            _Combustible = value
        End Set
    End Property
    Private _Proveedor As String = String.Empty
    Public Property Proveedor() As String
        Get
            Return _Proveedor
        End Get
        Set(ByVal value As String)
            _Proveedor = value
        End Set
    End Property
    Public Property tipprod() As String
        Get
            Return _tipprod
        End Get
        Set(ByVal value As String)
            _tipprod = value
        End Set
    End Property
    Public Property auxi() As String
        Get
            Return _auxi
        End Get
        Set(ByVal value As String)
            _auxi = value
        End Set
    End Property
    Public Property flgcompra() As Int32
        Get
            Return _flgcompra
        End Get
        Set(ByVal value As Int32)
            _flgcompra = value
        End Set
    End Property

    Public Property flgjefe() As Int32
        Get
            Return _flgjefe
        End Get
        Set(ByVal value As Int32)
            _flgjefe = value
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
    Public Property Action() As Boolean
        Get
            Return _action
        End Get
        Set(ByVal value As Boolean)
            _action = value
        End Set
    End Property
    Public Property codCuenta() As String
        Get
            Return _codCuenta
        End Get
        Set(ByVal value As String)
            _codCuenta = value
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
    Private _codCuentaBoleta As String = String.Empty
    Public Property codCuentaBoleta() As String
        Get
            Return _codCuentaBoleta
        End Get
        Set(ByVal value As String)
            _codCuentaBoleta = value
        End Set
    End Property
    Private _CuentaBoleta As String = String.Empty
    Public Property CuentaBoleta() As String
        Get
            Return _CuentaBoleta
        End Get
        Set(ByVal value As String)
            _CuentaBoleta = value
        End Set
    End Property

    Public Property tipoconcepto() As String
        Get
            Return _tipoconcepto
        End Get
        Set(ByVal value As String)
            _tipoconcepto = value
        End Set
    End Property
    Public Property tipocambio() As Double
        Get
            Return _tipocambio
        End Get
        Set(ByVal value As Double)
            _tipocambio = value
        End Set
    End Property

    Public Property lineacredito() As Double
        Get
            Return _lineacredito
        End Get
        Set(ByVal value As Double)
            _lineacredito = value
        End Set
    End Property
    Public Property bcotrabajador() As String
        Get
            Return _bcotrabajador
        End Get
        Set(ByVal value As String)
            _bcotrabajador = value
        End Set
    End Property
    Public Property ctatrabajador() As String
        Get
            Return _ctatrabajador
        End Get
        Set(ByVal value As String)
            _ctatrabajador = value
        End Set
    End Property
    Public Property codbanco() As String
        Get
            Return _codbanco
        End Get
        Set(ByVal value As String)
            _codbanco = value
        End Set
    End Property
    Public Property flgbeneficiario() As String
        Get
            Return _flgbeneficiario
        End Get
        Set(ByVal value As String)
            _flgbeneficiario = value
        End Set
    End Property
    Public Property dnibeneficiario() As String
        Get
            Return _dnibeneficiario
        End Get
        Set(ByVal value As String)
            _dnibeneficiario = value
        End Set
    End Property
    Public Property beneficiario() As String
        Get
            Return _beneficiario
        End Get
        Set(ByVal value As String)
            _beneficiario = value
        End Set
    End Property
    Public Property tipodepobeneficiario() As String
        Get
            Return _tipodepobeneficiario
        End Get
        Set(ByVal value As String)
            _tipodepobeneficiario = value
        End Set
    End Property
    Public Property bancobeneficiario() As String
        Get
            Return _bancobeneficiario
        End Get
        Set(ByVal value As String)
            _bancobeneficiario = value
        End Set
    End Property

    Public Property ctabeneficiario() As String
        Get
            Return _ctabeneficiario
        End Get
        Set(ByVal value As String)
            _ctabeneficiario = value
        End Set
    End Property

    Public Property nro_tarjeta() As String
        Get
            Return _nro_tarjeta
        End Get
        Set(ByVal value As String)
            _nro_tarjeta = value
        End Set
    End Property

    Public Property tipo_tarjeta() As String
        Get
            Return _tipo_tarjeta
        End Get
        Set(ByVal value As String)
            _tipo_tarjeta = value
        End Set
    End Property

    Public Property cod_banco() As String
        Get
            Return _cod_banco
        End Get
        Set(ByVal value As String)
            _cod_banco = value
        End Set
    End Property

    Public Property saldo_ini() As Int32
        Get
            Return _saldo_ini
        End Get
        Set(ByVal value As Int32)
            _saldo_ini = value
        End Set
    End Property
    Public Property saldo_ini1() As Int32
        Get
            Return _saldo_ini1
        End Get
        Set(ByVal value As Int32)
            _saldo_ini1 = value
        End Set
    End Property

    Public Property codmoneda() As String
        Get
            Return _codmoneda
        End Get
        Set(ByVal value As String)
            _codmoneda = value
        End Set
    End Property
    Public Property moneda() As String
        Get
            Return _moneda
        End Get
        Set(ByVal value As String)
            _moneda = value
        End Set
    End Property
    Public Property numinterno() As String
        Get
            Return _numinterno
        End Get
        Set(ByVal value As String)
            _numinterno = value
        End Set
    End Property
    Public Property encargado() As String
        Get
            Return _encargado
        End Get
        Set(ByVal value As String)
            _encargado = value
        End Set
    End Property
    Public Property userlogin() As String
        Get
            Return _userlogin
        End Get
        Set(ByVal value As String)
            _userlogin = value
        End Set
    End Property
    Public Property tipoAprobacion() As String
        Get
            Return _tipoAprobacion
        End Get
        Set(ByVal value As String)
            _tipoAprobacion = value
        End Set
    End Property
    Public Property codmotivoDetalle() As String
        Get
            Return _codmotivoDetalle
        End Get
        Set(ByVal value As String)
            _codmotivoDetalle = value
        End Set
    End Property
    Public Property motivoDetalle() As String
        Get
            Return _motivoDetalle
        End Get
        Set(ByVal value As String)
            _motivoDetalle = value
        End Set
    End Property
    Public Property Serie() As String
        Get
            Return _serie
        End Get
        Set(ByVal value As String)
            _serie = value
        End Set
    End Property
    Public Property tipodeposito() As String
        Get
            Return _tipodeposito
        End Get
        Set(ByVal value As String)
            _tipodeposito = value
        End Set
    End Property
    Public Property nrocta() As String
        Get
            Return _nrocta
        End Get
        Set(ByVal value As String)
            _nrocta = value
        End Set
    End Property
    Public Property banco() As String
        Get
            Return _banco
        End Get
        Set(ByVal value As String)
            _banco = value
        End Set
    End Property
    Public Property nrodoc() As String
        Get
            Return _nrodoc
        End Get
        Set(ByVal value As String)
            _nrodoc = value
        End Set
    End Property

    Public Property codTipoDoc() As String
        Get
            Return _codtipodoc
        End Get
        Set(ByVal value As String)
            _codtipodoc = value
        End Set
    End Property

    Public Property idComp() As Int32
        Get
            Return _idComp
        End Get
        Set(ByVal value As Int32)
            _idComp = value
        End Set
    End Property

    Public Property fila() As Int32
        Get
            Return _fila
        End Get
        Set(ByVal value As Int32)
            _fila = value
        End Set
    End Property

    Public Property montoDevolucion() As Double
        Get
            Return _montoDevolucion
        End Get
        Set(ByVal value As Double)
            _montoDevolucion = value
        End Set
    End Property

    Public Property montoReintegro() As Double
        Get
            Return _montoReintegro
        End Get
        Set(ByVal value As Double)
            _montoReintegro = value
        End Set
    End Property

    Public Property codAuxiliar() As String
        Get
            Return _codAuxiliar
        End Get
        Set(ByVal value As String)
            _codAuxiliar = value
        End Set
    End Property

    Public Property Concepto() As String
        Get
            Return _Concepto
        End Get
        Set(ByVal value As String)
            _Concepto = value
        End Set
    End Property

    Public Property Conceptos() As DataTable
        Get
            Return _Conceptos
        End Get
        Set(ByVal value As DataTable)
            _Conceptos = value
        End Set
    End Property
    Public Property nroruc() As String
        Get
            Return _nroruc
        End Get
        Set(ByVal value As String)
            _nroruc = value
        End Set
    End Property
    Public Property item() As Int32
        Get
            Return _item
        End Get
        Set(ByVal value As Int32)
            _item = value
        End Set
    End Property
    Public Property fechaComp() As DateTime
        Get
            Return _fechaComp
        End Get
        Set(ByVal value As DateTime)
            _fechaComp = value
        End Set
    End Property
    Public Property TipoDoc() As String
        Get
            Return _tipodoc
        End Get
        Set(ByVal value As String)
            _tipodoc = value
        End Set
    End Property
    Public Property NumDoc() As String
        Get
            Return _numdoc
        End Get
        Set(ByVal value As String)
            _numdoc = value
        End Set
    End Property

    Public Property NumDocdevo() As String
        Get
            Return _NumDocdevo
        End Get
        Set(ByVal value As String)
            _NumDocdevo = value
        End Set
    End Property
    Public Property Razon() As String
        Get
            Return _razon
        End Get
        Set(ByVal value As String)
            _razon = value
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
    Public Property codcencos() As String
        Get
            Return _codcencos
        End Get
        Set(ByVal value As String)
            _codcencos = value
        End Set
    End Property

    Public Property dni() As String
        Get
            Return _dni
        End Get
        Set(ByVal value As String)
            _dni = value
        End Set
    End Property

    Public Property Region() As String
        Get
            Return _Region
        End Get
        Set(ByVal value As String)
            _Region = value
        End Set
    End Property
    Public Property TipoOperacion() As Int32
        Get
            Return _TipoOperacion
        End Get
        Set(ByVal value As Int32)
            _TipoOperacion = value
        End Set
    End Property
    Public Property fechaRetorno() As Date
        Get
            Return _fechaRetorno
        End Get
        Set(ByVal value As Date)
            _fechaRetorno = value
        End Set
    End Property
    Public Property fechaSalida() As Date
        Get
            Return _fechaSalida
        End Get
        Set(ByVal value As Date)
            _fechaSalida = value
        End Set
    End Property
    Public Property montoTotal() As Double
        Get
            Return _montoTotal
        End Get
        Set(ByVal value As Double)
            _montoTotal = value
        End Set
    End Property

    Public Property montoTotalParcial() As Double
        Get
            Return _montoTotalParcial
        End Get
        Set(ByVal value As Double)
            _montoTotalParcial = value
        End Set
    End Property
    Dim _Galones As Double = 0
    Public Property Galones() As Double
        Get
            Return _Galones
        End Get
        Set(ByVal value As Double)
            _Galones = value
        End Set
    End Property

    Public Property montoParcial() As Double
        Get
            Return _montoParcial
        End Get
        Set(ByVal value As Double)
            _montoParcial = value
        End Set
    End Property

    Public Property codConcepto() As String
        Get
            Return _codConcepto
        End Get
        Set(ByVal value As String)
            _codConcepto = value
        End Set
    End Property


    Public Property totaldias() As Int32
        Get
            Return _totaldias
        End Get
        Set(ByVal value As Int32)
            _totaldias = value
        End Set
    End Property


    Public Property CodSolicitud() As String
        Get
            Return _CodSolicitud
        End Get
        Set(ByVal value As String)
            _CodSolicitud = value
        End Set
    End Property
    Public Property NumSolicitud() As String
        Get
            Return _NumSolicitud
        End Get
        Set(ByVal value As String)
            _NumSolicitud = value
        End Set
    End Property
    Public Property CodTrabajador() As String
        Get
            Return _CodTrabajador
        End Get
        Set(ByVal value As String)
            _CodTrabajador = value
        End Set
    End Property
    Public Property NomTrabajador() As String
        Get
            Return _NomTrabajador
        End Get
        Set(ByVal value As String)
            _NomTrabajador = value
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
    Public Property Producto() As String
        Get
            Return _Producto
        End Get
        Set(ByVal value As String)
            _Producto = value
        End Set
    End Property

    Public Property JefeArea() As String
        Get
            Return _JefeArea
        End Get
        Set(ByVal value As String)
            _JefeArea = value
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
    Public Property Motivo() As String
        Get
            Return _Motivo
        End Get
        Set(ByVal value As String)
            _Motivo = value
        End Set
    End Property
    Public Property codArea() As String
        Get
            Return _codArea
        End Get
        Set(ByVal value As String)
            _codArea = value
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

    Public Property Areabd() As String
        Get
            Return _Areabd
        End Get
        Set(ByVal value As String)
            _Areabd = value
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
    Public Property idEstado() As Int32
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Int32)
            _idEstado = value
        End Set
    End Property
    Public Property codCantera() As String
        Get
            Return _codCantera
        End Get
        Set(ByVal value As String)
            _codCantera = value
        End Set
    End Property
    Public Property Cantera() As String
        Get
            Return _Cantera
        End Get
        Set(ByVal value As String)
            _Cantera = value
        End Set
    End Property
    Public Property codCanteradet() As String
        Get
            Return _codCanteradet
        End Get
        Set(ByVal value As String)
            _codCanteradet = value
        End Set
    End Property
    Private _comentario As String = String.Empty
    Public Property comentario() As String
        Get
            Return _comentario
        End Get
        Set(ByVal value As String)
            _comentario = value
        End Set
    End Property
    Private _gastoAlimentacion As Double = 0
    Public Property gastoAlimentacion() As Double
        Get
            Return _gastoAlimentacion
        End Get
        Set(ByVal value As Double)
            _gastoAlimentacion = value
        End Set
    End Property
    Private _gastoHospedaje As Double = 0
    Public Property gastoHospedaje() As Double
        Get
            Return _gastoHospedaje
        End Get
        Set(ByVal value As Double)
            _gastoHospedaje = value
        End Set
    End Property
    Private _gastoMovilidad As Double = 0
    Public Property gastoMovilidad() As Double
        Get
            Return _gastoMovilidad
        End Get
        Set(ByVal value As Double)
            _gastoMovilidad = value
        End Set
    End Property
    Private _codMineral As String = String.Empty
    Public Property codMineral() As String
        Get
            Return _codMineral
        End Get
        Set(ByVal value As String)
            _codMineral = value
        End Set
    End Property
    Private _Mineral As String = String.Empty
    Public Property Mineral() As String
        Get
            Return _Mineral
        End Get
        Set(ByVal value As String)
            _Mineral = value
        End Set
    End Property
    Private _codUEA As String = String.Empty
    Public Property codUEA() As String
        Get
            Return _codUEA
        End Get
        Set(ByVal value As String)
            _codUEA = value
        End Set
    End Property
    Private _UEA As String = String.Empty
    Public Property UEA() As String
        Get
            Return _UEA
        End Get
        Set(ByVal value As String)
            _UEA = value
        End Set
    End Property
    Private _acumulado As Double = 0
    Public Property acumulado() As Double
        Get
            Return _acumulado
        End Get
        Set(ByVal value As Double)
            _acumulado = value
        End Set
    End Property
    Private _tipoIngreso As String = String.Empty
    Public Property tipoIngreso() As String
        Get
            Return _tipoIngreso
        End Get
        Set(ByVal value As String)
            _tipoIngreso = value
        End Set
    End Property
    Private _año As Int32 = 0
    Public Property año() As Int32
        Get
            Return _año
        End Get
        Set(ByVal value As Int32)
            _año = value
        End Set
    End Property

    '<JOSF 26/12/2022>
    'Public Property flgKilometraje() As String
    '    Get
    '        Return _flgKilometraje
    '    End Get
    '    Set(ByVal value As String)
    '        _flgKilometraje = value
    '    End Set
    'End Property

    Dim _Kilometraje As Double = 0
    Public Property Kilometraje() As Double
        Get
            Return _Kilometraje
        End Get
        Set(ByVal value As Double)
            _Kilometraje = value
        End Set
    End Property
    '</JOSF 26/12/2022>


    ' Propiedad para FechaInicioPeriodo
    Public Property FechaInicioPeriodo() As Date
        Get
            Return _FechaInicioPeriodo
        End Get
        Set(ByVal value As Date)
            _FechaInicioPeriodo = value
        End Set
    End Property

    ' Propiedad para FechaFinPeriodo
    Public Property FechaFinPeriodo() As Date
        Get
            Return _FechaFinPeriodo
        End Get
        Set(ByVal value As Date)
            _FechaFinPeriodo = value
        End Set
    End Property

    ' Propiedad para DiasPeriodo
    Public Property DiasPeriodo() As Integer
        Get
            Return _DiasPeriodo
        End Get
        Set(ByVal value As Integer)
            _DiasPeriodo = value
        End Set
    End Property

    ' Propiedad para LimiteCredito
    Public Property LimiteCredito() As Decimal
        Get
            Return _LimiteCredito
        End Get
        Set(ByVal value As Decimal)
            _LimiteCredito = value
        End Set
    End Property

    ' Propiedad para TotalConsumido
    Public Property TotalConsumido() As Decimal
        Get
            Return _TotalConsumido
        End Get
        Set(ByVal value As Decimal)
            _TotalConsumido = value
        End Set
    End Property

    ' Propiedad para SaldoDisponible
    Public Property SaldoDisponible() As Decimal
        Get
            Return _SaldoDisponible
        End Get
        Set(ByVal value As Decimal)
            _SaldoDisponible = value
        End Set
    End Property

    ' Propiedad para EstadoCredito
    Public Property EstadoCredito() As String
        Get
            Return _EstadoCredito
        End Get
        Set(ByVal value As String)
            _EstadoCredito = value
        End Set
    End Property



End Class
