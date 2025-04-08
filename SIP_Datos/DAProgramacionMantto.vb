Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports SIP_Entidad
Imports System.Data.Common
Imports System.Globalization
Imports System.Configuration

Public Class DAProgramacionMantto
    Public Function Mantenedor_Programacion(ByVal Ent_Prog As ETProgramacionMantto) As Integer
        Dim lResult As New ETProgramacionMantto
        If Ent_Prog Is Nothing Then
            Return 0
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Programacion)
                db.AddInParameter(cmd, "Programacion", DbType.Int32, Ent_Prog.Programacion)
                db.AddInParameter(cmd, "CodProgramacion", DbType.Int32, Val(Ent_Prog.Codigo))
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Fecha", DbType.Date, Ent_Prog.Fecha)
                db.AddInParameter(cmd, "RequerimientoID", DbType.Int32, Ent_Prog.RequerimientoID)
                db.AddInParameter(cmd, "EquipoID", DbType.Int32, Ent_Prog.EquipoID)
                db.AddInParameter(cmd, "FechaInicio", DbType.Date, Ent_Prog.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.Date, Ent_Prog.FechaTerminacion)
                db.AddInParameter(cmd, "Observaciones", DbType.String, Ent_Prog.Observaciones)
                db.AddInParameter(cmd, "status", DbType.String, Ent_Prog.Status)
                db.AddInParameter(cmd, "User", DbType.String, Ent_Prog.Usuario)
                db.AddInParameter(cmd, "Req_Ant", DbType.Int32, Ent_Prog.Req_Anterior)
                db.AddInParameter(cmd, "Eq_Ant", DbType.Int32, Ent_Prog.Equipo_Anterior)
                db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Prog.Tipo.ToString)
                lResult = New ETProgramacionMantto
                If Ent_Prog.Tipo = 1 Then
                    Using dr As IDataReader = db.ExecuteReader(cmd, Trans)
                        While dr.Read
                            lResult.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                            lResult.Respuesta = 1
                        End While
                        If dr IsNot Nothing Then dr.Close()
                    End Using
                    MsgBox("Se generó el Código N° " & lResult.Codigo, MsgBoxStyle.Information, MsgComacsa)
                Else
                    lResult.Respuesta = db.ExecuteNonQuery(cmd, Trans)
                End If
                Trans.Commit()
                conexion.Close()
            Catch Err As Exception
                lResult.Respuesta = 0
                Trans.Rollback()
                conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try
        End Using
        Return lResult.Respuesta
    End Function
    Public Function Consultar_Programacion() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Programacion)
        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "Tipo", DbType.String, "4")
        lResult = New ETMyLista
        Using dr As IDataReader = db.ExecuteReader(cmd)
            While dr.Read
                Entidad.Programacion_Mantto = New ETProgramacionMantto
                With Entidad.Programacion_Mantto
                    .Codigo = dr.GetString(dr.GetOrdinal("CodProgramacion"))
                    .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    .Cod_Req = dr.GetString(dr.GetOrdinal("Requerimiento"))
                    .Cod_Eq = dr.GetString(dr.GetOrdinal("CodEquipo"))
                    .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                    .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                    .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                    .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                    .RequerimientoID = dr.GetInt32(dr.GetOrdinal("RequerimientoID"))
                    .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                    .Status = dr.GetString(dr.GetOrdinal("Status"))
                    .Programacion = dr.GetInt32(dr.GetOrdinal("Programacion"))
                    lResult.Ls_Programacion_Mantto.Add(Entidad.Programacion_Mantto)
                End With
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = Boolean.TrueString
        End Using



        Return lResult
    End Function
    Public Function Consultar_Programacion_Pendiente_Ejecucion() As Boolean
        Dim lResult As Boolean = False
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Programacion)
        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "Tipo", DbType.String, "5")
        lResult = db.ExecuteScalar(cmd)
        Return lResult
    End Function
End Class
