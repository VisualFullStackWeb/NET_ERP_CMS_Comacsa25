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
Public Class frmInventarioIQBF
    Public Ls_Permisos As New List(Of Integer)
    Dim procesado As Int32
    Dim _objNegocio As NGInsumosFiscalizados
    Dim _objEntidad As ETInsumosFiscalizados
    Dim cierre As Int32 = 0

    Private Sub frmInventarioIQBF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Year(Now.Date)
        dtpfecha.Value = Now.Date
    End Sub
    Sub Reporte()
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DtIngreso As DataTable = Nothing
        Dim DtEgreso As DataTable = Nothing
        Dim DtProduccion As DataTable = Nothing
        Dim DtUso As DataTable = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .Cod_Cia = Companhia
                .año = txtAño.Value - 1
                .Fecha = "31/12/" & (txtAño.Value - 1).ToString
            End With
            oPrvFisN.RptInventarioIQBF(oPrvFisE)

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .Cod_Cia = Companhia
                .año = txtAño.Value
                .Fecha = dtpfecha.Value
            End With
            DtIngreso = oPrvFisN.RptInventarioIQBF(oPrvFisE)

            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\INVENTARIOIQBF_" & txtAño.Value & ".xls")
            File.Copy(RutaReporteERP & "INVENTARIOIQBF.xls", path & "\INVENTARIOIQBF_" & txtAño.Value & ".xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait

            m_Excel.Workbooks.Open(path & "\INVENTARIOIQBF_" & txtAño.Value & ".xls")

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            objHojaExcel.Name = "Reporte"
          
            exportarIngreso(objHojaExcel, DtIngreso)

            m_Excel.Visible = True
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
            'MessageBox.Show("Se proceso correctamente la información.", "Sistema", MessageBoxButtons.OK)
            'Tab1.Tabs("T02").Selected = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            oPrvFisN = Nothing
            oPrvFisE = Nothing
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub

    Sub exportarIngreso(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal datos As DataTable)
        Try
            If datos.Rows.Count <= 0 Then Exit Sub

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()

                '.Range("A1").Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
                '.Range("A4").Value = "(Kilogramos, DEL 01 ENE " & txtAño.Value & " AL 31 DIC " & txtAño.Value & ")"
                .Range("A4").Value = "(Presentaciones, DEL 01/01/" & Year(dtpfecha.Value).ToString & " AL " & dtpfecha.Value.ToString("dd/MM/yyyy") & ")"
                .Range("D5").Value = "Saldo Incial 01/01/" & Year(dtpfecha.Value).ToString & ""
                '(Kilogramos, DEL 01 ENE 2018 AL 31 DIC 2018)
                '.Range(.Cells(Numero, 1), .Cells(Numero, 17)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                Dim nfila As Int32 = 7
                For i As Int32 = 0 To datos.Rows.Count - 1
                    '.Range("A" & nfila + i & ":" & "O" & nfila + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("A" & nfila + i).Value = datos.Rows(i)("ITEM")
                    .Range("B" & nfila + i).Value = datos.Rows(i)("DES_SUNAT")
                    .Range("C" & nfila + i).Value = datos.Rows(i)("PRESENTACION")
                    .Range("D" & nfila + i).Value = datos.Rows(i)("SALDO_INICIAL")
                    .Range("E" & nfila + i).Value = datos.Rows(i)("INGRESO_COMPRA")
                    .Range("F" & nfila + i).Value = datos.Rows(i)("INGRESO_DEVOLUCION")
                    .Range("G" & nfila + i).Value = datos.Rows(i)("EGRESONEGO")
                    .Range("H" & nfila + i).Value = datos.Rows(i)("EGRESOOBT")
                    .Range("I" & nfila + i).Value = datos.Rows(i)("EGRESOBF")
                    .Range("J" & nfila + i).Value = datos.Rows(i)("INGRESOBF")
                    .Range("K" & nfila + i).Value = datos.Rows(i)("NACIONAL")
                    .Range("L" & nfila + i).Value = datos.Rows(i)("EXPORTACION")
                    .Range("M" & nfila + i).Value = datos.Rows(i)("GENERAL_INGRESO")
                    .Range("N" & nfila + i).Value = datos.Rows(i)("GENERAL_EGRESO")
                    .Range("O" & nfila + i).Formula = "=D" & nfila + i & "+E" & nfila + i & "+F" & nfila + i & "-G" & nfila + i & "-H" & nfila + i & "-I" & nfila + i & "+J" & nfila + i & "-K" & nfila + i & "-L" & nfila + i & "+M" & nfila + i & "-N" & nfila + i & ""
                Next
                'm_Excel.Visible = True
                'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class