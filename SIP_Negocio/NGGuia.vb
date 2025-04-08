Imports SIP_Entidad
Imports SIP_Datos

Public Class NGGuia
    Dim GuiaDAO As New DAGuia

    Public Function GrabarMovimiento(ByVal Opcion As String, ByVal Mov As String, ByVal Doc As String _
                                           , ByVal Guia As ETGuia, ByVal X As List(Of ETGuia) _
                                           , ByVal P As List(Of ETPedido), ByVal Y As List(Of ETGuia) _
                                           , ByVal Almacen As ETAlmacen) As ETResultado
        Return GuiaDAO.GrabarMovimiento(Opcion, Mov, Doc, Guia, X, P, Y, Almacen)
    End Function

    Public Function EliminarMovimiento(ByVal Guia As ETGuia, ByVal X As List(Of ETGuia)) As ETResultado
        Return GuiaDAO.EliminarMovimiento(Guia, X)
    End Function

    Public Function Listar_Guia(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable
        Return GuiaDAO.Listar_Guia(Guia, Opcion)
    End Function

    Public Function ListarMovimientoOrdenCompra(ByVal Listar As ETGuia, ByVal Opcion As String) As DataTable
        Return GuiaDAO.ListarMovimientoOrdenCompra(Listar, Opcion)
    End Function

    Public Function ListarMovimientoSalidaDevolucion(ByVal Listar As ETGuia, ByVal Opcion As String) As DataTable
        Return GuiaDAO.ListarMovimientoSalidaDevolucion(Listar, Opcion)
    End Function

    Public Function ListarMovimientoSalidaTransferencia(ByVal Listar As ETGuia, ByVal Opcion As String) As DataTable
        Return GuiaDAO.ListarMovimientoSalidaTransferencia(Listar, Opcion)
    End Function

    Public Function ListarTipoCambio(ByVal Cia As String, ByVal Tipo As String) As DataTable
        Return GuiaDAO.ListarTipoCambio(Cia, Tipo)
    End Function

    Public Function ListarMovimientoPorAjuste(ByVal Listar As ETGuia, ByVal Opcion As String) As DataTable
        Return GuiaDAO.ListarMovimientoPorAjuste(Listar, Opcion)
    End Function

    Public Function ListarIngresoTransferencia(ByVal Listar As ETGuia, ByVal Opcion As String) As DataTable
        Return GuiaDAO.ListarIngresoTransferencia(Listar, Opcion)
    End Function

    Public Function ListarSalidaRemarcado(ByVal Listar As ETGuia, ByVal Opcion As String) As DataTable
        Return GuiaDAO.ListarSalidaRemarcado(Listar, Opcion)
    End Function

    Public Function EliminacionTotal(ByVal CabGuia As ETGuia) As ETResultado
        Return GuiaDAO.EliminacionTotal(CabGuia)
    End Function

    Public Function ConvertirIngresoAlmacen(ByVal Producto As ETProducto, ByVal Cantidad As Decimal) As ETResultado
        Return GuiaDAO.ConvertirIngresoAlmacen(Producto, Cantidad)
    End Function

    Public Function ListarDetalleIngresoOC(ByVal Guia As ETGuia) As DataTable
        Return GuiaDAO.ListarDetalleIngresoOC(Guia)
    End Function

    Public Function ListarDetalleSalidaDevolucion(ByVal Guia As ETGuia) As DataTable
        Return GuiaDAO.ListarDetalleSalidaDevolucion(Guia)
    End Function

    Public Function ListarDetalleIngresoAjuste(ByVal Guia As ETGuia) As DataTable
        Return GuiaDAO.ListarDetalleIngresoAjuste(Guia)
    End Function

    Public Function ListarDetalleIngresoRemarcado(ByVal Guia As ETGuia) As DataTable
        Return GuiaDAO.ListarDetalleIngresoRemarcado(Guia)
    End Function

    Public Function ListarDetalleSalidaRemarcado(ByVal Guia As ETGuia) As DataTable
        Return GuiaDAO.ListarDetalleSalidaRemarcado(Guia)
    End Function

    Public Function ListarDetalleIngresoSinOC(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable
        Return GuiaDAO.ListarDetalleIngresoSinOC(Guia, Opcion)
    End Function

    Public Function ListarBilletesEnvioCantera(ByVal Guia As ETGuia) As DataTable
        Return GuiaDAO.ListarBilletesEnvioCantera(Guia)
    End Function

    Public Function ListarSalidaTransferenciaCantera(ByVal Guia As ETGuia) As DataTable
        Return GuiaDAO.ListarSalidaTransferenciaCantera(Guia)
    End Function

    Public Function ListarDetalleSalidaTransferencia(ByVal Guia As ETGuia) As DataTable
        Return GuiaDAO.ListarDetalleSalidaTransferencia(Guia)
    End Function

    Public Function Listar_GR_Contratista(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable
        Return GuiaDAO.Listar_GR_Contratista(Guia, Opcion)
    End Function

    Public Function VerificaDevolucion(ByVal Guia As ETGuia) As DataTable
        Return GuiaDAO.VerificaDevolucion(Guia)
    End Function

    Public Function OCPendienteIngresoProductos(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable
        Return GuiaDAO.OCPendienteIngresoProductos(Guia, Opcion)
    End Function

    Public Function OCIngresoAlmacen(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable
        Return GuiaDAO.OCIngresoAlmacen(Guia, Opcion)
    End Function

    Public Function Serie_Movimoiento(ByVal Cia As String, ByVal Almacen As String) As String
        Return GuiaDAO.Serie_Movimiento(Cia, Almacen)
    End Function

End Class
