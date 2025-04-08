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
Public Class frmHtnrxPresentacion
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
    Private Ls_EntregaEliminado As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private columna As String
    Private filtroConcepto As String = String.Empty
    Dim esDevolucion As Int32 = 0
    Dim totalPend As Double = 0
    Dim numInterno As String = String.Empty
    Dim idEstado As Int32
    Dim moneda As String = String.Empty
    Dim estado As String = String.Empty
    Dim auxi As String = String.Empty
    Dim flgauxi As Int32 = 0
    Dim tipotabla As Int32 = 0
    Dim estadoContable As Int32 = 0
#End Region
    Private Sub frmHtnrxPresentacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\HTNRPRESENTACION.xls")
            File.Copy(RutaReporteERP & "PLANTILLA HTNRPRESENTACION.xls", path & "\HTNRPRESENTACION.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\HTNRPRESENTACION.xls")
            Dim objHojaMensual As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcelAnual As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)

            exportarMensual(objHojaMensual)

            'objHojaMensual.Range("A2:P2").Value = "(Saldos al " & dtpFecha.Value.ToString("dd/MM/yyyy") & ")"
            'objHojaExcelAnual.Range("B3:H3").Value = "(Saldos al " & dtpFecha.Value.ToString("dd/MM/yyyy") & ")"

            'objHojaMensual.Range("C4").Value = Now.ToString("dd/MM/yyyy hh:mm:ss")
            'objHojaExcelAnual.Range("C6").Value = Now.ToString("dd/MM/yyyy hh:mm:ss")
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
    Sub exportarMensual(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                Dim oPrvFisN As NGProveedorFiscalizado = Nothing
                Dim oPrvFisE As ETProveedorFiscalizado = Nothing
                Dim dtReporte As New DataTable
                Dim dtEquipos As New DataTable
                oPrvFisN = New NGProveedorFiscalizado
                oPrvFisE = New ETProveedorFiscalizado
                With oPrvFisE
                    '.Fecha = dtpFecha.Value
                End With

                Dim Producto As String = String.Empty
                Dim Presentacion As String = String.Empty

                Dim contProducto As Int32 = 0
                Dim contEquipos As Int32 = 0

                Dim filaini As Int32 = 5
                Dim columnini As Int32 = 2
                Dim segPResentacion As Int32 = 0

                dtReporte = oPrvFisN.HtnrxPResentacion(oPrvFisE)

                'dtEquipos = oPrvFisN.HtnrEquipos(oPrvFisE)

                Dim dvEquipos As New DataView(dtEquipos)
                Dim dtfiltro As New DataTable
                If dtReporte.Rows.Count > 0 Then
                    Producto = dtReporte.Rows(0)("Producto")
                    Presentacion = dtReporte.Rows(0)("Presentacion")
                    .Range("A1").Value = "Producto"
                    .Range("A1").Font.Bold = True
                    .Range("B1").Font.Bold = True
                    .Range("B1").Value = Producto
                    .Range("A3").Value = "Máx. de TnHr"
                    .Range("A4").Value = "Nombre de Equipo"
                    .Range("A4").Font.Bold = True
                    .Range("A3").Font.Bold = True
                    .Range(.Cells(4, 1), .Cells(4, 2)).Interior.Color = 16772300
                    .Range(.Cells(4, 1), .Cells(4, 2)).RowHeight = 60
                    .Range(.Cells(4, 1), .Cells(4, 2)).WrapText = True
                    .Range(.Cells(4, 1), .Cells(4, 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(4, 1), .Cells(4, 2)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(4, 1), .Cells(4, 2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(4, 2), .Cells(4, 2)).Value = Presentacion
                    .Range(.Cells(4, 2), .Cells(4, 2)).Font.Bold = True
                    .Range(.Cells(4, 2), .Cells(4, 2)).ColumnWidth = 18 'Presentacion.Length

                    oPrvFisE.Produdcto = Producto
                    dtEquipos = oPrvFisN.HtnrEquipos(oPrvFisE)
                    For x As Int32 = 0 To dtEquipos.Rows.Count - 1
                        If dtEquipos.Rows(x)("Producto") = Producto Then
                            .Range(.Cells(filaini + x, 1), .Cells(filaini + x, 1)).Value = dtEquipos.Rows(x)("NombreEquipo")
                            contEquipos = contEquipos + 1
                        Else
                            Exit For
                        End If
                    Next

                    For i As Int16 = 0 To dtReporte.Rows.Count - 1

                        If dtReporte(i)("Producto") <> Producto Then
                            Producto = dtReporte(i)("Producto")
                            Presentacion = dtReporte(i)("Presentacion")
                            columnini = 2
                            filaini = filaini + contEquipos + 4
                            .Range(.Cells(filaini - 3, 1), .Cells(filaini - 3, 1)).Value = "Producto"
                            .Range(.Cells(filaini - 3, 1), .Cells(filaini - 3, 1)).Font.Bold = True
                            .Range(.Cells(filaini - 3, columnini), .Cells(filaini - 3, columnini)).Value = Producto
                            .Range(.Cells(filaini - 3, columnini), .Cells(filaini - 3, columnini)).Font.Bold = True
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, 1)).Value = "Nombre de Equipo"
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).Interior.Color = 16772300
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).RowHeight = 60
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).WrapText = True
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            .Range(.Cells(filaini - 1, columnini), .Cells(filaini - 1, columnini)).Value = Presentacion
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).Font.Bold = True
                            'If Presentacion.Length > .Range(.Cells(filaini - 1, columnini), .Cells(filaini - 1, columnini)).ColumnWidth Then
                            .Range(.Cells(filaini - 1, columnini), .Cells(filaini - 1, columnini)).ColumnWidth = 18 'Presentacion.Length
                            'End If
                            segPResentacion = 1
                            contEquipos = 0
                            oPrvFisE.Produdcto = Producto
                            dtEquipos = oPrvFisN.HtnrEquipos(oPrvFisE)
                            For x As Int32 = 0 To dtEquipos.Rows.Count - 1
                                If dtEquipos.Rows(x)("Producto") = Producto Then
                                    .Range(.Cells(filaini + x, 1), .Cells(filaini + x, 1)).Value = dtEquipos.Rows(x)("NombreEquipo")
                                    contEquipos = contEquipos + 1
                                    'Else
                                    '   Exit For
                                End If
                            Next

                        End If

                If dtReporte(i)("Presentacion") <> Presentacion Then
                    Presentacion = dtReporte(i)("Presentacion")
                    columnini = columnini + 1
                    .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, 1)).Value = "Nombre de Equipo"
                    .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).Interior.Color = 16772300
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).RowHeight = 60
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).WrapText = True
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            .Range(.Cells(filaini - 1, columnini), .Cells(filaini - 1, columnini)).Value = Presentacion
                    .Range(.Cells(filaini - 1, 1), .Cells(filaini - 1, columnini)).Font.Bold = True
                    'If Presentacion.Length > .Range(.Cells(filaini - 1, columnini), .Cells(filaini - 1, columnini)).ColumnWidth Then
                    .Range(.Cells(filaini - 1, columnini), .Cells(filaini - 1, columnini)).ColumnWidth = 18 'Presentacion.Length
                    'End If
                    segPResentacion = 1
                End If

                For j As Int32 = 0 To contEquipos
                    If .Range(.Cells(filaini + j, 1), .Cells(filaini + j, 1)).Value = dtReporte.Rows(i)("NombreEquipo") Then
                        '.Range(.Cells(filaini + j, 1), .Cells(filaini + j, 1)).Value = dtReporte.Rows(i)("NombreEquipo")
                        .Range(.Cells(filaini + j, columnini), .Cells(filaini + j, columnini)).Value = dtReporte.Rows(i)("TnHr")
                        .Range(.Cells(filaini + j, 1), .Cells(filaini + j, columnini)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        Exit For
                    End If
                    'contPresentacion = contPresentacion + 1
                Next
                'contPresentacion = contPresentacion - 1
                'End If


                'filaini = contEquipos + 1

                'If dtReporte(i)("Presentacion") <> Presentacion Then
                '    Presentacion = dtReporte(i)("Presentacion")
                '    columnini = columnini + 1
                '    .Range(.Cells(filaini - 1, columnini), .Cells(filaini - 1, columnini)).Value = Presentacion
                '    .Range(.Cells(filaini - 1, columnini), .Cells(filaini - 1, columnini)).ColumnWidth = Presentacion.Length
                '    segPResentacion = 1
                '    filaini = filaini - contPresentacion
                'End If
                'If segPResentacion = 0 Then
                '    .Range(.Cells(filaini + i, 1), .Cells(filaini + i, 1)).Value = dtReporte.Rows(i)("NombreEquipo")
                '    .Range(.Cells(filaini + i, 2), .Cells(filaini + i, 2)).Value = dtReporte.Rows(i)("TnHr")
                'Else

                '    For x As Int32 = 0 To contPresentacion
                '        If .Range(.Cells(filaini + i + x, 1), .Cells(filaini + i + x, 1)).Value = dtReporte.Rows(i)("NombreEquipo") Then
                '            .Range(.Cells(filaini + i + x, 1), .Cells(filaini + i + x, 1)).Value = dtReporte.Rows(i)("NombreEquipo")
                '            .Range(.Cells(filaini + i + x, columnini), .Cells(filaini + i + x, columnini)).Value = dtReporte.Rows(i)("TnHr")
                '            Exit For
                '        End If
                '        'contPresentacion = contPresentacion + 1
                '    Next
                '    contPresentacion = contPresentacion - 1
                'End If

                'contPresentacion = contPresentacion + 1
                    Next

                End If

            End With
        Catch ex As Exception

        End Try
    End Sub
End Class