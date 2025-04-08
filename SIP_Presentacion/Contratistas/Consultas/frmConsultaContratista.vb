Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class frmConsultaContratista
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
    Dim lResult As ETMyLista = Nothing
    Dim codbanco As String = ""
    Dim nrocta As String = ""
    Private Ls_Anticipo As List(Of ETContratista) = Nothing
    Private Ls_EntregaDetalle As List(Of ETContratista) = Nothing
    Dim x_mes As Int32 = 0
    Dim x_quincena As Int32 = 0
    Dim x_semanaini As Int32 = 0
    Dim x_semanafin As Int32 = 0
    Dim x_descripcion = ""
    Dim dtDatos As New DataTable

    Private Sub frmConsultaContratista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mes As Int32
        mes = Month(Now.Date)
        Dim fecha1 As Date
        fecha1 = "01/" & mes & "/" & Year(Now.Date)
        dtpDesde.Value = fecha1
        dtpHasta.Value = Now.Date
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
            codbanco = frm.gridcontratista.ActiveRow.Cells("CODBANCO").Value.ToString.Trim
            nrocta = frm.gridcontratista.ActiveRow.Cells("NROCTA").Value.ToString.Trim
            If tipo = "PR" Then
                txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            End If
            Procesar()
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
    Sub limpiar()
        txtcodcantera.Clear()
        txtcantera.Clear()
        txtidcontratista.Text = 0
    End Sub
    Sub Procesar()
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        Try
            lblmensaje.Visible = True
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Ls_Anticipo = Nothing
            Ls_Anticipo = New List(Of ETContratista)
            Ls_EntregaDetalle = Nothing
            Ls_EntregaDetalle = New List(Of ETContratista)
            Entidad.Contratista._codprov = txtcodcontratista.Text
            Entidad.Contratista._fecha1 = dtpDesde.Value
            Entidad.Contratista._fecha2 = dtpHasta.Value
            dtDatos = Negocio.NContratista.ConsultaContratista(Entidad.Contratista)
            Call CargarUltraGridxBinding(Me.GridAnticipo, Source1, dtDatos)
        Catch ex As Exception
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End Try

    End Sub
    Sub Reporte()
        If GridAnticipo.Rows.Count <= 0 Then
            MsgBox("No existen datos para exportar", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
        End If
        Try
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            ReporteGeneral()
        Catch ex As Exception
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End Try
    End Sub

    Sub ReporteGeneral()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            If dtDatos.Rows.Count > 0 Then

                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\CONSULTA_" & txtcodcontratista.Text.Trim & ".xls")
                File.Copy(RutaReporteERP & "PLANTILLATARJETACONTRATISTA.xls", path & "\CONSULTA_" & txtcodcontratista.Text.Trim & ".xls")
                m_Excel.Workbooks.Open(path & "\CONSULTA_" & txtcodcontratista.Text.Trim & ".xls")
                Dim canteraini As String
                canteraini = dtDatos.Rows(0)("CODCANTERA").Trim
                Dim cont As Int32 = 0
                Dim id As Int32 = 2
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    Dim nfila As Integer
                    Dim nfilaini As Integer
                    Dim nfilault As Integer = 0
                    nfila = 10
                    nfilaini = 10
                    cont = cont + 1
                    If canteraini.Trim <> dtDatos.Rows(i)("CODCANTERA").Trim Then
                        id = id + 1
                        canteraini = dtDatos.Rows(i)("CODCANTERA").Trim
                        'MsgBox(dtDatos.Rows(i)("CODCANTERA").Trim)
                        nfila = 10
                        nfilaini = 10
                        cont = 1
                        m_Excel.Sheets(1).Select()
                        m_Excel.Sheets(1).Copy(Before:=m_Excel.Sheets(1))
                        m_Excel.Sheets(1).Select()
                        m_Excel.Sheets(1).Move(After:=m_Excel.Sheets(id))
                    End If

                    Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(id)
                    objHojaExcel.Name = dtDatos.Rows(i)("CANTERA")
                    m_Excel.DisplayAlerts = False

                    With objHojaExcel
                        .Activate()
                        .Range("A7").Value = txtcodcontratista.Text
                        .Range("B7").Value = dtDatos.Rows(i)("RUC")
                        .Range("D6").Value = txtcontratista.Text.Trim
                        .Range("D7").Value = "SUPERVISOR: " & dtDatos.Rows(i)("SUPERVISOR") & ""
                        '.Range("E8").Value = "CONTADOR: " & dtDatos.Rows(i)("CONTADOR") & ""
                        .Range("I10").Value = dtDatos.Rows(i)("SALDOINI")
                        .Range("F7").Value = dtDatos.Rows(i)("CANTERA")
                        .Range("G7").Value = ""
                        .Range("H7").Value = "" ' NOMBRE DE MINERAL (ES)
                        Dim filaultima As Int32 = 0
                        .Range("A" & nfilaini + cont).RowHeight = 20
                        .Range("A" & nfilaini + cont).Value = dtDatos.Rows(i)("FECHADEPOSITO")
                        '.Range("B" & nfilaini + cont).Value = dtDatos.Rows(i)("NUMSOLICITUD")
                        .Range("B" & nfilaini + cont).Value = dtDatos.Rows(i)("FORMA")
                        .Range("C" & nfilaini + cont).Value = dtDatos.Rows(i)("NUMSOLICITUD")
                        .Range("D" & nfilaini + cont).Value = dtDatos.Rows(i)("DESCRIPCION")
                        .Range("E" & nfilaini + cont).Value = dtDatos.Rows(i)("CANTMINERAL")
                        If dtDatos.Rows(i)("FORMA").ToString.Trim <> "CONSTANCIA" Then
                            .Range("F" & nfilaini + cont).Value = dtDatos.Rows(i)("DEBE")
                            .Range("G" & nfilaini + cont).Value = 0
                        Else
                            .Range("F" & nfilaini + cont).Value = 0
                            .Range("G" & nfilaini + cont).Value = dtDatos.Rows(i)("DEBE")
                        End If
                        .Range("H" & nfilaini + cont).Value = dtDatos.Rows(i)("HABER")
                        .Range("I" & nfilaini + cont).Value = "=I" & nfilaini + cont - 1 & "+F" & nfilaini + cont & "+G" & nfilaini + cont & "-H" & nfilaini + cont & ""
                        .Range(.Cells(nfilaini + cont, 1), .Cells(nfilaini + cont, 10)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                        nfila = nfila + 1
                        filaultima = nfilaini + i
                    End With
                Next
                m_Excel.Sheets(1).Select()
                m_Excel.ActiveWindow.SelectedSheets.Visible = False
                'Sheets("S2").Select()
                'ActiveWindow.SelectedSheets.Visible = False
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub txtcodcontratista_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodcontratista.ValueChanged

    End Sub
End Class