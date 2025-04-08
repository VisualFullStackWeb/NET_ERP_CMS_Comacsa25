Imports SIP_Negocio
Imports SIP_Entidad
Imports SIP_Reporte
Imports System.Windows.Forms
Module ModStructure

    Public Structure Entidad
        Event z()
        'Public Shared Activo As ETActivo = Nothing
        'Public Shared Almacen As ETAlmacen = Nothing
        'Public Shared Anexo As New ETAnexo
        'Public Shared Cliente As ETCliente = Nothing
        'Public Shared Costo As ETCosto = Nothing
        'Public Shared Mineral As ETMineral = Nothing
        'Public Shared Ruma As ETRuma = Nothing
        'Public Shared Requerimiento As ETRequerimiento = Nothing
        'Public Shared Producto As ETProducto = Nothing
        'Public Shared Usuario As ETUsuario = Nothing
        'Public Shared Objecto As ETObjecto = Nothing
        'Public Shared Personal As ETPersonal = Nothing
        'Public Shared Proforma As ETProforma = Nothing
        'Public Shared Suministro As ETSuministro = Nothing
        'Public Shared Orden As ETOrden = Nothing
        'Public Shared MyLista As ETMyLista = Nothing


        Public Shared Activo As New ETActivo
        Public Shared Almacen As New ETAlmacen
        Public Shared Anexo As New ETAnexo
        Public Shared Cliente As New ETCliente
        Public Shared Costo As New ETCosto
        Public Shared Mineral As New ETMineral
        Public Shared Ruma As New ETRuma
        Public Shared Requerimiento As New ETRequerimiento
        Public Shared RequerimientoDetalle As New ETListDetalleRequerimiento
        Public Shared Producto As New ETProducto
        Public Shared Usuario As New ETUsuario
        Public Shared Objecto As New ETObjecto
        Public Shared Personal As New ETPersonal
        Public Shared Proveedor As New ETProveedor

        Public Shared Proforma As New ETProforma
        Public Shared Suministro As New ETSuministro
        Public Shared Orden As New ETOrden
        Public Shared Parametro As New ETParametro
        Public Shared MyLista As New ETMyLista
        Public Shared CanteraCosteo As New ETCanteraCosteo
        Public Shared LineaProduccion As New ETLineaNegocio
        Public Shared Periodo As New ETPeriodo
        Public Shared PeriodoDetalle As New ETPeriodoDetalle
        Public Shared CosteoActivo As New ETCosteoActivo
        Public Shared PersonalProduccion As New ETPersonalLineaProduccion

        Public Shared Entregas As New ETEntregas
        Public Shared Contratista As New ETContratista
        Public Shared AprobacionFirmaMonto As New ETAprobacionFirmaMonto
        Public Shared EmpleoLabor As New ETEmpleoLabor
        Public Shared Guia As New ETGuia
        Public Shared OrdenCompra As New ETOrdenCompra
        Public Shared Pedido As New ETPedido
        Public Shared Resultado As New ETResultado

        Public Shared CtaCteContratista As New ETCuentaCorriente

        'General ERP
        'Larry Fernando Sánchez Amaya
        Public Shared Area As New ETArea
        Public Shared Glosa As New ETGlosa
        Public Shared Sistemas As New ETSistema
        Public Shared SistemasGrupo As New ETSistema
        'RRHH
        'Larry Fernando Sánchez Amaya
        Public Shared AreaEmpleado As New ETAreaEmpleado

        '*********************************
        'Larry Fernando Sánchez Amaya
        ' Siman
        Public Shared UnidadMedida As New ETUnidadMedida
        Public Shared SubParteEquipo As New ETParteEquipo
        Public Shared AtribParteEquipo As New ETAtributo
        Public Shared AtribFamiliaEquipo As New ETAtributo
        Public Shared FamiliaParteEquipo As New ETParteEquipo
        Public Shared FamiliaEquipo As New ETFamiliaEquipo
        Public Shared AtribEquipo As New ETAtributo
        Public Shared AtribEquipo_ParteEq As New ETAtributo
        Public Shared Atributo As New ETAtributo
        Public Shared Equipo As New ETEquipo
        Public Shared Equipo_ParteEq_Atributo_Valor As New ETAtributo
        Public Shared Requerimiento_Det_Mantto As New ETRequerimiento_ManttoDetalle
        Public Shared Programacion_Mantto As New ETProgramacionMantto
        Public Shared Partida_Mantto As New ETPartida
        Public Shared Partida_Material As New ETPartidaMaterial
        Public Shared Partida_Equipo As New ETPartidaEquipo
        Public Shared Partida_ManoObra As New ETPartidaManoObra
        Public Shared Partida_Servicio As New ETPartidaServicio
        Public Shared Presupuesto As New ETPresupuesto
        Public Shared PresupuestoDet As New ETPresupuestoDetalle
        Public Shared Presupuesto_Material As New ETPresupuestoMaterial
        Public Shared Presupuesto_Equipo As New ETPresupuestoEquipo
        Public Shared Presupuesto_ManoObra As New ETPresupuestoManoObra
        Public Shared Presupuesto_Servicio As New ETPresupuestoServicio
        Public Shared Presupuesto_Plan As New ETPresupuestoPlan
        Public Shared Presupuesto_Plan_Recurso As New ETPresupuestoPlanRecursos
        Public Shared Presupuesto_Plan_Recurso_Asignacion As New ETPresupuestoPlanRecursosAsignacion
        Public Shared OrdenTrabajo As New ETOrdenTrabajo_Mantto
        Public Shared TareoOs As New ETTareoOS
        Public Shared CosteoManttoMecanico As New ETCosteoManttoMecanico
        Public Shared CosteoManttoMecanicoDetalle As New ETCosteoManttoMecanicoDetalle

        Public Shared OrdenTrabajo_Recursos As New ETOrdenTrabajo_Recursos
        Public Shared Maestro2 As New ETMaestos2

        Public Shared AreaJefatura As New ETAreaJefatura
        Public Shared Etfcb As New ETFCB

        Public Shared Banco As New ETBanco

    End Structure

    Public Structure Negocio
        Event z()
        'Public Shared Maestro As NGMaestro = Nothing
        'Public Shared Cliente As NGCliente = Nothing
        'Public Shared Costo As NGCosto = Nothing
        'Public Shared Mineral As NGMineral = Nothing
        'Public Shared Ruma As NGRuma = Nothing
        'Public Shared Reporte As NGReporte = Nothing
        'Public Shared Orden As NGOrden = Nothing
        'Public Shared Producto As NGProducto = Nothing
        'Public Shared Usuario As NGUsuario = Nothing
        'Public Shared Activo As NGActivo = Nothing
        'Public Shared Suministro As NGSuministro = Nothing
        'Public Shared Requerimiento As NGRequerimiento = Nothing
        'Public Shared Personal As NGPersonal = Nothing
        'Public Shared Almacen As NGAlmacen = Nothing
        Public Shared Maestro As New NGMaestro
        Public Shared Cliente As New NGCliente
        Public Shared Costo As New NGCosto
        Public Shared Mineral As New NGMineral
        Public Shared Ruma As New NGRuma
        Public Shared Reporte As New NGReporte
        Public Shared Orden As New NGOrden
        Public Shared Producto As New NGProducto
        Public Shared Usuario As New NGUsuario
        Public Shared Activo As New NGActivo
        Public Shared Suministro As New NGSuministro
        Public Shared Requerimiento As New NGRequerimiento
        Public Shared Personal As New NGPersonal
        Public Shared Proveedor As New NGProveedor

        Public Shared Almacen As New NGAlmacen
        Public Shared CanteraCosteo As New NGCanteraCosteo
        Public Shared LineaProduccion As New NGLineaProduccion
        Public Shared Personal_LinProd As New NGPersonal_LinProd
        Public Shared PeriodoCosteo As New NGPeriodoCosteo
        Public Shared PeriodoSiliceHomogenizada As New NGSiliceHomogenizada
        Public Shared PeriodoGasNatural As New NGPeriodoGasNatural
        Public Shared PeriodoPlantaCemento As New NGPeriodoPlantaCemento

        Public Shared CtaCteContratista As New NGCtaCteContratista
        Public Shared ConsultasRRHH As New NGConsultaRRHH
        Public Shared Sistemas As New NGSistema


        Public Shared EmpleoLabor As New NGEmpleoLabor
        Public Shared Guia As New NGGuia
        Public Shared Maestros2 As New NGMaestros2
        Public Shared ReportesBL As New NGReportes
        Public Shared AnexoOCBL As New NGAnexo
        Public Shared AprobacionFirmaMontoBL As New NGAprobacionFirmaMonto
        Public Shared PedidoBL As New NGPedido
        Public Shared AnexoBL As New NGAnexo
        Public Shared OrdenCompraBL As New NGOrdenCompra

        'General ERP
        'Larry Fernando Sánchez Amaya
        Public Shared Area As New NGArea
        Public Shared Glosa As New NGGlosa

        'RRHH
        'Larry Fernando Sánchez Amaya
        Public Shared AreaEmpleado As New NGAreaEmpleado
        '************************************************
        ' SiMan
        'Larry Fernando Sánchez Amaya
        Public Shared LineaNegocio As New NGLineaNegocio
        Public Shared UnidadMedida As New NGUnidadMedida
        Public Shared Atributo As New NGAtributo
        Public Shared ParteEquipo As New NGParteEquipo
        Public Shared FamiliaEquipo As New NGFamiliaEquipo
        Public Shared Equipo As New NGEquipo
        Public Shared CheckList As New NGCheckList
        Public Shared Requerimiento_Mantto As New NGRequerimiento_Mantto
        Public Shared Programacion_Mantto As New NGProgramacionMantto
        Public Shared Partida_Mantto As New NGPartida
        Public Shared Presupuesto As New NGPresupuesto
        Public Shared PresupuestoDet As New NGPresupuestoDet
        Public Shared Orden_Trabajo As New NGOrdenTrabajo_Mantto
        Public Shared Orden_Trabajo_Recurso_Sin_Precio As New NGOrdenTrabajoRecursoSinPrecio
        Public Shared TareoOS As New NGTareoOS
        Public Shared AreaJefatura As New NGAreaJefatura
        Public Shared CosteoManttoMecanico As New NGCosteoManttoMecanico
        Public Shared CosteoProduccion As New NGCosteoProduccion
        Public Shared NEntregas As New NGEntregas
        Public Shared NContratista As New NGContratista

        Public Shared Banco As New NGBanco

    End Structure

    Public Structure Reporte
        Event z()
        Public Shared Informe As RptInforme = Nothing
        Public Shared Exportar As RptExportar = Nothing
        Public Shared Activo As RptActivo = Nothing
    End Structure

    Public Structure StrucForm
        Event z()

        REM Form Basicos
        Public Shared FxBxAyuda As FrmBAyuda
        Public Shared FxBxBase As New FrmBBase
        Public Shared FxBxMain As New FrmBMain
        Public Shared FxBxLogueo As New FrmBLogueo
        Public Shared Formulario As Form = Nothing

        REM Crystal
        Public Shared FxRxReporte As FrmBReporte
        Public Shared FxRequerimientoCompra As Rpt_Requerimiento
        Public Shared FxSalidaOrden As Rpt_SalidaAlmacen
        Public Shared FxListaProducto As Rpt_Suministros_Envio
        Public Shared FxEnvioCantera As Rpt_Suministros_EnvioCantera
        Public Shared FxVidaUtil As Rpt_VidaUtil
        Public Shared VisorReport_Mantto As frmVisorReporte
        Public Shared FxRxSolicitud As FrmSolicitud
        Public Shared FxRxSolicitudPlanilla As FrmReporteSolicitudPlanilla
        Public Shared FxRxAnticipo As FrmAnticipo
        Public Shared FxRxLiquidacion As FrmRptLiquidacion
        Public Shared FxRxReintegro As Frm_RptReintegro
        Public Shared FxRxRegCompras As FrmRptRegCompra
        Public Shared FxRxCancelacionAnt As FrmRptCancelacionAnt
        Public Shared FxRxProductoNC As FrmRptNC
        Public Shared FxRxRptPedido As FrmRptPedido
        Public Shared FxRxFactCombustible As FrmRptFactCombustible
        REM Clases
        Public Shared CxMenu As ClsMenu
        'Public Shared CxReporte As ClsReporte
        Public Shared CxResolucion As ClsResolucion

        REM Consulta
        Public Shared FxCxPedidos As FrmCExportacion = Nothing
        Public Shared FxCxRumas As FrmCRumas = Nothing
        Public Shared FxCxMineralProyecion As FrmCMineralProyecion = Nothing
        Public Shared FxCxProductos As FrmCProductos = Nothing
        Public Shared FxCxPersonal As FrmCPersonal = Nothing
        Public Shared FxCxRequerimiento As FrmCRequerimiento = Nothing
        Public Shared FxCxOrden As FrmCOrden = Nothing
        Public Shared FxCxStockMinimo As FrmCStock = Nothing
        Public Shared FxCxSuministro As FrmCSuministro = Nothing
        Public Shared FxCxTSuministro As frmCTSuministro = Nothing
        Public Shared FxListaSuministro As frmListaSuministro = Nothing
        Public Shared FxCxEmpaques As FrmCEmpaques = Nothing
        Public Shared FxCxDetallada As FrmCDetallada = Nothing
        Public Shared FxCxCosteoMineral As FrmCCosteoMineral = Nothing


        REM Listar
        Public Shared FxLxListarActivo As FrmListarActivo = Nothing
        Public Shared FxLxListarCantera As FrmListarCantera = Nothing
        Public Shared FxLxListarEmpleoLabor As FrmListarEmpleoLabor = Nothing
        Public Shared FxLxListarPlanilla As FrmListarPlanilla = Nothing
        Public Shared FxLxListarProductos As FrmListarProductos = Nothing
        Public Shared FxLxListarProveedores As FrmProveedores = Nothing

        REM Planeamiento
        Public Shared FxLxRequerimiento As FrmLRequerimiento = Nothing
        Public Shared FxLxDetalleUnidad As FrmLDetalleUnidad = Nothing
        Public Shared FxLxStockMinimo As FrmLStockMinimo = Nothing
        Public Shared FxLxOrdenProduccion As FrmLOrdenProduccion = Nothing

        REM Maestros
        Public Shared FxMxEnlace As FrmMEnlace = Nothing
        'Public Shared FxMxProductos As FrmMProductos = Nothing

        Public Shared FxMxSuministros As FrmMaestroSuministros = Nothing
        Public Shared FxMxUsuario As FrmMUsuarios = Nothing
        Public Shared FxMxFormulario As FrmMFormularios = Nothing



    End Structure

    Public Structure Mensaje
        Event z()
        Public Const Error01 As String = "Error: Debe Ingresar los Datos Obligatorios"
        Public Const Comacsa As String = "COMACSA"
        Public Const Modulo As String = "No posee los permisos necesarios para acceder al modulo"
        Public Const Operacion As String = "No posee los permisos necesarios para realizar la operación"
        Public Const Correcto As String = "Se grabaron los datos correctamente"
        Public Const Error02 As String = "No se pudo grabar los datos correctamente"
        Public Const Pregunta As String = "¿Seguro desea guardar los cambios?"
        Public Const ErrorForm As String = "Se produjo errores al abrir el Modulo"
        Public Const Seleccion As String = "Tiene que Seleccionar una opción para Actualizar"
        Public Const Seleccion_2 As String = "Tiene que Seleccionar la opción Modificar para Actualizar Datos"
        Public Const Seleccion_3 As String = "Tiene que Seleccionar la opción Nuevo"
        Public Const Scroll As String = "          (*) Datos Obligatorios          "
    End Structure

    Public Structure StrucOperaciones
        Event z()
        Public Const _Nuevo As String = "1"
        Public Const _Modificar As String = "2"
        Public Const _Eliminar As String = "3"
        Public Const _Buscar As String = "4"
        Public Const _Grabar As String = "5"
        Public Const _Cancelar As String = "6"
        Public Const _Procesar As String = "7"
        Public Const _Reporte As String = "8"
        Public Const _Actualizar As String = "9"
        Public Const _Correo As String = "11"
        Public Const _Excel As String = "16" 'K12
        Public Const _Orden As String = "K13"
    End Structure



    Public Structure StrucActivos
        Event z()
        Public Const Molino As String = "01"
        Public Const Chancadora As String = "02"
        Public Const CodClase As String = "03"
        Public Const StrMolino As String = "MOLINO"
        Public Const StrChancadora As String = "CHANCADORA"
    End Structure

    Public Structure StrucToolTag
        Event z()
        Public Shared Nulo As String = String.Empty

        '   PRODUCCIÓN
        Public Shared MFormula As String = "2"
        Public Shared MProductoRuma As String = "3"
        Public Shared MProductos As String = "4"
        Public Shared MProductoxUnidad As String = "5"
        Public Shared MProyVentas As String = "6"
        Public Shared MUnidadPersonal As String = "7"
        Public Shared POrdenProduccion As String = "8"
        Public Shared PCronograma As String = "9"
        Public Shared PReqRumas As String = "10"
        Public Shared MEnvases As String = "11"
        Public Shared CProductos As String = "12"
        Public Shared CPersonal As String = "13"
        Public Shared CStock As String = "14"
        Public Shared CProduccionPendiente As String = "15"
        Public Shared CNacional As String = "16"
        Public Shared CExportacion As String = "17"
        Public Shared CRumas As String = "18"
        Public Shared CCosteoProduccion As String = "84"
        Public Shared MLineaProduccion As String = "87"
        Public Shared PPersonal_LineaProduccion As String = "88"
        Public Shared PPeriodo_GasNatural As String = "89"
        Public Shared PPeriodo_PlantaCemento As String = "90"
        Public Shared CMineralesProductos As String = "97"
        Public Shared PPeriodo_SiliceHomogenizada As String = "100"
        Public Shared PPeriodo_Costeo As String = "101"
        Public Shared PPeriodo_Costeo_Facturacion As String = "102"
        Public Shared PPeriodo_Costeo_Operador As String = "103"
        Public Shared CTrazabilidadProforma As String = "107"
        Public Shared MProcesoProductivo As String = "116"
        Public Shared LOrdenProd_Pesado As String = "118"
        Public Shared LOrdenProd_Chancado As String = "119"
        Public Shared LOrdenProd_Molienda_Confirmacion As String = "121"
        Public Shared LOrdenProd_Molienda_IngresoProd As String = "122"
        Public Shared LOrdenProd_Envasado As String = "123"


        '   USUARIOS
        Public Shared MUsuarios As String = "21"
        Public Shared MFormularios As String = "22"
        Public Shared MSistemas As String = "95"


        '   ALMACÉN
        Public Shared MSuministros As String = "20"
        Public Shared MCambioPassword As String = "28"
        Public Shared MConversionUnidades As String = "29"
        Public Shared MRangoAprobacion As String = "30"
        Public Shared MFirmaDigital As String = "31"
        Public Shared MEmpleoLabor As String = "47"
        Public Shared AAprobacionOC As String = "23"
        Public Shared AAprobacionRequerimiento As String = "24"
        Public Shared CAprobacionOC As String = "25"
        Public Shared CPedidos As String = "26"
        Public Shared CDatosAuxiliares As String = "27"
        Public Shared VRecepcionServicios As String = "32"
        Public Shared VIngresoAjuste As String = "33"
        Public Shared VIngresoOC As String = "34"
        Public Shared VIngresoRemarcado As String = "35"
        Public Shared VIngresoSinOC As String = "36"
        Public Shared VIngrsoTransferencia As String = "37"
        Public Shared VSalidaDevolucion As String = "38"
        Public Shared VSalidaOrden As String = "39"
        Public Shared VSalidaRemarcado As String = "40"
        Public Shared VSalidaTransferencia As String = "41"
        Public Shared EAutorizar As String = "42"
        Public Shared EDistribuir As String = "43"
        Public Shared EEntregar As String = "44"
        Public Shared ERegistrar As String = "45"
        Public Shared ERequerimientoCompra As String = "46"
        Public Shared CConsumoSuministro As String = "94"
        Public Shared ERequerimientoCompraConsolidado As String = "98"
        Public Shared ERequerimientoCompraDistribuir As String = "99"
        Public Shared CReportesVarios As String = "108"
        ' MINAS
        Public Shared CCosteoMineral As String = "48"
        Public Shared MCombustibleExplosivo As String = "49"
        Public Shared MRegistroPersonalCantera As String = "50"
        Public Shared MUbicacionCantera As String = "51"
        Public Shared MVigenciaCantera As String = "52"
        Public Shared MVidaUtilEquipo As String = "53"
        Public Shared CCanteraEquipo As String = "54"
        Public Shared MHoraMaquina As String = "55"
        Public Shared MDerechoCesion As String = "56"
        Public Shared MDonaciones As String = "57"
        Public Shared MListaPrecio As String = "58"
        Public Shared MDeprecionEquipo As String = "59"
        Public Shared MCostoAutorizacion As String = "60"
        Public Shared CEnvioSuministros As String = "61"
        Public Shared MListaPrecioFlete As String = "80"
        Public Shared MListaPrecioFletexMineral As String = "91"

        Public Shared CCtaCteContratista As String = "92"
        Public Shared MGlosaCostoAutorizTramiteDoc As String = "93"
        Public Shared CCosteoMineralxCantera As String = "104"
        Public Shared CCosteoMineralxTipoCosto As String = "105"

        Public Shared CCosteoMineralxCanteraxRango As String = "118"
        Public Shared CCosteoMineralxTipoCostoxRango As String = "119"


        Public Shared MDisponibilidadEquiposCantera As String = "106"
        Public Shared DContratista As String = "110"
        Public Shared DContratista_Faltas As String = "111"
        Public Shared DContratista_Esquema2 As String = "112"
        Public Shared DContratista_ListaPrecioMineral As String = "113"
        Public Shared DContratista_GenerarReporte As String = "114"
        'Mantenimiento
        Public Shared MLineaNegocio As String = "62"
        Public Shared MAtributo As String = "63"
        Public Shared MParteEquipo As String = "64"
        Public Shared MEnzalarComponenteSubComponente As String = "65"
        Public Shared MEnzalarAtributoComponente As String = "66"
        Public Shared MFamiliaEquipo As String = "67"
        Public Shared MEnzalarAtributoFamiliaEquipo As String = "68"
        Public Shared MEnzalarComponenteFamiliaEquipo As String = "69"
        Public Shared MEquipo As String = "70"
        Public Shared MPlantillaAPU As String = "71"
        Public Shared SCheckList As String = "72"
        Public Shared SRequerimiento As String = "73"
        Public Shared SProgramacion As String = "74"
        Public Shared SPresupuesto As String = "75"
        Public Shared SOrdenTrabajo As String = "76"
        Public Shared SBackLog As String = "77"
        Public Shared APresupuesto As String = "78"
        Public Shared STareoOS_Personal As String = "79"
        Public Shared STareoOS_Equipo As String = "81"
        Public Shared RPresupuesto_vs_OrdenTrabajo As String = "82"
        Public Shared POrdenTrabajo_Recurso_Sin_Precio As String = "83"
        Public Shared MEnlazarCodigoEquipo_CodigoContabilidad As String = "85"
        Public Shared PCosteoMantoMecanico As String = "86"
        'RR HH
        Public Shared MAreaEmpleado As String = ""
        Public Shared CCtaCtePersonal As String = "96"

        'ADMINISTRACION
        Public Shared MInsumosControlados As String = "120"
        Public Shared MEntregaraRendir As String = "121"
        Public Shared MTrabajadoresArea As String = "122"
        Public Shared MSeteoContable As String = "123"
        Public Shared MUsuarioAprueba As String = "124"
        Public Shared AdmFrmInsumosF As String = "125"
        Public Shared AdmFrmProveedorF As String = "126"
        Public Shared MConsulta As String = "127"
        Public Shared MLineaCredito As String = "128"
        Public Shared MAprobarLiquidacion As String = "129"
        Public Shared MDescripciones As String = "130"
        Public Shared AdmCargaIQBF As String = "131"
        Public Shared RegionCantera As String = "132"
        Public Shared ConsultaCombustible As String = "133"
        Public Shared RevisionDocumentos As String = "134"
        Public Shared MantenimientoCombustible As String = "135"
        Public Shared UsuarioIngresoInformacion As String = "136"
        Public Shared SeteoCorreo As String = "137"
        Public Shared HtnrPResentacion As String = "138"
        Public Shared GeneraStamin As String = "139"
        Public Shared rptMorosidad As String = "140"
        Public Shared AplicaReintegro As String = "141"
        Public Shared rptViatico As String = "142"
        Public Shared ConsultaRecibo As String = "143"
        Public Shared ConsultaSaldos As String = "144"
        Public Shared SolicitudAprobada As String = "145"
        Public Shared SolicitudCero As String = "146"
        Public Shared RendimientoxUnidad As String = "147"
        Public Shared PrecioCombustible As String = "148"
        Public Shared ValesSinSustento As String = "149"
        Public Shared ProyeccionVentaRuma As String = "150"
        Public Shared ProvisionLiquidaciones As String = "151"
        Public Shared ReporteFormulaciones As String = "152"
        Public Shared AgrupacionRumas As String = "153"
        Public Shared ConsultaDocumentos As String = "154"
        Public Shared FormulacionProyectado As String = "155"
        Public Shared RptOperaciones As String = "156"
        Public Shared ExcepcionPesoVehicular As String = "157"
        Public Shared LetraTransportista As String = "158"
        Public Shared ExoneracionLetra As String = "159"
        Public Shared ReporteDAC As String = "160"
        Public Shared ConstanciamalLlenada As String = "161"
        Public Shared Contratista As String = "162"
        Public Shared AnticipoExtraccion As String = "163"
        Public Shared PlanillaContratista As String = "164"
        Public Shared AnticipoObligacion As String = "165"
        Public Shared AnticipoImpuesto As String = "166"
        Public Shared AnticipoGratificacion As String = "167"
        Public Shared AnticipoCts As String = "168"
        Public Shared AnticipoVacacionLiquidacion As String = "169"
        Public Shared Conceptos As String = "170"
        Public Shared PrecioMineral As String = "171"
        Public Shared AnticipoOtros As String = "172"
        Public Shared SeteoFechas As String = "173"
        Public Shared SuspensionRenta As String = "174"
        Public Shared ConceptoRH As String = "176"
        Public Shared SeteoFcb As String = "175"
        Public Shared RptFcb As String = "177"
        Public Shared AnticipoProveedor As String = "178"
        Public Shared CargaPlanilla As String = "179"
        Public Shared AgregaAlmacen As String = "180"
        Public Shared MaquinaContratista As String = "181"
        Public Shared TipoMovimiento As String = "182"
        Public Shared Movimientos As String = "183"
        Public Shared ImportarDatos As String = "184"
        Public Shared Kardex As String = "185"
        Public Shared Existencia As String = "186"
        Public Shared MaqPesada As String = "187"
        Public Shared ApruebaDocumentos As String = "188"
        Public Shared AlquilerVehiculo As String = "189"
        Public Shared ConsultaContratista As String = "190"

        Public Shared RegistroCamiones As String = "194"
        Public Shared Camiondisponible As String = "195"
        Public Shared ProgramacionCamion As String = "196"
        Public Shared ConsultaProgramacion As String = "197"
        Public Shared ProgramacionGuia As String = "198"
        Public Shared Programacion_Incidencia As String = "199"
        Public Shared Mant_Incidencia As String = "200"
        Public Shared Mant_Conceptos As String = "201"
        Public Shared IngresoTasa As String = "202"
        Public Shared CalculoPPago As String = "203"
        Public Shared ReporteCosteo As String = "204"
        Public Shared CostoIndirecto As String = "205"
        Public Shared ReporteIndirecto As String = "206"
        Public Shared ReporteFinal As String = "207"
        Public Shared CostoPromedio As String = "208"
        Public Shared Costo_Seteos As String = "209"
        Public Shared FrmTonIngresadas As String = "210"
        Public Shared FrmCostoTrimestral As String = "211"
        Public Shared FrmCostoAltoBajo As String = "212"
        Public Shared frmInventarioIQBF As String = "213"
        Public Shared FrmReporteRH As String = "214"
        Public Shared FrmCosteoMinaCantera As String = "215"
        Public Shared FrmReporteIndicadores As String = "216"

        
        Public Shared FrmMantProdOptima As String = "217"
        Public Shared FrmIndProduccion As String = "218"
        Public Shared FrmIndAdministracion As String = "219"
        Public Shared FrmIngresoIndicadores As String = "220"
        Public Shared FrmCostoMineralDet As String = "221"
        Public Shared FrmCargaConsumoEnergia As String = "222"
        Public Shared FrmRumaComparativo As String = "223"
        Public Shared FrmCapacidadCemento As String = "224"
        Public Shared FrmParaCampañaCemento As String = "225"
        Public Shared FrmTrazabilidadCosteo As String = "226"
        Public Shared frmResumenMensual As String = "227"
        Public Shared Frm_Rh_Retencion As String = "228"
        Public Shared FrmReporteLimiteRH As String = "229"
        Public Shared frmConceptoFactura As String = "230"
        Public Shared frmFacturaConcepto As String = "231"
        Public Shared FrmPrecioProductoCliente As String = "232"
        Public Shared FrmCostoxMolino As String = "233"
        Public Shared FrmRegAlqMaquina As String = "234"
        Public Shared frmCargaPesosCrudo As String = "235"
        Public Shared FrmRptNoConforme As String = "236"
        Public Shared Frm_Costo_ConsumoEnergia As String = "237"
        Public Shared frmVentasReclamos As String = "238"
        Public Shared frmLaboratorioReclamos As String = "239"
		Public Shared frmVentasReclamosRegistro As String = "240"
        Public Shared FrmAutorizaIQBF As String = "241"
        Public Shared FrmPedidoSuministro As String = "242"
        Public Shared FrmRegistroKardex As String = "243"
        Public Shared FrmRptVacacionesLiquidaciones As String = "244"
        Public Shared FrmAplicacionAnticipo As String = "245"
        Public Shared FrmEquipoCantera As String = "246"
        Public Shared frmExamenesMedicos As String = "247"
        Public Shared frmFacturaCombustible As String = "248"
        Public Shared FrmRptIgvRenta As String = "249"
        Public Shared FrmConsumoCentroCosto As String = "250"

        Public Shared FrmAsignacionCelular As String = "251"

        Public Shared FrmVinculoFacturasConsumo As String = "252"
        Public Shared FrmRegistroSOAT As String = "253"
        Public Shared FrmTarifaVR As String = "254"
        Public Shared frmCargaUnacem As String = "255"
        Public Shared FrmMesesProduccion As String = "256"
        Public Shared frmRptControlPPago As String = "257"
        Public Shared FrmProyectos As String = "258"
        Public Shared FrmProyectoTrabajador As String = "259"
        Public Shared FrmProyectoEquipo As String = "260"
        Public Shared FrmGuiasFacturas As String = "261"
        Public Shared FrmCargaBilletes As String = "262"
        Public Shared FrmFacturaGas As String = "263"
        Public Shared FrmApruebaAtencionSuministro As String = "264"
        Public Shared FrmHistorialPedido As String = "265"
        Public Shared FrmMineralFleteExt As String = "266"
        Public Shared FemIndicadorLab As String = "267"
        Public Shared FrmCalendario As String = "268"
        Public Shared FrmProyectoTarea As String = "269"
        Public Shared FrmPlanificacion As String = "270"
        Public Shared FrmCierrePlanificacion As String = "271"
        Public Shared FrmAvanceProyecto As String = "272"
        Public Shared FrmReporteParada As String = "273"
        Public Shared FrmValidaProduccion As String = "274"
        Public Shared FrmTarifaExporta As String = "275"
        Public Shared frmRptCuenta9 As String = "276"
        Public Shared frmCostosAdm As String = "277"
        Public Shared FrmControlInventario As String = "278"
        Public Shared FrmConsultaOrden As String = "279"
        Public Shared FrmResumenER As String = "280"
        Public Shared frmListadoExportacion As String = "283"
        Public Shared frmReporteCostoCargaLaboral As String = "284"
        Public Shared frmCIndicadores As String = "285"
        Public Shared frmConsultaParteAsistencia As String = "286"
        Public Shared FrmBolsaCostos As String = "287"
        Public Shared FrmKardexCosteo As String = "288"
        Public Shared FrmSustentoProduccion As String = "289"
        Public Shared FrmactivaEmpleados As String = "290"
        Public Shared FrmImpEtiquetaQR As String = "291"
        Public Shared FrmSolicitudPlanilla As String = "292"
        Public Shared FrmListaDiferenciaProducto As String = "293"
        Public Shared FrmReporteCostCantera As String = "295"
        Public Shared FrmSeteoRumasCantidad As String = "296"
        Public Shared FrmGastosVehiculos As String = "297"
        Public Shared FrmFamiliaProductos As String = "298"
        Public Shared FrmConsumoRecursos As String = "299"
        Public Shared FrmLecturaDrone As String = "300"
        Public Shared FrmRptEstimacionesVtasProd As String = "302"
        'hv 11/02/2025
        Public Shared FrmAsigTarjetasConsumo As String = "304"

    End Structure

    Public Structure StrucToolOperacion
        Event z()

        Public Shared Nuevo As Integer = 1
        Public Shared Modificar As Integer = 2
        Public Shared Eliminar As Integer = 3
        Public Shared Buscar As Integer = 4
        Public Shared Grabar As Integer = 5
        Public Shared Cancelar As Integer = 6

    End Structure

    Public Structure StrucTextForm
        Event z()
        Public Shared Nulo As String = String.Empty
        Public Shared MUsuarios As String = "Usuarios"
        Public Shared MFormula As String = "Formula"
        Public Shared MEnlace As String = "Enlace (Producto-Ruma)"
        Public Shared MProductoxUnidad As String = "Enlace (Producto-Unidad)"
    End Structure

End Module
