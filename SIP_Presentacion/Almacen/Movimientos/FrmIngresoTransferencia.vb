Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmIngresoTransferencia

    '   *****   VARIABLES   *****
    Dim movimientos As New DataTable
    Dim dtSerie As New DataTable
    Dim dtNumeroMovimientoAlmacen As New DataTable
    Dim xTipoCambio As String
    Dim Serie As String
    Dim NumeroMovimiento As String
    Dim NumeroInternoMovimiento As String
    Dim xNumeroIngresoXorden As String
    Dim xNumeroInternoIngresoXorden As String

    '   *****   LISTAS  *****   
    Dim DetalleGuia As New List(Of ETGuia)
    Dim Guia As ETGuia

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

#Region "Nuevo"
    Public Sub Nuevo()
        TabIngresoTransferencia.Tabs("Ingreso").Selected = True
        CboAlmacen.Value = 28
        GrpLeyenda.Visible = True
        GrpAnulacion.Visible = False
        GrpReferencia.Visible = False
        CboDocumentoReferencia.SelectedIndex = -1
        TxtDocumentoReferencia.Clear()
        CboAlmacen.ReadOnly = False
        LblDocumento.Visible = True
        CboDocumento.Visible = True
        TxtNumeroMovimiento.Clear()
        CboDocumento.SelectedIndex = -1
        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Mid(CboDocumento.Text, 1, 10)
        End With
        dgvDetalleIngresoTransferencia.DataSource = Negocio.Almacen.DocumentosIngresoTransferencia(Entidad.Guia, "L2")

    End Sub
#End Region

#Region "Grabar"
    Public Sub Grabar()
        TxtNumeroMovimiento.Focus()
        If ValidarGrabar() = False Then Return
        xTipoCambio = TipoCambio()
        If MsgBox("¿Esta seguro de grabar el Ingreso Por Transferencia.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            With Entidad.Guia
                .Cod_Cia = Companhia
                .Tipo_Doc = "IT"
                .Tipo_Mov = CboTipoMovimiento.Value
                .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
                .NumInterno = DgvIngresoTransferencia.ActiveRow.Cells("NumeroMovimientoInterno").Value
                .Cod_Alm = CboAlmacen.Value
                .Cod_Alm2 = CboDocumento.Value
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
                .Cod_Cantera = ""
                .Cod_Cli = ""
                .RazSoc = ""
                .Cod_Per = ""
                .Cod_Area = ""
                .Tipo_DocOri = Mid(CboDocumento.Text, 12, 2)
                .Doc_Ori = Mid(CboDocumento.Text, 1, 10)
                .Ruc = ""
                .Obs = ""
                .TipDocRef = ""
                .NumDocRef = ""
                .TipoDespacho = "0"
                .Status = ""
                .NumDoc2 = Mid(CboDocumento.Text, 1, 10)
            End With


            For i As Integer = 0 To dgvDetalleIngresoTransferencia.Rows.Count - 1

                Guia = New ETGuia
                With Guia
                    .cod_cia = Companhia                                                         '**
                    .tipo_mov = CboTipoMovimiento.Value                                     '**
                    .tipo_doc = "IT"                                                        '**
                    .numdoc = Trim(TxtNumeroMovimiento.Text & "")
                    .numInterno = DgvIngresoTransferencia.ActiveRow.Cells("NumeroMovimientoInterno").Value
                    .cod_cli = "00000000"                                                   '**
                    .item = i + 1                                                           '**
                    .cod_prod = dgvDetalleIngresoTransferencia.Rows(i).Cells("Codigo").Value       '**
                    .descrip = dgvDetalleIngresoTransferencia.Rows(i).Cells("Descripcion").Value   '**
                    .unid = dgvDetalleIngresoTransferencia.Rows(i).Cells("UM").Value           '**
                    .cant_ing = dgvDetalleIngresoTransferencia.Rows(i).Cells("Cantidad").Value     '**
                    .moneda = "S/."                                                         '**
                    .tipo_cambio = xTipoCambio                                              '**
                    .precio = 0                                                             '**
                    .dcto = 0                                                               '**
                    .total = 0                                                              '**
                    .User_Crea = User_Sistema                                                   '**
                    .item_fact = 0                                                          '**
                    .cod_prodpdc = dgvDetalleIngresoTransferencia.Rows(i).Cells("Codigo").Value    '**
                    .tipprod = dgvDetalleIngresoTransferencia.Rows(i).Cells("TipoProducto").Value  '**
                    .codorigen = ""                         '**
                    .und_oc = ""                                                            '**
                    .cant_oc = 0                                                            '**
                    .num_ord_exp = ""                                                       '**
                    .factm = "0"                                                            '**
                    .cant_dev = "0"                                                         '**
                    .movi = "I"                                                             '**
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
                End With
                DetalleGuia.Add(Guia)

            Next

            If TxtNumeroMovimiento.Text = "" Then
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("AGR", CboTipoMovimiento.Value, "IT", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)
            End If

            If Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text = "" Then
                MsgBox("Se generó el Ingreso Por Transferencia N° " + xNumeroIngresoXorden + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If


            Call Nuevo()
            Call ListarMovimientoIngresoTransferencia("", "LTO")
            DgvIngresoTransferencia.DataSource = movimientos
            TabIngresoTransferencia.Tabs("Listar").Selected = True
        End If
        'End If
    End Sub

#End Region

#End Region  '   Funciones Publicas

#Region "Funciones Locales"

#Region "Listar Movimientos Ingreso Por Transferencia"

    Private Sub ListarMovimientoIngresoTransferencia(ByVal Documento As String, ByVal Opcion As String)
        With Entidad.Guia
            Dim ab, cd As String
            .Cod_Cia = Companhia
            .NumDoc = Documento
            .Tipo_Doc = "IT"
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
        movimientos = Negocio.Guia.ListarIngresoTransferencia(Entidad.Guia, Opcion)
    End Sub
#End Region

#Region "Listar Documentos de Referencia"
    Private Sub ListarDocumentosReferencia()
        Negocio.Maestros2 = New NGMaestros2
        CboDocumentoReferencia.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LDR", "", Now.ToShortDateString, Now)
        CboDocumentoReferencia.DisplayMember = "Descripcion"
        CboDocumentoReferencia.ValueMember = "Codigo"
        CboDocumentoReferencia.SelectedIndex = -1
    End Sub
#End Region

#Region "Validar Grabar"
    Private Function ValidarGrabar() As Boolean
        If TxtNumeroMovimiento.Text <> "" Then
            MsgBox("No se puede modificar este billete.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Validar Numero Movimiento Almacen"
    Private Function ValidarNumeroMovimientoAlmacen() As Boolean
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Tipo_Mov = Trim(CboTipoMovimiento.Value & "")
            .Tipo_Doc = "IT"
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

#End Region   '   Funciones Locales

#Region "Evento Controles"

#Region "CboAlmacen - ValueChanged"
    Private Sub CboAlmacen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Cod_Alm = CboAlmacen.Value
        End With
        CboDocumento.DataSource = Negocio.Almacen.DocumentosIngresoTransferencia(Entidad.Guia, "L1")
        CboDocumento.DisplayMember = "Documento"
        CboDocumento.ValueMember = "Codigo"
        CboDocumento.SelectedIndex = -1
    End Sub
#End Region

#Region "CboDocumento - ValueChanged"
    Private Sub CboDocumento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDocumento.ValueChanged
        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Mid(CboDocumento.Text, 1, 10)
        End With
        dgvDetalleIngresoTransferencia.DataSource = Negocio.Almacen.DocumentosIngresoTransferencia(Entidad.Guia, "L2")
    End Sub
#End Region

#Region "DgvIngresoTransferencia - DoubleClickRow"
    Private Sub DgvIngresoTransferencia_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvIngresoTransferencia.DoubleClickRow
        TabIngresoTransferencia.Tabs("Ingreso").Selected = True
        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        TxtNumeroMovimiento.Text = e.Row.Cells("NumeroDocumento").Value
        LblDocumento.Visible = False
        CboDocumento.Visible = False
        GrpReferencia.Visible = True
        GrpLeyenda.Visible = False
        GrpAnulacion.Visible = False
        CboDocumentoReferencia.Value = e.Row.Cells("TipoDocumentoOrigen").Value
        TxtDocumentoReferencia.Text = e.Row.Cells("DocumentoOrigen").Value
        CboAlmacen.ReadOnly = True

        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
        End With
        dgvDetalleIngresoTransferencia.DataSource = Negocio.Almacen.DocumentosIngresoTransferencia(Entidad.Guia, "L3")

    End Sub
#End Region

#End Region    '   Evento Controles

#Region "Load"
    Private Sub FrmIngresoTransferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtFechaConsulta.Value = Now
        dtFeStringegistro.Value = Now
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarDocumentosReferencia()
        Call ListarMovimientosUsuario(CboTipoMovimiento, "03")
        Call ListarMovimientoIngresoTransferencia("", "LTO")
        Call ListarAlmacenUsuarios(CboAlmacen, "28")
        Call ListarMotivoAnulacion(CboAnulacion)
        DgvIngresoTransferencia.DataSource = movimientos
    End Sub
#End Region                '   Load

End Class