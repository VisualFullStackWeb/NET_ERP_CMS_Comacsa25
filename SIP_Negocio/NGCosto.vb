Imports SIP_Entidad
Imports SIP_Datos
Public Class NGCosto
    Public Function Consulta(ByVal C As ETCosto) As List(Of ETCosto)
        Return Datos.Costo.Consulta(C)
    End Function
End Class
