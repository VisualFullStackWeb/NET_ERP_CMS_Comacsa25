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

Public Class FrmMUnidadPersonal

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Declaraciones"
    Private Ope As Int32 = 0
    Private CodPersonal As String = String.Empty
    Private CodClase As String = String.Empty
    Private CodTipo As String = String.Empty
    Private MdiOperaciones As List(Of String) = Nothing
    Private Ls_Activo As List(Of ETActivo) = Nothing
    Private Ls_Personal As List(Of ETPersonal) = Nothing
#End Region

#Region "Eventos"

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Modificar)
    '    MdiOperaciones.Add(StrucOperaciones._Cancelar)
    '    MdiOperaciones.Add(StrucOperaciones._Actualizar)
    '    MdiOperaciones.Add(StrucOperaciones._Grabar)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate

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

        If Ls_Activo IsNot Nothing Then Ls_Activo = Nothing
        If Ls_Personal IsNot Nothing Then Ls_Personal = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles _
                                Grid1.InitializeLayout, Grid2.InitializeLayout


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Placa" Or _
                        uColumn.Key = "Descripcion" Or _
                        uColumn.Key = "DesTipo") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "CodPersonal" Or _
                        uColumn.Key = "DesPersonal") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) _
                            Handles Grid1.InitializeRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            If e.Row.Cells("CodTipo").Value = StrucActivos.Molino Then
                e.Row.Cells("DesTipo").Value = StrucActivos.StrMolino
                e.Row.Cells("DesTipo").Appearance.BackColor = Color.SkyBlue
            End If
            If e.Row.Cells("CodTipo").Value = StrucActivos.Chancadora Then
                e.Row.Cells("DesTipo").Value = StrucActivos.StrChancadora
                e.Row.Cells("DesTipo").Appearance.BackColor = Color.LightCoral
            End If
        End If

    End Sub

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) _
                             Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return

        Call Consultar_Activo(e.Row)

    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _
                     Btn2.Click, Btn3.Click, Btn1.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Btn1 Then
            If Grid1.ActiveRow Is Nothing Then Return
            If Grid1.ActiveRow.IsFilterRow Then Return
            Call Consultar_Activo(Grid1.ActiveRow)
        End If

        If Ope = 0 OrElse Not VerificarControl(1, Txt1) Then Return

        If sender Is Btn2 Then
            StrucForm.FxCxPersonal = New FrmCPersonal
            AddHandler StrucForm.FxCxPersonal.Closing, AddressOf Cargar_Personal
            StrucForm.FxCxPersonal.MdiParent = MdiParent
            StrucForm.FxCxPersonal.L = Boolean.TrueString
            StrucForm.FxCxPersonal.Show()
            StrucForm.FxCxPersonal = Nothing
            Return
        End If

        If sender Is Btn3 Then
            If Not VerificarControl(5, Grid2) Then
                MessageBox.Show("No tiene Personal para Quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Grid2.ActiveRow Is Nothing Then
                MessageBox.Show("No tiene Personal Seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            Grid2.ActiveRow.Delete()
            Return
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

    Function Existe_Personal(ByVal Rpt As ETPersonal) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If
        If Rpt.CodPersonal = CodPersonal Then lResult = Boolean.TrueString
        Return lResult

    End Function

#End Region

#Region "Procedimientos"

    Sub Cargar_Activo(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Call Cancelar()

        Cbo1.Value = uRow.Cells("CodTipo").Value
        Txt1.Value = uRow.Cells("Placa").Value
        Txt2.Value = uRow.Cells("Descripcion").Value
        CodClase = uRow.Cells("CodClase").Value
        CodTipo = uRow.Cells("CodTipo").Value

        Call CargarUltraGrid(Grid2, Ls_Personal)

        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Sub Consultar_Activo(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Ls_Personal = New List(Of ETPersonal)
        Entidad.Activo = New ETActivo
        Entidad.MyLista = New ETMyLista
        Negocio.Activo = New NGActivo

        Entidad.Activo.CodClase = uRow.Cells("CodClase").Value
        Entidad.Activo.CodTipo = uRow.Cells("CodTipo").Value
        Entidad.Activo.Placa = uRow.Cells("Placa").Value

        Entidad.MyLista = Negocio.Activo.ConsultarActivo5(Entidad.Activo)

        If Entidad.MyLista.Validacion Then
            Ls_Personal = Entidad.MyLista.Ls_Personal
            Call Cargar_Activo(uRow)
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Sub Iniciar()

        Negocio.Activo = New NGActivo
        Entidad.MyLista = New ETMyLista
        Ls_Activo = New List(Of ETActivo)

        Entidad.MyLista = Negocio.Activo.ConsultarActivo4()

        If Entidad.MyLista.Validacion Then
            Ls_Activo = Entidad.MyLista.Ls_Activo
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Activo)

    End Sub

    Sub Controles(ByVal Val As Boolean)

        Btn2.Enabled = Not Val
        Btn3.Enabled = Not Val

        If Not Val Then
            Grid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True
        Else
            Grid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        End If

    End Sub

    Sub Cargar_Personal(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If sender.Lista.Count = 0 Then Return

        For Each w As ETPersonal In sender.Lista
            CodPersonal = String.Empty : CodPersonal = w.CodPersonal
            If Not Ls_Personal.Exists(AddressOf Existe_Personal) Then Ls_Personal.Add(w)
        Next

        Call CargarUltraGrid(Grid2, Ls_Personal)

    End Sub

#End Region

#Region "Publicos"

    Public Sub Modificar()

        If Tab1.SelectedTab.Key = "T01" Then Return

        If Not VerificarControl(1, Txt1) Then Return

        Ope = 2

        Call Controles(Boolean.FalseString)

    End Sub

    Public Sub Cancelar()

        Ope = 0
        Call Controles(Boolean.TrueString)

    End Sub

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Grabar()

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe Placa para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Grid2.PerformAction(ExitEditMode)

        Entidad.Activo = New ETActivo
        Entidad.Objecto = New ETObjecto
        Negocio.Activo = New NGActivo

        Entidad.Activo.CodClase = CodClase
        Entidad.Activo.CodTipo = CodTipo
        Entidad.Activo.Placa = Txt1.Value
        Entidad.Activo.Usuario = User_Sistema

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)


        Entidad.Objecto = Negocio.Activo.MantenimientoUnidadPersonal(Entidad.Activo, Ls_Personal)
        If Entidad.Objecto.Validacion Then Cancelar()


        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

End Class