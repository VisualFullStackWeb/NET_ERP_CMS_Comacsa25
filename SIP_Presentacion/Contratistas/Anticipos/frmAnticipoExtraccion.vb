Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb

Public Class frmAnticipoExtraccion
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
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
    Private Ls_Anticipo As List(Of ETContratista) = Nothing
    Private Ls_EntregaDetalle As List(Of ETContratista) = Nothing
#End Region

    Private Sub frmAnticipoExtraccion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Procesar()
    End Sub

    Private Sub frmAnticipoExtraccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDesde.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
        dtpHasta.Value = Now.Date
        txtayo.Value = Now.Date.Year
        txtsemana.Value = DatePart("ww", Now.Date)
        txtsemanaini.Value = DatePart("ww", Now.Date)
        Dim fecha1 As Date = "01/" & Now.Date.Month & "/" & Now.Date.Year
        Dim fecha2 As Date = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, fecha1)))
        dtinicio.Value = fecha1
        dtfin.Value = fecha2
        gbTonelada.Visible = False
        gbPlanilla.Visible = True
        Procesar()
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
        Entidad.Contratista._tipoanticipo = "E"
        Negocio.NContratista = New NGContratista
        Entidad.MyLista = New ETMyLista
        Ls_Anticipo = Nothing
        Ls_Anticipo = New List(Of ETContratista)
        Ls_EntregaDetalle = Nothing
        Ls_EntregaDetalle = New List(Of ETContratista)
        Entidad.Contratista._fecha1 = dtpDesde.Value
        Entidad.Contratista._fecha2 = dtpHasta.Value
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.MyLista = Negocio.NContratista.ListarAnticipos(Entidad.Contratista)
        If Entidad.MyLista.Validacion Then
            Ls_Anticipo = Entidad.MyLista.Ls_Anticipo
        End If
        Call CargarUltraGridxBinding(Me.GridAnticipo, Source2, Ls_Anticipo)
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
    Private Sub CargarBancos()
        Dim objNegocio As NGContratista = Nothing
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtBanco As New DataTable
        dtBanco = objNegocio.ListarBanco()
        Call CargarUltraCombo(cmbbanco, dtBanco, "cod_maestro2", "descrip")
    End Sub
    Dim idtipopago As String = ""
    Dim codbanco As String = ""
    Dim nrocta As String = ""
    Dim idfrecuenia As Int32 = 0

    Dim x_mes As Int32 = 0
    Dim x_quincena As Int32 = 0
    Dim x_semanaini As Int32 = 0
    Dim x_semanafin As Int32 = 0
    Dim x_descripcion = ""

    Dim cant_supervisor As Int32 = 0
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
            idtipopago = frm.gridcontratista.ActiveRow.Cells("TIPOPAGO").Value
            idfrecuenia = frm.gridcontratista.ActiveRow.Cells("IDFRECPAGO").Value
            'txtcodcantera.Focus()
            seteoVisible(idfrecuenia, idtipopago)
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

    Sub seteoVisible(ByVal _idfrecuenia As Int32, ByVal _idtipopago As String)
        gbsemanal.Visible = False
        gb2semanas.Visible = False
        gbquincenal.Visible = False
        gbmensual.Visible = False
        Select Case _idfrecuenia
            Case 1
                gbsemanal.Visible = True
                txtsemana.Value = DatePart("ww", Now.Date)
                Fecha_Semana(txtsemana.Value, 1)
            Case 2
                gb2semanas.Visible = True
                txtsemanaini.Value = DatePart("ww", Now.Date)
                Fecha_Semana(txtsemanaini.Value, 2)
            Case 3
                gbquincenal.Visible = True
                cmbmesquincena.Value = Now.Date.Month
                Fecha_Quincena()
            Case 4
                gbmensual.Visible = True
                cmbMes.Value = Now.Date.Month
                Fecha_Mes()
        End Select

        If _idtipopago.Trim = "T" Then
            gbPlanilla.Text = "REGISTRO ANTICIPO POR TONELADAS"
            'btncargarplanilla.Visible = False
            btnver.Text = "Ver Minerales"
            dtinicio.ReadOnly = False
            dtfin.ReadOnly = False
            chkporviaje.Checked = False
            chkporviaje.Visible = True
        ElseIf _idtipopago.Trim = "P" Then
            'btncargarplanilla.Visible = True
            btnver.Text = "Ver Planilla"
            dtinicio.ReadOnly = True
            dtfin.ReadOnly = True
            gbPlanilla.Text = "REGISTRO ANTICIPO POR PLANILLA"
            chkporviaje.Checked = False
            chkporviaje.Visible = False
        Else
            MsgBox("Contratista no posee configuración para esta cantera", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcantera.Focus()
            limpiar()
            Exit Sub
        End If
    End Sub

    Sub limpiar()
        txtcodcantera.Clear()
        txtcantera.Clear()
        txtsupervisor.Clear()
        txtsubtotal.Clear()
        txttotalotros.Clear()
        txttotal.Clear()
        txtidcontratista.Text = 0
        txtidsupervisor.Text = 0
        dtMinerales = New DataTable
        dtPlanilla = New DataTable
        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            gridconceptos.Rows(i).Cells("TOTAL").Value = "0.00"
        Next
        VisualizarDatosDeposito(False)
        chkporviaje.Checked = False
        txtcomentario.Clear()
        chkbeneficiario.Checked = False
        'dtCanteras = New DataTable
    End Sub

    Sub Fecha_Semana(ByVal semana As Int32, ByVal tipo As Int32)
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._semana = semana
        objEntidad._tipo = tipo
        objEntidad._ayo = txtayo.Value

        Dim dtValores As New DataSet
        dtValores = objNegocio.FechaSemana(objEntidad)

        If dtValores.Tables(0).Rows.Count = 0 Then MsgBox("No existe rango de fecha para la semana " & semana, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
        If tipo = 1 Then
            dtfin.Value = dtValores.Tables(0).Rows(0)("FECHAFIN")
        ElseIf tipo = 2 Then
            If dtValores.Tables(1).Rows.Count = 0 Then MsgBox("No existe rango de fecha para las semanas " & semana & ", " & semana + 1, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
            dtfin.Value = dtValores.Tables(1).Rows(0)("FECHAFIN")
        End If
        dtinicio.Value = dtValores.Tables(0).Rows(0)("FECHAINI")

        txtsubtotal.Clear()
        txttotal.Clear()
        dtMinerales = New DataTable
        calcularTotal()
    End Sub

    Private Sub txtsemana_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsemana.ValueChanged
        If gbsemanal.Visible = False Then Exit Sub
        Fecha_Semana(txtsemana.Value, 1)
    End Sub

    Private Sub txtsemanaini_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsemanaini.ValueChanged
        If gb2semanas.Visible = False Then Exit Sub
        Fecha_Semana(txtsemanaini.Value, 2)
        LBLFINAL.Text = "Sem. Final   :" & txtsemanaini.Value + 1
    End Sub

    Sub Fecha_Quincena()
        If cmbmesquincena.SelectedIndex < 0 Then
            MsgBox("Seleccione Mes", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
        Else
            Dim quincena As Int32
            Dim mes As Int32
            mes = cmbmesquincena.Value
            Dim fecha1 As Date
            Dim fechainicio As Date
            Dim fecha2 As Date
            fecha1 = "01/" & mes & "/" & txtayo.Value
            If rdb1quincena.Checked = True Then
                quincena = 1
                fechainicio = fecha1
                fecha2 = "15/" & mes & "/" & txtayo.Value
            Else
                quincena = 2
                fechainicio = "16/" & mes & "/" & txtayo.Value
                fecha2 = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, fecha1)))
            End If
            dtinicio.Value = fechainicio
            dtfin.Value = fecha2
            txtsubtotal.Clear()
            'txttotalotros.Clear()
            txttotal.Clear()
            dtMinerales = New DataTable
            calcularTotal()
        End If
    End Sub
    Sub Fecha_Mes()
        If cmbMes.SelectedIndex < 0 Then
            Exit Sub : MsgBox("Seleccione Mes", MsgBoxStyle.Exclamation, msgComacsa)
        Else
            Dim mes As Int32
            mes = cmbMes.Value
            Dim fecha1 As Date
            Dim fecha2 As Date
            fecha1 = "01/" & mes & "/" & txtayo.Value
            fecha2 = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, fecha1)))

            dtinicio.Value = fecha1
            dtfin.Value = fecha2

            txtsubtotal.Clear()
            txttotal.Clear()
            dtMinerales = New DataTable
            calcularTotal()
        End If
    End Sub
    Private Sub cmbmesquincena_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmesquincena.ValueChanged
        Try
            Fecha_Quincena()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdb1quincena_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb1quincena.CheckedChanged
        If rdb1quincena.Checked = True Then
            Fecha_Quincena()
        End If
    End Sub

    Private Sub rdb2quincena_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb2quincena.CheckedChanged
        If rdb2quincena.Checked = True Then
            Fecha_Quincena()
        End If
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            Fecha_Mes()
        Catch ex As Exception
        End Try
    End Sub
    Sub CargarConceptos(ByVal numSolicitud As String)
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        objEntidad._tipo = 2
        objEntidad._tipoanticipo = "E"
        objEntidad.NumSolicitud = numSolicitud
        dtDatos = objNegocio.Listarconceptos(objEntidad)
        Call CargarUltraGridxBinding(gridconceptos, Source1, dtDatos)
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
    Dim dtMinerales As New DataTable
    Dim dtPlanilla As New DataTable
    Dim dtnoExistente As New DataTable
    Private Sub btnprocesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprocesar.Click
        Try
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
            If cant_supervisor > 1 Then
                If txtidsupervisor.Text = 0 Or txtsupervisor.Text = "" Then
                    MsgBox("Debe seleccionar un supervisor", MsgBoxStyle.Exclamation, msgComacsa)
                    txtsupervisor.Focus()
                    Exit Sub
                End If
            End If
            If Not validaPeriodoAnticipo() Then
                MsgBox("El contratista ya generó un anticipo para este periodo", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            PlanillaPeriodo()
            btnver_Click(Nothing, Nothing)
            calcularTotal()
        Catch ex As Exception

        End Try
    End Sub
    Function validaPeriodoAnticipo() As Boolean
        If Ope = 2 Then Return True
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._tipoanticipo = "E"
        objEntidad._ayo = txtayo.Value
        If gbquincenal.Visible = True Then
            objEntidad._mes = cmbmesquincena.Value
            objEntidad._quincena = IIf(rdb1quincena.Checked = True, 1, 2)
        ElseIf gbquincenal.Visible = True Then
            objEntidad._mes = cmbMes.Value
            objEntidad._quincena = 0
        End If
        objEntidad._idcontratista = txtidcontratista.Text
        objEntidad._semanaini = 0
        objEntidad._semanafin = 0
        Dim dt As New DataTable
        dt = objNegocio.validaPeriodo(objEntidad)
        If idtipopago.Trim = "T" Then
            Return True
        End If
        If dt.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Sub PlanillaPeriodo()
        If idtipopago.Trim = "T" Then
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._fecha1 = dtinicio.Value
            objEntidad._fecha2 = dtfin.Value
            objEntidad._codcantera = txtcodcantera.Text
            objEntidad._codprov = txtcodcontratista.Text
            objEntidad.IDSUPERVISOR = txtidsupervisor.Text
            dtMinerales = objNegocio.IngresoMineralFecha(objEntidad)
            'Call CargarUltraGridxBinding(gridconceptos, Source1, dtMinerales)
        ElseIf idtipopago.Trim = "P" Then
            dtPlanilla = New DataTable
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._tipo = idfrecuenia
            objEntidad._ayo = txtayo.Value
            objEntidad._codcantera = txtcodcantera.Text
            objEntidad._codprov = txtcodcontratista.Text
            If gbquincenal.Visible = True Then
                objEntidad._mes = cmbmesquincena.Value
                objEntidad._quincena = IIf(rdb1quincena.Checked = True, 1, 2)
            ElseIf gbmensual.Visible = True Then
                objEntidad._mes = cmbMes.Value
                objEntidad._quincena = 0
            End If
            dtPlanilla = objNegocio.IngresoPlanillaFecha(objEntidad)
        End If
    End Sub
    Sub calcularTotal()
        gridconceptos.PerformAction(ExitEditMode)
        txttotalotros.Text = 0
        If txtsubtotal.Text.ToString.Trim = "" Then txtsubtotal.Text = 0
        Dim subtotalmineral As Double = 0
        If dtMinerales.Rows.Count > 0 And idtipopago.ToString.Trim = "T" Then
            For i As Int32 = 0 To dtMinerales.Rows.Count - 1
                subtotalmineral = subtotalmineral + dtMinerales.Rows(i)("TOTAL")
            Next
            txtsubtotal.Text = CDbl(subtotalmineral).ToString("#####0.00")
        End If

        If dtPlanilla.Rows.Count > 0 And idtipopago.ToString.Trim = "P" Then
            For i As Int32 = 0 To dtPlanilla.Rows.Count - 1
                subtotalmineral = subtotalmineral + dtPlanilla.Rows(i)("TOTALPAGO")
            Next
            txtsubtotal.Text = CDbl(subtotalmineral).ToString("#####0.00")
        End If

        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            Dim importe As Double
            importe = CDbl(gridconceptos.Rows(i).Cells("TOTAL").Value)
            Dim _variacion As String
            _variacion = gridconceptos.Rows(i).Cells("VARIACION").Value.ToString.Trim
            txttotalotros.Text = CDbl(txttotalotros.Text) + IIf(_variacion = "AUMENTA", importe, importe * -1)
        Next
        txttotalotros.Text = CDbl(txttotalotros.Text).ToString("#####0.00")
        txttotal.Text = CDbl(txtsubtotal.Text) + CDbl(txttotalotros.Text)
        txttotal.Text = CDbl(txttotal.Text).ToString("#####0.00")
    End Sub

    Private Sub btnver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnver.Click
        Try
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
            If cant_supervisor > 1 Then
                If txtidsupervisor.Text = 0 Or txtsupervisor.Text = "" Then
                    MsgBox("Debe seleccionar un supervisor", MsgBoxStyle.Exclamation, msgComacsa)
                    txtsupervisor.Focus()
                    Exit Sub
                End If
            End If
            If Not validaPeriodoAnticipo() Then
                MsgBox("El contratista ya generó un anticipo para este periodo", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If idtipopago.Trim = "T" Then
                If dtMinerales.Rows.Count <= 0 Then
                    MsgBox("No hay datos para mostrar", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                Else
                    Dim frm As New frmverMineral
                    frm.COD_PROV = txtcodcontratista.Text
                    frm.FECHA1 = dtinicio.Value
                    frm.COD_CANTERA = txtcodcantera.Text
                    frm.dtMinerales = dtMinerales
                    If flgaprobada = 1 Then
                        frm.gridMineral.Enabled = False
                    Else
                        frm.gridMineral.Enabled = True
                    End If
                    frm.ShowDialog()
                End If
            ElseIf idtipopago.Trim = "P" Then
                If dtPlanilla.Rows.Count <= 0 Then
                    MsgBox("No hay datos para mostrar", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                Else
                    Dim frm As New frmverPlanilla
                    frm.dtPlanilla = dtPlanilla
                    frm.CONTRATISTA = txtcontratista.Text
                    If flgaprobada = 1 Then
                        frm.gridPlanilla.Enabled = False
                    Else
                        frm.gridPlanilla.Enabled = True
                    End If
                    frm.ShowDialog()
                End If
            End If
            calcularTotal()
        Catch ex As Exception

        End Try
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

    'Sub Grabar()
    '    Try
    '        calcularTotal()
    '        'gridconceptos.PerformAction(ExitEditMode)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Sub Nuevo()
        Me.TabMaestroEntregas.Tabs("Registro").Selected = True
        btnprocesar.Enabled = True
        btncargarplanilla.Enabled = True
        gbquincenal.Enabled = True
        gbmensual.Enabled = True
        gbsemanal.Enabled = True
        gb2semanas.Enabled = True
        dtinicio.Enabled = True
        dtfin.Enabled = True
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
        txtcodcontratista.Focus()
        dtMinerales = New DataTable
        dtPlanilla = New DataTable
        Ls_Anticipo = New List(Of ETContratista)
        Ls_EntregaDetalle = New List(Of ETContratista)
        chkAprobar.Visible = False
        chkAprobar.Checked = False
        gridconceptos.Enabled = True
    End Sub
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
        If txttotal.Text.ToString.Trim = "" Then txttotal.Text = 0
        'If txttotal.Text = 0 Then
        '    MsgBox("Ingrese monto del Anticipo", MsgBoxStyle.Exclamation, msgComacsa)
        '    Return False
        'End If
        Return True
    End Function
    Private Sub btncargarplanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncargarplanilla.Click
        Try
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
            If Not validaPeriodoAnticipo() Then
                MsgBox("El contratista ya generó un anticipo para este periodo", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            PlanillaPeriodo()
            If dtPlanilla.Rows.Count > 0 Then
                If MsgBox("¿Ya se cargó una planilla para este periodo desea volver a cargar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName
            Cursor = Cursors.WaitCursor

            If Not ValidarExcel(cadenaExcel, txtcodcantera.Text) Then
                MsgBox("El archivo seleccionado es incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                Cursor = Cursors.Default
                Return
            End If
            'MsgBox("ENTRANDO A CONEXION OLEDB")
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                          "Data Source= " & cadenaExcel & _
                          ";Extended Properties=""Excel 8.0;HDR=YES"""
            Dim oConn As New OleDbConnection(cs)

            Try
                oConn.Open()
                CargarDatos(oConn, txtcodcantera.Text, 1)
                If dtnoExistente.Rows.Count > 0 Then
                    objNegocio = New NGContratista
                    objEntidad = New ETContratista
                    objEntidad._tipodocumento = "01"
                    objEntidad._idcontratista = txtidcontratista.Text
                    objEntidad._codprov = txtcodcontratista.Text
                    objEntidad._codcantera = txtcodcantera.Text
                    objEntidad._ayo = txtayo.Value
                    Select Case idfrecuenia
                        Case 3 'QUINCENAL
                            x_mes = cmbmesquincena.Value
                            x_quincena = IIf(rdb1quincena.Checked = True, 1, 2)
                        Case 4  'MENSUAL
                            x_mes = cmbMes.Value
                    End Select
                    objEntidad._mes = x_mes
                    objEntidad._quincena = x_quincena
                    objEntidad._semanaini = 0
                    objEntidad._semanafin = 0
                    objEntidad._usuario = User_Sistema
                    objEntidad._tipoanticipo = "E"
                    objNegocio.EliminaPlanillaPeriodo(objEntidad)
                    MessageBox.Show("El archivo contiene trabajador(es) no registrados en la BD", "Sistema", MessageBoxButtons.OK)
                    Dim frm As New frmnoExistente
                    frm.dtPlanilla = dtnoExistente
                    frm.ShowDialog()
                    Exit Sub
                End If
                MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
                btnprocesar_Click(Nothing, Nothing)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ocurrió un error")
                'MsgBox("Archivo incorrecto a ya se encuentra utilizado", MsgBoxStyle.Critical, "Comacsa")
            Finally
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Cursor = Cursors.Default
                oConn.Close()
                oConn.Dispose()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function BuscarTexto(ByVal Texto As String, ByVal Busqueda As String) As Boolean
        Dim i As Integer
        i = InStr(1, Texto, Busqueda)
        If i > 0 Then
            BuscarTexto = True
        Else
            BuscarTexto = False
        End If
    End Function
    Function ValidarExcel(ByVal RUTA As String, ByVal codCantera As String) As Boolean
        Cursor = Cursors.WaitCursor
        'lblmensaje.Visible = True
        'lblmensaje.Text = "Validando datos de libro Excel..."
        'lblmensaje.Refresh()
        If BuscarTexto(RUTA, "CTS") Then Return False
        If BuscarTexto(RUTA, "GRATIFICACION") Then Return False
        Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
        Dim ObjW As Microsoft.Office.Interop.Excel.Workbook
        ObjExcel = New Microsoft.Office.Interop.Excel.Application
        ObjW = ObjExcel.Workbooks.Open(RUTA)
        Try
            For i As Int32 = 1 To ObjW.Sheets.Count
                If ObjW.Sheets(i).Name = codCantera Then
                    Return True
                End If
            Next
            Return False
            'Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ObjW.Close()
            ObjW = Nothing
            ObjExcel.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(ObjExcel)
            ObjExcel = Nothing
        End Try
    End Function
    Sub cargarDatos(ByVal oConn As OleDbConnection, ByVal hoja As String, ByVal formato As Integer)
        Dim Ls_datos = New List(Of ETProveedorFiscalizado)
        Dim DtSet As New System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        MyCommand = New System.Data.OleDb.OleDbDataAdapter _
        ("select * from [" & hoja & "$]", oConn)
        MyCommand.TableMappings.Add("Table", "TablaSustento")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim dtSeteoExcel As New DataTable
        dtSeteoExcel = objNegocio.ListarSeteoExcel()
        Dim _DNI As String = dtSeteoExcel.Rows(0)("CONCEPTOEXCEL")
        Dim _REMUNERACION As String = dtSeteoExcel.Rows(1)("CONCEPTOEXCEL")
        Dim _PAGO As String = dtSeteoExcel.Rows(2)("CONCEPTOEXCEL")
        Dim _ONP As String = dtSeteoExcel.Rows(3)("CONCEPTOEXCEL")
        Dim _AFP As String = dtSeteoExcel.Rows(4)("CONCEPTOEXCEL")
        Dim _QUINTA As String = dtSeteoExcel.Rows(5)("CONCEPTOEXCEL")
        Dim _ESSALUD As String = dtSeteoExcel.Rows(6)("CONCEPTOEXCEL")
        Dim _SCTR As String = dtSeteoExcel.Rows(7)("CONCEPTOEXCEL")
        Dim _AFPCOMP As String = dtSeteoExcel.Rows(8)("CONCEPTOEXCEL")
        Dim _FMINERO As String = dtSeteoExcel.Rows(9)("CONCEPTOEXCEL")
        Dim _APE_PAT As String = dtSeteoExcel.Rows(12)("CONCEPTOEXCEL")
        Dim _APE_MAT As String = dtSeteoExcel.Rows(13)("CONCEPTOEXCEL")
        Dim _NOMBRES As String = dtSeteoExcel.Rows(14)("CONCEPTOEXCEL")
        dtPlanilla = DtSet.Tables(0)
        dtnoExistente = New DataTable
        If dtnoExistente.Columns.Count <= 0 Then
            dtnoExistente.Columns.Add("DNI")
            dtnoExistente.Columns.Add("NOMBRES")
        End If
        For i As Int32 = 0 To dtPlanilla.Rows.Count - 1
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._tipodocumento = "01"
            objEntidad._documento = dtPlanilla.Rows(i)(_DNI)
            objEntidad._ayo = txtayo.Value
            If gbquincenal.Visible = True Then
                objEntidad._mes = cmbmesquincena.Value
                objEntidad._quincena = IIf(rdb1quincena.Checked = True, 1, 2)
            ElseIf gbquincenal.Visible = True Then
                objEntidad._mes = cmbMes.Value
                objEntidad._quincena = 0
            End If
            objEntidad._semanaini = 0
            objEntidad._semanafin = 0
            objEntidad._fecha1 = dtinicio.Value
            objEntidad._fecha2 = dtfin.Value
            objEntidad._codprov = txtcodcontratista.Text
            objEntidad._codcantera = txtcodcantera.Text
            objEntidad._sueldo = dtPlanilla.Rows(i)(_REMUNERACION)
            objEntidad._pago = dtPlanilla.Rows(i)(_PAGO)
            objEntidad._onp = dtPlanilla.Rows(i)(_ONP)
            objEntidad._afp = dtPlanilla.Rows(i)(_AFP)
            objEntidad._essalud = dtPlanilla.Rows(i)(_ESSALUD)
            objEntidad._quinta = dtPlanilla.Rows(i)(_QUINTA)
            objEntidad._sctr = dtPlanilla.Rows(i)(_SCTR)
            objEntidad._afpcomp = dtPlanilla.Rows(i)(_AFPCOMP)
            objEntidad._fminero = dtPlanilla.Rows(i)(_FMINERO)
            objEntidad._usuario = User_Sistema
            objEntidad._apepat = dtPlanilla.Rows(i)(_APE_PAT)
            objEntidad._apemat = dtPlanilla.Rows(i)(_APE_MAT)
            objEntidad._nombres = dtPlanilla.Rows(i)(_NOMBRES)
            Dim id_trabajador As Int32
            id_trabajador = objNegocio.ImportarPlanilla(objEntidad)
            If id_trabajador = 0 Then
                Dim dr As DataRow
                dr = dtnoExistente.NewRow
                dr(0) = objEntidad._documento.Trim
                dr(1) = objEntidad._apepat.Trim & " " & objEntidad._apemat.Trim & " " & " " & objEntidad._nombres.Trim
                dtnoExistente.Rows.Add(dr)
            End If
        Next
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

            'MsgBox(idfrecuenia.ToString)
            'Exit Sub

            x_mes = 0
            x_quincena = 0
            x_semanaini = 0
            x_semanafin = 0

            Select Case idfrecuenia
                Case 3 'QUINCENAL
                    x_mes = cmbmesquincena.Value
                    x_quincena = IIf(rdb1quincena.Checked = True, 1, 2)
                Case 4  'MENSUAL
                    x_mes = cmbMes.Value
            End Select

            Entidad.Contratista.TipoOperacion = Ope
            Entidad.Contratista.NumSolicitud = NumSolicitud
            Entidad.Contratista._tipoanticipo = "E"
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
            Entidad.Contratista._observacion = txtcomentario.Text
            Entidad.Contratista._usuario = User_Sistema
            'Dim x_descripcion As String = ""
            'x_descripcion = String.Empty
            If idtipopago.Trim = "P" Then
                x_descripcion = "POR EXTRACCION (POR PLANILLA)"
            Else
                x_descripcion = "POR EXTRACCION DE MINERAL"
            End If
            Entidad.Contratista._descripcion = x_descripcion 'txtdescripcion.Text.ToString
            Entidad.Contratista.IDSUPERVISOR = txtidsupervisor.Text
            'Dim ls_Solicitud = Ls_Anticipo.Where(Function(x) x.codConcepto.ToString.Trim <> "").FirstOrDefault
            Ls_Anticipo = New List(Of ETContratista)
            Entidad.Contratista = Negocio.NContratista.MantenimientoAnticipo(Entidad.Contratista, Ls_Anticipo, Ls_EntregaDetalle)
            Dim num_solicitud As String = Entidad.Contratista.NumSolicitud
            If Entidad.Contratista.Validacion Then
                If idtipopago.Trim = "T" Then
                    If dtMinerales.Rows.Count > 0 Then
                        For i As Int32 = 0 To dtMinerales.Rows.Count - 1
                            Entidad.Contratista = New ETContratista
                            Entidad.Contratista.NumSolicitud = num_solicitud
                            Entidad.Contratista.activo = IIf(dtMinerales.Rows(i)("ACTIVO") = True, 1, 0)
                            Entidad.Contratista._billete = dtMinerales.Rows(i)("NUMDOC")
                            Entidad.Contratista._toneladas = dtMinerales.Rows(i)("TOTALTONELADAS")
                            Entidad.Contratista._codmineral = dtMinerales.Rows(i)("COD_MATPRIMA")
                            Entidad.Contratista._mineral = dtMinerales.Rows(i)("MINERAL")
                            Entidad.Contratista._precio = dtMinerales.Rows(i)("PRECIO")
                            Entidad.Contratista.montoTotal = dtMinerales.Rows(i)("TOTAL")
                            Entidad.Contratista.FechaIngreso = dtMinerales.Rows(i)("FECHA")
                            Entidad.Contratista._preciofactura = dtMinerales.Rows(i)("PRECIOFACTURA")
                            Entidad.Contratista._porcentaje = dtMinerales.Rows(i)("PORCENTAJE")
                            Entidad.Contratista._comentario = dtMinerales.Rows(i)("COMENTARIO")
                            Entidad.Contratista._billeteref = dtMinerales.Rows(i)("BILLETEREF")
                            Ls_Anticipo.Add(Entidad.Contratista)
                        Next
                        Entidad.Contratista = Negocio.NContratista.InsertaMineralAnticipo(Ls_Anticipo)
                    End If
                ElseIf idtipopago.Trim = "P" Then
                    If dtPlanilla.Rows.Count > 0 Then
                        For i As Int32 = 0 To dtPlanilla.Rows.Count - 1
                            Entidad.Contratista = New ETContratista
                            Entidad.Contratista.NumSolicitud = num_solicitud
                            Entidad.Contratista._idtrabajador = dtPlanilla.Rows(i)("IDTRABAJADOR")
                            Entidad.Contratista._sueldo = dtPlanilla.Rows(i)("REMUNERACION")
                            Entidad.Contratista._pago = dtPlanilla.Rows(i)("TOTALPAGO")
                            Entidad.Contratista._onp = dtPlanilla.Rows(i)("ONP")
                            Entidad.Contratista._afp = dtPlanilla.Rows(i)("AFP")
                            Entidad.Contratista._essalud = dtPlanilla.Rows(i)("ESSALUD")
                            Entidad.Contratista._quinta = dtPlanilla.Rows(i)("QUINTA")
                            Entidad.Contratista._sctr = dtPlanilla.Rows(i)("SCTR")
                            Entidad.Contratista._afpcomp = dtPlanilla.Rows(i)("AFPCOMP")
                            Entidad.Contratista._fminero = dtPlanilla.Rows(i)("FMINERO")
                            Ls_Anticipo.Add(Entidad.Contratista)
                        Next
                        Entidad.Contratista = Negocio.NContratista.InsertaPlanillaAnticipo(Ls_Anticipo)
                    End If
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

    Sub seteoEntidadDetalle()
        Entidad.Contratista = New ETContratista
        Ls_EntregaDetalle = New List(Of ETContratista)
        Dim idconcepto As Int32 = 0
        If idtipopago.Trim = "P" Then
            idconcepto = 11
        Else
            idconcepto = 10
        End If
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

    Private Sub cmbMoneda_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbMoneda.InitializeLayout
        With cmbMoneda.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("moneda").Width = sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "moneda") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
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

    Private Sub txtdnibeneficiario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdnibeneficiario.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
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
            flgaprobada = 1 : gridconceptos.Enabled = False
            rdbDeposito.Enabled = False
            rdbCheque.Enabled = False
            chkbeneficiario.Enabled = False
        Else
            flgaprobada = 0
            gridconceptos.Enabled = True
            rdbDeposito.Enabled = True
            rdbCheque.Enabled = True
            chkbeneficiario.Enabled = True
        End If

        'If Not estado = "PENDIENTE" Then flgaprobada = 1 : gridconceptos.Enabled = False Else flgaprobada = 0 'MsgBox("La solicitud se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa) : Return

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
        esCreador = 1
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
        If idtipopago.ToString.Trim = "T" Then
            CargarMineralAnticipo(NumSolicitud)
        Else
            CargarPlanillaAnticipo(NumSolicitud)
        End If
        'Txt4.Value = NumSolicitud
        'esCreador = uRow.Cells("flgpermiso").Value
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub
    Sub CargarMineralAnticipo(ByVal numsolicitud As String)
        Entidad.Contratista = New ETContratista
        Negocio.NContratista = New NGContratista
        Entidad.Contratista.NumSolicitud = numsolicitud
        dtMinerales = New DataTable
        dtMinerales = Negocio.NContratista.ListarMineralAniticipo(numsolicitud)
        calcularTotal()
    End Sub
    Sub CargarPlanillaAnticipo(ByVal numsolicitud As String)
        Entidad.Contratista = New ETContratista
        Negocio.NContratista = New NGContratista
        Entidad.Contratista.NumSolicitud = numsolicitud
        dtPlanilla = New DataTable
        dtPlanilla = Negocio.NContratista.ListarPlanillaAniticipo(numsolicitud)
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
            btnprocesar.Enabled = False
            btncargarplanilla.Enabled = False
            gbquincenal.Enabled = False
            gbmensual.Enabled = False
            gbsemanal.Enabled = False
            gb2semanas.Enabled = False
            dtinicio.Enabled = False
            dtfin.Enabled = False
            'Call HabilitarControles(True)
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
                idtipopago = Ls_Anticipo.Item(0)._tipopago.Trim
                idfrecuenia = Ls_Anticipo.Item(0)._idfrecpago
                seteoVisible(Ls_Anticipo.Item(0)._idfrecpago, Ls_Anticipo.Item(0)._tipopago.Trim)
                Select Case Ls_Anticipo.Item(0)._idfrecpago
                    Case 3 'QUINCENAL
                        cmbmesquincena.Value = Ls_Anticipo.Item(0)._mes
                        If Ls_Anticipo.Item(0)._quincena = 1 Then
                            rdb1quincena.Checked = True
                        Else
                            rdb2quincena.Checked = True
                        End If
                        'IIf(Ls_Anticipo.Item(0)._quincena = 1, rdb1quincena.Checked = True, rdb2quincena.Checked = True)
                    Case 4  'MENSUAL
                        cmbMes.Value = Ls_Anticipo.Item(0)._mes
                End Select
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
                txtcomentario.Text = Ls_Anticipo.Item(0)._observacion.ToString.Trim
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

    Private Sub GridAnticipo_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridAnticipo.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "NumSolicitud" OrElse uColumn.Key = "_descripcion" OrElse uColumn.Key = "FechaIngreso" OrElse _
                    uColumn.Key = "_contratista" OrElse uColumn.Key = "Estado" OrElse uColumn.Key = "_cantera" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "periodo") Then ' OrElse uColumn.Key = "moneda"
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
            Entidad.Contratista._tipoanticipo = "E"
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
End Class