Imports SIP_Entidad
Imports SIP_Datos

Public Class NGPeriodoGasNatural
    Public Function Mantenedor_PeriodoGasNatural(ByVal Periodo As ETPeriodo, _
                                                    ByVal Gas_Equipo As List(Of ETCosteoActivo), _
                                                    ByVal Gas_Equipo_Anul As List(Of ETCosteoActivo), _
                                                    ByVal Gas_LineaProduccion As List(Of ETLineaNegocio)) As Integer
        Dim lResult As Long = 0
        Dim Mensaje1, Mensaje2 As String
        Dim Porcentaje As Double = 0
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

        If Val(Periodo.ValorPeriodo) <= 0 Then
            MsgBox("El Consumo Mensual debe ser mayor a cero", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If

        If Val(Periodo.Valor2) <= 0 Then
            MsgBox("El Consumo de los Equipos debe ser mayor a cero", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If


        If Periodo.Tipo = 3 Then
            GoTo Operacion
        Else

            If Val(Periodo.ValorPeriodo) < Val(Periodo.Valor2) Then
                MsgBox("El Consumo de los Equipos Excede el Consumo Mensual ", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0

            ElseIf Val(Periodo.ValorPeriodo) > Val(Periodo.Valor2) Then
                For Each xRow As ETLineaNegocio In Gas_LineaProduccion
                    Porcentaje = Porcentaje + xRow.Porcentaje
                Next

                If Porcentaje > 100 Then
                    MsgBox("La sumatoria del Porcentaje de las Lineas de Producción excedió al 100%", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                ElseIf Porcentaje < 100 Then
                    MsgBox("la sumatoria del Porcentaje de las Lineas de Producción excedió al 100%", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                End If
            Else
                Gas_LineaProduccion = New List(Of ETLineaNegocio)

            End If



            If Datos.Periodo.Validar_Periodo(Periodo) Then
                MsgBox("El Periodo ya fue creado", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If
        End If

        If (Gas_Equipo.Count) = 0 Then
            MsgBox("Debe agregar el consumo de los Equipos", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            lResult = Datos.PeriodoGasNatural.Mantto_Periodo_GasNatural(Periodo, Gas_Equipo, Gas_Equipo_Anul, Gas_LineaProduccion)

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

    Public Function Consultar_PeriodoGasNatural(ByVal Periodo As ETPeriodo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        If Periodo Is Nothing Then Return lResult

        lResult = New ETMyLista
        lResult = Datos.PeriodoGasNatural.Consultar_PeriodoGasNatural(Periodo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function Consultar_PeriodoGasNaturalLineaProduccion(ByVal Periodo As ETPeriodo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        If Periodo Is Nothing Then Return lResult

        lResult = New ETMyLista
        lResult = Datos.PeriodoGasNatural.Consultar_PeriodoGasNatural_LinProd(Periodo)

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
