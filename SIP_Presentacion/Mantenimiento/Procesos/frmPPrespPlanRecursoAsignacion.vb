Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction


Public Class frmPPrespPlanRecursoAsignacion

#Region "Declarar Variables"
    Private _FamiliaEquipo As Long = 0
    Private _Cargo As String = String.Empty
    Private _Equipo As Long = 0
    Private _Personal As String = String.Empty
    Private _Fecha As Date = Date.Today
    Private _Horas As Integer = 0
    Private _Horas_Temp As Integer = 0

    Private _PresupuestoDet As Long = 0
    Private _PresupuestoPlan As Long = 0
    Private _PlanRecurso As Long = 0
    Private _PlanRecursoAsignacion As Long = 0
    Private _Lista_Asignar_Recurso As List(Of ETPresupuestoPlanRecursosAsignacion) = Nothing
    Private _Lista_Asignar_Recurso_Del As List(Of ETPresupuestoPlanRecursosAsignacion) = Nothing
    Private _HabilitarDatos As Boolean = True
    Private _Equipo_Input As Long = 0
    Private Indice As Integer = -1

    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eSelect = 4
    End Enum
    Private TipoG As State

#End Region

#Region "Propiedades Publicas"
    Public Property EquipoInput() As Long
        Get
            Return _Equipo_Input
        End Get
        Set(ByVal value As Long)
            _Equipo_Input = value
        End Set
    End Property
    Public Property FamiliaEquipo() As Long
        Get
            Return _FamiliaEquipo
        End Get
        Set(ByVal value As Long)
            _FamiliaEquipo = value
        End Set
    End Property
    Public Property Cargo() As String
        Get
            Return _Cargo
        End Get
        Set(ByVal value As String)
            _Cargo = value
        End Set
    End Property
    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property
    Public Property Horas() As Integer
        Get
            Return _Horas
        End Get
        Set(ByVal value As Integer)
            _Horas = value
        End Set
    End Property
    Public Property PresupuestoDet() As Long
        Get
            Return _PresupuestoDet
        End Get
        Set(ByVal value As Long)
            _PresupuestoDet = value
        End Set
    End Property
    Public Property PresupuestoPlan() As Long
        Get
            Return _PresupuestoPlan
        End Get
        Set(ByVal value As Long)
            _PresupuestoPlan = value
        End Set
    End Property
    Public Property PlanRecurso() As Long
        Get
            Return _PlanRecurso
        End Get
        Set(ByVal value As Long)
            _PlanRecurso = value
        End Set
    End Property
    Public Property PlanRecursoAsignacion() As Long
        Get
            Return _PlanRecursoAsignacion
        End Get
        Set(ByVal value As Long)
            _PlanRecursoAsignacion = value
        End Set
    End Property
    Public Property HabilitarDatos() As Boolean
        Get
            Return _HabilitarDatos
        End Get
        Set(ByVal value As Boolean)
            _HabilitarDatos = value
        End Set
    End Property
    Public ReadOnly Property PrespPlanRecursoAsignacion() As List(Of ETPresupuestoPlanRecursosAsignacion)
        Get
            Return _Lista_Asignar_Recurso
        End Get
    End Property
    Public ReadOnly Property PrespPlanRecursoAsignacion_Del() As List(Of ETPresupuestoPlanRecursosAsignacion)
        Get
            Return _Lista_Asignar_Recurso_Del
        End Get
    End Property
#End Region

#Region "Propiedades Privadas"
    Private Property Equipo() As Long
        Get
            Return _Equipo
        End Get
        Set(ByVal value As Long)
            _Equipo = value
        End Set
    End Property

    Private Property Personal() As String
        Get
            Return _Personal
        End Get
        Set(ByVal value As String)
            _Personal = value
        End Set
    End Property
    Private Property Horas_Temp() As Integer
        Get
            Return _Horas_Temp
        End Get
        Set(ByVal value As Integer)
            _Horas_Temp = value
        End Set
    End Property
#End Region

#Region "Funciones Privadas"
    Private Function Validar_Horas(ByVal Tipo As String) As Integer
        Dim Existe As Integer = 0

        Entidad.Presupuesto_Plan_Recurso_Asignacion = New ETPresupuestoPlanRecursosAsignacion
        With Entidad.Presupuesto_Plan_Recurso_Asignacion
            .PlanRecurso = Me.PlanRecurso
            If Tipo = "EQ" Then
                .Recurso = Me.Equipo
                .HoraInicio = mTxt1.Value.ToString
                .HoraFin = mTxt2.Value.ToString
            Else
                .Codigo = Txt3.Text
                .HoraInicio = mTxt3.Value.ToString
                .HoraFin = mTxt4.Value.ToString
            End If
            .Tipo = 5
        End With


        If Tipo = "EQ" Then
            Existe = Negocio.PresupuestoDet.Validar_Presupuesto_Plan_Equipo_Asignacion(Entidad.Presupuesto_Plan_Recurso_Asignacion)
        Else
            Existe = Negocio.PresupuestoDet.Validar_Presupuesto_Plan_ManoObra_Asignacion(Entidad.Presupuesto_Plan_Recurso_Asignacion)
        End If
        Negocio.PresupuestoDet = New NGPresupuestoDet

        Return Existe
    End Function

    Public Function ValidarHoraInicio_HoraFin(ByVal Tipo As String) As Boolean
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim Hora_x As DateTime
        Dim Hora_y As DateTime
        Dim Hora_i As DateTime
        Dim Hora_f As DateTime
        Dim Equipo1 As Long = 0
        Dim Equipo2 As Long = 0
        Dim Empleado1 As String = String.Empty
        Dim Empleado2 As String = String.Empty

        ValidarHoraInicio_HoraFin = True
        If Tipo = "EQ" Then
            Hora_x = mTxt1.Value
            Hora_y = mTxt2.Value
            Equipo1 = Me.Equipo

            If Grid1.Rows.Count > 0 Then

                For i = 0 To Grid1.Rows.Count - 1
                    Hora_i = Grid1.Rows(i).Cells("HoraInicio").Value
                    Hora_f = Grid1.Rows(i).Cells("HoraFin").Value
                    Equipo2 = Grid1.Rows(i).Cells("Recurso").Value

                    If Indice <> i Then
                        If Equipo1 = Equipo2 Then
                            If Hora_x <= Hora_i And Hora_f <= Hora_y Then
                                MsgBox("El Rango de Horas ya pertenece a otro rango", MsgBoxStyle.Critical, msgComacsa)
                                ValidarHoraInicio_HoraFin = False
                                Return ValidarHoraInicio_HoraFin
                            ElseIf Hora_i <= Hora_x And Hora_y <= Hora_f Then
                                MsgBox("El Rango de Horas ya pertenece a otro rango", MsgBoxStyle.Critical, msgComacsa)
                                ValidarHoraInicio_HoraFin = False
                                Return ValidarHoraInicio_HoraFin
                            ElseIf Hora_x <= Hora_i And Hora_y <= Hora_f And Hora_y > Hora_i Then
                                MsgBox("El Rango de Horas ya pertenece a otro rango", MsgBoxStyle.Critical, msgComacsa)
                                ValidarHoraInicio_HoraFin = False
                                Return ValidarHoraInicio_HoraFin
                            ElseIf Hora_x < Hora_f And Hora_f <= Hora_y Then
                                MsgBox("El Rango de Horas ya pertenece a otro rango", MsgBoxStyle.Critical, msgComacsa)
                                ValidarHoraInicio_HoraFin = False
                                Return ValidarHoraInicio_HoraFin
                            End If
                        End If
                    End If
                Next

            End If
        Else
            Hora_x = mTxt3.Value
            Hora_y = mTxt4.Value
            Empleado1 = Txt3.Text.Trim

            If Grid2.Rows.Count > 0 Then

                For i = 0 To Grid2.Rows.Count - 1
                    Hora_i = Grid2.Rows(i).Cells("HoraInicio").Value
                    Hora_f = Grid2.Rows(i).Cells("HoraFin").Value
                    Empleado2 = Grid2.Rows(i).Cells("Codigo").Value.ToString.Trim

                    If Indice <> i Then
                        If Empleado1 = Empleado2 Then
                            If Hora_x <= Hora_i And Hora_f <= Hora_y Then
                                MsgBox("El Rango de Horas ya pertenece a otro rango", MsgBoxStyle.Critical, msgComacsa)
                                ValidarHoraInicio_HoraFin = False
                                Return ValidarHoraInicio_HoraFin
                            ElseIf Hora_i <= Hora_x And Hora_y <= Hora_f Then
                                MsgBox("El Rango de Horas ya pertenece a otro rango", MsgBoxStyle.Critical, msgComacsa)
                                ValidarHoraInicio_HoraFin = False
                                Return ValidarHoraInicio_HoraFin
                            ElseIf Hora_x <= Hora_i And Hora_y <= Hora_f And Hora_y > Hora_i Then
                                MsgBox("El Rango de Horas ya pertenece a otro rango", MsgBoxStyle.Critical, msgComacsa)
                                ValidarHoraInicio_HoraFin = False
                                Return ValidarHoraInicio_HoraFin
                            ElseIf Hora_x < Hora_f And Hora_f <= Hora_y Then
                                MsgBox("El Rango de Horas ya pertenece a otro rango", MsgBoxStyle.Critical, msgComacsa)
                                ValidarHoraInicio_HoraFin = False
                                Return ValidarHoraInicio_HoraFin
                            End If
                        End If
                    End If
                Next
            End If
        End If
    End Function

    Private Function ValidarDatos() As Boolean
        Dim msgTexto As String = String.Empty

        ValidarDatos = True
        EP1.Clear()

        If Tab1.Tabs("T01").Visible = True Then
            If String.IsNullOrEmpty(Txt1.Text) Then
                msgTexto = "Asignar un(a) " & Cbo1.Text
                EP1.SetError(Txt1, msgTexto)
                ValidarDatos = False
            End If

            If Val(Equipo) <= 0 Then
                msgTexto = "Asignar un(a) " & Cbo1.Text
                EP1.SetError(Txt1, msgTexto)
                ValidarDatos = False
            End If

            If Not (IsDate(mTxt1.Value)) Then
                msgTexto = "Ingrese un Hora de Inicio Válida"
                EP1.SetError(mTxt1, msgTexto)
                ValidarDatos = False
            End If

            If Not (IsDate(mTxt2.Value)) Then
                msgTexto = "Ingrese un Hora de Fin Válida"
                EP1.SetError(mTxt2, msgTexto)
                ValidarDatos = False
            End If

            If Validar_Horas("EQ") > 0 Then
                msgTexto = "El equipo esta asignado para otro trabajo"
                EP1.SetError(mTxt2, msgTexto)
            End If
        Else
            If String.IsNullOrEmpty(Txt3.Text) Then
                msgTexto = "Asignar un(a) " & Cbo2.Text
                EP1.SetError(Txt3, msgTexto)
                ValidarDatos = False
            End If

            If Not (IsDate(mTxt3.Value)) Then
                msgTexto = "Ingrese un Hora de Inicio Válida"
                EP1.SetError(mTxt3, msgTexto)
                ValidarDatos = False
            End If

            If Not (IsDate(mTxt4.Value)) Then
                msgTexto = "Ingrese un Hora de Fin Válida"
                EP1.SetError(mTxt4, msgTexto)
                ValidarDatos = False
            End If

            If Validar_Horas("MO") > 0 Then
                msgTexto = "El Empleado esta asignado para otro trabajo"
                EP1.SetError(mTxt2, msgTexto)
            End If
        End If
    End Function
#End Region

#Region "Procedimientos Privadas"

    Private Function Calcular_Horas(ByVal Tipo As String) As Double
        Dim Suma As Double = 0
        Dim Valor As Double = 0


        If TipoG = State.eEdit Then
            Suma = Suma - Horas_Temp
        End If

        If Tipo = "EQ" Then
            If Grid1.Rows.Count > 0 Then
                For Each Row As UltraGridRow In Grid1.Rows
                    Suma = Suma + Row.Cells("Horas").Value
                Next
            End If
            Valor = Val(DateDiff(DateInterval.Minute, mTxt1.Value, mTxt2.Value)) / 60

        Else
            If Grid2.Rows.Count > 0 Then
                For Each Row As UltraGridRow In Grid2.Rows
                    Suma = Suma + Row.Cells("Horas").Value
                Next
            End If
            Valor = Val(DateDiff(DateInterval.Minute, mTxt3.Value, mTxt4.Value)) / 60

        End If
        Suma = Suma + Valor
        Return Suma
    End Function

    Private Function Validar_Horas_Asignar(ByVal Tipo As String) As Double
        Dim Valor As Double = 0

        If Tipo = "EQ" Then
            Valor = Val(DateDiff(DateInterval.Minute, mTxt1.Value, mTxt2.Value)) / 60
        Else
            Valor = Val(DateDiff(DateInterval.Minute, mTxt3.Value, mTxt4.Value)) / 60
        End If

        Return Valor

    End Function

    Private Sub Cargar_FamiliaEquipo()
        Dim Lista As New List(Of ETFamiliaEquipo)

        Entidad.MyLista = New ETMyLista
        Negocio.FamiliaEquipo = New NGFamiliaEquipo
        Entidad.MyLista = Negocio.FamiliaEquipo.ConsultarFamiliaEquipo_Todos()
        If Entidad.MyLista.Validacion = True Then
            Lista = Entidad.MyLista.Ls_FamiliaEquipo
        End If

        Call CargarUltraCombo(Cbo1, Lista, "IDCatalogo", "Descripcion")
        Cbo1.Value = FamiliaEquipo
    End Sub

    Private Sub Cargar_CargoEmpleado()
        Dim Lista As New List(Of ETMaestos2)
        Entidad.Maestro2 = New ETMaestos2
        Entidad.Maestro2.CiaMaestro = Companhia & "008"
        Entidad.MyLista = New ETMyLista
        Negocio.Maestro = New NGMaestro
        Entidad.MyLista = Negocio.Maestro.ConsultarMaestro2(Entidad.Maestro2)
        If Entidad.MyLista.Validacion = True Then
            Lista = Entidad.MyLista.Ls_Maestro2
        End If

        Call CargarUltraCombo(Cbo2, Lista, "Codigo", "Descripcion")
        Cbo2.Value = Cargo
    End Sub

    Private Sub Habilitar_Controles(ByVal xBol As Boolean)
        Cbo1.ReadOnly = True
        Cbo2.ReadOnly = True
        Txt1.ReadOnly = True
        Txt2.ReadOnly = True
        Txt3.ReadOnly = True
        Txt4.ReadOnly = True
        mTxt1.ReadOnly = Not xBol
        mTxt2.ReadOnly = Not xBol
        mTxt3.ReadOnly = Not xBol
        mTxt4.ReadOnly = Not xBol
        Btn1.Enabled = False
        Btn2.Enabled = xBol
        Btn3.Enabled = False
        Btn4.Enabled = xBol
        Btn5.Enabled = xBol
        Btn6.Enabled = False
        Btn7.Enabled = xBol
        Btn8.Enabled = False
        Btn9.Enabled = xBol
        Btn10.Enabled = xBol
    End Sub

    Private Sub VisualizarTab()
        Select Case Mid(Me.Tag, 2, 2)
            Case "08"
                Call Cargar_FamiliaEquipo()
                Me.Tab1.Tabs("T02").Visible = False
            Case "09"
                Me.Tab1.Tabs("T01").Visible = False
                Call Cargar_CargoEmpleado()
        End Select
    End Sub

    Private Sub Iniciar()
        _Lista_Asignar_Recurso = New List(Of ETPresupuestoPlanRecursosAsignacion)
        Entidad.Presupuesto_Plan_Recurso_Asignacion = New ETPresupuestoPlanRecursosAsignacion
        With Entidad.Presupuesto_Plan_Recurso_Asignacion
            .PlanRecurso = Me.PlanRecurso
            .Tipo = 4
        End With

        If Me.Tab1.Tabs("T01").Visible = True Then
            Negocio.PresupuestoDet = New NGPresupuestoDet
            Entidad.MyLista = New ETMyLista
            Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan_Equipo_Asignacion(Entidad.Presupuesto_Plan_Recurso_Asignacion)
            If Entidad.MyLista.Validacion Then
                _Lista_Asignar_Recurso = Entidad.MyLista.Ls_Presupuesto_Plan_Recurso_Asignacion
            End If
            Call CargarUltraGrid(Grid1, _Lista_Asignar_Recurso)
        Else
            Entidad.MyLista = New ETMyLista
            Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan_ManoObra_Asignacion(Entidad.Presupuesto_Plan_Recurso_Asignacion)
            If Entidad.MyLista.Validacion Then
                _Lista_Asignar_Recurso = Entidad.MyLista.Ls_Presupuesto_Plan_Recurso_Asignacion
            End If
            Call CargarUltraGrid(Grid2, _Lista_Asignar_Recurso)
        End If

        _Lista_Asignar_Recurso_Del = New List(Of ETPresupuestoPlanRecursosAsignacion)


    End Sub

    Private Sub HabilitarBotones(ByVal Recurso As String)

        If Recurso = "EQ" Then
            Select Case TipoG
                Case State.eNew, State.eEdit
                    Btn1.Enabled = True
                    Btn3.Enabled = True
                    Btn4.Enabled = False
                    Btn5.Enabled = False
                Case State.eSelect
                    Btn1.Enabled = False
                    Btn3.Enabled = False
                    Btn4.Enabled = True
                    Btn5.Enabled = True
            End Select
        Else
            Select Case TipoG
                Case State.eNew, State.eEdit
                    Btn6.Enabled = True
                    Btn8.Enabled = True
                    Btn9.Enabled = False
                    Btn10.Enabled = False
                Case State.eSelect
                    Btn6.Enabled = False
                    Btn8.Enabled = False
                    Btn9.Enabled = True
                    Btn10.Enabled = True
            End Select
        End If

    End Sub
#End Region

    Private Sub frmPPrespPlanRecursoAsignacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Call VisualizarTab()
        Call Habilitar_Controles(HabilitarDatos)
        Call Iniciar()

    End Sub

#Region "Combo"
    Private Sub Combo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo1.InitializeLayout, Cbo2.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            uColumn.CellActivation = Activation.NoEdit
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

#End Region

#Region "Botones"
    Private Sub Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click, Btn6.Click
        Dim frmHijo As New frmBuscar
        If sender Is Btn1 Then
            frmHijo.Formulario = frmBuscar.eState.frm_Equipo_Por_Familia
            frmHijo.ID_Input = Me.FamiliaEquipo
            frmHijo.Codigo_Input = Me.EquipoInput
        Else
            frmHijo.Formulario = frmBuscar.eState.frm_Cargo_Empleado
            frmHijo.Codigo_Input = Me.Cargo
            frmHijo.FechaInput = Me.Fecha
        End If

        frmHijo.ShowDialog()
        If sender Is Btn1 Then
            Me.Txt1.Text = frmHijo.Flag2
            Me.Txt2.Text = frmHijo.Descripcion
        Else
            Me.Txt3.Text = frmHijo.Flag2
            Me.Txt4.Text = frmHijo.Descripcion
        End If
       
        If sender Is Btn1 Then
            Equipo = frmHijo.ID
        End If

        frmHijo = Nothing
    End Sub
    Private Sub Limpiar(ByVal Tipo As String)
        EP1.Clear()
        If Tipo = "EQ" Then
            Txt1.Clear()
            Txt2.Clear()
            mTxt1.Value = ""
            mTxt2.Value = ""
            _Equipo = 0
        Else
            Txt3.Clear()
            Txt4.Clear()
            mTxt3.Value = ""
            mTxt4.Value = ""
            _Personal = ""
        End If
        Indice = -1
        _PlanRecursoAsignacion = 0
        _Horas_Temp = 0
    End Sub

    Private Sub Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click, Btn7.Click
        If sender Is Btn2 Then
            If Btn2.Tag = 4 Then
                Call Limpiar("EQ")
                TipoG = State.eSelect
                Call HabilitarBotones("EQ")
                Btn2.Appearance.Image = My.Resources.Document_01
                Btn2.Tag = 1
            Else
                TipoG = State.eNew
                Call Limpiar("EQ")
                Call HabilitarBotones("EQ")
                Btn2.Appearance.Image = My.Resources.Cancelar
                Btn2.Tag = 4
                Btn1.Focus()
            End If
        Else
            If Btn7.Tag = 4 Then
                Call Limpiar("MO")
                TipoG = State.eSelect
                Call HabilitarBotones("MO")
                Btn7.Appearance.Image = My.Resources.Document_01
                Btn7.Tag = 1
            Else
                TipoG = State.eNew
                Call Limpiar("MO")
                Call HabilitarBotones("MO")
                Btn7.Appearance.Image = My.Resources.Cancelar
                Btn7.Tag = 4
                Btn6.Focus()
            End If
        End If

    End Sub

    Private Sub Agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click, Btn8.Click
        Dim Tipo As String = String.Empty
        If sender Is Btn3 Then
            Tipo = "EQ"
        Else
            Tipo = "MO"
        End If

        If ValidarDatos() = False Then
            Exit Sub
        End If

        If Validar_Horas_Asignar(Tipo) <= 0 Then
            MsgBox("La diferencia de las horas deben ser mayor a cero", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If ValidarHoraInicio_HoraFin(Tipo) = False Then
            Exit Sub
        End If
        If Calcular_Horas(Tipo) > Horas Then
            MsgBox("Las Horas a Asignar es mayor a Total de Horas asignadas", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        mTxt1.EndUpdate()
        mTxt2.EndUpdate()
        mTxt3.EndUpdate()
        mTxt4.EndUpdate()

        If TipoG = State.eNew Then
            Entidad.Presupuesto_Plan_Recurso_Asignacion = New ETPresupuestoPlanRecursosAsignacion
            With Entidad.Presupuesto_Plan_Recurso_Asignacion
                If sender Is Btn3 Then
                    .Codigo = Txt1.Text
                    .Descripcion = Txt2.Text
                    .HoraInicio = mTxt1.Value
                    .HoraFin = mTxt2.Value
                    .Horas = Val(DateDiff(DateInterval.Minute, mTxt1.Value, mTxt2.Value)) / 60
                    .Recurso = Me.Equipo
                Else
                    .Codigo = Txt3.Text
                    .Descripcion = Txt4.Text
                    .HoraInicio = mTxt3.Value
                    .HoraFin = mTxt4.Value
                    .Horas = Val(DateDiff(DateInterval.Minute, mTxt3.Value, mTxt4.Value)) / 60
                End If
                .Tipo = Me.TipoG
                .Usuario = User_Sistema
                .Fecha = Me.Fecha
                .PresupuestoDet = Me.PresupuestoDet
                .PresupuestoPlan = Me.PresupuestoPlan
                .PlanRecurso = Me.PlanRecurso
            End With
            _Lista_Asignar_Recurso.Add(Entidad.Presupuesto_Plan_Recurso_Asignacion)

            If sender Is Btn3 Then
                Call CargarUltraGrid(Grid1, _Lista_Asignar_Recurso)
            Else
                Call CargarUltraGrid(Grid2, _Lista_Asignar_Recurso)
            End If
        Else
            If sender Is Btn3 Then
                If Grid1.ActiveRow Is Nothing Then Return
                Grid1.ActiveRow.Cells("Codigo").Value = Txt1.Text
                Grid1.ActiveRow.Cells("Descripcion").Value = Txt2.Text
                Grid1.ActiveRow.Cells("HoraInicio").Value = mTxt1.Value.ToString
                Grid1.ActiveRow.Cells("HoraFin").Value = mTxt2.Value.ToString
                Grid1.ActiveRow.Cells("Horas").Value = Val(DateDiff(DateInterval.Minute, mTxt1.Value, mTxt2.Value)) / 60
                Grid1.ActiveRow.Cells("Recurso").Value = Me.Equipo
                Grid1.ActiveRow.Cells("Usuario").Value = User_Sistema
                Grid1.UpdateData()
            Else
                Grid2.ActiveRow.Cells("Codigo").Value = Txt3.Text
                Grid2.ActiveRow.Cells("Descripcion").Value = Txt4.Text
                Grid2.ActiveRow.Cells("HoraInicio").Value = mTxt3.Value.ToString
                Grid2.ActiveRow.Cells("HoraFin").Value = mTxt4.Value.ToString
                Grid2.ActiveRow.Cells("Horas").Value = Val(DateDiff(DateInterval.Minute, mTxt3.Value, mTxt4.Value)) / 60
                Grid1.ActiveRow.Cells("Usuario").Value = User_Sistema
                Grid2.UpdateData()
            End If
        End If

        TipoG = State.eSelect
        If sender Is Btn3 Then
            Call Limpiar("EQ")
            Call HabilitarBotones("EQ")
            Btn2.Appearance.Image = My.Resources.Document_01
            Btn2.Tag = 1
        Else
            Call Limpiar("MO")
            Call HabilitarBotones("MO")
            Btn7.Appearance.Image = My.Resources.Document_01
            Btn7.Tag = 1
        End If

    End Sub

    Private Sub Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click, Btn9.Click

        If sender Is Btn4 Then

        End If
        If Grid1.Rows.Count <= 0 Then Return
        If Grid1.ActiveRow Is Nothing Then Return
        TipoG = State.eEdit
        If sender Is Btn4 Then
            Indice = Grid1.ActiveRow.Index
            PlanRecursoAsignacion = Grid1.ActiveRow.Cells("PlanRecursoAsignacion").Value
            Txt1.Text = Grid1.ActiveRow.Cells("Codigo").Value
            Txt2.Text = Grid1.ActiveRow.Cells("Descripcion").Value
            mTxt1.Value = CStr(Grid1.ActiveRow.Cells("HoraInicio").Value)
            mTxt2.Value = CStr(Grid1.ActiveRow.Cells("HoraFin").Value)
            Me.Horas_Temp = Grid1.ActiveRow.Cells("Horas").Value
            Equipo = Grid1.ActiveRow.Cells("Recurso").Value

            Call HabilitarBotones("EQ")
            Btn2.Appearance.Image = My.Resources.Cancelar
            Btn2.Tag = 4
        Else
            Indice = Grid2.ActiveRow.Index
            PlanRecursoAsignacion = Grid2.ActiveRow.Cells("PlanRecursoAsignacion").Value
            Txt3.Text = Grid2.ActiveRow.Cells("Codigo").Value
            Txt4.Text = Grid2.ActiveRow.Cells("Descripcion").Value
            mTxt3.Value = CStr(Grid2.ActiveRow.Cells("HoraInicio").Value)
            mTxt4.Value = CStr(Grid2.ActiveRow.Cells("HoraFin").Value)
            Me.Horas_Temp = Grid2.ActiveRow.Cells("Horas").Value
            Call HabilitarBotones("MO")
            Btn7.Appearance.Image = My.Resources.Cancelar
            Btn7.Tag = 4
        End If
    End Sub

    Private Sub Quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click, Btn10.Click

        Dim msgTexto As String = String.Empty

        If sender Is Btn5 Then
            If Me.Grid1.Rows.Count <= 0 Then Return
            If Me.Grid1.ActiveRow Is Nothing Then Return
            msgTexto = "Esta Seguro de quitar al Equipo: " & Grid1.ActiveRow.Cells("Codigo").Value
        Else
            If Me.Grid2.Rows.Count <= 0 Then Return
            If Me.Grid2.ActiveRow Is Nothing Then Return
            msgTexto = "Esta Seguro de quitar al Personal: " & Grid2.ActiveRow.Cells("Codigo").Value
        End If

        If MsgBox(msgTexto, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        If sender Is Btn5 Then
            If Grid1.ActiveRow.Cells("Tipo").Value <> 2 Then
                _Lista_Asignar_Recurso.RemoveAt(Grid1.ActiveRow.Index)
                Call CargarUltraGrid(Grid1, _Lista_Asignar_Recurso)
                Exit Sub
            End If
        Else
            If Grid2.ActiveRow.Cells("Tipo").Value <> 2 Then
                _Lista_Asignar_Recurso.RemoveAt(Grid2.ActiveRow.Index)
                Call CargarUltraGrid(Grid2, _Lista_Asignar_Recurso)
                Exit Sub
            End If
        End If

        Entidad.Presupuesto_Plan_Recurso_Asignacion = New ETPresupuestoPlanRecursosAsignacion
        If sender Is Btn5 Then
            With Entidad.Presupuesto_Plan_Recurso_Asignacion
                .Recurso = Grid1.ActiveRow.Cells("Recurso").Value
                .Tipo = 3
                .Usuario = User_Sistema
                .PresupuestoDet = Grid1.ActiveRow.Cells("PresupuestoDet").Value
                .PresupuestoPlan = Grid1.ActiveRow.Cells("PresupuestoPlan").Value
                .PlanRecurso = Grid1.ActiveRow.Cells("PlanRecurso").Value
                .PlanRecursoAsignacion = Grid1.ActiveRow.Cells("PlanRecursoAsignacion").Value
            End With
        Else
            With Entidad.Presupuesto_Plan_Recurso_Asignacion
                .Codigo = Grid2.ActiveRow.Cells("Codigo").Value
                .Tipo = 3
                .Usuario = User_Sistema
                .PresupuestoDet = Grid2.ActiveRow.Cells("PresupuestoDet").Value
                .PresupuestoPlan = Grid2.ActiveRow.Cells("PresupuestoPlan").Value
                .PlanRecurso = Grid2.ActiveRow.Cells("PlanRecurso").Value
                .PlanRecursoAsignacion = Grid2.ActiveRow.Cells("PlanRecursoAsignacion").Value
            End With
        End If


        _Lista_Asignar_Recurso_Del.Add(Entidad.Presupuesto_Plan_Recurso_Asignacion)
        _Lista_Asignar_Recurso.RemoveAt(Grid1.ActiveRow.Index)
        Call CargarUltraGrid(Grid1, _Lista_Asignar_Recurso)

        TipoG = State.eSelect
        If sender Is Btn5 Then
            Call HabilitarBotones("EQ")
        Else
            Call HabilitarBotones("MO")
        End If
    End Sub
#End Region

#Region "Grilla"
    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                    OrElse uColumn.Key = "HoraInicio" OrElse uColumn.Key = "HoraFin" _
                    OrElse uColumn.Key = "Horas") Then
                uColumn.Hidden = True
            Else
                'If uColumn.Key = "HoraInicio" OrElse uColumn.Key = "HoraFin" Then
                '    uColumn.MaskInput = "{LOC}hh:mm tt"
                'End If
                uColumn.Hidden = False
            End If
        Next
    End Sub
#End Region

#Region "Texto"
    Private Sub mTxt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mTxt1.KeyPress, mTxt2.KeyPress, mTxt3.KeyPress, mTxt4.KeyPress
        If sender Is mTxt1 Then
            If Asc(e.KeyChar) = 13 Then
                mTxt2.Focus()
            End If
        End If

        If sender Is mTxt2 Then
            If Asc(e.KeyChar) = 13 Then
                If Btn3.Enabled = True Then Btn3.Focus()
            End If
        End If

        If sender Is mTxt3 Then
            If Asc(e.KeyChar) = 13 Then
                mTxt4.Focus()
            End If
        End If

        If sender Is mTxt4 Then
            If Asc(e.KeyChar) = 13 Then
                If Btn8.Enabled = True Then Btn8.Focus()
            End If
        End If
    End Sub

#End Region
   
End Class