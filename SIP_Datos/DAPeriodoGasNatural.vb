Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAPeriodoGasNatural

    Public Function Mantto_Periodo_GasNatural(ByVal Periodo As ETPeriodo, _
                                            ByVal GN_Detalle As List(Of ETCosteoActivo), _
                                            ByVal GN_Anulado As List(Of ETCosteoActivo), _
                                            ByVal GN_LinProd As List(Of ETLineaNegocio)) As Integer

        Dim lResult As Long = 0
        If Periodo Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo)
                db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Anio", DbType.Int32, Periodo.Anio)
                db.AddInParameter(cmd, "Mes", DbType.Int16, Periodo.Mes)
                db.AddInParameter(cmd, "ValorPeriodo", DbType.Double, Periodo.ValorPeriodo)
                db.AddInParameter(cmd, "Valor2", DbType.Double, Periodo.Valor2)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.TipoPeriodo)
                db.AddInParameter(cmd, "status", DbType.String, Periodo.Status)
                db.AddInParameter(cmd, "User", DbType.String, Periodo.Usuario)
                db.AddInParameter(cmd, "TipoSQL", DbType.String, Periodo.Tipo.ToString)


                lResult = db.ExecuteScalar(cmd, Trans)

                If Not (Periodo.Tipo = 3) Then
                    For Each xRow As ETCosteoActivo In GN_Anulado
                        Dim dxmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_GasNatural)
                        db.AddInParameter(dxmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(dxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(dxmd, "Equipo", DbType.String, xRow.Codigo)
                        db.AddInParameter(dxmd, "Cantidad", DbType.Double, xRow.Cantidad)
                        db.AddInParameter(dxmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(dxmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(dxmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.ExecuteNonQuery(dxmd, Trans)
                    Next

                    For Each xRow As ETCosteoActivo In GN_Detalle
                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_GasNatural)

                        db.AddInParameter(xmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(xmd, "Equipo", DbType.String, xRow.Codigo)
                        db.AddInParameter(xmd, "Cantidad", DbType.Double, xRow.Cantidad)
                        db.AddInParameter(xmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(xmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.ExecuteNonQuery(xmd, Trans)
                    Next

                    'For Each xRow As ETCosteoActivo In GN_Planta_Anul
                    '    Dim dpmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_GasNatural_Planta)
                    '    db.AddInParameter(dpmd, "Periodo", DbType.Int32, lResult)
                    '    db.AddInParameter(dpmd, "Cod_Cia", DbType.String, Companhia)
                    '    db.AddInParameter(dpmd, "Planta", DbType.String, xRow.Codigo)
                    '    db.AddInParameter(dpmd, "Porcentaje", DbType.Double, xRow.Cantidad)
                    '    db.AddInParameter(dpmd, "status", DbType.String, xRow.Status)
                    '    db.AddInParameter(dpmd, "User", DbType.String, xRow.Usuario)
                    '    db.AddInParameter(dpmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                    '    db.ExecuteNonQuery(dpmd, Trans)
                    'Next

                    For Each xRow As ETLineaNegocio In GN_LinProd
                        Dim pmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_GasNatural_LinProd)

                        db.AddInParameter(pmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(pmd, "LinProd", DbType.Int32, xRow.IDCatalogo)
                        db.AddInParameter(pmd, "Porcentaje", DbType.Double, xRow.Porcentaje)
                        db.AddInParameter(pmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(pmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(pmd, "Tipo", DbType.String, xRow.Tipo.ToString)

                        db.ExecuteNonQuery(pmd, Trans)
                    Next

                End If

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return 0

            Finally

                Trans.Commit()
                Conexion.Close()

            End Try

        End Using

        Return lResult

    End Function

    Public Function Consultar_PeriodoGasNatural(ByVal Periodo As ETPeriodo) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_GasNatural)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CosteoActivo = New ETCosteoActivo
                    With Entidad.CosteoActivo
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                        .Tipo = 2
                    End With

                    lResult.Ls_PeriodoGasNatural.Add(Entidad.CosteoActivo)
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

    Public Function Consultar_PeriodoGasNatural_LinProd(ByVal Periodo As ETPeriodo) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_GasNatural_LinProd)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.LineaNegocio = New ETLineaNegocio
                    With Entidad.LineaNegocio
                        .IDCatalogo = dr.GetInt32(dr.GetOrdinal("LinProd"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje"))
                        .Tipo = dr.GetInt16(dr.GetOrdinal("Tipo"))
                    End With

                    lResult.Ls_PeriodoGasNaturalLineaProduccion.Add(Entidad.LineaNegocio)
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
