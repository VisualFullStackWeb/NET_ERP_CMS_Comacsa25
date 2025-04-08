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
Public Class frmSustentoProducción
#Region "Declarar Variables"
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Public ConceptoSeleccionado As String
    Public filtroDescripcion As String = String.Empty
#End Region

    Private Sub frmSustentoProducción_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlSustento.Visible = False
        dtinicio.Value = "01/" + Now.Date.Month.ToString + "/" + Now.Date.Year.ToString
        dtfin.Value = Now.Date
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad.liberado = 0
        Procesar()
    End Sub
    Sub Procesar()
        If pnlSustento.Visible = True Then MsgBox("Complete el sustento para continuar", MsgBoxStyle.Critical) : Exit Sub
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad.FechaInicio = dtinicio.Value
        objEntidad.FechaTerminacion = dtfin.Value
        objEntidad.liberado = IIf(cboAtendido.Checked = True, 1, 0)
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarValidaVTAProduccion(objEntidad)
        gridproducto.DataSource = dtDatos

    End Sub
    Sub Grabar()
        If cboPendiente.Checked = False Then Exit Sub
        If pnlSustento.Visible = True Then MsgBox("Complete el sustento para continuar", MsgBoxStyle.Critical) : Exit Sub
        gridproducto.PerformAction(ExitEditMode)
        If MsgBox("Desea grabar los datos?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        For i As Int32 = 0 To gridproducto.Rows.Count - 1
            objNegocio = New NGContratista
            objEntidad = New ETContratista

            objEntidad._billete = gridproducto.Rows(i).Cells("NUM_DOC").Value
            objEntidad._cod_prod = gridproducto.Rows(i).Cells("COD_PRODPDC").Value
            Dim validacion As Int32 = 0
            If gridproducto.Rows(i).Cells("VALIDACION").Value = True Then
                validacion = 2
            Else
                validacion = 0
            End If
            objEntidad.validacion_ = validacion
            objEntidad.cadena = TxtObservacion.Text
            objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.MantValidaVTAProduccion(objEntidad)
        Next
        MsgBox("Datos grabados correctamente", MsgBoxStyle.Information, "Sistema")
        Procesar()
        lblmensaje.Visible = False
        lblmensaje.Refresh()

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlSustento.Paint

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPendiente.CheckedChanged
        If cboPendiente.Checked = True Then
            cboAtendido.Checked = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAtendido.CheckedChanged
        If cboAtendido.Checked = True Then
            cboPendiente.Checked = False
        End If
        If cboAtendido.Checked = False Then
            Procesar()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        pnlSustento.Visible = False
        gridproducto.Enabled = True
        gridproducto.ActiveRow.Cells("VALIDACION").Value = False
    End Sub

    Private Sub gridproducto_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridproducto.AfterCellUpdate

    End Sub

    Private Sub gridproducto_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridproducto.CellChange
        If (gridproducto.ActiveRow.Cells("VALIDACION").Value Is DBNull.Value) Then
            Exit Sub
        End If

        If cboPendiente.Checked = True Then
            If gridproducto.ActiveRow.Cells("VALIDACION").Value = True Then
                gridproducto.ActiveRow.Cells("VALIDACION").Value = False
                Exit Sub
            End If
            TxtObservacion.Text = ""
            pnlSustento.Visible = True
            lblBillete.Text = gridproducto.ActiveRow.Cells("NUM_DOC").Value.ToString
            lblProducto.Text = gridproducto.ActiveRow.Cells("COD_PRODPDC").Value.ToString + " " + gridproducto.ActiveRow.Cells("DESCRIP").Value.ToString

            gridproducto.Enabled = False
        End If
    End Sub

    Private Sub gridproducto_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridproducto.InitializeLayout

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Trim(TxtObservacion.Text) = "" Then
            If MsgBox("Debe ingresar observación, ¿Desea continuar?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then
                pnlSustento.Visible = False
                gridproducto.Enabled = True
                gridproducto.ActiveRow.Cells("VALIDACION").Value = False
                Exit Sub
            End If
            TxtObservacion.Focus()
            Exit Sub
        End If
        If MsgBox("¿Desea grabar los datos?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
        objNegocio = New NGContratista
        objEntidad = New ETContratista

        objEntidad._billete = gridproducto.ActiveRow.Cells("NUM_DOC").Value
        objEntidad._cod_prod = gridproducto.ActiveRow.Cells("COD_PRODPDC").Value
        objEntidad.validacion_ = 1
        objEntidad.cadena = TxtObservacion.Text
        objEntidad.Usuario = User_Sistema
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.MantValidaVTAProduccion(objEntidad)

        MsgBox("Observación registrada correctamente", MsgBoxStyle.Information, "Sistema")

        pnlSustento.Visible = False
        gridproducto.Enabled = True

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
