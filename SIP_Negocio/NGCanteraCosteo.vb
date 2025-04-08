Imports SIP_Entidad
Imports SIP_Negocio

Public Class NGCanteraCosteo
    Private List As List(Of ETCanteraCosteo)

    Public Function GetDescripcionCantera(ByVal Cod_Cantera As String) As String
        Return Datos.CanteraCosteo.ObtenerDescripcionCantera(Cod_Cantera)
    End Function

    Public Function GetOrigenCantera(ByVal Cod_Cantera As String) As String
        Return Datos.CanteraCosteo.ObtenerOrigenCantera(Cod_Cantera)
    End Function


    '   *****   CANTERA - EMPLEADO              ****
    Public Function ConsultarCanteraViaje(ByVal CanteraViaje As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarCanteraViaje(CanteraViaje)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarCanteraViajeDetalle(ByVal CanteraViaje As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarCanteraViajeDetalle(CanteraViaje)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function EliminarCanteraViaje(ByVal Cabecera As ETCanteraCosteo, ByVal Detalle As List(Of ETCanteraCosteo)) As ETResultado
        EliminarCanteraViaje = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(Cabecera.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraViaje
            Else
                Cabecera.ID = Cabecera.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraViaje

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraViaje.Realizo = False
            Return EliminarCanteraViaje
        Else
            EliminarCanteraViaje = Datos.CanteraCosteo.MantenimientoCanteraViaje(Cabecera, Detalle)
        End If

Salida:

        If EliminarCanteraViaje Is Nothing OrElse EliminarCanteraViaje.Realizo = False Then
            EliminarCanteraViaje = New ETResultado
            EliminarCanteraViaje.Realizo = False
            Return EliminarCanteraViaje
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & Cabecera.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraViaje.Realizo = True
            Return EliminarCanteraViaje
        End If
    End Function

    Public Function MantenimientoCanteraViaje(ByVal CanteraViaje As ETCanteraCosteo, ByVal Detalle As List(Of ETCanteraCosteo)) As ETResultado
        MantenimientoCanteraViaje = New ETResultado
        List = New List(Of ETCanteraCosteo)

Ingreso:

        Try

            If Not (CanteraViaje.Opcion = 1) Then
                Return MantenimientoCanteraViaje
            End If

            If String.IsNullOrEmpty(CanteraViaje.Empleado) Then
                MsgBox("Ingrese el Empleado", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraViaje
            Else
                CanteraViaje.Empleado = CanteraViaje.Empleado.Trim
            End If

            If CanteraViaje.FechaFin < CanteraViaje.FechaInicio Then
                MsgBox("La fecha fin NO puede ser menor que la fecha inicio", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraViaje
            End If

            If Detalle Is Nothing Then
                MsgBox("Ingrese la(s) Cantera(s)", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraViaje
            ElseIf Detalle.Count <= 0 Then
                MsgBox("Ingrese la(s) Cantera(s)", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraViaje
            End If
        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraViaje

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraViaje.Realizo = False
            Return MantenimientoCanteraViaje
        Else
            MantenimientoCanteraViaje = Datos.CanteraCosteo.MantenimientoCanteraViaje(CanteraViaje, Detalle)
        End If

Salida:

        If MantenimientoCanteraViaje Is Nothing OrElse MantenimientoCanteraViaje.Realizo = False Then
            MantenimientoCanteraViaje = New ETResultado
            MantenimientoCanteraViaje.Realizo = False
            Return MantenimientoCanteraViaje
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraViaje.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraViaje.Realizo = True
            Return MantenimientoCanteraViaje
        End If
    End Function

    Public Function ValidarCanteraViaje(ByVal CanteraViaje As ETCanteraCosteo) As Boolean
        ValidarCanteraViaje = Datos.CanteraCosteo.ValidarCanteraViaje(CanteraViaje)
    End Function

    '   ****    COMBUSTIBLE - EXPLOSIVO         ****
    Public Function EliminarCombustibleExplosivo(ByVal CombustibleExplosivo As ETCanteraCosteo) As ETResultado
        EliminarCombustibleExplosivo = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(CombustibleExplosivo.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCombustibleExplosivo
            Else
                CombustibleExplosivo.ID = CombustibleExplosivo.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCombustibleExplosivo

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCombustibleExplosivo.Realizo = False
            Return EliminarCombustibleExplosivo
        Else
            EliminarCombustibleExplosivo = Datos.CanteraCosteo.MantenimientoCombustibleExplosivo(CombustibleExplosivo)
        End If

Salida:

        If EliminarCombustibleExplosivo Is Nothing OrElse EliminarCombustibleExplosivo.Realizo = False Then
            EliminarCombustibleExplosivo = New ETResultado
            EliminarCombustibleExplosivo.Realizo = False
            Return EliminarCombustibleExplosivo
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & CombustibleExplosivo.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCombustibleExplosivo.Realizo = True
            Return EliminarCombustibleExplosivo
        End If
    End Function

    Public Function ListarCanteraCombustibleExplosivo(ByVal CombustibleExplosivo As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ListarCanteraCombustibleExplosivo(CombustibleExplosivo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ListarPrecioCombustibleExplosivo(ByVal CombustibleExplosivo As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ListarPrecioCombustibleExplosivo(CombustibleExplosivo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function MantenimientoCombustibleExplosivo(ByVal CombustibleExplosivo As ETCanteraCosteo) As ETResultado
        MantenimientoCombustibleExplosivo = New ETResultado
        List = New List(Of ETCanteraCosteo)

Ingreso:

        Try

            If Not (CombustibleExplosivo.Opcion = 1) Then
                Return MantenimientoCombustibleExplosivo
            End If

            If String.IsNullOrEmpty(CombustibleExplosivo.Tipo) Then
                MsgBox("Ingrese el Tipo de Material", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCombustibleExplosivo
            Else
                CombustibleExplosivo.Tipo = CombustibleExplosivo.Tipo.Trim
            End If

            If String.IsNullOrEmpty(CombustibleExplosivo.Descripcion) Then
                MsgBox("Ingrese el Producto", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCombustibleExplosivo
            Else
                CombustibleExplosivo.Descripcion = CombustibleExplosivo.Descripcion.Trim
            End If

            If String.IsNullOrEmpty(CombustibleExplosivo.Cantera) Then
                MsgBox("Ingrese la Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCombustibleExplosivo
            End If


            If CombustibleExplosivo.TipoTrabajo = "A" Then
                If String.IsNullOrEmpty(CombustibleExplosivo.Motivo) Then
                    MsgBox("Ingrese el Motivo del Consumo Administrativo", MsgBoxStyle.Exclamation, msgComacsa)
                    Return MantenimientoCombustibleExplosivo
                Else
                    CombustibleExplosivo.Motivo = CombustibleExplosivo.Motivo.Trim
                End If
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCombustibleExplosivo

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCombustibleExplosivo.Realizo = False
            Return MantenimientoCombustibleExplosivo
        Else
            MantenimientoCombustibleExplosivo = Datos.CanteraCosteo.MantenimientoCombustibleExplosivo(CombustibleExplosivo)
        End If

Salida:

        If MantenimientoCombustibleExplosivo Is Nothing OrElse MantenimientoCombustibleExplosivo.Realizo = False Then
            MantenimientoCombustibleExplosivo = New ETResultado
            MantenimientoCombustibleExplosivo.Realizo = False
            Return MantenimientoCombustibleExplosivo
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCombustibleExplosivo.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCombustibleExplosivo.Realizo = True
            Return MantenimientoCombustibleExplosivo
        End If
    End Function


    Public Function MantenimientoPrecioCombustibleExplosivo(ByVal CombustibleExplosivo As ETCanteraCosteo, ByVal OPCION As Int32) As ETResultado
        MantenimientoPrecioCombustibleExplosivo = New ETResultado
        List = New List(Of ETCanteraCosteo)

Ingreso:

        Try

            'If Not (CombustibleExplosivo.Opcion = 1) Then
            '    Return MantenimientoPrecioCombustibleExplosivo
            'End If

            If String.IsNullOrEmpty(CombustibleExplosivo.Tipo) Then
                MsgBox("Ingrese el Tipo de Material", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoPrecioCombustibleExplosivo
            Else
                CombustibleExplosivo.Tipo = CombustibleExplosivo.Tipo.Trim
            End If

            If String.IsNullOrEmpty(CombustibleExplosivo.Descripcion) Then
                MsgBox("Ingrese el Producto", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoPrecioCombustibleExplosivo
            Else
                CombustibleExplosivo.Descripcion = CombustibleExplosivo.Descripcion.Trim
            End If

            If String.IsNullOrEmpty(CombustibleExplosivo.CodigoCantera) Then
                MsgBox("Ingrese Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoPrecioCombustibleExplosivo
            Else
                CombustibleExplosivo.CodigoCantera = CombustibleExplosivo.CodigoCantera.Trim
            End If
        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoPrecioCombustibleExplosivo

        End Try
Operacion:
        Dim mensaje As String = String.Empty
        mensaje = IIf(OPCION = 3, "¿Seguro desea eliminar registro?", "¿Seguro desea Guardar los cambios?")
        If MsgBox(mensaje, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoPrecioCombustibleExplosivo.Realizo = False
            Return MantenimientoPrecioCombustibleExplosivo
        Else
            MantenimientoPrecioCombustibleExplosivo = Datos.CanteraCosteo.MantenimientoPrecioCombustibleExplosivo(CombustibleExplosivo)
        End If

Salida:

        If MantenimientoPrecioCombustibleExplosivo Is Nothing OrElse MantenimientoPrecioCombustibleExplosivo.Realizo = False Then
            MantenimientoPrecioCombustibleExplosivo = New ETResultado
            MantenimientoPrecioCombustibleExplosivo.Realizo = False
            Return MantenimientoPrecioCombustibleExplosivo
        Else
            mensaje = IIf(OPCION = 3, "Se eliminó con éxito el registro", "Se guardó con éxito el registro")
            MsgBox(mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoPrecioCombustibleExplosivo.Realizo = True
            Return MantenimientoPrecioCombustibleExplosivo
        End If
    End Function

    '   ****    CANTERA - EQUIPO    ****
    Public Function ConsultarUbicacionEquipoCantera(ByVal CanteraViaje As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarUbicacionEquipoCantera(CanteraViaje)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function MantenimientoCanteraEquipo(ByVal CanteraEquipo As ETCanteraCosteo) As ETResultado
        MantenimientoCanteraEquipo = New ETResultado
        List = New List(Of ETCanteraCosteo)

Ingreso:
        Try
            If Not (CanteraEquipo.Opcion = 1) Then
                Return MantenimientoCanteraEquipo
            End If

            If String.IsNullOrEmpty(CanteraEquipo.Tipo) Then
                MsgBox("Ingrese el Tipo de Equipo", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraEquipo
            Else
                CanteraEquipo.Tipo = CanteraEquipo.Tipo.Trim
            End If

            If String.IsNullOrEmpty(CanteraEquipo.Cantera) Then
                MsgBox("Ingrese la Cantera.", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraEquipo
            Else
                CanteraEquipo.Cantera = CanteraEquipo.Cantera.Trim
            End If


            If String.IsNullOrEmpty(CanteraEquipo.NombreEquipo) Then
                MsgBox("Ingrese el Equipo", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraEquipo
            Else
                CanteraEquipo.NombreEquipo = CanteraEquipo.NombreEquipo.Trim
            End If


        Catch err As Exception
            MsgBox(err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraEquipo
        End Try

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraEquipo.Realizo = False
            Return MantenimientoCanteraEquipo
        Else
            MantenimientoCanteraEquipo = Datos.CanteraCosteo.MantenimientoCanteraEquipo(CanteraEquipo)
        End If

Salida:

        If MantenimientoCanteraEquipo Is Nothing OrElse MantenimientoCanteraEquipo.Realizo = False Then
            MantenimientoCanteraEquipo = New ETResultado
            MantenimientoCanteraEquipo.Realizo = False
            Return MantenimientoCanteraEquipo
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraEquipo.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraEquipo.Realizo = True
            Return MantenimientoCanteraEquipo
        End If

    End Function

    Public Function EliminarCanteraEquipo(ByVal Ubicacion As ETCanteraCosteo) As ETResultado
        EliminarCanteraEquipo = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(Ubicacion.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraEquipo
            Else
                Ubicacion.ID = Ubicacion.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraEquipo

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraEquipo.Realizo = False
            Return EliminarCanteraEquipo
        Else
            EliminarCanteraEquipo = Datos.CanteraCosteo.EliminarCanteraEquipo(Ubicacion)
        End If

Salida:

        If EliminarCanteraEquipo Is Nothing OrElse EliminarCanteraEquipo.Realizo = False Then
            EliminarCanteraEquipo = New ETResultado
            EliminarCanteraEquipo.Realizo = False
            Return EliminarCanteraEquipo
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & Ubicacion.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraEquipo.Realizo = True
            Return EliminarCanteraEquipo
        End If
    End Function

    Public Function ValidarCanteraEquipo(ByVal CanteraEquipo As ETCanteraCosteo) As Boolean
        ValidarCanteraEquipo = Datos.CanteraCosteo.ValidarCanteraEquipo(CanteraEquipo)
    End Function

    '   ****    CANTERA - VIGENCIA              ****
    Public Function ConsultarCanteraVigencia(ByVal CanteraVigencia As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarCanteraVigencia(CanteraVigencia)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function MantenimientoCanteraVigencia(ByVal CanteraVigenica As ETCanteraCosteo) As ETResultado
        MantenimientoCanteraVigencia = New ETResultado
        List = New List(Of ETCanteraCosteo)

Ingreso:

        Try

            If Not (CanteraVigenica.Opcion = 1) Then
                Return MantenimientoCanteraVigencia
            End If

            If String.IsNullOrEmpty(CanteraVigenica.Ano) Then
                MsgBox("Ingrese el Periodo", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraVigencia
            Else
                CanteraVigenica.Ano = CanteraVigenica.Ano.ToString
            End If

            If String.IsNullOrEmpty(CanteraVigenica.Cantera) Then
                MsgBox("Ingrese la Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraVigencia
            Else
                CanteraVigenica.Cantera = CanteraVigenica.Cantera.Trim
            End If

            If String.IsNullOrEmpty(CanteraVigenica.Moneda) Then
                MsgBox("Ingrese la Moneda", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraVigencia
            Else
                CanteraVigenica.Moneda = CanteraVigenica.Moneda.Trim
            End If


            If String.IsNullOrEmpty(CanteraVigenica.Importe) Then
                MsgBox("Ingrese el Importe", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraVigencia
            Else
                CanteraVigenica.Importe = CanteraVigenica.Importe.ToString
            End If

            Dim EntVC As New ETCanteraCosteo
            EntVC.ID = IIf(CanteraVigenica.ID Is Nothing, "", CanteraVigenica.ID)
            EntVC.CodigoCantera = CanteraVigenica.CodigoCantera
            EntVC.Ano = CanteraVigenica.Ano
            EntVC.Opcion = 4

            If Datos.CanteraCosteo.ValidarCanteraVigencia(EntVC) Then
                MsgBox("Ya existe un Registro para el Periodo Seleccionado", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraVigencia
            End If
        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraVigencia

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraVigencia.Realizo = False
            Return MantenimientoCanteraVigencia
        Else
            MantenimientoCanteraVigencia = Datos.CanteraCosteo.MantenimientoCanteraVigencia(CanteraVigenica)
        End If

Salida:

        If MantenimientoCanteraVigencia Is Nothing OrElse MantenimientoCanteraVigencia.Realizo = False Then
            MantenimientoCanteraVigencia = New ETResultado
            MantenimientoCanteraVigencia.Realizo = False
            Return MantenimientoCanteraVigencia
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraVigencia.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraVigencia.Realizo = True
            Return MantenimientoCanteraVigencia
        End If
    End Function

    Public Function ValidarCanteraVigencia(ByVal CanteraVigencia As ETCanteraCosteo) As Boolean
        ValidarCanteraVigencia = Datos.CanteraCosteo.ValidarCanteraVigencia(CanteraVigencia)
    End Function

    Public Function EliminarCanteraVigencia(ByVal Vigencia As ETCanteraCosteo) As ETResultado
        EliminarCanteraVigencia = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(Vigencia.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraVigencia
            Else
                Vigencia.ID = Vigencia.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraVigencia

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraVigencia.Realizo = False
            Return EliminarCanteraVigencia
        Else
            EliminarCanteraVigencia = Datos.CanteraCosteo.MantenimientoCanteraVigencia(Vigencia)
        End If

Salida:

        If EliminarCanteraVigencia Is Nothing OrElse EliminarCanteraVigencia.Realizo = False Then
            EliminarCanteraVigencia = New ETResultado
            EliminarCanteraVigencia.Realizo = False
            Return EliminarCanteraVigencia
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & Vigencia.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraVigencia.Realizo = True
            Return EliminarCanteraVigencia
        End If
    End Function

    '   ****    VIDA UTIL DE EQUIPOS            ****
    Public Function ConsultarVidaUtilEquipo(ByVal VidaUtil As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarVidaUtil(VidaUtil)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ListarCanteraVidaUtilEquipo(ByVal VidaUtil As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ListarCanteraVidaUtilEquipo(VidaUtil)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function MantenimientoVidaUtil(ByVal Producto As List(Of ETCanteraCosteo)) As ETResultado
        MantenimientoVidaUtil = New ETResultado
        List = New List(Of ETCanteraCosteo)

Ingreso:

        Try

            If Producto Is Nothing Or Producto.Count = 0 Then
                MsgBox("Debe seleccionar por lo menos un producto", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoVidaUtil
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoVidaUtil

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoVidaUtil.Realizo = False
            Return MantenimientoVidaUtil
        Else
            MantenimientoVidaUtil = Datos.CanteraCosteo.MantenimientoVidaUtil(Producto)
        End If

Salida:

        If MantenimientoVidaUtil Is Nothing OrElse MantenimientoVidaUtil.Realizo = False Then
            MantenimientoVidaUtil = New ETResultado
            MantenimientoVidaUtil.Realizo = False
            Return MantenimientoVidaUtil
        Else
            MsgBox("Se guardó con éxito el registro", MsgBoxStyle.Information, msgComacsa)
            MantenimientoVidaUtil.Realizo = True
            Return MantenimientoVidaUtil
        End If
    End Function

    '   ****    CANTERA -   HORA MAQUINA        ****
    Public Function EliminarCanteraHoraMaquina(ByVal HoraMaquina As ETCanteraCosteo) As ETResultado
        EliminarCanteraHoraMaquina = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(HoraMaquina.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraHoraMaquina
            Else
                HoraMaquina.ID = HoraMaquina.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraHoraMaquina

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraHoraMaquina.Realizo = False
            Return EliminarCanteraHoraMaquina
        Else
            EliminarCanteraHoraMaquina = Datos.CanteraCosteo.MantenimientoCanteraHoraMaquina(HoraMaquina)
        End If

Salida:

        If EliminarCanteraHoraMaquina Is Nothing OrElse EliminarCanteraHoraMaquina.Realizo = False Then
            EliminarCanteraHoraMaquina = New ETResultado
            EliminarCanteraHoraMaquina.Realizo = False
            Return EliminarCanteraHoraMaquina
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & HoraMaquina.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraHoraMaquina.Realizo = True
            Return EliminarCanteraHoraMaquina
        End If
    End Function
    '   ****    CANTERA -   HORAS DISPONIBLES MAQUINARIA   ****
    Public Function EliminarCanteraHoraDisponibleMaquina(ByVal HoraDisponibleMaquina As ETCanteraCosteo) As ETResultado
        EliminarCanteraHoraDisponibleMaquina = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(HoraDisponibleMaquina.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraHoraDisponibleMaquina
            Else
                HoraDisponibleMaquina.ID = HoraDisponibleMaquina.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraHoraDisponibleMaquina
        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraHoraDisponibleMaquina.Realizo = False
            Return EliminarCanteraHoraDisponibleMaquina
        Else
            EliminarCanteraHoraDisponibleMaquina = Datos.CanteraCosteo.MantenimientoCanteraHoraDisponibleMaquina(HoraDisponibleMaquina)
        End If

Salida:

        If EliminarCanteraHoraDisponibleMaquina Is Nothing OrElse EliminarCanteraHoraDisponibleMaquina.Realizo = False Then
            EliminarCanteraHoraDisponibleMaquina = New ETResultado
            EliminarCanteraHoraDisponibleMaquina.Realizo = False
            Return EliminarCanteraHoraDisponibleMaquina
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & HoraDisponibleMaquina.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraHoraDisponibleMaquina.Realizo = True
            Return EliminarCanteraHoraDisponibleMaquina
        End If
    End Function
    Public Function ListarCanteraHoraMaquina(ByVal HoraMaquina As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ListarCanteraHoraMaquina(HoraMaquina)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function MantenimientoCanteraHoraMaquina(ByVal HoraMaquina As ETCanteraCosteo) As ETResultado
        MantenimientoCanteraHoraMaquina = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(HoraMaquina.Cantera) Then
                MsgBox("Ingrese una Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraHoraMaquina
            Else
                HoraMaquina.Cantera = HoraMaquina.Cantera.Trim
            End If

            If String.IsNullOrEmpty(HoraMaquina.NombreEquipo) Then
                MsgBox("Ingrese un equipo", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraHoraMaquina
            Else
                HoraMaquina.NombreEquipo = HoraMaquina.NombreEquipo.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraHoraMaquina

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraHoraMaquina.Realizo = False
            Return MantenimientoCanteraHoraMaquina
        Else
            MantenimientoCanteraHoraMaquina = Datos.CanteraCosteo.MantenimientoCanteraHoraMaquina(HoraMaquina)
        End If

Salida:

        If MantenimientoCanteraHoraMaquina Is Nothing OrElse MantenimientoCanteraHoraMaquina.Realizo = False Then
            MantenimientoCanteraHoraMaquina = New ETResultado
            MantenimientoCanteraHoraMaquina.Realizo = False
            Return MantenimientoCanteraHoraMaquina
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraHoraMaquina.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraHoraMaquina.Realizo = True
            Return MantenimientoCanteraHoraMaquina
        End If
    End Function

    Public Function ValidarCanteraHoraMaquina(ByVal HoraMaquina As ETCanteraCosteo) As Boolean
        ValidarCanteraHoraMaquina = Datos.CanteraCosteo.ValidarCanteraHoraMaquina(HoraMaquina)
    End Function

    Public Function ValidarCanteraHoraMaquina_TotalHoras(ByVal HoraMaquina As ETCanteraCosteo) As Double
        ValidarCanteraHoraMaquina_TotalHoras = Datos.CanteraCosteo.ValidarCanteraHoraMaquina_TotalHoras(HoraMaquina)
    End Function
    '   ****    CANTERA -   HORAS DISPONIBLES MAQUINARIA   ****
    Public Function ListarCanteraHoraDisponibleMaquina(ByVal HoraDiponibleMaquina As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ListarCanteraHoraDisponibleMaquina(HoraDiponibleMaquina)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function MantenimientoCanteraHoraDisponibleMaquina(ByVal HoraDiponibleMaquina As ETCanteraCosteo) As ETResultado
        MantenimientoCanteraHoraDisponibleMaquina = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(HoraDiponibleMaquina.Cantera) Then
                MsgBox("Ingrese una Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraHoraDisponibleMaquina
            Else
                HoraDiponibleMaquina.Cantera = HoraDiponibleMaquina.Cantera.Trim
            End If

            If String.IsNullOrEmpty(HoraDiponibleMaquina.NombreEquipo) Then
                MsgBox("Ingrese un equipo", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraHoraDisponibleMaquina
            Else
                HoraDiponibleMaquina.NombreEquipo = HoraDiponibleMaquina.NombreEquipo.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraHoraDisponibleMaquina

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraHoraDisponibleMaquina.Realizo = False
            Return MantenimientoCanteraHoraDisponibleMaquina
        Else
            MantenimientoCanteraHoraDisponibleMaquina = Datos.CanteraCosteo.MantenimientoCanteraHoraDisponibleMaquina(HoraDiponibleMaquina)
        End If

Salida:

        If MantenimientoCanteraHoraDisponibleMaquina Is Nothing OrElse MantenimientoCanteraHoraDisponibleMaquina.Realizo = False Then
            MantenimientoCanteraHoraDisponibleMaquina = New ETResultado
            MantenimientoCanteraHoraDisponibleMaquina.Realizo = False
            Return MantenimientoCanteraHoraDisponibleMaquina
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraHoraDisponibleMaquina.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraHoraDisponibleMaquina.Realizo = True
            Return MantenimientoCanteraHoraDisponibleMaquina
        End If
    End Function

    Public Function ValidarCanteraHoraDisponibleMaquina(ByVal HoraDisponibleMaquina As ETCanteraCosteo) As Boolean
        ValidarCanteraHoraDisponibleMaquina = Datos.CanteraCosteo.ValidarCanteraHoraDisponibleMaquina(HoraDisponibleMaquina)
    End Function

    '   ****    CANTERA -   DERECHO DE CESION   ****
    Public Function ConsultarCanteraDerechoCesion(ByVal DerechoCesion As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarCanteraDerechoCesion(DerechoCesion)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function EliminarCanteraDerechoCesion(ByVal DerechoCesion As ETCanteraCosteo) As ETResultado
        EliminarCanteraDerechoCesion = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(DerechoCesion.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraDerechoCesion
            Else
                DerechoCesion.ID = DerechoCesion.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraDerechoCesion

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraDerechoCesion.Realizo = False
            Return EliminarCanteraDerechoCesion
        Else
            EliminarCanteraDerechoCesion = Datos.CanteraCosteo.MantenimientoCanteraDerechoCesion(DerechoCesion)
        End If

Salida:

        If EliminarCanteraDerechoCesion Is Nothing OrElse EliminarCanteraDerechoCesion.Realizo = False Then
            EliminarCanteraDerechoCesion = New ETResultado
            EliminarCanteraDerechoCesion.Realizo = False
            Return EliminarCanteraDerechoCesion
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & DerechoCesion.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraDerechoCesion.Realizo = True
            Return EliminarCanteraDerechoCesion
        End If
    End Function

    Public Function MantenimientoCanteraDerechoCesion(ByVal DerechoCesion As ETCanteraCosteo) As ETResultado
        MantenimientoCanteraDerechoCesion = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(DerechoCesion.Cantera) Then
                MsgBox("Ingrese una Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraDerechoCesion
            Else
                DerechoCesion.Cantera = DerechoCesion.Cantera.Trim
            End If


        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraDerechoCesion

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraDerechoCesion.Realizo = False
            Return MantenimientoCanteraDerechoCesion
        Else
            MantenimientoCanteraDerechoCesion = Datos.CanteraCosteo.MantenimientoCanteraDerechoCesion(DerechoCesion)
        End If

Salida:

        If MantenimientoCanteraDerechoCesion Is Nothing OrElse MantenimientoCanteraDerechoCesion.Realizo = False Then
            MantenimientoCanteraDerechoCesion = New ETResultado
            MantenimientoCanteraDerechoCesion.Realizo = False
            Return MantenimientoCanteraDerechoCesion
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraDerechoCesion.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraDerechoCesion.Realizo = True
            Return MantenimientoCanteraDerechoCesion
        End If
    End Function

    Public Function ValidarCanteraDerechoCesion(ByVal HoraMaquina As ETCanteraCosteo) As Boolean
        ValidarCanteraDerechoCesion = Datos.CanteraCosteo.ValidarCanteraDerechoCesion(HoraMaquina)
    End Function

    '   ****    CANTERA -   DONACIONES          ****
    Public Function ConsultarCanteraDonacionesMensual(ByVal Donacion As ETCanteraCosteo) As Double

        Dim lResult As Double = 0

        lResult = Datos.CanteraCosteo.ConsultarCanteraDonacionesMensual(Donacion)

        Return lResult

    End Function

    Public Function ConsultarCanteraDonaciones(ByVal DerechoCesion As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarCanteraDonaciones(DerechoCesion)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function EliminarCanteraDonaciones(ByVal Donaciones As ETCanteraCosteo) As ETResultado
        EliminarCanteraDonaciones = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(Donaciones.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraDonaciones
            Else
                Donaciones.ID = Donaciones.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraDonaciones

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraDonaciones.Realizo = False
            Return EliminarCanteraDonaciones
        Else
            EliminarCanteraDonaciones = Datos.CanteraCosteo.MantenimientoCanteraDonaciones(Donaciones)
        End If

Salida:

        If EliminarCanteraDonaciones Is Nothing OrElse EliminarCanteraDonaciones.Realizo = False Then
            EliminarCanteraDonaciones = New ETResultado
            EliminarCanteraDonaciones.Realizo = False
            Return EliminarCanteraDonaciones
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & Donaciones.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraDonaciones.Realizo = True
            Return EliminarCanteraDonaciones
        End If
    End Function

    Public Function MantenimientoCanteraDonaciones(ByVal DerechoCesion As ETCanteraCosteo) As ETResultado
        MantenimientoCanteraDonaciones = New ETResultado

Ingreso:

        Try

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraDonaciones

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraDonaciones.Realizo = False
            Return MantenimientoCanteraDonaciones
        Else
            MantenimientoCanteraDonaciones = Datos.CanteraCosteo.MantenimientoCanteraDonaciones(DerechoCesion)
        End If

Salida:

        If MantenimientoCanteraDonaciones Is Nothing OrElse MantenimientoCanteraDonaciones.Realizo = False Then
            MantenimientoCanteraDonaciones = New ETResultado
            MantenimientoCanteraDonaciones.Realizo = False
            Return MantenimientoCanteraDonaciones
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraDonaciones.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraDonaciones.Realizo = True
            Return MantenimientoCanteraDonaciones
        End If
    End Function

    Public Function ValidarCanteraDonaciones(ByVal Donaciones As ETCanteraCosteo) As Boolean
        ValidarCanteraDonaciones = Datos.CanteraCosteo.ValidarCanteraDonaciones(Donaciones)
    End Function

    '   ****    CANTERA -   LISTA DE PRECIOS    ****
    Public Function ConsultarCanteraListaPrecio(ByVal ListaPrecio As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarCanteraListaPrecio(ListaPrecio)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function ConsultarCanteraListaPrecioFlete(ByVal ListaPrecio As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarCanteraListaPrecioFlete(ListaPrecio)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarCanteraListaPrecioFletexMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarCanteraListaPrecioFletexMineral(ListaPrecio)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function EliminarCanteraListaPrecio(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        EliminarCanteraListaPrecio = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(ListaPrecio.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraListaPrecio
            Else
                ListaPrecio.ID = ListaPrecio.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraListaPrecio

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraListaPrecio.Realizo = False
            Return EliminarCanteraListaPrecio
        Else
            EliminarCanteraListaPrecio = Datos.CanteraCosteo.MantenimientoCanteraListaPrecio(ListaPrecio)
        End If

Salida:

        If EliminarCanteraListaPrecio Is Nothing OrElse EliminarCanteraListaPrecio.Realizo = False Then
            EliminarCanteraListaPrecio = New ETResultado
            EliminarCanteraListaPrecio.Realizo = False
            Return EliminarCanteraListaPrecio
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & ListaPrecio.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraListaPrecio.Realizo = True
            Return EliminarCanteraListaPrecio
        End If
    End Function
    Public Function EliminarCanteraListaPrecioFlete(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        EliminarCanteraListaPrecioFlete = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(ListaPrecio.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraListaPrecioFlete
            Else
                ListaPrecio.ID = ListaPrecio.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraListaPrecioFlete

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraListaPrecioFlete.Realizo = False
            Return EliminarCanteraListaPrecioFlete
        Else
            EliminarCanteraListaPrecioFlete = Datos.CanteraCosteo.MantenimientoCanteraListaPrecioFlete(ListaPrecio)
        End If

Salida:

        If EliminarCanteraListaPrecioFlete Is Nothing OrElse EliminarCanteraListaPrecioFlete.Realizo = False Then
            EliminarCanteraListaPrecioFlete = New ETResultado
            EliminarCanteraListaPrecioFlete.Realizo = False
            Return EliminarCanteraListaPrecioFlete
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & ListaPrecio.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraListaPrecioFlete.Realizo = True
            Return EliminarCanteraListaPrecioFlete
        End If
    End Function
    Public Function EliminarCanteraListaPrecioFletexMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        EliminarCanteraListaPrecioFletexMineral = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(ListaPrecio.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraListaPrecioFletexMineral
            Else
                ListaPrecio.ID = ListaPrecio.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraListaPrecioFletexMineral

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraListaPrecioFletexMineral.Realizo = False
            Return EliminarCanteraListaPrecioFletexMineral
        Else
            EliminarCanteraListaPrecioFletexMineral = Datos.CanteraCosteo.MantenimientoCanteraListaPrecioFletexMineral(ListaPrecio)
        End If

Salida:

        If EliminarCanteraListaPrecioFletexMineral Is Nothing OrElse EliminarCanteraListaPrecioFletexMineral.Realizo = False Then
            EliminarCanteraListaPrecioFletexMineral = New ETResultado
            EliminarCanteraListaPrecioFletexMineral.Realizo = False
            Return EliminarCanteraListaPrecioFletexMineral
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & ListaPrecio.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraListaPrecioFletexMineral.Realizo = True
            Return EliminarCanteraListaPrecioFletexMineral
        End If
    End Function
    Public Function MantenimientoCanteraListaPrecio(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        MantenimientoCanteraListaPrecio = New ETResultado
        Dim Duplicado As Boolean = Boolean.FalseString
Ingreso:

        Try

            If String.IsNullOrEmpty(ListaPrecio.Proveedor) And ListaPrecio.Tercero = True Then
                MsgBox("Ingrese un Proveedor", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraListaPrecio
            Else
                If String.IsNullOrEmpty(ListaPrecio.Proveedor) Then
                    ListaPrecio.Proveedor = ""
                Else
                    ListaPrecio.Proveedor = ListaPrecio.Proveedor.Trim
                End If

            End If


            If String.IsNullOrEmpty(ListaPrecio.Cantera) Then
                MsgBox("Ingrese una Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraListaPrecio
            Else
                ListaPrecio.Cantera = ListaPrecio.Cantera.Trim
            End If

            If String.IsNullOrEmpty(ListaPrecio.NombreEquipo) Then
                MsgBox("Ingrese un equipo", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraListaPrecio
            Else
                ListaPrecio.NombreEquipo = ListaPrecio.NombreEquipo.Trim
            End If

            Duplicado = Datos.CanteraCosteo.Validar_Duplicidad_CanteraListaPrecio(ListaPrecio).Realizo
            If Duplicado = True Then
                MsgBox("Ya existe un Precio para el Equipo " & Chr(13) & "en la misma Fecha, Proveedor, Cantera", MsgBoxStyle.Critical, msgComacsa)
                Return MantenimientoCanteraListaPrecio
            End If
        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraListaPrecio

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraListaPrecio.Realizo = False
            Return MantenimientoCanteraListaPrecio
        Else
            MantenimientoCanteraListaPrecio = Datos.CanteraCosteo.MantenimientoCanteraListaPrecio(ListaPrecio)
        End If

Salida:

        If MantenimientoCanteraListaPrecio Is Nothing OrElse MantenimientoCanteraListaPrecio.Realizo = False Then
            MantenimientoCanteraListaPrecio = New ETResultado
            MantenimientoCanteraListaPrecio.Realizo = False
            Return MantenimientoCanteraListaPrecio
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraListaPrecio.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraListaPrecio.Realizo = True
            Return MantenimientoCanteraListaPrecio
        End If
    End Function
    Public Function MantenimientoCanteraListaPrecioFlete(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        MantenimientoCanteraListaPrecioFlete = New ETResultado
        Dim Duplicado As Boolean = Boolean.FalseString
Ingreso:

        Try

            If String.IsNullOrEmpty(ListaPrecio.Proveedor) Then
                MsgBox("Ingrese un Proveedor", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraListaPrecioFlete
            Else
                ListaPrecio.Proveedor = ListaPrecio.Proveedor.Trim
            End If


            If String.IsNullOrEmpty(ListaPrecio.Cantera) Then
                MsgBox("Ingrese una Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraListaPrecioFlete
            Else
                ListaPrecio.Cantera = ListaPrecio.Cantera.Trim
            End If

            Duplicado = Datos.CanteraCosteo.Validar_Duplicidad_CanteraListaPrecioFlete(ListaPrecio).Realizo
            If Duplicado = True Then
                MsgBox("Ya existe un Precio la Cantera " & Chr(13) & "en la misma Fecha, Proveedor, Cantera y Moneda", MsgBoxStyle.Critical, msgComacsa)
                Return MantenimientoCanteraListaPrecioFlete
            End If
        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraListaPrecioFlete

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraListaPrecioFlete.Realizo = False
            Return MantenimientoCanteraListaPrecioFlete
        Else
            MantenimientoCanteraListaPrecioFlete = Datos.CanteraCosteo.MantenimientoCanteraListaPrecioFlete(ListaPrecio)
        End If

Salida:

        If MantenimientoCanteraListaPrecioFlete Is Nothing OrElse MantenimientoCanteraListaPrecioFlete.Realizo = False Then
            MantenimientoCanteraListaPrecioFlete = New ETResultado
            MantenimientoCanteraListaPrecioFlete.Realizo = False
            Return MantenimientoCanteraListaPrecioFlete
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraListaPrecioFlete.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraListaPrecioFlete.Realizo = True
            Return MantenimientoCanteraListaPrecioFlete
        End If
    End Function

    Public Function MantenimientoCanteraListaPrecioFletexMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        MantenimientoCanteraListaPrecioFletexMineral = New ETResultado
        Dim Duplicado As Boolean = Boolean.FalseString
Ingreso:

        Try

            If String.IsNullOrEmpty(ListaPrecio.Cantera) Then
                MsgBox("Ingrese una Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraListaPrecioFletexMineral
            Else
                ListaPrecio.Cantera = ListaPrecio.Cantera.Trim
            End If

            If String.IsNullOrEmpty(ListaPrecio.Mineral.Trim) Then
                MsgBox("Ingrese un Mineral", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraListaPrecioFletexMineral
            Else
                ListaPrecio.Mineral = ListaPrecio.Mineral.Trim
            End If

            Duplicado = Datos.CanteraCosteo.Validar_Duplicidad_CanteraListaPrecioFletexMineral(ListaPrecio).Realizo
            If Duplicado = True Then
                MsgBox("Ya existe un Precio la Cantera " & Chr(13) & "en la misma Fecha, Proveedor, Cantera y Moneda", MsgBoxStyle.Critical, msgComacsa)
                Return MantenimientoCanteraListaPrecioFletexMineral
            End If
        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraListaPrecioFletexMineral

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraListaPrecioFletexMineral.Realizo = False
            Return MantenimientoCanteraListaPrecioFletexMineral
        Else
            MantenimientoCanteraListaPrecioFletexMineral = Datos.CanteraCosteo.MantenimientoCanteraListaPrecioFletexMineral(ListaPrecio)
        End If

Salida:

        If MantenimientoCanteraListaPrecioFletexMineral Is Nothing OrElse MantenimientoCanteraListaPrecioFletexMineral.Realizo = False Then
            MantenimientoCanteraListaPrecioFletexMineral = New ETResultado
            MantenimientoCanteraListaPrecioFletexMineral.Realizo = False
            Return MantenimientoCanteraListaPrecioFletexMineral
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraListaPrecioFletexMineral.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraListaPrecioFletexMineral.Realizo = True
            Return MantenimientoCanteraListaPrecioFletexMineral
        End If
    End Function

    '   ****    CANTERA -   DEPRECIACION        ****
    Public Function EliminarCanteraDepreciacion(ByVal CanteraDepreciacion As ETCanteraCosteo) As ETResultado
        EliminarCanteraDepreciacion = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(CanteraDepreciacion.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraDepreciacion
            Else
                CanteraDepreciacion.ID = CanteraDepreciacion.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraDepreciacion

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraDepreciacion.Realizo = False
            Return EliminarCanteraDepreciacion
        Else
            EliminarCanteraDepreciacion = Datos.CanteraCosteo.MantenimientoCanteraDepreciacion(CanteraDepreciacion)
        End If

Salida:

        If EliminarCanteraDepreciacion Is Nothing OrElse EliminarCanteraDepreciacion.Realizo = False Then
            EliminarCanteraDepreciacion = New ETResultado
            EliminarCanteraDepreciacion.Realizo = False
            Return EliminarCanteraDepreciacion
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & CanteraDepreciacion.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraDepreciacion.Realizo = True
            Return EliminarCanteraDepreciacion
        End If
    End Function

    Public Function ListarCanteraDepreciacion(ByVal CanteraDepreciacion As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ListarCanteraDepreciacion(CanteraDepreciacion)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function MantenimientoCanteraDepreciacion(ByVal CanteraDepreciacion As ETCanteraCosteo) As ETResultado
        MantenimientoCanteraDepreciacion = New ETResultado

Ingreso:

        Try

            If String.IsNullOrEmpty(CanteraDepreciacion.Cantera) Then
                MsgBox("Ingrese una Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraDepreciacion
            Else
                CanteraDepreciacion.Cantera = CanteraDepreciacion.Cantera.Trim
            End If

            If String.IsNullOrEmpty(CanteraDepreciacion.NombreEquipo) Then
                MsgBox("Ingrese un Equipo", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraDepreciacion
            Else
                CanteraDepreciacion.NombreEquipo = CanteraDepreciacion.NombreEquipo.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraDepreciacion

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraDepreciacion.Realizo = False
            Return MantenimientoCanteraDepreciacion
        Else
            MantenimientoCanteraDepreciacion = Datos.CanteraCosteo.MantenimientoCanteraDepreciacion(CanteraDepreciacion)
        End If

Salida:

        If MantenimientoCanteraDepreciacion Is Nothing OrElse MantenimientoCanteraDepreciacion.Realizo = False Then
            MantenimientoCanteraDepreciacion = New ETResultado
            MantenimientoCanteraDepreciacion.Realizo = False
            Return MantenimientoCanteraDepreciacion
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraDepreciacion.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraDepreciacion.Realizo = True
            Return MantenimientoCanteraDepreciacion
        End If
    End Function

    '   ****    CANTERA -   COSTO AUTORIZACION  ****
    Public Function EliminarCostoAutorizacion(ByVal CostoAutorizacion As ETCanteraCosteo) As ETResultado
        EliminarCostoAutorizacion = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(CostoAutorizacion.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCostoAutorizacion
            Else
                CostoAutorizacion.ID = CostoAutorizacion.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCostoAutorizacion

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCostoAutorizacion.Realizo = False
            Return EliminarCostoAutorizacion
        Else
            EliminarCostoAutorizacion = Datos.CanteraCosteo.MantenimientoCanteraCostoAutorizacion(CostoAutorizacion)
        End If

Salida:

        If EliminarCostoAutorizacion Is Nothing OrElse EliminarCostoAutorizacion.Realizo = False Then
            EliminarCostoAutorizacion = New ETResultado
            EliminarCostoAutorizacion.Realizo = False
            Return EliminarCostoAutorizacion
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & CostoAutorizacion.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCostoAutorizacion.Realizo = True
            Return EliminarCostoAutorizacion
        End If
    End Function

    Public Function ConsultarCanteraCostoAutorizacionMensual(ByVal Autorizacion As ETCanteraCosteo) As Double

        Dim lResult As Double = 0

        lResult = Datos.CanteraCosteo.ConsultarCanteraCostoAutorizacionMensual(Autorizacion)

        Return lResult

    End Function

    Public Function ConsultarCanteraCostoAutorizacion(ByVal CostoAutorizacion As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarCanteraCostoAutorizacion(CostoAutorizacion)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function MantenimientoCostoAutorizacion(ByVal CostoAutorizacion As ETCanteraCosteo) As ETResultado
        MantenimientoCostoAutorizacion = New ETResultado

Ingreso:

        Try

            If String.IsNullOrEmpty(CostoAutorizacion.Cantera) Then
                MsgBox("Ingrese una Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCostoAutorizacion
            Else
                CostoAutorizacion.Cantera = CostoAutorizacion.Cantera.Trim
            End If


        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCostoAutorizacion

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCostoAutorizacion.Realizo = False
            Return MantenimientoCostoAutorizacion
        Else
            MantenimientoCostoAutorizacion = Datos.CanteraCosteo.MantenimientoCanteraCostoAutorizacion(CostoAutorizacion)
        End If

Salida:

        If MantenimientoCostoAutorizacion Is Nothing OrElse MantenimientoCostoAutorizacion.Realizo = False Then
            MantenimientoCostoAutorizacion = New ETResultado
            MantenimientoCostoAutorizacion.Realizo = False
            Return MantenimientoCostoAutorizacion
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCostoAutorizacion.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCostoAutorizacion.Realizo = True
            Return MantenimientoCostoAutorizacion
        End If
    End Function


    '   ****    CANTERA -  CONTARTISTA    ****
    Public Function ConsultarCanteraContratista(ByVal ListaContratista As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarCanteraContratista(ListaContratista)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function EliminarCanteraContratista(ByVal Contratista As ETCanteraCosteo, ByVal Billete As DataTable, ByVal Personal As DataTable) As ETResultado
        EliminarCanteraContratista = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(Contratista.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraContratista
            Else
                Contratista.ID = Contratista.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraContratista

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraContratista.Realizo = False
            Return EliminarCanteraContratista
        Else
            EliminarCanteraContratista = Datos.CanteraCosteo.MantenimientoCanteraContratista(Contratista, Billete, Personal, Nothing)
        End If

Salida:

        If EliminarCanteraContratista Is Nothing OrElse EliminarCanteraContratista.Realizo = False Then
            EliminarCanteraContratista = New ETResultado
            EliminarCanteraContratista.Realizo = False
            Return EliminarCanteraContratista
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & Contratista.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraContratista.Realizo = True
            Return EliminarCanteraContratista
        End If
    End Function

    Public Function MantenimientoCanteraContratista(ByVal Contratista As ETCanteraCosteo, ByVal Billete As DataTable, ByVal Personal As DataTable, ByVal Billete_Catigo As DataTable) As ETResultado
        MantenimientoCanteraContratista = New ETResultado
        Dim Duplicado As Boolean = Boolean.FalseString
Ingreso:

        Try

            If String.IsNullOrEmpty(Contratista.Proveedor) And Contratista.Tercero = True Then
                MsgBox("Ingrese un Proveedor", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraContratista
            Else
                If String.IsNullOrEmpty(Contratista.Proveedor) Then
                    Contratista.Proveedor = ""
                Else
                    Contratista.Proveedor = Contratista.Proveedor.Trim
                End If

            End If


            If String.IsNullOrEmpty(Contratista.Cantera) Then
                MsgBox("Ingrese una Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraContratista
            Else
                Contratista.Cantera = Contratista.Cantera.Trim
            End If

            If String.IsNullOrEmpty(Contratista.Empleado) Then
                MsgBox("Ingrese un Contratista", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraContratista
            Else
                Contratista.Empleado = Contratista.Empleado.Trim
            End If
            Contratista.Opcion = 4
            Duplicado = Datos.CanteraCosteo.Validar_Duplicidad_CanteraContratista(Contratista).Realizo
            If Duplicado = True Then
                MsgBox("El Contratista ya fue ingresado", MsgBoxStyle.Critical, msgComacsa)
                Return MantenimientoCanteraContratista
            End If
            Contratista.Opcion = 1
        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraContratista

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraContratista.Realizo = False
            Return MantenimientoCanteraContratista
        Else
            MantenimientoCanteraContratista = Datos.CanteraCosteo.MantenimientoCanteraContratista(Contratista, Billete, Personal, Billete_Catigo)
        End If

Salida:

        If MantenimientoCanteraContratista Is Nothing OrElse MantenimientoCanteraContratista.Realizo = False Then
            MantenimientoCanteraContratista = New ETResultado
            MantenimientoCanteraContratista.Realizo = False
            Return MantenimientoCanteraContratista
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraContratista.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraContratista.Realizo = True
            Return MantenimientoCanteraContratista
        End If
    End Function

    Public Function Consultar_Cantera_Contratista_Billete(ByVal Contratista As ETCanteraCosteo) As DataSet
        Return Datos.CanteraCosteo.Consultar_CanteraContratista_Billete(Contratista)
    End Function

    Public Function Consultar_Cantera_Contratista_Billete_Castigo(ByVal Contratista As ETCanteraCosteo) As DataSet
        Return Datos.CanteraCosteo.Consultar_CanteraContratista_Billete_Castigo(Contratista)
    End Function

    Public Function Consultar_Cantera_Contratista_Personal(ByVal Contratista As ETCanteraCosteo) As DataSet
        Return Datos.CanteraCosteo.Consultar_CanteraContratista_Personal(Contratista)
    End Function

    Public Function Consultar_Cantera_Contratista_Personal_Faltas(ByVal Contratista As ETCanteraCosteo) As DataSet
        Return Datos.CanteraCosteo.Consultar_CanteraContratista_Personal_Faltas(Contratista)
    End Function

    Public Function MantenimientoCanteraContratista_Faltas(ByVal Contratista As ETCanteraCosteo, ByVal Anular As List(Of ETPersonal), ByVal Faltas As List(Of ETPersonal)) As ETResultado
        MantenimientoCanteraContratista_Faltas = New ETResultado
        Dim Duplicado As Boolean = Boolean.FalseString
Ingreso:

        Try

            If Val(Contratista.ID) = 0 Then
                MsgBox("Seleccione el ID a añadir faltas", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraContratista_Faltas
            End If


        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraContratista_Faltas

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraContratista_Faltas.Realizo = False
            Return MantenimientoCanteraContratista_Faltas
        Else
            MantenimientoCanteraContratista_Faltas = Datos.CanteraCosteo.MantenimientoCanteraContratista_Faltas(Contratista, Anular, Faltas)
        End If

Salida:

        If MantenimientoCanteraContratista_Faltas Is Nothing OrElse MantenimientoCanteraContratista_Faltas.Realizo = False Then
            MantenimientoCanteraContratista_Faltas = New ETResultado
            MantenimientoCanteraContratista_Faltas.Realizo = False
            Return MantenimientoCanteraContratista_Faltas
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraContratista_Faltas.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraContratista_Faltas.Realizo = True
            Return MantenimientoCanteraContratista_Faltas
        End If
    End Function

    Public Function EliminarCanteraContratista_Faltas(ByVal Contratista As ETCanteraCosteo) As ETResultado
        EliminarCanteraContratista_Faltas = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(Contratista.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraContratista_Faltas
            Else
                Contratista.ID = Contratista.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraContratista_Faltas

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraContratista_Faltas.Realizo = False
            Return EliminarCanteraContratista_Faltas
        Else
            EliminarCanteraContratista_Faltas = Datos.CanteraCosteo.MantenimientoCanteraContratista_Faltas(Contratista, Nothing, Nothing)
        End If

Salida:

        If EliminarCanteraContratista_Faltas Is Nothing OrElse EliminarCanteraContratista_Faltas.Realizo = False Then
            EliminarCanteraContratista_Faltas = New ETResultado
            EliminarCanteraContratista_Faltas.Realizo = False
            Return EliminarCanteraContratista_Faltas
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & Contratista.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraContratista_Faltas.Realizo = True
            Return EliminarCanteraContratista_Faltas
        End If
    End Function

    Public Function MantenimientoCanteraContratista_ListaPrecioMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        MantenimientoCanteraContratista_ListaPrecioMineral = New ETResultado
        Dim Duplicado As Boolean = Boolean.FalseString
Ingreso:

        Try

            If String.IsNullOrEmpty(ListaPrecio.Proveedor) Then
                MsgBox("Ingrese un Proveedor", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraContratista_ListaPrecioMineral
            Else
                ListaPrecio.Proveedor = ListaPrecio.Proveedor.Trim
            End If


            If String.IsNullOrEmpty(ListaPrecio.Cantera) Then
                MsgBox("Ingrese una Cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraContratista_ListaPrecioMineral
            Else
                ListaPrecio.Cantera = ListaPrecio.Cantera.Trim
            End If

            If String.IsNullOrEmpty(ListaPrecio.Mineral) Then
                MsgBox("Ingrese un Mineral", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoCanteraContratista_ListaPrecioMineral
            Else
                ListaPrecio.Mineral = ListaPrecio.Mineral.Trim
            End If

            Duplicado = Datos.CanteraCosteo.Validar_Duplicidad_CanteraContratistaListaPrecioMineral(ListaPrecio).Realizo
            If Duplicado = True Then
                MsgBox("Ya existe un Precio en la Cantera " & Chr(13) & "en la misma Fecha, Proveedor, Cantera y Moneda", MsgBoxStyle.Critical, msgComacsa)
                Return MantenimientoCanteraContratista_ListaPrecioMineral
            End If
        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoCanteraContratista_ListaPrecioMineral

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoCanteraContratista_ListaPrecioMineral.Realizo = False
            Return MantenimientoCanteraContratista_ListaPrecioMineral
        Else
            MantenimientoCanteraContratista_ListaPrecioMineral = Datos.CanteraCosteo.MantenimientoCanteraContratista_ListaPrecioMineral(ListaPrecio)
        End If

Salida:

        If MantenimientoCanteraContratista_ListaPrecioMineral Is Nothing OrElse MantenimientoCanteraContratista_ListaPrecioMineral.Realizo = False Then
            MantenimientoCanteraContratista_ListaPrecioMineral = New ETResultado
            MantenimientoCanteraContratista_ListaPrecioMineral.Realizo = False
            Return MantenimientoCanteraContratista_ListaPrecioMineral
        Else
            MsgBox("Se guardó con éxito el registro N°: " & MantenimientoCanteraContratista_ListaPrecioMineral.Mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoCanteraContratista_ListaPrecioMineral.Realizo = True
            Return MantenimientoCanteraContratista_ListaPrecioMineral
        End If
    End Function

    Public Function EliminarCanteraContratista_ListaPrecioMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        EliminarCanteraContratista_ListaPrecioMineral = New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(ListaPrecio.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return EliminarCanteraContratista_ListaPrecioMineral
            Else
                ListaPrecio.ID = ListaPrecio.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return EliminarCanteraContratista_ListaPrecioMineral

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            EliminarCanteraContratista_ListaPrecioMineral.Realizo = False
            Return EliminarCanteraContratista_ListaPrecioMineral
        Else
            EliminarCanteraContratista_ListaPrecioMineral = Datos.CanteraCosteo.MantenimientoCanteraContratista_ListaPrecioMineral(ListaPrecio)
        End If

Salida:

        If EliminarCanteraContratista_ListaPrecioMineral Is Nothing OrElse EliminarCanteraContratista_ListaPrecioMineral.Realizo = False Then
            EliminarCanteraContratista_ListaPrecioMineral = New ETResultado
            EliminarCanteraContratista_ListaPrecioMineral.Realizo = False
            Return EliminarCanteraContratista_ListaPrecioMineral
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & ListaPrecio.ID, MsgBoxStyle.Information, msgComacsa)
            EliminarCanteraContratista_ListaPrecioMineral.Realizo = True
            Return EliminarCanteraContratista_ListaPrecioMineral
        End If
    End Function

    Public Function ConsultarCanteraContratista_ListaPrecioMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.CanteraCosteo.ConsultarCanteraContratista_ListaPrecioMineral(ListaPrecio)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function Generar_Cantera_Contratista_Esquema1(ByVal Contratista As ETCanteraCosteo) As DataSet
        Return Datos.CanteraCosteo.Generar_CanteraContratista_Esquema1(Contratista)
    End Function

    Public Function EliminarCanteraContratista_Guia_vs_Personal(ByVal Contratista As ETCanteraCosteo) As ETResultado

        Dim lResult As New ETResultado

Ingreso:

        Try
            If String.IsNullOrEmpty(Contratista.ID) Then
                MsgBox("Ingrese el número de Registro", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            Else
                Contratista.ID = Contratista.ID.Trim
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return lResult

        End Try
Operacion:

        If MsgBox("¿Seguro desea Eliminar el Registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            lResult.Realizo = False
            Return lResult
        Else
            lResult = Datos.CanteraCosteo.MantenimientoCanteraContratista_Guia_vs_Personal(Contratista, Nothing, Nothing)
        End If

Salida:

        If lResult Is Nothing OrElse lResult.Realizo = False Then
            lResult = New ETResultado
            lResult.Realizo = False
            Return lResult
        Else
            MsgBox("Se eliminó con éxito el registro N°: " & Contratista.ID, MsgBoxStyle.Information, msgComacsa)
            lResult.Realizo = True
            Return lResult
        End If
    End Function

    Public Function MantenimientoCanteraContratista_Personal_Guia(ByVal Contratista As ETCanteraCosteo, ByVal Anular As List(Of ETPersonal), ByVal PersonalGuia As List(Of ETPersonal)) As ETResultado
        Dim LResult As New ETResultado
        LResult = New ETResultado
        Dim Duplicado As Boolean = Boolean.FalseString
Ingreso:

        Try

            If Val(Contratista.ID) = 0 Then
                MsgBox("Seleccione el ID para enlazar al Personal con las Guías", MsgBoxStyle.Exclamation, msgComacsa)
                Return LResult
            End If


        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return LResult

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            LResult.Realizo = False
            Return LResult
        Else
            LResult = Datos.CanteraCosteo.MantenimientoCanteraContratista_Guia_vs_Personal(Contratista, Anular, PersonalGuia)
        End If

Salida:

        If LResult Is Nothing OrElse LResult.Realizo = False Then
            LResult = New ETResultado
            LResult.Realizo = False
            Return LResult
        Else
            MsgBox("Se guardó con éxito el registro N°: " & LResult.Mensaje, MsgBoxStyle.Information, msgComacsa)
            LResult.Realizo = True
            Return LResult
        End If
    End Function
    Public Function Consultar_Cantera_Contratista_Personal_Guia(ByVal Contratista As ETCanteraCosteo) As DataSet
        Return Datos.CanteraCosteo.Consultar_CanteraContratista_Personal_Guia(Contratista)
    End Function

    Public Function MantenimientoAgrupacion(ByVal Agrupacion As ETCanteraCosteo, ByVal OPCION As Int32) As ETResultado
        MantenimientoAgrupacion = New ETResultado
        List = New List(Of ETCanteraCosteo)

Operacion:
        Dim mensaje As String = String.Empty
        mensaje = IIf(OPCION = 3, "¿Seguro desea eliminar registro?", "¿Seguro desea Guardar los cambios?")
        If MsgBox(mensaje, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoAgrupacion.Realizo = False
            Return MantenimientoAgrupacion
        Else
            MantenimientoAgrupacion = Datos.CanteraCosteo.MantenimientoAgrupacion(Agrupacion)
        End If

Salida:

        If MantenimientoAgrupacion Is Nothing OrElse MantenimientoAgrupacion.Realizo = False Then
            MantenimientoAgrupacion = New ETResultado
            MantenimientoAgrupacion.Realizo = False
            Return MantenimientoAgrupacion
        Else
            'mensaje = IIf(OPCION = 3, "Se eliminó con éxito el registro", "Se guardó con éxito el registro")
            'MsgBox(mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoAgrupacion.Realizo = True
        End If
    End Function

    Public Function MantenimientoAgrupacionRuma(ByVal Agrupacion As ETCanteraCosteo, ByVal OPCION As Int32) As ETResultado
        MantenimientoAgrupacionRuma = New ETResultado
        List = New List(Of ETCanteraCosteo)

Operacion:
        Dim mensaje As String = String.Empty

        MantenimientoAgrupacionRuma = Datos.CanteraCosteo.MantenimientoAgrupacionRuma(Agrupacion)

Salida:

        If MantenimientoAgrupacionRuma Is Nothing OrElse MantenimientoAgrupacionRuma.Realizo = False Then
            MantenimientoAgrupacionRuma = New ETResultado
            MantenimientoAgrupacionRuma.Realizo = False
            Return MantenimientoAgrupacionRuma
        Else
            'mensaje = IIf(OPCION = 3, "Se eliminó con éxito el registro", "Se guardó con éxito el registro")
            'MsgBox(mensaje, MsgBoxStyle.Information, msgComacsa)
            MantenimientoAgrupacionRuma.Realizo = True
        End If
    End Function
End Class
