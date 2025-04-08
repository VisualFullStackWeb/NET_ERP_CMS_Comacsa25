Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class FrmDiasHabiles
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Private Sub FrmDiasHabiles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtdias.Focus()
    End Sub

    Private Sub btnnuevod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevod.Click
        If MsgBox("Desea registrar cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Exit Sub
        End If
        'MsgBox(cadOrden)

        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Tipo = 1
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Mes = cmbMes.Value
        _objEntidad.Dia = txtdias.Text
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Costo_RegistraDias(_objEntidad)
        MsgBox("Cambios realizados correctamente", MsgBoxStyle.Information, msgComacsa)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtdias_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdias.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub
End Class