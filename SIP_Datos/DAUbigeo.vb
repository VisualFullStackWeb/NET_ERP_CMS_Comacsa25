Imports System.Data.SqlClient
Imports SIP_Entidad

Public Class DAUbigeo
    Public Function ListarUbigeos() As List(Of ETUbigeos)
        'Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cm As DbCommand = db.GetStoredProcCommand("PAEXP_Ubigeos")
        Dim oUbigeo As ETUbigeos = Nothing
        Dim lstUbigeo As New List(Of ETUbigeos)
        Try

            Using sqlCon As SqlConnection = New SqlConnection(ConfigApp.Data.ConexionBD) 'ConfigApp.Data.ConexionBD
                Using sqlCmd As SqlCommand = New SqlCommand("PAEXP_Ubigeos_Pais_Sunat", sqlCon)
                    With sqlCmd
                        .CommandType = CommandType.StoredProcedure
                        sqlCon.Open()

                        Using dr As IDataReader = .ExecuteReader(CommandBehavior.CloseConnection)
                            While dr.Read
                                oUbigeo = New ETUbigeos
                                oUbigeo.Ubigeo = dr.GetString(dr.GetOrdinal("CodUbi"))
                                oUbigeo.Pais = dr.GetString(dr.GetOrdinal("Pais"))
                                oUbigeo.Departamento = dr.GetString(dr.GetOrdinal("Departamento"))
                                oUbigeo.Provincia = dr.GetString(dr.GetOrdinal("Provincia"))
                                oUbigeo.Distrito = dr.GetString(dr.GetOrdinal("Distrito"))
                                oUbigeo.IdUbigeoSunat = dr.GetString(dr.GetOrdinal("IdUbigeoSunat"))
                                lstUbigeo.Add(oUbigeo)
                            End While
                            If Not dr Is Nothing Then
                                dr.Close()
                            End If
                            Return lstUbigeo
                        End Using
                    End With
                End Using
            End Using


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
