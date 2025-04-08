Imports SIP_Entidad
Imports SIP_Datos

Public Class NGInsumosFProductos

    Public Function Listar_Productos(ByVal pCod_Cia As String) As DataTable
        Try
            Return Datos.InsumosFProductos.Listar_Productos(pCod_Cia)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Sub Grabar_ListInsumosFProductos(ByVal ListETInsumosFProductos As List(Of ETInsumosFProductos))
        Try
            Datos.InsumosFProductos.Grabar_ListInsumosFProductos(ListETInsumosFProductos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Sub

    Public Function Listar_InsumosFProductosXId_Prod(ByVal pId_Prod As Integer) As DataTable
        Try
            Return Datos.InsumosFProductos.Listar_InsumosFProductosXId_Prod(pId_Prod)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mostrar_CantidadInsumosFProductosXId_ProdAndCod_Prod(ByVal pId_Prod As Integer, ByVal pCod_Prod As String) As Integer
        Try
            Return Datos.InsumosFProductos.Mostrar_CantidadInsumosFProductosXId_ProdAndCod_Prod(pId_Prod, pCod_Prod)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

End Class
