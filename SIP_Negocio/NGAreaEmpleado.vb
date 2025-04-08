Imports SIP_Entidad
Imports SIP_Datos

Public Class NGAreaEmpleado
    Public Function Mantenedor_AreaEmpleado(ByVal Ls_Emp As List(Of ETAreaEmpleado), ByVal Ls_Emp_Del As List(Of ETAreaEmpleado)) As Integer
        Dim lResult As New ETResultado
        If Ls_Emp Is Nothing Then Return 0
        If Ls_Emp_Del Is Nothing Then Return 0
        Dim Mensaje1, Mensaje2 As String

        Mensaje1 = "¿Seguro desea Guardar los cambios?"
        Mensaje2 = "Se Guardaron Correctamente los Datos"
Ingreso:

Operacion:

        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else

            lResult.Valor = Datos.Area_Empleado.Mantenedor_AreaEmpleado(Ls_Emp_Del, Ls_Emp)
            If lResult.Valor = 0 Then
                MsgBox("No se Grabarón los Datos", MsgBoxStyle.Critical, msgComacsa)
                GoTo Salir
            End If
        End If

Salida:

        If lResult.Valor > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
        End If
Salir:
        Return lResult.Valor
    End Function

    Public Function Consultar_Area_Empleado(ByVal Entidad As ETAreaEmpleado) As ETMyLista
        Return Datos.Area_Empleado.Consultar_AreaEmpleado(Entidad)
    End Function
End Class
