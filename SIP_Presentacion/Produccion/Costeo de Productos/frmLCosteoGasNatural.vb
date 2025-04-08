Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmLCosteoGasNatural

#Region "Declarar Variables"

    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Periodo As List(Of ETPeriodo) = Nothing
    Private Ls_Detalle As List(Of ETCosteoActivo) = Nothing
    Private Ls_Anular As List(Of ETCosteoActivo) = Nothing
    Private Ls_LineaProduccion As List(Of ETLineaNegocio) = Nothing

    Private Enum eState
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private TipoG As eState
    Private TipoGDet As eState
    Private _Periodo As Integer = 0
#End Region

#Region "Propiedades"
    Private Property Periodo() As Integer
        Get
            Return _Periodo
        End Get
        Set(ByVal value As Integer)
            _Periodo = value
        End Set
    End Property
#End Region

#Region "Funciones Privadas"
    Private Function ValidarRegistro() As Boolean
        Dim i As Integer = -1
        Dim dup As Integer = 0
        Dim Consumo As Double = 0
        ValidarRegistro = True

        If String.IsNullOrEmpty(Txt1.Text.Trim) Then
            MsgBox("Seleccione el Equipo", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        If Val(Txt3.Value) <= 0 Then
            MsgBox("Ingrese el Consumo mayor a Cero", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        For Each xRow As UltraGridRow In Grid3.Rows
            i = i + 1

            If TipoGDet = eState.eNew Then
                If xRow.Cells("Codigo").Value.ToString.Trim = Txt1.Text.Trim Then
                    dup = dup + 1
                End If
            ElseIf TipoGDet = eState.eEdit Then
                If xRow.Cells("Codigo").Value.ToString.Trim = Txt1.Text.Trim Then
                    If Val(i) <> Val(Grid3.ActiveRow.Index) Then
                        dup = dup + 1
                    End If
                End If
            End If
        Next

        If dup > 0 Then
            MsgBox("Ya se agrego el Equipo: " & Txt1.Text.Trim, MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If


    End Function

    Private Function ConsumoGasNatEquipo() As Double
        Dim lResult As Double = 0
        For Each xRow As UltraGridRow In Grid3.Rows
            lResult = lResult + Val(xRow.Cells("Cantidad").Value)
        Next
        Return lResult
    End Function
#End Region

#Region "Procedimientos Privados"

    Private Sub Cargar_Grilla()
        Entidad.Periodo = New ETPeriodo
        Entidad.Periodo.TipoPeriodo = ETPeriodo.sTipoPeriodo.CosteoGasNatural
        Entidad.Periodo.Tipo = 6

        Ls_Periodo = Nothing
        Ls_Periodo = New List(Of ETPeriodo)

        Entidad.MyLista = New ETMyLista
        Negocio.PeriodoGasNatural = New NGPeriodoGasNatural
        Entidad.MyLista = Negocio.PeriodoGasNatural.Consultar_Periodo(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            Ls_Periodo = Entidad.MyLista.Ls_Periodo
        End If
        Call CargarUltraGrid(Grid1, Ls_Periodo)
    End Sub

    Private Sub Inicio()
        TipoG = eState.eView
        TipoGDet = eState.eView
        Call HabilitarControles(False)
        Call InHabilitarControlesDetalle(True)
        Call Limpiar()
        Call Cargar_Grilla()
        Tab1.Tabs("T01").Selected = True
    End Sub

    Private Sub Limpiar()
        Dtp1.Value = Date.Today

        If Cbo1.Items.Count > 0 Then
            Cbo1.Value = ""
        End If
        Cbo2.Value = "K1"
        Txt4.Value = 0
        Txt5.Value = 0
        _Periodo = 0
        Call LimpiarDetalle()

        Ls_Anular = Nothing
        Ls_Detalle = Nothing
        Ls_LineaProduccion = Nothing
        Ls_Anular = New List(Of ETCosteoActivo)
        Ls_Detalle = New List(Of ETCosteoActivo)
        Ls_LineaProduccion = New List(Of ETLineaNegocio)
        Call CargarUltraGrid(Grid2, Ls_LineaProduccion)
        Call CargarUltraGrid(Grid3, Ls_Detalle)

    End Sub

    Private Sub LimpiarDetalle()
        Txt1.Clear()
        Txt2.Clear()
        Txt3.Value = 0
    End Sub

    Private Sub LlenarMeses()
        Dim i As Short = 1
        Cbo1.Items.Clear()
        If Year(Dtp1.Value) = Year(Date.Today) Then
            For i = 1 To Month(Date.Today)
                Dim Item As New Infragistics.Win.ValueListItem
                Item.DataValue = i
                Item.DisplayText = NameMes(i)
                Cbo1.Items.Add(Item)
            Next
        ElseIf Year(Dtp1.Value) < Year(Date.Today) Then
            For i = 1 To 12
                Dim Item1 As New Infragistics.Win.ValueListItem
                Item1.DataValue = i
                Item1.DisplayText = NameMes(i)
                Cbo1.Items.Add(Item1)
            Next
        End If

    End Sub

    Private Sub HabilitarControles(ByVal xBol As Boolean)
        Dtp1.ReadOnly = Not xBol
        Cbo1.ReadOnly = Not xBol
        Cbo2.ReadOnly = True
        Txt4.ReadOnly = Not xBol
        Txt5.ReadOnly = True
    End Sub

    Private Sub HabilitarControlesDetalle(ByVal xBol As Boolean)
        Txt1.ReadOnly = True
        Txt2.ReadOnly = True
        Txt3.ReadOnly = Not xBol
        Btn1.Enabled = True
        Btn2.Enabled = xBol
        Btn3.Enabled = Not xBol
        Btn4.Enabled = Not xBol
        Grid3.Enabled = xBol
    End Sub

    Private Sub InHabilitarControlesDetalle(ByVal xBol As Boolean)
        Txt1.ReadOnly = xBol
        Txt2.ReadOnly = xBol
        Txt3.ReadOnly = xBol
        Btn1.Enabled = Not xBol
        Btn2.Enabled = Not xBol
        Btn3.Enabled = Not xBol
        Btn4.Enabled = Not xBol
    End Sub

    Private Sub CargarLineaProduccion()
        Entidad.Periodo = New ETPeriodo
        Entidad.Periodo.Periodo = Me.Periodo
        Entidad.Periodo.Tipo = 4

        Ls_LineaProduccion = Nothing
        Ls_LineaProduccion = New List(Of ETLineaNegocio)
        Entidad.MyLista = New ETMyLista
        Negocio.PeriodoGasNatural = New NGPeriodoGasNatural
        Entidad.MyLista = Negocio.PeriodoGasNatural.Consultar_PeriodoGasNaturalLineaProduccion(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            Ls_LineaProduccion = Entidad.MyLista.Ls_PeriodoGasNaturalLineaProduccion
        End If
        Call CargarUltraGrid(Grid2, Ls_LineaProduccion)
    End Sub

    Private Sub Cargar_Detalle()
        Entidad.Periodo = New ETPeriodo
        Entidad.Periodo.Periodo = Me.Periodo
        Entidad.Periodo.Tipo = 4

        Ls_Anular = Nothing
        Ls_Anular = New List(Of ETCosteoActivo)

        Ls_Detalle = Nothing
        Ls_Detalle = New List(Of ETCosteoActivo)
        Entidad.MyLista = New ETMyLista
        Negocio.PeriodoGasNatural = New NGPeriodoGasNatural
        Entidad.MyLista = Negocio.PeriodoGasNatural.Consultar_PeriodoGasNatural(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            Ls_Detalle = Entidad.MyLista.Ls_PeriodoGasNatural
        End If
        Call CargarUltraGrid(Grid3, Ls_Detalle)
    End Sub

#End Region

#Region "Procedimientos Publicos"

    Public Sub Buscar()
        If Not (TipoGDet = eState.eNew OrElse TipoGDet = eState.eEdit) Then
            MsgBox("Debe Presionar antes el evento Nuevo o Modificar del detalle", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Catalogo_Activos
        frmHijo.ShowDialog()
        Txt1.Text = frmHijo.Flag2.Trim
        Txt2.Text = frmHijo.Descripcion.Trim
        Txt3.Focus()
        frmHijo = Nothing

    End Sub

    Public Sub Nuevo()
        TipoG = eState.eNew
        TipoGDet = eState.eView
        Call Limpiar()
        Call HabilitarControles(True)
        Call HabilitarControlesDetalle(False)
        Call CargarLineaProduccion()
        Tab1.Tabs("T02").Selected = True
        Dtp1.Focus()
    End Sub

    Public Sub Grabar()
        If Not (TipoG = eState.eNew OrElse TipoG = eState.eEdit) Then
            MsgBox("Debe Presionar antes el evento Nuevo o Modificar", MsgBoxStyle.Exclamation, msgComacsa)
        End If

        Txt4.EndUpdate()
        Txt5.EndUpdate()
        Grid2.UpdateData()
        Grid3.UpdateData()

        Entidad.Periodo = New ETPeriodo

        With Entidad.Periodo
            .Periodo = Me.Periodo
            .Anio = Year(Dtp1.Value)
            If Cbo1.Items.Count > 0 Then
                .Mes = Cbo1.Value
            End If
            .TipoPeriodo = ETPeriodo.sTipoPeriodo.CosteoGasNatural
            .ValorPeriodo = Txt4.Value
            .Valor2 = Txt5.Value
            .Status = IIf(Cbo2.Value = "K1", "", "*")
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With


        If Negocio.PeriodoGasNatural.Mantenedor_PeriodoGasNatural(Entidad.Periodo, Ls_Detalle, Ls_Anular, Ls_LineaProduccion) > 0 Then
            Call Inicio()
        End If
    End Sub

    Public Sub Modificar()
        If Grid1.Rows.Count <= 0 Then Return
        If Grid1.ActiveRow Is Nothing Then Return
        TipoG = eState.eEdit
        Call Limpiar()
        Call HabilitarControles(True)
        Call HabilitarControlesDetalle(False)
        Grid3.Enabled = True
        Periodo = Grid1.ActiveRow.Cells("Periodo").Value
        Me.Dtp1.Value = Mid(Date.Today.ToShortDateString, 1, 6) & Grid1.ActiveRow.Cells("Anio").Value
        Me.Cbo1.Value = Grid1.ActiveRow.Cells("Mes").Value
        Me.Txt4.Value = Grid1.ActiveRow.Cells("ValorPeriodo").Value
        Me.Txt5.Value = Grid1.ActiveRow.Cells("Valor2").Value
        If Grid1.ActiveRow.Cells("Status").Value = "*" Then
            Cbo2.Value = "K2"
        Else
            Cbo2.Value = "K1"
        End If
        Call CargarLineaProduccion()
        Call Cargar_Detalle()
        Tab1.Tabs("T02").Selected = True
    End Sub

    Public Sub Eliminar()
        If Grid1.Rows.Count <= 0 Then Return
        If Grid1.ActiveRow Is Nothing Then Return
        If Not (TipoG = eState.eView) Then Return

        Entidad.Periodo = New ETPeriodo
        With Entidad.Periodo
            .Periodo = Grid1.ActiveRow.Cells("Periodo").Value
            .Anio = Grid1.ActiveRow.Cells("Anio").Value
            .Mes = Grid1.ActiveRow.Cells("Mes").Value
            .MesName = Grid1.ActiveRow.Cells("MesName").Value
            .Status = "*"
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        If Negocio.PeriodoGasNatural.Mantenedor_PeriodoGasNatural(Entidad.Periodo, Nothing, Nothing, Nothing) > 0 Then
            Call Inicio()
        End If
    End Sub

    Public Sub Cancelar()
        If Tab1.Tabs("T03").Selected = True And Not (TipoGDet = eState.eView) = True Then
            Call LimpiarDetalle()
            Call HabilitarControlesDetalle(False)
            Grid3.Enabled = True
            TipoGDet = eState.eView

        Else
            If Not (TipoG = eState.eView) Then
                Call Inicio()
            End If
        End If

    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

#End Region

#Region "Formulario"

    Private Sub frmLCosteoGasNatural_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmLCosteoGasNatural_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
#End Region

#Region "DateTime"
    Private Sub Dtp1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp1.ValueChanged
        Call LlenarMeses()
    End Sub

#End Region

#Region "Grilla"
    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout, Grid3.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Anio" OrElse uColumn.Key = "MesName" _
                        OrElse uColumn.Key = "ValorPeriodo" OrElse uColumn.Key = "Valor2") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                        OrElse uColumn.Key = "Porcentaje") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Grid3 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                        OrElse uColumn.Key = "Cantidad") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

    End Sub

    Private Sub Grid2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid2.KeyDown
        Try
            Dim f As System.EventArgs = Nothing
            With Grid2
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(AboveCell, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Down
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(BelowCell, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Right
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(NextCellByTab, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Left
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(PrevCellByTab, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Return
                        .PerformAction(ExitEditMode, False, False)
                        e.Handled = True
                        .PerformAction(NextRow, False, False)
                        .ActiveRow.Cells("Porcentaje").Activate()
                        .PerformAction(EnterEditMode, False, False)
                End Select
            End With
        Catch
            Exit Sub
        End Try
    End Sub
#End Region

#Region "Botones"
    Private Sub Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click, Btn2.Click, Btn3.Click, Btn4.Click
        If sender Is Btn1 Then
            Call LimpiarDetalle()
            Call HabilitarControlesDetalle(True)
            TipoGDet = eState.eNew
            Txt1.Focus()
        End If

        If sender Is Btn2 Then
            If ValidarRegistro() = False Then
                Exit Sub
            End If

            If TipoGDet = eState.eNew Then
                Entidad.CosteoActivo = New ETCosteoActivo
                With Entidad.CosteoActivo
                    .Codigo = Txt1.Text.Trim
                    .Descripcion = Txt2.Text.Trim
                    .Cantidad = Txt3.Value
                    .Usuario = User_Sistema
                    .Tipo = TipoGDet
                End With

                Ls_Detalle.Add(Entidad.CosteoActivo)

                Call CargarUltraGrid(Grid3, Ls_Detalle)

            Else
                Grid3.ActiveRow.Cells("Codigo").Value = Txt1.Text.Trim
                Grid3.ActiveRow.Cells("Descripcion").Value = Txt2.Text.Trim
                Grid3.ActiveRow.Cells("Cantidad").Value = Txt3.Value
                Grid3.ActiveRow.Cells("Usuario").Value = User_Sistema
                Grid3.UpdateData()
            End If

            Txt5.Value = ConsumoGasNatEquipo()
            Call HabilitarControlesDetalle(False)
            Call LimpiarDetalle()
            TipoGDet = eState.eView
            Grid3.Enabled = True
        End If

        If sender Is Btn3 Then
            If Grid3.Rows.Count <= 0 Then
                MsgBox("No hay Detalle a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid3.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If


            TipoGDet = eState.eEdit
            Call LimpiarDetalle()
            Call HabilitarControlesDetalle(True)

            Txt1.Text = Grid3.ActiveRow.Cells("Codigo").Value
            Txt2.Text = Grid3.ActiveRow.Cells("Descripcion").Value
            Txt3.Value = Grid3.ActiveRow.Cells("Cantidad").Value
            Grid3.Enabled = False
        End If

        If sender Is Btn4 Then
            If Grid3.Rows.Count <= 0 Then
                MsgBox("No hay Detalle a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid3.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If MsgBox("Está seguro de Quitar el Equipo: " & Grid3.ActiveRow.Cells("Codigo").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            If Val(Grid3.ActiveRow.Cells("Tipo").Value) = 2 Then
                Entidad.CosteoActivo = New ETCosteoActivo
                With Entidad.CosteoActivo
                    .Codigo = Grid2.ActiveRow.Cells("Codigo").Value
                    .Usuario = User_Sistema
                    .Tipo = 3
                End With
                Ls_Anular.Add(Entidad.CosteoActivo)
            End If

            Grid3.ActiveRow.Delete(False)
            Grid3.UpdateData()

            Txt5.Value = ConsumoGasNatEquipo()

        End If
    End Sub
#End Region

#Region "Txt"
    Private Sub Txt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Btn2.Enabled = True Then Btn2.Focus()
        End If
    End Sub
#End Region

  
End Class