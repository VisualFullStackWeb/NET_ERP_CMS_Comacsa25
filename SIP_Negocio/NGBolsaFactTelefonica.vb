Imports SIP_Entidad
Imports SIP_Datos

Public Class NGBolsaFactTelefonica
    Dim BolsaDA As New DABolsaFactTelefonica
    Public Function Listar(ByVal CodCia As String) As DataTable
        Return BolsaDA.Listar(CodCia)
    End Function
    Public Function Mantenimiento(ByVal pBolsa As ETBolsaFactTelefonica, ByVal pOpcion As Integer) As ETResultado
        Return BolsaDA.Mantenimiento(pBolsa, pOpcion)
    End Function
End Class
