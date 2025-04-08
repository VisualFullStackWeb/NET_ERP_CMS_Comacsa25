Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmValidarUsuarioRecojo

#Region "Load"
    Private Sub FrmValidarUsuarioRecojo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        txtUsuario.Focus()
    End Sub
#End Region                'Load

#Region "Eventos Controles"

#Region "Boton Validar"
    Private Sub btnValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidar.Click
        With Entidad.Usuario
            .Cod_Cia = Companhia
            .Login = txtUsuario.Text
            .Contrasenha = txtClave.Text
            .Sistema = gSistema
        End With
        Dim dtUsuario As New DataTable
        dtUsuario = Negocio.Usuario.ListarUsers(Entidad.Usuario, "VAL")
        If dtUsuario.Rows.Count > 0 Then
            MsgBox("Los datos son correctos", MsgBoxStyle.Information, "Comacsa")
            GUsuarioRecojo = dtUsuario.Rows(0).Item("NombreUsuario")
            GCodigoUsuarioRecojo = dtUsuario.Rows(0).Item("CodigoUsuario")
            Me.Close()
        Else
            MsgBox("Usuario y/o Password Incorrectos", MsgBoxStyle.Critical, "Comacsa")
            txtClave.Clear()
            txtUsuario.Clear()
            txtUsuario.Focus()

        End If
    End Sub

#End Region

#Region "Boton Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
#End Region

#End Region   'Eventos Controles

End Class