Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Imports System.IO
'Imports Microsoft.Office.Interop.Excel

Public Class FrmLiquidacionEntregas
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private TipoG As sTate
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_EntregaEliminado As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private columna As String
    Private filtroConcepto As String = String.Empty
    Dim esDevolucion As Int32 = 0
    Dim totalPend As Double = 0
    Dim numInterno As String = String.Empty
    Dim moneda As String = String.Empty
    Dim tipmon As String = String.Empty
    Dim estado As String = String.Empty
    Dim auxi As String = String.Empty
    Dim flgauxi As Int32 = 0
    Dim esprimera As Int32 = 0
    Dim tipotabla As Int32 = 0
    Dim cancelado As Int32 = 0
    Private idPendiente As Int32 = 0
    Dim anho As Int32
    Dim mes As Int32
    Dim monto As Double
    Dim ruc_Prov As String
    Dim fecha As DateTime
    Dim numDoc As String = String.Empty
#End Region
#Region "Procedimientos Privados"
    Private Sub Inicio()
        Call HabilitarControles(False)
        Call CargarDatos()
        Me.dtFechaSalida.Value = Now.Date
        Me.dtFechaRetorno.Value = Now.Date
        Me.TabMaestroEntregas.Tabs("Lista").Selected = True
        txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
        txttotalsolicitud.Text = CDbl("0.00").ToString("#####0.00")
        txtdevolucion.Text = CDbl("0.00").ToString("#####0.00")
        txtreintegro.Text = CDbl("0.00").ToString("#####0.00")
        esprimera = 1
    End Sub

    Sub comboMoneda()
        Dim valueList = New ValueList()
        valueList.ValueListItems.Add("S", "S/.")
        valueList.ValueListItems.Add("D", "US$")
        gridDetalle.DisplayLayout.Bands(0).Columns("moneda").Style = ColumnStyle.DropDownList
        gridDetalle.DisplayLayout.Bands(0).Columns("moneda").ValueList = valueList
        gridDetalle.DisplayLayout.Bands(0).Columns("moneda").ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
    End Sub

    Private Sub CargarDatos()
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.TipoOperacion = Ope
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.MyLista = Negocio.NEntregas.Listar_Liquidaciones(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.GridSolicitudes, Source1, Ls_Entrega)
    End Sub
    Private Sub HabilitarControles(ByVal D As Boolean)
        Me.TxtCodigoTrabajador.ReadOnly = Not D
        Me.TxtNombresTrabajador.ReadOnly = D
        Me.txtArea.ReadOnly = D
        Me.txtMotivo.ReadOnly = D
        Me.txtCantera.ReadOnly = D
        Me.txtRegion.ReadOnly = D
        Me.dtFechaSalida.ReadOnly = D
        Me.dtFechaRetorno.ReadOnly = D
        Me.TxtCodigoTrabajador.Focus()
    End Sub
#End Region

    Private Sub FrmLiquidacionEntregas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Actualizar()
    End Sub
    Private Sub FrmInsumosControlados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Inicio()        
    End Sub
    Private Sub GridSolicitudes_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridSolicitudes.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot GridSolicitudes Then Return
        If e.Row.IsFilterRow Then Return
        LimpiarDatos()
        SubProceso_Entregas(e.Row)
    End Sub
    Private Sub GridSolicitudes_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridSolicitudes.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "NumSolicitud" OrElse uColumn.Key = "Motivo" OrElse uColumn.Key = "FechaIngreso" OrElse _
                    uColumn.Key = "Estado" OrElse uColumn.Key = "NomTrabajador" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "moneda" OrElse uColumn.Key = "ID") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Sub SubProceso_Entregas(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If
        Ls_EntregaEliminado = New List(Of ETEntregas)
        Gpb1.Enabled = False
        chkActivarDev.Enabled = False
        chkActivarDev.Checked = False
        Dim usuarioSolicitud As String = String.Empty
        estado = uRow.Cells("estado").Value.ToString.Trim
        moneda = uRow.Cells("moneda").Value.ToString.Trim
        idPendiente = uRow.Cells("ID").Value.ToString.Trim
        usuarioSolicitud = uRow.Cells("usuario").Value
        Ope = 2
        If estado = "CERRADO" Then flgaprobada = 1 Else flgaprobada = 0
        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Entidad.Entregas.Usuario = User_Sistema
        'Entidad.Entregas.codArea = uRow.Cells("codArea").Value
        'Entidad.MyLista = Negocio.NEntregas.UsuarioAprobacion(Entidad.Entregas)
        'If Entidad.MyLista.Validacion Then
        '    Ls_Entrega = Entidad.MyLista.Ls_Entrega
        'End If
        'If Ls_Entrega.Count <= 0 Then
        '    chkCerrar.Visible = False
        '    esAprobador = 0
        '    puedeeliminar = 1
        'ElseIf Ls_Entrega.Count > 0 Then
        chkCerrar.Visible = True
        esAprobador = 1
        puedeeliminar = 0
        'End If
        If usuarioSolicitud <> User_Sistema Then esCreador = 0 Else esCreador = 1
        Call HabilitarControles(True)
        TxtCodigoTrabajador.ReadOnly = True
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.MyLista = New ETMyLista
        If Not uRow.Cells("NumSolicitud").Value.ToString.Substring(0, 4) = "PEND" Then
            Entidad.Entregas.NumSolicitud = uRow.Cells("NumSolicitud").Value
            NumSolicitud = uRow.Cells("NumSolicitud").Value
            nroSolicitud = uRow.Cells("NumSolicitud").Value
            esDevolucion = 0
        Else
            Dim cadena As String = uRow.Cells("Motivo").Value.ToString
            Entidad.Entregas.NumSolicitud = cadena.Substring(cadena.Length - 8, 8)
            NumSolicitud = cadena.Substring(cadena.Length - 8, 8)
            nroSolicitud = cadena.Substring(cadena.Length - 8, 8)
            esDevolucion = 1
            totalPend = uRow.Cells("montoTotal").Value
            numInterno = uRow.Cells("NumSolicitud").Value
        End If
        Entidad.MyLista = Negocio.NEntregas.SolicitudxNumeroLiquidacion(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        If Entidad.MyLista.Validacion Then Call Cargar_DatosSolicitud(esDevolucion)

        Entidad.Entregas.NumSolicitud = NumSolicitud
        Entidad.MyLista = Negocio.NEntregas.LimiteGastos(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        If Entidad.MyLista.Validacion Then Call CargarUltraGridxBinding(Me.gridViaticos, Source2, Ls_Entrega)

        lblmoneda.Text = moneda
        lblmoneda.Visible = True
        If moneda = "NUEVOS SOLES" Then
            UltraLabel3.Text = "IMPORTE TOTAL LIQUIDADO  S/."
            UltraLabel4.Text = "IMPORTE SOLICITUD  S/."
            UltraLabel9.Text = "DEVOLUCIÓN  S/."
            UltraLabel10.Text = "REINTEGRO  S/."
            tipmon = "S/."
        Else
            UltraLabel3.Text = "IMPORTE TOTAL LIQUIDADO  US$"
            UltraLabel4.Text = "IMPORTE SOLICITUD  US$"
            UltraLabel9.Text = "DEVOLUCIÓN  US$"
            UltraLabel10.Text = "REINTEGRO  US$"
            tipmon = "US$"
        End If
        esCreador = uRow.Cells("flgpermiso").Value
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub
    Sub Cargar_DatosSolicitud(ByVal esDevolucion As Int32)
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        If Ls_Entrega.Count > 0 Then
            TxtCodigoTrabajador.Text = Ls_Entrega.Item(0).CodTrabajador.ToString
            If codTrabajadorInicio.Trim = Ls_Entrega.Item(0).CodTrabajador.ToString.Trim Then esCreador = 1
            TxtNombresTrabajador.Text = Ls_Entrega.Item(0).NomTrabajador.ToString
            txtArea.Value = Ls_Entrega.Item(0).Area.ToString
            txtcodarea.Value = Ls_Entrega.Item(0).codArea.ToString
            txtMotivo.Value = Ls_Entrega.Item(0).Motivo.ToString
            dtFechaSalida.Value = Ls_Entrega.Item(0).fechaSalida
            dtFechaRetorno.Value = Ls_Entrega.Item(0).fechaRetorno
            txtcodCantera.Value = Ls_Entrega.Item(0).codCantera.ToString
            txtCantera.Value = Ls_Entrega.Item(0).Cantera.ToString
            txtRegion.Value = Ls_Entrega.Item(0).Region.ToString
            Entidad.Entregas.NumSolicitud = NumSolicitud
            txtnsolicitud.Text = NumSolicitud
            Dim idEstado As Int32
            idEstado = Ls_Entrega.Item(0).idEstado
            If idEstado = 3 Then
                chkCerrar.Checked = Boolean.FalseString
            ElseIf idEstado = 4 Then
                chkCerrar.Checked = Boolean.TrueString
            End If
            If esDevolucion = 0 Then
                txttotalsolicitud.Value = Ls_Entrega.Item(0).montoTotal.ToString("#####0.00")
                lblnSolicitud.Text = "N° Solicitud : " & NumSolicitud
                Entidad.Entregas.NumSolicitud = numInterno
                UltraLabel4.Text = "IMPORTE SOLICITUD  S/."
                'txtreintegro.Visible = True
                'txtdevolucion.Visible = True
                'UltraLabel9.Visible = True
                'UltraLabel10.Visible = True
            Else
                If estado = "PEND - DEVOLUCION" Then
                    chkCerrar.Checked = Boolean.FalseString
                Else
                    chkCerrar.Checked = Boolean.TrueString
                End If
                txttotalsolicitud.Value = totalPend.ToString("#####0.00")
                lblnSolicitud.Text = "Documento Virtual : " & numInterno
                UltraLabel4.Text = "IMPORTE DOC. VIRTUAL  S/."
                'txtreintegro.Visible = False
                'txtdevolucion.Visible = False
                'UltraLabel9.Visible = False
                'UltraLabel10.Visible = False
            End If
            lblnSolicitud.Visible = Boolean.TrueString
            Try
                Dim codigoConcepto As String = ""
            Catch ex As Exception
            End Try
            cargarValoresDetalle(nroSolicitud, esDevolucion)
        End If
    End Sub
    Private Sub LimpiarDatos()
        Me.TxtCodigoTrabajador.Clear()
        Me.TxtNombresTrabajador.Clear()
        Me.txtMotivo.Clear()
        Me.txtCantera.Clear()
        Me.txtRegion.Clear()
        Me.txtArea.Clear()
        Me.txtcodCantera.Clear()
        Me.lblnSolicitud.Visible = False
        nroSolicitud = ""
        dtFechaSalida.Value = Now.Date
        dtFechaRetorno.Value = Now.Date
        Gpb1.Enabled = False
        chkActivarDev.Checked = False
        chkActivarDev.Enabled = False
        btnAgregar.Enabled = False
        chkrepetir.Checked = False
        cancelado = 0
        txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
        txttotalsolicitud.Text = CDbl("0.00").ToString("#####0.00")
        txtdevolucion.Text = CDbl("0.00").ToString("#####0.00")
        txtreintegro.Text = CDbl("0.00").ToString("#####0.00")
        Ls_DetalleComp = New List(Of ETEntregas)
        Call CargarUltraGrid(gridDetalle, Ls_DetalleComp)
        Ls_Entrega = New List(Of ETEntregas)
        Ls_EntregaEliminado = New List(Of ETEntregas)
        Ls_DocAsociado = New List(Of ETEntregas)
        Ls_DocAsociadoEliminado = New List(Of ETEntregas)
        Ls_DocMovilidad = New List(Of ETEntregas)
        Ls_DocMovilidadEliminado = New List(Of ETEntregas)
        Ls_DocCombustible = New List(Of ETEntregas)
        Ls_DocCombustibleEliminado = New List(Of ETEntregas)
        Ls_DetalleRecibo = New List(Of ETEntregas)
        Ls_DetalleReciboEliminado = New List(Of ETEntregas)
    End Sub
    Public Sub Nuevo()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If nroSolicitud.Trim = "" Then MsgBox("Debe seleccionar una solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If esCreador = 0 Then MsgBox("No puede modificar la liquidación", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If flgaprobada = 1 Then MsgBox("La liquidación se encuentra cerrada", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If gridDetalle.Rows.Count > 0 Then
            MsgBox("Ya hay comprobantes registrados", MsgBoxStyle.Exclamation, msgComacsa) : Return
        Else
            Gpb1.Enabled = True
            btnAgregar.Enabled = True
            chkActivarDev.Enabled = True
            Btn3_Click(Nothing, Nothing)

            '@ID  @USUARIO   @FECHA    @MOTIVO
            '---------------------------------
            '@01  JSIESQUEN  05012023  Permisos para editar registros en liquidación


            '@01 Add ini
            Dim dtFlgPermiso As Boolean
            With Entidad.Usuario
                .Login = User_Sistema
            End With
            dtFlgPermiso = Negocio.Usuario.PermisoEdicionLiquidacion(Entidad.Usuario)
            '@01 Add fin

            If dtFlgPermiso = True Then

                Me.dtFechaSalida.ReadOnly = False
                'Me.txtcodCantera.ReadOnly = False

            End If
            Me.txtMotivo.ReadOnly = False
            Me.dtFechaRetorno.ReadOnly = False
        End If
    End Sub
    Sub modificar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If nroSolicitud.Trim = "" Then MsgBox("Debe seleccionar una solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If esCreador = 0 Then MsgBox("No puede modificar la liquidación", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If flgaprobada = 1 Then MsgBox("La liquidación se encuentra cerrada", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If gridDetalle.Rows.Count = 0 Then
            MsgBox("No hay comprobantes registrados", MsgBoxStyle.Exclamation, msgComacsa) : Return
        Else
            Gpb1.Enabled = True
            btnAgregar.Enabled = True
            If cancelado = 0 Then chkActivarDev.Enabled = True
            Dim dtFlgPermiso As Boolean
            With Entidad.Usuario
                .Login = User_Sistema
            End With
            dtFlgPermiso = Negocio.Usuario.PermisoEdicionLiquidacion(Entidad.Usuario)
            '@01 Add fin

            If dtFlgPermiso = True Then

                Me.dtFechaSalida.ReadOnly = False
                'Me.txtcodCantera.ReadOnly = False
            End If
            Me.txtMotivo.ReadOnly = False
            Me.dtFechaRetorno.ReadOnly = False
            Me.dtFechaRetorno.ReadOnly = False
            Me.txtMotivo.ReadOnly = False
        End If
    End Sub

    Private Sub gridDetalle_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridDetalle.DoubleClickRow
        Try
            If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString = "43" Then Return
            If gridDetalle.ActiveRow.Cells("montoTotalParcial").Value.ToString <= 0 Then
                MsgBox("Ingrese importe", MsgBoxStyle.Exclamation, msgComacsa) : Return
            End If
            If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "00" Then
                NecesitaAuxiliar(gridDetalle.ActiveRow.Index)
                If Ls_DocAsociado Is Nothing Then
                    Ls_DocAsociado = New List(Of ETEntregas)
                End If
                If Ls_DocAsociadoEliminado Is Nothing Then
                    Ls_DocAsociadoEliminado = New List(Of ETEntregas)
                End If
                Dim numDoc As String = String.Empty
                numDoc = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.PadLeft(16, "0") '("0000000000000000")
                Dim frm As FrmFacturasAsociadas
                frm = New FrmFacturasAsociadas
                frm.txtruc.Text = gridDetalle.ActiveRow.Cells("nroruc").Value.ToString
                frm.txtrazon.Text = gridDetalle.ActiveRow.Cells("Razon").Value.ToString
                frm.txttd.Text = gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString
                frm.txtserie.Text = gridDetalle.ActiveRow.Cells("Serie").Value.ToString
                frm.txtnumero.Text = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString
                frm.codArea = gridDetalle.ActiveRow.Cells("codArea").Value.ToString
                frm.flgcompra = gridDetalle.ActiveRow.Cells("flgcompra").Value.ToString
                frm.cadena = gridDetalle.ActiveRow.Cells("Auxiliar").Value.ToString
                Dim monDocumento As String = String.Empty
                monDocumento = gridDetalle.ActiveRow.Cells("moneda").Value.ToString.Trim
                frm.txtimporte.Text = CDbl(gridDetalle.ActiveRow.Cells("montoTotal").Value).ToString("#####0.00")
                frm.txtcambio.Text = CDbl(gridDetalle.ActiveRow.Cells("tipocambio").Value).ToString("#####0.00")
                If monDocumento = "S/." Or monDocumento = "NUEVOS SOLES" Then
                    frm.txtmoneda.Text = "NUEVOS SOLES"
                Else
                    frm.txtmoneda.Text = "DÓLARES"
                End If
                frm.mon = monDocumento
                frm.moneda = moneda
                frm.auxi = auxi
                frm.flgauxi = flgauxi
                frm.ShowDialog()
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Auxiliar").Value = Auxiliar
            End If
            If gridDetalle.ActiveRow.Cells("Descripcion").Value.ToString.Trim = "MOVILIDAD" Then
                DocumentosMovilidad()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDetalle.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "fechaComp" OrElse uColumn.Key = "TipoDoc" OrElse uColumn.Key = "NumDoc" OrElse uColumn.Key = "Auxiliar" OrElse uColumn.Key = "moneda" OrElse uColumn.Key = "tipocambio" OrElse uColumn.Key = "ANEXO3" OrElse _
                    uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Razon" OrElse uColumn.Key = "nroruc" OrElse uColumn.Key = "Serie" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "Area" OrElse uColumn.Key = "Cantera" OrElse uColumn.Key = "PLACA_TERCERO") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
        If Not gridDetalle.ActiveRow Is Nothing Then
            If Not ValidarDocumentoRepetido(gridDetalle.ActiveRow.Index) Then Return
        End If

        If Not ValidarCamposDetalle() Then Return
        CalcularTotalComprobantes()
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.fechaComp = Now.Date
        Entidad.Entregas.TipoDoc = String.Empty
        Entidad.Entregas.NumDoc = String.Empty
        Entidad.Entregas.nroruc = String.Empty
        Entidad.Entregas.Razon = String.Empty
        Entidad.Entregas.Descripcion = String.Empty
        Entidad.Entregas.codConcepto = String.Empty
        Entidad.Entregas.Serie = String.Empty
        Entidad.Entregas.Area = String.Empty
        Entidad.Entregas.codArea = String.Empty
        Entidad.Entregas.tipocambio = 1.0
        Entidad.Entregas.flgretencion = 0
        Entidad.Entregas.IDANEXO3 = 0
        Entidad.Entregas.ANEXO3 = ""
        Entidad.Entregas.PLACA_TERCERO = ""
        If gridDetalle.Rows.Count > 0 Then
            Entidad.Entregas.codmotivoDetalle = gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("codMotivodetalle").Value.ToString.Trim
            Entidad.Entregas.motivoDetalle = gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("motivoDetalle").Value.ToString.Trim
        Else
            Entidad.Entregas.motivoDetalle = String.Empty
        End If
        Dim array As String() = txtcodCantera.Text.Split(",")
        If array.Count = 1 Then
            Entidad.Entregas.Cantera = txtcodCantera.Text
        ElseIf chkrepetir.Checked = True Then
            Entidad.Entregas.Cantera = txtcodCantera.Text
        Else
            Entidad.Entregas.Cantera = String.Empty
        End If
        Entidad.Entregas.TipoOperacion = 1
        Entidad.Entregas.dias = 0
        Entidad.Entregas.personas = 0
        Entidad.Entregas.idComp = 0
        Ls_DetalleComp.Add(Entidad.Entregas)
        Call CargarUltraGrid(gridDetalle, Ls_DetalleComp)
        gridDetalle.Focus()
        gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells(0).Activate()
        gridDetalle.PerformAction(FirstCellInRow)
        gridDetalle.PerformAction(NextCellByTab)
        If gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("motivoDetalle").Value.ToString.Trim = "" Then
            gridDetalle.PerformAction(PrevCellByTab)
        End If
        comboMoneda()
        If lblmoneda.Text.ToString.Trim = "NUEVOS SOLES" Then
            gridDetalle.ActiveRow.Cells("moneda").Value = "S/."
        Else
            gridDetalle.ActiveRow.Cells("moneda").Value = "US$"
        End If
        If gridDetalle.Rows.Count = 1 Then
            Entidad.Entregas.nfila = 0
        Else
            Dim n_fila As Int32 = 0
            Dim n_fila_max As Int32 = 0
            For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                n_fila = gridDetalle.Rows(i).Cells("nfila").Value
                If n_fila > n_fila_max Then
                    n_fila_max = n_fila
                End If
            Next
            Entidad.Entregas.nfila = n_fila_max + 1
        End If

        btnAgregar.Enabled = False
        gridDetalle.ActiveRow.ToolTipText = "COMENTARIO : " & gridDetalle.ActiveRow.Cells("comentario").Value
    End Sub

    Function ValidarDocumentoRepetido(ByVal fila As Integer) As Boolean
        Try
            If gridDetalle.Rows.Count > 0 Then
                Me.gridDetalle.PerformAction(ExitEditMode)
                If Me.gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString.Trim = "VL" Then Return True
                Dim tipdoc As String = Me.gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString.Trim
                Dim serdoc As String = Me.gridDetalle.Rows(fila).Cells("Serie").Value.ToString.PadLeft(4, "0")
                Dim numdoc As String = Me.gridDetalle.Rows(fila).Cells("NumDoc").Value.ToString.PadLeft(16, "0")
                Dim nroruc As String = Me.gridDetalle.Rows(fila).Cells("nroruc").Value.ToString.Trim
                Dim cadenavalidar = tipdoc + serdoc + numdoc + nroruc
                Dim cadenacomparar As String = String.Empty
                For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                    cadenacomparar = Me.gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim + Me.gridDetalle.Rows(i).Cells("Serie").Value.ToString.PadLeft(4, "0") + Me.gridDetalle.Rows(i).Cells("NumDoc").Value.ToString.PadLeft(16, "0") + Me.gridDetalle.Rows(i).Cells("nroruc").Value.ToString.Trim
                    If Not i = fila Then
                        If cadenavalidar = cadenacomparar Then
                            MsgBox("El documento en la fila " & (i + 1) & " ya fue registrado", MsgBoxStyle.Exclamation, msgComacsa)
                            Me.gridDetalle.PerformAction(EnterEditMode)
                            Return False
                        End If
                    End If
                Next
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function

    Function ValidarDocumentoRepetidoBD(ByVal fila As Integer) As Boolean
        Try
            'If gridDetalle.Rows.Count > 0 Then
            Me.gridDetalle.PerformAction(ExitEditMode)
            If Me.gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString.Trim = "VL" Then Return True
            Dim tipdoc As String = Me.gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString.Trim
            Dim serdoc As String = Me.gridDetalle.Rows(fila).Cells("Serie").Value.ToString.PadLeft(4, "0")
            Dim numdoc As String = Me.gridDetalle.Rows(fila).Cells("NumDoc").Value.ToString.PadLeft(16, "0")
            Dim nroruc As String = Me.gridDetalle.Rows(fila).Cells("nroruc").Value.ToString.Trim
            Dim nro_solicitud = txtnsolicitud.Text 'nroSolicitud
            Dim nrodoc As String = String.Empty
            nrodoc = serdoc + numdoc
            Dim dtExistente As New DataTable
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.NumSolicitud = txtnsolicitud.Text 'nroSolicitud
            Entidad.Entregas.TipoDoc = tipdoc
            Entidad.Entregas.NumDoc = nrodoc
            Entidad.Entregas.nroruc = nroruc
            Entidad.Entregas.tipotabla = 1
            dtExistente = Negocio.NEntregas.ValidaDocRepetido(Entidad.Entregas)
            'End If
            If dtExistente.Rows.Count = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception

        End Try
    End Function

    Function ValidarCamposDetalle() As Boolean
        Me.gridDetalle.PerformAction(ExitEditMode)
        Me.gridDetalle.PerformAction(EnterEditMode)
        Me.gridDetalle.PerformAction(ExitEditMode)
        For i As Int32 = 0 To gridDetalle.Rows.Count - 1

            Dim fecha1 As Date = gridDetalle.Rows(i).Cells("fechaComp").Value
            Dim fecha2 As Date = dtFechaSalida.Value
            Dim fecha3 As Date = dtFechaRetorno.Value
            fecha1 = fecha1.ToString("dd/MM/yyyy")
            fecha2 = fecha2.ToString("dd/MM/yyyy")
            fecha3 = fecha3.ToString("dd/MM/yyyy")

            If fecha1.CompareTo(fecha2) < 0 And (gridDetalle.Rows(i).Cells("codConcepto").Value.ToString <> "43" And gridDetalle.Rows(i).Cells("codConcepto").Value.ToString <> "59") Then
                MsgBox("No puede ingresar comprobantes fuera de fecha en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
            End If

            If fecha3.CompareTo(fecha1) < 0 And (gridDetalle.Rows(i).Cells("codConcepto").Value.ToString <> "43" And gridDetalle.Rows(i).Cells("codConcepto").Value.ToString <> "59") Then
                MsgBox("No puede ingresar comprobantes fuera de fecha en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
            End If
            gridDetalle.Rows(i).Cells("Serie").Value = gridDetalle.Rows(i).Cells("Serie").Value.ToString.PadLeft(4, "0")
            If gridDetalle.Rows(i).Cells("codArea").Value.ToString = "" Then MsgBox("Ingrese centro costo en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
            If gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString <= 0 Then MsgBox("Ingrese importe en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
            If Not gridDetalle.Rows(i).Cells("Descripcion").Value.ToString.Trim = "REINTEGRO" Then
                If Not (gridDetalle.Rows(i).Cells("codConcepto").Value.ToString = "43") And Not (gridDetalle.Rows(i).Cells("codConcepto").Value.ToString = "59") Then
                    Dim TipoDocumento = gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString
                    If gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "" Then MsgBox("Ingrese tipo documento en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    If Not gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "VL" And Not gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "DBN" And Not gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "BP" And Not gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "TF" And Not gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "CPND" And Not gridDetalle.Rows(i).Cells("codTipoDoc").Value.ToString.Trim = "70" And Not gridDetalle.Rows(i).Cells("codTipoDoc").Value.ToString.Trim = "89" Then
                        If gridDetalle.Rows(i).Cells("Serie").Value.ToString.PadLeft(4, "0") = "0000" Or gridDetalle.Rows(i).Cells("Serie").Value.ToString.PadLeft(4, "0") = "E000" Then
                            MsgBox("Ingrese serie válida en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        End If
                        If Not valida_Serie(gridDetalle.Rows(i).Cells("Serie").Value.ToString.PadLeft(4, "0"), gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim) Then
                            MsgBox("Ingrese serie válida en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        End If
                        If gridDetalle.Rows(i).Cells("Serie").Value.ToString.Trim = "" Then MsgBox("Ingrese serie documento en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        If gridDetalle.Rows(i).Cells("NumDoc").Value.ToString.Trim = "" Then MsgBox("Ingrese nro. documento en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        If gridDetalle.Rows(i).Cells("nroruc").Value.ToString.Trim = "" Then MsgBox("Ingrese nro. ruc en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        If gridDetalle.Rows(i).Cells("razon").Value.ToString.Trim = "" Then MsgBox("Ingrese razón del proveedor en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    End If

                    If Me.gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "VL" And (gridDetalle.Rows(i).Cells("NumDoc").Value.ToString.Trim = "" Or gridDetalle.Rows(i).Cells("NumDoc").Value.ToString.Trim = "0") Then
                        gridDetalle.Rows(i).Cells("NumDoc").Value = Convert.ToInt32(txtnsolicitud.Text.Substring(1, 7)).ToString & gridDetalle.Rows(i).Index + 1.ToString
                    End If

                    If gridDetalle.Rows(i).Cells("nroruc").Value.ToString.Trim.Trim <> "" And gridDetalle.Rows(i).Cells("nroruc").Value.ToString.Length < 11 Then MsgBox("Debe ingresar 11 dígitos para el ruc en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : gridDetalle.PerformAction(PrevCellByTab) : Return False
                    If gridDetalle.Rows(i).Cells("Descripcion").Value.ToString.Trim = "" Then MsgBox("Ingrese descripción en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    If gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString <= 0 Then MsgBox("Ingrese importe en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False

                    Dim dtAuxi3 As New DataTable
                    Entidad.Entregas = New ETEntregas
                    Entidad.Entregas.codArea = gridDetalle.Rows(i).Cells("codArea").Value.ToString.Trim
                    Entidad.Entregas.codConcepto = gridDetalle.Rows(i).Cells("codConcepto").Value.ToString.Trim
                    Entidad.Entregas.Anho = Year(gridDetalle.Rows(i).Cells("fechaComp").Value)
                    dtAuxi3 = Negocio.NEntregas.VerAuxi3(Entidad.Entregas)

                    gridDetalle.Rows(i).Cells("IDANEXO3").Value = dtAuxi3.Rows(0)(0)

                    If gridDetalle.Rows(i).Cells("IDANEXO3").Value <> 0 Then
                        If gridDetalle.Rows(i).Cells("ANEXO3").Value.ToString = "" Then MsgBox("Ingrese 3er auxiliar en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    End If

                    If gridDetalle.Rows(i).Cells("codConcepto").Value.ToString.Trim = "32" Then
                        If validarIngresoMovilidad(i) = False Then
                            MsgBox("Ingrese planilla de movilidad en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        End If
                    End If

                    'If gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "RH" Then
                    '    If validarIngresoRh(i) = False Then
                    '        MsgBox("Ingrese detalle de RH en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    '    End If
                    'End If

                    anho = Year(Convert.ToDateTime(gridDetalle.Rows(i).Cells("fechaComp").Value))
                    mes = Month(Convert.ToDateTime(gridDetalle.Rows(i).Cells("fechaComp").Value))
                    monto = gridDetalle.Rows(i).Cells("montoTotalParcial").Value
                    ruc_Prov = gridDetalle.Rows(i).Cells("nroruc").Value
                    numDoc = gridDetalle.Rows(i).Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.Rows(i).Cells("NumDoc").Value.ToString.PadLeft(16, "0")
                    fecha = gridDetalle.Rows(i).Cells("fechaComp").Value.ToString
                    If gridDetalle.Rows(i).Cells("codConcepto").Value.ToString = "10" Then ' ALIMENTACION
                        If monto > 60 Then
                            If gridDetalle.Rows(i).Cells("dias").Value.ToString = 0 Then MsgBox("Ingrese nro. de días en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                            If gridDetalle.Rows(i).Cells("personas").Value.ToString = 0 Then MsgBox("Ingrese nro. de personas en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        End If
                    End If

                    If gridDetalle.Rows(i).Cells("codConcepto").Value.ToString = "25" Then ' HOSPEDAJE
                        If monto > 70 Then
                            If gridDetalle.Rows(i).Cells("dias").Value.ToString = 0 Then MsgBox("Ingrese nro. de días en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                            If gridDetalle.Rows(i).Cells("personas").Value.ToString = 0 Then MsgBox("Ingrese nro. de personas en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        End If
                    End If

                    If gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "RH" Then
                        If Not validarReciboHonorario(i, anho, mes, ruc_Prov, numDoc, monto, fecha) Then Return False
                    End If
                    Dim tipomoneda As String
                    Dim tipomonedaSol As String
                    tipomoneda = gridDetalle.Rows(i).Cells("moneda").Value.ToString.Trim
                    tipomonedaSol = lblmoneda.Text.ToString.Trim
                    If tipomoneda = "S/." Then tipomoneda = "S"
                    If tipomoneda = "US$" Then tipomoneda = "D"
                    If tipomonedaSol = "NUEVOS SOLES" Then tipomonedaSol = "S" Else tipomonedaSol = "D"
                    If tipomoneda <> tipomonedaSol Then
                        If gridDetalle.Rows(i).Cells("TipoCambio").Value <= 1 Then
                            MsgBox("Ingrese tipo de cambio en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        End If
                    End If
                    'MsgBox(lblmoneda.Text)
                    'MsgBox(gridDetalle.Rows(i).Cells("moneda").Value.ToString.Trim())
                    NecesitaAuxiliar(i)
                    If gridDetalle.Rows(i).Cells("flgauxi").Value = 1 Then
                        If gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString = "" Then MsgBox("Ingrese auxiliar en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    End If

                    If gridDetalle.Rows(i).Cells("flgauxi").Value = 1 Then
                        If gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString = "00000000" And (gridDetalle.Rows(i).Cells("PLACA_TERCERO").Value.ToString = "" Or gridDetalle.Rows(i).Cells("PLACA_TERCERO").Value.ToString.Length < 6) Then MsgBox("Ingrese placa correcta en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    End If

                    Dim CODCONCEPTO As String = ""
                    If flgauxi = 1 Then
                        If gridDetalle.Rows(i).Cells("codArea").Value.ToString.Trim = "912" And auxi.Trim = "AC" Then
                            CODCONCEPTO = "MP"
                        Else
                            CODCONCEPTO = gridDetalle.Rows(i).Cells("codConcepto").Value.ToString.Trim
                        End If
                    End If
                    If Not cantera_maquina(i, CODCONCEPTO) Then Return False
                    If gridDetalle.Rows(i).Cells("Cantera").Value.ToString = "" Then MsgBox("Ingrese cantera en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False

                    If ValidarDocumentoRepetido(i) = False Then
                        Return False
                        'MsgBox("El documento en la fila " & (i + 1).ToString & " ya ha sido registrado", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    End If
                    If ValidarDocumentoRepetidoBD(i) = False Then
                        MsgBox("El documento en la fila " & (i + 1).ToString & " ya ha sido registrado en otra liquidación", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    End If
                    If verificaDocumentos(gridDetalle.Rows(i).Cells("nroruc").Value.ToString, gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString, numDoc) Then
                        MsgBox("El documento en la fila " & (i + 1).ToString & " se encuentra en el registro de compras", MsgBoxStyle.Exclamation, msgComacsa)
                        Return False
                    End If
                    If gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "RH" And txtArea.Text.ToString.Trim = "DPTO. LEGAL" Then
                        If validarIngresoDetalleRH(i) = False Then
                            MsgBox("Ingrese detalle de Recibo en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        End If
                    End If
                End If
            Else
                If gridDetalle.Rows(i).Cells("NumDoc").Value.ToString = "" Then MsgBox("Debe elegir un reintegro en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
            End If
        Next
        Return True
    End Function
    Function valida_Serie(ByVal serie As String, ByVal td As String) As Boolean
        Dim n1 As String = serie.Substring(0, 1)
        Dim n As String = ""
        If IsNumeric(n1) Then
            For i As Int32 = 0 To 3
                n = serie.Substring(i, 1)
                If Not IsNumeric(n) Then
                    Return False
                End If
            Next
        Else
            Dim dtVerifica As New DataTable
            Entidad.Entregas = New ETEntregas
            Negocio.NEntregas = New NGEntregas
            Entidad.Entregas.TipoDoc = td
            dtVerifica = Negocio.NEntregas.verifica_documento_compra(Entidad.Entregas)
            If dtVerifica.Rows.Count > 0 Then
                If n1 <> "F" And n1 <> "B" And n1 <> "T" And n1 <> "E" Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Function verificaDocumentos(ByVal ruc As String, ByVal tipodoc As String, ByVal numdoc As String) As Boolean
        Try
            Negocio.NEntregas = New NGEntregas
            Entidad.MyLista = New ETMyLista
            'Ls_Entrega = Nothing
            'Ls_Entrega = New List(Of ETEntregas)
            Dim Rpt As New ETEntregas
            Rpt.nroruc = ruc
            Rpt.TipoDoc = tipodoc
            Rpt.NumDoc = numdoc
            Entidad.MyLista = Negocio.NEntregas.verificarDocumentos(Rpt)
            lResult = New ETMyLista
            lResult = Entidad.MyLista
            If Entidad.MyLista.Validacion Then
                If Not Entidad.MyLista.Ls_Entrega.Count > 0 Then
                    Return False
                End If
            End If
            Return True

        Catch ex As Exception
        End Try
    End Function
    Sub CalcularTotalComprobantes()
        txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
        Dim tcambio As Double = 0
        Dim importe As Double = 0
        Dim total As Double = 0
        Dim mon As String = String.Empty
        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            tcambio = gridDetalle.Rows(i).Cells("tipocambio").Value
            importe = gridDetalle.Rows(i).Cells("montoTotalParcial").Value
            mon = gridDetalle.Rows(i).Cells("moneda").Value.ToString.Trim
            If moneda = "NUEVOS SOLES" Then
                If mon = "S" Or mon = "S/." Then
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe
                Else
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe * tcambio
                End If
            Else
                If mon = "S" Or mon = "S/." Then
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe / tcambio
                Else
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe * 1
                End If
            End If
            txttotalliquidacion.Text = CDbl(CDbl(txttotalliquidacion.Text) + CDbl(gridDetalle.Rows(i).Cells("montoTotal").Value.ToString)).ToString("#####0.00")
        Next
        Dim totalliquida As Double = CDbl(txttotalliquidacion.Text)
        Dim totalsolicitud As Double = CDbl(txttotalsolicitud.Text)
        Dim resul As Double = totalliquida - totalsolicitud
        Dim devolucion As Double
        Dim reintegro As Double
        If resul < 0 Then
            devolucion = resul * -1
            reintegro = 0.0
        Else
            reintegro = resul
            devolucion = 0.0
        End If
        txtdevolucion.Text = devolucion.ToString("#####0.00")
        txtreintegro.Text = reintegro.ToString("#####0.00")
    End Sub
    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        If Not VerificarControl(5, gridDetalle) Then
            MessageBox.Show("No tiene comprobante para quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If gridDetalle.ActiveRow Is Nothing Then
            MessageBox.Show("No tiene un comprobante seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Not validarImportesAsociados() Then Return
        If Not validarDetalleRecibo(Me.gridDetalle.ActiveRow.Index) Then Return
        If gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codConcepto").Value.ToString = "43" Then
            MessageBox.Show("No puede eliminar una devolución en efectivo", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codConcepto").Value.ToString = "59" Then
            MessageBox.Show("No puede eliminar una aplicacion de reintegro", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim id As Int32 = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("idComp").Value
        If id <> 0 Then
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.TipoOperacion = 1
            Entidad.Entregas.NumSolicitud = txtnsolicitud.Text 'nroSolicitud
            Entidad.Entregas.idComp = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("idComp").Value.ToString
            Entidad.Entregas.TipoOperacion = 3
            Entidad.Entregas.fechaComp = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("fechaComp").Value.ToString
            Entidad.Entregas.TipoDoc = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("TipoDoc").Value.ToString
            Entidad.Entregas.NumDoc = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("NumDoc").Value.ToString
            Entidad.Entregas.nroruc = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("nroruc").Value.ToString
            Entidad.Entregas.Razon = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Razon").Value.ToString
            Entidad.Entregas.Descripcion = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Descripcion").Value.ToString
            Entidad.Entregas.codConcepto = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codConcepto").Value.ToString
            Entidad.Entregas.montoTotalParcial = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("montoTotalParcial").Value.ToString
            Entidad.Entregas.codAuxiliar = "" '
            Ls_EntregaEliminado.Add(Entidad.Entregas)
        End If
        gridDetalle.ActiveRow.Delete()
        If Me.gridDetalle.Rows.Count.ToString = 0 Then txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
        btnAgregar.Enabled = True
        CalcularTotalComprobantes()
        If Me.gridDetalle.Rows.Count > 0 Then
            gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells(0).Activate()
            gridDetalle.PerformAction(LastCellInRow)
            gridDetalle.PerformAction(PrevCellByTab)
        End If
    End Sub
    Private Sub gridDetalle_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridDetalle.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridDetalle Then Return
        e.DisplayPromptMsg = Boolean.FalseString
    End Sub
    Private Sub gridDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDetalle.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridDetalle) Then Return
            With sender
                Select Case e.KeyValue
                    Case 45
                        Btn3_Click(Nothing, Nothing)
                        e.Handled = True
                        Return
                    Case 46
                        If Not validarImportesAsociados() Then e.Handled = True : Return
                    Case 8
                        If Not validarImportesAsociados() Then e.Handled = True : Return
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
                        NecesitaAuxiliar(gridDetalle.ActiveRow.Index)
                        .PerformAction(ExitEditMode)
                        If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "nroruc" Then
                            If Not ValidarDocumentoRepetido(gridDetalle.ActiveRow.Index) Then gridDetalle.ActiveRow.Cells("nroruc").Value = "" : gridDetalle.ActiveRow.Cells("razon").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                            If gridDetalle.ActiveRow.Cells("TipoDoc").Value = "BL" Then
                                If gridDetalle.ActiveRow.Cells("nroruc").Value.ToString.Substring(0, 2) = "20" Then
                                    MsgBox("El proveedor solo puede emitir facturas", MsgBoxStyle.Exclamation, msgComacsa)
                                End If
                            End If
                            ObtenerRazon()
                        End If
                        If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Serie" Then
                            If Not ValidarDocumentoRepetido(gridDetalle.ActiveRow.Index) Then gridDetalle.ActiveRow.Cells("Serie").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                            gridDetalle.ActiveRow.Cells("Serie").Value = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.Trim.PadLeft(4, "0")
                        End If
                        If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "NumDoc" Then
                            If Not ValidarDocumentoRepetido(gridDetalle.ActiveRow.Index) Then gridDetalle.ActiveRow.Cells("NumDoc").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                            If Me.gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim = "VL" And (gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim = "" Or gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim = "0") Then
                                gridDetalle.ActiveRow.Cells("NumDoc").Value = Convert.ToInt32(txtnsolicitud.Text.Substring(1, 7)).ToString & gridDetalle.ActiveRow.Index + 1.ToString
                            End If
                            If Me.gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim = "DBN" And gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim = "" Then
                                gridDetalle.ActiveRow.Cells("NumDoc").Value = Convert.ToInt32(txtnsolicitud.Text.Substring(1, 7)).ToString & gridDetalle.ActiveRow.Index + 1.ToString
                            End If
                            gridDetalle.ActiveRow.Cells("NumDoc").Value = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim.PadLeft(16, "0")
                        End If
                        If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "montoTotalParcial" Then
                            If gridDetalle.ActiveRow.Cells("montoTotalParcial").Value <= 0 Then
                                MsgBox("Ingrese importe válido")
                                .PerformAction(PrevCellByTab)
                            Else
                                anho = Year(Convert.ToDateTime(gridDetalle.ActiveRow.Cells("fechaComp").Value))
                                mes = Month(Convert.ToDateTime(gridDetalle.ActiveRow.Cells("fechaComp").Value))
                                monto = gridDetalle.ActiveRow.Cells("montoTotalParcial").Value
                                ruc_Prov = gridDetalle.ActiveRow.Cells("nroruc").Value
                                numDoc = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.PadLeft(16, "0")
                                fecha = gridDetalle.ActiveRow.Cells("fechaComp").Value.ToString
                                If Not validarReciboHonorario(gridDetalle.ActiveRow.Index, anho, mes, ruc_Prov, numDoc, monto, fecha) Then
                                    gridDetalle.ActiveRow.Cells("montoTotalParcial").Value = 0
                                    Return
                                End If


                                If gridDetalle.ActiveRow.Cells("Descripcion").Value.ToString.Trim = "MOVILIDAD" Then
                                    DocumentosMovilidad()
                                End If
                                If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "00" Then
                                    DocumentosAsociados()
                                Else
                                    If flgauxi = 1 Then
                                        Dim frm As New FrmAuxiliar
                                        frm.auxi = auxi
                                        If gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim = "912" And auxi.Trim = "AC" Then
                                            frm.codconcepto = "MP"
                                        Else
                                            frm.codconcepto = gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim
                                        End If
                                        'SOLO PARA ALQUILER DE VEHICULOS
                                        If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "48" Then
                                            frm.codconcepto = gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim
                                            frm.auxi = "AL"
                                        End If
                                        frm.cadena = gridDetalle.ActiveRow.Cells("Auxiliar").Value.ToString
                                        frm.ShowDialog()
                                        If codAuxiliar.Trim = "" Then gridDetalle.PerformAction(PrevCellByTab) : Return
                                        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
                                        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Auxiliar").Value = Auxiliar
                                        codAuxiliar = ""
                                        Auxiliar = ""
                                        cantera_maquina(gridDetalle.ActiveRow.Index, frm.codconcepto)
                                        gridDetalle.PerformAction(NextCellByTab)
                                        e.Handled = True
                                        If gridDetalle.ActiveRow.Cells("Descripcion").Value.ToString.Trim = "COMBUSTIBLE" Then
                                            DocumentosCombustible()
                                        End If
                                        gridDetalle.ActiveRow.Cells("placa_tercero").Value = frm.placa_tercero.ToString
                                        Exit Sub
                                    Else
                                        Dim codconcepto As String = ""
                                        If gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim = "912" Then
                                            codconcepto = "MP"
                                        Else
                                            codconcepto = gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim
                                        End If
                                        cantera_maquina(gridDetalle.ActiveRow.Index, codconcepto)
                                    End If
                                End If
                                If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "10" Then ' ALIMENTACION
                                    If monto > 60 Then
                                        llenardias()
                                        llenarComentario()
                                        'ToolStripButton6_Click(Nothing, Nothing)
                                        'llenardias()
                                    End If
                                End If
                                If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "25" Then ' HOSPEDAJE
                                    If monto > 70 Then
                                        llenardias()
                                        llenarComentario()
                                        'ToolStripButton6_Click(Nothing, Nothing)
                                        'llenardias()
                                    End If
                                End If
                            End If
                        End If
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        CalcularTotalComprobantes()
                        btnAgregar.Enabled = True
                End Select

            End With
        Catch ex As Exception
        End Try
    End Sub

    Function cantera_maquina(ByVal fila As Int32, ByVal codconcepto As String) As Boolean
        If gridDetalle.Rows(fila).Cells("codAuxiliar").Value.ToString.Trim = "" Then Return True
        If gridDetalle.Rows(fila).Cells("codArea").Value.ToString.Trim = "912" And codconcepto.ToString.Trim = "MP" Then 'Or gridDetalle.Rows(fila).Cells("codArea").Value.ToString.Trim = "921" Or gridDetalle.Rows(fila).Cells("codArea").Value.ToString.Trim = "925"
            Dim array_maquina() As String
            Dim array_cantera_cab() As String
            Dim ayo As Int32
            Dim mes As Int32
            array_cantera_cab = txtcodCantera.Text.Split(",")
            array_maquina = gridDetalle.Rows(fila).Cells("codAuxiliar").Value.ToString.Split(",")
            ayo = Year(gridDetalle.Rows(fila).Cells("fechaComp").Value)
            mes = Month(gridDetalle.Rows(fila).Cells("fechaComp").Value)
            Dim cod_quipo As String = ""
            Dim cadena_Cantera As String = ""
            Dim dtCantera As New DataTable
            For i As Int32 = 0 To array_maquina.Count - 1
                dtCantera = New DataTable
                Entidad.Entregas = New ETEntregas
                Negocio.NEntregas = New NGEntregas
                cod_quipo = array_maquina(i)
                Entidad.Entregas.codAuxiliar = cod_quipo
                Entidad.Entregas.Anho = ayo
                Entidad.Entregas.Mes = mes
                dtCantera = Negocio.NEntregas.Cantera_Maquina(Entidad.Entregas)
                Dim cantera As String = ""
                If dtCantera.Rows.Count > 0 Then cantera = dtCantera.Rows(0)(0)
                If cantera.ToString.Trim.ToUpper = "OK" Then Return True
                Dim cant As Int32 = 0
                For j As Int32 = 0 To array_cantera_cab.Count - 1
                    If cantera.ToString.Trim = array_cantera_cab(j).ToString.Trim Then
                        cadena_Cantera = cadena_Cantera + cantera + ","
                        cant += 1
                        Exit For
                    End If
                Next
                If cant = 0 Then
                    MsgBox("La cantera " & cantera & " asignada al equipo " & cod_quipo & " en la fila " & fila + 1 & " no se encuentra registrada")
                    gridDetalle.Rows(fila).Cells("codCantera").Value = ""
                    gridDetalle.Rows(fila).Cells("Cantera").Value = ""
                    Return False
                End If
            Next
            gridDetalle.Rows(fila).Cells("codCantera").Value = cadena_Cantera
            gridDetalle.Rows(fila).Cells("Cantera").Value = cadena_Cantera
        End If

        Return True
    End Function

    Sub Detalle_Recibos()
        gridDetalle.ActiveRow.Cells("Serie").Value = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.Trim.PadLeft(4, "0")
        gridDetalle.ActiveRow.Cells("NumDoc").Value = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim.PadLeft(16, "0")
        Me.gridDetalle.PerformAction(ExitEditMode)
        Me.gridDetalle.PerformAction(ExitEditMode)
        If Ls_DetalleRecibo Is Nothing Then
            Ls_DetalleRecibo = New List(Of ETEntregas)
        End If
        If Ls_DetalleReciboEliminado Is Nothing Then
            Ls_DetalleReciboEliminado = New List(Of ETEntregas)
        End If
        Dim numDoc As String = String.Empty
        numDoc = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.PadLeft(16, "0") '("0000000000000000")
        Dim frm As FrmDetalleRH
        frm = New FrmDetalleRH
        frm.txtruc.Text = gridDetalle.ActiveRow.Cells("nroruc").Value.ToString.Trim
        frm.txtrazon.Text = gridDetalle.ActiveRow.Cells("Razon").Value.ToString.Trim
        frm.txttd.Text = gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim
        frm.txtserie.Text = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.Trim
        frm.txtnumero.Text = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim
        frm.x_idcomp = gridDetalle.ActiveRow.Cells("idComp").Value.ToString.Trim
        frm.x_fila = gridDetalle.ActiveRow.Cells("nfila").Value.ToString.Trim 'gridDetalle.ActiveRow.Index
        Dim monDocumento As String = String.Empty
        monDocumento = gridDetalle.ActiveRow.Cells("moneda").Value.ToString.Trim
        frm.ShowDialog()
        gridDetalle.ActiveRow.Cells("montoTotalParcial").Value = frm.monto
    End Sub


    Sub DocumentosAsociados()
        gridDetalle.ActiveRow.Cells("Serie").Value = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.Trim.PadLeft(4, "0")
        If Me.gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim = "VL" And gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim = "" Then
            gridDetalle.ActiveRow.Cells("NumDoc").Value = Convert.ToInt32(txtnsolicitud.Text.Substring(1, 7)).ToString & gridDetalle.ActiveRow.Index + 1.ToString
        End If
        gridDetalle.ActiveRow.Cells("NumDoc").Value = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim.PadLeft(16, "0")
        Me.gridDetalle.PerformAction(ExitEditMode)
        CalcularTotalComprobantes()
        Me.gridDetalle.PerformAction(ExitEditMode)
        If Ls_DocAsociado Is Nothing Then
            Ls_DocAsociado = New List(Of ETEntregas)
        End If
        If Ls_DocAsociadoEliminado Is Nothing Then
            Ls_DocAsociadoEliminado = New List(Of ETEntregas)
        End If
        Dim numDoc As String = String.Empty
        numDoc = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.PadLeft(16, "0") '("0000000000000000")
        Dim frm As FrmFacturasAsociadas
        frm = New FrmFacturasAsociadas
        frm.txtruc.Text = gridDetalle.ActiveRow.Cells("nroruc").Value.ToString.Trim
        frm.txtrazon.Text = gridDetalle.ActiveRow.Cells("Razon").Value.ToString.Trim
        frm.txttd.Text = gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim
        frm.txtserie.Text = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.Trim
        frm.txtnumero.Text = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim
        frm.codArea = gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim
        frm.flgcompra = gridDetalle.ActiveRow.Cells("flgcompra").Value.ToString.Trim
        frm.auxi = auxi
        frm.flgauxi = flgauxi
        Dim monDocumento As String = String.Empty
        monDocumento = gridDetalle.ActiveRow.Cells("moneda").Value.ToString.Trim
        frm.txtimporte.Text = CDbl(gridDetalle.ActiveRow.Cells("montoTotal").Value).ToString("#####0.00")
        frm.txtcambio.Text = CDbl(gridDetalle.ActiveRow.Cells("tipocambio").Value).ToString("#####0.00")
        If monDocumento = "S/." Or monDocumento = "NUEVOS SOLES" Then
            frm.txtmoneda.Text = "NUEVOS SOLES"
        Else
            frm.txtmoneda.Text = "DÓLARES"
        End If
        frm.mon = monDocumento
        frm.moneda = moneda
        frm.ShowDialog()
        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Auxiliar").Value = Auxiliar
    End Sub

    Sub DocumentosMovilidad()
        gridDetalle.ActiveRow.Cells("Serie").Value = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.Trim.PadLeft(4, "0")
        If Me.gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim = "VL" And gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim = "" Then
            gridDetalle.ActiveRow.Cells("NumDoc").Value = Convert.ToInt32(txtnsolicitud.Text.Substring(1, 7)).ToString & gridDetalle.ActiveRow.Index + 1.ToString
        End If
        gridDetalle.ActiveRow.Cells("NumDoc").Value = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim.PadLeft(16, "0")
        CalcularTotalComprobantes()
        Me.gridDetalle.PerformAction(ExitEditMode)
        If Ls_DocMovilidad Is Nothing Then
            Ls_DocMovilidad = New List(Of ETEntregas)
        End If
        If Ls_DocMovilidadEliminado Is Nothing Then
            Ls_DocMovilidadEliminado = New List(Of ETEntregas)
        End If
        Dim numDoc As String = String.Empty
        numDoc = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.PadLeft(16, "0")
        Dim frm As FrmMovilidad
        frm = New FrmMovilidad
        Dim tipo_doc As String = gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString
        frm.txtruc.Text = IIf(tipo_doc.Trim = "VL", "", gridDetalle.ActiveRow.Cells("nroruc").Value.ToString)
        frm.txtrazon.Text = gridDetalle.ActiveRow.Cells("Razon").Value.ToString
        frm.txttd.Text = tipo_doc '
        frm.txtserie.Text = gridDetalle.ActiveRow.Cells("Serie").Value.ToString
        frm.txtnumero.Text = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString
        frm.codtrabajador = TxtCodigoTrabajador.Text
        frm.NumSolicitud = NumSolicitud
        Dim monDocumento As String = String.Empty
        monDocumento = gridDetalle.ActiveRow.Cells("moneda").Value.ToString.Trim
        frm.txtimporte.Text = CDbl(gridDetalle.ActiveRow.Cells("montoTotal").Value).ToString("#####0.00")
        frm.txtcambio.Text = CDbl(gridDetalle.ActiveRow.Cells("tipocambio").Value).ToString("#####0.00")
        If monDocumento = "S/." Or monDocumento = "NUEVOS SOLES" Then
            frm.txtmoneda.Text = "NUEVOS SOLES"
        Else
            frm.txtmoneda.Text = "DÓLARES"
        End If
        frm.mon = monDocumento
        frm.moneda = moneda
        frm.fechaSalida = dtFechaSalida.Value
        frm.fechaRetorno = dtFechaRetorno.Value
        frm.ShowDialog()
    End Sub

    Sub DocumentosCombustible()
        gridDetalle.ActiveRow.Cells("Serie").Value = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.Trim.PadLeft(4, "0")
        If Me.gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim = "VL" And gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim = "" Then
            gridDetalle.ActiveRow.Cells("NumDoc").Value = Convert.ToInt32(txtnsolicitud.Text.Substring(1, 7)).ToString & gridDetalle.ActiveRow.Index + 1.ToString
        End If
        gridDetalle.ActiveRow.Cells("NumDoc").Value = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim.PadLeft(16, "0")
        CalcularTotalComprobantes()
        Me.gridDetalle.PerformAction(ExitEditMode)
        If Ls_DocCombustible Is Nothing Then
            Ls_DocCombustible = New List(Of ETEntregas)
        End If
        If Ls_DocCombustibleEliminado Is Nothing Then
            Ls_DocCombustibleEliminado = New List(Of ETEntregas)
        End If
        Dim numDoc As String = String.Empty
        numDoc = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.PadLeft(16, "0")
        Dim frm As frmIngresoCombustible
        frm = New frmIngresoCombustible
        frm.txtruc.Text = gridDetalle.ActiveRow.Cells("nroruc").Value.ToString
        frm.txtrazon.Text = gridDetalle.ActiveRow.Cells("Razon").Value.ToString
        frm.txttd.Text = gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString
        frm.txtserie.Text = gridDetalle.ActiveRow.Cells("Serie").Value.ToString
        frm.txtnumero.Text = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString

        Dim monDocumento As String = String.Empty
        monDocumento = gridDetalle.ActiveRow.Cells("moneda").Value.ToString.Trim
        frm.txtimporte.Text = CDbl(gridDetalle.ActiveRow.Cells("montoTotal").Value).ToString("#####0.00")
        'frm.txtcambio.Text = CDbl(gridDetalle.ActiveRow.Cells("tipocambio").Value).ToString("#####0.00")
        'If monDocumento = "S/." Or monDocumento = "NUEVOS SOLES" Then
        '    frm.txtmoneda.Text = "NUEVOS SOLES"
        'Else
        '    frm.txtmoneda.Text = "DÓLARES"
        'End If
        'frm.mon = monDocumento
        'frm.moneda = moneda
        'frm.fechaSalida = dtFechaSalida.Value
        'frm.fechaRetorno = dtFechaRetorno.Value
        frm.ShowDialog()
    End Sub

    Private Sub gridDetalle_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridDetalle.AfterCellUpdate
        If gridDetalle.Rows(e.Cell.Row.Index).Cells("Descripcion").Value.ToString = "REINTEGRO" Then Return
        If e.Cell.Column.Key = "montoTotalParcial" Then
            CalcularTotalComprobantes()
            monto = gridDetalle.ActiveRow.Cells("montoTotalParcial").Value
        End If
    End Sub

    Sub ObtenerRazon()
        If gridDetalle.ActiveRow.Cells("nroruc").Value.ToString.Trim <> "" And gridDetalle.ActiveRow.Cells("nroruc").Value.ToString.Length < 11 Then
            MsgBox("Debe ingresar 11 dígitos", MsgBoxStyle.Exclamation, msgComacsa) : gridDetalle.PerformAction(PrevCellByTab) : Return
        End If
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.nroruc = gridDetalle.ActiveRow.Cells("nroruc").Value.ToString
        Entidad.MyLista = Negocio.NEntregas.Listar_ProveedorxRuc(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        If Ls_Entrega.Count > 0 Then
            gridDetalle.ActiveRow.Cells("razon").Value = Ls_Entrega.Item(0).Razon.ToString '"PRUEBA"
            gridDetalle.PerformAction(NextCellByTab)
        End If
        '    If Ls_Entrega.Count > 0 Then
        '        gridDetalle.ActiveRow.Cells("razon").Value = Ls_Entrega.Item(0).Razon.ToString '"PRUEBA"
        '        gridDetalle.PerformAction(NextCellByTab)
        '    Else
        '        lblEspera.Visible = True
        '        lblEspera.Text = "Buscando Datos en Sunat..."
        '        lblEspera.Refresh()
        '        lblEspera.Update()
        '        Cursor = Cursors.WaitCursor
        '        Dim dato_sunat As New metodos()
        '        Try
        '            dato_sunat.Buscar_por_DNI = False
        '            dato_sunat.Buscar_por_Ruc = True
        '            dato_sunat.Documento_a_Buscar = Entidad.Entregas.nroruc.ToString.Trim
        '            dato_sunat.Buscar_el_Documento()
        '        Catch ex As Exception
        '            Cursor = Cursors.Default
        '            MsgBox(ex.Message.ToString)
        '        End Try
        '        'If dato_sunat.Dato_Encontrado = True Then
        '        '    With dato_sunat
        '        '        gridDetalle.ActiveRow.Cells("razon").Value = .Nombre
        '        '        gridDetalle.PerformAction(NextCellByTab)
        '        '    End With
        '        'Else
        '        '    MsgBox("No se encontró ruc registrado en la sunat", MsgBoxStyle.Exclamation, msgComacsa)
        '        '    gridDetalle.ActiveRow.Cells("razon").Value = String.Empty
        '        'End If
        '        dato_sunat = Nothing
        '        Cursor = Cursors.Default
        '        lblEspera.Visible = False
        '        lblEspera.Refresh()
        '        lblEspera.Update()
        '    End If
        'End Sub

        'Sub ImporteDocumento()
        '    Dim tcambio As Double = 0
        '    Dim importe As Double = 0
        '    Dim total As Double = 0
        '    tcambio = gridDetalle.ActiveRow.Cells("tipocambio").Value
        '    importe = gridDetalle.ActiveRow.Cells("montoTotalParcial").Value
        '    If lblmoneda.Text = "NUEVOS SOLES" Then
        '        If gridDetalle.ActiveRow.Cells("moneda").Value.ToString.Trim = "S" Then
        '            gridDetalle.ActiveRow.Cells("montoTotal").Value = importe
        '        Else
        '            gridDetalle.ActiveRow.Cells("montoTotal").Value = importe / tcambio
        '        End If
        '    Else
        '        If gridDetalle.ActiveRow.Cells("moneda").Value.ToString.Trim = "S" Then
        '            gridDetalle.ActiveRow.Cells("montoTotal").Value = importe * tcambio
        '        Else
        '            gridDetalle.ActiveRow.Cells("montoTotal").Value = importe * 1
        '        End If
        '    End If
    End Sub
    Private Sub gridDetalle_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles gridDetalle.DoubleClickCell
        If Not e.Cell.Column.Key = "Descripcion" OrElse _
            e.Cell.Column.Key = "motivoDetalle" Then
            If gridDetalle.Rows(e.Cell.Row.Index).Cells("Descripcion").Value.ToString.Trim = "REINTEGRO" Then
                Exit Sub
            End If
        End If
    End Sub
    Sub grabar()
        Try

            If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
            If gridDetalle.Rows.Count = 0 Then MsgBox("Debe registrarse mínimo un comprobante", MsgBoxStyle.Exclamation, msgComacsa) : Return
            If Not ValidarCamposDetalle() Then Return
            nroSolicitud = txtnsolicitud.Text
            Ls_Entrega = New List(Of ETEntregas)
            Dim tipomoneda As String = String.Empty
            Me.gridDetalle.PerformAction(ExitEditMode)
            Me.gridDetalle.PerformAction(EnterEditMode)
            For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                tipomoneda = gridDetalle.Rows(i).Cells("moneda").Value.ToString.Trim
                If tipomoneda = "S/." Then tipomoneda = "S"
                If tipomoneda = "US$" Then tipomoneda = "D"
                If Not gridDetalle.Rows(i).Cells("Descripcion").Value.ToString.Trim = "REINTEGRO" Then
                    Dim _serie As String = String.Empty
                    'If gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "RH" Then
                    '    _serie = "E" & Convert.ToString(Convert.ToInt32(gridDetalle.Rows(i).Cells("Serie").Value)).ToString.PadLeft(3, "0")
                    'Else
                    _serie = gridDetalle.Rows(i).Cells("Serie").Value.ToString.PadLeft(4, "0")
                    'End If
                    numDoc = _serie & gridDetalle.Rows(i).Cells("NumDoc").Value.ToString.PadLeft(16, "0")
                Else
                    If gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "RH" Then gridDetalle.Rows(i).Cells("Serie").Value = "E" & gridDetalle.Rows(i).Cells("Serie").Value.TO.PadLeft(3, "0")
                    numDoc = gridDetalle.Rows(i).Cells("Serie").Value.ToString & gridDetalle.Rows(i).Cells("NumDoc").Value.ToString
                End If
                Entidad.Entregas = New ETEntregas
                Entidad.Entregas.TipoOperacion = 1
                Entidad.Entregas.NumSolicitud = txtnsolicitud.Text 'nroSolicitud
                Entidad.Entregas.fechaComp = gridDetalle.Rows(i).Cells("fechaComp").Value.ToString
                Entidad.Entregas.TipoDoc = gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString
                Entidad.Entregas.NumDoc = numDoc
                Entidad.Entregas.nroruc = gridDetalle.Rows(i).Cells("nroruc").Value.ToString
                Entidad.Entregas.Razon = gridDetalle.Rows(i).Cells("Razon").Value.ToString
                Entidad.Entregas.codmotivoDetalle = gridDetalle.Rows(i).Cells("codMotivodetalle").Value.ToString
                Entidad.Entregas.Motivo = IIf(txtMotivo.Value Is Nothing, String.Empty, txtMotivo.Value)
                Entidad.Entregas.motivoDetalle = gridDetalle.Rows(i).Cells("motivoDetalle").Value.ToString
                Entidad.Entregas.Descripcion = gridDetalle.Rows(i).Cells("Descripcion").Value.ToString
                Entidad.Entregas.codConcepto = gridDetalle.Rows(i).Cells("codConcepto").Value.ToString
                Entidad.Entregas.montoTotalParcial = gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString
                Entidad.Entregas.idComp = gridDetalle.Rows(i).Cells("idComp").Value.ToString
                Entidad.Entregas.TipoOperacion = gridDetalle.Rows(i).Cells("TipoOperacion").Value.ToString
                Entidad.Entregas.codAuxiliar = gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString
                Entidad.Entregas.moneda = tipomoneda
                Entidad.Entregas.tipocambio = gridDetalle.Rows(i).Cells("tipocambio").Value.ToString
                Entidad.Entregas.montoTotal = gridDetalle.Rows(i).Cells("montoTotal").Value.ToString
                Entidad.Entregas.codArea = gridDetalle.Rows(i).Cells("codArea").Value.ToString
                Entidad.Entregas.fechaSalida = IIf(dtFechaSalida.Value Is Nothing, String.Empty, dtFechaSalida.Value)
                Entidad.Entregas.fechaRetorno = IIf(dtFechaRetorno.Value Is Nothing, String.Empty, dtFechaRetorno.Value)
                Entidad.Entregas.codCantera = IIf(txtcodCantera.Value Is Nothing, String.Empty, txtcodCantera.Value)
                Entidad.Entregas.Region = IIf(txtRegion.Value Is Nothing, String.Empty, txtRegion.Value)
                Entidad.Entregas.codCanteradet = gridDetalle.Rows(i).Cells("Cantera").Value.ToString
                Entidad.Entregas.comentario = gridDetalle.Rows(i).Cells("comentario").Value.ToString
                Entidad.Entregas.nfila = gridDetalle.Rows(i).Cells("nfila").Value
                Entidad.Entregas.flgretencion = gridDetalle.Rows(i).Cells("flgretencion").Value
                Entidad.Entregas.Usuario = User_Sistema
                Entidad.Entregas.ID = idPendiente
                If chkCerrar.Checked = True Then
                    Entidad.Entregas.idEstado = 4
                Else
                    Entidad.Entregas.idEstado = 3
                End If
                Entidad.Entregas.dias = gridDetalle.Rows(i).Cells("dias").Value.ToString
                Entidad.Entregas.personas = gridDetalle.Rows(i).Cells("personas").Value.ToString
                Entidad.Entregas.IDANEXO3 = gridDetalle.Rows(i).Cells("IDANEXO3").Value.ToString
                Entidad.Entregas.ANEXO3 = gridDetalle.Rows(i).Cells("ANEXO3").Value.ToString
                Entidad.Entregas.PLACA_TERCERO = gridDetalle.Rows(i).Cells("PLACA_TERCERO").Value.ToString
                Ls_Entrega.Add(Entidad.Entregas)
            Next
            If Ls_EntregaEliminado.Count > 0 Then
                For Each row In Ls_EntregaEliminado
                    Entidad.Entregas = New ETEntregas
                    Entidad.Entregas.TipoOperacion = 3
                    Entidad.Entregas.NumSolicitud = row.NumSolicitud
                    Entidad.Entregas.fechaComp = row.fechaComp
                    Entidad.Entregas.TipoDoc = row.TipoDoc
                    Entidad.Entregas.NumDoc = row.NumDoc
                    Entidad.Entregas.nroruc = row.nroruc
                    Entidad.Entregas.Razon = row.Razon
                    Entidad.Entregas.Descripcion = ""
                    Entidad.Entregas.codConcepto = ""
                    Entidad.Entregas.montoTotalParcial = 0
                    Entidad.Entregas.idComp = row.idComp
                    Entidad.Entregas.codAuxiliar = ""
                    Entidad.Entregas.moneda = ""
                    Entidad.Entregas.tipocambio = 0
                    Entidad.Entregas.dias = 0
                    Entidad.Entregas.personas = 0
                    Ls_Entrega.Add(Entidad.Entregas)
                Next
            End If
            Dim tiposaldo As String = String.Empty
            Dim saldo As String = String.Empty
            Dim reintegro As Double = CDbl(txtreintegro.Text)
            Dim devolucion As Double = CDbl(txtdevolucion.Text)
            If reintegro = 0 And devolucion = 0 Then tiposaldo = "1"
            If reintegro > 0 Then tiposaldo = "2" : saldo = reintegro.ToString("#####0.00")
            If devolucion > 0 Then tiposaldo = "3" : saldo = devolucion.ToString("#####0.00")
            If esDevolucion = 0 Then
                tipotabla = 1
                Entidad.Entregas = Negocio.NEntregas.MantenimientoLiquidacion(Entidad.Entregas, Ls_Entrega, tiposaldo, saldo, tipmon)
                If Not Entidad.Entregas.Validacion Then Return
                If Ls_DocAsociado.Count > 0 Then
                    Entidad.Entregas = Negocio.NEntregas.MantenimientoDocInterno(Entidad.Entregas, Ls_DocAsociado)
                End If
                If Ls_DocAsociadoEliminado.Count > 0 Then
                    Entidad.Entregas = Negocio.NEntregas.MantenimientoDocInterno(Entidad.Entregas, Ls_DocAsociadoEliminado)
                End If
            Else
                tipotabla = 2
                Entidad.Entregas = Negocio.NEntregas.MantenimientoLiquidacionPend(Entidad.Entregas, Ls_Entrega, tiposaldo, saldo)
                If Not Entidad.Entregas.Validacion Then Return
                If Ls_DocAsociado.Count > 0 Then
                    Entidad.Entregas = Negocio.NEntregas.MantenimientoDocInternoPend(Entidad.Entregas, Ls_DocAsociado)
                End If
                If Ls_DocAsociadoEliminado.Count > 0 Then
                    Entidad.Entregas = Negocio.NEntregas.MantenimientoDocInternoPend(Entidad.Entregas, Ls_DocAsociadoEliminado)
                End If
            End If

            If Ls_DetalleRecibo.Count > 0 Then
                Entidad.Entregas = Negocio.NEntregas.MantenimientoDetalleRecibo(txtnsolicitud.Text, Ls_DetalleRecibo)
            End If
            'If Ls_DocMovilidadEliminado.Count > 0 Then
            '    Entidad.Entregas = Negocio.NEntregas.MantenimientoDocMovilidad(Entidad.Entregas, Ls_DocMovilidadEliminado, tipotabla)
            'End If

            If Ls_DocMovilidad.Count > 0 Then
                Entidad.Entregas = Negocio.NEntregas.MantenimientoDocMovilidad(Entidad.Entregas, Ls_DocMovilidad, tipotabla)
            End If
            If Ls_DocMovilidadEliminado.Count > 0 Then
                Entidad.Entregas = Negocio.NEntregas.MantenimientoDocMovilidad(Entidad.Entregas, Ls_DocMovilidadEliminado, tipotabla)
            End If
            If Ls_DocCombustible.Count > 0 Then
                Entidad.Entregas = Negocio.NEntregas.MantenimientoDocCombustible(Entidad.Entregas, Ls_DocCombustible, tipotabla)
            End If
            If Ls_DocCombustibleEliminado.Count > 0 Then
                Entidad.Entregas = Negocio.NEntregas.MantenimientoDocCombustible(Entidad.Entregas, Ls_DocCombustibleEliminado, tipotabla)
            End If

            If Entidad.Entregas.Validacion Then
                Me.TabMaestroEntregas.Tabs("Lista").Selected = True
                Call Inicio()
                Call LimpiarDatos()
                lblmoneda.Visible = False
            End If
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub cargarValoresDetalle(ByVal numsolicitud As String, ByVal esDevolucion As Int32)
        Ls_DetalleComp = New List(Of ETEntregas)
        Entidad.Entregas.NumSolicitud = numsolicitud
        Entidad.Entregas.ID = idPendiente
        If esDevolucion = 0 Then
            Entidad.MyLista = Negocio.NEntregas.Listar_DetalleLiquidacion(Entidad.Entregas)
        Else
            Entidad.MyLista = Negocio.NEntregas.Listar_DetalleLiquidacionPend(Entidad.Entregas)
        End If
        If Entidad.MyLista.Validacion Then
            Ls_DetalleComp = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGrid(gridDetalle, Ls_DetalleComp)
        If Ls_DetalleComp.Count > 0 Then
            comboMoneda()
            For i As Int32 = 0 To Ls_DetalleComp.Count - 1
                If Ls_DetalleComp.Item(i).codConcepto.ToString.Trim = "43" Then
                    chkActivarDev.Checked = True
                End If
                gridDetalle.Rows(i).Cells("moneda").Value = Ls_DetalleComp.Item(i).moneda.ToString.Trim
                gridDetalle.Rows(i).Cells("tipocambio").Value = Ls_DetalleComp.Item(i).tipocambio
            Next
        End If
        CalcularTotalComprobantes()
        cargarDocAsociado(numsolicitud, esDevolucion)
        cargarDocMovilidad(numsolicitud, esDevolucion)
        cargarDocCombustible(numsolicitud, esDevolucion)
        cargarDocDeatlleRH(numsolicitud, esDevolucion)
        For i As Int32 = gridDetalle.Rows.Count - 1 To 0 Step -1
            gridDetalle.Rows(i).ToolTipText = "COMENTARIO : " & gridDetalle.Rows(i).Cells("comentario").Value
            If gridDetalle.Rows(i).Cells("codConcepto").Value.ToString = "43" Or gridDetalle.Rows(i).Cells("codConcepto").Value.ToString = "59" Then
                gridDetalle.ActiveRow.Cells("fechaComp").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("moneda").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("TipoDoc").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("Serie").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("NumDoc").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("nroruc").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("Razon").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("montoTotalParcial").Activation = Activation.AllowEdit
                Dim id As Int32 = gridDetalle.Rows(i).Cells("idComp").Value
                If id <> 0 Then
                    Entidad.Entregas = New ETEntregas
                    Entidad.Entregas.idComp = gridDetalle.Rows(i).Cells("idComp").Value.ToString
                    Entidad.MyLista = Negocio.NEntregas.VerificaDevolucion(Entidad.Entregas)
                    lResult = New ETMyLista
                    lResult = Entidad.MyLista
                    If Entidad.MyLista.Validacion Then
                        If Entidad.MyLista.Ls_Entrega.Count > 0 Then cancelado = 1 : Exit Sub Else cancelado = 0
                    End If
                End If
            End If
        Next
    End Sub
    Sub cargarDocAsociado(ByVal numsolicitud As String, ByVal esDevolucion As Int32)
        Ls_DocAsociado = New List(Of ETEntregas)
        Ls_DocAsociadoEliminado = New List(Of ETEntregas)
        Entidad.Entregas.NumSolicitud = numsolicitud
        If esDevolucion = 0 Then
            Entidad.MyLista = Negocio.NEntregas.Listar_DocAsociadoLiqui(Entidad.Entregas)
        Else
            Entidad.MyLista = Negocio.NEntregas.Listar_DocAsociadoLiquiPend(Entidad.Entregas)
        End If
        If Entidad.MyLista.Validacion Then
            Ls_DocAsociado = Entidad.MyLista.Ls_Entrega
        End If
    End Sub

    Sub cargarDocMovilidad(ByVal numsolicitud As String, ByVal esDevolucion As Int32)
        Ls_DocMovilidad = New List(Of ETEntregas)
        Ls_DocMovilidadEliminado = New List(Of ETEntregas)
        Entidad.Entregas.NumSolicitud = numsolicitud
        If esDevolucion = 0 Then
            tipotabla = 1
        Else
            tipotabla = 2
        End If
        Entidad.MyLista = Negocio.NEntregas.Listar_DocMovilidad(Entidad.Entregas, tipotabla)
        If Entidad.MyLista.Validacion Then
            Ls_DocMovilidad = Entidad.MyLista.Ls_Entrega
        End If
    End Sub

    Sub cargarDocDeatlleRH(ByVal numsolicitud As String, ByVal esDevolucion As Int32)
        Ls_DetalleRecibo = New List(Of ETEntregas)
        Ls_DetalleReciboEliminado = New List(Of ETEntregas)
        Entidad.Entregas.NumSolicitud = numsolicitud
        If esDevolucion = 0 Then
            tipotabla = 1
        Else
            tipotabla = 2
        End If
        Entidad.MyLista = Negocio.NEntregas.Listar_DocDetalleRH(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_DetalleRecibo = Entidad.MyLista.Ls_Entrega
        End If
    End Sub

    Sub cargarDocCombustible(ByVal numsolicitud As String, ByVal esDevolucion As Int32)
        Ls_DocCombustible = New List(Of ETEntregas)
        Ls_DocCombustibleEliminado = New List(Of ETEntregas)
        Entidad.Entregas.NumSolicitud = numsolicitud
        If esDevolucion = 0 Then
            tipotabla = 1
        Else
            tipotabla = 2
        End If
        Entidad.MyLista = Negocio.NEntregas.Listar_DocCombustible(Entidad.Entregas, tipotabla)
        If Entidad.MyLista.Validacion Then
            Ls_DocCombustible = Entidad.MyLista.Ls_Entrega
        End If
    End Sub

    Public Sub Reporte()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If nroSolicitud.ToString.Trim = "" Then Return
        lblmensaje.Visible = True
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Refresh()
        lblmensaje.Update()
        nroSolicitud = txtnsolicitud.Text
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        StrucForm.FxRxLiquidacion = New FrmRptLiquidacion
        StrucForm.FxRxLiquidacion.MdiParent = MdiParent
        StrucForm.FxRxLiquidacion.esDevolucion = esDevolucion
        StrucForm.FxRxLiquidacion.Show()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        lblmensaje.Visible = False
        lblmensaje.Refresh()
        lblmensaje.Update()
    End Sub
    Sub cancelar()
        Call Inicio()
        Call LimpiarDatos()
        lblmoneda.Visible = False
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
    End Sub
    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Inicio()
        Call LimpiarDatos()
        lblmoneda.Visible = False
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Private Sub gridDetalle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridDetalle.KeyPress
        Try
            If e.KeyChar = "+" Then
                Btn3_Click(Nothing, Nothing)
                e.Handled = True
                Return
            End If
            If e.KeyChar = "-" Then
                Btn4_Click(Nothing, Nothing)
                e.Handled = True
                Return
            End If
            If e.KeyChar = ChrW(Keys.Escape) Then Return
            If e.KeyChar = ChrW(Keys.Delete) Then Return
            If e.KeyChar = ChrW(Keys.Return) Then Return
            If e.KeyChar = ChrW(Keys.Back) Then Return
            If e.KeyChar.ToString.Trim = "" Then Return

            If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString = "43" And _
            gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key <> "montoTotalParcial" Then e.Handled = True : Return
            If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString = "43" Then
                If cancelado = 1 Then
                    MsgBox("La devolución ya fue cancelada", MsgBoxStyle.Exclamation, msgComacsa) : e.Handled = True
                End If
            End If
            'If cancelado = 0
            If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString = "59" Then e.Handled = True : Return
            If Not gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Descripcion" OrElse _
             gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "motivoDetalle" Then
                If gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Descripcion").Value.ToString.Trim = "REINTEGRO" Then
                    e.Handled = True
                    Exit Sub
                End If
            End If

            'Dim dtAuxi3 As New DataTable
            'Entidad.Entregas = New ETEntregas
            'Entidad.Entregas.codArea = gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim
            'Entidad.Entregas.codConcepto = codConcepto
            'Entidad.Entregas.Anho = Year(gridDetalle.ActiveRow.Cells("fechaComp").Value)
            'dtAuxi3 = Negocio.NEntregas.VerAuxi3(Entidad.Entregas)

            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "ANEXO3" Then
                Dim dtAuxi3 As New DataTable
                Entidad.Entregas = New ETEntregas
                Entidad.Entregas.codArea = gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim
                Entidad.Entregas.codConcepto = gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim
                Entidad.Entregas.Anho = Year(gridDetalle.ActiveRow.Cells("fechaComp").Value)
                dtAuxi3 = Negocio.NEntregas.VerAuxi3(Entidad.Entregas)
                gridDetalle.ActiveRow.Cells("IDANEXO3").Value = dtAuxi3.Rows(0)(0)
                If gridDetalle.ActiveRow.Cells("IDANEXO3").Value <> 0 Then
                    Dim frm As New FrmAuxi3
                    frm.tipo = gridDetalle.ActiveRow.Cells("IDANEXO3").Value
                    frm.codarea = gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim
                    frm.ShowDialog()
                    If codAuxiliar.Trim = "" Then e.Handled = True : Return
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("ANEXO3").Value = codAuxiliar
                    'gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Descripcion").Value = Auxiliar
                End If
            End If

            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Descripcion" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                If Not validarImportesAsociados() Then e.Handled = True : Return
                If gridDetalle.ActiveRow.Cells("Area").Value.ToString = "" Then e.Handled = True : MsgBox("Ingrese Área", MsgBoxStyle.Exclamation, msgComacsa) : Return
                Dim frm As New FrmDatosComprobantes
                frm.cod_Area = gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.ShowDialog()
                If codConcepto.Trim = "" Then e.Handled = True : Return
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codConcepto").Value = codConcepto
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Descripcion").Value = Concepto

                Dim dtAuxi3 As New DataTable
                Entidad.Entregas = New ETEntregas
                Entidad.Entregas.codArea = gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim
                Entidad.Entregas.codConcepto = codConcepto
                Entidad.Entregas.Anho = Year(gridDetalle.ActiveRow.Cells("fechaComp").Value)
                dtAuxi3 = Negocio.NEntregas.VerAuxi3(Entidad.Entregas)
                'MsgBox(dtAuxi3.Rows(0)(0))
                gridDetalle.ActiveRow.Cells("IDANEXO3").Value = dtAuxi3.Rows(0)(0)
                gridDetalle.ActiveRow.Cells("Auxiliar").Value = ""

                NecesitaAuxiliar(gridDetalle.ActiveRow.Index)
                codConcepto = ""
                Concepto = ""
                If Concepto.ToString.Trim = "REINTEGRO" Then
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("nroruc").Value = ""
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Razon").Value = ""
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("TipoDoc").Value = ""
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Serie").Value = ""
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("NumDoc").Value = ""
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("montoTotalParcial").Value = 0
                    CalcularTotalComprobantes()
                End If
                gridDetalle.PerformAction(NextCellByTab)
                e.Handled = True
                Exit Sub
            End If
            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "nroruc" Then
                If Not validarImportesAsociados() Then e.Handled = True : Return
            End If
            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "NumDoc" Then
                If Not validarImportesAsociados() Then e.Handled = True : Return
            End If
            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Serie" Then
                If Not validarImportesAsociados() Then e.Handled = True : Return
            End If
            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "TipoDoc" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                If Not validarImportesAsociados() Then e.Handled = True : Return
                Dim frm As New FrmListadoDocumentos
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.ShowDialog()
                If codTipoDoc.Trim = "" Then e.Handled = True : Return

                If TipoDoc.Trim = "RH" And txtcodarea.Text.Trim = "42" Then
                    Detalle_Recibos()
                    gridDetalle.ActiveRow.Cells("montoTotalParcial").Activation = Activation.ActivateOnly
                Else
                    If Not validarDetalleRecibo(Me.gridDetalle.ActiveRow.Index) Then Return
                    gridDetalle.ActiveRow.Cells("montoTotalParcial").Activation = Activation.AllowEdit
                End If

                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codTipoDoc").Value = codTipoDoc
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("TipoDoc").Value = TipoDoc
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("flgcompra").Value = flgcompra
                NecesitaAuxiliar(gridDetalle.ActiveRow.Index)
                If Not ValidarDocumentoRepetido(gridDetalle.ActiveRow.Index) Then
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codTipoDoc").Value = ""
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("TipoDoc").Value = ""
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("flgcompra").Value = 0
                    Return
                End If

                codTipoDoc = ""
                TipoDoc = ""
                gridDetalle.PerformAction(NextCellByTab)
                e.Handled = True
                Exit Sub
            End If
            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "motivoDetalle" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                Dim frm As New FrmMotivos
                frm.ShowDialog()
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codmotivoDetalle").Value = codMotivodetalle
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("motivoDetalle").Value = Motivodetalle
                gridDetalle.PerformAction(NextCellByTab)
                e.Handled = True
                Exit Sub
            End If
            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Area" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                Dim frm As New FrmAreas
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.ShowDialog()
                If codArea.Trim = "" Then e.Handled = True : Return
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codArea").Value = codArea
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Area").Value = Area
                NecesitaAuxiliar(gridDetalle.ActiveRow.Index)
                codArea = ""
                Area = ""
                gridDetalle.ActiveRow.Cells("DESCRIPCION").Value = ""
                gridDetalle.ActiveRow.Cells("IDANEXO3").Value = 0
                gridDetalle.ActiveRow.Cells("ANEXO3").Value = ""
                gridDetalle.PerformAction(NextCellByTab)
                e.Handled = True
                Exit Sub
            End If
            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Auxiliar" Then
                If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "00" Then e.Handled = True : Return
                If e.KeyChar.ToString.Trim = "" Then Return
                NecesitaAuxiliar(gridDetalle.ActiveRow.Index)
                If flgauxi = 0 And gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim = "912" Then
                    flgauxi = 1
                    auxi = "AC"
                    gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim()
                End If
                If flgauxi = 1 Then
                    Dim frm As New FrmAuxiliar
                    frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                    frm.auxi = auxi
                    'If gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim = "912" Then
                    '    frm.codconcepto = "MP"
                    'Else
                    frm.codconcepto = gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim
                    'SOLO PARA ALQUILER DE VEHICULOS
                    If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "48" Then
                        frm.codconcepto = gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim
                        frm.auxi = "AL"
                    End If
                    'End If
                    frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                    frm.cadena = gridDetalle.ActiveRow.Cells("Auxiliar").Value.ToString
                    frm.ShowDialog()
                    If codAuxiliar.Trim = "" Then e.Handled = True : Return
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Auxiliar").Value = Auxiliar
                    codAuxiliar = ""
                    Auxiliar = ""
                    cantera_maquina(gridDetalle.ActiveRow.Index, frm.codconcepto)
                    gridDetalle.PerformAction(NextCellByTab)
                    e.Handled = True
                    If gridDetalle.ActiveRow.Cells("Descripcion").Value.ToString.Trim = "COMBUSTIBLE" Then
                        DocumentosCombustible()
                    End If
                    gridDetalle.ActiveRow.Cells("placa_tercero").Value = frm.placa_tercero.ToString
                    Exit Sub
                Else
                    e.Handled = True : Return
                End If
            End If
            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Cantera" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                Dim frm As New FrmCanteras
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim

                Dim array As String() = txtcodCantera.Text.Split(",")
                'If array.Count = 1 Then Exit Sub
                frm.cadena = txtcodCantera.Text.ToString.Trim
                frm.cadenaDetalle = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Cantera").Value
                frm.tipo = 1

                frm.ShowDialog()
                If Not codCantera = "" Then
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codCantera").Value = codCantera
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Cantera").Value = codCantera
                    codCantera = ""
                    Cantera = ""
                End If
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub NecesitaAuxiliar(ByVal fila As Int32)
        'If gridDetalle.ActiveRow.Cells("flgcompra").Value = 1 Then
        '    If gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim = "912" Then
        '        flgauxi = 1
        '        auxi = "AC"
        '    Else
        '        flgauxi = 0
        '        auxi = ""
        '    End If
        'Else
        FlagAuxiliar(fila)
        'End If
        'If gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim = "912" Then
        '    flgauxi = 1
        '    auxi = "AC"
        'End If
        gridDetalle.Rows(fila).Cells("flgauxi").Value = flgauxi
        If gridDetalle.Rows(fila).Cells("codConcepto").Value.ToString.Trim = "48" Then flgauxi = 1 : gridDetalle.Rows(fila).Cells("flgauxi").Value = flgauxi
    End Sub

    Sub buscar()
        Try
            If flgaprobada = 1 Then Return
            If Gpb1.Enabled = False Then Return
            Dim dtFlgPermiso As Boolean
            With Entidad.Usuario
                .Login = User_Sistema
            End With
            dtFlgPermiso = Negocio.Usuario.PermisoEdicionLiquidacion(Entidad.Usuario)
            '@01 Add fin

            If dtFlgPermiso = True Then
                'If User_Sistema.ToUpper = "RPRINCIPE" Or User_Sistema.ToUpper = "COTOYA" Or User_Sistema.ToUpper = "SA" Or User_Sistema.ToUpper = "YRIS" Or User_Sistema.ToUpper = "MAMPUERO" Or User_Sistema.ToUpper = "JPAREJA" Or User_Sistema.ToUpper = "CCANTO" Then
                Dim frm As New FrmCanteras
                frm.filtroDescripcion = String.Empty
                frm.cadena = txtcodCantera.Text.ToString.Trim
                frm.tipo = 0
                frm.ShowDialog()
                If Not codCantera = "" Then
                    txtcodCantera.Text = codCantera
                    txtCantera.Text = Cantera
                    txtRegion.Text = ModVariable.Region
                    codCantera = ""
                    Cantera = ""
                End If

                If txtcodCantera.Text.ToString.Trim.Length = 5 Then
                    If Me.gridDetalle.Rows.Count > 0 Then
                        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                            If gridDetalle.Rows(i).Cells("codConcepto").Value.ToString.Trim <> "43" Then
                                gridDetalle.Rows(i).Cells("Cantera").Value = txtcodCantera.Text
                            End If
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        'Try
        '    If gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Descripcion").Value.ToString.Trim() = "REINTEGRO" Then
        '        Dim frm As New FrmListaReintegros
        '        frm.codtra = TxtCodigoTrabajador.Text.ToString.Trim
        '        frm.ShowDialog()
        '        Dim montoReintegro As Double = 0
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Serie").Value = "0000"
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("NumDoc").Value = frm.numsolicitud
        '        CalcularTotalComprobantes()
        '        montoReintegro = frm.monto
        '        Dim montoPendiente As Double = CDbl(Me.txttotalsolicitud.Text)
        '        Dim montoLiquidacion As Double = CDbl(Me.txttotalliquidacion.Text)
        '        If montoLiquidacion > montoPendiente Then MsgBox("Ya no hay monto a liquidar") : Return
        '        If montoReintegro + montoLiquidacion > montoPendiente Then
        '            MsgBox("El monto liquidado es mayor solo se tomará la cantidad necesaria")
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("montoTotalParcial").Value = montoPendiente - montoLiquidacion
        '            CalcularTotalComprobantes()
        '        Else
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("montoTotalParcial").Value = montoReintegro
        '            CalcularTotalComprobantes()
        '        End If
        '        Me.btnAgregar.Enabled = True
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub gridDetalle_CellListSelect(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridDetalle.CellListSelect
        If e.Cell.Column.Key = "moneda" Then
            gridDetalle.PerformAction(EnterEditMode)
            Dim val As ValueList
            Dim item As ValueListItem
            val = New ValueList()
            item = New ValueListItem()
            gridDetalle.DisplayLayout.Bands(0).Columns("moneda").ValueList.GetText(0)
            val = gridDetalle.DisplayLayout.Bands(0).Columns("moneda").ValueList
            item = val.ValueListItems(e.Cell.Column.ValueList.SelectedItemIndex)
            Dim monliquidacion As String = lblmoneda.Text.ToString.Trim.Substring(0, 1)
            If monliquidacion = "N" Then monliquidacion = "S" Else monliquidacion = "D"
            If item.DataValue = monliquidacion Then
                gridDetalle.PerformAction(NextCellByTab)
                gridDetalle.PerformAction(NextCellByTab)
            Else
                gridDetalle.PerformAction(NextCellByTab)
            End If
            CalcularTotalComprobantes()
        End If
    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Try

            If nroSolicitud.Trim = "" Then MsgBox("Debe seleccionar una solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
            If esCreador = 0 Then MsgBox("No puede importar datos", MsgBoxStyle.Exclamation, msgComacsa) : Return
            If flgaprobada = 1 Then MsgBox("La liquidación se encuentra cerrada", MsgBoxStyle.Exclamation, msgComacsa) : Return

            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = ""
            Me.OpenFileDialog1.ShowDialog()
            If Me.OpenFileDialog1.CheckFileExists = False Then
                MsgBox("Archivo no existe", MsgBoxStyle.Exclamation, msgComacsa)
                Return
            End If

            If Me.OpenFileDialog1.FileName.ToString.Trim = "" Then
                Return
            End If

            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName

            lblEspera.Visible = True
            lblEspera.Text = "Cargando datos desde libro Excel..."
            lblEspera.Refresh()
            lblEspera.Update()
            Cursor = Cursors.WaitCursor
            If Not ValidarExcel(cadenaExcel) Then
                MsgBox("El archivo seleccionado es incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                Return
            End If

            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                          "Data Source= " & cadenaExcel & _
                          ";Extended Properties=""Excel 8.0;HDR=YES"""
            Dim oConn As New OleDbConnection(cs)
            oConn.Open()

            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyCommand = New System.Data.OleDb.OleDbDataAdapter _
            ("select * from [SUSTENTO$]", oConn)
            MyCommand.TableMappings.Add("Table", "TablaSustento")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            oConn.Close()
            oConn.Dispose()

            If Not DtSet.Tables("TablaSustento").Columns.Count = 12 Then
                MsgBox("El archivo seleccionado es incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                Return
            End If

            Dim saldo As Double = 0
            Ls_Entrega = New List(Of ETEntregas)
            If gridDetalle.Rows.Count Then
                For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                    Dim id As Int32 = gridDetalle.Rows(i).Cells("idComp").Value
                    If id <> 0 Then
                        Entidad.Entregas = New ETEntregas
                        Entidad.Entregas.NumSolicitud = nroSolicitud
                        Entidad.Entregas.idComp = gridDetalle.Rows(i).Cells("idComp").Value.ToString
                        Entidad.Entregas.TipoOperacion = 3
                        Entidad.Entregas.fechaComp = gridDetalle.Rows(i).Cells("fechaComp").Value.ToString
                        Entidad.Entregas.TipoDoc = gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString
                        Entidad.Entregas.NumDoc = gridDetalle.Rows(i).Cells("NumDoc").Value.ToString
                        Entidad.Entregas.nroruc = gridDetalle.Rows(i).Cells("nroruc").Value.ToString
                        Entidad.Entregas.Razon = gridDetalle.Rows(i).Cells("Razon").Value.ToString
                        Entidad.Entregas.Descripcion = gridDetalle.Rows(i).Cells("Descripcion").Value.ToString
                        Entidad.Entregas.codConcepto = gridDetalle.Rows(i).Cells("codConcepto").Value.ToString
                        Entidad.Entregas.montoTotalParcial = gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString
                        Entidad.Entregas.codAuxiliar = "" '
                        Ls_EntregaEliminado.Add(Entidad.Entregas)
                    End If
                Next
            End If
            Ls_Entrega = New List(Of ETEntregas)
            For Each dr As DataRow In DtSet.Tables("TablaSustento").Rows
                Entidad.Entregas = New ETEntregas
                With Entidad.Entregas
                    If dr("fecha").ToString.Trim = "" Or dr("tipodoc").ToString.Trim = "" Or _
                     dr("nroruc").ToString.Trim = "" Or dr("codConcepto").ToString = "" Then
                        Exit For
                    End If
                    .fechaComp = dr("fecha")
                    .TipoDoc = dr("tipodoc").ToString
                    .Serie = dr("serie").ToString
                    .NumDoc = dr("numdoc").ToString
                    .nroruc = dr("nroruc").ToString
                    .Razon = dr("razon").ToString
                    .Descripcion = dr("Concepto").ToString
                    .codConcepto = dr("codConcepto").ToString
                    .codmotivoDetalle = ""
                    .motivoDetalle = ""
                    .montoTotalParcial = dr("monto").ToString
                    .codAuxiliar = ""
                    .TipoOperacion = 1
                    .idComp = 0
                    saldo = 0
                    If saldo > 0 Then
                        .montoDevolucion = 0
                        .montoReintegro = 0
                    Else
                        .montoDevolucion = 0
                        .montoReintegro = 0
                    End If
                    If dr("moneda").ToString = "S" Then
                        .moneda = "S/."
                    ElseIf dr("moneda").ToString = "D" Then
                        .moneda = "US$"
                    Else
                        .moneda = dr("moneda").ToString
                    End If
                    .tipocambio = dr("cambio")
                End With
                Ls_Entrega.Add(Entidad.Entregas)
            Next
            Ls_DetalleComp = New List(Of ETEntregas)
            Entidad.Entregas.NumSolicitud = NumSolicitud
            If Ls_Entrega.Count > 0 Then
                Ls_DetalleComp = Ls_Entrega
            End If
            Call CargarUltraGrid(gridDetalle, Ls_DetalleComp)
            If Ls_DetalleComp.Count > 0 Then
                comboMoneda()
                For i As Int32 = 0 To Ls_DetalleComp.Count - 1
                    gridDetalle.Rows(i).Cells("moneda").Value = Ls_DetalleComp.Item(i).moneda.ToString.Trim
                    gridDetalle.Rows(i).Cells("tipocambio").Value = Ls_DetalleComp.Item(i).tipocambio
                Next
            End If
            CalcularTotalComprobantes()
        Catch ex As Exception
            MsgBox(ex.InnerException)
        Finally
            Cursor = Cursors.Default
            lblEspera.Visible = False
            lblEspera.Refresh()
            lblEspera.Update()
        End Try
    End Sub

    Function ValidarExcel(ByVal RUTA As String) As Boolean
        Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
        Dim ObjW As Microsoft.Office.Interop.Excel.Workbook
        ObjExcel = New Microsoft.Office.Interop.Excel.Application
        ObjW = ObjExcel.Workbooks.Open(RUTA)
        Try
            If Not ObjW.Sheets(1).Name = "SUSTENTO" Then
                Return False
            End If
            Return True
        Catch ex As Exception
        Finally
            ObjW.Close()
            ObjW = Nothing
            ObjExcel.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(ObjExcel)
            ObjExcel = Nothing
        End Try
    End Function
    Sub FlagAuxiliar(ByVal fila As Int32)
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.codArea = gridDetalle.Rows(fila).Cells("codArea").Value.ToString.Trim
        Rpt.codConcepto = gridDetalle.Rows(fila).Cells("codConcepto").Value.ToString.Trim
        Entidad.MyLista = Negocio.NEntregas.FlagAuxiliar(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Validacion Then
            If Entidad.MyLista.Ls_Entrega.Count > 0 Then
                auxi = Entidad.MyLista.Ls_Entrega.Item(0).auxi
                If Not auxi.Trim = "" Then flgauxi = 1 Else flgauxi = 0
            Else
                flgauxi = 0
                auxi = String.Empty
            End If
        End If
    End Sub
    Function validarImportesAsociados() As Boolean
        Dim result As Boolean = True
        Dim ruc As String = Me.gridDetalle.ActiveRow.Cells("nroruc").Value.ToString.Trim
        Dim tdoc As String = Me.gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim
        Dim ndoc As String = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.PadLeft(16, "0")

        Dim Lista As ETEntregas = Nothing
        Dim ListaMovi As ETEntregas = Nothing
        Dim ListaComb As ETEntregas = Nothing

        If Ls_DocAsociado.Count > 0 Then
            For x As Int32 = 0 To Ls_DocAsociado.Count - 1
                Lista = Ls_DocAsociado.Where(Function(m) m.nroruc.ToString.Trim = ruc And _
                                              m.TipoDoc = tdoc.ToString.Trim And _
                                              m.NumDoc = ndoc).FirstOrDefault
                If Not Lista Is Nothing Then Exit For
            Next
        End If

        If Ls_DocMovilidad.Count > 0 Then
            For x As Int32 = 0 To Ls_DocMovilidad.Count - 1
                ListaMovi = Ls_DocMovilidad.Where(Function(m) m.nroruc.ToString.Trim = ruc And _
                                              m.TipoDoc = tdoc.ToString.Trim And _
                                              m.NumDoc = ndoc).FirstOrDefault
                If Not ListaMovi Is Nothing Then Exit For
            Next
        End If

        If Ls_DocCombustible.Count > 0 Then
            For h As Int32 = 0 To Ls_DocCombustible.Count - 1
                ListaComb = Ls_DocCombustible.Where(Function(m) m.nroruc.ToString.Trim = ruc And _
                                              m.TipoDoc = tdoc.ToString.Trim And _
                                              m.NumDoc = ndoc).FirstOrDefault
                If Not ListaComb Is Nothing Then Exit For
            Next
        End If

        If Not Lista Is Nothing Then
            If MsgBox("El documento tiene importes asociados ... ¿Desea eliminar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                result = False
            Else
                gridDetalle.ActiveRow.Cells("Auxiliar").Value = ""
                gridDetalle.ActiveRow.Cells("codAuxiliar").Value = ""
                For x As Int32 = 0 To Ls_DocAsociado.Count - 1
                    Lista = Ls_DocAsociado.Where(Function(m) m.nroruc.ToString.Trim = ruc And _
                                                  m.TipoDoc = tdoc.ToString.Trim And _
                                                  m.NumDoc = ndoc).FirstOrDefault
                    If Not Lista Is Nothing Then
                        Dim id As Int32 = Lista.idComp
                        If id <> 0 Then
                            Entidad.Entregas = New ETEntregas
                            Entidad.Entregas.NumSolicitud = nroSolicitud
                            Entidad.Entregas.idComp = id
                            Entidad.Entregas.TipoOperacion = 3
                            Entidad.Entregas.fechaComp = Lista.fechaComp
                            Entidad.Entregas.TipoDoc = Lista.TipoDoc
                            Entidad.Entregas.NumDoc = Lista.NumDoc
                            Entidad.Entregas.nroruc = Lista.nroruc
                            Entidad.Entregas.Razon = Lista.Razon
                            Entidad.Entregas.Descripcion = Lista.Descripcion
                            Entidad.Entregas.codConcepto = Lista.codConcepto
                            Entidad.Entregas.montoTotalParcial = Lista.montoTotalParcial
                            Entidad.Entregas.codAuxiliar = "" '
                            Ls_DocAsociadoEliminado.Add(Entidad.Entregas)
                        End If
                        Ls_DocAsociado.Remove(Ls_DocAsociado.Where(Function(m) m.nroruc = ruc And _
                                                     m.TipoDoc = tdoc And _
                                                     m.NumDoc = ndoc).FirstOrDefault)
                    End If
                Next
                result = True
            End If
        End If

        If Not ListaMovi Is Nothing Then

            If MsgBox("El documento tiene importes asociados de movilidad ...¿Desea eliminar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                result = False
            Else
                gridDetalle.ActiveRow.Cells("Auxiliar").Value = ""
                gridDetalle.ActiveRow.Cells("codAuxiliar").Value = ""
                For x As Int32 = 0 To Ls_DocMovilidad.Count - 1
                    ListaMovi = Ls_DocMovilidad.Where(Function(m) m.nroruc.ToString.Trim = ruc And _
                                                  m.TipoDoc = tdoc.ToString.Trim And _
                                                  m.NumDoc = ndoc).FirstOrDefault
                    If Not ListaMovi Is Nothing Then
                        Dim id As Int32 = ListaMovi.idComp
                        If id <> 0 Then
                            Entidad.Entregas = New ETEntregas
                            Entidad.Entregas.NumSolicitud = nroSolicitud
                            Entidad.Entregas.idComp = id
                            Entidad.Entregas.TipoOperacion = 3
                            Entidad.Entregas.fechaComp = ListaMovi.fechaComp
                            Entidad.Entregas.TipoDoc = ListaMovi.TipoDoc
                            Entidad.Entregas.NumDoc = ListaMovi.NumDoc
                            Entidad.Entregas.nroruc = ListaMovi.nroruc
                            Entidad.Entregas.Razon = ListaMovi.Razon
                            Entidad.Entregas.Descripcion = ListaMovi.Descripcion
                            Entidad.Entregas.codConcepto = ListaMovi.codConcepto
                            Entidad.Entregas.montoTotalParcial = ListaMovi.montoTotalParcial
                            Entidad.Entregas.codAuxiliar = "" '
                            Ls_DocMovilidadEliminado.Add(Entidad.Entregas)
                        End If
                        Ls_DocMovilidad.Remove(Ls_DocMovilidad.Where(Function(m) m.nroruc = ruc And _
                                                     m.TipoDoc = tdoc And _
                                                     m.NumDoc = ndoc).FirstOrDefault)
                    End If
                Next
                'DocumentosAsociados()
                result = True
            End If

        End If

        If Not ListaComb Is Nothing Then

            If MsgBox("El documento tiene importes asociados de combustible ...¿Desea eliminar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                result = False
            Else
                gridDetalle.ActiveRow.Cells("Auxiliar").Value = ""
                gridDetalle.ActiveRow.Cells("codAuxiliar").Value = ""
                For h As Int32 = 0 To Ls_DocCombustible.Count - 1
                    ListaComb = Ls_DocCombustible.Where(Function(m) m.nroruc.ToString.Trim = ruc And _
                                                  m.TipoDoc = tdoc.ToString.Trim And _
                                                  m.NumDoc = ndoc).FirstOrDefault
                    If Not ListaComb Is Nothing Then
                        Dim id As Int32 = ListaComb.idComp
                        If id <> 0 Then
                            Entidad.Entregas = New ETEntregas
                            Entidad.Entregas.NumSolicitud = nroSolicitud
                            Entidad.Entregas.idComp = id
                            Entidad.Entregas.TipoOperacion = 3
                            Entidad.Entregas.fechaComp = ListaComb.fechaComp
                            Entidad.Entregas.TipoDoc = ListaComb.TipoDoc
                            Entidad.Entregas.NumDoc = ListaComb.NumDoc
                            Entidad.Entregas.nroruc = ListaComb.nroruc
                            Entidad.Entregas.Razon = ListaComb.Razon
                            Entidad.Entregas.Descripcion = ListaComb.Descripcion
                            Entidad.Entregas.codConcepto = ListaComb.codConcepto
                            Entidad.Entregas.montoTotalParcial = ListaComb.montoTotalParcial
                            Entidad.Entregas.Galones = ListaComb.Galones
                            Entidad.Entregas.codAuxiliar = "" '
                            Ls_DocCombustibleEliminado.Add(Entidad.Entregas)
                        End If
                        Ls_DocCombustible.Remove(Ls_DocCombustible.Where(Function(m) m.nroruc = ruc And _
                                                     m.TipoDoc = tdoc And _
                                                     m.NumDoc = ndoc).FirstOrDefault)
                    End If
                Next
                'DocumentosAsociados()
                result = True
            End If

        End If

        Return result
    End Function

    Function validarDetalleRecibo(ByVal fila As Int32) As Boolean
        Dim result As Boolean = True
        Dim _xfila As Int32
        _xfila = Me.gridDetalle.Rows(fila).Cells("nfila").Value.ToString.Trim
        Dim _xidliquidacion As Int32
        _xidliquidacion = Me.gridDetalle.Rows(fila).Cells("idComp").Value.ToString.Trim

        Dim Lista As ETEntregas = Nothing

        If Ls_DetalleRecibo.Count > 0 Then
            For x As Int32 = 0 To Ls_DetalleRecibo.Count - 1
                Lista = Ls_DetalleRecibo.Where(Function(m) m.idComp = _xidliquidacion And _
                                                 m.fila = _xfila).FirstOrDefault
                If Not Lista Is Nothing Then Exit For
            Next
        End If

        If Not Lista Is Nothing Then
            If MsgBox("El recibo tiene importes asociados ... ¿Desea eliminar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                result = False
            Else

                For x As Int32 = 0 To Ls_DetalleRecibo.Count - 1
                    Lista = Ls_DetalleRecibo.Where(Function(m) m.idComp = _xidliquidacion And _
                                                 m.fila = _xfila).FirstOrDefault
                    If Not Lista Is Nothing Then
                        Dim id As Int32 = Lista.idComp
                        If id <> 0 Then
                            Entidad.Entregas = New ETEntregas
                            Entidad.Entregas.NumSolicitud = nroSolicitud
                            Entidad.Entregas.idComp = id
                            Entidad.Entregas.TipoOperacion = 3
                            Entidad.Entregas.ID = Lista.ID
                            Entidad.Entregas.Concepto = Lista.Concepto
                            Entidad.Entregas.Descripcion = Lista.Descripcion
                            Entidad.Entregas.fila = Lista.fila
                            Entidad.Entregas.Descripcion = Lista.Descripcion
                            Entidad.Entregas.montoTotal = Lista.montoTotal
                            'Entidad.Entregas.codAuxiliar = "" '
                            Ls_DetalleReciboEliminado.Add(Entidad.Entregas)
                        End If
                        Ls_DetalleRecibo.Remove(Ls_DetalleRecibo.Where(Function(m) m.idComp = _xidliquidacion And _
                                                 m.fila = _xfila).FirstOrDefault)
                    End If
                Next
                result = True
            End If
        End If

        Return result
    End Function

    Private Sub txtcodCantera_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodCantera.KeyPress
        Try
            If flgaprobada = 1 Then Return
            If e.KeyChar = ChrW(Keys.Escape) Then Return
            If e.KeyChar = ChrW(Keys.Delete) Then Return
            If e.KeyChar = ChrW(Keys.Return) Then Return
            If e.KeyChar = ChrW(Keys.Back) Then Return
            If Gpb1.Enabled = False Then Return

            Dim dtFlgPermiso As Boolean
            With Entidad.Usuario
                .Login = User_Sistema
            End With
            dtFlgPermiso = Negocio.Usuario.PermisoEdicionLiquidacion(Entidad.Usuario)
            '@01 Add fin

            If dtFlgPermiso = True Then
                'If User_Sistema.ToUpper = "RPRINCIPE" Or User_Sistema.ToUpper = "COTOYA" Or User_Sistema.ToUpper = "SA" Or User_Sistema.ToUpper = "YRIS" Or User_Sistema.ToUpper = "MAMPUERO" Or User_Sistema.ToUpper = "JPAREJA" Then
                Dim frm As New FrmCanteras
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.cadena = txtcodCantera.Text.ToString.Trim
                frm.tipo = 0
                frm.ShowDialog()
                If Not codCantera = "" Then
                    txtcodCantera.Text = codCantera
                    txtCantera.Text = Cantera
                    txtRegion.Text = ModVariable.Region
                    codCantera = ""
                    Cantera = ""
                End If

                If txtcodCantera.Text.ToString.Trim.Length = 5 Then
                    If Me.gridDetalle.Rows.Count > 0 Then
                        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                            If gridDetalle.Rows(i).Cells("codConcepto").Value.ToString.Trim <> "43" Then
                                gridDetalle.Rows(i).Cells("Cantera").Value = txtcodCantera.Text
                            End If
                        Next
                    End If
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtFechaRetorno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFechaRetorno.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        Dim fecha1 As Date = dtFechaSalida.Value
        Dim fecha2 As Date = dtFechaRetorno.Value
        If fecha2.CompareTo(fecha1) < 0 Then
            MsgBox("Fecha de retorno debe ser mayor a fecha de salida", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If
    End Sub

    Private Sub dtFechaRetorno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtFechaRetorno.LostFocus

    End Sub

    Private Sub dtFechaRetorno_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaRetorno.ValueChanged
        Try
            If esprimera = 0 Then Return
            If sender.readonly = True Then Return
            Dim fecha1 As Date = dtFechaSalida.Value
            Dim fecha2 As Date = dtFechaRetorno.Value
            If fecha2.CompareTo(fecha1) < 0 Then
                MsgBox("Fecha de retorno debe ser mayor a fecha de salida", MsgBoxStyle.Exclamation, msgComacsa)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtFechaSalida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFechaSalida.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        dtFechaRetorno.ReadOnly = False
        dtFechaRetorno.Focus()
    End Sub

    Private Sub dtFechaSalida_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtFechaSalida.ValueChanged
        Try
            If esprimera = 0 Then Return
            If sender.readonly = True Then Return
            dtFechaRetorno.ReadOnly = False
            dtFechaRetorno.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkActivarDev_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivarDev.CheckedChanged
        Try
            If chkActivarDev.Checked = True Then
                If Not validarDEvolucion() Then Return
                If Not ValidarCamposDetalle() Then chkActivarDev.Checked = False : Return
                'If CDbl(txtdevolucion.Text) <= 0 Then MsgBox("No existe devolución de dinero", MsgBoxStyle.Exclamation, msgComacsa) : chkActivarDev.Checked = False : Return
                txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
                CalcularTotalComprobantes()
                Entidad.Entregas = New ETEntregas
                Entidad.Entregas.fechaComp = Now.Date
                Entidad.Entregas.TipoDoc = String.Empty
                Entidad.Entregas.NumDoc = String.Empty
                Entidad.Entregas.nroruc = String.Empty
                Entidad.Entregas.Razon = String.Empty
                Entidad.Entregas.Descripcion = "DEVOLUCIÓN DE DINERO"
                Entidad.Entregas.codConcepto = "43"
                Entidad.Entregas.Serie = String.Empty
                Entidad.Entregas.Area = "GASTOS ADMINISTRATIVOS"
                Entidad.Entregas.codArea = "971"
                Entidad.Entregas.tipocambio = 1.0
                If gridDetalle.Rows.Count > 0 Then
                    Entidad.Entregas.codmotivoDetalle = gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("codMotivodetalle").Value.ToString.Trim
                    Entidad.Entregas.motivoDetalle = gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("motivoDetalle").Value.ToString.Trim
                Else
                    Entidad.Entregas.motivoDetalle = String.Empty
                End If
                Entidad.Entregas.TipoOperacion = 1
                Entidad.Entregas.montoTotalParcial = CDbl(txtdevolucion.Text)
                Entidad.Entregas.idComp = 0
                Ls_DetalleComp.Add(Entidad.Entregas)
                Call CargarUltraGrid(gridDetalle, Ls_DetalleComp)
                gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells(0).Activate()
                gridDetalle.PerformAction(LastCellInRow)
                If gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("motivoDetalle").Value.ToString.Trim = "" Then
                    gridDetalle.PerformAction(PrevCellByTab)
                End If
                comboMoneda()
                If lblmoneda.Text.ToString.Trim = "NUEVOS SOLES" Then
                    gridDetalle.ActiveRow.Cells("moneda").Value = "S/."
                Else
                    gridDetalle.ActiveRow.Cells("moneda").Value = "US$"
                End If
                If gridDetalle.Rows.Count = 1 Then
                    Entidad.Entregas.nfila = 0
                Else
                    Entidad.Entregas.nfila = gridDetalle.Rows(gridDetalle.Rows.Count - 2).Cells("nfila").Value + 1
                End If
                Entidad.Entregas.IDANEXO3 = 0
                Entidad.Entregas.ANEXO3 = ""
                Entidad.Entregas.PLACA_TERCERO = ""
                'gridDetalle.ActiveRow.Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("fechaComp").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("moneda").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("TipoDoc").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("Serie").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("NumDoc").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("nroruc").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("Razon").Activation = Activation.ActivateOnly
                gridDetalle.ActiveRow.Cells("montoTotalParcial").Activation = Activation.AllowEdit
            Else
                For i As Int32 = gridDetalle.Rows.Count - 1 To 0 Step -1
                    If gridDetalle.Rows(i).Cells("codConcepto").Value.ToString = "43" Then
                        Dim id As Int32 = gridDetalle.Rows(i).Cells("idComp").Value
                        If id <> 0 Then
                            Entidad.Entregas = New ETEntregas
                            Entidad.Entregas.NumSolicitud = nroSolicitud
                            Entidad.Entregas.idComp = gridDetalle.Rows(i).Cells("idComp").Value.ToString
                            Entidad.Entregas.TipoOperacion = 3
                            Entidad.Entregas.fechaComp = gridDetalle.Rows(i).Cells("fechaComp").Value.ToString
                            Entidad.Entregas.TipoDoc = gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString
                            Entidad.Entregas.NumDoc = gridDetalle.Rows(i).Cells("NumDoc").Value.ToString
                            Entidad.Entregas.nroruc = gridDetalle.Rows(i).Cells("nroruc").Value.ToString
                            Entidad.Entregas.Razon = gridDetalle.Rows(i).Cells("Razon").Value.ToString
                            Entidad.Entregas.Descripcion = gridDetalle.Rows(i).Cells("Descripcion").Value.ToString
                            Entidad.Entregas.codConcepto = gridDetalle.Rows(i).Cells("codConcepto").Value.ToString
                            Entidad.Entregas.montoTotalParcial = gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString
                            Entidad.Entregas.IDANEXO3 = 0
                            Entidad.Entregas.ANEXO3 = ""
                            Entidad.Entregas.codAuxiliar = "" '
                            Ls_EntregaEliminado.Add(Entidad.Entregas)
                        End If
                        Me.gridDetalle.Rows(i).Delete()
                    End If
                Next
            End If
            CalcularTotalComprobantes()
        Catch ex As Exception
        End Try
    End Sub
    Function validarDEvolucion() As Boolean
        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            If Ls_DetalleComp.Item(i).codConcepto.ToString.Trim = "43" Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub chkrepetir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkrepetir.CheckedChanged
        If chkrepetir.Checked = True Then
            If Me.gridDetalle.Rows.Count > 0 Then
                For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                    If gridDetalle.Rows(i).Cells("Cantera").Value.ToString.Trim = "" And gridDetalle.Rows(i).Cells("codConcepto").Value.ToString.Trim <> "43" Then
                        gridDetalle.Rows(i).Cells("Cantera").Value = txtcodCantera.Text
                    End If
                Next
            End If
        End If
    End Sub
    Sub Eliminar()
        Try
            If estado.Trim <> "DESEMBOLSADO" Then
                MessageBox.Show("La solicitud debe encontrarse en estado desembolsada", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
            If gridDetalle.Rows.Count = 0 Then MsgBox("No existen documentos a eliminar", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Entidad.Entregas.TipoOperacion = Ope
            Entidad.Entregas.NumSolicitud = txtnsolicitud.Text
            Entidad.Entregas.Usuario = User_Sistema
            Entidad.Entregas = Negocio.NEntregas.EliminaLiquidacion(Entidad.Entregas)
            If Entidad.Entregas.Validacion Then
                Me.TabMaestroEntregas.Tabs("Lista").Selected = True
                Call Inicio()
                Call LimpiarDatos()
                lblmoneda.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        If gridDetalle.ActiveRow Is Nothing Then
            MessageBox.Show("No tiene un comprobante seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If gridDetalle.ActiveRow.Cells("codConcepto").Value = "10" Or gridDetalle.ActiveRow.Cells("codConcepto").Value = "25" Then
            llenardias()
            'Exit Sub
        End If
        llenarComentario()
    End Sub

    Sub llenarComentario()
        Dim comentario As String
        Dim form As New Form()
        Dim label As New Label()
        Dim textBox As New TextBox()
        Dim buttonOk As New Button()
        Dim buttonCancel As New Button()

        If Me.gridDetalle.ActiveRow.Cells("TipoDoc").Value.Trim = "RH" And txtcodarea.Text.Trim = "42" Then
            Detalle_Recibos()
            gridDetalle.ActiveRow.Cells("montoTotalParcial").Activation = Activation.ActivateOnly
            Exit Sub
            'Else
            '    If Not validarDetalleRecibo(Me.gridDetalle.ActiveRow.Index) Then Return
            '    gridDetalle.ActiveRow.Cells("montoTotalParcial").Activation = Activation.AllowEdit
        End If

        form.Text = "INGRESE COMENTARIO"
        label.Text = "COMENTARIO"
        textBox.Text = Me.gridDetalle.ActiveRow.Cells("comentario").Value
        textBox.CharacterCasing = CharacterCasing.Upper
        buttonOk.Text = "OK"
        buttonCancel.Text = "Cancel"
        buttonOk.DialogResult = DialogResult.OK
        buttonCancel.DialogResult = DialogResult.Cancel
        textBox.Multiline = True
        label.SetBounds(9, 20, 372, 13)
        textBox.SetBounds(12, 36, 572, 102)
        buttonOk.SetBounds(428, 150, 75, 23)
        buttonCancel.SetBounds(509, 150, 75, 23)
        label.AutoSize = True
        textBox.Anchor = textBox.Anchor Or AnchorStyles.Right
        buttonOk.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        buttonCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right

        form.ClientSize = New Size(596, 187)
        form.Controls.AddRange(New Control() {label, textBox, buttonOk, buttonCancel})
        form.ClientSize = New Size(Math.Max(420, label.Right + 10), form.ClientSize.Height)
        form.FormBorderStyle = FormBorderStyle.FixedDialog
        form.StartPosition = FormStartPosition.CenterScreen
        form.MinimizeBox = False
        form.MaximizeBox = False
        form.AcceptButton = buttonOk
        form.CancelButton = buttonCancel
        Dim _dialogResult As DialogResult = form.ShowDialog()
        If _dialogResult = Windows.Forms.DialogResult.OK Then
            comentario = textBox.Text
            Me.gridDetalle.ActiveRow.Cells("comentario").Value = comentario
            gridDetalle.ActiveRow.ToolTipText = "COMENTARIO : " & gridDetalle.ActiveRow.Cells("comentario").Value
        End If
    End Sub

    Function validarReciboHonorario(ByVal fila As Int32, ByVal año As Integer, ByVal mes As Integer, ByVal ruc As String, ByVal numdoc As String, ByVal monto As Double, ByVal fecha As Date) As Boolean
        Try
            Me.gridDetalle.PerformAction(ExitEditMode)
            Me.gridDetalle.PerformAction(EnterEditMode)
            Me.gridDetalle.PerformAction(ExitEditMode)
            Dim flgretencion As Int32 = gridDetalle.Rows(fila).Cells("flgretencion").Value
            If flgretencion = 1 Then Return True
            'MsgBox(gridDetalle.Rows(fila).Cells("idcomp").Value)
            If gridDetalle.Rows(fila).Cells("codConcepto").Value.ToString = "43" Then Return True
            If gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString.Trim = "" Then MsgBox("Ingrese tipo de documento", MsgBoxStyle.Exclamation, msgComacsa) : Return False
            If gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString.Trim = "RH" Then
                Dim montoRecibo As Double = 0
                Dim montoRecibodia As Double = 0
                Dim montoComprobante As Double = gridDetalle.Rows(fila).Cells("montoTotalParcial").Value
                If gridDetalle.Rows.Count > 0 Then
                    For i As Int16 = 0 To gridDetalle.Rows.Count - 1
                        If gridDetalle.Rows(i).Cells("nroruc").Value = ruc And gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "RH" And gridDetalle.Rows(i).Cells("flgretencion").Value.ToString.Trim <> "1" Then
                            montoRecibo = montoRecibo + gridDetalle.Rows(i).Cells("montoTotalParcial").Value
                        End If
                        If gridDetalle.Rows(i).Cells("nroruc").Value = ruc And gridDetalle.Rows(i).Cells("fechaComp").Value = fecha And gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim = "RH" Then
                            montoRecibodia = montoRecibodia + gridDetalle.Rows(i).Cells("montoTotalParcial").Value
                        End If
                    Next
                End If

                'If gridDetalle.Rows(fila).Cells("idcomp").Value <> 0 Then monto = 0
                Entidad.Entregas = New ETEntregas
                Entidad.Entregas.año = año
                Entidad.Entregas.Mes = mes
                Entidad.Entregas.nroruc = ruc
                Entidad.Entregas.NumDoc = numdoc
                Entidad.Entregas.montoTotal = montoRecibo 'monto
                Entidad.Entregas.montoTotalParcial = montoRecibodia 'monto
                Entidad.Entregas.montoParcial = montoComprobante 'monto
                Entidad.Entregas.Fecha = CDate(fecha).ToString("dd/MM/yyyy")
                Entidad.MyLista = New ETMyLista

                If ruc.ToString.Trim = "" Then MsgBox("Ingrese Ruc del proveedor", MsgBoxStyle.Exclamation, msgComacsa) : Return False

                If ruc.ToString.Trim = "" Then MsgBox("Ingrese Ruc del proveedor", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                Dim Mensaje As String = ""
                Mensaje = Negocio.NEntregas.validarReciboHonorario(Entidad.Entregas)

                If Mensaje <> "SUSPENSION" Then
                    'If montoRecibodia > 1500 Then
                    '    If MsgBox("Error en la fila " & (fila + 1).ToString & ":" & vbCrLf & "EL PROVEEDOR " & _
                    '                            gridDetalle.Rows(fila).Cells("Razon").Value.ToString.Trim & " " & " SUPERO EL MONTO DE S/. 1,500 EN EL DIA " & fecha & vbCrLf & " ¿Desea realizar la retención del Documeto?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                    '        gridDetalle.Rows(fila).Cells("flgretencion").Value = 1
                    '        Return True
                    '    Else
                    '        Return False
                    '    End If
                    'End If
                    'If montoRecibo > 3208 Then
                    '    If MsgBox("Error en la fila " & (fila + 1).ToString & ":" & vbCrLf & "EL PROVEEDOR " & _
                    '                            gridDetalle.Rows(fila).Cells("Razon").Value.ToString.Trim & " " & " SUPERO EL MONTO DE S/. 3,208 EN EL MES " & vbCrLf & " ¿Desea realizar la retención del Documeto?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                    '        gridDetalle.Rows(fila).Cells("flgretencion").Value = 1
                    '        Return True
                    '    Else
                    '        Return False
                    '    End If
                    'End If
                    'add jcms 280524 C. Otoya
                    'If montoRecibo > 3755 Then
                    '    If MsgBox("Error en la fila " & (fila + 1).ToString & ":" & vbCrLf & "EL PROVEEDOR " & _
                    '                            gridDetalle.Rows(fila).Cells("Razon").Value.ToString.Trim & " " & " SUPERO EL MONTO DE S/. 3,755 EN EL MES " & vbCrLf & " ¿Desea realizar la retención del Documeto?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                    '        gridDetalle.Rows(fila).Cells("flgretencion").Value = 1
                    '        Return True
                    '    Else
                    '        Return False
                    '    End If
                    'End If


                End If

                If Mensaje = "OK" Or Mensaje = "SUSPENSION" Then
                    Return True
                Else
                    If MsgBox("Error en la fila " & (fila + 1).ToString & ":" & vbCrLf & "EL PROVEEDOR " & _
                           gridDetalle.Rows(fila).Cells("Razon").Value.ToString.Trim & " " & Mensaje.ToString & vbCrLf & " ¿Desea realizar la retención del Documeto?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                        gridDetalle.Rows(fila).Cells("flgretencion").Value = 1
                        Return True
                    Else
                        Return False
                    End If
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Function validarReciboHonorarioInterno(ByVal fila As Int32, ByVal año As Integer, ByVal mes As Integer, ByVal ruc As String, ByVal numdoc As String, ByVal monto As Double) As Boolean
        Try
            Me.gridDetalle.PerformAction(ExitEditMode)
            Me.gridDetalle.PerformAction(EnterEditMode)
            Me.gridDetalle.PerformAction(ExitEditMode)

            If gridDetalle.Rows(fila).Cells("codConcepto").Value.ToString = "43" Then Return True
            If gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString.Trim = "" Then MsgBox("Ingrese tipo de documento", MsgBoxStyle.Exclamation, msgComacsa) : Return False
            If gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString.Trim = "RH" Then

                Entidad.Entregas = New ETEntregas
                Entidad.Entregas.año = año
                Entidad.Entregas.Mes = mes
                Entidad.Entregas.nroruc = ruc
                Entidad.Entregas.NumDoc = numdoc
                Entidad.Entregas.montoTotal = monto

                Entidad.MyLista = New ETMyLista

            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Function validarIngresoDetalleRH(ByVal fila As Int32) As Boolean
        Dim result As Boolean = True
        Dim _xfila As Int32
        _xfila = fila 'Me.gridDetalle.ActiveRow.Index
        Dim _xidliquidacion As Int32
        _xidliquidacion = Me.gridDetalle.Rows(fila).Cells("idComp").Value.ToString.Trim

        'If _xidliquidacion <> 0 Then
        _xfila = Me.gridDetalle.Rows(fila).Cells("nfila").Value.ToString.Trim
        'End If
        Dim Lista As ETEntregas = Nothing

        If Ls_DetalleRecibo.Count > 0 Then
            For x As Int32 = 0 To Ls_DetalleRecibo.Count - 1
                Lista = Ls_DetalleRecibo.Where(Function(m) m.idComp = _xidliquidacion And _
                                                 m.fila = _xfila).FirstOrDefault
                If Not Lista Is Nothing Then Exit For
            Next
        End If


        If Lista Is Nothing Then
            'MsgBox("Ingrese planilla de movilidad", MsgBoxStyle.Exclamation, msgComacsa)
            result = False
        Else
            result = True
        End If
        Return result
    End Function

    Function validarIngresoRh(ByVal fila As Int32) As Boolean
        Dim result As Boolean = False
        Dim tipo_doc As String = Me.gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString
        Dim ruc As String = IIf(tipo_doc.Trim = "VL", "", Me.gridDetalle.Rows(fila).Cells("nroruc").Value.ToString)
        'Dim ruc As String = "" 'Me.gridDetalle.Rows(fila).Cells("nroruc").Value.ToString.Trim
        Dim tdoc As String = Me.gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString.Trim
        Dim ndoc As String = gridDetalle.Rows(fila).Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.Rows(fila).Cells("NumDoc").Value.ToString.PadLeft(16, "0")

        Dim ListaMovi As ETEntregas = Nothing

        If Ls_DetalleRecibo.Count > 0 Then
            For x As Int32 = 0 To Ls_DetalleRecibo.Count - 1
                ListaMovi = Ls_DetalleRecibo.Where(Function(m) m.nroruc.ToString.Trim = ruc.ToString.Trim And _
                                              m.TipoDoc.ToString.Trim = tdoc.ToString.Trim And _
                                              m.NumDoc.ToString.Trim = ndoc.ToString.Trim).FirstOrDefault
                If Not ListaMovi Is Nothing Then Exit For
            Next
        End If

        If ListaMovi Is Nothing Then
            'MsgBox("Ingrese planilla de movilidad", MsgBoxStyle.Exclamation, msgComacsa)
            result = False
        Else
            result = True
        End If
        Return result
    End Function

    Function validarIngresoMovilidad(ByVal fila As Int32) As Boolean
        Dim result As Boolean = False
        Dim tipo_doc As String = Me.gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString
        Dim ruc As String = IIf(tipo_doc.Trim = "VL", "", Me.gridDetalle.Rows(fila).Cells("nroruc").Value.ToString)
        'Dim ruc As String = "" 'Me.gridDetalle.Rows(fila).Cells("nroruc").Value.ToString.Trim
        Dim tdoc As String = Me.gridDetalle.Rows(fila).Cells("TipoDoc").Value.ToString.Trim
        Dim ndoc As String = gridDetalle.Rows(fila).Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.Rows(fila).Cells("NumDoc").Value.ToString.PadLeft(16, "0")

        Dim ListaMovi As ETEntregas = Nothing

        If Ls_DocMovilidad.Count > 0 Then
            For x As Int32 = 0 To Ls_DocMovilidad.Count - 1
                ListaMovi = Ls_DocMovilidad.Where(Function(m) m.nroruc.ToString.Trim = ruc.ToString.Trim And _
                                              m.TipoDoc.ToString.Trim = tdoc.ToString.Trim And _
                                              m.NumDoc.ToString.Trim = ndoc.ToString.Trim).FirstOrDefault
                If Not ListaMovi Is Nothing Then Exit For
            Next
        End If

        If ListaMovi Is Nothing Then
            'MsgBox("Ingrese planilla de movilidad", MsgBoxStyle.Exclamation, msgComacsa)
            result = False
        Else
            result = True
        End If
        Return result
    End Function

    Sub llenardias()
        If gridDetalle.ActiveRow Is Nothing Then
            MessageBox.Show("No tiene un comprobante seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim frm As New frmCantDiasPersonas
        frm.txtdias.Text = gridDetalle.ActiveRow.Cells("dias").Value
        frm.txtpersonas.Text = gridDetalle.ActiveRow.Cells("personas").Value
        frm.txtdias.Focus()
        Dim _dialogResult As DialogResult = frm.ShowDialog()
        If frm.boton = "OK" Then
            If Me.gridDetalle.ActiveRow.Cells("comentario").Value.ToString.Trim = "" Then
                Me.gridDetalle.ActiveRow.Cells("comentario").Value = frm.comentario
            End If
            gridDetalle.ActiveRow.Cells("dias").Value = frm.txtdias.Text
            gridDetalle.ActiveRow.Cells("personas").Value = frm.txtpersonas.Text
        End If
    End Sub

    Private Sub gridViaticos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridViaticos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Fecha" OrElse uColumn.Key = "gastoAlimentacion" OrElse uColumn.Key = "gastoHospedaje" OrElse uColumn.Key = "gastoMovilidad") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        If Not gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim = "RH" Then
            MsgBox("El tipo de documento es incorrecto para esta opción", MsgBoxStyle.Information, msgComacsa)
            Exit Sub
        End If
        If MsgBox("¿Desea realizar la retención del Documeto?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
            gridDetalle.ActiveRow.Cells("flgretencion").Value = 1
        End If
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        If Not gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim = "RH" Then
            MsgBox("El tipo de documento es incorrecto para esta opción", MsgBoxStyle.Information, msgComacsa)
            Exit Sub
        End If
        If gridDetalle.ActiveRow.Cells("flgretencion").Value = 0 Then
            MsgBox("El documento no posee retención", MsgBoxStyle.Information, msgComacsa)
            Exit Sub
        End If
        If MsgBox("¿Desea eliminar la retención del Documeto?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
            Dim dtRetencion As New DataTable
            Entidad.Entregas = New ETEntregas
            Negocio.NEntregas = New NGEntregas
            Entidad.Entregas.idComp = gridDetalle.ActiveRow.Cells("idComp").Value
            'Entidad.Entregas.nroruc = gridDetalle.ActiveRow.Cells("nroruc").Value
            'Entidad.Entregas.montoTotal = gridDetalle.ActiveRow.Cells("montoTotal").Value
            'Entidad.Entregas.NumDoc = gridDetalle.ActiveRow.Cells("NumDoc").Value
            'Entidad.Entregas.Razon = gridDetalle.ActiveRow.Cells("Razon").Value
            Entidad.Entregas.Usuario = User_Sistema
            dtRetencion = Negocio.NEntregas.elimina_retencion(Entidad.Entregas)
            If dtRetencion.Rows.Count > 0 Then
                If dtRetencion.Rows(0)(0) = "OK" Then
                    MsgBox("La retención del documento fue eliminada", MsgBoxStyle.Information, msgComacsa)
                    gridDetalle.ActiveRow.Cells("flgretencion").Value = 0
                End If
            End If
        End If
    End Sub

    Private Sub txtcodCantera_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodCantera.ValueChanged

    End Sub

    Private Sub TabMaestroEntregas_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabMaestroEntregas.SelectedTabChanged

    End Sub
End Class