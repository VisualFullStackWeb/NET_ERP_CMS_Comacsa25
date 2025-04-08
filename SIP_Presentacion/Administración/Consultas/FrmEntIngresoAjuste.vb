Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class FrmEntIngresoAjuste
    Public codTrabajador As String
    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Try
            verificaestadoContable()
            If estadoContable = 1 Then
                MsgBox("El período contable se encuentra cerrado", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If

            If MsgBox("Desea generar el ajuste del saldo?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            Dim dtDatos As New DataTable
            With oPrvFisE
                .Ope = 1
                .id = 0
                .cod_trabajador = codTrabajador
                .Monto = txtimporte.Text
                .User_Crea = User_Sistema
                .tipo_mov = cmbMovimiento.Value
                .Fecha = dtpFecha.Value
            End With
            dtDatos = oPrvFisN.AjustesDifCambio(oPrvFisE)
            MsgBox("Registro generado correctamente", MsgBoxStyle.Information, msgComacsa)
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Dim estadoContable As Int32 = 0
    Sub verificaestadoContable()
        Entidad.Entregas.añocontable = Convert.ToInt32(Year(dtpFecha.Value))
        Entidad.Entregas.mescontable = Convert.ToInt32(Month(dtpFecha.Value))
        Entidad.MyLista = Negocio.NEntregas.VerificaCierreContable(Entidad.Entregas)
        'lResult = New ETMyLista
        'lResult = Entidad.MyLista

        If Entidad.MyLista.Ls_Entrega.Count = 0 Then
            estadoContable = 0
        Else
            estadoContable = Entidad.MyLista.Ls_Entrega.Item(0).estadocontable
        End If
    End Sub

    Private Sub txtmarca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtimporte.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub cmbMovimiento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMovimiento.ValueChanged
        Try
            txtimporte.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtimporte_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtimporte.ValueChanged

    End Sub
End Class