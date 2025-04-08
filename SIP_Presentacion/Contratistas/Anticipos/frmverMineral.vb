Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop
Public Class frmverMineral
    Public dtMinerales As New DataTable
    Public COD_PROV As String
    Public FECHA1 As Date
    Public COD_CANTERA As String
    Private Sub frmverMineral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarUltraGridxBinding(gridMineral, Source1, dtMinerales)
    End Sub

    Private Sub gridMineral_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridMineral.ClickCell
        Try
            If gridMineral.ActiveRow.Cells(gridMineral.ActiveCell.Column.Index).Column.Key = "ACTIVO" Then
                gridMineral.PerformAction(ExitEditMode)
                'MsgBox(gridMineral.ActiveRow.Cells("ACTIVO").Value)
                Dim porcentaje As Double
                Dim total As Double
                If gridMineral.ActiveRow.Cells("ACTIVO").Value = True Then
                    total = gridMineral.ActiveRow.Cells("TOTALTONELADAS").Value * gridMineral.ActiveRow.Cells("PRECIO").Value
                    porcentaje = (100 - gridMineral.ActiveRow.Cells("PORCENTAJE").Value) / 100
                    gridMineral.ActiveRow.Cells("TOTAL").Value = total * porcentaje
                Else
                    gridMineral.ActiveRow.Cells("TOTAL").Value = "0.00"
                    gridMineral.ActiveRow.Cells("PORCENTAJE").Value = "0.00"
                    'gridMineral.ActiveRow.Cells("TOTALTONELADAS").Value = "0.00"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridMinerales_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridMineral.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridMineral) Then Return
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
                        calcularTotal()
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub calcularTotal()
        Dim porcentajemax As Double = 0
        porcentajemax = 100
        If gridMineral.ActiveRow.Cells("PORCENTAJE").Value > porcentajemax Then
            MsgBox("Descuento máximo " & porcentajemax & "%", MsgBoxStyle.Exclamation, msgComacsa)
            gridMineral.ActiveRow.Cells("PORCENTAJE").Value = 0
            Exit Sub
        End If

        If gridMineral.ActiveRow.Cells("PORCENTAJE").Value = 0 Then
            gridMineral.ActiveRow.Cells("COMENTARIO").Value = ""
            gridMineral.ActiveRow.Cells("BILLETEREF").Value = ""
        End If

        If gridMineral.ActiveRow.Cells("PORCENTAJE").Value > 0 Then
            llenarComentario2()
            gridMineral.ActiveRow.Cells("ACTIVO").Value = True
            'llenarComentario()
        End If

        gridMineral.PerformAction(ExitEditMode)
        Dim porcentaje As Double
        Dim total As Double
        total = gridMineral.ActiveRow.Cells("TOTALTONELADAS").Value * gridMineral.ActiveRow.Cells("PRECIO").Value
        porcentaje = (100 - gridMineral.ActiveRow.Cells("PORCENTAJE").Value) / 100
        gridMineral.ActiveRow.Cells("TOTAL").Value = total * porcentaje
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click

        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            If gridMineral.Rows.Count > 0 Then
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTEMINERALCONTRATISTA.xls")
                File.Copy(RutaReporteERP & "PLANTILLAMINERALCONTRATISTA.xls", path & "\REPORTEMINERALCONTRATISTA.xls")
                m_Excel.Workbooks.Open(path & "\REPORTEMINERALCONTRATISTA.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 13
                nfilaini = 13

                With objHojaExcel
                    .Activate()
                    .Range("A2").Value = "LISTADO DE MINERALES"
                    .Range("A2").Font.Bold = True
                    Dim filaultima As Int32 = 0
                    Dim contactivo As Int32 = 0
                    For i As Int16 = 0 To gridMineral.Rows.Count - 1
                        If gridMineral.Rows(i).Cells("ACTIVO").Value.ToString.ToUpper = "TRUE" Then
                            .Range("A" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("NUMDOC").Value
                            .Range("B" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("GUIA").Value
                            .Range("C" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("FECHA").Value
                            .Range("D" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("COD_MATPRIMA").Value
                            .Range("E" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("MINERAL").Value
                            .Range("F" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("TOTALTONELADAS").Value
                            .Range("G" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("PRECIO").Value
                            .Range("H" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("PRECIOFACTURA").Value
                            .Range("I" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("TOTAL").Value
                            .Range("J" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("PORCENTAJE").Value / 100
                            .Range("K" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("COMENTARIO").Value.ToString.Trim
                            '.Range("I" & 4 + i).WrapText = False
                            .Range(.Cells(5 - contactivo + i, 1), .Cells(5 - contactivo + i, 11)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            nfila = nfila + 1
                            filaultima = 6 - contactivo + i
                        Else
                            contactivo = contactivo + 1
                        End If
                    Next
                    .Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 5)).Value = "TOTALES"
                    .Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 5)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 6)).Formula = "=SUMA(F5:F" & filaultima & ")"
                    .Range(.Cells(filaultima + 1, 9), .Cells(filaultima + 1, 9)).Formula = "=SUMA(I5:I" & filaultima & ")"

                    '.Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 9)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                    .Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 9)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    .Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 9)).Font.Bold = True
                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Sub llenarComentario2()
        Dim Form As New frmIngresoComentario
        Dim comentario As String
        Dim billete As String
        Form.COD_PROV = COD_PROV
        Form.FECHA1 = FECHA1
        Form.COD_CANTERA = COD_CANTERA

        Form.txtcomentario.Text = Me.gridMineral.ActiveRow.Cells("COMENTARIO").Value
        Form.txtbillete.Text = Me.gridMineral.ActiveRow.Cells("BILLETEREF").Value
        Dim _dialogResult As DialogResult = Form.ShowDialog()
        If _dialogResult = Windows.Forms.DialogResult.OK Then
            comentario = Form.txtcomentario.Text
            billete = Form.txtbillete.Text
            Me.gridMineral.ActiveRow.Cells("COMENTARIO").Value = comentario
            Me.gridMineral.ActiveRow.Cells("BILLETEREF").Value = billete
            gridMineral.ActiveRow.ToolTipText = "COMENTARIO : " & gridMineral.ActiveRow.Cells("COMENTARIO").Value
            'Else
            '    Me.gridMinerales.ActiveRow.Cells("COMENTARIO").Value = ""
            '    Me.gridMinerales.ActiveRow.Cells("BILLETE").Value = ""
        End If
    End Sub
    Sub llenarComentario()
        Dim comentario As String
        Dim form As New Form()
        Dim label As New Label()
        Dim textBox As New TextBox()
        Dim buttonOk As New Button()
        Dim buttonCancel As New Button()
        form.Text = "INGRESE COMENTARIO"
        label.Text = "COMENTARIO"
        textBox.Text = Me.gridMineral.ActiveRow.Cells("COMENTARIO").Value
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
            Me.gridMineral.ActiveRow.Cells("COMENTARIO").Value = comentario
            gridMineral.ActiveRow.ToolTipText = "COMENTARIO : " & gridMineral.ActiveRow.Cells("COMENTARIO").Value
        End If
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        gridMineral.PerformAction(ExitEditMode)
        Me.Close()
    End Sub

    Private Sub gridMineral_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridMineral.InitializeLayout

    End Sub
End Class