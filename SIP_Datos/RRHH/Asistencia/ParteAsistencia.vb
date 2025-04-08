Imports System.Data.SqlClient
Imports SIP_Entidad

Public Class ParteAsistencia
    Private nombreProcedure As String = "usp_rrhh_asistencia_v2"
    Public Function listar(ByVal accion As String, ByVal opcion As String, _
                            ByVal fechaInicio As Date, ByVal fechaFin As Date, _
                            ByVal codigoArea As String, ByVal codigoEmpelado As String) As DataTable

        Dim value As New DataTable

        Using SqlConnection As SqlConnection = New SqlConnection(ConfigApp.Data.ConexionBD)

            Dim sqlReader As SqlDataReader
            Dim SqlCommand As SqlCommand = New SqlCommand(nombreProcedure, SqlConnection)
            SqlCommand.CommandType = CommandType.StoredProcedure
            SqlCommand.Parameters.Add(New SqlParameter("@accion", SqlDbType.VarChar, 3)).Value = accion
            SqlCommand.Parameters.Add(New SqlParameter("@opcion", SqlDbType.VarChar, 120)).Value = opcion
            SqlCommand.Parameters.Add(New SqlParameter("@fecha_ini", SqlDbType.DateTime)).Value = fechaInicio
            SqlCommand.Parameters.Add(New SqlParameter("@fecha_fin", SqlDbType.DateTime)).Value = fechaFin
            SqlCommand.Parameters.Add(New SqlParameter("@codigo_area", SqlDbType.VarChar, 3)).Value = codigoArea
            SqlCommand.Parameters.Add(New SqlParameter("@codigo_empleado", SqlDbType.VarChar, 10)).Value = codigoEmpelado

            SqlConnection.Open()
            sqlReader = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            value.Load(sqlReader)

        End Using

        Return value
    End Function
End Class
