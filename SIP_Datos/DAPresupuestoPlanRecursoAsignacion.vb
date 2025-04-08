Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports SIP_Entidad
Imports System.Data.Common
Imports System.Globalization
Imports System.Configuration

Public Class DAPresupuestoPlanRecursoAsignacion
    Public Function Consultar_PlanEquipo_Asignacion(ByVal Ent_PlaEq_Asig As ETPresupuestoPlanRecursosAsignacion) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_Equipo_Asignacion)
        Try
            db.AddInParameter(cmd, "PresupPlanEquipo", DbType.Int32, Ent_PlaEq_Asig.PlanRecurso)
            db.AddInParameter(cmd, "Tipo", DbType.String, Ent_PlaEq_Asig.Tipo.ToString)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.Presupuesto_Plan_Recurso_Asignacion = New ETPresupuestoPlanRecursosAsignacion
                    With Entidad.Presupuesto_Plan_Recurso_Asignacion
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .HoraInicio = dr.GetString(dr.GetOrdinal("HoraInicio"))
                        .HoraFin = dr.GetString(dr.GetOrdinal("HoraFin"))
                        .Horas = dr.GetDecimal(dr.GetOrdinal("Horas"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Tipo = 2
                        .Recurso = dr.GetInt32(dr.GetOrdinal("Recurso"))
                        .PresupuestoDet = dr.GetInt32(dr.GetOrdinal("PresupuestoDet"))
                        .PresupuestoPlan = dr.GetInt32(dr.GetOrdinal("PresupuestoPlan"))
                        .PlanRecurso = dr.GetInt32(dr.GetOrdinal("PlanRecurso"))
                        .PlanRecursoAsignacion = dr.GetInt32(dr.GetOrdinal("PlanRecursoAsignacion"))
                    End With
                    lResult.Ls_Presupuesto_Plan_Recurso_Asignacion.Add(Entidad.Presupuesto_Plan_Recurso_Asignacion)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using

        Catch Err As Exception
            MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return lResult
    End Function


    Public Function Validar_PlanEquipo_Asignacion(ByVal Ent_PlaEq_Asig As ETPresupuestoPlanRecursosAsignacion) As Integer
        Dim lResult As Integer = 0
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_Equipo_Asignacion)
        Try
            db.AddInParameter(cmd, "PresupPlanEquipo", DbType.Int32, Ent_PlaEq_Asig.PlanRecurso)
            db.AddInParameter(cmd, "Equipo", DbType.Int32, Ent_PlaEq_Asig.Recurso)
            db.AddInParameter(cmd, "HoraInicio", DbType.String, Ent_PlaEq_Asig.HoraInicio)
            db.AddInParameter(cmd, "HoraTermino", DbType.String, Ent_PlaEq_Asig.HoraFin)
            db.AddInParameter(cmd, "Tipo", DbType.String, Ent_PlaEq_Asig.Tipo.ToString)

            lResult = db.ExecuteScalar(cmd)
        Catch Err As Exception
            MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return lResult
    End Function


    Public Function Consultar_PlanManoObra_Asignacion(ByVal Ent_PlaEq_Asig As ETPresupuestoPlanRecursosAsignacion) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_ManoObra_Asignacion)
        Try
            db.AddInParameter(cmd, "PresupPlanManoObra", DbType.Int32, Ent_PlaEq_Asig.PlanRecurso)
            db.AddInParameter(cmd, "Empleado", DbType.String, Ent_PlaEq_Asig.Codigo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, Ent_PlaEq_Asig.Tipo.ToString)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.Presupuesto_Plan_Recurso_Asignacion = New ETPresupuestoPlanRecursosAsignacion
                    With Entidad.Presupuesto_Plan_Recurso_Asignacion
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .HoraInicio = dr.GetString(dr.GetOrdinal("HoraInicio"))
                        .HoraFin = dr.GetString(dr.GetOrdinal("HoraFin"))
                        .Horas = dr.GetDecimal(dr.GetOrdinal("Horas"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Tipo = 2
                        .PresupuestoDet = dr.GetInt32(dr.GetOrdinal("PresupuestoDet"))
                        .PresupuestoPlan = dr.GetInt32(dr.GetOrdinal("PresupuestoPlan"))
                        .PlanRecurso = dr.GetInt32(dr.GetOrdinal("PlanRecurso"))
                        .PlanRecursoAsignacion = dr.GetInt32(dr.GetOrdinal("PlanRecursoAsignacion"))
                    End With
                    lResult.Ls_Presupuesto_Plan_Recurso_Asignacion.Add(Entidad.Presupuesto_Plan_Recurso_Asignacion)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using

        Catch Err As Exception
            MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return lResult
    End Function

    Public Function Validar_PlanManoObra_Asignacion(ByVal Ent_PlaMO_Asig As ETPresupuestoPlanRecursosAsignacion) As Integer
        Dim lResult As Integer = 0
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_ManoObra_Asignacion)
        Try
            db.AddInParameter(cmd, "PresupPlanManoObra", DbType.Int32, Ent_PlaMO_Asig.PlanRecurso)
            db.AddInParameter(cmd, "HoraInicio", DbType.String, Ent_PlaMO_Asig.HoraInicio)
            db.AddInParameter(cmd, "HoraTermino", DbType.String, Ent_PlaMO_Asig.HoraFin)
            db.AddInParameter(cmd, "Tipo", DbType.String, Ent_PlaMO_Asig.Tipo.ToString)

            lResult = db.ExecuteScalar(cmd)
        Catch Err As Exception
            MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return lResult
    End Function
End Class
