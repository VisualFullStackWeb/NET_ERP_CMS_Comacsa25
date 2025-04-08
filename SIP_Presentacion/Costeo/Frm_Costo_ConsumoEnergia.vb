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
Imports System.Data
Imports System.Data.OleDb
Public Class Frm_Costo_ConsumoEnergia
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

    Private Sub Frm_Costo_ConsumoEnergia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
        cmbMes.Value = Now.Date.Month
    End Sub
    Sub Procesar()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtDatos As New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dsDatos As New DataSet
            dsDatos = _objNegocio.Costo_CONSUMO_ENERGIA(_objEntidad)
            gridCostos.DataSource = dsDatos.Tables(0)
            gridCostos.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            Procesar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        Reporte()
    End Sub

    Sub Reporte()
        Dim rpta As Long
        Dim ruta As String = ""

      
        ruta = Application.StartupPath & "\CONSUMOENERGIA " & ".xls"

        Dim archivoexcel As String = Trim(ruta)

        Try
            If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If
            Me.UltraGridExcelExporter1.Export(gridCostos, ruta)

            ''poner cabecera
            Dim titulo As String
            titulo = "CONSUMO DE ENERGIA DEL MES DE " & cmbMes.Text.ToString.ToUpper & " - " & txtayo.Value.ToString
         
            Call poner_cabecera_archivo_excel(archivoexcel, titulo)

            MessageBox.Show("Exportado: " & Chr(13) & ruta, "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Abrir_Archivo(ruta)
            'Me.Close()

        Catch ex As Exception
            'MessageBox.Show("Ruta Especificada No Existe", "Invalid File Name")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub poner_cabecera_archivo_excel(ByVal p_archivo As String, ByVal titulo As String)

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
            h_hoja.Range("1:1").Insert()
            h_hoja.Range("2:2").Insert()
            h_hoja.Range("A2:E2").Merge()
            h_hoja.Range("A2:E2").Font.Bold = True
            h_hoja.Range("A2:DG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            'h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = titulo
            h_hoja.Range("3:3").Insert()
            h_hoja.Range("A:A").ColumnWidth = 13
            h_hoja.Range("B:B").ColumnWidth = 30
            h_hoja.Range("C:E").NumberFormat = "#,##0.000"
            h_hoja.Range("C:E").ColumnWidth = 13
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

End Class