Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAMineral

    Public Function ConsultarMineral1() As List(Of ETMineral)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarMinerales)
        Dim lst As New List(Of ETMineral)
        Dim E As ETMineral = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 1)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETMineral
                    E.CodMineral = dr.GetString(dr.GetOrdinal("CodMineral"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    E.Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                    E.DesCantera = dr.GetString(dr.GetOrdinal("DesCantera"))
                    E.Contratista = dr.GetString(dr.GetOrdinal("Contratista"))
                    E.Estado = dr.GetString(dr.GetOrdinal("Estado"))
                    E.Origen = dr.GetString(dr.GetOrdinal("Origen"))
                    lst.Add(E)

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst

    End Function
    

End Class
