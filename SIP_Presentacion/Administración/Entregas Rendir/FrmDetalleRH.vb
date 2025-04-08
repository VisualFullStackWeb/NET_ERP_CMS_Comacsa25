Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Imports System.IO
Public Class FrmDetalleRH

    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleRH As List(Of ETEntregas) = Nothing
    Dim numDoc As String = String.Empty
    Dim item As Int32 = 0
    Public x_fila As Int32
    Public x_idcomp As Int32
    Public x_idconcepto As Int32

    Public dtDatos As New DataTable
    Dim objEntidad As ETEntregas
    Dim objNegocio As NGEntregas

    Private Sub FrmDetalleRH_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Validar() Then e.Cancel = True
        SeteoEntidad()
    End Sub

    Private Sub FrmDetalleRH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chkDirecto.Checked = False
        chkIndirecto.Checked = False

        If Ls_DetalleRH Is Nothing Then
            Ls_DetalleRH = New List(Of ETEntregas)
        End If
        Dim idliqui As Int32 = 0
        Dim cont As Int32 = 0
        If Ls_DetalleRecibo.Count > 0 Then
            numDoc = Me.txtserie.Text.ToString.Trim.PadLeft(4, "0") & Me.txtnumero.Text.ToString.Trim.PadLeft(16, "0")
            Dim tipomoneda As String = String.Empty
            For i As Int32 = 0 To Ls_DetalleRecibo.Count - 1
                If x_idcomp = Ls_DetalleRecibo.Item(i).idComp Then
                    'idliqui = Ls_DetalleRecibo.Item(i).idComp
                    item = cont
                    Dim Lista = Ls_DetalleRecibo.Where(Function(m) m.idComp = Me.x_idcomp And _
                                              m.fila = Me.x_fila And m.item = item).FirstOrDefault 'And m.ID = Ls_DetalleRecibo.Item(item).ID
                    If Not Lista Is Nothing Then
                        Ls_DetalleRH.Add(Lista)
                    End If
                    cont += 1
                End If
            Next
            Call CargarUltraGrid(gridConceptos, Ls_DetalleRH)
            gridConceptos.PerformAction(FirstCellInRow)

        End If

        If Ls_DetalleRH.Count = 0 Then
            cargarConceptos()
        Else
            If Ls_DetalleRH.Item(0).TipoRecibo = "D" Then
                chkDirecto.Checked = True
            Else
                chkIndirecto.Checked = True
            End If
        End If

        gridconceptos.Focus()
        gridConceptos.Rows(0).Cells(1).Activate()
        gridConceptos.PerformAction(FirstCellInRow)
        gridConceptos.PerformAction(EnterEditMode)
        gridConceptos.PerformAction(NextCellByTab)

    End Sub

    Sub cargarConceptos()
        objNegocio = New NGEntregas
        dtDatos = objNegocio.ConceptosRH()
        For i As Int32 = 0 To dtDatos.Rows.Count - 1
            objEntidad = New ETEntregas
            objEntidad.ID = dtDatos.Rows(i)("ID")
            objEntidad.Concepto = dtDatos.Rows(i)("CONCEPTO").ToString
            objEntidad.Descripcion = dtDatos.Rows(i)("DESCRIPCION").ToString
            objEntidad.montoTotal = dtDatos.Rows(i)("TOTAL")
            objEntidad.idComp = x_idcomp
            objEntidad.fila = x_fila
            Ls_DetalleRH.Add(objEntidad)
        Next

        Call CargarUltraGrid(gridconceptos, Ls_DetalleRH)

        'Dim fechaMovilidad As DateTime = fechaSalida
        'Dim dias As Int32 = 0
        'dias = (fechaRetorno - fechaSalida).TotalDays
        'For i As Int32 = 0 To dias
        '    Entidad.Entregas = New ETEntregas
        '    Entidad.Entregas.Fecha = fechaMovilidad.AddDays(i)
        '    Entidad.Entregas.montoTotalParcial = 0.0
        '    Entidad.Entregas.montoTotal = 0.0
        '    Entidad.Entregas.idComp = 0
        '    Entidad.Entregas.TipoOperacion = 1
        '    Ls_MovilidadAsociada.Add(Entidad.Entregas)
        'Next
        'Call CargarUltraGrid(gridDetalle, Ls_MovilidadAsociada)
    End Sub

    'Sub cargarConceptos()
    '    objNegocio = New NGEntregas
    '    dtDatos = objNegocio.ConceptosRH()
    '    Call CargarUltraGrid(gridconceptos, dtDatos)
    'End Sub

    Private Sub chkDirecto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDirecto.CheckedChanged
        If chkDirecto.Checked Then
            chkIndirecto.Checked = False
        End If
    End Sub

    Private Sub chkIndirecto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIndirecto.CheckedChanged
        If chkIndirecto.Checked Then
            chkDirecto.Checked = False
        End If
    End Sub

    Private Sub gridconceptos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridConceptos.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridConceptos) Then Return
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
                        'MsgBox(dtDatos.Rows(gridconceptos.ActiveRow.Index)(2))
                        If gridConceptos.ActiveRow.Cells(gridConceptos.ActiveCell.Column.Index).Column.Key = "TOTAL" Then
                            .PerformAction(NextCellByTab)
                        End If
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select

            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gridconceptos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "montoTotal" OrElse _
                    uColumn.Key = "Concepto" OrElse uColumn.Key = "Descripcion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Sub SeteoEntidad()
        Dim tipomoneda As String = String.Empty
        numDoc = Me.txtserie.Text.ToString.Trim.PadLeft(4, "0") & Me.txtnumero.Text.ToString.Trim.PadLeft(16, "0") '("0000000000000000")

        For x As Int32 = 0 To Ls_DetalleRecibo.Count - 1
            Dim Lista = Ls_DetalleRecibo.Where(Function(m) m.idComp = Me.x_idcomp And _
                                          m.fila = Me.x_fila).FirstOrDefault

            If Not Lista Is Nothing Then Ls_DetalleRecibo.Remove(Ls_DetalleRecibo.Where(Function(m) m.idComp = Me.x_idcomp And _
                                                 m.fila = Me.x_fila).FirstOrDefault)
        Next

        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            item = i
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.TipoOperacion = 1
            Entidad.Entregas.NumSolicitud = nroSolicitud

            Entidad.Entregas.ID = gridconceptos.Rows(i).Cells("ID").Value.ToString
            Entidad.Entregas.Concepto = gridconceptos.Rows(i).Cells("Concepto").Value.ToString
            Entidad.Entregas.Descripcion = gridconceptos.Rows(i).Cells("Descripcion").Value.ToString
            Entidad.Entregas.montoTotal = gridconceptos.Rows(i).Cells("montoTotal").Value.ToString

            Entidad.Entregas.idComp = gridconceptos.Rows(i).Cells("idComp").Value
            Entidad.Entregas.fila = gridconceptos.Rows(i).Cells("fila").Value

            If chkDirecto.Checked = True Then
                Entidad.Entregas.TipoRecibo = "D"
            Else
                Entidad.Entregas.TipoRecibo = "I"
            End If


            Entidad.Entregas.TipoDoc = Me.txttd.Text.ToString.Trim
            Entidad.Entregas.NumDoc = numDoc
            Entidad.Entregas.nroruc = Me.txtruc.Text.ToString.Trim
            Entidad.Entregas.Razon = Me.txtrazon.Text.ToString.Trim

            Entidad.Entregas.item = item
            Ls_DetalleRecibo.Add(Entidad.Entregas)
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not Validar() Then Exit Sub
        SeteoEntidad()
        Me.Close()
    End Sub
    Public monto As Double = 0
    Function Validar() As Boolean
        monto = 0
        gridConceptos.PerformAction(ExitEditMode)
        If chkDirecto.Checked = False And chkIndirecto.Checked = False Then
            MsgBox("Debe seleccionar un tipo de Recibo", MsgBoxStyle.Exclamation, msgComacsa) : Return False
        End If

        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            monto = monto + gridConceptos.Rows(i).Cells("montoTotal").Value
            If gridConceptos.Rows(i).Cells("montoTotal").Value.ToString.Trim > 0 Then
                If gridConceptos.Rows(i).Cells("Descripcion").Value.ToString.Trim = "" Then
                    MsgBox("Ingrese descripción en la fila " & i + 1, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                End If
            End If

            If gridconceptos.Rows(i).Cells("Descripcion").Value.ToString.Trim <> "" Then
                If gridconceptos.Rows(i).Cells("montoTotal").Value <= 0 Then
                    MsgBox("Ingrese monto en la fila " & i + 1, MsgBoxStyle.Exclamation, msgComacsa) : Return False
                End If
            End If
        Next
        If monto = 0 Then
            MsgBox("Debe ingresar un dato obligatoriamente", MsgBoxStyle.Exclamation, msgComacsa) : Return False
        End If
        Return True
    End Function

    Private Sub FrmDetalleRH_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub
End Class