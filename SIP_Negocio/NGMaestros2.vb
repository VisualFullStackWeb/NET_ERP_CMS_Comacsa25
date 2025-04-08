Imports SIP_Entidad
Imports SIP_Datos

Public Class NGMaestros2
    Dim Maestros2DAO As New DAMaestros2
    Dim FechaTemp As Date = Date.Now.ToShortDateString

    Public Function ListarAreaSolicitante(ByVal Opcion As String) As DataTable
        Return Maestros2DAO.ListarAreaSolicitante(Opcion)
    End Function

    Public Function ListarDocumentosTecnicos() As DataTable
        Return Maestros2DAO.ListarDocumentosTecnicos()
    End Function

    Public Function ListarEmpleoLabor(ByVal Codigo As String) As DataTable
        Return Maestros2DAO.ListarEmpleoLabor(Codigo)
    End Function

    Public Function ListarEstado() As DataTable
        Return Maestros2DAO.ListarEstado()
    End Function

    Public Function ListarActivo(ByVal Cia As String) As DataTable
        Return Maestros2DAO.ListarActivo(Cia)
    End Function

    Public Function ListarTipoActivo() As DataTable
        Return Maestros2DAO.ListarTipoActivo()
    End Function

    Public Function ListarDescripcionActivo(ByVal Cia As String, ByVal Activo As String, ByVal Empleo As String, ByVal Opcion As String) As DataTable
        Return Maestros2DAO.ListarDescripcionActivo(Cia, Activo, Empleo, Opcion)
    End Function

    Public Function Listar_Maestros2(ByVal Cia As String, ByVal Linea As String, ByVal SubLinea As String, ByVal UM As String, ByVal Opcion As String, ByVal Cantera As String, ByVal Fecha As Date, ByVal FechaTermino As DateTime) As DataTable
        Return Maestros2DAO.Listar_Maestros2(Cia, Linea, SubLinea, UM, Opcion, Cantera, Fecha, FechaTermino)
    End Function

    Public Function ListarPlantasInternasProduccion() As DataTable
        Return Maestros2DAO.ListarPlantasInternasProduccion
    End Function

End Class
