Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAProveedor
    Public Function ConsultarProveedor(ByVal rpt As ETProveedor) As String

        Dim lResult As String = ""
        Dim db As Database = DatabaseFactory.CreateDatabase
        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarProveedor)
            db.AddInParameter(cmd, "@pa_cod_cia", DbType.String, rpt.CodCiaProveedor)
            db.AddInParameter(cmd, "@pa_nroruc", DbType.String, rpt.RucProveedor)

            If IsNothing(db.ExecuteScalar(cmd)) Then
                lResult = ""
            Else
                lResult = db.ExecuteScalar(cmd)
            End If

            Return lResult
        Catch Err As Exception
            Return ""        
        End Try
        Return lResult
    End Function

End Class
