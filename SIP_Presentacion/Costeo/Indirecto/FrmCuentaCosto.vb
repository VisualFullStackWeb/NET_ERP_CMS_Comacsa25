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
Public Class FrmCuentaCosto
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Public dtDatos As New DataTable
    Private Sub FrmCuentaCosto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            '_objNegocio = New NGProducto
            '_objEntidad = New ETProducto
            '_objEntidad.Anho = Year(Now.Date)
            'dtDatos = _objNegocio.Costo_ListaCuentas(_objEntidad)
            Call CargarUltraGridxBinding(Me.gridCuenta, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub gridCuenta_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridCuenta.DoubleClickRow
        Try
            If gridCuenta.ActiveRow.Index < 0 Then Exit Sub
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class