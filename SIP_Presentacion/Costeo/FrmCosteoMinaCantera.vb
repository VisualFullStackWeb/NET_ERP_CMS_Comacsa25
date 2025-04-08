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
Public Class FrmCosteoMinaCantera
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

    Private Sub txtcodcantera_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodcantera.KeyPress
        Try
            If flgaprobada = 1 Then Return
            Dim frm As New FrmCosto_ListaCantera
            frm.ShowDialog()
            If Not codProducto = "" Then
                txtcodcantera.Text = codProducto
                txtcantera.Text = Producto
                codProducto = ""
                Producto = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Reporte()
    End Sub

    Sub Reporte()
        'Dim m_Excel As Object = CreateObject("Excel.Application")
        If cmbMesDesde.Value Is Nothing Then
            MsgBox("Seleccione mes inicial", MsgBoxStyle.Information)
            Exit Sub
        End If
        If cmbMesHasta.Value Is Nothing Then
            MsgBox("Seleccione mes final", MsgBoxStyle.Information)
            Exit Sub
        End If
        If txtcodcantera.Text.ToString.Trim = "" Then
            MsgBox("Seleccione Producto", MsgBoxStyle.Information)
            Exit Sub
        End If
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtDatos As New DataTable
            If rsbdirectos.Checked = True Then
                Dim mes_ini As Int32 = cmbMesDesde.Value
                Dim mes_final As Int32 = cmbMesHasta.Value
                _objNegocio = New NGProducto
                _objEntidad = New ETProducto
                _objEntidad.Anho = txtayo.Value
                _objEntidad.Mes = cmbMesDesde.Value
                _objEntidad.Mes1 = cmbMesHasta.Value
                _objEntidad.Cod_Cantera = txtcodcantera.Text
                dtDatos = _objNegocio.Costo_RPT_MIN_CANTERA(_objEntidad)
            End If
            If rdbtotal.Checked = True Then
                dtDatos = New DataTable
                _objNegocio = New NGProducto
                _objEntidad = New ETProducto
                _objEntidad.Anho = txtayo.Value
                _objEntidad.Mes = cmbMesDesde.Value
                _objEntidad.Mes1 = cmbMesHasta.Value
                _objEntidad.Cod_Cantera = txtcodcantera.Text
                dtDatos = _objNegocio.Costo_RPT_MIN_CANTERA_T(_objEntidad)
            End If
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\RPT_COST_MINA_CANTERA_" & cmbMesDesde.Text.ToUpper & ".xls")
                File.Copy(path & "\RPT_COST_MINA_CANTERA.xls", path & "\RPT_COST_MINA_CANTERA_" & cmbMesDesde.Text.ToUpper & ".xls")
                m_Excel.Workbooks.Open(path & "\RPT_COST_MINA_CANTERA_" & cmbMesDesde.Text.ToUpper & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 6
                nfilaini = 6
                Dim filaultima As Int32 = 0
                With objHojaExcel
                    .Activate()
                    .Range("B2").Value = "COSTO DE MINAS CANTERA: " & txtcantera.Text
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        '.Range("A" & nfila + i).Value = dtDatos.Rows(i)("COD_PROD")
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("DESCRIPCION")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("ENERO")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("FEBRERO")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("MARZO")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("ABRIL")
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("MAYO")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("JUNIO")
                        .Range("I" & nfila + i).Value = dtDatos.Rows(i)("JULIO")
                        .Range("J" & nfila + i).Value = dtDatos.Rows(i)("AGOSTO")
                        .Range("K" & nfila + i).Value = dtDatos.Rows(i)("SETIEMBRE")
                        .Range("L" & nfila + i).Value = dtDatos.Rows(i)("OCTUBRE")
                        .Range("M" & nfila + i).Value = dtDatos.Rows(i)("NOVIEMBRE")
                        .Range("N" & nfila + i).Value = dtDatos.Rows(i)("DICIEMBRE")
                        .Range("R" & nfila + i).Value = dtDatos.Rows(i)("TOTAL_CANTERA")
                        If rsbdirectos.Checked = True Then
                            .Range("R5").Value = "TOTAL"
                            .Range("Q" & nfila + i).Value = "=R" & nfila + i & "-P" & nfila + i & ""
                        Else
                            .Range("R5").Value = "TOTAL CANTERA"
                            .Range("Q" & nfila + i).Value = "=P" & nfila + i & "-R" & nfila + i & ""
                        End If
                        If dtDatos.Rows(i)("FLAG") <> "D" And dtDatos.Rows(i)("FLAG") <> "I" Then
                            .Range("Q" & nfila + i).Value = 0
                        End If
                        If dtDatos.Rows(i)("FLAG") <> "D" And dtDatos.Rows(i)("FLAG") <> "I" Then
                            .Range("B" & nfila + i & ":" & "N" & nfila + i).Font.Bold = True
                        End If
                        .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range(.Cells(nfila + i, 16), .Cells(nfila + i, 19)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        '.Range(.Cells(nfila + i, 39), .Cells(nfila + i, 70)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        '.Range(.Cells(nfila + i, 72), .Cells(nfila + i, 73)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'nfila = nfila + 1
                        filaultima = nfila + i
                    Next
                End With
                'Dim nro_mes As Integer = cmbMesDesde.Value
                Dim letraini As String = letra(cmbMesDesde.Value)
                Dim letrafin As String = letra(cmbMesHasta.Value)
                objHojaExcel.Columns(letraini & ":" & letrafin).Hidden = False

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
    Function letra(ByVal nmes As Integer) As String
        Dim nletra As String = ""
        Select Case nmes
            Case 1
                nletra = "C"
            Case 2
                nletra = "D"
            Case 3
                nletra = "E"
            Case 4
                nletra = "F"
            Case 5
                nletra = "G"
            Case 6
                nletra = "H"
            Case 7
                nletra = "I"
            Case 8
                nletra = "J"
            Case 9
                nletra = "K"
            Case 10
                nletra = "L"
            Case 11
                nletra = "M"
            Case Else
                nletra = "N"
        End Select

        Return nletra
    End Function

    Private Sub FrmCosteoMinaCantera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Year(Now.Date)
        rsbdirectos.Checked = True
    End Sub

    Private Sub txtcodcantera_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodcantera.ValueChanged

    End Sub
End Class