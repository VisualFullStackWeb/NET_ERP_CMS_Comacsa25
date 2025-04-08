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
Imports System.Data
Public Class FrmAvanceProyecto
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
    Dim dtTarea As New DataTable
    Dim dtSubTarea As New DataTable
    Dim dtSubTarea_Filtro As New DataTable
    Dim dtPersonal As New DataTable
    Dim dtMaterial As New DataTable
    Dim dtServicio As New DataTable
    Dim dtPersonalREAL As New DataTable
    Dim dtMaterialREAL As New DataTable
    Dim dtServicioREAL As New DataTable
    Dim dtPlano As New DataTable
    Dim dtPlanoDet As New DataTable
    Dim obj_Proyecto As New NGProyecto
    Dim obj_EProyecto As New ETProyecto
    Dim idproyecto As Int32 = 0
    Dim idtaller As Int32 = 0
    Private Sub FrmAvanceProyecto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargaData()
    End Sub
    Sub cargaData()
        Dim dtPlanificacion As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_PlanificacionAvance(obj_EProyecto)
        dtPlanificacion = dsData.Tables(0)
        gridProyecto.DataSource = dtPlanificacion
    End Sub

    Private Sub gridProyecto_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridProyecto.ClickCell
        Try
            If gridProyecto.ActiveRow.Cells(gridProyecto.ActiveCell.Column.Index).Column.Key = "INDICADOR" Then
                Dim frm As New FrmProyIndicador
                frm.IDPROYECTO = gridProyecto.ActiveRow.Cells("ID_PROYECTO").Value
                frm.PROYECTO = gridProyecto.ActiveRow.Cells("PROYECTO").Value
                frm.lblproyecto.Text = gridProyecto.ActiveRow.Cells("PROYECTO").Value
                frm.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridProyecto_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridProyecto.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = Boolean.TrueString
            txtidproyecto.Text = gridProyecto.ActiveRow.Cells("ID_PROYECTO").Value
            idproyecto = gridProyecto.ActiveRow.Cells("ID_PROYECTO").Value
            txtproyecto.Text = gridProyecto.ActiveRow.Cells("PROYECTO").Value
            dtFecha.Value = gridProyecto.ActiveRow.Cells("FECHA").Value
            txtcostototal.Text = CDbl(gridProyecto.ActiveRow.Cells("COSTO").Value).ToString("#,##0.00")
            txtcostoreal.Text = CDbl(gridProyecto.ActiveRow.Cells("REAL").Value).ToString("#,##0.00")
            cargaCostoTaller(txtidproyecto.Text)
        Catch ex As Exception

        End Try
    End Sub

    Sub cargaEquipoPlanificacion(ByVal id_proyecto As Int32, ByVal id_taller As String)
        Dim dtPlanificacion As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.idproyecto = id_proyecto
        obj_EProyecto.idtaller = id_taller
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_EquipoProyecto(obj_EProyecto)
        dtPlanificacion = dsData.Tables(0)
        cmbEquipo.DataSource = dtPlanificacion
        cmbEquipo.ValueMember = "ID_PLANIFICACION"
        cmbEquipo.DisplayMember = "EQUIPO"
        If dtPlanificacion.Rows.Count > 0 Then
            cmbEquipo.Value = dtPlanificacion.Rows(0)(0)
        End If
    End Sub

    Sub cargaCostoTaller(ByVal id_proyecto As Int32)
        Dim dtPlanificacion As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.idproyecto = id_proyecto
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_PlanificacionProyecto(obj_EProyecto)
        dtPlanificacion = dsData.Tables(0)
        griddetalle.DataSource = dtPlanificacion
    End Sub

    Private Sub griddetalle_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles griddetalle.ClickCell
        Try
            If griddetalle.ActiveRow.Cells(griddetalle.ActiveCell.Column.Index).Column.Key = "DETALLE" Then
                txtproyecto_det.Text = txtproyecto.Text
                txtcostototaldet.Text = CDbl(txtcostototal.Text).ToString("#,##0.00")
                txttaller.Text = griddetalle.ActiveRow.Cells("TALLER").Value
                idtaller = griddetalle.ActiveRow.Cells("ID_TALLER").Value
                dtFechadet.Value = dtFecha.Value
                txtcostotaller.Text = CDbl(griddetalle.ActiveRow.Cells("PLANIFICADO").Value).ToString("#,##0.00")
                txtrealtaller.Text = CDbl(griddetalle.ActiveRow.Cells("REAL").Value).ToString("#,##0.00")
                txtcostorealdet.Text = txtcostoreal.Text
                'txtcostoreal
                cargaEquipoPlanificacion(txtidproyecto.Text, griddetalle.ActiveRow.Cells("ID_TALLER").Value)
                Tab1.Tabs("T03").Selected = Boolean.TrueString
                CargaSubtarea(0)
            End If
            If griddetalle.ActiveRow.Cells(griddetalle.ActiveCell.Column.Index).Column.Key = "REPORTE" Then
                ReporteGant()
            End If
            If griddetalle.ActiveRow.Cells(griddetalle.ActiveCell.Column.Index).Column.Key = "REPORTE2" Then
                ReporteGantReal()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub ReporteGantReal()
        Try
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\REPORTE_GANT_REAL.xls")
            File.Copy(RutaReporteERP & "PLANTILLA_GANTREAL.xls", path & "\REPORTE_GANT_REAL.xls")
            m_Excel.Workbooks.Open(path & "\REPORTE_GANT_REAL.xls")
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            m_Excel.DisplayAlerts = False
            Dim dtDatos As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.idproyecto = txtidproyecto.Text
            obj_EProyecto.idtaller = griddetalle.ActiveRow.Cells("ID_TALLER").Value
            dtDatos = obj_Proyecto.ReporteGantReal(obj_EProyecto)

            'MsgBox(DateTime.DaysInMonth(2021, 2))

            If dtDatos.Rows.Count > 0 Then

                Dim nfila As Integer = 16
                Dim nfilaini As Integer = 0
                Dim nfilafin As Integer = 0
                Dim filaultima As Int32 = 0
                Dim id_equipo As Int32 = 0
                Dim id_planif_tarea As Int32 = 0
                Dim id_planif_subtarea As Int32 = 0
                Dim fechaini As Date
                Dim fechafin As Date
                Dim colini As Int32 = 7
                With objHojaExcel
                    .Range("A15").RowHeight = 3
                    .Range("AB6").Value = txtproyecto.Text
                    .Range("AB8").Value = griddetalle.ActiveRow.Cells("TALLER").Value
                    fechaini = dtDatos.Rows(0)("FECHA_INI")
                    fechafin = dtDatos.Rows(0)("FECHA_FIN")
                    .Range("I8").Value = fechaini
                    .Range("O8").Value = fechafin

                    Dim mes_ini As Int32 = Month(fechaini)
                    Dim ayo_ini As Int32 = Year(fechaini)
                    Dim mes_fin As Int32 = Month(fechafin)
                    Dim ayo_fin As Int32 = Year(fechafin)
                    Dim dia_ini As Int32 = fechaini.Day
                    Dim fil_ini_tarea As Int32 = 0

                    Dim dt_Cabecera As New DataTable
                    dt_Cabecera.Columns.Add("AYO")
                    dt_Cabecera.Columns.Add("MES")
                    dt_Cabecera.Columns.Add("DIA")
                    dt_Cabecera.Columns.Add("COL")
                    dt_Cabecera.Columns.Add("DOM")
                    'dt_Cabecera.Columns.Add("TIPO")
                    'CABECERA DE DIAS Y MESES **********************************************************
                    For i As Int32 = 0 To 36
                        If mes_ini > mes_fin And ayo_ini = ayo_fin Then Exit For
                        Dim dias As Int32 = DateTime.DaysInMonth(ayo_ini, mes_ini)
                        For col_dia As Int32 = dia_ini To dias
                            .Range(.Cells(13, colini), .Cells(13, colini + 1)).Value = col_dia
                            .Range(.Cells(13, colini), .Cells(13, colini + 1)).Merge()
                            .Range(.Cells(13, colini), .Cells(13, colini + 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                            .Range(.Cells(12, colini), .Cells(12, colini + 1)).Value = mes_ini
                            .Range(.Cells(12, colini), .Cells(12, colini + 1)).Merge()
                            .Range(.Cells(12, colini), .Cells(12, colini + 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                            .Range(.Cells(11, colini), .Cells(11, colini + 1)).Value = ayo_ini

                            Dim dr As DataRow
                            dr = dt_Cabecera.NewRow
                            dr(0) = ayo_ini
                            dr(1) = mes_ini
                            dr(2) = col_dia
                            dr(3) = colini
                            'dr(4) = dtDatos.Rows(i)("TIPO")
                            If CDate(col_dia.ToString & "/" & mes_ini.ToString & "/" & ayo_ini).ToString("dddd") = "domingo" Then
                                .Range(.Cells(13, colini), .Cells(13, colini + 1)).Font.Color = -16776961
                                .Range(.Cells(13, colini), .Cells(13, colini + 1)).Font.Bold = True
                                dr(4) = 1
                            Else
                                dr(4) = 0
                            End If
                            dt_Cabecera.Rows.Add(dr)
                            colini += 2
                        Next
                        If mes_ini = 12 Then
                            mes_ini = 1
                            ayo_ini += 1
                        Else
                            mes_ini += 1
                        End If
                        dia_ini = 1
                    Next
                    '***************************************************************************

                    For i As Int32 = 0 To dtDatos.Rows.Count - 1
                        If dtDatos.Rows(i)("ID_EQUIPO") <> id_equipo Or dtDatos.Rows(i)("ID_PLANIF_TAREA") <> id_planif_tarea Then
                            If i > 0 Then
                                '.Range("A" & nfila + i).RowHeight = 3
                                nfila += 1
                                .Range("A" & nfilaini & ":A" & nfilafin).Rows.Group()
                            End If
                            .Range("A" & nfila + i & ":E" & nfila + i).RowHeight = 10.5
                            .Range("B" & nfila + i & ":C" & nfila + i).Font.Size = 8
                            .Range("B" & nfila + i).Value = dtDatos.Rows(i)("NOM_EQUIPO")
                            .Range("C" & nfila + i).Value = dtDatos.Rows(i)("TAREA")
                            fil_ini_tarea = nfila + i
                            .Range("C" & nfila + i & ":E" & nfila + i).Merge()
                            .Range("B" & nfila + i & ":E" & nfila + i).Font.Bold = True
                            .Range("B" & nfila + i & ":E" & nfila + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            id_equipo = dtDatos.Rows(i)("ID_EQUIPO")
                            id_planif_tarea = dtDatos.Rows(i)("ID_PLANIF_TAREA")
                            nfila += 1
                            .Range("A" & nfila + i).RowHeight = 3
                            nfilaini = nfila + i + 1
                            nfila += 1
                        Else
                            .Range("B" & nfila + i).Value = ""
                            .Range("C" & nfila + i).Value = ""
                        End If
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("ID_ORDEN")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("SUBTAREA")
                        '.Range("G" & nfila + i).Interior.Color = 65535
                        .Range("A" & nfila + i & ":E" & nfila + i).RowHeight = 10.5
                        .Range("B" & nfila + i & ":C" & nfila + i).Font.Size = 8
                        .Range("C" & nfila + i & ":E" & nfila + i).Merge()

                        'RECORREMOS LOS DIAS Y PINTAMOS LOS DIAS PLANIFICADOS*****************************
                        ayo_ini = CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA")).Year
                        mes_ini = CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA")).Month
                        dia_ini = CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA")).Day
                        Dim cant_dias As Double = dtDatos.Rows(i)("DIAS")
                        Dim rows As DataRow()
                        rows = dt_Cabecera.Select("AYO='" & ayo_ini & "' AND MES='" & mes_ini & "' AND DIA='" & dia_ini & "'")
                        Dim col_sub As Int32 = rows(0).Item("COL").ToString
                        Dim cant_dom As Int32 = 0
                        If cant_dias > 0 Then
                            For col_color As Int32 = col_sub To (col_sub - 1) + (cant_dias * 2)
                                Dim rows_dom As DataRow()
                                rows_dom = dt_Cabecera.Select("COL='" & col_color & "'")
                                If rows_dom.Length > 0 Then
                                    If rows_dom(0).Item("DOM").ToString = 1 Then
                                        cant_dom = cant_dom + 2
                                    End If
                                End If
                                .Range(.Cells(fil_ini_tarea, col_color + cant_dom), .Cells(fil_ini_tarea, col_color + cant_dom)).Interior.Color = 12611584
                                If dtDatos.Rows(i)("TIPO") = "P" Then
                                    .Range(.Cells(nfila + i, col_color + cant_dom), .Cells(nfila + i, col_color + cant_dom)).Interior.Color = 65535
                                Else
                                    .Range(.Cells(nfila + i, col_color + cant_dom), .Cells(nfila + i, col_color + cant_dom)).Interior.Color = 6553
                                End If


                            Next
                        End If

                        'For col_sub As Int32 = 7 To 1000
                        '    If Year(CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA"))) = .Range(.Cells(11, col_sub).Cells(11, col_sub)).Value And CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA")).Month = .Range(.Cells(12, col_sub), .Cells(12, col_sub)).Value And CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA")).Day = .Range(.Cells(13, col_sub), .Cells(13, col_sub)).Value Then
                        '        .Range(.Cells(nfila + i, col_sub), .Cells(nfila + i, col_sub)).Interior.Color = 65535
                        '        Exit For
                        '    End If
                        'Next
                        '*********************************************************************************

                        nfila += 1
                        nfilafin = nfila + i + 1
                        .Range("A" & nfila + i).RowHeight = 3
                        '.Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                    .Range("A" & nfilaini & ":A" & nfilafin).Rows.Group()
                    .Activate()
                End With

            End If
            m_Excel.ActiveSheet.Outline.ShowLevels(RowLevels:=1)
            m_Excel.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub

    Sub ReporteGant()
        Try
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\REPORTE_GANT.xls")
            File.Copy(RutaReporteERP & "PLANTILLA_GANT.xls", path & "\REPORTE_GANT.xls")
            m_Excel.Workbooks.Open(path & "\REPORTE_GANT.xls")
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            m_Excel.DisplayAlerts = False
            Dim dtDatos As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.idproyecto = txtidproyecto.Text
            obj_EProyecto.idtaller = griddetalle.ActiveRow.Cells("ID_TALLER").Value
            dtDatos = obj_Proyecto.ReporteGant(obj_EProyecto)

            'MsgBox(DateTime.DaysInMonth(2021, 2))

            If dtDatos.Rows.Count > 0 Then

                Dim nfila As Integer = 16
                Dim nfilaini As Integer = 0
                Dim nfilafin As Integer = 0
                Dim filaultima As Int32 = 0
                Dim id_equipo As Int32 = 0
                Dim id_planif_tarea As Int32 = 0
                Dim id_planif_subtarea As Int32 = 0
                Dim fechaini As Date
                Dim fechafin As Date
                Dim colini As Int32 = 7
                With objHojaExcel
                    .Range("A15").RowHeight = 3
                    .Range("AB6").Value = txtproyecto.Text
                    .Range("AB8").Value = griddetalle.ActiveRow.Cells("TALLER").Value
                    fechaini = dtDatos.Rows(0)("FECHA_INI")
                    fechafin = dtDatos.Rows(0)("FECHA_FIN")
                    .Range("I8").Value = fechaini
                    .Range("O8").Value = fechafin

                    Dim mes_ini As Int32 = Month(fechaini)
                    Dim ayo_ini As Int32 = Year(fechaini)
                    Dim mes_fin As Int32 = Month(fechafin)
                    Dim ayo_fin As Int32 = Year(fechafin)
                    Dim dia_ini As Int32 = fechaini.Day
                    Dim fil_ini_tarea As Int32 = 0

                    Dim dt_Cabecera As New DataTable
                    dt_Cabecera.Columns.Add("AYO")
                    dt_Cabecera.Columns.Add("MES")
                    dt_Cabecera.Columns.Add("DIA")
                    dt_Cabecera.Columns.Add("COL")
                    dt_Cabecera.Columns.Add("DOM")
                    'CABECERA DE DIAS Y MESES **********************************************************
                    For i As Int32 = 0 To 36
                        If mes_ini > mes_fin And ayo_ini = ayo_fin Then Exit For
                        Dim dias As Int32 = DateTime.DaysInMonth(ayo_ini, mes_ini)
                        For col_dia As Int32 = dia_ini To dias
                            .Range(.Cells(13, colini), .Cells(13, colini + 1)).Value = col_dia
                            .Range(.Cells(13, colini), .Cells(13, colini + 1)).Merge()
                            .Range(.Cells(13, colini), .Cells(13, colini + 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                            .Range(.Cells(12, colini), .Cells(12, colini + 1)).Value = mes_ini
                            .Range(.Cells(12, colini), .Cells(12, colini + 1)).Merge()
                            .Range(.Cells(12, colini), .Cells(12, colini + 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                            .Range(.Cells(11, colini), .Cells(11, colini + 1)).Value = ayo_ini

                            Dim dr As DataRow
                            dr = dt_Cabecera.NewRow
                            dr(0) = ayo_ini
                            dr(1) = mes_ini
                            dr(2) = col_dia
                            dr(3) = colini
                            If CDate(col_dia.ToString & "/" & mes_ini.ToString & "/" & ayo_ini).ToString("dddd") = "domingo" Then
                                .Range(.Cells(13, colini), .Cells(13, colini + 1)).Font.Color = -16776961
                                .Range(.Cells(13, colini), .Cells(13, colini + 1)).Font.Bold = True
                                dr(4) = 1
                            Else
                                dr(4) = 0
                            End If
                            dt_Cabecera.Rows.Add(dr)
                            colini += 2
                        Next
                        If mes_ini = 12 Then
                            mes_ini = 1
                            ayo_ini += 1
                        Else
                            mes_ini += 1
                        End If
                        dia_ini = 1
                    Next
                    '***************************************************************************

                    For i As Int32 = 0 To dtDatos.Rows.Count - 1
                        If dtDatos.Rows(i)("ID_EQUIPO") <> id_equipo Or dtDatos.Rows(i)("ID_PLANIF_TAREA") <> id_planif_tarea Then
                            If i > 0 Then
                                '.Range("A" & nfila + i).RowHeight = 3
                                nfila += 1
                                .Range("A" & nfilaini & ":A" & nfilafin).Rows.Group()
                            End If
                            .Range("A" & nfila + i & ":E" & nfila + i).RowHeight = 10.5
                            .Range("B" & nfila + i & ":C" & nfila + i).Font.Size = 8
                            .Range("B" & nfila + i).Value = dtDatos.Rows(i)("NOM_EQUIPO")
                            .Range("C" & nfila + i).Value = dtDatos.Rows(i)("TAREA")
                            fil_ini_tarea = nfila + i
                            .Range("C" & nfila + i & ":E" & nfila + i).Merge()
                            .Range("B" & nfila + i & ":E" & nfila + i).Font.Bold = True
                            .Range("B" & nfila + i & ":E" & nfila + i).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            id_equipo = dtDatos.Rows(i)("ID_EQUIPO")
                            id_planif_tarea = dtDatos.Rows(i)("ID_PLANIF_TAREA")
                            nfila += 1
                            .Range("A" & nfila + i).RowHeight = 3
                            nfilaini = nfila + i + 1
                            nfila += 1
                        Else
                            .Range("B" & nfila + i).Value = ""
                            .Range("C" & nfila + i).Value = ""
                        End If
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("ID_ORDEN")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("SUBTAREA")
                        '.Range("G" & nfila + i).Interior.Color = 65535
                        .Range("A" & nfila + i & ":E" & nfila + i).RowHeight = 10.5
                        .Range("B" & nfila + i & ":C" & nfila + i).Font.Size = 8
                        .Range("C" & nfila + i & ":E" & nfila + i).Merge()

                        'RECORREMOS LOS DIAS Y PINTAMOS LOS DIAS PLANIFICADOS*****************************
                        ayo_ini = CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA")).Year
                        mes_ini = CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA")).Month
                        dia_ini = CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA")).Day
                        Dim cant_dias As Double = dtDatos.Rows(i)("DIAS")
                        Dim rows As DataRow()
                        rows = dt_Cabecera.Select("AYO='" & ayo_ini & "' AND MES='" & mes_ini & "' AND DIA='" & dia_ini & "'")
                        Dim col_sub As Int32 = rows(0).Item("COL").ToString
                        Dim cant_dom As Int32 = 0
                        If cant_dias > 0 Then
                            For col_color As Int32 = col_sub To (col_sub - 1) + (cant_dias * 2)
                                Dim rows_dom As DataRow()
                                rows_dom = dt_Cabecera.Select("COL='" & col_color & "'")
                                If rows_dom.Length > 0 Then
                                    If rows_dom(0).Item("DOM").ToString = 1 Then
                                        cant_dom = cant_dom + 2
                                    End If
                                End If
                                .Range(.Cells(fil_ini_tarea, col_color + cant_dom), .Cells(fil_ini_tarea, col_color + cant_dom)).Interior.Color = 12611584
                                .Range(.Cells(nfila + i, col_color + cant_dom), .Cells(nfila + i, col_color + cant_dom)).Interior.Color = 65535
                            Next
                        End If

                        'For col_sub As Int32 = 7 To 1000
                        '    If Year(CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA"))) = .Range(.Cells(11, col_sub).Cells(11, col_sub)).Value And CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA")).Month = .Range(.Cells(12, col_sub), .Cells(12, col_sub)).Value And CDate(dtDatos.Rows(i)("FECHA_INI_SUBTAREA")).Day = .Range(.Cells(13, col_sub), .Cells(13, col_sub)).Value Then
                        '        .Range(.Cells(nfila + i, col_sub), .Cells(nfila + i, col_sub)).Interior.Color = 65535
                        '        Exit For
                        '    End If
                        'Next
                        '*********************************************************************************

                        nfila += 1
                        nfilafin = nfila + i + 1
                        .Range("A" & nfila + i).RowHeight = 3
                        '.Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                    .Range("A" & nfilaini & ":A" & nfilafin).Rows.Group()
                    .Activate()
                End With

            End If
            m_Excel.ActiveSheet.Outline.ShowLevels(RowLevels:=1)
            m_Excel.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub

    Private Sub cmbEquipo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbEquipo.InitializeLayout
        With cmbEquipo.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("EQUIPO").Width = sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "EQUIPO") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbEquipo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEquipo.ValueChanged
        Try
            Dim dtPlanificacion As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.idplanificacion = cmbEquipo.Value
            obj_EProyecto.idproyecto = idproyecto
            obj_EProyecto.idtaller = idtaller
            Dim dsData As New DataSet
            dsData = obj_Proyecto.Lista_TallerID(obj_EProyecto)
            dtPlanificacion = dsData.Tables(0)
            cmbtarea.DataSource = dtPlanificacion
            cmbtarea.ValueMember = "ID_PLANIF_TAREA"
            cmbtarea.DisplayMember = "DESC_TAREA"
            cmbtarea.Value = 0
            ''If dtPlanificacion.Rows.Count > 0 Then
            ''    cmbEquipo.Value = dtPlanificacion.Rows(0)(0)
            ''End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbtarea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbtarea.InitializeLayout
        With cmbtarea.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("DESC_TAREA").Width = sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "DESC_TAREA") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbtarea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtarea.ValueChanged
        Try
            CargaSubtarea(cmbtarea.Value)
        Catch ex As Exception

        End Try
    End Sub

    Sub Procesar()
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Dim idtarea As Int32
        If cmbtarea.Value Is Nothing Then
            idtarea = 0
        Else
            idtarea = cmbtarea.Value
        End If
        CargaSubtarea(idtarea)
        lblmensaje.Visible = False
        lblmensaje.Refresh()
    End Sub

    Sub CargaSubtarea(ByVal idplaniftarea As Int32)
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Dim dtPlanificacion As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.idproyecto = txtidproyecto.Text
        obj_EProyecto.idtaller = idtaller
        obj_EProyecto.idequipo = cmbEquipo.Value
        obj_EProyecto.idplanificacion_tarea = idplaniftarea
        obj_EProyecto.flgpersonal = IIf(chkpersonal.Checked = True, 1, 0)
        obj_EProyecto.flgmaterial = IIf(chkmateriales.Checked = True, 1, 0)
        obj_EProyecto.flgservicio = IIf(chkservicio.Checked = True, 1, 0)
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_AvanceSubtarea(obj_EProyecto)
        dtPlanificacion = dsData.Tables(0)
        gridsubtarea.DataSource = dtPlanificacion
        If dtPlanificacion.Rows.Count > 0 Then
            Call CostoTarea()
            '    txtcostotarea.Text = CDbl(dtPlanificacion.Rows(0)("COSTO_TAREA")).ToString("#,##0.00")
            '    txtrealtarea.Text = CDbl(dtPlanificacion.Rows(0)("REAL_TAREA")).ToString("#,##0.00")
            'Else
            '    txtcostotarea.Text = "0.00"
        End If
        lblmensaje.Visible = False
        lblmensaje.Refresh()
    End Sub
    Sub CostoTarea()
        Dim planificado As Double = 0
        Dim real As Double = 0
        For i As Int32 = 0 To gridsubtarea.Rows.Count - 1
            planificado = planificado + gridsubtarea.Rows(i).Cells("PLANIFICADO").Value
            real = real + gridsubtarea.Rows(i).Cells("REAL").Value
        Next
        txtcostotarea.Text = CDbl(planificado).ToString("#,##0.00")
        txtrealtarea.Text = CDbl(real).ToString("#,##0.00")

    End Sub
    Private Sub gridsubtarea_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridsubtarea.ClickCell
        Try
            Dim activa As Int32 = 0
            If gridsubtarea.ActiveRow.Cells(gridsubtarea.ActiveCell.Column.Index).Column.Key = "PERSONAL" Then
                Tab1.Tabs("T04").Visible = True
                Tab1.Tabs("T04").Selected = Boolean.TrueString
                activa = 1
            End If
            If gridsubtarea.ActiveRow.Cells(gridsubtarea.ActiveCell.Column.Index).Column.Key = "MATERIALES" Then
                Tab1.Tabs("T05").Visible = True
                Tab1.Tabs("T05").Selected = Boolean.TrueString
                activa = 1
            End If
            If gridsubtarea.ActiveRow.Cells(gridsubtarea.ActiveCell.Column.Index).Column.Key = "SERVICIOS" Then
                Tab1.Tabs("T06").Visible = True
                Tab1.Tabs("T06").Selected = Boolean.TrueString
                activa = 1
            End If
            If activa = 1 Then
                lblsubtarea.Text = Me.gridsubtarea.ActiveRow.Cells("ORDEN").Value + " - " + Me.gridsubtarea.ActiveRow.Cells("SUBTAREA").Value
                lblsubtarea2.Text = Me.gridsubtarea.ActiveRow.Cells("ORDEN").Value + " - " + Me.gridsubtarea.ActiveRow.Cells("SUBTAREA").Value
                lblsubtarea3.Text = Me.gridsubtarea.ActiveRow.Cells("ORDEN").Value + " - " + Me.gridsubtarea.ActiveRow.Cells("SUBTAREA").Value
                cargaDetalleSubtareaID(Me.gridsubtarea.ActiveRow.Cells("ID_PLANIF_SUBTAREA").Value)
                cargaDetalleSubtareaIDREAL(Me.gridsubtarea.ActiveRow.Cells("ID_PLANIF_SUBTAREA").Value)
                habilita_tabs(False)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub habilita_tabs(ByVal opc As Boolean)
        Tab1.Tabs("T01").Enabled = opc
        Tab1.Tabs("T02").Enabled = opc
        Tab1.Tabs("T03").Enabled = opc
    End Sub

    Sub cargaDetalleSubtareaID(ByVal id As Int32)
        dtPersonal.Rows.Clear()
        dtMaterial.Rows.Clear()
        dtServicio.Rows.Clear()
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.idplanisubtarea = id
        obj_EProyecto.idtaller = id
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_DetSubtareaID(obj_EProyecto)
        dtPersonal = dsData.Tables(0)
        dtMaterial = dsData.Tables(1)
        dtServicio = dsData.Tables(2)
        dtPlanoDet = dsData.Tables(3)
        Dim dtDatos As New DataTable
        dtDatos = dsData.Tables(4)
        gridpersonal.DataSource = dtPersonal
        gridmaterial.DataSource = dtMaterial
        gridServicio.DataSource = dtServicio
    End Sub

    Sub cargaDetalleSubtareaIDREAL(ByVal id As Int32)
        dtPersonalREAL.Rows.Clear()
        dtMaterialREAL.Rows.Clear()
        'dtServicio.Rows.Clear()
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.idplanisubtarea = id
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_DetSubtareaIDREAL(obj_EProyecto)
        dtPersonalREAL = dsData.Tables(0)
        dtMaterialREAL = dsData.Tables(1)
        dtServicio = dsData.Tables(2)
        gridpersonalREAL.DataSource = dtPersonalREAL
        gridmaterialREAL.DataSource = dtMaterialREAL
        'gridServicio.DataSource = dtServicio
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click
        habilita_tabs(True)
        Tab1.Tabs("T03").Selected = True
        Tab1.Tabs("T04").Visible = False
        Tab1.Tabs("T05").Visible = False
        Tab1.Tabs("T06").Visible = False
    End Sub

    Private Sub griddetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles griddetalle.InitializeLayout

    End Sub

    Private Sub gridProyecto_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridProyecto.InitializeLayout

    End Sub
End Class