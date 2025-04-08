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
Public Class FrmTonIngresadas
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

    Private Sub FrmTonIngresadas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
        cmbMes.Value = Now.Date.Month
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Procesar()
    End Sub
    Sub Procesar()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 1
            Dim dtDatos As New DataTable
            If chkAnual.Checked = True Then
                dtDatos = _objNegocio.Costo_TonIngresada_Anual(_objEntidad)
            Else
                dtDatos = _objNegocio.Costo_TonIngresada(_objEntidad)
            End If
            Call CargarUltraGridxBinding(Me.gridingreso, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Sub Reporte()
        If gridingreso.Rows.Count <= 0 Then
            MsgBox("No existen datos a exportar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Dim rpta As Long
        Dim ruta As String = Application.StartupPath & "\TONINGRESADO " & cmbMes.Text & " " & txtayo.Value & ".xls"
        Dim archivoexcel As String = Trim(ruta)
        Try
            If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If
            Me.UltraGridExcelExporter1.Export(gridingreso, ruta)
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
            h_hoja.Range("A3:H3").Merge()
            h_hoja.Range("A3:H3").Font.Bold = True
            h_hoja.Range("A3:AH3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A2:H2").Merge()
            h_hoja.Range("A2:H2").Font.Bold = True
            h_hoja.Range("A2:AH2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = "TONELADAS INGRESADAS: " & cmbMes.Text & " - " & txtayo.Value
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
        xApp = CreateObject("excel.application")
        xLibros = xApp.Workbooks
        xLibros.Open(archivoexcel, 3)
        xLibro = xApp.ActiveWorkBook
        xApp.Visible = True
    End Sub

    Private Sub chkAnual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAnual.CheckedChanged
        Try
            If chkAnual.Checked = True Then
                cmbMes.Enabled = False
            Else
                cmbMes.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class