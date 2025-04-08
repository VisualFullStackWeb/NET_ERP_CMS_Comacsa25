Imports System.Text
Imports System.Net.Mail
Imports System.ComponentModel
Imports SIP_Entidad
Imports SIP_Negocio

Imports Infragistics.Win.UltraWinGrid
Imports CrystalDecisions.CrystalReports.Engine

Public Class FemIndicadorLab
    Public Ls_Permisos As New List(Of Integer)

    Private Sub FemIndicadorLab_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
    End Sub

    Sub indicador()
        If cmbMes.SelectedIndex < 0 Then Exit Sub
        If cmbMes1.SelectedIndex < 0 Then Exit Sub
        Dim dtindicador As DataTable
        Dim NReclamo As New NGReclamo
        dtindicador = NReclamo.Reclamo_IndicadorLab(txtayo.Value, cmbMes.SelectedIndex - 1, cmbMes1.SelectedIndex + 1)
        If dtindicador.Rows.Count > 0 Then
            txtreclamotiempo.Text = dtindicador.Rows(0)(0)
            txttotalreclamo.Text = dtindicador.Rows(0)(1)
            txtindicador.Text = dtindicador.Rows(0)(2)
        End If
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try

        Catch ex As Exception
            indicador()
        End Try
    End Sub

    Private Sub cmbMes1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes1.ValueChanged
        indicador()
    End Sub
End Class