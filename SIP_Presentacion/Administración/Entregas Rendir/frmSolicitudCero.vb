Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmSolicitudCero
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
    Sub buscar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If TxtCodigoTrabajador.ReadOnly = True Then Return

        If TxtCodigoTrabajador.Focused = True Then
            Dim FRM As New FrmListadoPersonal
            FRM.ShowDialog()
            If codTrabajador.ToString.Trim = "" Then Return
            TxtCodigoTrabajador.Text = codTrabajador.ToString.Trim
            TxtNombresTrabajador.Text = nomTrabajador.ToString.Trim
            CargarAreaTrabajador(Me.TxtCodigoTrabajador.Text)
            TxtUsuario.Text = ""
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
                codCantera = ""
                Cantera = ""
            End If
        End If
        If TxtUsuario.Focused = True Then
            Dim FRM As New FrmCargarUsuario
            FRM.sistema = "22"
            FRM.codarea = cmbArea.Value
            FRM.saldo_cero = "1"
            FRM.ShowDialog()
            TxtUsuario.Text = userLogin.ToString.Trim
        End If


        Me.txtMotivo.ReadOnly = False
        Me.txtRegion.ReadOnly = False
        Me.cmbArea.ReadOnly = False
        Me.cmbCantera.ReadOnly = False
        Me.dtFechaSalida.ReadOnly = False
        Me.dtFechaRetorno.ReadOnly = False
    End Sub

    Private Sub TxtCodigoTrabajador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoTrabajador.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If TxtCodigoTrabajador.Text.ToString.Trim = "" Then
            TxtCodigoTrabajador.Focus()
            Exit Sub
        End If
        CargarTrabajadoresxCodigo(Me.TxtCodigoTrabajador.Text)
        If lResult.Ls_Entrega.Count > 0 Then
            TxtNombresTrabajador.Text = lResult.Ls_Entrega.Item(0).NomTrabajador
            bcotrabajador = lResult.Ls_Entrega.Item(0).bancobeneficiario.ToString.Trim
            ctatrabajador = lResult.Ls_Entrega.Item(0).ctabeneficiario.ToString.Trim

            Me.cmbArea.ReadOnly = False
            Me.cmbCantera.ReadOnly = False
            Me.dtFechaSalida.ReadOnly = False
            Me.dtFechaRetorno.ReadOnly = False
            CargarAreaTrabajador(Me.TxtCodigoTrabajador.Text)
        Else
            MsgBox("Código de trabajador no existe", MsgBoxStyle.Exclamation, msgComacsa)
            TxtCodigoTrabajador.Clear()
            TxtNombresTrabajador.Clear()
            TxtCodigoTrabajador.Focus()
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

    Private Sub frmSolicitudCero_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      inicio()
    End Sub
    Sub inicio()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
        Call HabilitarControles(True)
        CargarDatos()
        Call CargarMonedas()
        TxtCodigoTrabajador.ReadOnly = True
        Me.dtFechaSalida.Value = Now.Date
        Me.dtFechaRetorno.Value = Now.Date
        Call CargarAreas()
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
        Entidad.MyLista = Negocio.NEntregas.ListarSolicitudesCero(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.GridSolicitudes, Source1, Ls_Entrega)
    End Sub
    Private Sub HabilitarControles(ByVal D As Boolean)
        Me.TxtCodigoTrabajador.ReadOnly = Not D
        Me.txtMotivo.ReadOnly = D
        Me.txtRegion.ReadOnly = D
        Me.cmbArea.ReadOnly = D
        Me.cmbCantera.ReadOnly = D
        Me.dtFechaSalida.ReadOnly = D
        Me.dtFechaRetorno.ReadOnly = D
        Me.TxtCodigoTrabajador.Focus()
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

    Private Sub cmbArea_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbArea.InitializeLayout
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
    Private Sub LimpiarDatos()
        Try
            Me.TxtCodigoTrabajador.Clear()
            Me.TxtNombresTrabajador.Clear()
            Me.txtJefeArea.Clear()
            Me.txtMotivo.Clear()
            Me.txtcodCantera.Clear()
            Me.txtCantera.Clear()
            Me.txtRegion.Clear()
            Me.TxtUsuario.Clear()
           
            dtFechaSalida.Value = Now.Date
            dtFechaRetorno.Value = Now.Date
            cmbArea.Value = 0
            cmbCantera.Value = 0

            codTrabajador = String.Empty
            nomTrabajador = String.Empty
            ctatrabajadorini = String.Empty
            bcotrabajadorini = String.Empty
            montosolicitud = 0
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Nuevo()
        Ope = 1
        nroSolicitud = String.Empty
        lblnSolicitud.Visible = Boolean.FalseString
        flgaprobada = 0
        Call LimpiarDatos()
        lblestado.Visible = False
        Call HabilitarControles(True)
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        Dim fecha1 As Date = dtFechaSalida.Value
        Dim fecha2 As Date = dtFechaRetorno.Value
        Me.TxtCodigoTrabajador.Focus()
    End Sub

    Private Sub txtcodCantera_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodCantera.KeyPress
        Try
            'If flgaprobada = 1 Then Return
            Dim frm As New FrmCanteras
            frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
            frm.cadena = txtcodCantera.Text.ToString.Trim
            frm.ShowDialog()
            If Not codCantera = "" Then
                txtcodCantera.Text = codCantera
                txtCantera.Text = Cantera
                txtRegion.Text = ModVariable.Region
                codCantera = ""
                Cantera = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Grabar()
        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If


        Dim fechaSalida As Date = dtFechaSalida.Value
        Dim fechaRetorno As Date = dtFechaRetorno.Value
        Dim fechaActual As Date = Now.Date

        If TxtCodigoTrabajador.Text = "" Then
            MsgBox("Debe ingresar el código de trabajador", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If

        If txtMotivo.Text = "" Then
            MsgBox("Debe ingresar el motivo de la solicitud", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If

        If TxtUsuario.Text = "" Then
            MsgBox("Debe ingresar el usuario de aprobación", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If

        If fechaRetorno.CompareTo(fechaSalida) < 0 Then
            MsgBox("Fecha de retorno debe ser mayor a fecha de salida", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If

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
        Entidad.Entregas.codCantera = IIf(txtcodCantera.Value Is Nothing, String.Empty, txtcodCantera.Value)
        Entidad.Entregas.Region = IIf(txtRegion.Value Is Nothing, String.Empty, txtRegion.Value)
        Entidad.Entregas.moneda = IIf(cmbMoneda.Value Is Nothing, String.Empty, cmbMoneda.Text.ToString.Trim.Substring(0, 1))
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.Entregas.userlogin = TxtUsuario.Text

        Dim ls_Solicitud = Ls_Entrega.Where(Function(x) x.codConcepto.ToString.Trim <> "").FirstOrDefault

        Entidad.Entregas = Negocio.NEntregas.MantenimientoSolictudCero(Entidad.Entregas, Ls_Entrega, Ls_EntregaDetalle)

        If Entidad.Entregas.Validacion Then
            Call Nuevo()
            inicio()
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Private Sub GridSolicitudes_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridSolicitudes.DoubleClickRow
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

        If usuarioSolicitud <> User_Sistema Then esCreador = 0 Else esCreador = 1

        TxtCodigoTrabajador.ReadOnly = True

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.MyLista = New ETMyLista
        Entidad.Entregas.NumSolicitud = uRow.Cells("NumSolicitud").Value
        NumSolicitud = uRow.Cells("NumSolicitud").Value
        nroSolicitud = uRow.Cells("NumSolicitud").Value
        Entidad.MyLista = Negocio.NEntregas.SolicitudxNumero(Entidad.Entregas)

        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If

        If Entidad.MyLista.Validacion Then Call Cargar_DatosSolicitud()
        'Txt4.Value = NumSolicitud
        esCreador = uRow.Cells("flgpermiso").Value
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

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
        
            If Ls_Entrega.Count > 0 Then
                TxtCodigoTrabajador.Text = Ls_Entrega.Item(0).CodTrabajador.ToString.Trim
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
                ctatrabajador = Ls_Entrega.Item(0).ctatrabajador.ToString.Trim
                bcotrabajador = Ls_Entrega.Item(0).bcotrabajador.ToString.Trim
                montosolicitud = Ls_Entrega.Item(0).montoTotal.ToString("#####0.00")

                Dim fecha1 As Date = dtFechaSalida.Value
                Dim fecha2 As Date = dtFechaRetorno.Value
                dias = (fecha2 - fecha1).TotalDays

                Dim descripTipoDeposito As String = String.Empty

                Dim idEstado As Int32
                idEstado = Ls_Entrega.Item(0).idEstado
              
                Entidad.Entregas.NumSolicitud = NumSolicitud
                lblnSolicitud.Text = "N° Solicitud : " & NumSolicitud
                lblnSolicitud.Visible = Boolean.TrueString

                Try
                    Dim codigoConcepto As String = ""
                    Call HabilitarControles(True)
                    TxtCodigoTrabajador.ReadOnly = True
                    cmbMoneda.Enabled = False
                    dtFechaRetorno.ReadOnly = True
                    dtFechaSalida.ReadOnly = True

                    Select Case (Ls_Entrega.Item(0).moneda.ToString.Trim)
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

    Private Sub GridSolicitudes_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridSolicitudes.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "NumSolicitud" OrElse uColumn.Key = "Motivo" OrElse uColumn.Key = "FechaIngreso" OrElse _
                    uColumn.Key = "Estado" OrElse uColumn.Key = "NomTrabajador" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "moneda") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Public Sub Modificar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If nroSolicitud.ToString.Trim = "" Then Return
        Ope = 2
        Call HabilitarControles(False)
        cmbMoneda.Enabled = True
        TxtCodigoTrabajador.ReadOnly = False
    End Sub

    Sub eliminar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If nroSolicitud.ToString.Trim = "" Then Return
        'If esCreador = 0 Then MsgBox("No puede eliminar la solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
        'If flgaprobada = 1 Then MsgBox("No puede eliminar la solicitud", MsgBoxStyle.Exclamation, msgComacsa) : Return
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

        Entidad.Entregas.Usuario = User_Sistema

        Dim ls_Solicitud = Ls_Entrega.Where(Function(x) x.codConcepto.ToString.Trim <> "").FirstOrDefault

        Entidad.Entregas = Negocio.NEntregas.EliminarSolicitudCero(Entidad.Entregas, Ls_Entrega, Ls_EntregaDetalle)

        If Entidad.Entregas.Validacion Then
            'If Ope = 1 Then
            Call Nuevo()
            Call Inicio()
            'End If
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call LimpiarDatos()
        nroSolicitud = ""
        lblestado.Visible = False
        UltraLabel39.Visible = False
        Call inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Sub cancelar()
        Call LimpiarDatos()
        Me.TxtCodigoTrabajador.ReadOnly = True
        nroSolicitud = ""
        lblestado.Visible = False
        UltraLabel39.Visible = False
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
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

    Private Sub UltraTextEditor1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUsuario.KeyPress
        Dim FRM As New FrmCargarUsuario
        FRM.sistema = "22"
        FRM.codarea = cmbArea.Value
        FRM.saldo_cero = "1"
        FRM.ShowDialog()
        TxtUsuario.Text = userLogin.ToString.Trim
    End Sub

End Class