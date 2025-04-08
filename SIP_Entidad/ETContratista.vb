Public Class ETContratista
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
    Private _Estado As String = String.Empty
    Private _idEstado As Int32 = 0
    Private _validacion As Int32 = 0
    'Private _codCantera As String = String.Empty
    Private _codCanteradet As String = String.Empty
    'Private _Cantera As String = String.Empty

    Private _codConcepto As String = String.Empty
    Private _totaldias As Int32 = 0
    Private _montoParcial As Double = 0
    Private _montoTotalParcial As Double = 0
    Private _montoTotal As Double = 0
    Private _dscto As Double = 0

    Private _fechaSalida As Date = Date.Now
    Private _fechaRetorno As Date = Date.Now
    Private _TipoOperacion As Int32 = 0
    Private _Region As String = String.Empty
    'Private _Descripcion As String = String.Empty

    Private _fechaComp As DateTime
    Private _tipodoc As String = String.Empty
    Private _codtipodoc As String = String.Empty
    Private _numdoc As String = String.Empty
    Private _numdocdevo As String = String.Empty
    'Private _razon As String = String.Empty
    Private _nroruc As String = String.Empty
    'Private _item As Int32
    Private _codAuxiliar As String = String.Empty
    Private _Concepto As String = String.Empty
    Private _Conceptos As DataTable
    Private _montoDevolucion As Double = 0
    Private _montoReintegro As Double = 0
    Private _idComp As Int32
    Private _fila As Int32

    Private _tipodeposito As String = String.Empty
    'Private _nrocta As String = String.Empty
    'Private _banco As String = String.Empty
    Private _nrodoc As String = String.Empty
    'Private _serie As String = String.Empty
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
    'Private _check As Int32 = 0
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
    Private _tipofiltro As String = String.Empty
    Private _TipoImpresion As Int32
    Private _flgpermiso As Int32
    Private _dias As Int32
    Private _personas As Int32
    Private _flgprovision As Int32
    Private _flgreal As Int32
    Private _nfila As Int32
    Private _activo As Int32
    Private _supervisor As String = String.Empty
    Private _contador As String = String.Empty
    Private _renta As Int32
    Private _hora As String = String.Empty

    Private _COD_PROCESO As String
    Private _TIPO_ANT As String
    Private _FECHAEMISION As Date
    Private _FECHAVTO As Date
    Private _MOVBCO As String
    Private _NROASIGNADO As String
    Private _PLANILLA As String
    Private _IMPORTE As Double
    Private _TCAMBIO As Double
    Private _VOUCHER As String
    Private _FECHA_PROC As Date
    Private _IMPCONT As Double
    Private _TIPO_DOC_CAN As String
    Private _COD_ALM As String

    Private _enero As Double
    Private _febrero As Double
    Private _marzo As Double
    Private _abril As Double
    Private _mayo As Double
    Private _junio As Double
    Private _julio As Double
    Private _agosto As Double
    Private _septiembre As Double
    Private _octubre As Double
    Private _noviembre As Double
    Private _diciembre As Double


    Public Comentarios As String



    Public Property COD_ALM() As String
        Get
            Return _COD_ALM
        End Get
        Set(ByVal value As String)
            _COD_ALM = value
        End Set
    End Property

    Public Property TIPO_DOC_CAN() As String
        Get
            Return _TIPO_DOC_CAN
        End Get
        Set(ByVal value As String)
            _TIPO_DOC_CAN = value
        End Set
    End Property

    Public Property VOUCHER() As String
        Get
            Return _VOUCHER
        End Get
        Set(ByVal value As String)
            _VOUCHER = value
        End Set
    End Property

    Public Property TCAMBIO() As Double
        Get
            Return _TCAMBIO
        End Get
        Set(ByVal value As Double)
            _TCAMBIO = value
        End Set
    End Property

    Public Property PLANILLA() As String
        Get
            Return _PLANILLA
        End Get
        Set(ByVal value As String)
            _PLANILLA = value
        End Set
    End Property

    Public Property COD_PROCESO() As String
        Get
            Return _COD_PROCESO
        End Get
        Set(ByVal value As String)
            _COD_PROCESO = value
        End Set
    End Property
    Public Property TIPO_ANT() As String
        Get
            Return _TIPO_ANT
        End Get
        Set(ByVal value As String)
            _TIPO_ANT = value
        End Set
    End Property
    Public Property MOVBCO() As String
        Get
            Return _MOVBCO
        End Get
        Set(ByVal value As String)
            _MOVBCO = value
        End Set
    End Property

    Public Property NROASIGNADO() As String
        Get
            Return _NROASIGNADO
        End Get
        Set(ByVal value As String)
            _NROASIGNADO = value
        End Set
    End Property


    Public Property hora() As String
        Get
            Return _hora
        End Get
        Set(ByVal value As String)
            _hora = value
        End Set
    End Property

    Public Property renta() As Int32
        Get
            Return _renta
        End Get
        Set(ByVal value As Int32)
            _renta = value
        End Set
    End Property

    Public Property supervisor() As String
        Get
            Return _supervisor
        End Get
        Set(ByVal value As String)
            _supervisor = value
        End Set
    End Property

    Public Property contador() As String
        Get
            Return _contador
        End Get
        Set(ByVal value As String)
            _contador = value
        End Set
    End Property

    Public Property activo() As Int32
        Get
            Return _activo
        End Get
        Set(ByVal value As Int32)
            _activo = value
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
    'Public Property nrocta() As String
    '    Get
    '        Return _nrocta
    '    End Get
    '    Set(ByVal value As String)
    '        _nrocta = value
    '    End Set
    'End Property
    'Public Property banco() As String
    '    Get
    '        Return _banco
    '    End Get
    '    Set(ByVal value As String)
    '        _banco = value
    '    End Set
    'End Property
    Public Property nrodoc() As String
        Get
            Return _nrodoc
        End Get
        Set(ByVal value As String)
            _nrodoc = value
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
    Public Property montoTotal() As Double
        Get
            Return _montoTotal
        End Get
        Set(ByVal value As Double)
            _montoTotal = value
        End Set
    End Property
    Public Property dscto() As Double
        Get
            Return _dscto
        End Get
        Set(ByVal value As Double)
            _dscto = value
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

    Public Property validacion_() As Int32
        Get
            Return _validacion
        End Get
        Set(ByVal value As Int32)
            _validacion = value
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

    Dim idcontratista As Int32
    Public Property _idcontratista() As Int32
        Get
            Return idcontratista
        End Get
        Set(ByVal value As Int32)
            idcontratista = value
        End Set
    End Property
    Shadows id As Int32
    Public Property _id() As Int32
        Get
            Return id
        End Get
        Set(ByVal value As Int32)
            id = value
        End Set
    End Property

    Dim item As Int32
    Public Property _item() As Int32
        Get
            Return item
        End Get
        Set(ByVal value As Int32)
            item = value
        End Set
    End Property

    Dim check As Int32
    Public Property _check() As Int32
        Get
            Return check
        End Get
        Set(ByVal value As Int32)
            check = value
        End Set
    End Property

    Dim check2 As Int32
    Public Property _check2() As Int32
        Get
            Return check2
        End Get
        Set(ByVal value As Int32)
            check2 = value
        End Set
    End Property

    Dim check3 As Int32
    Public Property _check3() As Int32
        Get
            Return check3
        End Get
        Set(ByVal value As Int32)
            check3 = value
        End Set
    End Property

    Dim flgtercero As Int32
    Public Property _flgtercero() As Int32
        Get
            Return flgtercero
        End Get
        Set(ByVal value As Int32)
            flgtercero = value
        End Set
    End Property

    Dim ndias As Int32
    Public Property _ndias() As Int32
        Get
            Return ndias
        End Get
        Set(ByVal value As Int32)
            ndias = value
        End Set
    End Property

    Dim flgcontratista As Int32
    Public Property _flgcontratista() As Int32
        Get
            Return flgcontratista
        End Get
        Set(ByVal value As Int32)
            flgcontratista = value
        End Set
    End Property

    Dim tipopago As String
    Public Property _tipopago() As String
        Get
            Return tipopago
        End Get
        Set(ByVal value As String)
            tipopago = value
        End Set
    End Property

    Dim horo_ini As String
    Public Property _horo_ini() As String
        Get
            Return horo_ini
        End Get
        Set(ByVal value As String)
            horo_ini = value
        End Set
    End Property

    Dim horo_fin As String
    Public Property _horo_fin() As String
        Get
            Return horo_fin
        End Get
        Set(ByVal value As String)
            horo_fin = value
        End Set
    End Property

    Dim labor As String
    Public Property _labor() As String
        Get
            Return labor
        End Get
        Set(ByVal value As String)
            labor = value
        End Set
    End Property

    Dim actividad As String
    Public Property _actividad() As String
        Get
            Return actividad
        End Get
        Set(ByVal value As String)
            actividad = value
        End Set
    End Property

    Dim idfrecpago As Int32
    Public Property _idfrecpago() As Int32
        Get
            Return idfrecpago
        End Get
        Set(ByVal value As Int32)
            idfrecpago = value
        End Set
    End Property
    Shadows usuario As String
    Public Property _usuario() As String
        Get
            Return usuario
        End Get
        Set(ByVal value As String)
            usuario = value
        End Set
    End Property

    Dim codprov As String
    Public Property _codprov() As String
        Get
            Return codprov
        End Get
        Set(ByVal value As String)
            codprov = value
        End Set
    End Property

    Dim precio As Double
    Public Property _precio() As Double
        Get
            Return precio
        End Get
        Set(ByVal value As Double)
            precio = value
        End Set
    End Property

    Dim codprod As String
    Public Property _codprod() As String
        Get
            Return codprod
        End Get
        Set(ByVal value As String)
            codprod = value
        End Set
    End Property

    Dim codprog As Int32
    Public Property _codprog() As Int32
        Get
            Return codprog
        End Get
        Set(ByVal value As Int32)
            codprog = value
        End Set
    End Property

    Dim codcantera As String
    Public Property _codcantera() As String
        Get
            Return codcantera
        End Get
        Set(ByVal value As String)
            codcantera = value
        End Set
    End Property
    Dim cantera As String
    Public Property _cantera() As String
        Get
            Return cantera
        End Get
        Set(ByVal value As String)
            cantera = value
        End Set
    End Property

    Dim codequipo As String
    Public Property _codequipo() As String
        Get
            Return codequipo
        End Get
        Set(ByVal value As String)
            codequipo = value
        End Set
    End Property

    Shadows tipo As Int32
    Public Property _tipo() As Int32
        Get
            Return tipo
        End Get
        Set(ByVal value As Int32)
            tipo = value
        End Set
    End Property

    Shadows semana As Int32
    Public Property _semana() As Int32
        Get
            Return semana
        End Get
        Set(ByVal value As Int32)
            semana = value
        End Set
    End Property

    Dim ayo As Int32
    Public Property _ayo() As Int32
        Get
            Return ayo
        End Get
        Set(ByVal value As Int32)
            ayo = value
        End Set
    End Property

    Shadows mes As Int32
    Public Property _mes() As Int32
        Get
            Return mes
        End Get
        Set(ByVal value As Int32)
            mes = value
        End Set
    End Property

    Shadows dia As Int32
    Public Property _dia() As Int32
        Get
            Return dia
        End Get
        Set(ByVal value As Int32)
            dia = value
        End Set
    End Property

    Dim quincena As Int32
    Public Property _quincena() As Int32
        Get
            Return quincena
        End Get
        Set(ByVal value As Int32)
            quincena = value
        End Set
    End Property

    Dim semanaini As Int32
    Public Property _semanaini() As Int32
        Get
            Return semanaini
        End Get
        Set(ByVal value As Int32)
            semanaini = value
        End Set
    End Property

    Dim semanafin As Int32
    Public Property _semanafin() As Int32
        Get
            Return semanafin
        End Get
        Set(ByVal value As Int32)
            semanafin = value
        End Set
    End Property

    Dim idtrabajador As Int32
    Public Property _idtrabajador() As Int32
        Get
            Return idtrabajador
        End Get
        Set(ByVal value As Int32)
            idtrabajador = value
        End Set
    End Property

    Dim flgcese As Int32
    Public Property _flgcese() As Int32
        Get
            Return flgcese
        End Get
        Set(ByVal value As Int32)
            flgcese = value
        End Set
    End Property

    Dim tipodocumento As String
    Public Property _tipodocumento() As String
        Get
            Return tipodocumento
        End Get
        Set(ByVal value As String)
            tipodocumento = value
        End Set
    End Property

    Dim placa As String
    Public Property _placa() As String
        Get
            Return placa
        End Get
        Set(ByVal value As String)
            placa = value
        End Set
    End Property

    Dim placa2 As String
    Public Property _placa2() As String
        Get
            Return placa2
        End Get
        Set(ByVal value As String)
            placa2 = value
        End Set
    End Property

    Dim chofer As String
    Public Property _chofer() As String
        Get
            Return chofer
        End Get
        Set(ByVal value As String)
            chofer = value
        End Set
    End Property

    Dim cod_prod As String
    Public Property _cod_prod() As String
        Get
            Return cod_prod
        End Get
        Set(ByVal value As String)
            cod_prod = value
        End Set
    End Property

    Dim cod_sunat As String
    Public Property _cod_sunat() As String
        Get
            Return cod_sunat
        End Get
        Set(ByVal value As String)
            cod_sunat = value
        End Set
    End Property

    Dim documento As String
    Public Property _documento() As String
        Get
            Return documento
        End Get
        Set(ByVal value As String)
            documento = value
        End Set
    End Property

    Dim serie As String
    Public Property _serie() As String
        Get
            Return serie
        End Get
        Set(ByVal value As String)
            serie = value
        End Set
    End Property

    Dim serie_transp As String
    Public Property _serie_transp() As String
        Get
            Return serie_transp
        End Get
        Set(ByVal value As String)
            serie_transp = value
        End Set
    End Property

    Dim numero_transp As String
    Public Property _numero_transp() As String
        Get
            Return numero_transp
        End Get
        Set(ByVal value As String)
            numero_transp = value
        End Set
    End Property

    Dim cod_transp As String
    Public Property _cod_transp() As String
        Get
            Return cod_transp
        End Get
        Set(ByVal value As String)
            cod_transp = value
        End Set
    End Property

    Dim apepat As String
    Public Property _apepat() As String
        Get
            Return apepat
        End Get
        Set(ByVal value As String)
            apepat = value
        End Set
    End Property
    Dim apemat As String
    Public Property _apemat() As String
        Get
            Return apemat
        End Get
        Set(ByVal value As String)
            apemat = value
        End Set
    End Property

    Dim nombres As String
    Public Property _nombres() As String
        Get
            Return nombres
        End Get
        Set(ByVal value As String)
            nombres = value
        End Set
    End Property

    Shadows fechaingreso As Date
    Public Property _fechaingreso() As Date
        Get
            Return fechaingreso
        End Get
        Set(ByVal value As Date)
            fechaingreso = value
        End Set
    End Property
    Dim fechacese As Date
    Public Property _fechacese() As Date
        Get
            Return fechacese
        End Get
        Set(ByVal value As Date)
            fechacese = value
        End Set
    End Property

    Dim sueldo As Double
    Public Property _sueldo() As Double
        Get
            Return sueldo
        End Get
        Set(ByVal value As Double)
            sueldo = value
        End Set
    End Property

    Dim tonxhora As Double
    Public Property _tonxhora() As Double
        Get
            Return tonxhora
        End Get
        Set(ByVal value As Double)
            tonxhora = value
        End Set
    End Property

    Dim pago As Double
    Public Property _pago() As Double
        Get
            Return pago
        End Get
        Set(ByVal value As Double)
            pago = value
        End Set
    End Property
    Dim peso As Double
    Public Property _peso() As Double
        Get
            Return peso
        End Get
        Set(ByVal value As Double)
            peso = value
        End Set
    End Property

    Dim peso2 As Double
    Public Property _peso2() As Double
        Get
            Return peso2
        End Get
        Set(ByVal value As Double)
            peso2 = value
        End Set
    End Property

    Dim neto As Double
    Public Property _neto() As Double
        Get
            Return neto
        End Get
        Set(ByVal value As Double)
            neto = value
        End Set
    End Property

    Dim configveh As String
    Public Property _configveh() As String
        Get
            Return configveh
        End Get
        Set(ByVal value As String)
            configveh = value
        End Set
    End Property

    Dim onp As Double
    Public Property _onp() As Double
        Get
            Return onp
        End Get
        Set(ByVal value As Double)
            onp = value
        End Set
    End Property

    Dim afp As Double
    Public Property _afp() As Double
        Get
            Return afp
        End Get
        Set(ByVal value As Double)
            afp = value
        End Set
    End Property

    Dim essalud As Double
    Public Property _essalud() As Double
        Get
            Return essalud
        End Get
        Set(ByVal value As Double)
            essalud = value
        End Set
    End Property
    Dim essalud_vida As Double
    Public Property _essalud_vida() As Double
        Get
            Return essalud_vida
        End Get
        Set(ByVal value As Double)
            essalud_vida = value
        End Set
    End Property

    Dim quinta As Double
    Public Property _quinta() As Double
        Get
            Return quinta
        End Get
        Set(ByVal value As Double)
            quinta = value
        End Set
    End Property

    Dim sctr As Double
    Public Property _sctr() As Double
        Get
            Return sctr
        End Get
        Set(ByVal value As Double)
            sctr = value
        End Set
    End Property
    Dim sctr_salud As Double
    Public Property _sctr_salud() As Double
        Get
            Return sctr_salud
        End Get
        Set(ByVal value As Double)
            sctr_salud = value
        End Set
    End Property

    Dim afpcomp As Double
    Public Property _afpcomp() As Double
        Get
            Return afpcomp
        End Get
        Set(ByVal value As Double)
            afpcomp = value
        End Set
    End Property

    Dim fminero As Double
    Public Property _fminero() As Double
        Get
            Return fminero
        End Get
        Set(ByVal value As Double)
            fminero = value
        End Set
    End Property

    Dim gratificacion As Double
    Public Property _gratificacion() As Double
        Get
            Return gratificacion
        End Get
        Set(ByVal value As Double)
            gratificacion = value
        End Set
    End Property

    Dim cts As Double
    Public Property _cts() As Double
        Get
            Return cts
        End Get
        Set(ByVal value As Double)
            cts = value
        End Set
    End Property

    Dim bonificacion As Double
    Public Property _bonificacion() As Double
        Get
            Return bonificacion
        End Get
        Set(ByVal value As Double)
            bonificacion = value
        End Set
    End Property

    Dim codafp As String
    Public Property _codafp() As String
        Get
            Return codafp
        End Get
        Set(ByVal value As String)
            codafp = value
        End Set
    End Property

    Dim flgessalud As String
    Public Property _flgessalud() As String
        Get
            Return flgessalud
        End Get
        Set(ByVal value As String)
            flgessalud = value
        End Set
    End Property

    Dim banco As String
    Public Property _banco() As String
        Get
            Return banco
        End Get
        Set(ByVal value As String)
            banco = value
        End Set
    End Property

    Dim nrocta As String
    Public Property _nrocta() As String
        Get
            Return nrocta
        End Get
        Set(ByVal value As String)
            nrocta = value
        End Set
    End Property

    Dim ruc As String
    Public Property _ruc() As String
        Get
            Return ruc
        End Get
        Set(ByVal value As String)
            ruc = value
        End Set
    End Property

    Dim razon As String
    Public Property _razon() As String
        Get
            Return razon
        End Get
        Set(ByVal value As String)
            razon = value
        End Set
    End Property

    Dim responsable As String
    Public Property _responsable() As String
        Get
            Return responsable
        End Get
        Set(ByVal value As String)
            responsable = value
        End Set
    End Property

    Dim tipoanticipo As String
    Public Property _tipoanticipo() As String
        Get
            Return tipoanticipo
        End Get
        Set(ByVal value As String)
            tipoanticipo = value
        End Set
    End Property


    Dim desctipoanticipo As String
    Public Property _desctipoanticipo() As String
        Get
            Return desctipoanticipo
        End Get
        Set(ByVal value As String)
            desctipoanticipo = value
        End Set
    End Property

    Dim variacion As String
    Public Property _variacion() As String
        Get
            Return variacion
        End Get
        Set(ByVal value As String)
            variacion = value
        End Set
    End Property
  
    Dim fecha1 As Date
    Public Property _fecha1() As Date
        Get
            Return fecha1
        End Get
        Set(ByVal value As Date)
            fecha1 = value
        End Set
    End Property
    Dim fecha2 As Date
    Public Property _fecha2() As Date
        Get
            Return fecha2
        End Get
        Set(ByVal value As Date)
            fecha2 = value
        End Set
    End Property
    Dim descripcion As String
    Public Property _descripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Dim ruta As String
    Public Property _ruta() As String
        Get
            Return ruta
        End Get
        Set(ByVal value As String)
            ruta = value
        End Set
    End Property

    Dim modelo As String
    Public Property _modelo() As String
        Get
            Return modelo
        End Get
        Set(ByVal value As String)
            modelo = value
        End Set
    End Property
    Dim idconcepto As Int32
    Public Property _idconcepto() As Int32
        Get
            Return idconcepto
        End Get
        Set(ByVal value As Int32)
            idconcepto = value
        End Set
    End Property

    Dim contratista As String
    Public Property _contratista() As String
        Get
            Return contratista
        End Get
        Set(ByVal value As String)
            contratista = value
        End Set
    End Property

    Dim idanticipo As Int32
    Public Property _idanticipo() As Int32
        Get
            Return idanticipo
        End Get
        Set(ByVal value As Int32)
            idanticipo = value
        End Set
    End Property

    Dim billete As String
    Public Property _billete() As String
        Get
            Return billete
        End Get
        Set(ByVal value As String)
            billete = value
        End Set
    End Property

    Dim codmineral As String
    Public Property _codmineral() As String
        Get
            Return codmineral
        End Get
        Set(ByVal value As String)
            codmineral = value
        End Set
    End Property

    Dim mineral As String
    Public Property _mineral() As String
        Get
            Return mineral
        End Get
        Set(ByVal value As String)
            mineral = value
        End Set
    End Property

    Dim comentario As String
    Public Property _comentario() As String
        Get
            Return comentario
        End Get
        Set(ByVal value As String)
            comentario = value
        End Set
    End Property

    Dim billeteref As String
    Public Property _billeteref() As String
        Get
            Return billeteref
        End Get
        Set(ByVal value As String)
            billeteref = value
        End Set
    End Property
    Dim toneladas As Double
    Public Property _toneladas() As Double
        Get
            Return toneladas
        End Get
        Set(ByVal value As Double)
            toneladas = value
        End Set
    End Property

    Dim galon As Double
    Public Property _galon() As Double
        Get
            Return galon
        End Get
        Set(ByVal value As Double)
            galon = value
        End Set
    End Property

    Dim galon_hora As Double
    Public Property _galon_hora() As Double
        Get
            Return galon_hora
        End Get
        Set(ByVal value As Double)
            galon_hora = value
        End Set
    End Property

    Dim importe_NC As Double
    Public Property _importe_NC() As Double
        Get
            Return importe_NC
        End Get
        Set(ByVal value As Double)
            importe_NC = value
        End Set
    End Property

    Dim preciofactura As Double
    Public Property _preciofactura() As Double
        Get
            Return preciofactura
        End Get
        Set(ByVal value As Double)
            preciofactura = value
        End Set
    End Property

    Shadows porcentaje As Double
    Public Property _porcentaje() As Double
        Get
            Return porcentaje
        End Get
        Set(ByVal value As Double)
            porcentaje = value
        End Set
    End Property

    Dim valorvta As Double
    Public Property _valorvta() As Double
        Get
            Return valorvta
        End Get
        Set(ByVal value As Double)
            valorvta = value
        End Set
    End Property

    Dim igv As Double
    Public Property _igv() As Double
        Get
            Return igv
        End Get
        Set(ByVal value As Double)
            igv = value
        End Set
    End Property

    Dim valor As Double
    Public Property _valor() As Double
        Get
            Return valor
        End Get
        Set(ByVal value As Double)
            valor = value
        End Set
    End Property

    Dim orden As Int32
    Public Property _orden() As Int32
        Get
            Return orden
        End Get
        Set(ByVal value As Int32)
            orden = value
        End Set
    End Property
    
    Dim numorden As String
    Public Property _numorden() As String
        Get
            Return numorden
        End Get
        Set(ByVal value As String)
            numorden = value
        End Set
    End Property

    Shadows aprobado As String
    Public Property _aprobado() As String
        Get
            Return aprobado
        End Get
        Set(ByVal value As String)
            aprobado = value
        End Set
    End Property

    Dim nota_credito As String
    Public Property _nota_credito() As String
        Get
            Return nota_credito
        End Get
        Set(ByVal value As String)
            nota_credito = value
        End Set
    End Property

    Dim numcontrato As String
    Public Property _numcontrato() As String
        Get
            Return numcontrato
        End Get
        Set(ByVal value As String)
            numcontrato = value
        End Set
    End Property
    Dim observacion As String
    Public Property _observacion() As String
        Get
            Return observacion
        End Get
        Set(ByVal value As String)
            observacion = value
        End Set
    End Property

    Dim marca As String
    Public Property _marca() As String
        Get
            Return marca
        End Get
        Set(ByVal value As String)
            marca = value
        End Set
    End Property

    Dim concentracion As String
    Public Property _concentracion() As String
        Get
            Return concentracion
        End Get
        Set(ByVal value As String)
            concentracion = value
        End Set
    End Property

    Dim movi As String
    Public Property _movi() As String
        Get
            Return movi
        End Get
        Set(ByVal value As String)
            movi = value
        End Set
    End Property
    Dim idreferencia As Int32
    Public Property _idreferencia() As Int32
        Get
            Return idreferencia
        End Get
        Set(ByVal value As Int32)
            idreferencia = value
        End Set
    End Property
    Dim flgtrans As Int32
    Public Property _flgtrans() As Int32
        Get
            Return flgtrans
        End Get
        Set(ByVal value As Int32)
            flgtrans = value
        End Set
    End Property
    Dim flgventa As Int32
    Public Property _flgventa() As Int32
        Get
            Return flgventa
        End Get
        Set(ByVal value As Int32)
            flgventa = value
        End Set
    End Property
    Dim flgOC As Int32
    Public Property _flgOC() As Int32
        Get
            Return flgOC
        End Get
        Set(ByVal value As Int32)
            flgOC = value
        End Set
    End Property

    Dim idtipomov As Int32
    Public Property _idtipomov() As Int32
        Get
            Return idtipomov
        End Get
        Set(ByVal value As Int32)
            idtipomov = value
        End Set
    End Property

    Dim tipo_fact As String
    Public Property _tipo_fact() As String
        Get
            Return tipo_fact
        End Get
        Set(ByVal value As String)
            tipo_fact = value
        End Set
    End Property

    Dim tipomaterial As String
    Public Property _tipomaterial() As String
        Get
            Return tipomaterial
        End Get
        Set(ByVal value As String)
            tipomaterial = value
        End Set
    End Property

    Dim codalmori As String
    Public Property _codalmori() As String
        Get
            Return codalmori
        End Get
        Set(ByVal value As String)
            codalmori = value
        End Set
    End Property

    Dim codalmdest As String
    Public Property _codalmdest() As String
        Get
            Return codalmdest
        End Get
        Set(ByVal value As String)
            codalmdest = value
        End Set
    End Property
    Dim codcli As String
    Public Property _codcli() As String
        Get
            Return codcli
        End Get
        Set(ByVal value As String)
            codcli = value
        End Set
    End Property

    Dim codcanteraori As String
    Public Property _codcanteraori() As String
        Get
            Return codcanteraori
        End Get
        Set(ByVal value As String)
            codcanteraori = value
        End Set
    End Property

    Dim codcanteradest As String
    Public Property _codcanteradest() As String
        Get
            Return codcanteradest
        End Get
        Set(ByVal value As String)
            codcanteradest = value
        End Set
    End Property
    Dim numdocori As String
    Public Property _numdocori() As String
        Get
            Return numdocori
        End Get
        Set(ByVal value As String)
            numdocori = value
        End Set
    End Property
    Dim numdocdest As String
    Public Property _numdocdest() As String
        Get
            Return numdocdest
        End Get
        Set(ByVal value As String)
            numdocdest = value
        End Set
    End Property

    Public Property enero() As Double
        Get
            Return _enero
        End Get
        Set(ByVal value As Double)
            _enero = value
        End Set
    End Property

    Public Property febrero() As Double
        Get
            Return _febrero
        End Get
        Set(ByVal value As Double)
            _febrero = value
        End Set
    End Property

    Public Property marzo() As Double
        Get
            Return _marzo
        End Get
        Set(ByVal value As Double)
            _marzo = value
        End Set
    End Property

    Public Property abril() As Double
        Get
            Return _abril
        End Get
        Set(ByVal value As Double)
            _abril = value
        End Set
    End Property

    Public Property mayo() As Double
        Get
            Return _mayo
        End Get
        Set(ByVal value As Double)
            _mayo = value
        End Set
    End Property

    Public Property junio() As Double
        Get
            Return _junio
        End Get
        Set(ByVal value As Double)
            _junio = value
        End Set
    End Property

    Public Property julio() As Double
        Get
            Return _julio
        End Get
        Set(ByVal value As Double)
            _julio = value
        End Set
    End Property

    Public Property agosto() As Double
        Get
            Return _agosto
        End Get
        Set(ByVal value As Double)
            _agosto = value
        End Set
    End Property

    Public Property septiembre() As Double
        Get
            Return _septiembre
        End Get
        Set(ByVal value As Double)
            _septiembre = value
        End Set
    End Property

    Public Property octubre() As Double
        Get
            Return _octubre
        End Get
        Set(ByVal value As Double)
            _octubre = value
        End Set
    End Property

    Public Property noviembre() As Double
        Get
            Return _noviembre
        End Get
        Set(ByVal value As Double)
            _noviembre = value
        End Set
    End Property

    Public Property diciembre() As Double
        Get
            Return _diciembre
        End Get
        Set(ByVal value As Double)
            _diciembre = value
        End Set
    End Property
End Class
