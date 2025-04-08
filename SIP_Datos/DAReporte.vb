
Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAReporte


    Public Function ReportexCuadroxActivo(ByVal P As ETProducto) As List(Of ETActivo)

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ReportexCuadroxActivo)
        Dim lst As New List(Of ETActivo)
        Dim E As ETActivo = Nothing

        Try

            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, P.ID)
            db.AddInParameter(cmd, "CodProducto", DbType.String, P.CodProducto)
            db.AddInParameter(cmd, "Cantidad", DbType.Decimal, P.Cantidad)
            db.AddInParameter(cmd, "Fecha", DbType.Date, P.Fecha)
            db.AddInParameter(cmd, "Turno", DbType.Int16, P.Turno)


            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETActivo

                    E.ID = dr.GetInt32(dr.GetOrdinal("CodEnlace"))
                    E.CodClase = dr.GetString(dr.GetOrdinal("CodClase"))
                    E.CodTipo = dr.GetString(dr.GetOrdinal("CodTipo"))
                    E.DesTipo = dr.GetString(dr.GetOrdinal("DesTipo"))
                    E.Placa = dr.GetString(dr.GetOrdinal("Placa"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("DesMaquina"))
                    E.Rendimiento = dr.GetDecimal(dr.GetOrdinal("Rendimiento"))
                    E.Energia = dr.GetDecimal(dr.GetOrdinal("Energia"))
                    E.NroOperarios = dr.GetInt16(dr.GetOrdinal("NroOperarios"))
                    E.CostoPromxHora = dr.GetDecimal(dr.GetOrdinal("CostoPromxHora"))
                    E.CostoKwxHora = dr.GetDecimal(dr.GetOrdinal("CostoKwxHora"))

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
