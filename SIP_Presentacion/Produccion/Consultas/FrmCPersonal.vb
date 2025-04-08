Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Math
Imports System.Drawing
Imports System.Windows
Imports System.Windows.Forms
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.DrawPhase
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmCPersonal

#Region "Declaraciones"

    Public Opcion As Int16 = 1
    Public vCargar As Boolean = Boolean.FalseString
    Public CodPersonal As String = String.Empty
    Public DesPersonal As String = String.Empty
    Public CodClase As String = String.Empty
    Public CodTipo As String = String.Empty
    Public Fecha As Date = Now.Date
    Public Placa As String = String.Empty
    Public CostoxHora As Decimal = Decimal.Zero
    Public L As Boolean = Boolean.FalseString
    Private Ls_Personal As List(Of ETPersonal) = Nothing
    Public Lista As List(Of ETPersonal) = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
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

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Personal IsNot Nothing Then Ls_Personal = Nothing
        If Lista IsNot Nothing Then Lista = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) _
                    Handles Me.Load

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

        If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return

        e.Row.Fixed = Not e.Row.Fixed

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "CodPersonal" Or uColumn.Key = "DesPersonal") Then
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
            MessageBox.Show("Debe Seleccionar al menos uno", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Lista = New List(Of ETPersonal)

        For Each uRow As UltraGridRow In Grid1.Rows.FixedRows
            Entidad.Personal = New ETPersonal
            Entidad.Personal.CodPersonal = uRow.Cells("CodPersonal").Value
            Entidad.Personal.DesPersonal = uRow.Cells("DesPersonal").Value
            Lista.Add(Entidad.Personal)
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

        Negocio.Personal = New NGPersonal
        Ls_Personal = New List(Of ETPersonal)
        Entidad.MyLista = New ETMyLista

        If L Then
            Btn1.Enabled = Boolean.TrueString
        Else
            Btn1.Enabled = Boolean.FalseString
        End If

        If Opcion = 2 Then
            Entidad.Activo = New ETActivo
            Entidad.Activo.CodClase = CodClase
            Entidad.Activo.CodTipo = CodTipo
            Entidad.Activo.Placa = Placa
            Entidad.Activo.Fecha = Fecha

            Entidad.MyLista = Negocio.Personal.ConsultarPersonal2(Entidad.Activo)
        Else
            Entidad.Personal = Nothing
            Entidad.Personal = New ETPersonal
            Entidad.Personal.Fecha = Fecha
            Entidad.MyLista = Negocio.Personal.ConsultarPersonal1(Entidad.Personal)
        End If

        If Entidad.MyLista.Validacion Then
            Ls_Personal = Entidad.MyLista.Ls_Personal
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Personal)

    End Sub

#End Region

End Class