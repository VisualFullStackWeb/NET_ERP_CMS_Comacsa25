Imports SIP_Entidad
Imports SIP_Datos

Public Class NGEmpleado
    Public Function ConsultarPagoTrabajador(ByVal Empleado As ETEmpelado) As DataTable
        Return Datos.Empleado.ConsultarPagoTrabajador(Empleado)
    End Function

    Public Function MantPagoTrabajador(ByVal Empleado As ETEmpelado) As Int32
        Return Datos.Empleado.MantPagoTrabajador(Empleado)
    End Function
    Public Function Prueba(ByVal Empleado As ETEmpelado) As DataTable
        Return Datos.Empleado.Prueba(Empleado)
    End Function
End Class
