Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class FrmReporteFinal
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Public ConceptoSeleccionado As String
    Public filtroDescripcion As String = String.Empty
#End Region
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Dim cierre As Int32

    Private Sub FrmReporteFinal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
        cmbMes.Value = Now.Date.Month
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Reporte()
    End Sub
    Sub Reporte()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dtDatos As New DataTable
            Dim dtDetMineral As New DataTable
            Dim dtDetMolienda As New DataTable
            Dim dtDetChancado As New DataTable
            Dim dtDetalle As New DataTable

            dtDatos = _objNegocio.Costo_ReportePresentacion(_objEntidad)
            dtDetMineral = _objNegocio.Costo_ReporteDetMineral(_objEntidad)
            dtDetMolienda = _objNegocio.Costo_ReporteDetMolienda(_objEntidad)
            dtDetChancado = _objNegocio.Costo_ReporteDetChancado(_objEntidad)
            dtDetalle = _objNegocio.Costo_ReporteDetalleMolienda(_objEntidad)

            'MsgBox(dtDatos.Rows.Count)
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTE_COST_PRESENTACION" & cmbMes.Value & ".xls")
                File.Copy(path & "\REPORTE_COST_PRESENTACION" & ".xls", path & "\REPORTE_COST_PRESENTACION" & cmbMes.Value & ".xls")
                m_Excel.Workbooks.Open(path & "\REPORTE_COST_PRESENTACION" & cmbMes.Value & ".xls")
                'm_Excel.Workbooks.Open(path & "\REPORTE_COST_PRESENTACION" & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                Dim objHojaExcelRuma As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
                Dim objHojaExcelMolienda As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
                Dim objHojaExcelChancado As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
                Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets.Add

                'objHojaExcel.Name = "RESUMEN"
                'm_Excel.ActiveProtectedViewWindow.Edit()
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 6
                nfilaini = 6
                Dim filaultima As Int32 = 0
                With objHojaExcel
                    .Activate()
                    .Range("D2").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    .Range("AA:AB").ColumnWidth = 0
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("A" & nfila + i).Value = "Chancado"
                        .Range("B" & nfila + i).Value = "Molienda"
                        .Range("C" & nfila + i).Value = "Mineral"
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("COD_PROD")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("PRODUCTO")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("KILOS")
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("TON")
                        .Range("I" & nfila + i).Value = dtDatos.Rows(i)("VARDIRECTO")
                        .Range("J" & nfila + i).Value = dtDatos.Rows(i)("VARINDIRECTO")
                        .Range("K" & nfila + i).Value = dtDatos.Rows(i)("FIJODIRECTO")
                        .Range("L" & nfila + i).Value = dtDatos.Rows(i)("FIJOINDIRECTO")
                        .Range("M" & nfila + i).Value = dtDatos.Rows(i)("OTRAS")
                        .Range("N" & nfila + i).Value = dtDatos.Rows(i)("CHVARDIRECTO")
                        .Range("O" & nfila + i).Value = dtDatos.Rows(i)("CHVARINDIRECTO")
                        .Range("P" & nfila + i).Value = dtDatos.Rows(i)("CHFIJODIRECTO")
                        .Range("Q" & nfila + i).Value = dtDatos.Rows(i)("CHFIJOINDIRECTO")
                        .Range("R" & nfila + i).Value = dtDatos.Rows(i)("MOVARDIRECTO")
                        .Range("S" & nfila + i).Value = dtDatos.Rows(i)("MOVARINDIRECTO")
                        .Range("T" & nfila + i).Value = dtDatos.Rows(i)("MOFIJODIRECTO")
                        .Range("U" & nfila + i).Value = dtDatos.Rows(i)("MOFIJOINDIRECTO")
                        .Range("V" & nfila + i).Value = dtDatos.Rows(i)("ENVASES")
                        .Range("W" & nfila + i).Value = dtDatos.Rows(i)("TOTVARIABLE")
                        .Range("X" & nfila + i).Value = dtDatos.Rows(i)("TOTFIJO")
                        .Range("Y" & nfila + i).Value = dtDatos.Rows(i)("TOTCOSTOPRODUCC")
                        .Range("AA" & nfila + i).Value = dtDatos.Rows(i)("GASTOSADM")
                        .Range("AB" & nfila + i).Value = dtDatos.Rows(i)("GASTOSVENTA")
                        .Range("AD" & nfila + i).Value = dtDatos.Rows(i)("COSTOTOTXTON")
                        .Range("AL" & nfila + i).Value = dtDatos.Rows(i)("COSTOXUNDENVASE")
                        '.Range(.Cells(nfila + i, 5), .Cells(nfila + i, 15)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nfila = nfila + 1
                        filaultima = nfila + i
                    Next
                End With
                nfila = 13
                nfilaini = 13
                filaultima = 0
                'm_Excel.Visible = True
                With objHojaExcelRuma
                    '.Activate()
                    '.Range("C9").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDetMineral.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDetMineral.Rows(i)("COD_PRODPDC")
                        .Range("B" & nfila + i).Value = dtDetMineral.Rows(i)("PRODUCTO")
                        .Range("C" & nfila + i).Value = dtDetMineral.Rows(i)("TIPOMATPRIMA")
                        .Range("D" & nfila + i).Value = dtDetMineral.Rows(i)("CODRUMA")
                        .Range("E" & nfila + i).Value = dtDetMineral.Rows(i)("INSUMO")
                        .Range("F" & nfila + i).Value = dtDetMineral.Rows(i)("TON_MATERIA_PRIMA")
                        .Range("G" & nfila + i).Value = dtDetMineral.Rows(i)("COSTOXTONVARD")
                        .Range("H" & nfila + i).Value = dtDetMineral.Rows(i)("CostoxTonVarI")
                        .Range("I" & nfila + i).Value = dtDetMineral.Rows(i)("CostoxTonFijoD")
                        .Range("J" & nfila + i).Value = dtDetMineral.Rows(i)("CostoxTonFijoI")
                        .Range("K" & nfila + i).Value = dtDetMineral.Rows(i)("CostoxTonOtras")
                        .Range("L" & nfila + i).Value = dtDetMineral.Rows(i)("CostoxTonRuma")
                        .Range("M" & nfila + i).Value = dtDetMineral.Rows(i)("PorcMerma")
                        .Range("N" & nfila + i).Value = dtDetMineral.Rows(i)("PorcHumedad")
                        .Range("O" & nfila + i).Value = dtDetMineral.Rows(i)("TonMermaH")
                        .Range("P" & nfila + i).Value = "=+F" & nfila + i & "+O" & nfila + i & ""
                        .Range("Q" & nfila + i).Value = "=+G" & nfila + i & "*$P" & nfila + i & ""
                        .Range("R" & nfila + i).Value = "=+H" & nfila + i & "*$P" & nfila + i & ""
                        .Range("S" & nfila + i).Value = "=+I" & nfila + i & "*$P" & nfila + i & ""
                        .Range("T" & nfila + i).Value = "=+J" & nfila + i & "*$P" & nfila + i & ""
                        .Range("U" & nfila + i).Value = "=+K" & nfila + i & "*$P" & nfila + i & ""
                        .Range("V" & nfila + i).Value = dtDetMineral.Rows(i)("TONPRODUCTO")
                        .Range("W" & nfila + i).Value = "=SUMA(Q" & nfila + i & ":U" & nfila + i & ")"
                        .Range("X" & nfila + i).Value = "=+W" & nfila + i & "/V" & nfila + i & ""
                        .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 24)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range("Z" & nfila + i).Value = dtDetMineral.Rows(i)("COSTOXTON_VAR_D")
                        .Range("AA" & nfila + i).Value = dtDetMineral.Rows(i)("COSTOXTON_VAR_I")
                        .Range("AB" & nfila + i).Value = dtDetMineral.Rows(i)("COSTOXTON_FIJ_D")
                        .Range("AC" & nfila + i).Value = dtDetMineral.Rows(i)("COSTOXTON_FIJ_I")
                        .Range("AD" & nfila + i).Value = "=SUMA(Z" & nfila + i & ":AC" & nfila + i & ")"
                        .Range("AE" & nfila + i).Value = "=+Z" & nfila + i & "*$F" & nfila + i & ""
                        .Range("AF" & nfila + i).Value = "=+AA" & nfila + i & "*$F" & nfila + i & ""
                        .Range("AG" & nfila + i).Value = "=+AB" & nfila + i & "*$F" & nfila + i & ""
                        .Range("AH" & nfila + i).Value = "=+AC" & nfila + i & "*$F" & nfila + i & ""
                        .Range("AI" & nfila + i).Value = dtDetMineral.Rows(i)("TONCHANCADO")
                        .Range(.Cells(nfila + i, 26), .Cells(nfila + i, 35)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                End With

                nfila = 16
                nfilaini = 16
                filaultima = 0
                'm_Excel.Visible = True
                With objHojaExcelMolienda
                    'MsgBox("CAYO")
                    '.Activate()
                    '.Range("C9").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDetMolienda.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDetMolienda.Rows(i)("COD_PROD")
                        .Range("B" & nfila + i).Value = dtDetMolienda.Rows(i)("EQUIPO")
                        .Range("C" & nfila + i).Value = dtDetMolienda.Rows(i)("CONCEPTO")
                        .Range("D" & nfila + i).Value = dtDetMolienda.Rows(i)("TON")
                        If dtDetMolienda.Rows(i)("FLGADM") = 1 Then
                            .Range("J" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_COSTO")
                        ElseIf dtDetMolienda.Rows(i)("FLGVTA") = 1 Then
                            .Range("K" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_COSTO")
                        Else
                            .Range("E" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_VAR_DIR")
                            .Range("F" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_VAR_IND")
                            .Range("G" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_FIJ_DIR")
                            .Range("H" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_FIJ_IND")
                        End If
                        .Range("I" & nfila + i).Value = "=SUMA(E" & nfila + i & ":H" & nfila + i & ")"
                        .Range("L" & nfila + i).Value = "=+I" & nfila + i & "+J" & nfila + i & "+K" & nfila + i & ""
                        .Range("M" & nfila + i).Value = dtDetMolienda.Rows(i)("ADMXTON")
                        .Range("N" & nfila + i).Value = dtDetMolienda.Rows(i)("VTAXTON")
                        '.Range("M" & nfila + i).Value = "=SI(J" & nfila + i & "="""","""",SI(D" & nfila + i & "=0,0,J" & nfila + i & "/D" & nfila + i & "))"
                        '.Range("N" & nfila + i).Value = "=SI(K" & nfila + i & "="""","""",SI(D" & nfila + i & "=0,0,K" & nfila + i & "/D" & nfila + i & "))"
                        .Range("O" & nfila + i).Value = dtDetMolienda.Rows(i)("TONPRODUCTO")

                        .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 15)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                End With

                nfila = 16
                nfilaini = 16
                filaultima = 0
                'm_Excel.Visible = True
                With objHojaExcelChancado
                    'MsgBox("CAYO")
                    '.Activate()
                    '.Range("C9").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDetChancado.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDetChancado.Rows(i)("COD_PROD")
                        .Range("B" & nfila + i).Value = dtDetChancado.Rows(i)("RUMA")
                        .Range("C" & nfila + i).Value = dtDetChancado.Rows(i)("EQUIPO")
                        .Range("D" & nfila + i).Value = dtDetChancado.Rows(i)("CONCEPTO")
                        .Range("E" & nfila + i).Value = dtDetChancado.Rows(i)("TON")
                        If dtDetChancado.Rows(i)("FLGADM") = 1 Then
                            .Range("K" & nfila + i).Value = dtDetChancado.Rows(i)("TOT_COSTO")
                        ElseIf dtDetChancado.Rows(i)("FLGVTA") = 1 Then
                            .Range("L" & nfila + i).Value = dtDetChancado.Rows(i)("TOT_COSTO")
                        Else
                            .Range("F" & nfila + i).Value = dtDetChancado.Rows(i)("TOT_VAR_DIR")
                            .Range("G" & nfila + i).Value = dtDetChancado.Rows(i)("TOT_VAR_IND")
                            .Range("H" & nfila + i).Value = dtDetChancado.Rows(i)("TOT_FIJ_DIR")
                            .Range("I" & nfila + i).Value = dtDetChancado.Rows(i)("TOT_FIJ_IND")
                        End If
                        .Range("J" & nfila + i).Value = dtDetChancado.Rows(i)("TOT_COSTO") '"=SUMA(F" & nfila + i & ":I" & nfila + i & ")"
                        .Range("M" & nfila + i).Value = "=+J" & nfila + i & "+K" & nfila + i & "+L" & nfila + i & ""
                        .Range("N" & nfila + i).Value = dtDetChancado.Rows(i)("ADMXTON")
                        .Range("O" & nfila + i).Value = dtDetChancado.Rows(i)("VTAXTON")
                        '.Range("M" & nfila + i).Value = "=SI(J" & nfila + i & "="""","""",SI(D" & nfila + i & "=0,0,J" & nfila + i & "/D" & nfila + i & "))"
                        '.Range("N" & nfila + i).Value = "=SI(K" & nfila + i & "="""","""",SI(D" & nfila + i & "=0,0,K" & nfila + i & "/D" & nfila + i & "))"
                        .Range("P" & nfila + i).Value = dtDetChancado.Rows(i)("TONPRODUCTO")

                        .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 16)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                End With
                nfila = 2
                objHojaExcelDetalle.Name = "Detalle costos"
                Dim totalSheets As Integer = m_Excel.ActiveWorkbook.Sheets.Count
                objHojaExcelDetalle.Move(After:=m_Excel.Worksheets(totalSheets))
                With objHojaExcelDetalle
                    .Range("B" & nfila).ColumnWidth = 15
                    .Range("C" & nfila).ColumnWidth = 25
                    .Range("D" & nfila).ColumnWidth = 45

                    .Range("A" & nfila).Value = "CODIGO"
                    .Range("B" & nfila).Value = "EQUIPO"
                    .Range("C" & nfila).Value = "CONCEPTO"
                    .Range("D" & nfila).Value = "CUENTA"
                    .Range("E" & nfila).Value = "VAR_DIR"
                    .Range("F" & nfila).Value = "VAR_IND"
                    .Range("G" & nfila).Value = "FIJ_DIR"
                    .Range("H" & nfila).Value = "FIJ_IND"
                    .Range("I" & nfila).Value = "TOTAL COSTO"
                    .Range("A" & nfila & ":I" & nfila).Font.Bold = True
                    .Range("A" & nfila & ":I" & nfila).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    nfila += 1

                    If dtDetalle.Rows.Count > 0 Then
                        For i As Int32 = 0 To dtDetalle.Rows.Count - 1
                            .Range("A" & nfila + i).Value = dtDetalle.Rows(i)("COD_PROD")
                            .Range("B" & nfila + i).Value = dtDetalle.Rows(i)("EQUIPO")
                            .Range("C" & nfila + i).Value = dtDetalle.Rows(i)("CONCEPTO")
                            .Range("D" & nfila + i).Value = dtDetalle.Rows(i)("CGCOD")
                            .Range("D" & nfila + i).NumberFormat = "@"
                            .Range("E" & nfila + i & ":I" & nfila + i).NumberFormat = "#,##0.00"
                            .Range("E" & nfila + i).Value = dtDetalle.Rows(i)("TOT_VAR_DIR")
                            .Range("F" & nfila + i).Value = dtDetalle.Rows(i)("TOT_VAR_IND")
                            .Range("G" & nfila + i).Value = dtDetalle.Rows(i)("TOT_FIJ_DIR")
                            .Range("H" & nfila + i).Value = dtDetalle.Rows(i)("TOT_FIJ_IND")
                            .Range("I" & nfila + i).Value = dtDetalle.Rows(i)("TOT_COSTO")
                        Next
                    End If
                End With
                'MsgBox("PASO3")
                m_Excel.Visible = True
            End If            
            'Call CargarUltraGridxBinding(Me.gridRevision, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
            'MsgBox(ex.ToString)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub ReporteCAL()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dtDatos As New DataTable
            Dim dtDetMatPrima As New DataTable
            Dim dtDetMolienda As New DataTable
            Dim dtDetalle As New DataTable

            dtDatos = _objNegocio.Costo_ReportePresentacionCAL(_objEntidad)
            dtDetMolienda = _objNegocio.Costo_ReporteDetMoliendaCAL(_objEntidad)
            dtDetMatPrima = _objNegocio.Costo_ReporteDetMatPrima(_objEntidad)

            dtDetalle = _objNegocio.Costo_ReporteDetalleMoliendaCAL(_objEntidad)

            'MsgBox(dtDatos.Rows.Count)
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTE_COST_PRESENTACION_CAL_" & cmbMes.Value & ".xls")
                File.Copy(path & "\REPORTE_COST_PRESENTACION_CAL" & ".xls", path & "\REPORTE_COST_PRESENTACION_CAL_" & cmbMes.Value & ".xls")
                m_Excel.Workbooks.Open(path & "\REPORTE_COST_PRESENTACION_CAL_" & cmbMes.Value & ".xls")

                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                Dim objHojaExcelRuma As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
                Dim objHojaExcelMolienda As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)

                Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets.Add

                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 6
                nfilaini = 6
                Dim filaultima As Int32 = 0
                With objHojaExcel
                    .Activate()
                    .Range("D2").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("B" & nfila + i).Value = "Molienda"
                        .Range("C" & nfila + i).Value = "Materia Prima"
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("COD_PROD")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("PRODUCTO")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("KILOS")
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("TON")
                        .Range("R" & nfila + i).Value = dtDatos.Rows(i)("VARDIRECTO")
                        .Range("S" & nfila + i).Value = dtDatos.Rows(i)("MOVARDIRECTO")
                        .Range("T" & nfila + i).Value = dtDatos.Rows(i)("MOVARINDIRECTO")
                        .Range("U" & nfila + i).Value = dtDatos.Rows(i)("MOFIJODIRECTO")
                        .Range("V" & nfila + i).Value = dtDatos.Rows(i)("MOFIJOINDIRECTO")
                        .Range("W" & nfila + i).Value = dtDatos.Rows(i)("ENVASES")
                        .Range("X" & nfila + i).Value = dtDatos.Rows(i)("TOTVARIABLE")
                        .Range("Y" & nfila + i).Value = dtDatos.Rows(i)("TOTFIJO")
                        .Range("Z" & nfila + i).Value = dtDatos.Rows(i)("TOTCOSTOPRODUCC")
                        .Range("AB" & nfila + i).Value = dtDatos.Rows(i)("GASTOSADM")
                        .Range("AC" & nfila + i).Value = dtDatos.Rows(i)("GASTOSVENTA")
                        .Range("AE" & nfila + i).Value = dtDatos.Rows(i)("COSTOTOTXTON")
                        .Range("AM" & nfila + i).Value = dtDatos.Rows(i)("COSTOXUNDENVASE")
                        filaultima = nfila + i
                    Next
                End With
                nfila = 16
                nfilaini = 16
                filaultima = 0
                With objHojaExcelRuma
                    For i As Int16 = 0 To dtDetMatPrima.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDetMatPrima.Rows(i)("COD_PROD")
                        .Range("B" & nfila + i).Value = dtDetMatPrima.Rows(i)("PRODUCTO")
                        .Range("C" & nfila + i).Value = dtDetMatPrima.Rows(i)("TON")
                        .Range("D" & nfila + i).Value = dtDetMatPrima.Rows(i)("CANT_MERMA")
                        .Range("E" & nfila + i).Value = dtDetMatPrima.Rows(i)("TIPO_MATPRIMA")
                        .Range("F" & nfila + i).Value = dtDetMatPrima.Rows(i)("COD_MATPRIMA")
                        .Range("G" & nfila + i).Value = dtDetMatPrima.Rows(i)("MAT_PRIMA")
                        .Range("H" & nfila + i).Value = dtDetMatPrima.Rows(i)("CANT_CONSUMIDA")
                        .Range("I" & nfila + i).Value = dtDetMatPrima.Rows(i)("COSTOXTON")
                        .Range("J" & nfila + i).Value = dtDetMatPrima.Rows(i)("COSTOTOTAL")
                        .Range(.Cells(nfila + i, 26), .Cells(nfila + i, 34)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    Next
                End With

                nfila = 16
                nfilaini = 16
                filaultima = 0
                With objHojaExcelMolienda
                    For i As Int16 = 0 To dtDetMolienda.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDetMolienda.Rows(i)("COD_PROD")
                        .Range("B" & nfila + i).Value = dtDetMolienda.Rows(i)("EQUIPO")
                        .Range("C" & nfila + i).Value = dtDetMolienda.Rows(i)("CONCEPTO")
                        .Range("D" & nfila + i).Value = dtDetMolienda.Rows(i)("TON")
                        If dtDetMolienda.Rows(i)("FLGADM") = 1 Then
                            .Range("J" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_COSTO")
                        ElseIf dtDetMolienda.Rows(i)("FLGVTA") = 1 Then
                            .Range("K" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_COSTO")
                        Else
                            .Range("E" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_VAR_DIR")
                            .Range("F" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_VAR_IND")
                            .Range("G" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_FIJ_DIR")
                            .Range("H" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_FIJ_IND")
                        End If
                        .Range("I" & nfila + i).Value = "=SUMA(E" & nfila + i & ":H" & nfila + i & ")"
                        .Range("L" & nfila + i).Value = "=+I" & nfila + i & "+J" & nfila + i & "+K" & nfila + i & ""
                        .Range("M" & nfila + i).Value = dtDetMolienda.Rows(i)("ADMXTON")
                        .Range("N" & nfila + i).Value = dtDetMolienda.Rows(i)("VTAXTON")
                        .Range("O" & nfila + i).Value = dtDetMolienda.Rows(i)("TONPRODUCTO")

                        .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 15)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                End With
                nfila = 2
                objHojaExcelDetalle.Name = "Detalle costos"
                Dim totalSheets As Integer = m_Excel.ActiveWorkbook.Sheets.Count
                objHojaExcelDetalle.Move(After:=m_Excel.Worksheets(totalSheets))
                With objHojaExcelDetalle
                    .Range("B" & nfila).ColumnWidth = 15
                    .Range("C" & nfila).ColumnWidth = 25
                    .Range("D" & nfila).ColumnWidth = 45

                    .Range("A" & nfila).Value = "CODIGO"
                    .Range("B" & nfila).Value = "EQUIPO"
                    .Range("C" & nfila).Value = "CONCEPTO"
                    .Range("D" & nfila).Value = "CUENTA"
                    .Range("E" & nfila).Value = "VAR_DIR"
                    .Range("F" & nfila).Value = "VAR_IND"
                    .Range("G" & nfila).Value = "FIJ_DIR"
                    .Range("H" & nfila).Value = "FIJ_IND"
                    .Range("I" & nfila).Value = "TOTAL COSTO"
                    .Range("A" & nfila & ":I" & nfila).Font.Bold = True
                    .Range("A" & nfila & ":I" & nfila).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    nfila += 1

                    If dtDetalle.Rows.Count > 0 Then
                        For i As Int32 = 0 To dtDetalle.Rows.Count - 1
                            .Range("A" & nfila + i).Value = dtDetalle.Rows(i)("COD_PROD")
                            .Range("B" & nfila + i).Value = dtDetalle.Rows(i)("EQUIPO")
                            .Range("C" & nfila + i).Value = dtDetalle.Rows(i)("CONCEPTO")
                            .Range("D" & nfila + i).Value = dtDetalle.Rows(i)("CGCOD")
                            .Range("D" & nfila + i).NumberFormat = "@"
                            .Range("E" & nfila + i & ":I" & nfila + i).NumberFormat = "#,##0.00"
                            .Range("E" & nfila + i).Value = dtDetalle.Rows(i)("TOT_VAR_DIR")
                            .Range("F" & nfila + i).Value = dtDetalle.Rows(i)("TOT_VAR_IND")
                            .Range("G" & nfila + i).Value = dtDetalle.Rows(i)("TOT_FIJ_DIR")
                            .Range("H" & nfila + i).Value = dtDetalle.Rows(i)("TOT_FIJ_IND")
                            .Range("I" & nfila + i).Value = dtDetalle.Rows(i)("TOT_COSTO")
                        Next
                    End If
                End With

                m_Excel.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ReporteCAL()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ReporteTERRAZO()
    End Sub
    Sub ReporteTERRAZO()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dtDatos As New DataTable
            Dim dtDetMatPrima As New DataTable
            Dim dtDetMolienda As New DataTable
            Dim dtDetalle As New DataTable

            dtDatos = _objNegocio.Costo_ReportePresentacionTERRAZO(_objEntidad)
            'dtDetMineral = _objNegocio.Costo_ReporteDetMineral(_objEntidad)
            dtDetMolienda = _objNegocio.Costo_ReporteDetMoliendaTERRAZO(_objEntidad)
            dtDetMatPrima = _objNegocio.Costo_ReporteDetMatPrimaTERRAZO(_objEntidad)
            dtDetalle = _objNegocio.Costo_ReporteDetalleMoliendaTERRAZO(_objEntidad)
            'MsgBox(dtDatos.Rows.Count)
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTE_COST_PRESENTACION_TERRAZO_" & cmbMes.Value & ".xls")
                File.Copy(path & "\REPORTE_COST_PRESENTACION_TERRAZO" & ".xls", path & "\REPORTE_COST_PRESENTACION_TERRAZO_" & cmbMes.Value & ".xls")
                m_Excel.Workbooks.Open(path & "\REPORTE_COST_PRESENTACION_TERRAZO_" & cmbMes.Value & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                Dim objHojaExcelRuma As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
                Dim objHojaExcelMolienda As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
                Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets.Add
                'objHojaExcel.Name = "RESUMEN"
                'm_Excel.ActiveProtectedViewWindow.Edit()
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 6
                nfilaini = 6
                Dim filaultima As Int32 = 0
                With objHojaExcel
                    .Activate()
                    .Range("D2").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("B" & nfila + i).Value = "Molienda"
                        .Range("C" & nfila + i).Value = "Materia Prima"
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("COD_PROD")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("PRODUCTO")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("KILOS")
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("TON")
                        '.Range("I" & nfila + i).Value = dtDatos.Rows(i)("VARDIRECTO")
                        '.Range("J" & nfila + i).Value = dtDatos.Rows(i)("VARINDIRECTO")
                        '.Range("K" & nfila + i).Value = dtDatos.Rows(i)("FIJODIRECTO")
                        '.Range("L" & nfila + i).Value = dtDatos.Rows(i)("FIJOINDIRECTO")
                        '.Range("M" & nfila + i).Value = dtDatos.Rows(i)("OTRAS")
                        '.Range("N" & nfila + i).Value = dtDatos.Rows(i)("CHVARDIRECTO")
                        '.Range("O" & nfila + i).Value = dtDatos.Rows(i)("CHVARINDIRECTO")
                        '.Range("P" & nfila + i).Value = dtDatos.Rows(i)("CHFIJODIRECTO")
                        .Range("R" & nfila + i).Value = dtDatos.Rows(i)("VARDIRECTO")
                        .Range("S" & nfila + i).Value = dtDatos.Rows(i)("MOVARDIRECTO")
                        .Range("T" & nfila + i).Value = dtDatos.Rows(i)("MOVARINDIRECTO")
                        .Range("U" & nfila + i).Value = dtDatos.Rows(i)("MOFIJODIRECTO")
                        .Range("V" & nfila + i).Value = dtDatos.Rows(i)("MOFIJOINDIRECTO")
                        .Range("W" & nfila + i).Value = dtDatos.Rows(i)("ENVASES")
                        .Range("X" & nfila + i).Value = dtDatos.Rows(i)("TOTVARIABLE")
                        .Range("Y" & nfila + i).Value = dtDatos.Rows(i)("TOTFIJO")
                        .Range("Z" & nfila + i).Value = dtDatos.Rows(i)("TOTCOSTOPRODUCC")
                        .Range("AB" & nfila + i).Value = dtDatos.Rows(i)("GASTOSADM")
                        .Range("AC" & nfila + i).Value = dtDatos.Rows(i)("GASTOSVENTA")
                        .Range("AE" & nfila + i).Value = dtDatos.Rows(i)("COSTOTOTXTON")
                        .Range("AM" & nfila + i).Value = dtDatos.Rows(i)("COSTOXUNDENVASE")
                        '.Range(.Cells(nfila + i, 5), .Cells(nfila + i, 15)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nfila = nfila + 1
                        filaultima = nfila + i
                    Next
                End With
                nfila = 16
                nfilaini = 16
                filaultima = 0
                'm_Excel.Visible = True
                With objHojaExcelRuma
                    '.Activate()
                    '.Range("C9").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDetMatPrima.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDetMatPrima.Rows(i)("COD_PROD")
                        .Range("B" & nfila + i).Value = dtDetMatPrima.Rows(i)("PRODUCTO")
                        .Range("C" & nfila + i).Value = dtDetMatPrima.Rows(i)("TON")
                        .Range("D" & nfila + i).Value = dtDetMatPrima.Rows(i)("CANT_MERMA")
                        .Range("E" & nfila + i).Value = dtDetMatPrima.Rows(i)("TIPO_MATPRIMA")
                        .Range("F" & nfila + i).Value = dtDetMatPrima.Rows(i)("COD_MATPRIMA")
                        .Range("G" & nfila + i).Value = dtDetMatPrima.Rows(i)("MAT_PRIMA")
                        .Range("H" & nfila + i).Value = dtDetMatPrima.Rows(i)("CANT_CONSUMIDA")
                        .Range("I" & nfila + i).Value = dtDetMatPrima.Rows(i)("COSTOXTON")
                        .Range("J" & nfila + i).Value = dtDetMatPrima.Rows(i)("COSTOTOTAL")
                        .Range(.Cells(nfila + i, 26), .Cells(nfila + i, 34)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'filaultima = nfila + i
                    Next
                End With

                nfila = 16
                nfilaini = 16
                filaultima = 0
                'm_Excel.Visible = True
                With objHojaExcelMolienda
                    'MsgBox("CAYO")
                    '.Activate()
                    '.Range("C9").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDetMolienda.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDetMolienda.Rows(i)("COD_PROD")
                        .Range("B" & nfila + i).Value = dtDetMolienda.Rows(i)("EQUIPO")
                        .Range("C" & nfila + i).Value = dtDetMolienda.Rows(i)("CONCEPTO")
                        .Range("D" & nfila + i).Value = dtDetMolienda.Rows(i)("TON")
                        If dtDetMolienda.Rows(i)("FLGADM") = 1 Then
                            .Range("J" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_COSTO")
                        ElseIf dtDetMolienda.Rows(i)("FLGVTA") = 1 Then
                            .Range("K" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_COSTO")
                        Else
                            .Range("E" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_VAR_DIR")
                            .Range("F" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_VAR_IND")
                            .Range("G" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_FIJ_DIR")
                            .Range("H" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_FIJ_IND")
                        End If
                        .Range("I" & nfila + i).Value = "=SUMA(E" & nfila + i & ":H" & nfila + i & ")"
                        .Range("L" & nfila + i).Value = "=+I" & nfila + i & "+J" & nfila + i & "+K" & nfila + i & ""
                        .Range("M" & nfila + i).Value = dtDetMolienda.Rows(i)("ADMXTON")
                        .Range("N" & nfila + i).Value = dtDetMolienda.Rows(i)("VTAXTON")
                        '.Range("M" & nfila + i).Value = "=SI(J" & nfila + i & "="""","""",SI(D" & nfila + i & "=0,0,J" & nfila + i & "/D" & nfila + i & "))"
                        '.Range("N" & nfila + i).Value = "=SI(K" & nfila + i & "="""","""",SI(D" & nfila + i & "=0,0,K" & nfila + i & "/D" & nfila + i & "))"
                        .Range("O" & nfila + i).Value = dtDetMolienda.Rows(i)("TONPRODUCTO")

                        .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 15)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                End With

                nfila = 2
                objHojaExcelDetalle.Name = "Detalle costos"
                Dim totalSheets As Integer = m_Excel.ActiveWorkbook.Sheets.Count
                objHojaExcelDetalle.Move(After:=m_Excel.Worksheets(totalSheets))
                With objHojaExcelDetalle
                    .Range("B" & nfila).ColumnWidth = 15
                    .Range("C" & nfila).ColumnWidth = 25
                    .Range("D" & nfila).ColumnWidth = 45

                    .Range("A" & nfila).Value = "CODIGO"
                    .Range("B" & nfila).Value = "EQUIPO"
                    .Range("C" & nfila).Value = "CONCEPTO"
                    .Range("D" & nfila).Value = "CUENTA"
                    .Range("E" & nfila).Value = "VAR_DIR"
                    .Range("F" & nfila).Value = "VAR_IND"
                    .Range("G" & nfila).Value = "FIJ_DIR"
                    .Range("H" & nfila).Value = "FIJ_IND"
                    .Range("I" & nfila).Value = "TOTAL COSTO"
                    .Range("A" & nfila & ":I" & nfila).Font.Bold = True
                    .Range("A" & nfila & ":I" & nfila).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    nfila += 1

                    If dtDetalle.Rows.Count > 0 Then
                        For i As Int32 = 0 To dtDetalle.Rows.Count - 1
                            .Range("A" & nfila + i).Value = dtDetalle.Rows(i)("COD_PROD")
                            .Range("B" & nfila + i).Value = dtDetalle.Rows(i)("EQUIPO")
                            .Range("C" & nfila + i).Value = dtDetalle.Rows(i)("CONCEPTO")
                            .Range("D" & nfila + i).Value = dtDetalle.Rows(i)("CGCOD")
                            .Range("D" & nfila + i).NumberFormat = "@"
                            .Range("E" & nfila + i & ":I" & nfila + i).NumberFormat = "#,##0.00"
                            .Range("E" & nfila + i).Value = dtDetalle.Rows(i)("TOT_VAR_DIR")
                            .Range("F" & nfila + i).Value = dtDetalle.Rows(i)("TOT_VAR_IND")
                            .Range("G" & nfila + i).Value = dtDetalle.Rows(i)("TOT_FIJ_DIR")
                            .Range("H" & nfila + i).Value = dtDetalle.Rows(i)("TOT_FIJ_IND")
                            .Range("I" & nfila + i).Value = dtDetalle.Rows(i)("TOT_COSTO")
                        Next
                    End If
                End With

                'MsgBox("PASO3")
                m_Excel.Visible = True
            End If
            'Call CargarUltraGridxBinding(Me.gridRevision, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
            'MsgBox(ex.ToString)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ReportePASTAS()
    End Sub
    Sub ReportePASTAS()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dtDatos As New DataTable
            Dim dtDetMatPrima As New DataTable
            Dim dtDetMolienda As New DataTable
            Dim dtDetalle As New DataTable
            dtDatos = _objNegocio.Costo_ReportePresentacionPASTAS(_objEntidad)
            'dtDetMineral = _objNegocio.Costo_ReporteDetMineral(_objEntidad)
            dtDetMolienda = _objNegocio.Costo_ReporteDetMoliendaPASTAS(_objEntidad)
            dtDetMatPrima = _objNegocio.Costo_ReporteDetMatPrimaPASTAS(_objEntidad)
            dtDetalle = _objNegocio.Costo_ReporteDetalleMoliendaPASTAS(_objEntidad)

            'MsgBox(dtDatos.Rows.Count)
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTE_COST_PRESENTACION_PASTAS_" & cmbMes.Value & ".xls")
                File.Copy(path & "\REPORTE_COST_PRESENTACION_PASTAS" & ".xls", path & "\REPORTE_COST_PRESENTACION_PASTAS_" & cmbMes.Value & ".xls")
                m_Excel.Workbooks.Open(path & "\REPORTE_COST_PRESENTACION_PASTAS_" & cmbMes.Value & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                Dim objHojaExcelRuma As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
                Dim objHojaExcelMolienda As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
                Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets.Add

                'objHojaExcel.Name = "RESUMEN"
                'm_Excel.ActiveProtectedViewWindow.Edit()
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 6
                nfilaini = 6
                Dim filaultima As Int32 = 0
                With objHojaExcel
                    .Activate()
                    .Range("D2").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("B" & nfila + i).Value = "Molienda"
                        .Range("C" & nfila + i).Value = "Materia Prima"
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("COD_PROD")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("PRODUCTO")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("KILOS")
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("TON")
                        '.Range("I" & nfila + i).Value = dtDatos.Rows(i)("VARDIRECTO")
                        '.Range("J" & nfila + i).Value = dtDatos.Rows(i)("VARINDIRECTO")
                        '.Range("K" & nfila + i).Value = dtDatos.Rows(i)("FIJODIRECTO")
                        '.Range("L" & nfila + i).Value = dtDatos.Rows(i)("FIJOINDIRECTO")
                        '.Range("M" & nfila + i).Value = dtDatos.Rows(i)("OTRAS")
                        '.Range("N" & nfila + i).Value = dtDatos.Rows(i)("CHVARDIRECTO")
                        '.Range("O" & nfila + i).Value = dtDatos.Rows(i)("CHVARINDIRECTO")
                        '.Range("P" & nfila + i).Value = dtDatos.Rows(i)("CHFIJODIRECTO")
                        .Range("R" & nfila + i).Value = dtDatos.Rows(i)("VARDIRECTO")
                        .Range("S" & nfila + i).Value = dtDatos.Rows(i)("MOVARDIRECTO")
                        .Range("T" & nfila + i).Value = dtDatos.Rows(i)("MOVARINDIRECTO")
                        .Range("U" & nfila + i).Value = dtDatos.Rows(i)("MOFIJODIRECTO")
                        .Range("V" & nfila + i).Value = dtDatos.Rows(i)("MOFIJOINDIRECTO")
                        .Range("W" & nfila + i).Value = dtDatos.Rows(i)("ENVASES")
                        .Range("X" & nfila + i).Value = dtDatos.Rows(i)("TOTVARIABLE")
                        .Range("Y" & nfila + i).Value = dtDatos.Rows(i)("TOTFIJO")
                        .Range("Z" & nfila + i).Value = dtDatos.Rows(i)("TOTCOSTOPRODUCC")
                        .Range("AB" & nfila + i).Value = dtDatos.Rows(i)("GASTOSADM")
                        .Range("AC" & nfila + i).Value = dtDatos.Rows(i)("GASTOSVENTA")
                        .Range("AE" & nfila + i).Value = dtDatos.Rows(i)("COSTOTOTXTON")
                        .Range("AM" & nfila + i).Value = dtDatos.Rows(i)("COSTOXUNDENVASE")
                        '.Range(.Cells(nfila + i, 5), .Cells(nfila + i, 15)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nfila = nfila + 1
                        filaultima = nfila + i
                    Next
                End With
                nfila = 16
                nfilaini = 16
                filaultima = 0
                'm_Excel.Visible = True
                With objHojaExcelRuma
                    '.Activate()
                    '.Range("C9").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDetMatPrima.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDetMatPrima.Rows(i)("COD_PROD")
                        .Range("B" & nfila + i).Value = dtDetMatPrima.Rows(i)("PRODUCTO")
                        .Range("C" & nfila + i).Value = dtDetMatPrima.Rows(i)("TON")
                        .Range("D" & nfila + i).Value = dtDetMatPrima.Rows(i)("CANT_MERMA")
                        .Range("E" & nfila + i).Value = dtDetMatPrima.Rows(i)("TIPO_MATPRIMA")
                        .Range("F" & nfila + i).Value = dtDetMatPrima.Rows(i)("COD_MATPRIMA")
                        .Range("G" & nfila + i).Value = dtDetMatPrima.Rows(i)("MAT_PRIMA")
                        .Range("H" & nfila + i).Value = dtDetMatPrima.Rows(i)("CANT_CONSUMIDA")
                        .Range("I" & nfila + i).Value = dtDetMatPrima.Rows(i)("COSTOXTON")
                        .Range("J" & nfila + i).Value = dtDetMatPrima.Rows(i)("COSTOTOTAL")
                        .Range(.Cells(nfila + i, 26), .Cells(nfila + i, 34)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'filaultima = nfila + i
                    Next
                End With

                nfila = 16
                nfilaini = 16
                filaultima = 0
                'm_Excel.Visible = True
                With objHojaExcelMolienda
                    'MsgBox("CAYO")
                    '.Activate()
                    '.Range("C9").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDetMolienda.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDetMolienda.Rows(i)("COD_PROD")
                        .Range("B" & nfila + i).Value = dtDetMolienda.Rows(i)("EQUIPO")
                        .Range("C" & nfila + i).Value = dtDetMolienda.Rows(i)("CONCEPTO")
                        .Range("D" & nfila + i).Value = dtDetMolienda.Rows(i)("TON")
                        If dtDetMolienda.Rows(i)("FLGADM") = 1 Then
                            .Range("J" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_COSTO")
                        ElseIf dtDetMolienda.Rows(i)("FLGVTA") = 1 Then
                            .Range("K" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_COSTO")
                        Else
                            .Range("E" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_VAR_DIR")
                            .Range("F" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_VAR_IND")
                            .Range("G" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_FIJ_DIR")
                            .Range("H" & nfila + i).Value = dtDetMolienda.Rows(i)("TOT_FIJ_IND")
                        End If
                        .Range("I" & nfila + i).Value = "=SUMA(E" & nfila + i & ":H" & nfila + i & ")"
                        .Range("L" & nfila + i).Value = "=+I" & nfila + i & "+J" & nfila + i & "+K" & nfila + i & ""
                        .Range("M" & nfila + i).Value = dtDetMolienda.Rows(i)("ADMXTON")
                        .Range("N" & nfila + i).Value = dtDetMolienda.Rows(i)("VTAXTON")
                        '.Range("M" & nfila + i).Value = "=SI(J" & nfila + i & "="""","""",SI(D" & nfila + i & "=0,0,J" & nfila + i & "/D" & nfila + i & "))"
                        '.Range("N" & nfila + i).Value = "=SI(K" & nfila + i & "="""","""",SI(D" & nfila + i & "=0,0,K" & nfila + i & "/D" & nfila + i & "))"
                        .Range("O" & nfila + i).Value = dtDetMolienda.Rows(i)("TONPRODUCTO")

                        .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 15)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                End With

                nfila = 2
                objHojaExcelDetalle.Name = "Detalle costos"
                Dim totalSheets As Integer = m_Excel.ActiveWorkbook.Sheets.Count
                objHojaExcelDetalle.Move(After:=m_Excel.Worksheets(totalSheets))
                With objHojaExcelDetalle
                    .Range("B" & nfila).ColumnWidth = 15
                    .Range("C" & nfila).ColumnWidth = 25
                    .Range("D" & nfila).ColumnWidth = 45

                    .Range("A" & nfila).Value = "CODIGO"
                    .Range("B" & nfila).Value = "EQUIPO"
                    .Range("C" & nfila).Value = "CONCEPTO"
                    .Range("D" & nfila).Value = "CUENTA"
                    .Range("E" & nfila).Value = "VAR_DIR"
                    .Range("F" & nfila).Value = "VAR_IND"
                    .Range("G" & nfila).Value = "FIJ_DIR"
                    .Range("H" & nfila).Value = "FIJ_IND"
                    .Range("I" & nfila).Value = "TOTAL COSTO"
                    .Range("A" & nfila & ":I" & nfila).Font.Bold = True
                    .Range("A" & nfila & ":I" & nfila).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    nfila += 1

                    If dtDetalle.Rows.Count > 0 Then
                        For i As Int32 = 0 To dtDetalle.Rows.Count - 1
                            .Range("A" & nfila + i).Value = dtDetalle.Rows(i)("COD_PROD")
                            .Range("B" & nfila + i).Value = dtDetalle.Rows(i)("EQUIPO")
                            .Range("C" & nfila + i).Value = dtDetalle.Rows(i)("CONCEPTO")
                            .Range("D" & nfila + i).Value = dtDetalle.Rows(i)("CGCOD")
                            .Range("D" & nfila + i).NumberFormat = "@"
                            .Range("E" & nfila + i & ":I" & nfila + i).NumberFormat = "#,##0.00"
                            .Range("E" & nfila + i).Value = dtDetalle.Rows(i)("TOT_VAR_DIR")
                            .Range("F" & nfila + i).Value = dtDetalle.Rows(i)("TOT_VAR_IND")
                            .Range("G" & nfila + i).Value = dtDetalle.Rows(i)("TOT_FIJ_DIR")
                            .Range("H" & nfila + i).Value = dtDetalle.Rows(i)("TOT_FIJ_IND")
                            .Range("I" & nfila + i).Value = dtDetalle.Rows(i)("TOT_COSTO")
                        Next
                    End If
                End With

                m_Excel.Visible = True
            End If
            'Call CargarUltraGridxBinding(Me.gridRevision, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
            'MsgBox(ex.ToString)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
End Class