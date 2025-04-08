Imports SIP_Entidad
Imports SIP_Datos
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Globalization
Imports System.Configuration
Public Class DAPresupuestoPlanRecurso
    Public Function Consultar_PresupuestoPlanMaterial(ByVal Ent_Plan As ETPresupuestoPlanRecursos) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_Material)
        db.AddInParameter(cmd, "DetallePresupuestoID", DbType.Int32, Ent_Plan.PresupuestoDet)
        db.AddInParameter(cmd, "PresupuestoPlanID", DbType.Int32, Ent_Plan.PresupuestoPlan)
        db.AddInParameter(cmd, "FechaInicio", DbType.Date, Ent_Plan.FechaInicio)
        db.AddInParameter(cmd, "FechaTermino", DbType.Date, Ent_Plan.FechaTerminacion)
        db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Plan.Tipo.ToString)
        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
                With Entidad.Presupuesto_Plan_Recurso
                    .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    .Dias = dr.GetString(dr.GetOrdinal("Dia"))
                    .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                    If Ent_Plan.Tipo = 5 Then
                        .Periodo = dr.GetString(dr.GetOrdinal("Periodo"))
                    End If
                    .Tipo = dr.GetString(dr.GetOrdinal("Tipo"))
                    .PresupuestoDet = dr.GetInt32(dr.GetOrdinal("PresupuestoDet"))
                    .PresupuestoPlan = dr.GetInt32(dr.GetOrdinal("PlanID"))
                    .PlanRecurso = dr.GetInt32(dr.GetOrdinal("PlanMaterial"))
                    lResult.Ls_Presupuesto_Plan_Recurso.Add(Entidad.Presupuesto_Plan_Recurso)
                End With
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = True
        End Using

        Return lResult
    End Function
    Public Function Consultar_PresupuestoPlanEquipo(ByVal Ent_Plan As ETPresupuestoPlanRecursos) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_Equipo)
        db.AddInParameter(cmd, "DetallePresupuestoID", DbType.Int32, Ent_Plan.PresupuestoDet)
        db.AddInParameter(cmd, "PresupuestoPlanID", DbType.Int32, Ent_Plan.PresupuestoPlan)
        db.AddInParameter(cmd, "FechaInicio", DbType.Date, Ent_Plan.FechaInicio)
        db.AddInParameter(cmd, "FechaTermino", DbType.Date, Ent_Plan.FechaTerminacion)
        db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Plan.Tipo.ToString)
        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
                With Entidad.Presupuesto_Plan_Recurso
                    .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    .Dias = dr.GetString(dr.GetOrdinal("Dia"))
                    .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                    If Ent_Plan.Tipo = 5 Then
                        .Periodo = dr.GetString(dr.GetOrdinal("Periodo"))
                    End If
                    .Tipo = dr.GetString(dr.GetOrdinal("Tipo"))
                    .Recurso = dr.GetInt32(dr.GetOrdinal("Equipo"))
                    .PresupuestoDet = dr.GetInt32(dr.GetOrdinal("PresupuestoDet"))
                    .PresupuestoPlan = dr.GetInt32(dr.GetOrdinal("PlanID"))
                    .PlanRecurso = dr.GetInt32(dr.GetOrdinal("PlanEquipo"))
                    .Contar = dr.GetInt32(dr.GetOrdinal("Contar"))
                    lResult.Ls_Presupuesto_Plan_Recurso.Add(Entidad.Presupuesto_Plan_Recurso)
                End With
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = True
        End Using

        Return lResult
    End Function


    Public Function Consultar_PresupuestoPlanManoObra(ByVal Ent_Plan As ETPresupuestoPlanRecursos) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_ManoObra)
        db.AddInParameter(cmd, "DetallePresupuestoID", DbType.Int32, Ent_Plan.PresupuestoDet)
        db.AddInParameter(cmd, "PresupuestoPlanID", DbType.Int32, Ent_Plan.PresupuestoPlan)
        db.AddInParameter(cmd, "FechaInicio", DbType.Date, Ent_Plan.FechaInicio)
        db.AddInParameter(cmd, "FechaTermino", DbType.Date, Ent_Plan.FechaTerminacion)
        db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Plan.Tipo.ToString)
        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
                With Entidad.Presupuesto_Plan_Recurso
                    .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    .Dias = dr.GetString(dr.GetOrdinal("Dia"))
                    .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                    If Ent_Plan.Tipo = 5 Then
                        .Periodo = dr.GetString(dr.GetOrdinal("Periodo"))
                    End If
                    .Tipo = dr.GetString(dr.GetOrdinal("Tipo"))
                    .PresupuestoDet = dr.GetInt32(dr.GetOrdinal("PresupuestoDet"))
                    .PresupuestoPlan = dr.GetInt32(dr.GetOrdinal("PlanID"))
                    .PlanRecurso = dr.GetInt32(dr.GetOrdinal("PlanManoObra"))
                    .Contar = dr.GetInt32(dr.GetOrdinal("Contar"))
                    lResult.Ls_Presupuesto_Plan_Recurso.Add(Entidad.Presupuesto_Plan_Recurso)
                End With
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = True
        End Using

        Return lResult
    End Function

    Public Function Consultar_PresupuestoPlanServicio(ByVal Ent_Plan As ETPresupuestoPlanRecursos) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_Servicio)
        db.AddInParameter(cmd, "DetallePresupuestoID", DbType.Int32, Ent_Plan.PresupuestoDet)
        db.AddInParameter(cmd, "PresupuestoPlanID", DbType.Int32, Ent_Plan.PresupuestoPlan)
        db.AddInParameter(cmd, "FechaInicio", DbType.Date, Ent_Plan.FechaInicio)
        db.AddInParameter(cmd, "FechaTermino", DbType.Date, Ent_Plan.FechaTerminacion)
        db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Plan.Tipo.ToString)
        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
                With Entidad.Presupuesto_Plan_Recurso
                    .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    .Dias = dr.GetString(dr.GetOrdinal("Dia"))
                    .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                    If Ent_Plan.Tipo = 5 Then
                        .Periodo = dr.GetString(dr.GetOrdinal("Periodo"))
                    End If
                    .Tipo = dr.GetString(dr.GetOrdinal("Tipo"))
                    .PresupuestoDet = dr.GetInt32(dr.GetOrdinal("PresupuestoDet"))
                    .PresupuestoPlan = dr.GetInt32(dr.GetOrdinal("PlanID"))
                    .PlanRecurso = dr.GetInt32(dr.GetOrdinal("PlanServicio"))
                    lResult.Ls_Presupuesto_Plan_Recurso.Add(Entidad.Presupuesto_Plan_Recurso)
                End With
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = True
        End Using

        Return lResult
    End Function
End Class
