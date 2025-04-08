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
Public Class FrmIngresaCampaña
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Private Sub FrmIngresaCampaña_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If txtid.Text.ToString.Trim = "" Then txtid.Text = 0
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Try
            Dim dtDatos As New DataTable
            dtDatos = New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.ID = txtid.Text
            _objEntidad.CodEquipo = txtcodequipo.Text
            _objEntidad.Equipo = txtequipo.Text
            _objEntidad.FechaInicio = dtpInicio.Value
            _objEntidad.FechaTerminacion = dtpFin.Value
            _objEntidad.Tipo = 1
            _objEntidad.numdoc = txtnumero.Text
            dtDatos = _objNegocio.MANT_PARA_CAMPANIA(_objEntidad)
            If dtDatos.Rows(0)(0) = "OK" Then
                MsgBox("Grabado Correctamente", MsgBoxStyle.Information, "Aviso")
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcodequipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodequipo.KeyPress
        Buscar()
    End Sub

    Sub Buscar()
        If txtcodequipo.Focused = True Then
            Dim frmEquipo As New frmBuscar
            frmEquipo.Formulario = frmBuscar.eState.frm_Catalogo_molino
            frmEquipo.ShowDialog()
            txtcodequipo.Text = frmEquipo.Flag2
            txtequipo.Text = frmEquipo.Descripcion
            frmEquipo = Nothing
            Exit Sub
        End If
    End Sub
End Class