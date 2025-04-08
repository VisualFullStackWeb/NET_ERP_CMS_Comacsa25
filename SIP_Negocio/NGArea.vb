Imports SIP_Entidad
Imports SIP_Datos

Public Class NGArea
    Public Function Consultar_Area(ByVal Ent_Area As ETArea) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Ent_Area Is Nothing Then
            Return Nothing
        End If
        lResult = New ETMyLista
        lResult = Datos.Area.Consulta_Area(Ent_Area)
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
