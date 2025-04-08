Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmOrdenes
    Public ayo As Int32
    Public mes As Int32
    Public codprov As String
    Sub CargarDatos()
        Try
            Dim objNegocio As NGContratista = Nothing
            Dim objEntidad As ETContratista = Nothing
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._ayo = ayo
            objEntidad._mes = mes
            objEntidad._codprov = codprov
            Dim dtContratista As New DataTable
            dtContratista = objNegocio.ListarOrden(objEntidad)
            If dtContratista.Rows.Count = 0 Then
                MsgBox("No existen datos", MsgBoxStyle.Exclamation, msgComacsa)
                Me.Close()
            End If
            Call CargarUltraGridxBinding(gridordenes, Source1, dtContratista)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmOrdenes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub

    Private Sub gridordenes_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridordenes.DoubleClickRow
        Try
            orden = gridordenes.ActiveRow.Cells("NRO_OC").Value.ToString.Trim
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class