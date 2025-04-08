Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmSalidaDevolucion
    '   *****   VARIABLES   *****
    Dim Movimientos As New DataTable
    Dim dtSerie As New DataTable
    Dim dtNumeroMovimientoAlmacen As New DataTable

    Dim Serie As String
    Dim NumeroMovimiento As String
    Dim NumeroInternoMovimiento As String
    Dim xNumeroSalidaDevolucion As String
    Dim xNumeroInternoSalidaDevolucion As String
    Dim xTipoCambio As String

    Private FecRegistro As Date = Date.Now


    '   *****   LISTAS  *****
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

#Region "Listar Documentos Referencia"
    Private Sub ListarDocumentosReferencia()
        With Entidad.Usuario
            .Cod_Cia = Companhia
        End With
        CboDocumentoReferencia.DataSource = Negocio.Usuario.MovimientosAlmacen(Entidad.Usuario, "LDR")
        CboDocumentoReferencia.DisplayMember = "Descripcion"
        CboDocumentoReferencia.ValueMember = "Codigo"
        CboDocumentoReferencia.Value = "OC"
    End Sub
#End Region

#Region "Listar Movimientos Por Orden Compra"

    Private Sub ListarMovimientoSalidaDevolucion(ByVal Documento As String, ByVal Opcion As String)
        With Entidad.Guia
            Dim ab, cd As String
            .Cod_Cia = Companhia
            .NumDoc = Documento
            .Tipo_Doc = "SD"
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

#Region "Listar Ordenes de Compra con Ingreso en Almacén"
    Private Sub ListarCabeceraOrdenesIngresoAlmacen()
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Fecha = Date.Now
            .Fecha2 = DateAdd(DateInterval.Day, -60, FecRegistro)
        End With
        DgvOC.DataSource = Negocio.Guia.OCIngresoAlmacen(Entidad.Guia, "CAB")
    End Sub
#End Region

#Region "Validar Grabar"
    Private Function ValidarGrabar() As Boolean
        Dim x_Stock As Decimal

        With Entidad.Almacen
            .Cod_Cia = Companhia
            .CodAlmacen = CboAlmacen.Value
        End With
        dtSerie = Negocio.Almacen.Listar_Almacen(Entidad.Almacen, "GEN")
        If dtSerie.Rows.Count = 0 Then
            MsgBox("Debe definir la serie para movimiento INGRESO POR O/C.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If


        If TxtNumeroMovimiento.Text <> "" Then
            Return False
        End If

        If TxtObservaciones.Text = "" Then
            MsgBox("Debe escribir un motivo.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        For j As Integer = 0 To dgvDetalleOC.Rows.Count - 1
            If CDbl(dgvDetalleOC.Rows(j).Cells("Cantidad").Value) = 0 Then
                MsgBox("La cantidad a devolver debe ser mayor a 0 para el producto." + dgvDetalleOC.Rows(j).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                Call UbicarCursorGrilla(dgvDetalleOC, dgvDetalleOC.Rows(j), "Cantidad")
                Return False
            End If

            With Entidad.Requerimiento
                .Cod_Cia = Companhia
                .Lugar_Ent = CboAlmacen.Value
                .CodigoProducto = dgvDetalleOC.Rows(j).Cells("Codigo").Value
            End With

            Entidad.Resultado = Negocio.Requerimiento.StockMesAnterior(Entidad.Requerimiento, "5")
            x_Stock = Entidad.Resultado.Mensaje


            If CDbl(x_Stock) < CDbl(dgvDetalleOC.Rows(j).Cells("Cantidad").Value) Then
                MsgBox("El Stock Actual es:  " + x_Stock + " " + dgvDetalleOC.Rows(j).Cells("UM").Value + " para el producto." + dgvDetalleOC.Rows(j).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                dgvDetalleOC.Rows(j).Cells("Cantidad").Value = 0
                Call UbicarCursorGrilla(dgvDetalleOC, dgvDetalleOC.Rows(j), "Cantidad")
                Return False
            End If
        Next

        Return True
    End Function
#End Region

#Region "Validar Numero Movimiento Almacen"
    Private Function ValidarNumeroMovimientoAlmacen() As Boolean
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Tipo_Mov = Trim(CboTipoMovimiento.Value & "")
            .Tipo_Doc = "SD"
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

#Region "Limpiar"
    Private Sub Limpiar()
        TxtNumeroOC.Clear()
        TxtCodigoProveedor.Clear()
        TxtRazonSocial.Clear()
        TxtNumeroMovimiento.Clear()
        DtFechaMovimiento.Value = Now
        CboAlmacen.Value = 28
        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = "0000000"
            .Tipo_Mov = "19"
            .Tipo_Doc = "SD"
        End With
        dgvDetalleOC.DataSource = Negocio.Guia.ListarDetalleSalidaDevolucion(Entidad.Guia)
        CboAnulacion.Value = 0
        GrpAnulacion.Visible = False
        LblEstado.Text = ""
    End Sub
#End Region

#End Region   '   Funciones Locales

#Region "Funciones Publicas"

#Region "Nuevo"
    Public Sub Nuevo()
        TabSalidaDevolucion.Tabs("Salida").Selected = True
        TabIngresoDetalleOC.Tabs("OCPendiente").Selected = True
        Call ListarCabeceraOrdenesIngresoAlmacen()
        TxtNumeroMovimiento.Clear()
        DtFechaMovimiento.Value = Now
        CboAlmacen.Value = "28"
        TxtCodigoProveedor.Clear()
        TxtRazonSocial.Clear()
        TxtNumeroOC.Clear()

        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = "0000000"
            .Tipo_Mov = "19"
            .Tipo_Doc = "SD"
        End With
        dgvDetalleOC.DataSource = Negocio.Guia.ListarDetalleSalidaDevolucion(Entidad.Guia)
        GrpAnulacion.Visible = False
        CboAnulacion.Value = 0
        LblEstado.Text = ""
        RdbReposicion.Checked = True
    End Sub

#End Region

#Region "Grabar"
    Public Sub Grabar()

        TxtNumeroMovimiento.Focus()
        If ValidarGrabar() = False Then Return
        xTipoCambio = TipoCambio()
        If MsgBox("¿Esta Seguro de GRABAR la Salidad por Devolución.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            With Entidad.Guia
                .Cod_Cia = Companhia
                .Tipo_Doc = "SD"
                .Tipo_Mov = CboTipoMovimiento.Value
                .NumDoc = xNumeroSalidaDevolucion
                .NumInterno = xNumeroInternoSalidaDevolucion
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
                .Ruc = DgvOC.ActiveRow.Cells("RUC").Value
                .Obs = Trim(TxtObservaciones.Text & "")
                .TipDocRef = CboDocumentoReferencia.Value
                .TipoDespacho = "0"
                If RdbReposicion.Checked = True Then
                    .Motivo = ""
                Else
                    .Motivo = "N"
                End If
            End With


            For i As Integer = 0 To dgvDetalleOC.Rows.Count - 1
                Guia = New ETGuia
                With Guia
                    .cod_cia = Companhia                                                                 '**
                    .tipo_mov = CboTipoMovimiento.Value                                             '**
                    .tipo_doc = "SD"                                                                '**
                    .numdoc = xNumeroSalidaDevolucion                                               '**
                    .numInterno = xNumeroInternoSalidaDevolucion                                    '**
                    .cod_cli = Trim(TxtCodigoProveedor.Text & "")                                   '**
                    .item = dgvDetalleOC.Rows(i).Cells("Item").Value                                                                   '**
                    .cod_prod = dgvDetalleOC.Rows(i).Cells("Codigo").Value                          '**
                    .descrip = dgvDetalleOC.Rows(i).Cells("Descripcion").Value                      '**
                    .unid = dgvDetalleOC.Rows(i).Cells("UM").Value                '**
                    .cant_ing = dgvDetalleOC.Rows(i).Cells("Cantidad").Value          '**
                    .moneda = dgvDetalleOC.Rows(i).Cells("Moneda").Value                            '**
                    .tipo_cambio = dgvDetalleOC.Rows(i).Cells("TipoCambio").Value                   '**
                    .precio = dgvDetalleOC.Rows(i).Cells("Precio").Value                            '**
                    .dcto = dgvDetalleOC.Rows(i).Cells("Descuento").Value                           '**
                    .total = dgvDetalleOC.Rows(i).Cells("Neto").Value                               '**
                    .User_Crea = User_Sistema                                                          '**
                    .item_fact = dgvDetalleOC.Rows(i).Cells("Item").Value                                                               '** Este debe cambiar viene del Ingreso x OC                  '**
                    .cod_prodpdc = dgvDetalleOC.Rows(i).Cells("Codigo").Value                       '**
                    .tipprod = dgvDetalleOC.Rows(i).Cells("TipoProducto").Value                     '**
                    .codorigen = dgvDetalleOC.Rows(i).Cells("TipoProducto").Value                   '** Este debe cambiar hay que seguir la secuencia desde el registro de los productos   '**
                    .und_oc = dgvDetalleOC.Rows(i).Cells("UM").Value                                '**
                    .cant_oc = dgvDetalleOC.Rows(i).Cells("Cantidad").Value                         '**
                    .num_ord_exp = Trim(dgvDetalleOC.Rows(i).Cells("NroOC").Value & "")                     '**
                    .numInternoexp = Trim(dgvDetalleOC.Rows(i).Cells("DocumentoIngresoAlmacen").Value & "")    '**
                    .factm = "0"                                                                    '**
                    .cant_dev = "0"                                                                 '**
                    .movi = "S"                                                                     '**
                    .nro_blsini = "0"                                                               '**
                    .nro_blsfin = "0"                                                               '**
                    .hrs_lab = "0"                                                                  '**
                    .peso_bls = "0"                                                                 '**
                    .cant_ped = "0"                                                                 '**
                    .largo = "0"                                                                    '**
                    .ancho = "0"                                                                    '**
                    .piezas = "0"                                                                   '**
                    .encajado = "0"                                                                 '**
                    .lleno = "0"                                                                    '**
                    .espesor = "0"                                                                  '**
                    .Cod_Empleo = ""                                                                '**
                    .Cod_Cantera = ""                                                               '**
                    .ctacosto = ""                                                                  '**
                    .cod_equipo = ""                                                                '**
                    .facturado = ""                                                                 '**
                    .valorizacion = "0"

                    With Entidad.Producto
                        .Cod_Cia = Companhia
                        .Unidad = dgvDetalleOC.Rows(i).Cells("UM").Value
                        .UnidadDesp = dgvDetalleOC.Rows(i).Cells("UM_Desp").Value
                        .CodProducto = dgvDetalleOC.Rows(i).Cells("Codigo").Value
                    End With


                    Entidad.Resultado = Negocio.Guia.ConvertirIngresoAlmacen(Entidad.Producto, dgvDetalleOC.Rows(i).Cells("Cantidad").Value)
                    .Cant_Anterior = CDbl(Entidad.Resultado.Mensaje)

                End With
                DetalleGuia.Add(Guia)

            Next

            Entidad.Resultado = Negocio.Guia.GrabarMovimiento("AGR", CboTipoMovimiento.Value.ToString, "SD", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)

            If Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text = "" Then
                MsgBox("Se generó la Salida por Devolución N° " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            DetalleGuia = New List(Of ETGuia)

            Call ListarMovimientoSalidaDevolucion("", "LTO")
            DgvMovimientosSalidaDevolucion.DataSource = Movimientos
            TabSalidaDevolucion.Tabs("Listar").Selected = True
            Call ListarCabeceraOrdenesIngresoAlmacen()
            Call Limpiar()
        End If
    End Sub
#End Region

#Region "Eliminar"
    Public Sub Eliminar()
        If TabSalidaDevolucion.Tabs("Listar").Selected = True Then

            TabSalidaDevolucion.Tabs("Salida").Selected = True
            TabIngresoDetalleOC.Tabs("DetallePendiente").Selected = True
            GrpAnulacion.Visible = True
            TxtNumeroMovimiento.Text = DgvMovimientosSalidaDevolucion.ActiveRow.Cells("NumeroDocumento").Value
            CboAlmacen.Value = DgvMovimientosSalidaDevolucion.ActiveRow.Cells("CodigoAlmacen").Value
            TxtCodigoProveedor.Text = Trim(DgvMovimientosSalidaDevolucion.ActiveRow.Cells("CodigoProveedor").Value & "")
            TxtRazonSocial.Text = DgvMovimientosSalidaDevolucion.ActiveRow.Cells("RazonSocial").Value
            TxtObservaciones.Text = DgvMovimientosSalidaDevolucion.ActiveRow.Cells("Observaciones").Value
            TxtNumeroOC.Text = DgvMovimientosSalidaDevolucion.ActiveRow.Cells("NumeroOC").Value

            With Entidad.Guia
                .Cod_Cia = Companhia
                .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
            End With
            DgvOC.DataSource = Negocio.Guia.ListarDetalleIngresoOC(Entidad.Guia)
            Return
        End If

        If ValidarAnulacion() = False Then Return
        If MsgBox("¿Esta Seguro de ELIMINAR el Ingreso por Orden.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            With Entidad.Guia
                .Cod_Cia = Companhia
                .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
                .Motivo = CboAnulacion.Value
                .User_Crea = User_Sistema
                .Tipo_Doc = "SD"
                .Tipo_Mov = "19"
            End With
            Entidad.Resultado = Negocio.Guia.EliminarMovimiento(Entidad.Guia, DetalleGuia)

            If Entidad.Resultado.Realizo = True Then
                MsgBox("La anulación de la Salida Por Devolución " & Trim(TxtNumeroMovimiento.Text & "") & " se realizó con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            DetalleGuia = New List(Of ETGuia)

            Call ListarMovimientoSalidaDevolucion("", "LTO")
            DgvMovimientosSalidaDevolucion.DataSource = Movimientos
            TabSalidaDevolucion.Tabs("Listar").Selected = True
            Call ListarCabeceraOrdenesIngresoAlmacen()
            Call Limpiar()
        End If

    End Sub
#End Region

#End Region  '   Funciones Publicas

#Region "Load"
    Private Sub FrmSalidaDevolucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListarCia(Cia1)
        ListarCia(Cia2)
        ListarCia(Cia3)
        Call ListarMovimientosUsuario(CboTipoMovimiento, "19")
        Call ListarAlmacenUsuarios(CboAlmacen, "28")
        Call ListarDocumentosReferencia()
        Call ListarMovimientoSalidaDevolucion("", "LTO")
        DgvMovimientosSalidaDevolucion.DataSource = Movimientos
        DtFechaConsulta.Value = Now
        DtFechaMovimiento.Value = Now
        Call ListarCabeceraOrdenesIngresoAlmacen()
        Call ListarMotivoAnulacion(CboAnulacion)
    End Sub
#End Region                '   Load

#Region "Evento Controles"

#Region "DgvOC - DoubleClickRow"
    Private Sub DgvOC_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvOC.DoubleClickRow
        TxtNumeroMovimiento.Clear()
        TabIngresoDetalleOC.Tabs("DetallePendiente").Selected = True
        CboAlmacen.Value = Trim(e.Row.Cells("CodigoAlmacen").Value & "")
        TxtCodigoProveedor.Text = Trim(e.Row.Cells("CodigoProveedor").Value & "")
        TxtRazonSocial.Text = Trim(e.Row.Cells("RazonSocial").Value & "")
        TxtNumeroOC.Text = Trim(e.Row.Cells("NumeroOC").Value & "")
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Num_Ord_Exp = TxtNumeroOC.Text
        End With
        dgvDetalleOC.DataSource = Negocio.Guia.OCIngresoAlmacen(Entidad.Guia, "DET")

        dgvDetalleOC.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Activation.AllowEdit
        RdbReposicion.Checked = True
    End Sub
#End Region

#Region "DgvMovimientosSalidaDevolucion - DoubleClickRow"
    Private Sub DgvMovimientosSalidaDevolucion_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvMovimientosSalidaDevolucion.DoubleClickRow
        TxtNumeroMovimiento.Text = e.Row.Cells("NumeroDocumento").Value
        TabSalidaDevolucion.Tabs("Salida").Selected = True
        TabIngresoDetalleOC.Tabs("DetallePendiente").Selected = True
        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        TxtCodigoProveedor.Text = Trim(e.Row.Cells("CodigoProveedor").Value & "")
        TxtRazonSocial.Text = e.Row.Cells("RazonSocial").Value
        TxtObservaciones.Text = e.Row.Cells("Observaciones").Value
        '   TxtNumeroOC.Text = e.Row.Cells("NumeroOC").Value
        LblEstado.Text = e.Row.Cells("Estado").Value

        If e.Row.Cells("Motivo").Value = "" Then
            RdbReposicion.Checked = True
        Else
            RdbNotaCredito.Checked = True
        End If

        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
            .Tipo_Mov = "19"
            .Tipo_Doc = "SD"
        End With
        dgvDetalleOC.DataSource = Negocio.Guia.ListarDetalleSalidaDevolucion(Entidad.Guia)

        TxtNumeroMovimiento.Focus()

        MsgBox("No podrá modificar este billete, proceda a eliminar y volverlo a ingresar." & vbNewLine & "Se generó cancelación automática de la Orden de Compra.", MsgBoxStyle.Critical, "Comacsa")
        dgvDetalleOC.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Activation.ActivateOnly


    End Sub
#End Region

#Region "dgvDetalleOC - AfterCellUpdate"
    Dim Tarea As Boolean = False
    Private Sub dgvDetalleOC_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvDetalleOC.AfterCellUpdate
        If Tarea = True Then Return
        If e.Cell.Column.Key = "Cantidad" Then
            If CDbl(e.Cell.Row.Cells("CantidadOC").Value) < (CDbl(e.Cell.Row.Cells("Cantidad").Value) + CDbl(e.Cell.Row.Cells("CantidadDevuelta").Value)) Then
                Tarea = True
                MsgBox("La cantidad a devolver NO puede ser mayor que la cantidad de Ingreso para el producto " + e.Cell.Row.Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                e.Cell.Row.Cells("Cantidad").Value = 0
                Call UbicarCursorGrilla(dgvDetalleOC, dgvDetalleOC.ActiveRow, "Cantidad")
                Tarea = False
            End If
        End If
    End Sub
#End Region

#End Region    '   Evento Controles

End Class