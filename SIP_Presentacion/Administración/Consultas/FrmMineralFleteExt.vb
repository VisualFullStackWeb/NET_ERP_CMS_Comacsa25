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
Public Class FrmMineralFleteExt
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
    Dim oPrvFisN As NGProveedorFiscalizado = Nothing
    Dim oPrvFisE As ETProveedorFiscalizado = Nothing

    Private Sub FrmMineralFleteExt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        Me.cmbMes.Value = Month(Now.Date)
    End Sub

    Sub Reporte()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\MINERAL_FLETEEXT.xls")
            File.Copy(RutaReporteERP & "PLANTILLAMINERAL_FLETEEXT.xls", path & "\MINERAL_FLETEEXT.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\MINERAL_FLETEEXT.xls")
            m_Excel.DisplayAlerts = False
            Dim dsDatos As New DataSet
            Dim dtDatos As New DataTable
            Dim dtDatos2 As New DataTable

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .año = txtAño.Value
                .mes = cmbMes.Value
                .User_Crea = User_Sistema
            End With

            dsDatos = oPrvFisN.MineralFlete(oPrvFisE)
            dtDatos = dsDatos.Tables(0)
            dtDatos2 = dsDatos.Tables(1)

                If dtDatos.Rows.Count > 0 Then
                Dim objHojaExcelIngreso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                Dim objHojaExcelIngreso2 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
                objHojaExcelIngreso.Visible = Excel.XlSheetVisibility.xlSheetVisible
                exportarReporte(objHojaExcelIngreso, dtDatos, objHojaExcelIngreso2, dtDatos2)
                End If

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

    Sub exportarReporte(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtDatos As DataTable, ByVal objHojaExcel2 As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtDatos2 As DataTable)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 2
            Dim nfilault As Integer = 0
            Dim nfilaArea As Integer = 2
            Dim nfilainiArea As Integer = 2
            Dim nfilaultArea As Integer = 0

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                '.Range("A4").Value = "REPORTE DE VALES SIN SUSTENTO TRIBUTARIO - " & nombreMEs(cmbMes.Value) & " " & txtAño.Value
                '.Range("A").ColumnWidth = 5
                '.Columns("A").ColumnWidth = 5
                '.Columns("E").NumberFormat = "#,##0.00"
                '.Columns("J").NumberFormat = "#,##0.00"
                Dim nmes As Int32 = 0
                For I As Int16 = 0 To dtDatos.Rows.Count - 1
                    'nmes = dtAnual.Rows(I)("MES")
                    .Range(.Cells(nfila + I, 1), .Cells(nfila + I, 1)).Value = dtDatos.Rows(I)("BILLETE")
                    .Range(.Cells(nfila + I, 2), .Cells(nfila + I, 2)).Value = dtDatos.Rows(I)("COD_PROV")
                    .Range(.Cells(nfila + I, 3), .Cells(nfila + I, 3)).Value = dtDatos.Rows(I)("FACTURA")
                    .Range(.Cells(nfila + I, 4), .Cells(nfila + I, 4)).Value = dtDatos.Rows(I)("FECHABILLETE")
                    .Range(.Cells(nfila + I, 5), .Cells(nfila + I, 5)).Value = dtDatos.Rows(I)("FECHAFACTURA")
                    .Range(.Cells(nfila + I, 6), .Cells(nfila + I, 6)).Value = dtDatos.Rows(I)("CODCANTERA")
                    .Range(.Cells(nfila + I, 7), .Cells(nfila + I, 7)).Value = dtDatos.Rows(I)("CANTERA")
                    .Range(.Cells(nfila + I, 8), .Cells(nfila + I, 8)).Value = dtDatos.Rows(I)("COD_MATPRIMA")
                    .Range(.Cells(nfila + I, 9), .Cells(nfila + I, 9)).Value = dtDatos.Rows(I)("DES_PROD")
                    .Range(.Cells(nfila + I, 10), .Cells(nfila + I, 10)).Value = dtDatos.Rows(I)("DES_TRANS")
                    .Range(.Cells(nfila + I, 11), .Cells(nfila + I, 11)).Value = dtDatos.Rows(I)("TON_INGRESADO")
                    .Range(.Cells(nfila + I, 12), .Cells(nfila + I, 12)).Value = dtDatos.Rows(I)("TON_FACTURADO")
                    .Range(.Cells(nfila + I, 13), .Cells(nfila + I, 13)).Value = dtDatos.Rows(I)("MONEDA")
                    .Range(.Cells(nfila + I, 14), .Cells(nfila + I, 14)).Value = dtDatos.Rows(I)("PRECIO")
                    .Range(.Cells(nfila + I, 15), .Cells(nfila + I, 15)).Value = dtDatos.Rows(I)("VALOR_VTA")
                    .Range(.Cells(nfila + I, 16), .Cells(nfila + I, 16)).Value = dtDatos.Rows(I)("IGV")
                    .Range(.Cells(nfila + I, 17), .Cells(nfila + I, 17)).Value = dtDatos.Rows(I)("TOTAL")
                    .Range(.Cells(nfila + I, 18), .Cells(nfila + I, 18)).Value = dtDatos.Rows(I)("ORIGEN")

                    .Range(.Cells(nfila + I, 1), .Cells(nfila + I, 18)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(nfila + I, 1), .Cells(nfila + I, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(nfila + I, 1), .Cells(nfila + I, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    'nfila = nfila + 1
                    nfilaArea = nfilaArea + 1
                    ultFila = nfila + I
                Next
                '.Range(.Cells(1, 1), .Cells(ultFila, 4)).RowHeight = 15
                .Range(.Cells(nfila, 1), .Cells(10000, 30)).WrapText = False
                ultFila = ultFila + 1
                '.Range("I" & ultFila + 1).Value = "TOTAL"
                '.Range("J" & ultFila + 1).Value = "=SUMA(J6:J" & ultFila & ")"
                '.Range("I" & ultFila + 1 & ":J" & ultFila + 1).Font.Bold = True
                '.Range("I" & ultFila + 1 & ":J" & ultFila + 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                '.Range("I" & ultFila + 1 & ":J" & ultFila + 1).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                '.Range(.Cells(1, 5), .Cells(ultFila, 5)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop
            End With

            nfila = 2
            nfilaini = 2
            nfilault = 0
            nfilaArea = 2
            nfilainiArea = 2
            nfilaultArea = 0
            dtDatos = New DataTable
            dtDatos = dtDatos2
            With objHojaExcel2
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                '.Range("A4").Value = "REPORTE DE VALES SIN SUSTENTO TRIBUTARIO - " & nombreMEs(cmbMes.Value) & " " & txtAño.Value
                '.Range("A").ColumnWidth = 5
                '.Columns("A").ColumnWidth = 5
                '.Columns("E").NumberFormat = "#,##0.00"
                '.Columns("J").NumberFormat = "#,##0.00"
                Dim nmes As Int32 = 0
                For I As Int16 = 0 To dtDatos.Rows.Count - 1
                    'nmes = dtAnual.Rows(I)("MES")
                    .Range(.Cells(nfila + I, 1), .Cells(nfila + I, 1)).Value = dtDatos.Rows(I)("BILLETE")
                    .Range(.Cells(nfila + I, 2), .Cells(nfila + I, 2)).Value = dtDatos.Rows(I)("FACTURA")
                    .Range(.Cells(nfila + I, 3), .Cells(nfila + I, 3)).Value = dtDatos.Rows(I)("FECHABILLETE")
                    .Range(.Cells(nfila + I, 4), .Cells(nfila + I, 4)).Value = dtDatos.Rows(I)("FECHAFACTURA")
                    .Range(.Cells(nfila + I, 5), .Cells(nfila + I, 5)).Value = dtDatos.Rows(I)("CODCANTERA")
                    .Range(.Cells(nfila + I, 6), .Cells(nfila + I, 6)).Value = dtDatos.Rows(I)("CANTERA")
                    .Range(.Cells(nfila + I, 7), .Cells(nfila + I, 7)).Value = dtDatos.Rows(I)("COD_MATPRIMA")
                    .Range(.Cells(nfila + I, 8), .Cells(nfila + I, 8)).Value = dtDatos.Rows(I)("DES_PROD")
                    .Range(.Cells(nfila + I, 9), .Cells(nfila + I, 9)).Value = dtDatos.Rows(I)("DES_TRANS")
                    .Range(.Cells(nfila + I, 10), .Cells(nfila + I, 10)).Value = dtDatos.Rows(I)("TON_INGRESADO")
                    .Range(.Cells(nfila + I, 11), .Cells(nfila + I, 11)).Value = dtDatos.Rows(I)("TON_FACTURADO")
                    .Range(.Cells(nfila + I, 12), .Cells(nfila + I, 12)).Value = dtDatos.Rows(I)("MONEDA")
                    .Range(.Cells(nfila + I, 13), .Cells(nfila + I, 13)).Value = dtDatos.Rows(I)("PRECIO")
                    .Range(.Cells(nfila + I, 14), .Cells(nfila + I, 14)).Value = dtDatos.Rows(I)("VALOR_VTA")
                    .Range(.Cells(nfila + I, 15), .Cells(nfila + I, 15)).Value = dtDatos.Rows(I)("IGV")
                    .Range(.Cells(nfila + I, 16), .Cells(nfila + I, 16)).Value = dtDatos.Rows(I)("TOTAL")
                    .Range(.Cells(nfila + I, 17), .Cells(nfila + I, 17)).Value = dtDatos.Rows(I)("ORIGEN")

                    .Range(.Cells(nfila + I, 1), .Cells(nfila + I, 17)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(nfila + I, 1), .Cells(nfila + I, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(nfila + I, 1), .Cells(nfila + I, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    'nfila = nfila + 1
                    nfilaArea = nfilaArea + 1
                    ultFila = nfila + I
                Next
                '.Range(.Cells(1, 1), .Cells(ultFila, 4)).RowHeight = 15
                .Range(.Cells(nfila, 1), .Cells(10000, 30)).WrapText = False
                ultFila = ultFila + 1
                '.Range("I" & ultFila + 1).Value = "TOTAL"
                '.Range("J" & ultFila + 1).Value = "=SUMA(J6:J" & ultFila & ")"
                '.Range("I" & ultFila + 1 & ":J" & ultFila + 1).Font.Bold = True
                '.Range("I" & ultFila + 1 & ":J" & ultFila + 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                '.Range("I" & ultFila + 1 & ":J" & ultFila + 1).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                '.Range(.Cells(1, 5), .Cells(ultFila, 5)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop
            End With

        Catch ex As Exception

        End Try
    End Sub
End Class