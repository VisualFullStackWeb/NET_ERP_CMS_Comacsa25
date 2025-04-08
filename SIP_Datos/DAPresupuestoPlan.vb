Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Globalization
Imports System.Configuration

Public Class DAPresupuestoPlan
    Public Function Consultar_PresupuestoPlan(ByVal Ent_Plan As ETPresupuestoPlan) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan)
        db.AddInParameter(cmd, "DetallePresupuestoID", DbType.Int32, Ent_Plan.PresupuestoDet)
        db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Plan.Tipo.ToString)
        lResult = New ETMyLista
        Using dr As IDataReader = db.ExecuteReader(cmd)
            While dr.Read
                Entidad.Presupuesto_Plan = New ETPresupuestoPlan
                With Entidad.Presupuesto_Plan
                    .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    .Item = dr.GetInt16(dr.GetOrdinal("Item"))
                    .Periodo = dr.GetString(dr.GetOrdinal("Periodo"))
                    .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                    .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                    .Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje"))
                    .PresupuestoDet = dr.GetInt32(dr.GetOrdinal("PresupuestoDet"))
                    .PlanID = dr.GetInt32(dr.GetOrdinal("PlanID"))
                    .Tipo = 2
                End With
                lResult.Ls_Presupuesto_Plan.Add(Entidad.Presupuesto_Plan)
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = True
        End Using

        Return lResult
    End Function

End Class
