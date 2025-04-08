Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmPRequerimientoMantto

#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private _Requerimiento As Long = 0
    Private _Solicitante As String = String.Empty
    Private _Dirigido As String = String.Empty
    Private _Area As String = String.Empty
    Private _Resultado As Integer = 0
    Private _Equipo As Long = 0
    Private _CheckList As Long = 0
    Private _Observaciones As String = String.Empty
    Private _StatusDet As String = String.Empty
    Private _DetReq As Long = 0
    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private TipoG As State
    Private TipoGDet As State
    Private Ls_DetReq As List(Of ETRequerimiento_ManttoDetalle) = Nothing
    Private Ls_DetReq_Anulado As List(Of ETRequerimiento_ManttoDetalle) = Nothing
#End Region
#Region "Propiedades"
    Private Property Requerimiento() As Long
        Get
            Return _Requerimiento
        End Get
        Set(ByVal value As Long)
            _Requerimiento = value
        End Set
    End Property
    Private Property Solicitante() As String
        Get
            Return _Solicitante
        End Get
        Set(ByVal value As String)
            _Solicitante = value
        End Set
    End Property
    Private Property Dirigido() As String
        Get
            Return _Dirigido
        End Get
        Set(ByVal value As String)
            _Dirigido = value
        End Set
    End Property
    Private Property Resultado() As Integer
        Get
            Return _Resultado
        End Get
        Set(ByVal value As Integer)
            _Resultado = value
        End Set
    End Property
    Private Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
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
    Private Property CheckList() As Long
        Get
            Return _CheckList
        End Get
        Set(ByVal value As Long)
            _CheckList = value
        End Set
    End Property
    Private Property Observaciones() As String
        Get
            Return _Observaciones
        End Get
        Set(ByVal value As String)
            _Observaciones = value
        End Set
    End Property
    Private Property StatusDet() As String
        Get
            Return _StatusDet
        End Get
        Set(ByVal value As String)
            _StatusDet = value
        End Set
    End Property
    Private Property DetReq() As Long
        Get
            Return _DetReq
        End Get
        Set(ByVal value As Long)
            _DetReq = value
        End Set
    End Property
#End Region
#Region "Procedimientos Privados"
    Private Sub InicializarValores()
        _Requerimiento = 0
        _Solicitante = String.Empty
        _Dirigido = String.Empty
        _Area = String.Empty
        _Resultado = 0
        Call InicializarValoresDetalle()
    End Sub
    Private Sub InicializarValoresDetalle()
        _DetReq = 0
        _Equipo = 0
        _CheckList = 0
        _Observaciones = String.Empty
        _StatusDet = String.Empty
    End Sub
    Private Sub LimpiarDetalle()
        Call InicializarValoresDetalle()
        Me.Txt5.Clear()
        Me.Txt6.Clear()
        Me.Cbo3.Value = ""
        Me.Cbo4.Value = ""
    End Sub
    Private Sub HabilidarControles(ByVal b As Boolean)
        Cbo1.ReadOnly = Not b
        Cbo2.ReadOnly = True
        Txt1.ReadOnly = True
        Txt2.ReadOnly = True
        Txt3.ReadOnly = True
        Txt4.ReadOnly = Not b
        Dtp1.ReadOnly = Not b
        Btn1.Enabled = b
        Btn2.Enabled = b
        Call HabilitarControlDetalle(Not b)
    End Sub
    Private Sub HabilitarControlDetalle(ByVal b As Boolean)
        Txt5.ReadOnly = Boolean.TrueString
        Txt6.ReadOnly = Not b
        Cbo3.ReadOnly = Not b
        Cbo4.ReadOnly = Boolean.TrueString
        Btn3.Enabled = b
        Btn5.Enabled = b
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
    Private Sub Cargar_CheckList()

        Dim ObjEnt As New ETCheckList
        Dim Ls_CheckList As New List(Of ETCheckList)
        Dim objNeg As New NGCheckList

        ObjEnt.EquipoID = Me.Equipo
        If TipoG = State.eNew Then
            ObjEnt.Tipo = "5"
        Else
            If Me.Cbo2.Value = "K1" Then
                ObjEnt.Tipo = "5"
            Else
                ObjEnt.Tipo = "6"
            End If
        End If

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = objNeg.ConsultarCheckList_Equipo(ObjEnt)
        If Entidad.MyLista.Validacion Then
            Ls_CheckList = Entidad.MyLista.Ls_CheckList
        End If

        Call CargarUltraCombo(Me.Cbo3, Ls_CheckList, "CheckList", "Codigo")
    End Sub
    Private Sub Limpiar()
        Call InicializarValores()
        Me.Txt1.Clear()
        Me.Txt2.Clear()
        Me.Txt3.Clear()
        Me.Txt4.Clear()
        Cbo1.Value = ""
        Cbo2.Value = "K1"
        Me.Dtp1.Value = Now.Date
        Call LimpiarDetalle()
        Ls_DetReq = Nothing
        Ls_DetReq = New List(Of ETRequerimiento_ManttoDetalle)
        Call CargarUltraGrid(Grid2, Ls_DetReq)
    End Sub
    Private Sub HabilitarBtnDetalle()
        If Cbo2.Value = "K1" Then
            Select Case TipoGDet
                Case State.eNew, State.eEdit, State.eView
                    Btn4.Enabled = True
                    Btn5.Enabled = False
                    Btn6.Enabled = True
                    Btn7.Enabled = True
                    'Case State.eView
                    '    Btn4.Enabled = True
                    '    Btn5.Enabled = True
                    '    Btn6.Enabled = True
                    '    Btn7.Enabled = True
            End Select
        Else
            Btn4.Enabled = False
            Btn5.Enabled = False
            Btn6.Enabled = False
            Btn7.Enabled = False
        End If
    End Sub
    Private Sub ModificarDetalle()
        If Grid2.Rows.Count <= 0 Then Exit Sub
        If Grid2.ActiveRow Is Nothing Then Exit Sub
        Me.Txt5.Text = Grid2.ActiveRow.Cells("Codigo").Value & Space(2) & Grid2.ActiveRow.Cells("Equipo").Value
        Me.Equipo = Grid2.ActiveRow.Cells("EquipoID").Value
        Call Cargar_CheckList()
        Me.Cbo3.Value = Grid2.ActiveRow.Cells("CheckListID").Value
        Me.Txt6.Text = Grid2.ActiveRow.Cells("Observaciones").Value
        Me.DetReq = Grid2.ActiveRow.Cells("Requerimiento").Value
        Me.StatusDet = Grid2.ActiveRow.Cells("Status").Value
        Select Case Me.StatusDet
            Case "*"
                Me.Cbo4.Value = "K5"
            Case "T"
                Me.Cbo4.Value = "K4"
            Case "R"
                Me.Cbo4.Value = "K3"
            Case "P"
                Me.Cbo4.Value = "K2"
            Case Else
                Me.Cbo4.Value = "K1"
        End Select

        TipoGDet = State.eEdit
        If TipoG = State.eNew Then
            Call HabilitarControlDetalle(True)
            Call HabilitarBtnDetalle()
        Else
            If Cbo2.Value = "K1" Then
                Call HabilitarControlDetalle(True)
                Call HabilitarBtnDetalle()
            Else
                Call HabilitarControlDetalle(False)
            End If
        End If
    End Sub
    Private Sub Inicio()
        Me.Tab1.Tabs("T01").Selected = Boolean.TrueString
        TipoG = State.eView
        TipoGDet = State.eView
        Call HabilidarControles(False)
        Call Limpiar()
        Btn4.Enabled = False
        Btn5.Enabled = False
        Btn6.Enabled = False
        Btn7.Enabled = False
        Call CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Dim Ls_Requerimiento As New List(Of ETRequerimiento_Mantto)
        Dim ObjNG As New NGRequerimiento_Mantto
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = ObjNG.ConsultarRequerimiento
        If Entidad.MyLista.Validacion Then
            Ls_Requerimiento = Entidad.MyLista.Ls_Requerimiento_Mantto
        End If
        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Requerimiento)
    End Sub
    Private Sub CargarDetReq()
        Dim ObjReq As New ETRequerimiento_Mantto
        Dim ObjNG As New NGRequerimiento_Mantto
        ObjReq.Tipo = 4
        ObjReq.Requerimiento = Me.Requerimiento
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = ObjNG.ConsultarRequerimiento_Det(ObjReq)
        Ls_DetReq = New List(Of ETRequerimiento_ManttoDetalle)
        If Entidad.MyLista.Validacion Then
            Ls_DetReq = Entidad.MyLista.Ls_Requerimiento_Det_Mantto
        End If
        Call CargarUltraGrid(Grid2, Ls_DetReq)

    End Sub
#End Region
#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        TipoG = State.eNew
        Call Limpiar()
        Call HabilidarControles(Boolean.TrueString)
        Me.Btn4.Enabled = Boolean.TrueString
        Call Cargar_Area()
        Ls_DetReq_Anulado = Nothing
        Ls_DetReq = Nothing
        Ls_DetReq = New List(Of ETRequerimiento_ManttoDetalle)
        Call CargarUltraGrid(Grid2, Ls_DetReq)
        Me.Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub
    Public Sub Grabar()
        If Cbo2.Value <> "K1" Then
            Call Inicio()
            Exit Sub
        End If
        Dim objReq As New ETRequerimiento_Mantto
        Dim ObjNG As New NGRequerimiento_Mantto
        Dim Codigo As String = String.Empty

        objReq.Tipo = TipoG
        objReq.Codigo = Me.Txt1.Text.Trim
        objReq.CodArea = Me.Cbo1.Value
        objReq.Area = Me.Area
        objReq.SolicitanteID = Me.Solicitante
        objReq.DirigidoID = Me.Dirigido
        objReq.Fecha = Me.Dtp1.Value
        objReq.Asunto = Me.Txt4.Text.Trim
        objReq.Requerimiento = Me.Requerimiento
        Select Case Cbo2.Value
            Case "K1"
                objReq.Status = ""
            Case "K2"
                objReq.Status = "P"
            Case "K3"
                objReq.Status = "R"
            Case "K4"
                objReq.Status = "T"
            Case "K5"
                objReq.Status = "*"
        End Select
        objReq.Usuario = User_Sistema
        Try
            Codigo = ObjNG.Mantenimiento_Requerimiento(objReq, Ls_DetReq, Ls_DetReq_Anulado)
            If Codigo.Trim <> "" Then
                If TipoG = State.eNew Then
                    MsgBox("Se generó el requerimiento: " & Codigo, MsgBoxStyle.Information, msgComacsa)
                Else
                    MsgBox("Se modificó el requerimiento: " & Codigo, MsgBoxStyle.Information, msgComacsa)
                End If

                Call Inicio()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, msgComacsa)
        End Try

    End Sub
    Public Sub Eliminar()
        Dim objReq As New ETRequerimiento_Mantto
        If Grid1.Rows.Count <= 0 Then Exit Sub
        If Grid1.ActiveRow Is Nothing Then Exit Sub
        If Not (Grid1.ActiveRow.Cells("Status").Value.ToString.Trim = "") Then
            MsgBox("Solo puede anular los Requerimientos que estan Activos", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        Me.Requerimiento = Me.Grid1.ActiveRow.Cells("Requerimiento").Value
        objReq.Usuario = User_Sistema
        objReq.Status = "*"
        objReq.Tipo = 3
        Negocio.Requerimiento_Mantto = New NGRequerimiento_Mantto
        Ls_DetReq = Nothing
        Ls_DetReq_Anulado = Nothing
        Try
            Me.Resultado = Negocio.Requerimiento_Mantto.Mantenimiento_Requerimiento(objReq, Ls_DetReq, Ls_DetReq_Anulado)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, msgComacsa)
        End Try
        Call Inicio()
    End Sub
    Public Sub Modificar()
        If Me.Grid1.ActiveRow Is Nothing Then Exit Sub
        If Me.Grid1.Rows.Count < 0 Then Exit Sub
        TipoG = State.eEdit
        TipoGDet = State.eView
        With Grid1.ActiveRow
            Call Limpiar()

            Select Case .Cells("Status").Value
                Case "P"
                    Me.Cbo2.Value = "K2"
                Case "R"
                    Me.Cbo2.Value = "K3"
                Case "T"
                    Me.Cbo2.Value = "K4"
                Case "*"
                    Me.Cbo2.Value = "K5"
                Case Else
                    Me.Cbo2.Value = "K1"
                    Me.Btn4.Enabled = Boolean.TrueString
            End Select
            Call Cargar_Area()
            Call HabilidarControles(Boolean.FalseString)
            Call HabilitarBtnDetalle()
            Call HabilitarControlDetalle(Boolean.FalseString)

            Me.Cbo1.Value = .Cells("CodArea").Value
            Me.Txt1.Text = .Cells("Codigo").Value
            Me.Txt2.Text = .Cells("Solicitante").Value
            Me.Txt3.Text = .Cells("Dirigido").Value
            Me.Txt4.Text = .Cells("Asunto").Value
            Me.Dtp1.Value = .Cells("Fecha").Value
            Me.Requerimiento = .Cells("Requerimiento").Value
            Me.Solicitante = .Cells("SolicitanteID").Value
            Me.Dirigido = .Cells("DirigidoID").Value
            Ls_DetReq = Nothing
            Call CargarDetReq()
            Ls_DetReq_Anulado = Nothing
            Ls_DetReq_Anulado = New List(Of ETRequerimiento_ManttoDetalle)
            Me.Tab1.Tabs("T02").Selected = Boolean.TrueString
        End With
    End Sub
    Public Sub Cancelar()
        If Tab1.Tabs("T03").Selected = True Then
            Call LimpiarDetalle()
            TipoGDet = State.eView
            Call HabilitarBtnDetalle()
        End If
    End Sub
    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
#End Region
#Region "Combos"
    Private Sub ConfigCombo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo1.InitializeLayout
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
        Else
        End If
    End Sub
    Private Sub Cbo1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged
        If Cbo1.ActiveRow Is Nothing Then Exit Sub
        Me.Area = Cbo1.ActiveRow.Cells("Abrev").Value
    End Sub
    Private Sub Cbo3_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo3.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Fecha" _
                    OrElse uColumn.Key = "TipoCL" OrElse uColumn.Key = "Control" _
                    OrElse uColumn.Key = "Valor" OrElse uColumn.Key = "Und") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                Select Case uColumn.Key
                    Case "Codigo", "Valor"
                        uColumn.MinWidth = 80
                        uColumn.MaxWidth = 80
                    Case "Fecha"
                        uColumn.MinWidth = 90
                        uColumn.MaxWidth = 90
                    Case "TipoCL", "Control"
                        uColumn.MinWidth = 100
                        uColumn.MaxWidth = 100
                    Case "Und"
                        uColumn.MinWidth = 50
                        uColumn.MaxWidth = 50
                End Select
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
#End Region
#Region "Grillas"
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Area" OrElse uColumn.Key = "Codigo" _
                    OrElse uColumn.Key = "Fecha" OrElse uColumn.Key = "Solicitante" _
                    OrElse uColumn.Key = "Dirigido" OrElse uColumn.Key = "Asunto" _
                    OrElse uColumn.Key = "Estado") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Private Sub Grid2_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid2.DoubleClickRow
        If e Is Nothing Then Exit Sub
        Call ModificarDetalle()
    End Sub

    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Equipo" _
                    OrElse uColumn.Key = "CheckList" OrElse uColumn.Key = "Observaciones" _
                    OrElse uColumn.Key = "Estado") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
#End Region
#Region "Botones"
    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Dim ObjSol As New frmBuscar
        ObjSol.Formulario = frmBuscar.eState.frm_Area_Empleado
        ObjSol.FechaInput = Me.Dtp1.Value
        ObjSol.Codigo_Input = Me.Cbo1.Value
        ObjSol.TipoReporte = 7
        ObjSol.ShowDialog()
        Me.Txt2.Text = ObjSol.Flag2.Trim + " - " + ObjSol.Descripcion
        Solicitante = ObjSol.Flag2
        ObjSol = Nothing
        If Solicitante.Trim <> "" Then
            If TipoG = State.eNew Then
                Me.Cbo1.ReadOnly = True
            End If
        Else
            If TipoG = State.eNew Then
                Me.Cbo1.ReadOnly = False
            End If
        End If

    End Sub
    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        Dim ObjDirig As New frmBuscar
        ObjDirig.Formulario = frmBuscar.eState.frm_Area_Empleado
        ObjDirig.FechaInput = Me.Dtp1.Value
        If gAreaMantto = True Then
            ObjDirig.Codigo_Input = gAreaEmpleado
        Else
            ObjDirig.Codigo_Input = ""
        End If
        ObjDirig.TipoReporte = 8
        ObjDirig.ShowDialog()
        Me.Txt3.Text = ObjDirig.Flag2.Trim + " - " + ObjDirig.Descripcion
        Dirigido = ObjDirig.Flag2
        ObjDirig = Nothing

        If Dirigido.Trim <> "" Then
            If TipoG = State.eNew Then
                Me.Dtp1.ReadOnly = True
            End If
        Else
            If TipoG = State.eNew Then
                Me.Dtp1.ReadOnly = False
            End If
        End If
    End Sub
    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        Dim frmEq As New frmBuscar


        frmEq.Formulario = frmBuscar.eState.frm_Equipo
        frmEq.ShowDialog()
        Me.Equipo = frmEq.ID
        Me.Txt5.Text = frmEq.Flag7 & Space(2) & frmEq.Descripcion

        Call Cargar_CheckList()
        frmEq = Nothing
    End Sub
    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        Call LimpiarDetalle()
        TipoGDet = State.eNew
        Call HabilitarBtnDetalle()
        Call HabilitarControlDetalle(Boolean.TrueString)
        Me.Btn6.Enabled = False
        Btn7.Enabled = False
        Me.Cbo4.Value = "K1"

    End Sub
    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        Dim EntObj As ETRequerimiento_ManttoDetalle = Nothing
        Dim Dup As Integer = 0

        If Me.Equipo <= 0 Then
            MsgBox("Ingrese el Equipo", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If Cbo3.Value Is Nothing Then
            MsgBox("Ingrese CheckList", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub

        ElseIf Val(Cbo3.Value) <= 0 Then
            MsgBox("Ingrese CheckList", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If Cbo4.Value = "" Then
            MsgBox("Seleccione el Estado", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If TipoGDet = State.eNew Then

            For Each Row As ETRequerimiento_ManttoDetalle In Ls_DetReq
                If Row.EquipoID = Me.Equipo Then
                    Dup = Dup + 1
                End If
            Next

            If Dup > 0 Then
                MsgBox("El Equipo ya fue agregado a la Lista", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If
            EntObj = New ETRequerimiento_ManttoDetalle
            EntObj.Tipo = TipoGDet
            EntObj.Codigo = Mid(Txt5.Text.Trim, 1, 8)
            EntObj.Equipo = Mid(Txt5.Text.Trim, 11, Len(Me.Txt5.Text))
            EntObj.CheckList = Cbo3.Text
            EntObj.Observaciones = Me.Txt6.Text.Trim
            EntObj.Estado = Me.Cbo4.Text
            EntObj.Usuario = User_Sistema
            EntObj.Status = ""
            EntObj.EquipoID = Me.Equipo
            EntObj.CheckListID = Cbo3.Value
            EntObj.Requerimiento = 0
            Ls_DetReq.Add(EntObj)
        Else

            For Each Row As ETRequerimiento_ManttoDetalle In Ls_DetReq
                If Row.EquipoID = Me.Equipo Then
                    If Grid2.ActiveRow.Cells("EquipoID").Value = Me.Equipo Then
                        Dup = Dup + 1
                    Else
                        Dup = Dup + 2
                    End If

                End If
            Next

            If Dup > 1 Then
                MsgBox("El Equipo ya fue agregado a la Lista", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            Grid2.ActiveRow.Cells("Codigo").Value = Mid(Txt5.Text.Trim, 1, 8)
            Grid2.ActiveRow.Cells("Equipo").Value = Mid(Txt5.Text.Trim, 11, Len(Me.Txt5.Text))
            Grid2.ActiveRow.Cells("CheckList").Value = Cbo3.Text
            Grid2.ActiveRow.Cells("Observaciones").Value = Me.Txt6.Text.Trim
            Grid2.ActiveRow.Cells("Estado").Value = Cbo4.Text
            Grid2.ActiveRow.Cells("Status").Value = StatusDet
            Grid2.ActiveRow.Cells("EquipoID").Value = Me.Equipo
            Grid2.ActiveRow.Cells("CheckListID").Value = Me.Cbo3.Value
            Grid2.ActiveRow.Cells("Requerimiento").Value = DetReq
            Grid2.ActiveRow.Cells("Usuario").Value = User_Sistema
            Grid2.UpdateData()
        End If

        Call CargarUltraGrid(Grid2, Ls_DetReq)
        Call HabilitarControlDetalle(False)
        TipoGDet = State.eView
        Call HabilitarBtnDetalle()
        Call LimpiarDetalle()
    End Sub
    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        Call ModificarDetalle()
    End Sub
    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        If Cbo2.Value <> "K1" Then Exit Sub
        If Grid2.Rows.Count <= 0 Then Exit Sub
        If Me.Grid2.ActiveRow Is Nothing Then Exit Sub
        Dim Mensaje As String
        Dim objReqDet As ETRequerimiento_ManttoDetalle = Nothing

        Mensaje = "Esta seguro de quitar de la Lista al Equipo: "
        Mensaje = Mensaje & Grid2.ActiveRow.Cells("Codigo").Value
        If MsgBox(Mensaje, MsgBoxStyle.Information + MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        If TipoG = State.eEdit Then
            objReqDet = New ETRequerimiento_ManttoDetalle
            objReqDet = Ls_DetReq(Grid2.ActiveRow.Index)
            If objReqDet.Tipo = 2 Then
                objReqDet.Tipo = 3
                Ls_DetReq_Anulado.Add(objReqDet)
            End If

        End If
        Ls_DetReq.RemoveAt(Grid2.ActiveRow.Index)
        Call CargarUltraGrid(Grid2, Ls_DetReq)
    End Sub
#End Region
#Region "Formulario"

    Private Sub frmPRequerimientoMantto_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmPRequerimientoMantto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
#End Region
End Class