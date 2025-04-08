Imports SIP_Entidad
Imports SIP_Datos

Public Class NGAnexo
    Dim AnexoDAO As New DAAnexo

    Public Function ListarDatosAnexoOC(ByVal Anexo As ETAnexo) As DataTable
        Return AnexoDAO.ListarDatosAnexoOC(Anexo)
    End Function

    Public Function ListarDatosAnexoRequerimiento(ByVal anexo As ETAnexo) As DataTable
        Return AnexoDAO.ListarDatosAnexoRequerimiento(anexo)
    End Function

End Class
