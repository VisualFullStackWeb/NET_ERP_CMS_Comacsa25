Imports SIP_Entidad
Imports SIP_Datos
Public Class NGCheckList
    Public Function Mantto_CheckList(ByVal EntCL As ETCheckList, ByVal Ls_Detalle_CL As List(Of ETCheckListDetalle)) As Integer

        Dim lResult As ETCheckList = Nothing

        Dim Mensaje1, Mensaje2 As String
        If EntCL Is Nothing Then
            Return 0
        End If
        If EntCL.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & EntCL.Codigo & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If


Ingreso:

        lResult = New ETCheckList

        If EntCL.Tipo = 3 Then
            GoTo Operacion
        End If

        Try

            If String.IsNullOrEmpty(EntCL.ResponsableID) Then
                MsgBox("Seleccione al Responsable del Check List", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            'If String.IsNullOrEmpty(EntCL.TipoChL) Then
            'MsgBox("Seleccione el Tipo de Check List", MsgBoxStyle.Exclamation, msgComacsa)
            'Return 0
            'End If


            If Val(EntCL.EquipoID) = 0 Then
                MsgBox("Seleccione el Equipo", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If EntCL.AtribOb = Boolean.TrueString Then
                If String.IsNullOrEmpty(EntCL.Valor) Then
                    MsgBox("Ingrese el Valor del Atributo Control", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                End If
            End If

            If Ls_Detalle_CL.Count <= 0 Then
                MsgBox("El Check List no cuenta con detalle", MsgBoxStyle.Exclamation, msgComacsa)
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
            lResult.Respuesta = Datos.CheckList.Mantto_CheckList(EntCL, Ls_Detalle_CL)

        End If
Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta

    End Function

    Public Function ConsultarDetalleCheckList(ByVal EntCL As ETCheckList) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If EntCL Is Nothing Then
            Return Nothing
        End If

        lResult = New ETMyLista
        lResult = Datos.CheckList.Consultar_DetalleCheckList(EntCL)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ConsultarCheckList() As ETMyLista
        Dim lResult As ETMyLista = Nothing


        lResult = New ETMyLista
        lResult = Datos.CheckList.Consultar_CheckList

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function ConsultarCheckList_Equipo(ByVal Ent_CheckList As ETCheckList) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Ent_CheckList Is Nothing Then
            Return lResult
            Exit Function
        End If

        lResult = New ETMyLista
        lResult = Datos.CheckList.Consultar_CheckList_Equipo(Ent_CheckList)

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
