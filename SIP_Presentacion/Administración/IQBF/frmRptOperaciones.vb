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
Public Class frmRptOperaciones
    Public Ls_Permisos As New List(Of Integer)
    Dim procesado As Int32
    Dim _objNegocio As NGInsumosFiscalizados
    Dim _objEntidad As ETInsumosFiscalizados
    Dim cierre As Int32 = 0

    Sub Reporte()
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DtIngreso As DataTable = Nothing
        Dim DtEgreso As DataTable = Nothing
        Dim DtProduccion As DataTable = Nothing
        Dim DtUso As DataTable = Nothing
        Dim DtGeneral As DataTable = Nothing

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .Cod_Cia = Companhia
                .FechIniVig = dtinicio.Value
                .FechFinVig = dtfin.Value
            End With
            DtIngreso = oPrvFisN.RptIngresoIQBF(oPrvFisE)
            DtEgreso = oPrvFisN.RptEgresoIQBF(oPrvFisE)
            DtProduccion = oPrvFisN.RptProduccionIQBF(oPrvFisE)
            DtUso = oPrvFisN.RptUsoIQBF(oPrvFisE)
            DtGeneral = oPrvFisN.RptGeneralIQBF(oPrvFisE)

            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\IngresoIQBF.xls")
            File.Copy(RutaReporteERP & "PLANTILLAINGRESOTOTALIQBF.xls", path & "\IngresoIQBF.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait

            m_Excel.Workbooks.Open(path & "\IngresoIQBF.xls")

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcelEgreso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            Dim objHojaExcelProduccion As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            Dim objHojaExcelUso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
            Dim objHojaExcelGeneral As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(5)
            objHojaExcel.Name = "Ingreso"
            objHojaExcelEgreso.Name = "Egreso"
            objHojaExcelProduccion.Name = "Producción"
            objHojaExcelUso.Name = "Uso"
            objHojaExcelGeneral.Name = "General"

            exportarIngreso(objHojaExcel, DtIngreso)
            exportarEgreso(objHojaExcelEgreso, DtEgreso)
            exportarProduccion(objHojaExcelProduccion, DtProduccion)
            exportarUso(objHojaExcelUso, DtUso)
            exportarGeneral(objHojaExcelGeneral, DtGeneral)

            m_Excel.Visible = True
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
            'MessageBox.Show("Se proceso correctamente la información.", "Sistema", MessageBoxButtons.OK)
            'Tab1.Tabs("T02").Selected = True

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

    Sub exportarIngreso(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal datos As DataTable)
        Try
            If datos.Rows.Count <= 0 Then Exit Sub
            'Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            'Dim path As String
            'path = Application.StartupPath
            'File.Delete(path & "\IngresoIQBF.xls")
            'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait

            'm_Excel.Workbooks.Open(path & "\IngresoIQBF.xls")
            'Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            'objHojaExcel.Name = "1|Ingreso"

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()

                .Range("A1").Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
                .Range("A2").Value = "REGISTRO DE OPERACIONES: INGRESO DE IQBF - " & dtinicio.Value.ToString("dd/MM/yyyy") & " A " & dtfin.Value.ToString("dd/MM/yyyy")
                .Range("A3").Value = "Establecimiento en que se produce el bien : " & datos.Rows(0)("establecimiento")
                '.Range(.Cells(Numero, 1), .Cells(Numero, 17)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                For i As Int32 = 0 To datos.Rows.Count - 1
                    .Range("A" & 6 + i & ":" & "U" & 6 + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("A" & 6 + i).Value = datos.Rows(i)("transaccion")
                    .Range("B" & 6 + i).Value = datos.Rows(i)("presentacion")
                    .Range("C" & 6 + i).Value = datos.Rows(i)("presentacion_des")
                    .Range("D" & 6 + i).Value = datos.Rows(i)("cantidad")
                    .Range("E" & 6 + i).Value = datos.Rows(i)("cantidadkilos")
                    .Range("F" & 6 + i).Value = datos.Rows(i)("docasociado")
                    .Range("G" & 6 + i).Value = datos.Rows(i)("numasociado")
                    .Range("H" & 6 + i).Value = datos.Rows(i)("fecha")
                    .Range("I" & 6 + i).Value = datos.Rows(i)("tipodestino")
                    .Range("J" & 6 + i).Value = datos.Rows(i)("numdestino")
                    .Range("K" & 6 + i).Value = datos.Rows(i)("tipodoc")
                    .Range("L" & 6 + i).Value = datos.Rows(i)("rucproveedor")
                    .Range("M" & 6 + i).Value = datos.Rows(i)("razonproveedor")
                    .Range("N" & 6 + i).Value = datos.Rows(i)("ructransportista")
                    .Range("O" & 6 + i).Value = datos.Rows(i)("razontransportista")
                    .Range("P" & 6 + i).Value = datos.Rows(i)("docremision")
                    .Range("Q" & 6 + i).Value = datos.Rows(i)("numguia")
                    .Range("R" & 6 + i).Value = datos.Rows(i)("placa")
                    .Range("S" & 6 + i).Value = datos.Rows(i)("brevete")
                    .Range("T" & 6 + i).Value = datos.Rows(i)("observacion")
                Next
                'm_Excel.Visible = True
                'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarEgreso(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal datos As DataTable)
        Try
            If datos.Rows.Count <= 0 Then Exit Sub
            'Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            'Dim path As String
            'path = Application.StartupPath
            'File.Delete(path & "\EgresoIQBF.xls")
            'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            'm_Excel.Workbooks.Open(path & "\EgresoIQBF.xls")
            'Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            'objHojaExcel.Name = "1|Egreso"

            With objHojaExcel
                '.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()

                .Range("A1").Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
                .Range("A2").Value = "REGISTRO DE OPERACIONES: EGRESO DE IQBF - " & dtinicio.Value.ToString("dd/MM/yyyy") & " A " & dtfin.Value.ToString("dd/MM/yyyy")
                .Range("A3").Value = "Establecimiento en que se produce el bien : " & datos.Rows(0)("establecimiento")
                '.Range(.Cells(Numero, 1), .Cells(Numero, 17)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                For i As Int32 = 0 To datos.Rows.Count - 1
                    .Range("A" & 6 + i & ":" & "X" & 6 + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("A" & 6 + i).Value = datos.Rows(i)("fechafactura")
                    .Range("B" & 6 + i).Value = datos.Rows(i)("transaccion")

                    .Range("C" & 6 + i).Value = datos.Rows(i)("tipofactura")
                    .Range("D" & 6 + i).Value = datos.Rows(i)("numfactura")
                    .Range("E" & 6 + i).Value = datos.Rows(i)("fecha")

                    .Range("F" & 6 + i).Value = datos.Rows(i)("docasociado")
                    .Range("G" & 6 + i).Value = datos.Rows(i)("numasociado")
                    .Range("H" & 6 + i).Value = datos.Rows(i)("nomfiscalizado")
                    '.Range("F" & 6 + i).Value = datos.Rows(i)("fecha")
                    .Range("J" & 6 + i).Value = datos.Rows(i)("cantidad")
                    .Range("K" & 6 + i).Value = datos.Rows(i)("cantidadkilos")
                    .Range("L" & 6 + i).Value = datos.Rows(i)("presentacion")
                    .Range("M" & 6 + i).Value = datos.Rows(i)("tipodoc")
                    .Range("N" & 6 + i).Value = datos.Rows(i)("rucproveedor")
                    .Range("O" & 6 + i).Value = datos.Rows(i)("razon")
                    .Range("P" & 6 + i).Value = datos.Rows(i)("tdguiacliente")
                    .Range("Q" & 6 + i).Value = datos.Rows(i)("guiacliente")
                    .Range("R" & 6 + i).Value = datos.Rows(i)("ructransportista")
                    .Range("S" & 6 + i).Value = datos.Rows(i)("razontransportista")
                    .Range("T" & 6 + i).Value = datos.Rows(i)("placa")
                    .Range("U" & 6 + i).Value = datos.Rows(i)("docremision")
                    .Range("V" & 6 + i).Value = datos.Rows(i)("numguia")

                    .Range("W" & 6 + i).Value = datos.Rows(i)("brevete")
                    .Range("X" & 6 + i).Value = datos.Rows(i)("observacion")
                Next
                'm_Excel.Visible = True
                'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarProduccion(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal datos As DataTable)
        Try

            'hv 18/09/2024
            'hv 20/09/2024

            If datos.Rows.Count <= 0 Then Exit Sub

            Dim Lxls As Integer = 6
            Dim fil1Actual As Integer = 0
            Dim fil2Actual As Integer = 0
            Dim fil3Actual As Integer = 0

            With objHojaExcel

                .Range("A1").Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
                .Range("A2").Value = "REGISTRO DE OPERACIONES: PRODUCCION DE IQBF - " & dtinicio.Value.ToString("dd/MM/yyyy") & " A " & dtfin.Value.ToString("dd/MM/yyyy")
                .Range("A3").Value = "Establecimiento en que se produce el bien : " & datos.Rows(0)("establecimiento")

                For i As Int32 = 0 To datos.Rows.Count - 1

                    If datos.Rows(i)("Placa") = 1 Then
                        .Range("A" & Lxls + fil1Actual).Value = datos.Rows(i)("fecha")
                        .Range("B" & Lxls + fil1Actual).Value = datos.Rows(i)("docasociado")
                        .Range("C" & Lxls + fil1Actual).Value = datos.Rows(i)("numasociado")
                        .Range("D" & Lxls + fil1Actual).Value = datos.Rows(i)("presentacion")
                        .Range("E" & Lxls + fil1Actual).Value = datos.Rows(i)("presentacion_des")
                        .Range("F" & Lxls + fil1Actual).Value = datos.Rows(i)("cantidad")
                        .Range("G" & Lxls + fil1Actual).Value = datos.Rows(i)("cantidadkilos")
                        .Range("H" & Lxls + fil1Actual).Value = "Kg."
                        .Range("I" & Lxls + fil1Actual).Value = datos.Rows(i)("observacion")
                        fil1Actual = fil1Actual + 1

                    ElseIf datos.Rows(i)("Placa") = 2 And datos.Rows(i)("brevete") = 3 Then
                        .Range("T" & Lxls + fil2Actual).Value = datos.Rows(i)("fecha")
                        .Range("U" & Lxls + fil2Actual).Value = datos.Rows(i)("docasociado")
                        .Range("V" & Lxls + fil2Actual).Value = datos.Rows(i)("numasociado")
                        .Range("W" & Lxls + fil2Actual).Value = datos.Rows(i)("presentacion")
                        .Range("X" & Lxls + fil2Actual).Value = datos.Rows(i)("presentacion_des")
                        .Range("Y" & Lxls + fil2Actual).Value = "" ' FALTA CONCENTRACION
                        .Range("Z" & Lxls + fil2Actual).Value = datos.Rows(i)("cantidad")
                        .Range("AA" & Lxls + fil2Actual).Value = datos.Rows(i)("cantidadkilos")
                        .Range("AB" & Lxls + fil2Actual).Value = "Kg."
                        fil2Actual = fil2Actual + 1

                    ElseIf datos.Rows(i)("Placa") = 2 And datos.Rows(i)("brevete") = 4 Then

                        .Range("J" & Lxls + fil3Actual).Value = datos.Rows(i)("fecha")
                        .Range("K" & Lxls + fil3Actual).Value = datos.Rows(i)("docasociado")
                        .Range("L" & Lxls + fil3Actual).Value = datos.Rows(i)("numasociado")
                        .Range("M" & Lxls + fil3Actual).Value = datos.Rows(i)("presentacion")
                        .Range("N" & Lxls + fil3Actual).Value = datos.Rows(i)("presentacion_des")
                        .Range("O" & Lxls + fil3Actual).Value = "" ' FALTA CONCENTRACION
                        .Range("P" & Lxls + fil3Actual).Value = datos.Rows(i)("cantidad")
                        .Range("Q" & Lxls + fil3Actual).Value = datos.Rows(i)("cantidadkilos")
                        .Range("R" & Lxls + fil3Actual).Value = "Kg."
                        .Range("S" & Lxls + fil3Actual).Formula = "=G" & Lxls + fil3Actual & "/Q" & Lxls + fil3Actual & ""

                        fil3Actual = fil3Actual + 1
                    End If
                    .Range("A" & Lxls + i & ":" & "AB" & Lxls + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                Next
            End With
        Catch ex As Exception

        End Try
    End Sub



    Sub exportarProduccion11(ByVal objHojaExcel As Excel.Worksheet, ByVal datos As DataTable)
        Try
            If datos.Rows.Count <= 0 Then Exit Sub

            Dim Lxls As Integer = 6

            With objHojaExcel
                .Range("A1").Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
                .Range("A2").Value = "REGISTRO DE OPERACIONES: PRODUCCION DE IQBF - " & dtinicio.Value.ToString("dd/MM/yyyy") & " A " & dtfin.Value.ToString("dd/MM/yyyy")
                .Range("A3").Value = "Establecimiento en que se produce el bien : " & datos.Rows(0)("establecimiento")

                Dim filaActual As Integer = Lxls
                Dim col1Actual As Integer = 1
                Dim col2Actual As Integer = 1

                For i As Integer = 0 To datos.Rows.Count - 1
                    Dim fila As Integer = datos.Rows(i)("fila")
                    Dim tipo As Integer = datos.Rows(i)("tipo")

                    If tipo = 1 Then
                        .Range("A" & filaActual).Value = col1Actual & " 1"
                        col1Actual += 1
                    ElseIf tipo = 2 Then
                        .Range("B" & filaActual).Value = col2Actual & " 2"
                        col2Actual += 1
                    End If

                    filaActual += 1
                Next

                ' Aplicar bordes a las celdas
                For i As Integer = Lxls To filaActual - 1
                    .Range("A" & i & ":" & "B" & i).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                Next
            End With
        Catch ex As Exception
            ' Manejo de excepciones
        End Try
    End Sub


    Sub exportarUso(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal datos As DataTable)
        Try
            If datos.Rows.Count <= 0 Then Exit Sub
            'Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            'Dim path As String
            'path = Application.StartupPath
            'File.Delete(path & "\UsoIQBF.xls")
            'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            'm_Excel.Workbooks.Open(path & "\UsoIQBF.xls")
            'Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            'objHojaExcel.Name = "1|Uso"

            With objHojaExcel
                '.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()

                .Range("A1").Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
                .Range("A2").Value = "REGISTRO DE OPERACIONES: USO DE IQBF - " & dtinicio.Value.ToString("dd/MM/yyyy") & " A " & dtfin.Value.ToString("dd/MM/yyyy")
                .Range("A3").Value = "Establecimiento en que se produce el bien : " & datos.Rows(0)("establecimiento")
                '.Range(.Cells(Numero, 1), .Cells(Numero, 17)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                For i As Int32 = 0 To datos.Rows.Count - 1
                    .Range("A" & 6 + i & ":" & "U" & 6 + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("A" & 6 + i).Value = datos.Rows(i)("transaccion")
                    .Range("B" & 6 + i).Value = datos.Rows(i)("presentacion")
                    .Range("C" & 6 + i).Value = datos.Rows(i)("presentacion_des")
                    .Range("D" & 6 + i).Value = datos.Rows(i)("cantidad")
                    .Range("E" & 6 + i).Value = datos.Rows(i)("cantidadkilos")
                    .Range("F" & 6 + i).Value = datos.Rows(i)("docasociado")
                    .Range("G" & 6 + i).Value = datos.Rows(i)("numasociado")
                    .Range("H" & 6 + i).Value = datos.Rows(i)("fecha")
                    .Range("I" & 6 + i).Value = datos.Rows(i)("tipodoc")
                    .Range("J" & 6 + i).Value = datos.Rows(i)("rucproveedor")
                    .Range("K" & 6 + i).Value = datos.Rows(i)("razon")
                    .Range("L" & 6 + i).Value = datos.Rows(i)("merma")
                    .Range("M" & 6 + i).Value = datos.Rows(i)("codProducto")
                    .Range("N" & 6 + i).Value = datos.Rows(i)("cantidadProduccion")
                    .Range("O" & 6 + i).Value = datos.Rows(i)("numruc")
                    .Range("P" & 6 + i).Value = datos.Rows(i)("tipoguia")
                    .Range("Q" & 6 + i).Value = datos.Rows(i)("numguia")
                    .Range("R" & 6 + i).Value = "" 'datos.Rows(i)("Placa")
                    .Range("S" & 6 + i).Value = "" 'datos.Rows(i)("brevete")
                    .Range("T" & 6 + i).Value = datos.Rows(i)("observacion")
                    .Range("U" & 6 + i).Value = datos.Rows(i)("codincidencia")
                    '.Range("U" & 6 + i).Value = datos.Rows(i)("codincidencia")
                Next
                'm_Excel.Visible = True
                'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarGeneral(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal datos As DataTable)
        Try
            If datos.Rows.Count <= 0 Then Exit Sub

            With objHojaExcel
                '.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()

                .Range("A1").Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
                '.Range("A2").Value = "REGISTRO DE OPERACIONES: USO DE IQBF - " & dtinicio.Value.ToString("dd/MM/yyyy") & " A " & dtfin.Value.ToString("dd/MM/yyyy")
                .Range("A2").Value = "REGISTRO DE OPERACIONES: GENERAL (AJUSTE POR INCREMENTO Y DISMINUCIÓN DE INGRESOS)  DE IQBF - " & dtinicio.Value.ToString("dd/MM/yyyy") & " A " & dtfin.Value.ToString("dd/MM/yyyy")
                '.Range(.Cells(Numero, 1), .Cells(Numero, 17)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                Dim nfila As Int32 = 5
                For i As Int32 = 0 To datos.Rows.Count - 1
                    .Range("A" & nfila + i & ":" & "K" & nfila + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("A" & nfila + i).Value = datos.Rows(i)("operacion")
                    .Range("B" & nfila + i).Value = datos.Rows(i)("establecimiento")
                    .Range("C" & nfila + i).Value = datos.Rows(i)("transaccion")
                    .Range("D" & nfila + i).Value = datos.Rows(i)("presentacion")
                    .Range("E" & nfila + i).Value = datos.Rows(i)("presentacion_des")
                    .Range("F" & nfila + i).Value = datos.Rows(i)("cantidad")
                    .Range("G" & nfila + i).Value = datos.Rows(i)("tipodoc")
                    .Range("H" & nfila + i).Value = datos.Rows(i)("numasociado")
                    .Range("I" & nfila + i).Value = datos.Rows(i)("fecha")
                    .Range("J" & nfila + i).Value = datos.Rows(i)("observacion")
                    .Range("K" & nfila + i).Value = "" 'datos.Rows(i)("razon")
                Next
                'm_Excel.Visible = True
                'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtfin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtfin.ValueChanged

    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged

    End Sub
End Class