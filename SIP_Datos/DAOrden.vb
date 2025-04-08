
Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAOrden
    Private _Cod_Chancadora As String = String.Empty
    Private _Cod_Turno As Short = 0

    Public Function MantenimientoOrden(ByVal Rpt As ETOrden, _
                                       ByVal Ls_Ruma As List(Of ETRuma), _
                                       ByVal Ls_Empaque As List(Of ETSuministro), _
                                       ByVal Ls_Chancadora As List(Of ETActivo), _
                                       ByVal Ls_Molino As List(Of ETActivo)) As ETOrden

        Dim lResult As ETOrden = Nothing
        If Rpt Is Nothing OrElse Ls_Ruma Is Nothing OrElse Ls_Empaque Is Nothing OrElse Ls_Chancadora Is Nothing OrElse Ls_Molino Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            lResult = New ETOrden

            Try

                Dim Comand1 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoOrden1)

                With Rpt
                    db.AddInParameter(Comand1, "Tipo", DbType.Int16, .Tipo)
                    db.AddInParameter(Comand1, "Companhia", DbType.String, Companhia)
                    db.AddInParameter(Comand1, "Serie", DbType.String, Serie)
                    db.AddParameter(Comand1, "ID", DbType.Int32, 10, _
                                    ParameterDirection.InputOutput, True, 0, 0, "", _
                                    DataRowVersion.Default, .ID)
                    db.AddParameter(Comand1, "NroDocumento", DbType.String, 10, _
                                    ParameterDirection.InputOutput, True, 0, 0, "", _
                                    DataRowVersion.Default, .NroDocumento)
                    db.AddInParameter(Comand1, "CodEnlace", DbType.Int32, .CodEnlace)
                    db.AddInParameter(Comand1, "CodProducto", DbType.String, .CodProducto)
                    db.AddInParameter(Comand1, "Descripcion", DbType.String, .Descripcion)
                    db.AddInParameter(Comand1, "Cantidad", DbType.Decimal, .Cantidad)
                    db.AddInParameter(Comand1, "CantidadReq", DbType.Decimal, .CantidadRequerida)
                    db.AddInParameter(Comand1, "CantidadRecirculado", DbType.Decimal, .CantidadRecirculado)
                    db.AddInParameter(Comand1, "FormulaRecirculado", DbType.Boolean, .FormulaRecirculado)
                    db.AddInParameter(Comand1, "FechaInicio", DbType.Date, .FechaInicio)
                    db.AddInParameter(Comand1, "FechaTerminacion", DbType.Date, .FechaTerminacion)
                    db.AddInParameter(Comand1, "FechaIngreso", DbType.Date, .FechaIngreso)
                    db.AddInParameter(Comand1, "Especificaciones", DbType.String, .Especificaciones)
                    db.AddInParameter(Comand1, "TotalRuma", DbType.Decimal, .TotalRuma)
                    db.AddInParameter(Comand1, "TotalSuministro", DbType.Decimal, .TotalSuministro)
                    db.AddInParameter(Comand1, "TotalChancadora", DbType.Decimal, .TotalChancadora)
                    db.AddInParameter(Comand1, "TotalMolino", DbType.Decimal, .TotalMolino)
                    db.AddInParameter(Comand1, "Usuario", DbType.String, .Usuario)
                    db.AddInParameter(Comand1, "Status", DbType.String, .Status)
                    db.AddOutParameter(Comand1, "Respuesta", DbType.Int16, 10)
                End With

                db.ExecuteNonQuery(Comand1, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(Comand1, "Respuesta"))
                If lResult.Respuesta <> 0 Then Err.Raise(10)
                lResult.ID = Convert.ToInt32(db.GetParameterValue(Comand1, "ID"))
                lResult.NroDocumento = Convert.ToString(db.GetParameterValue(Comand1, "NroDocumento"))

                For Each Entidad.Ruma In Ls_Ruma
                    Dim Comand2 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoOrden2)
                    With Entidad.Ruma
                        db.AddInParameter(Comand2, "TipoEnlace", DbType.String, .TipoEnlace)
                        db.AddInParameter(Comand2, "ID", DbType.Int32, lResult.ID)
                        db.AddInParameter(Comand2, "Item", DbType.Int32, .Item)
                        db.AddInParameter(Comand2, "CodRuma", DbType.String, .CodRuma)
                        db.AddInParameter(Comand2, "DesRuma", DbType.String, .DesRuma)
                        db.AddInParameter(Comand2, "Codigo", DbType.String, .Codigo)
                        db.AddInParameter(Comand2, "Descripcion", DbType.String, .Descripcion)

                        db.AddInParameter(Comand2, "Porcentaje", DbType.Decimal, .Porcentaje)
                        db.AddInParameter(Comand2, "Humedad", DbType.Decimal, .Humedad)
                        db.AddInParameter(Comand2, "Merma", DbType.Decimal, .Merma)

                        db.AddInParameter(Comand2, "Nro_OC", DbType.String, .Nro_OC)

                        db.AddInParameter(Comand2, "Cantidad", DbType.Decimal, .Cantidad)
                        db.AddInParameter(Comand2, "CantidadxRuma", DbType.Decimal, .CantidadxFraccionada)
                        db.AddInParameter(Comand2, "StockRuma", DbType.Decimal, .StockRuma)
                        db.AddInParameter(Comand2, "StockMineral", DbType.Decimal, .StockMineral)
                        db.AddInParameter(Comand2, "CantidadxMineral", DbType.Decimal, .CantidadSubRecurso)
                        db.AddInParameter(Comand2, "CantidadxNecesaria", DbType.Decimal, .CantidadxNecesaria)
                        db.AddInParameter(Comand2, "CantxRumaxNecesaria", DbType.Decimal, .CantxRumaxNecesaria)
                        db.AddInParameter(Comand2, "CostoxExtraccion", DbType.Decimal, .CostoxExtraccion)
                        db.AddInParameter(Comand2, "CostoxCompra", DbType.Decimal, .CostoxCompra)
                        db.AddInParameter(Comand2, "CostoxRegalias", DbType.Decimal, .CostoxRegalias)
                        db.AddInParameter(Comand2, "CostoxFlete", DbType.Decimal, .CostoxFlete)
                        db.AddInParameter(Comand2, "CostoxOtros", DbType.Decimal, .CostoxOtros)
                        db.AddInParameter(Comand2, "CostoxRuma", DbType.Decimal, .CostoxRuma)
                        db.AddInParameter(Comand2, "SubTotal", DbType.Decimal, .SubTotal)
                        db.AddInParameter(Comand2, "Usuario", DbType.String, Rpt.Usuario)
                        db.AddOutParameter(Comand2, "Respuesta", DbType.Int16, 10)

                    End With
                    db.ExecuteNonQuery(Comand2, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(Comand2, "Respuesta"))
                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                For Each Entidad.Suministro In Ls_Empaque
                    Dim Comand3 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoOrden3)
                    With Entidad.Suministro
                        db.AddInParameter(Comand3, "ID", DbType.Int32, lResult.ID)
                        db.AddInParameter(Comand3, "Item", DbType.Int32, .Item)
                        db.AddInParameter(Comand3, "CodSuministro", DbType.String, .CodSuministro)
                        db.AddInParameter(Comand3, "Descripcion", DbType.String, .Descripcion)
                        db.AddInParameter(Comand3, "Peso", DbType.Decimal, .Peso)
                        db.AddInParameter(Comand3, "Unidad", DbType.String, .Unidad)
                        db.AddInParameter(Comand3, "UndDesp", DbType.String, .UndDesp)
                        db.AddInParameter(Comand3, "CostoUnitario", DbType.Decimal, .CostoUnitario)
                        db.AddInParameter(Comand3, "CantidadUnitaria", DbType.Int32, .CantidadUnitaria)
                        db.AddInParameter(Comand3, "Cantidad", DbType.Int32, .Cantidad)
                        db.AddInParameter(Comand3, "SubTotal", DbType.Decimal, .SubTotal)
                        db.AddInParameter(Comand3, "Usuario", DbType.String, Rpt.Usuario)
                        db.AddOutParameter(Comand3, "Respuesta", DbType.Int16, 10)
                    End With
                    db.ExecuteNonQuery(Comand3, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(Comand3, "Respuesta"))
                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                For Each Entidad.Activo In Ls_Chancadora
                    Dim Comand4 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoOrden4)
                    With Entidad.Activo
                        db.AddInParameter(Comand4, "ID", DbType.Int32, lResult.ID)
                        db.AddInParameter(Comand4, "Item", DbType.Int32, .Item)
                        db.AddInParameter(Comand4, "CodLote", DbType.String, .CodLote)
                        db.AddInParameter(Comand4, "Fecha", DbType.Date, .Fecha)
                        db.AddInParameter(Comand4, "Turno", DbType.Int16, .Turno)
                        db.AddInParameter(Comand4, "CodClase", DbType.String, .CodClase)
                        db.AddInParameter(Comand4, "CodTipo", DbType.String, .CodTipo)
                        db.AddInParameter(Comand4, "Placa", DbType.String, .Placa)
                        db.AddInParameter(Comand4, "Descripcion", DbType.String, .Descripcion)
                        db.AddInParameter(Comand4, "Rendimiento", DbType.Decimal, .Rendimiento)
                        db.AddInParameter(Comand4, "Horas", DbType.Decimal, .Horas)
                        db.AddInParameter(Comand4, "Energia", DbType.Decimal, .Energia)
                        db.AddInParameter(Comand4, "NroOperarios", DbType.Int16, .NroOperarios)
                        db.AddInParameter(Comand4, "CostoPromxHora", DbType.Decimal, .CostoPromxHora)
                        db.AddInParameter(Comand4, "CostoKwxHora", DbType.Decimal, .CostoKwxHora)
                        db.AddInParameter(Comand4, "MODhhxtn", DbType.Decimal, .MODhhxtn)
                        db.AddInParameter(Comand4, "MODSolxtn", DbType.Decimal, .MODSolxtn)
                        db.AddInParameter(Comand4, "EnergiaSolxtn", DbType.Decimal, .EnergiaSolxtn)
                        db.AddInParameter(Comand4, "CostoxTon", DbType.Decimal, .CostoxTon)
                        db.AddInParameter(Comand4, "TonMaximo", DbType.Decimal, .TonMaximo)
                        db.AddInParameter(Comand4, "TonUtilizado", DbType.Decimal, .TonUtilizado)
                        db.AddInParameter(Comand4, "Uso", DbType.Int32, .Uso)
                        db.AddInParameter(Comand4, "SubTotal", DbType.Decimal, .SubTotal)
                        db.AddInParameter(Comand4, "Usuario", DbType.String, Rpt.Usuario)
                        db.AddOutParameter(Comand4, "Respuesta", DbType.Int16, 10)
                    End With
                    db.ExecuteNonQuery(Comand4, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(Comand4, "Respuesta"))
                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                For Each Entidad.Activo In Ls_Molino
                    Dim Comand5 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoOrden4)
                    With Entidad.Activo
                        db.AddInParameter(Comand5, "ID", DbType.Int32, lResult.ID)
                        db.AddInParameter(Comand5, "Item", DbType.Int32, .Item)
                        db.AddInParameter(Comand5, "CodLote", DbType.String, .CodLote)
                        db.AddInParameter(Comand5, "Fecha", DbType.Date, .Fecha)
                        db.AddInParameter(Comand5, "Turno", DbType.Int16, .Turno)
                        db.AddInParameter(Comand5, "CodClase", DbType.String, .CodClase)
                        db.AddInParameter(Comand5, "CodTipo", DbType.String, .CodTipo)
                        db.AddInParameter(Comand5, "Placa", DbType.String, .Placa)
                        db.AddInParameter(Comand5, "Descripcion", DbType.String, .Descripcion)
                        db.AddInParameter(Comand5, "Rendimiento", DbType.Decimal, .Rendimiento)
                        db.AddInParameter(Comand5, "Horas", DbType.Decimal, .Horas)
                        db.AddInParameter(Comand5, "Energia", DbType.Decimal, .Energia)
                        db.AddInParameter(Comand5, "NroOperarios", DbType.Int16, .NroOperarios)
                        db.AddInParameter(Comand5, "CostoPromxHora", DbType.Decimal, .CostoPromxHora)
                        db.AddInParameter(Comand5, "CostoKwxHora", DbType.Decimal, .CostoKwxHora)
                        db.AddInParameter(Comand5, "MODhhxtn", DbType.Decimal, .MODhhxtn)
                        db.AddInParameter(Comand5, "MODSolxtn", DbType.Decimal, .MODSolxtn)
                        db.AddInParameter(Comand5, "EnergiaSolxtn", DbType.Decimal, .EnergiaSolxtn)
                        db.AddInParameter(Comand5, "CostoxTon", DbType.Decimal, .CostoxTon)
                        db.AddInParameter(Comand5, "TonMaximo", DbType.Decimal, .TonMaximo)
                        db.AddInParameter(Comand5, "TonUtilizado", DbType.Decimal, .TonUtilizado)
                        db.AddInParameter(Comand5, "Uso", DbType.Int32, .Uso)
                        db.AddInParameter(Comand5, "SubTotal", DbType.Decimal, .SubTotal)
                        db.AddInParameter(Comand5, "Usuario", DbType.String, Rpt.Usuario)
                        db.AddOutParameter(Comand5, "Respuesta", DbType.Int16, 10)
                    End With
                    db.ExecuteNonQuery(Comand5, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(Comand5, "Respuesta"))
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

        Rpt = Nothing
        Ls_Ruma = Nothing
        Ls_Empaque = Nothing
        Ls_Chancadora = Nothing
        Ls_Molino = Nothing

        Return lResult

    End Function

    Public Function ConsultarOrden1() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 1)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Orden = New ETOrden
                    With Entidad.Orden
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .NroDocumento = dr.GetString(dr.GetOrdinal("NroDocumento"))
                        .CodEnlace = dr.GetInt32(dr.GetOrdinal("CodEnlace"))
                        .CodProducto = dr.GetString(dr.GetOrdinal("CodProducto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("FechaCreacion"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                    End With
                    lResult.Ls_Orden.Add(Entidad.Orden)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult

        'Dim lResult As ETOrden = Nothing
        'Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden)
        'Dim Ds As DataSet = Nothing
        'Dim Tabla As DataTable = Nothing
        'Try

        '    db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)

        '    Ds = New DataSet
        '    Ds = db.ExecuteDataSet(cmd)

        '    Tabla = New DataTable
        '    Tabla = Ds.Tables(0).Copy

        '    If Tabla.Rows.Count > 0 Then
        '        lResult = New ETOrden
        '        lResult.Tabla = Tabla.Copy
        '        lResult.Validacion = Boolean.TrueString
        '    End If

        'Catch Err As Exception

        '    MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        '    lResult = New ETOrden

        'Finally

        '    If Tabla IsNot Nothing Then Tabla = Nothing
        '    If Ds IsNot Nothing Then Ds = Nothing

        'End Try

        'Return lResult

    End Function

    Public Function ConsultarOrden2(ByVal Rpt As ETOrden) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 2)
            db.AddInParameter(cmd, "NroDocumento", DbType.String, Rpt.NroDocumento)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read
                    Entidad.Orden = New ETOrden
                    With Entidad.Orden
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .CodEnlace = dr.GetInt32(dr.GetOrdinal("CodEnlace"))
                        .NroDocumento = dr.GetString(dr.GetOrdinal("NroDocumento"))
                        .CodProducto = dr.GetString(dr.GetOrdinal("CodProducto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                        .CantidadRequerida = dr.GetDecimal(dr.GetOrdinal("CantidadReq"))
                        .CantidadRecirculado = dr.GetDecimal(dr.GetOrdinal("CantidadRecirculado"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTerminacion"))
                        .FechaIngreso = dr.GetDateTime(dr.GetOrdinal("FechaIngreso"))
                        .Especificaciones = dr.GetString(dr.GetOrdinal("Especificaciones"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("FechaCreacion"))
                        .FormulaRecirculado = dr.GetBoolean(dr.GetOrdinal("FormulaRecirculado"))
                        .FechaActualizacion = dr.GetDateTime(dr.GetOrdinal("FechaModificacion"))
                    End With
                    lResult.Ls_Orden.Add(Entidad.Orden)
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

    Public Function ConsultarOrden3(ByVal Rpt As ETOrden) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden)

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 3)
            db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)

            lResult = New ETMyLista
            Dim ds As New DataSet
            
            ds = db.ExecuteDataSet(cmd)

            lResult.DataTable1 = ds.Tables(1)
            lResult.DataTable2 = ds.Tables(2)

            For Each xRow As DataRow In ds.Tables(0).Rows
                Entidad.Ruma = New ETRuma
                With Entidad.Ruma
                    .TipoEnlace = xRow("TipoEnlace")
                    .CodRuma = xRow("CodRuma")
                    .DesRuma = xRow("DesRuma")
                    .Codigo = xRow("Codigo")
                    .Descripcion = xRow("Descripcion")
                    .Porcentaje = xRow("Porcentaje")
                    .Humedad = xRow("Humedad")
                    .Merma = xRow("Merma")
                    .Cantidad = xRow("Cantidad")
                    .CantidadxFraccionada = xRow("CantidadxRuma")
                    .StockRuma = xRow("StockRuma")
                    .StockMineral = xRow("StockMineral")
                    .CantidadSubRecurso = xRow("CantidadxMineral")
                    .CantidadxNecesaria = xRow("CantidadxNecesaria")
                    .CostoxExtraccion = xRow("CostoxExtraccion")
                    .CostoxCompra = xRow("CostoxCompra")
                    .CostoxRegalias = xRow("CostoxRegalia")
                    .CostoxFlete = xRow("CostoxFlete")
                    .CostoxOtros = xRow("CostoxOtros")
                    .CostoxRuma = xRow("CostoxRuma")
                    .SubTotal = xRow("SubTotal")
                    .Nro_OC = xRow("Nro_OC")
                End With
                Select Case xRow("TipoEnlace").ToString.Trim
                    Case "PRODUCTO"
                        lResult.Ls_Formulacion_Producto.Add(Entidad.Ruma)
                    Case "SUMINISTRO"
                        lResult.Ls_Formulacion_Suministro.Add(Entidad.Ruma)
                    Case "RECIRCULADO"
                        lResult.Ls_Formulacion_Recirculado.Add(Entidad.Ruma)
                End Select
                lResult.Ls_Ruma.Add(Entidad.Ruma)
            Next

            lResult.Validacion = Boolean.TrueString
            
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function

    Public Function ConsultarOrden4(ByVal Rpt As ETOrden) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 4)
            db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Suministro = New ETSuministro
                    With Entidad.Suministro
                        .CodSuministro = dr.GetString(dr.GetOrdinal("CodSuministro"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Peso = dr.GetDecimal(dr.GetOrdinal("Peso"))
                        .Unidad = dr.GetString(dr.GetOrdinal("Unidad"))
                        .UndDesp = dr.GetString(dr.GetOrdinal("UndDesp"))
                        .CostoUnitario = dr.GetDecimal(dr.GetOrdinal("CostoUnitario"))
                        .CantidadUnitaria = dr.GetInt32(dr.GetOrdinal("CantidadUnitaria"))
                        .Cantidad = dr.GetInt32(dr.GetOrdinal("Cantidad"))
                        .SubTotal = dr.GetDecimal(dr.GetOrdinal("SubTotal"))
                    End With
                    lResult.Ls_Suministro.Add(Entidad.Suministro)
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

    Public Function ConsultarOrden5(ByVal O As ETOrden, ByVal A As ETActivo) As List(Of ETActivo)

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden)
        Dim lst As New List(Of ETActivo)
        Dim E As ETActivo = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 5)
            db.AddInParameter(cmd, "ID", DbType.Int32, O.ID)
            db.AddInParameter(cmd, "CodTipo", DbType.String, A.CodTipo)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETActivo
                    E.CodLote = dr.GetString(dr.GetOrdinal("CodLote"))
                    E.Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    E.Turno = dr.GetInt16(dr.GetOrdinal("Turno"))
                    E.CodClase = dr.GetString(dr.GetOrdinal("CodClase"))
                    E.CodTipo = dr.GetString(dr.GetOrdinal("CodTipo"))
                    E.Placa = dr.GetString(dr.GetOrdinal("Placa"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    E.Rendimiento = dr.GetDecimal(dr.GetOrdinal("Rendimiento"))
                    E.Horas = dr.GetDecimal(dr.GetOrdinal("Horas"))
                    E.Energia = dr.GetDecimal(dr.GetOrdinal("Energia"))
                    E.NroOperarios = dr.GetInt16(dr.GetOrdinal("NroOperarios"))
                    E.CostoPromxHora = dr.GetDecimal(dr.GetOrdinal("CostoPromxHora"))
                    E.CostoKwxHora = dr.GetDecimal(dr.GetOrdinal("CostoKwxHora"))
                    E.MODhhxtn = dr.GetDecimal(dr.GetOrdinal("MODhhxtn"))
                    E.EnergiaSolxtn = dr.GetDecimal(dr.GetOrdinal("EnergiaSolxtn"))
                    E.CostoxTon = dr.GetDecimal(dr.GetOrdinal("CostoxTon"))
                    E.TonMaximo = dr.GetDecimal(dr.GetOrdinal("TonMaximo"))
                    E.TonUtilizado = dr.GetDecimal(dr.GetOrdinal("TonUtilizado"))
                    E.Uso = dr.GetInt16(dr.GetOrdinal("Uso"))
                    E.SubTotal = dr.GetDecimal(dr.GetOrdinal("SubTotal"))
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

    Public Function ConsultarOrden9(ByVal Rpt As ETOrden) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd1 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden)
        Dim cmd2 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden)

        Try
            ' PERSONAL
            db.AddInParameter(cmd1, "Tipo", DbType.Int16, 10)
            db.AddInParameter(cmd1, "ID", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd1, "CodTipo", DbType.String, Rpt.Tipo_Doc)
            db.AddInParameter(cmd1, "CodActivo", DbType.String, Rpt.Cod_Chancadora)
            db.AddInParameter(cmd1, "FechaFinal", DbType.DateTime, Rpt.Fecha.Date)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd1)
                While dr.Read
                    Entidad.Personal = New ETPersonal
                    With Entidad.Personal
                        .Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                        .CodUnidadProd = dr.GetString(dr.GetOrdinal("CodUnidadProd"))
                        .Turno = dr.GetInt16(dr.GetOrdinal("Turno"))
                        .DesTurno = dr.GetString(dr.GetOrdinal("DesTurno"))
                        .CodPersonal = dr.GetString(dr.GetOrdinal("CodPersonal"))
                        .DesPersonal = dr.GetString(dr.GetOrdinal("DesPersonal"))
                    End With

                    lResult.Ls_Personal.Add(Entidad.Personal)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

            ' chancadora
            db.AddInParameter(cmd2, "Tipo", DbType.Int16, 9)
            db.AddInParameter(cmd2, "ID", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd2, "CodTipo", DbType.String, Rpt.Tipo_Doc)
            db.AddInParameter(cmd2, "CodActivo", DbType.String, Rpt.Cod_Chancadora)
            db.AddInParameter(cmd2, "FechaFinal", DbType.DateTime, Rpt.Fecha.Date)

            Using dr As IDataReader = db.ExecuteReader(cmd2)
                While dr.Read

                    _Cod_Chancadora = dr.GetString(dr.GetOrdinal("CodChancPesaje"))
                    _Cod_Turno = dr.GetInt16(dr.GetOrdinal("Turno"))

                    Entidad.Activo = New ETActivo
                    With Entidad.Activo
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .Item = dr.GetInt32(dr.GetOrdinal("Item"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .CodClase = dr.GetString(dr.GetOrdinal("CodClase"))
                        .CodTipo = dr.GetString(dr.GetOrdinal("CodTipo"))
                        .CodInterno = dr.GetString(dr.GetOrdinal("CodChancPesaje"))
                        .Codigo = dr.GetString(dr.GetOrdinal("CodChancadora"))
                        .Turno = dr.GetInt16(dr.GetOrdinal("Turno"))
                        .Horas = dr.GetDecimal(dr.GetOrdinal("Horas"))
                        .HorasParada = dr.GetDecimal(dr.GetOrdinal("HorasParada"))
                        .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                        .Ls_Personal = lResult.Ls_Personal.Where(AddressOf Where_Personal_Turno).ToList
                        .NroOperarios = .ListaPersonal.Count
                    End With

                    lResult.Ls_Activo.Add(Entidad.Activo)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString

            End Using
            ' CHANCADORA TURNO
            lResult.Validacion = True
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function

    Public Function ConsultarOrden12(ByVal O As ETOrden) As List(Of ETActivo)

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden)
        Dim lst As New List(Of ETActivo)
        Dim E As ETActivo = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 12)
            db.AddInParameter(cmd, "ID", DbType.Int32, O.ID)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, O.CodRuma)
            db.AddInParameter(cmd, "CodTipo", DbType.String, O.Tipo_Doc)
            db.AddInParameter(cmd, "NroDocumento", DbType.String, O.NroDocumento)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETActivo
                    E.Action = True
                    E.Placa = dr.GetString(dr.GetOrdinal("Cod_Molino"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Molino"))
                    E.Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
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

    Public Function ConsultarOrden13(ByVal O As ETOrden) As List(Of ETActivo)

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden)
        Dim lst As New List(Of ETActivo)
        Dim E As ETActivo = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 13)
            db.AddInParameter(cmd, "ID", DbType.Int32, O.ID)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read
                    E = New ETActivo
                    E.Action = True
                    E.Placa = dr.GetString(dr.GetOrdinal("Cod_Molino"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Molino"))
                    E.Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                    lst.Add(E)
                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lst = New List(Of ETActivo)
            Return lst
        End Try

        Return lst

    End Function

    Public Function Consultar_Orden_PesajeRuma(ByVal Rpt As ETOrden) As DataSet
        Dim lResult As DataSet = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden_Pesaje_Ruma)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "NroOrden", DbType.Int32, Rpt.ID)

            lResult = New DataSet

            lResult = db.ExecuteDataSet(cmd)

            lResult.Tables(0).TableName = "Ruma"
            lResult.Tables(1).TableName = "Mineral"

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult
    End Function

    Public Function Consultar_Orden_Chancadora_Pesaje(ByVal Rpt As ETOrden) As DataSet
        Dim lResult As New DataSet
        Dim E As ETOrden = Nothing
        If Rpt Is Nothing Then
            Return Nothing
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden_Chancadora_Pesaje)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "NroOrden", DbType.Int32, Rpt.ID)

            lResult = db.ExecuteDataSet(cmd)

            lResult.Tables(0).TableName = "Activo"
            lResult.Tables(1).TableName = "Mineral"

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult
    End Function

    Public Function Consultar_Orden_Chancadora_Molino(ByVal Rpt As ETOrden) As DataSet
        Dim lResult As New DataSet
        Dim E As ETOrden = Nothing
        If Rpt Is Nothing Then
            Return Nothing
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden_Chancadora_Molino)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "NroOrden", DbType.Int32, Rpt.ID)

            lResult = db.ExecuteDataSet(cmd)

            lResult.Tables(0).TableName = "Activo"
            lResult.Tables(1).TableName = "Mineral"

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult
    End Function

    Public Function Consultar_Orden_Molienda_IngresoProd(ByVal Rpt As ETOrden) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim O As ETOrden = Nothing
        If Rpt Is Nothing Then
            Return Nothing
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden_Molienda_IP)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "Cod_Molino", DbType.String, Rpt.CodMolino)
            db.AddInParameter(cmd, "Cod_ALM", DbType.String, Rpt.Cod_Alm)

            lResult = New ETMyLista


            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    O = New ETOrden
                    With O
                        .Lote = dr.GetString(dr.GetOrdinal("Lote"))
                        .CodMolino = dr.GetString(dr.GetOrdinal("Cod_Molino"))
                        .Tipo_Mov = dr.GetString(dr.GetOrdinal("Tipo_Mov"))
                        .Tipo_Doc = dr.GetString(dr.GetOrdinal("Tipo_Doc"))
                        .NroDocumento = dr.GetString(dr.GetOrdinal("NumDoc"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Turno = dr.GetInt16(dr.GetOrdinal("CodTurno"))
                        .Cod_Alm = dr.GetString(dr.GetOrdinal("Almacen"))
                        .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                        .UnidProd = dr.GetString(dr.GetOrdinal("Unidad"))
                        .NroInicio = dr.GetInt32(dr.GetOrdinal("NroBolsaIni"))
                        .NroTermino = dr.GetInt32(dr.GetOrdinal("NroBolsaFin"))
                        .HorasMax = dr.GetDecimal(dr.GetOrdinal("HorasMax"))
                        .HorasTrabajadas = dr.GetDecimal(dr.GetOrdinal("HorasTrab"))
                        .HorasParada = dr.GetDecimal(dr.GetOrdinal("HorasParada"))
                        .NroOpe = dr.GetInt16(dr.GetOrdinal("NroOpe"))
                        .CodProducto = dr.GetString(dr.GetOrdinal("Cod_Prod"))
                        .Factor = dr.GetDecimal(dr.GetOrdinal("Factm"))
                    End With
                    lResult.Ls_Orden.Add(O)
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


    Public Function ConsultarOrden_Busqueda(ByVal Rpt As ETOrden) As ETOrden

        Dim lResult As ETOrden = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarOrden)
        Dim Ds As DataSet = Nothing
        Dim Tabla As DataTable = Nothing
        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, Rpt.Tipo)
            db.AddInParameter(cmd, "NroDocumento", DbType.String, Rpt.NroDocumento)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Rpt.CodProducto)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Rpt.FechaInicio)
            db.AddInParameter(cmd, "FechaFinal", DbType.DateTime, Rpt.FechaTerminacion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            If Tabla.Rows.Count > 0 Then
                lResult = New ETOrden
                lResult.Tabla = Tabla.Copy
                lResult.Validacion = Boolean.TrueString
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = New ETOrden

        Finally

            If Tabla IsNot Nothing Then Tabla = Nothing
            If Ds IsNot Nothing Then Ds = Nothing

        End Try

        Return lResult

    End Function

    Public Function MantenimientoOrden5(ByVal Rpt As ETOrden, _
                                     ByVal Ls_Activo As List(Of ETActivo), _
                                     ByVal Ls_Ruma As List(Of ETOrden)) As ETOrden

        Dim lResult As ETOrden = Nothing
        If Rpt Is Nothing OrElse Ls_Ruma Is Nothing OrElse Ls_Activo Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            lResult = New ETOrden

            Try
                For Each xRow As ETActivo In Ls_Activo

                    Dim Comand As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoOrden5)
                    With Rpt
                        db.AddInParameter(Comand, "Tipo", DbType.Int16, 3)
                        db.AddInParameter(Comand, "ID", DbType.Int32, .ID)
                        db.AddInParameter(Comand, "Fecha", DbType.DateTime, .Fecha.Date)
                        db.AddInParameter(Comand, "CodChancPesaje", DbType.String, .Cod_Chancadora)
                        db.AddInParameter(Comand, "User", DbType.String, .Usuario)
                        db.AddOutParameter(Comand, "Respuesta", DbType.Int32, 10)
                    End With

                    db.ExecuteNonQuery(Comand, Trans)
                    lResult.ID = Convert.ToInt32(db.GetParameterValue(Comand, "Respuesta"))
                    If lResult.ID = 0 Then Err.Raise(10)

                    Dim Comand1 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoOrden5)
                    With Rpt
                        db.AddInParameter(Comand1, "Tipo", DbType.Int16, 1)
                        db.AddInParameter(Comand1, "ID", DbType.Int32, .ID)
                        db.AddInParameter(Comand1, "Item", DbType.Int32, xRow.Item)
                        db.AddInParameter(Comand1, "Fecha", DbType.DateTime, xRow.Fecha.Date)
                        db.AddInParameter(Comand1, "CodClase", DbType.String, xRow.CodClase)
                        db.AddInParameter(Comand1, "CodTipo", DbType.String, xRow.CodTipo)
                        db.AddInParameter(Comand1, "CodChancPesaje", DbType.String, xRow.CodInterno)
                        db.AddInParameter(Comand1, "CodChancadora", DbType.String, xRow.Codigo)
                        db.AddInParameter(Comand1, "Turno", DbType.Int16, xRow.Turno)
                        db.AddInParameter(Comand1, "Horas", DbType.Decimal, xRow.Horas)
                        db.AddInParameter(Comand1, "HorasParada", DbType.Decimal, xRow.HorasParada)
                        db.AddInParameter(Comand1, "Cantidad", DbType.Decimal, xRow.Cantidad)
                        db.AddInParameter(Comand1, "User", DbType.String, .Usuario)
                        db.AddOutParameter(Comand1, "Respuesta", DbType.Int32, 10)
                    End With

                    db.ExecuteNonQuery(Comand1, Trans)
                    lResult.ID = Convert.ToInt32(db.GetParameterValue(Comand1, "Respuesta"))
                    If lResult.ID = 0 Then Err.Raise(10)

                    For Each yRow As ETOrden In Ls_Ruma
                        Dim Comand2 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoOrden5_D)
                        With yRow
                            db.AddInParameter(Comand2, "ID", DbType.Int32, lResult.ID)
                            db.AddInParameter(Comand2, "Cod_Cia", DbType.String, Companhia)
                            db.AddInParameter(Comand2, "Tipo_Doc", DbType.String, .Tipo_Doc)
                            db.AddInParameter(Comand2, "NumDoc", DbType.String, .NroDocumento)
                            db.AddInParameter(Comand2, "Cod_Molino", DbType.String, .CodMolino)
                            db.AddInParameter(Comand2, "CodRuma", DbType.String, .CodRuma)
                            db.AddInParameter(Comand2, "CodMineral", DbType.String, .CodProducto)
                            db.AddInParameter(Comand2, "Cantidad", DbType.Decimal, .Cantidad)
                            db.AddInParameter(Comand2, "User", DbType.String, Rpt.Usuario)
                            db.AddOutParameter(Comand2, "Respuesta", DbType.Int32, 10)
                        End With
                        db.ExecuteNonQuery(Comand2, Trans)
                        lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(Comand2, "Respuesta"))
                        If lResult.Respuesta <> 0 Then Err.Raise(10)
                    Next

                    For Each zRow As ETPersonal In xRow.ListaPersonal
                        Dim Comand3 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoOrden5_P)
                        With zRow
                            db.AddInParameter(Comand3, "ID", DbType.Int32, lResult.ID)
                            db.AddInParameter(Comand3, "Cod_Cia", DbType.String, Companhia)
                            db.AddInParameter(Comand3, "PlaCod", DbType.String, .CodPersonal)
                            db.AddInParameter(Comand3, "User", DbType.String, Rpt.Usuario)
                            db.AddOutParameter(Comand3, "Respuesta", DbType.Int16, 10)
                        End With
                        db.ExecuteNonQuery(Comand3, Trans)
                        lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(Comand3, "Respuesta"))
                        If lResult.Respuesta <> 0 Then Err.Raise(10)
                    Next
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

        Rpt = Nothing
        Ls_Ruma = Nothing
        Ls_Activo = Nothing

        Return lResult

    End Function

    Public Function MantenimientoOrden5_M(ByVal Ls_Billete As List(Of ETOrden), ByVal Ls_Mineral As List(Of ETOrden)) As ETOrden

        Dim lResult As ETOrden = Nothing
        If Ls_Billete Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            lResult = New ETOrden

            Try
                For Each xRow As ETOrden In Ls_Billete
                    Dim Comand1 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoOrden5_M)
                    With xRow
                        db.AddInParameter(Comand1, "Tipo", DbType.Int16, 2)
                        db.AddInParameter(Comand1, "ID", DbType.Int32, .ID)
                        db.AddInParameter(Comand1, "User", DbType.String, .Usuario)
                        'db.AddOutParameter(Comand1, "Respuesta", DbType.Int32, 10)
                    End With
                    db.ExecuteNonQuery(Comand1, Trans)
                    'lResult.ID = Convert.ToInt32(db.GetParameterValue(Comand1, "Respuesta"))
                    'If lResult.ID <> 0 Then Err.Raise(10)
                Next

                For Each yRow As ETOrden In Ls_Mineral
                    Dim Comand2 As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoOrden5_M)
                    With yRow
                        db.AddInParameter(Comand2, "Tipo", DbType.Int16, 1)
                        db.AddInParameter(Comand2, "ID", DbType.Int32, .ID)
                        db.AddInParameter(Comand2, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(Comand2, "Cod_Molino", DbType.String, .CodMolino)
                        db.AddInParameter(Comand2, "Cantidad", DbType.Decimal, .Cantidad)
                        db.AddInParameter(Comand2, "User", DbType.String, .Usuario)
                        'db.AddOutParameter(Comand2, "Respuesta", DbType.Int32, 10)
                    End With
                    db.ExecuteNonQuery(Comand2, Trans)
                    'lResult.Respuesta = Convert.ToInt32(db.GetParameterValue(Comand2, "Respuesta"))
                    'If lResult.Respuesta <> 0 Then Err.Raise(10)
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

        Ls_Billete = Nothing
        Ls_Mineral = Nothing

        Return lResult

    End Function

    Function Where_Personal_Turno(ByVal Rpt As ETPersonal) As Boolean
        Where_Personal_Turno = Boolean.FalseString
        If (Rpt.CodUnidadProd = _Cod_Chancadora And Rpt.Action = True And Rpt.Turno = _Cod_Turno) Then
            Where_Personal_Turno = Boolean.TrueString
        End If
    End Function


    'Public Function ConsultarOrdenxFecha(ByVal O As ETOrden, ByVal A As ETActivo) As List(Of ETOrden)
    '    Dim db As Database = DatabaseFactory.CreateDatabase()
    '    Dim cmd As DbCommand = db.GetStoredProcCommand(PPA.ConsultarOrden)
    '    Dim lst As New List(Of ETOrden)
    '    Dim E As ETOrden = Nothing

    '    Try

    '        db.AddInParameter(cmd, "Tipo", DbType.Int16, O.Tipo)
    '        db.AddInParameter(cmd, "Fecha", DbType.Date, O.Fecha)
    '        db.AddInParameter(cmd, "Turno", DbType.Int16, A.Turno)
    '        db.AddInParameter(cmd, "Placa", DbType.String, A.Placa)

    '        Using dr As IDataReader = db.ExecuteReader(cmd)

    '            While dr.Read

    '                E = New ETOrden
    '                E.NroDocumento = dr.GetString(dr.GetOrdinal("NroDocumento"))
    '                E.CodProducto = dr.GetString(dr.GetOrdinal("CodProducto"))
    '                E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
    '                lst.Add(E)

    '            End While

    '            If Not dr Is Nothing Then
    '                dr.Close()
    '            End If

    '        End Using

    '    Catch Err As Exception
    '        MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, msgComacsa)
    '        Return Nothing
    '    End Try

    '    Return lst

    'End Function

End Class
