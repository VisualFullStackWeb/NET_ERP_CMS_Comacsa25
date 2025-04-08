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
Public Class frmResumenMensual
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

    Private Sub frmResumenMensual_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDesde.Value = Now.Date
        dtpHasta.Value = Now.Date
    End Sub

    Sub Buscar()
        If txtalmorigen.Focused = True Then
            txtalmorigen.Clear()
            Dim frm As New frmBuscarAlmacen
            frm.ShowDialog()
            txtalmorigen.Text = frm.gridAlmacen.ActiveRow.Cells("ALMACEN").Value.ToString.Trim
            txtidalmorigen.Text = frm.gridAlmacen.ActiveRow.Cells("COD_ALMACEN").Value.ToString.Trim
            txtcodcanteraori.Text = frm.gridAlmacen.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcanteraori.Text = frm.gridAlmacen.ActiveRow.Cells("CANTERA").Value.ToString.Trim
        End If
    End Sub

    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        Reporte()
    End Sub

    Sub Reporte()
        Try
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim Obj_Excel As Object
            Dim Obj_Libro As Object
            Dim Obj_Hoja As Object
            Dim Fila As Integer = 0

            Obj_Excel = CreateObject("Excel.Application")
            Obj_Libro = Obj_Excel.Workbooks.Add()
            Obj_Libro.Sheets(1).Name = "REPORTE DE EMPLEADOS"

            Obj_Hoja = Obj_Libro.Sheets(1)
            Obj_Hoja.Activate()

            Obj_Hoja.Columns("A").ColumnWidth = 48
            Obj_Hoja.Columns("B").ColumnWidth = 15


            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = Obj_Excel.Worksheets(1)
            Dim nro_fila, nro_column As Integer

            nro_column = 3 'COLUMNA INICIAL 
            Dim nrofila_A As Int32 = 0
            Dim nrofila_B As Int32 = 0
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.FechaInicio = dtpDesde.Value
            _objEntidad.FechaTerminacion = dtpHasta.Value
            _objEntidad.CodAlmacen = txtidalmorigen.Text
            Dim dsDatos As New DataSet
            dsDatos = _objNegocio.CE_RESUMEN_MENSUAL(_objEntidad)

            Dim dtProducto As New DataTable
            Dim dtCliente As New DataTable
            Dim dtEquipo As New DataTable
            Dim dtContratista As New DataTable
            Dim dtAdministrativo As New DataTable
            Dim dtSaldo As New DataTable
            Dim dtIngreso As New DataTable

            dtProducto = dsDatos.Tables(0)
            dtCliente = dsDatos.Tables(1)
            dtEquipo = dsDatos.Tables(2)
            dtContratista = dsDatos.Tables(3)
            dtAdministrativo = dsDatos.Tables(4)
            dtSaldo = dsDatos.Tables(5)
            dtIngreso = dsDatos.Tables(6)

            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()

            If dtContratista.Rows.Count > 0 Then
                With objHojaExcel
                    .Columns("A").NumberFormat = "@"
                    .Columns("A").ColumnWidth = 10
                    .Columns("B").NumberFormat = "@"
                    .Columns("B").ColumnWidth = 54
                    '.Columns("B").NumberFormat = "#,##0.00"
                    .Cells(1, 2).value = "COMACSA" 'REPORTE VENTAS 
                    .Cells(2, 2).value = "RESUMEN MENSUAL DE EXPLOSIVOS Y COMBUSTIBLE"
                    .Range(.Cells(2, 2), .Cells(2, 2 + dtProducto.Rows.Count)).Merge()
                    .Range(.Cells(2, 2), .Cells(2, 2 + dtProducto.Rows.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(2, 2), .Cells(2, 2 + dtProducto.Rows.Count)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                    .Cells(3, 3).value = "UNIDAD"
                    .Cells(3, 4).value = txtalmorigen.Text
                    .Cells(4, 3).value = "MES"
                    .Cells(4, 4).value = "ENERO " & Year(dtpHasta.Value).ToString & "   (" & CDate(dtpDesde.Value).ToString("dd/MM/yyyy") & " AL " & CDate(dtpHasta.Value).ToString("dd/MM/yyyy") & ")"

                    nro_fila = 6
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, dtProducto.Rows.Count - 1 + nro_column)).Merge()
                    .Cells(nro_fila, 2).value = "CONSUMOS FACTURADOS"

                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2)).Font.Bold = True
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, dtProducto.Rows.Count - 1 + nro_column)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    .Cells.Range("B" & 1, "B" & 3).Font.Bold = True
                    nro_fila = 9
                    Dim n_fila_codigo As Int32 = 0
                    For i As Int32 = 0 To dtProducto.Rows.Count - 1
                        n_fila_codigo = nro_fila - 2
                        .Cells(nro_fila - 2, nro_column + i).NumberFormat = "@"
                        .Cells(nro_fila - 2, nro_column + i).value = dtProducto.Rows(i)(0)
                        .Cells(nro_fila - 2, nro_column + i).RowHeight = 0
                        .Range(.Cells(nro_fila - 1, 3), .Cells(nro_fila - 1, dtProducto.Rows.Count - 1 + nro_column)).Merge()
                        .Range(.Cells(nro_fila - 1, 3), .Cells(nro_fila - 1, dtProducto.Rows.Count - 1 + nro_column)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range(.Cells(nro_fila - 1, 2), .Cells(nro_fila, 2)).Merge()
                        .Range(.Cells(nro_fila - 1, 2), .Cells(nro_fila, 2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Cells(nro_fila - 1, 2).value = "USUARIOS"
                        .Cells(nro_fila - 1, 3).value = "MATERIALES"
                        .Range(.Cells(nro_fila - 1, 2), .Cells(nro_fila - 1, 3)).Font.Bold = True
                        .Range(.Cells(nro_fila - 1, 2), .Cells(nro_fila - 1, 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        .Range(.Cells(nro_fila - 1, 2), .Cells(nro_fila - 1, 2)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        .Range(.Cells(nro_fila - 1, 3), .Cells(nro_fila - 1, 3)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        .Range(.Cells(nro_fila - 1, 3), .Cells(nro_fila - 1, 3)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        .Cells(nro_fila, nro_column + i).NumberFormat = "@"
                        .Cells(nro_fila, nro_column + i).value = dtProducto.Rows(i)(1)
                        .Cells(nro_fila, nro_column + i).ColumnWidth = 12
                        .Cells(nro_fila, nro_column + i).RowHeight = 32
                        .Cells(nro_fila, nro_column + i).WrapText = True
                        .Cells(nro_fila, nro_column + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Cells(nro_fila, nro_column + i).Font.Bold = True
                        .Cells(nro_fila, nro_column + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        .Cells(nro_fila, nro_column + i).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    Next
                    nro_fila += 1

                    ' INGRESAMOS LA LISTA DE CLIENTES EN LA FILA 1
                    For i As Int32 = 0 To dtCliente.Rows.Count - 1
                        .Cells(nro_fila + i, 1).value = dtCliente.Rows(i)(0)
                        .Cells(nro_fila + i, 2).value = dtCliente.Rows(i)(1)
                        .Cells(nro_fila + i, 2).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nro_fila += 1
                    Next
                    .Cells(1, 1).ColumnWidth = 0
                    nro_column = 3
                    Dim fila_valor As Int32 = 0
                    Dim col_valor As Int32 = 0
                    For i As Int32 = 0 To dtContratista.Rows.Count - 1
                        Dim cod_prod As String = dtContratista.Rows(i)("COD_PROD")
                        Dim cod_cli As String = dtContratista.Rows(i)("COD_CLI")
                        For Fil As Int32 = nro_fila To nro_fila + dtCliente.Rows.Count - 1
                            For col As Int32 = nro_column To dtProducto.Rows.Count - 1 + nro_column
                                .Cells(Fil, col).NumberFormat = "#,##0.00"
                                .Cells(Fil, col).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                If cod_prod = .Cells(n_fila_codigo, col).value Then
                                    col_valor = col
                                    Exit For
                                End If
                            Next
                            If cod_cli = .Cells(Fil, 1).value Then
                                fila_valor = Fil
                                Exit For
                            End If
                        Next
                        .Cells(fila_valor, col_valor).NumberFormat = "#,##0.00"
                        .Cells(fila_valor, col_valor).value = dtContratista.Rows(i)("CANTIDAD")

                    Next
                    Dim n_fila_ini As Int32 = nro_fila
                    nro_fila = nro_fila + dtCliente.Rows.Count
                    .Cells.Range("B" & nro_fila).Value = "SUB - TOTAL (A)"
                    .Cells.Range("B" & nro_fila).Font.Bold = True
                    .Cells.Range("B" & nro_fila).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Cells.Range("B" & nro_fila).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    nrofila_A = nro_fila
                    'MsgBox(dtCliente.Rows.Count)
                    For i As Int32 = 0 To dtProducto.Rows.Count - 1
                        '.Cells(nro_fila, nro_column + i).FormulaR1C1 = "=SUM(R[-" & dtCliente.Rows.Count & "]C:R[-1]C)"
                        .Cells(nro_fila, nro_column + i).Value = "=SUMA(" & letra_numero(nro_column + i) & "" & n_fila_ini - 1 & ":" & letra_numero(nro_column + i) & "" & nro_fila - 1 & ")" '"=SUM(R[-" & dtCliente.Rows.Count & "]C:R[-1]C)"
                        .Cells(nro_fila, nro_column + i).NumberFormat = "#,##0.00"
                        .Cells(nro_fila, nro_column + i).Font.Bold = True
                        .Cells(nro_fila, nro_column + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    Next

                    nro_fila = nro_fila + 2
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, dtProducto.Rows.Count - 1 + nro_column)).Merge()
                    .Cells(nro_fila, 2).value = "CONSUMO ADMINISTRACION"
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2)).Font.Bold = True
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, dtProducto.Rows.Count - 1 + nro_column)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    nro_fila = nro_fila + 1

                    ' INGRESAMOS LA LISTA DE EQUIPOS EN LA FILA 1
                    For i As Int32 = 0 To dtEquipo.Rows.Count - 1
                        .Cells(nro_fila + i, 1).value = dtEquipo.Rows(i)(0)
                        .Cells(nro_fila + i, 2).value = dtEquipo.Rows(i)(1)
                        .Cells(nro_fila + i, 2).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nro_fila += 1
                    Next


                    nro_column = 3
                    fila_valor = 0
                    col_valor = 0
                    For i As Int32 = 0 To dtAdministrativo.Rows.Count - 1
                        Dim cod_prod As String = dtAdministrativo.Rows(i)("COD_PROD")
                        Dim cod_equipo As String = dtAdministrativo.Rows(i)("COD_EQUIPO")
                        For Fil As Int32 = nro_fila To nro_fila + dtEquipo.Rows.Count - 1
                            For col As Int32 = nro_column To dtProducto.Rows.Count - 1 + nro_column
                                .Cells(Fil, col).NumberFormat = "#,##0.00"
                                .Cells(Fil, col).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                If cod_prod = .Cells(n_fila_codigo, col).value Then
                                    col_valor = col
                                    Exit For
                                End If
                            Next
                            If cod_equipo = .Cells(Fil, 1).value Then
                                fila_valor = Fil
                                Exit For
                            End If
                        Next
                        .Cells(fila_valor, col_valor).NumberFormat = "#,##0.00"
                        .Cells(fila_valor, col_valor).value = dtAdministrativo.Rows(i)("CANTIDAD")
                    Next

                    n_fila_ini = nro_fila
                    nro_fila = nro_fila + dtEquipo.Rows.Count
                    .Cells.Range("B" & nro_fila).Value = "SUB - TOTAL (B)"
                    .Cells.Range("B" & nro_fila).Font.Bold = True
                    .Cells.Range("B" & nro_fila).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Cells.Range("B" & nro_fila).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    nrofila_B = nro_fila
                    'MsgBox(dtCliente.Rows.Count)
                    For i As Int32 = 0 To dtProducto.Rows.Count - 1
                        '.Cells(nro_fila, nro_column + i).FormulaR1C1 = "=SUM(R[-" & dtCliente.Rows.Count & "]C:R[-1]C)"
                        .Cells(nro_fila, nro_column + i).Value = "=SUMA(" & letra_numero(nro_column + i) & "" & n_fila_ini - 1 & ":" & letra_numero(nro_column + i) & "" & nro_fila - 1 & ")"
                        .Cells(nro_fila, nro_column + i).NumberFormat = "#,##0.00"
                        .Cells(nro_fila, nro_column + i).Font.Bold = True
                        .Cells(nro_fila, nro_column + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    Next
                    nro_fila += 2
                    Dim fila_total_AB As Int32 = nro_fila
                    .Cells.Range("B" & nro_fila).Value = "TOTAL (A) + (B)"
                    .Cells.Range("B" & nro_fila).Font.Bold = True
                    .Cells.Range("B" & nro_fila).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Cells.Range("B" & nro_fila).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    For i As Int32 = 0 To dtProducto.Rows.Count - 1
                        '.Cells(nro_fila, nro_column + i).FormulaR1C1 = "=SUM(R[-" & dtCliente.Rows.Count & "]C:R[-1]C)"
                        .Cells(nro_fila, nro_column + i).Value = "=" & letra_numero(nro_column + i) & "" & nrofila_A & "+" & letra_numero(nro_column + i) & "" & nrofila_B & ""
                        .Cells(nro_fila, nro_column + i).NumberFormat = "#,##0.00"
                        .Cells(nro_fila, nro_column + i).Font.Bold = True
                        .Cells(nro_fila, nro_column + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    Next

                    nro_fila = nro_fila + 4
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, dtProducto.Rows.Count - 1 + nro_column)).Merge()
                    .Cells(nro_fila, 2).value = "RESUMEN GENERAL"
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2)).Font.Bold = True
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, dtProducto.Rows.Count - 1 + nro_column)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    nro_fila = nro_fila + 3
                    n_fila_codigo = 0
                    For i As Int32 = 0 To dtProducto.Rows.Count - 1
                        n_fila_codigo = nro_fila - 2
                        .Cells(nro_fila - 2, nro_column + i).NumberFormat = "@"
                        n_fila_codigo = nro_fila - 2
                        .Cells(nro_fila - 2, nro_column + i).value = dtProducto.Rows(i)(0)
                        .Cells(nro_fila - 2, nro_column + i).RowHeight = 0
                        .Range(.Cells(nro_fila - 1, 3), .Cells(nro_fila - 1, dtProducto.Rows.Count - 1 + nro_column)).Merge()
                        .Range(.Cells(nro_fila - 1, 3), .Cells(nro_fila - 1, dtProducto.Rows.Count - 1 + nro_column)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range(.Cells(nro_fila - 1, 2), .Cells(nro_fila, 2)).Merge()
                        .Range(.Cells(nro_fila - 1, 2), .Cells(nro_fila, 2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Cells(nro_fila - 1, 2).value = "MOVIMIENTOS"
                        .Cells(nro_fila - 1, 3).value = "TIPO DE MATERIAL"
                        .Range(.Cells(nro_fila - 1, 2), .Cells(nro_fila - 1, 3)).Font.Bold = True
                        .Range(.Cells(nro_fila - 1, 2), .Cells(nro_fila - 1, 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        .Range(.Cells(nro_fila - 1, 2), .Cells(nro_fila - 1, 2)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        .Range(.Cells(nro_fila - 1, 3), .Cells(nro_fila - 1, 3)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        .Range(.Cells(nro_fila - 1, 3), .Cells(nro_fila - 1, 3)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        .Cells(nro_fila, nro_column + i).NumberFormat = "@"

                        .Cells(nro_fila, nro_column + i).value = dtProducto.Rows(i)(1)
                        .Cells(nro_fila, nro_column + i).ColumnWidth = 12
                        .Cells(nro_fila, nro_column + i).RowHeight = 32
                        .Cells(nro_fila, nro_column + i).WrapText = True
                        .Cells(nro_fila, nro_column + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Cells(nro_fila, nro_column + i).Font.Bold = True
                        .Cells(nro_fila, nro_column + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        .Cells(nro_fila, nro_column + i).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    Next
                    nro_fila += 1
                    Dim fila_saldo_ant As Int32 = nro_fila
                    .Cells(nro_fila, 2).value = "SALDO ANTERIOR"
                    .Cells(nro_fila, 2).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2 + dtProducto.Rows.Count)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    For i As Int32 = 0 To dtSaldo.Rows.Count - 1
                        Dim cod_prod As String = dtSaldo.Rows(i)("COD_PROD")
                        'Dim cod_equipo As String = dtSaldo.Rows(i)("COD_EQUIPO")
                        For col As Int32 = nro_column To dtProducto.Rows.Count - 1 + nro_column
                            .Cells(nro_fila, col).NumberFormat = "#,##0.00"
                            '.Cells(nro_fila, col).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            If cod_prod = .Cells(n_fila_codigo, col).value Then
                                col_valor = col
                                Exit For
                            End If
                        Next

                        .Cells(nro_fila, col_valor).NumberFormat = "#,##0.00"
                        .Cells(nro_fila, col_valor).value = dtSaldo.Rows(i)("CANTIDAD")
                    Next

                    nro_fila += 1
                    Dim fila_saldo_ing As Int32 = nro_fila
                    .Cells(nro_fila, 2).value = "INGRESO"
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2 + dtProducto.Rows.Count)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    For i As Int32 = 0 To dtIngreso.Rows.Count - 1
                        Dim cod_prod As String = dtIngreso.Rows(i)("COD_PROD")
                        For col As Int32 = nro_column To dtProducto.Rows.Count - 1 + nro_column
                            .Cells(nro_fila, col).NumberFormat = "#,##0.00"
                            .Cells(nro_fila, col).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            If cod_prod = .Cells(n_fila_codigo, col).value Then
                                col_valor = col
                                Exit For
                            End If
                        Next

                        .Cells(nro_fila, col_valor).NumberFormat = "#,##0.00"
                        .Cells(nro_fila, col_valor).value = dtIngreso.Rows(i)("CANTIDAD")
                    Next

                    nro_fila += 1
                    Dim fila_saldo_cons As Int32 = nro_fila
                    .Cells(nro_fila, 2).value = "CONS. DEL MES"
                    .Range(.Cells(nro_fila, 2), .Cells(nro_fila, 2 + dtProducto.Rows.Count)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    For i As Int32 = 0 To dtProducto.Rows.Count - 1
                        .Cells(nro_fila, nro_column + i).Value = "=" & letra_numero(nro_column + i) & "" & fila_total_AB
                        .Cells(nro_fila, nro_column + i).NumberFormat = "#,##0.00"
                    Next

                    nro_fila += 2
                    .Cells(nro_fila, 2).value = "SALDO ACTUAL"
                    .Cells(nro_fila, 2).Font.Bold = True
                    .Range(.Cells(nro_fila, 3), .Cells(nro_fila, 2 + dtProducto.Rows.Count)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    For i As Int32 = 0 To dtProducto.Rows.Count - 1
                        .Cells(nro_fila, nro_column + i).Value = "=" & letra_numero(nro_column + i) & "" & fila_saldo_ant & "+" & letra_numero(nro_column + i) & "" & fila_saldo_ing & "-" & letra_numero(nro_column + i) & "" & fila_saldo_cons & ""
                        .Cells(nro_fila, nro_column + i).NumberFormat = "#,##0.00"
                    Next

                End With
                Obj_Hoja = Obj_Libro.Sheets(1)
                Obj_Hoja.Activate()
            Else
                MsgBox("Ningun Registro Encontrado en empleados!!")
            End If

            Obj_Hoja = Obj_Libro.Sheets(1)
            Obj_Hoja.Activate()

            Obj_Excel.visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub
    Function letra_numero(ByVal numero As Int32) As String
        Dim letra As String = ""
        Select Case numero
            Case 1
                letra = "A"
            Case 2
                letra = "B"
            Case 3
                letra = "C"
            Case 4
                letra = "D"
            Case 5
                letra = "E"
            Case 6
                letra = "F"
            Case 7
                letra = "G"
            Case 8
                letra = "H"
            Case 9
                letra = "I"
            Case 10
                letra = "J"
            Case 11
                letra = "K"
            Case 12
                letra = "L"
            Case 13
                letra = "M"
            Case 14
                letra = "N"
            Case 15
                letra = "O"
            Case 16
                letra = "P"
            Case 17
                letra = "Q"
            Case 18
                letra = "R"
            Case 19
                letra = "S"
            Case 20
                letra = "T"
        End Select
        Return letra
    End Function

End Class