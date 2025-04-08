Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class frmMaqPesada
    Dim dtDatos As DataSet
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista
#Region "Variables"
    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private ListModulos As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim Ope = 1
#End Region
    Private Sub frmMaqPesada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        cmbMes.Value = Month(Now.Date)
        dtDatos = New DataSet
    End Sub
    Sub Procesar()
        CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._ayo = txtAño.Value
            objEntidad._mes = cmbMes.Value
            dtDatos = objNegocio.MaqPesada(objEntidad)
            Call CargarUltraGridxBinding(GridConsultas, Source1, dtDatos.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Sub Reporte()
        Try
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            ReporteDetalle()
        Catch ex As Exception
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End Try
    End Sub
    Sub ReporteDetalle()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            Dim cadenaSolicitud As String = String.Empty
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

            If dtDatos.Tables(0).Rows.Count > 0 Then
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTE.xls")
                File.Copy(RutaReporteERP & "PLANTILLAMAQPESADA.xls", path & "\REPORTE.xls")
                m_Excel.Workbooks.Open(path & "\REPORTE.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                'objHojaExcel.Name = "RESUMEN"
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 5
                nfilaini = 5
                Dim filaultima As Int32 = 0
                With objHojaExcel
                    .Activate()
                    .Range("B2").Value = "RESUMEN GASTOS DE VIAJE                    " & cmbMes.Text & " " & txtAño.Value
                    .Range("E2").Value = "DETALLE DE GASTOS VIAJE POR CONCEPTOS - " & cmbMes.Text & " " & txtAño.Value

                    For i As Int16 = 0 To dtDatos.Tables(0).Rows.Count - 1
                        .Range("B" & nfila + i).Value = dtDatos.Tables(0).Rows(i)("TRABAJADOR")
                        .Range("C" & nfila + i).Value = dtDatos.Tables(0).Rows(i)("TOTAL")
                        .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 3)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nfila = nfila + 1
                        filaultima = nfila + i
                    Next
                    For i As Int16 = 0 To dtDatos.Tables(1).Rows.Count - 1
                        .Range("E" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("TRABAJADOR")
                        .Range("F" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("VIATICOS")
                        .Range("G" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("PASAJE")
                        .Range("H" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("COMBUSTIBLE")
                        .Range("I" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("REPUESTO_MAQUINARIA")
                        .Range("J" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("REPUESTO_CORRECTIVO")
                        .Range("K" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("REPUESTO_PREVENTIVO")
                        .Range("L" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("REPUESTO_VEHICULO")
                        .Range("M" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("REPARMANTE")
                        .Range("N" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("MANTENIMIENTO_MAQUINARIA")
                        .Range("O" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("MANTENIMIENTO_CORRECTIVO")
                        .Range("P" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("MANTENIMIENTO_PREVENTIVO")
                        .Range("Q" & nfila + i).Value = dtDatos.Tables(1).Rows(i)("OTROS")
                        .Range("R" & nfila + i).Formula = "=SUMA(F" & nfila + i & ":Q" & nfila + i & ")"
                        .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 19)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Rows(nfila + i & ":" & nfila + i).RowHeight = 51.75
                        'nfila = nfila + 1
                        filaultima = nfila + i
                    Next
                    .Range("B" & filaultima + 2).Value = "TOTALES"
                    .Range("E" & filaultima + 2).Value = "TOTALES"
                    .Range("B" & filaultima + 2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Range("E" & filaultima + 2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Range("C" & filaultima + 2).Formula = "=SUMA(C" & nfila & ":C" & filaultima & ")"
                    .Range("R" & filaultima + 2).Formula = "=SUMA(R" & nfila & ":R" & filaultima & ")"
                    .Range(.Cells(filaultima + 2, 3), .Cells(filaultima + 2, 3)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                    .Range(.Cells(filaultima + 2, 3), .Cells(filaultima + 2, 3)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 2, 18), .Cells(filaultima + 2, 18)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                    .Range(.Cells(filaultima + 2, 18), .Cells(filaultima + 2, 18)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 2, 18), .Cells(filaultima + 2, 18)).Font.Bold = True
                    .Range(.Cells(filaultima + 2, 5), .Cells(filaultima + 2, 5)).Font.Bold = True
                    .Range(.Cells(filaultima + 2, 2), .Cells(filaultima + 2, 3)).Font.Bold = True
                End With

                Dim objHojaExcel2 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
                'objHojaExcel2.Name = "BASE DE DATOS"
                m_Excel.DisplayAlerts = False
                With objHojaExcel2
                    For i As Int16 = 0 To dtDatos.Tables(2).Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("NUMSOLICITUD")
                        .Range("B" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("FECHA")
                        .Range("C" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("TRABAJADOR")
                        .Range("D" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("TIPODOC")
                        .Range("E" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("NUMDOC")
                        .Range("F" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("NRORUC")
                        .Range("G" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("RAZON")
                        .Range("H" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("CONCEPTO")
                        .Range("I" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("TOTAL")
                        .Range("J" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("CANTERA")
                        .Range("K" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("COMENTARIO")
                        .Range("L" & nfila + i).Value = dtDatos.Tables(2).Rows(i)("AUXILIAR")
                        .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nfila = nfila + 1
                        filaultima = nfila + i
                    Next
                End With

                nfila = 13
                nfilaini = 13

                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

End Class