Imports SIP_Entidad
Imports SIP_Datos

Public Class NGEmpleoLabor
    Dim EmpleoLaborDAO As New DAEmpleoLabor

    Public Function AgregarEmpleoLabor(ByVal EmpleoLabor As ETEmpleoLabor, ByVal Activo As List(Of ETEmpleoLabor), ByVal Linea As List(Of ETEmpleoLabor), ByVal SubLinea As List(Of ETEmpleoLabor), ByVal Cantera As List(Of ETEmpleoLabor), ByVal Opcion As String) As ETResultado
        Return EmpleoLaborDAO.AgregarEmpleoLabor(EmpleoLabor, Activo, Linea, SubLinea, Cantera, Opcion)
    End Function

    Public Function EliminarEmpleoLabor(ByVal EmpleoLabor As ETEmpleoLabor) As ETResultado
        Return EmpleoLaborDAO.EliminarEmpleoLabor(EmpleoLabor)
    End Function

    Public Function ListarEmpleoLabor(ByVal Empleo As ETEmpleoLabor, ByVal Opcion As String) As DataTable
        Return EmpleoLaborDAO.ListarEmpleoLabor(Empleo, Opcion)
    End Function

    Public Function ListarActivo(ByVal Empleo As ETEmpleoLabor, ByVal Opcion As String) As DataTable
        Return EmpleoLaborDAO.ListarActivo(Empleo, Opcion)
    End Function

    Public Function ListarCantera(ByVal Empleo As ETEmpleoLabor, ByVal Opcion As String) As DataTable
        Return EmpleoLaborDAO.ListarCantera(Empleo, Opcion)
    End Function

    Public Function Cantera(ByVal Empleo As ETEmpleoLabor, ByVal Opcion As String) As DataTable
        Return EmpleoLaborDAO.Cantera(Empleo, Opcion)
    End Function

    Public Function ContratistaCantera(ByVal Empleo As ETEmpleoLabor, ByVal Opcion As String) As DataTable
        Return EmpleoLaborDAO.ContratistaCantera(Empleo, Opcion)
    End Function


End Class
