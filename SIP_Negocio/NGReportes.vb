Imports SIP_Entidad
Imports SIP_Datos

Public Class NGReportes
    Dim ReportesDAO As New DAReportes

    Public Function ListarProductosAtendidosDetalle(ByVal NumeroGuia As String, ByVal Numero_Doc As String, ByVal Cia As String) As DataSet
        Return ReportesDAO.ListarProductosAtendidosDetalle(NumeroGuia, Numero_Doc, Cia)
    End Function

    Public Function ListarProductosAtendidos(ByVal NumeroGuia As String, ByVal Numero_Doc As String, ByVal Cia As String) As DataSet
        Return ReportesDAO.ListarProductosAtendidos(NumeroGuia, Numero_Doc, Cia)
    End Function

    Public Function ImprimirRequerimiento(ByVal Cia As String, ByVal Requerimiento As String) As DataSet
        Return ReportesDAO.ImprimirRequerimiento(Cia, Requerimiento)
    End Function

    Public Function Suministros_EnvioCantera(ByVal Cia As String, ByVal Inicio As DateTime, ByVal Fin As DateTime, ByVal Opcion As Integer) As DataSet
        Return ReportesDAO.Suministros_EnvioCantera(Cia, Inicio, Fin, Opcion)
    End Function

    Public Function ValidarProforma(ByVal Cia As String, ByVal Proforma As String) As DataSet
        Return ReportesDAO.ValidarProforma(Cia, Proforma)
    End Function

    Public Function Minas_Reporte01(ByVal Cia As String, ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Moneda As String) As DataTable
        Return ReportesDAO.Minas_Reportes01(Cia, Fecha1, Fecha2, Moneda)
    End Function

    Public Function Minas_Reporte02(ByVal Cia As String, ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Moneda As String) As DataTable
        Return ReportesDAO.Minas_Reportes02(Cia, Fecha1, Fecha2, Moneda)
    End Function

    Public Function Minas_Reporte03(ByVal Cia As String, ByVal Año As Integer, ByVal Mes As Short, ByVal TipoInformacion As Short, ByVal Opcion As Short) As DataTable
        Return ReportesDAO.Minas_Reportes03(Cia, Año, Mes, TipoInformacion, Opcion)
    End Function

    Public Function Minas_Reporte04(ByVal Cia As String, ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Moneda As String) As DataTable
        Return ReportesDAO.Minas_Reportes04(Cia, Fecha1, Fecha2, Moneda)
    End Function

    Public Function RptSolicitud(ByVal NumSolicitud As String) As DataSet
        Return ReportesDAO.RptSolicitud(NumSolicitud)
    End Function
    Public Function RptSolicitudPlanilla(ByVal NumSolicitud As String) As DataSet
        Return ReportesDAO.RptSolicitudPlanilla(NumSolicitud)
    End Function

    Public Function RptAnticipo(ByVal NumSolicitud As String) As DataSet
        Return ReportesDAO.RptAnticipo(NumSolicitud)
    End Function

    Public Function RptFactCombustible(ByVal id As Int32) As DataSet
        Return ReportesDAO.RptFactCombustible(id)
    End Function

    Public Function RptLiquidacion(ByVal NumSolicitud As String) As DataSet
        Return ReportesDAO.RptLiquidacion(NumSolicitud)
    End Function
    Public Function RptLiquidacionDet(ByVal NumSolicitud As String) As DataSet
        Return ReportesDAO.RptLiquidacionDet(NumSolicitud)
    End Function
    Public Function RptRegCompras(ByVal NumSolicitud As String) As DataSet
        Return ReportesDAO.RptRegCompras(NumSolicitud)
    End Function

    Public Function RptCancelaAnt(ByVal ayo As Int32, ByVal mes As Int32, ByVal cgvoucher As String, ByVal voucherconta As String, ByVal usuario As String) As DataSet
        Return ReportesDAO.RptCancelaAnt(ayo, mes, cgvoucher, voucherconta, usuario)
    End Function

    Public Function RptProductoNC(ByVal cod_alm As String, ByVal fechaini As DateTime, ByVal fechafin As DateTime, ByVal movi As String) As DataSet
        Return ReportesDAO.RptProductoNC(cod_alm, fechaini, fechafin, movi)
    End Function

    Public Function RptPedidoSuministro(ByVal id As Int32) As DataSet
        Return ReportesDAO.RptPedidoSuministro(id)
    End Function

    Public Function RptRegCompras_Prov(ByVal NumSolicitud As String) As DataSet
        Return ReportesDAO.RptRegCompras_Prov(NumSolicitud)
    End Function
    Public Function RptLiquidacionReintegro(ByVal NumSolicitud As String) As DataSet
        Return ReportesDAO.RptLiquidacionReintegro(NumSolicitud)
    End Function
    Public Function RptLiquidacionPend(ByVal NumSolicitud As String) As DataSet
        Return ReportesDAO.RptLiquidacionPend(NumSolicitud)
    End Function
    Public Function RptLiquidacionCopia(ByVal NumSolicitud As String, ByVal contable As String) As DataSet
        Return ReportesDAO.RptLiquidacionCopia(NumSolicitud, contable)
    End Function
    Public Function RptLiquidacionPendCopia(ByVal NumSolicitud As String) As DataSet
        Return ReportesDAO.RptLiquidacionPendCopia(NumSolicitud)
    End Function
    Public Function RptAsientoEntreas(ByVal voucherconta As String, ByVal cgvoucher As String, ByVal año As String, ByVal mes As String) As DataSet
        Return ReportesDAO.RptAsientoEntreas(voucherconta, cgvoucher, año, mes)
    End Function
    Public Function RptAsientoEntreasPend(ByVal voucherconta As String, ByVal cgvoucher As String, ByVal año As String, ByVal mes As String) As DataSet
        Return ReportesDAO.RptAsientoEntreas(voucherconta, cgvoucher, año, mes)
    End Function
    Public Function RptAsientoProvision(ByVal voucherconta As String, ByVal cgvoucher As String, ByVal año As String, ByVal mes As String) As DataSet
        Return ReportesDAO.RptAsientoProvision(voucherconta, cgvoucher, año, mes)
    End Function
End Class
