Imports SIP_Datos
Imports SIP_Entidad

Public Class NGOrdenTrabajo_Mantto
    Public Function Mantenedor_Orden_Trabajo_Mantto(ByVal Entidad As ETOrdenTrabajo_Mantto) As ETOrdenTrabajo_Mantto
        Dim lResult As ETOrdenTrabajo_Mantto = Nothing
        Dim Mensaje1, Mensaje2 As String
        Dim MsgFechas As String = String.Empty
        If Entidad Is Nothing Then
            Return Nothing
        End If
        If Entidad.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Entidad.Abrev & " - " & Entidad.Codigo & " ?"
        End If

Ingreso:

        lResult = New ETOrdenTrabajo_Mantto

        If Entidad.Tipo = 3 Then
            GoTo Operacion
        End If

        If Not (Entidad.Status = "P" Or Entidad.Status = "*") Then
            Dim Validar As New ETResultado
            Validar = Datos.OrdenTrabajo_Mantto.Validar_OrdenTrabajo_Fecha(Entidad)
            lResult.Tipo = 0
            If Validar.Rec1 > 0 Then
                Select Case Validar.Rec1
                    Case 1
                        MsgFechas = "La Fecha de Inicio es mayor a la Mínima Fecha de la Asignación de los Costos de Materiales y Servicios"
                    Case 2
                        MsgFechas = "La Fecha de Inicio es mayor a la Mínima Fecha de la Asignación de los Costos de Equipos"
                    Case 3
                        MsgFechas = "La Fecha de Inicio es mayor a la Mínima Fecha de la Asignación de los Costos de Mano de Obra"
                End Select
                MsgFechas = MsgFechas & Chr(13) & "Se cambiará la Fecha de Inicio a " & Validar.RIni.ToShortDateString
                lResult.FechaInicio = Validar.RIni
                lResult.Tipo = 1
                MsgBox(MsgFechas, MsgBoxStyle.Critical, msgComacsa)
            End If

            If Validar.Rec2 > 0 Then
                Select Case Validar.Rec2
                    Case 1
                        MsgFechas = "La Fecha de Termino es menor a la Máxima Fecha de la Asignación de los Costos de Materiales y Servicios"
                    Case 2
                        MsgFechas = "La Fecha de Termino es menor a la Máxima Fecha de la Asignación de los Costos de Equipos"
                    Case 3
                        MsgFechas = "La Fecha de Termino es menor a la Máxima Fecha de la Asignación de los Costos de Mano de Obra"
                End Select
                MsgFechas = MsgFechas & Chr(13) & "Se cambiará la Fecha de Inicio a " & Validar.RFin.ToShortDateString
                lResult.FechaTerminacion = Validar.RFin
                If lResult.Tipo = 1 Then
                    lResult.Tipo = 3
                Else
                    lResult.Tipo = 2
                End If

                MsgBox(MsgFechas, MsgBoxStyle.Critical, msgComacsa)
            End If


            If Validar.Rec1 > 0 Or Validar.Rec2 > 0 Then
                lResult.Validacion = Boolean.FalseString
                Return lResult
            End If

            If Datos.OrdenTrabajo_Mantto.Validar_CostoBackLogCerrado(Entidad) > 0 Then
                MsgBox("Existen BackLog en Ejecución", MsgBoxStyle.Critical, msgComacsa)
                Return Nothing
            End If

        End If
Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return Nothing
        Else
            lResult = Datos.OrdenTrabajo_Mantto.Mantenedor_Orden_Trabajo(Entidad)
        End If

Salida:

        If Not (lResult Is Nothing) Then
            If Entidad.Tipo = 1 Then
                Mensaje2 = "Se Generó la Orden de Trabajo: " & Entidad.Abrev & " - " & lResult.Codigo
            ElseIf Entidad.Tipo = 2 Then
                Mensaje2 = "Se modificó la Orden de Trabajo: " & Entidad.Abrev & " - " & lResult.Codigo
            Else
                Mensaje2 = "Se Anularon Correctamente los Datos"
            End If

            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If
Salir:
        Return lResult
    End Function

    Public Function Consultar_OrdenTrabajo() As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.OrdenTrabajo_Mantto.Consultar_OrdenTrabajo
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_OrdenTrabajo_Recurso_Sin_Precio() As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.OrdenTrabajo_Mantto.Consultar_OrdenTrabajo_Sin_Precio
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Reporte_OrdenTrabajo() As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.OrdenTrabajo_Mantto.Reporte_OrdenTrabajo
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_BackLog() As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.OrdenTrabajo_Mantto.Consultar_BackLog
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_OrdenTrabajo_Recursos(ByVal Entidad As ETOrdenTrabajo_Recursos) As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.OrdenTrabajo_Recursos.Consultar_OrdenTrabajo_Recursos(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_OrdenTrabajo_Origen(ByVal Entidad As ETOrdenTrabajo_Recursos) As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.OrdenTrabajo_Recursos.Consultar_OrdenTrabajoOrigen(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Anular_Orden_Trabajo_Mantto(ByVal Entidad As ETOrdenTrabajo_Mantto) As ETOrdenTrabajo_Mantto
        Dim lResult As ETOrdenTrabajo_Mantto = Nothing
        Dim Mensaje2 As String
        Dim Status As String = String.Empty
        Dim CostoTotal As Double = 0
        If Entidad Is Nothing Then
            Return Nothing
        End If

Ingreso:

        lResult = New ETOrdenTrabajo_Mantto

        Status = Datos.OrdenTrabajo_Mantto.Obtener_OrdenTrabajo_Estado(Entidad)

        If Status.Trim = "*" Then
            MsgBox("La Orden de Trabajo ya fue Anulado", MsgBoxStyle.Critical, msgComacsa)
            Return Nothing
        ElseIf Not (Status.Trim = "P") Then
            MsgBox("El Trabajo ya fue Concluido", MsgBoxStyle.Critical, msgComacsa)
            Return Nothing
        End If

        CostoTotal = Datos.OrdenTrabajo_Mantto.Obtener_OrdenTrabajo_Costo_Total(Entidad)

        If CostoTotal <> 0 Then
            MsgBox("No se puede Anular la O/T porque tiene costos asignados", MsgBoxStyle.Critical, msgComacsa)
            Return Nothing
        End If
Operacion:


        lResult = Datos.OrdenTrabajo_Mantto.Mantenedor_Orden_Trabajo(Entidad)

Salida:

        If Not (lResult Is Nothing) Then
            Mensaje2 = "Se Anularon Correctamente los Datos"
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If
Salir:
        Return lResult
    End Function

    Public Function Consultar_OTsEnEjecucion(ByVal Entidad As ETOrdenTrabajo_Mantto) As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.OrdenTrabajo_Mantto.Consultar_OrdenTrabajoEnEjecucion(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_OrdenTrabajo_Costos_Detalle(ByVal Entidad As ETOrdenTrabajo_Mantto) As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.OrdenTrabajo_Mantto.Consultar_OrdenTrabajo_Recurso_Detalle(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_OrdenTrabajo_AnalisisCostos(ByVal Entidad As ETOrdenTrabajo_Mantto) As DataSet
        Return Datos.OrdenTrabajo_Mantto.Consultar_OrdenTrabajo_AnalisisCostos(Entidad)

    End Function
End Class
