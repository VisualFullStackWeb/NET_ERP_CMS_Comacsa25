Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAPeriodoPlantaCemento
    Public Function Mantto_Periodo_PlantaCemento(ByVal Periodo As ETPeriodo, _
                                        ByVal PC_UnidadProd As List(Of ETActivo), _
                                        ByVal PC_UnidadProd_Del As List(Of ETActivo), _
                                        ByVal PC_Mineral As List(Of ETProducto), _
                                        ByVal PC_Mineral_Del As List(Of ETProducto), _
                                        ByVal PC_Suministro As List(Of ETProducto), _
                                        ByVal PC_Suministro_Del As List(Of ETProducto), _
                                        ByVal PC_ManoObra As List(Of ETPersonal), _
                                        ByVal PC_ManoObra_Del As List(Of ETPersonal)) As Integer

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

                If Not (Periodo.Tipo = 3 Or Periodo.Tipo = 7) Then
                    For Each xRow As ETActivo In PC_UnidadProd_Del
                        Dim dxmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_UnidadProduccion)
                        db.AddInParameter(dxmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(dxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(dxmd, "UnidadProduccion", DbType.String, xRow.Codigo)
                        db.AddInParameter(dxmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(dxmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(dxmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.ExecuteNonQuery(dxmd, Trans)
                    Next

                    For Each xRow As ETActivo In PC_UnidadProd
                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_UnidadProduccion)

                        db.AddInParameter(xmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(xmd, "UnidadProduccion", DbType.String, xRow.Codigo)
                        db.AddInParameter(xmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(xmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.ExecuteNonQuery(xmd, Trans)
                    Next

                    For Each xRow As ETProducto In PC_Mineral_Del
                        Dim dxmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_Mineral)
                        db.AddInParameter(dxmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(dxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(dxmd, "UnidadProduccion", DbType.String, xRow.CodPlanta)
                        db.AddInParameter(dxmd, "Mineral", DbType.String, xRow.CodProducto)
                        db.AddInParameter(dxmd, "Tonelaje", DbType.Double, xRow.Cantidad)
                        db.AddInParameter(dxmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(dxmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(dxmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.ExecuteNonQuery(dxmd, Trans)
                    Next

                    For Each xRow As ETProducto In PC_Mineral
                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_Mineral)

                        db.AddInParameter(xmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(xmd, "UnidadProduccion", DbType.String, xRow.CodPlanta)
                        db.AddInParameter(xmd, "Mineral", DbType.String, xRow.CodProducto)
                        db.AddInParameter(xmd, "Tonelaje", DbType.Double, xRow.Cantidad)
                        db.AddInParameter(xmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(xmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.ExecuteNonQuery(xmd, Trans)
                    Next

                    For Each xRow As ETProducto In PC_Suministro_Del
                        Dim dxmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_Suministro)
                        db.AddInParameter(dxmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(dxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(dxmd, "UnidadProduccion", DbType.String, xRow.CodPlanta)
                        db.AddInParameter(dxmd, "Suministro", DbType.String, xRow.CodProducto)
                        db.AddInParameter(dxmd, "Cantidad", DbType.Double, xRow.Cantidad)
                        db.AddInParameter(dxmd, "UniMed", DbType.String, xRow.Unidad)
                        db.AddInParameter(dxmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(dxmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(dxmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.ExecuteNonQuery(dxmd, Trans)
                    Next

                    For Each xRow As ETProducto In PC_Suministro
                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_Suministro)

                        db.AddInParameter(xmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(xmd, "UnidadProduccion", DbType.String, xRow.CodPlanta)
                        db.AddInParameter(xmd, "Suministro", DbType.String, xRow.CodProducto)
                        db.AddInParameter(xmd, "Cantidad", DbType.Double, xRow.Cantidad)
                        db.AddInParameter(xmd, "UniMed", DbType.String, xRow.Unidad)
                        db.AddInParameter(xmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(xmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.ExecuteNonQuery(xmd, Trans)
                    Next


                    For Each xRow As ETPersonal In PC_ManoObra_Del
                        Dim dxmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_ManoObra)

                        db.AddInParameter(dxmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(dxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(dxmd, "UnidadProduccion", DbType.String, xRow.Cargo)
                        db.AddInParameter(dxmd, "Personal", DbType.String, xRow.CodPersonal)
                        db.AddInParameter(dxmd, "Horas", DbType.Double, xRow.HorasTrab)
                        db.AddInParameter(dxmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(dxmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(dxmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                        db.ExecuteNonQuery(dxmd, Trans)
                    Next

                    For Each xRow As ETPersonal In PC_ManoObra
                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_ManoObra)

                        db.AddInParameter(xmd, "Periodo", DbType.Int32, lResult)
                        db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(xmd, "UnidadProduccion", DbType.String, xRow.Cargo)
                        db.AddInParameter(xmd, "Personal", DbType.String, xRow.CodPersonal)
                        db.AddInParameter(xmd, "Horas", DbType.Double, xRow.HorasTrab)
                        db.AddInParameter(xmd, "status", DbType.String, xRow.Status)
                        db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(xmd, "Tipo", DbType.String, xRow.Tipo.ToString)
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

    Public Function Consultar_Periodo_UnidadProduccion(ByVal Periodo As ETPeriodo) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_UnidadProduccion)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Activo = New ETActivo
                    With Entidad.Activo
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Tipo = 2
                    End With

                    lResult.Ls_Activo.Add(Entidad.Activo)
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

    Public Function Consultar_Periodo_Minerales(ByVal Periodo As ETPeriodo) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_Mineral)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "UnidadProduccion", DbType.String, Periodo.VarFiltrar)
            db.AddInParameter(cmd, "Tipo", DbType.String, Periodo.Tipo.ToString)


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Producto = New ETProducto
                    With Entidad.Producto
                        .CodPlanta = dr.GetString(dr.GetOrdinal("UnidadProduccion"))
                        .CodProducto = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                        .Tipo = 2
                    End With

                    lResult.Ls_Producto.Add(Entidad.Producto)
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

    Public Function Consultar_Periodo_Suministros(ByVal Periodo As ETPeriodo) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_Suministro)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "UnidadProduccion", DbType.String, Periodo.VarFiltrar)
            db.AddInParameter(cmd, "Tipo", DbType.String, Periodo.Tipo.ToString)


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Producto = New ETProducto
                    With Entidad.Producto
                        .CodPlanta = dr.GetString(dr.GetOrdinal("UnidadProduccion"))
                        .CodProducto = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                        .Unidad = dr.GetString(dr.GetOrdinal("UniMed"))
                        .Tipo = 2
                    End With

                    lResult.Ls_Producto.Add(Entidad.Producto)
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

    Public Function Consultar_Periodo_ManoObra(ByVal Periodo As ETPeriodo) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_ManoObra)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Periodo", DbType.Int32, Periodo.Periodo)
            db.AddInParameter(cmd, "UnidadProduccion", DbType.String, Periodo.VarFiltrar)
            db.AddInParameter(cmd, "Tipo", DbType.String, Periodo.Tipo.ToString)


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Personal = New ETPersonal
                    With Entidad.Personal
                        .Cargo = dr.GetString(dr.GetOrdinal("UnidadProduccion"))
                        .CodPersonal = dr.GetString(dr.GetOrdinal("Codigo"))
                        .DesPersonal = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .HorasTrab = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                        .Tipo = dr.GetInt16(dr.GetOrdinal("Tipo"))
                    End With

                    lResult.Ls_Personal.Add(Entidad.Personal)
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

    Public Function Consultar_Periodo_OtrosCostos(ByVal UnidadProduccion As ETCosteoActivo) As Double
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Periodo_PlantaCemento_Otros)
        Dim lResult As Double = 0
        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "UnidadProduccion", DbType.String, UnidadProduccion.Codigo)
            db.AddInParameter(cmd, "Fecha", DbType.Date, UnidadProduccion.Fecha)
            db.AddInParameter(cmd, "Tipo", DbType.String, UnidadProduccion.Tipo.ToString)

            lResult = db.ExecuteScalar(cmd)

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult
    End Function
End Class
