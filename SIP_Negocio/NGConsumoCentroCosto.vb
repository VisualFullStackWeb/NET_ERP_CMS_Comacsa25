Imports SIP_Entidad
Imports SIP_Datos

Public Class NGConsumoCentroCosto

    Dim ConsumoCentroCostoDA As New DAConsumoCentroCosto

    Public Function ListarTipoConsumoCentroCosto(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Return ConsumoCentroCostoDA.ListarTipoConsumoCentroCosto(pConsumoCentroCosto)
    End Function
    Public Function MantenimientoConsumoCentroCosto(ByVal pConsumoCentroCosto As ETConsumoCentroCosto, ByVal pOp As Integer) As DataTable
        Return ConsumoCentroCostoDA.MantenimientoConsumoCentroCosto(pConsumoCentroCosto, pOp)
    End Function
    Public Function ObtenerConsumoCentroCosto(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Return ConsumoCentroCostoDA.ObtenerConsumoCentroCosto(pConsumoCentroCosto)
    End Function
    Public Function ListarConsumoCentroCosto(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Return ConsumoCentroCostoDA.ListarConsumoCentroCosto(pConsumoCentroCosto)
    End Function
    Public Function ListarCentroCosto(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Return ConsumoCentroCostoDA.ListarCentroCosto(pConsumoCentroCosto)
    End Function
    Public Function ListarUbigeo(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Return ConsumoCentroCostoDA.ListarUbigeo(pConsumoCentroCosto)
    End Function
    Public Function MantTarifaUbigeo(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Return ConsumoCentroCostoDA.MantTarifaUbigeo(pConsumoCentroCosto)
    End Function
    Public Function ListarTarifaUbigeo(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Return ConsumoCentroCostoDA.ListarTarifaUbigeo(pConsumoCentroCosto)
    End Function
End Class
