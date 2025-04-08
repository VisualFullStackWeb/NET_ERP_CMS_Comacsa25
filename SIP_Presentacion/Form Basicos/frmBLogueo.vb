Imports System.Configuration
Imports System
Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Windows.Forms
Imports System.Security.Principal
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.Misc
Imports Infragistics.Win.Misc.UltraButton
Public Class FrmBLogueo

#Region "Variables"

    Private Contador As Int16 = 0

#End Region

#Region "Eventos"

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _
                     btn1.Click, btn2.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is btn2 Then End

        If sender Is btn1 Then Call Ingresar()

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Initialize()

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles _
                       Me.KeyDown, Txt1.KeyDown, Txt2.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.KeyCode = Keys.Escape Then End

        If Not (e.KeyCode = Keys.Enter AndAlso sender IsNot Me) Then Return

        If sender Is Txt1 Then Txt2.Focus()

        If sender Is Txt2 Then
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Call Ingresar()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End If


    End Sub

#End Region

#Region "Funciones"

    Function Validar() As Boolean

        Validar = Boolean.FalseString

        If String.IsNullOrEmpty(Txt1.Value) Then
            MessageBox.Show("Ingrese el Usuario", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Else
            User_Sistema = Txt1.Value.ToString.Trim
        End If

        If String.IsNullOrEmpty(Txt2.Value) Then
            MessageBox.Show("Ingrese la Contraseña", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Else
            Contrasenha_Sistema = Txt2.Value.ToString.Trim
        End If

        Return Boolean.TrueString

    End Function

#End Region

#Region "Procedimiento"

    Sub Ingresar()

        If Not Validar() Then Return

        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario

        Entidad.Usuario.Tipo = Convert.ToInt16(Permisos.Ingreso)
        Entidad.Usuario.Usuario = User_Sistema
        Entidad.Usuario.Contrasenha = Contrasenha_Sistema

        Entidad.Objecto = New ETObjecto

        Entidad.Objecto = Negocio.Usuario.ConsultarPermisos(Entidad.Usuario)

        If Not Entidad.Objecto.Validacion Then
            Contador += 1 : If Contador >= 3 Then End
            pic1.Image = Global.SIP_Presentacion.My.Resources.Resources.ClaveErronea
            pic1.Refresh()
            Return
        Else
            pic1.Image = Global.SIP_Presentacion.My.Resources.Resources.Candado___Open
            pic1.Refresh()

        End If

        REM Conectamos al Servidor

        Entidad.Objecto = New ETObjecto
        Negocio.Usuario = New NGUsuario
        Entidad.Objecto.Tipo = 1
        Entidad.Objecto = Negocio.Usuario.ConsultarConexion(Entidad.Objecto)

        If Not Entidad.Objecto.Validacion Then End

        Servidor_App = Entidad.Objecto.ValorxTexto.ToUpper

        REM Conectamos a la BD

        Entidad.Objecto = New ETObjecto
        Negocio.Usuario = New NGUsuario
        Entidad.Objecto.Tipo = 2
        Entidad.Objecto = Negocio.Usuario.ConsultarConexion(Entidad.Objecto)

        If Not Entidad.Objecto.Validacion Then End

        BD_App = Entidad.Objecto.ValorxTexto.ToUpper

        REM ---------------------------
        User_Sistema = Entidad.Usuario.Usuario

        REM Datos del Usuario
        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario
        Dim DT As New DataTable
        With Entidad.Usuario
            .Sistema = Sistema
            .Cod_Cia = Companhia
            .Login = User_Sistema
        End With

        DT = Negocio.Usuario.ListarUsers(Entidad.Usuario, "DUS")

        gAreaEmpleado = Negocio.Usuario.ObtenerArea_Usuario(Entidad.Usuario, "OAU")
        Entidad.Usuario.Area = gAreaEmpleado
        gAreaMantto = Negocio.Usuario.ObtenerArea_Mantto(Entidad.Usuario, "OAM")

        If DT IsNot Nothing Then
            If DT.Rows.Count > 0 Then
                gAdmin = DT.Rows(0).Item("Administrador")
                codTrabajadorInicio = DT.Rows(0).Item("placod")
                nomTrabajadorInicio = DT.Rows(0).Item("nombre")
            End If
        End If

        StrucForm.FxBxMain.Show()
        StrucForm.FxBxBase.Close()

        'leer la conexion del appconfig y grabarlo en memoria, en la clase condfigapp
        SIP_Entidad.ConfigApp.Data.ConexionBD = ConfigurationManager.ConnectionStrings("cn").ConnectionString


        'leer la conexion del appconfig y grabarlo en memoria, en la clase condfigapp
        SIP_Entidad.ConfigApp.Data.ConexionBD = ConfigurationManager.ConnectionStrings("cn").ConnectionString

        Hide()

    End Sub

    Sub Initialize()

        Entidad.Objecto = New ETObjecto
        Negocio.Usuario = New NGUsuario
        Entidad.Objecto.Tipo = 3
        Entidad.Objecto = Negocio.Usuario.ConsultarFechaHora(Entidad.Objecto)

        If Not Entidad.Objecto.Validacion Then End

        lblVersion.Text = String.Format("(  Version: {0}  )", ObtenerNumeroDeVersionSistema())

        'StrucForm.FxBxBase.Show()
        Activate()
        Show()

        Txt1.Value = Terminal
        Txt1.Focus()
        Txt1.SelectAll()

        Dim nomMaquina As String = Environment.MachineName

        If nomMaquina.ToUpper = "RODA-HVILELA".ToUpper Or nomMaquina.ToUpper = "RDPCFMC28".ToUpper Then
            Txt2.Value = "1saposa5"
        End If

    End Sub

#End Region

    Private Sub UltraGroupBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGroupBox2.Click

    End Sub
End Class
