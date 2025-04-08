Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmIngresoAjuste

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

    '   *****   Listas  *****
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


#Region "Funciones Locales"

#Region "Listar Motivo Ajuste"
    Private Sub ListarMotivoAjuste()
        Negocio.Maestros2 = New NGMaestros2
        CboMotivo.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LAJ", "", Now.ToShortDateString, Now)
        CboMotivo.DisplayMember = "Motivo"
        CboMotivo.ValueMember = "Codigo"
        CboMotivo.SelectedIndex = -1
    End Sub
#End Region

#Region "Listar Movimientos Por Ajuste"
    Private Sub ListarMovimientoAjuste(ByVal Documento As String, ByVal Opcion As String)
        With Entidad.Guia
            Dim ab, cd As String
            .Cod_Cia = Companhia
            .NumDoc = Documento
            .Tipo_Doc = "IJ"
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
        movimientos = Negocio.Guia.ListarMovimientoPorAjuste(Entidad.Guia, Opcion)
    End Sub
#End Region

#Region "Validar Grabar"
    Private Function ValidarGrabar() As Boolean
        Dim xmes As String
        Dim xAno As String
        Dim Periodo As String

        xmes = Mes(Month(Now))
        xAno = Year(Now)
        Periodo = xmes + xAno

        If Existe_Serie(CboAlmacen.Value) = False Then
            MsgBox("NO hay SERIE definida para el almacén.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If Existe_Numeracion_Automatico(CboAlmacen.Value, CboTipoMovimiento.Value) = False Then
            MsgBox("NO hay numeración AUTOMATICA para el movimiento.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If PeriodoCerrado(CboAlmacen.Value, Periodo) Then Return False
        xTipoCambio = TipoCambio()

        If CboMotivo.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un motivo para el AJUSTE.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If LblEstado.Text = "ANULADO" Then
            MsgBox("NO se puede modificar un billete que está anulado.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If dgvDetalleIngresoAjuste.Rows.Count = 0 Then
            MsgBox("No hay detalle para GRABAR.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Validar Anulacion"
    Private Function ValidarAnulacion() As Boolean

        If TxtNumeroMovimiento.Text = "" Then
            Return False
        End If

        If GrpAnulacion.Visible = False And (TxtNumeroMovimiento.Text <> "" Or DgvIngresoAjuste.ActiveRow.Cells("NumeroDocumento").Value <> "") Then
            GrpAnulacion.Visible = True
            Return False
        End If

        If CboAnulacion.Value = 0 And GrpAnulacion.Visible = True Then
            MsgBox("Debe seleccionar un motivo para la anulación.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Limpiar"
    Private Sub Limpiar()
        DtFechaConsulta.Value = Now
        dtFeStringegistro.Value = Now
        TxtNumeroMovimiento.Clear()
        TxtNumeroDocumento.Clear()
        CboMotivo.SelectedIndex = -1
        CboAlmacen.Value = 28
        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
        End With
        dgvDetalleIngresoAjuste.DataSource = Negocio.Guia.ListarDetalleIngresoAjuste(Entidad.Guia)
        LblEstado.Text = ""
    End Sub
#End Region

#End Region   'Funciones Locales

#Region "Funciones Publicas"

#Region "Grabar"
    Public Sub Grabar()
        TxtNumeroMovimiento.Focus()
        If ValidarGrabar() = False Then Return
        If MsgBox("¿Esta seguro de grabar el Ingreso Por Ajuste.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            With Entidad.Guia
                .Cod_Cia = Companhia
                .NumDoc = Trim(TxtNumeroMovimiento.Text & "")

                If TxtNumeroMovimiento.Text = "" Then
                    .NumInterno = ""
                Else
                    .NumInterno = DgvIngresoAjuste.ActiveRow.Cells("NumeroMovimientoInterno").Value
                End If

                .Cod_Alm = CboAlmacen.Value
                .Mov_Stock = "1"
                .User_Crea = User_Sistema
                .PtoVta = "000"
                .NroHrs = "0"
                .CapacTransp = "0"
                .CostoMin = "0"
                .Kilometraje = "0"
                .Peso_Contenedor = "0"
                .Peso_Aduanas = "0"
                .Cod_Labor = Trim(CboMotivo.Value & "")
                .Cod_Cantera = ""
                .Cod_Cli = "00000000"
                .RazSoc = Trim(CboTipoMovimiento.Text & "")
                .Cod_Per = ""
                .Cod_Area = ""
                .Tipo_DocOri = ""
                .Doc_Ori = ""
                .Ruc = ""
                .Obs = ""
                .TipDocRef = ""
                .NumDocRef = ""
                .TipoDespacho = "0"
                .Status = ""
            End With


            For i As Integer = 0 To dgvDetalleIngresoAjuste.Rows.Count - 1
                Guia = New ETGuia
                With Guia
                    .cod_cia = Companhia                                                         '**
                    .numdoc = Trim(TxtNumeroMovimiento.Text & "")                                         '**

                    If TxtNumeroMovimiento.Text = "" Then
                        .NumInterno = ""
                    Else
                        .NumInterno = DgvIngresoAjuste.ActiveRow.Cells("NumeroMovimientoInterno").Value
                    End If

                    .Cod_Cli = "00000000"                                                   '**
                    .item = i + 1                                                           '**
                    .cod_prod = dgvDetalleIngresoAjuste.Rows(i).Cells("Codigo").Value       '**
                    .descrip = dgvDetalleIngresoAjuste.Rows(i).Cells("Descripcion").Value   '**
                    .unid = dgvDetalleIngresoAjuste.Rows(i).Cells("UM").Value           '**
                    .cant_ing = dgvDetalleIngresoAjuste.Rows(i).Cells("Cantidad").Value     '**
                    .moneda = "S/."                                                         '**
                    .tipo_cambio = xTipoCambio                                              '**
                    .precio = 0                                                             '**
                    .dcto = 0                                                               '**
                    .total = 0                                                              '**
                    .User_Crea = User_Sistema                                                   '**
                    .item_fact = 0                                                          '**
                    .cod_prodpdc = dgvDetalleIngresoAjuste.Rows(i).Cells("Codigo").Value    '**
                    .tipprod = dgvDetalleIngresoAjuste.Rows(i).Cells("TipoProducto").Value  '**
                    .codorigen = dgvDetalleIngresoAjuste.Rows(i).Cells("TipoProducto").Value    '**
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
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("AGR", CboTipoMovimiento.Value, "IJ", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)
            Else
                Entidad.Resultado = Negocio.Guia.GrabarMovimiento("MOD", CboTipoMovimiento.Value, "IJ", Entidad.Guia, DetalleGuia, Pedido, DetalleGuia, Entidad.Almacen)

            End If


            If Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text = "" Then
                MsgBox("Se generó el Ingreso Por Ajuste N° " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            ElseIf Entidad.Resultado.Realizo = True And TxtNumeroMovimiento.Text <> "" Then
                MsgBox("Se modificó el Ingreso Por Ajuste N° " + Entidad.Resultado.Mensaje + " con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            DetalleGuia = New List(Of ETGuia)


            Call ListarMovimientoAjuste("", "LTO")
            DgvIngresoAjuste.DataSource = movimientos
            TabIngresoAjuste.Tabs("Listar").Selected = True
            Call Limpiar()

        End If
    End Sub

#End Region

#Region "Eliminar"
    Public Sub Eliminar()

        If ValidarAnulacion() = False Then Return

        If MsgBox("¿Esta Seguro de ELIMINAR el Ingreso por Ajuste.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            With Entidad.Guia
                .Cod_Cia = Companhia
                .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
                .Motivo = CboAnulacion.Value
                .User_Crea = User_Sistema
                .Tipo_Doc = "IJ"
                .Tipo_Mov = "04"
            End With

            Entidad.Resultado = Negocio.Guia.EliminarMovimiento(Entidad.Guia, DetalleGuia)

            If Entidad.Resultado.Realizo = True Then
                MsgBox("La anulación del Ingreso por Ajuste " & Trim(TxtNumeroMovimiento.Text & "") & " se realizó con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            Call ListarMovimientoAjuste("", "LTO")
            DgvIngresoAjuste.DataSource = movimientos
            TabIngresoAjuste.Tabs("Listar").Selected = True
            Call Limpiar()
        End If
        'End If
    End Sub
#End Region

#Region "Buscar"
    Public Sub Buscar()
        Try

            With dgvDetalleIngresoAjuste
                Select Case .ActiveCell.Column.Key
                    Case "Codigo"
                        Dim Productos As New FrmListarProductos
                        gAlmacen = CboAlmacen.Value
                        Productos.ShowDialog()
                        dgvDetalleIngresoAjuste.ActiveRow.Cells("Codigo").Value = Productos.CODIGO
                        dgvDetalleIngresoAjuste.ActiveRow.Cells("Descripcion").Value = Productos.DESCRIPCION
                        dgvDetalleIngresoAjuste.ActiveRow.Cells("UM").Value = Productos.UNIDADMEDIDA
                        dgvDetalleIngresoAjuste.ActiveRow.Cells("TipoProducto").Value = Productos.UNIDADMEDIDA
                        UbicarCursorGrilla(dgvDetalleIngresoAjuste, dgvDetalleIngresoAjuste.ActiveRow, "Cantidad")
                    Case Else
                        MsgBox("Esta columna esta INACTIVA", MsgBoxStyle.Exclamation, "Comacsa")
                End Select
            End With
        Catch ex As Exception
        End Try


    End Sub
#End Region

#Region "Nuevo"
    Public Sub Nuevo()
        TabIngresoAjuste.Tabs("Ingreso").Selected = True
        Call Limpiar()
    End Sub
#End Region

#End Region  'Funciones Publicas

#Region "Eventos Controles"

#Region "dgvDetalleIngresoAjuste - KeyPress"
    Private Sub dgvDetalleIngresoAjuste_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDetalleIngresoAjuste.KeyPress

        Try
            With dgvDetalleIngresoAjuste
                Select Case .ActiveCell.Column.Key
                    Case "Codigo"
                        Select Case Asc(e.KeyChar)
                            Case 13
                                Dim DtProducto As New DataTable
                                With Entidad.Producto
                                    .Cod_Cia = Companhia
                                    .CodAlmacen = CboAlmacen.Value
                                    .CodProducto = Trim(dgvDetalleIngresoAjuste.ActiveCell.Text & "")
                                End With
                                DtProducto = Negocio.Producto.ListarProductos(Entidad.Producto, "LX2")
                                If DtProducto.Rows.Count > 0 Then
                                    dgvDetalleIngresoAjuste.ActiveRow.Cells("Codigo").Value = DtProducto.Rows(0).Item("Codigo")
                                    dgvDetalleIngresoAjuste.ActiveRow.Cells("Descripcion").Value = DtProducto.Rows(0).Item("Descripcion")
                                    dgvDetalleIngresoAjuste.ActiveRow.Cells("TipoProducto").Value = DtProducto.Rows(0).Item("TipoProducto")
                                    dgvDetalleIngresoAjuste.ActiveRow.Cells("UM").Value = DtProducto.Rows(0).Item("UM")
                                Else
                                    MsgBox("NO hay producto para este código.", MsgBoxStyle.Critical, "Comacsa")
                                    dgvDetalleIngresoAjuste.ActiveRow.Cells("Codigo").Value = ""
                                    Return
                                End If
                        End Select
                End Select
            End With
        Catch ex As Exception
        End Try

    End Sub
#End Region

#Region "DgvIngresoAjuste - DoubleClickRow"
    Private Sub DgvIngresoAjuste_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvIngresoAjuste.DoubleClickRow
        GrpAnulacion.Visible = False
        CboAnulacion.Value = 0
        TabIngresoAjuste.Tabs("Ingreso").Selected = True
        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        CboMotivo.Value = e.Row.Cells("CodigoMotivo").Value
        TxtNumeroMovimiento.Text = e.Row.Cells("NumeroDocumento").Value
        LblEstado.Text = e.Row.Cells("Estado").Value
        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(e.Row.Cells("NumeroDocumento").Value & "")
        End With
        dgvDetalleIngresoAjuste.DataSource = Negocio.Guia.ListarDetalleIngresoAjuste(Entidad.Guia)
        UbicarCursorGrilla(dgvDetalleIngresoAjuste, dgvDetalleIngresoAjuste.Rows(0), "Codigo")
    End Sub
#End Region

#Region "BtCancelar - Click"
    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        GrpAnulacion.Visible = False
        CboAnulacion.SelectedIndex = -1
    End Sub
#End Region

#Region "CboAlmacen - ValueChanged"
    Private Sub CboAlmacen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAlmacen.ValueChanged
        TxtNumeroMovimiento.Clear()
        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
        End With
        dgvDetalleIngresoAjuste.DataSource = Negocio.Guia.ListarDetalleIngresoAjuste(Entidad.Guia)
    End Sub
#End Region

#End Region   'Evento Controles

#Region "Load"
    Private Sub FrmIngresoAjuste_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarAlmacenUsuarios(CboAlmacen, "28")
        Call ListarMovimientosUsuario(CboTipoMovimiento, "04")
        Call ListarMotivoAnulacion(CmbAnulacion)
        Call ListarMotivoAjuste()
        Call ListarMovimientoAjuste("", "LTO")
        DgvIngresoAjuste.DataSource = movimientos
        DtFechaConsulta.Value = Now
        dtFeStringegistro.Value = Now
    End Sub
#End Region                'Load

End Class