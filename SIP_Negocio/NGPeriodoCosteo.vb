Imports SIP_Entidad
Imports SIP_Datos
Public Class NGPeriodoCosteo
    Public Function MantenedorPeriodoCosteo(ByVal Periodo As ETPeriodo) As Boolean
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
            Return False
        End If

        If Val(Periodo.Mes) = 0 Then
            MsgBox("Seleccione un Mes Valido", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If

        If Periodo.Tipo = 3 Then

            If String.IsNullOrEmpty(Periodo.Estado.TrimEnd) Then
                MsgBox("El Periodo ya fue Cerrado", MsgBoxStyle.Exclamation, msgComacsa)
                Return False
            Else
                GoTo Operacion
            End If
        Else
            If Datos.Periodo.Validar_Periodo(Periodo) Then
                MsgBox("El Periodo ya fue creado", MsgBoxStyle.Exclamation, msgComacsa)
                Return False
            End If
        End If
Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return False
        Else
            lResult = Datos.Periodo.Mantenedor_Periodo(Periodo)
        End If

Salida:

        If lResult = True Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
        End If

        Return lResult
    End Function

    Public Function ConsultarPeriodoCosteo(ByVal Periodo As ETPeriodo) As ETMyLista
        If Periodo Is Nothing Then
            Return Nothing
        Else
            Return Datos.Periodo.Consultar_Periodo(Periodo)
        End If

    End Function

    Public Function ConsultarPeriodo_Activo(ByVal Periodo As ETPeriodoDetalle) As ETMyLista
        If Periodo Is Nothing Then
            Return Nothing
        Else
            Return Datos.Periodo.Consultar_Periodo_Activos(Periodo)
        End If

    End Function

    Public Function ConsultarPeriodo_Activo_Facturacion(ByVal Periodo As ETPeriodoDetalle) As ETMyLista
        If Periodo Is Nothing Then
            Return Nothing
        Else
            Return Datos.Periodo.Consultar_Periodo_Activos_Facturacion(Periodo)
        End If

    End Function

    Public Function ConsultarPeriodoCosteo_Operador(ByVal Periodo As ETPeriodoDetalle) As ETMyLista
        If Periodo Is Nothing Then
            Return Nothing
        Else
            Return Datos.Periodo.Consultar_Periodo_Operador(Periodo)
        End If

    End Function

    Public Function ConsultarPeriodoCosteo_ComprobantePago(ByVal Periodo As ETPeriodoDetalle) As DataSet
        If Periodo Is Nothing Then
            Return Nothing
        Else
            Return Datos.Periodo.Consultar_Periodo_ComprobatePago(Periodo)
        End If

    End Function

    Public Function ConsultarPeriodoCosteo_ComprobantePago_Mes(ByVal Periodo As ETPeriodo) As ETMyLista
        If Periodo Is Nothing Then
            Return Nothing
        Else
            Return Datos.Periodo.Consultar_Periodo_ComprobatePago_Mes(Periodo)
        End If

    End Function


    Public Function MantenedorPeriodoCosteo_Facturacion(ByVal Periodo As ETPeriodo, ByVal PeriodoDetalle As List(Of ETPeriodoDetalle), ByVal Ls_Comprob_Pago As List(Of ETPeriodoDetalle), ByVal Ls_Comprob_Pago_Mes As List(Of ETPeriodoDetalle)) As Boolean
        Dim lResult As Long = 0
        Dim Mensaje1, Mensaje2 As String
        Dim EntObj As New ETPeriodo
        Dim Valor As Integer = 0
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
            Return False
        End If

        If Val(Periodo.Mes) = 0 Then
            MsgBox("Seleccione un Mes Valido", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If

        EntObj.Anio = Periodo.Anio
        EntObj.Mes = Periodo.Mes
        EntObj.TipoPeriodo = ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos
        EntObj.Tipo = 9

        Valor = Datos.Periodo.Validar_Periodo_Cerrado(EntObj)

        If Valor = 0 Then
            MsgBox("El Periodo de Costeo de Productos Terminados no Existe", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        ElseIf Valor = 2 Then
            MsgBox("El Periodo de Costeo de Productos Terminados está Cerrado", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If
        If Periodo.Tipo = 3 Then
            GoTo Operacion
        Else
            If Datos.Periodo.Validar_Periodo(Periodo) Then
                MsgBox("El Periodo ya fue creado", MsgBoxStyle.Exclamation, msgComacsa)
                Return False
            End If
        End If
Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return False
        Else
            lResult = Datos.Periodo.Mantenedor_Periodo_Facturacion(Periodo, PeriodoDetalle, Ls_Comprob_Pago, Ls_Comprob_Pago_Mes)
        End If

Salida:

        If lResult = True Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
        End If

        Return lResult
    End Function

    Public Function MantenedorPeriodoCosteo_Operador(ByVal Periodo As ETPeriodo, ByVal PeriodoDetalle As List(Of ETPeriodoDetalle)) As Boolean
        Dim lResult As Long = 0
        Dim Mensaje1, Mensaje2 As String
        Dim EntObj As New ETPeriodo
        Dim Valor As Integer = 0
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
            Return False
        End If

        If Val(Periodo.Mes) = 0 Then
            MsgBox("Seleccione un Mes Valido", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If

        EntObj.Anio = Periodo.Anio
        EntObj.Mes = Periodo.Mes
        EntObj.TipoPeriodo = ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos
        EntObj.Tipo = 9

        Valor = Datos.Periodo.Validar_Periodo_Cerrado(EntObj)

        If Valor = 0 Then
            MsgBox("El Periodo de Costeo de Productos Terminados no Existe", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        ElseIf Valor = 2 Then
            MsgBox("El Periodo de Costeo de Productos Terminados está Cerrado", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If
        If Periodo.Tipo = 3 Then
            GoTo Operacion
        Else
            If Datos.Periodo.Validar_Periodo(Periodo) Then
                MsgBox("El Periodo ya fue creado", MsgBoxStyle.Exclamation, msgComacsa)
                Return False
            End If
        End If
Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return False
        Else
            lResult = Datos.Periodo.Mantenedor_Periodo_Operador(Periodo, PeriodoDetalle)
        End If

Salida:

        If lResult = True Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
        End If

        Return lResult
    End Function

End Class
