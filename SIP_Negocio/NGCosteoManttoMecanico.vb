Imports SIP_Entidad
Imports SIP_Datos
Public Class NGCosteoManttoMecanico
    Public Function Mantenedor_CosteoManttoMecanico(ByVal Periodo As ETCosteoManttoMecanico, _
                                                     ByVal ListaDetalle As List(Of ETCosteoManttoMecanicoDetalle), _
                                                     ByVal Ls_Anular As List(Of ETCosteoManttoMecanicoDetalle)) As Integer
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

        If Periodo.Tipo = 1 Then
            If Datos.CosteoManttoMecanico.Validar_Costeo_ManttoMecanico(Periodo) Then
                MsgBox("El Periodo del Costo del Mantenimiento Mecánico ya fue creado", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If
        End If

        If Periodo.Tipo = 3 Then
            GoTo Operacion
        End If

        If Periodo.Horas < 0 Then
            MsgBox("Las Horas Hombre deben ser mayor a Cero", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If

        If Periodo.CostoManoObra < 0 Then
            MsgBox("Error: El Costo de Mano de Obra es Negativo", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If

        If Periodo.CostoMateriales < 0 Then
            MsgBox("Error: El Costo de Materiales es Negativo", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If

        If Periodo.Total <= 0 Then
            MsgBox("El Costo del Mantenimiento debe ser mayor a Cero", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If
        If (ListaDetalle.Count) = 0 Then
            MsgBox("No hay detalle del Costo de Mantenimiento Mecánico", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            lResult = Datos.CosteoManttoMecanico.Mantenedor_Costeo_ManttoMecanico(Periodo, ListaDetalle, Ls_Anular)

        End If

Salida:

        If lResult > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
        End If

        Return lResult
    End Function

    Public Function Consultar_CosteoManttoMecanico() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CosteoManttoMecanico.Consultar_Costeo_ManttoMecanico

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function Consultar_CosteoManttoMecanicoDetalle(ByVal Periodo As ETCosteoManttoMecanico) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        If Periodo Is Nothing Then Return lResult

        lResult = New ETMyLista
        lResult = Datos.CosteoManttoMecanico.Consultar_Costeo_ManttoMecanicoDetalle(Periodo)

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
