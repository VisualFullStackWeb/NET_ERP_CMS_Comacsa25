Imports SIP_Entidad
Imports SIP_Datos
Public Class NGMineral
 

    Public Function ConsultarMineral1() As List(Of ETMineral)
        Return Datos.Mineral.ConsultarMineral1
    End Function

End Class
