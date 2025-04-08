Imports SIP_Entidad
Imports SIP_Negocio

Imports Infragistics.Excel
Public Class frmCConsultarConsumoSuministro

    Public Ls_Permisos As New List(Of Integer)
    Private dsReporte As DataSet

    Private Sub frmCConsultarConsumoSuministro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarAlmacenUsuarios(CboAlmacen, "28")
        Call ListarArea_General(CboArea)
        Cbo3.Value = 3
    End Sub

    Public Sub Nuevo()
        Txt1.Clear()
        Txt2.Clear()
        CboArea.Value = ""
    End Sub

    Public Sub Buscar()
        Dim frm As New frmBuscar
        frm.Formulario = frmBuscar.eState.frm_PersonalTemp
        frm.ShowDialog()
        Txt1.Text = frm.Flag2
        Txt2.Text = frm.Descripcion
        frm = Nothing
    End Sub

    Public Sub Excel()
        If String.IsNullOrEmpty(CboAlmacen.Value) Then
            MsgBox("Seleccionar Almacén", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        Call CargarDatos()
    End Sub

    Private Sub CargarDatos()
        Dim Fecha1 As Date
        Dim Fecha2 As Date

        Fecha1 = dtpFecha1.Value
        Fecha2 = dtpFecha2.Value

        Entidad.Pedido = New ETPedido
        If String.IsNullOrEmpty(CboArea.Value) Then
            Entidad.Pedido.Codigo_Area = "*"
        Else
            Entidad.Pedido.Codigo_Area = CboArea.Value
        End If

        If Trim(Txt1.Text) = "" Then
            Entidad.Pedido.Codigo_Empleo = "*"
        Else
            Entidad.Pedido.Codigo_Empleo = Txt1.Text
        End If

        Entidad.Pedido.Codigo_Almacen = CboAlmacen.Value
        Entidad.Pedido.Fecha1 = Fecha1.ToShortDateString & " 00:00:00"
        Entidad.Pedido.Fecha2 = Fecha2.ToShortDateString & " 23:59:59"
        Entidad.Pedido.Tipo_Doc = Cbo3.Value
        dsReporte = Nothing
        dsReporte = New DataSet
        dsReporte = Negocio.Suministro.ConsultaConsumoSuministro(Entidad.Pedido)

        If dsReporte Is Nothing Then
            MsgBox("No se cargaron los Datos", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        Else
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Select Case Cbo3.Value
                Case "1"
                    Call ExportarResumenArea()
                Case "2"
                    Call ExportarResumenPersonal()
                Case "3"
                    Call ExportarDetallado()
            End Select

            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End If
    End Sub

    Private Sub ExportarDetallado()
        Dim i As Long = 0
        Dim j As Integer = 0
        Dim Path As String = String.Empty
        Dim Archivo As String = String.Empty
        Dim Libro As New Infragistics.Excel.Workbook
        Dim Fila As Long = 0
        Dim Area As String = String.Empty
        Dim Personal As String = String.Empty

        If dsReporte.Tables(0).Rows.Count <= 0 Then
            MsgBox("No hay Datos que Exportar", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        'Reporte de Costeo de Minerales
        Path = My.Application.Info.DirectoryPath & "\Reportes Almacen\"

        Archivo = Path & "Reporte Consumo Suministros.xls"
        Libro.Worksheets.Add("Reporte")
        Libro.Worksheets(0).Name = "Reporte"
        Libro.Worksheets(0).Rows(0).Cells(0).Value = UCase("Cia Minera Agregados Calcareos S.A.")
        Libro.Worksheets(0).Rows(2).Cells(1).CellFormat.Font.Height = 180

        Libro.Worksheets(0).Rows(2).Cells(0).Value = "CONSUMO DE UTILES DE OFICINA POR AREA (DETALLADO)"
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Height = 250
        Libro.Worksheets(0).MergedCellsRegions.Add(2, 0, 2, 6).CellFormat.Alignment = HorizontalCellAlignment.Center

        Libro.Worksheets(0).Rows(3).Cells(0).Value = "DESDE " & dtpFecha1.Value & " HASTA LA FECHA " & dtpFecha2.Value
        Libro.Worksheets(0).Rows(3).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(3).Cells(0).CellFormat.Font.Height = 230
        Libro.Worksheets(0).MergedCellsRegions.Add(3, 0, 3, 6).CellFormat.Alignment = HorizontalCellAlignment.Center


        Libro.Worksheets(0).Rows(4).Cells(0).Value = "ALMACEN: " & Trim(CboAlmacen.Text)
        Libro.Worksheets(0).Rows(4).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(4).Cells(0).CellFormat.Font.Height = 200
        Libro.Worksheets(0).MergedCellsRegions.Add(4, 0, 4, 6).CellFormat.Alignment = HorizontalCellAlignment.Center

        Fila = 5

        Libro.Worksheets(0).Columns(0).Width = 3000
        Libro.Worksheets(0).Columns(1).Width = 10000
        Libro.Worksheets(0).Columns(2).Width = 3000
        Libro.Worksheets(0).Columns(3).Width = 10000
        Libro.Worksheets(0).Columns(4).Width = 3000
        Libro.Worksheets(0).Columns(5).Width = 2500
        Libro.Worksheets(0).Columns(6).Width = 3000

        Try
            For i = 0 To dsReporte.Tables(0).Rows.Count - 1
                With dsReporte.Tables(0)

                    If Trim(.Rows(i)("Cod_Area").ToString) <> Trim(Area) Then
                        Fila = Fila + 2
                        Area = .Rows(i)("Cod_Area").ToString
                        Libro.Worksheets(0).Rows(Fila).Cells(1).Value = "AREA:"
                        Libro.Worksheets(0).Rows(Fila).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        Libro.Worksheets(0).Rows(Fila).Cells(1).CellFormat.Font.Height = 200
                        Libro.Worksheets(0).Rows(Fila).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Right
                        Libro.Worksheets(0).Rows(Fila).Cells(2).Value = Trim(.Rows(i)("Area").ToString)
                        Libro.Worksheets(0).Rows(Fila).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        Libro.Worksheets(0).Rows(Fila).Cells(2).CellFormat.Font.Height = 200

                        Fila = Fila + 2

                        Libro.Worksheets(0).Rows(Fila).Cells(0).Value = "FECHA"
                        Libro.Worksheets(0).Rows(Fila).Cells(1).Value = "USUARIO"
                        Libro.Worksheets(0).Rows(Fila).Cells(2).Value = "CODIGO"
                        Libro.Worksheets(0).Rows(Fila).Cells(3).Value = "PRODUCTO"
                        Libro.Worksheets(0).Rows(Fila).Cells(4).Value = "CANTIDAD"
                        Libro.Worksheets(0).Rows(Fila).Cells(5).Value = "UND"
                        Libro.Worksheets(0).Rows(Fila).Cells(6).Value = "BILLETE"
                        For j = 0 To 6
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                        Next j

                        Fila = Fila + 1
                    End If

                    Libro.Worksheets(0).Rows(Fila).Cells(0).CellFormat.FormatString = "dd/mm/yyyy"
                    Libro.Worksheets(0).Rows(Fila).Cells(0).Value = .Rows(i)("Fecha")
                    Libro.Worksheets(0).Rows(Fila).Cells(1).Value = .Rows(i)("Personal")
                    Libro.Worksheets(0).Rows(Fila).Cells(2).CellFormat.FormatString = "@"
                    Libro.Worksheets(0).Rows(Fila).Cells(2).Value = .Rows(i)("Cod_Prod")
                    Libro.Worksheets(0).Rows(Fila).Cells(3).Value = .Rows(i)("Producto")
                    Libro.Worksheets(0).Rows(Fila).Cells(4).CellFormat.FormatString = "#,##0.0000"
                    Libro.Worksheets(0).Rows(Fila).Cells(4).Value = .Rows(i)("Cantidad")
                    Libro.Worksheets(0).Rows(Fila).Cells(5).Value = .Rows(i)("Unid")
                    Libro.Worksheets(0).Rows(Fila).Cells(6).CellFormat.FormatString = "@"
                    Libro.Worksheets(0).Rows(Fila).Cells(6).Value = .Rows(i)("NumDoc")


                    For j = 0 To 6
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                    Next j

                    Fila = Fila + 1

                End With
            Next i
            Libro.Save(Archivo)
            Call Iniciar_Excel(Archivo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, msgComacsa)
        End Try

        Libro = Nothing
    End Sub
    Private Sub ExportarResumenPersonal()
        Dim i As Long = 0
        Dim j As Integer = 0
        Dim Path As String = String.Empty
        Dim Archivo As String = String.Empty
        Dim Libro As New Infragistics.Excel.Workbook
        Dim Fila As Long = 0
        Dim Area As String = String.Empty
        Dim Personal As String = String.Empty

        If dsReporte.Tables(0).Rows.Count <= 0 Then
            MsgBox("No hay Datos que Exportar", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        'Reporte de Costeo de Minerales
        Path = My.Application.Info.DirectoryPath & "\Reportes Almacen\"

        Archivo = Path & "Reporte Consumo Suministros Resumen Personal.xls"
        Libro.Worksheets.Add("Reporte")
        Libro.Worksheets(0).Name = "Reporte"
        Libro.Worksheets(0).Rows(0).Cells(0).Value = UCase("Cia Minera Agregados Calcareos S.A.")
        Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Height = 180

        Libro.Worksheets(0).Rows(2).Cells(0).Value = "CONSUMO DE UTILES DE OFICINA POR AREA (RESUMEN POR PERSONAL)"
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Height = 250
        Libro.Worksheets(0).MergedCellsRegions.Add(2, 0, 2, 5).CellFormat.Alignment = HorizontalCellAlignment.Center

        Libro.Worksheets(0).Rows(3).Cells(0).Value = "DESDE " & dtpFecha1.Value & " HASTA LA FECHA " & dtpFecha2.Value
        Libro.Worksheets(0).Rows(3).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(3).Cells(0).CellFormat.Font.Height = 230
        Libro.Worksheets(0).MergedCellsRegions.Add(3, 0, 3, 5).CellFormat.Alignment = HorizontalCellAlignment.Center

        Libro.Worksheets(0).Rows(4).Cells(0).Value = "ALMACEN: " & Trim(CboAlmacen.Text)
        Libro.Worksheets(0).Rows(4).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(4).Cells(0).CellFormat.Font.Height = 200
        Libro.Worksheets(0).MergedCellsRegions.Add(4, 0, 4, 5).CellFormat.Alignment = HorizontalCellAlignment.Center

        Fila = 5

        Libro.Worksheets(0).Columns(0).Width = 10000
        Libro.Worksheets(0).Columns(1).Width = 3000
        Libro.Worksheets(0).Columns(2).Width = 12000
        Libro.Worksheets(0).Columns(3).Width = 3000
        Libro.Worksheets(0).Columns(4).Width = 2500
        Libro.Worksheets(0).Columns(5).Width = 3000


        Try
            For i = 0 To dsReporte.Tables(0).Rows.Count - 1
                With dsReporte.Tables(0)

                    If Trim(.Rows(i)("Cod_Area").ToString) <> Trim(Area) Then
                        Fila = Fila + 2
                        Area = .Rows(i)("Cod_Area").ToString
                        Libro.Worksheets(0).Rows(Fila).Cells(1).Value = "AREA:"
                        Libro.Worksheets(0).Rows(Fila).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        Libro.Worksheets(0).Rows(Fila).Cells(1).CellFormat.Font.Height = 200
                        Libro.Worksheets(0).Rows(Fila).Cells(1).CellFormat.Alignment = HorizontalCellAlignment.Right
                        Libro.Worksheets(0).Rows(Fila).Cells(2).Value = Trim(.Rows(i)("Area").ToString)
                        Libro.Worksheets(0).Rows(Fila).Cells(2).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        Libro.Worksheets(0).Rows(Fila).Cells(2).CellFormat.Font.Height = 200

                        Fila = Fila + 2

                        Libro.Worksheets(0).Rows(Fila).Cells(0).Value = "USUARIO"
                        Libro.Worksheets(0).Rows(Fila).Cells(1).Value = "CODIGO"
                        Libro.Worksheets(0).Rows(Fila).Cells(2).Value = "PRODUCTO"
                        Libro.Worksheets(0).Rows(Fila).Cells(3).Value = "CANTIDAD"
                        Libro.Worksheets(0).Rows(Fila).Cells(4).Value = "UND"
                        Libro.Worksheets(0).Rows(Fila).Cells(5).Value = "PJE(%)"
                        For j = 0 To 5
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                        Next j

                        Fila = Fila + 1
                    End If

                    Libro.Worksheets(0).Rows(Fila).Cells(0).Value = .Rows(i)("Personal")
                    Libro.Worksheets(0).Rows(Fila).Cells(1).CellFormat.FormatString = "@"
                    Libro.Worksheets(0).Rows(Fila).Cells(1).Value = .Rows(i)("Cod_Prod")
                    Libro.Worksheets(0).Rows(Fila).Cells(2).Value = .Rows(i)("Producto")
                    Libro.Worksheets(0).Rows(Fila).Cells(3).CellFormat.FormatString = "#,##0.0000"
                    Libro.Worksheets(0).Rows(Fila).Cells(3).Value = .Rows(i)("Cantidad")
                    Libro.Worksheets(0).Rows(Fila).Cells(4).Value = .Rows(i)("Unid")
                    Libro.Worksheets(0).Rows(Fila).Cells(5).CellFormat.FormatString = "##0.00"
                    If Val(.Rows(i)("Total")) = 0 Then
                        Libro.Worksheets(0).Rows(Fila).Cells(5).Value = 0
                    Else
                        Libro.Worksheets(0).Rows(Fila).Cells(5).Value = (Val(.Rows(i)("Cantidad")) / Val(.Rows(i)("Total"))) * 100
                    End If

                    For j = 0 To 5
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                    Next j

                    Fila = Fila + 1

                End With
            Next i
            Libro.Save(Archivo)
            Call Iniciar_Excel(Archivo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, msgComacsa)
        End Try

        Libro = Nothing
    End Sub

    Private Sub ExportarResumenArea()
        Dim i As Long = 0
        Dim j As Integer = 0
        Dim Path As String = String.Empty
        Dim Archivo As String = String.Empty
        Dim Libro As New Infragistics.Excel.Workbook
        Dim Fila As Long = 0
        Dim Area As String = String.Empty
        Dim Personal As String = String.Empty

        If dsReporte.Tables(0).Rows.Count <= 0 Then
            MsgBox("No hay Datos que Exportar", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        'Reporte de Costeo de Minerales
        Path = My.Application.Info.DirectoryPath & "\Reportes Almacen\"

        Archivo = Path & "Reporte Consumo Suministros Resumen Area.xls"
        Libro.Worksheets.Add("Reporte")
        Libro.Worksheets(0).Name = "Reporte"
        Libro.Worksheets(0).Rows(0).Cells(0).Value = UCase("Cia Minera Agregados Calcareos S.A.")
        Libro.Worksheets(0).Rows(0).Cells(0).CellFormat.Font.Height = 180

        Libro.Worksheets(0).Rows(2).Cells(0).Value = "CONSUMO DE UTILES DE OFICINA POR AREA (RESUMEN POR AREA)"
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(2).Cells(0).CellFormat.Font.Height = 250
        Libro.Worksheets(0).MergedCellsRegions.Add(2, 0, 2, 4).CellFormat.Alignment = HorizontalCellAlignment.Center

        Libro.Worksheets(0).Rows(3).Cells(0).Value = "DESDE " & dtpFecha1.Value & " HASTA LA FECHA " & dtpFecha2.Value
        Libro.Worksheets(0).Rows(3).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(3).Cells(0).CellFormat.Font.Height = 230
        Libro.Worksheets(0).MergedCellsRegions.Add(3, 0, 3, 4).CellFormat.Alignment = HorizontalCellAlignment.Center

        Libro.Worksheets(0).Rows(4).Cells(0).Value = "ALMACEN: " & Trim(CboAlmacen.Text)
        Libro.Worksheets(0).Rows(4).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        Libro.Worksheets(0).Rows(4).Cells(0).CellFormat.Font.Height = 200
        Libro.Worksheets(0).MergedCellsRegions.Add(4, 0, 4, 4).CellFormat.Alignment = HorizontalCellAlignment.Center

        Fila = 5


        Libro.Worksheets(0).Columns(0).Width = 3000
        Libro.Worksheets(0).Columns(1).Width = 12000
        Libro.Worksheets(0).Columns(2).Width = 3000
        Libro.Worksheets(0).Columns(3).Width = 2500
        Libro.Worksheets(0).Columns(4).Width = 3000


        Try
            For i = 0 To dsReporte.Tables(0).Rows.Count - 1
                With dsReporte.Tables(0)

                    If Trim(.Rows(i)("Cod_Area").ToString) <> Trim(Area) Then
                        Fila = Fila + 2
                        Area = .Rows(i)("Cod_Area").ToString
                        Libro.Worksheets(0).Rows(Fila).Cells(0).Value = "AREA:"
                        Libro.Worksheets(0).Rows(Fila).Cells(0).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        Libro.Worksheets(0).Rows(Fila).Cells(0).CellFormat.Font.Height = 200
                        Libro.Worksheets(0).Rows(Fila).Cells(0).CellFormat.Alignment = HorizontalCellAlignment.Right
                        Libro.Worksheets(0).Rows(Fila).Cells(1).Value = Trim(.Rows(i)("Area").ToString)
                        Libro.Worksheets(0).Rows(Fila).Cells(1).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                        Libro.Worksheets(0).Rows(Fila).Cells(1).CellFormat.Font.Height = 200

                        Fila = Fila + 2

                        Libro.Worksheets(0).Rows(Fila).Cells(0).Value = "CODIGO"
                        Libro.Worksheets(0).Rows(Fila).Cells(1).Value = "PRODUCTO"
                        Libro.Worksheets(0).Rows(Fila).Cells(2).Value = "CANTIDAD"
                        Libro.Worksheets(0).Rows(Fila).Cells(3).Value = "UND"
                        Libro.Worksheets(0).Rows(Fila).Cells(4).Value = "PJE(%)"
                        For j = 0 To 4
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.Font.Bold = ExcelDefaultableBoolean.True
                            Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                        Next j

                        Fila = Fila + 1
                    End If

                    Libro.Worksheets(0).Rows(Fila).Cells(0).CellFormat.FormatString = "@"
                    Libro.Worksheets(0).Rows(Fila).Cells(0).Value = .Rows(i)("Cod_Prod")
                    Libro.Worksheets(0).Rows(Fila).Cells(1).Value = .Rows(i)("Producto")
                    Libro.Worksheets(0).Rows(Fila).Cells(2).CellFormat.FormatString = "#,##0.0000"
                    Libro.Worksheets(0).Rows(Fila).Cells(2).Value = .Rows(i)("Cantidad")
                    Libro.Worksheets(0).Rows(Fila).Cells(3).Value = .Rows(i)("Unid")
                    Libro.Worksheets(0).Rows(Fila).Cells(4).CellFormat.FormatString = "##0.00"
                    If Val(.Rows(i)("Total")) = 0 Then
                        Libro.Worksheets(0).Rows(Fila).Cells(4).Value = 0
                    Else
                        Libro.Worksheets(0).Rows(Fila).Cells(4).Value = (Val(.Rows(i)("Cantidad")) / Val(.Rows(i)("Total"))) * 100
                    End If

                    For j = 0 To 4
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.BottomBorderStyle = CellBorderLineStyle.Thin
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.TopBorderStyle = CellBorderLineStyle.Thin
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.LeftBorderStyle = CellBorderLineStyle.Thin
                        Libro.Worksheets(0).Rows(Fila).Cells(j).CellFormat.RightBorderStyle = CellBorderLineStyle.Thin
                    Next j

                    Fila = Fila + 1

                End With
            Next i
            Libro.Save(Archivo)
            Call Iniciar_Excel(Archivo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, msgComacsa)
        End Try

        Libro = Nothing
    End Sub

    Private Sub CboArea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles CboArea.InitializeLayout

    End Sub
End Class