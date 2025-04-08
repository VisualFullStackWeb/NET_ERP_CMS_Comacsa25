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
Public Class FrmCapacidadCemento
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

    Private Sub FrmCapacidadCemento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtayo.Value = Year(Now.Date)
        Me.cmbMesDesde.Value = Month(Now.Date)
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Reporte()
    End Sub
    Sub Reporte()
        'Dim m_Excel As Object = CreateObject("Excel.Application")
        If cmbMesDesde.Value Is Nothing Then
            MsgBox("Seleccione mes", MsgBoxStyle.Information)
            Exit Sub
        End If

        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtDatos As New DataTable
            Dim dtDatosResumen As New DataTable
            Dim mes_ini As Int32 = cmbMesDesde.Value
            Dim mes_final As Int32 = cmbMesDesde.Value

            Dim dsDatos As New DataSet
            dtDatos = New DataTable
            dtDatosResumen = New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = mes_ini
            _objEntidad.Usuario = userLogin
            dsDatos = _objNegocio.CAPACIDAD_CEMENTO(_objEntidad)
            dtDatos = dsDatos.Tables(0)
            dtDatosResumen = dsDatos.Tables(1)
            'dtDatosResumen = dsDatos.Tables(1)
            If dtDatos.Rows.Count > 0 Or dtDatosResumen.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\CAPACIDAD_CEMENTO_" & cmbMesDesde.Text & ".xls")
                File.Copy(RutaReporteERP & "CAPACIDAD_CEMENTO.xls", path & "\CAPACIDAD_CEMENTO_" & cmbMesDesde.Text & ".xls")
                m_Excel.Workbooks.Open(path & "\CAPACIDAD_CEMENTO_" & cmbMesDesde.Text & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                'Dim objHojaExcelResumen As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 7
                nfilaini = 7
                nfilaini = 7
                Dim filaultima As Int32 = 0
                'Dim MODELO As String = dtDatos.Rows(0)("MODELO")
                With objHojaExcel
                    .Activate()
                    .Range("B4").Value = "(ENE. a " & cmbMesDesde.Text.ToString.Substring(0, 3).ToUpper & ". " & txtayo.Value & ")"
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("MODELO")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("PARADA")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("EFECTIVA")
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("OPTIMA")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("REAL")
                        filaultima = nfila + i
                    Next
                    .Range("B15").Value = "(ENE. a " & cmbMesDesde.Text.ToString.Substring(0, 3).ToUpper & ". " & txtayo.Value & ")"
                    nfila = 18
                    For i As Int16 = 0 To dtDatosResumen.Rows.Count - 1
                        .Range("B" & nfila + i).Value = dtDatosResumen.Rows(i)("MODELO")
                        .Range("D" & nfila + i).Value = dtDatosResumen.Rows(i)("PARADA")
                        .Range("E" & nfila + i).Value = dtDatosResumen.Rows(i)("EFECTIVA")
                        .Range("G" & nfila + i).Value = dtDatosResumen.Rows(i)("OPTIMA")
                        .Range("H" & nfila + i).Value = dtDatosResumen.Rows(i)("REAL")
                        filaultima = nfila + i
                    Next
                    '.Range("B" & filaultima + 2).Value = "TOTAL"
                    '.Range("E" & filaultima + 2).Value = "=SUMA(E" & nfila & ":E" & filaultima & ")"
                    '.Range("F" & filaultima + 2).Value = "=SUMA(F" & nfila & ":F" & filaultima & ")"
                    '.Range("I" & filaultima + 2).Value = "=SUMA(I" & nfila & ":I" & filaultima & ")"
                    '.Range("J" & filaultima + 2).Value = "=SUMA(J" & nfila & ":J" & filaultima & ")"
                    '.Cells.Range("B" & filaultima + 2 & ":J" & filaultima + 2).Font.Bold = True
                    '.Range("B" & filaultima + 2 & ":J" & filaultima + 2).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                End With

                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            'm_Excel.Quit()
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
End Class