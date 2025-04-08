Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmEnlazarEquipoContabilidad
    Public Ls_Permisos As New List(Of Integer)

    Private Ls_Equipo_Pendiente As List(Of ETEquipo) = Nothing
    Private Ls_Equipo_Contabilidad As List(Of ETEquipo) = Nothing
    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Dim TipoG As State

    Private Sub frmEnlazarEquipoContabilidad_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmEnlazarEquipoContabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub

    Private Sub Inicio()
        TipoG = State.eView
        Call CargarGrilla()
        Tab1.Tabs("T01").Selected = True
    End Sub
    Private Sub CargarGrilla()

        Ls_Equipo_Pendiente = New List(Of ETEquipo)
        Ls_Equipo_Contabilidad = New List(Of ETEquipo)

        Entidad.MyLista = Negocio.Equipo.Consultar_Equipo_Pendiente_Contabilidad
        If Entidad.MyLista.Validacion Then
            Ls_Equipo_Pendiente = Entidad.MyLista.Ls_Equipo
        End If

        Entidad.MyLista = Negocio.Equipo.Consultar_Equipo_Enlazado_Contabilidad
        If Entidad.MyLista.Validacion Then
            Ls_Equipo_Contabilidad = Entidad.MyLista.Ls_Equipo
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Equipo_Pendiente)
        Call CargarUltraGridxBinding(Grid2, Source2, Ls_Equipo_Contabilidad)

    End Sub

    Private Sub Grid1_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid1.CellChange
        If Not (TipoG = State.eEdit) Then Return
        If e.Cell.Column.Key = "Action" Then
            Grid1.UpdateData()

            Grid1.PerformAction(ExitEditMode, False, False)
            Grid1.PerformAction(NextCellByTab, False, False)
            Grid1.PerformAction(NextCellByTab, False, False)
            Grid1.PerformAction(NextCellByTab, False, False)
            Grid1.PerformAction(NextCellByTab, False, False)
            Grid1.PerformAction(NextCellByTab, False, False)
            Grid1.PerformAction(NextCellByTab, False, False)
            Grid1.PerformAction(EnterEditMode, False, False)


        End If
    End Sub


    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                    OrElse uColumn.Key = "LinNeg" OrElse uColumn.Key = "FamiliaEq" _
                    OrElse uColumn.Key = "Action" OrElse uColumn.Key = "CodigoAnterior" _
                    OrElse uColumn.Key = "CodigoContabilidad") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
            uColumn.CellActivation = Activation.NoEdit

        Next
    End Sub

    Private Function ValidarCodigoContabilidad(ByVal Lista As List(Of ETEquipo)) As Boolean
        ValidarCodigoContabilidad = True
        Dim i As Long
        Dim j As Long
        For i = 0 To Lista.Count - 2
            For j = i + 1 To Lista.Count - 1
                If Lista(i).CodigoContabilidad = Lista(j).CodigoContabilidad Then
                    ValidarCodigoContabilidad = False
                    MsgBox("El Codigo de Contabilidad esta Duplicado", MsgBoxStyle.Critical, msgComacsa)
                    Exit Function
                End If
            Next

            If Negocio.Equipo.Validar_Equipo_Codigo_Contabilidad(Lista(i)) Then
                ValidarCodigoContabilidad = False
                MsgBox("El Codigo de Contabilidad esta Duplicado", MsgBoxStyle.Critical, msgComacsa)
                Exit Function
            End If
        Next

    End Function
    Public Sub Grabar()
        Dim ListaPendiente As New List(Of ETEquipo)
        Dim ListaQuitar As New List(Of ETEquipo)
        If Not (TipoG = State.eEdit) Then Return

        For Each xRow As UltraGridRow In Grid2.Rows
            If xRow.Cells("Action").Value = False Then
                With Entidad.Equipo
                    .Equipo = xRow.Cells("Equipo").Value
                    .CodigoContabilidad = String.Empty
                    .Usuario = User_Sistema
                    .Tipo = 13
                End With
                ListaQuitar.Add(Entidad.Equipo)
            End If
        Next

        For Each xRow As UltraGridRow In Grid1.Rows
            If xRow.Cells("Action").Value = True Then
                With Entidad.Equipo
                    .Equipo = xRow.Cells("Equipo").Value
                    .CodigoContabilidad = xRow.Cells("CodigoContabilidad").Value
                    .Usuario = User_Sistema
                    .Tipo = 13
                End With
                ListaPendiente.Add(Entidad.Equipo)
            End If
        Next

        If ValidarCodigoContabilidad(ListaPendiente) = False Then
            Exit Sub
        End If

        If Negocio.Equipo.Update_Equipo_Contabilidad(ListaPendiente, ListaQuitar) > 0 Then
            Call Inicio()
        End If
    End Sub
    Public Sub Modificar()
        Grid1.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.AllowEdit
        Grid1.DisplayLayout.Bands(0).Columns("CodigoContabilidad").CellActivation = Activation.AllowEdit
        Grid2.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.AllowEdit

        TipoG = State.eEdit
    End Sub

    Public Sub Cancelar()
        Call Inicio()
    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Private Sub Grid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        With Grid1
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
                    .ActiveRow.Cells("Action").Activate()
                    .PerformAction(EnterEditMode, False, False)
            End Select
        End With
    End Sub
End Class