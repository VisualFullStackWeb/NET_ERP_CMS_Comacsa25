Imports SIP_Entidad
Imports SIP_Datos

Public Class NGAlmacen

    Public Function ConsultarAlmacen5() As DataTable
        Return Datos.Almacen.ConsultarAlmacen5
    End Function

    Public Function ConsultarAlmacen6() As DataTable
        Return Datos.Almacen.ConsultarAlmacen6
    End Function

    Public Function ConsultarAlmacen1() As DataTable
        Return Datos.Almacen.ConsultarAlmacen1
    End Function

    Public Function Listar_Almacen(ByVal Almacen As ETAlmacen, ByVal Opcion As String) As DataTable
        Return Datos.Almacen.Listar_Almacen(Almacen, Opcion)
    End Function

    Public Function DireccionAlmacen(ByVal AlmacenBE As ETAlmacen) As ETResultado
        Return Datos.Almacen.DireccionAlmacen(AlmacenBE)
    End Function

    Public Function DocumentosIngresoTransferencia(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable
        Return Datos.Almacen.DocumentosIngresoTransferencia(Guia, Opcion)
    End Function

End Class
