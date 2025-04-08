Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text

Public Class FrmConsultaSaldos
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
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
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private lineacredito As Double = 0
    Dim esDevolucion As Int32 = 0
#End Region
    Private Sub FrmConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpfecha.Value = Now.Date
        'Call CargarDatos()
        'Call CargarDatosAprobados()
    End Sub
  
    Private Sub CargarDatos()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Try
            TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.TipoOperacion = Ope
            Entidad.Entregas.Usuario = User_Sistema
            Entidad.Entregas.Fecha = dtpfecha.Value
            Negocio.NEntregas = New NGEntregas
            Entidad.MyLista = New ETMyLista
            Ls_Entrega = Nothing
            Ls_Entrega = New List(Of ETEntregas)
            Ls_EntregaDetalle = Nothing
            Ls_EntregaDetalle = New List(Of ETEntregas)
            Ls_DetalleComp = New List(Of ETEntregas)

            Entidad.MyLista = Negocio.NEntregas.ConsultaSaldos(Entidad.Entregas)
            If Entidad.MyLista.Validacion Then
                Ls_Entrega = Entidad.MyLista.Ls_Entrega
            End If
            Call CargarUltraGridxBinding(Me.GridConsultas, Source1, Ls_Entrega)
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub
    Private Sub CargarDatosAprobados()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Try
            'TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.TipoOperacion = Ope
            Entidad.Entregas.Usuario = User_Sistema
            Entidad.Entregas.Fecha = dtpfecha.Value
            Negocio.NEntregas = New NGEntregas
            Entidad.MyLista = New ETMyLista
            Ls_Entrega = Nothing
            Ls_Entrega = New List(Of ETEntregas)
            Ls_EntregaDetalle = Nothing
            Ls_EntregaDetalle = New List(Of ETEntregas)
            Ls_DetalleComp = New List(Of ETEntregas)
            Entidad.MyLista = Negocio.NEntregas.ConsultaSaldosAprobados(Entidad.Entregas)
            If Entidad.MyLista.Validacion Then
                Ls_Entrega = Entidad.MyLista.Ls_Entrega
            End If
            Call CargarUltraGridxBinding(Me.Grid2, Source2, Ls_Entrega)
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Private Sub GridConsultas_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridConsultas.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "CodTrabajador" OrElse uColumn.Key = "Motivo" _
                    OrElse uColumn.Key = "NomTrabajador" OrElse uColumn.Key = "montoTotal") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Sub actualizar()
        Call CargarDatos()
    End Sub
    Sub cancelar()
       
    End Sub

    Private Sub GridConsultas_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridConsultas.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot GridConsultas Then Return

        If e.Row.IsFilterRow Then Return

        'e.Row.Fixed = Boolean.TrueString
   
        SubProceso_Entregas(e.Row)
    End Sub
    Sub PROCESAR()
        'CargarDatos()
        CargarDatosAprobados()
        Morosidad()
    End Sub
    Sub Morosidad()
        Dim fecha1 As Date = dtpfecha.Value
        Dim fecha2 As Date = Now.Date
        fecha1 = fecha1.ToString("dd/MM/yyyy")
        fecha2 = fecha2.ToString("dd/MM/yyyy")

        If fecha2.CompareTo(fecha1) < 0 Then
            MsgBox("No puede ingresar fecha posterior a la actual", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
        End If

        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DsReporte As DataSet = Nothing
        Dim DtMorisidad As DataTable = Nothing
        Dim DtSemanal As DataTable = Nothing
        Dim DtMensual As DataTable = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Procesando reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .Fecha = dtpfecha.Value
                .User_Crea = User_Sistema
            End With
            DsReporte = oPrvFisN.DatosMorosidadAp(oPrvFisE)
            DtMorisidad = DsReporte.Tables(0)

            Call CargarUltraGridxBinding(Grid1, Source4, DtMorisidad)
            lblmensaje.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub

    Private Function ValidaLineacredito(ByVal codTrabajador As String) As Boolean
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.CodTrabajador = codTrabajador
        Entidad.MyLista = Negocio.NEntregas.ValidaLineacredito(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Ls_Entrega.Count > 0 Then
            lineacredito = Entidad.MyLista.Ls_Entrega.Item(0).lineacredito
            Return True
        Else
            Return False
        End If
    End Function
    'Dim disponible As Double
    Sub SubProceso_Entregas(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.MyLista = New ETMyLista
        Entidad.Entregas.CodTrabajador = uRow.Cells("CodTrabajador").Value
     
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.Entregas.Tipo = 1

    End Sub

    Private Sub GridConsultaDetalle_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs)
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If e.Row.IsFilterRow Then Return
        SubProceso_Detalle(e.Row)
    End Sub

    Private Sub GridConsultaDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "NumSolicitud" OrElse uColumn.Key = "Fecha" OrElse uColumn.Key = "montoParcial" _
                    OrElse uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "Motivo" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "moneda") Then 'OrElse uColumn.Key = "NumDoc"
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Sub SubProceso_Detalle(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If

        'Gpb1.Enabled = False

        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista

        Entidad.MyLista = Negocio.NEntregas.UsuarioAprobacion(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        nroSolicitud = uRow.Cells("NumSolicitud").Value

        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
  

    Private Sub gridDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "fechaComp" OrElse uColumn.Key = "TipoDoc" OrElse uColumn.Key = "NumDoc" OrElse _
                    uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Razon" OrElse uColumn.Key = "Serie") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Sub Reporte()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            If TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString Then
                ReporteGeneral()
            ElseIf TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString Then
                ReporteDetalle()
            Else
                ReporteMorosidad()
            End If
        Catch ex As Exception
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Sub ReporteMorosidad()
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No existen datos para el reporte", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try

            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\MOROSIDAD.xls")
            File.Copy(RutaReporteERP & "PLANTILLAMOROSIDADAP.xls", path & "\MOROSIDAD.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\MOROSIDAD.xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcelDetalle As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            'Dim objHojaExcelSemana As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            'Dim objHojaExcelMes As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            Dim objHojaExcelDetalle_2 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)

            exportarDetalle(objHojaExcelDetalle, m_Excel)
            exportarDetalle_2(objHojaExcelDetalle_2, m_Excel)

            m_Excel.Visible = True
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub
    Sub exportarDetalle(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal m_excel As Microsoft.Office.Interop.Excel.Application)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A5").Value = mesNumero(Month(dtpfecha.Value)) & " - " & Year(dtpfecha.Value)
                .Range("K6").Value = Now.Date
                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 1)).Value = i + 1
                    .Range(.Cells(9 + i, 2), .Cells(9 + i, 2)).Value = Grid1.Rows(i).Cells("CODIGO").Value
                    .Range(.Cells(9 + i, 3), .Cells(9 + i, 3)).Value = Grid1.Rows(i).Cells("TRABAJADOR").Value
                    .Range(.Cells(9 + i, 3), .Cells(9 + i, 4)).Merge()
                    .Range(.Cells(9 + i, 5), .Cells(9 + i, 5)).Value = Grid1.Rows(i).Cells("AREA").Value
                    .Range(.Cells(9 + i, 6), .Cells(9 + i, 6)).Value = Grid1.Rows(i).Cells("0_DIAS").Value
                    .Range(.Cells(9 + i, 7), .Cells(9 + i, 7)).Value = Grid1.Rows(i).Cells("1_10_DIAS").Value
                    .Range(.Cells(9 + i, 8), .Cells(9 + i, 8)).Value = Grid1.Rows(i).Cells("11_18_DIAS").Value
                    .Range(.Cells(9 + i, 9), .Cells(9 + i, 9)).Value = Grid1.Rows(i).Cells("19_26_DIAS").Value
                    .Range(.Cells(9 + i, 10), .Cells(9 + i, 10)).Value = Grid1.Rows(i).Cells("27_34_DIAS").Value
                    '.Range(.Cells(9 + i, 10), .Cells(9 + i, 10)).Value = Grid1.Rows(i).Cells("35_MAS_DIAS").Value

                    .Range(.Cells(9 + i, 11), .Cells(9 + i, 11)).Formula = "=H" & 9 + i & "+I" & 9 + i & "+J" & 9 + i & ""
                    .Range(.Cells(9 + i, 12), .Cells(9 + i, 12)).Formula = "=F" & 9 + i & "+G" & 9 + i & "+K" & 9 + i & ""
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 12)).WrapText = False
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    ultFila = i + 9
                Next
                .Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 12)).Font.Bold = True
                .Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 12)).Font.Bold = True
                .Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 5)).Merge()
                .Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 5)).Merge()
                .Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 5)).Value = "TOTALES"
                .Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 5)).Value = "% POR COBRAR"

                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 5)).Formula = "=SUMA(E9:E" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 6), .Cells(1 + ultFila, 6)).Formula = "=SUMA(F9:F" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 7), .Cells(1 + ultFila, 7)).Formula = "=SUMA(G9:G" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 8), .Cells(1 + ultFila, 8)).Formula = "=SUMA(H9:H" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 9), .Cells(1 + ultFila, 9)).Formula = "=SUMA(I9:I" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 10), .Cells(1 + ultFila, 10)).Formula = "=SUMA(J9:J" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 11), .Cells(1 + ultFila, 11)).Formula = "=H" & 1 + ultFila & "+I" & 1 + ultFila & "+J" & 1 + ultFila & ""
                .Range(.Cells(1 + ultFila, 12), .Cells(1 + ultFila, 12)).Formula = "=F" & 1 + ultFila & "+G" & 1 + ultFila & "+K" & 1 + ultFila & ""

                '.Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 5)).Formula = "=+E" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 6), .Cells(2 + ultFila, 6)).Formula = "=+F" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 7), .Cells(2 + ultFila, 7)).Formula = "=+G" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 8), .Cells(2 + ultFila, 8)).Formula = "=+H" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 9), .Cells(2 + ultFila, 9)).Formula = "=+I" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 10), .Cells(2 + ultFila, 10)).Formula = "=+J" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 11), .Cells(2 + ultFila, 11)).Formula = "=+K" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 12), .Cells(2 + ultFila, 12)).Formula = "=+L" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 11)).NumberFormat = "0.00%" 'NumberFormat = "0.00%" '"0.00%;[Red]-0.00%"

                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 10)).Merge()
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 8)).Value = "INDICE DE MOROSIDAD"
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 8)).Font.Size = 11
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 11)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 11)).Font.Bold = True
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).NumberFormat = "0.00%"
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).Font.Size = 11
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).Formula = "=+K" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Rows(5 + ultFila & ":" & 5 + ultFila).Select()
                'If 4 + ultFila > 43 Then
                For i As Int32 = 0 To 54 - ultFila
                    m_excel.Selection.Delete(Shift:=Excel.XlDirection.xlUp)
                    'm_excel.Selection.Insert(Shift:=Excel.XlDirection.xlDown)
                Next
                'End If
                'Selection.Delete(Shift:=xlUp)
                .Range("A7").Select()
                'm_excel.Selection.Insert(Shift:=Excel.XlDirection.xlDown)
                '.Rows(4 + ultFila & ":" & 4 + ultFila).Selection.Insert(Shift:=.xlDown, CopyOrigin:=.xlFormatFromLeftOrAbove)
                '.Rows(4 + ultFila & ":" & 4 + ultFila).Selection.Insert(Shift:=.xlDown, CopyOrigin:=.xlFormatFromLeftOrAbove)
                '.Rows(4 + ultFila & ":" & 4 + ultFila).Selection.Insert(Shift:=.xlDown, CopyOrigin:=.xlFormatFromLeftOrAbove)
                'Selection.Insert(Shift:=.xlDown, CopyOrigin:=.xlFormatFromLeftOrAbove)
                Dim sort As Excel.Sort = objHojaExcel.Sort

                With sort
                    .SortFields.Clear()
                    .SortFields.Add(objHojaExcel.Range("K9"), Excel.XlSortOn.xlSortOnValues, _
                        Excel.XlSortOrder.xlDescending, Excel.XlSortDataOption.xlSortNormal)
                    .SortFields.Add(objHojaExcel.Range("L9"), Excel.XlSortOn.xlSortOnValues, _
                       Excel.XlSortOrder.xlDescending, Excel.XlSortDataOption.xlSortNormal)
                    .SetRange(objHojaExcel.Range("A9:L" & ultFila & ""))
                    .MatchCase = False
                    .Header = Excel.XlYesNoGuess.xlNo
                    .Orientation = Excel.XlSortOrientation.xlSortColumns
                    .SortMethod = Excel.XlSortMethod.xlPinYin
                    .Apply()
                End With

                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 1)).Value = i + 1
                Next

            End With
        Catch ex As Exception

        End Try
    End Sub

    Sub exportarDetalle_2(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet, ByVal m_excel As Microsoft.Office.Interop.Excel.Application)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0
            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A5").Value = mesNumero(Month(dtpfecha.Value)) & " - " & Year(dtpfecha.Value)
                .Range("K6").Value = Now.Date
                .Range("Q7").Value = "SALDO AL " & Now.Date & ""
                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 1)).Value = i + 1
                    .Range(.Cells(9 + i, 2), .Cells(9 + i, 2)).Value = Grid1.Rows(i).Cells("CODIGO").Value
                    .Range(.Cells(9 + i, 3), .Cells(9 + i, 3)).Value = Grid1.Rows(i).Cells("TRABAJADOR").Value
                    .Range(.Cells(9 + i, 3), .Cells(9 + i, 4)).Merge()
                    .Range(.Cells(9 + i, 5), .Cells(9 + i, 5)).Value = Grid1.Rows(i).Cells("AREA").Value
                    .Range(.Cells(9 + i, 6), .Cells(9 + i, 6)).Value = Grid1.Rows(i).Cells("0_DIAS").Value
                    .Range(.Cells(9 + i, 7), .Cells(9 + i, 7)).Value = Grid1.Rows(i).Cells("1_10_DIAS").Value
                    .Range(.Cells(9 + i, 8), .Cells(9 + i, 8)).Value = Grid1.Rows(i).Cells("11_18_DIAS").Value
                    .Range(.Cells(9 + i, 9), .Cells(9 + i, 9)).Value = Grid1.Rows(i).Cells("19_26_DIAS").Value
                    .Range(.Cells(9 + i, 10), .Cells(9 + i, 10)).Value = Grid1.Rows(i).Cells("27_34_DIAS").Value
                    '.Range(.Cells(9 + i, 10), .Cells(9 + i, 10)).Value = Grid1.Rows(i).Cells("35_MAS_DIAS").Value
                    .Range(.Cells(9 + i, 11), .Cells(9 + i, 11)).Formula = "=H" & 9 + i & "+I" & 9 + i & "+J" & 9 + i & ""
                    .Range(.Cells(9 + i, 12), .Cells(9 + i, 12)).Formula = "=F" & 9 + i & "+G" & 9 + i & "+K" & 9 + i & ""
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 12)).WrapText = False
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 18)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(9 + i, 13), .Cells(9 + i, 13)).Value = Grid1.Rows(i).Cells("PROVISION").Value
                    .Range(.Cells(9 + i, 14), .Cells(9 + i, 14)).Value = Grid1.Rows(i).Cells("CERRADAS").Value
                    .Range(.Cells(9 + i, 15), .Cells(9 + i, 15)).Value = Grid1.Rows(i).Cells("RECEPCIONADA").Value
                    .Range(.Cells(9 + i, 16), .Cells(9 + i, 16)).Value = Grid1.Rows(i).Cells("REINTEGRO").Value
                    .Range(.Cells(9 + i, 17), .Cells(9 + i, 17)).Value = "=L" & 9 + i & "-M" & 9 + i & "-N" & 9 + i & "-O" & 9 + i & "+P" & 9 + i & ""
                    ultFila = i + 9
                Next
                .Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 17)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 12)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 17)).Font.Bold = True
                .Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 17)).Font.Bold = True
                .Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 5)).Merge()
                .Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 5)).Merge()
                .Range(.Cells(1 + ultFila, 1), .Cells(1 + ultFila, 5)).Value = "TOTALES"
                .Range(.Cells(2 + ultFila, 1), .Cells(2 + ultFila, 5)).Value = "% POR COBRAR"

                .Range(.Cells(1 + ultFila, 5), .Cells(1 + ultFila, 5)).Formula = "=SUMA(E9:E" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 6), .Cells(1 + ultFila, 6)).Formula = "=SUMA(F9:F" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 7), .Cells(1 + ultFila, 7)).Formula = "=SUMA(G9:G" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 8), .Cells(1 + ultFila, 8)).Formula = "=SUMA(H9:H" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 9), .Cells(1 + ultFila, 9)).Formula = "=SUMA(I9:I" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 10), .Cells(1 + ultFila, 10)).Formula = "=SUMA(J9:J" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 11), .Cells(1 + ultFila, 11)).Formula = "=H" & 1 + ultFila & "+I" & 1 + ultFila & "+J" & 1 + ultFila & ""
                .Range(.Cells(1 + ultFila, 12), .Cells(1 + ultFila, 12)).Formula = "=F" & 1 + ultFila & "+G" & 1 + ultFila & "+K" & 1 + ultFila & ""

                .Range(.Cells(1 + ultFila, 13), .Cells(1 + ultFila, 13)).Formula = "=SUMA(M9:M" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 14), .Cells(1 + ultFila, 14)).Formula = "=SUMA(N9:N" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 15), .Cells(1 + ultFila, 15)).Formula = "=SUMA(O9:O" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 16), .Cells(1 + ultFila, 16)).Formula = "=SUMA(P9:P" & ultFila & ")"
                .Range(.Cells(1 + ultFila, 17), .Cells(1 + ultFila, 17)).Formula = "=SUMA(Q9:Q" & ultFila & ")"

                '.Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 5)).Formula = "=+E" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 6), .Cells(2 + ultFila, 6)).Formula = "=+F" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 7), .Cells(2 + ultFila, 7)).Formula = "=+G" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 8), .Cells(2 + ultFila, 8)).Formula = "=+H" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 9), .Cells(2 + ultFila, 9)).Formula = "=+I" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 10), .Cells(2 + ultFila, 10)).Formula = "=+J" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 11), .Cells(2 + ultFila, 11)).Formula = "=+K" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 12), .Cells(2 + ultFila, 12)).Formula = "=+L" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Range(.Cells(2 + ultFila, 5), .Cells(2 + ultFila, 11)).NumberFormat = "0.00%" 'NumberFormat = "0.00%" '"0.00%;[Red]-0.00%"

                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 10)).Merge()
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 8)).Value = "INDICE DE MOROSIDAD"
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 8)).Font.Size = 11
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 11)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(4 + ultFila, 8), .Cells(4 + ultFila, 11)).Font.Bold = True
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).NumberFormat = "0.00%"
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).Font.Size = 11
                .Range(.Cells(4 + ultFila, 11), .Cells(4 + ultFila, 11)).Formula = "=+K" & 1 + ultFila & "/$L$" & 1 + ultFila & ""
                .Rows(5 + ultFila & ":" & 5 + ultFila).Select()
                'If 4 + ultFila > 43 Then
                For i As Int32 = 0 To 54 - ultFila
                    m_excel.Selection.Delete(Shift:=Excel.XlDirection.xlUp)
                    'm_excel.Selection.Insert(Shift:=Excel.XlDirection.xlDown)
                Next
                'End If
                'Selection.Delete(Shift:=xlUp)
                .Range("A7").Select()
                'm_excel.Selection.Insert(Shift:=Excel.XlDirection.xlDown)
                '.Rows(4 + ultFila & ":" & 4 + ultFila).Selection.Insert(Shift:=.xlDown, CopyOrigin:=.xlFormatFromLeftOrAbove)
                '.Rows(4 + ultFila & ":" & 4 + ultFila).Selection.Insert(Shift:=.xlDown, CopyOrigin:=.xlFormatFromLeftOrAbove)
                '.Rows(4 + ultFila & ":" & 4 + ultFila).Selection.Insert(Shift:=.xlDown, CopyOrigin:=.xlFormatFromLeftOrAbove)
                'Selection.Insert(Shift:=.xlDown, CopyOrigin:=.xlFormatFromLeftOrAbove)
                Dim sort As Excel.Sort = objHojaExcel.Sort

                With sort
                    .SortFields.Clear()
                    .SortFields.Add(objHojaExcel.Range("K9"), Excel.XlSortOn.xlSortOnValues, _
                        Excel.XlSortOrder.xlDescending, Excel.XlSortDataOption.xlSortNormal)
                    .SortFields.Add(objHojaExcel.Range("L9"), Excel.XlSortOn.xlSortOnValues, _
                       Excel.XlSortOrder.xlDescending, Excel.XlSortDataOption.xlSortNormal)
                    .SetRange(objHojaExcel.Range("A9:R" & ultFila & ""))
                    .MatchCase = False
                    .Header = Excel.XlYesNoGuess.xlNo
                    .Orientation = Excel.XlSortOrientation.xlSortColumns
                    .SortMethod = Excel.XlSortMethod.xlPinYin
                    .Apply()
                End With

                For i = 0 To Grid1.Rows.Count - 1
                    .Range(.Cells(9 + i, 1), .Cells(9 + i, 1)).Value = i + 1
                Next

            End With
        Catch ex As Exception

        End Try
    End Sub

    Function mesNumero(ByVal Mes As Integer) As String
        Dim mesdescri As String = String.Empty
        Select Case Mes
            Case 1
                mesNumero = "ENERO"
            Case 2
                mesNumero = "FEBRERO"
            Case 3
                mesNumero = "MARZO"
            Case 4
                mesNumero = "ABRIL"
            Case 5
                mesNumero = "MAYO"
            Case 6
                mesNumero = "JUNIO"
            Case 7
                mesNumero = "JULIO"
            Case 8
                mesNumero = "AGOSTO"
            Case 9
                mesNumero = "SETIEMBRE"
            Case 10
                mesNumero = "OCTUBRE"
            Case 11
                mesNumero = "NOVIEMBRE"
            Case Else
                mesNumero = "DICIEMBRE"
        End Select
    End Function
    Sub ReporteGeneral()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            If GridConsultas.Rows.Count > 0 Then

                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTESALDOSPORMES.xls")
                File.Copy(RutaReporteERP & "PLANTILLASALDOS.xls", path & "\REPORTESALDOSPORMES.xls")
                m_Excel.Workbooks.Open(path & "\REPORTESALDOSPORMES.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 13
                nfilaini = 13

                With objHojaExcel
                    .Activate()
                    .Range("A2").Value = "SALDOS POR TRABAJADOR AL " & dtpfecha.Value.ToString("dd/MM/yyyy")
                    .Range("A2").Font.Bold = True
                    Dim filaultima As Int32 = 0

                    For i As Int16 = 0 To GridConsultas.Rows.Count - 1
                        .Range("A" & 5 + i).Value = GridConsultas.Rows(i).Cells("CodTrabajador")
                        .Range("B" & 5 + i).Value = GridConsultas.Rows(i).Cells("NomTrabajador")
                        .Range("C" & 5 + i).Value = GridConsultas.Rows(i).Cells("motivo")
                        .Range("D" & 5 + i).Value = GridConsultas.Rows(i).Cells("montoTotal")

                        .Range(.Cells(5 + i, 1), .Cells(5 + i, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                        nfila = nfila + 1
                        filaultima = 5 + i
                    Next
                    .Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 3)).Value = "Total"
                    .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 4)).Formula = "=SUMA(D5:D" & filaultima & ")"
                    .Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 4)).Font.Bold = True
                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Sub ReporteDetalle()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            If GridConsultas.Rows.Count > 0 Then

                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTESALDOSPORMESAPROBADO.xls")
                File.Copy(RutaReporteERP & "PLANTILLASALDOS.xls", path & "\REPORTESALDOSPORMESAPROBADO.xls")
                m_Excel.Workbooks.Open(path & "\REPORTESALDOSPORMESAPROBADO.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 13
                nfilaini = 13

                With objHojaExcel
                    .Activate()
                    .Range("A2").Value = "SALDOS POR TRABAJADOR AL " & dtpfecha.Value.ToString("dd/MM/yyyy")
                    .Range("A2").Font.Bold = True
                    Dim filaultima As Int32 = 0

                    For i As Int16 = 0 To Grid2.Rows.Count - 1
                        .Range("A" & 5 + i).Value = Grid2.Rows(i).Cells("CodTrabajador")
                        .Range("B" & 5 + i).Value = Grid2.Rows(i).Cells("NomTrabajador")
                        .Range("C" & 5 + i).Value = Grid2.Rows(i).Cells("motivo")
                        .Range("D" & 5 + i).Value = Grid2.Rows(i).Cells("montoTotal")

                        .Range(.Cells(5 + i, 1), .Cells(5 + i, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                        nfila = nfila + 1
                        filaultima = 5 + i
                    Next
                    .Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 3)).Value = "Total"
                    .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 4)).Formula = "=SUMA(D5:D" & filaultima & ")"
                    .Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 4)).Font.Bold = True
                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub Grid2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid2.DoubleClick
        Try
            Dim frm As New FrmEntAjusteSaldo
            frm.codtrabajador = Grid2.ActiveRow.Cells("CodTrabajador").Value.ToString.Trim
            frm.fecha = dtpfecha.Value
            frm.Label1.Text = "CÓDIGO:          " & Grid2.ActiveRow.Cells("CodTrabajador").Value.ToString.Trim
            frm.Label2.Text = "TRABAJADOR:  " & Grid2.ActiveRow.Cells("NomTrabajador").Value.ToString.Trim
            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "CodTrabajador" OrElse uColumn.Key = "Motivo" _
                    OrElse uColumn.Key = "NomTrabajador" OrElse uColumn.Key = "montoTotal") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout

    End Sub
End Class