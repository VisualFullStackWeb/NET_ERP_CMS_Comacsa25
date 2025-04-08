Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmEntregasxRendir
    Dim objNegocio As NGEntregas
    Dim objEntidad As ETEntregas
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    'Public Saldo_LC_T1 = 0.0  'Para indicar el saldo de T&E
    'Public Saldo_LC_T2 = 0.0  'Para indicar el saldo P-Card

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

    Private Sub FrmEntregasxRendir_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Actualizar()
    End Sub

    Private Sub FrmInsumosControlados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
#Region "Procedimientos Privados"
    Private Sub Inicio()
        Call HabilitarControles(True)
        TxtCodigoTrabajador.ReadOnly = True
        Call CargarDatos()
        Call CargarAreas()
        Call CargarCanteras()
        Call CargarMonedas()
        Call CargarBancos()
        Me.dtFechaSalida.Value = Now.Date
        Me.dtFechaRetorno.Value = Now.Date
        Dim fecha1 As Date = dtFechaSalida.Value
        Dim fecha2 As Date = dtFechaRetorno.Value
        calculoDias(fecha1, fecha2)
        Me.TabMaestroEntregas.Tabs("Lista").Selected = True
        esprimera = 1
    End Sub
    Private Sub CargarDatos()
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.TipoOperacion = Ope
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Ls_EntregaDetalle = Nothing
        Ls_EntregaDetalle = New List(Of ETEntregas)
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.MyLista = Negocio.NEntregas.ListarEntregas(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.GridSolicitudes, Source1, Ls_Entrega)
    End Sub

    Private Sub CargarAreas()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarAreas
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraCombo(cmbArea, Ls_Entrega, "codArea", "Area")
    End Sub

    Private Sub CargarCanteras()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarCanteras
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraCombo(cmbCantera, Ls_Entrega, "codCantera", "Cantera")
    End Sub
    Private Sub CargarMonedas()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarMonedas
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraCombo(cmbMoneda, Ls_Entrega, "codmoneda", "moneda")
        cmbMoneda.Value = "01"
    End Sub

    Private Sub CargarBancos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarBancos
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraCombo(cmbbanco, Ls_Entrega, "codbanco", "banco")
    End Sub

    Private Sub CargarTrabajadoresxCodigo(ByVal codTrabajador As String)
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.CodTrabajador = codTrabajador
        Entidad.MyLista = Negocio.NEntregas.ListarTrabajadorxCodigo(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
    End Sub

    Private Sub CargarAreaTrabajador(ByVal codTrabajador As String)
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.CodTrabajador = codTrabajador
        Entidad.MyLista = Negocio.NEntregas.ListarAreaTrabajador(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Validacion Then
            If Entidad.MyLista.Ls_Entrega.Count > 0 Then
                cmbArea.Value = Entidad.MyLista.Ls_Entrega.Item(0).codArea
                JefeArea()
                cmbArea.ReadOnly = True
                txtMotivo.ReadOnly = False
                txtMotivo.Focus()
            Else
                txtJefeArea.Clear()
                cmbArea.ReadOnly = False
                cmbArea.Focus()
            End If
        End If
    End Sub

#End Region

#Region "Procedimientos Publicos"

    Public Sub Nuevo()
        Ope = 1
        estado = "PENDIENTE"
        nroSolicitud = String.Empty
        lblnSolicitud.Visible = Boolean.FalseString
        flgaprobada = 0
        Call LimpiarDatos()
        lblestado.Visible = False
        Call HabilitarControles(True)
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        Dim fecha1 As Date = dtFechaSalida.Value
        Dim fecha2 As Date = dtFechaRetorno.Value
        calculoDias(fecha1, fecha2)
        Me.TxtCodigoTrabajador.Focus()
        chkAprobar.Checked = Boolean.FalseString
        chkAprobar.Visible = Boolean.FalseString
        chkdescri1.Enabled = False : chkdescri2.Enabled = False : chkdescri3.Enabled = False : chkdescri4.Enabled = False : chkdescri5.Enabled = False : chkdescri6.Enabled = False : chkdescri7.Enabled = False
    End Sub
    Private Sub LimpiarDatos()
        Try
            '----------------------------------------------------
            'HVilela 19/02/25
            Me.chk_TarjetaConsumo.Checked = False
            Me.txt_nro_tarjeta.Text = ""
            '----------------------------------------------------
            Me.TxtCodigoTrabajador.Clear()
            Me.TxtNombresTrabajador.Clear()
            Me.txtJefeArea.Clear()
            Me.txtMotivo.Clear()
            Me.txtcodCantera.Clear()
            Me.txtCantera.Clear()
            Me.txtRegion.Clear()
            Me.txtmontopasajed.Clear()
            Me.txtdiapasaje.Clear()
            Me.txtmontopasaje.Clear()
            Me.txtmontoalimd.Clear()
            Me.txtdiaalim.Clear()
            Me.txtmontoalim.Clear()
            Me.txtmontohosp.Clear()
            Me.txtdiahosp.Clear()
            Me.txtmontohospd.Clear()
            Me.txtmontomovd.Clear()
            Me.txtdiamov.Clear()
            Me.txtmontomov.Clear()
            Me.txtmontocomb.Clear()
            Me.txtmontogastos.Clear()
            Me.txtmontoadqui.Clear()
            Me.txtmontocomp.Clear()
            Me.txtmontootros.Clear()
            '<JOSF 16/01/2023>
            Me.dtOtrosGastos.Clear()
            '</JOSF 16/01/2023>
            Me.txttotalviaticos.Clear()
            Me.txttotaltramites.Clear()
            Me.txttotal.Clear()
            Me.txtmontootros.Clear()
            Me.txtdescripcion.Clear()

            Me.txt_saldo_inicialtc.Text = 0.0
            'Me.txt_saldo_finaltc.Text = 0.0

            dtFechaSalida.Value = Now.Date
            dtFechaRetorno.Value = Now.Date
            cmbArea.Value = 0
            cmbCantera.Value = 0
            cmbbanco.Value = 0
            Me.txtdnibeneficiario.Clear()
            Me.txtbeneficiario.Clear()
            Me.txtctabenef.Clear()
            chkbeneficiario.Checked = False
            rdbDeposito.Checked = False
            rdbCheque.Checked = False
            rdbEfectivo.Checked = False
            VisualizarDatosDeposito(False)
            chkbeneficiario.Enabled = True
            rdbDeposito.Enabled = True
            rdbCheque.Enabled = True
            rdbEfectivo.Enabled = True
            cmbMoneda.Enabled = True
            chkdescri1.Checked = False
            chkdescri2.Checked = False
            chkdescri3.Checked = False
            chkdescri4.Checked = False
            chkdescri5.Checked = False
            chkdescri6.Checked = False
            chkdescri7.Checked = False
            chkdescri1.Enabled = False : chkdescri2.Enabled = False : chkdescri3.Enabled = False : chkdescri4.Enabled = False : chkdescri5.Enabled = False : chkdescri6.Enabled = False : chkdescri7.Enabled = False
            codTrabajador = String.Empty
            nomTrabajador = String.Empty
            ctatrabajadorini = String.Empty
            bcotrabajadorini = String.Empty
            numeroTarjetaConsumo = String.Empty
            tipoTarjetaConsumo = String.Empty
            bancoTarjetaConsumo = String.Empty

            saliniTarjetaConsumo = 0.0
            montosolicitud = 0
            Ep1.Clear()
        Catch ex As Exception

        End Try
       
        'Ope = 0
    End Sub

    Private Sub HabilitarControles(ByVal D As Boolean)

        '----------------------------------------------------
        'HVilela 19/02/25
        Me.chk_TarjetaConsumo.Enabled = D
        Me.txt_nro_tarjeta.ReadOnly = D
        Me.txt_nro_tarjeta.InputMask = "####-####-####-####"
        Me.txt_nro_tarjeta.PromptChar = " "
        '----------------------------------------------------
        Me.TxtCodigoTrabajador.ReadOnly = Not D 'False
        Me.txtMotivo.ReadOnly = D
        Me.txtRegion.ReadOnly = D

        Me.txtmontopasajed.ReadOnly = D
        Me.txtmontopasaje.ReadOnly = D
        Me.txtmontoalimd.ReadOnly = D
        Me.txtmontohosp.ReadOnly = D
        Me.txtmontoalim.ReadOnly = D
        Me.txtmontohospd.ReadOnly = D
        Me.txtmontomovd.ReadOnly = D
        Me.txtmontomov.ReadOnly = D
        Me.txtmontocomb.ReadOnly = D
        Me.txtmontogastos.ReadOnly = D
        Me.txtmontoadqui.ReadOnly = D
        Me.txtmontocomp.ReadOnly = D
        Me.txtmontootros.ReadOnly = D


        Me.txtdiapasaje.ReadOnly = D
        Me.txtdiaalim.ReadOnly = D
        Me.txtdiahosp.ReadOnly = D
        Me.txtdiamov.ReadOnly = D
        Me.cmbArea.ReadOnly = D
        Me.cmbCantera.ReadOnly = D
        Me.dtFechaSalida.ReadOnly = D
        Me.dtFechaRetorno.ReadOnly = D
        Me.txtdescripcion.ReadOnly = D
        Me.txtdnibeneficiario.ReadOnly = D
        Me.txtbeneficiario.ReadOnly = D
        Me.cmbbanco.ReadOnly = True
        Me.txtctabenef.ReadOnly = True
        'If chkbeneficiario.Checked = True Then
        '    Me.txtdnibeneficiario.ReadOnly = False
        '    Me.txtbeneficiario.ReadOnly = False
        'Else
        '    Me.txtdnibeneficiario.ReadOnly = True
        '    Me.txtbeneficiario.ReadOnly = True
        'End If

        Me.TxtCodigoTrabajador.Focus()
    End Sub
#End Region

    Private Sub GridSolicitudes_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles GridSolicitudes.DragDrop

    End Sub

    Private Sub GridSolicitudes_FilterRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.FilterRowEventArgs) Handles GridSolicitudes.FilterRow
        Dim fechaactual As Date = Now.Date
        Dim fechaaprobacion As Date = CDate(e.Row.Cells("Fecha").Value()).ToString("dd/MM/yyyy")
        Dim diferencia As Int32 = 0
        diferencia = DateDiff(DateInterval.Day, fechaaprobacion, fechaactual)
        If e.Row.Cells("Estado").Value.ToString.Trim = "APROBADO" Then
            If diferencia > 2 Then e.Row.Appearance.BackColor = Color.Red
        End If
    End Sub

    Private Sub GridSolicitudes_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridSolicitudes.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "NumSolicitud" OrElse uColumn.Key = "Motivo" OrElse uColumn.Key = "FechaIngreso" OrElse _
                    uColumn.Key = "Estado" OrElse uColumn.Key = "NomTrabajador" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "moneda") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub TxtCodigoTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoTrabajador.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If TxtCodigoTrabajador.Text.ToString.Trim = "" Then
            TxtCodigoTrabajador.Focus()
            Exit Sub
        End If

        CargarTrabajadoresxCodigo(Me.TxtCodigoTrabajador.Text)

        If lResult.Ls_Entrega.Count > 0 Then

            Me.TxtNombresTrabajador.Text = lResult.Ls_Entrega.Item(0).NomTrabajador
            Me.txtbeneficiario.Text = lResult.Ls_Entrega.Item(0).NomTrabajador

            Me.txt_nro_tarjeta.Text = lResult.Ls_Entrega.Item(0).nro_tarjeta
            Me.txt_saldo_inicialtc.Text = CDbl(lResult.Ls_Entrega.Item(0).saldo_ini).ToString("#####0.00")
            bcotrabajador = lResult.Ls_Entrega.Item(0).bancobeneficiario.ToString.Trim
            ctatrabajador = lResult.Ls_Entrega.Item(0).ctabeneficiario.ToString.Trim

            Me.txtbeneficiario.Text = lResult.Ls_Entrega.Item(0).NomTrabajador
            Me.txtdnibeneficiario.Text = String.Empty
            chkbeneficiario.Checked = False
            Me.txtdnibeneficiario.ReadOnly = True
            Me.txtbeneficiario.ReadOnly = True
            CargarAreaTrabajador(Me.TxtCodigoTrabajador.Text)
            rdbDeposito_CheckedChanged(Nothing, Nothing)
            Me.txtMotivo.ReadOnly = False
            Me.txtRegion.ReadOnly = False
            Me.txtmontopasajed.ReadOnly = False
            Me.txtdiapasaje.ReadOnly = False
            Me.txtmontopasaje.ReadOnly = False
            Me.txtmontoalimd.ReadOnly = False
            Me.txtdiaalim.ReadOnly = False
            Me.txtmontoalim.ReadOnly = False
            Me.txtmontohosp.ReadOnly = False
            Me.txtdiahosp.ReadOnly = False
            Me.txtmontohospd.ReadOnly = False
            Me.txtmontomovd.ReadOnly = False
            Me.txtdiamov.ReadOnly = False
            Me.txtmontomov.ReadOnly = False
            Me.txtmontocomb.ReadOnly = False
            Me.txtmontogastos.ReadOnly = False
            Me.txtmontoadqui.ReadOnly = False
            Me.txtmontocomp.ReadOnly = False
            Me.txtmontootros.ReadOnly = False
            Me.cmbArea.ReadOnly = False
            Me.cmbCantera.ReadOnly = False
            Me.dtFechaSalida.ReadOnly = False
            Me.dtFechaRetorno.ReadOnly = False
            Me.txtmontootros.ReadOnly = False
        Else
            MsgBox("Código de trabajador no existe", MsgBoxStyle.Exclamation, msgComacsa)
            TxtCodigoTrabajador.Clear()
            TxtNombresTrabajador.Clear()
            TxtCodigoTrabajador.Focus()
        End If

    End Sub

    Private Sub cmbArea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbArea.InitializeLayout
        With cmbArea.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("Area").Width = 300 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Area") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbArea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbArea.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If cmbArea.Value Is Nothing Then Return
        JefeArea()
        txtMotivo.ReadOnly = False
        txtMotivo.Focus()
    End Sub

    Private Sub txtMotivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMotivo.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If txtMotivo.Text.ToString.Trim = "" Then
            txtMotivo.Focus()
            Exit Sub
        End If
        dtFechaSalida.ReadOnly = False
        dtFechaRetorno.ReadOnly = False
        dtFechaSalida.Focus()
    End Sub

    Private Sub dtFechaSalida_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFechaSalida.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        Dim fecha1 As Date = dtFechaSalida.Value
        Dim fecha2 As Date = dtFechaRetorno.Value
        Dim fechaActual As Date = Now.Date
        If fecha1.CompareTo(fechaActual) < 0 Then
            MsgBox("Fecha de salida debe ser mayor a fecha actual", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If
        calculoDias(fecha1, fecha2)
        dtFechaRetorno.ReadOnly = False
        dtFechaRetorno.Focus()
    End Sub

    Private Sub dtFechaRetorno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtFechaRetorno.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        Dim fecha1 As Date = dtFechaSalida.Value
        Dim fecha2 As Date = dtFechaRetorno.Value
        If fecha2.CompareTo(fecha1) < 0 Then
            MsgBox("Fecha de retorno debe ser mayor a fecha de salida", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If
        calculoDias(fecha1, fecha2)
        cmbCantera.ReadOnly = False
        txtcodCantera.Focus()
    End Sub

    Private Sub cmbCantera_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCantera.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        txtCantera.Text = cmbCantera.Text.ToString
        txtRegion.ReadOnly = False
        txtmontopasajed.ReadOnly = False
        txtmontopasajed.Focus()
    End Sub

    Private Sub txtRegion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRegion.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return

        Dim fecha1 As Date = dtFechaSalida.Value
        Dim fecha2 As Date = dtFechaRetorno.Value

        If fecha2.CompareTo(fecha1) < 0 Then
            MsgBox("Fecha de retorno debe ser mayor a fecha de salida", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If
        dias = (fecha2 - fecha1).TotalDays
        txtdiapasaje.Text = 2
        txtdiaalim.Text = dias
        txtdiahosp.Text = dias
        txtdiamov.Text = dias
        txtmontopasajed.ReadOnly = False
        txtmontopasaje.ReadOnly = False
        txtmontopasajed.Focus()
    End Sub

    Private Sub txtmontopasajed_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontopasajed.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If txtmontopasajed.Text.ToString.Trim = "" Then txtmontopasajed.Text = 0
        txtdiapasaje.ReadOnly = False
        txtdiapasaje.Focus()
    End Sub

    Private Sub txtdiapasaje_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdiapasaje.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If CDbl(txtdiapasaje.Text) > 2 Then MsgBox("El límite de dias es 2", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If txtmontopasajed.Text.ToString.Trim = "" Then MensajeAlerta(txtmontopasajed) : Return
        calculapasaje()
        'If txtdiapasaje.Text.ToString.Trim = "" Then Return
        'Dim montopasajedia As Double = txtmontopasajed.Text
        'Dim diaxpasaje As Double = txtdiapasaje.Text
        'txtmontopasaje.Text = (montopasajedia * diaxpasaje).ToString("#####0.00")
        'txtmontoalimd.ReadOnly = False
        'txtmontoalim.ReadOnly = False
        txtmontoalimd.Focus()
        'SubtotalViatico("01", montopasajedia, diaxpasaje, CDbl(txtmontopasaje.Text))
    End Sub
    Sub calculapasaje()
        If txtmontopasajed.Text.ToString.Trim = "" Then Return
        If txtdiapasaje.Text.ToString.Trim = "" Then Return
        Dim montopasajedia As Double = txtmontopasajed.Text
        Dim diaxpasaje As Double = txtdiapasaje.Text
        txtmontopasaje.Text = (montopasajedia * diaxpasaje).ToString("#####0.00")
        txtmontoalimd.ReadOnly = False
        txtmontoalim.ReadOnly = False
        'txtmontoalimd.Focus()
        SubtotalViatico("01", montopasajedia, diaxpasaje, CDbl(txtmontopasaje.Text))
    End Sub
    Sub MensajeAlerta(ByVal txt As Infragistics.Win.UltraWinEditors.UltraTextEditor)
        MsgBox("Ingrese Monto diario", MsgBoxStyle.Exclamation, msgComacsa)
        txt.Focus()
    End Sub

    Private Sub txtmontopasaje_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontopasaje.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If txtmontopasaje.Text.ToString.Trim = "" Then Return
        txtmontopasajed.Clear()
        txtdiapasaje.Clear()
        txtmontopasaje.Text = CDbl(txtmontopasaje.Text).ToString("#####0.00")
        txtmontoalim.ReadOnly = False
        txtmontoalimd.ReadOnly = False
        txtmontoalimd.Focus()
        SubtotalViatico("01", 0, 0, CDbl(txtmontopasaje.Text))
    End Sub



    Private Sub txtmontoalimd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontoalimd.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If txtmontoalimd.Text.ToString.Trim = "" Then txtmontoalimd.Text = 0
        txtdiaalim.ReadOnly = False
        txtdiaalim.Focus()
    End Sub

    Private Sub txtdiaalim_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdiaalim.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If CDbl(txtdiaalim.Text) > dias Then MsgBox("El límite de dias es " & dias.ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return
        If txtmontoalimd.Text.ToString.Trim = "" Then MensajeAlerta(txtmontoalimd) : Return
        calculalimento()
        txtmontohospd.Focus()
    End Sub
    Sub calculalimento()
        If txtmontoalimd.Text.ToString.Trim = "" Then Return
        If txtdiaalim.Text.ToString.Trim = "" Then Return
        Dim montoalimdia As Double = txtmontoalimd.Text
        Dim diaxalimento As Double = txtdiaalim.Text
        txtmontoalim.Text = (montoalimdia * diaxalimento).ToString("#####0.00")
        txtmontohosp.ReadOnly = False
        txtmontohospd.ReadOnly = False
        SubtotalViatico("02", montoalimdia, diaxalimento, CDbl(txtmontoalim.Text))
    End Sub
    Private Sub txtmontoalim_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontoalim.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If txtmontoalim.Text.ToString.Trim = "" Then Return
        txtmontoalimd.Clear()
        txtdiaalim.Clear()
        txtmontoalim.Text = CDbl(txtmontoalim.Text).ToString("#####0.00")
        txtmontohosp.ReadOnly = False
        txtmontohospd.ReadOnly = False
        txtmontohospd.Focus()
        SubtotalViatico("02", 0, 0, CDbl(txtmontoalim.Text))
    End Sub

    Private Sub txtmontohospd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontohospd.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If txtmontohospd.Text.ToString.Trim = "" Then txtmontohospd.Text = 0
        txtdiahosp.ReadOnly = False
        txtdiahosp.Focus()
    End Sub

    Private Sub txtdiahosp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdiahosp.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If CDbl(txtdiahosp.Text) > dias Then MsgBox("El límite de dias es " & dias.ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return
        If txtmontohospd.Text.ToString.Trim = "" Then MensajeAlerta(txtmontohospd) : Return
        calculahospedaje()
        'If txtdiahosp.Text.ToString.Trim = "" Then Return
        'Dim montohospdia As Double = txtmontohospd.Text
        'Dim diaxhospedaje As Double = txtdiahosp.Text
        'txtmontohosp.Text = (montohospdia * diaxhospedaje).ToString("#####0.00")
        'txtmontomov.ReadOnly = False
        'txtmontomovd.ReadOnly = False
        txtmontomovd.Focus()
        'SubtotalViatico("03", montohospdia, diaxhospedaje, CDbl(txtmontohosp.Text))
    End Sub
    Sub calculahospedaje()
        If txtmontohospd.Text.ToString.Trim = "" Then Return
        If txtdiahosp.Text.ToString.Trim = "" Then Return
        Dim montohospdia As Double = txtmontohospd.Text
        Dim diaxhospedaje As Double = txtdiahosp.Text
        txtmontohosp.Text = (montohospdia * diaxhospedaje).ToString("#####0.00")
        txtmontomov.ReadOnly = False
        txtmontomovd.ReadOnly = False
        'txtmontomovd.Focus()
        SubtotalViatico("03", montohospdia, diaxhospedaje, CDbl(txtmontohosp.Text))
    End Sub
    Private Sub txtmontohosp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontohosp.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If txtmontohosp.Text.ToString.Trim = "" Then Return
        txtmontohospd.Clear()
        txtdiahosp.Clear()
        txtmontohosp.Text = CDbl(txtmontohosp.Text).ToString("#####0.00")
        txtmontomov.ReadOnly = False
        txtmontomovd.ReadOnly = False
        txtmontomovd.Focus()
        SubtotalViatico("03", 0, 0, CDbl(txtmontohosp.Text))
    End Sub

    Private Sub txtmontomovd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontomovd.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If txtmontomovd.Text.ToString.Trim = "" Then txtmontomovd.Text = 0
        txtdiamov.ReadOnly = False
        txtdiamov.Focus()
    End Sub

    Private Sub txtdiamov_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdiamov.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If CDbl(txtdiamov.Text) > dias Then MsgBox("El límite de dias es " & dias.ToString, MsgBoxStyle.Exclamation, msgComacsa) : Return
        If txtmontomovd.Text.ToString.Trim = "" Then MensajeAlerta(txtmontomovd) : Return
        calculamovilidad()
        txtmontocomb.Focus()
    End Sub
    Sub calculamovilidad()
        If txtmontomovd.Text.ToString.Trim = "" Then Return
        If txtdiamov.Text.ToString.Trim = "" Then Return
        Dim montomovdia As Double = txtmontomovd.Text
        Dim diaxmovilidad As Double = txtdiamov.Text
        txtmontomov.Text = (montomovdia * diaxmovilidad).ToString("#####0.00")
        txtmontocomb.ReadOnly = False
        txtmontogastos.ReadOnly = False
        txtmontoadqui.ReadOnly = False
        txtmontocomp.ReadOnly = False
        txtmontootros.ReadOnly = False
        SubtotalViatico("04", montomovdia, diaxmovilidad, CDbl(txtmontomov.Text))
    End Sub

    Private Sub txtmontomov_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmontomov.GotFocus
        If sender.readonly = True Then Return
        If txtmontomov.Text.ToString.Trim = "" Then Return
        txtmontomovd.Clear()
        txtdiamov.Clear()
        txtmontomov.Text = CDbl(txtmontomov.Text).ToString("#####0.00")
        txtmontocomb.ReadOnly = False
        txtmontogastos.ReadOnly = False
        txtmontoadqui.ReadOnly = False
        txtmontocomp.ReadOnly = False
        txtmontootros.ReadOnly = False
        txtmontocomb.Focus()
        SubtotalViatico("04", 0, 0, CDbl(txtmontomov.Text))
    End Sub
    Private Sub txtmontomov_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontomov.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If txtmontomov.Text.ToString.Trim = "" Then Return
        txtmontomovd.Clear()
        txtdiamov.Clear()
        txtmontomov.Text = CDbl(txtmontomov.Text).ToString("#####0.00")
        txtmontocomb.ReadOnly = False
        txtmontogastos.ReadOnly = False
        txtmontoadqui.ReadOnly = False
        txtmontocomp.ReadOnly = False
        txtmontootros.ReadOnly = False
        txtmontocomb.Focus()
        SubtotalViatico("04", 0, 0, CDbl(txtmontomov.Text))
    End Sub

    Sub SubtotalViatico(ByVal codConcepto As String, ByVal montParcial As Double, ByVal dias As Int32, ByVal montTotal As Double)
        Dim totalpasajev As Double = 0
        Dim totalalimv As Double = 0
        Dim totalhospv As Double = 0
        Dim totalmovv As Double = 0
        Dim subtotalviatico As Double = 0
        If txtmontopasaje.Text.Trim = "" Then totalpasajev = 0 Else totalpasajev = txtmontopasaje.Text
        If txtmontoalim.Text.Trim = "" Then totalalimv = 0 Else totalalimv = txtmontoalim.Text
        If txtmontohosp.Text.Trim = "" Then totalhospv = 0 Else totalhospv = txtmontohosp.Text
        If txtmontomov.Text.Trim = "" Then totalmovv = 0 Else totalmovv = txtmontomov.Text
        subtotalviatico = totalpasajev + totalalimv + totalhospv + totalmovv
        txttotalviaticos.Text = subtotalviatico.ToString("#####0.00")
        seteoEntidades(codConcepto, montParcial, dias, montTotal)
        total()
    End Sub

    Private Sub txtmontocomb_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontocomb.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If Not (txtmontocomb.Text = "") Then txtmontocomb.Text = CDbl(txtmontocomb.Text).ToString("#####0.00") : SubtotalTramites("05", 0, 0, CDbl(txtmontocomb.Text))
        txtmontogastos.Focus()
    End Sub

    Private Sub txtmontogastos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontogastos.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If Not (txtmontogastos.Text = "") Then txtmontogastos.Text = CDbl(txtmontogastos.Text).ToString("#####0.00") : SubtotalTramites("06", 0, 0, CDbl(txtmontogastos.Text))
        txtmontoadqui.Focus()
    End Sub

    Private Sub txtmontoadqui_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontoadqui.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If Not (txtmontoadqui.Text = "") Then txtmontoadqui.Text = CDbl(txtmontoadqui.Text).ToString("#####0.00") : SubtotalTramites("07", 0, 0, CDbl(txtmontoadqui.Text))
        txtmontocomp.Focus()
    End Sub

    Private Sub txtmontocomp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontocomp.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If Not (txtmontocomp.Text = "") Then txtmontocomp.Text = CDbl(txtmontocomp.Text).ToString("#####0.00") : SubtotalTramites("08", 0, 0, CDbl(txtmontocomp.Text))
        txtmontootros.Focus()
    End Sub
    Public dtOtrosGastos As New DataTable
    Public otrosgastos As Double = 0

    Private Sub txtmontootros_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontootros.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If Not (txtmontootros.Text = "") Then txtmontootros.Text = CDbl(txtmontootros.Text).ToString("#####0.00") Else Return
        If CDbl(txtmontootros.Text > 0) Then
            Dim frm As New FrmOtrosGastos
            frm.solicitud = NumSolicitud
            frm.ShowDialog()
            dtOtrosGastos = frm.gridDetalle.DataSource
            OtrosGastosCalculo()
            '<JOSF 16/01/2023>
            SubtotalTramitesCarga()
            '</JOSF 16/01/2023>
            chkdescri1.Enabled = True : chkdescri2.Enabled = True : chkdescri3.Enabled = True : chkdescri4.Enabled = True : chkdescri5.Enabled = True : chkdescri6.Enabled = True : chkdescri7.Enabled = True
        Else
            chkdescri1.Enabled = False : chkdescri2.Enabled = False : chkdescri3.Enabled = False : chkdescri4.Enabled = False : chkdescri5.Enabled = False : chkdescri6.Enabled = False : chkdescri7.Enabled = False
        End If
    End Sub

    Sub OtrosGastosCalculo()
        otrosgastos = 0
        For i As Int32 = 0 To dtOtrosGastos.Rows.Count - 1
            otrosgastos = otrosgastos + dtOtrosGastos.Rows(i)("importe")
        Next
        txtmontootros.Text = otrosgastos.ToString("#0.00")
    End Sub

    Sub SubtotalTramites(ByVal codConcepto As String, ByVal montParcial As Double, ByVal dias As Int32, ByVal montTotal As Double)
        Dim totalcombustible As Double = 0
        Dim totalgastos As Double = 0
        Dim totaladquisicion As Double = 0
        Dim totalcompras As Double = 0
        Dim totalotros As Double = 0
        Dim subtotaltramites As Double = 0
        If txtmontocomb.Text.Trim = "" Then totalcombustible = 0 Else totalcombustible = txtmontocomb.Text
        If txtmontogastos.Text.Trim = "" Then totalgastos = 0 Else totalgastos = txtmontogastos.Text
        If txtmontoadqui.Text.Trim = "" Then totaladquisicion = 0 Else totaladquisicion = txtmontoadqui.Text
        If txtmontocomp.Text.Trim = "" Then totalcompras = 0 Else totalcompras = txtmontocomp.Text
        If txtmontootros.Text.Trim = "" Then totalotros = 0 : txtmontootros.Text = "0.00" Else totalotros = txtmontootros.Text
        subtotaltramites = totalcombustible + totalgastos + totaladquisicion + totalcompras + totalotros
        txttotaltramites.Text = subtotaltramites.ToString("#####0.00")
        'seteoEntidades(codConcepto, montParcial, dias, montTotal)
        If txtmontootros.Text > 0 Then
            OtrosGastosCalculo()
            For i As Int32 = 0 To dtOtrosGastos.Rows.Count - 1
                seteoEntidades(dtOtrosGastos.Rows(i)("codConcepto"), 0, 0, dtOtrosGastos.Rows(i)("importe"))
                'otrosgastos = otrosgastos + dtOtrosGastos.Rows(i)("importe")
            Next
        End If
        total()
    End Sub
    Dim arrayCodigos As New ArrayList
    Dim arrayMontos As New ArrayList

    Sub total()
        Dim subtotalviatico As Double = 0
        Dim subtotaltramites As Double = 0
        Dim totalgeneral As Double = 0
        'Dim val_saldo_finaltc As Decimal

        If txttotalviaticos.Text = "" Then txttotalviaticos.Text = 0
        subtotalviatico = CDbl(txttotalviaticos.Text)
        If txttotaltramites.Text.Trim = "" Then subtotaltramites = 0 Else subtotaltramites = CDbl(txttotaltramites.Text)
        totalgeneral = subtotalviatico + subtotaltramites
        txttotal.Text = CDbl(totalgeneral).ToString("#####0.00")
        If chk_TarjetaConsumo.Checked = True Then

            txttotal.Text = CDbl(txt_saldo_inicialtc.Text).ToString("#####0.00")

            txttotal.ReadOnly = False

            'val_saldo_finaltc = CDbl(Me.txt_saldo_inicialtc.Text - Me.txttotal.Text).ToString("#####0.00")
            'Me.txt_saldo_finaltc.Text = val_saldo_finaltc.ToString("N2")

            'If val_saldo_finaltc < 0 Then
            '    txt_saldo_finaltc.ForeColor = Color.Red
            'Else
            '    txt_saldo_finaltc.ForeColor = Color.Black
            'End If

            'If Me.txt_saldo_finaltc.Text < 0.0 Then
            '    MsgBox("Ya NO tiene saldo en la Tarjeta de Consumo", MsgBoxStyle.Exclamation, msgComacsa) : Return
            'End If

        End If

    End Sub

    Sub seteoEntidades(ByVal codConcepto As String, ByVal montParcial As Double, ByVal dias As Int32, ByVal montTotal As Double)
        Try
            If Ls_EntregaDetalle Is Nothing Then Ls_EntregaDetalle = New List(Of ETEntregas)
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.codConcepto = codConcepto
            Entidad.Entregas.totaldias = dias
            Entidad.Entregas.montoParcial = montParcial
            Entidad.Entregas.montoTotalParcial = montTotal
            Entidad.Entregas.Descripcion = txtdescripcion.Text.ToString
            Dim Lista = Ls_EntregaDetalle.Where(Function(m) m.codConcepto = codConcepto).FirstOrDefault
            If Not Lista Is Nothing Then Ls_EntregaDetalle.Remove(Ls_EntregaDetalle.Where(Function(m) m.codConcepto = codConcepto).FirstOrDefault)
            Ls_EntregaDetalle.Add(Entidad.Entregas)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtmontopasajed_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmontopasajed.KeyPress, txtdiapasaje.KeyPress, txtmontopasaje.KeyPress, txtmontoalimd.KeyPress, txtdiaalim.KeyPress, txtmontoalim.KeyPress, txtmontohospd.KeyPress, txtdiahosp.KeyPress, txtmontohosp.KeyPress, txtmontomovd.KeyPress, txtdiamov.KeyPress, txtmontomov.KeyPress, txtmontocomb.KeyPress, txtmontogastos.KeyPress, txtmontoadqui.KeyPress, txtmontocomp.KeyPress, txtmontootros.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub cmbCantera_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbCantera.InitializeLayout
        With cmbCantera.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("Cantera").Width = sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Cantera") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Public Sub Grabar()

        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return

        For Each txt As Control In Tabla1.Controls
            If (TypeOf txt Is Infragistics.Win.UltraWinEditors.UltraTextEditor) Then
                If txt.Text = "" Then txt.Text = "0"
            End If
        Next

        If flgaprobada = 1 And esAprobador = 0 Then MsgBox("La solicitud se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If chk_TarjetaConsumo.Checked = False Then

            Dim total_final As Decimal = txttotal.Text
            Dim total_fintc As Decimal = txt_saldo_inicialtc.Text


            If total_final > total_fintc Then
                MsgBox("El importe de la solicitud es mayor al limite de la Tarjeta", MsgBoxStyle.Exclamation, msgComacsa) : Return
            End If


            If Not ValidaLineacredito(Me.TxtCodigoTrabajador.Text.ToString.Trim) Then
                MsgBox("No tiene asignado una línea de crédito", MsgBoxStyle.Exclamation, msgComacsa) : Return
            End If

            If estado = "PENDIENTE" And Ope = 1 Then
                If Not ValidaExcesocredito(Me.TxtCodigoTrabajador.Text.ToString.Trim) Then
                    Return
                End If
            End If

        End If

        If txtmontopasaje.Text.Trim = "" Then txtmontopasaje.Text = 0
        If txtmontoalim.Text.Trim = "" Then txtmontoalim.Text = 0
        If txtmontohosp.Text.Trim = "" Then txtmontohosp.Text = 0
        If txtmontomov.Text.Trim = "" Then txtmontomov.Text = 0
        If txtmontocomb.Text.Trim = "" Then txtmontocomb.Text = 0
        If txtmontogastos.Text.Trim = "" Then txtmontogastos.Text = 0
        If txtmontoadqui.Text.Trim = "" Then txtmontoadqui.Text = 0
        If txtmontocomp.Text.Trim = "" Then txtmontocomp.Text = 0
        If txtmontootros.Text.Trim = "" Then txtmontootros.Text = 0

        If chk_TarjetaConsumo.Checked = False Then

            If CDbl(txtmontootros.Text > 0) Then
                If chkdescri1.Checked = False And chkdescri2.Checked = False And chkdescri3.Checked = False And chkdescri4.Checked = False And chkdescri5.Checked = False And chkdescri6.Checked = False And chkdescri7.Checked = False Then
                    MsgBox("Debe selecionar mínimo un concepto de otros gastos", MsgBoxStyle.Exclamation, msgComacsa) : Return
                End If
            End If

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

        End If


        Dim fechaSalida As Date = dtFechaSalida.Value
        Dim fechaRetorno As Date = dtFechaRetorno.Value
        Dim fechaActual As Date = Now.Date

        If fechaSalida.CompareTo(fechaActual) < 0 And Ope = 1 Then
            MsgBox("Fecha de salida debe ser mayor a fecha actual", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If

        If fechaRetorno.CompareTo(fechaSalida) < 0 Then
            MsgBox("Fecha de retorno debe ser mayor a fecha de salida", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If

        Dim ayo_actual As Integer
        Dim ayo_solicitud As Integer
        ayo_actual = Year(Now.Date)
        ayo_solicitud = Year(dtFechaSalida.Value)

        If ayo_solicitud > ayo_actual Then
            MsgBox("No puede solicitar dinero para el siguiente año", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If

        Dim dtUsuarioUnico As New DataTable
        dtUsuarioUnico = Negocio.NEntregas.VerificaUserUnico(User_Sistema, TxtCodigoTrabajador.Text)
        If dtUsuarioUnico.Rows.Count > 0 Then
            If dtUsuarioUnico.Rows(0)(0) <> "OK" Then
                MsgBox(dtUsuarioUnico.Rows(0)(0), MsgBoxStyle.Information, msgComacsa)
                Exit Sub
            End If
        Else
            MsgBox("Error al válidar usuario", MsgBoxStyle.Information, msgComacsa)
            Exit Sub
        End If



        Dim combustible As Double = txtmontocomb.Text
        Dim compras As Double = txtmontocomp.Text
        Dim adquisicion As Double = txtmontoadqui.Text
        Dim otros_gastos As Double = txtmontootros.Text

        Dim combustible_lm As Double = 0
        Dim compras_lm As Double = 0
        Dim adquisicion_lm As Double = 0
        Dim otros_gastos_lm As Double = 0

        If chk_TarjetaConsumo.Checked = False Then
            Dim dtLimiteTramites As New DataTable
            dtLimiteTramites = Negocio.NEntregas.LimiteTramites(TxtCodigoTrabajador.Text)

            If dtLimiteTramites.Rows.Count > 0 Then
                If dtLimiteTramites.Rows(0)(0).ToString.Trim.ToUpper <> "OK" Then
                    combustible_lm = dtLimiteTramites.Rows(0)(2)
                    compras_lm = dtLimiteTramites.Rows(1)(2)
                    adquisicion_lm = dtLimiteTramites.Rows(2)(2)
                    otros_gastos_lm = dtLimiteTramites.Rows(3)(2)
                    If combustible > combustible_lm Then
                        MsgBox("Todo importe de combustible mayor a S/. " & combustible_lm.ToString("#0.00") & " deberá ser consultado con el área de administración y  canalizado a través del área de compras", MsgBoxStyle.Exclamation, msgComacsa)
                        Exit Sub
                    End If
                    If compras > compras_lm Then
                        MsgBox("Todo importe de compra de bienes mayor a S/. " & compras_lm.ToString("#0.00") & " deberá ser consultado con el área de administración y  canalizado a través del área de compras", MsgBoxStyle.Exclamation, msgComacsa)
                        Exit Sub
                    End If
                    If adquisicion > adquisicion_lm Then
                        MsgBox("Todo importe de adquisicion de servicios mayor a S/. " & adquisicion_lm.ToString("#0.00") & " deberá ser consultado con el área de administración y  canalizado a través del área de compras", MsgBoxStyle.Exclamation, msgComacsa)
                        Exit Sub
                    End If
                    If otros_gastos > otros_gastos_lm Then
                        MsgBox("No puede ingresar importe mayor a S/. " & otros_gastos_lm.ToString("#0.00") & " por el concepto de otros gastos menores", MsgBoxStyle.Exclamation, msgComacsa)
                        Exit Sub
                    End If
                End If
            End If

        End If


        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)



        If chk_TarjetaConsumo.Checked = False Then
            seteoEntidadDetalle()
        End If

        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas

        If chk_TarjetaConsumo.Checked = False Then
            If Not (txtmontootros.Text = "") Then txtmontootros.Text = CDbl(txtmontootros.Text).ToString("#####0.00") : SubtotalTramites("09", 0, 0, CDbl(txtmontootros.Text))
        End If

        Entidad.Entregas.TipoOperacion = Ope
        Entidad.Entregas.NumSolicitud = NumSolicitud
        Entidad.Entregas.CodTrabajador = IIf(TxtCodigoTrabajador.Value Is Nothing, String.Empty, TxtCodigoTrabajador.Value)
        Entidad.Entregas.codArea = IIf(cmbArea.Value Is Nothing, String.Empty, cmbArea.Value)
        Entidad.Entregas.Motivo = IIf(txtMotivo.Value Is Nothing, String.Empty, txtMotivo.Value)
        Entidad.Entregas.fechaSalida = IIf(dtFechaSalida.Value Is Nothing, String.Empty, dtFechaSalida.Value)
        Entidad.Entregas.fechaRetorno = IIf(dtFechaRetorno.Value Is Nothing, String.Empty, dtFechaRetorno.Value)
        Entidad.Entregas.codCantera = IIf(txtcodCantera.Value Is Nothing, String.Empty, txtcodCantera.Value)
        Entidad.Entregas.Region = IIf(txtRegion.Value Is Nothing, String.Empty, txtRegion.Value)
        Entidad.Entregas.montoTotal = IIf(txttotal.Value Is Nothing, String.Empty, txttotal.Value)

        If chkAprobar.Checked Then
            Entidad.Entregas.idEstado = 2
        Else
            Entidad.Entregas.idEstado = 1
        End If

        If rdbDeposito.Checked = True Then
            Entidad.Entregas.tipodepobeneficiario = "1"
        ElseIf rdbCheque.Checked = True Then
            Entidad.Entregas.tipodepobeneficiario = "2"
        ElseIf rdbEfectivo.Checked = True Then
            Entidad.Entregas.tipodepobeneficiario = "3"
        End If

        If chkbeneficiario.Checked = True Then
            Entidad.Entregas.flgbeneficiario = "1"
        Else
            Entidad.Entregas.flgbeneficiario = "0"
        End If
        Entidad.Entregas.moneda = IIf(cmbMoneda.Value Is Nothing, String.Empty, cmbMoneda.Text.ToString.Trim.Substring(0, 1))
        Entidad.Entregas.dnibeneficiario = IIf(txtdnibeneficiario.Value Is Nothing, String.Empty, txtdnibeneficiario.Value)
        Entidad.Entregas.beneficiario = IIf(txtbeneficiario.Value Is Nothing, String.Empty, txtbeneficiario.Value)
        Entidad.Entregas.bancobeneficiario = IIf(cmbbanco.Value Is Nothing, String.Empty, cmbbanco.Value)
        Entidad.Entregas.ctabeneficiario = IIf(txtctabenef.Value Is Nothing, String.Empty, txtctabenef.Value)

        Entidad.Entregas.Usuario = User_Sistema
        Entidad.Entregas.Descripcion = txtdescripcion.Text.ToString
        '------------
        'Nuevo concepto que se esta implementando en el tema de tarjeta de consumo 
        ' hvilela - tarjeta de consumo 
        '------------
        Entidad.Entregas.idTarjetaConsumo = 0
        Entidad.Entregas.idTipoTarjetaConsumo = 0

        If chk_TarjetaConsumo.Checked = True Then
            Entidad.Entregas.idTarjetaConsumo = Integer.Parse(txt_idTarjetaConsumo.Text)
            Entidad.Entregas.idTipoTarjetaConsumo = IIf(rb_tconsumo1.Checked, 1, IIf(rb_tconsumo2.Checked, 2, 0))
        End If

        Dim ls_Solicitud = Ls_Entrega.Where(Function(x) x.codConcepto.ToString.Trim <> "").FirstOrDefault

        'Evento MantenimientoEntregas
        Entidad.Entregas = Negocio.NEntregas.MantenimientoEntregas(Entidad.Entregas, Ls_Entrega, Ls_EntregaDetalle)

        If Entidad.Entregas.Validacion Then
            Call Nuevo()
            Call Inicio()
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        CargarTrabajadoresxCodigo(Me.TxtCodigoTrabajador.Text)
        If Not Ls_Entrega.Count > 0 Then
            'MsgBox("Código de trabajador no existe", MsgBoxStyle.Exclamation, msgComacsa)
            TxtCodigoTrabajador.Clear()
            TxtNombresTrabajador.Clear()
            TxtCodigoTrabajador.Focus()
            'lResult = Boolean.FalseString
        End If
        If String.IsNullOrEmpty(TxtCodigoTrabajador.Value) Then
            Ep1.SetError(TxtCodigoTrabajador, "Ingrese código de trabajador")
            lResult = Boolean.FalseString
        End If
       
        If String.IsNullOrEmpty(cmbArea.Value) Then
            Ep1.SetError(cmbArea, "Seleccione área")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(txtMotivo.Value) Then
            Ep1.SetError(txtMotivo, "Ingrese el motivo")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(dtFechaSalida.Value) Then
            Ep1.SetError(dtFechaSalida, "Ingrese fecha de salida")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(dtFechaRetorno.Value) Then
            Ep1.SetError(dtFechaRetorno, "Ingrese fecha de retorno")
            lResult = Boolean.FalseString
        End If

        If chk_TarjetaConsumo.Checked = False Then
            If String.IsNullOrEmpty(txtcodCantera.Value) Then
                Ep1.SetError(txtCantera, "Seleccione cantera")
                lResult = Boolean.FalseString
            End If
        End If

        If txttotal.Text = "" Then
            Ep1.SetError(txttotal, "No puede registrar solicitud con monto 0.00")
            'MsgBox("No puede registrar solicitud con monto 0.00")
            lResult = Boolean.FalseString
        End If


        'If String.IsNullOrEmpty(txtmontopasaje.Value) Then
        '    Ep1.SetError(txtmontopasaje, "Ingrese monto de pasaje")
        '    lResult = Boolean.FalseString
        'End If

        'If String.IsNullOrEmpty(txtmontoalim.Value) Then
        '    Ep1.SetError(txtmontoalim, "Ingrese monto de alimentación")
        '    lResult = Boolean.FalseString
        'End If

        'If String.IsNullOrEmpty(txtmontohosp.Value) Then
        '    Ep1.SetError(txtmontohosp, "Ingrese monto de hospedaje")
        '    lResult = Boolean.FalseString
        'End If

        'If String.IsNullOrEmpty(txtmontomov.Value) Then
        '    Ep1.SetError(txtmontomov, "Ingrese monto de movilidad")
        '    lResult = Boolean.FalseString
        'End If

        Return lResult

    End Function

    Private Sub GridSolicitudes_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridSolicitudes.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot GridSolicitudes Then Return

        If e.Row.IsFilterRow Then Return

        SubProceso_Entregas(e.Row)
    End Sub

    Sub SubProceso_Entregas(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Call HabilitarControles(True)

        Dim usuarioSolicitud As String = String.Empty
        estado = uRow.Cells("estado").Value
        usuarioSolicitud = uRow.Cells("usuario").Value
        Ope = 2
        'If estado = "APROBADO" Then flgaprobada = 1 Else flgaprobada = 0 'MsgBox("La solicitud se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa) : Return
        lblestado.Text = estado.ToString.ToUpper.Trim
        If Not estado = "PENDIENTE" Then flgaprobada = 1 Else flgaprobada = 0 'MsgBox("La solicitud se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa) : Return
        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.Entregas.codArea = uRow.Cells("codArea").Value

        Entidad.MyLista = Negocio.NEntregas.UsuarioAprobacion(Entidad.Entregas)

        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        If Not estado = "DESEMBOLSADO" Then
            If Ls_Entrega.Count <= 0 Then
                chkAprobar.Visible = False
                esAprobador = 0
                puedeeliminar = 1
            ElseIf Ls_Entrega.Count > 0 Then
                chkAprobar.Visible = True
                esAprobador = 1
                puedeeliminar = 0
            End If
        Else
            chkAprobar.Visible = False
            esAprobador = 0
            puedeeliminar = 1
        End If

        If usuarioSolicitud <> User_Sistema Then esCreador = 0 Else esCreador = 1

        TxtCodigoTrabajador.ReadOnly = True

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.MyLista = New ETMyLista
        Entidad.Entregas.NumSolicitud = uRow.Cells("NumSolicitud").Value
        NumSolicitud = uRow.Cells("NumSolicitud").Value
        nroSolicitud = uRow.Cells("NumSolicitud").Value

        '----------------------------------------------------------------

        idTarjetaConsumo = uRow.Cells("idTarjetaConsumo").Value
        idTipoTarjetaConsumo = uRow.Cells("idTipoTarjetaConsumo").Value
        nroTarjeta = uRow.Cells("nrotarjeta").Value
        totalSolicitud = uRow.Cells("montototal").Value

        If idTarjetaConsumo <> 0 Then
            Me.chk_TarjetaConsumo.Checked = True
        Else
            Me.chk_TarjetaConsumo.Checked = False
        End If

        If Me.chk_TarjetaConsumo.Checked = True Then
            Entidad.MyLista = Negocio.NEntregas.SolicitudxNumeroTarjetaConsumo(Entidad.Entregas)
        Else
            Entidad.MyLista = Negocio.NEntregas.SolicitudxNumero(Entidad.Entregas)
        End If

        '----------------------------------------------------------------
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If

        If Entidad.MyLista.Validacion Then Call Cargar_DatosSolicitud()
        'Txt4.Value = NumSolicitud
        esCreador = uRow.Cells("flgpermiso").Value

        If Me.chk_TarjetaConsumo.Checked = True Then
            txt_nro_tarjeta.Text = nroTarjeta
            txttotal.Text = totalSolicitud
            If idTipoTarjetaConsumo = 1 Then
                rb_tconsumo1.Checked = True
                rb_tconsumo2.Checked = False
            Else
                rb_tconsumo1.Checked = False
                rb_tconsumo2.Checked = True
            End If
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

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
        y = Tabla1.Location.Y + Tabla1.Height
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
            Call LimpiarDatos()
            Call HabilitarControles(True)
            lblestado.Visible = True
            UltraLabel39.Visible = True
            Dim y As Double
            y = UltraLabel2.Location.Y
            UltraLabel39.Location = New Point(782, y)
            lblestado.Location = New Point(914, y)
            If lblestado.Text.ToString.Trim = "DESEMBOLSADO" Then
                VisualizarDatosDeposito(True)
            End If
            If Ls_Entrega.Count > 0 Then



                TxtCodigoTrabajador.Text = Ls_Entrega.Item(0).CodTrabajador.ToString
                If codTrabajadorInicio.Trim = Ls_Entrega.Item(0).CodTrabajador.ToString.Trim Then esCreador = 1
                TxtNombresTrabajador.Text = Ls_Entrega.Item(0).NomTrabajador.ToString
                cmbArea.Value = Ls_Entrega.Item(0).codArea.ToString
                txtJefeArea.Value = Ls_Entrega.Item(0).JefeArea.ToString
                txtMotivo.Value = Ls_Entrega.Item(0).Motivo.ToString
                dtFechaSalida.Value = Ls_Entrega.Item(0).fechaSalida.ToString("dd/MM/yyyy")
                dtFechaRetorno.Value = Ls_Entrega.Item(0).fechaRetorno.ToString("dd/MM/yyyy")
                txtcodCantera.Value = Ls_Entrega.Item(0).codCantera.ToString
                txtCantera.Value = Ls_Entrega.Item(0).Cantera.ToString
                txtRegion.Value = Ls_Entrega.Item(0).Region.ToString
                txttotal.Value = Ls_Entrega.Item(0).montoTotal.ToString("#####0.00")
                ctatrabajador = Ls_Entrega.Item(0).ctatrabajador.ToString.Trim
                bcotrabajador = Ls_Entrega.Item(0).bcotrabajador.ToString.Trim
                montosolicitud = Ls_Entrega.Item(0).montoTotal.ToString("#####0.00")

                Dim fecha1 As Date = dtFechaSalida.Value
                Dim fecha2 As Date = dtFechaRetorno.Value
                dias = (fecha2 - fecha1).TotalDays

                Dim descripTipoDeposito As String = String.Empty
                Select Case (Ls_Entrega.Item(0).tipodeposito.ToString.Trim)
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
                txtbanco.Value = Ls_Entrega.Item(0).banco.ToString
                txtcuenta.Value = Ls_Entrega.Item(0).nrocta.ToString
                txtnrodoc.Value = Ls_Entrega.Item(0).nrodoc.ToString

                Dim idEstado As Int32
                idEstado = Ls_Entrega.Item(0).idEstado
                If idEstado = 1 Then
                    chkAprobar.Checked = Boolean.FalseString
                ElseIf idEstado = 2 Then
                    chkAprobar.Checked = Boolean.TrueString
                End If
                Entidad.Entregas.NumSolicitud = NumSolicitud
                lblnSolicitud.Text = "N° Solicitud : " & NumSolicitud
                lblnSolicitud.Visible = Boolean.TrueString

                If Ls_Entrega.Item(0).flgbeneficiario.ToString.Trim = "1" Then
                    chkbeneficiario.Checked = True
                    txtdnibeneficiario.Text = Ls_Entrega.Item(0).dnibeneficiario.ToString.Trim
                    txtbeneficiario.Text = Ls_Entrega.Item(0).beneficiario.ToString.Trim
                Else
                    chkbeneficiario.Checked = False
                    txtdnibeneficiario.Text = ""
                    txtbeneficiario.Text = TxtNombresTrabajador.Text.ToString.Trim
                End If

                Select Case (Ls_Entrega.Item(0).tipodepobeneficiario.ToString.Trim)
                    Case Is = "1"
                        rdbDeposito.Checked = True
                        cmbbanco.Value = Ls_Entrega.Item(0).bancobeneficiario.ToString.Trim
                        txtctabenef.Value = Ls_Entrega.Item(0).ctabeneficiario.ToString.Trim
                        ctatrabajadorini = Ls_Entrega.Item(0).ctabeneficiario.ToString.Trim
                        bcotrabajadorini = Ls_Entrega.Item(0).bancobeneficiario.ToString.Trim
                    Case Is = "2"
                        rdbCheque.Checked = True
                    Case Is = "3"
                        rdbEfectivo.Checked = True
                End Select


                If Me.chk_TarjetaConsumo.Checked = True Then
                    Call chk_TarjetaConsumo_CheckedChanged(Me.chk_TarjetaConsumo, EventArgs.Empty)
                End If

                Try
                    Dim codigoConcepto As String = ""
                    For Each Row In Ls_Entrega
                        codigoConcepto = Row.codConcepto.ToString
                        Select Case (codigoConcepto)
                            Case "01" 'CARGAR MONTOS DE PASAJES
                                txtmontopasajed.Value = Row.montoParcial
                                txtdiapasaje.Value = Row.totaldias
                                txtmontopasaje.Value = Row.montoTotalParcial.ToString("#####0.00")
                                SubtotalViaticoCarga()
                                'SubtotalViatico("02", txtmontopasajed.Value, txtdiapasaje.Value, CDbl(txtmontopasaje.Text))
                            Case "02" 'CARGAR MONTOS DE ALIMENTACION
                                txtmontoalimd.Value = Row.montoParcial
                                txtdiaalim.Value = Row.totaldias
                                txtmontoalim.Value = Row.montoTotalParcial.ToString("#####0.00")
                                SubtotalViaticoCarga()
                                'SubtotalViatico("02", txtmontoalimd.Value, txtmontoalimd.Value, CDbl(txtmontoalim.Text))
                            Case "03" 'CARGAR MONTOS DE HOSPEDAJE
                                txtmontohospd.Value = Row.montoParcial
                                txtdiahosp.Value = Row.totaldias
                                txtmontohosp.Value = Row.montoTotalParcial.ToString("#####0.00")
                                SubtotalViaticoCarga()
                                'SubtotalViatico("03", txtmontohospd.Value, txtdiahosp.Value, CDbl(txtmontohosp.Text))
                            Case "04" 'CARGAR MONTOS DE MOVILIDAD
                                txtmontomovd.Value = Row.montoParcial
                                txtdiamov.Value = Row.totaldias
                                txtmontomov.Value = Row.montoTotalParcial.ToString("#####0.00")
                                SubtotalViaticoCarga()
                                'SubtotalViatico("04", txtmontomovd.Value, txtdiamov.Value, CDbl(txtmontomov.Text))
                            Case "05" 'CARGAR MONTOS DE COMBUSTIBLE
                                Dim mcomb As Double = 0
                                txtmontocomb.Value = Row.montoTotalParcial.ToString("#####0.00")
                                If txtmontocomb.Text = "" Then mcomb = 0 Else mcomb = txtmontocomb.Text
                                SubtotalTramitesCarga()
                                'SubtotalTramites("06", 0, 0, CDbl(mcomb))
                            Case "06" 'CARGAR MONTOS DE GASTOS NOTARIALES
                                Dim mgastos As Double = 0
                                txtmontogastos.Value = Row.montoTotalParcial.ToString("#####0.00")
                                If txtmontogastos.Text = "" Then mgastos = 0 Else mgastos = txtmontogastos.Text
                                SubtotalTramitesCarga()
                                'SubtotalTramites("06", 0, 0, CDbl(mgastos))
                            Case "07" 'CARGAR MONTOS DE ADQUISICION DE SERVICIOS
                                Dim madquisicion As Double = 0
                                txtmontoadqui.Value = Row.montoTotalParcial.ToString("#####0.00")
                                If txtmontoadqui.Text = "" Then madquisicion = 0 Else madquisicion = txtmontoadqui.Text
                                SubtotalTramitesCarga()
                                'SubtotalTramites("07", 0, 0, CDbl(madquisicion))
                            Case "08" 'CARGAR MONTOS DE COMPRAS BIENES
                                Dim mcompras As Double = 0
                                txtmontocomp.Value = Row.montoTotalParcial.ToString("#####0.00")
                                If txtmontocomp.Text = "" Then mcompras = 0 Else mcompras = txtmontocomp.Text
                                SubtotalTramitesCarga()
                                'SubtotalTramites("08", 0, 0, CDbl(mcompras))

                                '<JOSF 16/01/2023> Se comenta ya que esta para se realiza en el drOtrosGastos
                            Case "09" 'CARGAR MONTOS DE OTROS GASTOS 
                                '    Dim motros As Double = 0
                                '    txtmontootros.Value = Row.montoTotalParcial.ToString("#####0.00")
                                '    If txtmontootros.Text = "" Then motros = 0 Else motros = txtmontootros.Text
                                '    txtdescripcion.Value = Row.Descripcion.ToString
                                DescripcionesMarcadas(Row.Descripcion.ToString)
                                '    SubtotalTramitesCarga()
                                '    'SubtotalTramites("09", 0, 0, CDbl(motros))
                                '<JOSF 16/01/2023>
                        End Select

                    Next
                    Dim dtDatos As New DataTable
                    objNegocio = New NGEntregas
                    objEntidad = New ETEntregas
                    objEntidad.NumSolicitud = NumSolicitud

                    '<JOSF 16/01/2023> Se comenta el dtDatos ya que el dtOtrosGastos es quien debe pintar la información
                    'dtDatos = objNegocio.CargarOtroConcepto(objEntidad)

                    dtOtrosGastos = objNegocio.CargarOtroConcepto(objEntidad)
                    Dim valor As Integer = dtOtrosGastos.Rows.Count
                    OtrosGastosCalculo()
                    SubtotalTramitesCarga()
                    '<JOSF 16/01/2023>

                    Call HabilitarControles(True)
                    TxtCodigoTrabajador.ReadOnly = True
                    cmbMoneda.Enabled = False
                    chkbeneficiario.Enabled = False
                    rdbDeposito.Enabled = False
                    rdbCheque.Enabled = False
                    rdbEfectivo.Enabled = False
                    dtFechaRetorno.ReadOnly = True
                    dtFechaSalida.ReadOnly = True
                    chkdescri1.Enabled = False : chkdescri2.Enabled = False : chkdescri3.Enabled = False : chkdescri4.Enabled = False : chkdescri5.Enabled = False : chkdescri6.Enabled = False : chkdescri7.Enabled = False
                    Select Case (Ls_Entrega.Item(0).moneda.ToString.Trim)
                        Case Is = "S"
                            cmbMoneda.Value = "01"
                        Case Is = "D"
                            cmbMoneda.Value = "02"
                        Case Is = "E"
                            cmbMoneda.Value = "03"
                    End Select


                    '01/03/2025
                    'If chk_TarjetaConsumo.Checked = True Then
                    'Call chk_TarjetaConsumo_CheckedChanged(Me.chk_TarjetaConsumo, EventArgs.Empty)
                    'End If

                    If idTarjetaConsumo <> 0 Then

                        chk_TarjetaConsumo.Checked = Boolean.TrueString

                        If idTipoTarjetaConsumo = 1 Then
                            rb_tconsumo1.Checked = True
                        Else
                            rb_tconsumo2.Checked = True
                        End If

                        chk_TarjetaConsumo_CheckedChanged(Nothing, Nothing)

                    Else
                        chk_TarjetaConsumo.Checked = Boolean.FalseString
                    End If




                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SubtotalViaticoCarga()
        Dim totalpasajev As Double = 0
        Dim totalalimv As Double = 0
        Dim totalhospv As Double = 0
        Dim totalmovv As Double = 0
        Dim subtotalviatico As Double = 0
        If txtmontopasaje.Text.Trim = "" Then totalpasajev = 0 Else totalpasajev = txtmontopasaje.Text
        If txtmontoalim.Text.Trim = "" Then totalalimv = 0 Else totalalimv = txtmontoalim.Text
        If txtmontohosp.Text.Trim = "" Then totalhospv = 0 Else totalhospv = txtmontohosp.Text
        If txtmontomov.Text.Trim = "" Then totalmovv = 0 Else totalmovv = txtmontomov.Text
        subtotalviatico = totalpasajev + totalalimv + totalhospv + totalmovv
        txttotalviaticos.Text = subtotalviatico.ToString("#####0.00")
        total()
    End Sub
    Sub SubtotalTramitesCarga()
        Dim totalcombustible As Double = 0
        Dim totalgastos As Double = 0
        Dim totaladquisicion As Double = 0
        Dim totalcompras As Double = 0
        Dim totalotros As Double = 0
        Dim subtotaltramites As Double = 0
        If txtmontocomb.Text.Trim = "" Then totalcombustible = 0 Else totalcombustible = txtmontocomb.Text
        If txtmontogastos.Text.Trim = "" Then totalgastos = 0 Else totalgastos = txtmontogastos.Text
        If txtmontoadqui.Text.Trim = "" Then totaladquisicion = 0 Else totaladquisicion = txtmontoadqui.Text
        If txtmontocomp.Text.Trim = "" Then totalcompras = 0 Else totalcompras = txtmontocomp.Text
        If txtmontootros.Text.Trim = "" Then totalotros = 0 Else totalotros = txtmontootros.Text
        subtotaltramites = totalcombustible + totalgastos + totaladquisicion + totalcompras + totalotros
        txttotaltramites.Text = subtotaltramites.ToString("#####0.00")
        total()
    End Sub

    'Private Sub TabMaestroEntregas_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabMaestroEntregas.SelectedTabChanged
    '    If TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString Then
    '        Nuevo()
    '    End If
    'End Sub
    Sub eliminar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If nroSolicitud.ToString.Trim = "" Then Return
        If esCreador = 0 Then MsgBox("No puede eliminar la solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If flgaprobada = 1 Then MsgBox("No puede eliminar la solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
        'If flgaprobada = 1 Then MsgBox("La solicitud se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa) : Return
        Ope = 3
        'If puedeeliminar = 0 Then MsgBox("No puede elimnar la solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        'If Not Verificar_Datos() Then
        '    MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return
        'End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas

        Entidad.Entregas.TipoOperacion = Ope
        Entidad.Entregas.NumSolicitud = NumSolicitud
        Entidad.Entregas.CodTrabajador = IIf(TxtCodigoTrabajador.Value Is Nothing, String.Empty, TxtCodigoTrabajador.Value)
        Entidad.Entregas.codArea = IIf(cmbArea.Value Is Nothing, String.Empty, cmbArea.Value)
        Entidad.Entregas.Motivo = IIf(txtMotivo.Value Is Nothing, String.Empty, txtMotivo.Value)
        Entidad.Entregas.fechaSalida = IIf(dtFechaSalida.Value Is Nothing, String.Empty, dtFechaSalida.Value)
        Entidad.Entregas.fechaRetorno = IIf(dtFechaRetorno.Value Is Nothing, String.Empty, dtFechaRetorno.Value)
        Entidad.Entregas.codCantera = IIf(cmbCantera.Value Is Nothing, String.Empty, cmbCantera.Value)
        Entidad.Entregas.Region = IIf(txtRegion.Value Is Nothing, String.Empty, txtRegion.Value)
        Entidad.Entregas.montoTotal = IIf(txttotal.Value Is Nothing, String.Empty, txttotal.Value)
        If chkAprobar.Checked Then
            Entidad.Entregas.idEstado = 2
        Else
            Entidad.Entregas.idEstado = 1
        End If
        Entidad.Entregas.Usuario = User_Sistema

        Dim ls_Solicitud = Ls_Entrega.Where(Function(x) x.codConcepto.ToString.Trim <> "").FirstOrDefault

        Entidad.Entregas = Negocio.NEntregas.EliminarEntregas(Entidad.Entregas, Ls_Entrega, Ls_EntregaDetalle)

        If Entidad.Entregas.Validacion Then
            'If Ope = 1 Then
            Call Nuevo()
            Call Inicio()
            'End If
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        If Not VerificarControl(5, GridSolicitudes) Then Return

        If GridSolicitudes.ActiveRow Is Nothing Then Return

        If GridSolicitudes.ActiveRow.IsFilterRow Then Return

        If Not GridSolicitudes.ActiveRow.IsActiveRow Then Return

        'GridSolicitudes.ActiveRow.Fixed = Boolean.TrueString

        SubProceso_Entregas(GridSolicitudes.ActiveRow)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

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
        StrucForm.FxRxSolicitud = New FrmSolicitud
        'StrucForm.FxRxSolicitud.TextReporte = "Cuadro Enlace (Producto - Unidad)"
        StrucForm.FxRxSolicitud.MdiParent = MdiParent
        StrucForm.FxRxSolicitud.Show()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        lblmensaje.Visible = False
        lblmensaje.Refresh()
        lblmensaje.Update()
    End Sub
    Public Sub Modificar()
        Me.chk_TarjetaConsumo.Checked = False
        Me.txt_nro_tarjeta.Text = ""
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If nroSolicitud.ToString.Trim = "" Then Return
        If esCreador = 0 Then MsgBox("No puede modificar la solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
        If flgaprobada = 1 Then MsgBox("No puede modificar la solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
        'If flgaprobada = 1 Then MsgBox("La solicitud se encuentra aprobada", MsgBoxStyle.Exclamation, msgComacsa) : Return
        Ope = 2
        Call HabilitarControles(False)
        chkbeneficiario.Enabled = True
        rdbDeposito.Enabled = True
        rdbCheque.Enabled = True
        rdbEfectivo.Enabled = True
        cmbMoneda.Enabled = True
        If chkbeneficiario.Checked = True Then
            Me.txtdnibeneficiario.ReadOnly = False
            Me.txtbeneficiario.ReadOnly = False
        Else
            Me.txtdnibeneficiario.ReadOnly = True
            Me.txtbeneficiario.ReadOnly = True
        End If

        If rdbDeposito.Checked = True Then
            cmbbanco.ReadOnly = False
            txtctabenef.ReadOnly = False
        End If
        If txtmontootros.Text.ToString.Trim = "" Then txtmontootros.Text = 0
        If CDbl(txtmontootros.Text > 0) Then
            chkdescri1.Enabled = True : chkdescri2.Enabled = True : chkdescri3.Enabled = True : chkdescri4.Enabled = True : chkdescri5.Enabled = True : chkdescri6.Enabled = True : chkdescri7.Enabled = True
        Else
            chkdescri1.Enabled = False : chkdescri2.Enabled = False : chkdescri3.Enabled = False : chkdescri4.Enabled = False : chkdescri5.Enabled = False : chkdescri6.Enabled = False : chkdescri7.Enabled = False
        End If

        'Verifica controles activar o desactivar en caso de marcar tarjetas de consumo
        CheckTarjetaConsumoControles()

        TxtCodigoTrabajador.ReadOnly = False
    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call LimpiarDatos()
        nroSolicitud = ""
        lblestado.Visible = False
        UltraLabel39.Visible = False
        chkAprobar.Visible = False
        chkAprobar.Checked = False
        VisualizarDatosDeposito(False)
        Call Inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Private Sub txtdescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdescripcion.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        'SubtotalTramites("09", 0, 0, CDbl(txtmontootros.Text))
    End Sub
    Sub cancelar()
        Call LimpiarDatos()
        Me.TxtCodigoTrabajador.ReadOnly = True
        nroSolicitud = ""
        lblestado.Visible = False
        UltraLabel39.Visible = False
        chkAprobar.Visible = False
        chkAprobar.Checked = False
        VisualizarDatosDeposito(False)
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
    End Sub

    Private Sub dtFechaSalida_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaSalida.ValueChanged
        Try
            If esprimera = 0 Then Return
            If sender.readonly = True Then Return
            Dim fecha1 As Date = dtFechaSalida.Value
            Dim fecha2 As Date = dtFechaRetorno.Value
            Dim fechaActual As Date = Now.Date
            If fecha1.CompareTo(fechaActual) < 0 Then
                MsgBox("Fecha de salida debe ser mayor a fecha actual", MsgBoxStyle.Exclamation, msgComacsa)
                dtFechaSalida.Value = Now.Date
                Return
            End If
            calculoDias(fecha1, fecha2)
            dtFechaRetorno.ReadOnly = False
            dtFechaRetorno.Focus()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub dtFechaRetorno_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaRetorno.ValueChanged
        Try
            If esprimera = 0 Then Return
            If sender.readonly = True Then Return
            Dim fecha1 As Date = dtFechaSalida.Value
            Dim fecha2 As Date = dtFechaRetorno.Value
            If fecha2.CompareTo(fecha1) < 0 Then
                MsgBox("Fecha de retorno debe ser mayor a fecha de salida", MsgBoxStyle.Exclamation, msgComacsa)
                Return
            End If
            calculoDias(fecha1, fecha2)
            cmbCantera.ReadOnly = False
        Catch ex As Exception

        End Try
    End Sub
    Sub calculoDias(ByVal FechaSalida As Date, ByVal FechaRetorno As Date)
        Dim fechaActual As Date = Now.Date
        dias = (FechaRetorno - FechaSalida).TotalDays
        If dias < 0 Then Return
        dias += 1
        txtdiapasaje.Text = 2
        txtdiaalim.Text = dias
        txtdiahosp.Text = dias
        txtdiamov.Text = dias
        calculapasaje()
        calculalimento()
        calculahospedaje()
        calculamovilidad()
    End Sub
    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try
            If sender.readonly = True Then Return
            If cmbArea.Value Is Nothing Then Return
            JefeArea()
            txtMotivo.ReadOnly = False
        Catch ex As Exception

        End Try
    End Sub
    Sub JefeArea()
        Entidad.Entregas.codArea = cmbArea.Value.ToString
        Entidad.Entregas.CodTrabajador = TxtCodigoTrabajador.Text.ToString
        Entidad.MyLista = Negocio.NEntregas.Listar_JefeArea(Entidad.Entregas)
        If Entidad.MyLista.Ls_Entrega.Count > 0 Then
            txtJefeArea.Text = Entidad.MyLista.Ls_Entrega.Item(0).JefeArea.ToString
        Else
            txtJefeArea.Text = String.Empty
        End If
    End Sub
    Private Sub cmbCantera_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCantera.ValueChanged
        Try
            If sender.readonly = True Then Return
            txtCantera.Text = cmbCantera.Text.ToString
            txtRegion.Text = cmbCantera.ActiveRow.Cells("region").Value
            txtRegion.ReadOnly = False
            txtmontopasajed.ReadOnly = False
            'txtRegion.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Sub buscar()

        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return

        If TxtCodigoTrabajador.ReadOnly = True Then Return

        Dim lchk_tarjeta As Integer = 0

        If TxtCodigoTrabajador.Focused = True Then
            '----------------------------------------------------------
            'Se presenta un formulario 
            If chk_TarjetaConsumo.Checked = True Then
                lchk_tarjeta = IIf(rb_tconsumo1.Checked, 1, IIf(rb_tconsumo2.Checked, 2, 0))
            End If

            Dim FRM As New FrmListadoPersonal(chk_TarjetaConsumo.Checked, lchk_tarjeta)
            FRM.ShowDialog()
            '----------------------------------------------------------
            If codTrabajador.ToString.Trim = "" Then Return

            TxtCodigoTrabajador.Text = codTrabajador.ToString.Trim
            TxtNombresTrabajador.Text = nomTrabajador.ToString.Trim
            txtbeneficiario.Text = nomTrabajador.ToString.Trim
            txt_nro_tarjeta.Text = numeroTarjetaConsumo.ToString.Trim
            txt_saldo_inicialtc.Text = CDbl(saliniTarjetaConsumo).ToString("#####0.00")
            txt_idTarjetaConsumo.Text = idTarjetaConsumo.ToString

            'CDbl(txt_saldo_inicialtc.Text).ToString("#####0.00")
            'txt_saldo_consumotc = 
            'txt_saldo_finaltc = 
            'tipoTarjetaConsumo
            'bancoTarjetaConsumo
            txtdnibeneficiario.Text = String.Empty
            chkbeneficiario.Checked = False
            txtdnibeneficiario.ReadOnly = True
            txtbeneficiario.ReadOnly = True

            CargarAreaTrabajador(Me.TxtCodigoTrabajador.Text)
            rdbDeposito_CheckedChanged(Nothing, Nothing)

            If chk_TarjetaConsumo.Checked = True Then
                If rb_tconsumo1.Checked = True Then
                    rb_tconsumo1_CheckedChanged(Nothing, Nothing)
                Else
                    rb_tconsumo2_CheckedChanged(Nothing, Nothing)
                End If
            End If

        End If

        If txtcodCantera.Focused = True Then
            If flgaprobada = 1 Then Return
            Dim frm As New FrmCanteras
            frm.filtroDescripcion = ""
            frm.cadena = txtcodCantera.Text.ToString.Trim
            frm.ShowDialog()
            If Not codCantera = "" Then
                txtcodCantera.Text = codCantera
                txtCantera.Text = Cantera
                txtRegion.Text = ModVariable.Region
                txtmontopasajed.ReadOnly = False
                txtmontopasaje.ReadOnly = False
                txtmontopasajed.Focus()
                codCantera = ""
                Cantera = ""
            End If
        End If

        CheckTarjetaConsumoControles()

        Me.txtMotivo.ReadOnly = False
        Me.txtRegion.ReadOnly = False
        Me.txtdiapasaje.ReadOnly = False
        Me.txtdiaalim.ReadOnly = False
        Me.txtdiahosp.ReadOnly = False
        Me.txtdiamov.ReadOnly = False
        Me.cmbArea.ReadOnly = False
        Me.cmbCantera.ReadOnly = False
        Me.dtFechaSalida.ReadOnly = False
        Me.dtFechaRetorno.ReadOnly = False
    End Sub

    Public Sub CheckTarjetaConsumoControles()
        If chk_TarjetaConsumo.Checked = True Then
            Me.txtmontoalim.ReadOnly = True
            Me.txtmontohosp.ReadOnly = True
            Me.txtmontomov.ReadOnly = True
            Me.txtmontocomb.ReadOnly = True
            Me.txtmontogastos.ReadOnly = True
            Me.txtmontoadqui.ReadOnly = True
            Me.txtmontocomp.ReadOnly = True
            Me.txtmontootros.ReadOnly = True
            Me.txtmontopasajed.ReadOnly = True
            Me.txtmontohospd.ReadOnly = True
            Me.txtmontomovd.ReadOnly = True
            Me.txtmontopasaje.ReadOnly = True
            Me.txtmontoalimd.ReadOnly = True
            Me.txtmontootros.ReadOnly = True
            InfoSaldoConsumoTarjeta()
        Else
            Me.txtmontoalim.ReadOnly = False
            Me.txtmontohosp.ReadOnly = False
            Me.txtmontomov.ReadOnly = False
            Me.txtmontocomb.ReadOnly = False
            Me.txtmontogastos.ReadOnly = False
            Me.txtmontoadqui.ReadOnly = False
            Me.txtmontocomp.ReadOnly = False
            Me.txtmontootros.ReadOnly = False
            Me.txtmontopasajed.ReadOnly = False
            Me.txtmontohospd.ReadOnly = False
            Me.txtmontomovd.ReadOnly = False
            Me.txtmontopasaje.ReadOnly = False
            Me.txtmontoalimd.ReadOnly = False
            Me.txtmontootros.ReadOnly = False
        End If


    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

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
            txtbeneficiario.Text = TxtNombresTrabajador.Text
            If rdbDeposito.Checked = True And cmbMoneda.Text.ToString.Trim.Substring(0, 1) = "S" Then
                cmbbanco.Value = bcotrabajador
                txtctabenef.Text = ctatrabajador
            Else
                cmbbanco.Value = Nothing
                txtctabenef.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub cmbMoneda_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbMoneda.InitializeLayout
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

    Private Sub cmbMoneda_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMoneda.ValueChanged
        Try

            Dim trimmedText As String = cmbMoneda.Text.Trim()
            If trimmedText.Length = 0 Then
                trimmedText = "S"
                cmbMoneda.Text = "S"
            End If
            If trimmedText.Length > 0 Then
                If trimmedText.Substring(0, 1) = "S" Then
                    UltraLabel22.Text = "MONTO DIARIO S/."
                    UltraLabel23.Text = "MONTO TOTAL S/."
                    UltraLabel27.Text = "MONTO TOTAL S/."
                    UltraLabel30.Text = "SUB TOTAL (A) S/."
                    UltraLabel31.Text = "SUB TOTAL (B) S/."
                    UltraLabel32.Text = "TOTAL (A + B) S/."
                ElseIf trimmedText.Substring(0, 1) = "D" Then
                    UltraLabel22.Text = "MONTO DIARIO US$"
                    UltraLabel23.Text = "MONTO TOTAL US$"
                    UltraLabel27.Text = "MONTO TOTAL US$"
                    UltraLabel30.Text = "SUB TOTAL (A) US$"
                    UltraLabel31.Text = "SUB TOTAL (B) US$"
                    UltraLabel32.Text = "TOTAL (A + B) US$"
                End If
            End If


            If chkbeneficiario.Checked = True Then
                CargarBeneficiariosDni(Me.txtdnibeneficiario.Text)
            Else
                If rdbDeposito.Checked = True And trimmedText.Substring(0, 1) = "S" Then
                    cmbbanco.Value = bcotrabajador
                    txtctabenef.Text = ctatrabajador
                Else
                    cmbbanco.Value = bcotrabajadorini
                    txtctabenef.Text = ctatrabajadorini
                End If
            End If

            'MsgBox(cmbMoneda.Text.ToString.Trim.Substring(0, 1))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtdnibeneficiario_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdnibeneficiario.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
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


    Private Sub CargarBeneficiariosDni(ByVal dnibeneficiario As String)
        If chkbeneficiario.Checked = True Then
            Negocio.NEntregas = New NGEntregas
            Entidad.MyLista = New ETMyLista
            'Ls_Entrega = Nothing
            'Ls_Entrega = New List(Of ETEntregas)
            Dim Rpt As New ETEntregas
            Rpt.dnibeneficiario = dnibeneficiario.ToString.Trim
            Rpt.moneda = cmbMoneda.Text.ToString.Trim.Substring(0, 1)
            Entidad.MyLista = Negocio.NEntregas.ListarBeneficiarioDni(Rpt)
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

    Private Sub rdbDeposito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDeposito.CheckedChanged
        If rdbDeposito.Checked = True Then
            cmbbanco.ReadOnly = False
            txtctabenef.ReadOnly = False
            If chkbeneficiario.Checked = True Then
                CargarBeneficiariosDni(Me.txtdnibeneficiario.Text)
                Exit Sub
            End If
            cmbbanco.ReadOnly = False
            txtctabenef.ReadOnly = False
            If chkbeneficiario.Checked = False And cmbMoneda.Text.ToString.Trim.Substring(0, 1) = "S" Then
                cmbbanco.Value = bcotrabajador
                txtctabenef.Text = ctatrabajador
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

    Private Sub rdbEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbEfectivo.CheckedChanged
        If rdbEfectivo.Checked = True Then
            cmbbanco.ReadOnly = True
            txtctabenef.ReadOnly = True
            cmbbanco.Value = Nothing
            txtctabenef.Text = String.Empty
        End If
    End Sub

    Private Sub cmbbanco_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbbanco.InitializeLayout
        With cmbbanco.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("banco").Width = 150 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "banco") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub chkdescri1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdescri1.CheckedChanged, chkdescri2.CheckedChanged, chkdescri3.CheckedChanged, chkdescri4.CheckedChanged, chkdescri5.CheckedChanged, chkdescri6.CheckedChanged, chkdescri7.CheckedChanged
        Seleccionardescripcion()
    End Sub
    Sub Seleccionardescripcion()
        Dim cadena As String = String.Empty
        txtdescripcion.Text = String.Empty
        If chkdescri1.Checked = True Then
            cadena = cadena + chkdescri1.Text
        End If
        If chkdescri2.Checked = True Then
            cadena = cadena + "," + chkdescri2.Text
        End If
        If chkdescri3.Checked = True Then
            cadena = cadena + "," + chkdescri3.Text
        End If
        If chkdescri4.Checked = True Then
            cadena = cadena + "," + chkdescri4.Text
        End If
        If chkdescri5.Checked = True Then
            cadena = cadena + "," + chkdescri5.Text
        End If
        If chkdescri6.Checked = True Then
            cadena = cadena + "," + chkdescri6.Text
        End If
        If chkdescri7.Checked = True Then
            cadena = cadena + "," + chkdescri7.Text
        End If
        txtdescripcion.Text = cadena
    End Sub

    Sub DescripcionesMarcadas(ByVal descipcion As String)
        Dim arrDescripcion() As String = descipcion.Split(",")
        For i As Int32 = 0 To arrDescripcion.Count - 1
            If chkdescri1.Text.ToString.ToUpper = arrDescripcion(i) Then chkdescri1.Checked = True
            If chkdescri2.Text.ToString.ToUpper = arrDescripcion(i) Then chkdescri2.Checked = True
            If chkdescri3.Text.ToString.ToUpper = arrDescripcion(i) Then chkdescri3.Checked = True
            If chkdescri4.Text.ToString.ToUpper = arrDescripcion(i) Then chkdescri4.Checked = True
            If chkdescri5.Text.ToString.ToUpper = arrDescripcion(i) Then chkdescri5.Checked = True
            If chkdescri6.Text.ToString.ToUpper = arrDescripcion(i) Then chkdescri6.Checked = True
            If chkdescri7.Text.ToString.ToUpper = arrDescripcion(i) Then chkdescri7.Checked = True
        Next
    End Sub

    Private Function ValidaLineacredito(ByVal codTrabajador As String) As Boolean
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.CodTrabajador = codTrabajador
        Entidad.MyLista = Negocio.NEntregas.ValidaLineacredito(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Ls_Entrega.Count > 0 Then
            lineacredito = Entidad.MyLista.Ls_Entrega.Item(0).lineacredito
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ValidaExcesocredito(ByVal codTrabajador As String) As Boolean
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.CodTrabajador = codTrabajador
        Entidad.MyLista = Negocio.NEntregas.ValidaExcesocredito(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        Dim creditoacumulado As Double = 0
        Dim creditorestante As Double = 0
        Dim creditopedido As Double = CDbl(txttotal.Text)
        Dim montoinicial As Double = montosolicitud
        Dim tipocambio As Double = 0
        If Entidad.MyLista.Ls_Entrega.Count > 0 Then
            creditoacumulado = Entidad.MyLista.Ls_Entrega.Item(0).lineacredito
            tipocambio = Entidad.MyLista.Ls_Entrega.Item(0).tipocambio
        End If
        If Not cmbMoneda.Text.ToString.Trim.Substring(0, 1) = "S" Then
            creditopedido = creditopedido * tipocambio
            montoinicial = montoinicial * tipocambio
        End If

        creditoacumulado = creditoacumulado + creditopedido - montoinicial

        If lineacredito >= creditoacumulado Then
            Return True
        Else
            creditorestante = lineacredito - Entidad.MyLista.Ls_Entrega.Item(0).lineacredito
            MsgBox("Solo tiene un saldo de S/. " & creditorestante.ToString, MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If

    End Function

    Private Sub txtcodCantera_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodCantera.KeyPress
        Try
            If flgaprobada = 1 Then Return
            Dim frm As New FrmCanteras
            frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
            frm.cadena = txtcodCantera.Text.ToString.Trim
            frm.ShowDialog()
            If Not codCantera = "" Then
                txtcodCantera.Text = codCantera
                txtCantera.Text = Cantera
                txtRegion.Text = ModVariable.Region
                txtmontopasajed.ReadOnly = False
                txtmontopasaje.ReadOnly = False
                txtmontopasajed.Focus()
                codCantera = ""
                Cantera = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub seteoEntidadDetalle()
        SubtotalViaticoCarga()
        SubtotalTramitesCarga()
        seteoEntidades("01", IIf(txtmontopasajed.Text = "", 0, txtmontopasajed.Text), txtdiapasaje.Text, IIf(txtmontopasaje.Text = "", 0, txtmontopasaje.Text))
        seteoEntidades("02", IIf(txtmontoalimd.Text = "", 0, txtmontoalimd.Text), IIf(txtdiaalim.Text = "", 0, txtdiaalim.Text), IIf(txtmontoalim.Text = "", 0, txtmontoalim.Text))
        seteoEntidades("03", IIf(txtmontohospd.Text = "", 0, txtmontohospd.Text), IIf(txtdiahosp.Text = "", 0, txtdiahosp.Text), IIf(txtmontohosp.Text = "", 0, txtmontohosp.Text))
        seteoEntidades("04", IIf(txtmontomovd.Text = "", 0, txtmontomovd.Text), IIf(txtdiamov.Text = "", 0, txtdiamov.Text), IIf(txtmontomov.Text = "", 0, txtmontomov.Text))
        seteoEntidades("05", 0, 0, IIf(txtmontocomb.Text = "", 0, txtmontocomb.Text))
        seteoEntidades("06", 0, 0, IIf(txtmontogastos.Text = "", 0, txtmontogastos.Text))
        seteoEntidades("07", 0, 0, IIf(txtmontoadqui.Text = "", 0, txtmontoadqui.Text))
        seteoEntidades("08", 0, 0, IIf(txtmontocomp.Text = "", 0, txtmontocomp.Text))
        'seteoEntidades("09", 0, 0, IIf(txtmontootros.Text = "", 0, txtmontootros.Text))
        If txtmontootros.Text = "" Then txtmontootros.Text = 0
        If txtmontootros.Text > 0 Then
            OtrosGastosCalculo()
            For i As Int32 = 0 To dtOtrosGastos.Rows.Count - 1
                seteoEntidades(dtOtrosGastos.Rows(i)("codConcepto"), 0, 0, dtOtrosGastos.Rows(i)("importe"))
                'otrosgastos = otrosgastos + dtOtrosGastos.Rows(i)("importe")
            Next
        End If
    End Sub

    Private Sub chk_TarjetaConsumo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_TarjetaConsumo.CheckedChanged
        If chk_TarjetaConsumo.Checked = True Then
            txt_nro_tarjeta.Visible = True
            lbl_nro_tarjeta.Visible = True
            txt_saldo_inicialtc.Visible = True
            lbl_saldo_inicialtc.Visible = True
            rb_tconsumo1.Visible = True
            rb_tconsumo2.Visible = True

            ' Bloquear controles 
            rdbDeposito.Visible = False
            rdbCheque.Visible = False
            UltraLabel37.Visible = False
            cmbbanco.Visible = False
            UltraLabel36.Visible = False
            txtctabenef.Visible = False
            rdbEfectivo.Visible = False

            chkbeneficiario.Visible = False
            txtdnibeneficiario.Visible = False
            UltraLabel34.Visible = False
            txtbeneficiario.Visible = False
            UltraLabel35.Visible = False

            'txt_saldo_finaltc.Visible = True
            'lblsaldotc.Visible = True

            'Verificar la disponivilidad del importe de la tarjeta de consumo 
            ' no so es lo que se tiene como saldo inicial si en el mes o el periodo de vigencia ver tod los consumido 
            ' Lo inicial menos lo consumido seria lo que se tiene como saldo para utilizar en la Tarjeta de consumo

            InfoSaldoConsumoTarjeta()

            UltraLabel32.Text = "TOTAL (A+B+C) S/."


        Else
            txt_nro_tarjeta.Visible = False
            lbl_nro_tarjeta.Visible = False
            txt_saldo_inicialtc.Visible = False
            lbl_saldo_inicialtc.Visible = False
            rb_tconsumo1.Visible = False
            rb_tconsumo2.Visible = False


            'DesbBloquear controles 
            rdbDeposito.Visible = True
            rdbCheque.Visible = True
            UltraLabel37.Visible = True
            cmbbanco.Visible = True
            UltraLabel36.Visible = True
            txtctabenef.Visible = True
            rdbEfectivo.Visible = True

            txt_saldo_finaltc.Visible = False
            lblsaldotc.Visible = False

            chkbeneficiario.Visible = True
            txtdnibeneficiario.Visible = True
            UltraLabel34.Visible = True
            txtbeneficiario.Visible = True
            UltraLabel35.Visible = True


        End If
    End Sub

    Private Sub InfoSaldoConsumoTarjeta()

        Me.txttotal.Text = Me.txt_saldo_inicialtc.Text

    End Sub


    Private Sub txt_saldo_finaltc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_saldo_finaltc.ValueChanged

    End Sub

    Private Sub rb_tconsumo1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_tconsumo1.CheckedChanged

        If rb_tconsumo1.Checked Then

            'En este punto se a releccionado el tipo de tarjeta
            ' necesitamos saber el periodo o rango de fechas a buscar en los registros de las solicitudes aprobadas 
            ' esto para determinar cuanto le queda al usuario el saldo a aplicar en su solciitud 

            'hvilela - 24/03/2025

            If chk_TarjetaConsumo.Checked = True Then

                Ls_Entrega = Nothing
                Ls_Entrega = New List(Of ETEntregas)
                Entidad.Entregas = New ETEntregas
                Negocio.NEntregas = New NGEntregas
                SIP_Presentacion.ModStructure.Entidad.MyLista = New SIP_Entidad.ETMyLista
                Dim IDtarjconsumo As Integer = Integer.Parse(IIf(txt_idTarjetaConsumo.Text.Trim = "", 0, txt_idTarjetaConsumo.Text.Trim))
                Entidad.Entregas.idTarjetaConsumo = IDtarjconsumo
                Entidad.Entregas.idTipoTarjetaConsumo = 1

                SIP_Presentacion.ModStructure.Entidad.MyLista = Negocio.NEntregas.LimiteLineaCredito(Entidad.Entregas)

                If SIP_Presentacion.ModStructure.Entidad.MyLista IsNot Nothing Then

                    Dim lnSaldoDisponible = 0

                    For i As Int32 = 0 To SIP_Presentacion.ModStructure.Entidad.MyLista.Ls_Entrega.Count - 1

                        lnSaldoDisponible = lnSaldoDisponible + SIP_Presentacion.ModStructure.Entidad.MyLista.Ls_Entrega.Item(i).SaldoDisponible

                    Next


                    Saldo_LC_T1 = lnSaldoDisponible


                    'Saldo_LC_T1 = Saldo_LC_T1 - SIP_Presentacion.ModStructure.Entidad.Entregas.SaldoDisponible

                    'combustible_lm = dtLimiteLineaCredito.Rows(0)(2)
                    'compras_lm = dtLimiteLineaCredito.Rows(1)(2)
                    'adquisicion_lm = dtLimiteLineaCredito.Rows(2)(2)
                    'otros_gastos_lm = dtLimiteLineaCredito.Rows(3)(2)

                End If
            End If

            txt_saldo_inicialtc.Text = Saldo_LC_T1

            total()

        End If

    End Sub

    Private Sub rb_tconsumo2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_tconsumo2.CheckedChanged


        If rb_tconsumo2.Checked Then
            'En este punto se a releccionado el tipo de tarjeta
            ' necesitamos saber el periodo o rango de fechas a buscar en los registros de las solicitudes aprobadas 
            ' esto para determinar cuanto le queda al usuario el saldo a aplicar en su solciitud 

            'hvilela - 24/03/2025

            If chk_TarjetaConsumo.Checked = True Then

                Ls_Entrega = Nothing
                Ls_Entrega = New List(Of ETEntregas)
                Entidad.Entregas = New ETEntregas
                Negocio.NEntregas = New NGEntregas
                SIP_Presentacion.ModStructure.Entidad.MyLista = New SIP_Entidad.ETMyLista
                Dim IDtarjconsumo As Integer = Integer.Parse(IIf(txt_idTarjetaConsumo.Text.Trim = "", 0, txt_idTarjetaConsumo.Text.Trim))
                Entidad.Entregas.idTarjetaConsumo = IDtarjconsumo
                Entidad.Entregas.idTipoTarjetaConsumo = 2

                'SIP_Presentacion.ModStructure.Entidad.MyLista = Negocio.NEntregas.LimiteLineaCredito(Entidad.Entregas)

                Entidad.MyLista = Negocio.NEntregas.LimiteLineaCredito(Entidad.Entregas)

                'If SIP_Presentacion.ModStructure.Entidad.MyLista IsNot Nothing Then
                If Entidad.MyLista IsNot Nothing Then


                    Dim lnSaldoDisponible = 0

                    For i As Int32 = 0 To SIP_Presentacion.ModStructure.Entidad.MyLista.Ls_Entrega.Count - 1

                        lnSaldoDisponible = lnSaldoDisponible + SIP_Presentacion.ModStructure.Entidad.MyLista.Ls_Entrega.Item(i).SaldoDisponible

                    Next

                    Saldo_LC_T2 = lnSaldoDisponible

                    'Entidad.MyLista.Ls_Entrega.Item(0).SaldoDisponible

                    ' Saldo_LC_T2 = Saldo_LC_T2 - SIP_Presentacion.ModStructure.Entidad.Entregas.SaldoDisponible
                    'Saldo_LC_T2 = 

                    ' Entidad.MyLista.Ls_Entrega.


                    ' Ls_Entrega.

                    ' combustible_lm = dtLimiteLineaCredito.Rows(0)(2)
                    ' compras_lm = dtLimiteLineaCredito.Rows(1)(2)
                    ' adquisicion_lm = dtLimiteLineaCredito.Rows(2)(2)
                    ' otros_gastos_lm = dtLimiteLineaCredito.Rows(3)(2)

                End If
            End If

            txt_saldo_inicialtc.Text = Saldo_LC_T2

            total()

        End If

    End Sub

End Class