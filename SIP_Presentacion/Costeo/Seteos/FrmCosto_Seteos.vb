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
Public Class FrmCosto_Seteos
#Region "Declarar Variables"
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
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Dim cierre As Int32

    Private Sub FrmCosto_Seteos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MantPreventivo()
        PorcentajeCosteo()
    End Sub
    Sub MantPreventivo()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_CuentasMPrev(_objEntidad)
            Call CargarUltraGridxBinding(Me.gridmantpreventivo, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub PorcentajeCosteo()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_PorcentajeCosteo(_objEntidad)
            If dtDatos.Rows.Count > 0 Then
                txtchancadora.Text = dtDatos.Rows(0)("PORC_CHANCADORA")
                txtmolino.Text = dtDatos.Rows(0)("PORC_MOLINO")
            Else
                txtchancadora.Text = "0.00"
                txtmolino.Text = "0.00"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub btnagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        Try
            Dim frm As New FrmCuentaCosto
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = Year(Now.Date)
            frm.dtDatos = _objNegocio.Costo_ListaCuentasMPrev(_objEntidad)

            Dim resul As DialogResult
            resul = frm.ShowDialog()
            Dim cod_cuenta As String
            If resul = Windows.Forms.DialogResult.OK Then
                cod_cuenta = frm.gridCuenta.ActiveRow.Cells("codCuenta").Value

                If MsgBox("Desea registrar cuenta?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Exit Sub
                End If

                _objNegocio = New NGProducto
                _objEntidad = New ETProducto
                _objEntidad.Tipo = 1
                _objEntidad.Cuenta = cod_cuenta
                _objEntidad.Usuario = User_Sistema
                Dim dtDatos As New DataTable
                dtDatos = _objNegocio.Costo_RegistraCuentaMPrev(_objEntidad)
                MsgBox("Cambios realizados correctamente", MsgBoxStyle.Information, msgComacsa)
                MantPreventivo()
            End If

            'gridAreaCuenta.Rows(gridAreaCuenta.ActiveRow.Index).Cells("Cuenta").Value = Cuenta
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Try
            If gridmantpreventivo.ActiveRow.Index < 0 Then Exit Sub
            If MsgBox("Desea eliminar cuenta?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Tipo = 3
            _objEntidad.Cuenta = gridmantpreventivo.ActiveRow.Cells("cgcod").Value
            _objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RegistraCuentaMPrev(_objEntidad)
            MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            MantPreventivo()
            'gridAreaCuenta.Rows(gridAreaCuenta.ActiveRow.Index).Cells("Cuenta").Value = Cuenta
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtmolino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmolino.KeyDown
        If e.KeyData = Keys.Return Then
            btngrabar.Focus()
        End If
    End Sub

    Private Sub txtmolino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmolino.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtchancadora_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchancadora.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            If txtchancadora.Text.Trim = "" Then txtchancadora.Text = 0
            If txtmolino.Text.Trim = "" Then txtmolino.Text = 0
            Dim porc_chancadora As Double = txtchancadora.Text
            Dim porc_molino As Double = txtmolino.Text
            If porc_chancadora + porc_molino > 100 Then
                MsgBox("No puede superar el 100%", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If MsgBox("Desea registrar porcentaje?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Tipo = 1
            _objEntidad.PorcChancadora = porc_chancadora
            _objEntidad.PorcMolino = porc_molino
            _objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_Mant_PorcentajeCosteo(_objEntidad)
            MsgBox("Cambios realizados correctamente", MsgBoxStyle.Information, msgComacsa)
            PorcentajeCosteo()
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub txtchancadora_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtchancadora.KeyDown
        If e.KeyData = Keys.Return Then
            txtmolino.Focus()
        End If
    End Sub
End Class