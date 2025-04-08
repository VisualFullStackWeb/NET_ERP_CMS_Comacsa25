Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmMFormularios

#Region "Variables"

    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private Ls_Usuario As List(Of ETUsuario) = Nothing
    Private ListModulos As DataTable = Nothing
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

    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

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
                       Txt2.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return

        If sender Is Txt2 Then
            Txt2.SelectAll()
            Txt2.Focus()
        End If

        If sender Is Txt2 Then
            CboSistema.SelectAll()
            CboSistema.Focus()
        End If

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then

            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                uColumn.CellActivation = Activation.ActivateOnly
                If Not (uColumn.Key = "Sistema" Or uColumn.Key = "Grupo" Or _
                        uColumn.Key = "Formulario" Or uColumn.Key = "Estado") Then
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
        Tipo = Operacion.Retorno
        Call Consultar_Formulario(e.Row)

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) _
                             Handles Grid1.InitializeRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return


    End Sub

    Sub Evento_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CboGrupo.ValueChanged, CboSistema.ValueChanged


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is CboSistema Then
            Entidad.Usuario = New ETUsuario
            Negocio.Usuario = New NGUsuario
            ListModulos = New DataTable

            Entidad.Usuario.Sistema = CboSistema.Value

            CboGrupo.DataSource = Negocio.Usuario.ListarFormulario(Entidad.Usuario, 4)
            CboGrupo.ValueMember = "ID"
            CboGrupo.DisplayMember = "Grupo"

            CboGrupo.Value = 0

            Entidad.Usuario = New ETUsuario
            Negocio.Usuario = New NGUsuario

            Entidad.Usuario.Sistema = CboSistema.Value
            Entidad.Usuario.Grupo = CboGrupo.Value

            CboFormulario.DataSource = Negocio.Usuario.ListarFormulario(Entidad.Usuario, 3)
            CboFormulario.ValueMember = "ID"
            CboFormulario.DisplayMember = "Formulario"

        End If


        If sender Is CboGrupo Then

            Entidad.Usuario = New ETUsuario
            Negocio.Usuario = New NGUsuario

            Entidad.Usuario.Sistema = CboSistema.Value
            Entidad.Usuario.Grupo = CboGrupo.Value

            CboFormulario.DataSource = Negocio.Usuario.ListarFormulario(Entidad.Usuario, 3)
            CboFormulario.ValueMember = "ID"
            CboFormulario.DisplayMember = "Formulario"

        End If

    End Sub

    Sub Evento_DoubleClickHeader(ByVal sender As Object, ByVal e As DoubleClickHeaderEventArgs)


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.Header.Column.Key.ToString <> "Action" Then Return

        If ListModulos Is Nothing OrElse ListModulos.Rows.Count = 0 OrElse Tipo = 0 Then
            Return
        End If

        sender.Refresh()

    End Sub

#End Region

#Region "Publicos"

    Public Sub Nuevo()

        Tipo = Operacion.Nuevo
        Call Limpiar()
        Call Controles(Boolean.FalseString)
        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Public Sub Modificar()

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Not VerificarControl(1, Txt2) Then
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

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Not VerificarControl(1, Txt2) Then
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

        Txt1.EndUpdate()
        Txt2.EndUpdate()


        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario
        Entidad.Objecto = New ETObjecto

        With Entidad.Usuario
            .ID = Txt1.Value
            .Formulario = Txt2.Value
            .Sistema = CboSistema.Value
            .Grupo = CboGrupo.Value
            .Estado = CboEstado.Value
            If .Estado = "A" Then
                .Estado = ""
            ElseIf .Estado = "E" Then
                .Estado = "*"
            Else
                .Estado = "I"
            End If

            .Tipo = CboTipo.Value
        End With


        If CboFormulario.Value = Nothing Then
            Entidad.Usuario.KeyForm = "0"
        Else
            Entidad.Usuario.KeyForm = CboFormulario.Value
        End If

        Entidad.Usuario.Usuario = User_Sistema
        Entidad.Usuario.Jerarquia = CboNivel.Value


        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.Usuario.GrabarFormulario(Entidad.Usuario)

        If Entidad.Resultado.Realizo Then
            MsgBox("Se guardó con éxito el registro N°: " & Entidad.Resultado.Mensaje, MsgBoxStyle.Information, "Comacsa")
        End If
 
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

        Call Iniciar()

    End Sub

#End Region

#Region "Procedimientos"

    Sub Controles(ByVal xBol As Boolean)
        Txt2.ReadOnly = xBol
        CboEstado.ReadOnly = xBol
        CboFormulario.ReadOnly = xBol
        CboNivel.ReadOnly = xBol
        CboSistema.ReadOnly = xBol
        CboTipo.ReadOnly = xBol
        CboGrupo.ReadOnly = xBol
    End Sub

    Sub Limpiar()

        Txt1.Clear()
        Txt2.Value = String.Empty
        CboEstado.Value = 0
        CboFormulario.Value = 0
        CboGrupo.Value = 0
        CboNivel.Value = 20
        CboSistema.Value = 0
        CboTipo.Value = 20

    End Sub

    Sub Consultar_Formulario(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Call Limpiar()

        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("Formulario").Value

        CboEstado.Value = Mid((uRow.Cells("Estado").Value), 1, 1)

        CboNivel.Value = uRow.Cells("Jerarquia").Value

        CboSistema.Value = uRow.Cells("IDSistema").Value

        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario


        Entidad.Usuario.Sistema = CboSistema.Value
        Entidad.Usuario.Grupo = CboGrupo.Value

        '*
        CboFormulario.DataSource = Negocio.Usuario.ListarFormulario(Entidad.Usuario, 3)
        CboFormulario.ValueMember = "ID"
        CboFormulario.DisplayMember = "Formulario"
        CboFormulario.Value = uRow.Cells("KeyForm").Value
        '*

        CboGrupo.DataSource = Negocio.Usuario.ListarFormulario(Entidad.Usuario, 4)
        CboGrupo.ValueMember = "ID"
        CboGrupo.DisplayMember = "Grupo"
        CboGrupo.Value = uRow.Cells("IDGrupo").Value

        CboTipo.Value = uRow.Cells("Tipo").Value

        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Sub Iniciar()

        Negocio.Usuario = New NGUsuario
        Entidad.MyLista = New ETMyLista

        Entidad.MyLista = Negocio.Usuario.ListarFormulario

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Usuario = New List(Of ETUsuario)
        Ls_Usuario = Entidad.MyLista.Ls_Usuario

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Usuario)
        Tab1.Tabs("T01").Selected = Boolean.TrueString
    End Sub

    Sub VerificarDisponibilidad()

        If String.IsNullOrEmpty(Txt2.Value) Then
            Ep1.SetError(Txt2, "Ingrese un Usuario para Verificar")
            Return
        End If

        Ep1.Clear()
        Ep2.Clear()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Usuario = New ETUsuario
        Entidad.Objecto = New ETObjecto

        Entidad.Usuario.Usuario = Txt2.Value.ToString.Trim

        Entidad.Objecto = Negocio.Usuario.ConsultarDisponibilidadUsuario(Entidad.Usuario)

        If Entidad.Objecto IsNot Nothing AndAlso Entidad.Objecto.Respuesta = 0 Then
            Ep1.SetError(Txt2, "El Usuario ya existe Registrado")
        Else
            Ep2.SetError(Txt2, "El Nuevo Usuario es Valido")
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

#Region "Funciones"

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString


        If String.IsNullOrEmpty(Txt2.Value) Then
            Ep1.SetError(Txt2, "Ingrese el Nombre del Formulario")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(CboSistema.Value) Then
            Ep1.SetError(CboSistema, "Ingrese el Sistema del Formulario")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(CboGrupo.Value) Then
            Ep1.SetError(CboGrupo, "Ingrese el Grupo del Formulario")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(CboTipo.Value) Then
            Ep1.SetError(CboTipo, "Ingrese el Grupo del Formulario")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(CboNivel.Value) Then
            Ep1.SetError(CboNivel, "Ingrese el Nivel del Formulario")
            lResult = Boolean.FalseString
        End If

        If CboNivel.Value > 0 Then
            If String.IsNullOrEmpty(CboFormulario.Value) Then
                Ep1.SetError(CboFormulario, "Ingrese el Formulario Padre asignado")
                lResult = Boolean.FalseString
            End If
        End If

        If String.IsNullOrEmpty(CboEstado.Value) Then
            Ep1.SetError(CboEstado, "Ingrese el Estado del Formulario")
            lResult = Boolean.FalseString
        End If


        Return lResult

    End Function

#End Region

End Class
