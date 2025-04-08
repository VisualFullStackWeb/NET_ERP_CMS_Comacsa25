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

Public Class FrmSeteoRumasCantidad
#Region "Declarar Variables"
    Dim _objNegocio As NGRuma
    Dim _objEntidad As ETRuma


    Dim dtRuma As DataTable

    Dim ETMaestros2 = New ETMaestos2

    Dim Opcion As String


#End Region

#Region "FuncionesBasicas"
    Sub CargarRuma(ByVal codruma As String)
        'Llenar Combos de motivo
        ETMaestros2 = New ETMaestos2

        Negocio.Maestro = New NGMaestro

        ETMaestros2.Codigo = codruma


        Try
            dtRuma = Negocio.Maestro.ConsultaRuma(ETMaestros2)

            txtCodRuma.Text = dtRuma.Rows(0)("cod_ruma").ToString
            txtRuma.Text = dtRuma.Rows(0)("ruma").ToString
        Catch ex As Exception
            MsgBox("Ruma no encontrada")
            txtCodRuma.Text = ""
            txtRuma.Text = ""
        End Try

    End Sub

    Sub Limpiar()

        txtCodRuma.Text = ""
        txtRuma.Text = ""
        txtCantidad.Text = ""
        txtObservaciones.Text = ""
        cboRotacion.SelectedIndex = 0

    End Sub

    Function Validar() As Boolean

        If txtCantidad.Value = "" Then
            MessageBox.Show("Debe ingresar una Cantidad", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCantidad.Focus()
            Return False
        ElseIf cboRotacion.Text = "" Then
            MessageBox.Show("Debe ingresar una rotacion válida", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboRotacion.Focus()
            Return False
        ElseIf txtRuma.Text = "" Then
            MessageBox.Show("Debe ingresar una Ruma válida", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCodRuma.Focus()
            Return False
        Else
            Return True
        End If

    End Function

    Sub cargarDtg()
        Dim dtDatos As DataTable

        _objNegocio = New NGRuma
        _objEntidad = New ETRuma

        _objEntidad.tipograf = Opcion
        _objEntidad.MesStr = cmbMes.Value.ToString()
        _objEntidad.YearStr = txtayo.Value.ToString()

        dtDatos = _objNegocio.ConsultaRumaSeteos(_objEntidad)

        Call CargarUltraGridxBinding(grdRumas, Source1, dtDatos)

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

    Private Sub FrmActivaEmpleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtCodRuma.Text = ""
        cmbMes.Value = "01"
        Limpiar()

        Opcion = "R"
        cargarDtg()
    End Sub


    Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
        Limpiar()

        pnlRegistrar.Visible = True

        Opcion = "C"
        grdRumas.Enabled = False
        txtayo.Enabled = False
        cmbMes.Enabled = False
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        'Dim exito As Int16

        If Validar() = False Then Return

        _objNegocio = New NGRuma
        _objEntidad = New ETRuma

        _objEntidad.tipograf = Opcion
        _objEntidad.MesStr = cmbMes.Value.ToString()
        _objEntidad.YearStr = txtayo.Value.ToString()
        _objEntidad.CodRuma = txtCodRuma.Text
        _objEntidad.CantidadSubRecurso = txtCantidad.Text
        _objEntidad.Usuario = User_Sistema
        _objEntidad.Terminal = Terminal
        _objEntidad.TipoRecibo = cboRotacion.Value
        _objEntidad.Operacion = txtObservaciones.Text
        Try
            If (_objNegocio.ConsultaRumaSeteos(_objEntidad).Rows.Count > 0) Then
                MessageBox.Show("Registro Guardado Exitosamente", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        Opcion = "R"
        cargarDtg()

        pnlRegistrar.Visible = False
        txtCodRuma.Enabled = True
        grdRumas.Enabled = True
        txtayo.Enabled = True
        cmbMes.Enabled = True


    End Sub

    Private Sub grdEmpleados_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdRumas.DoubleClickRow
        Dim uRow As UltraGridRow
        uRow = e.Row

        Opcion = "U"

        _objNegocio = New NGRuma
        _objEntidad = New ETRuma

        txtCodRuma.Text = uRow.Cells("ruma").Value.ToString()
        txtCantidad.Text = uRow.Cells("Cantidad").Value.ToString()
        cboRotacion.Value = uRow.Cells("Flg_Rotacion").Value.ToString()
        txtRuma.Text = uRow.Cells("nomRuma").Value.ToString()
        txtObservaciones.Text = uRow.Cells("Observaciones").Value.ToString()

        txtayo.Enabled = False
        cmbMes.Enabled = False
        txtCodRuma.Enabled = False

        pnlRegistrar.Visible = True
        grdRumas.Enabled = False

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        grdRumas.Enabled = True
        txtayo.Enabled = True
        cmbMes.Enabled = True
        txtCodRuma.Enabled = True
        pnlRegistrar.Visible = False

        Limpiar()

    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Opcion = "R"
        cargarDtg()
    End Sub

    Private Sub txtayo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtayo.ValueChanged

    End Sub

    Private Sub grdEmpleados_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdRumas.InitializeLayout

    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtCantidad.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantidad_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.ValueChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If grdRumas.ActiveRow Is Nothing Then
            MessageBox.Show("No tiene un registro seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        _objNegocio = New NGRuma
        _objEntidad = New ETRuma

        Opcion = "D"

        _objEntidad.tipograf = Opcion
        _objEntidad.MesStr = cmbMes.Value.ToString()
        _objEntidad.YearStr = txtayo.Value.ToString()
        _objEntidad.CodRuma = grdRumas.ActiveRow.Cells("Ruma").Value.ToString()

        If MsgBox("¿Desea eliminar el registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then

            Try
                If Not (_objNegocio.ConsultaRumaSeteos(_objEntidad).Rows.Count > 0) Then
                    MessageBox.Show("Registro eliminado exitosamente", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Opcion = "R"
                    cargarDtg()
                End If
            Catch ex As Exception
                MessageBox.Show(ex, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub txtCodRuma_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodRuma.ValueChanged

    End Sub

    Private Sub txtCodRuma_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodRuma.KeyPress
        If e.KeyChar = Chr(13) Then
            txtCodRuma.Text = txtCodRuma.Text.PadLeft(8, "0")
            Dim txtcodRumas As String = txtCodRuma.Text
            CargarRuma(txtcodRumas)
        End If
    End Sub
End Class