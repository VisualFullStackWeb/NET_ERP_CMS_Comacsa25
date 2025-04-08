Imports SIP_Negocio
Imports SIP_Entidad

Public Class FrmCambioPassword

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Locales"

#Region "Validar - Usuario"
    Private Function ValidarUsuario() As Boolean
        Dim dtPassword As New DataTable
        With Entidad.Usuario
            .Sistema = gsistema
            .Contrasenha = Trim(TxtPasswordActual.Text & "")
            .Login = User_Sistema
        End With
        If Negocio.Usuario.Users(Entidad.Usuario) = False Then
            MsgBox("La contraseña NO es correcta.", MsgBoxStyle.Critical, "Comacsa")
            TxtPasswordActual.Clear()
            TxtPasswordActual.Focus()
        End If

        If Len(TxtPasswordNuevo.Text) > 10 Then
            MsgBox("Se ha sobrepasado la cantidad máxima de caracteres.", MsgBoxStyle.Critical, "Comacsa")
            TxtPasswordNuevo.Clear()
            TxtPasswordNuevo.Focus()
            Return False
        End If

        If Len(TxtConfirmarPassword.Text) > 10 Then
            MsgBox("Se ha sobrepasado la cantidad máxima de caracteres.", MsgBoxStyle.Critical, "Comacsa")
            TxtConfirmarPassword.Clear()
            TxtConfirmarPassword.Focus()
            Return False
        End If


        If Trim(TxtPasswordNuevo.Text & "") <> Trim(TxtConfirmarPassword.Text & "") Then
            MsgBox("Los datos del Password Nuevo NO coinciden.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If
        Return True
    End Function
#End Region

#End Region   'Funciones Locales

#Region "Funciones Publicas"

#Region "Grabar"
    Public Sub Grabar()
        If MsgBox("¿Esta seguro de MODIFICAR la contraseña?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            With Entidad.Usuario
                .Cod_Cia = Companhia
                .Sistema = gSistema
                .Login = User_Sistema
                .Contrasenha = Trim(TxtPasswordNuevo.Text & "")
            End With
            Entidad.Resultado = Negocio.Usuario.UpdateCambioPassword(Entidad.Usuario)

            If Entidad.Resultado.Realizo = True Then
                MsgBox("El cambio de contraseña se realizó con éxito.", MsgBoxStyle.Information, "Comacsa")
                Me.Close()
                Me.Finalize()
            End If
        End If
    End Sub
#End Region

#End Region  'Funciones Públicas

#Region "Load"
    Private Sub FrmCambioPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtLogin.Text = User_Sistema
    End Sub
#End Region                'Load

End Class