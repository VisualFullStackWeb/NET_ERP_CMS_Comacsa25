Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Excel
Public Class FrmCConsultarResumenPeriodoCantera
    Public Ls_Permisos As New List(Of Integer)

    Sub LlenarPeriodo()
        Cbo2.Items.Clear()
        Dim i As Integer = 2010
        For i = 2010 To Year(Date.Now)
            Dim Dato As New Infragistics.Win.ValueListItem
            Dato.DisplayText = CStr(i)
            Dato.DataValue = CStr(i)
            Cbo2.Items.Add(Dato)
        Next
    End Sub

    Private Sub FrmCConsultarResumenPeriodoCantera_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub
    Private Sub FrmCConsultarResumenPeriodoCantera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia)
        Call LlenarPeriodo()
        Cbo4.Value = "1"
        If Tag = "105" Then
            TabCosteo.Tabs("T01").Text = "COSTEO DE MINERALES POR TIPO DE COSTO"
            Grid1.Visible = False
        Else
            Grid2.Visible = False
        End If
    End Sub

    Sub Configurar()
        Dim i As Integer
        Dim z As Integer

        If Grid2.Rows.Count > 0 Then
            Dim dt As New DataTable
            dt = Grid2.DataSource
            For i = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(i).Item(0)
                    Case 1
                        Grid2.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid2.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Green
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 2
                        Grid2.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid2.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Blue
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True

                                If z = 1 Then .FontData.Underline = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next

                    Case 24
                        Grid2.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid2.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Blue
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 25
                        Grid2.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid2.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.LightCoral
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                                If z = 1 Then .FontData.Underline = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 44
                        Grid2.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid2.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.LightCoral
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 45
                        Grid2.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid2.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Green
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                        'Case 46
                        '    Grid1.Rows(i).Activate()
                        '    For z = 0 To dt.Columns.Count - 1
                        '        With Grid1.ActiveRow.Cells(z).Appearance
                        '            .ForeColor = Color.DodgerBlue
                        '            .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        '            .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                        '        End With
                        '    Next

                        'Case 47
                        '    Grid1.Rows(i).Activate()
                        '    For z = 0 To dt.Columns.Count - 1
                        '        With Grid1.ActiveRow.Cells(z).Appearance
                        '            .ForeColor = Color.Orange
                        '            .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        '            .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                        '        End With
                        '    Next
                        'Case 48
                        '    Grid1.Rows(i).Activate()
                        '    For z = 0 To dt.Columns.Count - 1
                        '        With Grid1.ActiveRow.Cells(z).Appearance
                        '            .ForeColor = Color.Black
                        '            .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        '            .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                        '        End With
                        '    Next
                End Select
            Next
            Grid1.DataSource = dt
        End If

    End Sub

    Public Sub Procesar()
        Cia.Focus()
        If Cbo2.Value < 1 Then
            MsgBox("Debe seleccionar un PERIODO")
            Cbo2.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Cbo4.Value) Then
            MsgBox("Debe de donde se obtendrá la información")
            Cbo4.Focus()
            Return
        End If

        Me.Cursor = Cursors.Cross
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Negocio.Activo = New NGActivo
        Entidad.CanteraCosteo = New ETCanteraCosteo
        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Ano = Cbo2.Value
            .Tipo = Cbo4.Value
            .User = User_Sistema
            If Me.Tag = "104" Then
                .TipoTrabajo = "1"
            Else
                .TipoTrabajo = "2"
            End If

        End With

        Try
            If Tag = "105" Then
                Grid2.DataSource = Negocio.Activo.ListarCosteoMineralxCantera(Entidad.CanteraCosteo)
                Call Configurar()
            Else
                Grid1.DataSource = Negocio.Activo.ListarCosteoMineralxCantera(Entidad.CanteraCosteo)
            End If

        Catch ex As Exception
            If Tag = "105" Then
                Grid2.DataSource = Nothing
            Else
                Grid1.DataSource = Nothing
            End If

        End Try
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Me.Cursor = Cursors.Default
    End Sub

    Private Function ColumnaExcel(ByVal Columna As Integer) As String
        Dim LResult As String
        Select Case Columna
            Case 1
                LResult = "A"
            Case 2
                LResult = "B"
            Case 3
                LResult = "C"
            Case 4
                LResult = "D"
            Case 5
                LResult = "E"
            Case 6
                LResult = "F"
            Case 7
                LResult = "G"
            Case 8
                LResult = "H"
            Case 9
                LResult = "I"
            Case 10
                LResult = "J"
            Case 11
                LResult = "K"
            Case 12
                LResult = "L"
            Case 13
                LResult = "M"
            Case 14
                LResult = "N"
            Case 15
                LResult = "O"
            Case 16
                LResult = "P"
            Case 17
                LResult = "Q"
            Case 18
                LResult = "R"
            Case 19
                LResult = "S"
            Case 20
                LResult = "T"
            Case 21
                LResult = "U"
            Case 22
                LResult = "V"
            Case 23
                LResult = "W"
            Case 24
                LResult = "X"
            Case 25
                LResult = "Y"
            Case 26
                LResult = "Z"
            Case 27
                LResult = "AA"
            Case 28
                LResult = "AB"
            Case 29
                LResult = "AC"
            Case 30
                LResult = "AD"
            Case Else
                LResult = ""
        End Select

        Return LResult
    End Function

    Public Sub Excel()
        If Tag = "104" Then
            Call Excel_CosteoxCantera()
        Else
            Call Excel_CosteoxTipoCosto()
        End If
    End Sub
    Private Sub Excel_CosteoxTipoCosto()
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim Path As String = String.Empty
        Dim Archivo As String = String.Empty
        Dim Libro As New Infragistics.Excel.Workbook
        Dim Fila As Integer

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Dim Columna As String = String.Empty

        If Grid2.Rows.Count <= 0 Then
            MsgBox("No hay Datos que Exportar", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If
        Fila = Grid2.Rows.Count
        'Reporte de Costeo de Minerales
        Path = My.Application.Info.DirectoryPath & "\Reporte de Costeo de Minerales"

        Archivo = Path & "\Costeo de Minerales x Tipo de Costo - Periodo " & Cbo2.Text & ".xls"
        UltraGridExcelExporter1.Export(Grid2, Libro, 5, 0)
        Libro.Worksheets(0).Name = "Costeo de Minerales x Tipo Costo"
        Libro.Worksheets(0).Rows(0).Cells(0).Value = Cia.Text
        Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Height = 160
        Libro.Worksheets(0).Rows(2).Cells(0).Value = "COSTEO DE MINERALES POR TIPO COSTO PERIODO " & Cbo2.Text
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Default
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Height = 260
        'Libro.Worksheets(0).Rows(5).CellFormat.Font.Bold = ExcelDefaultableBoolean.True


        For j = 5 To Grid2.Rows.Count + 5
            If j = 5 Then
                For i = 1 To Grid2.DisplayLayout.Bands(0).Columns.Count - 1
                    With Libro.Worksheets(0).Rows(j).Cells(i - 1).CellFormat
                        .Font.Name = "Microsoft Sans Serif"
                        .Font.Height = 160
                        .Font.Bold = ExcelDefaultableBoolean.True
                        .Alignment = HorizontalCellAlignment.Center
                        .BottomBorderColor = Color.Black
                        .BottomBorderStyle = CellBorderLineStyle.Thin
                        .LeftBorderColor = Color.Black
                        .LeftBorderStyle = CellBorderLineStyle.Thin
                        .RightBorderColor = Color.Black
                        .RightBorderStyle = CellBorderLineStyle.Thin
                        .TopBorderColor = Color.Black
                        .TopBorderStyle = CellBorderLineStyle.Thin
                    End With

                Next
            Else
                For i = 1 To Grid2.DisplayLayout.Bands(0).Columns.Count - 1
                    With Libro.Worksheets(0).Rows(j).Cells(i - 1).CellFormat
                        .Font.Name = "Microsoft Sans Serif"
                        .Font.Height = 160
                        .BottomBorderColor = Color.Black
                        .BottomBorderStyle = CellBorderLineStyle.Thin
                        .LeftBorderColor = Color.Black
                        .LeftBorderStyle = CellBorderLineStyle.Thin
                        .RightBorderColor = Color.Black
                        .RightBorderStyle = CellBorderLineStyle.Thin
                        .TopBorderColor = Color.Black
                        .TopBorderStyle = CellBorderLineStyle.Thin
                        If i >= 2 Then
                            .Alignment = HorizontalCellAlignment.Right
                            .FormatString = "#,##0.0000"
                        Else
                            .Alignment = HorizontalCellAlignment.Left
                        End If
                    End With
                Next
            End If
        Next

        Libro.Worksheets(0).DisplayOptions.PanesAreFrozen = True
        Libro.Worksheets(0).DisplayOptions.FrozenPaneSettings.FrozenColumns = 1
        Libro.Worksheets(0).DisplayOptions.FrozenPaneSettings.FrozenRows = 6
        Try
            Libro.Save(Archivo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Call Iniciar_Excel(Archivo)

        Libro = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Private Sub Excel_CosteoxCantera()
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim Path As String = String.Empty
        Dim Archivo As String = String.Empty
        Dim Libro As New Infragistics.Excel.Workbook
        Dim Fila As Integer

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Dim Columna As String = String.Empty

        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay Datos que Exportar", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If
        Fila = Grid1.Rows.Count
        'Reporte de Costeo de Minerales
        Path = My.Application.Info.DirectoryPath & "\Reporte de Costeo de Minerales"

        Archivo = Path & "\Costeo de Minerales x Cantera - Periodo " & Cbo2.Text & ".xls"
        UltraGridExcelExporter1.Export(Grid1, Libro, 5, 0)
        Libro.Worksheets(0).Name = "Costeo de Minerales x Cantera"
        Libro.Worksheets(0).Rows(0).Cells(0).Value = Cia.Text
        Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Height = 160
        Libro.Worksheets(0).Rows(2).Cells(0).Value = "COSTEO DE MINERALES POR CANTERA PERIODO " & Cbo2.Text
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Default
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Height = 260
        'Libro.Worksheets(0).Rows(5).CellFormat.Font.Bold = ExcelDefaultableBoolean.True


        For j = 5 To Grid1.Rows.Count + 6
            If j = 5 Or j = Grid1.Rows.Count + 6 Then
                If j = 5 Then
                    For i = 1 To Grid1.DisplayLayout.Bands(0).Columns.Count
                        With Libro.Worksheets(0).Rows(j).Cells(i - 1).CellFormat
                            .Font.Name = "Microsoft Sans Serif"
                            .Font.Height = 160
                            .Font.Bold = ExcelDefaultableBoolean.True
                            .Alignment = HorizontalCellAlignment.Center
                            .BottomBorderColor = Color.Black
                            .BottomBorderStyle = CellBorderLineStyle.Thin
                            .LeftBorderColor = Color.Black
                            .LeftBorderStyle = CellBorderLineStyle.Thin
                            .RightBorderColor = Color.Black
                            .RightBorderStyle = CellBorderLineStyle.Thin
                            .TopBorderColor = Color.Black
                            .TopBorderStyle = CellBorderLineStyle.Thin
                        End With

                    Next
                Else
                    For i = 5 To Grid1.DisplayLayout.Bands(0).Columns.Count
                        With Libro.Worksheets(0).Rows(j).Cells(i - 1).CellFormat
                            .Font.Name = "Microsoft Sans Serif"
                            .Font.Height = 160
                            .Font.Bold = ExcelDefaultableBoolean.True
                            .BottomBorderColor = Color.Black
                            .BottomBorderStyle = CellBorderLineStyle.Thin
                            .LeftBorderColor = Color.Black
                            .LeftBorderStyle = CellBorderLineStyle.Thin
                            .RightBorderColor = Color.Black
                            .RightBorderStyle = CellBorderLineStyle.Thin
                            .TopBorderColor = Color.Black
                            .TopBorderStyle = CellBorderLineStyle.Thin
                            If i >= 5 Then
                                .Alignment = HorizontalCellAlignment.Right
                                .FormatString = "#,##0.0000"
                            Else
                                .Alignment = HorizontalCellAlignment.Left
                            End If

                        End With
                    Next
                End If
            Else
                For i = 1 To Grid1.DisplayLayout.Bands(0).Columns.Count
                    With Libro.Worksheets(0).Rows(j).Cells(i - 1).CellFormat
                        .Font.Name = "Microsoft Sans Serif"
                        .Font.Height = 160
                        .BottomBorderColor = Color.Black
                        .BottomBorderStyle = CellBorderLineStyle.Thin
                        .LeftBorderColor = Color.Black
                        .LeftBorderStyle = CellBorderLineStyle.Thin
                        .RightBorderColor = Color.Black
                        .RightBorderStyle = CellBorderLineStyle.Thin
                        .TopBorderColor = Color.Black
                        .TopBorderStyle = CellBorderLineStyle.Thin
                        If i >= 5 Then
                            .Alignment = HorizontalCellAlignment.Right
                            .FormatString = "#,##0.0000"
                        Else
                            .Alignment = HorizontalCellAlignment.Left
                        End If
                    End With
                Next
            End If
        Next

        j = 4
        For i = 1 To 13
            If i = 13 Then
                Libro.Worksheets(0).Rows(4).Cells(j).Value = "TOTAL"
            Else
                Libro.Worksheets(0).Rows(4).Cells(j).Value = NameMes(i)
            End If
            Libro.Worksheets(0).Rows(4).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True

            '  Libro.Worksheets(0).MergedCellsRegions.Add(4, j, 4, j + 1).CellFormat.Alignment = HorizontalCellAlignment.Center
            With Libro.Worksheets(0).MergedCellsRegions.Add(4, j, 4, j + 1).CellFormat
                .Alignment = HorizontalCellAlignment.Center
                .BottomBorderStyle = CellBorderLineStyle.Thin
                .LeftBorderStyle = CellBorderLineStyle.Thin
                .RightBorderStyle = CellBorderLineStyle.Thin
                .TopBorderStyle = CellBorderLineStyle.Thin
                .Font.Bold = ExcelDefaultableBoolean.True
            End With

            With Libro.Worksheets(0).Rows(6 + Fila).Cells(j).CellFormat
                .Font.Name = "Microsoft Sans Serif"
                .Font.Height = 160
                .Font.Bold = ExcelDefaultableBoolean.True
                .Alignment = HorizontalCellAlignment.Right
                .BottomBorderStyle = CellBorderLineStyle.Thin
                .LeftBorderStyle = CellBorderLineStyle.Thin
                .RightBorderStyle = CellBorderLineStyle.Thin
                .TopBorderStyle = CellBorderLineStyle.Thin
            End With

            Columna = ColumnaExcel(j + 1)
            Libro.Worksheets(0).Rows(6 + Fila).Cells(j).ApplyFormula("=SUM(" & Columna & "7:" & Columna & CStr((Grid1.Rows.Count + 6)) & ")")

            Libro.Worksheets(0).Rows(5).Cells(j).Value = "Cant. (TON)"
            Libro.Worksheets(0).Rows(5).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            j = j + 1

            With Libro.Worksheets(0).Rows(6 + Fila).Cells(j).CellFormat
                .Font.Name = "Microsoft Sans Serif"
                .Font.Height = 160
                .Font.Bold = ExcelDefaultableBoolean.True
                .Alignment = HorizontalCellAlignment.Right
                .BottomBorderStyle = CellBorderLineStyle.Thin
                .LeftBorderStyle = CellBorderLineStyle.Thin
                .RightBorderStyle = CellBorderLineStyle.Thin
                .TopBorderStyle = CellBorderLineStyle.Thin
            End With

            Columna = ColumnaExcel(j + 1)
            Libro.Worksheets(0).Rows(6 + Fila).Cells(j).ApplyFormula("=SUM(" & Columna & "7:" & Columna & CStr((Grid1.Rows.Count + 6)) & ")")

            Libro.Worksheets(0).Rows(5).Cells(j).Value = "SubTotal (S/.)"
            Libro.Worksheets(0).Rows(5).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            j = j + 1

        Next

        Libro.Worksheets(0).DisplayOptions.PanesAreFrozen = True
        Libro.Worksheets(0).DisplayOptions.FrozenPaneSettings.FrozenColumns = 4
        Libro.Worksheets(0).DisplayOptions.FrozenPaneSettings.FrozenRows = 6
        Try
            Libro.Save(Archivo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Call Iniciar_Excel(Archivo)

        Libro = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout
        If e Is Nothing Then Exit Sub
        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If xCol.Key = "ID" Then
                xCol.Hidden = True
            ElseIf xCol.Key = "Descripcion" Then
                xCol.MinWidth = 250
            End If
        Next
    End Sub
End Class