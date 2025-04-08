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
Public Class FrmSeguroLey
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim FRM As New FrmListadoPersonal
            FRM.ShowDialog()
            If codTrabajador.ToString.Trim = "" Then Return
            TxtCodigoTrabajador.Text = codTrabajador.ToString.Trim
            TxtNombresTrabajador.Text = nomTrabajador.ToString.Trim
            txtseguro.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtseguro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtseguro.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
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
        _objEntidad.CodProducto = TxtCodigoTrabajador.Text
        _objEntidad.Monto = txtseguro.Text
        _objEntidad.Usuario = User_Sistema
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Costo_RegistraSeguro(_objEntidad)
        MsgBox("Cambios realizados correctamente", MsgBoxStyle.Information, msgComacsa)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class