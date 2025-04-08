Imports SIP_Entidad
Imports SIP_Datos
Public Class NGPersonal_LinProd
    Public Function Mantenedor_Personal_LinProd(ByVal Periodo As ETPeriodo, _
                                                     ByVal ListaDetalle As List(Of ETPersonalLineaProduccion), _
                                                     ByVal Ls_Anular As List(Of ETPersonalLineaProduccion)) As Integer
        Dim lResult As Long = 0
        Dim Mensaje1, Mensaje2 As String
        If Periodo Is Nothing Then
            Return 0
        End If
        If Periodo.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Periodo.Anio & " - " & Periodo.MesName & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If
Ingreso:

        If Periodo.Anio <= 0 Then
            MsgBox("Ingrese un Año Valido", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If

        If Val(Periodo.Mes) = 0 Then
            MsgBox("Seleccione un Mes Valido", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If

        If Periodo.Tipo = 3 Then
            GoTo Operacion
        Else

            If Datos.Periodo.Validar_Periodo(Periodo) Then
                MsgBox("El Periodo ya fue creado", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If
        End If

        If (ListaDetalle.Count) = 0 Then
            MsgBox("No sea distribuido el Costo del Personal según la Linea de Producción", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            lResult = Datos.Personal_LinProd.Mantto_Personal_LineaProd(Periodo, ListaDetalle, Ls_Anular)

        End If

Salida:

        If lResult > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
        End If

        Return lResult
    End Function

    Public Function Consultar_Periodo(ByVal Periodo As ETPeriodo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Periodo.Consultar_Periodo(Periodo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function Consultar_PersonalLinProd(ByVal Periodo As ETPeriodo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        If Periodo Is Nothing Then Return lResult

        lResult = New ETMyLista
        lResult = Datos.Personal_LinProd.Consultar_Personal_LinProd(Periodo)

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
