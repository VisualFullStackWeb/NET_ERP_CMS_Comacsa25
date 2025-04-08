Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Imports System.IO

Public Class FrmCargaBilletes
    Dim dtDetalle As DataTable
    Dim flgtrans As Int32
    Dim tipomov As String
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista
#Region "Variables"
    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private ListModulos As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim Ope = 1
#End Region

    Private Sub FrmCargaBilletes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFecha.Value = Now.Date
        txtAño.Value = Now.Date.Year
        cmbMes.Value = Now.Date.Month
    End Sub
    Dim estadoAlmacen As Int32 = 0
    Dim periodoProvision As Int32 = 0
    Sub verificacierreAlmacen()

        Entidad.Producto.Periodo = (cmbMes.SelectedIndex + 1).ToString.PadLeft(2, "0") & txtAño.Value.ToString
        Dim dtCierre As New DataTable
        dtCierre = Negocio.Producto.verificacierreAlmacen(Entidad.Producto)
        'Entidad.MyLista = Negocio.NEntregas.VerificaCierreContable(Entidad.Entregas)

        If dtCierre.Rows.Count > 0 Then
            estadoAlmacen = 1
        Else
            estadoAlmacen = 0
        End If

    End Sub

    Sub verificaperiodoProvision()

        Entidad.Producto.Periodo = (cmbMes.SelectedIndex + 1).ToString.PadLeft(2, "0") & txtAño.Value.ToString
        Dim dtPeriodo As New DataTable
        dtPeriodo = Negocio.Producto.verificaperiodoProvision(Entidad.Producto)
        'Entidad.MyLista = Negocio.NEntregas.VerificaCierreContable(Entidad.Entregas)

        If dtPeriodo.Rows.Count > 0 Then
            periodoProvision = 1
        Else
            periodoProvision = 0
        End If

    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Try
            If cmbMes.SelectedIndex < 0 Then
                MsgBox("Seleccione mes de proceso", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If cmbalmacen.SelectedIndex < 0 Then
                MsgBox("Seleccione almacén", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If

            verificacierreAlmacen()
            If estadoAlmacen = 1 Then MsgBox("El almacén se encuentra cerrado", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            verificaperiodoProvision()
            If periodoProvision = 1 Then MsgBox("El mes ya se encuentra provisionado", MsgBoxStyle.Information, msgComacsa) : Exit Sub

            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName
            Cursor = Cursors.WaitCursor

            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                        "Data Source= " & cadenaExcel & _
                        ";Extended Properties=""Excel 8.0;HDR=YES"""
            Dim oConn As New OleDbConnection(cs)
            Try
                oConn.Open()
                cargarDatos(oConn, cadenaExcel)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ocurrió un error")
            Finally
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Cursor = Cursors.Default
                lblmensaje.Visible = False
                lblmensaje.Refresh()
                oConn.Close()
                oConn.Dispose()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub cargarDatos(ByVal oConn As OleDbConnection, ByVal cadenaExcel As String)
        Try
            Dim Ls_datos = New List(Of ETProveedorFiscalizado)
            Dim DtSet As New System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyCommand = New System.Data.OleDb.OleDbDataAdapter _
            ("select * from [FORMATO$A8:AC1000]", oConn)
            MyCommand.TableMappings.Add("Table", "Tabla")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            Dim cont As Int32 = 1
            Dim dtDatos As New DataTable
            dtDatos = DtSet.Tables(0)

            lblmensaje.Text = "Validando datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim codigo_transp As String = ""
            Dim cod_ruma_ori As String = ""
            Dim transferencia As Int32 = 0
            For i As Int32 = 0 To dtDatos.Rows.Count - 1
                If dtDatos.Rows(i)("ITEM").ToString.Trim = "" Then Exit For
                codigo_transp = dtDatos.Rows(i)("CODIGO_TRANSPORTISTA").ToString.Trim
                If codigo_transp = "" Then Exit For
                If codigo_transp <> "" Then
                    Dim fecha_cantera As String = dtDatos.Rows(i)("FECHA").ToString.Trim
                    If fecha_cantera = "" Then MsgBox("Ingrese fecha de proceso en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim cod_cantera As String = dtDatos.Rows(i)("CODIGO_CANTERA").ToString.Trim
                    If cod_cantera = "" Then MsgBox("Ingrese codigo de cantera en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim cod_ruma As String = dtDatos.Rows(i)("CODIGO_RUMA").ToString.Trim
                    If cod_ruma = "" Then MsgBox("Ingrese codigo de ruma en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim cod_mineral As String = dtDatos.Rows(i)("CODIGO_MINERAL").ToString.Trim
                    If cod_mineral = "" Then MsgBox("Ingrese codigo de mineral en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim placa As String = dtDatos.Rows(i)("PLACA_TRACTO").ToString.Trim
                    If placa = "" Then MsgBox("Ingrese placa en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim placa_2 As String = dtDatos.Rows(i)("PLACA_CARRETA").ToString.Trim
                    'If placa_2 = "" Then MsgBox("Ingrese placa en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim dni As String = dtDatos.Rows(i)("DNI_CONDUCTOR").ToString.Trim
                    If dni = "" Then MsgBox("Ingrese dni en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    If dni.Length < 8 Then MsgBox("Ingrese dni correcto en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim serie As String = dtDatos.Rows(i)("SERIE_GUIA_COMACSA_PROVEEDOR").ToString.Trim
                    If serie = "" Then MsgBox("Ingrese serie documento en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim numero As String = dtDatos.Rows(i)("NUMERO_GUIA_COMACSA_PROVEEDOR").ToString.Trim
                    If numero = "" Then MsgBox("Ingrese numero documento en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim peso_bruto As Double = dtDatos.Rows(i)("PESO_BRUTO")
                    Dim peso_tara As Double = dtDatos.Rows(i)("PESO_TARA").ToString.Trim
                    If peso_tara > peso_bruto Then MsgBox("El peso tara no puede exceder al peso bruto en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim peso_neto As Double = dtDatos.Rows(i)("PESO_NETO").ToString.Trim
                    If Math.Round(CDbl(peso_neto), 2) <> Math.Round(CDbl(peso_bruto - peso_tara), 2) Then MsgBox("El peso neto es incorrecto en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim serie_transp As String = dtDatos.Rows(i)("SERIE_GUIA_TRANSPORTISTA").ToString.Trim
                    If serie = "" Then MsgBox("Ingrese serie transportista documento en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim numero_transp As String = dtDatos.Rows(i)("NUMERO_TRANSPORTISTA").ToString.Trim
                    If numero_transp = "" Then MsgBox("Ingrese numero transportista documento en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim constancia As String = dtDatos.Rows(i)("N_CVPM").ToString.Trim
                    If constancia = "" Then MsgBox("Ingrese constancia de pesos y medidas en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub

                    Dim confvehi As String = dtDatos.Rows(i)("CONF_VEHICULAR").ToString.Trim
                    If confvehi = "" Then MsgBox("Ingrese configuracion vehicular en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub

                    Dim pesomax As String = dtDatos.Rows(i)("PESO_MAX").ToString.Trim
                    If pesomax = "" Then MsgBox("Ingrese peso maximo en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub

                    Dim fecha_salida_cantera As String = dtDatos.Rows(i)("FECHA_SALIDA_CANTERA").ToString.Trim
                    If fecha_salida_cantera = "" Then MsgBox("Ingrese fecha salida de cantera en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub

                    If Year(fecha_cantera) <> txtAño.Value Then
                        MsgBox("El año de proceso en la fila " & i + 9 & " es diferente al año seleccionado", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    End If
                    If Month(fecha_cantera) > cmbMes.Value Then
                        MsgBox("El mes de proceso en la fila " & i + 9 & " es mayor al mes selecionado", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    End If
                    
                    If chktransfer.Checked = True Then
                        transferencia = 1
                        cod_ruma_ori = dtDatos.Rows(i)("RUMA_ORIGEN").ToString.Trim
                        If cod_ruma_ori = "" Then MsgBox("Ingrese codigo de ruma origen en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    End If
                    
                    'Dim fecha_proceso As String = dtDatos.Rows(i)("FECHA_SALIDA_CANTERA").ToString.Trim
                    'If fecha_proceso = "" Then MsgBox("Ingrese fecha de proceso en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    'Dim doc_fisico As String = dtDatos.Rows(i)("DOCUMENTOS_ENTREGADOS_FISICO").ToString.Trim
                    'If doc_fisico <> "SI" And doc_fisico <> "NO" Then MsgBox("Debe ingresar solo SI o NO para el ingreso de documentos fisicos en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                End If
            Next

            lblmensaje.Text = "Cargando datos de libro Excel..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()

            objNegocio = New NGContratista
            Dim cod_alm As String = ""
            cod_alm = cmbalmacen.Value

            Dim cod_alm_ori As String = ""
            cod_alm_ori = cmbalmacenori.Value

            Dim dtResult As New DataTable
            dtResult = objNegocio.CargaBilletesPrev(dtDatos, User_Sistema, txtAño.Value, cod_alm, transferencia, cod_alm_ori)

            'COPIAMOS UNA COPIA DEL ARCHIVO EN EL SERVIDOR
            If dtResult.Rows.Count > 0 Then
                If dtResult.Rows(0)(0) = "OK" Then
                    'Dim RUTA As String = RutaReportes_UNCAEM & "\REPORTE_VARAGA_BILLETE_PREV_" & txtAño.Value & ".xlsx"
                    'If File.Exists(RUTA) Then
                    '    File.Delete(RUTA)
                    'End If
                    'File.Copy(cadenaExcel, RUTA)
                    MessageBox.Show("Datos procesados correctamente.", "Sistema", MessageBoxButtons.OK)
                    procesar()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub

    Sub procesar()
        lblmensaje.Text = "Procesando Datos..."
        lblmensaje.Visible = True
        lblmensaje.Update()
        Try
            Dim dtDatos As New DataSet
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad.Fecha = dtFecha.Value
            objEntidad.Anho = txtAño.Value
            objEntidad.Mes = cmbMes.Value
            objEntidad.COD_ALM = cmbalmacen.Value
            dtDatos = objNegocio.ListaCargaBilletePrev(objEntidad)
            Dim dtINgMin As New DataTable
            dtINgMin = dtDatos.Tables(0)

            Call CargarUltraGridxBinding(UltraGrid1, Source1, dtINgMin)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Update()
        End Try

    End Sub

    Sub Reporte()
        If UltraGrid1.Rows.Count <= 0 Then
            MsgBox("No existen datos a exportar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        'Dim rpta As Long
        Dim ruta As String = Application.StartupPath & "\INGRESO_" & cmbalmacen.Text.ToUpper & ".xls"
        Dim archivoexcel As String = Trim(ruta)

        Try
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
            h_hoja.Range("A2:H2").Merge()
            h_hoja.Range("A2:H2").Font.Bold = True
            h_hoja.Range("A2:DG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = "REPORTE INGRESO " & cmbalmacen.Text.ToUpper
            'h_hoja.Range("A1").ColumnWidth = 9.15
            'h_hoja.Range("B1").ColumnWidth = 39.3
            'h_hoja.Range("C1").ColumnWidth = 38.45
            'h_hoja.Range("D1").ColumnWidth = 29.15
            'h_hoja.Range("E1").ColumnWidth = 32.7
            h_hoja.Range("H1:H10000").NumberFormat = "#,##0.00"

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

    Private Sub cmbalmacen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbalmacen.ValueChanged

    End Sub

    Private Sub UltraLabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel4.Click

    End Sub

    Private Sub chktransfer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktransfer.CheckedChanged
        If chktransfer.Checked = True Then
            cmbalmacenori.Visible = True
            UltraLabel3.Visible = True
        Else
            cmbalmacenori.Visible = False
            UltraLabel3.Visible = False
        End If
    End Sub
End Class