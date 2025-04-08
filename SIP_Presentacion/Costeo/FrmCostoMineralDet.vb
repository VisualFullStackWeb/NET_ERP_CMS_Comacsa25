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
Public Class FrmCostoMineralDet
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

    Private Sub FrmCostoMineralDet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbMes.Value = Month(Now.Date)
        txtayo.Value = Year(Now.Date)
    End Sub
    Sub Buscar()
        If txtcodprod.Focused = True Then
            Dim frm As New FrmListaProductos
            frm.ShowDialog()
            If Not codProducto = "" Then
                txtcodProd.Text = codProducto
                txtProducto.Text = Producto
                codProducto = ""
                Producto = ""
            End If
        End If
    End Sub

    Private Sub txtcodcantera_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Buscar()
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
            _objEntidad.CodProducto = txtcodprod.Text
            dsData = _objNegocio.Costo_COST_MINERAL_DET(_objEntidad)
            dtDatos = dsData.Tables(0)
            dtResumen = dsData.Tables(1)
            dtRuma = dsData.Tables(2)
            Dim n_fila As Int32 = 9

            Dim n_fila_ini As Int32 = 0
            Dim n_fila_fin As Int32 = 0

            Dim fgl_cab As Int32 = 0
            Dim fila_ini As Int32 = 0
            Dim filault As Int32 = 0
            Dim fila_ini_i As Int32 = 0
            Dim filault_i As Int32 = 0
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\COST_MIN_DET" & cmbMes.Text.Trim.ToUpper & "_" & txtayo.Value & ".xls")
                File.Copy(RutaReporteERP & "PLANTILLA_COST_MIN_DET.xls", path & "\COST_MIN_DET" & cmbMes.Text.Trim.ToUpper & "_" & txtayo.Value & ".xls")
                'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
                m_Excel.Workbooks.Open(path & "\COST_MIN_DET" & cmbMes.Text.Trim.ToUpper & "_" & txtayo.Value & ".xls")
                Dim objHojaExcel_Resumen As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
                Dim objHojaExcel_Ruma As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 9
                Dim cod_matprima_sig As String = ""
                Dim filaultima As Int32 = 0
                'm_Excel.Visible = True
                With objHojaExcel
                    .Activate()
                    .Range("C2").Value = "DETALLE DE COSTO DE MINERAL " & cmbMes.Text.ToString.ToUpper

                    'Dim cod_mineral As String
                    Dim col As Int32 = 4
                    Dim fila_D As Integer = 0
                    Dim fila_I As Integer = 0
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        If i > 0 Then
                            If dtDatos.Rows(i)("COD_MATPRIMA") <> dtDatos.Rows(i - 1)("COD_MATPRIMA") Then
                                fgl_cab = 0
                                nfila = 9
                                col += 1
                                fila_D = 0
                                fila_I = 0
                            End If
                        End If

                        If fgl_cab = 0 Then
                            nfilaini = nfila
                            .Range(.Cells(nfila, 1), .Cells(nfila, 1)).Value = "COSTOS DIRECTOS"
                            .Range(.Cells(4, col), .Cells(4, col)).ColumnWidth = 24.5
                            .Range(.Cells(4, col), .Cells(4, col)).Value = dtDatos.Rows(i)("CODRUMA").ToString.Trim
                            .Range(.Cells(5, col), .Cells(5, col)).Value = dtDatos.Rows(i)("CANTERA")
                            .Range(.Cells(6, col), .Cells(6, col)).Value = dtDatos.Rows(i)("COD_MATPRIMA").ToString.Trim
                            .Range(.Cells(7, col), .Cells(7, col)).Value = dtDatos.Rows(i)("MINERAL")
                            .Range(.Cells(8, col), .Cells(8, col)).Value = dtDatos.Rows(i)("TON")
                            .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Extracción"
                            .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtDatos.Rows(i)("VALOREXTRACCION")
                            nfila += 1
                            .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Compra"
                            .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtDatos.Rows(i)("VALORCOMPRA")
                            nfila += 1
                            .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Flete"
                            .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtDatos.Rows(i)("FLETE")
                            nfila += 1
                            .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Regalía"
                            .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtDatos.Rows(i)("REGALIAS")
                            nfila += 1
                            .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Lavado"
                            .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtDatos.Rows(i)("LAVADO")
                            nfila += 1
                            .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Carguío"
                            .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtDatos.Rows(i)("CARGUIO")
                            nfila += 1
                            .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Primera Bajada"
                            .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtDatos.Rows(i)("PRIBAJADA")

                            nfila += 1
                            .Range("C" & nfila).Value = "SUB-TOTAL COSTOS DIRECTOS"
                            .Range("D" & nfila).Value = "=SUMA(D" & 9 & ":D" & 15 & ")"
                            .Range(.Cells(nfila, 3), .Cells(nfila, col)).Font.Bold = True
                            .Range("C" & nfila & ":D" & nfila).Interior.Color = 14599344 '11829830

                            .Range("A" & nfila - 7 & ":B" & nfila - 1).Merge()
                            .Range("A" & nfila - 7 & ":B" & nfila - 1).Orientation = 90 ' Microsoft.Office.Interop.Excel.XlOrientation.xlVertical

                            nfila += 1
                            filault_i += 1
                            fgl_cab = 1
                            fila_ini = nfila
                        End If
                        
                        If i > 0 Then

                            If dtDatos.Rows(i)("FLAGCONTA") <> dtDatos.Rows(i - 1)("FLAGCONTA") And dtDatos.Rows(i)("FLAGCONTA") = "I" Then
                                'nfila += 1
                                fila_ini_i = nfila + 1
                                .Range("C" & nfila & ":D" & nfila).Font.Bold = True
                                .Range("C" & nfila & ":D" & nfila).Interior.Color = 14599344 '11829830
                                .Range("B" & fila_ini).Value = "COSTOS " & IIf(dtDatos.Rows(i - 1)("FLAGCONTA") = "D", "DIRECTOS", "INDIRECTOS")
                                .Range("B" & fila_ini & ":B" & nfila).Merge()
                                .Range("B" & fila_ini & ":B" & nfila).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                .Range("B" & fila_ini & ":B" & nfila).Font.Bold = True
                                .Range("B" & fila_ini & ":B" & nfila).Orientation = 90

                                .Range("C" & nfila & ":D" & nfila).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                .Range("C" & nfila).Value = "SUB- TOTAL GASTOS MINAS " & IIf(dtDatos.Rows(i - 1)("FLAGCONTA") = "D", "DIRECTOS", "INDIRECTOS")
                                .Range("D" & nfila).Value = "=SUMA(D" & fila_ini & ":D" & nfila - 1 & ")"
                                filault = nfila
                                nfila += 1
                            End If

                            If dtDatos.Rows(i)("FLAGCONTA") <> dtDatos.Rows(i - 1)("FLAGCONTA") And dtDatos.Rows(i)("FLAGCONTA") = "D" Then
                                'filault_i += 1
                                .Range("C" & filault_i & ":D" & filault_i).Font.Bold = True
                                .Range("C" & filault_i & ":D" & filault_i).Interior.Color = 14599344 '11829830
                                .Range("B" & filault_i).Value = "COSTOS " & IIf(dtDatos.Rows(i - 1)("FLAGCONTA") = "D", "DIRECTOS", "INDIRECTOS")
                                .Range("B" & fila_ini_i & ":B" & filault_i).Merge()
                                .Range("B" & fila_ini_i & ":B" & filault_i).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                .Range("B" & fila_ini_i & ":B" & filault_i).Font.Bold = True
                                .Range("B" & fila_ini_i & ":B" & filault_i).Orientation = 90

                                .Range("C" & filault_i & ":D" & filault_i).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                .Range("C" & filault_i).Value = "SUB- TOTAL GASTOS MINAS " & IIf(dtDatos.Rows(i - 1)("FLAGCONTA") = "D", "DIRECTOS", "INDIRECTOS")
                                .Range("D" & filault_i).Value = "=SUMA(D" & fila_ini_i & ":D" & filault_i - 1 & ")"

                                .Range("A17").Value = "GASTOS DE MINAS "
                                .Range("A17" & ":A" & filault_i).Merge()
                                .Range("A17" & ":A" & filault_i).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                .Range("A17" & ":A" & filault_i).Font.Bold = True
                                .Range("A17" & ":A" & filault_i).Orientation = 90
                                'nfila += 1
                            End If

                        End If

                        .Range("C" & nfila).Value = dtDatos.Rows(i)("DESCRIPCION")
                        If dtDatos.Rows(i)("FLAGCONTA") = "D" Then
                            .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtDatos.Rows(i)("DIRECTO")
                            fila_D += 1
                        Else
                            .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtDatos.Rows(i)("INDIRECTO")
                            filault_i = nfila
                            fila_I += 1
                        End If
                        nfila += 1
                        .Range(.Cells(4, 4), .Cells(nfila + 1, col)).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    Next

                    If col > 4 Then
                        .Range("D16").Select()
                        m_Excel.Selection.Copy()
                        .Range(.Cells(16, 5), .Cells(16, col)).Select()
                        .Paste()

                        .Range("D" & filault).Select()
                        m_Excel.Selection.Copy()
                        .Range(.Cells(filault, 5), .Cells(filault, col)).Select()
                        .Paste()

                        filault_i += 1
                        .Range("D" & filault_i).Select()
                        m_Excel.Selection.Copy()
                        .Range(.Cells(filault_i, 5), .Cells(filault_i, col)).Select()
                        .Paste()

                        .Range("C" & filault_i + 1 & ":D" & filault_i + 1).Font.Bold = True
                        .Range("C" & filault_i + 1 & ":D" & filault_i + 1).Interior.Color = 14599344 '11829830
                        .Range("C" & filault_i + 1 & ":D" & filault_i + 1).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range("C" & filault_i + 1).Value = "TOTAL COSTOS"
                        .Range("D" & filault_i + 1).Value = "=D16+D" & filault & "+D" & filault_i

                        .Range("D" & filault_i + 1).Select()
                        m_Excel.Selection.Copy()
                        .Range(.Cells(filault_i + 1, 5), .Cells(filault_i + 1, col)).Select()
                        .Paste()

                        '.Range("D58").Select()
                        'm_Excel.Selection.Copy()
                        '.Range(.Cells(58, 5), .Cells(58, col)).Select()
                        '.Paste()
                        m_Excel.CutCopyMode = False
                    End If

                    Dim ruma As String
                    Dim n_ini As Int32 = 4
                    Dim ruma_ini As String
                    ruma_ini = .Range(.Cells(4, 4), .Cells(4, 4)).Value
                    For i As Int32 = 4 To col
                        ruma = .Range(.Cells(4, i), .Cells(4, i)).Value
                        If i > 4 Then
                            ruma_ini = .Range(.Cells(4, i - 1), .Cells(4, i - 1)).Value
                        End If
                        If ruma <> ruma_ini Then
                            .Range(.Cells(4, n_ini), .Cells(4, i - 1)).Merge()
                            n_ini = i
                        End If
                    Next
                    .Range(.Cells(4, n_ini), .Cells(4, col)).Merge()

                    ruma = ""
                    n_ini = 4
                    ruma_ini = ""
                    ruma_ini = .Range(.Cells(5, 4), .Cells(5, 4)).Value
                    For i As Int32 = 4 To col
                        ruma = .Range(.Cells(5, i), .Cells(5, i)).Value
                        If i > 4 Then
                            ruma_ini = .Range(.Cells(5, i - 1), .Cells(5, i - 1)).Value
                        End If
                        If ruma <> ruma_ini Then
                            .Range(.Cells(5, n_ini), .Cells(5, i - 1)).Merge()
                            n_ini = i
                        End If
                    Next
                    .Range(.Cells(5, n_ini), .Cells(5, col)).Merge()

                    .Range("C4").Select()
                End With

                If dtResumen.Rows.Count > 0 Then
                    With objHojaExcel_Resumen
                        .Activate()
                        For i As Int32 = 0 To dtResumen.Rows.Count - 1
                            n_fila = 7
                            .Range("B" & n_fila + i).Value = dtResumen.Rows(i)("CODRUMA").ToString.Trim
                            .Range("C" & n_fila + i).Value = dtResumen.Rows(i)("CANTERA")
                            .Range("D" & n_fila + i).Value = dtResumen.Rows(i)("COD_MATPRIMA").ToString.Trim
                            .Range("E" & n_fila + i).Value = dtResumen.Rows(i)("MINERAL")
                            .Range("F" & n_fila + i).Value = dtResumen.Rows(i)("TON")
                            .Range("G" & n_fila + i).Value = dtResumen.Rows(i)("DIRECTO")
                            .Range("H" & n_fila + i).Value = "=G" & n_fila + i & "/F" & n_fila + i & ""
                            .Range("I" & n_fila + i).Value = dtResumen.Rows(i)("DIRECTOMINAS")
                            .Range("J" & n_fila + i).Value = "=I" & n_fila + i & "/F" & n_fila + i & ""
                            .Range("K" & n_fila + i).Value = dtResumen.Rows(i)("INDIRECTOMINAS")
                            .Range("L" & n_fila + i).Value = "=K" & n_fila + i & "/F" & n_fila + i & ""
                            .Range("M" & n_fila + i).Value = "=K" & n_fila + i & "+I" & n_fila + i & "+G" & n_fila + i & ""
                            .Range("N" & n_fila + i).Value = "=M" & n_fila + i & "/F" & n_fila + i & ""
                            n_fila += 1
                        Next
                    End With
                End If

                '************************************RESUMEN DE RUMAS************************************
                fgl_cab = 0
                If dtRuma.Rows.Count > 0 Then
                    nfila = 7
                    cod_matprima_sig = ""
                    filaultima = 0
                    'm_Excel.Visible = True
                    With objHojaExcel_Ruma
                        .Activate()
                        .Range("C2").Value = "DETALLE DE COSTO DE RUMA " & cmbMes.Text.ToString.ToUpper

                        'Dim cod_mineral As String
                        Dim col As Int32 = 5
                        Dim fila_D As Integer = 0
                        Dim fila_I As Integer = 0
                        For i As Int16 = 0 To dtRuma.Rows.Count - 1
                            If i > 0 Then
                                If dtRuma.Rows(i)("CODRUMA") <> dtRuma.Rows(i - 1)("CODRUMA") Then
                                    fgl_cab = 0
                                    nfila = 7
                                    col += 2
                                    fila_D = 0
                                    fila_I = 0
                                End If
                            End If

                            If fgl_cab = 0 Then
                                nfilaini = nfila
                                .Range(.Cells(nfila, 1), .Cells(nfila, 1)).Value = "COSTOS DIRECTOS"
                                .Range(.Cells(4, col), .Cells(4, col + 1)).ColumnWidth = 18
                                .Range(.Cells(4, col), .Cells(4, col)).Value = dtRuma.Rows(i)("CODRUMA").ToString.Trim
                                .Range(.Cells(4, col), .Cells(4, col + 1)).Merge()
                                '.Range(.Cells(4, col + 1), .Cells(4, col + 1)).Value = dtRuma.Rows(i)("CODRUMA").ToString.Trim
                                .Range(.Cells(5, col), .Cells(5, col)).Value = "Costo Total"
                                .Range(.Cells(5, col + 1), .Cells(5, col + 1)).Value = "Costo x Ton"

                                .Range(.Cells(6, col), .Cells(6, col)).Value = dtRuma.Rows(i)("TON")
                                .Range(.Cells(6, col), .Cells(6, col + 1)).Merge()
                                .Range(.Cells(nfila, 4), .Cells(nfila, 4)).Value = "V"
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Extracción"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtRuma.Rows(i)("VALOREXTRACCION")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtRuma.Rows(i)("VALOREXTRACCIONXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 4), .Cells(nfila, 4)).Value = "V"
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Compra"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtRuma.Rows(i)("VALORCOMPRA")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtRuma.Rows(i)("VALORCOMPRAXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 4), .Cells(nfila, 4)).Value = "V"
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Flete"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtRuma.Rows(i)("FLETE")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtRuma.Rows(i)("FLETEXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 4), .Cells(nfila, 4)).Value = "V"
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Regalía"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtRuma.Rows(i)("REGALIAS")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtRuma.Rows(i)("REGALIASXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 4), .Cells(nfila, 4)).Value = "V"
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Lavado"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtRuma.Rows(i)("LAVADO")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtRuma.Rows(i)("LAVADOXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 4), .Cells(nfila, 4)).Value = "V"
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Carguío"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtRuma.Rows(i)("CARGUIO")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtRuma.Rows(i)("CARGUIOXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 4), .Cells(nfila, 4)).Value = "V"
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Primera Bajada"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtRuma.Rows(i)("PRIBAJADA")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtRuma.Rows(i)("PRIBAJADAXTON")

                                nfila += 1
                                .Range("C" & nfila).Value = "SUB-TOTAL COSTOS DIRECTOS"
                                .Range("C" & nfila & ":E" & nfila).Interior.Color = 14599344 '11829830
                                .Range("E" & nfila).Value = "=SUMA(E" & 7 & ":E" & 13 & ")"
                                .Range(.Cells(nfila, 3), .Cells(nfila, col)).Font.Bold = True

                                .Range("A" & nfila - 7 & ":B" & nfila - 1).Merge()
                                .Range("A" & nfila - 7 & ":B" & nfila - 1).Orientation = 90 ' Microsoft.Office.Interop.Excel.XlOrientation.xlVertical

                                nfila += 1
                                filault_i += 1
                                fgl_cab = 1
                            End If

                            If i > 0 Then
                                If dtRuma.Rows(i)("FLAGCONTA") <> dtRuma.Rows(i - 1)("FLAGCONTA") And dtRuma.Rows(i)("FLAGCONTA") = "I" Then
                                    'nfila += 1
                                    fila_ini = 15
                                    fila_ini_i = nfila + 1
                                    .Range("C" & nfila & ":E" & nfila).Font.Bold = True
                                    .Range("C" & nfila & ":E" & nfila).Interior.Color = 14599344 '11829830
                                    .Range("B" & fila_ini).Value = "COSTOS " & IIf(dtRuma.Rows(i - 1)("FLAGCONTA") = "D", "DIRECTOS", "INDIRECTOS")
                                    .Range("B" & fila_ini & ":B" & nfila).Merge()
                                    .Range("B" & fila_ini & ":B" & nfila).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                    .Range("B" & fila_ini & ":B" & nfila).Font.Bold = True
                                    .Range("B" & fila_ini & ":B" & nfila).Orientation = 90

                                    .Range("C" & nfila & ":E" & nfila).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                    .Range("C" & nfila).Value = "SUB- TOTAL GASTOS MINAS " & IIf(dtRuma.Rows(i - 1)("FLAGCONTA") = "D", "DIRECTOS", "INDIRECTOS")
                                    .Range("E" & nfila).Value = "=SUMA(E" & fila_ini & ":E" & nfila - 1 & ")"
                                    filault = nfila
                                    nfila += 1
                                End If

                                If dtRuma.Rows(i)("FLAGCONTA") <> dtRuma.Rows(i - 1)("FLAGCONTA") And dtRuma.Rows(i)("FLAGCONTA") = "D" Then
                                    'filault_i += 1
                                    .Range("C" & filault_i & ":E" & filault_i).Font.Bold = True
                                    .Range("C" & filault_i & ":E" & filault_i).Interior.Color = 14599344 '11829830
                                    .Range("B" & filault_i).Value = "COSTOS " & IIf(dtRuma.Rows(i - 1)("FLAGCONTA") = "D", "DIRECTOS", "INDIRECTOS")
                                    .Range("B" & fila_ini_i & ":B" & filault_i).Merge()
                                    .Range("B" & fila_ini_i & ":B" & filault_i).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                    .Range("B" & fila_ini_i & ":B" & filault_i).Font.Bold = True
                                    .Range("B" & fila_ini_i & ":B" & filault_i).Orientation = 90

                                    .Range("C" & filault_i & ":E" & filault_i).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                    .Range("C" & filault_i).Value = "SUB- TOTAL GASTOS MINAS " & IIf(dtRuma.Rows(i - 1)("FLAGCONTA") = "D", "DIRECTOS", "INDIRECTOS")
                                    .Range("E" & filault_i).Value = "=SUMA(E" & fila_ini_i & ":E" & filault_i - 1 & ")"

                                    .Range("A15").Value = "GASTOS DE MINAS "
                                    .Range("A15" & ":A" & filault_i).Merge()
                                    .Range("A15" & ":A" & filault_i).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                    .Range("A15" & ":A" & filault_i).Font.Bold = True
                                    .Range("A15" & ":A" & filault_i).Orientation = 90
                                    'nfila += 1
                                End If

                            End If

                            .Range("C" & nfila).Value = dtDatos.Rows(i)("DESCRIPCION")
                            .Range("D" & nfila).Value = dtDatos.Rows(i)("FijoVar")
                            If dtRuma.Rows(i)("FLAGCONTA") = "D" Then
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtRuma.Rows(i)("DIRECTOMINAS")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtRuma.Rows(i)("DIRECTOMINASXTON")
                                fila_D += 1
                            Else

                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtRuma.Rows(i)("INDIRECTOMINAS")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtRuma.Rows(i)("INDIRECTOMINASXTON")
                                filault_i = nfila
                                fila_I += 1
                            End If
                            nfila += 1
                            .Range(.Cells(4, 4), .Cells(nfila, col + 1)).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                        Next
                        'm_Excel.Visible = True
                        If col > 5 Then
                            .Range("E14").Select()
                            m_Excel.Selection.Copy()
                            .Range(.Cells(14, 5), .Cells(14, col + 1)).Select()
                            .Paste()

                            .Range("E" & filault).Select()
                            m_Excel.Selection.Copy()
                            .Range(.Cells(filault, 5), .Cells(filault, col + 1)).Select()
                            .Paste()

                            filault_i += 1
                            .Range("E" & filault_i).Select()
                            m_Excel.Selection.Copy()
                            .Range(.Cells(filault_i, 5), .Cells(filault_i, col + 1)).Select()
                            .Paste()

                            .Range("C" & filault_i + 1 & ":E" & filault_i + 1).Font.Bold = True
                            .Range("C" & filault_i + 1 & ":E" & filault_i + 1).Interior.Color = 14599344 '11829830
                            .Range("C" & filault_i + 1 & ":E" & filault_i + 1).Borders().LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            .Range("C" & filault_i + 1).Value = "TOTAL COSTOS"
                            .Range("E" & filault_i + 1).Value = "=E14+E" & filault & "+E" & filault_i

                            .Range("E" & filault_i + 1).Select()
                            m_Excel.Selection.Copy()
                            .Range(.Cells(filault_i + 1, 5), .Cells(filault_i + 1, col + 1)).Select()
                            .Paste()

                            m_Excel.CutCopyMode = False
                        End If

                        .Range("C4").Select()
                    End With
                End If
                objHojaExcel_Resumen.Activate()
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