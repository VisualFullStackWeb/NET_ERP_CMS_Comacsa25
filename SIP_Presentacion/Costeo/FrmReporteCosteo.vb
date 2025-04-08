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
Imports System.Data
Imports System.Data.OleDb

Public Class FrmReporteCosteo
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
    Private Sub FrmReporteCosteo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If User_Sistema = "JCRUZ" Or User_Sistema = "GDAYAN" Then
            btnmanoobra.Enabled = False
            btncosto.Enabled = False
            btncierre.Enabled = False
            'btnimportar.Enabled = False
        Else
            btnmanoobra.Enabled = True
            btncosto.Enabled = True
            btncierre.Enabled = True
            'btnimportar.Enabled = True
        End If

        txtayo.Value = Now.Date.Year
        cmbMes.Value = Now.Date.Month
        VerificaCierre()
    End Sub
    Sub diasHabiles()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        Dim dtDias As New DataTable
        dtDias = _objNegocio.Costo_DiasHabiles(_objEntidad)
        Call CargarUltraGridxBinding(Me.gridDias, Source3, dtDias)
    End Sub
    Sub SeguroLey()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        Dim dtSeguro As New DataTable
        dtSeguro = _objNegocio.Costo_Seguro(_objEntidad)
        Call CargarUltraGridxBinding(Me.gridSeguro, Source4, dtSeguro)
    End Sub
    Private Sub btnmanoobra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmanoobra.Click
        gbmanoobra.Visible = True
        diasHabiles()
        SeguroLey()
        gbrevision.Visible = False
        gbrevision.Refresh()
        Dim dtObrero As New DataTable
        Dim dtEmpleado As New DataTable
        Dim dtProrrateo As New DataTable
        Dim dtProrrateo2 As New DataTable
        Dim dtDetallemolPer As New DataTable

        Dim dtDetallemolProd As New DataTable
        Dim dtDetallechancadora As New DataTable


        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        Dim dtValidacion As New DataTable
        dtValidacion = _objNegocio.Costo_Validacion(_objEntidad)
        If dtValidacion.Rows(0)(0) <> "OK" Then
            MsgBox(dtValidacion.Rows(0)(0), MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        If MsgBox("Dese generar reporte", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        Try
            VerificaCierre()
            If cierre = 0 Then
                If Not ProcesaCierre() Then Exit Sub
            End If
            'VerificaCierre()
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()

            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dsDatos As New DataSet
            dsDatos = _objNegocio.Costo_ManoObra(_objEntidad)
            dtObrero = dsDatos.Tables(0)
            dtEmpleado = dsDatos.Tables(1)
            dtProrrateo = dsDatos.Tables(2)
            dtProrrateo2 = dsDatos.Tables(3)
            dtDetallemolPer = dsDatos.Tables(4)
            dtDetallemolProd = dsDatos.Tables(5)
            dtDetallechancadora = dsDatos.Tables(6)

            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim libro_excel As Microsoft.Office.Interop.Excel.Workbook = Nothing
            Dim h_hoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing

            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\REPORTE_MANOOBRA_" & cmbMes.Text & ".xls")
            File.Copy(RutaReporteERP & "PLANTILLA_MANOOBRA.xls", path & "\REPORTE_MANOOBRA_" & cmbMes.Text & ".xls")
            'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            Dim aa As String
            aa = path & "\REPORTE_MANOOBRA_" & cmbMes.Text & ".xls"
            m_Excel.Workbooks.Open(path & "\REPORTE_MANOOBRA_" & cmbMes.Text & ".xls")

            m_Excel.DisplayAlerts = False
            Dim objHojaExcelIngreso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcelEmpleado As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            Dim objHojaExcelProrratear As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            Dim objHojaExcelProrratear2 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)

            Dim objHojaExcelMolPer As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(5)
            Dim objHojaExcelMolProd As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(6)
            Dim objHojaExcelChancadora As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(7)

            Dim objHojaExcelDetMolPer As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(8)
            Dim objHojaExcelDetMolProd As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(9)
            Dim objHojaExcelDetChancadora As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(10)

            exportarObrero(objHojaExcelIngreso, dtObrero)
            exportarEmpleado(objHojaExcelEmpleado, dtEmpleado)
            exportarProrratear(objHojaExcelProrratear, dtProrrateo)
            exportarProrratear2(objHojaExcelProrratear2, dtProrrateo2)
            exportarMolper(objHojaExcelMolPer, dtDetallemolPer, m_Excel)
            exportarMolprod(objHojaExcelMolProd, dtDetallemolProd, m_Excel)
            exportarChancadora(objHojaExcelChancadora, dtDetallechancadora, m_Excel)

            objHojaExcelIngreso.Activate()
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

    Sub CrearTablaDinamica()
    End Sub

    Sub exportarObrero(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 15
            Dim nfilaini As Integer = 15
            Dim filaultima As Integer = 15

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                Dim nmes As Int32 = 0
                .Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("COD_PER")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("CENTROCOSTO")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("NOMBRE")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("TOTALING")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("TOTALAPO")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("HORASFACTOR")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("ESCOLARIDAD")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("PROVCTS")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("PROVVACA")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("PROVGRATI")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("SEGVIDA")
                    .Range(.Cells(nfila + i, 12), .Cells(nfila + i, 12)).Value = dt.Rows(i)("SEGPERSONAL")
                    .Range(.Cells(nfila + i, 13), .Cells(nfila + i, 13)).Value = dt.Rows(i)("TOTAL")
                    .Range(.Cells(nfila + i, 14), .Cells(nfila + i, 14)).Value = dt.Rows(i)("FINGRESO")
                    filaultima = filaultima + 1
                Next
                'filaultima += 1
                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 4)).Formula = "=SUMA(D15:D" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 5)).Formula = "=SUMA(E15:E" & filaultima & ")"

                .Range(.Cells(filaultima + 1, 7), .Cells(filaultima + 1, 7)).Formula = "=SUMA(G15:G" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 8), .Cells(filaultima + 1, 8)).Formula = "=SUMA(H15:H" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 9), .Cells(filaultima + 1, 9)).Formula = "=SUMA(I15:I" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 10)).Formula = "=SUMA(J15:J" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 11), .Cells(filaultima + 1, 11)).Formula = "=SUMA(K15:K" & filaultima & ")"

                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 5)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(filaultima + 1, 7), .Cells(filaultima + 1, 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(filaultima + 1, 7), .Cells(filaultima + 1, 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 11)).Font.Bold = True

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarEmpleado(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 14
            Dim nfilaini As Integer = 14
            Dim filaultima As Integer = 14

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0
                .Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("COD_PER")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("CENTROCOSTO")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("NOMBRE")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("TOTALING")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("TOTALAPO")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("HORASFACTOR")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("ESCOLARIDAD")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("PROVCTS")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("PROVVACA")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("PROVGRATI")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("SEGVIDA")
                    .Range(.Cells(nfila + i, 12), .Cells(nfila + i, 12)).Value = dt.Rows(i)("SEGPERSONAL")
                    .Range(.Cells(nfila + i, 13), .Cells(nfila + i, 13)).Value = dt.Rows(i)("TOTAL")
                    .Range(.Cells(nfila + i, 14), .Cells(nfila + i, 14)).Value = dt.Rows(i)("FINGRESO")
                    filaultima = filaultima + 1
                Next
                'filaultima += 1
                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 4)).Formula = "=SUMA(D14:D" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 5)).Formula = "=SUMA(E14:E" & filaultima & ")"

                .Range(.Cells(filaultima + 1, 7), .Cells(filaultima + 1, 7)).Formula = "=SUMA(G14:G" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 8), .Cells(filaultima + 1, 8)).Formula = "=SUMA(H14:H" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 9), .Cells(filaultima + 1, 9)).Formula = "=SUMA(I14:I" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 10)).Formula = "=SUMA(J14:J" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 11), .Cells(filaultima + 1, 11)).Formula = "=SUMA(K14:K" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 12), .Cells(filaultima + 1, 12)).Formula = "=SUMA(L14:L" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 13), .Cells(filaultima + 1, 13)).Formula = "=SUMA(M14:M" & filaultima & ")"

                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 5)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(filaultima + 1, 7), .Cells(filaultima + 1, 13)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(filaultima + 1, 7), .Cells(filaultima + 1, 13)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 13)).Font.Bold = True

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarProrratear(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 14
            Dim nfilaini As Integer = 14
            Dim filaultima As Integer = 14

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0
                .Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("CENTROCOSTO")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("COD_PER")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("NOMBRE")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("HORASEFECTIVAS")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("HORASPAGADAS")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("SOLESPORHORA")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("HORASMES")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("TOPEHORAS")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("HORASPRORRATEAR")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("SOLESPRODUCCION")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("SOLESPRORRATEAR")
                    filaultima = filaultima + 1
                Next
                'filaultima += 1
                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 4)).Formula = "=SUMA(D14:D" & filaultima & ")"
                '.Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 5)).Formula = "=SUMA(E5:E" & filaultima & ")"

                '.Range(.Cells(filaultima + 1, 7), .Cells(filaultima + 1, 7)).Formula = "=SUMA(G5:G" & filaultima & ")"
                '.Range(.Cells(filaultima + 1, 8), .Cells(filaultima + 1, 8)).Formula = "=SUMA(H5:H" & filaultima & ")"
                '.Range(.Cells(filaultima + 1, 9), .Cells(filaultima + 1, 9)).Formula = "=SUMA(I5:I" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 10)).Formula = "=SUMA(J14:J" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 11), .Cells(filaultima + 1, 11)).Formula = "=SUMA(K14:K" & filaultima & ")"

                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 4)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 4)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 11)).Font.Bold = True

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarProrratear2(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 19
            Dim nfilaini As Integer = 19
            Dim filaultima As Integer = 19

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0
                .Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("COD_PER")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("CENTROCOSTO")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("NOMBRE")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("TOTALING")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("TOTALAPO")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("HORASFACTOR")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("ESCOLARIDAD")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("PROVCTS")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("PROVVACA")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("PROVGRATI")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("SEGVIDA")
                    .Range(.Cells(nfila + i, 12), .Cells(nfila + i, 12)).Value = dt.Rows(i)("SOLESPORHORA")
                    .Range(.Cells(nfila + i, 13), .Cells(nfila + i, 13)).Value = dt.Rows(i)("HORASMES")
                    .Range(.Cells(nfila + i, 14), .Cells(nfila + i, 14)).Value = dt.Rows(i)("HORASFACTOR")
                    .Range(.Cells(nfila + i, 15), .Cells(nfila + i, 15)).Value = dt.Rows(i)("HORASTOPE")
                    .Range(.Cells(nfila + i, 16), .Cells(nfila + i, 16)).Value = dt.Rows(i)("SOLESPRORRATEAR")
                    filaultima = filaultima + 1
                Next
                'filaultima += 1
                '.Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 4)).Formula = "=SUMA(D5:D" & filaultima & ")"
                '.Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 5)).Formula = "=SUMA(E5:E" & filaultima & ")"

                '.Range(.Cells(filaultima + 1, 7), .Cells(filaultima + 1, 7)).Formula = "=SUMA(G5:G" & filaultima & ")"
                '.Range(.Cells(filaultima + 1, 8), .Cells(filaultima + 1, 8)).Formula = "=SUMA(H5:H" & filaultima & ")"
                '.Range(.Cells(filaultima + 1, 9), .Cells(filaultima + 1, 9)).Formula = "=SUMA(I5:I" & filaultima & ")"
                '.Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 10)).Formula = "=SUMA(J5:J" & filaultima & ")"
                .Range(.Cells(filaultima + 1, 16), .Cells(filaultima + 1, 16)).Formula = "=SUMA(P19:P" & filaultima & ")"

                '.Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                '.Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 5)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(filaultima + 1, 16), .Cells(filaultima + 1, 16)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(filaultima + 1, 16), .Cells(filaultima + 1, 16)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 16)).Font.Bold = True

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarDetMolper(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 2
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0
                '.Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("codtipo")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("DIA")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("TURNO")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("COD_PER")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("NUMDOC")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("COD_EQUIPO")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("COSTEAR")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("SolesPorHora")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("nrohrs")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("HORASEF")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("ValorBi")
                    .Range(.Cells(nfila + i, 12), .Cells(nfila + i, 12)).Value = dt.Rows(i)("EQUIPO")
                    .Range(.Cells(nfila + i, 13), .Cells(nfila + i, 13)).Value = dt.Rows(i)("NOMBRE")
                    filaultima = filaultima + 1
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarDetMolprod(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 2
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0
                '.Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("COD_EQUIPO")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("NUMDOC")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("COD_PROD")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("TON")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("TONBI")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("PORCENTAJE")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("VALORBI")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("VALOR")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("CODTIPO")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("EQUIPO")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("PRODUCTO")
                    .Range(.Cells(nfila + i, 12), .Cells(nfila + i, 12)).Value = dt.Rows(i)("PLANTA")
                    .Range(.Cells(nfila + i, 13), .Cells(nfila + i, 13)).Value = dt.Rows(i)("CLASE")
                    filaultima = filaultima + 1
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarDetChancadora(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 2
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0
                '.Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("PLANTA")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("DIA")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("COD_CHANCADORA")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("EQUIPO")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("COD_RUMA")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("RUMA")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("TON")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("VALORMES")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("TONMES")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("VALORRUMA")
                    filaultima = filaultima + 1
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarMolper(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable, ByVal m_excel As Microsoft.Office.Interop.Excel.Application)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 2
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                Dim Sql As String
                If cierre = 0 Then
                    Sql = "uSp_Costo_mano_obra_produccion '01'," & txtayo.Value & "," & cmbMes.Value & ",'PL'"
                Else
                    Sql = "select CODTIPO,DIA,TURNO,COD_PER,NUMDOC,COD_EQUIPO,COSTEAR,SOLESPORHORA,NROHRS,HORASEF," & _
                    "VALORBI,EQUIPO,NOMBRE from Tbl_Cost_Mo_Molino_Personal " & _
                    "where ayo=" & txtayo.Value & " and mes=" & cmbMes.Value & ""
                End If
                With m_excel.ActiveWorkbook.PivotCaches.Create(Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlExternal)

                    Dim sCnx As String

                    sCnx = "OLEDB;Provider=SQLOLEDB.1;Use Procedure for Prepare=1;Use Encryption for Data=False;Auto Translate=True;" & _
                    "Password =" & PASSINI & ";" & _
                    "Persist Security Info=False;" & _
                    "User ID=" & USERINI & ";" & _
                    "Initial Catalog=" & BDINI & ";" & _
                    "Data Source=" & DATASOURCE & ""

                    .Connection = sCnx
                    .CommandType = Microsoft.Office.Interop.Excel.XlCmdType.xlCmdSql
                    .CommandText = Sql

                    .CreatePivotTable(TableDestination:=m_excel.ActiveWorkbook.ActiveSheet.Range("A3"), TableName:="Tabla dinámica1")
                End With

                With m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1")
                    'With .PivotFields("Centro_Costo")
                    '    .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                    '    .Position = 1
                    '    .Name = "Centro_Costo"
                    'End With

                    With .PivotFields("EQUIPO")
                        .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 1
                    End With

                    With .PivotFields("NOMBRE")
                        .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 2
                    End With

                    .AddDataField(.PivotFields("HORASEF"), "Suma de HORASEF", Excel.XlConsolidationFunction.xlSum)
                    m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("Suma de HORASEF").NumberFormat = "#,##0.00"

                    .AddDataField(.PivotFields("ValorBi"), "Suma de ValorBi", Excel.XlConsolidationFunction.xlSum)
                    m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("Suma de ValorBi").NumberFormat = "#,##0.00"

                End With
            End With
            m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").SubtotalLocation(Excel.XlSubtototalLocationType.xlAtBottom)

        Catch ex As Exception

        End Try
    End Sub

    Sub exportarMolprod(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable, ByVal m_excel As Microsoft.Office.Interop.Excel.Application)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 2
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                Dim Sql As String
                If cierre = 0 Then
                    Sql = "uSp_Costo_mano_obra_produccion '01'," & txtayo.Value & "," & cmbMes.Value & ",'PM'"
                Else
                    Sql = "select COD_EQUIPO,NUMDOC,COD_PROD,TON,TONBI,PORCENTAJE,VALORBI,VALOR,CODTIPO," & _
                    "EQUIPO,PRODUCTO,PLANTA,CLASE from Tbl_Cost_Mo_Molino_Producto " & _
                    "where ayo=" & txtayo.Value & " and mes=" & cmbMes.Value & ""
                End If
                With m_excel.ActiveWorkbook.PivotCaches.Create(Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlExternal)

                    Dim sCnx As String

                    sCnx = "OLEDB;Provider=SQLOLEDB.1;Use Procedure for Prepare=1;Use Encryption for Data=False;Auto Translate=True;" & _
                    "Password =" & PASSINI & ";" & _
                    "Persist Security Info=False;" & _
                    "User ID=" & USERINI & ";" & _
                    "Initial Catalog=" & BDINI & ";" & _
                    "Data Source=" & DATASOURCE & ""

                    .Connection = sCnx
                    .CommandType = Microsoft.Office.Interop.Excel.XlCmdType.xlCmdSql
                    .CommandText = Sql

                    .CreatePivotTable(TableDestination:=m_excel.ActiveWorkbook.ActiveSheet.Range("A3"), TableName:="Tabla dinámica2")
                End With

                With m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica2")
                    With .PivotFields("PLANTA")
                        .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                        .Position = 1
                        .Name = "PLANTA"
                    End With

                    With .PivotFields("CLASE")
                        .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                        .Position = 2
                        .Name = "CLASE"
                    End With

                    With .PivotFields("EQUIPO")
                        .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 1
                    End With

                    With .PivotFields("PRODUCTO")
                        .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 2
                    End With

                    .AddDataField(.PivotFields("TON"), "Suma de TON", Excel.XlConsolidationFunction.xlSum)
                    m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica2").PivotFields("Suma de TON").NumberFormat = "#,##0.00"

                    .AddDataField(.PivotFields("VALOR"), "Suma de VALOR", Excel.XlConsolidationFunction.xlSum)
                    m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica2").PivotFields("Suma de VALOR").NumberFormat = "#,##0.00"

                End With
            End With
            'm_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").ColumnGrand = False
            m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica2").SubtotalLocation(Excel.XlSubtototalLocationType.xlAtBottom)

        Catch ex As Exception

        End Try
    End Sub

    Sub exportarChancadora(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable, ByVal m_excel As Microsoft.Office.Interop.Excel.Application)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 2
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                Dim Sql As String
                If cierre = 0 Then
                    Sql = "uSp_Costo_mano_obra_produccion '01'," & txtayo.Value & "," & cmbMes.Value & ",'CH'"
                Else
                    Sql = "select PLANTA,DIA,COD_CHANCADORA,EQUIPO,COD_RUMA,RUMA,TON,VALORMES,TONMES,VALORRUMA from Tbl_Cost_Mo_Chancadoras " & _
                    "where ayo=" & txtayo.Value & " and mes=" & cmbMes.Value & ""
                End If
                With m_excel.ActiveWorkbook.PivotCaches.Create(Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlExternal)

                    Dim sCnx As String

                    sCnx = "OLEDB;Provider=SQLOLEDB.1;Use Procedure for Prepare=1;Use Encryption for Data=False;Auto Translate=True;" & _
                    "Password =" & PASSINI & ";" & _
                    "Persist Security Info=False;" & _
                    "User ID=" & USERINI & ";" & _
                    "Initial Catalog=" & BDINI & ";" & _
                    "Data Source=" & DATASOURCE & ""

                    .Connection = sCnx
                    .CommandType = Microsoft.Office.Interop.Excel.XlCmdType.xlCmdSql
                    .CommandText = Sql

                    .CreatePivotTable(TableDestination:=m_excel.ActiveWorkbook.ActiveSheet.Range("A3"), TableName:="Tabla dinámica3")
                End With

                With m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica3")
                    With .PivotFields("PLANTA")
                        .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                        .Position = 1
                        .Name = "PLANTA"
                    End With

                    'With .PivotFields("CLASE")
                    '    .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                    '    .Position = 2
                    '    .Name = "CLASE"
                    'End With

                    With .PivotFields("EQUIPO")
                        .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 1
                    End With

                    With .PivotFields("RUMA")
                        .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 2
                    End With

                    .AddDataField(.PivotFields("TON"), "Suma de TON", Excel.XlConsolidationFunction.xlSum)
                    m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica3").PivotFields("Suma de TON").NumberFormat = "#,##0.00"

                    .AddDataField(.PivotFields("VALORRUMA"), "Suma de VALORRUMA", Excel.XlConsolidationFunction.xlSum)
                    m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica3").PivotFields("Suma de VALORRUMA").NumberFormat = "#,##0.00"

                End With
                'm_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").ColumnGrand = False
                'm_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica3").SubtotalLocation(Excel.XlSubtototalLocationType.xlAtBottom)

                For I As Int32 = 5 To 100
                    If .Range(.Cells(I, 3), .Cells(I, 3)).Value = 0 Then
                        Exit For
                    End If
                    .Range(.Cells(I, 4), .Cells(I, 4)).Value = "=C" & I & "/B" & I & ""
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub

    Function nombreMEs(ByVal mes As Int32) As String
        Select Case mes
            Case 1
                Return "ENERO"
            Case 2
                Return "FEBRERO"
            Case 3
                Return "MARZO"
            Case 4
                Return "ABRIL"
            Case 5
                Return "MAYO"
            Case 6
                Return "JUNIO"
            Case 7
                Return "JULIO"
            Case 8
                Return "AGOSTO"
            Case 9
                Return "SETIEMBRE"
            Case 10
                Return "OCTUBRE"
            Case 11
                Return "NOVIEMBRE"
            Case Else
                Return "DICIEMBRE"
        End Select
        Return ""
    End Function

    Private Sub btncierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncierre.Click
        Try
            Dim msg As String = ""
            If cierre = 1 Then
                msg = "Desea reabrir mes?"
            Else
                msg = "Desea realizar cierre de mes?"
            End If
            If MsgBox(msg, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                If ProcesaCierre() Then
                    MsgBox("Operación realizada con exito", MsgBoxStyle.Information, msgComacsa)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub
    Function ProcesaCierre() As Boolean
        lblmensaje.Text = "Procesando Datos..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        _objEntidad.User_Crea = User_Sistema
        Dim dtCierre As New DataTable
        dtCierre = _objNegocio.Costo_Cierre(_objEntidad)
        If dtCierre.Rows(0)(0) = "OK" Then
            VerificaCierre()
            Return True
        Else
            MsgBox(dtCierre.Rows(0)(0))
            Return False
        End If
    End Function

    Sub VerificaCierre()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        Dim dtCierre As New DataTable
        dtCierre = _objNegocio.Costo_VerificaCierre(_objEntidad)
        cierre = dtCierre.Rows(0)(0)
        If cierre = 1 Then
            btncierre.Text = "Reabrir Mes"
        Else
            btncierre.Text = "Cierre Mes"
        End If
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            VerificaCierre()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrevision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrevision.Click
        gbrevision.Visible = True
        gbmanoobra.Visible = False
        CargaRevision()
    End Sub
    Sub CargaRevision()
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
            dtDatos = _objNegocio.Costo_RevisionCantera(_objEntidad)
            Call CargarUltraGridxBinding(Me.gridRevision, Source1, dtDatos)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Sub exportarRevCantera()

        Dim archivo_excel As New Microsoft.Office.Interop.Excel.Application
        Dim libro_excel As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim h_hoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing

        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()

            libro_excel = archivo_excel.Workbooks.Add
            h_hoja = libro_excel.Worksheets.Add
            h_hoja.Visible = True : h_hoja.Activate()

            'With h_hoja
            '.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
            '.Activate()
            Dim Sql As String
            Dim SpSql As String
            'If cierre = 0 Then
            'If chkCuenta9.Checked Then
            'SpSql = "Usp_Cont_Minas_Canteras_Cta9 "
            'Else
            SpSql = "Usp_Cont_Minas_Canteras "
            'End If

            Sql = SpSql & " " & txtayo.Value & "," & cmbMes.Value

            'Else
            '    Sql = "select PLANTA,DIA,COD_CHANCADORA,EQUIPO,COD_RUMA,RUMA,TON,VALORMES,TONMES,VALORRUMA from Tbl_Cost_Mo_Chancadoras " & _
            '    "where ayo=" & txtayo.Value & " and mes=" & cmbMes.Value & ""
            'End If
            With libro_excel.PivotCaches.Create(Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlExternal)

                Dim sCnx As String

                sCnx = "OLEDB;Provider=SQLOLEDB.1;Use Procedure for Prepare=1;Use Encryption for Data=False;Auto Translate=True;" & _
                "Password =" & PASSINI & ";" & _
                "Persist Security Info=False;" & _
                "User ID=" & USERINI & ";" & _
                "Initial Catalog=" & BDINI & ";" & _
                "Data Source=" & DATASOURCE & ""

                .Connection = sCnx
                .CommandType = Microsoft.Office.Interop.Excel.XlCmdType.xlCmdSql
                .CommandText = Sql

                .CreatePivotTable(TableDestination:=libro_excel.ActiveSheet.Range("A3"), TableName:="Tabla dinámica1")
            End With

            With libro_excel.ActiveSheet.PivotTables("Tabla dinámica1")
                'With .PivotFields("PLANTA")
                '    .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                '    .Position = 1
                '    .Name = "PLANTA"
                'End With

                'With .PivotFields("CLASE")
                '    .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                '    .Position = 2
                '    .Name = "CLASE"
                'End With

                'With .PivotFields("CODCANTERA")
                '    .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                '    .Position = 1
                'End With

                With .PivotFields("CANTERA")
                    .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                    .Position = 1
                End With

                .AddDataField(.PivotFields("IMPORTE"), "Suma de IMPORTE", Excel.XlConsolidationFunction.xlSum)
                libro_excel.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("Suma de IMPORTE").NumberFormat = "#,##0.00"

                .AddDataField(.PivotFields("TONELADAS"), "Suma de TONELADAS", Excel.XlConsolidationFunction.xlSum)
                libro_excel.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("Suma de TONELADAS").NumberFormat = "#,##0.00"

                'libro_excel.ActiveSheet.PivotTables("Tabla dinámica1").ColumnGrand = False
                'libro_excel.ActiveSheet.PivotTables("Tabla dinámica1").SubtotalLocation(Excel.XlSubtototalLocationType.xlAtBottom)

                h_hoja.Visible = True
                archivo_excel.Visible = True

                libro_excel = Nothing
                archivo_excel = Nothing
                'End With
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        Try
            exportarRevCantera()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridRevision_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridRevision.DoubleClickRow
        Try
            If gridRevision.ActiveRow.Cells("idconmay").Value <> 0 Then
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                lblmensaje.Text = "Procesando Datos..."
                lblmensaje.Visible = True
                lblmensaje.Refresh()
                Dim frm As New FrmCambiaCantera
                frm.ayo = txtayo.Value
                frm.mes = cmbMes.Value
                frm.idconmay = gridRevision.ActiveRow.Cells("idconmay").Value
                Dim RESUL As DialogResult
                RESUL = frm.ShowDialog
                'frm.ShowDialog()
                If RESUL = Windows.Forms.DialogResult.OK Then
                    CargaRevision()
                End If
            End If
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub

    Private Sub btncosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncosto.Click
        gbrevision.Visible = False
        gbmanoobra.Visible = False
        gbrevision.Refresh()
        Dim dtMatrizGral As New DataTable
        Dim dtMatrizSust As New DataTable
        Dim dtCostoMin As New DataTable
        Dim dtCostoRuma As New DataTable
        Dim dtProductos As New DataTable
        Dim dtFlete As New DataTable

        Try
            VerificaCierre()
            If cierre = 0 Then
                If Not ProcesaCierre() Then Exit Sub
            End If
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dsDatos As New DataSet
            dsDatos = _objNegocio.Costo_CostoMineral(_objEntidad)
            'Exit Sub
            dtMatrizGral = dsDatos.Tables(0)
            dtMatrizSust = dsDatos.Tables(1)
            dtCostoMin = dsDatos.Tables(2)
            dtCostoRuma = dsDatos.Tables(3)
            dtProductos = dsDatos.Tables(4)
            dtFlete = dsDatos.Tables(5)

            'Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            'Dim libro_excel As Microsoft.Office.Interop.Excel.Workbook = Nothing
            'Dim h_hoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing

            Dim path As String
            path = Application.StartupPath
            'File.Delete(path & "\REPORTE_COSTO_MINERAL_" & cmbMes.Text & ".xls")
            'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            'm_Excel.Workbooks.Open(path & "\REPORTE_COSTO_MINERAL_" & cmbMes.Text & ".xls")
            Dim ruta As String = path & "\REPORTE_COSTO_MINERAL_" & cmbMes.Text & ".xls"
            Call CargarUltraGridxBinding(Me.gridcostomin, Source2, dsDatos.Tables(0))
            'UltraGridExcelExporter1.FileLimitBehaviour = ExcelExport.FileLimitBehaviour.ThrowException
            Me.UltraGridExcelExporter1.Export(gridcostomin, ruta)

            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            'Abrimos el archivo
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            '' ''poner cabecera antes de abrir
            ''If b_imprimir_cabecera = True Then Call poner_cabecera_archivo_excel(archivoexcel)
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook
            xApp.Worksheets.add()
            xApp.Worksheets.add()
            xApp.Worksheets.add()
            xApp.Worksheets.add()
            xApp.Worksheets.add()
            xApp.Worksheets.add()

            Dim objHojaExcelConcepto As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)

            '.NumberFormat = "###,##0.00"
            Dim objHojaExcelMatrizSust As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(2)
            Dim objHojaExcelCostoMin As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(3)
            Dim objHojaExcelCostoRuma As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(4)
            Dim objHojaExcelProductos As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(5)
            Dim objHojaExcelMatrizGral As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(7)
            Dim objHojaExcelFlete As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(6)

            objHojaExcelMatrizGral.Name = "MATRIZ_GRAL"
            exportarConceptos(objHojaExcelConcepto, dtMatrizGral, xApp)
            objHojaExcelConcepto.Name = "CONCEPTOS"
            objHojaExcelConcepto.Columns("A").ColumnWidth = 40
            objHojaExcelConcepto.Range("A1:D10000").Font.Size = 9

            objHojaExcelMatrizSust.Name = "MATRIZ_SUSTENTO"
            objHojaExcelMatrizSust.Range("A1:A10000").NumberFormat = "@"
            objHojaExcelMatrizSust.Range("D2:E10000").NumberFormat = "###0.00"
            objHojaExcelMatrizSust.Range("G2:G10000").NumberFormat = "###0.00"
            objHojaExcelMatrizSust.Range("A1:J10000").Font.Size = 9
            objHojaExcelMatrizSust.Range("A1:J1").Font.Bold = True
            objHojaExcelMatrizSust.Range("A1:J1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            exportarMatrizSust(objHojaExcelMatrizSust, dtMatrizSust)


            objHojaExcelCostoMin.Name = "COSTO_MINERAL"
            objHojaExcelCostoMin.Range("A1:A10000").NumberFormat = "@"
            objHojaExcelCostoMin.Range("AB1:AB10000").NumberFormat = "@"
            objHojaExcelCostoMin.Range("E2:AA10000").NumberFormat = "###0.00"
            objHojaExcelCostoMin.Range("A1:AB10000").Font.Size = 9
            objHojaExcelCostoMin.Range("A1:AB1").Font.Bold = True
            objHojaExcelCostoMin.Range("A1:AB1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            objHojaExcelCostoMin.Columns("Q").ColumnWidth = 0
            objHojaExcelCostoMin.Columns("R").ColumnWidth = 0
            objHojaExcelCostoMin.Columns("S").ColumnWidth = 0
            objHojaExcelCostoMin.Columns("T").ColumnWidth = 0
            objHojaExcelCostoMin.Columns("W").ColumnWidth = 0
            objHojaExcelCostoMin.Columns("X").ColumnWidth = 0
            objHojaExcelCostoMin.Columns("Y").ColumnWidth = 0
            objHojaExcelCostoMin.Columns("Z").ColumnWidth = 0
            objHojaExcelCostoMin.Columns("AA").ColumnWidth = 0
            exportarCostoMin(objHojaExcelCostoMin, dtCostoMin)

            objHojaExcelCostoRuma.Name = "COSTO_RUMA"
            objHojaExcelCostoRuma.Range("A1:A10000").NumberFormat = "@"
            'objHojaExcelCostoRuma.Range("Y1:Y10000").NumberFormat = "@"
            objHojaExcelCostoRuma.Range("C2:Q10000").NumberFormat = "###0.00"
            objHojaExcelCostoRuma.Range("A1:Q10000").Font.Size = 9
            objHojaExcelCostoRuma.Range("A1:Q1").Font.Bold = True
            objHojaExcelCostoRuma.Range("A1:Q1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            objHojaExcelCostoRuma.Columns("K").ColumnWidth = 0
            objHojaExcelCostoRuma.Columns("L").ColumnWidth = 0
            objHojaExcelCostoRuma.Columns("M").ColumnWidth = 0
            objHojaExcelCostoRuma.Columns("N").ColumnWidth = 0

            exportarCostoRuma(objHojaExcelCostoRuma, dtCostoRuma)

            objHojaExcelProductos.Name = "PRODUCTOS"
            objHojaExcelProductos.Range("A1:A10000").NumberFormat = "@"
            objHojaExcelProductos.Range("D1:D10000").NumberFormat = "@"
            objHojaExcelProductos.Range("F2:O10000").NumberFormat = "###0.00"
            objHojaExcelProductos.Range("A1:O10000").Font.Size = 9
            objHojaExcelProductos.Range("A1:O1").Font.Bold = True
            objHojaExcelProductos.Range("A1:O1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            exportarProductos(objHojaExcelProductos, dtProductos)


            objHojaExcelFlete.Name = "DETALLE FLETE"
            objHojaExcelFlete.Range("A1:A10000").NumberFormat = "@"
            objHojaExcelFlete.Range("C1:N10000").NumberFormat = "@"
            objHojaExcelFlete.Range("F2:H10000").NumberFormat = "###0.00"
            objHojaExcelFlete.Range("O2:O10000").NumberFormat = "###0.00"
            objHojaExcelFlete.Range("A1:O1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            objHojaExcelProductos.Range("A1:O10000").Font.Size = 9
            exportarCostoFlete(objHojaExcelFlete, dtFlete)

            objHojaExcelMatrizGral.Select()
            objHojaExcelMatrizGral.Move(Before:=xApp.Worksheets(2))

            xApp.Visible = True

            Exit Sub
            'm_Excel.DisplayAlerts = False
            'Dim objHojaExcelConcepto As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            ''Dim objHojaExcelMatrizGral As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            'Dim objHojaExcelMatrizSust As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            'Dim objHojaExcelCostoMin As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
            'Dim objHojaExcelCostoRuma As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(5)
            'Dim objHojaExcelProductos As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(6)


            'exportarConceptos(objHojaExcelConcepto, dtMatrizGral, m_Excel)
            ''exportarMatrizGral(objHojaExcelMatrizGral, dtMatrizGral)
            'exportarMatrizSust(objHojaExcelMatrizSust, dtMatrizSust)
            'exportarCostoMin(objHojaExcelCostoMin, dtCostoMin)
            'exportarCostoRuma(objHojaExcelCostoRuma, dtCostoRuma)
            'exportarProductos(objHojaExcelProductos, dtProductos)

            'objHojaExcelConcepto.Activate()
            'm_Excel.Visible = True
            'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub
    Private Sub Abrir_Archivo(ByVal ruta As String)
       
    End Sub
    Sub exportarConceptos(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable, ByVal m_excel As Microsoft.Office.Interop.Excel.Application)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 2
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                Dim Sql As String
                Sql = "Usp_Minas_Costo_Mineral " & txtayo.Value & "," & cmbMes.Value & ",'D'"
                With m_excel.ActiveWorkbook.PivotCaches.Create(Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlExternal)

                    Dim sCnx As String

                    sCnx = "OLEDB;Provider=SQLOLEDB.1;Use Procedure for Prepare=1;Use Encryption for Data=False;Auto Translate=True;" & _
                    "Password =" & PASSINI & ";" & _
                    "Persist Security Info=False;" & _
                    "User ID=" & USERINI & ";" & _
                    "Initial Catalog=" & BDINI & ";" & _
                    "Data Source=" & DATASOURCE & ""

                    .Connection = sCnx
                    .CommandType = Microsoft.Office.Interop.Excel.XlCmdType.xlCmdSql
                    .CommandText = Sql

                    .CreatePivotTable(TableDestination:=m_excel.ActiveWorkbook.ActiveSheet.Range("A3"), TableName:="Tabla dinámica1")
                End With

                With m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1")
                    With .PivotFields("CODCANTERA")
                        .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                        .Position = 1
                        .Name = "CODCANTERA"
                    End With
                    With .PivotFields("CONSIDERAR")
                        .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                        .Position = 2
                        .Name = "CONSIDERAR"
                    End With
                    With .PivotFields("PRODUCCION")
                        .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                        .Position = 3
                        .Name = "PRODUCCION"
                    End With
                    With .PivotFields("TIPOREPORTE")
                        .Orientation = Excel.XlPivotFieldOrientation.xlColumnField
                        .Position = 1
                    End With
                    With .PivotFields("MES")
                        .Orientation = Excel.XlPivotFieldOrientation.xlColumnField
                        .Position = 2
                    End With

                    With .PivotFields("CONCEPTO")
                        .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 1
                    End With

                    .AddDataField(.PivotFields("IMPORTE"), "Suma de IMPORTE", Excel.XlConsolidationFunction.xlSum)
                    m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("Suma de IMPORTE").NumberFormat = "#,##0.00"

                End With
            End With

            m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").SubtotalLocation(Excel.XlSubtototalLocationType.xlAtBottom)

        Catch ex As Exception

        End Try
    End Sub

    Sub exportarMatrizGral(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 2
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0
                '.Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("AYO")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("MES")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("CODCANTERA")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("CANTERA")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("IDCONCEPTO")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("CONCEPTO")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("IMPORTE")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("ORDEN")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("FLAG")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("FLAGCONTA")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("CONSIDERAR")
                    .Range(.Cells(nfila + i, 12), .Cells(nfila + i, 12)).Value = dt.Rows(i)("TIPOREPORTE")
                    .Range(.Cells(nfila + i, 13), .Cells(nfila + i, 13)).Value = dt.Rows(i)("FIJOVAR")
                    .Range(.Cells(nfila + i, 14), .Cells(nfila + i, 14)).Value = dt.Rows(i)("PRODUCCION")
                    filaultima = filaultima + 1
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarMatrizSust(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 1
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0

                .Range(.Cells(nfilaini, 1), .Cells(nfilaini, 1)).Value = "codcantera"
                .Range(.Cells(nfilaini, 2), .Cells(nfilaini, 2)).Value = "idconcepto"
                .Range(.Cells(nfilaini, 3), .Cells(nfilaini, 3)).Value = "flagconta"
                .Range(.Cells(nfilaini, 4), .Cells(nfilaini, 4)).Value = "Distribuido"
                .Range(.Cells(nfilaini, 5), .Cells(nfilaini, 5)).Value = "SinDistribuir"
                .Range(.Cells(nfilaini, 6), .Cells(nfilaini, 6)).Value = "fijovar"
                .Range(.Cells(nfilaini, 7), .Cells(nfilaini, 7)).Value = "Importe"
                .Range(.Cells(nfilaini, 8), .Cells(nfilaini, 8)).Value = "OtrasCanteras"
                .Range(.Cells(nfilaini, 9), .Cells(nfilaini, 9)).Value = "Cantera"
                .Range(.Cells(nfilaini, 10), .Cells(nfilaini, 10)).Value = "Concepto"

                '.Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("CODCANTERA")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("IDCONCEPTO")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("FLAGCONTA")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("DISTRIBUIDO")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("SINDISTRIBUIR")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("FIJOVAR")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("IMPORTE")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("OTRASCANTERAS")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("CANTERA")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("CONCEPTO")
                    filaultima = filaultima + 1
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarCostoMin(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 1
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0
                '.Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                .Range(.Cells(nfilaini, 1), .Cells(nfilaini, 1)).Value = "CodCantera"
                .Range(.Cells(nfilaini, 2), .Cells(nfilaini, 2)).Value = "Cantera"
                .Range(.Cells(nfilaini, 3), .Cells(nfilaini, 3)).Value = "cod_matprima"
                .Range(.Cells(nfilaini, 4), .Cells(nfilaini, 4)).Value = "Materia_Prima"
                .Range(.Cells(nfilaini, 5), .Cells(nfilaini, 5)).Value = "Toneladas"
                .Range(.Cells(nfilaini, 6), .Cells(nfilaini, 6)).Value = "Extr_Comp"
                .Range(.Cells(nfilaini, 7), .Cells(nfilaini, 7)).Value = "Lavado"
                .Range(.Cells(nfilaini, 8), .Cells(nfilaini, 8)).Value = "Carguio"
                .Range(.Cells(nfilaini, 9), .Cells(nfilaini, 9)).Value = "PriBajada"
                .Range(.Cells(nfilaini, 10), .Cells(nfilaini, 10)).Value = "Flete"
                .Range(.Cells(nfilaini, 11), .Cells(nfilaini, 11)).Value = "Regalias"
                .Range(.Cells(nfilaini, 12), .Cells(nfilaini, 12)).Value = "DirectoV"
                .Range(.Cells(nfilaini, 13), .Cells(nfilaini, 13)).Value = "DirectoF"
                .Range(.Cells(nfilaini, 14), .Cells(nfilaini, 14)).Value = "IndirectoV"
                .Range(.Cells(nfilaini, 15), .Cells(nfilaini, 15)).Value = "IndirectoF"
                .Range(.Cells(nfilaini, 16), .Cells(nfilaini, 16)).Value = "OTRAS"
                .Range(.Cells(nfilaini, 17), .Cells(nfilaini, 17)).Value = "DirectoOtrasV"
                .Range(.Cells(nfilaini, 18), .Cells(nfilaini, 18)).Value = "DirectoOtrasF"
                .Range(.Cells(nfilaini, 19), .Cells(nfilaini, 19)).Value = "IndirectoOtrasV"
                .Range(.Cells(nfilaini, 20), .Cells(nfilaini, 20)).Value = "IndirectoOtrasF"
                .Range(.Cells(nfilaini, 21), .Cells(nfilaini, 21)).Value = "CostoMineral"
                .Range(.Cells(nfilaini, 22), .Cells(nfilaini, 22)).Value = "Costo_Ton"
                .Range(.Cells(nfilaini, 23), .Cells(nfilaini, 23)).Value = "Porc"
                .Range(.Cells(nfilaini, 24), .Cells(nfilaini, 24)).Value = "TotalExtComp"
                .Range(.Cells(nfilaini, 25), .Cells(nfilaini, 25)).Value = "TotalFlete"
                .Range(.Cells(nfilaini, 26), .Cells(nfilaini, 26)).Value = "TotalRegalia"
                .Range(.Cells(nfilaini, 27), .Cells(nfilaini, 27)).Value = "TotalCantera"
                .Range(.Cells(nfilaini, 28), .Cells(nfilaini, 28)).Value = "CodRuma"
                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("CODCANTERA")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("CANTERA")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("COD_MATPRIMA")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("MATERIA_PRIMA")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("TONELADAS")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("EXTR_COMP")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("LAVADO")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("CARGUIO")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("PRIBAJADA")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("FLETE")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("REGALIAS")
                    .Range(.Cells(nfila + i, 12), .Cells(nfila + i, 12)).Value = dt.Rows(i)("DIRECTOV")
                    .Range(.Cells(nfila + i, 13), .Cells(nfila + i, 13)).Value = dt.Rows(i)("DIRECTOF")
                    .Range(.Cells(nfila + i, 14), .Cells(nfila + i, 14)).Value = dt.Rows(i)("INDIRECTOV")
                    .Range(.Cells(nfila + i, 15), .Cells(nfila + i, 15)).Value = dt.Rows(i)("INDIRECTOF")

                    .Range(.Cells(nfila + i, 17), .Cells(nfila + i, 17)).Value = dt.Rows(i)("DIRECTOOTRASV")
                    .Range(.Cells(nfila + i, 18), .Cells(nfila + i, 18)).Value = dt.Rows(i)("DIRECTOOTRASF")
                    .Range(.Cells(nfila + i, 19), .Cells(nfila + i, 19)).Value = dt.Rows(i)("INDIRECTOOTRASV")
                    .Range(.Cells(nfila + i, 20), .Cells(nfila + i, 20)).Value = dt.Rows(i)("INDIRECTOOTRASF")

                    .Range(.Cells(nfila + i, 21), .Cells(nfila + i, 21)).Value = dt.Rows(i)("COSTOMINERAL")
                    .Range(.Cells(nfila + i, 22), .Cells(nfila + i, 22)).Value = dt.Rows(i)("COSTO_TON")
                    .Range(.Cells(nfila + i, 23), .Cells(nfila + i, 23)).Value = dt.Rows(i)("PORC")
                    .Range(.Cells(nfila + i, 24), .Cells(nfila + i, 24)).Value = dt.Rows(i)("TotalExtComp")
                    .Range(.Cells(nfila + i, 25), .Cells(nfila + i, 25)).Value = dt.Rows(i)("TotalFlete")
                    .Range(.Cells(nfila + i, 26), .Cells(nfila + i, 26)).Value = dt.Rows(i)("TotalRegalia")
                    .Range(.Cells(nfila + i, 27), .Cells(nfila + i, 27)).Value = dt.Rows(i)("TotalCantera")
                    .Range(.Cells(nfila + i, 28), .Cells(nfila + i, 28)).Value = dt.Rows(i)("CODRUMA")

                    .Range(.Cells(nfila + i, 16), .Cells(nfila + i, 16)).Value = "=SUMA(Q" & i + nfila & ":T" & i + nfila & ")"

                    filaultima = filaultima + 1
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarCostoFlete(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 1
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0
                '.Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                .Range(.Cells(nfilaini, 1), .Cells(nfilaini, 1)).Value = "Billete"
                .Range(.Cells(nfilaini, 2), .Cells(nfilaini, 2)).Value = "Fecha"
                .Range(.Cells(nfilaini, 3), .Cells(nfilaini, 3)).Value = "Código"
                .Range(.Cells(nfilaini, 4), .Cells(nfilaini, 4)).Value = "Cantera"
                .Range(.Cells(nfilaini, 5), .Cells(nfilaini, 5)).Value = "Mineral"
                .Range(.Cells(nfilaini, 6), .Cells(nfilaini, 6)).Value = "Ton"
                .Range(.Cells(nfilaini, 7), .Cells(nfilaini, 7)).Value = "Precio"
                .Range(.Cells(nfilaini, 8), .Cells(nfilaini, 8)).Value = "Flete"
                .Range(.Cells(nfilaini, 9), .Cells(nfilaini, 9)).Value = "Origen"
                .Range(.Cells(nfilaini, 10), .Cells(nfilaini, 10)).Value = "Codigo Prov."
                .Range(.Cells(nfilaini, 11), .Cells(nfilaini, 11)).Value = "Proveedor"
                .Range(.Cells(nfilaini, 12), .Cells(nfilaini, 12)).Value = "Nro. Reg."
                .Range(.Cells(nfilaini, 13), .Cells(nfilaini, 13)).Value = "Nro. File"
                .Range(.Cells(nfilaini, 14), .Cells(nfilaini, 14)).Value = "Nro. Doc."
                .Range(.Cells(nfilaini, 15), .Cells(nfilaini, 15)).Value = "Valor vta."

                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("Billete")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("Fecha")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("codigo")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("cantera")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("mineral")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("ton")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("precio")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("flete")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("origen")

                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("COD_PROV")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("RAZSOC")
                    .Range(.Cells(nfila + i, 12), .Cells(nfila + i, 12)).Value = dt.Rows(i)("REG_COMP")
                    .Range(.Cells(nfila + i, 13), .Cells(nfila + i, 13)).Value = dt.Rows(i)("N_FILE")
                    .Range(.Cells(nfila + i, 14), .Cells(nfila + i, 14)).Value = dt.Rows(i)("NUM_DOC")
                    .Range(.Cells(nfila + i, 15), .Cells(nfila + i, 15)).Value = dt.Rows(i)("VALOR_VTA")

                    filaultima = filaultima + 1
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub


    Sub exportarCostoRuma(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 1
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0
                '.Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                .Range(.Cells(nfilaini, 1), .Cells(nfilaini, 1)).Value = "Cod_Ruma"
                .Range(.Cells(nfilaini, 2), .Cells(nfilaini, 2)).Value = "Ruma"
                .Range(.Cells(nfilaini, 3), .Cells(nfilaini, 3)).Value = "Toneladas"
                .Range(.Cells(nfilaini, 4), .Cells(nfilaini, 4)).Value = "CostoRuma"
                .Range(.Cells(nfilaini, 5), .Cells(nfilaini, 5)).Value = "CostoxTon"
                .Range(.Cells(nfilaini, 6), .Cells(nfilaini, 6)).Value = "CostoxTonExtFlRm"
                .Range(.Cells(nfilaini, 7), .Cells(nfilaini, 7)).Value = "CostoDirectoxTonV"
                .Range(.Cells(nfilaini, 8), .Cells(nfilaini, 8)).Value = "CostoDirectoxTonF"
                .Range(.Cells(nfilaini, 9), .Cells(nfilaini, 9)).Value = "CostoIndirectoxTonV"
                .Range(.Cells(nfilaini, 10), .Cells(nfilaini, 10)).Value = "CostoIndirectoxTonF"
                .Range(.Cells(nfilaini, 11), .Cells(nfilaini, 11)).Value = "CostoDirectoOtrasxTonV"
                .Range(.Cells(nfilaini, 12), .Cells(nfilaini, 12)).Value = "CostoDirectoOtrasxTonF"
                .Range(.Cells(nfilaini, 13), .Cells(nfilaini, 13)).Value = "CostoIndirectoOtrasxTonV"
                .Range(.Cells(nfilaini, 14), .Cells(nfilaini, 14)).Value = "CostoIndirectoOtrasxTonF"
                .Range(.Cells(nfilaini, 15), .Cells(nfilaini, 15)).Value = "CostoxTonOtras"
                .Range(.Cells(nfilaini, 16), .Cells(nfilaini, 16)).Value = "CostoxTonVar"
                .Range(.Cells(nfilaini, 17), .Cells(nfilaini, 17)).Value = "CostoxTonFijo"

                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("COD_RUMA")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("RUMA")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("TONELADAS")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("COSTORUMA")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("COSTOXTON")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Interior.Color = 49407
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("CostoxTonExtFlRm")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("CostoDirectoxTonV")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("CostoDirectoxTonF")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("CostoIndirectoxTonV")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("CostoIndirectoxTonF")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("CostoDirectoOtrasxTonV")
                    .Range(.Cells(nfila + i, 12), .Cells(nfila + i, 12)).Value = dt.Rows(i)("CostoDirectoOtrasxTonF")
                    .Range(.Cells(nfila + i, 13), .Cells(nfila + i, 13)).Value = dt.Rows(i)("CostoIndirectoOtrasxTonV")

                    .Range(.Cells(nfila + i, 14), .Cells(nfila + i, 14)).Value = dt.Rows(i)("CostoIndirectoOtrasxTonF")
                    .Range(.Cells(nfila + i, 15), .Cells(nfila + i, 15)).Value = dt.Rows(i)("CostoxTonOtras")
                    .Range(.Cells(nfila + i, 16), .Cells(nfila + i, 16)).Value = "=+F" & i + nfila & "+G" & i + nfila & "+I" & i + nfila & ""
                    .Range(.Cells(nfila + i, 17), .Cells(nfila + i, 17)).Value = "=+H" & i + nfila & "+J" & i + nfila & ""

                    .Range(.Cells(nfila + i, 15), .Cells(nfila + i, 15)).Interior.Color = 16772300
                    .Range(.Cells(nfila + i, 16), .Cells(nfila + i, 16)).Interior.Color = 16772300
                    .Range(.Cells(nfila + i, 17), .Cells(nfila + i, 17)).Interior.Color = 16772300
                    filaultima = filaultima + 1
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarProductos(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 1
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                Dim nmes As Int32 = 0
                '.Range("A1").Value = "'" & nombreMEs(cmbMes.Value) & " - " & txtayo.Value
                .Range(.Cells(nfilaini, 1), .Cells(nfilaini, 1)).Value = "cod_prodpdc"
                .Range(.Cells(nfilaini, 2), .Cells(nfilaini, 2)).Value = "Producto"
                .Range(.Cells(nfilaini, 3), .Cells(nfilaini, 3)).Value = "TipoMatprima"
                .Range(.Cells(nfilaini, 4), .Cells(nfilaini, 4)).Value = "CodRuma"
                .Range(.Cells(nfilaini, 5), .Cells(nfilaini, 5)).Value = "Insumo"
                .Range(.Cells(nfilaini, 6), .Cells(nfilaini, 6)).Value = "Ton_Materia_Prima"
                .Range(.Cells(nfilaini, 7), .Cells(nfilaini, 7)).Value = "CostoxTonVarD"
                .Range(.Cells(nfilaini, 8), .Cells(nfilaini, 8)).Value = "CostoxTonVarI"
                .Range(.Cells(nfilaini, 9), .Cells(nfilaini, 9)).Value = "CostoxTonFijoD"
                .Range(.Cells(nfilaini, 10), .Cells(nfilaini, 10)).Value = "CostoxTonFijoI"
                .Range(.Cells(nfilaini, 11), .Cells(nfilaini, 11)).Value = "CostoxTonOtras"
                .Range(.Cells(nfilaini, 12), .Cells(nfilaini, 12)).Value = "CostoxTonRuma"
                .Range(.Cells(nfilaini, 13), .Cells(nfilaini, 13)).Value = "PorcMerma"
                .Range(.Cells(nfilaini, 14), .Cells(nfilaini, 14)).Value = "PorcHumedad"
                .Range(.Cells(nfilaini, 15), .Cells(nfilaini, 15)).Value = "TonMermaH"

                For i As Int16 = 0 To dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("cod_prodpdc")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("PRODUCTO")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("TipoMatprima")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("CodRuma")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("INSUMO")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("Ton_Materia_Prima")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("CostoxTonVarD")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("CostoxTonVarI")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("CostoxTonFijoD")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("CostoxTonFijoI")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("CostoxTonOtras")
                    .Range(.Cells(nfila + i, 12), .Cells(nfila + i, 12)).Value = dt.Rows(i)("CostoxTonRuma")
                    .Range(.Cells(nfila + i, 13), .Cells(nfila + i, 13)).Value = dt.Rows(i)("PorcMerma")
                    .Range(.Cells(nfila + i, 14), .Cells(nfila + i, 14)).Value = dt.Rows(i)("PorcHumedad")
                    .Range(.Cells(nfila + i, 15), .Cells(nfila + i, 15)).Value = dt.Rows(i)("TonMermaH")
                    filaultima = filaultima + 1
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnnuevod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevod.Click
        Dim frm As New FrmDiasHabiles
        frm.txtayo.Value = txtayo.Value
        frm.cmbMes.Value = cmbMes.Value
        frm.txtdias.Focus()
        Dim resul As DialogResult
        resul = frm.ShowDialog()
        If resul = Windows.Forms.DialogResult.OK Then
            diasHabiles()
        End If
    End Sub

    Private Sub btnnuevos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevos.Click
        Dim frm As New FrmSeguroLey
        frm.txtayo.Value = txtayo.Value
        frm.cmbMes.Value = cmbMes.Value
        frm.Button1.Enabled = True
        frm.txtseguro.Focus()
        Dim resul As DialogResult
        resul = frm.ShowDialog()
        If resul = Windows.Forms.DialogResult.OK Then
            SeguroLey()
        End If
    End Sub

    Private Sub gridDias_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridDias.DoubleClickRow
        Try
            If gridDias.ActiveRow.Index < 0 Then Exit Sub
            Dim frm As New FrmDiasHabiles
            frm.txtayo.Value = txtayo.Value
            frm.cmbMes.Value = gridDias.ActiveRow.Cells("MESNRO").Value
            frm.txtdias.Text = gridDias.ActiveRow.Cells("DIAS").Value
            frm.txtdias.Focus()
            Dim resul As DialogResult
            resul = frm.ShowDialog()
            If resul = Windows.Forms.DialogResult.OK Then
                diasHabiles()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btneliminard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminard.Click
        Try
            If gridDias.ActiveRow.Index < 0 Then Exit Sub
            If MsgBox("Desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            'MsgBox(cadOrden)

            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Tipo = 3
            _objEntidad.Anho = gridDias.ActiveRow.Cells("AYO").Value
            _objEntidad.Mes = gridDias.ActiveRow.Cells("MESNRO").Value
            _objEntidad.Dia = gridDias.ActiveRow.Cells("DIAS").Value
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RegistraDias(_objEntidad)
            MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            diasHabiles()
            'Me.DialogResult = Windows.Forms.DialogResult.OK
            'Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btneliminars_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminars.Click
        Try
            If gridDias.ActiveRow.Index < 0 Then Exit Sub
            If MsgBox("Desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            'MsgBox(cadOrden)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Tipo = 3
            _objEntidad.Anho = gridSeguro.ActiveRow.Cells("AYO").Value
            _objEntidad.Mes = gridSeguro.ActiveRow.Cells("MESNRO").Value
            _objEntidad.CodProducto = gridSeguro.ActiveRow.Cells("PLACOD").Value
            _objEntidad.Monto = gridSeguro.ActiveRow.Cells("SEGURO").Value
            _objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RegistraSeguro(_objEntidad)
            MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            SeguroLey()
            'Me.DialogResult = Windows.Forms.DialogResult.OK
            'Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridSeguro_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridSeguro.DoubleClickRow
        Try
            If gridSeguro.ActiveRow.Index < 0 Then Exit Sub
            Dim frm As New FrmSeguroLey
            frm.txtayo.Value = txtayo.Value
            frm.cmbMes.Value = cmbMes.Value
            frm.TxtCodigoTrabajador.Text = gridSeguro.ActiveRow.Cells("PLACOD").Value
            frm.TxtNombresTrabajador.Text = gridSeguro.ActiveRow.Cells("TRABAJADOR").Value
            frm.txtseguro.Text = gridSeguro.ActiveRow.Cells("SEGURO").Value
            frm.Button1.Enabled = False
            frm.txtseguro.Focus()
            Dim resul As DialogResult
            resul = frm.ShowDialog()
            If resul = Windows.Forms.DialogResult.OK Then
                SeguroLey()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnreplica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreplica.Click
        Try
            If gridDias.ActiveRow.Index < 0 Then Exit Sub
            If MsgBox("Seguro replicar la informacion del periodo anterior?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            'MsgBox(cadOrden)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_ReplicaSeguro(_objEntidad)
            MsgBox(dtDatos.Rows(0)(0), MsgBoxStyle.Information, msgComacsa)
            SeguroLey()
            'Me.DialogResult = Windows.Forms.DialogResult.OK
            'Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnimportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimportar.Click
        Try
            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName
            Cursor = Cursors.WaitCursor
            lblmensaje.Visible = True
            lblmensaje.Text = "Validando datos de libro Excel..."
            lblmensaje.Refresh()
         
            'MsgBox("ENTRANDO A CONEXION OLEDB")
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                          "Data Source= " & cadenaExcel & _
                          ";Extended Properties=""Excel 8.0;HDR=YES"""
            Dim oConn As New OleDbConnection(cs)

            Try
                oConn.Open()
                If Not cargarCanteras(oConn, "Canteras", 1) Then
                    Exit Sub
                End If
                MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
                CargaRevision()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ocurrió un error")
                'MsgBox("Archivo incorrecto a ya se encuentra utilizado", MsgBoxStyle.Critical, "Comacsa")
            Finally
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Cursor = Cursors.Default
                lblmensaje.Visible = False
                lblmensaje.Refresh()
                oConn.Close()
                oConn.Dispose()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function validaCantera(ByVal fila As Int32, ByVal codcantera As String) As Boolean
        Try
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Cod_Cantera = codcantera
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_ValidaCantera(_objEntidad)
            If dtDatos.Rows(0)(0).ToString = "OK" Then
                Return True
            Else
                MsgBox("Ingrese catera correcta en la fila " & fila + 1, MsgBoxStyle.Exclamation, msgComacsa)
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Function

    Function cargarCanteras(ByVal oConn As OleDbConnection, ByVal hoja As String, ByVal formato As Integer) As Boolean
        If MsgBox("Desea realizar importacion de canteras?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return False
            Exit Function
        End If
        Dim Ls_datos = New List(Of ETProveedorFiscalizado)
        Dim DtSet As New System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        MyCommand = New System.Data.OleDb.OleDbDataAdapter _
        ("select * from [" & hoja & "$]", oConn)
        MyCommand.TableMappings.Add("Table", "TablaSustento")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        lblmensaje.Text = "Cargando datos de libro Excel..."
        lblmensaje.Refresh()
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        For i As Int32 = 0 To DtSet.Tables(0).Rows.Count - 1
            If validaCantera(i, DtSet.Tables(0).Rows(i)("CODCANTERA")) = False Then
                Return False
            End If
        Next

        'MsgBox(cadOrden)

        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        
        For i As Int32 = 0 To DtSet.Tables(0).Rows.Count - 1
            _objEntidad.ID = DtSet.Tables(0).Rows(i)("IDCONMAY")
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Cod_Cantera = DtSet.Tables(0).Rows(i)("CODCANTERA")
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_ActualizaCantera(_objEntidad)
        Next

        If Not oPrvFisE Is Nothing Then
            oPrvFisN.DatosUsoLaboratorio(oPrvFisE, Ls_datos)
        End If
        Return True
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application

        Try
            Dim dsData As New DataSet
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.User_Crea = User_Sistema
            dsData = _objNegocio.Costo_RptComparativoMinas(_objEntidad)
            Dim dtCostos As New DataTable
            Dim dtConta As New DataTable
            Dim dtDetCostos As New DataTable
            Dim dtDetConta As New DataTable
            dtCostos = dsData.Tables(0)
            If dtCostos.Columns.Count = 1 Then
                MsgBox(dtCostos.Rows(0)(0), MsgBoxStyle.Exclamation, "Sistemas")
                Exit Sub
            End If
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            dtConta = dsData.Tables(1)
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\COSTOS_MINAS_CONTA_" & cmbMes.Text & ".xls")
            File.Copy(RutaReporteERP & "PLANTILLA_COST_MINAS_CONTA.xls", path & "\COSTOS_MINAS_CONTA_" & cmbMes.Text & ".xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
            m_Excel.Workbooks.Open(path & "\COSTOS_MINAS_CONTA_" & cmbMes.Text & ".xls")

            Dim concepto_costo As String = ""
            Dim concepto_conta As String = ""
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)

            With objHojaExcel
                For fila As Int32 = 4 To 36
                    concepto_costo = .Range(.Cells(fila, 2), .Cells(fila, 2)).Value
                    concepto_conta = .Range(.Cells(fila, 6), .Cells(fila, 6)).Value
                    For i As Int32 = 0 To dtCostos.Rows.Count - 1
                        If concepto_costo = dtCostos.Rows(i)(0) Then
                            .Range(.Cells(fila, 3), .Cells(fila, 3)).Value = dtCostos.Rows(i)(1)
                            Exit For
                        End If
                    Next
                    For x As Int32 = 0 To dtConta.Rows.Count - 1
                        If concepto_conta = dtConta.Rows(x)(0) Then
                            .Range(.Cells(fila, 7), .Cells(fila, 7)).Value = dtConta.Rows(x)(1)
                            Exit For
                        End If
                    Next
                Next
            End With

            Dim objHojaExcelDetCosto As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            dtDetCostos = dsData.Tables(2)

            With objHojaExcelDetCosto
                For i As Int32 = 0 To dtDetCostos.Rows.Count - 1
                    .Range("A" & i + 3).Value = dtDetCostos.Rows(i)(3)
                    .Range("B" & i + 3).Value = dtDetCostos.Rows(i)(4)
                    .Range("C" & i + 3).Value = dtDetCostos.Rows(i)(5)
                    .Range("D" & i + 3).Value = dtDetCostos.Rows(i)(6)
                Next
            End With

            Dim objHojaExcelDetConta As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            dtDetConta = dsData.Tables(3)
            With objHojaExcelDetConta
                For i As Int32 = 0 To dtDetConta.Rows.Count - 1
                    .Range("A" & i + 3).Value = dtDetConta.Rows(i)(17)
                    .Range("B" & i + 3).Value = dtDetConta.Rows(i)(0)
                    .Range("C" & i + 3).Value = dtDetConta.Rows(i)(1)
                    .Range("D" & i + 3).Value = dtDetConta.Rows(i)(2)
                    .Range("E" & i + 3).Value = dtDetConta.Rows(i)(3)
                    .Range("F" & i + 3).Value = dtDetConta.Rows(i)(4)
                    .Range("G" & i + 3).Value = dtDetConta.Rows(i)(5)
                    .Range("H" & i + 3).Value = dtDetConta.Rows(i)(6)
                    .Range("I" & i + 3).Value = dtDetConta.Rows(i)(7)
                    .Range("J" & i + 3).Value = dtDetConta.Rows(i)(8)
                    .Range("K" & i + 3).Value = dtDetConta.Rows(i)(9)
                    .Range("L" & i + 3).Value = dtDetConta.Rows(i)(10)
                    .Range("M" & i + 3).Value = dtDetConta.Rows(i)(11)
                    .Range("N" & i + 3).Value = dtDetConta.Rows(i)(12)
                    .Range("O" & i + 3).Value = dtDetConta.Rows(i)(13)
                    .Range("P" & i + 3).Value = dtDetConta.Rows(i)(15)
                    .Range("Q" & i + 3).Value = dtDetConta.Rows(i)(16)
                Next
            End With

            m_Excel.DisplayAlerts = False
            m_Excel.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
            m_Excel.Quit()
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
       

    End Sub


End Class