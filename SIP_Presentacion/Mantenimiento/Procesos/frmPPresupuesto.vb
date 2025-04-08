Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Excel
Public Class frmPPresupuesto
#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private Enum ValorTipoDato
        vVacio = 0
        vTexto = 1
        vEntero = 2
        vDecimal = 3
        vDate = 4
        vTime = 5
    End Enum
    Dim TipoDato As ValorTipoDato
    Private TipoG As State
    Private _Longitud As Short = 0
    Private _Decimal As Short = 0
    Private _Presupuesto As Long = 0
    Private _JefeArea As String = String.Empty
    Private _Cliente As String = String.Empty
    Private _Equipo As Long = 0
    Private _AreaInt As String = String.Empty
    Private _Atributo As Long = 0

    Private _FechaInicioJA As String = String.Empty
    Private _FechaTerminoJA As String = String.Empty
    Private _FechaInicioEA As String = String.Empty
    Private _FechaTerminoEA As String = String.Empty

    Private Ls_Pres_Det As List(Of ETPresupuestoDetalle) = Nothing
    Private Ls_Pres_Det_Del As List(Of ETPresupuestoDetalle) = Nothing

    Private Ls_Material As List(Of ETPresupuestoMaterial) = Nothing
    Private Ls_Equipo As List(Of ETPresupuestoEquipo) = Nothing
    Private Ls_ManoObra As List(Of ETPresupuestoManoObra) = Nothing
    Private Ls_Servicio As List(Of ETPresupuestoServicio) = Nothing

    Private Ls_Material_Del As List(Of ETPresupuestoMaterial) = Nothing
    Private Ls_Equipo_Del As List(Of ETPresupuestoEquipo) = Nothing
    Private Ls_ManoObra_Del As List(Of ETPresupuestoManoObra) = Nothing
    Private Ls_Servicio_Del As List(Of ETPresupuestoServicio) = Nothing

    Private Ls_PresupuestoPlan As List(Of ETPresupuestoPlan) = Nothing
    Private Ls_PresupuestoPlan_Del As List(Of ETPresupuestoPlan) = Nothing

    Private Ls_PrespPlanMaterial As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private Ls_PrespPlanEquipo As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private Ls_PrespPlanManoObra As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private Ls_PrespPlanServicio As List(Of ETPresupuestoPlanRecursos) = Nothing

    Private Ls_Plan_Equipo_Asignacion As List(Of ETPresupuestoPlanRecursosAsignacion) = Nothing
    Private Ls_Plan_ManoObra_Asignacion As List(Of ETPresupuestoPlanRecursosAsignacion) = Nothing
    Private Ls_Plan_Equipo_Asignacion_Del As List(Of ETPresupuestoPlanRecursosAsignacion) = Nothing
    Private Ls_Plan_ManoObra_Asignacion_Del As List(Of ETPresupuestoPlanRecursosAsignacion) = Nothing

    Dim Obj_Excel As Object
    Dim Obj_Libro As Object
    Dim Obj_Hoja As Object

    Private Enum BordesExcel
        xlDiagonalDown = 5
        xlDiagonalUp = 6
        xlEdgeLeft = 7
        xlEdgeTop = 8
        xlEdgeBottom = 9
        xlEdgeRight = 10
        xlInsideVertical = 11
        xlInsideHorizontal = 12
    End Enum

    Private Enum EstiloLineaExcel
        xlContinuous = 1
        xlDash = -4115
        xlDashDot = 4
        xlDashDotDot = 5
        xlDot = -4118
        xlDouble = -4119
        xlLineStyleNone = -4142
        xlSlantDashDot = 13
    End Enum

    Private Enum BorderWeithExcel
        xlHairline = 1
        xlMedium = -4138
        xlThick = 4
        xlThin = 2
    End Enum

    Private Enum ConstantesExcel
        xlAutomatic = -4105
    End Enum

    Private Enum AliniacionHorizontal_Excel
        xlHAlignCenter = 3 '-4108
        xlHAlignCenterAcrossSelection = 7
        xlHAlignDistributed = -4117
        xlHAlignFill = 5
        xlHAlignGeneral = 1
        xlHAlignJustify = -4130
        xlHAlignLeft = -4131
        xlHAlignRight = -4152
    End Enum
    Private Enum AliniacionVertical_Excel
        xlVAlignBottom = -4107
        xlVAlignCenter = 2 '-4108
        xlVAlignDistributed = -4117
        xlVAlignJustify = -4130
        xlVAlignTop = -4160


    End Enum

#End Region
#Region "Propiedades"
    Private Property Presupuesto() As Long
        Get
            Return _Presupuesto
        End Get
        Set(ByVal value As Long)
            _Presupuesto = value
        End Set
    End Property
    Private Property EncargadoArea() As String
        Get
            Return _JefeArea
        End Get
        Set(ByVal value As String)
            _JefeArea = value
        End Set
    End Property
    Private Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

    Private Property Equipo() As Long
        Get
            Return _Equipo
        End Get
        Set(ByVal value As Long)
            _Equipo = value
        End Set
    End Property
    Private Property Longitud() As Short
        Get
            Return _Longitud
        End Get
        Set(ByVal value As Short)
            _Longitud = value
        End Set
    End Property
    Private Property Decimales() As Short
        Get
            Return _Decimal
        End Get
        Set(ByVal value As Short)
            _Decimal = value
        End Set
    End Property
    Private Property AreaInt() As String
        Get
            Return _AreaInt
        End Get
        Set(ByVal value As String)
            _AreaInt = value
        End Set
    End Property
    Private Property Atributo() As Long
        Get
            Return _Atributo
        End Get
        Set(ByVal value As Long)
            _Atributo = value
        End Set
    End Property
    Private Property FechaInicioJA() As String
        Get
            Return _FechaInicioJA
        End Get
        Set(ByVal value As String)
            _FechaInicioJA = value
        End Set
    End Property
    Private Property FechaTerminoJA() As String
        Get
            Return _FechaTerminoJA
        End Get
        Set(ByVal value As String)
            _FechaTerminoJA = value
        End Set
    End Property
    Private Property FechaInicioEA() As String
        Get
            Return _FechaInicioEA
        End Get
        Set(ByVal value As String)
            _FechaInicioEA = value
        End Set
    End Property
    Private Property FechaTerminoEA() As String
        Get
            Return _FechaTerminoEA
        End Get
        Set(ByVal value As String)
            _FechaTerminoEA = value
        End Set
    End Property
#End Region
#Region "formularios"

    Private Sub frmPPresupuesto_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmPPresupuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
#End Region
#Region "Grillas"
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            uColumn.CellActivation = Activation.NoEdit
            If Not (uColumn.Key = "Fecha" _
                    OrElse uColumn.Key = "Area_Abrev" OrElse uColumn.Key = "Cod_Presup" _
                    OrElse uColumn.Key = "Equipo" OrElse uColumn.Key = "TipoMantto" _
                    OrElse uColumn.Key = "Moneda" OrElse uColumn.Key = "Total" _
                    OrElse uColumn.Key = "FechaInicio" OrElse uColumn.Key = "FechaTerminacion" _
                    OrElse uColumn.Key = "Estado") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub Grid2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid2.KeyPress
        Dim KeyAscii As Integer
        If e Is Nothing Then
            Exit Sub
        End If

        If Grid2.Rows.Count <= 0 Then
            Exit Sub
        End If

        If Grid2.ActiveRow Is Nothing Then Exit Sub

        KeyAscii = Asc(e.KeyChar)

        If KeyAscii = 13 Then

            Grid2.UpdateData()
            Grid2.ActiveRow.Cells("Parcial").Value = Grid2.ActiveRow.Cells("Metrado").Value * Grid2.ActiveRow.Cells("Precio").Value
            Grid2.UpdateData()
            Grid2.PerformAction(ExitEditMode, False, False)
            Grid2.PerformAction(NextCellByTab, False, False)
            Call Calcular_Total_Fechas()

        End If

    End Sub
    Private Sub Grid2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grid2.MouseClick
        If Grid2.Rows.Count <= 0 Then
            cmnut1.Items(0).Enabled = True
            cmnut1.Items(1).Enabled = False
            cmnut1.Items(2).Enabled = False
            cmnut1.Items(4).Enabled = False
            cmnut1.Items(5).Enabled = False
        Else
            cmnut1.Items(0).Enabled = True
            cmnut1.Items(1).Enabled = True
            cmnut1.Items(2).Enabled = True
            cmnut1.Items(4).Enabled = True
            cmnut1.Items(5).Enabled = True
        End If
        If TipoG = State.eEdit Then
            If Rbn6.Enabled = False And Grid2.Rows.Count > 0 Then
                If Rbn1.Checked = False Then
                    cmnut1.Items(0).Enabled = False
                    cmnut1.Items(1).Enabled = True
                    cmnut1.Items(2).Enabled = False
                    cmnut1.Items(4).Enabled = True
                    cmnut1.Items(5).Enabled = True
                End If
               
            End If
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.Grid2.ContextMenuStrip = Me.cmnut1
            Me.Grid2.ContextMenuStrip.Show()
        End If
    End Sub
    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout
        If e Is Nothing Then
            Return
        End If



        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If uColumn.Key = "Metrado" OrElse uColumn.Key = "FechaInicio" _
            OrElse uColumn.Key = "FechaTerminacion" Then
                uColumn.CellActivation = Activation.AllowEdit
            Else
                uColumn.CellActivation = Activation.NoEdit
            End If

            If Not (uColumn.Key = "Descripcion" OrElse uColumn.Key = "UniMed" _
                    OrElse uColumn.Key = "Metrado" OrElse uColumn.Key = "Precio" _
                    OrElse uColumn.Key = "Parcial" OrElse uColumn.Key = "FechaInicio" _
                    OrElse uColumn.Key = "FechaTerminacion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

        For Each uRow As UltraGridRow In Grid2.Rows
            If Val(uRow.Cells("Contar").Value) > 0 Then
                For Each ucolumn As UltraGridColumn In e.Layout.Bands(0).Columns
                    uRow.Cells(ucolumn.Key).Activation = Activation.NoEdit
                Next
            End If
        Next
    End Sub

#End Region
#Region "Menu Contextual"
    Private Sub cmnu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu1.Click
        Dim frmAPU As New frmMPlantillaAPU
        frmAPU.Part_Presupuesto = Boolean.TrueString
        frmAPU.Atributo_Input = Atributo
        If TipoDato = ValorTipoDato.vDate OrElse TipoDato = ValorTipoDato.vTime Then
            frmAPU.Valor_Input = Txt6.Value
        Else
            frmAPU.Valor_Input = Txt5.Text
        End If
        frmAPU.TipoMantto_Input = Cbo2.Value
        frmAPU.ShowDialog()
        If frmAPU.AddPartida = Boolean.TrueString Then
            Call ReCalcularItemPresp()
            Entidad.PresupuestoDet = New ETPresupuestoDetalle
            With Entidad.PresupuestoDet
                .Item = (Grid2.Rows.Count + 1).ToString
                .Descripcion = frmAPU.Part_Descripcion
                .UniMed = frmAPU.Part_DescripUniMed
                .Precio = FormatNumber(frmAPU.Part_Total, 4)
                .Cod_UniMed = frmAPU.Part_UniMed
                .TipoFactor = frmAPU.Part_TipoFactor
                .Factor = frmAPU.Part_Factor
                .Jornada = frmAPU.Part_Jornada
                .Partida = frmAPU.Partida
                .TipoCambio = Val(Txt7.Value)
                .Presupuesto = Presupuesto
                .Usuario = User_Sistema
                .FechaInicio = Dtp2.Value
                .FechaTerminacion = Dtp3.Value
                .Tipo = 1
            End With

            Ls_Pres_Det.Add(Entidad.PresupuestoDet)
            Call CargarUltraGrid(Grid2, Ls_Pres_Det)

        End If

    End Sub
    Private Sub cmnu2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnu2.Click
        If Grid2.Rows.Count <= 0 Then Exit Sub
        If Grid2.ActiveRow Is Nothing Then Exit Sub
        Dim Total As Double = 0
        Dim Precio As Double = 0
        Dim Frm As New frmPPrespuestoRecursos
        Dim PresDet As Long = 0
        PresDet = Grid2.ActiveRow.Cells("PresupuestoDet").Value
        Frm.Presupuesto = Grid2.ActiveRow.Cells("PresupuestoDet").Value
        Frm.TipoFactor = Grid2.ActiveRow.Cells("TipoFactor").Value
        Frm.Factor = Grid2.ActiveRow.Cells("Factor").Value
        Frm.Jornada = Grid2.ActiveRow.Cells("Jornada").Value
        Frm.UniMed = Grid2.ActiveRow.Cells("Cod_UniMed").Value
        If TipoG = State.eNew Then
            Frm.SoloLectura = False
        Else
            If Val(Grid2.ActiveRow.Cells("Contar").Value) > 0 Then
                Frm.SoloLectura = True
            Else
                Frm.SoloLectura = False
            End If
        End If
        Call CargarFormularios(Frm)
        Grid2.ActiveRow.Cells("TipoFactor").Value = Frm.TipoFactor
        Grid2.ActiveRow.Cells("Factor").Value = Frm.Factor
        Grid2.ActiveRow.Cells("Jornada").Value = Frm.Jornada
        Grid2.ActiveRow.Cells("Cod_UniMed").Value = Frm.UniMed
        If Val(Txt7.Value) = 0 Then
            Precio = 0
        Else
            Precio = Frm.Total_Partida / Val(Txt7.Value)
        End If
        Grid2.ActiveRow.Cells("Precio").Value = Precio
        Total = Val(Grid2.ActiveRow.Cells("Metrado").Value) * Precio
        Grid2.ActiveRow.Cells("Parcial").Value = Total
        Call Calcular_Total_Fechas()
        Call RemoverRecursosPartida(PresDet)
        Call Agregar_Listas_Recursos(Frm.Ls_Material, Frm.Ls_Material_Del, _
            Frm.Ls_Equipo, Frm.Ls_Equipo_Del, Frm.Ls_ManoObra, Frm.Ls_ManoObra_Del, _
            Frm.Ls_Servicio, Frm.Ls_Servicio_Del)
        Grid2.UpdateData()
        Frm = Nothing

    End Sub
    Private Sub cmnu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnu3.Click
        If Grid2.Rows.Count <= 0 Then Exit Sub
        If Grid2.ActiveRow Is Nothing Then Exit Sub
        Entidad.PresupuestoDet = New ETPresupuestoDetalle
        With Entidad.PresupuestoDet
            .PresupuestoDet = Grid2.ActiveRow.Cells("PresupuestoDet").Value
            .Usuario = User_Sistema
            .Tipo = 3
        End With
        If Grid2.ActiveRow.Cells("Tipo").Value = 2 Then
            Ls_Pres_Det_Del.Add(Entidad.PresupuestoDet)
        End If
        Ls_Pres_Det.RemoveAt(Grid2.ActiveRow.Index)
        Call CargarUltraGrid(Grid2, Ls_Pres_Det)
    End Sub

    Private Sub cmnu5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnu5.Click
        If Grid2.Rows.Count <= 0 Then Exit Sub
        If Grid2.ActiveRow Is Nothing Then Exit Sub

        Dim PresDet As Long = 0
        Dim Frm As New frmPPresupuestoPlanPeriodo
        

        PresDet = Grid2.ActiveRow.Cells("PresupuestoDet").Value
        Frm.FechaInicio = Grid2.ActiveRow.Cells("FechaInicio").Value
        Frm.FechaTermino = Grid2.ActiveRow.Cells("FechaTerminacion").Value
        Frm.PresupuestoDet = Grid2.ActiveRow.Cells("PresupuestoDet").Value
        If Val(Grid2.ActiveRow.Cells("Contar").Value) > 0 Then
            Frm.HabilitarDatos = False
        Else
            Frm.HabilitarDatos = True
        End If

        Frm.Partida = Grid2.ActiveRow.Cells("Descripcion").Value
        Call CargarFormularios(Frm)
        Call RemoverPartidaPlan(PresDet)
        Call Agregar_Listas_PartidaPlan(Frm.Ls_PresupuestoPlan, Frm.Ls_PresupuestoPlan_Del)

        Frm = Nothing

    End Sub
    Private Sub cmnu6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnu6.Click
        If Grid2.Rows.Count <= 0 Then Exit Sub
        If Grid2.ActiveRow Is Nothing Then Exit Sub

        Dim Frm As New frmPPrespPlanRecursos
        Dim PresDet As Long = 0
        PresDet = Grid2.ActiveRow.Cells("PresupuestoDet").Value
        Frm.PresupuestoDet = Grid2.ActiveRow.Cells("PresupuestoDet").Value
        Frm.Partida = Grid2.ActiveRow.Cells("Descripcion").Value
        Frm.Equipo = Me.Equipo
        If TipoG = State.eNew Then
            Frm.HabilitarDatos = True
        Else
            Frm.HabilitarDatos = Rbn6.Enabled
        End If
        Call CargarFormularios(Frm)
        Call RemoverPartidaPlanRecurso(PresDet)
        Call Agregar_Listas_PlanRecursos(Frm.Ls_PlanMaterial, _
             Frm.Ls_PlanEquipo, Frm.Ls_PlanManoObra, _
             Frm.Ls_PlanServicio, Frm.Ls_PlanEquipo_Asignacion, _
             Frm.Ls_PlanEquipo_Asignacion_Del, _
             Frm.Ls_PlanManoObra_Asignacion, _
             Frm.Ls_PlanManoObra_Asignacion_Del)
        Frm = Nothing

    End Sub
#End Region
#Region "Funciones privadas"
    Private Function ValidarDatos() As Boolean
        ValidarDatos = Boolean.TrueString

        If Chk1.Checked = True Then
            If TipoG = State.eNew Then
                If Not (String.IsNullOrEmpty(FechaInicioJA)) Then
                    If String.IsNullOrEmpty(FechaTerminoJA) Then
                        If CDate(FechaInicioJA) > CDate(Dtp1.Value) Then
                            MsgBox("El Cliente Interno ingreso el " & FechaInicioJA, MsgBoxStyle.Critical, Me.Text)
                            ValidarDatos = Boolean.FalseString
                            Exit Function
                        End If
                    Else
                        If CDate(FechaInicioJA) > CDate(Dtp1.Value) Then
                            MsgBox("El Cliente Interno ingreso el " & FechaInicioJA, MsgBoxStyle.Critical, Me.Text)
                            ValidarDatos = Boolean.FalseString
                            Exit Function
                        ElseIf CDate(FechaTerminoJA) < CDate(Dtp1.Value) Then
                            MsgBox("El Cliente Interno dejó la Jefatura el " & FechaTerminoJA, MsgBoxStyle.Critical, Me.Text)
                            ValidarDatos = Boolean.FalseString
                            Exit Function
                        End If
                    End If
                End If
            End If
        End If

        If Rbn6.Checked = True Then
            Entidad.Presupuesto = New ETPresupuesto
            Entidad.Presupuesto.Presupuesto = Me.Presupuesto
            Negocio.Presupuesto = New NGPresupuesto
            If Not (Negocio.Presupuesto.IsPresupuestoPendienteAprobacion(Entidad.Presupuesto)) Then
                ValidarDatos = Boolean.FalseString
                Exit Function
            End If
        End If
    End Function

#End Region

#Region "Procedimientos Privados"
    Private Sub ObtenerJefeArea()

        If Not (TipoG = State.eNew) Then
            Return
        End If

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Return
        End If

        Dim Lista As New List(Of ETAreaJefatura)
        Entidad.AreaJefatura = New ETAreaJefatura
        With Entidad.AreaJefatura
            .Cod_Area = Cbo1.Value
            .FechaInicio = Dtp1.Value
            .Tipo = 5
        End With
        Negocio.AreaJefatura = New NGAreaJefatura
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.AreaJefatura.Consultar_AreaJefetura_Activa(Entidad.AreaJefatura)
        If Entidad.MyLista.Validacion Then
            Lista = Entidad.MyLista.Ls_AreaJefatura
        End If

        Txt20.Clear()
        _JefeArea = String.Empty
        _FechaInicioEA = String.Empty
        _FechaTerminoEA = String.Empty
        If Lista IsNot Nothing Then
            For Each Row As ETAreaJefatura In Lista
                Txt20.Text = Row.Cod_JefeArea & "  " & Row.JefeArea
                _JefeArea = Row.Cod_JefeArea
                _FechaInicioEA = Row.FechaInicioTxt
                _FechaTerminoEA = Row.FechaTerminoTxt
            Next
        End If
    End Sub

    Sub CargarFormularios(ByVal frmChild As Form)
        frmChild.WindowState = FormWindowState.Normal
        frmChild.MaximizeBox = False
        frmChild.ShowDialog()
    End Sub

    Private Sub RemoverRecursosPartida(ByVal PresDet As Double)
        Dim i As Integer = 0
        If Ls_Material.Count > 0 Then
            While i < Ls_Material.Count
                If Ls_Material(i).Presupuesto = PresDet Then
                    Ls_Material.Remove(Ls_Material(i))
                Else
                    i = i + 1
                End If
            End While

        End If
        i = 0
        If Ls_Equipo.Count > 0 Then
            While i < Ls_Equipo.Count
                If Ls_Equipo(i).Presupuesto = PresDet Then
                    Ls_Equipo.Remove(Ls_Equipo(i))
                Else
                    i = i + 1
                End If
            End While
        End If
        i = 0
        If Ls_ManoObra.Count > 0 Then
            While i < Ls_ManoObra.Count
                If Ls_ManoObra(i).Presupuesto = PresDet Then
                    Ls_ManoObra.Remove(Ls_ManoObra(i))
                Else
                    i = i + 1
                End If
            End While
        End If
        i = 0
        If Ls_Servicio.Count > 0 Then
            While i < Ls_Servicio.Count
                If Ls_Servicio(i).Presupuesto = PresDet Then
                    Ls_Servicio.Remove(Ls_Servicio(i))
                Else
                    i = i + 1
                End If
            End While
        End If
        i = 0
        If Ls_Material_Del.Count > 0 Then
            While i < Ls_Material_Del.Count
                If Ls_Material_Del(i).Presupuesto = PresDet Then
                    Ls_Material_Del.Remove(Ls_Material_Del(i))
                Else
                    i = i + 1
                End If
            End While
        End If
        i = 0
        If Ls_Equipo_Del.Count > 0 Then
            While i < Ls_Equipo_Del.Count
                If Ls_Equipo_Del(i).Presupuesto = PresDet Then
                    Ls_Equipo_Del.Remove(Ls_Equipo_Del(i))
                Else
                    i = i + 1
                End If
            End While

        End If
        i = 0
        If Ls_ManoObra_Del.Count > 0 Then
            While i < Ls_ManoObra_Del.Count
                If Ls_ManoObra_Del(i).Presupuesto = PresDet Then
                    Ls_ManoObra_Del.Remove(Ls_ManoObra_Del(i))
                Else
                    i = i + 1
                End If
            End While
        End If
        i = 0
        If Ls_Servicio_Del.Count > 0 Then
            While i < Ls_Servicio_Del.Count
                If Ls_Servicio_Del(i).Presupuesto = PresDet Then
                    Ls_Servicio_Del.Remove(Ls_Servicio_Del(i))
                Else
                    i = i + 1
                End If
            End While
        End If

    End Sub

    Private Sub RemoverPartidaPlan(ByVal PresDet As Double)
        Dim i As Integer = 0
        If Ls_PresupuestoPlan.Count > 0 Then
            While i < Ls_PresupuestoPlan.Count
                If Ls_PresupuestoPlan(i).PresupuestoDet = PresDet Then
                    Ls_PresupuestoPlan.Remove(Ls_PresupuestoPlan(i))
                Else
                    i = i + 1
                End If
            End While

        End If

    End Sub

    Private Sub Agregar_Listas_PartidaPlan(ByVal Presp_Plan As List(Of ETPresupuestoPlan), _
    ByVal Presp_Plan_Del As List(Of ETPresupuestoPlan))

        If Presp_Plan IsNot Nothing Then
            For Each Row As ETPresupuestoPlan In Presp_Plan
                Row.Usuario = User_Sistema
                Ls_PresupuestoPlan.Add(Row)
            Next
        End If

        If Presp_Plan_Del IsNot Nothing Then
            For Each Row As ETPresupuestoPlan In Presp_Plan_Del
                Row.Usuario = User_Sistema
                Ls_PresupuestoPlan_Del.Add(Row)
            Next
        End If


    End Sub

    Private Sub RemoverPartidaPlanRecurso(ByVal PresDet As Double)
        Dim i As Integer = 0
        If Ls_PrespPlanMaterial.Count > 0 Then
            While i < Ls_PrespPlanMaterial.Count
                If Ls_PrespPlanMaterial(i).PresupuestoDet = PresDet Then
                    Ls_PrespPlanMaterial.Remove(Ls_PrespPlanMaterial(i))
                Else
                    i = i + 1
                End If
            End While
        End If
        i = 0
        If Ls_PrespPlanEquipo.Count > 0 Then
            While i < Ls_PrespPlanEquipo.Count
                If Ls_PrespPlanEquipo(i).PresupuestoDet = PresDet Then
                    Ls_PrespPlanEquipo.Remove(Ls_PrespPlanEquipo(i))
                Else
                    i = i + 1
                End If
            End While
        End If
        i = 0
        If Ls_PrespPlanManoObra.Count > 0 Then
            While i < Ls_PrespPlanManoObra.Count
                If Ls_PrespPlanManoObra(i).PresupuestoDet = PresDet Then
                    Ls_PrespPlanManoObra.Remove(Ls_PrespPlanManoObra(i))
                Else
                    i = i + 1
                End If
            End While
        End If
        i = 0
        If Ls_PrespPlanServicio.Count > 0 Then
            While i < Ls_PrespPlanServicio.Count
                If Ls_PrespPlanServicio(i).PresupuestoDet = PresDet Then
                    Ls_PrespPlanServicio.Remove(Ls_PrespPlanServicio(i))
                Else
                    i = i + 1
                End If
            End While
        End If

        i = 0
        If Ls_Plan_Equipo_Asignacion.Count > 0 Then
            While i < Ls_Plan_Equipo_Asignacion.Count
                If Ls_Plan_Equipo_Asignacion(i).PresupuestoDet = PresDet Then
                    Ls_Plan_Equipo_Asignacion.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While
        End If

        i = 0
        If Ls_Plan_Equipo_Asignacion_Del.Count > 0 Then
            While i < Ls_Plan_Equipo_Asignacion_Del.Count
                If Ls_Plan_Equipo_Asignacion_Del(i).PresupuestoDet = PresDet Then
                    Ls_Plan_Equipo_Asignacion_Del.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While
        End If

        i = 0
        If Ls_Plan_ManoObra_Asignacion.Count > 0 Then
            While i < Ls_Plan_ManoObra_Asignacion.Count
                If Ls_Plan_ManoObra_Asignacion(i).PresupuestoDet = PresDet Then
                    Ls_Plan_ManoObra_Asignacion.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While
        End If

        i = 0
        If Ls_Plan_ManoObra_Asignacion_Del.Count > 0 Then
            While i < Ls_Plan_ManoObra_Asignacion_Del.Count
                If Ls_Plan_ManoObra_Asignacion_Del(i).PresupuestoDet = PresDet Then
                    Ls_Plan_ManoObra_Asignacion_Del.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While
        End If

    End Sub

    Private Sub Agregar_Listas_PlanRecursos(ByVal PrespPlan_Material As List(Of ETPresupuestoPlanRecursos), _
                                            ByVal PrespPlan_Equipo As List(Of ETPresupuestoPlanRecursos), _
                                            ByVal PrespPlan_ManoObra As List(Of ETPresupuestoPlanRecursos), _
                                            ByVal PrespPlan_Servicio As List(Of ETPresupuestoPlanRecursos), _
                                            ByVal PrespPlan_Equipo_Asig As List(Of ETPresupuestoPlanRecursosAsignacion), _
                                            ByVal PrespPlan_Equipo_Asig_Del As List(Of ETPresupuestoPlanRecursosAsignacion), _
                                            ByVal PrespPlan_ManoObra_Asig As List(Of ETPresupuestoPlanRecursosAsignacion), _
                                            ByVal PrespPlan_ManoObra_Asig_Del As List(Of ETPresupuestoPlanRecursosAsignacion))

        If PrespPlan_Material IsNot Nothing Then
            If PrespPlan_Material.Count > 0 Then
                For Each Row As ETPresupuestoPlanRecursos In PrespPlan_Material
                    Row.Usuario = User_Sistema
                    Ls_PrespPlanMaterial.Add(Row)
                Next
            End If

        End If

        If PrespPlan_Equipo IsNot Nothing Then
            If PrespPlan_Equipo.Count > 0 Then
                For Each Row As ETPresupuestoPlanRecursos In PrespPlan_Equipo
                    Row.Usuario = User_Sistema
                    Ls_PrespPlanEquipo.Add(Row)
                Next
            End If
        End If

        If PrespPlan_ManoObra IsNot Nothing Then
            If PrespPlan_ManoObra.Count > 0 Then
                For Each Row As ETPresupuestoPlanRecursos In PrespPlan_ManoObra
                    Row.Usuario = User_Sistema
                    Ls_PrespPlanManoObra.Add(Row)
                Next
            End If
        End If

        If PrespPlan_Servicio IsNot Nothing Then
            If PrespPlan_Servicio.Count > 0 Then
                For Each Row As ETPresupuestoPlanRecursos In PrespPlan_Servicio
                    Row.Usuario = User_Sistema
                    Ls_PrespPlanServicio.Add(Row)
                Next
            End If
        End If

        If PrespPlan_Equipo_Asig IsNot Nothing Then
            If PrespPlan_Equipo_Asig.Count > 0 Then
                For Each Row As ETPresupuestoPlanRecursosAsignacion In PrespPlan_Equipo_Asig
                    Row.Usuario = User_Sistema
                    Ls_Plan_Equipo_Asignacion.Add(Row)
                Next
            End If
        End If

        If PrespPlan_Equipo_Asig_Del IsNot Nothing Then
            If PrespPlan_Equipo_Asig_Del.Count > 0 Then
                For Each Row As ETPresupuestoPlanRecursosAsignacion In PrespPlan_Equipo_Asig_Del
                    Row.Usuario = User_Sistema
                    Ls_Plan_Equipo_Asignacion_Del.Add(Row)
                Next
            End If
        End If

        If PrespPlan_ManoObra_Asig IsNot Nothing Then
            If PrespPlan_ManoObra_Asig.Count > 0 Then
                For Each Row As ETPresupuestoPlanRecursosAsignacion In PrespPlan_ManoObra_Asig
                    Row.Usuario = User_Sistema
                    Ls_Plan_ManoObra_Asignacion.Add(Row)
                Next
            End If
        End If

        If PrespPlan_ManoObra_Asig_Del IsNot Nothing Then
            If PrespPlan_ManoObra_Asig_Del.Count > 0 Then
                For Each Row As ETPresupuestoPlanRecursosAsignacion In PrespPlan_ManoObra_Asig_Del
                    Row.Usuario = User_Sistema
                    Ls_Plan_ManoObra_Asignacion.Add(Row)
                Next
            End If
        End If
    End Sub

    Private Sub Agregar_Listas_Recursos(ByVal Presp_Material As List(Of ETPresupuestoMaterial), _
    ByVal Presp_Material_Del As List(Of ETPresupuestoMaterial), ByVal Presp_Equipo As List(Of ETPresupuestoEquipo), _
    ByVal Presp_Equipo_Del As List(Of ETPresupuestoEquipo), ByVal Presp_ManoObra As List(Of ETPresupuestoManoObra), _
    ByVal Presp_ManoObra_Del As List(Of ETPresupuestoManoObra), ByVal Presp_Servicio As List(Of ETPresupuestoServicio), _
    ByVal Presp_Servicio_Del As List(Of ETPresupuestoServicio))

        If Presp_Material IsNot Nothing Then
            For Each Row As ETPresupuestoMaterial In Presp_Material
                Row.Usuario = User_Sistema
                Ls_Material.Add(Row)
            Next
        End If

        If Presp_Equipo IsNot Nothing Then
            For Each Row As ETPresupuestoEquipo In Presp_Equipo
                Row.Usuario = User_Sistema
                Ls_Equipo.Add(Row)
            Next
        End If

        If Presp_ManoObra IsNot Nothing Then
            For Each Row As ETPresupuestoManoObra In Presp_ManoObra
                Row.Usuario = User_Sistema
                Ls_ManoObra.Add(Row)
            Next
        End If

        If Presp_Servicio IsNot Nothing Then
            For Each Row As ETPresupuestoServicio In Presp_Servicio
                Row.Usuario = User_Sistema
                Ls_Servicio.Add(Row)
            Next
        End If

        If Presp_Material_Del IsNot Nothing Then
            For Each Row As ETPresupuestoMaterial In Presp_Material_Del
                Row.Usuario = User_Sistema
                Ls_Material_Del.Add(Row)
            Next
        End If

        If Presp_Equipo_Del IsNot Nothing Then
            For Each Row As ETPresupuestoEquipo In Presp_Equipo_Del
                Row.Usuario = User_Sistema
                Ls_Equipo_Del.Add(Row)
            Next
        End If

        If Presp_ManoObra_Del IsNot Nothing Then
            For Each Row As ETPresupuestoManoObra In Presp_ManoObra_Del
                Row.Usuario = User_Sistema
                Ls_ManoObra_Del.Add(Row)
            Next
        End If

        If Presp_Servicio_Del IsNot Nothing Then
            For Each Row As ETPresupuestoServicio In Presp_Servicio_Del
                Row.Usuario = User_Sistema
                Ls_Servicio_Del.Add(Row)
            Next
        End If

    End Sub

    Private Sub InicializarValores()
        _Decimal = 0
        _Longitud = 0
        _Presupuesto = 0
        _JefeArea = String.Empty
        _Cliente = String.Empty
        _Equipo = 0
        TipoDato = ValorTipoDato.vVacio
        _AreaInt = String.Empty
        _Atributo = 0
        _FechaInicioJA = String.Empty
        _FechaTerminoJA = String.Empty
        _FechaInicioEA = String.Empty
        _FechaTerminoEA = String.Empty

    End Sub

    Private Sub Cargar_Area()
        Dim Ls_Area As New List(Of ETArea)

        Dim objArea As New ETArea
        Dim ObjNeg As New NGArea
        If TipoG = State.eNew Then
            objArea.Tipo = TipoG
        Else
            objArea.Tipo = TipoG
        End If

        objArea.Usuario = User_Sistema
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = ObjNeg.Consultar_Area(objArea)
        If Entidad.MyLista.Validacion Then
            Ls_Area = Entidad.MyLista.Ls_Area
        End If

        Call CargarUltraCombo(Me.Cbo1, Ls_Area, "Codigo", "Area")
    End Sub

    Private Sub HabilitarControles(ByVal b As Boolean)
        Cbo1.ReadOnly = Not b
        Txt1.ReadOnly = True
        Dtp1.Enabled = b
        Chk1.Enabled = b
        Txt2.ReadOnly = True
        Txt3.ReadOnly = True
        Btn1.Enabled = b
        Txt4.ReadOnly = True
        Btn2.Enabled = b
        Cbo2.ReadOnly = Not b
        Txt5.ReadOnly = Not b
        Cbo3.ReadOnly = True
        Cbo4.ReadOnly = Not b
        Cbo5.ReadOnly = True
        Txt7.ReadOnly = True
        Txt8.ReadOnly = True
        Dtp2.ReadOnly = True
        Dtp3.ReadOnly = True
        Rbn1.Enabled = False
        Rbn2.Enabled = False
        Rbn3.Enabled = False
        Rbn4.Enabled = False
        Rbn5.Enabled = False
        Rbn6.Enabled = False

    End Sub

    Private Sub Limpiar()
        Call InicializarValores()
        If Cbo1.Rows.Count > 0 Then Cbo1.Value = ""
        Cbo2.Value = "1"
        If Cbo3.Rows.Count > 0 Then Cbo3.Value = ""
        Cbo4.Value = "1"
        Cbo5.Value = "S/."
        Txt20.Clear()
        Dtp1.Value = Date.Today
        Dtp2.Value = Date.Today
        Dtp3.Value = Date.Today

        Me.Grid2.ContextMenuStrip = Nothing

        Txt1.Clear()
        Txt2.Clear()
        Txt3.Clear()
        Txt4.Clear()
        Txt5.Clear()
        Txt6.Text = ""
        Txt7.Text = "1.00"
        Txt8.Text = "0.00"
        Rbn1.Checked = True

        Ls_Pres_Det = Nothing
        Ls_Pres_Det = New List(Of ETPresupuestoDetalle)
        Ls_Pres_Det_Del = Nothing
        Ls_Pres_Det_Del = New List(Of ETPresupuestoDetalle)
        Call CargarUltraGrid(Grid2, Ls_Pres_Det)

        Ls_Material = Nothing
        Ls_Equipo = Nothing
        Ls_ManoObra = Nothing
        Ls_Servicio = Nothing

        Ls_Material_Del = Nothing
        Ls_Equipo_Del = Nothing
        Ls_ManoObra_Del = Nothing
        Ls_Servicio_Del = Nothing

        Ls_PresupuestoPlan = Nothing
        Ls_PresupuestoPlan_Del = Nothing

        Ls_PrespPlanMaterial = Nothing
        Ls_PrespPlanEquipo = Nothing
        Ls_PrespPlanManoObra = Nothing
        Ls_PrespPlanServicio = Nothing

        Ls_Plan_Equipo_Asignacion = Nothing
        Ls_Plan_Equipo_Asignacion_Del = Nothing
        Ls_Plan_ManoObra_Asignacion = Nothing
        Ls_Plan_ManoObra_Asignacion_Del = Nothing


        Ls_Material = New List(Of ETPresupuestoMaterial)
        Ls_Equipo = New List(Of ETPresupuestoEquipo)
        Ls_ManoObra = New List(Of ETPresupuestoManoObra)
        Ls_Servicio = New List(Of ETPresupuestoServicio)

        Ls_Material_Del = New List(Of ETPresupuestoMaterial)
        Ls_Equipo_Del = New List(Of ETPresupuestoEquipo)
        Ls_ManoObra_Del = New List(Of ETPresupuestoManoObra)
        Ls_Servicio_Del = New List(Of ETPresupuestoServicio)

        Ls_PresupuestoPlan = New List(Of ETPresupuestoPlan)
        Ls_PresupuestoPlan_Del = New List(Of ETPresupuestoPlan)

        Ls_PrespPlanMaterial = New List(Of ETPresupuestoPlanRecursos)
        Ls_PrespPlanEquipo = New List(Of ETPresupuestoPlanRecursos)
        Ls_PrespPlanManoObra = New List(Of ETPresupuestoPlanRecursos)
        Ls_PrespPlanServicio = New List(Of ETPresupuestoPlanRecursos)

        Ls_Plan_Equipo_Asignacion = New List(Of ETPresupuestoPlanRecursosAsignacion)
        Ls_Plan_Equipo_Asignacion_Del = New List(Of ETPresupuestoPlanRecursosAsignacion)
        Ls_Plan_ManoObra_Asignacion = New List(Of ETPresupuestoPlanRecursosAsignacion)
        Ls_Plan_ManoObra_Asignacion_Del = New List(Of ETPresupuestoPlanRecursosAsignacion)

    End Sub

    Private Sub Inicio()
        TipoG = State.eView
        Tab1.Tabs("T01").Selected = True
        Call HabilitarControles(False)
        Call CargarUnidadMedida()
        Call Limpiar()
        Call CargarGrilla()
    End Sub

    Private Sub CargarGrilla()
        Dim Ls_Presupuesto As New List(Of ETPresupuesto)

        Negocio.Presupuesto = New NGPresupuesto

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Presupuesto.Consultar_Presupuesto
        If Entidad.MyLista.Validacion Then
            Ls_Presupuesto = Entidad.MyLista.Ls_Presupuesto
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Presupuesto)

    End Sub

    Private Sub CargarPrespDetalle()
        Entidad.Presupuesto = New ETPresupuesto
        With Entidad.Presupuesto
            .Presupuesto = Me.Presupuesto
            .TipoCambio = Val(Me.Txt7.Value)
            .Tipo = 4
        End With
        Negocio.Presupuesto = New NGPresupuesto

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Presupuesto.Consultar_PresupDetalle(Entidad.Presupuesto)
        If Entidad.MyLista.Validacion Then
            Ls_Pres_Det = Entidad.MyLista.Ls_Presupuesto_Detalle
        End If

        Call CargarUltraGrid(Grid2, Ls_Pres_Det)

    End Sub

    Private Sub CargarUnidadMedida()
        Dim Ls_Combo As List(Of ETUnidadMedida)
        Negocio.UnidadMedida = New NGUnidadMedida
        Entidad.MyLista = New ETMyLista

        Ls_Combo = New List(Of ETUnidadMedida)

        Entidad.MyLista = Negocio.UnidadMedida.ConsultarUnidadMedida

        If Entidad.MyLista.Validacion Then
            Ls_Combo = Entidad.MyLista.Ls_UnidadMedida
        End If

        Call CargarUltraCombo(Me.Cbo3, Ls_Combo, "Codigo", "Descripcion", String.Empty)

    End Sub

    Private Sub ReCalcularItemPresp()
        Dim i As Integer = 0
        For Each Row As ETPresupuestoDetalle In Ls_Pres_Det
            Row.Item = String.Format("000", i)
        Next

        Call CargarUltraGrid(Grid2, Ls_Pres_Det)
    End Sub

    Private Sub Calcular_Total_Fechas()
        Dim i As Integer = 0
        Dim FechaInicio As Date = Date.MaxValue
        Dim FechaTermino As Date = Date.MinValue
        Dim Total As Double = 0

        For Each Row As ETPresupuestoDetalle In Ls_Pres_Det
            Total = Total + Row.Parcial
            If FechaInicio > Row.FechaInicio Then
                FechaInicio = Row.FechaInicio
            End If
            If FechaTermino < Row.FechaTerminacion Then
                FechaTermino = Row.FechaTerminacion
            End If
        Next

        Txt8.Value = Total
        Dtp2.Value = FechaInicio
        Dtp3.Value = FechaTermino

    End Sub

    Private Function CargarTipoCambio() As Double
        Dim lResult As Double = 0
        Entidad.Presupuesto = New ETPresupuesto
        With Entidad.Presupuesto
            .Moneda = Cbo5.Value
            .Fecha = Dtp1.Value
            .Tipo = 5
        End With
        Negocio.Presupuesto = New NGPresupuesto
        lResult = Negocio.Presupuesto.Consultar_TipoCambio(Entidad.Presupuesto)
        Return lResult
    End Function
#End Region
#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        TipoG = State.eView
        Call Limpiar()
        TipoG = State.eNew
        Tab1.Tabs("T03").Enabled = Boolean.FalseString
        Call HabilitarControles(True)
        Call Cargar_Area()
        Cbo1.Focus()
        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub
    
    Public Sub Grabar()
        Dim lResult As ETPresupuesto = Nothing
        Entidad.Presupuesto = New ETPresupuesto

        If TipoG = State.eEdit Then
            If Rbn6.Enabled = False Then
                Call Inicio()
                Return
            End If
        End If
        If Grid2.Rows.Count > 0 Then
            Grid2.UpdateData()
            Grid2.PerformAction(ExitEditMode, False, False)
            Call Calcular_Total_Fechas()
        End If

        If ValidarDatos() = False Then
            Exit Sub
        End If

        With Entidad.Presupuesto
            If Not (Cbo1.ActiveRow Is Nothing) Then
                .Presupuesto = Me.Presupuesto
                .Cod_Area = Cbo1.Value
                .Area = Cbo1.Text
                If String.IsNullOrEmpty(Cbo1.ActiveRow.Cells("Abrev").Value.ToString.Trim) Then
                    .Area_Abrev = Cbo1.Text
                Else
                    .Area_Abrev = Cbo1.ActiveRow.Cells("Abrev").Value
                End If
                .Cod_Presup = Txt1.Text
                .Cod_EncargadoArea = EncargadoArea
                .TipoCliente = Chk1.Checked
                .Cliente = Txt2.Text
                If Chk1.Checked = False Then
                    .Cod_Cli = Cliente
                Else
                    .Cod_ClienteInt = Cliente
                    .Cod_AreaInt = Me.AreaInt
                End If

                .EquipoID = Equipo
                .TipoProceso = Cbo2.Value
                If Cbo2.Value = "1" Then
                    Select Case TipoDato
                        Case ValorTipoDato.vDate, ValorTipoDato.vTime
                            .ValorControl = Txt6.Text
                        Case Else
                            .ValorControl = Txt5.Text
                    End Select
                    .AtributoControl = Atributo
                End If
                .Cod_Prioridad = Cbo4.Value
                .Moneda = Cbo5.Value
                .TipoCambio = Txt7.Value
                .Total = Txt8.Value
                .FechaInicio = Dtp2.Value
                .FechaTerminacion = Dtp3.Value
                If Rbn1.Checked = True Then
                    .Status = "D"
                ElseIf Rbn2.Checked = True Then
                    .Status = "A"
                ElseIf Rbn3.Checked = True Then
                    .Status = "P"
                ElseIf Rbn4.Checked = True Then
                    .Status = ""
                ElseIf Rbn6.Checked = True Then
                    .Status = "C"
                Else
                    .Status = "*"
                End If
                .Tipo = TipoG
                .Usuario = User_Sistema
            End If
        End With

        lResult = New ETPresupuesto
        lResult = Negocio.Presupuesto.Mantenedor_Presupuesto(Entidad.Presupuesto, _
                  Ls_Pres_Det_Del, Ls_Pres_Det, Ls_Material, Ls_Material_Del, _
                  Ls_Equipo, Ls_Equipo_Del, Ls_ManoObra, Ls_ManoObra_Del, _
                  Ls_Servicio, Ls_Servicio_Del, Ls_PresupuestoPlan, Ls_PresupuestoPlan_Del, _
                  Ls_PrespPlanMaterial, Ls_PrespPlanEquipo, Ls_PrespPlanManoObra, _
                  Ls_PrespPlanServicio, Ls_Plan_Equipo_Asignacion, Ls_Plan_Equipo_Asignacion_Del, _
                  Ls_Plan_ManoObra_Asignacion, Ls_Plan_ManoObra_Asignacion_Del)
        If Not (lResult Is Nothing) Then
            If TipoG = State.eNew Then
                If MsgBox("Desea Agregar las Partidas", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Call Inicio()
                Else
                    TipoG = State.eEdit
                    Tab1.Tabs("T03").Enabled = True
                    Tab1.Tabs("T03").Selected = True
                    Grid2.ContextMenuStrip = Nothing
                    Presupuesto = lResult.Presupuesto
                    Txt1.Text = lResult.Cod_Presup
                    Cbo1.ReadOnly = True
                End If
            Else
                Call Inicio()
            End If
        End If
    End Sub

    Public Sub Modificar()
        If Grid1.Rows.Count <= 0 Then Exit Sub
        If Grid1.ActiveRow Is Nothing Then Exit Sub

        TipoG = State.eView
        Call Limpiar()
        TipoG = State.eEdit
        Tab1.Tabs("T03").Enabled = Boolean.TrueString
        Call HabilitarControles(False)
        Call Cargar_Area()

        Cbo1.Value = Grid1.ActiveRow.Cells("Cod_Area").Value
        Txt1.Text = Grid1.ActiveRow.Cells("Cod_Presup").Value
        Dtp1.Value = Grid1.ActiveRow.Cells("Fecha").Value
        EncargadoArea = Grid1.ActiveRow.Cells("Cod_EncargadoArea").Value
        Txt20.Text = EncargadoArea & "  " & Grid1.ActiveRow.Cells("EncargadoArea").Value
        Chk1.Checked = Grid1.ActiveRow.Cells("TipoCliente").Value
        If Chk1.Checked = False Then
            Cliente = Grid1.ActiveRow.Cells("Cod_Cli").Value
            Txt3.Text = Grid1.ActiveRow.Cells("RUC").Value
        Else
            Cliente = Grid1.ActiveRow.Cells("Cod_ClienteInt").Value
            Txt3.Text = Grid1.ActiveRow.Cells("AreaInterna").Value
            AreaInt = Grid1.ActiveRow.Cells("Cod_AreaInt").Value
        End If
        Txt2.Text = Grid1.ActiveRow.Cells("Cliente").Value

        Txt4.Text = Grid1.ActiveRow.Cells("Equipo").Value
        Equipo = Grid1.ActiveRow.Cells("EquipoID").Value
        Atributo = Grid1.ActiveRow.Cells("AtributoControl").Value
        TipoDato = Grid1.ActiveRow.Cells("TipoDato").Value
        Longitud = Grid1.ActiveRow.Cells("Longitud").Value
        Decimales = Grid1.ActiveRow.Cells("Decimales").Value
        Label6.Text = Grid1.ActiveRow.Cells("Atributo").Value
        Select Case TipoDato
            Case ValorTipoDato.vTime, ValorTipoDato.vDate
                Txt6.Text = Grid1.ActiveRow.Cells("ValorControl").Value
            Case Else
                Txt5.Text = Grid1.ActiveRow.Cells("ValorControl").Value
        End Select
        Cbo3.Value = Grid1.ActiveRow.Cells("Cod_UniMed").Value
        Cbo2.Value = Grid1.ActiveRow.Cells("TipoProceso").Value
        Cbo4.Value = Grid1.ActiveRow.Cells("Cod_Prioridad").Value
        Cbo5.Value = Grid1.ActiveRow.Cells("Moneda").Value
        Txt7.Text = Grid1.ActiveRow.Cells("TipoCambio").Value
        Txt8.Text = Grid1.ActiveRow.Cells("Total").Value
        Dtp2.Value = Grid1.ActiveRow.Cells("FechaInicio").Value
        Dtp3.Value = Grid1.ActiveRow.Cells("FechaTerminacion").Value
        Grb2.Enabled = False
        Select Case Grid1.ActiveRow.Cells("Status").Value
            Case "C"
                Rbn6.Checked = True
            Case "*"
                Rbn5.Checked = True
            Case "D"
                Rbn1.Checked = True
                Grb2.Enabled = True
                Rbn6.Enabled = True
            Case "A"
                Rbn2.Checked = True
            Case "P"
                Rbn3.Checked = True
            Case Else
                Rbn4.Checked = True
        End Select
        Presupuesto = Grid1.ActiveRow.Cells("Presupuesto").Value
        Call CargarPrespDetalle()
        Tab1.Tabs("T03").Selected = Boolean.TrueString
    End Sub

    Public Sub Eliminar()
        Dim mensaje As String = String.Empty
        Dim Status As String = String.Empty
        If Tab1.Tabs("T01").Selected = False Then
            Return
        End If
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No existen Presupuestos", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If
        If Grid1.ActiveRow Is Nothing Then
            Return
        End If
        mensaje = "Esta seguro de Anular el Presupuesto: "
        mensaje = mensaje & Grid1.ActiveRow.Cells("Area_Abrev").Value
        mensaje = mensaje & " - " & Grid1.ActiveRow.Cells("Cod_Presup").Value

        If MsgBox(mensaje, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Ok Then
            Return
        End If
        Status = Grid1.ActiveRow.Cells("Status").Value
        If Not (Status = "D" OrElse Status = "C") Then
            MsgBox("El Presupuesto ya fue abrobado", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If
        Entidad.Presupuesto = New ETPresupuesto
        Entidad.Presupuesto.Presupuesto = Grid1.ActiveRow.Cells("Presupuesto").Value
        Entidad.Presupuesto.Usuario = User_Sistema
        Entidad.Presupuesto.Tipo = 3

        Negocio.Presupuesto.Anular_Presupuesto(Entidad.Presupuesto)

        Call Inicio()
    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Public Sub Cancelar()
        Call Inicio()
    End Sub

    Public Sub Excel()
        If Not (TipoG = State.eEdit) Then
            Exit Sub
        End If

        If Rbn1.Checked = True Or Rbn5.Checked = True Then
            MsgBox("El Presupuesto esta en Desarrollo o Anulado", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        Else
            If Grb2.Enabled = True Then
                MsgBox("El Presupuesto esta en Desarrollo", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If
        End If

        Obj_Excel = CreateObject("Excel.Application")
        Obj_Libro = Obj_Excel.Workbooks.Add()
        'Obj_Hoja = Obj_Libro.Sheets.Add

        With Obj_Libro
            .Sheets(1).Name = "Presupuesto"
            .Sheets(2).Name = "APU"
            '.Sheets(3).Name = "Planificar Recursos"
            '.Sheets(4).Name = "Asignar Recursos"
        End With

        Call ExportarPresupuesto()
        Call ExportarAPU()
        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()

        Obj_Excel.visible = True

        Obj_Hoja = Nothing
        Obj_Libro = Nothing
        Obj_Excel = Nothing

    End Sub

    Private Sub ExportarAPU()
        Dim Fila As Integer
        Dim Item As Integer
        Dim TipoRec As Integer
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim Registro As Integer
        Dim FilaInicio As Integer
        Dim SubTotalRecurso As Double
        Dim Item_Texto As String = String.Empty
        Dim RecursoMat As List(Of ETPresupuestoMaterial)
        Dim RecursoEq As List(Of ETPresupuestoEquipo)
        Dim RecursoMO As List(Of ETPresupuestoManoObra)
        Dim RecursoSer As List(Of ETPresupuestoServicio)

        Obj_Hoja = Obj_Libro.Sheets(2)
        Obj_Hoja.Activate()
        Obj_Hoja.Columns(1).ColumnWidth = 2.14
        Obj_Hoja.Columns(2).ColumnWidth = 10.71
        Obj_Hoja.Columns(3).ColumnWidth = 17.29
        Obj_Hoja.Columns(4).ColumnWidth = 15.57
        Obj_Hoja.Columns(5).ColumnWidth = 8.57
        Obj_Hoja.Columns(6).ColumnWidth = 6.14
        Obj_Hoja.Columns(7).ColumnWidth = 6.71
        Obj_Hoja.Columns(8).ColumnWidth = 10.43
        Obj_Hoja.Columns(9).ColumnWidth = 13.71
        Obj_Hoja.Columns(10).ColumnWidth = 2.14

        Fila = 2



        Obj_Hoja.Cells(Fila, 2) = "ANÁLISIS DE COSTOS UNITARIOS"
        Call CombinarCeldas("B" & CStr(Fila) & ":I" & CStr(Fila), 0)
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 14, , )
        Fila = Fila + 1
        Item = 0
        TipoRec = 0
        Registro = 0
        SubTotalRecurso = 0
        FilaInicio = 0
        For Each xRow As UltraGridRow In Grid2.Rows
            Item = Item + 1
            Fila = Fila + 1
            FilaInicio = Fila
            Obj_Hoja.Cells(Fila, 1) = CStr(Item)
            Obj_Hoja.Cells(Fila, 2) = "Partida"
            Call CombinarCeldas("B" & CStr(Fila) & ":B" & CStr(Fila + 2), AliniacionHorizontal_Excel.xlHAlignGeneral)
            Call FormatoCelda("B" & CStr(Fila) & ":B" & CStr(Fila + 2), "Arial Narrow", False, 8, , EstiloLineaExcel.xlContinuous, 15, , AliniacionVertical_Excel.xlVAlignTop)
            Obj_Hoja.Cells(Fila, 3) = xRow.Cells("Descripcion").Value
            Call CombinarCeldas("C" & CStr(Fila) & ":I" & CStr(Fila + 2), AliniacionHorizontal_Excel.xlHAlignGeneral)
            Call FormatoCelda("C" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 11, , EstiloLineaExcel.xlContinuous, 15)

            Fila = Fila + 3
            Call FormatoCelda("B" & CStr(Fila) & ":B" & CStr(Fila), "Arial Narrow", False, 8, , EstiloLineaExcel.xlContinuous, 15, AliniacionHorizontal_Excel.xlHAlignLeft)
            Obj_Hoja.Cells(Fila, 2) = "Rendimiento:"
            Call FormatoCelda("C" & CStr(Fila) & ":C" & CStr(Fila), "Arial Narrow", False, 8, , EstiloLineaExcel.xlContinuous, 15, AliniacionHorizontal_Excel.xlHAlignLeft)
            Obj_Hoja.Cells(Fila, 3) = xRow.Cells("Factor").Value
            Call FormatoCelda("D" & CStr(Fila) & ":D" & CStr(Fila), "Arial Narrow", False, 8, , EstiloLineaExcel.xlContinuous, 15, AliniacionHorizontal_Excel.xlHAlignRight)
            Obj_Hoja.Cells(Fila, 4) = "/Día"
            Obj_Hoja.Cells(Fila, 8) = "Costo Unitario Directo por : " & xRow.Cells("UniMed").Value
            Call CombinarCeldas("E" & CStr(Fila) & ":H" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignRight)
            Call FormatoCelda("E" & CStr(Fila) & ":H" & CStr(Fila), "Arial Narrow", True, 8, , EstiloLineaExcel.xlContinuous, 15, AliniacionHorizontal_Excel.xlHAlignRight)
            Obj_Hoja.Cells(Fila, 9) = xRow.Cells("Precio").Value
            Call FormatoCelda("I" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", True, 10, , EstiloLineaExcel.xlContinuous, 15, AliniacionHorizontal_Excel.xlHAlignRight)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "ITEM"
            Obj_Hoja.Cells(Fila, 3) = "DESCRIPCIÓN"
            Call CombinarCeldas("C" & CStr(Fila) & ":D" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
            Obj_Hoja.Cells(Fila, 5) = "Unidad"
            Obj_Hoja.Cells(Fila, 6) = "N° Und"
            Obj_Hoja.Cells(Fila, 7) = "Cantidad"
            Obj_Hoja.Cells(Fila, 8) = "Precio " & Cbo5.Value
            Obj_Hoja.Cells(Fila, 9) = "Parcial " & Cbo5.Value
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", True, 8, , EstiloLineaExcel.xlContinuous, 15, AliniacionHorizontal_Excel.xlHAlignGeneral)

            RecursoMat = New List(Of ETPresupuestoMaterial)
            RecursoEq = New List(Of ETPresupuestoEquipo)
            RecursoMO = New List(Of ETPresupuestoManoObra)
            RecursoSer = New List(Of ETPresupuestoServicio)

            With Entidad.PresupuestoDet
                .PresupuestoDet = xRow.Cells("PresupuestoDet").Value
                .Tipo = 4
            End With

            Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Material(Entidad.PresupuestoDet)
            If Entidad.MyLista.Validacion Then
                RecursoMat = Entidad.MyLista.Ls_Presupuesto_Material
            End If

            Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Equipo(Entidad.PresupuestoDet)
            If Entidad.MyLista.Validacion Then
                RecursoEq = Entidad.MyLista.Ls_Presupuesto_Equipo
            End If

            Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_ManoObra(Entidad.PresupuestoDet)
            If Entidad.MyLista.Validacion Then
                RecursoMO = Entidad.MyLista.Ls_Presupuesto_ManoObra
            End If

            Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Servicio(Entidad.PresupuestoDet)
            If Entidad.MyLista.Validacion Then
                RecursoSer = Entidad.MyLista.Ls_Presupuesto_Servicio
            End If


            Registro = 0
            SubTotalRecurso = 0
            If RecursoMat.Count > 0 Then
                TipoRec = TipoRec + 1
                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2).NumberFormat = CStr(TipoRec) & ".000"
                Obj_Hoja.Cells(Fila, 2) = 0
                Obj_Hoja.Cells(Fila, 3) = "MATERIALES"
                Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", True, 8, , , 15, AliniacionHorizontal_Excel.xlHAlignLeft)
                For Each xMat As ETPresupuestoMaterial In RecursoMat
                    Fila = Fila + 1
                    Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", False, 8, , , , AliniacionHorizontal_Excel.xlHAlignLeft)
                    Registro = Registro + 1

                    i = Len(CStr(Registro).ToString.Trim)
                    Item_Texto = CStr(Registro).ToString.Trim
                    For j = i To 2
                        Item_Texto = "0" & Item_Texto
                    Next
                    Item_Texto = CStr(TipoRec) & "." & Item_Texto

                    Obj_Hoja.Cells(Fila, 2) = Item_Texto
                    Obj_Hoja.Cells(Fila, 3) = xMat.Material
                    Call CombinarCeldas("C" & CStr(Fila) & ":D" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
                    Obj_Hoja.Cells(Fila, 5) = xMat.UniMed

                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = xMat.Cantidad
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = xMat.Precio
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = xMat.SubTotal
                    SubTotalRecurso = SubTotalRecurso + xMat.SubTotal
                Next
                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 9) = SubTotalRecurso
                Call FormatoCelda("I" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", True, 9, , , , AliniacionHorizontal_Excel.xlHAlignRight)
            End If

            Registro = 0
            SubTotalRecurso = 0
            If RecursoEq.Count > 0 Then
                TipoRec = TipoRec + 1
                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2).NumberFormat = CStr(TipoRec) & ".000"
                Obj_Hoja.Cells(Fila, 2) = 0
                Obj_Hoja.Cells(Fila, 3) = "EQUIPOS"
                Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", True, 8, , , 15, AliniacionHorizontal_Excel.xlHAlignLeft)
                For Each xEq As ETPresupuestoEquipo In RecursoEq
                    Fila = Fila + 1
                    Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", False, 8, , , , AliniacionHorizontal_Excel.xlHAlignLeft)
                    Registro = Registro + 1
                    i = Len(CStr(Registro).ToString.Trim)
                    Item_Texto = CStr(Registro).ToString.Trim
                    For j = i To 2
                        Item_Texto = "0" & Item_Texto
                    Next
                    Item_Texto = CStr(TipoRec) & "." & Item_Texto

                    Obj_Hoja.Cells(Fila, 2) = Item_Texto
                    Obj_Hoja.Cells(Fila, 3) = xEq.Equipo
                    Call CombinarCeldas("C" & CStr(Fila) & ":D" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
                    Obj_Hoja.Cells(Fila, 5) = xEq.UniMed
                    Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 6) = xEq.Cuadrilla
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = xEq.Cantidad
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = xEq.Precio
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = xEq.SubTotal
                    SubTotalRecurso = SubTotalRecurso + xEq.SubTotal
                Next
                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 9) = SubTotalRecurso
                Call FormatoCelda("I" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", True, 9, , , , AliniacionHorizontal_Excel.xlHAlignRight)
            End If
           
            Registro = 0
            SubTotalRecurso = 0
            If RecursoMO.Count > 0 Then
                TipoRec = TipoRec + 1
                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2).NumberFormat = CStr(TipoRec) & ".000"
                Obj_Hoja.Cells(Fila, 2) = 0
                Obj_Hoja.Cells(Fila, 3) = "MANO DE OBRA"
                Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", True, 8, , , 15, AliniacionHorizontal_Excel.xlHAlignLeft)
                For Each xMO As ETPresupuestoManoObra In RecursoMO
                    Fila = Fila + 1
                    Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", False, 8, , , , AliniacionHorizontal_Excel.xlHAlignLeft)
                    Registro = Registro + 1
                    i = Len(CStr(Registro).ToString.Trim)
                    Item_Texto = CStr(Registro).ToString.Trim
                    For j = i To 2
                        Item_Texto = "0" & Item_Texto
                    Next
                    Item_Texto = CStr(TipoRec) & "." & Item_Texto

                    Obj_Hoja.Cells(Fila, 2) = Item_Texto
                    Obj_Hoja.Cells(Fila, 3) = xMO.Cargo
                    Call CombinarCeldas("C" & CStr(Fila) & ":D" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
                    Obj_Hoja.Cells(Fila, 5) = xMO.UniMed
                    Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 6) = xMO.Cuadrilla
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = xMO.Cantidad
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = xMO.Precio
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = xMO.SubTotal
                    SubTotalRecurso = SubTotalRecurso + xMO.SubTotal
                Next
                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 9) = SubTotalRecurso
                Call FormatoCelda("I" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", True, 9, , , , AliniacionHorizontal_Excel.xlHAlignRight)
            End If

            Registro = 0
            SubTotalRecurso = 0
            If RecursoSer.Count > 0 Then
                TipoRec = TipoRec + 1
                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2).NumberFormat = CStr(TipoRec) & ".000"
                Obj_Hoja.Cells(Fila, 2) = 0
                Obj_Hoja.Cells(Fila, 3) = "SERVICIOS"
                Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", True, 8, , , 15, AliniacionHorizontal_Excel.xlHAlignLeft)
                For Each xSer As ETPresupuestoServicio In RecursoSer
                    Fila = Fila + 1
                    Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", False, 8, , , , AliniacionHorizontal_Excel.xlHAlignLeft)
                    Registro = Registro + 1
                    i = Len(CStr(Registro).ToString.Trim)
                    Item_Texto = CStr(Registro).ToString.Trim
                    For j = i To 2
                        Item_Texto = "0" & Item_Texto
                    Next
                    Item_Texto = CStr(TipoRec) & "." & Item_Texto

                    Obj_Hoja.Cells(Fila, 2) = Item_Texto
                    Obj_Hoja.Cells(Fila, 3) = xSer.Servicio
                    Call CombinarCeldas("C" & CStr(Fila) & ":D" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
                    Obj_Hoja.Cells(Fila, 5) = xSer.UniMed

                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = xSer.Cantidad
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = xSer.Precio
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = xSer.SubTotal
                    SubTotalRecurso = SubTotalRecurso + xSer.SubTotal
                Next
                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 9) = SubTotalRecurso
                Call FormatoCelda("I" & CStr(Fila) & ":I" & CStr(Fila), "Arial Narrow", True, 9, , , , AliniacionHorizontal_Excel.xlHAlignRight)

            End If
            Call BordearCelasExcelContornoGrueso("B" & CStr(FilaInicio) & ":I" & CStr(Fila))

            ' Entidad.PresupuestoDet.Precio
        Next

    End Sub
    Private Sub ExportarPresupuesto()
        Dim Fila As Integer
        Dim Item As Integer = 0
        Dim SubTotal As Double = 0
        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()
        Fila = 1
        Obj_Hoja.Columns(1).ColumnWidth = 13
        Obj_Hoja.Columns(2).ColumnWidth = 71
        Obj_Hoja.Columns(3).ColumnWidth = 8.43
        Obj_Hoja.Columns(4).ColumnWidth = 8.71
        Obj_Hoja.Columns(5).ColumnWidth = 16.14
        Obj_Hoja.Columns(6).ColumnWidth = 17

        Obj_Hoja.Cells(Fila, 4) = "PRESUPUESTO"
        Obj_Hoja.Rows(Fila).RowHeight = 29.25
        Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignCenter)
        Call FormatoCelda("D" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 14, , EstiloLineaExcel.xlContinuous, 44)

        Fila = Fila + 1

        Obj_Hoja.Cells(Fila, 4) = "Nro:"
        If Cbo1.ActiveRow.Cells("Abrev").Value.ToString.Trim = "" Then
            Obj_Hoja.Cells(Fila, 5) = Cbo1.Value.ToString.Trim & " - " & Txt1.Text.Trim
        Else
            Obj_Hoja.Cells(Fila, 5) = Cbo1.ActiveRow.Cells("Abrev").Value.ToString.Trim & " - " & Txt1.Text.Trim
        End If
        'Obj_Hoja.Cells(Fila, 5) = Grid1.ActiveRow.Cells("Area_Abrev").Value.ToString.Trim & " - " & Grid1.ActiveRow.Cells("Cod_Presup").Value.ToString.Trim
        Call FormatoCelda("D" & CStr(Fila) & ":D" & CStr(Fila), "Arial", True, 14, , EstiloLineaExcel.xlContinuous, 44)
        Call CombinarCeldas("E" & CStr(Fila) & ":F" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignCenter)
        Call FormatoCelda("E" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 14, , EstiloLineaExcel.xlContinuous)
        'Call BordearCelasExcelContornoGrueso("D" & CStr(Fila - 1) & ":F" & CStr(Fila))

        Fila = Fila + 2
        Obj_Hoja.Cells(Fila, 4) = "Fecha:"
        ' Obj_Hoja.Cells(Fila, 5) = Grid1.ActiveRow.Cells("Fecha").Value
        Obj_Hoja.Cells(Fila, 5) = Convert.ToDateTime(Dtp1.Value).Date
        Call FormatoCelda("D" & CStr(Fila) & ":D" & CStr(Fila), "Arial", True, 10, , EstiloLineaExcel.xlContinuous, 44)
        Call CombinarCeldas("E" & CStr(Fila) & ":F" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignCenter)
        Call FormatoCelda("E" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 10, , EstiloLineaExcel.xlContinuous)
        'Call BordearCelasExcelContornoGrueso("D" & CStr(Fila) & ":F" & CStr(Fila))

        Fila = Fila + 2
        Obj_Hoja.Cells(Fila, 1) = "Mantenimiento:"
        If Cbo2.Value = "2" Then
            Obj_Hoja.Cells(Fila, 2) = Grid1.ActiveRow.Cells("TipoMantto").Value
        Else
            If TipoDato = ValorTipoDato.vDate OrElse TipoDato = ValorTipoDato.vTime Then
                Obj_Hoja.Cells(Fila, 2) = Grid1.ActiveRow.Cells("TipoMantto").Value & " DE " & Txt6.Value & Cbo3.Text
            Else
                Obj_Hoja.Cells(Fila, 2) = Grid1.ActiveRow.Cells("TipoMantto").Value & " DE " & Txt5.Text & Cbo3.Text
            End If
        End If

        Call FormatoCelda("A" & CStr(Fila) & ":A" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous, 44)
        Call CombinarCeldas("B" & CStr(Fila) & ":F" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
        Call FormatoCelda("B" & CStr(Fila) & ":F" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 1) = "Equipo:"
        Call FormatoCelda("A" & CStr(Fila) & ":A" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous, 44)
        Obj_Hoja.Cells(Fila, 2) = Txt4.Text
        'Obj_Hoja.Cells(Fila, 2) = Grid1.ActiveRow.Cells("Equipo").Value
        Call CombinarCeldas("B" & CStr(Fila) & ":F" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
        Call FormatoCelda("B" & CStr(Fila) & ":F" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 1) = "Cliente:"
        Call FormatoCelda("A" & CStr(Fila) & ":A" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous, 44)
        Obj_Hoja.Cells(Fila, 2) = Txt2.Text
        'Obj_Hoja.Cells(Fila, 2) = Grid1.ActiveRow.Cells("Cliente").Value

        Call CombinarCeldas("B" & CStr(Fila) & ":D" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
        Call FormatoCelda("B" & CStr(Fila) & ":D" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)

        Obj_Hoja.Cells(Fila, 5) = "Moneda:"
        Call FormatoCelda("E" & CStr(Fila) & ":E" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous, 44)
        Obj_Hoja.Cells(Fila, 6) = Cbo5.Value
        'Obj_Hoja.Cells(Fila, 6) = Grid1.ActiveRow.Cells("Moneda").Value
        Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 1) = "Atención:"
        Call FormatoCelda("A" & CStr(Fila) & ":A" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous, 44)
        Obj_Hoja.Cells(Fila, 2) = Txt20.Text
        'Obj_Hoja.Cells(Fila, 2) = Grid1.ActiveRow.Cells("EncargadoArea").Value
        Call CombinarCeldas("B" & CStr(Fila) & ":D" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
        Call FormatoCelda("B" & CStr(Fila) & ":D" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)

        Obj_Hoja.Cells(Fila, 5) = "Tiempo Ejec.:"
        Call FormatoCelda("E" & CStr(Fila) & ":E" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous, 44)
        Obj_Hoja.Cells(Fila, 6) = CStr(DateDiff(DateInterval.Day, Dtp2.Value, Dtp3.Value) + 1) & " día calendario"
        'Obj_Hoja.Cells(Fila, 6) = CStr(DateDiff(DateInterval.Day, Grid1.ActiveRow.Cells("FechaInicio").Value, Grid1.ActiveRow.Cells("FechaTerminacion").Value) + 1) & " día calendario"
        Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)

        ' Call BordearCelasExcelContornoGrueso("A" & CStr(Fila - 3) & ":F" & CStr(Fila))

        Fila = Fila + 1
        Obj_Hoja.Rows(Fila).RowHeight = 9

        Fila = Fila + 1

        Obj_Hoja.Cells(Fila, 1) = "Ítem"
        Obj_Hoja.Cells(Fila, 2) = "Partida"
        Obj_Hoja.Cells(Fila, 3) = "Cantidad"
        Obj_Hoja.Cells(Fila, 4) = "Unidad"
        Obj_Hoja.Cells(Fila, 5) = "P. U."
        Obj_Hoja.Cells(Fila, 6) = "P. Parcial"
        Call FormatoCelda("A" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 10, , EstiloLineaExcel.xlContinuous, 44)
        ' Call BordearCelasExcelContornoGrueso("A" & CStr(Fila) & ":F" & CStr(Fila))
        Me.Presupuesto = Grid1.ActiveRow.Cells("Presupuesto").Value
        Txt7.Text = Grid1.ActiveRow.Cells("TipoCambio").Value


        If Grid2.Rows.Count > 0 Then
            For Each xRow As UltraGridRow In Grid2.Rows
                Item = Item + 1
                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 1) = CStr(Item)
                Obj_Hoja.Cells(Fila, 2) = xRow.Cells("Descripcion").Value
                Obj_Hoja.Cells(Fila, 3).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 3) = xRow.Cells("Metrado").Value
                Obj_Hoja.Cells(Fila, 4) = xRow.Cells("UniMed").Value
                Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 5) = xRow.Cells("Precio").Value
                Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 6) = xRow.Cells("Parcial").Value
                SubTotal = SubTotal + xRow.Cells("Parcial").Value
                Call FormatoCelda("A" & CStr(Fila) & ":F" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)
            Next
        End If
        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 4) = "SubTotal:"
        Call CombinarCeldas("D" & CStr(Fila) & ":E" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
        Call FormatoCelda("D" & CStr(Fila) & ":E" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)
        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 6) = SubTotal
        Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 10, , EstiloLineaExcel.xlContinuous)
        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 4) = "Gastos Generales:"
        Call CombinarCeldas("D" & CStr(Fila) & ":E" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
        Call FormatoCelda("D" & CStr(Fila) & ":E" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)
        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 6) = 0
        Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)
        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 4) = "Utilidad:"
        Call CombinarCeldas("D" & CStr(Fila) & ":E" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
        Call FormatoCelda("D" & CStr(Fila) & ":E" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)
        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 6) = 0
        Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)
        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 4) = "TOTAL " & Cbo5.Value & ":"
        Call CombinarCeldas("D" & CStr(Fila) & ":E" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
        Call FormatoCelda("D" & CStr(Fila) & ":E" & CStr(Fila), "Arial", True, 11, , EstiloLineaExcel.xlContinuous)
        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 6) = "=SUM(F" & CStr(Fila - 3) & ":F" & CStr(Fila - 1) & ")"
        Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 11, , EstiloLineaExcel.xlContinuous)

        Call CombinarCeldas("A" & CStr(Fila - 3) & ":C" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignLeft)
        Call FormatoCelda("A" & CStr(Fila) & ":C" & CStr(Fila), "Arial", False, 10, , EstiloLineaExcel.xlContinuous)

        Fila = Fila + 5
        Obj_Hoja.Cells(Fila, 4) = "_____________________________________"
        Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignCenter)
        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 4) = "Cía Minera Agregados Calcareos S.A."
        Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), AliniacionHorizontal_Excel.xlHAlignCenter)

    End Sub

    Private Sub BordearCelasExcelContornoGrueso(ByVal RANGO As String)
        On Error GoTo Continuar
        Obj_Excel.range(RANGO).Select()


        'Obj_Excel.Selection.Borders(BordesExcel.xlDiagonalDown).LineStyle = EstiloLineaExcel.xlLineStyleNone
        'Obj_Excel.Selection.Borders(BordesExcel.xlDiagonalUp).LineStyle = EstiloLineaExcel.xlLineStyleNone
        With Obj_Excel.Selection.Borders(BordesExcel.xlEdgeLeft)
            .LineStyle = EstiloLineaExcel.xlContinuous
            .Weight = BorderWeithExcel.xlMedium
            .ColorIndex = ConstantesExcel.xlAutomatic
        End With
        With Obj_Excel.Selection.Borders(BordesExcel.xlEdgeTop)
            .LineStyle = EstiloLineaExcel.xlContinuous
            .Weight = BorderWeithExcel.xlMedium
            .ColorIndex = ConstantesExcel.xlAutomatic
        End With
        With Obj_Excel.Selection.Borders(BordesExcel.xlEdgeBottom)
            .LineStyle = EstiloLineaExcel.xlContinuous
            .Weight = BorderWeithExcel.xlMedium
            .ColorIndex = ConstantesExcel.xlAutomatic
        End With
        With Obj_Excel.Selection.Borders(BordesExcel.xlEdgeRight)
            .LineStyle = EstiloLineaExcel.xlContinuous
            .Weight = BorderWeithExcel.xlMedium
            .ColorIndex = ConstantesExcel.xlAutomatic
        End With
        'Obj_Excel.Selection.Borders(BordesExcel.xlInsideVertical).LineStyle = EstiloLineaExcel.xlLineStyleNone
        'Obj_Excel.Selection.Borders(BordesExcel.xlInsideHorizontal).LineStyle = EstiloLineaExcel.xlLineStyleNone

Continuar:
        If Err.Number = 91 Then
            Exit Sub
        End If
    End Sub
    Private Sub CombinarCeldas(ByVal RANGO As String, ByVal Alineacion As Long)
        Obj_Excel.range(RANGO).Select()
        Obj_Excel.Selection.MergeCells = True
        If Alineacion <> 0 Then
            Obj_Excel.range(RANGO).HorizontalAlignment = Alineacion
        End If

        Obj_Excel.range(RANGO).VerticalAlignment = AliniacionVertical_Excel.xlVAlignCenter
        Obj_Excel.ActiveCell.WrapText = True
    End Sub
    Private Sub FormatoCelda(ByVal RANGO As String, ByVal TipoLetra As String, _
                             ByVal Negrita As Boolean, ByVal TamañoLetra As Integer, _
                             Optional ByVal Color As Integer = 0, Optional ByVal Linea As Integer = 0, _
                             Optional ByVal Relleno As Integer = 0, Optional ByVal Horizontal As Integer = 0, _
                             Optional ByVal Vertical As Integer = 0)
        With Obj_Hoja.range(RANGO)
            .Font.Name = TipoLetra
            .Font.Bold = Negrita
            .Font.Size = TamañoLetra
            If Val(Color) > 0 Then .Font.ColorIndex = Color
            If Val(Linea) > 0 Then .Borders.LineStyle = Linea
            If Val(Relleno) > 0 Then .Interior.ColorIndex = Relleno
            If Val(Horizontal) > 0 Then .HorizontalAlignment = Horizontal
            If Val(Vertical) > 0 Then .VerticalAlignment = Vertical
        End With
    End Sub

#End Region
#Region "Combo"
    Private Sub Cbo1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        With sender.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.TrueString
            For Each uColumn As UltraGridColumn In .Columns
                If sender.Name = "Cbo1" Then
                    If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Area" _
                        OrElse uColumn.Key = "Abrev") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                End If
            Next
        End With

        If sender.Name = "Cbo1" Then
            Cbo1.DisplayLayout.Bands(0).Columns("Codigo").Width = 50
            Cbo1.DisplayLayout.Bands(0).Columns("Area").Width = 300
            Cbo1.DisplayLayout.Bands(0).Columns("Abrev").Width = 60
        End If
    End Sub
    Private Sub Cbo1_RowSelected(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles Cbo1.RowSelected
        If e Is Nothing Then
            Return
        End If

        Dtp1.Focus()
    End Sub
    Private Sub Cbo2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo2.ValueChanged

        If Me.Atributo > 0 Then
            Txt5.Focus()
            Me.Txt5.ReadOnly = False
            Txt6.ReadOnly = False
        Else
            Me.Txt5.ReadOnly = True
            Txt6.ReadOnly = True
        End If
    End Sub
    Private Sub Cbo3_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo3.InitializeLayout
        With sender.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.TrueString
            .Columns("Descripcion").Width = sender.Width - 40
            .Columns("Abrev").Width = 40
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Descripcion" OrElse uColumn.Key = "Abrev") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next

        End With
    End Sub
    Private Sub Cbo4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo4.ValueChanged
        Cbo5.Focus()
    End Sub
    Private Sub Cbo5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo5.ValueChanged
        If TipoG = State.eNew OrElse TipoG = State.eEdit Then
            Txt7.Text = CargarTipoCambio()
            If Val(Txt7.Text) <= 0 Then
                MsgBox("No hay Tipo de Cambio para la Fecha", MsgBoxStyle.Exclamation, msgComacsa)
            End If
            Txt8.Focus()
        End If
    End Sub
#End Region
#Region "Texto"
    Private Sub Txt5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt5.KeyPress
        Dim KeyAscii As Integer = 0
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Cbo4.Focus()
        Else
            'If Cbo2.Value = "1" Then
            Select Case TipoDato
                Case ValorTipoDato.vEntero
                    KeyAscii = ValidarEntero(KeyAscii)
                Case ValorTipoDato.vDecimal
                    KeyAscii = ValidarDecimal(KeyAscii, Txt5.Text)
            End Select
            'End If
        End If
        e.KeyChar = Chr(KeyAscii)
    End Sub
#End Region
#Region "Botones"
    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Dim frm As New frmBuscar
        If Chk1.Checked = False Then
            frm.Formulario = frmBuscar.eState.frm_Cliente
        Else
            frm.Formulario = frmBuscar.eState.frm_Area_Jefatura
        End If
        frm.ShowDialog()

        Txt2.Text = frm.Flag2 & "  " & frm.Descripcion
        Txt3.Text = frm.Flag3

        Me.AreaInt = frm.Flag4
        Me.FechaInicioJA = frm.Flag5
        Me.FechaTerminoJA = frm.Flag6
        Cliente = frm.Flag2
        frm = Nothing

    End Sub
    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        Dim frm As New frmBuscar
        frm.Formulario = frmBuscar.eState.frm_Equipo
        frm.ShowDialog()
        Equipo = frm.ID
        Txt4.Text = frm.Flag7 & "  " & frm.Descripcion
        Cbo3.Value = frm.Flag3
        Atributo = frm.Flag1
        Label6.Text = "* " & frm.Flag2
        TipoDato = Val(frm.Flag4)
        Select Case TipoDato
            Case ValorTipoDato.vDate
                Txt6.FormatString = "{LOC}dd/mm/yyyy"
                Txt5.Visible = False
                Txt6.Visible = True
            Case ValorTipoDato.vTime
                Txt6.FormatString = "{LOC}hh:mm"
                Txt5.Visible = False
                Txt6.Visible = True
            Case Else
                Txt6.Visible = False
                Txt5.Visible = True
        End Select
        Longitud = Val(frm.Flag5)
        Decimales = Val(frm.Flag6)

        If Me.Atributo > 0 Then
            Me.Txt5.ReadOnly = False
            Txt6.ReadOnly = False
        Else
            Me.Txt5.ReadOnly = True
            Txt6.ReadOnly = True
        End If

        frm = Nothing
    End Sub
#End Region
#Region "Datetime"
    Private Sub Dtp1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp1.ValueChanged
        If TipoG = State.eNew OrElse TipoG = State.eEdit Then
            Txt7.Text = CargarTipoCambio()
            If Val(Txt7.Text) <= 0 Then
                MsgBox("No hay Tipo de Cambio para la Fecha", MsgBoxStyle.Exclamation, msgComacsa)
            End If
            Call ObtenerJefeArea()
        End If

    End Sub
#End Region


    Private Sub Chk1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk1.CheckedChanged
        Me.Txt2.Clear()
        Me.Txt3.Clear()
        Me.Cliente = String.Empty
        Me.FechaInicioJA = String.Empty
        Me.FechaTerminoJA = String.Empty
        Me.AreaInt = String.Empty
        If Btn1.Enabled = True Then Btn1.Focus()
    End Sub

    Private Sub Cbo1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged
        Call ObtenerJefeArea()
    End Sub


End Class