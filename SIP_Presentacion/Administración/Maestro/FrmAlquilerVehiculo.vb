Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmAlquilerVehiculo
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
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
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
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
    Dim dtTarifa As New DataTable

    Private Sub FrmAlquilerVehiculo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFecha.Value = Now.Date
        Procesar()
        CargarTipoVehiculo()
        CargarTipoFacturacion()
        CargarMoneda()
    End Sub

    Sub Nuevo()
        Call LimpiarDatos()
        Ope = 1
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
    End Sub

    Sub LimpiarDatos()
        txtcodprov.Clear()
        txtproveedor.Clear()
        txtplaca.Clear()
        txtdescripcion.Clear()
        txtimporte.Clear()
        txtobservaciones.Clear()
        cmbMoneda.Value = ""
        cmbtipovehiculo.Value = ""
        cmbtipofact.Value = ""
        txtid.Text = 0
        chkcombustible.Checked = False
        chkoperador.Checked = False
        dtpFecha.Value = Now.Date
        txtcodprov.Enabled = True
        txtproveedor.Enabled = True
        txtplaca.Enabled = True
        dtTarifa = New DataTable
        Agregar()
        Ope = 0
    End Sub

    Sub Buscar()
        If txtcodprov.Focused = True Then
            Dim frm As New FrmListaTransportista
            frm.ShowDialog()
            txtcodprov.Text = codMotivodetalle.Trim
            txtproveedor.Text = Motivodetalle.Trim
        End If
    End Sub
    Sub procesar()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Dim dtDatos As New DataTable
        dtDatos = Negocio.NEntregas.CargarAlquilerVehiculo()
        Call CargarUltraGridxBinding(GridAlquilerVehiculo, Source1, dtDatos)
        Call LimpiarDatos()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
        'cmbMoneda.Value = "01"
    End Sub
    Private Sub CargarTipoVehiculo()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Dim dtDatos As New DataTable
        dtDatos = Negocio.NEntregas.CargarTipoVehiculo()
        Call CargarUltraCombo(cmbtipovehiculo, dtDatos, "cod_maestro2", "descrip")
        cmbtipovehiculo.Value = ""
    End Sub
    Private Sub CargarTipoFacturacion()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Dim dtDatos As New DataTable
        dtDatos = Negocio.NEntregas.CargarTipoFacturacion()
        Call CargarUltraCombo(cmbtipofact, dtDatos, "cod_maestro2", "descrip")
        cmbtipofact.Value = ""
    End Sub
    Private Sub CargarMoneda()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Dim dtDatos As New DataTable
        dtDatos = Negocio.NEntregas.CargarMonedas()
        Call CargarUltraCombo(cmbMoneda, dtDatos, "cod_maestro2", "descrip")
        cmbMoneda.Value = ""
    End Sub

    Private Sub cmbMoneda_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbMoneda.InitializeLayout
        With cmbMoneda.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descrip").Width = sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descrip") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbtipovehiculo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbtipovehiculo.InitializeLayout
        With cmbtipovehiculo.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descrip").Width = 200 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descrip") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbtipofact_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbtipofact.InitializeLayout
        With cmbtipofact.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descrip").Width = sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descrip") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub txtcodprov_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodprov.KeyPress
        Buscar()
    End Sub

    Sub grabar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Not Verificar_Datos() Then
            'MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Ope = 1 Then
            Negocio.NEntregas = New NGEntregas
            Entidad.MyLista = New ETMyLista
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NEntregas.VerificaPlaca(txtplaca.Text, cmbtipofact.Value)
            If dtDatos.Rows.Count > 0 Then
                MessageBox.Show("La placa ya se encuentra registrada", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        gridTarifa.PerformAction(ExitEditMode)
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        For i As Int32 = 0 To dtTarifa.Rows.Count - 1
            Entidad.Entregas = New ETEntregas
            Negocio.NEntregas = New NGEntregas
            Entidad.Entregas.Tipo = 1
            If txtid.Text = "" Then txtid.Text = 0
            Entidad.Entregas.ID = dtTarifa.Rows(i)("ID")
            Entidad.Entregas.codprov = txtcodprov.Text
            Entidad.Entregas.Razon = txtproveedor.Text
            Entidad.Entregas.placa = txtplaca.Text
            Entidad.Entregas.tvehiculo = cmbtipovehiculo.Value
            Entidad.Entregas.tfacturacion = cmbtipofact.Value
            Entidad.Entregas.moneda = cmbMoneda.Value
            Entidad.Entregas.montoTotal = dtTarifa.Rows(i)("TARIFA")
            'Entidad.Entregas.montoTotal = txtimporte.Text
            Entidad.Entregas.FechaInicio = dtpFecha.Value
            Entidad.Entregas.flgcombustible = IIf(dtTarifa.Rows(i)("COMBUSTIBLE") = True, 1, 0)
            Entidad.Entregas.flgoperador = IIf(dtTarifa.Rows(i)("OPERADOR") = True, 1, 0)
            'Entidad.Entregas.flgcombustible = IIf(chkcombustible.Checked = True, 1, 0)
            'Entidad.Entregas.flgoperador = IIf(chkoperador.Checked = True, 1, 0)
            Entidad.Entregas.Descripcion = txtdescripcion.Text
            Entidad.Entregas.Observacion = txtobservaciones.Text
            Entidad.Entregas.Usuario = User_Sistema
            Entidad.Entregas = Negocio.NEntregas.MantenimientoAlquilerVehiculo(Entidad.Entregas)
        Next
        MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
        If Entidad.Entregas.Validacion Then
            Call actualizar()
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Sub Eliminar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Not Verificar_Datos() Then
            Return
        End If
        If MsgBox("¿Seguro desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.Entregas.Tipo = 3
        If txtid.Text = "" Then txtid.Text = 0
        Entidad.Entregas.ID = txtid.Text
        Entidad.Entregas.codprov = txtcodprov.Text
        Entidad.Entregas.Razon = txtproveedor.Text
        Entidad.Entregas.placa = txtplaca.Text
        Entidad.Entregas.tvehiculo = cmbtipovehiculo.Value
        Entidad.Entregas.tfacturacion = cmbtipofact.Value
        Entidad.Entregas.moneda = cmbMoneda.Value
        Entidad.Entregas.montoTotal = txtimporte.Text
        Entidad.Entregas.FechaInicio = dtpFecha.Value
        Entidad.Entregas.flgcombustible = IIf(chkcombustible.Checked = True, 1, 0)
        Entidad.Entregas.Descripcion = txtdescripcion.Text
        Entidad.Entregas.Observacion = txtobservaciones.Text
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.Entregas = Negocio.NEntregas.MantenimientoAlquilerVehiculo(Entidad.Entregas)
        MsgBox("Se eliminó correctamente el registro", MsgBoxStyle.Information, msgComacsa)
        If Entidad.Entregas.Validacion Then
            Call actualizar()
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Sub actualizar()
        Call LimpiarDatos()
        Procesar()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
    End Sub

    Function Verificar_Datos() As Boolean
        Dim lResult As Boolean = Boolean.TrueString
        If txtcodprov.Text.Trim = "" Then MessageBox.Show("Debe ingresar proveedor", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : lResult = False : Return lResult
        If txtplaca.Text.Trim = "" Then MessageBox.Show("Debe ingresar placa", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : lResult = False : Return lResult
        If cmbtipovehiculo.Value Is Nothing Then MessageBox.Show("Debe ingresar tipo de vehículo", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : lResult = False : Return lResult
        If cmbtipofact.Value Is Nothing Then MessageBox.Show("Debe ingresar tipo de facturación", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : lResult = False : Return lResult
        If cmbMoneda.Value Is Nothing Then MessageBox.Show("Debe ingresar moneda", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : lResult = False : Return lResult
        If txtimporte.Text.Trim = "" Then txtimporte.Text = 0

        'If txtimporte.Text <= 0 Then MessageBox.Show("Debe ingresar importe", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : lResult = False : Return lResult

        Return lResult
        'If txtcodprov.Text.Trim = "" Then MessageBox.Show("Debe ingresar proveedor", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : lResult = False
        'If txtcodprov.Text.Trim = "" Then MessageBox.Show("Debe ingresar proveedor", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : lResult = False
    End Function

    Private Sub GridAlquilerVehiculo_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridAlquilerVehiculo.DoubleClickRow
        Try
            If GridAlquilerVehiculo.ActiveRow.Index < 0 Then Exit Sub
            txtcodprov.Text = GridAlquilerVehiculo.ActiveRow.Cells("CODPROVEEDOR").Value.ToString.Trim
            txtproveedor.Text = GridAlquilerVehiculo.ActiveRow.Cells("RAZON").Value.ToString.Trim
            txtplaca.Text = GridAlquilerVehiculo.ActiveRow.Cells("PLACA").Value.ToString.Trim
            cmbtipovehiculo.Value = GridAlquilerVehiculo.ActiveRow.Cells("TVEHICULO").Value.ToString.Trim
            cmbtipofact.Value = GridAlquilerVehiculo.ActiveRow.Cells("TFACTURACION").Value.ToString.Trim
            txtdescripcion.Text = GridAlquilerVehiculo.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
            cmbMoneda.Value = GridAlquilerVehiculo.ActiveRow.Cells("CODMONEDA").Value.ToString.Trim
            txtobservaciones.Text = GridAlquilerVehiculo.ActiveRow.Cells("OBSERVACION").Value.ToString.Trim
            txtimporte.Text = GridAlquilerVehiculo.ActiveRow.Cells("IMPORTE").Value.ToString.Trim
            dtpFecha.Value = GridAlquilerVehiculo.ActiveRow.Cells("FECHAINICIO").Value.ToString.Trim
            chkcombustible.Checked = IIf(GridAlquilerVehiculo.ActiveRow.Cells("FLGCOMBUSTIBLE").Value = 1, True, False)
            chkoperador.Checked = IIf(GridAlquilerVehiculo.ActiveRow.Cells("FLGOPERADOR").Value = 1, True, False)
            txtid.Text = GridAlquilerVehiculo.ActiveRow.Cells("ID").Value.ToString.Trim
            Ope = 2
            txtcodprov.Enabled = False
            txtproveedor.Enabled = False
            txtplaca.Enabled = False

            Negocio.NEntregas = New NGEntregas
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.codprov = txtcodprov.Text
            Entidad.Entregas.placa = txtplaca.Text
            Entidad.Entregas.tvehiculo = cmbtipovehiculo.Value
            Entidad.Entregas.tfacturacion = cmbtipofact.Value
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NEntregas.CargarAlquilerVehiculoPlaca(Entidad.Entregas)
            dtTarifa = New DataTable
            If dtTarifa.Columns.Count <= 0 Then
                dtTarifa.Columns.Add("DESCRIPCION")
                dtTarifa.Columns.Add("TARIFA")
                dtTarifa.Columns.Add("COMBUSTIBLE")
                dtTarifa.Columns.Add("OPERADOR")
                dtTarifa.Columns.Add("ID")
            End If
            If dtDatos.Rows.Count > 0 Then
                Dim dr As DataRow
                For i As Int32 = 0 To dtDatos.Rows.Count - 1
                    dr = dtTarifa.NewRow
                    dr(0) = "TARIFA " & i + 1
                    dr(1) = dtDatos.Rows(i)("IMPORTE")
                    dr(2) = IIf(dtDatos.Rows(i)("FLGCOMBUSTIBLE") = 1, True, False)
                    dr(3) = IIf(dtDatos.Rows(i)("FLGOPERADOR") = 1, True, False)
                    dr(4) = dtDatos.Rows(i)("ID")
                    dtTarifa.Rows.Add(dr)
                Next
                Call CargarUltraGrid(gridTarifa, dtTarifa)
            End If
            TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtimporte_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtimporte.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtimporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtimporte.KeyDown
        If Not (e.KeyValue = Keys.Enter) Then Return
        If txtimporte.Text = "" Then txtimporte.Text = "0.00"
        txtimporte.Text = CDbl(txtimporte.Text).ToString("###0.00")
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Agregar()
    End Sub
    Sub Agregar()
        If dtTarifa.Columns.Count <= 0 Then
            dtTarifa.Columns.Add("DESCRIPCION")
            dtTarifa.Columns.Add("TARIFA")
            dtTarifa.Columns.Add("COMBUSTIBLE")
            dtTarifa.Columns.Add("OPERADOR")
            dtTarifa.Columns.Add("ID")
        End If
        Dim dr As DataRow
        dr = dtTarifa.NewRow
        dr(0) = "TARIFA " & dtTarifa.Rows.Count + 1
        dr(1) = "0.00"
        dr(2) = False
        dr(3) = False
        dr(4) = 0
        dtTarifa.Rows.Add(dr)
        Call CargarUltraGrid(gridTarifa, dtTarifa)
    End Sub

    Private Sub gridTarifa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridTarifa.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridTarifa) Then Return
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
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class