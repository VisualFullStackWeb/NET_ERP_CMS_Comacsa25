Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Public Class FrmBAyuda

    Private ET_Usuario As ETUsuario
    Public Formulario As String = String.Empty

    Sub FrmBAyuda_Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario
        ET_Usuario = New ETUsuario

        Entidad.Usuario.KeyForm = Formulario

        ET_Usuario = Negocio.Usuario.ConsultarAyuda(Entidad.Usuario)

        If Not ET_Usuario.Validacion Then
            Ftxt1.Value = String.Empty
        Else
            Ftxt1.Value = ET_Usuario.ValorxTexto
        End If

    End Sub

End Class