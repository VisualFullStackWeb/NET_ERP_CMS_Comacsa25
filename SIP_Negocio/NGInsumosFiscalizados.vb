Imports SIP_Entidad
Imports SIP_Datos

Public Class NGInsumosFiscalizados

    Public Function Insertar_InsumosFiscalizados(ByVal C As ETInsumosFiscalizados) As Integer
        Try
            Return Datos.InsumosFiscalizados.Insertar_InsumosFiscalizados(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Actualizar_InsumosFiscalizados(ByVal C As ETInsumosFiscalizados) As Integer
        Try
            Return Datos.InsumosFiscalizados.Actualizar_InsumosFiscalizados(C)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_UnidadesDeMedidas(ByVal pCod_Cia As String) As DataTable
        Try
            Return Datos.InsumosFiscalizados.Listar_UnidadesDeMedidas(pCod_Cia)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_InsumosFiscalizados_x_Cod_Cia(ByVal pCod_Cia As String) As DataTable
        Try
            Return Datos.InsumosFiscalizados.Listar_InsumosFiscalizados_x_Cod_Cia(pCod_Cia)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mostrar_InsumosFiscalizados_x_Id_Prod(ByVal pId_Prod As String) As ETInsumosFiscalizados
        Try
            Return Datos.InsumosFiscalizados.Mostrar_InsumosFiscalizados_x_Id_Prod(pId_Prod)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mostrar_ID_PROD_InsumosFiscalizados_x_Cod_SUNAT(ByVal pCod_Cia As String, ByVal pCod_Sunat As String) As Integer
        Try
            Return Datos.InsumosFiscalizados.Mostrar_ID_PROD_InsumosFiscalizados_x_Cod_SUNAT(pCod_Cia, pCod_Sunat)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Mostrar_Count_InsumosFProductosXId_Prod(ByVal pId_Prod As Integer) As Integer
        Try
            Return Datos.InsumosFiscalizados.Mostrar_Count_InsumosFProductosXId_Prod(pId_Prod)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try

    End Function

    Public Function Anular_InsumosFiscalizados(ByVal pId_Prod As Integer, ByVal pUser_Modi As String) As Integer
        Try
            Return Datos.InsumosFiscalizados.Anular_InsumosFiscalizados(pId_Prod, pUser_Modi)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Modifica_Iqbf(ByVal Ls_Datos As List(Of ETInsumosFiscalizados)) As Integer

        Try
            Return Datos.InsumosFiscalizados.Modifica_Iqbf(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Cierre_Iqbf(ByVal _Datos As ETInsumosFiscalizados) As Integer

        Try
            Return Datos.InsumosFiscalizados.Cierre_Iqbf(_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
End Class
