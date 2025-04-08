Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class FrmReporteParada
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Public ConceptoSeleccionado As String
    Public filtroDescripcion As String = String.Empty
#End Region
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto

    Private Sub FrmReporteParada_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtdesde.Value = Now.Date
        dthasta.Value = Now.Date
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        RrporteParada()
    End Sub
    Sub RrporteParada()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtDatos As New DataTable
            Dim dtDatosResumen As New DataTable

            Dim dtParadaCab As New DataTable
            Dim dtParadaDet As New DataTable

            Dim fecha_desde As Date = dtdesde.Value
            Dim fecha_hasta As Date = dthasta.Value

            Dim dsDatos As New DataSet
            dtDatos = New DataTable
            dtParadaCab = New DataTable
            dtParadaDet = New DataTable

            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.FechaInicio = fecha_desde
            _objEntidad.FechaTerminacion = fecha_hasta
            _objEntidad.Usuario = userLogin
            dsDatos = _objNegocio.REPORTE_PARADA(_objEntidad)
            dtParadaCab = dsDatos.Tables(0)
            dtParadaDet = dsDatos.Tables(1)

            If dtParadaCab.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTE_PARADA.xls")
                File.Copy(RutaReporteERP & "PLANTILLA_REPORTE_PARADA.xls", path & "\REPORTE_PARADA.xls")
                m_Excel.Workbooks.Open(path & "\REPORTE_PARADA.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)

                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                Dim filaultima As Int32 = 0
                nfila = 10
                nfilaini = 10
                Dim restar As Int32 = 0
                'm_Excel.Visible = True
                With objHojaExcel
                    .Range("B" & 9).Value = "MODELO" 'dtParadaDet.Rows(i)("MODELO")
                    .Range("C" & 9).Value = "HORASPARA" 'dtParadaDet.Rows(i)("HORASPARA")
                    .Range("D" & 9).Value = "FEC_EMISION" 'dtParadaDet.Rows(i)("FEC_EMISION")
                    .Range("E" & 9).Value = "COD_MOT" 'dtParadaDet.Rows(i)("COD_MOT")
                    .Range("F" & 9).Value = "DESCRIP" 'dtParadaDet.Rows(i)("DESCRIP")
                    For i As Int16 = 0 To dtParadaDet.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtParadaDet.Rows(i)("COD_EQUIPO")
                        .Range("B" & nfila + i).Value = dtParadaDet.Rows(i)("MODELO")
                        .Range("C" & nfila + i).Value = dtParadaDet.Rows(i)("HORASPARA")
                        .Range("D" & nfila + i).Value = dtParadaDet.Rows(i)("FEC_EMISION")
                        .Range("E" & nfila + i).Value = dtParadaDet.Rows(i)("COD_MOT")
                        .Range("F" & nfila + i).Value = dtParadaDet.Rows(i)("DESCRIP")
                        '.Range("G" & nfila + i).Value = "=1-F" & nfila + i & ""
                        '.Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                    .Activate()

                    Dim fila As Int32 = dtParadaDet.Rows.Count + 9
                    .Range("A9:F" & fila & "").Select()
                    m_Excel.Sheets.Add()
                    m_Excel.ActiveWorkbook.PivotCaches.Create(SourceType:=Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlDatabase, SourceData:= _
                        "Paradas!R9C2:R" & fila & "C6").CreatePivotTable( _
                        TableDestination:="Hoja1!R4C1", TableName:="Tabla dinámica1")
                    m_Excel.Sheets("Hoja1").Select()
                    m_Excel.Cells(4, 1).Select()
                    'm_Excel.ActiveWindow.SmallScroll(Down:=-3)
                    m_Excel.ActiveSheet.PivotTables("Tabla dinámica1").AddDataField(m_Excel.ActiveSheet.PivotTables _
                        ("Tabla dinámica1").PivotFields("HORASPARA"), "Suma de HORASPARA", Excel.XlConsolidationFunction.xlSum)
                    With m_Excel.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("MODELO")
                        .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 1
                    End With
                    With m_Excel.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("FEC_EMISION")
                        .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 2
                    End With
                    With m_Excel.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("DESCRIP")
                        .Orientation = Excel.XlPivotFieldOrientation.xlColumnField
                        .Position = 1
                    End With
                    m_Excel.Range("A2").Value = "DETALLE DE PARADAS"
                    m_Excel.Range("A2").Font.Bold = True
                    m_Excel.Range("A2:E2").Merge()
                End With
                Dim objHojaExcelParadaDet As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(5)
                objHojaExcelParadaDet.Visible = Excel.XlSheetVisibility.xlSheetHidden
                objHojaExcelParadaDet = m_Excel.Worksheets(1)
                objHojaExcelParadaDet.Name = "Detalle Paradas"
                objHojaExcelParadaDet.Activate()
                objHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetHidden
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            'm_Excel.Quit()
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
End Class