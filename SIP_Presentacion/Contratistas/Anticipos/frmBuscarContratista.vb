Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmBuscarContratista
    Public tipo As String
    Sub CargarDatos()
        Try
            Dim objNegocio As NGContratista = Nothing
            objNegocio = New NGContratista
            Dim dtContratista As New DataTable
            dtContratista = objNegocio.ListarContratistaConsulta(Companhia, tipo)
            Call CargarUltraGridxBinding(gridcontratista, Source1, dtContratista)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmBuscarContratista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub

    Private Sub gridcontratista_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridcontratista.DoubleClickRow
        Try
            codContratista = gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            Contratista = gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class