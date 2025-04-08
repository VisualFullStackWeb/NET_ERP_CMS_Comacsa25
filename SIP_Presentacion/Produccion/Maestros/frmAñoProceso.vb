Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class frmAñoProceso

    Private Sub frmAñoProceso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Now.Date.Year
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Negocio.Producto = New NGProducto
        Entidad.MyLista = New ETMyLista
        Dim dtReporte As New DataTable

        lblmensaje.Visible = True
        lblmensaje.Refresh()

        dtReporte = Negocio.Producto.Rpt_ReporteProyectadoMineral(txtAño.Value)

        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            If dtReporte.Rows.Count > 0 Then

                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\PROYECCIONMINERAL.xls")
                File.Copy(RutaReporteERP & "PLANTILLAPROYECCIONMINERAL.xls", path & "\PROYECCIONMINERAL.xls")
                m_Excel.Workbooks.Open(path & "\PROYECCIONMINERAL.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 6
                nfilaini = 6

                With objHojaExcel
                    .Activate()
                    .Range("B3").Value = "PROYECCION DE MATERIA PRIMA " & txtAño.Value
                    .Range("B3").Font.Bold = True
                    Dim filaultima As Int32 = 0
                    For i As Int16 = 0 To dtReporte.Rows.Count - 1
                        .Range("B" & nfilaini + i).Value = dtReporte.Rows(i)("CODRUMA")
                        .Range("C" & nfilaini + i).Value = dtReporte.Rows(i)("MINERAL")
                        .Range("D" & nfilaini + i).Value = dtReporte.Rows(i)("ENERO")
                        .Range("E" & nfilaini + i).Value = dtReporte.Rows(i)("FEBRERO")
                        .Range("F" & nfilaini + i).Value = dtReporte.Rows(i)("MARZO")
                        .Range("G" & nfilaini + i).Value = dtReporte.Rows(i)("ABRIL")
                        .Range("H" & nfilaini + i).Value = dtReporte.Rows(i)("MAYO")
                        .Range("I" & nfilaini + i).Value = dtReporte.Rows(i)("JUNIO")
                        .Range("J" & nfilaini + i).Value = dtReporte.Rows(i)("JULIO")
                        .Range("K" & nfilaini + i).Value = dtReporte.Rows(i)("AGOSTO")
                        .Range("L" & nfilaini + i).Value = dtReporte.Rows(i)("SETIEMBRE")
                        .Range("M" & nfilaini + i).Value = dtReporte.Rows(i)("OCTUBRE")
                        .Range("N" & nfilaini + i).Value = dtReporte.Rows(i)("NOVIEMBRE")
                        .Range("O" & nfilaini + i).Value = dtReporte.Rows(i)("DICIEMBRE")
                        .Range("P" & nfilaini + i).Value = "=SUMA(D" & nfilaini + i & ":O" & nfilaini + i & ")"
                        .Range(.Cells(nfilaini + i, 2), .Cells(nfilaini + i, 2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfila + 1
                        'filaultima = 5 + i
                    Next
                    filaultima = nfila - 1
                    .Range("B" & nfila).Value = "Total general"
                    .Range("D" & nfila).Value = "=SUMA(D" & nfilaini & ":D" & filaultima & ")"
                    .Range("E" & nfila).Value = "=SUMA(E" & nfilaini & ":E" & filaultima & ")"
                    .Range("F" & nfila).Value = "=SUMA(F" & nfilaini & ":F" & filaultima & ")"
                    .Range("G" & nfila).Value = "=SUMA(G" & nfilaini & ":G" & filaultima & ")"
                    .Range("H" & nfila).Value = "=SUMA(H" & nfilaini & ":H" & filaultima & ")"
                    .Range("I" & nfila).Value = "=SUMA(I" & nfilaini & ":I" & filaultima & ")"
                    .Range("J" & nfila).Value = "=SUMA(J" & nfilaini & ":J" & filaultima & ")"
                    .Range("K" & nfila).Value = "=SUMA(K" & nfilaini & ":K" & filaultima & ")"
                    .Range("L" & nfila).Value = "=SUMA(L" & nfilaini & ":L" & filaultima & ")"
                    .Range("M" & nfila).Value = "=SUMA(M" & nfilaini & ":M" & filaultima & ")"
                    .Range("N" & nfila).Value = "=SUMA(N" & nfilaini & ":N" & filaultima & ")"
                    .Range("O" & nfila).Value = "=SUMA(O" & nfilaini & ":O" & filaultima & ")"
                    .Range("P" & nfila).Value = "=SUMA(P" & nfilaini & ":P" & filaultima & ")"
                    .Range(.Cells(nfila, 2), .Cells(nfila, 16)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                    .Range(.Cells(nfila, 2), .Cells(nfila, 16)).Font.Bold = True
                End With
                m_Excel.Visible = True
                Me.Close()
            Else
                MsgBox("No hay datos a procesar", MsgBoxStyle.Information, "Comacsa")
            End If
        Catch ex As Exception

        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub
End Class