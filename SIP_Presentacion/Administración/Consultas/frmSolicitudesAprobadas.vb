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
Public Class frmSolicitudesAprobadas
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private TipoG As sTate
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
    Dim esDevolucion As Int32 = 0
#End Region
    Dim DtAnulada As DataTable
    Dim DtDetalleAplicacion As DataTable
    Sub Procesar()

        Dim fecha1 As Date = dtFecha.Value
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DsConsulta As DataSet = Nothing
        Dim DtListado As DataTable = Nothing
        DtAnulada = New DataTable
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .Fecha = dtFecha.Value
                .User_Crea = User_Sistema
            End With
            DsConsulta = oPrvFisN.SolicitudAprobada(oPrvFisE)
            DtListado = DsConsulta.Tables(0)
            DtAnulada = DsConsulta.Tables(1)
            DtDetalleAplicacion = DsConsulta.Tables(2)
            Call CargarUltraGridxBinding(Grid1, Source1, DtListado)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

        End Try
    End Sub

    Private Sub frmSolicitudesAprobadas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Procesar()
    End Sub

    Private Sub btnSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSolicitud.Click
        Try
            If Grid1.ActiveRow Is Nothing Then MsgBox("Debe seleccionar un registro", MsgBoxStyle.Information, msgComacsa) : Return
            nroSolicitud = Me.Grid1.ActiveRow.Cells("NUMSOLICITUD").Value.ToString
            If nroSolicitud.ToString.Trim = "" Then Return
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            StrucForm.FxRxSolicitud = New FrmSolicitud
            StrucForm.FxRxSolicitud.MdiParent = MdiParent
            StrucForm.FxRxSolicitud.Show()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
            'StrucForm.FxRxSolicitud.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiquidacion.Click
        Try
            If Grid1.ActiveRow Is Nothing Then MsgBox("Debe seleccionar un registro", MsgBoxStyle.Information, msgComacsa) : Return
            nroSolicitud = Me.Grid1.ActiveRow.Cells("NUMSOLICITUD").Value.ToString

            If Me.Grid1.ActiveRow.Cells("TIPO").Value.ToString.Trim = "DEVOLUCION EN EFECTIVO" Then
                MsgBox("No existe liquidación para devolución en efectivo", MsgBoxStyle.Information, msgComacsa) : Return
            End If

            If nroSolicitud.ToString.Trim = "" Then Return
            If Not Grid1.ActiveRow.Cells("NumSolicitud").Value.ToString.Substring(0, 4) = "PEND" Then
                esDevolucion = 0
            Else
                esDevolucion = 1
            End If
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            StrucForm.FxRxLiquidacion = New FrmRptLiquidacion
            StrucForm.FxRxLiquidacion.MdiParent = MdiParent
            StrucForm.FxRxLiquidacion.esDevolucion = esDevolucion
            StrucForm.FxRxLiquidacion.tiporeporte = 1
            StrucForm.FxRxLiquidacion.Show()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub Reporte()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            If Grid1.Rows.Count > 0 Then
                lblmensaje.Visible = True
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                lblmensaje.Update()
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\SOLITUDESAPROBADAS.xls")
                File.Copy(RutaReporteERP & "PLANTILLASOLICITUDESAPROBADAS.xls", path & "\SOLITUDESAPROBADAS.xls")
                m_Excel.Workbooks.Open(path & "\SOLITUDESAPROBADAS.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 13
                nfilaini = 13

                With objHojaExcel
                    .Activate()
                    .Range("A2").Value = "SOLITUDES APROBADAS AL " & dtfecha.Value.ToString("dd/MM/yyyy")
                    .Range("A2").Font.Bold = True
                    Dim filaultima As Int32 = 0
                    For i As Int16 = 0 To Grid1.Rows.Count - 1
                        .Range("A" & 5 + i).Value = Grid1.Rows(i).Cells("NUMSOLICITUD")
                        .Range("B" & 5 + i).Value = Grid1.Rows(i).Cells("NUMLIQUIDACION")
                        .Range("C" & 5 + i).Value = Grid1.Rows(i).Cells("TIPO")
                        .Range("D" & 5 + i).Value = Grid1.Rows(i).Cells("CODTRABAJADOR")
                        .Range("E" & 5 + i).Value = Grid1.Rows(i).Cells("TRABAJADOR")
                        .Range("F" & 5 + i).Value = Grid1.Rows(i).Cells("MOTIVO")
                        .Range("G" & 5 + i).Value = Grid1.Rows(i).Cells("TOTAL")
                        .Range(.Cells(5 + i, 1), .Cells(5 + i, 7)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfila + 1
                        filaultima = 5 + i
                    Next
                    .Range(.Cells(6, 1), .Cells(filaultima + 1, 7)).WrapText = False
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 6)).Value = "Total"
                    .Range(.Cells(filaultima + 1, 7), .Cells(filaultima + 1, 7)).Formula = "=SUMA(G5:G" & filaultima & ")"
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 7)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 7)).Font.Bold = True
                    .Range("A" & filaultima + 3).Value = "LIQUIDACIONES ANULADAS"
                    .Range(.Cells(filaultima + 3, 1), .Cells(filaultima + 3, 4)).Merge()
                    .Range(.Cells(filaultima + 3, 1), .Cells(filaultima + 4, 4)).Font.Bold = True
                    .Range(.Cells(filaultima + 3, 1), .Cells(filaultima + 4, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("A" & filaultima + 4).Value = "ITEM"
                    .Range("B" & filaultima + 4).Value = "Nª ANULADO"
                    .Range("C" & filaultima + 4).Value = "VOUCHER"
                    .Range("D" & filaultima + 4).Value = "NUEVO NUMERO"
                    If DtAnulada.Rows.Count > 0 Then
                        For x As Int32 = 0 To DtAnulada.Rows.Count - 1
                            .Range("A" & filaultima + 5 + x).Value = x + 1
                            .Range("B" & filaultima + 5 + x).Value = DtAnulada.Rows(x)("NUMERO")
                            .Range("C" & filaultima + 5 + x).Value = DtAnulada.Rows(x)("VOUCHER")
                            .Range("D" & filaultima + 5 + x).Value = DtAnulada.Rows(x)("NUEVO_NUMERO")
                            .Range(.Cells(filaultima + 5 + x, 1), .Cells(filaultima + 5 + x, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        Next
                    End If
                End With

                With objHojaExcelDetalle
                    '.Activate()
                    .Range("A2").Value = "DETALLE DE APLICACIONES AL " & dtfecha.Value.ToString("dd/MM/yyyy")
                    .Range("A2").Font.Bold = True
                    Dim filaultima As Int32 = 0

                    For i As Int16 = 0 To DtDetalleAplicacion.Rows.Count - 1
                        .Range("A" & 6 + i).Value = DtDetalleAplicacion.Rows(i)("NUMSOLICITUDLLEGA")
                        .Range("B" & 6 + i).Value = DtDetalleAplicacion.Rows(i)("NUMASIENTOLLEGA")
                        .Range("C" & 6 + i).Value = DtDetalleAplicacion.Rows(i)("NUMSOLICITUDSALE")
                        .Range("D" & 6 + i).Value = DtDetalleAplicacion.Rows(i)("NUMASIENTOSALE")
                        .Range("E" & 6 + i).Value = DtDetalleAplicacion.Rows(i)("MONTO")
                        .Range(.Cells(6 + i, 1), .Cells(6 + i, 5)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                        nfila = nfila + 1
                        filaultima = 6 + i
                    Next
                    '.Range(.Cells(6, 1), .Cells(filaultima + 1, 5)).WrapText = False
                    .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 4)).Value = "Total"
                    .Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 5)).Formula = "=SUBTOTALES(9;E5:E" & filaultima & ")"
                    .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 5)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 5)).Font.Bold = True
                End With

                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End Try
    End Sub

    Private Sub btnVerAsiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerAsiento.Click
        Try
            If Grid1.ActiveRow Is Nothing Then MsgBox("Debe seleccionar un registro", MsgBoxStyle.Information, msgComacsa) : Return
            nroSolicitud = Me.Grid1.ActiveRow.Cells("NUMSOLICITUD").Value.ToString
            Dim NUMASIENTO = Me.Grid1.ActiveRow.Cells("NUMASIENTO").Value.ToString
            If Me.Grid1.ActiveRow.Cells("TIPO").Value.ToString.Trim = "DEVOLUCION EN EFECTIVO" Then
                MsgBox("No existe asiento para devolución en efectivo", MsgBoxStyle.Information, msgComacsa) : Return
            End If
            If nroSolicitud.ToString.Trim = "" Then Return
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte de Asiento..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Dim frm As New Frm_RptAsientoEntregas
            frm.MdiParent = MdiParent
            frm.esDevolucion = esDevolucion
            frm.voucherconta = "0313" & NUMASIENTO.ToString.Trim
            frm.cgvoucher = ""
            frm.año = Year(dtfecha.Value)
            frm.mes = Month(dtfecha.Value)
            frm.Show()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        Catch ex As Exception

        End Try

    End Sub
End Class
