Imports SIP_Datos
Imports SIP_Entidad
Imports SIP_Negocio

Public Class NGCiaEstablecimiento
    Public Function ListarCiaEstablecimiento() As List(Of ETCiaEstablecimiento)
        Dim da As New DACiaEstablecimiento
        Try
            Return da.ListarCiaEstablecimiento()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
