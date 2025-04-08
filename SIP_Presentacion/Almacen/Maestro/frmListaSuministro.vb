Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.FixedRowIndicator
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports SIP_Entidad
Imports SIP_Negocio
Public Class frmListaSuministro
    Private cargoForm As Boolean = False
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub


#Region "Declaraciones"
    Public vCargar As Boolean = Boolean.FalseString
    Public L As Boolean = Boolean.FalseString
    Public ls_IdAlmacenSolicitante As String = ""

    Private Ls_Suministro As List(Of ETRuma) = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Lista As List(Of ETRuma) = Nothing

    Private Property idtipoStock()
        Get
            Return Me.cbbTipoStock.SelectedIndex
        End Get
        Set(ByVal value)
            Me.cbbTipoStock.SelectedIndex = value
        End Set
    End Property

    'Private Property IdAlmacenSolicitante()
    '    Get
    '        Return Me.ucboalmsol.
    '    End Get
    '    Set(ByVal value)
    '        Me.IdAlmacenSolicitante.SelectedIndex = value
    '    End Set
    'End Property

#End Region

#Region "Eventos"

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
                          Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
    '                     Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Actualizar)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Suministro IsNot Nothing Then Ls_Suministro = Nothing
        If Lista IsNot Nothing Then Lista = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) _
                    Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        comboTipoStock()
        Call Iniciar()
        cargoForm = True
    End Sub

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) _
                              Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If Grid1.ActiveRow.Cells("StockD").Value = 0 Then
            MessageBox.Show("No puede seleccionar un suministro con stock 0", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If Not VerificarControl(5, Grid1) Then Return

        If e.Row.IsFilterRow Then Return

        e.Row.Fixed = Not e.Row.Fixed


    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        For Each uColumn As UltraGridColumn In Grid1.DisplayLayout.Bands(0).Columns
            If Not (uColumn.Key = "CodRuma" Or uColumn.Key = "Descripcion" Or uColumn.Key = "Unidad" Or uColumn.Key = "StockD") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
                       Handles Grid1.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        Try
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
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch
        End Try
    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn1.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Btn1 Then Return

        If Not VerificarControl(5, Grid1) Then Return

        If Grid1.Rows.FixedRows.Count = 0 Then
            MessageBox.Show("No puede seleccionar un suministro con stock 0", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Lista = New List(Of ETRuma)

        For Each uRow As UltraGridRow In Grid1.Rows.FixedRows
            Entidad.Ruma = New ETRuma
            If uRow.Cells("StockD").Value = 0 Then MessageBox.Show("No puede seleccionar un suministro con stock 0", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
            Entidad.Ruma.CodRuma = uRow.Cells("CodRuma").Value
            Entidad.Ruma.Descripcion = uRow.Cells("Descripcion").Value
            Entidad.Ruma.StockD = uRow.Cells("StockD").Value
            'Entidad.Ruma.TipoEnlace = uRow.Cells("TipoEnlace").Value
            Lista.Add(Entidad.Ruma)
        Next

        vCargar = Boolean.TrueString

        If L Then Close()

    End Sub

#End Region

#Region "Publicos"

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

#Region "Procedimientos"

    Private Sub comboTipoStock()

        With cbbTipoStock
            .Items.Clear()
            .Items.Add("[Todos]")
            .Items.Add("Sin Stock")
            .Items.Add("Con Stock")
            .SelectedIndex = 2 'con stock
        End With

    End Sub

    Sub Iniciar()

        If L Then
            Btn1.Enabled = Boolean.TrueString
        Else
            Btn1.Enabled = Boolean.FalseString
        End If

        Ls_Suministro = New List(Of ETRuma)
        Ls_Suministro = Negocio.Producto.ConsultarSuministros2(Me.idtipoStock, ls_IdAlmacenSolicitante)

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Suministro)

    End Sub

#End Region

    Private Sub cbbTipoStock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbTipoStock.SelectedIndexChanged

        If cargoForm = True Then
            Iniciar()
        End If

    End Sub
End Class