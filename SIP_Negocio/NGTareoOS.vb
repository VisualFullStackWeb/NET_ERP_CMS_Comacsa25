Imports SIP_Entidad
Imports SIP_Datos

Public Class NGTareoOS
    Public Function Mantenedor_TareoPersonal(ByVal Entidad As ETTareoOS) As Integer
        Dim lResult As ETTareoOS = Nothing
        Dim Status As String = String.Empty
        Dim Horas As Double = 0
        Dim Mensaje1, Mensaje2 As String
        If Entidad Is Nothing Then
            Return Nothing
        End If
        If Entidad.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Entidad.Cod_TareosOS & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If


Ingreso:

        lResult = New ETTareoOS

        If Entidad.Tipo = 3 Then
            GoTo Operacion
        End If

        Try

            If String.IsNullOrEmpty(Entidad.Codigo) Then
                MsgBox("Seleccione el Personal que Trabajo en la O/T", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            If Entidad.OrdenTrabajo = 0 Then
                MsgBox("Seleccione la O/T a Tarear", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If


            If Entidad.Fecha > Entidad.FechaTerminacion Or Entidad.Fecha < Entidad.FechaInicio Then
                MsgBox("La Fecha de Tareo no esta dentro del rango de la O/T", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            If String.IsNullOrEmpty(Entidad.Fecha2) Then
                If Entidad.Fecha < CDate(Entidad.Fecha1) Then
                    MsgBox("La Fecha de Tareo no esta dentro del rango de la O/T", MsgBoxStyle.Exclamation, msgComacsa)
                    Return Nothing
                End If
            Else
                If Entidad.Fecha > CDate(Entidad.Fecha2) Or Entidad.Fecha < CDate(Entidad.Fecha1) Then
                    MsgBox("La Fecha de Tareo no esta dentro del rango de la O/T", MsgBoxStyle.Exclamation, msgComacsa)
                    Return Nothing
                End If
            End If


            Dim ObjOT As New ETOrdenTrabajo_Mantto
            ObjOT.OrdenTrabajo = Entidad.OrdenTrabajo

            Status = Datos.OrdenTrabajo_Mantto.Obtener_OrdenTrabajo_Estado(ObjOT)

            If Status = "*" Then
                MsgBox("La Orden de Trabajo esta Anulada", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            ElseIf Not (Status = "P") Then
                MsgBox("No se puede Actualizar el Costo proque el Trabajo ya Concluyó", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            Horas = Datos.TareoOS.Obtener_Horas_Trabajas_Personal_Fecha(Entidad)

            If (Entidad.Horas + Horas) > 24 Then
                MsgBox("Excedió el limite permitido de horas diarias a trabajar", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If


        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return Nothing

        End Try

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return Nothing
        Else
            lResult = Datos.TareoOS.Mantenedor_TareosOT_Personal(Entidad)

        End If
Salida:

        If lResult.Validacion Then
            If Entidad.Tipo = 1 Then
                Mensaje2 = "Se generó el Codigo: " & lResult.Codigo
                MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            Else
                MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            End If
            lResult.Respuesta = 1
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta
    End Function

    Public Function Consultar_TareoOSPersonal(ByVal Entidad As ETTareoOS) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing
        lResult = New ETMyLista
        lResult = Datos.TareoOS.Consultar_Tareo_OT_Personal(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function

    Public Function Mantenedor_TareoEquipo(ByVal Entidad As ETTareoOS) As Integer
        Dim lResult As ETTareoOS = Nothing
        Dim Status As String = String.Empty
        Dim Horas As Double = 0
        Dim Mensaje1, Mensaje2 As String
        If Entidad Is Nothing Then
            Return Nothing
        End If
        If Entidad.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Entidad.Cod_TareosOS & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If


Ingreso:

        lResult = New ETTareoOS

        If Entidad.Tipo = 3 Then
            GoTo Operacion
        End If

        Try

            If String.IsNullOrEmpty(Entidad.Codigo) Then
                MsgBox("Seleccione el Equipo que Trabajo en la O/T", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            If Entidad.Recurso <= 0 Then
                MsgBox("Seleccione el Equipo que Trabajo en la O/T", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            If Entidad.OrdenTrabajo <= 0 Then
                MsgBox("Seleccione la O/T a Tarear", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If


            If Entidad.Fecha > Entidad.FechaTerminacion Or Entidad.Fecha < Entidad.FechaInicio Then
                MsgBox("La Fecha de Tareo no esta dentro del rango de la O/T", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If


            Dim ObjOT As New ETOrdenTrabajo_Mantto
            ObjOT.OrdenTrabajo = Entidad.OrdenTrabajo

            Status = Datos.OrdenTrabajo_Mantto.Obtener_OrdenTrabajo_Estado(ObjOT)

            If Status = "*" Then
                MsgBox("La Orden de Trabajo esta Anulada", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            ElseIf Not (Status = "P") Then
                MsgBox("No se puede Actualizar el Costo proque el Trabajo ya Concluyó", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            Horas = Datos.TareoOS.Obtener_Horas_Trabajas_Equipo_Fecha(Entidad)

            If (Entidad.Horas + Horas) > 24 Then
                MsgBox("Excedió el limite permitido de horas diarias a trabajar", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If


        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return Nothing

        End Try

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return Nothing
        Else
            lResult = Datos.TareoOS.Mantenedor_TareosOT_Equipo(Entidad)

        End If
Salida:

        If lResult.Validacion Then
            If Entidad.Tipo = 1 Then
                Mensaje2 = "Se generó el Codigo: " & lResult.Codigo
                MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            Else
                MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            End If

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta
    End Function

    Public Function Consultar_TareoOSEquipo(ByVal Entidad As ETTareoOS) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing
        lResult = New ETMyLista
        lResult = Datos.TareoOS.Consultar_Tareo_OT_Equipo(Entidad)
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
