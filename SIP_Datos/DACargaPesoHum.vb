Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports SIP_Entidad

Public Class DACargaPesoHum

    Public Function Prod_CargaPesos_ValidarCierre(ByVal anio As Integer, ByVal mes As Integer) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ProdCargaPesoHum_VerificarCierre)
        Dim nro_registros As Integer = 0
        Try

            db.AddInParameter(cmd, "@anio", DbType.Int32, anio)
            db.AddInParameter(cmd, "@mes", DbType.Int32, mes)

            nro_registros = db.ExecuteScalar(cmd)

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            nro_registros = -1

        End Try

        Return nro_registros

    End Function

    Public Function Prod_CargaPesos_LimpiarRegistros(ByVal anio As Integer, ByVal mes As Integer, ByVal dia As Integer) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ProdCargaPesoHum_LimpiarRegistros)
        Dim nro_registros As Integer = 0
        Try

            db.AddInParameter(cmd, "@anio", DbType.Int32, anio)
            db.AddInParameter(cmd, "@mes", DbType.Int32, mes)
            db.AddInParameter(cmd, "@dia", DbType.Int32, dia)

            nro_registros = db.ExecuteScalar(cmd)

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            nro_registros = -1

        End Try

        Return nro_registros

    End Function

    Public Function Prod_CargaPesos_RegistrarTrama(ByVal id As String, _
                                                   ByVal hora As String, _
                                                   ByVal fecha As DateTime, _
                                                   ByVal peso_caliza As Decimal, _
                                                   ByVal peso_silice As Decimal, _
                                                   ByVal peso_caolin As Decimal, _
                                                   ByVal grupo As String) As Integer

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ProdCargaPesoHum_RegistrarTrama)
        Dim nro_registros As Integer = 0
        Try

            db.AddInParameter(cmd, "@id", DbType.String, id)
            db.AddInParameter(cmd, "@hora", DbType.String, hora)
            db.AddInParameter(cmd, "@fecha", DbType.DateTime, fecha)
            db.AddInParameter(cmd, "@peso_caliza", DbType.Decimal, peso_caliza)
            db.AddInParameter(cmd, "@peso_silice", DbType.Decimal, peso_silice)
            db.AddInParameter(cmd, "@peso_caolin", DbType.Decimal, peso_caolin)
            db.AddInParameter(cmd, "@grupo", DbType.String, grupo)

            nro_registros = db.ExecuteScalar(cmd)

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            nro_registros = -1

        End Try

        Return nro_registros

    End Function

    Public Function Listar_CargaPesosHum(ByVal anio As Integer, ByVal mes As Integer) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ProdCargaPesoHum_ListarCarga)
        Dim ds As New DataSet("CARGA_ARCHIVO")
        Try
            db.AddInParameter(cmd, "@anio", DbType.String, anio)
            db.AddInParameter(cmd, "@mes", DbType.String, mes)

            ds = db.ExecuteDataSet(cmd)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return ds
    End Function

    Public Function Listar_CargaPesosHumGrupo(ByVal Grupo As String) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ProdCargaPesoHum_ListarCargaGrupo)
        Dim ds As New DataSet("CARGA_ARCHIVO_SUBIDOS")
        Try
            db.AddInParameter(cmd, "@Grupo", DbType.String, Grupo)

            ds = db.ExecuteDataSet(cmd)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return ds
    End Function
    Public Function Actualizar_CargaPesosResumenParametros(ByVal anio As Integer, ByVal mes As Integer, ByVal porc_pirofilita As Decimal, ByVal porc_silice As Decimal) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Try
            Using con As DbConnection = db.CreateConnection()

                Dim cmd As DbCommand = db.GetStoredProcCommand("usp_Prod_CargaPeso_ActualizarParametros")

                db.AddInParameter(cmd, "@anio", DbType.Int32, anio)
                db.AddInParameter(cmd, "@mes", DbType.Int32, mes)

                db.AddInParameter(cmd, "@porc_pirofilita", DbType.Decimal, porc_pirofilita)
                db.AddInParameter(cmd, "@porc_silice", DbType.Decimal, porc_silice)

                db.ExecuteNonQuery(cmd)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function Actualizar_CargaPesosResumen(ByVal ListaItems As List(Of ETCargaPesoCrudo)) As String
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cadena As String = String.Empty
        Try

            Using con As DbConnection = db.CreateConnection()

                con.Open()

                Dim tran As DbTransaction = con.BeginTransaction()

                Try
                    For Each ItemRow As ETCargaPesoCrudo In ListaItems
                        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ProdCargaPesoHum_ActualizarResumen)

                        db.AddInParameter(cmd, "@anio", DbType.Int32, ItemRow.Anio)
                        db.AddInParameter(cmd, "@mes", DbType.Int32, ItemRow.Mes)
                        db.AddInParameter(cmd, "@dia", DbType.Int32, ItemRow.Dia)

                        db.AddInParameter(cmd, "@porc_hum_caliza", DbType.Decimal, ItemRow.PorcHumCaliza)
                        db.AddInParameter(cmd, "@porc_hum_silice", DbType.Decimal, ItemRow.PorcHumSilice)
                        db.AddInParameter(cmd, "@porc_hum_caolin", DbType.Decimal, ItemRow.PorcHumCaolin)
                        db.AddInParameter(cmd, "@porc_hum_pirofilita", DbType.Decimal, ItemRow.PorcHumPirofilita)

                        db.AddInParameter(cmd, "@base_caliza", DbType.Decimal, ItemRow.BaseCaliza)
                        db.AddInParameter(cmd, "@base_silice", DbType.Decimal, ItemRow.BaseSilice)
                        db.AddInParameter(cmd, "@base_caolin", DbType.Decimal, ItemRow.BaseCaolin)

                        db.AddOutParameter(cmd, "@msj", DbType.String, 200)

                        db.ExecuteNonQuery(cmd)

                        cadena = db.GetParameterValue(cmd, "@msj").ToString

                        If cadena.Length > 0 Then
                            Throw New Exception(cadena)
                        End If

                    Next

                    tran.Commit()
                    con.Close()

                Catch Err As Exception
                    tran.Rollback()
                    con.Close()
                    MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                End Try

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return cadena
    End Function


#Region "REPORTES"

    Public Function ValidarResumenHorno(ByVal pHornoReporte As ETClinker_Reporte) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_Prod_HornoResumenMensual_Validar")
        Dim nro_registros As Integer = 0
        Try

            db.AddInParameter(cmd, "@anio", DbType.Int32, pHornoReporte.Anio)
            db.AddInParameter(cmd, "@mes", DbType.Int32, pHornoReporte.Mes)
            db.AddInParameter(cmd, "@tipo", DbType.String, pHornoReporte.Tipo)

            nro_registros = db.ExecuteScalar(cmd)

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            nro_registros = -1

        End Try

        Return nro_registros
    End Function
    Public Function ActualizarResumenHorno(ByVal pHornoReporte As ETClinker_Reporte) As ETClinker_Reporte

        Try

            Dim db As Database = DatabaseFactory.CreateDatabase()

            Dim nro_registros As String = String.Empty

            Using con As DbConnection = db.CreateConnection()

                con.Open()

                Dim tran As DbTransaction = con.BeginTransaction()

                Dim cmdHeader As DbCommand = db.GetStoredProcCommand("usp_Prod_HornoResumenMensual_Operaciones")
                db.AddInParameter(cmdHeader, "@anio", DbType.Int32, pHornoReporte.Anio)
                db.AddInParameter(cmdHeader, "@mes", DbType.Int32, pHornoReporte.Mes)
                db.AddInParameter(cmdHeader, "@tipo", DbType.String, pHornoReporte.Tipo)

                db.AddInParameter(cmdHeader, "@I7", DbType.Decimal, pHornoReporte.I7)
                db.AddInParameter(cmdHeader, "@K7", DbType.Decimal, pHornoReporte.K7)
                db.AddInParameter(cmdHeader, "@L7", DbType.Decimal, pHornoReporte.L7)
                db.AddInParameter(cmdHeader, "@M7", DbType.Decimal, pHornoReporte.M7)
                db.AddInParameter(cmdHeader, "@N7", DbType.Decimal, pHornoReporte.N7)
                db.AddInParameter(cmdHeader, "@O7", DbType.Decimal, pHornoReporte.O7)
                db.AddInParameter(cmdHeader, "@P7", DbType.Decimal, pHornoReporte.P7)
                db.AddInParameter(cmdHeader, "@Q7", DbType.Decimal, pHornoReporte.Q7)
                db.AddInParameter(cmdHeader, "@R7", DbType.Decimal, pHornoReporte.R7)
                db.AddInParameter(cmdHeader, "@S7", DbType.Decimal, pHornoReporte.S7)

                db.AddInParameter(cmdHeader, "@op", DbType.Int32, 2)
                db.AddOutParameter(cmdHeader, "@idResumen", DbType.Int32, 8)

                Try
                    db.ExecuteNonQuery(cmdHeader, tran)

                    pHornoReporte.idResumen = Convert.ToInt32(db.GetParameterValue(cmdHeader, "@idResumen"))

                    For Each ItemRow As ETClinker_FilaReporte In pHornoReporte.Detalles

                        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_Prod_HornoResumenMensual_ActualizarDetalle")

                        db.AddInParameter(cmd, "@idResumen", DbType.Int32, pHornoReporte.idResumen)

                        db.AddInParameter(cmd, "@dia", DbType.Int32, ItemRow.Dia)

                        If ItemRow.De.HasValue Then
                            db.AddInParameter(cmd, "@de", DbType.DateTime, ItemRow.De.Value)
                        Else
                            db.AddInParameter(cmd, "@de", DbType.DateTime, DBNull.Value)
                        End If
                        If ItemRow.A.HasValue Then
                            db.AddInParameter(cmd, "@a", DbType.DateTime, ItemRow.A.Value)
                        Else
                            db.AddInParameter(cmd, "@a", DbType.DateTime, DBNull.Value)
                        End If

                        db.AddInParameter(cmd, "@total_horas", DbType.String, ItemRow.TotalHoras)

                        db.AddInParameter(cmd, "@kgmin", DbType.Decimal, ItemRow.KgPorMin)
                        db.AddInParameter(cmd, "@crudo", DbType.Decimal, ItemRow.CrudoRecirculado)
                        db.AddInParameter(cmd, "@fm", DbType.Decimal, ItemRow.CrudoRecirculado)
                        db.AddInParameter(cmd, "@ciclones", DbType.Decimal, ItemRow.ConsumoGas)
                        db.AddInParameter(cmd, "@otros", DbType.Decimal, ItemRow.CrudoRecirculado)
                        db.AddInParameter(cmd, "@descuento", DbType.Decimal, ItemRow.Descuento)
                        db.AddInParameter(cmd, "@mermas", DbType.Decimal, ItemRow.Merma)
                        db.AddInParameter(cmd, "@consumo_gas", DbType.Decimal, ItemRow.ConsumoGas)

                        nro_registros = db.ExecuteNonQuery(cmd)

                    Next

                    tran.Commit()
                    con.Close()

                Catch Err As Exception
                    tran.Rollback()
                    con.Close()
                    MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                End Try

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return pHornoReporte

    End Function
    Public Function ObtenerResumenHorno(ByVal pHornoReporte As ETClinker_Reporte) As ETClinker_Reporte

        Dim oItem As New ETClinker_Reporte
        Dim item As New ETClinker_FilaReporte

        Try

            Dim db As Database = DatabaseFactory.CreateDatabase()
            Dim cmd As DbCommand = db.GetStoredProcCommand("usp_Prod_HornoResumenMensual_Obtener")

            Try
                db.AddInParameter(cmd, "@anio", DbType.String, pHornoReporte.Anio)
                db.AddInParameter(cmd, "@mes", DbType.String, pHornoReporte.Mes)
                db.AddInParameter(cmd, "@tipo", DbType.String, pHornoReporte.Tipo)

                Using reader As IDataReader = db.ExecuteReader(cmd)


                    If reader.Read() Then
                        If reader("idResumen") IsNot DBNull.Value Then
                            oItem.idResumen = Convert.ToInt32(reader("idResumen"))
                        End If
                        If reader("anio") IsNot DBNull.Value Then
                            oItem.Anio = Convert.ToInt32(reader("anio"))
                        End If
                        If reader("mes") IsNot DBNull.Value Then
                            oItem.Mes = Convert.ToInt32(reader("mes"))
                        End If
                        If reader("tipo") IsNot DBNull.Value Then
                            oItem.Tipo = Convert.ToString(reader("tipo"))
                        End If
                        If reader("I7") IsNot DBNull.Value Then
                            oItem.I7 = Convert.ToDecimal(reader("I7"))
                        End If
                        If reader("K7") IsNot DBNull.Value Then
                            oItem.K7 = Convert.ToDecimal(reader("K7"))
                        End If
                        If reader("L7") IsNot DBNull.Value Then
                            oItem.L7 = Convert.ToDecimal(reader("L7"))
                        End If
                        If reader("M7") IsNot DBNull.Value Then
                            oItem.M7 = Convert.ToDecimal(reader("M7"))
                        End If
                        If reader("N7") IsNot DBNull.Value Then
                            oItem.N7 = Convert.ToDecimal(reader("N7"))
                        End If
                        If reader("O7") IsNot DBNull.Value Then
                            oItem.O7 = Convert.ToDecimal(reader("O7"))
                        End If
                        If reader("P7") IsNot DBNull.Value Then
                            oItem.P7 = Convert.ToDecimal(reader("P7"))
                        End If
                        If reader("Q7") IsNot DBNull.Value Then
                            oItem.Q7 = Convert.ToDecimal(reader("Q7"))
                        End If
                        If reader("R7") IsNot DBNull.Value Then
                            oItem.R7 = Convert.ToDecimal(reader("R7"))
                        End If
                        If reader("S7") IsNot DBNull.Value Then
                            oItem.S7 = Convert.ToDecimal(reader("S7"))
                        End If
                    End If

                    If reader.NextResult() Then

                        While reader.Read()

                            item = New ETClinker_FilaReporte
                            If reader("idResumen") IsNot DBNull.Value Then
                                item.idResumen = Convert.ToInt32(reader("idResumen"))
                            End If
                            If reader("dia") IsNot DBNull.Value Then
                                item.Dia = Convert.ToInt32(reader("dia"))
                            End If
                            If reader("de") IsNot DBNull.Value Then
                                item.De = Convert.ToDateTime(reader("de"))
                            End If
                            If reader("a") IsNot DBNull.Value Then
                                item.A = Convert.ToDateTime(reader("a"))
                            End If
                            If reader("total_horas") IsNot DBNull.Value Then
                                item.TotalHoras = Convert.ToString(reader("total_horas"))
                            End If
                            If reader("kgmin") IsNot DBNull.Value Then
                                item.KgPorMin = Convert.ToDecimal(reader("kgmin"))
                            End If
                            If reader("crudo") IsNot DBNull.Value Then
                                item.CrudoRecirculado = Convert.ToDecimal(reader("crudo"))
                            End If
                            If reader("descuento") IsNot DBNull.Value Then
                                item.Descuento = Convert.ToDecimal(reader("descuento"))
                            End If
                            If reader("mermas") IsNot DBNull.Value Then
                                item.Merma = Convert.ToDecimal(reader("mermas"))
                            End If
                            If reader("consumo_gas") IsNot DBNull.Value Then
                                item.ConsumoGas = Convert.ToDecimal(reader("consumo_gas"))
                            End If
                            If reader("fm") IsNot DBNull.Value Then
                                item.Fm = Convert.ToDecimal(reader("fm"))
                            End If
                            If reader("ciclones") IsNot DBNull.Value Then
                                item.Ciclones = Convert.ToDecimal(reader("ciclones"))
                            End If
                            If reader("otros") IsNot DBNull.Value Then
                                item.Otros = Convert.ToDecimal(reader("otros"))
                            End If

                            oItem.Detalles.Add(item)
                        End While


                    End If

                End Using

            Catch Err As Exception
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return oItem

    End Function
    Public Function GenerarResumenHorno(ByVal pHornoReporte As ETClinker_Reporte, ByVal user As String, ByVal opcion As Integer) As ETClinker_Reporte

        Dim oItem As New ETClinker_Reporte
        Dim item As New ETClinker_FilaReporte

        Try

            Dim db As Database = DatabaseFactory.CreateDatabase()

            Dim nro_registros As String = String.Empty

            Using con As DbConnection = db.CreateConnection()

                con.Open()

                Dim tran As DbTransaction = con.BeginTransaction()

                Try

                    Dim cmd As DbCommand = db.GetStoredProcCommand("usp_Prod_HornoResumenMensual_Operaciones")

                    db.AddInParameter(cmd, "@anio", DbType.Int32, pHornoReporte.Anio)
                    db.AddInParameter(cmd, "@mes", DbType.Int32, pHornoReporte.Mes)
                    db.AddInParameter(cmd, "@tipo", DbType.String, pHornoReporte.Tipo)

                    db.AddInParameter(cmd, "@I7", DbType.Decimal, pHornoReporte.I7)
                    db.AddInParameter(cmd, "@K7", DbType.Decimal, pHornoReporte.K7)
                    db.AddInParameter(cmd, "@L7", DbType.Decimal, pHornoReporte.L7)
                    db.AddInParameter(cmd, "@M7", DbType.Decimal, pHornoReporte.M7)
                    db.AddInParameter(cmd, "@N7", DbType.Decimal, pHornoReporte.N7)
                    db.AddInParameter(cmd, "@O7", DbType.Decimal, pHornoReporte.O7)
                    db.AddInParameter(cmd, "@P7", DbType.Decimal, pHornoReporte.P7)
                    db.AddInParameter(cmd, "@Q7", DbType.Decimal, pHornoReporte.Q7)
                    db.AddInParameter(cmd, "@R7", DbType.Decimal, pHornoReporte.Q7)
                    db.AddInParameter(cmd, "@S7", DbType.Decimal, pHornoReporte.S7)

                    db.AddInParameter(cmd, "@op", DbType.Int32, opcion)
                    db.AddOutParameter(cmd, "@idResumen", DbType.Int32, 8)

                    nro_registros = db.ExecuteNonQuery(cmd)

                    pHornoReporte.idResumen = Convert.ToInt32(db.GetParameterValue(cmd, "@idResumen"))

                    tran.Commit()
                    con.Close()

                Catch Err As Exception
                    tran.Rollback()
                    con.Close()
                    MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                End Try

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return pHornoReporte

    End Function

    Public Function ObtenerInventario(ByVal anio As Integer, ByVal mes As Integer) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_Prod_Inventario_Hornos")
        Dim ds As New DataSet("INFORME")
        Try
            db.AddInParameter(cmd, "@anio", DbType.String, anio)
            db.AddInParameter(cmd, "@mes", DbType.String, mes)

            ds = db.ExecuteDataSet(cmd)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return ds
    End Function
#End Region


End Class
