Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmCSuministro

#Region "Declaraciones"
    Public vCargar As Boolean = Boolean.FalseString
    Public CodSuministro As String = String.Empty
    Public Descripcion As String = String.Empty
    Public L As Boolean = Boolean.FalseString
    Private MdiOperaciones As List(Of String) = Nothing
    Private Ls_Suministro As List(Of ETSuministro) = Nothing
    Public Lista As List(Of ETSuministro) = Nothing
#End Region

#Region "Eventos"

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
                          Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                         Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        MdiOperaciones = New List(Of String)

        MdiOperaciones.Add(StrucOperaciones._Actualizar)

        Call AdministrarToolBar(MdiParent, MdiOperaciones)

    End Sub

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) _
                              Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return

        e.Row.Fixed = Not e.Row.Fixed

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

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Lista IsNot Nothing Then Lista = Nothing
        If Ls_Suministro IsNot Nothing Then Lista = Nothing
        If MdiOperaciones IsNot Nothing Then Lista = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) _
                    Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        With Grid1.DisplayLayout.Bands(0)
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "CodSuministro" OrElse uColumn.Key = "DesSuministro" OrElse _
                        uColumn.Key = "CodEmpaque" OrElse uColumn.Key = "DesEmpaque") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With

    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn1.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Btn1 Then Return

        If Not VerificarControl(5, Grid1) Then Return

        If Grid1.Rows.FixedRows.Count = 0 Then
            MessageBox.Show("Debe Seleccionar al menos uno", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Lista = New List(Of ETSuministro)

        For Each uRow As UltraGridRow In Grid1.Rows.FixedRows
            Entidad.Suministro = New ETSuministro
            Entidad.Suministro.CodSuministro = uRow.Cells("CodEmpaque").Value
            Entidad.Suministro.Descripcion = uRow.Cells("DesEmpaque").Value
            Lista.Add(Entidad.Suministro)
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

    Sub Iniciar()

        If L Then
            Btn1.Enabled = Boolean.TrueString
        Else
            Btn1.Enabled = Boolean.FalseString
        End If

        vCargar = Boolean.FalseString

        Negocio.Suministro = New NGSuministro
        Entidad.MyLista = New ETMyLista

        Ls_Suministro = New List(Of ETSuministro)

        Entidad.MyLista = Negocio.Suministro.ConsultarSuministro

        If Entidad.MyLista.Validacion Then
            Ls_Suministro = Entidad.MyLista.Ls_Suministro
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Suministro)

    End Sub

#End Region

End Class