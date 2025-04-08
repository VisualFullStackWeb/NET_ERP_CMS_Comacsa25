Imports SIP_Entidad
Imports SIP_Datos

Public Class NGAsigCelular

    Dim AsignacionCelularDA As New DAAsigCelular

    Public Function MantenimientoBolsa(ByVal CodCia As String, ByVal CodBolsa As String, ByVal Bolsa As String, ByVal pOpcion As Integer) As ETResultado
        Return AsignacionCelularDA.MantenimientoBolsa(CodCia, CodBolsa, Bolsa, pOpcion)
    End Function
    Public Function MantenimientoCelularesAsignados(ByVal pAsigCelular As ETAsigCelular, ByVal pOpcion As Integer) As ETResultado
        Return AsignacionCelularDA.MantenimientoCelularesAsignados(pAsigCelular, pOpcion)
    End Function
    Public Function ListarCelularesAsignados(ByVal pAsigCelular As ETAsigCelular) As DataTable
        Return AsignacionCelularDA.ListarCelularesAsignados(pAsigCelular)
    End Function
    Public Function Obtener(ByVal pAsigCelular As ETAsigCelular) As DataTable
        Return AsignacionCelularDA.Obtener(pAsigCelular)
    End Function
    Public Function ListarBolsas(ByVal pAsigCelular As ETAsigCelular) As DataTable
        Return AsignacionCelularDA.ListarBolsas(pAsigCelular)
    End Function
End Class
