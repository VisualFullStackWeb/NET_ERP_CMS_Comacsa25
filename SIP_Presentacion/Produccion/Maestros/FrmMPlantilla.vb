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

Public Class FrmMPlantilla

#Region "Variables"


    Private StrAsignado As String = "<<  Asignado  >>"
    Private StrDisponible As String = "<< Disponible >>"
    Private Ope As Int32 = 0
    Private List_Unidad As List(Of ETActivo)
    Private List_Personal As List(Of ETPersonal)
    Private CodPersonal As String = String.Empty
    Private CodClase As String = String.Empty
    Private CodTipo As String = String.Empty
    Private StrOperaciones As String() = {StrucOperaciones._Modificar, _
                                          StrucOperaciones._Cancelar, _
                                          StrucOperaciones._Actualizar, _
                                          StrucOperaciones._Buscar, _
                                          StrucOperaciones._Grabar}


#End Region

#Region "Eventos"

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated



        'AdministrarToolBar(MdiParent, StrOperaciones)
    End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate
        AdministrarToolBar(MdiParent)
    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        List_Unidad = New List(Of ETActivo)

        Entidad.Activo = New ETActivo
        Negocio.Activo = New NGActivo

        Entidad.Activo.CodClase = StrucActivos.CodClase
        List_Unidad = Negocio.Activo.ConsultarActivo6(Entidad.Activo)

        CargarUltraGrid(Grid1, List_Unidad)

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout


        If CType(sender, UltraGrid) Is Grid1 Then

            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Placa" Or _
                        uColumn.Key = "Descripcion" Or _
                        uColumn.Key = "DesTipo" Or _
                        uColumn.Key = "DesTurno1" Or _
                        uColumn.Key = "DesTurno2" Or _
                        uColumn.Key = "DesTurno3" Or _
                        uColumn.Key = "DesTurno4") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next

        End If

        If CType(sender, UltraGrid) Is Grid2 Then

            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "CodPersonal" Or _
                        uColumn.Key = "DesPersonal") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next

        End If

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) Handles Grid1.InitializeRow

        If CType(sender, UltraGrid) Is Grid1 Then

            If e.Row.Cells("CodTipo").Value = "02" Then
                e.Row.Cells("DesTipo").Value = "CHANCADORA"
                e.Row.Cells("DesTipo").Appearance.BackColor = Color.LightCoral
            End If
            If e.Row.Cells("CodTipo").Value = "01" Then
                e.Row.Cells("DesTipo").Value = "MOLINO"
                e.Row.Cells("DesTipo").Appearance.BackColor = Color.SkyBlue
            End If

            If e.Row.Cells("Turno1").Value Then
                e.Row.Cells("DesTurno1").Value = StrAsignado
                e.Row.Cells("DesTurno1").Appearance.ForeColor = Color.Blue
            Else
                e.Row.Cells("DesTurno1").Value = StrDisponible
            End If

            If e.Row.Cells("Turno2").Value Then
                e.Row.Cells("DesTurno2").Value = StrAsignado
                e.Row.Cells("DesTurno2").Appearance.ForeColor = Color.Blue
            Else
                e.Row.Cells("DesTurno2").Value = StrDisponible
            End If

            If e.Row.Cells("Turno3").Value Then
                e.Row.Cells("DesTurno3").Value = StrAsignado
                e.Row.Cells("DesTurno3").Appearance.ForeColor = Color.Blue
            Else
                e.Row.Cells("DesTurno3").Value = StrDisponible
            End If

            If e.Row.Cells("Turno4").Value Then
                e.Row.Cells("DesTurno4").Value = StrAsignado
                e.Row.Cells("DesTurno4").Appearance.ForeColor = Color.Blue
            Else
                e.Row.Cells("DesTurno4").Value = StrDisponible
            End If

        End If

    End Sub

    Sub Evento_ClickCellButton(ByVal sender As Object, ByVal e As CellEventArgs) Handles Grid1.ClickCellButton

        If CType(sender, UltraGrid) Is Grid1 Then

            Select Case e.Cell.Column.Key
                Case "DesTurno1"
                    CargarRegistro(e.Cell.Row, 1)
                Case "DesTurno2"
                    CargarRegistro(e.Cell.Row, 2)
                Case "DesTurno3"
                    CargarRegistro(e.Cell.Row, 3)
                Case "DesTurno4"
                    CargarRegistro(e.Cell.Row, 4)
                Case Else
                    Exit Sub
            End Select

        End If

    End Sub

    Sub Evento_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles Gpb1.DoubleClick

        Buscar()

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
                       Handles Grid1.KeyDown, Grid2.KeyDown

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

        List_Unidad = Nothing
        List_Personal = Nothing

    End Sub

#End Region

#Region "Metodos Publicos"

    Public Sub Buscar()

        If Not VerificarControl(1, Txt1) OrElse Tab1.Tabs("T01").Selected = True Then
            Exit Sub
        End If

        If Ope = 0 Then
            Exit Sub
        End If

        StrucForm.FxCxPersonal = New FrmCPersonal
        AddHandler StrucForm.FxCxPersonal.Closed, AddressOf BuscarPersonal
        StrucForm.FxCxPersonal.MdiParent = MdiParent
        StrucForm.FxCxPersonal.L = Boolean.TrueString
        StrucForm.FxCxPersonal.Show()
        StrucForm.FxCxPersonal = Nothing

    End Sub

    Public Sub Modificar()

        If Tab1.SelectedTab.Key = "T01" Then
            Exit Sub
        End If

        If Tab1.SelectedTab.Key = "T02" Then
            If Not VerificarControl(1, Txt1) Then
                MessageBox.Show("No existe Placa para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

        End If

        Ope = 2

        Controles(Boolean.FalseString)

    End Sub

    Public Sub Cancelar()

        Ope = 0
        Call Controles(Boolean.TrueString)

    End Sub

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Evento_Load(Me, Nothing)
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Grabar()

        If Tab1.SelectedTab.Key <> "T02" Then
            Exit Sub
        End If

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe Placa para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Grid2.PerformAction(ExitEditMode)

        Entidad.Activo = New ETActivo
        Entidad.Objecto = New ETObjecto
        Negocio.Activo = New NGActivo

        Entidad.Activo.CodClase = CodClase
        Entidad.Activo.CodTipo = CodTipo
        Entidad.Activo.Placa = Txt1.Value
        Entidad.Activo.Turno = Cbo2.Value
        Entidad.Activo.Usuario = User_Sistema

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Objecto = Negocio.Activo.MantenimientoPlanilla(Entidad.Activo, List_Personal)

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

        If Entidad.Objecto.Validacion Then Call Cancelar()


    End Sub

#End Region

#Region "Metodos Locales"

    Sub CargarRegistro(ByVal uRow As UltraGridRow, ByVal i32Turno As Int32)

        CodClase = uRow.Cells("CodClase").Value
        CodTipo = uRow.Cells("CodTipo").Value
        Txt1.Value = uRow.Cells("Placa").Value
        Txt2.Value = uRow.Cells("Descripcion").Value
        Cbo1.Value = CodTipo
        Cbo2.Value = i32Turno

        List_Personal = New List(Of ETPersonal)
        Entidad.Activo = New ETActivo
        Negocio.Activo = New NGActivo

        Entidad.Activo.CodClase = CodClase
        Entidad.Activo.CodTipo = CodTipo
        Entidad.Activo.Placa = uRow.Cells("Placa").Value
        Entidad.Activo.Turno = i32Turno

        List_Personal = Negocio.Activo.ConsultarActivo7(Entidad.Activo)

        CargarUltraGrid(Grid2, List_Personal)

        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Sub BuscarPersonal(ByVal sender As Object, ByVal e As EventArgs)
        If Not sender.vCargar Then
            Exit Sub
        Else

            Entidad.Personal = New ETPersonal
            Entidad.Personal.CodPersonal = sender.CodPersonal
            Entidad.Personal.DesPersonal = sender.DesPersonal
            CodPersonal = sender.CodPersonal

            If Not (List_Personal.FindAll(AddressOf BuscarPersonal).Count = 0) Then
                Exit Sub
            End If

            List_Personal.Add(Entidad.Personal)

            CargarUltraGrid(Grid2, List_Personal)

        End If
    End Sub

    Sub Controles(ByVal Val As Boolean)
        If Not Val Then
            Grid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True
        Else
            Grid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        End If
    End Sub

#End Region

#Region "Funciones"

    Function BuscarPersonal(ByVal Rpt As ETPersonal) As Boolean
        If Rpt.CodPersonal = CodPersonal Then
            Return Boolean.TrueString
        Else
            Return Boolean.FalseString
        End If
    End Function

#End Region

End Class