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
Public Class FrmReporteIndirecto
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

    Private Sub FrmReporteIndirecto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
        cmbMes.Value = Now.Date.Month
    End Sub

    Sub CargaDetalle()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 0
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirecto(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid1, Source1, dtDatos)

            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_INDDETALLE_" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid1, ruta)
            Call poner_cabecera_archivo_excel_Detalle(Trim(ruta))
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:H").ColumnWidth = 12
            objHojaExcel.Columns("A").ColumnWidth = 5
            objHojaExcel.Columns("C").ColumnWidth = 30
            objHojaExcel.Columns("D").ColumnWidth = 8
            objHojaExcel.Columns("F").ColumnWidth = 30
            objHojaExcel.Range("G2:G10000").NumberFormat = "###,##0.00"
            xApp.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub poner_cabecera_archivo_excel_Detalle(ByVal p_archivo As String)

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
            h_hoja.Range("A3:AG3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A2:H2").Merge()
            h_hoja.Range("A2:H2").Font.Bold = True
            h_hoja.Range("A2:AG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Range("A1:A2").Font.Size = 9
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = "DETALLE DE COSTOS INDIRECTOS - " & cmbMes.Text
        Catch ex As Exception
            MsgBox("Error al Insertar Cabecera del Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        libro_excel.Save()
        libro_excel.Close()
        libro_excel = Nothing

        archivo_excel.Quit()
        archivo_excel = Nothing

    End Sub

    Sub CargaBeneficio()
        Try

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 1
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirecto(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid2, Source2, dtDatos)
            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_INDBENEFICIO" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid2, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 1, "BENEFICIO")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub CargaCAL()
        Try

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 1
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirectoCAL(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid2, Source2, dtDatos)
            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_INDCAL" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid2, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 1, "CALIMA")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub CargaTalleres()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 2
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirecto(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid2, Source2, dtDatos)

            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_TALLERES" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid2, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 2, "BENFICIO")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub CargaTalleresCAL()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 2
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirectoCAL(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid2, Source2, dtDatos)

            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_TALLERES_CAL" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid2, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 2, "CALIMA")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub CargaAdmVenta()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 3
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirecto(_objEntidad)
            If dtDatos.Columns.Count = 1 Then
                MsgBox(dtDatos.Rows(0)(0))
                Dim frm As New FrmSeteoCuentaADMVTA
                frm.ayo = txtayo.Value
                frm.ShowDialog()
                Exit Sub
            End If
            Call CargarUltraGridxBinding(Me.Grid3, Source3, dtDatos)

            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_ADMVENTA" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(Grid3, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 3, "BENEFICIO")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Columns("C:H").ColumnWidth = 12
            'objHojaExcel.Columns("A:H").Merge()
            'h_hoja.Range("A3:H3").Merge()
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub CargaAdmVentaCAL()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 3
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirectoCAL(_objEntidad)
            Call CargarUltraGridxBinding(Me.Grid3, Source3, dtDatos)

            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_ADMVENTA_CAL" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(Grid3, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 2, "CALIMA")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub poner_cabecera_mat_prima(ByVal p_archivo As String, ByVal tipo As Int32, ByVal centrocosto As String)

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
            h_hoja.Range("A3:J3").Merge()
            h_hoja.Range("A3:J3").Font.Bold = True
            h_hoja.Range("A3:AG3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A2:J2").Merge()
            h_hoja.Range("A2:J2").Font.Bold = True
            h_hoja.Range("A2:AG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Range("A1:A2").Font.Size = 9
            'h_hoja.Range("A").ColumnWidth = 10
            'h_hoja.Range("B").ColumnWidth = 45
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            If tipo = 1 Then
                h_hoja.Cells(2, 1).value = "PRODUCCION VS MATERA PRIMA " & centrocosto.ToString.ToUpper & " - " & cmbMes.Text
            End If
        Catch ex As Exception
            MsgBox("Error al Insertar Cabecera del Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        libro_excel.Save()
        libro_excel.Close()
        libro_excel = Nothing

        archivo_excel.Quit()
        archivo_excel = Nothing

    End Sub

    Private Sub poner_cabecera_archivo_excel_Beneficio(ByVal p_archivo As String, ByVal tipo As Int32, ByVal centrocosto As String)

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
            h_hoja.Range("A3:S3").Font.Bold = True
            h_hoja.Range("A3:AG3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            'h_hoja.Range("A2:S2").Merge()
            h_hoja.Range("A2:S2").Font.Bold = True
            h_hoja.Range("A2:AG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Range("A1:A2").Font.Size = 9
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            If tipo = 1 Then
                'h_hoja.Range("A3:S3").Merge()
                h_hoja.Range("A2:S2").Merge()
                h_hoja.Cells(2, 1).value = "DETALLE DE COSTOS INDIRECTOS " & centrocosto.ToString.ToUpper & " - " & cmbMes.Text
            ElseIf tipo = 2 Then
                'h_hoja.Range("A3:S3").Merge()
                h_hoja.Range("A2:S2").Merge()
                h_hoja.Cells(2, 1).value = "DETALLE DE COSTOS INDIRECTOS TALLERES - " & cmbMes.Text
            ElseIf tipo = 3 Then
                h_hoja.Range("C3:F3").ColumnWidth = 12
                h_hoja.Range("A2:H2").Merge()
                h_hoja.Range("A4:H4").RowHeight = 35
                h_hoja.Range("A4:H4").WrapText = True
                h_hoja.Cells(2, 1).value = "DETALLE DE COSTOS ADMINISTRACION, VENTAS Y GASTOS FINANCIEROS - " & cmbMes.Text
            End If
        Catch ex As Exception
            MsgBox("Error al Insertar Cabecera del Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        libro_excel.Save()
        libro_excel.Close()
        libro_excel = Nothing

        archivo_excel.Quit()
        archivo_excel = Nothing

    End Sub

    Private Sub btndetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndetalle.Click
        CargaDetalle()
    End Sub

    Private Sub btnbeneficio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbeneficio.Click
        CargaBeneficio()
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CargaTalleres()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CargaAdmVenta()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        CargaCAL()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CargaAdmVentaCAL()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        CargaTalleresCAL()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        CargaMPCAL()
    End Sub
    Sub CargaMPCAL()
        Try

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 1
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_MP_CAL(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid2, Source2, dtDatos)
            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_MP_CAL" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid2, ruta)
            poner_cabecera_mat_prima(Trim(ruta), 1, "CALIMA")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A").ColumnWidth = 10
            objHojaExcel.Columns("B").ColumnWidth = 45
            objHojaExcel.Columns("D").ColumnWidth = 12
            objHojaExcel.Columns("E").ColumnWidth = 12.86
            objHojaExcel.Columns("F").ColumnWidth = 12.71
            objHojaExcel.Columns("G").ColumnWidth = 36
            objHojaExcel.Columns("H").ColumnWidth = 14.86
            objHojaExcel.Columns("I").ColumnWidth = 10
            objHojaExcel.Columns("J").ColumnWidth = 10.71

            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        CargaMPTerrazo()
    End Sub
    Sub CargaMPTerrazo()
        Try

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 1
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_MP_Terrazo(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid2, Source2, dtDatos)
            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_MP_TERRAZO" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid2, ruta)
            poner_cabecera_mat_prima(Trim(ruta), 1, "TERRAZZOS")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A").ColumnWidth = 10
            objHojaExcel.Columns("B").ColumnWidth = 45
            objHojaExcel.Columns("D").ColumnWidth = 12
            objHojaExcel.Columns("E").ColumnWidth = 12.86
            objHojaExcel.Columns("F").ColumnWidth = 12.71
            objHojaExcel.Columns("G").ColumnWidth = 36
            objHojaExcel.Columns("H").ColumnWidth = 14.86
            objHojaExcel.Columns("I").ColumnWidth = 10
            objHojaExcel.Columns("J").ColumnWidth = 10.71

            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        CargaTerrazo()
    End Sub
    Sub CargaTerrazo()
        Try

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 1
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirectoTerrazo(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid2, Source2, dtDatos)
            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_INDTEARRAZO" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid2, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 1, "TERRAZZOS")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        CargaTalleresTerrazo()
    End Sub
    Sub CargaTalleresTerrazo()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 2
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirectoTerrazo(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid2, Source2, dtDatos)

            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_TALLERES_TERRAZO" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid2, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 2, "TERRAZO")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        CargaAdmVentaTerrazo()
    End Sub
    Sub CargaAdmVentaTerrazo()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 3
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirectoTerrazo(_objEntidad)
            Call CargarUltraGridxBinding(Me.Grid3, Source3, dtDatos)

            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_ADMVENTA_TERRAZO" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(Grid3, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 2, "TERRAZO")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        CargaMPPasta()
    End Sub
    Sub CargaMPPasta()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 1
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_MP_Pasta(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid2, Source2, dtDatos)
            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_MP_PASTA" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid2, ruta)
            poner_cabecera_mat_prima(Trim(ruta), 1, "PASTAS")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A").ColumnWidth = 10
            objHojaExcel.Columns("B").ColumnWidth = 45
            objHojaExcel.Columns("D").ColumnWidth = 12
            objHojaExcel.Columns("E").ColumnWidth = 12.86
            objHojaExcel.Columns("F").ColumnWidth = 12.71
            objHojaExcel.Columns("G").ColumnWidth = 36
            objHojaExcel.Columns("H").ColumnWidth = 14.86
            objHojaExcel.Columns("I").ColumnWidth = 10
            objHojaExcel.Columns("J").ColumnWidth = 10.71

            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        CargaPastas()
    End Sub
    Sub CargaPastas()
        Try

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 1
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirectoPastas(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid2, Source2, dtDatos)
            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_INDPASTAS" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid2, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 1, "PASTAS")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        CargaTalleresPastas()
    End Sub
    Sub CargaTalleresPastas()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 2
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirectoPastas(_objEntidad)
            Call CargarUltraGridxBinding(Me.grid2, Source2, dtDatos)

            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_TALLERES_PASTAS" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(grid2, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 2, "PASTAS")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        CargaAdmVentaPastas()
    End Sub
    Sub CargaAdmVentaPastas()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Tipo = 3
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RptIndirectoPastas(_objEntidad)
            Call CargarUltraGridxBinding(Me.Grid3, Source3, dtDatos)

            Dim path As String
            path = Application.StartupPath
            Dim ruta As String = path & "\REPORTE_COSTO_ADMVENTA_PASTAS" & cmbMes.Text & ".xls"
            Me.UltraGridExcelExporter1.Export(Grid3, ruta)
            poner_cabecera_archivo_excel_Beneficio(Trim(ruta), 2, "PASTAS")
            Dim xApp As Object
            Dim xLibros As Object
            Dim xLibro As Object
            Dim archivoexcel As String = Trim(ruta)
            xApp = CreateObject("excel.application")
            xLibros = xApp.Workbooks
            xLibros.Open(archivoexcel, 3)
            xLibro = xApp.ActiveWorkBook

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = xApp.Worksheets(1)
            objHojaExcel.Columns("A:S").ColumnWidth = 8
            objHojaExcel.Columns("B").ColumnWidth = 30
            objHojaExcel.Range("A2:S10000").NumberFormat = "###,##0.00"
            'objHojaExcel.Range("A2:S10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.
            xApp.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_GastoExportacion(_objEntidad)
            'MsgBox(dtDatos.Rows.Count)
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\COSTO_GASTO_EXPORTACION_" & cmbMes.Text.ToUpper.ToString.Trim & ".xls")
                File.Copy(RutaReporteERP & "PLANTILLA_GASTO_EXPORTACION.xls", path & "\COSTO_GASTO_EXPORTACION_" & cmbMes.Text.ToUpper.ToString.Trim & ".xls")
                m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
                m_Excel.Workbooks.Open(path & "\COSTO_GASTO_EXPORTACION_" & cmbMes.Text.ToUpper.ToString.Trim & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                'Dim objHojaExcel_Trimestral As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 5
                nfilaini = 5
                Dim filaultima As Int32 = 0
                With objHojaExcel
                    .Activate()
                    .Range("B2").Value = "GASTOS DE EXPORTACION ACUMULADO AL MES DE " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1

                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("TIPODOC")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("DOCUMENTO")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("FCHEMISION")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("DESCLIENTE")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("IDPRESENTACION")
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("PRODUCTO")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("PESONETO_TON")
                        .Range("I" & nfila + i).Value = dtDatos.Rows(i)("VALORPROVISION")
                        .Range("J" & nfila + i).Value = dtDatos.Rows(i)("GASTO_DESPACHO")
                        .Range("K" & nfila + i).Value = dtDatos.Rows(i)("GASTO_VENTA")
                        .Range("L" & nfila + i).Value = dtDatos.Rows(i)("GASTO_VENTA_TON")
                        .Range("M" & nfila + i).Value = dtDatos.Rows(i)("GASTO_PARIHUELA")
                        .Range("N" & nfila + i).Value = dtDatos.Rows(i)("GASTO_TOTAL")

                        '.Range(.Cells(nfila + i, 1), .Cells(nfila + i, 37)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        '.Range(.Cells(nfila + i, 39), .Cells(nfila + i, 70)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        '.Range(.Cells(nfila + i, 72), .Cells(nfila + i, 75)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nfila = nfila + 1
                        filaultima = nfila + i
                    Next
                End With
                m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
                m_Excel.Visible = True
            End If
            'Call CargarUltraGridxBinding(Me.gridRevision, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
            'MsgBox(ex.ToString)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
End Class