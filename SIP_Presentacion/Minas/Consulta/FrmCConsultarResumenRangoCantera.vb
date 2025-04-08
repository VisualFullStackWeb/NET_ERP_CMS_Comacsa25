Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Excel
Imports Infragistics.Excel.Workbook

Public Class FrmCConsultarResumenRangoCantera
    Public Ls_Permisos As New List(Of Integer)

    Sub LlenarPeriodo()
        Cbo2.Items.Clear()
        Cbo21.Items.Clear()
        Dim i As Integer = 2010
        For i = 2010 To Year(Date.Now)
            Dim Dato As New Infragistics.Win.ValueListItem
            Dim DatoFin As New Infragistics.Win.ValueListItem
            Dato.DisplayText = CStr(i)
            Dato.DataValue = CStr(i)
            DatoFin.DisplayText = CStr(i)
            DatoFin.DataValue = CStr(i)
            Cbo2.Items.Add(Dato)
            Cbo21.Items.Add(DatoFin)
        Next
    End Sub

    Private Sub FrmCConsultarResumenRangoCantera_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Private Sub FrmCConsultarResumenRangoCantera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia)
        Call LlenarPeriodo()
        Call Cargar_CosteoMineral_Conceptos_Variacion(Grid4, Cia.Value)
        Cbo4.Value = "1"
        Cbo2.Value = Now.Year
        CboMes.Value = 1
        Cbo21.Value = Now.Year
        CboMes1.Value = Now.Month
        CboTipoCantera.Value = "A"
        CboCosto.Value = "T"
        If Tag = "119" Then
            TabCosteo.Tabs("T01").Text = "COSTEO DE MINERALES  POR TIPO DE COSTO POR RANGOS"
            Grid1.Visible = False
        Else
            TabCosteo.Tabs("T01").Text = "COSTEO DE MINERALES  POR CANTERA POR RANGOS"
            Grid2.Visible = False
        End If
    End Sub
    Public Sub Procesar()
        Cia.Focus()
        If Cbo2.Value < 1 Then
            MsgBox("Debe seleccionar un Año de Inicio Válido")
            Cbo2.Focus()
            Return
        End If
        If CboMes.Value < 1 Then
            MsgBox("Debe seleccionar el Mes de Inicio Válido")
            CboMes.Focus()
            Return
        End If

        If Cbo21.Value < 1 Then
            MsgBox("Debe seleccionar un Año de Termino Válido")
            Cbo21.Focus()
            Return
        End If

        If CboMes1.Value < 1 Then
            MsgBox("Debe seleccionar el Mes de Termino Válido")
            CboMes1.Focus()
            Return
        End If

        If Cbo2.Value = Cbo21.Value And CboMes1.Value < CboMes.Value Then
            MsgBox("El mes de termino no puede ser menor al de Inicio")
            CboMes1.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Cbo4.Value) Then
            MsgBox("Debe de donde se obtendrá la información")
            Cbo4.Focus()
            Return
        End If

        If String.IsNullOrEmpty(CboCosto.Value) Then
            MsgBox("Seleccione el Tipo de Costo")
            CboCosto.Focus()
            Return
        End If

        If String.IsNullOrEmpty(CboTipoCantera.Value) Then
            MsgBox("Seleccione el Tipo de Cantera")
            CboTipoCantera.Focus()
            Return
        End If

        Grid4.Update()
        Grid4.UpdateData()
        Dim Dt_Concepto As New DataTable

        If chkIncluirVariacion.Checked Then
            Dt_Concepto = Grid4.DataSource
        End If


        Me.Cursor = Cursors.Cross
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Negocio.Activo = New NGActivo
        Entidad.CanteraCosteo = New ETCanteraCosteo
        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Ano = Cbo2.Value
            .Mes = CboMes.Value
            .Ano_Fin = Cbo21.Value
            .Mes_Fin = CboMes1.Value
            .TipoCantera = CboTipoCantera.Value
            .TipoCosto = CboCosto.Value
            .Tipo = Cbo4.Value
            .User = User_Sistema
            If Me.Tag = "118" Then
                .TipoTrabajo = "1"
            Else
                .TipoTrabajo = "2"
            End If
            .Action = chkIncluirVariacion.Checked
            .DT_Lista = Dt_Concepto
        End With

        Try
            If Tag = "118" Then
                Grid1.DataSource = Nothing
                Grid1.DataSource = Negocio.Activo.ListarCosteoMineralxCantera_por_Rangos(Entidad.CanteraCosteo)

            Else
                Grid2.DataSource = Nothing
                Grid2.DataSource = Negocio.Activo.ListarCosteoMineralxCantera_por_Rangos(Entidad.CanteraCosteo)
                Call Configurar()
            End If

        Catch ex As Exception
            If Tag = "118" Then
                Grid1.DataSource = Nothing
            Else
                Grid2.DataSource = Nothing
            End If

        End Try
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        Try

            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                xCol.Header.Appearance.FontData.Bold = DefaultableBoolean.True
                xCol.MaxWidth = 0
                xCol.CellActivation = Activation.ActivateOnly
                Select Case xCol.Key
                    Case "Cantera"
                        xCol.MinWidth = 80
                        xCol.Header.Caption = "CODIGO"
                    Case "Descripcion"
                        xCol.Header.Caption = "CANTERA"
                        xCol.MinWidth = 200
                    Case "Origen"
                        xCol.Hidden = True

                    Case "TON_TOTAL"
                        xCol.Header.Caption = "CANT.(TON)"
                        xCol.MinWidth = 100
                        xCol.Format = "n3"
                        xCol.CellAppearance.BackColor = Color.Orange
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    Case "COSTOTON"
                        xCol.Header.Caption = "COSTO X TON"
                        xCol.MinWidth = 100
                        xCol.Format = "n3"
                        xCol.CellAppearance.BackColor = Color.Yellow
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    Case "COSTO_TOTAL"
                        xCol.Header.Caption = "COSTO TOTAL(S/.)"
                        xCol.MinWidth = 120
                        xCol.Format = "n4"
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.CellAppearance.BackColor = Color.YellowGreen
                        xCol.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    Case "TON_PROM"
                        xCol.Header.Caption = "CANT.(TON)"
                        xCol.MinWidth = 100
                        xCol.Format = "n3"
                        xCol.CellAppearance.BackColor = Color.Orange
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    Case "COSTOTON_PROM"
                        xCol.Header.Caption = "COSTO X TON"
                        xCol.MinWidth = 100
                        xCol.Format = "n3"
                        xCol.CellAppearance.BackColor = Color.Yellow
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    Case "TOTAL_PROM"
                        xCol.Header.Caption = "COSTO TOTAL(S/.)"
                        xCol.MinWidth = 120
                        xCol.Format = "n4"
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.CellAppearance.BackColor = Color.YellowGreen
                        xCol.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    Case Else
                        xCol.Format = "n4"
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        If Mid(xCol.Key.Trim, 1, 3) = "TON" Then
                            xCol.MinWidth = 90
                        Else
                            xCol.MinWidth = 100
                        End If

                End Select

            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Excel()
        If Tag = "118" Then
            Call Excel_CosteoxCantera()
        Else
            Call Excel_CosteoxTipoCosto()
        End If
    End Sub

    Sub Configurar()
        Dim i As Integer
        Dim z As Integer

        If Grid2.Rows.Count > 0 Then
            Dim dt As New DataTable
            dt = Grid2.DataSource
            For i = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(i).Item("Concepto")
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
            'Grid1.DataSource = dt
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

        Archivo = Path & "\Costeo de Minerales x Tipo de Costo - Periodo De " & CboMes.Text & " " & Cbo2.Text & " A " & CboMes1.Text & " " & Cbo21.Text & ".xls"
        UltraGridExcelExporter1.Export(Grid2, Libro, 5, 0)
        Libro.Worksheets(0).Name = "Costeo de Minerales x Tipo Costo"
        Libro.Worksheets(0).Rows(0).Cells(0).Value = Cia.Text
        Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Height = 160
        Libro.Worksheets(0).Rows(2).Cells(0).Value = "COSTEO DE MINERALES POR TIPO COSTO PERIODO DE " & CboMes.Text & " " & Cbo2.Text & " A " & CboMes1.Text & " " & Cbo21.Text
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Default
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Height = 260
        'Libro.Worksheets(0).Rows(5).CellFormat.Font.Bold = ExcelDefaultableBoolean.True


        For j = 5 To Grid2.Rows.Count + 5
            If j = 5 Then
                For i = 5 To Grid2.DisplayLayout.Bands(0).Columns.Count + 1
                    With Libro.Worksheets(0).Rows(j).Cells(i - 5).CellFormat
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
                For i = 5 To Grid2.DisplayLayout.Bands(0).Columns.Count + 1
                    With Libro.Worksheets(0).Rows(j).Cells(i - 5).CellFormat
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
                        If i >= 6 Then
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

        Archivo = Path & "\Costeo de Minerales x Cantera - Periodo De " & CboMes.Text & " " & Cbo2.Text & " A " & CboMes1.Text & " " & Cbo21.Text & ".xls"
        UltraGridExcelExporter1.Export(Grid1, Libro, 5, 0)
        Libro.Worksheets(0).Name = "Costeo de Minerales x Cantera"
        Libro.Worksheets(0).Rows(0).Cells(0).Value = Cia.Text
        Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Height = 160
        Libro.Worksheets(0).Rows(2).Cells(0).Value = "COSTEO DE MINERALES POR CANTERA PERIODO DE " & CboMes.Text & " " & Cbo2.Text & " A " & CboMes1.Text & " " & Cbo21.Text
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Default
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Height = 260
        'Libro.Worksheets(0).Rows(5).CellFormat.Font.Bold = ExcelDefaultableBoolean.True


        For j = 5 To Grid1.Rows.Count + 6
            If j = 5 Or j = Grid1.Rows.Count + 6 Then
                If j = 5 Then
                    For i = 1 To Grid1.DisplayLayout.Bands(0).Columns.Count - 1
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
                    For i = 1 To Grid1.DisplayLayout.Bands(0).Columns.Count - 1
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
                            If i >= 3 Then
                                .Alignment = HorizontalCellAlignment.Right
                                .FormatString = "#,##0.0000"
                            Else
                                .Alignment = HorizontalCellAlignment.Left
                            End If

                        End With
                    Next
                End If
            Else
                For i = 1 To Grid1.DisplayLayout.Bands(0).Columns.Count - 1
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
                        If i >= 3 Then
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
        For i = 3 To Grid1.DisplayLayout.Bands(0).Columns.Count - 1

            If Not (Grid1.DisplayLayout.Bands(0).Columns(i).Key = "TON_TOTAL" OrElse _
            Grid1.DisplayLayout.Bands(0).Columns(i).Key = "COSTO_TOTAL" OrElse _
            Grid1.DisplayLayout.Bands(0).Columns(i).Key = "COSTOTON" OrElse _
            Grid1.DisplayLayout.Bands(0).Columns(i).Key = "TON_PROM" OrElse _
            Grid1.DisplayLayout.Bands(0).Columns(i).Key = "COSTOTON_PROM" OrElse _
            Grid1.DisplayLayout.Bands(0).Columns(i).Key = "TOTAL_PROM" OrElse _
            Grid1.DisplayLayout.Bands(0).Columns(i).Key = "Origen" OrElse _
            Grid1.DisplayLayout.Bands(0).Columns(i).Key = "Cantera" OrElse _
            Grid1.DisplayLayout.Bands(0).Columns(i).Key = "Descripcion") Then
                If Mid(Grid1.DisplayLayout.Bands(0).Columns(i).Key, 1, 3) = "TON" Then
                    Libro.Worksheets(0).Rows(j).Cells(i - 1).Value = NameMes(Mid(Grid1.DisplayLayout.Bands(0).Columns(i).Key, 9, 2)) & " " & Mid(Grid1.DisplayLayout.Bands(0).Columns(i).Key, 5, 4)
                    Libro.Worksheets(0).Rows(j + 1).Cells(i - 1).Value = "TON"
                    With Libro.Worksheets(0).MergedCellsRegions.Add(j, i - 1, j, i + 1).CellFormat
                        .Alignment = HorizontalCellAlignment.Center
                        .BottomBorderStyle = CellBorderLineStyle.Thin
                        .LeftBorderStyle = CellBorderLineStyle.Thin
                        .RightBorderStyle = CellBorderLineStyle.Thin
                        .TopBorderStyle = CellBorderLineStyle.Thin
                        .Font.Bold = ExcelDefaultableBoolean.True
                    End With
                ElseIf Mid(Grid1.DisplayLayout.Bands(0).Columns(i).Key, 1, 5) = "COSTO" Then
                    Libro.Worksheets(0).Rows(j + 1).Cells(i - 1).Value = "COSTO X TON"
                Else
                    Libro.Worksheets(0).Rows(j + 1).Cells(i - 1).Value = "SUBTOTAL"
                End If
            ElseIf Grid1.DisplayLayout.Bands(0).Columns(i).Key = "TON_TOTAL" Then
                Libro.Worksheets(0).Rows(j).Cells(i - 1).Value = "TOTALES"
                With Libro.Worksheets(0).MergedCellsRegions.Add(j, i - 1, j, i + 1).CellFormat
                    .Alignment = HorizontalCellAlignment.Center
                    .BottomBorderStyle = CellBorderLineStyle.Thin
                    .LeftBorderStyle = CellBorderLineStyle.Thin
                    .RightBorderStyle = CellBorderLineStyle.Thin
                    .TopBorderStyle = CellBorderLineStyle.Thin
                    .Font.Bold = ExcelDefaultableBoolean.True
                End With
            ElseIf Grid1.DisplayLayout.Bands(0).Columns(i).Key = "TON_PROM" Then
                Libro.Worksheets(0).Rows(j).Cells(i - 1).Value = "PROMEDIOS"
                With Libro.Worksheets(0).MergedCellsRegions.Add(j, i - 1, j, i + 1).CellFormat
                    .Alignment = HorizontalCellAlignment.Center
                    .BottomBorderStyle = CellBorderLineStyle.Thin
                    .LeftBorderStyle = CellBorderLineStyle.Thin
                    .RightBorderStyle = CellBorderLineStyle.Thin
                    .TopBorderStyle = CellBorderLineStyle.Thin
                    .Font.Bold = ExcelDefaultableBoolean.True
                End With
            End If

            Libro.Worksheets(0).Rows(j).Cells(i - 1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True

            With Libro.Worksheets(0).Rows(6 + Fila).Cells(i - 1).CellFormat
                .Font.Name = "Microsoft Sans Serif"
                .Font.Height = 160
                .Font.Bold = ExcelDefaultableBoolean.True
                .Alignment = HorizontalCellAlignment.Right
                .BottomBorderStyle = CellBorderLineStyle.Thin
                .LeftBorderStyle = CellBorderLineStyle.Thin
                .RightBorderStyle = CellBorderLineStyle.Thin
                .TopBorderStyle = CellBorderLineStyle.Thin
            End With

            Columna = Letra_ColumnaExcel(i) ' ColumnaExcel(j + 1)
            Libro.Worksheets(0).Rows(6 + Fila).Cells(i - 1).ApplyFormula("=SUM(" & Columna & "7:" & Columna & CStr((Grid1.Rows.Count + 6)) & ")")

            'Libro.Worksheets(0).Rows(5).Cells(j).Value = "Cant. (TON)"
            Libro.Worksheets(0).Rows(5).Cells(i - 1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            'j = j + 1

            'With Libro.Worksheets(0).Rows(6 + Fila).Cells(j).CellFormat
            '    .Font.Name = "Microsoft Sans Serif"
            '    .Font.Height = 160
            '    .Font.Bold = ExcelDefaultableBoolean.True
            '    .Alignment = HorizontalCellAlignment.Right
            '    .BottomBorderStyle = CellBorderLineStyle.Thin
            '    .LeftBorderStyle = CellBorderLineStyle.Thin
            '    .RightBorderStyle = CellBorderLineStyle.Thin
            '    .TopBorderStyle = CellBorderLineStyle.Thin
            'End With

            'Columna = ColumnaExcel(j + 1)
            'Libro.Worksheets(0).Rows(6 + Fila).Cells(j).ApplyFormula("=SUM(" & Columna & "7:" & Columna & CStr((Grid1.Rows.Count + 6)) & ")")

            'Libro.Worksheets(0).Rows(5).Cells(j).Value = "SubTotal (S/.)"
            'Libro.Worksheets(0).Rows(5).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            'j = j + 1

        Next

        Libro.Worksheets(0).DisplayOptions.PanesAreFrozen = True
        Libro.Worksheets(0).DisplayOptions.FrozenPaneSettings.FrozenColumns = 2
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
        Try
            e.Layout.Bands(0).Override.HeaderClickAction = HeaderClickAction.Select

            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                xCol.Header.Appearance.FontData.Bold = DefaultableBoolean.True
                xCol.MaxWidth = 0
                xCol.CellActivation = Activation.ActivateOnly
                Select Case xCol.Key
                    Case "Orden", "ID", "Concepto"
                        xCol.Hidden = True
                    Case "Descripcion"
                        xCol.Header.Caption = "DESCRIPCIÓN"
                        xCol.MinWidth = 200
                    Case "TOTAL"
                        xCol.MinWidth = 120
                        xCol.Format = "n4"
                        xCol.Header.Caption = "TOTAL (S/.)"
                        xCol.CellAppearance.BackColor = Color.YellowGreen
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    Case "PROMEDIO"
                        xCol.MinWidth = 120
                        xCol.Format = "n4"
                        xCol.Header.Caption = "PROMEDIO (S/.)"
                        xCol.CellAppearance.BackColor = Color.Yellow
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    Case Else
                        xCol.Format = "n4"
                        xCol.MinWidth = 100
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        If Mid(xCol.Key.Trim, 1, 2) = "C_" Then
                            xCol.Header.Caption = Mid(NameMes(Mid(xCol.Key.Trim, 7, 2)), 1, 3) & " " & Mid(xCol.Key.Trim, 3, 4)
                        End If

                End Select

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkIncluirVariacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncluirVariacion.CheckedChanged
        If chkIncluirVariacion.Checked = True Then
            TabCosteo.Tabs("T02").Selected = True
        End If
    End Sub

    Private Sub Grid4_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles Grid4.InitializeRow
        Try
            If e.Row.Cells("activo").Value = True Then
                e.Row.Cells("Variacion").Activation = Activation.AllowEdit
            Else
                e.Row.Cells("Variacion").Activation = Activation.NoEdit
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid4.KeyDown
        With sender
            Select Case e.KeyValue
                Case Keys.Up
                    .PerformAction(ExitEditMode)
                    .PerformAction(AboveCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Down
                    .PerformAction(ExitEditMode)
                    .PerformAction(BelowCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Right
                    .PerformAction(ExitEditMode)
                    .PerformAction(NextCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Left
                    .PerformAction(ExitEditMode)
                    .PerformAction(PrevCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Return

                    .PerformAction(ExitEditMode)
                    .PerformAction(BelowCell)
                    .ActiveRow.Cells("Variacion").Activate()
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)



            End Select
        End With
    End Sub
End Class