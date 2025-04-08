Imports SIP_Datos
Imports SIP_Entidad
Imports SIP_Negocio
Public Class NGUbigeos

    Public Function ListarUbigeos() As List(Of ETUbigeos)
        Dim da As New DAUbigeo
        Try
            Return da.ListarUbigeos()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
