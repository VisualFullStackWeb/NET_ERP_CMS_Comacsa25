Public Class VentaExportacion
    Public Function listadoExportacion(fechaInicio As Date, fechaFin As Date) As DataTable

        Try

            Dim data As New SIP_Datos.VentaExportacion()
            Return data.listar(fechaInicio, fechaFin)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
End Class
