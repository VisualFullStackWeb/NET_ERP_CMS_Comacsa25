Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmAnticipoOtrosConceptos
    Public montoAnticipo As Double
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
    Private Ls_Anticipo As List(Of ETContratista) = Nothing
    Private Ls_EntregaDetalle As List(Of ETContratista) = Nothing
    Dim x_mes As Int32 = 0
    Dim x_quincena As Int32 = 0
    Dim x_semanaini As Int32 = 0
    Dim x_semanafin As Int32 = 0
    Dim x_descripcion = ""
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Public tipo As String = ""
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
    Sub Buscar()
        If Me.TabMaestroEntregas.Tabs("Lista").Selected = True Then Exit Sub
        If txtcodcontratista.Focused = True Then
            If Ope = 2 Then Exit Sub
            limpiar()
            Dim frm As New frmBuscarContratista
            frm.tipo = tipo
            frm.ShowDialog()
            txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            txtcodcontratista.Text = frm.gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            txtcontratista.Text = frm.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            txtbeneficiario.Text = frm.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            Dim idtipopago As String = frm.gridcontratista.ActiveRow.Cells("TIPOPAGO").Value
            Dim idfrecuenia As Int32 = frm.gridcontratista.ActiveRow.Cells("IDFRECPAGO").Value
            codbanco = frm.gridcontratista.ActiveRow.Cells("CODBANCO").Value.ToString.Trim
            nrocta = frm.gridcontratista.ActiveRow.Cells("NROCTA").Value.ToString.Trim
            If tipo = "PR" Then
                txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            End If
            rdbDeposito_CheckedChanged(Nothing, Nothing)
        End If
        If tipo = "PR" Then
            If txtnumero.Focused = True And rdbOC.Checked = True Then
                Dim frm As New frmOrdenes
                frm.ayo = txtayo.Value
                frm.mes = cmbmes.Value
                frm.codprov = txtcodcontratista.Text
                frm.ShowDialog()
                txtnumero.Text = orden
            End If
            Exit Sub
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
            ' VER LA CANTIDAD DE SUPERVISORES QUE HAY POR CANTERA
            Supervisor_Cantera(txtcodcontratista.Text, txtcodcantera.Text)
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
        txttotalotros.Clear()
        txttotal.Clear()
        txtnumero.Clear()
        txtobservacion.Clear()
        rdbotro.Checked = True
        txtidcontratista.Text = 0
        txtidsupervisor.Text = 0
        txtsupervisor.Clear()
        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            gridconceptos.Rows(i).Cells("TOTAL").Value = "0.00"
        Next
        'btnCanteras.Visible = False
        VisualizarDatosDeposito(False)
        dtCanteras = New DataTable
        chkbeneficiario.Checked = False
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
        Ope = 1
        estado = "PENDIENTE"
        flgaprobada = 0
        lblestado.Visible = False
        txtcodcontratista.Clear()
        txtcontratista.Clear()
        limpiar()
        txtcodcontratista.Focus()
        chkAprobar.Visible = False
        chkAprobar.Checked = False
        Ls_Anticipo = New List(Of ETContratista)
        Ls_EntregaDetalle = New List(Of ETContratista)
        gridconceptos.Enabled = True : UltraGroupBox1.Enabled = True : cmbmes.ReadOnly = False
        CargarConceptos("")
    End Sub
    Sub CargarConceptos(ByVal numSolicitud As String)
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        objEntidad._tipo = 2
        objEntidad._tipoanticipo = tipo
        objEntidad.NumSolicitud = numSolicitud
        dtDatos = objNegocio.Listarconceptos(objEntidad)
        Call CargarUltraGridxBinding(gridconceptos, Source1, dtDatos)
    End Sub

    Private Sub frmAnticipoOtrosConceptos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Procesar()
        txtidcontratista.Visible = True
        txtidsupervisor.Visible = True
    End Sub

    Private Sub frmAnticipoOtrosConceptos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tipo = Me.Tag
        rdbotro.Checked = True
        If tipo = "OA" Then
            gridconceptos.DisplayLayout.Bands(0).Columns("NUMDOC").Hidden = False
            gridconceptos.DisplayLayout.Bands(0).Columns("FECHADOC").Hidden = False
            gridconceptos.DisplayLayout.Bands(0).Columns("SERIE").Hidden = False
            gridconceptos.DisplayLayout.Bands(0).Columns("RUC").Hidden = False
            gridconceptos.DisplayLayout.Bands(0).Columns("RAZON").Hidden = False
            UltraGroupBox1.Visible = False
            UltraLabel19.Text = " ANTICIPO POR OTROS CONCEPTOS"
            txtcomentario.Visible = True
            UltraLabel3.Visible = True
        Else
            gridconceptos.DisplayLayout.Bands(0).Columns("NUMDOC").Hidden = True
            gridconceptos.DisplayLayout.Bands(0).Columns("FECHADOC").Hidden = True
            gridconceptos.DisplayLayout.Bands(0).Columns("SERIE").Hidden = True
            gridconceptos.DisplayLayout.Bands(0).Columns("RUC").Hidden = True
            gridconceptos.DisplayLayout.Bands(0).Columns("RAZON").Hidden = True
            UltraGroupBox1.Visible = True
            UltraLabel19.Text = " ANTICIPO POR PROVEEDORES"
            txtcomentario.Visible = False
            UltraLabel3.Visible = False
        End If
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

    Private Sub gridconceptos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridconceptos.InitializeLayout

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
                        If gridconceptos.ActiveRow.Cells(gridconceptos.ActiveCell.Column.Index).Column.Key = "RUC" Then
                            'If Not ValidarDocumentoRepetido() Then gridDetalle.ActiveRow.Cells("nroruc").Value = "" : gridDetalle.ActiveRow.Cells("razon").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                            ObtenerRazon()
                        End If
                        If gridconceptos.ActiveRow.Cells(gridconceptos.ActiveCell.Column.Index).Column.Key = "SERIE" Then
                            'If Not ValidarDocumentoRepetido() Then gridDetalle.ActiveRow.Cells("NumDoc").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                            gridconceptos.ActiveRow.Cells("SERIE").Value = gridconceptos.ActiveRow.Cells("SERIE").Value.ToString.Trim.PadLeft(3, "0")
                        End If
                        If gridconceptos.ActiveRow.Cells(gridconceptos.ActiveCell.Column.Index).Column.Key = "NUMDOC" Then
                            'If Not ValidarDocumentoRepetido() Then gridDetalle.ActiveRow.Cells("NumDoc").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                            gridconceptos.ActiveRow.Cells("NUMDOC").Value = gridconceptos.ActiveRow.Cells("NUMDOC").Value.ToString.Trim.PadLeft(7, "0")
                        End If

                        If gridconceptos.ActiveRow.Cells(gridconceptos.ActiveCell.Column.Index).Column.Key = "TOTAL" Then
                            txttotalotros.Text = 0
                            calcularTotal()
                        End If

                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        'CalcularTotalComprobantes()
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub ObtenerRazon()
        If gridconceptos.ActiveRow.Cells("RUC").Value.ToString.Trim <> "" And gridconceptos.ActiveRow.Cells("RUC").Value.ToString.Length < 11 Then
            MsgBox("Debe ingresar 11 dígitos", MsgBoxStyle.Exclamation, msgComacsa) : gridconceptos.PerformAction(PrevCellByTab) : Return
        End If
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.nroruc = gridconceptos.ActiveRow.Cells("RUC").Value.ToString
        Entidad.MyLista = Negocio.NEntregas.Listar_ProveedorxRuc(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        If Ls_Entrega.Count > 0 Then
            gridconceptos.ActiveRow.Cells("razon").Value = Ls_Entrega.Item(0).Razon.ToString '"PRUEBA"
            gridconceptos.PerformAction(NextCellByTab)
        Else
            lblmensaje.Visible = True
            lblmensaje.Text = "Buscando Datos en Sunat..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Cursor = Cursors.WaitCursor
            Dim dato_sunat As New metodos()
            Try
                dato_sunat.Buscar_por_DNI = False
                dato_sunat.Buscar_por_Ruc = True
                dato_sunat.Documento_a_Buscar = Entidad.Entregas.nroruc.ToString.Trim
                dato_sunat.Buscar_el_Documento()
            Catch ex As Exception
                Cursor = Cursors.Default
                MsgBox(ex.Message.ToString)
            End Try
            ''mostrar los datos
            If dato_sunat.Dato_Encontrado = True Then
                With dato_sunat
                    gridconceptos.ActiveRow.Cells("razon").Value = .Nombre
                    gridconceptos.PerformAction(NextCellByTab)
                End With
            Else
                MsgBox("No se encontró ruc registrado en la sunat", MsgBoxStyle.Exclamation, msgComacsa)
                gridconceptos.ActiveRow.Cells("RAZON").Value = String.Empty
            End If
            dato_sunat = Nothing
            Cursor = Cursors.Default
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End If
    End Sub
    Sub calcularTotal()
        gridconceptos.PerformAction(ExitEditMode)
        txttotalotros.Text = 0
        'If txtsubtotal.Text.ToString.Trim = "" Then txtsubtotal.Text = 0
        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            'gridconceptos.Rows(i).Cells("montoTotal").Value = importe
            Dim importe As Double
            importe = CDbl(gridconceptos.Rows(i).Cells("TOTAL").Value)
            Dim _variacion As String
            _variacion = gridconceptos.Rows(i).Cells("VARIACION").Value.ToString.Trim
            txttotalotros.Text = CDbl(txttotalotros.Text) + IIf(_variacion = "AUMENTA", importe, importe * -1)
        Next
        txttotalotros.Text = CDbl(txttotalotros.Text).ToString("#####0.00")
        txttotal.Text = CDbl(txttotalotros.Text)
        txttotal.Text = CDbl(txttotal.Text).ToString("#####0.00")
    End Sub
    Function validaDatos() As Boolean
        If txtcodcontratista.Text.ToString.Trim = "" Then
            MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcontratista.Focus()
            Return False
        End If
        If txtcodcantera.Text.ToString.Trim = "" And tipo = "OA" Then
            MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcantera.Focus()
            Return False
        End If
        If cmbmes.SelectedIndex < 0 Then
            MsgBox("Seleccione mes", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcantera.Focus()
            Return False
        End If
        If txttotal.Text.ToString.Trim = "" Then txttotal.Text = 0
        'If txttotal.Text = 0 Then
        '    MsgBox("Ingrese monto del Anticipo", MsgBoxStyle.Exclamation, msgComacsa)
        '    Return False
        'End If
        If tipo = "PR" Then
            If rdbOC.Checked = True Then
                If txtnumero.Text.ToString.Trim = "" Then
                    MsgBox("Ingrese N° de orden de compra", MsgBoxStyle.Exclamation, msgComacsa)
                    txtnumero.Focus()
                    Return False
                End If
            End If
            If rdbContrato.Checked = True Then
                If txtnumero.Text.ToString.Trim = "" Then
                    MsgBox("Ingrese N° de contrato", MsgBoxStyle.Exclamation, msgComacsa)
                    txtnumero.Focus()
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Sub seteoEntidadDetalle()
        Entidad.Contratista = New ETContratista
        Ls_EntregaDetalle = New List(Of ETContratista)
        'Dim idconcepto As Int32 = 0
        'Ls_EntregaDetalle.Add(Entidad.Contratista)
        Dim serie As String = ""
        Dim numero As String = ""
        Dim ruc As String = ""
        Dim razon As String = ""
        Dim fecha As Date
        If gridconceptos.Rows.Count > 0 Then
            For i As Int32 = 0 To gridconceptos.Rows.Count - 1
                'If gridconceptos.Rows(i).Cells("TOTAL").Value > 0 Then
                Entidad.Contratista = New ETContratista
                Entidad.Contratista._idconcepto = gridconceptos.Rows(i).Cells("ID").Value
                Entidad.Contratista._variacion = gridconceptos.Rows(i).Cells("FLAGVARIACION").Value
                Entidad.Contratista.montoTotal = CDbl(gridconceptos.Rows(i).Cells("TOTAL").Value)
                'If gridconceptos.Rows(i).Cells("SERIE").Value Is Nothing Then
                '    serie = ""
                'End If
                serie = IIf(gridconceptos.Rows(i).Cells("SERIE").Value Is Nothing, "", gridconceptos.Rows(i).Cells("SERIE").Value.ToString)
                numero = IIf(gridconceptos.Rows(i).Cells("NUMDOC").Value Is Nothing, "", gridconceptos.Rows(i).Cells("NUMDOC").Value.ToString)
                ruc = IIf(gridconceptos.Rows(i).Cells("RUC").Value Is Nothing, "", gridconceptos.Rows(i).Cells("RUC").Value.ToString)
                razon = IIf(gridconceptos.Rows(i).Cells("RAZON").Value Is Nothing, "", gridconceptos.Rows(i).Cells("RAZON").Value.ToString)
                fecha = IIf(gridconceptos.Rows(i).Cells("FECHADOC").Value Is Nothing, "01/01/1900", IIf(gridconceptos.Rows(i).Cells("FECHADOC").Value.ToString = "", "01/01/1900", gridconceptos.Rows(i).Cells("FECHADOC").Value.ToString))
                Entidad.Contratista._documento = serie & numero
                'Entidad.Contratista._serie = gridconceptos.Rows(i).Cells("SERIE").Value
                Entidad.Contratista.Fecha = fecha
                Entidad.Contratista._ruc = ruc.ToString
                Entidad.Contratista._razon = razon.ToString
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
            'If Ope = 1 Then
            '    If Not validaPeriodoAnticipo() Then
            '        MsgBox("El contratista ya generó un anticipo para este periodo", MsgBoxStyle.Exclamation, msgComacsa)
            '        Exit Sub
            '    End If
            'End If

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

            Entidad.Contratista.TipoOperacion = Ope
            Entidad.Contratista.NumSolicitud = NumSolicitud
            Entidad.Contratista._tipoanticipo = tipo
            Entidad.Contratista._ayo = txtayo.Value
            Entidad.Contratista._mes = cmbmes.Value
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
            If tipo = "OA" Then
                x_descripcion = "POR OTROS CONCEPTOS"
                Entidad.Contratista._observacion = txtcomentario.Text
            Else
                x_descripcion = "POR PROVEEDORES"
                Entidad.Contratista._observacion = txtobservacion.Text
            End If

            Entidad.Contratista._descripcion = x_descripcion 'txtdescripcion.Text.ToString
            Entidad.Contratista.IDSUPERVISOR = txtidsupervisor.Text
            If rdbOC.Checked = True Then
                Entidad.Contratista._numorden = txtnumero.Text
                Entidad.Contratista._numcontrato = ""
            ElseIf rdbContrato.Checked = True Then
                Entidad.Contratista._numorden = ""
                Entidad.Contratista._numcontrato = txtnumero.Text
            End If

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
    Private Sub CargarDatos()
        Entidad.Contratista = New ETContratista
        Entidad.Contratista.TipoOperacion = Ope
        Entidad.Contratista._tipoanticipo = tipo
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
        Call CargarUltraGridxBinding(Me.GridAnticipo, Source2, Ls_Anticipo)
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
            flgaprobada = 1 : gridconceptos.Enabled = False : UltraGroupBox1.Enabled = False : cmbmes.ReadOnly = True
            rdbDeposito.Enabled = False
            rdbCheque.Enabled = False
            chkbeneficiario.Enabled = False
        Else
            flgaprobada = 0
            gridconceptos.Enabled = True : UltraGroupBox1.Enabled = True : cmbmes.ReadOnly = False
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

        If usuarioSolicitud <> User_Sistema Then esCreador = 0 Else esCreador = 1 ': gridconceptos.Enabled = True
        'esCreador = 1
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
        CargarCanteraAnticipo(NumSolicitud)
        'btnCanteras.Visible = True
        'Txt4.Value = NumSolicitud
        'esCreador = uRow.Cells("flgpermiso").Value
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Sub Cargar_DatosSolicitud()
        Try
            Ope = 2
            TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
            Call limpiar()

            'Call HabilitarControles(True)
            lblestado.Visible = True
            UltraLabel39.Visible = True
            'Dim y As Double
            'y = UltraLabel2.Location.Y
            'UltraLabel39.Location = New Point(782, y)
            'lblestado.Location = New Point(914, y)
            If lblestado.Text.ToString.Trim = "DESEMBOLSADO" Then
                VisualizarDatosDeposito(True)
            End If
            If Ls_Anticipo.Count > 0 Then
                txtayo.Value = Ls_Anticipo.Item(0)._ayo
                cmbmes.Value = Ls_Anticipo.Item(0)._mes
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
                If tipo = "PR" Then
                    If Ls_Anticipo.Item(0)._numorden.ToString.Trim <> "" Then
                        rdbOC.Checked = True
                        txtnumero.Text = Ls_Anticipo.Item(0)._numorden.ToString.Trim
                    ElseIf Ls_Anticipo.Item(0)._numcontrato.ToString.Trim <> "" Then
                        rdbContrato.Checked = True
                        txtnumero.Text = Ls_Anticipo.Item(0)._numcontrato.ToString.Trim
                    Else
                        rdbotro.Checked = True
                        txtnumero.Clear()
                        txtobservacion.Clear()
                    End If
                    txtobservacion.Text = Ls_Anticipo.Item(0)._observacion.ToString.Trim
                Else
                    txtnumero.Clear()
                    txtobservacion.Clear()
                    txtcomentario.Text = Ls_Anticipo.Item(0)._observacion.ToString.Trim
                End If
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
        y = UltraGroupBox2.Location.Y + UltraGroupBox2.Height - 10
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
            Entidad.Contratista._tipoanticipo = "OC"
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

    Private Sub rdbOC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbOC.CheckedChanged
        If rdbOC.Checked = True Then
            UltraLabel1.Text = "N° OC"
            txtnumero.Focus()
            txtnumero.Clear()
            txtnumero.ReadOnly = True
        End If
    End Sub
    Private Sub rdbContrato_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbContrato.CheckedChanged
        If rdbContrato.Checked = True Then
            UltraLabel1.Text = "N° Contrato"
            txtnumero.Focus()
            txtnumero.Clear()
            txtnumero.ReadOnly = False
        End If
    End Sub
    Private Sub rdbotro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbotro.CheckedChanged
        If rdbotro.Checked = True Then
            txtnumero.Clear()
            txtnumero.ReadOnly = True
        End If
    End Sub

    Private Sub cmbmes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmes.ValueChanged
        Try
            txtnumero.Clear()
        Catch ex As Exception

        End Try
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
End Class