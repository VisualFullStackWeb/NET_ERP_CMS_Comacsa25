Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DALineaProduccion
    Public Function ManttoLineaProduccion(ByVal LineaProduccion As ETLineaNegocio, ByVal Productos As List(Of ETLineaNegocio), ByVal Procesos As List(Of ETLineaNegocio)) As Integer
        Dim lResult As ETLineaNegocio = Nothing
        If LineaProduccion Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Linea_Produccion)
                db.AddInParameter(cmd, "LinProd", DbType.Int32, LineaProduccion.IDCatalogo)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Codigo", DbType.Int32, Val(LineaProduccion.Codigo))
                db.AddInParameter(cmd, "Descripción", DbType.String, LineaProduccion.Descripcion)
                db.AddInParameter(cmd, "status", DbType.String, LineaProduccion.Status)
                db.AddInParameter(cmd, "User", DbType.String, LineaProduccion.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, LineaProduccion.Tipo.ToString)
                lResult = New ETLineaNegocio
                lResult.IDCatalogo = db.ExecuteScalar(cmd, Trans)

                If LineaProduccion.Tipo = 1 OrElse LineaProduccion.Tipo = 2 Then
                    For Each xRow As ETLineaNegocio In Productos
                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Linea_Produccion_Productos)
                        db.AddInParameter(xmd, "LinProd", DbType.Int32, lResult.IDCatalogo)
                        db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(xmd, "Cod_Prod", DbType.String, xRow.Codigo)
                        db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(xmd, "Tipo", DbType.String, xRow.Tipo.ToString)

                        If xRow.Action = True Then
                            db.AddInParameter(xmd, "status", DbType.String, "")
                            db.ExecuteNonQuery(xmd, Trans)
                        ElseIf xRow.IDCatalogo > 0 Then
                            db.AddInParameter(xmd, "status", DbType.String, "*")
                            db.ExecuteNonQuery(xmd, Trans)
                        End If

                    Next

                    For Each xRow As ETLineaNegocio In Procesos
                        Dim ymd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Linea_Produccion_ProcesoProductivo)
                        db.AddInParameter(ymd, "LinProd", DbType.Int32, lResult.IDCatalogo)
                        db.AddInParameter(ymd, "Proceso", DbType.String, xRow.IDCatalogo)
                        db.AddInParameter(ymd, "Orden", DbType.String, xRow.Orden)
                        db.AddInParameter(ymd, "User", DbType.String, xRow.Usuario)
                        If xRow.Action = True Then
                            db.AddInParameter(ymd, "status", DbType.String, "")
                            db.ExecuteNonQuery(ymd, Trans)
                        ElseIf xRow.IDCatalogo > 0 Then
                            db.AddInParameter(ymd, "status", DbType.String, "*")
                            db.ExecuteNonQuery(ymd, Trans)
                        End If
                    Next

                End If

                lResult.Respuesta = 1
            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            Finally

                Trans.Commit()
                Conexion.Close()

            End Try

        End Using

        Return lResult.Respuesta


    End Function

    Public Function ConsultarLineaProduccion() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Linea_Produccion)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.LineaNegocio = New ETLineaNegocio
                    Entidad.LineaNegocio.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.LineaNegocio.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.LineaNegocio.Estado = dr.GetString(dr.GetOrdinal("Estado"))
                    Entidad.LineaNegocio.Status = dr.GetString(dr.GetOrdinal("status"))
                    Entidad.LineaNegocio.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    lResult.Ls_Linea_Produccion.Add(Entidad.LineaNegocio)
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

    Public Function ConsultarLineaProduccion_Productos(ByVal LineaProduccion As ETLineaNegocio) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Linea_Produccion_Productos)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, LineaProduccion.IDCatalogo)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.LineaNegocio = New ETLineaNegocio
                    With Entidad.LineaNegocio
                        .Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Tipo = dr.GetInt16(dr.GetOrdinal("Tipo"))
                        .IDCatalogo = dr.GetInt32(dr.GetOrdinal("LinProd"))
                    End With
                    
                    lResult.Ls_LineaProduccion_Productos.Add(Entidad.LineaNegocio)
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

    Public Function ConsultarLineaProduccion_Procesos(ByVal LineaProduccion As ETLineaNegocio) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Linea_Produccion)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, LineaProduccion.IDCatalogo)
            db.AddInParameter(cmd, "Tipo", DbType.String, "5")


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.LineaNegocio = New ETLineaNegocio
                    With Entidad.LineaNegocio
                        .Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                        .Orden = dr.GetInt32(dr.GetOrdinal("Orden"))
                    End With

                    lResult.Ls_LineaProduccion_Proceso.Add(Entidad.LineaNegocio)
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

    Public Function Mantto_ProcesoProducto(ByVal Proceso As ETLineaNegocio) As Integer
        Dim lResult As ETLineaNegocio = Nothing
        If Proceso Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ProcesoProductivo)
                db.AddInParameter(cmd, "Proceso", DbType.Int32, Proceso.IDCatalogo)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Codigo", DbType.Int32, Val(Proceso.Codigo))
                db.AddInParameter(cmd, "Descripción", DbType.String, Proceso.Descripcion)
                db.AddInParameter(cmd, "status", DbType.String, Proceso.Status)
                db.AddInParameter(cmd, "User", DbType.String, Proceso.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, Proceso.Tipo.ToString)
                lResult = New ETLineaNegocio
                lResult.IDCatalogo = db.ExecuteScalar(cmd, Trans)

                lResult.Respuesta = 1
            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            Finally

                Trans.Commit()
                Conexion.Close()

            End Try

        End Using

        Return lResult.Respuesta


    End Function

    Public Function Consultar_ProcesoProductivo() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ProcesoProductivo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.LineaNegocio = New ETLineaNegocio
                    Entidad.LineaNegocio.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.LineaNegocio.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.LineaNegocio.Estado = dr.GetString(dr.GetOrdinal("Estado"))
                    Entidad.LineaNegocio.Status = dr.GetString(dr.GetOrdinal("status"))
                    Entidad.LineaNegocio.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    lResult.Ls_Linea_Produccion.Add(Entidad.LineaNegocio)
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
