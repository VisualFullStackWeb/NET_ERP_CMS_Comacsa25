Imports System.Data.SqlClient
Imports SIP_Entidad
Public Class CentroCostoCargaLaboral
    Private nombreProcedure As String = "usp_rrhh_centrocosto_carga_laboral_cab"
    Public Function listar(ByVal accion As String, ByVal opcion As String, _
                            ByVal anio As Short, ByVal mes As Short) As DataTable

        Dim value As New DataTable

        Using SqlConnection As SqlConnection = New SqlConnection(ConfigApp.Data.ConexionBD)

            Dim sqlReader As SqlDataReader
            Dim SqlCommand As SqlCommand = New SqlCommand(nombreProcedure, SqlConnection)
            SqlCommand.CommandType = CommandType.StoredProcedure
            SqlCommand.Parameters.Add(New SqlParameter("@accion", SqlDbType.VarChar, 3)).Value = accion
            SqlCommand.Parameters.Add(New SqlParameter("@opcion", SqlDbType.VarChar, 120)).Value = opcion
            SqlCommand.Parameters.Add(New SqlParameter("@anio", SqlDbType.Int)).Value = anio
            SqlCommand.Parameters.Add(New SqlParameter("@mes", SqlDbType.Int)).Value = mes            
            SqlConnection.Open()
            sqlReader = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection)
            value.Load(sqlReader)

        End Using

        Return value
    End Function
    Public Function listarOutput(ByVal accion As String, ByVal opcion As String, ByVal anio As Short, ByVal mes As Short) As Integer
        Try
            Dim intValue As Integer = -1
            Using sqlCon As SqlConnection = New SqlConnection(ConfigApp.Data.ConexionBD)
                Using sqlCmd As SqlCommand = New SqlCommand(nombreProcedure, sqlCon)
                    With sqlCmd
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@accion", SqlDbType.VarChar, 3)).Value = accion
                        .Parameters.Add(New SqlParameter("@opcion", SqlDbType.VarChar, 120)).Value = opcion
                        .Parameters.Add(New SqlParameter("@anio", SqlDbType.Int)).Value = anio
                        .Parameters.Add(New SqlParameter("@mes", SqlDbType.Int)).Value = mes
                        .Parameters.Add(New SqlParameter("@value_out", SqlDbType.Int))
                        .Parameters("@value_out").Direction = ParameterDirection.Output
                        sqlCon.Open()
                        .ExecuteNonQuery()
                        intValue = .Parameters("@value_out").Value
                        Return intValue
                    End With
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return -1
        End Try
    End Function
    Public Function agregarCabecera(ByVal accion As String, ByVal opcion As String, _
        ByVal entity As Cabecera) As Integer

        Dim value As Integer

        Using SqlConnection As SqlConnection = New SqlConnection(ConfigApp.Data.ConexionBD)

            Dim SqlCommand As SqlCommand = New SqlCommand("usp_rrhh_centrocosto_carga_laboral_cab", SqlConnection)
            SqlCommand.CommandType = CommandType.StoredProcedure
            SqlCommand.Parameters.Add(New SqlParameter("@accion", SqlDbType.VarChar, 3)).Value = accion
            SqlCommand.Parameters.Add(New SqlParameter("@opcion", SqlDbType.VarChar, 120)).Value = opcion
            SqlCommand.Parameters.Add(New SqlParameter("@anio", SqlDbType.SmallInt)).Value = entity.anio
            SqlCommand.Parameters.Add(New SqlParameter("@mes", SqlDbType.SmallInt)).Value = entity.mes
            SqlCommand.Parameters.Add(New SqlParameter("@nom_archivo", SqlDbType.VarChar, 100)).Value = entity.nombreArchivo
            SqlCommand.Parameters.Add(New SqlParameter("@nom_hoja", SqlDbType.VarChar, 50)).Value = entity.nombreHoja
            SqlCommand.Parameters.Add(New SqlParameter("@usuario", SqlDbType.VarChar, 50)).Value = entity.loginUsuario
            SqlCommand.Parameters.Add(New SqlParameter("@value_out", SqlDbType.Int))
            SqlCommand.Parameters("@value_out").Direction = ParameterDirection.Output

            SqlConnection.Open()
            SqlCommand.ExecuteNonQuery()

            value = SqlCommand.Parameters("@value_out").Value

        End Using

        Return value
    End Function

    Public Function agregarDetalle(ByVal accion As String, ByVal opcion As String, _
        ByVal entity As Detalle) As Integer

        Dim value As Integer

        Using SqlConnection As SqlConnection = New SqlConnection(ConfigApp.Data.ConexionBD)

            Dim SqlCommand As SqlCommand = New SqlCommand("usp_rrhh_centrocosto_carga_laboral_det", SqlConnection)
            SqlCommand.CommandType = CommandType.StoredProcedure
            SqlCommand.Parameters.Add(New SqlParameter("@accion", SqlDbType.VarChar, 3)).Value = accion
            SqlCommand.Parameters.Add(New SqlParameter("@opcion", SqlDbType.VarChar, 120)).Value = opcion

            SqlCommand.Parameters.Add(New SqlParameter("@fk_cc_car_lab_cab_id", SqlDbType.Int)).Value = entity.idCabecera
            SqlCommand.Parameters.Add(New SqlParameter("@nom_empleado", SqlDbType.VarChar, 100)).Value = entity.empleado
            SqlCommand.Parameters.Add(New SqlParameter("@cod_empleado", SqlDbType.VarChar, 10)).Value = entity.codigoEmpleado
            SqlCommand.Parameters.Add(New SqlParameter("@ape_nom_empleado", SqlDbType.VarChar, 100)).Value = entity.apellidosEmpleado.Trim
            SqlCommand.Parameters.Add(New SqlParameter("@usuario", SqlDbType.VarChar, 50)).Value = entity.loginUsuario
            SqlCommand.Parameters.Add(New SqlParameter("@value_out", SqlDbType.Int))
            SqlCommand.Parameters("@value_out").Direction = ParameterDirection.Output

            SqlConnection.Open()
            SqlCommand.ExecuteNonQuery()

            value = SqlCommand.Parameters("@value_out").Value

        End Using

        Return value
    End Function

    Public Function eliminar(ByVal accion As String, ByVal opcion As String, ByVal anio As Short, ByVal mes As Short, ByVal loginUsuario As String) As Integer

        Dim value As Integer

        Using SqlConnection As SqlConnection = New SqlConnection(ConfigApp.Data.ConexionBD)

            Dim SqlCommand As SqlCommand = New SqlCommand("usp_rrhh_centrocosto_carga_laboral_cab", SqlConnection)
            SqlCommand.CommandType = CommandType.StoredProcedure
            SqlCommand.Parameters.Add(New SqlParameter("@accion", SqlDbType.VarChar, 3)).Value = accion
            SqlCommand.Parameters.Add(New SqlParameter("@opcion", SqlDbType.VarChar, 120)).Value = opcion
            SqlCommand.Parameters.Add(New SqlParameter("@anio", SqlDbType.SmallInt)).Value = anio
            SqlCommand.Parameters.Add(New SqlParameter("@mes", SqlDbType.SmallInt)).Value = mes
            SqlCommand.Parameters.Add(New SqlParameter("@usuario", SqlDbType.VarChar, 50)).Value = loginUsuario
            SqlCommand.Parameters.Add(New SqlParameter("@value_out", SqlDbType.Int))
            SqlCommand.Parameters("@value_out").Direction = ParameterDirection.Output

            SqlConnection.Open()
            SqlCommand.ExecuteNonQuery()

            value = SqlCommand.Parameters("@value_out").Value

        End Using

        Return value
    End Function
End Class
