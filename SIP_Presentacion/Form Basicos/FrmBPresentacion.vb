Public NotInheritable Class FrmBPresentacion

    Private Sub FrmBPresentacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Version.Text = String.Format("Version: {0}", ObtenerNumeroDeVersionSistema())
    End Sub
End Class
