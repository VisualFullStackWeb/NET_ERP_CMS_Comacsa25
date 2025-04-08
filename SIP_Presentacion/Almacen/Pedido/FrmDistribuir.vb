Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Math
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmDistribuir

    '   ***** VARIABLES *****
    Dim Codigo As String = ""
    Dim Almacen As String = ""

    Public Descripcion As String = ""
    Public UM As String = ""

    Dim xTipoCambio As String
    Dim NumeroGuia As String
    Dim NumeroInterno As String
    Dim Serie As String
    Dim NumeroSO As String
    Dim Flag, Ano As String
    Dim NumeroInternoLogistica As String
    Dim NumeroLogistica As String
    Dim NumeroSalidaOrden As String
    Dim NumeroSalidaOrdenInterno As String
    Dim Numero_Req As String

    Dim NumeroMovimiento As String

    Dim numero As Integer
    Dim xNumeroItem As Integer

    Dim StockDistribuir As New DataTable
    Dim dtSerie As New DataTable
    Dim DtFlag As New DataTable
    Dim DtNumeroLogistica As New DataTable
    Dim DtNumeroInterno As New DataTable
    Dim DtModificarOrden As New DataTable
    Dim DtModificarLogistica As New DataTable
    Dim dtDocumentos_Tecnicos As New DataTable
    Dim dtValidarSO As New DataTable

    '   *****   LISTAS  *****
    Dim LstDetAten As New List(Of ETListDetalleAtender)
    Dim Aten As ETListDetalleAtender

    Dim Pedido As New List(Of ETPedido)
    Dim Ped As ETPedido

    Dim SalidaOrden As New List(Of ETGuia)
    Dim SO As ETGuia

    Dim Requerimiento As New List(Of ETRequerimiento)
    Dim Reque As ETRequerimiento

    Public Ls_Permisos As New List(Of Integer)


#Region "Load"

#Region "Load"
    Private Sub FrmAtender_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarArea_General(CboArea)
        Call ListarAlmacen_General(CboAlmacen)
        Call ListarRequisicion()
        Call ListarColaboradorAlmacen()

        ' dgvAtender1.DisplayLayout.Bands(0).Columns("Entrega").CellAppearance.BackColor = Color.Lavender
        '  dgvAtender1.DisplayLayout.Bands(0).Columns("Entrega").CellAppearance.ForeColor = Color.Blue

        dtFechaHoy.Value = Now

    End Sub

#End Region

#End Region                'Load

#Region "Funciones Locales"

#Region "Listar Colaborador Almacen"
    Private Sub ListarColaboradorAlmacen()
        With Entidad.Usuario
            .Cod_Cia = Companhia
        End With
        CmbColaborador.DataSource = Negocio.Usuario.ListarUsers(Entidad.Usuario, "COL")
        CmbColaborador.ValueMember = "Codigo"
        CmbColaborador.DisplayMember = "Obrero"
        CmbColaborador.Value = 0
    End Sub
#End Region

#Region "Listar Requisicion"
    Private Sub ListarRequisicion()
        Entidad.Pedido = New ETPedido
        Negocio.PedidoBL = New NGPedido
        Dim dx As New DataTable

        With Entidad.Pedido
            .Sistema = gSistema
        End With

        dx = Negocio.PedidoBL.Listar_PedidoAtender(Entidad.Pedido, "LAT")

        If dx.Rows.Count > 0 Then
            dgvAtender1.DataSource = dx
        End If

    End Sub

#End Region

#Region "Validar Grabar"
    Private Function Validar() As Boolean

        xTipoCambio = TipoCambio()

        If dgvAtender3.Rows.Count > 0 Then
            numero = 0

            For j As Integer = 0 To dgvAtender3.Rows.Count - 1
                If dgvAtender3.Rows(j).Cells("Action").Value = True Then
                    numero = numero + 1
                End If

                For l As Integer = 0 To StockDistribuir.Rows.Count - 1
                    dgvAtender3.Rows(j).Cells("Stock").Value = Saldo_Stock(dgvAtender3.Rows(j).Cells("Codigo").Value, CboAlmacen.Value, dgvAtender3.Rows(j).Cells("TipoProducto").Value)
                Next
            Next

            If numero = 0 Then
                MsgBox("Debe seleccionar un PRODUCTO para atender.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If


            For i As Integer = 0 To dgvAtender3.Rows.Count - 1
                If dgvAtender3.Rows(i).Cells("Action").Value = True Then

                    If dgvAtender3.Rows(i).Cells("UM").Value <> dgvAtender3.Rows(i).Cells("UMCompra").Value Then
                        If Existe_Producto_Conversion(dgvAtender3.Rows(i).Cells("Codigo").Value, dgvAtender3.Rows(i).Cells("UM").Value, dgvAtender3.Rows(i).Cells("UMCompra").Value) = True Then
                            MsgBox("NO hay factor de conversión para el producto " & dgvAtender3.Rows(i).Cells("Descripcion").Value & " : " & dgvAtender3.Rows(i).Cells("UM").Value & " a " & dgvAtender3.Rows(i).Cells("UMCompra").Value, MsgBoxStyle.Critical, "Comacsa")
                            Return False
                        End If

                        If Existe_Producto_Conversion(dgvAtender3.Rows(i).Cells("Codigo").Value, dgvAtender3.Rows(i).Cells("UMCompra").Value, dgvAtender3.Rows(i).Cells("UM").Value) = True Then
                            MsgBox("NO hay factor de conversión para el producto " & dgvAtender3.Rows(i).Cells("Descripcion").Value & " : " & dgvAtender3.Rows(i).Cells("UMCompra").Value & " a " & dgvAtender3.Rows(i).Cells("UM").Value, MsgBoxStyle.Critical, "Comacsa")
                            Return False
                        End If
                    End If

                    If dgvAtender3.Rows(i).Cells("Stock").Value = 0 And dgvAtender3.Rows(i).Cells("Codigo").Value = "99999999" Then
                        dgvAtender3.Rows(i).Cells("Stock").Value = dgvAtender3.Rows(i).Cells("CantidadSolicitada").Value
                        dgvAtender3.Rows(i).Cells("Stock").Value = dgvAtender3.Rows(i).Cells("CantidadAtendida").Value
                    End If

                    If dgvAtender3.Rows(i).Cells("CantidadAtendida").Value > dgvAtender3.Rows(i).Cells("Stock").Value Then
                        MsgBox("La Cantidad Atendida NO puede ser mayor que el Stock para el producto: " + dgvAtender3.Rows(i).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                        Return False
                    End If

                    If dgvAtender3.Rows(i).Cells("Stock").Value = 0 And dgvAtender3.Rows(i).Cells("CantidadRequerida").Value = 0 Then
                        MsgBox("Debe realizar un Requerimiento para el Producto: " + dgvAtender3.Rows(i).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                        Return False
                    End If

                    If dgvAtender3.Rows(i).Cells("CantidadAtendida").Value > dgvAtender3.Rows(i).Cells("CantidadSolicitada").Value Then
                        MsgBox("La Cantidad Atendida NO puede ser mayor que la Cantidad Solicitada para el producto " + dgvAtender3.Rows(i).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                        Return False
                    End If

                    If dgvAtender3.Rows(i).Cells("Codigo").Value = "00000000" Then
                        MsgBox("No se puede ATENDER productos que NO tengan definido su código.", MsgBoxStyle.Critical, "Comacsa")
                        Return False
                    End If

                    If IsDBNull(dgvAtender3.Rows(i).Cells("Requerimiento").Value) = False And dgvAtender3.Rows(i).Cells("CantidadRequerida").Value > 0 Then
                        MsgBox("Ya se generó un requerimiento de compra, solo puede atender el pedido.", MsgBoxStyle.Critical, "Comacsa")
                        dgvAtender3.Rows(i).Cells("CantidadRequerida").Value = 0
                        Return False
                    End If

                End If
            Next
            Return True
        Else
            MsgBox("No hay DETALLE para Atender.", MsgBoxStyle.Information, "Comacsa")
            Return False
        End If

    End Function
#End Region

#Region "Validar Salida x Orden"
    Private Function ValidarSalidaOrden() As Boolean
        With Entidad.Pedido
            .Cod_Cia = Companhia
            .Tipo_Doc = "RAL"
            .Numero_Doc = dgvAtender1.ActiveRow.Cells("Codigo").Value
        End With
        DtModificarOrden = Negocio.PedidoBL.Listar_Numero_SO(Entidad.Pedido, "LxO")

        If DtModificarOrden.Rows.Count > 0 Then
            NumeroSalidaOrden = Trim(DtModificarOrden.Rows(0).Item("Numero") & "")
        End If

        With Entidad.Guia
            .Cod_Cia = Companhia
            .Tipo_DocOri = "SO"
            .Doc_Ori = NumeroSalidaOrden
        End With
        dtValidarSO = Negocio.Guia.Listar_Guia(Entidad.Guia, "VAL")

        If dtValidarSO.Rows.Count <> 0 Then
            MsgBox("NO se puede ELIMINAR la atención por que tiene MOVIMIENTOS ya realizados.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Validar Requerimiento a Logistica"
    Private Function ValidarRequerimientoLogistica() As Boolean
        With Entidad.Requerimiento
            .Cod_Cia = Companhia
            .DocOri = "RA"
            .NumDocOri = dgvAtender1.ActiveRow.Cells("Codigo").Value
        End With
        Dim DtModificarLogistica1 As New DataTable
        DtModificarLogistica1 = Negocio.Requerimiento.ListarRequerimientoLogistica(Entidad.Requerimiento, "LIS")
        Numero_Req = ""
        If DtModificarLogistica1.Rows.Count > 0 Then
            Numero_Req = DtModificarLogistica1.Rows(0).Item("Numero")
        End If

        DtModificarLogistica = Negocio.Requerimiento.ListarRequerimientoLogistica(Entidad.Requerimiento, "VX")
        If DtModificarLogistica.Rows.Count > 0 Then
            MsgBox("NO se puede ELIMINAR la atención por que tiene MOVIMIENTOS ya realizados.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Validar Eliminacion"
    Private Function ValidarEliminarAtencion() As Boolean
        If ValidarSalidaOrden() = False Then Return False
        If ValidarRequerimientoLogistica() = False Then Return False
        Return True
    End Function
#End Region

#Region "Solo Numeros"
    Private Sub SoloNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 13 Or AscW(e.KeyChar) = 8) Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "Cargar Grilla Distribucion"
    Private Sub CargarGrillaDistribucion()
        If dgvAtender3.Rows.Count > 0 Then
            For i As Integer = 0 To dgvAtender3.Rows.Count - 1
                If dgvAtender3.Rows(i).Cells("Stock").Value = 0 Then
                    dgvAtender3.Rows(i).Cells("CantidadAtendida").Value = 0
                    dgvAtender3.Rows(i).Cells("CantidadRequerida").Value = dgvAtender3.Rows(i).Cells("CantidadSolicitada").Value
                Else
                    If dgvAtender3.Rows(i).Cells("CantidadSolicitada").Value > dgvAtender3.Rows(i).Cells("Stock").Value Then
                        dgvAtender3.Rows(i).Cells("CantidadAtendida").Value = dgvAtender3.Rows(i).Cells("Stock").Value
                        dgvAtender3.Rows(i).Cells("CantidadRequerida").Value = dgvAtender3.Rows(i).Cells("CantidadSolicitada").Value - dgvAtender3.Rows(i).Cells("CantidadAtendida").Value + dgvAtender3.Rows(i).Cells("StockMinimo").Value
                    Else
                        dgvAtender3.Rows(i).Cells("CantidadAtendida").Value = dgvAtender3.Rows(i).Cells("CantidadSolicitada").Value
                        dgvAtender3.Rows(i).Cells("CantidadRequerida").Value = 0
                    End If
                End If

                If dgvAtender3.Rows(i).Cells("StockMinimo").Value > (dgvAtender3.Rows(i).Cells("Stock").Value - dgvAtender3.Rows(i).Cells("CantidadAtendida").Value) Then
                    dgvAtender3.Rows(i).Cells("CantidadRequerida").Value = dgvAtender3.Rows(i).Cells("StockMinimo").Value - (dgvAtender3.Rows(i).Cells("Stock").Value - dgvAtender3.Rows(i).Cells("CantidadAtendida").Value)
                End If
            Next

        End If
    End Sub
#End Region

#End Region   'Funciones Locales

#Region "Funciones Globales"

#Region "Grabar"
    Public Sub Grabar()
        TxtNumeroRequisicion.Focus()
        If TabAtender.Tabs("Atender").Selected = True Then
            If LblEstado.Text = "DISTRIBUIR" Then
                If MsgBox("¿Esta Seguro de DISTRIBUIR el Requerimiento?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                    If Validar() = False Then Return
                    Try

                        With Entidad.Pedido
                            .Cod_Cia = Companhia
                            .Tipo_Doc = "RAL"
                            .Numero_Doc = TxtNumeroRequisicion.Text
                            .User = User_Sistema
                            .Codigo_Almacen = CboAlmacen.Value

                            If numero = dgvAtender3.Rows.Count Then
                                .Estado = "EP"
                            Else
                                .Estado = "A"
                            End If

                            If ChkUrgente.Checked = True Then
                                .Urgente = "U"
                            Else
                                .Urgente = "N"
                            End If

                            If dgvAtender3.Rows.Count > 0 Then
                                For n As Integer = 0 To dgvAtender3.Rows.Count - 1
                                    If dgvAtender3.Rows(n).Cells("Action").Value = True Then
                                        Ped = New ETPedido
                                        With Ped
                                            .Numero_Doc = Trim(TxtNumeroRequisicion.Text & "")
                                            .Codigo_Producto = dgvAtender3.Rows(n).Cells("Codigo").Value
                                            .NumeroMovimiento = NumeroMovimiento
                                            .Estado = "*"
                                            .Item = dgvAtender3.Rows(n).Cells("Item").Value
                                            .Unidad = dgvAtender3.Rows(n).Cells("UM").Value
                                            .Descripcion_Producto = dgvAtender3.Rows(n).Cells("Descripcion").Value
                                            .Cantidad_Requerida = dgvAtender3.Rows(n).Cells("CantidadRequerida").Value
                                            .Cantidad_Atendida = dgvAtender3.Rows(n).Cells("CantidadAtendida").Value
                                            .User = User_Sistema
                                        End With
                                    End If
                                    Pedido.Add(Ped)
                                Next
                                Dim xNumero, yNumero As Integer
                                xNumero = 0
                                yNumero = 0

                                For i As Integer = 0 To dgvAtender3.Rows.Count - 1
                                    If CDbl(dgvAtender3.Rows(i).Cells("CantidadAtendida").Value) > 0 And dgvAtender3.Rows(i).Cells("Action").Value = True Then
                                        xNumero = xNumero + 1
                                    End If

                                    If CDbl(dgvAtender3.Rows(i).Cells("CantidadRequerida").Value) > 0 And dgvAtender3.Rows(i).Cells("Action").Value = True Then
                                        yNumero = yNumero + 1
                                    End If
                                Next

                                If xNumero > 0 Then
                                    With Entidad.Guia
                                        .Cod_Cia = Companhia
                                        .Tipo_Doc = "SO"
                                        .Tipo_Mov = "18"
                                        .NumDoc = Serie + NumeroGuia
                                        .NumInterno = Serie + NumeroInterno
                                        .Cod_Alm = CboAlmacen.Value
                                        .Mov_Stock = "1"
                                        .User_Crea = User_Sistema
                                        .PtoVta = "000"
                                        .NroHrs = 1
                                        .CapacTransp = "0"
                                        .CostoMin = "0"
                                        .Kilometraje = "0"
                                        .Peso_Contenedor = "0"
                                        .Peso_Aduanas = "0"
                                        .Cod_Labor = ""
                                        .Cod_Cantera = Trim(TxtCodigoCantera.Text & "")
                                        .Cod_Cli = Trim(CboContratista.Value & "")
                                        .RazSoc = Trim(CboContratista.Text & "")
                                        .Cod_Per = TxtUserSolicita.Text
                                        .Cod_Area = CboArea.Value
                                        .Ruc = ""
                                        .Tipo_DocOri = ""
                                        .Doc_Ori = ""
                                        .Obs = ""
                                        .TipDocRef = ""
                                        .NumDocRef = ""
                                        .TipoDespacho = "0"
                                        .Status = ""
                                    End With

                                    Dim xItem As Integer
                                    For i As Integer = 0 To dgvAtender3.Rows.Count - 1

                                        If CDbl(dgvAtender3.Rows(i).Cells("CantidadAtendida").Value) > 0 And dgvAtender3.Rows(i).Cells("Action").Value = True Then
                                            SO = New ETGuia
                                            With SO
                                                .NumDoc = Serie + NumeroGuia
                                                .NumInterno = Serie + NumeroInterno
                                                .Cod_Cli = ""
                                                xItem = xItem + 1
                                                .Item = xItem
                                                .Cod_Prod = dgvAtender3.Rows(i).Cells("Codigo").Value
                                                .Descrip = dgvAtender3.Rows(i).Cells("Descripcion").Value
                                                .Unid = dgvAtender3.Rows(i).Cells("UM").Value
                                                .Factm = "0"
                                                .Cant_Ing = dgvAtender3.Rows(i).Cells("CantidadAtendida").Value
                                                .Cant_Dev = "0"
                                                .Moneda = "S/."
                                                .Tipo_Cambio = xTipoCambio
                                                .Precio = "0"
                                                .Dcto = "0"
                                                .Total = "0"
                                                .User_Crea = User_Sistema
                                                .Item_Fact = "0"
                                                .Movi = "S"
                                                .Valorizacion = "0"
                                                .Cod_ProdPdc = dgvAtender3.Rows(i).Cells("Codigo").Value
                                                .Nro_BlsIni = "0"
                                                .Nro_BlsFin = "0"
                                                .Hrs_Lab = "0"
                                                .TipProd = dgvAtender3.Rows(i).Cells("TipoProducto").Value
                                                .CodOrigen = "00"
                                                .Peso_Bls = "0"
                                                .Cant_OC = "0"
                                                .Cod_Equipo = Trim(dgvAtender3.Rows(i).Cells("CodigoActivo").Value & "")
                                                .Facturado = ""
                                                .CtaCosto = ""
                                                .Cant_Ped = "0"
                                                .Largo = "0"
                                                .Ancho = "0"
                                                .Piezas = "0"
                                                .Encajado = "0"
                                                .Lleno = "0"
                                                .Espesor = "0"
                                                .NumeroRequisicion = Trim(TxtNumeroRequisicion.Text & "")
                                                .Cod_Empleo = Trim(dgvAtender3.Rows(i).Cells("CodigoAplicacion").Value & "")
                                                .Cod_Cantera = Trim(dgvAtender3.Rows(i).Cells("CodigoCantera").Value & "")
                                                .NumeroRequisicion = Trim(TxtNumeroRequisicion.Text & "")
                                                .Colaborador = Trim(CmbColaborador.Value & "")
                                                .Item_Pedido = dgvAtender3.Rows(i).Cells("Item").Value

                                            End With
                                            SalidaOrden.Add(SO)
                                        End If
                                    Next
                                End If

                                If yNumero > 0 Then
                                    With Entidad.Requerimiento
                                        .NroReq = NumeroLogistica + "-" + Trim(Flag & "") + "-" + Ano
                                        .Cod_Cia = Companhia
                                        .Lugar_Ent = CboAlmacen.Value
                                        .DocOri = "RA"
                                        .NumDocOri = TxtNumeroRequisicion.Text
                                        .Nro_Int = NumeroInternoLogistica
                                        .User_Crea = User_Sistema
                                        .Sistema = gSistema
                                        .User_Recibe = Trim(TxtUserSolicita.Text & "")
                                        If ChkUrgente.Checked = True Then
                                            .Prioridad = 1
                                        Else
                                            .Prioridad = 0
                                        End If
                                    End With

                                    Dim ItemLogistica As Integer = 0
                                    For i As Integer = 0 To dgvAtender3.Rows.Count - 1
                                        If dgvAtender3.Rows(i).Cells("CantidadRequerida").Value > 0 And dgvAtender3.Rows(i).Cells("Action").Value = True Then
                                            Reque = New ETRequerimiento

                                            With Reque
                                                .CodigoProducto = dgvAtender3.Rows(i).Cells("Codigo").Value
                                                .Unidad = Trim(dgvAtender3.Rows(i).Cells("UMCompra").Value & "")
                                                .Unidad_Pedida = dgvAtender3.Rows(i).Cells("UM").Value
                                                .Cantidad = dgvAtender3.Rows(i).Cells("CantidadRequerida").Value
                                                .Empleo = Trim(dgvAtender3.Rows(i).Cells("Aplicacion").Value & "")
                                                .Item = i + 1
                                                .Nro_Int = Trim(NumeroInternoLogistica & "")
                                                .Memo = Trim(dgvAtender3.Rows(i).Cells("Observacion").Value & "")
                                                .User_Crea = User_Sistema
                                                .NumeroDocumento = TxtNumeroRequisicion.Text
                                                .Cantidad_Pedida = dgvAtender3.Rows(i).Cells("CantidadSolicitada").Value
                                                .Item_Pedido = dgvAtender3.Rows(i).Cells("Item").Value

                                            End With
                                            Requerimiento.Add(Reque)


                                        End If
                                    Next
                                End If

                                Entidad.Resultado = Negocio.PedidoBL.GrabarDistribucionPedido(Entidad.Pedido, Pedido, xNumero, yNumero, Entidad.Guia, SalidaOrden, Entidad.Requerimiento, Requerimiento)

                                If Entidad.Resultado.Realizo = True And xNumero > 0 Then

                                    Dim Reporte As New Rpt_Suministros_Envio
                                    StrucForm.FxListaProducto = New Rpt_Suministros_Envio
                                    gDocumentoAtender = Trim(TxtNumeroRequisicion.Text)
                                    Dim Serie As String = ""
                                    Serie = Negocio.Guia.Serie_Movimoiento(Companhia, CboAlmacen.Value)
                                    gDocumentoSalidaOrden = Serie & Entidad.Resultado.Mensaje
                                    StrucForm.FxListaProducto.NombreReporte = "Salida x Orden [" & Entidad.Resultado.Mensaje & "]"
                                    StrucForm.FxListaProducto.MdiParent = MdiParent
                                    StrucForm.FxListaProducto.Show()

                                End If

                                Pedido = New List(Of ETPedido)
                                SalidaOrden = New List(Of ETGuia)
                                Requerimiento = New List(Of ETRequerimiento)

                                TabAtender.Tabs("Listar").Selected = True
                                Call ListarRequisicion()
                                CmbColaborador.Value = 0
                            End If

                        End With
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Else
                    Return
                End If
            End If
        Else
            MsgBox("NO hay detalle para GRABAR", MsgBoxStyle.Information, "Comacsa")
            Return
        End If
    End Sub
#End Region

#Region "Reporte"
    Public Sub Reporte()
        If TabAtender.Tabs("Atender").Selected = False Then
            If dgvAtender1.ActiveRow.Cells("SalidaOrden").Value <> 0 Then
                Dim Reporte As New Rpt_Suministros_Envio
                StrucForm.FxListaProducto = New Rpt_Suministros_Envio
                gDocumentoAtender = dgvAtender1.ActiveRow.Cells("Codigo").Value
                gDocumentoSalidaOrden = dgvAtender1.ActiveRow.Cells("SalidaOrden").Value
                StrucForm.FxListaProducto.NombreReporte = "Salida x Orden [" & Trim(dgvAtender1.ActiveRow.Cells("SalidaOrden").Value & "") & "]"
                StrucForm.FxListaProducto.MdiParent = MdiParent
                StrucForm.FxListaProducto.Show()
            End If
        Else
            Return
        End If

    End Sub
#End Region

#Region "Cancelar"
    Public Sub Cancelar()
        With Entidad.Pedido
            .Cod_Cia = Companhia
            .Tipo_Doc = "RAL"
            .Numero_Doc = TxtNumeroRequisicion.Text
            .Codigo_Almacen = dgvAtender1.ActiveRow.Cells("CodigoAlmacen").Value
        End With
        dgvAtender3.DataSource = Negocio.PedidoBL.ListarDetallePedido(Entidad.Pedido, "LEP")

    End Sub
#End Region

#End Region  'Funciones Globales

#Region "Eventos Controles"

#Region "dgvAtender1 - DoubleClickRow"
    Private Sub dgvAtender1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvAtender1.DoubleClickRow
        If dgvAtender1.Rows.Count = 0 Then
            Return
        End If

        TabAtender.Tabs("Atender").Selected = True
        TabAtender.Tabs("Atender").Enabled = True
        dtRegistro.Value = e.Row.Cells("Fecha").Value
        TxtNumeroRequisicion.Text = e.Row.Cells("Codigo").Value
        TxtUserSolicita.Text = e.Row.Cells("CodigoUsuario").Value
        TxtNombreUsuario.Text = e.Row.Cells("NombreUsuario").Value
        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        CboArea.Value = e.Row.Cells("CodigoArea").Value
        dtEntrega.Value = e.Row.Cells("Entrega").Value

        TxtCodigoCantera.Text = Trim(e.Row.Cells("CodigoCantera").Value & "")
        TxtCantera.Text = Trim(e.Row.Cells("Cantera").Value & "")
        Call ContratistaCantera(CboContratista, TxtCodigoCantera.Text, CboArea.Value)
        CboContratista.Value = e.Row.Cells("CodigoProveedor").Value

        If e.Row.Cells("CodigoEstado").Value = "EP" Then
            LblEstado.Text = "EN PROCESO"
        Else
            LblEstado.Text = "DISTRIBUIR"
        End If

        With Entidad.Pedido
            .Cod_Cia = Companhia
            .Tipo_Doc = "RAL"
            .Numero_Doc = TxtNumeroRequisicion.Text
            .Codigo_Almacen = dgvAtender1.ActiveRow.Cells("CodigoAlmacen").Value
        End With

        If CboArea.Value <> 22 Then
            LblCantera.Visible = False
            TxtCodigoCantera.Visible = False
            TxtCantera.Visible = False

            LblContratista.Visible = False
            CboContratista.Visible = False

        Else
            LblCantera.Visible = True
            TxtCodigoCantera.Visible = True
            TxtCantera.Visible = True

            LblContratista.Visible = True
            CboContratista.Visible = True
        End If

        dgvAtender3.DataSource = Negocio.PedidoBL.ListarDetallePedido(Entidad.Pedido, "LEP")

        If dgvAtender3.Rows.Count > 0 Then
            Dim Mensaje As String = ""
            For a As Integer = 0 To dgvAtender3.Rows.Count - 1

                If IsDBNull(dgvAtender3.Rows(a).Cells("Requerimiento").Value) = True Then
                    With Entidad.Producto
                        .Cod_Cia = Companhia
                        .Unidad = dgvAtender3.Rows(a).Cells("UM").Value
                        .UnidadDesp = dgvAtender3.Rows(a).Cells("UMCompra").Value
                        .CodProducto = dgvAtender3.Rows(a).Cells("Codigo").Value
                    End With

                    Dim xRequerida As Decimal
                    Entidad.Resultado = Negocio.Guia.ConvertirIngresoAlmacen(Entidad.Producto, dgvAtender3.Rows(a).Cells("CantidadSolicitada").Value)
                    xRequerida = Entidad.Resultado.Mensaje
                    dgvAtender3.Rows(a).Cells("CantidadRequerida").Value = xRequerida
                    dgvAtender3.Rows(a).Cells("CantidadAtendida").Value = 0

                Else
                    dgvAtender3.Rows(a).Cells("CantidadRequerida").Value = 0
                    dgvAtender3.Rows(a).Cells("CantidadAtendida").Value = dgvAtender3.Rows(a).Cells("CantidadSolicitada").Value

                End If

                If dgvAtender3.Rows(a).Cells("UM").Value <> dgvAtender3.Rows(a).Cells("UMCompra").Value Then
                    With Entidad.Producto
                        .Cod_Cia = Companhia
                        .CodProducto = dgvAtender3.Rows(a).Cells("Codigo").Value
                        .Unidad = dgvAtender3.Rows(a).Cells("UM").Value
                        .UnidadDesp = dgvAtender3.Rows(a).Cells("UMCompra").Value
                    End With
                    Dim Existencia As New DataTable
                    Existencia = Negocio.Producto.Existe_Producto_Conversion(Entidad.Producto)

                    If Existencia.Rows.Count = 0 Then
                        Mensaje = Mensaje & "El producto " & dgvAtender3.Rows(a).Cells("Codigo").Value & " ," & vbCrLf
                    End If
                End If

            Next
            If Mensaje <> "" Then
                MsgBox(Mensaje & " NO tiene(n) factor de conversión para ingresar al almacén." & vbCrLf & "Al terminar de registar la conversión ACTUALIZE la pantalla.", MsgBoxStyle.Critical, "Comacsa")
            End If
        End If

    End Sub
#End Region

#Region "DgvAtender3 - DoubleClickRow"
    Private Sub dgvAtender3_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvAtender3.DoubleClickRow
        Dim dtOC As New DataTable
        With Entidad.OrdenCompra
            .Cod_Cia = Companhia
            .Cod_Prod = dgvAtender3.ActiveRow.Cells("Codigo").Value
        End With

        dtOC = Negocio.Producto.ListarProductosOC(Entidad.OrdenCompra, "LOC")

        If dtOC.Rows.Count > 0 Then
            TxtCodigoProducto.Text = dgvAtender3.ActiveRow.Cells("Codigo").Value
            TxtDescripcionProducto.Text = dgvAtender3.ActiveRow.Cells("Descripcion").Value
            With Entidad.OrdenCompra
                .Cod_Cia = Companhia
                .Cod_Prod = Trim(TxtCodigoProducto.Text & "")
            End With
            CmbOC.DataSource = Negocio.Producto.ListarProductosOC(Entidad.OrdenCompra, "LOC")
            CmbOC.DisplayMember = "Descripcion"
            CmbOC.ValueMember = "Numero"
            GrpOC.Visible = True
        Else
            MsgBox("NO hay O/C autorizadas para el producto " & Trim(dgvAtender3.ActiveRow.Cells("Descripcion").Value), MsgBoxStyle.Critical, "Comacsa")
            Return
        End If
    End Sub
#End Region

#Region "CmbOC - ValueChanged"
    Private Sub CmbOC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOC.ValueChanged
        With Entidad.OrdenCompra
            .Cod_Cia = Companhia
            .Nro_OC = CmbOC.Value
        End With
        DgvOC.DataSource = Negocio.Producto.ListarProductosOC(Entidad.OrdenCompra, "LIS")
    End Sub
#End Region

#Region "BtnSalir - Click"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        GrpOC.Visible = False
    End Sub
#End Region

#Region "BtnAsignarCodigo - Click"
    Private Sub BtnAsignarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsignarCodigo.Click

        If dgvAtender3.Rows.Count = 0 Then
            Return
        End If


        If dgvAtender3.ActiveRow.Cells("Codigo").Value = "" Then
            MsgBox("Debe CANCELAR las modificaciones.", MsgBoxStyle.Information, "Comacsa")
            Return
        End If

        If dgvAtender3.ActiveRow.Cells("Codigo").Value <> "00000000" Then
            MsgBox("NO se puede asignar un código. Debe seleccionar un producto con código 00000000.", MsgBoxStyle.Information, "Comacsa")
            Return
        End If

        Descripcion = dgvAtender3.ActiveRow.Cells("Descripcion").Value
        UM = dgvAtender3.ActiveRow.Cells("UM").Value

        Dim Registrar As New FrmMaestroSuministros
        Registrar.WindowState = FormWindowState.Normal

        Registrar.TabMaestroSumunistros.Tabs("Registro").Enabled = True
        Registrar.TabMaestroSumunistros.Tabs("Consulta").Enabled = True
        Registrar.btnGuardar.Visible = True
        ' Registrar.CmbNombreComercial.ReadOnly = True
        Registrar.Nuevo()
        Registrar.CmbNombreComercial.Text = Trim(Descripcion & "")
        Registrar.CmbUnidadDespacho.Value = Trim(UM & "")
        Registrar.ShowDialog()

        dgvAtender3.ActiveRow.Cells("Codigo").Value = Registrar.CodigoProducto
        dgvAtender3.ActiveRow.Cells("Descripcion").Value = Registrar.DescripcionProducto
        dgvAtender3.ActiveRow.Cells("UM").Value = Registrar.UMProducto

    End Sub
#End Region

#Region "Evento_Activated"
    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub
#End Region

#End Region   'Eventos Controles

End Class