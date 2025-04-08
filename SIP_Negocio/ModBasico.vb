Imports SIP_Entidad
Imports SIP_Datos

Module ModBasico

    Public MsgErrorIngreso As String = "Se produjo un error al Ingresar los Datos"
    Public MsgErrorAlCargar As String = "No se pudieron Cargar los datos Correctamente"
    Public msgComacsa As String = "COMACSA"

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
        Public Shared MyLista As ETMyLista
        Public Shared Equipo As ETEquipo
        Public Shared Resultado As ETResultado
    End Structure

    Public Structure Datos

        Event z()
        Public Shared Maestro As New DAMaestro
        Public Shared Maestro2 As New DAMaestros2
        Public Shared Reporte As New DAReporte
        Public Shared Ruma As New DARuma
        Public Shared Producto As New DAProducto
        Public Shared Empleado As New DAEmpleado
        Public Shared Proyecto As New DAProyecto
        Public Shared Usuario As New DAUsuario
        Public Shared CanteraCosteo As New DACanteraCosteo
        Public Shared Activo As New DAActivo
        Public Shared Costo As New DACosto
        Public Shared Mineral As New DAMineral
        Public Shared Personal As New DAPersonal
        Public Shared Proveedor As New DAProveedor
        Public Shared Requerimiento As New DARequerimiento
        Public Shared Suministro As New DASuministro
        Public Shared Orden As New DAOrden
        Public Shared Cliente As New DACliente
        Public Shared Almacen As New DAAlmacen
        Public Shared Area As New DAArea
        Public Shared Area_Empleado As New DAAreaEmpleado
        Public Shared CosteoProduccion As New DACosteoProduccion
        Public Shared LineaProduccion As New DALineaProduccion
        Public Shared CtaCteContratista As New DACtaCteContratista
        Public Shared ConsultasRRHH As New DAConsultaRRHH
        Public Shared Banco As New DABanco

        Public Shared TarjetaConsumo As New DATarjetaConsumo

        Public Shared Glosa As New DAGlosa
        Public Shared Sistema As New DASistema

        '******************************
        '   SiMan
        '   Larry Fernando Sánchez Amaya
        Public Shared LineaNegocio As New DALineaNegocio
        Public Shared UnidadMedida As New DAUnidadMedida
        Public Shared Atributo As New DAAtributo
        Public Shared ParteEquipo As New DAParteEquipo
        Public Shared FamiliaEquipo As New DAFamiliaEquipo
        Public Shared Equipo As New DAEquipo
        Public Shared CheckList As New DACheckList
        Public Shared Requerimiento_Mantto As New DAReq_Mantto
        Public Shared Programacion_Mantto As New DAProgramacionMantto
        Public Shared Partida_Mantto As New DAPartida
        Public Shared Partida_Material As New DAPartidaMaterial
        Public Shared Partida_Equipo As New DAPartidaEquipo
        Public Shared Partida_ManoObra As New DAPartidaManoObra
        Public Shared Partida_Servicio As New DAPartidaServicio
        Public Shared Presupuesto As New DAPresupuesto
        Public Shared Presupuesto_Material As New DAPresupuestoMaterial
        Public Shared Presupuesto_Equipo As New DAPresupuestoEquipo
        Public Shared Presupuesto_ManoObra As New DAPresupuestoManoObra
        Public Shared Presupuesto_Servicios As New DAPresupuestoServicio
        Public Shared Presupuesto_Plan As New DAPresupuestoPlan
        Public Shared Presupuesto_Plan_Recurso As New DAPresupuestoPlanRecurso
        Public Shared Presupuesto_Plan_Recurso_Asignacion As New DAPresupuestoPlanRecursoAsignacion
        Public Shared OrdenTrabajo_Mantto As New DAOrdenTrabajo
        Public Shared OrdenTrabajo_Recursos As New DAOrdenTrabajoRecurso
        Public Shared OrdenTrabajo_Recursos_SinPrecio As New DAOrdenTrabajoRecursoSinPrecio
        Public Shared TareoOS As New DATareosOS
        Public Shared CosteoManttoMecanico As New DACosteoManttoMecanico
        Public Shared Periodo As New DAPeriodo
        Public Shared Personal_LinProd As New DAPersonal_LineaProduccion
        Public Shared PeriodoGasNatural As New DAPeriodoGasNatural
        Public Shared PeriodoPlantaCemento As New DAPeriodoPlantaCemento
        Public Shared AreaJefactura As New DAAreaJefatura

        Public Shared Entregas As New DAEntregas


        Public Shared InsumosFiscalizados As New DAInsumosFiscalizados
        Public Shared InsumosFProductos As New DAInsumosFProductos
        Public Shared ProveedorFiscalizado As New DAProveedorFiscalizado

        Public Shared Contratistas As New DAContratista
    End Structure



End Module
