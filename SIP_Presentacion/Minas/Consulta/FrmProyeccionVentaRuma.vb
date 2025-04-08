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
Public Class FrmProyeccionVentaRuma
    Public Ls_Permisos As New List(Of Integer)
    Dim DsDatos As DataSet
    Dim dtVenta As DataTable
    Dim dtRuma As DataTable
    Private Sub FrmProyeccionVentaRuma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        Me.cmbMes.SelectedIndex = Now.Date.Month - 1
    End Sub '_Permisos As New List(Of Integer)
    Sub procesar()
        DsDatos = New DataSet
        dtVenta = New DataTable
        dtRuma = New DataTable
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Procesando datos..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .Cod_Cia = Companhia
                .año = txtAño.Value
                .mes = cmbMes.Value
            End With
            DsDatos = oPrvFisN.ReporteProyeccionVentaRuma(oPrvFisE)
            dtVenta = DsDatos.Tables(0)
            dtRuma = DsDatos.Tables(1)
            Reporte()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub
    Sub Reporte()
        If dtVenta.Rows.Count <= 0 Then
            MsgBox("No existen datos para el reporte", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If
        If dtRuma.Columns.Count = 2 Then
            MsgBox("Hay rumas que no se encuentran agupadas", MsgBoxStyle.Information, "Comacsa")
            Dim frm As New frmSinAgrupacion
            frm.gridRuma.DataSource = dtRuma
            frm.ShowDialog()
            Exit Sub
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\PROYECCIONVENTARUMA_" & cmbMes.Text & ".xls")
            File.Copy(RutaReporteERP & "PLANTILLAPROYECCIONVENTARUMA.xls", path & "\PROYECCIONVENTARUMA_" & cmbMes.Text & ".xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\PROYECCIONVENTARUMA_" & cmbMes.Text & ".xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcelIngreso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcelRumas As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            exportarReporte(objHojaExcelIngreso)
            exportarReporteRuma(objHojaExcelRumas)
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

    Sub exportarReporte(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 5
            Dim nfilaini As Integer = 5
            Dim nfilault As Integer = 0
            Dim COD_PROD As String = String.Empty
            Dim VENDIDO As Double = 0
            Dim PROYECTADO As Double = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A1").Value = "MINERALES UTILIZADOS EN VENTAS " & nombreMEs(cmbMes.Value) & " - " & txtAño.Value
                COD_PROD = dtVenta.Rows(0)("COD_PROD").ToString.Trim
                For i As Int32 = 0 To dtVenta.Rows.Count - 1
                    .Range(.Cells(5 + i, 1), .Cells(5 + i, 1)).Value = dtVenta.Rows(i)("COD_PROD")
                    .Range(.Cells(5 + i, 2), .Cells(5 + i, 2)).Value = dtVenta.Rows(i)("DESCRIP")
                    .Range(.Cells(5 + i, 3), .Cells(5 + i, 3)).Value = dtVenta.Rows(i)("PROYECTADO")
                    .Range(.Cells(5 + i, 4), .Cells(5 + i, 4)).Value = dtVenta.Rows(i)("VENDIDO")
                    VENDIDO = dtVenta.Rows(i)("VENDIDO")
                    PROYECTADO = IIf(VENDIDO = 0, 1, dtVenta.Rows(i)("PROYECTADO"))
                    .Range(.Cells(5 + i, 5), .Cells(5 + i, 5)).Value = IIf(PROYECTADO = 0, 0, VENDIDO / PROYECTADO)
                    If dtVenta.Rows(i)("VENDIDO") = 0 And dtVenta.Rows(i)("PROYECTADO") = 0 Then
                        .Range(.Cells(5 + i, 5), .Cells(5 + i, 5)).Value = ""
                    End If
                    .Range(.Cells(5 + i, 6), .Cells(5 + i, 6)).Value = dtVenta.Rows(i)("CODRUMA")
                    .Range(.Cells(5 + i, 7), .Cells(5 + i, 7)).Value = dtVenta.Rows(i)("RUMA")
                    .Range(.Cells(5 + i, 8), .Cells(5 + i, 8)).Value = dtVenta.Rows(i)("UTILIZADO")
                    .Range(.Cells(5 + i, 1), .Cells(5 + i, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    If IIf(PROYECTADO = 0, 0, VENDIDO / PROYECTADO) < 1 Then
                        .Range(.Cells(5 + i, 5), .Cells(5 + i, 5)).Font.Color = -16776961
                    Else
                        .Range(.Cells(5 + i, 5), .Cells(5 + i, 5)).Font.Color = 0
                    End If

                    If COD_PROD.Trim <> dtVenta.Rows(i)("COD_PROD").ToString.Trim Then
                        nfilault = 4 + i
                        .Range(.Cells(nfilaini, 1), .Cells(nfilault, 1)).Merge()
                        .Range(.Cells(nfilaini, 2), .Cells(nfilault, 2)).Merge()
                        .Range(.Cells(nfilaini, 3), .Cells(nfilault, 3)).Merge()
                        .Range(.Cells(nfilaini, 4), .Cells(nfilault, 4)).Merge()
                        .Range(.Cells(nfilaini, 5), .Cells(nfilault, 5)).Merge()
                        nfilaini = 5 + i
                        COD_PROD = dtVenta.Rows(i)("COD_PROD").ToString.Trim
                        'correl += 1
                    End If
                    ultFila = i + 6
                Next
                .Range(.Cells(nfilaini, 1), .Cells(ultFila - 1, 1)).Merge()
                .Range(.Cells(nfilaini, 2), .Cells(ultFila - 1, 2)).Merge()
                .Range(.Cells(nfilaini, 3), .Cells(ultFila - 1, 3)).Merge()
                .Range(.Cells(nfilaini, 4), .Cells(ultFila - 1, 4)).Merge()
                .Range(.Cells(nfilaini, 5), .Cells(ultFila - 1, 5)).Merge()

                .Range(.Cells(ultFila, 2), .Cells(ultFila, 2)).Value = "TOTALES"
                .Range(.Cells(ultFila, 2), .Cells(ultFila, 5)).Font.Bold = True
                .Range(.Cells(ultFila, 2), .Cells(ultFila, 5)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(ultFila, 3), .Cells(ultFila, 3)).Formula = "=SUMA(C5 : C" & ultFila - 1 & ")"
                .Range(.Cells(ultFila, 4), .Cells(ultFila, 4)).Formula = "=SUMA(D5 : D" & ultFila - 1 & ")"
                .Range(.Cells(ultFila, 5), .Cells(ultFila, 5)).Formula = "=D" & ultFila & " / C" & ultFila & ""

                .Range(.Cells(ultFila, 7), .Cells(ultFila, 7)).Value = "TOTAL"
                .Range(.Cells(ultFila, 7), .Cells(ultFila, 8)).Font.Bold = True
                .Range(.Cells(ultFila, 7), .Cells(ultFila, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(ultFila, 8), .Cells(ultFila, 8)).Formula = "=SUMA(H5 : H" & ultFila - 1 & ")"
            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarReporteRuma(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 5
            Dim nfilaini As Integer = 5
            Dim nfilault As Integer = 0

            Dim nfilaagru As Integer = 5
            Dim nfilainiagru As Integer = 5
            Dim nfilaultagru As Integer = 0

            Dim CODRUMA As String = String.Empty
            Dim CODAGRUPACION As String = String.Empty
            With objHojaExcel
                '.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                '.Activate()
                .Range("R4").Value = "STOCK " & nombreMEs(cmbMes.Value)
                .Range("S4").Value = "STOCK " & nombreMEs(IIf(cmbMes.Value = 1, 12, cmbMes.Value - 1))
                'COD_PROD = dtVenta.Rows(0)("COD_PROD").ToString.Trim
                .Range("A1").Value = "MINERALES PROYECTADOS VS VENTAS " & nombreMEs(cmbMes.Value) & " - " & txtAño.Value
                Dim INGRESADO As Double = 0
                Dim PROYECTADO As Double = 0
                Dim INGRESADOACUM As Double = 0
                Dim PROYECTADOACUM As Double = 0
                Dim INGRESADOPROM As Double = 0
                Dim PROYECTADOPROM As Double = 0
                CODRUMA = dtRuma.Rows(0)("CODRUMA").ToString.Trim
                CODAGRUPACION = dtRuma.Rows(0)("CODAGRUPACION").ToString.Trim

                For i As Int32 = 0 To dtRuma.Rows.Count - 1
                    .Range(.Cells(5 + i, 1), .Cells(5 + i, 1)).Value = dtRuma.Rows(i)("CODRUMA")
                    .Range(.Cells(5 + i, 2), .Cells(5 + i, 2)).Value = dtRuma.Rows(i)("AGRUPACION")
                    .Range(.Cells(5 + i, 3), .Cells(5 + i, 3)).Value = dtRuma.Rows(i)("DESCRIPCION")
                    .Range(.Cells(5 + i, 4), .Cells(5 + i, 4)).Value = dtRuma.Rows(i)("CANTERA")
                    .Range(.Cells(5 + i, 5), .Cells(5 + i, 5)).Value = dtRuma.Rows(i)("PROYECTADO")
                    .Range(.Cells(5 + i, 6), .Cells(5 + i, 6)).Value = dtRuma.Rows(i)("VENTATOTAL")
                    .Range(.Cells(5 + i, 7), .Cells(5 + i, 7)).Value = dtRuma.Rows(i)("INGRESADO")

                    .Range(.Cells(5 + i, 9), .Cells(5 + i, 9)).Value = dtRuma.Rows(i)("PROYECTADOACUM")
                    .Range(.Cells(5 + i, 10), .Cells(5 + i, 10)).Value = dtRuma.Rows(i)("VENTATOTALACUM")
                    .Range(.Cells(5 + i, 11), .Cells(5 + i, 11)).Value = dtRuma.Rows(i)("INGRESADOACUM")

                    .Range(.Cells(5 + i, 13), .Cells(5 + i, 13)).Value = dtRuma.Rows(i)("PROYECTADOPROM")
                    .Range(.Cells(5 + i, 14), .Cells(5 + i, 14)).Value = dtRuma.Rows(i)("VENTATOTALPROM")
                    .Range(.Cells(5 + i, 15), .Cells(5 + i, 15)).Value = dtRuma.Rows(i)("INGRESADOPROM")

                    '.Range(.Cells(5 + i, 18), .Cells(5 + i, 18)).Value = dtRuma.Rows(i)("INGRESADORUMAACUM")
                    '.Range(.Cells(5 + i, 19), .Cells(5 + i, 19)).Value = dtRuma.Rows(i)("VENTATOTALRUMAACUM")
                    '*************************CUMPLMIENTO DEL MES*************************
                    INGRESADO = dtRuma.Rows(i)("INGRESADO")
                    PROYECTADO = IIf(INGRESADO = 0, 1, dtRuma.Rows(i)("PROYECTADO"))
                    .Range(.Cells(5 + i, 8), .Cells(5 + i, 8)).Value = dtRuma.Rows(i)("CUMPLIMIENTO")
                    '.Range(.Cells(5 + i, 7), .Cells(5 + i, 7)).Value = IIf(PROYECTADO = 0, 0, INGRESADO / PROYECTADO)
                    If dtRuma.Rows(i)("INGRESADO") = 0 And dtRuma.Rows(i)("PROYECTADO") = 0 Then
                        .Range(.Cells(5 + i, 8), .Cells(5 + i, 8)).Value = ""
                    End If

                    If dtRuma.Rows(i)("CUMPLIMIENTO") < 1 Then
                        .Range(.Cells(5 + i, 8), .Cells(5 + i, 8)).Font.Color = -16776961
                    Else
                        .Range(.Cells(5 + i, 8), .Cells(5 + i, 8)).Font.Color = 0
                    End If
                    '***************************************************************************

                    '*************************CUMPLMIENTO ACUMULADO*************************
                    INGRESADO = dtRuma.Rows(i)("INGRESADOACUM")
                    PROYECTADO = IIf(INGRESADO = 0, 1, dtRuma.Rows(i)("PROYECTADOACUM"))
                    .Range(.Cells(5 + i, 12), .Cells(5 + i, 12)).Value = dtRuma.Rows(i)("CUMPLIMIENTOACUM")
                    '.Range(.Cells(5 + i, 11), .Cells(5 + i, 11)).Value = IIf(PROYECTADO = 0, 0, INGRESADO / PROYECTADO)
                    If dtRuma.Rows(i)("INGRESADOACUM") = 0 And dtRuma.Rows(i)("PROYECTADOACUM") = 0 Then
                        .Range(.Cells(5 + i, 12), .Cells(5 + i, 12)).Value = ""
                    End If

                    If dtRuma.Rows(i)("CUMPLIMIENTOACUM") < 1 Then
                        .Range(.Cells(5 + i, 12), .Cells(5 + i, 12)).Font.Color = -16776961
                    Else
                    End If
                    '***************************************************************************

                    '*************************CUMPLMIENTO PROMEDIO*************************
                    INGRESADO = dtRuma.Rows(i)("INGRESADOPROM")
                    PROYECTADO = IIf(INGRESADO = 0, 1, dtRuma.Rows(i)("PROYECTADOPROM"))
                    .Range(.Cells(5 + i, 16), .Cells(5 + i, 16)).Value = dtRuma.Rows(i)("CUMPLIMIENTOPROM")
                    '.Range(.Cells(5 + i, 15), .Cells(5 + i, 15)).Value = IIf(PROYECTADO = 0, 0, INGRESADO / PROYECTADO)
                    If dtRuma.Rows(i)("INGRESADOPROM") = 0 And dtRuma.Rows(i)("PROYECTADOPROM") = 0 Then
                        .Range(.Cells(5 + i, 16), .Cells(5 + i, 16)).Value = ""
                    End If

                    If dtRuma.Rows(i)("CUMPLIMIENTOPROM") < 1 Then
                        .Range(.Cells(5 + i, 16), .Cells(5 + i, 16)).Font.Color = -16776961
                    Else
                        .Range(.Cells(5 + i, 16), .Cells(5 + i, 16)).Font.Color = 0
                    End If
                    '***************************************************************************

                    '*************************CUMPLMIENTO VENTA PROMEDIO*************************
                    INGRESADO = dtRuma.Rows(i)("VENTATOTALPROM")
                    PROYECTADO = IIf(INGRESADO = 0, 1, dtRuma.Rows(i)("PROYECTADOPROM"))
                    .Range(.Cells(5 + i, 17), .Cells(5 + i, 17)).Value = dtRuma.Rows(i)("CUMPLIMIENTOVENTAPROM")
                    '.Range(.Cells(5 + i, 15), .Cells(5 + i, 15)).Value = IIf(PROYECTADO = 0, 0, INGRESADO / PROYECTADO)
                    If dtRuma.Rows(i)("VENTATOTALPROM") = 0 And dtRuma.Rows(i)("PROYECTADOPROM") = 0 Then
                        .Range(.Cells(5 + i, 17), .Cells(5 + i, 17)).Value = ""
                    End If

                    If dtRuma.Rows(i)("CUMPLIMIENTOVENTAPROM") < 1 Then
                        .Range(.Cells(5 + i, 17), .Cells(5 + i, 17)).Font.Color = -16776961
                    Else
                        .Range(.Cells(5 + i, 17), .Cells(5 + i, 17)).Font.Color = 0
                    End If
                    '***************************************************************************



                    .Range(.Cells(5 + i, 18), .Cells(5 + i, 18)).Value = dtRuma.Rows(i)("STOCKACTUAL")
                    .Range(.Cells(5 + i, 19), .Cells(5 + i, 19)).Value = dtRuma.Rows(i)("STOCKANTERIOR")
                    'If .Range("N" & 5 + i).Value <= 0 Then
                    '    .Range(.Cells(5 + i, 20), .Cells(5 + i, 20)).Formula = 0
                    'Else
                    '    .Range(.Cells(5 + i, 20), .Cells(5 + i, 20)).Formula = "=R" & 5 + i & "/N" & 5 + i
                    'End If

                    .Range(.Cells(5 + i, 20), .Cells(5 + i, 20)).Formula = "=R" & 5 + i & "/N" & 5 + i

                    .Range(.Cells(5 + i, 1), .Cells(5 + i, 20)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    If CODAGRUPACION.Trim <> dtRuma.Rows(i)("CODAGRUPACION").ToString.Trim Then
                        nfilaultagru = 4 + i
                        .Range(.Cells(nfilainiagru, 2), .Cells(nfilaultagru, 2)).Merge()
                        .Range(.Cells(nfilainiagru, 5), .Cells(nfilaultagru, 5)).Merge()
                        .Range(.Cells(nfilainiagru, 6), .Cells(nfilaultagru, 6)).Merge()
                        .Range(.Cells(nfilainiagru, 10), .Cells(nfilaultagru, 10)).Merge()
                        .Range(.Cells(nfilainiagru, 14), .Cells(nfilaultagru, 14)).Merge()
                        .Range(.Cells(nfilainiagru, 9), .Cells(nfilaultagru, 9)).Merge()
                        .Range(.Cells(nfilainiagru, 13), .Cells(nfilaultagru, 13)).Merge()
                        .Range(.Cells(nfilainiagru, 17), .Cells(nfilaultagru, 17)).Merge()
                        '.Range(.Cells(ultFila, 9), .Cells(ultFila, 9)).Formula = "=SUMA(I5 : I" & ultFila - 1 & ")"
                        '.Range(.Cells(nfilainiagru, 18), .Cells(nfilaultagru, 18)).Merge()
                        '.Range(.Cells(nfilainiagru, 19), .Cells(nfilaultagru, 19)).Merge()
                        '.Range(.Cells(nfilainiagru, 20), .Cells(nfilaultagru, 20)).Merge()
                        .Range(.Cells(nfilainiagru, 8), .Cells(nfilaultagru, 8)).Merge()
                        .Range(.Cells(nfilainiagru, 12), .Cells(nfilaultagru, 12)).Merge()
                        .Range(.Cells(nfilainiagru, 16), .Cells(nfilaultagru, 16)).Merge()
                        For ini = nfilaultagru To nfilainiagru Step -1
                            .Range(.Cells(ini, 20), .Cells(ini, 20)).Formula = "=R" & ini & "/N" & nfilainiagru
                        Next
                        nfilainiagru = 5 + i
                        CODAGRUPACION = dtRuma.Rows(i)("CODAGRUPACION").ToString.Trim
                    End If
                    'For ini As Int32 = 1 To nfilaultagru - nfilainiagru - 1
                    '    .Range(.Cells(nfilainiagru - ini, 20), .Cells(nfilainiagru - ini, 20)).Formula = "=R" & 5 + i & "/N" & nfilainiagru - ini
                    'Next



                    If CODRUMA.Trim <> dtRuma.Rows(i)("CODRUMA").ToString.Trim Then
                        nfilault = 4 + i
                        .Range(.Cells(nfilaini, 1), .Cells(nfilault, 1)).Merge()
                        .Range(.Cells(nfilaini, 3), .Cells(nfilault, 3)).Merge()
                        nfilaini = 5 + i
                        CODRUMA = dtRuma.Rows(i)("CODRUMA").ToString.Trim
                        'correl += 1
                    End If

                    ultFila = i + 6
                Next

                .Range(.Cells(nfilaini, 1), .Cells(ultFila - 1, 1)).Merge()
                .Range(.Cells(nfilaini, 3), .Cells(ultFila - 1, 3)).Merge()
                .Range(.Cells(nfilainiagru, 2), .Cells(ultFila - 1, 2)).Merge()
                .Range(.Cells(nfilainiagru, 5), .Cells(ultFila - 1, 5)).Merge()
                .Range(.Cells(nfilainiagru, 6), .Cells(ultFila - 1, 6)).Merge()
                .Range(.Cells(nfilainiagru, 10), .Cells(ultFila - 1, 10)).Merge()
                .Range(.Cells(nfilainiagru, 14), .Cells(ultFila - 1, 14)).Merge()
                .Range(.Cells(nfilainiagru, 9), .Cells(ultFila - 1, 9)).Merge()
                .Range(.Cells(nfilainiagru, 13), .Cells(ultFila - 1, 13)).Merge()
                .Range(.Cells(nfilainiagru, 17), .Cells(ultFila - 1, 17)).Merge()
                '.Range(.Cells(nfilainiagru, 18), .Cells(ultFila - 1, 18)).Merge()
                '.Range(.Cells(nfilainiagru, 19), .Cells(ultFila - 1, 19)).Merge()
                '.Range(.Cells(nfilainiagru, 20), .Cells(ultFila - 1, 20)).Merge()
                .Range(.Cells(nfilainiagru, 8), .Cells(ultFila - 1, 8)).Merge()
                .Range(.Cells(nfilainiagru, 12), .Cells(ultFila - 1, 12)).Merge()
                .Range(.Cells(nfilainiagru, 16), .Cells(ultFila - 1, 16)).Merge()

                '.Range(.Cells(nfilaini, 19), .Cells(ultFila - 1, 19)).Merge()
                '.Range(.Cells(nfilaini, 20), .Cells(ultFila - 1, 20)).Merge()

                .Range(.Cells(ultFila, 4), .Cells(ultFila, 4)).Value = "TOTALES"
                .Range(.Cells(ultFila, 4), .Cells(ultFila, 20)).Font.Bold = True
                .Range(.Cells(ultFila, 4), .Cells(ultFila, 20)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(ultFila, 5), .Cells(ultFila, 5)).Formula = "=SUMA(E5 : E" & ultFila - 1 & ")"
                .Range(.Cells(ultFila, 6), .Cells(ultFila, 6)).Formula = "=SUMA(F5 : F" & ultFila - 1 & ")"
                .Range(.Cells(ultFila, 7), .Cells(ultFila, 7)).Formula = "=SUMA(G5 : G" & ultFila - 1 & ")"

                .Range(.Cells(ultFila, 9), .Cells(ultFila, 9)).Formula = "=SUMA(I5 : I" & ultFila - 1 & ")"
                .Range(.Cells(ultFila, 10), .Cells(ultFila, 10)).Formula = "=SUMA(J5 : J" & ultFila - 1 & ")"
                .Range(.Cells(ultFila, 13), .Cells(ultFila, 13)).Formula = "=SUMA(M5 : M" & ultFila - 1 & ")"
                .Range(.Cells(ultFila, 11), .Cells(ultFila, 11)).Formula = "=SUMA(K5 : K" & ultFila - 1 & ")"
                .Range(.Cells(ultFila, 14), .Cells(ultFila, 14)).Formula = "=SUMA(N5 : N" & ultFila - 1 & ")"
                .Range(.Cells(ultFila, 15), .Cells(ultFila, 15)).Formula = "=SUMA(O5 : O" & ultFila - 1 & ")"

                .Range(.Cells(ultFila, 8), .Cells(ultFila, 8)).Formula = "=G" & ultFila & " / E" & ultFila & ""
                .Range(.Cells(ultFila, 12), .Cells(ultFila, 12)).Formula = "=K" & ultFila & " / I" & ultFila & ""
                .Range(.Cells(ultFila, 16), .Cells(ultFila, 16)).Formula = "=O" & ultFila & " / M" & ultFila & ""
                .Range(.Cells(ultFila, 18), .Cells(ultFila, 18)).Formula = "=SUMA(R5 : R" & ultFila - 1 & ")"
                .Range(.Cells(ultFila, 19), .Cells(ultFila, 19)).Formula = "=SUMA(S5 : S" & ultFila - 1 & ")"
            End With
        Catch ex As Exception

        End Try
    End Sub
    Function nombreMEs(ByVal mes As Int32) As String
        Select Case mes
            Case 1
                Return "ENERO"
            Case 2
                Return "FEBRERO"
            Case 3
                Return "MARZO"
            Case 4
                Return "ABRIL"
            Case 5
                Return "MAYO"
            Case 6
                Return "JUNIO"
            Case 7
                Return "JULIO"
            Case 8
                Return "AGOSTO"
            Case 9
                Return "SETIEMBRE"
            Case 10
                Return "OCTUBRE"
            Case 11
                Return "NOVIEMBRE"
            Case Else
                Return "DICIEMBRE"
        End Select
        Return ""
    End Function
End Class