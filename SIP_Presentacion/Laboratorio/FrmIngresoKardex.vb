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
Public Class FrmIngresoKardex
    Public movi As String
    Public cod_prod As String
    Public cod_sunat As String
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Private Sub FrmIngresoKardex_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFecha.Value = Now.Date
    End Sub

    Private Sub txtcodCantera_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        Try
            If txtcantidad.Text = "" Then txtcantidad.Text = 0
            If txtcantidad.Text = 0 Then
                MsgBox("Ingrese una cantidad correcta", MsgBoxStyle.Information, msgComacsa)
                txtcantidad.Focus()
                Exit Sub
            End If
            If cmbMovimiento.SelectedIndex < 0 Then
                MsgBox("Ingrese un tipo de movimiento", MsgBoxStyle.Information, msgComacsa)
                Exit Sub
            End If

            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad.Operacion = 1
            objEntidad._id = 0
            objEntidad._cod_prod = cod_prod
            objEntidad._cod_sunat = cod_sunat
            objEntidad._movi = cmbMovimiento.Value
            objEntidad.Fecha = dtFecha.Value
            objEntidad.Cantidad = txtcantidad.Text
            objEntidad._marca = txtmarca.Text
            objEntidad._concentracion = txtconcentracion.Text
            objEntidad._observacion = txtobservacion.Text
            objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.IngresoIQBFkardex(objEntidad)
            If dtDatos.Rows.Count > 0 Then
                If dtDatos.Rows(0)(0) = "OK" Then
                    MsgBox("Se guardaron correctamente los datos", MsgBoxStyle.Information, msgComacsa)
                    Me.Close()
                Else
                    MsgBox(dtDatos.Rows(0)(0), MsgBoxStyle.Information, msgComacsa)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMovimiento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMovimiento.ValueChanged
        Try
            If cmbMovimiento.Value = "I" Then
                txtmarca.Focus()
                txtmarca.ReadOnly = False
                txtconcentracion.ReadOnly = False
            Else
                txtcantidad.Focus()
                txtmarca.ReadOnly = True
                txtconcentracion.ReadOnly = True
                txtmarca.Text = ""
                txtconcentracion.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class