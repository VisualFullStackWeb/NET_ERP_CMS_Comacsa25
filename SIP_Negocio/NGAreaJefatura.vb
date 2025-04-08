Imports SIP_Entidad
Imports SIP_Datos

Public Class NGAreaJefatura
    Public Function Consultar_AreaJefetura_Activa(ByVal Ent_Area As ETAreaJefatura) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Ent_Area Is Nothing Then
            Return Nothing
        End If
        lResult = New ETMyLista
        lResult = Datos.AreaJefactura.Consultar_AreaJetatura_Activa(Ent_Area)
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
