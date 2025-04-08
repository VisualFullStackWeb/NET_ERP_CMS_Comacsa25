Imports SIP_Entidad
Imports SIP_Datos

Public Class NGAprobacionFirmaMonto
    Dim AprobacionFirmaMontoDAO As New DAAprobacionFirmaMonto

    Public Function ListarFirmaMonto(ByVal Firma As ETAprobacionFirmaMonto, ByVal Opcion As String) As DataTable
        Return AprobacionFirmaMontoDAO.ListarFirmaMonto(Firma, Opcion)
    End Function

    Public Function ListarRangoAprobacion(ByVal Aprobacion As ETAprobacionFirmaMonto, ByVal Opcion As String) As DataTable
        Return AprobacionFirmaMontoDAO.ListarRangoAprobacion(Aprobacion, Opcion)
    End Function

    Public Function GrabarRangoAprobacion(ByVal RangoApropacion As ETAprobacionFirmaMonto, ByVal A As List(Of ETAprobacionFirmaMonto), ByVal Opcion As String) As ETResultado
        Return AprobacionFirmaMontoDAO.GrabarRangoAprobacion(RangoApropacion, A, Opcion)
    End Function

    Public Function RangoAprobacionEliminar(ByVal RangoApropacion As ETAprobacionFirmaMonto) As ETResultado
        Return AprobacionFirmaMontoDAO.RangoAprobacionEliminar(RangoApropacion)
    End Function

    Public Function GrabarAprobacionOC(ByVal Aprobacion As List(Of ETAprobacionFirmaMonto)) As ETResultado
        Return AprobacionFirmaMontoDAO.GrabarAprobacionOC(Aprobacion)
    End Function

    Public Function GrabarAnularAprobacionOC(ByVal Aprobacion As List(Of ETAprobacionFirmaMonto)) As ETResultado
        Return AprobacionFirmaMontoDAO.GrabarAnularAprobacionOC(Aprobacion)
    End Function

End Class
