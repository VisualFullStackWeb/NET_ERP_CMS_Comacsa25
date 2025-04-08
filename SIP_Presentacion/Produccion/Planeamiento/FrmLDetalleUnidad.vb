Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows
Imports System.Windows.Forms
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinSchedule

Public Class FrmLDetalleUnidad

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub


#Region "Variables"

    Private Structure TurnoProduccion
        Event z()
        Const Turno1 As String = "PRIMERO"
        Const Turno2 As String = "SEGUNDO"
        Const Turno3 As String = "TERCERO"
        Const Turno4 As String = "HORARIO NORMAL"
    End Structure
    Private DateRanges As SelectedDateRanges = Nothing
    Private Ls_Personal As List(Of ETPersonal) = Nothing
    Private Ls_Unidad As List(Of ETActivo) = Nothing
    Public Lista As List(Of ETActivo) = Nothing
    Public CodProducto As String = String.Empty
    Public CodClase As String = String.Empty
    Public CodTipo As String = String.Empty
    Public Placa As String = String.Empty
    Public Descripcion As String = String.Empty
    Public FecIngreso As Date = Date.Now
    Public FecInicio As Date = Date.Now
    Public Fecha As Date = Date.Now
    Public ID As Int32 = 0
    Public Turno As Int16 = 0
    Public L As Boolean = Boolean.FalseString
    Public vCargar As Boolean = Boolean.FalseString
    Private StartDate As Date = Date.Now
    Private EndDate As Date = Date.Now
    Private MdiOperaciones As List(Of String) = Nothing

#End Region

#Region "Eventos"

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Actualizar)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Unidad IsNot Nothing Then Ls_Unidad = Nothing
        If Ls_Personal IsNot Nothing Then Ls_Personal = Nothing
        If Lista IsNot Nothing Then Lista = Nothing
        If DateRanges IsNot Nothing Then DateRanges = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles _
                                Cbo1.InitializeLayout, Grid1.InitializeLayout, Drop1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Cbo1 Then
            With e.Layout.Bands(0)
                .ColHeadersVisible = Boolean.FalseString
                .Columns("Descripcion").Width = sender.Width
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Descripcion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End With
            Return
        End If
        If sender Is Grid1 Then
            With e.Layout.Bands(0)
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Descripcion" OrElse _
                            uColumn.Key = "DesTurno" OrElse _
                            uColumn.Key = "Fecha" OrElse _
                            uColumn.Key = "Horas" OrElse _
                            uColumn.Key = "NroOperarios") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End With
            Return
        End If
        If sender Is Drop1 Then
            With e.Layout.Bands(0)
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "CodPersonal" OrElse _
                            uColumn.Key = "DesPersonal") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End With
            Return
        End If

    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _
                     Btn1.Click, Btn2.Click, Btn3.Click, Btn4.Click, Btn5.Click


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Btn1 Then

            If Lista Is Nothing Then
                MessageBox.Show("Error: Debe Ingresar la Programación", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Lista.Count = 0 Then
                MessageBox.Show("Error: Debe Ingresar la Programación", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            vCargar = Boolean.TrueString
            Call Close()

        End If

        If sender Is Btn2 Then

            If String.IsNullOrEmpty(Cbo1.Value) Then
                MessageBox.Show("Error: Debe Ingresar la Unidad", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            DateRanges = Info1.AlternateSelectedDateRanges

            If DateRanges.SelectedDaysCount = 0 Then
                MessageBox.Show("Error: Debe Ingresar el dia", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If Not (Chk1.Checked OrElse Chk2.Checked OrElse _
                    Chk3.Checked OrElse Chk4.Checked) Then
                MessageBox.Show("Error: Debe Seleccionar el Turno", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

            Call Cargar_Programacion()

            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

            Return

        End If

        If sender Is Btn3 Then

            If Not VerificarControl(5, Grid1) Then
                MessageBox.Show("No tiene Programación para Quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Grid1.ActiveRow Is Nothing Then
                MessageBox.Show("No tiene una Programación Seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            Grid1.ActiveRow.Delete()
            Return

        End If

        If sender Is Btn4 Then
            Lista = New List(Of ETActivo)
            Call CargarUltraGrid(Grid1, Lista)
            Return
        End If

        If sender Is Btn5 Then
            Gpb1.Visible = Boolean.FalseString
        End If

    End Sub

    Sub Evento_BeforeRowsDeleted(ByVal sender As Object, ByVal e As BeforeRowsDeletedEventArgs) _
                                 Handles Grid1.BeforeRowsDeleted

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        e.DisplayPromptMsg = Boolean.FalseString

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) Handles _
                             Grid1.InitializeRow


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        Select Case e.Row.Cells("Turno").Value
            Case 1
                e.Row.Cells("DesTurno").Value = TurnoProduccion.Turno1
            Case 2
                e.Row.Cells("DesTurno").Value = TurnoProduccion.Turno2
            Case 3
                e.Row.Cells("DesTurno").Value = TurnoProduccion.Turno3
            Case Else
                e.Row.Cells("DesTurno").Value = TurnoProduccion.Turno4
        End Select

    End Sub

    Sub Evento_ClickCellButton(ByVal sender As Object, ByVal e As CellEventArgs) Handles _
                               Grid1.ClickCellButton

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Cell.Column.Key <> "NroOperarios" Then Return

        Call Consultar_Operarios(e.Cell.Row.Cells("Fecha").Value, _
                                 e.Cell.Row.Cells("Placa").Value, _
                                 e.Cell.Row.Cells("Turno").Value)

        Call Cargar_Operarios()

    End Sub

    Sub Evento_BeforeActivitiesDeleted(ByVal sender As System.Object, ByVal e As BeforeActivitiesDeletedEventArgs) Handles _
                                       Wv1.BeforeActivitiesDeleted

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Wv1 Then Return

        e.Cancel = Boolean.TrueString

    End Sub

    Sub Evento_BeforeAlternateSelectedDateRangeChange(ByVal sender As Object, ByVal e As BeforeSelectedDateRangeChangeEventArgs) Handles _
                                                      Info1.BeforeAlternateSelectedDateRangeChange

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Info1 Then Return

        If Not e.WasMaxSelectedDaysExceeded Then Return

        e.DisplayMaxSelectedDaysErrorMsg = Boolean.FalseString

    End Sub

#End Region

#Region "Propiedad"

    Sub Iniciar()

        REM -------------------------------

        Info1.MaxDate = FecIngreso
        Info1.MinDate = DateAdd(DateInterval.Day, -1, FecInicio)
        Info1.ActiveDay.Selected = Boolean.TrueString
        Info1.ActiveDay.SelectedInAlternateDateRanges = Boolean.TrueString

        Info2.MaxDate = DateAdd(DateInterval.Month, 1, FecIngreso)
        Info2.MinDate = DateAdd(DateInterval.Month, -1, FecInicio)

        Gpb1.Visible = Boolean.FalseString
        GpE1.Expanded = Boolean.TrueString

        REM -------------------------------

        Call Consultar_Programacion()

        REM -------------------------------

        Call Consultar_Unidades()

    End Sub

    Sub Consultar_Programacion()

        Entidad.Activo = New ETActivo
        Entidad.Producto = New ETProducto
        Negocio.Activo = New NGActivo
        Entidad.MyLista = New ETMyLista

        Entidad.Activo.CodClase = CodClase
        Entidad.Activo.CodTipo = CodTipo
        Entidad.Activo.FechaInicio = Info2.MinDate
        Entidad.Activo.FechaFinal = Info2.MaxDate
        Entidad.Producto.CodProducto = CodProducto

        Entidad.MyLista = Negocio.Activo.ConsultarProgramacion_1(Entidad.Activo, Entidad.Producto)

        If Not Entidad.MyLista.Validacion Then Return

        Call SetDataBindingsForNotes()

    End Sub

    Sub Consultar_Unidades()

        Entidad.Activo = New ETActivo
        Negocio.Activo = New NGActivo

        Entidad.Activo.Tipo = 3
        Entidad.Activo.CodClase = CodClase
        Entidad.Activo.CodTipo = CodTipo
        Entidad.Activo.CodEnlace = ID

        Ls_Unidad = New List(Of ETActivo)
        Ls_Unidad = Negocio.Activo.ConsultarActivo(Entidad.Activo)

        Call CargarUltraCombo(Cbo1, Ls_Unidad, "Placa", "Descripcion")

    End Sub

    Sub Cargar_Programacion()
        Dim Horas As Decimal = Decimal.Zero
        Dim HorasMax As Decimal = Decimal.Zero

        If Lista Is Nothing Then Lista = New List(Of ETActivo)

        StartDate = DateRanges(0).StartDate
        EndDate = DateRanges(DateRanges.Count - 1).EndDate

        While StartDate <= EndDate
            For i As Int16 = 1 To 4

                If i = 1 AndAlso Not Chk1.Checked Then GoTo Saltar
                If i = 2 AndAlso Not Chk2.Checked Then GoTo Saltar
                If i = 3 AndAlso Not Chk3.Checked Then GoTo Saltar
                If i = 4 AndAlso Not Chk4.Checked Then GoTo Saltar

                Entidad.Activo = New ETActivo

                Select Case i
                    Case 1
                        If Chk1.Checked = True Then
                            Horas = Num1.Value
                            HorasMax = Num1.MaxValue
                        End If
                    Case 2
                        If Chk1.Checked = True Then
                            Horas = Num2.Value
                            HorasMax = Num2.MaxValue
                        End If
                    Case 3
                        If Chk3.Checked = True Then
                            Horas = Num3.Value
                            HorasMax = Num3.MaxValue
                        End If
                    Case Else
                        If Chk4.Checked = True Then
                            Horas = Num4.Value
                            HorasMax = Num4.MaxValue
                        End If
                End Select

                Entidad.Activo.Placa = Cbo1.Value
                Entidad.Activo.Turno = i
                Entidad.Activo.Fecha = StartDate

                If Lista.Exists(AddressOf Existe_Registro) Then
                    GoTo Saltar
                Else

                    Call Consultar_Operarios(Entidad.Activo.Fecha, _
                                             Entidad.Activo.Placa, _
                                             Entidad.Activo.Turno)

                    Entidad.Activo.Descripcion = Cbo1.Text
                    Entidad.Activo.NroOperarios = Ls_Personal.Count
                    Entidad.Activo.CodClase = CodClase
                    Entidad.Activo.CodTipo = CodTipo
                    Entidad.Activo.Horas = IIf((Horas > HorasMax) Or (Horas <= 0), HorasMax, Horas)
                    Entidad.Activo.HorasMax = HorasMax
                    Lista.Add(Entidad.Activo)

                End If
Saltar:
            Next
            StartDate = DateAdd(DateInterval.Day, 1, StartDate)
        End While

        Negocio.Activo = New NGActivo
        Call Negocio.Activo.Ordenar_Activo(Lista)

        Call CargarUltraGrid(Grid1, Lista)

    End Sub

    Sub Consultar_Operarios(ByVal _Fecha As Date, ByVal _Placa As String, ByVal _Turno As Int16)

        If String.IsNullOrEmpty(_Placa) Then
            Return
        End If

        Entidad.Activo = New ETActivo
        Negocio.Activo = New NGActivo
        Entidad.MyLista = New ETMyLista
        Ls_Personal = New List(Of ETPersonal)


        Dim NumDiaxSemana As Integer
        Dim NumSemanaxAnho As Integer
        Dim Anho As Integer
        Dim FechaIni As Date
        Dim FechaFin As Date

        NumDiaxSemana = DatePart(DateInterval.Weekday, _Fecha)
        NumSemanaxAnho = DatePart(DateInterval.WeekOfYear, _Fecha, Microsoft.VisualBasic.FirstDayOfWeek.Wednesday)

        If NumDiaxSemana = 1 OrElse NumDiaxSemana = 2 OrElse NumDiaxSemana = 3 Then
            FechaIni = DateAdd(DateInterval.Day, -(3 + NumDiaxSemana), _Fecha)
            FechaFin = DateAdd(DateInterval.Day, 3 - NumDiaxSemana, _Fecha)
        Else
            FechaIni = DateAdd(DateInterval.Day, 4 - NumDiaxSemana, _Fecha)
            FechaFin = DateAdd(DateInterval.Day, 10 - NumDiaxSemana, _Fecha)
        End If

        Anho = DatePart(DateInterval.Year, _Fecha)

        If FechaIni.Year = FechaFin.Year Then
            Anho = FechaIni.Year
        Else
            Anho = FechaFin.Year
            NumSemanaxAnho = 1
        End If

        With Entidad.Activo
            .CodClase = CodClase
            .CodTipo = CodTipo
            .Placa = _Placa
            .Anho = Anho
            .Semana = NumSemanaxAnho 'DatePart(DateInterval.WeekOfYear, _Fecha, Microsoft.VisualBasic.FirstDayOfWeek.Wednesday)
            .Dia = DatePart(DateInterval.Weekday, _Fecha) + 4 : If .Dia > 7 Then .Dia -= 7
            .Fecha = _Fecha
            .Turno = _Turno
        End With

        Entidad.MyLista = Negocio.Activo.ConsultarCronogramaxPersonal(Entidad.Activo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Personal = Entidad.MyLista.Ls_Personal

    End Sub

    Sub Cargar_Operarios()

        Call CargarUltraDropDown(Drop1, Ls_Personal)

        Drop1.Visible = Boolean.TrueString
        Gpb1.Visible = Boolean.TrueString

    End Sub

    Sub SetDataBindingsForNotes()

        With Info2.DataBindingsForNotes
            .BindingContextControl = Me
            .DataSource = Entidad.MyLista.Coleccion
            .DateMember = "Fecha"
            .DescriptionMember = "Nota"
        End With

    End Sub

#End Region

#Region "Funciones"

    Function Existe_Registro(ByVal Rpt As ETActivo) As Boolean

        Dim lResult As Boolean = Boolean.FalseString

        If Rpt Is Nothing Then
            Return lResult
        End If

        With Entidad.Activo
            If Rpt.Placa = .Placa AndAlso Rpt.Fecha = .Fecha AndAlso Rpt.Turno = .Turno Then
                lResult = Boolean.TrueString
            End If
        End With

        Return lResult

    End Function

#End Region

#Region "Publicos"

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

    Private Sub Chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk1.CheckedChanged, Chk2.CheckedChanged, Chk3.CheckedChanged, Chk4.CheckedChanged
        If sender Is Chk1 Then

            Num1.ReadOnly = Not Chk1.Checked

            If Chk1.Checked = True Then
                Num1.Value = Num1.MaxValue
                Num1.SelectAll()
                Num1.Focus()
            Else
                Num1.Value = Num1.MinValue
            End If

        End If

        If sender Is Chk2 Then
            Num2.ReadOnly = Not Chk2.Checked
            If Chk2.Checked = True Then
                Num2.Value = Num2.MaxValue
                Num2.SelectAll()
                Num2.Focus()
            Else
                Num2.Value = Num2.MinValue
            End If
        End If

        If sender Is Chk3 Then
            Num3.ReadOnly = Not Chk3.Checked
            If Chk3.Checked = True Then
                Num3.Value = Num3.MaxValue
                Num3.SelectAll()
                Num3.Focus()
            Else
                Num3.Value = Num3.MinValue
            End If
        End If

        If sender Is Chk4 Then
            Num4.ReadOnly = Not Chk4.Checked
            If Chk4.Checked = True Then
                Num4.Value = Num4.MaxValue
                Num4.SelectAll()
                Num4.Focus()
            Else
                Num4.Value = Num4.MinValue
            End If
        End If
    End Sub

    Private Sub Num_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num1.ValueChanged, Num2.ValueChanged, Num3.ValueChanged, Num4.ValueChanged
        Call ValidarHora(sender)
    End Sub

    Private Sub ValidarHora(ByVal TextNum As UltraWinEditors.UltraNumericEditor)
        If IsDBNull(TextNum.Value) = False Then
            If TextNum.Value < TextNum.MinValue Then
                TextNum.Value = TextNum.MinValue
            End If
            If TextNum.Value > TextNum.MaxValue Then
                TextNum.Value = TextNum.MaxValue
            End If
        End If
        
    End Sub
End Class