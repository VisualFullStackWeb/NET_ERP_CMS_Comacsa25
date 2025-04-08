Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports SIP_Entidad
Imports System.Globalization
Imports System.Configuration

Public Class DAReq_Mantto
    Public Function Mantenedor_Requerimiento(ByVal EntReq As ETRequerimiento_Mantto, ByVal Ls_DetReq As List(Of ETRequerimiento_ManttoDetalle), ByVal Ls_DetReq_Anulado As List(Of ETRequerimiento_ManttoDetalle)) As String
        Dim Codigo As String = String.Empty
        Dim Req As Long

        If EntReq Is Nothing Then
            Return Codigo
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase

        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Requerimiento_Mantto)
                db.AddInParameter(cmd, "RequerimientoID", DbType.Int32, EntReq.Requerimiento)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodReq", DbType.Int32, Val(EntReq.Codigo))
                db.AddInParameter(cmd, "Area", DbType.String, EntReq.CodArea)
                db.AddInParameter(cmd, "Solicitante", DbType.String, EntReq.SolicitanteID)
                db.AddInParameter(cmd, "Dirigido", DbType.String, EntReq.DirigidoID)
                db.AddInParameter(cmd, "Fecha", DbType.Date, EntReq.Fecha)
                db.AddInParameter(cmd, "Asunto", DbType.String, EntReq.Asunto)
                db.AddInParameter(cmd, "status", DbType.String, EntReq.Status)
                db.AddInParameter(cmd, "User", DbType.String, EntReq.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, EntReq.Tipo.ToString)

                If EntReq.Tipo = 1 Then
                    Using dr As IDataReader = db.ExecuteReader(cmd, Trans)
                        While dr.Read
                            Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                            Req = dr.GetInt32(dr.GetOrdinal("ID"))
                        End While
                        If dr IsNot Nothing Then dr.Close()
                    End Using
                Else
                    Codigo = EntReq.Codigo
                    Req = EntReq.Requerimiento

                    For Each Row As ETRequerimiento_ManttoDetalle In Ls_DetReq_Anulado
                        Dim xmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ReqDetalle_Mantto)
                        db.AddInParameter(xmd, "RequerimientoID", DbType.Int32, Req)
                        db.AddInParameter(xmd, "EquipoID", DbType.Int32, Row.EquipoID)
                        db.AddInParameter(xmd, "CheckListID", DbType.Int32, Row.CheckListID)
                        db.AddInParameter(xmd, "Observaciones", DbType.String, Row.Observaciones)
                        db.AddInParameter(xmd, "status", DbType.String, Row.Status)
                        db.AddInParameter(xmd, "User", DbType.String, Row.Usuario)
                        db.AddInParameter(xmd, "Tipo", DbType.String, Row.Tipo.ToString)

                        db.ExecuteNonQuery(xmd, Trans)
                    Next
                End If

                For Each Row As ETRequerimiento_ManttoDetalle In Ls_DetReq
                    Dim xmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ReqDetalle_Mantto)
                    db.AddInParameter(xmd, "RequerimientoID", DbType.Int32, Req)
                    db.AddInParameter(xmd, "EquipoID", DbType.Int32, Row.EquipoID)
                    db.AddInParameter(xmd, "CheckListID", DbType.Int32, Row.CheckListID)
                    db.AddInParameter(xmd, "Observaciones", DbType.String, Row.Observaciones)
                    db.AddInParameter(xmd, "status", DbType.String, Row.Status)
                    db.AddInParameter(xmd, "User", DbType.String, Row.Usuario)
                    db.AddInParameter(xmd, "Tipo", DbType.String, Row.Tipo.ToString)
                    db.ExecuteNonQuery(xmd, Trans)
                Next
                Trans.Commit()
                conexion.Close()
            Catch Err As Exception
                Codigo = ""
                Trans.Rollback()
                conexion.Close()

                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return Codigo
    End Function

    Public Function Consultar_Requerimiento() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Requerimiento_Mantto)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Requerimiento_Mantto = New ETRequerimiento_Mantto
                    With Entidad.Requerimiento_Mantto
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Area = dr.GetString(dr.GetOrdinal("Area"))
                        .CodArea = dr.GetString(dr.GetOrdinal("AreaID"))
                        .Solicitante = dr.GetString(dr.GetOrdinal("Solicitante"))
                        .Dirigido = dr.GetString(dr.GetOrdinal("Dirigido"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Asunto = dr.GetString(dr.GetOrdinal("Asunto"))
                        .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                        .SolicitanteID = dr.GetString(dr.GetOrdinal("SolicitanteID"))
                        .DirigidoID = dr.GetString(dr.GetOrdinal("DirigidoID"))
                        .Requerimiento = dr.GetInt32(dr.GetOrdinal("RequerimientoID"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        lResult.Ls_Requerimiento_Mantto.Add(Entidad.Requerimiento_Mantto)
                    End With
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
    Public Function Consultar_Requerimiento_Det(ByVal Ent_Req As ETRequerimiento_Mantto) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ReqDetalle_Mantto)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "RequerimientoID", DbType.Int32, Ent_Req.Requerimiento)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Requerimiento_Det_Mantto = New ETRequerimiento_ManttoDetalle
                    With Entidad.Requerimiento_Det_Mantto
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .CheckList = dr.GetString(dr.GetOrdinal("CheckList"))
                        .Observaciones = dr.GetString(dr.GetOrdinal("Observaciones"))
                        .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                        .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        .CheckListID = dr.GetInt32(dr.GetOrdinal("CheckListID"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        .Tipo = 2
                        lResult.Ls_Requerimiento_Det_Mantto.Add(Entidad.Requerimiento_Det_Mantto)
                    End With
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

    Public Function Consultar_Requerimiento_Activo_Programar() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Requerimiento_Mantto)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, "5")
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Requerimiento_Mantto = New ETRequerimiento_Mantto
                    With Entidad.Requerimiento_Mantto
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Area = dr.GetString(dr.GetOrdinal("Area"))
                        .Solicitante = dr.GetString(dr.GetOrdinal("Solicitante"))
                        .Dirigido = dr.GetString(dr.GetOrdinal("Dirigido"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Asunto = dr.GetString(dr.GetOrdinal("Asunto"))
                        .Requerimiento = dr.GetInt32(dr.GetOrdinal("RequerimientoID"))
                        lResult.Ls_Requerimiento_Mantto.Add(Entidad.Requerimiento_Mantto)
                    End With
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
    Public Function Consultar_Req_Equipo_Activo_Programar(ByVal Ent_Req As ETRequerimiento_ManttoDetalle) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ReqDetalle_Mantto)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "RequerimientoID", DbType.Int32, Ent_Req.Requerimiento)
            db.AddInParameter(cmd, "EquipoID", DbType.Int32, Ent_Req.EquipoID)
            db.AddInParameter(cmd, "Status", DbType.String, Ent_Req.Status)
            db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Req.Tipo.ToString)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Requerimiento_Det_Mantto = New ETRequerimiento_ManttoDetalle
                    With Entidad.Requerimiento_Det_Mantto

                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .CheckList = dr.GetString(dr.GetOrdinal("CheckList"))
                        .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        lResult.Ls_Requerimiento_Det_Mantto.Add(Entidad.Requerimiento_Det_Mantto)
                    End With
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

    Public Function Consultar_Requerimiento_OT(ByVal Ent_Req As ETRequerimiento_ManttoDetalle) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ReqDetalle_Mantto)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "RequerimientoID", DbType.Int32, Ent_Req.Requerimiento)
            db.AddInParameter(cmd, "EquipoID", DbType.Int32, Ent_Req.EquipoID)
            db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Req.Tipo.ToString)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Requerimiento_Det_Mantto = New ETRequerimiento_ManttoDetalle
                    With Entidad.Requerimiento_Det_Mantto
                        .Requerimiento = dr.GetInt32(dr.GetOrdinal("ID"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Requerimiento"))
                        .CheckList = dr.GetString(dr.GetOrdinal("CheckList"))
                        .Programacion = dr.GetString(dr.GetOrdinal("Programacion"))
                        .ProgramacionID = dr.GetInt32(dr.GetOrdinal("ProgramacionID"))
                        lResult.Ls_Requerimiento_Det_Mantto.Add(Entidad.Requerimiento_Det_Mantto)
                    End With
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
