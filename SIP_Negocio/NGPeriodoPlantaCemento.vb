Imports SIP_Entidad
Imports SIP_Datos
Public Class NGPeriodoPlantaCemento
    Public Function Mantenedor_PeriodoPlantaCemento(ByVal Periodo As ETPeriodo, _
                                        ByVal PC_UnidadProd As List(Of ETActivo), _
                                        ByVal PC_UnidadProd_Del As List(Of ETActivo), _
                                        ByVal PC_Mineral As List(Of ETProducto), _
                                        ByVal PC_Mineral_Del As List(Of ETProducto), _
                                        ByVal PC_Suministro As List(Of ETProducto), _
                                        ByVal PC_Suministro_Del As List(Of ETProducto), _
                                        ByVal PC_ManoObra As List(Of ETPersonal), _
                                        ByVal PC_ManoObra_Del As List(Of ETPersonal)) As Integer
        Dim lResult As Long = 0
        Dim Mensaje1, Mensaje2 As String
        Dim Porcentaje As Double = 0
        Dim Contar As Integer = 0
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
        ElseIf Datos.Periodo.Validar_Periodo(Periodo) Then
            MsgBox("El Periodo ya fue creado", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If

        If Not (Periodo.Tipo = 7) Then
            If (PC_UnidadProd.Count) <= 0 Then
                MsgBox("Debe agregar las Unidades de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            For Each xRow As ETActivo In PC_UnidadProd
                Contar = 0
                For Each mRow As ETProducto In PC_Mineral
                    If xRow.Codigo.Trim = mRow.CodPlanta.Trim Then
                        Contar = Contar + 1
                    End If
                Next

                'If Contar = 0 Then
                '    MsgBox("Debe Agregar los Minerales de la Unidad de Produccion:" & xRow.Codigo.Trim & " - " & xRow.Descripcion, MsgBoxStyle.Critical, msgComacsa)
                '    Return 0
                'End If

                Contar = 0
                For Each mRow As ETPersonal In PC_ManoObra
                    If xRow.Codigo.Trim = mRow.Cargo.Trim Then
                        Contar = Contar + 1
                    End If
                Next

                If Contar = 0 Then
                    MsgBox("Debe Agregar el Personal de la Unidad de Produccion:" & xRow.Codigo.Trim & " - " & xRow.Descripcion, MsgBoxStyle.Critical, msgComacsa)
                    Return 0
                End If
            Next
        End If
       

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            lResult = Datos.PeriodoPlantaCemento.Mantto_Periodo_PlantaCemento(Periodo, PC_UnidadProd, PC_UnidadProd_Del, PC_Mineral, PC_Mineral_Del, PC_Suministro, PC_Suministro_Del, PC_ManoObra, PC_ManoObra_Del)
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

    Public Function Consultar_PeriodoPlantaCemento_UnidadProduccion(ByVal Periodo As ETPeriodo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        If Periodo Is Nothing Then Return lResult

        lResult = New ETMyLista
        lResult = Datos.PeriodoPlantaCemento.Consultar_Periodo_UnidadProduccion(Periodo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function Consultar_PeriodoPlantaCemento_Minerales(ByVal Periodo As ETPeriodo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        If Periodo Is Nothing Then Return lResult

        lResult = New ETMyLista
        lResult = Datos.PeriodoPlantaCemento.Consultar_Periodo_Minerales(Periodo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function Consultar_PeriodoPlantaCemento_Suministro(ByVal Periodo As ETPeriodo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        If Periodo Is Nothing Then Return lResult

        lResult = New ETMyLista
        lResult = Datos.PeriodoPlantaCemento.Consultar_Periodo_Suministros(Periodo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function Consultar_PeriodoPlantaCemento_ManoObra(ByVal Periodo As ETPeriodo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        If Periodo Is Nothing Then Return lResult

        lResult = New ETMyLista
        lResult = Datos.PeriodoPlantaCemento.Consultar_Periodo_ManoObra(Periodo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function Consultar_PeriodoPlantaCemento_Otros(ByVal UnidadProduccion As ETCosteoActivo) As Double
        Dim lResult As Double = 0

        If UnidadProduccion Is Nothing Then Return lResult
        lResult = Datos.PeriodoPlantaCemento.Consultar_Periodo_OtrosCostos(UnidadProduccion)
        Return lResult

    End Function


End Class
