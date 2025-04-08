Imports SIP_Entidad
Imports SIP_Datos
Public Class NGCosteoProduccion
    Public Function Consultar_Produccion(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Tonelaje(Producto)
    End Function

    Public Function Consultar_Produccion_Neto(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_CostoNeto(Producto)
    End Function

    Public Function Consultar_Produccion_General(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_General(Producto)
    End Function

    Public Function Consultar_Produccion_GasNatural(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_GasNatural(Producto)
    End Function

    Public Function Consultar_Produccion_Envases(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Suministro(Producto)
    End Function

    Public Function Consultar_Produccion_Depreciacion(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Depreciacion(Producto)
    End Function

    Public Function Consultar_Produccion_Depreciacion_Normal(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Depreciacion_Normal(Producto)
    End Function

    Public Function Consultar_Produccion_Pala_Depreciacion(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Pala_Depreciacion(Producto)
    End Function

    Public Function Consultar_Produccion_Pala_Alquiler_Mantto(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Pala_Alquiler_Mantto(Producto)
    End Function

    Public Function Consultar_Produccion_Mantto_Mecanico(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_ManttoMecanico(Producto)
    End Function

    Public Function Consultar_Produccion_Mantto_Mecanico_Normal(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_ManttoMecanicoNormal(Producto)
    End Function

    Public Function Consultar_Produccion_ManoObra(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_ManoObra(Producto)
    End Function

    Public Function Consultar_Produccion_Chancadora_ManoObra(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_ManoObra(Producto)
    End Function

    Public Function Consultar_Produccion_Chancadora_ManoObra_Normal(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_ManoObra_Normal(Producto)
    End Function

    Public Function Consultar_Produccion_Pala_ManoObra(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Pala_ManoObra(Producto)
    End Function

    Public Function Consultar_Produccion_Ruma(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Ruma(Producto)
    End Function

    Public Function Consultar_Produccion_Silice(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Silice(Producto)
    End Function


    Public Function Consultar_Produccion_Chancadora_TranspInt(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_TranspInt(Producto)
    End Function

    Public Function Consultar_Produccion_Chancadora_ManttoMecanico(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_ManttoMecanico(Producto)
    End Function

    Public Function Consultar_Produccion_Chancadora_Depreciacion(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_Depreciacion(Producto)
    End Function

    Public Function Consultar_Produccion_Chancadora_Energia(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_Energia(Producto)
    End Function

    Public Function Consultar_Produccion_Chancadora(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora(Producto)
    End Function

    Public Function Consultar_Produccion_Pala(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Pala(Producto)
    End Function

    Public Function Consultar_Produccion_Pala_Combustible(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Pala_Combustible(Producto)
    End Function

    Public Function Consultar_Produccion_Energia(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Energia(Producto)
    End Function

    Public Function Consultar_Produccion_PrecioVenta(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_PrecioVenta(Producto)
    End Function

    Public Function Consultar_Spid() As Integer
        Return Datos.CosteoProduccion.Consultar_SPID
    End Function

    Public Function Consultar_Produccion_GenericoxMolino(ByVal Producto As ETOrden) As Boolean
        Return Datos.CosteoProduccion.Consultar_Producto_Generico(Producto)
    End Function

    Public Function Consultar_Produccion_Generico_Delete(ByVal Producto As ETOrden) As Boolean
        Return Datos.CosteoProduccion.Consultar_Producto_Generico_Delete(Producto)
    End Function
    Public Function Validar_Costeo_ProductosTerminados(ByVal Producto As ETOrden) As Boolean
        Dim lResult As Boolean = True
        Dim Mensaje As String = String.Empty
        Dim Mensaje1 As String = String.Empty
        Dim Mensaje2 As String = String.Empty
        Dim lResultTemp As ETMyLista = Nothing

        Datos.CosteoProduccion = New DACosteoProduccion

        If Not (Producto.Cierre = "2") Then
            Return lResult
        End If

        Producto.Tipo = 11
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "No hay Ingresos de Producción para la consulta del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If


        Producto.Tipo = 1
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "Debe crear un enlace para la formulación del Producto"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 14
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "Falta la Formulación para el Costeo de la RUMA"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If


        Producto.Tipo = 13
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "No se ha registrado el costo de la Homogenización de la Silice para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 9
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.Ls_CosteoActivo.Count > 0 Then
                lResult = False

                Mensaje = "No sea ingresado el Costo de Transporte Interno"

                For Each xRow As ETCosteoActivo In lResultTemp.Ls_CosteoActivo
                    Mensaje = Mensaje & Chr(13) & "Transporte: " & xRow.Codigo.Trim
                Next

                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If

        End If

        Producto.Tipo = 8
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.Ls_CosteoActivo.Count > 0 Then

                Mensaje1 = String.Empty
                Mensaje2 = String.Empty
                For Each xRow As ETCosteoActivo In lResultTemp.Ls_CosteoActivo
                    If xRow.Descripcion.Trim <> "" Then
                        Mensaje1 = Mensaje1 & Chr(13) & "Pala: " & xRow.Codigo.Trim
                    Else
                        Mensaje2 = Mensaje2 & Chr(13) & "Pala: " & xRow.Codigo.Trim
                    End If
                Next

                If Mensaje1.Trim <> String.Empty Then
                    Mensaje = "No sea ingresado el costo de Alquiler de la Pala:"
                    Mensaje = Mensaje & Chr(13) & Mensaje1
                    lResult = False
                    MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                    Return lResult
                End If

                If Mensaje2.Trim <> String.Empty Then
                    Mensaje = "No sea ingresado el costo de Mantenimiento de la Pala:"
                    Mensaje = Mensaje & Chr(13) & Mensaje2
                    Mensaje = Mensaje & Chr(13) & "Si no existe costo presionar el boton SI, de lo Contrario presionar NO"
                    If MsgBox(Mensaje, MsgBoxStyle.Critical + MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                        lResult = False
                        Return lResult
                    End If
                End If

            End If

        End If

        Producto.Tipo = 2
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "La Planilla no esta actualizada para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 3
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "La Provisión no esta actualizada para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 17
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "Debe distribuir el Costeo del Personal Empleado entre las Plantas"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 18
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "Debe asignar el Personal a las Unidades de Producción de la Planta de Cemento"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 4
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "La Depreciación no esta actualizada para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 5
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                Mensaje = "No hay Costo de Mantenimiento Mecánico." & Chr(13) & "Si esta seguro presionar el boton SI, de lo Contrario presionar NO"
                If MsgBox(Mensaje, MsgBoxStyle.Critical + MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    lResult = False
                    Return lResult
                End If
            End If
        End If

        Producto.Tipo = 6
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "No sea cargado el consumo de Energía para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 7
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "No se ha registrado el costo KWH para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If


        Producto.Respuesta = 2
        Producto.Tipo = 10
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "No sea cargado el Consumo del Gas para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 12
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "No se ha registrado el costo del Gas Natural por m3 STD para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Return lResult
    End Function


#Region "Cierre Costeo de Productos"

    Public Function Validar_Costeo_ProductosTerminados_Cierre(ByVal Producto As ETOrden) As Boolean
        Dim lResult As Boolean = True
        Dim Mensaje As String = String.Empty
        Dim Mensaje1 As String = String.Empty
        Dim Mensaje2 As String = String.Empty
        Dim lResultTemp As ETMyLista = Nothing

        Datos.CosteoProduccion = New DACosteoProduccion

        Producto.Tipo = 15
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                'Mensaje = "Debe Procesar el Costeo del Producto"
                'MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                'Return lResult
            End If
        End If

        If Not (Producto.Cierre = "2") Then
            Return lResult
        End If

        Producto.Tipo = 19
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                'Mensaje = "Debe Procesar el Costeo del Producto del Mes Anterior"
                'MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                'Return lResult
            End If
        End If

        If Producto.Proyeccion = False Then
            Producto.Tipo = 11
            lResultTemp = New ETMyLista
            lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
            If lResultTemp.Validacion Then
                If lResultTemp.ValorxDecimal <= 0 Then
                    lResult = False
                    Mensaje = "No hay Ingresos de Producción para la consulta del Costeo"
                    MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                    Return lResult
                End If
            End If
        End If

        Producto.Tipo = 1
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "Debe crear un enlace para la formulación del Producto"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 14
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "Falta la Formulación para el Costeo de la RUMA"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 16
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "Debe Procesar Todos los Productos Terminados de la Formulación de Producto"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 13
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "No se ha registrado el costo de la Homogenización de la Silice para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 9
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.Ls_CosteoActivo.Count > 0 Then
                lResult = False

                Mensaje = "No sea ingresado el Costo de Transporte Interno"

                For Each xRow As ETCosteoActivo In lResultTemp.Ls_CosteoActivo
                    Mensaje = Mensaje & Chr(13) & "Transporte: " & xRow.Codigo.Trim
                Next

                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If

        End If

        Producto.Tipo = 8
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.Ls_CosteoActivo.Count > 0 Then

                Mensaje1 = String.Empty
                Mensaje2 = String.Empty
                For Each xRow As ETCosteoActivo In lResultTemp.Ls_CosteoActivo
                    If xRow.Descripcion.Trim <> "" Then
                        Mensaje1 = Mensaje1 & Chr(13) & "Pala: " & xRow.Codigo.Trim
                    Else
                        Mensaje2 = Mensaje2 & Chr(13) & "Pala: " & xRow.Codigo.Trim
                    End If
                Next

                If Mensaje1.Trim <> String.Empty Then
                    Mensaje = "No sea ingresado el costo de Alquiler de la Pala:"
                    Mensaje = Mensaje & Chr(13) & Mensaje1
                    lResult = False
                    MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                    Return lResult
                End If

                If Mensaje2.Trim <> String.Empty Then
                    Mensaje = "No sea ingresado el costo de Mantenimiento de la Pala:"
                    Mensaje = Mensaje & Chr(13) & Mensaje2
                    Mensaje = Mensaje & Chr(13) & "Si no existe costo presionar el boton SI, de lo Contrario presionar NO"
                    If MsgBox(Mensaje, MsgBoxStyle.Critical + MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                        lResult = False
                        Return lResult
                    End If
                End If

            End If

        End If

        Producto.Tipo = 2
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "La Planilla no esta actualizada para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 3
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "La Provisión no esta actualizada para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 17
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "Debe distribuir el Costeo del Personal Empleado entre las Plantas"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 18
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "Debe asignar el Personal a las Unidades de Producción de la Planta de Cemento"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 4
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "La Depreciación no esta actualizada para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 5
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                Mensaje = "No hay Costo de Mantenimiento Mecánico." & Chr(13) & "Si esta seguro presionar el boton SI, de lo Contrario presionar NO"
                If MsgBox(Mensaje, MsgBoxStyle.Critical + MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    lResult = False
                    Return lResult
                End If
            End If
        End If

        Producto.Tipo = 6
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "No sea cargado el consumo de Energía para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 7
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "No se ha registrado el costo KWH para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If


        Producto.Respuesta = 2
        Producto.Tipo = 10
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "No sea cargado el Consumo del Gas para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Producto.Tipo = 12
        lResultTemp = New ETMyLista
        lResultTemp = Datos.CosteoProduccion.ValidarCosteoProductoTerminado(Producto)
        If lResultTemp.Validacion Then
            If lResultTemp.ValorxDecimal <= 0 Then
                lResult = False
                Mensaje = "No se ha registrado el costo del Gas Natural por m3 STD para el mes del Costeo"
                MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_Produccion_MesSinProd_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Costeo_Produccion_SinProdMes_Cierre(Producto)
    End Function
    Public Function Consultar_Dureza_Producto(ByVal Cia As String, ByVal Ano As Integer, ByVal Mes As Integer, ByVal Producto As String, ByVal Molino As String) As Decimal
        Return Datos.CosteoProduccion.Consultar_Factor_DurezaProducto(Cia, Ano, Mes, Producto, Molino)
    End Function


    Public Function Consultar_Produccion_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Costeo_Produccion_Cierre(Producto)
    End Function
    Public Function Consultar_Produccion_GenericoxMolino_Cierre(ByVal Producto As ETOrden) As Boolean
        Return Datos.CosteoProduccion.Consultar_Producto_Generico_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Ruma_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Ruma_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Silice_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Silice_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Chancadora_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Chancadora_TranspInt_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_TranspInt_Cierre(Producto)
    End Function


    Public Function Consultar_Produccion_Chancadora_ManttoMecanico_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_ManttoMecanico_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Chancadora_Depreciacion_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_Depreciacion_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Chancadora_Energia_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_Energia_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Chancadora_ManoObra_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Chancadora_ManoObra_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Pala_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Pala_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Pala_Combustible_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Pala_Combustible_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Pala_ManoObra_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Pala_ManoObra_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Pala_Depreciacion_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Pala_Depreciacion_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Pala_Alquiler_Mantto_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Pala_Alquiler_Mantto_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_ManoObra_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_ManoObra_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Mantto_Mecanico_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_ManttoMecanico_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Contable_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Contable_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Depreciacion_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Depreciacion_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Energia_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Energia_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_GasNatural_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_GasNatural_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Envases_Cierre(ByVal Producto As ETOrden) As DataSet
        Return Datos.CosteoProduccion.Consultar_Producto_Suministro_Cierre(Producto)
    End Function

    Public Function Consultar_Produccion_Resumen(ByVal Producto As ETOrden, ByVal Resumen As List(Of ETOrden), ByVal Molino As List(Of ETOrden)) As Boolean
        Return Datos.CosteoProduccion.Consultar_Producto_Resumen(Producto, Resumen, Molino)
    End Function

#End Region
End Class
