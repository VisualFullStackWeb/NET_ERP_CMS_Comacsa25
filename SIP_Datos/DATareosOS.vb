Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports SIP_Entidad
Imports System.Data.Common
Imports System.Globalization
Imports System.Configuration

Public Class DATareosOS
    Public Function Mantenedor_TareosOT_Personal(ByVal Tareo As ETTareoOS) As ETTareoOS
        Dim lResult As ETTareoOS = Nothing

        If Tareo Is Nothing Then Return Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_TareosOS_Personal)
                db.AddInParameter(cmd, "TareoOS", DbType.Int32, Tareo.TareoOS)
                db.AddInParameter(cmd, "Codigo", DbType.Int32, Val(Tareo.Cod_TareosOS))
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, Tareo.OrdenTrabajo)
                db.AddInParameter(cmd, "Personal", DbType.String, Tareo.Codigo)
                db.AddInParameter(cmd, "AreaEmpleado", DbType.Int32, Tareo.Recurso)
                db.AddInParameter(cmd, "Horas", DbType.Double, Tareo.Horas)
                db.AddInParameter(cmd, "Fecha", DbType.Date, Tareo.Fecha)
                db.AddInParameter(cmd, "status", DbType.String, Tareo.Status)
                db.AddInParameter(cmd, "User", DbType.String, Tareo.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, Tareo.Tipo.ToString)
                lResult = New ETTareoOS
                If Tareo.Tipo = 1 Then
                    lResult.Codigo = db.ExecuteScalar(cmd, Trans)
                Else
                    db.ExecuteNonQuery(cmd, Trans)
                End If
                lResult.Validacion = True
                Trans.Commit()
                conexion.Close()
            Catch ex As Exception
                lResult = New ETTareoOS
                lResult.Validacion = False
                Trans.Rollback()
                conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            End Try
            Return lResult
        End Using
    End Function

    Public Function Consultar_Tareo_OT_Personal(ByVal Tareo As ETTareoOS) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_TareosOS_Personal)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, Tareo.OrdenTrabajo)
            db.AddInParameter(cmd, "Tipo", DbType.String, Tareo.Tipo.ToString)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.TareoOS = New ETTareoOS
                    With Entidad.TareoOS
                        .Cod_TareosOS = dr.GetString(dr.GetOrdinal("Cod_TareosOS"))
                        .Cod_OT = dr.GetString(dr.GetOrdinal("Cod_OT"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Horas = dr.GetDecimal(dr.GetOrdinal("Horas"))
                        .OrdenTrabajo = dr.GetInt32(dr.GetOrdinal("OrdenTrabajo"))
                        .Recurso = dr.GetInt32(dr.GetOrdinal("AreaEmpleado"))
                        .TareoOS = dr.GetInt32(dr.GetOrdinal("TareoOS"))
                        .Area = dr.GetString(dr.GetOrdinal("Area"))
                    End With
                    lResult.Ls_TareoOS.Add(Entidad.TareoOS)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        Return lResult
    End Function

    Public Function Obtener_Horas_Trabajas_Personal_Fecha(ByVal Tareo As ETTareoOS) As Double
        Dim lResult As Double = 0
        Dim db As Database = DatabaseFactory.CreateDatabase
        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_TareosOS_Personal)
            db.AddInParameter(cmd, "TareoOS", DbType.Int32, Tareo.TareoOS)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Personal", DbType.String, Tareo.Codigo)
            db.AddInParameter(cmd, "Tipo", DbType.String, "5")
            lResult = db.ExecuteScalar(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
        End Try
        Return lResult
    End Function

    Public Function Mantenedor_TareosOT_Equipo(ByVal Tareo As ETTareoOS) As ETTareoOS
        Dim lResult As ETTareoOS = Nothing

        If Tareo Is Nothing Then Return Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_TareosOS_Equipo)
                db.AddInParameter(cmd, "TareoOS", DbType.Int32, Tareo.TareoOS)
                db.AddInParameter(cmd, "Codigo", DbType.Int32, Val(Tareo.Cod_TareosOS))
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, Tareo.OrdenTrabajo)
                db.AddInParameter(cmd, "Equipo", DbType.Int32, Tareo.Recurso)
                db.AddInParameter(cmd, "Horas", DbType.Double, Tareo.Horas)
                db.AddInParameter(cmd, "Fecha", DbType.Date, Tareo.Fecha)
                db.AddInParameter(cmd, "status", DbType.String, Tareo.Status)
                db.AddInParameter(cmd, "User", DbType.String, Tareo.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, Tareo.Tipo.ToString)
                lResult = New ETTareoOS
                If Tareo.Tipo = 1 Then
                    lResult.Codigo = db.ExecuteScalar(cmd, Trans)
                Else
                    db.ExecuteNonQuery(cmd, Trans)
                End If
                lResult.Validacion = True
                Trans.Commit()
                conexion.Close()
            Catch ex As Exception
                lResult = New ETTareoOS
                lResult.Validacion = False
                Trans.Rollback()
                conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            End Try
            Return lResult
        End Using
    End Function

    Public Function Consultar_Tareo_OT_Equipo(ByVal Tareo As ETTareoOS) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_TareosOS_Equipo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, Tareo.OrdenTrabajo)
            db.AddInParameter(cmd, "Tipo", DbType.String, Tareo.Tipo.ToString)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.TareoOS = New ETTareoOS
                    With Entidad.TareoOS
                        .Cod_TareosOS = dr.GetString(dr.GetOrdinal("Cod_TareosOS"))
                        .Cod_OT = dr.GetString(dr.GetOrdinal("Cod_OT"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Horas = dr.GetDecimal(dr.GetOrdinal("Horas"))
                        .OrdenTrabajo = dr.GetInt32(dr.GetOrdinal("OrdenTrabajo"))
                        .Recurso = dr.GetInt32(dr.GetOrdinal("Equipo"))
                        .TareoOS = dr.GetInt32(dr.GetOrdinal("TareoOS"))
                        .Area = dr.GetString(dr.GetOrdinal("Area"))
                    End With
                    lResult.Ls_TareoOS.Add(Entidad.TareoOS)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        Return lResult
    End Function

    Public Function Obtener_Horas_Trabajas_Equipo_Fecha(ByVal Tareo As ETTareoOS) As Double
        Dim lResult As Double = 0
        Dim db As Database = DatabaseFactory.CreateDatabase
        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_TareosOS_Equipo)
            db.AddInParameter(cmd, "TareoOS", DbType.Int32, Tareo.TareoOS)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Equipo", DbType.Int32, Tareo.Recurso)
            db.AddInParameter(cmd, "Tipo", DbType.String, "5")
            lResult = db.ExecuteScalar(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
        End Try
        Return lResult
    End Function
End Class
