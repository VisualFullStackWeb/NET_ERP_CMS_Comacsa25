Imports SIP_Entidad
Imports SIP_Datos

Public Class NGTarjetaConsumo

    Dim TarjetaConsumoDA As New DATarjetaConsumo

    Public Function ValidaTarjetaConsumoAsignado(ByVal pTarjetaConsumo As ETTarjetaConsumo, ByVal op As Integer) As ETResultado
        Return TarjetaConsumoDA.ValidaTarjetaConsumoAsignado(pTarjetaConsumo, op)
    End Function

    'Listado de Tarjeta de Consumo
    Public Function ListarTarjetasConsumo(ByVal pTarjetaConsumo As ETTarjetaConsumo) As DataTable
        Return TarjetaConsumoDA.ListarTarjetaConsumo(pTarjetaConsumo)
    End Function

    'Historial de Tarjeta de Consumo
    Public Function spTarjetaConsumo_Historial(ByVal pTarjetaConsumo As ETTarjetaConsumo) As DataTable
        Return TarjetaConsumoDA.ListarTarjetaConsumoHistorial(pTarjetaConsumo)
    End Function

    'Public Function Obtener(ByVal pAsigCelular As ETAsigCelular) As DataTable
    '    Return TarjetaConsumoDA.Obtener(pAsigCelular)
    'End Function

    Public Function CargarTipoTarjeta() As DataTable
        Return Datos.TarjetaConsumo.CargarTipoTarjeta()
    End Function

    Public Function CargarMonedaTarjeta() As DataTable
        Return Datos.TarjetaConsumo.CargarMonedaTarjeta()
    End Function

    Public Function CargaEstadoTarjeta() As DataTable
        Return Datos.TarjetaConsumo.CargaEstadoTarjeta()
    End Function

    Public Function MantenimientoTarjetaConsumoAsignado(ByVal pTarjetaConsumo As ETTarjetaConsumo, ByVal pOpcion As Integer) As ETResultado
        Return TarjetaConsumoDA.MantenimientoTarjetaConsumoAsignado(pTarjetaConsumo, pOpcion)
    End Function

    Public Function ListarLimiteTarjetasConsumo(ByVal idTarjetaConsumo As Integer, ByVal idTipoTarjetaConsumo As Integer) As DataTable
        Return TarjetaConsumoDA.ListarLimiteTarjetasConsumo(idTarjetaConsumo, idTipoTarjetaConsumo)
    End Function

End Class
