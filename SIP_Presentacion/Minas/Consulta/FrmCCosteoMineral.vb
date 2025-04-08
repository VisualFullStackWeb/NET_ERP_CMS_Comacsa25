Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Excel
Imports Infragistics.Excel.Workbook


Public Class FrmCCosteoMineral


    Public Ls_Permisos As New List(Of Integer)
    Dim xGastosCantera As Double = 0
    Dim xGastosCanteraM As Double = 0
    Dim xTotalVentas As Double = 0
    Private Ls_Canteras As List(Of ETCanteraCosteo) = Nothing
    Private Ls_Conceptos As List(Of ETCanteraCosteo) = Nothing
    Private Ls_CosteoMineral As List(Of ETCanteraCosteo) = Nothing
    Private CodigoCantera As String = String.Empty
    Private IDConcepto As Integer = 0

    Private Enum Alineacion
        Izquierda = -4131
        Derecha = -4152
        Centrado = -4108
    End Enum

    Dim Obj_Excel As Object
    Dim Obj_Libro As Object
    Dim Obj_Hoja As Object
    Dim Fila As Integer = 0

#Region "Procedimientos Privados"
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

    Sub Configurar()
        Dim i As Integer
        Dim z As Integer

        If Grid1.Rows.Count > 0 Then
            Dim dt As New DataTable
            dt = Grid1.DataSource
            For i = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(i).Item(0)
                    Case 1
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Green
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 2
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Blue
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True

                                If z = 1 Then .FontData.Underline = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next

                    Case 24
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Blue
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 25
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.LightCoral
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                                If z = 1 Then .FontData.Underline = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 44
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.LightCoral
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 45
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Green
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 46
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.DodgerBlue
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next

                    Case 47
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Orange
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 48
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Black
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                End Select
            Next
            Grid1.DataSource = dt
        End If

    End Sub

    Sub Agrupar()
        Dim i As Integer
        Dim j As Integer
        Dim z As Integer
        Dim Costo As Decimal = Decimal.Zero
        Dim Tonelada As Decimal = Decimal.Zero
        If Grid1.Rows.Count > 0 Then
            Dim dt As New DataTable
            dt = Grid1.DataSource
            For i = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(i).Item(0)
                    Case 1
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Green
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 2
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Blue
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True

                                If z = 1 Then .FontData.Underline = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next

                    Case 24
                        For j = 0 To dt.Rows.Count - 1
                            If dt.Rows(j).Item(0) = 3 OrElse dt.Rows(j).Item(0) = 4 _
                            OrElse dt.Rows(j).Item(0) = 5 OrElse dt.Rows(j).Item(0) = 6 _
                            OrElse dt.Rows(j).Item(0) = 7 OrElse dt.Rows(j).Item(0) = 8 _
                            OrElse dt.Rows(j).Item(0) = 9 OrElse dt.Rows(j).Item(0) = 10 _
                            OrElse dt.Rows(j).Item(0) = 11 OrElse dt.Rows(j).Item(0) = 12 _
                            OrElse dt.Rows(j).Item(0) = 13 OrElse dt.Rows(j).Item(0) = 14 _
                            OrElse dt.Rows(j).Item(0) = 16 OrElse dt.Rows(j).Item(0) = 17 _
                            OrElse dt.Rows(j).Item(0) = 18 OrElse dt.Rows(j).Item(0) = 19 _
                            OrElse dt.Rows(j).Item(0) = 20 OrElse dt.Rows(j).Item(0) = 21 _
                            OrElse dt.Rows(j).Item(0) = 22 OrElse dt.Rows(j).Item(0) = 23 Then
                                For z = 2 To dt.Columns.Count - 1
                                    dt.Rows(i).Item(z) = dt.Rows(i).Item(z) + dt.Rows(j).Item(z)
                                Next
                            End If
                        Next
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Blue
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 25
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.LightCoral
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                                If z = 1 Then .FontData.Underline = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 44
                        For j = 0 To dt.Rows.Count - 1
                            If dt.Rows(j).Item(0) = 27 OrElse dt.Rows(j).Item(0) = 29 _
                            OrElse dt.Rows(j).Item(0) = 30 OrElse dt.Rows(j).Item(0) = 31 _
                            OrElse dt.Rows(j).Item(0) = 32 OrElse dt.Rows(j).Item(0) = 33 _
                            OrElse dt.Rows(j).Item(0) = 34 OrElse dt.Rows(j).Item(0) = 35 _
                            OrElse dt.Rows(j).Item(0) = 36 OrElse dt.Rows(j).Item(0) = 37 _
                            OrElse dt.Rows(j).Item(0) = 38 OrElse dt.Rows(j).Item(0) = 39 _
                            OrElse dt.Rows(j).Item(0) = 40 OrElse dt.Rows(j).Item(0) = 41 _
                            OrElse dt.Rows(j).Item(0) = 42 OrElse dt.Rows(j).Item(0) = 43 _
                            Then
                                For z = 2 To dt.Columns.Count - 1
                                    dt.Rows(i).Item(z) = dt.Rows(i).Item(z) + dt.Rows(j).Item(z)
                                Next
                            End If
                        Next
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.LightCoral
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 45
                        For j = 0 To dt.Rows.Count - 1
                            If dt.Rows(j).Item(0) = 16 _
                            OrElse dt.Rows(j).Item(0) = 18 OrElse dt.Rows(j).Item(0) = 24 _
                            OrElse dt.Rows(j).Item(0) = 44 Then
                                For z = 2 To dt.Columns.Count - 1
                                    If dt.Rows(j).Item(0) = 16 OrElse dt.Rows(j).Item(0) = 18 Then
                                        dt.Rows(i).Item(z) = dt.Rows(i).Item(z) - dt.Rows(j).Item(z)
                                    Else
                                        dt.Rows(i).Item(z) = dt.Rows(i).Item(z) + dt.Rows(j).Item(z)
                                    End If

                                Next
                            End If
                        Next
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Green
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 46
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.DodgerBlue
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next

                    Case 47

                        For j = 2 To dt.Columns.Count - 2
                            Costo = 0
                            Tonelada = 0
                            For z = 0 To dt.Rows.Count - 1
                                If dt.Rows(z).Item(0) = 1 Then
                                    Tonelada = dt.Rows(z).Item(j)
                                End If

                                If dt.Rows(z).Item(0) = 45 Then
                                    Costo = Costo + dt.Rows(z).Item(j)
                                End If

                                If dt.Rows(z).Item(0) = 47 Then
                                    If Tonelada <> 0 Then
                                        dt.Rows(z).Item(j) = Costo / Tonelada
                                    End If
                                End If
                            Next
                        Next
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Orange
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                    Case 48
                        For j = 2 To dt.Columns.Count - 2
                            Costo = 0
                            Tonelada = 0
                            For z = 0 To dt.Rows.Count - 1
                                If dt.Rows(z).Item(0) = 1 Then
                                    Tonelada = dt.Rows(z).Item(j)
                                End If

                                If dt.Rows(z).Item(0) = 24 Then
                                    Costo = Costo + dt.Rows(z).Item(j)
                                End If

                                If dt.Rows(z).Item(0) = 48 Then
                                    If Tonelada <> 0 Then
                                        dt.Rows(z).Item(j) = FormatNumber((Costo / Tonelada), 4)
                                    End If
                                End If
                            Next
                        Next
                        Grid1.Rows(i).Activate()
                        For z = 0 To dt.Columns.Count - 1
                            With Grid1.ActiveRow.Cells(z).Appearance
                                .ForeColor = Color.Black
                                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                                .FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                            End With
                        Next
                End Select
            Next
            Grid1.DataSource = dt
        End If

    End Sub

    Private Sub CalcularTotalPorcentaje()
        Dim dt As New DataTable
        dt = Grid1.DataSource
        Dim dt1 As New DataTable
        dt1 = Grid1.DataSource
        Dim xsuma As Decimal = 0
        Dim TotalGastos As Decimal = 0
        Dim TotalToneladas As Decimal = 0
        Dim TotalGastoCantera As Decimal = 0
        Dim ToneladaCantera As Decimal = 0


        If Grid1.Rows.Count > 0 Then
            For I As Integer = 0 To dt.Rows.Count - 1

                If I = 0 Then
                    Grid1.DisplayLayout.Bands(0).Columns(0).Width = 0
                    Grid1.DisplayLayout.Bands(0).Columns(0).Hidden = True
                    Grid1.DisplayLayout.Bands(0).Columns(0).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                    Grid1.DisplayLayout.Bands(0).Columns(0).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    Grid1.DisplayLayout.Bands(0).Columns(0).Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                    Grid1.DisplayLayout.Bands(0).Columns(0).Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    Grid1.DisplayLayout.Bands(0).Columns(0).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
                ElseIf I = 1 Then
                    Grid1.DisplayLayout.Bands(0).Columns(1).Width = 450
                    Grid1.DisplayLayout.Bands(0).Columns(1).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
                    Grid1.DisplayLayout.Bands(0).Columns(1).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    Grid1.DisplayLayout.Bands(0).Columns(1).Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                    Grid1.DisplayLayout.Bands(0).Columns(1).Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    Grid1.DisplayLayout.Bands(0).Columns(1).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
                End If

                For j As Integer = 2 To dt.Columns.Count - 1
                    xsuma = xsuma + CDbl(dt.Rows(I).Item(j))

                    Grid1.DisplayLayout.Bands(0).Columns(j).Width = 100
                    Grid1.DisplayLayout.Bands(0).Columns(j).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    Grid1.DisplayLayout.Bands(0).Columns(j).CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    Grid1.DisplayLayout.Bands(0).Columns(j).Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                    Grid1.DisplayLayout.Bands(0).Columns(j).Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    Grid1.DisplayLayout.Bands(0).Columns(j).Format = "n4"
                    Grid1.DisplayLayout.Bands(0).Columns(j).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly

                Next
                If Grid1.Rows(I).Cells("ID").Value = 45 Then
                    TotalGastos = CDbl(xsuma)
                    xGastosCantera = TotalGastos
                End If

                If Grid1.Rows(I).Cells("ID").Value = 1 Then
                    TotalToneladas = CDbl(xsuma)
                End If

                Grid1.Rows(I).Cells("Total").Value = CDbl(xsuma)
                Grid1.DisplayLayout.Bands(0).Columns("Total").Width = 120
                Grid1.DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                Grid1.DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Grid1.DisplayLayout.Bands(0).Columns("Total").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                Grid1.DisplayLayout.Bands(0).Columns("Total").Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Grid1.DisplayLayout.Bands(0).Columns("Total").Format = "n4"
                Grid1.DisplayLayout.Bands(0).Columns("Total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly

                Grid1.DisplayLayout.Bands(0).Columns("Porcentaje").Width = 80
                Grid1.DisplayLayout.Bands(0).Columns("Porcentaje").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                Grid1.DisplayLayout.Bands(0).Columns("Porcentaje").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Grid1.DisplayLayout.Bands(0).Columns("Porcentaje").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                Grid1.DisplayLayout.Bands(0).Columns("Porcentaje").Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle
                Grid1.DisplayLayout.Bands(0).Columns("Porcentaje").Format = "n2"
                Grid1.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly

                xsuma = 0
            Next

            Grid1.UpdateData()
            If TotalGastos <> 0 Then


                For I As Integer = 0 To dt.Rows.Count - 1
                    If Grid1.Rows(I).Cells("ID").Value = 46 Then
                        For j As Integer = 2 To dt.Columns.Count - 2
                            TotalGastoCantera = 0

                            For K As Integer = 0 To dt1.Rows.Count - 1
                                If dt1.Rows(K).Item("ID") = 45 Then
                                    TotalGastoCantera = dt1.Rows(K).Item(j)
                                End If
                            Next
                            If TotalToneladas <> 0 Then
                                Grid1.Rows(I).Cells(j).Value = FormatNumber((TotalGastoCantera / TotalGastos) * 100, 4)
                            End If

                        Next
                        'Grid1.Rows(I).Cells("Porcentaje").Value = FormatNumber((Val(Grid1.Rows(I).Cells("Total").Value) / TotalGastos) * 100, 2)
                    ElseIf Grid1.Rows(I).Cells("ID").Value > 1 And Grid1.Rows(I).Cells("ID").Value <= 45 Then
                        Grid1.Rows(I).Cells("Porcentaje").Value = FormatNumber((Val(Grid1.Rows(I).Cells("Total").Value) / TotalGastos) * 100, 2)
                    End If

                Next
                Grid1.UpdateData()
            End If


        End If

    End Sub

#End Region

#Region "Eventos"
    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
             Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Sub _Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia)
        Call LlenarPeriodo()
        Call Cargar_CosteoMineral_Conceptos_Variacion(Grid4, Cia.Value)

        Cbo4.Value = "1"
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

    Private Sub Grid1_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles Grid1.DoubleClickCell
        Dim TotalMinerales As Decimal = Decimal.Zero
        Dim CantMineral As Decimal = Decimal.Zero

        If Grid1.ActiveRow Is Nothing Then Exit Sub
        If Grid1.Rows.Count <= 0 Then Exit Sub

        LblCantera.Text = ""
        Try
            With Grid1


                Entidad.EmpleoLabor = New ETEmpleoLabor
                Negocio.Activo = New NGActivo
                CodigoCantera = Grid1.ActiveRow.Cells(Grid1.ActiveCell.Column.Index).Column.Key.ToString '.ActiveCell.Column.Key
                TotalMinerales = Ls_Canteras.Sum(Function(Rpt As ETCanteraCosteo) Rpt.Importe)
                CantMineral = Ls_Canteras.Where(AddressOf FiltrarCanteraCosteo2).Sum(Function(Rpt As ETCanteraCosteo) Rpt.Importe)
                With Entidad.CanteraCosteo
                    .CodCia = Companhia
                    .CodigoCantera = Grid1.ActiveCell.Column.Key.ToString
                    .Ano = Cbo2.Value
                    .Mes = CboMes.Value
                    .NumeroPeriodo = CantMineral ' Grid1.Rows(0).Cells(Grid1.ActiveCell.Column.Key).Value
                    .Importe = TotalMinerales
                    .Tipo = Cbo4.Value
                End With
                txtValor.Value = 0
                LblDetalle.Text = ""
                LblCantera.Text = Grid1.ActiveCell.Column.Key.ToString
                Select Case .ActiveCell.Row.Cells(0).Value
                    Case 1

                        TabCosteo.Tabs("T02").Selected = True
                        Grid2.DataSource = Negocio.Activo.ListarDetalleCosteoMineral(Entidad.CanteraCosteo, 1)
                        Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = False
                        Grid2.DisplayLayout.Bands(0).Columns("Moneda").Hidden = True
                        LblDetalle.Text = Grid1.ActiveRow.Cells("Descripcion").Value

                    Case 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 19, 23, 29, 30, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 51, 52, 54, 57, 58

                        TabCosteo.Tabs("T02").Selected = True

                        Grid2.DataSource = Negocio.Activo.ListarDetalleCosteoMineral(Entidad.CanteraCosteo, .ActiveCell.Row.Cells(0).Value)
                        If Cbo4.Value = "1" Then
                            Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = True
                        ElseIf Cbo4.Value = "0" And .ActiveCell.Row.Cells(0).Value = 4 Then
                            Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = False
                            Grid2.DisplayLayout.Bands(0).Columns("Unidad").Header.Caption = "Tipo Tareo"
                            Grid2.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Equipo"
                        Else
                            Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = True
                            'Grid2.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción"
                        End If

                        Grid2.DisplayLayout.Bands(0).Columns("Moneda").Hidden = False
                        LblDetalle.Text = Grid1.ActiveRow.Cells("Descripcion").Value

                    Case 15, 16, 17, 18, 53, 20, 22
                        TabCosteo.Tabs("T02").Selected = True
                        Grid2.DataSource = Negocio.Activo.ListarDetalleCosteoMineral(Entidad.CanteraCosteo, .ActiveCell.Row.Cells(0).Value)
                        Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = False
                        Grid2.DisplayLayout.Bands(0).Columns("Moneda").Hidden = False
                        LblDetalle.Text = Grid1.ActiveRow.Cells("Descripcion").Value


                    Case 27, 31, 32, 33, 28, 31, 32, 21, 55, 56

                        TabCosteo.Tabs("T02").Selected = True
                        Grid2.DataSource = Negocio.Activo.ListarDetalleCosteoMineral(Entidad.CanteraCosteo, .ActiveCell.Row.Cells(0).Value)
                        Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = True
                        Grid2.DisplayLayout.Bands(0).Columns("Moneda").Hidden = False
                        Grid2.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Empleado"
                        LblDetalle.Text = Grid1.ActiveRow.Cells("Descripcion").Value

                    Case Else

                        TabCosteo.Tabs("T02").Selected = True
                        Grid2.DataSource = Negocio.Activo.ListarDetalleCosteoMineral(Entidad.CanteraCosteo, 0)
                        Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = False
                        Grid2.DisplayLayout.Bands(0).Columns("Moneda").Hidden = False
                        LblDetalle.Text = Grid1.ActiveRow.Cells("Descripcion").Value

                End Select

                If Grid2.Rows.Count > 0 Then
                    Dim suma As Double = 0
                    For w = 0 To Grid2.Rows.Count - 1
                        suma = suma + Val(Grid2.Rows(w).Cells("Neto").Value)
                    Next

                    txtValor.Value = suma

                End If
                txtValor.Text = CDbl(txtValor.Text).ToString("###,##0.00#")
                'If Asc(e.KeyChar) = 13 Then
                '    With Grid1
                '        .PerformAction(ExitEditMode)
                '        .PerformAction(BelowCell)
                '        .PerformAction(EnterEditMode)
                '    End With
                'End If

            End With
        Catch ex As Exception
            MsgBox("NO se pudo cargar con exito el detalle", MsgBoxStyle.Critical, "Comacsa")
            Return
        End Try

    End Sub

    Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown, Grid4.KeyDown
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
                    If sender Is Grid4 Then
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        .ActiveRow.Cells("Variacion").Activate()
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    End If
                   
            End Select
        End With
    End Sub

    Sub _KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid1.KeyPress
        'Dim TotalMinerales As Decimal = Decimal.Zero
        'Dim CantMineral As Decimal = Decimal.Zero

        'If Grid1.ActiveRow Is Nothing Then Exit Sub
        'If Grid1.Rows.Count <= 0 Then Exit Sub

        'LblCantera.Text = ""
        'Try
        '    With Grid1


        '        Entidad.EmpleoLabor = New ETEmpleoLabor
        '        Negocio.Activo = New NGActivo
        '        CodigoCantera = Grid1.ActiveRow.Cells(Grid1.ActiveCell.Column.Index).Column.Key.ToString '.ActiveCell.Column.Key
        '        TotalMinerales = Ls_Canteras.Sum(Function(Rpt As ETCanteraCosteo) Rpt.Importe)
        '        CantMineral = Ls_Canteras.Where(AddressOf FiltrarCanteraCosteo2).Sum(Function(Rpt As ETCanteraCosteo) Rpt.Importe)
        '        With Entidad.CanteraCosteo
        '            .CodCia = Companhia
        '            .CodigoCantera = Grid1.ActiveCell.Column.Key.ToString
        '            .Ano = Cbo2.Value
        '            .Mes = CboMes.Value
        '            .NumeroPeriodo = CantMineral ' Grid1.Rows(0).Cells(Grid1.ActiveCell.Column.Key).Value
        '            .Importe = TotalMinerales
        '            .Tipo = Cbo4.Value
        '        End With
        '        txtValor.Value = 0
        '        LblDetalle.Text = ""
        '        LblCantera.Text = Grid1.ActiveCell.Column.Key.ToString
        '        Select Case .ActiveCell.Row.Cells(0).Value
        '            Case 1
        '                Select Case Asc(e.KeyChar)
        '                    Case 13
        '                        TabCosteo.Tabs("T02").Selected = True
        '                        Grid2.DataSource = Negocio.Activo.ListarDetalleCosteoMineral(Entidad.CanteraCosteo, 1)
        '                        Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = False
        '                        Grid2.DisplayLayout.Bands(0).Columns("Moneda").Hidden = True
        '                        LblDetalle.Text = Grid1.ActiveRow.Cells("Descripcion").Value
        '                End Select

        '            Case 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 19, 23, 29, 30, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43
        '                Select Case Asc(e.KeyChar)
        '                    Case 13
        '                        TabCosteo.Tabs("T02").Selected = True

        '                        Grid2.DataSource = Negocio.Activo.ListarDetalleCosteoMineral(Entidad.CanteraCosteo, .ActiveCell.Row.Cells(0).Value)
        '                        If Cbo4.Value = "1" Then
        '                            Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = True
        '                        ElseIf Cbo4.Value = "0" And .ActiveCell.Row.Cells(0).Value = 4 Then
        '                            Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = False
        '                            Grid2.DisplayLayout.Bands(0).Columns("Unidad").Header.Caption = "Tipo Tareo"
        '                            Grid2.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Equipo"
        '                        Else
        '                            Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = True
        '                            'Grid2.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción"
        '                        End If

        '                        Grid2.DisplayLayout.Bands(0).Columns("Moneda").Hidden = False
        '                        LblDetalle.Text = Grid1.ActiveRow.Cells("Descripcion").Value
        '                End Select

        '            Case 16, 17, 18, 20, 21
        '                Select Case Asc(e.KeyChar)
        '                    Case 13
        '                        TabCosteo.Tabs("T02").Selected = True
        '                        Grid2.DataSource = Negocio.Activo.ListarDetalleCosteoMineral(Entidad.CanteraCosteo, .ActiveCell.Row.Cells(0).Value)
        '                        Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = False
        '                        Grid2.DisplayLayout.Bands(0).Columns("Moneda").Hidden = False
        '                        LblDetalle.Text = Grid1.ActiveRow.Cells("Descripcion").Value
        '                End Select

        '            Case 27, 31, 32, 33
        '                Select Case Asc(e.KeyChar)
        '                    Case 13
        '                        TabCosteo.Tabs("T02").Selected = True
        '                        Grid2.DataSource = Negocio.Activo.ListarDetalleCosteoMineral(Entidad.CanteraCosteo, .ActiveCell.Row.Cells(0).Value)
        '                        Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = True
        '                        Grid2.DisplayLayout.Bands(0).Columns("Moneda").Hidden = False
        '                        Grid2.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Empleado"
        '                        LblDetalle.Text = Grid1.ActiveRow.Cells("Descripcion").Value
        '                End Select
        '            Case Else
        '                Select Case Asc(e.KeyChar)
        '                    Case 13
        '                        TabCosteo.Tabs("T02").Selected = True
        '                        Grid2.DataSource = Negocio.Activo.ListarDetalleCosteoMineral(Entidad.CanteraCosteo, 0)
        '                        Grid2.DisplayLayout.Bands(0).Columns("Unidad").Hidden = False
        '                        Grid2.DisplayLayout.Bands(0).Columns("Moneda").Hidden = False
        '                        LblDetalle.Text = Grid1.ActiveRow.Cells("Descripcion").Value
        '                End Select


        '        End Select

        '        If Grid2.Rows.Count > 0 Then
        '            Dim suma As Double = 0
        '            For w = 0 To Grid2.Rows.Count - 1
        '                suma = suma + Val(Grid2.Rows(w).Cells("Neto").Value)
        '            Next

        '            txtValor.Value = suma

        '        End If

        '        If Asc(e.KeyChar) = 13 Then
        '            With Grid1
        '                .PerformAction(ExitEditMode)
        '                .PerformAction(BelowCell)
        '                .PerformAction(EnterEditMode)
        '            End With
        '        End If

        '    End With
        'Catch ex As Exception
        '    MsgBox("NO se pudo cargar con exito el detalle", MsgBoxStyle.Critical, "Comacsa")
        '    Return
        'End Try

    End Sub

    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout
        If e Is Nothing Then Exit Sub
        If sender Is Grid1 Then
            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                If xCol.Key = "ID" Then
                    xCol.Hidden = True
                ElseIf xCol.Key = "Orden" Then
                    xCol.Hidden = True
                ElseIf xCol.Key = "Descripcion" Then
                    xCol.MinWidth = 250
                Else
                    xCol.Format = "n4"
                    xCol.MinWidth = 100
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    If Val(Cbo4.Value) = 3 Then

                        Select Case xCol.Key
                            Case "PorcentajeC"
                                xCol.Header.Caption = "Pje (%) - Contab."
                            Case "PorcentajeM"
                                xCol.Header.Caption = "Pje (%) - Minas"
                            Case "PorcentajeD"
                                xCol.Header.Caption = "Pje (%) - Dif."
                            Case Else
                                Select Case Mid(xCol.Key, 6, 1)
                                    Case "C"
                                        xCol.Header.Caption = Mid(xCol.Key, 1, 5) & " - Contab."
                                    Case "D"
                                        xCol.Header.Caption = Mid(xCol.Key, 1, 5) & " - Dif."
                                    Case "M"
                                        xCol.Header.Caption = Mid(xCol.Key, 1, 5) & " - Minas"
                                End Select
                        End Select

                    End If

                End If
                xCol.CellActivation = Activation.ActivateOnly
                
            Next
        End If

        If sender Is Grid2 Then
            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                xCol.CellActivation = Activation.ActivateOnly
            Next
        End If
    End Sub
#End Region
    Function ExisteCantera(ByVal Rpt As ETCanteraCosteo) As Boolean
        If Rpt.CodigoCantera = _CodCantera Then
            Return True
        Else
            Return False
        End If
    End Function

    Private _CodCantera As String = String.Empty

    Private Function ConfigurarReporteDataTable(ByVal DT_Local As DataTable) As DataTable
        Dim lResult As New DataTable
        Dim TipoCantera As String = String.Empty
        Dim Ls_CanteraP As New List(Of ETCanteraCosteo)
        Dim FilaTotal As DataRow
        For Each xCol As DataColumn In DT_Local.Columns
            lResult.Columns.Add(xCol.ColumnName, xCol.DataType)

            TipoCantera = Negocio.CanteraCosteo.GetOrigenCantera(xCol.ColumnName)
            If TipoCantera = "P" Or TipoCantera = "T" Or TipoCantera = "C" Then
                lResult.Columns.Add(("Ind_" & xCol.ColumnName), Type.GetType("System.Decimal"))
                Entidad.CanteraCosteo = Nothing
                Entidad.CanteraCosteo = New ETCanteraCosteo
                Entidad.CanteraCosteo.CodigoCantera = xCol.ColumnName
                Ls_CanteraP.Add(Entidad.CanteraCosteo)
            End If
        Next
        FilaTotal = Nothing
        For Each xRow As DataRow In DT_Local.Rows
            If xRow("Orden") = 1 Then
                FilaTotal = xRow
            End If
        Next

        For Each xRow As DataRow In DT_Local.Rows
            Dim Fila As DataRow
            Fila = lResult.Rows.Add
            For Each xCol As DataColumn In DT_Local.Columns
                Fila(xCol.ColumnName) = xRow(xCol.ColumnName)
                _CodCantera = xCol.ColumnName

                If Ls_CanteraP.Exists(AddressOf ExisteCantera) Then
                    If Fila("Orden") <= 44 And Fila("Orden") > 1 Then ' MOD 13/05/2014 If Fila("Orden") <= 42 And Fila("Orden") > 1 Then
                        If FilaTotal(xCol.ColumnName) = 0 Then
                            Fila(("Ind_" & xCol.ColumnName)) = Math.Round(0, 2)
                        Else
                            Fila(("Ind_" & xCol.ColumnName)) = Math.Round(((xRow(xCol.ColumnName) / FilaTotal(xCol.ColumnName))), 2)
                        End If
                    Else
                        Fila(("Ind_" & xCol.ColumnName)) = Math.Round(0, 2)
                    End If
                End If

            Next
        Next

        Return lResult
    End Function

    Public Sub Procesar()
        Dim DT_Procesar As DataTable = Nothing
        Cia.Focus()
        If Cbo2.Value < 2010 Then
            MsgBox("Debe seleccionar un PERIODO valido")
            Cbo2.Focus()
            Return
        End If
        If CboMes.Value < 1 Then
            MsgBox("Debe seleccionar un MES")
            CboMes.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Cbo4.Value) Then
            MsgBox("Debe de donde se obtendrá la información")
            Cbo4.Focus()
            Return
        End If

        'validar que todos los trabajadores tenga una categoria asignada
        Dim dtData As New DataTable
        dtData = CargaCategoriaTrabajador()
        For i As Int32 = 0 To dtData.Rows.Count-1
            If dtData.Rows(i)("IDCATEGORIA") = 0 Then
                MsgBox("Existen Trabajadores pendientes de asignar categoría", MsgBoxStyle.Exclamation, "Validación")
                Dim frm As New FrmCategoriaTrabajador
                frm.dtData = dtData
                frm.ShowDialog()
                Exit Sub
            End If
        Next

        Me.Cursor = Cursors.Cross
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Dim Fecha1 As Date
        Dim Fecha2 As DateTime
        Grid4.Update()
        Grid4.UpdateData()
        Dim Dt_Concepto As New DataTable

        If chkIncluirVariacion.Checked Then
            Dt_Concepto = Grid4.DataSource
        End If

        Fecha1 = CDate(("01/" & CboMes.Value & "/" & Cbo2.Value))
        Fecha2 = DateAdd(DateInterval.Month, 1, Fecha1)
        Fecha2 = DateAdd(DateInterval.Second, -1, Fecha2)
        Negocio.Activo = New NGActivo
        Entidad.CanteraCosteo = New ETCanteraCosteo
        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Mes = CboMes.Value
            .Ano = Cbo2.Value
            .Tipo = Cbo4.Value
            .User = User_Sistema
            .FechaInicio = Fecha1
            .FechaFin = Fecha2
            .Action = chkIncluirVariacion.Checked
            .DT_Lista = Dt_Concepto
        End With

        Grid3.DataSource = Nothing
        Grid1.DataSource = Nothing
        Try
            Grid3.DataSource = Negocio.Activo.CosteoMineral_ValidarBilleteSinCantera(Entidad.CanteraCosteo)

            If Grid3.Rows.Count > 0 And Cbo4.Value <> 4 Then

                Dim Libro As New Infragistics.Excel.Workbook
                Dim Path As String = String.Empty
                Dim Archivo As String = String.Empty

                MsgBox("Existen Billetes de Ingreso de Minerales sin Cantera", MsgBoxStyle.Exclamation, msgComacsa)

                Path = My.Application.Info.DirectoryPath & "\Reporte de Costeo de Minerales"
                Archivo = Path & "\Billetes Sin Cantera - " & CboMes.Text & " DEL " & Cbo2.Text & ".xls"

                UltraGridExcelExporter1.Export(Grid3, Libro, 5, 0)

                Libro.Worksheets(0).Name = "Costeo de Minerales"
                Libro.Worksheets(0).Rows(0).Cells(0).Value = Cia.Text
                Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Height = 160
                Libro.Worksheets(0).Rows(2).Cells(0).Value = "BILLETES SIN CANTERA - " & CboMes.Text & " DEL " & Cbo2.Text
                Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Default
                Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Height = 260

                Try
                    Libro.Save(Archivo)

                    Call Iniciar_Excel(Archivo)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                Libro = Nothing
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Me.Cursor = Cursors.Default

                Exit Sub
            End If

            If Cbo4.Value = 0 OrElse Cbo4.Value = 1 Then
                DT_Procesar = Negocio.Activo.ListarCosteoMineral_Save(Entidad.CanteraCosteo)
                Grid1.DataSource = ConfigurarReporteDataTable(DT_Procesar)
            ElseIf Cbo4.Value = 4 Then
                DT_Procesar = Negocio.Activo.ListarCosteoMineral_Minas(Entidad.CanteraCosteo)
                Grid1.DataSource = DT_Procesar 'ConfigurarReporteDataTable(DT_Procesar)
                Grid1.DisplayLayout.Bands(0).Columns("ID").Hidden = True
                Grid1.DisplayLayout.Bands(0).Columns("ORDEN").Hidden = True
                Grid1.DisplayLayout.Bands(0).Columns("NOMBRE").CellAppearance.TextHAlign = HAlign.Left
                Grid1.DisplayLayout.Bands(0).Columns("DESCRIPCION").CellAppearance.TextHAlign = HAlign.Left
                Grid1.DisplayLayout.Bands(0).Columns("NOMBRE").Width = 180
                Grid1.DisplayLayout.Bands(0).Columns("DESCRIPCION").Width = 180
            Else
                Grid1.DataSource = Negocio.Activo.ListarCosteoMineral_Save(Entidad.CanteraCosteo)
            End If

            Ls_Canteras = Nothing
            Ls_Canteras = New List(Of ETCanteraCosteo)
            Entidad.CanteraCosteo = New ETCanteraCosteo
            With Entidad.CanteraCosteo
                .CodCia = Companhia
                .Mes = CboMes.Value
                .Ano = Cbo2.Value
                .Tipo = Cbo4.Value
                .User = User_Sistema
                If Val(Cbo4.Value) = 3 Then
                    .TipoTrabajo = "3"
                Else
                    .TipoTrabajo = "1"
                End If
            End With

            Entidad.MyLista = Negocio.Activo.ListarCanteras_CosteoMineral(Entidad.CanteraCosteo)
            If Entidad.MyLista.Validacion Then
                Ls_Canteras = Entidad.MyLista.Ls_CanteraCosteo
            End If

            If Val(Cbo4.Value) = 2 Then
                Ls_CosteoMineral = Nothing
                Ls_CosteoMineral = New List(Of ETCanteraCosteo)
                For Each xRow As UltraGridRow In Grid1.Rows
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .CodigoCantera = xRow.Cells("Cod_Cantera").Value.ToString.TrimEnd
                        .ID = xRow.Cells("ID").Value.ToString.TrimEnd
                        .Importe = xRow.Cells("Valor").Value
                    End With
                    Ls_CosteoMineral.Add(Entidad.CanteraCosteo)
                Next

                Ls_Conceptos = Nothing
                Ls_Conceptos = New List(Of ETCanteraCosteo)
                Entidad.CanteraCosteo = New ETCanteraCosteo
                With Entidad.CanteraCosteo
                    .CodCia = Companhia
                    .Mes = CboMes.Value
                    .Ano = Cbo2.Value
                    .Tipo = Cbo4.Value
                    .User = User_Sistema
                    .TipoTrabajo = "2"
                End With

                Entidad.MyLista = Negocio.Activo.ListarCanteras_CosteoMineral(Entidad.CanteraCosteo)
                If Entidad.MyLista.Validacion Then
                    Ls_Conceptos = Entidad.MyLista.Ls_CanteraCosteo
                End If

            End If

            Try
                xTotalVentas = Negocio.Activo.ObtenerVentasMesual(Entidad.CanteraCosteo)
            Catch ex As Exception
                xTotalVentas = 0
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
            Grid1.DataSource = Nothing
        End Try
        xGastosCantera = 0
        If Val(Cbo4.Value) <> 2 Then
            Call Configurar()
        End If

        'Call CalcularTotalPorcentaje()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Me.Cursor = Cursors.Default

    End Sub

   
    Private Sub FormatoCelda(ByVal RANGO As String, ByVal TipoLetra As String, _
    ByVal Negrita As Boolean, ByVal TamañoLetra As Integer, Optional ByVal color As Integer = 0, _
    Optional ByVal Linea As Integer = 0, Optional ByVal Relleno As Integer = 0, _
    Optional ByVal AjustarTexto As Boolean = False, Optional ByVal Alinear As Long = 0, _
    Optional ByVal NumeroFormato As String = "", Optional ByVal Cursiva As Boolean = False, _
    Optional ByVal Subtrayado As Boolean = False)



        With Obj_Hoja.range(RANGO)
            .Font.Name = TipoLetra
            .Font.Bold = Negrita
            .Font.Size = TamañoLetra
            .Font.Italic = Cursiva
            .Font.underline = Subtrayado
            If Val(color) > 0 Then .Font.ColorIndex = color
            If Val(Linea) > 0 Then .Borders.LineStyle = Linea
            If Val(Relleno) > 0 Then .Interior.ColorIndex = Relleno
            If Val(Alinear) <> 0 Then .HorizontalAlignment = Alinear
            .VerticalAlignment = Alineacion.Centrado
            .WrapText = AjustarTexto
            If Not (String.IsNullOrEmpty(NumeroFormato)) Then .NumberFormat = NumeroFormato

        End With
    End Sub

    Function FiltrarCanteraCosteo(ByVal Rpt As ETCanteraCosteo) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.CodigoCantera.Trim = CodigoCantera.Trim And Val(Rpt.ID) = IDConcepto Then lResult = Boolean.TrueString

        Return lResult

    End Function

    Function FiltrarCanteraCosteo2(ByVal Rpt As ETCanteraCosteo) As Boolean
        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.CodigoCantera = CodigoCantera Then lResult = Boolean.TrueString

        Return lResult

    End Function

    Private Sub Excel_CM2()
        Try
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim k As Integer = 0

            Dim Letra1 As String = String.Empty
            Dim Letra2 As String = String.Empty
            Dim Total As Decimal = Decimal.Zero
            Dim Cod_Cantera As String = String.Empty
            Dim CosteoMineral45 As Decimal = Decimal.Zero
            Dim CosteoMineral24 As Decimal = Decimal.Zero
            Dim CosteoMineral1 As Decimal = Decimal.Zero

            If Ls_Canteras.Count <= 0 Then Exit Sub

            Obj_Excel = CreateObject("Excel.Application")
            Obj_Libro = Obj_Excel.Workbooks.Add()
            Obj_Libro.Sheets(1).Name = "Costeo de Minerales"
            Obj_Hoja = Obj_Libro.Sheets(1)
            Obj_Hoja.Activate()
            Obj_Hoja.Columns("A").ColumnWidth = 38.43

            Fila = 1
            Obj_Hoja.Cells(Fila, 1) = Cia.Text
            Call FormatoCelda("A" & CStr(Fila) & ":A" & CStr(Fila), "Arial", False, 8)
            Fila = Fila + 2
            Obj_Hoja.Cells(Fila, 1) = "COSTEO DE MINERALES PERIODO " & CboMes.Text & " DEL " & Cbo2.Text & " - DPTO. MINAS (Sin Distribuir)"
            Call FormatoCelda("A" & CStr(Fila) & ":A" & CStr(Fila), "Arial", True, 13)

            'Microsoft Sans Serif
            Dim Ls_Temp As New List(Of ETCanteraCosteo)
            Fila = Fila + 2
            'Obj_Excel.visible = True
            Obj_Hoja.Rows(Fila).RowHeight = 33
            Letra1 = "A"
            Letra2 = Letra_ColumnaExcel(Ls_Canteras.Count + 2)
            Call FormatoCelda(Letra1 & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Arial", True, 8, 1, 1, 15, True, Alineacion.Centrado)
            Call FormatoCelda("A" & CStr(Fila + 1) & ":" & Letra2 & CStr(Fila + 1), "Arial Narrow", True, 10, 1, 1, 15, True, Alineacion.Centrado, "@")

            For i = 1 To Ls_Canteras.Count
                For j = 5 To 6
                    If j = 5 Then
                        Obj_Hoja.Cells(j, i + 1) = Ls_Canteras(i - 1).Descripcion
                    Else
                        Obj_Hoja.Cells(j, i + 1) = Ls_Canteras(i - 1).CodigoCantera
                    End If
                Next
            Next

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 1) = "Descripción"
            Obj_Hoja.Cells(Fila, Ls_Canteras.Count + 2) = "Total"
            Call FormatoCelda("B" & CStr(Fila + 1) & ":" & Letra2 & CStr(Fila + Ls_Conceptos.Count), "Microsoft Sans Serif", False, 8, 1, 1, 0, False, Alineacion.Derecha, "#,##0.0000")
            For i = 0 To Ls_Conceptos.Count - 1
                Fila = Fila + 1

                Total = 0
                Obj_Hoja.Cells(Fila, 1) = Ls_Conceptos(i).Descripcion

                Select Case Val(Ls_Conceptos(i).CodigoCantera)
                    Case 1
                        Call FormatoCelda("A" & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Microsoft Sans Serif", True, 8, 10, 1, , , , , True)
                    Case 2
                        Call FormatoCelda("A" & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Microsoft Sans Serif", True, 8, 5, 1, , , , , True, True)
                    Case 24
                        Call FormatoCelda("A" & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Microsoft Sans Serif", True, 8, 5, 1, , , , , True)
                    Case 25
                        Call FormatoCelda("A" & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Microsoft Sans Serif", True, 8, 22, 1, , , , , True, True)
                    Case 44
                        Call FormatoCelda("A" & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Microsoft Sans Serif", True, 8, 22, 1, , , , , True)
                    Case 45
                        Call FormatoCelda("A" & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Microsoft Sans Serif", True, 8, 10, 1, , , , , True)
                    Case 46
                        Call FormatoCelda("A" & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Microsoft Sans Serif", True, 8, 33, 1, , , , , True)
                    Case 47
                        Call FormatoCelda("A" & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Microsoft Sans Serif", True, 8, 44, 1, , , , , True)
                    Case 48
                        Call FormatoCelda("A" & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Microsoft Sans Serif", True, 8, 1, 1, , , , , True)
                End Select

                For j = 1 To Ls_Canteras.Count
                    Cod_Cantera = Obj_Hoja.Cells(6, j + 1).Value
                    CodigoCantera = Cod_Cantera
                    IDConcepto = Val(Ls_Conceptos(i).CodigoCantera)
                    Try
                        'If CodigoCantera.Trim = "0618" Then
                        'MsgBox(CodigoCantera)
                        'End If
                        Ls_Temp = Ls_CosteoMineral.Where(AddressOf FiltrarCanteraCosteo).ToList
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    k = 0

                    If Ls_Temp.Count > 0 Then
                        Obj_Hoja.Cells(Fila, j + 1) = Ls_Temp(k).Importe
                        Total = Total + Ls_Temp(k).Importe

                    End If

                Next
                Select Case Val(Ls_Conceptos(i).CodigoCantera)
                    Case 1
                        CosteoMineral1 = Total
                    Case 24
                        CosteoMineral24 = Total
                    Case 45
                        xGastosCantera = Total
                        CosteoMineral45 = Total
                    Case 47
                        If CosteoMineral1 <> 0 Then
                            Total = CosteoMineral45 / CosteoMineral1
                        Else
                            Total = 0
                        End If
                    Case 48
                        If CosteoMineral1 <> 0 Then
                            Total = CosteoMineral24 / CosteoMineral1
                        Else
                            Total = 0
                        End If

                End Select

                Obj_Hoja.Cells(Fila, Ls_Canteras.Count + 2) = Total
            Next

            Fila = Fila + 3
            Call FormatoCelda("A" & CStr(Fila) & ":A" & CStr(Fila + 2), "Arial", True, 8)
            Call FormatoCelda("B" & CStr(Fila) & ":B" & CStr(Fila + 2), "Arial", False, 8, , , , , Alineacion.Derecha, "#,##0.0000")
            Obj_Hoja.Cells(Fila, 1) = "TOTAL GASTOS DE CANTERAS ( G )"
            Obj_Hoja.Cells(Fila, 2) = xGastosCantera

            Call FormatoCelda("A" & CStr(Fila) & ":A" & CStr(Fila), "Arial", True, 8)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 1) = "TOTAL VENTAS DEL MES ( V )"
            Obj_Hoja.Cells(Fila, 2) = xTotalVentas
            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 1) = "G / V"
            Obj_Hoja.Cells(Fila, 2) = xTotalVentas

            If xTotalVentas <> 0 Then
                Obj_Hoja.Cells(Fila, 2) = xGastosCantera / xTotalVentas
            Else
                Obj_Hoja.Cells(Fila, 2) = 0
            End If

            Obj_Hoja = Obj_Libro.Sheets(1)
            Obj_Hoja.Activate()

            Obj_Excel.visible = True

            Obj_Hoja = Nothing
            Obj_Libro = Nothing
            Obj_Excel = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Excel()
        Dim RPje As Integer = 0
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Long = 0
        Dim Total As Decimal = Decimal.Zero
        Dim Path As String = String.Empty
        Dim Archivo As String = String.Empty
        Dim Cod_Cantera As String = String.Empty
        Dim Descrip_Cantera As String = String.Empty
        'Dim Libro As New Infragistics.Excel.Workbook

        Dim Libro As New Infragistics.Excel.Workbook

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        If TabCosteo.Tabs("T01").Selected = True Then
            If Grid1.Rows.Count <= 0 Then
                MsgBox("No hay Datos que Exportar", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            'Reporte de Costeo de Minerales
            Path = My.Application.Info.DirectoryPath & "\Reporte de Costeo de Minerales"
            Select Case Val(Cbo4.Value)
                Case 1
                    Archivo = Path & "\Costeo de Minerales - " & CboMes.Text & " DEL " & Cbo2.Text & " - CONTABILIDAD.xls"
                Case 0
                    Archivo = Path & "\Costeo de Minerales - " & CboMes.Text & " DEL " & Cbo2.Text & " - DPTO. MINAS(Distribuido).xls"
                Case 2
                    Archivo = Path & "\Costeo de Minerales - " & CboMes.Text & " DEL " & Cbo2.Text & " - DPTO. MINAS(Sin Distribuir).xls"
                Case Else
                    Archivo = Path & "\Costeo de Minerales - " & CboMes.Text & " DEL " & Cbo2.Text & ".xls"
            End Select

            If Val(Cbo4.Value) <> 2 Then
                UltraGridExcelExporter1.Export(Grid1, Libro, 5, 0)
            Else
                Call Excel_CM2()
                Libro = Nothing
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Exit Sub
            End If

            Libro.Worksheets(0).Name = "Costeo de Minerales"
            Libro.Worksheets(0).Rows(0).Cells(0).Value = Cia.Text
            Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Height = 160

            Select Case Val(Cbo4.Value)
                Case 1
                    Libro.Worksheets(0).Rows(2).Cells(0).Value = "COSTEO DE MINERALES PERIODO " & CboMes.Text & " DEL " & Cbo2.Text & " - CONTABILIDAD"
                Case 0
                    Libro.Worksheets(0).Rows(2).Cells(0).Value = "COSTEO DE MINERALES PERIODO " & CboMes.Text & " DEL " & Cbo2.Text & " - DPTO. MINAS (Distribuido)"
                Case 2
                    Libro.Worksheets(0).Rows(2).Cells(0).Value = "COSTEO DE MINERALES PERIODO " & CboMes.Text & " DEL " & Cbo2.Text & " - DPTO. MINAS (Sin Distribuir)"
                Case 4
                    Libro.Worksheets(0).Rows(2).Cells(0).Value = "COSTEO DE MINERALES PERIODO " & CboMes.Text & " DEL " & Cbo2.Text & " - DPTO. MINAS"
                Case Else
                    Libro.Worksheets(0).Rows(2).Cells(0).Value = "COSTEO DE MINERALES PERIODO " & CboMes.Text & " DEL " & Cbo2.Text & " - CONTABILIDAD VS DPTO. MINAS (Distribuido)"
            End Select

            Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Center
            Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Height = 260
            'Libro.Worksheets(0).Rows(5).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            Libro.Worksheets(0).Rows(4).Height = 660



            If Val(Cbo4.Value) <> 2 Then

                If Grid1.DisplayLayout.Bands(0).Columns.Count > 4 Then
                    For j = 0 To Grid1.DisplayLayout.Bands(0).Columns.Count - 1
                        RPje = 0
                        If Libro.Worksheets(0).Rows(5).Cells(j).Value IsNot Nothing Then
                            If Not (Libro.Worksheets(0).Rows(5).Cells(j).Value = "Descripcion" OrElse _
                             Mid(Libro.Worksheets(0).Rows(5).Cells(j).Value, 1, 7) = "Pje (%)") Then
                                Cod_Cantera = Mid(Libro.Worksheets(0).Rows(5).Cells(j).Value, 1, 5)
                                If Len(Cod_Cantera.TrimStart.TrimEnd) >= 3 Then
                                    If (Cod_Cantera <> "Total") And Val(Cbo4.Value) <> 4 Then
                                        If Mid(Libro.Worksheets(0).Rows(5).Cells(j).Value, 5, 5) = Mid(Libro.Worksheets(0).Rows(5).Cells(j - 1).Value, 1, 5) Then
                                            Descrip_Cantera = "Indicadores"
                                            RPje = 1
                                        Else
                                            Negocio.CanteraCosteo = New NGCanteraCosteo
                                            Descrip_Cantera = Negocio.CanteraCosteo.GetDescripcionCantera(Cod_Cantera)
                                            RPje = 0
                                        End If

                                    ElseIf Val(Cbo4.Value) = 4 Then
                                        Negocio.CanteraCosteo = New NGCanteraCosteo
                                        Descrip_Cantera = Negocio.CanteraCosteo.GetDescripcionCantera(Cod_Cantera)
                                        RPje = 0
                                    Else
                                        RPje = 0
                                        Descrip_Cantera = "Total"
                                    End If

                                    If RPje = 0 Then
                                        Libro.Worksheets(0).Rows(4).Cells(j).Value = Descrip_Cantera

                                        If Cbo4.Value <> 3 Then
                                            With Libro.Worksheets(0).Rows(4).Cells(j).CellFormat
                                                .FillPatternForegroundColor = Color.LightGray

                                                .Font.Bold = ExcelDefaultableBoolean.True
                                                .Font.Height = 160
                                                .Alignment = HorizontalCellAlignment.Center
                                                .VerticalAlignment = VerticalCellAlignment.Center
                                                .WrapText = ExcelDefaultableBoolean.True
                                                .TopBorderColor = Color.LightSlateGray
                                                .TopBorderStyle = CellBorderLineStyle.Thin
                                                .BottomBorderColor = Color.LightSlateGray
                                                .BottomBorderStyle = CellBorderLineStyle.Thin
                                                .RightBorderColor = Color.LightSlateGray
                                                .RightBorderStyle = CellBorderLineStyle.Thin
                                                .LeftBorderColor = Color.LightSlateGray
                                                .LeftBorderStyle = CellBorderLineStyle.Thin
                                            End With
                                        Else
                                            With Libro.Worksheets(0).MergedCellsRegions.Add(4, j, 4, j + 2).CellFormat
                                                .FillPatternForegroundColor = Color.LightGray
                                                .Font.Bold = ExcelDefaultableBoolean.True
                                                .Font.Height = 160
                                                .Alignment = HorizontalCellAlignment.Center
                                                .VerticalAlignment = VerticalCellAlignment.Center
                                                .WrapText = ExcelDefaultableBoolean.True
                                                .TopBorderColor = Color.LightSlateGray
                                                .TopBorderStyle = CellBorderLineStyle.Thin
                                                .BottomBorderColor = Color.LightSlateGray
                                                .BottomBorderStyle = CellBorderLineStyle.Thin
                                                .RightBorderColor = Color.LightSlateGray
                                                .RightBorderStyle = CellBorderLineStyle.Thin
                                                .LeftBorderColor = Color.LightSlateGray
                                                .LeftBorderStyle = CellBorderLineStyle.Thin
                                            End With
                                            j = j + 2
                                        End If

                                    Else


                                        If Cbo4.Value <> 3 Then
                                            Libro.Worksheets(0).Rows(5).Cells(j).Value = Descrip_Cantera
                                            With Libro.Worksheets(0).MergedCellsRegions.Add(4, j - 1, 4, j).CellFormat
                                                .FillPatternForegroundColor = Color.LightGray
                                                .Font.Bold = ExcelDefaultableBoolean.True
                                                .Font.Height = 160
                                                .Alignment = HorizontalCellAlignment.Center
                                                .VerticalAlignment = VerticalCellAlignment.Center
                                                .WrapText = ExcelDefaultableBoolean.True
                                                .TopBorderColor = Color.LightSlateGray
                                                .TopBorderStyle = CellBorderLineStyle.Thin
                                                .BottomBorderColor = Color.LightSlateGray
                                                .BottomBorderStyle = CellBorderLineStyle.Thin
                                                .RightBorderColor = Color.LightSlateGray
                                                .RightBorderStyle = CellBorderLineStyle.Thin
                                                .LeftBorderColor = Color.LightSlateGray
                                                .LeftBorderStyle = CellBorderLineStyle.Thin
                                            End With
                                        Else
                                            Libro.Worksheets(0).Rows(4).Cells(j).Value = Descrip_Cantera

                                            With Libro.Worksheets(0).MergedCellsRegions.Add(4, j, 4, j + 2).CellFormat
                                                .FillPatternForegroundColor = Color.LightGray
                                                .Font.Bold = ExcelDefaultableBoolean.True
                                                .Font.Height = 160
                                                .Alignment = HorizontalCellAlignment.Center
                                                .VerticalAlignment = VerticalCellAlignment.Center
                                                .WrapText = ExcelDefaultableBoolean.True
                                                .TopBorderColor = Color.LightSlateGray
                                                .TopBorderStyle = CellBorderLineStyle.Thin
                                                .BottomBorderColor = Color.LightSlateGray
                                                .BottomBorderStyle = CellBorderLineStyle.Thin
                                                .RightBorderColor = Color.LightSlateGray
                                                .RightBorderStyle = CellBorderLineStyle.Thin
                                                .LeftBorderColor = Color.LightSlateGray
                                                .LeftBorderStyle = CellBorderLineStyle.Thin
                                            End With
                                            j = j + 2
                                        End If

                                    End If

                                End If
                            Else
                                If Mid(Libro.Worksheets(0).Rows(5).Cells(j).Value, 1, 7) = "Pje (%)" Then
                                    Libro.Worksheets(0).Rows(4).Cells(j).Value = "Pje (%)"
                                    If Cbo4.Value <> 3 Then
                                        With Libro.Worksheets(0).Rows(4).Cells(j).CellFormat
                                            .FillPatternForegroundColor = Color.LightGray
                                            .Font.Bold = ExcelDefaultableBoolean.True
                                            .Font.Height = 160
                                            .Alignment = HorizontalCellAlignment.Center
                                            .VerticalAlignment = VerticalCellAlignment.Center
                                            .WrapText = ExcelDefaultableBoolean.True
                                            .TopBorderColor = Color.LightSlateGray
                                            .TopBorderStyle = CellBorderLineStyle.Thin
                                            .BottomBorderColor = Color.LightSlateGray
                                            .BottomBorderStyle = CellBorderLineStyle.Thin
                                            .RightBorderColor = Color.LightSlateGray
                                            .RightBorderStyle = CellBorderLineStyle.Thin
                                            .LeftBorderColor = Color.LightSlateGray
                                            .LeftBorderStyle = CellBorderLineStyle.Thin
                                        End With
                                    Else

                                        With Libro.Worksheets(0).MergedCellsRegions.Add(4, j, 4, j + 2).CellFormat
                                            .FillPatternForegroundColor = Color.LightGray
                                            .Font.Bold = ExcelDefaultableBoolean.True
                                            .Font.Height = 160
                                            .Alignment = HorizontalCellAlignment.Center
                                            .VerticalAlignment = VerticalCellAlignment.Center
                                            .WrapText = ExcelDefaultableBoolean.True
                                            .TopBorderColor = Color.LightSlateGray
                                            .TopBorderStyle = CellBorderLineStyle.Thin
                                            .BottomBorderColor = Color.LightSlateGray
                                            .BottomBorderStyle = CellBorderLineStyle.Thin
                                            .RightBorderColor = Color.LightSlateGray
                                            .RightBorderStyle = CellBorderLineStyle.Thin
                                            .LeftBorderColor = Color.LightSlateGray
                                            .LeftBorderStyle = CellBorderLineStyle.Thin
                                        End With
                                        j = j + 2
                                    End If


                                End If
                            End If
                        End If

                    Next
                End If

                xGastosCantera = 0
                xGastosCanteraM = 0

                For j = 5 To Grid1.Rows.Count - 1 + 6
                    If j = 5 Then
                        For i = 1 To Grid1.DisplayLayout.Bands(0).Columns.Count - 1
                            Libro.Worksheets(0).Rows(j).Cells(i - 1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        Next
                    Else
                        For i = 2 To Grid1.DisplayLayout.Bands(0).Columns.Count - 1
                            Libro.Worksheets(0).Rows(j).Cells(i - 1).CellFormat.FormatString = "#,##0.0000"
                            If Libro.Worksheets(0).Rows(5).Cells(i - 1).Value = "Indicadores" Then
                                Libro.Worksheets(0).Rows(j).Cells(i - 1).CellFormat.FormatString = "#,##0.00"
                                Libro.Worksheets(0).Rows(j).Cells(i - 1).CellFormat.FillPatternForegroundColor = Color.LightYellow
                            End If
                        Next
                    End If
                Next

                For Each xRow As UltraGridRow In Grid1.Rows
                    If Val(xRow.Cells("ID").Value) = 45 And Val(Cbo4.Value) <> 4 Then
                        If Val(Cbo4.Value) <> 3 Then
                            xGastosCantera = Val(xRow.Cells("Total").Value)
                        Else
                            xGastosCantera = Val(xRow.Cells("TotalC").Value)
                            xGastosCanteraM = Val(xRow.Cells("TotalM").Value)

                        End If

                    End If
                Next

                '-------------
            Else
                If Ls_Canteras.Count <= 0 Then Exit Sub
                Dim Ls_Temp As New List(Of ETCanteraCosteo)
                Ls_Temp = Ls_CosteoMineral
                For i = 1 To Ls_Canteras.Count
                    For j = 4 To 5
                        If j = 4 Then
                            Libro.Worksheets(0).Rows(j).Cells(i).Value = Ls_Canteras(i - 1).Descripcion
                        Else
                            Libro.Worksheets(0).Rows(j).Cells(i).Value = Ls_Canteras(i - 1).CodigoCantera
                        End If
                        'Libro.Worksheets(0).Rows(j).Cells(i).Formula="=SUMA(A2:A20)"
                        With Libro.Worksheets(0).Rows(j).Cells(i).CellFormat
                            .FillPatternForegroundColor = Color.LightGray
                            .Font.Bold = ExcelDefaultableBoolean.True
                            If j = 4 Then
                                .Font.Height = 160
                            End If
                            .Alignment = HorizontalCellAlignment.Center
                            .VerticalAlignment = VerticalCellAlignment.Center
                            .WrapText = ExcelDefaultableBoolean.True
                            .TopBorderColor = Color.LightSlateGray
                            .TopBorderStyle = CellBorderLineStyle.Thin
                            .BottomBorderColor = Color.LightSlateGray
                            .BottomBorderStyle = CellBorderLineStyle.Thin
                            .RightBorderColor = Color.LightSlateGray
                            .RightBorderStyle = CellBorderLineStyle.Thin
                            .LeftBorderColor = Color.LightSlateGray
                            .LeftBorderStyle = CellBorderLineStyle.Thin
                        End With
                    Next
                Next

                Libro.Worksheets(0).Rows(5).Cells(Ls_Canteras.Count + 1).Value = "Total"
                With Libro.Worksheets(0).Rows(5).Cells(Ls_Canteras.Count + 1).CellFormat
                    .Font.Height = 160
                    .TopBorderColor = Color.LightSlateGray
                    .TopBorderStyle = CellBorderLineStyle.Thin
                    .BottomBorderColor = Color.LightSlateGray
                    .BottomBorderStyle = CellBorderLineStyle.Thin
                    .RightBorderColor = Color.LightSlateGray
                    .RightBorderStyle = CellBorderLineStyle.Thin
                    .LeftBorderColor = Color.LightSlateGray
                    .LeftBorderStyle = CellBorderLineStyle.Thin
                End With

                Libro.Worksheets(0).Rows(5).Cells(0).Value = "Descripción"
                With Libro.Worksheets(0).Rows(5).Cells(0).CellFormat
                    .FillPatternForegroundColor = Color.LightGray
                    .Font.Bold = ExcelDefaultableBoolean.True
                    .Alignment = HorizontalCellAlignment.Center
                    .VerticalAlignment = VerticalCellAlignment.Center
                    .WrapText = ExcelDefaultableBoolean.True
                    .TopBorderColor = Color.LightSlateGray
                    .TopBorderStyle = CellBorderLineStyle.Thin
                    .BottomBorderColor = Color.LightSlateGray
                    .BottomBorderStyle = CellBorderLineStyle.Thin
                    .RightBorderColor = Color.LightSlateGray
                    .RightBorderStyle = CellBorderLineStyle.Thin
                    .LeftBorderColor = Color.LightSlateGray
                    .LeftBorderStyle = CellBorderLineStyle.Thin
                End With

                For i = 0 To Ls_Conceptos.Count - 1
                    Total = 0
                    Libro.Worksheets(0).Rows(i + 6).Cells(0).Value = Ls_Conceptos(i).Descripcion

                    Select Case Val(Ls_Conceptos(i).CodigoCantera)
                        Case 1
                            With Libro.Worksheets(0).Rows(i + 6).CellFormat
                                .Font.Color = Color.Green
                                .Font.Bold = ExcelDefaultableBoolean.True
                                .Font.Italic = ExcelDefaultableBoolean.True
                            End With
                        Case 2, 24
                            With Libro.Worksheets(0).Rows(i + 6).CellFormat
                                .Font.Color = Color.Blue
                                .Font.Bold = ExcelDefaultableBoolean.True
                                .Font.Italic = ExcelDefaultableBoolean.True
                            End With

                        Case 25, 44
                            With Libro.Worksheets(0).Rows(i + 6).CellFormat
                                .Font.Color = Color.LightCoral
                                .Font.Bold = ExcelDefaultableBoolean.True
                                .Font.Italic = ExcelDefaultableBoolean.True
                            End With
                        Case 45
                            With Libro.Worksheets(0).Rows(i + 6).CellFormat
                                .Font.Color = Color.Green
                                .Font.Bold = ExcelDefaultableBoolean.True
                                .Font.Italic = ExcelDefaultableBoolean.True
                            End With
                        Case 46
                            With Libro.Worksheets(0).Rows(i + 6).CellFormat
                                .Font.Color = Color.DodgerBlue
                                .Font.Bold = ExcelDefaultableBoolean.True
                                .Font.Italic = ExcelDefaultableBoolean.True
                            End With
                        Case 47
                            With Libro.Worksheets(0).Rows(i + 6).CellFormat
                                .Font.Color = Color.Orange
                                .Font.Bold = ExcelDefaultableBoolean.True
                                .Font.Italic = ExcelDefaultableBoolean.True
                            End With
                        Case 48
                            With Libro.Worksheets(0).Rows(i + 6).CellFormat
                                .Font.Color = Color.Black
                                .Font.Bold = ExcelDefaultableBoolean.True
                                .Font.Italic = ExcelDefaultableBoolean.True
                            End With

                    End Select

                    With Libro.Worksheets(0).Rows(i + 6).Cells(0).CellFormat
                        Select Case Val(Ls_Conceptos(i).CodigoCantera)
                            Case 2, 25
                                .Font.UnderlineStyle = FontUnderlineStyle.Single
                        End Select
                        .Font.Height = 160
                        .TopBorderColor = Color.LightSlateGray
                        .TopBorderStyle = CellBorderLineStyle.Thin
                        .BottomBorderColor = Color.LightSlateGray
                        .BottomBorderStyle = CellBorderLineStyle.Thin
                        .RightBorderColor = Color.LightSlateGray
                        .RightBorderStyle = CellBorderLineStyle.Thin
                        .LeftBorderColor = Color.LightSlateGray
                        .LeftBorderStyle = CellBorderLineStyle.Thin
                    End With

                    For j = 1 To Ls_Canteras.Count
                        Cod_Cantera = Libro.Worksheets(0).Rows(5).Cells(j).Value
                        CodigoCantera = Cod_Cantera
                        IDConcepto = Val(Ls_Conceptos(i).CodigoCantera)
                        Try
                            Ls_Temp = Ls_CosteoMineral.Where(AddressOf FiltrarCanteraCosteo).ToList
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        k = 0


                        If Ls_Temp.Count > 0 Then
                            Libro.Worksheets(0).Rows(i + 6).Cells(j).Value = Ls_Temp(k).Importe
                            Total = Total + Ls_Temp(k).Importe
                            With Libro.Worksheets(0).Rows(5).Cells(0).CellFormat
                                .Font.Height = 160
                                .TopBorderColor = Color.LightSlateGray
                                .TopBorderStyle = CellBorderLineStyle.Thin
                                .BottomBorderColor = Color.LightSlateGray
                                .BottomBorderStyle = CellBorderLineStyle.Thin
                                .RightBorderColor = Color.LightSlateGray
                                .RightBorderStyle = CellBorderLineStyle.Thin
                                .LeftBorderColor = Color.LightSlateGray
                                .LeftBorderStyle = CellBorderLineStyle.Thin
                                .FormatString = "#,##0.0000"
                            End With
                        End If

                    Next
                    Libro.Worksheets(0).Rows(i + 6).Cells(Ls_Canteras.Count + 1).Value = Total

                    With Libro.Worksheets(0).Rows(5).Cells(0).CellFormat
                        .Font.Height = 160
                        .TopBorderColor = Color.LightSlateGray
                        .TopBorderStyle = CellBorderLineStyle.Thin
                        .BottomBorderColor = Color.LightSlateGray
                        .BottomBorderStyle = CellBorderLineStyle.Thin
                        .RightBorderColor = Color.LightSlateGray
                        .RightBorderStyle = CellBorderLineStyle.Thin
                        .LeftBorderColor = Color.LightSlateGray
                        .LeftBorderStyle = CellBorderLineStyle.Thin
                        .FormatString = "#,##0.0000"
                    End With

                Next
            End If

            If Val(Cbo4.Value) = 3 Then
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 8).Cells(1).Value = "Contabilidad"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 8).Cells(2).Value = "Minas"

                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 9).Cells(0).Value = "TOTAL GASTOS DE CANTERAS ( G )"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 9).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 9).Cells(1).CellFormat.FormatString = "#,##0.0000"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 9).Cells(1).Value = xGastosCantera 'FormatNumber(xGastosCantera, 4)
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 9).Cells(2).CellFormat.FormatString = "#,##0.0000"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 9).Cells(2).Value = xGastosCanteraM 'FormatNumber(xGastosCantera, 4)


                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 10).Cells(0).Value = "TOTAL VENTAS DEL MES ( V )"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 10).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 10).Cells(1).CellFormat.FormatString = "#,##0.0000"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 10).Cells(1).Value = xTotalVentas ' FormatNumber(xTotalVentas, 4)
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 10).Cells(2).CellFormat.FormatString = "#,##0.0000"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 10).Cells(2).Value = xTotalVentas ' FormatNumber(xTotalVentas, 4)

                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 11).Cells(0).Value = "G / V"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 11).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 11).Cells(1).CellFormat.FormatString = "#,##0.0000"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 11).Cells(2).CellFormat.FormatString = "#,##0.0000"


                If xTotalVentas <> 0 Then
                    Libro.Worksheets(0).Rows(Grid1.Rows.Count + 11).Cells(1).Value = xGastosCantera / xTotalVentas ' FormatNumber(xGastosCantera / xTotalVentas, 4)
                    Libro.Worksheets(0).Rows(Grid1.Rows.Count + 11).Cells(2).Value = xGastosCanteraM / xTotalVentas ' FormatNumber(xGastosCantera / xTotalVentas, 4)
                Else
                    Libro.Worksheets(0).Rows(Grid1.Rows.Count + 11).Cells(1).Value = 0
                    Libro.Worksheets(0).Rows(Grid1.Rows.Count + 11).Cells(2).Value = 0
                End If

            Else
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 8).Cells(0).Value = "TOTAL GASTOS DE CANTERAS ( G )"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 8).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 8).Cells(1).CellFormat.FormatString = "#,##0.0000"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 8).Cells(1).Value = xGastosCantera 'FormatNumber(xGastosCantera, 4)

                'Libro.Worksheets(0).Rows(35).Cells(1).Value = "=SUMA(B35:B8)"

                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 9).Cells(0).Value = "TOTAL VENTAS DEL MES ( V )"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 9).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 9).Cells(1).CellFormat.FormatString = "#,##0.0000"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 9).Cells(1).Value = xTotalVentas ' FormatNumber(xTotalVentas, 4)

                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 10).Cells(0).Value = "G / V"
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 10).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                Libro.Worksheets(0).Rows(Grid1.Rows.Count + 10).Cells(1).CellFormat.FormatString = "#,##0.0000"

                If xTotalVentas <> 0 Then
                    Libro.Worksheets(0).Rows(Grid1.Rows.Count + 10).Cells(1).Value = xGastosCantera / xTotalVentas ' FormatNumber(xGastosCantera / xTotalVentas, 4)
                Else
                    Libro.Worksheets(0).Rows(Grid1.Rows.Count + 10).Cells(1).Value = 0
                End If
            End If

            Libro.Worksheets(0).DisplayOptions.PanesAreFrozen = True
            Libro.Worksheets(0).DisplayOptions.FrozenPaneSettings.FrozenColumns = 1
            Libro.Worksheets(0).DisplayOptions.FrozenPaneSettings.FrozenRows = 6
            Try
                Libro.Save(Archivo)

                Call Iniciar_Excel(Archivo)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            If Grid2.Rows.Count <= 0 Then
                MsgBox("No hay Datos que Exportar", MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If

            Path = My.Application.Info.DirectoryPath & "\Reporte de Costeo de Minerales"

            UltraGridExcelExporter1.Export(Grid2, Libro, 5, 0)

            Archivo = LblCantera.Text & " - " & Me.LblDetalle.Text & " - " & CboMes.Text & " DEL " & Cbo2.Text
            Libro.Worksheets(0).Name = "Detalle"
            Libro.Worksheets(0).Rows(0).Cells(0).Value = Cia.Text
            Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Height = 160
            Libro.Worksheets(0).Rows(2).Cells(0).Value = Archivo
            Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
            'Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Center
            Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Height = 260
            Archivo = Path & "\" & Archivo & ".xls"
            Libro.Save(Archivo)
            Call Iniciar_Excel(Archivo)
        End If

        Libro = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Private Sub chkIncluirVariacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncluirVariacion.CheckedChanged
        If chkIncluirVariacion.Checked = True Then
            TabCosteo.Tabs("T03").Selected = True
        End If
    End Sub

    Function CargaCategoriaTrabajador() As DataTable
        Dim dtData As New DataTable
        dtData = Negocio.Activo.ListarCategoriaTrabajador(Entidad.CanteraCosteo)
        Return dtData
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dtData As New DataTable
        dtData = CargaCategoriaTrabajador()
        Dim frm As New FrmCategoriaTrabajador
        frm.dtData = dtData
        frm.ShowDialog()
    End Sub

    Private Sub Cbo4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo4.ValueChanged

    End Sub
End Class