Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAProducto

    Public Function ConsultarPermisoStockMinimo(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarPermisoStockMinimo)

        Try

            db.AddInParameter(cmd, "NAME_USER", DbType.String, Rpt.Usuario)

            lResult = New ETMyLista

            If Convert.ToBoolean(db.ExecuteScalar(cmd)) Then lResult.Validacion = Boolean.TrueString

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult

    End Function
    Public Function ConsultarSubfamilia(ByVal P As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarSubfamilia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Opcion", DbType.String, P.Accion)
            db.AddInParameter(cmd, "idfamilia", DbType.String, P.familia)
            db.AddInParameter(cmd, "idSubFamilia", DbType.String, P.SubFamilia)
            db.AddInParameter(cmd, "descrip", DbType.String, P.Descripcion)
            db.AddInParameter(cmd, "estado", DbType.String, P.Estado)
            db.AddInParameter(cmd, "usuario", DbType.String, P.Usuario)
            db.AddInParameter(cmd, "fecha", DbType.String, P.Fecha)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarSubfamilia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    Public Function Consultarfamilia(ByVal P As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Consultarfamilia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Opcion", DbType.String, P.Accion)
            db.AddInParameter(cmd, "idfamilia", DbType.String, P.Familia)
            db.AddInParameter(cmd, "descrip", DbType.String, P.Descripcion)
            db.AddInParameter(cmd, "estado", DbType.String, P.Estado)
            db.AddInParameter(cmd, "usuario", DbType.String, P.Usuario)
            db.AddInParameter(cmd, "fecha", DbType.String, P.Fecha)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Consultarfamilia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    Public Function ConsultarProducto(ByVal Rpt As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarProducto)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "PERIODO", DbType.String, Producto.Periodo)
            db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.Tipo)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarProducto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        'Dim lResult As ETMyLista = Nothing
        ''If Rpt Is Nothing Then
        ''    Return lResult
        ''End If

        'Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarProducto)

        'Try

        '    db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.Tipo)
        '    db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

        '    lResult = New ETMyLista

        '    Using dr As IDataReader = db.ExecuteReader(cmd)
        '        While dr.Read
        '            Entidad.Producto = New ETProducto
        '            With Entidad.Producto
        '                .CodProducto = dr.GetString(dr.GetOrdinal("CodProducto"))
        '                .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
        '                If Rpt.Tipo = 7 Then
        '                    .Unidad = dr.GetString(dr.GetOrdinal("UM"))
        '                End If
        '            End With
        '            lResult.Ls_Producto.Add(Entidad.Producto)
        '        End While
        '        If dr IsNot Nothing Then dr.Close()
        '        lResult.Validacion = Boolean.TrueString
        '    End Using

        'Catch Err As Exception

        '    MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        '    lResult = Nothing

        'End Try

        'Return lResult

    End Function

    Public Function ConsultarProductoxStock(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        lResult = New ETMyLista

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarStockProducto)

                db.AddInParameter(cmd, "Tipo", DbType.Int16, Rpt.Tipo)
                db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Rpt.CodProducto)
                db.AddInParameter(cmd, "CodAlmacen", DbType.String, Rpt.CodAlmacen)
                db.AddInParameter(cmd, "TipProd", DbType.String, Rpt.TipoProducto)
                db.AddInParameter(cmd, "Descripcion", DbType.String, Rpt.Descripcion)
                db.AddInParameter(cmd, "Fecha", DbType.Date, Rpt.Fecha)
                db.AddInParameter(cmd, "Anho", DbType.Int32, Rpt.Anho)
                db.AddInParameter(cmd, "Mes", DbType.Int16, Rpt.Mes)

                lResult = New ETMyLista

                Using dr As IDataReader = db.ExecuteReader(cmd, Trans)
                    While dr.Read
                        Entidad.Producto = New ETProducto
                        With Entidad.Producto
                            .CodProducto = dr.GetString(dr.GetOrdinal("CodProducto"))
                            .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                            .Peso = dr.GetDecimal(dr.GetOrdinal("Peso"))
                            .Factor = dr.GetDecimal(dr.GetOrdinal("Factor"))
                            .Unidad = dr.GetString(dr.GetOrdinal("Unidad"))
                            .StockDespacho = dr.GetDecimal(dr.GetOrdinal("StockDespacho"))
                            .StockVenta = dr.GetDecimal(dr.GetOrdinal("StockVenta"))
                            .StockPendiente = dr.GetDecimal(dr.GetOrdinal("StockPendiente"))
                            .StockMinimo = dr.GetDecimal(dr.GetOrdinal("StockMinimo"))
                            .Proyeccion = dr.GetDecimal(dr.GetOrdinal("Proyeccion"))
                            .EnProduccion = dr.GetDecimal(dr.GetOrdinal("EnProduccion"))
                            .CantidadDespachada = dr.GetDecimal(dr.GetOrdinal("CantidadDespachada"))
                        End With
                        lResult.Ls_Producto.Add(Entidad.Producto)
                    End While
                    If dr IsNot Nothing Then dr.Close()
                End Using

                lResult.Validacion = Boolean.TrueString
                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using

        Return lResult

    End Function

    Public Function ConsultarAlmacen(ByVal P As ETProducto) As List(Of ETProducto)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarAlmacen)
        Dim lst As New List(Of ETProducto)
        Dim A As ETProducto = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, P.Tipo)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodPlanta", DbType.String, P.CodPlanta)
            db.AddInParameter(cmd, "Usuario", DbType.String, P.Usuario)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    A = New ETProducto
                    A.CodAlmacen = dr.GetString(dr.GetOrdinal("CodAlmacen"))
                    A.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    lst.Add(A)

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

    Public Function ConsultarEnlace() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarEnlace)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 1)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Producto = New ETProducto
                    With Entidad.Producto
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .IDMolino = dr.GetString(dr.GetOrdinal("CodMolino"))
                        .UnidadProduccion = dr.GetString(dr.GetOrdinal("Molino"))
                        .CodProducto = dr.GetString(dr.GetOrdinal("CodProducto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .FechaCreacion = dr.GetDateTime(dr.GetOrdinal("FechaCreacion"))
                        .FechaActualizacion = dr.GetDateTime(dr.GetOrdinal("FechaActualizacion"))
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

    Public Function ConsultarProdProyectado(ByVal ayo As Int32) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarProdProyectado)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "AYO", DbType.Int32, ayo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Producto = New ETProducto
                    With Entidad.Producto
                        .ID = dr.GetInt32(dr.GetOrdinal("IDUNION"))
                        .CodProducto = dr.GetString(dr.GetOrdinal("CODIGO"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("NOMBREUNIDO"))
                        .Estado = dr.GetString(dr.GetOrdinal("ESTADO"))
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

    Public Function ConsultarBusquedaEnlace(ByVal Rpt As ETProducto) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarBusquedaEnlace)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, Rpt.Tipo)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Rpt.CodProducto)
            db.AddInParameter(cmd, "Descripcion", DbType.String, Rpt.Descripcion)
            db.AddInParameter(cmd, "Fecha1", DbType.Date, Rpt.FechaCreacion)
            db.AddInParameter(cmd, "Fecha2", DbType.Date, Rpt.FechaActualizacion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Producto = New ETProducto
                    With Entidad.Producto
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .CodProducto = dr.GetString(dr.GetOrdinal("CodProducto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .FechaCreacion = dr.GetDateTime(dr.GetOrdinal("FechaCreacion"))
                        .FechaActualizacion = dr.GetDateTime(dr.GetOrdinal("FechaActualizacion"))
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

    Public Function ConsultarEnlacexProducto(ByVal P As ETProducto) As List(Of ETProducto)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarEnlace)
        Dim lst As New List(Of ETProducto)
        Dim E As ETProducto = Nothing
        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 5)
            db.AddInParameter(cmd, "CodProducto", DbType.String, P.CodProducto)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    E = New ETProducto
                    E.ID = dr.GetInt32(dr.GetOrdinal("ID"))
                    lst.Add(E)
                End While
                If Not dr Is Nothing Then dr.Close()
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst

    End Function

    Public Function ValidarProductoOrden(ByVal Rpt As ETProducto) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ValidarProductoOrden)

        Try
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Rpt.CodProducto)
            db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

            lResult = New ETProducto
            db.ExecuteNonQuery(cmd)

            lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
            lResult.Validacion = Boolean.TrueString

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lResult

    End Function

    Public Function ConsultarEnlacexRuma(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarEnlace)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 2)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "Mes", DbType.Int32, Rpt.Mes)
            db.AddInParameter(cmd, "Año", DbType.Int32, Rpt.Anho)
            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Ruma = New ETRuma
                    Entidad.Ruma.CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                    Entidad.Ruma.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
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

    Public Function ConsultarEnlacexRumaxProducto(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarEnlace)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 6)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "Mes", DbType.Int32, Rpt.Mes)
            db.AddInParameter(cmd, "Año", DbType.Int32, Rpt.Anho)
            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Ruma = New ETRuma
                    Entidad.Ruma.CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                    Entidad.Ruma.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
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

    Public Function ConsultarEnlacexRumaxSuministro(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarEnlace)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 8)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "Mes", DbType.Int32, Rpt.Mes)
            db.AddInParameter(cmd, "Año", DbType.Int32, Rpt.Anho)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Ruma = New ETRuma
                    Entidad.Ruma.CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                    Entidad.Ruma.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
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
    Public Function ConsultarEnlacexDetalle() As List(Of ETRuma)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarEnlace)
        Dim lst As New List(Of ETRuma)
        Dim E As ETRuma = Nothing
        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 3)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETRuma
                    E.ID = dr.GetInt32(dr.GetOrdinal("ID"))
                    E.CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
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

    Public Function ConsultarEnlacexFormula(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarEnlace)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 4)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, Rpt.CodEnlace)
            db.AddInParameter(cmd, "Mes", DbType.Int32, Rpt.Mes)
            db.AddInParameter(cmd, "Año", DbType.Int32, Rpt.Anho)
            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Ruma = New ETRuma
                    Entidad.Ruma.CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                    Entidad.Ruma.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.Ruma.Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje"))
                    Entidad.Ruma.Humedad = dr.GetDecimal(dr.GetOrdinal("Humedad"))
                    Entidad.Ruma.Merma = dr.GetDecimal(dr.GetOrdinal("Merma"))
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

    Public Function ConsultarEnlacexFormulaxProducto(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarEnlace)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 7)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, Rpt.CodEnlace)
            db.AddInParameter(cmd, "Mes", DbType.Int32, Rpt.Mes)
            db.AddInParameter(cmd, "Año", DbType.Int32, Rpt.Anho)
            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Ruma = New ETRuma
                    Entidad.Ruma.CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                    Entidad.Ruma.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.Ruma.Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje"))
                    Entidad.Ruma.Humedad = dr.GetDecimal(dr.GetOrdinal("Humedad"))
                    Entidad.Ruma.Merma = dr.GetDecimal(dr.GetOrdinal("Merma"))
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

    Public Function ConsultarEnlacexFormulaxSuministro(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarEnlace)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 9)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, Rpt.CodEnlace)
            db.AddInParameter(cmd, "Mes", DbType.Int32, Rpt.Mes)
            db.AddInParameter(cmd, "Año", DbType.Int32, Rpt.Anho)
            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Ruma = New ETRuma
                    Entidad.Ruma.CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                    Entidad.Ruma.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.Ruma.Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje"))
                    Entidad.Ruma.Humedad = dr.GetDecimal(dr.GetOrdinal("Humedad"))
                    Entidad.Ruma.Merma = dr.GetDecimal(dr.GetOrdinal("Merma"))
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

    Public Function ConsultarProyeccion_1(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarProyeccion)

        Try
            db.AddInParameter(cmd, "Tipo", DbType.String, 1)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Anho", DbType.Int16, Rpt.Anho)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Rpt.Mes)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Producto = New ETProducto
                    Entidad.Producto.CodProducto = dr.GetString(dr.GetOrdinal("CodProducto"))
                    Entidad.Producto.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.Producto.Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                    lResult.Ls_Producto.Add(Entidad.Producto)
                End While
                lResult.Validacion = Boolean.TrueString
                If dr IsNot Nothing Then dr.Close()
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function

    Public Function MantenimientoProyeccion(ByVal Rpt As ETProducto, ByVal Lista As List(Of ETProducto)) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing OrElse Lista Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        lResult = New ETProducto

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxProyeccion)

                db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
                db.AddInParameter(cmd, "Anho", DbType.String, Rpt.Anho)
                db.AddInParameter(cmd, "Mes", DbType.String, Rpt.Mes)
                db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.AddOutParameter(cmd, "ID", DbType.Int32, 11)

                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                lResult.ID = Convert.ToInt32(db.GetParameterValue(cmd, "ID"))

                If lResult.Respuesta <> 0 OrElse lResult.ID = 0 Then Err.Raise(10)

                For Each Entidad.Producto In Lista

                    Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxProyeccion)

                    db.AddInParameter(xmd, "Tipo", DbType.Int16, 2)
                    db.AddInParameter(xmd, "ID", DbType.Int32, lResult.ID)
                    db.AddInParameter(xmd, "CodProducto", DbType.String, Entidad.Producto.CodProducto)
                    db.AddInParameter(xmd, "Cantidad", DbType.String, Entidad.Producto.Cantidad)
                    db.AddInParameter(xmd, "Usuario", DbType.String, Rpt.Usuario)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)

                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                    If lResult.Respuesta <> 0 Then Err.Raise(10)

                Next

                lResult.Validacion = Boolean.TrueString
                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using

        Return lResult

    End Function

    Public Function MantenimientoFormula(ByVal Rpt As ETProducto, ByVal Ls_Ruma As List(Of ETRuma), _
                                         ByVal Ls_RumaProd As List(Of ETRuma), _
                                         ByVal Ls_RumaSuministro As List(Of ETRuma)) As ETProducto


        Dim lResult As ETProducto = Nothing

        If Rpt Is Nothing OrElse (Ls_Ruma Is Nothing And Ls_RumaProd Is Nothing And Ls_RumaSuministro Is Nothing) Then
            Return lResult
        End If


        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETProducto

                Dim cmd_e As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxEnlace)

                db.AddInParameter(cmd_e, "Tipo", DbType.Int16, 1)
                db.AddInParameter(cmd_e, "ID", DbType.Int32, Rpt.ID)
                db.AddInParameter(cmd_e, "CodMolino", DbType.String, Rpt.IDMolino)
                db.AddInParameter(cmd_e, "CodProducto", DbType.String, Rpt.CodProducto)
                db.AddInParameter(cmd_e, "Usuario", DbType.String, Rpt.Usuario)
                db.AddInParameter(cmd_e, "Fecha", DbType.String, Rpt.Fecha)
                db.AddInParameter(cmd_e, "Masivo", DbType.Boolean, Rpt.Update)
                db.AddInParameter(cmd_e, "Mes", DbType.String, Rpt.Mes)
                db.AddInParameter(cmd_e, "Año", DbType.String, Rpt.Anho)
                db.AddOutParameter(cmd_e, "Respuesta", DbType.Int16, 10)
                db.AddOutParameter(cmd_e, "Valor", DbType.Int32, 11)
                db.ExecuteNonQuery(cmd_e, Trans)

                lResult.ID = Convert.ToInt32(db.GetParameterValue(cmd_e, "Valor"))
                If lResult.ID > 0 Then
                    Rpt.ID = lResult.ID
                End If

                If Ls_Ruma IsNot Nothing Then
                    For Each Row In Ls_Ruma

                        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxFormula)

                        db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
                        db.AddInParameter(cmd, "CodEnlace", DbType.Int32, Rpt.ID)
                        db.AddInParameter(cmd, "CodRuma", DbType.String, Row.CodRuma)
                        db.AddInParameter(cmd, "Porcentaje", DbType.Decimal, Row.Porcentaje)
                        db.AddInParameter(cmd, "Humedad", DbType.Decimal, Row.Humedad)
                        db.AddInParameter(cmd, "Merma", DbType.Decimal, Row.Merma)
                        db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                        db.AddInParameter(cmd, "Mes", DbType.String, Rpt.Mes)
                        db.AddInParameter(cmd, "Año", DbType.String, Rpt.Anho)
                        db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

                        db.ExecuteNonQuery(cmd, Trans)

                        lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                        If lResult.Respuesta <> 0 Then Err.Raise(10)

                        If Rpt.Update = True Then
                            Dim cmd_m1 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxFormula_Masivo)
                            db.AddInParameter(cmd_m1, "Tipo", DbType.Int16, 1)

                            db.AddInParameter(cmd_m1, "CodEnlace", DbType.Int32, Rpt.ID)
                            db.AddInParameter(cmd_m1, "Cod_Prod", DbType.String, Rpt.CodProducto)
                            db.AddInParameter(cmd_m1, "CodRuma", DbType.String, Row.CodRuma)
                            db.AddInParameter(cmd_m1, "Porcentaje", DbType.Decimal, Row.Porcentaje)
                            db.AddInParameter(cmd_m1, "Humedad", DbType.Decimal, Row.Humedad)
                            db.AddInParameter(cmd_m1, "Merma", DbType.Decimal, Row.Merma)
                            db.AddInParameter(cmd_m1, "Usuario", DbType.String, Rpt.Usuario)
                            db.ExecuteNonQuery(cmd_m1, Trans)
                        End If

                    Next
                End If

                If Ls_RumaProd IsNot Nothing Then
                    For Each Row In Ls_RumaProd

                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxFormula)

                        db.AddInParameter(xmd, "Tipo", DbType.Int16, 2)
                        db.AddInParameter(xmd, "CodEnlace", DbType.Int32, Rpt.ID)
                        db.AddInParameter(xmd, "CodRuma", DbType.String, Row.CodRuma)
                        db.AddInParameter(xmd, "Porcentaje", DbType.Decimal, Row.Porcentaje)
                        db.AddInParameter(xmd, "Humedad", DbType.Decimal, Row.Humedad)
                        db.AddInParameter(xmd, "Merma", DbType.Decimal, Row.Merma)
                        db.AddInParameter(xmd, "Usuario", DbType.String, Rpt.Usuario)
                        db.AddInParameter(xmd, "Mes", DbType.String, Rpt.Mes)
                        db.AddInParameter(xmd, "Año", DbType.String, Rpt.Anho)
                        db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)

                        db.ExecuteNonQuery(xmd, Trans)

                        lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                        If lResult.Respuesta <> 0 Then Err.Raise(10)

                        If Rpt.Update = True Then
                            Dim cmd_m2 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxFormula_Masivo)
                            db.AddInParameter(cmd_m2, "Tipo", DbType.Int16, 2)
                            db.AddInParameter(cmd_m2, "CodEnlace", DbType.Int32, Rpt.ID)
                            db.AddInParameter(cmd_m2, "Cod_Prod", DbType.String, Rpt.CodProducto)
                            db.AddInParameter(cmd_m2, "CodRuma", DbType.String, Row.CodRuma)
                            db.AddInParameter(cmd_m2, "Porcentaje", DbType.Decimal, Row.Porcentaje)
                            db.AddInParameter(cmd_m2, "Humedad", DbType.Decimal, Row.Humedad)
                            db.AddInParameter(cmd_m2, "Merma", DbType.Decimal, Row.Merma)
                            db.AddInParameter(cmd_m2, "Usuario", DbType.String, Rpt.Usuario)
                            db.ExecuteNonQuery(cmd_m2, Trans)
                        End If
                    Next


                End If

                If Ls_RumaSuministro IsNot Nothing Then
                    For Each Row In Ls_RumaSuministro

                        Dim ymd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxFormula)

                        db.AddInParameter(ymd, "Tipo", DbType.Int16, 3)
                        db.AddInParameter(ymd, "CodEnlace", DbType.Int32, Rpt.ID)
                        db.AddInParameter(ymd, "CodRuma", DbType.String, Row.CodRuma)
                        db.AddInParameter(ymd, "Porcentaje", DbType.Decimal, Row.Porcentaje)
                        db.AddInParameter(ymd, "Humedad", DbType.Decimal, Row.Humedad)
                        db.AddInParameter(ymd, "Merma", DbType.Decimal, Row.Merma)
                        db.AddInParameter(ymd, "Usuario", DbType.String, Rpt.Usuario)
                        db.AddInParameter(ymd, "Mes", DbType.String, Rpt.Mes)
                        db.AddInParameter(ymd, "Año", DbType.String, Rpt.Anho)
                        db.AddOutParameter(ymd, "Respuesta", DbType.Int16, 10)

                        db.ExecuteNonQuery(ymd, Trans)

                        lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(ymd, "Respuesta"))

                        If lResult.Respuesta <> 0 Then Err.Raise(10)

                        If Rpt.Update = True Then
                            Dim cmd_m3 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxFormula_Masivo)
                            db.AddInParameter(cmd_m3, "Tipo", DbType.Int16, 3)
                            db.AddInParameter(cmd_m3, "CodEnlace", DbType.Int32, Rpt.ID)
                            db.AddInParameter(cmd_m3, "Cod_Prod", DbType.String, Rpt.CodProducto)
                            db.AddInParameter(cmd_m3, "CodRuma", DbType.String, Row.CodRuma)
                            db.AddInParameter(cmd_m3, "Porcentaje", DbType.Decimal, Row.Porcentaje)
                            db.AddInParameter(cmd_m3, "Humedad", DbType.Decimal, Row.Humedad)
                            db.AddInParameter(cmd_m3, "Merma", DbType.Decimal, Row.Merma)
                            db.AddInParameter(cmd_m3, "Usuario", DbType.String, Rpt.Usuario)
                            db.ExecuteNonQuery(cmd_m3, Trans)
                        End If
                    Next
                End If


                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

                lResult = Nothing

            End Try

        End Using

        Return lResult

    End Function

    Private Shared Sub Actualizacion_ProductoxRuma(ByVal Rpt As ETProducto, ByVal db As Database, ByVal Trans As DbTransaction, ByVal Row As ETRuma)

        If Rpt Is Nothing OrElse db Is Nothing OrElse Trans Is Nothing OrElse Row Is Nothing Then
            Return
        End If

        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxEnlace)

        With db
            .AddInParameter(xmd, "Tipo", DbType.Int16, 2)
            .AddInParameter(xmd, "ID", DbType.Int32, Entidad.Producto.ID)
            .AddInParameter(xmd, "CodRuma", DbType.String, Row.CodRuma)
            .AddInParameter(xmd, "Porcentaje", DbType.Decimal, Row.Porcentaje)
            .AddInParameter(xmd, "Usuario", DbType.String, Rpt.Usuario)
            .AddInParameter(xmd, "Mes", DbType.Int16, Rpt.Mes)
            .AddInParameter(xmd, "Año", DbType.Int16, Rpt.Anho)
            .AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
            .ExecuteNonQuery(xmd, Trans)
        End With

        Entidad.Producto.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

        If Entidad.Producto.Respuesta <> 0 Then Err.Raise(10)

    End Sub

    Private Shared Sub Actualizacion_ProductoxRumaxProd(ByVal Rpt As ETProducto, ByVal db As Database, ByVal Trans As DbTransaction, ByVal Row As ETRuma)

        If Rpt Is Nothing OrElse db Is Nothing OrElse Trans Is Nothing OrElse Row Is Nothing Then
            Return
        End If

        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxEnlace)

        With db
            .AddInParameter(xmd, "Tipo", DbType.Int16, 4)
            .AddInParameter(xmd, "ID", DbType.Int32, Entidad.Producto.ID)
            .AddInParameter(xmd, "CodRuma", DbType.String, Row.CodRuma)
            .AddInParameter(xmd, "Porcentaje", DbType.Decimal, Row.Porcentaje)
            .AddInParameter(xmd, "Usuario", DbType.String, Rpt.Usuario)
            .AddInParameter(xmd, "Mes", DbType.Int16, Rpt.Mes)
            .AddInParameter(xmd, "Año", DbType.Int16, Rpt.Anho)
            .AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
            .ExecuteNonQuery(xmd, Trans)
        End With

        Entidad.Producto.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

        If Entidad.Producto.Respuesta <> 0 Then Err.Raise(10)

    End Sub

    Private Shared Sub Actualizacion_ProductoxRumaxSuministro(ByVal Rpt As ETProducto, ByVal db As Database, ByVal Trans As DbTransaction, ByVal Row As ETRuma)

        If Rpt Is Nothing OrElse db Is Nothing OrElse Trans Is Nothing OrElse Row Is Nothing Then
            Return
        End If

        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxEnlace)

        With db
            .AddInParameter(xmd, "Tipo", DbType.Int16, 5)
            .AddInParameter(xmd, "ID", DbType.Int32, Entidad.Producto.ID)
            .AddInParameter(xmd, "CodRuma", DbType.String, Row.CodRuma)
            .AddInParameter(xmd, "Porcentaje", DbType.Decimal, Row.Porcentaje)
            .AddInParameter(xmd, "Usuario", DbType.String, Rpt.Usuario)
            .AddInParameter(xmd, "Mes", DbType.Int16, Rpt.Mes)
            .AddInParameter(xmd, "Año", DbType.Int16, Rpt.Anho)
            .AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
            .ExecuteNonQuery(xmd, Trans)
        End With

        Entidad.Producto.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

        If Entidad.Producto.Respuesta <> 0 Then Err.Raise(10)

    End Sub

    Public Function MantenimientoEnlace(ByVal Rpt As ETProducto, ByVal Ls_Ruma As List(Of ETRuma), _
                                        ByVal Ls_RumaProd As List(Of ETRuma), _
                                        ByVal Ls_RumaSuministro As List(Of ETRuma)) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing OrElse (Ls_Ruma Is Nothing And Ls_RumaProd Is Nothing And Ls_RumaSuministro Is Nothing) Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETProducto

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxEnlace)

                db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
                db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Rpt.CodProducto)
                db.AddInParameter(cmd, "CodMolino", DbType.String, Rpt.IDMolino)
                db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                db.AddInParameter(cmd, "Mes", DbType.Int16, Rpt.Mes)
                db.AddInParameter(cmd, "Año", DbType.Int16, Rpt.Anho)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.AddOutParameter(cmd, "Valor", DbType.Int32, 11)

                db.ExecuteNonQuery(cmd, Trans)

                Entidad.Producto = New ETProducto

                Entidad.Producto.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                Entidad.Producto.ID = Convert.ToInt32(db.GetParameterValue(cmd, "Valor"))

                If Entidad.Producto.Respuesta <> 0 OrElse Entidad.Producto.ID = 0 Then Err.Raise(10)

                If Ls_Ruma IsNot Nothing Then
                    For Each Row As ETRuma In Ls_Ruma
                        Call Actualizacion_ProductoxRuma(Rpt, db, Trans, Row)
                    Next
                End If

                If Ls_RumaProd IsNot Nothing Then
                    For Each Row As ETRuma In Ls_RumaProd
                        Call Actualizacion_ProductoxRumaxProd(Rpt, db, Trans, Row)
                    Next
                End If

                If Ls_RumaSuministro IsNot Nothing Then
                    For Each Row As ETRuma In Ls_RumaSuministro
                        Call Actualizacion_ProductoxRumaxSuministro(Rpt, db, Trans, Row)
                    Next
                End If

                Entidad.Producto.Validacion = Boolean.TrueString
                lResult = Entidad.Producto

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using

        Return lResult

    End Function

    Public Function EliminarEnlace(ByVal Rpt As ETProducto) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETProducto

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxEnlace)

                db.AddInParameter(cmd, "Tipo", DbType.Int16, 3)
                db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)
                db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                db.AddInParameter(cmd, "Mes", DbType.Int16, Rpt.Mes)
                db.AddInParameter(cmd, "Año", DbType.Int16, Rpt.Anho)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

                lResult = Nothing

            End Try

        End Using

        Return lResult

    End Function

    Public Function ConsultarFactor1(ByVal P As ETProducto) As List(Of ETProducto)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarFactor)
        Dim lst As New List(Of ETProducto)
        Dim E As ETProducto = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 1)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Usuario", DbType.String, P.Usuario)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETProducto
                    E.CodAlmacen = dr.GetString(dr.GetOrdinal("CodAlmacen"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
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

    Public Function ConsultarFactor2() As List(Of ETProducto)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarFactor)
        Dim lst As New List(Of ETProducto)
        Dim E As ETProducto = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 2)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETProducto
                    E.TipoProducto = dr.GetString(dr.GetOrdinal("TipoProducto"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
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

    Public Function ConsultarFactor3() As List(Of ETProducto)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarFactor)
        Dim lst As New List(Of ETProducto)
        Dim E As ETProducto = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 3)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETProducto
                    E.Unidad = dr.GetString(dr.GetOrdinal("Unidad"))
                    E.ValorxTexto = dr.GetString(dr.GetOrdinal("Valor"))
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

    Public Function ProductosExportacion(ByVal P As ETProducto) As List(Of ETProducto)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ProductosExportacion)
        Dim lst As New List(Of ETProducto)
        Dim E As ETProducto = Nothing

        Try

            db.AddInParameter(cmd, "cod_cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Palabra", DbType.String, P.Descripcion)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETProducto
                    E.CodProducto = dr.GetString(dr.GetOrdinal("Codigo"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
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

    Public Function ConsultarProductoJS(ByVal Rpt As ETProducto) As DataTable


        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarProducto)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Tipo", DbType.String, 6)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Rpt.CodProducto)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarProductoJS = tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            ConsultarProductoJS = Nothing
        End Try

    End Function

    Public Function ConsultarProducto6(ByVal Rpt As ETProducto) As ETProducto

        Dim lResult As New ETProducto
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarProducto)

        Try
            db.AddInParameter(cmd, "Tipo", DbType.String, 6)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Rpt.CodProducto)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read()
                    With lResult
                        .CodProducto = dr.GetString(dr.GetOrdinal("CodProducto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .ParteMensual = dr.GetBoolean(dr.GetOrdinal("ParteMensual"))
                        .UnidadVentas = dr.GetString(dr.GetOrdinal("UnidadVentas"))
                        .UnidadProduccion = dr.GetString(dr.GetOrdinal("UnidadProduccion"))
                        .Unidad = dr.GetString(dr.GetOrdinal("Unidad"))
                        .NoConforme = dr.GetString(dr.GetOrdinal("NoConforme"))
                        .Uso = dr.GetString(dr.GetOrdinal("Uso"))
                        .Clasificacion = dr.GetString(dr.GetOrdinal("Clasificacion"))
                        .Muestra = dr.GetBoolean(dr.GetOrdinal("Muestra"))
                        .Ventas = dr.GetBoolean(dr.GetOrdinal("Ventas"))
                        .TipoProducto = dr.GetString(dr.GetOrdinal("TipoProducto"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        .ParteSemanal = dr.GetInt32(dr.GetOrdinal("ParteSemanal"))
                        .Peso = dr.GetDecimal(dr.GetOrdinal("Peso"))
                        .Factor = dr.GetDecimal(dr.GetOrdinal("Factor"))
                        .FactorBolsa = dr.GetDecimal(dr.GetOrdinal("FactorBolsa"))
                        .QuitarConsultaStock = dr.GetBoolean(dr.GetOrdinal("QuitarConsultaStock"))
                        .FechaActualizacion = dr.GetDateTime(dr.GetOrdinal("FechaActualizacion"))
                        .FechaCreacion = dr.GetDateTime(dr.GetOrdinal("FechaCreacion"))
                        .Validacion = Boolean.TrueString
                    End With
                End While
                If Not dr Is Nothing Then dr.Close()
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = New ETProducto
        End Try

        Return lResult

    End Function

    Public Function ConsultarSuministros_Enlace() As ETMyLista

        Dim lResult As New ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarProducto)

        Try
            db.AddInParameter(cmd, "Tipo", DbType.String, 9)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read()
                    Entidad.Ruma = New ETRuma
                    With Entidad.Ruma
                        .CodRuma = dr.GetString(dr.GetOrdinal("CodProducto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    End With
                    lResult.Ls_Ruma.Add(Entidad.Ruma)
                End While
                If Not dr Is Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = New ETMyLista
        End Try

        Return lResult

    End Function

    Public Function ConsultarSuministros(ByVal pIdAlmSol As String) As ETMyLista

        Dim lResult As New ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarSuministros)
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarSuministros_xAlmacen)
        cmd.CommandTimeout = 0
        Try
            'db.AddInParameter(cmd, "Tipo", DbType.String, 9)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "pa_IdAlm", DbType.String, pIdAlmSol)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read()
                    Entidad.Ruma = New ETRuma
                    With Entidad.Ruma
                        .CodRuma = dr.GetString(dr.GetOrdinal("CodProducto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Unidad = dr.GetString(dr.GetOrdinal("unid_desp"))
                        .StockD = dr.GetDecimal(dr.GetOrdinal("STOCK"))
                        '.TipoEnlace = dr.GetString(dr.GetOrdinal("codlinea"))
                    End With
                    lResult.Ls_Ruma.Add(Entidad.Ruma)
                End While
                If Not dr Is Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = New ETMyLista
        End Try

        Return lResult

    End Function


    Public Function ListaProductosImp(ByVal Producto As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarProductosAlm)
        Dim Tabla1 As DataTable = Nothing
        Dim Ds As DataSet = New DataSet()

        Try
            db.AddInParameter(cmd, "Opcion", DbType.String, Producto.Accion)
            db.AddInParameter(cmd, "cod_prod", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Producto.CodAlmacen)
            db.AddInParameter(cmd, "csStock", DbType.String, Producto.csStock)

            Ds = db.ExecuteDataSet(cmd)

            If Ds.Tables.Count > 0 Then
                Tabla1 = Ds.Tables(0).Copy
            Else
                Tabla1 = New DataTable
            End If

            Tabla1 = Ds.Tables(0).Copy

            Return Tabla1

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function


    Public Function ListaProductosImpTMP(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPedidosSuministro)
        'Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarProductosAlm)

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarProductosAlm)
        Dim Tabla1 As DataTable = Nothing

        Dim Ds As DataSet = New DataSet()

        ' Ahora puedes acceder a la tabla
        'Dim tabla As DataTable = Ds.Tables(0)

        Try
            db.AddInParameter(cmd, "Opcion", DbType.String, Producto.Accion)
            db.AddInParameter(cmd, "cod_prod", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Producto.CodAlmacen)
            db.AddInParameter(cmd, "csStock", DbType.String, Producto.csStock)

            ' Ahora puedes acceder a la tabla
            Dim tabla As DataTable = Ds.Tables(0)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla1 = New DataTable
            Tabla1 = Ds.Tables(0).Copy

            ListaProductosImpTMP = Tabla1

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


    Public Function MantenimientoProducto(ByVal Rpt As ETProducto, ByVal Ls_Suministro As List(Of ETSuministro)) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing OrElse Ls_Suministro Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETProducto

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoProducto)

                db.AddInParameter(cmd, "Tipo", DbType.Int16, Rpt.Tipo)
                db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
                db.AddParameter(cmd, "CodProducto", DbType.String, 8, ParameterDirection.InputOutput, True, 0, 0, "", DataRowVersion.Default, Rpt.CodProducto)
                db.AddInParameter(cmd, "Descripcion", DbType.String, Rpt.Descripcion)
                db.AddInParameter(cmd, "UnidadProduccion", DbType.String, Rpt.UnidadProduccion)
                db.AddInParameter(cmd, "UnidadVentas", DbType.String, Rpt.UnidadVentas)
                db.AddInParameter(cmd, "TipoProducto", DbType.String, Rpt.TipoProducto)
                db.AddInParameter(cmd, "Peso", DbType.Decimal, Rpt.Peso)
                db.AddInParameter(cmd, "Factor", DbType.Decimal, Rpt.Factor)
                db.AddInParameter(cmd, "Muestra", DbType.Boolean, Rpt.Muestra)
                db.AddInParameter(cmd, "Ventas", DbType.Boolean, Rpt.Ventas)
                db.AddInParameter(cmd, "ParteMensual", DbType.Boolean, Rpt.ParteMensual)
                db.AddInParameter(cmd, "ParteSemanal", DbType.Int32, Rpt.ParteSemanal)
                db.AddInParameter(cmd, "Unidad", DbType.String, Rpt.Unidad)
                db.AddInParameter(cmd, "UnidadDesp", DbType.String, Rpt.UnidadDesp)
                db.AddInParameter(cmd, "Status", DbType.String, Rpt.Status)
                db.AddInParameter(cmd, "FactorBolsa", DbType.Decimal, Rpt.FactorBolsa)
                db.AddInParameter(cmd, "Uso", DbType.String, Rpt.Uso)
                db.AddInParameter(cmd, "CodProdPDCObs", DbType.String, Rpt.CodProdPDCObs)
                db.AddInParameter(cmd, "Clasificacion", DbType.String, Rpt.Clasificacion)
                db.AddInParameter(cmd, "NoConforme", DbType.String, Rpt.NoConforme)
                db.AddInParameter(cmd, "QuitarConsultaStock", DbType.Boolean, Rpt.QuitarConsultaStock)
                db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                lResult.ValorxTexto = Convert.ToString(db.GetParameterValue(cmd, "CodProducto"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

                For Each Row In Ls_Suministro

                    Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoSuministro)

                    db.AddInParameter(xmd, "Tipo", DbType.Int16, 1)
                    db.AddInParameter(xmd, "Companhia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "CodProducto", DbType.String, lResult.ValorxTexto)
                    db.AddInParameter(xmd, "CodEnlace", DbType.String, Row.CodSuministro)
                    db.AddInParameter(xmd, "Usuario", DbType.String, Rpt.Usuario)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)

                    db.ExecuteNonQuery(xmd, Trans)

                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)

                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ConsultarCodVenta(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarCodVenta)

        Try
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Rpt.CodProducto)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Producto = New ETProducto
                    Entidad.Producto.CodVenta = dr.GetString(dr.GetOrdinal("CodVenta"))
                    Entidad.Producto.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.Producto.FechaCreacion = dr.GetDateTime(dr.GetOrdinal("FechaCreacion"))
                    lResult.Ls_Producto.Add(Entidad.Producto)
                End While
                If Not dr Is Nothing Then dr.Close()
            End Using
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function


    '    =======================================0
#Region "Agregar - Producto"
    Public Function AgregarProducto(ByVal Producto As ETProducto, ByVal Opcion As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim Und_Compra As String = ""
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Productos)
        Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.NumeracionSuministros)
        Dim cmd3 As DbCommand = db.GetStoredProcCommand(usp_RAL.Maestros_2)
        Dim cmd4 As DbCommand = db.GetStoredProcCommand(usp_RAL.Crea_Stock)


        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                If Opcion = "AGR" Then
                    db.AddInParameter(cmd2, "documento", DbType.String, "SUM")
                    db.AddInParameter(cmd2, "Cod_Cia", DbType.String, Producto.Cod_Cia)
                    db.AddOutParameter(cmd2, "numero2", DbType.Int32, 10)
                    IntRes = db.ExecuteNonQuery(cmd2, Trans)

                    ETResultado.Mensaje = Codigo_Producto(Convert.ToString(db.GetParameterValue(cmd2, "numero2")))
                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    db.AddInParameter(cmd4, "CodCia", DbType.String, Producto.Cod_Cia)
                    db.AddInParameter(cmd4, "CodProd", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd4, "TipProd", DbType.String, Producto.TipoProducto)
                    db.AddInParameter(cmd4, "unidad", DbType.String, Producto.UnidadDesp)
                    IntRes = db.ExecuteNonQuery(cmd4, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                Else
                    ETResultado.Mensaje = Producto.CodProducto
                End If

                db.AddInParameter(cmd3, "Cod_Cia", DbType.String, Producto.Cod_Cia)
                db.AddInParameter(cmd3, "Unidad_Despacho", DbType.String, Producto.UnidadDesp)
                db.AddInParameter(cmd3, "Opcion", DbType.String, "LMD")

                Ds = New DataSet
                Ds = db.ExecuteDataSet(cmd3)

                Tabla = New DataTable
                Tabla = Ds.Tables(0).Copy

                If Tabla.Rows.Count > 0 Then Und_Compra = Tabla.Rows(0).Item("Codigo")

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Producto.Cod_Cia)
                db.AddInParameter(cmd, "Cod_Producto", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd, "Descripcion", DbType.String, Producto.Descripcion)
                db.AddInParameter(cmd, "CODUNIDCPA", DbType.String, Und_Compra)
                db.AddInParameter(cmd, "CODLINEA", DbType.String, Producto.CodLinea)
                db.AddInParameter(cmd, "CODNAT", DbType.String, Producto.CodNat)
                db.AddInParameter(cmd, "CODCARACT", DbType.String, Producto.CodCaract)
                db.AddInParameter(cmd, "USER_CREA", DbType.String, Producto.User_Crea)
                db.AddInParameter(cmd, "opcprod", DbType.String, Producto.OpcProd)
                db.AddInParameter(cmd, "tipprod", DbType.String, Producto.TipoProducto)
                db.AddInParameter(cmd, "destecnica", DbType.String, Producto.DesTecnica)
                db.AddInParameter(cmd, "cpaxvol", DbType.String, Producto.CpaxVol)
                db.AddInParameter(cmd, "unid_desp", DbType.String, Producto.UnidadDesp)
                db.AddInParameter(cmd, "control_num", DbType.String, Producto.Control_Num)
                db.AddInParameter(cmd, "control_dua", DbType.String, Producto.Control_Dua)
                db.AddInParameter(cmd, "stkmin", DbType.String, Producto.StkMin)
                db.AddInParameter(cmd, "ubialm", DbType.String, Producto.UbiAlm)
                db.AddInParameter(cmd, "Status", DbType.String, Producto.Status)
                db.AddInParameter(cmd, "sumi_critico", DbType.String, Producto.Sumi_Critico)
                db.AddInParameter(cmd, "tiempo_stock_seguridad", DbType.String, Producto.Tiempo_Stock_Seguridad)
                db.AddInParameter(cmd, "cod_tiempo_stock_seguridad", DbType.String, Producto.Cod_Tiempo_Stock_Seguridad)
                db.AddInParameter(cmd, "tiempo_importacion", DbType.String, Producto.Tiempo_Importacion)
                db.AddInParameter(cmd, "cod_tiempo_importacion", DbType.String, Producto.Cod_Tiempo_Importacion)
                db.AddInParameter(cmd, "sumi_consu", DbType.String, Producto.Sumi_Consu)
                db.AddInParameter(cmd, "cod_clasconta", DbType.String, Producto.Cod_ClasConta)
                db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False

                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function
#End Region

    '   ***** usp_RAL_ListarProductos   *****   
    '   Opcion  :   LIS     =>  Listar Productos x Empleo
    '   Opcion  :   LIS1    =>  Listar Productos LIKE Codigo
    '   Opcion  :   LIS2    =>  Listar Productos LIKE Descripcion  
    '   Opcion  :   LX1     =>  Listar Productos General LIKE Codigo
    '   Opcion  :   LX1C    =>  Listar Productos General LIKE Codigo
    '   Opcion  :   LX1D    =>  Listar Productos General LIKE Descripcion
    '   Opcion  :   LX3     =>  Listar Productos General con Stock Minimo
    '   OPcion  :   LPS     =>  Listar Productos Sustitutos
    '   Opcion  :   LCO     =>  Listar Productos X Nombre
    '   Opcion  :   LX2     =>  Listar Codigo Producto General
    '   Opcion  :   LDT     =>  Listar Descripcion Tecnica Todos
    '   Opcion  :   DTP     =>  Listar Descripcion Tecnica x Producto  
    '   Opcion  :   LMA     =>  Listar Maestro Productos
    '   Opcion  :   DET     =>  Listar Detalle Producto

#Region "Listar Producto"
    Public Function ListarProducto(ByVal Producto As ETProducto, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarProductos)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CodCia", DbType.String, Producto.Cod_Cia)
            db.AddInParameter(cmd, "CodAlm", DbType.String, Producto.CodAlmacen)
            db.AddInParameter(cmd, "Cod_Empleo", DbType.String, Producto.Empleo)
            db.AddInParameter(cmd, "Cod_Prod", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Producto", DbType.String, Producto.Descripcion)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Producto.Cod_Cantera)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarProducto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_OrdenCompra *****
    '   Opcion  :   LIS     =>  
    '   Opcion  :   LOC     =>  Listar OC por Producto

#Region "Listar Producto OC"
    Public Function ListarProductosOC(ByVal OC As ETOrdenCompra, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.OrdenCompra)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, OC.Cod_Cia)
            db.AddInParameter(cmd, "Nro_OC", DbType.String, OC.Nro_OC)
            db.AddInParameter(cmd, "Cod_Prod", DbType.String, OC.Cod_Prod)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarProductosOC = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_ValidarMaestroProductos *****
    '   Opcion  :   LRA     =>  Validar Requisición - Anulacion Producto
    '   Opcion  :   LRE     =>  Validar Cotización - Anulacion Producto
    '   Opcion  :   LRI     =>  Validar OC - Anulacion Producto
    '   Opcion  :   LRO     =>  Validar Det_Guia - Anulacion Producto
    '   Opcion  :   LRU     =>  Validar Nombre Producto Nuevo
    '   OPcion  :   LRX     =>  Validar Nombre Producto Existente
    '   Opcion  :   XCO     =>  Validar Codigo Producto Existente

#Region "Producto Validar"
    Public Function ProductoValidar(ByVal Producto As ETProducto, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ValidarMaestroProductos)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@Cod_Cia", DbType.String, Producto.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Producto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Tipo_Producto", DbType.String, Producto.TipoProducto)
            db.AddInParameter(cmd, "Descripcion", DbType.String, Producto.Descripcion)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ProductoValidar = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Actualizar Unidad de Despacho del Producto "
    Public Function Update_Producto_UD(ByVal Producto As ETProducto) As ETResultado
        Dim IntRes As Integer = -1
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.UPD_UnidadDespacho)


        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Producto.Cod_Cia)
                db.AddInParameter(cmd, "CodigoProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Unidad_Despacho", DbType.String, Producto.UnidadDesp)
                db.AddInParameter(cmd, "Unidad_Anterior", DbType.String, Producto.Unidad)

                IntRes = db.ExecuteNonQuery(cmd, Trans)



                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False

                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function
#End Region

#Region "Producto Validar"
    Public Function ProductoStockActual(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.UltimoSaldo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "codcia", DbType.String, Producto.Cod_Cia)
            db.AddInParameter(cmd, "codprod", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "codalm", DbType.String, Producto.CodAlmacen)
            db.AddInParameter(cmd, "tipprod", DbType.String, Producto.TipoProducto)
            db.AddInParameter(cmd, "fecha", DbType.DateTime, Producto.FechaCreacion)
            db.AddInParameter(cmd, "tipo", DbType.String, "D")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ProductoStockActual = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_ConversionUnidadesProductos
    '   Opcion: L3  =>  Listar Conversion x Producto
    '   Opcion: L4  =>  Listar Producto Peso - Coversion

#Region "Listar Conversion x Producto"
    Public Function ListarConversionProducto(ByVal Conversion As ETProducto, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConversionUnidadesProductos)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Conversion.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Prod", DbType.String, Conversion.CodProducto)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarConversionProducto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Conversion x Producto"
    Public Function Existe_Producto_Conversion(ByVal Conversion As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConsultarConversion2)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Conversion.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Producto", DbType.String, Conversion.CodProducto)
            db.AddInParameter(cmd, "UM_Origen", DbType.String, Conversion.Unidad)
            db.AddInParameter(cmd, "UM_Destino", DbType.String, Conversion.UnidadDesp)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Existe_Producto_Conversion = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   MANTENIMIENTO   *****   

#Region "Conversion x Producto "
    Public Function ConversionProducto(ByVal Conversion As ETProducto, ByVal Opcion As String) As ETResultado

        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConversionUnidadesProductos)
        Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.ConversionUnidadesProductos)
        Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.ConversionUnidadesProductos)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Conversion.Cod_Cia)
                db.AddInParameter(cmd, "User", DbType.String, Conversion.User_Crea)
                db.AddInParameter(cmd, "Cod_Prod", DbType.String, Conversion.CodProducto)
                db.AddInParameter(cmd, "Opcion", DbType.String, "AN")

                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                db.AddInParameter(cmd1, "Cod_Cia", DbType.String, Conversion.Cod_Cia)
                db.AddInParameter(cmd1, "Opcion", DbType.String, "UP")
                db.AddOutParameter(cmd1, "Mensaje", DbType.String, 5)

                IntRes = db.ExecuteNonQuery(cmd1, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd1, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                db.AddInParameter(cmd2, "Cod_Cia", DbType.String, Conversion.Cod_Cia)
                db.AddInParameter(cmd2, "Cod_Conver", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd2, "Cod_Prod", DbType.String, Conversion.CodProducto)
                db.AddInParameter(cmd2, "UM_Origen", DbType.String, Conversion.Unidad)
                db.AddInParameter(cmd2, "UM_Destino", DbType.String, Conversion.UnidadDesp)
                db.AddInParameter(cmd2, "Operacion", DbType.String, Conversion.Operacion)
                db.AddInParameter(cmd2, "Factor", DbType.String, Conversion.FactorConversion)
                db.AddInParameter(cmd2, "User", DbType.String, Conversion.User_Crea)
                db.AddInParameter(cmd2, "Entero", DbType.String, Conversion.Entero)
                db.AddInParameter(cmd2, "Opcion", DbType.String, Opcion)

                IntRes = db.ExecuteNonQuery(cmd2, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False

                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try
        End Using

        Return ETResultado

    End Function
#End Region

#Region "Producto Conversion "
    Public Function ProductoConversion(ByVal Conversion As ETProducto, ByVal A As List(Of ETProducto)) As ETResultado

        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConversionUnidadesProductos)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Conversion.Cod_Cia)
                db.AddInParameter(cmd, "User", DbType.String, Conversion.User_Crea)
                db.AddInParameter(cmd, "Cod_Prod", DbType.String, Conversion.CodProducto)
                db.AddInParameter(cmd, "Opcion", DbType.String, "AN")

                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                For Each X As ETProducto In A
                    Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.ConversionUnidadesProductos)
                    Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.ConversionUnidadesProductos)
                    db.AddInParameter(cmd1, "Cod_Cia", DbType.String, Conversion.Cod_Cia)
                    db.AddInParameter(cmd1, "Opcion", DbType.String, "UP")
                    db.AddOutParameter(cmd1, "Mensaje", DbType.String, 5)

                    IntRes = db.ExecuteNonQuery(cmd1, Trans)
                    ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd1, "Mensaje"))

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    db.AddInParameter(cmd2, "Cod_Cia", DbType.String, X.Cod_Cia)
                    db.AddInParameter(cmd2, "Cod_Conver", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd2, "Cod_Prod", DbType.String, X.CodProducto)
                    db.AddInParameter(cmd2, "UM_Origen", DbType.String, X.Unidad)
                    db.AddInParameter(cmd2, "UM_Destino", DbType.String, X.UnidadDesp)
                    db.AddInParameter(cmd2, "Operacion", DbType.String, X.Operacion)
                    db.AddInParameter(cmd2, "Factor", DbType.String, X.Factor)
                    db.AddInParameter(cmd2, "User", DbType.String, X.User_Crea)
                    db.AddInParameter(cmd2, "Entero", DbType.String, X.Entero)
                    db.AddInParameter(cmd2, "Opcion", DbType.String, "AG")

                    IntRes = db.ExecuteNonQuery(cmd2, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If
                Next

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False

                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try
        End Using

        Return ETResultado

    End Function
#End Region


    '   *****   usp_RAL_ListarLinea *****
    '   Opcion  :   L1  =>  Listar Solo Linea 
    '   Opcion  :   L2  =>  Listar Linea

#Region "Listar Solo Linea"
    Public Function Listar_Linea_SubLinea(ByVal Producto As ETProducto, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarLinea)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Producto.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Empleo", DbType.String, Producto.Empleo)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Listar_Linea_SubLinea = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RAL_ListarSubLinea  *****
    '   Opcion  :   LNU     =>  Listar SubLinea
    '   Opcion  :   LMO     =>  Listar SubLinea Modificar  

#Region "Listar Sub Linea"
    Public Function ListarSubLinea(ByVal Producto As ETProducto, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarSubLinea)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Producto.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Linea", DbType.String, Producto.CodLinea)
            db.AddInParameter(cmd, "Cod_Empleo", DbType.String, Producto.Empleo)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarSubLinea = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    Public Function verificacierreAlmacen(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.VERIFICA_CIERREALMACEN)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "PERIODO", DbType.String, Producto.Periodo)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            verificacierreAlmacen = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function verificaperiodoProvision(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.verificaperiodoProvision)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "periodo", DbType.String, Producto.Periodo)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            verificaperiodoProvision = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Consultar_Formulaciones(ByVal p_cod_producto As String, ByVal p_cod_molino As String, ByVal p_agno As Integer, ByVal p_mes As Integer) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Consultar_Formulaciones)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "p_codproducto", DbType.String, p_cod_producto)
            db.AddInParameter(cmd, "p_codmolino", DbType.String, p_cod_molino)
            db.AddInParameter(cmd, "p_agno", DbType.Int16, p_agno)
            db.AddInParameter(cmd, "p_mes", DbType.Int16, p_mes)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return Tabla

    End Function

    Public Function MantenimientoMineralProductoProyeccion(ByVal Rpt As ETProducto, ByVal Ls_Ruma As List(Of ETRuma)) As ETProducto


        Dim lResult As ETProducto = Nothing

        If Rpt Is Nothing OrElse (Ls_Ruma Is Nothing) Then
            Return lResult
        End If


        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETProducto

                If Ls_Ruma IsNot Nothing Then
                    For Each Row In Ls_Ruma

                        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoMineralProductoProyeccion)

                        db.AddInParameter(cmd, "TIPO", DbType.Int16, 1)
                        db.AddInParameter(cmd, "IDPRODUCTO", DbType.Int32, Rpt.ID)
                        db.AddInParameter(cmd, "CODMINERAL", DbType.String, Row.CodRuma)
                        db.AddInParameter(cmd, "PORCENTAJE", DbType.Decimal, Row.Porcentaje)
                        db.AddInParameter(cmd, "HUMEDAD", DbType.Decimal, Row.Humedad)
                        db.AddInParameter(cmd, "MERMA", DbType.Decimal, Row.Merma)
                        db.AddInParameter(cmd, "SEGURIDAD", DbType.Decimal, Row.Seguridad)
                        db.AddInParameter(cmd, "USERCREA", DbType.String, Rpt.Usuario)
                        'db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

                        db.ExecuteNonQuery(cmd, Trans)

                        'lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                        'If lResult.Respuesta <> 0 Then Err.Raise(10)

                    Next
                End If

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

                lResult = Nothing

            End Try

        End Using

        Return lResult

    End Function

    Public Function EliminaMineralProductoProyeccion(ByVal Rpt As ETProducto) As Integer


        Dim lResult As Integer = 0


        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = 0


                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.EliminaMineralProductoProyeccion)

                db.AddInParameter(cmd, "IDPRODUCTO", DbType.Int32, Rpt.ID)
                db.AddInParameter(cmd, "USERCREA", DbType.String, Rpt.Usuario)

                db.ExecuteNonQuery(cmd, Trans)

                lResult = 1
                'lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

                lResult = 0

            End Try

        End Using

        Return lResult

    End Function


    'Public Function ListarFormulacionProyectada(ByVal idProducto As Int32) As DataTable

    '    Dim db As Database = DatabaseFactory.CreateDatabase()
    '    Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarFormulacionProyectada)
    '    Dim Tabla As DataTable = Nothing
    '    Dim Ds As DataSet = Nothing

    '    Try
    '        db.AddInParameter(cmd, "IDPRODUCTO", DbType.Int32, idProducto)

    '        Ds = New DataSet
    '        Ds = db.ExecuteDataSet(cmd)

    '        Tabla = New DataTable
    '        Tabla = Ds.Tables(0).Copy

    '        ListarFormulacionProyectada = Tabla

    '    Catch Err As Exception
    '        MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
    '        Return Nothing
    '    End Try

    'End Function

    Public Function ListarFormulacionProyectada(ByVal idProducto As Int32) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarFormulacionProyectada)

        Try

            db.AddInParameter(cmd, "IDPRODUCTO", DbType.Int32, idProducto)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Ruma = New ETRuma
                    With Entidad.Ruma
                        .CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje"))
                        .Humedad = dr.GetDecimal(dr.GetOrdinal("Humedad"))
                        .Merma = dr.GetDecimal(dr.GetOrdinal("Merma"))
                        .Seguridad = dr.GetDecimal(dr.GetOrdinal("Seguridad"))

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

    Public Function CargarBilletes(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CargarBilletes)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "CODTRANSPORTISTA", DbType.String, Producto.CodTransportista)
            db.AddInParameter(cmd, "FECHA1", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FECHA2", DbType.DateTime, Producto.FechaTerminacion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarBilletes = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Billete_Exonerado(ByVal Ls_Datos As List(Of ETProducto)) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                For Each Row In Ls_Datos
                    Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Billete_Exonerado)
                    db.AddInParameter(cmd, "@CHECK", DbType.Int32, Row.check)
                    db.AddInParameter(cmd, "@CIA", DbType.String, Row.Cod_Cia)
                    db.AddInParameter(cmd, "@NUMBILLETE", DbType.String, Row.numbillete)
                    db.AddInParameter(cmd, "@TIPODOC", DbType.String, Row.tipodoc)
                    db.AddInParameter(cmd, "@COD_TRANSP", DbType.String, Row.CodTransportista)
                    db.AddInParameter(cmd, "@USUARIO", DbType.String, Row.User_Crea)
                    db.ExecuteNonQuery(cmd)
                Next

                Trans.Commit()
                Conexion.Close()
                Return 1
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Return 0
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function CargarLetras() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CargarLetras)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarLetras = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


    Public Function CargarAutorizacionIQBF() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CargarAutorizacionIQBF)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarAutorizacionIQBF = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Letra_Transportista(ByVal Ls_Datos As ETProducto) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim id As Int32 = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Letra_Transportista)
                db.AddInParameter(cmd, "@TIPO", DbType.Int32, Ls_Datos.Tipo)
                db.AddInParameter(cmd, "@ID", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@COD_TRANSP", DbType.String, Ls_Datos.CodTransportista)
                db.AddInParameter(cmd, "@FECHAINICIO", DbType.DateTime, Ls_Datos.FechaInicio)
                db.AddInParameter(cmd, "@FECHAVENCIMIENTO", DbType.DateTime, Ls_Datos.FechaTerminacion)
                db.AddInParameter(cmd, "@MONTO", DbType.Double, Ls_Datos.Monto)
                db.AddInParameter(cmd, "@OBSERVACION", DbType.String, Ls_Datos.Observacion)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.User_Crea)
                db.AddInParameter(cmd, "@FLGDEVOLUCION", DbType.Int32, Ls_Datos.flgdevolucion)
                db.AddInParameter(cmd, "@FECHADEVOLUCION", DbType.DateTime, Ls_Datos.fechadevolucion)
                db.AddInParameter(cmd, "@RUTACONVENIO", DbType.String, Ls_Datos.RutaConvenio)
                db.AddInParameter(cmd, "@RUTALETRA", DbType.String, Ls_Datos.RutaLetra)

                id = db.ExecuteScalar(cmd)

                Trans.Commit()
                Conexion.Close()
                Return id
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Return 0
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function


    Public Function Autorizacion_IQBF(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim id As Int32 = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Autorizacion_IQBF)
                db.AddInParameter(cmd, "@OPE", DbType.Int32, Ls_Datos.Tipo)
                db.AddInParameter(cmd, "@ID", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@COD_PROV", DbType.String, Ls_Datos.CodTransportista)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Ls_Datos.FechaInicio)
                db.AddInParameter(cmd, "@OBSERVACION", DbType.String, Ls_Datos.Observacion)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.User_Crea)
                Dim dttable As New DataTable
                dttable = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dttable
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function CargarExoneracion() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CargarExoneracion)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarExoneracion = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    Public Function ConsultarProducto5() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPedidosSuministro)
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarProducto)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Tipo", DbType.String, 5)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarProducto5 = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        'Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarProducto)
        'Dim Tabla As DataTable = Nothing
        'Dim Ds As DataSet = Nothing

        'Try

        '    db.AddInParameter(cmd, "Tipo", DbType.String, 5)
        '    db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

        '    lResult = New ETMyLista

        '    Using dr As IDataReader = db.ExecuteReader(cmd)
        '        While dr.Read
        '            Entidad.Producto = New ETProducto
        '            With Entidad.Producto
        '                .CodProducto = dr.GetString(dr.GetOrdinal("CodProducto"))
        '                .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
        '                .Status = dr.GetString(dr.GetOrdinal("Status"))
        '                .Uso = dr.GetString(dr.GetOrdinal("Uso"))
        '                .Peso = dr.GetDecimal(dr.GetOrdinal("Peso"))
        '                .CodProdPDCObs = dr.GetString(dr.GetOrdinal("CodProdPDCObs"))
        '            End With
        '            lResult.Ls_Producto.Add(Entidad.Producto)
        '        End While
        '        If dr IsNot Nothing Then dr.Close()
        '        lResult.Validacion = Boolean.TrueString
        '    End Using

        'Catch Err As Exception

        '    MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        '    lResult = Nothing

        'End Try

        'Return lResult

    End Function
    Public Function ConsultarFamiliaProductoFamilia(ByVal P As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarFamiliaProductoFamilia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Opcion", DbType.String, P.Accion)
            db.AddInParameter(cmd, "idSubFamilia", DbType.String, P.SubFamilia)
            db.AddInParameter(cmd, "cod_prod", DbType.String, P.CodProducto)
            db.AddInParameter(cmd, "estado", DbType.String, P.Estado)
            db.AddInParameter(cmd, "usuario", DbType.String, P.Usuario)
            db.AddInParameter(cmd, "fecha", DbType.String, P.Fecha)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarFamiliaProductoFamilia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    Public Function ListarSolicitudesPlanilla(ByVal usuario As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarSolicitudesPlanilla)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "USUARIO", DbType.String, usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarSolicitudesPlanilla = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    Public Function ListaPedidosSuministro(ByVal usuario As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPedidosSuministro)
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPedidosSuministro_v3)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "USUARIO", DbType.String, usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListaPedidosSuministro = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ClonarUsuario(ByVal usuario As String, ByVal user_ant As String, ByVal user_nuevo As String, ByVal pass As String, ByVal encargado As String, ByVal email As String, ByVal placod As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ClonarUsuario)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@USUARIO_CREA", DbType.String, usuario)
            db.AddInParameter(cmd, "@USUARIO_ANT", DbType.String, user_ant)
            db.AddInParameter(cmd, "@USUARIO_NUEVO", DbType.String, user_nuevo)
            db.AddInParameter(cmd, "@PASS", DbType.String, pass)
            db.AddInParameter(cmd, "@ENCARGADO", DbType.String, encargado)
            db.AddInParameter(cmd, "@EMAIL", DbType.String, email)
            db.AddInParameter(cmd, "@PLACOD", DbType.String, placod)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ClonarUsuario = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function AreaUsuario(ByVal usuario As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.AreaUsuario)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@USUARIO", DbType.String, usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            AreaUsuario = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListaPedidoAtendido(ByVal usuario As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPedidoAtendido)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "USUARIO", DbType.String, usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListaPedidoAtendido = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListaPedidoAtendido_Hist(ByVal usuario As String, ByVal fecha1 As Date, ByVal fecha2 As Date) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPedidoAtendido_Hist)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "USUARIO", DbType.String, usuario)
            db.AddInParameter(cmd, "FECHA1", DbType.String, fecha1)
            db.AddInParameter(cmd, "FECHA2", DbType.String, fecha2)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListaPedidoAtendido_Hist = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListaPedidoAtendidoCadena(ByVal usuario As String, ByVal cadena As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPedidoAtendidoCadena)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "USUARIO", DbType.String, usuario)
            db.AddInParameter(cmd, "CADENA", DbType.String, cadena)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListaPedidoAtendidoCadena = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListaPedidoAtendidoCorreo(ByVal ruta As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPedidoAtendidoCorreo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "RUTA", DbType.String, ruta)
            'db.AddInParameter(cmd, "CADENA", DbType.String, cadena)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListaPedidoAtendidoCorreo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    Public Function DiferenciaInventario(ByVal Ls_Datos As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DiferenciaInventario)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@opcion", DbType.String, Ls_Datos.Accion)
            db.AddInParameter(cmd, "@NroInventario", DbType.Int16, Ls_Datos.Tipo)
            db.AddInParameter(cmd, "@Fila", DbType.String, Ls_Datos.CodCaract)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            DiferenciaInventario = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    Public Function ApruebaPedidoAtendido(ByVal Ls_Datos As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ApruebaPedidoAtendido)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@NUMPEDIDO", DbType.String, Ls_Datos.numdoc)
            db.AddInParameter(cmd, "@USERAPRUEBA", DbType.String, Ls_Datos.Usuario)
            db.AddInParameter(cmd, "@APROBADO", DbType.String, Ls_Datos.aprobado)
            db.AddInParameter(cmd, "@CADENA", DbType.String, Ls_Datos.cadena)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ApruebaPedidoAtendido = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function userapruebaSuministro(ByVal usuario As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.userapruebaSuministro)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "USUARIO", DbType.String, usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            userapruebaSuministro = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function SolicitudDetalle(ByVal id As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_SolicitudDetalle)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "@numsolicitud", DbType.String, id)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            SolicitudDetalle = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    Public Function ListaPedidosSuministroID(ByVal id As Int32) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPedidosSuministroID)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@ID", DbType.Int32, id)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListaPedidosSuministroID = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Exoneracion_Letra(ByVal Ls_Datos As ETProducto) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Exoneracion_Letra)
                db.AddInParameter(cmd, "@TIPO", DbType.Int32, Ls_Datos.Tipo)
                db.AddInParameter(cmd, "@ID", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@COD_TRANSP", DbType.String, Ls_Datos.CodTransportista)
                'db.AddInParameter(cmd, "@FECHAINICIO", DbType.DateTime, Ls_Datos.FechaInicio)
                'db.AddInParameter(cmd, "@FECHAVENCIMIENTO", DbType.DateTime, Ls_Datos.FechaTerminacion)
                'db.AddInParameter(cmd, "@MONTO", DbType.Double, Ls_Datos.Monto)
                db.AddInParameter(cmd, "@OBSERVACION", DbType.String, Ls_Datos.Observacion)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.User_Crea)
                db.ExecuteNonQuery(cmd)

                Trans.Commit()
                Conexion.Close()
                Return 1
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Return 0
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ValidacionLetras(ByVal Ls_Datos As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ValidacionLetras)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "COD_TRANSP", DbType.String, Ls_Datos.CodTransportista)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ValidacionLetras = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function CargarLetraID(ByVal id As Int32) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CargarLetraID)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "ID", DbType.Int32, id)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarLetraID = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Rpt_FormulacionProyectado() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Rpt_FormulacionProyectado)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Rpt_FormulacionProyectado = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Rpt_ReporteProyectadoMineral(ByVal ayo As Integer) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.PROCESO_RPT_FORMULACION_PROYECTADO)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "AYO", DbType.String, ayo)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Rpt_ReporteProyectadoMineral = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


    Public Function CargarConstanciaError(ByVal obj As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConstanciaError)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "FECHA1", DbType.DateTime, obj.FechaInicio)
            db.AddInParameter(cmd, "FECHA2", DbType.DateTime, obj.FechaTerminacion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarConstanciaError = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function CargarConstanciaBillete(ByVal billete As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConstanciaBillete)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "BILLETE", DbType.String, billete)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarConstanciaBillete = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function CargarDescripcionError() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DescripcionError)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarDescripcionError = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Inserta_ConstanciaError(ByVal Ls_Datos As ETProducto) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim id As Int32 = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.InsertaConstanciaError)
                db.AddInParameter(cmd, "@TIPO", DbType.Int32, Ls_Datos.Tipo)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@NUMBILLETE", DbType.String, Ls_Datos.numbillete)
                db.AddInParameter(cmd, "@IDERROR", DbType.Int32, Ls_Datos.iderror)
                db.AddInParameter(cmd, "@OBSERVACION", DbType.String, Ls_Datos.Observacion)
                db.AddInParameter(cmd, "@CONFIGURACION", DbType.String, Ls_Datos.Configuracion)
                db.AddInParameter(cmd, "@PESO", DbType.Decimal, Ls_Datos.Peso)
                db.AddInParameter(cmd, "@NUMCONSTANCIA", DbType.String, Ls_Datos.numconstancia)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.User_Crea)
                id = db.ExecuteNonQuery(cmd)

                Trans.Commit()
                Conexion.Close()
                Return id
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Return 0
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Ingreso_Tasa(ByVal Ls_Datos As ETProducto) As String
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim resul As String = ""
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Ingreso_Tasa)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@COD_PROV", DbType.String, Ls_Datos.CodTransportista)
                db.AddInParameter(cmd, "@TEA", DbType.Double, Ls_Datos.tea)
                db.AddInParameter(cmd, "@TED", DbType.Double, Ls_Datos.ted)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                resul = db.ExecuteDataSet(cmd).Tables(0).Rows(0)(0)
                Trans.Commit()
                Conexion.Close()
                Return resul
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Return ""
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Tasa_Proveedor(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Tasa_Proveedor)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@COD_PROV", DbType.String, Ls_Datos.CodTransportista)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Factura_Pagar(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Factura_Pagar)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@COD_PROV", DbType.String, Ls_Datos.CodTransportista)
                db.AddInParameter(cmd, "@MONEDA", DbType.String, Ls_Datos.Moneda)
                db.AddInParameter(cmd, "@fecha_pago", DbType.DateTime, Ls_Datos.Fecha)

                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Ingreso_Calculo_Cab(ByVal Ls_Datos As ETProducto, ByVal dtDetalle As DataTable) As String
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim resul As String = ""
        Dim idcalculo As Int32 = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Ingreso_Calculo_Cab)
                db.AddInParameter(cmd, "@TIPO", DbType.Int32, Ls_Datos.Tipo)
                db.AddInParameter(cmd, "@ID", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@COD_PROV", DbType.String, Ls_Datos.CodTransportista)
                db.AddInParameter(cmd, "@FECHA_PAGO", DbType.DateTime, Ls_Datos.Fecha)
                db.AddInParameter(cmd, "@TEA", DbType.Double, Ls_Datos.tea)
                db.AddInParameter(cmd, "@TED", DbType.Double, Ls_Datos.ted)
                db.AddInParameter(cmd, "@ESTADO", DbType.String, Ls_Datos.Estado)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                db.AddInParameter(cmd, "@MONEDA", DbType.String, Ls_Datos.Moneda)
                'resul = db.ExecuteDataSet(cmd).Tables(0).Rows(0)(0)
                idcalculo = db.ExecuteDataSet(cmd, Trans).Tables(0).Rows(0)(0)

                If idcalculo = 0 Then
                    Trans.Commit()
                    Conexion.Close()
                    Return "NO PUEDE ELIMINAR UN CALCULO QUE YA HA SIDO UTILIZADO EN UNA NOTA DE CREDITO"
                End If
                If Ls_Datos.Tipo <> 3 Then
                    For i As Int32 = 0 To dtDetalle.Rows.Count - 1
                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Ingreso_Calculo_Det)
                        db.AddInParameter(xmd, "@MARCA", DbType.Int32, IIf(dtDetalle.Rows(i)("MARCA") = True, 1, 0))
                        db.AddInParameter(xmd, "@CIA", DbType.String, Companhia)
                        db.AddInParameter(xmd, "@IDCALCULOCAB", DbType.Int32, idcalculo)
                        db.AddInParameter(xmd, "@NUM_DOC", DbType.String, dtDetalle.Rows(i)("NUM_DOC"))
                        db.AddInParameter(xmd, "@FECHA_DOC", DbType.DateTime, dtDetalle.Rows(i)("FECHA_DOC"))
                        db.AddInParameter(xmd, "@FECHA_RECEPCION", DbType.DateTime, dtDetalle.Rows(i)("FECHA_RECEPCION"))
                        db.AddInParameter(xmd, "@FECHA_VTO", DbType.DateTime, dtDetalle.Rows(i)("FECHA_VTO"))
                        db.AddInParameter(xmd, "@MONTO", DbType.Double, dtDetalle.Rows(i)("SALDO"))
                        db.AddInParameter(xmd, "@MONTO_RETENCION", DbType.Double, dtDetalle.Rows(i)("MONTO_RETENCION")) '130924
                        db.AddInParameter(xmd, "@DIASADELANTO", DbType.Int32, dtDetalle.Rows(i)("DIASADELANTO"))
                        db.AddInParameter(xmd, "@DSCTO", DbType.Double, dtDetalle.Rows(i)("DSCTO"))
                        db.AddInParameter(xmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                        db.AddInParameter(xmd, "@TIPO_DOC", DbType.String, dtDetalle.Rows(i)("TIPO_DOC"))
                        db.AddInParameter(xmd, "@MONEDA", DbType.String, Ls_Datos.Moneda)
                        db.ExecuteNonQuery(xmd, Trans)
                    Next
                End If

                Trans.Commit()
                Conexion.Close()
                Return "OK"
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Return ""
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Listar_Calculo_PP(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Listar_Calculo_PP)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Listar_Correo_PP(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Listar_Correo_PP)
                db.AddInParameter(cmd, "@COD_PROV", DbType.String, Ls_Datos.CodTransportista)
                db.AddInParameter(cmd, "@RUTA", DbType.String, Ls_Datos.Observacion)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Factura_Calculo(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Factura_Calculo)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@COD_PROV", DbType.String, Ls_Datos.CodTransportista)
                db.AddInParameter(cmd, "@IDCALCULO", DbType.Int32, Ls_Datos.ID)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ManoObra(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ManoObra)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@ayo", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@Mes", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_Validacion(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_Validacion)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_Cierre(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_Cierre)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.User_Crea)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RptComparativoMinas(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RptComparativoMinas)
                cmd.CommandTimeout = 6000
                'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                'db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.User_Crea)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_VerificaCierre(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_VerificaCierre)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    'Public Function Costo_RevisionCantera(ByVal Ls_Datos As ETProducto) As DataTable
    '    Dim db As Database = DatabaseFactory.CreateDatabase()
    '    Dim dt As DataTable
    '    Using Conexion As DbConnection = db.CreateConnection()
    '        Conexion.Open()
    '        Dim Trans As DbTransaction = Conexion.BeginTransaction()
    '        Try
    '            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RevisionCantera)
    '            cmd.CommandTimeout = 0
    '            db.AddInParameter(cmd, "@ano", DbType.String, Ls_Datos.Anho)
    '            db.AddInParameter(cmd, "@mes", DbType.String, Ls_Datos.Mes)
    '            dt = db.ExecuteDataSet(cmd).Tables(0)
    '            Trans.Commit()
    '            Conexion.Close()
    '            Return dt
    '        Catch Err As Exception
    '            Trans.Rollback()
    '            Conexion.Close()
    '            Throw New Exception(Err.Message)
    '        End Try
    '    End Using
    'End Function

    ' Esta función obtiene el costo de revisión de cantera basándose en los datos proporcionados.
    Public Function Costo_RevisionCantera(ByVal Ls_Datos As ETProducto) As DataTable
        ' Crear una instancia de la base de datos utilizando la fábrica de bases de datos.
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable

        ' Usar una conexión a la base de datos.
        Using Conexion As DbConnection = db.CreateConnection()
            ' Abrir la conexión a la base de datos.
            Conexion.Open()

            ' Iniciar una transacción.
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                ' Crear un comando para ejecutar el procedimiento almacenado 'Costo_RevisionCantera'.

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RevisionCantera)

                'Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RevisionCantera_Cta9)


                ' Establecer el tiempo de espera del comando en 0 (sin límite de tiempo).
                cmd.CommandTimeout = 0

                ' Agregar los parámetros de entrada necesarios para el procedimiento almacenado.
                db.AddInParameter(cmd, "@ano", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.String, Ls_Datos.Mes)

                ' Ejecutar el procedimiento almacenado y obtener el resultado en un DataTable.
                dt = db.ExecuteDataSet(cmd).Tables(0)

                ' Confirmar la transacción si todo ha salido bien.
                Trans.Commit()

                ' Cerrar la conexión a la base de datos.
                Conexion.Close()

                ' Devolver el DataTable resultante.
                Return dt
            Catch Err As Exception
                ' Si hay un error, revertir la transacción.
                Trans.Rollback()

                ' Cerrar la conexión a la base de datos.
                Conexion.Close()

                ' Lanzar una nueva excepción con el mensaje de error.
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function


    Public Function Costo_RevisionCanteraID(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RevisionCanteraID)
                db.AddInParameter(cmd, "@ano", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.String, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@idconmay", DbType.Int32, Ls_Datos.ID)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ActualizaCantera(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ActualizaCantera)
                db.AddInParameter(cmd, "@IDCONMAY", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@ORDEN", DbType.String, Ls_Datos.Cod_Cantera)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_CostoMineral(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_CostoMineral)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_DiasHabiles(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_DiasHabiles)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_Seguro(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_Seguro)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RegistraDias(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RegistraDias)
                db.AddInParameter(cmd, "@TIPO", DbType.Int32, Ls_Datos.Tipo)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@DIAS", DbType.Int32, Ls_Datos.Dia)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function
    Public Function Costo_RegistraSeguro(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RegistraSeguro)
                db.AddInParameter(cmd, "@TIPO", DbType.Int32, Ls_Datos.Tipo)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@PLACOD", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@SEGURO", DbType.Int32, Ls_Datos.Monto)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReplicaSeguro(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReplicaSeguro)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_Indirecto(ByVal Ls_Datos As ETProducto) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_Indirecto)
                'db.AddInParameter(cmd, "@ano", DbType.String, Ls_Datos.Anho)
                'db.AddInParameter(cmd, "@mes", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaCuentas(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaCuentas)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RegistraCuenta(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RegistraCuenta)
                db.AddInParameter(cmd, "@TIPO", DbType.Int32, Ls_Datos.Tipo)
                db.AddInParameter(cmd, "@CGCOD", DbType.String, Ls_Datos.Cuenta)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function
    Public Function Costo_ListaEquipos(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaEquipos)
                'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                'db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Consumo_Ene_Mes(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Consumo_Ene_Mes)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RegistraCostEquipo(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RegistraCostEquipo)
                db.AddInParameter(cmd, "@TIPO", DbType.Int32, Ls_Datos.Tipo)
                db.AddInParameter(cmd, "@PLACA", DbType.String, Ls_Datos.Placa)
                db.AddInParameter(cmd, "@COD_CALSE", DbType.String, Ls_Datos.codClase)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaPorcAyo(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaPorcAyo)
                db.AddInParameter(cmd, "@ayo", DbType.Int32, Ls_Datos.Anho)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function
    Public Function Costo_RegistraPorcProduccion(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RegistraPorcProduccion)
                db.AddInParameter(cmd, "@IDCLASE", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@PORCENTAJE", DbType.Double, Ls_Datos.Monto)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RptIndirecto(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RptIndirecto)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@ano", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@Accion", DbType.Int16, Ls_Datos.Tipo)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaSeteoVTAADM(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaSeteoVTAADM)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "ayo", DbType.Int32, Ls_Datos.Anho)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_MantSeteoVTAADM(ByVal dt As DataTable) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dtResult As New DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                'Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaSeteoVTAADM)
                'cmd.CommandTimeout = 0
                'db.AddInParameter(cmd, "ayo", DbType.Int32, Ls_Datos.Anho)
                If dt.Rows.Count > 0 Then
                    For i As Int32 = 0 To DT.Rows.Count - 1
                        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_MantSeteoVTAADM)
                        cmd.CommandTimeout = 0
                        db.AddInParameter(cmd, "@CUENTA", DbType.String, dt.Rows(i)("CUENTA"))
                        db.AddInParameter(cmd, "@PORC_NACIONAL", DbType.Int32, dt.Rows(i)("PORC_NACIONAL"))
                        db.AddInParameter(cmd, "@PORC_EXTERIOR", DbType.Double, dt.Rows(i)("PORC_EXTERIOR"))
                        db.AddInParameter(cmd, "@ID", DbType.String, dt.Rows(i)("TIPO"))
                        dtResult = db.ExecuteDataSet(cmd).Tables(0)
                    Next
                End If
                'dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dtResult
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function CE_RESUMEN_MENSUAL(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.CE_RESUMEN_MENSUAL)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Ls_Datos.FechaInicio)
                db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Ls_Datos.FechaTerminacion)
                db.AddInParameter(cmd, "@CODALMACEN", DbType.String, Ls_Datos.CodAlmacen)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RptIndirectoCAL(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RptIndirectoCAL)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@ano", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@Accion", DbType.Int16, Ls_Datos.Tipo)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RptIndirectoTerrazo(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RptIndirectoTerrazo)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@ano", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@Accion", DbType.Int16, Ls_Datos.Tipo)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RptIndirectoPastas(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RptIndirectoPastas)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@ano", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@Accion", DbType.Int16, Ls_Datos.Tipo)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_MP_CAL(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_MP_CAL)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_MP_Terrazo(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_MP_Terrazo)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_MP_Pasta(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_MP_Pasta)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReportePresentacion(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReportePresentacion)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function
    Public Function Costo_ReporteCanteras(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteCanteras)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@Opcion", DbType.String, Ls_Datos.Accion)
                db.AddInParameter(cmd, "@ano", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MesInicial", DbType.String, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MesFinal", DbType.String, Ls_Datos.Mes1)

                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteTrimestral(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteTrimestral)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteTrimestralRuma(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteTrimestralRuma)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteTrimestralMO(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteTrimestralMO)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_MesesProduccion(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_MesesProduccion)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_GastoExportacion(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_GastoExportacion)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@IdMes", DbType.String, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@IdAnho", DbType.String, Ls_Datos.Anho)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReportePresentacionCAL(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReportePresentacionCAL)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReportePresentacionTERRAZO(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReportePresentacionTERRAZO)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReportePresentacionPASTAS(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReportePresentacionPASTAS)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_COST_ALTOBAJO(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_COST_ALTOBAJO)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@AYO1", DbType.String, Ls_Datos.Anho1)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MES1", DbType.String, Ls_Datos.Mes1)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_PRECIOPRODUCTO(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_PRECIOPRODUCTO)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@COD_CLI", DbType.String, Ls_Datos.CodTransportista)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_COSTOXMOLINO(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_COSTOXMOLINO)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_CONSUMO_ENERGIA(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_CONSUMO_ENERGIA)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function PP_RPT_CONTROL(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.PP_RPT_CONTROL)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@FECHADESDE", DbType.DateTime, Ls_Datos.FechaInicio)
                db.AddInParameter(cmd, "@FECHAHASTA", DbType.DateTime, Ls_Datos.FechaTerminacion)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_COSTOXCHANCADORA(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_COSTOXCHANCADORA)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_COSTOXRUMA(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_COSTOXRUMA)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_COST_MIN_CANTERA(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_COST_MIN_CANTERA)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@COD_CIA", DbType.String, Companhia)                
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@ANO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@CONTABLE", DbType.String, Ls_Datos.tipodoc)
                db.AddInParameter(cmd, "@CANTERA", DbType.String, Ls_Datos.Cod_Cantera)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INDICADOR_PRODUCCION(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INDICADOR_PRODUCCION)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES1", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MES2", DbType.Int32, Ls_Datos.Mes1)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function REPORTE_PARADA(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.REPORTE_PARADA)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@FECHAINI", DbType.Date, Ls_Datos.FechaInicio)
                db.AddInParameter(cmd, "@FECHAFIN", DbType.Date, Ls_Datos.FechaTerminacion)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INDICADOR_PRODUCCION_FINAL(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INDICADOR_PRODUCCION_FINAL)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INDICADOR_ADMINISTRACION_FINAL(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INDICADOR_ADMINISTRACION_FINAL)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INDICADOR_ADMINISTRACION_FINAL_DETALLE(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INDICADOR_ADMINISTRACION_FINAL_DETALLE)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INDICADOR_COMPRA_DETALLE(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INDICADOR_COMPRA_DETALLE)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@DESCRIPCION", DbType.String, Ls_Datos.Descripcion)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function RPT_CUENTA9(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.RPT_CUENTA9)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function RPT_COSTOS_ADM(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.RPT_COSTOS_ADM)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@FECHA1", DbType.Date, Ls_Datos.FechaInicio)
                db.AddInParameter(cmd, "@FECHA2", DbType.Date, Ls_Datos.FechaTerminacion)
                db.AddInParameter(cmd, "@TIPO", DbType.String, Ls_Datos.tipodoc)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INDICADOR_COMERCIAL_DETALLE(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INDICADOR_COMERCIAL_DETALLE)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@DESCRIPCION", DbType.String, Ls_Datos.Descripcion)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INDICADOR_DETALLE(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INDICADOR_DETALLE)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@IDCONCEPTO", DbType.Int32, Ls_Datos.ID)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function LISTAR_AREA(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTAR_AREA)
                cmd.CommandTimeout = 6000
                'db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function LISTAR_INDPRINCIPAL(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTAR_INDPRINCIPAL)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@IDAREA", DbType.String, Ls_Datos.ID)
                'db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function LISTAR_INDICADORES(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTAR_INDICADORES)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@IDAREA", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@IND_PRINCIPAL", DbType.String, Ls_Datos.Descripcion)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function CARGA_INDICADORES(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.CARGA_INDICADORES)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function LISTAR_INDICADORES_FINAL(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTAR_INDICADORES_FINAL)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@IDAREA", DbType.Int32, Ls_Datos.ID)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INSERTA_INDICADORES(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INSERTA_INDICADORES)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@IDCONCEPTO", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@INDICADOR", DbType.Double, Ls_Datos.ValorxDecimal)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function LISTA_PARA_CAMPANIA(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTA_PARA_CAMPANIA)
                cmd.CommandTimeout = 6000
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function LISTA_NAVIERA(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTA_NAVIERA)
                cmd.CommandTimeout = 6000
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function MANT_NAVIERA(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.MANT_NAVIERA)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@OPE", DbType.Int32, Ls_Datos.Operacion)
                db.AddInParameter(cmd, "@ID", DbType.Int32, Ls_Datos.IDNAVIERA)
                db.AddInParameter(cmd, "@NAVIERA", DbType.String, Ls_Datos.NAVIERA)
                db.AddInParameter(cmd, "@ID_TIPO", DbType.Int32, Ls_Datos.IDTIPO)
                db.AddInParameter(cmd, "@DESC_TIPO", DbType.String, Ls_Datos.DESCTIPO)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function APRUEBA_TARIFA(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.APRUEBA_TARIFA)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function LISTA_TARIFA_NAV(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTA_TARIFA_NAV)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@ID_NAVIERA", DbType.Int32, Ls_Datos.ID)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function MANT_TARIFA_NAV(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.MANT_TARIFA_NAV)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@ID", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@ID_NAVIERA", DbType.Int32, Ls_Datos.IDNAVIERA)
                db.AddInParameter(cmd, "@CONCEPTO", DbType.String, Ls_Datos.Descripcion)
                db.AddInParameter(cmd, "@MONEDA", DbType.String, Ls_Datos.Moneda)
                db.AddInParameter(cmd, "@TARIFA", DbType.Decimal, Ls_Datos.Total)
                db.AddInParameter(cmd, "@FLG_APROBACION", DbType.String, Ls_Datos.aprobado)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                db.AddInParameter(cmd, "@TIPO", DbType.String, Ls_Datos.tipotarifa)
                db.AddInParameter(cmd, "@FACTOR", DbType.Decimal, Ls_Datos.Factor)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function APRUEBA_TARIFA_NAV(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.APRUEBA_TARIFA_NAV)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@IDTARIFA", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@FLGAPROBADO", DbType.String, Ls_Datos.aprobado)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function LISTA_TRAZA_COSTO(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTA_TRAZA_COSTO)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function LISTA_TRAZA_COSTO_MOL(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTA_TRAZA_COSTO_MOL)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@FLGADM", DbType.Int32, Ls_Datos.flgADM)
                db.AddInParameter(cmd, "@FLGVENTA", DbType.Int32, Ls_Datos.flgVENTA)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function LISTA_TRAZA_COSTO_CH(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTA_TRAZA_COSTO_CH)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@FLGADM", DbType.Int32, Ls_Datos.flgADM)
                db.AddInParameter(cmd, "@FLGVENTA", DbType.Int32, Ls_Datos.flgVENTA)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function LISTA_TRAZA_COSTO_MIN(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTA_TRAZA_COSTO_MIN)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function MANT_PARA_CAMPANIA(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.MANT_PARA_CAMPANIA)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@OPE", DbType.Int32, Ls_Datos.Tipo)
                db.AddInParameter(cmd, "@ID", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@NRO", DbType.String, Ls_Datos.numdoc)
                db.AddInParameter(cmd, "@COD_EQUIPO", DbType.String, Ls_Datos.CodEquipo)
                db.AddInParameter(cmd, "@EQUIPO", DbType.String, Ls_Datos.Equipo)
                db.AddInParameter(cmd, "@FECHAINICIO", DbType.DateTime, Ls_Datos.FechaInicio)
                db.AddInParameter(cmd, "@FECHAFIN", DbType.DateTime, Ls_Datos.FechaTerminacion)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INDICADOR_ENERGIA(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INDICADOR_ENERGIA)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES1", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MES2", DbType.Int32, Ls_Datos.Mes1)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function CAPACIDAD_CEMENTO(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.CAPACIDAD_CEMENTO)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INDICADOR_DEVOLUCION(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INDICADOR_DEVOLUCION)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INDICADOR_VARIOS(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INDICADOR_VARIOS)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RPT_MIN_CANTERA(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RPT_MIN_CANTERA)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MES1", DbType.String, Ls_Datos.Mes1)
                db.AddInParameter(cmd, "@CODCANTERA", DbType.String, Ls_Datos.Cod_Cantera)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RPT_MIN_CANTERA_T(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RPT_MIN_CANTERA_T)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MES1", DbType.String, Ls_Datos.Mes1)
                db.AddInParameter(cmd, "@CODCANTERA", DbType.String, Ls_Datos.Cod_Cantera)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_COST_MINERAL_DET(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_COST_MINERAL_DET)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RPT_GUIA_FACTURA(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RPT_GUIA_FACTURA)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_COST_RUMA_COMPARATIVO(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_COST_RUMA_COMPARATIVO)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@AYO1", DbType.Int32, Ls_Datos.Anho1)
                db.AddInParameter(cmd, "@MES1", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MES2", DbType.Int32, Ls_Datos.Mes1)
                db.AddInParameter(cmd, "@COD_RUMA", DbType.String, Ls_Datos.CodProducto)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_COST_CH_COMPARATIVO(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_COST_CH_COMPARATIVO)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@AYO1", DbType.Int32, Ls_Datos.Anho1)
                db.AddInParameter(cmd, "@MES1", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MES2", DbType.Int32, Ls_Datos.Mes1)
                db.AddInParameter(cmd, "@COD_EQUIPO", DbType.String, Ls_Datos.CodProducto)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_COST_MOLINO_COMPARATIVO(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_COST_MOLINO_COMPARATIVO)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@AYO1", DbType.Int32, Ls_Datos.Anho1)
                db.AddInParameter(cmd, "@MES1", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MES2", DbType.Int32, Ls_Datos.Mes1)
                db.AddInParameter(cmd, "@COD_EQUIPO", DbType.String, Ls_Datos.CodProducto)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaActivoClase(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaActivoClase)
                db.AddInParameter(cmd, "@Placa", DbType.String, Ls_Datos.Placa)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaTipoComb(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaTipoComb)
                'db.AddInParameter(cmd, "@Placa", DbType.String, Ls_Datos.Placa)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_MantActivos(ByVal Ls_Datos As ETProducto, ByVal dtDetalle As DataTable) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_MantActivoTipo)
                db.AddInParameter(cmd, "@placa", DbType.String, Ls_Datos.Placa)
                db.AddInParameter(cmd, "@idtipo", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@usuario", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)

                If dtDetalle.Rows.Count > 0 Then
                    For i As Int32 = 0 To dtDetalle.Rows.Count - 1
                        Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_MantActivoClase)
                        db.AddInParameter(xmd, "@placa", DbType.String, Ls_Datos.Placa)
                        db.AddInParameter(xmd, "@idclase", DbType.Int32, dtDetalle.Rows(i)("idclase"))
                        db.AddInParameter(xmd, "@porcentaje", DbType.Double, dtDetalle.Rows(i)("porcentaje"))
                        db.AddInParameter(xmd, "@usuario", DbType.String, Ls_Datos.Usuario)
                        dt = db.ExecuteDataSet(xmd).Tables(0)
                    Next
                End If

                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListacostoPromedio(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListacostoPromedio)
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@ayo", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@usuario", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListacostoPromedio_Rango(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListacostoPromedio_Rango)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@ayo", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@mes1", DbType.Int32, Ls_Datos.Mes1)
                db.AddInParameter(cmd, "@usuario", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd) '.Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_Abrir_Margenes(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_Abrir_Margenes)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@ayo", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@usuario", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function


    Public Function Costo_VerificaTipo(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_VerificaTipo)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@ayo", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@mes1", DbType.Int32, Ls_Datos.Mes1)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_IngresaTipo(ByVal Ls_Datos As ETProducto) As Int32
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_IngresaTipo)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@ACCION", DbType.String, Ls_Datos.Accion)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@IDGRUPO", DbType.Int32, Ls_Datos.ID)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                db.AddInParameter(cmd, "@TERMINAL", DbType.String, Ls_Datos.Terminal)
                db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return 1
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ProcesaMargen(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ProcesaMargen)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@pa_ano", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@pa_mes", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@pa_mes1", DbType.Int32, Ls_Datos.Mes1)
                db.AddInParameter(cmd, "@usuario", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaProducto(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaProducto)
                db.AddInParameter(cmd, "@ayo", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaCantera(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaCantera)
                'db.AddInParameter(cmd, "@ayo", DbType.Int32, Ls_Datos.Anho)
                'db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ClonarRegistro(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ClonarRegistro)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@COD_PRODPDC", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@NUEVO_COD", DbType.String, Ls_Datos.CodProdPDCObs)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ClonarRegistro_Rango(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ClonarRegistro_Rango)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MES1", DbType.Int32, Ls_Datos.Mes1)
                db.AddInParameter(cmd, "@COD_PRODPDC", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@NUEVO_COD", DbType.String, Ls_Datos.CodProdPDCObs)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ClonarEnvase(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ClonarEnvase)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@COD_PROD_N", DbType.String, Ls_Datos.CodProdPDCObs)
                'db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_Prom_EliminarRegistro(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_Prom_EliminarRegistro)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MES1", DbType.Int32, Ls_Datos.Mes1)
                db.AddInParameter(cmd, "@COD_PRODPDC", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaConcepto(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaConcepto)
                'db.AddInParameter(cmd, "@ayo", DbType.Int32, Ls_Datos.Anho)
                'db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_Prom_IngresoRegistro(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_Prom_IngresoRegistro)
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@MINVARD", DbType.Double, Ls_Datos.MinVarD)
                db.AddInParameter(cmd, "@MINVARI", DbType.Double, Ls_Datos.MinVarI)
                db.AddInParameter(cmd, "@MINFIJD", DbType.Double, Ls_Datos.MinFijD)
                db.AddInParameter(cmd, "@MINFIJI", DbType.Double, Ls_Datos.MinFijI)
                db.AddInParameter(cmd, "@MINFIJO", DbType.Double, Ls_Datos.MinFijO)
                db.AddInParameter(cmd, "@CHAVARD", DbType.Double, Ls_Datos.ChaVarD)
                db.AddInParameter(cmd, "@CHAVARI", DbType.Double, Ls_Datos.ChaVarI)
                db.AddInParameter(cmd, "@CHAFIJD", DbType.Double, Ls_Datos.ChaFijD)
                db.AddInParameter(cmd, "@CHAFIJI", DbType.Double, Ls_Datos.ChaFijI)
                db.AddInParameter(cmd, "@MOLVARD", DbType.Double, Ls_Datos.MolVarD)
                db.AddInParameter(cmd, "@MOLVARI", DbType.Double, Ls_Datos.MolVarI)
                db.AddInParameter(cmd, "@MOLFIJD", DbType.Double, Ls_Datos.MolFijD)
                db.AddInParameter(cmd, "@MOLFIJI", DbType.Double, Ls_Datos.MolFijI)
                db.AddInParameter(cmd, "@ENVASES", DbType.Double, Ls_Datos.Envases)
                db.AddInParameter(cmd, "@GASTOADM", DbType.Double, Ls_Datos.GastoAdm)
                db.AddInParameter(cmd, "@GASTOVTA", DbType.Double, Ls_Datos.GastoVta)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_Prom_IngresoRegistro_Rango(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_Prom_IngresoRegistro_Rango)
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@MES1", DbType.Int32, Ls_Datos.Mes1)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                db.AddInParameter(cmd, "@MINVARD", DbType.Double, Ls_Datos.MinVarD)
                db.AddInParameter(cmd, "@MINVARI", DbType.Double, Ls_Datos.MinVarI)
                db.AddInParameter(cmd, "@MINFIJD", DbType.Double, Ls_Datos.MinFijD)
                db.AddInParameter(cmd, "@MINFIJI", DbType.Double, Ls_Datos.MinFijI)
                db.AddInParameter(cmd, "@MINFIJO", DbType.Double, Ls_Datos.MinFijO)
                db.AddInParameter(cmd, "@CHAVARD", DbType.Double, Ls_Datos.ChaVarD)
                db.AddInParameter(cmd, "@CHAVARI", DbType.Double, Ls_Datos.ChaVarI)
                db.AddInParameter(cmd, "@CHAFIJD", DbType.Double, Ls_Datos.ChaFijD)
                db.AddInParameter(cmd, "@CHAFIJI", DbType.Double, Ls_Datos.ChaFijI)
                db.AddInParameter(cmd, "@MOLVARD", DbType.Double, Ls_Datos.MolVarD)
                db.AddInParameter(cmd, "@MOLVARI", DbType.Double, Ls_Datos.MolVarI)
                db.AddInParameter(cmd, "@MOLFIJD", DbType.Double, Ls_Datos.MolFijD)
                db.AddInParameter(cmd, "@MOLFIJI", DbType.Double, Ls_Datos.MolFijI)
                db.AddInParameter(cmd, "@ENVASES", DbType.Double, Ls_Datos.Envases)
                db.AddInParameter(cmd, "@GASTOADM", DbType.Double, Ls_Datos.GastoAdm)
                db.AddInParameter(cmd, "@GASTOVTA", DbType.Double, Ls_Datos.GastoVta)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaDocumentos(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaDocumentos)
                'db.AddInParameter(cmd, "@ayo", DbType.Int32, Ls_Datos.Anho)
                'db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_IngresoEnergiaGas(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_IngresoEnergiaGas)
                db.AddInParameter(cmd, "@OPE", DbType.Int32, Ls_Datos.Operacion)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@TIPO", DbType.String, Ls_Datos.TipoRecibo)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@TIPODOC", DbType.String, Ls_Datos.tipodoc)
                db.AddInParameter(cmd, "@SERIEDOC", DbType.String, Ls_Datos.seriedoc)
                db.AddInParameter(cmd, "@NUMDOC", DbType.String, Ls_Datos.numdoc)
                db.AddInParameter(cmd, "@CANTIDAD", DbType.Double, Ls_Datos.Cantidad)
                db.AddInParameter(cmd, "@IMPORTE", DbType.Double, Ls_Datos.Monto)
                db.AddInParameter(cmd, "@OBSERVACION", DbType.String, Ls_Datos.Observacion)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaEnergiaGas(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaEnergiaGas)
                db.AddInParameter(cmd, "@ayo", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaAgua(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaAgua)
                db.AddInParameter(cmd, "@ayo", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@mes", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ListaCuentasMPrev(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ListaCuentasMPrev)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_RegistraCuentaMPrev(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_RegistraCuentaMPrev)
                db.AddInParameter(cmd, "@TIPO", DbType.Int32, Ls_Datos.Tipo)
                db.AddInParameter(cmd, "@CGCOD", DbType.String, Ls_Datos.Cuenta)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_CuentasMPrev(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_CuentasMPrev)
                'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                'db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_PorcentajeCosteo(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_PorcentajeCosteo)
                'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                'db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_Mant_PorcentajeCosteo(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_Mant_PorcentajeCosteo)
                db.AddInParameter(cmd, "@PORC_CHANCADORA", DbType.Double, Ls_Datos.PorcChancadora)
                db.AddInParameter(cmd, "@PORC_MOLINO", DbType.Double, Ls_Datos.PorcMolino)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Ls_Datos.Usuario)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetMolienda(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetMolienda)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetChancado(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetChancado)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetMoliendaCAL(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetMoliendaCAL)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetalleMoliendaCAL(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetalleMoliendaCAL)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetalleMoliendaTERRAZO(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetalleMoliendaTERRAZO)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetMoliendaTERRAZO(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetMoliendaTERRAZO)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetalleMoliendaPASTAS(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetalleMoliendaPASTAS)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function


    Public Function Costo_ReporteDetalleMolienda(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetalleMolienda)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetMoliendaPASTAS(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetMoliendaPASTAS)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetMatPrima(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetMatPrima)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetMatPrimaTERRAZO(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetMatPrimaTERRAZO)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetMatPrimaPASTAS(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetMatPrimaPASTAS)
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ReporteDetMineral(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ReporteDetMineral)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.String, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.String, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_TonIngresada(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_TonIngresada)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@ANO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_Bolsa(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_Bolsa)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_Kardex(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_Kardex)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_TonIngresada_Anual(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_TonIngresada_Anual)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@ANO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Costo_ValidaCantera(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_ValidaCantera)
                db.AddInParameter(cmd, "@CADCANTERA", DbType.String, Ls_Datos.Cod_Cantera)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function MantenimientoProyecto(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoProyecto)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@OPE", DbType.Int32, Producto.Operacion)
            db.AddInParameter(cmd, "@ID", DbType.Int32, Producto.ID)
            db.AddInParameter(cmd, "@PROYECTO", DbType.String, Producto.Proyecto)
            db.AddInParameter(cmd, "@DESCRIPCION", DbType.String, Producto.Descripcion)
            db.AddInParameter(cmd, "@COD_AREA", DbType.String, Producto.Area)
            db.AddInParameter(cmd, "@FECHA_INI", DbType.DateTime, Producto.Fecha)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Producto.Usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            MantenimientoProyecto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function MantenimientoProyectoTrabajador(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoProyectoTrabajador)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@OPE", DbType.Int32, Producto.Operacion)
            db.AddInParameter(cmd, "@ID", DbType.Int32, Producto.ID)
            db.AddInParameter(cmd, "@IDPROYECTO", DbType.Int32, Producto.IDPROYECTO)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Producto.Anho)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Producto.Mes)
            db.AddInParameter(cmd, "@CODTRABAJADOR", DbType.String, Producto.CodTrabajador)
            db.AddInParameter(cmd, "@PORCENTAJE", DbType.Decimal, Producto.Porcentaje)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Producto.Usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            MantenimientoProyectoTrabajador = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarProyectoTrabajador(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarProyectoTrabajador)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@IDPROYECTO", DbType.Int32, Producto.IDPROYECTO)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Producto.Anho)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Producto.Mes)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarProyectoTrabajador = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function MantenimientoProyectoEquipo(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoProyectoEquipo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@OPE", DbType.Int32, Producto.Operacion)
            db.AddInParameter(cmd, "@ID", DbType.Int32, Producto.ID)
            db.AddInParameter(cmd, "@IDPROYECTO", DbType.Int32, Producto.IDPROYECTO)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Producto.Anho)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Producto.Mes)
            db.AddInParameter(cmd, "@CODEQUIPO", DbType.String, Producto.CodEquipo)
            db.AddInParameter(cmd, "@PORCENTAJE", DbType.Decimal, Producto.Porcentaje)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Producto.Usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            MantenimientoProyectoEquipo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarProyectoEquipo(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarProyectoEquipo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@IDPROYECTO", DbType.Int32, Producto.IDPROYECTO)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Producto.Anho)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Producto.Mes)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarProyectoEquipo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarProyecto(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarProyecto)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarProyecto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ReplicaProyectoTrabajador(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ReplicaProyectoTrabajador)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@IDPROYECTO", DbType.Int32, Producto.IDPROYECTO)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Producto.Anho)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Producto.Mes)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Producto.Usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ReplicaProyectoTrabajador = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ReplicaProyectoEquipo(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ReplicaProyectoEquipo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@IDPROYECTO", DbType.Int32, Producto.IDPROYECTO)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Producto.Anho)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Producto.Mes)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Producto.Usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ReplicaProyectoEquipo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Costo_DetalleCostoProd(ByVal Ls_Datos As ETProducto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Costo_DetalleCostoProd)
                cmd.CommandTimeout = 6000
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, Ls_Datos.CodProducto)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ListaConInvFiltro(ByVal usuario As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaConInvFiltro)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "USUARIO", DbType.String, usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            'Tabla = New DataTable
            'Tabla = Ds.Tables(0).Copy

            ListaConInvFiltro = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListaConInvData(ByVal fechaini As Date, ByVal fechafin As Date) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaConInvData)
        cmd.CommandTimeout = 0
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@pa_codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "@fecha1", DbType.DateTime, fechaini)
            db.AddInParameter(cmd, "@fecha2", DbType.DateTime, fechafin)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListaConInvData = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ConInvSaldoInicial(ByVal fecha As Date) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConInvSaldoInicial)
        cmd.CommandTimeout = 0
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, fecha)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConInvSaldoInicial = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ConInvConfMeses(ByVal ayo As Int32) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConInvConfMeses)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "@AYO", DbType.Int32, ayo)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConInvConfMeses = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListaConfigMes() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaConfigMes)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "@pa_codcia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "@pa_ano_saldoinicial", DbType.Int32, ayo)
            'db.AddInParameter(cmd, "@pa_mes_saldoinicial", DbType.Int32, 12)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListaConfigMes = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function MantConfigMes(ByVal obj As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantConfigMes)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@ID", DbType.String, obj.ID)
            db.AddInParameter(cmd, "@DESCRIPCION", DbType.String, obj.Descripcion)
            db.AddInParameter(cmd, "@MIN_MESES", DbType.Int32, obj.Mes)
            db.AddInParameter(cmd, "@MAX_MESES", DbType.Int32, obj.Mes1)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj.Usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            MantConfigMes = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListaConInvDataHist(ByVal fechaini As Date, ByVal fechafin As Date) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaConInvDataHist)
        cmd.CommandTimeout = 0
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@pa_codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "@fecha1", DbType.DateTime, fechaini)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListaConInvDataHist = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListaConfigRuma(ByVal idconfig As Int32) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaConfigRuma)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@ID_CONFIG", DbType.Int32, idconfig)
            'db.AddInParameter(cmd, "@pa_ano_saldoinicial", DbType.Int32, ayo)
            'db.AddInParameter(cmd, "@pa_mes_saldoinicial", DbType.Int32, 12)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListaConfigRuma = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function MantConfigRuma(ByVal obj As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantConfigRuma)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try            
            db.AddInParameter(cmd, "@COD_RUMA", DbType.String, obj.CODRUMA)
            db.AddInParameter(cmd, "@ID_CONFIG", DbType.Int32, obj.ID)
            'db.AddInParameter(cmd, "@pa_ano_saldoinicial", DbType.Int32, ayo)
            'db.AddInParameter(cmd, "@pa_mes_saldoinicial", DbType.Int32, 12)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            MantConfigRuma = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListaComentarioControl(ByVal codruma As String, ByVal tipo As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaComentarioControl)
        cmd.CommandTimeout = 0
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@COD_RUMA", DbType.String, codruma)
            db.AddInParameter(cmd, "@TIPO", DbType.String, tipo)
            'db.AddInParameter(cmd, "@fecha2", DbType.DateTime, fechafin)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListaComentarioControl = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function MantComentarioControl(ByVal codruma As String, ByVal OBS As String, ByVal usuario As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantComentarioControl)
        cmd.CommandTimeout = 0
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@COD_RUMA", DbType.String, codruma)
            db.AddInParameter(cmd, "@COMENTARIO", DbType.String, OBS)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            MantComentarioControl = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function RPT_RESUMEN_ENTREGAS(ByVal Ls_Datos As ETProducto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataTable
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.RPT_RESUMEN_ENTREGAS)
                cmd.CommandTimeout = 0
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Ls_Datos.Anho)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Ls_Datos.Mes)
                dt = db.ExecuteDataSet(cmd).Tables(0)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

End Class
