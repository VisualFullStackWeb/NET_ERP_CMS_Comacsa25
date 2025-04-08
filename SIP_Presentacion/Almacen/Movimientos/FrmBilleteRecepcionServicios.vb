Imports SIP_Entidad
Imports SIP_Negocio

Public Class frmBilleteRecepcionServicios

    '   *****   VARIABLES   *****
    Dim Movimientos As New DataTable
    Dim dtValidarDocumentos As New DataTable
    Dim dtNumeroMovimientoAlmacen As New DataTable
    Dim dtValidarCodigoExiste As New DataTable
    Dim dtSerie As New DataTable
    Dim Serie As String
    Dim NumeroMovimiento As String
    Dim NumeroInternoMovimiento As String
    Private FecRegistro As Date = Date.Now

    '   ****    LISTAS  *****
    Dim DetalleGuia As New List(Of ETGuia)
    Dim Guia As ETGuia

    Dim Pedido As New List(Of ETPedido)

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Locales"

#Region "Listar Movimientos Por Billetes de Control de Servicios"

    Private Sub ListarMovimientoControlServicios(ByVal Documento As String, ByVal Opcion As String)
        With Entidad.Guia
            Dim ab, cd As String
            .Cod_Cia = Companhia
            .NumDoc = Documento
            .Tipo_Doc = "II"
            .Ano = Year(DtFechaConsulta.Value)
            .User_Crea = User_Sistema
            ab = Month(DtFechaConsulta.Value)
            cd = Microsoft.VisualBasic.DateAndTime.Day(DtFechaConsulta.Value)

            If Len(ab) = 1 Then
                .Mes = "0" & Month(DtFechaConsulta.Value)
            Else
                .Mes = Month(DtFechaConsulta.Value)
            End If

            If Len(cd) = 1 Then
                .Mes = "0" & Microsoft.VisualBasic.DateAndTime.Day(DtFechaConsulta.Value)
            Else
                .Dia = Microsoft.VisualBasic.DateAndTime.Day(DtFechaConsulta.Value)
            End If

        End With
        Movimientos = Negocio.Guia.ListarMovimientoOrdenCompra(Entidad.Guia, Opcion)
    End Sub
#End Region

#Region "Listar Documentos Referencia"
    Private Sub ListarDocumentosReferencia()
        With Entidad.Usuario
            .Cod_Cia = Companhia
        End With
        CboDocumentoReferencia.DataSource = Negocio.Usuario.MovimientosAlmacen(Entidad.Usuario, "LDR")

        CboDocumentoReferencia.DisplayMember = "Descripcion"
        CboDocumentoReferencia.ValueMember = "Codigo"
        CboDocumentoReferencia.SelectedIndex = -1
    End Sub
#End Region

#Region "Limpiar"
    Private Sub Limpiar()
        CboDocumentoReferencia.SelectedIndex = -1
        TxtSerieNumeroDocumentoReferencia.Clear()
        TxtNumeroDocumentoReferencia.Clear()
        TxtNumeroOC.Clear()
        TxtCodigoProveedor.Clear()
        TxtRazonSocial.Clear()
        TxtNumeroMovimiento.Clear()
        DtFechaMovimiento.Value = Now
        CboAlmacen.Value = 28

        With Entidad.Guia
            .Cod_Cli = Companhia
            .Num_Ord_Exp = TxtNumeroOC.Text
        End With
        dgvDetalleOC.DataSource = Negocio.Guia.OCPendienteIngresoProductos(Entidad.Guia, "DET")

        CboAnulacion.Value = 0
        GrpAnulacion.Visible = False
        LblEstado.Text = ""
    End Sub
#End Region

#Region "Listar Ordenes de Compra Pendientes de Ingreso - Control de Servicios"
    Private Sub ListarOCControlServicios()
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Fecha = Date.Now
            .Fecha2 = DateAdd(DateInterval.Day, -60, FecRegistro)
        End With
        DgvOCpendientes.DataSource = Negocio.Guia.OCPendienteIngresoProductos(Entidad.Guia, "CS2")
    End Sub
#End Region

#Region "Formato Numero Serie"
    Private Sub FormatoNumerosSerie()
        Select Case Len(TxtSerieNumeroDocumentoReferencia.Text)
            Case 1
                TxtSerieNumeroDocumentoReferencia.Text = "00" & TxtSerieNumeroDocumentoReferencia.Text
            Case 2
                TxtSerieNumeroDocumentoReferencia.Text = "0" & TxtSerieNumeroDocumentoReferencia.Text
            Case Else
                TxtSerieNumeroDocumentoReferencia.Text = TxtSerieNumeroDocumentoReferencia.Text
        End Select
    End Sub
#End Region

#Region "Formato Numero"
    Private Sub FormatoNumero()
        Select Case Len(TxtNumeroDocumentoReferencia.Text)
            Case 1
                TxtNumeroDocumentoReferencia.Text = "0000000000000000" & TxtNumeroDocumentoReferencia.Text
            Case 2
                TxtNumeroDocumentoReferencia.Text = "000000000000000" & TxtNumeroDocumentoReferencia.Text
            Case 3
                TxtNumeroDocumentoReferencia.Text = "00000000000000" & TxtNumeroDocumentoReferencia.Text
            Case 4
                TxtNumeroDocumentoReferencia.Text = "0000000000000" & TxtNumeroDocumentoReferencia.Text
            Case 5
                TxtNumeroDocumentoReferencia.Text = "000000000000" & TxtNumeroDocumentoReferencia.Text
            Case 6
                TxtNumeroDocumentoReferencia.Text = "00000000000" & TxtNumeroDocumentoReferencia.Text
            Case 7
                TxtNumeroDocumentoReferencia.Text = "0000000000" & TxtNumeroDocumentoReferencia.Text
            Case 8
                TxtNumeroDocumentoReferencia.Text = "000000000" & TxtNumeroDocumentoReferencia.Text
            Case 9
                TxtNumeroDocumentoReferencia.Text = "00000000" & TxtNumeroDocumentoReferencia.Text
            Case 10
                TxtNumeroDocumentoReferencia.Text = "0000000" & TxtNumeroDocumentoReferencia.Text
            Case 11
                TxtNumeroDocumentoReferencia.Text = "000000" & TxtNumeroDocumentoReferencia.Text
            Case 12
                TxtNumeroDocumentoReferencia.Text = "00000" & TxtNumeroDocumentoReferencia.Text
            Case 13
                TxtNumeroDocumentoReferencia.Text = "0000" & TxtNumeroDocumentoReferencia.Text
            Case 14
                TxtNumeroDocumentoReferencia.Text = "000" & TxtNumeroDocumentoReferencia.Text
            Case 15
                TxtNumeroDocumentoReferencia.Text = "00" & TxtNumeroDocumentoReferencia.Text
            Case 16
                TxtNumeroDocumentoReferencia.Text = "0" & TxtNumeroDocumentoReferencia.Text
            Case 17
                TxtNumeroDocumentoReferencia.Text = TxtSerieNumeroDocumentoReferencia.Text
        End Select
    End Sub



#End Region

#Region "Validar Documentos Referencia"
    Private Function ValidarDocumentos() As Boolean
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Cod_Cli = TxtCodigoProveedor.Text
            .TipDocRef = CboDocumentoReferencia.Value
            .NumDocRef = TxtSerieNumeroDocumentoReferencia.Text + TxtNumeroDocumentoReferencia.Text
        End With
        dtValidarDocumentos = Negocio.OrdenCompraBL.DocumentosReferencia(Entidad.Guia, "VA1")
    End Function
#End Region

#Region "Validar Numero Movimiento Almacen"
    Private Function ValidarNumeroMovimientoAlmacen() As Boolean
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Tipo_Mov = Trim(CboTipoMovimiento.Value & "")
            .Tipo_Doc = "II"
            .NumDoc = Serie + NumeroMovimiento
        End With
        dtNumeroMovimientoAlmacen = Negocio.OrdenCompraBL.DocumentosReferencia(Entidad.Guia, "VA2")

        If dtNumeroMovimientoAlmacen.Rows.Count > 0 Then
            MsgBox("El número de documento " + Serie + NumeroMovimiento + " ya fue ingresado", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Validar Grabar"
    Private Function ValidarGrabar() As Boolean

        If GrpAnulacion.Visible = True Then
            Return False
        End If

        If LblEstado.Text = "ANULADO" Then
            MsgBox("No se puede modificar un movimiento que esta ANULADO.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If TxtNumeroMovimiento.Text <> "" Then
            Dim x As Integer = 0
            For i As Integer = 0 To dgvDetalleOC.Rows.Count - 1
                If dgvDetalleOC.Rows(i).Cells("Action").Value = 1 Then
                    x = x + 1
                End If
            Next
            If x = 0 Then
                MsgBox("Debe seleccionar por lo menos un ITEM.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If
        End If

        If CboDocumentoReferencia.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un documento de referencia.", MsgBoxStyle.Critical, "Comacsa")
            CboDocumentoReferencia.Focus()
            Return False
        End If

        If TxtSerieNumeroDocumentoReferencia.Text = "" Then
            MsgBox("Debe escribir la serie del documento de referencia.", MsgBoxStyle.Critical, "Comacsa")
            TxtSerieNumeroDocumentoReferencia.Focus()
            Return False
        End If

        If TxtNumeroDocumentoReferencia.Text = "" Then
            MsgBox("Debe escribir el número del documento de referencia.", MsgBoxStyle.Critical, "Comacsa")
            TxtNumeroDocumentoReferencia.Focus()
            Return False
        End If

        Call ValidarDocumentos()
        If dtValidarDocumentos.Rows.Count > 0 Then
            MsgBox("El documento " + (TxtSerieNumeroDocumentoReferencia.Text + TxtNumeroDocumentoReferencia.Text) & " ya fue ingresado para este proveedor.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        For j As Integer = 0 To dgvDetalleOC.Rows.Count - 1
            If dgvDetalleOC.Rows(j).Cells("Action").Value = 1 Then
                With Entidad.Producto
                    .Cod_Cia = Companhia
                    .CodProducto = dgvDetalleOC.Rows(j).Cells("Codigo").Value
                    .TipoProducto = dgvDetalleOC.Rows(j).Cells("TipoProducto").Value
                End With
                dtValidarCodigoExiste = Negocio.Producto.ProductoValidar(Entidad.Producto, "XCO")
                If dtValidarCodigoExiste.Rows.Count <> 1 Then
                    MsgBox("Código del producto " + dgvDetalleOC.Rows(j).Cells("Codigo").Value + " no existe.", MsgBoxStyle.Critical, "Comacsa")
                    Return False
                End If

                If dgvDetalleOC.Rows(j).Cells("Cantidad").Value = 0 Then
                    MsgBox("La cantidad NO puede ser 0 para el producto " + dgvDetalleOC.Rows(j).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                    Return False
                End If

                If dgvDetalleOC.Rows(j).Cells("Cantidad").Value > dgvDetalleOC.Rows(j).Cells("CantidadOC").Value Then
                    MsgBox("La cantidad NO puede ser mayor que la cantida de la OC para el producto " + dgvDetalleOC.Rows(j).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                    Return False
                End If
            End If
        Next

        Return True
    End Function
#End Region

#Region "Validar Anulacion"
    Private Function ValidarAnulacion() As Boolean

        If TxtNumeroMovimiento.Text = "" Then
            Return False
        End If

        If GrpAnulacion.Visible = False And TxtNumeroMovimiento.Text <> "" Then
            GrpAnulacion.Visible = True
            Return False
        End If

        If CboAnulacion.Value = 0 Then
            MsgBox("Debe seleccionar un motivo de anulacion para continuar.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Return True
    End Function
#End Region

#End Region   '   Funciones Locales

#Region "Funciones Públicas"

#Region "Grabar"
    Public Sub Grabar()

        TxtNumeroMovimiento.Focus()
        If ValidarGrabar() = False Then Return
        If MsgBox("¿Esta Seguro de GRABAR el ingreso por Orden.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            For p As Integer = 0 To dgvDetalleOC.Rows.Count - 1
                If dgvDetalleOC.Rows(p).Cells("Action").Value = 1 Then
                    With Entidad.Producto
                        .Cod_Cia = Companhia
                        .Unidad = dgvDetalleOC.Rows(p).Cells("UM").Value
                        .UnidadDesp = dgvDetalleOC.Rows(p).Cells("UnidadIngresoAlmacen").Value
                        .CodProducto = dgvDetalleOC.Rows(p).Cells("Codigo").Value
                    End With
                    Entidad.Resultado = Negocio.Guia.ConvertirIngresoAlmacen(Entidad.Producto, dgvDetalleOC.Rows(p).Cells("Cantidad").Value)
                    If Entidad.Resultado.Realizo = True Then
                        dgvDetalleOC.Rows(p).Cells("CantidadIngresoAlmacen").Value = Entidad.Resultado.Mensaje
                    Else
                        MsgBox("NO se puede convertir el producto " + dgvDetalleOC.Rows(p).Cells("Descripcion").Value + " , consultar con el departamento de SISTEMAS.", MsgBoxStyle.Critical, "Comacsa")
                        Return
                    End If
                End If
            Next
            dgvDetalleOC.Refresh()


            With Entidad.Guia
                .Cod_Cia = Companhia
                .NumDoc = Trim(TxtNumeroMovimiento.Text & "")

                If TxtNumeroMovimiento.Text = "" Then
                    .NumInterno = ""
                Else
                    .NumInterno = DgvBilletesRecepcion.ActiveRow.Cells("NumeroMovimientoInterno").Value
                End If

                .Cod_Alm = CboAlmacen.Value
                .Mov_Stock = "1"
                .User_Crea = User_Sistema
                .PtoVta = "000"
                .NroHrs = "0"
                .CapacTransp = "0"
                .CostoMin = "0"
                .Kilometraje = "0"
                .Peso_Contenedor = "0"
                .Peso_Aduanas = "0"
                .Cod_Labor = ""
                .Cod_Cantera = ""
                .Cod_Cli = Trim(TxtCodigoProveedor.Text & "")
                .RazSoc = Trim(TxtRazonSocial.Text & "")
                .Cod_Per = ""
                .Cod_Area = ""
                .Tipo_DocOri = ""
                .Doc_Ori = ""
                .Status = ""
                If TxtNumeroMovimiento.Text = "" Then
                    .Ruc = DgvOCpendientes.ActiveRow.Cells("RUC").Value
                End If
                .Obs = Trim(TxtObservaciones.Text & "")
                .TipDocRef = CboDocumentoReferencia.Value
                .NumDocRef = Trim(TxtSerieNumeroDocumentoReferencia.Text & "") & Trim(TxtNumeroDocumentoReferencia.Text & "")
                .TipoDespacho = "0"
            End With

            For i As Integer = 0 To dgvDetalleOC.Rows.Count - 1
                If dgvDetalleOC.Rows(i).Cells("Action").Value = 1 Then
                    Guia = New ETGuia

                    With Guia
                        .cod_cia = Companhia                                                 '**
                        .numdoc = Trim(TxtNumeroMovimiento.Text & "")                   '**

                        If TxtNumeroMovimiento.Text = "" Then
                            .NumInterno = ""
                        Else
                            .NumInterno = DgvBilletesRecepcion.ActiveRow.Cells("NumeroMovimientoInterno").Value
                        End If

                        .Cod_Cli = Trim(TxtCodigoProveedor.Text & "")                   '**
                        .item = i + 1                                                   '**
                        .cod_prod = dgvDetalleOC.Rows(i).Cells("Codigo").Value          '**
                        .descrip = dgvDetalleOC.Rows(i).Cells("Descripcion").Value      '**
                        .unid = dgvDetalleOC.Rows(i).Cells("UnidadIngresoAlmacen").Value       '**
                        .cant_ing = dgvDetalleOC.Rows(i).Cells("CantidadIngresoAlmacen").Value '**
                        .moneda = dgvDetalleOC.Rows(i).Cells("Moneda").Value            '**
                        .tipo_cambio = dgvDetalleOC.Rows(i).Cells("TipoCambio").Value   '**
                        .precio = dgvDetalleOC.Rows(i).Cells("Precio").Value            '**
                        .dcto = dgvDetalleOC.Rows(i).Cells("Descuento").Value           '**
                        .total = dgvDetalleOC.Rows(i).Cells("Neto").Value               '**
                        .User_Crea = User_Sistema                                           '**
                        .item_fact = dgvDetalleOC.Rows(i).Cells("Item").Value           '**
                        .cod_prodpdc = dgvDetalleOC.Rows(i).Cells("Codigo").Value       '**
                        .tipprod = dgvDetalleOC.Rows(i).Cells("TipoProducto").Value     '**
                        .codorigen = dgvDetalleOC.Rows(i).Cells("TipoProducto").Value   '**
                        .und_oc = dgvDetalleOC.Rows(i).Cells("UM").Value                '**
                        .cant_oc = dgvDetalleOC.Rows(i).Cells("Cantidad").Value         '**
                        .num_ord_exp = Trim(TxtNumeroOC.Text & "")                      '**
                        .factm = "0"                                                    '**
                        .cant_dev = "0"                                                 '**
                        .movi = "I"                                                     '**
                        .nro_blsini = "0"                                               '**
                        .nro_blsfin = "0"                                               '**
                        .hrs_lab = "0"                                                  '**
                        .peso_bls = "0"                                                 '**
                        .cant_ped = "0"                                                 '**
                        .largo = "0"                                                    '**
                        .ancho = "0"                                                    '**
                        .piezas = "0"                                                   '**
                        .encajado = "0"                                                 '**
                        .lleno = "0"                                                    '**
                        .espesor = "0"                                                  '**
                        .Cod_Empleo = ""                                                '**
                        .Cod_Cantera = ""                                               '**
                        .ctacosto = ""                                                  '**
                        .cod_equipo = ""                                                '**
                        .facturado = ""                                                 '**
                        .valorizacion = "0"                                             '**
                    End With
                    DetalleGuia.Add(Guia)

                End If
            Next


            If TxtNumeroMovimiento.Text = "" Then
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("AGR", CboTipoMovimiento.Value, "II", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)

            Else
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("MOD", CboTipoMovimiento.Value, "II", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)
            End If


            If Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text = "" Then
                MsgBox("Se generó el Billete de Control de Servicios N° " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            ElseIf Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text <> "" Then
                MsgBox("Se modificó el Billete de Control de Servicios N° " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            DetalleGuia = New List(Of ETGuia)

            Call ListarMovimientoControlServicios("", "LTO")
            DgvBilletesRecepcion.DataSource = Movimientos
            TabControlServicios.Tabs("Listar").Selected = True
            Call ListarOCControlServicios()
            Call Limpiar()

        End If
    End Sub
#End Region

#Region "Nuevo"
    Public Sub Nuevo()
        TabControlServicios.Tabs("Billete").Selected = True
        TabIngresoDetalleOC.Tabs("OCPendiente").Selected = True
        Call ListarOCControlServicios()
        TxtNumeroMovimiento.Clear()
        DtFechaMovimiento.Value = Now
        CboAlmacen.Value = 0
        CboDocumentoReferencia.SelectedIndex = -1
        TxtSerieNumeroDocumentoReferencia.Clear()
        TxtCodigoProveedor.Clear()
        TxtRazonSocial.Clear()
        TxtNumeroDocumentoReferencia.Clear()
        TxtNumeroOC.Clear()
        With Entidad.Guia
            .Cod_Cli = Companhia
            .Num_Ord_Exp = TxtNumeroOC.Text
        End With
        dgvDetalleOC.DataSource = Negocio.Guia.OCPendienteIngresoProductos(Entidad.Guia, "DET")


        GrpAnulacion.Visible = False
        CboAnulacion.Value = 0
    End Sub
#End Region

#Region "Buscar"
    Public Sub Buscar()
        If TabControlServicios.Tabs("Listar").Selected = True Then
            If Len(TxtBuscarNumeroDocumento.Text) = 0 Then
                Call ListarMovimientoControlServicios("", "LFE")
                If Movimientos.Rows.Count > 0 Then
                    DgvBilletesRecepcion.DataSource = Movimientos
                Else
                    MsgBox("No existen billete(s) generados el dia " & DtFechaConsulta.Value & " .", MsgBoxStyle.Critical, "Comacsa")
                    TxtBuscarNumeroDocumento.Clear()
                    TxtBuscarNumeroDocumento.Focus()
                    Return
                End If

            Else
                Call ListarMovimientoControlServicios(TxtBuscarNumeroDocumento.Text, "LNU")
                If Movimientos.Rows.Count > 0 Then
                    TabControlServicios.Tabs("Ingreso").Selected = True
                    TabIngresoDetalleOC.Tabs("DetallePendiente").Selected = True
                    TxtNumeroMovimiento.Text = Movimientos.Rows(0).Item("NumeroDocumento")
                    DtFechaMovimiento.Value = Movimientos.Rows(0).Item("Fecha")
                    CboTipoMovimiento.Value = Movimientos.Rows(0).Item("CodigoTipoMovimiento")
                    CboAlmacen.Value = Movimientos.Rows(0).Item("CodigoAlmacen")
                    TxtSerieNumeroDocumentoReferencia.Text = Mid((Movimientos.Rows(0).Item("NumeroDocumentoReferencia")), 1, 3)
                    TxtNumeroDocumentoReferencia.Text = Mid((Movimientos.Rows(0).Item("NumeroDocumentoReferencia")), 4, 17)
                    TxtCodigoProveedor.Text = Trim(Movimientos.Rows(0).Item("CodigoProveedor") & "")
                    TxtRazonSocial.Text = Trim(Movimientos.Rows(0).Item("RazonSocial") & "")
                    TxtObservaciones.Text = Movimientos.Rows(0).Item("Observaciones")
                    CboDocumentoReferencia.Value = Movimientos.Rows(0).Item("TipoDocumentoReferencia")
                    TxtNumeroOC.Text = Movimientos.Rows(0).Item("NumeroOC")
                    LblEstado.Text = Movimientos.Rows(0).Item("Estado")

                    With Entidad.Guia
                        .Cod_Cia = Companhia
                        .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
                    End With
                    dgvDetalleOC.DataSource = Negocio.Guia.ListarDetalleIngresoOC(Entidad.Guia)

                    For p As Integer = 0 To dgvDetalleOC.Rows.Count - 1
                        With Entidad.Producto
                            .Cod_Cia = Companhia
                            .Unidad = dgvDetalleOC.Rows(p).Cells("UnidadIngresoAlmacen").Value
                            .UnidadDesp = dgvDetalleOC.Rows(p).Cells("UM").Value
                            .CodProducto = dgvDetalleOC.Rows(p).Cells("Codigo").Value
                        End With
                        Entidad.Resultado = Negocio.Guia.ConvertirIngresoAlmacen(Entidad.Producto, dgvDetalleOC.Rows(p).Cells("CantidadIngresoAlmacen").Value)
                        If Entidad.Resultado.Realizo = True Then
                            dgvDetalleOC.Rows(p).Cells("Cantidad").Value = Entidad.Resultado.Mensaje
                        Else
                            MsgBox("NO se puede convertir el producto " + dgvDetalleOC.Rows(p).Cells("Descripcion").Value + " , consultar con el departamento de SISTEMAS.", MsgBoxStyle.Critical, "Comacsa")
                            Return
                        End If
                    Next
                    dgvDetalleOC.Refresh()

                Else
                    MsgBox("El billete " & TxtBuscarNumeroDocumento.Text & " NO existe.", MsgBoxStyle.Critical, "Comacsa")
                    TxtBuscarNumeroDocumento.Clear()
                    TxtBuscarNumeroDocumento.Focus()
                    Return
                End If
            End If
        End If
    End Sub
#End Region

#Region "Eliminar"
    Public Sub Eliminar()
        If TabControlServicios.Tabs("Listar").Selected = True Then
            TabControlServicios.Tabs("Billete").Selected = True
            TabIngresoDetalleOC.Tabs("DetallePendiente").Selected = True
            GrpAnulacion.Visible = True

            TxtNumeroMovimiento.Text = DgvBilletesRecepcion.ActiveRow.Cells("NumeroDocumento").Value
            CboAlmacen.Value = DgvBilletesRecepcion.ActiveRow.Cells("CodigoAlmacen").Value
            CboDocumentoReferencia.Value = DgvBilletesRecepcion.ActiveRow.Cells("TipoDocumentoReferencia").Value
            TxtSerieNumeroDocumentoReferencia.Text = Mid((DgvBilletesRecepcion.ActiveRow.Cells("NumeroDocumentoReferencia").Value), 1, 3)
            TxtNumeroDocumentoReferencia.Text = Mid((DgvBilletesRecepcion.ActiveRow.Cells("NumeroDocumentoReferencia").Value), 4, 17)
            TxtCodigoProveedor.Text = Trim(DgvBilletesRecepcion.ActiveRow.Cells("CodigoProveedor").Value & "")
            TxtRazonSocial.Text = DgvBilletesRecepcion.ActiveRow.Cells("RazonSocial").Value
            TxtObservaciones.Text = DgvBilletesRecepcion.ActiveRow.Cells("Observaciones").Value
            TxtNumeroOC.Text = DgvBilletesRecepcion.ActiveRow.Cells("NumeroOC").Value

            With Entidad.Guia
                .Cod_Cia = Companhia
                .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
            End With
            dgvDetalleOC.DataSource = Negocio.Guia.ListarDetalleIngresoOC(Entidad.Guia)

            For p As Integer = 0 To dgvDetalleOC.Rows.Count - 1
                With Entidad.Producto
                    .Cod_Cia = Companhia
                    .Unidad = dgvDetalleOC.Rows(p).Cells("UnidadIngresoAlmacen").Value
                    .UnidadDesp = dgvDetalleOC.Rows(p).Cells("UM").Value
                    .CodProducto = dgvDetalleOC.Rows(p).Cells("Codigo").Value
                End With
                Entidad.Resultado = Negocio.Guia.ConvertirIngresoAlmacen(Entidad.Producto, dgvDetalleOC.Rows(p).Cells("CantidadIngresoAlmacen").Value)
                If Entidad.Resultado.Realizo = True Then
                    dgvDetalleOC.Rows(p).Cells("Cantidad").Value = Entidad.Resultado.Mensaje
                End If
            Next
            Return
        End If

        If ValidarAnulacion() = False Then Return
        If MsgBox("¿Esta Seguro de ELIMINAR el Billete de Recepción de Servicios.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            With Entidad.Guia
                .Cod_Cia = Companhia
                .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
                .Motivo = CboAnulacion.Value
                .User_Crea = User_Sistema
                .Tipo_Doc = "II"
                .Tipo_Mov = CboTipoMovimiento.Value
            End With

            For j As Integer = 0 To dgvDetalleOC.Rows.Count - 1
                Guia = New ETGuia
                With Guia
                    .cod_cia = Companhia
                    .num_ord_exp = Trim(TxtNumeroOC.Text & "")
                    .item = dgvDetalleOC.Rows(j).Cells("Item").Value
                    .tipprod = dgvDetalleOC.Rows(j).Cells("TipoProducto").Value
                    .cod_prod = dgvDetalleOC.Rows(j).Cells("Codigo").Value
                    .cant_ped = dgvDetalleOC.Rows(j).Cells("Cantidad").Value
                    .User_Crea = User_Sistema
                End With
                DetalleGuia.Add(Guia)
            Next

            Entidad.Resultado = Negocio.Guia.EliminarMovimiento(Entidad.Guia, DetalleGuia)

            If Entidad.Resultado.Realizo = True Then
                MsgBox("La anulación del Billete de Control de Servicios " & Trim(TxtNumeroMovimiento.Text & "") & " se realizó con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            DetalleGuia = New List(Of ETGuia)

            Call ListarMovimientoControlServicios("", "LTO")
            DgvBilletesRecepcion.DataSource = Movimientos
            TabControlServicios.Tabs("Listar").Selected = True
            Call ListarOCControlServicios()
            Call Limpiar()
        End If

    End Sub
#End Region

#End Region  '   Funciones Publicas

#Region "Load"
    Private Sub FrmBilleteRecepcionServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarCia(Cia3)
        Call ListarOCControlServicios()
        Call ListarMotivoAnulacion(CboAnulacion)
        Call ListarAlmacenUsuarios(CboAlmacen, "28")
        Call ListarMovimientosUsuario(CboTipoMovimiento, "41")
        Call ListarMovimientoControlServicios("", "LTO")
        DgvBilletesRecepcion.DataSource = Movimientos
        Call ListarDocumentosReferencia()
        DtFechaConsulta.Value = Now
        DtFechaMovimiento.Value = Now
    End Sub
#End Region                '   Load

#Region "Evento Controles"

#Region "DgvOCpendientes_DoubleClickRow"
    Private Sub DgvOCpendientes_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvOCpendientes.DoubleClickRow
        CboDocumentoReferencia.SelectedIndex = -1
        TxtSerieNumeroDocumentoReferencia.Clear()
        TxtNumeroDocumentoReferencia.Clear()
        TabIngresoDetalleOC.Tabs("DetallePendiente").Selected = True
        CboAlmacen.Value = Trim(e.Row.Cells("CodigoAlmacen").Value & "")
        TxtCodigoProveedor.Text = Trim(e.Row.Cells("CodigoProveedor").Value & "")
        TxtRazonSocial.Text = Trim(e.Row.Cells("RazonSocial").Value & "")
        TxtNumeroOC.Text = Trim(e.Row.Cells("NumeroOC").Value & "")
        TxtObservaciones.Text = Trim(e.Row.Cells("Observaciones").Value & "")
        TxtNumeroMovimiento.Clear()
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Num_Ord_Exp = TxtNumeroOC.Text
        End With
        dgvDetalleOC.DataSource = Negocio.Guia.OCPendienteIngresoProductos(Entidad.Guia, "DET")
    End Sub
#End Region

#Region "DgvBilletesRecepcion - DoubleClickRow"
    Private Sub DgvBilletesRecepcion_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvBilletesRecepcion.DoubleClickRow
        TxtNumeroMovimiento.Text = e.Row.Cells("NumeroDocumento").Value
        TabControlServicios.Tabs("Billete").Selected = True
        TabIngresoDetalleOC.Tabs("DetallePendiente").Selected = True
        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        CboDocumentoReferencia.Value = e.Row.Cells("TipoDocumentoReferencia").Value
        TxtSerieNumeroDocumentoReferencia.Text = Mid((e.Row.Cells("NumeroDocumentoReferencia").Value), 1, 3)
        TxtNumeroDocumentoReferencia.Text = Mid((e.Row.Cells("NumeroDocumentoReferencia").Value), 4, 17)
        TxtCodigoProveedor.Text = Trim(e.Row.Cells("CodigoProveedor").Value & "")
        TxtRazonSocial.Text = e.Row.Cells("RazonSocial").Value
        TxtObservaciones.Text = e.Row.Cells("Observaciones").Value
        TxtNumeroOC.Text = e.Row.Cells("NumeroOC").Value
        LblEstado.Text = e.Row.Cells("Estado").Value

        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
            .Tipo_Doc = "II"
            .Tipo_Mov = "41"
        End With
        dgvDetalleOC.DataSource = Negocio.Guia.ListarDetalleIngresoOC(Entidad.Guia)

        For p As Integer = 0 To dgvDetalleOC.Rows.Count - 1
            With Entidad.Producto
                .Cod_Cia = Companhia
                .Unidad = dgvDetalleOC.Rows(p).Cells("UnidadIngresoAlmacen").Value
                .UnidadDesp = dgvDetalleOC.Rows(p).Cells("UM").Value
                .CodProducto = dgvDetalleOC.Rows(p).Cells("Codigo").Value
            End With
            Entidad.Resultado = Negocio.Guia.ConvertirIngresoAlmacen(Entidad.Producto, dgvDetalleOC.Rows(p).Cells("CantidadIngresoAlmacen").Value)
            If Entidad.Resultado.Realizo = True Then
                dgvDetalleOC.Rows(p).Cells("Cantidad").Value = Entidad.Resultado.Mensaje
            Else
                MsgBox("NO se puede convertir el producto " + dgvDetalleOC.Rows(p).Cells("Descripcion").Value + " , consultar con el departamento de SISTEMAS.", MsgBoxStyle.Critical, "Comacsa")
                Return
            End If
        Next
        dgvDetalleOC.Refresh()
    End Sub
#End Region

#Region "BtnSalir - Click"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        GrpAnulacion.Visible = False
        CboAnulacion.Value = 0
    End Sub
#End Region

#Region "TxtSerieNumeroDocumentoReferencia - AfterExitEditMode"
    Private Sub TxtSerieNumeroDocumentoReferencia_AfterExitEditMode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSerieNumeroDocumentoReferencia.AfterExitEditMode
        Call FormatoNumerosSerie()
    End Sub
#End Region

#Region "TxtNumeroDocumentoReferencia - AfterExitEditMode"
    Private Sub TxtNumeroDocumentoReferencia_AfterExitEditMode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumeroDocumentoReferencia.AfterExitEditMode
        Call FormatoNumero()
    End Sub
#End Region

#End Region    '   Evento Controles

End Class