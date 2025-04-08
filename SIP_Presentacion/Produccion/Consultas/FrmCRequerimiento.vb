Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmCRequerimiento

#Region "Variables"
    Public StrNroReq As String = String.Empty
    Public L As Boolean = Boolean.FalseString
    Public vCargar As Boolean = Boolean.FalseString
    Private Ls_Requerimiento As List(Of ETRequerimiento) = Nothing
#End Region

#Region "Eventos"

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                        Handles Me.Activated

        AdministrarToolBar(MdiParent, Nothing, Boolean.TrueString)

    End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
                          Handles Me.Deactivate

        AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Requerimiento IsNot Nothing Then Ls_Requerimiento = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Negocio.Requerimiento = New NGRequerimiento

        Ls_Requerimiento = New List(Of ETRequerimiento)
        'Ls_Requerimiento = Negocio.Requerimiento.ConsultarReq1
        CargarUltraGrid(Grid1, Ls_Requerimiento)

    End Sub

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) _
                              Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return

        e.Row.Fixed = Not e.Row.Fixed

        Call Cargar_Requerimiento(e.Row)

    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn1.Click

        If Not VerificarControl(5, Grid1) Then Return

        If IsDBNull(Grid1.ActiveRow.Cells("NroReq").Value) Then Return

        'If Not Ls_Requerimiento.Exists(AddressOf Existe_Requerimiento) Then Exit Sub

        Call Cargar_Requerimiento(Grid1.ActiveRow)

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles Grid1.InitializeLayout

        If sender IsNot Grid1 Then Return

        For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
            If Not (uColumn.Key = "NroReq" Or uColumn.Key = "FechaEmision" Or uColumn.Key = "FechaLimite") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
                       Handles Grid1.KeyDown

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

#End Region

#Region "Procedimientos"

    Sub Cargar_Requerimiento(ByVal uRow As UltraGridRow)

        vCargar = Boolean.TrueString
        StrNroReq = uRow.Cells("NroReq").Value
        If L Then Close()

    End Sub

#End Region

End Class