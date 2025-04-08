Imports SIP_Entidad
Imports SIP_Datos

Public Class NGPedido
    Dim PedidoDAO As New DAPedido

    Public Function GrabarPedido(ByVal Pedido As ETPedido, ByVal A As List(Of ETPedido), ByVal B As List(Of ETLisMaestroDocumentosTecnicos), ByVal Opcion As String) As ETResultado
        Return PedidoDAO.GrabarPedido(Pedido, A, B, Opcion)
    End Function

    Public Function EliminarPedido(ByVal Pedido As ETPedido) As ETResultado
        Return PedidoDAO.EliminarPedido(Pedido)
    End Function

    Public Function GrabarAutorizacion(ByVal Pedido As ETPedido, ByVal A As List(Of ETPedido)) As ETResultado
        Return PedidoDAO.GrabarAutorizacion(Pedido, A)
    End Function

    Public Function CancelarAutorizacion(ByVal Pedido As ETPedido) As ETResultado
        Return PedidoDAO.CancelarAutorizacion(Pedido)
    End Function

    Public Function GrabarDistribucionPedido(ByVal Pedido As ETPedido, ByVal B As List(Of ETPedido) _
                                            , ByVal Num1 As Integer, ByVal Num2 As Integer _
                                            , ByVal C_Guia As ETGuia, ByVal X As List(Of ETGuia) _
                                            , ByVal Reque As ETRequerimiento, ByVal C As List(Of ETRequerimiento)) As ETResultado
        Return PedidoDAO.GrabarDistribucionPedido(Pedido, B, Num1, Num2, C_Guia, X, Reque, C)
    End Function

    Public Function ActualizarEntregaPedido(ByVal Pedido As ETPedido) As ETResultado
        Return PedidoDAO.ActualizarEntregaPedido(Pedido)
    End Function

    Public Function GrabarEntrega(ByVal Pedido As ETPedido) As ETResultado
        Return PedidoDAO.GrabarEntrega(Pedido)
    End Function

    Public Function ListarDetallePedido(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable
        Return PedidoDAO.ListarDetallePedido(Pedido, Opcion)
    End Function

    Public Function GrabarAplicacion(ByVal Pedido As ETPedido, ByVal Opcion As String) As ETResultado
        Return PedidoDAO.GrabarAplicacion(Pedido, Opcion)
    End Function

    Public Function ListarAplicacion(ByVal Pedido As ETPedido) As DataTable
        Return PedidoDAO.ListarAplicacion(Pedido)
    End Function

    Public Function Listar_PedidoPendiente(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable
        Return PedidoDAO.Listar_PedidoPendiente(Pedido, Opcion)
    End Function

    Public Function Listar_PedidoAutorizado(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable
        Return PedidoDAO.Listar_PedidoAutorizado(Pedido, Opcion)
    End Function

    Public Function Listar_PedidoAtender(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable
        Return PedidoDAO.Listar_PedidoAtender(Pedido, Opcion)
    End Function

    Public Function Listar_PedidoEntregar(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable
        Return PedidoDAO.Listar_PedidoEntregar(Pedido, Opcion)
    End Function

    Public Function Listar_Pedido(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable
        Return PedidoDAO.Listar_Pedido(Pedido, Opcion)
    End Function

    Public Function Listar_Numero_SO(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable
        Return PedidoDAO.Listar_Numero_SO(Pedido, Opcion)
    End Function

    Public Function Listar_SalidaOrden(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable
        Return PedidoDAO.Listar_SalidaOrden(Pedido, Opcion)
    End Function

    Public Function Grabar_SalidaOrden(ByVal Pedido As ETPedido, ByVal Detalle As List(Of ETPedido)) As ETResultado
        Return PedidoDAO.Grabar_SalidaOrden(Pedido, Detalle)
    End Function

    Public Function Listar_DocTec(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable
        Return PedidoDAO.Listar_DocTec(Pedido, Opcion)
    End Function

    Public Function ListarSalidaOrdenRequerimientoCompra(ByVal Pedido As ETPedido) As DataTable
        Return PedidoDAO.ListarSalidaOrdenRequerimientoCompra(Pedido)
    End Function

    Public Function Consulta_Pedido(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable
        Return PedidoDAO.Consulta_Pedido(Pedido, Opcion)
    End Function

End Class
