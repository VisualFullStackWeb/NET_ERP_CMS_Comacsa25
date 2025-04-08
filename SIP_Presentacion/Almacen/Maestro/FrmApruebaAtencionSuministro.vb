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
Public Class FrmApruebaAtencionSuministro
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

    Private Sub FrmApruebaAtencionSuministro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario
        CargaDatos()
    End Sub

    Sub procesar()
        CargaDatos()
    End Sub

    Sub CargaDatos()
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        Dim dt As New DataTable
        dt = _objNegocio_.ListaPedidoAtendido(User_Sistema)
        Call CargarUltraGridxBinding(UltraGrid1, Source1, dt)
    End Sub

    Private Sub chktodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktodo.CheckedChanged
        Try
            For i As Int32 = 0 To UltraGrid1.Rows.Count - 1
                If chktodo.Checked = True Then
                    UltraGrid1.Rows(i).Cells("SEL").Value = True
                Else
                    UltraGrid1.Rows(i).Cells("SEL").Value = False
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub reporte()
        If UltraGrid1.Rows.Count <= 0 Then
            MsgBox("No existen datos a exportar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Dim rpta As Long
        Dim ruta As String = Application.StartupPath & "\PEDIDO_ATENDIDO " & ".xls"
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
            h_hoja.Range("A2:K2").Merge()
            h_hoja.Range("A2:K2").Font.Bold = True
            h_hoja.Range("A2:DG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = "SALIDA DE SUMINISTROS ATENDIDAS"
            h_hoja.Range("A1").ColumnWidth = 0
            h_hoja.Range("B1").ColumnWidth = 0
            h_hoja.Range("C1").ColumnWidth = 9
            h_hoja.Range("C4").RowHeight = 25
            h_hoja.Range("A4:K4").WrapText = True
            h_hoja.Range("D1").ColumnWidth = 30
            h_hoja.Range("E1").ColumnWidth = 25
            h_hoja.Range("F1").ColumnWidth = 25
            h_hoja.Range("G1").ColumnWidth = 30
            h_hoja.Range("H1").ColumnWidth = 10
            h_hoja.Range("I1").ColumnWidth = 30
            h_hoja.Range("J1").ColumnWidth = 10
            h_hoja.Range("K1").ColumnWidth = 10
            h_hoja.Range("J1:K10000").NumberFormat = "#,##0.0000"
            h_hoja.Range("J1:K10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            h_hoja.Range("A4:K4").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        Catch ex As Exception
            MsgBox("Error al Insertar Cabecera del Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        libro_excel.Save()
        libro_excel.Close()
        libro_excel = Nothing

        archivo_excel.Quit()
        archivo_excel = Nothing

    End Sub

    Sub Grabar()
        If MsgBox("Desa aprobar los registros seleccionados?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
        Dim cadena As String = ""
        UltraGrid1.PerformAction(ExitEditMode)
        Dim pri_codigo As String = ""
        For i As Int32 = 0 To UltraGrid1.Rows.Count - 1
            _objNegocio_ = New NGProducto
            _objEntidad_ = New ETProducto
            _objEntidad_.numdoc = UltraGrid1.Rows(i).Cells("CODIGO").Value
            _objEntidad_.Usuario = User_Sistema
            _objEntidad_.aprobado = IIf(UltraGrid1.Rows(i).Cells("SEL").Value = True, 1, 0)
            If UltraGrid1.Rows(i).Cells("SEL").Value = True Then
                If cadena = "" Then pri_codigo = UltraGrid1.Rows(i).Cells("CODIGO").Value
                cadena = cadena + "," + UltraGrid1.Rows(i).Cells("CODIGO").Value
                _objEntidad_.cadena = cadena
            End If
            Dim dt As New DataTable
            dt = _objNegocio_.ApruebaPedidoAtendido(_objEntidad_)
            'Call CargarUltraGridxBinding(UltraGrid1, Source1, dt)
        Next
        'MsgBox(cadena)
        'MsgBox(pri_codigo)
        MsgBox("Pedidos aprobados correctamente", MsgBoxStyle.Information, "Sistema")
        EnviaCorreoAprobado(cadena, pri_codigo)
        CargaDatos()
        chktodo.Checked = False
    End Sub

    Sub EnviaCorreoAprobado(ByVal cadena As String, ByVal pri_codigo As String)
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        Dim dt As New DataTable
        dt = _objNegocio_.ListaPedidoAtendidoCadena(User_Sistema, cadena)
        Call CargarUltraGridxBinding(UltraGrid1, Source1, dt)

        If UltraGrid1.Rows.Count <= 0 Then
            Exit Sub
        End If
        Dim rpta As Long
        Dim ruta As String = "\\10.10.10.33\PEDIDOATENDIDO_APROB$\APROBACION_" & CDate(Now.Date).ToString("dd_MM_yyyy") & "_" & pri_codigo & ".xls"
        Dim archivoexcel As String = Trim(ruta)

        Try
            If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If
            Me.UltraGridExcelExporter1.Export(UltraGrid1, ruta)

            ''poner cabecera
            Call poner_cabecera_archivo_excel(archivoexcel)

            'MessageBox.Show("Exportado: " & Chr(13) & ruta, "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Abrir_Archivo(ruta)

            'proc para enviar correo
            _objNegocio_ = New NGProducto
            _objEntidad_ = New ETProducto
            dt = New DataTable
            dt = _objNegocio_.ListaPedidoAtendidoCorreo(archivoexcel)
        Catch ex As Exception
            'MessageBox.Show("Ruta Especificada No Existe", "Invalid File Name")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub UltraGrid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout

    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged

    End Sub
End Class