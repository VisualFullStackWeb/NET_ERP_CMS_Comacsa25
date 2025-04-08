Imports SIP_Entidad
Imports SIP_Datos

Public Class NGPartidaMaterial
    Public Function Mantenedor_Material(ByVal Lista As List(Of ETPartidaMaterial), ByVal List_Del As List(Of ETPartidaMaterial)) As Integer
        Dim lResult As ETPartidaMaterial = Nothing
        Dim Mensaje1, Mensaje2 As String
        If Lista Is Nothing Then
            Return 0
        End If

        If List_Del Is Nothing Then
            Return 0
        End If

        Mensaje1 = "¿Seguro desea Guardar los cambios?"
        Mensaje2 = "Se Guardaron Correctamente los Datos"

Ingreso:

        lResult = New ETPartidaMaterial

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            If List_Del.Count > 0 Then
                lResult.Respuesta = Datos.Partida_Material.Mantenedor_Part_Material(List_Del)
            End If
            If Lista.Count > 0 Then
                lResult.Respuesta = lResult.Respuesta + Datos.Partida_Material.Mantenedor_Part_Material(Lista)
            End If
        End If
Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta
    End Function

    Public Function ConsultarListaMaterial() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Partida_Material.Consultar_Lista_Material

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
