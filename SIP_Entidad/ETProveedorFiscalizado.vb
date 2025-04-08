Public Class ETProveedorFiscalizado
    '	Cod_Cia Char(2) NOT NULL,

    Private Cod_Cia_ As String
    Public Property Cod_Cia() As String
        Get
            Return Cod_Cia_
        End Get
        Set(ByVal value As String)
            Cod_Cia_ = value
        End Set
    End Property

    Private _cod_Almacen As String
    Public Property cod_Almacen() As String
        Get
            Return _cod_Almacen
        End Get
        Set(ByVal value As String)
            _cod_Almacen = value
        End Set
    End Property


    Private _cod_Almacen_Solicitante As String
    Public Property cod_Almacen_Solicitante() As String
        Get
            Return _cod_Almacen_Solicitante
        End Get
        Set(ByVal value As String)
            _cod_Almacen_Solicitante = value
        End Set
    End Property


    Private Cod_Sunat_ As String
    Public Property Cod_Sunat() As String
        Get
            Return Cod_Sunat_
        End Get
        Set(ByVal value As String)
            Cod_Sunat_ = value
        End Set
    End Property

    '	Cod_Prov Char(8) NOT NULL,

    Private Cod_Prov_ As String
    Public Property Cod_Prov() As String
        Get
            Return Cod_Prov_
        End Get
        Set(ByVal value As String)
            Cod_Prov_ = value
        End Set
    End Property

    Private numsolicitud As String
    Public Property _numsolicitud() As String
        Get
            Return numsolicitud
        End Get
        Set(ByVal value As String)
            numsolicitud = value
        End Set
    End Property

    Private moneda As String
    Public Property _moneda() As String
        Get
            Return moneda
        End Get
        Set(ByVal value As String)
            moneda = value
        End Set
    End Property

    Private iddocinterno As Int32
    Public Property _iddocinterno() As Int32
        Get
            Return iddocinterno
        End Get
        Set(ByVal value As Int32)
            iddocinterno = value
        End Set
    End Property

    Private idliquidacion As Int32
    Public Property _idliquidacion() As Int32
        Get
            Return idliquidacion
        End Get
        Set(ByVal value As Int32)
            idliquidacion = value
        End Set
    End Property
    '	FechIniVig Datetime NOT NULL,

    Private FechIniVig_ As Date
    Public Property FechIniVig() As Date
        Get
            Return FechIniVig_
        End Get
        Set(ByVal value As Date)
            FechIniVig_ = value
        End Set
    End Property

    '	FechFinVig Datetime NOT NULL,

    Private FechFinVig_ As Date
    Public Property FechFinVig() As Date
        Get
            Return FechFinVig_
        End Get
        Set(ByVal value As Date)
            FechFinVig_ = value
        End Set
    End Property

    '	Status Char(1) Not Null Default '',

    Private Status_ As String
    Public Property Status() As String
        Get
            Return Status_
        End Get
        Set(ByVal value As String)
            Status_ = value
        End Set
    End Property

    '	User_Crea Char(10) Not Null,

    Private User_Crea_ As String
    Public Property User_Crea() As String
        Get
            Return User_Crea_
        End Get
        Set(ByVal value As String)
            User_Crea_ = value
        End Set
    End Property

    '	Fecha_Crea Datetime Not Null Default Getdate(),

    Private Fecha_Crea_ As Date
    Public Property Fecha_Crea() As Date
        Get
            Return Fecha_Crea_
        End Get
        Set(ByVal value As Date)
            Fecha_Crea_ = value
        End Set
    End Property

    '	User_Modi Char(10),

    Private User_Modi_ As String
    Public Property User_Modi() As String
        Get
            Return User_Modi_
        End Get
        Set(ByVal value As String)
            User_Modi_ = value
        End Set
    End Property

    '	Fecha_Modi datetime

    Private Fecha_Modi_ As String
    Public Property Fecha_Modi() As String
        Get
            Return Fecha_Modi_
        End Get
        Set(ByVal value As String)
            Fecha_Modi_ = value
        End Set
    End Property

    Private RUC_ As String
    Public Property RUC() As String
        Get
            Return RUC_
        End Get
        Set(ByVal value As String)
            RUC_ = value
        End Set
    End Property

    Private RazSoc_ As String
    Public Property RazSoc() As String
        Get
            Return RazSoc_
        End Get
        Set(ByVal value As String)
            RazSoc_ = value
        End Set
    End Property

    Private _mes As Int32
    Public Property mes() As Int32
        Get
            Return _mes
        End Get
        Set(ByVal value As Int32)
            _mes = value
        End Set
    End Property

    Private _id As Int32
    Public Property id() As Int32
        Get
            Return _id
        End Get
        Set(ByVal value As Int32)
            _id = value
        End Set
    End Property

    Private _mes2 As Int32
    Public Property mes2() As Int32
        Get
            Return _mes2
        End Get
        Set(ByVal value As Int32)
            _mes2 = value
        End Set
    End Property

    Private _iduso As Int32
    Public Property iduso() As Int32
        Get
            Return _iduso
        End Get
        Set(ByVal value As Int32)
            _iduso = value
        End Set
    End Property

    Private _molino As String
    Public Property molino() As String
        Get
            Return _molino
        End Get
        Set(ByVal value As String)
            _molino = value
        End Set
    End Property

    Private _año As Int32
    Public Property año() As Int32
        Get
            Return _año
        End Get
        Set(ByVal value As Int32)
            _año = value
        End Set
    End Property

    Private Cod_Prod_ As String
    Public Property Cod_Prod() As String
        Get
            Return Cod_Prod_
        End Get
        Set(ByVal value As String)
            Cod_Prod_ = value
        End Set
    End Property

    Private TipoDoc_ As String
    Public Property TipoDoc() As String
        Get
            Return TipoDoc_
        End Get
        Set(ByVal value As String)
            TipoDoc_ = value
        End Set
    End Property

    Private Ope_ As String
    Public Property Ope() As Int32
        Get
            Return Ope_
        End Get
        Set(ByVal value As Int32)
            Ope_ = value
        End Set
    End Property

    Private Produdcto_ As String
    Public Property Produdcto() As String
        Get
            Return Produdcto_
        End Get
        Set(ByVal value As String)
            Produdcto_ = value
        End Set
    End Property

    Private Presentacion_ As String
    Public Property Presentacion() As String
        Get
            Return Presentacion_
        End Get
        Set(ByVal value As String)
            Presentacion_ = value
        End Set
    End Property

    Private tipo_mov_ As String
    Public Property tipo_mov() As String
        Get
            Return tipo_mov_
        End Get
        Set(ByVal value As String)
            tipo_mov_ = value
        End Set
    End Property

    Private Fecha_ As Date
    Public Property Fecha() As Date
        Get
            Return Fecha_
        End Get
        Set(ByVal value As Date)
            Fecha_ = value
        End Set
    End Property

    Private Observacion_ As String
    Public Property Observacion() As String
        Get
            Return Observacion_
        End Get
        Set(ByVal value As String)
            Observacion_ = value
        End Set
    End Property

    Private T_Mantenimiento_ As String
    Public Property T_Mantenimiento() As String
        Get
            Return T_Mantenimiento_
        End Get
        Set(ByVal value As String)
            T_Mantenimiento_ = value
        End Set
    End Property

    Private cod_area_ As String
    Public Property cod_area() As String
        Get
            Return cod_area_
        End Get
        Set(ByVal value As String)
            cod_area_ = value
        End Set
    End Property

    Private cod_labor_ As String
    Public Property cod_labor() As String
        Get
            Return cod_labor_
        End Get
        Set(ByVal value As String)
            cod_labor_ = value
        End Set
    End Property

    Private cod_anexo3_ As String
    Public Property cod_anexo3() As String
        Get
            Return cod_anexo3_
        End Get
        Set(ByVal value As String)
            cod_anexo3_ = value
        End Set
    End Property

    Private cod_cantera_ As String
    Public Property cod_cantera() As String
        Get
            Return cod_cantera_
        End Get
        Set(ByVal value As String)
            cod_cantera_ = value
        End Set
    End Property

    Private cod_equipo_ As String
    Public Property cod_equipo() As String
        Get
            Return cod_equipo_
        End Get
        Set(ByVal value As String)
            cod_equipo_ = value
        End Set
    End Property

    Private cod_trabajador_ As String
    Public Property cod_trabajador() As String
        Get
            Return cod_trabajador_
        End Get
        Set(ByVal value As String)
            cod_trabajador_ = value
        End Set
    End Property

    Private aprobado_ As String
    Public Property aprobado() As String
        Get
            Return aprobado_
        End Get
        Set(ByVal value As String)
            aprobado_ = value
        End Set
    End Property

    Private urgente_ As String
    Public Property urgente() As String
        Get
            Return urgente_
        End Get
        Set(ByVal value As String)
            urgente_ = value
        End Set
    End Property

    Private anulado_ As String
    Public Property anulado() As String
        Get
            Return anulado_
        End Get
        Set(ByVal value As String)
            anulado_ = value
        End Set
    End Property

    Private Cantidad_ As Double
    Public Property Cantidad() As Double
        Get
            Return Cantidad_
        End Get
        Set(ByVal value As Double)
            Cantidad_ = value
        End Set
    End Property

    Private Stock_ As Double
    Public Property Stock() As Double
        Get
            Return Stock_
        End Get
        Set(ByVal value As Double)
            Stock_ = value
        End Set
    End Property

    Private Monto_ As Double
    Public Property Monto() As Double
        Get
            Return Monto_
        End Get
        Set(ByVal value As Double)
            Monto_ = value
        End Set
    End Property

    Private Saldo_ As Double
    Public Property Saldo() As Double
        Get
            Return Saldo_
        End Get
        Set(ByVal value As Double)
            Saldo_ = value
        End Set
    End Property

    Private Unidad_ As String
    Public Property Unidad() As String
        Get
            Return Unidad_
        End Get
        Set(ByVal value As String)
            Unidad_ = value
        End Set
    End Property


    '@pa_gre_id_motivo_traslado char(2),
    Private gre_id_motivo_traslado_ As String
    Public Property gre_id_motivo_traslado() As String
        Get
            Return gre_id_motivo_traslado_
        End Get
        Set(ByVal value As String)
            gre_id_motivo_traslado_ = value
        End Set
    End Property

    '@pa_gre_id_modalidad_traslado char(2),
    Private gre_id_modalidad_traslado_ As String
    Public Property gre_id_modalidad_traslado() As String
        Get
            Return gre_id_modalidad_traslado_
        End Get
        Set(ByVal value As String)
            gre_id_modalidad_traslado_ = value
        End Set
    End Property

    '@pa_gre_dest_id_doc_identidad char(2),
    Private gre_dest_id_doc_identidad_ As String
    Public Property gre_dest_id_doc_identidad() As String
        Get
            Return gre_dest_id_doc_identidad_
        End Get
        Set(ByVal value As String)
            gre_dest_id_doc_identidad_ = value
        End Set
    End Property


    '@pa_gre_dest_nro_doc_identidad char(15),
    Private gre_dest_nro_doc_identidad_ As String
    Public Property gre_dest_nro_doc_identidad() As String
        Get
            Return gre_dest_nro_doc_identidad_
        End Get
        Set(ByVal value As String)
            gre_dest_nro_doc_identidad_ = value
        End Set
    End Property

    '@pa_gre_dest_nombre char(250),
    Private gre_dest_nombre_ As String
    Public Property gre_dest_nombre() As String
        Get
            Return gre_dest_nombre_
        End Get
        Set(ByVal value As String)
            gre_dest_nombre_ = value
        End Set
    End Property

    '@pa_gre_ptollegada_direccion char(500),
    Private gre_ptollegada_direccion_ As String
    Public Property gre_ptollegada_direccion() As String
        Get
            Return gre_ptollegada_direccion_
        End Get
        Set(ByVal value As String)
            gre_ptollegada_direccion_ = value
        End Set
    End Property

    '@pa_gre_ptollegada_codubigeo char(6),
    Private gre_ptollegada_codubigeo_ As String
    Public Property gre_ptollegada_codubigeo() As String
        Get
            Return gre_ptollegada_codubigeo_
        End Get
        Set(ByVal value As String)
            gre_ptollegada_codubigeo_ = value
        End Set
    End Property

    '@pa_gre_ptollegada_ruc_establecimiento char(11),
    Private gre_ptollegada_ruc_establecimiento_ As String
    Public Property gre_ptollegada_ruc_establecimiento() As String
        Get
            Return gre_ptollegada_ruc_establecimiento_
        End Get
        Set(ByVal value As String)
            gre_ptollegada_ruc_establecimiento_ = value
        End Set
    End Property

    '@pa_gre_ptollegada_codestablecimiento char(4),
    Private gre_ptollegada_codestablecimiento_ As String
    Public Property gre_ptollegada_codestablecimiento() As String
        Get
            Return gre_ptollegada_codestablecimiento_
        End Get
        Set(ByVal value As String)
            gre_ptollegada_codestablecimiento_ = value
        End Set
    End Property

    '@pa_gre_transp_ruc char(11),
    Private gre_transp_ruc_ As String
    Public Property gre_transp_ruc() As String
        Get
            Return gre_transp_ruc_
        End Get
        Set(ByVal value As String)
            gre_transp_ruc_ = value
        End Set
    End Property

    '@pa_gre_transp_nombre char(250),
    Private gre_transp_nombre_ As String
    Public Property gre_transp_nombre() As String
        Get
            Return gre_transp_nombre_
        End Get
        Set(ByVal value As String)
            gre_transp_nombre_ = value
        End Set
    End Property

    '@pa_gre_chofer_id_doc_identidad char(2),
    Private gre_chofer_id_doc_identidad_ As String
    Public Property gre_chofer_id_doc_identidad() As String
        Get
            Return gre_chofer_id_doc_identidad_
        End Get
        Set(ByVal value As String)
            gre_chofer_id_doc_identidad_ = value
        End Set
    End Property


    '@pa_gre_chofer_nro_doc_identidad char(15),
    Private gre_chofer_nro_doc_identidad_ As String
    Public Property gre_chofer_nro_doc_identidad() As String
        Get
            Return gre_chofer_nro_doc_identidad_
        End Get
        Set(ByVal value As String)
            gre_chofer_nro_doc_identidad_ = value
        End Set
    End Property

    '@pa_gre_chofer_apellidos char(250),
    Private gre_chofer_apellidos_ As String
    Public Property gre_chofer_apellidos() As String
        Get
            Return gre_chofer_apellidos_
        End Get
        Set(ByVal value As String)
            gre_chofer_apellidos_ = value
        End Set
    End Property

    '@pa_gre_chofer_nombres char(250),
    Private gre_chofer_nombres_ As String
    Public Property gre_chofer_nombres() As String
        Get
            Return gre_chofer_nombres_
        End Get
        Set(ByVal value As String)
            gre_chofer_nombres_ = value
        End Set
    End Property

    '@pa_gre_chofer_nro_licencia char(10),
    Private gre_chofer_nro_licencia_ As String
    Public Property gre_chofer_nro_licencia() As String
        Get
            Return gre_chofer_nro_licencia_
        End Get
        Set(ByVal value As String)
            gre_chofer_nro_licencia_ = value
        End Set
    End Property

    '@pa_gre_vehiculo_indicador_traslado_M1 bit,
    Private gre_vehiculo_indicador_traslado_M1_ As Byte
    Public Property gre_vehiculo_indicador_traslado_M1() As Byte
        Get
            Return gre_vehiculo_indicador_traslado_M1_
        End Get
        Set(ByVal value As Byte)
            gre_vehiculo_indicador_traslado_M1_ = value
        End Set
    End Property

    '@pa_gre_vehiculo_pri_placa char(8),
    Private gre_vehiculo_pri_placa_ As String
    Public Property gre_vehiculo_pri_placa() As String
        Get
            Return gre_vehiculo_pri_placa_
        End Get
        Set(ByVal value As String)
            gre_vehiculo_pri_placa_ = value
        End Set
    End Property


    '@pa_gre_vehiculo_pri_nrotarjeta_circulacion char(15),
    Private gre_vehiculo_pri_nrotarjeta_circulacion_ As String
    Public Property gre_vehiculo_pri_nrotarjeta_circulacion() As String
        Get
            Return gre_vehiculo_pri_nrotarjeta_circulacion_
        End Get
        Set(ByVal value As String)
            gre_vehiculo_pri_nrotarjeta_circulacion_ = value
        End Set
    End Property

    '@pa_gre_vehiculo_sec_placa char(8),
    Private gre_vehiculo_sec_placa_ As String
    Public Property gre_vehiculo_sec_placa() As String
        Get
            Return gre_vehiculo_sec_placa_
        End Get
        Set(ByVal value As String)
            gre_vehiculo_sec_placa_ = value
        End Set
    End Property

    '@pa_gre_vehiculo_sec_nrotarjeta_circulacion char(15),
    Private gre_vehiculo_sec_nrotarjeta_circulacion_ As String
    Public Property gre_vehiculo_sec_nrotarjeta_circulacion() As String
        Get
            Return gre_vehiculo_sec_nrotarjeta_circulacion_
        End Get
        Set(ByVal value As String)
            gre_vehiculo_sec_nrotarjeta_circulacion_ = value
        End Set
    End Property


    '@pa_gre_envio_nro_bultos int,
    Private gre_envio_nro_bultos_ As Integer
    Public Property gre_envio_nro_bultos() As Integer
        Get
            Return gre_envio_nro_bultos_
        End Get
        Set(ByVal value As Integer)
            gre_envio_nro_bultos_ = value
        End Set
    End Property

    '@pa_gre_envio_peso_bruto_carga_kgs decimal(12,3),
    Private gre_envio_peso_bruto_carga_kgs_ As Decimal
    Public Property gre_envio_peso_bruto_carga_kgs() As Decimal
        Get
            Return gre_envio_peso_bruto_carga_kgs_
        End Get
        Set(ByVal value As Decimal)
            gre_envio_peso_bruto_carga_kgs_ = value
        End Set
    End Property

    '@pa_gre_observacion char(250)
    Private gre_observacion_ As String
    Public Property gre_observacion() As String
        Get
            Return gre_observacion_
        End Get
        Set(ByVal value As String)
            gre_observacion_ = value
        End Set
    End Property

    '@pa_gre_observacion char(250)
    Private nroorden_trabajo_ As String
    Public Property nroorden_trabajo() As String
        Get
            Return nroorden_trabajo_
        End Get
        Set(ByVal value As String)
            nroorden_trabajo_ = value
        End Set
    End Property




End Class

