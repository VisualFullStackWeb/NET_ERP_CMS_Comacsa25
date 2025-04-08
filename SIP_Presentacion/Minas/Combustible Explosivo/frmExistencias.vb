Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class frmExistencias
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista
    Public UltGrd As Infragistics.Win.UltraWinGrid.UltraGrid
#Region "Variables"
    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private ListModulos As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim Ope = 1
#End Region

    Private Sub frmExistencias_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmExistencias_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Year(Now.Date)
        cmbMes.Value = Month(Now.Date)
        gridExistencia.DisplayLayout.Override.MinRowHeight = 18
        cmbtipo.Value = "T"
    End Sub

    Sub Procesar()
        CargarDatos()
    End Sub
    Public Sub CargarDatos()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._ayo = txtAño.Value
            objEntidad._mes = cmbMes.Value
            objEntidad._tipomaterial = cmbtipo.Value
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.Existencias(objEntidad)
            Call CargarUltraGridxBinding(gridExistencia, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub gridExistencia_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridExistencia.InitializeLayout
        With gridExistencia.DisplayLayout
            .Bands(0).Columns("COD_PROD").CellAppearance.ForeColor = Color.DarkBlue
            .Bands(0).Columns("PRODUCTO").CellAppearance.ForeColor = Color.DarkBlue
        End With
    End Sub
    Sub Reporte()
        If gridExistencia.Rows.Count <= 0 Then
            MsgBox("No existen datos a exportar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Dim rpta As Long
        Dim ruta As String = Application.StartupPath & "\EXISTENCIA " & cmbMes.Text & " " & txtAño.Value & ".xls"
        Dim archivoexcel As String = Trim(ruta)

        Try
            If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If
            Me.UltraGridExcelExporter1.Export(gridExistencia, ruta)

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
            'h_hoja.Range("A3:D3").Merge()
            'h_hoja.Range("A3:G3").Font.Bold = True
            'h_hoja.Range("A3:AG3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A2:D2").Merge()
            h_hoja.Range("A2:D2").Font.Bold = True
            h_hoja.Range("A2:DG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            'h_hoja.Cells(2, 1).value = "EXISTENCIAS"
            h_hoja.Cells(2, 1).value = "EXISTENCIAS " & cmbMes.Text & " - " & txtAño.Value
            h_hoja.Range("B1").ColumnWidth = 36
            h_hoja.Range("C1").ColumnWidth = 11
            h_hoja.Range("D1").ColumnWidth = 13
            h_hoja.Range("D1:D10000").NumberFormat = "#,##0.0000"
            'h_hoja.Cells(4, 1).value = ""
            'h_hoja.Cells(5, 1).value = ""
            'h_hoja.Cells(6, 1).value = ""
            'h_hoja.Cells(7, 1).value = ""

        Catch ex As Exception
            MsgBox("Error al Insertar Cabecera del Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        libro_excel.Save()
        libro_excel.Close()
        libro_excel = Nothing

        archivo_excel.Quit()
        archivo_excel = Nothing

    End Sub

    Private Sub cmbtipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipo.ValueChanged
        Try
            Procesar()
        Catch ex As Exception

        End Try
    End Sub
End Class