Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmSalidaRemarcado

    '   *****       VARIABLES   *****
    Dim Serie As String
    Dim NumeroMovimiento As String
    Dim dtNumeroMovimientoAlmacen As New DataTable
    Dim movimientos As New DataTable
    Dim dtSerie As New DataTable
    Dim xTipoCambio As String
    Dim NumeroInternoMovimiento As String
    Dim xNumeroIngresoXorden As String
    Dim xNumeroInternoIngresoXorden As String

    '   *****   LISTAS  *****
    Dim DetalleGuia As New List(Of ETGuia)
    Dim Guia As ETGuia

    Dim Detalle_Guia_Re As New List(Of ETGuia)
    Dim Guia_Re As ETGuia

    Dim Pedido As New List(Of ETPedido)
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Publicas"

#Region "Grabar"
    Public Sub Grabar()

        TxtNumeroMovimiento.Focus()
        ' If ValidarGrabar() = False Then Return
        xTipoCambio = TipoCambio()
        If MsgBox("¿Esta seguro de grabar la Salida por cambio de producto (Remarcado).?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            With Entidad.Guia
                .Cod_Cia = Companhia
                .Tipo_Doc = "SE"
                .Tipo_Mov = CboTipoMovimiento.Value
                .NumDoc = xNumeroIngresoXorden
                .NumInterno = xNumeroInternoIngresoXorden
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
                .Cod_Cli = "00000000"
                .RazSoc = Trim(CboTipoMovimiento.Text & "")
                .Cod_Per = ""
                .Cod_Area = ""
                .Tipo_DocOri = ""
                .Doc_Ori = ""
                .Ruc = ""
                .Obs = ""
                .TipDocRef = ""
                .NumDocRef = ""
                .TipoDespacho = "0"
                .Status = ""
            End With

            For i As Integer = 0 To dgvDetalleSalidaRemarcado.Rows.Count - 1
                Guia = New ETGuia
                With Guia
                    .Cod_Cia = Companhia                                                         '**
                    .Tipo_Mov = CboTipoMovimiento.Value                                     '**
                    .Tipo_Doc = "SE"                                                        '**
                    .NumDoc = Trim(TxtNumeroMovimiento.Text & "")                                        '**

                    If TxtNumeroMovimiento.Text = "" Then
                        .NumInterno = ""
                    Else
                        .NumInterno = DgvSalidaRemarcado.ActiveRow.Cells("NumeroInternoMovimiento").Value                               '**
                    End If
                   
                    .Cod_Cli = "00000000"                                                   '**
                    .Item = i + 1                                                           '**
                    .Cod_Prod = dgvDetalleSalidaRemarcado.Rows(i).Cells("Codigo").Value       '**
                    .Descrip = dgvDetalleSalidaRemarcado.Rows(i).Cells("Descripcion").Value   '**
                    .Unid = dgvDetalleSalidaRemarcado.Rows(i).Cells("UM").Value           '**
                    .Cant_Ing = dgvDetalleSalidaRemarcado.Rows(i).Cells("Cantidad").Value     '**
                    .Moneda = "S/."                                                         '**
                    .Tipo_Cambio = xTipoCambio                                              '**
                    .Precio = 0                                                             '**
                    .Dcto = 0                                                               '**
                    .Total = 0                                                              '**
                    .User_Crea = User_Sistema                                                   '**
                    .Item_Fact = 0                                                          '**
                    .Cod_ProdPdc = dgvDetalleSalidaRemarcado.Rows(i).Cells("Codigo").Value    '**
                    .TipProd = dgvDetalleSalidaRemarcado.Rows(i).Cells("TipoProducto").Value  '**
                    .CodOrigen = ""    '**
                    .Und_OC = dgvDetalleSalidaRemarcado.Rows(i).Cells("UMIngresoAlmacen").Value                                                            '**
                    .Cant_OC = dgvDetalleSalidaRemarcado.Rows(i).Cells("CantidadIngresoAlmacen").Value                                                           '**

                    If IsDBNull(dgvDetalleSalidaRemarcado.Rows(i).Cells("OC").Value) = True Then
                        .Num_Ord_Exp = ""
                    Else
                        .Num_Ord_Exp = dgvDetalleSalidaRemarcado.Rows(i).Cells("OC").Value
                    End If

                    .Factm = "0"                                                            '**
                    .Cant_Dev = "0"                                                         '**
                    .Movi = "S"                                                             '**
                    .Nro_BlsIni = "0"                                                       '**
                    .Nro_BlsFin = "0"                                                       '**
                    .Hrs_Lab = "0"                                                          '**
                    .Peso_Bls = "0"                                                         '**
                    .Cant_Ped = "0"                                                         '**
                    .Largo = "0"                                                            '**
                    .Ancho = "0"                                                            '**
                    .Piezas = "0"                                                           '**
                    .Encajado = "0"                                                         '**
                    .Lleno = "0"                                                            '**
                    .Espesor = "0"                                                          '**
                    .Cod_Empleo = ""                                                        '**
                    .Cod_Cantera = ""                                                       '**
                    .CtaCosto = ""                                                          '**
                    .Cod_Equipo = ""                                                        '**
                    .Facturado = ""                                                         '**
                    .Valorizacion = "0"                                                     '**
                End With
                DetalleGuia.Add(Guia)

                Guia_Re = New ETGuia
                With Guia_Re
                    .Cod_Cia = Companhia                                                         '**
                    .Tipo_Mov = "23"                                     '**
                    .Tipo_Doc = "IE"                                                        '**
                    .NumDoc = Trim(TxtNumeroMovimiento.Text & "")                                        '**

                    If TxtNumeroMovimiento.Text = "" Then
                        .NumInterno = ""
                    Else
                        .NumInterno = DgvSalidaRemarcado.ActiveRow.Cells("NumeroInternoMovimiento").Value
                    End If


                    .Cod_Cli = "00000000"                                                   '**
                    .Item = i + 1                                                          '**
                    .Cod_Prod = dgvDetalleSalidaRemarcado.Rows(i).Cells("CodigoTransferir").Value       '**
                    .Descrip = dgvDetalleSalidaRemarcado.Rows(i).Cells("DescripcionTransferir").Value   '**
                    .Unid = dgvDetalleSalidaRemarcado.Rows(i).Cells("UMIngresoAlmacen").Value           '**
                    .Cant_Ing = dgvDetalleSalidaRemarcado.Rows(i).Cells("CantidadIngresoAlmacen").Value     '**
                    .Moneda = "S/."                                                         '**
                    .Tipo_Cambio = xTipoCambio                                              '**
                    .Precio = 0                                                             '**
                    .Dcto = 0                                                               '**
                    .Total = 0                                                              '**
                    .User_Crea = User_Sistema                                                   '**
                    .Item_Fact = 0                                                          '**
                    .Cod_ProdPdc = dgvDetalleSalidaRemarcado.Rows(i).Cells("CodigoTransferir").Value    '**
                    .TipProd = dgvDetalleSalidaRemarcado.Rows(i).Cells("TipoProductoTransferir").Value  '**
                    .CodOrigen = ""    '**
                    .Und_OC = dgvDetalleSalidaRemarcado.Rows(i).Cells("UMIngresoAlmacen").Value                                                            '**
                    .Cant_OC = dgvDetalleSalidaRemarcado.Rows(i).Cells("CantidadIngresoAlmacen").Value                                                           '**
                    If IsDBNull(dgvDetalleSalidaRemarcado.Rows(i).Cells("OC").Value) = True Then
                        .Num_Ord_Exp = ""
                    Else
                        .Num_Ord_Exp = dgvDetalleSalidaRemarcado.Rows(i).Cells("OC").Value
                    End If

                    .Factm = "0"                                                            '**
                    .Cant_Dev = "0"                                                         '**
                    .Movi = "I"                                                             '**
                    .Nro_BlsIni = "0"                                                       '**
                    .Nro_BlsFin = "0"                                                       '**
                    .Hrs_Lab = "0"                                                          '**
                    .Peso_Bls = "0"                                                         '**
                    .Cant_Ped = "0"                                                         '**
                    .Largo = "0"                                                            '**
                    .Ancho = "0"                                                            '**
                    .Piezas = "0"                                                           '**
                    .Encajado = "0"                                                         '**
                    .Lleno = "0"                                                            '**
                    .Espesor = "0"                                                          '**
                    .Cod_Empleo = ""                                                        '**
                    .Cod_Cantera = ""                                                       '**
                    .CtaCosto = ""                                                          '**
                    .Cod_Equipo = ""                                                        '**
                    .Facturado = ""                                                         '**
                    .Valorizacion = "0"                                                     '**
                End With
                Detalle_Guia_Re.Add(Guia_Re)
            Next


            If TxtNumeroMovimiento.Text = "" Then
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("AGR", CboTipoMovimiento.Value, "SE", Entidad.Guia, DetalleGuia, Pedido, Detalle_Guia_Re, Entidad.Almacen)
            Else
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("MOD", CboTipoMovimiento.Value, "SE", Entidad.Guia, DetalleGuia, Pedido, Detalle_Guia_Re, Entidad.Almacen)
            End If


            If Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text = "" Then
                MsgBox("Se generó la Salida por Cambio de Producto " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            ElseIf Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text <> "" Then
                MsgBox("Se modificó la Salida por Cambio de Producto " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            DetalleGuia = New List(Of ETGuia)
            Detalle_Guia_Re = New List(Of ETGuia)

            Call ListarMovimientoSalidaRemarcado("", "LTO")
            DgvSalidaRemarcado.DataSource = movimientos
            TabSalidaRemarcado.Tabs("Listar").Selected = True
            Call Limpiar()

        End If
    End Sub

#End Region

#Region "Nuevo"
    Public Sub Nuevo()
        TabSalidaRemarcado.Tabs("Salida").Selected = True
        dtFeStringegistro.Value = Now
        dtFeStringegistro.Value = Now
        TxtNumeroMovimiento.Clear()
        TxtNumeroDocumento.Clear()
        CboAlmacen.ReadOnly = False
        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
            .Cod_Alm = CboAlmacen.Value
        End With
        dgvDetalleSalidaRemarcado.DataSource = Negocio.Guia.ListarDetalleSalidaRemarcado(Entidad.Guia)
    End Sub
#End Region

#Region "Buscar"
    Public Sub Buscar()

        If CboAlmacen.Value = 0 Then
            MsgBox("Debe seleccionar un ÁLMACEN para continuar.", MsgBoxStyle.Critical, "Comacsa")
            Return
        End If

        With dgvDetalleSalidaRemarcado
            Select Case .ActiveCell.Column.Key
                Case "Codigo"
                    Dim Productos As New FrmListarProductos
                    gAlmacen = CboAlmacen.Value
                    Productos.ShowDialog()
                    dgvDetalleSalidaRemarcado.ActiveRow.Cells("Codigo").Value = Productos.CODIGO
                    dgvDetalleSalidaRemarcado.ActiveRow.Cells("Descripcion").Value = Productos.DESCRIPCION
                    dgvDetalleSalidaRemarcado.ActiveRow.Cells("UM").Value = Productos.UNIDADMEDIDA
                    dgvDetalleSalidaRemarcado.ActiveRow.Cells("TipoProducto").Value = Productos.UNIDADMEDIDA
                    dgvDetalleSalidaRemarcado.ActiveRow.Cells("Stock").Value = Productos.STOCK
                    CboAlmacen.ReadOnly = True
                    Call UbicarCursorGrilla(dgvDetalleSalidaRemarcado, dgvDetalleSalidaRemarcado.ActiveRow, "Cantidad")

                Case "CodigoTransferir"
                    If IsDBNull(dgvDetalleSalidaRemarcado.ActiveRow.Cells("Codigo").Value) = True Then
                        MsgBox("Debe seleccionar un producto a transferir.", MsgBoxStyle.Critical, "Comacsa")
                        Call UbicarCursorGrilla(dgvDetalleSalidaRemarcado, dgvDetalleSalidaRemarcado.ActiveRow, "Codigo")
                        Return
                    ElseIf IsDBNull(dgvDetalleSalidaRemarcado.ActiveRow.Cells("Cantidad").Value) = True Then
                        MsgBox("Debe escribir una cantidad a transferir.", MsgBoxStyle.Critical, "Comacsa")
                        dgvDetalleSalidaRemarcado.ActiveRow.Cells("Cantidad").Activated = True
                        Call UbicarCursorGrilla(dgvDetalleSalidaRemarcado, dgvDetalleSalidaRemarcado.ActiveRow, "Codigo")
                        Return
                    End If

                    Dim Productos As New FrmListarProductos
                    gAlmacen = CboAlmacen.Value
                    Productos.ShowDialog()
                    dgvDetalleSalidaRemarcado.ActiveRow.Cells("CodigoTransferir").Value = Productos.CODIGO
                    dgvDetalleSalidaRemarcado.ActiveRow.Cells("DescripcionTransferir").Value = Productos.DESCRIPCION
                    dgvDetalleSalidaRemarcado.ActiveRow.Cells("UMIngresoAlmacen").Value = Productos.UNIDADMEDIDA
                    dgvDetalleSalidaRemarcado.ActiveRow.Cells("TipoProductoTransferir").Value = Productos.TIPO_PRODUCTO
                    Call UbicarCursorGrilla(dgvDetalleSalidaRemarcado, dgvDetalleSalidaRemarcado.ActiveRow, "CantidadIngresoAlmacen")

                Case Else
                    MsgBox("Esta columna esta INACTIVA", MsgBoxStyle.Exclamation, "Comacsa")
            End Select
        End With
    End Sub
#End Region

#End Region  '   Funciones Publicas

#Region "Funciones Locales"

#Region "Limpiar"
    Private Sub Limpiar()
        TxtNumeroMovimiento.Clear()
        dtFeStringegistro.Value = Now
        CboAlmacen.Value = 28
        CboAnulacion.Value = 0
        GrpAnulacion.Visible = False
        LblEstado.Text = ""
    End Sub
#End Region

#Region "Validar Numero Movimiento Almacen"
    Private Function ValidarNumeroMovimientoAlmacen() As Boolean
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Tipo_Mov = Trim(CboTipoMovimiento.Value & "")
            .Tipo_Doc = "SE"
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

#Region "Listar Movimientos Salida por Cambio de Producto"
    Private Sub ListarMovimientoSalidaRemarcado(ByVal Documento As String, ByVal Opcion As String)
        With Entidad.Guia
            Dim ab, cd As String
            .Cod_Cia = Companhia
            .NumDoc = Documento
            .Tipo_Doc = "SE"
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
        movimientos = Negocio.Guia.ListarMovimientoPorAjuste(Entidad.Guia, Opcion)
    End Sub
#End Region

#End Region   '   Funciones Locales

#Region "Evento Controles"

#Region "dgvDetalleSalidaRemarcado - AfterCellUpdate"
    Dim Tarea As Boolean = False
    Private Sub dgvDetalleSalidaRemarcado_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvDetalleSalidaRemarcado.AfterCellUpdate
        If Tarea = True Then Return
        If e.Cell.Column.Key = "Codigo" Then
            If Len(e.Cell.Row.Cells("Codigo").Value) <> 8 Then
                Tarea = True
                e.Cell.Row.Cells("Descripcion").Value = ""
                e.Cell.Row.Cells("UM").Value = ""
                e.Cell.Row.Cells("Stock").Value = ""
                e.Cell.Row.Cells("Cantidad").Value = ""
                Tarea = False
            End If
        End If

        If e.Cell.Column.Key = "CodigoTransferir" Then
            If Len(e.Cell.Row.Cells("CodigoTransferir").Value) <> 8 Then
                Tarea = True
                e.Cell.Row.Cells("DescripcionTransferir").Value = ""
                e.Cell.Row.Cells("UMIngresoAlmacen").Value = ""
                Tarea = False
            End If

            If e.Cell.Row.Cells("Codigo").Value = e.Cell.Row.Cells("CodigoTransferir").Value Then
                Tarea = True
                e.Cell.Row.Cells("CodigoTransferir").Value = ""
                MsgBox("El producto a transferir NO puede ser el mismo que el producto origen.", MsgBoxStyle.Critical, "Comacsa")
                Return
            End If


            If e.Cell.Row.Cells("Cantidad").Value <> 0 Then
                Tarea = True
                e.Cell.Row.Cells("CantidadIngresoAlmacen").Value = e.Cell.Row.Cells("Cantidad").Value
                Tarea = False
            End If
        End If

        If e.Cell.Column.Key = "Cantidad" Then
            If IsDBNull(e.Cell.Row.Cells("CantidadBase").Value) = True Then
                e.Cell.Row.Cells("CantidadBase").Value = "0"
            End If

            If IsDBNull(e.Cell.Row.Cells("CodigoTransferir").Value) = True Then
                e.Cell.Row.Cells("CodigoTransferir").Value = ""
            End If


            If CDbl(e.Cell.Row.Cells("Cantidad").Value) > (CDbl(e.Cell.Row.Cells("Stock").Value) + CDbl(e.Cell.Row.Cells("CantidadBase").Value)) Then
                Tarea = True
                MsgBox("La cantidad NO puede ser mayor que el STOCK.", MsgBoxStyle.Critical, "Comacsa")
                e.Cell.Row.Cells("Cantidad").Value = 0
                Tarea = False
                Return
                Call UbicarCursorGrilla(dgvDetalleSalidaRemarcado, dgvDetalleSalidaRemarcado.ActiveRow, "Cantidad")
            End If

            If e.Cell.Row.Cells("CodigoTransferir").Value <> "" Then
                e.Cell.Row.Cells("CantidadIngresoAlmacen").Value = e.Cell.Row.Cells("Cantidad").Value
            End If

        End If
    End Sub
#End Region

#Region "dgvDetalleSalidaRemarcado - KeyDown"
    Private Sub dgvDetalleSalidaRemarcado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalleSalidaRemarcado.KeyDown
        With sender
            Select Case e.KeyValue
                Case Keys.Up
                    .PerformAction(ExitEditMode)
                    .PerformAction(AboveCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Down
                    .PerformAction(ExitEditMode)
                    .PerformAction(BelowCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Right
                    .PerformAction(ExitEditMode)
                    .PerformAction(NextCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Left
                    .PerformAction(ExitEditMode)
                    .PerformAction(PrevCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Return
                    .PerformAction(ExitEditMode)
                    .PerformAction(BelowCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
            End Select
        End With
    End Sub
#End Region

#Region "DgvSalidaRemarcado - DoubleClickRow"
    Private Sub DgvSalidaRemarcado_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvSalidaRemarcado.DoubleClickRow
        TabSalidaRemarcado.Tabs("Salida").Selected = True

        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        CboAlmacen.ReadOnly = True
        TxtNumeroMovimiento.Text = e.Row.Cells("NumeroDocumento").Value

        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
            .Cod_Alm = CboAlmacen.Value
        End With
        dgvDetalleSalidaRemarcado.DataSource = Negocio.Guia.ListarDetalleSalidaRemarcado(Entidad.Guia)
    End Sub
#End Region

#End Region    '   Evento Controles

#Region "Load"
    Private Sub FrmSalidaRemarcado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarMotivoAnulacion(CboAnulacion)
        Call ListarMovimientosUsuario(CboTipoMovimiento, "27")
        Call ListarAlmacenUsuarios(CboAlmacen, "28")
        Call ListarMovimientoSalidaRemarcado("", "LTO")
        DgvSalidaRemarcado.DataSource = movimientos
        DtFechaConsulta.Value = Now
        dtFeStringegistro.Value = Now
    End Sub
#End Region                '   Load

End Class