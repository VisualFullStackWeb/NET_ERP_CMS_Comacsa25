Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmCEnvioSuministrosCantera
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Sub _Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia)
        Me.WindowState = FormWindowState.Normal
    End Sub

    Public Sub Reporte()

        Dim Reporte As New Rpt_Suministros_EnvioCantera
        Dim Reporte1 As New Rpt_VidaUtil
        StrucForm.FxEnvioCantera = New Rpt_Suministros_EnvioCantera
        StrucForm.FxVidaUtil = New Rpt_VidaUtil
        GFechaInicio = dtInicio.Value
        GFechaFin = dtFin.Value

        If (ChkTodos.Checked = False And ChkRenovar.Checked = False) Or (ChkTodos.Checked = True And ChkRenovar.Checked = True) Then
            MsgBox("Seleccione alguna de las opciones", MsgBoxStyle.Critical, "Comacsa")
            Return
        End If

        If ChkFecha.Checked = True And ChkTodos.Checked = True Then
            GOpcion = 3
            StrucForm.FxEnvioCantera.NombreReporte = "Suministros Enviados A Cantera"
            StrucForm.FxEnvioCantera.MdiParent = MdiParent
            StrucForm.FxEnvioCantera.Show()

            'ElseIf ChkFecha.Checked = True And ChkRenovar.Checked = True Then
            '    GOpcion = 4
            '    StrucForm.FxVidaUtil.NombreReporte = "Vida Util de Suministros Enviados a Cantera"
            '    StrucForm.FxVidaUtil.MdiParent = MdiParent
            '    StrucForm.FxVidaUtil.Show()

        ElseIf ChkTodos.Checked = True Then
            GOpcion = 1
            StrucForm.FxEnvioCantera.NombreReporte = "Suministros Enviados A Cantera"
            StrucForm.FxEnvioCantera.MdiParent = MdiParent
            StrucForm.FxEnvioCantera.Show()
        ElseIf ChkRenovar.Checked = True Then
            GOpcion = 2
            StrucForm.FxVidaUtil.NombreReporte = "Vida Util de Suministros Enviados a Cantera"
            StrucForm.FxVidaUtil.MdiParent = MdiParent
            StrucForm.FxVidaUtil.Show()
        End If
    End Sub

    Private Sub ChkFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFecha.CheckedChanged
        If ChkFecha.Checked = True Then
            dtInicio.Enabled = True
            dtFin.Enabled = True
        Else
            dtInicio.Enabled = False
            dtFin.Enabled = False
        End If
    End Sub

End Class