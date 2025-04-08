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
Imports System.Data
Imports System.Data.OleDb
Public Class frmRptControlPPago
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

    Private Sub frmRptControlPPago_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDesde.Value = Now.Date
        dtpHasta.Value = Now.Date
    End Sub
    Dim dtDetalle As DataTable
    Dim dtResumen As DataTable
    Sub Procesar()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtDatos As New DataSet
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.FechaInicio = dtpDesde.Value
            _objEntidad.FechaTerminacion = dtpHasta.Value
            Dim dsDatos As New DataSet
            dsDatos = _objNegocio.PP_RPT_CONTROL(_objEntidad)
            dtDetalle = New DataTable
            dtDetalle = dsDatos.Tables(0)
            gridReporte.DataSource = dtDetalle
            dtResumen = New DataTable
            dtResumen = dsDatos.Tables(1)
            gridReporte.DataBind()
            Reporte_excel()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub Reporte_excel()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()

            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\REPORTE_CONTROL_PP" & ".xls")
            File.Copy(RutaReporteERP & "\PLANTILLA_CONTROL_PP" & ".xls", path & "\REPORTE_CONTROL_PP" & ".xls")
            m_Excel.Workbooks.Open(path & "\REPORTE_CONTROL_PP" & ".xls")

            If dtDetalle.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()

                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilafin As Integer
                Dim nfilault As Integer = 0

                nfila = 9
                nfilaini = 9
                nfilafin = 9
                Dim codigo As String = ""
                Dim filaultima As Int32 = 0
                With objHojaExcel
                    .Activate()
                    .Range("E4").Value = CDate(dtpDesde.Value).ToString("dd/MM/yyyy")
                    .Range("E5").Value = CDate(dtpHasta.Value).ToString("dd/MM/yyyy")
                    'codigo = dtDetalle.Rows(0)("CODIGO")
                    For i As Int16 = 0 To dtDetalle.Rows.Count - 1
                        .Range("B" & nfila + i).Value = i + 1
                        .Range("C" & nfila + i).Value = dtDetalle.Rows(i)("COD_PROV")
                        .Range("D" & nfila + i).Value = dtDetalle.Rows(i)("RUC")
                        .Range("E" & nfila + i).Value = dtDetalle.Rows(i)("CODIGO")
                        .Range("F" & nfila + i).Value = dtDetalle.Rows(i)("RAZSOC")
                        .Range("G" & nfila + i).Value = dtDetalle.Rows(i)("TEA")
                        .Range("H" & nfila + i).Value = "=((G" & nfila + i & "+1)^(1/12))-1"
                        .Range("I" & nfila + i).Value = dtDetalle.Rows(i)("TED")
                        .Range("J" & nfila + i).Value = dtDetalle.Rows(i)("FECHA_DOC")
                        .Range("K" & nfila + i).Value = dtDetalle.Rows(i)("NRO_COMP")
                        .Range("L" & nfila + i).Value = dtDetalle.Rows(i)("TOTAL")
                        .Range("M" & nfila + i).Value = dtDetalle.Rows(i)("FECHA_RECEPCION")
                        .Range("N" & nfila + i).Value = dtDetalle.Rows(i)("FECHA_VTO")
                        .Range("O" & nfila + i).Value = dtDetalle.Rows(i)("FEC_CANCELA")
                        .Range("P" & nfila + i).Value = dtDetalle.Rows(i)("DIASADELANTO")
                        '.Range("P" & nfila + i).Value = dtDetalle.Rows(i)("IGV")
                        .Range("Q" & nfila + i).Value = dtDetalle.Rows(i)("NC")
                        .Range("R" & nfila + i).Value = dtDetalle.Rows(i)("DETRACCION")
                        .Range("S" & nfila + i).Value = dtDetalle.Rows(i)("EXCESO_PESO")
                        .Range("T" & nfila + i).Value = dtDetalle.Rows(i)("IMPORTE_NETO") '"=L" & nfila + i & "-Q" & nfila + i & "-R" & nfila + i & "-S" & nfila + i & "" 'dtDetalle.Rows(i)("IMPORTE_NETO")
                        .Range("U" & nfila + i).Value = dtDetalle.Rows(i)("DIAS_CREDITO")
                        .Range("V" & nfila + i).Value = dtDetalle.Rows(i)("FECHA_DESEMBOLSO")
                        .Range("W" & nfila + i).Value = dtDetalle.Rows(i)("DSCTO_NETO")
                        .Range("X" & nfila + i).Value = dtDetalle.Rows(i)("DSCTO_IGV")
                        .Range("Y" & nfila + i).Value = dtDetalle.Rows(i)("DSCTO_TOTAL")
                        .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 25)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        If i > 0 Then
                            If codigo <> dtDetalle.Rows(i)("CODIGO") Then
                                codigo = dtDetalle.Rows(i)("CODIGO")
                                nfilaini = nfila + i
                                nfilafin = nfila + i
                            Else
                                nfilafin = nfila + i
                            End If
                            .Range("C" & nfilaini & ":C" & nfilafin & "").Merge()
                            .Range("F" & nfilaini & ":F" & nfilafin & "").Merge()
                            .Range("W" & nfilaini & ":W" & nfilafin & "").Merge()
                            .Range("X" & nfilaini & ":X" & nfilafin & "").Merge()
                            .Range("Y" & nfilaini & ":Y" & nfilafin & "").Merge()
                        End If                       
                        'nfila = nfila + 1
                        filaultima = nfila + i
                    Next
                    .Range("K" & filaultima + 1).Value = "TOTALES"
                    .Range("L" & filaultima + 1).Value = "=SUMA(L9:L" & filaultima & ")"
                    .Range("Q" & filaultima + 1).Value = "=SUMA(Q9:Q" & filaultima & ")"
                    .Range("R" & filaultima + 1).Value = "=SUMA(R9:R" & filaultima & ")"
                    .Range("T" & filaultima + 1).Value = "=SUMA(T9:T" & filaultima & ")"
                    .Range("W" & filaultima + 1).Value = "=SUMA(W9:W" & filaultima & ")"
                    .Range("X" & filaultima + 1).Value = "=SUMA(X9:X" & filaultima & ")"
                    .Range("Y" & filaultima + 1).Value = "=SUMA(Y9:Y" & filaultima & ")"
                    .Range("T" & filaultima + 1).Interior.Color = 65535
                    .Range("W" & filaultima + 1).Interior.Color = 5296274
                    .Range(.Cells(filaultima + 1, 11), .Cells(filaultima + 1, 25)).Font.Bold = True
                    .Range(.Cells(filaultima + 1, 11), .Cells(filaultima + 1, 25)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                End With
            End If
            If dtResumen.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                path = Application.StartupPath

                Dim objHojaExcel2 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 9
                nfilaini = 9
                Dim filaultima As Int32 = 0
                Dim nfilafin As Integer

                nfila = 9
                nfilaini = 9
                nfilafin = 9
                Dim codigo As String = ""
                With objHojaExcel2
                    '.Activate()
                    '.Range("B4").Value = "CONTROL DE DESCUENTOS POR PRONTO PAGO DEL " & CDate(dtpDesde.Value).ToString("dd/MM/yyyy") & " AL " & CDate(dtpHasta.Value).ToString("dd/MM/yyyy") & ""
                    .Range("E4").Value = CDate(dtpDesde.Value).ToString("dd/MM/yyyy")
                    .Range("E5").Value = CDate(dtpHasta.Value).ToString("dd/MM/yyyy")
                    For i As Int16 = 0 To dtResumen.Rows.Count - 1
                        .Range("B" & nfila + i).Value = i + 1
                        .Range("C" & nfila + i).Value = dtResumen.Rows(i)("COD_PROV")
                        .Range("D" & nfila + i).Value = dtResumen.Rows(i)("RUC")
                        .Range("E" & nfila + i).Value = dtResumen.Rows(i)("CODIGO")
                        .Range("F" & nfila + i).Value = dtResumen.Rows(i)("RAZSOC")
                        .Range("G" & nfila + i).Value = dtResumen.Rows(i)("TEA")
                        .Range("H" & nfila + i).Value = "=((G" & nfila + i & "+1)^(1/12))-1"
                        .Range("I" & nfila + i).Value = dtResumen.Rows(i)("TED")
                        '.Range("J" & nfila + i).Value = dtResumen.Rows(i)("FECHA_DOC")
                        '.Range("K" & nfila + i).Value = dtResumen.Rows(i)("NRO_COMP")
                        .Range("J" & nfila + i).Value = dtResumen.Rows(i)("TOTAL")
                        '.Range("M" & nfila + i).Value = dtResumen.Rows(i)("FECHA_RECEPCION")
                        '.Range("N" & nfila + i).Value = dtResumen.Rows(i)("FECHA_VTO")
                        '.Range("O" & nfila + i).Value = dtResumen.Rows(i)("FEC_CANCELA")
                        '.Range("P" & nfila + i).Value = dtResumen.Rows(i)("DIASADELANTO")
                        ''.Range("P" & nfila + i).Value = dtDetalle.Rows(i)("IGV")
                        '.Range("Q" & nfila + i).Value = dtResumen.Rows(i)("TOTAL")
                        .Range("K" & nfila + i).Value = dtResumen.Rows(i)("NC")
                        .Range("L" & nfila + i).Value = dtResumen.Rows(i)("DETRACCION")
                        .Range("M" & nfila + i).Value = dtResumen.Rows(i)("EXCESO_PESO")
                        .Range("N" & nfila + i).Value = dtResumen.Rows(i)("IMPORTE_NETO") '"=J" & nfila + i & "-K" & nfila + i & "-L" & nfila + i & "-M" & nfila + i & "" 'dtResumen.Rows(i)("IMPORTE_NETO")
                        .Range("O" & nfila + i).Value = dtResumen.Rows(i)("FECHA_DESEMBOLSO")
                        .Range("P" & nfila + i).Value = dtResumen.Rows(i)("DSCTO_NETO")
                        .Range("Q" & nfila + i).Value = dtResumen.Rows(i)("DSCTO_IGV")
                        .Range("R" & nfila + i).Value = dtResumen.Rows(i)("DSCTO_TOTAL")
                        .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 18)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nfila = nfila + 1
                        filaultima = nfila + i
                        If i > 0 Then
                            If codigo <> dtDetalle.Rows(i)("CODIGO") Then
                                codigo = dtDetalle.Rows(i)("CODIGO")
                                nfilaini = nfila + i
                                nfilafin = nfila + i
                            Else
                                nfilafin = nfila + i
                            End If
                            .Range("C" & nfilaini & ":C" & nfilafin & "").Merge()
                            .Range("F" & nfilaini & ":F" & nfilafin & "").Merge()
                            .Range("P" & nfilaini & ":P" & nfilafin & "").Merge()
                            .Range("Q" & nfilaini & ":Q" & nfilafin & "").Merge()
                            .Range("R" & nfilaini & ":R" & nfilafin & "").Merge()
                        End If
                    Next
                    .Range("I" & filaultima + 1).Value = "TOTALES"
                    .Range("J" & filaultima + 1).Value = "=SUMA(J9:J" & filaultima & ")"
                    .Range("N" & filaultima + 1).Interior.Color = 65535
                    .Range("P" & filaultima + 1).Interior.Color = 5296274
                    .Range("K" & filaultima + 1).Value = "=SUMA(K9:K" & filaultima & ")"
                    .Range("L" & filaultima + 1).Value = "=SUMA(L9:L" & filaultima & ")"
                    .Range("N" & filaultima + 1).Value = "=SUMA(N9:N" & filaultima & ")"
                    .Range("P" & filaultima + 1).Value = "=SUMA(P9:P" & filaultima & ")"
                    .Range("Q" & filaultima + 1).Value = "=SUMA(Q9:Q" & filaultima & ")"
                    .Range("R" & filaultima + 1).Value = "=SUMA(R9:R" & filaultima & ")"
                    .Range(.Cells(filaultima + 1, 9), .Cells(filaultima + 1, 18)).Font.Bold = True
                    .Range(.Cells(filaultima + 1, 9), .Cells(filaultima + 1, 18)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                End With
            End If
            m_Excel.Visible = True
            'End If
            'Call CargarUltraGridxBinding(Me.gridRevision, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
            'MsgBox(ex.ToString)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

End Class