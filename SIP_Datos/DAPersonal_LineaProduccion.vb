Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAPersonal_LineaProduccion

    Public Function Mantto_Personal_LineaProd(ByVal Periodo As ETPeriodo, _
                                              ByVal Detalle As List(Of ETPersonalLineaProduccion), _
                                              ByVal Anulado As List(Of ETPersonalLineaProduccion)) As Integer

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
                db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.TipoPeriodo)
                db.AddInParameter(cmd, "status", DbType.String, Periodo.Status)
                db.AddInParameter(cmd, "User", DbType.String, Periodo.Usuario)
                db.AddInParameter(cmd, "TipoSQL", DbType.String, Periodo.Tipo.ToString)


                lResult = db.ExecuteScalar(cmd, Trans)

                If Not (Periodo.Tipo = 3) Then
                    For Each xRow As ETPersonalLineaProduccion In Anulado
                        Dim dxmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Personal_LineaProduccion)
                        db.AddInParameter(dxmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(dxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(dxmd, "Personal", DbType.String, xRow.Codigo)
                        db.AddInParameter(dxmd, "LinProd", DbType.Int32, xRow.LinProd)
                        db.AddInParameter(dxmd, "Porcentaje", DbType.Double, xRow.Porcentaje)
                        db.AddInParameter(dxmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(dxmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(dxmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.AddInParameter(dxmd, "Asigna", DbType.String, xRow.Asigna.ToString)
                        db.ExecuteNonQuery(dxmd, Trans)
                    Next

                    For Each xRow As ETPersonalLineaProduccion In Detalle
                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Personal_LineaProduccion)

                        db.AddInParameter(xmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(xmd, "Personal", DbType.String, xRow.Codigo)
                        db.AddInParameter(xmd, "LinProd", DbType.Int32, xRow.LinProd)
                        db.AddInParameter(xmd, "Porcentaje", DbType.Double, xRow.Porcentaje)
                        db.AddInParameter(xmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(xmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.AddInParameter(xmd, "Asigna", DbType.String, xRow.Asigna.ToString)
                        db.ExecuteNonQuery(xmd, Trans)
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


    Public Function Consultar_Personal_LinProd(ByVal Periodo As ETPeriodo) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Personal_LineaProduccion)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")
            db.AddInParameter(cmd, "Asigna", DbType.String, "")


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Personal_LinProd = New ETPersonalLineaProduccion
                    With Entidad.Personal_LinProd
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .CodLinProd = dr.GetString(dr.GetOrdinal("CodLinProd"))
                        .LineaProduccion = dr.GetString(dr.GetOrdinal("LineaProduccion"))
                        .Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje"))
                        .LinProd = dr.GetInt32(dr.GetOrdinal("LinProd"))
                        .Periodo = Periodo.Periodo
                        .Tipo = 2
                        .Asigna = dr.GetString(dr.GetOrdinal("Asigna"))
                    End With

                    lResult.Ls_Personal_LinProd.Add(Entidad.Personal_LinProd)
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
