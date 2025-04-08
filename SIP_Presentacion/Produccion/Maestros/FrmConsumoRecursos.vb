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
Imports System.Data
Imports System.Data.OleDb

Public Class FrmConsumoRecursos
#Region "Variables"
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista

    Dim opcion As String
#End Region
#Region "Funciones Basicas"
    Sub cargarDtg()
        Dim dtDatos As DataTable

        objNegocio = New NGContratista
        objEntidad = New ETContratista
        opcion = "R"

        objEntidad._tipopago = opcion
        objEntidad.ANEXO3 = cboTipo.Value.ToString()
        objEntidad.YearStr = txtPeriodo.Value.ToString

        dtDatos = objNegocio.ConsultarConsumoRecursos(objEntidad)

        GrdConsumo.DataSource = dtDatos

    End Sub
#End Region

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Private Sub FrmConsumoRecursos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTipo.Value = "1"
        cargarDtg()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim dtDatos As DataTable

        objNegocio = New NGContratista
        objEntidad = New ETContratista

        objEntidad._tipopago = opcion
        objEntidad.cadena = ""
        objEntidad.YearStr = txtPeriodoR.Value.ToString()
        objEntidad._descripcion = txtPlanta.Text
        objEntidad.ANEXO3 = cboTipoR.Value.ToString()
        objEntidad.Usuario = User_Sistema
        objEntidad.Fecha = Date.Now

        dtDatos = objNegocio.ConsultarConsumoRecursos(objEntidad)

        cargarDtg()

        pnlRegistrar.Visible = False
        GrdConsumo.Enabled = True
        txtPeriodo.Enabled = True
        cboTipo.Enabled = True

    End Sub

    Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
        opcion = "C"
        pnlRegistrar.Visible = True
        GrdConsumo.Enabled = False
        txtPeriodo.Enabled = False
        cboTipo.Enabled = False
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        pnlRegistrar.Visible = False
        GrdConsumo.Enabled = True
        txtPeriodo.Enabled = True
        cboTipo.Enabled = True
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        cargarDtg()
    End Sub

    Private Sub btnGrabarConsumos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarConsumos.Click

        objNegocio = New NGContratista
        objEntidad = New ETContratista

        Dim dtDetalle As DataTable
        For i As Int32 = 0 To GrdConsumo.Rows.Count - 1

            With objEntidad
                ._tipopago = "U"
                .cadena = GrdConsumo.Rows(i).Cells("idConsumoRecursos").Value
                ._descripcion = GrdConsumo.Rows(i).Cells("descripcion").Value
                .YearStr = txtPeriodo.Value.ToString()
                ._descripcion = GrdConsumo.Rows(i).Cells("descripcion").Value
                .ANEXO3 = cboTipo.Value.ToString()

                If Not (GrdConsumo.Rows(i).Cells("Enero").Value Is DBNull.Value) Then .enero = GrdConsumo.Rows(i).Cells("Enero").Value Else .enero = 0
                If Not (GrdConsumo.Rows(i).Cells("Febrero").Value Is DBNull.Value) Then .febrero = GrdConsumo.Rows(i).Cells("Febrero").Value Else .febrero = 0
                If Not (GrdConsumo.Rows(i).Cells("Marzo").Value Is DBNull.Value) Then .marzo = GrdConsumo.Rows(i).Cells("Marzo").Value Else .marzo = 0
                If Not (GrdConsumo.Rows(i).Cells("Abril").Value Is DBNull.Value) Then .abril = GrdConsumo.Rows(i).Cells("Abril").Value Else .abril = 0
                If Not (GrdConsumo.Rows(i).Cells("Mayo").Value Is DBNull.Value) Then .mayo = GrdConsumo.Rows(i).Cells("Mayo").Value Else .mayo = 0
                If Not (GrdConsumo.Rows(i).Cells("Junio").Value Is DBNull.Value) Then .junio = GrdConsumo.Rows(i).Cells("Junio").Value Else .junio = 0
                If Not (GrdConsumo.Rows(i).Cells("Julio").Value Is DBNull.Value) Then .julio = GrdConsumo.Rows(i).Cells("Julio").Value Else .julio = 0
                If Not (GrdConsumo.Rows(i).Cells("Agosto").Value Is DBNull.Value) Then .agosto = GrdConsumo.Rows(i).Cells("Agosto").Value Else .agosto = 0
                If Not (GrdConsumo.Rows(i).Cells("Septiembre").Value Is DBNull.Value) Then .septiembre = GrdConsumo.Rows(i).Cells("Septiembre").Value Else .septiembre = 0
                If Not (GrdConsumo.Rows(i).Cells("Octubre").Value Is DBNull.Value) Then .octubre = GrdConsumo.Rows(i).Cells("Octubre").Value Else .octubre = 0
                If Not (GrdConsumo.Rows(i).Cells("Noviembre").Value Is DBNull.Value) Then .noviembre = GrdConsumo.Rows(i).Cells("Noviembre").Value Else .noviembre = 0
                If Not (GrdConsumo.Rows(i).Cells("Diciembre").Value Is DBNull.Value) Then .diciembre = GrdConsumo.Rows(i).Cells("Diciembre").Value Else .diciembre = 0

                .Usuario = User_Sistema
                .Fecha = Date.Now
            End With

            dtDetalle = objNegocio.ConsultarConsumoRecursos(objEntidad)

        Next

        cargarDtg()

    End Sub
End Class