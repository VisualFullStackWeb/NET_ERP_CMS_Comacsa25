Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmCMinerales

    Private List As List(Of ETMineral)

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles Grid1.InitializeLayout

        If CType(sender, UltraGrid) IsNot Grid1 Then
            Exit Sub
        End If



        For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
            If Not (uColumn.Key = "CodMineral" Or uColumn.Key = "Descripcion" Or _
                    uColumn.Key = "Cantera" Or uColumn.Key = "DesCantera" Or _
                    uColumn.Key = "Contratista" Or uColumn.Key = "Estado" Or _
                    uColumn.Key = "Origen") Then
                uColumn.Hidden = True
            End If

           
        Next

    End Sub

    Sub Evento_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        List = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        List = New List(Of ETMineral)

        Negocio.Mineral = New NGMineral

        List = Negocio.Mineral.ConsultarMineral1

        CargarUltraGrid(Grid1, List)

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Grid1.KeyDown

        Try
            With sender
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = True
                        .PerformAction(EnterEditMode)
                    Case Keys.Down
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = True
                        .PerformAction(EnterEditMode)
                    Case Keys.Right
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = True
                        .PerformAction(EnterEditMode)
                    Case Keys.Left
                        .PerformAction(ExitEditMode)
                        .PerformAction(PrevCellByTab)
                        e.Handled = True
                        .PerformAction(EnterEditMode)
                    Case Keys.Return
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = True
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch
            Exit Sub
        End Try

    End Sub

End Class