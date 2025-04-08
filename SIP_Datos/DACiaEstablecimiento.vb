Imports System.Data.SqlClient
Imports SIP_Entidad

Public Class DACiaEstablecimiento
    Public Function ListarCiaEstablecimiento() As List(Of ETCiaEstablecimiento)
        'Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cm As DbCommand = db.GetStoredProcCommand("PAEXP_Ubigeos")
        Dim oCiaEstablecimiento As ETCiaEstablecimiento = Nothing
        Dim lstCiaEstb As New List(Of ETCiaEstablecimiento)
        Try

            Using sqlCon As SqlConnection = New SqlConnection(ConfigApp.Data.ConexionBD) 'ConfigApp.Data.ConexionBD
                Using sqlCmd As SqlCommand = New SqlCommand("usp_listar_cia_establecimientos", sqlCon)
                    With sqlCmd
                        .CommandType = CommandType.StoredProcedure
                        sqlCon.Open()


                        Using dr As IDataReader = .ExecuteReader(CommandBehavior.CloseConnection)
                            While dr.Read
                                oCiaEstablecimiento = New ETCiaEstablecimiento
                                oCiaEstablecimiento.IdCodEstab = dr.GetString(dr.GetOrdinal("IdCodEstab"))
                                oCiaEstablecimiento.Denominacion = dr.GetString(dr.GetOrdinal("denominacion"))
                                oCiaEstablecimiento.Domicilio = dr.GetString(dr.GetOrdinal("domicilio"))
                                oCiaEstablecimiento.Nombre_Ubigeo = dr.GetString(dr.GetOrdinal("nombre_ubigeo"))
                                oCiaEstablecimiento.Codigo_Ubigeo = dr.GetString(dr.GetOrdinal("Codigo_Ubigeo"))
                                lstCiaEstb.Add(oCiaEstablecimiento)
                            End While
                            If Not dr Is Nothing Then
                                dr.Close()
                            End If
                            Return lstCiaEstb
                        End Using
                    End With
                End Using
            End Using


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
