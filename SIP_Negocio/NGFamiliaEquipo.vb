Imports SIP_Entidad
Imports SIP_Datos
Public Class NGFamiliaEquipo
    Public Function Mantto_FamiliaEquipo(ByVal Entidad As ETFamiliaEquipo) As Integer

        Dim lResult As ETFamiliaEquipo = Nothing
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

        lResult = New ETFamiliaEquipo

        If Entidad.Tipo = 3 Then
            GoTo Operacion
        End If

        Try

            If String.IsNullOrEmpty(Entidad.Descripcion) Then
                MsgBox("Ingrese la Descripcion del Componente", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If Entidad.ExisteImage = Boolean.FalseString And Entidad.Tipo = 1 Then
                MsgBox("Debe Seleccionar una Foto Predeterminada del Equipo", MsgBoxStyle.Exclamation, msgComacsa)
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
            If Entidad.ExisteImage = Boolean.FalseString Then
                lResult.Respuesta = Datos.FamiliaEquipo.ManttoFamiliaEquipo(Entidad)
            Else
                lResult.Respuesta = Datos.FamiliaEquipo.Mantto_FamiliaEquipo_Image(Entidad)
            End If
        End If
Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta

    End Function

    Public Function ConsultarFamiliaEquipo() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.FamiliaEquipo.ConsultarFamiliaEq()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarFamiliaEquipo_Enlazar() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.FamiliaEquipo.ConsultarFamiliaEq_Enlazar

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function ConsultarFamiliaEquipo_Todos() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.FamiliaEquipo.ConsultarFamiliaEq_Todos

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function Mantto_SubParteEquipo(ByVal ListaxSubParteEq As List(Of ETParteEquipo)) As Integer

        Dim lResult As ETParteEquipo = Nothing
        Dim Mensaje1, Mensaje2 As String
        If ListaxSubParteEq Is Nothing Then
            Return 0
        End If

        Mensaje1 = "¿Seguro desea Guardar los cambios?"
        Mensaje2 = "Se Guardaron Correctamente los Datos"
Ingreso:

        lResult = New ETParteEquipo


Operacion:

        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            lResult.Respuesta = Datos.ParteEquipo.ManttoSubParteEquipo(ListaxSubParteEq)

        End If

Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta

    End Function

End Class
