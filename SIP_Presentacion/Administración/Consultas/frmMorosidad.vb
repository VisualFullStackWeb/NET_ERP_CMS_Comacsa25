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
Public Class frmMorosidad
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
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
#End Region

    Private Sub frmMorosidad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFecha.Value = Now.Date
    End Sub

    Sub Procesar()

        Dim fecha1 As Date = dtFecha.Value
        Dim fecha2 As Date = Now.Date
        fecha1 = fecha1.ToString("dd/MM/yyyy")
        fecha2 = fecha2.ToString("dd/MM/yyyy")

        If fecha2.CompareTo(fecha1) < 0 Then
            MsgBox("No puede ingresar fecha posterior a la actual", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
        End If

        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DsReporte As DataSet = Nothing
        Dim DtMorisidad As DataTable = Nothing
        Dim DtSemanal As DataTable = Nothing
        Dim DtMensual As DataTable = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Procesando reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .Fecha = dtFecha.Value
                .User_Crea = User_Sistema
            End With
            DsReporte = oPrvFisN.DatosMorosidad(oPrvFisE)
            DtMorisidad = DsReporte.Tables(0)
            DtSemanal = DsReporte.Tables(1)
            DtMensual = DsReporte.Tables(2)

            Call CargarUltraGridxBinding(Grid1, Source1, DtMorisidad)
            Call CargarUltraGridxBinding(Grid2, Source2, DtSemanal)
            Call CargarUltraGridxBinding(Grid3, Source3, DtMensual)

            'lblmensaje.Text = "Procesando datos venta de mineral..."
            lblmensaje.Refresh()
            'DsVentaMineral = oPrvFisN.DatosVentaMineral(oPrvFisE)
            'DtVentaNacional = DsVentaMineral.Tables(0)
            'DtVentaExportacion = DsVentaMineral.Tables(1)
            'DtStamin = DsVentaMineral.Tables(2)
            'DtSFNAcional = DsVentaMineral.Tables(3)
            'DtSFExterior = DsVentaMineral.Tables(4)

            'Call CargarUltraGridxBinding(GridNacional, Source3, DtVentaNacional)
            'Call CargarUltraGridxBinding(GridExportacion, Source4, DtVentaExportacion)
            'Call CargarUltraGridxBinding(GridStamin, Source5, DtStamin)
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
            File.Delete(path & "\MOROSIDAD.xls")
            File.Copy(RutaReporteERP & "PLANTILLAMOROSIDAD.xls", path & "\MOROSIDAD.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\MOROSIDAD.xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcelSemana As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            Dim objHojaExcelMes As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            Dim objHojaExcelDetalleInterno As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)

            'exportarDetalle(objHojaExcelDetalle, m_Excel)
            exportarSemana(objHojaExcelSemana)
            exportarMes(objHojaExcelMes)
            exportarDetalleInterno(objHojaExcelDetalleInterno, m_Excel)
            'exportarNacional(objHojaExcelSemana)
            'exportarExterior(objHojaExcelMes)


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
    Sub exportarDetalleInterno(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal m_excel As Microsoft.Office.Interop.Excel.Application)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                .Range("A5").Value = mesNumero(Month(dtFecha.Value)) & " - " & Year(dtFecha.Value)
                .Range("K6").Value = Now.Date
                .Range("N7").Value = "SALDO AL " & Now.Date & ""
                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 1)).Value = i + 1
                    .Range(.Cells(9 + i, 2), .Cells(9 + i, 2)).Value = Grid1.Rows(i).Cells("CODIGO").Value
                    .Range(.Cells(9 + i, 3), .Cells(9 + i, 3)).Value = Grid1.Rows(i).Cells("TRABAJADOR").Value
                    .Range(.Cells(9 + i, 3), .Cells(9 + i, 4)).Merge()
                    .Range(.Cells(9 + i, 5), .Cells(9 + i, 5)).Value = Grid1.Rows(i).Cells("AREA").Value
                    .Range(.Cells(9 + i, 6), .Cells(9 + i, 6)).Value = Grid1.Rows(i).Cells("0_DIAS").Value
                    .Range(.Cells(9 + i, 7), .Cells(9 + i, 7)).Value = Grid1.Rows(i).Cells("1_10_DIAS").Value
                    .Range(.Cells(9 + i, 8), .Cells(9 + i, 8)).Value = Grid1.Rows(i).Cells("11_18_DIAS").Value
                    .Range(.Cells(9 + i, 9), .Cells(9 + i, 9)).Value = Grid1.Rows(i).Cells("19_26_DIAS").Value
                    .Range(.Cells(9 + i, 10), .Cells(9 + i, 10)).Value = Grid1.Rows(i).Cells("27_34_DIAS").Value

                    '.Range(.Cells(9 + i, 10), .Cells(9 + i, 10)).Value = Grid1.Rows(i).Cells("35_MAS_DIAS").Value

                    .Range(.Cells(9 + i, 11), .Cells(9 + i, 11)).Formula = "=H" & 9 + i & "+I" & 9 + i & "+J" & 9 + i & ""
                    .Range(.Cells(9 + i, 12), .Cells(9 + i, 12)).Formula = "=F" & 9 + i & "+G" & 9 + i & "+K" & 9 + i & ""

                    .Range(.Cells(9 + i, 13), .Cells(9 + i, 13)).Value = Grid1.Rows(i).Cells("CERRADAS").Value
                    .Range(.Cells(9 + i, 14), .Cells(9 + i, 14)).Formula = "=L" & 9 + i & "-M" & 9 + i & ""

                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 14)).WrapText = False
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 15)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    ultFila = i + 9
                Next
                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 14)).Font.Bold = True
                .Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 14)).Font.Bold = True
                '.Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 5)).Merge()
                '.Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 5)).Merge()
                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 5)).Value = "TOTALES"
                .Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 5)).Value = "% POR COBRAR"

                '.Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 5)).Formula = "=SUMA(E9:E" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 6), .Cells(1 + ultFila, 6)).Formula = "=SUMA(F9:F" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 7), .Cells(1 + ultFila, 7)).Formula = "=SUMA(G9:G" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 8), .Cells(1 + ultFila, 8)).Formula = "=SUMA(H9:H" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 9), .Cells(1 + ultFila, 9)).Formula = "=SUMA(I9:I" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 10), .Cells(1 + ultFila, 10)).Formula = "=SUMA(J9:J" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 13), .Cells(1 + ultFila, 13)).Formula = "=SUMA(M9:M" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 14), .Cells(1 + ultFila, 14)).Formula = "=SUMA(N9:N" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 11), .Cells(1 + ultFila, 11)).Formula = "=H" & 1 + ultFila & "+I" & 1 + ultFila & "+J" & 1 + ultFila & ""
                .Range(.Cells(1 + ultFila, 12), .Cells(1 + ultFila, 12)).Formula = "=F" & 1 + ultFila & "+G" & 1 + ultFila & "+K" & 1 + ultFila & ""

                '.Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 5)).Formula = "=+E" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 6), .Cells(2 + ultFila, 6)).Formula = "=+F" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 7), .Cells(2 + ultFila, 7)).Formula = "=+G" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 8), .Cells(2 + ultFila, 8)).Formula = "=+H" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 9), .Cells(2 + ultFila, 9)).Formula = "=+I" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 10), .Cells(2 + ultFila, 10)).Formula = "=+J" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 11), .Cells(2 + ultFila, 11)).Formula = "=+K" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 12), .Cells(2 + ultFila, 12)).Formula = "=+L" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 11)).NumberFormat = "0.00%" 'NumberFormat = "0.00%" '"0.00%;[Red]-0.00%"

                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 10)).Merge()
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 8)).Value = "INDICE DE MOROSIDAD"
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 8)).Font.Size = 11
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 11)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 11)).Font.Bold = True
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).NumberFormat = "0.00%"
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).Font.Size = 11
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).Formula = "=+K" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Rows(5 + ultFila & ":" & 5 + ultFila).Select()

                'If 4 + ultFila > 43 Then
                For i As Int32 = 0 To 54 - ultFila
                    m_excel.Selection.Delete(Shift:=Excel.XlDirection.xlUp)
                    'm_excel.Selection.Insert(Shift:=Excel.XlDirection.xlDown)
                Next
                .Range("A7").Select()

                Dim sort As Excel.Sort = objHojaExcel.Sort

                With sort
                    .SortFields.Clear()
                    .SortFields.Add(objHojaExcel.Range("K9"), Excel.XlSortOn.xlSortOnValues, _
                        Excel.XlSortOrder.xlDescending, Excel.XlSortDataOption.xlSortNormal)
                    .SortFields.Add(objHojaExcel.Range("O9"), Excel.XlSortOn.xlSortOnValues, _
                       Excel.XlSortOrder.xlDescending, Excel.XlSortDataOption.xlSortNormal)
                    .SetRange(objHojaExcel.Range("A9:O" & ultFila & ""))
                    .MatchCase = False
                    .Header = Excel.XlYesNoGuess.xlNo
                    .Orientation = Excel.XlSortOrientation.xlSortColumns
                    .SortMethod = Excel.XlSortMethod.xlPinYin
                    .Apply()
                End With

                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 1)).Value = i + 1
                Next

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarDetalle(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal m_excel As Microsoft.Office.Interop.Excel.Application)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A5").Value = mesNumero(Month(dtFecha.Value)) & " - " & Year(dtFecha.Value)
                .Range("K6").Value = Now.Date
                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 1)).Value = i + 1
                    .Range(.Cells(9 + i, 2), .Cells(9 + i, 2)).Value = Grid1.Rows(i).Cells("CODIGO").Value
                    .Range(.Cells(9 + i, 3), .Cells(9 + i, 3)).Value = Grid1.Rows(i).Cells("TRABAJADOR").Value
                    .Range(.Cells(9 + i, 3), .Cells(9 + i, 4)).Merge()
                    .Range(.Cells(9 + i, 5), .Cells(9 + i, 5)).Value = Grid1.Rows(i).Cells("AREA").Value
                    .Range(.Cells(9 + i, 6), .Cells(9 + i, 6)).Value = Grid1.Rows(i).Cells("0_DIAS").Value
                    .Range(.Cells(9 + i, 7), .Cells(9 + i, 7)).Value = Grid1.Rows(i).Cells("1_10_DIAS").Value
                    .Range(.Cells(9 + i, 8), .Cells(9 + i, 8)).Value = Grid1.Rows(i).Cells("11_18_DIAS").Value
                    .Range(.Cells(9 + i, 9), .Cells(9 + i, 9)).Value = Grid1.Rows(i).Cells("19_26_DIAS").Value
                    .Range(.Cells(9 + i, 10), .Cells(9 + i, 10)).Value = Grid1.Rows(i).Cells("27_34_DIAS").Value

                    '.Range(.Cells(9 + i, 10), .Cells(9 + i, 10)).Value = Grid1.Rows(i).Cells("35_MAS_DIAS").Value

                    .Range(.Cells(9 + i, 11), .Cells(9 + i, 11)).Formula = "=H" & 9 + i & "+I" & 9 + i & "+J" & 9 + i & ""
                    .Range(.Cells(9 + i, 12), .Cells(9 + i, 12)).Formula = "=F" & 9 + i & "+G" & 9 + i & "+K" & 9 + i & ""


                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 12)).WrapText = False
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    ultFila = i + 9
                Next
                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 12)).Font.Bold = True
                .Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 12)).Font.Bold = True
                '.Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 5)).Merge()
                '.Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 5)).Merge()
                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 5)).Value = "TOTALES"
                .Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 5)).Value = "% POR COBRAR"

                '.Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 5)).Formula = "=SUMA(E9:E" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 6), .Cells(1 + ultFila, 6)).Formula = "=SUMA(F9:F" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 7), .Cells(1 + ultFila, 7)).Formula = "=SUMA(G9:G" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 8), .Cells(1 + ultFila, 8)).Formula = "=SUMA(H9:H" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 9), .Cells(1 + ultFila, 9)).Formula = "=SUMA(I9:I" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 10), .Cells(1 + ultFila, 10)).Formula = "=SUMA(J9:J" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 11), .Cells(1 + ultFila, 11)).Formula = "=H" & 1 + ultFila & "+I" & 1 + ultFila & "+J" & 1 + ultFila & ""
                .Range(.Cells(1 + ultFila, 12), .Cells(1 + ultFila, 12)).Formula = "=F" & 1 + ultFila & "+G" & 1 + ultFila & "+K" & 1 + ultFila & ""

                '.Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 5)).Formula = "=+E" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 6), .Cells(2 + ultFila, 6)).Formula = "=+F" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 7), .Cells(2 + ultFila, 7)).Formula = "=+G" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 8), .Cells(2 + ultFila, 8)).Formula = "=+H" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 9), .Cells(2 + ultFila, 9)).Formula = "=+I" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 10), .Cells(2 + ultFila, 10)).Formula = "=+J" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 11), .Cells(2 + ultFila, 11)).Formula = "=+K" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 12), .Cells(2 + ultFila, 12)).Formula = "=+L" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 11)).NumberFormat = "0.00%" 'NumberFormat = "0.00%" '"0.00%;[Red]-0.00%"

                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 10)).Merge()
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 8)).Value = "INDICE DE MOROSIDAD"
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 8)).Font.Size = 11
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 11)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 11)).Font.Bold = True
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).NumberFormat = "0.00%"
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).Font.Size = 11
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).Formula = "=+K" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Rows(5 + ultFila & ":" & 5 + ultFila).Select()
                'If 4 + ultFila > 43 Then
                For i As Int32 = 0 To 54 - ultFila
                    m_excel.Selection.Delete(Shift:=Excel.XlDirection.xlUp)
                    'm_excel.Selection.Insert(Shift:=Excel.XlDirection.xlDown)
                Next
                .Range("A7").Select()

                Dim sort As Excel.Sort = objHojaExcel.Sort

                With sort
                    .SortFields.Clear()
                    .SortFields.Add(objHojaExcel.Range("K9"), Excel.XlSortOn.xlSortOnValues, _
                        Excel.XlSortOrder.xlDescending, Excel.XlSortDataOption.xlSortNormal)
                    .SortFields.Add(objHojaExcel.Range("L9"), Excel.XlSortOn.xlSortOnValues, _
                       Excel.XlSortOrder.xlDescending, Excel.XlSortDataOption.xlSortNormal)
                    .SetRange(objHojaExcel.Range("A9:L" & ultFila & ""))
                    .MatchCase = False
                    .Header = Excel.XlYesNoGuess.xlNo
                    .Orientation = Excel.XlSortOrientation.xlSortColumns
                    .SortMethod = Excel.XlSortMethod.xlPinYin
                    .Apply()
                End With

                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 1)).Value = i + 1
                Next

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarSemana(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                '.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                '.Range("A2").Value =
                If Grid2.Rows.Count > 0 Then
                    Dim Mes As String = String.Empty
                    Mes = Grid2.Rows(0).Cells("MES").Value.ToString.Substring(0, 3).ToUpper

                    Dim filaini As Int32 = 4
                    'Dim filafin As Int32 = 0

                    Dim contSemana As Int32 = 1
                    For i = 0 To Grid2.Rows.Count - 1
                        If Mes <> Grid2.Rows(i).Cells("MES").Value.ToString.Substring(0, 3).ToUpper Then
                            contSemana = 1 : Mes = Grid2.Rows(i).Cells("MES").Value.ToString.Substring(0, 3).ToUpper
                            .Range(.Cells(filaini, 1), .Cells(3 + i, 1)).Merge()
                            '.Range(.Cells(filaini, 1), .Cells(4 + i, 1)).
                            filaini = i + 4
                        End If

                        .Range(.Cells(4 + i, 1), .Cells(4 + i, 1)).Value = Grid2.Rows(i).Cells("MES").Value.ToString.Substring(0, 3).ToUpper
                        .Range(.Cells(4 + i, 2), .Cells(4 + i, 2)).Value = contSemana
                        .Range(.Cells(4 + i, 3), .Cells(4 + i, 3)).Value = Grid2.Rows(i).Cells("FECHA").Value
                        .Range(.Cells(4 + i, 4), .Cells(4 + i, 4)).Value = Grid2.Rows(i).Cells("MOROSIDAD").Value
                        '.Range(.Cells(7 + i, 1), .Cells(7 + i, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        ultFila = i + 4
                        contSemana += 1
                    Next
                    .Range(.Cells(filaini, 1), .Cells(ultFila, 1)).Merge()
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarMes(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                '.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                '.Range("A2").Value =
                If Grid2.Rows.Count > 0 Then
                    Dim Mes As String = String.Empty
                    Mes = Grid2.Rows(0).Cells("MES").Value.ToString.Substring(0, 3).ToUpper

                    Dim filaini As Int32 = 4
                    'Dim filafin As Int32 = 0

                    Dim contSemana As Int32 = 1
                    For i = 0 To Grid3.Rows.Count - 1
                        .Range(.Cells(4 + i, 3), .Cells(4 + i, 3)).Value = Grid3.Rows(i).Cells("IMPORTETOTAL").Value
                        .Range(.Cells(4 + i, 4), .Cells(4 + i, 4)).Value = Grid3.Rows(i).Cells("PORVENCER").Value
                        .Range(.Cells(4 + i, 5), .Cells(4 + i, 5)).Value = Grid3.Rows(i).Cells("VENCIDO").Value
                        .Range(.Cells(4 + i, 7), .Cells(4 + i, 7)).Value = Grid3.Rows(i).Cells("SOLICITADO").Value
                        '.Range(.Cells(7 + i, 1), .Cells(7 + i, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        ultFila = i + 4
                        contSemana += 1
                    Next
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Function mesNumero(ByVal Mes As Integer) As String
        Dim mesdescri As String = String.Empty
        Select Case Mes
            Case 1
                mesNumero = "ENERO"
            Case 2
                mesNumero = "FEBRERO"
            Case 3
                mesNumero = "MARZO"
            Case 4
                mesNumero = "ABRIL"
            Case 5
                mesNumero = "MAYO"
            Case 6
                mesNumero = "JUNIO"
            Case 7
                mesNumero = "JULIO"
            Case 8
                mesNumero = "AGOSTO"
            Case 9
                mesNumero = "SETIEMBRE"
            Case 10
                mesNumero = "OCTUBRE"
            Case 11
                mesNumero = "NOVIEMBRE"
            Case Else
                mesNumero = "DICIEMBRE"
        End Select
    End Function
End Class
