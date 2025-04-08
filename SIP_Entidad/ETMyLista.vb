Public Class ETMyLista

    Inherits ETObjecto

    Private _Ls_Producto As List(Of ETProducto)
    Private _Ls_Activo As List(Of ETActivo)
    Private _Ls_Almacen As List(Of ETAlmacen)
    Private _Ls_Cliente As List(Of ETCliente)
    Private _Ls_Costo As List(Of ETCosto)
    Private _Ls_Mineral As List(Of ETMineral)
    Private _Ls_Personal As List(Of ETPersonal)
    Private _Ls_Proforma As List(Of ETProforma)
    Private _Ls_Requerimiento As List(Of ETRequerimiento)
    Private _Ls_Ruma As List(Of ETRuma)
    Private _Ls_Formulacion_Ruma As List(Of ETRuma)
    Private _Ls_Formulacion_Producto As List(Of ETRuma)
    Private _Ls_Formulacion_Suministro As List(Of ETRuma)
    Private _Ls_Formulacion_Recirculado As List(Of ETRuma)
    Private _Ls_Suministro As List(Of ETSuministro)
    Private _Ls_Usuario As List(Of ETUsuario)
    Private _Ls_Orden As List(Of ETOrden)
    Private _Ls_CanteraCosteo As List(Of ETCanteraCosteo)
    Private _Ls_Area As List(Of ETArea)
    Private _Ls_AreaEmpleado As List(Of ETAreaEmpleado)
    Private _Ls_LineaProduccion As List(Of ETLineaNegocio)
    Private _Ls_LineaProduccion_Productos As List(Of ETLineaNegocio)
    Private _Ls_LineaProduccion_Proceso As List(Of ETLineaNegocio)
    Private _Ls_CtaCtePersonal As List(Of ETCuentaCorriente)
    Private _Ls_PeriodoDetalle As List(Of ETPeriodoDetalle)

    Private _Ls_Periodo As List(Of ETPeriodo)
    Private _Ls_Personal_LinProd As List(Of ETPersonalLineaProduccion)
    Private _Ls_PeriodoGasNatural As List(Of ETCosteoActivo)
    Private _Ls_PeriodoGasNaturalLinProd As List(Of ETLineaNegocio)
    Private _Ls_CosteoActivo As List(Of ETCosteoActivo)
    Private _Ls_CtaCteContratista As List(Of ETCuentaCorriente)

    '***********************
    '   Siman
    Private _Ls_LinNeg As New List(Of ETLineaNegocio)
    Private _Ls_UnidadMedida As New List(Of ETUnidadMedida)
    Private _Ls_Atributo As New List(Of ETAtributo)
    Private _Ls_ParteEquipo As New List(Of ETParteEquipo)
    Private _Ls_SubParteEquipo As New List(Of ETParteEquipo)
    Private _Ls_FamiliaEquipo As New List(Of ETFamiliaEquipo)
    Private _Ls_Equipo As New List(Of ETEquipo)
    Private _Ls_CheckList As New List(Of ETCheckList)
    Private _Ls_CheckListDet As New List(Of ETCheckListDetalle)
    Private _Ls_Requerimiento_Mantto As New List(Of ETRequerimiento_Mantto)
    Private _Ls_Requerimiento_Det_Mantto As New List(Of ETRequerimiento_ManttoDetalle)
    Private _Ls_Programacion_Mantto As New List(Of ETProgramacionMantto)
    Private _Ls_Partida_Material As New List(Of ETPartidaMaterial)
    Private _Ls_Partida_Equipo As New List(Of ETPartidaEquipo)
    Private _Ls_Partida_ManoObra As New List(Of ETPartidaManoObra)
    Private _Ls_Partida_Servicio As New List(Of ETPartidaServicio)
    Private _Ls_Presupuesto As New List(Of ETPresupuesto)
    Private _Ls_Presupuesto_Detalle As New List(Of ETPresupuestoDetalle)
    Private _Ls_Presupuesto_Material As New List(Of ETPresupuestoMaterial)
    Private _Ls_Presupuesto_Equipo As New List(Of ETPresupuestoEquipo)
    Private _Ls_Presupuesto_ManoObra As New List(Of ETPresupuestoManoObra)
    Private _Ls_Presupuesto_Servicio As New List(Of ETPresupuestoServicio)
    Private _Ls_Presupuesto_Plan As New List(Of ETPresupuestoPlan)
    Private _Ls_Presupuesto_Plan_Recurso As New List(Of ETPresupuestoPlanRecursos)
    Private _Ls_Presupuesto_Plan_Recurso_Asignacion As New List(Of ETPresupuestoPlanRecursosAsignacion)
    Private _Ls_Orden_Trabajo_Mantto As New List(Of ETOrdenTrabajo_Mantto)
    Private _Ls_Orden_Trabajo_Recurso As New List(Of ETOrdenTrabajo_Recursos)
    Private _Ls_Orden_Trabajo_RecursoDetalle As New List(Of ETOTRecursoDetalle)
    Private _Ls_TareoOS As New List(Of ETTareoOS)
    Private _Ls_CosteoManttoMecanico As New List(Of ETCosteoManttoMecanico)
    Private _Ls_CosteoManttoMecanicoDetalle As New List(Of ETCosteoManttoMecanicoDetalle)

    Private _Ls_AreaJefatura As New List(Of ETAreaJefatura)
    Private _Ls_Maestro2 As New List(Of ETMaestos2)
    Private _Ls_Glosa As New List(Of ETGlosa)
    Private _Ls_Sistema As New List(Of ETSistema)

    Private _DataTable1 As New DataTable
    Private _DataTable2 As New DataTable

    Private _Ls_Entregas As List(Of ETEntregas)
    Private _Ls_Anticipo As List(Of ETContratista)
    Private _Ls_Trabajador As List(Of ETEntregas)

    Sub New()
        _Ls_Producto = New List(Of ETProducto)
        _Ls_Activo = New List(Of ETActivo)
        _Ls_Almacen = New List(Of ETAlmacen)
        _Ls_Cliente = New List(Of ETCliente)
        _Ls_Costo = New List(Of ETCosto)
        _Ls_Mineral = New List(Of ETMineral)
        _Ls_Personal = New List(Of ETPersonal)
        _Ls_Proforma = New List(Of ETProforma)
        _Ls_Requerimiento = New List(Of ETRequerimiento)
        _Ls_Ruma = New List(Of ETRuma)
        _Ls_Suministro = New List(Of ETSuministro)
        _Ls_Usuario = New List(Of ETUsuario)
        _Ls_Orden = New List(Of ETOrden)
        _Ls_CanteraCosteo = New List(Of ETCanteraCosteo)
        _Ls_Area = New List(Of ETArea)
        _Ls_AreaEmpleado = New List(Of ETAreaEmpleado)
        _Ls_LineaProduccion = New List(Of ETLineaNegocio)
        _Ls_LineaProduccion_Productos = New List(Of ETLineaNegocio)
        _Ls_LineaProduccion_Proceso = New List(Of ETLineaNegocio)
        _Ls_Periodo = New List(Of ETPeriodo)
        _Ls_Personal_LinProd = New List(Of ETPersonalLineaProduccion)
        _Ls_PeriodoGasNatural = New List(Of ETCosteoActivo)
        _Ls_PeriodoGasNaturalLinProd = New List(Of ETLineaNegocio)
        _Ls_CosteoActivo = New List(Of ETCosteoActivo)
        _Ls_CtaCteContratista = New List(Of ETCuentaCorriente)
        _Ls_CtaCtePersonal = New List(Of ETCuentaCorriente)
        _Ls_PeriodoDetalle = New List(Of ETPeriodoDetalle)
        _Ls_Formulacion_Producto = New List(Of ETRuma)
        _Ls_Formulacion_Suministro = New List(Of ETRuma)
        _Ls_Formulacion_Recirculado = New List(Of ETRuma)

        _Ls_Entregas = New List(Of ETEntregas)
        _Ls_Anticipo = New List(Of ETContratista)
        _Ls_Trabajador = New List(Of ETEntregas)
    End Sub

    Public Property Ls_Entrega() As List(Of ETEntregas)
        Get
            Return _Ls_Entregas
        End Get
        Set(ByVal value As List(Of ETEntregas))
            _Ls_Entregas = value
        End Set
    End Property

    Public Property Ls_Anticipo() As List(Of ETContratista)
        Get
            Return _Ls_Anticipo
        End Get
        Set(ByVal value As List(Of ETContratista))
            _Ls_Anticipo = value
        End Set
    End Property


    Public Property Ls_Trabajador() As List(Of ETEntregas)
        Get
            Return _Ls_Trabajador
        End Get
        Set(ByVal value As List(Of ETEntregas))
            _Ls_Trabajador = value
        End Set
    End Property

    Public Property Ls_Producto() As List(Of ETProducto)
        Get
            Return _Ls_Producto
        End Get
        Set(ByVal value As List(Of ETProducto))
            _Ls_Producto = value
        End Set
    End Property

    Public Property Ls_Activo() As List(Of ETActivo)
        Get
            Return _Ls_Activo
        End Get
        Set(ByVal value As List(Of ETActivo))
            _Ls_Activo = value
        End Set
    End Property

    Public Property Ls_Almacen() As List(Of ETAlmacen)
        Get
            Return _Ls_Almacen
        End Get
        Set(ByVal value As List(Of ETAlmacen))
            _Ls_Almacen = value
        End Set
    End Property

    Public Property Ls_Cliente() As List(Of ETCliente)
        Get
            Return _Ls_Cliente
        End Get
        Set(ByVal value As List(Of ETCliente))
            _Ls_Cliente = value
        End Set
    End Property

    Public Property Ls_Costo() As List(Of ETCosto)
        Get
            Return _Ls_Costo
        End Get
        Set(ByVal value As List(Of ETCosto))
            _Ls_Costo = value
        End Set
    End Property

    Public Property Ls_Mineral() As List(Of ETMineral)
        Get
            Return _Ls_Mineral
        End Get
        Set(ByVal value As List(Of ETMineral))
            _Ls_Mineral = value
        End Set
    End Property

    Public Property Ls_Personal() As List(Of ETPersonal)
        Get
            Return _Ls_Personal
        End Get
        Set(ByVal value As List(Of ETPersonal))
            _Ls_Personal = value
        End Set
    End Property

    Public Property Ls_Proforma() As List(Of ETProforma)
        Get
            Return _Ls_Proforma
        End Get
        Set(ByVal value As List(Of ETProforma))
            _Ls_Proforma = value
        End Set
    End Property

    Public Property Ls_Requerimiento() As List(Of ETRequerimiento)
        Get
            Return _Ls_Requerimiento
        End Get
        Set(ByVal value As List(Of ETRequerimiento))
            _Ls_Requerimiento = value
        End Set
    End Property

    Public Property Ls_Ruma() As List(Of ETRuma)
        Get
            Return _Ls_Ruma
        End Get
        Set(ByVal value As List(Of ETRuma))
            _Ls_Ruma = value
        End Set
    End Property

    Public Property Ls_Suministro() As List(Of ETSuministro)
        Get
            Return _Ls_Suministro
        End Get
        Set(ByVal value As List(Of ETSuministro))
            _Ls_Suministro = value
        End Set
    End Property

    Public Property Ls_Usuario() As List(Of ETUsuario)
        Get
            Return _Ls_Usuario
        End Get
        Set(ByVal value As List(Of ETUsuario))
            _Ls_Usuario = value
        End Set
    End Property

    Public Property Ls_Orden() As List(Of ETOrden)
        Get
            Return _Ls_Orden
        End Get
        Set(ByVal value As List(Of ETOrden))
            _Ls_Orden = value
        End Set
    End Property

    Public Property Ls_CanteraCosteo() As List(Of ETCanteraCosteo)
        Get
            Return _Ls_CanteraCosteo
        End Get
        Set(ByVal value As List(Of ETCanteraCosteo))
            _Ls_CanteraCosteo = value
        End Set
    End Property

    Public Property Ls_Area() As List(Of ETArea)
        Get
            Return _Ls_Area
        End Get
        Set(ByVal value As List(Of ETArea))
            _Ls_Area = value
        End Set
    End Property

    Public Property Ls_AreaEmpleado() As List(Of ETAreaEmpleado)
        Get
            Return _Ls_AreaEmpleado
        End Get
        Set(ByVal value As List(Of ETAreaEmpleado))
            _Ls_AreaEmpleado = value
        End Set
    End Property

    '***********************
    ' SiMan
    Public Property Ls_LinNeg() As List(Of ETLineaNegocio)
        Get
            Return _Ls_LinNeg
        End Get
        Set(ByVal value As List(Of ETLineaNegocio))
            _Ls_LinNeg = value
        End Set
    End Property
    Public Property Ls_UnidadMedida() As List(Of ETUnidadMedida)
        Get
            Return _Ls_UnidadMedida
        End Get
        Set(ByVal value As List(Of ETUnidadMedida))
            _Ls_UnidadMedida = value
        End Set
    End Property

    Public Property Ls_Atributo() As List(Of ETAtributo)
        Get
            Return _Ls_Atributo
        End Get
        Set(ByVal value As List(Of ETAtributo))
            _Ls_Atributo = value
        End Set
    End Property
    Public Property Ls_ParteEquipo() As List(Of ETParteEquipo)
        Get
            Return _Ls_ParteEquipo
        End Get
        Set(ByVal value As List(Of ETParteEquipo))
            _Ls_ParteEquipo = value
        End Set
    End Property
    Public Property Ls_SubParteEquipo() As List(Of ETParteEquipo)
        Get
            Return _Ls_SubParteEquipo
        End Get
        Set(ByVal value As List(Of ETParteEquipo))
            _Ls_SubParteEquipo = value
        End Set
    End Property

    Public Property Ls_FamiliaEquipo() As List(Of ETFamiliaEquipo)
        Get
            Return _Ls_FamiliaEquipo
        End Get
        Set(ByVal value As List(Of ETFamiliaEquipo))
            _Ls_FamiliaEquipo = value
        End Set
    End Property
    Public Property Ls_Equipo() As List(Of ETEquipo)
        Get
            Return _Ls_Equipo
        End Get
        Set(ByVal value As List(Of ETEquipo))
            _Ls_Equipo = value
        End Set
    End Property
    Public Property Ls_CheckList() As List(Of ETCheckList)
        Get
            Return _Ls_CheckList
        End Get
        Set(ByVal value As List(Of ETCheckList))
            _Ls_CheckList = value
        End Set
    End Property
    Public Property Ls_CheckListDet() As List(Of ETCheckListDetalle)
        Get
            Return _Ls_CheckListDet
        End Get
        Set(ByVal value As List(Of ETCheckListDetalle))
            _Ls_CheckListDet = value
        End Set
    End Property
    Public Property Ls_Requerimiento_Mantto() As List(Of ETRequerimiento_Mantto)
        Get
            Return _Ls_Requerimiento_Mantto
        End Get
        Set(ByVal value As List(Of ETRequerimiento_Mantto))
            _Ls_Requerimiento_Mantto = value
        End Set
    End Property
    Public Property Ls_Requerimiento_Det_Mantto() As List(Of ETRequerimiento_ManttoDetalle)
        Get
            Return _Ls_Requerimiento_Det_Mantto
        End Get
        Set(ByVal value As List(Of ETRequerimiento_ManttoDetalle))
            _Ls_Requerimiento_Det_Mantto = value
        End Set
    End Property

    Public Property Ls_Programacion_Mantto() As List(Of ETProgramacionMantto)
        Get
            Return _Ls_Programacion_Mantto
        End Get
        Set(ByVal value As List(Of ETProgramacionMantto))
            _Ls_Programacion_Mantto = value
        End Set
    End Property
    Public Property Ls_Partida_Material() As List(Of ETPartidaMaterial)
        Get
            Return _Ls_Partida_Material
        End Get
        Set(ByVal value As List(Of ETPartidaMaterial))
            _Ls_Partida_Material = value
        End Set
    End Property
    Public Property Ls_Partida_Equipo() As List(Of ETPartidaEquipo)
        Get
            Return _Ls_Partida_Equipo
        End Get
        Set(ByVal value As List(Of ETPartidaEquipo))
            _Ls_Partida_Equipo = value
        End Set
    End Property
    Public Property Ls_Partida_ManoObra() As List(Of ETPartidaManoObra)
        Get
            Return _Ls_Partida_ManoObra
        End Get
        Set(ByVal value As List(Of ETPartidaManoObra))
            _Ls_Partida_ManoObra = value
        End Set
    End Property
    Public Property Ls_Partida_Servicio() As List(Of ETPartidaServicio)
        Get
            Return _Ls_Partida_Servicio
        End Get
        Set(ByVal value As List(Of ETPartidaServicio))
            _Ls_Partida_Servicio = value
        End Set
    End Property
    Public Property Ls_Presupuesto() As List(Of ETPresupuesto)
        Get
            Return _Ls_Presupuesto
        End Get
        Set(ByVal value As List(Of ETPresupuesto))
            _Ls_Presupuesto = value
        End Set
    End Property

    Public Property Ls_Presupuesto_Detalle() As List(Of ETPresupuestoDetalle)
        Get
            Return _Ls_Presupuesto_Detalle
        End Get
        Set(ByVal value As List(Of ETPresupuestoDetalle))
            _Ls_Presupuesto_Detalle = value
        End Set
    End Property
    Public Property Ls_Presupuesto_Material() As List(Of ETPresupuestoMaterial)
        Get
            Return _Ls_Presupuesto_Material
        End Get
        Set(ByVal value As List(Of ETPresupuestoMaterial))
            _Ls_Presupuesto_Material = value
        End Set
    End Property
    Public Property Ls_Presupuesto_Equipo() As List(Of ETPresupuestoEquipo)
        Get
            Return _Ls_Presupuesto_Equipo
        End Get
        Set(ByVal value As List(Of ETPresupuestoEquipo))
            _Ls_Presupuesto_Equipo = value
        End Set
    End Property
    Public Property Ls_Presupuesto_ManoObra() As List(Of ETPresupuestoManoObra)
        Get
            Return _Ls_Presupuesto_ManoObra
        End Get
        Set(ByVal value As List(Of ETPresupuestoManoObra))
            _Ls_Presupuesto_ManoObra = value
        End Set
    End Property
    Public Property Ls_Presupuesto_Servicio() As List(Of ETPresupuestoServicio)
        Get
            Return _Ls_Presupuesto_Servicio
        End Get
        Set(ByVal value As List(Of ETPresupuestoServicio))
            _Ls_Presupuesto_Servicio = value
        End Set
    End Property
    Public Property Ls_Presupuesto_Plan() As List(Of ETPresupuestoPlan)
        Get
            Return _Ls_Presupuesto_Plan
        End Get
        Set(ByVal value As List(Of ETPresupuestoPlan))
            _Ls_Presupuesto_Plan = value
        End Set
    End Property

    Public Property Ls_Presupuesto_Plan_Recurso() As List(Of ETPresupuestoPlanRecursos)
        Get
            Return _Ls_Presupuesto_Plan_Recurso
        End Get
        Set(ByVal value As List(Of ETPresupuestoPlanRecursos))
            _Ls_Presupuesto_Plan_Recurso = value
        End Set
    End Property

    Public Property Ls_Presupuesto_Plan_Recurso_Asignacion() As List(Of ETPresupuestoPlanRecursosAsignacion)
        Get
            Return _Ls_Presupuesto_Plan_Recurso_Asignacion
        End Get
        Set(ByVal value As List(Of ETPresupuestoPlanRecursosAsignacion))
            _Ls_Presupuesto_Plan_Recurso_Asignacion = value
        End Set
    End Property

    Public Property Ls_Orden_Trabajo_Mantto() As List(Of ETOrdenTrabajo_Mantto)
        Get
            Return _Ls_Orden_Trabajo_Mantto
        End Get
        Set(ByVal value As List(Of ETOrdenTrabajo_Mantto))
            _Ls_Orden_Trabajo_Mantto = value
        End Set
    End Property

    Public Property Ls_OrdenTrabajo_Recursos() As List(Of ETOrdenTrabajo_Recursos)
        Get
            Return _Ls_Orden_Trabajo_Recurso
        End Get
        Set(ByVal value As List(Of ETOrdenTrabajo_Recursos))
            _Ls_Orden_Trabajo_Recurso = value
        End Set
    End Property

    Public Property Ls_OrdenTrabajo_RecursosDetalle() As List(Of ETOTRecursoDetalle)
        Get
            Return _Ls_Orden_Trabajo_RecursoDetalle
        End Get
        Set(ByVal value As List(Of ETOTRecursoDetalle))
            _Ls_Orden_Trabajo_RecursoDetalle = value
        End Set
    End Property

    Public Property Ls_TareoOS() As List(Of ETTareoOS)
        Get
            Return _Ls_TareoOS
        End Get
        Set(ByVal value As List(Of ETTareoOS))
            _Ls_TareoOS = value
        End Set
    End Property

    Public Property Ls_CosteoManttoMecanico() As List(Of ETCosteoManttoMecanico)
        Get
            Return _Ls_CosteoManttoMecanico
        End Get
        Set(ByVal value As List(Of ETCosteoManttoMecanico))
            _Ls_CosteoManttoMecanico = value
        End Set
    End Property

    Public Property Ls_CosteoManttoMecanicoDetalle() As List(Of ETCosteoManttoMecanicoDetalle)
        Get
            Return _Ls_CosteoManttoMecanicoDetalle
        End Get
        Set(ByVal value As List(Of ETCosteoManttoMecanicoDetalle))
            _Ls_CosteoManttoMecanicoDetalle = value
        End Set
    End Property

    Public Property Ls_Linea_Produccion() As List(Of ETLineaNegocio)
        Get
            Return _Ls_LineaProduccion
        End Get
        Set(ByVal value As List(Of ETLineaNegocio))
            _Ls_LineaProduccion = value
        End Set
    End Property

    Public Property Ls_LineaProduccion_Productos() As List(Of ETLineaNegocio)
        Get
            Return _Ls_LineaProduccion_Productos
        End Get
        Set(ByVal value As List(Of ETLineaNegocio))
            _Ls_LineaProduccion_Productos = value
        End Set
    End Property

    Public Property Ls_LineaProduccion_Proceso() As List(Of ETLineaNegocio)
        Get
            Return _Ls_LineaProduccion_Proceso
        End Get
        Set(ByVal value As List(Of ETLineaNegocio))
            _Ls_LineaProduccion_Proceso = value
        End Set
    End Property

    Public Property Ls_Periodo() As List(Of ETPeriodo)
        Get
            Return _Ls_Periodo
        End Get
        Set(ByVal value As List(Of ETPeriodo))
            _Ls_Periodo = value
        End Set
    End Property

    Public Property Ls_Personal_LinProd() As List(Of ETPersonalLineaProduccion)
        Get
            Return _Ls_Personal_LinProd
        End Get
        Set(ByVal value As List(Of ETPersonalLineaProduccion))
            _Ls_Personal_LinProd = value
        End Set
    End Property

    Public Property Ls_AreaJefatura() As List(Of ETAreaJefatura)
        Get
            Return _Ls_AreaJefatura
        End Get
        Set(ByVal value As List(Of ETAreaJefatura))
            _Ls_AreaJefatura = value
        End Set
    End Property
    Public Property Ls_Maestro2() As List(Of ETMaestos2)
        Get
            Return _Ls_Maestro2
        End Get
        Set(ByVal value As List(Of ETMaestos2))
            _Ls_Maestro2 = value
        End Set
    End Property

    Public Property Ls_PeriodoGasNatural() As List(Of ETCosteoActivo)
        Get
            Return _Ls_PeriodoGasNatural
        End Get
        Set(ByVal value As List(Of ETCosteoActivo))
            _Ls_PeriodoGasNatural = value
        End Set
    End Property

    Public Property Ls_PeriodoGasNaturalLineaProduccion() As List(Of ETLineaNegocio)
        Get
            Return _Ls_PeriodoGasNaturalLinProd
        End Get
        Set(ByVal value As List(Of ETLineaNegocio))
            _Ls_PeriodoGasNaturalLinProd = value
        End Set
    End Property

    Public Property Ls_CosteoActivo() As List(Of ETCosteoActivo)
        Get
            Return _Ls_CosteoActivo
        End Get
        Set(ByVal value As List(Of ETCosteoActivo))
            _Ls_CosteoActivo = value
        End Set
    End Property

    Public Property Ls_CtaCteContratista() As List(Of ETCuentaCorriente)
        Get
            Return _Ls_CtaCteContratista
        End Get
        Set(ByVal value As List(Of ETCuentaCorriente))
            _Ls_CtaCteContratista = value
        End Set
    End Property

    Public Property Ls_CtaCtePersonal() As List(Of ETCuentaCorriente)
        Get
            Return _Ls_CtaCtePersonal
        End Get
        Set(ByVal value As List(Of ETCuentaCorriente))
            _Ls_CtaCtePersonal = value
        End Set
    End Property


    Public Property Ls_Glosa() As List(Of ETGlosa)
        Get
            Return _Ls_Glosa
        End Get
        Set(ByVal value As List(Of ETGlosa))
            _Ls_Glosa = value
        End Set
    End Property

    Public Property Ls_Sistema() As List(Of ETSistema)
        Get
            Return _Ls_Sistema
        End Get
        Set(ByVal value As List(Of ETSistema))
            _Ls_Sistema = value
        End Set
    End Property

    Public Property Ls_PeriodoDetalle() As List(Of ETPeriodoDetalle)
        Get
            Return _Ls_PeriodoDetalle
        End Get
        Set(ByVal value As List(Of ETPeriodoDetalle))
            _Ls_PeriodoDetalle = value
        End Set
    End Property

    Public Property DataTable1() As DataTable
        Get
            Return _DataTable1
        End Get
        Set(ByVal value As DataTable)
            _DataTable1 = value
        End Set
    End Property

    Public Property DataTable2() As DataTable
        Get
            Return _DataTable2
        End Get
        Set(ByVal value As DataTable)
            _DataTable2 = value
        End Set
    End Property

    Public Property Ls_Formulacion_Producto() As List(Of ETRuma)
        Get
            Return _Ls_Formulacion_Producto
        End Get
        Set(ByVal value As List(Of ETRuma))
            _Ls_Formulacion_Producto = value
        End Set
    End Property

    Public Property Ls_Formulacion_Suministro() As List(Of ETRuma)
        Get
            Return _Ls_Formulacion_Suministro
        End Get
        Set(ByVal value As List(Of ETRuma))
            _Ls_Formulacion_Suministro = value
        End Set
    End Property


    Public Property Ls_Formulacion_Ruma() As List(Of ETRuma)
        Get
            Return _Ls_Formulacion_Ruma
        End Get
        Set(ByVal value As List(Of ETRuma))
            _Ls_Formulacion_Ruma = value
        End Set
    End Property

    Public Property Ls_Formulacion_Recirculado() As List(Of ETRuma)
        Get
            Return _Ls_Formulacion_Recirculado
        End Get
        Set(ByVal value As List(Of ETRuma))
            _Ls_Formulacion_Recirculado = value
        End Set
    End Property

End Class
