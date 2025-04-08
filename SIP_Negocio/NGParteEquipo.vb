Imports SIP_Entidad
Imports SIP_Datos
Public Class NGParteEquipo
    Public Function Mantto_ParteEquipo(ByVal Entidad As ETParteEquipo) As Integer

        Dim lResult As ETParteEquipo = Nothing
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

        lResult = New ETParteEquipo

        If Entidad.Tipo = 3 Then
            GoTo Operacion
        ElseIf Entidad.Tipo = 8 Then
            GoTo Salto
        End If

        Try

            If String.IsNullOrEmpty(Entidad.Descripcion) Then
                MsgBox("Ingrese la Descripcion del Componente", MsgBoxStyle.Exclamation, msgComacsa)
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
Salto:
            lResult.Respuesta = Datos.ParteEquipo.ManttoParteEquipo(Entidad)
        End If
Salida:

        If lResult.Respuesta > 0 Then
            If Entidad.Tipo <> 8 Then MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta

    End Function

    Public Function ConsultarParteEquipo(ByVal EntParteEq As ETParteEquipo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.ParteEquipo.ConsultarParteEq(EntParteEq)

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
    Public Function Validar_Circularidad_SubComponente(ByVal Entidad As ETParteEquipo) As Boolean
        Return Datos.ParteEquipo.Validar_Circularidad_Comp_SubComp(Entidad)
    End Function

    Public Function Consultar_FamiliaEq_ParteEquipo(ByVal EntParteEq As ETParteEquipo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.ParteEquipo.Consultar_FamiliaParteEq(EntParteEq)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function Mantto_FamiliaEq_ParteEquipo(ByVal ListaxFamiliaEqParteEq As List(Of ETParteEquipo)) As Integer

        Dim lResult As ETParteEquipo = Nothing
        Dim Mensaje1, Mensaje2 As String
        If ListaxFamiliaEqParteEq Is Nothing Then
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
            lResult.Respuesta = Datos.ParteEquipo.Mantto_FamiliaEq_ParteEquipo(ListaxFamiliaEqParteEq)

        End If

Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta

    End Function
End Class
