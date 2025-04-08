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
Public Class frmConsultaViaticos
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
    Private Sub frmConsultaViaticos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        Me.cmbMes.Value = Month(Now.Date)
    End Sub
    Dim DtRAlimentacion As DataTable = Nothing
    Dim DtRHospedaje As DataTable = Nothing
    Sub Procesar()

        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DsReporte As DataSet = Nothing
        Dim DtPromedio As DataTable = Nothing
        Dim DtDetalle As DataTable = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Procesando reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .año = txtAño.Value
                .mes = cmbMes.Value
                .User_Crea = User_Sistema
            End With
            DsReporte = oPrvFisN.ReporteViaticos(oPrvFisE)
            DtPromedio = DsReporte.Tables(0)
            DtRAlimentacion = DsReporte.Tables(1)
            DtRHospedaje = DsReporte.Tables(2)
            'DtDetalle = DsReporte.Tables(1)
            Tab1.Tabs("T01").Selected = Boolean.TrueString
            Call CargarUltraGridxBinding(Grid1, Source1, DtPromedio)
            'Call CargarUltraGridxBinding(Grid2, Source2, New DataTable)
            'Call CargarUltraGridxBinding(Grid2, Source2, DtDetalle)

            'lblmensaje.Text = "Procesando datos venta de mineral..."
            lblmensaje.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub

    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return
        
        Viatico_Detalle()
    End Sub
    Sub Viatico_Detalle()
        'If uRow Is Nothing Then
        '    Return
        'End If
        Dim codtrabajador As String = String.Empty
        codtrabajador = Grid1.ActiveRow.Cells("CODTRABAJADOR").Value
        lbltrabajador.Text = Grid1.ActiveRow.Cells("TRABAJADOR").Value
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DsReporte As DataSet = Nothing
        Dim DtPromedio As DataTable = Nothing
        Dim DtDetalle As DataTable = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Procesando reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .Cod_Prov = codtrabajador
                .año = txtAño.Value
                .mes = cmbMes.Value
                .User_Crea = User_Sistema
            End With
            DsReporte = oPrvFisN.ReporteDetalleViaticos(oPrvFisE)
            DtDetalle = DsReporte.Tables(0)
            Call CargarUltraGridxBinding(Grid2, Source2, DtDetalle)
            lblmensaje.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub

    Sub Reporte()
        If Tab1.Tabs("T01").Selected = Boolean.TrueString Then
            ReportePromedio()
        Else
            ReporteDetalle()
        End If
    End Sub
    Sub ReportePromedio()
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
            File.Delete(path & "\PROMEDIOVIATICOS.xls")
            File.Copy(RutaReporteERP & "PLANTILLAPROMEDIOVIATICOS.xls", path & "\PROMEDIOVIATICOS.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\PROMEDIOVIATICOS.xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcelDetalle2 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            Dim objHojaExcelDetalle3 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            Dim objHojaExcelDetalle4 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
            exportarPromedio(objHojaExcelDetalle)
            exportarPromedioHospedaje(objHojaExcelDetalle2)
            exportarPromedioMovilidad(objHojaExcelDetalle3)
            exportarPromedioResumen(objHojaExcelDetalle4)
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
    Sub ReporteDetalle()
        If Grid2.Rows.Count <= 0 Then
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
            File.Delete(path & "\DETALLEVIATICOS.xls")
            File.Copy(RutaReporteERP & "PLANTILLADETALLEVIATICOS.xls", path & "\DETALLEVIATICOS.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\DETALLEVIATICOS.xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            'm_Excel.Visible = True
            'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
            exportarDetalle(objHojaExcelDetalle)
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

    Sub exportarPromedio(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A4").Value = "REPORTE DE ALIMENTACION - " & mesNumero(cmbMes.Value) & " " & txtAño.Value
                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(7 + i, 1), .Cells(7 + i, 1)).Value = i + 1
                    .Range(.Cells(7 + i, 2), .Cells(7 + i, 2)).Value = Grid1.Rows(i).Cells("CODTRABAJADOR").Value
                    .Range(.Cells(7 + i, 3), .Cells(7 + i, 3)).Value = Grid1.Rows(i).Cells("TRABAJADOR").Value

                    .Range(.Cells(7 + i, 4), .Cells(7 + i, 4)).Value = Grid1.Rows(i).Cells("TOTALALIMENTACION").Value
                    If Grid1.Rows(i).Cells("TOTALALIMENTACION").Value > 0 Then
                        .Range(.Cells(7 + i, 5), .Cells(7 + i, 5)).Value = Grid1.Rows(i).Cells("DIASALIMENTACION").Value
                    Else
                        .Range(.Cells(7 + i, 5), .Cells(7 + i, 5)).Value = 0
                    End If
                    .Range(.Cells(7 + i, 6), .Cells(7 + i, 6)).Value = Grid1.Rows(i).Cells("ALIMENTACION").Value
                    .Range(.Cells(7 + i, 1), .Cells(7 + i, 6)).WrapText = False
                    .Range(.Cells(7 + i, 1), .Cells(7 + i, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    ultFila = i + 7
                Next
                ultFila = ultFila + 1
                .Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 6)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                '.Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 6)).Font.Bold = True
                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 3)).Value = "TOTALES"
                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 3)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 4)).Formula = "=SUMA(D7:D" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 5)).Formula = "=SUMA(E7:E" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 6), .Cells(1 + ultFila, 6)).Formula = "=SUMA(F7:F" & ultFila & ")"

                .Range(.Cells(5 + ultFila, 1), .Cells(5 + ultFila, 7)).Merge()
                .Range(.Cells(5 + ultFila, 1), .Cells(5 + ultFila, 1)).Value = "RESUMEN"
                .Range(.Cells(6 + ultFila, 1), .Cells(6 + ultFila, 7)).Merge()
                .Range(.Cells(6 + ultFila, 1), .Cells(6 + ultFila, 1)).Value = "RESTAURANTES  MAS CONCURRIDOS EN EL MES DE " & mesNumero(cmbMes.Value)
                .Range(.Cells(5 + ultFila, 1), .Cells(6 + ultFila, 5)).Font.Bold = True

                .Range(.Cells(8 + ultFila, 1), .Cells(8 + ultFila, 1)).Value = "ITEM"
                .Range(.Cells(8 + ultFila, 2), .Cells(8 + ultFila, 2)).Value = "RUC"
                .Range(.Cells(8 + ultFila, 3), .Cells(8 + ultFila, 3)).Value = "RAZON SOCIAL"
                .Range(.Cells(8 + ultFila, 4), .Cells(8 + ultFila, 4)).Value = "IMPORTE TOTAL"
                .Range(.Cells(8 + ultFila, 4), .Cells(8 + ultFila, 4)).WrapText = True
                .Range(.Cells(8 + ultFila, 5), .Cells(8 + ultFila, 5)).Value = "N° DE VECES"
                .Range(.Cells(8 + ultFila, 5), .Cells(8 + ultFila, 5)).WrapText = True
                .Range(.Cells(8 + ultFila, 6), .Cells(8 + ultFila, 6)).Value = "DPTO."
                .Range(.Cells(8 + ultFila, 7), .Cells(8 + ultFila, 7)).Value = "DIRECCION"
                .Range(.Cells(8 + ultFila, 1), .Cells(8 + ultFila, 7)).Font.Bold = True
                .Range(.Cells(8 + ultFila, 1), .Cells(8 + ultFila, 7)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(8 + ultFila, 1), .Cells(8 + ultFila, 7)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                If DtRAlimentacion.Rows.Count > 0 Then
                    For a As Int32 = 0 To DtRAlimentacion.Rows.Count - 1
                        .Range(.Cells(9 + ultFila + a, 1), .Cells(9 + ultFila + a, 1)).Value = a + 1
                        .Range(.Cells(9 + ultFila + a, 2), .Cells(9 + ultFila + a, 2)).Value = DtRAlimentacion.Rows(a)("NRORUC")
                        .Range(.Cells(9 + ultFila + a, 3), .Cells(9 + ultFila + a, 3)).Value = DtRAlimentacion.Rows(a)("RAZON")
                        .Range(.Cells(9 + ultFila + a, 4), .Cells(9 + ultFila + a, 4)).Value = DtRAlimentacion.Rows(a)("TOTAL")
                        .Range(.Cells(9 + ultFila + a, 5), .Cells(9 + ultFila + a, 5)).Value = DtRAlimentacion.Rows(a)("VECES")
                        .Range(.Cells(9 + ultFila + a, 6), .Cells(9 + ultFila + a, 6)).Value = DtRAlimentacion.Rows(a)("DPTO")
                        .Range(.Cells(8 + ultFila + a, 1), .Cells(9 + ultFila + a, 7)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    Next
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub exportarPromedioHospedaje(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                .Range("A4").Value = "REPORTE DE HOSPEDAJE - " & mesNumero(cmbMes.Value) & " " & txtAño.Value
                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(7 + i, 1), .Cells(7 + i, 1)).Value = i + 1
                    .Range(.Cells(7 + i, 2), .Cells(7 + i, 2)).Value = Grid1.Rows(i).Cells("CODTRABAJADOR").Value
                    .Range(.Cells(7 + i, 3), .Cells(7 + i, 3)).Value = Grid1.Rows(i).Cells("TRABAJADOR").Value

                    .Range(.Cells(7 + i, 4), .Cells(7 + i, 4)).Value = Grid1.Rows(i).Cells("TOTALHOSPEDAJE").Value

                    If Grid1.Rows(i).Cells("TOTALHOSPEDAJE").Value > 0 Then
                        .Range(.Cells(7 + i, 5), .Cells(7 + i, 5)).Value = Grid1.Rows(i).Cells("DIASHOSPEDAJE").Value
                    Else
                        .Range(.Cells(7 + i, 5), .Cells(7 + i, 5)).Value = 0
                    End If

                    '.Range(.Cells(7 + i, 5), .Cells(7 + i, 5)).Value = Grid1.Rows(i).Cells("DIASHOSPEDAJE").Value
                    .Range(.Cells(7 + i, 6), .Cells(7 + i, 6)).Value = Grid1.Rows(i).Cells("HOSPEDAJE").Value
                    .Range(.Cells(7 + i, 1), .Cells(7 + i, 6)).WrapText = False
                    .Range(.Cells(7 + i, 1), .Cells(7 + i, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    ultFila = i + 7
                Next
                ultFila = ultFila + 1
                '.Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 6)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 6)).Font.Bold = True
                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 3)).Value = "TOTALES"
                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 3)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 4)).Formula = "=SUMA(D7:D" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 5)).Formula = "=SUMA(E7:E" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 6), .Cells(1 + ultFila, 6)).Formula = "=SUMA(F7:F" & ultFila & ")"

                .Range(.Cells(5 + ultFila, 1), .Cells(5 + ultFila, 7)).Merge()
                .Range(.Cells(5 + ultFila, 1), .Cells(5 + ultFila, 1)).Value = "RESUMEN"
                .Range(.Cells(6 + ultFila, 1), .Cells(6 + ultFila, 7)).Merge()
                .Range(.Cells(6 + ultFila, 1), .Cells(6 + ultFila, 1)).Value = "HOSPEDAJES  MAS CONCURRIDOS EN EL MES DE " & mesNumero(cmbMes.Value)
                .Range(.Cells(5 + ultFila, 1), .Cells(6 + ultFila, 5)).Font.Bold = True

                .Range(.Cells(8 + ultFila, 1), .Cells(8 + ultFila, 1)).Value = "ITEM"
                .Range(.Cells(8 + ultFila, 2), .Cells(8 + ultFila, 2)).Value = "RUC"
                .Range(.Cells(8 + ultFila, 3), .Cells(8 + ultFila, 3)).Value = "RAZON SOCIAL"
                .Range(.Cells(8 + ultFila, 4), .Cells(8 + ultFila, 4)).Value = "IMPORTE TOTAL"
                .Range(.Cells(8 + ultFila, 4), .Cells(8 + ultFila, 4)).WrapText = True
                .Range(.Cells(8 + ultFila, 5), .Cells(8 + ultFila, 5)).Value = "N° DE VECES"
                .Range(.Cells(8 + ultFila, 5), .Cells(8 + ultFila, 5)).WrapText = True
                .Range(.Cells(8 + ultFila, 6), .Cells(8 + ultFila, 6)).Value = "DPTO."
                .Range(.Cells(8 + ultFila, 7), .Cells(8 + ultFila, 7)).Value = "DIRECCION"
                .Range(.Cells(8 + ultFila, 1), .Cells(8 + ultFila, 7)).Font.Bold = True
                .Range(.Cells(8 + ultFila, 1), .Cells(8 + ultFila, 7)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(8 + ultFila, 1), .Cells(8 + ultFila, 7)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                If DtRHospedaje.Rows.Count > 0 Then
                    For a As Int32 = 0 To DtRHospedaje.Rows.Count - 1
                        .Range(.Cells(9 + ultFila + a, 1), .Cells(9 + ultFila + a, 1)).Value = a + 1
                        .Range(.Cells(9 + ultFila + a, 2), .Cells(9 + ultFila + a, 2)).Value = DtRHospedaje.Rows(a)("NRORUC")
                        .Range(.Cells(9 + ultFila + a, 3), .Cells(9 + ultFila + a, 3)).Value = DtRHospedaje.Rows(a)("RAZON")
                        .Range(.Cells(9 + ultFila + a, 4), .Cells(9 + ultFila + a, 4)).Value = DtRHospedaje.Rows(a)("TOTAL")
                        .Range(.Cells(9 + ultFila + a, 5), .Cells(9 + ultFila + a, 5)).Value = DtRAlimentacion.Rows(a)("VECES")
                        .Range(.Cells(9 + ultFila + a, 6), .Cells(9 + ultFila + a, 6)).Value = DtRHospedaje.Rows(a)("DPTO")
                        .Range(.Cells(8 + ultFila + a, 1), .Cells(9 + ultFila + a, 7)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    Next
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub exportarPromedioMovilidad(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                .Range("A4").Value = "REPORTE DE MOVILIDAD - " & mesNumero(cmbMes.Value) & " " & txtAño.Value
                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(7 + i, 1), .Cells(7 + i, 1)).Value = i + 1
                    .Range(.Cells(7 + i, 2), .Cells(7 + i, 2)).Value = Grid1.Rows(i).Cells("CODTRABAJADOR").Value
                    .Range(.Cells(7 + i, 3), .Cells(7 + i, 3)).Value = Grid1.Rows(i).Cells("TRABAJADOR").Value

                    .Range(.Cells(7 + i, 4), .Cells(7 + i, 4)).Value = Grid1.Rows(i).Cells("TOTALMOVILIDAD").Value

                    If Grid1.Rows(i).Cells("TOTALMOVILIDAD").Value > 0 Then
                        .Range(.Cells(7 + i, 5), .Cells(7 + i, 5)).Value = Grid1.Rows(i).Cells("DIASMOVILIDAD").Value
                    Else
                        .Range(.Cells(7 + i, 5), .Cells(7 + i, 5)).Value = 0
                    End If
                    '.Range(.Cells(7 + i, 5), .Cells(7 + i, 5)).Value = Grid1.Rows(i).Cells("DIASMOVILIDAD").Value
                    .Range(.Cells(7 + i, 6), .Cells(7 + i, 6)).Value = Grid1.Rows(i).Cells("MOVILIDAD").Value
                    .Range(.Cells(7 + i, 1), .Cells(7 + i, 6)).WrapText = False
                    .Range(.Cells(7 + i, 1), .Cells(7 + i, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    ultFila = i + 7
                Next
                ultFila = ultFila + 1
                '.Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 6)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 6)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 6)).Font.Bold = True
                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 3)).Value = "TOTALES"
                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 3)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 4)).Formula = "=SUMA(D7:D" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 5)).Formula = "=SUMA(E7:E" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 6), .Cells(1 + ultFila, 6)).Formula = "=SUMA(F7:F" & ultFila & ")"

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarPromedioResumen(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                '.Range("A3").Value = "RESUMEN VIATICOS - " & mesNumero(cmbMes.Value) & " " & txtAño.Value
                .Range("A5").Value = mesNumero(cmbMes.Value) & " " & txtAño.Value
                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 1)).Value = i + 1
                    .Range(.Cells(9 + i, 2), .Cells(9 + i, 2)).Value = Grid1.Rows(i).Cells("CODTRABAJADOR").Value
                    .Range(.Cells(9 + i, 3), .Cells(9 + i, 3)).Value = Grid1.Rows(i).Cells("TRABAJADOR").Value
                    .Range(.Cells(9 + i, 4), .Cells(9 + i, 4)).Value = Grid1.Rows(i).Cells("AREA").Value

                    .Range(.Cells(9 + i, 5), .Cells(9 + i, 5)).Value = Grid1.Rows(i).Cells("TOTALALIMENTACION").Value
                    If Grid1.Rows(i).Cells("TOTALALIMENTACION").Value > 0 Then
                        .Range(.Cells(9 + i, 6), .Cells(9 + i, 6)).Value = Grid1.Rows(i).Cells("DIASALIMENTACION").Value
                    Else
                        .Range(.Cells(9 + i, 6), .Cells(9 + i, 6)).Value = 0
                    End If
                    '.Range(.Cells(7 + i, 6), .Cells(7 + i, 6)).Value = Grid1.Rows(i).Cells("DIASALIMENTACION").Value
                    .Range(.Cells(9 + i, 7), .Cells(9 + i, 7)).Value = Grid1.Rows(i).Cells("ALIMENTACION").Value

                    .Range(.Cells(9 + i, 9), .Cells(9 + i, 9)).Value = Grid1.Rows(i).Cells("TOTALHOSPEDAJE").Value
                    If Grid1.Rows(i).Cells("TOTALHOSPEDAJE").Value > 0 Then
                        .Range(.Cells(9 + i, 10), .Cells(9 + i, 10)).Value = Grid1.Rows(i).Cells("DIASHOSPEDAJE").Value
                    Else
                        .Range(.Cells(9 + i, 10), .Cells(9 + i, 10)).Value = 0
                    End If
                    '.Range(.Cells(7 + i, 10), .Cells(7 + i, 10)).Value = Grid1.Rows(i).Cells("DIASHOSPEDAJE").Value
                    .Range(.Cells(9 + i, 11), .Cells(9 + i, 11)).Value = Grid1.Rows(i).Cells("HOSPEDAJE").Value

                    .Range(.Cells(9 + i, 13), .Cells(9 + i, 13)).Formula = "=G" & 9 + i & "+K" & 9 + i & ""

                    .Range(.Cells(9 + i, 15), .Cells(9 + i, 15)).Value = Grid1.Rows(i).Cells("TOTALMOVILIDAD").Value
                    If Grid1.Rows(i).Cells("TOTALMOVILIDAD").Value > 0 Then
                        .Range(.Cells(9 + i, 16), .Cells(9 + i, 16)).Value = Grid1.Rows(i).Cells("DIASMOVILIDAD").Value
                    Else
                        .Range(.Cells(9 + i, 16), .Cells(9 + i, 16)).Value = 0
                    End If
                    '.Range(.Cells(7 + i, 16), .Cells(7 + i, 16)).Value = Grid1.Rows(i).Cells("DIASMOVILIDAD").Value
                    .Range(.Cells(9 + i, 17), .Cells(9 + i, 17)).Value = Grid1.Rows(i).Cells("MOVILIDAD").Value

                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 6)).WrapText = False
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 13)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(9 + i, 15), .Cells(9 + i, 18)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    ultFila = i + 9
                Next

                ultFila = ultFila + 1
                '.Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 13)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                '.Range(.Cells(1 + ultFila, 15), .Cells(1 + ultFila, 18)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 13)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 13)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                .Range(.Cells(1 + ultFila, 15), .Cells(1 + ultFila, 18)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range(.Cells(1 + ultFila, 15), .Cells(1 + ultFila, 18)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 18)).Font.Bold = True
                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 3)).Value = "TOTALES"
                .Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 3)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 5)).Formula = "=SUMA(E7:E" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 6), .Cells(1 + ultFila, 6)).Formula = "=SUMA(F7:F" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 7), .Cells(1 + ultFila, 7)).Formula = "=E" & 1 + ultFila & "/F" & 1 + ultFila & "" '"=SUMA(G7:G" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 9), .Cells(1 + ultFila, 9)).Formula = "=SUMA(I7:I" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 10), .Cells(1 + ultFila, 10)).Formula = "=SUMA(J7:J" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 11), .Cells(1 + ultFila, 11)).Formula = "=I" & 1 + ultFila & "/J" & 1 + ultFila & "" '"=SUMA(K7:K" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 13), .Cells(1 + ultFila, 13)).Formula = "=G" & 1 + ultFila & "+K" & 1 + ultFila & "" '"=SUMA(M7:M" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 15), .Cells(1 + ultFila, 15)).Formula = "=SUMA(O7:O" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 16), .Cells(1 + ultFila, 16)).Formula = "=SUMA(P7:P" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 17), .Cells(1 + ultFila, 17)).Formula = "=O" & 1 + ultFila & "/P" & 1 + ultFila & "" '"=SUMA(Q7:Q" & ultFila & ")"
                '.Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                '.Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 6)).Font.Bold = True
                '.Range(.Cells(1 + ultFila, 3), .Cells(1 + ultFila, 3)).Value = "TOTALES"
                '.Range(.Cells(1 + ultFila, 4), .Cells(1 + ultFila, 4)).Formula = "=SUMA(D7:D" & ultFila & ")"
                '.Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 5)).Formula = "=SUMA(E7:E" & ultFila & ")"
                '.Range(.Cells(1 + ultFila, 6), .Cells(1 + ultFila, 6)).Formula = "=SUMA(F7:F" & ultFila & ")"

                '.Range(.Cells(5 + ultFila, 1), .Cells(5 + ultFila, 5)).Merge()
                '.Range(.Cells(5 + ultFila, 1), .Cells(5 + ultFila, 1)).Value = "RESUMEN"
                '.Range(.Cells(6 + ultFila, 1), .Cells(6 + ultFila, 5)).Merge()
                '.Range(.Cells(6 + ultFila, 1), .Cells(6 + ultFila, 1)).Value = "HOSPEDAJES  MAS CONCURRIDOS EN EL MES DE " & mesNumero(cmbMes.Value)
                '.Range(.Cells(5 + ultFila, 1), .Cells(6 + ultFila, 5)).Font.Bold = True

                '.Range(.Cells(8 + ultFila, 1), .Cells(8 + ultFila, 1)).Value = "ITEM"
                '.Range(.Cells(8 + ultFila, 2), .Cells(8 + ultFila, 2)).Value = "RUC"
                '.Range(.Cells(8 + ultFila, 3), .Cells(8 + ultFila, 3)).Value = "RAZON SOCIAL"
                '.Range(.Cells(8 + ultFila, 4), .Cells(8 + ultFila, 4)).Value = "IMPORTE TOTAL"
                '.Range(.Cells(8 + ultFila, 4), .Cells(8 + ultFila, 4)).WrapText = True
                '.Range(.Cells(8 + ultFila, 5), .Cells(8 + ultFila, 5)).Value = "DPTO."
                '.Range(.Cells(8 + ultFila, 1), .Cells(8 + ultFila, 5)).Font.Bold = True

                'If DtRHospedaje.Rows.Count > 0 Then
                '    For a As Int32 = 0 To DtRHospedaje.Rows.Count - 1
                '        .Range(.Cells(9 + ultFila + a, 1), .Cells(9 + ultFila + a, 1)).Value = a + 1
                '        .Range(.Cells(9 + ultFila + a, 2), .Cells(9 + ultFila + a, 2)).Value = DtRHospedaje.Rows(a)("NRORUC")
                '        .Range(.Cells(9 + ultFila + a, 3), .Cells(9 + ultFila + a, 3)).Value = DtRHospedaje.Rows(a)("RAZON")
                '        .Range(.Cells(9 + ultFila + a, 4), .Cells(9 + ultFila + a, 4)).Value = DtRHospedaje.Rows(a)("TOTAL")
                '        .Range(.Cells(9 + ultFila + a, 5), .Cells(9 + ultFila + a, 5)).Value = DtRHospedaje.Rows(a)("DPTO")
                '        .Range(.Cells(8 + ultFila + a, 1), .Cells(9 + ultFila + a, 5)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                '    Next
                'End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarDetalle(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A2").Value = "DETALLE GASTOS DE VIATICOS AL MES DE " & mesNumero(cmbMes.Value) & " - " & txtAño.Value
                .Range("B4").Value = lbltrabajador.Text
                Dim nfila As Integer = 7
                Dim nfilaini As Integer = 7
                Dim nfilault As Integer = 7

                Dim nfilainidias As Integer = 7
                Dim nfilaultdias As Integer = 7

                Dim saltolinea As Int32 = 0

                For i = 0 To Grid2.Rows.Count - 1

                    If i > 0 Then
                        If Grid2.Rows(i).Cells("CONCEPTO").Value = "ALIMENTACION" Then
                            If Grid2.Rows(i).Cells("FECHA").Value = Grid2.Rows(i - 1).Cells("FECHA").Value Then 'And Grid2.Rows(i).Cells("DIAS").Value = Grid2.Rows(i - 1).Cells("DIAS").Value Then
                                nfilaultdias = nfila
                            Else
                                .Range(.Cells(nfilainidias, 9), .Cells(nfilaultdias, 9)).Merge()
                                nfilainidias = nfilaultdias + saltolinea + 1
                                nfilaultdias = nfila
                            End If

                        End If

                        If Grid2.Rows(i).Cells("CONCEPTO").Value = Grid2.Rows(i - 1).Cells("CONCEPTO").Value Then
                            nfilault = nfila
                        Else
                            .Range(.Cells(7 + saltolinea + i, 7), .Cells(7 + saltolinea + i, 7)).Value = "TOTAL"
                            .Range(.Cells(7 + saltolinea + i, 8), .Cells(7 + saltolinea + i, 8)).Formula = "=SUMA(H" & nfilaini & ":H" & nfilault + saltolinea & ")"
                            .Range(.Cells(7 + saltolinea + i, 9), .Cells(7 + saltolinea + i, 9)).Formula = "=SUMA(I" & nfilaini & ":I" & nfilault + saltolinea & ")"
                            .Range(.Cells(7 + saltolinea + i, 7), .Cells(7 + saltolinea + i, 9)).Font.Bold = True
                            .Range(.Cells(7 + saltolinea + i, 7), .Cells(7 + saltolinea + i, 9)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            saltolinea = saltolinea + 2
                            nfilaini = nfilault + saltolinea + 1
                            'nfila = nfila + 1
                        End If
                    End If

                    .Range(.Cells(7 + saltolinea + i, 1), .Cells(7 + saltolinea + i, 1)).Value = Grid2.Rows(i).Cells("NUMSOLICITUD").Value
                    .Range(.Cells(7 + saltolinea + i, 2), .Cells(7 + saltolinea + i, 2)).Value = Grid2.Rows(i).Cells("FECHA").Value
                    .Range(.Cells(7 + saltolinea + i, 3), .Cells(7 + saltolinea + i, 3)).Value = Grid2.Rows(i).Cells("TIPDOC").Value
                    .Range(.Cells(7 + saltolinea + i, 4), .Cells(7 + saltolinea + i, 4)).Value = Grid2.Rows(i).Cells("NUMDOC").Value
                    .Range(.Cells(7 + saltolinea + i, 5), .Cells(7 + saltolinea + i, 5)).Value = Grid2.Rows(i).Cells("FECHADOC").Value
                    .Range(.Cells(7 + saltolinea + i, 6), .Cells(7 + saltolinea + i, 6)).Value = Grid2.Rows(i).Cells("RAZON").Value
                    .Range(.Cells(7 + saltolinea + i, 7), .Cells(7 + saltolinea + i, 7)).Value = Grid2.Rows(i).Cells("CONCEPTO").Value
                    .Range(.Cells(7 + saltolinea + i, 12), .Cells(7 + saltolinea + i, 12)).Value = Grid2.Rows(i).Cells("COMENTARIO").Value
                    If Grid2.Rows(i).Cells("FLGTERCERO").Value = 1 Then
                        .Range(.Cells(7 + saltolinea + i, 8), .Cells(7 + saltolinea + i, 8)).Value = 0
                        .Range(.Cells(7 + saltolinea + i, 9), .Cells(7 + saltolinea + i, 9)).Value = 0
                        .Range(.Cells(7 + saltolinea + i, 10), .Cells(7 + saltolinea + i, 10)).Value = 0
                        .Range(.Cells(7 + saltolinea + i, 11), .Cells(7 + saltolinea + i, 11)).Value = Grid2.Rows(i).Cells("IMPORTE").Value
                    Else
                        .Range(.Cells(7 + saltolinea + i, 8), .Cells(7 + saltolinea + i, 8)).Value = Grid2.Rows(i).Cells("IMPORTE").Value
                        .Range(.Cells(7 + saltolinea + i, 9), .Cells(7 + saltolinea + i, 9)).Value = Grid2.Rows(i).Cells("DIAS").Value
                        .Range(.Cells(7 + saltolinea + i, 10), .Cells(7 + saltolinea + i, 10)).Value = Grid2.Rows(i).Cells("PERSONAS").Value
                    End If
                    .Range(.Cells(7 + saltolinea + i, 1), .Cells(7 + saltolinea + i, 12)).WrapText = False
                    .Range(.Cells(7 + saltolinea + i, 1), .Cells(7 + saltolinea + i, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    nfila = nfila + 1
                    ultFila = i + 7
                Next
                .Range(.Cells(nfilainidias, 9), .Cells(nfilaultdias, 9)).Merge()
                .Range(.Cells(saltolinea + ultFila + 1, 7), .Cells(saltolinea + ultFila + 1, 7)).Value = "TOTAL"
                .Range(.Cells(saltolinea + ultFila + 1, 8), .Cells(saltolinea + ultFila + 1, 8)).Formula = "=SUMA(H" & nfilaini & ":H" & saltolinea + ultFila & ")"
                .Range(.Cells(saltolinea + ultFila + 1, 9), .Cells(saltolinea + ultFila + 1, 9)).Formula = "=SUMA(I" & nfilaini & ":I" & saltolinea + ultFila & ")"
                .Range(.Cells(saltolinea + ultFila + 1, 7), .Cells(saltolinea + ultFila + 1, 9)).Font.Bold = True
                .Range(.Cells(saltolinea + ultFila + 1, 7), .Cells(saltolinea + ultFila + 1, 9)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                '.Range(.Cells(saltolinea + 1 + ultFila, 6), .Cells(saltolinea + 1 + ultFila, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                '.Range(.Cells(saltolinea + 1 + ultFila, 6), .Cells(saltolinea + 1 + ultFila, 8)).Font.Bold = True
                '.Range(.Cells(saltolinea + 1 + ultFila, 6), .Cells(saltolinea + 1 + ultFila, 6)).Value = "TOTALES"
                '.Range(.Cells(saltolinea + 1 + ultFila, 7), .Cells(saltolinea + 1 + ultFila, 7)).Formula = "=SUMA(G7:G" & ultFila & ")"
                '.Range(.Cells(saltolinea + 1 + ultFila, 8), .Cells(saltolinea + 1 + ultFila, 8)).Formula = "=SUMA(H7:H" & ultFila & ")"
                '.Range(.Cells(saltolinea + 1 + ultFila, 9), .Cells(saltolinea + 1 + ultFila, 9)).Formula = "=SUMA(I7:I" & ultFila & ")"

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

    Private Sub txtAño_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAño.ValueChanged
        Try
            'Procesar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Grid2_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid2.DoubleClickRow
        Try
            Dim frm As New frmFechaGasto
            frm.dtFecha.Value = Grid2.ActiveRow.Cells("FECHA").Value
            frm.txtdias.Value = Grid2.ActiveRow.Cells("DIAS").Value
            frm.txtcomentario.Value = Grid2.ActiveRow.Cells("COMENTARIO").Value
            If Grid2.ActiveRow.Cells("FLGTERCERO").Value Then
                frm.chktercero.Checked = True
            Else
                frm.chktercero.Checked = False
            End If
            frm.ShowDialog()
            If frm.grabado = 1 Then
                Grid2.ActiveRow.Cells("FECHA").Value = frm.dtFecha.Value
                Grid2.ActiveRow.Cells("DIAS").Value = frm.txtdias.Value
                Grid2.ActiveRow.Cells("COMENTARIO").Value = frm.txtcomentario.Value
                Grid2.ActiveRow.Cells("GRABADO").Value = 1
                If frm.chktercero.Checked = True Then
                    Grid2.ActiveRow.Cells("FLGTERCERO").Value = 1
                Else
                    Grid2.ActiveRow.Cells("FLGTERCERO").Value = 0
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Sub Grabar()
        Try
            Dim cont As Int32 = 0
            For i As Int32 = 0 To Grid2.Rows.Count - 1
                objNegocio = New NGContratista
                objEntidad = New ETContratista
                If Grid2.Rows(i).Cells("GRABADO").Value = 1 Then
                    objEntidad._id = Grid2.Rows(i).Cells("IDLIQUIDACION").Value
                    objEntidad._fecha1 = Grid2.Rows(i).Cells("FECHA").Value
                    objEntidad._flgtercero = Grid2.Rows(i).Cells("FLGTERCERO").Value
                    objEntidad._flgtercero = Grid2.Rows(i).Cells("FLGTERCERO").Value
                    objEntidad._ndias = Grid2.Rows(i).Cells("DIAS").Value
                    objEntidad._comentario = Grid2.Rows(i).Cells("COMENTARIO").Value
                    objEntidad._usuario = User_Sistema
                    Dim result As New Int32
                    result = objNegocio.MantFechaViatico(objEntidad)
                    'If result > 0 Then
                    '    cont += 1
                    'End If
                End If
            Next
            MsgBox("Guardado correctamente", MsgBoxStyle.Information, msgComacsa)
            Viatico_Detalle()
            'If cont > 0 Then

            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged

    End Sub


End Class