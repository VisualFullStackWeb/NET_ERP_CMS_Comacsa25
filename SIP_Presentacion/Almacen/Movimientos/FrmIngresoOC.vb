Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridBand
Public Class FrmIngresoOC

    '   *****   VARIABLES   *****
    Dim Movimientos As New DataTable
    Dim DetalleMovimiento As New DataTable
    Dim dtValidarDocumentos As New DataTable
    Dim dtValidarCodigoExiste As New DataTable
    Dim dtNumeroMovimientoAlmacen As New DataTable
    Dim dtSerie As New DataTable
    Dim Serie As String
    Dim NumeroMovimiento As String
    Dim NumeroInternoMovimiento As String
    Private FecRegistro As Date = Date.Now


    '   *****   Listas  *****
    Dim DetalleGuia As New List(Of ETGuia)
    Dim Guia As ETGuia

    Dim Pedido As New List(Of ETPedido)
    Dim Ped As ETPedido

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub


#Region "Funciones Locales"

#Region "Listar Movimientos Por Orden Compra"
    Private Sub ListarMovimientoOrdenCompra(ByVal Documento As String, ByVal Opcion As String)
        Dim Fecha1 As Date
        Dim Fecha2 As DateTime
        Fecha1 = CDate(Dtp3.Value).Date
        Fecha2 = CDate(DtFechaConsulta.Value).Date
        Fecha2 = DateAdd(DateInterval.Day, 1, Fecha2)
        Fecha2 = DateAdd(DateInterval.Second, -1, Fecha2)

        With Entidad.Guia
            Dim ab, cd As String
            .Cod_Cia = Companhia
            .NumDoc = Documento
            .Tipo_Doc = "IO"
            .Ano = Year(DtFechaConsulta.Value)
            .User_Crea = User_Sistema
            ab = Month(DtFechaConsulta.Value)
            cd = Microsoft.VisualBasic.DateAndTime.Day(DtFechaConsulta.Value)
            .Fecha = Fecha1
            .Fecha2 = Fecha2
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
            .Cod_Cia = Companhia
            .Num_Ord_Exp = TxtNumeroOC.Text
        End With
        dgvOC.DataSource = Negocio.Guia.OCPendienteIngresoProductos(Entidad.Guia, "DET")
        CboAnulacion.Value = 0
        GrpAnulacion.Visible = False
        LblEstado.Text = ""
    End Sub
#End Region

#Region "Listar Ordenes de Compra Pendientes de Ingreso - Productos"
    Private Sub ListarCabeceraOrdenesPendientesIngreso()
        Dim Fecha1 As Date
        Dim Fecha2 As DateTime
        Fecha1 = CDate(Dtp1.Value).Date
        Fecha2 = CDate(Dtp2.Value).Date
        Fecha2 = DateAdd(DateInterval.Day, 1, Fecha2)
        Fecha2 = DateAdd(DateInterval.Second, -1, Fecha2)
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Fecha = Fecha2
            .Fecha2 = Fecha1
            .User_Crea = User_Sistema
        End With
        DgvOCpendientes.DataSource = Negocio.Guia.OCPendienteIngresoProductos(Entidad.Guia, "CAB")
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

#Region "Validar Grabar"
    Private Function ValidarGrabar() As Boolean
        Dim x_Stock As String
        Dim x_Cantidad As String

        With Entidad.Almacen
            .Cod_Cia = Companhia
            .CodAlmacen = CboAlmacen.Value
        End With
        dtSerie = Negocio.Almacen.Listar_Almacen(Entidad.Almacen, "GEN")
        If dtSerie.Rows.Count = 0 Then
            MsgBox("Debe definir la serie para movimiento INGRESO POR O/C.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If GrpAnulacion.Visible = True Then
            Return False
        End If

        If LblEstado.Text = "ANULADO" Then
            MsgBox("No se puede modificar un movimiento que esta ANULADO.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Dim x As Integer = 0
        For i As Integer = 0 To dgvOC.Rows.Count - 1
            If dgvOC.Rows(i).Cells("Action").Value = 1 Then
                x = x + 1
            End If
        Next

        If x = 0 Then
            MsgBox("Debe seleccionar por lo menos un ITEM.", MsgBoxStyle.Critical, "Comacsa")
            Call UbicarCursorGrilla(dgvOC, dgvOC.Rows(0), "Action")
            Return False
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

        For j As Integer = 0 To dgvOC.Rows.Count - 1
            If dgvOC.Rows(j).Cells("Action").Value = 1 Then
                If CDbl(dgvOC.Rows(j).Cells("Cantidad").Value) = 0 Then
                    MsgBox("La cantidad NO puede ser 0 para el producto " + dgvOC.Rows(j).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                    Return False
                End If


                If CDbl(dgvOC.Rows(j).Cells("CantidadAtendida").Value) + CDbl(dgvOC.Rows(j).Cells("Cantidad").Value) > CDbl(dgvOC.Rows(j).Cells("CantidadOC").Value) Then
                    MsgBox("La Cantidad Atendida NO puede ser mayor que la Cantidad de la O/C para el producto " + dgvOC.Rows(j).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                    Return False
                End If


                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CboAlmacen.Value
                    .CodigoProducto = dgvOC.Rows(j).Cells("Codigo").Value
                End With
                Entidad.Resultado = Negocio.Requerimiento.StockMesAnterior(Entidad.Requerimiento, "5")
                x_Stock = Entidad.Resultado.Mensaje

                If TxtNumeroMovimiento.Text <> "" Then
                    With Entidad.Producto
                        .Cod_Cia = Companhia
                        .Unidad = dgvOC.Rows(j).Cells("UnidadIngresoAlmacen").Value
                        .UnidadDesp = dgvOC.Rows(j).Cells("UM").Value
                        .CodProducto = dgvOC.Rows(j).Cells("Codigo").Value
                    End With
                    Entidad.Resultado = Negocio.Guia.ConvertirIngresoAlmacen(Entidad.Producto, (CDbl(dgvOC.Rows(j).Cells("CantidadOC").Value) - CDbl(dgvOC.Rows(j).Cells("Cantidad").Value)))
                    x_Cantidad = Entidad.Resultado.Mensaje

                    If CDbl(x_Stock) < CDbl(x_Cantidad) Then
                        MsgBox("El Stock Actual es: " + x_Stock + dgvOC.Rows(j).Cells("UM").Value + " para el producto." + dgvOC.Rows(j).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                        dgvOC.Rows(j).Cells("Cantidad").Value = 0
                        Call UbicarCursorGrilla(dgvOC, dgvOC.Rows(j), "Cantidad")
                        Return False
                    End If
                End If

                With Entidad.Producto
                    .Cod_Cia = Companhia
                    .CodProducto = dgvOC.Rows(j).Cells("Codigo").Value
                    .TipoProducto = dgvOC.Rows(j).Cells("TipoProducto").Value
                End With
                dtValidarCodigoExiste = Negocio.Producto.ProductoValidar(Entidad.Producto, "XCO")

                If dtValidarCodigoExiste.Rows.Count <> 1 Then
                    MsgBox("Código del producto " + dgvOC.Rows(j).Cells("Codigo").Value + " no existe.", MsgBoxStyle.Critical, "Comacsa")
                    Return False
                End If

            End If
        Next

        Return True
    End Function
#End Region

#Region "Validar Anulacion"
    Private Function ValidarAnulacion() As Boolean
        Dim xmes As String
        Dim Ano As String
        Dim Periodo As String
        Dim Stock As Decimal
        Dim Eliminar As Decimal

        If TxtNumeroMovimiento.Text = "" Then
            Return False
        End If

        If LblEstado.Text = "ANULADO" Then
            Return False
        End If

        xmes = Mes(Month(Now))
        Ano = Year(Now)
        Periodo = xmes + Ano

        If PeriodoCerrado(CboAlmacen.Value, Periodo) = True Then Return False
        If FacturacionBillete(CboTipoMovimiento.Value, Trim(TxtNumeroMovimiento.Text & "")) = True Then Return False

        For i As Integer = 0 To dgvOC.Rows.Count - 1
            If VerificarDevolucion(CboTipoMovimiento.Value, "IO", TxtNumeroMovimiento.Text, TxtNumeroOC.Text) Then
                MsgBox("Imposible anular existen salida(s) por devolución para esta orden de compra " & TxtNumeroOC.Text, vbExclamation, "Comacsa")
                Return False
            End If

            If Mid(dgvOC.Rows(i).Cells("Codigo").Value, 1, 1) <> "P" And dgvOC.Rows(i).Cells("TipoProducto").Value = "04" Then
                MsgBox("NO existe enlace con producción." & vbCrLf & "Producto: " & dgvOC.Rows(i).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If

            Stock = Saldo_Stock(dgvOC.Rows(i).Cells("Codigo").Value, CboAlmacen.Value, dgvOC.Rows(i).Cells("TipoProducto").Value)
            Eliminar = SumaTotalProducto(dgvOC, dgvOC.Rows(i).Cells("Codigo").Value)

            If Stock < Eliminar Then
                MsgBox("El Stock " & DescripcionMes(xmes) & " " & Ano & " del producto " & dgvOC.Rows(i).Cells("Codigo").Value & " es menor, a la cantidad a eliminar." & vbCrLf & "Se cancelará la anulación de la guia.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If
        Next

        If GrpAnulacion.Visible = False And TxtNumeroMovimiento.Text <> "" Then
            CboAnulacion.ReadOnly = False
            CboAnulacion.Value = 0
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

#End Region      'Funciones Locales

#Region "Funciones Públicas"

#Region "Grabar"
    Public Sub Grabar()
        TxtNumeroMovimiento.Focus()
        If ValidarGrabar() = False Then Return
        If MsgBox("¿Esta Seguro de GRABAR el ingreso por Orden.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            For p As Integer = 0 To dgvOC.Rows.Count - 1
                If dgvOC.Rows(p).Cells("Action").Value = 1 Then
                    With Entidad.Producto
                        .Cod_Cia = Companhia
                        .Unidad = dgvOC.Rows(p).Cells("UM").Value
                        .UnidadDesp = dgvOC.Rows(p).Cells("UnidadIngresoAlmacen").Value
                        .CodProducto = dgvOC.Rows(p).Cells("Codigo").Value
                    End With
                    Entidad.Resultado = Negocio.Guia.ConvertirIngresoAlmacen(Entidad.Producto, dgvOC.Rows(p).Cells("Cantidad").Value)
                    If Entidad.Resultado.Realizo = True Then
                        dgvOC.Rows(p).Cells("CantidadIngresoAlmacen").Value = Entidad.Resultado.Mensaje
                    Else
                        MsgBox("NO se puede convertir el producto " + dgvOC.Rows(p).Cells("Descripcion").Value + " , consultar con el departamento de SISTEMAS.", MsgBoxStyle.Critical, "Comacsa")
                        Return
                    End If
                End If
            Next
            dgvOC.Refresh()

            With Entidad.Guia
                .Cod_Cia = Companhia
                .Tipo_Doc = "IO"
                .Tipo_Mov = CboTipoMovimiento.Value
                .NumDoc = Trim(TxtNumeroMovimiento.Text & "")

                If TxtNumeroMovimiento.Text = "" Then
                    .NumInterno = ""
                Else
                    .NumInterno = DgvMovimientosOrdenCompra.ActiveRow.Cells("NumeroMovimientoInterno").Value
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

            For i As Integer = 0 To dgvOC.Rows.Count - 1
                If dgvOC.Rows(i).Cells("Action").Value = 1 Then
                    Guia = New ETGuia
                    With Guia
                        .cod_cia = Companhia                                                 '**
                        .tipo_mov = CboTipoMovimiento.Value                             '**
                        .tipo_doc = "IO"                                                '**
                        .numdoc = Trim(TxtNumeroMovimiento.Text & "")
                        If TxtNumeroMovimiento.Text = "" Then
                            .NumInterno = ""
                        Else
                            .NumInterno = DgvMovimientosOrdenCompra.ActiveRow.Cells("NumeroMovimientoInterno").Value
                        End If
                        .cod_cli = Trim(TxtCodigoProveedor.Text & "")                   '**
                        .item = dgvOC.Rows(i).Cells("Item").Value                       '**
                        .cod_prod = dgvOC.Rows(i).Cells("Codigo").Value                 '**
                        .descrip = dgvOC.Rows(i).Cells("Descripcion").Value             '**
                        .unid = dgvOC.Rows(i).Cells("UnidadIngresoAlmacen").Value       '**
                        .cant_ing = dgvOC.Rows(i).Cells("CantidadIngresoAlmacen").Value '**
                        .moneda = dgvOC.Rows(i).Cells("Moneda").Value                   '**
                        .tipo_cambio = dgvOC.Rows(i).Cells("TipoCambio").Value          '**
                        .precio = dgvOC.Rows(i).Cells("Precio").Value                   '**
                        .dcto = dgvOC.Rows(i).Cells("Descuento").Value                  '**
                        .total = dgvOC.Rows(i).Cells("Neto").Value                      '**
                        .User_Crea = User_Sistema                                           '**
                        .item_fact = dgvOC.Rows(i).Cells("Item").Value                  '**
                        .cod_prodpdc = dgvOC.Rows(i).Cells("Codigo").Value              '**
                        .tipprod = dgvOC.Rows(i).Cells("TipoProducto").Value            '**
                        .codorigen = dgvOC.Rows(i).Cells("TipoProducto").Value          '**
                        .und_oc = dgvOC.Rows(i).Cells("UM").Value                       '**
                        .cant_oc = dgvOC.Rows(i).Cells("Cantidad").Value                '**
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

                    Dim dt_AnexoOC As New DataTable
                    Dim dt_AnexoRequerimiento As New DataTable

                    With Entidad.Anexo
                        .Cod_Cia = Companhia
                        .Item_Pedido = dgvOC.Rows(i).Cells("Item").Value
                        .Nro_OC = Trim(TxtNumeroOC.Text & "")
                    End With
                    dt_AnexoOC = Negocio.AnexoOCBL.ListarDatosAnexoOC(Entidad.Anexo)


                    For j As Integer = 0 To dt_AnexoOC.Rows.Count - 1
                        With Entidad.Anexo
                            .Cod_Cia = Companhia
                            .Nro_Req = Trim(dt_AnexoOC.Rows(j).Item("Nro_Requi") & "")
                            .Item_Requerimiento = dt_AnexoOC.Rows(j).Item("Item")
                            .Codigo_Producto = dt_AnexoOC.Rows(j).Item("Producto")
                        End With
                        dt_AnexoRequerimiento = Negocio.AnexoBL.ListarDatosAnexoRequerimiento(Entidad.Anexo)

                        If dt_AnexoRequerimiento.Rows.Count > 0 Then
                            For k As Integer = 0 To dt_AnexoRequerimiento.Rows.Count - 1
                                Ped = New ETPedido
                                With Entidad.Pedido
                                    .Cod_Cia = Companhia
                                    .Item = dt_AnexoRequerimiento.Rows(0).Item("Item")
                                    .Numero_Doc = dt_AnexoRequerimiento.Rows(0).Item("Nro_Pedido")
                                    .Codigo_Producto = dt_AnexoRequerimiento.Rows(0).Item("Producto")
                                    .User = User_Sistema
                                End With
                                Pedido.Add(Ped)
                            Next
                        End If
                    Next
                End If
            Next

            If TxtNumeroMovimiento.Text = "" Then
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("AGR", CboTipoMovimiento.Value, "IO", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)
            Else
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("MOD", CboTipoMovimiento.Value, "IO", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)
            End If


            If Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text = "" Then
                MsgBox("Se generó el Ingreso Por Orden N° " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            ElseIf Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text <> "" Then
                MsgBox("Se modificó el Ingreso Por Orden N° " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            DetalleGuia = New List(Of ETGuia)

            Call ListarMovimientoOrdenCompra("", "LTO")
            DgvMovimientosOrdenCompra.DataSource = Movimientos
            TabIngresoOC.Tabs("Listar").Selected = True
            Call ListarCabeceraOrdenesPendientesIngreso()
            Call Limpiar()
        End If
    End Sub
#End Region

#Region "Nuevo"
    Public Sub Nuevo()
        TabIngresoOC.Tabs("Ingreso").Selected = True
        TabIngresoDetalleOC.Tabs("OCPendiente").Selected = True
        Dtp2.Value = Date.Now
        Dtp1.Value = DateAdd(DateInterval.Day, -60, Dtp2.Value)
        Call ListarCabeceraOrdenesPendientesIngreso()
        TxtNumeroMovimiento.Clear()
        DtFechaMovimiento.Value = Now
        CboAlmacen.Value = "28"
        CboDocumentoReferencia.SelectedIndex = -1
        TxtSerieNumeroDocumentoReferencia.Clear()
        TxtCodigoProveedor.Clear()
        TxtRazonSocial.Clear()
        TxtNumeroDocumentoReferencia.Clear()
        TxtNumeroOC.Clear()
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Num_Ord_Exp = TxtNumeroOC.Text
        End With
        dgvOC.DataSource = Negocio.Guia.OCPendienteIngresoProductos(Entidad.Guia, "DET")
        GrpAnulacion.Visible = False
        CboAnulacion.Value = 0
        CboAnulacion.ReadOnly = True
        LblEstado.Text = ""
        dgvOC.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        dgvOC.DisplayLayout.Bands(0).Columns("Action").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
    End Sub

    Public Sub Procesar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        If TabIngresoOC.Tabs("Ingreso").Selected = True And TabIngresoDetalleOC.Tabs("OCPendiente").Selected = True Then
            Call ListarCabeceraOrdenesPendientesIngreso()
            TxtNumeroMovimiento.Clear()
            DtFechaMovimiento.Value = Now
            CboAlmacen.Value = "28"
            CboDocumentoReferencia.SelectedIndex = -1
            TxtSerieNumeroDocumentoReferencia.Clear()
            TxtCodigoProveedor.Clear()
            TxtRazonSocial.Clear()
            TxtNumeroDocumentoReferencia.Clear()
            TxtNumeroOC.Clear()
            With Entidad.Guia
                .Cod_Cia = Companhia
                .Num_Ord_Exp = TxtNumeroOC.Text
            End With
            dgvOC.DataSource = Negocio.Guia.OCPendienteIngresoProductos(Entidad.Guia, "DET")
            GrpAnulacion.Visible = False
            CboAnulacion.Value = 0
            CboAnulacion.ReadOnly = True
            LblEstado.Text = ""
            dgvOC.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            dgvOC.DisplayLayout.Bands(0).Columns("Action").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

        ElseIf TabIngresoOC.Tabs("Listar").Selected = True Then
            Call ListarMovimientoOrdenCompra(TxtBuscarNumeroDocumento.Text.Trim, "LTO")
            DgvMovimientosOrdenCompra.DataSource = Movimientos
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
#End Region

#Region "Buscar"
    Public Sub Buscar()
        If TabIngresoOC.Tabs("Listar").Selected = True Then
            If Len(TxtBuscarNumeroDocumento.Text) = 0 Then
                Call ListarMovimientoOrdenCompra("", "LFE")
                If Movimientos.Rows.Count > 0 Then
                    DgvMovimientosOrdenCompra.DataSource = Movimientos
                Else
                    MsgBox("No existen billete(s) generados el dia " & DtFechaConsulta.Value & " .", MsgBoxStyle.Critical, "Comacsa")
                    TxtBuscarNumeroDocumento.Clear()
                    TxtBuscarNumeroDocumento.Focus()
                    Return
                End If

            Else
                Call ListarMovimientoOrdenCompra(TxtBuscarNumeroDocumento.Text, "LNU")
                If Movimientos.Rows.Count > 0 Then
                    TabIngresoOC.Tabs("Ingreso").Selected = True
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
                    dgvOC.DataSource = Negocio.Guia.ListarDetalleIngresoOC(Entidad.Guia)

                    For p As Integer = 0 To dgvOC.Rows.Count - 1
                        With Entidad.Producto
                            .Cod_Cia = Companhia
                            .Unidad = dgvOC.Rows(p).Cells("UnidadIngresoAlmacen").Value
                            .UnidadDesp = dgvOC.Rows(p).Cells("UM").Value
                            .CodProducto = dgvOC.Rows(p).Cells("Codigo").Value
                        End With
                        Entidad.Resultado = Negocio.Guia.ConvertirIngresoAlmacen(Entidad.Producto, dgvOC.Rows(p).Cells("CantidadIngresoAlmacen").Value)
                        If Entidad.Resultado.Realizo = True Then
                            dgvOC.Rows(p).Cells("Cantidad").Value = Entidad.Resultado.Mensaje
                        Else
                            MsgBox("NO se puede convertir el producto " + dgvOC.Rows(p).Cells("Descripcion").Value + " , consultar con el departamento de SISTEMAS.", MsgBoxStyle.Critical, "Comacsa")
                            Return
                        End If
                    Next
                    dgvOC.Refresh()

                Else
                    MsgBox("El billete " & TxtBuscarNumeroDocumento.Text & " NO existe.", MsgBoxStyle.Critical, "Comacsa")
                    TxtBuscarNumeroDocumento.Clear()
                    TxtBuscarNumeroDocumento.Focus()
                    Return
                End If
            End If

        Else
            If TxtCodigoProveedor.Text = "" Then
                Dim Proveedor As New FrmProveedores
                Proveedor.ShowDialog()
                TxtCodigoProveedor.Text = Trim(Proveedor.Codigo & "")
                TxtRazonSocial.Text = Trim(Proveedor.RazonSocial & "")
            Else
                With dgvOC
                    Select Case .ActiveCell.Column.Key

                        Case "Codigo"
                            Dim Productos As New FrmListarProductos
                            gAlmacen = CboAlmacen.Value
                            Productos.ShowDialog()
                            dgvOC.ActiveRow.Cells("Codigo").Value = Productos.CODIGO
                            dgvOC.ActiveRow.Cells("Descripcion").Value = Productos.DESCRIPCION
                            dgvOC.ActiveRow.Cells("UM").Value = Productos.UNIDADMEDIDA
                    End Select
                End With
            End If
        End If
    End Sub
#End Region

#Region "Eliminar"
    Public Sub Eliminar()
        If TabIngresoOC.Tabs("Listar").Selected = True Then
            If DgvMovimientosOrdenCompra.ActiveRow.Cells("Estado").Value = "ANULADO" Then
                MsgBox("NO podrá modificar el documento por que ya fue ANULADO.", MsgBoxStyle.Critical, "Comacsa")
            End If

            TabIngresoOC.Tabs("Ingreso").Selected = True
            TabIngresoDetalleOC.Tabs("DetallePendiente").Selected = True
            GrpAnulacion.Visible = True
            TxtNumeroMovimiento.Text = DgvMovimientosOrdenCompra.ActiveRow.Cells("NumeroDocumento").Value
            CboAlmacen.Value = DgvMovimientosOrdenCompra.ActiveRow.Cells("CodigoAlmacen").Value
            CboDocumentoReferencia.Value = DgvMovimientosOrdenCompra.ActiveRow.Cells("TipoDocumentoReferencia").Value
            TxtSerieNumeroDocumentoReferencia.Text = Mid((DgvMovimientosOrdenCompra.ActiveRow.Cells("NumeroDocumentoReferencia").Value), 1, 3)
            TxtNumeroDocumentoReferencia.Text = Mid((DgvMovimientosOrdenCompra.ActiveRow.Cells("NumeroDocumentoReferencia").Value), 4, 17)
            TxtCodigoProveedor.Text = Trim(DgvMovimientosOrdenCompra.ActiveRow.Cells("CodigoProveedor").Value & "")
            TxtRazonSocial.Text = DgvMovimientosOrdenCompra.ActiveRow.Cells("RazonSocial").Value
            TxtObservaciones.Text = DgvMovimientosOrdenCompra.ActiveRow.Cells("Observaciones").Value
            TxtNumeroOC.Text = DgvMovimientosOrdenCompra.ActiveRow.Cells("NumeroOC").Value

        End If

        dgvOC.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        dgvOC.DisplayLayout.Bands(0).Columns("Action").CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly

        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
            .Tipo_Mov = "01"
            .Tipo_Doc = "IO"
        End With
        dgvOC.DataSource = Negocio.Guia.ListarDetalleIngresoOC(Entidad.Guia)

        For p As Integer = 0 To dgvOC.Rows.Count - 1
            With Entidad.Producto
                .Cod_Cia = Companhia
                .Unidad = dgvOC.Rows(p).Cells("UnidadIngresoAlmacen").Value
                .UnidadDesp = dgvOC.Rows(p).Cells("UM").Value
                .CodProducto = dgvOC.Rows(p).Cells("Codigo").Value
            End With
            Entidad.Resultado = Negocio.Guia.ConvertirIngresoAlmacen(Entidad.Producto, dgvOC.Rows(p).Cells("CantidadIngresoAlmacen").Value)
            dgvOC.Rows(p).Cells("Cantidad").Value = Entidad.Resultado.Mensaje
            dgvOC.Rows(p).Cells("Cantidad_Anterior").Value = Entidad.Resultado.Mensaje
            dgvOC.Rows(p).Cells("CantidadAtendida").Value = CDbl(dgvOC.Rows(p).Cells("CantidadAtendida").Value) - CDbl(dgvOC.Rows(p).Cells("Cantidad").Value)
        Next
        dgvOC.Refresh()

        If ValidarAnulacion() = False Then Return
        If MsgBox("¿Esta Seguro de ELIMINAR el Ingreso por Orden.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            With Entidad.Guia
                .Cod_Cia = Companhia
                .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
                .Motivo = CboAnulacion.Value
                .User_Crea = User_Sistema
                .Tipo_Doc = "IO"
                .Tipo_Mov = "01"
            End With

            For j As Integer = 0 To dgvOC.Rows.Count - 1
                Guia = New ETGuia

                With Guia
                    .cod_cia = Companhia
                    .num_ord_exp = Trim(TxtNumeroOC.Text & "")
                    .item = dgvOC.Rows(j).Cells("Item").Value
                    .cod_prod = dgvOC.Rows(j).Cells("Codigo").Value
                    .cant_ped = dgvOC.Rows(j).Cells("Cantidad").Value
                    .User_Crea = User_Sistema
                End With
                DetalleGuia.Add(Guia)

            Next

            Entidad.Resultado = Negocio.Guia.EliminarMovimiento(Entidad.Guia, DetalleGuia)


            If Entidad.Resultado.Realizo = True Then
                MsgBox("La anulación del Ingreso x Orden " & Trim(TxtNumeroMovimiento.Text & "") & " se realizó con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            DetalleGuia = New List(Of ETGuia)

            Call ListarMovimientoOrdenCompra("", "LTO")
            DgvMovimientosOrdenCompra.DataSource = Movimientos
            TabIngresoOC.Tabs("Listar").Selected = True
            Call ListarCabeceraOrdenesPendientesIngreso()
            Call Limpiar()


            If Chk_Total.Checked = True Then
                With Entidad.Guia
                    .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
                    .Tipo_Mov = CboTipoMovimiento.Value
                    .Tipo_Doc = "IO"
                    .Cod_Cia = Companhia
                End With
                Entidad.Resultado = Negocio.Guia.EliminacionTotal(Entidad.Guia)

            End If

        End If
    End Sub
#End Region

#End Region     'Funciones Publicas 

#Region "Eventos Controles"

#Region "DgvMovimientosOrdenCompra - DoubleClickRow"
    Private Sub DgvMovimientosOrdenCompra_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvMovimientosOrdenCompra.DoubleClickRow
        CboAnulacion.ReadOnly = True
        CboAnulacion.Value = 0
        TxtNumeroMovimiento.Text = e.Row.Cells("NumeroDocumento").Value
        TabIngresoOC.Tabs("Ingreso").Selected = True
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
            .Tipo_Mov = "01"
            .Tipo_Doc = "IO"
        End With
        dgvOC.DataSource = Negocio.Guia.ListarDetalleIngresoOC(Entidad.Guia)

        For p As Integer = 0 To dgvOC.Rows.Count - 1
            With Entidad.Producto
                .Cod_Cia = Companhia
                .Unidad = dgvOC.Rows(p).Cells("UnidadIngresoAlmacen").Value
                .UnidadDesp = dgvOC.Rows(p).Cells("UM").Value
                .CodProducto = dgvOC.Rows(p).Cells("Codigo").Value
            End With
            Entidad.Resultado = Negocio.Guia.ConvertirIngresoAlmacen(Entidad.Producto, dgvOC.Rows(p).Cells("CantidadIngresoAlmacen").Value)
            dgvOC.Rows(p).Cells("Cantidad").Value = Entidad.Resultado.Mensaje
            dgvOC.Rows(p).Cells("Cantidad_Anterior").Value = Entidad.Resultado.Mensaje

            dgvOC.Rows(p).Cells("CantidadAtendida").Value = CDbl(dgvOC.Rows(p).Cells("CantidadAtendida").Value) - CDbl(dgvOC.Rows(p).Cells("Cantidad").Value)
        Next

        dgvOC.Refresh()

        If GrpAnulacion.Visible = True Then
            dgvOC.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        ElseIf LblEstado.Text = "ANULADO" Then
            MsgBox("NO podrá modificar el documento por que ya fue ANULADO.", MsgBoxStyle.Critical, "Comacsa")
            dgvOC.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Else
            dgvOC.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        End If
        dgvOC.DisplayLayout.Bands(0).Columns("Action").CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
    End Sub
#End Region

#Region "dgvOC - KeyPress"
    Private Sub dgvOC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvOC.KeyPress
        With dgvOC
            Select Case .ActiveCell.Column.Key
                Case "Codigo"
                    Select Case Asc(e.KeyChar)
                        Case 13
                            Dim DtProducto As New DataTable
                            With Entidad.Producto
                                .Cod_Cia = Companhia
                                .CodAlmacen = CboAlmacen.Value
                                .CodProducto = Trim(dgvOC.ActiveCell.Text & "")
                            End With
                            DtProducto = Negocio.Producto.ListarProductos(Entidad.Producto, "LX2")
                            If DtProducto.Rows.Count > 0 Then
                                dgvOC.ActiveRow.Cells("Codigo").Value = DtProducto.Rows(0).Item("Codigo")
                                dgvOC.ActiveRow.Cells("Descripcion").Value = DtProducto.Rows(0).Item("Descripcion")
                                dgvOC.ActiveRow.Cells("UM").Value = DtProducto.Rows(0).Item("UM")
                            Else
                                MsgBox("NO hay producto para este código.", MsgBoxStyle.Critical, "Comacsa")
                                dgvOC.ActiveRow.Cells("Codigo").Value = ""
                                Return
                            End If
                    End Select
            End Select
        End With
    End Sub
#End Region

#Region "dgvOC - BeforeRowsDeleted"
    Private Sub dgvOC_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvOC.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
#End Region

#Region "dgvOC - AfterCellUpdate"
    Dim Tarea As Boolean = False

    Private Sub dgvOC_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvOC.AfterCellUpdate
        If Tarea = True Then Return

        If e.Cell.Column.Key = "Codigo" Then
            If Len(e.Cell.Row.Cells("Codigo").Value) <> 8 Then
                Tarea = True
                e.Cell.Row.Cells("Codigo").Value = ""
                e.Cell.Row.Cells("Descripcion").Value = ""
                e.Cell.Row.Cells("UM").Value = ""
                e.Cell.Row.Cells("CantidadOC").Value = ""
                e.Cell.Row.Cells("CantidadAtendida").Value = 0
                e.Cell.Row.Cells("Cantidad").Value = ""
                e.Cell.Row.Cells("NroOC").Value = ""
                e.Cell.Row.Cells("UnidadIngresoAlmacen").Value = ""
                e.Cell.Row.Cells("CantidadIngresoAlmacen").Value = ""
                Tarea = False
            End If
        End If


        If e.Cell.Column.Key = "Action" = True Then

            If e.Cell.Row.Cells("UnidadIngresoAlmacen").Value <> e.Cell.Row.Cells("UM").Value Then

                With Entidad.Producto
                    .Cod_Cia = Companhia
                    .CodProducto = e.Cell.Row.Cells("Codigo").Value
                    .Unidad = e.Cell.Row.Cells("UM").Value
                    .UnidadDesp = e.Cell.Row.Cells("UnidadIngresoAlmacen").Value
                End With
                Dim Existencia As New DataTable
                Existencia = Negocio.Producto.Existe_Producto_Conversion(Entidad.Producto)

                If Existencia.Rows.Count = 0 Then
                    Tarea = True
                    MsgBox("El producto NO tiene factor de conversión para ingresar al almacén.", MsgBoxStyle.Critical, "Comacsa")
                    e.Cell.Row.Cells("Action").Value = False
                    Tarea = False
                End If
            End If
        End If

    End Sub

#End Region

#Region "DgvOCpendientes - DoubleClickRow"
    Private Sub DgvOCpendientes_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvOCpendientes.DoubleClickRow
        CboDocumentoReferencia.SelectedIndex = -1
        TxtSerieNumeroDocumentoReferencia.Clear()
        TxtNumeroDocumentoReferencia.Clear()
        TxtNumeroMovimiento.Clear()
        TabIngresoDetalleOC.Tabs("DetallePendiente").Selected = True
        CboAlmacen.Value = Trim(e.Row.Cells("CodigoAlmacen").Value & "")
        TxtCodigoProveedor.Text = Trim(e.Row.Cells("CodigoProveedor").Value & "")
        TxtRazonSocial.Text = Trim(e.Row.Cells("RazonSocial").Value & "")
        TxtNumeroOC.Text = Trim(e.Row.Cells("NumeroOC").Value & "")
        TxtObservaciones.Text = Trim(e.Row.Cells("Observaciones").Value & "")
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Num_Ord_Exp = TxtNumeroOC.Text
        End With
        dgvOC.DataSource = Negocio.Guia.OCPendienteIngresoProductos(Entidad.Guia, "DET")


        Entidad.Almacen = New ETAlmacen
        Negocio.Almacen = New NGAlmacen
        With Entidad.Almacen
            .Cod_Cia = Companhia
            .CodAlmacen = CboAlmacen.Value
        End With
        dtSerie = Negocio.Almacen.Listar_Almacen(Entidad.Almacen, "GEN")
        If dtSerie.Rows.Count = 0 Then
            MsgBox("Debe definir la serie para movimiento INGRESO POR O/C.", MsgBoxStyle.Critical, "Comacsa")
        End If

        dgvOC.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        dgvOC.DisplayLayout.Bands(0).Columns("Action").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

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

#Region "dgvOC - ClickCell"
    Private Sub dgvOC_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dgvOC.ClickCell
        If e.Cell.Column.Key = "Action" = True Then
            If e.Cell.Row.Cells("UM").Value <> e.Cell.Row.Cells("UnidadIngresoAlmacen").Value Then
                With Entidad.Producto
                    .Cod_Cia = Companhia
                    .CodProducto = e.Cell.Row.Cells("Codigo").Value
                    .Unidad = e.Cell.Row.Cells("UM").Value
                    .UnidadDesp = e.Cell.Row.Cells("UnidadIngresoAlmacen").Value
                End With
                Dim Existencia As New DataTable
                Existencia = Negocio.Producto.Existe_Producto_Conversion(Entidad.Producto)

                If Existencia.Rows.Count = 0 Then
                    Tarea = True
                    MsgBox("El producto NO tiene factor de conversión para ingresar al almacén.", MsgBoxStyle.Critical, "Comacsa")
                    e.Cell.Row.Cells("Action").Value = False
                    Tarea = False
                End If
            End If
        End If
    End Sub
#End Region

#Region "btnCancelar - Click"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        GrpAnulacion.Visible = False
        dgvOC.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        dgvOC.DisplayLayout.Bands(0).Columns("Action").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        CboAnulacion.Value = 0
    End Sub
#End Region

#End Region      'Evento Controles

#Region "Load"
    Private Sub FrmIngresoOC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtFechaConsulta.Value = Now
        Dtp3.Value = DateAdd(DateInterval.Month, -1, Now)
        DtFechaMovimiento.Value = Now
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarCia(Cia3)
        Call ListarMotivoAnulacion(CboAnulacion)
        Call ListarMovimientosUsuario(CboTipoMovimiento, "01")
        Call ListarAlmacenUsuarios(CboAlmacen, "28")

        Call ListarDocumentosReferencia()
        Call ListarMovimientoOrdenCompra("", "LTO")
        DgvMovimientosOrdenCompra.DataSource = Movimientos

        If User_Sistema = "SA" Then
            Chk_Total.Visible = True
        Else
            Chk_Total.Visible = False
        End If

    End Sub
#End Region                   'Load


    Private Sub CboAnulacion_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles CboAnulacion.InitializeLayout
        If e Is Nothing Then Return
        With sender.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.TrueString
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Motivo") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                    If uColumn.Key = "Codigo" Then
                        uColumn.MinWidth = 40
                        uColumn.MaxWidth = 40
                    Else
                        uColumn.MinWidth = CboAnulacion.Width - 40
                        uColumn.MaxWidth = CboAnulacion.Width - 40
                    End If
                End If
            Next
        End With
    End Sub

End Class