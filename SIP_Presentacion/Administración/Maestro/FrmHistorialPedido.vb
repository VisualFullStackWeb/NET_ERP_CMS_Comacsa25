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
Public Class FrmHistorialPedido
    Public Ls_Permisos As New List(Of Integer)
    Dim procesado As Int32
    Dim _objNegocio As NGInsumosFiscalizados
    Dim _objEntidad As ETInsumosFiscalizados
    Dim cierre As Int32 = 0
    Private Ls_RumaSuministro As List(Of ETRuma) = Nothing
    Private CodRuma As String = String.Empty
    Dim _objNegocio_ As NGProducto
    Dim _objEntidad_ As ETProducto
    Public Lista As List(Of ETRuma) = Nothing

    Private Sub FrmHistorialPedido_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario
        dtpDesde.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
        dtpHasta.Value = Now.Date
        CargaDatos()
    End Sub

    Sub procesar()
        CargaDatos()
    End Sub

    Sub CargaDatos()
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        Dim dt As New DataTable
        dt = _objNegocio_.ListaPedidoAtendido_Hist(User_Sistema, dtpDesde.Value, dtpHasta.Value)
        Call CargarUltraGridxBinding(UltraGrid1, Source1, dt)
    End Sub

    Sub reporte()
        If UltraGrid1.Rows.Count <= 0 Then
            MsgBox("No existen datos a exportar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Dim rpta As Long
        Dim ruta As String = Application.StartupPath & "\HISTORIAL_PEDIDO " & ".xls"
        Dim archivoexcel As String = Trim(ruta)

        Try
            If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If
            Me.UltraGridExcelExporter1.Export(UltraGrid1, ruta)

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
            h_hoja.Range("A2:S2").Merge()
            h_hoja.Range("A2:S2").Font.Bold = True
            h_hoja.Range("A2:DG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = "HISTORIAL DE PEDIDO DE SUMINISTROS DESDE " & CDate(dtpDesde.Value).ToString("dd/MM/yyyy") & " HASTA " & CDate(dtpHasta.Value).ToString("dd/MM/yyyy")
            h_hoja.Range("A1").ColumnWidth = 10
            h_hoja.Range("B1").ColumnWidth = 10
            h_hoja.Range("C1").ColumnWidth = 9
            h_hoja.Range("C4").RowHeight = 25
            h_hoja.Range("A4:S4").WrapText = True
            h_hoja.Range("D1").ColumnWidth = 30
            h_hoja.Range("E1").ColumnWidth = 8
            h_hoja.Range("F1").ColumnWidth = 25
            h_hoja.Range("G1").ColumnWidth = 25
            h_hoja.Range("H1").ColumnWidth = 7
            h_hoja.Range("I1").ColumnWidth = 10
            h_hoja.Range("J1").ColumnWidth = 30
            h_hoja.Range("K1").ColumnWidth = 20
            h_hoja.Range("L1").ColumnWidth = 20
            h_hoja.Range("M1").ColumnWidth = 20
            h_hoja.Range("N1").ColumnWidth = 25
            h_hoja.Range("O1").ColumnWidth = 9
            h_hoja.Range("P1").ColumnWidth = 9
            h_hoja.Range("Q1").ColumnWidth = 30
            h_hoja.Range("R1").ColumnWidth = 8
            h_hoja.Range("S1").ColumnWidth = 8
            h_hoja.Range("R1:S10000").NumberFormat = "#,##0.0000"
            h_hoja.Range("R1:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            h_hoja.Range("A4:S4").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        Catch ex As Exception
            MsgBox("Error al Insertar Cabecera del Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        libro_excel.Save()
        libro_excel.Close()
        libro_excel = Nothing

        archivo_excel.Quit()
        archivo_excel = Nothing

    End Sub

    'Private Sub UltraGrid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles UltraGrid1.DoubleClickRow
    '    Try
    '        Dim estado As String
    '        Dim codigo As String
    '        estado = UltraGrid1.ActiveRow.Cells("ESTADO").Value
    '        codigo = UltraGrid1.ActiveRow.Cells("CODIGO").Value
    '        If estado <> "ATENDIDO" Then
    '            MsgBox("La solicitud no se encuentra atendida", MsgBoxStyle.Information, "Sistemas")
    '            Exit Sub
    '        End If
    '        Process.Start("\\10.10.10.33\pedidosuministro$\" & codigo & ".pdf")
    '    Catch ex As Exception

    '    End Try
    'End Sub


    Private Sub UltraGrid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles UltraGrid1.DoubleClickRow
        Try
            Dim estado As String
            Dim codigo As String
            Dim rutaArchivo As String

            estado = UltraGrid1.ActiveRow.Cells("ESTADO").Value
            codigo = UltraGrid1.ActiveRow.Cells("CODIGO").Value

            If estado <> "ATENDIDO" Then
                MsgBox("La solicitud no se encuentra atendida", MsgBoxStyle.Information, "Sistemas")
                Exit Sub
            End If

            ' Construye la ruta del archivo
            rutaArchivo = "\\10.10.10.33\pedidosuministro$\" & codigo & ".pdf"

            ' Verifica si el archivo existe
            If System.IO.File.Exists(rutaArchivo) Then
                ' Intenta abrir el archivo
                Process.Start(rutaArchivo)
            Else
                MsgBox("El archivo no se encuentra disponible.", MsgBoxStyle.Exclamation, "Sistemas")
            End If

        Catch ex As Exception
            ' Maneja cualquier otra excepción que pueda ocurrir
            MsgBox("Ocurrió un error: " & ex.Message, MsgBoxStyle.Critical, "Sistemas")
        End Try
    End Sub


    Private Sub UltraGrid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout

    End Sub
End Class