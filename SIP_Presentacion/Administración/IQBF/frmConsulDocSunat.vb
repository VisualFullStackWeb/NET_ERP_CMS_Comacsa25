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
Public Class frmConsulDocSunat

    Private Sub frmConsulDocSunat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        oPrvFisN = New NGProveedorFiscalizado
        oPrvFisE = New ETProveedorFiscalizado
        Dim dtDatos As New DataTable
        dtDatos = oPrvFisN.TipoguiaSunat()
        Call CargarUltraGridxBinding(Grid1, Source1, dtDatos)
    End Sub

    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot Grid1 Then Return
        If e.Row.IsFilterRow Then Return
        SeleccionarConcepto(e.Row)
    End Sub

    Sub SeleccionarConcepto(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If
        Motivodetalle = uRow.Cells("DESCRIPCION").Value.ToString.ToUpper
        Me.Close()

    End Sub
    Private Sub Grid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If e.KeyValue = Keys.Return Then
            If Grid1.ActiveRow.Index < 0 Then MsgBox("Seleccione tipo documento", MsgBoxStyle.Exclamation, msgComacsa) : Return
            Motivodetalle = Grid1.Rows(Grid1.ActiveRow.Index).Cells("DESCRIPCION").Value.ToString.ToUpper
            Me.Close()
        End If
    End Sub
End Class