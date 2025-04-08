Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinExplorerBar
Imports Infragistics.Win.UltraWinTree

Module ModFormulario

    Private Ls_Permisos As List(Of Integer) = Nothing
    Private ObjForm As Object = Nothing
    Public Sub Inizializar_Formulario(ByVal Tree As UltraTree, ByVal Tab As UltraTabControl, ByVal Mdi As Form)

        If Tree Is Nothing OrElse Mdi Is Nothing OrElse Tab Is Nothing Then
            Return
        End If

        Select Case Tree.ActiveNode.Key
            '   PRODUCCION
            Case StrucToolTag.MProductoRuma, _
                StrucToolTag.MProductoxUnidad, _
                StrucToolTag.MFormula
                StrucForm.Formulario = New FrmMEnlace
                StrucForm.Formulario.Tag = Tree.ActiveNode.Key
                StrucForm.Formulario.Text = NombrarFormulario(Tree.ActiveNode.Key)

            Case StrucToolTag.MUnidadPersonal
                StrucForm.Formulario = New FrmMUnidadPersonal

            Case StrucToolTag.MProductos
                StrucForm.Formulario = New FrmMProductos
            Case StrucToolTag.MEnvases
                StrucForm.Formulario = New FrmMSuministro
            Case StrucToolTag.MProyVentas
                StrucForm.Formulario = New FrmMProyVentas
            Case StrucToolTag.POrdenProduccion
                StrucForm.Formulario = New FrmLOrdenProduccion
            Case StrucToolTag.PCronograma
                StrucForm.Formulario = New FrmLCronograma
            Case StrucToolTag.PReqRumas
                StrucForm.Formulario = New FrmLRequerimiento
            Case StrucToolTag.CProductos
                StrucForm.Formulario = New FrmCProductos
            Case StrucToolTag.CPersonal
                StrucForm.Formulario = New FrmCPersonal
            Case StrucToolTag.CRumas
                StrucForm.Formulario = New FrmCRumas
            Case StrucToolTag.CStock
                StrucForm.Formulario = New FrmCStock
            Case StrucToolTag.CExportacion
                StrucForm.Formulario = New FrmCExportacion

            Case StrucToolTag.CCosteoProduccion
                StrucForm.Formulario = New frmCCosteoProduccion
                StrucForm.Formulario.Tag = StrucToolTag.CCosteoProduccion
                StrucForm.Formulario.Text = NombrarFormulario(Tree.ActiveNode.Key)
            Case StrucToolTag.CMineralesProductos
                StrucForm.Formulario = New frmCCosteoProduccion
                StrucForm.Formulario.Tag = StrucToolTag.CMineralesProductos
                StrucForm.Formulario.Text = NombrarFormulario(Tree.ActiveNode.Key)
            Case StrucToolTag.CTrazabilidadProforma
                StrucForm.Formulario = New frmCCosteoProduccion
                StrucForm.Formulario.Tag = StrucToolTag.CTrazabilidadProforma
                StrucForm.Formulario.Text = NombrarFormulario(Tree.ActiveNode.Key)

            Case StrucToolTag.MLineaProduccion
                StrucForm.Formulario = New frmMLineaProduccion
                StrucForm.Formulario.Tag = StrucToolTag.MLineaProduccion
                StrucForm.Formulario.Text = "Linea de Producción"
            Case StrucToolTag.MProcesoProductivo
                StrucForm.Formulario = New frmMLineaProduccion
                StrucForm.Formulario.Tag = StrucToolTag.MProcesoProductivo
                StrucForm.Formulario.Text = "Proceso Productivo"
            Case StrucToolTag.PPersonal_LineaProduccion
                StrucForm.Formulario = New frmLPersonalLineaProduccion

            Case StrucToolTag.PPeriodo_GasNatural
                StrucForm.Formulario = New frmLCosteoGasNatural
            Case StrucToolTag.PPeriodo_PlantaCemento
                StrucForm.Formulario = New frmLCosteoPlantaCemento
            Case StrucToolTag.PPeriodo_SiliceHomogenizada
                StrucForm.Formulario = New frmLSiliceHomogenizada
            Case StrucToolTag.PPeriodo_Costeo
                StrucForm.Formulario = New frmPeriodoCosteo
                StrucForm.Formulario.Tag = StrucToolTag.PPeriodo_Costeo
            Case StrucToolTag.PPeriodo_Costeo_Facturacion
                StrucForm.Formulario = New frmPeriodoCosteo
                StrucForm.Formulario.Tag = StrucToolTag.PPeriodo_Costeo_Facturacion
            Case StrucToolTag.PPeriodo_Costeo_Operador
                StrucForm.Formulario = New frmPeriodoCosteo
                StrucForm.Formulario.Tag = StrucToolTag.PPeriodo_Costeo_Operador
                'ANUN NO FUNCIONA
                'Case StrucToolTag.LOrdenProd_Pesado, StrucToolTag.LOrdenProd_Chancado, _
                '     StrucToolTag.LOrdenProd_Molienda_Confirmacion, StrucToolTag.LOrdenProd_Molienda_IngresoProd, _
                '     StrucToolTag.LOrdenProd_Envasado
                '    StrucForm.Formulario = New frmLProcesoOrdenProduccion
                '    StrucForm.Formulario.Tag = Tree.ActiveNode.Key
                '   Usuarios
            Case StrucToolTag.MUsuarios
                StrucForm.Formulario = New FrmMUsuarios
            Case StrucToolTag.MFormularios
                StrucForm.Formulario = New FrmMFormularios
            Case StrucToolTag.MSistemas
                StrucForm.Formulario = New frmMSistemas

                '   Almacen
            Case StrucToolTag.MSuministros
                StrucForm.Formulario = New FrmMaestroSuministros
            Case StrucToolTag.MCambioPassword
                StrucForm.Formulario = New FrmCambioPassword
            Case StrucToolTag.MEmpleoLabor
                StrucForm.Formulario = New FrmMaestroEmpleoLabor
            Case StrucToolTag.MConversionUnidades
                StrucForm.Formulario = New FrmMaestroConversionUnidades
            Case StrucToolTag.MRangoAprobacion
                StrucForm.Formulario = New FrmRangosAprobacion
            Case StrucToolTag.MFirmaDigital
                StrucForm.Formulario = New FrmUsuariosFirmaDigital
            Case StrucToolTag.AAprobacionOC
                StrucForm.Formulario = New FrmAprobacionOC
            Case StrucToolTag.AAprobacionRequerimiento
                StrucForm.Formulario = New FrmAprobacionRequerimiento
            Case StrucToolTag.CAprobacionOC
                StrucForm.Formulario = New FrmConsultaAprobaciones
            Case StrucToolTag.CPedidos
                StrucForm.Formulario = New FrmConsultaEstadoRequisicion
            Case StrucToolTag.CDatosAuxiliares
                StrucForm.Formulario = New FrmDatosAuxiliares
            Case StrucToolTag.VRecepcionServicios
                StrucForm.Formulario = New frmBilleteRecepcionServicios
            Case StrucToolTag.VIngresoAjuste
                StrucForm.Formulario = New FrmIngresoAjuste
            Case StrucToolTag.VIngresoOC
                StrucForm.Formulario = New FrmIngresoOC
            Case StrucToolTag.VIngresoRemarcado
                StrucForm.Formulario = New FrmIngresoRemarcado
            Case StrucToolTag.VIngresoSinOC
                StrucForm.Formulario = New FrmIngresoSinOC
            Case StrucToolTag.VIngrsoTransferencia
                StrucForm.Formulario = New FrmIngresoTransferencia
            Case StrucToolTag.VSalidaDevolucion
                StrucForm.Formulario = New FrmSalidaDevolucion
            Case StrucToolTag.VSalidaOrden
                StrucForm.Formulario = New FrmSalidaOrden
            Case StrucToolTag.VSalidaRemarcado
                StrucForm.Formulario = New FrmSalidaRemarcado
            Case StrucToolTag.VSalidaTransferencia
                StrucForm.Formulario = New FrmSalidaTransferencia
            Case StrucToolTag.EAutorizar
                StrucForm.Formulario = New FrmAutorizar
            Case StrucToolTag.EDistribuir
                StrucForm.Formulario = New FrmDistribuir
            Case StrucToolTag.EEntregar
                StrucForm.Formulario = New FrmEntregar
            Case StrucToolTag.ERegistrar
                StrucForm.Formulario = New FrmRegistrar

            Case StrucToolTag.ERequerimientoCompra
                StrucForm.Formulario = New FrmRequerimientoCompra
                StrucForm.Formulario.Tag = "46"
            Case StrucToolTag.ERequerimientoCompraConsolidado
                StrucForm.Formulario = New FrmRequerimientoCompra
                StrucForm.Formulario.Tag = "98"
            Case StrucToolTag.ERequerimientoCompraDistribuir
                StrucForm.Formulario = New FrmRequerimientoCompra
                StrucForm.Formulario.Tag = "99"
            Case StrucToolTag.CConsumoSuministro
                StrucForm.Formulario = New frmCConsultarConsumoSuministro
                'Minas
            Case StrucToolTag.CCosteoMineral
                StrucForm.Formulario = New FrmCCosteoMineral
            Case StrucToolTag.MCombustibleExplosivo
                StrucForm.Formulario = New FrmMCombustibleExplosivos
            Case StrucToolTag.MRegistroPersonalCantera
                StrucForm.Formulario = New FrmMRegistroEmpleado
            Case StrucToolTag.MUbicacionCantera
                StrucForm.Formulario = New FrmMUbicacionEquipoCantera
            Case StrucToolTag.MVigenciaCantera
                StrucForm.Formulario = New FrmMVigenciaCantera
            Case StrucToolTag.MVidaUtilEquipo
                StrucForm.Formulario = New FrmMVidaUtil
            Case StrucToolTag.CCanteraEquipo
                StrucForm.Formulario = New FrmCVidaUtil
            Case StrucToolTag.MHoraMaquina
                StrucForm.Formulario = New FrmMHoraMaquina
            Case StrucToolTag.MDerechoCesion
                StrucForm.Formulario = New FrmMDerechosCesion
            Case StrucToolTag.MDonaciones
                StrucForm.Formulario = New FrmMDonaciones
            Case StrucToolTag.MListaPrecio
                StrucForm.Formulario = New FrmMListaPrecioEquipo
            Case StrucToolTag.MDeprecionEquipo
                StrucForm.Formulario = New FrmMDepreciacionEquipo
            Case StrucToolTag.MCostoAutorizacion
                StrucForm.Formulario = New FrmMCostoAutorizacion
            Case StrucToolTag.CEnvioSuministros
                StrucForm.Formulario = New FrmCEnvioSuministrosCantera
            Case StrucToolTag.MListaPrecioFlete
                StrucForm.Formulario = New frmMListaPrecioFlete_Cantera
            Case StrucToolTag.MListaPrecioFletexMineral
                StrucForm.Formulario = New frmMListaPrecioFleteMineral
            Case StrucToolTag.CCtaCteContratista
                StrucForm.Formulario = New frmCCtaCteContratista
            Case StrucToolTag.DContratista
                StrucForm.Formulario = New frmDContratista
                StrucForm.Formulario.Tag = "110"
            Case StrucToolTag.DContratista_Faltas
                StrucForm.Formulario = New frmDContratista
                StrucForm.Formulario.Tag = "111"
            Case StrucToolTag.DContratista_Esquema2
                StrucForm.Formulario = New frmDContratista
                StrucForm.Formulario.Tag = "112"
            Case StrucToolTag.DContratista_ListaPrecioMineral
                StrucForm.Formulario = New frmDListarPrecioMineral

            Case StrucToolTag.DContratista_GenerarReporte
                StrucForm.Formulario = New frmDGenerarReporte


            Case StrucToolTag.MGlosaCostoAutorizTramiteDoc
                StrucForm.Formulario = New frmMGlosa
                StrucForm.Formulario.Tag = "24M93"
            Case StrucToolTag.CCosteoMineralxCantera
                StrucForm.Formulario = New FrmCConsultarResumenPeriodoCantera
                StrucForm.Formulario.Tag = "104"
                StrucForm.Formulario.Text = "Costeo de Minerales por Cantera"
            Case StrucToolTag.CCosteoMineralxTipoCosto
                StrucForm.Formulario = New FrmCConsultarResumenPeriodoCantera
                StrucForm.Formulario.Text = "Costeo de Minerales por Tipo de Costo"
                StrucForm.Formulario.Tag = "105"

            Case StrucToolTag.CCosteoMineralxCanteraxRango
                StrucForm.Formulario = New FrmCConsultarResumenRangoCantera
                StrucForm.Formulario.Tag = "118"
                StrucForm.Formulario.Text = "Costeo de Minerales por Cantera por Rangos"
            Case StrucToolTag.CCosteoMineralxTipoCostoxRango
                StrucForm.Formulario = New FrmCConsultarResumenRangoCantera
                StrucForm.Formulario.Text = "Costeo de Minerales por Tipo de Costo por Rangos"
                StrucForm.Formulario.Tag = "119"


            Case StrucToolTag.MDisponibilidadEquiposCantera
                StrucForm.Formulario = New FrmDisponibilidadEquipoCantera
            Case StrucToolTag.CReportesVarios
                StrucForm.Formulario = New frmCReporteMinasVarios

                'Mantenimiento
            Case StrucToolTag.MLineaNegocio, StrucToolTag.MAtributo, _
                StrucToolTag.MParteEquipo
                StrucForm.Formulario = New frmMCatalogosMantto
                StrucForm.Formulario.Tag = "M" & Tree.ActiveNode.Key
            Case StrucToolTag.MEnzalarComponenteSubComponente, _
                StrucToolTag.MEnzalarAtributoComponente, _
                StrucToolTag.MEnzalarAtributoFamiliaEquipo, _
                StrucToolTag.MEnzalarComponenteFamiliaEquipo
                StrucForm.Formulario = New frmMEnlazarCatalogos
                StrucForm.Formulario.Tag = "M" & Tree.ActiveNode.Key
            Case StrucToolTag.MFamiliaEquipo
                StrucForm.Formulario = New frmMFamiliaEquipo
            Case StrucToolTag.MEquipo
                StrucForm.Formulario = New frmMEquipo
            Case StrucToolTag.MPlantillaAPU
                StrucForm.Formulario = New frmMPlantillaAPU
            Case StrucToolTag.SCheckList
                StrucForm.Formulario = New frmPCheckList
            Case StrucToolTag.SRequerimiento
                StrucForm.Formulario = New frmPRequerimientoMantto
            Case StrucToolTag.SProgramacion
                StrucForm.Formulario = New frmPProgramacionMantto
            Case StrucToolTag.SPresupuesto
                StrucForm.Formulario = New frmPPresupuesto
            Case StrucToolTag.SOrdenTrabajo, StrucToolTag.SBackLog
                StrucForm.Formulario = New frmPOrdenTrabajo
                StrucForm.Formulario.Tag = "S" & Tree.ActiveNode.Key
            Case StrucToolTag.STareoOS_Personal, StrucToolTag.STareoOS_Equipo
                StrucForm.Formulario = New frmPTareoOS
                StrucForm.Formulario.Tag = "S" & Tree.ActiveNode.Key

            Case StrucToolTag.APresupuesto
                StrucForm.Formulario = New frmPresupuestoAprobar

            Case StrucToolTag.RPresupuesto_vs_OrdenTrabajo
                StrucForm.Formulario = New frmROrdenTrabajo_vs_Presupuesto

            Case StrucToolTag.POrdenTrabajo_Recurso_Sin_Precio
                StrucForm.Formulario = New frmPOrdenTrabajoRecursoSinPrecio
            Case StrucToolTag.MEnlazarCodigoEquipo_CodigoContabilidad
                StrucForm.Formulario = New frmEnlazarEquipoContabilidad
            Case StrucToolTag.PCosteoMantoMecanico
                StrucForm.Formulario = New frmPCosteoManttoMecanico
            Case StrucToolTag.MAreaEmpleado
                StrucForm.Formulario = New frmMAreaEmpleado

                'RRHH
            Case StrucToolTag.CCtaCtePersonal
                StrucForm.Formulario = New frmCCuentaCorrientePersonal

                'ADMINISTRACION
            Case StrucToolTag.MInsumosControlados
                StrucForm.Formulario = New FrmLiquidacionEntregas
            Case StrucToolTag.MEntregaraRendir
                StrucForm.Formulario = New FrmEntregasxRendir
            Case StrucToolTag.MUsuarioAprueba
                StrucForm.Formulario = New FrmUsuarioApruebaEntrega
            Case StrucToolTag.MConsulta
                StrucForm.Formulario = New FrmConsultas
            Case StrucToolTag.MLineaCredito
                StrucForm.Formulario = New FrmLineaCredito
            Case StrucToolTag.MAprobarLiquidacion
                StrucForm.Formulario = New FrmAprobarLiquidacion
            Case StrucToolTag.MDescripciones
                StrucForm.Formulario = New FrmDescripciones
            Case StrucToolTag.MSeteoContable
                StrucForm.Formulario = New FrmSeteoContable
            Case StrucToolTag.MTrabajadoresArea
                StrucForm.Formulario = New FrmTrabajadoresArea

            Case StrucToolTag.AdmFrmInsumosF
                StrucForm.Formulario = New frmInsumosFiscalizados
            Case StrucToolTag.AdmFrmProveedorF
                StrucForm.Formulario = New FrmProveedorFiscalizado
            Case StrucToolTag.AdmCargaIQBF
                StrucForm.Formulario = New frmCargaDatosIQBF
            Case StrucToolTag.RegionCantera
                StrucForm.Formulario = New FrmRegionesCantera
            Case StrucToolTag.ConsultaCombustible
                StrucForm.Formulario = New frmConsultaCombustible
            Case StrucToolTag.RevisionDocumentos
                StrucForm.Formulario = New FrmRevisionDocumentos
            Case StrucToolTag.MantenimientoCombustible
                StrucForm.Formulario = New FrmMantenimientoCombustible
            Case StrucToolTag.UsuarioIngresoInformacion
                StrucForm.Formulario = New FrmUsuarioIngresoInformacion
            Case StrucToolTag.SeteoCorreo
                StrucForm.Formulario = New FrmSeteoEnvioCorreo
            Case StrucToolTag.HtnrPResentacion
                StrucForm.Formulario = New frmHtnrxPresentacion
            Case StrucToolTag.GeneraStamin
                StrucForm.Formulario = New FrmGeneraStamin
            Case StrucToolTag.rptMorosidad
                StrucForm.Formulario = New frmMorosidad
            Case StrucToolTag.AplicaReintegro
                StrucForm.Formulario = New FrmAplicaReintegro
            Case StrucToolTag.rptViatico
                StrucForm.Formulario = New frmConsultaViaticos
            Case StrucToolTag.ConsultaRecibo
                StrucForm.Formulario = New frmConsultaRecibo
                StrucForm.Formulario.Tag = 0
            Case StrucToolTag.ConsultaSaldos
                StrucForm.Formulario = New FrmConsultaSaldos
            Case StrucToolTag.SolicitudAprobada
                StrucForm.Formulario = New frmSolicitudesAprobadas
            Case StrucToolTag.SolicitudCero
                StrucForm.Formulario = New frmSolicitudCero
            Case StrucToolTag.RendimientoxUnidad
                StrucForm.Formulario = New FrmRendimientoxUnidad
            Case StrucToolTag.PrecioCombustible
                StrucForm.Formulario = New FrmMPrecioCombustible
            Case StrucToolTag.ValesSinSustento
                StrucForm.Formulario = New frmReporteVales
            Case StrucToolTag.ProyeccionVentaRuma
                StrucForm.Formulario = New FrmProyeccionVentaRuma
            Case StrucToolTag.ProvisionLiquidaciones
                StrucForm.Formulario = New FrmProvisionLiquidaciones
            Case StrucToolTag.AgrupacionRumas
                StrucForm.Formulario = New frmAgrupacionRuma
            Case StrucToolTag.ReporteFormulaciones
                StrucForm.Formulario = New FrmCFormulacion
            Case StrucToolTag.ConsultaDocumentos
                StrucForm.Formulario = New frmConsultaRecibo
                StrucForm.Formulario.Tag = 1
            Case StrucToolTag.FormulacionProyectado
                StrucForm.Formulario = New FrmMFormulacionProyectado
            Case StrucToolTag.RptOperaciones
                StrucForm.Formulario = New frmRptOperaciones
            Case StrucToolTag.ExcepcionPesoVehicular
                StrucForm.Formulario = New FrmExcepcionPesoVehicular
            Case StrucToolTag.LetraTransportista
                StrucForm.Formulario = New FrmLetraTransportista
            Case StrucToolTag.ExoneracionLetra
                StrucForm.Formulario = New FrmExoneracionLetra
            Case StrucToolTag.ReporteDAC
                StrucForm.Formulario = New FrmRtDac
            Case StrucToolTag.ConstanciamalLlenada
                StrucForm.Formulario = New FrmConstanciamalLlenada
            Case StrucToolTag.Contratista
                StrucForm.Formulario = New frmContratista
            Case StrucToolTag.AnticipoExtraccion
                StrucForm.Formulario = New frmAnticipoExtraccion
            Case StrucToolTag.PlanillaContratista
                StrucForm.Formulario = New frmPlanillaContratista
            Case StrucToolTag.AnticipoObligacion
                StrucForm.Formulario = New frmAnticipoObligacionLaboral
            Case StrucToolTag.AnticipoImpuesto
                StrucForm.Formulario = New frmAnticipoImpuesto
            Case StrucToolTag.Conceptos
                StrucForm.Formulario = New frmConceptos
            Case StrucToolTag.PrecioMineral
                StrucForm.Formulario = New frmPrecioMineral
            Case StrucToolTag.AnticipoGratificacion
                StrucForm.Formulario = New frmAnticipoGratificacion
            Case StrucToolTag.AnticipoCts
                StrucForm.Formulario = New frmAnticipoCts
            Case StrucToolTag.AnticipoVacacionLiquidacion
                StrucForm.Formulario = New frmAnticipoVacacionesLiquidaciones
            Case StrucToolTag.AnticipoOtros
                StrucForm.Formulario = New frmAnticipoOtrosConceptos
                StrucForm.Formulario.Tag = "OA"
            Case StrucToolTag.SeteoFechas
                StrucForm.Formulario = New frmSteoFechas
            Case StrucToolTag.SuspensionRenta
                StrucForm.Formulario = New FrmSuspensionRenta
            Case StrucToolTag.ConceptoRH
                StrucForm.Formulario = New FrmConceptoRH
            Case StrucToolTag.SeteoFcb
                StrucForm.Formulario = New frm_SeteoFCB
            Case StrucToolTag.RptFcb
                StrucForm.Formulario = New frm_RptFCB
            Case StrucToolTag.AnticipoProveedor
                StrucForm.Formulario = New frmAnticipoOtrosConceptos
                StrucForm.Formulario.Tag = "PR"
            Case StrucToolTag.CargaPlanilla
                StrucForm.Formulario = New frmCargaPlanilla
            Case StrucToolTag.AgregaAlmacen
                StrucForm.Formulario = New frmAgregaAlmacen
            Case StrucToolTag.MaquinaContratista
                StrucForm.Formulario = New frmMaquinaContratista
            Case StrucToolTag.TipoMovimiento
                StrucForm.Formulario = New frmTipoMovimiento
            Case StrucToolTag.Movimientos
                StrucForm.Formulario = New frmMovimientos
            Case StrucToolTag.ImportarDatos
                StrucForm.Formulario = New frmImportaDatos
            Case StrucToolTag.Kardex
                StrucForm.Formulario = New frmKardex
            Case StrucToolTag.Existencia
                StrucForm.Formulario = New frmExistencias
            Case StrucToolTag.MaqPesada
                StrucForm.Formulario = New frmMaqPesada
            Case StrucToolTag.ApruebaDocumentos
                StrucForm.Formulario = New FrmApruebaDocumentos
            Case StrucToolTag.AlquilerVehiculo
                StrucForm.Formulario = New FrmAlquilerVehiculo
            Case StrucToolTag.ConsultaContratista
                StrucForm.Formulario = New frmConsultaContratista
            Case StrucToolTag.RegistroCamiones
                StrucForm.Formulario = New frmCamiones
            Case StrucToolTag.Camiondisponible
                StrucForm.Formulario = New frmCamionDisponible
            Case StrucToolTag.ProgramacionCamion
                StrucForm.Formulario = New frmProgramacionCamion
            Case StrucToolTag.ConsultaProgramacion
                StrucForm.Formulario = New frmConsultaProgramacion
            Case StrucToolTag.ProgramacionGuia
                StrucForm.Formulario = New frmProgramacionGuia
            Case StrucToolTag.Programacion_Incidencia
                StrucForm.Formulario = New frmProgramacion_Incidencia
            Case StrucToolTag.Mant_Incidencia
                StrucForm.Formulario = New frmMant_Incidencia
            Case StrucToolTag.Mant_Conceptos
                StrucForm.Formulario = New frmMant_Conceptos
            Case StrucToolTag.IngresoTasa
                StrucForm.Formulario = New frmIngresoTasa
            Case StrucToolTag.CalculoPPago
                StrucForm.Formulario = New frmCalculoPPago
            Case StrucToolTag.ReporteCosteo
                StrucForm.Formulario = New FrmReporteCosteo
            Case StrucToolTag.CostoIndirecto
                StrucForm.Formulario = New FrmCostoIndirecto
            Case StrucToolTag.ReporteIndirecto
                StrucForm.Formulario = New FrmReporteIndirecto
            Case StrucToolTag.ReporteFinal
                StrucForm.Formulario = New FrmReporteFinal
            Case StrucToolTag.CostoPromedio
                StrucForm.Formulario = New FrmCostoPromedio
            Case StrucToolTag.Costo_Seteos
                StrucForm.Formulario = New FrmCosto_Seteos
            Case StrucToolTag.FrmTonIngresadas
                StrucForm.Formulario = New FrmTonIngresadas
            Case StrucToolTag.FrmCostoTrimestral
                StrucForm.Formulario = New FrmCostoTrimestral
            Case StrucToolTag.FrmCostoAltoBajo
                StrucForm.Formulario = New FrmCostoAltoBajo
            Case StrucToolTag.frmInventarioIQBF
                StrucForm.Formulario = New frmInventarioIQBF
            Case StrucToolTag.FrmReporteRH
                StrucForm.Formulario = New FrmReporteRH
            Case StrucToolTag.FrmCosteoMinaCantera
                StrucForm.Formulario = New FrmCosteoMinaCantera

            Case StrucToolTag.FrmReporteIndicadores
                StrucForm.Formulario = New FrmReporteIndicadores

            Case StrucToolTag.FrmRptEstimacionesVtasProd
                StrucForm.Formulario = New FrmRptEstimacionesVtasProd

            Case StrucToolTag.FrmMantProdOptima
                StrucForm.Formulario = New FrmMantProdOptima
            Case StrucToolTag.FrmIndProduccion
                StrucForm.Formulario = New FrmIndProduccion
            Case StrucToolTag.FrmIndAdministracion
                StrucForm.Formulario = New FrmIndAdministracion
            Case StrucToolTag.FrmIngresoIndicadores
                StrucForm.Formulario = New FrmIngresoIndicadores
            Case StrucToolTag.FrmCostoMineralDet
                StrucForm.Formulario = New FrmCostoMineralDet
            Case StrucToolTag.FrmCargaConsumoEnergia
                StrucForm.Formulario = New FrmCargaConsumoEnergia
            Case StrucToolTag.FrmRumaComparativo
                StrucForm.Formulario = New FrmRumaComparativo
            Case StrucToolTag.FrmCapacidadCemento
                StrucForm.Formulario = New FrmCapacidadCemento
            Case StrucToolTag.FrmParaCampañaCemento
                StrucForm.Formulario = New FrmParaCampañaCemento
            Case StrucToolTag.FrmTrazabilidadCosteo
                StrucForm.Formulario = New FrmTrazabilidadCosteo
            Case StrucToolTag.frmResumenMensual
                StrucForm.Formulario = New frmResumenMensual
            Case StrucToolTag.Frm_Rh_Retencion
                StrucForm.Formulario = New Frm_Rh_Retencion
            Case StrucToolTag.FrmReporteLimiteRH
                StrucForm.Formulario = New FrmReporteLimiteRH
            Case StrucToolTag.frmConceptoFactura
                StrucForm.Formulario = New frmConceptoFactura
            Case StrucToolTag.frmFacturaConcepto
                StrucForm.Formulario = New frmFacturaConcepto
            Case StrucToolTag.FrmPrecioProductoCliente
                StrucForm.Formulario = New FrmPrecioProductoCliente
            Case StrucToolTag.FrmCostoxMolino
                StrucForm.Formulario = New FrmCostoxMolino
            Case StrucToolTag.FrmRegAlqMaquina
                StrucForm.Formulario = New FrmRegAlqMaquina
			Case StrucToolTag.frmCargaPesosCrudo
                StrucForm.Formulario = New FrmCargaPesoParaCrudo
            Case StrucToolTag.FrmRptNoConforme
                StrucForm.Formulario = New FrmRptNoConforme
            Case StrucToolTag.Frm_Costo_ConsumoEnergia
                StrucForm.Formulario = New Frm_Costo_ConsumoEnergia
			Case StrucToolTag.frmVentasReclamos
                StrucForm.Formulario = New frmReclamos
            Case StrucToolTag.frmLaboratorioReclamos
                StrucForm.Formulario = New frmReclamosLaboratorio
			Case StrucToolTag.frmVentasReclamosRegistro
                StrucForm.Formulario = New frmReclamoEjecutivo
            Case StrucToolTag.FrmAutorizaIQBF
                StrucForm.Formulario = New FrmAutorizaIQBF
            Case StrucToolTag.FrmPedidoSuministro
                StrucForm.Formulario = New FrmPedidoSuministro
            Case StrucToolTag.FrmRegistroKardex
                StrucForm.Formulario = New FrmRegistroKardex
            Case StrucToolTag.FrmRptVacacionesLiquidaciones
                StrucForm.Formulario = New FrmRptVacacionesLiquidaciones
            Case StrucToolTag.FrmAplicacionAnticipo
                StrucForm.Formulario = New FrmAplicacionAnticipo
            Case StrucToolTag.FrmEquipoCantera
                StrucForm.Formulario = New FrmEquipoCantera
            Case StrucToolTag.frmExamenesMedicos
                StrucForm.Formulario = New frmExamenesMedicos
            Case StrucToolTag.frmFacturaCombustible
                StrucForm.Formulario = New frmFacturaCombustible
            Case StrucToolTag.FrmRptIgvRenta
                StrucForm.Formulario = New FrmRptIgvRenta
            Case StrucToolTag.FrmConsumoCentroCosto
                StrucForm.Formulario = New FrmConsumoPorCC
            Case StrucToolTag.FrmAsignacionCelular
                StrucForm.Formulario = New FrmAsignacionCelulares
            Case StrucToolTag.FrmVinculoFacturasConsumo
                StrucForm.Formulario = New FrmFacturasTelefonicas
            Case StrucToolTag.FrmRegistroSOAT
                StrucForm.Formulario = New FrmRegistroSOAT
            Case StrucToolTag.FrmTarifaVR
                StrucForm.Formulario = New FrmTarifaVR
            Case StrucToolTag.frmCargaUnacem
                StrucForm.Formulario = New frmCargaUnacem
            Case StrucToolTag.FrmMesesProduccion
                StrucForm.Formulario = New FrmMesesProduccion
            Case StrucToolTag.frmRptControlPPago
                StrucForm.Formulario = New frmRptControlPPago
            Case StrucToolTag.FrmProyectos
                StrucForm.Formulario = New FrmProyectos
            Case StrucToolTag.FrmProyectoTrabajador
                StrucForm.Formulario = New FrmProyectoTrabajador
            Case StrucToolTag.FrmProyectoEquipo
                StrucForm.Formulario = New FrmProyectoEquipo
            Case StrucToolTag.FrmGuiasFacturas
                StrucForm.Formulario = New FrmGuiasFacturas
            Case StrucToolTag.FrmCargaBilletes
                StrucForm.Formulario = New FrmCargaBilletes
            Case StrucToolTag.FrmFacturaGas
                StrucForm.Formulario = New FrmFacturaGas
            Case StrucToolTag.FrmApruebaAtencionSuministro
                StrucForm.Formulario = New FrmApruebaAtencionSuministro
            Case StrucToolTag.FrmHistorialPedido
                StrucForm.Formulario = New FrmHistorialPedido
            Case StrucToolTag.FrmMineralFleteExt
                StrucForm.Formulario = New FrmMineralFleteExt
            Case StrucToolTag.FemIndicadorLab
                StrucForm.Formulario = New FemIndicadorLab
            Case StrucToolTag.FrmCalendario
                StrucForm.Formulario = New FrmCalendario
            Case StrucToolTag.FrmProyectoTarea
                StrucForm.Formulario = New FrmProyectoTarea
            Case StrucToolTag.FrmPlanificacion
                StrucForm.Formulario = New FrmPlanificacion
            Case StrucToolTag.FrmCierrePlanificacion
                StrucForm.Formulario = New FrmCierrePlanificacion
            Case StrucToolTag.FrmAvanceProyecto
                StrucForm.Formulario = New FrmAvanceProyecto
            Case StrucToolTag.FrmReporteParada
                StrucForm.Formulario = New FrmReporteParada
            Case StrucToolTag.FrmValidaProduccion
                StrucForm.Formulario = New FrmValidaProduccion
            Case StrucToolTag.FrmTarifaExporta
                StrucForm.Formulario = New FrmTarifaExporta
            Case StrucToolTag.frmRptCuenta9
                StrucForm.Formulario = New frmRptCuenta9
            Case StrucToolTag.frmCostosAdm
                StrucForm.Formulario = New frmCostosAdm
            Case StrucToolTag.FrmControlInventario
                StrucForm.Formulario = New FrmControlInventario
            Case StrucToolTag.FrmConsultaOrden
                StrucForm.Formulario = New FrmConsultaOrden
            Case StrucToolTag.FrmResumenER
                StrucForm.Formulario = New FrmResumenER
            Case StrucToolTag.frmListadoExportacion
                StrucForm.Formulario = New frmListadoExportacion

            Case StrucToolTag.frmReporteCostoCargaLaboral
                StrucForm.Formulario = New frmReporteCostoCargaLaboral

            Case StrucToolTag.frmCIndicadores
                StrucForm.Formulario = New frmCIndicadores

            Case StrucToolTag.frmConsultaParteAsistencia
                StrucForm.Formulario = New frmConsultaParteAsistencia
            Case StrucToolTag.FrmBolsaCostos
                StrucForm.Formulario = New FrmBolsaCostos
            Case StrucToolTag.FrmKardexCosteo
                StrucForm.Formulario = New FrmKardexCosteo
            Case StrucToolTag.FrmSustentoProduccion
                StrucForm.Formulario = New frmSustentoProducción
            Case StrucToolTag.FrmactivaEmpleados

                StrucForm.Formulario = New FrmActivaEmpleados
            Case StrucToolTag.FrmImpEtiquetaQR
                StrucForm.Formulario = New FrmImpEtiquetaQR

            Case StrucToolTag.FrmSolicitudPlanilla
                StrucForm.Formulario = New FrmSolicitudPlanilla

            Case StrucToolTag.FrmListaDiferenciaProducto
                StrucForm.Formulario = New FrmListaDiferenciaProducto

            Case StrucToolTag.FrmReporteCostCantera
                StrucForm.Formulario = New FrmReporteCostCantera
            Case StrucToolTag.FrmSeteoRumasCantidad
                StrucForm.Formulario = New FrmSeteoRumasCantidad
            Case StrucToolTag.FrmGastosVehiculos
                StrucForm.Formulario = New FrmGastosVehiculos
            Case StrucToolTag.FrmFamiliaProductos
                StrucForm.Formulario = New FrmFamiliaProductos
            Case StrucToolTag.FrmConsumoRecursos
                StrucForm.Formulario = New FrmConsumoRecursos
            Case StrucToolTag.FrmLecturaDrone
                StrucForm.Formulario = New FrmLecturaDron
            Case StrucToolTag.FrmAsigTarjetasConsumo
                StrucForm.Formulario = New FrmAsigTarjetasConsumo
            Case Else
                Return
        End Select


        Call Show_Permisos(StrucForm.Formulario, Tree.ActiveNode.Key)

        Call Show_Form(StrucForm.Formulario, Mdi, Tab, Tree)

    End Sub

    Public Sub Inizializar_VisorReporte(ByVal frm As frmVisorReporte)
        Dim frmReporte As New frmVisorReporte
        frmReporte.OrdenTrabajo = frm.OrdenTrabajo
        frmReporte.Presupuesto = frm.OrdenTrabajo
        frmReporte.Status = frm.Status
        Call Show_Permisos(frmReporte, "82")

        frmReporte.MdiParent = FrmBMain
        frmReporte.WindowState = FormWindowState.Maximized
        frmReporte.Show()

    End Sub
    Sub Show_Form(ByVal ChildForm As Form, ByVal Mdi As Form, ByVal Tab As UltraTabControl, ByVal Tree As UltraTree)

        If ChildForm Is Nothing OrElse Mdi Is Nothing OrElse Tab Is Nothing OrElse Tree Is Nothing Then
            Return
        End If

        Call CargarUltraStatusBar(Mdi, uStatus.Procesando)

        ChildForm.MdiParent = Mdi
        ChildForm.Text = String.Concat(Tab.ActiveTab.Text, _
                                       ".", _
                                       StrConv(Tree.Tag.ToString, VbStrConv.ProperCase), _
                                       " - ", _
                                       StrConv(ChildForm.Text, VbStrConv.ProperCase))
        ChildForm.WindowState = FormWindowState.Maximized
        ChildForm.Show()

        Call CargarUltraStatusBar(Mdi, uStatus.Finalizado)

    End Sub

    Sub Show_Permisos(ByRef Formulario As Form, ByVal Key As String)

        Ls_Permisos = New List(Of Integer) : ObjForm = New Object

        Ls_Permisos = Habilitar_Permisos(Key)

        ObjForm = Formulario
        ObjForm.Ls_Permisos = Ls_Permisos.ToList

        Formulario = ObjForm

    End Sub

End Module
