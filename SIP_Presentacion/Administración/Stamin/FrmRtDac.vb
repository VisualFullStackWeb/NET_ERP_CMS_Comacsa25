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
Public Class FrmRtDac
    Public Ls_Permisos As New List(Of Integer)
    Dim DsReporte As DataSet = Nothing
    Dim DtReporte As DataTable = Nothing
    Private Sub FrmRtDac_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
    End Sub
    Sub Procesar()
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Procesando datos..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .año = txtAño.Value
                .User_Crea = User_Sistema                
            End With
            DsReporte = oPrvFisN.ReporteDAC(oPrvFisE)
            DtReporte = DsReporte.Tables(0)
            Call CargarUltraGridxBinding(Grid1, Source1, DtReporte)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub
    Sub Reporte()
       
        Try
            If DtReporte.Rows.Count <= 0 Then
                MsgBox("No existen datos para el reporte", MsgBoxStyle.Information, "Comacsa")
                Exit Sub
            End If
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\REPORTEDAC.xls")
            File.Copy(RutaReporteERP & "PLANTILLADAC.xls", path & "\REPORTEDAC.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\REPORTEDAC.xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            'Dim objHojaExcelOtraFormula As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(7)
            exportarReporte(objHojaExcel, DtReporte)
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

    Sub exportarReporte(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            Dim inicial As Int32 = 12
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                '.Range("A2").Value = Me.cmbMes.Text.ToString.ToUpper & " " & txtAño.Value.ToString
                For i = 0 To dt.Rows.Count - 1
                    .Range(.Cells(inicial + i, 1), .Cells(inicial + i, 1)).Value = dt.Rows(i)("COD_DAC")
                    .Range(.Cells(inicial + i, 2), .Cells(inicial + i, 2)).Value = dt.Rows(i)("UEA")
                    .Range(.Cells(inicial + i, 3), .Cells(inicial + i, 3)).Value = dt.Rows(i)("TIPO_COMPROBANTE")
                    .Range(.Cells(inicial + i, 4), .Cells(inicial + i, 4)).Value = dt.Rows(i)("NUMFACTURA")
                    .Range(.Cells(inicial + i, 5), .Cells(inicial + i, 5)).Value = dt.Rows(i)("DOC_REFERENCIA")
                    .Range(.Cells(inicial + i, 6), .Cells(inicial + i, 6)).Value = dt.Rows(i)("FEC_EMISION")
                    .Range(.Cells(inicial + i, 7), .Cells(inicial + i, 7)).Value = dt.Rows(i)("PRODUCTO")
                    .Range(.Cells(inicial + i, 8), .Cells(inicial + i, 8)).Value = dt.Rows(i)("TONELADAS")
                    .Range(.Cells(inicial + i, 9), .Cells(inicial + i, 9)).Value = dt.Rows(i)("UM")
                    .Range(.Cells(inicial + i, 10), .Cells(inicial + i, 10)).Value = dt.Rows(i)("COMPRADOR")
                    .Range(.Cells(inicial + i, 11), .Cells(inicial + i, 11)).Value = "'" & dt.Rows(i)("RUC")
                    .Range(.Cells(inicial + i, 12), .Cells(inicial + i, 12)).Value = dt.Rows(i)("PAIS")
                    .Range(.Cells(inicial + i, 13), .Cells(inicial + i, 13)).Value = dt.Rows(i)("TIPO_CAMBIO")
                    .Range(.Cells(inicial + i, 14), .Cells(inicial + i, 14)).Value = dt.Rows(i)("VALOR_BRUTO")
                    .Range(.Cells(inicial + i, 15), .Cells(inicial + i, 15)).Value = dt.Rows(i)("DSCTO")
                    .Range(.Cells(inicial + i, 16), .Cells(inicial + i, 16)).Value = dt.Rows(i)("VALOR_NETO")
                    .Range(.Cells(inicial + i, 1), .Cells(inicial + i, 16)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    ultFila = i + inicial
                Next
                .Range(.Cells(ultFila + 1, 3), .Cells(ultFila + 1, 3)).Value = "Notas :"
                .Range(.Cells(ultFila + 1, 4), .Cells(ultFila + 1, 4)).Value = "1. VALOR BRUTO = PRECIO UNITARIO * TONELAJE"
                .Range(.Cells(ultFila + 2, 4), .Cells(ultFila + 2, 4)).Value = "2. DEDUCCIONES POR TRANSFORMACION, FLETE, ETC"
                .Range(.Cells(ultFila + 3, 4), .Cells(ultFila + 3, 4)).Value = "3. SIN INCLUIR IMPUESTOS"
                .Range(.Cells(ultFila + 1, 3), .Cells(ultFila + 3, 4)).WrapText = False

                .Range(.Cells(ultFila + 5, 6), .Cells(ultFila + 5, 6)).Value = "=SUMA(F12 : F" & ultFila & ")"
                .Range(.Cells(ultFila + 5, 6), .Cells(ultFila + 5, 6)).Font.Bold = True
                .Range(.Cells(ultFila + 5, 6), .Cells(ultFila + 5, 6)).Font.Size = 10
                .Range(.Cells(ultFila + 5, 6), .Cells(ultFila + 5, 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(ultFila + 5, 6), .Cells(ultFila + 5, 6)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                .Range(.Cells(ultFila + 5, 10), .Cells(ultFila + 5, 10)).Value = "=SUMA(J12 : J" & ultFila & ")"
                .Range(.Cells(ultFila + 5, 10), .Cells(ultFila + 5, 10)).Font.Bold = True
                .Range(.Cells(ultFila + 5, 10), .Cells(ultFila + 5, 10)).Font.Size = 10
                .Range(.Cells(ultFila + 5, 10), .Cells(ultFila + 5, 10)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(ultFila + 5, 10), .Cells(ultFila + 5, 10)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                .Range(.Cells(ultFila + 5, 12), .Cells(ultFila + 5, 12)).Value = "=SUMA(L12 : L" & ultFila & ")"
                .Range(.Cells(ultFila + 5, 12), .Cells(ultFila + 5, 12)).Font.Bold = True
                .Range(.Cells(ultFila + 5, 12), .Cells(ultFila + 5, 12)).Font.Size = 10
                .Range(.Cells(ultFila + 5, 12), .Cells(ultFila + 5, 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(ultFila + 5, 12), .Cells(ultFila + 5, 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                '.Range(.Cells(ultFila + 1, 4), .Cells(ultFila + 3, 4)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                '.Range(.Cells(ultFila + 1, 4), .Cells(ultFila + 3, 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignDistributed

                '.Range(.Cells(ultFila, 3), .Cells(ultFila, 3)).Value = "SUB TOTAL"
                '.Range(.Cells(ultFila, 3), .Cells(ultFila, 4)).Font.Bold = True
                '.Range(.Cells(ultFila, 3), .Cells(ultFila, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                '.Range(.Cells(ultFila, 4), .Cells(ultFila, 4)).Formula = "=SUMA(D4 : D" & ultFila - 1 & ")"            
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout

    End Sub
End Class