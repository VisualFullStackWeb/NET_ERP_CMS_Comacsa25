Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class FrmRptIgvRenta
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

    Private Sub FrmRptIgvRenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mes As Int32
        mes = Month(Now.Date)
        Dim fecha1 As Date
        fecha1 = "01/" & mes & "/" & Year(Now.Date)
        dtpDesde.Value = fecha1
        dtpHasta.Value = Now.Date
        txtayo.Value = Now.Date.Year
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
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista

            Dim dsIgvRenta As New DataSet
            Dim dtVenta As New DataTable
            Dim dtCompra As New DataTable
            Dim dtRetencion As New DataTable

            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\RPT_IGVRENTA_" & txtcodcontratista.Text.Trim & ".xls")
            File.Copy(RutaReporteERP & "PLANTILLAIGVRENTA.xls", path & "\RPT_IGVRENTA_" & txtcodcontratista.Text.Trim & ".xls")
            m_Excel.Workbooks.Open(path & "\RPT_IGVRENTA_" & txtcodcontratista.Text.Trim & ".xls")
            m_Excel.DisplayAlerts = False

            For i As Int32 = 1 To 12
                Entidad.Contratista = New ETContratista
                Negocio.NContratista = New NGContratista
                Entidad.Contratista._codprov = txtcodcontratista.Text
                Entidad.Contratista.Anho = txtayo.Value
                Entidad.Contratista._mes = i
                dsIgvRenta = Negocio.NContratista.RptIgvRenta_CTR(Entidad.Contratista)
                dtVenta = dsIgvRenta.Tables(0)
                dtCompra = dsIgvRenta.Tables(1)
                dtRetencion = dsIgvRenta.Tables(2)
                'If dtVenta.Rows.Count <= 0 And dtCompra.Rows.Count <= 0 And dtRetencion.Rows.Count <= 0 Then
                '    MsgBox("No existen datos para mostrar", MsgBoxStyle.Information, msgComacsa)
                '    Exit Sub
                'End If
                imprimir(m_Excel, dtVenta, dtCompra, dtRetencion, i)
            Next
            m_Excel.Visible = True
        Catch ex As Exception
            m_Excel.Quit()
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Function nombre_Mes(ByVal mes_nro As Int32) As String
        Dim mes As String = ""
        Select Case mes_nro
            Case 1 : mes = "ENERO"
            Case 2 : mes = "FEBRERO"
            Case 3 : mes = "MARZO"
            Case 4 : mes = "ABRIL"
            Case 5 : mes = "MAYO"
            Case 6 : mes = "JUNIO"
            Case 7 : mes = "JULIO"
            Case 8 : mes = "AGOSTO"
            Case 8 : mes = "SETIEMBRE"
            Case 10 : mes = "OCTUBRE"
            Case 11 : mes = "NOVIEMBRE"
            Case 12 : mes = "DICIEMBRE"
        End Select
        Return mes
    End Function

    Sub imprimir(ByVal m_Excel As Microsoft.Office.Interop.Excel.Application, ByVal dtVentas As DataTable, ByVal dtCompras As DataTable, ByVal dtDetracc As DataTable, ByVal numHoja As Int32)
        Try
            If dtVentas.Rows.Count > 0 Or dtCompras.Rows.Count > 0 Or dtDetracc.Rows.Count > 0 Then

                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(numHoja)
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim n_vta As Int32 = 0
                Dim n_compra As Int32 = 0
                nfila = 0
                With objHojaExcel
                    .Range("F8").Value = nombre_Mes(numHoja) & " " & txtayo.Value
                    For i As Int16 = 0 To dtVentas.Rows.Count - 1
                        Dim nfilault As Integer = 0
                        nfilaini = 12
                        .Activate()
                        .Range("B" & nfilaini + i & ":C" & nfilaini + i).Merge()
                        .Range("D" & nfilaini + i).Value = dtVentas.Rows(i)("FECHADOC")
                        .Range("D" & nfilaini + i & ":E" & nfilaini + i).Merge()
                        .Range("F" & nfilaini + i).Value = dtVentas.Rows(i)("NUMDOC")
                        .Range("F" & nfilaini + i & ":G" & nfilaini + i).Merge()
                        .Range("H" & nfilaini + i).Value = dtVentas.Rows(i)("MONEDA")
                        .Range("I" & nfilaini + i).Value = dtVentas.Rows(i)("VALORVTA")
                        .Range("J" & nfilaini + i).Value = dtVentas.Rows(i)("IGV")
                        .Range("K" & nfilaini + i).Value = dtVentas.Rows(i)("VALOR")
                        .Range("M" & nfilaini + i).Value = dtVentas.Rows(i)("CANTERA")
                        .Range("N" & nfilaini + i).Value = "=K" & nfilaini + i & "/$K$" & nfilaini + dtVentas.Rows.Count + 1 & ""
                        .Range("O" & nfilaini + i).Value = "=N" & nfilaini + i & "*$O$" & nfilaini + dtVentas.Rows.Count + 1 & ""
                        .Range(.Cells(nfilaini + i, 1), .Cells(nfilaini + i, 15)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfilaini + i
                    Next
                    .Range("H" & nfila + 2).Value = "TOTAL S/."
                    .Range("I" & nfila + 2).Value = "=SUMA(I" & nfilaini & ":I" & nfila & ")"
                    .Range("J" & nfila + 2).Value = "=SUMA(J" & nfilaini & ":J" & nfila & ")"
                    .Range("K" & nfila + 2).Value = "=SUMA(K" & nfilaini & ":K" & nfila & ")"
                    n_vta = nfila + 2
                    .Range("H" & nfila + 2 & ":K" & nfila + 2).Font.Bold = True
                    .Range("I" & nfila + 2 & ":K" & nfila + 2).NumberFormat = "###,##0.00"
                    .Range("I" & nfila + 2 & ":K" & nfila + 2).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("I" & nfila + 2 & ":K" & nfila + 2).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble

                    nfila += 4
                    .Range("A" & nfila).Value = "II. FACTURAS COMPRA"
                    .Range("A" & nfila).Font.Bold = True
                    nfila += 1
                    .Range("A" & nfila).Value = "Código"
                    .Range("A" & nfila).RowHeight = 23.25
                    .Range("A" & nfila & ":B" & nfila).Merge()
                    .Range("C" & nfila).Value = "Fecha de Emisión"
                    .Range("C" & nfila & ":D" & nfila).Merge()
                    .Range("E" & nfila).Value = "N° Documento"
                    .Range("E" & nfila & ":G" & nfila).Merge()
                    .Range("H" & nfila).Value = "Mon"
                    .Range("I" & nfila).Value = "Valor Vta."
                    .Range("J" & nfila).Value = "I.G.V"
                    .Range("K" & nfila).Value = "Precio Venta"
                    .Range("L" & nfila).Value = "Concepto Referencial"
                    .Range("A" & nfila & ":L" & nfila).WrapText = True
                    .Range("A" & nfila & ":L" & nfila).Font.Bold = True
                    nfilaini = nfila + 1

                    For i As Int16 = 0 To dtCompras.Rows.Count - 1
                        Dim nfilault As Integer = 0
                        'nfilaini = 12
                        '.Activate()
                        .Range("A" & nfilaini + i).Value = "" 'dtVentas.Rows(i)("COD_PROV")
                        .Range("A" & nfilaini + i & ":B" & nfilaini + i).Merge()
                        .Range("C" & nfilaini + i).Value = dtCompras.Rows(i)("FECHADOC")
                        .Range("C" & nfilaini + i & ":D" & nfilaini + i).Merge()
                        .Range("E" & nfilaini + i).Value = dtCompras.Rows(i)("NUMDOC")
                        .Range("E" & nfilaini + i & ":G" & nfilaini + i).Merge()
                        .Range("H" & nfilaini + i).Value = dtCompras.Rows(i)("MONEDA")
                        .Range("I" & nfilaini + i).Value = dtCompras.Rows(i)("VALORVTA")
                        .Range("J" & nfilaini + i).Value = dtCompras.Rows(i)("IGV")
                        .Range("K" & nfilaini + i).Value = dtCompras.Rows(i)("VALOR")
                        .Range("L" & nfilaini + i).Value = "" 'dtVentas.Rows(i)("CANTERA")
                        .Range(.Cells(nfilaini - 1 + i, 1), .Cells(nfilaini + i, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfilaini + i
                    Next
                    .Range("H" & nfila + 2).Value = "TOTAL S/."
                    .Range("I" & nfila + 2).Value = "=SUMA(I" & nfilaini & ":I" & nfila & ")"
                    .Range("J" & nfila + 2).Value = "=SUMA(J" & nfilaini & ":J" & nfila & ")"
                    .Range("K" & nfila + 2).Value = "=SUMA(K" & nfilaini & ":K" & nfila & ")"
                    n_compra = nfila + 2
                    .Range("H" & nfila + 2 & ":K" & nfila + 2).Font.Bold = True
                    .Range("I" & nfila + 2 & ":K" & nfila + 2).NumberFormat = "###,##0.00"
                    .Range("I" & nfila + 2 & ":K" & nfila + 2).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("I" & nfila + 2 & ":K" & nfila + 2).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble

                    nfila += 4
                    .Range("A" & nfila).Value = "CALCULO IMPUESTOS"
                    .Range("A" & nfila & ":I" & nfila).Merge()
                    .Range("A" & nfila).RowHeight = 21
                    .Range("A" & nfila).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    '.Range("A" & nfila).Interior.Color = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorAccent1
                    '.Range("A" & nfila).Font.Color = Color.Red

                    nfila += 2
                    .Range("F" & nfila).Value = "SALDO"
                    .Range("G" & nfila).Value = "SALDO A FAVOR ANTERIOR"
                    .Range("G" & nfila & ":H" & nfila).Merge()
                    .Range("I" & nfila).Value = "IMPUESTO POR PAGAR"
                    .Range("A" & nfila).RowHeight = 25.5
                    .Range("F" & nfila & ":I" & nfila).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("F" & nfila & ":I" & nfila).WrapText = True
                    .Range("F" & nfila & ":I" & nfila).Font.Bold = True

                    nfila += 1
                    .Range("A" & nfila).Value = "TOTAL IGV (VENTAS - COMPRAS)"
                    .Range("F" & nfila & ":I" & nfila).NumberFormat = "###,##0.00"
                    .Range("F" & nfila).Value = "=J" & n_vta & "-J" & n_compra & ""
                    .Range("I" & nfila).Value = "=F" & nfila & "+G" & nfila & ""
                    .Range("A" & nfila & ":E" & nfila).Merge()
                    .Range("A" & nfila & ":E" & nfila).Font.Bold = True
                    nfila += 1
                    .Range("A" & nfila).Value = "TOTAL IMP. A LA RENTA  0.015"
                    .Range("F" & nfila & ":I" & nfila).NumberFormat = "###,##0.00"
                    .Range("F" & nfila).Value = "=I" & n_vta & "*0.015"
                    .Range("I" & nfila).Value = "=SI((F" & nfila & "-G" & nfila & ")>0,(F" & nfila & "-G" & nfila & "),0)"
                    .Range("A" & nfila & ":E" & nfila).Merge()
                    .Range("A" & nfila & ":E" & nfila).Font.Bold = True
                    .Range("F" & nfila & ":I" & nfila).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("G" & nfila + 2).Value = "TOTAL IMPUESTOS"
                    .Range("I" & nfila + 2).Value = "=SUMA(I" & nfila - 1 & ":I" & nfila & ")"
                    .Range("G" & nfila + 2 & ":I" & nfila + 2).Font.Bold = True

                    nfila += 4
                    .Range("A" & nfila).Value = "DETRACCIONES"
                    .Range("A" & nfila).Font.Bold = True
                    nfila += 1

                    .Range("A" & nfila).Value = "PERIODO"
                    .Range("A" & nfila & ":B" & nfila).Merge()
                    .Range("C" & nfila).Value = "FECHA"
                    .Range("C" & nfila & ":D" & nfila).Merge()
                    .Range("E" & nfila).Value = "DOCUMENTO"
                    .Range("E" & nfila & ":F" & nfila).Merge()
                    .Range("G" & nfila).Value = "NUMERO"
                    .Range("H" & nfila).Value = "IMPORTE"
                    .Range("A" & nfila & ":H" & nfila).Font.Bold = True
                    .Range("A" & nfila & ":H" & nfila).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    nfilaini = nfila + 1

                    For i As Int16 = 0 To dtDetracc.Rows.Count - 1
                        Dim nfilault As Integer = 0
                        'nfilaini = 12
                        '.Activate()
                        .Range("A" & nfilaini + i).Value = dtDetracc.Rows(i)("PERIODO")
                        .Range("A" & nfilaini + i & ":B" & nfilaini + i).Merge()
                        .Range("C" & nfilaini + i).Value = dtDetracc.Rows(i)("FECHADEPOSITO")
                        .Range("C" & nfilaini + i & ":D" & nfilaini + i).Merge()
                        .Range("E" & nfilaini + i).Value = dtDetracc.Rows(i)("OPERACION")
                        .Range("E" & nfilaini + i & ":F" & nfilaini + i).Merge()
                        .Range("G" & nfilaini + i).Value = dtDetracc.Rows(i)("NRODEPOSITO")
                        .Range("H" & nfilaini + i).Value = dtDetracc.Rows(i)("IGV")

                        .Range("A" & nfilaini + i & ":H" & nfilaini + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfilaini + i
                    Next
                    .Range("G" & nfila + 2).Value = "TOTAL DETRACCIONES"
                    .Range("G" & nfila + 2 & ":H" & nfila + 2).Merge()
                    .Range("I" & nfila + 2).Value = "=SUMA(H" & nfilaini & ":H" & nfila & ")"
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class