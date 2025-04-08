Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmResumenER
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
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
    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Try
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.RPT_RESUMEN_ENTREGAS(_objEntidad)
            Grid1.DataSource = dtDatos
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Visible = True
            Imprimir()
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        Catch ex As Exception

        End Try
    End Sub
    Sub Imprimir()
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No existen datos a exportar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        'Dim rpta As Long
        Dim ruta As String = Application.StartupPath & "\RESUMENENTREGAS_ " & cmbMes.Text & ".xls"
        Dim archivoexcel As String = Trim(ruta)

        Try
            'If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
            '    rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            '    If rpta = vbNo Then Exit Sub
            'End If
            Me.UltraGridExcelExporter1.Export(Grid1, ruta)
            ''poner cabecera
            Call poner_cabecera_archivo_excel(archivoexcel)

            MessageBox.Show("Exportado: " & Chr(13) & ruta, "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Abrir_Archivo(ruta)
            'Me.Close()

        Catch ex As Exception
            'MessageBox.Show("Ruta Especificada No Existe", "Invalid File Name")
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub poner_cabecera_archivo_excel(ByVal p_archivo As String)

        Dim archivo_excel As New Microsoft.Office.Interop.Excel.Application
        Dim libro_excel As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim h_hoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing

        ''abrir el archivo excel
        Try
            libro_excel = archivo_excel.Workbooks.Open(p_archivo, , False, , , , True, , , True)
        Catch ex As Exception
            MsgBox("Error al intentar abrir el Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        Try
            h_hoja = libro_excel.Sheets(1)
            h_hoja.Range("A1:AZ3").Insert()
            h_hoja.Range("A2:M2").Merge()
            h_hoja.Range("A2:X2").Font.Bold = True
            h_hoja.Range("A2:DG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Range("A1").ColumnWidth = 10
            h_hoja.Range("B1").ColumnWidth = 45
            h_hoja.Range("C1").ColumnWidth = 30
            h_hoja.Range("D1").ColumnWidth = 12
            h_hoja.Range("E1").ColumnWidth = 12
            h_hoja.Range("F1").ColumnWidth = 12
            h_hoja.Range("G1").ColumnWidth = 10
            h_hoja.Range("H1").ColumnWidth = 12
            h_hoja.Range("I1").ColumnWidth = 12
            h_hoja.Range("J1").ColumnWidth = 12
            h_hoja.Range("K1").ColumnWidth = 12
            h_hoja.Range("L1").ColumnWidth = 62
            h_hoja.Range("U1").ColumnWidth = 32
            h_hoja.Range("G:J").NumberFormat = "#,##0.00"
            h_hoja.Range("F:G").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = "RESUMEN DE ENTREGAS " & txtayo.Value & " ENERO - " & cmbMes.Text.ToString.Trim.ToUpper
        Catch ex As Exception
            MsgBox("Error al Insertar Cabecera del Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        libro_excel.Save()
        libro_excel.Close()
        libro_excel = Nothing

        archivo_excel.Quit()
        archivo_excel = Nothing

    End Sub

    Private Sub Abrir_Archivo(ByVal ruta As String)

        Dim xApp As Object
        Dim xLibros As Object
        Dim xLibro As Object
        Dim archivoexcel As String = Trim(ruta)

        'Abrimos el archivo
        xApp = CreateObject("excel.application")
        xLibros = xApp.Workbooks

        '' ''poner cabecera antes de abrir
        ''If b_imprimir_cabecera = True Then Call poner_cabecera_archivo_excel(archivoexcel)

        xLibros.Open(archivoexcel, 3)
        xLibro = xApp.ActiveWorkBook
        xApp.Visible = True

    End Sub

    Private Sub FrmResumenER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Year
        cmbMes.Value = Now.Month
    End Sub
End Class