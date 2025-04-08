Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop
Public Class frmdetalleProgramacion
    Public dtDatosProg As New DataTable
    Public pedido_eliminado As String = ""
    Public placa_eliminado As String = ""
    Public tonelada_eliminado As Double = 0
    Public nroviaje_eliminado As Int32 = 0
    Public dtEliminados As New DataTable
    Public dtOrdenada As New DataTable
    Private Sub frmdetalleProgramacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dtEliminados = New DataTable
            dtEliminados.Columns.Add("PEDIDO")
            dtEliminados.Columns.Add("PLACA")
            dtEliminados.Columns.Add("TONELADA")
            dtEliminados.Columns.Add("NROVIAJE")
            If dtDatosProg.Rows.Count > 0 Then
                Me.Text = "DETALLE DE PROGRAMACION  - PLACA " & dtDatosProg.Rows(0)("PLACA")
            End If
            'Dim view As DataView = New DataView(dtDatosProg)
            'view.Sort = "ORDEN"
            'dtOrdenada = view.ToTable("TABLA", True, "ORDEN")
            'dtProgramacion = view.Table
            Call CargarUltraGridxBinding(Me.gridDetalle, Source1, dtDatosProg)
            'dtOrdenada = view.ToTable("TABLA", True, "ORDEN")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gridDetalle_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridDetalle.ClickCell
        Try
            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "ELIMINAR" Then
                If gridDetalle.ActiveRow.Cells("EXISTE").Value = 1 Then
                    MsgBox("Este pedido ya fue guiado y no puede eliminarse", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
                If MsgBox("Seguro de eliminar la programación?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                    pedido_eliminado = gridDetalle.ActiveRow.Cells("NUMPEDIDO").Value.ToString
                    placa_eliminado = gridDetalle.ActiveRow.Cells("PLACA").Value.ToString
                    tonelada_eliminado = CDbl(gridDetalle.ActiveRow.Cells("TONELADA").Value).ToString("##0.0000")
                    nroviaje_eliminado = gridDetalle.ActiveRow.Cells("NROVIAJE").Value
                    dtDatosProg.Rows.RemoveAt(gridDetalle.ActiveRow.Index)
                    Dim dr As DataRow
                    dr = dtEliminados.NewRow
                    dr(0) = pedido_eliminado
                    dr(1) = placa_eliminado
                    dr(2) = tonelada_eliminado
                    dr(3) = nroviaje_eliminado
                    dtEliminados.Rows.Add(dr)
                    'frmProgramacionCamion.eliminaProgramacion(pedido_eliminado, placa_eliminado, tonelada_eliminado)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        exportar()
    End Sub
    Sub exportar()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            If gridDetalle.Rows.Count > 0 Then
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\PROGRAMACIONCAMION.xls")
                File.Copy(RutaReporteERP & "PLANTILLAPROGRAMACIONCAMION.xls", path & "\PROGRAMACIONCAMION.xls")
                m_Excel.Workbooks.Open(path & "\PROGRAMACIONCAMION.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 7
                nfilaini = 7

                With objHojaExcel
                    .Activate()
                    .Range("D1").Value = "PROGRAMACION POR CAMION : PLACA " & gridDetalle.Rows(0).Cells("PLACA").Value & ""
                    .Range("D1").Font.Bold = True
                    Dim filaultima As Int32 = 0
                    Dim contactivo As Int32 = 0
                    For i As Int16 = 0 To gridDetalle.Rows.Count - 1
                        '.Range("A" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("NUMDOC").Value
                        .Range("B" & nfilaini + i).Value = gridDetalle.Rows(i).Cells("NUMPEDIDO").Value
                        .Range("C" & nfilaini + i).Value = gridDetalle.Rows(i).Cells("CLIENTE").Value
                        '.Range("C" & nfilaini & "D" & nfilaini).Merge()
                        .Range(.Cells(nfilaini + i, 3), .Cells(nfilaini + i, 4)).Merge()
                        '.Range("D" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("COD_MATPRIMA").Value
                        .Range("E" & nfilaini + i).Value = gridDetalle.Rows(i).Cells("DISTRITO").Value
                        .Range("F" & nfilaini + i).Value = gridDetalle.Rows(i).Cells("DIRECCION").Value
                        .Range("G" & nfilaini + i).Value = gridDetalle.Rows(i).Cells("REFERENCIA").Value
                        .Range("H" & nfilaini + i).Value = gridDetalle.Rows(i).Cells("PRODUCTO").Value
                        .Range("I" & nfilaini + i).Value = gridDetalle.Rows(i).Cells("HORA").Value
                        .Range("J" & nfilaini + i).Value = "TM"
                        .Range("K" & nfilaini + i).Value = gridDetalle.Rows(i).Cells("TONELADA").Value
                        .Range(.Cells(nfilaini + i, 2), .Cells(nfilaini + i, 11)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfila + 1
                        filaultima = nfilaini + i
                    Next
                    filaultima += 1
                    .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 10)).Value = "TOTAL"
                    .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 10)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(filaultima + 1, 11), .Cells(filaultima + 1, 11)).Formula = "=SUMA(K5:K" & filaultima & ")"

                    '.Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                    .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 11)).Font.Bold = True
                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub btnSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubir.Click
        Try
            If gridDetalle.ActiveRow.Index = 0 Then Exit Sub
            Dim index = gridDetalle.ActiveRow.Index
            Dim up As Object = dtDatosProg.Rows(index).ItemArray
            Dim down As Object = dtDatosProg.Rows(index - 1).ItemArray
            dtDatosProg.Rows(index).ItemArray = down
            dtDatosProg.Rows(index - 1).ItemArray = up
            gridDetalle.Rows(index - 1).Cells(0).Activate()
            gridDetalle.Rows(index).Selected = False
            gridDetalle.Rows(index - 1).Selected = True
            Call CargarUltraGridxBinding(Me.gridDetalle, Source1, dtDatosProg)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBajar.Click
        Try
            If gridDetalle.ActiveRow.Index = gridDetalle.Rows.Count - 1 Then Exit Sub
            Dim index = gridDetalle.ActiveRow.Index
            Dim down As Object = dtDatosProg.Rows(index).ItemArray
            Dim up As Object = dtDatosProg.Rows(index + 1).ItemArray
            dtDatosProg.Rows(index).ItemArray = up
            dtDatosProg.Rows(index + 1).ItemArray = down
            gridDetalle.Rows(index + 1).Cells(0).Activate()
            gridDetalle.Rows(index).Selected = False
            gridDetalle.Rows(index + 1).Selected = True
            Call CargarUltraGridxBinding(Me.gridDetalle, Source1, dtDatosProg)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub gridDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDetalle.InitializeLayout

    End Sub
End Class