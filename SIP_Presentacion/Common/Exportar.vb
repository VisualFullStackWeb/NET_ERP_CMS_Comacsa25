Imports System.Runtime.CompilerServices
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Reflection

Namespace Common
    Public Class Exportar
        Private Shared missing As Object = Type.Missing
        Public Shared Sub ExportToExcel(ByVal tbl As DataTable, ByVal excelFilePath As String)
            Try
                If tbl Is Nothing OrElse tbl.Columns.Count = 0 Then Throw New Exception("ExportToExcel: Null or empty input table!" & vbLf)
                Dim excelApp = New Excel.Application()
                excelApp.Workbooks.Add()
                Dim workSheet As Excel._Worksheet = excelApp.ActiveSheet

                For i = 0 To tbl.Columns.Count - 1
                    workSheet.Cells(1, i + 1) = tbl.Columns(i).ColumnName
                Next

                For i = 0 To tbl.Rows.Count - 1

                    For j = 0 To tbl.Columns.Count - 1
                        workSheet.Cells(i + 2, j + 1) = tbl.Rows(i)(j)
                    Next
                Next

                If Not String.IsNullOrEmpty(excelFilePath) Then

                    Try
                        workSheet.SaveAs(excelFilePath)
                        excelApp.Quit()
                        MessageBox.Show("Excel file saved!")
                    Catch ex As Exception
                        Throw New Exception("ExportToExcel: Excel file could not be saved! Check filepath." & vbLf & ex.Message)
                    End Try
                Else
                    excelApp.Visible = True
                End If

            Catch ex As Exception
                Throw New Exception("ExportToExcel: " & vbLf & ex.Message)
            End Try
        End Sub

        Public Shared Sub ExportToExcelMultipleHojas(ByVal lista As List(Of DataTable), ByVal excelFilePath As String)


            Dim oXL As Excel.Application = New Excel.Application()
            oXL.Visible = False
            Dim oWB As Excel.Workbook = oXL.Workbooks.Add(missing)

            'recorrer 1ra hoja
            Dim oSheet As Excel.Worksheet = TryCast(oWB.ActiveSheet, Excel.Worksheet)
            oSheet.Name = "BD-1"
            'oSheet.Cells(1, 1) = "Something"

            Dim tbl As DataTable = lista.Item(0)
            For i = 0 To tbl.Columns.Count - 1
                oSheet.Cells(1, i + 1) = tbl.Columns(i).ColumnName
            Next

            For i = 0 To tbl.Rows.Count - 1
                For j = 0 To tbl.Columns.Count - 1
                    oSheet.Cells(i + 2, j + 1) = tbl.Rows(i)(j)
                Next
            Next

            oSheet.Columns.AutoFit()
            oSheet.Range("A1:K1").Font.Bold = True

            'recorrer 2da hoja
            tbl = New DataTable
            tbl = lista.Item(1)

            Dim oSheet2 As Excel.Worksheet = TryCast(oWB.Sheets.Add(missing, missing, 1, missing), Excel.Worksheet)
            oSheet2.Name = "BD-2"
            'oSheet2.Cells(1, 1) = "Something completely different"

            For i = 0 To tbl.Columns.Count - 1
                oSheet2.Cells(1, i + 1) = tbl.Columns(i).ColumnName
            Next

            For i = 0 To tbl.Rows.Count - 1
                For j = 0 To tbl.Columns.Count - 1
                    oSheet2.Cells(i + 2, j + 1) = tbl.Rows(i)(j)
                Next
            Next

            oSheet2.Columns.AutoFit()
            oSheet2.Range("A1:Q1").Font.Bold = True

            Dim fileName As String = excelFilePath 'Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) & "SoSample.xlsx"
            oWB.SaveAs(fileName, Excel.XlFileFormat.xlOpenXMLWorkbook, Nothing, Nothing, Nothing, Nothing, Excel.XlSaveAsAccessMode.xlNoChange, _
                Nothing, Nothing, Nothing, Nothing, Nothing)

            oWB.Close()
            oXL.UserControl = True
            oXL.Quit()
        End Sub

        Public Shared Sub ExportDatasetToExcelMultipleHojas(ByVal dataset As DataSet, ByVal excelFilePath As String, Optional ByVal rangoCabecera As String = "")


            Dim oXL As Excel.Application = New Excel.Application()
            oXL.Visible = False
            Dim oWB As Excel.Workbook = oXL.Workbooks.Add(missing)
            Dim hojaNuevo As Boolean = False

            For Each tabla As DataTable In dataset.Tables

                Dim oSheet As Excel.Worksheet

                'crear hojas
                If hojaNuevo = False Then
                    oSheet = TryCast(oWB.ActiveSheet, Excel.Worksheet)
                Else
                    oSheet = TryCast(oWB.Sheets.Add(missing, missing, 1, missing), Excel.Worksheet)
                End If

                oSheet.Name = tabla.TableName

                Dim tbl As DataTable = tabla
                For i = 0 To tbl.Columns.Count - 1
                    oSheet.Cells(1, i + 1) = tbl.Columns(i).ColumnName
                Next

                For i = 0 To tbl.Rows.Count - 1
                    For j = 0 To tbl.Columns.Count - 1
                        oSheet.Cells(i + 2, j + 1) = tbl.Rows(i)(j)
                    Next
                Next

                oSheet.Columns.AutoFit()

                If rangoCabecera.Trim.Length > 3 Then
                    oSheet.Range(rangoCabecera).Font.Bold = True
                End If
                'oSheet.Range(rangoCabecera).Cells.Font.Color = Color.Gainsboro
                hojaNuevo = True
            Next

            Dim fileName As String = excelFilePath
            oWB.SaveAs(fileName, Excel.XlFileFormat.xlOpenXMLWorkbook, Nothing, Nothing, Nothing, Nothing, Excel.XlSaveAsAccessMode.xlNoChange, _
                Nothing, Nothing, Nothing, Nothing, Nothing)

            oWB.Close()
            oXL.UserControl = True
            oXL.Quit()
        End Sub

        
        Public Shared Sub ExportExcel(ByVal dt As DataTable)

            Try

                'Dim strFile As String = MYFilelocation
                Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
                Dim wBook As Microsoft.Office.Interop.Excel.Workbook
                Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

                wBook = excel.Workbooks.Add()
                wSheet = wBook.ActiveSheet()

                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    excel.Cells(1, colIndex) = dc.ColumnName
                    excel.Range(excel.Cells(1, colIndex), excel.Cells(1, colIndex)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)
                    excel.Range(excel.Cells(1, colIndex), excel.Cells(1, colIndex)).Font.Bold = True
                    excel.Range(excel.Cells(1, colIndex), excel.Cells(1, colIndex)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                Next

                For Each dr In dt.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In dt.Columns
                        colIndex = colIndex + 1
                        excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next

                wSheet.Columns.AutoFit()
                'wBook.SaveAs(strFile)
                excel.Visible = True
                excel = Nothing
                'wBook.Close()

            Catch ex As Exception
                MessageBox.Show("there was an issue Exporting to Excel" & ex.ToString)
            End Try


        End Sub
    End Class
End Namespace