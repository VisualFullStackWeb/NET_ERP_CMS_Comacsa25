Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Excel

Public Class frmCCuentaCorrientePersonal
    Public Ls_Permisos As New List(Of Integer)
    Dim Ls_Reporte As List(Of ETCuentaCorriente) = Nothing
    Private Sub frmCCuentaCorrientePersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub

    Private Sub Inicio()
        Txt1.Clear()
        Txt2.Clear()
        Txt3.Value = Year(Date.Now)
    End Sub

    Public Sub Buscar()
        Dim Personal As New frmBuscar
        Personal.Formulario = frmBuscar.eState.frm_PersonalTemp
        Personal.ShowDialog()
        Txt1.Text = Trim(Personal.Flag2 & "")
        Txt2.Text = Trim(Personal.Descripcion & "")
        Personal = Nothing
    End Sub

    Public Sub Procesar()

        If String.IsNullOrEmpty(Txt1.Text.Trim) Then
            MsgBox("Seleccione el Personal", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If String.IsNullOrEmpty(Txt2.Text.Trim) Then
            MsgBox("Seleccione el Personal", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If Val(Txt3.Value) < 1900 Then
            MsgBox("Ingrese un Periodo Válido", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If Val(Txt3.Value) > Year(Date.Now) Then
            MsgBox("El Periodo es Mayor al Año Actual", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Negocio.CtaCteContratista = New NGCtaCteContratista
        Entidad.MyLista = New ETMyLista
        Ls_Reporte = New List(Of ETCuentaCorriente)
        Entidad.MyLista = Negocio.ConsultasRRHH.Consultar_CtaCorrientePersonal(Txt1.Text.Trim, Txt3.Value)
        If Entidad.MyLista.Validacion Then
            Ls_Reporte = Entidad.MyLista.Ls_CtaCtePersonal
        End If

        Call CargarUltraGrid(Grid1, Ls_Reporte)

        For i As Integer = 0 To Grid1.Rows.Count - 1
            If Val(Grid1.Rows(i).Cells("Saldo").Value) < 0 Then
                Grid1.Rows(i).Cells("Saldo").Appearance.ForeColor = Color.Red
            End If
        Next

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

        Cursor = Cursors.Default
    End Sub

    Public Sub Excel()
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim Path As String = String.Empty
        Dim Archivo As String = String.Empty
        Dim Libro As New Infragistics.Excel.Workbook

        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay Datos que Exportar", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If
        'Reporte de Costeo de Minerales
        Path = My.Application.Info.DirectoryPath & "\Reportes RRHH\"

        Archivo = Path & "Reporte de Cta Cte del Personal - " & Txt1.Text & " DEL " & Txt3.Value & ".xls"
        UltraGridExcelExporter1.Export(Grid1, Libro, 2, 0)
        Libro.Worksheets(0).Name = "Cta Cte Personal"
        Libro.Worksheets(0).Rows(0).Cells(0).Value = UCase("Cia Minera Agregados Calcareos S.A.")
        Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Center
        Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(0).CellFormat.Font.Color = Color.Blue
        'Libro.Worksheets(0).Rows(0).CellFormat.FillPatternBackgroundColor = Color.Azure
        Libro.Worksheets(0).MergedCellsRegions.Add(0, 0, 0, 8).CellFormat.FillPatternForegroundColor = Color.Aqua
        Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Height = 350

        Libro.Worksheets(0).Rows(1).Cells(0).Value = "COD"
        Libro.Worksheets(0).Rows(1).Cells(1).Value = Txt1.Text.Trim
        Libro.Worksheets(0).Rows(1).Cells(2).Value = Txt3.Value
        Libro.Worksheets(0).Rows(1).Cells(2).CellFormat.Alignment = HorizontalCellAlignment.Center
        Libro.Worksheets(0).Rows(1).Cells(3).Value = Txt2.Text.Trim
        Libro.Worksheets(0).MergedCellsRegions.Add(1, 3, 1, 6)

        Libro.Worksheets(0).Rows(1).CellFormat.Font.Color = Color.Blue
        Libro.Worksheets(0).Rows(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        For i = 0 To Grid1.DisplayLayout.Bands(0).Columns.Count - 1
            Libro.Worksheets(0).Rows(1).Cells(i).CellFormat.FillPatternForegroundColor = Color.Azure
        Next

        Libro.Worksheets(0).Columns(3).CellFormat.FormatString = "#,##0.00"
        Libro.Worksheets(0).Columns(4).CellFormat.FormatString = "#,##0.00"
        Libro.Worksheets(0).Columns(5).CellFormat.FormatString = "#,##0.00"

        'Libro.Worksheets(0).DisplayOptions.PanesAreFrozen = True
        'Libro.Worksheets(0).DisplayOptions.FrozenPaneSettings.FrozenColumns = 1
        'Libro.Worksheets(0).DisplayOptions.FrozenPaneSettings.FrozenRows = 6
        Libro.Save(Archivo)
        Call Iniciar_Excel(Archivo)

        Libro = Nothing
    End Sub


    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "ID" OrElse uColumn.Key = "Detalle" _
                    OrElse uColumn.Key = "Debe" OrElse uColumn.Key = "Haber" _
                    OrElse uColumn.Key = "Saldo" OrElse uColumn.Key = "VoucherConta" _
                    OrElse uColumn.Key = "Voucher" OrElse uColumn.Key = "Fecha") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
End Class