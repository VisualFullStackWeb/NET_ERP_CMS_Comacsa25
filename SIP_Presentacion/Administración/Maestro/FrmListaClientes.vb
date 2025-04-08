Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmListaClientes
    Sub CargarDatos()
        Try
            Dim objNegocio As NGContratista = Nothing
            objNegocio = New NGContratista
            Dim dtCliente As New DataTable
            dtCliente = objNegocio.ListarClientes()
            Call CargarUltraGridxBinding(gridcliente, Source1, dtCliente)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmListaClientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub

    Private Sub gridcliente_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridcliente.DoubleClickRow
        Try
            codCliente = gridcliente.ActiveRow.Cells("COD_CLI").Value.ToString.Trim
            Cliente = gridcliente.ActiveRow.Cells("CLIENTE").Value.ToString.Trim
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class