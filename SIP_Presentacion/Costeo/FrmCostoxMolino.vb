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
Public Class FrmCostoxMolino
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

    Private Sub FrmCostoxMolino_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
        cmbMes.Value = Now.Date.Month
        rdbmolino.Checked = True
    End Sub
    Sub procesar()
        If rdbmolino.Checked = False And rdbruma.Checked = False And rdbchancadoras.Checked = False Then
            MsgBox("Debe seleccionar un opción", MsgBoxStyle.Information, msgComacsa)
            Exit Sub
        End If
        If rdbmolino.Checked = True Then
            molinos()
        End If
        If rdbruma.Checked = True Then
            rumas()
        End If
        If rdbchancadoras.Checked = True Then
            chancadoras()
        End If
    End Sub

    Sub molinos()
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
            dsDatos = _objNegocio.Costo_COSTOXMOLINO(_objEntidad)
            If dsDatos.Relations.Item("COD_EQUIPO") Is Nothing Then
                Dim RelTipoAnalisis As New DataRelation("RelTipoAnalisis", dsDatos.Tables("Table").Columns("COD_EQUIPO"), dsDatos.Tables("Table1").Columns("COD_EQUIPO"))
                dsDatos.Relations.Add(RelTipoAnalisis)
            End If
            gridCostos.DataSource = dsDatos
            gridCostos.DataBind()
            'Call CargarUltraGridxBinding(Me.gridCostos, Source1, dsDatos.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub rumas()
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
            dsDatos = _objNegocio.Costo_COSTOXRUMA(_objEntidad)
            If dsDatos.Relations.Item("COD_RUMA") Is Nothing Then
                Dim RelTipoAnalisis As New DataRelation("RelTipoAnalisis", dsDatos.Tables("Table").Columns("COD_RUMA"), dsDatos.Tables("Table1").Columns("COD_RUMA"))
                dsDatos.Relations.Add(RelTipoAnalisis)
            End If
            gridCostos.DataSource = dsDatos
            gridCostos.DataBind()
            'Call CargarUltraGridxBinding(Me.gridCostos, Source1, dsDatos.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub chancadoras()
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
            dsDatos = _objNegocio.Costo_COSTOXCHANCADORA(_objEntidad)
            If dsDatos.Relations.Item("COD_EQUIPO") Is Nothing Then
                Dim RelTipoAnalisis As New DataRelation("RelTipoAnalisis", dsDatos.Tables("Table").Columns("COD_EQUIPO"), dsDatos.Tables("Table1").Columns("COD_EQUIPO"))
                dsDatos.Relations.Add(RelTipoAnalisis)
            End If
            gridCostos.DataSource = dsDatos
            gridCostos.DataBind()
            'Call CargarUltraGridxBinding(Me.gridCostos, Source1, dsDatos.Tables(0))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        Reporte()
    End Sub

    Sub Reporte()
        Dim rpta As Long
        Dim ruta As String = ""

        If rdbmolino.Checked = True Then
            ruta = Application.StartupPath & "\COSTOXMOLINO " & ".xls"
        End If
        If rdbruma.Checked = True Then
            ruta = Application.StartupPath & "\COSTOXRUMA " & ".xls"
        End If
        If rdbchancadoras.Checked = True Then
            ruta = Application.StartupPath & "\COSTOXCHANCADORA " & ".xls"
        End If

        Dim archivoexcel As String = Trim(ruta)

        Try
            If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If
            Me.UltraGridExcelExporter1.Export(gridCostos, ruta)

            ''poner cabecera
            Dim titulo As String
            If rdbmolino.Checked = True Then
                titulo = "COSTOS POR MOLINO"
            ElseIf rdbchancadoras.Checked = True Then
                titulo = "COSTOS POR CHANCADORA"
            Else
                titulo = "COSTOS POR RUMA"
            End If
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
            'h_hoja.Range("A1:AZ3").Insert()
            h_hoja.Range("1:1").Insert()
            h_hoja.Range("2:2").Insert()
            'h_hoja.Range("B1:BZ3").Insert()
            h_hoja.Range("A2:L2").Merge()
            h_hoja.Range("A2:E2").Font.Bold = True
            h_hoja.Range("A2:DG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = titulo
            'h_hoja.Range("A1").ColumnWidth = 9.15
            'h_hoja.Range("B1").ColumnWidth = 39.3
            'h_hoja.Range("C1").ColumnWidth = 38.45
            'h_hoja.Range("D1").ColumnWidth = 29.15
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

    Private Sub gridCostos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridCostos.InitializeLayout
        Try
            With e.Layout
                '.Bands(1).Columns("TIPO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                '.Bands(1).Columns("TIPO").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                .Bands(1).Columns("COD_EQUIPO").Hidden = True
                '.Bands(1).Columns("DESCRIPCION").CellActivation = Activation.ActivateOnly
                '.Bands(1).Columns("COSTO X TON").CellActivation = Activation.ActivateOnly
                '.Bands(1).Columns("COSTO X TON").CellAppearance.TextHAlign = HAlign.Right
                '.Bands(1).Columns("COSTO TOTAL").CellActivation = Activation.ActivateOnly
                '.Bands(1).Columns("COSTO TOTAL").CellAppearance.TextHAlign = HAlign.Right
                '.Bands(1).Columns("TON").CellActivation = Activation.ActivateOnly
                .Bands(1).Columns("TOT_VAR_DIR").Format = "#,##0.000"
                .Bands(1).Columns("TOT_VAR_DIR").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("TOT_VAR_IND").Format = "#,##0.000"
                .Bands(1).Columns("TOT_VAR_IND").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("TOT_FIJ_DIR").Format = "#,##0.000"
                .Bands(1).Columns("TOT_FIJ_DIR").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("TOT_FIJ_IND").Format = "#,##0.000"
                .Bands(1).Columns("TOT_FIJ_IND").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("TOT_COSTO").Format = "#,##0.000"
                .Bands(1).Columns("TOT_COSTO").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("TON_VAR_DIR").Format = "#,##0.000"
                .Bands(1).Columns("TON_VAR_DIR").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("TON_VAR_IND").Format = "#,##0.000"
                .Bands(1).Columns("TON_VAR_IND").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("TON_FIJ_DIR").Format = "#,##0.000"
                .Bands(1).Columns("TON_FIJ_DIR").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("TON_FIJ_IND").Format = "#,##0.000"
                .Bands(1).Columns("TON_FIJ_IND").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("TON_COSTO").Format = "#,##0.000"
                .Bands(1).Columns("TON_COSTO").CellAppearance.TextHAlign = HAlign.Right
                .Bands(1).Columns("EQUIPO").Hidden = True
                .Bands(1).Columns("TONPRODUCTO").Hidden = True
                .Bands(1).Columns("TONPRODUCTO_TOTAL").Hidden = True
                If rdbmolino.Checked = True Then
                    .Bands(0).Columns("COD_RUMA").Hidden = True
                    .Bands(0).Columns("RUMA").Hidden = True
                    .Bands(0).Columns("COD_EQUIPO").Hidden = True
                    .Bands(0).Columns("EQUIPO").Hidden = False
                    .Bands(0).Columns("EQUIPO").Width = 200
                    .Bands(1).Columns("COD_EQUIPO").Hidden = True
                    .Bands(1).Columns("EQUIPO").Hidden = True
                End If
                If rdbruma.Checked = True Then
                    .Bands(1).Columns("COD_RUMA").Hidden = True
                    .Bands(0).Columns("COD_RUMA").Hidden = True
                    .Bands(0).Columns("RUMA").Hidden = False
                    .Bands(0).Columns("COD_EQUIPO").Hidden = True
                    .Bands(0).Columns("EQUIPO").Hidden = True
                    .Bands(0).Columns("RUMA").Width = 200
                    .Bands(1).Columns("COD_EQUIPO").Hidden = True
                    .Bands(1).Columns("EQUIPO").Hidden = False
                End If
                If rdbchancadoras.Checked = True Then
                    .Bands(0).Columns("COD_RUMA").Hidden = True
                    .Bands(0).Columns("RUMA").Hidden = True
                    .Bands(0).Columns("COD_EQUIPO").Hidden = True
                    .Bands(0).Columns("EQUIPO").Hidden = False
                    .Bands(0).Columns("EQUIPO").Width = 200
                    .Bands(1).Columns("COD_EQUIPO").Hidden = True
                    .Bands(1).Columns("EQUIPO").Hidden = True
                End If
                '.Bands(0).Columns("TON").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                '.Bands(0).Columns("TON").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            End With
        Catch ex As Exception

        End Try
    End Sub

End Class