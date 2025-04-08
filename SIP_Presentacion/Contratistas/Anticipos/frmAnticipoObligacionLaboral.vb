Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmAnticipoObligacionLaboral
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
    Dim lResult As ETMyLista = Nothing
    Dim codbanco As String = ""
    Dim nrocta As String = ""
    Dim renta As Int32 = 2
    Private Ls_Anticipo As List(Of ETContratista) = Nothing
    Private Ls_EntregaDetalle As List(Of ETContratista) = Nothing
    Dim x_mes As Int32 = 0
    Dim x_quincena As Int32 = 0
    Dim x_semanaini As Int32 = 0
    Dim x_semanafin As Int32 = 0
    Dim x_descripcion = ""
    Sub Buscar()
        If Me.TabMaestroEntregas.Tabs("Lista").Selected = True Then Exit Sub
        If txtcodcontratista.Focused = True Then
            limpiar()
            Dim frm As New frmBuscarContratista
            frm.ShowDialog()
            txtcodcontratista.Text = frm.gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            txtcontratista.Text = frm.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            txtbeneficiario.Text = frm.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            Dim idtipopago As String = frm.gridcontratista.ActiveRow.Cells("TIPOPAGO").Value
            Dim idfrecuenia As Int32 = frm.gridcontratista.ActiveRow.Cells("IDFRECPAGO").Value
            codbanco = frm.gridcontratista.ActiveRow.Cells("CODBANCO").Value.ToString.Trim
            nrocta = frm.gridcontratista.ActiveRow.Cells("NROCTA").Value.ToString.Trim
            rdbDeposito_CheckedChanged(Nothing, Nothing)
        End If
        If txtcodcantera.Focused = True Then
            limpiar()
            If txtcodcontratista.Text.Trim = "" Then
                MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            Dim frm As New frmBuscarCantera
            frm.codprov = txtcodcontratista.Text
            frm.ShowDialog()
            txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            txtcodcantera.Text = frm.gridcontratista.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcantera.Text = frm.gridcontratista.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
            limpiarobligaciones()
            cmbgrupo.Value = 1
            ' VER LA CANTIDAD DE SUPERVISORES QUE HAY POR CANTERA
            Supervisor_Cantera(txtcodcontratista.Text, txtcodcantera.Text)
            'btnCanteras.Visible = True
        End If
        If txtsupervisor.Focused = True Then
            If txtcodcantera.Text.Trim = "" Then
                MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            Dim frm As New frmBuscarSupervisor
            frm.codprov = txtcodcontratista.Text
            frm.cod_cantera = txtcodcantera.Text
            frm.ShowDialog()
            If frm.gridcontratista.Rows.Count = 0 Then
                txtidsupervisor.Text = 0
                txtsupervisor.Text = ""
            Else
                txtidsupervisor.Text = frm.gridcontratista.ActiveRow.Cells("ID_SUPERVISOR").Value
                txtsupervisor.Text = frm.gridcontratista.ActiveRow.Cells("SUPERVISOR").Value.ToString.Trim
            End If
        End If
    End Sub
    Dim cant_supervisor As Int32 = 0
    Sub Supervisor_Cantera(ByVal codprov As String, ByVal cod_cantera As String)
        Try
            Dim objNegocio As NGContratista = Nothing
            Dim objEntidad As ETContratista = Nothing
            objNegocio = New NGContratista
            objEntidad = New ETContratista

            objEntidad._codprov = codprov
            objEntidad._codcantera = cod_cantera
            Dim dtContratista As New DataTable
            dtContratista = objNegocio.ListarSupervisor_Contratista(objEntidad)
            cant_supervisor = dtContratista.Rows.Count
            If cant_supervisor = 1 Then
                txtidsupervisor.Text = dtContratista.Rows(0)(0)
                txtsupervisor.Text = dtContratista.Rows(0)(1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub limpiar()
        txtcodcantera.Clear()
        txtcantera.Clear()
        txtsubtotal.Clear()
        txttotalotros.Clear()
        txttotal.Clear()
        txtidcontratista.Text = 0
        txtidsupervisor.Text = 0
        txtsupervisor.Clear()
        cmbgrupo.Value = 1
        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            gridconceptos.Rows(i).Cells("TOTAL").Value = "0.00"
        Next
        limpiarobligaciones()
        'btnCanteras.Visible = False
        VisualizarDatosDeposito(False)
        dtCanteras = New DataTable
        chkbeneficiario.Checked = False
    End Sub
    Sub limpiarobligaciones()
        For i As Int32 = 0 To gridObligaciones.Rows.Count - 1
            gridObligaciones.Rows(i).Cells("TOTAL").Value = "0.00"
        Next
    End Sub

    Private Sub frmAnticipoObligacionLaboral_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Procesar()
    End Sub
    Private Sub frmAnticipoObligacionLaboral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDesde.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
        dtpHasta.Value = Now.Date
        Procesar()
        txtayo.Value = Now.Date.Year
        cmbgrupo.Value = 1
    End Sub
    Sub Procesar()
        CargarDatos()
        CargarConceptos("")
        CargarBancos()
        CargarMonedas()
        Me.TabMaestroEntregas.Tabs("Lista").Selected = True
    End Sub
    Sub Actualizar()
        Procesar()
    End Sub
    Private Sub CargarMonedas()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Anticipo = Nothing
        Ls_Anticipo = New List(Of ETContratista)
        Entidad.MyLista = Negocio.NContratista.ListarMonedas
        If Entidad.MyLista.Validacion Then
            Ls_Anticipo = Entidad.MyLista.Ls_Anticipo
        End If
        Call CargarUltraCombo(cmbMoneda, Ls_Anticipo, "codmoneda", "moneda")
        cmbMoneda.Value = "01"
    End Sub
    Sub CargarConceptos(ByVal numSolicitud As String)
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        objEntidad._tipo = 2
        objEntidad._tipoanticipo = "OL"
        objEntidad.NumSolicitud = numSolicitud
        dtDatos = objNegocio.Listarconceptos(objEntidad)
        Call CargarUltraGridxBinding(gridconceptos, Source1, dtDatos)
    End Sub

    Sub CargarObligaciones()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        objEntidad._codprov = txtcodcontratista.Text
        objEntidad._codcantera = txtcodcantera.Text
        objEntidad._tipo = cmbgrupo.Value
        objEntidad._ayo = txtayo.Value
        objEntidad._mes = cmbMes.Value
        dtDatos = objNegocio.ListarObligaciones(objEntidad)
        Dim dr As DataRow
        If saldototal < 0 And cmbgrupo.Value = 1 Then
            dr = dtDatos.NewRow
            dr(0) = 8
            dr(1) = "SALDO IMPUESTO MES"
            dr(2) = CDbl(saldototal * -1).ToString("##0.00")
            dr(3) = "0.00"
            dr(4) = "SALDO IMPUESTO MES"
            dr(5) = 1
            dtDatos.Rows.Add(dr)
        End If

        Call CargarUltraGridxBinding(gridObligaciones, Source2, dtDatos)
        For I As Int32 = 0 To gridObligaciones.Rows.Count - 1
            If gridObligaciones.Rows(I).Cells("FLGOBLIGATORIO").Value.ToString = 0 Then
                gridObligaciones.Rows(I).Cells("TOTAL").Activation = Activation.AllowEdit
            Else
                gridObligaciones.Rows(I).Cells("TOTAL").Activation = Activation.ActivateOnly
            End If
        Next
        calcularTotal()
        'btnCanteras.Visible = True
    End Sub

    Sub detalleObligaciones(ByVal concepto As String)
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        objEntidad._codprov = txtcodcontratista.Text
        objEntidad._codcantera = txtcodcantera.Text
        objEntidad._descripcion = concepto
        objEntidad._ayo = txtayo.Value
        objEntidad._mes = cmbMes.Value
        dtDatos = objNegocio.detalleObligaciones(objEntidad)
        If dtDatos.Rows.Count <= 0 Then
            MsgBox("No existe datos para mostrar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Dim frm As New frmdetalleObligaciones
        'frm.gridPlanilla.DisplayLayout.Bands(0).ColHeadersVisible("TOTAL") = True
        frm.Text = "PAGO DE " & concepto
        frm.concepto = concepto
        frm.dtPlanilla = dtDatos
        frm.ShowDialog()
    End Sub

    Private Sub CargarBancos()
        Dim objNegocio As NGContratista = Nothing
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtBanco As New DataTable
        dtBanco = objNegocio.ListarBanco()
        Call CargarUltraCombo(cmbbanco, dtBanco, "cod_maestro2", "descrip")
    End Sub
    Sub Nuevo()
        Me.TabMaestroEntregas.Tabs("Registro").Selected = True
        txtcodcontratista.Clear()
        txtcontratista.Clear()
        rdbDeposito.Enabled = True
        rdbCheque.Enabled = True
        Ope = 1
        estado = "PENDIENTE"
        nroSolicitud = String.Empty
        lblnSolicitud.Visible = Boolean.FalseString
        flgaprobada = 0
        lblestado.Visible = False
        limpiar()
        txtcodcontratista.Focus()
        Ls_Anticipo = New List(Of ETContratista)
        Ls_EntregaDetalle = New List(Of ETContratista)
        cmbMes.ReadOnly = False
        cmbgrupo.ReadOnly = False
        chkAprobar.Visible = False
        chkAprobar.Checked = False
        gridconceptos.Enabled = True
        btnCalcular.Enabled = True
    End Sub

    Private Sub gridconceptos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridconceptos.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridconceptos) Then Return
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
                        txttotalotros.Text = 0
                        calcularTotal()
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
    Dim saldoutilizado As Double = 0
    Sub calcularTotal()
        gridconceptos.PerformAction(ExitEditMode)
        txttotalotros.Text = 0
        txtsubtotal.Text = 0
        If txtsubtotal.Text.ToString.Trim = "" Then txtsubtotal.Text = 0
        Dim importe As Double
        Dim saldototalSub As Double = 0
        saldototalSub = IIf(saldototal < 0, saldototal * -1, 0)
        'MsgBox(saldototal)
        Dim essalud As Double = 0
        Dim onp As Double = 0
        Dim esavida As Double = 0
        Dim fminero As Double = 0
        Dim saldoresto As Double = saldototalSub
        saldoutilizado = 0

        For i As Int32 = 0 To gridObligaciones.Rows.Count - 1

            Select Case gridObligaciones.Rows(i).Cells("CONCEPTO").Value
                Case Is = "ESSALUD"
                    essalud = essalud + gridObligaciones.Rows(i).Cells("TOTAL").Value
                    If saldoresto > 0 Then
                        If saldoresto > essalud Then
                            gridObligaciones.Rows(i).Cells("DSCTO").Value = essalud.ToString("#####0.00")
                        Else
                            gridObligaciones.Rows(i).Cells("DSCTO").Value = saldoresto.ToString("#####0.00")
                        End If
                        saldoresto = saldoresto - essalud
                    End If

                Case Is = "ESSALUD_VIDA"
                    esavida = esavida + gridObligaciones.Rows(i).Cells("TOTAL").Value
                    If saldoresto > 0 Then
                        If saldoresto > esavida Then
                            gridObligaciones.Rows(i).Cells("DSCTO").Value = esavida.ToString("#####0.00")
                        Else
                            gridObligaciones.Rows(i).Cells("DSCTO").Value = saldoresto.ToString("#####0.00")
                        End If
                        saldoresto = saldoresto - esavida
                    End If

                Case Is = "FMINERO"
                    fminero = fminero + gridObligaciones.Rows(i).Cells("TOTAL").Value
                    If saldoresto > 0 Then
                        If saldoresto > fminero Then
                            gridObligaciones.Rows(i).Cells("DSCTO").Value = fminero.ToString("#####0.00")
                        Else
                            gridObligaciones.Rows(i).Cells("DSCTO").Value = saldoresto.ToString("#####0.00")
                        End If
                        saldoresto = saldoresto - fminero
                    End If

                Case Is = "ONP"
                    onp = onp + gridObligaciones.Rows(i).Cells("TOTAL").Value
                    If saldoresto > 0 Then
                        If saldoresto > onp Then
                            gridObligaciones.Rows(i).Cells("DSCTO").Value = onp.ToString("#####0.00")
                        Else
                            gridObligaciones.Rows(i).Cells("DSCTO").Value = saldoresto.ToString("#####0.00")
                        End If
                        saldoresto = saldoresto - onp
                    End If

            End Select
            'MsgBox(saldototal)
            saldoutilizado = saldoutilizado + gridObligaciones.Rows(i).Cells("DSCTO").Value
            'MsgBox(saldoutilizado)
            If gridObligaciones.Rows(i).Cells("CONCEPTO").Value <> "SALDO IMPUESTO MES" Then
                importe = CDbl(gridObligaciones.Rows(i).Cells("TOTAL").Value) - CDbl(gridObligaciones.Rows(i).Cells("DSCTO").Value)
                txtsubtotal.Text = CDbl(txtsubtotal.Text) + importe
            End If
        Next

        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            importe = CDbl(gridconceptos.Rows(i).Cells("TOTAL").Value)
            Dim _variacion As String
            _variacion = gridconceptos.Rows(i).Cells("VARIACION").Value.ToString.Trim
            txttotalotros.Text = CDbl(txttotalotros.Text) + IIf(_variacion = "AUMENTA", importe, importe * -1)
        Next
        txttotalotros.Text = CDbl(txttotalotros.Text).ToString("#####0.00")
        txttotal.Text = CDbl(txtsubtotal.Text) + CDbl(txttotalotros.Text)
        txttotal.Text = CDbl(txttotal.Text).ToString("#####0.00")
    End Sub

    Private Sub chkbeneficiario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbeneficiario.CheckedChanged
        If chkbeneficiario.Checked = True Then
            txtdnibeneficiario.ReadOnly = False
            txtbeneficiario.ReadOnly = False
            txtdnibeneficiario.Text = String.Empty
            txtbeneficiario.Text = String.Empty
            cmbbanco.Value = Nothing
            txtctabenef.Text = String.Empty
            txtdnibeneficiario.Focus()
        Else
            txtdnibeneficiario.ReadOnly = True
            txtbeneficiario.ReadOnly = True
            txtdnibeneficiario.Text = String.Empty
            txtbeneficiario.Text = txtcontratista.Text
            If rdbDeposito.Checked = True Then
                cmbbanco.Value = codbanco
                txtctabenef.Text = nrocta
            Else
                cmbbanco.Value = Nothing
                txtctabenef.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub rdbDeposito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDeposito.CheckedChanged
        If rdbDeposito.Checked = True Then
            cmbbanco.ReadOnly = False
            txtctabenef.ReadOnly = False
            If chkbeneficiario.Checked = True Then
                'CargarBeneficiariosDni(Me.txtdnibeneficiario.Text)
                Exit Sub
            End If
            cmbbanco.ReadOnly = False
            txtctabenef.ReadOnly = False
            If chkbeneficiario.Checked = False Then 'And cmbMoneda.Text.ToString.Trim.Substring(0, 1) = "S"
                cmbbanco.Value = codbanco
                txtctabenef.Text = nrocta
            End If
        Else
            cmbbanco.ReadOnly = False
            txtctabenef.ReadOnly = False
        End If
    End Sub

    Private Sub rdbCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCheque.CheckedChanged
        If rdbCheque.Checked = True Then
            cmbbanco.ReadOnly = True
            txtctabenef.ReadOnly = True
            cmbbanco.Value = Nothing
            txtctabenef.Text = String.Empty
        End If
    End Sub

    Private Sub cmbbanco_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbbanco.InitializeLayout
        With cmbbanco.DisplayLayout.Bands(0)
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
    Dim saldoigv As Double = 0
    Dim saldototal As Double = 0
    Dim idcontratistasaldo As Integer = 0
    Sub CargarSaldoImpuestos()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        If cmbMes.Value = 12 Then
            objEntidad._ayo = txtayo.Value + 1
            objEntidad._mes = 1
        Else
            objEntidad._ayo = txtayo.Value
            objEntidad._mes = cmbMes.Value + 1
        End If
        objEntidad._idcontratista = txtidcontratista.Text
        objEntidad.NumSolicitud = NumSolicitud
        dtDatos = objNegocio.ListarSaldoImpuestos(objEntidad)
        saldoigv = 0
        saldototal = 0
        If dtDatos.Rows.Count > 0 Then
            saldoigv = dtDatos.Rows(0)("CALCULOIGV")
            saldototal = dtDatos.Rows(0)("SALDO")
            idcontratistasaldo = dtDatos.Rows(0)("IDCONTRATISTA")
        End If
    End Sub

    Sub CargarSaldoImpuestosAnticipo()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        If cmbMes.Value = 12 Then
            objEntidad._ayo = txtayo.Value + 1
            objEntidad._mes = 1
        Else
            objEntidad._ayo = txtayo.Value
            objEntidad._mes = cmbMes.Value + 1
        End If
        objEntidad._idcontratista = txtidcontratista.Text
        objEntidad.NumSolicitud = NumSolicitud
        dtDatos = objNegocio.ListarSaldoImpuestosAnticipo(objEntidad)
        saldoigv = 0
        saldototal = 0
        If dtDatos.Rows.Count > 0 Then
            saldoigv = dtDatos.Rows(0)("CALCULOIGV")
            saldototal = dtDatos.Rows(0)("SALDO")
            idcontratistasaldo = dtDatos.Rows(0)("IDCONTRATISTA")
        End If
    End Sub

    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        If txtcodcontratista.Text.ToString.Trim = "" Then
            MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcontratista.Focus()
            Exit Sub
        End If
        If txtcodcantera.Text.ToString.Trim = "" Then
            MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcantera.Focus()
            Exit Sub
        End If
        If cmbMes.SelectedIndex < 0 Then
            MsgBox("Seleccione mes", MsgBoxStyle.Exclamation, msgComacsa)
            cmbMes.Focus()
            Exit Sub
        End If
        CargarSaldoImpuestos()
        CargarObligaciones()
    End Sub

    Private Sub cmbgrupo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgrupo.ValueChanged
        Try
            limpiarobligaciones()
            CargarSaldoImpuestos()
            CargarObligaciones()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            limpiarobligaciones()
            CargarSaldoImpuestos()
            CargarObligaciones()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridObligaciones_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridObligaciones.DoubleClickRow
        Try
            Dim concepto As String
            concepto = gridObligaciones.ActiveRow.Cells("CONCEPTO").Value.ToString.Trim
            detalleObligaciones(concepto)
        Catch ex As Exception

        End Try
    End Sub

    Sub seteoEntidadDetalle()
        Entidad.Contratista = New ETContratista
        Ls_EntregaDetalle = New List(Of ETContratista)
        Dim idconcepto As Int32 = 0
        idconcepto = 12
        Entidad.Contratista._idconcepto = idconcepto
        Entidad.Contratista._variacion = "A"
        Entidad.Contratista.montoTotal = IIf(txtsubtotal.Value Is Nothing, String.Empty, txtsubtotal.Value)
        Ls_EntregaDetalle.Add(Entidad.Contratista)
        If gridconceptos.Rows.Count > 0 Then
            For i As Int32 = 0 To gridconceptos.Rows.Count - 1
                'If gridconceptos.Rows(i).Cells("TOTAL").Value > 0 Then
                Entidad.Contratista = New ETContratista
                Entidad.Contratista._idconcepto = gridconceptos.Rows(i).Cells("ID").Value
                Entidad.Contratista._variacion = gridconceptos.Rows(i).Cells("FLAGVARIACION").Value
                Entidad.Contratista.montoTotal = CDbl(gridconceptos.Rows(i).Cells("TOTAL").Value)
                Ls_EntregaDetalle.Add(Entidad.Contratista)
                'End If
            Next
        End If
    End Sub
    Function validaPeriodoAnticipo() As Boolean
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._tipoanticipo = "OL"
        objEntidad._ayo = txtayo.Value
        objEntidad._mes = cmbMes.Value
        objEntidad._quincena = cmbgrupo.Value
        objEntidad._idcontratista = txtidcontratista.Text
        objEntidad._semanaini = 0
        objEntidad._semanafin = 0
        objEntidad.IDSUPERVISOR = txtidsupervisor.Text
        Dim dt As New DataTable
        dt = objNegocio.validaPeriodo(objEntidad)
        If dt.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Function validaDatos() As Boolean
        If txtcodcontratista.Text.ToString.Trim = "" Then
            MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcontratista.Focus()
            Return False
        End If
        If txtcodcantera.Text.ToString.Trim = "" Then
            MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcantera.Focus()
            Return False
        End If
        If cmbMes.SelectedIndex < 0 Then
            MsgBox("Seleccione mes", MsgBoxStyle.Exclamation, msgComacsa)
            cmbMes.Focus()
            Exit Function
        End If
        If txttotal.Text.ToString.Trim = "" Then txttotal.Text = 0
        'If txttotal.Text = 0 Then
        '    MsgBox("Ingrese monto del Anticipo", MsgBoxStyle.Exclamation, msgComacsa)
        '    Return False
        'End If
        Return True
    End Function
    Public Sub Grabar()
        Try
            If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
            If flgaprobada = 1 And esAprobador = 0 Then MsgBox("La solicitud se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa) : Return
            If Ope = 0 Then
                MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Ope = 1 Then
                If Not validaPeriodoAnticipo() Then
                    MsgBox("El contratista ya generó un anticipo para este periodo", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
            End If

            If Not validaDatos() Then
                Exit Sub
            End If

            'If estado = "PENDIENTE" Then
            '    If Not ValidaExcesocredito(Me.TxtCodigoTrabajador.Text.ToString.Trim) Then
            '        Return
            '    End If
            'End If


            If rdbCheque.Checked = False And rdbDeposito.Checked = False Then
                MsgBox("Seleccione tipo de depósito", MsgBoxStyle.Exclamation, msgComacsa) : Return
            End If
            If chkbeneficiario.Checked = True Then If txtdnibeneficiario.Text.Trim = "" Or txtbeneficiario.Text.Trim = "" Then MsgBox("Debe ingresar datos del beneficiario", MsgBoxStyle.Exclamation, msgComacsa) : Return

            If rdbDeposito.Checked = True And chkbeneficiario.Checked = True Then
                If String.IsNullOrEmpty(cmbbanco.Value) Then
                    MsgBox("Ingresar banco a depositar", MsgBoxStyle.Exclamation, msgComacsa) : Return
                End If
                If String.IsNullOrEmpty(txtctabenef.Value) Then
                    MsgBox("Ingresar cuenta a depositar", MsgBoxStyle.Exclamation, msgComacsa) : Return
                End If
            End If
            If cant_supervisor > 1 Then
                If txtidsupervisor.Text = 0 Or txtsupervisor.Text = "" Then
                    MsgBox("Debe seleccionar un supervisor", MsgBoxStyle.Exclamation, msgComacsa) : Return
                End If
            End If
            'Dim fechaSalida As Date = dtFechaSalida.Value
            'Dim fechaRetorno As Date = dtFechaRetorno.Value
            Dim fechaActual As Date = Now.Date

            'If fechaSalida.CompareTo(fechaActual) < 0 And Ope = 1 Then
            '    MsgBox("Fecha de salida debe ser mayor a fecha actual", MsgBoxStyle.Exclamation, msgComacsa)
            '    Return
            'End If
            'If fechaRetorno.CompareTo(fechaSalida) < 0 Then
            '    MsgBox("Fecha de retorno debe ser mayor a fecha de salida", MsgBoxStyle.Exclamation, msgComacsa)
            '    Return
            'End If
            calcularTotal()
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            seteoEntidadDetalle()
            'seteoEntidadDetalle()
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista

            If dtCanteras.Rows.Count > 0 Then
                Dim totalcantera As Double = 0
                Dim totalanticipo As Double = Math.Round(CDbl(txttotal.Text), 2)
                For i As Int32 = 0 To dtCanteras.Rows.Count - 1
                    If dtCanteras.Rows(i)("Action").ToString = "True" Then
                        Entidad.Contratista = New ETContratista
                        totalcantera = totalcantera + Math.Round(CDbl(dtCanteras.Rows(i)("MONTO")), 2)
                        Ls_Anticipo.Add(Entidad.Contratista)
                    End If
                Next
                If totalcantera <> totalanticipo And totalcantera > 0 Then
                    MsgBox("El monto dividido en las canteras debe ser igual al total del anticipo", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
            End If

            'MsgBox(idfrecuenia.ToString)
            'Exit Sub

            x_mes = 0
            x_quincena = 0
            x_semanaini = 0
            x_semanafin = 0


            x_mes = cmbMes.Value
            x_quincena = cmbgrupo.Value
            Entidad.Contratista.TipoOperacion = Ope
            Entidad.Contratista.NumSolicitud = NumSolicitud
            Entidad.Contratista._tipoanticipo = "OL"
            Entidad.Contratista._ayo = txtayo.Value
            Entidad.Contratista._mes = x_mes
            Entidad.Contratista._quincena = x_quincena
            Entidad.Contratista._semanaini = x_semanaini
            Entidad.Contratista._semanafin = x_semanafin
            If txtidcontratista.Text.ToString.Trim = "" Then txtidcontratista.Text = 0
            Entidad.Contratista._idcontratista = txtidcontratista.Text
            Entidad.Contratista._fecha1 = Now.Date
            Entidad.Contratista.montoTotal = IIf(txttotal.Value Is Nothing, String.Empty, txttotal.Value)
            If chkAprobar.Checked Then
                Entidad.Contratista.idEstado = 2
            Else
                Entidad.Contratista.idEstado = 1
            End If

            If rdbDeposito.Checked = True Then
                Entidad.Contratista.tipodepobeneficiario = "1"
            ElseIf rdbCheque.Checked = True Then
                Entidad.Contratista.tipodepobeneficiario = "2"
                'ElseIf rdbEfectivo.Checked = True Then
                '    Entidad.Entregas.tipodepobeneficiario = "3"
            End If

            If chkbeneficiario.Checked = True Then
                Entidad.Contratista.flgbeneficiario = "1"
            Else
                Entidad.Contratista.flgbeneficiario = "0"
            End If
            Entidad.Contratista.moneda = IIf(cmbMoneda.Value Is Nothing, String.Empty, cmbMoneda.Text.ToString.Trim.Substring(0, 1))
            Entidad.Contratista.dnibeneficiario = IIf(txtdnibeneficiario.Value Is Nothing, String.Empty, txtdnibeneficiario.Value)
            Entidad.Contratista.beneficiario = IIf(txtbeneficiario.Value Is Nothing, String.Empty, txtbeneficiario.Value)
            Entidad.Contratista.bancobeneficiario = IIf(cmbbanco.Value Is Nothing, String.Empty, cmbbanco.Value)
            Entidad.Contratista.ctabeneficiario = IIf(txtctabenef.Value Is Nothing, String.Empty, txtctabenef.Value)

            Entidad.Contratista._usuario = User_Sistema
            'Dim x_descripcion As String = ""
            'x_descripcion = String.Empty

            If cmbgrupo.Value = 1 Then
                x_descripcion = "POR OBLIGACION LABORAL (ONP - ESSALUD)"
            ElseIf cmbgrupo.Value = 2 Then
                x_descripcion = "POR OBLIGACION LABORAL (AFP - SCTR)"
            End If


            Entidad.Contratista._descripcion = x_descripcion 'txtdescripcion.Text.ToString
            Entidad.Contratista.IDSUPERVISOR = txtidsupervisor.Text
            'Dim ls_Solicitud = Ls_Anticipo.Where(Function(x) x.codConcepto.ToString.Trim <> "").FirstOrDefault
            Ls_Anticipo = New List(Of ETContratista)
            Entidad.Contratista = Negocio.NContratista.MantenimientoAnticipo(Entidad.Contratista, Ls_Anticipo, Ls_EntregaDetalle)
            Dim num_solicitud As String = Entidad.Contratista.NumSolicitud
            If Entidad.Contratista.Validacion Then

                If dtCanteras.Rows.Count > 0 Then
                    'MsgBox(IIf(dtCanteras.Rows(0)("Action").ToString = "True", 1, 0))
                    For i As Int32 = 0 To dtCanteras.Rows.Count - 1
                        If dtCanteras.Rows(i)("Action").ToString = "True" Then
                            Entidad.Contratista = New ETContratista
                            Entidad.Contratista.NumSolicitud = num_solicitud
                            Entidad.Contratista._codcantera = dtCanteras.Rows(i)("CODCANTERA")
                            Entidad.Contratista._descripcion = dtCanteras.Rows(i)("DESCRIPCION")
                            Entidad.Contratista.montoTotal = dtCanteras.Rows(i)("MONTO")
                            Entidad.Contratista.IDSUPERVISOR = dtCanteras.Rows(i)("ID_SUPERVISOR")
                            Ls_Anticipo.Add(Entidad.Contratista)
                        End If
                    Next
                    Entidad.Contratista = Negocio.NContratista.InsertaCanteraAnticipo(Ls_Anticipo)
                End If

                Ls_Anticipo = New List(Of ETContratista)

                If gridObligaciones.Rows.Count > 0 Then
                    For i As Int32 = 0 To gridObligaciones.Rows.Count - 1
                        Entidad.Contratista = New ETContratista
                        Entidad.Contratista.NumSolicitud = num_solicitud
                        Entidad.Contratista.ID = gridObligaciones.Rows(i).Cells("ID").Value
                        Entidad.Contratista.montoTotal = gridObligaciones.Rows(i).Cells("TOTAL").Value
                        Entidad.Contratista.dscto = gridObligaciones.Rows(i).Cells("DSCTO").Value
                        'Entidad.Contratista._pago = dtPlanilla.Rows(i)("TOTALPAGO")
                        'Entidad.Contratista._onp = dtPlanilla.Rows(i)("ONP")
                        'Entidad.Contratista._afp = dtPlanilla.Rows(i)("AFP")
                        'Entidad.Contratista._essalud = dtPlanilla.Rows(i)("ESSALUD")
                        'Entidad.Contratista._quinta = dtPlanilla.Rows(i)("QUINTA")
                        'Entidad.Contratista._sctr = dtPlanilla.Rows(i)("SCTR")
                        'Entidad.Contratista._afpcomp = dtPlanilla.Rows(i)("AFPCOMP")
                        'Entidad.Contratista._fminero = dtPlanilla.Rows(i)("FMINERO")
                        Ls_Anticipo.Add(Entidad.Contratista)
                    Next
                    Entidad.Contratista = Negocio.NContratista.InsertaObligacionAnticipo(Ls_Anticipo)
                End If
                If saldoutilizado > 0 Then
                    Ls_Anticipo = New List(Of ETContratista)
                    Entidad.Contratista = New ETContratista
                    Entidad.Contratista.NumSolicitud = num_solicitud
                    Entidad.Contratista._idcontratista = idcontratistasaldo
                    Entidad.Contratista._ayo = txtayo.Value
                    Entidad.Contratista._mes = cmbMes.Value
                    Entidad.Contratista.montoTotal = saldoutilizado
                    Ls_Anticipo.Add(Entidad.Contratista)
                    Entidad.Contratista = Negocio.NContratista.InsertaSaldoUtilizado(Ls_Anticipo)
                End If
                'MsgBox(Ls_Anticipo.Count)
                Call Nuevo()
                CargarDatos()
                TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Private Sub CargarDatos()
        Entidad.Contratista = New ETContratista
        Entidad.Contratista.TipoOperacion = Ope
        Entidad.Contratista._tipoanticipo = "OL"
        Negocio.NContratista = New NGContratista
        Entidad.MyLista = New ETMyLista
        Ls_Anticipo = Nothing
        Ls_Anticipo = New List(Of ETContratista)
        Ls_EntregaDetalle = Nothing
        Ls_EntregaDetalle = New List(Of ETContratista)
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.Contratista._fecha1 = dtpDesde.Value
        Entidad.Contratista._fecha2 = dtpHasta.Value
        Entidad.MyLista = Negocio.NContratista.ListarAnticipos(Entidad.Contratista)
        If Entidad.MyLista.Validacion Then
            Ls_Anticipo = Entidad.MyLista.Ls_Anticipo
        End If
        Call CargarUltraGridxBinding(Me.GridAnticipo, Source3, Ls_Anticipo)
    End Sub

    Private Sub GridAnticipo_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridAnticipo.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot GridAnticipo Then Return

        If e.Row.IsFilterRow Then Return

        SubProceso_Anticipo(e.Row)
    End Sub

    Sub SubProceso_Anticipo(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Dim usuarioSolicitud As String = String.Empty
        estado = uRow.Cells("estado").Value
        usuarioSolicitud = uRow.Cells("usuario").Value
        Ope = 2
        'If estado = "APROBADO" Then flgaprobada = 1 Else flgaprobada = 0 'MsgBox("La solicitud se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa) : Return
        lblestado.Text = estado.ToString.ToUpper.Trim
        If Not estado = "PENDIENTE" Then
            flgaprobada = 1 : btnCalcular.Enabled = False : gridconceptos.Enabled = False
            rdbDeposito.Enabled = False
            rdbCheque.Enabled = False
            chkbeneficiario.Enabled = False
        Else
            flgaprobada = 0
            btnCalcular.Enabled = True : gridconceptos.Enabled = True
            rdbDeposito.Enabled = True
            rdbCheque.Enabled = True
            chkbeneficiario.Enabled = True
        End If

        Entidad.Contratista = New ETContratista
        Negocio.NContratista = New NGContratista
        Entidad.MyLista = New ETMyLista
        Entidad.Contratista.Usuario = User_Sistema
        Entidad.MyLista = Negocio.NContratista.UsuarioAprobacion(Entidad.Contratista)
        If Entidad.MyLista.Validacion Then
            Ls_Anticipo = Entidad.MyLista.Ls_Anticipo
        End If
        If Not estado = "DESEMBOLSADO" Then
            If Ls_Anticipo.Count <= 0 Then
                'gridconceptos.Enabled = True
                chkAprobar.Visible = False
                esAprobador = 0
                puedeeliminar = 1
            ElseIf Ls_Anticipo.Count > 0 Then
                'TabMaestroEntregas.Tabs("Registro").Enabled = False
                'gridconceptos.Enabled = False
                chkAprobar.Visible = True
                esAprobador = 1
                puedeeliminar = 0
            End If
        Else
            chkAprobar.Visible = False
            esAprobador = 0
            puedeeliminar = 1
        End If

        If usuarioSolicitud <> User_Sistema Then esCreador = 0 Else esCreador = 1 ': gridconceptos.Enabled = True

        'TxtCodigoTrabajador.ReadOnly = True

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.MyLista = New ETMyLista
        Entidad.Contratista.NumSolicitud = uRow.Cells("NumSolicitud").Value
        NumSolicitud = uRow.Cells("NumSolicitud").Value
        nroSolicitud = uRow.Cells("NumSolicitud").Value

        Entidad.MyLista = Negocio.NContratista.SolicitudAnticipoxNumero(Entidad.Contratista)

        If Entidad.MyLista.Validacion Then
            Ls_Anticipo = Entidad.MyLista.Ls_Anticipo
        End If

        If Entidad.MyLista.Validacion Then Cargar_DatosSolicitud() : CargarConceptos(NumSolicitud)

        '*****************CORREGIR ESTA PARTE*****************
        'If estado = "PENDIENTE" Then
        CargarSaldoImpuestosAnticipo()
        'CargarSaldoImpuestos()
        'End If

        CargarObligacionAnticipo(NumSolicitud)
        CargarCanteraAnticipo(NumSolicitud)

        'btnCanteras.Visible = True
        'CargarObligaciones()

        'Txt4.Value = NumSolicitud
        'esCreador = uRow.Cells("flgpermiso").Value
        If estado = "CERRADO" Then
            flgaprobada = 0
            chkAprobar.Visible = False
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        For I As Int32 = 0 To gridObligaciones.Rows.Count - 1
            If gridObligaciones.Rows(I).Cells("FLGOBLIGATORIO").Value.ToString = 0 Then
                gridObligaciones.Rows(I).Cells("TOTAL").Activation = Activation.AllowEdit
            Else
                gridObligaciones.Rows(I).Cells("TOTAL").Activation = Activation.ActivateOnly
            End If
        Next
        'btnCalcular.Enabled = True
    End Sub

    Sub CargarObligacionAnticipo(ByVal numsolicitud As String)
        Dim dtDatos As DataTable
        dtDatos = New DataTable
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad.NumSolicitud = numsolicitud
        dtDatos = objNegocio.CargarObligacionAnticipo(objEntidad)
        Call CargarUltraGridxBinding(gridObligaciones, Source2, dtDatos)
        'If gridImpuestos.Rows.Count > 0 Then
        calcularTotal()
    End Sub

    Sub VisualizarDatosDeposito(ByVal D As Boolean)
        txttipodep.Visible = D
        txtbanco.Visible = D
        txtcuenta.Visible = D
        txtnrodoc.Visible = D
        lbltipo.Visible = D
        lblbanco.Visible = D
        lblcuenta.Visible = D
        lblnumero.Visible = D
        Dim y As Double
        Dim y1 As Double
        y = gbPlanilla.Location.Y + gbPlanilla.Height - 10
        y = y + 15
        y1 = y + 20
        txttipodep.Location = New Point(24, y1)
        lbltipo.Location = New Point(24, y)
        txtbanco.Location = New Point(149, y1)
        lblbanco.Location = New Point(149, y)
        txtcuenta.Location = New Point(272, y1)
        lblcuenta.Location = New Point(272, y)
        txtnrodoc.Location = New Point(416, y1)
        lblnumero.Location = New Point(416, y)
    End Sub
    Sub Cargar_DatosSolicitud()
        Try
            Ope = 2
            TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
            Call limpiar()
            'Call HabilitarControles(True)
            cmbMes.ReadOnly = True
            cmbgrupo.ReadOnly = True
            lblestado.Visible = True
            UltraLabel39.Visible = True
            Dim y As Double
            y = UltraLabel7.Location.Y
            'UltraLabel39.Location = New Point(782, y)
            'lblestado.Location = New Point(914, y)
            If lblestado.Text.ToString.Trim = "DESEMBOLSADO" Then
                VisualizarDatosDeposito(True)
            End If
            If Ls_Anticipo.Count > 0 Then
                txtayo.Value = Ls_Anticipo.Item(0)._ayo
                cmbMes.Value = Ls_Anticipo.Item(0)._mes
                cmbgrupo.Value = Ls_Anticipo.Item(0)._quincena
                txtcodcontratista.Value = Ls_Anticipo.Item(0)._codprov.ToString.Trim
                txtcontratista.Value = Ls_Anticipo.Item(0)._contratista.ToString.Trim
                txtidcontratista.Value = Ls_Anticipo.Item(0)._idcontratista.ToString
                txtcodcantera.Value = Ls_Anticipo.Item(0)._codcantera.ToString.Trim
                txtcantera.Value = Ls_Anticipo.Item(0)._cantera.ToString.Trim
                txtidsupervisor.Value = Ls_Anticipo.Item(0).IDSUPERVISOR.ToString
                txtsupervisor.Value = Ls_Anticipo.Item(0).supervisor.ToString
                txttotal.Value = Ls_Anticipo.Item(0).montoTotal.ToString("#####0.00")
                ctatrabajador = Ls_Anticipo.Item(0).ctatrabajador.ToString.Trim
                bcotrabajador = Ls_Anticipo.Item(0).bcotrabajador.ToString.Trim
                montosolicitud = Ls_Anticipo.Item(0).montoTotal.ToString("#####0.00")
                Dim descripTipoDeposito As String = String.Empty
                Select Case (Ls_Anticipo.Item(0).tipodeposito.ToString.Trim)
                    Case Is = "CH"
                        descripTipoDeposito = "CHEQUE"
                    Case Is = "DR"
                        descripTipoDeposito = "NOTA DE CARGO"
                    Case Is = "VL"
                        descripTipoDeposito = "VALE"
                    Case Is = "SF"
                        descripTipoDeposito = "SUSTENTO FIJO"
                End Select
                txttipodep.Value = descripTipoDeposito ' Ls_Entrega.Item(0).tipodeposito.ToString
                txtbanco.Value = Ls_Anticipo.Item(0)._banco.ToString
                txtcuenta.Value = Ls_Anticipo.Item(0)._nrocta.ToString
                txtnrodoc.Value = Ls_Anticipo.Item(0).nrodoc.ToString
                Dim idEstado As Int32
                idEstado = Ls_Anticipo.Item(0).idEstado
                If idEstado = 1 Then
                    chkAprobar.Checked = Boolean.FalseString
                ElseIf idEstado = 2 Then
                    chkAprobar.Checked = Boolean.TrueString
                End If
                Entidad.Entregas.NumSolicitud = NumSolicitud
                lblnSolicitud.Text = "N° Solicitud : " & NumSolicitud
                lblnSolicitud.Visible = Boolean.TrueString
                If Ls_Anticipo.Item(0).flgbeneficiario.ToString.Trim = "1" Then
                    chkbeneficiario.Checked = True
                    txtdnibeneficiario.Text = Ls_Anticipo.Item(0).dnibeneficiario.ToString.Trim
                    txtbeneficiario.Text = Ls_Anticipo.Item(0).beneficiario.ToString.Trim
                Else
                    chkbeneficiario.Checked = False
                    txtdnibeneficiario.Text = ""
                    txtbeneficiario.Text = txtcontratista.Text.ToString.Trim
                End If
                codbanco = Ls_Anticipo.Item(0).bancobeneficiario.ToString.Trim
                nrocta = Ls_Anticipo.Item(0).ctabeneficiario.ToString.Trim
                Select Case (Ls_Anticipo.Item(0).tipodepobeneficiario.ToString.Trim)
                    Case Is = "1"
                        rdbDeposito.Checked = True
                        cmbbanco.Value = Ls_Anticipo.Item(0).bancobeneficiario.ToString.Trim
                        txtctabenef.Value = Ls_Anticipo.Item(0).ctabeneficiario.ToString.Trim
                        ctatrabajadorini = Ls_Anticipo.Item(0).ctabeneficiario.ToString.Trim
                        bcotrabajadorini = Ls_Anticipo.Item(0).bancobeneficiario.ToString.Trim
                    Case Is = "2"
                        rdbCheque.Checked = True
                        'Case Is = "3"
                        '    rdbEfectivo.Checked = True
                End Select
                Try
                    Dim codigoConcepto As String = ""
                    'TxtCodigoTrabajador.ReadOnly = True
                    cmbMoneda.Enabled = False
                    'chkbeneficiario.Enabled = False
                    'rdbDeposito.Enabled = False
                    'rdbCheque.Enabled = False
                    Select Case (Ls_Anticipo.Item(0).moneda.ToString.Trim)
                        Case Is = "S"
                            cmbMoneda.Value = "01"
                        Case Is = "D"
                            cmbMoneda.Value = "02"
                        Case Is = "E"
                            cmbMoneda.Value = "03"
                    End Select
                   
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridAnticipo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "NumSolicitud" OrElse uColumn.Key = "_descripcion" OrElse uColumn.Key = "FechaIngreso" OrElse _
                    uColumn.Key = "_contratista" OrElse uColumn.Key = "Estado" OrElse uColumn.Key = "_cantera" OrElse uColumn.Key = "montoTotal") Then ' OrElse uColumn.Key = "moneda"
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Sub Eliminar()
        Try
            If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
            If nroSolicitud.ToString.Trim = "" Then Return
            If esCreador = 0 Then MsgBox("No tiene permisos para eliminar la solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
            If flgaprobada = 1 Then MsgBox("No puede eliminar la solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
            'If flgaprobada = 1 And esAprobador = 0 Then MsgBox("La solicitud se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa) : Return
            If Ope = 0 Then
                MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            Dim fechaActual As Date = Now.Date
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            seteoEntidadDetalle()
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            x_mes = 0
            x_quincena = 0
            x_semanaini = 0
            x_semanafin = 0

            x_mes = x_mes
            x_quincena = x_quincena

            Ope = 3
            Entidad.Contratista.TipoOperacion = Ope
            Entidad.Contratista.NumSolicitud = NumSolicitud
            Entidad.Contratista._tipoanticipo = "OL"
            Entidad.Contratista._ayo = txtayo.Value
            Entidad.Contratista._mes = x_mes
            Entidad.Contratista._quincena = x_quincena
            Entidad.Contratista._semanaini = x_semanaini
            Entidad.Contratista._semanafin = x_semanafin
            If txtidcontratista.Text.ToString.Trim = "" Then txtidcontratista.Text = 0
            Entidad.Contratista._idcontratista = txtidcontratista.Text
            Entidad.Contratista._fecha1 = Now.Date
            Entidad.Contratista.montoTotal = IIf(txttotal.Value Is Nothing, String.Empty, txttotal.Value)
            If chkAprobar.Checked Then
                Entidad.Contratista.idEstado = 2
            Else
                Entidad.Contratista.idEstado = 1
            End If

            If rdbDeposito.Checked = True Then
                Entidad.Contratista.tipodepobeneficiario = "1"
            ElseIf rdbCheque.Checked = True Then
                Entidad.Contratista.tipodepobeneficiario = "2"
                'ElseIf rdbEfectivo.Checked = True Then
                '    Entidad.Entregas.tipodepobeneficiario = "3"
            End If

            If chkbeneficiario.Checked = True Then
                Entidad.Contratista.flgbeneficiario = "1"
            Else
                Entidad.Contratista.flgbeneficiario = "0"
            End If
            Entidad.Contratista.moneda = IIf(cmbMoneda.Value Is Nothing, String.Empty, cmbMoneda.Text.ToString.Trim.Substring(0, 1))
            Entidad.Contratista.dnibeneficiario = IIf(txtdnibeneficiario.Value Is Nothing, String.Empty, txtdnibeneficiario.Value)
            Entidad.Contratista.beneficiario = IIf(txtbeneficiario.Value Is Nothing, String.Empty, txtbeneficiario.Value)
            Entidad.Contratista.bancobeneficiario = IIf(cmbbanco.Value Is Nothing, String.Empty, cmbbanco.Value)
            Entidad.Contratista.ctabeneficiario = IIf(txtctabenef.Value Is Nothing, String.Empty, txtctabenef.Value)

            Entidad.Contratista._usuario = User_Sistema
            x_descripcion = "ANTICIPO ELIMINADO"
            Entidad.Contratista._descripcion = x_descripcion 'txtdescripcion.Text.ToString
            Entidad.Contratista.IDSUPERVISOR = txtidsupervisor.Text
            'Dim ls_Solicitud = Ls_Anticipo.Where(Function(x) x.codConcepto.ToString.Trim <> "").FirstOrDefault
            Ls_Anticipo = New List(Of ETContratista)
            Entidad.Contratista = Negocio.NContratista.EliminarAnticipo(Entidad.Contratista, Ls_Anticipo, Ls_EntregaDetalle)
            Dim num_solicitud As String = Entidad.Contratista.NumSolicitud
            If Entidad.Contratista.Validacion Then
                Call Nuevo()
                CargarDatos()
                TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
            End If
            'MsgBox(Ls_Anticipo.Count)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Public Sub Reporte()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If Not flgaprobada = 1 Then MsgBox("La solicitud no se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If nroSolicitud.ToString.Trim = "" Then Return
        lblmensaje.Visible = True
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Refresh()
        lblmensaje.Update()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        StrucForm.FxRxAnticipo = New FrmAnticipo
        'StrucForm.FxRxSolicitud.TextReporte = "Cuadro Enlace (Producto - Unidad)"
        StrucForm.FxRxAnticipo.MdiParent = MdiParent
        StrucForm.FxRxAnticipo.Show()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        lblmensaje.Visible = False
        lblmensaje.Refresh()
        lblmensaje.Update()
    End Sub

    Private Sub GridAnticipo_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridAnticipo.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "NumSolicitud" OrElse uColumn.Key = "_descripcion" OrElse uColumn.Key = "FechaIngreso" OrElse _
                    uColumn.Key = "_contratista" OrElse uColumn.Key = "Estado" OrElse uColumn.Key = "_cantera" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "periodo") Then ' OrElse uColumn.Key = "moneda"
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub txtdnibeneficiario_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdnibeneficiario.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return

        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return

        If txtdnibeneficiario.Text.ToString.Trim = "" Then
            txtdnibeneficiario.Focus()
            Exit Sub
        End If
        CargarBeneficiariosDni(Me.txtdnibeneficiario.Text)

        txtbeneficiario.Focus()
    End Sub

    Private Sub txtdnibeneficiario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdnibeneficiario.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub
    Private Sub CargarBeneficiariosDni(ByVal dnibeneficiario As String)
        If chkbeneficiario.Checked = True Then
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            'Ls_Entrega = Nothing
            'Ls_Entrega = New List(Of ETEntregas)
            Dim Rpt As New ETContratista
            Rpt.dnibeneficiario = dnibeneficiario.ToString.Trim
            Rpt.moneda = cmbMoneda.Text.ToString.Trim.Substring(0, 1)
            Entidad.MyLista = Negocio.NContratista.ListarBeneficiarioDni(Rpt)
            lResult = New ETMyLista
            lResult = Entidad.MyLista

            If Not Entidad.MyLista.Validacion Then Return
            'Ls_Entrega = Entidad.MyLista.Ls_Entrega
            'End If

            If Entidad.MyLista.Ls_Entrega.Count > 0 Then
                txtbeneficiario.Text = Entidad.MyLista.Ls_Entrega.Item(0).beneficiario.ToString.Trim
                cmbbanco.Value = Entidad.MyLista.Ls_Entrega.Item(0).bancobeneficiario.ToString.Trim
                txtctabenef.Text = Entidad.MyLista.Ls_Entrega.Item(0).ctabeneficiario.ToString.Trim
            Else
                'cmbbanco.Value = Nothing
                'txtbeneficiario.Text = String.Empty
                'txtctabenef.Text = String.Empty
                'txtbeneficiario.Focus()
            End If
        End If
    End Sub
    Dim dtCanteras As New DataTable
    Private Sub btnCanteras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCanteras.Click
        Try
            If txttotal.Text.Trim = "" Then txttotal.Text = 0
            If txttotal.Text <= 0 Then
                MsgBox("El total debe ser mayor a 0", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If

            Dim frm As New frmSeparaCanteras
            If flgaprobada = 1 Then
                frm.gridcontratista.Enabled = False
            Else
                frm.gridcontratista.Enabled = True
            End If
            frm.dtCanteras = dtCanteras
            frm.montoAnticipo = txttotal.Text
            frm.codprov = txtcodcontratista.Text
            frm.ShowDialog()
            dtCanteras = frm.dtCanteras
        Catch ex As Exception

        End Try
    End Sub
    Sub CargarCanteraAnticipo(ByVal numsolicitud As String)
        Dim dtDatos As DataTable
        dtDatos = New DataTable
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad.NumSolicitud = numsolicitud
        dtCanteras = objNegocio.CargarCanteraAnticipo(objEntidad)
        'Call CargarUltraGridxBinding(gridImpuestos, Source2, dtDatos)
    End Sub

    Private Sub gridObligaciones_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridObligaciones.InitializeLayout

    End Sub

    Private Sub gridObligaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridObligaciones.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridObligaciones) Then Return
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
                        If gridObligaciones.ActiveRow.Cells(gridObligaciones.ActiveCell.Column.Index).Column.Key = "TOTAL" Then
                            calcularTotal()
                        End If
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                End Select

            End With
        Catch ex As Exception
        End Try
    End Sub
End Class