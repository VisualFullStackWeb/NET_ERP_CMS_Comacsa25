Imports SIP_Datos
Imports SIP_Entidad

Public Class NGProgramacionMantto
    Public Function Mantenedor_Programacion(ByVal Entidad As ETProgramacionMantto) As Integer
        Dim lResult As ETParteEquipo = Nothing
        Dim Mensaje1, Mensaje2 As String
        If Entidad Is Nothing Then
            Return 0
        End If
        If Entidad.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Entidad.Codigo & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If

Ingreso:

        lResult = New ETParteEquipo

        If Entidad.Tipo = 3 Then
            GoTo Operacion
        End If

        Try

            If (Entidad.RequerimientoID) <= 0 Then
                MsgBox("Ingrese el Requerimiento", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If
            If (Entidad.EquipoID) <= 0 Then
                MsgBox("Ingrese el Equipo", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If Entidad.FechaInicio > Entidad.FechaTerminacion Then
                MsgBox("La Fecha de Inicio es mayor a la Fecha de Termino", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return 0

        End Try

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            lResult.Respuesta = Datos.Programacion_Mantto.Mantenedor_Programacion(Entidad)
        End If
Salida:

        If lResult.Respuesta > 0 Then
            If Entidad.Tipo <> 1 Then MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta
    End Function

    Public Function Consultar_Programacion() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        lResult = Datos.Programacion_Mantto.Consultar_Programacion

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Programacion_PendienteEjecucion() As Boolean
        Dim lResult As Boolean = False
        lResult = Datos.Programacion_Mantto.Consultar_Programacion_Pendiente_Ejecucion
        Return lResult
    End Function
End Class
