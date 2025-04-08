Imports SIP_Entidad
Imports SIP_Datos

Public Class NGOrdenCompra
    Dim OrdenCompraDAO As New DAOrdenCompra

    Public Function ListarCabOrdenCompra(ByVal OC As ETOrdenCompra) As DataTable
        Return OrdenCompraDAO.ListarCabOrdenCompra(OC)
    End Function

    Public Function ListarCabOrdenCompraUsuario(ByVal OC As ETOrdenCompra) As DataTable
        Return OrdenCompraDAO.ListarCabOrdenCompraUsuario(OC)
    End Function

    Public Function ListarDetalleOC(ByVal OC As ETOrdenCompra) As DataTable
        Return OrdenCompraDAO.ListarDetalleOC(OC)
    End Function

    Public Function ListarTopMejores(ByVal Producto As ETProducto) As DataTable
        Return OrdenCompraDAO.ListarTopMejores(Producto)
    End Function

    Public Function ArticulosComparados(ByVal OC As ETOrdenCompra, ByVal Tipo As String) As DataTable
        Return OrdenCompraDAO.ArticulosComparados(OC, Tipo)
    End Function

    Public Function DocumentosReferencia(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable
        Return OrdenCompraDAO.DocumentosReferencia(Guia, Opcion)
    End Function

End Class
