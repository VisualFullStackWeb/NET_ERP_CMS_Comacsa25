Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DARuma

    Public Function ConsultarRuma1() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarRuma)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista



            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Ruma = New ETRuma
                    With Entidad.Ruma
                        .CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    End With
                    lResult.Ls_Ruma.Add(Entidad.Ruma)
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

    Public Function ConsultaRumaSeteos(ByVal Rpt As ETRuma) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarSeteoRumas)
        cmd.CommandTimeout = 60000
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@opcion", DbType.String, Rpt.tipograf)
            db.AddInParameter(cmd, "@año", DbType.String, Rpt.YearStr)
            db.AddInParameter(cmd, "@mes", DbType.String, Rpt.MesStr)
            db.AddInParameter(cmd, "@ruma", DbType.String, Rpt.CodRuma)
            db.AddInParameter(cmd, "@cantidad", DbType.Double, Rpt.CantidadSubRecurso)
            db.AddInParameter(cmd, "@usuario", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "@fecha", DbType.Date, Rpt.Fecha)
            db.AddInParameter(cmd, "@rotacion", DbType.String, Rpt.TipoRecibo)
            db.AddInParameter(cmd, "@observaciones", DbType.String, Rpt.Operacion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultaRumaSeteos = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    Public Function ConsultarMineral1() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarMineral)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista



            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Ruma = New ETRuma
                    With Entidad.Ruma
                        .CodRuma = dr.GetString(dr.GetOrdinal("cod_prod"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("descrip"))
                    End With
                    lResult.Ls_Ruma.Add(Entidad.Ruma)
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

    Public Function ConsultarRuma2(ByVal P As ETProducto) As List(Of ETRuma)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarRuma)
        Dim lst As New List(Of ETRuma)
        Dim E As ETRuma = Nothing

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 2)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodPlanta", DbType.String, P.CodPlanta)
            db.AddInParameter(cmd, "CodAlmacen", DbType.String, P.CodAlmacen)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read
                    E = New ETRuma
                    E.CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion1"))
                    E.InstMineral.CodMineral = dr.GetString(dr.GetOrdinal("CodMineral"))
                    E.InstMineral.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion2"))
                    E.InstMineral.Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                    lst.Add(E)
                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst
    End Function

    Public Function CuadroxOrdenxRuma(ByVal P As ETProducto) As List(Of ETRuma)

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.CuadroxOrdenxRuma)
        Dim lst As New List(Of ETRuma)
        Dim E As ETRuma = Nothing

        Try

            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, P.ID)
            db.AddInParameter(cmd, "CodProducto", DbType.String, P.CodProducto)
            db.AddInParameter(cmd, "Cantidad", DbType.Decimal, P.Cantidad)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETRuma
                    E.ID = dr.GetInt32(dr.GetOrdinal("CodEnlace"))
                    E.CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("DesRuma"))
                    E.Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje"))
                    E.Humedad = dr.GetDecimal(dr.GetOrdinal("Humedad"))
                    E.Merma = dr.GetDecimal(dr.GetOrdinal("Merma"))
                    E.CostoxRuma = dr.GetDecimal(dr.GetOrdinal("CostoxRuma"))
                    E.CostoxFlete = dr.GetDecimal(dr.GetOrdinal("CostoxFlete"))
                    lst.Add(E)

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst

    End Function

    Public Function CuadroxOrdenxRumaxProductoxSuministro(ByVal P As ETProducto) As List(Of ETRuma)

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.CuadroxOrdenxRumaxProdTerminadoxSuministro)
        Dim lst As New List(Of ETRuma)
        Dim E As ETRuma = Nothing

        Try

            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, P.ID)
            db.AddInParameter(cmd, "CodProducto", DbType.String, P.CodProducto)
            db.AddInParameter(cmd, "Cantidad", DbType.Decimal, P.Cantidad)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, P.FechaTerminacion)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETRuma
                    E.TipoEnlace = dr.GetString(dr.GetOrdinal("TipoEnlace"))
                    E.ID = dr.GetInt32(dr.GetOrdinal("CodEnlace"))
                    E.CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                    E.DesRuma = dr.GetString(dr.GetOrdinal("DesRuma"))
                    E.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    E.Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje"))
                    E.Humedad = dr.GetDecimal(dr.GetOrdinal("Humedad"))
                    E.Merma = dr.GetDecimal(dr.GetOrdinal("Merma"))
                    E.StockRuma = dr.GetDecimal(dr.GetOrdinal("StockRecurso"))
                    E.StockMineral = dr.GetDecimal(dr.GetOrdinal("StockSubRecurso"))
                    E.CostoxExtraccion = dr.GetDecimal(dr.GetOrdinal("CostoxExtraccion"))
                    E.CostoxCompra = dr.GetDecimal(dr.GetOrdinal("CostoxCompra"))
                    E.CostoxRegalias = dr.GetDecimal(dr.GetOrdinal("CostoxRegalias"))
                    E.CostoxFlete = dr.GetDecimal(dr.GetOrdinal("CostoxFlete"))
                    E.CostoxOtros = dr.GetDecimal(dr.GetOrdinal("CostoxOtros"))
                    E.CostoxRuma = dr.GetDecimal(dr.GetOrdinal("CostoxTON"))
                    lst.Add(E)

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst

    End Function

    Public Function CuadroxOrdenxRumaxProductoxSuministro_Relacion(ByVal P As ETProducto) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.CuadroxOrdenxRumaxProdTerminadoxSuministro)
        Dim lst As New List(Of ETRuma)
        Dim E As ETRuma = Nothing
        Dim Ds As New DataSet
        Dim lResult As New ETMyLista

        Try

            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, P.ID)
            db.AddInParameter(cmd, "CodProducto", DbType.String, P.CodProducto)
            db.AddInParameter(cmd, "Cantidad", DbType.Decimal, P.Cantidad)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, P.FechaTerminacion)

            Ds = db.ExecuteDataSet(cmd)

            lResult.DataTable1 = Ds.Tables(1)
            lResult.DataTable2 = Ds.Tables(2)

            For Each xRow As DataRow In Ds.Tables(0).Rows

                If xRow("TipoEnlace") <> "RUMA" Then

                    E = New ETRuma
                    E.TipoEnlace = xRow("TipoEnlace")
                    E.ID = xRow("CodEnlace")
                    E.CodRuma = xRow("CodRuma")
                    E.DesRuma = xRow("DesRuma")
                    E.Codigo = xRow("Codigo")
                    E.Descripcion = xRow("Descripcion")

                    E.Porcentaje = xRow("Porcentaje")
                    E.Humedad = xRow("Humedad")
                    E.Merma = xRow("Merma")

                    E.StockRuma = xRow("StockRecurso")
                    E.CostoxRuma = xRow("CostoxTON")
                    lResult.Ls_Ruma.Add(E)
                    If xRow("TipoEnlace") = "PRODUCTO" Then
                        lResult.Ls_Formulacion_Producto.Add(E)
                    ElseIf xRow("TipoEnlace") = "SUMINISTRO" Then
                        lResult.Ls_Formulacion_Suministro.Add(E)
                    ElseIf xRow("TipoEnlace") = "RECIRCULADO" Then
                        lResult.Ls_Formulacion_Recirculado.Add(E)
                    End If
                End If
            Next

            If (Ds.Tables(0).Rows.Count + Ds.Tables(1).Rows.Count + Ds.Tables(2).Rows.Count) > 0 Then
                lResult.Validacion = True
            End If
            
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lResult

    End Function

    Public Function CuadroxOrdenxRumaxMineral(ByVal P As ETProducto) As List(Of ETRuma)

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.CuadroxOrdenxRumaxMineral)
        Dim lst As New List(Of ETRuma)
        Dim E As ETRuma = Nothing

        Try

            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Ruma", DbType.String, P.CodProducto)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, P.FechaTerminacion)

            Using Dr As IDataReader = db.ExecuteReader(cmd)
                While Dr.Read
                    E = New ETRuma
                    E.CodRuma = Dr.GetString(Dr.GetOrdinal("CodRuma"))
                    E.Codigo = Dr.GetString(Dr.GetOrdinal("Codigo"))
                    E.Descripcion = Dr.GetString(Dr.GetOrdinal("Descripcion"))
                    E.Porcentaje = Dr.GetDecimal(Dr.GetOrdinal("Porcentaje"))
                    E.Humedad = Dr.GetDecimal(Dr.GetOrdinal("Humedad"))
                    E.Merma = Dr.GetDecimal(Dr.GetOrdinal("Merma"))
                    E.StockRuma = Dr.GetDecimal(Dr.GetOrdinal("StockRecurso"))
                    E.StockMineral = Dr.GetDecimal(Dr.GetOrdinal("StockSubRecurso"))
                    E.CostoxExtraccion = Dr.GetDecimal(Dr.GetOrdinal("CostoxExtraccion"))
                    E.CostoxCompra = Dr.GetDecimal(Dr.GetOrdinal("CostoxCompra"))
                    E.CostoxRegalias = Dr.GetDecimal(Dr.GetOrdinal("CostoxRegalias"))
                    E.CostoxFlete = Dr.GetDecimal(Dr.GetOrdinal("CostoxFlete"))
                    E.CostoxOtros = Dr.GetDecimal(Dr.GetOrdinal("CostoxOtros"))
                    E.CostoxRuma = Dr.GetDecimal(Dr.GetOrdinal("CostoxRuma"))
                    lst.Add(E)
                End While
                If Not Dr Is Nothing Then
                    Dr.Close()
                End If
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst

    End Function

    Public Function CuadroxOrdenxProductoxSuministro(ByVal P As ETProducto) As List(Of ETRuma)

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.CuadroxOrdenxProdTerminadoxSuministro)
        Dim lst As New List(Of ETRuma)
        Dim E As ETRuma = Nothing

        Try

            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, P.ID)
            db.AddInParameter(cmd, "CodProducto", DbType.String, P.CodProducto)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, P.FechaTerminacion)
            db.AddInParameter(cmd, "Tipo", DbType.String, P.TipoProducto)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETRuma
                    E.TipoEnlace = dr.GetString(dr.GetOrdinal("TipoEnlace"))
                    E.ID = dr.GetInt32(dr.GetOrdinal("CodEnlace"))
                    E.CodRuma = dr.GetString(dr.GetOrdinal("Codigo"))
                    E.DesRuma = dr.GetString(dr.GetOrdinal("Descripcion"))
                    E.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    E.StockRuma = dr.GetDecimal(dr.GetOrdinal("StockRecurso"))
                    E.CostoxRuma = dr.GetDecimal(dr.GetOrdinal("CostoxTON"))
                    lst.Add(E)

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst

    End Function
End Class
