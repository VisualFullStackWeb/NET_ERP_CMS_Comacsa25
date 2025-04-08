Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAUnidadMedida
    Public Function ConsultarUnidadMedida() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ConsultarUniMed)
        Dim lResult As ETMyLista = Nothing

        Try

            'db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "Tipo", DbType.String, "4")

            lResult = New ETMyLista
            Entidad.UnidadMedida = New ETUnidadMedida
            Entidad.UnidadMedida.Codigo = "00"
            Entidad.UnidadMedida.Descripcion = "<< NINGUNO >>"
            Entidad.UnidadMedida.Abrev = ""
            lResult.Ls_UnidadMedida.Add(Entidad.UnidadMedida)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.UnidadMedida = New ETUnidadMedida
                    Entidad.UnidadMedida.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.UnidadMedida.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.UnidadMedida.Abrev = dr.GetString(dr.GetOrdinal("Abrev"))
                    Entidad.UnidadMedida.Decimales = dr.GetString(dr.GetOrdinal("Decimales"))
                    lResult.Ls_UnidadMedida.Add(Entidad.UnidadMedida)
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
