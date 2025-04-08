Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports SIP_Entidad
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAOrdenTrabajo
    Public Function Mantenedor_Orden_Trabajo(ByVal Ent_OT As ETOrdenTrabajo_Mantto) As ETOrdenTrabajo_Mantto
        Dim lResult As ETOrdenTrabajo_Mantto = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim mensaje As String = String.Empty

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)
                db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, Ent_OT.OrdenTrabajo)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Area", DbType.String, Ent_OT.Area)
                db.AddInParameter(cmd, "CodOT", DbType.Int32, Val(Ent_OT.Codigo))
                db.AddInParameter(cmd, "CodOTOrigen", DbType.Int32, Ent_OT.OrdenTrabajoOrigen)
                db.AddInParameter(cmd, "PresupuestoID", DbType.Int32, Ent_OT.Presupuesto)
                db.AddInParameter(cmd, "Moneda", DbType.String, Ent_OT.Moneda)
                db.AddInParameter(cmd, "CostoPresup", DbType.Double, Ent_OT.CostoPresup)
                db.AddInParameter(cmd, "EncargadoArea", DbType.String, Ent_OT.Cod_EncargadoArea)
                db.AddInParameter(cmd, "Cliente", DbType.String, Ent_OT.Cod_Cli)
                db.AddInParameter(cmd, "ClienteInterno", DbType.String, Ent_OT.Cod_CliInterno)
                db.AddInParameter(cmd, "AreaInterna", DbType.String, Ent_OT.Cod_AreaInt)
                db.AddInParameter(cmd, "Equipo", DbType.Int32, Ent_OT.EquipoID)
                db.AddInParameter(cmd, "Descripcion", DbType.String, Ent_OT.Descripcion)
                db.AddInParameter(cmd, "ValorControl", DbType.String, Ent_OT.ValorControl)
                db.AddInParameter(cmd, "AtributoControl", DbType.Int32, Ent_OT.AtributoControl)
                db.AddInParameter(cmd, "TipoProceso", DbType.String, Ent_OT.TipoProceso)
                db.AddInParameter(cmd, "Prioridad", DbType.String, Ent_OT.Cod_Prioridad)
                db.AddInParameter(cmd, "FechaInicio", DbType.Date, Ent_OT.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.Date, Ent_OT.FechaTerminacion)
                db.AddInParameter(cmd, "Programacion", DbType.Int32, Ent_OT.Cod_Programacion)
                db.AddInParameter(cmd, "RequerimientoID", DbType.Int32, Ent_OT.Cod_Requerimiento)
                db.AddInParameter(cmd, "CostoMaterial", DbType.Double, Ent_OT.CostoMaterial)
                db.AddInParameter(cmd, "CostoEquipos", DbType.Double, Ent_OT.CostoEquipos)
                db.AddInParameter(cmd, "CostoManoObra", DbType.Double, Ent_OT.CostoManoObra)
                db.AddInParameter(cmd, "CostoServicios", DbType.Double, Ent_OT.CostoServicios)
                db.AddInParameter(cmd, "CostoBackLog", DbType.Double, Ent_OT.CostoBackLog)
                db.AddInParameter(cmd, "status", DbType.String, Ent_OT.Status)
                db.AddInParameter(cmd, "User", DbType.String, Ent_OT.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, Ent_OT.Tipo)

                lResult = New ETOrdenTrabajo_Mantto
                lResult.Abrev = Ent_OT.Abrev
                If Ent_OT.Tipo = 1 Then
                    lResult.Codigo = db.ExecuteScalar(cmd, Trans)
                Else
                    If Not (Ent_OT.Status.Trim) = "" Then
                        db.ExecuteNonQuery(cmd, Trans)
                    Else
                        Using dr As IDataReader = db.ExecuteReader(cmd, Trans)
                            While dr.Read
                                If dr.GetBoolean(dr.GetOrdinal("Mat")) = True Then
                                    mensaje = mensaje & Chr(13) & "Existen Costos de Materiales con Precio Cero"
                                End If
                                If dr.GetBoolean(dr.GetOrdinal("Eq")) = True Then
                                    mensaje = mensaje & Chr(13) & "Existen Costos de Equipos con Precio Cero"
                                End If
                                If dr.GetBoolean(dr.GetOrdinal("MO")) = True Then
                                    mensaje = mensaje & Chr(13) & "Existen Costos de Mano de Obra con Precio Cero"
                                End If
                                If dr.GetBoolean(dr.GetOrdinal("Ser")) = True Then
                                    mensaje = mensaje & Chr(13) & "Existen Costos de Servicios con Precio Cero"
                                End If
                                If dr.GetBoolean(dr.GetOrdinal("PendMat")) = True Then
                                    mensaje = mensaje & Chr(13) & "Existen Materiales Pendientes de Entrega"
                                End If
                                If dr.GetBoolean(dr.GetOrdinal("PendSer")) = True Then
                                    mensaje = mensaje & Chr(13) & "Existen Servicios Pendientes de Entrega"
                                End If
                            End While
                            If dr IsNot Nothing Then dr.Close()
                            If Not (String.IsNullOrEmpty(mensaje)) Then
                                GoTo AnularGrabacion
                            End If
                        End Using
                    End If

                    lResult.Codigo = Ent_OT.Codigo
                End If

                Trans.Commit()
                Conexion.Close()
                Return lResult
                GoTo Salir
AnularGrabacion:
                mensaje = "No se puede Cerrar la O/T por:" & mensaje
                Trans.Rollback()
                Conexion.Close()
                MsgBox(mensaje, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try

        End Using
Salir:

    End Function

    Public Function Consultar_OrdenTrabajo() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 4)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.OrdenTrabajo = New ETOrdenTrabajo_Mantto
                    With Entidad.OrdenTrabajo
                        .Abrev = dr.GetString(dr.GetOrdinal("Abrev"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Cod_Presp = dr.GetString(dr.GetOrdinal("Cod_Presp"))
                        .OTOrigen = dr.GetString(dr.GetOrdinal("OTOrigen"))
                        .EncargadoArea = dr.GetString(dr.GetOrdinal("EncargadoArea"))
                        .TipoCliente = dr.GetBoolean(dr.GetOrdinal("TipoCliente"))
                        .Cliente = dr.GetString(dr.GetOrdinal("Cliente"))
                        .RUC = dr.GetString(dr.GetOrdinal("RUC"))
                        .AreaInterna = dr.GetString(dr.GetOrdinal("AreaInterna"))
                        .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .TipoMantto = dr.GetString(dr.GetOrdinal("TipoMantto"))
                        .Atributo = dr.GetString(dr.GetOrdinal("Atributo"))
                        .ValorControl = dr.GetString(dr.GetOrdinal("ValorControl"))
                        .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                        .Prioridad = dr.GetString(dr.GetOrdinal("Prioridad"))
                        .Requerimiento = dr.GetString(dr.GetOrdinal("Requerimiento"))
                        .Programacion = dr.GetString(dr.GetOrdinal("Programacion"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .CostoPresup = dr.GetDecimal(dr.GetOrdinal("CostoPresup"))
                        .CostoMaterial = dr.GetDecimal(dr.GetOrdinal("CostoMaterial"))
                        .CostoEquipos = dr.GetDecimal(dr.GetOrdinal("CostoEquipos"))
                        .CostoManoObra = dr.GetDecimal(dr.GetOrdinal("CostoManoObra"))
                        .CostoServicios = dr.GetDecimal(dr.GetOrdinal("CostoServicios"))
                        .CostoBackLog = dr.GetDecimal(dr.GetOrdinal("CostoBackLog"))
                        .CostoTotal = dr.GetDecimal(dr.GetOrdinal("CostoTotal"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                        .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                        .Area = dr.GetString(dr.GetOrdinal("Area"))
                        .Cod_EncargadoArea = dr.GetString(dr.GetOrdinal("Cod_EncargadoArea"))
                        .Cod_Cli = dr.GetString(dr.GetOrdinal("Cod_Cli"))
                        .Cod_CliInterno = dr.GetString(dr.GetOrdinal("Cod_CliInterno"))
                        .Cod_AreaInt = dr.GetString(dr.GetOrdinal("Cod_AreaInt"))
                        .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        .TipoProceso = dr.GetString(dr.GetOrdinal("TipoProceso"))
                        .Cod_Prioridad = dr.GetString(dr.GetOrdinal("Cod_Prioridad"))
                        .Cod_Requerimiento = dr.GetInt32(dr.GetOrdinal("Cod_Requerimiento"))
                        .Cod_Programacion = dr.GetInt32(dr.GetOrdinal("Cod_Programacion"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        .AtributoControl = dr.GetInt32(dr.GetOrdinal("AtributoControl"))
                        .Cod_UniMed = dr.GetString(dr.GetOrdinal("Cod_UniMed"))
                        .TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                        .Longitud = dr.GetInt16(dr.GetOrdinal("Longitud"))
                        .Decimales = dr.GetInt16(dr.GetOrdinal("Decimales"))
                        .Presupuesto = dr.GetInt32(dr.GetOrdinal("Presupuesto"))
                        .OrdenTrabajoOrigen = dr.GetInt32(dr.GetOrdinal("OrdenTrabajoOrigen"))
                        .OrdenTrabajo = dr.GetInt32(dr.GetOrdinal("OrdenTrabajo"))
                    End With
                    lResult.Ls_Orden_Trabajo_Mantto.Add(Entidad.OrdenTrabajo)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using
        Catch Err As Exception
            lResult = Nothing
            MsgBox(Err.Message)

        End Try


        Return lResult
    End Function
    Public Function Consultar_BackLog() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodOTOrigen", DbType.Int32, 1)
            db.AddInParameter(cmd, "Tipo", DbType.String, 4)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.OrdenTrabajo = New ETOrdenTrabajo_Mantto
                    With Entidad.OrdenTrabajo
                        .Abrev = dr.GetString(dr.GetOrdinal("Abrev"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Cod_Presp = dr.GetString(dr.GetOrdinal("Cod_Presp"))
                        .OTOrigen = dr.GetString(dr.GetOrdinal("OTOrigen"))
                        .EncargadoArea = dr.GetString(dr.GetOrdinal("EncargadoArea"))
                        .TipoCliente = dr.GetBoolean(dr.GetOrdinal("TipoCliente"))
                        .Cliente = dr.GetString(dr.GetOrdinal("Cliente"))
                        .RUC = dr.GetString(dr.GetOrdinal("RUC"))
                        .AreaInterna = dr.GetString(dr.GetOrdinal("AreaInterna"))
                        .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .TipoMantto = dr.GetString(dr.GetOrdinal("TipoMantto"))
                        .Atributo = dr.GetString(dr.GetOrdinal("Atributo"))
                        .ValorControl = dr.GetString(dr.GetOrdinal("ValorControl"))
                        .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                        .Prioridad = dr.GetString(dr.GetOrdinal("Prioridad"))
                        .Requerimiento = dr.GetString(dr.GetOrdinal("Requerimiento"))
                        .Programacion = dr.GetString(dr.GetOrdinal("Programacion"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .CostoPresup = dr.GetDecimal(dr.GetOrdinal("CostoPresup"))
                        .CostoMaterial = dr.GetDecimal(dr.GetOrdinal("CostoMaterial"))
                        .CostoEquipos = dr.GetDecimal(dr.GetOrdinal("CostoEquipos"))
                        .CostoManoObra = dr.GetDecimal(dr.GetOrdinal("CostoManoObra"))
                        .CostoServicios = dr.GetDecimal(dr.GetOrdinal("CostoServicios"))
                        .CostoBackLog = dr.GetDecimal(dr.GetOrdinal("CostoBackLog"))
                        .CostoTotal = dr.GetDecimal(dr.GetOrdinal("CostoTotal"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                        .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                        .Area = dr.GetString(dr.GetOrdinal("Area"))
                        .Cod_EncargadoArea = dr.GetString(dr.GetOrdinal("Cod_EncargadoArea"))
                        .Cod_Cli = dr.GetString(dr.GetOrdinal("Cod_Cli"))
                        .Cod_CliInterno = dr.GetString(dr.GetOrdinal("Cod_CliInterno"))
                        .Cod_AreaInt = dr.GetString(dr.GetOrdinal("Cod_AreaInt"))
                        .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        .TipoProceso = dr.GetString(dr.GetOrdinal("TipoProceso"))
                        .Cod_Prioridad = dr.GetString(dr.GetOrdinal("Cod_Prioridad"))
                        .Cod_Requerimiento = dr.GetInt32(dr.GetOrdinal("Cod_Requerimiento"))
                        .Cod_Programacion = dr.GetInt32(dr.GetOrdinal("Cod_Programacion"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        .AtributoControl = dr.GetInt32(dr.GetOrdinal("AtributoControl"))
                        .Cod_UniMed = dr.GetString(dr.GetOrdinal("Cod_UniMed"))
                        .TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                        .Longitud = dr.GetInt16(dr.GetOrdinal("Longitud"))
                        .Decimales = dr.GetInt16(dr.GetOrdinal("Decimales"))
                        .Presupuesto = dr.GetInt32(dr.GetOrdinal("Presupuesto"))
                        .OrdenTrabajoOrigen = dr.GetInt32(dr.GetOrdinal("OrdenTrabajoOrigen"))
                        .OrdenTrabajo = dr.GetInt32(dr.GetOrdinal("OrdenTrabajo"))
                        .FechaInicioOTO = dr.GetDateTime(dr.GetOrdinal("FechaInicioOTO"))
                        .FechaTerminoOTO = dr.GetDateTime(dr.GetOrdinal("FechaTerminoOTO"))
                    End With
                    lResult.Ls_Orden_Trabajo_Mantto.Add(Entidad.OrdenTrabajo)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using
        Catch Err As Exception
            lResult = Nothing
            MsgBox(Err.Message)

        End Try


        Return lResult
    End Function

    Public Function Obtener_OrdenTrabajo_Estado(ByVal OT As ETOrdenTrabajo_Mantto) As String
        Dim lResult As String
        Dim db As Database = DatabaseFactory.CreateDatabase


        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)
        db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, OT.OrdenTrabajo)
        db.AddInParameter(cmd, "Tipo", DbType.Int16, 7)
        lResult = db.ExecuteScalar(cmd)
       
        Return lResult
    End Function

    Public Function Obtener_OrdenTrabajo_Costo_Total(ByVal OT As ETOrdenTrabajo_Mantto) As String
        Dim lResult As String
        Dim db As Database = DatabaseFactory.CreateDatabase


        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)
        db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, OT.OrdenTrabajo)
        db.AddInParameter(cmd, "Tipo", DbType.Int16, 9)
        lResult = db.ExecuteScalar(cmd)

        Return lResult
    End Function

    Public Function Consultar_OrdenTrabajoEnEjecucion(ByVal Ent_OT As ETOrdenTrabajo_Mantto) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Area", DbType.String, Ent_OT.Area)
            db.AddInParameter(cmd, "FechaInicio", DbType.Date, Ent_OT.FechaInicio.ToShortDateString)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 8)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.OrdenTrabajo = New ETOrdenTrabajo_Mantto
                    With Entidad.OrdenTrabajo
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Cod_Presp = dr.GetString(dr.GetOrdinal("Codigo2"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                        .Area = dr.GetString(dr.GetOrdinal("Area"))
                        .OrdenTrabajo = dr.GetInt32(dr.GetOrdinal("OrdenTrabajo"))
                    End With
                    lResult.Ls_Orden_Trabajo_Mantto.Add(Entidad.OrdenTrabajo)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using
        Catch Err As Exception
            lResult = Nothing
            MsgBox(Err.Message)
        End Try

        Return lResult
    End Function

    Public Function Validar_OrdenTrabajo_Fecha(ByVal Ent_OT As ETOrdenTrabajo_Mantto) As ETResultado
        Dim lResult As ETResultado = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, Ent_OT.OrdenTrabajo)
            db.AddInParameter(cmd, "FechaInicio", DbType.Date, Ent_OT.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.Date, Ent_OT.FechaTerminacion)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 10)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETResultado
                While dr.Read
                    lResult.Rec1 = dr.GetInt16(dr.GetOrdinal("Ini"))
                    lResult.Rec2 = dr.GetInt16(dr.GetOrdinal("Fin"))
                    If dr.GetInt16(dr.GetOrdinal("Ini")) > 0 Then
                        lResult.RIni = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                    End If
                    If dr.GetInt16(dr.GetOrdinal("Fin")) > 0 Then
                        lResult.RFin = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                    End If
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Realizo = True
            End Using
        Catch Err As Exception
            lResult = Nothing
            MsgBox(Err.Message)
        End Try

        Return lResult
    End Function

    Public Function Validar_CostoBackLogCerrado(ByVal OT As ETOrdenTrabajo_Mantto) As Integer
        Dim lResult As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase


        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)
        db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, OT.OrdenTrabajo)
        db.AddInParameter(cmd, "Tipo", DbType.Int16, 11)
        lResult = db.ExecuteScalar(cmd)

        Return lResult
    End Function

    Public Function Consultar_OrdenTrabajo_Recurso_Detalle(ByVal Ent_OT As ETOrdenTrabajo_Mantto) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo_Costos_Detalle)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "OrdenTrabajo", DbType.String, Ent_OT.OrdenTrabajo)
            db.AddInParameter(cmd, "Status", DbType.String, Ent_OT.Status)
            db.AddInParameter(cmd, "Tipo", DbType.String, Ent_OT.Tipo.ToString)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.OrdenTrabajo_Recurso_Detalle = New ETOTRecursoDetalle
                    With Entidad.OrdenTrabajo_Recurso_Detalle
                        .Billete = dr.GetString(dr.GetOrdinal("Billete"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                        .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                        .Precio = dr.GetDecimal(dr.GetOrdinal("Precio"))
                        .SubTotal = dr.GetDecimal(dr.GetOrdinal("SubTotal"))
                    End With
                    lResult.Ls_OrdenTrabajo_RecursosDetalle.Add(Entidad.OrdenTrabajo_Recurso_Detalle)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using
        Catch Err As Exception
            lResult = Nothing
            MsgBox(Err.Message)
        End Try

        Return lResult
    End Function

    Public Function Consultar_OrdenTrabajo_AnalisisCostos(ByVal Ent_OT As ETOrdenTrabajo_Mantto) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Reporte_Presupuesto_vs_OT)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "OrdenTrabajo", DbType.String, Ent_OT.OrdenTrabajo)
            db.AddInParameter(cmd, "Presupuesto", DbType.String, Ent_OT.Presupuesto)
            db.AddInParameter(cmd, "Status", DbType.String, Ent_OT.Status)
            db.AddInParameter(cmd, "Tipo", DbType.String, Ent_OT.Tipo.ToString)
            lResult = db.ExecuteDataSet(cmd)

        Catch Err As Exception
            lResult = Nothing
            MsgBox(Err.Message)
        End Try

        Return lResult
    End Function

    Public Function Consultar_OrdenTrabajo_Sin_Precio() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, 13)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.OrdenTrabajo = New ETOrdenTrabajo_Mantto
                    With Entidad.OrdenTrabajo
                        .Abrev = dr.GetString(dr.GetOrdinal("Abrev"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Cod_Presp = dr.GetString(dr.GetOrdinal("Cod_Presp"))
                        .OTOrigen = dr.GetString(dr.GetOrdinal("OTOrigen"))
                        .EncargadoArea = dr.GetString(dr.GetOrdinal("EncargadoArea"))
                        .TipoCliente = dr.GetBoolean(dr.GetOrdinal("TipoCliente"))
                        .Cliente = dr.GetString(dr.GetOrdinal("Cliente"))
                        .RUC = dr.GetString(dr.GetOrdinal("RUC"))
                        .AreaInterna = dr.GetString(dr.GetOrdinal("AreaInterna"))
                        .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .TipoMantto = dr.GetString(dr.GetOrdinal("TipoMantto"))
                        .Atributo = dr.GetString(dr.GetOrdinal("Atributo"))
                        .ValorControl = dr.GetString(dr.GetOrdinal("ValorControl"))
                        .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                        .Prioridad = dr.GetString(dr.GetOrdinal("Prioridad"))
                        .Requerimiento = dr.GetString(dr.GetOrdinal("Requerimiento"))
                        .Programacion = dr.GetString(dr.GetOrdinal("Programacion"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .CostoPresup = dr.GetDecimal(dr.GetOrdinal("CostoPresup"))
                        .CostoMaterial = dr.GetDecimal(dr.GetOrdinal("CostoMaterial"))
                        .CostoEquipos = dr.GetDecimal(dr.GetOrdinal("CostoEquipos"))
                        .CostoManoObra = dr.GetDecimal(dr.GetOrdinal("CostoManoObra"))
                        .CostoServicios = dr.GetDecimal(dr.GetOrdinal("CostoServicios"))
                        .CostoBackLog = dr.GetDecimal(dr.GetOrdinal("CostoBackLog"))
                        .CostoTotal = dr.GetDecimal(dr.GetOrdinal("CostoTotal"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                        .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                        .Area = dr.GetString(dr.GetOrdinal("Area"))
                        .Cod_EncargadoArea = dr.GetString(dr.GetOrdinal("Cod_EncargadoArea"))
                        .Cod_Cli = dr.GetString(dr.GetOrdinal("Cod_Cli"))
                        .Cod_CliInterno = dr.GetString(dr.GetOrdinal("Cod_CliInterno"))
                        .Cod_AreaInt = dr.GetString(dr.GetOrdinal("Cod_AreaInt"))
                        .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        .TipoProceso = dr.GetString(dr.GetOrdinal("TipoProceso"))
                        .Cod_Prioridad = dr.GetString(dr.GetOrdinal("Cod_Prioridad"))
                        .Cod_Requerimiento = dr.GetInt32(dr.GetOrdinal("Cod_Requerimiento"))
                        .Cod_Programacion = dr.GetInt32(dr.GetOrdinal("Cod_Programacion"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        .AtributoControl = dr.GetInt32(dr.GetOrdinal("AtributoControl"))
                        .Cod_UniMed = dr.GetString(dr.GetOrdinal("Cod_UniMed"))
                        .TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                        .Longitud = dr.GetInt16(dr.GetOrdinal("Longitud"))
                        .Decimales = dr.GetInt16(dr.GetOrdinal("Decimales"))
                        .Presupuesto = dr.GetInt32(dr.GetOrdinal("Presupuesto"))
                        .OrdenTrabajoOrigen = dr.GetInt32(dr.GetOrdinal("OrdenTrabajoOrigen"))
                        .OrdenTrabajo = dr.GetInt32(dr.GetOrdinal("OrdenTrabajo"))
                    End With
                    lResult.Ls_Orden_Trabajo_Mantto.Add(Entidad.OrdenTrabajo)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using
        Catch Err As Exception
            lResult = Nothing
            MsgBox(Err.Message)

        End Try


        Return lResult
    End Function

    Public Function Reporte_OrdenTrabajo() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "@CodOTOrigen", DbType.Int32, 0)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 12)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    If dr.GetString(dr.GetOrdinal("Status")).ToString.Trim <> "*" Then
                        Entidad.OrdenTrabajo = New ETOrdenTrabajo_Mantto
                        With Entidad.OrdenTrabajo
                            .Abrev = dr.GetString(dr.GetOrdinal("Abrev"))
                            .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                            .Cod_Presp = dr.GetString(dr.GetOrdinal("Cod_Presp"))
                            .OTOrigen = dr.GetString(dr.GetOrdinal("OTOrigen"))
                            '.EncargadoArea = dr.GetString(dr.GetOrdinal("EncargadoArea"))
                            .TipoCliente = dr.GetBoolean(dr.GetOrdinal("TipoCliente"))
                            .Cliente = dr.GetString(dr.GetOrdinal("Cliente"))
                            '.RUC = dr.GetString(dr.GetOrdinal("RUC"))
                            '.AreaInterna = dr.GetString(dr.GetOrdinal("AreaInterna"))
                            .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                            .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                            '.TipoMantto = dr.GetString(dr.GetOrdinal("TipoMantto"))
                            '.Atributo = dr.GetString(dr.GetOrdinal("Atributo"))
                            '.ValorControl = dr.GetString(dr.GetOrdinal("ValorControl"))
                            '.UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                            '.Prioridad = dr.GetString(dr.GetOrdinal("Prioridad"))
                            '.Requerimiento = dr.GetString(dr.GetOrdinal("Requerimiento"))
                            '.Programacion = dr.GetString(dr.GetOrdinal("Programacion"))
                            .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                            .CostoPresup = dr.GetDecimal(dr.GetOrdinal("CostoPresup"))
                            '.CostoMaterial = dr.GetDecimal(dr.GetOrdinal("CostoMaterial"))
                            '.CostoEquipos = dr.GetDecimal(dr.GetOrdinal("CostoEquipos"))
                            '.CostoManoObra = dr.GetDecimal(dr.GetOrdinal("CostoManoObra"))
                            '.CostoServicios = dr.GetDecimal(dr.GetOrdinal("CostoServicios"))
                            '.CostoBackLog = dr.GetDecimal(dr.GetOrdinal("CostoBackLog"))
                            .CostoTotal = dr.GetDecimal(dr.GetOrdinal("CostoTotal"))
                            .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                            '.FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                            .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                            .Area = dr.GetString(dr.GetOrdinal("Area"))
                            '.Cod_EncargadoArea = dr.GetString(dr.GetOrdinal("Cod_EncargadoArea"))
                            '.Cod_Cli = dr.GetString(dr.GetOrdinal("Cod_Cli"))
                            '.Cod_CliInterno = dr.GetString(dr.GetOrdinal("Cod_CliInterno"))
                            '.Cod_AreaInt = dr.GetString(dr.GetOrdinal("Cod_AreaInt"))
                            '.EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                            '.TipoProceso = dr.GetString(dr.GetOrdinal("TipoProceso"))
                            '.Cod_Prioridad = dr.GetString(dr.GetOrdinal("Cod_Prioridad"))
                            '.Cod_Requerimiento = dr.GetInt32(dr.GetOrdinal("Cod_Requerimiento"))
                            '.Cod_Programacion = dr.GetInt32(dr.GetOrdinal("Cod_Programacion"))
                            .Status = dr.GetString(dr.GetOrdinal("Status"))
                            '.AtributoControl = dr.GetInt32(dr.GetOrdinal("AtributoControl"))
                            '.Cod_UniMed = dr.GetString(dr.GetOrdinal("Cod_UniMed"))
                            '.TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                            '.Longitud = dr.GetInt16(dr.GetOrdinal("Longitud"))
                            '.Decimales = dr.GetInt16(dr.GetOrdinal("Decimales"))
                            .Presupuesto = dr.GetInt32(dr.GetOrdinal("Presupuesto"))
                            '.OrdenTrabajoOrigen = dr.GetInt32(dr.GetOrdinal("OrdenTrabajoOrigen"))
                            .OrdenTrabajo = dr.GetInt32(dr.GetOrdinal("OrdenTrabajo"))
                        End With
                        lResult.Ls_Orden_Trabajo_Mantto.Add(Entidad.OrdenTrabajo)
                    End If
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using
        Catch Err As Exception
            lResult = Nothing
            MsgBox(Err.Message)

        End Try


        Return lResult
    End Function
End Class
