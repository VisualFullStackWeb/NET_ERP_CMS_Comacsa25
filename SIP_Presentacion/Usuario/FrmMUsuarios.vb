Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmMUsuarios

#Region "Variables"

    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private Ls_Usuario As List(Of ETUsuario) = Nothing
    Private ListModulos As List(Of ETUsuario) = Nothing
    Private Lis As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)


    Private Structure EstadoUsuario
        Event z()
    Const KeyEliminado As String = "E"
    Const KeyInactivo As String = "I"
    Const KeyActivo As String = "A"
    Const Eliminado As String = "ELIMINADO"
    Const Inactivo As String = "INACTIVO"
    Const Activo As String = "ACTIVO"
    End Structure
#End Region

#Region "Eventos"

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Nuevo)
    '    MdiOperaciones.Add(StrucOperaciones._Modificar)
    '    MdiOperaciones.Add(StrucOperaciones._Cancelar)
    '    MdiOperaciones.Add(StrucOperaciones._Grabar)
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

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()
        Negocio.Sistemas = New NGSistema
        Cbo3.DataSource = Negocio.Sistemas.Consultar_SistemaDT
        Cbo3.ValueMember = "idSistema"
        Cbo3.DisplayMember = "Sistema"
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Cbo3.Value = 0

    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call ScrollLabel(Lbl1)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Usuario IsNot Nothing Then Ls_Usuario = Nothing
        If ListModulos IsNot Nothing Then ListModulos = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles _
                       Txt1.KeyDown, Txt2.KeyDown, Txt4.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return

        If sender Is Txt1 Then
            Txt2.SelectAll()
            Txt2.Focus()
        End If

        If sender Is Txt2 Then
            Txt4.SelectAll()
            Txt4.Focus()
        End If

        If sender Is Txt4 Then
            Txt5.SelectAll()
            Txt5.Focus()
        End If

    End Sub

    Sub Evento_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Txt2.TextChanged

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Txt2 Then Return

        If User_Sistema = "SA" Then
            sender.PasswordChar = String.Empty
        Else
            sender.PasswordChar = "*"
        End If

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then

            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Usuario" Or uColumn.Key = "Encargado") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If
        'Carga las columnas
        If sender Is Grid2 Then

            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Formulario" Or uColumn.Key = "Action" Or _
                        uColumn.Key = "Operacion") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
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

        Call Consultar_Usuario(e.Row)

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) _
                             Handles Grid1.InitializeRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Row.Cells("Estado").Value = EstadoUsuario.KeyEliminado Then
            e.Row.Cells("DesEstado").Value = EstadoUsuario.Eliminado

        ElseIf e.Row.Cells("Estado").Value = EstadoUsuario.KeyInactivo Then
            e.Row.Cells("DesEstado").Value = EstadoUsuario.Inactivo

        Else
            e.Row.Cells("DesEstado").Value = EstadoUsuario.Activo
        End If

    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) _
                     Handles Btn2.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Btn1 Then

            If Not VerificarControl(5, Grid1) Then Return
            If Grid1.ActiveRow.IsFilterRow Then Return
            Call Consultar_Usuario(Grid1.ActiveRow)
            Return

        End If

        If sender Is Btn2 Then

            Call VerificarDisponibilidad()
            Return

        End If

    End Sub

    Sub Evento_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
                            Handles Cbo2.ValueChanged, Cbo3.ValueChanged, Txt3.ValueChanged

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Txt3 Then
            If Len(Txt3.Value) <> 5 Then Txt4.Clear()
        End If

        If sender Is Cbo3 Then

            Entidad.Usuario = New ETUsuario
            Negocio.Usuario = New NGUsuario
            Lis = New DataTable

            Entidad.Usuario.Sistema = Cbo3.Value

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Cbo2.DataSource = Negocio.Usuario.ListarFormulario(Entidad.Usuario, 4)
            Cbo2.ValueMember = "ID"
            Cbo2.DisplayMember = "Grupo"
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            Cbo2.Value = 0

            ListModulos = New List(Of ETUsuario)
            ListModulos = Negocio.Usuario.ConsultarOpcionesUsuario(Entidad.Usuario)
            CargarUltraGrid(Grid2, ListModulos)

        End If


        If sender Is Cbo2 Then
            If Not VerificarControl(1, Txt1) OrElse Not VerificarControl(4, Cbo2) Then
                Return
            End If

            Entidad.Usuario = New ETUsuario
            Negocio.Usuario = New NGUsuario

            Entidad.Usuario.Usuario = Txt1.Value
            Entidad.Usuario.Sistema = Cbo3.Value
            Entidad.Usuario.Grupo = Cbo2.Value

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

            ListModulos = Negocio.Usuario.ConsultarOpcionesUsuario(Entidad.Usuario)

            CargarUltraGrid(Grid2, ListModulos)

            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End If

    End Sub

    Sub Evento_DoubleClickHeader(ByVal sender As Object, ByVal e As DoubleClickHeaderEventArgs) _
                                 Handles Grid2.DoubleClickHeader

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid2 Then Return

        If e.Header.Column.Key.ToString <> "Action" Then Return

        If ListModulos Is Nothing OrElse ListModulos.Count = 0 OrElse Tipo = 0 Then
            Return
        End If

        For Each Y In ListModulos
            Y.Action = Not Val
        Next

        Val = Not Val

        sender.Refresh()

    End Sub

    Sub CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcarTodo.CheckedChanged
        If Grid2.Rows.Count > 0 Then
            If ChkMarcarTodo.Checked = True Then
                For j As Integer = 0 To Grid2.Rows.Count - 1
                    Grid2.Rows(j).Cells("Action").Value = True
                Next

            Else
                For j As Integer = 0 To Grid2.Rows.Count - 1
                    Grid2.Rows(j).Cells("Action").Value = False
                Next
            End If
        End If
    End Sub

#End Region

#Region "Publicos"

    Public Sub Nuevo()

        Tipo = Operacion.Nuevo
        Call Limpiar()
        Call Controles(Boolean.FalseString)
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Tab1.Tabs("T03").Selected = Boolean.TrueString

    End Sub

    Public Sub Modificar()

        If Tab1.SelectedTab.Key <> "T02" And Tab1.SelectedTab.Key <> "T03" Then Return

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe Usuario para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Tipo = Operacion.Modificar

        Call Controles(Boolean.FalseString)

    End Sub

    Public Sub Cancelar()

        Tipo = Operacion.Retorno
        Call Controles(Boolean.TrueString)

    End Sub

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Grabar()

        If Tab1.SelectedTab.Key <> "T02" And Tab1.SelectedTab.Key <> "T03" Then Return

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe Usuario para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Tipo = Operacion.Retorno Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim cont_area As Int32 = 0
        For i As Int32 = 0 To gridArea.Rows.Count - 1
            If gridArea.Rows(i).Cells("Action").Value = True Then cont_area += 1
        Next

        If cont_area = 0 And txtuserclonar.Text = "2 Then" Then
            MessageBox.Show("Debe asignar un área al usuario", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Txt1.EndUpdate()
        Txt2.EndUpdate()
        Txt3.EndUpdate()
        Txt4.EndUpdate()
        Txt5.EndUpdate()
        Grid2.PerformAction(ExitEditMode)
        Grid2.PerformAction(EnterEditMode)
        gridArea.PerformAction(ExitEditMode)
        gridArea.PerformAction(EnterEditMode)

        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario
        Entidad.Objecto = New ETObjecto

        Entidad.Usuario.Tipo = IIf(Not (Tipo = Operacion.Nuevo OrElse Tipo = Operacion.Modificar), Operacion.Retorno, IIf(Tipo = Operacion.Nuevo, 1, 2))
        Entidad.Usuario.Login = Txt1.Value
        Entidad.Usuario.Contrasenha = Txt2.Value
        Entidad.Usuario.Encargado = Txt4.Value
        Entidad.Usuario.Email = Txt5.Value
        Entidad.Usuario.Estado = Cbo1.Value
        Entidad.Usuario.Grupo = IIf(Not VerificarControl(4, Cbo2), String.Empty, Cbo2.Value)
        Entidad.Usuario.Usuario = User_Sistema
        Entidad.Usuario.PlaCod = Txt3.Value

        If ChkAdmin.Checked = True Then
            Entidad.Usuario.Admin = 1
        Else
            Entidad.Usuario.Admin = 0
        End If

        If chkAprobPedido.Checked = True Then
            Entidad.Usuario.AprobPedido = 1
        Else
            Entidad.Usuario.AprobPedido = 0
        End If

        If chkVerPedido.Checked = True Then
            Entidad.Usuario.VerPedidoxArea = 1
        Else
            Entidad.Usuario.VerPedidoxArea = 0
        End If

        

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Objecto = Negocio.Usuario.MantenimientoUsuario(Entidad.Usuario, ListModulos)

        If Entidad.Objecto.Validacion Then
            For i As Int32 = 0 To gridArea.Rows.Count - 1
                Entidad.Usuario.Area = gridArea.Rows(i).Cells("COD_MAESTRO2").Value
                Dim validacion As String = "*"
                Dim a As Boolean = gridArea.Rows(i).Cells("Action").Value
                If a = True Then
                    validacion = "1"
                End If
                Entidad.Usuario.ActionArea = validacion
                Negocio.Usuario.MantenimientoUsuarioArea(Entidad.Usuario)
            Next
        End If

        If txtuserclonar.Text <> "" Then
            If MsgBox("Desea clonar los accesos del usuario: " + txtuserclonar.Text, MsgBoxStyle.YesNo, "Sistemas") = MsgBoxResult.Yes Then
                Dim _objNegocio_ As NGProducto
                Dim _objEntidad_ As ETProducto
                _objNegocio_ = New NGProducto
                _objEntidad_ = New ETProducto
                Dim dt As New DataTable
                'usuario, user_ant, user_nuevo, pass, encargado, email, placod
                dt = _objNegocio_.ClonarUsuario(User_Sistema, txtuserclonar.Text, Txt1.Text, Txt2.Text, Txt4.Text, Txt5.Text, Txt3.Text)
                MsgBox("Permisos clonados correctamente", MsgBoxStyle.Information, "Sistemas")
                Call Iniciar()
            End If
        End If

        If Entidad.Objecto.Validacion Then Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)



    End Sub

#End Region

#Region "Procedimientos"

    Sub Controles(ByVal xBol As Boolean)

        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        txtuserclonar.ReadOnly = True 'Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Btn2.Enabled = Not xBol AndAlso Tipo = Operacion.Nuevo
        Txt2.ReadOnly = xBol
        Txt3.ReadOnly = xBol
        Txt5.ReadOnly = xBol
        Cbo1.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        Cbo3.ReadOnly = xBol
        ChkAdmin.Checked = xBol
        ChkMarcarTodo.Checked = xBol


        With Grid2.DisplayLayout.Bands(0)
            If xBol Then
                .Columns("Action").CellActivation = Activation.ActivateOnly
            Else
                .Columns("Action").CellActivation = Activation.AllowEdit
            End If
        End With

    End Sub

    Sub Limpiar()
        txtuserclonar.Clear()
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt4.Value = String.Empty
        Txt5.Value = String.Empty
        Cbo1.Value = EstadoUsuario.KeyActivo
        Ep1.Clear()
        Ep2.Clear()
        Cbo2.Value = Nothing
        Cbo3.Value = 0
        ChkAdmin.Checked = False
        chkAprobPedido.Checked = False
        ChkMarcarTodo.Checked = False
        chkVerPedido.Checked = False
        AreaUsuario("")
        ListModulos = New List(Of ETUsuario)
        Call CargarUltraGrid(Grid2, ListModulos)

    End Sub

    Sub Consultar_Usuario(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Call Limpiar()

        Txt1.Value = uRow.Cells("Usuario").Value
        Txt2.Value = uRow.Cells("Contrasenha").Value
        Txt4.Value = uRow.Cells("Encargado").Value
        Txt5.Value = uRow.Cells("Email").Value
        Cbo1.Value = uRow.Cells("Estado").Value

        If uRow.Cells("Admin").Value = "1" Then
            ChkAdmin.Checked = True

        Else
            ChkAdmin.Checked = False
        End If

        If uRow.Cells("AprobPedido").Value = "1" Then
            chkAprobPedido.Checked = True

        Else
            chkAprobPedido.Checked = False
        End If

        If uRow.Cells("VerPedidoxArea").Value = "1" Then
            chkVerPedido.Checked = True

        Else
            chkVerPedido.Checked = False
        End If

        Txt3.Value = uRow.Cells("PlaCod").Value

        Cbo2.Value = Nothing


        ListModulos = New List(Of ETUsuario)
        Call CargarUltraGrid(Grid2, ListModulos)
        AreaUsuario(Txt1.Value)
        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Sub Iniciar()

        Negocio.Usuario = New NGUsuario
        Entidad.MyLista = New ETMyLista

        Entidad.MyLista = Negocio.Usuario.ConsultarUsuario

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Usuario = New List(Of ETUsuario)
        Ls_Usuario = Entidad.MyLista.Ls_Usuario

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Usuario)

    End Sub

    Sub VerificarDisponibilidad()

        If String.IsNullOrEmpty(Txt1.Value) Then
            Ep1.SetError(Txt1, "Ingrese un Usuario para Verificar")
            Return
        End If

        Ep1.Clear()
        Ep2.Clear()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Usuario = New ETUsuario
        Entidad.Objecto = New ETObjecto

        Entidad.Usuario.Usuario = Txt1.Value.ToString.Trim

        Entidad.Objecto = Negocio.Usuario.ConsultarDisponibilidadUsuario(Entidad.Usuario)

        If Entidad.Objecto IsNot Nothing AndAlso Entidad.Objecto.Respuesta = 0 Then
            Ep1.SetError(Txt1, "El Usuario ya existe Registrado")
        Else
            Ep2.SetError(Txt1, "El Nuevo Usuario es Valido")
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

#Region "Funciones"

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt1.Value) Then
            Ep1.SetError(Txt1, "Ingrese un Usuario para Verificar")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt2.Value) Then
            Ep1.SetError(Txt2, "Ingrese la Contraseña del Usuario")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt4.Value) Then
            Ep1.SetError(Txt4, "Ingrese el Encargado de la Cuenta")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Ep1.SetError(Cbo1, "Ingrese el Estado del Usuario")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function

#End Region

    Private Sub _KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt3.KeyPress
        Dim DtProducto As New DataTable
        Select Case Asc(e.KeyChar)
            Case "13"
                Dim Lista As New FrmListarPlanilla
                Lista.ShowDialog()
                Txt3.Text = Trim(Lista.CODIGO & "")
                Txt4.Text = Trim(Lista.EMPLEADO & "")
        End Select
    End Sub

    Private Sub txtuserclonar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtuserclonar.KeyDown
        If e.KeyCode = 8 Or e.KeyCode = 46 Then
            txtuserclonar.Text = ""
        Else
            txtuserclonar.Text = "SI"
        End If
    End Sub

    Private Sub txtuserclonar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuserclonar.KeyPress
        Try
            If txtuserclonar.Text = "" Then
                Exit Sub
            End If
            Dim frm As New UsuarioClonar
            frm.ShowDialog()
            txtuserclonar.Text = ""
            txtuserclonar.Text = frm.usuario
        Catch ex As Exception

        End Try
    End Sub

    Sub AreaUsuario(ByVal usuario As String)
        Dim _objNegocio_ As NGProducto
        Dim _objEntidad_ As ETProducto
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        Dim dt As New DataTable
        dt = _objNegocio_.AreaUsuario(usuario)
        gridArea.DataSource = dt
    End Sub

    Private Sub cboSistema_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSistema.ValueChanged
        Try
            If cboSistema.Value = 1 Then
                Negocio.Sistemas = New NGSistema
                Cbo3.DataSource = Negocio.Sistemas.Consultar_SistemaDT
                Cbo3.ValueMember = "idSistema"
                Cbo3.DisplayMember = "Sistema"
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Cbo3.Value = 0
                'Cbo2.Visible = True
                'UltraLabel6.Visible = True
            Else
                Cbo3.DataSource = New DataTable
                Cbo2.DataSource = New DataTable
                'Cbo2.Visible = False
                'UltraLabel6.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridArea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridArea.InitializeLayout

    End Sub

    Private Sub UltraGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGroupBox1.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAprobPedido.CheckedChanged

    End Sub

    Private Sub ChkAdmin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAdmin.CheckedChanged

    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged

    End Sub

    Private Sub Txt1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt1.ValueChanged

    End Sub
End Class
