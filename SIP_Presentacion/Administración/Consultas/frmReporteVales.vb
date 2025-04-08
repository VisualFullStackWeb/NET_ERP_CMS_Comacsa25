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
Public Class frmReporteVales
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
    Dim dsDatos As DataSet
    Dim dtMes As DataTable
    Dim dtAnual As DataTable
    Private Sub frmReporteVales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        Me.cmbMes.Value = Month(Now.Date)
    End Sub
    Sub Procesar()
        dsDatos = New DataSet
        dtMes = New DataTable
        dtAnual = New DataTable
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .año = txtAño.Value
                .mes = cmbMes.Value
                .User_Crea = User_Sistema
            End With
            dsDatos = oPrvFisN.ReporteSinSustento(oPrvFisE)
            dtMes = dsDatos.Tables(0)
            dtAnual = dsDatos.Tables(1)
            Call CargarUltraGridxBinding(Grid1, Source1, dtMes)
        Catch ex As Exception

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
            File.Delete(path & "\REPORTESINSUSTENTO.xls")
            File.Copy(RutaReporteERP & "PLANTILLAREPORTESINSUSTENTO.xls", path & "\REPORTESINSUSTENTO.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\REPORTESINSUSTENTO.xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcelIngreso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            'm_Excel.Visible = True
            exportarReporte(objHojaExcelIngreso)
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
    Sub exportarReporte(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 7
            Dim nfilaini As Integer = 7
            Dim nfilault As Integer = 0
            Dim nfilaArea As Integer = 7
            Dim nfilainiArea As Integer = 7
            Dim nfilaultArea As Integer = 0

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A4").Value = "REPORTE DE VALES SIN SUSTENTO TRIBUTARIO - " & nombreMEs(cmbMes.Value) & " " & txtAño.Value
                Dim nmes As Int32 = 0
                For I As Int16 = 0 To dtAnual.Rows.Count - 1
                    nmes = dtAnual.Rows(I)("MES")
                    .Range(.Cells(7 + I, 1), .Cells(7 + I, 1)).Value = I + 1
                    .Range(.Cells(7 + I, 2), .Cells(7 + I, 2)).Value = dtAnual.Rows(I)("CODTRABAJADOR")
                    .Range(.Cells(7 + I, 3), .Cells(7 + I, 3)).Value = dtAnual.Rows(I)("AREA")
                    .Range(.Cells(7 + I, 4), .Cells(7 + I, 4)).Value = dtAnual.Rows(I)("TRABAJADOR")
                    .Range(.Cells(7 + I, 5), .Cells(7 + I, 5)).Value = dtAnual.Rows(I)("CONCEPTO").ToString.Trim
                    .Range(.Cells(7 + I, 6), .Cells(7 + I, 6)).Value = dtAnual.Rows(I)("DESCRIPCION").ToString.Trim
                    .Range(.Cells(7 + I, 6 + nmes), .Cells(7 + I, 6 + nmes)).Value = dtAnual.Rows(I)("MONTOTOTAL")

                    .Range("S" & 7 + I).Value = "=SUMA(G" & 7 + I & ":R" & 7 + I & ")"

                    If I > 0 Then
                        If dtAnual.Rows(I)("CODTRABAJADOR") = dtAnual.Rows(I - 1)("CODTRABAJADOR") Then
                            nfilault = nfila
                        Else
                            .Range(.Cells(nfilaini, 2), .Cells(nfilault, 2)).Merge()
                            .Range(.Cells(nfilaini, 4), .Cells(nfilault, 4)).Merge()
                            nfilaini = nfila
                            nfilault = nfila
                        End If

                        If dtAnual.Rows(I)("AREA") = dtAnual.Rows(I - 1)("AREA") Then
                            nfilaultArea = nfilaArea
                        Else
                            .Range(.Cells(nfilainiArea, 3), .Cells(nfilaultArea, 3)).Merge()
                            nfilainiArea = nfilaArea
                            nfilaultArea = nfilaArea
                        End If
                    End If
                 
                    .Range(.Cells(7 + I, 1), .Cells(7 + I, 19)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(7 + I, 1), .Cells(7 + I, 19)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(7 + I, 1), .Cells(7 + I, 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    nfila = nfila + 1
                    nfilaArea = nfilaArea + 1
                    ultFila = 7 + I
                Next
                nfila = nfila + 1
                .Range("F" & nfila).Value = "TOTALES"
                .Range("G" & nfila).Value = "=SUMA(G1:G" & nfila - 2 & ")"
                .Range("H" & nfila).Value = "=SUMA(H1:H" & nfila - 2 & ")"
                .Range("I" & nfila).Value = "=SUMA(I1:I" & nfila - 2 & ")"
                .Range("J" & nfila).Value = "=SUMA(J1:J" & nfila - 2 & ")"
                .Range("K" & nfila).Value = "=SUMA(K1:K" & nfila - 2 & ")"
                .Range("L" & nfila).Value = "=SUMA(L1:L" & nfila - 2 & ")"
                .Range("M" & nfila).Value = "=SUMA(M1:M" & nfila - 2 & ")"
                .Range("N" & nfila).Value = "=SUMA(N1:N" & nfila - 2 & ")"
                .Range("O" & nfila).Value = "=SUMA(O1:O" & nfila - 2 & ")"
                .Range("P" & nfila).Value = "=SUMA(P1:P" & nfila - 2 & ")"
                .Range("Q" & nfila).Value = "=SUMA(Q1:Q" & nfila - 2 & ")"
                .Range("R" & nfila).Value = "=SUMA(R1:R" & nfila - 2 & ")"
                .Range("S" & nfila).Value = "=SUMA(S1:S" & nfila - 2 & ")"

                .Range("F" & nfila & ":S" & nfila).Font.Bold = True
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                '.Range("E" & nfila & ":Q" & nfila).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


                .Range(.Cells(nfilaini, 2), .Cells(nfilault, 2)).Merge()
                .Range(.Cells(nfilaini, 4), .Cells(nfilault, 4)).Merge()
                .Range(.Cells(nfilainiArea, 3), .Cells(nfilaultArea, 3)).Merge()
                .Range(.Cells(1, 1), .Cells(ultFila, 4)).RowHeight = 15
                .Range(.Cells(1, 1), .Cells(ultFila, 6)).WrapText = True
                .Range(.Cells(1, 6), .Cells(ultFila, 6)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop
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
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        Try
            With e.Layout
                .Bands(0).Columns("CODTRABAJADOR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                .Bands(0).Columns("CODTRABAJADOR").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                .Bands(0).Columns("TRABAJADOR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                .Bands(0).Columns("TRABAJADOR").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                .Bands(0).Columns("AREA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                .Bands(0).Columns("AREA").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class