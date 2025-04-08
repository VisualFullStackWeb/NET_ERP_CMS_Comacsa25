Imports SIP_Entidad
Imports SIP_Datos
Public Class NGGlosa
    Public Function Mantto_Glosa(ByVal Entidad As ETGlosa) As Integer

        Dim lResult As ETGlosa = Nothing
        Dim EntValidar As ETGlosa = Nothing
        Dim Mensaje1, Mensaje2 As String
        If Entidad Is Nothing Then
            Return 0
        End If
        If Entidad.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Entidad.ID & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If

Ingreso:

        lResult = New ETGlosa

        If Entidad.Tipo = 3 Then

            EntValidar = New ETGlosa
            EntValidar.ID = Val(Entidad.ID)
            EntValidar.Tipo = 5

            If Datos.Glosa.ValidarAnulacionGlosa(EntValidar) > 0 Then
                MsgBox("La Glosa: " & Entidad.ID & " esta relacionada con uno o más Costos de Autorización/Tramite Doc.", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            GoTo Operacion

        End If


        Try
            If String.IsNullOrEmpty(Entidad.Cod_Sistema) Then
                MsgBox("Seleccione el Sistema", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If String.IsNullOrEmpty(Entidad.Cod_Grupo) Then
                MsgBox("Seleccione el Grupo", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If Val(Entidad.Cod_Modulo) <= 0 Then
                MsgBox("Seleccione el Módulo de la Glosa", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If String.IsNullOrEmpty(Entidad.Glosa) Then
                MsgBox("Ingrese la Glosa", MsgBoxStyle.Exclamation, msgComacsa)
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
            lResult.ID = Datos.Glosa.ManttoGlosa(Entidad)
        End If
Salida:

        If Val(lResult.ID) > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
        End If

        Return Val(lResult.ID)

    End Function

    Public Function ConsultarGlosa(ByVal Formulario As ETGlosa) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Glosa.ConsultarGlosa(Formulario)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarGlosaFormulario(ByVal Formulario As ETGlosa) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Glosa.ConsultarGlosaFormulario(Formulario)

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
