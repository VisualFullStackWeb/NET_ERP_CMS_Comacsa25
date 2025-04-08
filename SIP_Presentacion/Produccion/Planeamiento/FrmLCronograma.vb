Imports SIP_Entidad
Imports SIP_Negocio
Imports SIP_Reporte
Imports System
Imports System.Math
Imports System.Drawing
Imports System.Windows
Imports System.Windows.Forms
Imports System.Windows.Forms.DateTimePicker
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmLCronograma

#Region "Declaraciones"
    Private Ope As Int32 = 0
    Private BooLimpiar As Boolean = Boolean.FalseString
    Private CodPersonal As String = String.Empty
    Private Anho As Int32 = 0
    Private CodClase As String = String.Empty
    Private CodTipo As String = String.Empty
    Private NumDiaxAnho As Int16 = 0
    Private NumDiaxSemana As Int16 = 0
    Private NumSemanaxAnho As Int16 = 0
    Private FecRegistro As Date = Date.Now
    Private FecSeleccionada As Date = Date.Now
    Private FecCierre As Date = Date.Now
    Private FecInicio As Date = Date.Now
    Private Ls_Activo As List(Of ETActivo) = Nothing
    Private Ls_Personal As List(Of ETPersonal) = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Structure HorarioSituacion
        Event z()
        Const Asignado As String = "<<  Asignado  >>"
        Const Disponible As String = "<< Disponible >>"
    End Structure
    Private Structure HorarioProduccion
        Event z()
        Const Hora1 As String = "07:00 a.m."
        Const Hora2 As String = "03:00 p.m."
        Const Hora3 As String = "11:00 p.m."
        Const Hora4 As String = "04:20 p.m."
    End Structure
    Private MdiOperaciones As List(Of String) = Nothing

#End Region

#Region "Eventos"

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Nuevo)
    '    MdiOperaciones.Add(StrucOperaciones._Modificar)
    '    MdiOperaciones.Add(StrucOperaciones._Cancelar)
    '    MdiOperaciones.Add(StrucOperaciones._Actualizar)
    '    MdiOperaciones.Add(StrucOperaciones._Buscar)
    '    MdiOperaciones.Add(StrucOperaciones._Grabar)
    '    MdiOperaciones.Add(StrucOperaciones._Excel)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Activo IsNot Nothing Then Ls_Activo = Nothing
        If Ls_Personal IsNot Nothing Then Ls_Personal = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Evento_ValueChanged(Dt1, e)

    End Sub

    Sub Evento_ClickCellButton(ByVal sender As Object, ByVal e As CellEventArgs) _
                               Handles Grid1.ClickCellButton

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return
        If Cbo1.SelectedIndex < 0 Then
            MsgBox("Seleccionar el día", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If

        Grb1.Enabled = False

        Select Case e.Cell.Column.Key.ToString
            Case Is = "DesTurno1"
                Call Cargar_Programacion(e.Cell.Row, Cbo1.SelectedIndex + 1, 1)
            Case Is = "DesTurno2"
                Call Cargar_Programacion(e.Cell.Row, Cbo1.SelectedIndex + 1, 2)
            Case Is = "DesTurno3"
                Call Cargar_Programacion(e.Cell.Row, Cbo1.SelectedIndex + 1, 3)
            Case Is = "DesTurno4"
                Call Cargar_Programacion(e.Cell.Row, Cbo1.SelectedIndex + 1, 4)
        End Select

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles _
                                Grid1.InitializeLayout, Grid2.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In Grid1.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Placa" Or uColumn.Key = "DesTipo" Or _
                        uColumn.Key = "Descripcion" Or uColumn.Key = "DesTurno1" Or _
                        uColumn.Key = "DesTurno2" Or uColumn.Key = "DesTurno3" Or _
                        uColumn.Key = "DesTurno4") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In Grid2.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "CodPersonal" Or uColumn.Key = "DesPersonal") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) _
                             Handles Grid1.InitializeRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            If e.Row.Cells("CodTipo").Value = StrucActivos.Chancadora Then
                e.Row.Cells("DesTipo").Value = StrucActivos.StrChancadora
                e.Row.Cells("DesTipo").Appearance.BackColor = Color.LightCoral
            End If
            If e.Row.Cells("CodTipo").Value = StrucActivos.Molino Then
                e.Row.Cells("DesTipo").Value = StrucActivos.StrMolino
                e.Row.Cells("DesTipo").Appearance.BackColor = Color.SkyBlue
            End If
            If e.Row.Cells("Turno1").Value Then
                e.Row.Cells("DesTurno1").Value = HorarioSituacion.Asignado
                e.Row.Cells("DesTurno1").Appearance.ForeColor = Color.Blue
            Else
                e.Row.Cells("DesTurno1").Value = HorarioSituacion.Disponible
            End If
            If e.Row.Cells("Turno2").Value Then
                e.Row.Cells("DesTurno2").Value = HorarioSituacion.Asignado
                e.Row.Cells("DesTurno2").Appearance.ForeColor = Color.Blue
            Else
                e.Row.Cells("DesTurno2").Value = HorarioSituacion.Disponible
            End If
            If e.Row.Cells("Turno3").Value Then
                e.Row.Cells("DesTurno3").Value = HorarioSituacion.Asignado
                e.Row.Cells("DesTurno3").Appearance.ForeColor = Color.Blue
            Else
                e.Row.Cells("DesTurno3").Value = HorarioSituacion.Disponible
            End If
            If e.Row.Cells("Turno4").Value Then
                e.Row.Cells("DesTurno4").Value = HorarioSituacion.Asignado
                e.Row.Cells("DesTurno4").Appearance.ForeColor = Color.Blue
            Else
                e.Row.Cells("DesTurno4").Value = HorarioSituacion.Disponible
            End If
        End If
    End Sub

    Sub Evento_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
                            Handles Dt1.ValueChanged, Ops1.ValueChanged, _
                                    Cbo2.ValueChanged, Txt1.ValueChanged

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Dt1 Then
            If Not IsDate(Dt1.Value) Then Return
            Call Cargar_Descripcion_Fecha() : Return
        End If

        If sender Is Ops1 Then
            Select Case Ops1.CheckedItem.DataValue
                Case "Chk1"
                    Tab3.Visible = Boolean.TrueString
                    Tab3.Tabs("T02").Visible = Boolean.FalseString
                    Tab3.Tabs("T03").Visible = Boolean.FalseString
                    Tab3.Tabs("T01").Visible = Boolean.TrueString
                    Tab2.Tabs("T02").Selected = Boolean.TrueString
                    Tab3.Tabs("T01").Selected = Boolean.TrueString
                Case "Chk3"
                    Tab3.Visible = Boolean.TrueString
                    Tab3.Tabs("T01").Visible = Boolean.FalseString
                    Tab3.Tabs("T03").Visible = Boolean.FalseString
                    Tab3.Tabs("T02").Visible = Boolean.TrueString
                    Tab2.Tabs("T02").Selected = Boolean.TrueString
                    Tab3.Tabs("T02").Selected = Boolean.TrueString
            End Select
            Return
        End If

        If sender Is Cbo2 Then
            Select Case sender.value
                Case 1
                    Txt5.Value = HorarioProduccion.Hora1
                    Txt6.Value = HorarioProduccion.Hora2
                Case 2
                    Txt5.Value = HorarioProduccion.Hora2
                    Txt6.Value = HorarioProduccion.Hora3
                Case 3
                    Txt5.Value = HorarioProduccion.Hora3
                    Txt6.Value = HorarioProduccion.Hora1
                Case 4
                    Txt5.Value = HorarioProduccion.Hora1
                    Txt6.Value = HorarioProduccion.Hora4
                Case Else
                    Txt5.Value = String.Empty
                    Txt6.Value = String.Empty
            End Select
            Return
        End If

        If sender Is Txt1 Then
            Cbo1.SelectedIndex = -1
        End If

    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) _
                     Handles Btn1.Click, Btn2.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ope = 0 Then Return

        If Not VerificarControl(1, Txt3) Then Return

        If sender Is Btn1 Then
            StrucForm.FxCxPersonal = New FrmCPersonal
            AddHandler StrucForm.FxCxPersonal.Closed, AddressOf Buscar_Personal
            StrucForm.FxCxPersonal.MdiParent = MdiParent
            StrucForm.FxCxPersonal.L = Boolean.TrueString
            If Chk2.Checked = False Then
                StrucForm.FxCxPersonal.Opcion = 2
            Else
                StrucForm.FxCxPersonal.Opcion = 1
            End If
            StrucForm.FxCxPersonal.Fecha = FecSeleccionada.Date
            StrucForm.FxCxPersonal.CodClase = StrucActivos.CodClase
            StrucForm.FxCxPersonal.CodTipo = Cbo3.Value
            StrucForm.FxCxPersonal.Placa = Txt3.Value
            StrucForm.FxCxPersonal.Show()
            StrucForm.FxCxPersonal = Nothing
            Return
        End If

        If sender Is Btn2 Then
            If Not VerificarControl(5, Grid2) Then
                MessageBox.Show("No tiene Personal para Quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Grid2.ActiveRow Is Nothing Then
                MessageBox.Show("No tiene una Personal Seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            Grid2.ActiveRow.Delete()
            Return
        End If

    End Sub

    Sub Evento_BeforeRowsDeleted(ByVal sender As Object, ByVal e As BeforeRowsDeletedEventArgs) _
                                 Handles Grid2.BeforeRowsDeleted

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid2 Then Return

        e.DisplayPromptMsg = Boolean.FalseString

    End Sub

    Sub Evento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
                                    Handles Cbo1.SelectedIndexChanged

        If sender Is Nothing Then
            Return
        End If

        If sender IsNot Cbo1 Then Return

        If Not IsNumeric(Txt1.Value) OrElse Not IsNumeric(Txt2.Value) Then Return

        If Cbo1.SelectedIndex = -1 Then Return

        BooLimpiar = Boolean.TrueString

        Call Limpiar()

        Call Consultar_Cronograma()

    End Sub

#End Region

#Region "Procedimientos"

    Sub Consultar_Cronograma()

        Entidad.MyLista = New ETMyLista
        Entidad.Activo = New ETActivo
        Negocio.Activo = New NGActivo
        Ls_Activo = New List(Of ETActivo)

        Entidad.Activo.CodClase = StrucActivos.CodClase
        Entidad.Activo.Anho = Txt2.Value
        Entidad.Activo.Semana = Txt1.Value
        Entidad.Activo.Dia = Cbo1.SelectedIndex + 1

        Entidad.MyLista = Negocio.Activo.ConsultarCronograma(Entidad.Activo)

        If Entidad.MyLista.Validacion Then
            Ls_Activo = Entidad.MyLista.Ls_Activo
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Activo)

    End Sub

    Sub Cargar_Descripcion_Fecha()

        FecRegistro = Dt1.Value
        NumDiaxSemana = DatePart(DateInterval.Weekday, FecRegistro)
        NumSemanaxAnho = DatePart(DateInterval.WeekOfYear, FecRegistro, FirstDayOfWeek.Wednesday)
        NumDiaxAnho = DatePart(DateInterval.DayOfYear, FecRegistro)
        Anho = DatePart(DateInterval.Year, FecRegistro)

        If NumDiaxSemana = 1 OrElse NumDiaxSemana = 2 OrElse NumDiaxSemana = 3 Then
            FecInicio = DateAdd(DateInterval.Day, -(3 + NumDiaxSemana), FecRegistro)
            FecCierre = DateAdd(DateInterval.Day, 3 - NumDiaxSemana, FecRegistro)
        Else
            FecInicio = DateAdd(DateInterval.Day, 4 - NumDiaxSemana, FecRegistro)
            FecCierre = DateAdd(DateInterval.Day, 10 - NumDiaxSemana, FecRegistro)
        End If

        If Year(FecInicio) = Year(FecCierre) Then
            Anho = Year(FecInicio)

        Else
            Anho = Year(FecCierre)
            NumSemanaxAnho = 1
        End If


        dTxt1.Value = FormatDateTime(FecInicio, DateFormat.LongDate)
        dTxt2.Value = FormatDateTime(FecCierre, DateFormat.LongDate)
        Txt2.Value = Anho
        Txt1.Value = NumSemanaxAnho

    End Sub

    Sub Cargar_Programacion(ByVal uRow As UltraGridRow, ByVal i32Dia As Int32, ByVal i32Turno As Int32)

        If uRow Is Nothing Then
            Return
        End If

        CodClase = uRow.Cells("CodClase").Value
        CodTipo = uRow.Cells("CodTipo").Value
        Txt3.Value = uRow.Cells("Placa").Value
        Txt4.Value = uRow.Cells("Descripcion").Value

        Cbo3.Value = CodTipo
        Cbo2.Value = i32Turno

        FecSeleccionada = DateAdd(DateInterval.Day, i32Dia - 1, FecInicio)
        dTxt3.Value = FormatDateTime(FecSeleccionada, DateFormat.LongDate)

        Ls_Personal = New List(Of ETPersonal)
        Entidad.Activo = New ETActivo
        Entidad.MyLista = New ETMyLista
        Negocio.Activo = New NGActivo

        Entidad.Activo.CodClase = uRow.Cells("CodClase").Value
        Entidad.Activo.CodTipo = uRow.Cells("CodTipo").Value
        Entidad.Activo.Placa = uRow.Cells("Placa").Value
        Entidad.Activo.Anho = Txt2.Value
        Entidad.Activo.Semana = Txt1.Value
        Entidad.Activo.Dia = i32Dia
        Entidad.Activo.Fecha = FecSeleccionada
        Entidad.Activo.Turno = i32Turno

        Entidad.MyLista = Negocio.Activo.ConsultarCronogramaxPersonal(Entidad.Activo)

        If Entidad.MyLista.Validacion Then Ls_Personal = Entidad.MyLista.Ls_Personal

        Call CargarUltraGrid(Grid2, Ls_Personal)

        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Sub Limpiar()

        If Not BooLimpiar Then Return

        Source1.Clear()
        Ls_Activo = New List(Of ETActivo)
        Call CargarUltraGrid(Grid1, Ls_Activo)

        Ls_Personal = New List(Of ETPersonal)
        CargarUltraGrid(Grid2, Ls_Personal)

        Cbo2.Value = String.Empty
        Cbo3.Value = String.Empty
        dTxt3.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = String.Empty
        Chk1.Checked = Boolean.FalseString
        BooLimpiar = Boolean.FalseString

    End Sub

    Sub Buscar_Personal(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If sender.Lista.Count = 0 Then Return

        For Each w As ETPersonal In sender.Lista
            CodPersonal = String.Empty : CodPersonal = w.CodPersonal
            If Ls_Personal.FindAll(AddressOf FiltrarPersonal).Count = 0 Then Ls_Personal.Add(w)
        Next

        Call CargarUltraGrid(Grid2, Ls_Personal)

    End Sub

    Sub Controles(ByVal Val As Boolean)

        Btn1.Enabled = Not Val
        Btn2.Enabled = Not Val


        With Grid2.DisplayLayout
            If Not Val Then
                .Override.AllowDelete = DefaultableBoolean.True
            Else
                .Override.AllowDelete = DefaultableBoolean.False
            End If
        End With

    End Sub

    Sub MantenimientoCronograma()




        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Not VerificarControl(1, Txt3) Then
            MessageBox.Show("No existe Placa para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Grid2.PerformAction(ExitEditMode)

        Entidad.Activo = New ETActivo
        Negocio.Activo = New NGActivo

        Entidad.Activo.Anho = Txt2.Value
        Entidad.Activo.Semana = Txt1.Value
        Entidad.Activo.Dia = Cbo1.SelectedIndex + 1
        Entidad.Activo.Turno = Cbo2.Value
        Entidad.Activo.Fecha = FecSeleccionada
        Entidad.Activo.Usuario = User_Sistema
        Entidad.Activo.CodClase = CodClase
        Entidad.Activo.CodTipo = CodTipo
        Entidad.Activo.Placa = Txt3.Value
        Entidad.Activo.AplicarSemana = Chk1.Checked
        Entidad.Activo.FechaInicio = FecInicio.Date
        Dim FechaTemp As DateTime
        FechaTemp = FecCierre.Date
        FechaTemp = DateAdd(DateInterval.Day, 1, FechaTemp)
        FechaTemp = DateAdd(DateInterval.Second, -1, FechaTemp)
        Entidad.Activo.FechaTerminacion = FechaTemp
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Activo = Negocio.Activo.MantenimientoxCronograma(Entidad.Activo, Ls_Personal)

        If Entidad.Activo.Validacion Then
            Call Evento_SelectedIndexChanged(Cbo1, Nothing)
            Call Cancelar()
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Sub ImportarCronograma()
        Entidad.Activo = New ETActivo
        Negocio.Activo = New NGActivo
        Entidad.Objecto = New ETObjecto
        If Ops1.CheckedItem.DataValue = "Chk1" Then
            Entidad.Activo.Tipo = 1
        ElseIf Ops1.CheckedItem.DataValue = "Chk2" Then
            Entidad.Activo.Tipo = 2
        ElseIf Ops1.CheckedItem.DataValue = "Chk3" Then
            Entidad.Activo.Tipo = 3
        Else
            Exit Sub
        End If
        Entidad.Activo.Rotar1 = IIf(IsDBNull(NumU1.Value), 2, NumU1.Value)
        Entidad.Activo.Rotar2 = IIf(IsDBNull(NumU2.Value), 3, NumU2.Value)
        Entidad.Activo.Rotar3 = IIf(IsDBNull(NumU3.Value), 1, NumU3.Value)
        Entidad.Activo.SemanaPrevia = IIf(IsDBNull(NumE1.Value), 1, NumE1.Value)
        Entidad.Activo.Semana = Txt1.Value
        Entidad.Activo.Anho = Txt2.Value
        Entidad.Activo.Usuario = User_Sistema
        Entidad.Activo.FechaInicio = FecInicio
        Entidad.Objecto = Negocio.Activo.ImportarCronograma(Entidad.Activo)
        If Entidad.Objecto.Validacion Then
            Evento_SelectedIndexChanged(Cbo1, Nothing)
            Cancelar()
        End If
    End Sub

    Sub GenerarExcel()

        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

            Entidad.Activo = New ETActivo
            Reporte.Activo = New RptActivo

            Entidad.Activo.FechaInicio = FecInicio
            Entidad.Activo.Semana = Txt1.Value
            Entidad.Activo.Anho = Txt2.Value

            Dim dr As DialogResult
            Dim f As New RptActivoCriterios()

            dr = f.ShowDialog()
            If dr = DialogResult.OK Then

                Call Reporte.Activo.Generar_Cronograma(Entidad.Activo, f.IdPlanta, f.NomPlanta)
                'MsgBox("User clicked OK button")
            ElseIf dr = DialogResult.Cancel Then
                Exit Sub
            End If
            f.Dispose()
            f = Nothing

        Catch e As Exception
            'MessageBox.Show("Ocurrieron Problemas al Generar el Excel", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MessageBox.Show(e.Message.ToString, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

#End Region

#Region "Publicos"

    Public Sub Modificar()

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Not VerificarControl(1, Txt3) Then
            MessageBox.Show("No existe Placa para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Ope = 2

        Call Controles(Boolean.FalseString)

    End Sub

    Public Sub Cancelar()

        If Ope = 1 Then

            Tab1.Tabs("T03").Visible = Boolean.FalseString

            Tab1.Tabs("T02").Visible = Boolean.TrueString
            Tab1.Tabs("T01").Visible = Boolean.TrueString

            Tab1.Tabs("T01").Selected = Boolean.TrueString

        End If

        Grb1.Enabled = True
        Cbo1.SelectedIndex = -1

        Ope = 0
        Call Controles(Boolean.TrueString)

    End Sub

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Evento_SelectedIndexChanged(Cbo1, Nothing)
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Grabar()

        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        If Ope = 1 Then Call ImportarCronograma()

        If Ope = 2 Then Call MantenimientoCronograma()

    End Sub

    Public Sub Nuevo()

        Tab1.Tabs("T03").Visible = Boolean.TrueString
        Tab1.Tabs("T02").Visible = Boolean.FalseString
        Tab1.Tabs("T01").Visible = Boolean.FalseString

        Tab2.Tabs("T01").Selected = Boolean.TrueString
        Ops1.CheckedIndex = -1

        Tab3.Visible = Boolean.FalseString

        Ope = 1

    End Sub

    Public Sub Excel()

        Entidad.Activo = New ETActivo
        Entidad.Objecto = New ETObjecto
        Negocio.Activo = New NGActivo
        Entidad.Activo.Semana = Txt1.Value
        Entidad.Activo.Anho = Txt2.Value
        Entidad.Objecto = Negocio.Activo.ConsultarExisteCronograma(Entidad.Activo)

        If Entidad.Objecto.Respuesta <> 0 Then
            MessageBox.Show("No existe Cronograma para esta Semana y Año", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Call GenerarExcel()
        End If


    End Sub

#End Region

#Region "Funciones"

    Function FiltrarPersonal(ByVal Rpt As ETPersonal) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.CodPersonal = CodPersonal Then lResult = Boolean.TrueString

        Return lResult

    End Function

    Function ReNombrarHojaExcel(ByVal dia As Int16) As String

        ReNombrarHojaExcel = String.Empty

        Select Case dia
            Case 1
                ReNombrarHojaExcel = "Miercoles"
            Case 2
                ReNombrarHojaExcel = "Jueves"
            Case 3
                ReNombrarHojaExcel = "Viernes"
            Case 4
                ReNombrarHojaExcel = "Sabado"
            Case 5
                ReNombrarHojaExcel = "Domingo"
            Case 6
                ReNombrarHojaExcel = "Lunes"
            Case Else
                ReNombrarHojaExcel = "Martes"
        End Select

    End Function

#End Region


   
End Class