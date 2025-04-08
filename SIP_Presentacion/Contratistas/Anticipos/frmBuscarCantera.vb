Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmBuscarCantera
    Public codprov As String
    Public Sub CargarDatos()
        Try
            Dim objNegocio As NGContratista = Nothing
            Dim objEntidad As ETContratista = Nothing
            objNegocio = New NGContratista
            objEntidad = New ETContratista

            objEntidad._codprov = codprov

            Dim dtContratista As New DataTable
            dtContratista = objNegocio.ListarCantera(objEntidad)
            Call CargarUltraGridxBinding(gridcontratista, Source1, dtContratista)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmBuscarCantera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub

    Private Sub gridcontratista_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridcontratista.DoubleClickRow
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class