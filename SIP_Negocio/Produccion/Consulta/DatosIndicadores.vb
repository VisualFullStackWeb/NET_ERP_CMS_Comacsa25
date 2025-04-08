Public Class DatosIndicadores
    Public Function listadoDataIndicador(ByVal fechaInicio As Date, ByVal fechaFin As Date) As List(Of DataTable)

        Try

            Dim data As New SIP_Datos.DatosIndicadores
            Return data.listar(fechaInicio, fechaFin)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
End Class
