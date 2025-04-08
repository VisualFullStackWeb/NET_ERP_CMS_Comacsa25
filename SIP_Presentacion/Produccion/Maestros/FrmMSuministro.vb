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
Public Class FrmMSuministro



#Region "Variables"

    Private Ope As Int32 = 0
    Private CodSuministro As String = String.Empty
    Private Ls_Empaque As List(Of ETSuministro) = Nothing
    Private Ls_Suministro As List(Of ETSuministro) = Nothing
    Private MdiOperaciones As List(Of String) = Nothing

    Public Ls_Permisos As New List(Of Integer)
    Public Dt_Suministro As New DataTable

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#End Region

#Region "Eventos"

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
    '                     Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Nuevo)
    '    MdiOperaciones.Add(StrucOperaciones._Modificar)
    '    MdiOperaciones.Add(StrucOperaciones._Cancelar)
    '    MdiOperaciones.Add(StrucOperaciones._Eliminar)
    '    MdiOperaciones.Add(StrucOperaciones._Actualizar)
    '    MdiOperaciones.Add(StrucOperaciones._Grabar)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
                          Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Empaque IsNot Nothing Then Ls_Empaque = Nothing
        If Ls_Suministro IsNot Nothing Then Ls_Suministro = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()

    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call ScrollLabel(Lbl1)

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            With sender.DisplayLayout.Bands(0)
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "CodEmpaque" Or uColumn.Key = "DesEmpaque") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End With
            Return
        End If

        If sender Is Grid2 Then
            With sender.DisplayLayout.Bands(0)
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "CodSuministro" Or uColumn.Key = "DesSuministro") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End With
            Return
        End If

    End Sub

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) _
                              Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return

        Call Consultar_Empaque(e.Row)

    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) _
                     Handles Btn2.Click, Btn3.Click, Btn1.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Btn1 Then

            If Not VerificarControl(5, Grid1) Then Return

            If Grid1.ActiveRow.IsFilterRow Then Return

            Call Consultar_Empaque(Grid1.ActiveRow)

        End If

        If sender Is Btn2 Then

            If Ope = 0 Then Exit Sub

            StrucForm.FxCxEmpaques = New FrmCEmpaques
            AddHandler StrucForm.FxCxEmpaques.Closing, AddressOf Cargar_Suministro
            StrucForm.FxCxEmpaques.MdiParent = MdiParent
            StrucForm.FxCxEmpaques.Show()
            StrucForm.FxCxEmpaques = Nothing

        End If

        If sender Is Btn3 Then
            If Not VerificarControl(5, Grid2) Then
                MessageBox.Show("No tiene Suministros para Quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Grid2.ActiveRow Is Nothing Then
                MessageBox.Show("No tiene un Suministro Seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            Grid2.ActiveRow.Delete()
        End If

    End Sub

    Sub Evento_BeforeRowsDeleted(ByVal sender As Object, ByVal e As BeforeRowsDeletedEventArgs) _
                                 Handles Grid2.BeforeRowsDeleted

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid2 Then Return

        e.DisplayPromptMsg = Boolean.FalseString

    End Sub

#End Region

#Region "Funciones"

    Function Existe_Suministro(ByVal Rpt As ETSuministro) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.CodSuministro = CodSuministro Then lResult = Boolean.TrueString

        Return lResult

    End Function

#End Region

#Region "Procedimiento"

    Sub Controles(ByVal Val As Boolean)

        Txt2.ReadOnly = Not Val
        Cbo1.ReadOnly = Not Val
        Btn2.Enabled = Val
        Btn3.Enabled = Val

        If Val Then
            Grid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True
        Else
            Grid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        End If

    End Sub

    Sub Iniciar()

        Negocio.Suministro = New NGSuministro
        Entidad.MyLista = New ETMyLista

        Ls_Empaque = New List(Of ETSuministro)

        Entidad.MyLista = Negocio.Suministro.ConsultarSuministro5()

        If Entidad.MyLista.Validacion Then
            Ls_Empaque = Entidad.MyLista.Ls_Suministro
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Empaque)

    End Sub

    Sub Limpiar()

        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Cbo1.Value = "K1"

        Ls_Suministro = New List(Of ETSuministro)
        Call CargarUltraGrid(Grid2, Ls_Suministro)

    End Sub

    Sub Cargar_Suministro(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        For Each W As ETSuministro In sender.Lista
            CodSuministro = String.Empty : CodSuministro = W.CodSuministro
            If Not Ls_Suministro.Exists(AddressOf Existe_Suministro) Then Ls_Suministro.Add(W)
        Next

        Call CargarUltraGrid(Grid2, Ls_Suministro)

    End Sub

    Sub Consultar_Empaque(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.MyLista = New ETMyLista
        Entidad.Suministro = New ETSuministro
        Negocio.Suministro = New NGSuministro
        Ls_Suministro = New List(Of ETSuministro)

        Entidad.Suministro.CodEmpaque = uRow.Cells("CodEmpaque").Value
        Dt_Suministro = Negocio.Suministro.ConsultarSuministro3(Entidad.Suministro)


        If Entidad.MyLista.Validacion Then
            Ls_Suministro = Entidad.MyLista.Ls_Suministro
            Call Cargar_Empaque(uRow)
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Sub Cargar_Empaque(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Call Cancelar()

        Txt1.Value = uRow.Cells("CodEmpaque").Value
        Txt2.Value = uRow.Cells("DesEmpaque").Value

        Select Case uRow.Cells("status").Value
            Case "I"
                Cbo1.Value = "K2"
            Case "*"
                Cbo1.Value = "K3"
            Case Else
                Cbo1.Value = "K1"
        End Select

        Call CargarUltraGrid(Grid2, Ls_Suministro)

        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

#End Region

#Region "Publicos"

    Public Sub Nuevo()

        Ope = 1
        Call Limpiar()
        Call Controles(Boolean.TrueString)
        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Public Sub Modificar()

        If Not Tab1.Tabs("T02").Selected Then
            Return
        End If

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe Producto para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Ope = 2
        Call Controles(Boolean.TrueString)

    End Sub

    Public Sub Cancelar()

        Ope = 0
        Call Controles(Boolean.FalseString)

    End Sub

    Public Sub Grabar()

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Grid2.PerformAction(ExitEditMode)
        Grid2.PerformAction(EnterEditMode)

        Entidad.Suministro = New ETSuministro
        Negocio.Suministro = New NGSuministro

        Entidad.Suministro.CodSuministro = IIf(Txt1.Value = Nothing, String.Empty, Txt1.Value)
        Entidad.Suministro.Descripcion = IIf(Txt2.Value = Nothing, String.Empty, Txt2.Value)
        Entidad.Suministro.Status = Cbo1.Value
        Entidad.Suministro.Usuario = User_Sistema

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Suministro = Negocio.Suministro.MantenimientoEmpaques(Entidad.Suministro, Ls_Suministro)

        If Entidad.Suministro.Validacion Then
            If Ope = 1 Then Txt1.Value = Entidad.Suministro.CodEmpaque
            Call Iniciar() : Call Cancelar()
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

End Class