Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmMSistemas
#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Sistemas As List(Of ETSistema) = Nothing
    Private Ls_Grupo As List(Of ETSistema) = Nothing

    Private Enum eState
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private TipoG As eState

#End Region

#Region "Procedimientos Privados"
    Private Sub HabilitarControles(ByVal xBol As Boolean)
        Txt1.ReadOnly = True
        Txt2.ReadOnly = Not xBol
        Txt3.ReadOnly = Not xBol
        Cbo1.ReadOnly = Not xBol
        If xBol = False Then
            Grid2.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.NoEdit
        Else
            Grid2.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.AllowEdit
        End If
    End Sub

    Private Sub Limpiar()
        Txt1.Clear()
        Txt2.Clear()
        Txt3.Clear()
        Cbo1.Value = "A"
        Ls_Grupo = Nothing
        Ls_Grupo = New List(Of ETSistema)
        Call CargarUltraGrid(Grid2, Ls_Grupo)
    End Sub

    Private Sub Inicio()
        Tab1.Tabs("T01").Selected = True
        Call Limpiar()
        Call HabilitarControles(False)
        TipoG = eState.eView
        Call Cargar_Sistemas()
    End Sub

    Private Sub Cargar_Sistemas()
        Ls_Sistemas = Nothing
        Ls_Sistemas = New List(Of ETSistema)
        Entidad.MyLista = New ETMyLista
        Negocio.Sistemas = New NGSistema
        Entidad.MyLista = Negocio.Sistemas.Consultar_Sistema
        If Entidad.MyLista IsNot Nothing Then
            If Entidad.MyLista.Validacion Then
                Ls_Sistemas = Entidad.MyLista.Ls_Sistema
            End If
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Sistemas)
    End Sub

    Private Sub Cargar_Sistemas_Grupo()
        Ls_Grupo = Nothing
        Ls_Grupo = New List(Of ETSistema)
        Entidad.Sistemas = New ETSistema
        Entidad.Sistemas.ID = Trim(Txt1.Text)
        Entidad.MyLista = New ETMyLista
        Negocio.Sistemas = New NGSistema
        Entidad.MyLista = Negocio.Sistemas.Consultar_Sistema_Grupos(Entidad.Sistemas)
        If Entidad.MyLista IsNot Nothing Then
            If Entidad.MyLista.Validacion Then
                Ls_Grupo = Entidad.MyLista.Ls_Sistema
            End If
        End If

        Call CargarUltraGrid(Grid2, Ls_Grupo)
    End Sub



#End Region

#Region "Formulario"

    Private Sub frmMSistemas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub

#End Region

#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        Call Limpiar()
        Call Cargar_Sistemas_Grupo()
        Call HabilitarControles(True)
        Txt2.Focus()
        TipoG = eState.eNew
        Tab1.Tabs("T02").Selected = True
    End Sub

    Public Sub Modificar()
        Call HabilitarControles(True)
        Txt2.Focus()
        TipoG = eState.eEdit
    End Sub

    Public Sub Grabar()
        Entidad.Sistemas = New ETSistema
        With Entidad.Sistemas
            .ID = Txt1.Text.Trim
            .Sistema = Txt2.Text.Trim
            .Abrev = Txt3.Text.Trim
            If Cbo1.Value = "I" Then
                .Status = "I"
            ElseIf Cbo1.Value = "E" Then
                .Status = "*"
            End If
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With
        Grid2.Update()
        Grid2.UpdateData()

        Ls_Grupo = Nothing
        Ls_Grupo = New List(Of ETSistema)

        If Grid2.Rows.Count > 0 Then
            For Each xRow As UltraGridRow In Grid2.Rows
                Entidad.SistemasGrupo = New ETSistema
                With Entidad.SistemasGrupo
                    .ID = xRow.Cells("ID").Value
                    .Grupo = xRow.Cells("Grupo").Value
                    If xRow.Cells("Action").Value = True Then
                        .Status = ""
                        .Action = True
                    Else
                        .Status = "*"
                        .Action = False
                    End If
                    .Usuario = User_Sistema
                    .Tipo = 1
                End With
                If TipoG = eState.eNew Then
                    If xRow.Cells("Action").Value = True Then
                        Ls_Grupo.Add(Entidad.SistemasGrupo)
                    End If
                Else
                    Ls_Grupo.Add(Entidad.SistemasGrupo)
                End If

            Next

        End If

        Negocio.Sistemas = New NGSistema
        If Negocio.Sistemas.Mantto_Sistema(Entidad.Sistemas, Ls_Grupo) > 0 Then
            Call Inicio()
        End If
    End Sub

    Public Sub Actualizar()
        Call Inicio()
    End Sub

    Public Sub Cancelar()
        Call Inicio()
    End Sub
#End Region
#Region "Grilla"

    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow
        If e Is Nothing Then Exit Sub
        If Grid1.Rows.Count <= 0 Then Exit Sub
        If Grid1.ActiveRow Is Nothing Then Exit Sub

        Call Limpiar()
        Txt1.Text = Grid1.ActiveRow.Cells("ID").Value
        Txt2.Text = Grid1.ActiveRow.Cells("Sistema").Value
        Txt3.Text = Grid1.ActiveRow.Cells("Abrev").Value
        Cbo1.Value = Grid1.ActiveRow.Cells("Status").Value
        Call Cargar_Sistemas_Grupo()
        Call HabilitarControles(False)
        Tab1.Tabs("T02").Selected = True
    End Sub
    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "ID" OrElse uColumn.Key = "Sistema" _
                        OrElse uColumn.Key = "Abrev") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "ID" OrElse uColumn.Key = "Grupo" _
                        OrElse uColumn.Key = "Action") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

    End Sub
#End Region
  

End Class