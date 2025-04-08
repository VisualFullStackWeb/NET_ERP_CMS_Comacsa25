Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmDocumentosReemplazar
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
    Dim idEstado As Int32
    Dim moneda As String = String.Empty
    Dim estado As String = String.Empty
    Dim auxi As String = String.Empty
    Dim flgauxi As Int32 = 0
    Dim tipotabla As Int32 = 0
    Dim estadoContable As Int32 = 0

    Public fechaSalida As Date
    Public fechaRetorno As Date
    Dim numDoc As String = String.Empty

#End Region
    Private Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
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

        Entidad.Entregas.Area = String.Empty 'txtArea.Value.ToString.Trim
        Entidad.Entregas.codArea = String.Empty 'txtcodarea.Value.ToString.Trim

        Entidad.Entregas.tipocambio = 1.0
        If gridDetalle.Rows.Count > 0 Then
            Entidad.Entregas.codmotivoDetalle = gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("codMotivodetalle").Value.ToString.Trim
            Entidad.Entregas.motivoDetalle = gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("motivoDetalle").Value.ToString.Trim
        Else
            Entidad.Entregas.motivoDetalle = String.Empty
        End If
        Entidad.Entregas.Cantera = txtcodCantera.Text
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
        'btnAgregar.Enabled = False
    End Sub
    Sub comboMoneda()
        Dim valueList = New ValueList()
        valueList.ValueListItems.Add("S", "S/.")
        valueList.ValueListItems.Add("D", "US$")
        gridDetalle.DisplayLayout.Bands(0).Columns("moneda").Style = ColumnStyle.DropDownList
        gridDetalle.DisplayLayout.Bands(0).Columns("moneda").ValueList = valueList
        gridDetalle.DisplayLayout.Bands(0).Columns("moneda").ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
    End Sub
    Function ValidarCamposDetalle()
        Me.gridDetalle.PerformAction(ExitEditMode)
        Me.gridDetalle.PerformAction(EnterEditMode)
        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
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
            If lblmoneda.Text.Trim = "NUEVOS SOLES" Then
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
    End Sub

    Private Sub FrmDocumentosReemplazar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Ls_DetalleComp = New List(Of ETEntregas)
        btnAgregar_Click(Nothing, Nothing)
    End Sub

    Private Sub gridDetalle_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridDetalle.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridDetalle Then Return
        e.DisplayPromptMsg = Boolean.FalseString
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

    Private Sub gridDetalle_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridDetalle.DoubleClickRow
        Try
            If gridDetalle.ActiveRow.Cells("montoTotalParcial").Value.ToString <= 0 Then
                MsgBox("Ingrese importe", MsgBoxStyle.Exclamation, msgComacsa) : Return
            End If
            If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "00" Then
                numDoc = gridDetalle.ActiveRow.Cells("Serie").Value.ToString & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString
                If verificaDocumentos(gridDetalle.ActiveRow.Cells("nroruc").Value.ToString, gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString, numDoc) Then
                    MsgBox("El documento se encuentra en el registro de compras", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
                If Ls_DocAsociado Is Nothing Then
                    Ls_DocAsociado = New List(Of ETEntregas)
                End If
                If Ls_DocAsociado.Count > 0 Then
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
                    frm.codArea = gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim
                    frm.flgcompra = gridDetalle.ActiveRow.Cells("flgcompra").Value.ToString.Trim
                    frm.cadena = gridDetalle.ActiveRow.Cells("Auxiliar").Value.ToString.Trim
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
                End If

            End If
            If gridDetalle.ActiveRow.Cells("Descripcion").Value.ToString.Trim = "MOVILIDAD" Then
                DocumentosMovilidad()
            End If
        Catch ex As Exception

        End Try
    End Sub

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

    Private Sub gridDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDetalle.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "fechaComp" OrElse uColumn.Key = "TipoDoc" OrElse uColumn.Key = "NumDoc" OrElse uColumn.Key = "Auxiliar" OrElse uColumn.Key = "moneda" OrElse uColumn.Key = "tipocambio" OrElse _
                    uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Razon" OrElse uColumn.Key = "nroruc" OrElse uColumn.Key = "Serie" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "Area" OrElse uColumn.Key = "Cantera") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub gridDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDetalle.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridDetalle) Then Return
            With sender
                Select Case e.KeyValue
                    Case 45
                        btnAgregar_Click(Nothing, Nothing)
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
                        NecesitaAuxiliar()
                        .PerformAction(ExitEditMode)
                        If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "nroruc" Then
                            If Not ValidarDocumentoRepetido() Then gridDetalle.ActiveRow.Cells("nroruc").Value = "" : gridDetalle.ActiveRow.Cells("razon").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                            ObtenerRazon()
                        End If
                        If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Serie" Then
                            If Not ValidarDocumentoRepetido() Then gridDetalle.ActiveRow.Cells("Serie").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                            gridDetalle.ActiveRow.Cells("Serie").Value = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.Trim.PadLeft(4, "0")
                        End If
                        If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "NumDoc" Then
                            If Not ValidarDocumentoRepetido() Then gridDetalle.ActiveRow.Cells("NumDoc").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                            gridDetalle.ActiveRow.Cells("NumDoc").Value = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.Trim.PadLeft(16, "0")
                        End If

                        If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "montoTotalParcial" Then
                            If gridDetalle.ActiveRow.Cells("montoTotalParcial").Value <= 0 Then
                                MsgBox("Ingrese importe válido")
                                .PerformAction(PrevCellByTab)
                            Else
                                CalcularTotalComprobantes()
                                If gridDetalle.ActiveRow.Cells("Descripcion").Value.ToString.Trim = "MOVILIDAD" Then
                                    DocumentosMovilidad()
                                End If
                                If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "00" Then
                                    DocumentosAsociados()
                                Else
                                    'PREGUNTAMOS SI NECESITA AUXILIAR
                                    If flgauxi = 1 Then
                                        Dim frm As New FrmAuxiliar
                                        frm.auxi = auxi
                                        frm.cadena = gridDetalle.ActiveRow.Cells("Auxiliar").Value.ToString
                                        frm.ShowDialog()
                                        If codAuxiliar.Trim = "" Then gridDetalle.PerformAction(PrevCellByTab) : Return
                                        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
                                        gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Auxiliar").Value = Auxiliar
                                        codAuxiliar = ""
                                        Auxiliar = ""
                                        gridDetalle.PerformAction(NextCellByTab)
                                        e.Handled = True
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        CalcularTotalComprobantes()
                        'btnAgregar.Enabled = True
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub DocumentosAsociados()
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
        frm.txtruc.Text = gridDetalle.ActiveRow.Cells("nroruc").Value.ToString
        frm.txtrazon.Text = gridDetalle.ActiveRow.Cells("Razon").Value.ToString
        frm.txttd.Text = gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString
        frm.txtserie.Text = gridDetalle.ActiveRow.Cells("Serie").Value.ToString
        frm.txtnumero.Text = gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString
        frm.codArea = gridDetalle.ActiveRow.Cells("codArea").Value.ToString
        frm.flgcompra = gridDetalle.ActiveRow.Cells("flgcompra").Value.ToString
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
        numDoc = gridDetalle.ActiveRow.Cells("Serie").Value.ToString.PadLeft(4, "0") & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString.PadLeft(16, "0") '("0000000000000000")
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
        frm.fechaSalida = fechaSalida
        frm.fechaRetorno = fechaRetorno
        frm.ShowDialog()
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
            ''mostrar los datos
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

    Function ValidarDocumentoOriginal() As Boolean
        Try
            If gridDetalle.Rows.Count > 0 Then
                Me.gridDetalle.PerformAction(ExitEditMode)
                If Me.gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString.Trim = "VL" Then Return True
                Dim tipdoc As String = txttd.Text.ToString.Trim
                Dim serdoc As String = txtserie.Text.ToString.Trim
                Dim numdoc As String = txtnumero.Text.ToString.Trim
                Dim nroruc As String = txtruc.Text.ToString.Trim
                Dim cadenavalidar = tipdoc + serdoc + numdoc + nroruc
                Dim cadenacomparar As String = String.Empty
                For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                    cadenacomparar = Me.gridDetalle.Rows(i).Cells("TipoDoc").Value.ToString.Trim + Me.gridDetalle.Rows(i).Cells("Serie").Value.ToString.PadLeft(4, "0") + Me.gridDetalle.Rows(i).Cells("NumDoc").Value.ToString.PadLeft(16, "0") + Me.gridDetalle.Rows(i).Cells("nroruc").Value.ToString.Trim
                    If cadenavalidar = cadenacomparar Then
                        MsgBox("No puede registrar un documento igual al original", MsgBoxStyle.Exclamation, msgComacsa)
                        Me.gridDetalle.PerformAction(EnterEditMode)
                        Return False
                    End If
                Next
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function

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
        If gridDetalle.ActiveRow.Cells("codArea").Value.ToString.Trim = "912" Then
            flgauxi = 1
            auxi = "AC"
        End If
        gridDetalle.ActiveRow.Cells("flgauxi").Value = flgauxi
    End Sub
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
        If Ls_DocAsociado.Count > 0 Then
            For x As Int32 = 0 To Ls_DocAsociado.Count - 1
                Lista = Ls_DocAsociado.Where(Function(m) m.nroruc.ToString.Trim = ruc And _
                                              m.TipoDoc = tdoc.ToString.Trim And _
                                              m.NumDoc = ndoc).FirstOrDefault
                If Not Lista Is Nothing Then Exit For
            Next
        End If

        If Not Lista Is Nothing Then

            If MsgBox("El documento tiene importes asociados ...¿Desea eliminar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
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
                'DocumentosAsociados()
                result = True
            End If

        End If

        Return result
    End Function

    Private Sub gridDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridDetalle.KeyPress
        Try
            If e.KeyChar = "+" Then
                btnAgregar_Click(Nothing, Nothing)
                e.Handled = True
                Return
            End If
            If e.KeyChar = "-" Then
                btnQuitar_Click(Nothing, Nothing)
                e.Handled = True
                Return
            End If
            If e.KeyChar = ChrW(Keys.Escape) Then Return
            If e.KeyChar = ChrW(Keys.Delete) Then Return
            If e.KeyChar = ChrW(Keys.Return) Then Return
            If e.KeyChar = ChrW(Keys.Back) Then Return
            If e.KeyChar.ToString.Trim = "" Then Return

            numDoc = gridDetalle.ActiveRow.Cells("Serie").Value.ToString & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString
            If verificaDocumentos(gridDetalle.ActiveRow.Cells("nroruc").Value.ToString, gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString, numDoc) Then
                MsgBox("El documento se encuentra en el registro de compras", MsgBoxStyle.Exclamation, msgComacsa)
                e.Handled = True
                Exit Sub
            End If

            If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString = "43" Then e.Handled = True : Return
            If Not gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Descripcion" OrElse _
             gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "motivoDetalle" Then
                If gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Descripcion").Value.ToString.Trim = "REINTEGRO" Then
                    e.Handled = True
                    Exit Sub
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
                NecesitaAuxiliar()
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
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codTipoDoc").Value = codTipoDoc
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("TipoDoc").Value = TipoDoc
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("flgcompra").Value = flgcompra
                NecesitaAuxiliar()
                If Not ValidarDocumentoRepetido() Then
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
                NecesitaAuxiliar()
                codArea = ""
                Area = ""
                gridDetalle.PerformAction(NextCellByTab)
                e.Handled = True
                Exit Sub
            End If

            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Auxiliar" Then
                If gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim = "00" Then e.Handled = True : Return
                If e.KeyChar.ToString.Trim = "" Then Return
                NecesitaAuxiliar()
                If flgauxi = 1 Then
                    Dim frm As New FrmAuxiliar
                    frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                    frm.auxi = auxi
                    frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                    frm.cadena = gridDetalle.ActiveRow.Cells("Auxiliar").Value.ToString
                    frm.ShowDialog()
                    If codAuxiliar.Trim = "" Then e.Handled = True : Return
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
                    gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Auxiliar").Value = Auxiliar
                    codAuxiliar = ""
                    Auxiliar = ""
                    gridDetalle.PerformAction(NextCellByTab)
                    e.Handled = True
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
                If array.Count = 1 Then Exit Sub
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

    Private Sub btnQuitar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        If Not VerificarControl(5, gridDetalle) Then
            MessageBox.Show("No tiene comprobante para quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If gridDetalle.ActiveRow Is Nothing Then
            MessageBox.Show("No tiene un comprobante seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codConcepto").Value.ToString = "43" Then
            MessageBox.Show("No puede eliminar una devolución en efectivo", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        numDoc = gridDetalle.ActiveRow.Cells("Serie").Value.ToString & gridDetalle.ActiveRow.Cells("NumDoc").Value.ToString

        If verificaDocumentos(gridDetalle.ActiveRow.Cells("nroruc").Value.ToString, gridDetalle.ActiveRow.Cells("TipoDoc").Value.ToString, numDoc) Then
            MsgBox("El documento se encuentra en el registro de compras", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If Not validarImportesAsociados() Then Return
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
        If Me.gridDetalle.Rows.Count.ToString = 0 Then txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00") 'btnAgregar.Enabled = True :
        CalcularTotalComprobantes()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If gridDetalle.Rows.Count <= 0 Then
            MsgBox("Debe ingresar un documento", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        If Not ValidarCamposDetalle() Then Return
        If Not ValidarDocumentoOriginal() Then Return
        If txtmotivo.Text.ToString.Trim = "" Then
            MsgBox("Ingrese el motivo de reemplazo del documento", MsgBoxStyle.Exclamation, msgComacsa)
            txtmotivo.Focus()
            Exit Sub
        End If
        'If ComprobarMontos() Then
        Me.Close()
        'End If
    End Sub
    Function ComprobarMontos() As Boolean
        If txttotalliquidacion.Text.Trim = "" Then txttotalliquidacion.Text = 0
        If Not CDbl(txttotalliquidacion.Text) = CDbl(txtimporte.Text) Then
            MsgBox("El monto debe ser igual al original", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If
        Return True
    End Function

End Class