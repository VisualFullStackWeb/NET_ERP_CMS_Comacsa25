Imports SIP_Entidad
Imports SIP_Datos
Public Class NGAtributo
    Public Function Mantto_Atributo(ByVal Entidad As ETAtributo) As Integer

        Dim lResult As ETAtributo = Nothing
        Dim EntValidar As ETAtributo = Nothing
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

        lResult = New ETAtributo

        If Entidad.Tipo = 3 Then

            EntValidar = New ETAtributo
            EntValidar.IDCatalogo = Entidad.IDCatalogo
            EntValidar.Tipo = 6

            If Datos.Atributo.ExisteAtributo(EntValidar) Then
                MsgBox("El Atributo: " & Entidad.Descripcion & " esta relacionado con los Componentes o la Familia de Equipos", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            GoTo Operacion

        End If


        Try

            If String.IsNullOrEmpty(Entidad.Descripcion) Then
                MsgBox("Ingrese la Descripcion de la Linea de Negocio", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If String.IsNullOrEmpty(Entidad.UniMed) Then
                MsgBox("Seleccione la Unidad de Medida", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If String.IsNullOrEmpty(Entidad.TipoDato) Then
                MsgBox("Seleccione el Tipo de Dato", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If Not (Val(Entidad.TipoDato) = 4 Or Val(Entidad.TipoDato) = 5) = Boolean.TrueString Then
                If Not IsNumeric(Entidad.Longitud) Then
                    MsgBox("Ingrese un valor numérico en el campo Longitud", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                ElseIf Val(Entidad.Longitud) > 255 Then
                    MsgBox("Longitud: Ingrese un Valor menor o igual a 255", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                ElseIf Val(Entidad.Longitud) <= 0 Then
                    MsgBox("Longitud: Ingrese un Valor mayor cero", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                End If
            End If


            If Val(Entidad.TipoDato) = 3 Then
                If Not IsNumeric(Entidad.Decimales) Then
                    MsgBox("Ingrese un valor numérico en el campo Decimales", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                ElseIf Val(Entidad.Decimales) > 255 Then
                    MsgBox("Decimal: Ingrese un Valor menor o igual a 255", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                ElseIf Val(Entidad.Decimales) <= 0 Then
                    MsgBox("Decimal: Ingrese un Valor mayor cero", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                ElseIf Val(Entidad.Longitud) < Val(Entidad.Decimales) Then
                    MsgBox("El Número de Decimales debe ser menor a la longitud", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                End If
            End If

            EntValidar = New ETAtributo
            EntValidar.IDCatalogo = Entidad.IDCatalogo
            EntValidar.Descripcion = Entidad.Descripcion
            EntValidar.Tipo = 5

            If Datos.Atributo.ExisteAtributo(EntValidar) Then
                MsgBox("El Atributo: " & Entidad.Descripcion & " ya existe", MsgBoxStyle.Exclamation, msgComacsa)
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
            lResult.Respuesta = Datos.Atributo.ManttoAtributo(Entidad)
        End If
Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta

    End Function

    Public Function ConsultarAtributo() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Atributo.ConsultarAtributo

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function Mantto_AtributoParteEquipo(ByVal ListaxAtributoParteEq As List(Of ETAtributo)) As Integer

        Dim lResult As ETAtributo = Nothing

        Dim Mensaje1, Mensaje2 As String
        If ListaxAtributoParteEq Is Nothing Then
            Return 0
        End If

        Mensaje1 = "¿Seguro desea Guardar los cambios?"
        Mensaje2 = "Se Guardaron Correctamente los Datos"
Ingreso:

        lResult = New ETAtributo


Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            lResult.Respuesta = Datos.Atributo.ManttoAtributoParteEquipo(ListaxAtributoParteEq)
        End If


Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta

    End Function

    Public Function ConsultarAtributoParteEquipo(ByVal EntAtributo As ETAtributo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Atributo.ConsultarAtributoParteEq(EntAtributo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function Mantto_AtributoFamiliaEquipo(ByVal ListaxAtributoFamiliaEq As List(Of ETAtributo)) As Integer

        Dim lResult As ETAtributo = Nothing

        Dim Mensaje1, Mensaje2 As String
        If ListaxAtributoFamiliaEq Is Nothing Then
            Return 0
        End If

        Mensaje1 = "¿Seguro desea Guardar los cambios?"
        Mensaje2 = "Se Guardaron Correctamente los Datos"
Ingreso:

        lResult = New ETAtributo


Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            lResult.Respuesta = Datos.Atributo.ManttoAtributoFamiliaEquipo(ListaxAtributoFamiliaEq)
        End If


Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta

    End Function

    Public Function ConsultarAtributoFamiliaEquipo(ByVal EntAtributo As ETAtributo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Atributo.ConsultarAtributoFamiliaEq(EntAtributo)

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
