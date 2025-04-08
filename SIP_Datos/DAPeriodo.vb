Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAPeriodo

    Public Function Validar_Periodo(ByVal Periodo As ETPeriodo) As Boolean
        Dim lResult As Boolean = False
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo)
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Anio", DbType.Int32, Periodo.Anio)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Periodo.Mes)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.TipoPeriodo)
            db.AddInParameter(cmd, "TipoSQL", DbType.Int16, 5)

            lResult = db.ExecuteScalar(cmd)

        Catch Err As Exception

            MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)

        End Try

        Return lResult
    End Function

    Public Function Validar_Periodo_Cerrado(ByVal Periodo As ETPeriodo) As Integer
        Dim lResult As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo)
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Anio", DbType.Int32, Periodo.Anio)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Periodo.Mes)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.TipoPeriodo)
            db.AddInParameter(cmd, "TipoSQL", DbType.Int16, 9)

            lResult = db.ExecuteScalar(cmd)

        Catch Err As Exception

            MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)

        End Try

        Return lResult
    End Function

    Public Function Mantenedor_Periodo(ByVal Periodo As ETPeriodo) As Boolean
        Dim lResult As Boolean = False
        Dim db As Database = DatabaseFactory.CreateDatabase

        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo)
                db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Anio", DbType.Int32, Periodo.Anio)
                db.AddInParameter(cmd, "Mes", DbType.Int16, Periodo.Mes)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.TipoPeriodo)
                db.AddInParameter(cmd, "ValorPeriodo", DbType.Double, Periodo.ValorPeriodo)
                db.AddInParameter(cmd, "Valor2", DbType.Double, Periodo.Valor2)
                db.AddInParameter(cmd, "Valor3", DbType.Double, Periodo.Valor3)
                db.AddInParameter(cmd, "Valor4", DbType.Double, Periodo.Valor4)
                db.AddInParameter(cmd, "Valor5", DbType.Double, Periodo.Valor5)
                db.AddInParameter(cmd, "Valor6", DbType.Double, Periodo.Valor6)
                db.AddInParameter(cmd, "Status", DbType.String, Periodo.Status)
                db.AddInParameter(cmd, "User", DbType.String, Periodo.Usuario)
                db.AddInParameter(cmd, "TipoSQL", DbType.Int16, Periodo.Tipo.ToString)

                lResult = db.ExecuteNonQuery(cmd, Trans)
                Trans.Commit()
                conexion.Close()
                lResult = True
            Catch Err As Exception
                Trans.Rollback()
                conexion.Close()
                MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = False
            End Try
        End Using
        
        Return lResult
    End Function

    Public Function Mantenedor_Periodo_Facturacion(ByVal Periodo As ETPeriodo, ByVal Periodo_Detalle As List(Of ETPeriodoDetalle), ByVal Ls_Comprob_Pago As List(Of ETPeriodoDetalle), ByVal Ls_Comprob_Pago_Mes As List(Of ETPeriodoDetalle)) As Boolean
        Dim lResult As Boolean = False
        Dim IDPeriodo As Long = 0

        Dim db As Database = DatabaseFactory.CreateDatabase

        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo)
                db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Anio", DbType.Int32, Periodo.Anio)
                db.AddInParameter(cmd, "Mes", DbType.Int16, Periodo.Mes)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.TipoPeriodo)
                db.AddInParameter(cmd, "Status", DbType.String, Periodo.Status)
                db.AddInParameter(cmd, "User", DbType.String, Periodo.Usuario)
                db.AddInParameter(cmd, "TipoSQL", DbType.Int16, Periodo.Tipo.ToString)
                IDPeriodo = db.ExecuteScalar(cmd, Trans)

                If Periodo.Tipo <> 3 Then
                    If Periodo.TipoPeriodo = ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos_Facturacion Then
                        For Each zRow As ETPeriodoDetalle In Ls_Comprob_Pago_Mes
                            Dim zmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_ComprobantePago_Mes)
                            db.AddInParameter(zmd, "Periodo", DbType.Int32, IDPeriodo)
                            db.AddInParameter(zmd, "Cod_Cia", DbType.String, Companhia)
                            db.AddInParameter(zmd, "Cod_Prov", DbType.String, zRow.Cod_Prov)
                            db.AddInParameter(zmd, "Tipo_Doc", DbType.String, zRow.Tipo_Doc)
                            db.AddInParameter(zmd, "Num_Doc", DbType.String, zRow.Num_Doc)
                            db.AddInParameter(zmd, "Tipo", DbType.String, zRow.TipoCosteo)
                            db.AddInParameter(zmd, "Importe", DbType.Double, zRow.Importe)
                            db.AddInParameter(zmd, "Consumo", DbType.Double, zRow.Consumo)
                            db.AddInParameter(zmd, "CostoUnitario", DbType.Double, zRow.CostoUnitario)
                            db.AddInParameter(zmd, "User", DbType.String, zRow.Usuario)
                            db.AddInParameter(zmd, "TipoSQL", DbType.String, "1")
                            db.ExecuteNonQuery(zmd, Trans)
                        Next
                    End If

                    For Each xRow As ETPeriodoDetalle In Periodo_Detalle
                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_Activos)
                        db.AddInParameter(xmd, "Periodo", DbType.Int32, IDPeriodo)
                        db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(xmd, "TipoCosteo", DbType.String, xRow.TipoCosteo)
                        db.AddInParameter(xmd, "Costeo", DbType.String, xRow.Costeo)
                        db.AddInParameter(xmd, "Codigo", DbType.String, xRow.Codigo)
                        db.AddInParameter(xmd, "TipoPropio", DbType.String, xRow.TipoPropio)
                        db.AddInParameter(xmd, "Propio", DbType.String, xRow.Propio)
                        db.AddInParameter(xmd, "SubTipo", DbType.String, xRow.SubTipo)
                        db.AddInParameter(xmd, "SubCosteo", DbType.String, xRow.SubCosteo)
                        db.AddInParameter(xmd, "Cod_Prov", DbType.String, xRow.Cod_Prov)
                        db.AddInParameter(xmd, "Cod_Alm", DbType.String, xRow.Cod_Alm)
                        db.AddInParameter(xmd, "FechaInicio", DbType.DateTime, xRow.FechaInicio)
                        db.AddInParameter(xmd, "FechaTermino", DbType.DateTime, xRow.FechaTermino)
                        db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(xmd, "Tipo", DbType.String, "1")
                        db.ExecuteNonQuery(xmd, Trans)
                        If Ls_Comprob_Pago IsNot Nothing Then
                            If Ls_Comprob_Pago.Count > 0 Then
                                For Each yRow As ETPeriodoDetalle In Ls_Comprob_Pago
                                    If xRow.Codigo.TrimEnd = yRow.Codigo.TrimEnd Then
                                        Dim ymd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_Activos_Facturacion)
                                        db.AddInParameter(ymd, "Periodo", DbType.Int32, IDPeriodo)
                                        db.AddInParameter(ymd, "Cod_Cia", DbType.String, Companhia)
                                        db.AddInParameter(ymd, "Codigo", DbType.String, yRow.Codigo)
                                        db.AddInParameter(ymd, "Cod_Prov", DbType.String, yRow.Cod_Prov)
                                        db.AddInParameter(ymd, "Tipo_Doc", DbType.String, yRow.Tipo_Doc)
                                        db.AddInParameter(ymd, "Num_Doc", DbType.String, yRow.Num_Doc)
                                        db.AddInParameter(ymd, "User", DbType.String, yRow.Usuario)
                                        db.AddInParameter(ymd, "Tipo", DbType.String, "1")
                                        db.ExecuteNonQuery(ymd, Trans)
                                    End If
                                Next
                            End If
                        End If

                    Next
                End If
                Trans.Commit()
                conexion.Close()
                lResult = True
            Catch Err As Exception
                Trans.Rollback()
                conexion.Close()
                MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = False
            End Try
        End Using

        Return lResult
    End Function

    Public Function Mantenedor_Periodo_Operador(ByVal Periodo As ETPeriodo, ByVal Periodo_Detalle As List(Of ETPeriodoDetalle)) As Boolean
        Dim lResult As Boolean = False
        Dim IDPeriodo As Long = 0

        Dim db As Database = DatabaseFactory.CreateDatabase

        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo)
                db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Anio", DbType.Int32, Periodo.Anio)
                db.AddInParameter(cmd, "Mes", DbType.Int16, Periodo.Mes)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.TipoPeriodo)
                db.AddInParameter(cmd, "Status", DbType.String, Periodo.Status)
                db.AddInParameter(cmd, "User", DbType.String, Periodo.Usuario)
                db.AddInParameter(cmd, "TipoSQL", DbType.Int16, Periodo.Tipo.ToString)
                IDPeriodo = db.ExecuteScalar(cmd, Trans)

                If Periodo.Tipo <> 3 Then
                    For Each xRow As ETPeriodoDetalle In Periodo_Detalle
                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_Operador)
                        db.AddInParameter(xmd, "Periodo", DbType.Int32, IDPeriodo)
                        db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(xmd, "Codigo", DbType.String, xRow.Codigo)
                        db.AddInParameter(xmd, "Descripcion", DbType.String, xRow.Descripcion)
                        db.AddInParameter(xmd, "PlaCod", DbType.String, xRow.PlaCod)
                        db.AddInParameter(xmd, "Cod_Alm", DbType.String, xRow.Cod_Alm)
                        db.AddInParameter(xmd, "FechaInicio", DbType.DateTime, xRow.FechaInicio)
                        db.AddInParameter(xmd, "FechaTermino", DbType.DateTime, xRow.FechaTermino)
                        db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(xmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.ExecuteNonQuery(xmd, Trans)
                    Next
                End If
                Trans.Commit()
                conexion.Close()
                lResult = True
            Catch Err As Exception
                Trans.Rollback()
                conexion.Close()
                MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = False
            End Try
        End Using

        Return lResult
    End Function

    Public Function Consultar_Periodo(ByVal Periodo As ETPeriodo) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.TipoPeriodo)
            db.AddInParameter(cmd, "TipoSQL", DbType.String, Periodo.Tipo)


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Periodo = New ETPeriodo
                    Entidad.Periodo.Anio = dr.GetInt32(dr.GetOrdinal("Anio"))
                    Entidad.Periodo.MesName = dr.GetString(dr.GetOrdinal("MesName"))
                    Entidad.Periodo.Mes = dr.GetInt16(dr.GetOrdinal("Mes"))

                    Select Case Periodo.TipoPeriodo
                        Case ETPeriodo.sTipoPeriodo.DistribucionPersonal_LinProd
                            Entidad.Periodo.NroReg = dr.GetInt32(dr.GetOrdinal("NroReg"))
                        Case ETPeriodo.sTipoPeriodo.CosteoGasNatural
                            Entidad.Periodo.ValorPeriodo = dr.GetDecimal(dr.GetOrdinal("ValorPeriodo"))
                            Entidad.Periodo.Valor2 = dr.GetDecimal(dr.GetOrdinal("Valor2"))
                        Case ETPeriodo.sTipoPeriodo.CosteoSiliceHomogenizada
                            Entidad.Periodo.ValorPeriodo = dr.GetDecimal(dr.GetOrdinal("ValorPeriodo"))
                            Entidad.Periodo.Valor2 = dr.GetDecimal(dr.GetOrdinal("Valor2"))
                            Entidad.Periodo.Valor3 = dr.GetDecimal(dr.GetOrdinal("Valor3"))
                            Entidad.Periodo.Valor4 = dr.GetDecimal(dr.GetOrdinal("Valor4"))
                            Entidad.Periodo.Valor5 = dr.GetDecimal(dr.GetOrdinal("Valor5"))
                            Entidad.Periodo.Valor6 = dr.GetDecimal(dr.GetOrdinal("Valor6"))
                        Case ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos, ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos_Facturacion, ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos_Operador
                            Entidad.Periodo.Estado = dr.GetString(dr.GetOrdinal("Estado"))
                            Entidad.Periodo.Status = dr.GetString(dr.GetOrdinal("Status"))
                    End Select

                    Entidad.Periodo.Periodo = dr.GetInt32(dr.GetOrdinal("Periodo"))
                    lResult.Ls_Periodo.Add(Entidad.Periodo)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult
    End Function

    Public Function Consultar_Periodo_Activos(ByVal Periodo As ETPeriodoDetalle) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_Activos)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Periodo.Cod_Alm)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Periodo.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Periodo.FechaTermino)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.PeriodoDetalle = New ETPeriodoDetalle
                    With Entidad.PeriodoDetalle
                        .TipoCosteo = dr.GetString(dr.GetOrdinal("TipoCosteo"))
                        .Costeo = dr.GetString(dr.GetOrdinal("Costeo"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .TipoPropio = dr.GetString(dr.GetOrdinal("TipoPropio"))
                        .Propio = dr.GetString(dr.GetOrdinal("Propio"))
                        .SubTipo = dr.GetString(dr.GetOrdinal("SubTipo"))
                        .SubCosteo = dr.GetString(dr.GetOrdinal("SubCosteo"))
                        .Cod_Prov = dr.GetString(dr.GetOrdinal("Cod_Prov"))
                        .RazSoc = dr.GetString(dr.GetOrdinal("RazSoc"))
                        .Facturacion = dr.GetInt16(dr.GetOrdinal("Facturacion"))
                        .Tipo = dr.GetInt16(dr.GetOrdinal("Tipo"))
                        .Usuario = Periodo.Usuario
                    End With
                    lResult.Ls_PeriodoDetalle.Add(Entidad.PeriodoDetalle)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult
    End Function

    Public Function Consultar_Periodo_Activos_Facturacion(ByVal Periodo As ETPeriodoDetalle) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_Activos_Facturacion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.PeriodoDetalle = New ETPeriodoDetalle
                    With Entidad.PeriodoDetalle
                        .Action = True
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Cod_Prov = dr.GetString(dr.GetOrdinal("Cod_Prov"))
                        .Tipo_Doc = dr.GetString(dr.GetOrdinal("Tipo_Doc"))
                        .Tipo_Doc_Name = dr.GetString(dr.GetOrdinal("Tipo_Doc_Name"))
                        .Num_Doc = dr.GetString(dr.GetOrdinal("Num_Doc"))
                        .Fecha_Doc = dr.GetDateTime(dr.GetOrdinal("Fecha_Doc"))
                        .Fecha_Proc = dr.GetDateTime(dr.GetOrdinal("Fecha_Proc"))
                        .Total = dr.GetDecimal(dr.GetOrdinal("Total"))
                        .IGV = dr.GetDecimal(dr.GetOrdinal("IGV"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Importe"))
                        .Tipo = 1
                        .Usuario = Periodo.Usuario
                    End With
                    lResult.Ls_PeriodoDetalle.Add(Entidad.PeriodoDetalle)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult
    End Function


    Public Function Consultar_Periodo_Operador(ByVal Periodo As ETPeriodoDetalle) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_Operador)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Periodo.Cod_Alm)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Periodo.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Periodo.FechaTermino)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.PeriodoDetalle = New ETPeriodoDetalle
                    With Entidad.PeriodoDetalle
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .PlaCod = dr.GetString(dr.GetOrdinal("PlaCod"))
                        .Operador = dr.GetString(dr.GetOrdinal("Personal"))
                        .Personal = dr.GetString(dr.GetOrdinal("Personal"))
                        .Tipo = dr.GetInt16(dr.GetOrdinal("Tipo"))
                        .Usuario = Periodo.Usuario
                    End With
                    lResult.Ls_PeriodoDetalle.Add(Entidad.PeriodoDetalle)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult
    End Function

    Public Function Consultar_Periodo_ComprobatePago(ByVal Periodo As ETPeriodoDetalle) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_ComprobantePago)
        Dim lResult As DataSet

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Prov", DbType.String, Periodo.Cod_Prov)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.Tipo)
            db.AddInParameter(cmd, "Tipo_Doc", DbType.String, Periodo.Tipo_Doc)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Periodo.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Periodo.FechaTermino)

            lResult = db.ExecuteDataSet(cmd)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        Return lResult
    End Function

    Public Function Consultar_Periodo_ComprobatePago_Mes(ByVal Periodo As ETPeriodo) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_ComprobantePago_Mes)
        Dim lResult As New ETMyLista

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "TipoSQL", DbType.String, Periodo.Tipo.ToString)
            Using dr As DbDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.PeriodoDetalle = New ETPeriodoDetalle
                    With Entidad.PeriodoDetalle
                        .Cod_Prov = dr.GetString(dr.GetOrdinal("Cod_Prov"))
                        .RazSoc = dr.GetString(dr.GetOrdinal("Proveedor"))
                        .Num_Doc = dr.GetString(dr.GetOrdinal("Num_Doc"))
                        .TipoCosteo = dr.GetString(dr.GetOrdinal("Tipo"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Importe"))
                        .Consumo = dr.GetDecimal(dr.GetOrdinal("Consumo"))
                        .CostoUnitario = dr.GetDecimal(dr.GetOrdinal("CostoUnitario"))
                    End With
                    lResult.Ls_PeriodoDetalle.Add(Entidad.PeriodoDetalle)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString

            End Using


        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        Return lResult
    End Function

End Class
