Imports System.IO
Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win.UltraWinGrid

Public Class FrmCargaPesoParaCrudo
    Public Ls_Permisos As New List(Of Integer)

    Dim CargaPesoHumNG As NGCargaPesoHum
    Dim HornoGiratorio As String = "GIRATORIO"
    Dim HornoMultiple As String = "MULTIPLE"

#Region "Carga Archivo"
    Function VerificaCierreResumenCrudo(ByVal fecha As DateTime) As Boolean
        Try
            If CargaPesoHumNG.Prod_CargaPesos_ValidarCierre(fecha.Year, fecha.Month) > 0 Then
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return False
    End Function
    Private Sub btnCargarArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarArchivo.Click

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Try

            OpenFileDialog1.Filter = "Archivo de Texto|*.txt"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub

            Dim rutaArchivo As String = Me.OpenFileDialog1.FileName
            Dim nombreArchivo As String = Me.OpenFileDialog1.SafeFileName.ToUpper

            txtRutaArchivo.Text = rutaArchivo

            Cursor = Cursors.WaitCursor

            lblmensaje.Visible = True
            lblmensaje.Text = "Validando datos del archivo"
            lblmensaje.Refresh()

            Dim lineas() As String = File.ReadAllLines(rutaArchivo)

            Dim codigo As String = ""
            Dim hora As String = ""
            Dim fecha As DateTime = DateTime.MinValue
            Dim peso_caliza As Decimal = 0.0
            Dim peso_silice As Decimal = 0.0
            Dim peso_caolin As Decimal = 0.0
            Dim cadena As String = ""

            Dim dt As DataTable = CrearTabla()

            Dim lst As New List(Of DateTime)

            Dim Grupo As String = DateTime.Now.ToString("yyyyMMddHHmmss")

            'guardamos una copia del archivo
            'File.Copy(rutaArchivo, "\\198.9.9.20\Shared\CargaPesos\" & nombreArchivo.Replace(".TXT", "_" & Grupo & ".TXT"), False)

            For Each trama As String In lineas
                fecha = DateTime.MinValue
                If Not trama.StartsWith("kg") AndAlso trama.Length > 60 Then
                    If DateTime.TryParseExact(trama.Substring(15, 10), _
                                              "dd/MM/yyyy", _
                                              System.Globalization.CultureInfo.CurrentCulture, _
                                              Globalization.DateTimeStyles.None, fecha) Then

                        If Not lst.Contains(fecha) Then

                            lst.Add(fecha)

                        End If
                    End If
                End If
            Next

            For Each fechaProceso As DateTime In lst
                If VerificaCierreResumenCrudo(fechaProceso) Then
                    MsgBox("El archivo tiene fechas que pertenecen a meses cerrados")
                    Exit Sub
                End If
            Next

            For Each FechaProceso As DateTime In lst
                CargaPesoHumNG.Prod_CargaPesos_LimpiarRegistros(FechaProceso.Year, FechaProceso.Month, FechaProceso.Day)
            Next

            For Each trama As String In lineas

                peso_silice = 0.0
                peso_caliza = 0.0
                peso_caolin = 0.0
                codigo = ""
                hora = ""
                fecha = DateTime.MinValue
                cadena = ""

                trama = trama.Trim()

                If Not trama.StartsWith("kg") AndAlso trama.Length > 60 Then

                    codigo = trama.Substring(0, 6)
                    hora = trama.Substring(8, 5)

                    If DateTime.TryParseExact(trama.Substring(15, 10), _
                                              "dd/MM/yyyy", _
                                              System.Globalization.CultureInfo.CurrentCulture, _
                                              Globalization.DateTimeStyles.None, fecha) Then

                        If Not Decimal.TryParse(trama.Substring(28, 7), peso_caliza) Then
                            peso_caliza = 0.0
                        End If
                        If Not Decimal.TryParse(trama.Substring(41, 7), peso_silice) Then
                            peso_silice = 0.0
                        End If
                        If Not Decimal.TryParse(trama.Substring(54, 7), peso_caolin) Then
                            peso_caolin = 0.0
                        End If

                        cadena = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", codigo, hora, fecha.ToString("dd/MM/yyyy"), peso_caliza, peso_silice, peso_caolin)

                        dt.Rows.Add(codigo, hora, fecha.ToString("dd/MM/yyyy"), peso_caliza, peso_silice, peso_caolin, cadena)

                        CargaPesoHumNG.Prod_CargaPesos_RegistrarTrama(codigo, hora, fecha, peso_caliza, peso_silice, peso_caolin, Grupo)

                    End If

                End If
            Next

            TabContenedor.SelectedTab = TabContenedor.Tabs(1)

            If lst.Count > 0 Then
                cboAnio.SelectedValue = lst(0).Year
                cboMes.SelectedValue = lst(0).Month
            End If

            Dim ds As DataSet = CargaPesoHumNG.Listar_CargaPesosHumGrupo(Grupo)

            ugDatos.DataSource = ds.Tables(0)

            Buscar()

            lblmensaje.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

            lblmensaje.Visible = False
            lblmensaje.Text = ""
            lblmensaje.Refresh()

        End Try
    End Sub
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Excel()
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Grabar()
        Buscar()
    End Sub
#End Region
#Region "Eventos de Grilla"
    Private Sub UltraGrid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDatos.InitializeLayout
        ' ordenamiento de columnas
        Dim layout As UltraGridLayout = e.Layout
        Dim band As UltraGridBand = layout.Bands(0)
        Dim ov As UltraGridOverride = layout.Override

        ov.HeaderClickAction = HeaderClickAction.SortMulti
        band.SortedColumns.Add("FECHA", False)
        band.SortedColumns.Add("HORA", False)

    End Sub
#End Region

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
             Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Private Sub FrmCargaPesoParaCrudo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dtAnio As New DataTable()

            dtAnio.Columns.Add("YEAR", GetType(String))
            dtAnio.Columns.Add("YEAR_NAME", GetType(String))

            For index As Integer = 0 To 5

                dtAnio.Rows.Add((2018 + index).ToString(), (2018 + index).ToString())

            Next

            cboAnio.DataSource = dtAnio
            cboAnio.DisplayMember = "YEAR_NAME"
            cboAnio.ValueMember = "YEAR"

            cboAnioHornoGiratorio.DataSource = dtAnio.Copy
            cboAnioHornoGiratorio.DisplayMember = "YEAR_NAME"
            cboAnioHornoGiratorio.ValueMember = "YEAR"

            cboAnioHornoMultiple.DataSource = dtAnio.Copy
            cboAnioHornoMultiple.DisplayMember = "YEAR_NAME"
            cboAnioHornoMultiple.ValueMember = "YEAR"

            cboInventarioAnio.DataSource = dtAnio.Copy
            cboInventarioAnio.DisplayMember = "YEAR_NAME"
            cboInventarioAnio.ValueMember = "YEAR"

            Dim dtMes As New DataTable()
            dtMes.Columns.Add("MONTH", GetType(String))
            dtMes.Columns.Add("MONTH_NAME", GetType(String))

            dtMes.Rows.Add("1", "ENERO")
            dtMes.Rows.Add("2", "FEBRERO")
            dtMes.Rows.Add("3", "MARZO")
            dtMes.Rows.Add("4", "ABRIL")
            dtMes.Rows.Add("5", "MAYO")
            dtMes.Rows.Add("6", "JUNIO")
            dtMes.Rows.Add("7", "JULIO")
            dtMes.Rows.Add("8", "AGOSTO")
            dtMes.Rows.Add("9", "SETIEMBRE")
            dtMes.Rows.Add("10", "OCTUBRE")
            dtMes.Rows.Add("11", "NOVIEMBRE")
            dtMes.Rows.Add("12", "DICIEMBRE")

            cboMes.DataSource = dtMes
            cboMes.DisplayMember = "MONTH_NAME"
            cboMes.ValueMember = "MONTH"

            cboMesHornoGiratorio.DataSource = dtMes.Copy
            cboMesHornoGiratorio.DisplayMember = "MONTH_NAME"
            cboMesHornoGiratorio.ValueMember = "MONTH"

            cboMesHornoMultiple.DataSource = dtMes.Copy
            cboMesHornoMultiple.DisplayMember = "MONTH_NAME"
            cboMesHornoMultiple.ValueMember = "MONTH"

            cboInventarioMes.DataSource = dtMes.Copy
            cboInventarioMes.DisplayMember = "MONTH_NAME"
            cboInventarioMes.ValueMember = "MONTH"


            CargaPesoHumNG = New NGCargaPesoHum()

            Dim rc As Infragistics.Shared.ResourceCustomizer
            rc = Infragistics.Win.UltraWinGrid.Resources.Customizer
            rc.SetCustomizedString("GroupByBoxDefaultPrompt", "Arrastre una cabecera de columna aqui para agrupar los datos por esa columna")
            rc.SetCustomizedString("DataErrorCellUpdateUnableToUpdateValue", "El valor ingresado no es válido: {0}")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub FrmCargaPesoParaCrudo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub TabContenedor_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabContenedor.SelectedTabChanged

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarResHornoGiratorio.Click
        Procesar()
    End Sub

    Private Sub btnGenerarResHornoMultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarResHornoMultiple.Click
        Procesar()
    End Sub

#Region "Busqueda"
    Sub BuscarProduccionCrudos()
        Try
            Dim anio As Integer = Convert.ToInt32(cboAnio.SelectedValue)
            Dim mes As Integer = Convert.ToInt32(cboMes.SelectedValue)

            Dim ds As DataSet = CargaPesoHumNG.Listar_CargaPesosHum(anio, mes)

            ugResumen.DataSource = ds.Tables(1)

            If ds.Tables(2).Rows.Count > 0 Then
                nupPorcSilice.Value = Convert.ToDecimal(ds.Tables(2).Rows(0)("porc_silice"))
                nupPorcPirofilita.Value = Convert.ToDecimal(ds.Tables(2).Rows(0)("porc_pirofilita"))
            Else
                nupPorcPirofilita.Value = 0.0
                nupPorcSilice.Value = 0.0
            End If

            Dim nro_registros_cerrados As Integer = CargaPesoHumNG.Prod_CargaPesos_ValidarCierre(anio, mes)

            If nro_registros_cerrados > 0 Then

                lblEstado.Visible = True

                ugResumen.DisplayLayout.Bands(0).Columns("PORC_HUM_CALIZA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                ugResumen.DisplayLayout.Bands(0).Columns("PORC_HUM_SILICE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                ugResumen.DisplayLayout.Bands(0).Columns("PORC_HUM_CAOLIN").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                ugResumen.DisplayLayout.Bands(0).Columns("PORC_HUM_PIROFILITA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

                ugResumen.DisplayLayout.Bands(0).Columns("BASE_HUM_CALIZA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                ugResumen.DisplayLayout.Bands(0).Columns("BASE_HUM_SILICE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                ugResumen.DisplayLayout.Bands(0).Columns("BASE_HUM_CAOLIN").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            Else
                lblEstado.Visible = False

                ugResumen.DisplayLayout.Bands(0).Columns("PORC_HUM_CALIZA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                ugResumen.DisplayLayout.Bands(0).Columns("PORC_HUM_SILICE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                ugResumen.DisplayLayout.Bands(0).Columns("PORC_HUM_CAOLIN").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

                ugResumen.DisplayLayout.Bands(0).Columns("BASE_HUM_CALIZA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                ugResumen.DisplayLayout.Bands(0).Columns("BASE_HUM_SILICE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                ugResumen.DisplayLayout.Bands(0).Columns("BASE_HUM_CAOLIN").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                ugResumen.DisplayLayout.Bands(0).Columns("PORC_HUM_PIROFILITA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub BuscarResumenHornoGiratorio()
        Try

            Dim anio As Integer = Convert.ToInt32(cboAnioHornoGiratorio.SelectedValue)
            Dim mes As Integer = Convert.ToInt32(cboMesHornoGiratorio.SelectedValue)

            Dim oReporte As New ETClinker_Reporte
            oReporte.Anio = anio
            oReporte.Mes = mes
            oReporte.Tipo = HornoGiratorio

            oReporte = CargaPesoHumNG.ObtenerResumenHorno(oReporte)

            CargarResumenHornoGiratorio(oReporte)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub BuscarResumenHornoMultiple()
        Try

            Dim anio As Integer = Convert.ToInt32(cboAnioHornoMultiple.SelectedValue)
            Dim mes As Integer = Convert.ToInt32(cboMesHornoMultiple.SelectedValue)

            Dim oReporte As New ETClinker_Reporte
            oReporte.Anio = anio
            oReporte.Mes = mes
            oReporte.Tipo = HornoMultiple

            oReporte = CargaPesoHumNG.ObtenerResumenHorno(oReporte)

            CargarResumenHornoMultiple(oReporte)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub BuscarResumenInventario()
        Try
            Dim anio As Integer = Convert.ToInt32(cboInventarioAnio.SelectedValue)
            Dim mes As Integer = Convert.ToInt32(cboInventarioMes.SelectedValue)

            Dim ds As DataSet = CargaPesoHumNG.ObtenerInventario(anio, mes)


            ugInvHornoMultiple.DataSource = ds.Tables(0)
            ugInvHornoGiratorio.DataSource = ds.Tables(1)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Buscar()

        Select Case TabContenedor.SelectedTab.Key
            Case "T03"
                BuscarProduccionCrudos()
            Case "T04"
                BuscarResumenHornoGiratorio()
            Case "T05"
                BuscarResumenHornoMultiple()
            Case "T06"
                BuscarResumenInventario()
        End Select
    End Sub
#End Region

#Region "Grabar"
    Sub GrabarResumenHornoMultiple()
        Try

            If ugResHornoMultiple.DataSource Is Nothing Then Return

            Dim anio As Integer = Convert.ToInt32(cboAnioHornoMultiple.SelectedValue)
            Dim mes As Integer = Convert.ToInt32(cboMesHornoMultiple.SelectedValue)

            ugResHornoMultiple.UpdateData()

            Dim lista As List(Of ETClinker_FilaReporte) = ugResHornoMultiple.DataSource

            Dim oReporte As New ETClinker_Reporte
            oReporte.Anio = anio
            oReporte.Mes = mes
            oReporte.Tipo = HornoMultiple
            oReporte.Detalles = lista

            oReporte.I7 = nudI8.Value
            oReporte.K7 = nudK8.Value
            oReporte.L7 = nudL8.Value
            oReporte.M7 = nudM8.Value
            oReporte.N7 = 0
            oReporte.O7 = 0
            oReporte.P7 = nudP8.Value
            oReporte.Q7 = nudQ8.Value
            oReporte.R7 = nudR8.Value
            oReporte.S7 = nudS8.Value

            oReporte = CargaPesoHumNG.ActualizarResumenHorno(oReporte)

            If oReporte.idResumen > 0 Then
                MsgBox("Se actualizó el resumen")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub GrabarResumenHornoGiratorio()
        Try

            If ugResHornoGiratorio.DataSource Is Nothing Then Return

            Dim anio As Integer = Convert.ToInt32(cboAnioHornoGiratorio.SelectedValue)
            Dim mes As Integer = Convert.ToInt32(cboMesHornoGiratorio.SelectedValue)

            ugResHornoGiratorio.UpdateData()

            Dim lista As List(Of ETClinker_FilaReporte) = ugResHornoGiratorio.DataSource

            Dim oReporte As New ETClinker_Reporte
            oReporte.Anio = anio
            oReporte.Mes = mes
            oReporte.Tipo = HornoGiratorio
            oReporte.Detalles = lista

            oReporte.I7 = 0
            oReporte.K7 = nupK7.Value
            oReporte.L7 = 0
            oReporte.M7 = nupM7.Value
            oReporte.N7 = nupN7.Value
            oReporte.O7 = nupO7.Value
            oReporte.P7 = nupP7.Value
            oReporte.Q7 = 0
            oReporte.R7 = nupR7.Value
            oReporte.S7 = 0

            oReporte = CargaPesoHumNG.ActualizarResumenHorno(oReporte)

            If oReporte.idResumen > 0 Then
                MsgBox("Se Actualizó el Resumen")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub GrabarResumenCrudo()
        Try
            If ugResumen.DataSource Is Nothing Then Return

            ugResumen.UpdateData()

            Dim dt As DataTable = ugResumen.DataSource

            If Not lblEstado.Visible Then

                Dim listaItems As New List(Of ETCargaPesoCrudo)
                Dim Item As ETCargaPesoCrudo = Nothing

                For Each row As DataRow In dt.Rows
                    Item = New ETCargaPesoCrudo()

                    Item.Anio = Convert.ToInt32(row("ANIO"))
                    Item.Mes = Convert.ToInt32(row("MES"))
                    Item.Dia = Convert.ToInt32(row("DIA"))

                    Item.PorcHumCaliza = Convert.ToDecimal(row("PORC_HUM_CALIZA"))
                    Item.PorcHumSilice = Convert.ToDecimal(row("PORC_HUM_SILICE"))
                    Item.PorcHumCaolin = Convert.ToDecimal(row("PORC_HUM_CAOLIN"))
                    Item.PorcHumPirofilita = Convert.ToDecimal(row("PORC_HUM_PIROFILITA"))

                    Item.BaseCaliza = Convert.ToDecimal(row("BASE_HUM_CALIZA"))
                    Item.BaseSilice = Convert.ToDecimal(row("BASE_HUM_SILICE"))
                    Item.BaseCaolin = Convert.ToDecimal(row("BASE_HUM_CAOLIN"))

                    listaItems.Add(Item)
                Next

                If listaItems.Count > 0 Then
                    CargaPesoHumNG.Actualizar_CargaPesosResumenParametros(listaItems(0).Anio, listaItems(0).Mes, nupPorcPirofilita.Value, nupPorcSilice.Value)
                    CargaPesoHumNG.Actualizar_CargaPesosResumen(listaItems)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Grabar()

        Select Case TabContenedor.SelectedTab.Key
            Case "T03"
                GrabarResumenCrudo()
            Case "T04"
                GrabarResumenHornoGiratorio()
            Case "T05"
                GrabarResumenHornoMultiple()
        End Select

    End Sub
#End Region

#Region "Recuperar Datos"
    Public Sub CargarResumenHornoGiratorio(ByVal oResumen As ETClinker_Reporte)
        ugResHornoGiratorio.DataSource = oResumen.Detalles
        nupK7.Value = oResumen.K7
        nupM7.Value = oResumen.M7
        nupN7.Value = oResumen.N7
        nupO7.Value = oResumen.O7
        nupP7.Value = oResumen.P7
    End Sub
    Public Sub CargarResumenHornoMultiple(ByVal oResumen As ETClinker_Reporte)
        ugResHornoMultiple.DataSource = oResumen.Detalles
        nudI8.Value = oResumen.I7
        nudK8.Value = oResumen.K7
        nudL8.Value = oResumen.L7
        nudM8.Value = oResumen.M7
        nudP8.Value = oResumen.P7
        nudQ8.Value = oResumen.Q7
        nudR8.Value = oResumen.R7
        nudS8.Value = oResumen.S7
    End Sub
    Public Function ObtenerCantidadHoras(ByVal cadena As String) As Double
        Dim valor As Double
        Try

            Dim time As DateTime

            If cadena <> "24:00" Then
                If DateTime.TryParseExact(cadena, "HH:mm", _
                Globalization.CultureInfo.CurrentCulture, _
                Globalization.DateTimeStyles.None, time) Then
                    valor = time.TimeOfDay.TotalHours
                End If
            Else
                valor = 24.0
            End If

            valor = Math.Round(valor, 2)
        Catch ex As Exception
            valor = 0
        End Try
        Return valor
    End Function
#End Region

#Region "Excel"
    Sub GenerarExcelResumenClinkerHornoGiratorio()
        Try

            GrabarResumenHornoGiratorio()

            Dim oReporte As New ETClinker_Reporte
            oReporte.Anio = Convert.ToInt32(cboAnioHornoGiratorio.SelectedValue)
            oReporte.Mes = Convert.ToInt32(cboMesHornoGiratorio.SelectedValue)
            oReporte.Tipo = HornoGiratorio

            oReporte = CargaPesoHumNG.ObtenerResumenHorno(oReporte)

            Dim rutaPlantilla As String = RutaReporteERP & "PLANTILLA_PROD_CLINKER_HG.xlsx"
            Dim nombreArchivo As String = "FORMATO_PRODUCCION_CLINKER_HG" & DateTime.Now.ToString("_yyyyMMddHHmmss") & ".xlsx"

            Dim rutaDestino As String = Application.StartupPath & "\" & nombreArchivo

            If File.Exists(rutaPlantilla) Then

                File.Copy(rutaPlantilla, rutaDestino)

            End If


            Dim culture As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture

            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
            Dim ObjW As Microsoft.Office.Interop.Excel.Workbook

            ObjExcel = New Microsoft.Office.Interop.Excel.Application
            ObjW = ObjExcel.Workbooks.Open(rutaDestino)

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = ObjW.Worksheets(1)

            With objHojaExcel
                .Activate()

                .Name = NombreMes(oReporte.Mes)

                .Range("A7").Value = NombreMes(oReporte.Mes) & "," & oReporte.Anio
                '.Range("I7").Value = oReporte.I7
                .Range("K7").Value = oReporte.K7
                '.Range("L7").Value = oReporte.L7
                .Range("M7").Value = oReporte.M7
                .Range("N7").Value = oReporte.N7
                .Range("O7").Value = oReporte.O7
                .Range("P7").Value = oReporte.P7
                '.Range("Q7").Value = oReporte.Q7
                .Range("R7").Value = oReporte.R7

                For Each row As ETClinker_FilaReporte In oReporte.Detalles

                    Dim rowIndex As String = (row.Dia + 10).ToString()

                    .Range("A" & rowIndex).Value = row.Dia
                    If row.De.HasValue Then
                        .Range("B" & rowIndex).Value = row.De.Value.ToString("hh:mm tt")
                    Else
                        .Range("B" & rowIndex).Value = ""
                    End If
                    If row.A.HasValue Then
                        .Range("C" & rowIndex).Value = row.A.Value.ToString("hh:mm tt")
                    Else
                        .Range("C" & rowIndex).Value = ""
                    End If

                    .Range("D" & rowIndex).Value = ObtenerCantidadHoras(row.TotalHoras)
                    .Range("E" & rowIndex).Value = row.KgPorMin

                    .Range("I" & rowIndex).Value = row.CrudoRecirculado
                    .Range("K" & rowIndex).Formula = "=" & row.Descuento.ToString & "*K7"
                    .Range("O" & rowIndex).Formula = "=" & row.Merma.ToString() & "*P7"
                    .Range("Q" & rowIndex).Value = row.ConsumoGas
                Next

            End With


            ObjExcel.Visible = True

            System.Threading.Thread.CurrentThread.CurrentCulture = culture

        Catch err As Exception
            MsgBox(err.Message)
        End Try
    End Sub
    Sub GenerarExcelResumenHornoMultiple()
        Try

            GrabarResumenHornoMultiple()

            Dim oReporte As New ETClinker_Reporte
            oReporte.Anio = Convert.ToInt32(cboAnioHornoMultiple.SelectedValue)
            oReporte.Mes = Convert.ToInt32(cboMesHornoMultiple.SelectedValue)
            oReporte.Tipo = HornoMultiple

            oReporte = CargaPesoHumNG.ObtenerResumenHorno(oReporte)

            Dim rutaPlantilla As String = RutaReporteERP & "PLANTILLA_PROD_CLINKER_HM.xlsx"
            Dim nombreArchivo As String = "FORMATO_PRODUCCION_CLINKER_HM" & DateTime.Now.ToString("_yyyyMMddHHmmss") & ".xlsx"

            Dim rutaDestino As String = Application.StartupPath & "\" & nombreArchivo

            If File.Exists(rutaPlantilla) Then

                File.Copy(rutaPlantilla, rutaDestino)

            End If


            Dim culture As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture

            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
            Dim ObjW As Microsoft.Office.Interop.Excel.Workbook

            ObjExcel = New Microsoft.Office.Interop.Excel.Application
            ObjW = ObjExcel.Workbooks.Open(rutaDestino)

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = ObjW.Worksheets(1)

            With objHojaExcel
                .Activate()

                .Name = NombreMes(oReporte.Mes)

                .Range("A7").Value = NombreMes(oReporte.Mes) & "," & oReporte.Anio
                .Range("I8").Value = oReporte.I7
                .Range("K8").Value = oReporte.K7
                .Range("L8").Value = oReporte.L7
                .Range("M8").Value = oReporte.M7
                '.Range("N7").Value = oReporte.N7
                '.Range("O7").Value = oReporte.O7
                .Range("P8").Value = oReporte.P7
                .Range("Q8").Value = oReporte.Q7
                .Range("R8").Value = oReporte.R7
                .Range("S8").Value = oReporte.S7

                For Each row As ETClinker_FilaReporte In oReporte.Detalles

                    Dim rowIndex As String = (row.Dia + 11).ToString()

                    .Range("A" & rowIndex).Value = row.Dia
                    If row.De.HasValue Then
                        .Range("B" & rowIndex).Value = row.De.Value.ToString("hh:mm tt")
                    Else
                        .Range("B" & rowIndex).Value = ""
                    End If
                    If row.A.HasValue Then
                        .Range("C" & rowIndex).Value = row.A.Value.ToString("hh:mm tt")
                    Else
                        .Range("C" & rowIndex).Value = ""
                    End If

                    .Range("D" & rowIndex).Value = ObtenerCantidadHoras(row.TotalHoras)
                    .Range("E" & rowIndex).Value = row.KgPorMin

                    .Range("I" & rowIndex).Value = row.CrudoRecirculado
                    .Range("K" & rowIndex).Value = row.Fm
                    .Range("L" & rowIndex).Value = row.Ciclones
                    .Range("M" & rowIndex).Value = row.Otros
                    .Range("R" & rowIndex).Formula = row.Merma
                    .Range("Q" & rowIndex).Value = row.ConsumoGas
                Next

            End With

            ObjExcel.Visible = True

            System.Threading.Thread.CurrentThread.CurrentCulture = culture

        Catch err As Exception
            MsgBox(err.Message)
        End Try
    End Sub
    Sub GenerarExcelResumenCrudo()

        Try

            If ugResumen.DataSource Is Nothing Then Return

            GrabarResumenCrudo()

            BuscarProduccionCrudos()

            Dim dt As DataTable = ugResumen.DataSource

            Dim rutaPlantilla As String = RutaReporteERP & "PLANTILLAPRODUCCIONCRUDOS.xlsx" ' Application.StartupPath + "\PROD_FORMATO_CRUDO.xlsx"
            Dim nombreArchivo As String = "FORMATO_PRODUCCION_CRUDOS_" & DateTime.Now.ToString("_yyyyMMddHHmmss") & ".xlsx"

            Dim rutaDestino As String = Application.StartupPath & "\" & nombreArchivo

            If File.Exists(rutaPlantilla) Then

                File.Copy(rutaPlantilla, rutaDestino)

            End If


            Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
            Dim ObjW As Microsoft.Office.Interop.Excel.Workbook

            ObjExcel = New Microsoft.Office.Interop.Excel.Application
            ObjW = ObjExcel.Workbooks.Open(rutaDestino)

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = ObjW.Worksheets(1)

            With objHojaExcel
                .Activate()

                .Name = cboMes.Text

                .Range("A6").Value = cboMes.Text & "," & cboAnio.Text
                .Range("I97").Value = nupPorcSilice.Value
                .Range("L97").Value = nupPorcPirofilita.Value

                'recorremos las filas
                For index As Integer = 10 To 41

                    .Range("B" & index.ToString()).Value = ""
                    .Range("C" & index.ToString()).Value = ""
                    .Range("D" & index.ToString()).Value = ""

                    .Range("F" & index.ToString()).Value = ""
                    .Range("G" & index.ToString()).Value = ""

                    .Range("I" & index.ToString()).Value = ""
                    .Range("J" & index.ToString()).Value = ""

                    .Range("L" & index.ToString()).Value = ""
                    .Range("M" & index.ToString()).Value = ""

                    .Range("Q" & index.ToString()).Value = ""
                    .Range("R" & index.ToString()).Value = ""
                    .Range("S" & index.ToString()).Value = ""

                Next

                For Each row As DataRow In dt.Rows

                    Dim dia As Integer = Convert.ToInt32(row("DIA"))
                    Dim index As String = (dia + 9).ToString()

                    If .Range("A" + index).Value.ToString = dia.ToString() Then

                        .Range("B" & index).Value = Convert.ToInt32(row("NRO_ITEMS"))
                        .Range("C" & index).Value = Convert.ToDecimal(row("PESO_HUM_CALIZA"))
                        .Range("D" & index).Value = Convert.ToDecimal(row("PORC_HUM_CALIZA"))

                        .Range("F" & index).Value = Convert.ToDecimal(row("PESO_HUM_SILICE"))
                        .Range("G" & index).Value = Convert.ToDecimal(row("PORC_HUM_SILICE"))

                        .Range("I" & index).Value = Convert.ToDecimal(row("PESO_HUM_CAOLIN"))
                        .Range("J" & index).Value = Convert.ToDecimal(row("PORC_HUM_CAOLIN"))

                        .Range("L" & index).Value = Convert.ToDecimal(row("PESO_HUM_PIROFILITA"))
                        .Range("M" & index).Value = Convert.ToDecimal(row("PORC_HUM_PIROFILITA"))

                        .Range("Q" & index).Value = Convert.ToDecimal(row("BASE_HUM_CALIZA"))
                        .Range("R" & index).Value = Convert.ToDecimal(row("BASE_HUM_SILICE"))
                        .Range("S" & index).Value = Convert.ToDecimal(row("BASE_HUM_PIROFILITA"))


                    End If
                Next

            End With


            ObjExcel.Visible = True
            'ObjExcel.Columns.AutoFit()

        Catch err As Exception
            MsgBox(err.Message)
        Finally
            'ObjW.Close()
            'ObjW = Nothing
            'ObjExcel.Quit()
            'Runtime.InteropServices.Marshal.ReleaseComObject(ObjExcel)
            'ObjExcel = Nothing
        End Try

    End Sub
    Sub GenerarExcelInventario()
        Try

            Dim anio As Integer = Convert.ToInt32(cboInventarioAnio.SelectedValue)
            Dim mes As Integer = Convert.ToInt32(cboInventarioMes.SelectedValue)

            Dim ds As DataSet = CargaPesoHumNG.ObtenerInventario(anio, mes)

            Dim rutaPlantilla As String = RutaReporteERP & "PLANTILLAPRODUCCIONINVENTARIO.xlsx" ' Application.StartupPath + "\PROD_FORMATO_CRUDO.xlsx"
            Dim nombreArchivo As String = "FORMATO_PRODUCCION_INVENTARIO_" & DateTime.Now.ToString("_yyyyMMddHHmmss") & ".xlsx"

            Dim rutaDestino As String = Application.StartupPath & "\" & nombreArchivo

            If File.Exists(rutaPlantilla) Then

                File.Copy(rutaPlantilla, rutaDestino)

            End If

            Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
            Dim ObjW As Microsoft.Office.Interop.Excel.Workbook

            ObjExcel = New Microsoft.Office.Interop.Excel.Application
            ObjW = ObjExcel.Workbooks.Open(rutaDestino)

            Dim objHojaExcelHornoG As Microsoft.Office.Interop.Excel.Worksheet = ObjW.Worksheets(1)
            Dim rowNumber As Integer = 0
            Dim rowEnd As Integer = 0

            With objHojaExcelHornoG
                .Activate()

                .Name = cboMes.Text

                .Range("E6").Value = cboMes.Text
                .Range("H6").Value = "," & cboAnio.Text

                'rowNumber = 12
                'rowEnd = 26

                'For index As Integer = rowNumber To rowEnd

                '    '.Range("B" & index.ToString()).Value = ""
                '    '.Range("C" & index.ToString()).Value = ""
                '    '.Range("F" & index.ToString()).Value = ""
                '    .Range("G" & index.ToString()).Value = ""
                '    .Range("H" & index.ToString()).Value = ""
                '    .Range("I" & index.ToString()).Value = ""
                '    .Range("J" & index.ToString()).Value = ""
                '    .Range("K" & index.ToString()).Value = ""
                '    .Range("L" & index.ToString()).Value = ""
                'Next

                rowNumber = 12
                For Each row As DataRow In ds.Tables(0).Rows
                    .Range("B" & rowNumber.ToString()).Value = Convert.ToString(row("CODIGO"))
                    .Range("C" & rowNumber.ToString()).Value = Convert.ToString(row("NOMBRE"))
                    .Range("G" & rowNumber.ToString()).Value = Convert.ToString(row("UTILIZADOS"))
                    .Range("H" & rowNumber.ToString()).Value = Convert.ToString(row("UNID_UTILIZADOS"))
                    .Range("I" & rowNumber.ToString()).Value = Convert.ToString(row("ALMACENADOS"))
                    .Range("J" & rowNumber.ToString()).Value = Convert.ToString(row("UNID_ALMACENADOS"))
                    .Range("K" & rowNumber.ToString()).Value = Convert.ToString(row("PRODUCCION"))
                    rowNumber += 1
                Next

                rowNumber = 49
                rowNumber = rowNumber + ds.Tables(1).Rows.Count

                For index As Integer = 49 To 52

                    .Range("B" & index.ToString()).Value = ""
                    .Range("C" & index.ToString()).Value = ""
                    .Range("F" & index.ToString()).Value = "----"
                    .Range("H" & index.ToString()).Value = "----"
                    .Range("J" & index.ToString()).Value = "----"
                    .Range("L" & index.ToString()).Value = "----"

                Next

                rowNumber = 49

                For Each row As DataRow In ds.Tables(1).Rows

                    .Range("B" & rowNumber.ToString()).Value = Convert.ToString(row("CODIGO"))
                    .Range("C" & rowNumber.ToString()).Value = Convert.ToString(row("NOMBRE"))
                    .Range("F" & rowNumber.ToString()).Value = Convert.ToString(row("BASE_HUMEDA"))
                    .Range("H" & rowNumber.ToString()).Value = Convert.ToString(row("BASE_SECA"))
                    .Range("J" & rowNumber.ToString()).Value = Convert.ToString(row("UTILIZADOS"))
                    .Range("K" & rowNumber.ToString()).Value = Convert.ToString(row("UNID_UTILIZADOS"))
                    .Range("L" & rowNumber.ToString()).Value = Convert.ToString(row("ALMACENADOS"))
                    .Range("M" & rowNumber.ToString()).Value = Convert.ToString(row("UNID_ALMACENADOS"))
                    rowNumber += 1
                Next

            End With

            Dim objExcelHornoMultiple As Microsoft.Office.Interop.Excel.Worksheet = ObjW.Worksheets(4)
            rowNumber = 0
            rowEnd = 0

            With objHojaExcelHornoG
                .Activate()

                '.Name = cboMes.Text

                .Range("D6").Value = cboMes.Text
                .Range("E6").Value = "," & cboAnio.Text

                rowNumber = 10

                For Each row As DataRow In ds.Tables(2).Rows
                    .Range("A" & rowNumber.ToString()).Value = Convert.ToString(row("CODIGO"))
                    .Range("B" & rowNumber.ToString()).Value = Convert.ToString(row("NOMBRE"))
                    .Range("D" & rowNumber.ToString()).Value = Convert.ToString(row("UTILIZADOS"))
                    .Range("E" & rowNumber.ToString()).Value = Convert.ToString(row("UNID_UTILIZADOS"))
                    .Range("F" & rowNumber.ToString()).Value = Convert.ToString(row("ALMACENADOS"))
                    .Range("G" & rowNumber.ToString()).Value = Convert.ToString(row("UNID_ALMACENADOS"))
                    .Range("H" & rowNumber.ToString()).Value = Convert.ToString(row("PRODUCIDOS"))
                    .Range("I" & rowNumber.ToString()).Value = Convert.ToString(row("UNID_PRODUCIDOS"))
                    rowNumber += 1
                Next

            End With

            ObjExcel.Visible = True
            'ObjExcel.Columns.AutoFit()

        Catch err As Exception
            MsgBox(err.Message)
        Finally
            'ObjW.Close()
            'ObjW = Nothing
            'ObjExcel.Quit()
            'Runtime.InteropServices.Marshal.ReleaseComObject(ObjExcel)
            'ObjExcel = Nothing
        End Try

    End Sub
    Public Sub Excel()
        Try

            Select Case TabContenedor.SelectedTab.Key
                Case "T05"
                    GenerarExcelResumenHornoMultiple()
                Case "T04"
                    GenerarExcelResumenClinkerHornoGiratorio()
                Case "T03"
                    GenerarExcelResumenCrudo()

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Procesar"
    Public Sub Procesar()

        Dim anio As Integer = 0
        Dim mes As Integer = 0
        Dim oReporte As New ETClinker_Reporte

        If TabContenedor.SelectedTab.Key = "T04" Then
            ' creamos la cabecera
            anio = Convert.ToInt32(cboAnioHornoGiratorio.SelectedValue)
            mes = Convert.ToInt32(cboMesHornoGiratorio.SelectedValue)

            oReporte.Anio = anio
            oReporte.Mes = mes
            oReporte.Tipo = HornoGiratorio

            oReporte.I7 = 0
            oReporte.K7 = nupK7.Value
            oReporte.L7 = 0
            oReporte.M7 = nupM7.Value
            oReporte.N7 = nupN7.Value
            oReporte.O7 = nupO7.Value
            oReporte.P7 = nupP7.Value
            oReporte.Q7 = 0
            oReporte.R7 = nupR7.Value
            oReporte.S7 = 0

            If CargaPesoHumNG.ValidarResumenCLinker(oReporte) > 0 Then
                MsgBox("EL Resumen para Horno Giratorio de: " & NombreMes(mes) & " ya ha sido creado")
            Else
                oReporte = CargaPesoHumNG.GenerarResumenHorno(oReporte, User_Sistema, 1)

                If oReporte.idResumen > 0 Then
                    MsgBox("Se generó el resumen para Horno Giratorio de " & NombreMes(mes) & " mes con exito")
                Else
                    MsgBox("Ocurrio un error al registrar el resumen para Horno Giratorio de " & NombreMes(mes) & " ")
                End If
            End If

            oReporte = CargaPesoHumNG.ObtenerResumenHorno(oReporte)
            CargarResumenHornoGiratorio(oReporte)
        End If

        If TabContenedor.SelectedTab.Key = "T05" Then

            anio = Convert.ToInt32(cboAnioHornoMultiple.SelectedValue)
            mes = Convert.ToInt32(cboMesHornoMultiple.SelectedValue)

            oReporte.Anio = anio
            oReporte.Mes = mes
            oReporte.Tipo = HornoMultiple

            oReporte.I7 = nupI7.Value
            oReporte.K7 = nupK7.Value
            oReporte.L7 = nupL7.Value
            oReporte.M7 = nupM7.Value
            oReporte.N7 = 0
            oReporte.O7 = 0
            oReporte.P7 = nupP7.Value
            oReporte.Q7 = nupQ7.Value
            oReporte.R7 = nudR8.Value
            oReporte.S7 = nudS8.Value

            If CargaPesoHumNG.ValidarResumenCLinker(oReporte) > 0 Then
                MsgBox("EL Resumen para Horno Multiple de: " & NombreMes(mes) & " ya ha sido creado")
            Else
                oReporte = CargaPesoHumNG.GenerarResumenHorno(oReporte, User_Sistema, 1)

                If oReporte.idResumen > 0 Then
                    MsgBox("Se generó el resumen para Horno Multiple de " & NombreMes(mes) & " mes con exito")
                Else
                    MsgBox("Ocurrio un error al registrar el resumen para Horno Multiple de " & NombreMes(mes) & " mes con exito")
                End If
            End If

            oReporte = CargaPesoHumNG.ObtenerResumenHorno(oReporte)
            CargarResumenHornoMultiple(oReporte)
        End If


    End Sub
#End Region

#Region "Comun"
    Function CrearTabla() As DataTable
        Dim dt As New DataTable("PESOS_CRUDOS")

        dt.Columns.Add("ID", GetType(String))
        dt.Columns.Add("HORA", GetType(String))
        dt.Columns.Add("FECHA", GetType(String))
        dt.Columns.Add("PESO_CALIZA", GetType(Decimal))
        dt.Columns.Add("PESO_SILICE", GetType(Decimal))
        dt.Columns.Add("PESO_CAOLIN", GetType(Decimal))
        dt.Columns.Add("TRAMA", GetType(String))

        Return dt
    End Function
    Function NombreMes(ByVal nro As Integer) As String
        Dim cadena As String = String.Empty
        Select Case nro
            Case 1 : cadena = "ENERO"
            Case 2 : cadena = "FEBRERO"
            Case 3 : cadena = "MARZO"
            Case 4 : cadena = "ABRIL"
            Case 5 : cadena = "MAYO"
            Case 6 : cadena = "JUNIO"
            Case 7 : cadena = "JULIO"
            Case 8 : cadena = "AGOSTO"
            Case 9 : cadena = "SETIEMBRE"
            Case 10 : cadena = "OCTUBRE"
            Case 11 : cadena = "NOVIEMBRE"
            Case 12 : cadena = "DICIEMBRE"
        End Select
        Return cadena
    End Function

#End Region

    Private Sub btnGenerarInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarInventario.Click
        GenerarExcelInventario()
    End Sub


    Private Sub ugResHornoGiratorio_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugResHornoGiratorio.AfterCellUpdate
        If e.Cell.Column.Key = "De" Or e.Cell.Column.Key = "A" Then

            Dim inicio As DateTime = Convert.ToDateTime(e.Cell.Row.Cells("De").Value)
            Dim fin As DateTime = Convert.ToDateTime(e.Cell.Row.Cells("A").Value)

            Dim total As DateTime = fin.AddMinutes(-1 * inicio.TimeOfDay.TotalMinutes)

            If total.TimeOfDay.TotalMinutes = 0 Then 'las fechas eran iguales 
                e.Cell.Row.Cells("TotalHoras").Value = "24:00"
            Else
                e.Cell.Row.Cells("TotalHoras").Value = total.ToString("HH:mm")
            End If

        End If
    End Sub

    Private Sub ugResHornoMultiple_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugResHornoMultiple.AfterCellUpdate
        If e.Cell.Column.Key = "De" Or e.Cell.Column.Key = "A" Then

            Dim inicio As DateTime = Convert.ToDateTime(e.Cell.Row.Cells("De").Value)
            Dim fin As DateTime = Convert.ToDateTime(e.Cell.Row.Cells("A").Value)
            Dim total As DateTime = fin.AddMinutes(-1 * inicio.TimeOfDay.TotalMinutes)

            If total.TimeOfDay.TotalMinutes = 0 Then 'las fechas eran iguales 
                e.Cell.Row.Cells("TotalHoras").Value = "24:00"
            Else
                e.Cell.Row.Cells("TotalHoras").Value = total.ToString("HH:mm")
            End If

        End If
    End Sub
End Class