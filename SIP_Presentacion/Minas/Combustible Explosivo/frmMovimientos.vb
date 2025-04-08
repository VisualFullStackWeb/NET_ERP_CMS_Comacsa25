Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class frmMovimientos
    Dim dtDetalle As New DataTable
    Dim flgtrans As Int32
    Dim tipomov As String
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista
#Region "Variables"
    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private ListModulos As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim Ope = 1
#End Region
    Sub CargarTipoMovimiento()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.Listar_TipoMovimiento()
        Call CargarUltraCombo(cmbtipoMovimiento, dtDatos, "ID", "DESCRIPCION")
    End Sub

    Private Sub frmMovimientos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmMovimientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        limpiar()
        dtpDesde.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
        dtpHasta.Value = Now.Date
        dtFecha.Value = Now.Date
        CargarDatos()
        CargarTipoMovimiento()
        Tipo_Tareo()
        cmbtipo.Value = "C"
        cmbtipotareo.Value = "05"
    End Sub
    Sub Procesar()
        CargarDatos()
        CargarTipoMovimiento()
        Tipo_Tareo()
        Me.Tab1.Tabs("T01").Selected = True
        limpiar()
        limpiarConsumo()
        limpiarIngresoSalida()
    End Sub
    Sub Actualizar()
        Procesar()
    End Sub
    Public Sub CargarDatos()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._fecha1 = CDate(dtpDesde.Value).ToString("dd/MM/yyyy")
            objEntidad._fecha2 = CDate(dtpHasta.Value).ToString("dd/MM/yyyy")
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.ListarMovimientos(objEntidad)
            Call CargarUltraGridxBinding(gridMovimiento, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Private Sub cmbtipoMovimiento_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbtipoMovimiento.InitializeLayout
        With cmbtipoMovimiento.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("DESCRIPCION").Width = 350 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "DESCRIPCION") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub
    Sub Buscar()
        If txtalmorigen.Focused = True Then
            txtalmorigen.Clear()
            Dim frm As New frmBuscarAlmacen
            frm.ShowDialog()
            txtalmorigen.Text = frm.gridAlmacen.ActiveRow.Cells("ALMACEN").Value.ToString.Trim
            txtidalmorigen.Text = frm.gridAlmacen.ActiveRow.Cells("COD_ALMACEN").Value.ToString.Trim
            txtcodcanteraori.Text = frm.gridAlmacen.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcanteraori.Text = frm.gridAlmacen.ActiveRow.Cells("CANTERA").Value.ToString.Trim
            Tipo_Equipo()
        End If
        If txtalmdestino.Focused = True Then
            txtalmdestino.Clear()
            Dim frm As New frmBuscarAlmacen
            frm.ShowDialog()
            txtalmdestino.Text = frm.gridAlmacen.ActiveRow.Cells("ALMACEN").Value.ToString.Trim
            txtidalmdestino.Text = frm.gridAlmacen.ActiveRow.Cells("COD_ALMACEN").Value.ToString.Trim
            txtcodcanteradest.Text = frm.gridAlmacen.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcanteradest.Text = frm.gridAlmacen.ActiveRow.Cells("CANTERA").Value.ToString.Trim
        End If
        If txtcodequipo.Focused = True Then
            Dim Equipo As New FrmListarActivo
            xFormulario = "Movimientos"
            GCantera = Trim(txtcodcanteraori.Text & "")
            GLinea = cmbtipoequipo.Value
            gEmpleo = ""
            Equipo.ShowDialog()
            txtcodequipo.Text = Equipo.CODIGO
            txtequipo.Text = Equipo.ACTIVO
            Equipo = Nothing
            xFormulario = String.Empty
        End If
        If txtcliente.Focused = True Then
            txtcliente.Clear()
            txtcodcliente.Clear()
            Dim frm As New frmBuscarCliente
            frm.ShowDialog()
            txtcliente.Text = frm.gridCliente.ActiveRow.Cells("RAZON").Value.ToString.Trim
            txtcodcliente.Text = frm.gridCliente.ActiveRow.Cells("COD_CLI").Value.ToString.Trim
        End If
        If txtoc.Focused = True Then
            txtoc.Clear()
            Dim frm As New frmBuscarOrden
            frm.ayo = Year(dtFecha.Value)
            frm.mes = Month(dtFecha.Value)
            frm.ShowDialog()
            If Not frm.gridordenes.ActiveRow Is Nothing Then
                txtoc.Text = frm.gridordenes.ActiveRow.Cells("NRO_OC").Value.ToString.Trim
                dtFecha.Value = frm.gridordenes.ActiveRow.Cells("FECHA").Value.ToString.Trim
            End If
            If dtDetalle.Columns.Count <= 1 Then
                creaTablaDetalle()
            End If
            llenaOC(txtoc.Text.ToString.Trim)
        End If
        If txtcodmaterial.Focused = True Then
            Dim Combustible As New FrmListarProductos

            If cmbtipo.Value = "C" Then
                xFormulario = "Cantera_Combustible"
            Else
                xFormulario = "Cantera_Explosivo"
            End If

            Combustible.ShowDialog()
            txtcodmaterial.Text = Trim(Combustible.CODIGO & "")
            txtmaterial.Text = Trim(Combustible.DESCRIPCION & "")
            txtUM.Text = Trim(Combustible.UNIDADMEDIDA & "")
            Combustible = Nothing
            xFormulario = String.Empty
            'Txt8.SelectAll()
            txtcantidad.Focus()
            Return
        End If
        If txtcodmaterial1.Focused = True Then
            Dim Combustible As New FrmListarProductos

            If cmbtipo.Value = "C" Then
                xFormulario = "Cantera_Combustible"
            Else
                xFormulario = "Cantera_Explosivo"
            End If

            Combustible.ShowDialog()
            txtcodmaterial1.Text = Trim(Combustible.CODIGO & "")
            txtmaterial1.Text = Trim(Combustible.DESCRIPCION & "")
            txtUM1.Text = Trim(Combustible.UNIDADMEDIDA & "")
            Combustible = Nothing
            xFormulario = String.Empty
            'Txt8.SelectAll()
            txtcantmaterial.Focus()
            Return
        End If
    End Sub
    Sub Nuevo()
        Me.Tab1.Tabs("T02").Selected = True
        Ope = 1
        limpiar()
        limpiarConsumo()
        limpiarIngresoSalida()
        cmbtipoMovimiento.Focus()
        pnlPrincipal.Enabled = True
        Ope = 1
        txtidmovimiento.Text = 0
    End Sub
    Sub limpiar()
        Try
            cmbtipoMovimiento.Value = Nothing
            dtFecha.Value = Now.Date
            txtalmorigen.Clear()
            txtalmdestino.Clear()
            txtidalmorigen.Text = 0
            txtidalmdestino.Text = 0
            txtcodcanteraori.Clear()
            txtcodcanteradest.Clear()
            txtcanteraori.Clear()
            txtcanteradest.Clear()
            txtcliente.Clear()
            txtidmovimiento.Text = 0
            txtoc.Clear()
            UltraGroupBox2.Enabled = True
            GrpGrupo.Enabled = True
            btnagregar.Enabled = True
            btneliminar.Enabled = True
            txtoc.Visible = False
            UltraLabel23.Visible = False
            txtcliente.Visible = False
            txtcodcliente.Visible = False
            UltraLabel5.Visible = False
            txtalmdestino.Visible = False
            UltraLabel3.Visible = False
            txtcodcanteradest.Visible = False
            lblnumero.Visible = False
            dtDetalle.Rows.Clear()
            Call CargarUltraGrid(gridDetalle, dtDetalle)
        Catch ex As Exception

        End Try

    End Sub
    Sub Tipo_Equipo()
        cmbtipoequipo.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "UNO", txtcodcanteraori.Value, dtFecha.Value, Now)
        cmbtipoequipo.ValueMember = "Codigo"
        cmbtipoequipo.DisplayMember = "Descripcion"
    End Sub
    Sub Tipo_Tareo()
        cmbtipotareo.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "TTE", "", Now.ToShortDateString, Now)
        cmbtipotareo.ValueMember = "Codigo"
        cmbtipotareo.DisplayMember = "Descripcion"
    End Sub

    Private Sub cmbtipoMovimiento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtipoMovimiento.ValueChanged
        Try
            dtDetalle.Rows.Clear()
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad.ID = cmbtipoMovimiento.Value
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.TipoMovimientoConcepto(objEntidad)
            flgtrans = dtDatos.Rows(0)("FLGTRANS")
            tipomov = dtDatos.Rows(0)("MOVI")
            If dtDatos.Rows.Count > 0 Then
                If dtDatos.Rows(0)("FLGTRANS") = 0 Then
                    GrpGrupo.Visible = False
                    UltraGroupBox2.Visible = True
                    txtalmdestino.Visible = False
                    UltraLabel3.Visible = False
                Else
                    GrpGrupo.Visible = True
                    UltraGroupBox2.Visible = False
                    txtalmdestino.Visible = True
                    UltraLabel3.Visible = True
                End If

                If dtDatos.Rows(0)("FLGVENTA") = 0 Then
                    txtcliente.Visible = False
                    txtcodcliente.Visible = False
                    UltraLabel5.Visible = False
                    cmbtipotrabajo.Value = "A"
                Else
                    txtcliente.Visible = True
                    txtcodcliente.Visible = True
                    UltraLabel5.Visible = True
                    cmbtipotrabajo.Value = "C"
                End If

                If dtDatos.Rows(0)("FLGOC") = 0 Then
                    txtoc.Visible = False
                    UltraLabel23.Visible = False
                    txtoc.Clear()
                    gridDetalleOC.Visible = False
                    gridDetalle.Visible = True
                    UltraGroupBox2.Enabled = True
                    GrpGrupo.Enabled = True
                    btnagregar.Enabled = True
                    btneliminar.Enabled = True
                Else
                    txtoc.Visible = True
                    UltraLabel23.Visible = True
                    gridDetalleOC.Visible = True
                    gridDetalle.Visible = False
                    UltraGroupBox2.Enabled = False
                    GrpGrupo.Enabled = False
                    btnagregar.Enabled = False
                    btneliminar.Enabled = False
                    txtoc.Clear()
                    'UltraLabel5.Visible = True
                End If

                If tipomov = "S" And flgtrans = 0 And cmbtipo.Value = "C" Then
                    GrpGrupo.Visible = True
                    UltraGroupBox2.Visible = False
                Else
                    GrpGrupo.Visible = False
                    UltraGroupBox2.Visible = True
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbtipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipo.ValueChanged
        Try
            txtcodmaterial.Clear()
            txtmaterial.Clear()
            txtUM.Clear()
            If cmbtipo.Value = "C" Then
                txtcodmaterial1.Visible = True
                txtmaterial1.Visible = True
                txtcantmaterial.Visible = True
                txtUM1.Visible = True
                UltraLabel20.Visible = True
                UltraLabel18.Visible = True
                UltraLabel16.Visible = True
            Else
                txtcodmaterial1.Visible = False
                txtmaterial1.Visible = False
                txtcantmaterial.Visible = False
                txtUM1.Visible = False
                UltraLabel20.Visible = False
                UltraLabel18.Visible = False
                UltraLabel16.Visible = False
            End If
            If tipomov = "S" And flgtrans = 0 And cmbtipo.Value = "C" Then
                GrpGrupo.Visible = True
                UltraGroupBox2.Visible = False
            Else
                GrpGrupo.Visible = False
                UltraGroupBox2.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtentrada_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtentrada.GotFocus
        txtentrada.Text = CDbl(txtentrada.Text).ToString("##00.0000")
    End Sub

    Private Sub txtentrada_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtentrada.KeyDown
        If e.KeyData = Keys.Return Then
            txtsalida.Focus()
        End If
    End Sub

    Private Sub txtsalida_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsalida.GotFocus
        txtsalida.Text = CDbl(txtsalida.Text).ToString("##00.0000")
    End Sub

    Private Sub txtsalida_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsalida.KeyDown
        If e.KeyData = Keys.Return Then
            cmbtipotrabajo.Focus()
        End If
    End Sub

    Private Sub Txt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsalida.ValueChanged, txtentrada.ValueChanged
        If txtsalida.Value IsNot Nothing And IsDBNull(txtsalida.Value) = False And _
        txtentrada.Value IsNot Nothing And IsDBNull(txtentrada.Value) = False Then
            If Not (cmbtipotareo.Value = "06") Then
                txtcantidad1.Value = txtsalida.Value - txtentrada.Value
            Else
                txtcantidad1.Value = 0
            End If

        Else
            txtcantidad1.Value = 0
        End If
    End Sub

    Private Sub cmbtipotareo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtipotareo.ValueChanged
        Try
            If cmbtipotareo.Value = "06" Then
                txtcantidad1.ReadOnly = False
                txtcantidad1.SelectAll()
                txtcantidad1.Focus()
            Else
                Txt_ValueChanged(sender, e)
                txtcantidad1.ReadOnly = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcantmaterial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcantmaterial.GotFocus
        txtcantmaterial.Text = CDbl(txtcantmaterial.Text).ToString("##00.0000")
    End Sub

    Private Sub txtcantmaterial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcantmaterial.KeyDown
        If e.KeyData = Keys.Return Then
            btnagregar.Focus()
        End If
    End Sub

    Private Sub txtentrada_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtentrada.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtsalida_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsalida.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub btnagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        If Not validarCabecera() Then Exit Sub
        If GrpGrupo.Visible = True Then
            If Not validaConsumo() Then Exit Sub
            agregaConsumo()
        End If
        If UltraGroupBox2.Visible = True Then
            If Not validaIngresoSalida() Then Exit Sub
            agregaIngresoSalida()
        End If
        pnlPrincipal.Enabled = False
    End Sub
    Function validaConsumo() As Boolean
        If cmbtipoequipo.Value = Nothing Then
            MessageBox.Show("Seleccione tipo de equipo", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If txtcodequipo.Text.Trim = "" Then
            MessageBox.Show("Seleccione equipo", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtcodequipo.Focus()
            Return False
        End If
        If txtentrada.Text.Trim = "" Then txtentrada.Text = 0
        If txtentrada.Text.Trim <= 0 Then
            MessageBox.Show("Ingrese valor de entrada", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtentrada.Focus()
            Return False
        End If
        If txtsalida.Text.Trim = "" Then txtsalida.Text = 0
        If txtsalida.Text.Trim <= 0 Then
            MessageBox.Show("Ingrese valor de salida", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtsalida.Focus()
            Return False
        End If
        If cmbtipo.Value = Nothing Then
            MessageBox.Show("Ingrese tipo de tareo", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If cmbtipotrabajo.SelectedIndex < 0 Then
            MessageBox.Show("Seleccione tipo de trabajo", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If txtcodmaterial1.Text.Trim = "" Then
            MessageBox.Show("Ingrese material", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtcodmaterial1.Focus()
            Return False
        End If
        If txtcantmaterial.Text.Trim = "" Then txtcantmaterial.Text = 0
        If txtcantmaterial.Text.Trim <= 0 Then
            MessageBox.Show("Ingrese cantidad", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtcantmaterial.Focus()
            Return False
        End If
        For i As Int32 = 0 To dtDetalle.Rows.Count - 1
            If txtcodmaterial1.Text.Trim = dtDetalle.Rows(i)("COD_MATERIAL").ToString.Trim Then
                MessageBox.Show("El producto ya fue agregado", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Next
        Return True
    End Function
    Function validaIngresoSalida() As Boolean
        If txtcodmaterial.Text.Trim = "" Then
            MessageBox.Show("Ingrese material", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtcodmaterial.Focus()
            Return False
        End If
        If txtcantidad.Text.Trim = "" Then txtcantidad.Text = 0
        If txtcantidad.Text.Trim <= 0 Then
            MessageBox.Show("Ingrese cantidad", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtcantidad.Focus()
            Return False
        End If
        For i As Int32 = 0 To dtDetalle.Rows.Count - 1
            If txtcodmaterial.Text.Trim = dtDetalle.Rows(i)("COD_MATERIAL").ToString.Trim Then
                MessageBox.Show("El producto ya fue agregado", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Next
        Return True
    End Function
    Private Sub txtcantmaterial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantmaterial.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Sub agregaConsumo()
        If txtentrada.Text = "" Then txtentrada.Text = 0
        If txtsalida.Text = "" Then txtsalida.Text = 0
        If txtcantmaterial.Text = "" Then txtcantmaterial.Text = 0
        txtentrada.Text = CDbl(txtentrada.Text).ToString("###0.0000")
        txtsalida.Text = CDbl(txtsalida.Text).ToString("###0.0000")
        txtcantmaterial.Text = CDbl(txtcantmaterial.Text).ToString("###0.0000")
        If dtDetalle.Columns.Count <= 1 Then
            creaTablaDetalle()
        End If
        llenaConsumo()
        limpiarConsumo()
    End Sub
    Sub agregaIngresoSalida()
        If txtcantidad.Text = "" Then txtcantidad.Text = 0
        txtcantidad.Text = CDbl(txtcantidad.Text).ToString("###0.0000")
        If dtDetalle.Columns.Count <= 1 Then
            creaTablaDetalle()
        End If
        llenaIngresoSalida()
        limpiarIngresoSalida()
    End Sub
    Sub llenaOC(ByVal numOC As String)
        dtDetalle.Rows.Clear()
        Call CargarUltraGrid(gridDetalleOC, dtDetalle)
        Dim objNegocio As NGContratista = Nothing
        Dim objEntidad As ETContratista = Nothing
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._numorden = numOC
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.CE_DetalleOrden(objEntidad)
        If dtDatos.Rows.Count > 0 Then
            Dim dr As DataRow
            For i As Int32 = 0 To dtDatos.Rows.Count - 1
                dr = dtDetalle.NewRow
                dr(0) = ""
                dr(1) = ""
                dr(2) = ""
                dr(3) = ""
                dr(4) = "0.00000"
                dr(5) = "0.00000"
                dr(6) = "0.00000"
                dr(7) = ""
                dr(8) = ""
                dr(9) = ""
                dr(10) = ""
                dr(11) = dtDatos.Rows(i)("COD_MATERIAL")
                dr(12) = dtDatos.Rows(i)("MATERIAL")
                dr(13) = "0.00000"
                dr(14) = dtDatos.Rows(i)("UM")
                dr(15) = dtDatos.Rows(i)("CANT_PEDIDA")
                dr(16) = dtDatos.Rows(i)("VALOR")
                dr(17) = dtDatos.Rows(i)("CANTIDAD")
                dr(18) = dtDatos.Rows(i)("ITEM")
                dtDetalle.Rows.Add(dr)
            Next
            Call CargarUltraGrid(gridDetalleOC, dtDetalle)
        End If
    End Sub
    Sub llenaConsumo()
        Dim dr As DataRow
        dr = dtDetalle.NewRow
        dr(0) = cmbtipoequipo.Value
        dr(1) = cmbtipoequipo.Text
        dr(2) = txtcodequipo.Text
        dr(3) = txtequipo.Text
        dr(4) = txtentrada.Text
        dr(5) = txtsalida.Text
        dr(6) = txtcantidad1.Text
        dr(7) = cmbtipotareo.Value
        dr(8) = cmbtipotareo.Text
        dr(9) = cmbtipotrabajo.Value
        dr(10) = cmbtipotrabajo.Text
        dr(11) = txtcodmaterial1.Text
        dr(12) = txtmaterial1.Text
        dr(13) = txtcantmaterial.Text
        dr(14) = txtUM1.Text
        dr(15) = "0.00000"
        dr(16) = "0.00000"
        dr(17) = "0.00000"
        dtDetalle.Rows.Add(dr)
        Call CargarUltraGrid(gridDetalle, dtDetalle)
    End Sub
    Sub llenaIngresoSalida()
        Dim dr As DataRow
        dr = dtDetalle.NewRow
        dr(0) = ""
        dr(1) = ""
        dr(2) = ""
        dr(3) = ""
        dr(4) = "0.00000"
        dr(5) = "0.00000"
        dr(6) = "0.00000"
        dr(7) = ""
        dr(8) = ""
        dr(9) = "C" 'cmbtipotrabajo1.Value
        dr(10) = "CANTERA" 'cmbtipotrabajo1.Text
        dr(11) = txtcodmaterial.Text
        dr(12) = txtmaterial.Text
        dr(13) = txtcantidad.Text
        dr(14) = txtUM.Text
        dr(15) = "0.00000"
        dr(16) = "0.00000"
        dr(17) = "0.00000"
        dtDetalle.Rows.Add(dr)
        Call CargarUltraGrid(gridDetalle, dtDetalle)
    End Sub
    Sub limpiarIngresoSalida()
        txtcodmaterial.Clear()
        txtmaterial.Clear()
        txtcantidad.Clear()
        txtUM.Clear()
        cmbtipotrabajo1.SelectedIndex = -1
    End Sub
    Sub limpiarConsumo()
        txtentrada.Clear()
        txtsalida.Clear()
        txtcodmaterial1.Clear()
        txtmaterial1.Clear()
        txtcantmaterial.Clear()
        txtUM1.Clear()
        txtentrada.Focus()
    End Sub
    Sub creaTablaDetalle()
        dtDetalle.Columns.Add("COD_TIPOEQUIPO")
        dtDetalle.Columns.Add("TIPOEQUIPO")
        dtDetalle.Columns.Add("COD_EQUIPO")
        dtDetalle.Columns.Add("EQUIPO")
        dtDetalle.Columns.Add("ENTRADA")
        dtDetalle.Columns.Add("SALIDA")
        dtDetalle.Columns.Add("CANTMAQUINA")
        dtDetalle.Columns.Add("COD_TIPOTAREO")
        dtDetalle.Columns.Add("TIPOTAREO")
        dtDetalle.Columns.Add("COD_TIPOTRABAJO")
        dtDetalle.Columns.Add("TIPOTRABAJO")
        dtDetalle.Columns.Add("COD_MATERIAL")
        dtDetalle.Columns.Add("MATERIAL")
        dtDetalle.Columns.Add("CANTIDAD")
        dtDetalle.Columns.Add("UM")
        dtDetalle.Columns.Add("CANT_PEDIDA")
        dtDetalle.Columns.Add("VALOR")
        dtDetalle.Columns.Add("TOTALDESPACHADO")
        dtDetalle.Columns.Add("ITEM")
    End Sub

    Private Sub txtcantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtalmorigen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtalmorigen.KeyPress, txtalmdestino.KeyPress, txtcliente.KeyPress, txtcodequipo.KeyPress, txtcodmaterial1.KeyPress, txtcodmaterial.KeyPress
        Buscar()
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        If Not VerificarControl(5, gridDetalle) Then
            MessageBox.Show("No tiene registro para quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If gridDetalle.ActiveRow Is Nothing Then
            MessageBox.Show("No tiene un registro seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MsgBox("¿Desea eliminar registro seleccionado?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        dtDetalle.Rows.RemoveAt(gridDetalle.ActiveRow.Index)
        'gridDetalle.ActiveRow.Delete()
        'MsgBox(dtDetalle.Rows.Count)
    End Sub

    Private Sub gridDetalle_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridDetalle.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridDetalle Then Return
        e.DisplayPromptMsg = Boolean.FalseString
    End Sub
    Function validarCabecera() As Boolean
        If cmbtipoMovimiento.Value = Nothing Then
            MessageBox.Show("Seleccione tipo de movimiento", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbtipoMovimiento.Focus()
            Return False
        End If
        If txtoc.Visible = True Then
            If txtoc.Text.Trim = "" Then
                MessageBox.Show("Ingrese N° de OC", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtoc.Focus()
                Return False
            End If
        End If
        If cmbtipo.SelectedIndex < 0 Then
            MessageBox.Show("Seleccione tipo de material", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbtipo.Focus()
            Return False
        End If
        If txtalmorigen.Text.Trim = "" Then
            MessageBox.Show("Ingrese almacén", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtalmorigen.Focus()
            Return False
        End If
        If txtalmdestino.Visible = True Then
            If txtalmdestino.Text.Trim = "" Then
                MessageBox.Show("Ingrese almacén destino", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtalmdestino.Focus()
                Return False
            End If
            If txtidalmdestino.Text.Trim = txtidalmorigen.Text.Trim Then
                MessageBox.Show("El almacén origen y destino deben ser diferentes", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtidalmdestino.Focus()
                Return False
            End If
        End If
        If txtcliente.Visible = True Then
            If txtcliente.Text.Trim = "" Then
                MessageBox.Show("Ingrese cliente", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtcliente.Focus()
                Return False
            End If
        End If       
        'If gridDetalle.Visible = True Then
        '    If gridDetalle.Rows.Count <= 0 Then
        '        MessageBox.Show("Debe ingresar mínimo un movimiento detalle", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Return False
        '    End If
        'Else
        '    If gridDetalleOC.Rows.Count <= 0 Then
        '        MessageBox.Show("Debe ingresar mínimo un movimiento detalle", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Return False
        '    End If
        'End If
        Return True
    End Function
    Function validarDetalle() As Boolean
        gridDetalle.PerformAction(ExitEditMode)
        gridDetalle.PerformAction(BelowCell)
        gridDetalle.PerformAction(EnterEditMode)

        Dim total As Double = 0
        'If gridDetalle.Visible = True Then
        '    For i As Int32 = 0 To gridDetalle.Rows.Count - 1
        '        total = total + gridDetalle.Rows(i).Cells("CANTIDAD").Value
        '    Next
        'Else
        For i As Int32 = 0 To dtDetalle.Rows.Count - 1
            total = total + CDbl(dtDetalle.Rows(i)("CANTIDAD"))
            If gridDetalleOC.Visible = True Then
                If CDbl(dtDetalle.Rows(i)("CANT_PEDIDA")) < CDbl(dtDetalle.Rows(i)("CANTIDAD")) + CDbl(dtDetalle.Rows(i)("TOTALDESPACHADO")) Then
                    MessageBox.Show("No puede ingresar cantidad mayor a la solicitada en la fila " & i + 1, msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            End If
        Next
        'End If
        If total <= 0 Then
            MessageBox.Show("Debe ingresar cantidad como mínimo en un registro", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function
    Sub Grabar()
        Try
            If Tab1.SelectedTab.Key <> "T02" Then Return
            If Ope = 0 Then
                MessageBox.Show("Tiene que Seleccionar una opción para Actualizar", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Not validarCabecera() Then Exit Sub
            If Not validarDetalle() Then Exit Sub
            If dtDetalle.Rows.Count <= 0 Then
                MessageBox.Show("Debe ingresar mínimo un movimiento detalle", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Return
            End If
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            objEntidad = New ETContratista
            objNegocio = New NGContratista
            With objEntidad
                .Tipo = Ope
                .ID = txtidmovimiento.Text
                ._idtipomov = cmbtipoMovimiento.Value
                .Fecha = dtFecha.Value
                ._tipomaterial = cmbtipo.Value
                ._numorden = txtoc.Text
                ._codalmori = txtidalmorigen.Text
                ._codalmdest = txtidalmdestino.Text
                ._codcli = txtcodcliente.Text
                ._codcanteraori = txtcodcanteraori.Text
                ._codcanteradest = txtcodcanteradest.Text
                ._usuario = User_Sistema
            End With
            objNegocio.Mant_MovimientoCombExplosivo(objEntidad, dtDetalle)
            Dim Mensaje As String = "Se grabó con éxito el registro"
            MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
            Call Nuevo()
            CargarDatos()
            Tab1.Tabs("T01").Selected = Boolean.TrueString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub gridDetalleOC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDetalleOC.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridDetalleOC) Then Return
            With sender
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Down
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Right
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Left
                        .PerformAction(ExitEditMode)
                        .PerformAction(PrevCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Return
                        .PerformAction(ExitEditMode)
                        If gridDetalleOC.ActiveRow.Cells(gridDetalleOC.ActiveCell.Column.Index).Column.Key = "CANTIDAD" Then

                            If CDbl(gridDetalleOC.ActiveRow.Cells("CANT_PEDIDA").Value) < CDbl(gridDetalleOC.ActiveRow.Cells("CANTIDAD").Value) + CDbl(gridDetalleOC.ActiveRow.Cells("TOTALDESPACHADO").Value) Then
                                MessageBox.Show("No puede ingresar cantidad mayor a la solicitada", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                gridDetalleOC.ActiveRow.Cells("CANTIDAD").Value = 0
                                .PerformAction(EnterEditMode)
                                Exit Sub
                            End If
                            .PerformAction(ExitEditMode)
                            .PerformAction(BelowCell)
                            e.Handled = Boolean.TrueString
                            .PerformAction(EnterEditMode)
                        Else
                            .PerformAction(NextCellByTab)
                            e.Handled = Boolean.TrueString
                            .PerformAction(EnterEditMode)
                        End If
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridMovimiento_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridMovimiento.DoubleClickRow
        Try
            Dim numdoc As String
            numdoc = gridMovimiento.ActiveRow.Cells("NUMDOC").Value.ToString.Trim
            cargarDatos_Numero(numdoc)
            Me.Tab1.Tabs("T02").Selected = True
        Catch ex As Exception

        End Try
    End Sub
    Sub cargarDatos_Numero(ByVal numdoc As String)
        objEntidad = New ETContratista
        objNegocio = New NGContratista
        objEntidad._numorden = numdoc
        Dim dsDatos As New DataSet
        Dim dtCabecera As New DataTable
        dsDatos = objNegocio.ListarMovimientoNumero(objEntidad)
        dtCabecera = dsDatos.Tables(0)
        If dtCabecera.Rows.Count > 0 Then
            lblnumero.Visible = True
            lblnumero.Text = "TICKET N° " & numdoc.Trim
            txtidmovimiento.Text = dtCabecera.Rows(0)("ID")
            cmbtipoMovimiento.Value = dtCabecera.Rows(0)("IDTIPOMOV")
            dtFecha.Value = dtCabecera.Rows(0)("FECHA_EMISION")
            cmbtipo.Value = dtCabecera.Rows(0)("TIPO_MATERIAL")
            txtoc.Text = dtCabecera.Rows(0)("NUM_REFERENCIA")
            txtidalmorigen.Text = dtCabecera.Rows(0)("COD_ALMORI")
            txtalmorigen.Text = dtCabecera.Rows(0)("ALMORI")
            txtidalmdestino.Text = dtCabecera.Rows(0)("CODALMDEST")
            txtalmdestino.Text = dtCabecera.Rows(0)("ALMDESTINO")
            txtcodcanteraori.Text = dtCabecera.Rows(0)("CANTERAORI")
            txtcodcanteradest.Text = dtCabecera.Rows(0)("CANTERADEST")
            txtcodcliente.Text = dtCabecera.Rows(0)("COD_CLI")
            txtcliente.Text = dtCabecera.Rows(0)("CLIENTE")
            Tipo_Equipo()
        End If
        dtDetalle = dsDatos.Tables(1)
        If dsDatos.Tables(2).Rows(0)(0) = 0 Then
            Call CargarUltraGrid(gridDetalle, dtDetalle)
        Else
            Call CargarUltraGrid(gridDetalleOC, dtDetalle)
        End If
        pnlPrincipal.Enabled = False
    End Sub

    Sub Eliminar()
        Try
            If Tab1.SelectedTab.Key <> "T02" Then Return
            If txtidmovimiento.Text = 0 Then
                MessageBox.Show("Debe seleccionar un registro a eliminar", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If MsgBox("¿Seguro desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Return
            End If
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            objEntidad = New ETContratista
            objNegocio = New NGContratista
            With objEntidad
                .Tipo = 3
                .ID = txtidmovimiento.Text
                ._idtipomov = cmbtipoMovimiento.Value
                .Fecha = dtFecha.Value
                ._tipomaterial = cmbtipo.Value
                ._numorden = txtoc.Text
                ._codalmori = txtidalmorigen.Text
                ._codalmdest = txtidalmdestino.Text
                ._codcli = txtcodcliente.Text
                ._codcanteraori = txtcodcanteraori.Text
                ._codcanteradest = txtcodcanteradest.Text
                ._usuario = User_Sistema
            End With
            objNegocio.Mant_MovimientoCombExplosivo(objEntidad, New DataTable)
            Dim Mensaje As String = "Se eliminó con éxito el registro"
            MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
            Call Nuevo()
            CargarDatos()
            Tab1.Tabs("T01").Selected = Boolean.TrueString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub txtoc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtoc.KeyPress
        Buscar()
    End Sub
End Class