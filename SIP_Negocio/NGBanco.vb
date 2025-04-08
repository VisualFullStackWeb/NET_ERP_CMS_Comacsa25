Imports SIP_Entidad
Imports SIP_Datos

Public Class NGBanco

    Private List As List(Of ETBanco)

    Public Function ListarBancos(ByVal Reg As ETBanco, ByVal Opcion As String) As DataTable
        Return Datos.Banco.ListarBancos(Reg, Opcion)
    End Function

End Class
