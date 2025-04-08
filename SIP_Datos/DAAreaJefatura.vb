Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports SIP_Entidad
Imports System.Configuration
Imports System.Globalization

Public Class DAAreaJefatura
    Public Function Consultar_AreaJetatura_Activa(ByVal Ent_AJ As ETAreaJefatura) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(RPA_RecursosHumanos.Planillas_AreaJefatura)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Area", DbType.String, Ent_AJ.Cod_Area)
            db.AddInParameter(cmd, "FechaInicio", DbType.Date, Ent_AJ.FechaInicio)
            db.AddInParameter(cmd, "Tipo", DbType.String, Ent_AJ.Tipo.ToString)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.AreaJefatura = New ETAreaJefatura
                    With Entidad.AreaJefatura
                        .AreaJefatura = dr.GetInt32(dr.GetOrdinal("AreaJefatura"))
                        .Area = dr.GetString(dr.GetOrdinal("Area"))
                        .JefeArea = dr.GetString(dr.GetOrdinal("JefeArea"))
                        .Cod_Area = dr.GetString(dr.GetOrdinal("Cod_Area"))
                        .Cod_JefeArea = dr.GetString(dr.GetOrdinal("Cod_JefeArea"))
                        .FechaInicioTxt = dr.GetString(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminoTxt = dr.GetString(dr.GetOrdinal("FechaTermino"))
                    End With
                    lResult.Ls_AreaJefatura.Add(Entidad.AreaJefatura)
                End While

                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
                Return lResult
            End Using

        Catch Err As Exception
            MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

End Class
