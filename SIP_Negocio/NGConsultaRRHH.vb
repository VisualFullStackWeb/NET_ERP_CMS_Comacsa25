Imports SIP_Entidad
Imports SIP_Datos
Public Class NGConsultaRRHH
    Public Function Consultar_CtaCorrientePersonal(ByVal Empleado As String, ByVal Anio As Integer) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.ConsultasRRHH.ConsultarCuentaCorrientePersonal(Empleado, Anio)

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
