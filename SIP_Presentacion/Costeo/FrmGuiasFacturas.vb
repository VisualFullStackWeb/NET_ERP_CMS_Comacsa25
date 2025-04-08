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
Public Class FrmGuiasFacturas
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

    Private Sub FrmGuiasFacturas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbMes.Value = Month(Now.Date)
        txtayo.Value = Year(Now.Date)
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtDatos As New DataTable
            Dim dtResumen As New DataTable
            Dim dtRuma As New DataTable
            Dim mes_ini As Int32 = cmbMes.Value
            dtDatos = New DataTable
            dtResumen = New DataTable
            dtRuma = New DataTable
            Dim dsData As New DataSet

            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMes.Value
            dsData = _objNegocio.Costo_RPT_GUIA_FACTURA(_objEntidad)
            dtDatos = dsData.Tables(0)
            Dim n_fila As Int32 = 9

            Dim n_fila_ini As Int32 = 0
            Dim n_fila_fin As Int32 = 0

            Dim fgl_cab As Int32 = 0
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\GUIA_FACTURA" & cmbMes.Text.Trim.ToUpper & "_" & txtayo.Value & ".xls")
                File.Copy(RutaReporteERP & "PLANTILLAGUIAFACTURA.xls", path & "\GUIA_FACTURA" & cmbMes.Text.Trim.ToUpper & "_" & txtayo.Value & ".xls")
                m_Excel.Workbooks.Open(path & "\GUIA_FACTURA" & cmbMes.Text.Trim.ToUpper & "_" & txtayo.Value & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                'Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 6
                Dim cod_matprima_sig As String = ""
                Dim filaultima As Int32 = 0
                'm_Excel.Visible = True
                With objHojaExcel
                    .Activate()
                    .Range("C2").Value = "RELACION DE GUIAS POR FACTURA " & cmbMes.Text.ToString.ToUpper
                    Dim col As Int32 = 4
                    Dim fila_D As Integer = 0
                    Dim fila_I As Integer = 0
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        n_fila = nfila
                        .Range("A" & n_fila + i).Value = dtDatos.Rows(i)("REG_COMP")
                        .Range("B" & n_fila + i).Value = dtDatos.Rows(i)("COD_PROV")
                        .Range("C" & n_fila + i).Value = dtDatos.Rows(i)("TIPO_DOC")
                        .Range("D" & n_fila + i).Value = dtDatos.Rows(i)("NUM_DOC")
                        .Range("E" & n_fila + i).Value = dtDatos.Rows(i)("RAZSOC")
                        .Range("F" & n_fila + i).Value = dtDatos.Rows(i)("VALOR_VTA")
                        .Range("G" & n_fila + i).Value = dtDatos.Rows(i)("COD_CLI")
                        .Range("H" & n_fila + i).Value = dtDatos.Rows(i)("CLIENTE")
                        .Range("I" & n_fila + i).Value = dtDatos.Rows(i)("TIPO_COMPROB")
                        .Range("J" & n_fila + i).Value = dtDatos.Rows(i)("NUMDOC")
                        .Range("K" & n_fila + i).Value = dtDatos.Rows(i)("VALOR_VTA_CLI")
                        .Range("L" & n_fila + i).Value = dtDatos.Rows(i)("TIPO_DOC_CLI")
                        .Range("M" & n_fila + i).Value = dtDatos.Rows(i)("GUIA")
                        .Range("N" & n_fila + i).Value = dtDatos.Rows(i)("ITEM")
                        .Range("O" & n_fila + i).Value = dtDatos.Rows(i)("COD_PROD")
                        .Range("P" & n_fila + i).Value = dtDatos.Rows(i)("DESCRIP")
                        .Range("Q" & n_fila + i).Value = dtDatos.Rows(i)("UNID")
                        .Range("R" & n_fila + i).Value = dtDatos.Rows(i)("CANT_ING")
                        .Range("S" & n_fila + i).Value = dtDatos.Rows(i)("CANT_DEV")
                        .Range("T" & n_fila + i).Value = dtDatos.Rows(i)("MONEDA")
                        .Range("U" & n_fila + i).Value = dtDatos.Rows(i)("TIPO_CAMBIO")
                        .Range("V" & n_fila + i).Value = dtDatos.Rows(i)("PRECIO")
                        .Range("W" & n_fila + i).Value = dtDatos.Rows(i)("DCTO")
                        .Range("X" & n_fila + i).Value = dtDatos.Rows(i)("FLETE")
                        .Range("Y" & n_fila + i).Value = dtDatos.Rows(i)("TOTAL")
                        .Range("Z" & n_fila + i).Value = dtDatos.Rows(i)("FEC_EMISION")
                        .Range("AA" & n_fila + i).Value = dtDatos.Rows(i)("COD_PRODPDC")
                    Next

                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            m_Excel.Quit()
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

End Class