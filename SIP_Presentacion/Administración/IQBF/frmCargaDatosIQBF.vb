Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class frmCargaDatosIQBF
    Public Ls_Permisos As New List(Of Integer)
    Dim procesado As Int32
    Dim _objNegocio As NGInsumosFiscalizados
    Dim _objEntidad As ETInsumosFiscalizados
    Dim cierre As Int32 = 0
    Dim DtUsuario As DataTable = Nothing
    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If cmbMes.Value <= 0 Then
            MsgBox("Seleccione un mes a procesar", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If
        If Not Tab1.Tabs("T01").Selected Then Exit Sub
        'VerificaCierre()
        'If cierre = 1 Then
        '    MsgBox("El mes se encuentra cerrado", MsgBoxStyle.Information, "Comacsa")
        '    Exit Sub
        'End If
        If MsgBox("¿Seguro de procesar la información?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub
        proceso(0)
    End Sub
    Sub cancelar()
        Tab1.Tabs("T01").Selected = True
    End Sub
    Sub reporte()
        'If Grid1.Rows.Count <= 0 Then
        '    MsgBox("No existen datos para el reporte", MsgBoxStyle.Information, "Comacsa")
        '    Exit Sub
        'End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\TransaccionesIngresadas_" & cmbMes.Text & "_ERP.xls")
            File.Copy(RutaReporteERP & "PLANTILLA IQBF.xls", path & "\TransaccionesIngresadas_" & cmbMes.Text & "_ERP.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            'Dim objLibroExcel As Microsoft.Office.Interop.Excel.Workbook = m_Excel.Workbooks.Add
            'objLibroExcel.Password = "123"
            'objLibroExcel.Worksheets.Add()
            m_Excel.Workbooks.Open(path & "\TransaccionesIngresadas_" & cmbMes.Text & "_ERP.xls")
            'm_Excel.Workbooks.Open("C:\Users\sistemas\Desktop\Excel Registros IQPF\TransaccionesIngresadas_20140410173132", "C:\Users\sistemas\Desktop\TransaccionesIngresadas_20140410173132")
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcelEgreso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            Dim objHojaExcelProduccion As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            Dim objHojaExcelUso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
            Dim objHojaExcelGeneral As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(5)
            objHojaExcel.Name = "1|Ingreso"
            objHojaExcelEgreso.Name = "2|Egreso"
            objHojaExcelProduccion.Name = "3|Producción"
            objHojaExcelUso.Name = "4|Uso"
            objHojaExcelGeneral.Name = "5|General"
            exportarIngreso(objHojaExcel)
            exportarEgreso(objHojaExcelEgreso)
            exportarProduccion(objHojaExcelProduccion)
            exportarUso(objHojaExcelUso)
            'exportarGeneral(objHojaExcelGeneral)
            m_Excel.Visible = True
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault            
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub

    Sub exportarIngreso(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()

                .Range("A2:S2").Value = "REGISTRO DE OPERACIONES: INGRESO DE IQBF - " & Me.cmbMes.Text.ToString.Trim.ToUpper & " " & txtAño.Value

                Const primeraLetra As Char = "A"
                Dim primerNumero As Short = 4
                Dim Letra As Char, UltimaLetra As Char = ""
                Dim Numero As Integer, UltimoNumero As Integer = 0
                Dim cod_letra As Byte = Asc(primeraLetra) - 1
                Dim strColumna As String = ""
                Dim LetraIzq As String = ""
                Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1

                Letra = primeraLetra
                Numero = primerNumero
                Dim objCelda As Excel.Range

                For i As Int32 = 0 To Grid1.Rows.Count - 1
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For x As Int32 = 0 To 18
                        If Letra = "T" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra + Numero.ToString
                        'If Letra <> "E" And Letra <> "H" Then
                        '    .Range(strColumna).NumberFormat = "@"
                        'End If
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = Grid1.Rows(i).Cells(x).Value
                        .Range(strColumna).WrapText = True
                        '.Range(strColumna).Font.Size = 8
                        '.Range(strColumna).Font.Name = "Arial"

                        .Range(strColumna).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                    Next
                    .Range(.Cells(Numero, 1), .Cells(Numero, 19)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    Numero += 1
                Next

            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub exportarGeneral(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()

                .Range("A2:S2").Value = "REGISTRO DE OPERACIONES: GENERAL DE IQBF - " & Me.cmbMes.Text.ToString.Trim.ToUpper & " " & txtAño.Value

                Const primeraLetra As Char = "A"
                Dim primerNumero As Short = 4
                Dim Letra As Char, UltimaLetra As Char = ""
                Dim Numero As Integer, UltimoNumero As Integer = 0
                Dim cod_letra As Byte = Asc(primeraLetra) - 1
                Dim strColumna As String = ""
                Dim LetraIzq As String = ""
                Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1

                Letra = primeraLetra
                Numero = primerNumero
                Dim objCelda As Excel.Range

                For i As Int32 = 0 To Grid5.Rows.Count - 1
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For x As Int32 = 0 To 18
                        If Letra = "T" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra + Numero.ToString
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = Grid5.Rows(i).Cells(x).Value
                        .Range(strColumna).WrapText = True
                        .Range(strColumna).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                    Next
                    .Range(.Cells(Numero, 1), .Cells(Numero, 19)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    Numero += 1
                Next

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarEgreso(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            With objHojaExcel
                '.Range("A1").ColumnWidth = 6 : .Range("B1").ColumnWidth = 15.86
                '.Range("C1").ColumnWidth = 5.57 : .Range("D1").ColumnWidth = 17.14
                '.Range("E1").ColumnWidth = 5 : .Range("F1").ColumnWidth = 7.57
                '.Range("G1").ColumnWidth = 14 : .Range("H1").ColumnWidth = 8.29
                '.Range("I1").ColumnWidth = 4.86 : .Range("J1").ColumnWidth = 10
                '.Range("K1").ColumnWidth = 12.86 : .Range("L1").ColumnWidth = 8
                '.Range("M1").ColumnWidth = 4.29 : .Range("N1").ColumnWidth = 4.29
                '.Range("O1").ColumnWidth = 4.29 : .Range("P1").ColumnWidth = 4.29
                '.Range("Q1").ColumnWidth = 16.14 : .Range("R1").ColumnWidth = 5.86
                '.Range("A1:R1").Merge() : .Range("A1:R1").Value = "" : .Range("A1:R1").Font.Bold = True : .Range("A1:R1").Font.Size = 12

                '.Range("A3").Value = "Tipo de Operación"
                '.Range("B3").Value = "Establecimiento del que sale el bien"
                '.Range("C3").Value = "Tipo de transacción"
                '.Range("D3").Value = "Presentación del producto"
                '.Range("E3").Value = "Cantidad de presentaciones"
                '.Range("F3").Value = "Tipo de documento asociado a la transacción"
                '.Range("G3").Value = "Número de documento asociado a la transacción"
                '.Range("H3").Value = "Fecha de transacción"
                '.Range("I3").Value = "Tipo de Documento del adquiriente del bien"
                '.Range("J3").Value = "Numero de documento del adquiriente del bien"
                '.Range("K3").Value = "Nombre y apellidos o Razón Social si no se encuentra en el RBF"
                '.Range("L3").Value = "Número de RUC del transportista"
                '.Range("M3").Value = "Tipo de Guía de Remisión"
                '.Range("N3").Value = "Número de guía de remisión"
                '.Range("O3").Value = "Placa del vehículo"
                '.Range("P3").Value = "Número de licencia de conducir del conductor"
                '.Range("Q3").Value = "Observaciones"
                '.Range("R3").Value = "Código de incidencia"

                '.Range("A3:R3").RowHeight = 33
                '.Range("A3:R3").Interior.Color = 8189807
                '.Range("A3:R3").WrapText = True
                '.Range("A3:R3").Font.Bold = True
                '.Range("A3:R3").Font.Size = 8
                '.Range("A3:R3").Font.Name = "Arial"
                '.Range("A3:R3").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                '.Range(.Cells(3, 1), .Cells(3, 18)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                '.Range("A2:R2").Merge()
                '.Range("A2:R2").WrapText = True

                .Range("A2:R2").Value = "REGISTRO DE OPERACIONES: EGRESO DE IQBF - " & Me.cmbMes.Text.ToString.Trim.ToUpper & " " & txtAño.Value
                '.Range("A2:R2").Font.Bold = True
                '.Range("A2:R2").Font.Size = 12
                '.Range("A2:R2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                '.Range("A2:R2").Font.Name = "Arial"

                Const primeraLetra As Char = "A"
                Dim primerNumero As Short = 4
                Dim Letra As Char, UltimaLetra As Char = ""
                Dim Numero As Integer, UltimoNumero As Integer = 0
                Dim cod_letra As Byte = Asc(primeraLetra) - 1
                Dim strColumna As String = ""
                Dim LetraIzq As String = ""
                Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1

                Letra = primeraLetra
                Numero = primerNumero
                Dim objCelda As Excel.Range

                For i As Int32 = 0 To Grid2.Rows.Count - 1
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For x As Int32 = 0 To 19
                        If Letra = "W" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra + Numero.ToString
                        'If Letra <> "E" And Letra <> "H" Then
                        '    .Range(strColumna).NumberFormat = "@"
                        'End If
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = Grid2.Rows(i).Cells(x).Value
                        .Range(strColumna).WrapText = True
                        '.Range(strColumna).Font.Size = 8
                        '.Range(strColumna).Font.Name = "Arial"
                        .Range(strColumna).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    Next
                    .Range(.Cells(Numero, 1), .Cells(Numero, 23)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    Numero += 1
                Next

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarProduccion(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            With objHojaExcel
                '.Range("A1").ColumnWidth = 9.71 : .Range("B1").ColumnWidth = 19.86
                '.Range("C1").ColumnWidth = 28.71 : .Range("D1").ColumnWidth = 26.86
                '.Range("E1").ColumnWidth = 7.43 : .Range("F1").ColumnWidth = 8.29
                '.Range("G1").ColumnWidth = 7 : .Range("H1").ColumnWidth = 8.86
                '.Range("I1").ColumnWidth = 3.57 : .Range("J1").ColumnWidth = 21.86
                '.Range("K1").ColumnWidth = 8.29
                '.Range("A1:K1").Merge() : .Range("A1:K1").Value = "" : .Range("K1:K1").Font.Bold = True : .Range("K1:K1").Font.Size = 12

                '.Range("A3").Value = "Tipo de Operación"
                '.Range("B3").Value = "Establecimiento que usa el bien"
                '.Range("C3").Value = "Tipo de transacción"
                '.Range("D3").Value = "Presentación del producto"
                '.Range("E3").Value = "Cantidad de presentaciones"
                '.Range("F3").Value = "Tipo de documento asociado a la transacción"
                '.Range("G3").Value = "Número de documento asociado a la transacción"
                '.Range("H3").Value = "Fecha de transacción"
                '.Range("I3").Value = "Merma – expresa en kilogramos"
                '.Range("J3").Value = "Observaciones"
                '.Range("K3").Value = "Código de incidencia"

                '.Range("A3:K3").RowHeight = 56.25
                '.Range("A3:K3").Interior.Color = 11851260
                '.Range("A3:K3").WrapText = True
                '.Range("A3:K3").Font.Bold = True
                '.Range("A3:K3").Font.Size = 8
                '.Range("A3:K3").Font.Name = "Calibri"
                '.Range("A3:K3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                '.Range("A3:K3").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                '.Range(.Cells(3, 1), .Cells(3, 11)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                '.Range("A2:K2").Merge()
                '.Range("A2:K2").WrapText = True

                .Range("A2:K2").Value = "REGISTRO DE OPERACIONES: PRODUCCION DE IQBF - " & Me.cmbMes.Text.ToString.Trim.ToUpper & " " & txtAño.Value
                '.Range("A2:K2").Font.Bold = True
                '.Range("A2:K2").Font.Size = 12
                '.Range("A2:K2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                '.Range("A2:K2").Font.Name = "Arial"

                Const primeraLetra As Char = "A"
                Dim primerNumero As Short = 4
                Dim Letra As Char, UltimaLetra As Char = ""
                Dim Numero As Integer, UltimoNumero As Integer = 0
                Dim cod_letra As Byte = Asc(primeraLetra) - 1
                Dim strColumna As String = ""
                Dim LetraIzq As String = ""
                Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1

                Letra = primeraLetra
                Numero = primerNumero
                Dim objCelda As Excel.Range

                For i As Int32 = 0 To Grid3.Rows.Count - 1
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For x As Int32 = 0 To 10
                        If Letra = "T" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra + Numero.ToString
                        'If Letra <> "E" And Letra <> "H" Then
                        '    .Range(strColumna).NumberFormat = "@"
                        'End If
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = Grid3.Rows(i).Cells(x).Value
                        .Range(strColumna).WrapText = True
                        '.Range(strColumna).Font.Size = 8
                        '.Range(strColumna).Font.Name = "Arial"
                        .Range(strColumna).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    Next
                    .Range(.Cells(Numero, 1), .Cells(Numero, 11)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    Numero += 1
                Next

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarUso(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            With objHojaExcel

                .Range("A2:S2").Value = "REGISTRO DE OPERACIONES: USO DE IQBF - " & Me.cmbMes.Text.ToString.Trim.ToUpper & " " & txtAño.Value

                Const primeraLetra As Char = "A"
                Dim primerNumero As Short = 4
                Dim Letra As Char, UltimaLetra As Char = ""
                Dim Numero As Integer, UltimoNumero As Integer = 0
                Dim cod_letra As Byte = Asc(primeraLetra) - 1
                Dim strColumna As String = ""
                Dim LetraIzq As String = ""
                Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1

                Letra = primeraLetra
                Numero = primerNumero
                Dim objCelda As Excel.Range

                For i As Int32 = 0 To Grid4.Rows.Count - 1
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For x As Int32 = 0 To 18
                        If Letra = "T" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra + Numero.ToString
                        'If Letra <> "E" And Letra <> "H" Then
                        '    .Range(strColumna).NumberFormat = "@"
                        'End If
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = IIf(x = 15, "", Grid4.Rows(i).Cells(x).Value)
                        .Range(strColumna).WrapText = True
                        '.Range(strColumna).Font.Size = 8
                        '.Range(strColumna).Font.Name = "Arial"
                        .Range(strColumna).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    Next
                    .Range(.Cells(Numero, 1), .Cells(Numero, 19)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    Numero += 1
                Next

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        If cmbMes.Value <= 0 Then
            MsgBox("Seleccione un mes a importar", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If
        If Not Tab1.Tabs("T01").Selected Then Exit Sub
        VerificaCierre()
        If cierre = 1 Then
            MsgBox("El mes se encuentra cerrado", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Try
            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName
            Cursor = Cursors.WaitCursor
            lblmensaje.Visible = True
            lblmensaje.Text = "Validando datos de libro Excel..."
            lblmensaje.Refresh()
            If Not ValidarExcel(cadenaExcel) Then
                MsgBox("El archivo seleccionado es incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                Cursor = Cursors.Default
                lblmensaje.Visible = False
                lblmensaje.Refresh()
                Return
            End If
            'MsgBox("ENTRANDO A CONEXION OLEDB")
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                          "Data Source= " & cadenaExcel & _
                          ";Extended Properties=""Excel 8.0;HDR=YES"""
            Dim oConn As New OleDbConnection(cs)

            Try
                oConn.Open()
                cargarDatosLaboratorio(oConn, "HNO3 60-70%", 1)
                cargarDatosLaboratorio(oConn, "HCl 36.5-38%", 1)
                cargarDatosLaboratorio(oConn, "H2SO4 95-98%", 1)
                cargarDatosLaboratorio(oConn, "NH4OH 28-30% 2.25Kg", 1)
                cargarDatosLaboratorio(oConn, "NH4OH 28-30% 2.3Kg", 1)
                cargarDatosLaboratorio(oConn, "KMnO4 mín 99% 0.5kg", 2)
                cargarDatosLaboratorio(oConn, "KMnO4 mín 99% 1Kg", 2)
                cargarDatosLaboratorio(oConn, "Na2CO3", 2)
                cargarDatosLaboratorio(oConn, "HCl 33% Rovic bidón", 2)

                MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ocurrió un error")
                'MsgBox("Archivo incorrecto a ya se encuentra utilizado", MsgBoxStyle.Critical, "Comacsa")
            Finally
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Cursor = Cursors.Default
                lblmensaje.Visible = False
                lblmensaje.Refresh()
                oConn.Close()
                oConn.Dispose()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub cargarDatosLaboratorio(ByVal oConn As OleDbConnection, ByVal hoja As String, ByVal formato As Integer)
        Dim Ls_datos = New List(Of ETProveedorFiscalizado)
        Dim DtSet As New System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        MyCommand = New System.Data.OleDb.OleDbDataAdapter _
        ("select * from [" & hoja & "$]", oConn)
        MyCommand.TableMappings.Add("Table", "TablaSustento")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        lblmensaje.Text = "Cargando datos de libro Excel..."
        lblmensaje.Refresh()
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        'MsgBox(DtSet.Tables(0).Columns(1).ColumnName)
        For i As Int32 = 4 To DtSet.Tables(0).Rows.Count - 1
            If DtSet.Tables(0).Rows(i)(4).ToString = "" Then DtSet.Tables(0).Rows(i)(4) = "01/01/1990"

            If Month(DtSet.Tables(0).Rows(i)(4).ToString) = cmbMes.Value And Year(DtSet.Tables(0).Rows(i)(4).ToString) = txtAño.Value Then 'Year(Now.Date) Then
                oPrvFisN = New NGProveedorFiscalizado
                oPrvFisE = New ETProveedorFiscalizado
                With oPrvFisE
                    .Cod_Cia = Companhia
                    .Cod_Prod = DtSet.Tables(0).Rows(0)(1).ToString.Trim
                    '.Cod_Prod = DtSet.Tables(0).Columns(1).ColumnName.Trim
                    .Fecha = DtSet.Tables(0).Rows(i)(4)
                    .Cod_Sunat = ""

                    If hoja = "NH4OH 28-30% 2.25Kg" Then
                        .Cod_Sunat = "17"
                    End If

                    If hoja = "NH4OH 28-30% 2.3Kg" Then
                        .Cod_Sunat = "5"
                    End If


                    If hoja = "KMnO4 mín 99% 0.5kg" Then
                        .Cod_Sunat = "21"
                    End If

                    If hoja = "KMnO4 mín 99% 1Kg" Then
                        .Cod_Sunat = "10"
                    End If

                    If formato = 1 Then
                        .Cantidad = DtSet.Tables(0).Rows(i)(6)
                        .Unidad = "KG"
                        .Observacion = DtSet.Tables(0).Rows(i)(7).ToString
                        .Saldo = DtSet.Tables(0).Rows(i)(10)
                    Else
                        .Cantidad = DtSet.Tables(0).Rows(i)(5)
                        .Unidad = "KG"
                        .Observacion = DtSet.Tables(0).Rows(i)(6).ToString
                        .Saldo = DtSet.Tables(0).Rows(i)(8)
                    End If
                    .User_Crea = User_Sistema
                    '.mes = cmbMes.Value
                End With
                Ls_datos.Add(oPrvFisE)
            End If

        Next
        If Not oPrvFisE Is Nothing Then
            oPrvFisN.DatosUsoLaboratorio(oPrvFisE, Ls_datos)
        End If
    End Sub

    Function ValidarExcel(ByVal RUTA As String) As Boolean
        Cursor = Cursors.WaitCursor
        lblmensaje.Visible = True
        lblmensaje.Text = "Validando datos de libro Excel..."
        lblmensaje.Refresh()
        Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
        Dim ObjW As Microsoft.Office.Interop.Excel.Workbook
        ObjExcel = New Microsoft.Office.Interop.Excel.Application
        ObjW = ObjExcel.Workbooks.Open(RUTA)
        Try
            If Not ObjW.Sheets(1).Name.ToString.Trim = "HNO3 60-70%" Then
                Return False
            End If
            If Not ObjW.Sheets(2).Name.ToString.Trim = "HCl 36.5-38%" Then
                Return False
            End If
            If Not ObjW.Sheets(3).Name.ToString.Trim = "H2SO4 95-98%" Then
                Return False
            End If
            If Not ObjW.Sheets(4).Name.ToString.Trim = "NH4OH 28-30% 2.25Kg" Then
                Return False
            End If
            If Not ObjW.Sheets(5).Name.ToString.Trim = "NH4OH 28-30% 2.3Kg" Then
                Return False
            End If
            If Not ObjW.Sheets(6).Name.ToString.Trim = "KMnO4 mín 99% 0.5kg" Then
                Return False
            End If
            If Not ObjW.Sheets(7).Name.ToString.Trim = "KMnO4 mín 99% 1Kg" Then
                Return False
            End If

            If Not ObjW.Sheets(8).Name.ToString.Trim = "Na2CO3" Then
                Return False
            End If
            If Not ObjW.Sheets(9).Name.ToString.Trim = "HCl 33% Rovic bidón" Then
                Return False
            End If
            If Not ObjW.Sheets(10).Name.ToString.Trim = "HCl 33% Rovic granel" Then
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ObjW.Close()
            ObjW = Nothing
            ObjExcel.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(ObjExcel)
            ObjExcel = Nothing
        End Try
    End Function

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If cmbMes.Value <= 0 Then
            MsgBox("Seleccione un mes a generar", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName.Trim = "" Then Exit Sub
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Cursor = Cursors.WaitCursor
        lblmensaje.Visible = True
        lblmensaje.Text = "Generando archivo txt..."
        lblmensaje.Refresh()
        Dim ruta As String
        If SaveFileDialog1.FileName.Substring(SaveFileDialog1.FileName.Length - 4, 1) = "." Then
            ruta = SaveFileDialog1.FileName
        Else
            ruta = SaveFileDialog1.FileName & ".txt"
        End If
        Dim fs As FileStream = File.Create(ruta)
        fs.Close()
        Dim sw As New System.IO.StreamWriter(ruta)
        Try
            generarTxtIngreso(sw)
            generarTxtEgreso(sw)
            generarTxtProduccion(sw)
            generarTxtUso(sw)
            generarTxtGeneral(sw)
            MsgBox("Archivo txt generado en la ruta: " & ruta, MsgBoxStyle.Information, "Comacsa")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            sw.Close()
            Cursor = Cursors.Default
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub
    Sub generarTxtIngreso(ByVal sw As System.IO.StreamWriter)
        If Grid1.Rows.Count > 0 Then
            For i As Int32 = 0 To Grid1.Rows.Count - 1
                'Código del  Tipo de Operación
                sw.Write(Grid1.Rows(i).Cells(0).Value.ToString.Substring(0, 1).Trim)
                sw.Write("|")
                'Código de establecimiento al que ingresa el bien.
                sw.Write(Grid1.Rows(i).Cells(1).Value.ToString.Substring(0, 4).Trim)
                sw.Write("|")
                'Código de Tipo de transacción
                sw.Write(Grid1.Rows(i).Cells(2).Value.ToString.Substring(0, 3).Trim)
                sw.Write("|")
                'Código de presentación del producto.
                If Grid1.Rows(i).Cells(3).Value.ToString.Substring(0, 2).Trim = "00" Then
                    sw.Write(Grid1.Rows(i).Cells(3).Value.ToString.Substring(0, 6).Trim)
                Else
                    sw.Write(Grid1.Rows(i).Cells(3).Value.ToString.Substring(0, 2).Trim)
                End If
                sw.Write("|")
                'Cantidad de  presentaciones
                sw.Write(Grid1.Rows(i).Cells(4).Value.ToString.Trim)
                sw.Write("|")
                'Tipo de documento asociado a la transacción
                If Grid1.Rows(i).Cells(5).Value.ToString.Substring(0, 1).Trim = "1" Then
                    sw.Write("01")
                Else
                    sw.Write(Grid1.Rows(i).Cells(5).Value.ToString.Substring(0, 2).Trim)
                End If
                sw.Write("|")
                'Número de documento asociado a la transacción
                sw.Write(Grid1.Rows(i).Cells(6).Value.ToString.Trim)
                sw.Write("|")
                'Fecha de transacción
                sw.Write(Convert.ToDateTime(Grid1.Rows(i).Cells(7).Value).ToString("dd/MM/yyyy"))
                sw.Write("|")
                'Tipo de Documento del destinatario
                sw.Write(Grid1.Rows(i).Cells(8).Value.ToString.Trim)
                sw.Write("|")
                'Documento del destinatario
                sw.Write(Grid1.Rows(i).Cells(9).Value.ToString.Trim)
                sw.Write("|")
                'Tipo de Documento del que Transfiere
                sw.Write(Grid1.Rows(i).Cells(10).Value.ToString.Substring(0, 1).Trim)
                sw.Write("|")
                'Numero de documento del que transfiere
                sw.Write(Grid1.Rows(i).Cells(11).Value.ToString.Trim)
                sw.Write("|")
                'Numero de RUC del transportista
                sw.Write(Grid1.Rows(i).Cells(12).Value.ToString.Trim)
                sw.Write("|")
                'Tipo de Guía de Remisión
                If Not Grid1.Rows(i).Cells(13).Value.ToString.Trim = "" Then
                    sw.Write(Grid1.Rows(i).Cells(13).Value.ToString.Substring(0, 2).Trim)
                Else
                    sw.Write(Grid1.Rows(i).Cells(13).Value.ToString)
                End If
                sw.Write("|")
                'Número de guía de remisión
                sw.Write(Grid1.Rows(i).Cells(14).Value.ToString.Trim)
                sw.Write("|")
                'Placa del vehículo
                sw.Write(Grid1.Rows(i).Cells(15).Value.ToString.Trim)
                sw.Write("|")
                'Numero de licencia de conducir del conductor
                sw.Write(Grid1.Rows(i).Cells(16).Value.ToString.Trim)
                sw.Write("|")
                'Observaciones
                sw.Write(Grid1.Rows(i).Cells(17).Value.ToString.Trim)
                sw.Write("|")
                'Código de  incidencia
                sw.Write(Grid1.Rows(i).Cells(18).Value.ToString.Trim)
                sw.WriteLine("|")
            Next
        End If
    End Sub
    Sub generarTxtGeneral(ByVal sw As System.IO.StreamWriter)
        If Grid5.Rows.Count > 0 Then
            For i As Int32 = 0 To Grid5.Rows.Count - 1
                'Código del  Tipo de Operación
                sw.Write(Grid5.Rows(i).Cells(0).Value.ToString.Substring(0, 1).Trim)
                sw.Write("|")
                'Código de establecimiento al que ingresa el bien.
                sw.Write(Grid5.Rows(i).Cells(1).Value.ToString.Substring(0, 4).Trim)
                sw.Write("|")
                'Código de Tipo de transacción
                sw.Write(Grid5.Rows(i).Cells(2).Value.ToString.Substring(0, 3).Trim)
                sw.Write("|")
                'Código de presentación del producto.
                If Grid5.Rows(i).Cells(3).Value.ToString.Substring(0, 2).Trim = "00" Then
                    sw.Write(Grid5.Rows(i).Cells(3).Value.ToString.Substring(0, 6).Trim)
                Else
                    sw.Write(Grid5.Rows(i).Cells(3).Value.ToString.Substring(0, 2).Trim)
                End If
                sw.Write("|")
                'Cantidad de  presentaciones
                sw.Write(Grid5.Rows(i).Cells(4).Value.ToString.Trim)
                sw.Write("|")
                'Tipo de documento asociado a la transacción
                sw.Write("99")
                sw.Write("|")
                'Número de documento asociado a la transacción
                sw.Write(Convert.ToDateTime(Grid5.Rows(i).Cells(7).Value).ToString("ddMMyyyy"))
                sw.Write("|")
                'Fecha de transacción
                sw.Write(Convert.ToDateTime(Grid5.Rows(i).Cells(7).Value).ToString("dd/MM/yyyy"))
                sw.Write("|")
                'Observaciones
                sw.Write(Grid5.Rows(i).Cells(17).Value.ToString.Trim)
                sw.Write("|")
                'Código de  incidencia
                sw.Write(Grid5.Rows(i).Cells(18).Value.ToString.Trim)
                sw.WriteLine("|")
            Next
        End If
    End Sub
    Sub generarTxtEgreso(ByVal sw As System.IO.StreamWriter)
        If Grid2.Rows.Count > 0 Then
            For i As Int32 = 0 To Grid2.Rows.Count - 1
                'Código del  Tipo de Operación
                sw.Write(Grid2.Rows(i).Cells(0).Value.ToString.Substring(0, 1).Trim)
                sw.Write("|")
                'Código de establecimiento al que ingresa el bien.
                sw.Write(Grid2.Rows(i).Cells(1).Value.ToString.Substring(0, 4).Trim)
                sw.Write("|")
                'Código de Tipo de transacción
                sw.Write(Grid2.Rows(i).Cells(2).Value.ToString.Substring(0, 3).Trim)
                sw.Write("|")
                'Código de presentación del producto.
                If Grid2.Rows(i).Cells(3).Value.ToString.Substring(0, 2).Trim = "00" Then
                    sw.Write(Grid2.Rows(i).Cells(3).Value.ToString.Substring(0, 6).Trim)
                Else
                    sw.Write(Grid2.Rows(i).Cells(3).Value.ToString.Substring(0, 2).Trim)
                End If
                sw.Write("|")
                'Cantidad de  presentaciones
                sw.Write(Grid2.Rows(i).Cells(4).Value.ToString.Trim)
                sw.Write("|")
                'Tipo de documento asociado a la transacción
                If Grid2.Rows(i).Cells(6).Value.ToString.Substring(0, 1).Trim = "1" Then
                    sw.Write("01")
                Else
                    sw.Write(Grid2.Rows(i).Cells(6).Value.ToString.Substring(0, 2).Trim)
                End If
                sw.Write("|")
                'Número de documento asociado a la transacción  FACTURA
                sw.Write(Grid2.Rows(i).Cells(7).Value.ToString.Trim)
                sw.Write("|")
                'Fecha de transacción  FACTURA
                sw.Write(Convert.ToDateTime(Grid2.Rows(i).Cells(5).Value).ToString("dd/MM/yyyy"))
                sw.Write("|")
                'Tipo de Documento del adquiriente del bien.
                If Grid2.Rows(i).Cells(11).Value.ToString.Substring(0, 1).Trim = "9" Then
                    sw.Write(Grid2.Rows(i).Cells(11).Value.ToString.Substring(0, 2).Trim)
                Else
                    sw.Write(Grid2.Rows(i).Cells(11).Value.ToString.Substring(0, 1).Trim)
                End If
                sw.Write("|")
                'Numero de documento del adquiriente del bien
                sw.Write(Grid2.Rows(i).Cells(12).Value.ToString.Trim)
                sw.Write("|")
                'Nombre y apellidos o Razón Social si no se encuentra en el RBF
                sw.Write(Grid2.Rows(i).Cells(13).Value.ToString.Trim.Replace("Ñ", "N"))
                sw.Write("|")
                'Numero de RUC del transportista
                sw.Write(Grid2.Rows(i).Cells(16).Value.ToString.Trim)
                sw.Write("|")
                'Tipo de Guía de Remisión
                'sw.Write(Grid2.Rows(i).Cells(12).Value.ToString.Trim) '.Substring(0, 2))
                If Grid2.Rows(i).Cells(17).Value.ToString.Trim = "" Then
                    sw.Write(Grid2.Rows(i).Cells(17).Value.ToString)
                Else
                    sw.Write(Grid2.Rows(i).Cells(17).Value.ToString.Substring(0, 2).Trim)
                End If
                sw.Write("|")
                'Número de guía de remisión
                sw.Write(Grid2.Rows(i).Cells(18).Value.ToString.Trim)
                sw.Write("|")
                'Placa del vehículo
                sw.Write(Grid2.Rows(i).Cells(19).Value.ToString.Trim)
                sw.Write("|")
                'Numero de licencia de conducir del conductor
                sw.Write(Grid2.Rows(i).Cells(20).Value.ToString.Trim)
                sw.Write("|")
                'Observaciones
                sw.Write(Grid2.Rows(i).Cells(21).Value.ToString.Trim)
                sw.Write("|")
                'Código de  incidencia.
                sw.Write(Grid2.Rows(i).Cells(22).Value.ToString.Trim)
                sw.WriteLine("|")
            Next
        End If
    End Sub

    Sub generarTxtProduccion(ByVal sw As System.IO.StreamWriter)
        If Grid3.Rows.Count > 0 Then
            For i As Int32 = 0 To Grid3.Rows.Count - 1
                'Código del  Tipo de Operación
                sw.Write(Grid3.Rows(i).Cells(0).Value.ToString.Substring(0, 1).Trim)
                sw.Write("|")
                'Código de establecimiento al que ingresa el bien.
                sw.Write(Grid3.Rows(i).Cells(1).Value.ToString.Substring(0, 4).Trim)
                sw.Write("|")
                'Código de Tipo de transacción
                sw.Write(Grid3.Rows(i).Cells(2).Value.ToString.Substring(0, 3).Trim)
                sw.Write("|")
                'Código de presentación del producto.
                If Grid3.Rows(i).Cells(3).Value.ToString.Substring(0, 2).Trim = "00" Then
                    sw.Write(Grid3.Rows(i).Cells(3).Value.ToString.Substring(0, 6).Trim)
                Else
                    sw.Write(Grid3.Rows(i).Cells(3).Value.ToString.Substring(0, 2).Trim)
                End If
                sw.Write("|")
                'Cantidad de  presentaciones
                sw.Write(Grid3.Rows(i).Cells(4).Value.ToString.Trim)
                sw.Write("|")
                'Tipo de documento asociado a la transacción
                sw.Write(Grid3.Rows(i).Cells(5).Value.ToString.Substring(0, 2).Trim)
                sw.Write("|")
                'Número de documento asociado a la transacción
                sw.Write(Grid3.Rows(i).Cells(6).Value.ToString.Trim)
                sw.Write("|")
                'Fecha de transacción
                sw.Write(Convert.ToDateTime(Grid3.Rows(i).Cells(7).Value).ToString("dd/MM/yyyy"))
                sw.Write("|")
                'Merma – expresa en la unidad de control
                sw.Write(Grid3.Rows(i).Cells(8).Value.ToString.Trim)
                sw.Write("|")
                'Observaciones
                sw.Write(Grid3.Rows(i).Cells(9).Value.ToString.Trim)
                sw.Write("|")
                'Código de  incidencia
                sw.Write(Grid3.Rows(i).Cells(10).Value.ToString.Trim)
                sw.WriteLine("|")
            Next
        End If
    End Sub

    Sub generarTxtUso(ByVal sw As System.IO.StreamWriter)
        If Grid4.Rows.Count > 0 Then
            For i As Int32 = 0 To Grid4.Rows.Count - 1
                'Código del  Tipo de Operación
                sw.Write(Grid4.Rows(i).Cells(0).Value.ToString.Substring(0, 1).Trim)
                sw.Write("|")
                'Código de establecimiento al que ingresa el bien.
                sw.Write(Grid4.Rows(i).Cells(1).Value.ToString.Substring(0, 4).Trim)
                sw.Write("|")
                'Código de Tipo de transacción
                sw.Write(Grid4.Rows(i).Cells(2).Value.ToString.Substring(0, 3).Trim)
                sw.Write("|")
                'Código de presentación del producto.
                If Grid4.Rows(i).Cells(3).Value.ToString.Substring(0, 2).Trim = "00" Then
                    sw.Write(Grid4.Rows(i).Cells(3).Value.ToString.Substring(0, 6).Trim)
                Else
                    sw.Write(Grid4.Rows(i).Cells(3).Value.ToString.Substring(0, 2).Trim)
                End If
                sw.Write("|")
                'Cantidad de  presentaciones
                sw.Write(Grid4.Rows(i).Cells(4).Value.ToString.Trim)
                sw.Write("|")
                'Tipo de documento asociado a la transacción
                sw.Write(Grid4.Rows(i).Cells(5).Value.ToString.Substring(0, 2).Trim)
                sw.Write("|")
                'Número de documento asociado a la transacción
                sw.Write(Grid4.Rows(i).Cells(6).Value.ToString.Trim)
                sw.Write("|")
                'Fecha de transacción
                sw.Write(Convert.ToDateTime(Grid4.Rows(i).Cells(7).Value).ToString("dd/MM/yyyy"))
                sw.Write("|")
                'Tipo de Documento del relacionado del bien
                sw.Write(Grid4.Rows(i).Cells(8).Value.ToString.Substring(0, 1).Trim)
                sw.Write("|")
                'Numero de documento del relacionado del bien
                sw.Write(Grid4.Rows(i).Cells(9).Value.ToString.Trim)
                sw.Write("|")
                'Nombre y apellidos o Razón Social si no se encuentra en el RBF
                sw.Write(Grid4.Rows(i).Cells(10).Value.ToString.Trim)
                sw.Write("|")
                'Merma – expresa en la unidad de control
                sw.Write(Grid4.Rows(i).Cells(11).Value.ToString.Trim)
                sw.Write("|")

                'Código del producto no fiscalizado inscrito en el registro
                sw.Write(Grid4.Rows(i).Cells(19).Value.ToString.Trim)
                sw.Write("|")
                'Cantidad Estimada del producto no fiscalizado expresada en la unidad de medida inscrito en el cuadro insumo producto inscrito del registro.
                sw.Write(IIf(Grid4.Rows(i).Cells(21).Value = 0, "", Grid4.Rows(i).Cells(21).Value))
                sw.Write("|")

                'Numero de RUC del transportista
                sw.Write(Grid4.Rows(i).Cells(12).Value.ToString.Trim)
                sw.Write("|")
                'Tipo de Guía de Remisión
                sw.Write(Grid4.Rows(i).Cells(13).Value.ToString.Trim) '.Substring(0, 2).Trim)
                sw.Write("|")
                'Número de guía de remisión
                sw.Write(Grid4.Rows(i).Cells(14).Value.ToString.Trim)
                sw.Write("|")
                'Placa del vehículo
                sw.Write("") '(Grid4.Rows(i).Cells(15).Value.ToString.Trim)
                sw.Write("|")
                'Numero de licencia de conducir del conductor
                sw.Write("") '(Grid4.Rows(i).Cells(16).Value.ToString.Trim)
                sw.Write("|")
                'Observaciones
                sw.Write(Grid4.Rows(i).Cells(17).Value.ToString.Trim)
                sw.Write("|")
                'Código de  incidencia
                sw.Write(Grid4.Rows(i).Cells(18).Value.ToString.Trim)
                sw.WriteLine("|")
            Next
        End If
    End Sub

    Private Sub Grid1_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow, Grid2.DoubleClickRow, Grid3.DoubleClickRow, Grid4.DoubleClickRow
        Try
            'Dim frm As New frmIngresarObservacionIQBF
            'If sender Is Grid1 Then
            '    frm.Txtobservacion.Text = Grid1.ActiveRow.Cells("observacion").Value.ToString
            'End If
            'If sender Is Grid2 Then
            '    frm.Txtobservacion.Text = Grid2.ActiveRow.Cells("observacion").Value.ToString
            'End If
            'If sender Is Grid3 Then
            '    frm.Txtobservacion.Text = Grid3.ActiveRow.Cells("observacion").Value.ToString
            'End If
            'If sender Is Grid4 Then
            '    frm.Txtobservacion.Text = Grid4.ActiveRow.Cells("observacion").Value.ToString
            'End If
            'frm.Txtobservacion.Focus()
            'frm.ShowDialog()
            'If frm.guardado = False Then Exit Sub
            'If sender Is Grid1 Then
            '    Grid1.ActiveRow.Cells("observacion").Value = frm.Txtobservacion.Text.ToString.Trim
            'End If
            'If sender Is Grid2 Then
            '    Grid2.ActiveRow.Cells("observacion").Value = frm.Txtobservacion.Text.ToString.Trim
            'End If
            'If sender Is Grid3 Then
            '    Grid3.ActiveRow.Cells("observacion").Value = frm.Txtobservacion.Text.ToString.Trim
            'End If
            'If sender Is Grid4 Then
            '    Grid4.ActiveRow.Cells("observacion").Value = frm.Txtobservacion.Text.ToString.Trim
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            btnGenerar.Enabled = False
            btningresobarbotina.Enabled = False
            VerificaCierre()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\SALDOS PRESENTACIONES.xls")
            File.Copy(RutaReporteERP & "PLANTILLA SALDOPRESENTACIONES.xls", path & "\SALDOS PRESENTACIONES.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\SALDOS PRESENTACIONES.xls")
            Dim objHojaMensual As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcelAnual As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)

            exportarMensual(objHojaMensual)

            objHojaMensual.Range("A2:P2").Value = "(Saldos al " & dtpFecha.Value.ToString("dd/MM/yyyy") & ")"
            objHojaExcelAnual.Range("B3:H3").Value = "(Saldos al " & dtpFecha.Value.ToString("dd/MM/yyyy") & ")"
            objHojaMensual.Range("M6:M6").Value = "Stock en Kg al " & dtpFecha.Value.ToString("dd/MM/yyyy") & ""
            objHojaMensual.Range("H6:H6").Value = "Stock por Presentación al " & dtpFecha.Value.ToString("dd/MM/yyyy") & ""
            objHojaMensual.Range("E7:E7").Value = "Stock inicial (01/01/" & dtpFecha.Value.ToString("yyyy") & ")"
            'Stock por Presentación al 31/03/2018
            '"Stock en Kg al 31/03/2018"

            'objHojaMensual.Range("C4").Value = Now.ToString("dd/MM/yyyy hh:mm:ss")
            objHojaExcelAnual.Range("C6").Value = Now.ToString("dd/MM/yyyy hh:mm:ss")
            m_Excel.Visible = True
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub

    Sub exportarMensual(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()

                Dim oPrvFisN As NGProveedorFiscalizado = Nothing
                Dim oPrvFisE As ETProveedorFiscalizado = Nothing
                Dim dtMensual As New DataTable

                oPrvFisN = New NGProveedorFiscalizado
                oPrvFisE = New ETProveedorFiscalizado

                With oPrvFisE
                    .Fecha = dtpFecha.Value
                End With
                Dim n_fila As Int32 = 8
                dtMensual = oPrvFisN.DatosSadosIQBF(oPrvFisE)
                For i As Int16 = 0 To dtMensual.Rows.Count - 1
                    .Range("A" & n_fila + i).Value = dtMensual.Rows(i)("ITEM")
                    .Range("B" & n_fila + i).Value = dtMensual.Rows(i)("COD_PROD_SUNAT")
                    .Range("C" & n_fila + i).Value = dtMensual.Rows(i)("DES_SUNAT")
                    .Range("D" & n_fila + i).Value = dtMensual.Rows(i)("PRESENTACION")
                    .Range("E" & n_fila + i).Value = dtMensual.Rows(i)("SALDO_INICIAL")
                    .Range("F" & n_fila + i).Value = dtMensual.Rows(i)("INGRESO_TOTAL")
                    .Range("G" & n_fila + i).Value = dtMensual.Rows(i)("EGRESO_TOTAL")
                    .Range("J" & n_fila + i).Value = dtMensual.Rows(i)("CANTIDAD_NETA")
                    .Range("I" & n_fila + i).Value = dtMensual.Rows(i)("UNIDAD")
                    '.Range(.Cells(8 + i, 6), .Cells(8 + i, 6)).Value = dtMensual.Rows(i)(2)
                    '.Range(.Cells(8 + i, 7), .Cells(8 + i, 7)).Value = dtMensual.Rows(i)(3)
                    '.Range(.Cells(8 + i, 14), .Cells(8 + i, 14)).Value = dtMensual.Rows(i)(4)
                Next


            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmCargaDatosIQBF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        verificaUsuario()
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
    End Sub
    Sub verificaUsuario()
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        oPrvFisN = New NGProveedorFiscalizado
        oPrvFisE = New ETProveedorFiscalizado

        With oPrvFisE
            .Cod_Cia = Companhia
            .User_Crea = User_Sistema
        End With
        DtUsuario = oPrvFisN.VerificaUserCierre(oPrvFisE)
        If DtUsuario.Rows.Count > 0 Then
            chkcerrar.Visible = True
            btncerrar.Visible = True
            'txtnumsunat.Visible = True
            'dtfechaproceso.Visible = True
        Else
            chkcerrar.Visible = False
            btncerrar.Visible = False
            txtnumsunat.Visible = False
            dtfechaproceso.Visible = False
            lblnumero.Visible = False
            lblfecha.Visible = False
        End If
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btningresobarbotina.Click
        Try
            VerificaCierre()
            If cierre = 1 Then
                MsgBox("El mes se encuentra cerrado", MsgBoxStyle.Information, "Comacsa")
                Exit Sub
            End If
            Dim frm As New frmIngresoBarbotina
            frm.mes = cmbMes.Value
            frm.año = txtAño.Value
            frm.ShowDialog()

            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            Dim DtIngreso As DataTable = Nothing
            Dim DtEgreso As DataTable = Nothing
            Dim DtProduccion As DataTable = Nothing
            Dim DtUso As DataTable = Nothing
            Dim DtGeneral As DataTable = Nothing
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .Cod_Cia = Companhia
                .mes = cmbMes.Value
                .año = txtAño.Value
            End With
            DtUso = oPrvFisN.DatosUsoIQBF(oPrvFisE)
            Call CargarUltraGridxBinding(Grid4, Source4, DtUso)
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Sub Grabar()
        'INGRESO
        VerificaCierre()
        If cierre = 1 Then
            MsgBox("El mes se encuentra cerrado", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If
        If Grid1.Rows.Count <= 0 And Grid2.Rows.Count <= 0 And Grid3.Rows.Count <= 0 And Grid4.Rows.Count <= 0 Then
            MsgBox("No Existen Datos", MsgBoxStyle.Information, msgComacsa)
            Exit Sub
        End If

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        Grid1.PerformAction(ExitEditMode)
        Grid2.PerformAction(ExitEditMode)
        Grid3.PerformAction(ExitEditMode)
        Grid4.PerformAction(ExitEditMode)
        _objNegocio = New NGInsumosFiscalizados
        _objEntidad = New ETInsumosFiscalizados
        Dim list_entidades As New List(Of ETInsumosFiscalizados)
        'INGRESO
        For i As Int32 = 0 To Grid1.Rows.Count - 1
            _objEntidad = New ETInsumosFiscalizados
            _objEntidad.Id_Prod = Grid1.Rows(i).Cells("id").Value
            _objEntidad.cantidad = Grid1.Rows(i).Cells("cantidad").Value
            _objEntidad.numasociado = Grid1.Rows(i).Cells("numasociado").Value
            _objEntidad.numguia = Grid1.Rows(i).Cells("numguia").Value
            _objEntidad.rucproveedor = Grid1.Rows(i).Cells("rucproveedor").Value
            _objEntidad.ructransportista = Grid1.Rows(i).Cells("ructransportista").Value
            _objEntidad.placa = Grid1.Rows(i).Cells("Placa").Value
            _objEntidad.brevete = Grid1.Rows(i).Cells("brevete").Value
            _objEntidad.tdremitente = Grid1.Rows(i).Cells("docasociado").Value
            _objEntidad.tdtransportista = Grid1.Rows(i).Cells("docremision").Value
            _objEntidad.tdcliente = ""
            _objEntidad.guiacliente = ""
            list_entidades.Add(_objEntidad)
        Next
        'EGRESO
        For j As Int32 = 0 To Grid2.Rows.Count - 1
            _objEntidad = New ETInsumosFiscalizados
            _objEntidad.Id_Prod = Grid2.Rows(j).Cells("id").Value
            _objEntidad.cantidad = Grid2.Rows(j).Cells("cantidad").Value
            _objEntidad.numasociado = Grid2.Rows(j).Cells("numasociado").Value
            _objEntidad.numguia = Grid2.Rows(j).Cells("numguia").Value
            _objEntidad.rucproveedor = Grid2.Rows(j).Cells("rucproveedor").Value
            _objEntidad.ructransportista = Grid2.Rows(j).Cells("ructransportista").Value
            _objEntidad.placa = Grid2.Rows(j).Cells("Placa").Value
            _objEntidad.brevete = Grid2.Rows(j).Cells("brevete").Value
            _objEntidad.tdremitente = Grid2.Rows(j).Cells("docasociado").Value
            _objEntidad.tdtransportista = Grid2.Rows(j).Cells("docremision").Value
            _objEntidad.tdcliente = Grid2.Rows(j).Cells("TDGUIACLIENTE").Value
            _objEntidad.guiacliente = Grid2.Rows(j).Cells("GUIACLIENTE").Value
            list_entidades.Add(_objEntidad)
        Next
        'PRODUCION
        For k As Int32 = 0 To Grid3.Rows.Count - 1
            _objEntidad = New ETInsumosFiscalizados
            _objEntidad.Id_Prod = Grid3.Rows(k).Cells("id").Value
            _objEntidad.cantidad = Grid3.Rows(k).Cells("cantidad").Value
            _objEntidad.numasociado = Grid3.Rows(k).Cells("numasociado").Value
            _objEntidad.numguia = ""
            _objEntidad.rucproveedor = ""
            _objEntidad.ructransportista = ""
            _objEntidad.placa = Grid3.Rows(k).Cells("Placa").Value
            _objEntidad.brevete = Grid3.Rows(k).Cells("brevete").Value
            _objEntidad.tdremitente = Grid3.Rows(k).Cells("docasociado").Value
            _objEntidad.tdtransportista = ""
            _objEntidad.tdcliente = ""
            _objEntidad.guiacliente = ""
            list_entidades.Add(_objEntidad)
        Next
        'USO
        For l As Int32 = 0 To Grid4.Rows.Count - 1
            _objEntidad = New ETInsumosFiscalizados
            _objEntidad.Id_Prod = Grid4.Rows(l).Cells("id").Value
            _objEntidad.cantidad = Grid4.Rows(l).Cells("cantidad").Value
            _objEntidad.numasociado = Grid4.Rows(l).Cells("numasociado").Value
            _objEntidad.numguia = Grid4.Rows(l).Cells("numguia").Value
            _objEntidad.rucproveedor = Grid4.Rows(l).Cells("rucproveedor").Value
            _objEntidad.ructransportista = ""
            _objEntidad.placa = Grid4.Rows(l).Cells("Placa").Value
            _objEntidad.brevete = Grid4.Rows(l).Cells("brevete").Value
            _objEntidad.tdremitente = Grid4.Rows(l).Cells("docasociado").Value
            _objEntidad.tdtransportista = "99|Otros"
            _objEntidad.tdcliente = ""
            _objEntidad.guiacliente = ""
            list_entidades.Add(_objEntidad)
        Next
        Dim id As Int32
        id = _objNegocio.Modifica_Iqbf(list_entidades)
        If id <> 0 Then
            proceso(1)
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
        Else
            MsgBox("Se Produjo un Error al Grabar", MsgBoxStyle.Information, msgComacsa)
        End If
        'MsgBox(list_entidades.Count)
    End Sub

    Private Sub Grid1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown, Grid2.KeyDown, Grid3.KeyDown, Grid4.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If

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
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub proceso(ByVal id As Int32)
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DtIngreso As DataTable = Nothing
        Dim DtEgreso As DataTable = Nothing
        Dim DtProduccion As DataTable = Nothing
        Dim DtUso As DataTable = Nothing
        Dim DtGeneral As DataTable = Nothing

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Procesando Datos..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            If id = 0 Then
                If cierre <> 1 Then
                    Dim frm As New frmIngresoBarbotina
                    frm.mes = cmbMes.Value
                    frm.año = txtAño.Value
                    frm.ShowDialog()
                End If
            End If
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            With oPrvFisE
                .Cod_Cia = Companhia
                .mes = cmbMes.Value
                .año = txtAño.Value
            End With
            DtIngreso = oPrvFisN.DatosIngresoIQBF(oPrvFisE)
            DtEgreso = oPrvFisN.DatosEgresoIQBF(oPrvFisE)
            DtProduccion = oPrvFisN.DatosProduccionIQBF(oPrvFisE)
            DtUso = oPrvFisN.DatosUsoIQBF(oPrvFisE)
            DtGeneral = oPrvFisN.DatosGeneralIQBF(oPrvFisE)
            Call CargarUltraGridxBinding(Grid1, Source1, DtIngreso)
            Call CargarUltraGridxBinding(Grid2, Source2, DtEgreso)
            Call CargarUltraGridxBinding(Grid3, Source3, DtProduccion)
            Call CargarUltraGridxBinding(Grid4, Source4, DtUso)
            Call CargarUltraGridxBinding(Grid5, Source5, DtGeneral)

            If id = 0 Then
                MessageBox.Show("Se proceso correctamente la información.", "Sistema", MessageBoxButtons.OK)
                Tab1.Tabs("T02").Selected = True
                btnGenerar.Enabled = True
                btningresobarbotina.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            oPrvFisN = Nothing
            oPrvFisE = Nothing
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub

    Private Sub Grid2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid2.KeyPress, Grid1.KeyPress
        Try
            If sender.ActiveRow.Cells(sender.ActiveCell.Column.Index).Column.Key = "docasociado" Then
                Dim frm As New frmConsulDocSunat
                frm.ShowDialog()
                sender.ActiveRow.Cells("docasociado").Value = Motivodetalle
            End If
            If sender.ActiveRow.Cells(sender.ActiveCell.Column.Index).Column.Key = "docremision" Then
                Dim frm As New frmConsulDocSunat
                frm.ShowDialog()
                sender.ActiveRow.Cells("docremision").Value = Motivodetalle
            End If
            If sender.ActiveRow.Cells(sender.ActiveCell.Column.Index).Column.Key = "TDGUIACLIENTE" Then
                Dim frm As New frmConsulDocSunat
                frm.ShowDialog()
                sender.ActiveRow.Cells("TDGUIACLIENTE").Value = Motivodetalle
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkcerrar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcerrar.CheckedChanged
        Try
            If chkcerrar.Checked = True Then
                lblnumero.Visible = True
                lblfecha.Visible = True
                txtnumsunat.Visible = True
                txtnumsunat.Focus()
                btncerrar.Text = "Cerrar Mes"
                btncerrar.Visible = True
                dtfechaproceso.Visible = True
            Else
                lblnumero.Visible = False
                lblfecha.Visible = False
                txtnumsunat.Visible = False
                'txtnumsunat.Clear()
                btncerrar.Text = "Activar Mes"
                btncerrar.Visible = True
                dtfechaproceso.Visible = False
            End If
            verificaUsuario()
            'If DtUsuario.Rows.Count <= 0 Then Exit Sub
        Catch ex As Exception

        End Try
    End Sub

    Sub VerificaCierre()
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim dtCierre As DataTable = Nothing

        oPrvFisN = New NGProveedorFiscalizado
        oPrvFisE = New ETProveedorFiscalizado

        With oPrvFisE
            .Cod_Cia = Companhia
            .mes = cmbMes.Value
            .año = txtAño.Value
        End With
        dtCierre = oPrvFisN.VerificaCierreIqbf(oPrvFisE)
        cierre = 0
        chkcerrar.Checked = False
        txtnumsunat.Clear()
        If dtCierre.Rows.Count > 0 Then
            cierre = dtCierre.Rows(0)("ESTADO")
            If cierre = 1 Then
                chkcerrar.Checked = True
                txtnumsunat.Text = dtCierre.Rows(0)("NUMSUNAT")
                dtfechaproceso.Value = dtCierre.Rows(0)("FECHAPROCESO")
            Else
                chkcerrar.Checked = False
            End If
        End If
        verificaUsuario()
    End Sub

    Private Sub btncerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncerrar.Click
        Try
            If cmbMes.Value <= 0 Then
                MsgBox("Seleccione un mes a cerrar", MsgBoxStyle.Information, "Comacsa")
                Exit Sub
            End If
            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            Grid1.PerformAction(ExitEditMode)
            Grid2.PerformAction(ExitEditMode)
            Grid3.PerformAction(ExitEditMode)
            Grid4.PerformAction(ExitEditMode)
            _objNegocio = New NGInsumosFiscalizados
            _objEntidad = New ETInsumosFiscalizados
            Dim list_entidades As New List(Of ETInsumosFiscalizados)

            _objEntidad = New ETInsumosFiscalizados
            _objEntidad.ayo = txtAño.Value
            _objEntidad.mes = cmbMes.Value
            If chkcerrar.Checked = True Then
                _objEntidad.observacion = "MES CERRADO"
                _objEntidad.estado = 1
                _objEntidad.numsunat = txtnumsunat.Text
            Else
                _objEntidad.observacion = "MES ABIERTO"
                _objEntidad.estado = 0
                _objEntidad.numsunat = ""
            End If
            _objEntidad.Fecha_Crea = dtfechaproceso.Value
            _objEntidad.User_Crea = User_Sistema

            Dim id As Int32
            id = _objNegocio.Cierre_Iqbf(_objEntidad)
            If id <> 0 Then
                MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            Else
                MsgBox("Se Produjo un Error al Grabar", MsgBoxStyle.Information, msgComacsa)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub Nuevo()
        Dim ope As Int32 = 0
        Dim frm As New frmIngresarIQBF
        Dim tipo As String = ""
        If Tab1.Tabs("T02").Selected = True Then
            tipo = "INGRESO"
            ope = 1
        ElseIf Tab1.Tabs("T03").Selected = True Then
            tipo = "EGRESO"
            ope = 0
        ElseIf Tab1.Tabs("T04").Selected = True Then
            tipo = "PRODUCCION"
            ope = 1
        ElseIf Tab1.Tabs("T05").Selected = True Then
            tipo = "USO"
            ope = 1
        ElseIf Tab1.Tabs("T06").Selected = True Then
            tipo = "GENERAL"
            ope = 0
        End If
        If ope = 1 Then
            frm.tipo = tipo
            frm.mes = cmbMes.Value
            frm.ayo = txtAño.Value
            frm.ShowDialog()

            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            Dim DtIngreso As DataTable = Nothing
            Dim DtEgreso As DataTable = Nothing
            Dim DtProduccion As DataTable = Nothing
            Dim DtUso As DataTable = Nothing
            Dim DtGeneral As DataTable = Nothing

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            With oPrvFisE
                .Cod_Cia = Companhia
                .mes = cmbMes.Value
                .año = txtAño.Value
            End With

            If Tab1.Tabs("T02").Selected = True Then
                DtIngreso = oPrvFisN.DatosIngresoIQBF(oPrvFisE)
                Call CargarUltraGridxBinding(Grid1, Source1, DtIngreso)
            ElseIf Tab1.Tabs("T03").Selected = True Then
                DtEgreso = oPrvFisN.DatosEgresoIQBF(oPrvFisE)
                Call CargarUltraGridxBinding(Grid2, Source2, DtEgreso)
            ElseIf Tab1.Tabs("T04").Selected = True Then
                DtProduccion = oPrvFisN.DatosProduccionIQBF(oPrvFisE)
                Call CargarUltraGridxBinding(Grid3, Source3, DtProduccion)
            ElseIf Tab1.Tabs("T05").Selected = True Then
                DtUso = oPrvFisN.DatosUsoIQBF(oPrvFisE)
                Call CargarUltraGridxBinding(Grid4, Source4, DtUso)
            ElseIf Tab1.Tabs("T06").Selected = True Then
                DtGeneral = oPrvFisN.DatosGeneralIQBF(oPrvFisE)
                Call CargarUltraGridxBinding(Grid5, Source5, DtGeneral)
            End If
        End If
    End Sub
    Sub eliminar()
        If MsgBox("¿Seguro de eliminar registro?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub

        Dim id As Int32 = 0
        If Tab1.Tabs("T02").Selected = True Then
            id = Grid1.ActiveRow.Cells("id").Value
        ElseIf Tab1.Tabs("T03").Selected = True Then
            id = Grid2.ActiveRow.Cells("id").Value
        ElseIf Tab1.Tabs("T04").Selected = True Then
            id = Grid3.ActiveRow.Cells("id").Value
        ElseIf Tab1.Tabs("T05").Selected = True Then
            id = Grid4.ActiveRow.Cells("id").Value
        ElseIf Tab1.Tabs("T06").Selected = True Then
            id = Grid5.ActiveRow.Cells("id").Value
        End If
        If id <> 0 Then

            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            Dim DtIngreso As DataTable = Nothing
            Dim DtEgreso As DataTable = Nothing
            Dim DtProduccion As DataTable = Nothing
            Dim DtUso As DataTable = Nothing
            Dim DtGeneral As DataTable = Nothing

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            With oPrvFisE
                .id = id
            End With

            oPrvFisN.DatosEliminaIQBF(oPrvFisE)

            MessageBox.Show("Se elimino correctamente el registro.", "Sistema", MessageBoxButtons.OK)

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            With oPrvFisE
                .Cod_Cia = Companhia
                .mes = cmbMes.Value
                .año = txtAño.Value
            End With

            If Tab1.Tabs("T02").Selected = True Then
                DtIngreso = oPrvFisN.DatosIngresoIQBF(oPrvFisE)
                Call CargarUltraGridxBinding(Grid1, Source1, DtIngreso)
            ElseIf Tab1.Tabs("T03").Selected = True Then
                DtEgreso = oPrvFisN.DatosEgresoIQBF(oPrvFisE)
                Call CargarUltraGridxBinding(Grid2, Source2, DtEgreso)
            ElseIf Tab1.Tabs("T04").Selected = True Then
                DtProduccion = oPrvFisN.DatosProduccionIQBF(oPrvFisE)
                Call CargarUltraGridxBinding(Grid3, Source3, DtProduccion)
            ElseIf Tab1.Tabs("T05").Selected = True Then
                DtUso = oPrvFisN.DatosUsoIQBF(oPrvFisE)
                Call CargarUltraGridxBinding(Grid4, Source4, DtUso)
            ElseIf Tab1.Tabs("T06").Selected = True Then
                DtGeneral = oPrvFisN.DatosGeneralIQBF(oPrvFisE)
                Call CargarUltraGridxBinding(Grid5, Source5, DtGeneral)
            End If
        End If
    End Sub
End Class