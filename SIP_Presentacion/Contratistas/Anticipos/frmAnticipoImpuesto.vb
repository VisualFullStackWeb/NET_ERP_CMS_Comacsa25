Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class frmAnticipoImpuesto
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
    Dim renta As Int32 = 0
    Private Ls_Anticipo As List(Of ETContratista) = Nothing
    Private Ls_EntregaDetalle As List(Of ETContratista) = Nothing
    Dim x_mes As Int32 = 0
    Dim x_quincena As Int32 = 0
    Dim x_semanaini As Int32 = 0
    Dim x_semanafin As Int32 = 0
    Dim x_descripcion = ""
    Sub Buscar()
        If Me.TabMaestroEntregas.Tabs("Lista").Selected = True Then Exit Sub
        If Ope = 2 Then Exit Sub
        If txtcodcontratista.Focused = True Then
            limpiar()
            Dim frm As New frmBuscarContratista
            frm.ShowDialog()
            txtcodcontratista.Text = frm.gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            txtcontratista.Text = frm.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            txtbeneficiario.Text = frm.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            Dim idtipopago As String = frm.gridcontratista.ActiveRow.Cells("TIPOPAGO").Value
            Dim idfrecuenia As Int32 = frm.gridcontratista.ActiveRow.Cells("IDFRECPAGO").Value
            'txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            codbanco = frm.gridcontratista.ActiveRow.Cells("CODBANCO").Value.ToString.Trim
            nrocta = frm.gridcontratista.ActiveRow.Cells("NROCTA").Value.ToString.Trim
            renta = frm.gridcontratista.ActiveRow.Cells("RENTA").Value
            rdbDeposito_CheckedChanged(Nothing, Nothing)
            btncalcular_Click(Nothing, Nothing)
            Dim frm1 As New frmBuscarCantera
            frm1.codprov = txtcodcontratista.Text
            frm1.CargarDatos()
            txtidcontratista.Text = frm1.gridcontratista.Rows(0).Cells("IDCONTRATISTA").Value
        End If
        If txtcodcantera.Focused = True Then
            If txtcodcontratista.Text.Trim = "" Then
                MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            limpiar()
            Dim frm As New frmBuscarCantera
            frm.codprov = txtcodcontratista.Text
            frm.ShowDialog()
            txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            txtcodcantera.Text = frm.gridcontratista.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcantera.Text = frm.gridcontratista.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
        End If

    End Sub
    Sub limpiar()
        txtcodcantera.Clear()
        txtcantera.Clear()
        txtsubtotal.Clear()
        txttotalotros.Clear()
        txttotal.Clear()
        txtidcontratista.Text = 0
        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            gridconceptos.Rows(i).Cells("TOTAL").Value = "0.00"
        Next
        CargarImpuestos()
        btnCanteras.Visible = False
        VisualizarDatosDeposito(False)
        dtCanteras = New DataTable
        chkbeneficiario.Checked = False
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
        rdbDeposito.Enabled = True
        rdbCheque.Enabled = True
        chkbeneficiario.Enabled = True
        txtcodcontratista.Clear()
        txtcontratista.Clear()
        Ope = 1
        estado = "PENDIENTE"
        nroSolicitud = String.Empty
        lblnSolicitud.Visible = Boolean.FalseString
        flgaprobada = 0
        lblestado.Visible = False
        limpiar()
        CalculoTotales()
        txtcodcontratista.Focus()
        Ls_Anticipo = New List(Of ETContratista)
        Ls_EntregaDetalle = New List(Of ETContratista)
        chkAprobar.Visible = False
        chkAprobar.Checked = False
        cmbMes.ReadOnly = False
        btncalcular.Enabled = True : Button1.Enabled = True : Button7.Enabled = True
    End Sub

    Private Sub frmAnticipoImpuesto_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Procesar()
    End Sub

    Private Sub frmAnticipoImpuesto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDesde.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
        dtpHasta.Value = Now.Date
        Procesar()
        txtayo.Value = Now.Date.Year
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
    Private Sub CargarDatos()
        Entidad.Contratista = New ETContratista
        Entidad.Contratista.TipoOperacion = Ope
        Entidad.Contratista._tipoanticipo = "I"
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
        objEntidad._tipoanticipo = "I"
        objEntidad.NumSolicitud = numSolicitud
        dtDatos = objNegocio.Listarconceptos(objEntidad)
        Call CargarUltraGridxBinding(gridconceptos, Source1, dtDatos)
    End Sub
    Sub CargarImpuestos()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        objEntidad._ayo = txtayo.Value
        objEntidad._mes = cmbMes.Value
        objEntidad._codprov = txtcodcontratista.Text
        dtDatos = objNegocio.ListarImpuestos(objEntidad)
        Call CargarUltraGridxBinding(gridImpuestos, Source2, dtDatos)
        'If gridImpuestos.Rows.Count > 0 Then
        CalculoTotales()
        'End If
    End Sub
    Dim saldoigv As Double = 0
    Dim saldototal As Double = 0
    Sub CargarSaldoImpuestos()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        objEntidad._ayo = txtayo.Value
        objEntidad._mes = cmbMes.Value
        objEntidad._idcontratista = txtidcontratista.Text
        dtDatos = objNegocio.ListarSaldoImpuestos(objEntidad)
        saldoigv = 0
        saldototal = 0
        If dtDatos.Rows.Count > 0 Then
            saldoigv = dtDatos.Rows(0)("CALCULOIGV")
            saldototal = dtDatos.Rows(0)("SALDO")
        End If
    End Sub
    Sub CalculoTotales()
        'MsgBox(saldoigv)
        'MsgBox(saldototal)
        Dim dtTotales As New DataTable
        dtTotales.Columns.Add("OPERACION")
        dtTotales.Columns.Add("TOTAL")
        Dim totcompra As Double = 0
        Dim totventa As Double = 0
        Dim totdetraccion As Double = 0
        Dim totrenta As Double = 0
        If gridImpuestos.Rows.Count <= 0 Then Call CargarUltraGridxBinding(gridTotales, Source4, dtTotales) : Exit Sub
        For i As Int32 = 0 To gridImpuestos.Rows.Count - 1
            Select Case gridImpuestos.Rows(i).Cells("TIPO").Value
                Case Is = "VENTA"
                    totventa = totventa + gridImpuestos.Rows(i).Cells("IGV").Value
                    totrenta = totrenta + (gridImpuestos.Rows(i).Cells("VALORVTA").Value * 0.015)
                Case Is = "COMPRA"
                    totcompra = totcompra + gridImpuestos.Rows(i).Cells("IGV").Value
                    'Case Is = "RENTA"
                    '    totventa = totventa + gridImpuestos.Rows(i).Cells("VALORVTA").Value
                Case Is = "DETRACCION"
                    totdetraccion = totdetraccion + gridImpuestos.Rows(i).Cells("IGV").Value
            End Select

        Next
        Dim dr As DataRow
        dr = dtTotales.NewRow
        dr(0) = "IGV VENTA"
        dr(1) = CDbl(totventa).ToString("##0.00")
        dtTotales.Rows.Add(dr)
        dr = dtTotales.NewRow
        dr(0) = "IGV COMPRA"
        dr(1) = CDbl(totcompra * -1).ToString("##0.00")
        dtTotales.Rows.Add(dr)

        If saldoigv < 0 Then
            dr = dtTotales.NewRow
            dr(0) = "SALDO IGV MES ANTERIOR"
            dr(1) = CDbl(saldoigv).ToString("##0.00") ' * -1
            dtTotales.Rows.Add(dr)
        End If
        renta = gridImpuestos.Rows(0).Cells("RENTA").Value
        If renta = 1 Then
            dr = dtTotales.NewRow
            dr(0) = "RENTA"
            dr(1) = CDbl(totrenta).ToString("##0.00")
            dtTotales.Rows.Add(dr)
        End If

        dr = dtTotales.NewRow
        dr(0) = "DETRACCION"
        dr(1) = CDbl(totdetraccion * -1).ToString("##0.00")
        dtTotales.Rows.Add(dr)

        If saldototal < 0 Then
            dr = dtTotales.NewRow
            dr(0) = "SALDO IMPUESTO MES ANTERIOR"
            dr(1) = CDbl(saldototal).ToString("##0.00") '* -1
            dtTotales.Rows.Add(dr)
        End If
        Call CargarUltraGridxBinding(gridTotales, Source4, dtTotales)
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

    Private Sub btncalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncalcular.Click
        'If Ope = 2 Then Exit Sub
        If txtcodcontratista.Text.ToString.Trim = "" Then
            MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcontratista.Focus()
            Exit Sub
        End If
        If cmbMes.SelectedIndex < 0 Then
            MsgBox("Seleccione mes", MsgBoxStyle.Exclamation, msgComacsa)
            cmbMes.Focus()
            Exit Sub
        End If
        Try
            lblmensaje.Visible = True
            lblmensaje.Text = "Calculando Impuestos..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            CargarSaldoImpuestos()
            CargarImpuestos()
            calcularTotal()
            btnCanteras.Visible = True
        Catch ex As Exception
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End Try
       
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
                        'If gridconceptos.ActiveRow.Cells(gridconceptos.ActiveCell.Column.Index).Column.Key = "TOTAL" Then
                        calcularTotal()
                        'End If
                        '.PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        'CalcularTotalComprobantes()
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub calcularTotal()
        gridconceptos.PerformAction(ExitEditMode)
        txttotalotros.Text = 0
        txtsubtotal.Text = 0
        txttotal.Text = 0
        Dim totcompra As Double = 0
        Dim totventa As Double = 0
        Dim totdetraccion As Double = 0
        Dim totrenta As Double = 0
        Dim totsaldoigv As Double = 0
        Dim totsaldo As Double = 0
        Dim calculoigv As Double = 0
        'If txtsubtotal.Text.ToString.Trim = "" Then txtsubtotal.Text = 0
        Dim i As Int32 = 0
        For i = 0 To gridTotales.Rows.Count - 1
            Select Case gridTotales.Rows(i).Cells("OPERACION").Value
                Case Is = "IGV VENTA"
                    totventa = totventa + gridTotales.Rows(i).Cells("TOTAL").Value
                Case Is = "IGV COMPRA"
                    totcompra = totcompra + gridTotales.Rows(i).Cells("TOTAL").Value
                Case Is = "RENTA"
                    totrenta = totrenta + gridTotales.Rows(i).Cells("TOTAL").Value
                Case Is = "DETRACCION"
                    totdetraccion = totdetraccion + gridTotales.Rows(i).Cells("TOTAL").Value
                Case Is = "SALDO IGV MES ANTERIOR"
                    totsaldoigv = totsaldoigv + gridTotales.Rows(i).Cells("TOTAL").Value
                Case Is = "SALDO IMPUESTO MES ANTERIOR"
                    totsaldo = totsaldo + gridTotales.Rows(i).Cells("TOTAL").Value
            End Select
            'Dim importe As Double
            'importe = CDbl(gridImpuestos.Rows(i).Cells("IGV").Value)
            'Dim _operacion As String
            '_operacion = gridImpuestos.Rows(i).Cells("TIPO").Value.ToString.Trim
            'txtsubtotal.Text = CDbl(txtsubtotal.Text) + IIf(_operacion = "VENTA", importe, importe * -1)
        Next
        'calculoigv = totventa - totcompra - totsaldoigv
        calculoigv = totventa + totcompra + totsaldoigv
        If calculoigv > 0 Then
            'txttotal.Text = calculoigv + totrenta - totdetraccion - totsaldo
            txtsubtotal.Text = calculoigv + totrenta + totdetraccion + totsaldo
        Else
            'txttotal.Text = totrenta - totdetraccion - totsaldo
            txtsubtotal.Text = totrenta + totdetraccion + totsaldo
        End If

        txttotal.Text = CDbl(txttotal.Text).ToString("#####0.00")
        txtsubtotal.Text = CDbl(txtsubtotal.Text).ToString("#####0.00")
        For j As Int32 = 0 To gridconceptos.Rows.Count - 1
            Dim importe As Double
            importe = CDbl(gridconceptos.Rows(j).Cells("TOTAL").Value)
            Dim _variacion As String
            _variacion = gridconceptos.Rows(j).Cells("VARIACION").Value.ToString.Trim
            txttotalotros.Text = CDbl(txttotalotros.Text) + IIf(_variacion = "AUMENTA", importe, importe * -1)
        Next
        txttotalotros.Text = CDbl(txttotalotros.Text).ToString("#####0.00")
        txttotal.Text = CDbl(txtsubtotal.Text) + CDbl(txttotalotros.Text)
        txttotal.Text = CDbl(txttotal.Text).ToString("#####0.00")
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
            flgaprobada = 1 : btncalcular.Enabled = False : Button1.Enabled = False : gridconceptos.Enabled = False : Button7.Enabled = False
            rdbDeposito.Enabled = False
            rdbCheque.Enabled = False
            chkbeneficiario.Enabled = False
        Else
            flgaprobada = 0
            gridconceptos.Enabled = True
            btncalcular.Enabled = True : Button1.Enabled = True : Button7.Enabled = True
            rdbDeposito.Enabled = True
            rdbCheque.Enabled = True
            chkbeneficiario.Enabled = True
        End If 'MsgBox("La solicitud se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa) : Return
        

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

        If usuarioSolicitud <> User_Sistema Then esCreador = 0 Else esCreador = 1 : gridconceptos.Enabled = True

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

        '**********************************
        CargarSaldoImpuestos()
        CargarImpuestoAnticipo(NumSolicitud)
        CargarCanteraAnticipo(NumSolicitud)
        btnCanteras.Visible = True
        'btncalcular_Click(Nothing, Nothing)

        'Txt4.Value = NumSolicitud
        'esCreador = uRow.Cells("flgpermiso").Value
        If estado = "CERRADO" Then
            flgaprobada = 0
            chkAprobar.Visible = False
        End If
        If estado = "CERRADO" And CDbl(txttotal.Text) < 0 Then
            gridconceptos.Enabled = True
            btncalcular.Enabled = True
            Button7.Enabled = True
            Button1.Enabled = True
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub
    Sub CargarImpuestoAnticipo(ByVal numsolicitud As String)
        Dim dtDatos As DataTable
        dtDatos = New DataTable
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad.NumSolicitud = numsolicitud
        dtDatos = objNegocio.CargarImpuestoAnticipo(objEntidad)
        Call CargarUltraGridxBinding(gridImpuestos, Source2, dtDatos)
        'If gridImpuestos.Rows.Count > 0 Then
        CalculoTotales()
        'End If
        calcularTotal()
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
        y = gbPlanilla.Location.Y + gbPlanilla.Height
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
                'cmbgrupo.Value = Ls_Anticipo.Item(0)._quincena
                txtcodcontratista.Value = Ls_Anticipo.Item(0)._codprov.ToString.Trim
                txtcontratista.Value = Ls_Anticipo.Item(0)._contratista.ToString.Trim
                txtidcontratista.Value = Ls_Anticipo.Item(0)._idcontratista.ToString
                txtcodcantera.Value = Ls_Anticipo.Item(0)._codcantera.ToString.Trim
                txtcantera.Value = Ls_Anticipo.Item(0)._cantera.ToString.Trim
                txttotal.Value = Ls_Anticipo.Item(0).montoTotal.ToString("#####0.00")
                ctatrabajador = Ls_Anticipo.Item(0).ctatrabajador.ToString.Trim
                renta = Ls_Anticipo.Item(0).renta
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

    Private Sub txtdnibeneficiario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdnibeneficiario.KeyDown
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If Ope = 2 Then Exit Sub
        If txtcodcontratista.Text.ToString.Trim = "" Then
            MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcontratista.Focus()
            Exit Sub
        End If
        If cmbMes.SelectedIndex < 0 Then
            MsgBox("Seleccione mes", MsgBoxStyle.Exclamation, msgComacsa)
            cmbMes.Focus()
            Exit Sub
        End If
        Dim frm As New frmAgregarFactura
        frm.txtcodcontratista.Text = txtcodcontratista.Text
        frm.txtcontratista.Text = txtcontratista.Text
        frm.txtidcontratista.Text = txtidcontratista.Text
        frm.mes = cmbMes.Value
        frm.ayo = txtayo.Value
        Dim rs As DialogResult
        rs = frm.ShowDialog()
        If rs = Windows.Forms.DialogResult.OK Then
            'MsgBox("OK")
        End If
        CargarImpuestos()
        calcularTotal()
    End Sub
    Function validaPeriodoAnticipo() As Boolean
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._tipoanticipo = "I"
        objEntidad._ayo = txtayo.Value
        objEntidad._mes = cmbMes.Value
        objEntidad._quincena = 0
        objEntidad._idcontratista = txtidcontratista.Text
        objEntidad._semanaini = 0
        objEntidad._semanafin = 0
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
        'If txtcodcantera.Text.ToString.Trim = "" Then
        '    MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
        '    txtcodcantera.Focus()
        '    Return False
        'End If
        If txttotal.Text.ToString.Trim = "" Then txttotal.Text = 0
        If txttotal.Text = 0 Then
            MsgBox("Ingrese monto del Anticipo", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If
        Return True
    End Function
    Sub seteoEntidadDetalle()
        Entidad.Contratista = New ETContratista
        Ls_EntregaDetalle = New List(Of ETContratista)
        Dim idconcepto As Int32 = 0
        idconcepto = 13
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
            If dtCanteras.Rows.Count <= 0 Then
                MsgBox("Debe ingresar una Cantera como mínimo", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
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
                        totalcantera = Math.Round(CDbl(totalcantera), 2) + Math.Round(CDbl(dtCanteras.Rows(i)("MONTO")), 2)
                        Ls_Anticipo.Add(Entidad.Contratista)
                    End If
                Next
                If Math.Round(CDbl(totalcantera), 2) <> Math.Round(CDbl(totalanticipo), 2) And totalcantera > 0 Then
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
            x_quincena = 0
            Entidad.Contratista.TipoOperacion = Ope
            Entidad.Contratista.NumSolicitud = NumSolicitud
            Entidad.Contratista._tipoanticipo = "I"
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

            x_descripcion = "POR IMPUESTOS"

            Entidad.Contratista._descripcion = x_descripcion 'txtdescripcion.Text.ToString
            Entidad.Contratista.IDSUPERVISOR = 0
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

                If gridImpuestos.Rows.Count > 0 Then
                    For i As Int32 = 0 To gridImpuestos.Rows.Count - 1
                        Entidad.Contratista = New ETContratista
                        Entidad.Contratista.NumSolicitud = num_solicitud
                        Entidad.Contratista._tipodocumento = gridImpuestos.Rows(i).Cells("TIPO_COMPROB").Value
                        Entidad.Contratista._documento = gridImpuestos.Rows(i).Cells("NUMDOC").Value
                        Entidad.Contratista.Fecha = gridImpuestos.Rows(i).Cells("FECHA").Value
                        Entidad.Contratista._tipoanticipo = gridImpuestos.Rows(i).Cells("TIPO").Value
                        Entidad.Contratista._valorvta = gridImpuestos.Rows(i).Cells("VALORVTA").Value
                        Entidad.Contratista._igv = gridImpuestos.Rows(i).Cells("IGV").Value
                        Entidad.Contratista._valor = gridImpuestos.Rows(i).Cells("TOTAL").Value
                        Entidad.Contratista._orden = gridImpuestos.Rows(i).Cells("ORDEN").Value
                        Entidad.Contratista.renta = gridImpuestos.Rows(i).Cells("RENTA").Value
                        Ls_Anticipo.Add(Entidad.Contratista)
                    Next
                    Entidad.Contratista = Negocio.NContratista.InsertaImpuestoAnticipo(Ls_Anticipo)
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim path As String
            path = Application.StartupPath
            Me.UltraGridExcelExporter1.Export(Me.gridImpuestos, path & "\Facturas.xls")
            Process.Start(path & "\Facturas.xls")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
            'seteoEntidadDetalle()
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            x_mes = 0
            x_quincena = 0
            x_semanaini = 0
            x_semanafin = 0

            x_mes = cmbMes.Value
            x_quincena = 0
            Ope = 3
            Entidad.Contratista.TipoOperacion = Ope
            Entidad.Contratista.NumSolicitud = NumSolicitud
            Entidad.Contratista._tipoanticipo = "I"
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
            Entidad.Contratista.IDSUPERVISOR = 0
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
    Dim dtCanteras As New DataTable
    Private Sub btnCanteras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCanteras.Click
        Try
            If txttotal.Text.Trim = "" Then txttotal.Text = 0
            If txttotal.Text = 0 Then
                MsgBox("El total debe ser diferente a 0", MsgBoxStyle.Exclamation, msgComacsa)
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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            gridImpuestos.ActiveRow.Delete()
            CalculoTotales()
            calcularTotal()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridImpuestos_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridImpuestos.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridImpuestos Then Return
        e.DisplayPromptMsg = Boolean.FalseString
    End Sub
End Class