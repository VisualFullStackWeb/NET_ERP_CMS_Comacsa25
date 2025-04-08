Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmIngresoSinOC
  
    '   *****   VARIABLES   *****
    Dim Movimientos As New DataTable
    Dim dtValidarDocumentos As New DataTable
    Dim dtValidarCodigoExiste As New DataTable
    Dim dtNumeroMovimientoAlmacen As New DataTable
    Dim Serie As String
    Dim NumeroMovimiento As String
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

#Region "Listar Movimientos Ingreso Sin Orden Compra"

    Private Sub ListarMovimientoSinOrdenCompra(ByVal Documento As String, ByVal Opcion As String)
        With Entidad.Guia
            Dim ab, cd As String
            .Cod_Cia = Companhia
            .NumDoc = Documento
            .Tipo_Doc = "IX"
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
            .Tipo_Doc = "IX"
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

        If dgvSinOC.Rows.Count = 0 Then
            MsgBox("No hay detalle para Grabar.", MsgBoxStyle.Critical, "Comacsa")
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

        For j As Integer = 0 To dgvSinOC.Rows.Count - 1

            With Entidad.Producto
                .Cod_Cia = Companhia
                .CodProducto = dgvSinOC.Rows(j).Cells("Codigo").Value
                .TipoProducto = dgvSinOC.Rows(j).Cells("TipoProducto").Value
            End With
            dtValidarCodigoExiste = Negocio.Producto.ProductoValidar(Entidad.Producto, "XCO")

            If dtValidarCodigoExiste.Rows.Count <> 1 Then
                MsgBox("Código del producto " + dgvSinOC.Rows(j).Cells("Codigo").Value + " no existe.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If

            If dgvSinOC.Rows(j).Cells("Cantidad").Value = 0 Then
                MsgBox("La cantidad NO puede ser 0 para el producto " + dgvSinOC.Rows(j).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If
        Next

        Return True
    End Function
#End Region

#Region "Limpiar"
    Private Sub Limpiar()
        TxtNumeroMovimiento.Clear()
        TxtNumeroOC.Clear()
        CboDocumentoReferencia.SelectedIndex = -1
        CboAlmacen.Value = 28
        TxtSerieNumeroDocumentoReferencia.Clear()
        TxtNumeroDocumentoReferencia.Clear()
        TxtCodigoProveedor.Clear()
        TxtRazonSocial.Clear()
        TxtSuma.Text = ""
        TxtObservaciones.Clear()
        TxtRUC.Clear()

        Dim i As Integer = dgvSinOC.Rows.Count - 1
        While i >= 0
            dgvSinOC.Rows(i).Delete()
            i = dgvSinOC.Rows.Count - 1
        End While

    End Sub
#End Region

#End Region   '   Funciones Locales

#Region "Evento Controles"

#Region "btnCancelar - Click"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        GrpAnulacion.Visible = False
        CboAnulacion.Value = 0
    End Sub
#End Region

#Region "DgvMovimientosSinOrdenCompra - DoubleClickRow"
    Private Sub DgvMovimientosSinOrdenCompra_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvMovimientosSinOrdenCompra.DoubleClickRow
        TxtNumeroMovimiento.Text = e.Row.Cells("NumeroDocumento").Value
        TabIngresoSinOC.Tabs("Ingreso").Selected = True

        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        CboDocumentoReferencia.Value = e.Row.Cells("TipoDocumentoReferencia").Value
        TxtSerieNumeroDocumentoReferencia.Text = Mid((e.Row.Cells("NumeroDocumentoReferencia").Value), 1, 3)
        TxtNumeroDocumentoReferencia.Text = Mid((e.Row.Cells("NumeroDocumentoReferencia").Value), 4, 17)
        TxtCodigoProveedor.Text = Trim(e.Row.Cells("CodigoProveedor").Value & "")
        TxtRazonSocial.Text = Trim(e.Row.Cells("RazonSocial").Value & "")
        TxtObservaciones.Text = Trim(e.Row.Cells("Observaciones").Value & "")
        TxtNumeroOC.Text = Trim(e.Row.Cells("NumeroOC").Value & "")
        LblEstado.Text = e.Row.Cells("Estado").Value

        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
        End With
        dgvSinOC.DataSource = Negocio.Guia.ListarDetalleIngresoSinOC(Entidad.Guia, "LI1")

        Dim Suma As Decimal = 0
        For i As Integer = 0 To dgvSinOC.Rows.Count - 1
            Suma = Suma + dgvSinOC.Rows(i).Cells("Neto").Value
        Next
        TxtSuma.Text = Suma
    End Sub
#End Region

#Region "dgvSinOC - BeforeRowsDeleted"
    Private Sub dgvSinOC_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvSinOC.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
#End Region

#Region "dgvSinOC - AfterCellUpdate"
    Private Sub dgvSinOC_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvSinOC.AfterCellUpdate
        Dim xSuma As Decimal = 0
        Dim Tarea As Boolean = False
        If Tarea = True Then Return
        If e.Cell.Column.Key = "Neto" Then
            If (e.Cell.Row.Cells("Neto").Value) <> 0 Then
                Tarea = True

                For j As Integer = 0 To dgvSinOC.Rows.Count - 1
                    xSuma = xSuma + dgvSinOC.Rows(j).Cells("Neto").Value
                Next
                Tarea = False
            End If
            TxtSuma.Text = xSuma
            xSuma = 0
        End If
    End Sub
#End Region

#Region "TxtCodigoProveedor - KeyPress"
    Private Sub TxtCodigoProveedor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoProveedor.KeyPress
        Select Case Asc(e.KeyChar)
            Case "13"
                Dim dtProveedor As New DataTable
                With Entidad.Requerimiento
                    .Cod_Prov = Trim(TxtCodigoProveedor.Text & "")
                    .Cod_Cia = Companhia
                End With
                dtProveedor = Negocio.Requerimiento.ListarNombreCorto(Entidad.Requerimiento, "LXP")

                If dtProveedor.Rows.Count > 0 Then
                    TxtCodigoProveedor.Text = Trim(dtProveedor.Rows(0).Item("Codigo") & "")
                    TxtRazonSocial.Text = Trim(dtProveedor.Rows(0).Item("RazonSocial") & "")
                    TxtRUC.Text = Trim(dtProveedor.Rows(0).Item("RUC") & "")
                Else
                    MsgBox("No hay PROVEEDOR con este codigo: " & TxtCodigoProveedor.Text, MsgBoxStyle.Critical, "Comacsa")
                    TxtCodigoProveedor.Clear()
                    TxtRazonSocial.Clear()
                    Return
                End If
        End Select



    End Sub
#End Region

#Region "TxtCodigoProveedor - ValueChanged"
    Private Sub TxtCodigoProveedor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoProveedor.ValueChanged
        If Len(TxtCodigoProveedor.Text) <> 6 Then
            TxtRazonSocial.Clear()
        End If
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

#Region "Load"
    Private Sub FrmIngresoSinOC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarMovimientosUsuario(CboTipoMovimiento, "39")
        Call ListarAlmacenUsuarios(CboAlmacen, "28")
        Call ListarMovimientoSinOrdenCompra("", "LTO")
        DgvMovimientosSinOrdenCompra.DataSource = Movimientos
        Call ListarDocumentosReferencia()
        Call ListarMotivoAnulacion(CboAnulacion)
        DtFechaConsulta.Value = Now
        DtFechaMovimiento.Value = Now
    End Sub
#End Region                '   Load

#Region "Funciones Publicas"

#Region "Grabar"
    Public Sub Grabar()

        TxtNumeroMovimiento.Focus()
        If ValidarGrabar() = False Then Return
        xTipoCambio = TipoCambio()
        If MsgBox("¿Esta Seguro de GRABAR el ingreso por Orden.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            With Entidad.Guia
                .Cod_Cia = Companhia
                .Tipo_Doc = "IX"
                .Tipo_Mov = CboTipoMovimiento.Value
                .NumDoc = Trim(TxtNumeroMovimiento.Text & "")

                If TxtNumeroMovimiento.Text = "" Then
                    .NumInterno = ""
                Else
                    .NumInterno = Trim(DgvMovimientosSinOrdenCompra.ActiveRow.Cells("NumeroMovimientoInterno").Value & "")
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
                .Status = ""
                .Peso_Aduanas = "0"
                .Cod_Labor = ""
                .Cod_Cantera = ""
                .Cod_Cli = Trim(TxtCodigoProveedor.Text & "")
                .RazSoc = Trim(TxtRazonSocial.Text & "")
                .Cod_Per = ""
                .Cod_Area = ""
                .Tipo_DocOri = ""
                .Doc_Ori = ""
                .Ruc = Trim(TxtRUC.Text & "")
                .Obs = Trim(TxtObservaciones.Text & "")
                .TipDocRef = CboDocumentoReferencia.Value
                .NumDocRef = Trim(TxtSerieNumeroDocumentoReferencia.Text & "") & Trim(TxtNumeroDocumentoReferencia.Text & "")
                .TipoDespacho = "0"
            End With



            For i As Integer = 0 To dgvSinOC.Rows.Count - 1
                Guia = New ETGuia
                With Guia
                    .Cod_Cia = Companhia                                                 '**
                    .Tipo_Mov = CboTipoMovimiento.Value                             '**
                    .Tipo_Doc = "IX"                                                '**
                    .NumDoc = Trim(TxtNumeroMovimiento.Text & "")

                    If TxtNumeroMovimiento.Text = "" Then
                        .NumInterno = ""
                    Else
                        .NumInterno = Trim(DgvMovimientosSinOrdenCompra.ActiveRow.Cells("NumeroMovimientoInterno").Value & "")
                    End If

                    .Cod_Cli = Trim(TxtCodigoProveedor.Text & "")                   '**
                    .Item = i + 1                                                   '**
                    .Cod_Prod = dgvSinOC.Rows(i).Cells("Codigo").Value              '**
                    .Descrip = dgvSinOC.Rows(i).Cells("Descripcion").Value          '**
                    .Unid = dgvSinOC.Rows(i).Cells("UM").Value                      '**
                    .Cant_Ing = dgvSinOC.Rows(i).Cells("Cantidad").Value            '**
                    .Moneda = "S/."                                                 '**
                    .Tipo_Cambio = xTipoCambio                                      '**
                    .Precio = 0                                                     '**
                    .Dcto = 0                                                       '**
                    .Total = dgvSinOC.Rows(i).Cells("Neto").Value                   '**
                    .User_Crea = User_Sistema                                           '**
                    .Item_Fact = 0                                                  '**
                    .Cod_ProdPdc = dgvSinOC.Rows(i).Cells("Codigo").Value           '**
                    .TipProd = dgvSinOC.Rows(i).Cells("TipoProducto").Value         '**
                    .CodOrigen = dgvSinOC.Rows(i).Cells("TipoProducto").Value       '**
                    .Und_OC = ""                                                    '**
                    .Cant_OC = 0                                                    '**
                    .Num_Ord_Exp = Trim(TxtNumeroOC.Text & "")                      '**
                    .Factm = "0"                                                    '**
                    .Cant_Dev = "0"                                                 '**
                    .Movi = "I"                                                     '**
                    .Nro_BlsIni = "0"                                               '**
                    .Nro_BlsFin = "0"                                               '**
                    .Hrs_Lab = "0"                                                  '**
                    .Peso_Bls = "0"                                                 '**
                    .Cant_Ped = "0"                                                 '**
                    .Largo = "0"                                                    '**
                    .Ancho = "0"                                                    '**
                    .Piezas = "0"                                                   '**
                    .Encajado = "0"                                                 '**
                    .Lleno = "0"                                                    '**
                    .Espesor = "0"                                                  '**
                    .Cod_Empleo = ""                                                '**
                    .Cod_Cantera = ""                                               '**
                    .CtaCosto = ""                                                  '**
                    .Cod_Equipo = ""                                                '**
                    .Facturado = ""                                                 '**
                    .Valorizacion = "0"                                             '**
                End With
                DetalleGuia.Add(Guia)
            Next
            If TxtNumeroMovimiento.Text = "" Then
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("AGR", CboTipoMovimiento.Value, "IX", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)
            Else
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("MOD", CboTipoMovimiento.Value, "IX", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)

            End If


            If Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text = "" Then
                MsgBox("Se generó el Ingreso Sin Orden OC N° " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            ElseIf Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text <> "" Then
                MsgBox("Se modificó el Ingreso Sin Orden OC N° " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            DetalleGuia = New List(Of ETGuia)


            Call ListarMovimientoSinOrdenCompra("", "LTO")
            DgvMovimientosSinOrdenCompra.DataSource = Movimientos
            TabIngresoSinOC.Tabs("Listar").Selected = True
            Call Limpiar()

        End If
    End Sub
#End Region

#Region "Nuevo"
    Public Sub Nuevo()
        TabIngresoSinOC.Tabs("Ingreso").Selected = True
        Call Limpiar()
    End Sub
#End Region

#Region "Buscar"
    Public Sub Buscar()
        If TabIngresoSinOC.Tabs("Listar").Selected = True Then
            If Len(TxtBuscarNumeroDocumento.Text) = 0 Then
                Call ListarMovimientoSinOrdenCompra("", "LFE")
                If Movimientos.Rows.Count > 0 Then
                    DgvMovimientosSinOrdenCompra.DataSource = Movimientos
                Else
                    MsgBox("No existen billete(s) generados el dia " & DtFechaConsulta.Value & " .", MsgBoxStyle.Critical, "Comacsa")
                    TxtBuscarNumeroDocumento.Clear()
                    TxtBuscarNumeroDocumento.Focus()
                    Return
                End If

            Else
                Call ListarMovimientoSinOrdenCompra(TxtBuscarNumeroDocumento.Text, "LNU")
                If Movimientos.Rows.Count > 0 Then
                    TabIngresoSinOC.Tabs("Ingreso").Selected = True
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
                    dgvSinOC.DataSource = Negocio.Guia.ListarDetalleIngresoOC(Entidad.Guia)
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
                TxtRUC.Text = Trim(Proveedor.Ruc & "")
            Else
                With dgvSinOC
                    Select Case .ActiveCell.Column.Key
                        Case "Codigo"
                            Dim Productos As New FrmListarProductos
                            gAlmacen = CboAlmacen.Value
                            Productos.ShowDialog()
                            dgvSinOC.ActiveRow.Cells("Codigo").Value = Productos.CODIGO
                            dgvSinOC.ActiveRow.Cells("Descripcion").Value = Productos.DESCRIPCION
                            dgvSinOC.ActiveRow.Cells("UM").Value = Productos.UNIDADMEDIDA
                            dgvSinOC.ActiveRow.Cells("TipoProducto").Value = Productos.TIPO_PRODUCTO
                    End Select
                End With
            End If
        End If
    End Sub
#End Region

#End Region  '   Funciones Publicas
   
End Class