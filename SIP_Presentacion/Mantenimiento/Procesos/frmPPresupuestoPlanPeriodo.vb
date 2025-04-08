Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmPPresupuestoPlanPeriodo
#Region "Declarar Variables"
    Private _Partida As String = String.Empty
    Private _PresupuestoDet As Long = 0
    Private _FechaInicio As Date = Date.Today
    Private _FechaTermino As Date = Date.Today
    Private _HabilitarDatos As Boolean = Boolean.FalseString

    Public Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Public TipoG As State
    Private _Ls_PresupuestoPlan As List(Of ETPresupuestoPlan) = Nothing
    Private _Ls_PresupuestoPlan_Del As List(Of ETPresupuestoPlan) = Nothing
#End Region
#Region "Propiedades Publicas"
    Public Property Partida() As String
        Get
            Return _Partida
        End Get
        Set(ByVal value As String)
            _Partida = value
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
    Public Property FechaInicio() As Date
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As Date)
            _FechaInicio = value
        End Set
    End Property
    Public Property FechaTermino() As Date
        Get
            Return _FechaTermino
        End Get
        Set(ByVal value As Date)
            _FechaTermino = value
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
    Public Property Ls_PresupuestoPlan() As List(Of ETPresupuestoPlan)
        Get
            Return _Ls_PresupuestoPlan
        End Get
        Set(ByVal value As List(Of ETPresupuestoPlan))
            _Ls_PresupuestoPlan = value
        End Set
    End Property
    Public Property Ls_PresupuestoPlan_Del() As List(Of ETPresupuestoPlan)
        Get
            Return _Ls_PresupuestoPlan_Del
        End Get
        Set(ByVal value As List(Of ETPresupuestoPlan))
            _Ls_PresupuestoPlan_Del = value
        End Set
    End Property
#End Region
#Region "Procedimientos Privados"
    Private Sub CargarDatos()
        Grb1.Text = Partida
        'UltraLabel2.Text = "Desde: " & FechaInicio.ToString & " al " & FechaTermino.ToString
        Dtp1.Value = FechaInicio
        Dtp2.Value = FechaTermino
        Call HabilitarControles()
        Call CargarGrillas()
        If TipoG = State.eNew Then
            _Ls_PresupuestoPlan = New List(Of ETPresupuestoPlan)
            _Ls_PresupuestoPlan_Del = New List(Of ETPresupuestoPlan)
            Call CargarUltraGrid(Grid1, _Ls_PresupuestoPlan)
        End If
    End Sub
    Private Sub CargarGrillas()
        Entidad.Presupuesto_Plan = New ETPresupuestoPlan
        Entidad.Presupuesto_Plan.PresupuestoDet = Me.PresupuestoDet
        Entidad.Presupuesto_Plan.Tipo = 4
        Entidad.MyLista = New ETMyLista
        Negocio.PresupuestoDet = New NGPresupuestoDet
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan(Entidad.Presupuesto_Plan)
        If Entidad.MyLista.Validacion Then
            _Ls_PresupuestoPlan = Entidad.MyLista.Ls_Presupuesto_Plan
        End If
        Call CargarUltraGrid(Grid1, _Ls_PresupuestoPlan)
        If Grid1.Rows.Count > 0 Then
            TipoG = State.eEdit
        Else
            TipoG = State.eNew
        End If
    End Sub
    Private Sub HabilitarControles()
        Dtp1.ReadOnly = True
        Dtp1.ReadOnly = True
        Cbo1.ReadOnly = Not HabilitarDatos
        Btn1.Enabled = HabilitarDatos
        Btn2.Enabled = HabilitarDatos
    End Sub
#End Region

#Region "Formularios"
    Private Sub frmPlanificarPeriodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Call CargarDatos()
    End Sub
#End Region

    
#Region "Grillas"
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns

            If Not (uColumn.Key = "Codigo" _
                    OrElse uColumn.Key = "FechaInicio" OrElse uColumn.Key = "FechaTerminacion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
#End Region
   
#Region "Funciones Privadas"
    Private Function AgregarCeros(ByVal Texto As String, ByVal Longitud As Short) As String
        Dim i As Short = 0
        Dim sLen As Short = 0
        Dim NewText As String = String.Empty
        sLen = Len(Texto)
        If Longitud - sLen <= 0 Then
            NewText = Mid(NewText, 1, Longitud)
        Else
            For i = 1 To Longitud - sLen
                NewText = NewText & "0"
            Next i
            NewText = NewText & Texto
        End If

        Return NewText
    End Function
#End Region
   
#Region "Botones"
    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Dim dias As Integer = 0
        Dim DiaSem As Integer = 0
        Dim DiasTemp As Integer = 0
        Dim Mes As Integer = 0
        Dim MesParcial As Integer = 0
        Dim MesTemp As Integer = 0
        Dim Fecha1 As Date = Dtp1.Value
        Dim Fecha2 As Date = Dtp2.Value
        Dim PjeTemp As Double = 0
        Dim PjeAcum As Double = 0
        Dim Pje As Double = 0
        Dim Fila As Short = 0

        If Cbo1.Value = "" Then
            MsgBox("Seleccione la Periodicidad", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If _Ls_PresupuestoPlan IsNot Nothing Then
            For Each Row As ETPresupuestoPlan In _Ls_PresupuestoPlan
                If Row.Tipo = 2 Then
                    _Ls_PresupuestoPlan_Del.Add(Row)
                End If
            Next
        End If


        _Ls_PresupuestoPlan = New List(Of ETPresupuestoPlan)

        If Cbo1.Value = "S" Then

            dias = DateDiff(DateInterval.Day, Fecha1, Fecha2)
            DiaSem = DatePart(DateInterval.Weekday, Dtp1.Value, FirstDayOfWeek.Monday)

            PjeTemp = 100 / (dias + 1)

            While dias > 0
                PjeAcum = PjeAcum + Pje
                Fila = Fila + 1
                If (7 - DiaSem) > 0 Then
                    Fecha2 = DateAdd(DateInterval.Day, (7 - DiaSem), Fecha1)
                    Pje = PjeTemp * (8 - DiaSem)
                Else
                    Fecha2 = DateAdd(DateInterval.Day, 6, Fecha1)
                    If Fecha2 > FechaTermino Then
                        Fecha2 = FechaTermino
                        DiasTemp = DateDiff(DateInterval.Day, Fecha1, Fecha2)
                        Pje = PjeTemp * (DiasTemp + 1)
                    Else
                        Pje = PjeTemp * (7)
                    End If
                End If

                Pje = Math.Round(Pje, 2)

                Entidad.Presupuesto_Plan = New ETPresupuestoPlan
                With Entidad.Presupuesto_Plan
                    .Item = Fila
                    .Periodo = Cbo1.Value
                    .Codigo = "S" & AgregarCeros(Fila.ToString, 3)
                    .FechaInicio = Fecha1
                    .FechaTerminacion = Fecha2
                    .PresupuestoDet = PresupuestoDet
                    Fecha1 = DateAdd(DateInterval.Day, 1, Fecha2)
                    dias = DateDiff(DateInterval.Day, Fecha1, FechaTermino)
                    dias = dias + 1
                    If dias > 0 Then
                        .Porcentaje = Pje
                    Else
                        Pje = 100 - PjeAcum
                        Pje = Math.Round(Pje, 2)
                        .Porcentaje = Math.Round(Pje, 2)
                    End If
                    .Usuario = User_Sistema
                    .Tipo = 1
                End With
                _Ls_PresupuestoPlan.Add(Entidad.Presupuesto_Plan)

                DiaSem = 7
            End While

        ElseIf Cbo1.Value = "M" Then
            Mes = DateDiff(DateInterval.Month, Fecha1, Fecha2)
            dias = DateDiff(DateInterval.Day, Fecha1, Fecha2)
            PjeTemp = 100 / (dias + 1)
            Mes = Mes + 1
            While Mes > 0
                PjeAcum = PjeAcum + Pje
                Fila = Fila + 1

                Fecha2 = DateAdd(DateInterval.Month, 1, Fecha1)
                DiasTemp = DatePart(DateInterval.Day, Fecha2)
                DiasTemp = DiasTemp * (-1)
                Fecha2 = DateAdd(DateInterval.Day, DiasTemp, Fecha2)

                If Fecha2 > FechaTermino Then
                    Fecha2 = FechaTermino
                End If

                If Mes = 1 Then
                    Mes = 0
                    Pje = 100 - PjeAcum
                Else

                    DiasTemp = DateDiff(DateInterval.Day, Fecha1, Fecha2)
                    Pje = PjeTemp * (DiasTemp + 1)
                End If

                Pje = Math.Round(Pje, 2)

                Entidad.Presupuesto_Plan = New ETPresupuestoPlan
                With Entidad.Presupuesto_Plan
                    .Item = Fila
                    .Periodo = Cbo1.Value
                    .Codigo = "M" & AgregarCeros(Fila.ToString, 3)
                    .FechaInicio = Fecha1
                    .FechaTerminacion = Fecha2
                    .PresupuestoDet = PresupuestoDet
                    .Porcentaje = Pje
                    .Usuario = User_Sistema
                    .Tipo = 1
                End With
                _Ls_PresupuestoPlan.Add(Entidad.Presupuesto_Plan)
                Fecha1 = DateAdd(DateInterval.Day, 1, Fecha2)
                If Mes > 0 Then
                    Mes = DateDiff(DateInterval.Month, Fecha1, FechaTermino)
                    Mes = Mes + 1
                End If

            End While
        Else
            Entidad.Presupuesto_Plan = New ETPresupuestoPlan
            With Entidad.Presupuesto_Plan
                .Item = Fila
                .Periodo = Cbo1.Value
                .PresupuestoDet = PresupuestoDet
                .Codigo = "T001"
                .FechaIngreso = Dtp1.Value
                .FechaTerminacion = Dtp2.Value
                .Porcentaje = 100
                .Usuario = User_Sistema
                .Tipo = 1
            End With
            _Ls_PresupuestoPlan.Add(Entidad.Presupuesto_Plan)
        End If
        Call CargarUltraGrid(Grid1, _Ls_PresupuestoPlan)
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        If TipoG = State.eNew Then
            _Ls_PresupuestoPlan = Nothing
            _Ls_PresupuestoPlan = New List(Of ETPresupuestoPlan)
            Call CargarUltraGrid(Grid1, _Ls_PresupuestoPlan)
        Else
            _Ls_PresupuestoPlan_Del = Nothing
            _Ls_PresupuestoPlan_Del = New List(Of ETPresupuestoPlan)
            _Ls_PresupuestoPlan_Del = _Ls_PresupuestoPlan
            _Ls_PresupuestoPlan = New List(Of ETPresupuestoPlan)
            Call CargarUltraGrid(Grid1, Ls_PresupuestoPlan)
            TipoG = State.eNew
        End If
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        Grid1.UpdateData()
        Me.Close()
    End Sub
#End Region


End Class