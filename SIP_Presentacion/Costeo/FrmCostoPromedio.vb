Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Imports Microsoft.Office.Interop
Public Class FrmCostoPromedio
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

    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista

    Private Sub FrmCostoPromedio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
        cmbMes.Value = 1 'Now.Date.Month
        cmbMes1.Value = Now.Date.Month
    End Sub

    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        lblmensaje.Text = "Verificando Datos..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        verificatipo()
        lblmensaje.Text = "Procesando Datos..."
        lblmensaje.Refresh()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        _objEntidad.Mes1 = cmbMes1.Value
        _objEntidad.Usuario = User_Sistema
        Dim dtDatos As New DataSet
        dtDatos = _objNegocio.Costo_ListacostoPromedio_Rango(_objEntidad)
        If dtDatos.Tables(0).Rows(0)(0) <> "OK" Then
            MsgBox(dtDatos.Tables(0).Rows(0)(0))
        End If
        Call CargarUltraGridxBinding(Me.gridcostopromedio, Source1, dtDatos.Tables(1))
        lblmensaje.Visible = False
        lblmensaje.Refresh()
    End Sub

    Sub verificatipo()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        _objEntidad.Mes1 = cmbMes1.Value
        _objEntidad.Usuario = User_Sistema
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Costo_VerificaTipo(_objEntidad)
        If dtDatos.Rows.Count > 0 Then
            MsgBox("Ingresar tipo de producto a los siguientes códigos")
            Dim frm As New FrmIngresoTipoProd
            frm.dtdatos = dtDatos
            frm.ShowDialog()
        End If
        'Call CargarUltraGridxBinding(Me.gridcostopromedio, Source1, dtDatos)
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            'btnCalcular_Click(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnduplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnduplicar.Click
        Try
            If gridcostopromedio.ActiveRow.Index < 0 Then
                MsgBox("Debe seleccionar un registro", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            Dim frm As New FrmCosto_ListaProducto
            Dim resul As DialogResult
            frm.ayo = txtayo.Value
            frm.mes = cmbMes.Value
            resul = frm.ShowDialog
            If resul = Windows.Forms.DialogResult.OK Then
                Dim _codprod As String = gridcostopromedio.ActiveRow.Cells("Cod_prod").Value.trim
                If MsgBox("Seguro desea clonar producto " & _codprod & "?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Exit Sub
                End If
                _objNegocio = New NGProducto
                _objEntidad = New ETProducto
                _objEntidad.Anho = txtayo.Value
                _objEntidad.Mes = cmbMes.Value
                _objEntidad.Mes1 = cmbMes1.Value
                _objEntidad.CodProducto = _codprod
                _objEntidad.CodProdPDCObs = frm.gridcostoproducto.ActiveRow.Cells("COD_PROD").Value.trim
                _objEntidad.Usuario = User_Sistema
                Dim dtResul As New DataTable
                dtResul = _objNegocio.Costo_ClonarRegistro_Rango(_objEntidad)
                MsgBox("Proceso generado correctamente", MsgBoxStyle.Information, msgComacsa)
                btnCalcular_Click(Nothing, Nothing)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Try
            If gridcostopromedio.ActiveRow.Index < 0 Then
                MsgBox("Debe seleccionar un registro", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            Dim _codprod As String = gridcostopromedio.ActiveRow.Cells("Cod_prod").Value.trim
            Dim _tiporeg As String = gridcostopromedio.ActiveRow.Cells("tipoRegistro").Value.trim
            If _tiporeg = "A" Then
                MsgBox("No puede eliminar un registro generado automáticamente por el sistema", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If MsgBox("Seguro desea eliminar producto " & _codprod & "?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            'MsgBox(_tiporeg)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Mes1 = cmbMes1.Value
            _objEntidad.CodProducto = _codprod
            _objEntidad.Usuario = User_Sistema
            Dim dtResul As New DataTable
            dtResul = _objNegocio.Costo_Prom_EliminarRegistro(_objEntidad)
            MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            btnCalcular_Click(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Try
            If gridcostopromedio.Rows.Count <= 0 Then
                Exit Sub
            End If
            Dim frm As New FrmCostoProm_NuevoReg
            Dim resul As DialogResult
            frm.ayo = txtayo.Value
            frm.mes = cmbMes.Value
            frm.mes1 = cmbMes1.Value
            resul = frm.ShowDialog
            If resul = Windows.Forms.DialogResult.OK Then
                MsgBox("Proceso generado correctamente", MsgBoxStyle.Information, msgComacsa)
                btnCalcular_Click(Nothing, Nothing)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        If gridcostopromedio.Rows.Count <= 0 Then
            Exit Sub
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\REPORTECOSTOPROMEDIO_" & cmbMes.Value & ".xls")
            File.Copy(RutaReporteERP & "PLANTILLA_COSTOPROMEDIO.xls", path & "\REPORTECOSTOPROMEDIO_" & cmbMes.Value & ".xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\REPORTECOSTOPROMEDIO_" & cmbMes.Value & ".xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcelIngreso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            m_Excel.Visible = True
            exportarReporte(objHojaExcelIngreso)
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub

    Sub exportarReporte(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Dim nfila As Integer
        Dim nfilaini As Integer
        Dim nfilault As Integer = 0

        nfila = 5
        nfilaini = 5

        With objHojaExcel
            .Activate()
            .Range("A2").Value = "COSTO PROMEDIO " & cmbMes.Text & " - " & cmbMes1.Text & " - " & txtayo.Value
            .Range("A2").Font.Bold = True
            Dim filaultima As Int32 = 0

            For i As Int16 = 0 To gridcostopromedio.Rows.Count - 1
                .Range("A" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("COD_PROD")
                .Range("B" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("PRODUCTO")
                .Range("E" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("MIN_VAR_D")
                .Range("F" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("MIN_VAR_I")
                .Range("G" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("MIN_FIJ_D")
                .Range("H" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("MIN_FIJ_I")
                .Range("I" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("MIN_FIJ_O")
                .Range("J" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("CHA_VAR_D")
                .Range("K" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("CHA_VAR_I")
                .Range("L" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("CHA_FIJ_D")
                .Range("M" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("CHA_FIJ_I")
                .Range("N" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("MOL_VAR_D")
                .Range("O" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("MOL_VAR_I")
                .Range("P" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("MOL_FIJ_D")
                .Range("Q" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("MOL_FIJ_I")
                .Range("T" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("ENVASES")
                .Range("R" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("GTO_ADM")
                .Range("S" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("GTO_VTA")
                .Range("T" & nfilaini + i).Value = gridcostopromedio.Rows(i).Cells("ENVASES")
                '.Range("V" & nfilaini + i).Value = "=SUMA(E" & nfilaini + i & ":T" & nfilaini + i & ")"
                '.Range("W" & nfilaini + i).Value = "=SUMA(E" & nfilaini + i & ":Q" & nfilaini + i & ",T" & nfilaini + i & ")"
                '.Range("X" & nfilaini + i).Value = "=E" & nfilaini + i & "+F" & nfilaini + i & "+J" & nfilaini + i & "+K" & nfilaini + i & "+N" & nfilaini + i & "+O" & nfilaini + i & "+T" & nfilaini + i & ""
                '.Range("Y" & nfilaini + i).Value = "=G" & nfilaini + i & "+H" & nfilaini + i & "+I" & nfilaini + i & "+L" & nfilaini + i & "+M" & nfilaini + i & "+P" & nfilaini + i & "+Q" & nfilaini + i & ""
                '.Range(.Cells(5 + i, 1), .Cells(5 + i, 7)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                nfila = nfila + 1
                filaultima = 5 + i
            Next
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If gridcostopromedio.Rows.Count = 0 Then Exit Sub
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
            ("select * from [CLONAR$A2:B40]", oConn)
            MyCommand.TableMappings.Add("Table", "Tabla")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            Dim cont As Int32 = 1
            Dim dtDatos As New DataTable
            dtDatos = DtSet.Tables(0)

            lblmensaje.Text = "Cargando datos de libro Excel..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()

            For i As Int32 = 0 To dtDatos.Rows.Count - 1
                If dtDatos.Rows(i)("BUSCAR").ToString.Trim <> "" Then
                    _objNegocio = New NGProducto
                    _objEntidad = New ETProducto
                    _objEntidad.Anho = txtayo.Value
                    _objEntidad.Mes = cmbMes.Value
                    _objEntidad.Mes1 = cmbMes1.Value
                    _objEntidad.CodProducto = dtDatos.Rows(i)("BUSCAR")
                    _objEntidad.CodProdPDCObs = dtDatos.Rows(i)("CLONAR")
                    _objEntidad.Usuario = User_Sistema
                    Dim dtResul As New DataTable
                    dtResul = _objNegocio.Costo_ClonarRegistro_Rango(_objEntidad)
                End If
            Next
            MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
            btnCalcular_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If gridcostopromedio.Rows.Count = 0 Then Exit Sub
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
                cargarDatosEnvase(oConn, cadenaExcel)
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

    Sub cargarDatosEnvase(ByVal oConn As OleDbConnection, ByVal cadenaExcel As String)
        Try
            Dim Ls_datos = New List(Of ETProveedorFiscalizado)
            Dim DtSet As New System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyCommand = New System.Data.OleDb.OleDbDataAdapter _
            ("select * from [ENVASES$A5:I40]", oConn)
            MyCommand.TableMappings.Add("Table", "Tabla")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            Dim cont As Int32 = 1
            Dim dtDatos As New DataTable
            dtDatos = DtSet.Tables(0)

            lblmensaje.Text = "Cargando datos de libro Excel..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()

            For i As Int32 = 0 To dtDatos.Rows.Count - 1
                If dtDatos.Rows(i)("CODPROD").ToString.Trim <> "" And dtDatos.Rows(i)("CODPROD_N").ToString.Trim <> "" Then
                    _objNegocio = New NGProducto
                    _objEntidad = New ETProducto
                    _objEntidad.Anho = txtayo.Value
                    _objEntidad.Mes = cmbMes.Value
                    _objEntidad.Mes1 = cmbMes1.Value
                    _objEntidad.CodProducto = dtDatos.Rows(i)("CODPROD")
                    _objEntidad.CodProdPDCObs = dtDatos.Rows(i)("CODPROD_N")
                    _objEntidad.Usuario = User_Sistema
                    Dim dtResul As New DataTable
                    dtResul = _objNegocio.Costo_ClonarEnvase(_objEntidad)
                End If
            Next
            MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
            btnCalcular_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Procesando Datos..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        _objEntidad.Mes1 = cmbMes1.Value
        _objEntidad.Usuario = User_Sistema
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Costo_ProcesaMargen(_objEntidad)
        ReporteMargenes(dtDatos)
        MessageBox.Show("Márgenes procesados correctamente.", "Sistema", MessageBoxButtons.OK)
        'Call CargarUltraGridxBinding(Me.gridcostopromedio, Source1, dtDatos)
    End Sub

    Sub ReporteMargenes(ByVal dt As DataTable)
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()


            Dim libro_excel As Microsoft.Office.Interop.Excel.Workbook = Nothing
            Dim h_hoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing

            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\MARGENES_" & cmbMes.Text & "_" & cmbMes1.Text & ".xlsm")
            File.Copy(RutaReporteERP & "Plantilla_Margenes.xlsm", path & "\MARGENES_" & cmbMes.Text & "_" & cmbMes1.Text & ".xlsm")
            m_Excel.Workbooks.Open(path & "\MARGENES_" & cmbMes.Text & "_" & cmbMes1.Text & ".xlsm")

            m_Excel.DisplayAlerts = False
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)

            Dim nfila As Int32 = 2
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                Dim nmes As Int32 = 0
                For i As Int16 = 0 To 10 'dt.Rows.Count - 1
                    .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 1)).Value = dt.Rows(i)("VALORVTASOLES")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 2)).Value = dt.Rows(i)("FLETE_PRECIO")
                    .Range(.Cells(nfila + i, 3), .Cells(nfila + i, 3)).Value = dt.Rows(i)("VALORFACTURA")
                    .Range(.Cells(nfila + i, 4), .Cells(nfila + i, 4)).Value = dt.Rows(i)("FLETEASUMIDO")
                    .Range(.Cells(nfila + i, 5), .Cells(nfila + i, 5)).Value = dt.Rows(i)("DESTINOCELIMA")
                    .Range(.Cells(nfila + i, 6), .Cells(nfila + i, 6)).Value = dt.Rows(i)("TOTALTONELADAS")
                    .Range(.Cells(nfila + i, 7), .Cells(nfila + i, 7)).Value = dt.Rows(i)("INMERSO_PRECIO")
                    .Range(.Cells(nfila + i, 8), .Cells(nfila + i, 8)).Value = dt.Rows(i)("FLETE_DISCRIMINADO_FT")
                    .Range(.Cells(nfila + i, 9), .Cells(nfila + i, 9)).Value = dt.Rows(i)("FLETE_OTRA_FACTURA")
                    .Range(.Cells(nfila + i, 10), .Cells(nfila + i, 10)).Value = dt.Rows(i)("FLETECOBRADO")
                    .Range(.Cells(nfila + i, 11), .Cells(nfila + i, 11)).Value = dt.Rows(i)("FLETEPAGADO")
                    .Range(.Cells(nfila + i, 12), .Cells(nfila + i, 12)).Value = dt.Rows(i)("FLETESOLES")
                    .Range(.Cells(nfila + i, 13), .Cells(nfila + i, 13)).Value = dt.Rows(i)("FLETE_TOTAL")
                    .Range(.Cells(nfila + i, 14), .Cells(nfila + i, 14)).Value = dt.Rows(i)("FLETE_TON")

                    .Range(.Cells(nfila + i, 15), .Cells(nfila + i, 15)).Value = dt.Rows(i)("FLETE_COBRADO")
                    .Range(.Cells(nfila + i, 16), .Cells(nfila + i, 16)).Value = dt.Rows(i)("COD_CIA")
                    .Range(.Cells(nfila + i, 17), .Cells(nfila + i, 17)).Value = dt.Rows(i)("TIPO_COMPROB")
                    .Range(.Cells(nfila + i, 18), .Cells(nfila + i, 18)).Value = dt.Rows(i)("NUMDOC")
                    .Range(.Cells(nfila + i, 19), .Cells(nfila + i, 19)).Value = dt.Rows(i)("MONEDA")
                    .Range(.Cells(nfila + i, 20), .Cells(nfila + i, 20)).Value = dt.Rows(i)("VALOR_VTA")
                    .Range(.Cells(nfila + i, 21), .Cells(nfila + i, 21)).Value = dt.Rows(i)("DCTO")
                    .Range(.Cells(nfila + i, 22), .Cells(nfila + i, 22)).Value = dt.Rows(i)("FLETE")
                    .Range(.Cells(nfila + i, 23), .Cells(nfila + i, 23)).Value = dt.Rows(i)("SEGURO")
                    .Range(.Cells(nfila + i, 24), .Cells(nfila + i, 24)).Value = dt.Rows(i)("FINANCIAM")
                    .Range(.Cells(nfila + i, 25), .Cells(nfila + i, 25)).Value = dt.Rows(i)("TC_PROMEDIO")
                    .Range(.Cells(nfila + i, 26), .Cells(nfila + i, 26)).Value = dt.Rows(i)("FEC_CREA")
                    .Range(.Cells(nfila + i, 27), .Cells(nfila + i, 27)).Value = dt.Rows(i)("CODCLI")
                    .Range(.Cells(nfila + i, 28), .Cells(nfila + i, 28)).Value = dt.Rows(i)("CON_PAGO")
                    .Range(.Cells(nfila + i, 29), .Cells(nfila + i, 29)).Value = dt.Rows(i)("COD_UBI")
                    .Range(.Cells(nfila + i, 30), .Cells(nfila + i, 30)).Value = dt.Rows(i)("COD_PROD")
                    .Range(.Cells(nfila + i, 31), .Cells(nfila + i, 31)).Value = dt.Rows(i)("FACTM")
                    .Range(.Cells(nfila + i, 32), .Cells(nfila + i, 32)).Value = dt.Rows(i)("CANT")
                    .Range(.Cells(nfila + i, 33), .Cells(nfila + i, 33)).Value = dt.Rows(i)("TIPO_MOTIVO")
                    .Range(.Cells(nfila + i, 34), .Cells(nfila + i, 34)).Value = dt.Rows(i)("COD_PRODPDC")
                    .Range(.Cells(nfila + i, 35), .Cells(nfila + i, 35)).Value = dt.Rows(i)("ANO")
                    .Range(.Cells(nfila + i, 36), .Cells(nfila + i, 36)).Value = dt.Rows(i)("MES")
                    .Range(.Cells(nfila + i, 37), .Cells(nfila + i, 37)).Value = dt.Rows(i)("NOMCLIENTE")
                    .Range(.Cells(nfila + i, 38), .Cells(nfila + i, 38)).Value = dt.Rows(i)("NOMPRODUCTO")
                    .Range(.Cells(nfila + i, 39), .Cells(nfila + i, 39)).Value = dt.Rows(i)("NOMBREPAIS")
                    .Range(.Cells(nfila + i, 40), .Cells(nfila + i, 40)).Value = dt.Rows(i)("NOMSECTOR")

                    .Range(.Cells(nfila + i, 41), .Cells(nfila + i, 41)).Value = dt.Rows(i)("ORIGEN")
                    .Range(.Cells(nfila + i, 42), .Cells(nfila + i, 42)).Value = dt.Rows(i)("AGRUPACION")
                    .Range(.Cells(nfila + i, 43), .Cells(nfila + i, 43)).Value = dt.Rows(i)("PRECIOACTUAL")
                    .Range(.Cells(nfila + i, 44), .Cells(nfila + i, 44)).Value = dt.Rows(i)("TIPO_CAMBIO")
                    .Range(.Cells(nfila + i, 45), .Cells(nfila + i, 45)).Value = dt.Rows(i)("COD_VIA")
                    .Range(.Cells(nfila + i, 46), .Cells(nfila + i, 46)).Value = dt.Rows(i)("NOMBREUNIDO")
                    .Range(.Cells(nfila + i, 47), .Cells(nfila + i, 47)).Value = dt.Rows(i)("IDNOMBREUNIDO")
                    .Range(.Cells(nfila + i, 48), .Cells(nfila + i, 48)).Value = dt.Rows(i)("CODORIGEN")
                    .Range(.Cells(nfila + i, 49), .Cells(nfila + i, 49)).Value = dt.Rows(i)("TIPO_INGRESO")
                    .Range(.Cells(nfila + i, 50), .Cells(nfila + i, 50)).Value = dt.Rows(i)("COSTO_X_TON_MER")
                    .Range(.Cells(nfila + i, 51), .Cells(nfila + i, 51)).Value = dt.Rows(i)("MIN_VAR_D")
                    .Range(.Cells(nfila + i, 52), .Cells(nfila + i, 52)).Value = dt.Rows(i)("MIN_VAR_I")
                    .Range(.Cells(nfila + i, 53), .Cells(nfila + i, 53)).Value = dt.Rows(i)("MIN_FIJ_D")
                    .Range(.Cells(nfila + i, 54), .Cells(nfila + i, 54)).Value = dt.Rows(i)("MIN_FIJ_I")
                    .Range(.Cells(nfila + i, 55), .Cells(nfila + i, 55)).Value = dt.Rows(i)("MIN_OTRAS")
                    .Range(.Cells(nfila + i, 56), .Cells(nfila + i, 56)).Value = dt.Rows(i)("CHA_VAR_D")
                    .Range(.Cells(nfila + i, 57), .Cells(nfila + i, 57)).Value = dt.Rows(i)("CHA_VAR_I")
                    .Range(.Cells(nfila + i, 58), .Cells(nfila + i, 58)).Value = dt.Rows(i)("CHA_FIJ_D")
                    .Range(.Cells(nfila + i, 59), .Cells(nfila + i, 59)).Value = dt.Rows(i)("CHA_FIJ_I")
                    .Range(.Cells(nfila + i, 60), .Cells(nfila + i, 60)).Value = dt.Rows(i)("MOL_VAR_D")
                    .Range(.Cells(nfila + i, 61), .Cells(nfila + i, 61)).Value = dt.Rows(i)("MOL_VAR_I")
                    .Range(.Cells(nfila + i, 62), .Cells(nfila + i, 62)).Value = dt.Rows(i)("MOL_FIJ_D")
                    .Range(.Cells(nfila + i, 63), .Cells(nfila + i, 63)).Value = dt.Rows(i)("MOL_FIJ_I")
                    .Range(.Cells(nfila + i, 64), .Cells(nfila + i, 64)).Value = dt.Rows(i)("ENVASES")
                    .Range(.Cells(nfila + i, 65), .Cells(nfila + i, 65)).Value = ""
                    .Range(.Cells(nfila + i, 66), .Cells(nfila + i, 66)).Value = ""
                    .Range(.Cells(nfila + i, 67), .Cells(nfila + i, 67)).Value = "=AX" & nfila + i & "+AY" & nfila + i & "+AZ" & nfila + i & "+BD" & nfila + i & "+BE" & nfila + i & "+BH" & nfila + i & "+BI" & nfila + i & "+BL" & nfila + i & ""
                    .Range(.Cells(nfila + i, 68), .Cells(nfila + i, 68)).Value = "=BO" & nfila + i & "*F" & nfila + i & ""
                    .Range(.Cells(nfila + i, 69), .Cells(nfila + i, 69)).Value = "=BA" & nfila + i & "+BB" & nfila + i & "+BC" & nfila + i & "+BF" & nfila + i & "+BG" & nfila + i & "+BJ" & nfila + i & "+BK" & nfila + i & ""
                    .Range(.Cells(nfila + i, 70), .Cells(nfila + i, 70)).Value = "=BQ" & nfila + i & "*F" & nfila + i & ""
                    .Range(.Cells(nfila + i, 71), .Cells(nfila + i, 71)).Value = "=+BK" & nfila + i & "+BJ" & nfila + i & "+BI" & nfila + i & "+BH" & nfila + i & "+BG" & nfila + i & "+BF" & nfila + i & "+BE" & nfila + i & "+BD" & nfila + i & "+BC" & nfila + i & "+BB" & nfila + i & "+BA" & nfila + i & "+AZ" & nfila + i & "+AY" & nfila + i & "+AX" & nfila + i & "+BL" & nfila + i & ""
                    .Range(.Cells(nfila + i, 72), .Cells(nfila + i, 72)).Value = "=+BS" & nfila + i & "*F" & nfila + i & ""
                    .Range(.Cells(nfila + i, 73), .Cells(nfila + i, 73)).Value = ""
                    .Range(.Cells(nfila + i, 74), .Cells(nfila + i, 74)).Value = dt.Rows(i)("PRODUCTOPDC")
                    .Range(.Cells(nfila + i, 75), .Cells(nfila + i, 75)).Value = ""
                    .Range(.Cells(nfila + i, 76), .Cells(nfila + i, 76)).Value = ""
                    .Range(.Cells(nfila + i, 77), .Cells(nfila + i, 77)).Value = ""
                    .Range(.Cells(nfila + i, 78), .Cells(nfila + i, 78)).Value = ""
                    .Range(.Cells(nfila + i, 79), .Cells(nfila + i, 79)).Value = ""
                    .Range(.Cells(nfila + i, 80), .Cells(nfila + i, 80)).Value = ""
                    .Range(.Cells(nfila + i, 81), .Cells(nfila + i, 81)).Value = ""
                    .Range(.Cells(nfila + i, 82), .Cells(nfila + i, 82)).Value = ""

                    .Range(.Cells(nfila + i, 83), .Cells(nfila + i, 83)).Value = dt.Rows(i)("MIN_VAR_D")
                    .Range(.Cells(nfila + i, 84), .Cells(nfila + i, 84)).Value = dt.Rows(i)("MIN_VAR_I")
                    .Range(.Cells(nfila + i, 85), .Cells(nfila + i, 85)).Value = dt.Rows(i)("MIN_FIJ_D")
                    .Range(.Cells(nfila + i, 86), .Cells(nfila + i, 86)).Value = dt.Rows(i)("MIN_FIJ_I")
                    .Range(.Cells(nfila + i, 87), .Cells(nfila + i, 87)).Value = dt.Rows(i)("MIN_OTRAS")
                    .Range(.Cells(nfila + i, 88), .Cells(nfila + i, 88)).Value = dt.Rows(i)("CHA_VAR_D")
                    .Range(.Cells(nfila + i, 89), .Cells(nfila + i, 89)).Value = dt.Rows(i)("CHA_VAR_I")
                    .Range(.Cells(nfila + i, 90), .Cells(nfila + i, 90)).Value = dt.Rows(i)("CHA_FIJ_D")
                    .Range(.Cells(nfila + i, 91), .Cells(nfila + i, 91)).Value = dt.Rows(i)("CHA_FIJ_I")
                    .Range(.Cells(nfila + i, 92), .Cells(nfila + i, 92)).Value = dt.Rows(i)("MOL_VAR_D")
                    .Range(.Cells(nfila + i, 93), .Cells(nfila + i, 93)).Value = dt.Rows(i)("MOL_VAR_I")
                    .Range(.Cells(nfila + i, 94), .Cells(nfila + i, 94)).Value = dt.Rows(i)("MOL_FIJ_D")
                    .Range(.Cells(nfila + i, 95), .Cells(nfila + i, 95)).Value = dt.Rows(i)("MOL_FIJ_I")
                    .Range(.Cells(nfila + i, 96), .Cells(nfila + i, 96)).Value = dt.Rows(i)("ENVASES")

                    .Range(.Cells(nfila + i, 97), .Cells(nfila + i, 97)).Value = dt.Rows(i)("GTO_ADM")
                    .Range(.Cells(nfila + i, 98), .Cells(nfila + i, 98)).Value = dt.Rows(i)("GTO_VTA_TOT")
                    .Range(.Cells(nfila + i, 99), .Cells(nfila + i, 99)).Value = dt.Rows(i)("GTO_EXPORTACION_TOT")
                    .Range(.Cells(nfila + i, 100), .Cells(nfila + i, 100)).Value = "=SUMA(CE" & nfila + i & ":CU" & nfila + i & ")"
                    .Range(.Cells(nfila + i, 101), .Cells(nfila + i, 101)).Value = "=CS" & nfila + i & ""
                    .Range(.Cells(nfila + i, 102), .Cells(nfila + i, 102)).Value = "=CT" & nfila + i & ""
                    .Range(.Cells(nfila + i, 103), .Cells(nfila + i, 103)).Value = "=CU" & nfila + i & ""
                    .Range(.Cells(nfila + i, 104), .Cells(nfila + i, 104)).Value = "=SI(F" & nfila + i & "=0,0,CX" & nfila + i & "/F" & nfila + i & ")"
                    .Range(.Cells(nfila + i, 105), .Cells(nfila + i, 105)).Value = "=SI(F" & nfila + i & "=0,0,CY" & nfila + i & "/F" & nfila + i & ")"
                    .Range(.Cells(nfila + i, 106), .Cells(nfila + i, 106)).Value = dt.Rows(i)("NUMGUIA")
                    .Range(.Cells(nfila + i, 107), .Cells(nfila + i, 107)).Value = dt.Rows(i)("FECHAGUIA")
                    .Range(.Cells(nfila + i, 108), .Cells(nfila + i, 108)).Value = dt.Rows(i)("RUC_TRANSPORTISTA")
                    .Range(.Cells(nfila + i, 109), .Cells(nfila + i, 109)).Value = dt.Rows(i)("TRANSPORTISTA")
                    .Range(.Cells(nfila + i, 110), .Cells(nfila + i, 110)).Value = dt.Rows(i)("COD_DESPACHO")
                    .Range(.Cells(nfila + i, 111), .Cells(nfila + i, 111)).Value = dt.Rows(i)("DIR_DESPACHO")
                    .Range(.Cells(nfila + i, 112), .Cells(nfila + i, 112)).Value = dt.Rows(i)("UBI_DESPACHO")
                Next
            End With

            m_Excel.Visible = True
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault

        Catch ex As Exception
            MsgBox(ex.Message)
            m_Excel.Quit()
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()

        End Try
    End Sub

    Private Sub gridcostopromedio_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridcostopromedio.DoubleClickRow
        Try
            DetalleCosto(gridcostopromedio.ActiveRow.Cells("Cod_prod").Value.ToString.Trim)
        Catch ex As Exception

        End Try
    End Sub

    Sub DetalleCosto(ByVal cod_prod As String)
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes1.Value
            _objEntidad.CodProducto = cod_prod
            Dim dtDatos As New DataSet
            Dim dtDetProduccion As New DataTable
            Dim dtChancado As New DataTable
            Dim dtDetMineral As New DataTable
            Dim dtDetChancado As New DataTable
            Dim dtDetMolienda As New DataTable
            Dim dtDetEnvases As New DataTable
            dtDatos = _objNegocio.Costo_DetalleCostoProd(_objEntidad)
            dtDetProduccion = dtDatos.Tables(0)
            dtChancado = dtDatos.Tables(1)
            dtDetMineral = dtDatos.Tables(2)
            dtDetChancado = dtDatos.Tables(3)
            dtDetMolienda = dtDatos.Tables(4)
            dtDetEnvases = dtDatos.Tables(5)
            If dtDetMineral.Rows.Count = 0 And dtDetChancado.Rows.Count = 0 And dtDetMolienda.Rows.Count = 0 Then Exit Sub
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\DETALLE_COSTO" & cmbMes1.Text & ".xls")
            File.Copy("\\10.10.10.33\SISCOMACSA$\REPORTES\ERP_COMACSA\PLANTILLA_DETALLE_COSTO" & ".xls", path & "\DETALLE_COSTO" & cmbMes1.Text & ".xls")
            m_Excel.Workbooks.Open(path & "\DETALLE_COSTO" & cmbMes1.Text & ".xls")
            m_Excel.DisplayAlerts = False
            m_Excel.Visible = True
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim nfila As Int32 = 5
            Dim nfilaini As Int32 = 0
            With objHojaExcel
                .Activate()
                If dtDetProduccion.Rows.Count > 0 Then
                    .Range("A2").Value = "DETALLE DE COSTOS - " & dtDetProduccion.Rows(0)("COD_PROD").ToString.Trim & " " & dtDetProduccion.Rows(0)("PRODUCTO").ToString.Trim
                    .Range("E" & nfila).Value = dtDetProduccion.Rows(0)("PRODUCTO").ToString.Trim
                    '.Range("F" & nfila).Value = dtDetProduccion.Rows(0)("PRODUCTO")
                    .Range("G" & nfila).Value = dtDetProduccion.Rows(0)("ENERO")
                    .Range("H" & nfila).Value = dtDetProduccion.Rows(0)("FEBRERO")
                    .Range("I" & nfila).Value = dtDetProduccion.Rows(0)("MARZO")
                    .Range("J" & nfila).Value = dtDetProduccion.Rows(0)("ABRIL")
                    .Range("K" & nfila).Value = dtDetProduccion.Rows(0)("MAYO")
                    .Range("L" & nfila).Value = dtDetProduccion.Rows(0)("JUNIO")
                    .Range("M" & nfila).Value = dtDetProduccion.Rows(0)("JULIO")
                    .Range("N" & nfila).Value = dtDetProduccion.Rows(0)("AGOSTO")
                    .Range("O" & nfila).Value = dtDetProduccion.Rows(0)("SETIEMBRE")
                    .Range("P" & nfila).Value = dtDetProduccion.Rows(0)("OCTUBRE")
                    .Range("Q" & nfila).Value = dtDetProduccion.Rows(0)("NOVIEMBRE")
                    .Range("R" & nfila).Value = dtDetProduccion.Rows(0)("DICIEMBRE")
                End If
                nfila = nfila + 1
                If dtChancado.Rows.Count > 0 Then
                    .Range("E" & nfila).Value = dtChancado.Rows(0)("PRODUCTO").ToString.Trim
                    '.Range("F" & nfila).Value = dtChancado.Rows(0)("PRODUCTO")
                    .Range("G" & nfila).Value = dtChancado.Rows(0)("ENERO")
                    .Range("H" & nfila).Value = dtChancado.Rows(0)("FEBRERO")
                    .Range("I" & nfila).Value = dtChancado.Rows(0)("MARZO")
                    .Range("J" & nfila).Value = dtChancado.Rows(0)("ABRIL")
                    .Range("K" & nfila).Value = dtChancado.Rows(0)("MAYO")
                    .Range("L" & nfila).Value = dtChancado.Rows(0)("JUNIO")
                    .Range("M" & nfila).Value = dtChancado.Rows(0)("JULIO")
                    .Range("N" & nfila).Value = dtChancado.Rows(0)("AGOSTO")
                    .Range("O" & nfila).Value = dtChancado.Rows(0)("SETIEMBRE")
                    .Range("P" & nfila).Value = dtChancado.Rows(0)("OCTUBRE")
                    .Range("Q" & nfila).Value = dtChancado.Rows(0)("NOVIEMBRE")
                    .Range("R" & nfila).Value = dtChancado.Rows(0)("DICIEMBRE")
                End If

                '****************************MINERAL****************************
                nfila = nfila + 2
                .Range("A" & nfila - 1).Value = "MINERAL"
                .Range("C" & nfila).Value = "CODRUMA"
                .Range("D" & nfila).Value = "RUMA"
                .Range("E" & nfila).Value = "TIPO"
                .Range("F" & nfila).Value = "SUBTIPO"
                .Range("G" & nfila).Value = "ENERO"
                .Range("H" & nfila).Value = "FEBRERO"
                .Range("I" & nfila).Value = "MARZO"
                .Range("J" & nfila).Value = "ABRIL"
                .Range("K" & nfila).Value = "MAYO"
                .Range("L" & nfila).Value = "JUNIO"
                .Range("M" & nfila).Value = "JULIO"
                .Range("N" & nfila).Value = "AGOSTO"
                .Range("O" & nfila).Value = "SETIEMBRE"
                .Range("P" & nfila).Value = "OCTUBRE"
                .Range("Q" & nfila).Value = "NOVIEMBRE"
                .Range("R" & nfila).Value = "DICIEMBRE"
                .Range("C" & nfila & ":R" & nfila).Font.Bold = True
                .Range("C" & nfila & ":R" & nfila).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                nfila = nfila + 1
                nfilaini = nfila
                For i As Int32 = 0 To dtDetMineral.Rows.Count - 1
                    .Range("C" & nfila).Value = dtDetMineral.Rows(i)("CODRUMA")
                    .Range("D" & nfila).Value = dtDetMineral.Rows(i)("RUMA")
                    .Range("E" & nfila).Value = dtDetMineral.Rows(i)("TIPO")
                    .Range("F" & nfila).Value = dtDetMineral.Rows(i)("SUBTIPO")
                    .Range("G" & nfila).Value = dtDetMineral.Rows(i)("ENERO")
                    .Range("H" & nfila).Value = dtDetMineral.Rows(i)("FEBRERO")
                    .Range("I" & nfila).Value = dtDetMineral.Rows(i)("MARZO")
                    .Range("J" & nfila).Value = dtDetMineral.Rows(i)("ABRIL")
                    .Range("K" & nfila).Value = dtDetMineral.Rows(i)("MAYO")
                    .Range("L" & nfila).Value = dtDetMineral.Rows(i)("JUNIO")
                    .Range("M" & nfila).Value = dtDetMineral.Rows(i)("JULIO")
                    .Range("N" & nfila).Value = dtDetMineral.Rows(i)("AGOSTO")
                    .Range("O" & nfila).Value = dtDetMineral.Rows(i)("SETIEMBRE")
                    .Range("P" & nfila).Value = dtDetMineral.Rows(i)("OCTUBRE")
                    .Range("Q" & nfila).Value = dtDetMineral.Rows(i)("NOVIEMBRE")
                    .Range("R" & nfila).Value = dtDetMineral.Rows(i)("DICIEMBRE")
                    nfila = nfila + 1
                Next
                .Range("F" & nfila).Value = "PROMEDIO"
                .Range("G" & nfila).Value = "=(SUMA(G" & nfilaini & ":G" & nfila - 1 & ")*G5)/$S$5"
                .Range("G" & nfila).Select()
                m_Excel.Selection.Copy()
                .Range("H" & nfila & ":R" & nfila).Select()
                .Paste()
                .Range("F" & nfila & ":S" & nfila).Font.Bold = True
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range("S" & nfila).Value = "=SUMA(G" & nfila & ":R" & nfila & ")"
                .Range("A" & nfilaini - 1 & ":A" & nfila).Rows.Group()

                '****************************CHANCADO****************************
                nfila = nfila + 3
                .Range("A" & nfila - 1).Value = "CHANCADO"
                .Range("B" & nfila).Value = "RUMA"
                .Range("C" & nfila).Value = "EQUIPO"
                .Range("D" & nfila).Value = "TIPO"
                .Range("E" & nfila).Value = "SUBTIPO"
                .Range("F" & nfila).Value = "CONCEPTO"
                .Range("G" & nfila).Value = "ENERO"
                .Range("H" & nfila).Value = "FEBRERO"
                .Range("I" & nfila).Value = "MARZO"
                .Range("J" & nfila).Value = "ABRIL"
                .Range("K" & nfila).Value = "MAYO"
                .Range("L" & nfila).Value = "JUNIO"
                .Range("M" & nfila).Value = "JULIO"
                .Range("N" & nfila).Value = "AGOSTO"
                .Range("O" & nfila).Value = "SETIEMBRE"
                .Range("P" & nfila).Value = "OCTUBRE"
                .Range("Q" & nfila).Value = "NOVIEMBRE"
                .Range("R" & nfila).Value = "DICIEMBRE"
                .Range("C" & nfila & ":R" & nfila).Font.Bold = True
                .Range("B" & nfila & ":R" & nfila).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                nfila = nfila + 1
                nfilaini = nfila

                .Range("D" & nfila & ":D10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                .Range("F" & nfila & ":F10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                For i As Int32 = 0 To dtDetChancado.Rows.Count - 1
                    .Range("B" & nfila).Value = dtDetChancado.Rows(i)("RUMA")
                    .Range("C" & nfila).Value = dtDetChancado.Rows(i)("EQUIPO")
                    .Range("D" & nfila).Value = dtDetChancado.Rows(i)("TIPO")
                    .Range("E" & nfila).Value = dtDetChancado.Rows(i)("SUBTIPO")
                    .Range("F" & nfila).Value = dtDetChancado.Rows(i)("CONCEPTO")
                    .Range("G" & nfila).Value = dtDetChancado.Rows(i)("ENERO")
                    .Range("H" & nfila).Value = dtDetChancado.Rows(i)("FEBRERO")
                    .Range("I" & nfila).Value = dtDetChancado.Rows(i)("MARZO")
                    .Range("J" & nfila).Value = dtDetChancado.Rows(i)("ABRIL")
                    .Range("K" & nfila).Value = dtDetChancado.Rows(i)("MAYO")
                    .Range("L" & nfila).Value = dtDetChancado.Rows(i)("JUNIO")
                    .Range("M" & nfila).Value = dtDetChancado.Rows(i)("JULIO")
                    .Range("N" & nfila).Value = dtDetChancado.Rows(i)("AGOSTO")
                    .Range("O" & nfila).Value = dtDetChancado.Rows(i)("SETIEMBRE")
                    .Range("P" & nfila).Value = dtDetChancado.Rows(i)("OCTUBRE")
                    .Range("Q" & nfila).Value = dtDetChancado.Rows(i)("NOVIEMBRE")
                    .Range("R" & nfila).Value = dtDetChancado.Rows(i)("DICIEMBRE")
                    nfila = nfila + 1
                Next
                .Range("F" & nfila).Value = "TOTAL"
                .Range("G" & nfila).NumberFormat = "general"
                '.Range("G" & nfila).Value = "=SI(G6<>0,SUMA(G" & nfilaini & ":G" & nfila - 1 & ")/G6,0)"
                .Range("G" & nfila).Formula = "=SI.ERROR(SUMA(G" & nfilaini & ":G" & nfila - 1 & ")/G6;0)"
                .Range("G" & nfila).Select()
                m_Excel.Selection.Copy()
                .Range("H" & nfila & ":R" & nfila).Select()
                .Paste()
                .Range("F" & nfila & ":S" & nfila).Font.Bold = True
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range("S" & nfila).Value = "=SUMA(G" & nfila & ":R" & nfila & ")"

                nfila = nfila + 1

                .Range("F" & nfila).Value = "PROMEDIO"
                .Range("G" & nfila).Value = "=(G" & nfila - 1 & "*G5)/$S$5"
                .Range("G" & nfila).Select()
                m_Excel.Selection.Copy()
                .Range("H" & nfila & ":R" & nfila).Select()
                .Paste()
                .Range("F" & nfila & ":S" & nfila).Font.Bold = True
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range("S" & nfila).Value = "=SUMA(G" & nfila & ":R" & nfila & ")"
                .Range("A" & nfilaini - 1 & ":A" & nfila).Rows.Group()

                '****************************MOLIENDA****************************
                nfila = nfila + 3
                .Range("A" & nfila - 1).Value = "MOLIENDA"
                .Range("C" & nfila).Value = "EQUIPO"
                .Range("D" & nfila).Value = "TIPO"
                .Range("E" & nfila).Value = "SUBTIPO"
                .Range("F" & nfila).Value = "CONCEPTO"
                .Range("G" & nfila).Value = "ENERO"
                .Range("H" & nfila).Value = "FEBRERO"
                .Range("I" & nfila).Value = "MARZO"
                .Range("J" & nfila).Value = "ABRIL"
                .Range("K" & nfila).Value = "MAYO"
                .Range("L" & nfila).Value = "JUNIO"
                .Range("M" & nfila).Value = "JULIO"
                .Range("N" & nfila).Value = "AGOSTO"
                .Range("O" & nfila).Value = "SETIEMBRE"
                .Range("P" & nfila).Value = "OCTUBRE"
                .Range("Q" & nfila).Value = "NOVIEMBRE"
                .Range("R" & nfila).Value = "DICIEMBRE"
                .Range("C" & nfila & ":R" & nfila).Font.Bold = True
                .Range("B" & nfila & ":R" & nfila).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                nfila = nfila + 1
                nfilaini = nfila

                .Range("D" & nfila & ":D10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                .Range("F" & nfila & ":F10000").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                For i As Int32 = 0 To dtDetMolienda.Rows.Count - 1
                    .Range("C" & nfila).Value = dtDetMolienda.Rows(i)("EQUIPO")
                    .Range("D" & nfila).Value = dtDetMolienda.Rows(i)("TIPO")
                    .Range("E" & nfila).Value = dtDetMolienda.Rows(i)("SUBTIPO")
                    .Range("F" & nfila).Value = dtDetMolienda.Rows(i)("CONCEPTO")
                    .Range("G" & nfila).Value = dtDetMolienda.Rows(i)("ENERO")
                    .Range("H" & nfila).Value = dtDetMolienda.Rows(i)("FEBRERO")
                    .Range("I" & nfila).Value = dtDetMolienda.Rows(i)("MARZO")
                    .Range("J" & nfila).Value = dtDetMolienda.Rows(i)("ABRIL")
                    .Range("K" & nfila).Value = dtDetMolienda.Rows(i)("MAYO")
                    .Range("L" & nfila).Value = dtDetMolienda.Rows(i)("JUNIO")
                    .Range("M" & nfila).Value = dtDetMolienda.Rows(i)("JULIO")
                    .Range("N" & nfila).Value = dtDetMolienda.Rows(i)("AGOSTO")
                    .Range("O" & nfila).Value = dtDetMolienda.Rows(i)("SETIEMBRE")
                    .Range("P" & nfila).Value = dtDetMolienda.Rows(i)("OCTUBRE")
                    .Range("Q" & nfila).Value = dtDetMolienda.Rows(i)("NOVIEMBRE")
                    .Range("R" & nfila).Value = dtDetMolienda.Rows(i)("DICIEMBRE")
                    nfila = nfila + 1
                Next
                .Range("F" & nfila).Value = "PROMEDIO"
                .Range("G" & nfila).Value = "=(SUMA(G" & nfilaini & ":G" & nfila - 1 & ")*G5)/$S$5"
                .Range("G" & nfila).Select()
                m_Excel.Selection.Copy()
                .Range("H" & nfila & ":R" & nfila).Select()
                .Paste()
                .Range("F" & nfila & ":S" & nfila).Font.Bold = True
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range("S" & nfila).Value = "=SUMA(G" & nfila & ":R" & nfila & ")"
                .Range("A" & nfilaini - 1 & ":A" & nfila).Rows.Group()

                nfila = nfila + 2
                If dtDetEnvases.Rows.Count > 0 Then
                    .Range("F" & nfila).Value = "ENVASES"
                    .Range("G" & nfila).Value = dtDetEnvases.Rows(0)("ENERO")
                    .Range("H" & nfila).Value = dtDetEnvases.Rows(0)("FEBRERO")
                    .Range("I" & nfila).Value = dtDetEnvases.Rows(0)("MARZO")
                    .Range("J" & nfila).Value = dtDetEnvases.Rows(0)("ABRIL")
                    .Range("K" & nfila).Value = dtDetEnvases.Rows(0)("MAYO")
                    .Range("L" & nfila).Value = dtDetEnvases.Rows(0)("JUNIO")
                    .Range("M" & nfila).Value = dtDetEnvases.Rows(0)("JULIO")
                    .Range("N" & nfila).Value = dtDetEnvases.Rows(0)("AGOSTO")
                    .Range("O" & nfila).Value = dtDetEnvases.Rows(0)("SETIEMBRE")
                    .Range("P" & nfila).Value = dtDetEnvases.Rows(0)("OCTUBRE")
                    .Range("Q" & nfila).Value = dtDetEnvases.Rows(0)("NOVIEMBRE")
                    .Range("R" & nfila).Value = dtDetEnvases.Rows(0)("DICIEMBRE")
                End If
                '.Range("S" & nfila).Value = "=SUMA(G" & nfila & ":R" & nfila & ")"
                .Range("F" & nfila & ":S" & nfila).Font.Bold = True
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                '.Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                nfila = nfila + 2

                .Range("F" & nfila).Value = "PROMEDIO"
                .Range("G" & nfila).Value = "=(G" & nfila - 2 & "*G5)/$S$5"
                .Range("G" & nfila).Select()
                m_Excel.Selection.Copy()
                .Range("H" & nfila & ":R" & nfila).Select()
                .Paste()
                .Range("F" & nfila & ":S" & nfila).Font.Bold = True
                '.Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range("F" & nfila & ":S" & nfila).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                .Range("S" & nfila).Value = "=SUMA(G" & nfila & ":R" & nfila & ")"
                '.Range("A" & nfilaini - 1 & ":A" & nfila).Rows.Group()

                .Range("A2").Select()

            End With

            m_Excel.ActiveSheet.Outline.ShowLevels(RowLevels:=1)
            objHojaExcel = Nothing
            m_Excel = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            m_Excel.Quit()
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If MsgBox("Seguro desea abrir mes?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes1.Value
            _objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_Abrir_Margenes(_objEntidad)
            'Call CargarUltraGridxBinding(Me.gridcostopromedio, Source1, dtDatos)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            MessageBox.Show("Proceso realizado correctamente.", "Sistema", MessageBoxButtons.OK)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMes1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes1.ValueChanged

    End Sub
End Class