Imports System
Imports System.Windows
Imports System.Windows.Forms
Imports System.Windows.Forms.Clipboard
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Win.UltraWinExplorerBar
Imports Infragistics.Win.FormattedLinkLabel
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinSpellChecker
Imports Infragistics.Win.UltraWinStatusBar.PanelStyle
Imports SIP_Negocio

Public Class FrmBMain

    Inherits System.Windows.Forms.Form
    Private ComboTool As ComboBoxTool = Nothing

#Region "Procedimientos"

    Sub Initialize()
        ComboTool = Nothing
        ComboTool = tolMain.Tools("R28")
        If Not (StrTema = "1" OrElse StrTema = "2" OrElse StrTema = "3") Then StrTema = "0"
        ComboTool.Value = StrTema
        ComboTool = Nothing
        'EN ESTA LINEA DEMORA LA CARGA DEL MENU
        ComboTool = tolMain.Tools("R27")
        'ComboTool.Value = StrEstilo
        stbMain.Panels("KeyUsuario").Text = String.Concat("  Usuario : ", User_Sistema)
        stbMain.Panels("KeyServidor").Text = String.Concat("  Servidor : ", Servidor_App.ToUpper)
        stbMain.Panels("KeyBD").Text = String.Concat("  Base de Datos : ", BD_App.ToUpper)
        stbMain.Panels("KeyTiempo").Style = Progress
        stbMain.Panels("KeyVersion").Text = String.Format("(  Version: {0}  )", ObtenerNumeroDeVersionSistema())
    End Sub

    Sub Consultar_Sistemas()
        Call Activar_Sistemas(Usuario)
    End Sub

#End Region

#Region "Eventos"

    Sub Evento_SelectedTabChanging(ByVal sender As Object, ByVal e As SelectedTabChangingEventArgs) Handles Usuario.SelectedTabChanging

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Usuario Then Return

        If String.IsNullOrEmpty(e.Tab.Key.ToString) Then Return

        If e.Tab.TabPage.Controls.Count = 0 Then Return

        Call Activar_Modulo_Sistema(e.Tab.Key, e.Tab.TabPage.Controls(0))

    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Initialize()

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If ComboTool IsNot Nothing Then ComboTool = Nothing

    End Sub

    Sub Evento_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If MessageBox.Show("Seguro de Salir del Sistema", Mensaje.Comacsa, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = Boolean.TrueString
        Else
            FrmBLogueo.Close()
        End If

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Consultar_Sistemas()

        If gAreaMantto = True Or UCase(User_Sistema.Trim) = "SA" Then
            'Timer2.Enabled = Negocio.Programacion_Mantto.Programacion_PendienteEjecucion()
            Timer2.Enabled = False
        End If

    End Sub

    Sub Evento_ToolClick(ByVal sender As Object, ByVal e As ToolClickEventArgs) Handles tolMain.ToolClick

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Dim Ruta As String = String.Empty
        StrucForm.CxMenu = New ClsMenu

        Select Case e.Tool.Key.ToString
            Case StrucOperaciones._Nuevo
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Nuevo, ActiveMdiChild)
                End If
            Case StrucOperaciones._Modificar
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Modificar, ActiveMdiChild)
                End If
            Case StrucOperaciones._Eliminar
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Eliminar, ActiveMdiChild)
                End If
            Case StrucOperaciones._Cancelar
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Cancelar, ActiveMdiChild)
                End If
            Case StrucOperaciones._Grabar
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Grabar, ActiveMdiChild)
                End If
            Case StrucOperaciones._Buscar
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Buscar, ActiveMdiChild)
                End If
            Case StrucOperaciones._Procesar
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Procesar, ActiveMdiChild)
                End If
            Case StrucOperaciones._Actualizar
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Actualizar, ActiveMdiChild)
                End If
            Case StrucOperaciones._Reporte
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Reporte, ActiveMdiChild)
                End If
            Case StrucOperaciones._Excel
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Excel, ActiveMdiChild)
                End If


                REM Utilitarios

            Case "R04", "R05", "R06", "R07"
                If MessageBox.Show("¿Seguro desea Modificar la Resolución de la Pantalla?", _
                   Mensaje.Comacsa, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
                   DialogResult.No Then
                    Exit Sub
                End If
                StrucForm.CxResolucion = New ClsResolucion

                If e.Tool.Key.ToString = "R04" Then
                    StrucForm.CxResolucion.i32Horizontal = 1024
                    StrucForm.CxResolucion.i32Vertical = 768
                ElseIf e.Tool.Key.ToString = "R05" Then
                    StrucForm.CxResolucion.i32Horizontal = 1152
                    StrucForm.CxResolucion.i32Vertical = 864
                ElseIf e.Tool.Key.ToString = "R06" Then
                    StrucForm.CxResolucion.i32Horizontal = 1280
                    StrucForm.CxResolucion.i32Vertical = 960
                Else
                    StrucForm.CxResolucion.i32Horizontal = 1280
                    StrucForm.CxResolucion.i32Vertical = 1024
                End If

                StrucForm.CxResolucion.Main()

            Case "R12"
                If ActiveMdiChild IsNot Nothing Then
                    ActiveMdiChild.Close()
                End If
            Case "R13"
                Close()
            Case "R16"
                If ActiveMdiChild IsNot Nothing Then
                    For Each Frm As Form In MdiChildren
                        Frm.Close()
                    Next
                End If
            Case "R17"
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Word, ActiveMdiChild)
                End If
            Case "R18"
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Pdf, ActiveMdiChild)
                End If
            Case "R19"
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Excel, ActiveMdiChild)
                End If
            Case "Help"
                Ruta = My.Application.Info.DirectoryPath & "\" & "Help_ERP_Comacsa.pdf"
                Try
                    System.Diagnostics.Process.Start(Ruta)

                Catch Err As Exception

                    MsgBox("El archivo de ayuda no esta en el Directorio, Actualice el Sistema", MsgBoxStyle.Exclamation, My.Application.Info.Description)

                End Try

            Case Else
                If ActiveMdiChild IsNot Nothing Then
                    StrucForm.CxMenu.Evento_Click(Operacion.Manual, ActiveMdiChild)
                End If
        End Select

    End Sub

    Sub Evento_ToolValueChanged(ByVal sender As Object, ByVal e As ToolEventArgs) Handles _
                                tolMain.ToolValueChanged

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (e.Tool.Key.ToString = "R27" OrElse e.Tool.Key.ToString = "R28") Then Return

        ComboTool = Nothing
        ComboTool = e.Tool

        If e.Tool.Key.ToString = "R28" Then
            Office2007ColorTable.ColorScheme = ComboTool.Value
        Else
            If Not IO.File.Exists(String.Concat(StrRutaTemas, ComboTool.Value.ToString)) OrElse ComboTool.Text = "Defauld" Then
                AppStyling.StyleManager.Reset()
            Else
                AppStyling.StyleManager.Load(String.Concat(StrRutaTemas, ComboTool.Value.ToString))
            End If
        End If

        Call GuardarConfiguracion(ComboTool.Value.ToString, IIf(e.Tool.Key.ToString = "R28", "Tema", "Estilo"))

    End Sub

    Sub Evento_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles _
                           Tree1.DoubleClick, Tree2.DoubleClick, Tree3.DoubleClick, Tree4.DoubleClick, Tree5.DoubleClick, Tree6.DoubleClick _
                           , Tree7.DoubleClick, Tree8.DoubleClick, Tree9.DoubleClick, Tree10.DoubleClick, Tree11.DoubleClick, _
                           Tree12.DoubleClick, Tree13.DoubleClick, Tree14.DoubleClick, Tree15.DoubleClick, Tree20.DoubleClick, Tree21.DoubleClick, _
                           Tree22.DoubleClick, Tree23.DoubleClick, Tree24.DoubleClick, Tree25.DoubleClick, UltraTree30.DoubleClick, UltraTree4.DoubleClick, UltraTree5.DoubleClick, _
                           UltraTree2.DoubleClick, UltraTree1.DoubleClick, UltraTree6.DoubleClick, UltraTree7.DoubleClick, UltraTree28.DoubleClick, UltraTree29.DoubleClick, UltraTree3.DoubleClick, UltraTree10.DoubleClick, UltraTree11.DoubleClick, UltraTree12.DoubleClick, UltraTree13.DoubleClick, UltraTree14.DoubleClick, UltraTree37.DoubleClick, UltraTree41.DoubleClick, UltraTree42.DoubleClick, UltraTree9.DoubleClick, UltraTree55.DoubleClick,UltraTree57.DoubleClick

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender.ActiveNode Is Nothing Then Return

        If sender.ActiveNode.LeftImages(0) Then Return

        Call Inizializar_Formulario(sender, Usuario, Me)

    End Sub

#End Region

#Region "Timer"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static X As Long
        If Val(X) > 0 Then
            If X Mod 300000 = 0 Then
                Timer2.Enabled = Negocio.Programacion_Mantto.Programacion_PendienteEjecucion()
                If Timer2.Enabled = True Then
                    Timer1.Enabled = False
                End If
                X = 0
            End If
        End If
        X = Val(X) + Timer1.Interval
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Static Y As Long
        If Val(Y) <= 5000 Then
            Dim objPT As New Point

            With Me
                objPT.X = .Right
                objPT.Y = .Bottom
            End With

            UltraPopupControlContainer1.Show(PointToScreen(objPT))

            Y = Y + Timer2.Interval
        ElseIf Val(Y) > 5000 Then
            UltraPopupControlContainer1.Close()
            Y = 0
            Timer2.Enabled = False
            Timer1.Enabled = True

        End If
    End Sub
#End Region

#Region "Label"
    Private Sub UltraLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel1.Click

        If Habilitar_Permisos("74").Count <= 0 Then
            MsgBox("Usted no tiene permisos para visualizar el formulario", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If
        StrucForm.Formulario = New frmPProgramacionMantto

        Call Show_Permisos(StrucForm.Formulario, "74")
        Call CargarUltraStatusBar(Me, uStatus.Procesando)

        StrucForm.Formulario.MdiParent = Me
        StrucForm.Formulario.Text = "Mantenimiento.Planeamiento - Programación De Mantenimiento"
        StrucForm.Formulario.WindowState = FormWindowState.Maximized
        StrucForm.Formulario.Show()

        Call CargarUltraStatusBar(Me, uStatus.Finalizado)
    End Sub

#End Region

    Private Sub stbMain_PanelDoubleClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinStatusBar.PanelClickEventArgs) Handles stbMain.PanelDoubleClick
        If e.Panel.Key = "KeyVersion" Then
            Dim version As String = ObtenerNumeroDeVersionSistema()
            System.Windows.Forms.Clipboard.SetText(version)
            MessageBox.Show(version, msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Usuario_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Usuario.SelectedTabChanged

    End Sub

    Private Sub tolMain_BeforeToolEnterEditMode(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.BeforeToolEnterEditModeEventArgs) Handles tolMain.BeforeToolEnterEditMode

    End Sub

    Private Sub UltraTree10_AfterSelect(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.SelectEventArgs) Handles UltraTree10.AfterSelect

    End Sub

    Private Sub Tree1_AfterSelect(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.SelectEventArgs) Handles Tree1.AfterSelect

    End Sub

    Private Sub UltraExplorerBar2_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles UltraExplorerBar2.ItemClick

    End Sub

    Private Sub UltraTree57_AfterSelect(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.SelectEventArgs) Handles UltraTree57.AfterSelect

    End Sub

    Private Sub UltraExplorerBar8_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles UltraExplorerBar8.ItemClick

    End Sub
End Class