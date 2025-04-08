Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Excel
Imports Infragistics.Excel.Workbook
Imports Infragistics
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frm_RptFCB
    'EXCEL
    Dim Obj_Excel As Object
    Dim Obj_Libro As Object
    Dim Obj_Hoja As Object
    Dim Fila As Integer = 0

    Dim Ent As New ETFCB
    Dim Negocio As New NGFCB
    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Entrega As List(Of ETFCB) = Nothing


    Private Sub frm_RptFCB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        Me.cmbMes.Value = Month(Now.Date)
    End Sub



    Sub ReporteDetalle()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Dim dt_detconmay As New DataTable
        dt_detconmay = Negocio.Rpt_listardetalleconmay(Companhia, txtAño.Value, cmbMes.Value) '
        GridConsultaDetalle.DataSource = dt_detconmay
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Sub ReporteDetalle2()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application

        Obj_Excel = CreateObject("Excel.Application")
        Obj_Libro = Obj_Excel.Workbooks.Add()
        Obj_Libro.Sheets(1).Name = "DETALLE FLUJO DE BANCOS"
        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()
        Obj_Hoja.Columns("A").ColumnWidth = 25
        Obj_Hoja.Columns("D").ColumnWidth = 20
        Obj_Hoja.Columns("E").ColumnWidth = 20
        Obj_Hoja.Columns("G").ColumnWidth = 20
        Obj_Hoja.Columns("J").ColumnWidth = 25

        Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = Obj_Excel.Worksheets(1)


        Dim cgimporte As Decimal = 0
        Dim total As Decimal = 0

        Dim i As Integer
        Dim grupo
        Dim nro_fila, prim_fila, nro_column, ultfila As Integer
        nro_column = 2 'COLUMNA INICIAL
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        With objHojaExcelDetalle

            .Cells(2, 1).value = ("REPORTE DETALLADO MES " & Nombre_Mes(cmbMes.Value) & " - " & txtAño.Value).ToString()
            .Cells(2, 1).Font.Bold = True
            .Cells(2, 1).Font.Size = 11

            Dim dt_detconmay As New DataTable
            dt_detconmay = Negocio.Rpt_listardetalleconmay(Companhia, txtAño.Value, cmbMes.Value) '

            Dim ctabanco, subgrupo As String
            ctabanco = ""
            grupo = ""
            subgrupo = ""
            nro_fila = 3
            prim_fila = nro_fila + 1
            For i = 0 To dt_detconmay.Rows.Count - 1

                If ctabanco <> dt_detconmay.Rows(i)("CtaBanco") Then
                    nro_fila = nro_fila + 1
                    ctabanco = dt_detconmay.Rows(i)("CtaBanco")
                    .Range("A" & nro_fila + i).Value = dt_detconmay.Rows(i)("banco") & " - " & dt_detconmay.Rows(i)("bcocta")
                    .Cells(nro_fila + i, 1).Font.Bold = True
                    .Cells(nro_fila + i, 1).Font.Size = 10
                    nro_fila = nro_fila + 1
                    'Else
                    '    nro_fila = nro_fila + 1
                End If

                If grupo <> dt_detconmay.Rows(i)("grupo") Then

                    nro_fila = nro_fila + 1
                    grupo = dt_detconmay.Rows(i)("grupo")
                    .Range("B" & nro_fila + i).Value = dt_detconmay.Rows(i)("grupo")
                    .Cells(nro_fila + i, 2).Font.Bold = True
                    nro_fila = nro_fila + 1
                    'Else
                    '    nro_fila = nro_fila + 1
                End If

                If subgrupo <> dt_detconmay.Rows(i)("subgrupo") Then

                    If i > 0 Then
                        .Range("C" & ultfila + 1).Value = cgimporte
                        .Range("C" & ultfila + 1).NumberFormat = "###,##0.00" ' Formato
                        .Range("C" & ultfila + 1).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nro_fila = nro_fila + 1
                        cgimporte = 0
                    End If
                    subgrupo = dt_detconmay.Rows(i)("subgrupo")
                    .Range("B" & nro_fila + i).Value = dt_detconmay.Rows(i)("subgrupo")
                    .Cells(nro_fila + i, 1).Font.Bold = True
                    nro_fila = nro_fila + 1
                End If

                .Range("B" & nro_fila + i).Value = dt_detconmay.Rows(i)("cgvoucher")
                .Range("C" & nro_fila + i).Value = dt_detconmay.Rows(i)("cgimporte")
                .Range("D" & nro_fila + i).Value = dt_detconmay.Rows(i)("cgdoc")
                .Range("E" & nro_fila + i).Value = dt_detconmay.Rows(i)("concepto")
                .Range("F" & nro_fila + i).Value = dt_detconmay.Rows(i)("CtaBanco")
                .Range("G" & nro_fila + i).Value = dt_detconmay.Rows(i)("banco")
                .Range("H" & nro_fila + i).Value = dt_detconmay.Rows(i)("bcocta")
                .Range("I" & nro_fila + i).Value = dt_detconmay.Rows(i)("cgaux")
                .Range("J" & nro_fila + i).Value = dt_detconmay.Rows(i)("RazSoc")
                .Range(.Cells(nro_fila + i, 2), .Cells(nro_fila + i, 10)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                ultfila = nro_fila + i
                cgimporte = cgimporte + dt_detconmay.Rows(i)("cgimporte")
                total = total + cgimporte
            Next

            .Range("C" & ultfila + 1).Value = cgimporte
            .Range("C" & nro_fila + 4).Value = total
            .Range("C" & ultfila + 1).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range("C" & nro_fila + 4).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Cells(ultfila + 4, 3).Font.Bold = True
        End With
        
        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()

        Obj_Excel.visible = True
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Sub ReporteResumen()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application

        Obj_Excel = CreateObject("Excel.Application")
        Obj_Libro = Obj_Excel.Workbooks.Add()
        Obj_Libro.Sheets(1).Name = "RESUMEN FLUJO DE BANCOS"
        Obj_Libro.Sheets(2).Name = "GASTOS POR OBRA"
        'Obj_Libro.Sheets(3).Name = "GASTOS POR OBRA"

        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()
        Obj_Hoja.Columns("A").ColumnWidth = 38.43

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        'Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = Obj_Excel.Worksheets(1)
        Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = Obj_Excel.Worksheets(1)
        Dim objHojaExcelObras As Microsoft.Office.Interop.Excel.Worksheet = Obj_Excel.Worksheets(2)

        Dim dt_cuentas As New DataTable
        dt_cuentas = Negocio.Rpt_listarcuentas(Companhia, txtAño.Value, cmbMes.Value)

        Dim dt_grupos As New DataTable
        dt_grupos = Negocio.Rpt_listargrupos()

        Dim dt_conmay As New DataTable
        dt_conmay = Negocio.Rpt_listar_gasto_obras_xmes(Companhia, txtAño.Value, cmbMes.Value) ' PASAR PARAMETROS
        'dt_conmay = Negocio.Rpt_listarconmay(Companhia, txtAño.Value, cmbMes.Value) ' PASAR PARAMETROS

        'Dim sub_id, sb_id As Integer
        Dim i As Integer ', j, k
        Dim grupo As String ', ctacte
        Dim nro_fila, prim_fila, nro_column, ultfila As Integer ', colum_total
        nro_column = 2 'COLUMNA INICIAL

        'With objHojaExcel
        '    .Activate()
        '    'cells(fila,column)
        '    .Cells(2, 1).value = "REPORTE FLUJO BANCOS " & Nombre_Mes(cmbMes.Value).ToString() & " - " & txtAño.Value
        '    .Range("A" & 4, "A" & 5).Merge()
        '    .Cells(4, 1).value = "BANCO CUENTA"

        '    .Cells(6, 1).value = "CONCEPTO"
        '    .Cells(8, 1).value = "Saldo Inicial"

        '    For i = 0 To dt_cuentas.Rows.Count - 1
        '        Dim s_let As String = Letra_Columna_Excel(nro_column + i)
        '        .Cells(4, nro_column + i).value = dt_cuentas.Rows(i)("descrip")
        '        .Cells(5, nro_column + i).value = dt_cuentas.Rows(i)("nro_cta").ToString()
        '        .Cells(6, nro_column + i).value = dt_cuentas.Rows(i)("moneda")
        '        .Cells(8, nro_column + i).value = dt_cuentas.Rows(i)("sinicial")
        '        .Range(s_let & 8, s_let & 8).NumberFormat = "###,##0.00" ' Formato
        '    Next
        '    colum_total = nro_column + i
        '    Dim s_letra As String = Letra_Columna_Excel(colum_total)
        '    .Range(s_letra & 4, s_letra & 6).Merge()
        '    .Range(s_letra & 4, s_letra & 6).Value = "TOTALES"
        '    '
        '    Dim s_letra_col As String = Letra_Columna_Excel(colum_total - 1) 'Letra ultima columna de bancos
        '    .Range(.Cells(8, colum_total), .Cells(8, colum_total)).Value = "=SUMA(B8:" & s_letra_col & 8 & ")"

        '    .Columns("B:" & s_letra).ColumnWidth = 20
        '    .Cells.Range("A" & 4, s_letra & 6).Font.Bold = True
        '    .Range("A4", s_letra & "6").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        '    .Range("A4", s_letra & "6").VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        '    .Range(.Cells(4, 1), .Cells(6, colum_total)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        '    .Range(.Cells(8, 1), .Cells(8, colum_total)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

        '    grupo = ""
        '    nro_fila = 9
        '    prim_fila = nro_fila + 1
        '    For i = 0 To dt_grupos.Rows.Count - 1
        '        If grupo <> dt_grupos.Rows(i)("grupo") Then
        '            nro_fila = nro_fila + 1
        '            .Range("A" & nro_fila + i).Value = dt_grupos.Rows(i)("grupo")
        '            grupo = dt_grupos.Rows(i)("grupo")
        '            .Cells(nro_fila + i, 1).Font.Bold = True
        '            nro_fila = nro_fila + 2
        '        End If

        '        .Range("A" & nro_fila + i).Value = dt_grupos.Rows(i)("subgrupo")
        '        .Range(.Cells(nro_fila + i, 1), .Cells(nro_fila + i, colum_total)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        '        sub_id = dt_grupos.Rows(i)("sg_id")


        '        For j = 0 To dt_conmay.Rows.Count - 1
        '            sb_id = dt_conmay.Rows(j)("sb_id")
        '            ctacte = dt_conmay.Rows(j)("bcocta")
        '            If sub_id = sb_id Then
        '                nro_column = 2
        '                For k = 0 To dt_cuentas.Rows.Count - 1
        '                    If ctacte = dt_cuentas.Rows(k)("nro_cta") Then
        '                        .Cells(nro_fila + i, nro_column + k).Value = dt_conmay.Rows(j)("importe")
        '                    End If
        '                Next
        '            End If
        '        Next
        '        ''
        '        ultfila = nro_fila + i
        '        'Suma para cada concepto en forma horizontal
        '        .Range(.Cells(nro_fila + i, colum_total), .Cells(nro_fila + i, colum_total)).Value = "=SUMA(B" & nro_fila + i & ":" & s_letra_col & nro_fila + i & ")"
        '    Next
        '    ultfila = ultfila + 1
        '    'totales
        '    .Range("A" & ultfila + 1).Value = "TOTALES"
        '    .Range("A" & ultfila + 3).Value = "SALDO FINAL"
        '    nro_column = 2
        '    For k = 0 To dt_cuentas.Rows.Count - 1 'Suma de column en vertical
        '        Dim s_letra_col_formula As String = Letra_Columna_Excel(nro_column + k)
        '        .Range(.Cells(ultfila + 1, nro_column + k), .Cells(ultfila + 1, nro_column + k)).Value = "=SUMA(" & s_letra_col_formula & prim_fila & ":" & s_letra_col_formula & ultfila - 1 & ")"
        '        .Range(.Cells(ultfila + 3, nro_column + k), .Cells(ultfila + 3, nro_column + k)).Value = "=(" & s_letra_col_formula & 8 & "+" & s_letra_col_formula & ultfila + 1 & ")" '8 # de fila de sinicial 
        '        .Range(.Cells(prim_fila, nro_column + k + 1), .Cells(ultfila + 3, nro_column + k + 1)).NumberFormat = "###,##0.00"
        '    Next
        '    'Suma en forma horizontal
        '    .Range(.Cells(ultfila + 1, colum_total), .Cells(ultfila + 1, colum_total)).Value = "=SUMA(B" & ultfila + 1 & ":" & s_letra_col & ultfila + 1 & ")"
        '    .Range(.Cells(ultfila + 3, colum_total), .Cells(ultfila + 3, colum_total)).Value = "=SUMA(B" & ultfila + 3 & ":" & s_letra_col & ultfila + 3 & ")"
        '    '
        '    .Range(.Cells(ultfila + 1, nro_column - 1), .Cells(ultfila + 1, colum_total)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        '    .Range(.Cells(ultfila + 3, nro_column - 1), .Cells(ultfila + 3, colum_total)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        '    .Range(.Cells(ultfila + 1, nro_column - 1), .Cells(ultfila + 1, colum_total)).Font.Bold = True
        '    .Range(.Cells(ultfila + 3, nro_column - 1), .Cells(ultfila + 3, colum_total)).Font.Bold = True
        'End With

        'Detalle

        Dim cgimporte As Decimal = 0
        Dim total As Decimal = 0

        With objHojaExcelDetalle
            .Columns("A").ColumnWidth = 38.43
            .Range("A2").Value = "RESUMEN MENSUAL " & cmbMes.Text & " - " & txtAño.Value
            Dim dt_detcon As New DataTable
            dt_detcon = Negocio.Rpt_listarmontoxconcepto(Companhia, txtAño.Value, cmbMes.Value) '
            Dim ctabanco, subgrupo As String
            ctabanco = ""
            grupo = ""
            subgrupo = ""
            nro_fila = 4
            prim_fila = nro_fila + 1
            'Obj_Excel.visible = True
            For i = 0 To dt_detcon.Rows.Count - 1
                '        If ctabanco <> dt_detcon.Rows(i)("CtaBanco") Then
                '            nro_fila = nro_fila + 1
                '            ctabanco = dt_detcon.Rows(i)("CtaBanco")
                '            .Range("A" & nro_fila + i).Value = dt_detcon.Rows(i)("banco") & " - " & dt_detcon.Rows(i)("bcocta")
                '            .Cells(nro_fila + i, 1).Font.Bold = True
                '            nro_fila = nro_fila + 1
                '        End If
                If grupo <> dt_detcon.Rows(i)("grupo") Then
                    If i <> 0 Then
                        nro_fila = nro_fila + 3
                    End If
                    grupo = dt_detcon.Rows(i)("grupo")
                    .Range("A" & nro_fila + i).Value = dt_detcon.Rows(i)("grupo")
                    .Cells(nro_fila + i, 1).Font.Bold = True
                    nro_fila = nro_fila + 1
                    'Else 'prueba
                    '    nro_fila = nro_fila + 1
                End If

                If subgrupo <> dt_detcon.Rows(i)("subgrupo") Then

                    If i > 0 Then
                        .Range("A" & ultfila + 1).Value = "TOTAL (Sin IGV)"
                        .Range("B" & ultfila + 1).Value = cgimporte
                        .Range("A" & ultfila + 2).Value = "TOTAL (Con IGV)"
                        .Range("B" & ultfila + 2).Value = cgimporte * 1.18
                        .Range(.Cells(ultfila + 1, 1), .Cells(ultfila + 2, 2)).Font.Bold = True '
                        .Range(.Cells(ultfila + 1, 1), .Cells(ultfila + 2, 2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nro_fila = nro_fila + 2
                        cgimporte = 0
                        'Else
                        '    nro_fila = nro_fila + 1
                    End If
                    nro_fila = nro_fila + 1
                    subgrupo = dt_detcon.Rows(i)("subgrupo")
                    .Range("A" & nro_fila + i).Value = dt_detcon.Rows(i)("subgrupo")
                    '.Range(.Cells(nro_fila + i, 1), .Cells(nro_fila + i, 2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    '.Cells(nro_fila + i, 1).Font.Bold = True
                    'nro_fila = nro_fila + 1
                End If
                If dt_detcon.Rows(i)("grupo") <> "" Then
                    .Range("A" & nro_fila + i).Value = dt_detcon.Rows(i)("concepto")
                    .Range("B" & nro_fila + i).Value = dt_detcon.Rows(i)("cgimporte")
                    .Range(.Cells(nro_fila + i, 1), .Cells(nro_fila + i, 2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    ultfila = nro_fila + i
                    cgimporte = cgimporte + dt_detcon.Rows(i)("cgimporte")
                    total = total + cgimporte
                End If
            Next
            'para ultimo subgrupo
            'If dt_detcon.Rows(i)("subgrupo") <> "" Then
            .Range("B" & prim_fila, "B" & ultfila + 2).NumberFormat = "###,##0.00" ' Formato
            .Range("A" & ultfila + 1).Value = "TOTAL (Sin IGV)"
            .Range("B" & ultfila + 1).Value = cgimporte
            .Range("A" & ultfila + 2).Value = "TOTAL (Con IGV)"
            .Range("B" & ultfila + 2).Value = cgimporte * 1.18
            .Range(.Cells(ultfila + 1, 1), .Cells(ultfila + 2, 2)).Font.Bold = True '
            .Range(.Cells(ultfila + 1, 1), .Cells(ultfila + 2, 2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            'End If

        End With
        ' objHojaExcelDetalle.Range("A" & ultfila + 1).Value = "TOTALES"
        '.Range(.Cells(ultfila + 1, nro_column - 1), .Cells(ultfila + 1, colum_total)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        '--
        With objHojaExcelObras
            .Columns("B").ColumnWidth = 40
            Dim dt_conmay_gastoxobra As New DataTable
            dt_conmay_gastoxobra = Negocio.Rpt_listar_gasto_obras_xmes(Companhia, txtAño.Value, cmbMes.Value) ' PASAR PARAMETROS
            .Cells(2, 1).value = "INVERSIONES CORRIENTES " & Nombre_Mes(cmbMes.Value).ToString() & " - " & txtAño.Value
            nro_fila = 4
            prim_fila = nro_fila
            For i = 0 To dt_conmay_gastoxobra.Rows.Count - 1
                .Range("A" & nro_fila + i).Value = dt_conmay_gastoxobra.Rows(i)("id_Obra").ToString()
                .Range("B" & nro_fila + i).Value = dt_conmay_gastoxobra.Rows(i)("nom_Obra")
                .Range("C" & nro_fila + i).Value = dt_conmay_gastoxobra.Rows(i)("imp")
                nro_fila = nro_fila + i
            Next
            .Range("B" & nro_fila + 1).Value = "TOTAL "
            .Range("C" & nro_fila + 1).Value = "=SUMA(C" & prim_fila & ":C" & nro_fila & ")"
            .Range("C" & prim_fila, "C" & nro_fila + 1).NumberFormat = "###,##0.00"
            .Range("C" & nro_fila + 1).Font.Bold = True
            .Range(.Cells(prim_fila, 1), .Cells(nro_fila + 1, 3)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        End With
        '--
        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()

        Obj_Excel.visible = True

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Sub ReporteAcumulado()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application

        Obj_Excel = CreateObject("Excel.Application")
        Obj_Libro = Obj_Excel.Workbooks.Add()
        Obj_Libro.Sheets(1).Name = "ACUMULADO FLUJO DE BANCOS"
        Obj_Libro.Sheets(2).Name = "GASTOS POR OBRA"
        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()
        Obj_Hoja.Columns("A").ColumnWidth = 38.43

        Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = Obj_Excel.Worksheets(1)
        'Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = Obj_Excel.Worksheets(2)
        Dim objHojaExcelObraAcum As Microsoft.Office.Interop.Excel.Worksheet = Obj_Excel.Worksheets(2)
        'Dim dt_cuentas As New DataTable
        'dt_cuentas = Negocio.Rpt_listarcuentas(Companhia, txtAño.Value, cmbMes.Value)
        Dim dt_sini As New DataTable
        dt_sini = Negocio.saldo_ini_mensual(Companhia, txtAño.Value, cmbMes.Value)

        Dim dt_grupos As New DataTable
        dt_grupos = Negocio.Rpt_listargrupos()

        Dim dt_conmay As New DataTable
        dt_conmay = Negocio.Rpt_listarconmayacumulado(Companhia, txtAño.Value, cmbMes.Value) ' PASAR PARAMETROS

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Dim sub_id, sb_id As Integer
        Dim i, j, k As Integer
        Dim grupo, ctacte As String
        Dim nro_fila, prim_fila, nro_column, ultfila, colum_total As Integer
        nro_column = 1 'COLUMNA INICIAL
        '.Range("G1:G" & Trim(Str(nRow))).NumberFormat = "###,##0.00"
        With objHojaExcel

            .Activate()
            'cells(fila,column)
            .Cells(2, 1).value = "REPORTE FLUJO BANCOS ACUMULADO HASTA " & cmbMes.Text & " - " & txtAño.Value
            .Cells(4, 1).value = "MES"

            .Cells(6, 1).value = "CONCEPTO"
            .Cells(8, 1).value = "Saldo Inicial"

            Dim N_mes As String
            For i = 1 To dt_sini.Rows.Count
                N_mes = Nombre_Mes(i)
                Dim s_let As String = Letra_Columna_Excel(nro_column + i)
                .Range(s_let & 4, s_let & 6).Merge()
                .Cells(4, nro_column + i).value = N_mes
                .Cells(8, nro_column + i).value = dt_sini.Rows(i - 1)("importe") '*** SALDO INCIAL
                .Range(s_let & 8, s_let & 8).NumberFormat = "###,##0.00" ' Formato
            Next

            colum_total = nro_column + i
            Dim s_letra As String = Letra_Columna_Excel(colum_total)
            .Range(s_letra & 4, s_letra & 6).Merge()
            '.Range("B 4, s_letra & 6).Merge()
            .Range(s_letra & 4, s_letra & 6).Value = "TOTALES"
            '
            Dim s_letra_col As String = Letra_Columna_Excel(colum_total - 1) 'Letra ultima columna de bancos
            .Range(.Cells(8, colum_total), .Cells(8, colum_total)).Value = "=SUMA(B8:" & s_letra_col & 8 & ")"

            .Columns("B:" & s_letra).ColumnWidth = 20
            .Cells.Range("A" & 4, s_letra & 6).Font.Bold = True
            .Range("A4", s_letra & "6").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            .Range("A4", s_letra & "6").VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            .Range(.Cells(4, 1), .Cells(6, colum_total)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(8, 1), .Cells(8, colum_total)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            grupo = ""
            nro_fila = 9
            prim_fila = nro_fila + 1
            For i = 0 To dt_grupos.Rows.Count - 1
                If grupo <> dt_grupos.Rows(i)("grupo") Then
                    nro_fila = nro_fila + 1
                    .Range("A" & nro_fila + i).Value = dt_grupos.Rows(i)("grupo")
                    grupo = dt_grupos.Rows(i)("grupo")
                    .Cells(nro_fila + i, 1).Font.Bold = True
                    nro_fila = nro_fila + 2
                End If

                .Range("A" & nro_fila + i).Value = dt_grupos.Rows(i)("subgrupo")
                .Range(.Cells(nro_fila + i, 1), .Cells(nro_fila + i, colum_total)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                sub_id = dt_grupos.Rows(i)("sg_id")

                For j = 0 To dt_conmay.Rows.Count - 1
                    sb_id = dt_conmay.Rows(j)("sb_id")
                    ctacte = dt_conmay.Rows(j)("cgfecha") 'mes
                    If sub_id = sb_id Then
                        nro_column = 1
                        For k = 1 To cmbMes.Value
                            If ctacte = k Then
                                .Cells(nro_fila + i, nro_column + k).Value = dt_conmay.Rows(j)("importe")
                            End If
                        Next
                    End If
                Next
                ''
                ultfila = nro_fila + i
                'Suma para cada concepto en forma horizontal
                .Range(.Cells(nro_fila + i, colum_total), .Cells(nro_fila + i, colum_total)).Value = "=SUMA(B" & nro_fila + i & ":" & s_letra_col & nro_fila + i & ")"
                .Range(.Cells(nro_fila + i, colum_total), .Cells(nro_fila + i, colum_total)).NumberFormat = "###,##0.00" '
            Next
            ultfila = ultfila + 1
            'totales
            .Range("A" & ultfila + 1).Value = "TOTALES"
            .Range("A" & ultfila + 3).Value = "SALDO FINAL"
            nro_column = 1
            For k = 1 To cmbMes.Value 'Suma de column en vertical
                Dim s_letra_col_formula As String = Letra_Columna_Excel(nro_column + k)
                .Range(.Cells(ultfila + 1, nro_column + k), .Cells(ultfila + 1, nro_column + k)).Value = "=SUMA(" & s_letra_col_formula & prim_fila & ":" & s_letra_col_formula & ultfila - 1 & ")"
                .Range(.Cells(ultfila + 3, nro_column + k), .Cells(ultfila + 3, nro_column + k)).Value = "=(" & s_letra_col_formula & 8 & "+" & s_letra_col_formula & ultfila + 1 & ")" '8 # de fila de sinicial 
                .Range(.Cells(prim_fila, nro_column + k), .Cells(ultfila + 3, nro_column + k)).NumberFormat = "###,##0.00"
            Next
            'Suma en forma horizontal
            .Range(.Cells(ultfila + 1, colum_total), .Cells(ultfila + 1, colum_total)).Value = "=SUMA(B" & ultfila + 1 & ":" & s_letra_col & ultfila + 1 & ")"
            .Range(.Cells(ultfila + 3, colum_total), .Cells(ultfila + 3, colum_total)).Value = "=SUMA(B" & ultfila + 3 & ":" & s_letra_col & ultfila + 3 & ")"
            '
            '
            .Range(.Cells(ultfila + 1, nro_column), .Cells(ultfila + 1, colum_total)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(ultfila + 3, nro_column), .Cells(ultfila + 3, colum_total)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Range(.Cells(ultfila + 1, nro_column), .Cells(ultfila + 1, colum_total)).Font.Bold = True
            .Range(.Cells(ultfila + 3, nro_column), .Cells(ultfila + 3, colum_total)).Font.Bold = True
        End With
        '
        With objHojaExcelObraAcum
            nro_fila = 5
            nro_column = 2
            prim_fila = nro_fila + 1
            .Columns("B").ColumnWidth = 50

            Dim dt_obras As New DataTable
            dt_obras = Negocio.Rpt_listarobras()

            Dim dt_gastoobra As New DataTable
            dt_gastoobra = Negocio.Rpt_gasto_acumuladoxobras(Companhia, txtAño.Value, cmbMes.Value)

            Dim N_Mes As String
            For i = 1 To cmbMes.Value
                N_Mes = Nombre_Mes(i)
                Dim s_let As String = Letra_Columna_Excel(nro_column + i)
                .Cells(4, nro_column + i).value = N_Mes
            Next
            Dim s_lett As String = Letra_Columna_Excel(colum_total + 1)
            .Range(.Cells(4, 2), .Cells(4, colum_total + 1)).Font.Bold = True '

            .Cells(2, 1).value = "REPORTE INVERSIONES CORRIENTES ACUMULADO HASTA " & cmbMes.Text & " - " & txtAño.Value
            '.Cells(2, 1).Font.Bold = True
            .Cells(4, 2).value = "OBRAS"
            .Range("A" & 4, "B" & 4).Merge()
            .Range(s_lett & 4, s_lett & 4).Value = "TOTALES"
            .Range("A4", s_lett & "4").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            .Range(.Cells(4, 1), .Cells(4, colum_total + 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            For i = 0 To dt_obras.Rows.Count - 1
                
                .Range("A" & nro_fila + i).Value = dt_obras.Rows(i)("id_Obra") 'Obras
                .Range("B" & nro_fila + i).Value = dt_obras.Rows(i)("nom_Obra") 'Obras
                .Range(.Cells(nro_fila + i, 1), .Cells(nro_fila + i, colum_total + 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                sub_id = dt_obras.Rows(i)("id_Obra")

                For j = 0 To dt_gastoobra.Rows.Count - 1
                    sb_id = dt_gastoobra.Rows(j)("id_Obra")
                    ctacte = dt_gastoobra.Rows(j)("cgfecha") 'mes
                    If sub_id = sb_id Then
                        nro_column = 2
                        For k = 1 To cmbMes.Value
                            If ctacte = k Then
                                .Cells(nro_fila + i, nro_column + k).Value = dt_gastoobra.Rows(j)("imp")
                            End If
                        Next
                    End If
                Next
                ''
                ultfila = nro_fila + i
                Dim s_letra_col As String = Letra_Columna_Excel(colum_total) 'Letra ultima columna de bancos
                ''Suma para cada concepto en forma horizontal
                .Range(.Cells(nro_fila + i, colum_total + 1), .Cells(nro_fila + i, colum_total + 1)).Value = "=SUMA(C" & nro_fila + i & ":" & s_letra_col & nro_fila + i & ")"

                .Range(.Cells(nro_fila + i, colum_total + 1), .Cells(nro_fila + i, colum_total + 1)).NumberFormat = "###,##0.00" '
            Next
            'totales
            Dim s_letra_colu As String = Letra_Columna_Excel(colum_total + 1)
            .Range(.Cells(ultfila + 1, 1), .Cells(ultfila + 1, colum_total + 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            .Cells.Range("A" & ultfila + 1, s_letra_colu & ultfila + 1).Font.Bold = True
            .Cells.Range(s_letra_colu & prim_fila - 1, s_letra_colu & ultfila + 1).Font.Bold = True
            .Range("B" & ultfila + 1).Value = "TOTALES"
            .Range("A" & ultfila + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            .Range("A" & ultfila + 1, "B" & ultfila + 1).Merge()

            nro_column = 2
            For k = 1 To cmbMes.Value + 1 'Suma de column en vertical
                Dim s_letra_col_formula As String = Letra_Columna_Excel(nro_column + k)
                .Range(.Cells(ultfila + 1, nro_column + k), .Cells(ultfila + 1, nro_column + k)).Value = "=SUMA(" & s_letra_col_formula & prim_fila - 1 & ":" & s_letra_col_formula & ultfila & ")"
                .Range(.Cells(prim_fila - 1, nro_column + k), .Cells(ultfila + 3, nro_column + k)).NumberFormat = "###,##0.00"
            Next
        End With
        '
        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()

        Obj_Excel.visible = True
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Public Function Letra_Columna_Excel(ByVal p_numero_columna As Integer) As String
        Dim n1 As Integer
        Dim n2 As Integer
        Dim s_letra_columna As String = ""
        If p_numero_columna > 26 Then
            n2 = p_numero_columna
            n1 = 0
            Do While n2 > 26
                n1 = n1 + 1
                n2 = n2 - 26
            Loop
            s_letra_columna = Chr(n1 + 64) & Chr(n2 + 64)
        Else
            s_letra_columna = Chr(p_numero_columna + 64)
        End If
        Return s_letra_columna
    End Function

    Public Function Nombre_Mes(ByVal p_mes As Integer)
        Dim s_nombre_mes As String = ""
        Select Case p_mes
            Case 1
                s_nombre_mes = "ENERO"
            Case 2
                s_nombre_mes = "FEBRERO"
            Case 3
                s_nombre_mes = "MARZO"
            Case 4
                s_nombre_mes = "ABRIL"
            Case 5
                s_nombre_mes = "MAYO"
            Case 6
                s_nombre_mes = "JUNIO"
            Case 7
                s_nombre_mes = "JULIO"
            Case 8
                s_nombre_mes = "AGOSTO"
            Case 9
                s_nombre_mes = "SETIEMBRE"
            Case 10
                s_nombre_mes = "OCTUBRE"
            Case 11
                s_nombre_mes = "NOVIEMBRE"
            Case 12
                s_nombre_mes = "DICIEMBRE"
        End Select
        Return s_nombre_mes
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Rbt_resumen.Checked = True Then
                ReporteResumen()
            ElseIf Rbt_acumulado.Checked = True Then
                ReporteAcumulado()
            ElseIf rdbflujo.Checked = True Then
                FlujoCaja()
            Else
                ReporteDetalle()
            End If
        Catch ex As Exception
            MsgBox("Error al cargar el Reporte")
        End Try


    End Sub
    Sub FlujoCaja()
        Dim dtFlujo As New DataTable
        Dim letra As String = ""
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\RPT_FLUJOCAJA_" & cmbMes.Text.Trim & ".xls")
            File.Copy(RutaReporteERP & "PLANTILLAFLUJOCAJA.xls", path & "\RPT_FLUJOCAJA_" & cmbMes.Text.Trim & ".xls")
            m_Excel.Workbooks.Open(path & "\RPT_FLUJOCAJA_" & cmbMes.Text.Trim & ".xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcel_EgresoDet As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            For i As Int32 = 1 To cmbMes.Value
                dtFlujo = Negocio.Rpt_FlujoCaja(txtAño.Value, i)
                imprimirFlujo(m_Excel, objHojaExcel, dtFlujo, letra_mes(i))
            Next
            objHojaExcel.Range("A2").Value = "FLUJO DE CAJA " & txtAño.Value

            objHojaExcel.Range("D5").Value = "Ene-" & txtAño.Value
            objHojaExcel.Range("E5").Value = "Feb-" & txtAño.Value
            objHojaExcel.Range("F5").Value = "Mar-" & txtAño.Value
            objHojaExcel.Range("G5").Value = "Abr-" & txtAño.Value
            objHojaExcel.Range("H5").Value = "May-" & txtAño.Value
            objHojaExcel.Range("I5").Value = "Jun-" & txtAño.Value
            objHojaExcel.Range("J5").Value = "Jul-" & txtAño.Value
            objHojaExcel.Range("K5").Value = "Ago-" & txtAño.Value
            objHojaExcel.Range("L5").Value = "Set-" & txtAño.Value
            objHojaExcel.Range("M5").Value = "Oct-" & txtAño.Value
            objHojaExcel.Range("N5").Value = "Nov-" & txtAño.Value
            objHojaExcel.Range("O5").Value = "Dic-" & txtAño.Value

            objHojaExcel.Range("D4").Value = "Real"
            objHojaExcel.Range(letra_mes(cmbMes.Value + 1) & "4").Value = "Proyectado"
            objHojaExcel.Range("D4:" & letra_mes(cmbMes.Value) & "4").Merge()
            objHojaExcel.Range("D4:" & letra_mes(cmbMes.Value) & "4").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            objHojaExcel.Range(letra_mes(cmbMes.Value + 1) & "4:O4").Merge()
            objHojaExcel.Range(letra_mes(cmbMes.Value + 1) & "4:O4").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            exportarDetEgreso(objHojaExcel_EgresoDet, dtFlujo, m_Excel)
            objHojaExcel.Activate()
            m_Excel.Visible = True
        Catch ex As Exception
            m_Excel.Quit()
            MsgBox(ex.Message)
        End Try
    End Sub

    Function letra_mes(ByVal mes As Int32) As String
        Dim letra As String = ""
        Select Case mes
            Case 1 : letra = "D"
            Case 2 : letra = "E"
            Case 3 : letra = "F"
            Case 4 : letra = "G"
            Case 5 : letra = "H"
            Case 6 : letra = "I"
            Case 7 : letra = "J"
            Case 8 : letra = "K"
            Case 9 : letra = "L"
            Case 10 : letra = "M"
            Case 11 : letra = "N"
            Case 12 : letra = "O"
        End Select
        Return letra
    End Function

    Sub imprimirFlujo(ByVal m_Excel As Microsoft.Office.Interop.Excel.Application, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dtFlujo As DataTable, ByVal letra As String)
        Try
            If dtFlujo.Rows.Count > 0 Then
                Dim nfila As Integer
                nfila = 0
                With objHojaExcel
                    Dim nfilaini As Integer
                    Dim nfilaini_suma As Integer
                    Dim nfilault As Integer = 0
                    nfilaini_suma = 6
                    nfilaini = 7

                    For i As Int16 = 0 To dtFlujo.Rows.Count - 1
                        If dtFlujo.Rows(i)("ORDEN") = 7 Then
                            nfilaini += 1
                        End If
                        .Activate()
                        .Range("A" & nfilaini + i).Value = dtFlujo.Rows(i)("ORDEN")
                        .Range("B" & nfilaini + i).Value = dtFlujo.Rows(i)("DESCRIPCION")
                        .Range(letra & nfilaini + i).Value = dtFlujo.Rows(i)("VALOR")
                        .Range("P" & nfilaini + i).Value = "=SUMA(D" & nfilaini + i & ":O" & nfilaini + i & ")"
                        .Range("P" & nfilaini + i).Font.Bold = True
                        .Range(letra & nfilaini + i).NumberFormat = "#,##0_ ;[Rojo]-#,##0;-"
                        '.Range(.Cells(nfilaini + i, 1), .Cells(nfilaini + i, 16)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfilaini + i
                    Next
                    '.Range("J" & nfila + 2).Value = "=SUMA(J5:J" & nfila & ")"
                    '.Range("J" & nfila + 2).Font.Bold = True
                    '.Range("J" & nfila + 2).NumberFormat = "###,##0.00"
                    '.Range("J" & nfila + 2).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    '.Range("J" & nfila + 2).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                End With
            End If

        Catch ex As Exception

        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub exportarDetEgreso(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal dt As DataTable, ByVal m_excel As Microsoft.Office.Interop.Excel.Application)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 2
            Dim nfilaini As Integer = 2
            Dim filaultima As Integer = 2

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                Dim Sql As String

                Sql = "USP_DETALLE_EGRESO_FLUJO " & txtAño.Value & "," & cmbMes.Value & ""

                With m_excel.ActiveWorkbook.PivotCaches.Create(Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlExternal)

                    Dim sCnx As String

                    sCnx = "OLEDB;Provider=SQLOLEDB.1;Use Procedure for Prepare=1;Use Encryption for Data=False;Auto Translate=True;" & _
                    "Password =" & PASSINI & ";" & _
                    "Persist Security Info=False;" & _
                    "User ID=" & USERINI & ";" & _
                    "Initial Catalog=" & BDINI & ";" & _
                    "Data Source=" & DATASOURCE & ""

                    .Connection = sCnx
                    .CommandType = Microsoft.Office.Interop.Excel.XlCmdType.xlCmdSql
                    .CommandText = Sql

                    .CreatePivotTable(TableDestination:=m_excel.ActiveWorkbook.ActiveSheet.Range("A3"), TableName:="Tabla dinámica1")
                End With

                With m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1")
                    With .PivotFields("MERCADO")
                        .Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlPageField
                        .Position = 1
                        .Name = "MERCADO"
                    End With
                    With .PivotFields("DESC_MES")
                        .Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlColumnField
                        .Position = 1
                    End With

                    With .PivotFields("CARACTERISTICA")
                        .Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 1
                    End With

                    With .PivotFields("IMPORTE")
                        .Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 2
                    End With

                    .AddDataField(.PivotFields("IMPORTE"), "Suma de IMPORTE", Microsoft.Office.Interop.Excel.XlConsolidationFunction.xlSum)
                    m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("Suma de IMPORTE").NumberFormat = "#,##0.00"

                End With
            End With
            'm_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").ColumnGrand = False
            m_excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").SubtotalLocation(Microsoft.Office.Interop.Excel.XlSubtototalLocationType.xlAtBottom)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub mnu_exportar_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_exportar_excel.Click
        'Dim rpta As Long
        'Dim archivoexcel As String = Trim(Me.exportFileName.Text)

        Try
            'If Trim(Dir(Trim(Me.exportFileName.Text), vbArchive)) <> "" Then
            '    rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            '    If rpta = vbNo Then Exit Sub
            'End If
            Me.UltraGridExcelExporter1.Export(GridConsultaDetalle, "D:\DetalleFCB.xls")

            ''poner cabecera
            'If b_imprimir_cabecera = True Then Call poner_cabecera_archivo_excel(archivoexcel)

            'MessageBox.Show("Exportado " & Chr(13) & Me.exportFileName.Text, "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Abrir_Archivo()
            'If ChkAbrir.Checked Then 
            'Me.Close()

        Catch ex As Exception
            'MessageBox.Show("Ruta Especificada No Existe", "Invalid File Name")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Abrir_Archivo()

        Dim xApp As Object
        Dim xLibros As Object
        Dim xLibro As Object
        Dim archivoexcel As String = Trim("D:\DetalleFCB.xls")

        'Abrimos el archivo
        xApp = CreateObject("excel.application")
        xLibros = xApp.Workbooks

        '' ''poner cabecera antes de abrir
        ''If b_imprimir_cabecera = True Then Call poner_cabecera_archivo_excel(archivoexcel)

        xLibros.Open(archivoexcel, 3)
        xLibro = xApp.ActiveWorkBook
        xApp.Visible = True

    End Sub

    Private Sub GridConsultaDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridConsultaDetalle.InitializeLayout
        e.Layout().Bands(0).Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        'e.Layout.Bands(0).Columns("IdCuadro").Hidden = True
        'e.Layout().Bands(0).Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        'e.Layout().Bands(0).Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
        'e.Layout().Bands(0).Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
    End Sub

    'Private Sub poner_cabecera_archivo_excel(ByVal p_archivo As String)

    '    Dim archivo_excel As New Microsoft.Office.Interop.Excel.Application
    '    Dim libro_excel As Microsoft.Office.Interop.Excel.Workbook = Nothing
    '    Dim h_hoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing

    '    ''abrir el archivo excel
    '    Try
    '        libro_excel = archivo_excel.Workbooks.Open(p_archivo, , False, , , , True, , , True)
    '    Catch ex As Exception
    '        Avisar("Error al intentar abrir el Archivo" & vbCrLf & ex.Message.ToString)
    '    End Try

    '    Try
    '        h_hoja = libro_excel.Sheets(1)
    '        h_hoja.Range("A1:AZ8").Insert()

    '        h_hoja.Cells(1, 1).value = CIA_AUX_DES
    '        h_hoja.Cells(2, 1).value = "RUC: " & CIA_AUX_RUC
    '        h_hoja.Cells(3, 1).value = "FECHA: " & Format(Now, g_formato_fecha_mostrar_con_hora)
    '        h_hoja.Cells(4, 1).value = s_titulo_reporte
    '        h_hoja.Cells(5, 1).value = s_subtitulo_reporte_1
    '        h_hoja.Cells(6, 1).value = s_subtitulo_reporte_2
    '        h_hoja.Cells(7, 1).value = s_subtitulo_reporte_3

    '    Catch ex As Exception
    '        Avisar("Error al Insertar Cabecera del Archivo" & vbCrLf & ex.Message.ToString)
    '    End Try

    '    libro_excel.Save()
    '    libro_excel.Close()
    '    libro_excel = Nothing

    '    archivo_excel.Quit()
    '    archivo_excel = Nothing

    'End Sub

    Private Sub ExportarAExcelDetalladoPorBancosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelDetalladoPorBancosToolStripMenuItem.Click
        Call ReporteDetalle2()
    End Sub
End Class