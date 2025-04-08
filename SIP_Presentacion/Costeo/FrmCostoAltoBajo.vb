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
Public Class FrmCostoAltoBajo
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


    Private Sub txtcodCantera_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodProd.KeyPress
        Try
            If flgaprobada = 1 Then Return
            Dim frm As New FrmListaProductos
            frm.ShowDialog()
            If Not codProducto = "" Then
                txtcodProd.Text = codProducto
                txtProducto.Text = Producto
                codProducto = ""
                Producto = ""
            End If
        Catch ex As Exception
        End Try
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
        If txtcodProd.Text.ToString.Trim = "" Then
            MsgBox("Seleccione Producto", MsgBoxStyle.Information)
            Exit Sub
        End If
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            'PLANTILLA_ALTO_BAJO
            Dim dtDatos As New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Anho1 = txtayohasta.Value
            _objEntidad.Mes = cmbMesDesde.Value
            _objEntidad.Mes1 = cmbMesHasta.Value
            _objEntidad.CodProducto = txtcodProd.Text
            Dim dsDatos As New DataSet
            dsDatos = _objNegocio.Costo_COST_ALTOBAJO(_objEntidad)

            Dim dtDatos1 As New DataTable
            Dim dtDatos2 As New DataTable
            Dim dtDatos3 As New DataTable
            Dim dtDatos4 As New DataTable
            dtDatos1 = dsDatos.Tables(1)
            dtDatos2 = dsDatos.Tables(2)
            dtDatos3 = dsDatos.Tables(3)
            dtDatos4 = dsDatos.Tables(4)
            If dsDatos.Tables(0).Rows.Count = 0 Then
                MsgBox("No existe costeo para el producto seleccionado", MsgBoxStyle.Information)
                Exit Sub
            End If
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Try
                Dim nfila As Integer = 0
                Dim nfila_ult As Integer = 0
                'Dim objLibroExcel As Object = m_Excel.WorkBooks.add
                'Dim objHojaExcel As Object = objLibroExcel.WorkSheets(1)
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTE_ALTO_BAJO" & ".xls")
                File.Copy(RutaReporteERP & "PLANTILLA_ALTO_BAJO.xls", path & "\REPORTE_ALTO_BAJO" & ".xls")
                m_Excel.Workbooks.Open(path & "\REPORTE_ALTO_BAJO" & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                m_Excel.Visible = True
                objHojaExcel.Name = "Reporte"
                Dim formula1 As String = "="
                Dim formula2 As String = "="
                'Dim formula3 As String = "=SI.ERROR(("
                Dim formula3 As String = "=("
                Dim formula4 As String = "=("
                Dim ini_ruma As Int32 = 0
                If dsDatos.Tables(0).Rows.Count > 0 Then
                    With objHojaExcel
                        .Range("B2").Value = txtcodProd.Text.ToString.Trim.ToUpper & " " & txtProducto.Text.ToString.Trim.ToUpper
                        .Range("B6").Value = txtProducto.Text.ToString.Trim.ToUpper
                        .Range("F8").NumberFormat = "@"
                        .Range("M8").NumberFormat = "@"
                        .Range("T8").NumberFormat = "@"
                        .Range("F8").Value = dsDatos.Tables(0).Rows(2)("MES")
                        .Range("M8").Value = dsDatos.Tables(0).Rows(1)("MES")
                        .Range("T8").Value = dsDatos.Tables(0).Rows(0)("MES")
                        .Range("F10").Value = dsDatos.Tables(0).Rows(2)("TON")
                        .Range("G10").Value = dsDatos.Tables(0).Rows(2)("VALOR")
                        .Range("M10").Value = dsDatos.Tables(0).Rows(1)("TON")
                        .Range("N10").Value = dsDatos.Tables(0).Rows(1)("VALOR")
                        .Range("T10").Value = dsDatos.Tables(0).Rows(0)("TON")
                        .Range("U10").Value = dsDatos.Tables(0).Rows(0)("VALOR")
                        nfila = 18
                        .Range("X17").Value = "COD_CANTERA"
                        .Range("Y17").Value = "CANTERA"
                        Dim cont As Int32 = 1
                        If dtDatos1.Rows.Count > 0 Then
                            For i As Int32 = 0 To dtDatos1.Rows.Count - 1
                                .Range("A" & nfila + i).Value = dtDatos1.Rows(i)("CODRUMA")
                                .Range("B" & nfila + i).Value = dtDatos1.Rows(i)("INSUMO")
                                .Range("F" & nfila + i).Value = dtDatos1.Rows(i)("TON_BAJO")
                                .Range("G" & nfila + i).Value = dtDatos1.Rows(i)("COSTO_BAJO")
                                .Range("D" & nfila + i).Value = dtDatos1.Rows(i)("COSTO_BAJO_RUMA")
                                .Range("E" & nfila + i).Value = "=D" & nfila + i & "*F" & nfila + i & ""
                                '.Range("A" & nfila + i).Value = dtDatos1.Rows(i)("")
                                .Range("M" & nfila + i).Value = dtDatos1.Rows(i)("TON_MEDIO")
                                .Range("N" & nfila + i).Value = dtDatos1.Rows(i)("COSTO_MEDIO")
                                .Range("K" & nfila + i).Value = dtDatos1.Rows(i)("COSTO_MEDIO_RUMA")
                                .Range("L" & nfila + i).Value = "=K" & nfila + i & "*M" & nfila + i & ""
                                '.Range("A" & nfila + i).Value = dtDatos1.Rows(i)("")
                                .Range("T" & nfila + i).Value = dtDatos1.Rows(i)("TON_ALTO")
                                .Range("U" & nfila + i).Value = dtDatos1.Rows(i)("COSTO_ALTO")
                                .Range("R" & nfila + i).Value = dtDatos1.Rows(i)("COSTO_ALTO_RUMA")
                                .Range("S" & nfila + i).Value = "=R" & nfila + i & "*T" & nfila + i & ""
                                .Range("X" & nfila + i).Value = dtDatos1.Rows(i)("CODCANTERA")
                                .Range("Y" & nfila + i).Value = dtDatos1.Rows(i)("CODCANTERA_DES")
                                '.Range("A" & nfila + i).Value = dtDatos1.Rows(i)("")
                                cont = cont + 1
                            Next
                        End If
                        nfila = nfila + cont
                        .Range("F15").Value = "=SUMA(F18:F" & nfila - 2 & ")"
                        .Range("G15").Value = "=SUMA(G18:G" & nfila - 2 & ")"

                        .Range("M15").Value = "=SUMA(M18:M" & nfila - 2 & ")"
                        .Range("N15").Value = "=SUMA(N18:N" & nfila - 2 & ")"

                        .Range("T15").Value = "=SUMA(T18:T" & nfila - 2 & ")"
                        .Range("U15").Value = "=SUMA(U18:U" & nfila - 2 & ")"


                        .Range("D" & nfila - 1).Value() = "Totales"
                        .Range("E" & nfila - 1).Value() = "=SUMA(E18:E" & nfila - 2 & ")"
                        .Range("F" & nfila - 1).Value() = "=SUMA(F18:F" & nfila - 2 & ")"
                        .Range("G" & nfila - 1).Value() = "=SUMA(G18:G" & nfila - 2 & ")"
                        .Range("H" & nfila - 1).Value() = "=(F15-F10)/F15"

                        .Range("D" & nfila).Value() = "CPMC"
                        .Range("E" & nfila).Value() = "=E" & nfila - 1 & "/F" & nfila - 1 & ""

                        .Range("K" & nfila - 1).Value() = "Totales"
                        .Range("L" & nfila - 1).Value() = "=SUMA(L18:L" & nfila - 2 & ")"
                        .Range("M" & nfila - 1).Value() = "=SUMA(M18:M" & nfila - 2 & ")"
                        .Range("N" & nfila - 1).Value() = "=SUMA(N18:N" & nfila - 2 & ")"
                        .Range("O" & nfila - 1).Value() = "=(M15-M10)/M15"

                        .Range("K" & nfila).Value() = "CPMC"
                        .Range("L" & nfila).Value() = "=L" & nfila - 1 & "/M" & nfila - 1 & ""

                        .Range("R" & nfila - 1).Value() = "Totales"
                        .Range("S" & nfila - 1).Value() = "=SUMA(S18:S" & nfila - 2 & ")"
                        .Range("T" & nfila - 1).Value() = "=SUMA(T18:T" & nfila - 2 & ")"
                        .Range("U" & nfila - 1).Value() = "=SUMA(U18:U" & nfila - 2 & ")"
                        .Range("V" & nfila - 1).Value() = "=(T15-T10)/T15"

                        .Range("R" & nfila).Value() = "CPMC"
                        .Range("S" & nfila).Value() = "=S" & nfila - 1 & "/T" & nfila - 1 & ""

                        .Range("D" & nfila - 1 & ":Z" & nfila - 1).Font.Bold = True

                        nfila += 1
                        .Range("A16:A" & nfila - 1).Rows.Group()

                        nfila += 1
                        .Range("A" & nfila).Value = "Chancado"

                        Dim ini_chancado As Int32 = nfila + 1

                        .Range("A" & nfila).Font.Bold = True
                        .Range("A" & nfila).Font.Size = 11
                        Dim cod_ruma As String = ""
                        Dim cod_chancadora As String = ""
                        cont = 1
                        If dtDatos2.Rows.Count > 0 Then
                            For i As Int32 = 0 To dtDatos2.Rows.Count - 1
                                If cod_ruma <> dtDatos2.Rows(i)("COD_RUMA") Then
                                    nfila = nfila + 2
                                    .Range("A" & nfila + i).Value = dtDatos2.Rows(i)("RUMA")
                                    .Range("A" & nfila + i).Font.Bold = True
                                    formula2 = formula2 + "+" + "F" & nfila + i
                                    formula1 = "="
                                    formula4 = formula4 & "+F" & nfila + i & "*" & "G" & nfila + i
                                    formula3 = "=("
                                    ini_ruma = nfila + i
                                    cod_ruma = dtDatos2.Rows(i)("COD_RUMA")
                                    cod_chancadora = ""
                                End If
                                If cod_chancadora <> dtDatos2.Rows(i)("COD_CHANCADORA") Then
                                    nfila = nfila + 2
                                    .Range("B" & nfila + i).Value = dtDatos2.Rows(i)("EQUIPO")
                                    .Range("B" & nfila + i & ":" & "Z" & nfila + i).Font.Bold = True
                                    formula1 = formula1 + "+" + "F" & nfila + i
                                    formula3 = formula3 & "+F" & nfila + i & "*" & "G" & nfila + i

                                    cod_chancadora = dtDatos2.Rows(i)("COD_CHANCADORA")
                                    .Range("F" & nfila + i).Value = dtDatos2.Rows(i)("TON_BAJO")
                                    .Range("M" & nfila + i).Value = dtDatos2.Rows(i)("TON_MEDIO")
                                    .Range("T" & nfila + i).Value = dtDatos2.Rows(i)("TON_ALTO")

                                    .Range("C" & nfila + i & ":" & "Z" & nfila + i).NumberFormat = "#,##0.000"

                                    .Range("G" & nfila + i).Value = IIf(dtDatos2.Rows(i)("TON_BAJO") <> 0, "=SUMA(D" & nfila + i + 2 & ":D" & nfila + i + 2 + dtDatos2.Rows(i)("CANT_CONCEPTO") & ")/F" & nfila + i & "", "0.00")

                                    .Range("N" & nfila + i).Value = IIf(dtDatos2.Rows(i)("TON_MEDIO") <> 0, "=SUMA(K" & nfila + i + 2 & ":K" & nfila + i + 2 + dtDatos2.Rows(i)("CANT_CONCEPTO") & ")/M" & nfila + i & "", "0.00")

                                    .Range("U" & nfila + i).Value = IIf(dtDatos2.Rows(i)("TON_ALTO") <> 0, "=SUMA(R" & nfila + i + 2 & ":R" & nfila + i + 2 + dtDatos2.Rows(i)("CANT_CONCEPTO") & ")/T" & nfila + i & "", "0.00")

                                    nfila = nfila + 2
                                End If

                                .Range("F" & ini_ruma).Value = formula1
                                .Range("G" & ini_ruma).Value = formula3 + ")/" & "F" & ini_ruma '& ",0)"
                                .Range("F" & ini_ruma & ":G" & ini_ruma).Select()
                                m_Excel.Selection.Copy()
                                .Range("M" & ini_ruma & ":N" & ini_ruma).Select()
                                .Paste()
                                m_Excel.Selection.Copy()
                                .Range("T" & ini_ruma & ":U" & ini_ruma).Select()
                                .Paste()
                                If .Range("F" & ini_ruma).Value = 0 Then .Range("G" & ini_ruma).Value = "0.00"
                                If .Range("M" & ini_ruma).Value = 0 Then .Range("N" & ini_ruma).Value = "0.00"
                                If .Range("T" & ini_ruma).Value = 0 Then .Range("U" & ini_ruma).Value = "0.00"

                                .Range("B" & nfila + i).Value = dtDatos2.Rows(i)("CONCEPTO")
                                .Range("D" & nfila + i).Value = dtDatos2.Rows(i)("COSTO_BAJO")
                                .Range("G" & nfila + i).Value = dtDatos2.Rows(i)("COSTOXTON_BAJO")

                                .Range("K" & nfila + i).Value = dtDatos2.Rows(i)("COSTO_MEDIO")
                                .Range("N" & nfila + i).Value = dtDatos2.Rows(i)("COSTOXTON_MEDIO")

                                .Range("R" & nfila + i).Value = dtDatos2.Rows(i)("COSTO_ALTO")
                                .Range("U" & nfila + i).Value = dtDatos2.Rows(i)("COSTOXTON_ALTO")

                                cont = cont + 1
                            Next

                            .Range("F" & ini_chancado - 1).Value = formula2
                            .Range("G" & ini_chancado - 1).Value = IIf(.Range("F" & ini_chancado - 1).Value = 0, formula4 + ")/" & "F" & ini_chancado - 1, formula4 + ")/" & "F" & ini_chancado - 1)
                            'If .Range("G" & ini_chancado - 1).Value.ToString = "#¡DIV/0!" Then .Range("G" & ini_chancado - 1).Value = 0
                            .Range("F" & ini_chancado - 1 & ":G" & ini_chancado - 1).Select()
                            m_Excel.Selection.Copy()
                            .Range("M" & ini_chancado - 1 & ":N" & ini_chancado - 1).Select()
                            .Paste()
                            m_Excel.Selection.Copy()
                            .Range("T" & ini_chancado - 1 & ":U" & ini_chancado - 1).Select()
                            .Paste()

                            '.Range("F" & ini_chancado - 2 & ":G" & ini_chancado - 1 & ",M" & ini_chancado - 2 & ",N" & ini_chancado - 2 & ",M" & ini_chancado - 1 & ",N" & ini_chancado - 1 & ",T" & ini_chancado - 2 & ",U" & ini_chancado - 2 & ",T" & ini_chancado - 1 & ",U" & ini_chancado - 1 & "").Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorDark1
                            '.Range("F" & ini_chancado - 2 & ":G" & ini_chancado - 1 & ",M" & ini_chancado - 2 & ",N" & ini_chancado - 2 & ",M" & ini_chancado - 1 & ",N" & ini_chancado - 1 & ",T" & ini_chancado - 2 & ",U" & ini_chancado - 2 & ",T" & ini_chancado - 1 & ",U" & ini_chancado - 1 & "").Interior.TintAndShade = -0.0499893185216834

                        End If

                        nfila = nfila + cont
                        Dim cod_molienda As String = ""

                        formula1 = "="
                        formula2 = "="
                        formula3 = "=("
                        formula4 = "=("
                        nfila += 1
                        .Range("A" & ini_chancado & ":A" & nfila - 1).Rows.Group()
                        nfila += 1
                        .Range("A" & nfila).Value = "Molienda"

                        Dim ini_molienda As Int32 = nfila + 1
                        .Range("A" & nfila).Font.Bold = True
                        .Range("A" & nfila).Font.Size = 11
                        cont = 1

                        If dtDatos3.Rows.Count > 0 Then
                            For i As Int32 = 0 To dtDatos3.Rows.Count - 1
                                If cod_molienda <> dtDatos3.Rows(i)("COD_EQUIPO") Then
                                    nfila = nfila + 2
                                    .Range("B" & nfila + i).Value = dtDatos3.Rows(i)("EQUIPO")
                                    .Range("B" & nfila + i & ":" & "Z" & nfila + i).Font.Bold = True
                                    cod_molienda = dtDatos3.Rows(i)("COD_EQUIPO")

                                    formula1 = formula1 + "+" + "F" & nfila + i
                                    formula3 = formula3 & "+F" & nfila + i & "*" & "G" & nfila + i

                                    .Range("F" & nfila + i).Value = dtDatos3.Rows(i)("TON_BAJO")
                                    .Range("M" & nfila + i).Value = dtDatos3.Rows(i)("TON_MEDIO")
                                    .Range("T" & nfila + i).Value = dtDatos3.Rows(i)("TON_ALTO")

                                    .Range("C" & nfila + i & ":" & "Z" & nfila + i).NumberFormat = "#,##0.000"

                                    .Range("G" & nfila + i).Value = IIf(dtDatos3.Rows(i)("TON_BAJO") <> 0, "=SUMA(D" & nfila + i + 2 & ":D" & nfila + i + 2 + dtDatos3.Rows(i)("CANT_CONCEPTO") & ")/F" & nfila + i & "", "0.00")

                                    .Range("N" & nfila + i).Value = IIf(dtDatos3.Rows(i)("TON_MEDIO") <> 0, "=SUMA(K" & nfila + i + 2 & ":K" & nfila + i + 2 + dtDatos3.Rows(i)("CANT_CONCEPTO") & ")/M" & nfila + i & "", "0.00")

                                    .Range("U" & nfila + i).Value = IIf(dtDatos3.Rows(i)("TON_ALTO") <> 0, "=SUMA(R" & nfila + i + 2 & ":R" & nfila + i + 2 + dtDatos3.Rows(i)("CANT_CONCEPTO") & ")/T" & nfila + i & "", "0.00")

                                    nfila = nfila + 2
                                End If
                                .Range("B" & nfila + i).Value = dtDatos3.Rows(i)("CONCEPTO")
                                .Range("D" & nfila + i).Value = dtDatos3.Rows(i)("COSTO_BAJO")
                                .Range("G" & nfila + i).Value = dtDatos3.Rows(i)("COSTOXTON_BAJO")

                                .Range("K" & nfila + i).Value = dtDatos3.Rows(i)("COSTO_MEDIO")
                                .Range("N" & nfila + i).Value = dtDatos3.Rows(i)("COSTOXTON_MEDIO")

                                .Range("R" & nfila + i).Value = dtDatos3.Rows(i)("COSTO_ALTO")
                                .Range("U" & nfila + i).Value = dtDatos3.Rows(i)("COSTOXTON_ALTO")
                                cont = cont + 1
                            Next
                            nfila = nfila + cont
                            .Range("A" & ini_molienda & ":A" & nfila - 2).Rows.Group()
                            .Range("F" & ini_molienda - 1).Value = formula1
                            .Range("G" & ini_molienda - 1).Value = IIf(.Range("F" & ini_molienda - 1).Value = 0, 0, formula3 + ")/" & "F" & ini_molienda - 1)
                            '.Range("G" & ini_molienda - 1).Value = formula3 + ")/" & "F" & ini_molienda - 1 '& ",0)"
                            .Range("F" & ini_molienda - 1 & ":G" & ini_molienda - 1).Select()
                            m_Excel.Selection.Copy()
                            .Range("M" & ini_molienda - 1 & ":N" & ini_molienda - 1).Select()
                            .Paste()
                            m_Excel.Selection.Copy()
                            .Range("T" & ini_molienda - 1 & ":U" & ini_molienda - 1).Select()
                            .Paste()

                            '.Range("F" & ini_molienda - 2 & ":G" & ini_molienda - 1 & ",M" & ini_molienda - 2 & ",N" & ini_molienda - 2 & ",M" & ini_molienda - 1 & ",N" & ini_molienda - 1 & ",T" & ini_molienda - 2 & ",U" & ini_molienda - 2 & ",T" & ini_molienda - 1 & ",U" & ini_molienda - 1 & "").Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorDark1
                            '.Range("F" & ini_molienda - 2 & ":G" & ini_molienda - 1 & ",M" & ini_molienda - 2 & ",N" & ini_molienda - 2 & ",M" & ini_molienda - 1 & ",N" & ini_molienda - 1 & ",T" & ini_molienda - 2 & ",U" & ini_molienda - 2 & ",T" & ini_molienda - 1 & ",U" & ini_molienda - 1 & "").Interior.TintAndShade = -0.0499893185216834
                        End If

                        'nfila = nfila + cont

                        .Range("A" & nfila).Value = "Costo de Envase"
                        .Range("A" & nfila).Font.Bold = True
                        .Range("A" & nfila).Font.Size = 11
                        cont = 1
                        'COSTO BAJO
                        .Range("F16" & ":F" & nfila).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range("F16" & ":F" & nfila).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range("G16" & ":G" & nfila).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range("F" & nfila & ":G" & nfila).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'COSTO MEDIO
                        .Range("M16" & ":M" & nfila).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range("M16" & ":M" & nfila).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range("N16" & ":N" & nfila).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range("M" & nfila & ":N" & nfila).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        'COSTO ALTO
                        .Range("T16" & ":T" & nfila).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range("T16" & ":T" & nfila).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range("U16" & ":U" & nfila).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range("T" & nfila & ":U" & nfila).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        '.Range("F" & nfila - 1 & ":G" & nfila & ",M" & nfila - 1 & ",N" & nfila - 1 & ",M" & nfila & ",N" & nfila & ",T" & nfila - 1 & ",U" & nfila - 1 & ",T" & nfila & ",U" & nfila & "").Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorDark1
                        '.Range("F" & nfila - 1 & ":G" & nfila & ",M" & nfila - 1 & ",N" & nfila - 1 & ",M" & nfila & ",N" & nfila & ",T" & nfila - 1 & ",U" & nfila - 1 & ",T" & nfila & ",U" & nfila & "").Interior.TintAndShade = -0.0499893185216834
                        '.TintAndShade = 0.799981688894314
                        If dtDatos4.Rows.Count > 0 Then
                            .Range("G" & nfila).Value = dtDatos4.Rows(0)("COSTOENVASE")
                            .Range("N" & nfila).Value = dtDatos4.Rows(1)("COSTOENVASE")
                            .Range("U" & nfila).Value = dtDatos4.Rows(2)("COSTOENVASE")
                            .Range("B" & nfila & ":" & "Z" & nfila).Font.Bold = True
                        End If
                        .Range("A1").Select()
                    End With
                End If
                m_Excel.ActiveSheet.Outline.ShowLevels(RowLevels:=1)
                'm_Excel.Visible = True
                objHojaExcel = Nothing
                m_Excel = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
                m_Excel.Quit()
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Reporte()
    End Sub

    Private Sub FrmCostoAltoBajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtayo.Value = Now.Date.Year
        txtayohasta.Value = Now.Date.Year
    End Sub

    Private Sub txtcodProd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodProd.ValueChanged

    End Sub
End Class