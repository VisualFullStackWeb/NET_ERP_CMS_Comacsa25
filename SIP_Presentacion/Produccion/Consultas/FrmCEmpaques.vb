Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows
Imports System.Windows.Forms
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmCEmpaques

#Region "Variables"

    Public vCargar As Boolean = Boolean.FalseString
    Public CodSuministro As String = String.Empty
    Public DesSuministro As String = String.Empty
    Public CodAnterior As String = String.Empty
    Private Ls_Logistica As List(Of ETSuministro) = Nothing
    Public Lista As List(Of ETSuministro) = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)

#End Region

#Region "Eventos"

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
                       Handles Grid1.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Exit Sub

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
            Exit Sub
        End Try
    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Source1.Clear()
        Ls_Logistica = Nothing
        Lista = Nothing
        MdiOperaciones = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()

    End Sub

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) _
                              Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Exit Sub

        If e.Row.IsFilterRow Then Exit Sub

        e.Row.Fixed = Not e.Row.Fixed

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Exit Sub

        With sender.DisplayLayout.Bands(0)

            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "CodSuministro" Or _
                        uColumn.Key = "CodAnterior" Or _
                        uColumn.Key = "DesSuministro") Then
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

        If sender IsNot Btn1 Then Exit Sub

        If Not VerificarControl(5, Grid1) Then Exit Sub

        If Grid1.Rows.FixedRows.Count = 0 Then
            MessageBox.Show("Debe Seleccionar al menos uno", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Lista = New List(Of ETSuministro)

        For Each uRow As UltraGridRow In Grid1.Rows.FixedRows
            Entidad.Suministro = New ETSuministro
            Entidad.Suministro.CodSuministro = uRow.Cells("CodSuministro").Value
            Entidad.Suministro.DesSuministro = uRow.Cells("DesSuministro").Value
            Lista.Add(Entidad.Suministro)
        Next

        vCargar = Boolean.TrueString

        Close()

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

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
                          Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

#End Region

#Region "Metodos Publicos"

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Iniciar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

#Region "Procedimientos"

    Sub Iniciar()

        Negocio.Suministro = New NGSuministro
        Entidad.MyLista = New ETMyLista
        Ls_Logistica = New List(Of ETSuministro)

        Entidad.MyLista = Negocio.Suministro.ConsultarSuministro4()

        If Entidad.MyLista.Validacion Then
            Ls_Logistica = Entidad.MyLista.Ls_Suministro
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Logistica)

    End Sub

#End Region

End Class