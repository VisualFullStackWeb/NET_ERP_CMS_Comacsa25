Imports SIP_Entidad
Imports SIP_Datos

Public Class NGProveedorFiscalizado
    Public Sub Insertar_ProveedorFiscalizado(ByVal C As ETProveedorFiscalizado)
        Try
            Datos.ProveedorFiscalizado.Insertar_ProveedorFiscalizado(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Sub

    Public Function Listar_ProveedorFiscalizado(ByVal pCod_Cia As String) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.Listar_ProveedorFiscalizado(pCod_Cia)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mostrar_ProveedorFiscalizado_X_Cod_Prov(ByVal pCod_Cia As String, ByVal pCod_Prov As String) As ETProveedorFiscalizado
        Try
            Return Datos.ProveedorFiscalizado.Mostrar_ProveedorFiscalizado_X_Cod_Prov(pCod_Cia, pCod_Prov)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Actualizar_ProveedorFiscalizado(ByVal C As ETProveedorFiscalizado) As Integer
        Try
            Return Datos.ProveedorFiscalizado.Actualizar_ProveedorFiscalizado(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Anular_ProveedorFiscalizado(ByVal C As ETProveedorFiscalizado) As Integer
        Try
            Return Datos.ProveedorFiscalizado.Anular_ProveedorFiscalizado(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mostrar_Proveedor_X_Cod_Prov(ByVal pCod_Cia As String, ByVal pCod_Prov As String) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.Mostrar_Proveedor_X_Cod_Prov(pCod_Cia, pCod_Prov)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_Proveedores_Fiscalizar(ByVal pCod_Cia As String) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.Listar_Proveedores_Fiscalizar(pCod_Cia)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function DatosIngresoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function DatosEliminaIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.DatosEliminaIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function PresentacionIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.PresentacionIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function IngresaIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.IngresaIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function DatosEgresoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.DatosEgresoIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function DatosProduccionIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.DatosProduccionIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function DatosUsoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.DatosUsoIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function PedidoSuministro(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.PedidoSuministro(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function EnviarCorreoSolicitud(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.EnviarCorreoSolicitud(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function SolicitudPlanilla(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.SolicitudPlanilla(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function PedidoSuministro_Det(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.PedidoSuministro_Det(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function SolicitudPlanilla_Det(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.SolicitudPlanilla_Det(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function DatosGeneralIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.DatosGeneralIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function DatosUsoBarbotinaIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.DatosUsoBarbotinaIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function DatosUsoLaboratorio(ByVal C As ETProveedorFiscalizado, ByVal Ls_Datos As List(Of ETProveedorFiscalizado)) As Integer
        Try
            Return Datos.ProveedorFiscalizado.DatosUsoLaboratorio(C, Ls_Datos)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function DatosSadosIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.DatosSadosIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function HtnrxPResentacion(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.HtnrxPResentacion(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function HtnrEquipos(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.HtnrEquipos(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function


    Public Function DatosIngresoMineral(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.DatosIngresoMineral(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function DatosVentaMineral(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.DatosVentaMineral(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function DatosMorosidad(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.DatosMorosidad(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function DatosMorosidadAp(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.DatosMorosidadAp(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function DatosAjustesEnt(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.DatosAjustesEnt(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function AjustesDifCambio(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.AjustesDifCambio(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarReintegros(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.ListarReintegros(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarPendLiquidacion(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.ListarPendLiquidacion(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarAplicaciones(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.ListarAplicaciones(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function AplicaReintegros(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.AplicaReintegros(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function QuitarAplicacion(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.QuitarAplicacion(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ReporteViaticos(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ReporteViaticos(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ReporteSinSustento(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ReporteSinSustento(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ReporteRH(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.ReporteRH(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MineralFlete(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.MineralFlete(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ReporteLimiteRH(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.ReporteLimiteRH(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ReporteRH_Resumen(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.ReporteRH_Resumen(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListadoProvisiones(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ListadoProvisiones(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function


    Public Function ReporteDetalleViaticos(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ReporteDetalleViaticos(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ConsultaRecibos(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ConsultaRecibos(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ConsultaDocumentosAprobados(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ConsultaDocumentosAprobados(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ConsultaCTRAplicaciones(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ConsultaCTRAplicaciones(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ConsultaCTRListaAnticipo(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ConsultaCTRListaAnticipo(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ConsultaCTRListaDocumento(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ConsultaCTRListaDocumento(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function SolicitudAprobada(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.SolicitudAprobada(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function ReporteRendimiento(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ReporteRendimiento(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function ReporteProyeccionVentaRuma(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ReporteProyeccionVentaRuma(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INSERTA_USOBARBOTINA(ByVal C As ETProveedorFiscalizado) As Integer
        Try
            Return Datos.ProveedorFiscalizado.INSERTA_USOBARBOTINA(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function TipoguiaSunat() As DataTable
        Try
            Return Datos.ProveedorFiscalizado.TipoguiaSunat()
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function VerificaCierreIqbf(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.VerificaCierreIqbf(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RptIngresoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.RptIngresoIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RptInventarioIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.RptInventarioIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RptEgresoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.RptEgresoIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RptProduccionIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.RptProduccionIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RptUsoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.RptUsoIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function


    Public Function RptGeneralIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.RptGeneralIQBF(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function VerificaUserCierre(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.VerificaUserCierre(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ReporteDAC(ByVal C As ETProveedorFiscalizado) As DataSet
        Try
            Return Datos.ProveedorFiscalizado.ReporteDAC(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ConsultaUsuariosDocumentos(ByVal C As ETProveedorFiscalizado) As DataTable
        Try
            Return Datos.ProveedorFiscalizado.ConsultaUsuariosDocumentos(C)
            'Datos.ProveedorFiscalizado.DatosIngresoIQBF(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
End Class

