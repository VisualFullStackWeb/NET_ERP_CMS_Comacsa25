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

Public Class FrmRevisionDocumentos
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
        Entidad.MyLista = Negocio.NEntregas.Listar_LiquidacionesRevision(Entidad.Entregas)
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
    Private Sub FrmInsumosControlados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Inicio()
        Gpb1.Enabled = True
    End Sub
    Private Sub GridSolicitudes_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridSolicitudes.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot GridSolicitudes Then Return
        If e.Row.IsFilterRow Then Return
        LimpiarDatos()
        SubProceso_Entregas(e.Row)
        Gpb1.Enabled = True
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
        'chkCerrar.Visible = True
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
    End Sub
    Public Sub Nuevo()
       
    End Sub
    Sub modificar()
       
    End Sub

    Private Sub gridDetalle_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridDetalle.DoubleClickRow
        'Try
        '    If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString = "43" Then Return
        '    If gridDetalle.ActiveRow.Cells("montoTotalParcial").Value.ToString <= 0 Then
        '        MsgBox("Ingrese importe", MsgBoxStyle.Exclamation, msgComacsa) : Return
        '    End If
        '    If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "00" Then
        '        NecesitaAuxiliar()
        '        If Ls_DocAsociado Is Nothing Then
        '            Ls_DocAsociado = New List(Of ETEntregas)
        '        End If
        '        If Ls_DocAsociadoEliminado Is Nothing Then
        '            Ls_DocAsociadoEliminado = New List(Of ETEntregas)
        '        End If
        '        Dim numDoc As String = String.Empty
        '        numDoc = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.PadLeft(16, "0") '("0000000000000000")
        '        Dim frm As FrmFacturasAsociadas
        '        frm = New FrmFacturasAsociadas
        '        frm.txtruc.Text = gridDetalle.ActiveRow.Cells("nroruc").Value.ToString
        '        frm.txtrazon.Text = gridDetalle.ActiveRow.Cells("Razon").Value.ToString
        '        frm.txttd.Text = gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString
        '        frm.txtserie.Text = gridDetalle.ActiveRow.Cells("Serie").Value.ToString
        '        frm.txtnumero.Text = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString
        '        frm.codArea = gridDetalle.ActiveRow.Cells("codArea").Value.ToString
        '        frm.flgcompra = gridDetalle.ActiveRow.Cells("flgcompra").Value.ToString
        '        frm.cadena = gridDetalle.ActiveRow.Cells("Auxiliar").Value.ToString
        '        Dim monDocumento As String = String.Empty
        '        monDocumento = gridDetalle.ActiveRow.Cells("moneda").Value.ToString.Trim
        '        frm.txtimporte.Text = CDbl(gridDetalle.ActiveRow.Cells("montoTotal").Value).ToString("#####0.00")
        '        frm.txtcambio.Text = CDbl(gridDetalle.ActiveRow.Cells("tipocambio").Value).ToString("#####0.00")
        '        If monDocumento = "S/." Or monDocumento = "NUEVOS SOLES" Then
        '            frm.txtmoneda.Text = "NUEVOS SOLES"
        '        Else
        '            frm.txtmoneda.Text = "DÓLARES"
        '        End If
        '        frm.mon = monDocumento
        '        frm.moneda = moneda
        '        frm.auxi = auxi
        '        frm.flgauxi = flgauxi
        '        frm.ShowDialog()
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Auxiliar").Value = Auxiliar
        '    End If
        '    If gridDetalle.ActiveRow.Cells("Descripcion").Value.ToString.Trim = "MOVILIDAD" Then
        '        DocumentosMovilidad()
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDetalle.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "fechaComp" OrElse uColumn.Key = "TipoDoc" OrElse uColumn.Key = "NumDoc" OrElse uColumn.Key = "Auxiliar" OrElse _
                    uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Razon" OrElse uColumn.Key = "nroruc" OrElse uColumn.Key = "Serie" OrElse uColumn.Key = "comentario" OrElse uColumn.Key = "Cantera") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
        If Not ValidarDocumentoRepetido() Then Return
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
        btnAgregar.Enabled = False
        gridDetalle.ActiveRow.ToolTipText = "COMENTARIO : " & gridDetalle.ActiveRow.Cells("comentario").Value
    End Sub

    Function ValidarDocumentoRepetido() As Boolean
        Try
            If gridDetalle.Rows.Count > 0 Then
                Me.gridDetalle.PerformAction(ExitEditMode)
                If Me.gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim = "VL" Then Return True
                Dim tipdoc As String = Me.gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim
                Dim serdoc As String = Me.gridDetalle.ActiveRow.Cells("Serie").Value.ToString.PadLeft(4, "0")
                Dim numdoc As String = Me.gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.PadLeft(16, "0")
                Dim nroruc As String = Me.gridDetalle.ActiveRow.Cells("nroruc").Value.ToString.Trim
                Dim cadenavalidar = tipdoc + serdoc + numdoc + nroruc
                Dim cadenacomparar As String = String.Empty
                For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                    cadenacomparar = Me.gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim + Me.gridDetalle.Rows(i).Cells("Serie").Value.ToString.PadLeft(4, "0") + Me.gridDetalle.Rows(i).Cells("NumDoc").Value.ToString.PadLeft(16, "0") + Me.gridDetalle.Rows(i).Cells("nroruc").Value.ToString.Trim
                    If Not i = Me.gridDetalle.ActiveRow.Index Then
                        If cadenavalidar = cadenacomparar Then
                            MsgBox("El documento ya fue registrado", MsgBoxStyle.Exclamation, msgComacsa)
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

    Function ValidarCamposDetalle() As Boolean
        Me.gridDetalle.PerformAction(ExitEditMode)
        Me.gridDetalle.PerformAction(EnterEditMode)
        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
         
            If gridDetalle.Rows(i).Cells("fechaComp").Value < dtFechaSalida.Value And gridDetalle.Rows(i).Cells("codConcepto").Value.ToString <> "43" Then
                MsgBox("No puede ingresar comprobantes fuera de fecha", MsgBoxStyle.Exclamation, msgComacsa) : Return False
            End If
            If gridDetalle.Rows(i).Cells("fechaComp").Value > dtFechaRetorno.Value And gridDetalle.Rows(i).Cells("codConcepto").Value.ToString <> "43" Then
                MsgBox("No puede ingresar comprobantes fuera de fecha", MsgBoxStyle.Exclamation, msgComacsa) : Return False
            End If
            If gridDetalle.Rows(i).Cells("codArea").Value.ToString = "" Then MsgBox("Ingrese área", MsgBoxStyle.Exclamation, msgComacsa) : Return False
            If Not gridDetalle.Rows(i).Cells("Descripcion").Value.ToString.Trim = "REINTEGRO" Then
                If Not gridDetalle.Rows(i).Cells("codConcepto").Value.ToString = "43" Then
                    Dim TipoDocumento = gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString
                    If gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString = "" Then MsgBox("Ingrese tipo documento", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    If Not gridDetalle.Rows(i).Cells("TipoDoc").Value = "VL" Then
                        If gridDetalle.Rows(i).Cells("Serie").Value.ToString = "" Then MsgBox("Ingrese serie documento", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        If gridDetalle.Rows(i).Cells("NumDoc").Value.ToString = "" Then MsgBox("Ingrese nro. documento", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        If gridDetalle.Rows(i).Cells("nroruc").Value.ToString = "" Then MsgBox("Ingrese nro. ruc", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                        If gridDetalle.Rows(i).Cells("razon").Value.ToString = "" Then MsgBox("Ingrese razón del proveedor", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    End If
                    If gridDetalle.Rows(i).Cells("nroruc").Value.ToString.Trim <> "" And gridDetalle.Rows(i).Cells("nroruc").Value.ToString.Length < 11 Then MsgBox("Debe ingresar 11 dígitos para el ruc", MsgBoxStyle.Exclamation, msgComacsa) : gridDetalle.PerformAction(PrevCellByTab) : Return False
                    If gridDetalle.Rows(i).Cells("Descripcion").Value.ToString = "" Then MsgBox("Ingrese descripción", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    If gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString <= 0 Then MsgBox("Ingrese importe", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    If gridDetalle.Rows(i).Cells("flgauxi").Value = 1 Then
                        If gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString = "" Then MsgBox("Ingrese auxiliar en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                    End If
                    If gridDetalle.Rows(i).Cells("Cantera").Value.ToString = "" Then MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                End If
            Else
                If gridDetalle.Rows(i).Cells("NumDoc").Value.ToString = "" Then MsgBox("Debe elegir un reintegro", MsgBoxStyle.Exclamation, msgComacsa) : Return False
            End If
        Next
        Return True
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

        If gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codConcepto").Value.ToString = "43" Then
            MessageBox.Show("No puede eliminar una devolución en efectivo", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim id As Int32 = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("idComp").Value
        If id <> 0 Then
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.TipoOperacion = 1
            Entidad.Entregas.NumSolicitud = nroSolicitud
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
                        'NecesitaAuxiliar()
                        '.PerformAction(ExitEditMode)
                        'If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "nroruc" Then
                        '    If Not ValidarDocumentoRepetido() Then gridDetalle.ActiveRow.Cells("nroruc").Value = "" : gridDetalle.ActiveRow.Cells("razon").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                        '    If gridDetalle.ActiveRow.Cells("TipoDoc").Value = "BL" Then
                        '        If gridDetalle.ActiveRow.Cells("nroruc").Value.ToString.Substring(0, 2) = "20" Then
                        '            MsgBox("El proveedor solo puede emitir facturas", MsgBoxStyle.Exclamation, msgComacsa)
                        '        End If
                        '    End If
                        '    ObtenerRazon()
                        'End If
                        'If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Serie" Then
                        '    If Not ValidarDocumentoRepetido() Then gridDetalle.ActiveRow.Cells("Serie").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                        '    gridDetalle.ActiveRow.Cells("Serie").Value = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.Trim.PadLeft(4, "0")
                        'End If
                        'If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "NumDoc" Then
                        '    If Not ValidarDocumentoRepetido() Then gridDetalle.ActiveRow.Cells("NumDoc").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                        '    gridDetalle.ActiveRow.Cells("NumDoc").Value = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim.PadLeft(16, "0")
                        'End If
                        'If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "montoTotalParcial" Then
                        '    If gridDetalle.ActiveRow.Cells("montoTotalParcial").Value <= 0 Then
                        '        MsgBox("Ingrese importe válido")
                        '        .PerformAction(PrevCellByTab)
                        '    Else
                        '        If gridDetalle.ActiveRow.Cells("Descripcion").Value.ToString.Trim = "MOVILIDAD" Then
                        '            DocumentosMovilidad()
                        '        End If
                        '        If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "00" Then
                        '            DocumentosAsociados()
                        '        Else
                        '            If flgauxi = 1 Then
                        '                Dim frm As New FrmAuxiliar
                        '                frm.auxi = auxi
                        '                frm.cadena = gridDetalle.ActiveRow.Cells("Auxiliar").Value.ToString
                        '                frm.ShowDialog()
                        '                If codAuxiliar.Trim = "" Then gridDetalle.PerformAction(PrevCellByTab) : Return
                        '                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
                        '                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Auxiliar").Value = Auxiliar
                        '                codAuxiliar = ""
                        '                Auxiliar = ""
                        '                gridDetalle.PerformAction(NextCellByTab)
                        '                e.Handled = True
                        '                If gridDetalle.ActiveRow.Cells("Descripcion").Value.ToString.Trim = "COMBUSTIBLE" Then
                        '                    DocumentosCombustible()
                        '                End If
                        '                Exit Sub
                        '            End If
                        '        End If

                        '    End If
                        'End If
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

    Sub DocumentosAsociados()
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
        frm.txtruc.Text = gridDetalle.ActiveRow.Cells("nroruc").Value.ToString
        frm.txtrazon.Text = gridDetalle.ActiveRow.Cells("Razon").Value.ToString
        frm.txttd.Text = gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString
        frm.txtserie.Text = gridDetalle.ActiveRow.Cells("Serie").Value.ToString
        frm.txtnumero.Text = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString

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
        Else
            lblEspera.Visible = True
            lblEspera.Text = "Buscando Datos en Sunat..."
            lblEspera.Refresh()
            lblEspera.Update()
            Cursor = Cursors.WaitCursor
            Dim dato_sunat As New metodos()
            Try
                dato_sunat.Buscar_por_DNI = False
                dato_sunat.Buscar_por_Ruc = True
                dato_sunat.Documento_a_Buscar = Entidad.Entregas.nroruc.ToString.Trim
                dato_sunat.Buscar_el_Documento()
            Catch ex As Exception
                Cursor = Cursors.Default
                MsgBox(ex.Message.ToString)
            End Try
            If dato_sunat.Dato_Encontrado = True Then
                With dato_sunat
                    gridDetalle.ActiveRow.Cells("razon").Value = .Nombre
                    gridDetalle.PerformAction(NextCellByTab)
                End With
            Else
                MsgBox("No se encontró ruc registrado en la sunat", MsgBoxStyle.Exclamation, msgComacsa)
                gridDetalle.ActiveRow.Cells("razon").Value = String.Empty
            End If
            dato_sunat = Nothing
            Cursor = Cursors.Default
            lblEspera.Visible = False
            lblEspera.Refresh()
            lblEspera.Update()
        End If
    End Sub

    Sub ImporteDocumento()
        Dim tcambio As Double = 0
        Dim importe As Double = 0
        Dim total As Double = 0
        tcambio = gridDetalle.ActiveRow.Cells("tipocambio").Value
        importe = gridDetalle.ActiveRow.Cells("montoTotalParcial").Value
        If lblmoneda.Text = "NUEVOS SOLES" Then
            If gridDetalle.ActiveRow.Cells("moneda").Value.ToString.Trim = "S" Then
                gridDetalle.ActiveRow.Cells("montoTotal").Value = importe
            Else
                gridDetalle.ActiveRow.Cells("montoTotal").Value = importe / tcambio
            End If
        Else
            If gridDetalle.ActiveRow.Cells("moneda").Value.ToString.Trim = "S" Then
                gridDetalle.ActiveRow.Cells("montoTotal").Value = importe * tcambio
            Else
                gridDetalle.ActiveRow.Cells("montoTotal").Value = importe * 1
            End If
        End If
    End Sub
    Private Sub gridDetalle_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles gridDetalle.DoubleClickCell
        'If Not e.Cell.Column.Key = "Descripcion" OrElse _
        '    e.Cell.Column.Key = "motivoDetalle" Then
        '    If gridDetalle.Rows(e.Cell.Row.Index).Cells("Descripcion").Value.ToString.Trim = "REINTEGRO" Then
        '        Exit Sub
        '    End If
        'End If
    End Sub
    Sub grabar()
      
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
        For i As Int32 = gridDetalle.Rows.Count - 1 To 0 Step -1
            gridDetalle.Rows(i).ToolTipText = "COMENTARIO : " & gridDetalle.Rows(i).Cells("comentario").Value
            If gridDetalle.Rows(i).Cells("codConcepto").Value.ToString = "43" Then
                gridDetalle.Rows(i).Activation = Activation.ActivateOnly
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
        'Try
        '    If e.KeyChar = "+" Then
        '        Btn3_Click(Nothing, Nothing)
        '        e.Handled = True
        '        Return
        '    End If
        '    If e.KeyChar = "-" Then
        '        Btn4_Click(Nothing, Nothing)
        '        e.Handled = True
        '        Return
        '    End If
        '    If e.KeyChar = ChrW(Keys.Escape) Then Return
        '    If e.KeyChar = ChrW(Keys.Delete) Then Return
        '    If e.KeyChar = ChrW(Keys.Return) Then Return
        '    If e.KeyChar = ChrW(Keys.Back) Then Return
        '    If e.KeyChar.ToString.Trim = "" Then Return
        '    If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString = "43" Then e.Handled = True : Return
        '    If Not gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Descripcion" OrElse _
        '     gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "motivoDetalle" Then
        '        If gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Descripcion").Value.ToString.Trim = "REINTEGRO" Then
        '            e.Handled = True
        '            Exit Sub
        '        End If
        '    End If
        '    If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Descripcion" Then
        '        If e.KeyChar.ToString.Trim = "" Then Return
        '        If Not validarImportesAsociados() Then e.Handled = True : Return
        '        If gridDetalle.ActiveRow.Cells("Area").Value.ToString = "" Then e.Handled = True : MsgBox("Ingrese Área", MsgBoxStyle.Exclamation, msgComacsa) : Return
        '        Dim frm As New FrmDatosComprobantes
        '        frm.cod_Area = gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim
        '        frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
        '        frm.ShowDialog()
        '        If codConcepto.Trim = "" Then e.Handled = True : Return
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codConcepto").Value = codConcepto
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Descripcion").Value = Concepto
        '        NecesitaAuxiliar()
        '        codConcepto = ""
        '        Concepto = ""
        '        If Concepto.ToString.Trim = "REINTEGRO" Then
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("nroruc").Value = ""
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Razon").Value = ""
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("TipoDoc").Value = ""
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Serie").Value = ""
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("NumDoc").Value = ""
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("montoTotalParcial").Value = 0
        '            CalcularTotalComprobantes()
        '        End If
        '        gridDetalle.PerformAction(NextCellByTab)
        '        e.Handled = True
        '        Exit Sub
        '    End If
        '    If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "nroruc" Then
        '        If Not validarImportesAsociados() Then e.Handled = True : Return
        '    End If
        '    If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "NumDoc" Then
        '        If Not validarImportesAsociados() Then e.Handled = True : Return
        '    End If
        '    If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Serie" Then
        '        If Not validarImportesAsociados() Then e.Handled = True : Return
        '    End If
        '    If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "TipoDoc" Then
        '        If e.KeyChar.ToString.Trim = "" Then Return
        '        If Not validarImportesAsociados() Then e.Handled = True : Return
        '        Dim frm As New FrmListadoDocumentos
        '        frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
        '        frm.ShowDialog()
        '        If codTipoDoc.Trim = "" Then e.Handled = True : Return
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codTipoDoc").Value = codTipoDoc
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("TipoDoc").Value = TipoDoc
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("flgcompra").Value = flgcompra
        '        NecesitaAuxiliar()
        '        If Not ValidarDocumentoRepetido() Then
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codTipoDoc").Value = ""
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("TipoDoc").Value = ""
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("flgcompra").Value = 0
        '            Return
        '        End If
        '        codTipoDoc = ""
        '        TipoDoc = ""
        '        gridDetalle.PerformAction(NextCellByTab)
        '        e.Handled = True
        '        Exit Sub
        '    End If
        '    If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "motivoDetalle" Then
        '        If e.KeyChar.ToString.Trim = "" Then Return
        '        Dim frm As New FrmMotivos
        '        frm.ShowDialog()
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codmotivoDetalle").Value = codMotivodetalle
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("motivoDetalle").Value = Motivodetalle
        '        gridDetalle.PerformAction(NextCellByTab)
        '        e.Handled = True
        '        Exit Sub
        '    End If
        '    If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Area" Then
        '        If e.KeyChar.ToString.Trim = "" Then Return
        '        Dim frm As New FrmAreas
        '        frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
        '        frm.ShowDialog()
        '        If codArea.Trim = "" Then e.Handled = True : Return
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codArea").Value = codArea
        '        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Area").Value = Area
        '        NecesitaAuxiliar()
        '        codArea = ""
        '        Area = ""
        '        gridDetalle.PerformAction(NextCellByTab)
        '        e.Handled = True
        '        Exit Sub
        '    End If
        '    If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Auxiliar" Then
        '        If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "00" Then e.Handled = True : Return
        '        If e.KeyChar.ToString.Trim = "" Then Return
        '        NecesitaAuxiliar()
        '        If flgauxi = 1 Then
        '            Dim frm As New FrmAuxiliar
        '            frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
        '            frm.auxi = auxi
        '            frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
        '            frm.cadena = gridDetalle.ActiveRow.Cells("Auxiliar").Value.ToString
        '            frm.ShowDialog()
        '            If codAuxiliar.Trim = "" Then e.Handled = True : Return
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Auxiliar").Value = Auxiliar
        '            codAuxiliar = ""
        '            Auxiliar = ""
        '            gridDetalle.PerformAction(NextCellByTab)
        '            e.Handled = True
        '            If gridDetalle.ActiveRow.Cells("Descripcion").Value.ToString.Trim = "COMBUSTIBLE" Then
        '                DocumentosCombustible()
        '            End If
        '            Exit Sub
        '        Else
        '            e.Handled = True : Return
        '        End If
        '    End If
        '    If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Cantera" Then
        '        If e.KeyChar.ToString.Trim = "" Then Return
        '        Dim frm As New FrmCanteras
        '        frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim

        '        Dim array As String() = txtcodCantera.Text.Split(",")
        '        'If array.Count = 1 Then Exit Sub
        '        frm.cadena = txtcodCantera.Text.ToString.Trim
        '        frm.cadenaDetalle = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Cantera").Value
        '        frm.tipo = 1

        '        frm.ShowDialog()
        '        If Not codCantera = "" Then
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codCantera").Value = codCantera
        '            gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Cantera").Value = codCantera
        '            codCantera = ""
        '            Cantera = ""
        '        End If
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Sub NecesitaAuxiliar()
        'If gridDetalle.ActiveRow.Cells("flgcompra").Value = 1 Then
        '    If gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim = "912" Then
        '        flgauxi = 1
        '        auxi = "AC"
        '    Else
        '        flgauxi = 0
        '        auxi = ""
        '    End If
        'Else
        FlagAuxiliar()
        'End If
        If gridDetalle.ActiveRow.Cells("codArea").Value = "912" Then
            flgauxi = 1
            auxi = "AC"
        End If
        gridDetalle.ActiveRow.Cells("flgauxi").Value = flgauxi
    End Sub

    Sub buscar()
        Try
            If flgaprobada = 1 Then Return
            If Gpb1.Enabled = False Then Return
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
    Sub FlagAuxiliar()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.codArea = gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim
        Rpt.codConcepto = gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim
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
                            Entidad.Entregas.fechaComp = ListaMovi.fechaComp
                            Entidad.Entregas.TipoDoc = ListaMovi.TipoDoc
                            Entidad.Entregas.NumDoc = ListaMovi.NumDoc
                            Entidad.Entregas.nroruc = ListaMovi.nroruc
                            Entidad.Entregas.Razon = ListaMovi.Razon
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

    Private Sub txtcodCantera_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodCantera.KeyPress
        Try
            If flgaprobada = 1 Then Return
            If e.KeyChar = ChrW(Keys.Escape) Then Return
            If e.KeyChar = ChrW(Keys.Delete) Then Return
            If e.KeyChar = ChrW(Keys.Return) Then Return
            If e.KeyChar = ChrW(Keys.Back) Then Return
            If Gpb1.Enabled = False Then Return

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
                gridDetalle.ActiveRow.Activation = Activation.ActivateOnly
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
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        If gridDetalle.ActiveRow Is Nothing Then
            MessageBox.Show("No tiene un comprobante seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim comentario As String
        Dim form As New Form()
        Dim label As New Label()
        Dim textBox As New TextBox()
        Dim buttonOk As New Button()
        Dim buttonCancel As New Button()

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
        textBox.SetBounds(12, 36, 372, 42)
        buttonOk.SetBounds(228, 90, 75, 23)
        buttonCancel.SetBounds(309, 90, 75, 23)
        label.AutoSize = True
        textBox.Anchor = textBox.Anchor Or AnchorStyles.Right
        buttonOk.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        buttonCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right

        form.ClientSize = New Size(396, 127)
        form.Controls.AddRange(New Control() {label, textBox, buttonOk, buttonCancel})
        form.ClientSize = New Size(Math.Max(300, label.Right + 10), form.ClientSize.Height)
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

    Private Sub gridDetalle_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles gridDetalle.InitializeRow
        Dim Comentario As String = e.Row.Cells("comentario").Value()
        If Not Comentario.Trim = "" Then e.Row.Appearance.BackColor = Color.Yellow
    End Sub
End Class