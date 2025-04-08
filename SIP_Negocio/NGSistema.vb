Imports SIP_Entidad
Imports SIP_Datos
Public Class NGSistema
    Public Function Mantto_Sistema(ByVal System As ETSistema, ByVal Grupo As List(Of ETSistema)) As Integer

        Dim lResult As Integer
        Dim i As Integer = 0
        Dim Mensaje1, Mensaje2 As String
        If System Is Nothing Then
            Return 0
        End If
        If System.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & System.ID & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If


Ingreso:

        lResult = 0

        If System.Tipo = 3 Then
            GoTo Operacion
        End If

        Try

            If String.IsNullOrEmpty(System.Sistema) Then
                MsgBox("Seleccione al Responsable del Check List", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            For Each xRow As ETSistema In Grupo
                If xRow.Action = True Then
                    i = i + 1
                End If
            Next

            If i = 0 Then
                MsgBox("Al menos checkee un Grupo que tendrá el Sistema", MsgBoxStyle.Exclamation, msgComacsa)
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
            lResult = Datos.Sistema.Mantenedor_Sistemas(System, Grupo)

        End If
Salida:

        If lResult > 0 Then
            If System.Tipo = 1 Then
                Mensaje2 = "Se creó el Sistema con ID: " & lResult.ToString
            End If
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
        End If

        Return lResult

    End Function

    Public Function Consultar_Sistema() As ETMyLista
        Dim lResult As ETMyLista = Nothing


        lResult = New ETMyLista
        lResult = Datos.Sistema.Consultar_Sistemas

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_SistemaDT() As DataTable
        Dim lResult As DataTable = Nothing


        lResult = New DataTable
        lResult = Datos.Sistema.Consultar_SistemaDT

        'If lResult Is Nothing Then
        '    lResult = New DataTable
        'Else
        '    If Not lResult.Validacion Then
        '        MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
        '    End If
        'End If

        Return lResult
    End Function

    Public Function Consultar_Sistema_Grupos(ByVal System As ETSistema) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If System Is Nothing Then
            Return Nothing
        End If

        lResult = New ETMyLista
        lResult = Datos.Sistema.Consultar_Sistemas_Grupos(System)

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
