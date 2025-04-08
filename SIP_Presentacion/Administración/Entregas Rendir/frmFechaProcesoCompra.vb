Public Class frmFechaProcesoCompra

    Private Sub frmFechaProcesoCompra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFechaProceso.Value = Now.Date
        dtFechaProceso.Enabled = True
        dtFechaProceso.ReadOnly = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class