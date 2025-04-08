Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmSalidaTransferencia

    '   *****   VARIBALES   *****
    Dim dt_GR As New DataTable
    Dim dtSerie As New DataTable
    Dim movimientos As New DataTable
    Dim dtNumeroMovimientoAlmacen As New DataTable

    Dim Serie As String
    Dim xTipoCambio As String
    Dim NumeroMovimiento As String
    Dim NumeroInternoMovimiento As String
    Dim xNumeroIngresoXorden As String
    Dim xNumeroInternoIngresoXorden As String

    '   *****   LISTAS  *****   
    Dim DetalleGuia As New List(Of ETGuia)
    Dim Guia

    Dim Pedido As New List(Of ETPedido)
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Publicas"

#Region "Grabar"
    Public Sub Grabar()
        TxtNumeroMovimiento.Focus()
        If ValidarGrabar() = False Then Return
        xTipoCambio = TipoCambio()
        If MsgBox("¿Esta seguro de grabar la Salida Por Transferencia.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            With Entidad.Guia
                .Cod_Cia = Companhia
                .Tipo_Doc = "ST"
                .Tipo_Mov = CboTipoMovimiento.Value
                .NumDoc = xNumeroIngresoXorden
                .NumInterno = xNumeroInternoIngresoXorden
                .Cod_Alm = CboAlmacen.Value
                .Cod_Alm2 = CboAlmacenDestino.Value
                .Status = "T"
                .Mov_Stock = "1"
                .User_Crea = User_Sistema
                .PtoVta = "000"
                .NroHrs = "0"
                .CapacTransp = "0"
                .CostoMin = "0"
                .Kilometraje = "0"
                .Peso_Contenedor = "0"
                .Peso_Aduanas = "0"
                .Cod_Labor = ""
                If CboAlmacen.Value = 35 And CboAlmacenDestino.Value > 35 Then
                    .Cod_Cantera = GR_CodigoCantera
                    .Cod_Cli = GR_CodigoRazonSocialDestinatario
                    .RazSoc = GR_RazonSocialDestinatario
                    .Ruc = GR_RucDestinatario
                    .Dir = GR_Direccion_I
                    .Cod_Ubi = GR_CodigoUbicacion_I
                    .Dir2 = "CANTERA" + GR_Cantera
                    .Cod_Ubi2 = GR_CodigoUbicacion
                Else
                    .Cod_Cantera = ""
                    .Cod_Cli = Trim(LblCodigo.Text & "")
                    .RazSoc = Trim(LblRazonSocial.Text)
                    .Dir = ""
                    .Cod_Ubi = ""
                    .Dir2 = ""
                    .Cod_Ubi2 = ""
                    .Ruc = ""
                End If

                .Cod_Per = ""
                .Cod_Area = ""
                .Tipo_DocOri = ""
                .Doc_Ori = ""
                .Obs = ""
                .TipDocRef = "GU"
                .NumDocRef = LblSerieGuia.Text + LblNumeroGuia.Text
                .TipoDespacho = "0"
            End With

            With Entidad.Almacen
                .Cod_Cia = Companhia
                .Tipo_Mov = CboTipoMovimiento.Value
                .Tipo_Doc = "ST"
                .Num_Doc = xNumeroIngresoXorden
                .Cod_Transp = GR_CodigoRazonSocialTransportista
                .Raz_Soc = GR_RazonSocialTransportista
                .Ruc = GR_RucTransportista
                .Placa = GR_Placa
                .Cod_Chofer = "000"
                .Nom_Chofer = GR_NombreChofer
                .Marca = GR_Marca
                .Cert_Inscrip = GR_CertificadoInscripcion
                .Lic_Conducir = GR_Licencia
                .Dni_Chofer = ""
                .Dni_Destinatario = GR_DniDestinatario
                .Enviado_a = GR_Enviado
                .User_Crea = User_Sistema
            End With


            For i As Integer = 0 To dgvDetalleSalidaTransferencia.Rows.Count - 1
                Guia = New ETGuia
                With Guia
                    .cod_cia = Companhia                                                         '**
                    .tipo_mov = CboTipoMovimiento.Value                                     '**
                    .tipo_doc = "ST"                                                        '**
                    .numdoc = xNumeroIngresoXorden                                          '**
                    .numInterno = xNumeroInternoIngresoXorden                               '**
                    .cod_cli = "00000000"                                                   '**
                    .item = i + 1                                                           '**
                    .cod_prod = dgvDetalleSalidaTransferencia.Rows(i).Cells("Codigo").Value       '**
                    .descrip = dgvDetalleSalidaTransferencia.Rows(i).Cells("Descripcion").Value   '**
                    .unid = dgvDetalleSalidaTransferencia.Rows(i).Cells("UM").Value           '**
                    .cant_ing = dgvDetalleSalidaTransferencia.Rows(i).Cells("Cantidad").Value     '**
                    .moneda = "S/."                                                         '**
                    .tipo_cambio = xTipoCambio                                              '**
                    .precio = 0                                                             '**
                    .dcto = 0                                                               '**
                    .total = 0                                                              '**
                    .user_crea = User_Sistema                                                   '**
                    .item_fact = 0                                                          '**
                    .cod_prodpdc = dgvDetalleSalidaTransferencia.Rows(i).Cells("Codigo").Value    '**
                    .tipprod = dgvDetalleSalidaTransferencia.Rows(i).Cells("TipoProducto").Value  '**
                    .codorigen = ""                                                         '**
                    .und_oc = ""                                                            '**
                    .cant_oc = 0                                                            '**
                    If IsDBNull(dgvDetalleSalidaTransferencia.Rows(i).Cells("OrdenCompra").Value) = True Then
                        .num_ord_exp = ""
                    Else
                        .num_ord_exp = dgvDetalleSalidaTransferencia.Rows(i).Cells("OrdenCompra").Value
                    End If
                    .factm = "0"                                                            '**
                    .cant_dev = "0"                                                         '**
                    .movi = "S"                                                             '**
                    .nro_blsini = "0"                                                       '**
                    .nro_blsfin = "0"                                                       '**
                    .hrs_lab = "0"                                                          '**
                    .peso_bls = "0"                                                         '**
                    .cant_ped = "0"                                                         '**
                    .largo = "0"                                                            '**
                    .ancho = "0"                                                            '**
                    .piezas = "0"                                                           '**
                    .encajado = "0"                                                         '**
                    .lleno = "0"                                                            '**
                    .espesor = "0"                                                          '**
                    .Cod_Empleo = ""                                                        '**
                    .Cod_Cantera = ""                                                       '**
                    .ctacosto = ""                                                          '**
                    .cod_equipo = ""                                                        '**
                    .facturado = ""                                                         '**
                    .valorizacion = "0"                                                     '**

                    If IsDBNull(dgvDetalleSalidaTransferencia.Rows(i).Cells("OrdenCompra").Value) = False Then
                        .IndicadorEnvio = "1"
                    End If

                End With
                DetalleGuia.Add(Guia)
            Next

            If TxtNumeroMovimiento.Text = "" Then
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("AGR", CboTipoMovimiento.Value, "ST", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)
            Else
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("MOD", CboTipoMovimiento.Value, "ST", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)
            End If

            If Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text = "" Then
                MsgBox("Se generó la Salida Por Transferencia N° " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            ElseIf Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text <> "" Then
                MsgBox("Se modificó la Salida Por Transferencia N° " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            Call Nuevo()
        End If

    End Sub

#End Region

#Region "Buscar"
    Public Sub Buscar()
        If TabSalidaTransferencia.Tabs("Listar").Selected = True Then
            If Len(TxtNumeroDocumento.Text) = 0 Then
                Call ListarMovimientoSalidaTransferencia("", "LFE")
                If movimientos.Rows.Count > 0 Then
                    DgvSalidaTransferencia.DataSource = movimientos
                Else
                    MsgBox("No existen billete(s) generados el dia " & DtFechaConsulta.Value & " .", MsgBoxStyle.Critical, "Comacsa")
                    TxtNumeroDocumento.Clear()
                    TxtNumeroDocumento.Focus()
                    Return
                End If

            Else
                Call ListarMovimientoSalidaTransferencia(Trim(TxtNumeroDocumento.Text & ""), "LNU")
                If movimientos.Rows.Count > 0 Then
                    TabSalidaTransferencia.Tabs("Salida").Selected = True
                    dtFeStringegistro.Value = movimientos.Rows(0).Item("Fecha")
                    CboTipoMovimiento.Value = movimientos.Rows(0).Item("CodigoTipoMovimiento")
                    CboAlmacen.Value = movimientos.Rows(0).Item("CodigoAlmacen")
                    CboAlmacenDestino.Value = movimientos.Rows(0).Item("CodigoAlmacenDestino")
                    LblSerieGuia.Text = Mid((movimientos.Rows(0).Item("NumeroGuia")), 1, 4)
                    LblNumeroGuia.Text = Mid((movimientos.Rows(0).Item("NumeroGuia")), 5, 16)
                    LblEstado.Text = movimientos.Rows(0).Item("Estado")
                    TxtNumeroMovimiento.Text = Trim(TxtNumeroDocumento.Text & "")

                    With Entidad.Guia
                        .Cod_Cia = Companhia
                        .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
                        .Cod_Alm = CboAlmacen.Value
                    End With
                    dgvDetalleSalidaTransferencia.DataSource = Negocio.Guia.ListarDetalleSalidaTransferencia(Entidad.Guia)

                Else
                    MsgBox("El billete " & TxtNumeroDocumento.Text & " NO existe o ha sido creado por otro usuario.", MsgBoxStyle.Critical, "Comacsa")
                    TxtNumeroDocumento.Clear()
                    TxtNumeroDocumento.Focus()
                    Return
                End If
            End If

        Else

            With dgvDetalleSalidaTransferencia
                Select Case .ActiveCell.Column.Key

                    Case "Codigo"
                        Dim Productos As New FrmListarProductos
                        gAlmacen = CboAlmacen.Value
                        Productos.ShowDialog()
                        dgvDetalleSalidaTransferencia.ActiveRow.Cells("Codigo").Value = Productos.CODIGO
                        dgvDetalleSalidaTransferencia.ActiveRow.Cells("Stock").Value = Productos.STOCK
                        dgvDetalleSalidaTransferencia.ActiveRow.Cells("Descripcion").Value = Productos.DESCRIPCION
                        dgvDetalleSalidaTransferencia.ActiveRow.Cells("UM").Value = Productos.UNIDADMEDIDA
                        dgvDetalleSalidaTransferencia.ActiveRow.Cells("TipoProducto").Value = Productos.TIPO_PRODUCTO

                End Select
            End With
        End If

    End Sub
#End Region

#Region "Nuevo"
    Public Sub Nuevo()
        TabSalidaTransferencia.Tabs("Salida").Selected = True
        LblCodigo.Text = ""
        LblRuc.Text = ""
        LblRazonSocial.Text = ""
        LblLugarEntrega.Text = ""
        LblSerieGuia.Clear()
        LblNumeroGuia.Clear()
        CboAlmacen.Value = 28
        RdbInterna.Checked = True
        CboAlmacenDestino.SelectedIndex = -1
        BtnPendientes.Visible = False
        BtnGuia.Visible = False

        'Dim i As Integer = dgvDetalleSalidaTransferencia.Rows.Count - 1
        'While i >= 0
        '    dgvDetalleSalidaTransferencia.Rows(i).Delete()
        '    i = dgvDetalleSalidaTransferencia.Rows.Count - 1
        'End While




        TxtNumeroMovimiento.Clear()
    End Sub
#End Region

#End Region      'Funciones Publicas

#Region "Funciones Locales"

#Region "Listar Movimientos Ingreso Sin Orden Compra"
    Private Sub ListarMovimientoSalidaTransferencia(ByVal Documento As String, ByVal Opcion As String)
        With Entidad.Guia
            Dim ab, cd As String
            .Cod_Cia = Companhia
            .NumDoc = Documento
            .Tipo_Doc = "ST"
            .Ano = Year(DtFechaConsulta.Value)
            .User_Crea = User_Sistema
            ab = Month(DtFechaConsulta.Value)
            cd = Microsoft.VisualBasic.DateAndTime.Day(DtFechaConsulta.Value)

            If Len(ab) = 1 Then
                .Mes = "0" & Month(DtFechaConsulta.Value)
            Else
                .Mes = Month(DtFechaConsulta.Value)
            End If

            If Len(cd) = 1 Then
                .Mes = "0" & Microsoft.VisualBasic.DateAndTime.Day(DtFechaConsulta.Value)
            Else
                .Dia = Microsoft.VisualBasic.DateAndTime.Day(DtFechaConsulta.Value)
            End If

        End With
        movimientos = Negocio.Guia.ListarMovimientoSalidaTransferencia(Entidad.Guia, Opcion)
    End Sub
#End Region

#Region "Listar Almacen Destino X Usuario"
    Private Sub ListarAlmacenDestinoUsuario()
        With Entidad.Usuario
            .Cod_Cia = Companhia
            .Name_User = User_Sistema
            .Cod_Almacen = CboAlmacen.Value
        End With
        CboAlmacenDestino.DataSource = Negocio.Usuario.MovimientosAlmacen(Entidad.Usuario, "AUX")
        CboAlmacenDestino.DisplayMember = "Descripcion"
        CboAlmacenDestino.ValueMember = "Codigo"
        CboAlmacenDestino.SelectedIndex = -1
    End Sub
#End Region

#Region "Listar Detalle Guia Remision"
    Private Sub ListarDetalleGuiaRemision()
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Cod_Alm = CboAlmacen.Value
            .Cod_Alm2 = CboAlmacenDestino.Value
        End With
        dt_GR = Negocio.Guia.Listar_GR_Contratista(Entidad.Guia, "DC1")
    End Sub
#End Region

#Region "Validar Numero Movimiento Almacen"
    Private Function ValidarNumeroMovimientoAlmacen() As Boolean
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Tipo_Mov = Trim(CboTipoMovimiento.Value & "")
            .Tipo_Doc = "ST"
            .NumDoc = Serie + NumeroMovimiento
        End With
        dtNumeroMovimientoAlmacen = Negocio.OrdenCompraBL.DocumentosReferencia(Entidad.Guia, "VA2")

        If dtNumeroMovimientoAlmacen.Rows.Count > 0 Then
            MsgBox("El número de documento " + Serie + NumeroMovimiento + " ya fue ingresado", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Validar Grabar"
    Private Function ValidarGrabar() As Boolean

        Return True
    End Function
#End Region

#End Region       'Funciones Locales

#Region "Evento Controles"

#Region "CboAlmacen - ValueChanged"
    Private Sub CboAlmacen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAlmacen.ValueChanged
        Call ListarAlmacenDestinoUsuario()
        RdbInterna.Checked = True
        CboAlmacenDestino.SelectedIndex = -1
        BtnGuia.Visible = False
        BtnPendientes.Visible = False
    End Sub
#End Region

#Region "CboAlmacenDestino - ValueChanged"
    Private Sub CboAlmacenDestino_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAlmacenDestino.ValueChanged
        If CboAlmacenDestino.SelectedIndex = -1 Then
            LblCodigo.Text = ""
            LblRuc.Text = ""
            LblRazonSocial.Text = ""
            LblLugarEntrega.Text = ""
            LblSerieGuia.Clear()
            LblNumeroGuia.Clear()
        Else
            With Entidad.Almacen
                .Cod_Cia = Companhia
                .CodAlmacen = CboAlmacenDestino.Value
            End With
            Entidad.Resultado = Negocio.Almacen.DireccionAlmacen(Entidad.Almacen)

            LblCodigo.Text = "00000000"
            LblRuc.Text = "20100037689"
            LblRazonSocial.Text = "DEPOSITO DE " + CboAlmacenDestino.Text
            LblLugarEntrega.Text = Entidad.Resultado.Mensaje
            LblSerieGuia.Clear()
            LblNumeroGuia.Clear()
        End If

        TxtNumeroMovimiento.Clear()
       

        If DgvSalidaTransferencia.Rows.Count - 1 > 0 Then
            Dim i As Integer = dgvDetalleSalidaTransferencia.Rows.Count - 1
            While i >= 0
                dgvDetalleSalidaTransferencia.Rows(i).Delete()
                i = dgvDetalleSalidaTransferencia.Rows.Count - 1
            End While
        End If


        If CboAlmacen.Value = 35 And CboAlmacenDestino.Value > 35 Then
            Call ListarDetalleGuiaRemision()
            GR_CodigoCantera = dt_GR.Rows(0).Item("CodigoCantera")
            GR_Cantera = dt_GR.Rows(0).Item("Cantera")
            GR_Direccion = dt_GR.Rows(0).Item("Direccion")
            GR_CodigoUbicacion_I = dt_GR.Rows(0).Item("CodigoUbicacion_I")
            GR_Direccion_I = dt_GR.Rows(0).Item("Ubicacion_I")
            GR_UbicacionGeografica = dt_GR.Rows(0).Item("Ubicacion")
            GR_CodigoUbicacion = dt_GR.Rows(0).Item("CodigoUbicacion")
            GR_Enviado = dt_GR.Rows(0).Item("Destinatario")
            GR_CodigoRazonSocialDestinatario = dt_GR.Rows(0).Item("CodigoContratista")
            GR_RazonSocialDestinatario = dt_GR.Rows(0).Item("RazonSocial")
            GR_RucDestinatario = dt_GR.Rows(0).Item("RUC")
            GR_DniDestinatario = dt_GR.Rows(0).Item("DNI")
            GR_CodigoRazonSocialTransportista = ""
            GR_RazonSocialTransportista = ""
            GR_RucTransportista = ""
            GR_Marca = ""
            GR_Placa = ""
            GR_CertificadoInscripcion = ""
            GR_Licencia = ""
            GR_NombreChofer = ""
        End If

        If RdbExterna.Checked = True And CboAlmacen.Value = 35 And CboAlmacenDestino.Value > 35 Then
            BtnGuia.Visible = True
            BtnPendientes.Visible = True
        Else
            BtnGuia.Visible = False
            BtnPendientes.Visible = False
        End If

    End Sub

#End Region

#Region "BtnGuia - Click"
    Private Sub BtnGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuia.Click
        Dim Guia As New FrmDatosGuia
        Guia.ShowDialog()

        GR_CodigoRazonSocialTransportista = Guia.CodigoRazonSocialTransportista
        GR_RazonSocialTransportista = Guia.RazonSocialTransportista
        GR_RucTransportista = Guia.RucTransportista
        GR_Marca = Guia.Marca
        GR_Placa = Guia.Placa
        GR_CertificadoInscripcion = Guia.CertificadoInscripcion
        GR_Licencia = Guia.Licencia
        GR_NombreChofer = Guia.NombreChofer

    End Sub
#End Region

#Region "RdbInterna - CheckedChanged"
    Private Sub RdbInterna_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbInterna.CheckedChanged
        If RdbInterna.Checked = True Then
            BtnPendientes.Visible = False
            BtnGuia.Visible = False
        End If
    End Sub
#End Region

#Region "RdbExterna - CheckedChanged"
    Private Sub RdbExterna_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbExterna.CheckedChanged
        If RdbExterna.Checked = True And CboAlmacen.Value = 35 And CboAlmacenDestino.Value > 35 Then
            BtnPendientes.Visible = True
            BtnGuia.Visible = True
        Else
            BtnPendientes.Visible = False
            BtnGuia.Visible = False
        End If
    End Sub
#End Region

#Region "DgvSalidaTransferencia - DoubleClickRow"
    Private Sub DgvSalidaTransferencia_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvSalidaTransferencia.DoubleClickRow
        Dim xNumeroGuia As String
        xNumeroGuia = e.Row.Cells("NumeroGuia").Value
        TabSalidaTransferencia.Tabs("Salida").Selected = True
        dtFeStringegistro.Value = e.Row.Cells("Fecha").Value
        CboTipoMovimiento.Value = e.Row.Cells("CodigoTipoMovimiento").Value
        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        CboAlmacenDestino.Value = e.Row.Cells("CodigoAlmacenDestino").Value
        LblSerieGuia.Text = Mid(xNumeroGuia, 1, 4)
        LblNumeroGuia.Text = Mid(xNumeroGuia, 5, 16)
        LblEstado.Text = e.Row.Cells("Estado").Value
        TxtNumeroMovimiento.Text = e.Row.Cells("NumeroDocumento").Value

        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
            .Cod_Alm = CboAlmacen.Value
        End With
        dgvDetalleSalidaTransferencia.DataSource = Negocio.Guia.ListarDetalleSalidaTransferencia(Entidad.Guia)

        Call UbicarCursorGrilla(dgvDetalleSalidaTransferencia, dgvDetalleSalidaTransferencia.Rows(0), "Codigo")


    End Sub
#End Region

#Region "dgvDetalleSalidaTransferencia - BeforeRowsDeleted"
    Private Sub dgvDetalleSalidaTransferencia_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvDetalleSalidaTransferencia.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
#End Region

#End Region        'Evento Controles

#Region "Load"
    Private Sub FrmSalidaTransferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarMovimientosUsuario(CboTipoMovimiento, "09")
        Call ListarAlmacenUsuarios(CboAlmacen, "28")
        Call ListarMotivoAnulacion(CboAnulacion)
        Call ListarMovimientoSalidaTransferencia("", "LTO")
        DgvSalidaTransferencia.DataSource = movimientos
        Call ListarAlmacenDestinoUsuario()
        DtFechaConsulta.Value = Now
        dtFeStringegistro.Value = Now
    End Sub
#End Region                    'Load



    Private Sub BtnPendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPendientes.Click

    End Sub
End Class