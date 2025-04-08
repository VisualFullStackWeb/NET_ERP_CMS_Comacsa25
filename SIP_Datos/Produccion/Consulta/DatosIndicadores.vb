Imports System.Data.SqlClient
Imports SIP_Entidad
Public Class DatosIndicadores
    Private nombreProcedure As String = "usp_produccion_data_indicador"
    Public Function listar(ByVal fechaInicio As Date, ByVal fechaFin As Date) As List(Of DataTable)

        Dim valueLista As New List(Of DataTable)
        Dim value As DataTable = Nothing

        Using SqlConnection As SqlConnection = New SqlConnection(ConfigApp.Data.ConexionBD)

            Dim SqlCommand As SqlCommand = New SqlCommand(nombreProcedure, SqlConnection)
            SqlCommand.CommandTimeout = 60 * 5 'segundos, 5 min
            SqlCommand.CommandType = CommandType.StoredProcedure
            SqlCommand.Parameters.Add(New SqlParameter("@fecha1", SqlDbType.Date)).Value = fechaInicio
            SqlCommand.Parameters.Add(New SqlParameter("@fecha2", SqlDbType.Date)).Value = fechaFin

            SqlConnection.Open()

            Dim ds As New DataSet
            Dim sqlDA As New SqlDataAdapter(SqlCommand)
            sqlDA.Fill(ds)

            If ds.Tables.Count > 0 Then
                'value = ds.Tables(0)
                valueLista.Add(ds.Tables(0))
                valueLista.Add(ds.Tables(1))

                'value = New DataTable
                'value = ds.Tables(1)
                'valueLista.Add(value)
            End If

        End Using

        Return valueLista
    End Function
End Class
