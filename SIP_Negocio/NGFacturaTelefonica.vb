Imports SIP_Entidad
Imports SIP_Datos

Public Class NGFacturaTelefonica

    Dim FacturaElectronicaDA As New DAFacturaTelefonica

    Public Function Listar(ByVal pFactElect As ETFacturaTelefonica) As DataTable
        Return FacturaElectronicaDA.Listar(pFactElect)
    End Function
    Public Function Obtener(ByVal pFactElect As ETFacturaTelefonica) As DataTable
        Return FacturaElectronicaDA.Obtener(pFactElect)
    End Function
    Public Function Mantenimiento(ByVal pFactElect As ETFacturaTelefonica, ByVal pOpcion As Integer) As ETResultado
        Return FacturaElectronicaDA.Mantenimiento(pFactElect, pOpcion)
    End Function
    Public Function ListarGrupos(ByVal CodCia As String) As DataTable
        Return FacturaElectronicaDA.ListarGrupos(CodCia)
    End Function
    Public Function ListarProveedores(ByVal CodCia As String) As DataTable
        Return FacturaElectronicaDA.ListarProveedores(CodCia)
    End Function
    Public Function ListarTipoDocumentos(ByVal CodCia As String) As DataTable
        Return FacturaElectronicaDA.ListarTipoDocumentos(CodCia)
    End Function

    Public Function MantenimientoFactGas(ByVal pFactElect As ETFacturaTelefonica, ByVal pOpcion As Integer) As DataTable
        Return FacturaElectronicaDA.MantenimientoFactGas(pFactElect, pOpcion)
    End Function
    Public Function ListarFactGas(ByVal pFactElect As ETFacturaTelefonica) As DataTable
        Return FacturaElectronicaDA.ListarFactGas(pFactElect)
    End Function
    Public Function ListarFactGasID(ByVal pFactElect As ETFacturaTelefonica) As DataTable
        Return FacturaElectronicaDA.ListarFactGasID(pFactElect)
    End Function
    Public Function ListarFactGasCONSUMO(ByVal pFactElect As ETFacturaTelefonica) As DataTable
        Return FacturaElectronicaDA.ListarFactGasCONSUMO(pFactElect)
    End Function
End Class
