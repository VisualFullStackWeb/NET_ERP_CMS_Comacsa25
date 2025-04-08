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
Public Class FrmRendimientoxUnidad
    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Dim DtSFNAcional As DataTable = Nothing
    Dim DtSFExterior As DataTable = Nothing
    Dim DtSobrantes As DataTable = Nothing

    Dim DtOFNAcional As DataTable = Nothing
    Dim DtOFExterior As DataTable = Nothing
    Dim DtExploracion As DataTable = Nothing
    Dim DsDatos As DataSet
    Dim dtProduto As DataTable
    Dim dtReporte As DataTable

    Private Sub FrmRendimientoxUnidad_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub FrmRendimientoxUnidad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        Me.cmbMes.SelectedIndex = Now.Date.Month - 1
    End Sub
    Sub procesar()
        DsDatos = New DataSet
        dtProduto = New DataTable
        dtReporte = New DataTable
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
                .molino = "*"
                .User_Crea = User_Sistema
            End With
            DsDatos = oPrvFisN.ReporteRendimiento(oPrvFisE)
            dtReporte = DsDatos.Tables(0)
            dtProduto = DsDatos.Tables(0)
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
        If dtReporte.Rows.Count <= 0 Then
            MsgBox("No existen datos para el reporte", MsgBoxStyle.Information, "Comacsa")
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
            File.Delete(path & "\RENDIMIENTOXUNIDAD.xls")
            File.Copy(RutaReporteERP & "PLANTILLARENDIMIENTO.xls", path & "\RENDIMIENTOXUNIDAD.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\RENDIMIENTOXUNIDAD.xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcelIngreso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            'm_Excel.Visible = True
            exportarReporte(objHojaExcelIngreso)
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

            Dim nfila As Integer = 7
            Dim nfilaini As Integer = 7
            Dim nfilault As Integer = 0

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A2").Value = Me.cmbMes.Text.ToString.ToUpper & " " & txtAño.Value.ToString
                Dim nmes As Integer = 1
                For m As Int32 = 1 To cmbMes.Value
                    nmes = 6 * (m - 1)
                    If m Mod 2 = 0 Then
                        .Range(.Cells(4, 3 + nmes), .Cells(5, 8 + nmes)).Interior.Color = 14806254
                    Else
                        .Range(.Cells(4, 3 + nmes), .Cells(5, 8 + nmes)).Interior.Color = 15853276
                    End If
                    .Range(.Cells(5, 3 + nmes), .Cells(5, 3 + nmes)).Value = "Horas Trab."
                    .Range(.Cells(5, 4 + nmes), .Cells(5, 4 + nmes)).Value = "Ton."
                    .Range(.Cells(5, 5 + nmes), .Cells(5, 5 + nmes)).Value = "Tn x Hr"
                    .Range(.Cells(5, 6 + nmes), .Cells(5, 6 + nmes)).Value = "Dias Parada"
                    .Range(.Cells(5, 7 + nmes), .Cells(5, 7 + nmes)).Value = "Prom. Personas"
                    .Range(.Cells(5, 8 + nmes), .Cells(5, 8 + nmes)).Value = "Kw/Hr"
                    .Range(.Cells(4, 3 + nmes), .Cells(5, 8 + nmes)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(4, 3 + nmes), .Cells(5, 8 + nmes)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(4, 3 + nmes), .Cells(5, 8 + nmes)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(4, 3 + nmes), .Cells(4, 8 + nmes)).Value = nombreMEs(m)
                    .Range(.Cells(4, 3 + nmes), .Cells(5, 8 + nmes)).Font.Bold = True
                    .Range(.Cells(4, 3 + nmes), .Cells(4, 8 + nmes)).Merge()
                    .Range(.Cells(4, 3 + nmes), .Cells(5, 8 + nmes)).WrapText = True
                Next
                Dim mesProductoIni As Int32 = dtProduto.Rows(0)("NroMes")
                Dim mesProductoFin As Int32 = dtProduto.Rows(0)("NroMes")
                Dim mesProducto As Int32 = 0
                Dim acum As Int32 = 0
                If dtReporte.Rows.Count > 0 Then
                    .Range(.Cells(6, 2), .Cells(6, 2)).Value = dtProduto.Rows(0)("NombreEquipo")
                    .Range(.Cells(6, 2), .Cells(6, 2)).Font.Bold = True
                    Dim cont As Int32 = 0
                    For I As Int32 = 0 To dtProduto.Rows.Count - 1
                        If I > 0 Then
                            If dtProduto.Rows(I)("Producto") <> dtProduto.Rows(I - 1)("Producto") Then
                                mesProductoIni = dtProduto.Rows(I)("NroMes")
                            End If
                        End If
                        mesProducto = dtProduto.Rows(I)("NroMes")
                        mesProductoFin = dtProduto.Rows(I)("NroMes")
                        nmes = 6 * (mesProducto - 1)
                        If mesProductoIni <> mesProductoFin Then acum += 1
                        If I > 0 Then
                            If dtProduto.Rows(I)("NombreEquipo") <> dtProduto.Rows(I - 1)("NombreEquipo") Then
                                .Range(.Cells(7 + I + cont - acum, 2), .Cells(7 + I + cont - acum, 2)).Value = dtProduto.Rows(I)("NombreEquipo")
                                .Range(.Cells(7 + I + cont - acum, 2), .Cells(7 + I + cont - acum, 2)).Font.Bold = True
                                cont += 1
                            End If
                        End If
                        .Range(.Cells(7 + I + cont - acum, 2), .Cells(7 + I + cont - acum, 2)).Value = "      " & IIf(dtReporte.Rows(I)("Producto") = "", "** " & dtReporte.Rows(I)("NombreEquipo") & " **", dtReporte.Rows(I)("Producto"))
                        If dtReporte.Rows(I)("Producto") = "" Then
                            .Range(.Cells(7 + I + cont - acum, 2), .Cells(7 + I + cont - acum, 8 + nmes)).Interior.Color = 15853276 '16772300
                            .Range(.Cells(7 + I + cont - acum, 2), .Cells(7 + I + cont - acum, 8 + nmes)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            .Range(.Cells(7 + I + cont - acum, 2), .Cells(7 + I + cont - acum, 8 + nmes)).Font.Bold = True
                        End If
                        .Range(.Cells(7 + I + cont - acum, 3 + nmes), .Cells(7 + I + cont - acum, 3 + nmes)).Value = dtReporte.Rows(I)("HorasTrabajadas") '"Horas Trab."
                        .Range(.Cells(7 + I + cont - acum, 4 + nmes), .Cells(7 + I + cont - acum, 4 + nmes)).Value = dtReporte.Rows(I)("Ton") '"Ton."
                        .Range(.Cells(7 + I + cont - acum, 5 + nmes), .Cells(7 + I + cont - acum, 5 + nmes)).Value = dtReporte.Rows(I)("TnHr") '"Tn x Hr"
                        .Range(.Cells(7 + I + cont - acum, 6 + nmes), .Cells(7 + I + cont - acum, 6 + nmes)).Value = dtReporte.Rows(I)("NroDiasParada") '"Dias Parada"
                        .Range(.Cells(7 + I + cont - acum, 7 + nmes), .Cells(7 + I + cont - acum, 7 + nmes)).Value = dtReporte.Rows(I)("NroPromPersonas") '"Prom. Personas"
                        .Range(.Cells(7 + I + cont - acum, 8 + nmes), .Cells(7 + I + cont - acum, 8 + nmes)).Value = dtReporte.Rows(I)("Factor_KWH") '"Kw/Hr"
                    Next

                    Dim ultCol As Int32 = nmes
                End If

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