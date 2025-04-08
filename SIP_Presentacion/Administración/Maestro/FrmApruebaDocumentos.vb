Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class FrmApruebaDocumentos
#Region "Variables"
    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private ListModulos As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim Ope = 1
#End Region
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista
    Private Sub FrmApruebaDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbtipo.Value = "T"
        dtpDesde.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
        dtpHasta.Value = Now.Date
    End Sub
    Sub Procesar()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._fecha1 = dtpDesde.Value
            objEntidad._fecha2 = dtpHasta.Value
            objEntidad._codcli = txtcodcliente.Text
            objEntidad._tipodocumento = cmbtipo.Value
            objEntidad._documento = txtnumdoc.Text
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.ListarDocumentoAprobar(objEntidad)
            Call CargarUltraGridxBinding(gridComprobante, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub txtnumdoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnumdoc.KeyDown
        If e.KeyData = Keys.Return Then
            Procesar()
        End If
    End Sub
    Sub Buscar()
        Dim frm As New FrmListaClientes
        frm.ShowDialog()
        txtcliente.Text = Cliente
        txtcodcliente.Text = codCliente
    End Sub

    Sub Grabar()
        If gridComprobante.Rows.Count <= 0 Then
            MessageBox.Show("No existen datos para grabar", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            gridComprobante.PerformAction(ExitEditMode)
            lblmensaje.Visible = True
            lblmensaje.Text = "Validando documentos..."
            lblmensaje.Refresh()
            Dim dtDatos As New DataTable
            dtDatos = Source1.DataSource
            objEntidad = New ETContratista
            objNegocio = New NGContratista
            objEntidad.Usuario = User_Sistema
            objNegocio.ApruebaDocumento(objEntidad, dtDatos)
            Dim Mensaje As String = "Se grabó con éxito el registro"
            MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
            Procesar()
            'For i As Int32 = 0 To gridComprobante.Rows.Count - 1
            'Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub

    Private Sub txtcliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcliente.KeyDown
        If e.KeyData = Keys.Delete Or e.KeyData = Keys.Back Then
            txtcliente.Text = ""
            txtcodcliente.Text = ""
        End If
    End Sub
End Class