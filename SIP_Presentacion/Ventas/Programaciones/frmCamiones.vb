Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class frmCamiones
#Region "Declarar Variables"
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private TipoG As sTate
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
#End Region
    Private Sub frmCamiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtayo.Value = Year(Now.Date)
        Procesar()
        CargarListaConfigVehicular()
    End Sub
    Sub Procesar()
        CargarDatos()
        Me.Tab1.Tabs("T01").Selected = True
    End Sub
    Private Sub CargarDatos()
        Entidad.Contratista = New ETContratista
        Entidad.Contratista.TipoOperacion = Ope
        Entidad.Contratista._tipoanticipo = "I"
        Negocio.NContratista = New NGContratista
        Entidad.MyLista = New ETMyLista
        Entidad.Entregas.Usuario = User_Sistema
        Dim dtDatos As New DataTable
        dtDatos = Negocio.NContratista.Listar_PRO_Camiones(Entidad.Contratista)
        Call CargarUltraGridxBinding(Me.gridCamiones, Source1, dtDatos)
    End Sub
    Public Sub CargarListaConfigVehicular()
        Try
            Dim lista As New List(Of ETConfigVehicular)
            lista = Negocio.NContratista.Listar_PRO_ConfigVehicular()

            cboConfigVeh.DisplayMember = "CONFIGVEH"
            cboConfigVeh.ValueMember = "ID"

            cboConfigVeh.DataSource = lista
            cboConfigVeh.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Nuevo()
        Me.Tab1.Tabs("T02").Selected = True
        limpiar()
    End Sub
    Sub limpiar()
        txtid.Text = 0
        txtcodprov.Clear()
        txtproveedor.Clear()
        txtcodprov.Focus()
        txtplaca.Clear()
        txtdescripcion.Clear()
        txtmodelo.Clear()
        txtmarca.Clear()
        txtpeso.Text = "0.00"
        cboConfigVeh.SelectedRow = Nothing
        txtConfigVehCargaUtil.Text = "0"
        txtcodprov.ReadOnly = False
        txtcodprov.Focus()
    End Sub
    Sub Buscar()
        If txtid.Text <> 0 Then Exit Sub
        Dim frm As New FrmListaTransportista
        frm.ShowDialog()
        txtcodprov.Text = codMotivodetalle.Trim
        txtproveedor.Text = Motivodetalle.Trim
        txtplaca.Focus()
        'txtruc.Text = Ruc.Trim
    End Sub

    Private Sub txtcodprov_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodprov.KeyDown
        If e.KeyData = Keys.Return Then
            If txtid.Text <> 0 Then Exit Sub
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NContratista.Listar_PRO_Prov_Codigo(Entidad.Contratista)
            If dtDatos.Rows.Count > 0 Then
                txtcodprov.Text = dtDatos.Rows(0)("COD_PROV")
                txtproveedor.Text = dtDatos.Rows(0)("PROVEEDOR")
                txtplaca.Focus()
            Else
                MsgBox("El código no existe", MsgBoxStyle.Exclamation, msgComacsa)
                txtproveedor.Clear()
            End If
        End If
    End Sub

    Private Sub txtdescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdescripcion.KeyDown
        If e.KeyData = Keys.Return Then
            txtmarca.Focus()
        End If
    End Sub

    Private Sub txtmarca_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmarca.KeyDown
        If e.KeyData = Keys.Return Then
            txtmodelo.Focus()
        End If
    End Sub

    Private Sub txtmodelo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmodelo.KeyDown
        If e.KeyData = Keys.Return Then
            txtpeso.Focus()
        End If
    End Sub

    Private Sub txtpeso_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpeso.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtplaca_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtplaca.KeyDown
        If e.KeyData = Keys.Return Then
            txtdescripcion.Focus()
        End If
    End Sub

    Private Sub txtpeso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpeso.KeyDown
        If e.KeyData = Keys.Return Then
            txtpeso.Text = CDbl(txtpeso.Text).ToString("###0.00")
            txtayo.Focus()
        End If
    End Sub

    Sub Grabar()
        Try
            If Tab1.SelectedTab.Key <> "T02" Then Return

            If txtcodprov.Text.Trim = "" Or txtproveedor.Text.Trim = "" Then
                MessageBox.Show("Ingrese proveedor correcto", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtcodprov.Focus()
                Exit Sub
            End If

            If txtplaca.Text.Trim = "" Then                
                MessageBox.Show("Ingrese placa del camión", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtplaca.Focus()
                Exit Sub
            End If

            If txtdescripcion.Text.Trim = "" Then                
                MessageBox.Show("Ingrese descripción del camión", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtdescripcion.Focus()
                Exit Sub
            End If

            If txtpeso.Text.Trim = "" Then txtpeso.Text = 0
            If txtpeso.Text.Trim <= 0 Then
                MessageBox.Show("Ingrese peso máximo del camión", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtpeso.Focus()
                Exit Sub
            End If

            Dim row As UltraGridRow = cboConfigVeh.SelectedRow
            If row Is Nothing Then
                MessageBox.Show("Debe seleccionar la configuración vehicular del vehiculo", msgComacsa, _
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboConfigVeh.Focus()
                Exit Sub
            End If

            If txtConfigVehCargaUtil.Text.Trim.Length = 0 Then txtConfigVehCargaUtil.Text = "0"
            If txtConfigVehCargaUtil.Text.Trim <= 0 Then                
                MessageBox.Show("La Carga Util de la configuración vehicular debe ser mayor a 0", msgComacsa, _
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtpeso.Focus()
                Exit Sub
            End If

            If MessageBox.Show("¿Seguro desea guardar los cambios?", msgComacsa, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Return
            End If

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista.Tipo = 1
            Entidad.Contratista.ID = txtid.Text
            Entidad.Contratista._codprov = txtcodprov.Text
            Entidad.Contratista._placa = txtplaca.Text
            Entidad.Contratista._descripcion = txtdescripcion.Text
            Entidad.Contratista._marca = txtmarca.Text
            Entidad.Contratista._modelo = txtmodelo.Text
            Entidad.Contratista._ayo = txtayo.Value
            Entidad.Contratista._peso = txtpeso.Text
            Entidad.Contratista._configveh = cboConfigVeh.Text.Trim()
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NContratista.Listar_PRO_MantCamion(Entidad.Contratista)
            If dtDatos.Rows(0)(0) = "OK" Then
                Dim Mensaje As String = "Se grabó con éxito el registro"
                MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
                Call Procesar()
                Call limpiar()
            Else
                Dim Mensaje As String = dtDatos.Rows(0)(0)
                MsgBox(Mensaje, MsgBoxStyle.Exclamation, msgComacsa)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Sub Eliminar()
        Try
            If Tab1.SelectedTab.Key <> "T02" Then Return
            If txtid.Text = 0 Then
                MsgBox("Seleccione un registro a eliminar", MsgBoxStyle.Exclamation, msgComacsa)
                Return
            End If
            If MsgBox("¿Seguro desea eliminar el registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Return
            End If
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista.Tipo = 3
            Entidad.Contratista.ID = txtid.Text
            Entidad.Contratista._codprov = txtcodprov.Text
            Entidad.Contratista._placa = txtplaca.Text
            Entidad.Contratista._descripcion = txtdescripcion.Text
            Entidad.Contratista._marca = txtmarca.Text
            Entidad.Contratista._modelo = txtmodelo.Text
            Entidad.Contratista._ayo = txtayo.Value
            Entidad.Contratista._peso = txtpeso.Text
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NContratista.Listar_PRO_MantCamion(Entidad.Contratista)
            If dtDatos.Rows(0)(0) = "OK" Then
                Dim Mensaje As String = "Se eliminó con éxito el registro"
                MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
                Call Procesar()
                Call limpiar()
            Else
                Dim Mensaje As String = dtDatos.Rows(0)(0)
                MsgBox(Mensaje, MsgBoxStyle.Exclamation, msgComacsa)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Private Sub gridCamiones_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridCamiones.DoubleClickRow
        Try
            Me.Tab1.Tabs("T02").Selected = True
            limpiar()
            txtid.Text = gridCamiones.ActiveRow.Cells("ID").Value
            txtcodprov.Text = gridCamiones.ActiveRow.Cells("COD_PROV").Value
            txtproveedor.Text = gridCamiones.ActiveRow.Cells("PROVEEDOR").Value
            txtplaca.Text = gridCamiones.ActiveRow.Cells("PLACA").Value
            txtdescripcion.Text = gridCamiones.ActiveRow.Cells("DESCRIPCION").Value
            txtmarca.Text = gridCamiones.ActiveRow.Cells("MARCA").Value
            txtmodelo.Text = gridCamiones.ActiveRow.Cells("MODELO").Value
            txtpeso.Text = gridCamiones.ActiveRow.Cells("PESOMAXIMO").Value
            txtayo.Value = gridCamiones.ActiveRow.Cells("AYOFABRICACION").Value
            SeleccionarConfigVeh(gridCamiones.ActiveRow.Cells("CONFIGVEH").Value)
            txtcodprov.ReadOnly = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SeleccionarConfigVeh(ByVal ID As String)
        If cboConfigVeh.Rows.Count = 0 Then Exit Sub
        For Each row As UltraGridRow In cboConfigVeh.Rows
            If row.Cells("CONFIGVEH").Value = ID Then
                row.Activate()
            End If
        Next
    End Sub

    Private Sub cboConfigVeh_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConfigVeh.ValueChanged

        Dim row As UltraGridRow = cboConfigVeh.SelectedRow

        If row IsNot Nothing Then
            txtConfigVehCargaUtil.Text = row.Cells("CargaUtil").Value
        Else
            txtConfigVehCargaUtil.Text = "0"
        End If

    End Sub
End Class