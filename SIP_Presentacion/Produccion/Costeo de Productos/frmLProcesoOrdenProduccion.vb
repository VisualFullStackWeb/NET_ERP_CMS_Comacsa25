Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows
Imports System.Windows.Forms
Imports System.Math
Imports System.Drawing
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmLProcesoOrdenProduccion

#Region "Declaraciones"

    Public L As Boolean = Boolean.FalseString
    Public vCargar As Boolean = Boolean.FalseString
    Public NroDocumento As String = String.Empty
    Private Ls_Orden As List(Of ETOrden) = Nothing
    Private uRow As UltraGridRow
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Enlace As List(Of ETProducto) = Nothing
    Private Ls_Activo As List(Of ETActivo) = Nothing
    Private Ls_Activo_Billete As List(Of ETOrden) = Nothing
    Private Ls_Activo_Billete_Detalle As List(Of ETOrden) = Nothing
    Private Ls_Personal As List(Of ETPersonal) = Nothing
    Private Ope As Integer
    Private _OrdenProduccion As Integer = 0
    Private _CodTurno As Short = 0
    Private ds_Activo As DataSet = Nothing
    Private Tbl_Activo1 As DataTable = Nothing
    Private Tbl_Activo2 As DataTable = Nothing
    Private _Cod_Activo As String = String.Empty
    Private _ChancadoraMyLista As ETMyLista = Nothing
    Private _Saltar_Cancel As Boolean = False
    Private Bucle As Boolean = Boolean.FalseString

    Private Enum Proceso
        Pesado = 118
        Chancado = 119
        Molienda_Confirmacion = 121
        Molienda_IngresoProduccion = 122
        Envasado = 123
        Laboratorio = 124
        Almacenado = 125
        DespachoProdTerminado = 126
    End Enum

    Private Enum Evento
        Clear = 0
        Nuevo = 1
        Edit = 2
        Delete = 3
        View = 4
    End Enum
    Private TipoProceso As Proceso
    Private TipoG As Evento

    Public Property OrdenProduccion() As Integer
        Get
            Return _OrdenProduccion
        End Get
        Set(ByVal value As Integer)
            _OrdenProduccion = value
        End Set
    End Property

#End Region

#Region "Eventos"

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

        AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Orden IsNot Nothing Then Ls_Orden = Nothing
        If Ls_Enlace IsNot Nothing Then Ls_Enlace = Nothing
        If Ls_Activo IsNot Nothing Then Ls_Activo = Nothing
        If Ls_Activo_Billete IsNot Nothing Then Ls_Activo_Billete = Nothing
        If Ls_Personal IsNot Nothing Then Ls_Personal = Nothing
        If Ls_Activo_Billete_Detalle IsNot Nothing Then Ls_Activo_Billete = Nothing

        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Gbp1.Expanded = Boolean.FalseString
        Gbp1.Enabled = Boolean.TrueString
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Dt1.Value = DBNull.Value
        Dt2.Value = DBNull.Value

    End Sub
    Sub Cargar_Molinos_IngProd()
        Ls_Activo_Billete = Nothing
        Ls_Activo_Billete = New List(Of ETOrden)
        Call CargarUltraGrid(Grid12, Ls_Activo_Billete)

        Ls_Activo = Nothing
        Ls_Activo = New List(Of ETActivo)
        Ls_Activo = Negocio.Orden.ConsultarOrden13(Entidad.Orden)
        Call CargarUltraCombo(Cbo2, Ls_Activo, "Placa", "Descripcion")

    End Sub

    Sub CargarIngresoProduccion()
        TipoG = Evento.View
        Dim O As New ETOrden
        Entidad.MyLista = New ETMyLista
        Ls_Activo_Billete = Nothing
        Ls_Activo_Billete = New List(Of ETOrden)

        O.ID = _OrdenProduccion
        O.CodMolino = Cbo2.Value
        O.Cod_Alm = strAlmacen
        Negocio.Orden = New NGOrden
        Entidad.MyLista = Negocio.Orden.Consultar_Orden_Molienda_IngresoProd(O)
        If Entidad.MyLista.Validacion Then Ls_Activo_Billete = Entidad.MyLista.Ls_Orden
        Call CargarUltraGrid(Grid12, Ls_Activo_Billete)

    End Sub
    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()

    End Sub


    Sub Evento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid6.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid6) Then Return
        If sender Is Grid6 Then
            If Grid6.ActiveRow Is Nothing Then Return
            If Grid6.ActiveRow.Band.Index = 0 Then
                TipoG = Evento.Clear
                Call LimpiarDatosActivo()
                Call HabilitarDatosActivo(False)
            End If
        End If


    End Sub

    Private Sub Evento_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid11.AfterCellUpdate
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Dim Saldo As Decimal = Decimal.Zero

        If sender Is Grid11 Then
            If e.Cell.Column.Key = "Cantidad" Then
                Call Sumar_Cantidad_a_Molienda()
            ElseIf e.Cell.Column.Key = "Action" Then
                If e.Cell.Value = Boolean.FalseString Then
                    e.Cell.Row.Cells("Cantidad").Value = 0
                Else
                    Grid11.UpdateData()
                    Call Sumar_Cantidad_a_Molienda()
                    Saldo = Num16.Value - Num17.Value
                    If Saldo > 0 Then
                        e.Cell.Row.Cells("Cantidad").Value = Saldo
                    End If
                End If
            End If
        End If


    End Sub

    Sub Evento_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles Grid11.BeforeCellUpdate, Grid12.BeforeCellUpdate
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Dim Saldo As Decimal = Decimal.Zero

        If sender Is Grid11 Then
            If e.Cell.Column.Key = "Cantidad" Then
                If e.Cell.Row.Cells("Action").Value = Boolean.FalseString Then
                    If _Saltar_Cancel = False Then
                        e.Cancel = True
                    Else
                        _Saltar_Cancel = False
                    End If
                ElseIf Val(e.NewValue) < 0 Then
                    e.Cancel = True
                ElseIf (Val(Num17.Value) + Val(e.NewValue) - Val(e.Cell.Value)) > Val(Num16.Value) Then
                    e.Cancel = True
                End If
            ElseIf e.Cell.Column.Key = "Action" Then
                If e.NewValue = Boolean.FalseString Then
                    _Saltar_Cancel = True
                End If
                Grid11.UpdateData()
            End If
        End If

        If sender Is Grid12 Then
            If e.Cell.Column.Key = "HorasTrabajadas" Then
                If Val(e.NewValue) > Val(e.Cell.Row.Cells("HorasMax").Value) OrElse Val(e.NewValue) < 0 Then
                    e.Cancel = True
                End If
            ElseIf e.Cell.Column.Key = "Cantidad" Then
                If Val(e.NewValue) < 0 Then
                    e.Cancel = True
                End If

            End If
        End If

    End Sub
    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Grid1.KeyDown, Grid6.KeyDown, Grid9.KeyDown, Grid11.KeyDown, Grid12.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid1 OrElse sender Is Grid6 OrElse sender Is Grid9 OrElse sender Is Grid11 OrElse sender Is Grid12) Then Return

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
                    .PerformAction(NextCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
            End Select
        End With

    End Sub
    Sub LimpiarMolinoConfirmarIndividual()
        Ls_Activo = Nothing
        Ls_Activo_Billete = Nothing
        Ls_Activo_Billete_Detalle = Nothing

        Ls_Activo = New List(Of ETActivo)
        Ls_Activo_Billete = New List(Of ETOrden)
        Ls_Activo_Billete_Detalle = New List(Of ETOrden)
        Txt4.Clear()
        Txt5.Clear()
        Txt6.Clear()
        Txt7.Clear()
        Txt4.Tag = ""
        Txt5.Tag = ""
        Txt6.Tag = ""
        Txt7.Tag = ""
        Num16.Value = 0
        Num17.Value = 0
        Grbe2.Expanded = False
        Call CargarUltraGrid(Grid10, Ls_Activo_Billete)
        Call CargarUltraGrid(Grid11, Ls_Activo)

    End Sub
    Sub Evento_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid9.ClickCellButton, Grid12.ClickCellButton

        If sender Is Nothing OrElse e Is Nothing Then Return

        If sender Is Grid9 Then
            If e.Cell.Column.Key = "Confirmar" Then
                _Saltar_Cancel = False
                Call Cargar_DatosActivo_Molino(e.Cell.Row)
                Call Cargar_Orden_Unidad()
                Grbe2.Expanded = False
                Tab4.Tabs("T02").Enabled = True
                Tab4.Tabs("T02").Selected = True
            End If

        End If

        If sender Is Grid12 Then
            'lResult = Consultar_Operarios(e.Cell.Row.Cells("Fecha").Value, Cbo1.Value, Turno, StrucActivos.CodClase, StrucActivos.Molino)
        End If
    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles Cbo1.InitializeLayout, Cbo2.InitializeLayout, Grid1.InitializeLayout, Grid2.InitializeLayout, Grid6.InitializeLayout, Grid7.InitializeLayout, Grid8.InitializeLayout, Grid9.InitializeLayout, Grid10.InitializeLayout, Grid11.InitializeLayout, Grid12.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Cbo1 OrElse sender Is Cbo2 OrElse sender Is Grid1 OrElse sender Is Grid2 OrElse sender Is Grid6 OrElse sender Is Grid7 OrElse sender Is Grid8 OrElse sender Is Grid9 OrElse sender Is Grid10 OrElse sender Is Grid11 OrElse sender Is Grid12) Then Return

        If sender Is Cbo1 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If uColumn.Key = "Placa" Then
                    uColumn.Header.Caption = "Código"
                    uColumn.MinWidth = 50
                    uColumn.MaxWidth = 50
                    uColumn.Hidden = Boolean.FalseString
                ElseIf uColumn.Key = "Descripcion" Then
                    uColumn.Hidden = Boolean.FalseString
                    uColumn.Header.Caption = "Descripción"
                    uColumn.MaxWidth = 0
                    If (uColumn.Width - 50) > 100 Then
                        uColumn.MinWidth = uColumn.Width - 50
                    Else
                        uColumn.MinWidth = 100
                    End If
                Else
                    uColumn.Hidden = Boolean.TrueString
                End If
            Next
        End If

        If sender Is Cbo2 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If uColumn.Key = "Placa" Then
                    uColumn.Header.Caption = "Código"
                    uColumn.MinWidth = 50
                    uColumn.MaxWidth = 50
                    uColumn.Hidden = Boolean.FalseString
                ElseIf uColumn.Key = "Cantidad" Then
                    uColumn.MinWidth = 80
                    uColumn.MaxWidth = 80
                    uColumn.Hidden = Boolean.FalseString
                ElseIf uColumn.Key = "Descripcion" Then
                    uColumn.Hidden = Boolean.FalseString
                    uColumn.Header.Caption = "Molino"
                    If (uColumn.Width - 130) > 100 Then
                        uColumn.MinWidth = uColumn.Width - 130
                    Else
                        uColumn.MinWidth = 100
                    End If
                    'uColumn.MaxWidth = uColumn.MinWidth
                Else
                    uColumn.Hidden = Boolean.TrueString
                End If
            Next
        End If

        If sender Is Grid8 Or sender Is Grid10 Then
            sender.DisplayLayout.Bands(0).Summaries.Clear()
            sender.DisplayLayout.Bands(0).SummaryFooterCaption = ""

            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "NroDocumento" OrElse uColumn.Key = "CodRuma" OrElse _
                        uColumn.Key = "DesRuma" OrElse uColumn.Key = "CodProducto" OrElse _
                        uColumn.Key = "Descripcion" OrElse uColumn.Key = "Cantidad") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    If uColumn.Key = "Cantidad" Then
                        With sender.DisplayLayout.Bands(0).Summaries
                            .Add("Sumary1", SummaryType.Sum, uColumn, SummaryPosition.UseSummaryPositionColumn)
                            .Item("Sumary1").Appearance.BackColor = Color.LightYellow
                            .Item("Sumary1").Appearance.ForeColor = Color.Red
                            .Item("Sumary1").Appearance.FontData.Bold = DefaultableBoolean.True
                            .Item("Sumary1").Appearance.TextHAlign = HAlign.Right
                            .Item("Sumary1").DisplayFormat = "{0:N4}"
                        End With
                    End If
                    uColumn.Hidden = Boolean.FalseString
                End If
                uColumn.CellActivation = Activation.ActivateOnly
            Next
        End If

        If sender Is Grid7 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Action" OrElse uColumn.Key = "CodPersonal" OrElse _
                        uColumn.Key = "DesPersonal" OrElse uColumn.Key = "DesTurno") Then
                    uColumn.Hidden = Boolean.TrueString
                    uColumn.CellActivation = Activation.ActivateOnly
                Else
                    If uColumn.Key = "Action" Then
                        If TipoG = Evento.Nuevo OrElse TipoG = Evento.Edit Then
                            uColumn.CellActivation = Activation.AllowEdit
                        Else
                            uColumn.CellActivation = Activation.ActivateOnly
                        End If
                    Else
                        uColumn.CellActivation = Activation.ActivateOnly
                    End If
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If


        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "NroDocumento" OrElse uColumn.Key = "Descripcion" OrElse _
                        uColumn.Key = "CodProducto" OrElse uColumn.Key = "Fecha" OrElse _
                        uColumn.Key = "DesStatus") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Grid12 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Lote" OrElse uColumn.Key = "NroDocumento" OrElse _
                        uColumn.Key = "NroOpe" OrElse _
                        uColumn.Key = "Cod_Alm" OrElse uColumn.Key = "Cantidad" OrElse _
                        uColumn.Key = "UnidProd" OrElse uColumn.Key = "NroInicio" OrElse _
                        uColumn.Key = "NroTermino" OrElse uColumn.Key = "HorasTrabajadas" OrElse _
                        uColumn.Key = "HorasParada") Then
                    uColumn.Hidden = Boolean.TrueString
                    uColumn.CellActivation = Activation.ActivateOnly
                Else
                    If Not (TipoG = Evento.Nuevo OrElse TipoG = Evento.Edit) Then
                        If uColumn.Key = "Cantidad" Then
                            uColumn.CellActivation = Activation.ActivateOnly
                        ElseIf uColumn.Key = "HorasTrabajadas" OrElse _
                            uColumn.Key = "HorasParada" OrElse uColumn.Key = "NroOpe" Then
                            uColumn.CellActivation = Activation.NoEdit
                        End If
                    Else
                        If uColumn.Key = "Cantidad" Then
                            uColumn.CellActivation = Activation.AllowEdit
                        ElseIf uColumn.Key = "HorasTrabajadas" OrElse _
                            uColumn.Key = "HorasParada" OrElse uColumn.Key = "NroOpe" Then
                            uColumn.CellActivation = Activation.AllowEdit
                        End If
                    End If
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If


        If sender Is Grid11 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" OrElse _
                        uColumn.Key = "Action" OrElse uColumn.Key = "Cantidad") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    If uColumn.Key = "Cantidad" OrElse uColumn.Key = "Action" Then
                        If Not (TipoG = Evento.Nuevo OrElse TipoG = Evento.Edit) Then
                            uColumn.CellActivation = Activation.ActivateOnly
                        Else
                            uColumn.CellActivation = Activation.AllowEdit
                        End If
                    End If
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If


        If sender Is Grid2 Then
            Grid2.DisplayLayout.Bands(0).Summaries.Clear()
            Grid2.DisplayLayout.Bands(0).SummaryFooterCaption = ""

            Grid2.DisplayLayout.Bands(1).Summaries.Clear()
            Grid2.DisplayLayout.Bands(1).SummaryFooterCaption = ""

            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                Select Case xCol.Key
                    Case "CodRuma"
                        xCol.Header.Caption = "Código"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "DesRuma"
                        xCol.Header.Caption = "Ruma"
                        xCol.MinWidth = 350
                        xCol.CellActivation = Activation.ActivateOnly

                    Case "Cantidad"
                        xCol.Header.Caption = "Cant.TON"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.Format = "n3"
                        With Grid2.DisplayLayout.Bands(0).Summaries
                            .Add("Sumary1", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                            .Item("Sumary1").Appearance.BackColor = Color.LightYellow
                            .Item("Sumary1").Appearance.ForeColor = Color.Red
                            .Item("Sumary1").Appearance.FontData.Bold = DefaultableBoolean.True
                            .Item("Sumary1").Appearance.TextHAlign = HAlign.Right
                            .Item("Sumary1").DisplayFormat = "{0:N3}"
                        End With

                    Case "CantidadxNecesaria"
                        xCol.Header.Caption = "Cant.Req"
                        xCol.MinWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.Format = "n3"
                        With Grid2.DisplayLayout.Bands(0).Summaries
                            .Add("Sumary2", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                            .Item("Sumary2").Appearance.BackColor = Color.LightYellow
                            .Item("Sumary2").Appearance.ForeColor = Color.Red
                            .Item("Sumary2").Appearance.FontData.Bold = DefaultableBoolean.True
                            .Item("Sumary2").Appearance.TextHAlign = HAlign.Right
                            .Item("Sumary2").DisplayFormat = "{0:N3}"
                        End With
                    Case Else
                        xCol.Hidden = True
                        xCol.CellActivation = Activation.NoEdit
                End Select
                xCol.Header.Appearance.TextHAlign = HAlign.Center
            Next

            For Each xCol As UltraGridColumn In e.Layout.Bands(1).Columns
                Select Case xCol.Key
                    Case "Codigo"
                        xCol.Header.Caption = "Código"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Descripcion"
                        xCol.Header.Caption = "Mineral"
                        xCol.MinWidth = 150
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Billete"
                        xCol.Header.Caption = "Billete"
                        xCol.MinWidth = 100
                        xCol.MaxWidth = 100
                        xCol.CellActivation = Activation.ActivateOnly
                        xCol.CellAppearance.TextHAlign = HAlign.Center
                    Case "Cantidad"
                        xCol.Header.Caption = "Cant.TON"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.Format = "n3"
                        With Grid2.DisplayLayout.Bands(1).Summaries
                            .Add("Sumary3", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                            .Item("Sumary3").Appearance.BackColor = Color.LightYellow
                            .Item("Sumary3").Appearance.ForeColor = Color.Red
                            .Item("Sumary3").Appearance.FontData.Bold = DefaultableBoolean.True
                            .Item("Sumary3").Appearance.TextHAlign = HAlign.Right
                            .Item("Sumary3").DisplayFormat = "{0:N3}"
                        End With
                    Case "CantidadxNecesaria"
                        xCol.Header.Caption = "Cant.Req"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.Format = "n3"
                        With Grid2.DisplayLayout.Bands(1).Summaries
                            .Add("Sumary4", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                            .Item("Sumary4").Appearance.BackColor = Color.LightYellow
                            .Item("Sumary4").Appearance.ForeColor = Color.Red
                            .Item("Sumary4").Appearance.FontData.Bold = DefaultableBoolean.True
                            .Item("Sumary4").Appearance.TextHAlign = HAlign.Right
                            .Item("Sumary4").DisplayFormat = "{0:N3}"
                        End With
                    Case Else
                        xCol.Hidden = True
                        xCol.CellActivation = Activation.NoEdit
                End Select
                xCol.Header.Appearance.TextHAlign = HAlign.Center
            Next
        End If

        If sender Is Grid6 Then
            sender.DisplayLayout.Bands(0).Summaries.Clear()
            sender.DisplayLayout.Bands(0).SummaryFooterCaption = ""

            sender.DisplayLayout.Bands(1).Summaries.Clear()
            sender.DisplayLayout.Bands(1).SummaryFooterCaption = ""

            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                Select Case xCol.Key
                    Case "Fecha"
                        xCol.MinWidth = 65
                        xCol.MaxWidth = 65
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Cod_Chancadora"
                        xCol.Header.Caption = "Código"
                        xCol.MinWidth = 50
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Chancadora"
                        xCol.MinWidth = 100
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Cantidad"
                        xCol.Header.Caption = "Cant.TON"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.Format = "n3"
                        With sender.DisplayLayout.Bands(0).Summaries
                            .Add("Sumary1", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                            .Item("Sumary1").Appearance.BackColor = Color.LightYellow
                            .Item("Sumary1").Appearance.ForeColor = Color.Red
                            .Item("Sumary1").Appearance.FontData.Bold = DefaultableBoolean.True
                            .Item("Sumary1").Appearance.TextHAlign = HAlign.Right
                            .Item("Sumary1").DisplayFormat = "{0:N3}"
                        End With
                    Case Else
                        xCol.Hidden = True
                        xCol.CellActivation = Activation.NoEdit
                End Select
                xCol.Header.Appearance.TextHAlign = HAlign.Center
            Next

            For Each xCol As UltraGridColumn In e.Layout.Bands(1).Columns
                Select Case xCol.Key
                    Case "CodRuma"
                        xCol.Header.Caption = "Cod.Ruma"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "DesRuma"
                        xCol.Header.Caption = "Ruma"
                        xCol.MinWidth = 150
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Codigo"
                        xCol.Header.Caption = "Código"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Descripcion"
                        xCol.Header.Caption = "Mineral"
                        xCol.MinWidth = 150
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Billete"
                        xCol.Header.Caption = "Billete"
                        xCol.MinWidth = 100
                        xCol.MaxWidth = 100
                        xCol.CellActivation = Activation.ActivateOnly
                        xCol.CellAppearance.TextHAlign = HAlign.Center
                    Case "Cantidad"
                        xCol.Header.Caption = "Cant.TON"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.Format = "n3"
                        With sender.DisplayLayout.Bands(1).Summaries
                            .Add("Sumary3", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                            .Item("Sumary3").Appearance.BackColor = Color.LightYellow
                            .Item("Sumary3").Appearance.ForeColor = Color.Red
                            .Item("Sumary3").Appearance.FontData.Bold = DefaultableBoolean.True
                            .Item("Sumary3").Appearance.TextHAlign = HAlign.Right
                            .Item("Sumary3").DisplayFormat = "{0:N3}"
                        End With
                    Case Else
                        xCol.Hidden = True
                        xCol.CellActivation = Activation.NoEdit
                End Select
                xCol.Header.Appearance.TextHAlign = HAlign.Center
            Next
        End If

        If sender Is Grid9 Then
            sender.DisplayLayout.Bands(0).Summaries.Clear()
            sender.DisplayLayout.Bands(0).SummaryFooterCaption = ""

            sender.DisplayLayout.Bands(1).Summaries.Clear()
            sender.DisplayLayout.Bands(1).SummaryFooterCaption = ""

            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                Select Case xCol.Key
                    Case "Cod_Chancadora"
                        xCol.Header.Caption = "Cód.Chanc"
                        xCol.MinWidth = 40
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Chancadora"
                        xCol.MinWidth = 100
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "NumDoc"
                        xCol.Header.Caption = "Billete"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                        xCol.CellAppearance.TextHAlign = HAlign.Center
                    Case "Cod_Molino"
                        xCol.Header.Caption = "Cód.Mol"
                        xCol.MinWidth = 40
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Molino"
                        xCol.MinWidth = 100
                        xCol.CellActivation = Activation.ActivateOnly

                    Case "CodRuma"
                        xCol.Header.Caption = "Cód.Ruma"
                        xCol.MinWidth = 70
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Ruma"
                        xCol.MinWidth = 120
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Cantidad"
                        xCol.Header.Caption = "Cant.TON"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.Format = "n4"
                        With sender.DisplayLayout.Bands(0).Summaries
                            .Add("Sumary1", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                            .Item("Sumary1").Appearance.BackColor = Color.LightYellow
                            .Item("Sumary1").Appearance.ForeColor = Color.Red
                            .Item("Sumary1").Appearance.FontData.Bold = DefaultableBoolean.True
                            .Item("Sumary1").Appearance.TextHAlign = HAlign.Right
                            .Item("Sumary1").DisplayFormat = "{0:N4}"
                        End With
                    Case "Action"
                        xCol.Header.Caption = ""
                        xCol.MinWidth = 17
                        xCol.MaxWidth = 17
                        If (TipoG = Evento.Nuevo OrElse TipoG = Evento.Edit) Then
                            xCol.CellActivation = Activation.AllowEdit
                        Else
                            xCol.CellActivation = Activation.Disabled
                        End If
                    Case "Confirmar"
                        xCol.MinWidth = 65
                        xCol.Hidden = False
                        xCol.Style = UltraWinGrid.ColumnStyle.Button
                        xCol.CellAppearance.BackColor = Color.LightGreen
                        If (TipoG = Evento.Nuevo OrElse TipoG = Evento.Edit) Then
                            xCol.CellActivation = Activation.AllowEdit
                        Else
                            xCol.CellActivation = Activation.Disabled
                        End If
                    Case Else
                        xCol.Hidden = True
                        xCol.CellActivation = Activation.NoEdit
                End Select
                xCol.Header.Appearance.TextHAlign = HAlign.Center
            Next

            For Each xCol As UltraGridColumn In e.Layout.Bands(1).Columns
                Select Case xCol.Key
                    Case "CodMineral"
                        xCol.Header.Caption = "Cod. Mineral"
                        xCol.MinWidth = 100
                        xCol.MaxWidth = 100
                        xCol.CellActivation = Activation.ActivateOnly
                    Case "Mineral"
                        xCol.Header.Caption = "Mineral"
                        xCol.MinWidth = 300
                        xCol.CellActivation = Activation.ActivateOnly

                    Case "Cantidad"
                        xCol.Header.Caption = "Cant.TON"
                        xCol.MinWidth = 80
                        xCol.MaxWidth = 80
                        xCol.CellActivation = Activation.ActivateOnly
                        xCol.CellAppearance.TextHAlign = HAlign.Right
                        xCol.Format = "n4"
                        With sender.DisplayLayout.Bands(1).Summaries
                            .Add("Sumary2", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                            .Item("Sumary2").Appearance.BackColor = Color.LightYellow
                            .Item("Sumary2").Appearance.ForeColor = Color.Red
                            .Item("Sumary2").Appearance.FontData.Bold = DefaultableBoolean.True
                            .Item("Sumary2").Appearance.TextHAlign = HAlign.Right
                            .Item("Sumary2").DisplayFormat = "{0:N4}"
                        End With
                    Case Else
                        xCol.Hidden = True
                        xCol.CellActivation = Activation.NoEdit
                End Select
                xCol.Header.Appearance.TextHAlign = HAlign.Center
            Next
        End If
    End Sub

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow, Grid6.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid1 OrElse sender Is Grid6) Then Return

        If sender Is Grid1 Then
            If e.Row.IsFilterRow Then Return
            Call Cargar_Orden(e.Row)
        End If

        If sender Is Grid6 Then
            If Grid6.ActiveRow Is Nothing Then Return
            If Grid6.ActiveRow.Band.Index = 0 Then
                TipoG = Evento.View
                Call LimpiarDatosActivo()
                Call HabilitarDatosActivo(False)
                Call Cargar_DatosActivo_Chancadora(e.Row)
                Call Cargar_Confirmacion_Chancadora()
                Tab3.Tabs("T02").Enabled = True
                Tab3.Tabs("T02").Selected = True
            End If
        End If

    End Sub

    Sub Evento_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _
                        Txt1.KeyPress, Txt2.KeyPress

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Txt1 Then

            If Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57 OrElse Asc(e.KeyChar) = Keys.Back Then
                e.Handled = Boolean.FalseString
            Else
                e.Handled = Boolean.TrueString
            End If
            Return

        End If

        If sender Is Txt2 Then

            If Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57 OrElse _
                Asc(e.KeyChar) = 80 OrElse Asc(e.KeyChar) = 112 OrElse _
                Asc(e.KeyChar) = Keys.Back Then
                e.Handled = Boolean.FalseString
            Else
                e.Handled = Boolean.TrueString
            End If
            Return

        End If

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) Handles Grid1.InitializeRow, Grid6.InitializeRow, Grid8.InitializeRow, Grid9.InitializeRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid1 OrElse sender Is Grid6 OrElse sender Is Grid8 OrElse sender Is Grid9) Then Return

        If sender Is Grid1 Then
            With e.Row.Cells("Status")
                Select Case .Value
                    Case "*"
                        e.Row.Cells("DesStatus").Value = "ANULADO"
                    Case "R"
                        e.Row.Cells("DesStatus").Value = "RECIRCULADO"
                    Case "P"
                        e.Row.Cells("DesStatus").Value = "PESADO"
                    Case "H"
                        e.Row.Cells("DesStatus").Value = "CHANCADO"
                    Case "M"
                        e.Row.Cells("DesStatus").Value = "MOLIENDA"
                    Case "E"
                        e.Row.Cells("DesStatus").Value = "ENVASADO"
                    Case "L"
                        e.Row.Cells("DesStatus").Value = "LABORATORIO"
                    Case "A"
                        e.Row.Cells("DesStatus").Value = "ALMACEN"
                    Case "D"
                        e.Row.Cells("DesStatus").Value = "DESPACHO"
                    Case "C"
                        e.Row.Cells("DesStatus").Value = "CERRADO"
                    Case Else
                        e.Row.Cells("DesStatus").Value = "ACTIVO"
                End Select

            End With

        End If

        If sender Is Grid6 OrElse sender Is Grid8 OrElse sender Is Grid9 Then
            If e.Row.Band.Index = 0 Then
                If Val(e.Row.Cells("Nuevo").Value) <> Val(e.Row.Cells("Contar").Value) Then
                    e.Row.CellAppearance.BackColor = Color.LightGreen
                ElseIf Val(e.Row.Cells("Nuevo").Value) > 0 Then
                    e.Row.CellAppearance.BackColor = Color.LightYellow

                End If
            Else
                If Val(e.Row.Cells("Nuevo").Value) > 0 Then
                    e.Row.CellAppearance.BackColor = Color.LightYellow
                End If
            End If
        End If
    End Sub

#End Region

#Region "Procedimientos"

    Sub LimpiarDatosActivo()
        Dt3.Value = DBNull.Value

        Txt3.Clear()
        Txt3.Tag = ""

        Num1.Value = 0
        Num2.Value = 0
        Num3.Value = 0
        Num4.Value = 0
        Num5.Value = 0
        Num6.Value = 0
        Num7.Value = 0
        Num8.Value = 0
        Num9.Value = 0
        Num10.Value = 0
        Num11.Value = 0
        Num12.Value = 0
        Num13.Value = 0
        Num14.Value = 0
        Num15.Value = 0
        Chk1.Checked = False
        Chk2.Checked = False
        Chk3.Checked = False
        Chk4.Checked = False
        Grbe1.Expanded = False
        Cbo1.Value = ""
        Ls_Personal = Nothing
        Ls_Personal = New List(Of ETPersonal)
        Call CargarUltraGrid(Grid7, Ls_Personal)
        Ls_Activo_Billete = Nothing
        Ls_Activo_Billete = New List(Of ETOrden)
        _ChancadoraMyLista = Nothing
        _ChancadoraMyLista = New ETMyLista
        Call CargarUltraGrid(Grid8, Ls_Activo_Billete)

    End Sub

    Sub HabilitarDatosActivo(ByVal xBol As Boolean)
        Cbo1.ReadOnly = Not xBol
        Grb4.Enabled = xBol

        If xBol = True Then
            Grid7.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.AllowEdit
        Else
            Grid7.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.ActivateOnly
        End If
    End Sub

    Sub HabilitarConfirmacionMolino(ByVal xBol As Boolean)
        If Tab4.Tabs("T01").Selected = True Then
            If xBol = True Then
                Grid9.DisplayLayout.Bands(0).Columns("Confirmar").CellActivation = Activation.AllowEdit
                Grid9.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.AllowEdit
            Else
                Grid9.DisplayLayout.Bands(0).Columns("Confirmar").CellActivation = Activation.NoEdit
                Grid9.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.NoEdit
            End If
        Else
            If xBol = True Then
                Grid11.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.AllowEdit
                Grid11.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Activation.AllowEdit
            Else
                Grid11.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.ActivateOnly
                Grid11.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Activation.ActivateOnly
            End If
        End If
        
    End Sub

    Sub HabilitarMolino_Ingreso_Produccion(ByVal xBol As Boolean)
        If xBol = True Then
            With Grid12.DisplayLayout.Bands(0)
                .Columns("Cantidad").CellActivation = Activation.AllowEdit
                .Columns("HorasTrabajadas").CellActivation = Activation.AllowEdit
                .Columns("HorasParada").CellActivation = Activation.AllowEdit
                .Columns("NroOpe").CellActivation = Activation.AllowEdit
            End With

        Else
            With Grid12.DisplayLayout.Bands(0)
                .Columns("Cantidad").CellActivation = Activation.ActivateOnly
                .Columns("HorasTrabajadas").CellActivation = Activation.NoEdit
                .Columns("HorasParada").CellActivation = Activation.NoEdit
                .Columns("NroOpe").CellActivation = Activation.NoEdit
            End With
        End If
       

    End Sub

    

    Sub Iniciar()

        Entidad.MyLista = New ETMyLista
        Negocio.Orden = New NGOrden

        Entidad.MyLista = Negocio.Orden.ConsultarOrden1()

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Orden = New List(Of ETOrden)
        Ls_Orden = Entidad.MyLista.Ls_Orden

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Orden)

        TipoProceso = Val(Tag)

        Select Case TipoProceso
            Case Proceso.Pesado
                Tab1.Tabs("T03").Visible = True
                Tab2.Tabs("T01").Selected = True
            Case Proceso.Chancado
                Tab1.Tabs("T04").Visible = True
                Tab3.Tabs("T01").Selected = True
            Case Proceso.Molienda_Confirmacion
                Tab1.Tabs("T05").Visible = True
                Tab4.Tabs("T01").Selected = True
                Tab4.Tabs("T03").Visible = False
            Case Proceso.Molienda_IngresoProduccion
                Call ListarAlmacenUsuarios(Cbo3, strAlmacen)
                Tab1.Tabs("T05").Visible = True
                Tab4.Tabs("T01").Visible = False
                Tab4.Tabs("T02").Visible = False
                Tab4.Tabs("T03").Selected = True
        End Select
        TipoG = Evento.View
    End Sub
    Sub Sumar_Cantidad_a_Molienda()
        Dim Suma As Decimal = Decimal.Zero

        For Each xRow As UltraGridRow In Grid11.Rows
            If xRow.Cells("Action").Value = Boolean.TrueString Then
                Suma = Suma + xRow.Cells("Cantidad").Value
            End If
        Next

        Num17.Value = Suma
    End Sub
    Sub Cargar_Orden(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        vCargar = Boolean.TrueString

        NroDocumento = uRow.Cells("NroDocumento").Value
        _OrdenProduccion = uRow.Cells("ID").Value

        Entidad.Orden.NroDocumento = NroDocumento
        Entidad.Orden.ID = _OrdenProduccion
        Entidad.MyLista = New ETMyLista

        Entidad.MyLista = Negocio.Orden.ConsultarOrden2(Entidad.Orden)

        If Entidad.MyLista.Validacion Then Entidad.Orden = Entidad.MyLista.Ls_Orden.First()

        Ls_Enlace = New List(Of ETProducto)
        Entidad.Producto.CodProducto = Entidad.Orden.CodProducto
        Ls_Enlace = Negocio.Producto.ConsultarEnlacexProducto(Entidad.Producto)
        Call CargarUltraCombo(CboOP1, Ls_Enlace, "ID", "ID")

        CboOP1.Value = Entidad.Orden.CodEnlace
        txtOP1.Value = Entidad.Orden.NroDocumento
        DtpOP1.Value = Entidad.Orden.Fecha
        DtpOP2.Value = IIf(Entidad.Orden.FechaActualizacion = FechaMinimaBD OrElse _
                        Not IsDate(Entidad.Orden.FechaActualizacion), DBNull.Value, Entidad.Orden.FechaActualizacion)
        txtOP2.Value = Entidad.Orden.CodProducto
        txtOP3.Value = Entidad.Orden.Descripcion
        NumOP1.Value = Entidad.Orden.Cantidad
        NumOP2.Value = Entidad.Orden.CantidadRequerida
        NumOP3.Value = Entidad.Orden.CantidadRequerida - Entidad.Orden.CantidadRecirculado
        NumOP4.Value = Entidad.Orden.Cantidad

        DtpOP3.Value = Entidad.Orden.FechaIngreso
        txtOP4.Value = Entidad.Orden.Especificaciones
        ChkOP1.Checked = Entidad.Orden.FormulaRecirculado
        If String.IsNullOrEmpty(Entidad.Orden.Status.Trim()) Then
            CboOP2.Value = "P"
        Else
            CboOP2.Value = Entidad.Orden.Status
        End If
        TipoG = Evento.View
        Select Case TipoProceso
            Case Proceso.Pesado
                Call Cargar_Pesado()
                Tab1.Tabs("T03").Selected = True
            Case Proceso.Chancado
                Call LimpiarDatosActivo()
                Call Cargar_Orden_Unidad()
                Call Cargar_Chancadora_Pesado()
                Tab1.Tabs("T04").Selected = True
            Case Proceso.Molienda_Confirmacion
                Call LimpiarMolinoConfirmarIndividual()
                Call HabilitarConfirmacionMolino(False)
                Call Cargar_Chancadora_Molino()
                Tab1.Tabs("T05").Selected = True
                Tab4.Tabs("T01").Selected = True
            Case Proceso.Molienda_IngresoProduccion
                Call Cargar_Molinos_IngProd()
                Tab1.Tabs("T05").Selected = True
        End Select

    End Sub

    Sub Cargar_Pesado()
        Dim ds As New DataSet
        ds = Negocio.Orden.Consultar_Orden_PesajeRuma(Entidad.Orden)

        Grid2.DataSource = Nothing

        Dim ColPk1 As DataColumn = ds.Tables(0).Columns("CodRuma")
        Dim ColPk2 As DataColumn = ds.Tables(1).Columns("CodRuma")

        Dim DtRelacion As DataRelation
        DtRelacion = Nothing
        DtRelacion = New DataRelation("PK_Ruma", ColPk1, ColPk2, False)
        ds.Relations.Add(DtRelacion)

        Call CargarUltraGrid(Grid2, ds)
    End Sub

    Function FiltrarConsultaActivo(ByRef Ls1 As List(Of ETActivo), ByRef Ls2 As List(Of ETActivo)) As List(Of ETActivo)

        Dim lResult As List(Of ETActivo) = Nothing

        lResult = New List(Of ETActivo)

        For Each Entidad.Activo In Ls1
            Entidad.Activo.Codigo = Entidad.Activo.Placa
            Entidad.Activo.Usuario = User_Sistema
            lResult.Add(Entidad.Activo)
        Next

        If Ls1.Count > 0 Then
            For Each Entidad.Activo In Ls2
                Bucle = Boolean.FalseString

                For Each Rpt As ETActivo In Ls1
                    If Rpt.Codigo = Entidad.Activo.Codigo Then
                        Bucle = Boolean.TrueString : Exit For
                    End If
                Next
                If Not Bucle Then lResult.Add(Entidad.Activo)
            Next
        Else
            For Each xRow As ETActivo In Ls2
                If xRow.Codigo.Trim = Txt5.Tag.ToString.Trim Then
                    xRow.Action = True
                    xRow.Cantidad = Num16.Value
                End If
                xRow.Usuario = User_Sistema
                lResult.Add(xRow)
            Next
        End If
        

        Ls1 = Nothing
        Ls2 = Nothing

        Return lResult

    End Function


    Sub Cargar_Orden_Unidad()
        Entidad.Activo = New ETActivo
        If TipoProceso = Proceso.Chancado Then
            Entidad.Activo.CodTipo = StrucActivos.Chancadora
        ElseIf TipoProceso = Proceso.Molienda_Confirmacion Then
            Entidad.Activo.CodTipo = StrucActivos.Molino
        End If

        Ls_Activo = Nothing
        Ls_Activo = New List(Of ETActivo)

        Dim Ls1 As New List(Of ETActivo)
        Dim Ls2 As New List(Of ETActivo)
        Dim O As New ETOrden
       

        Ls2 = Negocio.Orden.ConsultarOrden5(Entidad.Orden, Entidad.Activo)

        If TipoProceso = Proceso.Chancado Then
            Ls_Activo = Ls2
            Call CargarUltraCombo(Cbo1, Ls_Activo, "Placa", "Descripcion")
        ElseIf TipoProceso = Proceso.Molienda_Confirmacion Then
            O.ID = _OrdenProduccion
            O.Tipo_Doc = Txt6.Tag.ToString.Trim
            O.NroDocumento = Txt6.Text
            O.CodRuma = Txt7.Tag.ToString.Trim

            Ls1 = Negocio.Orden.ConsultarOrden12(O)

            Ls_Activo = FiltrarConsultaActivo(Ls1, Ls2)
            Call CargarUltraGrid(Grid11, Ls_Activo)
            Call Sumar_Cantidad_a_Molienda()
        End If
        O = Nothing
        Ls1 = Nothing
        Ls2 = Nothing
    End Sub

    Sub Cargar_Chancadora_Pesado()

        Dim ds As New DataSet

        ds = Negocio.Orden.Consultar_Orden_Chancadora_Pesaje(Entidad.Orden)

        Tbl_Activo1 = Nothing
        Tbl_Activo2 = Nothing
        ds_Activo = Nothing
        If ds IsNot Nothing Then

            Grid6.DataSource = Nothing

            ds_Activo = New DataSet
            Tbl_Activo1 = New DataTable
            Tbl_Activo2 = New DataTable
            Tbl_Activo1 = ds.Tables(0).Copy
            Tbl_Activo2 = ds.Tables(1).Copy
            ds_Activo.Tables.Add(Tbl_Activo1)
            ds_Activo.Tables.Add(Tbl_Activo2)

            Dim ColPk1 As DataColumn = Tbl_Activo1.Columns("ID")
            Dim ColPk2 As DataColumn = Tbl_Activo2.Columns("ID")

            Dim DtRelacion As DataRelation
            DtRelacion = Nothing
            DtRelacion = New DataRelation("PK_Activo", ColPk1, ColPk2, False)
            ds_Activo.Relations.Add(DtRelacion)
        End If

        Call CargarUltraGrid(Grid6, ds_Activo)

    End Sub

    Sub Cargar_Chancadora_Molino()

        Dim ds As New DataSet

        ds = Negocio.Orden.Consultar_Orden_Chancadora_Molino(Entidad.Orden)

        Tbl_Activo1 = Nothing
        Tbl_Activo2 = Nothing
        ds_Activo = Nothing
        If ds IsNot Nothing Then

            Grid9.DataSource = Nothing

            ds_Activo = New DataSet
            Tbl_Activo1 = New DataTable
            Tbl_Activo2 = New DataTable
            Tbl_Activo1 = ds.Tables(0).Copy
            Tbl_Activo2 = ds.Tables(1).Copy
            ds_Activo.Tables.Add(Tbl_Activo1)
            ds_Activo.Tables.Add(Tbl_Activo2)

            Dim ColPk1 As DataColumn = Tbl_Activo1.Columns("ID")
            Dim ColPk2 As DataColumn = Tbl_Activo2.Columns("ID")

            Dim DtRelacion As DataRelation
            DtRelacion = Nothing
            DtRelacion = New DataRelation("PK_Activo", ColPk1, ColPk2, False)
            ds_Activo.Relations.Add(DtRelacion)
        End If

        Call CargarUltraGrid(Grid9, ds_Activo)

    End Sub

    Sub Cargar_DatosActivo_Molino(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If

        Txt4.Tag = uRow.Cells("Cod_Chancadora").Value.ToString.Trim
        Txt4.Text = uRow.Cells("Cod_Chancadora").Value.ToString.Trim & " - " & uRow.Cells("Chancadora").Value.ToString.Trim
        Txt5.Tag = uRow.Cells("Cod_Molino").Value.ToString.Trim
        Txt5.Text = uRow.Cells("Molino").Value.ToString.Trim & " - " & uRow.Cells("Chancadora").Value.ToString.Trim
        Txt6.Tag = uRow.Cells("Tipo_Doc").Value.ToString.Trim
        Txt6.Text = uRow.Cells("NumDoc").Value.ToString.Trim
        Txt7.Tag = uRow.Cells("CodRuma").Value.ToString.Trim
        Txt7.Text = uRow.Cells("CodRuma").Value.ToString.Trim & " - " & uRow.Cells("Ruma").Value.ToString.Trim
        Num16.Value = uRow.Cells("Cantidad").Value
        Num17.Value = 0

        Dim dataViewHijos As DataView
        Dim O As ETOrden = Nothing

        dataViewHijos = New DataView(Tbl_Activo2)
        dataViewHijos.RowFilter = Tbl_Activo2.Columns("ID").ColumnName + " = " + CStr(uRow.Cells("ID").Value)

        Ls_Activo_Billete = Nothing
        Ls_Activo_Billete = New List(Of ETOrden)

        For Each yRow As DataRowView In dataViewHijos
            O = New ETOrden
            With O
                .ID = yRow("KeyID")
                .Cod_Chancadora = yRow("Cod_Chancadora").ToString.Trim
                .Tipo_Doc = "TS"
                .NroDocumento = yRow("NumDoc").ToString().Trim()
                .CodMolino = yRow("Cod_Molino").ToString().Trim()
                .CodRuma = yRow("CodRuma").ToString().Trim()
                .DesRuma = yRow("Ruma").ToString().Trim()
                .CodProducto = yRow("CodMineral").ToString().Trim()
                .Descripcion = yRow("Mineral").ToString().Trim()
                .Cantidad = Val(yRow("Cantidad").ToString().Trim())
                .Nuevo = Val(yRow("Nuevo").ToString().Trim())
                .Usuario = User_Sistema
            End With
            Ls_Activo_Billete.Add(O)
        Next yRow

        Call CargarUltraGrid(Grid10, Ls_Activo_Billete)
    End Sub

    Sub Cargar_DatosActivo_Chancadora(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If

        Dt3.Value = uRow.Cells("Fecha").Value
        Txt3.Text = uRow.Cells("Cod_Chancadora").Value.ToString.Trim & " - " & uRow.Cells("Chancadora").Value.ToString.Trim
        Txt3.Tag = uRow.Cells("Cod_Chancadora").Value.ToString.Trim
        Num1.Value = uRow.Cells("Cantidad").Value
        Cbo1.Value = Txt3.Tag


        Dim dataViewHijos As DataView
        Dim O As ETOrden = Nothing

        dataViewHijos = New DataView(Tbl_Activo2)
        dataViewHijos.RowFilter = Tbl_Activo2.Columns("ID").ColumnName + " = " + CStr(uRow.Cells("ID").Value)

        Ls_Activo_Billete = Nothing
        Ls_Activo_Billete = New List(Of ETOrden)

        For Each dataRowCurrent As DataRowView In dataViewHijos
            O = New ETOrden
            With O
                .ID = uRow.Cells("ID").Value
                .Tipo_Doc = "TS"
                .Cod_Chancadora = uRow.Cells("Cod_Chancadora").Value.ToString.Trim
                .NroDocumento = dataRowCurrent("Billete").ToString().Trim()
                .CodRuma = dataRowCurrent("CodRuma").ToString().Trim()
                .DesRuma = dataRowCurrent("DesRuma").ToString().Trim()
                .CodProducto = dataRowCurrent("Codigo").ToString().Trim()
                .Descripcion = dataRowCurrent("Descripcion").ToString().Trim()
                .Cantidad = Val(dataRowCurrent("Cantidad").ToString().Trim())
                .Nuevo = Val(dataRowCurrent("Nuevo").ToString().Trim())
                .CodMolino = dataRowCurrent("Cod_Molino").ToString().Trim()
            End With
            Ls_Activo_Billete.Add(O)
        Next dataRowCurrent

        Call CargarUltraGrid(Grid8, Ls_Activo_Billete)
    End Sub

    Sub Cargar_Confirmacion_Chancadora()
        Entidad.MyLista = New ETMyLista
        Dim ObjOrden As New ETOrden
        ObjOrden.ID = OrdenProduccion
        ObjOrden.Cod_Chancadora = Txt3.Tag
        ObjOrden.Cantidad = Num1.Value
        ObjOrden.Tipo_Doc = StrucActivos.Chancadora
        ObjOrden.Fecha = CDate(Dt3.Value)
        Entidad.MyLista = Negocio.Orden.ConsultarOrden9(ObjOrden)
        If Entidad.MyLista.Validacion = False Then Exit Sub
        _ChancadoraMyLista = Nothing
        _ChancadoraMyLista = New ETMyLista
        _ChancadoraMyLista = Entidad.MyLista
        Ls_Activo = New List(Of ETActivo)
        Ls_Activo = Entidad.MyLista.Ls_Activo
        
        Call CargarUltraGrid(Grid7, Ls_Personal)
        For Each xRow As ETActivo In Ls_Activo
            Cbo1.Value = xRow.Codigo
            Select Case xRow.Turno
                Case 1
                    Chk1.Checked = True
                    Num2.Value = xRow.Horas
                    Num3.Value = xRow.HorasParada
                    Num4.Value = xRow.Cantidad
                Case 2
                    Chk2.Checked = True
                    Num5.Value = xRow.Horas
                    Num6.Value = xRow.HorasParada
                    Num7.Value = xRow.Cantidad
                Case 3
                    Chk3.Checked = True
                    Num8.Value = xRow.Horas
                    Num9.Value = xRow.HorasParada
                    Num10.Value = xRow.Cantidad
                Case Else
                    Chk4.Checked = True
                    Num11.Value = xRow.Horas
                    Num12.Value = xRow.HorasParada
                    Num13.Value = xRow.Cantidad
            End Select
        Next
        Ls_Personal = New List(Of ETPersonal)
        Ls_Personal = Entidad.MyLista.Ls_Personal
        Call CargarUltraGrid(Grid7, Ls_Personal)

    End Sub
    'Sub Cargar_Cronograma_Activo()

    '    If Val(OrdenProduccion) <= 0 Then
    '        Exit Sub
    '    End If

    '    If Cbo1.Value Is Nothing Then
    '        Exit Sub
    '    End If

    '    If String.IsNullOrEmpty(Cbo1.Value) Then
    '        Exit Sub
    '    End If

    '    If TipoProceso = Proceso.Chancado Then
    '        If Chk1.Checked = True Then

    '        End If
    '        Consultar_Operarios(Dt3.Value, Cbo1.Value, Turno, StrucActivos.CodClase, StrucActivos.Chancadora)
    '    ElseIf TipoProceso = Proceso.Molienda Then
    '        Call Consultar_Operarios(Dt3.Value, Cbo1.Value, Turno, StrucActivos.CodClase, StrucActivos.Molino)
    '    End If

    '    Call CargarUltraGrid(Grid7, Ls_Personal)
    'End Sub

    Sub Chancadora_Turno()
        Dim Item As Integer = 0

        Ls_Activo = Nothing
        Ls_Activo = New List(Of ETActivo)

        _Cod_Activo = Txt3.Tag

        If Chk1.Checked Then
            Item = Item + 1
            _CodTurno = 1
            Entidad.Activo = New ETActivo
            With Entidad.Activo
                .Item = Item
                .Fecha = Dt3.Value
                .CodClase = StrucActivos.CodClase
                .CodTipo = StrucActivos.Chancadora
                .CodInterno = Txt3.Tag
                .Codigo = Cbo1.Value
                .Turno = _CodTurno
                .Horas = Num2.Value
                .HorasParada = Num3.Value
                .Cantidad = Num4.Value
                .ListaPersonal = Ls_Personal.Where(AddressOf Where_Personal_Turno).ToList
                .NroOperarios = .ListaPersonal.Count
            End With
            Ls_Activo.Add(Entidad.Activo)
        End If

        If Chk2.Checked Then
            Item = Item + 1
            _CodTurno = 2
            Entidad.Activo = New ETActivo
            With Entidad.Activo
                .Item = Item
                .Fecha = Dt3.Value
                .CodClase = StrucActivos.CodClase
                .CodTipo = StrucActivos.Chancadora
                .CodInterno = Txt3.Tag
                .Codigo = Cbo1.Value
                .Turno = _CodTurno
                .Horas = Num5.Value
                .HorasParada = Num6.Value
                .Cantidad = Num7.Value
                .ListaPersonal = Ls_Personal.Where(AddressOf Where_Personal_Turno).ToList
                .NroOperarios = .ListaPersonal.Count
            End With
            Ls_Activo.Add(Entidad.Activo)
        End If

        If Chk3.Checked Then
            Item = Item + 1
            _CodTurno = 3
            Entidad.Activo = New ETActivo
            With Entidad.Activo
                .Item = Item
                .Fecha = Dt3.Value
                .CodClase = StrucActivos.CodClase
                .CodTipo = StrucActivos.Chancadora
                .CodInterno = Txt3.Tag
                .Codigo = Cbo1.Value
                .Turno = _CodTurno
                .Horas = Num8.Value
                .HorasParada = Num9.Value
                .Cantidad = Num10.Value
                .ListaPersonal = Ls_Personal.Where(AddressOf Where_Personal_Turno).ToList
                .NroOperarios = .ListaPersonal.Count
            End With
            Ls_Activo.Add(Entidad.Activo)
        End If

        If Chk4.Checked Then
            Item = Item + 1
            _CodTurno = 4
            Entidad.Activo = New ETActivo
            With Entidad.Activo
                .Item = Item
                .Fecha = Dt3.Value
                .CodClase = StrucActivos.CodClase
                .CodTipo = StrucActivos.Chancadora
                .CodInterno = Txt3.Tag
                .Codigo = Cbo1.Value
                .Turno = _CodTurno
                .Horas = Num11.Value
                .HorasParada = Num12.Value
                .Cantidad = Num13.Value
                .ListaPersonal = Ls_Personal.Where(AddressOf Where_Personal_Turno).ToList
                .NroOperarios = .ListaPersonal.Count
            End With
            Ls_Activo.Add(Entidad.Activo)
        End If

    End Sub
    Sub Grabar_Chancadora()
        Dim Item As Integer = 0

        If Tab3.Tabs("T02").Selected = False Then Return

        If ValidarDatosActivo() = False Then
            Return
        End If

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .ID = OrdenProduccion
            .NroDocumento = txtOP1.Text
            .Usuario = User_Sistema
            .Fecha = Dt3.Value
            .Cod_Chancadora = Txt3.Tag
            .Cantidad = Num1.Value
        End With

        Call Chancadora_Turno()

        If Negocio.Orden.MantenimientoOrden5(Entidad.Orden, Ls_Activo, Ls_Activo_Billete).Validacion Then
            Call Cargar_Chancadora_Pesado()
            Tab3.Tabs("T01").Selected = True
        End If
    End Sub
    Sub Grabar_Molienda_ConfirmadaIndividual()
        If Not (TipoG = Evento.Nuevo OrElse TipoG = Evento.Edit) Then
            Return
        End If
        Grid11.UpdateData()
        Grid11.Update()

        Call Sumar_Cantidad_a_Molienda()

        If Val(Num16.Value) <> Val(Num17.Value) OrElse Val(Num16.Value) <= 0 OrElse Val(Num17.Value) <= 0 Then
            Ep1.SetError(Num17, "La Cantidad a Molienda deber igual a la Cantidad Chancada")
            Exit Sub
        End If

        Ls_Activo_Billete_Detalle = Nothing
        Ls_Activo_Billete_Detalle = New List(Of ETOrden)
        Dim O As ETOrden = Nothing
        Dim Suma As Decimal = Decimal.Zero
        Suma = Val(Num17.Value)

        For Each xRow As ETActivo In Ls_Activo
            If xRow.Action = True And xRow.Cantidad > 0 Then
                For Each yRow As ETOrden In Ls_Activo_Billete
                    O = New ETOrden
                    O.ID = yRow.ID
                    O.CodMolino = xRow.Codigo
                    O.Cantidad = yRow.Cantidad * (xRow.Cantidad / Suma)
                    O.Usuario = User_Sistema
                    Ls_Activo_Billete_Detalle.Add(O)
                Next
            End If
        Next

        If Ls_Activo_Billete.Count <= 0 Then
            MsgBox("No day datos a Confirmar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        O = New ETOrden
        O = Negocio.Orden.MantenimientoOrden5_M(Ls_Activo_Billete, Ls_Activo_Billete_Detalle)

        If O.Validacion Then
            TipoG = Evento.View
            Call LimpiarMolinoConfirmarIndividual()
            Call Cargar_Chancadora_Molino()
            Tab4.Tabs("T01").Selected = True
        End If

    End Sub

    Sub Grabar_Molienda_ConfirmacionMasiva()
        Dim ds As New DataSet
        Dim Tbl1 As New DataTable
        Dim Tbl2 As New DataTable
        Dim contar As Integer = 0

        Grid9.PerformAction(EnterEditMode)
        Grid9.Update()
        Grid9.UpdateData()

        ds = Grid9.DataSource
        Tbl1 = ds.Tables(0).Copy
        Tbl2 = ds.Tables(1).Copy

        Ls_Activo_Billete = Nothing
        Ls_Activo_Billete = New List(Of ETOrden)
        Ls_Activo_Billete_Detalle = Nothing
        Ls_Activo_Billete_Detalle = New List(Of ETOrden)


        Dim O As ETOrden = Nothing
        For Each xRow As DataRow In Tbl1.Rows
            contar = 0
            If xRow.Item("Action") = Boolean.TrueString Then
                Dim dataViewHijos As DataView
                dataViewHijos = New DataView(Tbl2)
                dataViewHijos.RowFilter = Tbl2.Columns("ID").ColumnName + " = " + CStr(xRow.Item("ID"))

                For Each yRow As DataRowView In dataViewHijos
                    contar = contar + 1
                    O = New ETOrden
                    With O
                        .ID = Val(yRow.Item("KeyID").ToString.Trim)
                        .CodMolino = yRow.Item("Cod_Molino").ToString.Trim
                        .Cantidad = Val(yRow("Cantidad").ToString().Trim())
                        .Usuario = User_Sistema
                    End With
                    Ls_Activo_Billete_Detalle.Add(O)
                    If contar = 1 Then
                        Ls_Activo_Billete.Add(O)
                    End If
                Next yRow
            End If
        Next

        If Ls_Activo_Billete.Count <= 0 Then
            MsgBox("Para la Confirmación Identica al Billete de Pesaje" & Chr(13) & "Debe checkear al menos un Billete", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        O = New ETOrden
        O = Negocio.Orden.MantenimientoOrden5_M(Ls_Activo_Billete, Ls_Activo_Billete_Detalle)

        If O.Validacion Then
            TipoG = Evento.View
            Call Cargar_Chancadora_Molino()
        End If
    End Sub
#End Region

#Region "Metodos Publicos"

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Modificar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Select Case TipoProceso
            Case Proceso.Chancado
                If _OrdenProduccion <= 0 Then
                    MsgBox("Seleccione una Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                    Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                    Exit Sub
                End If

                Call HabilitarDatosActivo(True)
                TipoG = Evento.Edit
                Tab1.Tabs("T04").Selected = True
            Case Proceso.Molienda_Confirmacion
                If _OrdenProduccion <= 0 Then
                    MsgBox("Seleccione una Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                    Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                    Exit Sub
                End If

                Call HabilitarConfirmacionMolino(True)

                TipoG = Evento.Edit
                Tab1.Tabs("T05").Selected = True
            Case Proceso.Molienda_IngresoProduccion
                If _OrdenProduccion <= 0 Then
                    MsgBox("Seleccione una Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                    Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                    Exit Sub
                End If
                Call HabilitarMolino_Ingreso_Produccion(True)
                TipoG = Evento.Edit
                Tab1.Tabs("T05").Selected = True
                Tab4.Tabs("T03").Selected = True
        End Select

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Public Sub Grabar()
        If Not (TipoG = Evento.Nuevo OrElse TipoG = Evento.Edit) Then
            Return
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Select Case TipoProceso
            Case Proceso.Chancado
                Call Grabar_Chancadora()
            Case Proceso.Molienda_Confirmacion
                If Tab4.Tabs("T01").Selected = True Then
                    Call Grabar_Molienda_ConfirmacionMasiva()
                Else
                    Call Grabar_Molienda_ConfirmadaIndividual()
                End If
        End Select
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

#Region "Function"

    Function Consultar_Operarios(ByVal _Fecha As Date, ByVal _Placa As String, _
                             ByVal _Turno As Int16, ByVal _CodClase As String, _
                             ByVal _CodTipo As String) As List(Of ETPersonal)
        Dim lResult As New List(Of ETPersonal)

        If String.IsNullOrEmpty(_Placa) Then
            Return lResult
        End If

        If Val(_Turno) <= 0 Then
            Return lResult
        End If

        Entidad.Activo = New ETActivo
        Negocio.Activo = New NGActivo
        Entidad.MyLista = New ETMyLista

        Dim NumDiaxSemana As Integer
        Dim NumSemanaxAnho As Integer
        Dim Anho As Integer
        Dim FechaIni As Date
        Dim FechaFin As Date

        _Fecha = _Fecha.Date
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
            .CodClase = _CodClase
            .CodTipo = _CodTipo
            .Placa = _Placa
            .Anho = Anho
            .Semana = NumSemanaxAnho 'DatePart(DateInterval.WeekOfYear, _Fecha, Microsoft.VisualBasic.FirstDayOfWeek.Wednesday)
            .Dia = DatePart(DateInterval.Weekday, _Fecha) + 4 : If .Dia > 7 Then .Dia -= 7
            .Fecha = _Fecha
            .Turno = _Turno
        End With

        Entidad.MyLista = Negocio.Activo.ConsultarCronogramaxPersonal(Entidad.Activo)

        If Not Entidad.MyLista.Validacion Then Return lResult

        lResult = Entidad.MyLista.Ls_Personal
        Return lResult
    End Function

    Function ValidarDatosActivo() As Boolean
        ValidarDatosActivo = True
        If OrdenProduccion <= 0 Then
            Ep1.SetError(txtOP1, "Seleccione una Orden de Producción")
            ValidarDatosActivo = False
            Exit Function
        End If

        If Cbo1.Value Is Nothing Then
            Ep1.SetError(Cbo1, "Seleccione una Chancadora")
            ValidarDatosActivo = False
            Exit Function
        End If

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Ep1.SetError(Cbo1, "Seleccione una Chancadora")
            ValidarDatosActivo = False
            Exit Function
        End If

        If Chk1.Checked = True Then
            If Val(Num2.Value) < 0 OrElse Val(Num2.Value) > Val(Num2.MaxValue) Then
                Ep1.SetError(Num2, "Las Horas Trabajadas debe estar entre 0 y " & CStr(Num2.MaxValue))
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num3.Value) < 0 OrElse Val(Num3.Value) > Val(Num3.MaxValue) Then
                Ep1.SetError(Num3, "Las Horas Paradas debe estar entre 0 y " & CStr(Num3.MaxValue))
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num3.Value) > Val(Num2.Value) Then
                Ep1.SetError(Num3, "Las Horas Paradas deben ser menor a las Horas Trabajadas")
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num4.Value) < 0 Then
                Ep1.SetError(Num4, "La Cantidad Chancada del Turno debe ser mayor o igual a Cero")
                ValidarDatosActivo = False
                Exit Function
            End If

        End If

        If Chk2.Checked = True Then
            If Val(Num5.Value) < 0 OrElse Val(Num5.Value) > Val(Num5.MaxValue) Then
                Ep1.SetError(Num5, "Las Horas Trabajadas debe estar entre 0 y " & CStr(Num5.MaxValue))
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num6.Value) < 0 OrElse Val(Num6.Value) > Val(Num6.MaxValue) Then
                Ep1.SetError(Num6, "Las Horas Paradas debe estar entre 0 y " & CStr(Num6.MaxValue))
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num6.Value) > Val(Num5.Value) Then
                Ep1.SetError(Num6, "Las Horas Paradas deben ser menor a las Horas Trabajadas")
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num7.Value) < 0 Then
                Ep1.SetError(Num7, "La Cantidad Chancada del Turno debe ser mayor o igual a Cero")
                ValidarDatosActivo = False
                Exit Function
            End If
        End If

        If Chk3.Checked = True Then
            If Val(Num8.Value) < 0 OrElse Val(Num8.Value) > Val(Num8.MaxValue) Then
                Ep1.SetError(Num8, "Las Horas Trabajadas debe estar entre 0 y " & CStr(Num8.MaxValue))
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num9.Value) < 0 OrElse Val(Num9.Value) > Val(Num9.MaxValue) Then
                Ep1.SetError(Num9, "Las Horas Paradas debe estar entre 0 y " & CStr(Num9.MaxValue))
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num9.Value) > Val(Num8.Value) Then
                Ep1.SetError(Num9, "Las Horas Paradas deben ser menor a las Horas Trabajadas")
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num10.Value) < 0 Then
                Ep1.SetError(Num10, "La Cantidad Chancada del Turno debe ser mayor o igual a Cero")
                ValidarDatosActivo = False
                Exit Function
            End If
        End If

        If Chk4.Checked = True Then
            If Val(Num11.Value) < 0 OrElse Val(Num11.Value) > Val(Num11.MaxValue) Then
                Ep1.SetError(Num11, "Las Horas Trabajadas debe estar entre 0 y " & CStr(Num11.MaxValue))
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num12.Value) < 0 OrElse Val(Num12.Value) > Val(Num12.MaxValue) Then
                Ep1.SetError(Num12, "Las Horas Paradas debe estar entre 0 y " & CStr(Num12.MaxValue))
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num12.Value) > Val(Num11.Value) Then
                Ep1.SetError(Num12, "Las Horas Paradas deben ser menor a las Horas Trabajadas")
                ValidarDatosActivo = False
                Exit Function
            End If

            If Val(Num13.Value) < 0 Then
                Ep1.SetError(Num13, "La Cantidad Chancada del Turno debe ser mayor o igual a Cero")
                ValidarDatosActivo = False
                Exit Function
            End If
        End If

        If Not (Val(Num1.Value) = Val(Num14.Value)) Then
            Ep1.SetError(Num14, "La Cantidad Chancada es diferente a la Cantidad de los Billetes")
            ValidarDatosActivo = False
            Exit Function
        End If

    End Function
    Function Existe_Orden(ByVal Rpt As ETOrden) As Boolean
        If Rpt.NroDocumento = Grid1.ActiveRow.Cells("NroDocumento").Value Then
            Return Boolean.TrueString
        Else
            Return Boolean.FalseString
        End If
    End Function

    Function Filtrar_Busqueda(ByVal uButon As Object) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If uButon Is Nothing Then
            Return lResult
        End If

        Ep1.Clear()

        lResult = Boolean.TrueString

Salir:
        Return lResult

    End Function

    Function Where_Personal_Turno(ByVal Rpt As ETPersonal) As Boolean
        Where_Personal_Turno = Boolean.FalseString
        If (Rpt.CodUnidadProd = _Cod_Activo And Rpt.Action = True And Rpt.Turno = _CodTurno) Then
            Where_Personal_Turno = Boolean.TrueString
        End If
    End Function

#End Region

    Function Where_Turno(ByVal Rpt As ETPersonal) As Boolean

        Dim lResult As Boolean = Boolean.TrueString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.Turno = _CodTurno Then
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function


    Private Sub Evento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk1.CheckedChanged, Chk2.CheckedChanged, Chk3.CheckedChanged, Chk4.CheckedChanged, Chk5.CheckedChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (TipoG = Evento.Nuevo OrElse TipoG = Evento.Edit) Then
            Return
        End If
        If sender Is Chk1 OrElse sender Is Chk2 OrElse sender Is Chk3 OrElse sender Is Chk4 Then
            Dim Turno As Integer

            Dim Saldo As Decimal = Decimal.Zero
            Saldo = Num1.Value - Num14.Value
            Saldo = IIf(Saldo < 0, 0, Saldo)
            Turno = Val(sender.Tag)
            _CodTurno = Turno
            If Ls_Personal Is Nothing Then Ls_Personal = New List(Of ETPersonal)
            Dim lResult As New List(Of ETPersonal)

            If sender Is Chk1 Then
                Num2.Value = 0
                Num3.Value = 0
                Num4.Value = 0
                If sender.Checked = True Then
                    Num2.Value = Num2.MaxValue
                    Num4.Value = Saldo
                End If
                Num2.ReadOnly = Not sender.Checked
                Num3.ReadOnly = Not sender.Checked
                Num4.ReadOnly = Not sender.Checked
            End If

            If sender Is Chk2 Then
                Num5.Value = 0
                Num6.Value = 0
                Num7.Value = 0
                If sender.Checked = True Then
                    Num5.Value = Num5.MaxValue
                    Num7.Value = Saldo
                End If

                Num5.ReadOnly = Not sender.Checked
                Num6.ReadOnly = Not sender.Checked
                Num7.ReadOnly = Not sender.Checked
            End If

            If sender Is Chk3 Then
                Num8.Value = 0
                Num9.Value = 0
                Num10.Value = 0
                If sender.Checked = True Then
                    Num8.Value = Num8.MaxValue
                    Num10.Value = Saldo
                End If

                Num8.ReadOnly = Not sender.Checked
                Num9.ReadOnly = Not sender.Checked
                Num10.ReadOnly = Not sender.Checked
            End If

            If sender Is Chk4 Then
                Num11.Value = 0
                Num12.Value = 0
                Num13.Value = 0
                If sender.Checked = True Then
                    Num11.Value = Num11.MaxValue
                    Num13.Value = Saldo
                End If

                Num11.ReadOnly = Not sender.Checked
                Num12.ReadOnly = Not sender.Checked
                Num13.ReadOnly = Not sender.Checked
            End If

            If TipoProceso = Proceso.Chancado Then
                If sender.Checked = True Then
                    lResult = Consultar_Operarios(Dt3.Value, Cbo1.Value, Turno, StrucActivos.CodClase, StrucActivos.Chancadora)
                End If
            ElseIf TipoProceso = Proceso.Molienda_Confirmacion Then
                If sender.Checked = True Then
                    lResult = Consultar_Operarios(Dt3.Value, Cbo1.Value, Turno, StrucActivos.CodClase, StrucActivos.Molino)
                End If
            End If

            If sender.Checked = True Then
                If lResult.Count > 0 Then
                    For Each xRow As ETPersonal In lResult
                        Ls_Personal.Add(xRow)
                    Next
                End If
            Else
                If Ls_Personal.Count > 0 Then
                    lResult = Ls_Personal.Where(AddressOf Where_Turno).ToList()
                    Ls_Personal = Nothing
                    Ls_Personal = New List(Of ETPersonal)
                    Ls_Personal = lResult
                End If
            End If

            Call CargarUltraGrid(Grid7, Ls_Personal)
        End If

        If sender Is Chk5 Then
            Grid9.PerformAction(ExitEditMode)
            For Each uRow As UltraGridRow In Grid9.Rows
                If uRow.Band.Index = 0 Then
                    uRow.Cells("Action").Value = Chk5.Checked
                End If
            Next
            Grid9.Update()
            Grid9.UpdateData()
        End If

    End Sub

    Private Sub Num14_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num14.ValueChanged

        If sender Is Nothing OrElse e Is Nothing Then Return

        If Val(Num14.Value) < 0 Or Val(Num14.Value) > Val(Num1.Value) Then
            Num14.Appearance.ForeColor = Color.Red
        ElseIf Val(Num14.Value) >= 0 And Val(Num14.Value) < Val(Num1.Value) Then
            Num14.Appearance.ForeColor = Color.Orange
        Else
            Num14.Appearance.ForeColor = Color.Green
        End If
    End Sub

    Sub Evento_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab3.SelectedTabChanged, Tab4.SelectedTabChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Tab3 OrElse sender Is Tab4) Then
            Return
        End If

        If e.Tab.Key = "T01" Then
            sender.Tabs("T02").Enabled = False
            TipoG = Evento.Clear
            If TipoProceso = Proceso.Chancado Then
                Call LimpiarDatosActivo()
                Call HabilitarDatosActivo(False)
            Else

            End If
            
        End If
    End Sub


    Private Sub Evento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo2.ValueChanged
        If sender Is Nothing OrElse e Is Nothing Then Return

        Call CargarIngresoProduccion()
    End Sub

End Class