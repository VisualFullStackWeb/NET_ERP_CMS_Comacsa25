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
Imports Infragistics.Win.UltraWinTree
Imports Infragistics.Win.UltraWinEditors
Public Class FrmTrazabilidadCosteo
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
    Private Sub FrmTrazabilidadCosteo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtayo.Value = Year(Now.Date)
        Me.cmbMes.Value = Month(Now.Date)
    End Sub
    Sub Procesar()
        Dim dtDatos As New DataTable
        dtDatos = New DataTable
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        dtDatos = _objNegocio.LISTA_TRAZA_COSTO(_objEntidad)
        Call CargarUltraGridxBinding(Me.gridCostos, Source1, dtDatos)
    End Sub
    Dim codProducto As String = ""
    Dim nombre_columna As String
    Private Sub gridCostos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridCostos.DoubleClickRow
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            nombre_columna = gridCostos.ActiveRow.Cells(gridCostos.ActiveCell.Column.Index).Column.Key
            codProducto = gridCostos.ActiveRow.Cells("COD_PROD").Value.ToString.Trim
            'MsgBox(nombre_columna)
            Select Case nombre_columna
                Case "MOLIENDA"
                    Tab1.Tabs("T02").Visible = True
                    Tab1.Tabs("T02").Selected = True
                    CalculoMolienda(0, 0)
                Case "GASTOSADM"
                    Tab1.Tabs("T02").Visible = True
                    Tab1.Tabs("T02").Selected = True
                    CalculoMolienda(1, 0)
                Case "GASTOSVENTA"
                    Tab1.Tabs("T02").Visible = True
                    Tab1.Tabs("T02").Selected = True
                    CalculoMolienda(0, 1)
                Case "CHANCADO"
                    Tab1.Tabs("T03").Visible = True
                    Tab1.Tabs("T03").Selected = True
                    CalculoChancado(0, 0)
                Case "MINERAL"
                    Tab1.Tabs("T04").Visible = True
                    Tab1.Tabs("T04").Selected = True
                    CalculoMineral(0, 0)
                Case Else

            End Select
        Catch ex As Exception

        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
        
    End Sub

    Sub CalculoMolienda(ByVal FLGADM As Int32, ByVal FLGVENTA As Int32)
        Label1.Text = "      PRODUCTO: " & codProducto & " - " & gridCostos.ActiveRow.Cells("PRODUCTO").Value.ToString.Trim
        'txttoneladas.Text = CDbl(gridCostos.ActiveRow.Cells("TON").Value).ToString("#,##0.00")
        'txtcostoxton.Text = CDbl(gridCostos.ActiveRow.Cells(nombre_columna).Value).ToString("#,##0.00")
        Dim toneladas As Double = CDbl(gridCostos.ActiveRow.Cells("TON").Value).ToString("#,##0.00")
        txttoneladas.Text = CDbl(toneladas).ToString("#,##0.00")


        Dim dtDatos As New DataSet
        dtDatos = New DataSet
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        _objEntidad.CodProducto = codProducto
        _objEntidad.flgADM = FLGADM
        _objEntidad.flgVENTA = FLGVENTA
        dtDatos = _objNegocio.LISTA_TRAZA_COSTO_MOL(_objEntidad)
        If dtDatos.Relations.Item("RelTipoAnalisisM") Is Nothing Then
            Dim RelTipoAnalisis As New DataRelation("RelTipoAnalisisM", dtDatos.Tables("Table").Columns("ENLACE"), dtDatos.Tables("Table1").Columns("ENLACE"))
            dtDatos.Relations.Add(RelTipoAnalisis)
        End If
        UltraGrid1.DataSource = dtDatos
        UltraGrid1.DataBind()

        'Call CargarUltraGridxBinding(Me.UltraGrid1, Source2, dtDatos)
        'Call CargarUltraGridxBinding(Me.UltraGrid2, Source3, dtDatos)
        Dim costoTotal As Double = 0
        Dim costoVariable As Double = 0
        Dim costoFijo As Double = 0
        For I As Int32 = 0 To UltraGrid1.Rows.Count - 1
            costoTotal = costoTotal + UltraGrid1.Rows(I).Cells("TOT_COSTO_FIJO").Value + UltraGrid1.Rows(I).Cells("TOT_COSTO_VAR").Value
            'If UltraGrid1.Rows(I).Cells("FIJOVAR").Value = "F" Then
            costoFijo = costoFijo + UltraGrid1.Rows(I).Cells("TOT_COSTO_FIJO").Value
            'End If
            'If UltraGrid1.Rows(I).Cells("FIJOVAR").Value = "V" Then
            costoVariable = costoVariable + UltraGrid1.Rows(I).Cells("TOT_COSTO_VAR").Value
            'End If
        Next
        'txtcostototal.Text = Math.Round(CDbl(costoTotal), 2).ToString("#,##0.00")
        Dim costoxtonVar As Double = costoVariable / toneladas
        Dim costoxtonFIJO As Double = costoFijo / toneladas
        Dim costoxton As Double = costoTotal / toneladas
        'txtcostoxton2.Text = CDbl(gridCostos.ActiveRow.Cells(nombre_columna).Value).ToString("#,##0.00")
        txtcostoVAR2.Text = Math.Round(CDbl(costoVariable), 2).ToString("#,##0.00")
        txtcostoFIJO2.Text = Math.Round(CDbl(costoFijo), 2).ToString("#,##0.00")
        txtcostototal.Text = Math.Round(CDbl(costoTotal), 2).ToString("#,##0.00")

        txtcostoxtonvar3.Text = Math.Round(CDbl(costoxtonVar), 2).ToString("#,##0.00")
        txtcostoxtonfijo3.Text = Math.Round(CDbl(costoxtonFIJO), 2).ToString("#,##0.00")
        txtcostoxton.Text = Math.Round(CDbl(costoxton), 2).ToString("#,##0.00")
    End Sub

    Sub CalculoChancado(ByVal FLGADM As Int32, ByVal FLGVENTA As Int32)
        Label4.Text = "      PRODUCTO: " & codProducto & " - " & gridCostos.ActiveRow.Cells("PRODUCTO").Value.ToString.Trim
        Dim toneladas As Double = CDbl(gridCostos.ActiveRow.Cells("TON").Value).ToString("#,##0.00")
        txttoneladas2.Text = CDbl(toneladas).ToString("#,##0.00")

        Dim dtDatos As New DataTable
        dtDatos = New DataTable
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        _objEntidad.CodProducto = codProducto
        _objEntidad.flgADM = FLGADM
        _objEntidad.flgVENTA = FLGVENTA
        dtDatos = _objNegocio.LISTA_TRAZA_COSTO_CH(_objEntidad)
        Call CargarUltraGridxBinding(Me.UltraGrid2, Source3, dtDatos)
        Dim costoTotal As Double = 0
        Dim costoVariable As Double = 0
        Dim costoFijo As Double = 0
        For I As Int32 = 0 To UltraGrid2.Rows.Count - 1
            costoTotal = costoTotal + UltraGrid2.Rows(I).Cells("COSTOXTON_TOTAL_MATPRIMA").Value
            If UltraGrid2.Rows(I).Cells("FIJOVAR").Value = "F" Then
                costoFijo = costoFijo + UltraGrid2.Rows(I).Cells("COSTOXTON_TOTAL_MATPRIMA").Value
            End If
            If UltraGrid2.Rows(I).Cells("FIJOVAR").Value = "V" Then
                costoVariable = costoVariable + UltraGrid2.Rows(I).Cells("COSTOXTON_TOTAL_MATPRIMA").Value
            End If
        Next
        Dim costoxtonVar As Double = costoVariable / toneladas
        Dim costoxtonFIJO As Double = costoFijo / toneladas
        Dim costoxton As Double = costoTotal / toneladas
        'txtcostoxton2.Text = CDbl(gridCostos.ActiveRow.Cells(nombre_columna).Value).ToString("#,##0.00")
        txtcostoVAR.Text = Math.Round(CDbl(costoVariable), 2).ToString("#,##0.00")
        txtcostoFIJO.Text = Math.Round(CDbl(costoFijo), 2).ToString("#,##0.00")
        txtcostototal2.Text = Math.Round(CDbl(costoTotal), 2).ToString("#,##0.00")

        txtcostoxtonvar2.Text = Math.Round(CDbl(costoxtonVar), 2).ToString("#,##0.00")
        txtcostoxtonfijo2.Text = Math.Round(CDbl(costoxtonFIJO), 2).ToString("#,##0.00")
        txtcostoxton2.Text = Math.Round(CDbl(costoxton), 2).ToString("#,##0.00")
    End Sub

    Sub CalculoMineral(ByVal FLGADM As Int32, ByVal FLGVENTA As Int32)
        Label5.Text = "      PRODUCTO: " & codProducto & " - " & gridCostos.ActiveRow.Cells("PRODUCTO").Value.ToString.Trim
        'txttoneladas3.Text = CDbl(gridCostos.ActiveRow.Cells("TON").Value).ToString("#,##0.00")
        'txtcostoxton3.Text = CDbl(gridCostos.ActiveRow.Cells(nombre_columna).Value).ToString("#,##0.00")
        Dim toneladas As Double = CDbl(gridCostos.ActiveRow.Cells("TON").Value).ToString("#,##0.00")
        txttoneladas3.Text = CDbl(toneladas).ToString("#,##0.00")

        Dim dtDatos As New DataSet
        dtDatos = New DataSet
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        _objEntidad.CodProducto = codProducto
        dtDatos = _objNegocio.LISTA_TRAZA_COSTO_MIN(_objEntidad)

        If dtDatos.Relations.Item("RelTipoAnalisis") Is Nothing Then
            Dim RelTipoAnalisis As New DataRelation("RelTipoAnalisis", dtDatos.Tables("Table").Columns("CODRUMA"), dtDatos.Tables("Table1").Columns("CODRUMA"))
            dtDatos.Relations.Add(RelTipoAnalisis)
        End If
        gridMineral.DataSource = dtDatos
        gridMineral.DataBind()

        Dim costoxTon As Double = 0
        Dim costoxTonVar As Double = 0
        Dim costoxTonFijo As Double = 0
        Dim tonelada_consumida As Double = 0 '= CDbl(gridCostos.ActiveRow.Cells("TONCONSUMIDA").Value).ToString("#,##0.00")
        For I As Int32 = 0 To dtDatos.Tables(1).Rows.Count - 1
            tonelada_consumida = dtDatos.Tables(1).Rows(I)(7)
            costoxTon = costoxTon + (dtDatos.Tables(1).Rows(I)(6)) * tonelada_consumida
            If dtDatos.Tables(1).Rows(I)("FIJOVAR") = "F" Then
                costoxTonFijo = costoxTonFijo + (dtDatos.Tables(1).Rows(I)(6)) * tonelada_consumida
            End If
            If dtDatos.Tables(1).Rows(I)("FIJOVAR") = "V" Then
                costoxTonVar = costoxTonVar + (dtDatos.Tables(1).Rows(I)(6)) * tonelada_consumida
            End If
        Next
        txtcostoxtonvar1.Text = CDbl(costoxTonVar / toneladas).ToString("#,##0.00")
        txtcostoxtonfijo1.Text = CDbl(costoxTonFijo / toneladas).ToString("#,##0.00")
        txtcostoxton3.Text = CDbl(costoxTon / toneladas).ToString("#,##0.00")
        'gridMineral.DataSource = dtDatos
        'Call CargarUltraGridxBinding(Me.UltraGrid2, Source3, dtDatos)
        'Dim costoTotal As Double = 0
        'For I As Int32 = 0 To UltraGrid2.Rows.Count - 1
        '    costoTotal = costoTotal + UltraGrid2.Rows(I).Cells("TOT_COSTO").Value
        'Next
        'txtcostototal2.Text = Math.Round(CDbl(costoTotal), 2).ToString("#,##0.00")
    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged
        If Tab1.Tabs("T01").Selected = True Then
            Tab1.Tabs("T02").Visible = False
            Tab1.Tabs("T03").Visible = False
            Tab1.Tabs("T04").Visible = False
        End If
    End Sub

    Private Sub UltraGrid1_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        Try
            With e.Layout
                .Bands(0).Columns("EQUIPO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                .Bands(0).Columns("EQUIPO").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                .Bands(0).Columns("TON").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                .Bands(0).Columns("TON").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click, Label3.Click
        Me.Cursor = Cursors.Hand
        Tab1.Tabs("T01").Selected = True
    End Sub

    Private Sub Label2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.MouseEnter, Label3.MouseEnter, Label6.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave, Label3.MouseLeave, Label6.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub gridMineral_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridMineral.InitializeLayout
        Try
            With e.Layout
                .Bands(1).Columns("TIPO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                .Bands(1).Columns("TIPO").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                .Bands(1).Columns("CODRUMA").Hidden = True
                .Bands(1).Columns("DESCRIPCION").CellActivation = Activation.ActivateOnly
                .Bands(1).Columns("COSTO X TON").CellActivation = Activation.ActivateOnly
                .Bands(1).Columns("COSTO X TON").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("COSTO TOTAL").CellActivation = Activation.ActivateOnly
                .Bands(1).Columns("COSTO TOTAL").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("TON").CellActivation = Activation.ActivateOnly
                '.Bands(1).Columns("TON").Hidden = True
                '.Bands(0).Columns("TON").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                '.Bands(0).Columns("TON").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Me.Cursor = Cursors.Hand
        Tab1.Tabs("T01").Selected = True
    End Sub

    Private Sub UltraGrid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid2.InitializeLayout
        Try
            With e.Layout
                .Bands(0).Columns("EQUIPO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                .Bands(0).Columns("EQUIPO").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                .Bands(0).Columns("RUMA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                .Bands(0).Columns("RUMA").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                .Bands(0).Columns("TON_MATPRIMA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                .Bands(0).Columns("TON_MATPRIMA").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub Reporte()
        If Tab1.Tabs("T02").Selected = True Then ' MOLIENDA
            Reporte_Molienda("MOLIENDA PRODUCTO: " & codProducto & " - " & gridCostos.ActiveRow.Cells("PRODUCTO").Value.ToString.Trim)
        End If
        If Tab1.Tabs("T03").Selected = True Then ' CHANCADO
            Reporte_Chancado("CHANCADO PRODUCTO: " & codProducto & " - " & gridCostos.ActiveRow.Cells("PRODUCTO").Value.ToString.Trim)
        End If
        If Tab1.Tabs("T04").Selected = True Then ' MINERAL
            Reporte_Mineral("MINERAL PRODUCTO: " & codProducto & " - " & gridCostos.ActiveRow.Cells("PRODUCTO").Value.ToString.Trim)
        End If
    End Sub

    Sub Reporte_Mineral(ByVal titulo As String)
        Dim rpta As Long
        Dim ruta As String = ""

        ruta = Application.StartupPath & "\DETALLE_TRAZA_MINERAL" & ".xls"

        Dim archivoexcel As String = Trim(ruta)

        Try
            If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If
            Me.UltraGridExcelExporter1.Export(gridMineral, ruta)
            ''poner cabecera

            Call poner_cabecera_archivo_excel(archivoexcel, titulo)

            MessageBox.Show("Exportado: " & Chr(13) & ruta, "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Abrir_Archivo(ruta)

        Catch ex As Exception
            'MessageBox.Show("Ruta Especificada No Existe", "Invalid File Name")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Reporte_Chancado(ByVal titulo As String)
        Dim rpta As Long
        Dim ruta As String = ""

        ruta = Application.StartupPath & "\DETALLE_TRAZA_CHANCADO" & ".xls"

        Dim archivoexcel As String = Trim(ruta)

        Try
            If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If
            Me.UltraGridExcelExporter1.Export(UltraGrid2, ruta)
            ''poner cabecera

            Call poner_cabecera_archivo_excel(archivoexcel, titulo)

            MessageBox.Show("Exportado: " & Chr(13) & ruta, "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Abrir_Archivo(ruta)

        Catch ex As Exception
            'MessageBox.Show("Ruta Especificada No Existe", "Invalid File Name")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Reporte_Molienda(ByVal titulo As String)
        Dim rpta As Long
        Dim ruta As String = ""

        ruta = Application.StartupPath & "\DETALLE_TRAZA_MOLIENDA" & ".xls"

        Dim archivoexcel As String = Trim(ruta)

        Try
            If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If
            Me.UltraGridExcelExporter1.Export(UltraGrid11, ruta)
            ''poner cabecera

            Call poner_cabecera_archivo_excel(archivoexcel, titulo)

            MessageBox.Show("Exportado: " & Chr(13) & ruta, "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Abrir_Archivo(ruta)

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
            h_hoja.Range("A2:L2").Merge()
            h_hoja.Range("A2:E2").Font.Bold = True
            h_hoja.Range("A2:DG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = titulo
            h_hoja.Range("B1:L1").ColumnWidth = 11
            h_hoja.Range("B1:L10000").NumberFormat = "#,##0.000"
            h_hoja.Range("B1:L10000").RowHeight = 15

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