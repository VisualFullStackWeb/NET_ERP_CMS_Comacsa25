Imports SIP_Datos
Imports SIP_Entidad

Public Class NGRequerimiento_Mantto
    Public Function Mantenimiento_Requerimiento(ByVal EntReq As ETRequerimiento_Mantto, ByVal Ls_ReqDet As List(Of ETRequerimiento_ManttoDetalle), ByVal Ls_ReqDet_Anulado As List(Of ETRequerimiento_ManttoDetalle)) As String
        Dim Codigo As String = String.Empty
        Dim Nro As String = String.Empty
        Dim Mensaje1, Mensaje2 As String
        If EntReq Is Nothing Then
            Return ""
        End If
        If EntReq.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & EntReq.Codigo & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If


Ingreso:

        If EntReq.Tipo = 3 Then
            GoTo Operacion
        End If

        Try

            If String.IsNullOrEmpty(EntReq.CodArea) Then
                MsgBox("Seleccione el Área Socilitante", MsgBoxStyle.Exclamation, msgComacsa)
                Return ""
            End If

            If String.IsNullOrEmpty(EntReq.SolicitanteID) Then
                MsgBox("Seleccione al Socilitante", MsgBoxStyle.Exclamation, msgComacsa)
                Return ""
            End If

            If String.IsNullOrEmpty(EntReq.DirigidoID) Then
                MsgBox("Seleccione a quien va dirigido el Requerimiento", MsgBoxStyle.Exclamation, msgComacsa)
                Return ""
            End If

            If String.IsNullOrEmpty(EntReq.Asunto) Then
                MsgBox("Ingrese el Asunto de Requerimiento", MsgBoxStyle.Exclamation, msgComacsa)
                Return ""
            End If

            If Ls_ReqDet.Count <= 0 Then
                MsgBox("El Requerimiento no cuenta con detalle", MsgBoxStyle.Exclamation, msgComacsa)
                Return ""
            End If


        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return ""

        End Try

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return ""
        Else
            Codigo = EntReq.Area & Space(2)
            Nro = Datos.Requerimiento_Mantto.Mantenedor_Requerimiento(EntReq, Ls_ReqDet, Ls_ReqDet_Anulado)
            If Nro = "" Then
                Codigo = ""
            Else
                Codigo = Codigo & Nro
            End If
        End If
Salida:

        Return Codigo
    End Function
    Public Function ConsultarRequerimiento() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        lResult = Datos.Requerimiento_Mantto.Consultar_Requerimiento
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function
    Public Function ConsultarRequerimiento_Pendientes_Programacion() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        lResult = Datos.Requerimiento_Mantto.Consultar_Requerimiento_Activo_Programar
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function
    Public Function ConsultarRequerimiento_Det(ByVal EntReq As ETRequerimiento_Mantto) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        lResult = Datos.Requerimiento_Mantto.Consultar_Requerimiento_Det(EntReq)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function
    Public Function Consultar_Equipos_Programar(ByVal EntReq As ETRequerimiento_ManttoDetalle) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        lResult = Datos.Requerimiento_Mantto.Consultar_Req_Equipo_Activo_Programar(EntReq)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function

    Public Function Consultar_Requerimiento_OT(ByVal EntReq As ETRequerimiento_ManttoDetalle) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        lResult = Datos.Requerimiento_Mantto.Consultar_Requerimiento_OT(EntReq)
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
