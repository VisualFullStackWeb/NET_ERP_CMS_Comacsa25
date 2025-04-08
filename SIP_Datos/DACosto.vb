Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DACosto
    Public Function Consulta(ByVal C As ETCosto) As List(Of ETCosto)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaCostosIndirectos)
        Dim lst As New List(Of ETCosto)
        Dim E As ETCosto = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, C.Tipo)
            db.AddInParameter(cmd, "ID", DbType.Int32, C.ID)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETCosto
                    E.ID = dr.GetInt32(dr.GetOrdinal("ID"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
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
