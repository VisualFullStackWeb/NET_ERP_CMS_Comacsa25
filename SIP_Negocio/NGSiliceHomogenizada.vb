Imports SIP_Entidad
Imports SIP_Datos
Public Class NGSiliceHomogenizada
    Public Function MantenedorSiliceHomogenizada(ByVal Periodo As ETPeriodo) As Boolean
        Dim lResult As Long = 0
        Dim Mensaje1, Mensaje2 As String

        If Periodo Is Nothing Then
            Return 0
        End If

        If Periodo.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Periodo.Anio & " - " & Periodo.MesName & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If


Ingreso:

        If Periodo.Anio <= 0 Then
            MsgBox("Ingrese un Año Valido", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If

        If Val(Periodo.Mes) = 0 Then
            MsgBox("Seleccione un Mes Valido", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If

        If Val(Periodo.ValorPeriodo) = 0 Then
            MsgBox("Debe Ingresar los Costos x TON", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If

        If Periodo.Tipo = 3 Then
            GoTo Operacion
        Else
            If Datos.Periodo.Validar_Periodo(Periodo) Then
                MsgBox("El Periodo ya fue creado", MsgBoxStyle.Exclamation, msgComacsa)
                Return False
            End If
        End If
Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return False
        Else
            lResult = Datos.Periodo.Mantenedor_Periodo(Periodo)
        End If

Salida:

        If lResult = True Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
        End If

        Return lResult
    End Function

    Public Function ConsultarSiliceHomogenizada(ByVal Periodo As ETPeriodo) As ETMyLista
        If Periodo Is Nothing Then
            Return Nothing
        Else
            Return Datos.Periodo.Consultar_Periodo(Periodo)
        End If

    End Function
End Class
