Imports Microsoft
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Excel.Constants
Imports Microsoft.Office.Interop.Excel.XlThemeColor
Imports Microsoft.Office.Interop.Excel.XlLineStyle
Imports Microsoft.Office.Interop.Excel.XlBordersIndex
Imports Microsoft.Office.Interop.Excel.XlBorderWeight
Imports Microsoft.Office.Interop.Excel.XlFormatConditionType

Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Threading

Public Class RptActivo

    Private List_Reporte As List(Of ETActivo) = Nothing
    'Private Shared List1 As List(Of ETPersonal)
    'Private Shared List2 As List(Of ETPersonal)
    'Private Shared List3 As List(Of ETPersonal)
    'Private Shared List4 As List(Of ETPersonal)
    Private Tabla As System.Data.DataTable = Nothing

    Public Sub Generar_Cronograma(ByVal Rpt As ETActivo, ByVal pIdPlanta As Int16, ByVal pNomPlanta As String)

        Dim nFil As Int16
        Dim nCol As Int16
        Dim xlApp2 As Excel.Application
        Dim xlApp1 As Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet


        xlApp1 = CreateObject("Excel.Application")
        xlApp1.Workbooks.Add()
        xlApp2 = xlApp1.Application
        xlBook = xlApp2.Workbooks(1)
        xlSheet = xlApp2.Worksheets("HOJA1")



        Dim item As Integer = 0
        Dim nColMax As Integer = 8
        'xlBook.Name = "CRONOGRAMA  " & Rpt.Semana.ToString & "-" & Rpt.Anho.ToString
        With xlSheet
            nFil = nFil + 1
            .Columns.Range("A:A").ColumnWidth = 2
            .Columns.Range("B:B").ColumnWidth = 10
            .Columns.Range("C:C").ColumnWidth = 6
            .Columns.Range("D:D").ColumnWidth = 35
            .Columns.Range("E:E").ColumnWidth = 6
            .Columns.Range("F:F").ColumnWidth = 35
            .Columns.Range("G:G").ColumnWidth = 6
            .Columns.Range("H:H").ColumnWidth = 35


            .Range("A:A").Merge()
            .Cells(nFil, 2).Value = "COMACSA"
            .Cells(nFil, 2).Font.size = 13
            .Cells(nFil, 2).Font.Bold = True
            'xlSheet.Range("B1:K1").Merge()
            'xlSheet.Range("B1:K1").HorizontalAlignment = xlCenter

            .Cells(nFil, nColMax).Value = "ROL DE TURNOS "
            .Cells(nFil, nColMax).Font.size = 13
            .Cells(nFil, nColMax).Font.Bold = True
            'xlSheet.Range("B1:K1").Merge()
            .Range(.Cells(nFil, nColMax), .Cells(nFil, nColMax)).HorizontalAlignment = xlRight

            nFil = nFil + 1

            .Range("A:A").Merge()
            .Cells(nFil, 2).Value = "PLANTA INFANTAS"
            .Cells(nFil, 2).Font.size = 13
            .Cells(nFil, 2).Font.Bold = True
            .Range(.Cells(nFil, nColMax), .Cells(nFil, nColMax)).HorizontalAlignment = xlRight
            'xlSheet.Range("B1:K1").Merge()
            'xlSheet.Range("B1:K1").HorizontalAlignment = xlCenter

            .Cells(nFil, nColMax).Value = "SEMANA Nº " & Space(3) & ":" & Space(2) & Rpt.Semana.ToString
            .Cells(nFil, nColMax).Font.size = 13
            .Cells(nFil, nColMax).Font.Bold = True
            'xlSheet.Range("B1:K1").Merge()
            'xlSheet.Range("B1:K1").HorizontalAlignment = xlCenter

            nFil = nFil + 2
            .Cells(nFil, 2).Value = pNomPlanta.Trim
            .Cells(nFil, 2).Font.size = 16
            .Cells(nFil, 2).Font.Bold = True
            .Range(.Cells(nFil, 2), .Cells(nFil, nColMax)).Merge()
            .Range(.Cells(nFil, 2), .Cells(nFil, nColMax)).HorizontalAlignment = xlCenter

            nFil = nFil + 1
            '.Cells(nFil, 2).Value = "SEMANA DEL " & FormatDateTime(Rpt.FechaInicio.AddDays(7), DateFormat.LongDate).ToString
            .Cells(nFil, 2).Value = "SEMANA DEL " & Rpt.FechaInicio.Day.ToString & " DE " & MonthName(Rpt.FechaInicio.Month).ToUpper.ToString & " AL " & Rpt.FechaInicio.AddDays(6).Day.ToString & " DE " & MonthName(Rpt.FechaInicio.AddDays(6).Month).ToUpper.ToString & " DEL " & Rpt.FechaInicio.AddDays(6).Year.ToString
            .Cells(nFil, 2).Font.size = 16
            .Cells(nFil, 2).Font.Bold = True
            .Range(.Cells(nFil, 2), .Cells(nFil, nColMax)).Merge()
            .Range(.Cells(nFil, 2), .Cells(nFil, nColMax)).HorizontalAlignment = xlCenter

            nFil = nFil + 1
            nCol = 3
            .Cells(nFil, nCol).Value = "Primer Turno"
            .Cells(nFil, nCol).Font.size = 12
            .Cells(nFil, nCol).Font.Bold = True
            .Range(.Cells(nFil, nCol), .Cells(nFil, nCol + 1)).Merge()
            .Range(.Cells(nFil, nCol), .Cells(nFil, nCol + 1)).HorizontalAlignment = xlCenter

            nCol = 5
            .Cells(nFil, nCol).Value = "Segundo Turno"
            .Cells(nFil, nCol).Font.size = 12
            .Cells(nFil, nCol).Font.Bold = True
            .Range(.Cells(nFil, nCol), .Cells(nFil, nCol + 1)).Merge()
            .Range(.Cells(nFil, nCol), .Cells(nFil, nCol + 1)).HorizontalAlignment = xlCenter

            nCol = 7
            .Cells(nFil, nCol).Value = "Tercer Turno"
            .Cells(nFil, nCol).Font.size = 12
            .Cells(nFil, nCol).Font.Bold = True
            .Range(.Cells(nFil, nCol), .Cells(nFil, nCol + 1)).Merge()
            .Range(.Cells(nFil, nCol), .Cells(nFil, nCol + 1)).HorizontalAlignment = xlCenter

            'nFil = 8

            nFil = nFil + 2
            Dim I As Int16 = 1

            Dim NroFilaxUnidad As Int16 = 0

            List_Reporte = New List(Of ETActivo)
            Entidad.Activo = New ETActivo
            Negocio.Activo = New NGActivo
            Entidad.MyLista = New ETMyLista
            Tabla = New System.Data.DataTable

            Entidad.Activo.Anho = Rpt.Anho.ToString
            Entidad.Activo.Semana = Rpt.Semana.ToString
            Entidad.Activo.Dia = I

            Entidad.MyLista = Negocio.Activo.ConsultarCronograma6(Entidad.Activo, pIdPlanta)

            If Entidad.MyLista.Validacion Then
                List_Reporte = Entidad.MyLista.Ls_Activo
                Entidad.Activo = Negocio.Activo.Reporte_Cronograma(Entidad.Activo, pIdPlanta)
                If Entidad.Activo.Validacion Then
                    Tabla = Entidad.Activo.Tabla.Copy
                End If
            End If

            For Each lRow In List_Reporte
                Dim LsRow As DataRow() = Nothing
                Dim LsRow_1 As DataRow() = Nothing
                Dim LsRow_2 As DataRow() = Nothing
                Dim LsRow_3 As DataRow() = Nothing
                Dim LsRow_4 As DataRow() = Nothing
                Dim SubTabla As System.Data.DataTable = Nothing
                SubTabla = New System.Data.DataTable
                LsRow = Tabla.Select("Placa=" & lRow.Placa & " And CodTipo=" & lRow.CodTipo, "Turno Asc,DesPersonal Asc")
                If LsRow.Count > 0 Then

                    SubTabla = Tabla.Clone

                    For Each dRow As DataRow In LsRow
                        SubTabla.ImportRow(dRow)
                    Next

                    LsRow_1 = SubTabla.Select("Turno=" & 1, "DesPersonal ASC")
                    LsRow_2 = SubTabla.Select("Turno=" & 2, "DesPersonal ASC")
                    LsRow_3 = SubTabla.Select("Turno=" & 3, "DesPersonal ASC")
                    LsRow_4 = SubTabla.Select("Turno=" & 4, "DesPersonal ASC")

                    NroFilaxUnidad = LsRow_1.Count

                    If NroFilaxUnidad < LsRow_2.Count Then NroFilaxUnidad = LsRow_2.Count

                    If NroFilaxUnidad < LsRow_3.Count Then NroFilaxUnidad = LsRow_3.Count

                    If NroFilaxUnidad < LsRow_4.Count Then NroFilaxUnidad = LsRow_4.Count

                    If NroFilaxUnidad <> 0 Then

                        'xlSheet.Cells(nFil, 2).Value = lRow.Placa
                        'xlSheet.Cells(nFil, 2).NumberFormat = "000"
                        'xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).Merge()
                        'xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).HorizontalAlignment = xlCenter
                        'xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).VerticalAlignment = xlCenter

                        .Cells(nFil, 3).Value = "MOLINO " & lRow.Descripcion.Trim
                        .Cells(nFil, 3).font.bold = True
                        .Cells(nFil, 3).font.size = 14
                        'xlSheet.Range("C" & nFil & ":C" & nFil + NroFilaxUnidad - 1).Merge()
                        'xlSheet.Range("C" & nFil & ":C" & nFil + NroFilaxUnidad - 1).VerticalAlignment = xlCenter
                        .Range(.Cells(nFil, 2), .Cells(nFil, nColMax)).Merge()
                        .Range(.Cells(nFil, 2), .Cells(nFil, nColMax)).VerticalAlignment = xlCenter
                        .Range(.Cells(nFil, 2), .Cells(nFil, nColMax)).HorizontalAlignment = xlCenter
                        nFil = nFil + 1
                        item = nFil - 1

                        For Each vRow1 As DataRow In LsRow_1
                            item += 1
                            .Cells(item, 2).Value = "MOLINERO"
                            .Cells(item, 2).HorizontalAlignment = xlLeft
                            .Cells(item, 3).Value = Right(vRow1("CodPersonal"), 4)
                            .Cells(item, 3).HorizontalAlignment = xlLeft

                            .Cells(item, 4).Value = vRow1("DesPersonal")
                            .Cells(item, 4).HorizontalAlignment = xlLeft
                            .Range(.Cells(item, 2), .Cells(item, nColMax)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        Next

                        item = nFil - 1

                        For Each vRow2 As DataRow In LsRow_2
                            item += 1
                            .Cells(item, 5).Value = Right(vRow2("CodPersonal"), 4)
                            .Cells(item, 5).HorizontalAlignment = xlLeft

                            .Cells(item, 6).Value = vRow2("DesPersonal")
                            .Cells(item, 6).HorizontalAlignment = xlLeft
                            .Range(.Cells(item, 2), .Cells(item, nColMax)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        Next

                        item = nFil - 1

                        For Each vRow3 As DataRow In LsRow_3
                            item += 1
                            .Cells(item, 7).Value = Right(vRow3("CodPersonal"), 4)
                            .Cells(item, 7).HorizontalAlignment = xlLeft
                            .Cells(item, 8).Value = vRow3("DesPersonal")
                            .Cells(item, 8).HorizontalAlignment = xlLeft
                            .Range(.Cells(item, 2), .Cells(item, nColMax)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        Next

                        item = nFil - 1

                        'For Each vRow4 As DataRow In LsRow_4
                        '    item += 1
                        '    xlSheet.Cells(item, 10).Value = vRow4("CodPersonal")
                        '    xlSheet.Cells(item, 10).HorizontalAlignment = xlCenter
                        '    xlSheet.Cells(item, 11).Value = vRow4("DesPersonal")
                        'Next

                        nFil = nFil + NroFilaxUnidad

                    End If
                End If
            Next

        End With
        xlSheet = xlApp2.Worksheets("Hoja1")
        xlApp2.Application.ActiveWindow.DisplayGridlines = False

        xlSheet.Range("A1:A1").Select()


        xlApp1.ActiveWindow.Zoom = 80
        xlApp2.Application.Visible = True

        EiminaReferencias(xlSheet)
        EiminaReferencias(xlBook)
        EiminaReferencias(xlApp2)
        EiminaReferencias(xlApp1)
        System.GC.Collect()

Termina:

        If Not xlApp2 Is Nothing Then xlApp2 = Nothing
        If Not xlApp1 Is Nothing Then xlApp1 = Nothing
        If Not xlBook Is Nothing Then xlBook = Nothing
        If Not xlSheet Is Nothing Then xlSheet = Nothing

        Exit Sub
        '    'Dim oExcel As Excel.Application
        '    'Dim oBook As Excel.Workbook = Nothing
        '    'Dim xlSheet As Excel.Worksheet = Nothing



        '    oExcel = New Excel.Application
        '    oExcel.Caption = "CRONOGRAMA  " & Rpt.Semana.ToString & "-" & Rpt.Anho.ToString

        '    oExcel.Visible = False

        '    oBook = oExcel.Workbooks.Add()
        '    Dim I As Int16 = 1
        '    'For I As Int16 = 7 To 1 Step -1

        '    'xlSheet = oBook.Worksheets.Add()
        '    'xlSheet.Name = ReNombrarHojaExcel(I)
        '    nFil = nFil + 1

        '    'xlSheet.Range("A:A").Merge()
        '    xlSheet.Cells(nFil, 2).Value = "COMACSA"
        '    xlSheet.Cells(nFil, 2).Font.size = 14
        '    xlSheet.Cells(nFil, 2).Font.Bold = True
        '    'xlSheet.Range("B1:K1").Merge()
        '    'xlSheet.Range("B1:K1").HorizontalAlignment = xlCenter

        '    xlSheet.Cells(nFil, nColMax).Value = "ROL DE TURNOS "
        '    xlSheet.Cells(nFil, nColMax).Font.size = 14
        '    xlSheet.Cells(nFil, nColMax).Font.Bold = True
        '    'xlSheet.Range("B1:K1").Merge()
        '    'xlSheet.Range("B1:K1").HorizontalAlignment = xlCenter

        '    nFil = nFil + 1

        '    xlSheet.Range("A:A").Merge()
        '    xlSheet.Cells(nFil, 2).Value = "PLANTA INFANTAS"
        '    xlSheet.Cells(nFil, 2).Font.size = 14
        '    xlSheet.Cells(nFil, 2).Font.Bold = True
        '    'xlSheet.Range("B1:K1").Merge()
        '    'xlSheet.Range("B1:K1").HorizontalAlignment = xlCenter

        '    xlSheet.Cells(nFil, nColMax).Value = "SEMANA" & Space(3) & ":" & Space(2) & Rpt.Semana.ToString
        '    xlSheet.Cells(nFil, nColMax).Font.size = 14
        '    xlSheet.Cells(nFil, nColMax).Font.Bold = True
        '    'xlSheet.Range("B1:K1").Merge()
        '    'xlSheet.Range("B1:K1").HorizontalAlignment = xlCenter

        '    nFil = nFil + 1

        '    xlSheet.Cells(2, 2).Value = "AÑO" & Space(10) & ":" & Space(2) & Rpt.Anho.ToString
        '    xlSheet.Cells(2, 2).Font.Size = 14
        '    xlSheet.Cells(2, 2).Font.Bold = True
        '    xlSheet.Range("B2:K2").Merge()
        '    xlSheet.Cells(3, 2).Value = "SEMANA" & Space(3) & ":" & Space(2) & Rpt.Semana.ToString


        '    xlSheet.Cells(3, 2).Font.Size = 14
        '    xlSheet.Cells(3, 2).Font.Bold = True
        '    xlSheet.Range("B3:K3").Merge()
        '    xlSheet.Range("B4:K4").Merge()
        '    xlSheet.Cells(4, 2).Value = "DIA" & Space(12) & ":" & Space(2) & FormatDateTime(Rpt.FechaInicio.AddDays(I - 1), DateFormat.LongDate).ToString
        '    xlSheet.Cells(4, 2).Font.Size = 14
        '    xlSheet.Cells(4, 2).Font.Bold = True
        '    xlSheet.Range("B5:K5").Merge()

        '    nFil = 6
        '    xlSheet.Range("A:A").ColumnWidth = 3

        '    xlSheet.Range("B:B").ColumnWidth = 9
        '    xlSheet.Range("B6:B7").Merge()
        '    xlSheet.Range("B6:B7").HorizontalAlignment = xlCenter
        '    xlSheet.Range("B6:B7").VerticalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 2).Value = "PLACA"
        '    xlSheet.Cells(nFil, 2).Font.Bold = True

        '    xlSheet.Range("C:C").ColumnWidth = 25
        '    xlSheet.Range("C6:C7").Merge()
        '    xlSheet.Range("C6:C7").HorizontalAlignment = xlCenter
        '    xlSheet.Range("C6:C7").VerticalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 3).Value = "UNIDAD"
        '    xlSheet.Cells(nFil, 3).Font.Bold = True

        '    xlSheet.Range("D6:E6").Merge()
        '    xlSheet.Range("D6:E6").HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 4).Value = "TURNO 1"
        '    xlSheet.Cells(nFil, 4).Font.Bold = True

        '    xlSheet.Range("D:D").ColumnWidth = 9
        '    xlSheet.Cells(nFil + 1, 4).Value = "CODIGO"
        '    xlSheet.Cells(nFil + 1, 4).HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil + 1, 4).Font.Bold = True

        '    xlSheet.Range("E:E").ColumnWidth = 41
        '    xlSheet.Cells(nFil + 1, 5).Value = "PERSONAL"
        '    xlSheet.Cells(nFil + 1, 5).Font.Bold = True

        '    xlSheet.Range("F6:G6").Merge()
        '    xlSheet.Range("F6:G6").HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 6).Value = "TURNO 2"
        '    xlSheet.Cells(nFil, 6).Font.Bold = True

        '    xlSheet.Range("F:F").ColumnWidth = 9
        '    xlSheet.Cells(nFil + 1, 6).Value = "CODIGO"
        '    xlSheet.Cells(nFil + 1, 6).HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil + 1, 6).Font.Bold = True

        '    xlSheet.Range("G:G").ColumnWidth = 41
        '    xlSheet.Cells(nFil + 1, 7).Value = "PERSONAL"
        '    xlSheet.Cells(nFil + 1, 7).Font.Bold = True

        '    xlSheet.Range("H6:I6").Merge()
        '    xlSheet.Range("H6:I6").HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 8).Value = "TURNO 3"
        '    xlSheet.Cells(nFil, 8).Font.Bold = True

        '    xlSheet.Range("H:H").ColumnWidth = 9
        '    xlSheet.Cells(nFil + 1, 8).Value = "CODIGO"
        '    xlSheet.Cells(nFil + 1, 8).HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil + 1, 8).Font.Bold = True

        '    xlSheet.Range("I:I").ColumnWidth = 41
        '    xlSheet.Cells(nFil + 1, 9).Value = "PERSONAL"
        '    xlSheet.Cells(nFil + 1, 9).Font.Bold = True

        '    xlSheet.Range("J6:K6").Merge()
        '    xlSheet.Range("J6:K6").HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 10).Value = "HORARIO NORMAL"
        '    xlSheet.Cells(nFil, 10).Font.Bold = True

        '    xlSheet.Range("J:J").ColumnWidth = 9
        '    xlSheet.Cells(nFil + 1, 10).Value = "CODIGO"
        '    xlSheet.Cells(nFil + 1, 10).HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil + 1, 10).Font.Bold = True

        '    xlSheet.Range("K:K").ColumnWidth = 41
        '    xlSheet.Cells(nFil + 1, 11).Value = "PERSONAL"
        '    xlSheet.Cells(nFil + 1, 11).Font.Bold = True

        '    nFil = 8

        '    Dim NroFilaxUnidad As Int16 = 0

        '    List_Reporte = New List(Of ETActivo)
        '    Entidad.Activo = New ETActivo
        '    Negocio.Activo = New NGActivo
        '    Entidad.MyLista = New ETMyLista
        '    Tabla = New System.Data.DataTable

        '    Entidad.Activo.Anho = Rpt.Anho.ToString
        '    Entidad.Activo.Semana = Rpt.Semana.ToString
        '    Entidad.Activo.Dia = I

        '    Entidad.MyLista = Negocio.Activo.ConsultarCronograma6(Entidad.Activo, pIdPlanta)

        '    If Entidad.MyLista.Validacion Then
        '        List_Reporte = Entidad.MyLista.Ls_Activo
        '        Entidad.Activo = Negocio.Activo.Reporte_Cronograma(Entidad.Activo)
        '        If Entidad.Activo.Validacion Then
        '            Tabla = Entidad.Activo.Tabla.Copy
        '        End If
        '    End If

        '    For Each lRow In List_Reporte
        '        Dim LsRow As DataRow() = Nothing
        '        Dim LsRow_1 As DataRow() = Nothing
        '        Dim LsRow_2 As DataRow() = Nothing
        '        Dim LsRow_3 As DataRow() = Nothing
        '        Dim LsRow_4 As DataRow() = Nothing
        '        Dim SubTabla As System.Data.DataTable = Nothing
        '        SubTabla = New System.Data.DataTable
        '        LsRow = Tabla.Select("Placa=" & lRow.Placa & " And CodTipo=" & lRow.CodTipo, "Turno Asc,DesPersonal Asc")
        '        If LsRow.Count > 0 Then

        '            SubTabla = Tabla.Clone

        '            For Each dRow As DataRow In LsRow
        '                SubTabla.ImportRow(dRow)
        '            Next

        '            LsRow_1 = SubTabla.Select("Turno=" & 1, "DesPersonal ASC")
        '            LsRow_2 = SubTabla.Select("Turno=" & 2, "DesPersonal ASC")
        '            LsRow_3 = SubTabla.Select("Turno=" & 3, "DesPersonal ASC")
        '            LsRow_4 = SubTabla.Select("Turno=" & 4, "DesPersonal ASC")

        '            NroFilaxUnidad = LsRow_1.Count

        '            If NroFilaxUnidad < LsRow_2.Count Then NroFilaxUnidad = LsRow_2.Count

        '            If NroFilaxUnidad < LsRow_3.Count Then NroFilaxUnidad = LsRow_3.Count

        '            If NroFilaxUnidad < LsRow_4.Count Then NroFilaxUnidad = LsRow_4.Count

        '            If NroFilaxUnidad <> 0 Then

        '                xlSheet.Cells(nFil, 2).Value = lRow.Placa
        '                xlSheet.Cells(nFil, 2).NumberFormat = "000"
        '                xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).Merge()
        '                xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).HorizontalAlignment = xlCenter
        '                xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).VerticalAlignment = xlCenter

        '                xlSheet.Cells(nFil, 3).Value = lRow.Descripcion
        '                xlSheet.Range("C" & nFil & ":C" & nFil + NroFilaxUnidad - 1).Merge()
        '                xlSheet.Range("C" & nFil & ":C" & nFil + NroFilaxUnidad - 1).VerticalAlignment = xlCenter

        '                item = nFil - 1

        '                For Each vRow1 As DataRow In LsRow_1
        '                    item += 1
        '                    xlSheet.Cells(item, 4).Value = vRow1("CodPersonal")
        '                    xlSheet.Cells(item, 4).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 5).Value = vRow1("DesPersonal")
        '                Next

        '                item = nFil - 1

        '                For Each vRow2 As DataRow In LsRow_2
        '                    item += 1
        '                    xlSheet.Cells(item, 6).Value = vRow2("CodPersonal")
        '                    xlSheet.Cells(item, 6).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 7).Value = vRow2("DesPersonal")
        '                Next

        '                item = nFil - 1

        '                For Each vRow3 As DataRow In LsRow_3
        '                    item += 1
        '                    xlSheet.Cells(item, 8).Value = vRow3("CodPersonal")
        '                    xlSheet.Cells(item, 8).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 9).Value = vRow3("DesPersonal")
        '                Next

        '                item = nFil - 1

        '                For Each vRow4 As DataRow In LsRow_4
        '                    item += 1
        '                    xlSheet.Cells(item, 10).Value = vRow4("CodPersonal")
        '                    xlSheet.Cells(item, 10).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 11).Value = vRow4("DesPersonal")
        '                Next

        '                nFil = nFil + NroFilaxUnidad

        '            End If
        '        End If
        '        'Next

        '        With xlSheet.Range("B6:K" & nFil - 1)
        '            .Select()
        '            .Borders(xlDiagonalDown).LineStyle = xlNone
        '            .Borders(xlDiagonalUp).LineStyle = xlNone

        '            With .Borders(xlEdgeLeft)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlEdgeTop)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlEdgeBottom)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlEdgeRight)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlInsideVertical)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlInsideHorizontal)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '        End With

        '        With xlSheet.Range("B6:K7")
        '            With .Interior
        '                .Pattern = xlSolid
        '                .PatternColorIndex = xlAutomatic
        '                .ThemeColor = xlThemeColorAccent5
        '                .TintAndShade = -0.249977111117893
        '                .PatternTintAndShade = 0
        '            End With
        '            With .Font
        '                .ThemeColor = xlThemeColorDark1
        '                .TintAndShade = 0
        '            End With
        '        End With

        '        oExcel.ActiveWindow.Zoom = 73
        '        oExcel.Sheets(1).select()
        '    Next



        '    oExcel.Application.Visible = True

        'End Sub

        'Public Sub Generar_Cronograma_alex(ByVal Rpt As ETActivo)

        '    Dim oExcel As Excel.Application
        '    Dim oBook As Excel.Workbook = Nothing
        '    Dim xlSheet As Excel.Worksheet = Nothing
        '    Dim nFil As Integer = 0
        '    Dim item As Integer = 0


        '    oExcel = New Excel.Application
        '    oExcel.Caption = "CRONOGRAMA  " & Rpt.Semana.ToString & "-" & Rpt.Anho.ToString

        '    oExcel.Visible = False

        '    oBook = oExcel.Workbooks.Add()

        '    For I As Int16 = 7 To 1 Step -1

        '        xlSheet = oBook.Worksheets.Add()
        '        xlSheet.Name = ReNombrarHojaExcel(I)

        '        xlSheet.Range("A:A").Merge()
        '        xlSheet.Cells(1, 2).Value = "ROL DE TURNOS DE LA PLANTA DE PRODUCCION"
        '        xlSheet.Cells(1, 2).Font.size = 18
        '        xlSheet.Cells(1, 2).Font.Bold = True
        '        xlSheet.Range("B1:K1").Merge()
        '        xlSheet.Range("B1:K1").HorizontalAlignment = xlCenter


        '        xlSheet.Cells(2, 2).Value = "AÑO" & Space(10) & ":" & Space(2) & Rpt.Anho.ToString
        '        xlSheet.Cells(2, 2).Font.Size = 14
        '        xlSheet.Cells(2, 2).Font.Bold = True
        '        xlSheet.Range("B2:K2").Merge()
        '        xlSheet.Cells(3, 2).Value = "SEMANA" & Space(2) & ":" & Space(2) & Rpt.Semana.ToString


        '        xlSheet.Cells(3, 2).Font.Size = 14
        '        xlSheet.Cells(3, 2).Font.Bold = True
        '        xlSheet.Range("B3:K3").Merge()
        '        xlSheet.Range("B4:K4").Merge()
        '        xlSheet.Cells(4, 2).Value = "DIA" & Space(12) & ":" & Space(2) & FormatDateTime(Rpt.FechaInicio.AddDays(I - 1), DateFormat.LongDate).ToString
        '        xlSheet.Cells(4, 2).Font.Size = 14
        '        xlSheet.Cells(4, 2).Font.Bold = True
        '        xlSheet.Range("B5:K5").Merge()

        '        nFil = 6
        '        xlSheet.Range("A:A").ColumnWidth = 3

        '        xlSheet.Range("B:B").ColumnWidth = 9
        '        xlSheet.Range("B6:B7").Merge()
        '        xlSheet.Range("B6:B7").HorizontalAlignment = xlCenter
        '        xlSheet.Range("B6:B7").VerticalAlignment = xlCenter
        '        xlSheet.Cells(nFil, 2).Value = "PLACA"
        '        xlSheet.Cells(nFil, 2).Font.Bold = True

        '        xlSheet.Range("C:C").ColumnWidth = 25
        '        xlSheet.Range("C6:C7").Merge()
        '        xlSheet.Range("C6:C7").HorizontalAlignment = xlCenter
        '        xlSheet.Range("C6:C7").VerticalAlignment = xlCenter
        '        xlSheet.Cells(nFil, 3).Value = "UNIDAD"
        '        xlSheet.Cells(nFil, 3).Font.Bold = True

        '        xlSheet.Range("D6:E6").Merge()
        '        xlSheet.Range("D6:E6").HorizontalAlignment = xlCenter
        '        xlSheet.Cells(nFil, 4).Value = "TURNO 1"
        '        xlSheet.Cells(nFil, 4).Font.Bold = True

        '        xlSheet.Range("D:D").ColumnWidth = 9
        '        xlSheet.Cells(nFil + 1, 4).Value = "CODIGO"
        '        xlSheet.Cells(nFil + 1, 4).HorizontalAlignment = xlCenter
        '        xlSheet.Cells(nFil + 1, 4).Font.Bold = True

        '        xlSheet.Range("E:E").ColumnWidth = 41
        '        xlSheet.Cells(nFil + 1, 5).Value = "PERSONAL"
        '        xlSheet.Cells(nFil + 1, 5).Font.Bold = True

        '        xlSheet.Range("F6:G6").Merge()
        '        xlSheet.Range("F6:G6").HorizontalAlignment = xlCenter
        '        xlSheet.Cells(nFil, 6).Value = "TURNO 2"
        '        xlSheet.Cells(nFil, 6).Font.Bold = True

        '        xlSheet.Range("F:F").ColumnWidth = 9
        '        xlSheet.Cells(nFil + 1, 6).Value = "CODIGO"
        '        xlSheet.Cells(nFil + 1, 6).HorizontalAlignment = xlCenter
        '        xlSheet.Cells(nFil + 1, 6).Font.Bold = True

        '        xlSheet.Range("G:G").ColumnWidth = 41
        '        xlSheet.Cells(nFil + 1, 7).Value = "PERSONAL"
        '        xlSheet.Cells(nFil + 1, 7).Font.Bold = True

        '        xlSheet.Range("H6:I6").Merge()
        '        xlSheet.Range("H6:I6").HorizontalAlignment = xlCenter
        '        xlSheet.Cells(nFil, 8).Value = "TURNO 3"
        '        xlSheet.Cells(nFil, 8).Font.Bold = True

        '        xlSheet.Range("H:H").ColumnWidth = 9
        '        xlSheet.Cells(nFil + 1, 8).Value = "CODIGO"
        '        xlSheet.Cells(nFil + 1, 8).HorizontalAlignment = xlCenter
        '        xlSheet.Cells(nFil + 1, 8).Font.Bold = True

        '        xlSheet.Range("I:I").ColumnWidth = 41
        '        xlSheet.Cells(nFil + 1, 9).Value = "PERSONAL"
        '        xlSheet.Cells(nFil + 1, 9).Font.Bold = True

        '        xlSheet.Range("J6:K6").Merge()
        '        xlSheet.Range("J6:K6").HorizontalAlignment = xlCenter
        '        xlSheet.Cells(nFil, 10).Value = "HORARIO NORMAL"
        '        xlSheet.Cells(nFil, 10).Font.Bold = True

        '        xlSheet.Range("J:J").ColumnWidth = 9
        '        xlSheet.Cells(nFil + 1, 10).Value = "CODIGO"
        '        xlSheet.Cells(nFil + 1, 10).HorizontalAlignment = xlCenter
        '        xlSheet.Cells(nFil + 1, 10).Font.Bold = True

        '        xlSheet.Range("K:K").ColumnWidth = 41
        '        xlSheet.Cells(nFil + 1, 11).Value = "PERSONAL"
        '        xlSheet.Cells(nFil + 1, 11).Font.Bold = True

        '        nFil = 8

        '        Dim NroFilaxUnidad As Int16 = 0

        '        List_Reporte = New List(Of ETActivo)
        '        Entidad.Activo = New ETActivo
        '        Negocio.Activo = New NGActivo
        '        Entidad.MyLista = New ETMyLista

        '        Entidad.Activo.CodClase = Rpt.CodClase
        '        Entidad.Activo.Anho = Rpt.Anho.ToString
        '        Entidad.Activo.Semana = Rpt.Semana.ToString
        '        Entidad.Activo.Dia = I


        '        'Entidad.Activo.Fecha = DateAdd(DateInterval.Day, Entidad.Activo.Dia - 1, Rpt.FechaInicio)

        '        'Entidad.MyLista = Negocio.Activo.ConsultarCronograma(Entidad.Activo)

        '        If Entidad.MyLista.Validacion Then
        '            List_Reporte = Entidad.MyLista.Ls_Activo
        '        End If

        '        For Each W As ETActivo In List_Reporte

        '            List1 = New List(Of ETPersonal)
        '            List2 = New List(Of ETPersonal)
        '            List3 = New List(Of ETPersonal)
        '            List4 = New List(Of ETPersonal)

        '            If W.Turno1 Then
        '                Entidad.MyLista = New ETMyLista
        '                Entidad.Activo = New ETActivo
        '                Negocio.Activo = New NGActivo
        '                Entidad.Activo.CodClase = W.CodClase
        '                Entidad.Activo.CodTipo = W.CodTipo
        '                Entidad.Activo.Placa = W.Placa
        '                Entidad.Activo.Anho = Rpt.Anho.ToString
        '                Entidad.Activo.Semana = Rpt.Semana.ToString
        '                Entidad.Activo.Dia = I
        '                Entidad.Activo.Turno = 1
        '                Entidad.Activo.Fecha = W.Fecha

        '                Entidad.MyLista = Negocio.Activo.ConsultarCronograma(Entidad.Activo)
        '                If Entidad.MyLista.Validacion Then List1 = Entidad.MyLista.Ls_Personal

        '            End If

        '            If W.Turno2 Then
        '                Entidad.Activo = New ETActivo
        '                Entidad.MyLista = New ETMyLista
        '                Negocio.Activo = New NGActivo
        '                Entidad.Activo.CodClase = W.CodClase
        '                Entidad.Activo.CodTipo = W.CodTipo
        '                Entidad.Activo.Placa = W.Placa
        '                Entidad.Activo.Anho = Rpt.Anho.ToString
        '                Entidad.Activo.Semana = Rpt.Semana.ToString
        '                Entidad.Activo.Dia = I
        '                Entidad.Activo.Turno = 2
        '                Entidad.Activo.Fecha = W.Fecha

        '                Entidad.MyLista = Negocio.Activo.ConsultarCronograma(Entidad.Activo)
        '                If Entidad.MyLista.Validacion Then List2 = Entidad.MyLista.Ls_Personal

        '            End If

        '            If W.Turno3 Then
        '                Entidad.Activo = New ETActivo
        '                Entidad.MyLista = New ETMyLista
        '                Negocio.Activo = New NGActivo
        '                Entidad.Activo.CodClase = W.CodClase
        '                Entidad.Activo.CodTipo = W.CodTipo
        '                Entidad.Activo.Placa = W.Placa
        '                Entidad.Activo.Anho = Rpt.Anho.ToString
        '                Entidad.Activo.Semana = Rpt.Semana.ToString
        '                Entidad.Activo.Dia = I
        '                Entidad.Activo.Turno = 3
        '                Entidad.Activo.Fecha = W.Fecha

        '                Entidad.MyLista = Negocio.Activo.ConsultarCronograma(Entidad.Activo)
        '                If Entidad.MyLista.Validacion Then List3 = Entidad.MyLista.Ls_Personal

        '            End If

        '            If W.Turno4 Then
        '                Entidad.Activo = New ETActivo
        '                Entidad.MyLista = New ETMyLista
        '                Negocio.Activo = New NGActivo
        '                Entidad.Activo.CodClase = W.CodClase
        '                Entidad.Activo.CodTipo = W.CodTipo
        '                Entidad.Activo.Placa = W.Placa
        '                Entidad.Activo.Anho = Rpt.Anho.ToString
        '                Entidad.Activo.Semana = Rpt.Semana.ToString
        '                Entidad.Activo.Dia = I
        '                Entidad.Activo.Turno = 4
        '                Entidad.Activo.Fecha = W.Fecha

        '                Entidad.MyLista = Negocio.Activo.ConsultarCronograma(Entidad.Activo)
        '                If Entidad.MyLista.Validacion Then List4 = Entidad.MyLista.Ls_Personal

        '            End If

        '            NroFilaxUnidad = List1.Count

        '            If NroFilaxUnidad < List2.Count Then
        '                NroFilaxUnidad = List2.Count
        '            End If
        '            If NroFilaxUnidad < List3.Count Then
        '                NroFilaxUnidad = List3.Count
        '            End If
        '            If NroFilaxUnidad < List4.Count Then
        '                NroFilaxUnidad = List4.Count
        '            End If

        '            If NroFilaxUnidad <> 0 Then

        '                xlSheet.Cells(nFil, 2).Value = W.Placa
        '                xlSheet.Cells(nFil, 2).NumberFormat = "000"
        '                xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).Merge()
        '                xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).HorizontalAlignment = xlCenter
        '                xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).VerticalAlignment = xlCenter

        '                xlSheet.Cells(nFil, 3).Value = W.Descripcion
        '                xlSheet.Range("C" & nFil & ":C" & nFil + NroFilaxUnidad - 1).Merge()
        '                xlSheet.Range("C" & nFil & ":C" & nFil + NroFilaxUnidad - 1).VerticalAlignment = xlCenter

        '                item = nFil - 1

        '                For Each s As ETPersonal In List1
        '                    item += 1
        '                    xlSheet.Cells(item, 4).Value = s.CodPersonal
        '                    xlSheet.Cells(item, 4).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 5).Value = s.DesPersonal
        '                Next

        '                item = nFil - 1

        '                For Each s As ETPersonal In List2
        '                    item += 1
        '                    xlSheet.Cells(item, 6).Value = s.CodPersonal
        '                    xlSheet.Cells(item, 6).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 7).Value = s.DesPersonal
        '                Next

        '                item = nFil - 1

        '                For Each s As ETPersonal In List3
        '                    item += 1
        '                    xlSheet.Cells(item, 8).Value = s.CodPersonal
        '                    xlSheet.Cells(item, 8).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 9).Value = s.DesPersonal
        '                Next

        '                item = nFil - 1

        '                For Each s As ETPersonal In List4
        '                    item += 1
        '                    xlSheet.Cells(item, 10).Value = s.CodPersonal
        '                    xlSheet.Cells(item, 10).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 11).Value = s.DesPersonal
        '                Next

        '                nFil = nFil + NroFilaxUnidad

        '            End If

        '        Next

        '        With xlSheet.Range("B6:K" & nFil - 1)
        '            .Select()
        '            .Borders(xlDiagonalDown).LineStyle = xlNone
        '            .Borders(xlDiagonalUp).LineStyle = xlNone

        '            With .Borders(xlEdgeLeft)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlEdgeTop)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlEdgeBottom)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlEdgeRight)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlInsideVertical)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlInsideHorizontal)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '        End With

        '        With xlSheet.Range("B6:K7")
        '            With .Interior
        '                .Pattern = xlSolid
        '                .PatternColorIndex = xlAutomatic
        '                .ThemeColor = xlThemeColorAccent5
        '                .TintAndShade = -0.249977111117893
        '                .PatternTintAndShade = 0
        '            End With
        '            With .Font
        '                .ThemeColor = xlThemeColorDark1
        '                .TintAndShade = 0
        '            End With
        '        End With

        '        oExcel.ActiveWindow.Zoom = 73
        '        oExcel.Sheets(1).select()
        '    Next

        '    oExcel.Application.Visible = True

        'End Sub
        'Public Sub Generar_Cronograma_alex(ByVal Rpt As ETActivo)

        '    Dim oExcel As Excel.Application
        '    Dim oBook As Excel.Workbook = Nothing
        '    Dim xlSheet As Excel.Worksheet = Nothing
        '    Dim nFil As Integer = 0
        '    Dim item As Integer = 0


        '    oExcel = New Excel.Application
        '    oExcel.Caption = "CRONOGRAMA  " & Rpt.Semana.ToString & "-" & Rpt.Anho.ToString

        '    oExcel.Visible = False

        '    oBook = oExcel.Workbooks.Add()

        '    'For I As Int16 = 7 To 1 Step -1

        '    'xlSheet = oBook.Worksheets.Add()
        '    xlSheet.Name = ReNombrarHojaExcel(I)

        '    xlSheet.Range("A:A").Merge()
        '    xlSheet.Cells(1, 2).Value = "ROL DE TURNOS DE LA PLANTA DE PRODUCCION"
        '    xlSheet.Cells(1, 2).Font.size = 18
        '    xlSheet.Cells(1, 2).Font.Bold = True
        '    xlSheet.Range("B1:K1").Merge()
        '    xlSheet.Range("B1:K1").HorizontalAlignment = xlCenter


        '    xlSheet.Cells(2, 2).Value = "AÑO" & Space(10) & ":" & Space(2) & Rpt.Anho.ToString
        '    xlSheet.Cells(2, 2).Font.Size = 14
        '    xlSheet.Cells(2, 2).Font.Bold = True
        '    xlSheet.Range("B2:K2").Merge()
        '    xlSheet.Cells(3, 2).Value = "SEMANA" & Space(3) & ":" & Space(2) & Rpt.Semana.ToString


        '    xlSheet.Cells(3, 2).Font.Size = 14
        '    xlSheet.Cells(3, 2).Font.Bold = True
        '    xlSheet.Range("B3:K3").Merge()
        '    xlSheet.Range("B4:K4").Merge()
        '    xlSheet.Cells(4, 2).Value = "DIA" & Space(12) & ":" & Space(2) & FormatDateTime(Rpt.FechaInicio.AddDays(I - 1), DateFormat.LongDate).ToString
        '    xlSheet.Cells(4, 2).Font.Size = 14
        '    xlSheet.Cells(4, 2).Font.Bold = True
        '    xlSheet.Range("B5:K5").Merge()

        '    nFil = 6
        '    xlSheet.Range("A:A").ColumnWidth = 3

        '    xlSheet.Range("B:B").ColumnWidth = 9
        '    xlSheet.Range("B6:B7").Merge()
        '    xlSheet.Range("B6:B7").HorizontalAlignment = xlCenter
        '    xlSheet.Range("B6:B7").VerticalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 2).Value = "PLACA"
        '    xlSheet.Cells(nFil, 2).Font.Bold = True

        '    xlSheet.Range("C:C").ColumnWidth = 25
        '    xlSheet.Range("C6:C7").Merge()
        '    xlSheet.Range("C6:C7").HorizontalAlignment = xlCenter
        '    xlSheet.Range("C6:C7").VerticalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 3).Value = "UNIDAD"
        '    xlSheet.Cells(nFil, 3).Font.Bold = True

        '    xlSheet.Range("D6:E6").Merge()
        '    xlSheet.Range("D6:E6").HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 4).Value = "TURNO 1"
        '    xlSheet.Cells(nFil, 4).Font.Bold = True

        '    xlSheet.Range("D:D").ColumnWidth = 9
        '    xlSheet.Cells(nFil + 1, 4).Value = "CODIGO"
        '    xlSheet.Cells(nFil + 1, 4).HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil + 1, 4).Font.Bold = True

        '    xlSheet.Range("E:E").ColumnWidth = 41
        '    xlSheet.Cells(nFil + 1, 5).Value = "PERSONAL"
        '    xlSheet.Cells(nFil + 1, 5).Font.Bold = True

        '    xlSheet.Range("F6:G6").Merge()
        '    xlSheet.Range("F6:G6").HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 6).Value = "TURNO 2"
        '    xlSheet.Cells(nFil, 6).Font.Bold = True

        '    xlSheet.Range("F:F").ColumnWidth = 9
        '    xlSheet.Cells(nFil + 1, 6).Value = "CODIGO"
        '    xlSheet.Cells(nFil + 1, 6).HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil + 1, 6).Font.Bold = True

        '    xlSheet.Range("G:G").ColumnWidth = 41
        '    xlSheet.Cells(nFil + 1, 7).Value = "PERSONAL"
        '    xlSheet.Cells(nFil + 1, 7).Font.Bold = True

        '    xlSheet.Range("H6:I6").Merge()
        '    xlSheet.Range("H6:I6").HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 8).Value = "TURNO 3"
        '    xlSheet.Cells(nFil, 8).Font.Bold = True

        '    xlSheet.Range("H:H").ColumnWidth = 9
        '    xlSheet.Cells(nFil + 1, 8).Value = "CODIGO"
        '    xlSheet.Cells(nFil + 1, 8).HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil + 1, 8).Font.Bold = True

        '    xlSheet.Range("I:I").ColumnWidth = 41
        '    xlSheet.Cells(nFil + 1, 9).Value = "PERSONAL"
        '    xlSheet.Cells(nFil + 1, 9).Font.Bold = True

        '    xlSheet.Range("J6:K6").Merge()
        '    xlSheet.Range("J6:K6").HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil, 10).Value = "HORARIO NORMAL"
        '    xlSheet.Cells(nFil, 10).Font.Bold = True

        '    xlSheet.Range("J:J").ColumnWidth = 9
        '    xlSheet.Cells(nFil + 1, 10).Value = "CODIGO"
        '    xlSheet.Cells(nFil + 1, 10).HorizontalAlignment = xlCenter
        '    xlSheet.Cells(nFil + 1, 10).Font.Bold = True

        '    xlSheet.Range("K:K").ColumnWidth = 41
        '    xlSheet.Cells(nFil + 1, 11).Value = "PERSONAL"
        '    xlSheet.Cells(nFil + 1, 11).Font.Bold = True

        '    nFil = 8

        '    Dim NroFilaxUnidad As Int16 = 0

        '    List_Reporte = New List(Of ETActivo)
        '    Entidad.Activo = New ETActivo
        '    Negocio.Activo = New NGActivo
        '    Entidad.MyLista = New ETMyLista
        '    Tabla = New System.Data.DataTable

        '    Entidad.Activo.Anho = Rpt.Anho.ToString
        '    Entidad.Activo.Semana = Rpt.Semana.ToString
        '    Entidad.Activo.Dia = I

        '    Entidad.MyLista = Negocio.Activo.ConsultarCronograma6(Entidad.Activo)

        '    If Entidad.MyLista.Validacion Then
        '        List_Reporte = Entidad.MyLista.Ls_Activo
        '        Entidad.Activo = Negocio.Activo.Reporte_Cronograma(Entidad.Activo)
        '        If Entidad.Activo.Validacion Then
        '            Tabla = Entidad.Activo.Tabla.Copy
        '        End If
        '    End If

        '    For Each lRow In List_Reporte
        '        Dim LsRow As DataRow() = Nothing
        '        Dim LsRow_1 As DataRow() = Nothing
        '        Dim LsRow_2 As DataRow() = Nothing
        '        Dim LsRow_3 As DataRow() = Nothing
        '        Dim LsRow_4 As DataRow() = Nothing
        '        Dim SubTabla As System.Data.DataTable = Nothing
        '        SubTabla = New System.Data.DataTable
        '        LsRow = Tabla.Select("Placa=" & lRow.Placa & " And CodTipo=" & lRow.CodTipo, "Turno Asc,DesPersonal Asc")
        '        If LsRow.Count > 0 Then

        '            SubTabla = Tabla.Clone

        '            For Each dRow As DataRow In LsRow
        '                SubTabla.ImportRow(dRow)
        '            Next

        '            LsRow_1 = SubTabla.Select("Turno=" & 1, "DesPersonal ASC")
        '            LsRow_2 = SubTabla.Select("Turno=" & 2, "DesPersonal ASC")
        '            LsRow_3 = SubTabla.Select("Turno=" & 3, "DesPersonal ASC")
        '            LsRow_4 = SubTabla.Select("Turno=" & 4, "DesPersonal ASC")

        '            NroFilaxUnidad = LsRow_1.Count

        '            If NroFilaxUnidad < LsRow_2.Count Then NroFilaxUnidad = LsRow_2.Count

        '            If NroFilaxUnidad < LsRow_3.Count Then NroFilaxUnidad = LsRow_3.Count

        '            If NroFilaxUnidad < LsRow_4.Count Then NroFilaxUnidad = LsRow_4.Count

        '            If NroFilaxUnidad <> 0 Then

        '                xlSheet.Cells(nFil, 2).Value = lRow.Placa
        '                xlSheet.Cells(nFil, 2).NumberFormat = "000"
        '                xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).Merge()
        '                xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).HorizontalAlignment = xlCenter
        '                xlSheet.Range("B" & nFil & ":B" & nFil + NroFilaxUnidad - 1).VerticalAlignment = xlCenter

        '                xlSheet.Cells(nFil, 3).Value = lRow.Descripcion
        '                xlSheet.Range("C" & nFil & ":C" & nFil + NroFilaxUnidad - 1).Merge()
        '                xlSheet.Range("C" & nFil & ":C" & nFil + NroFilaxUnidad - 1).VerticalAlignment = xlCenter

        '                item = nFil - 1

        '                For Each vRow1 As DataRow In LsRow_1
        '                    item += 1
        '                    xlSheet.Cells(item, 4).Value = vRow1("CodPersonal")
        '                    xlSheet.Cells(item, 4).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 5).Value = vRow1("DesPersonal")
        '                Next

        '                item = nFil - 1

        '                For Each vRow2 As DataRow In LsRow_2
        '                    item += 1
        '                    xlSheet.Cells(item, 6).Value = vRow2("CodPersonal")
        '                    xlSheet.Cells(item, 6).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 7).Value = vRow2("DesPersonal")
        '                Next

        '                item = nFil - 1

        '                For Each vRow3 As DataRow In LsRow_3
        '                    item += 1
        '                    xlSheet.Cells(item, 8).Value = vRow3("CodPersonal")
        '                    xlSheet.Cells(item, 8).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 9).Value = vRow3("DesPersonal")
        '                Next

        '                item = nFil - 1

        '                For Each vRow4 As DataRow In LsRow_4
        '                    item += 1
        '                    xlSheet.Cells(item, 10).Value = vRow4("CodPersonal")
        '                    xlSheet.Cells(item, 10).HorizontalAlignment = xlCenter
        '                    xlSheet.Cells(item, 11).Value = vRow4("DesPersonal")
        '                Next

        '                nFil = nFil + NroFilaxUnidad

        '            End If
        '        End If
        '        'Next

        '        With xlSheet.Range("B6:K" & nFil - 1)
        '            .Select()
        '            .Borders(xlDiagonalDown).LineStyle = xlNone
        '            .Borders(xlDiagonalUp).LineStyle = xlNone

        '            With .Borders(xlEdgeLeft)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlEdgeTop)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlEdgeBottom)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlEdgeRight)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlInsideVertical)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '            With .Borders(xlInsideHorizontal)
        '                .LineStyle = xlContinuous
        '                .Weight = xlThin
        '                .ColorIndex = xlAutomatic
        '            End With
        '        End With

        '        With xlSheet.Range("B6:K7")
        '            With .Interior
        '                .Pattern = xlSolid
        '                .PatternColorIndex = xlAutomatic
        '                .ThemeColor = xlThemeColorAccent5
        '                .TintAndShade = -0.249977111117893
        '                .PatternTintAndShade = 0
        '            End With
        '            With .Font
        '                .ThemeColor = xlThemeColorDark1
        '                .TintAndShade = 0
        '            End With
        '        End With

        '        oExcel.ActiveWindow.Zoom = 73
        '        oExcel.Sheets(1).select()
        '    Next



        '    oExcel.Application.Visible = True

    End Sub

    Function ReNombrarHojaExcel(ByVal dia As Int16) As String

        ReNombrarHojaExcel = String.Empty
        Select Case dia
            Case 1
                ReNombrarHojaExcel = "Miercoles"
            Case 2
                ReNombrarHojaExcel = "Jueves"
            Case 3
                ReNombrarHojaExcel = "Viernes"
            Case 4
                ReNombrarHojaExcel = "Sabado"
            Case 5
                ReNombrarHojaExcel = "Domingo"
            Case 6
                ReNombrarHojaExcel = "Lunes"
            Case Else
                ReNombrarHojaExcel = "Martes"
        End Select

    End Function
    Private Sub EiminaReferencias(ByRef Referencias As Object)
        Try
            'Bucle de eliminacion
            Do Until _
                 System.Runtime.InteropServices.Marshal.ReleaseComObject(Referencias) <= 0
            Loop
        Catch
        Finally
            Referencias = Nothing
        End Try
    End Sub

End Class
