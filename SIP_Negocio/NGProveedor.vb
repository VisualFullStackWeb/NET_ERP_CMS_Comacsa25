Imports SIP_Entidad
Imports SIP_Datos
Public Class NGProveedor
   

    Public Function ConsultarProveedor(ByVal Rpt As ETProveedor) As String

         Return Datos.Proveedor.ConsultarProveedor(Rpt) 
        
    End Function


End Class
