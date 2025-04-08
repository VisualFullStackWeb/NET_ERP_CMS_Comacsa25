Imports SIP_Entidad
Imports SIP_Datos
Public Class NGLineaNegocio
    Public Function Mantto_LineaNegocio(ByVal Entidad As ETLineaNegocio) As Integer

        Dim lResult As ETLineaNegocio = Nothing
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

        lResult = New ETLineaNegocio

        If Entidad.Tipo = 3 Then GoTo Operacion

        Try

            If String.IsNullOrEmpty(Entidad.Codigo) Then
                MsgBox("Ingrese el Código de la Linea de Negocio", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If String.IsNullOrEmpty(Entidad.Descripcion) Then
                MsgBox("Ingrese la Descripcion de la Linea de Negocio", MsgBoxStyle.Exclamation, msgComacsa)
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
            'Datos.LineaNegocio = New DALineaNegocio
            lResult.Respuesta = Datos.LineaNegocio.ManttoLineaNegocio(Entidad)
        End If
Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta

    End Function

    Public Function ConsultarLineaNegocio() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.LineaNegocio.ConsultarLinNeg

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ConsultarLineaNegocio_Activos() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.LineaNegocio.ConsultarLinNeg_Activos

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
