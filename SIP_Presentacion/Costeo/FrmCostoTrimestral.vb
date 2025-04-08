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
Public Class FrmCostoTrimestral
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
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
    Private Sub FrmCostoTrimestral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
        cmbMes.Value = Now.Date.Month
    End Sub
    Sub Reporte()
        If rdbProducto.Checked = True Then
            Procesar_Producto()
        End If
        If rdbRuma.Checked = True Then
            Procesar_Ruma()
        End If
        If rdbManoobra.Checked = True Then
            Procesar_MO()
        End If
    End Sub

    Sub Procesar_MO()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_ReporteTrimestralMO(_objEntidad)

            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\COSTO_MENSUAL_MO_" & txtayo.Value & ".xls")
            File.Copy(RutaReporteERP & "PLANTILLA_COSTO_MO.xls", path & "\COSTO_MENSUAL_MO_" & txtayo.Value & ".xls")
            m_Excel.Workbooks.Open(path & "\COSTO_MENSUAL_MO_" & txtayo.Value & ".xls")
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)

            m_Excel.DisplayAlerts = False
            Dim nfila As Integer
            Dim nfilaini As Integer
            Dim nfilault As Integer = 0
            objHojaExcel.Range("A2").Value = "COSTO DE MANO DE OBRA POR PRODUCTO MENSUAL - " & txtayo.Value
            nfila = 6
            nfilaini = 6
            nfilaini = 6
            Dim filaultima As Int32 = 0
            With objHojaExcel
                .Activate()
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    .Range("A" & nfila + i).Value = dtDatos.Rows(i)("COD_PROD")
                    .Range("B" & nfila + i).Value = dtDatos.Rows(i)("PRODUCTO")
                    .Range("B" & nfila + i).WrapText = False
                    .Range("C" & nfila + i).Value = dtDatos.Rows(i)("TON_ENERO")
                    .Range("D" & nfila + i).Value = dtDatos.Rows(i)("ENERO")
                    .Range("E" & nfila + i).Value = dtDatos.Rows(i)("TON_FEBRERO")
                    .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FEBRERO")
                    .Range("G" & nfila + i).Value = dtDatos.Rows(i)("TON_MARZO")
                    .Range("H" & nfila + i).Value = dtDatos.Rows(i)("MARZO")
                    .Range("I" & nfila + i).Value = dtDatos.Rows(i)("TON_ABRIL")
                    .Range("J" & nfila + i).Value = dtDatos.Rows(i)("ABRIL")
                    .Range("K" & nfila + i).Value = dtDatos.Rows(i)("TON_MAYO")
                    .Range("L" & nfila + i).Value = dtDatos.Rows(i)("MAYO")
                    .Range("M" & nfila + i).Value = dtDatos.Rows(i)("TON_JUNIO")
                    .Range("N" & nfila + i).Value = dtDatos.Rows(i)("JUNIO")
                    .Range("O" & nfila + i).Value = dtDatos.Rows(i)("TON_JULIO")
                    .Range("P" & nfila + i).Value = dtDatos.Rows(i)("JULIO")
                    .Range("Q" & nfila + i).Value = dtDatos.Rows(i)("TON_AGOSTO")
                    .Range("R" & nfila + i).Value = dtDatos.Rows(i)("AGOSTO")
                    .Range("S" & nfila + i).Value = dtDatos.Rows(i)("TON_SETIEMBRE")
                    .Range("T" & nfila + i).Value = dtDatos.Rows(i)("SETIEMBRE")
                    .Range("U" & nfila + i).Value = dtDatos.Rows(i)("TON_OCTUBRE")
                    .Range("V" & nfila + i).Value = dtDatos.Rows(i)("OCTUBRE")
                    .Range("W" & nfila + i).Value = dtDatos.Rows(i)("TON_NOVIEMBRE")
                    .Range("X" & nfila + i).Value = dtDatos.Rows(i)("NOVIEMBRE")
                    .Range("Y" & nfila + i).Value = dtDatos.Rows(i)("TON_DICIEMBRE")
                    .Range("Z" & nfila + i).Value = dtDatos.Rows(i)("DICIEMBRE")
                    '.Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    filaultima = nfila + i
                Next
            End With
            m_Excel.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
            m_Excel.Quit()
        End Try
    End Sub

    Sub Procesar_Ruma()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_ReporteTrimestralRuma(_objEntidad)

            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\COSTO_MENSUAL_RUMA_" & txtayo.Value & ".xls")
            File.Copy(RutaReporteERP & "PLANTILLA_COSTO_RUMA.xls", path & "\COSTO_MENSUAL_RUMA_" & txtayo.Value & ".xls")
            m_Excel.Workbooks.Open(path & "\COSTO_MENSUAL_RUMA_" & txtayo.Value & ".xls")
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)

            m_Excel.DisplayAlerts = False
            Dim nfila As Integer
            Dim nfilaini As Integer
            Dim nfilault As Integer = 0
            objHojaExcel.Range("A2").Value = "COSTO DE RUMA MENSUAL - " & txtayo.Value
            nfila = 6
            nfilaini = 6
            nfilaini = 6
            Dim filaultima As Int32 = 0
            With objHojaExcel
                .Activate()
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    .Range("A" & nfila + i).Value = dtDatos.Rows(i)("CODRUMA")
                    .Range("B" & nfila + i).Value = dtDatos.Rows(i)("INSUMO")
                    .Range("B" & nfila + i).WrapText = False
                    .Range("C" & nfila + i).Value = dtDatos.Rows(i)("TON_ENERO")
                    .Range("D" & nfila + i).Value = dtDatos.Rows(i)("ENERO")
                    .Range("E" & nfila + i).Value = dtDatos.Rows(i)("TON_FEBRERO")
                    .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FEBRERO")
                    .Range("G" & nfila + i).Value = dtDatos.Rows(i)("TON_MARZO")
                    .Range("H" & nfila + i).Value = dtDatos.Rows(i)("MARZO")
                    .Range("I" & nfila + i).Value = dtDatos.Rows(i)("TON_ABRIL")
                    .Range("J" & nfila + i).Value = dtDatos.Rows(i)("ABRIL")
                    .Range("K" & nfila + i).Value = dtDatos.Rows(i)("TON_MAYO")
                    .Range("L" & nfila + i).Value = dtDatos.Rows(i)("MAYO")
                    .Range("M" & nfila + i).Value = dtDatos.Rows(i)("TON_JUNIO")
                    .Range("N" & nfila + i).Value = dtDatos.Rows(i)("JUNIO")
                    .Range("O" & nfila + i).Value = dtDatos.Rows(i)("TON_JULIO")
                    .Range("P" & nfila + i).Value = dtDatos.Rows(i)("JULIO")
                    .Range("Q" & nfila + i).Value = dtDatos.Rows(i)("TON_AGOSTO")
                    .Range("R" & nfila + i).Value = dtDatos.Rows(i)("AGOSTO")
                    .Range("S" & nfila + i).Value = dtDatos.Rows(i)("TON_SETIEMBRE")
                    .Range("T" & nfila + i).Value = dtDatos.Rows(i)("SETIEMBRE")
                    .Range("U" & nfila + i).Value = dtDatos.Rows(i)("TON_OCTUBRE")
                    .Range("V" & nfila + i).Value = dtDatos.Rows(i)("OCTUBRE")
                    .Range("W" & nfila + i).Value = dtDatos.Rows(i)("TON_NOVIEMBRE")
                    .Range("X" & nfila + i).Value = dtDatos.Rows(i)("NOVIEMBRE")
                    .Range("Y" & nfila + i).Value = dtDatos.Rows(i)("TON_DICIEMBRE")
                    .Range("Z" & nfila + i).Value = dtDatos.Rows(i)("DICIEMBRE")
                    '.Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    filaultima = nfila + i
                Next
            End With
            m_Excel.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
            m_Excel.Quit()
        End Try
    End Sub

    Sub Procesar_Producto()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_ReporteTrimestral(_objEntidad)
            'MsgBox(dtDatos.Rows.Count)
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\RPT_COST_TRIMESTRAL_" & cmbMes.Text.ToUpper & ".xls")
                File.Copy(path & "\RPT_COST_TRIMESTRAL.xls", path & "\RPT_COST_TRIMESTRAL_" & cmbMes.Text.ToUpper & ".xls")
                m_Excel.Workbooks.Open(path & "\RPT_COST_TRIMESTRAL_" & cmbMes.Text.ToUpper & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                Dim objHojaExcel_Trimestral As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 6
                nfilaini = 6
                Dim filaultima As Int32 = 0
                With objHojaExcel
                    .Activate()
                    '.Range("D2").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDatos.Rows(i)("COD_PROD")
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("PRODUCTO")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("TON_ENE_ANT")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("ENE_ANT")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("TON_FEB_ANT")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FEB_ANT")
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("TON_MAR_ANT")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("MAR_ANT")
                        .Range("I" & nfila + i).Value = "=+C" & nfila + i & "+E" & nfila + i & "+G" & nfila + i & ""
                        .Range("J" & nfila + i).Value = dtDatos.Rows(i)("PRI_TRI_ANT")
                        .Range("K" & nfila + i).Value = dtDatos.Rows(i)("TON_ABR_ANT")
                        .Range("L" & nfila + i).Value = dtDatos.Rows(i)("ABR_ANT")
                        .Range("M" & nfila + i).Value = dtDatos.Rows(i)("TON_MAY_ANT")
                        .Range("N" & nfila + i).Value = dtDatos.Rows(i)("MAY_ANT")
                        .Range("O" & nfila + i).Value = dtDatos.Rows(i)("TON_JUN_ANT")
                        .Range("P" & nfila + i).Value = dtDatos.Rows(i)("JUN_ANT")
                        .Range("Q" & nfila + i).Value = "=+K" & nfila + i & "+M" & nfila + i & "+O" & nfila + i & ""
                        .Range("R" & nfila + i).Value = dtDatos.Rows(i)("SEG_TRI_ANT")
                        .Range("S" & nfila + i).Value = dtDatos.Rows(i)("TON_JUL_ANT")
                        .Range("T" & nfila + i).Value = dtDatos.Rows(i)("JUL_ANT")
                        .Range("U" & nfila + i).Value = dtDatos.Rows(i)("TON_AGO_ANT")
                        .Range("V" & nfila + i).Value = dtDatos.Rows(i)("AGO_ANT")
                        .Range("W" & nfila + i).Value = dtDatos.Rows(i)("TON_SETI_ANT")
                        .Range("X" & nfila + i).Value = dtDatos.Rows(i)("SETI_ANT")
                        .Range("Y" & nfila + i).Value = "=+S" & nfila + i & "+U" & nfila + i & "+W" & nfila + i & ""
                        .Range("Z" & nfila + i).Value = dtDatos.Rows(i)("TER_TRI_ANT")
                        .Range("AA" & nfila + i).Value = dtDatos.Rows(i)("TON_OCT_ANT")
                        .Range("AB" & nfila + i).Value = dtDatos.Rows(i)("OCT_ANT")
                        .Range("AC" & nfila + i).Value = dtDatos.Rows(i)("TON_NOV_ANT")
                        .Range("AD" & nfila + i).Value = dtDatos.Rows(i)("NOV_ANT")
                        .Range("AE" & nfila + i).Value = dtDatos.Rows(i)("TON_DIC_ANT")
                        .Range("AF" & nfila + i).Value = dtDatos.Rows(i)("DIC_ANT")
                        .Range("AG" & nfila + i).Value = "=+AA" & nfila + i & "+AC" & nfila + i & "+AE" & nfila + i & ""
                        .Range("AH" & nfila + i).Value = dtDatos.Rows(i)("CUA_TRI_ANT")
                        .Range("AJ" & nfila + i).Value = "=+C" & nfila + i & "+E" & nfila + i & "+G" & nfila + i & "+K" & nfila + i & "+M" & nfila + i & "+O" & nfila + i & "+S" & nfila + i & "+U" & nfila + i & "+W" & nfila + i & "+AA" & nfila + i & "+AC" & nfila + i & "+AE" & nfila + i & "" 'TON PROM_GENERAL
                        .Range("AK" & nfila + i).Value = dtDatos.Rows(i)("PROM_GEN_ANT")


                        .Range("AM" & nfila + i).Value = dtDatos.Rows(i)("TON_ENE")
                        .Range("AN" & nfila + i).Value = dtDatos.Rows(i)("ENE")
                        .Range("AO" & nfila + i).Value = dtDatos.Rows(i)("TON_FEB")
                        .Range("AP" & nfila + i).Value = dtDatos.Rows(i)("FEB")
                        .Range("AQ" & nfila + i).Value = dtDatos.Rows(i)("TON_MAR")
                        .Range("AR" & nfila + i).Value = dtDatos.Rows(i)("MAR")
                        .Range("AS" & nfila + i).Formula = "=+AM" & nfila + i & "+AO" & nfila + i & "+AQ" & nfila + i & ""
                        .Range("AT" & nfila + i).Value = dtDatos.Rows(i)("PRI_TRI")
                        .Range("AU" & nfila + i).Value = dtDatos.Rows(i)("TON_ABR")
                        .Range("AV" & nfila + i).Value = dtDatos.Rows(i)("ABR")
                        .Range("AW" & nfila + i).Value = dtDatos.Rows(i)("TON_MAY")
                        .Range("AX" & nfila + i).Value = dtDatos.Rows(i)("MAY")
                        .Range("AY" & nfila + i).Value = dtDatos.Rows(i)("TON_JUN")
                        .Range("AZ" & nfila + i).Value = dtDatos.Rows(i)("JUN")
                        .Range("BA" & nfila + i).Value = "=+AU" & nfila + i & "+AW" & nfila + i & "+AY" & nfila + i & ""
                        .Range("BB" & nfila + i).Value = dtDatos.Rows(i)("SEG_TRI")
                        .Range("BC" & nfila + i).Value = dtDatos.Rows(i)("TON_JUL")
                        .Range("BD" & nfila + i).Value = dtDatos.Rows(i)("JUL")
                        .Range("BE" & nfila + i).Value = dtDatos.Rows(i)("TON_AGO")
                        .Range("BF" & nfila + i).Value = dtDatos.Rows(i)("AGO")
                        .Range("BG" & nfila + i).Value = dtDatos.Rows(i)("TON_SETI")
                        .Range("BH" & nfila + i).Value = dtDatos.Rows(i)("SETI")
                        .Range("BI" & nfila + i).Value = "=+BC" & nfila + i & "+BE" & nfila + i & "+BG" & nfila + i & ""
                        .Range("BJ" & nfila + i).Value = dtDatos.Rows(i)("TER_TRI")
                        .Range("BK" & nfila + i).Value = dtDatos.Rows(i)("TON_OCT")
                        .Range("BL" & nfila + i).Value = dtDatos.Rows(i)("OCT")
                        .Range("BM" & nfila + i).Value = dtDatos.Rows(i)("TON_NOV")
                        .Range("BN" & nfila + i).Value = dtDatos.Rows(i)("NOV")
                        .Range("BO" & nfila + i).Value = dtDatos.Rows(i)("TON_DIC")
                        .Range("BP" & nfila + i).Value = dtDatos.Rows(i)("DIC")
                        .Range("BQ" & nfila + i).Value = "=+BK" & nfila + i & "+BM" & nfila + i & "+BO" & nfila + i & ""
                        .Range("BR" & nfila + i).Value = dtDatos.Rows(i)("CUA_TRI")
                        .Range("BT" & nfila + i).Value = "=+AM" & nfila + i & "+AO" & nfila + i & "+AQ" & nfila + i & "+AU" & nfila + i & "+AW" & nfila + i & "+AY" & nfila + i & "+BC" & nfila + i & "+BE" & nfila + i & "+BG" & nfila + i & "+BK" & nfila + i & "+BM" & nfila + i & "+BO" & nfila + i & "" 'TON PROM_GENERAL
                        '.Range(.Cells(filaultima + 1, 13), .Cells(filaultima + 1, 13)).Formula = "=SUMA(M14:M" & filaultima & ")"
                        .Range("BU" & nfila + i).Value = dtDatos.Rows(i)("PROM_GEN")
                        .Range("BV" & nfila + i).Value = dtDatos.Rows(i)("VARIACION_SOLES")
                        .Range("BW" & nfila + i).Value = dtDatos.Rows(i)("VARIACION_PORCENTAJE")

                        .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 37)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range(.Cells(nfila + i, 39), .Cells(nfila + i, 70)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range(.Cells(nfila + i, 72), .Cells(nfila + i, 75)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nfila = nfila + 1
                        filaultima = nfila + i
                    Next
                End With
                Dim nro_mes As Integer = cmbMes.Value
                Select Case nro_mes
                    Case 1
                        objHojaExcel.Columns("AO:BR").Hidden = True
                    Case 2
                        objHojaExcel.Columns("AQ:BR").Hidden = True
                    Case 3
                        objHojaExcel.Columns("AU:BR").Hidden = True
                    Case 4
                        objHojaExcel.Columns("AW:BR").Hidden = True
                    Case 5
                        objHojaExcel.Columns("AY:BR").Hidden = True
                    Case 6
                        objHojaExcel.Columns("BC:BR").Hidden = True
                    Case 7
                        objHojaExcel.Columns("BE:BR").Hidden = True
                    Case 8
                        objHojaExcel.Columns("BG:BR").Hidden = True
                    Case 9
                        objHojaExcel.Columns("BK:BR").Hidden = True
                    Case 10
                        objHojaExcel.Columns("BM:BR").Hidden = True
                    Case 11
                        objHojaExcel.Columns("BO:BR").Hidden = True
                End Select

                ''COSTOS TRIMESTRALES

                nfila = 6
                nfilaini = 6
                filaultima = 0
                With objHojaExcel_Trimestral
                    '.Activate()
                    '.Range("D2").Value = "COSTOS DE PRODUCCION " & cmbMes.Text & " - " & txtayo.Value & ""
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDatos.Rows(i)("COD_PROD")
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("PRODUCTO")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("TON_ENE_ANT")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("ENE_ANT")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("TON_FEB_ANT")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FEB_ANT")
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("TON_MAR_ANT")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("MAR_ANT")
                        .Range("I" & nfila + i).Value = "=+C" & nfila + i & "+E" & nfila + i & "+G" & nfila + i & ""
                        .Range("J" & nfila + i).Value = dtDatos.Rows(i)("PRI_TRI_ANT")
                        .Range("K" & nfila + i).Value = dtDatos.Rows(i)("TON_ABR_ANT")
                        .Range("L" & nfila + i).Value = dtDatos.Rows(i)("ABR_ANT")
                        .Range("M" & nfila + i).Value = dtDatos.Rows(i)("TON_MAY_ANT")
                        .Range("N" & nfila + i).Value = dtDatos.Rows(i)("MAY_ANT")
                        .Range("O" & nfila + i).Value = dtDatos.Rows(i)("TON_JUN_ANT")
                        .Range("P" & nfila + i).Value = dtDatos.Rows(i)("JUN_ANT")
                        .Range("Q" & nfila + i).Value = "=+K" & nfila + i & "+M" & nfila + i & "+O" & nfila + i & ""
                        .Range("R" & nfila + i).Value = dtDatos.Rows(i)("SEG_TRI_ANT")
                        .Range("S" & nfila + i).Value = dtDatos.Rows(i)("TON_JUL_ANT")
                        .Range("T" & nfila + i).Value = dtDatos.Rows(i)("JUL_ANT")
                        .Range("U" & nfila + i).Value = dtDatos.Rows(i)("TON_AGO_ANT")
                        .Range("V" & nfila + i).Value = dtDatos.Rows(i)("AGO_ANT")
                        .Range("W" & nfila + i).Value = dtDatos.Rows(i)("TON_SETI_ANT")
                        .Range("X" & nfila + i).Value = dtDatos.Rows(i)("SETI_ANT")
                        .Range("Y" & nfila + i).Value = "=+S" & nfila + i & "+U" & nfila + i & "+W" & nfila + i & ""
                        .Range("Z" & nfila + i).Value = dtDatos.Rows(i)("TER_TRI_ANT")
                        .Range("AA" & nfila + i).Value = dtDatos.Rows(i)("TON_OCT_ANT")
                        .Range("AB" & nfila + i).Value = dtDatos.Rows(i)("OCT_ANT")
                        .Range("AC" & nfila + i).Value = dtDatos.Rows(i)("TON_NOV_ANT")
                        .Range("AD" & nfila + i).Value = dtDatos.Rows(i)("NOV_ANT")
                        .Range("AE" & nfila + i).Value = dtDatos.Rows(i)("TON_DIC_ANT")
                        .Range("AF" & nfila + i).Value = dtDatos.Rows(i)("DIC_ANT")
                        .Range("AG" & nfila + i).Value = "=+AA" & nfila + i & "+AC" & nfila + i & "+AE" & nfila + i & ""
                        .Range("AH" & nfila + i).Value = dtDatos.Rows(i)("CUA_TRI_ANT")
                        .Range("AJ" & nfila + i).Value = "=+C" & nfila + i & "+E" & nfila + i & "+G" & nfila + i & "+K" & nfila + i & "+M" & nfila + i & "+O" & nfila + i & "+S" & nfila + i & "+U" & nfila + i & "+W" & nfila + i & "+AA" & nfila + i & "+AC" & nfila + i & "+AE" & nfila + i & "" 'TON PROM_GENERAL
                        .Range("AK" & nfila + i).Value = dtDatos.Rows(i)("PROM_GEN_ANT")


                        .Range("AM" & nfila + i).Value = dtDatos.Rows(i)("TON_ENE")
                        .Range("AN" & nfila + i).Value = dtDatos.Rows(i)("ENE")
                        .Range("AO" & nfila + i).Value = dtDatos.Rows(i)("TON_FEB")
                        .Range("AP" & nfila + i).Value = dtDatos.Rows(i)("FEB")
                        .Range("AQ" & nfila + i).Value = dtDatos.Rows(i)("TON_MAR")
                        .Range("AR" & nfila + i).Value = dtDatos.Rows(i)("MAR")
                        .Range("AS" & nfila + i).Formula = "=+AM" & nfila + i & "+AO" & nfila + i & "+AQ" & nfila + i & ""
                        .Range("AT" & nfila + i).Value = dtDatos.Rows(i)("PRI_TRI")
                        .Range("AU" & nfila + i).Value = dtDatos.Rows(i)("TON_ABR")
                        .Range("AV" & nfila + i).Value = dtDatos.Rows(i)("ABR")
                        .Range("AW" & nfila + i).Value = dtDatos.Rows(i)("TON_MAY")
                        .Range("AX" & nfila + i).Value = dtDatos.Rows(i)("MAY")
                        .Range("AY" & nfila + i).Value = dtDatos.Rows(i)("TON_JUN")
                        .Range("AZ" & nfila + i).Value = dtDatos.Rows(i)("JUN")
                        .Range("BA" & nfila + i).Value = "=+AU" & nfila + i & "+AW" & nfila + i & "+AY" & nfila + i & ""
                        .Range("BB" & nfila + i).Value = dtDatos.Rows(i)("SEG_TRI")
                        .Range("BC" & nfila + i).Value = dtDatos.Rows(i)("TON_JUL")
                        .Range("BD" & nfila + i).Value = dtDatos.Rows(i)("JUL")
                        .Range("BE" & nfila + i).Value = dtDatos.Rows(i)("TON_AGO")
                        .Range("BF" & nfila + i).Value = dtDatos.Rows(i)("AGO")
                        .Range("BG" & nfila + i).Value = dtDatos.Rows(i)("TON_SETI")
                        .Range("BH" & nfila + i).Value = dtDatos.Rows(i)("SETI")
                        .Range("BI" & nfila + i).Value = "=+BC" & nfila + i & "+BE" & nfila + i & "+BG" & nfila + i & ""
                        .Range("BJ" & nfila + i).Value = dtDatos.Rows(i)("TER_TRI")
                        .Range("BK" & nfila + i).Value = dtDatos.Rows(i)("TON_OCT")
                        .Range("BL" & nfila + i).Value = dtDatos.Rows(i)("OCT")
                        .Range("BM" & nfila + i).Value = dtDatos.Rows(i)("TON_NOV")
                        .Range("BN" & nfila + i).Value = dtDatos.Rows(i)("NOV")
                        .Range("BO" & nfila + i).Value = dtDatos.Rows(i)("TON_DIC")
                        .Range("BP" & nfila + i).Value = dtDatos.Rows(i)("DIC")
                        .Range("BQ" & nfila + i).Value = "=+BK" & nfila + i & "+BM" & nfila + i & "+BO" & nfila + i & ""
                        .Range("BR" & nfila + i).Value = dtDatos.Rows(i)("CUA_TRI")
                        .Range("BT" & nfila + i).Value = "=+AM" & nfila + i & "+AO" & nfila + i & "+AQ" & nfila + i & "+AU" & nfila + i & "+AW" & nfila + i & "+AY" & nfila + i & "+BC" & nfila + i & "+BE" & nfila + i & "+BG" & nfila + i & "+BK" & nfila + i & "+BM" & nfila + i & "+BO" & nfila + i & "" 'TON PROM_GENERAL
                        '.Range(.Cells(filaultima + 1, 13), .Cells(filaultima + 1, 13)).Formula = "=SUMA(M14:M" & filaultima & ")"
                        .Range("BU" & nfila + i).Value = dtDatos.Rows(i)("PROM_GEN")
                        .Range("BV" & nfila + i).Value = dtDatos.Rows(i)("VARIACION_SOLES")
                        .Range("BW" & nfila + i).Value = dtDatos.Rows(i)("VARIACION_PORCENTAJE")

                        .Range(.Cells(nfila + i, 1), .Cells(nfila + i, 37)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range(.Cells(nfila + i, 39), .Cells(nfila + i, 70)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range(.Cells(nfila + i, 72), .Cells(nfila + i, 75)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nfila = nfila + 1
                        filaultima = nfila + i
                    Next
                End With
                nro_mes = cmbMes.Value
                Select Case nro_mes
                    Case 1
                        objHojaExcel_Trimestral.Columns("AO:BR").Hidden = True
                    Case 2
                        objHojaExcel_Trimestral.Columns("AQ:BR").Hidden = True
                    Case 3
                        objHojaExcel_Trimestral.Columns("AU:BR").Hidden = True
                    Case 4
                        objHojaExcel_Trimestral.Columns("AW:BR").Hidden = True
                    Case 5
                        objHojaExcel_Trimestral.Columns("AY:BR").Hidden = True
                    Case 6
                        objHojaExcel_Trimestral.Columns("BC:BR").Hidden = True
                    Case 7
                        objHojaExcel_Trimestral.Columns("BE:BR").Hidden = True
                    Case 8
                        objHojaExcel_Trimestral.Columns("BG:BR").Hidden = True
                    Case 9
                        objHojaExcel_Trimestral.Columns("BK:BR").Hidden = True
                    Case 10
                        objHojaExcel_Trimestral.Columns("BM:BR").Hidden = True
                    Case 11
                        objHojaExcel_Trimestral.Columns("BO:BR").Hidden = True
                End Select

                m_Excel.Visible = True
            End If
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

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged

    End Sub
End Class