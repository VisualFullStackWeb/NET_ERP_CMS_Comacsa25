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
Public Class FrmRumaComparativo
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
    Sub Reporte()
        If Tab1.Tabs("T01").Selected = True Then
            btnReporte_Click(Nothing, Nothing)
        End If
        If Tab1.Tabs("T02").Selected = True Then
            btnReporte_Mol_Click(Nothing, Nothing)
        End If
        If Tab1.Tabs("T03").Selected = True Then
            btnReporte_Mol_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        If cmbMes.Value = cmbhasta.Value Then
            MsgBox("No puede comprar dos meses iguales", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If
        If txtcodruma.Text.ToString.Trim = "" Then
            MsgBox("Seleccione código de Ruma", MsgBoxStyle.Exclamation, "Validación")
            txtcodruma.Focus()
            Exit Sub
        End If
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
            _objEntidad.Anho1 = txtayohasta.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.Mes1 = cmbhasta.Value
            _objEntidad.CodProducto = txtcodruma.Text
            dsData = _objNegocio.Costo_COST_RUMA_COMPARATIVO(_objEntidad)
            dtRuma = dsData.Tables(0)
            dtResumen = dsData.Tables(1)
            Dim n_fila As Int32 = 9

            Dim n_fila_ini As Int32 = 0
            Dim n_fila_fin As Int32 = 0

            Dim fgl_cab As Int32 = 0
            'MsgBox(RutaReporteERP)
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\COST_COMPARATIVO_RUMA_" & cmbMes.Text.Trim.ToUpper & "_" & cmbhasta.Text.Trim.ToUpper & ".xls")
            File.Copy(RutaReporteERP & "COST_RUMA_COMPARATIVO.xls", path & "\COST_COMPARATIVO_RUMA_" & cmbMes.Text.Trim.ToUpper & "_" & cmbhasta.Text.Trim.ToUpper & ".xls")
            'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\COST_COMPARATIVO_RUMA_" & cmbMes.Text.Trim.ToUpper & "_" & cmbhasta.Text.Trim.ToUpper & ".xls")
            Dim objHojaExcel_Ruma As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            'Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            'Dim objHojaExcel_Ruma As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            m_Excel.DisplayAlerts = False
            Dim nfila As Integer
            Dim nfilaini As Integer
            Dim nfilault As Integer = 0

            nfila = 9
            Dim cod_matprima_sig As String = ""
            Dim filaultima As Int32 = 0

            If dtRuma.Rows.Count > 0 Then
                '************************************RESUMEN DE RUMAS************************************

                With objHojaExcel_Ruma
                    .Activate()
                    .Range("C2").Value = "COMPARATIVO DE COSTO DE RUMA " '& cmbMes.Text.ToString.ToUpper

                    fgl_cab = 0
                    If dtRuma.Rows.Count > 0 Then
                        nfila = 8
                        cod_matprima_sig = ""
                        filaultima = 0
                        'm_Excel.Visible = True
                        'Dim cod_mineral As String
                        Dim col As Int32 = 5
                        Dim fila_D As Integer = 0
                        Dim fila_I As Integer = 0
                        For i As Int16 = 0 To dtRuma.Rows.Count - 1
                            If i > 0 Then
                                If dtRuma.Rows(i)("CODRUMA") <> dtRuma.Rows(i - 1)("CODRUMA") Then
                                    fgl_cab = 0
                                    nfila = 8
                                    col += 2
                                    fila_D = 0
                                    fila_I = 0
                                End If
                            End If

                            If fgl_cab = 0 Then
                                nfilaini = nfila
                                .Range(.Cells(nfila, 1), .Cells(nfila, 1)).Value = "COSTOS DIRECTOS"
                                .Range(.Cells(4, col), .Cells(4, col + 1)).ColumnWidth = 18
                                .Range(.Cells(4, col), .Cells(4, col)).Value = cmbMes.Text.ToString.Trim + " - " + txtayo.Value.ToString
                                .Range(.Cells(5, col), .Cells(5, col)).Value = dtRuma.Rows(i)("CODRUMA").ToString.Trim
                                '.Range(.Cells(5, col), .Cells(5, col + 1)).Merge()
                                '.Range(.Cells(4, col + 1), .Cells(4, col + 1)).Value = dtRuma.Rows(i)("CODRUMA").ToString.Trim
                                .Range(.Cells(6, col), .Cells(6, col)).Value = "Costo Total"
                                .Range(.Cells(6, col + 1), .Cells(6, col + 1)).Value = "Costo x Ton"

                                .Range(.Cells(7, col), .Cells(7, col)).Value = dtRuma.Rows(i)("TON")
                                .Range(.Cells(7, col), .Cells(7, col + 1)).Merge()

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
                                '.Range("D" & nfila).Value = "=SUMA(D" & 7 & ":D" & 13 & ")"
                                .Range(.Cells(nfila, 3), .Cells(nfila, col)).Font.Bold = True

                                '.Range("A" & nfila - 7 & ":B" & nfila - 1).Merge()
                                '.Range("A" & nfila - 7 & ":B" & nfila - 1).Orientation = 90 ' Microsoft.Office.Interop.Excel.XlOrientation.xlVertical

                                nfila += 1
                                fgl_cab = 1
                            End If

                            If i > 0 Then
                                If dtRuma.Rows(i)("FLAGCONTA") <> dtRuma.Rows(i - 1)("FLAGCONTA") And dtRuma.Rows(i)("FLAGCONTA") = "I" Then
                                    nfila += 1
                                End If
                            End If
                            .Range("D" & nfila).Value = dtRuma.Rows(i)("FIJOVAR")
                            .Range("C" & nfila).Value = dtRuma.Rows(i)("DESCRIPCION")
                            If dtRuma.Rows(i)("FLAGCONTA") = "D" Then
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtRuma.Rows(i)("DIRECTOMINAS")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtRuma.Rows(i)("DIRECTOMINASXTON")
                                fila_D += 1
                            Else
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtRuma.Rows(i)("INDIRECTOMINAS")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtRuma.Rows(i)("INDIRECTOMINASXTON")
                                fila_I += 1
                            End If
                            nfila += 1

                        Next
                        'm_Excel.Visible = True
                    End If


                    fgl_cab = 0
                    If dtResumen.Rows.Count > 0 Then
                        nfila = 8
                        cod_matprima_sig = ""
                        filaultima = 0
                        'm_Excel.Visible = True
                        'Dim cod_mineral As String
                        Dim col As Int32 = 7
                        Dim fila_D As Integer = 0
                        Dim fila_I As Integer = 0
                        For i As Int16 = 0 To dtResumen.Rows.Count - 1
                            If i > 0 Then
                                If dtResumen.Rows(i)("CODRUMA") <> dtResumen.Rows(i - 1)("CODRUMA") Then
                                    fgl_cab = 0
                                    nfila = 8
                                    col += 2
                                    fila_D = 0
                                    fila_I = 0
                                End If
                            End If

                            If fgl_cab = 0 Then
                                nfilaini = nfila
                                .Range(.Cells(nfila, 1), .Cells(nfila, 1)).Value = "COSTOS DIRECTOS"
                                .Range(.Cells(4, col), .Cells(4, col + 1)).ColumnWidth = 18
                                .Range(.Cells(4, col), .Cells(4, col)).Value = cmbhasta.Text.ToString.Trim + " - " + txtayohasta.Value.ToString
                                .Range(.Cells(5, col), .Cells(5, col)).Value = dtResumen.Rows(i)("CODRUMA").ToString.Trim
                                '.Range(.Cells(5, col), .Cells(5, col + 1)).Merge()
                                '.Range(.Cells(4, col + 1), .Cells(4, col + 1)).Value = dtRuma.Rows(i)("CODRUMA").ToString.Trim
                                .Range(.Cells(6, col), .Cells(6, col)).Value = "Costo Total"
                                .Range(.Cells(6, col + 1), .Cells(6, col + 1)).Value = "Costo x Ton"

                                .Range(.Cells(7, col), .Cells(7, col)).Value = dtResumen.Rows(i)("TON")
                                .Range(.Cells(7, col), .Cells(7, col + 1)).Merge()

                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Extracción"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtResumen.Rows(i)("VALOREXTRACCION")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtResumen.Rows(i)("VALOREXTRACCIONXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Compra"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtResumen.Rows(i)("VALORCOMPRA")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtResumen.Rows(i)("VALORCOMPRAXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Flete"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtResumen.Rows(i)("FLETE")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtResumen.Rows(i)("FLETEXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Regalía"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtResumen.Rows(i)("REGALIAS")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtResumen.Rows(i)("REGALIASXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Lavado"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtResumen.Rows(i)("LAVADO")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtResumen.Rows(i)("LAVADOXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Carguío"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtResumen.Rows(i)("CARGUIO")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtResumen.Rows(i)("CARGUIOXTON")
                                nfila += 1
                                .Range(.Cells(nfila, 3), .Cells(nfila, 3)).Value = "Primera Bajada"
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtResumen.Rows(i)("PRIBAJADA")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtResumen.Rows(i)("PRIBAJADAXTON")

                                nfila += 1
                                .Range("C" & nfila).Value = "SUB-TOTAL COSTOS DIRECTOS"
                                '.Range("D" & nfila).Value = "=SUMA(D" & 7 & ":D" & 13 & ")"
                                .Range(.Cells(nfila, 3), .Cells(nfila, col)).Font.Bold = True

                                '.Range("A" & nfila - 7 & ":B" & nfila - 1).Merge()
                                '.Range("A" & nfila - 7 & ":B" & nfila - 1).Orientation = 90 ' Microsoft.Office.Interop.Excel.XlOrientation.xlVertical

                                nfila += 1
                                fgl_cab = 1
                            End If

                            If i > 0 Then
                                If dtResumen.Rows(i)("FLAGCONTA") <> dtRuma.Rows(i - 1)("FLAGCONTA") And dtResumen.Rows(i)("FLAGCONTA") = "I" Then
                                    nfila += 1
                                End If
                            End If

                            .Range("C" & nfila).Value = dtResumen.Rows(i)("DESCRIPCION")
                            If dtResumen.Rows(i)("FLAGCONTA") = "D" Then
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtResumen.Rows(i)("DIRECTOMINAS")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtResumen.Rows(i)("DIRECTOMINASXTON")
                                fila_D += 1
                            Else
                                .Range(.Cells(nfila, col), .Cells(nfila, col)).Value = dtResumen.Rows(i)("INDIRECTOMINAS")
                                .Range(.Cells(nfila, col + 1), .Cells(nfila, col + 1)).Value = dtResumen.Rows(i)("INDIRECTOMINASXTON")
                                fila_I += 1
                            End If
                            nfila += 1

                        Next
                        'm_Excel.Visible = True
                    End If

                End With
            End If
            objHojaExcel_Ruma.Activate()
            m_Excel.Visible = True


        Catch ex As Exception
            MsgBox(ex.Message)
            m_Excel.Quit()
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub FrmRumaComparativo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Year(Now.Date)
        txtayohasta.Value = Year(Now.Date)
        cmbMes.Value = Month(Now.Date)
        cmbhasta.Value = Month(Now.Date)

        txtayo1.Value = Year(Now.Date)
        txtayohasta1.Value = Year(Now.Date)
        cmbmes1.Value = Month(Now.Date)
        cmbmeshasta1.Value = Month(Now.Date)

        txtayo2.Value = Year(Now.Date)
        txtayohasta2.Value = Year(Now.Date)
        cmbMes2.Value = Month(Now.Date)
        cmbhasta2.Value = Month(Now.Date)
    End Sub

    Private Sub txtcodruma_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodruma.KeyPress
        Try
            Dim frm As New FrmListaRuma
            frm.ShowDialog()
            If Not codProducto = "" Then
                txtcodruma.Text = codProducto
                txtruma.Text = Producto
                codProducto = ""
                Producto = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnReporte_Mol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte_Mol.Click
        If cmbmes1.Value = cmbmeshasta1.Value Then
            MsgBox("No puede comprar dos meses iguales", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If
        If txtcodmolino.Text.ToString.Trim = "" Then
            MsgBox("Seleccione código de Molino", MsgBoxStyle.Exclamation, "Validación")
            txtcodruma.Focus()
            Exit Sub
        End If
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtConceptos As New DataTable
            Dim dt1 As New DataTable
            Dim dt2 As New DataTable
            Dim mes1 As String = ""
            Dim mes2 As String = ""
            dt1 = New DataTable
            dt2 = New DataTable
            Dim dsData As New DataSet

            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo1.Value
            _objEntidad.Anho1 = txtayohasta1.Value
            _objEntidad.Mes = cmbmes1.Value
            _objEntidad.Mes1 = cmbmeshasta1.Value
            _objEntidad.CodProducto = txtcodmolino.Text
            dsData = _objNegocio.Costo_COST_MOLINO_COMPARATIVO(_objEntidad)

            dt1 = dsData.Tables(0)
            dt2 = dsData.Tables(1)

            If dsData.Tables(0).Rows.Count = 0 And dsData.Tables(1).Rows.Count = 0 Then
                MsgBox("No hay datos para mostrar", MsgBoxStyle.Information, msgComacsa)
                Exit Sub
            End If
            If dt1.Rows.Count >= dt2.Rows.Count Then
                dtConceptos = dt1
            Else
                dtConceptos = dt2
            End If

            'dtRuma = dsData.Tables(0)
            'dtResumen = dsData.Tables(1)
            Dim n_fila As Int32 = 9

            Dim n_fila_ini As Int32 = 0
            Dim n_fila_fin As Int32 = 0

            Dim fgl_cab As Int32 = 0
            'MsgBox(RutaReporteERP)
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\COST_COMPARATIVO_MOLINO_" & cmbmes1.Text.Trim.ToUpper & "_" & cmbmeshasta1.Text.Trim.ToUpper & ".xls")
            File.Copy(RutaReporteERP & "COST_MOLINO_COMPARATIVO.xls", path & "\COST_COMPARATIVO_MOLINO_" & cmbmes1.Text.Trim.ToUpper & "_" & cmbmeshasta1.Text.Trim.ToUpper & ".xls")
            'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\COST_COMPARATIVO_MOLINO_" & cmbmes1.Text.Trim.ToUpper & "_" & cmbmeshasta1.Text.Trim.ToUpper & ".xls")
            Dim objHojaExcel_Ruma As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            m_Excel.DisplayAlerts = False
            Dim nfila As Integer
            nfila = 8

            With objHojaExcel_Ruma
                .Activate()
                .Range("C2").Value = "COMPARATIVO DE COSTO POR MOLINO " '& cmbMes.Text.ToString.ToUpper
                .Range("D5").Value = dtConceptos.Rows(0)("EQUIPO")
                .Range("D7").Value = dt1.Rows(0)("TONPRODUCTO")
                .Range("F7").Value = dt2.Rows(0)("TONPRODUCTO")
                .Range("D4").Value = cmbmes1.Text
                .Range("F4").Value = cmbmeshasta1.Text

                For i As Int32 = 0 To dtConceptos.Rows.Count - 1
                    .Range("C" & nfila + i).Value = dtConceptos.Rows(i)("CONCEPTO")
                    .Range("D" & nfila + i & ":G" & nfila + i).Value = 0
                    .Range("I" & nfila + i).Value = "=G" & nfila + i & "-E" & nfila + i
                Next
                Dim fila_ult As Int32 = dtConceptos.Rows.Count - 1 + nfila
                fila_ult += 2
                .Range("C" & fila_ult).Value = "TOTALES"
                .Range("D" & fila_ult).Value = "=SUMA(D" & nfila & ":D" & fila_ult - 2 & ")"
                .Range("E" & fila_ult).Value = "=SUMA(E" & nfila & ":E" & fila_ult - 2 & ")"
                .Range("F" & fila_ult).Value = "=SUMA(F" & nfila & ":F" & fila_ult - 2 & ")"
                .Range("G" & fila_ult).Value = "=SUMA(G" & nfila & ":G" & fila_ult - 2 & ")"
                .Range("I" & fila_ult).Value = "=SUMA(I" & nfila & ":I" & fila_ult - 2 & ")"

                .Range("C" & fila_ult & ":I" & fila_ult).Font.Bold = True

                For i As Int32 = 0 To dt1.Rows.Count - 1
                    For x As Int32 = 0 To dtConceptos.Rows.Count - 1
                        If dt1.Rows(i)("CONCEPTO") = .Range("C" & nfila + x).Value Then
                            .Range("D" & nfila + i).Value = dt1.Rows(i)("TOT_COSTO")
                            .Range("E" & nfila + i).Value = dt1.Rows(i)("TON_COSTO")
                            Exit For
                        End If
                    Next
                Next

                For i As Int32 = 0 To dt2.Rows.Count - 1
                    For x As Int32 = 0 To dtConceptos.Rows.Count - 1
                        If dt2.Rows(i)("CONCEPTO") = .Range("C" & nfila + x).Value Then
                            .Range("F" & nfila + i).Value = dt2.Rows(i)("TOT_COSTO")
                            .Range("G" & nfila + i).Value = dt2.Rows(i)("TON_COSTO")
                            Exit For
                        End If
                    Next
                Next

            End With

            objHojaExcel_Ruma.Activate()
            m_Excel.Visible = True


        Catch ex As Exception
            MsgBox(ex.Message)
            m_Excel.Quit()
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub btnReporte_Ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte_Ch.Click
        If cmbMes2.Value = cmbhasta2.Value Then
            MsgBox("No puede comprar dos meses iguales", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If
        If txtcodchancadora.Text.ToString.Trim = "" Then
            MsgBox("Seleccione código de Chancadora", MsgBoxStyle.Exclamation, "Validación")
            txtcodruma.Focus()
            Exit Sub
        End If
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtConceptos As New DataTable
            Dim dt1 As New DataTable
            Dim dt2 As New DataTable
            Dim mes1 As String = ""
            Dim mes2 As String = ""
            dt1 = New DataTable
            dt2 = New DataTable
            Dim dsData As New DataSet

            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo2.Value
            _objEntidad.Anho1 = txtayohasta2.Value
            _objEntidad.Mes = cmbMes2.Value
            _objEntidad.Mes1 = cmbhasta2.Value
            _objEntidad.CodProducto = txtcodchancadora.Text
            dsData = _objNegocio.Costo_COST_CH_COMPARATIVO(_objEntidad)

            dt1 = dsData.Tables(0)
            dt2 = dsData.Tables(1)

            If dsData.Tables(0).Rows.Count = 0 And dsData.Tables(1).Rows.Count = 0 Then
                MsgBox("No hay datos para mostrar", MsgBoxStyle.Information, msgComacsa)
                Exit Sub
            End If
            If dt1.Rows.Count >= dt2.Rows.Count Then
                dtConceptos = dt1
            Else
                dtConceptos = dt2
            End If

            'dtRuma = dsData.Tables(0)
            'dtResumen = dsData.Tables(1)
            Dim n_fila As Int32 = 9

            Dim n_fila_ini As Int32 = 0
            Dim n_fila_fin As Int32 = 0

            Dim fgl_cab As Int32 = 0
            'MsgBox(RutaReporteERP)
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\COST_COMPARATIVO_CHANCADORA_" & cmbMes2.Text.Trim.ToUpper & "_" & cmbhasta2.Text.Trim.ToUpper & ".xls")
            File.Copy(RutaReporteERP & "COST_MOLINO_COMPARATIVO.xls", path & "\COST_COMPARATIVO_CHANCADORA_" & cmbMes2.Text.Trim.ToUpper & "_" & cmbhasta2.Text.Trim.ToUpper & ".xls")
            'm_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\COST_COMPARATIVO_CHANCADORA_" & cmbMes2.Text.Trim.ToUpper & "_" & cmbhasta2.Text.Trim.ToUpper & ".xls")
            Dim objHojaExcel_Ruma As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            m_Excel.DisplayAlerts = False
            Dim nfila As Integer
            nfila = 8

            With objHojaExcel_Ruma
                .Activate()
                .Range("C2").Value = "COMPARATIVO DE COSTO POR MOLINO " '& cmbMes.Text.ToString.ToUpper
                .Range("D5").Value = dtConceptos.Rows(0)("EQUIPO")
                .Range("D7").Value = dt1.Rows(0)("TONPRODUCTO")
                .Range("F7").Value = dt2.Rows(0)("TONPRODUCTO")
                .Range("D4").Value = cmbMes2.Text
                .Range("F4").Value = cmbhasta2.Text

                For i As Int32 = 0 To dtConceptos.Rows.Count - 1
                    .Range("C" & nfila + i).Value = dtConceptos.Rows(i)("CONCEPTO")
                    .Range("D" & nfila + i & ":G" & nfila + i).Value = 0
                    .Range("I" & nfila + i).Value = "=G" & nfila + i & "-E" & nfila + i
                Next
                Dim fila_ult As Int32 = dtConceptos.Rows.Count - 1 + nfila
                fila_ult += 2
                .Range("C" & fila_ult).Value = "TOTALES"
                .Range("D" & fila_ult).Value = "=SUMA(D" & nfila & ":D" & fila_ult - 2 & ")"
                .Range("E" & fila_ult).Value = "=SUMA(E" & nfila & ":E" & fila_ult - 2 & ")"
                .Range("F" & fila_ult).Value = "=SUMA(F" & nfila & ":F" & fila_ult - 2 & ")"
                .Range("G" & fila_ult).Value = "=SUMA(G" & nfila & ":G" & fila_ult - 2 & ")"
                .Range("I" & fila_ult).Value = "=SUMA(I" & nfila & ":I" & fila_ult - 2 & ")"

                .Range("C" & fila_ult & ":I" & fila_ult).Font.Bold = True

                For i As Int32 = 0 To dt1.Rows.Count - 1
                    For x As Int32 = 0 To dtConceptos.Rows.Count - 1
                        If dt1.Rows(i)("CONCEPTO") = .Range("C" & nfila + x).Value Then
                            .Range("D" & nfila + i).Value = dt1.Rows(i)("TOT_COSTO")
                            .Range("E" & nfila + i).Value = dt1.Rows(i)("TON_COSTO")
                            Exit For
                        End If
                    Next
                Next

                For i As Int32 = 0 To dt2.Rows.Count - 1
                    For x As Int32 = 0 To dtConceptos.Rows.Count - 1
                        If dt2.Rows(i)("CONCEPTO") = .Range("C" & nfila + x).Value Then
                            .Range("F" & nfila + i).Value = dt2.Rows(i)("TOT_COSTO")
                            .Range("G" & nfila + i).Value = dt2.Rows(i)("TON_COSTO")
                            Exit For
                        End If
                    Next
                Next

            End With

            objHojaExcel_Ruma.Activate()
            m_Excel.Visible = True


        Catch ex As Exception
            MsgBox(ex.Message)
            m_Excel.Quit()
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub txtcodruma_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodruma.ValueChanged

    End Sub

    Private Sub txtcodmolino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodmolino.KeyPress
        Try
            Dim frm As New FrmCostoEquipo
            Dim resul As DialogResult
            resul = frm.ShowDialog()
            If resul = Windows.Forms.DialogResult.OK Then
                txtcodmolino.Text = frm.gridCuenta.ActiveRow.Cells("placa").Value
                txtmolino.Text = frm.gridCuenta.ActiveRow.Cells("modelo").Value
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcodchancadora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodchancadora.KeyPress
        Try
            Dim frm As New FrmCostoEquipo
            Dim resul As DialogResult
            resul = frm.ShowDialog()
            If resul = Windows.Forms.DialogResult.OK Then
                txtcodchancadora.Text = frm.gridCuenta.ActiveRow.Cells("placa").Value
                txtchancadora.Text = frm.gridCuenta.ActiveRow.Cells("modelo").Value
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcodmolino_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodmolino.ValueChanged

    End Sub

    Private Sub txtcodchancadora_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodchancadora.ValueChanged

    End Sub
End Class