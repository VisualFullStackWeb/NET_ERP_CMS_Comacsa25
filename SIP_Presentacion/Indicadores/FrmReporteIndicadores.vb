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
Public Class FrmReporteIndicadores
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

    Private Sub FrmReporteIndicadores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtayo.Value = Year(Now.Date)
        Me.cmbMesDesde.Value = Month(Now.Date)
    End Sub
    Sub Reporte()
        'Dim m_Excel As Object = CreateObject("Excel.Application")
        If cmbMesDesde.Value Is Nothing Then
            MsgBox("Seleccione mes", MsgBoxStyle.Information)
            Exit Sub
        End If
        'If cmbMesHasta.Value Is Nothing Then
        '    MsgBox("Seleccione mes final", MsgBoxStyle.Information)
        '    Exit Sub
        'End If
        If cmbTipo.Value Is Nothing Then
            MsgBox("Seleccione tipo de indicador", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim tipo As String = cmbTipo.Value.ToString.Trim
        If tipo = "PR" Then
            Ind_Produccion(tipo)
        End If
        If tipo = "EE" Then
            Ind_Energia(tipo)
        End If
        If tipo = "DE" Then
            Ind_Devoluciones(tipo)
        End If
        If tipo = "VA" Then
            Ind_Varios(tipo)
        End If
    End Sub

    Sub Ind_Varios(ByVal tipo As String)
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtDatos As New DataTable
            Dim dtDatosTot As New DataTable
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
            dsDatos = _objNegocio.INDICADOR_VARIOS(_objEntidad)
            dtDatos = dsDatos.Tables(0)
            dtDatosTot = dsDatos.Tables(2)

            'dtDatosResumen = dsDatos.Tables(1)
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\INDICADOR_VARIOS_" & cmbMesDesde.Text & ".xls")
                File.Copy(RutaReporteERP & "PLANTILLAINDICADOR_VARIOS.xls", path & "\INDICADOR_VARIOS_" & cmbMesDesde.Text & ".xls")
                m_Excel.Workbooks.Open(path & "\INDICADOR_VARIOS_" & cmbMesDesde.Text & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                Dim objHojaExcel2 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
                Dim objHojaExcel3 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
                Dim objHojaExcel4 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 5
                nfilaini = 5
                nfilaini = 5
                Dim filaultima As Int32 = 0
                With objHojaExcel
                    .Activate()
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDatos.Rows(i)("NOMBRE_MES")
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("EQUIPO")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("VALORBI")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("TON")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("MO_TON")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("VALORBASICO")
                        filaultima = nfila + i
                    Next

                    For i As Int16 = 0 To dtDatosTot.Rows.Count - 1
                        .Range("H" & nfila + i).Value = dtDatosTot.Rows(i)("NOMBRE_MES")
                        .Range("I" & nfila + i).Value = dtDatosTot.Rows(i)("TON")
                        .Range("J" & nfila + i).Value = dtDatosTot.Rows(i)("VALORBI")
                        .Range("K" & nfila + i).Value = dtDatosTot.Rows(i)("VALORSINPROD")
                        .Range("L" & nfila + i).Value = dtDatosTot.Rows(i)("INDICADOR_PROD")
                        .Range("M" & nfila + i).Value = dtDatosTot.Rows(i)("INDICADOR_IND")
                        .Range("N" & nfila + i).Value = dtDatosTot.Rows(i)("INDICADOR")
                        filaultima = nfila + i
                    Next

                End With

                With objHojaExcel2
                    '.Activate()
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtDatos.Rows(i)("NOMBRE_MES")
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("EQUIPO")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("TON")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("CANT_TON")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("TIPO")
                        filaultima = nfila + i
                    Next

                    dtDatosTot = dsDatos.Tables(3)
                    For i As Int16 = 0 To dtDatosTot.Rows.Count - 1
                        .Range("H" & nfila + i).Value = dtDatosTot.Rows(i)("NOMBRE_MES")
                        .Range("I" & nfila + i).Value = dtDatosTot.Rows(i)("CANTIDAD")
                        .Range("J" & nfila + i).Value = dtDatosTot.Rows(i)("TON")
                        .Range("K" & nfila + i).Value = dtDatosTot.Rows(i)("CANT_TON")
                        .Range("L" & nfila + i).Value = dtDatosTot.Rows(i)("CANTIDAD_TOTAL")
                        .Range("M" & nfila + i).Value = "=J" & nfila + i & "/L" & nfila + i & ""
                        .Range("N" & nfila + i).Value = "=J" & nfila + i & "/(L" & nfila + i & "+I" & nfila + i & ")"
                        filaultima = nfila + i
                    Next

                End With

                dtDatos = dsDatos.Tables(1)
                If dtDatos.Rows.Count > 0 Then
                    lblmensaje.Text = "Generando Reporte..."
                    lblmensaje.Refresh()
                    nfila = 5
                    nfilaini = 5
                    nfilaini = 5
                    filaultima = 0
                    With objHojaExcel3
                        '.Activate()
                        For i As Int16 = 0 To dtDatos.Rows.Count - 1
                            .Range("A" & nfila + i).Value = dtDatos.Rows(i)("NOMBRE_MES")
                            .Range("B" & nfila + i).Value = dtDatos.Rows(i)("EQUIPO")
                            .Range("C" & nfila + i).Value = dtDatos.Rows(i)("DIASPARA")
                            .Range("D" & nfila + i).Value = dtDatos.Rows(i)("DIAS")
                            .Range("E" & nfila + i).Value = dtDatos.Rows(i)("DIAS_AYO")
                            .Range("F" & nfila + i).Value = dtDatos.Rows(i)("IND_HORAPERDIDA")
                            filaultima = nfila + i
                        Next
                    End With

                    With objHojaExcel4
                        '.Activate()
                        For i As Int16 = 0 To dtDatos.Rows.Count - 1
                            .Range("A" & nfila + i).Value = dtDatos.Rows(i)("NOMBRE_MES")
                            .Range("B" & nfila + i).Value = dtDatos.Rows(i)("EQUIPO")
                            .Range("C" & nfila + i).Value = dtDatos.Rows(i)("HORASPARA")
                            .Range("D" & nfila + i).Value = dtDatos.Rows(i)("HORA_PRODUCIDA")
                            .Range("E" & nfila + i).Value = dtDatos.Rows(i)("HORA_PARA_PRODUCIDA")
                            .Range("F" & nfila + i).Value = dtDatos.Rows(i)("HSINBILLETE")
                            .Range("G" & nfila + i).Value = dtDatos.Rows(i)("DISPONIBILIDAD")
                            filaultima = nfila + i
                        Next
                    End With
                End If

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

    Sub Ind_Produccion(ByVal tipo As String)
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtDatos As New DataTable
            Dim dtDatosResumen As New DataTable

            Dim dtParadaCab As New DataTable
            Dim dtParadaDet As New DataTable

            Dim mes_ini As Int32 = cmbMesDesde.Value
            Dim mes_final As Int32 = cmbMesDesde.Value

            Dim dsDatos As New DataSet
            dtDatos = New DataTable
            dtDatosResumen = New DataTable
            dtParadaCab = New DataTable
            dtParadaDet = New DataTable

            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = mes_ini
            _objEntidad.Mes1 = mes_final
            _objEntidad.Usuario = userLogin
            dsDatos = _objNegocio.INDICADOR_PRODUCCION(_objEntidad)
            dtDatos = dsDatos.Tables(0)
            dtDatosResumen = dsDatos.Tables(1)
            dtParadaCab = dsDatos.Tables(2)
            dtParadaDet = dsDatos.Tables(3)

            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\INDICADOR_PRODUCCION_" & cmbMesDesde.Text & ".xls")
                File.Copy(RutaReporteERP & "PLANTILLAINDICADOR_PRODUCCION.xls", path & "\INDICADOR_PRODUCCION_" & cmbMesDesde.Text & ".xls")
                m_Excel.Workbooks.Open(path & "\INDICADOR_PRODUCCION_" & cmbMesDesde.Text & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
                Dim objHojaExcelResumen As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
                Dim objHojaExcelParada As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)

                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 3
                nfilaini = 3
                nfilaini = 3
                Dim filaultima As Int32 = 0
                Dim MODELO As String = dtDatos.Rows(0)("MODELO")
                With objHojaExcel
                    .Activate()
                    '.Range("B2").Value = "COSTO DE MINAS CANTERA: "
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        '.Range("C" & nfila + i).Value = dtDatos.Rows(i)("MODELO")
                        If i = 0 Then
                            .Range("A" & nfila + i).Value = dtDatos.Rows(i)("PLANTA")
                            .Range("B" & nfila + i).Value = dtDatos.Rows(i)("COD_EQUIPO")
                            .Range("C" & nfila + i).Value = dtDatos.Rows(i)("MODELO")
                        Else
                            If dtDatos.Rows(i)("MODELO") <> dtDatos.Rows(i - 1)("MODELO") Then
                                nfilault = nfila + i
                                '.Range("A" & nfila + i).Value = dtDatos.Rows(i)("PLANTA")
                                .Range("D" & nfilault).Value = "SUB TOTAL"
                                .Range("P" & nfilault).Value = "=SUMA(P" & nfilaini & ":P" & nfilault - 1 & ")"
                                .Range("R" & nfilault).Value = "=SUMA(R" & nfilaini & ":R" & nfilault - 1 & ")"
                                .Range("S" & nfilault).Value = "=SUMA(S" & nfilaini & ":S" & nfilault - 1 & ")"
                                .Range("T" & nfilault).Value = "=S" & nfilault & "/R" & nfilault & ""
                                .Range("U" & nfilault).Value = "=1-T" & nfilault & ""
                                .Cells.Range("D" & nfilault & ":U" & nfilault).Font.Bold = True
                                .Range("C" & nfilaini & ":U" & nfilault).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                .Range("C" & nfilault & ":U" & nfilault).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                .Range("C" & nfilaini & ":U" & nfilault).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                .Range("C" & nfilaini & ":U" & nfilault).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                .Range("C" & nfilaini & ":U" & nfilault).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                                nfila = nfila + 3
                                nfilaini = nfila + i
                                .Range("B" & nfila + i).Value = dtDatos.Rows(i)("COD_EQUIPO")
                                .Range("C" & nfila + i).Value = dtDatos.Rows(i)("MODELO")
                                MODELO = dtDatos.Rows(i)("MODELO")
                            End If
                        End If
                        .Range("A" & nfila + i).Value = dtDatos.Rows(i)("PLANTA")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("COD_PROD")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("PRODUCTO")
                        .Range("L" & nfila + i).Value = dtDatos.Rows(i)("OPTIMA")
                        .Range("P" & nfila + i).Value = dtDatos.Rows(i)("EFECTIVA")
                        .Range("Q" & nfila + i).Value = dtDatos.Rows(i)("HRPARADA")
                        .Range("R" & nfila + i).Value = "=P" & nfila + i & "*L" & nfila + i & ""
                        .Range("S" & nfila + i).Value = dtDatos.Rows(i)("TLNPRODUCIDAS")
                        If .Range("R" & nfila + i).Value = 0 Then
                            .Range("T" & nfila + i).Value = 0
                        Else
                            .Range("T" & nfila + i).Value = "=S" & nfila + i & "/R" & nfila + i & ""
                        End If

                        .Range("U" & nfila + i).Value = "=1-T" & nfila + i & ""
                        '.Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                    filaultima += 1
                    nfilault += 3
                    .Range("D" & filaultima).Value = "SUB TOTAL"
                    .Range("P" & filaultima).Value = "=SUMA(P" & nfilault & ":P" & filaultima - 1 & ")"
                    .Range("R" & filaultima).Value = "=SUMA(R" & nfilault & ":R" & filaultima - 1 & ")"
                    .Range("S" & filaultima).Value = "=SUMA(S" & nfilault & ":S" & filaultima - 1 & ")"
                    .Range("T" & filaultima).Value = "=S" & filaultima & "/R" & filaultima & ""
                    .Range("U" & filaultima).Value = "=1-T" & filaultima & ""
                    .Cells.Range("D" & filaultima & ":U" & filaultima).Font.Bold = True

                    .Range("C" & nfilault & ":U" & filaultima).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("C" & filaultima & ":U" & filaultima).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("C" & nfilault & ":U" & filaultima).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("C" & nfilault & ":U" & filaultima).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("C" & nfilault & ":U" & filaultima).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                End With


                nfila = 3
                nfilaini = 3
                filaultima = 0
                With objHojaExcelResumen
                    '.Activate()

                    For i As Int16 = 0 To dtDatosResumen.Rows.Count - 1
                        .Range("a" & nfila + i).Value = dtDatosResumen.Rows(i)("NOMBRE_MES")
                        .Range("B" & nfila + i).Value = dtDatosResumen.Rows(i)("MODELO")
                        .Range("D" & nfila + i).Value = dtDatosResumen.Rows(i)("TEORICO")
                        .Range("E" & nfila + i).Value = dtDatosResumen.Rows(i)("REAL")
                        If dtDatosResumen.Rows(i)("TEORICO") = 0 Then
                            .Range("F" & nfila + i).Value = 0
                        Else
                            .Range("F" & nfila + i).Value = "=E" & nfila + i & "/D" & nfila + i & ""
                        End If


                        .Range("G" & nfila + i).Value = "=1-F" & nfila + i & ""
                        .Range("H" & nfila + i).Value = dtDatosResumen.Rows(i)("DISPONIBILIDAD")
                        .Range("I" & nfila + i).Value = "=F" & nfila + i & "*H" & nfila + i & ""
                        filaultima = nfila + i
                    Next
                    .Cells.Range("B" & filaultima + 2 & ":G" & filaultima + 2).Font.Bold = True
                    .Range("B" & filaultima + 2 & ":G" & filaultima + 2).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("B" & filaultima + 2 & ":G" & filaultima + 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                    .Range("B" & filaultima + 2).Value = "TOTAL"
                    .Range("D" & filaultima + 2).Value = "=SUMA(D" & nfila & ":D" & filaultima & ")"
                    .Range("E" & filaultima + 2).Value = "=SUMA(E" & nfila & ":E" & filaultima & ")"
                    .Range("F" & filaultima + 2).Value = "=E" & filaultima + 2 & "/D" & filaultima + 2 & ""
                    .Range("G" & filaultima + 2).Value = "=1-F" & filaultima + 2 & ""
                End With

                nfila = 10
                nfilaini = 10
                filaultima = 0
                Dim restar As Int32 = 0

                With objHojaExcelParada
                    .Range("B" & 9).Value = "MODELO" 'dtParadaDet.Rows(i)("MODELO")
                    .Range("C" & 9).Value = "HORASPARA" 'dtParadaDet.Rows(i)("HORASPARA")
                    .Range("D" & 9).Value = "FEC_EMISION" 'dtParadaDet.Rows(i)("FEC_EMISION")
                    .Range("E" & 9).Value = "COD_MOT" 'dtParadaDet.Rows(i)("COD_MOT")
                    .Range("F" & 9).Value = "DESCRIP" 'dtParadaDet.Rows(i)("DESCRIP")
                    For i As Int16 = 0 To dtParadaDet.Rows.Count - 1
                        .Range("A" & nfila + i).Value = dtParadaDet.Rows(i)("COD_EQUIPO")
                        .Range("B" & nfila + i).Value = dtParadaDet.Rows(i)("MODELO")
                        .Range("C" & nfila + i).Value = dtParadaDet.Rows(i)("HORASPARA")
                        .Range("D" & nfila + i).Value = dtParadaDet.Rows(i)("FEC_EMISION")
                        .Range("E" & nfila + i).Value = dtParadaDet.Rows(i)("COD_MOT")
                        .Range("F" & nfila + i).Value = dtParadaDet.Rows(i)("DESCRIP")
                        '.Range("G" & nfila + i).Value = "=1-F" & nfila + i & ""
                        '.Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                    .Activate()

                    Dim fila As Int32 = dtParadaDet.Rows.Count + 9
                    .Range("A9:F" & fila & "").Select()
                    m_Excel.Sheets.Add()
                    m_Excel.ActiveWorkbook.PivotCaches.Create(SourceType:=Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlDatabase, SourceData:= _
                        "Paradas!R9C2:R" & fila & "C6").CreatePivotTable( _
                        TableDestination:="Hoja1!R4C1", TableName:="Tabla dinámica1")
                    m_Excel.Sheets("Hoja1").Select()
                    m_Excel.Cells(4, 1).Select()
                    'm_Excel.ActiveWindow.SmallScroll(Down:=-3)
                    m_Excel.ActiveSheet.PivotTables("Tabla dinámica1").AddDataField(m_Excel.ActiveSheet.PivotTables _
                        ("Tabla dinámica1").PivotFields("HORASPARA"), "Suma de HORASPARA", Excel.XlConsolidationFunction.xlSum)
                    With m_Excel.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("MODELO")
                        .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 1
                    End With
                    With m_Excel.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("FEC_EMISION")
                        .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                        .Position = 2
                    End With
                    With m_Excel.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("DESCRIP")
                        .Orientation = Excel.XlPivotFieldOrientation.xlColumnField
                        .Position = 1
                    End With
                    m_Excel.Range("A2").Value = "DETALLE DE PARADAS"
                    m_Excel.Range("A2").Font.Bold = True
                    m_Excel.Range("A2:E2").Merge()
                End With
                Dim objHojaExcelParadaDet As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(5)
                objHojaExcelParadaDet.Visible = Excel.XlSheetVisibility.xlSheetHidden
                objHojaExcelParadaDet = m_Excel.Worksheets(4)
                objHojaExcelParadaDet.Name = "Detalle Paradas"
                objHojaExcel.Activate()
                'Dim nro_mes As Integer = cmbMesDesde.Value
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
    Function obtener_Letra(ByVal num As Int32) As String
        Dim letra As String = ""
        Select Case num
            Case 4
                letra = "D"
            Case 5
                letra = "E"
            Case 6
                letra = "F"
            Case 7
                letra = "G"
            Case 8
                letra = "H"
            Case 9
                letra = "I"
            Case 10
                letra = "J"
            Case 11
                letra = "K"
            Case 12
                letra = "L"
            Case 13
                letra = "M"
            Case 14
                letra = "N"
            Case 15
                letra = "O"
            Case 16
                letra = "P"
            Case Else
                letra = "Q"
        End Select
        Return letra
    End Function

    Sub Ind_Energia(ByVal tipo As String)
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
            _objEntidad.Mes1 = mes_final
            _objEntidad.Usuario = userLogin
            dsDatos = _objNegocio.INDICADOR_ENERGIA(_objEntidad)
            dtDatos = dsDatos.Tables(0)
            'dtDatosResumen = dsDatos.Tables(1)
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\INDICADOR_ENERGIA_" & cmbMesDesde.Text & ".xls")
                File.Copy(RutaReporteERP & "PLANTILLAINDICADOR_ENERGIA.xls", path & "\INDICADOR_ENERGIA_" & cmbMesDesde.Text & ".xls")
                m_Excel.Workbooks.Open(path & "\INDICADOR_ENERGIA_" & cmbMesDesde.Text & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                'Dim objHojaExcelResumen As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 4
                nfilaini = 4
                nfilaini = 4
                Dim filaultima As Int32 = 0
                Dim MODELO As String = dtDatos.Rows(0)("MODELO")
                With objHojaExcel
                    .Activate()
                    .Range("E2").Value = "AÑO " & txtayo.Value 'cmbMesDesde.Text.ToString.ToUpper
                    Dim fila As Int32 = 4
                    Dim colum As Int32 = 0
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        '.Range("B" & nfila + i).Value = dtDatos.Rows(i)("MODELO")
                        '.Range("E" & nfila + i).Value = dtDatos.Rows(i)("TONELADAS")
                        '.Range("F" & nfila + i).Value = dtDatos.Rows(i)("KWH")
                        .Range(.Cells(fila, 1 + colum), .Cells(fila, 1 + colum)).Value = dtDatos.Rows(i)("NOMBRE_MES")
                        .Range(.Cells(fila, 2 + colum), .Cells(fila, 2 + colum)).Value = dtDatos.Rows(i)("MODELO")
                        .Range(.Cells(fila, 5 + colum), .Cells(fila, 5 + colum)).Value = dtDatos.Rows(i)("TONELADAS")
                        .Range(.Cells(fila, 6 + colum), .Cells(fila, 6 + colum)).Value = dtDatos.Rows(i)("KWH")


                        'If dtDatos.Rows(i)("TONELADAS") = 0 Then
                        '    '.Range("G" & nfila + i).Value = "0"
                        '    .Range(.Cells(fila, 2), .Cells(fila, 2)).Value = 0
                        'Else
                        '    .Range("G" & nfila + i).Value = "=F" & nfila + i & "/E" & nfila + i & ""
                        'End If
                        .Range(.Cells(fila, 7 + colum), .Cells(fila, 7 + colum)).Value = dtDatos.Rows(i)("KW_TON")
                        If dtDatos.Rows(i)("TONELADAS") = 0 Or dtDatos.Rows(i)("COSTOKWH") = 0 Then
                            .Range(.Cells(fila, 8 + colum), .Cells(fila, 8 + colum)).Value = 0
                            '.Range("H" & nfila + i).Value = "0"
                        Else
                            '.Range("H" & nfila + i).Value = "=F" & nfila + i & "*" & dtDatos.Rows(i)("COSTOKWH") & "/E" & nfila + i & ""
                            .Range(.Cells(fila, 8 + colum), .Cells(fila, 8 + colum)).Value = "=F" & nfila + i & "*" & dtDatos.Rows(i)("COSTOKWH") & "/E" & nfila + i & ""
                        End If

                        filaultima = nfila + i
                        fila += 1
                        'If i < dtDatos.Rows.Count - 1 Then
                        '    If dtDatos.Rows(i)("MES") <> dtDatos.Rows(i + 1)("MES") Then
                        '        colum += 1
                        '    End If
                        'End If
                    Next
                    .Range("B" & filaultima + 2).Value = "TOTAL"
                    .Range("E" & filaultima + 2).Value = "=SUMA(E" & nfila & ":E" & filaultima & ")"
                    .Range("F" & filaultima + 2).Value = "=SUMA(F" & nfila & ":F" & filaultima & ")"
                    .Range("I" & filaultima + 2).Value = "=SUMA(I" & nfila & ":I" & filaultima & ")"
                    .Range("J" & filaultima + 2).Value = "=SUMA(J" & nfila & ":J" & filaultima & ")"
                    .Cells.Range("B" & filaultima + 2 & ":J" & filaultima + 2).Font.Bold = True
                    .Range("B" & filaultima + 2 & ":J" & filaultima + 2).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("B" & filaultima + 2 & ":J" & filaultima + 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
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

    Private Sub btnReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Reporte()
    End Sub

    Sub Ind_Devoluciones(ByVal tipo As String)
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
            dsDatos = _objNegocio.INDICADOR_DEVOLUCION(_objEntidad)
            dtDatos = dsDatos.Tables(0)
            'dtDatosResumen = dsDatos.Tables(1)
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\INDICADOR_DEVOLUCIONES_" & cmbMesDesde.Text & ".xls")
                File.Copy(RutaReporteERP & "PLANTILLAINDICADOR_DEVOLUCIONES.xls", path & "\INDICADOR_DEVOLUCIONES_" & cmbMesDesde.Text & ".xls")
                m_Excel.Workbooks.Open(path & "\INDICADOR_DEVOLUCIONES_" & cmbMesDesde.Text & ".xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                'Dim objHojaExcelResumen As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
                m_Excel.DisplayAlerts = False
                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 5
                nfilaini = 5
                nfilaini = 5
                Dim filaultima As Int32 = 0
                'Dim MODELO As String = dtDatos.Rows(0)("MODELO")
                With objHojaExcel
                    .Activate()
                    .Range("B2").Value = "TONELDAS DEVUELTAS EN EL MES DE " & cmbMesDesde.Text.ToString.ToUpper
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("NUMDOC")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("FEC_EMISION")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("COD_CLI")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("CLIENTE")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("COD_PRODPDC")
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("DESCRIP")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("TLNDEVOLUCION")
                        
                        '.Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                    .Range("G" & filaultima + 2).Value = "TOTAL"
                    .Range("H" & filaultima + 2).Value = "=SUMA(H" & nfila & ":H" & filaultima & ")"
                    '.Range("F" & filaultima + 2).Value = "=SUMA(F" & nfila & ":F" & filaultima & ")"
                    '.Range("I" & filaultima + 2).Value = "=SUMA(I" & nfila & ":I" & filaultima & ")"
                    '.Range("J" & filaultima + 2).Value = "=SUMA(J" & nfila & ":J" & filaultima & ")"
                    .Cells.Range("G" & filaultima + 2 & ":H" & filaultima + 2).Font.Bold = True
                    .Range("G" & filaultima + 2 & ":H" & filaultima + 2).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("G" & filaultima + 2 & ":H" & filaultima + 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
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