Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class FrmGeneraStamin
    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Dim DtSFNAcional As DataTable = Nothing
    Dim DtSFExterior As DataTable = Nothing
    Dim DtSobrantes As DataTable = Nothing

    Dim DtOFNAcional As DataTable = Nothing
    Dim DtOFExterior As DataTable = Nothing
    Dim DtExploracion As DataTable = Nothing
    Private Sub FrmGeneraStamin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        Me.cmbMes.SelectedIndex = Now.Date.Month - 1
    End Sub
    Sub Procesar()
        If cmbMes.Value <= 0 Then
            MsgBox("Seleccione un mes a procesar", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If

        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DsIngresoMineral As DataSet = Nothing
        Dim DsVentaMineral As DataSet = Nothing
        Dim DtIngresoExt As DataTable = Nothing
        Dim DtIngresoComp As DataTable = Nothing
        Dim DtVentaNacional As DataTable = Nothing
        Dim DtVentaExportacion As DataTable = Nothing
        Dim DtEgreso As DataTable = Nothing
        Dim DtStamin As DataTable = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Procesando datos ingreso de mineral..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .año = txtAño.Value
                .mes = cmbMes.Value
                .User_Crea = User_Sistema
            End With
            DsIngresoMineral = oPrvFisN.DatosIngresoMineral(oPrvFisE)
            DtIngresoExt = DsIngresoMineral.Tables(0)
            DtIngresoComp = DsIngresoMineral.Tables(1)
            'DtEgreso = oPrvFisN.DatosEgresoIQBF(oPrvFisE)
            Call CargarUltraGridxBinding(Grid1, Source1, DtIngresoExt)
            Call CargarUltraGridxBinding(Grid2, Source2, DtIngresoComp)
            lblmensaje.Text = "Procesando datos venta de mineral..."
            lblmensaje.Refresh()
            DsVentaMineral = oPrvFisN.DatosVentaMineral(oPrvFisE)
            DtVentaNacional = DsVentaMineral.Tables(0)
            DtVentaExportacion = DsVentaMineral.Tables(1)
            DtStamin = DsVentaMineral.Tables(2)
            DtSFNAcional = DsVentaMineral.Tables(3)
            DtSFExterior = DsVentaMineral.Tables(4)
            DtOFNAcional = DsVentaMineral.Tables(5)
            DtOFExterior = DsVentaMineral.Tables(6)
            DtExploracion = DsVentaMineral.Tables(7)
            Call CargarUltraGridxBinding(GridNacional, Source3, DtVentaNacional)
            Call CargarUltraGridxBinding(GridExportacion, Source4, DtVentaExportacion)
            Call CargarUltraGridxBinding(GridStamin, Source5, DtStamin)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub


    Private Sub Grid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is Grid1) Then Return
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
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Grid1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid1.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Escape) Then Return
            If e.KeyChar = ChrW(Keys.Delete) Then Return
            If e.KeyChar = ChrW(Keys.Return) Then Return
            If e.KeyChar = ChrW(Keys.Back) Then Return
            If e.KeyChar.ToString.Trim = "" Then Return

            If Grid1.ActiveRow.Cells(Grid1.ActiveCell.Column.Index).Column.Key = "CANTERA" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                Dim frm As New FrmCanterasUEA
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.UEA = Grid1.Rows(Grid1.ActiveRow.Index).Cells("COD_UEA").Value.ToString
                frm.ShowDialog()
                If Not codCantera = "" Then
                    Grid1.Rows(Grid1.ActiveRow.Index).Cells("CANTERA").Value = Cantera
                    codCantera = ""
                    Cantera = ""
                End If
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Grabar()
        Try
            Ls_Entrega = New List(Of ETEntregas)
            If Grid1.Rows.Count > 0 Then
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                lblmensaje.Text = "Grabando Datos..."
                lblmensaje.Visible = True
                lblmensaje.Refresh()
                For i As Int32 = 0 To Grid1.Rows.Count - 1
                    Entidad.Entregas = New ETEntregas
                    Entidad.Entregas.codMineral = Grid1.Rows(i).Cells("COD_PROD").Value.ToString
                    Entidad.Entregas.Mineral = Grid1.Rows(i).Cells("MINERAL").Value.ToString
                    Entidad.Entregas.Cantera = Grid1.Rows(i).Cells("CANTERA").Value.ToString
                    Entidad.Entregas.acumulado = Grid1.Rows(i).Cells("ACUMULADO").Value.ToString
                    Entidad.Entregas.UEA = Grid1.Rows(i).Cells("UEA").Value.ToString
                    Entidad.Entregas.codUEA = Grid1.Rows(i).Cells("COD_UEA").Value.ToString
                    Entidad.Entregas.tipoIngreso = "E"
                    Entidad.Entregas.Mes = cmbMes.Value
                    Entidad.Entregas.Anho = txtAño.Value
                    Entidad.Entregas.Usuario = User_Sistema
                    Ls_Entrega.Add(Entidad.Entregas)
                Next
            End If
            If Grid2.Rows.Count > 0 Then
                For i As Int32 = 0 To Grid2.Rows.Count - 1
                    Entidad.Entregas = New ETEntregas
                    Entidad.Entregas.codMineral = Grid2.Rows(i).Cells("COD_PROD").Value.ToString
                    Entidad.Entregas.Mineral = Grid2.Rows(i).Cells("MINERAL").Value.ToString
                    Entidad.Entregas.Cantera = Grid2.Rows(i).Cells("CANTERA").Value.ToString
                    Entidad.Entregas.acumulado = Grid2.Rows(i).Cells("ACUMULADO").Value.ToString
                    Entidad.Entregas.UEA = Grid2.Rows(i).Cells("UEA").Value.ToString
                    Entidad.Entregas.codUEA = Grid2.Rows(i).Cells("COD_UEA").Value.ToString
                    Entidad.Entregas.tipoIngreso = "C"
                    Entidad.Entregas.Mes = cmbMes.Value
                    Entidad.Entregas.Anho = txtAño.Value
                    Entidad.Entregas.Usuario = User_Sistema
                    Ls_Entrega.Add(Entidad.Entregas)
                Next
            End If

            Entidad.Entregas = Negocio.NEntregas.MANTINGRESOMINERALSATAMIN(Ls_Entrega)
            Procesar()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub
    Sub Reporte()
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No existen datos para el reporte", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try

            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\STAMIN.xls")
            File.Copy(RutaReporteERP & "PLANTILLA STAMIN.xls", path & "\STAMIN.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\STAMIN.xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcelIngreso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcelNacional As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            Dim objHojaExcelExterior As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            Dim objHojaExcelSinFormula As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
            Dim objHojaExcelStamin As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(5)
            Dim objHojaExcelExploracion As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(6)
            'Dim objHojaExcelOtraFormula As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(7)
            exportarIngreso(objHojaExcelIngreso)
            exportarNacional(objHojaExcelNacional, objHojaExcelSinFormula)
            exportarExterior(objHojaExcelExterior, objHojaExcelSinFormula)
            exportarSinFormula(objHojaExcelSinFormula)
            exportarStamin(objHojaExcelStamin)
            exportarExploracion(objHojaExcelExploracion)
            m_Excel.Visible = True
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub
    Sub exportarIngreso(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A2").Value = Me.cmbMes.Text.ToString.ToUpper & " " & txtAño.Value.ToString
                For i = 0 To Grid1.Rows.Count - 1
                    If Grid1.Rows(i).Cells("ACUMULADO").Value > 0 Then
                        .Range(.Cells(4 + i, 1), .Cells(4 + i, 1)).Value = Grid1.Rows(i).Cells("COD_PROD").Value
                        .Range(.Cells(4 + i, 2), .Cells(4 + i, 2)).Value = Grid1.Rows(i).Cells("CANTERA").Value
                        .Range(.Cells(4 + i, 3), .Cells(4 + i, 3)).Value = Grid1.Rows(i).Cells("MINERAL").Value
                        .Range(.Cells(4 + i, 4), .Cells(4 + i, 4)).Value = Grid1.Rows(i).Cells("ACUMULADO").Value
                        .Range(.Cells(4 + i, 5), .Cells(4 + i, 5)).Value = Grid1.Rows(i).Cells("UEA").Value
                        .Range(.Cells(4 + i, 1), .Cells(4 + i, 5)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        ultFila = i + 5
                        'Else
                        '.Range("A21").EntireRow.Delete()
                    End If
                Next
                .Range(.Cells(ultFila, 3), .Cells(ultFila, 3)).Value = "SUB TOTAL"
                .Range(.Cells(ultFila, 3), .Cells(ultFila, 4)).Font.Bold = True
                .Range(.Cells(ultFila, 3), .Cells(ultFila, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(ultFila, 4), .Cells(ultFila, 4)).Formula = "=SUMA(D4 : D" & ultFila - 1 & ")"

                filaCompra = ultFila + 2
                If Grid2.Rows.Count > 0 Then
                    For j = 0 To Grid2.Rows.Count - 1
                        If Grid2.Rows(j).Cells("ACUMULADO").Value > 0 Then
                            .Range(.Cells(filaCompra + j, 1), .Cells(filaCompra + j, 1)).Value = Grid2.Rows(j).Cells("COD_PROD").Value
                            .Range(.Cells(filaCompra + j, 2), .Cells(filaCompra + j, 2)).Value = Grid2.Rows(j).Cells("CANTERA").Value
                            .Range(.Cells(filaCompra + j, 3), .Cells(filaCompra + j, 3)).Value = Grid2.Rows(j).Cells("MINERAL").Value
                            .Range(.Cells(filaCompra + j, 4), .Cells(filaCompra + j, 4)).Value = Grid2.Rows(j).Cells("ACUMULADO").Value
                            .Range(.Cells(filaCompra + j, 5), .Cells(filaCompra + j, 5)).Value = Grid2.Rows(j).Cells("UEA").Value
                            .Range(.Cells(filaCompra + j, 1), .Cells(filaCompra + j, 5)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            ultFila2 = filaCompra + j
                        End If
                    Next
                    ultFila2 = ultFila2 + 1
                    .Range(.Cells(ultFila2, 3), .Cells(ultFila2, 3)).Value = "SUB TOTAL"
                    .Range(.Cells(ultFila2, 3), .Cells(ultFila2, 4)).Font.Bold = True
                    .Range(.Cells(ultFila2, 3), .Cells(ultFila2, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(ultFila2, 4), .Cells(ultFila2, 4)).Formula = "=SUMA(D" & filaCompra & " : D" & ultFila2 - 1 & ")"

                End If
                .Range(.Cells(ultFila2 + 1, 3), .Cells(ultFila2 + 1, 3)).Value = "TOTAL"
                .Range(.Cells(ultFila2 + 1, 3), .Cells(ultFila2 + 1, 4)).Font.Bold = True
                .Range(.Cells(ultFila2 + 1, 3), .Cells(ultFila2 + 1, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(ultFila2 + 1, 4), .Cells(ultFila2 + 1, 4)).Formula = "=D" & ultFila & " + D" & ultFila2 & ""
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarNacional(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal objHojaExcelVTotal As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A2").Value = Me.cmbMes.Text.ToString.ToUpper & " " & txtAño.Value.ToString
                If GridNacional.Rows.Count > 0 Then

                    For i = 0 To GridNacional.Rows.Count - 1
                        If GridNacional.Rows(i).Cells("UEA").Value.ToString.Trim <> "COMPRA" Then
                            .Range(.Cells(4 + i, 1), .Cells(4 + i, 1)).Value = GridNacional.Rows(i).Cells("COD_PROD").Value
                            .Range(.Cells(4 + i, 2), .Cells(4 + i, 2)).Value = GridNacional.Rows(i).Cells("CANTERA").Value
                            .Range(.Cells(4 + i, 3), .Cells(4 + i, 3)).Value = GridNacional.Rows(i).Cells("MINERAL").Value
                            .Range(.Cells(4 + i, 4), .Cells(4 + i, 4)).Value = GridNacional.Rows(i).Cells("CANTIDAD").Value
                            .Range(.Cells(4 + i, 5), .Cells(4 + i, 5)).Value = GridNacional.Rows(i).Cells("SOLES").Value
                            .Range(.Cells(4 + i, 6), .Cells(4 + i, 6)).Value = GridNacional.Rows(i).Cells("ACUMULADO").Value
                            .Range(.Cells(4 + i, 7), .Cells(4 + i, 7)).Value = GridNacional.Rows(i).Cells("UEA").Value
                            .Range(.Cells(4 + i, 1), .Cells(4 + i, 7)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            ultFila = i + 5
                        End If
                    Next
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 3)).Value = "SUB TOTAL"
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 6)).Font.Bold = True
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(ultFila, 4), .Cells(ultFila, 4)).Formula = "=SUMA(D4 : D" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 5), .Cells(ultFila, 5)).Formula = "=SUMA(E4 : E" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 6), .Cells(ultFila, 6)).Formula = "=SUMA(F4 : F" & ultFila - 1 & ")"

                    objHojaExcelVTotal.Range("D2").Formula = "=SUMA(NACIONAL!D4 : D" & ultFila - 1 & ")"
                    objHojaExcelVTotal.Range("E2").Formula = "=SUMA(NACIONAL!E4 : E" & ultFila - 1 & ")"
                    objHojaExcelVTotal.Range("F2").Formula = "=SUMA(NACIONAL!F4 : F" & ultFila - 1 & ")"

                    filaCompra = ultFila + 2

                End If

                For i = 0 To GridNacional.Rows.Count - 1
                    If GridNacional.Rows(i).Cells("UEA").Value.ToString.Trim = "COMPRA" Then
                        .Range(.Cells(6 + i, 1), .Cells(6 + i, 1)).Value = GridNacional.Rows(i).Cells("COD_PROD").Value
                        .Range(.Cells(6 + i, 2), .Cells(6 + i, 2)).Value = GridNacional.Rows(i).Cells("CANTERA").Value
                        .Range(.Cells(6 + i, 3), .Cells(6 + i, 3)).Value = GridNacional.Rows(i).Cells("MINERAL").Value
                        .Range(.Cells(6 + i, 4), .Cells(6 + i, 4)).Value = GridNacional.Rows(i).Cells("CANTIDAD").Value
                        .Range(.Cells(6 + i, 5), .Cells(6 + i, 5)).Value = GridNacional.Rows(i).Cells("SOLES").Value
                        .Range(.Cells(6 + i, 6), .Cells(6 + i, 6)).Value = GridNacional.Rows(i).Cells("ACUMULADO").Value
                        .Range(.Cells(6 + i, 7), .Cells(6 + i, 7)).Value = GridNacional.Rows(i).Cells("UEA").Value
                        .Range(.Cells(6 + i, 1), .Cells(6 + i, 7)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        ultFila2 = i + 6
                    End If
                Next
                ultFila2 = ultFila2 + 1
                .Range(.Cells(ultFila2, 3), .Cells(ultFila2, 3)).Value = "SUB TOTAL"
                .Range(.Cells(ultFila2, 3), .Cells(ultFila2, 6)).Font.Bold = True
                .Range(.Cells(ultFila2, 3), .Cells(ultFila2, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(ultFila2, 4), .Cells(ultFila2, 4)).Formula = "=SUMA(D" & filaCompra & " : D" & ultFila2 - 1 & ")"
                .Range(.Cells(ultFila2, 5), .Cells(ultFila2, 5)).Formula = "=SUMA(E" & filaCompra & " : E" & ultFila2 - 1 & ")"
                .Range(.Cells(ultFila2, 6), .Cells(ultFila2, 6)).Formula = "=SUMA(F" & filaCompra & " : F" & ultFila2 - 1 & ")"

                objHojaExcelVTotal.Range("D3").Formula = "=SUMA(NACIONAL!D" & filaCompra & " : D" & ultFila2 - 1 & ")"
                objHojaExcelVTotal.Range("E3").Formula = "=SUMA(NACIONAL!E" & filaCompra & " : E" & ultFila2 - 1 & ")"
                objHojaExcelVTotal.Range("F3").Formula = "=SUMA(NACIONAL!F" & filaCompra & " : F" & ultFila2 - 1 & ")"

                .Range(.Cells(ultFila2 + 1, 3), .Cells(ultFila2 + 1, 3)).Value = "TOTAL"
                .Range(.Cells(ultFila2 + 1, 3), .Cells(ultFila2 + 1, 6)).Font.Bold = True
                .Range(.Cells(ultFila2 + 1, 3), .Cells(ultFila2 + 1, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(ultFila2 + 1, 4), .Cells(ultFila2 + 1, 4)).Formula = "=D" & ultFila & " + D" & ultFila2 & ""
                .Range(.Cells(ultFila2 + 1, 5), .Cells(ultFila2 + 1, 5)).Formula = "=E" & ultFila & " + E" & ultFila2 & ""
                .Range(.Cells(ultFila2 + 1, 6), .Cells(ultFila2 + 1, 6)).Formula = "=F" & ultFila & " + F" & ultFila2 & ""



            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarExterior(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal objHojaExcelVTotal As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A2").Value = Me.cmbMes.Text.ToString.ToUpper & " " & txtAño.Value.ToString
                If GridNacional.Rows.Count > 0 Then

                    For i = 0 To GridExportacion.Rows.Count - 1
                        If GridExportacion.Rows(i).Cells("UEA").Value.ToString.Trim <> "COMPRA" Then
                            .Range(.Cells(4 + i, 1), .Cells(4 + i, 1)).Value = GridExportacion.Rows(i).Cells("COD_PROD").Value
                            .Range(.Cells(4 + i, 2), .Cells(4 + i, 2)).Value = GridExportacion.Rows(i).Cells("CANTERA").Value
                            .Range(.Cells(4 + i, 3), .Cells(4 + i, 3)).Value = GridExportacion.Rows(i).Cells("MINERAL").Value
                            .Range(.Cells(4 + i, 4), .Cells(4 + i, 4)).Value = GridExportacion.Rows(i).Cells("CANTIDAD").Value
                            .Range(.Cells(4 + i, 5), .Cells(4 + i, 5)).Value = GridExportacion.Rows(i).Cells("SOLES").Value
                            .Range(.Cells(4 + i, 6), .Cells(4 + i, 6)).Value = GridExportacion.Rows(i).Cells("ACUMULADO").Value
                            .Range(.Cells(4 + i, 7), .Cells(4 + i, 7)).Value = GridExportacion.Rows(i).Cells("UEA").Value
                            .Range(.Cells(4 + i, 8), .Cells(4 + i, 8)).Value = GridExportacion.Rows(i).Cells("PAIS").Value
                            .Range(.Cells(4 + i, 1), .Cells(4 + i, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            ultFila = i + 5
                        End If
                    Next
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 3)).Value = "SUB TOTAL"
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 6)).Font.Bold = True
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(ultFila, 4), .Cells(ultFila, 4)).Formula = "=SUMA(D4 : D" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 5), .Cells(ultFila, 5)).Formula = "=SUMA(E4 : E" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 6), .Cells(ultFila, 6)).Formula = "=SUMA(F4 : F" & ultFila - 1 & ")"

                    objHojaExcelVTotal.Range("D4").Formula = "=SUMA(EXTERIOR!D4 : D" & ultFila - 1 & ")"
                    objHojaExcelVTotal.Range("E4").Formula = "=SUMA(EXTERIOR!E4 : E" & ultFila - 1 & ")"
                    objHojaExcelVTotal.Range("F4").Formula = "=SUMA(EXTERIOR!F4 : F" & ultFila - 1 & ")"

                    filaCompra = ultFila + 2

                End If

                For i = 0 To GridExportacion.Rows.Count - 1
                    If GridExportacion.Rows(i).Cells("UEA").Value.ToString.Trim = "COMPRA" Then
                        .Range(.Cells(6 + i, 1), .Cells(6 + i, 1)).Value = GridExportacion.Rows(i).Cells("COD_PROD").Value
                        .Range(.Cells(6 + i, 2), .Cells(6 + i, 2)).Value = GridExportacion.Rows(i).Cells("CANTERA").Value
                        .Range(.Cells(6 + i, 3), .Cells(6 + i, 3)).Value = GridExportacion.Rows(i).Cells("MINERAL").Value
                        .Range(.Cells(6 + i, 4), .Cells(6 + i, 4)).Value = GridExportacion.Rows(i).Cells("CANTIDAD").Value
                        .Range(.Cells(6 + i, 5), .Cells(6 + i, 5)).Value = GridExportacion.Rows(i).Cells("SOLES").Value
                        .Range(.Cells(6 + i, 6), .Cells(6 + i, 6)).Value = GridExportacion.Rows(i).Cells("ACUMULADO").Value
                        .Range(.Cells(6 + i, 7), .Cells(6 + i, 7)).Value = GridExportacion.Rows(i).Cells("UEA").Value
                        .Range(.Cells(6 + i, 8), .Cells(6 + i, 8)).Value = GridExportacion.Rows(i).Cells("PAIS").Value
                        .Range(.Cells(6 + i, 1), .Cells(6 + i, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        ultFila2 = i + 6
                    End If
                Next
                ultFila2 = ultFila2 + 1
                .Range(.Cells(ultFila2, 3), .Cells(ultFila2, 3)).Value = "SUB TOTAL"
                .Range(.Cells(ultFila2, 3), .Cells(ultFila2, 6)).Font.Bold = True
                .Range(.Cells(ultFila2, 3), .Cells(ultFila2, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(ultFila2, 4), .Cells(ultFila2, 4)).Formula = "=SUMA(D" & filaCompra & " : D" & ultFila2 - 1 & ")"
                .Range(.Cells(ultFila2, 5), .Cells(ultFila2, 5)).Formula = "=SUMA(E" & filaCompra & " : E" & ultFila2 - 1 & ")"
                .Range(.Cells(ultFila2, 6), .Cells(ultFila2, 6)).Formula = "=SUMA(F" & filaCompra & " : F" & ultFila2 - 1 & ")"

                objHojaExcelVTotal.Range("D5").Formula = "=SUMA(EXTERIOR!D" & filaCompra & " : D" & ultFila2 - 1 & ")"
                objHojaExcelVTotal.Range("E5").Formula = "=SUMA(EXTERIOR!E" & filaCompra & " : E" & ultFila2 - 1 & ")"
                objHojaExcelVTotal.Range("F5").Formula = "=SUMA(EXTERIOR!F" & filaCompra & " : F" & ultFila2 - 1 & ")"

                .Range(.Cells(ultFila2 + 1, 3), .Cells(ultFila2 + 1, 3)).Value = "TOTAL"
                .Range(.Cells(ultFila2 + 1, 3), .Cells(ultFila2 + 1, 6)).Font.Bold = True
                .Range(.Cells(ultFila2 + 1, 3), .Cells(ultFila2 + 1, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(ultFila2 + 1, 4), .Cells(ultFila2 + 1, 4)).Formula = "=D" & ultFila & " + D" & ultFila2 & ""
                .Range(.Cells(ultFila2 + 1, 5), .Cells(ultFila2 + 1, 5)).Formula = "=E" & ultFila & " + E" & ultFila2 & ""
                .Range(.Cells(ultFila2 + 1, 6), .Cells(ultFila2 + 1, 6)).Formula = "=F" & ultFila & " + F" & ultFila2 & ""
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarStamin(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            Dim correl As Int32 = 1

            Dim nfila As Integer
            Dim nfilaini As Integer = 0
            Dim nfilault As Integer = 0
            Dim UEA As String = String.Empty
            nfila = 6
            nfilaini = 6

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A2").Value = "REPORTE DE ESTADISTICA MINERA"
                .Range("B3").Value = Me.cmbMes.Text.ToString.ToUpper & " " & txtAño.Value.ToString
                If GridNacional.Rows.Count > 0 Then
                    UEA = GridStamin.Rows(0).Cells("UEA").Value.ToString.Trim
                    Dim cantSUEA As Int32 = 0
                    For i = 0 To GridStamin.Rows.Count - 1

                        If UEA.Trim <> GridStamin.Rows(i).Cells("UEA").Value.ToString.Trim Then
                            nfilault = 5 + i
                            .Range(.Cells(nfilaini, 1), .Cells(nfilault, 1)).Merge()
                            .Range(.Cells(nfilaini, 2), .Cells(nfilault, 2)).Merge()
                            nfilaini = 6 + i
                            UEA = GridStamin.Rows(i).Cells("UEA").Value.ToString.Trim
                            correl += 1
                        End If

                        .Range(.Cells(6 + i, 1), .Cells(6 + i, 1)).Value = correl
                        .Range(.Cells(6 + i, 2), .Cells(6 + i, 2)).Value = GridStamin.Rows(i).Cells("UEA").Value.ToString.Trim
                        .Range(.Cells(6 + i, 3), .Cells(6 + i, 3)).Value = GridStamin.Rows(i).Cells("DESCRIPCION").Value.ToString.Trim
                        If GridStamin.Rows(i).Cells("INGRESO").Value > 0 Then
                            .Range(.Cells(6 + i, 4), .Cells(6 + i, 4)).Value = GridStamin.Rows(i).Cells("INGRESO").Value
                        End If

                        'If GridStamin.Rows(i).Cells("UEA").Value.ToString.Trim = "SIN UEA" Then
                        '    If GridStamin.Rows(i).Cells("PAIS").Value = "PERU" Then
                        '        .Range(.Cells(9 + i, 5), .Cells(9 + i, 5)).Value = GridStamin.Rows(i).Cells("TONELADAS").Value
                        '        .Range(.Cells(9 + i, 6), .Cells(9 + i, 6)).Value = GridStamin.Rows(i).Cells("SOLES").Value
                        '        .Range(.Cells(9 + i, 7), .Cells(9 + i, 7)).Value = GridStamin.Rows(i).Cells("DOLARES").Value
                        '        .Range(.Cells(9 + i, 12), .Cells(9 + i, 12)).Value = "=G" & 9 + i & " / E" & 9 + i & ""
                        '    Else
                        '        .Range(.Cells(9 + i, 8), .Cells(9 + i, 8)).Value = GridStamin.Rows(i).Cells("TONELADAS").Value
                        '        .Range(.Cells(9 + i, 9), .Cells(9 + i, 9)).Value = GridStamin.Rows(i).Cells("SOLES").Value
                        '        .Range(.Cells(9 + i, 10), .Cells(9 + i, 10)).Value = GridStamin.Rows(i).Cells("DOLARES").Value
                        '        .Range(.Cells(9 + i, 11), .Cells(6 + i, 11)).Value = GridStamin.Rows(i).Cells("PAIS").Value
                        '        .Range(.Cells(9 + i, 12), .Cells(9 + i, 12)).Value = "=J" & 9 + i & " / H" & 9 + i & ""
                        '    End If
                        '    cantSUEA += 1
                        '    ultFila = i + 10
                        'Else
                        If GridStamin.Rows(i).Cells("PAIS").Value = "PERU" Then
                            .Range(.Cells(6 + i, 5), .Cells(6 + i, 5)).Value = GridStamin.Rows(i).Cells("TONELADAS").Value
                            .Range(.Cells(6 + i, 6), .Cells(6 + i, 6)).Value = GridStamin.Rows(i).Cells("SOLES").Value
                            .Range(.Cells(6 + i, 7), .Cells(6 + i, 7)).Value = GridStamin.Rows(i).Cells("DOLARES").Value
                            .Range(.Cells(6 + i, 12), .Cells(6 + i, 12)).Value = "=G" & 6 + i & " / E" & 6 + i & ""
                        Else
                            .Range(.Cells(6 + i, 8), .Cells(6 + i, 8)).Value = GridStamin.Rows(i).Cells("TONELADAS").Value
                            .Range(.Cells(6 + i, 9), .Cells(6 + i, 9)).Value = GridStamin.Rows(i).Cells("SOLES").Value
                            .Range(.Cells(6 + i, 10), .Cells(6 + i, 10)).Value = GridStamin.Rows(i).Cells("DOLARES").Value
                            .Range(.Cells(6 + i, 11), .Cells(6 + i, 11)).Value = GridStamin.Rows(i).Cells("PAIS").Value
                            .Range(.Cells(6 + i, 12), .Cells(6 + i, 12)).Value = "=J" & 6 + i & " / H" & 6 + i & ""

                        End If

                        'End If
                        .Range(.Cells(6 + i, 1), .Cells(6 + i, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        ultFila = i + 7

                    Next
                    'correl += 1
                    .Range(.Cells(nfilaini, 1), .Cells(ultFila - 1, 1)).Merge()
                    .Range(.Cells(nfilaini, 2), .Cells(ultFila - 1, 2)).Merge()

                    .Range(.Cells(ultFila + 1, 4), .Cells(ultFila + 1, 10)).Font.Bold = True
                    .Range(.Cells(ultFila - cantSUEA + 1, 4), .Cells(ultFila + 1, 10)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(ultFila - cantSUEA + 1, 4), .Cells(ultFila - cantSUEA + 1, 4)).Formula = "=SUMA(D4 : D" & ultFila - cantSUEA - 1 & ")"
                    .Range(.Cells(ultFila - cantSUEA + 1, 5), .Cells(ultFila - cantSUEA + 1, 5)).Formula = "=SUMA(E4 : E" & ultFila - cantSUEA - 1 & ")"
                    .Range(.Cells(ultFila - cantSUEA + 1, 6), .Cells(ultFila - cantSUEA + 1, 6)).Formula = "=SUMA(F4 : F" & ultFila - cantSUEA - 1 & ")"
                    .Range(.Cells(ultFila - cantSUEA + 1, 7), .Cells(ultFila - cantSUEA + 1, 7)).Formula = "=SUMA(G4 : G" & ultFila - cantSUEA - 1 & ")"
                    .Range(.Cells(ultFila - cantSUEA + 1, 8), .Cells(ultFila - cantSUEA + 1, 8)).Formula = "=SUMA(H4 : H" & ultFila - cantSUEA - 1 & ")"
                    .Range(.Cells(ultFila - cantSUEA + 1, 9), .Cells(ultFila - cantSUEA + 1, 9)).Formula = "=SUMA(I4 : I" & ultFila - cantSUEA - 1 & ")"
                    .Range(.Cells(ultFila - cantSUEA + 1, 10), .Cells(ultFila - cantSUEA + 1, 10)).Formula = "=SUMA(J4 : J" & ultFila - cantSUEA - 1 & ")"
                    filaCompra = ultFila + 2

                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarSinFormula(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            Dim filasNAcional As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                '.Range("A2").Value = Me.cmbMes.Text.ToString.ToUpper & " " & txtAño.Value.ToString

                If DtSFNAcional.Rows.Count > 0 Then
                    filasNAcional = DtSFNAcional.Rows.Count + 17
                    For i = 0 To DtSFNAcional.Rows.Count - 1
                        .Range(.Cells(15 + i, 2), .Cells(15 + i, 2)).Value = DtSFNAcional.Rows(i)("CODPRODUCTO")
                        .Range(.Cells(15 + i, 3), .Cells(15 + i, 3)).Value = DtSFNAcional.Rows(i)("DESCRIP")
                        .Range(.Cells(15 + i, 4), .Cells(15 + i, 4)).Value = DtSFNAcional.Rows(i)("CANTIDAD")
                        .Range(.Cells(15 + i, 5), .Cells(15 + i, 5)).Value = DtSFNAcional.Rows(i)("IMPORTESOL")
                        .Range(.Cells(15 + i, 6), .Cells(15 + i, 6)).Value = DtSFNAcional.Rows(i)("IMPORTEDOL")
                        .Range(.Cells(15 + i, 7), .Cells(15 + i, 7)).Value = DtSFNAcional.Rows(i)("PAIS")
                        .Range(.Cells(15 + i, 2), .Cells(15 + i, 7)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        ultFila = i + 15
                    Next
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 3)).Value = "SUB TOTAL"
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 6)).Font.Bold = True
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(ultFila, 4), .Cells(ultFila, 4)).Formula = "=SUMA(D14 : D" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 5), .Cells(ultFila, 5)).Formula = "=SUMA(E14 : E" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 6), .Cells(ultFila, 6)).Formula = "=SUMA(F14 : F" & ultFila - 1 & ")"

                    .Range("D6").Formula = "=SUMA(D14 : D" & ultFila - 1 & ")"
                    .Range("E6").Formula = "=SUMA(E14: E" & ultFila - 1 & ")"
                    .Range("F6").Formula = "=SUMA(F14 : F" & ultFila - 1 & ")"


                End If

                If DtSFExterior.Rows.Count > 0 Then

                    For i = 0 To DtSFExterior.Rows.Count - 1
                        .Range(.Cells(filasNAcional + i, 2), .Cells(filasNAcional + i, 2)).Value = DtSFExterior.Rows(i)("CODPRODUCTO")
                        .Range(.Cells(filasNAcional + i, 3), .Cells(filasNAcional + i, 3)).Value = DtSFExterior.Rows(i)("DESCRIP")
                        .Range(.Cells(filasNAcional + i, 4), .Cells(filasNAcional + i, 4)).Value = DtSFExterior.Rows(i)("CANTIDAD")
                        .Range(.Cells(filasNAcional + i, 5), .Cells(filasNAcional + i, 5)).Value = DtSFExterior.Rows(i)("IMPORTESOL")
                        .Range(.Cells(filasNAcional + i, 6), .Cells(filasNAcional + i, 6)).Value = DtSFExterior.Rows(i)("IMPORTEDOL")
                        .Range(.Cells(filasNAcional + i, 7), .Cells(filasNAcional + i, 7)).Value = DtSFExterior.Rows(i)("PAIS")
                        .Range(.Cells(filasNAcional + i, 2), .Cells(filasNAcional + i, 7)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        ultFila = i + filasNAcional + 1
                    Next
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 3)).Value = "SUB TOTAL"
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 6)).Font.Bold = True
                    .Range(.Cells(ultFila, 3), .Cells(ultFila, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(ultFila, 4), .Cells(ultFila, 4)).Formula = "=SUMA(D" & filasNAcional & " : D" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 5), .Cells(ultFila, 5)).Formula = "=SUMA(E" & filasNAcional & " : E" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 6), .Cells(ultFila, 6)).Formula = "=SUMA(F" & filasNAcional & " : F" & ultFila - 1 & ")"

                    .Range("D7").Formula = "=SUMA(D" & filasNAcional & " : D" & ultFila - 1 & ")"
                    .Range("E7").Formula = "=SUMA(E" & filasNAcional & " : E" & ultFila - 1 & ")"
                    .Range("F7").Formula = "=SUMA(F" & filasNAcional & " : F" & ultFila - 1 & ")"


                End If

                If DtOFNAcional.Rows.Count > 0 Then
                    filasNAcional = DtOFNAcional.Rows.Count + 17
                    For i = 0 To DtOFNAcional.Rows.Count - 1
                        .Range(.Cells(15 + i, 9), .Cells(15 + i, 9)).Value = DtOFNAcional.Rows(i)("CODPRODUCTO")
                        .Range(.Cells(15 + i, 10), .Cells(15 + i, 10)).Value = DtOFNAcional.Rows(i)("DESCRIP")
                        .Range(.Cells(15 + i, 11), .Cells(15 + i, 11)).Value = DtOFNAcional.Rows(i)("CANTIDAD")
                        .Range(.Cells(15 + i, 12), .Cells(15 + i, 12)).Value = DtOFNAcional.Rows(i)("IMPORTESOL")
                        .Range(.Cells(15 + i, 13), .Cells(15 + i, 13)).Value = DtOFNAcional.Rows(i)("IMPORTEDOL")
                        .Range(.Cells(15 + i, 14), .Cells(15 + i, 14)).Value = DtOFNAcional.Rows(i)("PAIS")
                        .Range(.Cells(15 + i, 9), .Cells(15 + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        ultFila = i + 15
                    Next
                    .Range(.Cells(ultFila, 10), .Cells(ultFila, 10)).Value = "SUB TOTAL"
                    .Range(.Cells(ultFila, 10), .Cells(ultFila, 13)).Font.Bold = True
                    .Range(.Cells(ultFila, 10), .Cells(ultFila, 13)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(ultFila, 11), .Cells(ultFila, 11)).Formula = "=SUMA(K14 : K" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 12), .Cells(ultFila, 12)).Formula = "=SUMA(L14 : L" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 13), .Cells(ultFila, 13)).Formula = "=SUMA(M14 : M" & ultFila - 1 & ")"

                    .Range("D8").Formula = "=SUMA(K14 : K" & ultFila - 1 & ")"
                    .Range("E8").Formula = "=SUMA(L14 : L" & ultFila - 1 & ")"
                    .Range("F8").Formula = "=SUMA(M14 : M" & ultFila - 1 & ")"


                End If

                If DtOFExterior.Rows.Count > 0 Then

                    For i = 0 To DtOFExterior.Rows.Count - 1
                        .Range(.Cells(filasNAcional + i, 9), .Cells(filasNAcional + i, 9)).Value = DtOFExterior.Rows(i)("CODPRODUCTO")
                        .Range(.Cells(filasNAcional + i, 10), .Cells(filasNAcional + i, 10)).Value = DtOFExterior.Rows(i)("DESCRIP")
                        .Range(.Cells(filasNAcional + i, 11), .Cells(filasNAcional + i, 11)).Value = DtOFExterior.Rows(i)("CANTIDAD")
                        .Range(.Cells(filasNAcional + i, 12), .Cells(filasNAcional + i, 12)).Value = DtOFExterior.Rows(i)("IMPORTESOL")
                        .Range(.Cells(filasNAcional + i, 13), .Cells(filasNAcional + i, 13)).Value = DtOFExterior.Rows(i)("IMPORTEDOL")
                        .Range(.Cells(filasNAcional + i, 14), .Cells(filasNAcional + i, 14)).Value = DtOFExterior.Rows(i)("PAIS")
                        .Range(.Cells(filasNAcional + i, 9), .Cells(filasNAcional + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        ultFila = i + filasNAcional + 1
                    Next
                    .Range(.Cells(ultFila, 10), .Cells(ultFila, 10)).Value = "SUB TOTAL"
                    .Range(.Cells(ultFila, 10), .Cells(ultFila, 13)).Font.Bold = True
                    .Range(.Cells(ultFila, 10), .Cells(ultFila, 13)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(ultFila, 11), .Cells(ultFila, 11)).Formula = "=SUMA(K" & filasNAcional & " : K" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 12), .Cells(ultFila, 12)).Formula = "=SUMA(L" & filasNAcional & " : L" & ultFila - 1 & ")"
                    .Range(.Cells(ultFila, 13), .Cells(ultFila, 13)).Formula = "=SUMA(M" & filasNAcional & " : M" & ultFila - 1 & ")"

                    .Range("D9").Formula = "=SUMA(K" & filasNAcional & " : K" & ultFila - 1 & ")"
                    .Range("E9").Formula = "=SUMA(L" & filasNAcional & " : L" & ultFila - 1 & ")"
                    .Range("F9").Formula = "=SUMA(M" & filasNAcional & " : M" & ultFila - 1 & ")"
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarExploracion(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                '.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                '.Range("A2").Value = Me.cmbMes.Text.ToString.ToUpper & " " & txtAño.Value.ToString
                If DtExploracion.Rows.Count > 0 Then
                    For i = 0 To DtExploracion.Rows.Count - 1
                        'If GridExportacion.Rows(i).Cells("UEA").Value.ToString.Trim <> "COMPRA" Then
                        .Range(.Cells(5 + i, 11), .Cells(5 + i, 11)).Value = DtExploracion.Rows(i)("INGRESO")
                        ultFila = i + 6
                        'End If
                    Next
                    '.Range(.Cells(ultFila, 3), .Cells(ultFila, 3)).Value = "SUB TOTAL"
                    '.Range(.Cells(ultFila, 3), .Cells(ultFila, 6)).Font.Bold = True
                    '.Range(.Cells(ultFila, 3), .Cells(ultFila, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    '.Range(.Cells(ultFila, 4), .Cells(ultFila, 4)).Formula = "=SUMA(D4 : D" & ultFila - 1 & ")"
                    '.Range(.Cells(ultFila, 5), .Cells(ultFila, 5)).Formula = "=SUMA(E4 : E" & ultFila - 1 & ")"
                    '.Range(.Cells(ultFila, 6), .Cells(ultFila, 6)).Formula = "=SUMA(F4 : F" & ultFila - 1 & ")"

                    'filaCompra = ultFila + 2

                End If

            End With
        Catch ex As Exception

        End Try
    End Sub
End Class