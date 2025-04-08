Imports SIP_Entidad
Imports SIP_Datos
Public Class NGContratista
    Public Function ListarContratista(ByVal pCod_Cia As String) As DataTable
        Try
            Return Datos.Contratistas.ListarContratista(pCod_Cia)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarContratistaConsulta(ByVal pCod_Cia As String, ByVal tipo As String) As DataTable
        Try
            Return Datos.Contratistas.ListarContratistaConsulta(pCod_Cia, tipo)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarFrecuencia(ByVal pCod_Cia As String) As DataTable
        Try
            Return Datos.Contratistas.ListarFrecuencia(pCod_Cia)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ActualizaContratista(ByVal obj As ETContratista) As Int32
        Try
            Return Datos.Contratistas.ActualizaContratista(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function ListarCantera(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarCantera(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarSupervisor_Contratista(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarSupervisor_Contratista(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarAfp(ByVal pCod_Cia As String) As DataTable
        Try
            Return Datos.Contratistas.ListarAfp(pCod_Cia)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarTipodoc(ByVal pCod_Cia As String) As DataTable
        Try
            Return Datos.Contratistas.ListarTipodoc(pCod_Cia)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function FechaSemana(ByVal obj As ETContratista) As DataSet
        Try
            Return Datos.Contratistas.FechaSemana(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mant_Planilla(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Mant_Planilla(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarPlanilla(ByVal pCod_Cia As String, ByVal cod_prov As String) As DataTable
        Try
            Return Datos.Contratistas.ListarPlanilla(pCod_Cia, cod_prov)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarPlanillaTrabajador(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarPlanillaTrabajador(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarMineralContratista(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarMineralContratista(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarBanco() As DataTable
        Try
            Return Datos.Contratistas.ListarBanco()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mant_Conceptos(ByVal obj As ETContratista) As Int32
        Try
            Return Datos.Contratistas.Mant_Conceptos(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listarconceptos(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Listarconceptos(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarIQBFkardex() As DataTable
        Try
            Return Datos.Contratistas.ListarIQBFkardex()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarValidaProduccion(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarValidaProduccion(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function ListarValidaVTAProduccion(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarValidaVTAProduccion(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MantValidaProduccion(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.MantValidaProduccion(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RegistrarModificarObsProduccion(ByVal obj As ETContratista) As Int32
        Try
            Return Datos.Contratistas.RegistrarModificarObsProduccion(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function


    Public Function MantValidaVTAProduccion(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.MantValidaVTAProduccion(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarIQBFRPTkardex(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarIQBFRPTkardex(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarIQBFkardexMov(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarIQBFkardexMov(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function


    Public Function IngresoIQBFkardex(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.IngresoIQBFkardex(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listarconceptos_Fact(ByVal idfactura As Int32) As DataTable
        Try
            Return Datos.Contratistas.Listarconceptos_Fact(idfactura)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mantconceptos_Fact_Cab(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Mantconceptos_Fact_Cab(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mantconceptos_Fact_Det(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Mantconceptos_Fact_Det(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarPrecioMineral() As DataTable
        Try
            Return Datos.Contratistas.ListarPrecioMineral()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarConceptoFact() As DataTable
        Try
            Return Datos.Contratistas.ListarConceptoFact()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mant_PrecioMineral(ByVal obj As ETContratista) As Int32
        Try
            Return Datos.Contratistas.Mant_PrecioMineral(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mant_ConceptoFact(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Mant_ConceptoFact(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function IngresoMineralFecha(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.IngresoMineralFecha(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarImpuestos(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarImpuestos(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function ListarSaldoImpuestos(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarSaldoImpuestos(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarSaldoImpuestosAnticipo(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarSaldoImpuestosAnticipo(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MantSuspension(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.MantSuspension(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MantRetencionRH(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.MantRetencionRH(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MantFechaViatico(ByVal obj As ETContratista) As Int32
        Try
            Return Datos.Contratistas.MantFechaViatico(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MantReciboRH(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.MantReciboRH(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ImportarPlanilla(ByVal obj As ETContratista) As Int32
        Try
            Return Datos.Contratistas.ImportarPlanilla(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarSeteoExcel() As DataTable
        Try
            Return Datos.Contratistas.ListarSeteoExcel()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function IngresoPlanillaFecha(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.IngresoPlanillaFecha(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListaPlanillaFechaContratisa(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListaPlanillaFechaContratisa(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarBeneficiarioDni(ByVal Rpt As ETContratista) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Contratistas.ListarBeneficiarioDni(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Private Shared ListaAnticipo As List(Of ETContratista)
    Public Function MantenimientoAnticipo(ByVal Rpt As ETContratista, ByVal Ls_Anticipo As List(Of ETContratista), ByVal Ls_AnticipoDetalle As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing OrElse Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else

            lResult = Datos.Contratistas.MantenimientoAnticipo(Rpt, ListaAnticipo, Ls_AnticipoDetalle)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            If Rpt.TipoOperacion = 1 Then
                MsgBox("Se Registró Correctamente la Solicitud N° " & numSolicitud, MsgBoxStyle.Information, msgComacsa)
            Else
                MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            End If
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function

    Public Function EliminarAnticipo(ByVal Rpt As ETContratista, ByVal Ls_Anticipo As List(Of ETContratista), ByVal Ls_AnticipoDetalle As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing OrElse Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo
        If MsgBox("¿Seguro desea eliminar solicitud de anticipo?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else

            lResult = Datos.Contratistas.MantenimientoAnticipo(Rpt, ListaAnticipo, Ls_AnticipoDetalle)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud

            MsgBox("Se eliminó correctamente", MsgBoxStyle.Information, msgComacsa)
            
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function

    Public Function ListarMonedas() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Contratistas.ListarMonedas

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarAnticipos(ByVal Rpt As ETContratista) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Contratistas.ListarAnticipos(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function SolicitudAnticipoxNumero(ByVal Rpt As ETContratista) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Contratistas.SolicitudAnticipoxNumero(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function InsertaMineralAnticipo(ByVal Ls_Anticipo As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo

        lResult = Datos.Contratistas.InsertaMineralAnticipo(ListaAnticipo)

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function

    Public Function ListarMineralAniticipo(ByVal numsolicitud As String) As DataTable
        Try
            Return Datos.Contratistas.ListarMineralAniticipo(numsolicitud)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarCTR_Factura() As DataTable
        Try
            Return Datos.Contratistas.ListarCTR_Factura()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function validaPeriodo(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.validaPeriodo(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function validaPeriodoPlanilla(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.validaPeriodoPlanilla(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function InsertaPlanillaAnticipo(ByVal Ls_Anticipo As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo

        lResult = Datos.Contratistas.InsertaPlanillaAnticipo(ListaAnticipo)

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function

    Public Function ListarPlanillaAniticipo(ByVal numsolicitud As String) As DataTable
        Try
            Return Datos.Contratistas.ListarPlanillaAniticipo(numsolicitud)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function billeteExistente(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.billeteExistente(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarObligaciones(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarObligaciones(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function detalleObligaciones(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.detalleObligaciones(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ImportarGratiCts(ByVal obj As ETContratista) As Int32
        Try
            Return Datos.Contratistas.ImportarGratiCts(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function IngresoGratiCtsFecha(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.IngresoGratiCtsFecha(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function InsertaGratiCtsAnticipo(ByVal Ls_Anticipo As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo

        lResult = Datos.Contratistas.InsertaGratiCtsAnticipo(ListaAnticipo)

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function

    Public Function ListarGratificacionAniticipo(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarGratificacionAniticipo(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function EliminaPlanillaPeriodo(ByVal obj As ETContratista) As Int32
        Try
            Return Datos.Contratistas.EliminaPlanillaPeriodo(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function UsuarioAprobacion(ByVal Rpt As ETContratista) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Contratistas.UsuarioAprobacion(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function InsertaImpuestoAnticipo(ByVal Ls_Anticipo As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo

        lResult = Datos.Contratistas.InsertaImpuestoAnticipo(ListaAnticipo)

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function

    Public Function CargarImpuestoAnticipo(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CargarImpuestoAnticipo(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function InsertaObligacionAnticipo(ByVal Ls_Anticipo As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo

        lResult = Datos.Contratistas.InsertaObligacionAnticipo(ListaAnticipo)

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function

    Public Function CargarObligacionAnticipo(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CargarObligacionAnticipo(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function InsertaSaldoUtilizado(ByVal Ls_Anticipo As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo

        lResult = Datos.Contratistas.InsertaSaldoUtilizado(ListaAnticipo)

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function

    Public Function ListarTrabajadorContratista(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarTrabajadorContratista(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Verifica_Trabajador_Liquidacion(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Verifica_Trabajador_Liquidacion(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function InsertaVacacionesAnticipo(ByVal Ls_Anticipo As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo

        lResult = Datos.Contratistas.InsertaVacacionesAnticipo(ListaAnticipo)

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function

    Public Function CargarVacacionesAnticipo(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CargarVacacionesAnticipo(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarConceptoLiquidacion(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarConceptoLiquidacion(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function InsertaLiquidacionTrabajador(ByVal Ls_Anticipo As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo

        lResult = Datos.Contratistas.InsertaLiquidacionTrabajador(ListaAnticipo)

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function

    Public Function validaPeriodoVacaciones(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.validaPeriodoVacaciones(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarOrden(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarOrden(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarCanteraAnticipo(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarCanteraAnticipo(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarRetencionSolicitud(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarRetencionSolicitud(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarRetencionxValidar(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarRetencionxValidar(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ValidarRetencionSolicitud(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ValidarRetencionSolicitud(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function InsertaCanteraAnticipo(ByVal Ls_Anticipo As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo

        lResult = Datos.Contratistas.InsertaCanteraAnticipo(ListaAnticipo)

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function
    Public Function CargarCanteraAnticipo(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CargarCanteraAnticipo(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MantenimientoOtraFactura(ByVal Ls_Anticipo As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Anticipo Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        ListaAnticipo = Ls_Anticipo
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else

            lResult = Datos.Contratistas.MantenimientoOtraFactura(ListaAnticipo)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
            lResult.NumSolicitud = numSolicitud
        End If

        Return lResult

    End Function

    Public Function ListarOtraFactura(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarOtraFactura(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function EliminaOtraFactura(ByVal obj As ETContratista) As ETContratista

        Dim lResult As ETContratista = Nothing
        'If Ls_Anticipo Is Nothing Then
        '    Return lResult
        'End If
        lResult = New ETContratista

Operacion:
        ListaAnticipo = New List(Of ETContratista)
        'ListaAnticipo = Ls_Anticipo
        If MsgBox("¿Seguro desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else

            lResult = Datos.Contratistas.EliminaOtraFactura(obj)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            MsgBox("Se eliminó correctamente el registro", MsgBoxStyle.Information, msgComacsa)
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function MantenimientoAlmacen(ByVal Rpt As ETContratista) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        Dim msg As String
        If Rpt.TipoOperacion = 3 Then
            msg = "¿Seguro desea eliminar registro?"
        Else
            msg = "¿Seguro desea Guardar los cambios?"
        End If
        If MsgBox(msg, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else

            lResult = Datos.Contratistas.MantenimientoAlmacen(Rpt)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            If Rpt.TipoOperacion = 3 Then
                MsgBox("Se Eliminó Correctamente el Registro", MsgBoxStyle.Information, msgComacsa)
            Else
                MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            End If
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function
    Public Function ListarAlmacen() As DataTable
        Try
            Return Datos.Contratistas.ListarAlmacen()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function ListarActivoContratista(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarActivoContratista(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mant_ActivoContratista(ByVal Rpt As ETContratista) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        'Dim msg As String
        'If Rpt.TipoOperacion = 3 Then
        '    msg = "¿Seguro desea eliminar registro?"
        'Else
        '    msg = "¿Seguro desea Guardar los cambios?"
        'End If
        'If MsgBox(msg, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '    Return lResult
        'Else

        lResult = Datos.Contratistas.Mant_ActivoContratista(Rpt)
        'End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            'If Rpt.TipoOperacion = 3 Then
            '    MsgBox("Se Eliminó Correctamente el Registro", MsgBoxStyle.Information, msgComacsa)
            'Else
            '    MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            'End If
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function VerificaActivoContratistaMes(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.VerificaActivoContratistaMes(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function AperturaActivoContratistaMes(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.AperturaActivoContratistaMes(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MantenimientoTipoMovimiento(ByVal Rpt As ETContratista) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        Dim msg As String
        If Rpt.TipoOperacion = 3 Then
            msg = "¿Seguro desea eliminar registro?"
        Else
            msg = "¿Seguro desea Guardar los cambios?"
        End If
        If MsgBox(msg, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else

            lResult = Datos.Contratistas.MantenimientoTipoMovimiento(Rpt)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            If Rpt.TipoOperacion = 3 Then
                MsgBox("Se Eliminó Correctamente el Registro", MsgBoxStyle.Information, msgComacsa)
            Else
                MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            End If
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ListarTipoMovimiento() As DataTable
        Try
            Return Datos.Contratistas.ListarTipoMovimiento()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Listar_TipoMovimiento() As DataTable
        Try
            Return Datos.Contratistas.Listar_TipoMovimiento()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function TipoMovimientoConcepto(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.TipoMovimientoConcepto(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function ListarCliente() As DataTable
        Try
            Return Datos.Contratistas.ListarCliente()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarMaquina() As DataTable
        Try
            Return Datos.Contratistas.ListarMaquina()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarEquipo() As DataTable
        Try
            Return Datos.Contratistas.ListarEquipo()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mant_MovimientoCombExplosivo(ByVal Rpt As ETContratista, ByVal dtDetalle As DataTable) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        'Dim msg As String
        'If Rpt.TipoOperacion = 3 Then
        '    msg = "¿Seguro desea eliminar registro?"
        'Else
        '    msg = "¿Seguro desea Guardar los cambios?"
        'End If
        'If MsgBox(msg, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '    Return lResult
        'Else

        lResult = Datos.Contratistas.Mant_MovimientoCombExplosivo(Rpt, dtDetalle)
        'End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            'If Rpt.TipoOperacion = 3 Then
            '    MsgBox("Se Eliminó Correctamente el Registro", MsgBoxStyle.Information, msgComacsa)
            'Else
            '    MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            'End If
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function
    Public Function ListarMovimientos(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarMovimientos(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarProdOptima(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarProdOptima(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MantProdOptima(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.MantProdOptima(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CE_ListarOrden(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CE_ListarOrden(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function CE_DetalleOrden(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CE_DetalleOrden(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CARGA_ENERGIA_ELECTRICA(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CARGA_ENERGIA_ELECTRICA(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CARGA_ENERGIA_ELECTRICA_MENSUAL(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CARGA_ENERGIA_ELECTRICA_MENSUAL(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CTR_INSERTA_CTAPAGKARDEX(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CTR_INSERTA_CTAPAGKARDEX(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CTR_ANT_NUMERO_VOUCHER(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CTR_ANT_NUMERO_VOUCHER(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CTR_ANT_GENERA_ASIENTO(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CTR_ANT_GENERA_ASIENTO(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTA_ENERGIA_ELECTRICA(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.LISTA_ENERGIA_ELECTRICA(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarMovimientoNumero(ByVal obj As ETContratista) As DataSet
        Try
            Return Datos.Contratistas.ListarMovimientoNumero(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function BuscaTipoEquipo(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.BuscaTipoEquipo(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Carga_Movimiento(ByVal Rpt As ETContratista, ByVal dtDetalle As DataTable) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:

        lResult = Datos.Contratistas.Carga_Movimiento(Rpt, dtDetalle)

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            'If Rpt.TipoOperacion = 3 Then
            '    MsgBox("Se Eliminó Correctamente el Registro", MsgBoxStyle.Information, msgComacsa)
            'Else
            '    MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            'End If
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function Reg_Alquiler_Maquina(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Reg_Alquiler_Maquina(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Reg_Alquiler_Maquina_Det(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Reg_Alquiler_Maquina_Det(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ValidaCarga(ByVal obj As ETContratista) As String
        Try
            Return Datos.Contratistas.ValidaCarga(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Elimina_Carga_Movimiento(ByVal Rpt As ETContratista) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:
        lResult = Datos.Contratistas.Elimina_Carga_Movimiento(Rpt)
Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function
    Public Function ListarCargas(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarCargas(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CTR_ListarCombustible(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CTR_ListarCombustible(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTA_CE_FACT_COMBUSTIBLE_CAB(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.LISTA_CE_FACT_COMBUSTIBLE_CAB(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CTR_CE_FACT_COMBUSTIBLE_CAB(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CTR_CE_FACT_COMBUSTIBLE_CAB(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CTR_CE_FACT_COMBUSTIBLE_DET(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.CTR_CE_FACT_COMBUSTIBLE_DET(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarEquipoCantera(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarEquipoCantera(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function InsertaEquipoCantera(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.InsertaEquipoCantera(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function EliminaEquipoCantera(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.EliminaEquipoCantera(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarFacturaAlquiler(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarFacturaAlquiler(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarFacturaAlquiler_ID(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarFacturaAlquiler_ID(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function user_Aprueba_Alquiler(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.user_Aprueba_Alquiler(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarRegistroAlquiler(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarRegistroAlquiler(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarRegistroAlquiler_Det(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarRegistroAlquiler_Det(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Kardex(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Kardex(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Existencias(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Existencias(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function ValidaFechasCarga(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ValidaFechasCarga(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function MaqPesada(ByVal Rpt As ETContratista) As DataSet
        Try
            Return Datos.Contratistas.MaqPesada(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function ListarDocumentoAprobar(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ListarDocumentoAprobar(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarClientes() As DataTable
        Try
            Return Datos.Contratistas.ListarClientes()

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarClientesPareto(_parameter As Integer) As DataTable
        Try
            Return Datos.Contratistas.ListarClientesPareto(_parameter)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ApruebaDocumento(ByVal Rpt As ETContratista, ByVal dtDetalle As DataTable) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETContratista

Operacion:

        lResult = Datos.Contratistas.ApruebaDocumento(Rpt, dtDetalle)

Salida:

        If lResult Is Nothing Then
            lResult = New ETContratista
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            'If Rpt.TipoOperacion = 3 Then
            '    MsgBox("Se Eliminó Correctamente el Registro", MsgBoxStyle.Information, msgComacsa)
            'Else
            '    MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            'End If
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ValidaProduto(ByVal codprod As String) As DataTable
        Try
            Return Datos.Contratistas.ValidaProduto(codprod)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ConsultaContratista(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ConsultaContratista(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RptVacaciones_CTR(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.RptVacaciones_CTR(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RptExMedico_CTR(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.RptExMedico_CTR(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RptIgvRenta_CTR(ByVal Rpt As ETContratista) As DataSet
        Try
            Return Datos.Contratistas.RptIgvRenta_CTR(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RptLiquidaciones_CTR(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.RptLiquidaciones_CTR(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_PRO_Camiones(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Listar_PRO_Camiones(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_PRO_Prov_Codigo(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Listar_PRO_Prov_Codigo(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_PRO_MantCamion(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Listar_PRO_MantCamion(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_PRO_MantDisponibilidad(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Listar_PRO_MantDisponibilidad(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_PRO_Disponibilidad(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Listar_PRO_Disponibilidad(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_PRO_CamionDisponible(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Listar_PRO_CamionDisponible(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Elimina_Programacion(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Elimina_Programacion(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CargaUnacem(ByVal dtDatos As DataTable, ByVal usuario As String, ByVal ayo As String) As DataTable
        Try
            Return Datos.Contratistas.CargaUnacem(dtDatos, usuario, ayo)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CargaBilletesPrev(ByVal dtDatos As DataTable, ByVal usuario As String, ByVal ayo As String, ByVal cod_alm As String, ByVal transferencia As Integer, ByVal cod_alm_ori As String) As DataTable
        Try
            Return Datos.Contratistas.CargaBilletesPrev(dtDatos, usuario, ayo, cod_alm, transferencia, cod_alm_ori)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListaCargaUnacem(ByVal obj As ETContratista) As DataSet
        Try
            Return Datos.Contratistas.ListaCargaUnacem(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListaCargaBilletePrev(ByVal obj As ETContratista) As DataSet
        Try
            Return Datos.Contratistas.ListaCargaBilletePrev(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ValidaCargaUnacem(ByVal obj As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.ValidaCargaUnacem(obj)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Registra_Programacion(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Registra_Programacion(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_PRO_Programacion(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Listar_PRO_Programacion(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Listar_PRO_ConfigVehicular() As List(Of ETConfigVehicular)
        Try
            Return Datos.Contratistas.Listar_PRO_ConfigVehicular()
        Catch ex As Exception
            Throw New Exception
        End Try
    End Function
    Public Function Listar_PRO_ProgramacionCamion(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Listar_PRO_ProgramacionCamion(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_PRO_ConsultaProgramacion(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Listar_PRO_ConsultaProgramacion(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_PRO_Prod_Programacion(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Listar_PRO_Prod_Programacion(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Consulta_GuiaProgramacion(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Consulta_GuiaProgramacion(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Consulta_GuiaProgramacion2(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Consulta_GuiaProgramacion2(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Consulta_GuiaProgramacionV2(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Consulta_GuiaProgramacionV2(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Reprogramacion_Pedido(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Reprogramacion_Pedido(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Actualiza_Placa_Prog(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Actualiza_Placa_Prog(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function llenar_Incidencia(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.llenar_Incidencia(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function llenar_Concepto(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.llenar_Concepto(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Registra_Incidencia(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Registra_Incidencia(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Consulta_Incidencia(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Consulta_Incidencia(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Elimina_Incidencia(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Elimina_Incidencia(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mant_Concepto_Prog(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Mant_Concepto_Prog(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Mant_Incidencia_Prog(ByVal Rpt As ETContratista) As DataTable
        Try
            Return Datos.Contratistas.Mant_Incidencia_Prog(Rpt)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function ConsultarConsumoRecursos(ByVal P As ETContratista) As DataTable
        Return Datos.Contratistas.ConsultarConsumoRecursos(P)
    End Function
    Public Function ConsultarLecturaDrone(ByVal P As ETContratista) As DataTable
        Return Datos.Contratistas.ConsultarLecturaDrone(P)
    End Function

End Class

