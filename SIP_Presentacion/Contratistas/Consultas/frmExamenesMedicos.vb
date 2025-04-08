Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class frmExamenesMedicos
#Region "Declarar Variables"
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
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
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
#End Region

    Private Sub frmExamenesMedicos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mes As Int32
        mes = Month(Now.Date)
        Dim fecha1 As Date
        fecha1 = "01/" & mes & "/" & Year(Now.Date)
        dtpDesde.Value = fecha1
        dtpHasta.Value = Now.Date
    End Sub
    Sub limpiar()
        txtcodcantera.Clear()
        txtcantera.Clear()
        txtidcontratista.Text = 0
    End Sub
    Sub Buscar()
        'If Me.TabMaestroEntregas.Tabs("Lista").Selected = True Then Exit Sub
        Dim tipo As String = "C"
        If txtcodcontratista.Focused = True Then
            If Ope = 2 Then Exit Sub
            limpiar()
            Dim frm As New frmBuscarContratista
            frm.tipo = tipo
            frm.ShowDialog()
            txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            txtcodcontratista.Text = frm.gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            txtcontratista.Text = frm.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            Dim idtipopago As String = frm.gridcontratista.ActiveRow.Cells("TIPOPAGO").Value
            Dim idfrecuenia As Int32 = frm.gridcontratista.ActiveRow.Cells("IDFRECPAGO").Value
            If tipo = "PR" Then
                txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            End If
        End If
        If txtcodcantera.Focused = True Then
            If txtcodcontratista.Text.Trim = "" Then
                MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            limpiar()
            Dim frm As New frmBuscarCantera
            frm.codprov = txtcodcontratista.Text
            frm.ShowDialog()
            txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            txtcodcantera.Text = frm.gridcontratista.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcantera.Text = frm.gridcontratista.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
            'btnCanteras.Visible = True
        End If

    End Sub
    Sub PROCESAR()
        CargarDatos()
    End Sub
    Sub REPORTE()
        CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Try
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista

            Dim dtExMedico As New DataTable
            Entidad.Contratista._codprov = IIf(txtcodcontratista.Text <> "", txtcodcontratista.Text, "*")
            Entidad.Contratista._fecha1 = dtpDesde.Value
            Entidad.Contratista._fecha2 = dtpHasta.Value
            dtExMedico = Negocio.NContratista.RptExMedico_CTR(Entidad.Contratista)
            If dtExMedico.Rows.Count <= 0 And dtExMedico.Rows.Count <= 0 Then
                MsgBox("No existen datos para mostrar", MsgBoxStyle.Information, msgComacsa)
                Exit Sub
            End If
            imprimir(dtExMedico)
            'Call CargarUltraGridxBinding(Me.GridAnticipo, Source1, dtDatos)
        Catch ex As Exception
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End Try

    End Sub
    Sub imprimir(ByVal dtExMedico As DataTable)
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\RPT_EXAMENMEDICO_" & txtcodcontratista.Text.Trim & ".xls")
            File.Copy(RutaReporteERP & "PLANTILLAEXAMENMEDICO.xls", path & "\RPT_EXAMENMEDICO_" & txtcodcontratista.Text.Trim & ".xls")
            m_Excel.Workbooks.Open(path & "\RPT_EXAMENMEDICO_" & txtcodcontratista.Text.Trim & ".xls")
            m_Excel.DisplayAlerts = False

            If dtExMedico.Rows.Count > 0 Then
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                Dim nfila As Integer
                nfila = 0
                With objHojaExcel
                    For i As Int16 = 0 To dtExMedico.Rows.Count - 1
                        Dim nfilaini As Integer
                        Dim nfilault As Integer = 0
                        nfilaini = 7
                        .Activate()
                        .Range("B" & nfilaini + i).Value = dtExMedico.Rows(i)("ITEM")
                        .Range("C" & nfilaini + i).Value = dtExMedico.Rows(i)("CLINICA")
                        .Range("D" & nfilaini + i).Value = dtExMedico.Rows(i)("EMPRESA")
                        .Range("E" & nfilaini + i).Value = dtExMedico.Rows(i)("FECHA_FACTURA")
                        .Range("F" & nfilaini + i).Value = dtExMedico.Rows(i)("NUMFACTURA")
                        .Range("G" & nfilaini + i).Value = dtExMedico.Rows(i)("MONTO")
                        .Range("H" & nfilaini + i).Value = dtExMedico.Rows(i)("FECHA_ANTICIPO")
                        '.Range("I" & nfilaini + i).Value = dtExMedico.Rows(i)("FECHA_DEPOSITO")
                        '.Range("J" & nfilaini + i).Value = dtExMedico.Rows(i)("IMPORTE")
                        '.Range("J" & nfilaini + i).Value = dtExMedico.Rows(i)("IMPORTE")
                        '.Range("J" & nfilaini + i).Value = dtExMedico.Rows(i)("IMPORTE")
                        '.Range("J" & nfilaini + i).Value = dtExMedico.Rows(i)("IMPORTE")
                        '.Range("J" & nfilaini + i).Value = dtExMedico.Rows(i)("IMPORTE")
                        .Range(.Cells(nfilaini + i, 2), .Cells(nfilaini + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfilaini + i
                    Next
                    .Range("G" & nfila + 2).Value = "=SUMA(G7:G" & nfila & ")"
                    .Range("G" & nfila + 2).Font.Bold = True
                    .Range("G" & nfila + 2).NumberFormat = "###,##0.00"
                    .Range("G" & nfila + 2).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("G" & nfila + 2).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                End With
            End If
            m_Excel.Visible = True
        Catch ex As Exception
            m_Excel.Quit()
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub txtcodcontratista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodcontratista.KeyDown
        If e.KeyData = Keys.Back Or e.KeyData = 46 Then
            txtcodcontratista.Text = ""
            txtcontratista.Text = ""
        End If
    End Sub
End Class