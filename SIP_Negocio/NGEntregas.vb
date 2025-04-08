Imports SIP_Entidad
Imports SIP_Datos

Public Class NGEntregas
    Private Shared ListaEntrega As List(Of ETEntregas)

    Public Function ListarEntregas(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarSolicitudes(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarSolicitudesCero(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarSolicitudesCero(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarTrabajadorxCodigo(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarTrabajadorxCodigo(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarAreas() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarAreas

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarCanteras() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarCanteras

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarProductos() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarProductos

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarProductosVTA() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarProductosVTA

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarGatosVehiculos(ByVal periodo As String, ByVal cencos As String, ByVal placa As String) As DataSet
        Return Datos.Entregas.ListarGatosVehiculos(periodo, cencos, placa)
    End Function
    Public Function ListarPlacasxCentro(ByVal periodo As String, ByVal cgcod As String, ByVal placa As String) As DataSet
        Return Datos.Entregas.ListarPlacasxCentro(periodo, cgcod, placa)
    End Function

    Public Function ListarRumas() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarRumas

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoEntregas(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal Ls_EntregaDetalle As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else

            lResult = Datos.Entregas.MantenimientoSolicitud(Rpt, ListaEntrega, Ls_EntregaDetalle)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            If Rpt.TipoOperacion = 1 Then
                MsgBox("Se Registró Correctamente la Solicitud N° " & numSolicitud, MsgBoxStyle.Information, msgComacsa)
            Else
                MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            End If
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function MantenimientoSolictudCero(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal Ls_EntregaDetalle As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else

            lResult = Datos.Entregas.MantenimientoSolictudCero(Rpt, ListaEntrega, Ls_EntregaDetalle)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            If Rpt.TipoOperacion = 1 Then
                MsgBox("Se Registró Correctamente la Solicitud N° " & numSolicitud, MsgBoxStyle.Information, msgComacsa)
            Else
                MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            End If
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function EliminarSolicitudCero(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal Ls_EntregaDetalle As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea eliminar solicitud?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoSolictudCero(Rpt, ListaEntrega, Ls_EntregaDetalle)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            MsgBox("Se eliminó correctamente", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function EliminarEntregas(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal Ls_EntregaDetalle As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea eliminar solicitud?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoSolicitud(Rpt, ListaEntrega, Ls_EntregaDetalle)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            MsgBox("Se eliminó correctamente", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function SolicitudDetalle(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.SolicitudDetalle(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function SolicitudxNumero(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.SolicitudxNumero(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function SolicitudxNumeroTarjetaConsumo(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.SolicitudxNumeroTarjetaConsumo(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function UsuarioAprobacion(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.UsuarioAprobacion(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function Listar_JefeArea(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_JefeArea(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Listar_ProveedorxRuc(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_ProveedorxRuc(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function ListarConceptos() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarConceptos()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarConceptosxArea(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarConceptosxArea(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoLiquidacion(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal tiposaldo As String, ByVal saldo As String, ByVal tipmon As String) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        If ListaEntrega.Item(0).idEstado = 3 Or tiposaldo = "1" Then
            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Return lResult
            Else
                lResult = Datos.Entregas.MantenimientoLiquidacion(Rpt, ListaEntrega)
            End If
        ElseIf ListaEntrega.Item(0).idEstado = 4 Then

            If tiposaldo = "2" Then

                If MsgBox("El monto a liquidar es mayor al monto solicitado" & vbCrLf & "¿Desea generar un documento de reintegro por " & saldo & " " & tipmon & "?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Return lResult
                Else
                    lResult = Datos.Entregas.MantenimientoLiquidacion(Rpt, ListaEntrega)
                End If
            ElseIf tiposaldo = "3" Then
                If MsgBox("Se generará un documento pendiente de liquidar por " & saldo & " " & tipmon & " ...¿Desea grabar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Return lResult
                Else
                    lResult = Datos.Entregas.MantenimientoLiquidacion(Rpt, ListaEntrega)
                End If

            End If

        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function Listar_DetalleLiquidacion(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DetalleLiquidacion(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarDocumentos() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarDocumentos()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Listar_Liquidaciones(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_Liquidaciones(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function ListarMotivos() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarMotivos()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ConsultaEntregas(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ConsultaEntregas(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ConsultaSaldos(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ConsultaSaldos(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ConsultaSaldosAprobados(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ConsultaSaldosAprobados(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ConsultaEntregasDetalle(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ConsultaEntregasDetalle(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarUsuariosAprueba(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarUsuariosAprueba(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function CargarUsuarios(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.CargarUsuarios(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function CargarUsuariosAprueba(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.CargarUsuariosAprueba(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoUsuarioAprobacion(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        'ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoUsuarioAprobacion(Rpt, Ls_Entrega)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else

            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function EliminarUsuarioAprobacion(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        'ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoUsuarioAprobacion(Rpt, Ls_Entrega)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else

            MsgBox("Se eliminó correctamente", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function CargarPersonal(ByVal Cencos As String) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.CargarPersonal(Cencos)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function CargarPersonalTarjetaConsumo(ByVal _lchk_tarjeta As Integer) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.CargarPersonalTarjetaConsumo(_lchk_tarjeta)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function


    Public Function CargarBarbotina() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.CargarBarbotina()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoLiquidacionPend(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal tiposaldo As String, ByVal saldo As String) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoLiquidacionPend(Rpt, ListaEntrega)
        End If
        'If ListaEntrega.Item(0).idEstado = 3 Or tiposaldo = "1" Then
        '    If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '        Return lResult
        '    Else
        '        lResult = Datos.Entregas.MantenimientoLiquidacion(Rpt, ListaEntrega)
        '    End If
        'ElseIf ListaEntrega.Item(0).idEstado = 4 Then

        '    If tiposaldo = "2" Then

        '        If MsgBox("El monto a liquidar es mayor al monto solicitado" & vbCrLf & "¿Desea generar un documento de reintegro por " & saldo & "?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '            Return lResult
        '        Else
        '            lResult = Datos.Entregas.MantenimientoLiquidacion(Rpt, ListaEntrega)
        '        End If
        '    ElseIf tiposaldo = "3" Then
        '        If MsgBox("Se generará un documento pendiente de liquidar por " & saldo & " ...¿Desea grabar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '            Return lResult
        '        Else
        '            lResult = Datos.Entregas.MantenimientoLiquidacionPend(Rpt, ListaEntrega)
        '        End If

        '    End If

        'End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function Listar_DetalleLiquidacionPend(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DetalleLiquidacionPend(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function CargarReintegros(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.CargarReintegros(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarMonedas() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarMonedas

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function CargarMonedas() As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.CargarMonedas()
    End Function

    Public Function CargarOtroConcepto(ByVal obj As ETEntregas) As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.CargarOtroConcepto(obj)
    End Function
    Public Function CargarTipoVehiculo() As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.CargarTipoVehiculo()
    End Function

    Public Function VerificaPlaca(ByVal placa As String, ByVal tfactura As String) As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.VerificaPlaca(placa, tfactura)
    End Function

    Public Function LimiteTramites(ByVal cod_trabajador As String) As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.LimiteTramites(cod_trabajador)
    End Function

    Public Function VerificaUserUnico(ByVal usuario As String, ByVal cod_trabajador As String) As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.VerificaUserUnico(usuario, cod_trabajador)
    End Function

    Public Function CargarTipoFacturacion() As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.CargarTipoFacturacion()
    End Function
    Public Function CargarAlquilerVehiculo() As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.CargarAlquilerVehiculo()
    End Function

    Public Function CargarAlquilerVehiculoPlaca(ByVal Rpt As ETEntregas) As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.CargarAlquilerVehiculoPlaca(Rpt)
    End Function

    Public Function ListarBancos() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarBancos

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarBeneficiarioDni(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarBeneficiarioDni(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarLineacredito() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarLineacredito()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarSuspension() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarSuspension()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarRetencionRH() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarRetencionRH()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoLineacredito(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal Ls_EntregaDetalle As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoLineacredito(Rpt, ListaEntrega, Ls_EntregaDetalle)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function EliminarLineacredito(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal Ls_EntregaDetalle As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoLineacredito(Rpt, ListaEntrega, Ls_EntregaDetalle)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            MsgBox("Se eliminó correctamente", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ValidaLineacredito(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ValidaLineacredito(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ValidaExcesocredito(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ValidaExcesocredito(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Listar_LiquidacionesCerradas(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_LiquidacionesCerradas(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function


    '    Public Function RecepcionarSolicitud(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

    '        Dim lResult As ETEntregas = Nothing
    '        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
    '            Return lResult
    '        End If
    '        lResult = New ETEntregas
    'Operacion:
    '        ListaEntrega = New List(Of ETEntregas)
    '        ListaEntrega = Ls_Entrega
    '        'If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
    '        '    Return lResult
    '        'Else
    '        lResult = Datos.Entregas.RecepcionarSolicitud(Rpt, ListaEntrega)
    '        'End If
    'Salida:

    '        If lResult Is Nothing Then
    '            lResult = New ETEntregas
    '        Else
    '            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
    '            lResult.Validacion = Boolean.TrueString
    '        End If

    '        Return lResult

    '    End Function


    Public Function RecepcionarSolicitud(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas
        ' Esta función toma dos parámetros: Rpt (un objeto ETEntregas) y Ls_Entrega (una Lista de objetos ETEntregas)
        ' Devuelve un objeto ETEntregas

        Dim lResult As ETEntregas = Nothing
        ' Inicializa lResult como Nothing (null en otros lenguajes)

        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        ' Si Rpt o Ls_Entrega es Nothing, devuelve lResult (que es Nothing en este punto)

        lResult = New ETEntregas
        ' Crea un nuevo objeto ETEntregas y lo asigna a lResult

Operacion:
        ' Esta etiqueta no se usa en el código actual, pero podría usarse para manejo de errores o control de flujo

        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        ' Crea una nueva Lista de ETEntregas y le asigna el valor de Ls_Entrega
        ' Nota: Este paso parece redundante ya que ListaEntrega se sobrescribe inmediatamente

        'If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '    Return lResult
        'Else
        ' Este código comentado habría mostrado un diálogo de confirmación al usuario
        ' Si el usuario hiciera clic en 'No', devolvería lResult (que es un objeto ETEntregas vacío en este punto)

        lResult = Datos.Entregas.RecepcionarSolicitud(Rpt, ListaEntrega)
        ' Llama al método RecepcionarSolicitud de Datos.Entregas, pasando Rpt y ListaEntrega
        ' El resultado se asigna a lResult

        'End If
        ' Fin de la declaración if comentada

Salida:
        ' Otra etiqueta, no utilizada en el código actual

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            ' Este código comentado habría mostrado un mensaje de éxito al usuario

            lResult.Validacion = Boolean.TrueString
            ' Establece la propiedad Validacion de lResult a "True" (como una cadena)
        End If

        Return lResult
        ' Devuelve el objeto lResult final

    End Function

    Public Function CodigoDescripcion() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.CodigoDescripcion()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoDescripciones(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        'ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoDescripciones(Rpt)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else

            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function Listar_DetalleLiquidacionCopia(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DetalleLiquidacionCopia(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoLiquidacionCopia(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        'If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '    Return lResult
        'Else
        lResult = Datos.Entregas.MantenimientoLiquidacionCopia(Rpt, ListaEntrega)
        'End If
Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ListarAreasCuenta(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarAreasCuenta(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarCuentaContable() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarCuentaContable()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoSeteContable(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        'ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoSeteContable(Rpt, Ls_Entrega)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else

            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ListarAreasxUsuario(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarAreasxUsuario(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarTrabajadoresArea() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarTrabajadoresArea()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoTrabajadorArea(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        lResult = New ETEntregas

        If Rpt Is Nothing Then
            Return lResult
        End If
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoTrabajadorArea(Rpt)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
    
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ListarAreaTrabajador(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarAreaTrabajador(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function RecepcionarSolicitudPend(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas
Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        'If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '    Return lResult
        'Else
        lResult = Datos.Entregas.RecepcionarSolicitudPend(Rpt, ListaEntrega)
        'End If
Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult


    End Function

    Public Function MantenimientoLiquidacionCopiaPend(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega
        'If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '    Return lResult
        'Else
        lResult = Datos.Entregas.MantenimientoLiquidacionCopiaPend(Rpt, ListaEntrega)
        'End If
Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function Listar_DetalleLiquidacionPendCopia(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DetalleLiquidacionPendCopia(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoDocInterno(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega

        lResult = Datos.Entregas.MantenimientoDocInterno(Rpt, ListaEntrega)

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function Listar_DocAsociadoLiqui(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DocAsociadoLiqui(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoDocInternoPend(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega

        lResult = Datos.Entregas.MantenimientoDocInternoPend(Rpt, ListaEntrega)

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function Listar_DocAsociadoLiquiPend(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DocAsociadoLiquiPend(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Listar_DocAsociadoLiquiCopia(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DocAsociadoLiquiCopia(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Listar_DocAsociadoLiquiPendCopia(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DocAsociadoLiquiPendCopia(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoDocInternoCopia(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega

        lResult = Datos.Entregas.MantenimientoDocInternoCopia(Rpt, ListaEntrega)

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function MantenimientoDocInternoPendCopia(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega

        lResult = Datos.Entregas.MantenimientoDocInternoPendCopia(Rpt, ListaEntrega)

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function FlagAuxiliar(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.FlagAuxiliar(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarAuxiliar(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarAuxiliar(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarAuxiliar3(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarAuxiliar3(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoDocMovilidad(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal tipotabla As Int32) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega

        lResult = Datos.Entregas.MantenimientoDocMovilidad(Rpt, ListaEntrega, tipotabla)

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function MantenimientoDetalleRecibo(ByVal numsolicitud As String, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        'If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
        '    Return lResult
        'End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega

        lResult = Datos.Entregas.MantenimientoDetalleRecibo(numsolicitud, ListaEntrega)

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function MantenimientoDetalleReciboCopia(ByVal numsolicitud As String, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        'If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
        '    Return lResult
        'End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega

        lResult = Datos.Entregas.MantenimientoDetalleReciboCopia(numsolicitud, ListaEntrega)

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function


    Public Function Listar_DocMovilidad(ByVal Rpt As ETEntregas, ByVal tipotabla As Int32) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DocMovilidad(Rpt, tipotabla)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Listar_DocMovilidadCopia(ByVal Rpt As ETEntregas, ByVal tipotabla As Int32) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DocMovilidadCopia(Rpt, tipotabla)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoDocMovilidadCopia(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal tipotabla As Int32) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega

        lResult = Datos.Entregas.MantenimientoDocMovilidadCopia(Rpt, ListaEntrega, tipotabla)

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function
    Public Function ListarCentroCostoPlaca(ByVal periodo As String) As DataSet
        Return Datos.Entregas.ListarCentroCostoPlaca(periodo)
    End Function
    Public Function ListarCentroCosto() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarCentroCosto

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function SolicitudxNumeroLiquidacion(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.SolicitudxNumeroLiquidacion(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function VerificaCierreContable(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.VerificaCierreContable(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function VerificaDevolucion(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.VerificaDevolucion(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function verificarDocumentos(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.verificarDocumentos(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function GeneraAsientoEntregas(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        'ListaEntrega = Ls_Entrega
        'If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        'Return lResult
        'Else
        lResult = Datos.Entregas.GeneraAsientoEntregas(Rpt)
        'End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            'Dim numSolicitud As String = String.Empty
            'numSolicitud = lResult.NumSolicitud
            'If Rpt.TipoOperacion = 1 Then
            'MsgBox("Se Registró Correctamente la Solicitud N° " & numSolicitud, MsgBoxStyle.Information, msgComacsa)
            'Else
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            'End If
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function GeneraAsientoEntregasProvision(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        'ListaEntrega = Ls_Entrega
        'If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        'Return lResult
        'Else
        lResult = Datos.Entregas.GeneraAsientoEntregasProvision(Rpt)
        'End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            'Dim numSolicitud As String = String.Empty
            'numSolicitud = lResult.NumSolicitud
            'If Rpt.TipoOperacion = 1 Then
            'MsgBox("Se Registró Correctamente la Solicitud N° " & numSolicitud, MsgBoxStyle.Information, msgComacsa)
            'Else
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            'End If
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function GeneraAsientoEntregasPend(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        'ListaEntrega = Ls_Entrega
        'If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        'Return lResult
        'Else
        lResult = Datos.Entregas.GeneraAsientoEntregasPend(Rpt)
        'End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            'Dim numSolicitud As String = String.Empty
            'numSolicitud = lResult.NumSolicitud
            'If Rpt.TipoOperacion = 1 Then
            'MsgBox("Se Registró Correctamente la Solicitud N° " & numSolicitud, MsgBoxStyle.Information, msgComacsa)
            'Else
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            'End If
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function verificaReintegro(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.verificaReintegro(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ActualizaRegion(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        lResult = New ETEntregas

        If Rpt Is Nothing Then
            Return lResult
        End If
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.ActualizaRegion(Rpt)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else

            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ConsultaReporte(ByVal Rpt As ETEntregas) As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.ConsultaReporte(Rpt)
    End Function

    Public Function CorreoSaldo(ByVal codtrabajador As String) As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.CorreoSaldo(codtrabajador)
    End Function

    Public Function ListarCombustible() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarCombustible()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoDocCombustible(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal tipotabla As Int32) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega

        lResult = Datos.Entregas.MantenimientoDocCombustible(Rpt, ListaEntrega, tipotabla)

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function Listar_DocCombustible(ByVal Rpt As ETEntregas, ByVal tipotabla As Int32) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DocCombustible(Rpt, tipotabla)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Listar_DocDetalleRH(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DocDetalleRH(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Listar_DocDetalleRHCopia(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DocDetalleRHCopia(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Listar_DocCombustibleCopia(ByVal Rpt As ETEntregas, ByVal tipotabla As Int32) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_DocCombustibleCopia(Rpt, tipotabla)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoDocCombustibleCopia(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal tipotabla As Int32) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega

        lResult = Datos.Entregas.MantenimientoDocCombustibleCopia(Rpt, ListaEntrega, tipotabla)

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ConsultaCombustible(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ConsultaCombustible(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarCombustibleMant() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarCombustibleMant

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoCombustible(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        lResult = New ETEntregas

        If Rpt Is Nothing Then
            Return lResult
        End If
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoCombustible(Rpt)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else

            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ActualizaCombustible(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        lResult = New ETEntregas

        If Rpt Is Nothing Then
            Return lResult
        End If
Operacion:

        'If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '    Return lResult
        'Else
        lResult = Datos.Entregas.ActualizaCombustible(Rpt)
        'End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else

            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function


    Public Function EliminaCombustible(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        lResult = New ETEntregas

        If Rpt Is Nothing Then
            Return lResult
        End If
Operacion:

        If MsgBox("¿Seguro desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoCombustible(Rpt)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else

            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ListarAreasIngreso(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarAreasIngreso(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoUsuarioIngreso(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        'ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoUsuarioIngreso(Rpt, Ls_Entrega)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else

            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ListarSeteoCorreo(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarSeteoCorreo(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MantenimientoSeteoCorreo(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        'ListaEntrega = Ls_Entrega
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MantenimientoSeteoCorreo(Rpt, Ls_Entrega)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else

            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function Listar_LiquidacionesRevision(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.Listar_LiquidacionesRevision(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function LimiteGastos(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.LimiteGastos(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListarCanterasUEA(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarCanterasUEA(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function MANTINGRESOMINERALSATAMIN(ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        ListaEntrega = Ls_Entrega

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Entregas.MANTINGRESOMINERALSATAMIN(ListaEntrega)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function validarReciboHonorario(ByVal Rpt As ETEntregas) As String

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        Return Datos.Entregas.validarReciboHonorario(Rpt)

        'If lResult Is Nothing Then
        '    lResult = New ETMyLista
        'Else
        '    If Not lResult.Validacion Then
        '        MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
        '    End If
        'End If

        'Return lResult
    End Function

    Public Function ValidaDocRepetido(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.ValidaDocRepetido(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function VerAuxi3(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.VerAuxi3(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function VerAuxi3Log(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.VerAuxi3Log(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function validarUserRevision(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.validarUserRevision(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Cantera_Maquina(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.Cantera_Maquina(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Movilidad_Fecha(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.Movilidad_Fecha(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function verifica_documento_compra(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.verifica_documento_compra(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function usuario_registro_compra(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.usuario_registro_compra(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function registra_retencion(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.registra_retencion(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function elimina_retencion(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.elimina_retencion(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function lista_registro_compra(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.lista_registro_compra(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function registro_compra(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.registro_compra(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function registro_compra_Prov(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.registro_compra_Prov(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function elimina_registro_compra(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.elimina_registro_compra(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ValidaReintegroAplicacion(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.ValidaReintegroAplicacion(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CombustibleResumen(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.CombustibleResumen(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function EliminaProvisionEntregas(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.EliminaProvisionEntregas(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function verificaProvisionMes(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.verificaProvisionMes(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function usuarioRevision(ByVal Rpt As ETEntregas) As DataTable
        Try
            Return Datos.Entregas.usuarioRevision(Rpt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarTransportista_() As DataTable
        Try
            Return Datos.Entregas.ListarTransportista_()
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListarTransportista() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Entregas.ListarTransportista()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ListaPrudctoIQBF() As DataTable
        Try
            Return Datos.Entregas.ListaPrudctoIQBF()
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ConceptosRH() As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.ConceptosRH()
    End Function

    Public Function ListarConceptoRH() As DataTable
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        Return Datos.Entregas.ListarConceptoRH()
    End Function

    Public Function EliminaLiquidacion(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If
        lResult = New ETEntregas

Operacion:
        ListaEntrega = New List(Of ETEntregas)
        If MsgBox("¿Seguro desea eliminar los documentos?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else

            lResult = Datos.Entregas.EliminaLiquidacion(Rpt)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            Dim numSolicitud As String = String.Empty
            numSolicitud = lResult.NumSolicitud
            MsgBox("Se eliminaron correctamente los documentos", MsgBoxStyle.Information, msgComacsa)
            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function MantenimientoAlquilerVehiculo(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        lResult = New ETEntregas

        If Rpt Is Nothing Then
            Return lResult
        End If
Operacion:

        'If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '    Return lResult
        'Else
        lResult = Datos.Entregas.MantenimientoAlquilerVehiculo(Rpt)
        'End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else

            'MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)

            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function


    Public Function FechaKilometraje() As ETEntregas
        Dim lResult As ETEntregas = Nothing
        lResult = New ETEntregas
Operacion:
        lResult = Datos.Entregas.FechaKilometraje()
Salida:
        If lResult Is Nothing Then
            lResult = New ETEntregas
        Else
            lResult.Validacion = Boolean.TrueString
        End If
        Return lResult
    End Function

    ' Función que obtiene los límites de línea de crédito desde la capa de datos
    ' Parámetro:
    '   Rpt - Objeto de tipo ETEntregas (no se utiliza en la función actual)
    ' Retorna:
    '   Objeto ETMyLista con los resultados de límites de la linea de crédito de la Tarjeta

    Public Function LimiteLineaCredito(ByVal Rpt As ETEntregas) As ETMyLista
        ' Declaración e inicialización de variable para almacenar el resultado
        Dim lResult As ETMyLista = Nothing

        ' Creación de nueva instancia de ETMyLista (aunque se sobrescribe en la siguiente línea)
        lResult = New ETMyLista

        ' NOTA: Este return hace que el resto del código no se ejecute nunca (posible error)
        lResult = Datos.Entregas.LimiteLineaCredito(Rpt.idTarjetaConsumo, Rpt.idTipoTarjetaConsumo)

        ' --- El código siguiente nunca se ejecuta debido al Return anterior ---
        ' Validación si no se obtuvieron resultados
        If lResult Is Nothing Then
            ' Crear nueva lista vacía si no hay resultados
            lResult = New ETMyLista
        Else
            ' Si hay resultados pero la validación falló
            If Not lResult.Validacion Then
                ' Mostrar mensaje de error al usuario
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        ' Retornar el resultado 
        Return lResult
    End Function

End Class
