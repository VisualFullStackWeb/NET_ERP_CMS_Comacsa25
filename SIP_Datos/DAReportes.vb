Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Exception
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class DAReportes

#Region "Reporte de Salida x Orden"
    Public Function ListarProductosAtendidosDetalle(ByVal NumeroGuia As String, ByVal NumeroDoc As String, ByVal Cia As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.SalidaOrden)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Numero_Documento", DbType.String, NumeroDoc)
            db.AddInParameter(cmd, "Numero_Guia", DbType.String, NumeroGuia)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)


            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            ListarProductosAtendidosDetalle = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Reporte de Productos Atendidos"
    Public Function ListarProductosAtendidos(ByVal NumeroGuia As String, ByVal NumeroDoc As String, ByVal Cia As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.AtencionProductos)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Numero_Documento", DbType.String, NumeroDoc)
            db.AddInParameter(cmd, "Numero_Guia", DbType.String, NumeroGuia)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)


            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            ListarProductosAtendidos = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Reporte Requerimiento"
    Public Function ImprimirRequerimiento(ByVal Cia As String, ByVal Requerimiento As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ImprimirRequerimiento)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "NroReq", DbType.String, Requerimiento)
            db.AddInParameter(cmd, "CodCia", DbType.String, Cia)


            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            ImprimirRequerimiento = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Reporte Suministros Envio Cantera y Vida Útil"
    Public Function Suministros_EnvioCantera(ByVal Cia As String, ByVal Inicio As DateTime, ByVal Fin As DateTime, ByVal Opcion As Integer) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.EnvioCantera_VidaUtil)
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, Opcion)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Inicio)
            db.AddInParameter(cmd, "FechaFin", DbType.DateTime, Fin)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Suministros_EnvioCantera = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Validar Cotizacion"

    Public Function ValidarProforma(ByVal Cia As String, ByVal Proforma As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ValidarProforma)
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)
            db.AddInParameter(cmd, "Proforma", DbType.String, Proforma)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            ValidarProforma = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


#Region "Reportes Minas"
    Public Function Minas_Reportes01(ByVal Cia As String, ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Moneda As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand
        If Fecha1 >= "01/01/2016" Then
            cmd = db.GetStoredProcCommand(usp_RAL.CE_Reporte01)
        Else
            cmd = db.GetStoredProcCommand(usp_RAL.Reporte01)
        End If
        'Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Reporte01)
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "cod_cia", DbType.String, Cia)
            db.AddInParameter(cmd, "FechaInicio", DbType.Date, Fecha1)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Fecha2)
            db.AddInParameter(cmd, "Moneda", DbType.String, Moneda)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Minas_Reportes01 = Ds.Tables(0)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Minas_Reportes02(ByVal Cia As String, ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Moneda As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand
        If Fecha1 >= "01/01/2016" Then
            cmd = db.GetStoredProcCommand(usp_RAL.CE_Reporte02)
        Else
            cmd = db.GetStoredProcCommand(usp_RAL.Reporte02)
        End If
        cmd.CommandTimeout = 0
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "cod_cia", DbType.String, Cia)
            db.AddInParameter(cmd, "FechaInicio", DbType.Date, Fecha1)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Fecha2)
            db.AddInParameter(cmd, "Moneda", DbType.String, Moneda)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Minas_Reportes02 = Ds.Tables(0)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Minas_Reportes03(ByVal Cia As String, ByVal Año As Integer, ByVal Mes As Short, ByVal TipoInformacion As Short, ByVal Opcion As Short) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Reporte03)
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)
            db.AddInParameter(cmd, "Informacion", DbType.Int16, TipoInformacion)
            db.AddInParameter(cmd, "Ano", DbType.Int32, Año)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Mes)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Minas_Reportes03 = Ds.Tables(0)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Minas_Reportes04(ByVal Cia As String, ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Moneda As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand
        If Fecha1 >= "01/01/2016" Then
            cmd = db.GetStoredProcCommand(usp_RAL.CE_Reporte04)
        Else
            cmd = db.GetStoredProcCommand(usp_RAL.Reporte04)
        End If
        cmd.CommandTimeout = 0
        'Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Reporte04)
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "cod_cia", DbType.String, Cia)
            db.AddInParameter(cmd, "FechaInicio", DbType.Date, Fecha1)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Fecha2)
            db.AddInParameter(cmd, "Moneda", DbType.String, Moneda)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Minas_Reportes04 = Ds.Tables(0)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Reporte de Entregas x Rendir"
    Public Function RptSolicitudPlanilla(ByVal NumSolicitud As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptSolicitudPlanilla)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, NumSolicitud)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptSolicitudPlanilla = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    Public Function RptSolicitud(ByVal NumSolicitud As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptSolicitud)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, NumSolicitud)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptSolicitud = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptLiquidacion(ByVal NumSolicitud As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptLiquidacion)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, NumSolicitud)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptLiquidacion = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptLiquidacionDet(ByVal NumSolicitud As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptLiquidacionDet)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, NumSolicitud)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptLiquidacionDet = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptRegCompras(ByVal NumSolicitud As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptRegCompras)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, NumSolicitud)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptRegCompras = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptCancelaAnt(ByVal ayo As Int32, ByVal mes As Int32, ByVal cgvoucher As String, ByVal voucherconta As String, ByVal usuario As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptCancelaAnt)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, mes)
            db.AddInParameter(cmd, "@CGVOUCHER", DbType.String, cgvoucher)
            db.AddInParameter(cmd, "@VOUCHERCONTA", DbType.String, voucherconta)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptCancelaAnt = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptProductoNC(ByVal cod_alm As String, ByVal fechaini As DateTime, ByVal fechafin As DateTime, ByVal movi As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptProductoNC)
        cmd.CommandTimeout = 0
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@COD_ALM", DbType.String, cod_alm)
            db.AddInParameter(cmd, "@FECHAINI", DbType.DateTime, fechaini)
            db.AddInParameter(cmd, "@FECHAFIN", DbType.DateTime, fechafin)
            db.AddInParameter(cmd, "@MOVI", DbType.String, movi)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptProductoNC = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptPedidoSuministro(ByVal id As Int32) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptPedidoSuministro)
        cmd.CommandTimeout = 0
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@ID", DbType.String, id)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptPedidoSuministro = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptRegCompras_Prov(ByVal NumSolicitud As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptRegCompras_Prov)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, NumSolicitud)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptRegCompras_Prov = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptLiquidacionReintegro(ByVal NumSolicitud As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptLiquidacionReintegro)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, NumSolicitud)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptLiquidacionReintegro = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptLiquidacionPend(ByVal NumSolicitud As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptLiquidacionPend)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, NumSolicitud)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptLiquidacionPend = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


    Public Function RptLiquidacionCopia(ByVal NumSolicitud As String, ByVal contable As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptLiquidacionCopia)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, NumSolicitud)
            db.AddInParameter(cmd, "contable", DbType.String, contable)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptLiquidacionCopia = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptLiquidacionPendCopia(ByVal NumSolicitud As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptLiquidacionPendCopia)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, NumSolicitud)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptLiquidacionPendCopia = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptAsientoEntreas(ByVal voucherconta As String, ByVal cgvoucher As String, ByVal año As String, ByVal mes As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptAsientoContable)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "voucherconta", DbType.String, voucherconta)
            db.AddInParameter(cmd, "cgvoucher", DbType.String, cgvoucher)
            db.AddInParameter(cmd, "mescontable", DbType.String, mes)
            db.AddInParameter(cmd, "añocontable", DbType.String, año)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptAsientoEntreas = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptAsientoProvision(ByVal voucherconta As String, ByVal cgvoucher As String, ByVal año As String, ByVal mes As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptAsientoProvision)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)            
            db.AddInParameter(cmd, "mescontable", DbType.String, mes)
            db.AddInParameter(cmd, "añocontable", DbType.String, año)
            'db.AddInParameter(cmd, "voucherconta", DbType.String, voucherconta)
            'db.AddInParameter(cmd, "cgvoucher", DbType.String, cgvoucher)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptAsientoProvision = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptAsientoEntreasPend(ByVal voucherconta As String, ByVal cgvoucher As String, ByVal año As String, ByVal mes As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptAsientoContablePend)
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "voucherconta", DbType.String, voucherconta)
            db.AddInParameter(cmd, "cgvoucher", DbType.String, cgvoucher)
            db.AddInParameter(cmd, "mescontable", DbType.String, mes)
            db.AddInParameter(cmd, "añocontable", DbType.String, año)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptAsientoEntreasPend = Ds
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptAnticipo(ByVal NumSolicitud As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptAnticipo)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, NumSolicitud)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptAnticipo = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RptFactCombustible(ByVal id As Int32) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RptFactCombustible)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "ID", DbType.Int32, id)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            RptFactCombustible = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


End Class
