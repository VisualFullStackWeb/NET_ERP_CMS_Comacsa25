Imports SIP_Entidad
Imports SIP_Datos

Public Class NGRegistroSOAT
    Dim RegistroSOATDA As New DARegistroSOAT

    Public Function Mantenimiento(ByVal pRegSOAT As ETRegistroSOAT, ByVal pOpcion As Integer) As ETResultado
        Return RegistroSOATDA.Mantenimiento(pRegSOAT, pOpcion)
    End Function

    Public Function Listar(ByVal pRegSOAT As ETRegistroSOAT) As DataTable
        Return RegistroSOATDA.Listar(pRegSOAT)
    End Function
End Class
