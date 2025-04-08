Imports SIP_Entidad
Imports SIP_Datos
Public Class NGOrdenTrabajoRecursoSinPrecio

    Public Function Mantenedor_Orden_Trabajo_Mantto(ByVal ListaPrecioNuevo As List(Of ETOrdenTrabajo_Recursos), _
                                                    ByVal ListaPrecioAntigua As List(Of ETOrdenTrabajo_Recursos)) As ETOrdenTrabajo_Recursos
        Dim lResult As ETOrdenTrabajo_Recursos = Nothing
        Dim Mensaje1, Mensaje2 As String
        Dim MsgFechas As String = String.Empty


        Mensaje1 = "¿Seguro desea Guardar los cambios?"
        Mensaje2 = "Se Guardaron Correctamente los Datos"

Ingreso:

        lResult = New ETOrdenTrabajo_Recursos


Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return Nothing
        Else
            lResult = Datos.OrdenTrabajo_Recursos_SinPrecio.Mantenedor_OrdenTrabajo_Recurso_Sin_Precio(ListaPrecioNuevo, ListaPrecioAntigua)
        End If

Salida:

        If Not (lResult Is Nothing) Then

            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If
Salir:
        Return lResult
    End Function

    Public Function Consultar_OrdenTrabajo(ByVal OrdenTrabajo As ETOrdenTrabajo_Mantto) As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.OrdenTrabajo_Recursos_SinPrecio.Consultar_OrdenTrabajo_Recurso_SinPrecio(OrdenTrabajo)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
End Class
