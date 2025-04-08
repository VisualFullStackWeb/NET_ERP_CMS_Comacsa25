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
Public Class FrmProyIndicador
    Public IDPROYECTO As Integer
    Public PROYECTO As String
    Dim obj_Proyecto As New NGProyecto
    Dim obj_EProyecto As New ETProyecto
    Private Sub FrmProyIndicador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFecha.Value = Now.Date
    End Sub

    Private Sub dtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFecha.ValueChanged
        Try
            Dim dtPlanificacion As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.idproyecto = IDPROYECTO
            obj_EProyecto.Fecha = dtFecha.Value
            Dim dsData As New DataSet
            dsData = obj_Proyecto.Lista_AvanceFisicoSub(obj_EProyecto)
            dtPlanificacion = dsData.Tables(0)
            gridsubtarea.DataSource = dtPlanificacion
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridsubtarea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridsubtarea.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridsubtarea) Then Return
            With sender
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Down
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Right
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Left
                        .PerformAction(ExitEditMode)
                        .PerformAction(PrevCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Return
                        .PerformAction(ExitEditMode)
                        If gridsubtarea.ActiveRow.Cells("AVANCE_FISICO").Value > 100 Then
                            MsgBox("No puede registrar mas del 100%", MsgBoxStyle.Exclamation, "Validación")
                            gridsubtarea.ActiveRow.Cells("AVANCE_FISICO").Value = "0.00"
                            .PerformAction(EnterEditMode)
                            '.PerformAction(PrevCellByTab)
                            Exit Sub
                        End If
                        '.PerformAction(NextCellByTab)
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If cmbTipo.SelectedIndex < 0 Then
                MsgBox("Debe seleccionar tipo de gráfico", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If
            GrabaAvance()
            ReporteValor()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub GrabaAvance()
        Dim dtResul As New DataTable
        For I As Int32 = 0 To gridsubtarea.Rows.Count - 1
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.idplanisubtarea = gridsubtarea.Rows(I).Cells("ID_PLANIF_SUBTAREA").Value
            obj_EProyecto.Fecha = dtFecha.Value
            obj_EProyecto.avance = gridsubtarea.Rows(I).Cells("AVANCE_FISICO").Value
            obj_EProyecto.Usuario = User_Sistema
            Dim dsData As New DataSet
            dsData = obj_Proyecto.Mant_AvanceFisicoSub(obj_EProyecto)
            dtResul = dsData.Tables(0)
        Next
    End Sub

    Sub ReporteValor()
        Try
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\REPORTE_VALOR.xls")
            File.Copy(RutaReporteERP & "PLANTILLA_VALOR.xls", path & "\REPORTE_VALOR.xls")
            m_Excel.Workbooks.Open(path & "\REPORTE_VALOR.xls")
            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcel_Graf As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            m_Excel.DisplayAlerts = False
            Dim dsDatos As New DataSet
            Dim dtDatos As New DataTable
            Dim dtDatosTOT As New DataTable
            Dim dtDatosGRAF As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.Fecha = dtFecha.Value
            obj_EProyecto.tipograf = cmbTipo.Value
            dsDatos = obj_Proyecto.ReporteValor(obj_EProyecto)
            dtDatos = dsDatos.Tables(0)
            dtDatosTOT = dsDatos.Tables(1)
            dtDatosGRAF = dsDatos.Tables(2)
            'MsgBox(DateTime.DaysInMonth(2021, 2))

            If dtDatos.Rows.Count > 0 Then

                Dim nfila As Integer = 9
                Dim nfilaini As Integer = 0
                Dim nfilafin As Integer = 0
                Dim filaultima As Int32 = 0
                Dim id_equipo As Int32 = 0
                Dim id_planif_tarea As Int32 = 0
                Dim id_planif_subtarea As Int32 = 0
                'Dim fechaini As Date
                'Dim fechafin As Date
                Dim colini As Int32 = 7
                With objHojaExcel
                    '.Range("A15").RowHeight = 3
                    'Dim mes_ini As Int32 = Month(fechaini)
                    'Dim ayo_ini As Int32 = Year(fechaini)
                    'Dim mes_fin As Int32 = Month(fechafin)
                    'Dim ayo_fin As Int32 = Year(fechafin)
                    'Dim dia_ini As Int32 = fechaini.Day
                    Dim fil_ini_tarea As Int32 = 0

                    'Dim dt_Cabecera As New DataTable
                    'dt_Cabecera.Columns.Add("AYO")
                    'dt_Cabecera.Columns.Add("MES")
                    'dt_Cabecera.Columns.Add("DIA")
                    'dt_Cabecera.Columns.Add("COL")
                    'dt_Cabecera.Columns.Add("DOM")
                    .Range("C6").Value = PROYECTO
                    If dtDatosTOT.Rows.Count > 0 Then
                        .Range("H6").Value = dtDatosTOT.Rows(0)("PV")
                        .Range("I6").Value = dtDatosTOT.Rows(0)("EV")
                        .Range("J6").Value = dtDatosTOT.Rows(0)("AC")
                        .Range("K6").Value = dtDatosTOT.Rows(0)("SV")
                        .Range("L6").Value = dtDatosTOT.Rows(0)("CV")
                        .Range("M6").Value = dtDatosTOT.Rows(0)("SPI")
                        .Range("N6").Value = dtDatosTOT.Rows(0)("CPI")
                        .Range("O6").Value = dtDatosTOT.Rows(0)("EAC")
                        .Range("P6").Value = dtDatosTOT.Rows(0)("BAC")
                        .Range("Q6").Value = dtDatosTOT.Rows(0)("VAC")
                        .Range("R6").Value = dtDatosTOT.Rows(0)("TCPI")
                    End If
                    For i As Int32 = 0 To dtDatos.Rows.Count - 1
                        If dtDatos.Rows(i)("ID_EQUIPO") <> id_equipo Or dtDatos.Rows(i)("ID_PLANIF_TAREA") <> id_planif_tarea Or i = dtDatos.Rows.Count - 1 Then
                            'If i = dtDatos.Rows.Count - 1 Then
                            '    MsgBox("")
                            'End If
                            If i > 0 Then
                                '.Range("A" & nfila + i).RowHeight = 3
                                nfila += 1
                                .Range("A" & nfilaini & ":A" & nfilafin).Rows.Group()
                                .Range("H" & fil_ini_tarea).Value = "=SUMA(H" & nfilaini & ":H" & nfilafin & ")" ' PV
                                .Range("I" & fil_ini_tarea).Value = "=SUMA(I" & nfilaini & ":I" & nfilafin & ")" ' EV
                                .Range("J" & fil_ini_tarea).Value = "=SUMA(J" & nfilaini & ":J" & nfilafin & ")" ' AC

                                .Range("K" & fil_ini_tarea).Value = "=SI.ERROR(I" & fil_ini_tarea & "-H" & fil_ini_tarea & ",0)" ' SV
                                .Range("L" & fil_ini_tarea).Value = "=SI.ERROR(I" & fil_ini_tarea & "-J" & fil_ini_tarea & ",0)" ' CV
                                .Range("M" & fil_ini_tarea).Value = "=SI.ERROR(I" & fil_ini_tarea & "/H" & fil_ini_tarea & ",0)" ' SPI
                                .Range("N" & fil_ini_tarea).Value = "=SI.ERROR(I" & fil_ini_tarea & "/J" & fil_ini_tarea & ",0)" ' CPI
                                .Range("O" & fil_ini_tarea).Value = "=SI.ERROR(P" & fil_ini_tarea & "/N" & fil_ini_tarea & ",0)" ' EAC
                                .Range("P" & fil_ini_tarea).Value = "=SUMA(P" & nfilaini & ":P" & nfilafin & ")" ' BAC
                                .Range("Q" & fil_ini_tarea).Value = "=SI.ERROR(P" & fil_ini_tarea & "-O" & fil_ini_tarea & ",0)" ' VAC
                                .Range("R" & fil_ini_tarea).Value = "=SI.ERROR((P" & fil_ini_tarea & "-I" & fil_ini_tarea & ")/(P" & fil_ini_tarea & "-J" & fil_ini_tarea & "),0)" ' TCPI

                                .Range("F" & fil_ini_tarea & ":R" & fil_ini_tarea).Font.Bold = True
                                .Range("F" & fil_ini_tarea & ":R" & fil_ini_tarea).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                            End If
                            '.Range("A" & nfila + i & ":E" & nfila + i).RowHeight = 10.5
                            .Range("B" & nfila + i & ":C" & nfila + i).Font.Size = 8
                            .Range("B" & nfila + i).Value = dtDatos.Rows(i)("EQUIPO")
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
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("ORDEN")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("SUBTAREA")

                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("AVANCE_PROGRAMADO") / 100
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("AVANCE_FISICO") / 100
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("PV")
                        .Range("I" & nfila + i).Value = dtDatos.Rows(i)("EV")
                        .Range("J" & nfila + i).Value = dtDatos.Rows(i)("AC")
                        .Range("K" & nfila + i).Value = dtDatos.Rows(i)("SV")
                        .Range("L" & nfila + i).Value = dtDatos.Rows(i)("CV")
                        .Range("M" & nfila + i).Value = dtDatos.Rows(i)("SPI")
                        .Range("N" & nfila + i).Value = dtDatos.Rows(i)("CPI")
                        .Range("O" & nfila + i).Value = dtDatos.Rows(i)("EAC")
                        .Range("P" & nfila + i).Value = dtDatos.Rows(i)("BAC")
                        .Range("Q" & nfila + i).Value = dtDatos.Rows(i)("VAC")
                        .Range("R" & nfila + i).Value = dtDatos.Rows(i)("TCPI")

                        '.Range("G" & nfila + i).Interior.Color = 65535
                        '.Range("A" & nfila + i & ":E" & nfila + i).RowHeight = 10.5
                        .Range("B" & nfila + i & ":C" & nfila + i).Font.Size = 8
                        .Range("C" & nfila + i & ":E" & nfila + i).Merge()

                        'nfila += 1
                        nfilafin = nfila + i + 1
                        '.Range("A" & nfila + i).RowHeight = 3
                        '.Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        filaultima = nfila + i
                    Next
                    .Activate()
                    '.Range("A" & nfilaini & ":A" & nfilafin).Rows.Group()
                    With objHojaExcel_Graf
                        .Activate()
                        .Range("C3").Value = PROYECTO
                        If dtDatosTOT.Rows.Count > 0 Then
                            .Range("H4").Value = dtDatosTOT.Rows(0)("PV")
                            .Range("I4").Value = dtDatosTOT.Rows(0)("EV")
                            .Range("J4").Value = dtDatosTOT.Rows(0)("AC")
                            .Range("K4").Value = dtDatosTOT.Rows(0)("SV")
                            .Range("L4").Value = dtDatosTOT.Rows(0)("CV")
                            .Range("M4").Value = dtDatosTOT.Rows(0)("SPI")
                            .Range("N4").Value = dtDatosTOT.Rows(0)("CPI")
                            .Range("O4").Value = dtDatosTOT.Rows(0)("EAC")
                            .Range("P4").Value = dtDatosTOT.Rows(0)("BAC")
                            .Range("Q4").Value = dtDatosTOT.Rows(0)("VAC")
                            .Range("R4").Value = dtDatosTOT.Rows(0)("TCPI")
                        End If
                        nfila = 9
                        Dim filafin_graf As Int32
                        Dim pv_acum As Double = 0
                        Dim ev_acum As Double = 0
                        Dim ac_acum As Double = 0
                        For i As Int32 = 0 To dtDatosGRAF.Rows.Count - 1
                            .Range("B" & nfila + i).Value = dtDatosGRAF.Rows(i)(0)
                            pv_acum = pv_acum + dtDatosGRAF.Rows(i)("PV")
                            ev_acum = ev_acum + dtDatosGRAF.Rows(i)("EV")
                            ac_acum = ac_acum + dtDatosGRAF.Rows(i)("AC")
                            .Range("C" & nfila + i).Value = pv_acum
                            .Range("D" & nfila + i).Value = ev_acum
                            .Range("E" & nfila + i).Value = ac_acum
                            filafin_graf = nfila + i
                        Next
                        If filafin_graf = 11 Then filafin_graf += 1
                        .Range("B8:E" & filafin_graf).Select()
                        m_Excel.ActiveSheet.Shapes.AddChart.Select()
                        m_Excel.ActiveChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLineMarkers
                        m_Excel.ActiveChart.SetSourceData(Source:=.Range("Hoja2!$B$8:$E$" & filafin_graf))
                        m_Excel.ActiveSheet.ChartObjects("1 Gráfico").Activate()
                        m_Excel.ActiveSheet.Shapes("1 Gráfico").IncrementLeft(77.75)
                        m_Excel.ActiveSheet.Shapes("1 Gráfico").IncrementTop(-63.75)
                        If cmbTipo.Text = "MENSUAL" Then
                            .Range("B8").Value = "Mes"
                        Else
                            .Range("B8").Value = "Semana"
                        End If
                        If filafin_graf > 25 Then filafin_graf += 2 Else filafin_graf = 25
                        .Range("B" & filafin_graf).Font.Bold = True
                        .Range("B" & filafin_graf).Value = "Interpretación"
                        filafin_graf += 1
                        .Range("B" & filafin_graf).Value = "CV > cero Eficiente; CV < cero Ineficiente"
                        filafin_graf += 1
                        .Range("B" & filafin_graf).Value = "Por casa $$$ gastado trabajamos $ " & .Range("N4").Value
                        filafin_graf += 1
                        .Range("B" & filafin_graf).Value = "SV > cero adelantados en el cronograma; SV < cero atrasados en el cronograma"
                        filafin_graf += 1
                        .Range("B" & filafin_graf).Value = "Estamos progresando aún " & .Range("M4").Value & "% de lo planeado"
                        filafin_graf += 1
                        .Range("B" & filafin_graf).Value = "TCPI > 1: No es bueno, significa que hay que mejorar la eficiencia para no exceder el presupuesto original"
                        filafin_graf += 1
                        .Range("B" & filafin_graf).Value = "TCPI < 1: Es bueno, significa que tenemos holgura para gastar más sin que esto genere un exceso en el costo total del proyecto"
                    End With
                End With

            End If
            'm_Excel.ActiveSheet.Outline.ShowLevels(RowLevels:=1)
            m_Excel.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub
End Class