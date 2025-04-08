Imports System.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Globalization
Imports System.Exception
Imports SIP_Entidad

Module ModBasico

    Public Companhia As String = ConfigurationManager.AppSettings.Get("Companhia")
    Public Sistema As String = ConfigurationManager.AppSettings.Get("Sistema")
    Public Serie As String = ConfigurationManager.AppSettings.Get("Serie")
    Public MsgComacsa As String = "COMACSA"
    Public msgError As String = "Comuniquese con el Area de Sistemas"
    Public gSistema As String = "22"


#Region "STORE PROCEDURE"

    Public Structure PPA_InsumosFiscalizados
        Event z()
        Public Const Insertar_InsumosFiscalizados As String = "UPS_ERP_Insertar_InsumosFiscalizados"
        Public Const Actualizar_InsumosFiscalizados As String = "UPS_ERP_Actualizar_InsumosFiscalizados"
        Public Const Listar_UnidadesDeMedidas As String = "UPS_ERP_Listar_UnidadesDeMedidas"
        Public Const Listar_InsumosFiscalizados_x_Cod_Cia As String = "UPS_ERP_Listar_InsumosFiscalizados_x_Cod_Cia"
        Public Const Mostrar_InsumosFiscalizados_x_Id_Prod As String = "UPS_ERP_Mostrar_InsumosFiscalizados_x_Id_Prod"
        Public Const Mostrar_ID_PROD_InsumosFiscalizados_x_Cod_SUNAT As String = "UPS_ERP_Mostrar_ID_PROD_InsumosFiscalizados_x_Cod_SUNAT"
        Public Const Anular_InsumosFiscalizados As String = "UPS_ERP_Anular_InsumosFiscalizados"
        Public Const Mostrar_Count_InsumosFProductosXId_Prod As String = "UPS_Mostrar_Count_InsumosFProductosXId_Prod"
    End Structure

    Public Structure PPA_InsumosFProductos
        Event z()
        Public Const Listar_Productos As String = "UPS_ERP_InsumosFProductos_Listar_Productos"
        Public Const Insertar_InsumosFProductos As String = "UPS_ERP_Insertar_InsumosFProductos"
        Public Const Listar_InsumosFProductosXId_Prod As String = "UPS_ERP_Listar_InsumosFProductosXId_Prod"
        Public Const Anular_InsumosFProductosXId_Prod As String = "UPS_ERP_Anular_InsumosFProductosXId_Prod"
        Public Const Mostrar_CantidadInsumosFProductosXId_Prod As String = "UPS_ERP_Mostrar_CantidadInsumosFProductosXId_Prod"
        Public Const Mostrar_CantidadInsumosFProductosXId_ProdAndCod_Prod As String = "UPS_ERP_Mostrar_CantidadInsumosFProductosXId_ProdAndCod_Prod"
    End Structure

    Public Structure PPA_ProveedorFiscalizado
        Event z()
        Public Const Insertar_ProveedorFiscalizado As String = "UPS_ERP_Insertar_ProveedorFiscalizado"
        Public Const MODIFICAIQBF As String = "USP_MODIFICAIQBF"
        Public Const Billete_Exonerado As String = "USP_NUEVO_BILLETE_EXONERADO"
        Public Const Letra_Transportista As String = "USP_MANTLETRATRANSPORTISTA"

        Public Const Autorizacion_IQBF As String = "USP_ERP_AUTORIZA_IQBF"

        Public Const InsertaConstanciaError As String = "USP_INSERTA_CONSTANCIAERROR"
        Public Const Exoneracion_Letra As String = "USP_MANTEXONERACIONLETRA"
        Public Const CIERRE_MES_IQBF As String = "USP_CIERRE_MES_IQBF"
        Public Const Listar_ProveedorFiscalizado As String = "UPS_ERP_Listar_ProveedorFiscalizado"
        Public Const Mostrar_ProveedorFiscalizado_X_Cod_Prov As String = "UPS_ERP_Mostrar_ProveedorFiscalizado_X_Cod_Prov"
        Public Const Actualizar_ProveedorFiscalizado As String = "UPS_ERP_Actualizar_ProveedorFiscalizado"
        Public Const INSERTA_USOBARBOTINA As String = "USP_INSERTA_USOBARBOTINA"
        Public Const Anular_ProveedorFiscalizado As String = "UPS_ERP_Anular_ProveedorFiscalizado"
        Public Const Mostrar_Proveedor_X_Cod_Prov As String = "UPS_ERP_Mostrar_Proveedor_X_Cod_Prov"
        Public Const Listar_Proveedores_Fiscalizar As String = "UPS_ERP_Listar_Proveedores_Fiscalizar"
        Public Const DatosIngresoIQBF As String = "Usp_DatosIngresoIQBF"
        Public Const DatosEliminaIQBF As String = "USP_ELIMINA_IQBF"
        Public Const PresentacionIQBF As String = "USP_IQBF_LISTA_PRESENTACION"
        Public Const IngresaIQBF As String = "USP_INGRESO_IQBF"
        Public Const RptEgresoIQBF As String = "Usp_RptEgresoIQBF"
        Public Const RptIngresoIQBF As String = "Usp_RptIngresoIQBF"
        Public Const RptInventarioIQBF As String = "USP_INVENTARIO_IQBF"
        Public Const RptProduccionIQBF As String = "Usp_RptProduccionIQBF"
        Public Const RptUsoIQBF As String = "Usp_RptUsoIQBF"
        Public Const RptGeneralIQBF As String = "Usp_RptGeneralIQBF"
        Public Const VerificaUserCierre As String = "USP_VERIFICA_USER_CIERRE_IQBF"
        Public Const VerificaCierreIqbf As String = "USP_VERIFICA_CIERRE_IQBF"
        Public Const TipoguiaSunat As String = "USP_LISTAR_TIPOGUIA_SUNAT"
        Public Const DatosEgresoIQBF As String = "Usp_DatosEgresoIQBF"
        Public Const DatosProduccionIQBF As String = "Usp_DatosProduccionIQBF"
        Public Const DatosUsoIQBF As String = "Usp_DatosUsoIQBF"

        Public Const PedidoSuministro As String = "USP_ERP_PEDIDO_SUMINISTRO_CAB"
        Public Const PedidoSuministro_v2 As String = "USP_ERP_PEDIDO_SUMINISTRO_CAB_V2"
        Public Const PedidoSuministro_Det As String = "USP_ERP_PEDIDO_SUMINISTRO_DET"

        Public Const SolicitudPlanilla_Det As String = "pla_mant_SolicitudPlanillaDetalle"

        Public Const PedidoSuministro_v3 As String = "USP_ERP_PEDIDO_SUMINISTRO_CAB_V3"

        Public Const SolicitudPlanilla As String = "pla_mant_SolicitudPlanilla"
        Public Const EnviarCorreoSolicitud As String = "pla_EnviarCorreoSolicitud"

        Public Const DatosGeneralIQBF As String = "Usp_DatosGeneralIQBF"
        Public Const DatosUsoBarbotinaIQBF As String = "Usp_DatosUsoBarbotinaIQBF"
        Public Const InsertaUsoLaboratorio As String = "USP_InsertaUsoLaboratorio"
        Public Const DatosSaldosIQBF As String = "RPT_STKPRESENTACIONES"
        Public Const HtnrxPResentacion As String = "USP_HtnrxPResentacion"
        Public Const HtnrEquipos As String = "USP_HtnrEquipos"
        Public Const DatosIngresoMineral As String = "USP_ERP_INGRESOMINERAL"
        Public Const DatosVentaMineral As String = "USP_ERP_SALIDAMINERAL"
        Public Const DatosMorosidad As String = "USP_MOROSIDAD"
        Public Const DatosMorosidadAp As String = "USP_MOROSIDADAPROBADO"

        Public Const DatosAjustesEnt As String = "USP_ENT_LISTA_AJUSTES"
        Public Const AjustesDifCambio As String = "USP_ENT_AJUSTE_DIF_CAMBIO"

        Public Const ListarReintegro As String = "USP_Listar_Reintegros"
        Public Const ListarPendLiquidacion As String = "USP_LISTAR_PENDLIQUIDACION"
        Public Const ListarAplicaciones As String = "USP_ERP_LISTARAPLICACION"
        Public Const AplicarReintegro As String = "USP_APLICAREINTEGRO"
        Public Const QuitarAplicacion As String = "USP_ERP_QUITARAPLICACION"
        Public Const ReporteViaticos As String = "USP_ERP_PROM_VIATICO"
        Public Const ReporteDetalleViaticos As String = "USP_ERP_DETALLE_VIATICO"
        Public Const ConsultaRecibos As String = "USP_ERP_CONSULTA_RECIBOS"
        Public Const ConsultaDocumentosAprobados As String = "USP_ERP_CONSULTA_DOCUMENTOSAPROBADOS"
        Public Const ConsultaCTRAplicaciones As String = "USP_CTR_LISTA_APLICACIONES_ANT"
        Public Const ConsultaCTRListaAnticipo As String = "USP_CTR_LISTA_ANTICIPO"
        Public Const ConsultaCTRListaDocumento As String = "USP_CTR_LISTA_DOCUMENTO"
        Public Const SolicitudAprobada As String = "USP_ERP_SOLICITUDAPROBADA"
        Public Const Reporte_Rendimiento As String = "usp_pdc_reporte_rendimiento_xmolino"
        Public Const RPTSINSUSTENTO As String = "USP_ERP_RPTSINSUSTENTO"
        Public Const ReporteRH As String = "USP_RH_LIQUIDADO"

        Public Const MineralFlete As String = "USP_RPT_MINERAL_FLETEEXT"

        Public Const ReporteLimiteRH As String = "USP_RPT_RH_LIMITE"
        Public Const ReporteRH_Resumen As String = "USP_RH_LIQUIDADO_RESUMEN"
        Public Const RPT_PROYECCIONVENTARUMA As String = "USP_RPT_PROYECCIONVENTARUMA"
        Public Const LISTARPROVISIONES As String = "USP_LISTARPROVISIONES"
        Public Const ReporteDAC As String = "USP_ERP_RPTDAC"
        Public Const ConsultaUsuariosDocumentos As String = "USP_ERP_USUARIO_VER_DOCUMENTOS"
        Public Const Ingreso_Tasa As String = "USP_PP_INGRESO_TASA"
        Public Const Tasa_Proveedor As String = "USP_PP_TASA_PROVEEDOR"
        'Public Const Factura_Pagar As String = "USP_PP_FACTURA_PORPAGAR"
        Public Const Factura_Pagar As String = "USP_PP_FACTURA_PORPAGAR_2024"
        Public Const Ingreso_Calculo_Cab As String = "USP_PP_INGRESO_CALCULO_CAB"
        Public Const Ingreso_Calculo_Det As String = "USP_PP_INGRESO_CALCULO_DET_2024"
        'Public Const Listar_Calculo_PP As String = "USP_PP_LISTA_CALCULO"
        Public Const Listar_Calculo_PP As String = "USP_PP_LISTA_CALCULO_2024"

        Public Const Listar_Correo_PP As String = "USP_ENVIA_CORREO_PRONTO_PAGO"

        'Public Const Factura_Calculo As String = "USP_PP_FACTURA_CALCULO"
        Public Const Factura_Calculo As String = "USP_PP_FACTURA_CALCULO_2024"

        Public Const Costo_ManoObra As String = "USP_COSTO_MANO_OBRA_PRODUCCION_DS"
        Public Const Costo_Validacion As String = "USP_COST_VALIDACION"
        Public Const Costo_Cierre As String = "USP_COST_CIERRE"
        Public Const Costo_RptComparativoMinas As String = "usp_cost_rpt_comparativo_minas"
        Public Const Costo_VerificaCierre As String = "USP_COST_VERIFICACIERRE"
        Public Const Costo_RevisionCantera As String = "Usp_Cont_Minas_Canteras"
        Public Const Costo_RevisionCantera_Cta9 As String = "Usp_Cont_Minas_Canteras_Cta9"

        Public Const Costo_RevisionCanteraID As String = "Usp_Cont_Minas_Canteras_id"
        Public Const Costo_ActualizaCantera As String = "USP_COST_ACTUALIZA_CANTERA"
        Public Const Costo_CostoMineral As String = "USP_COST_COSTO_MINERAL"
        Public Const Costo_Seguro As String = "USP_COST_PLA_SEGURO"
        Public Const Costo_DiasHabiles As String = "USP_COST_DIAS_HABILES"
        Public Const Costo_RegistraDias As String = "USP_COST_INSERTA_DIAS_HABILES"
        Public Const Costo_RegistraSeguro As String = "USP_COST_INSERTA_SEGURO_LEY"
        Public Const Costo_ReplicaSeguro As String = "USP_COST_REPLICA_SEGURO"
        Public Const Costo_Indirecto As String = "usp_cost_indirecto"
        Public Const Costo_ListaCuentas As String = "USP_COST_LISTA_CUENTA"
        Public Const Costo_RegistraCuenta As String = "USP_COS_MANT_CUENTA_NOCONSIDERAR"
        Public Const Costo_ListaEquipos As String = "USP_COST_LISTA_EQUIPOS"

        Public Const Consumo_Ene_Mes As String = "Consumo_Ene_Mes"

        Public Const Costo_RegistraCostEquipo As String = "USP_COST_MANT_EQUIPOS"
        Public Const Costo_ListaPorcAyo As String = "usp_cost_porcproduccion_ayo"
        Public Const Costo_RegistraPorcProduccion As String = "USP_COST_MANT_PORCPRODUCCION"
        Public Const Costo_RptIndirecto As String = "Usp_Cost_Traer_Costos_Indirectos"

        Public Const Costo_ListaSeteoVTAADM As String = "USP_COST_LISTA_SETEO_ADMVENTTA"
        Public Const Costo_MantSeteoVTAADM As String = "USP_COST_SETEO_ADMVTA_CUENTA"

        Public Const CE_RESUMEN_MENSUAL As String = "USP_CE_RPT_CONSUMO"

        Public Const Costo_RptIndirectoCAL As String = "Usp_Cost_Traer_Costos_Indirectos_CAL"
        Public Const Costo_RptIndirectoTerrazo As String = "Usp_Cost_Traer_Costos_Indirectos_Terrazo"
        Public Const Costo_RptIndirectoPastas As String = "Usp_Cost_Traer_Costos_Indirectos_Pastas"
        Public Const Costo_MP_CAL As String = "USP_COST_PRODUCC_CAL"
        Public Const Costo_MP_Terrazo As String = "USP_COST_PRODUCC_TERRAZO"
        Public Const Costo_MP_Pasta As String = "USP_COST_PRODUCC_PASTA"
        Public Const Costo_ReportePresentacion As String = "USP_COST_RPTPRESENTACION"

        Public Const Costo_ReporteCanteras As String = "Usp_Cont_Minas_Canteras_Costos"

        Public Const Costo_ReporteTrimestral As String = "USP_COST_TRIMESTRAL"

        Public Const Costo_DetalleCostoProd As String = "USP_COST_DETALLE_COSTO_PROD"

        Public Const Costo_ReporteTrimestralRuma As String = "USP_COST_TRIMESTRAL_RUMA"
        Public Const Costo_ReporteTrimestralMO As String = "USP_COST_TRIMESTRAL_MO"
        Public Const Costo_MesesProduccion As String = "USP_COSTO_MESES_PRODUCCION"

        Public Const Costo_GastoExportacion As String = "PA_RptCuadroComision_Costo"

        Public Const Costo_ReportePresentacionCAL As String = "USP_COST_RPTPRESENTACIONCAL"
        Public Const Costo_ReportePresentacionTERRAZO As String = "USP_COST_RPTPRESENTACIONTERRAZO"
        Public Const Costo_ReportePresentacionPASTAS As String = "USP_COST_RPTPRESENTACIONPASTAS"
        Public Const Costo_COST_ALTOBAJO As String = "USP_COST_ALTOBAJO"
        Public Const Costo_PRECIOPRODUCTO As String = "USP_LISTA_CLIENTE_PRODUCTO_PRECIO"
        Public Const Costo_COSTOXMOLINO As String = "USP_COST_COSTOXMOLINO"

        Public Const Costo_CONSUMO_ENERGIA As String = "USP_COST_LISTA_CONSUMO_ENERIGA"
        Public Const PP_RPT_CONTROL As String = "USP_PP_RPT_CONTROL"

        Public Const Costo_COSTOXCHANCADORA As String = "USP_COST_COSTOXCHANCADORA"
        Public Const Costo_COSTOXRUMA As String = "USP_COST_COSTOXRUMA"
        Public Const Costo_COST_MIN_CANTERA As String = "usp_Cantera_Mineral_CosteoMinerales_V1_2016_Cantera"
        Public Const INDICADOR_PRODUCCION As String = "USP_INDICADOR_PRODUCCION_ANUAL"
        Public Const REPORTE_PARADA As String = "USP_REPORTE_PARADA"
        Public Const INDICADOR_PRODUCCION_FINAL As String = "USP_INDICADOR_PRODUCCION_FINAL"
        Public Const INDICADOR_ADMINISTRACION_FINAL As String = "USP_INDICADOR_ADMINISTRACION_FINAL"
        Public Const INDICADOR_ADMINISTRACION_FINAL_DETALLE As String = "USP_LISTA_DETALLE_INDICADOR"
        Public Const INDICADOR_COMPRA_DETALLE As String = "USP_IND_DETALLE_COMPRA"

        Public Const RPT_CUENTA9 As String = "USP_RPT_CUENTA9"

        Public Const RPT_COSTOS_ADM As String = "USP_RPT_COSTOS_ADM"
        Public Const RPT_RESUMEN_ENTREGAS As String = "USP_ERP_RESUMEN_ENTREGAS"

        Public Const INDICADOR_COMERCIAL_DETALLE As String = "USP_IND_DETALLE_COMERCIAL"
        Public Const INDICADOR_DETALLE As String = "USP_IND_DETALLE_INDICADOR"
        Public Const LISTAR_AREA As String = "USP_IND_LISTAAREA"
        Public Const LISTAR_INDPRINCIPAL As String = "USP_INDPRINCIPAL_AREA"
        Public Const LISTAR_INDICADORES As String = "USP_IND_VALORES_CONCEPTO_MES"
        Public Const CARGA_INDICADORES As String = "USP_IND_CARGA_DATOS"
        Public Const LISTAR_INDICADORES_FINAL As String = "USP_IND_VALORES_CONCEPTO_DIRECTO_MES"
        Public Const INSERTA_INDICADORES As String = "USP_IND_INSERTA_VALORES"
        Public Const LISTA_PARA_CAMPANIA As String = "USP_LISTA_PARA_CAMPANIA"
        Public Const LISTA_NAVIERA As String = "USP_NAVIERA"
        Public Const MANT_NAVIERA As String = "USP_NAVIERA_MANT"
        Public Const LISTA_TARIFA_NAV As String = "USP_TARIFA_NAV"
        Public Const MANT_TARIFA_NAV As String = "USP_MANT_TARIFA_NAV"
        Public Const APRUEBA_TARIFA_NAV As String = "USP_APRUEBATARIFA"

        Public Const APRUEBA_TARIFA As String = "USP_USER_APRUEBATARIFA"

        Public Const LISTA_TRAZA_COSTO As String = "USP_COST_COSTOSPRODUCTO"
        Public Const LISTA_TRAZA_COSTO_MOL As String = "USP_COST_DET_MOLIENDA_PROD"
        Public Const LISTA_TRAZA_COSTO_CH As String = "USP_COST_DET_CHANCADO_PROD"
        Public Const LISTA_TRAZA_COSTO_MIN As String = "USP_COST_TRAZA_DET_MINERAL"
        Public Const MANT_PARA_CAMPANIA As String = "USP_ERP_PARA_CAMPANIA"
        Public Const INDICADOR_ENERGIA As String = "USP_INDICADOR_ENERGIA"
        Public Const CAPACIDAD_CEMENTO As String = "USP_CAPACIDAD_CEMENTO"
        Public Const INDICADOR_DEVOLUCION As String = "USP_IND_DET_DEVOLUCION"
        Public Const INDICADOR_VARIOS As String = "USP_INDICADOR_MANOOBRA"
        Public Const Costo_RPT_MIN_CANTERA As String = "USP_RPT_COSTEO_MIN_CANTERA"
        Public Const Costo_RPT_MIN_CANTERA_T As String = "USP_RPT_COSTEO_MIN_CANTERA_T"
        Public Const Costo_COST_MINERAL_DET As String = "USP_COSTO_MINERAL_DET"

        Public Const Costo_RPT_GUIA_FACTURA As String = "USP_GUIA_FACTURA_FLETE"

        Public Const Costo_COST_RUMA_COMPARATIVO As String = "USP_COSTO_RUMA_COMPARATIVO"
        Public Const Costo_COST_CH_COMPARATIVO As String = "USP_COSTO_CHANCADORA_COMPARATIVO"
        Public Const Costo_COST_MOLINO_COMPARATIVO As String = "USP_COSTO_MOLINO_COMPARATIVO"
        Public Const Costo_ListaActivoClase As String = "USP_COST_LISTA_ACTIVOS_CLASE"
        Public Const Costo_ListaTipoComb As String = "USP_COST_TIPO_COMB"
        Public Const Costo_MantActivoTipo As String = "usp_cost_mant_activos_tipo"
        Public Const Costo_MantActivoClase As String = "usp_cost_mant_activos_clase"
        Public Const Costo_ListacostoPromedio As String = "usp_cost_lista_costo_promedio"
        Public Const Costo_ListacostoPromedio_Rango As String = "usp_cost_lista_costo_promedio_Rango"
        Public Const Costo_Abrir_Margenes As String = "USP_COST_LIBERA_MES_MARGEN"
        Public Const Costo_VerificaTipo As String = "USP_COST_VERIFICA_TIPOPRODUCTO"
        Public Const Costo_IngresaTipo As String = "USP_COST_PROD_GRUPO"
        Public Const Costo_ProcesaMargen As String = "usp_cost_vta_detalle_acumulado_Rango"
        Public Const Costo_ListaProducto As String = "USP_COST_LISTA_PRODUYCTO"
        Public Const Costo_ListaCantera As String = "USP_COST_LISTA_CANTERA"
        Public Const Costo_ClonarRegistro As String = "USP_COSTO_CLONAR_REGISTRO"
        Public Const Costo_ClonarRegistro_Rango As String = "USP_COSTO_CLONAR_REGISTRO_RANGO"
        Public Const Costo_ClonarEnvase As String = "USP_CLONAR_ENVASE"
        Public Const Costo_Prom_EliminarRegistro As String = "USP_COSTOPROMEDIO_ELIMINAR_REGISTRO"
        Public Const Costo_ListaConcepto As String = "USP_COSTO_PROM_LISTACONCEPTOS"
        Public Const Costo_Prom_IngresoRegistro As String = "USP_COSTO_PROM_INGRESO_REGISTRO"
        Public Const Costo_Prom_IngresoRegistro_Rango As String = "USP_COSTO_PROM_INGRESO_REGISTRO_RANGO"
        Public Const Costo_ListaDocumentos As String = "usp_cost_lista_documentos"
        Public Const Costo_IngresoEnergiaGas As String = "USP_COST_INGRESO_ENERGIA_GAS"
        Public Const Costo_ListaEnergiaGas As String = "usp_cost_lista_energia_gas"
        Public Const Costo_ListaAgua As String = "usp_cost_lista_agua"
        Public Const Costo_ListaCuentasMPrev As String = "USP_COST_LISTA_CUENTA_MPREVENTIVO"
        Public Const Costo_RegistraCuentaMPrev As String = "USP_COS_MANT_CUENTA_MPREVENTIVO"
        Public Const Costo_CuentasMPrev As String = "usp_cost_Mpreventivo"
        Public Const Costo_PorcentajeCosteo As String = "USP_COST_PORCENTAJECOSTEO"
        Public Const Costo_Mant_PorcentajeCosteo As String = "USP_COST_MANT_PORCENTAJECOSTEO"
        Public Const Costo_ReporteDetMolienda As String = "USP_COST_DET_MOLIENDA"
        Public Const Costo_ReporteDetChancado As String = "USP_COST_DET_CHANCADO"
        Public Const Costo_ReporteDetMoliendaCAL As String = "USP_COST_DET_MOLIENDA_CAL"

        Public Const Costo_ReporteDetalleMoliendaCAL As String = "USP_COST_DETALLE_MOLIENDA_CAL"
        Public Const Costo_ReporteDetalleMoliendaTERRAZO As String = "USP_COST_DETALLE_MOLIENDA_TERRAZO"
        Public Const Costo_ReporteDetalleMoliendaPASTAS As String = "USP_COST_DETALLE_MOLIENDA_PASTAS"
        Public Const Costo_ReporteDetalleMolienda As String = "USP_COST_DETALLE_MOLIENDA"

        Public Const Costo_ReporteDetMoliendaTERRAZO As String = "USP_COST_DET_MOLIENDA_TERRAZO"
        Public Const Costo_ReporteDetMoliendaPASTAS As String = "USP_COST_DET_MOLIENDA_PASTAS"
        Public Const Costo_ReporteDetMatPrima As String = "USP_COST_DET_MATPRIMA_CAL"
        Public Const Costo_ReporteDetMatPrimaTERRAZO As String = "USP_COST_DET_MATPRIMA_TERRAZO"
        Public Const Costo_ReporteDetMatPrimaPASTAS As String = "USP_COST_DET_MATPRIMA_PASTAS"
        Public Const Costo_ReporteDetMineral As String = "USP_COST_DET_MINERAL"
        Public Const Costo_TonIngresada As String = "USP_COST_INGRESO_MINERAL"
        Public Const Costo_TonIngresada_Anual As String = "USP_COST_INGRESO_MINERAL_ANUAL"
        Public Const Costo_ValidaCantera As String = "USP_COST_VALIDA_CANTERA"
        Public Const Costo_Bolsa As String = "USP_COSTO_CONCEPTO_MINA_PRORRATEO"
        Public Const Costo_Kardex As String = "USP_COST_KARDEX_MINERAL"
    End Structure
    Public Structure PPA_Empleado
        Event z()
        Public Const ListarPagoTrabajador As String = "Pla_MuestraPago_Trabajador"
        Public Const MantPagoTrabajador As String = "Pla_Up_Autorizar_Pago_Trabajador"
        Public Const prueba As String = "PruebaCSV"
    End Structure
    Public Structure PPA_Contratista
        Event z()
        Public Const ListarContratista As String = "USP_CTR_LISTARCONTRATISTA"
        Public Const ListarContratistaConsulta As String = "USP_CTR_LISTARCONTRATISTACONSULTA"
        Public Const ListarFrecuencia As String = "USP_CTR_LISTAR_FRECUENCIAPAGO"
        Public Const ActualizaContratista As String = "USP_ACTUALIZACONTRATISTA"
        Public Const ListarCantera As String = "USP_CTR_CANTERACONTRATISTA"
        Public Const ListarSupervisor_Contratista As String = "USP_CTR_SUPERVISORCONTRATISTA"
        Public Const ListarAfp As String = "USP_CTR_LISTARAFP"
        Public Const ListarMineralAniticipo As String = "USP_CTR_LISTARMINERALANTICIPO"
        Public Const ListarPlanillaAniticipo As String = "USP_CTR_LISTARPLANILLAANTICIPO"
        Public Const ListarTipodoc As String = "USP_CTR_LISTARTIPODOC"
        Public Const FechaSemana As String = "USP_CTR_FECHA_SEMANA"
        Public Const Mant_Planilla As String = "USP_CTR_MANT_PLANILLA"
        Public Const ListarPlanilla As String = "USP_CTR_LISTARPLANILLA"
        Public Const ListarPlanillaTrabajador As String = "USP_CTR_PLANILLA_XTRABAJADOR"
        Public Const ListarMineralContratista As String = "USP_CTR_MINERAL_CONTRATISTA"
        Public Const ListarBanco As String = "USP_ListarBancos"
        Public Const Mant_Conceptos As String = "USP_CTR_MANTCONCEPTOS"
        Public Const Listarconceptos As String = "USP_CTR_LISTARCONCEPTOS"

        Public Const ListarIQBFkardex As String = "USP_IQBF_PROD_LABORATORIO"
        Public Const ListarValidaProduccion As String = "USP_LISTA_VALIDA_PRODUCCION"
        Public Const ListarValidaVTAProduccion As String = "USP_LISTA_VALIDAVTA_PRODUCCION"
        Public Const MantValidaProduccion As String = "USP_VALIDACION_PRODUCCION"

        Public Const RegistrarModificarObsProduccion As String = "USP_RegistrarModificarObsProduccion"

        Public Const MantValidaVTAProduccion As String = "USP_VALIDACIONVTA_PRODUCCION"
        Public Const ListarIQBFkardexMov As String = "USP_IQBF_LISTAR_MOVIMIENTO_KARDEX"
        Public Const ListarIQBFRPTkardex As String = "USP_IQBF_RPT_KARDEX"
        Public Const IngresoIQBFkardex As String = "USP_ERP_KARDEX_LABORATORIO"

        Public Const Listarconceptos_Fact As String = "USP_CTR_LISTA_CONCEPTO_FACT"
        Public Const Mantconceptos_Fact_Cab As String = "USP_CTR_MANT_FACTURA_CAB"
        Public Const Mantconceptos_Fact_Det As String = "USP_CTR_MANT_FACTURA_DET"
        Public Const ListarTrabajadorContratista As String = "USP_CTR_TRABAJADOR_CONTRATISTA"
        Public Const Verifica_Trabajador_Liquidacion As String = "USP_VERIFICA_TRABAJADOR_LIQUIDACION"
        Public Const validaPeriodoVacaciones As String = "USP_CTR_VALIDA_PERIODOVACACIONES"

        Public Const ListarOrden As String = "USP_CTR_LISTARORDEN"
        Public Const CE_ListarOrden As String = "USP_CE_LISTAORDEN"
        Public Const CE_DetalleOrden As String = "USP_CE_DETALLEOC"

        Public Const CARGA_ENERGIA_ELECTRICA As String = "USP_MANT_CONSUMO_ENERGIA"
        Public Const CARGA_ENERGIA_ELECTRICA_MENSUAL As String = "USP_MANT_CONSUMO_ENERGIA_MENSUAL"
        Public Const CTR_INSERTA_CTAPAGKARDEX As String = "USP_CTR_INSERTA_CTAPAGKARDEX"
        Public Const CTR_ANT_NUMERO_VOUCHER As String = "USP_CTR_ANT_NUMERO_VOUCHER"

        Public Const CTR_ANT_GENERA_ASIENTO As String = "USP_CTR_GENERA_ASIENTO_ANT"

        Public Const LISTA_ENERGIA_ELECTRICA As String = "USP_LISTA_CONSUMO_ENERGIA"

        Public Const ListarObligaciones As String = "USP_CTR_CARGAOBLIGACIONES"
        Public Const detalleObligaciones As String = "USP_CTR_DETALLEOBLIGACIONES"
        Public Const ListarPrecioMineral As String = "USP_CTR_LISTAPRECIOMINERAL"
        Public Const ListarConceptoFact As String = "USP_CTR_LISTA_CONCEPTO_FACTURA"
        Public Const Mant_PrecioMineral As String = "USP_CTR_MANTPRECIOMINERAL"
        Public Const Mant_ConceptoFact As String = "USP_CTR_MANT_CONCEPTO_FACTURA"
        Public Const IngresoMineralFecha As String = "USP_CTR_INGRESOMINERAL_FECHA"
        Public Const billeteExistente As String = "USP_CTR_BILLETEEXISTENTE"
        Public Const validaPeriodo As String = "USP_CTR_VERIFICAPERIODOANTICIPO"
        Public Const ListarCTR_Factura As String = "USP_CTR_LISTA_FACTURA"
        Public Const validaPeriodoPlanilla As String = "USP_CTR_VERIFICAPERIODOANTICIPO_PLANILLA"
        Public Const ListarImpuestos As String = "USP_CTR_LISTADO_IMPUESTOS"
        Public Const ListarSaldoImpuestos As String = "USP_CTR_SALDOIMPUESTO"
        Public Const ListarSaldoImpuestosAnticipo As String = "USP_CTR_SALDOIMPUESTOANTICIPO"
        Public Const MantSuspension As String = "USP_ERP_MANTSUSPENSION"
        Public Const MantRetencionRH As String = "USP_ERP_MANTRETENCIONRH"
        Public Const MantReciboRH As String = "USP_ERP_MAT_CONCEPTORH"
        Public Const MantFechaViatico As String = "MANT_FECHA_GASTOVIATICO"
        Public Const ImportarPlanilla As String = "USP_CTR_PLANILLAPAGO"
        Public Const ImportarGratiCts As String = "USP_CTR_PLANILLA_GRATI_CTS"
        Public Const EliminaPlanillaPeriodo As String = "USP_CTR_ELIMINA_PLANILLA"
        Public Const ListarSeteoExcel As String = "USP_CTR_LISTARSETEOEXCEL"
        Public Const IngresoPlanillaFecha As String = "USP_CTR_PLANILLA_FECHA"
        Public Const ListaPlanillaFechaContratisa As String = "USP_CTR_PLANILLA_FECHA_CONTRATISTA"
        Public Const IngresoGratiCtsFecha As String = "USP_CTR_GRATICTS_FECHA"
        Public Const ListarGratificacionAniticipo As String = "USP_CTR_LISTARGRATICTSANTICIPO"
        Public Const CargarImpuestoAnticipo As String = "USP_CTR_LISTARIMPUESTOANTICIPO"
        Public Const CargarObligacionAnticipo As String = "USP_CTR_LISTAROBLIGACIONANTICIPO"
        Public Const CargarVacacionesAnticipo As String = "USP_CTR_LISTARVACACIONESANTICIPO"
        Public Const ListarConceptoLiquidacion As String = "USP_CTR_LISTARCONCEPTOLIQUIDACION"
        Public Const ListarCanteraAnticipo As String = "USP_CTR_CANTERAANTICIPO"
        Public Const ListarRetencionSolicitud As String = "USP_LISTA_RETENCION_VALIDAR"
        Public Const ListarRetencionxValidar As String = "USP_LISTA_RETENCIONXVALIDAR"
        Public Const ValidarRetencionSolicitud As String = "USP_VALIDA_RETENCIORH"
        Public Const CargarCanteraAnticipo As String = "USP_CTR_LISTARCANTERAANTICIPO"
        Public Const ListarOtraFactura As String = "USP_LISTAR_OTRAFACTURA"
        Public Const ListarAlmacen As String = "USP_CE_LISTARALMACEN"
        Public Const ListarActivoContratista As String = "USP_CE_LISTA_ACTIVOCONTRATISTA"
        Public Const VerificaActivoContratistaMes As String = "USP_CE_VERIFICA_ACTIVOCONTRATISTAMES"
        Public Const AperturaActivoContratistaMes As String = "USP_CE_APERTURA_ACTIVOCONTRATISTAMES"
        Public Const ListarTipoMovimiento As String = "USP_CE_LISTARTIPOMOVIMIENTO"
        Public Const Listar_TipoMovimiento As String = "USP_CE_LISTAR_TIPOMOVIMIENTO"
        Public Const TipoMovimientoConcepto As String = "USP_CE_TIPOMOV_CONCEPTO"
        Public Const ListarCliente As String = "USP_CE_LISTARCLIENTE"
        Public Const ListarMaquina As String = "USP_LISTA_MAQUINA"
        Public Const ListarEquipo As String = " "
        Public Const ListarClientes As String = "USP_ERP_LISTARCLIENTES"
        Public Const ListarClientesPareto As String = "USP_ERP_LISTARCLIENTESPARETO"
        Public Const ListarMovimientos As String = "USP_CE_LISTARMOVIMIENTOS"
        Public Const ListarProdOptima As String = "USP_LISTA_PROD_OPTIMA"
        Public Const MantProdOptima As String = "USP_MANT_PROD_OPTIMA"
        Public Const ListarMovimientoNumero As String = "USP_CE_MOVIMIENTO_NUMERO"
        Public Const BuscaTipoEquipo As String = "USP_CE_BUSCA_TIPOEQUIPO"

        Public Const Reg_Alquiler_Maquina As String = "USP_MIN_COMB_ALQ_MAQUINA_CAB"
        Public Const Reg_Alquiler_Maquina_Det As String = "USP_MIN_COMB_ALQ_MAQUINA_DET"

        Public Const ValidaCarga As String = "USP_CE_VERIFICACARGA"
        Public Const ListarCargas As String = "USP_CE_LISTA_CARGAS"

        Public Const CTR_ListarCombustible As String = "USP_CTR_LISTAR_COMBUSTIBLE"
        Public Const LISTA_CE_FACT_COMBUSTIBLE_CAB As String = "USP_LISTA_CE_FACT_COMBUSTIBLE_CAB"

        Public Const CTR_CE_FACT_COMBUSTIBLE_CAB As String = "USP_CE_FACT_COMBUSTIBLE_CAB"
        Public Const CTR_CE_FACT_COMBUSTIBLE_DET As String = "USP_CE_FACT_COMBUSTIBLE_DET"

        Public Const ListarEquipoCantera As String = "USP_LISTA_EQUIPO_CANTERA"

        Public Const InsertaEquipoCantera As String = "USP_MANT_ERP_EQUIPO_CANTERA"
        Public Const EliminaEquipoCantera As String = "USP_ELIM_ERP_EQUIPO_CANTERA"

        Public Const ListarFacturaAlquiler As String = "USP_FACTURA_FECHA_ALQUILER"
        Public Const ListarFacturaAlquiler_ID As String = "USP_FACTURA_REG_ALQUILER_ID"
        Public Const user_Aprueba_Alquiler As String = "USP_ERP_USUARIO_APRUEBA_REG_ALQUILER"
        Public Const ListarRegistroAlquiler As String = "USP_LISTA_REGISTRO_ALQUILER"
        Public Const ListarRegistroAlquiler_Det As String = "USP_MIN_REGISTRO_DET"

        Public Const Kardex As String = "USP_CE_KARDEX"
        Public Const Existencias As String = "USP_CE_EXISTENCIA"
        Public Const ValidaFechasCarga As String = "USP_CE_VALIDAFECHA_CARGA"
        Public Const MaqPesada As String = "USP_ERP_MAQPESADA"
        Public Const ListarDocumentoAprobar As String = "USP_ERP_LISTAR_COMPROBANTES_APROBAR"
        Public Const ValidaProduto As String = "USP_CE_VALIDAPRODUCTO"
        Public Const CTR_CONSULTA As String = "USP_CTR_CONSULTA"

        Public Const RptVacaciones_CTR As String = "USP_CTR_RPT_VACACIONES"
        Public Const RptExMedico_CTR As String = "USP_CTR_RPT_EXMEDICO"

        Public Const RptIgvRenta_CTR As String = "USP_CTR_RPTIGVRENTA"

        Public Const RptLiquidaciones_CTR As String = "USP_CTR_RPT_LIQUIDACIONES"

        Public Const Listar_PRO_Camiones As String = "USP_ERP_LISTA_CAMIONES"
        'Public Const Listar_PRO_Prov_Codigo As String = "USP_ERP_PROVEEDOR_CODIGO"
        Public Const Listar_PRO_Prov_Codigo As String = "USP_ERP_PROVEEDOR_CODIGO_2024"
        Public Const Listar_PRO_MantCamion As String = "USP_ERP_MANT_CAMION"
        Public Const Listar_PRO_Disponibilidad As String = "USP_LISTA_DISPONIBILIDAD"
        Public Const Listar_PRO_MantDisponibilidad As String = "USP_ERP_MANT_DISPNIBILIDAD"
        Public Const Listar_PRO_CamionDisponible As String = "USP_LISTA_CAMION_DISPONIBLE"
        Public Const Listar_PRO_Programacion As String = "USP_ERP_LISTA_PROGRAMACION"
        Public Const Listar_PRO_ConfigVehicular As String = "USP_ERP_LISTA_CONFIGVEHICULAR"
        Public Const Elimina_Programacion As String = "USP_ERP_ELIMINA_PROG_DIA"
        Public Const CargaUnacem As String = "USP_CARGA_UNACEM"

        Public Const CargaBilletesPrev As String = "USP_CARGA_BILLETE_MINERAL"

        Public Const ListaCargaUnacem As String = "USP_LISTA_CARGA_UNACEM"
        Public Const ListaCargaBilletePrev As String = "USP_LISTA_CARGA_BILLETE_PREV"

        Public Const ValidaCargaUnacem As String = "USP_VALIDA_CARGA_UNACEM"
        Public Const Registra_Programacion As String = "USP_ERP_REGISTRA_PROG_DIA"
        Public Const Listar_PRO_ProgramacionCamion As String = "USP_ERP_LISTA_PROGRAMACION_CAMION"
        Public Const Listar_PRO_ConsultaProgramacion As String = "USP_ERP_LISTA_CONSULTA_PROGRAMACION"
        Public Const Listar_PRO_Prod_Programacion As String = "USP_ERP_PRODUCTO_PROGRAMACION"
        Public Const Consulta_GuiaProgramacion As String = "USP_ERP_CONSULTA_GUIA_PROGRAMACION"
        Public Const Consulta_GuiaProgramacionV2 As String = "USP_ERP_CONSULTA_GUIA_PROGRAMACION_V2"
        Public Const Consulta_GuiaProgramacion2 As String = "USP_ERP_CONSULTA_GUIA_PROGRAMACION2"
        Public Const Reprogramacion_Pedido As String = "USP_ERP_REPROGRAMACION"
        Public Const Actualiza_Placa_Prog As String = "USP_ERP_ACTUALIZA_PLACA_PROG"
        Public Const llenar_Concepto As String = "USP_ERP_LISTACONCEPTO"
        Public Const Registra_Incidencia As String = "USP_ERP_INSERTA_INCIDENCIA_PROGRAMACION"
        Public Const Consulta_Incidencia As String = "USP_ERP_DETALLE_INCIDENCIA"
        Public Const llenar_Incidencia As String = "USP_ERP_LISTAINCIDENCIA"
        Public Const Elimina_Incidencia As String = "USP_ERP_ELIMINAINCIDENCIA"
        Public Const Mant_Concepto_Prog As String = "USP_ERP_MANT_CONCEPTO_PROG"
        Public Const Mant_Incidencia_Prog As String = "USP_ERP_MANT_INICIDENCIA_PROG"
        'ConsultarLecturaDrone
        Public Const ConsultarConsumoRecursos As String = "erp_mant_ConsumoRecursos"
        Public Const ConsultarLecturaDrone As String = "erp_mant_LecturaRumaDron"
    End Structure
    Public Structure PPA_Produccion
        Event Z()
        Public Const ImportarCronograma As String = "PPA_ImportarCronograma"
        Public Const MantenimientoPlanilla As String = "PPA_MantenimientoPlanilla"
        Public Const MantenimientoUnidadPersonal As String = "PPA_MantenimientoUnidadPersonal"
        Public Const ConsultarConexion As String = "PPA_ConsultarConexion"
        Public Const ConsultarPermisos As String = "PPA_ConsultarPermisos"
        Public Const ConsultaCostosIndirectos As String = "PPA_ConsultaCostosIndirectos"
        Public Const ConsultarBusquedaEnlace As String = "PPA_ConsultarBusquedaEnlace"
        Public Const ConsultarEnlace As String = "PPA_ConsultarEnlace"
        Public Const ConsultarProdProyectado As String = "USP_LISTAR_PRODPROYECTADO"
        Public Const MantenimientoxEnlace As String = "PPA_MantenimientoEnlace"
        Public Const MantenimientoxCronograma As String = "PPA_MantenimientoxCronograma"
        Public Const ConsultarCronograma As String = "PPA_ConsultarCronograma"
        Public Const ConsultarProgramacion As String = "PPA_ConsultarProgramacion"
        Public Const ConsultarPersonal As String = "PPA_ConsultarPersonal"
        Public Const ConsultarProveedor As String = "PPA_ConsultarProveedor"

        Public Const ConsultarSeteoRumas As String = "erp_mant_seteoRumas"


        Public Const MantenimientoxRequerimiento As String = "PPA_MantenimientoxRequerimiento"
        Public Const ConsultarMinerales As String = "PPA_ConsultarMinerales"
        Public Const ConsultarProducto As String = "PPA_ConsultarProducto"
        Public Const ConsultarSubfamilia As String = "erp_mant_SubFamiliaProductosProduccion"
        Public Const Consultarfamilia As String = "erp_mant_familiaProductosProduccion"

        Public Const ConsultarFamiliaProductoFamilia As String = "erp_mant_ProductosSubFamiliaProduccion"
        Public Const Lista_HoraDia As String = "USP_PROY_HORA_DIA"
        Public Const Lista_Tarea As String = "USP_PROY_LISTA_TAREA"
        Public Const Lista_Taller As String = "USP_PROY_LISTATALLER"
        Public Const Lista_Proyecto As String = "USP_PROY_LISTAPROYECTO"
        Public Const ValidaPlano As String = "USP_PROY_VALIDAPLANO"
        Public Const Lista_Equipo As String = "USP_PROY_LISTAEQUIPO"
        Public Const Actualiza_HoraDia As String = "USP_PROY_ACT_HORA_DIA"
        Public Const Mant_Tarea As String = "USP_PROY_MANT_TAREA"

        Public Const Mant_SubTarea As String = "USP_PROY_MANT_SUBTAREA"
        Public Const Mant_Planificacion As String = "USP_PROY_MANT_PLANIFICACION"
        Public Const Lista_Planificacion As String = "USP_LISTA_PLANIFICACION"
        Public Const Lista_PlanificacionID As String = "USP_LISTA_PLANIFICACION_ID"

        Public Const Lista_PlanificacionOrden As String = "USP_LISTA_PLANIFICACION_ORDEN"

        Public Const Lista_PlanificacionAvance As String = "USP_LISTA_PLANIFICACION_AVANCE"
        Public Const Lista_PlanificacionProyecto As String = "USP_LISTA_PLANIFICACION_PROYECTO"
        Public Const Lista_EquipoProyecto As String = "USP_PROY_EQUIPO_PROYECTO"

        Public Const Lista_DetalleTaller As String = "USP_PROY_DETALLE_TALLER"

        Public Const Lista_TallerID As String = "USP_LISTA_TALLER_ID"
        Public Const Lista_AvanceSubtarea As String = "USP_PROY_AVANCE_SUBTAREA"
        Public Const Lista_AvanceFisicoSub As String = "USP_PROY_AVAN_FISICO_FECHA"
        Public Const Mant_AvanceFisicoSub As String = "USP_PROY_SUBTAREA_AVANCE_FISICO"

        Public Const Actu_Subtarea As String = "USP_PROY_ACTUALIZA_SUBTAREA"
        Public Const ReporteGant As String = "USP_PROY_RPT_GANT"
        Public Const ReporteGantReal As String = "USP_PROY_RPT_GANT_REAL"
        Public Const ReporteValor As String = "USP_PROY_RPTVALOR"

        Public Const CierreProyecto As String = "USP_PROY_CIERRE_PROYECTO"
        Public Const CierreTaller As String = "USP_PROY_CIERRE_TALLER"

        Public Const Lista_DetSubtareaID As String = "USP_PROY_LISTA_DETSUBTAREA"

        Public Const Lista_DetSubtareaIDREAL As String = "USP_PROY_LISTA_DETSUBTAREA_REAL"

        Public Const Lista_Personal As String = "USP_LISTA_PERSONAL"
        Public Const Lista_PersonalExt As String = "USP_PROY_LISTA_PERSONAL_EXT"
        Public Const Lista_PersonalExtMant As String = "USP_PROY_PERSONAL_EXTERNO"
        Public Const Lista_Subtarea As String = "USP_PRY_LISTA_SUBTAREA"

        Public Const Lista_Material As String = "USP_PROY_LISTA_SUMINISTRO"
        Public Const Costo_Material As String = "USP_PROY_COSTO_SUMINISTRO"

        Public Const Lista_Servicio As String = "USP_PROY_LISTA_SERVICIO"
        Public Const Costo_Servicio As String = "USP_PROY_COSTO_SERVICIO"

        Public Const Mant_Pla_Tarea As String = "USP_PROY_PLANIF_TAREA"
        Public Const Mant_Plano As String = "USP_PROY_PLANIF_PLANO"
        Public Const Mant_PlanoDET As String = "USP_PROY_PLANIF_PLANODET"

        Public Const Mant_SubPersonal As String = "USP_PROY_PLANIF_SUB_PERSONAL"
        Public Const Mant_SubMaterial As String = "USP_PROY_PLANIF_SUB_MATERIAL"
        Public Const Mant_SubServicio As String = "USP_PROY_PLANIF_SUB_SERVICIO"

        Public Const ConsultarSuministros As String = "PPA_ConsultaSuministro"
        Public Const ConsultarSuministros_xAlmacen As String = "PPA_ConsultaSuministro_v2"

        Public Const ConsultarStockProducto As String = "PPA_ConsultarStockProducto"
        Public Const MantenimientoxFormula As String = "PPA_MantenimientoFormula"
        Public Const MantenimientoMineralProductoProyeccion As String = "USP_MANT_MINERALPRODUCTO_PROYECTADO"
        Public Const EliminaMineralProductoProyeccion As String = "USP_ELIMINA_MINERALPRODUCTO_PROYECTADO"
        Public Const MantenimientoxFormula_Masivo As String = "PPA_MantenimientoFormula_Masivo"
        Public Const Consultar_Formulaciones As String = "USP_RPT_FORMULACION"
        Public Const ConsultarAlmacen As String = "PPA_ConsultarAlmacen"
        Public Const ConsultarRuma As String = "PPA_ConsultarRuma"
        Public Const ConsultarMineral As String = "Usp_ListarMineral"
        Public Const MantenimientoxMatrizxActivo As String = "PPA_MantenimientoxMatrizxActivo"
        Public Const ConsultarActivos As String = "PPA_ConsultarActivos"
        Public Const ConsultarSuministro As String = "PPA_ConsultarSuministro"
        Public Const ConsultarUsuario As String = "PPA_ConsultarUsuario"
        Public Const ConsultarOpcionesUsuario As String = "PPA_ConsultarOpcionesUsuario"
        Public Const ConsultarDisponibilidadUsuario As String = "PPA_ConsultarDisponibilidadUsuario"
        Public Const MantenimientoxUsuario As String = "PPA_MantenimientoUsuario"
        Public Const MantenimientoAreaxUsuario As String = "PPA_MantenimientoAreaxUsuario"
        Public Const ConsultarProyeccion As String = "PPA_ConsultarProyeccion"
        Public Const MantenimientoxProyeccion As String = "PPA_MantenimientoProyeccion"
        Public Const ConsultarFactor As String = "PPA_ConsultarFactor"
        Public Const CuadroxOrdenxRuma As String = "PPA_CuadroxOrdenxRuma"
        Public Const CuadroxOrdenxRumaxProdTerminadoxSuministro As String = "PPA_CuadroxOrdenxRumaxProdTermxSuministro"
        Public Const CuadroxOrdenxProdTerminadoxSuministro As String = "PPA_Consultar_ProdTermxSuministro"
        Public Const CuadroxOrdenxRumaxMineral As String = "PPA_ConsultarRumaMineral"
        Public Const ReportexCuadroxActivo As String = "PPA_ReportexCuadroxActivo"
        Public Const CuadroxOrdenxSuministro As String = "PPA_CuadroxOrdenxSuministro"
        Public Const MantenimientoOrden1 As String = "PPA_MantenimientoOrden1"
        Public Const MantenimientoOrden2 As String = "PPA_MantenimientoOrden2"
        Public Const MantenimientoOrden3 As String = "PPA_MantenimientoOrden3"
        Public Const MantenimientoOrden4 As String = "PPA_MantenimientoOrden4"
        Public Const MantenimientoOrden5 As String = "PPA_MantenimientoOrden5"
        Public Const MantenimientoOrden5_D As String = "PPA_MantenimientoOrden5_D"
        Public Const MantenimientoOrden5_P As String = "PPA_MantenimientoOrden5_P"
        Public Const MantenimientoOrden5_M As String = "PPA_MantenimientoOrden5_M"
        Public Const CuadroDisponUnidad As String = "PPA_CuadroDisponUnidad"
        Public Const CuadroDisponUnidadxEnlace As String = "PPA_CuadroDisponUnidadxEnlace"
        Public Const ListarExportacion As String = "PPA_ListarExportacion"
        Public Const ProductosExportacion As String = "Pro_Filtrar_ProductosVenta"
        Public Const ConsultarPermisoStockMinimo As String = "usp_BuscarUsers"
        Public Const MantenimientoOpciones As String = "PPA_MantenimientoOpciones"
        Public Const ConsultarPedidosExportacion As String = "PPA_ConsultarPedidosExportacion"
        Public Const MantenimientoProducto As String = "PPA_MantenimientoProducto"
        Public Const MantenimientoSuministro As String = "PPA_MantenimientoSuministro"
        Public Const Converciones As String = "PPA_Converciones"
        Public Const ConsultasMaestros As String = "PPA_ConsultasMaestros"
        Public Const ConsultarCodVenta As String = "PPA_ConsultarCodVenta"
        Public Const MantenimientoEmpaques As String = "PPA_MantenimientoEmpaques"
        Public Const CuadroxOrdenxUnidad As String = "PPA_CuadroxOrdenxUnidad"
        Public Const ConsultarOrden As String = "PPA_ConsultarOrden"
        Public Const ConsultarOrden_Pesaje_Ruma As String = "PPA_Consultar_OrdenProduccion_Pesaje_Ruma"
        Public Const ConsultarOrden_Chancadora_Pesaje As String = "PPA_Consultar_Orden_Chancadora_Pesaje"
        Public Const ConsultarOrden_Chancadora_Molino As String = "PPA_Consultar_Orden_Chancadora_Molino"
        Public Const ConsultarOrden_Molienda_IP As String = "PPA_Consultar_Orden_Molienda_IngresoProduccion"
        Public Const ConsultaExportacion As String = "PPA_ConsultaExportacion"
        Public Const VerificarProforma As String = "PPA_VerificarProforma"
        Public Const ConsultaERP As String = "PPA_ConsultaERP"
        Public Const ListarCanteras_CosteoMineral As String = "usp_RAL_ObtenerCanteras_CosteoMinerales"

        REM JHTA Carga Archivo Peso Humedo
        Public Const ProdCargaPesoHum_VerificarCierre As String = "usp_Prod_CargaPesos_ValidarCierre"
        Public Const ProdCargaPesoHum_LimpiarRegistros As String = "usp_Prod_CargaPesos_LimpiarRegistros"
        Public Const ProdCargaPesoHum_RegistrarTrama As String = "usp_Prod_CargaPesos_RegistrarTrama"
        Public Const ProdCargaPesoHum_ListarCarga As String = "usp_Prod_CargaPesos_Listar"
        Public Const ProdCargaPesoHum_ListarCargaGrupo As String = "usp_Prod_CargaPesos_ListarSubidos"
        Public Const ProdCargaPesoHum_ActualizarResumen As String = "usp_Prod_CargaPeso_ActualizarResumen"

        REM Reportes
        Public Const ConsultarProformaGuia As String = "PPA_ConsultarProformaGuia"
        Public Const ConsultarProforma As String = "PPA_ConsultarProforma"
        Public Const EnvasesProducto As String = "PPA_EnvasesProducto"
        Public Const CRxOrdenDocumento As String = "PPA_CRxOrdenDocumento"
        Public Const CRxOrdenxActivo As String = "PPA_CRxOrdenxActivo"
        Public Const CRxOrdenxRuma As String = "PPA_CRxOrdenxRuma"
        Public Const CRxOrdenxSuministro As String = "PPA_CRxOrdenxSuministro"
        Public Const CRxConsultar_Requerimiento As String = "PPA_CRxConsultar_Requerimiento"
        Public Const ConsultarRequerimiento As String = "PPA_ConsultarRequerimiento"
        Public Const ValidarProductoOrden As String = "PPA_ValidarProductoOrden"
        Public Const Validar_Costeo_Produccion As String = "PPA_Validar_CosteoProduccion"
        Public Const Costeo_Produccion As String = "PPA_Consulta_CosteoProduccion"
        Public Const Costeo_Produccion_PrecioVenta As String = "PPA_ObtenerMaxMinPrecioProdTerminado"
        Public Const Consultar_SPID As String = "PPA_Costeo_Produccion_SPID"
        Public Const Costeo_Produccion_Generico_Delete As String = "PPA_CosteoProduccion_DeleteRegistros"
        Public Const Costeo_Produccion_Generico_Molino As String = "PPA_CreateTableMesxMolinoxCosteoProducto"
        Public Const Costeo_Produccion_Generico_Pala As String = "PPA_CreateTableMesxMolinoxPalaxCosteoProducto"
        Public Const Costeo_Produccion_Neto As String = "PPA_Costeo_ProductoNeto"
        Public Const Costeo_Produccion_Molino As String = "PPA_Costeo_General_Producto"
        Public Const Costeo_Produccion_Ruma As String = "PPA_Costeo_ProductoxRuma_Acumulado"
        Public Const Costeo_Produccion_Silice As String = "PPA_Costeo_ProductoxSilice_Acumulado"
        Public Const Costeo_Produccion_Chancadora_TranspInt As String = "PPA_Costeo_Chancadora_Transporte_Acumulado"
        Public Const Costeo_Produccion_Chancadora_ManttoMec As String = "PPA_Costeo_ProductoxChancadora_ManttoMecanico_Acumulado"
        Public Const Costeo_Produccion_Chancadora_Deprec As String = "PPA_Costeo_ProductoxChancadora_Depreciacion_Acumulado"
        Public Const Costeo_Produccion_Chancadora_Energia As String = "PPA_Costeo_ProductoxChancadora_Energia_Acumulado"
        Public Const Costeo_Produccion_Chancadora_ManoObra As String = "PPA_Costeo_Chancadora_MO_Acumulado"
        Public Const Costeo_Produccion_Chancadora As String = "PPA_Costeo_ProductoxUnidad_Chancadora"
        Public Const Costeo_Produccion_Chancadora_Detalle As String = "PPA_Costeo_ProductoxUnidad_Chancadora_Detalle"
        Public Const Costeo_Produccion_Pala As String = "PPA_Costeo_ProductoxUnidad_Pala"
        Public Const Costeo_Produccion_PalaDetalle As String = "PPA_Costeo_ProductoxUnidad_PalaDetalle"
        Public Const Costeo_Produccion_PalaDetalle_Comb As String = "PPA_Costeo_Activo_Combustible_Acumulado"
        Public Const Costeo_Produccion_PalaDetalle_Deprec As String = "PPA_Costeo_ProductoxPala_Depreciacion_Acumulado"
        Public Const Costeo_Produccion_ManoObra As String = "PPA_Costeo_ProductoxUnidad_MO_Acumulado"
        Public Const Costeo_Produccion_Chancadora_ManoObraNormal As String = "PPA_Costeo_Chancadora_MO"
        Public Const Costeo_Produccion_Pala_ManoObra As String = "PPA_Costeo_Pala_MO_Acumulado"
        Public Const Costeo_Produccion_Pala_Alquiler_Mantto As String = "PPA_Costeo_Pala_ManttoAlquiler_Acumulado"
        Public Const Costeo_Produccion_ManttoMecanico As String = "PPA_Costeo_ProductoxUnidad_ManttoMecanico_Acumulado"
        Public Const Costeo_Produccion_ManttoMecanico_Normal As String = "PPA_Costeo_ProductoxUnidad_ManttoMecanico"
        Public Const Costeo_Produccion_Depreciacion As String = "PPA_Costeo_ProductoxUnidad_Depreciacion_Acumulado"
        Public Const Costeo_Produccion_Depreciacion_Normal As String = "PPA_Costeo_ProductoxUnidad_Depreciacion"
        Public Const Costeo_Produccion_GasNatural As String = "PPA_Costeo_ProductoGasNatural_Acumulado"
        Public Const Costeo_Produccion_Envases As String = "PPA_Costeo_ProductoxSuministro_Acumulado"
        Public Const Costeo_Produccion_Energia As String = "PPA_Costeo_ProductoxUnidad_Energia_Acumulado"
        Public Const Costeo_Produccion_Energia_Normal As String = "PPA_Costeo_ProductoxUnidad_Energia"
        Public Const Costeo_Produccion_Generico_Molino_Cierre As String = "PPA_Costeo_ProductoxPalaChancadora_Cierre"
        Public Const Costeo_Produccion_Ruma_Cierre As String = "PPA_Costeo_ProductoxRuma_Cierre"
        Public Const Costeo_Produccion_Silice_Cierre As String = "PPA_Costeo_ProductoxSilice_Cierre"
        Public Const Costeo_Produccion_Chancadora_Cierre As String = "PPA_Costeo_ProductoxUnidad_Chancadora_Cierre"
        Public Const Costeo_Produccion_Chancadora_TranspInt_Cierre As String = "PPA_Costeo_Chancadora_Transporte_Cierre"
        Public Const Costeo_Produccion_Chancadora_ManttoMec_Cierre As String = "PPA_Costeo_ProductoxChancadora_ManttoMecanico_Cierre"
        Public Const Costeo_Produccion_Chancadora_Deprec_Cierre As String = "PPA_Costeo_ProductoxChancadora_Depreciacion_Cierre"
        Public Const Costeo_Produccion_Chancadora_Energia_Cierre As String = "PPA_Costeo_ProductoxChancadora_Energia_Cierre"
        Public Const Costeo_Produccion_Chancadora_ManoObra_Cierre As String = "PPA_Costeo_Chancadora_MO_Cierre"
        Public Const Costeo_Produccion_Pala_Cierre As String = "PPA_Costeo_ProductoxUnidad_Pala_Cierre"
        Public Const Costeo_Produccion_PalaDetalle_Comb_Cierre As String = "PPA_Costeo_Pala_Combustible_Cierre"
        Public Const Costeo_Produccion_Pala_ManoObra_Cierre As String = "PPA_Costeo_Pala_MO_Cierre"
        Public Const Costeo_Produccion_Pala_Depreciacion_Cierre As String = "PPA_Costeo_ProductoxPala_Depreciacion_Cierre"
        Public Const Costeo_Produccion_Pala_Alquiler_Mantto_Cierre As String = "PPA_Costeo_Pala_ManttoAlquiler_Cierre"
        Public Const Costeo_Produccion_ManoObra_Cierre As String = "PPA_Costeo_ProductoxUnidad_MO_Cierre"
        Public Const Costeo_Produccion_ManttoMecanico_Cierre As String = "PPA_Costeo_ProductoxUnidad_ManttoMecanico_Cierre"
        Public Const Costeo_Produccion_Depreciacion_Cierre As String = "PPA_Costeo_ProductoxUnidad_Depreciacion_Cierre"
        Public Const Costeo_Produccion_Energia_Cierre As String = "PPA_Costeo_ProductoxUnidad_Energia_Cierre"
        Public Const Costeo_Produccion_GasNatural_Cierre As String = "PPA_Costeo_ProductoGasNatural_Cierre"
        Public Const Costeo_Produccion_Envase_Cierre As String = "PPA_Costeo_ProductoxSuministro_Cierre"
        Public Const Costeo_Produccion_Resumen_Delete As String = "PPA_Prod_CosteoProducion_Producto_DELETE"
        Public Const Costeo_Produccion_Resumen As String = "PPA_Prod_CosteoProducion_Producto"
        Public Const Costeo_Produccion_Resumen_Molino As String = "PPA_Prod_CosteoProducion_Molino"
        Public Const Costeo_Produccion_Cierre As String = "PPA_Consulta_CosteoProduccion_Cierre"
        Public Const Validar_Costeo_Produccion_Cierre As String = "PPA_Validar_CosteoProduccion_Cierre"
        Public Const Costeo_Produccion_SinProd_Cierre As String = "PPA_Prod_CosteoProducion_Producto_MesSinProd"
        Public Const Costeo_Produccion_Contable_Cierre As String = "PPA_Costeo_ProductoxUnidad_Contable_Cierre"
        Public Const Linea_Produccion As String = "PPA_Prod_LineaProduccion"
        Public Const ProcesoProductivo As String = "PPA_Prod_ProcesoProductivo"
        Public Const Linea_Produccion_Productos As String = "PPA_Prod_LineaProduccionProducto"
        Public Const Linea_Produccion_ProcesoProductivo As String = "PPA_Prod_LineaProduccionProcesoProductivo"
        Public Const Periodo As String = "PPA_Prod_Periodo"
        Public Const Personal_LineaProduccion As String = "PPA_Prod_Personal_LineaProduccion"
        Public Const Periodo_GasNatural As String = "PPA_Prod_Periodo_GasNatural"
        Public Const Periodo_GasNatural_LinProd As String = "PPA_Prod_Periodo_GasNat_LinProd"
        Public Const Periodo_PlantaCemento_UnidadProduccion As String = "PPA_Prod_Periodo_Planta_Cemento_UnidadProd"
        Public Const Periodo_PlantaCemento_Mineral As String = "PPA_Prod_Periodo_Planta_Cemento_Mineral"
        Public Const Periodo_PlantaCemento_Suministro As String = "PPA_Prod_Periodo_Planta_Cemento_Suministro"
        Public Const Periodo_PlantaCemento_ManoObra As String = "PPA_Prod_Periodo_Planta_Cemento_ManoObra"
        Public Const Periodo_PlantaCemento_Otros As String = "PPA_Prod_Periodo_Planta_Cemento_Otros"
        Public Const Periodo_Activos As String = "PPA_Prod_Periodo_Activos"
        Public Const Periodo_Activos_Facturacion As String = "PPA_Prod_Periodo_Activos_Facturacion"
        Public Const Periodo_Operador As String = "PPA_Prod_Periodo_CosteoProducto_Operador"
        Public Const Periodo_ComprobantePago As String = "PPA_Periodo_Facturacion_Operador_Documento"
        Public Const Periodo_ComprobantePago_Mes As String = "PPA_Prod_Periodo_Facturacion_Mes"
        Public Const ValidarProforma As String = "PPA_ValidarProforma"
        'add jcms 290613
        Public Const ReporteCronogramaPdcCriterios As String = "usp_alm_listar_plantas_internas"
    End Structure
    Public Structure GPA_ERP_COMACSA
        Event z()
        Public Const Area As String = "MPA_Area"
        Public Const Glosa As String = "UPA_TblFormularioGlosa"
        Public Const Sistema As String = "UPA_TblSystem"
        Public Const EnlaceGrupoSistema As String = "UPA_TblEnlaceSystemGroup"
    End Structure
    Public Structure RPA_RecursosHumanos
        Event z()
        Public Const Area_Empleado As String = "RPA_AreaEmpleado"
        Public Const Planillas_AreaJefatura As String = "RPA_RRHH_AreaJefatura"
        Public Const CtaCorrientePersonal As String = "RPA_CtaCtePersonal"
    End Structure

    Public Structure usp_RAL
        Event z()
        Public Const UPD_DocumentosTecnicos As String = "usp_RAL_Actualizar_DocumentosTecnicos"
        Public Const UPD_UnidadDespacho As String = "usp_RAL_ActualizarUnidadDespacho"
        Public Const ADD_FirmaUsers As String = "usp_RAL_AgregarMostrarFirmaUsers"
        Public Const SEL_SaldoInicial As String = "USP_RAL_ALM_SALDOINCIAL_KARDEX"
        Public Const Almacen As String = "usp_RAL_Almacen"
        Public Const Almacen_Serie As String = "usp_RAL_AlmacenSerie"
        Public Const Anexo_Requerimiento As String = "usp_RAL_AnexoRequerimiento"
        Public Const UPD_AnularMovimiento As String = "usp_RAL_AnularMovimientosAlmacen"
        Public Const AplicacionEmpleo As String = "usp_Ral_AplicacionAreaEmpleo"
        Public Const Aprobacion_Requerimiento As String = "usp_RAL_AprobacionRequerimiento"
        Public Const Cab_IngresoOC As String = "usp_RAL_CabPedido_IngresoOC"
        Public Const Cab_Pedido As String = "usp_RAL_CabRequisicionAlmacen"
        Public Const ConsultarOpcionesUsuario As String = "usp_RAL_ConsultarOpcionesUsuario"
        Public Const ConsultarMenuUsuario As String = "usp_RAL_ConsultarMenuUsuario"
        Public Const ConsultarConexion As String = "PPA_ConsultarConexion"
        Public Const ConversionUnidadesProductos As String = "usp_RAL_ConversionUnidadesProductos"
        Public Const ConsultarToolsMenuUsuario As String = "usp_RAL_ConsultarToolsMenuUsuario"
        Public Const ConsultarConversion2 As String = "usp_RAL_ConsultarConversion2"
        Public Const DocumentosIngresoTransferencia As String = "usp_RAL_Listar_DocumentosIngresoTransferencia"
        Public Const DisenoSispedal As String = "usp_RAL_DisenoSispedal"
        Public Const EmpleoLabor As String = "usp_RAL_EmpleoLabor"
        Public Const EmpleoLabor_Activo As String = "usp_RAL_Insertar_EmpleoLabor_Activo"
        Public Const EmpleoLabor_SoloLinea As String = "usp_RAL_Insertar_EmpleoLabor_SoloLinea"
        Public Const EmpleoLabor_Linea As String = "usp_RAL_Insertar_EmpleoLabor_Linea"
        Public Const EmpleoLabor_Cantera As String = "usp_RAL_Insertar_EmpleoLabor_Cantera"
        Public Const MantenimientoOpciones As String = "PPA_MantenimientoOpciones"
        Public Const Users As String = "usp_RAL_Users"
        'hv 12/02/2025
        Public Const Bancos As String = "usp_RAL_Bancos"

        Public Const TipoTarjetaConsumo As String = "usp_RAL_TipoTarjetaConsumo"
        Public Const EstadoTarjetaConsumo As String = "usp_RAL_EstadoTarjetaConsumo"
        Public Const MonedaTarjetaConsumo As String = "usp_RAL_MonedaTarjetaConsumo"

        'Public Const ListarProductosAlm As String = "Alm_Muestra_Productos_Almacen"
        Public Const ListarProductosAlm As String = "Alm_Muestra_Productos_Almacen_20240617"

        Public Const Listar_EmpleoLabor As String = "usp_RAL_Listar_EmpleoLabor"
        Public Const ListarCantera As String = "usp_RAL_ListarCantera"
        Public Const ListarContratista_Cantera As String = "usp_RAL_ListarContratista_Cantera"
        Public Const UsersAreaAprobacionRequerimiento As String = "usp_RAL_UsersAreaAprobacionRequerimiento"
        Public Const AgregarMostrarFirmaUsers As String = "usp_RAL_AgregarMostrarFirmaUsers"
        Public Const UsersAreaAprobacionOC As String = "usp_RAL_UsersAreaAprobacionOC"
        Public Const Cia As String = "usp_RAL_Cia"
        Public Const ProveedoresCia As String = "usp_RAL_ProveedoresCia"
        Public Const ValidarNombreCorto As String = "usp_RAL_ValidarNombreCorto"
        Public Const ListarAnexoOC_Item As String = "usp_RAL_ListarAnexoOC_Item"
        Public Const ProductosMayorMonto As String = "usp_RAL_ProductosMayorMonto"
        Public Const FirmaMonto As String = "usp_RAL_FirmaMonto"
        Public Const RangoAprobacion As String = "usp_RAL_RangoAprobacion"
        Public Const OrdenAprobacionMonto As String = "usp_RAL_OrdenAprobacionMonto"
        Public Const UpdateDetalleOC As String = "usp_RAL_UpdateDetalleOC"
        Public Const Crea_Stock = "SP_ALM_CREA_STOCK"
        Public Const Maestros_2 As String = "usp_RAL_Maestros_2"
        Public Const Productos As String = "usp_RAL_Productos"
        Public Const Grabar_Requerimiento01 As String = "usp_RAL_Grabar_Requerimiento01"
        Public Const Almacen_Requerimiento03 As String = "usp_RAL_REQUISICION03"
        Public Const Almacen_Requerimiento04 As String = "usp_RAL_REQUISICION04"
        Public Const NumeracionSuministros As String = "Sp_Numeracion_suministros"
        Public Const Det_Pedido As String = "usp_RAL_DetRequisicionAlmacen"
        Public Const MaestroDocumentos As String = "usp_RAL_MaestroDocumentos"
        Public Const NumeroMovimiento As String = "usp_RAL_GenerarNroDocAlm"
        Public Const AtenderPedido As String = "usp_RAL_CabRequisicionAtender"
        Public Const Grabar_CabGuia As String = "usp_RAL_Grabar_Cab_Guia"
        Public Const Grabar_DetGuia As String = "usp_RAL_Grabar_Det_Guia"
        Public Const ListarFlag As String = "usp_RAL_ListarFlag"
        Public Const NumeracionRequerimiento As String = "SP_LOGNUMERACIONREQ"
        Public Const Numeracion2 As String = "sp_Numeracion2"
        Public Const RequisicionFirma As String = "usp_RAL_RequisicionFirma"
        Public Const Detalle_Requerimiento As String = "usp_RAL_DetRequisicion02"
        Public Const UpdateSoloRequerimiento As String = "usp_RAL_UpdateSoloRequerimiento"
        Public Const UpdateEntregar As String = "usp_RAL_UpdateEntregar"
        Public Const UpdateEntregarRequerimiento As String = "usp_RAL_UpdateEntregarRequerimiento"
        Public Const UpdateListaRecojo As String = "usp_RAL_UpdateListaRecojo"
        Public Const ListarDocumentosTecnicos As String = "usp_RAL_ListarDocTec"
        Public Const OrdenCompra As String = "usp_RAL_OrdenCompra"
        Public Const UltimoSaldo = "SP_ALM_ULTIMOSALDO"
        Public Const DocumentosTecnicos As String = "usp_log_iu_requisicion02_producto_documentos_tecnicos"
        Public Const EliminarRequerimiento As String = "usp_RAL_EliminarRequerimiento"
        Public Const Acumulado As String = "SP_LOGCON_ACUMDESPXMOVXAÑO"
        Public Const UltimaCompra As String = "SP_LOGCONREQ_ULTIMACPAPROV"
        Public Const UltimoDespacho As String = "SP_LOGCON_FECHAULTIMODESPACHO"
        Public Const AcumuladoMovimiento As String = "SP_LOGCON_ACUMDESPXMOV"
        Public Const AcumuladoFecha As String = "SP_LOGCON_ACUMDESPXMOVXRANGOFECHAS"
        Public Const DiasDemora As String = "SP_LOGCON_DIASDEMORAPROV"
        Public Const ValidarMaestroProductos As String = "usp_RAL_ValidarMaestroProductos"
        Public Const ListarProductos As String = "usp_RAL_ListarProductos"
        Public Const CargarBilletes As String = "USP_CARGA_BILLETES"
        Public Const CargarLetras As String = "USP_LISTARLETRA_TRANSPORTISTA"

        Public Const CargarAutorizacionIQBF As String = "USP_LISTA_AUTORIZA_IQBF"
        Public Const ConstanciaError As String = "USP_LISTA_ERRORCONSTANCIA"
        Public Const ConstanciaBillete As String = "USP_CONSTANCIAPESO_BILLETE"
        Public Const DescripcionError As String = "USP_DESCRIPCIONERROR"
        Public Const CargarLetraID As String = "USP_LETRA_ID"
        Public Const ValidacionLetras As String = "USP_VALIDACIONLETRA"
        Public Const CargarExoneracion As String = "USP_LISTAR_EXONERACIONLETRA"

        Public Const ListaPedidosSuministro As String = "USP_LISTAR_PEDIDOSUMINISTRO"
        Public Const ListaPedidosSuministro_v2 As String = "USP_LISTAR_PEDIDOSUMINISTRO_v2"
        Public Const ListaPedidosSuministro_v3 As String = "USP_LISTAR_PEDIDOSUMINISTRO_v3"

        Public Const ClonarUsuario As String = "USP_ERP_CLONA_USUARIO"
        Public Const AreaUsuario As String = "USP_ERP_AREA_USUARIO"

        Public Const ListaPedidoAtendido As String = "USP_LISTAR_PEDIDOATENDIDO"
        Public Const ListaPedidoAtendido_Hist As String = "USP_LISTAR_PEDIDOATENDIDO_HIST"
        Public Const ListaPedidoAtendidoCadena As String = "USP_LISTAR_PEDIDOATENDIDO_CADENA"
        Public Const ListaPedidoAtendidoCorreo As String = "USP_PEDIDO_APROBADO_CORREO"
        Public Const ApruebaPedidoAtendido As String = "USP_PEDIDO_ATENDIDO_APROBADO"

        Public Const DiferenciaInventario As String = "Lg_Diferencia_Inventario"

        Public Const ListaConInvFiltro As String = "USP_ERP_CINV_FILTROS"
        Public Const ListaConInvData As String = "usp_alm_min_kardex_minerales_tabladinamica"
        Public Const ListaConInvDataHist As String = "usp_alm_min_kardex_minerales_tabladinamica_hist"
        Public Const ConInvSaldoInicial As String = "USP_ERP_SALDOS_INICIALES"
        Public Const ConInvConfMeses As String = "USP_ERP_CINV_CONFIG_ROTACION"
        Public Const ListaConfigMes As String = "USP_CINV_LISTA_CONFIG_ROTACION"
        Public Const MantConfigMes As String = "USP_CINV_MANT_CONFIG_ROTACION"
        Public Const ListaConfigRuma As String = "USP_LISTA_CONFIG_RUMA"
        Public Const MantConfigRuma As String = "USP_MANT_CONFIG_RUMA"

        Public Const ListaComentarioControl As String = "TBL_ERP_LISTA_COMENTARIO_CONTROL_RUMA"
        Public Const MantComentarioControl As String = "USP_ERP_COMENTARIO_CONTROL_RUMA"

        Public Const userapruebaSuministro As String = "USP_USER_APRUEBA_PEDIDOSUM"

        Public Const ListaPedidosSuministroID As String = "USP_LISTAR_PEDIDOSUMINISTRO_ID"

        Public Const ListarFormulacionProyectada As String = "USP_LISTAR_FORMULACIONPROYECTADA"
        Public Const UpdatePedidoIngresoOC As String = "usp_RAL_UpdatePedidoIngresoOC"
        Public Const UpdateAnexo_IngresoOC As String = "usp_RAL_UpdateAnexo_IngresoOC"
        Public Const Update_SalidaDevolucion_OC As String = "usp_RAL_UpdateOrden02_SalidaDevolucion"
        Public Const SalidaDevolucion As String = "usp_RAL_SalidaDevolucion"
        Public Const SalidaTransferencia As String = "usp_RAL_SalidaTransferencia"
        Public Const IngresoOrdenCompra As String = "usp_RAL_IngresoOrdenCompra"
        Public Const TipoCambio As String = "usp_RAL_TipoCambio"
        Public Const IngresoAjuste As String = "usp_RAL_IngresoAjuste"
        Public Const IngresoTransferencia As String = "usp_RAL_IngresoTransferencia"
        Public Const SalidaRemarcado As String = "usp_RAL_SalidaRemarcado"
        Public Const Eliminacion_Total As String = "usp_RAL_Eliminacion_Total"
        Public Const DetalleIngresoOC As String = "usp_RAL_ListarDetalleIngresoOC"
        Public Const DetalleIngresoAjuste As String = "usp_RAL_ListarDetalleIngresoAjuste"
        Public Const DetalleIngresoRemarcado As String = "usp_RAL_ListarDetalleIngresoRemarcado"
        Public Const DetalleIngresoSinOC As String = "usp_RAL_ListarDetalleIngresoSinOC"
        Public Const DetalleSalidaTransferencia As String = "usp_RAL_ListarDetalleSalidaTransferencia"
        Public Const ListarSalidaTransferenciaCantera As String = "usp_RAL_ListarSalidaTransferenciaCantera"
        Public Const DetalleSalidaRemarcado As String = "usp_RAL_ListarDetalleSalidaRemarcado"
        Public Const Pendientes_Envio_Cantera As String = "usp_alm_consulta_billetes_pendientes_envio_canteras"
        Public Const DatosContratista As String = "usp_RAL_ListarDatosContratista"
        Public Const DetalleSalidaDevolucion As String = "usp_RAL_ListarDetalleSalidaDevolucion"
        Public Const Verificar_Devolucion As String = "usp_alm_verificar_devolucion"
        Public Const ConvertirNumeroIngreso As String = "usp_RAL_ConvertirNumeroIngreso"
        Public Const PedidoPendiente As String = "usp_RAL_CabRequisicionPendiente"
        Public Const PedidoAutorizado As String = "usp_RAL_CabRequisicionAutorizada"
        Public Const PedidoAtender As String = "usp_RAL_CabRequisicionAtender"
        Public Const PedidoEntregar As String = "usp_RAL_CabRequisicionEntregar"
        Public Const DistribuirPedido As String = "usp_RAL_Distribuir_Requerimiento"
        Public Const OC_Aprobacion As String = "usp_RAL_OC_Aprobacion"
        Public Const OC_Aprobacion_Usuario As String = "usp_RAL_OC_Aprobacion_Usuario"
        Public Const Detalle_OC As String = "usp_RAL_DETALLE_OC"
        Public Const MejorPrecio As String = "usp_RAL_MejorPrecio_PorRangoFecha_OC"
        Public Const OrdenCotizacionLogistica As String = "usp_RALL_OrdenCotizacionLogistica"
        Public Const DocumentosReferencia As String = "usp_RAL_DocumentosReferencia"
        Public Const ListarLinea As String = "usp_RAL_ListarLinea"
        Public Const Rpt_FormulacionProyectado As String = "USP_RPT_FORMULACIONPROYECTADO"
        Public Const PROCESO_RPT_FORMULACION_PROYECTADO As String = "USP_PROCESO_RPT_FORMULACION_PROYECTADO"
        Public Const ListarSubLinea As String = "usp_RAL_ListarSubLinea"
        Public Const OCPendientesIngreso As String = "usp_RAL_OrdenCompraPendientesIngreso"
        Public Const OCIngresoAlmacen As String = "usp_RAL_OrdenCompraIngresoAlmacen"
        Public Const MovimientosAlmacen As String = "usp_RAL_MovimientosAlmacen"
        Public Const MovimientosAlmacen_NC As String = "usp_almacen_no_conforme"
        Public Const Area_Usuario As String = "SP_Descrip_Maestros2_logistica"
        Public Const DocIdentidad_Usuario As String = "SP_Descrip_Maestros2_sunat"
        Public Const MotivosTrasladoSunat_Usuario As String = "usp_listar_TbSunat_MotivosDeTraslado"

        Public Const ListarAlmacen As String = "usp_almacen"
        Public Const ListarAlmacenSolicitante As String = "usp_almacen_solicitante_pedido_suministro"

        Public Const Carga_Empleo As String = "usp_lista_empleo"
        Public Const ListarArea As String = "usp_RAL_ListarArea"
        Public Const ListarDocumentosTecnicos1 As String = "usp_RAL_Listar_DocumentosTecnicos"
        Public Const ListarEmpleoLabor As String = "usp_RAL_ListarEmpleoLabor"
        Public Const ListarEstadoActual As String = "usp_RAL_ListarEstadoActual"
        Public Const ListarActivo As String = "usp_RAL_ListarActivo"
        Public Const ListarDescripcionActivo As String = "usp_RAL_ListarDescripcionActivo"
        Public Const Transp_Guia_Almacen As String = "usp_alm_iu_transp_guia_almacen"
        Public Const MantenimientoFormularios As String = "usp_RAL_Mantenimiento_Formularios"
        Public Const OpcionesERP As String = "usp_RAL_Opciones_ERP"
        Public Const MantenimientoERP As String = "usp_RAL_Mantenimiento_ERP"
        Public Const Consulta_Pedido As String = "usp_RAL_Consulta_Pedido"
        Public Const Doc_Pedido As String = "usp_RAL_Doc_Pedido"
        Public Const VERIFICA_CIERREALMACEN As String = "USP_VERIFICA_CIERREALMACEN"
        Public Const verificaperiodoProvision As String = "usp_verifica_periodoprovision"

        Public Const MantenimientoProyecto As String = "USP_ERP_PROYECTO"
        Public Const MantenimientoProyectoTrabajador As String = "USP_ERP_PROYECTO_TRABAJADOR"
        Public Const MantenimientoProyectoEquipo As String = "USP_ERP_PROYECTO_EQUIPO"

        Public Const ReplicaProyectoTrabajador As String = "USP_ERP_REPLICA_PROYECTO_TRABAJADOR"
        Public Const ReplicaProyectoEquipo As String = "USP_ERP_REPLICA_PROYECTO_EQUIPO"

        Public Const ListarProyecto As String = "USP_LISTA_PROYECTO"
        Public Const ListarProyectoTrabajador As String = "USP_ERP_LISTA_PROYECTO_TRABAJADOR"
        Public Const ListarProyectoEquipo As String = "USP_ERP_LISTA_PROYECTO_EQUIPO"

        ' Public Const CosteoMineral As String = "usp_RAL_CosteoMineral_Datos"
        Public Const CosteoMineral_Variacion_Guardar As String = "usp_RAL_Costeo_Mineral_Variacion_Guardar"
        Public Const CosteoMineral As String = "usp_Cantera_CosteoMinerales"
        'MOD 10052014
        'Public Const CosteoMineral_Mineral As String = "usp_Cantera_Mineral_CosteoMinerales"
        'Public Const CosteoMineral_Mineral As String = "usp_Cantera_Mineral_CosteoMinerales_V1"
        Public Const CosteoMineral_Mineral_2016 As String = "usp_Cantera_Mineral_CosteoMinerales_V1_2016"

        Public Const ListarCategoriaTrabajador As String = "Usp_TrabajadorCategoria"
        Public Const ListarCategoriaTrabajadorMant As String = "Usp_TrabajadorCategoria_Mant"

        '-------------
        Public Const CosteoMineral_xCantera As String = "usp_RAL_Costeo_Mineral_CanteraxMineral_Anual"
        Public Const CosteoMineral_xCantera_xRangos As String = "usp_RAL_Costeo_Mineral_CanteraxPeriodo_Anual"
        Public Const CosteoMineral_xTipoConcepto_xRangos As String = "usp_RAL_Costeo_Mineral_TipoConceptoxPeriodo_Anual"
        Public Const CosteoMineral_Listar As String = "usp_RAL_Costeo_Mineral_Consultar"
        Public Const CosteoMineral_VentasMensual As String = "usp_RAL_VentasMensualSoles"
        Public Const CosteoMineral_Comparacion As String = "usp_Cantera_Mineral_CosteoMinerales_Comparacion"

        Public Const CosteoMineral_Minas As String = "USP_ERP_MINAS_COSTEO"

        Public Const CosteoMineral_ValidarBilleteSinCantera As String = "usp_RAL_CosteoMineral_ValidadBilleteSinCantera"
        'Public Const DetalleCosteoMineral As String = "usp_RAL_Detalle_CosteoMineral"
        Public Const DetalleCosteoMineral_2016 As String = "usp_RAL_Detalle_CosteoMineral_2016"
        'Public Const DetalleCosteoMineral_NoContable As String = "usp_RAL_Detalle_CosteoMineral_NoContable"
        Public Const DetalleCosteoMineral_NoContable_2016 As String = "usp_RAL_Detalle_CosteoMineral_NoContable_2016"
        Public Const DetalleCosteoMineral_Comparacion As String = "usp_RAL_Detalle_CosteoMineral_Comparacion"
        Public Const CombustibleExplosivo As String = "usp_RAL_Combustible_Explosivo"
        Public Const MantPrecioCombustibleExplosivo As String = "USP_ERP_MANTENIMIENTO_PRECIOCOMBUSTIBLE"
        Public Const PrecioCombustibleExplosivo As String = "USP_LISTADO_PRECIOCOMBUSTIBLE"
        Public Const Ubigeo As String = "usp_RAL_Ubigeo"
        Public Const CanteraViaje As String = "usp_RAL_CanteraViaje"
        Public Const CanteraViajeDetalle As String = "usp_RAL_CanteraViajeDetalle"
        Public Const CanteraEquipo As String = "usp_RAL_Cantera_Equipo"
        Public Const DescripcionCantera As String = "usp_RAL_DescripcionCantera"
        Public Const OrigenCantera As String = "usp_RAL_TipoCantera"
        Public Const ConsultarTipoEquipo As String = "usp_RAL_ConsultarTipoEquipo"
        Public Const MANTENIMIENTOAGRUPACION As String = "USP_ERP_MANTENIMIENTOAGRUPACION"
        Public Const MANTENIMIENTOAGRUPACIONRUMA As String = "USP_ERP_MANTENIMIENTOAGRUPACIONRUMA"
        Public Const CanteraVigencia As String = "usp_RAL_Vigencia_Cantera"
        Public Const VidaUtil As String = "usp_RAl_Suministros_Ttl"
        Public Const CanteraVidaUtil As String = "usp_RAL_Cantera_VidaUtil_Producto"
        Public Const HoraMaquina As String = "usp_RAL_Cantera_HoraMaquina"
        Public Const HoraDisponibleMaquina As String = "usp_RAL_Cantera_Hora_Disponible_Maquina"
        Public Const DerechoCesion As String = "usp_RAL_Cantera_DerechoCesion"
        Public Const CanteraDonaciones As String = "usp_RAL_Cantera_Donaciones"
        Public Const ListaPrecio As String = "usp_RAL_Cantera_ListaPrecio"
        Public Const CanteraContratista As String = "usp_RAL_Cantera_Contratista"
        Public Const CanteraContratista_Billete As String = "USP_RAL_Cantera_Contratista_Billete"
        Public Const CanteraContratista_Billete_Castigo As String = "USP_RAL_Cantera_Contratista_Billete_Castigo"
        Public Const CanteraContratista_Personal As String = "usp_RAL_Cantera_Contratista_Personal"
        Public Const CanteraContratista_Personal_Faltas As String = "usp_RAL_Cantera_Contratista_Personal_Faltas"
        Public Const CanteraContratista_Personal_Guia As String = "usp_RAL_Cantera_Contratista_Personal_Guia"
        Public Const Consultar_CanteraContratista_Billete As String = "usp_RAL_ConsultarBillete_CanteraContratista"
        Public Const Consultar_CanteraContratista_Billete_Castigo As String = "usp_RAL_ConsultarBillete_CanteraContratista_Castigo"
        Public Const Consultar_CanteraContratista_Personal As String = "usp_RAL_ConsultarPersonal_CanteraContratista"
        Public Const Generar_CanteraContratista_Esquema1 As String = "USP_RAL_GenerarReportePlanillaContratista_Esquema1"
        Public Const Consultar_CanteraContratista_Personal_Faltas As String = "usp_RAL_Consultar_Falta_CanteraContratista"
        Public Const Consultar_CanteraContratista_Personal_Guia As String = "usp_RAL_Consultar_CanteraContratista_Guia_Personal"
        Public Const ListaPrecioFlete As String = "usp_RAL_Cantera_ListaPrecioFlete"
        Public Const CanteraContratista_ListaPrecioMineral As String = "usp_RAL_Cantera_ListaPrecioMineralContratista"
        Public Const ListaPrecioFletexMineral As String = "usp_RAL_Cantera_ListaPrecioFletexMineral"
        Public Const DepreciacionEquipo As String = "usp_RAL_Cantera_Depreciacion"
        Public Const CostoAutorizacion As String = "usp_RAL_Cantera_CostoAutorizacion"
        Public Const CtaCteContratista As String = "usp_RAL_CtaCteContratista"
        Public Const LISTAAGRUPACION As String = "USP_ERP_LISTAAGRUPACION"
        'REPORTES
        Public Const AtencionProductos As String = "usp_RAL_Atencion_Productos"
        Public Const SalidaOrden As String = "usp_RAL_AtencionProductos"
        Public Const ImprimirRequerimiento As String = "SP_IMPRIMIR_REQUERIMIENTO"
        Public Const EnvioCantera_VidaUtil As String = "usp_RAL_Reporte_EnvioCantera_VidaUtil"
        Public Const ReporteConsumoSuministro As String = "usp_RAL_Reporte_ConsumoSuministros"
        Public Const Reporte01 As String = "usp_RAL_ConsultarTareoEquipo"
        Public Const CE_Reporte01 As String = "usp_CE_ConsultarTareoEquipo"
        Public Const Reporte02 As String = "usp_RAL_ConsultarTareoCombustible"
        Public Const CE_Reporte02 As String = "usp_CE_ConsultarTareoCombustible"
        Public Const Reporte03 As String = "USP_RAL_COSTEO_MINERAL_DETALLE"
        Public Const Reporte04 As String = "usp_RAL_ConsultarExplosivos"
        Public Const CE_Reporte04 As String = "usp_CE_ConsultarExplosivos"
        Public Const RptSolicitud As String = "USP_RptSolicitud"
        Public Const RptSolicitudPlanilla As String = "USP_RptSolicitudPlanilla"
        Public Const RptAnticipo As String = "USP_RptAnticipo"
        Public Const RptLiquidacion As String = "USP_Liquidacion"
        Public Const RptLiquidacionDet As String = "USP_Liquidacion_Resumen"
        Public Const RptRegCompras As String = "USP_RPT_REG_COMPRAS"
        Public Const RptFactCombustible As String = "USP_CE_RPT_FACT_COMBUSTIBLE"
        Public Const RptCancelaAnt As String = "USP_CTR_RPT_ASIENTO_ANT"

        Public Const RptProductoNC As String = "USP_RPT_PRODUCTO_NC"

        Public Const RptPedidoSuministro As String = "USP_RPT_PEDIDOSUMINISTRO_ID"

        Public Const RptRegCompras_Prov As String = "USP_RPT_REG_COMPRAS_PROV"
        Public Const RptLiquidacionReintegro As String = "USP_LiquidacionReintegro"
        Public Const RptLiquidacionPend As String = "USP_LiquidacionPend"
        Public Const RptLiquidacionCopia As String = "USP_LiquidacionCopia"
        Public Const RptLiquidacionPendCopia As String = "USP_LiquidacionPendCopia"
        Public Const RptAsientoContable As String = "USP_AsientoEntregas"
        Public Const RptAsientoProvision As String = "USP_AsientoProvision"
        Public Const RptAsientoContablePend As String = "USP_AsientoEntregas"
    End Structure

    '********************************
    '   SiMan
    Public Structure MPA_Mantenimiento
        Event Z()
        Public Const Mantenimiento_LinNeg As String = "MPA_Mantto_LineaNegocio"
        Public Const Mantenimiento_ConsultarUniMed As String = "MPA_ConsultarUnidadMedida"
        Public Const Mantenimiento_Atributo As String = "MPA_Mantto_Atributo"
        Public Const Mantenimiento_ParteEquipo As String = "MPA_Mantto_ParteEquipo"
        Public Const Mantenimiento_AtributoParteEquipo As String = "MPA_Mantto_ParteEqAtributo"
        Public Const Mantenimiento_FamiliaEquipo As String = "MPA_Mantto_FamiliaEquipo"
        Public Const Mantenimiento_AtributoFamiliaEquipo As String = "MPA_Mantto_FamiliaEqAtributo"
        Public Const Mantenimiento_ComponenteFamiliaEquipo As String = "MPA_Mantto_FamiliaEqParteEq"
        Public Const Mantenimiento_Equipo_CargarDatosNew As String = "MPA_Equipo_CargarNuevo"
        Public Const Mantenimiento_Equipo As String = "MPA_Mantto_Equipo"
        Public Const Mantenimiento_EquipoAtributo As String = "MPA_Mantto_EquipoAtributo"
        Public Const Mantenimiento_Equipo_ParteEq As String = "MPA_Mantto_EquipoPartEq"
        Public Const Mantenimiento_Equipo_ParteEq_Atrib_Valor As String = "MPA_Mantto_EquipoComponenteValor"
        Public Const Mantenimiento_CheckList As String = "MPA_Mantto_CheckList"
        Public Const Mantenimiento_CheckList_Detalle As String = "MPA_Mantto_DetalleCheckList"
        Public Const Mantenimiento_Area As String = "MPA_Area"
        Public Const Mantenimiento_Requerimiento_Mantto As String = "MPA_Mantto_Requerimiento"
        Public Const Mantenimiento_ReqDetalle_Mantto As String = "MPA_Mantto_DetalleRequerimiento"
        Public Const Mantenimiento_Programacion As String = "MPA_Mantto_Programacion"
        Public Const Mantenimiento_Partida As String = "MPA_Mantto_Partida"
        Public Const Mantenimiento_Partida_Recursos As String = "MPA_Recursos_Partida"
        Public Const Mantenimiento_Partida_Material As String = "MPA_Mantto_PartidaMaterial"
        Public Const Mantenimiento_Partida_Equipo As String = "MPA_Mantto_PartidaEquipo"
        Public Const Mantenimiento_Partida_ManoObra As String = "MPA_Mantto_PartidaManoObra"
        Public Const Mantenimiento_Partida_Servicio As String = "MPA_Mantto_PartidaServicio"
        Public Const Mantenimiento_Presupuesto As String = "MPA_Mantto_Presupuesto"
        Public Const Mantenimiento_PresupuestoDetalle As String = "MPA_Mantto_DetallePresupuesto"
        Public Const Mantenimiento_Presupuesto_Material As String = "MPA_Mantto_PresupuestoMaterial"
        Public Const Mantenimiento_Presupuesto_Equipo As String = "MPA_Mantto_PresupuestoEquipo"
        Public Const Mantenimiento_Presupuesto_ManoObra As String = "MPA_Mantto_PresupuestoManoObra"
        Public Const Mantenimiento_Presupuesto_Servicio As String = "MPA_Mantto_PresupuestoServicio"
        Public Const Mantenimiento_Presupuesto_Plan As String = "MPA_Mantto_PresupuestoPlanificacion"
        Public Const Mantenimiento_Presupuesto_Plan_Material As String = "MPA_Mantto_PresupPlanMaterial"
        Public Const Mantenimiento_Presupuesto_Plan_Equipo As String = "MPA_Mantto_PresupPlanEquipo"
        Public Const Mantenimiento_Presupuesto_Plan_ManoObra As String = "MPA_Mantto_PresupPlanManoObra"
        Public Const Mantenimiento_Presupuesto_Plan_Servicio As String = "MPA_Mantto_PresupPlanServicio"
        Public Const Mantenimiento_Cliente As String = "MPA_Clientes"
        Public Const Mantenimiento_Presupuesto_Plan_Equipo_Asignacion As String = "MPA_Mantto_PresupPlanEq_Asignacion"
        Public Const Mantenimiento_Presupuesto_Plan_ManoObra_Asignacion As String = "MPA_Mantto_PresupPlanMOAsignacion"
        Public Const Mantenimiento_OrdenTrabajo As String = "MPA_Mantto_OrdenTrabajo"
        Public Const Mantenimiento_OrdenTrabajo_Material As String = "MPA_Mantto_OTMaterial"
        Public Const Mantenimiento_OrdenTrabajo_Equipo As String = "MPA_Mantto_OTEquipo"
        Public Const Mantenimiento_OrdenTrabajo_ManoObra As String = "MPA_Mantto_OTManoObra"
        Public Const Mantenimiento_OrdenTrabajo_Servicio As String = "MPA_Mantto_OTServicio"
        Public Const Mantenimiento_OrdenTrabajo_Costos_Detalle As String = "MPA_Mantto_OrdenTrabajo_Recurso_Detalle"
        Public Const Mantenimiento_TareosOS_Personal As String = "MPA_Mantto_TareoOS_Personal"
        Public Const Mantenimiento_TareosOS_Equipo As String = "MPA_Mantto_TareoOS_Equipo"
        Public Const Mantenimiento_OrdenTrabajo_Recurso_SinPrecio As String = "MPA_Mantto_OrdenTrabajo_Recurso_SinPrecio"
        Public Const Mantenimiento_Costeo_ManttoMecanico As String = "MPA_Mantto_CosteoManttoMecanico"
        Public Const Mantenimiento_Costeo_ManttoMecanicoDetalle As String = "MPA_Mantto_CosteoManttoMecanicoDetalle"
        Public Const Maestro_2 As String = "usp_Maestros2"
        Public Const Maestro_3 As String = "usp_Maestros3"
        Public Const RH_OBTENER_TIPO_INGRESO As String = "RH_OBTENER_TIPO_INGRESO"
        REM Reportes
        Public Const Mantenimiento_Reporte_Presupuesto_vs_OT As String = "MPA_Mantto_Reporte_Presupuesto_vs_OrdenTrabajo"
    End Structure

    Public Structure SP_ADMINISTRACION
        Event z()

        Public Const ListarSolicitudesPlanilla As String = "Pla_Listar_solicitudes"

        Public Const Listar_Solicitudes As String = "USP_Listar_Solicitudes"

        Public Const Listar_Solicitudes25 As String = "USP_Listar_Solicitudes25"

        Public Const Listar_SolicitudesAnticipo As String = "USP_Listar_SolicitudAnticipo"
        Public Const Listar_SolicitudesCero As String = "USP_Listar_SolicitudesCero"
        Public Const Listar_TrabajadorCod As String = "USP_ListarTrabajadorxCodigo"
        Public Const Listar_Areas As String = "USP_listarArea"
        Public Const Listar_ConceptosSolicitudes As String = "Pla_listarConceptoSolicitudes"
        Public Const ConsultarPermisos As String = "USP_Verificar_Permisos_Botones"
        Public Const Listar_Canteras As String = "USP_ListarCanteras"
        Public Const ListarProductos As String = "USP_ListarProductos"
        Public Const ListarProductosVTA As String = "USP_ListarProductosVentas"

        Public Const ListarRumas As String = "USP_ListarRumas"
        Public Const ListarRumasSeteo As String = "USP_ListarRumasSeteo"

        '------------------------------------

        'Hvilela 23/03/2025 / Informacion sobre el limite de tarjeta de consumo 
        Public Const LimiteLineaCredito25 As String = "USP_LimiteLineaTarjetaConsumo25"

        '------------------------------------

        Public Const MantenimientoSolicitud As String = "USP_InsertaSolicituCab"

        ' se mantiene el sp anterior en caso de versiones anteriores
        '------------------------------------
        'Nuevo SP para Grabar las solicitudes
        'se incluye el tema de la Tarjetas de Consumo
        Public Const MantenimientoSolicitud25 As String = "USP_InsertaSolicitudCab25"
        '------------------------------------

        Public Const MantenimientoAnticipo As String = "USP_CTR_INSERTASOLICITUD"
        Public Const MantenimientoSolicitudCero As String = "USP_ERP_SOLICITUDCERO"

        '------------------------------------
        Public Const MantenimientoSolicitudDeta As String = "USP_InsertaSolicitudDet"
        Public Const MantenimientoAnticipoDeta As String = "USP_CTR_INSERTASOLICITUDDET"
        Public Const InsertaMineralAnticipo As String = "USP_INSERTA_MINERAL_ANTICIPO"
        Public Const InsertaPlanillaAnticipo As String = "USP_INSERTA_PLANILLA_ANTICIPO"
        Public Const InsertaObligacionAnticipo As String = "USP_INSERTA_OBLIGACION_ANTICIPO"
        Public Const InsertaVacacionesAnticipo As String = "USP_INSERTA_VACACIONESLIQUIDACIONES_ANTICIPO"
        Public Const InsertaLiquidacionTrabajador As String = "USP_INSERTA_LIQUIDACION_TRABAJADOR"
        Public Const InsertaSaldoUtilizado As String = "USP_INSERTA_SALDOIMPUESTO_UTILIZADO"
        Public Const InsertaImpuestoAnticipo As String = "USP_INSERTA_IMPUESTO_ANTICIPO"
        Public Const InsertaGratiCtsAnticipo As String = "USP_INSERTA_GRATICTS_ANTICIPO"

        Public Const Listar_SolicitudDetalle As String = "Pla_Solicitud_Detalle"
        Public Const Listar_SolicitudxNumero As String = "USP_SolicitudxNumero"

        Public Const Listar_SolicitudxNumeroTarjetaConsumo As String = "USP_SolicitudxNumeroTarjetaConsumo"

        ' se mantiene el sp anterior en caso de versiones anteriores
        '------------------------------------
        'Nuevo SP para Grabar las modificaciones de las solicitudes
        'se incluye el tema de la Tarjetas de Consumo
        Public Const Listar_SolicitudxNumero25 As String = "USP_SolicitudxNumero25"
        '------------------------------------

        Public Const SolicitudAnticipoxNumero As String = "USP_SolicitudAnticipoxNumero"
        Public Const Listar_UsuarioAprobacion As String = "USP_listarUsuarioAprobacion"
        Public Const CTR_UsuarioAprobacion As String = "USP_CTR_UsuarioAprobacion"
        Public Const Listar_Conceptos As String = "USP_ListarConceptos"
        Public Const Listar_ConceptosArea As String = "USP_ListarConceptosxArea"
        Public Const Listar_JefeArea As String = "USP_JefeArea"
        Public Const Listar_ProveedorxRuc As String = "USP_ProveedorxRuc"
        Public Const MantenimientoLiquidacion As String = "USP_InsertaLiquidacionDet"
        Public Const Listar_DetalleLiquidacion As String = "USP_ListarDetalleLiquidacion"
        Public Const Listar_Documentos As String = "USP_ListarDocumentos"
        Public Const Listar_Liquidaciones As String = "USP_Listar_Liquidaciones"
        Public Const Listar_Motivos As String = "USP_ListarMotivo"
        Public Const ListarTransportista As String = "SP_Transportistas"
        Public Const ConsultaEntregas As String = "USP_ConsultaEntregasRendir"
        Public Const ConsultaSaldos As String = "USP_ERP_SALDOMENSUAL"
        Public Const ConsultaSaldosAprobados As String = "USP_ERP_SALDOMENSUALAPROBADO"
        Public Const ConsultaEntregasDetalle As String = "USP_ConsultaEntregasRendirDetalle"
        Public Const Listar_UsuariosAprueba As String = "USP_listarUsuariosAprueba"
        Public Const Cargar_Usuarios As String = "USP_CargarUsuarios"
        Public Const CargarUsuariosAprueba As String = "USP_CargarUsuarios_APrueba"

        Public Const MantenimientoUsuarioAprobacion As String = "USP_InsertaUsuarioAprueba"
        ' Fltro de carga de persona
        Public Const Cargar_Personal As String = "USP_listadoTrabajador"
        Public Const Cargar_Personal_ID As String = "USP_listadoTrabajador_ID"
        ' Se crea otra SP con el filtro de Tarjeta de Consumo de carga de personal
        Public Const Cargar_Personal_TarjetaConsumo As String = "USP_ListadoTrabajadorTarjetaConsumo"

        Public Const listar_barbotina As String = "usp_erp_listarbarbotina"
        Public Const MantenimientoLiquidacionPend As String = "USP_InsertaLiquidacionPend"
        Public Const Listar_DetalleLiquidacionPend As String = "USP_ListarDetalleLiquidacionPend"
        Public Const Cargar_Reintegros As String = "USP_ListarReintegro"
        Public Const Listar_Monedas As String = "USP_ListarMonedas"

        Public Const ObtenerDataTrabajador As String = "pla_ObtenerInfoAreaTrabajador"
        Public Const CargarOtroConcepto As String = "USP_ListaOtrosconceptosEntrega"
        Public Const CargarTipoVehiculo As String = "USP_TipoVehiculo"
        Public Const VerificaPlaca As String = "USP_VERIFICA_PLACA"

        Public Const VerificaUserUnico As String = "USP_VALIDA_USER_UNICO"
        Public Const LimiteTramites As String = "USP_ERP_LIMITE_TRAMITES_VARIOS"

        Public Const CargarAlquilerVehiculo As String = "USP_LISTAR_ALQUILERVEHICULO"
        Public Const CargarAlquilerVehiculoPlaca As String = "USP_LISTAR_ALQUILERVEHICULO_PLACA"
        Public Const CargarTipoFacturacion As String = "USP_TipoFacturacion"
        Public Const Listar_Bancos As String = "USP_ListarBancos"
        Public Const Listar_BeneficiarioDni As String = "USP_BeneficiarioDni"
        Public Const Listar_Ctr_BeneficiarioDni As String = "USP_CTR_BeneficiarioDni"
        Public Const Listar_Lineacredito As String = "USP_ListarLiceacredito"
        Public Const ListarSuspension As String = "USP_LISTARSUSPENSION"
        Public Const ListarRetencionRH As String = "USP_LISTARRETENCIONRH"
        Public Const MantenimientoLineacredito As String = "USP_InsertaLineaCredito"
        Public Const Valida_Lineacredito As String = "USP_ValidaLiceacredito"
        Public Const Valida_Excesocredito As String = "USP_ExcesoLineacredito"

        Public Const Listar_LiquidacionesCerradas As String = "USP_Listar_LiquidacionesCerradas"
        Public Const RecepcionarSolicitud As String = "USP_RecepcionarLiquidacion"
        Public Const CodigoConcepto As String = "USP_CodigoConcepto"
        Public Const MantenimientoDescripciones As String = "USP_InsetaConcepto"
        Public Const Listar_DetalleLiquidacionCopia As String = "USP_ListarDetalleLiquidacionCopia"
        Public Const MantenimientoLiquidacionCopia As String = "USP_InsertaLiquidacionCopia"
        Public Const Listar_AreasCuenta As String = "USP_listarAreasCuentas"
        Public Const Listar_CuentaContable As String = "USP_ListarCuentaContable"
        Public Const MantenimientoSeteoContable As String = "USP_InsertarAmarreContable"
        Public Const Listar_AreasUsuario As String = "USP_listarAreaUsuario"
        Public Const Listar_TrabajadoresArea As String = "USP_TrabajadoresArea"
        Public Const MantenimientoTrabajadorArea As String = "USP_InsertarTrabajadorArea"
        Public Const Listar_AreaTrabajador As String = "USP_AreaTrabajador"
        Public Const RecepcionarSolicitudPend As String = "USP_RecepcionarLiquidacionPendiente"
        Public Const MantenimientoLiquidacionCopiaPend As String = "USP_InsertaLiquidacionCopiaPend"
        Public Const Listar_DetalleLiquidacionPendCopia As String = "USP_ListarDetalleLiquidacionPendCopia"
        Public Const MantenimientoDocAsociado As String = "USP_DocAsociadoLiqui"
        Public Const Listar_DocAsociadoLiqui As String = "USP_ListarDocAsociadoLiqui"
        Public Const MantenimientoDocAsociadoPend As String = "USP_DocAsociadoLiquiPend"
        Public Const Listar_DocAsociadoLiquiPend As String = "USP_ListarDocAsociadoLiquiPend"
        Public Const Listar_DocAsociadoLiquiCopia As String = "USP_ListarDocAsociadoLiquiCopia"
        Public Const Listar_DocAsociadoLiquiPendCopia As String = "USP_ListarDocAsociadoLiquiPendCopia"
        Public Const MantenimientoDocAsociadoCopia As String = "USP_DocAsociadoLiquiCopia"
        Public Const MantenimientoDocAsociadoPendCopia As String = "USP_DocAsociadoLiquiPendCopia"
        Public Const FlagAuxiliar As String = "USP_AuxiliarCuenta"
        Public Const Listar_Auxiliar As String = "USP_ListaAuxiliar"

        Public Const ListarAuxiliar3 As String = "USP_LISTAR_AUXILIAR3"

        Public Const MantenimientoDocMovilidad As String = "USP_MovilidadLiqui"
        Public Const MantenimientoDetalleRecibo As String = "USP_ERP_MANT_CONCEPTORH_LIQUIDACION"
        Public Const MantenimientoDetalleReciboCopia As String = "USP_ERP_MANT_CONCEPTORH_LIQUIDACIONCOPIA"
        Public Const Listar_DoMovilidad As String = "USP_ListarDocMovilidad"
        Public Const Listar_DoMovilidadCopia As String = "USP_ListarDocMovilidadCopia"
        Public Const MantenimientoDocMovilidadCopia As String = "USP_MovilidadLiquiCopia"
        Public Const Listar_CentroCosto As String = "USP_listarCentroCosto"
        Public Const Listar_CentroCostoPlaca As String = "erp_listarCentroCostoPlaca"
        Public Const Listar_SolicitudxNumeroLiquidacion As String = "USP_SolicitudxNumeroLiquidacion"
        Public Const VerificaCierreContable As String = "USP_VerificaCierreContable"
        Public Const VerificaDevolucion As String = "USP_VerificaDevolucion"
        Public Const verficaDocumentos As String = "USP_VerificaDocumentos"
        Public Const GeneraAsientoEntregas As String = "USP_GeneraAsientoEntregas"
        Public Const GeneraAsientoEntregasProvision As String = "USP_GeneraAsientoEntregasProvision"
        Public Const GeneraAsientoEntregasPend As String = "USP_GeneraAsientoEntregasPend"
        Public Const verificaReintegro As String = "USP_verificaReintegro"
        Public Const Acualiza_Cantera As String = "USP_Acualiza_Cantera"
        Public Const CONSULTA_ENTREGAS As String = "USP_CONSULTA_ENTREGAS"
        Public Const CORREO_SALDO_ENTREGAS As String = "USP_ERP_CORRE_SALDO_LIQUIDACION"
        Public Const ListarGatosVehiculos As String = "erp_gasto_vehiculo"
        Public Const ListarPlacasxCentro As String = "erp_gasto_PlacaXCencos"
        Public Const LISTARCONCEPTORH As String = "USP_CONCEPTORH"
        Public Const Listar_Combustible As String = "USP_ListarCombustible"
        Public Const MantenimientoDocCombustible As String = "USP_CombustibleLiqui"
        Public Const Listar_DocCombustible As String = "USP_ListarDocCombustible"
        Public Const Listar_DocDetalleRH As String = "USP_LISTAR_DETALLERH"
        Public Const Listar_DocDetalleRHCopia As String = "USP_LISTAR_DETALLERHCOPIA"
        Public Const Listar_DoCombustibleCopia As String = "USP_ListarDocCombustibleCopia"
        Public Const MantenimientoDocCombustibleCopia As String = "USP_CombustibleLiquiCopia"
        Public Const ConsultaCombustible As String = "USP_ConsultaCombustible"
        Public Const MantenimientoCombustible As String = "USP_MantnimientoCombustible"
        Public Const ACTUALIZA_COMBUSTIBLE As String = "USP_ACTUALIZA_COMBUSTIBLE"
        Public Const Listar_AreasIngreso As String = "USP_listarAreaIngreso"
        Public Const MantenimientoUsuarioIngreso As String = "USP_MantenimientoUsuarioIngreso"
        Public Const ListarSeteoCorreo As String = "USP_ListarSeteoCorreo"
        Public Const MantenimientoSeteocorreo As String = "USP_MantenimientoSeteocorreo"
        Public Const Listar_LiquidacionesRevision As String = "USP_Listar_LiquidacionesRevision"
        Public Const LimiteGastos As String = "USP_GASTOVIATICO"
        Public Const Listar_CanterasUEA As String = "USP_ERP_CANTERASUEA"
        Public Const MANTINGRESOMINERALSATAMIN As String = "USP_ERP_MANTINGRESOMINERALSATAMIN"
        Public Const VALIDARECIBOHONORARIO As String = "USP_ERP_VALIDARECIBOHONORARIO"

        Public Const VALIDARUSUARIOREVISION As String = "USP_USUARIO_REVISION_LIQUIDACION"

        Public Const VALIDADOCREPETIDO As String = "USP_VALIDADOCREPETIDO"

        Public Const VerAuxi3 As String = "USP_ERP_IDAUXI3_CONCEPTO"
        Public Const VerAuxi3Log As String = "USP_LISTAR_AUXILIAR3_LOG"

        Public Const Cantera_Maquina As String = "usp_cantera_equipo"

        Public Const Movilidad_Fecha As String = "USP_MOVILIDAD_FECHA"

        Public Const verifica_documento_compra As String = "USP_ERP_DOCUMENTO_COMPRA"
        Public Const registro_compra As String = "USP_ENT_REGISTRA_COMPRAS"
        Public Const registro_compra_Prov As String = "USP_ENT_REGISTRA_COMPRAS_PROV"
        Public Const lista_registro_compra As String = "USP_LISTA_REGISTRO_COMPRA"
        Public Const usuario_registro_compra As String = "USP_VERIFICA_USER_COMPRA"

        Public Const registra_retencion As String = "USP_REGISTRA_RETENCION"
        Public Const elimina_retencion As String = "USP_ELIMINA_RETENCION"

        Public Const elimina_registro_compra As String = "USP_ENT_ELIMINA_COMPRAS"
        Public Const VERIFICA_REINTEGROAPLICACION As String = "USP_VERIFICA_REINTEGROAPLICACION"
        Public Const COMBUSTIBLERESUMEN As String = "USP_ConsultaCombustibleResumen"
        Public Const ELIMINAPROVENTREGAS As String = "USP_ERP_ELIMINAPROVISIONENTREGA"
        Public Const VERIFICAPROVISION As String = "USP_ERP_VERIFICAPROVISION"

        Public Const usuarioRevision As String = "USP_ERP_USUARIO_REVISION_LIQUIDACION"

        Public Const LISTAPRODUCTOIQBF As String = "USP_LISTA_PROD_IQBF"

        Public Const CONCEPTORH As String = "USP_CONCEPTORH"
        Public Const InsertaCanteraAnticipo As String = "USP_INSERTA_CANTERA_ANTICIPO"
        Public Const MantenimientoOtraFactura As String = "USP_CTR_INSERTA_OTRAFACTURA"
        Public Const EliminaOtraFactura As String = "USP_CTR_ELIMINA_OTRAFACTURA"
        Public Const MantenimientoAlmacen As String = "USP_CE_INSERTA_ALMACEN"
        Public Const Mant_ActivoContratista As String = "USP_MANT_ACTIVOCONTRATISTA"
        Public Const MantenimientoTipoMovimiento As String = "USP_CE_MANT_TIPOMOVIMIENTO"
        Public Const Mant_MovimientoCombExplosivo As String = "USP_CE_MANT_MOVIMIENTO_CAB"
        Public Const Mant_MovimientoCombExplosivoDet As String = "USP_CE_MANT_MOVIMIENTO_DET"
        Public Const Carga_Movimiento As String = "USP_CE_CARGA_MOVIMIENTO"
        Public Const Elimina_Carga_Movimiento As String = "USP_CE_ELIMINACARGA"
        Public Const EliminaLiquidacion As String = "USP_ELIMINALIQUIDACION"
        Public Const ApruebaDocumento As String = "USP_ERP_APRUEBA_DOCUMENTO"
        Public Const MantenimientoAlquilerVehiculo As String = "USP_ERP_ALQUILER_VEHICULO"

        'consumo por centro de costo
        Public Const spListarConsumoCentroCosto As String = "USP_ERP_LISTAR_CONSUMO_CC"
        Public Const spListarTipoConsumoCentroCosto As String = "USP_ERP_TIPO_CONSUMO_CC"
        Public Const spCargarConsumoCentroCosto As String = "USP_ERP_OBTENER_CONSUMO_CC"
        Public Const spMantenimientoConsumoCentroCosto As String = "USP_ERP_MANTENIMIENTO_CONSUMO_CC"
        Public Const spListarCentroCosto As String = "USP_ERP_LISTAR_CENTRO_COSTO"
        Public Const ListarUbigeo As String = "USP_LISTAUBIGEO"
        Public Const MantTarifaUbigeo As String = "USP_TARIFA_FLETE_VR"
        Public Const ListarTarifaUbigeo As String = "USP_LISTA_TARIFA"

        'Asignacion Celulares
        Public Const spAsigCelular_ListarBolsas As String = "USP_ERP_ASIG_CELULAR_LISTAR_BOLSAS"
        Public Const spAsigCelular_Listar As String = "usp_empleado_tarifa_celular"
        Public Const spAsigCelular_Mantenimiento As String = "USP_ERP_ASIG_CELULAR_MANTENIMIENTO"
        Public Const spAsigCelular_MantenimientoBolsa As String = "USP_ERP_ASIG_CELULAR_BOLSA_MANTENIMIENTO"
        Public Const spAsigCelular_Obtener As String = "USP_ERP_ASIG_CELULAR_OBTENER"

        'Asignacion Tarjetas de Consumo
        Public Const spTarjetaConsumo_Listar As String = "usp_empleado_tarjetaconsumo_listar"
        Public Const spAsigTarjetaConsumo_Mantenimiento As String = "USP_ERP_ASIG_TARJETACONSUMO_MANTENIMIENTO"

        'hvilela 27/03/2025
        Public Const spListarLimiteTarjetasConsumo As String = "USP_LimiteLineaTarjetaConsumo25"

        '------------------------------
        ' 07/03/2025
        Public Const spAsigTarjetaConsumo_Mantenimiento25 As String = "USP_ERP_ASIG_TARJETACONSUMO_MANTENIMIENTO25"
        '------------------------------

        Public Const spAsigTarjetaConsumo_Validar As String = "USP_ERP_ASIG_TARJETACONSUMO_VALIDAR"
        Public Const spTarjetaConsumo_Historial As String = "usp_empleado_tarjetaconsumo_Historial"

        'Registro Facturas Telefonicas
        Public Const spFactTelefonia_Listar As String = "USP_ERP_FACT_TELEFONIA_LISTAR"
        Public Const spFactTelefonia_Obtener As String = "USP_ERP_FACT_TELEFONIA_OBTENER"
        Public Const spFactTelefonia_Mantenimiento As String = "USP_ERP_FACT_TELEFONIA_MANTENIMIENTO"

        Public Const MantenimientoFactGas As String = "USP_ERP_FACT_GAS"
        Public Const ListarFactGas As String = "USP_ERP_LISTA_FACT_GAS"
        Public Const ListarFactGasID As String = "USP_ERP_LISTA_FACT_GAS_ID"
        Public Const ListarFactGasCONSUMO As String = "USP_ERP_LISTA_CONSUMO_GAS"

        Public Const spFactTelefonia_ListarProveedores As String = "USP_ERP_FACT_TELEFONIA_LISTAR_PROV"
        Public Const spFactTelefonia_ListarTipoDoc As String = "USP_ERP_FACT_TELEFONIA_LISTAR_TIPODOC"

        'Grupos para Facturas Telefonicas
        Public Const spBolsaTelefonia_Listar As String = "USP_ERP_BOLSA_TELEFONIA_LISTAR"
        Public Const spBolsaTelefonia_Obtener As String = "USP_ERP_BOLSA_TELEFONIA_OBTENER"
        Public Const spBolsaTelefonia_Mantenimiento As String = "USP_ERP_BOLSA_TELEFONIA_MANTENIMIENTO"

        'Registro de SOAT
        Public Const spRegSOAT_Listar As String = "USP_ERP_REG_SOAT_LISTAR"
        Public Const spRegSOAT_Mantenimiento As String = "USP_ERP_REG_SOAT_MANTENIMIENTO"

        '<JOSF 26/12/2022>
        Public Const Kilometraje_Fecha As String = "usp_fecha_kilometraje"
        '</JOSF 26/12/2022>
    End Structure
#End Region

    Public Structure Entidad
        Event z()
        Public Shared Cliente As ETCliente
        Public Shared Costo As ETCosto
        Public Shared Mineral As ETMineral
        Public Shared Ruma As ETRuma
        Public Shared Requerimiento As ETRequerimiento
        Public Shared Producto As ETProducto
        Public Shared Usuario As ETUsuario
        Public Shared Activo As ETActivo
        Public Shared Objecto As ETObjecto
        Public Shared Personal As ETPersonal
        Public Shared Suministro As ETSuministro
        Public Shared Orden As ETOrden
        Public Shared Almacen As ETAlmacen
        Public Shared CanteraCosteo As ETCanteraCosteo
        Public Shared MyLista As ETMyLista
        Public Shared Area As ETArea
        Public Shared Area_Empleado As ETAreaEmpleado
        Public Shared Resultado As ETResultado
        Public Shared Periodo As ETPeriodo
        Public Shared PeriodoDetalle As ETPeriodoDetalle
        Public Shared Personal_LinProd As ETPersonalLineaProduccion
        Public Shared CosteoActivo As ETCosteoActivo
        Public Shared CtaCteContratista As ETCuentaCorriente
        Public Shared Entregas As ETEntregas
        Public Shared Contratista As ETContratista
        '**************************************
        ' SiMan
        Public Shared LineaNegocio As ETLineaNegocio
        Public Shared UnidadMedida As ETUnidadMedida
        Public Shared Atributo As ETAtributo
        Public Shared ParteEquipo As ETParteEquipo
        Public Shared FamiliaEquipo As ETFamiliaEquipo
        Public Shared Equipo As ETEquipo
        Public Shared CheckList As ETCheckList
        Public Shared CheckListDet As ETCheckListDetalle
        Public Shared Requerimiento_Mantto As ETRequerimiento_Mantto
        Public Shared Requerimiento_Det_Mantto As ETRequerimiento_ManttoDetalle
        Public Shared Programacion_Mantto As ETProgramacionMantto
        Public Shared Partida_Material As ETPartidaMaterial
        Public Shared Partida_Equipo As ETPartidaEquipo
        Public Shared Partida_ManoObra As ETPartidaManoObra
        Public Shared Partida_Servicio As ETPartidaServicio
        Public Shared Presupuesto As ETPresupuesto
        Public Shared Presupuesto_Detalle As ETPresupuestoDetalle
        Public Shared Presupuesto_Material As ETPresupuestoMaterial
        Public Shared Presupuesto_Equipo As ETPresupuestoEquipo
        Public Shared Presupuesto_ManoObra As ETPresupuestoManoObra
        Public Shared Presupuesto_Servicio As ETPresupuestoServicio
        Public Shared Presupuesto_Plan As ETPresupuestoPlan
        Public Shared Presupuesto_Plan_Recurso As ETPresupuestoPlanRecursos
        Public Shared Presupuesto_Plan_Recurso_Asignacion As ETPresupuestoPlanRecursosAsignacion
        Public Shared OrdenTrabajo As ETOrdenTrabajo_Mantto
        Public Shared OrdenTrabajo_Recursos As ETOrdenTrabajo_Recursos
        Public Shared OrdenTrabajo_Recurso_Detalle As ETOTRecursoDetalle
        Public Shared TareoOS As ETTareoOS
        Public Shared CosteoManttoMecanico As ETCosteoManttoMecanico
        Public Shared CosteoManttoMecanicoDetalle As ETCosteoManttoMecanicoDetalle
        Public Shared AreaJefatura As ETAreaJefatura
        Public Shared Maestro2 As ETMaestos2
        Public Shared Glosa As ETGlosa
        Public Shared Sistema As ETSistema
    End Structure


    Public Function Codigo_Producto(ByVal Numero As String) As String
        Select Case Len(Numero)
            Case 1
                Codigo_Producto = "5000000" & Numero
            Case 2
                Codigo_Producto = "500000" & Numero
            Case 3
                Codigo_Producto = "50000" & Numero
            Case 4
                Codigo_Producto = "5000" & Numero
            Case 5
                Codigo_Producto = "500" & Numero
            Case 6
                Codigo_Producto = "50" & Numero
            Case 7
                Codigo_Producto = "5" & Numero
            Case Else
                Codigo_Producto = Numero
        End Select
        Return Codigo_Producto
    End Function

    Public Function SerieMovimiento(ByVal Cia As String, ByVal Almacen As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Almacen)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Almacen)
            db.AddInParameter(cmd, "Opcion", DbType.String, "GEN")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            SerieMovimiento = Tabla.Rows(0).Item("Serie")

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function FlagRequerimiento(ByVal Cia As String, ByVal Area As String) As String

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarFlag)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)
            db.AddInParameter(cmd, "Cod_Area", DbType.String, Area)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            FlagRequerimiento = Tabla.Rows(0).Item("Flag2")

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function NumeroMovimiento(ByVal Cia As String, ByVal Mov As String, ByVal Doc As String, ByVal Almacen As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.NumeroMovimiento)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing



        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)
        db.AddInParameter(cmd, "Tipo_Mov", DbType.String, Mov)
        db.AddInParameter(cmd, "Tipo_Doc", DbType.String, Doc)
        db.AddInParameter(cmd, "Codigo_Almacen", DbType.String, Almacen)
        db.AddOutParameter(cmd, "Numero", DbType.Int16, 7)
        db.AddInParameter(cmd, "Opcion", DbType.String, "GEN")

        Ds = New DataSet
        Ds = db.ExecuteDataSet(cmd)

        Tabla = New DataTable
        Tabla = Ds.Tables(0).Copy

        NumeroMovimiento = NumeroMovimientoAlmacen(Tabla.Rows(0).Item("Serie").ToString)



    End Function

    Public Function NumeroMovimientoAlmacen(ByVal Numero As String) As String
        Select Case Len(Numero)
            Case 1
                NumeroMovimientoAlmacen = "000000" & Numero
            Case 2
                NumeroMovimientoAlmacen = "00000" & Numero
            Case 3
                NumeroMovimientoAlmacen = "0000" & Numero
            Case 4
                NumeroMovimientoAlmacen = "000" & Numero
            Case 5
                NumeroMovimientoAlmacen = "00" & Numero
            Case 6
                NumeroMovimientoAlmacen = "0" & Numero
            Case Else
                NumeroMovimientoAlmacen = Numero
        End Select
        Return NumeroMovimientoAlmacen
    End Function
End Module
