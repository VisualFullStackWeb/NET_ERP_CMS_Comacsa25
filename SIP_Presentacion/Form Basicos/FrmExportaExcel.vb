
Public Class FrmExportaExcel

    Public UltGrd As Infragistics.Win.UltraWinGrid.UltraGrid
    Private b_imprimir_cabecera As Boolean = False
    Private s_titulo_reporte As String = ""
    Private s_subtitulo_reporte_1 As String = ""
    Private s_subtitulo_reporte_2 As String = ""
    Private s_subtitulo_reporte_3 As String = ""
    Private b_no_abrir_archivo As Boolean = False
    Public anual As Int32 = 0
    Public dtReporte As New DataTable
    Public dtInventario As New DataTable
    Public dtCierre1 As New DataTable
    Public dtCierre2 As New DataTable
    Public dtCierre3 As New DataTable
    Public dtCierre4 As New DataTable
    Public dtRecir1 As New DataTable
    Public dtRecir2 As New DataTable
    Public CONSUMO As String = ""
#Region "Propiedades"
    Public WriteOnly Property Insertar_Cabecera() As Boolean
        Set(ByVal value As Boolean)
            b_imprimir_cabecera = value
        End Set
    End Property

    Public WriteOnly Property Titulo_Reporte() As String
        Set(ByVal value As String)
            s_titulo_reporte = value
        End Set
    End Property

    Public WriteOnly Property Subtitulo_Reporte_1() As String
        Set(ByVal value As String)
            s_subtitulo_reporte_1 = value
        End Set
    End Property

    Public WriteOnly Property Subtitulo_Reporte_2() As String
        Set(ByVal value As String)
            s_subtitulo_reporte_2 = value
        End Set
    End Property

    Public WriteOnly Property Subtitulo_Reporte_3() As String
        Set(ByVal value As String)
            s_subtitulo_reporte_3 = value
        End Set
    End Property

    Public Property No_Abrir_Archivo() As Boolean
        Get
            Return b_no_abrir_archivo
        End Get
        Set(ByVal value As Boolean)
            b_no_abrir_archivo = value
        End Set
    End Property

#End Region

    Private Sub FrmExportaExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If b_no_abrir_archivo = True Then
            ChkAbrir.Checked = False
            ChkAbrir.Visible = False
        End If
        
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click

        Dim rpta As Long
        Dim archivoexcel As String = Trim(Me.exportFileName.Text)

        Try
            If Trim(Dir(Trim(Me.exportFileName.Text), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If

            Me.UltraGridExcelExporter1.Export(UltGrd, Me.exportFileName.Text)

            ''poner cabecera
            If b_imprimir_cabecera = True Then Call poner_cabecera_archivo_excel(archivoexcel)

            MessageBox.Show("Exportado " & Chr(13) & Me.exportFileName.Text, "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If ChkAbrir.Checked Then Abrir_Archivo()
            Me.Close()

        Catch ex As Exception
            'MessageBox.Show("Ruta Especificada No Existe", "Invalid File Name")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Abrir_Archivo()

        Dim xApp As Object
        Dim xLibros As Object
        Dim xLibro As Object
        Dim archivoexcel As String = Trim(Me.exportFileName.Text)

        xApp = CreateObject("excel.application")
        xLibros = xApp.Workbooks

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
            MessageBox.Show("Ocurrió un problema al subir el archivo", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        Try
            h_hoja = libro_excel.Sheets(1)
            h_hoja.Range("A1:AZ4").Insert()

            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = "RUC: 20100037689"
            h_hoja.Cells(3, 1).value = s_titulo_reporte

        Catch ex As Exception
            MessageBox.Show("Ocurrió un problema al colocar la cabecera", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        End Try

        libro_excel.Save()
        libro_excel.Close()
        libro_excel = Nothing

        archivo_excel.Quit()
        archivo_excel = Nothing

    End Sub



End Class