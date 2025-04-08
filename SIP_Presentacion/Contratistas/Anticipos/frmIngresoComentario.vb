Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class frmIngresoComentario
    Public COD_PROV As String
    Public FECHA1 As Date
    Public COD_CANTERA As String
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Dim dtDatos As DataTable
    Private Sub frmIngresoComentario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'billeteExistente(txtbillete.Text)
        'If dtDatos.Rows.Count <= 0 Then
        '    MsgBox("El billete no existe para el contratista", MsgBoxStyle.Exclamation, msgComacsa)
        '    txtbillete.Clear()
        '    txtbillete.Focus()
        '    Exit Sub
        'End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmIngresoComentario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        billeteExistente("")
        If dtDatos.Rows.Count <= 0 Then
            MsgBox("No hay datos para mostrar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Dim frm As New frmverBillete
        frm.dtBillete = dtDatos
        frm.ShowDialog()
        txtbillete.Text = frm.gridBillete.ActiveRow.Cells("NUMDOC").Value.ToString.Trim
        txtcomentario.Focus()
    End Sub
    Sub billeteExistente(ByVal billete As String)
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._fecha1 = FECHA1
        objEntidad._codcantera = COD_CANTERA
        objEntidad._codprov = COD_PROV
        objEntidad._billete = billete
        dtDatos = New DataTable
        dtDatos = objNegocio.billeteExistente(objEntidad)
    End Sub

    Private Sub txtbillete_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbillete.KeyDown
        If e.KeyData = Keys.Return Then
            billeteExistente(txtbillete.Text)
            If dtDatos.Rows.Count <= 0 Then
                MsgBox("El billete no existe para el contratista", MsgBoxStyle.Exclamation, msgComacsa)
                txtbillete.Clear()
                txtbillete.Focus()
                Exit Sub
            End If
            txtcomentario.Focus()
        End If
    End Sub

    Private Sub txtbillete_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbillete.LostFocus
        
    End Sub
End Class