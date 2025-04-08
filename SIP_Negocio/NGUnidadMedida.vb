Imports SIP_Entidad
Imports SIP_Datos
Public Class NGUnidadMedida
    Public Function ConsultarUnidadMedida() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.UnidadMedida.ConsultarUnidadMedida()

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
