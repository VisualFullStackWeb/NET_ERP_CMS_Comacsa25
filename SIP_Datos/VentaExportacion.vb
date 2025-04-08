Imports SIP_Entidad
Imports System.Data.SqlClient
Public Class VentaExportacion

    Private nombreProcedure As String = "usp_ventas_listado_exportacion"

    Public Function listar(fechaInicio As Date, fechaFin As Date) As DataTable

        Dim value As New DataTable

        Using SqlConnection As SqlConnection = New SqlConnection(ConfigApp.Data.ConexionBD)

            Dim sqlReader As SqlDataReader
            Dim SqlCommand As SqlCommand = New SqlCommand(nombreProcedure, SqlConnection)
            SqlCommand.CommandType = CommandType.StoredProcedure
            SqlCommand.Parameters.Add(New SqlParameter("@fecha_ini", SqlDbType.DateTime)).Value = fechaInicio
            SqlCommand.Parameters.Add(New SqlParameter("@fecha_fin", SqlDbType.DateTime)).Value = fechaFin

            SqlConnection.Open()
            sqlReader = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            value.Load(sqlReader)

        End Using

        Return value
    End Function
End Class


