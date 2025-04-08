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
Public Class FrmFacturasAsociadas
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
    Private Ls_FacturaAsociada As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private columna As String
    Private filtroConcepto As String = String.Empty
    Dim esDevolucion As Int32 = 0
    Dim totalPend As Double = 0
    Dim numInterno As String = String.Empty
    Public moneda As String = String.Empty
    Dim tipmon As String = String.Empty
    Dim estado As String = String.Empty
    Public mon As String = String.Empty
    Dim numDoc As String = String.Empty
    Dim item As Int32 = 0
    Public auxi As String = String.Empty
    Public codArea As String = String.Empty
    Public flgcompra As String = String.Empty
    Public cadena As String = String.Empty
    Public flgauxi As Int32 = 0
#End Region
    Private Sub gridDetalle_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles gridDetalle.DoubleClickCell
        If e.Cell.Column.Key = "Descripcion" Then
            Dim frm As New FrmDatosComprobantes
            frm.ShowDialog()
            gridDetalle.Rows(e.Cell.Row.Index).Cells("codConcepto").Value = codConcepto
            gridDetalle.Rows(e.Cell.Row.Index).Cells("Descripcion").Value = Concepto
            If Concepto.ToString.Trim = "REINTEGRO" Then
                gridDetalle.Rows(e.Cell.Row.Index).Cells("nroruc").Value = ""
                gridDetalle.Rows(e.Cell.Row.Index).Cells("Razon").Value = ""
                gridDetalle.Rows(e.Cell.Row.Index).Cells("TipoDoc").Value = ""
                gridDetalle.Rows(e.Cell.Row.Index).Cells("Serie").Value = ""
                gridDetalle.Rows(e.Cell.Row.Index).Cells("NumDoc").Value = ""
                gridDetalle.Rows(e.Cell.Row.Index).Cells("montoTotalParcial").Value = 0
                CalcularTotalComprobantes()
            End If

            gridDetalle.PerformAction(NextCellByTab)
        End If
    End Sub

    Private Sub gridDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDetalle.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "Auxiliar" OrElse _
                    uColumn.Key = "Descripcion") Then
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
                        If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "montoTotalParcial" Then
                            If gridDetalle.ActiveRow.Cells("montoTotalParcial").Value <= 0 Then
                                MsgBox("Ingrese importe válido")
                                .PerformAction(PrevCellByTab)
                            Else
                                .PerformAction(NextCellByTab)
                            End If
                            CalcularTotalComprobantes()
                            If flgauxi = 1 Then
                                Dim frm As New FrmAuxiliar
                                frm.auxi = auxi
                                frm.cadena = gridDetalle.ActiveRow.Cells("Auxiliar").Value.ToString
                                frm.codconcepto = gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim
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
                            Dim monto As Double
                            monto = gridDetalle.ActiveRow.Cells("montoTotalParcial").Value
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
            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Descripcion" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                Dim frm As New FrmDatosComprobantes
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.cod_Area = codArea.ToString.Trim
                frm.ShowDialog()
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("codConcepto").Value = codConcepto
                gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Descripcion").Value = Concepto '"PRUEBA"
                gridDetalle.PerformAction(NextCellByTab)
                NecesitaAuxiliar()
                e.Handled = True
                Exit Sub
            End If

            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Auxiliar" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                NecesitaAuxiliar()
                If flgauxi = 1 Then
                    Dim frm As New FrmAuxiliar
                    frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                    frm.auxi = auxi
                    frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                    frm.codconcepto = gridDetalle.ActiveRow.Cells("codConcepto").Value.ToString.Trim
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
                Else
                    e.Handled = True : Return
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub NecesitaAuxiliar()
        'If flgcompra.Trim = "1" Then
        '    If codArea.ToString.Trim = "912" Then
        '        flgauxi = 1
        '        auxi = "AC"
        '    Else
        '        flgauxi = 0
        '        auxi = ""
        '    End If
        'Else
        FlagAuxiliar()
        'End If
        If codArea.ToString.Trim = "912" Then
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
        Rpt.codArea = codArea.ToString.Trim
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

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Not ValidarCamposDetalle() Then Return
        CalcularTotalComprobantes()
        numDoc = Me.txtserie.Text.ToString.Trim.PadLeft(4, "0") & Me.txtnumero.Text.ToString.Trim.PadLeft(16, "0") '("0000000000000000")
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.fechaComp = Now.Date
        Entidad.Entregas.TipoDoc = txttd.Text.ToString.Trim
        Entidad.Entregas.NumDoc = numDoc
        Entidad.Entregas.nroruc = txtruc.Text.ToString.Trim
        Entidad.Entregas.Razon = txtrazon.Text.ToString.Trim
        Entidad.Entregas.Descripcion = String.Empty
        Entidad.Entregas.codConcepto = String.Empty
        Entidad.Entregas.Serie = String.Empty
        Entidad.Entregas.codAuxiliar = String.Empty
        Entidad.Entregas.tipocambio = 1.0
        If gridDetalle.Rows.Count > 0 Then
            Entidad.Entregas.codmotivoDetalle = gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("codMotivodetalle").Value.ToString.Trim
            Entidad.Entregas.motivoDetalle = gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("motivoDetalle").Value.ToString.Trim
        Else
            Entidad.Entregas.motivoDetalle = String.Empty
        End If
        Entidad.Entregas.TipoOperacion = 1
        Entidad.Entregas.idComp = 0
        Ls_FacturaAsociada.Add(Entidad.Entregas)
        Call CargarUltraGrid(gridDetalle, Ls_FacturaAsociada)
        gridDetalle.Focus()
        gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells(0).Activate()
        gridDetalle.PerformAction(FirstCellInRow)
        'gridDetalle.PerformAction(NextCellByTab)
        btnAgregar.Enabled = False
    End Sub

    Function ValidarCamposDetalle()
        Me.gridDetalle.PerformAction(ExitEditMode)
        Me.gridDetalle.PerformAction(EnterEditMode)
        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            If gridDetalle.Rows(i).Cells("Descripcion").Value.ToString = "" Then MsgBox("Ingrese descripción", MsgBoxStyle.Exclamation, msgComacsa) : Return False
            If gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString <= 0 Then MsgBox("Ingrese importe", MsgBoxStyle.Exclamation, msgComacsa) : Return False
            If gridDetalle.Rows(i).Cells("flgauxi").Value = 1 Then
                If gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString = "" Then MsgBox("Ingrese auxiliar en la fila " & (i + 1).ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return False
            End If
        Next
        Return True
    End Function
    Private Sub FrmFacturasAsociadas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Ls_FacturaAsociada Is Nothing Then
            Ls_FacturaAsociada = New List(Of ETEntregas)
        End If
        If moneda = "NUEVOS SOLES" Then
            UltraLabel6.Text = "Importe  S/."
            UltraLabel5.Text = "IMPORTE TOTAL  S/."
        Else
            UltraLabel6.Text = "Importe  US$"
            UltraLabel5.Text = "IMPORTE TOTAL  US$"
        End If
        If Ls_DocAsociado.Count > 0 Then
            numDoc = Me.txtserie.Text.ToString.Trim.PadLeft(4, "0") & Me.txtnumero.Text.ToString.Trim.PadLeft(16, "0") '("0000000000000000")
            Dim tipomoneda As String = String.Empty
            For i As Int32 = 0 To Ls_DocAsociado.Count - 1
                item = i
                Dim Lista = Ls_DocAsociado.Where(Function(m) m.nroruc = Me.txtruc.Text.ToString.Trim And _
                  m.TipoDoc = Me.txttd.Text.ToString.Trim And _
                  m.NumDoc = numDoc And m.item = item).FirstOrDefault
                If Not Lista Is Nothing Then
                    Ls_FacturaAsociada.Add(Lista)
                End If
            Next
            Call CargarUltraGrid(gridDetalle, Ls_FacturaAsociada)
            gridDetalle.PerformAction(FirstCellInRow)
            'gridDetalle.PerformAction(NextCellByTab)
        End If
        If Ls_FacturaAsociada.Count = 0 Then
            btnAgregar_Click(Nothing, Nothing)
        End If
        CalcularTotalComprobantes()
    End Sub

    Sub CalcularTotalComprobantes()
        txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
        Dim tcambio As Double = 0
        Dim importe As Double = 0
        Dim total As Double = 0

        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            tcambio = gridDetalle.Rows(i).Cells("tipocambio").Value
            importe = gridDetalle.Rows(i).Cells("montoTotalParcial").Value
            'mon = gridDetalle.Rows(i).Cells("moneda").Value.ToString.Trim
            If moneda = "NUEVOS SOLES" Then
                If mon = "S" Or mon = "S/." Then
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe
                Else
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe * CDbl(txtcambio.Text.Trim)
                End If
            Else
                If mon = "S" Or mon = "S/." Then
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe / CDbl(txtcambio.Text.Trim)
                Else
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe
                End If
            End If
            txttotalliquidacion.Text = CDbl(CDbl(txttotalliquidacion.Text) + CDbl(gridDetalle.Rows(i).Cells("montoTotal").Value.ToString)).ToString("#####0.00")
        Next

        'ImporteDocumento()
    End Sub

    Sub SeteoEntidad()
        'Me.gridDetalle.PerformAction(ExitEditMode)
        Dim tipomoneda As String = String.Empty
        numDoc = Me.txtserie.Text.ToString.Trim.PadLeft(4, "0") & Me.txtnumero.Text.ToString.Trim.PadLeft(16, "0") '("0000000000000000")

        For x As Int32 = 0 To Ls_DocAsociado.Count - 1
            Dim Lista = Ls_DocAsociado.Where(Function(m) m.nroruc = Me.txtruc.Text.ToString.Trim And _
                                          m.TipoDoc = Me.txttd.Text.ToString.Trim And _
                                          m.NumDoc = numDoc).FirstOrDefault

            If Not Lista Is Nothing Then Ls_DocAsociado.Remove(Ls_DocAsociado.Where(Function(m) m.nroruc = Me.txtruc.Text.ToString.Trim And _
                                                 m.TipoDoc = Me.txttd.Text.ToString.Trim And _
                                                 m.NumDoc = numDoc).FirstOrDefault)
        Next

        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            item = i
            tipomoneda = mon 'gridDetalle.Rows(i).Cells("moneda").Value.ToString.Trim
            If tipomoneda = "S/." Then tipomoneda = "S"
            If tipomoneda = "US$" Then tipomoneda = "D"
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.TipoOperacion = 1
            Entidad.Entregas.NumSolicitud = nroSolicitud
            Entidad.Entregas.fechaComp = Now.Date 'gridDetalle.Rows(i).Cells("fechaComp").Value.ToString
            Entidad.Entregas.TipoDoc = Me.txttd.Text.ToString.Trim
            Entidad.Entregas.NumDoc = numDoc 'Me.txtnumero.Text.ToString.Trim
            Entidad.Entregas.nroruc = Me.txtruc.Text.ToString.Trim
            Entidad.Entregas.Razon = Me.txtrazon.Text.ToString.Trim
            Entidad.Entregas.codmotivoDetalle = ""
            Entidad.Entregas.motivoDetalle = ""
            Entidad.Entregas.Descripcion = gridDetalle.Rows(i).Cells("Descripcion").Value.ToString
            Entidad.Entregas.codConcepto = gridDetalle.Rows(i).Cells("codConcepto").Value.ToString
            Entidad.Entregas.montoTotalParcial = gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString
            Entidad.Entregas.idComp = gridDetalle.Rows(i).Cells("idComp").Value.ToString
            Entidad.Entregas.TipoOperacion = gridDetalle.Rows(i).Cells("TipoOperacion").Value.ToString
            Entidad.Entregas.codAuxiliar = gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString
            Entidad.Entregas.Auxiliar = gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString
            Entidad.Entregas.moneda = tipomoneda
            Entidad.Entregas.tipocambio = gridDetalle.Rows(i).Cells("tipocambio").Value.ToString
            Entidad.Entregas.montoTotal = gridDetalle.Rows(i).Cells("montoTotal").Value.ToString
            Entidad.Entregas.comentario = gridDetalle.Rows(i).Cells("comentario").Value.ToString
            Entidad.Entregas.dias = gridDetalle.Rows(i).Cells("dias").Value.ToString
            Entidad.Entregas.personas = gridDetalle.Rows(i).Cells("personas").Value.ToString
            Entidad.Entregas.item = item
            Ls_DocAsociado.Add(Entidad.Entregas)
        Next
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        If Not VerificarControl(5, gridDetalle) Then
            MessageBox.Show("No tiene Comprobante para Quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If gridDetalle.ActiveRow Is Nothing Then
            MessageBox.Show("No tiene una Comprobante Seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim id As Int32 = gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("idComp").Value
        If id <> 0 Then
            Entidad.Entregas = New ETEntregas
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
            Ls_DocAsociadoEliminado.Add(Entidad.Entregas)
        End If
        gridDetalle.ActiveRow.Delete()
        If Me.gridDetalle.Rows.Count.ToString = 0 Then btnAgregar.Enabled = True : txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
        CalcularTotalComprobantes()
    End Sub

    Private Sub gridDetalle_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridDetalle.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridDetalle Then Return
        e.DisplayPromptMsg = Boolean.FalseString
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not ValidarCamposDetalle() Then Return
        CalcularTotalComprobantes()
        Dim importedoc As Double = CDbl(txtimporte.Text)
        Dim importeingresado As Double = CDbl(txttotalliquidacion.Text)
        If Not importedoc = importeingresado Then
            MsgBox("El importe total debe ser igual al importe del documento original", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        Else
            SeteoEntidad()
            seteoAuxiliar()
            Me.Close()
        End If
    End Sub
    Sub seteoAuxiliar()
        Me.gridDetalle.PerformAction(ExitEditMode)
        Me.gridDetalle.PerformAction(EnterEditMode)
        Dim cont As Int32 = 0
        Dim cadAuxi As String = String.Empty
        Dim cadcodAuxi As String = String.Empty
        For i As Integer = 0 To Me.gridDetalle.Rows.Count - 1
            If Not Me.gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString.Trim = "" Then
                cont += 1
                cadAuxi = cadAuxi + Me.gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString.Trim
                cadcodAuxi = cadcodAuxi + Me.gridDetalle.Rows(i).Cells("codAuxiliar").Value.ToString.Trim
                cadAuxi = cadAuxi + ","
                cadcodAuxi = cadcodAuxi + ","
            End If
        Next
        If cadcodAuxi.Length > 0 Then
            Auxiliar = cadcodAuxi.Substring(0, cadcodAuxi.Length - 1)
            codAuxiliar = cadcodAuxi.Substring(0, cadcodAuxi.Length - 1)
        Else
            Auxiliar = String.Empty
            codAuxiliar = String.Empty
        End If
        Me.Close()
    End Sub

    Private Sub btnComentario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComentario.Click
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

    Sub llenarComentario()
        Dim comentario As String
        Dim form As New Form()
        Dim label As New Label()
        Dim textBox As New TextBox()
        Dim buttonOk As New Button()
        Dim buttonCancel As New Button()

        'If Me.gridDetalle.ActiveRow.Cells("TipoDoc").Value.Trim = "RH" And codArea.Trim = "42" Then
        '    'Detalle_Recibos()
        '    gridDetalle.ActiveRow.Cells("montoTotalParcial").Activation = Activation.ActivateOnly
        '    Exit Sub
        '    'Else
        '    '    If Not validarDetalleRecibo(Me.gridDetalle.ActiveRow.Index) Then Return
        '    '    gridDetalle.ActiveRow.Cells("montoTotalParcial").Activation = Activation.AllowEdit
        'End If

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

End Class