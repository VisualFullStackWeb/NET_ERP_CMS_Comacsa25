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
Imports System.Net.Mail

Public Class FrmSolicitudPlanilla
    Dim _objNegocio_ As NGProducto
    Dim _objEntidad_ As ETProducto
    Private Ls_Concepto As List(Of ETRuma) = Nothing
    Dim dtArea As DataTable
    Dim dtMoneda As DataTable
    Dim dtConcepto As DataTable
    Dim dtPermisos As DataTable
    Dim dtUsuario As DataTable
    Dim dtRuta As DataTable
    Dim ETMaestros2 = New ETMaestos2
    Public Lista As List(Of ETRuma) = Nothing
    Dim concepto As String
    Dim ApruebaJefatura As String
    Dim ApruebaTesoreria As String
    Dim FechaApruebaJefatura As Date = "01-08-1969 06:00:00"
    Dim FechaApruebaTesoreria As Date = "01-08-1969 06:00:00"
    Dim userApruebaJefatura As String
    Dim txt_ruta As String
    Dim pdf As String
    Dim newFile As String = ""


#Region "FuncionesGenerales"
    Private Sub ObtenerDataTrabajador()
        ETMaestros2 = New ETMaestos2

        ETMaestros2.Codigo = TxtCodigoTrabajador.Text
        Negocio.Maestro = New NGMaestro

        dtUsuario = Negocio.Maestro.ObtenerDataTrabajador(ETMaestros2)
        If dtUsuario.Rows.Count > 0 Then
            Try
                TxtNombresTrabajador.Text = dtUsuario.Rows(0)("nomTrabajador")
                cbArea.SelectedValue = dtUsuario.Rows(0)("codarea")
                txtJefeArea.Text = dtUsuario.Rows(0)("nomjefe")

            Catch ex As Exception
                MsgBox(ex.Message, "Falta información del trabajador")
            End Try
        End If
    End Sub
    Private Sub LimpiarDatos()
        Try
            Button4.Visible = False
            TxtCodigoTrabajador.ReadOnly = False
            Me.TxtCodigoTrabajador.Clear()
            Me.TxtNombresTrabajador.Clear()
            Me.txtJefeArea.Clear()
            Me.txtMotivo.Clear()
            Me.txttotal.Clear()
            Me.lblNroSolicitud.Text = ""
            Me.lblIdDetalle.Text = ""
            Me.txtMonto.Clear()
            Me.txtDescripción.Clear()
            Me.txtBeneficiario.Text = ""
            Me.txtNomBanco.Text = ""
            Me.txtDNI.Text = ""
            Me.txtNroCuenta.Text = ""
            txt_ruta = ""

            dtFechaLimite.Value = Date.Now
            dtFechaCrea.Value = Date.Now

            cmbArea.Value = 0
            cboEstado.SelectedIndex = 0
            cbMoneda.SelectedValue = "01"
            cbMoneda.Enabled = True
            ckbJefatura.Checked = False
            ckbTesoreria.Checked = False
            codTrabajador = String.Empty
            nomTrabajador = String.Empty
            ctatrabajadorini = String.Empty
            bcotrabajadorini = String.Empty
            montosolicitud = 0
            printPDF.Visible = False
            btnAddPDF.Enabled = True
            btnvisualizar.Enabled = False
            GroupBox2.Visible = False
            pdf = ""

            For i As Int32 = grdDetalle.Rows.Count - 1 To 0 Step -1
                grdDetalle.Rows(i).Delete()
            Next


        Catch ex As Exception

        End Try

        'Ope = 0
    End Sub
    Sub CargarAreass()
        'Llenar Combos de motivo
        ETMaestros2 = New ETMaestos2

        ETMaestros2.Usuario = User_Sistema
        Negocio.Maestro = New NGMaestro

        dtArea = Negocio.Maestro.ConsultarAreas(ETMaestros2)

        Try


            cbArea.DisplayMember = "descrip"
            cbArea.ValueMember = "Cod_Maestro2"
            cbArea.DataSource = dtArea
            cbArea.DropDownStyle = ComboBoxStyle.DropDownList
        Catch ex As Exception
            MsgBox(ex.Message, "Motivos no encontrados")
        End Try

        'Try
        '    cboMotivo2.DisplayMember = "Descripcion"
        '    cboMotivo2.ValueMember = "Cod_Maestro3"
        '    cboMotivo2.DataSource = dtMotivo2

        'Catch ex As Exception
        '    MsgBox(ex.Message, "Motivos no encontrados")
        'End Try

    End Sub
    Private Sub CargarMonedass()
        ETMaestros2 = New ETMaestos2

        ETMaestros2.Usuario = User_Sistema
        Negocio.Maestro = New NGMaestro

        dtMoneda = Negocio.Maestro.ConsultarMonedas(ETMaestros2)

        Try

            cbMoneda.DisplayMember = "descrip"
            cbMoneda.ValueMember = "Cod_Maestro2"
            cbMoneda.DataSource = dtMoneda
            cbMoneda.SelectedValue = "01"
        Catch ex As Exception
            MsgBox(ex.Message, "Motivos no encontrados")
        End Try
    End Sub
    Private Sub CargarConceptos()
        ETMaestros2 = New ETMaestos2

        ETMaestros2.Usuario = User_Sistema
        Negocio.Maestro = New NGMaestro

        dtConcepto = Negocio.Maestro.ConsultarConceptos(ETMaestros2)

        Try

            cboConcepto.DisplayMember = "descripcion"
            cboConcepto.ValueMember = "codConcepto"
            cboConcepto.DataSource = dtConcepto

        Catch ex As Exception
            MsgBox(ex.Message, "Motivos no encontrados")
        End Try
    End Sub
    Public Function PermisosBotones(ByVal nomreBoton As String) As Boolean

        ETMaestros2 = New ETMaestos2

        ETMaestros2.Usuario = User_Sistema
        ETMaestros2.Codigo = "FrmSolicitudPlanilla"
        ETMaestros2.descripcion = nomreBoton
        Negocio.Maestro = New NGMaestro

        dtPermisos = Negocio.Maestro.ConsultarPermisos(ETMaestros2)

        If (dtPermisos.Rows.Count > 0) Then
            PermisosBotones = True
        Else
            PermisosBotones = False
        End If

    End Function
    Private Sub BloquearCampos(ByVal block As Boolean)



        TxtCodigoTrabajador.Enabled = block
        txtMotivo.Enabled = block
        TxtNombresTrabajador.Enabled = block
        dtFechaLimite.Enabled = block
        dtFechaCrea.Enabled = block
        txtJefeArea.Enabled = block
        txtBeneficiario.Enabled = block
        txtNomBanco.Enabled = block
        txtDNI.Enabled = block
        txtNroCuenta.Enabled = block

        'cbArea.Enabled = block
        UltraGroupBox2.Enabled = block
        txtMotivo.Enabled = block
        cbMoneda.Enabled = block
        'cboEstado.Enabled = block

        'cboEstado.Enabled = PermisosBotones(cboEstado.Name)

        If userApruebaJefatura = User_Sistema Then
            ckbJefatura.Enabled = True
        Else
            ckbJefatura.Enabled = False
        End If

        ckbTesoreria.Enabled = PermisosBotones(ckbTesoreria.Name)




    End Sub
    Sub Anulado()

        TxtCodigoTrabajador.Enabled = False
        txtMotivo.Enabled = False
        TxtNombresTrabajador.Enabled = False
        dtFechaLimite.Enabled = False
        dtFechaCrea.Enabled = False
        txtJefeArea.Enabled = False
        txtBeneficiario.Enabled = False
        txtNomBanco.Enabled = False
        txtDNI.Enabled = False
        txtNroCuenta.Enabled = False

        cbArea.Enabled = False
        UltraGroupBox2.Enabled = False
        txtMotivo.Enabled = False
        cbMoneda.Enabled = False
        cboEstado.Enabled = False
        ckbJefatura.Enabled = False
        ckbTesoreria.Enabled = False

        GroupBox1.Enabled = False

        GroupBox2.Enabled = False

    End Sub
    Private Sub ObtenerRuta()
        Negocio.Maestro = New NGMaestro
        ETMaestros2 = New ETMaestos2

        ETMaestros2.Ciamaestro = "01213"

        dtRuta = Negocio.Maestro.ConsultasMaestros2(ETMaestros2)
    End Sub
#End Region

#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private Ope As String
    Private OpeCab As String
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

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Private Sub CargarDatos()
        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas

        Entidad.Entregas.Usuario = User_Sistema

        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto

        Dim dt As New DataTable
        dt = _objNegocio_.ListarEntregasSolicitudPlanilla(User_Sistema)
        Call CargarUltraGridxBinding(Me.GridSolicitudes, Source1, dt)
    End Sub


    Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GridSolicitudes_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridSolicitudes.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot GridSolicitudes Then Return

        If e.Row.IsFilterRow Then Return
        printPDF.Visible = False
        printPDF.Navigate("")
        lblNroSolicitud.Text = e.Row.Cells("Nro_Solicitud").Value
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString

        TxtCodigoTrabajador.Text = e.Row.Cells("codtrabajador").Value
        TxtNombresTrabajador.Text = e.Row.Cells("nomTrabajador").Value
        txtJefeArea.Text = e.Row.Cells("jefeArea").Value
        dtFechaCrea.Value = e.Row.Cells("fechacrea").Value
        dtFechaLimite.Value = e.Row.Cells("fec_limite").Value
        txtMotivo.Text = e.Row.Cells("motivo").Value
        txttotal.Text = e.Row.Cells("Total").Value
        txtBeneficiario.Text = e.Row.Cells("beneficiario").Value
        txtNomBanco.Text = e.Row.Cells("nomBanco").Value
        txtDNI.Text = e.Row.Cells("nroDNI").Value
        txtNroCuenta.Text = e.Row.Cells("nroCuenta").Value


        If RTrim(e.Row.Cells("TesoreriaAprueba").Value) <> "" Then
            ckbTesoreria.Checked = True
            ApruebaTesoreria = RTrim(e.Row.Cells("TesoreriaAprueba").Value)
            FechaApruebaTesoreria = e.Row.Cells("fechaApruebaTeso").Value
        Else
            ckbTesoreria.Checked = False
            ApruebaTesoreria = ""
            FechaApruebaTesoreria = "01-08-1969 06:00:00"
        End If
        If RTrim(e.Row.Cells("jefaturaAprueba").Value) <> "" Then
            ckbJefatura.Checked = True
            ApruebaJefatura = RTrim(e.Row.Cells("jefaturaAprueba").Value)
            FechaApruebaJefatura = e.Row.Cells("fechaApruebaJefa").Value
        Else
            ckbJefatura.Checked = False
            ApruebaJefatura = ""
            FechaApruebaJefatura = "01-08-1969 06:00:00"
        End If

        userApruebaJefatura = RTrim(e.Row.Cells("usuarioJefe").Value)

        Select Case (e.Row.Cells("cod_moneda").Value)
            Case Is = "S  "
                cbMoneda.SelectedValue = "01"
            Case Is = "D  "
                cbMoneda.SelectedValue = "02"
            Case Is = "E  "
                cbMoneda.SelectedValue = "03"
        End Select
        cboEstado.SelectedIndex = e.Row.Cells("cod_estado").Value - 1

        cbArea.SelectedValue = e.Row.Cells("codarea").Value

        Dim dtDetalle As New DataTable
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        dtDetalle = _objNegocio_.SolicitudDetalle(e.Row.Cells("Nro_Solicitud").Value)

        Call CargarUltraGridxBinding(grdDetalle, Source2, dtDetalle)

        Button4.Visible = True
        If e.Row.Cells("cod_estado").Value = "1" Then
            BloquearCampos(True)
            GroupBox2.Visible = False
            btnAnular.Visible = True
        Else
            BloquearCampos(False)
            GroupBox2.Visible = True
            ckbJefatura.Enabled = False
            ckbTesoreria.Enabled = False
        End If

        If RTrim(e.Row.Cells("TesoreriaAprueba").Value) <> "" Then

            BloquearCampos(False)
        End If
        If RTrim(e.Row.Cells("jefaturaAprueba").Value) <> "" Then

            BloquearCampos(False)
        End If


        TxtCodigoTrabajador.ReadOnly = True
        btnAddPDF.Enabled = False
        btnvisualizar.Enabled = True
        GroupBox2.Enabled = True
        GroupBox1.Enabled = True

        If e.Row.Cells("cod_estado").Value = "3" Then
            BtnReporte.Visible = True
            btnAddPDFP.Enabled = False
        ElseIf e.Row.Cells("cod_estado").Value = "4" Then
            Button4.Visible = False
            BtnReporte.Visible = False
            btnAnular.Visible = False
            Anulado()
            ckbJefatura.Enabled = False
            ckbTesoreria.Enabled = False
        End If


    End Sub

    Private Sub GridSolicitudes_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles GridSolicitudes.DragDrop

    End Sub

    Private Sub GridSolicitudes_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles GridSolicitudes.DragEnter

    End Sub

    Private Sub GridSolicitudes_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridSolicitudes.InitializeLayout

    End Sub

    Private Sub FrmSolicitudPlanilla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call CargarAreass()
        Call CargarMonedass()
        Call CargarConceptos()
        Call ObtenerRuta()

        BloquearCampos(True)
        CargarDatos()

        LimpiarDatos()
    End Sub

    Private Sub grdDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)

    End Sub

    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        pnlRegistrar.Visible = True
        BloquearCampos(False)
        txtMonto.Clear()
        txtDescripción.Clear()
        lblIdDetalle.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        pnlRegistrar.Visible = False
        BloquearCampos(True)
    End Sub

    Private Sub grdDetalle_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdDetalle.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot grdDetalle Then Return
        e.DisplayPromptMsg = Boolean.FalseString
    End Sub

    Private Sub grdDetalle_DoubleClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdDetalle.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot grdDetalle Then Return

        If e.Row.IsFilterRow Then Return
        pnlRegistrar.Visible = True
        BloquearCampos(False)
        lblIdDetalle.Text = e.Row.Cells("idDetalle").Value
        cboConcepto.SelectedValue = e.Row.Cells("codConcepto").Value
        txtDescripción.Text = e.Row.Cells("descripcion").Value

    End Sub

    Private Sub grdDetalle_InitializeLayout_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdDetalle.InitializeLayout

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Validaciones
        If TxtNombresTrabajador.Text = "" Or txtJefeArea.Text = "" Then
            MessageBox.Show("Validar información del trabajador", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        ElseIf txtMonto.Text = "" Then
            MessageBox.Show("Ingresar monto del concepto", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim idDetalle As String

        If lblNroSolicitud.Text = "" Then
            OpeCab = "C"
            CrearSolicitud()
        End If

        idDetalle = lblIdDetalle.Text
        If idDetalle = "" Then
            Ope = "C"
            idDetalle = "0"
        Else
            Ope = "U"
        End If

        If lblNroSolicitud.Text <> "" Then

            CrearDetalle(Ope, idDetalle)

            TxtCodigoTrabajador.ReadOnly = True
            Button4.Visible = True
            btnAddPDF.Enabled = False
            btnvisualizar.Enabled = True

            pnlRegistrar.Visible = False
            BloquearCampos(True)
            btnAnular.Visible = True
        End If

    End Sub
    Sub CrearDetalle(ByVal ope As String, ByVal idDetalle As String)

        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing


        oPrvFisN = New NGProveedorFiscalizado
        oPrvFisE = New ETProveedorFiscalizado

        Dim dt As New DataTable

        With oPrvFisE
            .cod_labor = ope
            .TipoDoc = idDetalle
            ._numsolicitud = lblNroSolicitud.Text
            .Cod_Cia = Companhia
            If ope = "D" Then
                .Monto = 0.0
                .Cod_Prod = grdDetalle.ActiveRow.Cells("codConcepto").Value
            Else
                .Monto = Convert.ToDouble(txtMonto.Text)
                .Cod_Prod = Convert.ToString(cboConcepto.SelectedValue)
            End If
            .Observacion = txtDescripción.Text
        End With



        Try
            dt = oPrvFisN.SolicitudPlanilla_Det(oPrvFisE)

            Call CargarUltraGridxBinding(grdDetalle, Source2, dt)

            If dt.Rows.Count > 0 Then
                txttotal.Text = Convert.ToString(dt.Rows(0)("total"))
            Else
                txttotal.Text = "0.00"
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error en el procesamiento", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'LimpiarDatos()
        End Try

    End Sub
    Sub CrearSolicitud()

        Dim codSolicitud As String


        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing

        oPrvFisN = New NGProveedorFiscalizado
        oPrvFisE = New ETProveedorFiscalizado

        With oPrvFisE
            .cod_labor = OpeCab
            .Cod_Cia = Companhia
            If OpeCab = "C" Then

                .Cod_Prov = ""
                .Status = "1"
            Else
                .gre_chofer_nombres = ApruebaJefatura
                .gre_transp_nombre = ApruebaTesoreria
                .Cod_Prov = lblNroSolicitud.Text
                .Status = cboEstado.SelectedIndex + 1
            End If
            .FechIniVig = FechaApruebaJefatura
            .FechFinVig = FechaApruebaTesoreria
            .cod_trabajador = TxtCodigoTrabajador.Text
            .cod_area = Convert.ToString(cbArea.SelectedValue)
            .Observacion = txtMotivo.Text
            .Fecha = dtFechaLimite.Value

            .User_Crea = User_Sistema
            .Fecha_Crea = Date.Now
            Select Case (cbMoneda.SelectedValue)
                Case Is = "01"
                    .tipo_mov = "S"
                Case Is = "02"
                    .tipo_mov = "D"
                Case Is = "03"
                    .tipo_mov = "E"
            End Select
            .gre_dest_nombre = txtBeneficiario.Text
            .gre_ptollegada_direccion = txtNomBanco.Text
            .gre_ptollegada_ruc_establecimiento = txtDNI.Text
            .gre_vehiculo_pri_nrotarjeta_circulacion = txtNroCuenta.Text
        End With
        codSolicitud = oPrvFisN.SolicitudPlanilla(oPrvFisE).Rows(0)(0)
        MessageBox.Show("Se guardó Correctamente el registro", Mensaje.Comacsa, MessageBoxButtons.OK)
        lblNroSolicitud.Text = codSolicitud

        If OpeCab = "C" Then

            subirPDF()
        End If

    End Sub

    Private Sub TabMaestroEntregas_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabMaestroEntregas.SelectedTabChanged
        If TabMaestroEntregas.Tabs(0).Selected = True Then
            CargarDatos()
            BtnReporte.Visible = False
            btnAnular.Visible = False
        End If
    End Sub

    Private Sub UltraLabel19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel19.Click

    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtMonto.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.ValueChanged

    End Sub

    Private Sub cboConcepto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConcepto.SelectedIndexChanged

    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        If grdDetalle.ActiveRow Is Nothing Then
            MessageBox.Show("No tiene un producto seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim idDetalle As String
        idDetalle = Convert.ToString(grdDetalle.ActiveRow.Cells("iddetalle").Value)

        If MsgBox("¿Desea eliminar el registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
            Ope = "D"
            CrearDetalle(Ope, idDetalle)
        End If


    End Sub
    Sub Buscar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If TxtCodigoTrabajador.Focused = True Then

            Dim FRM As New FrmListadoPersonal
            FRM.ShowDialog()
            If codTrabajador.ToString.Trim = "" Then Return
            TxtCodigoTrabajador.Text = codTrabajador.ToString.Trim
            ObtenerDataTrabajador()
        End If
        Exit Sub

    End Sub

    Private Sub TxtCodigoTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoTrabajador.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If TxtCodigoTrabajador.Text.ToString.Trim = "" Then
            Buscar()
            Return
        End If
        ObtenerDataTrabajador()

    End Sub
    Private Sub TxtCodigoTrabajador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoTrabajador.KeyPress

    End Sub

    Private Sub TxtCodigoTrabajador_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoTrabajador.ValueChanged

    End Sub

    Private Sub cbMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMoneda.SelectedIndexChanged

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        BloquearCampos(True)
        LimpiarDatos()
        TabMaestroEntregas.Tabs("Registro").Selected = True
        BtnReporte.Visible = False
        GroupBox2.Enabled = True
        GroupBox1.Enabled = True
    End Sub

    Private Sub lblestado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
        If cboEstado.Text = "Procesado" Then

        ElseIf cboEstado.Text = "Anulado" Then

        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        OpeCab = "U"
        CrearSolicitud()
        If cboEstado.Text <> "PENDIENTE" Then
            BloquearCampos(True)
        End If
        If ckbJefatura.Checked = True Or ckbTesoreria.Checked = True Then
            BloquearCampos(False)
        Else
            BloquearCampos(True)
        End If
        If ckbJefatura.Checked = True And ckbTesoreria.Checked = True Then
            GroupBox2.Visible = True
        Else
            GroupBox2.Visible = False
        End If
    End Sub

    Private Sub ckbJefatura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbJefatura.CheckedChanged
        If ckbJefatura.Checked = True Then
            ApruebaJefatura = User_Sistema
            FechaApruebaJefatura = Date.Now
        Else
            ApruebaJefatura = ""
            FechaApruebaJefatura = "01-08-1969 06:00:00"
        End If
        If ckbTesoreria.Checked = True And ckbJefatura.Checked = True Then
            cboEstado.SelectedIndex = 1
        Else
            cboEstado.SelectedIndex = 0


        End If
    End Sub

    Private Sub ckbTesoreria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbTesoreria.CheckedChanged
        If ckbTesoreria.Checked = True Then
            ApruebaTesoreria = User_Sistema
            FechaApruebaTesoreria = Date.Now
        Else
            ApruebaTesoreria = ""
            FechaApruebaTesoreria = "01-08-1969 06:00:00"
        End If
        If ckbTesoreria.Checked = True And ckbJefatura.Checked = True Then
            cboEstado.SelectedIndex = 1
        Else
            cboEstado.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnAddPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPDF.Click
        Dim archivo As New OpenFileDialog
        archivo.Filter = "Documento Adobe (*.pdf)|*.pdf"
        If archivo.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_ruta = archivo.FileName
        Else
            Exit Sub
        End If

        '\\198.9.9.6\comacsa\SolicitudPlanillas
    End Sub

    Private Sub subirPDF()
        Try
            newFile = ""
            If txt_ruta <> "" Then
                Dim SaveFileDialog1 As New SaveFileDialog()
                Dim fi As New IO.FileInfo(txt_ruta)


                SaveFileDialog1.Filter = "Documento Adobe (*.pdf)|*.pdf"

                SaveFileDialog1.FilterIndex = 1

                SaveFileDialog1.RestoreDirectory = True

                SaveFileDialog1.FileName = fi.Name '' nombre del documento

                If dtRuta.Rows.Count < 1 Then Exit Sub


                'Copiar en el 198.9.9.6
                Dim ruta As String = dtRuta.Rows(0)("Descripcion").ToString + SaveFileDialog1.FileName
                fi.CopyTo(ruta, True)

                Dim oldFile As String = ruta


                newFile = oldFile.Replace(System.IO.Path.GetFileNameWithoutExtension(oldFile), String.Format("S-" + lblNroSolicitud.Text, System.IO.Path.GetFileNameWithoutExtension(oldFile)))

                System.IO.File.Copy(oldFile, newFile)
                System.IO.File.Delete(oldFile)

                'Copiar en el 10.10.10.33


                ruta = "\\10.10.10.33\siscomacsa$\Ejecutables\SolicitudPlanillas\" + SaveFileDialog1.FileName
                fi.CopyTo(ruta, True)

                oldFile = ruta
                newFile = oldFile.Replace(System.IO.Path.GetFileNameWithoutExtension(oldFile), String.Format("S-" + lblNroSolicitud.Text, System.IO.Path.GetFileNameWithoutExtension(oldFile)))
                System.IO.File.Copy(oldFile, newFile)
                System.IO.File.Delete(oldFile)


                pdf = newFile
            End If

            EviarEmail(newFile)


        Catch ex As Exception
            MessageBox.Show("Ocurrió un problema al subir el archivo", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Sub EviarEmail(ByVal newFile As String)
        Try
            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .cod_equipo = OpeCab
                .Cod_Prov = lblNroSolicitud.Text
                .Presentacion = newFile
                .User_Crea = User_Sistema
            End With

            If oPrvFisN.EnviarCorreoSolicitud(oPrvFisE).Rows.Count > 0 Then
                MessageBox.Show("Se envió correctamente el correo", Mensaje.Comacsa, MessageBoxButtons.OK)
                If newFile <> "" Then
                    System.IO.File.Delete(newFile)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error al enviar el correo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub pnlRegistrar_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlRegistrar.Paint

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvisualizar.Click
        Dim ruta As String = dtRuta.Rows(0)("Descripcion").ToString + "S-" + lblNroSolicitud.Text + ".pdf"
        printPDF.BringToFront()
        btnClose.BringToFront()
        printPDF.Visible = True
        printPDF.Navigate(ruta)
        btnClose.Visible = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        printPDF.Visible = False
        printPDF.Navigate("")
        btnClose.Visible = False
    End Sub

    Private Sub btnAddPDFP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPDFP.Click
        If Not MsgBox("Una vez adjuntado el documento no podrá editarse. ¿Desea subir el documento?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
            Return
        End If

        Dim archivo As New OpenFileDialog

        archivo.Filter = "Documento Adobe (*.pdf)|*.pdf"

        If archivo.ShowDialog = Windows.Forms.DialogResult.OK Then

            txt_ruta = archivo.FileName

            Dim SaveFileDialog1 As New SaveFileDialog()
            Dim fi As New IO.FileInfo(txt_ruta)


            SaveFileDialog1.Filter = "Documento Adobe (*.pdf)|*.pdf"

            SaveFileDialog1.FilterIndex = 1

            SaveFileDialog1.RestoreDirectory = True

            SaveFileDialog1.FileName = fi.Name '' nombre del documento

            If dtRuta.Rows.Count < 1 Then Exit Sub

            Try
                'Copiar en el 198.9.9.6
                Dim ruta As String = dtRuta.Rows(0)("Descripcion").ToString + SaveFileDialog1.FileName
                fi.CopyTo(ruta, True)

                Dim oldFile As String = ruta

                Dim newFile As String
                newFile = oldFile.Replace(System.IO.Path.GetFileNameWithoutExtension(oldFile), String.Format("P-" + lblNroSolicitud.Text, System.IO.Path.GetFileNameWithoutExtension(oldFile)))

                System.IO.File.Copy(oldFile, newFile)
                System.IO.File.Delete(oldFile)

                'Copiar en el 10.10.10.33

                ruta = "\\10.10.10.33\siscomacsa$\Ejecutables\SolicitudPlanillas\" + SaveFileDialog1.FileName
                fi.CopyTo(ruta, True)

                oldFile = ruta
                newFile = oldFile.Replace(System.IO.Path.GetFileNameWithoutExtension(oldFile), String.Format("P-" + lblNroSolicitud.Text, System.IO.Path.GetFileNameWithoutExtension(oldFile)))
                System.IO.File.Copy(oldFile, newFile)
                System.IO.File.Delete(oldFile)

                pdf = newFile

                OpeCab = "U"
                EviarEmail(newFile)

                btnAddPDFP.Enabled = False
                Button4.Visible = False
                cboEstado.SelectedIndex = 2



                CrearSolicitud()
                BloquearCampos(False)
                BtnReporte.Visible = True
                ckbJefatura.Enabled = False
                ckbTesoreria.Enabled = False

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error al guardar el documento", MessageBoxButtons.OK)
            End Try

        Else
            Exit Sub
        End If



    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnvisualizarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvisualizarP.Click
        Dim ruta As String = dtRuta.Rows(0)("Descripcion").ToString + "P-" + lblNroSolicitud.Text + ".pdf"
        printPDF.BringToFront()
        btnClose.BringToFront()
        printPDF.Visible = True
        printPDF.Navigate(ruta)
        btnClose.Visible = True
    End Sub

    Private Sub BtnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReporte.Click
        nroSolicitud = lblNroSolicitud.Text
        StrucForm.FxRxSolicitudPlanilla = New FrmReporteSolicitudPlanilla
        StrucForm.FxRxSolicitudPlanilla.MdiParent = MdiParent
        StrucForm.FxRxSolicitudPlanilla.Show()
    End Sub

    Private Sub UltraLabel14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel14.Click

    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        If Not MsgBox("Una vez anulado el registro, no podrá revertirse. ¿Desea anular la solicitud?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
            Return
        End If
        Anulado()
        btnAnular.Visible = False
        OpeCab = "D"
        CrearSolicitud()
        Button4.Visible = False
    End Sub

End Class