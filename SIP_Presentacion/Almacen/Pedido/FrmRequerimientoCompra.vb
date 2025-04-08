Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Windows.Forms
Imports System.Math
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmRequerimientoCompra

    '   *****       LISTAS   *****
    Dim LstRequerimiento As New List(Of ETListDetalleRequerimiento)
    Dim LstDetalleAquisicion As List(Of ETListDetalleRequerimiento) = Nothing
    Dim LstDetalleAtendido As List(Of ETListDetalleRequerimiento) = Nothing


    Dim LstReqOrigen As New List(Of ETRequerimiento)
    Dim Reque As ETListDetalleRequerimiento

    Dim LsDocumentosTecnicos As New List(Of ETListDocumentosTecnicos)
    Dim Doc As ETListDocumentosTecnicos

    Dim LsMaestroDocumentos As New List(Of ETLisMaestroDocumentosTecnicos)
    Dim Maestro As ETLisMaestroDocumentosTecnicos

    Dim Requerimiento As New List(Of ETRequerimiento)
    Dim Req As ETRequerimiento

    '   *****       VARIABLES   *****
    Dim Ano As String
    Dim Flag As String
    Dim NumeroLogistica As String
    Dim NumeroInternoLogistica As String
    Dim DtFlag As New DataTable
    Dim DtNumeroLogistica As New DataTable
    Dim DtNumeroInterno As New DataTable

    Public Ls_Permisos As New List(Of Integer)
    Dim Consolidado As Boolean

#Region "Funciones Publicas"

#Region "Grabar"

    Private Sub GrabarReqCompra()
        Dim Grilla As UltraGrid
        Numero_Requisicion.Focus()
        LstReqOrigen = New List(Of ETRequerimiento)
        If ValidarGrabar() = False Then Return
        If Me.TabRequerimientoCompra.Tabs("Detalle").Selected = True Then
            If MsgBox("¿Esta Seguro de GRABAR el Requerimiento de Compra.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                LblNroRequerimiento.Focus()

                With Entidad.Requerimiento
                    .NroReq = Trim(LblNroRequerimiento.Text & "")
                    .Cod_Cia = Companhia
                    .Lugar_Ent = LugarEntrega.Value
                    .Area = CboArea.Value
                    .DocOri = ""
                    .NumDocOri = Trim(Numero_Requisicion.Text & "")
                    .Nro_Int = NumeroInternoLogistica
                    .User_Crea = User_Sistema

                    If RequePrioridad.Checked = True Then
                        .Prioridad = "1"
                    Else
                        .Prioridad = "0"
                    End If
                End With

                LstReqOrigen = Nothing
                LstReqOrigen = New List(Of ETRequerimiento)

                If Trim(Me.Tag) = "46" Then
                    Grilla = dgvDetalleRequerimiento
                Else
                    Grilla = dgvDetalleReqConsolidado

                    Dim EntReqOrigen As ETRequerimiento
                    For Each xRow As UltraGridRow In dgvRequerimientoCompraOrigen.Rows
                        If xRow.Cells("Action").Value = True Then
                            EntReqOrigen = New ETRequerimiento
                            With EntReqOrigen
                                .NroReq = xRow.Cells("Requerimiento").Value
                                .Cod_Cia = Companhia
                                .User_Crea = User_Sistema
                                .Item = 0
                                .Status = ""
                            End With
                            LstReqOrigen.Add(EntReqOrigen)
                            EntReqOrigen = Nothing
                        End If

                    Next


                End If

                If Grilla.Rows.Count > 0 Then
                    If Numero_Requisicion.Text = "" Or Numero_Requisicion.Text = "0000000" Then
                        Dim xItem As Integer = 0
                        Dim abc As Integer = 0

                        For x As Integer = 0 To Grilla.Rows.Count - 1
                            If Trim(Grilla.Rows(x).Cells("Codigo").Value & "") <> "" And Trim(Grilla.Rows(x).Cells("Descripcion").Value & "") <> "" Then

                                Req = New ETRequerimiento
                                With Req

                                    If IsDBNull(Grilla.Rows(x).Cells("Item").Value) = True Then
                                        abc = 0
                                    Else
                                        abc = Grilla.Rows(x).Cells("Item").Value
                                    End If

                                    xItem = xItem + 1
                                    If LblNroRequerimiento.Text <> "" Then
                                        .NroReq = Trim(Grilla.ActiveRow.Cells("Requerimiento").Value & "")
                                    Else
                                        .NroReq = NumeroLogistica + "-" + Trim(Flag & "") + "-" + Ano

                                    End If

                                    .Item = xItem
                                    .Cod_Cia = Companhia
                                    .CodigoProducto = Grilla.Rows(x).Cells("Codigo").Value
                                    .Unidad = Grilla.Rows(x).Cells("UM").Value
                                    .Cantidad = Grilla.Rows(x).Cells("CantidadRequerida").Value
                                    .Empleo = Trim(Grilla.Rows(x).Cells("Empleo").Value & "")
                                    .Nro_Int = NumeroInternoLogistica
                                    .User_Crea = User_Sistema
                                    .Unidad = Trim(Grilla.Rows(x).Cells("UM").Value & "")
                                    .Memo = Trim(Grilla.Rows(x).Cells("Observaciones").Value & "")
                                    .Cod_Prov = Trim(Grilla.Rows(x).Cells("CodigoProveedor").Value & "")
                                    .Nom_Prov = Trim(Grilla.Rows(x).Cells("RazonSocial").Value & "")
                                End With
                                Requerimiento.Add(Req)

                            End If
                        Next
                    End If

                    If LblNroRequerimiento.Text = "" Then
                        Entidad.Resultado = Negocio.Requerimiento.GrabarRequerimientoCompra(Entidad.Requerimiento, Requerimiento, "AGR", LsMaestroDocumentos, LstReqOrigen)
                    Else
                        Entidad.Resultado = Negocio.Requerimiento.GrabarRequerimientoCompra(Entidad.Requerimiento, Requerimiento, "MOD", LsMaestroDocumentos, LstReqOrigen)
                    End If

                    If Entidad.Resultado.Realizo = True Then
                        MsgBox("Los Datos se guardaron correctamente." & vbCrLf & "Nro Requerimiento :" & Entidad.Resultado.Mensaje, MsgBoxStyle.Information, "Comacsa")
                        TabRequerimientoCompra.Tabs("Listar").Selected = True
                        Call ListarRequerimientoCompra()
                    End If

                    LstRequerimiento = New List(Of ETListDetalleRequerimiento)
                    LsDocumentosTecnicos = New List(Of ETListDocumentosTecnicos)
                    LsMaestroDocumentos = New List(Of ETLisMaestroDocumentosTecnicos)
                    Requerimiento = New List(Of ETRequerimiento)

                End If
            End If
        End If
    End Sub

    Private Sub GrabarReqCompraDistribuir()
        If LstDetalleAquisicion.Count <= 0 Then
            MsgBox("Debe Distribuir al menos un Item del Requerimiento", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If Me.TabRequerimientoCompra.Tabs("Detalle").Selected = True Then
            If MsgBox("¿Esta Seguro de GRABAR el Requerimiento de Compra.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

                Entidad.Resultado = Negocio.Requerimiento.GrabarRequerimientoCompraDistribuir(LstDetalleAtendido, LstDetalleAquisicion)
            
                If Entidad.Resultado.Realizo = True Then
                    MsgBox("Los Datos se guardaron correctamente." & vbCrLf & "Nro Requerimiento :" & Trim(LblNroRequerimiento.Text), MsgBoxStyle.Information, "Comacsa")
                    TabRequerimientoCompra.Tabs("Listar").Selected = True
                    Call ListarRequerimientoCompra()
                End If
                LstDetalleAtendido = Nothing
                LstDetalleAquisicion = Nothing
                LstDetalleAtendido = New List(Of ETListDetalleRequerimiento)
                LstDetalleAquisicion = New List(Of ETListDetalleRequerimiento)
            End If
        End If
    End Sub

    Public Sub Grabar()
        If Trim(Me.Tag) = "99" Then
            Call GrabarReqCompraDistribuir()
        Else
            Call GrabarReqCompra()
        End If
    End Sub
#End Region

#Region "Actualizar"
    Public Sub Actualizar()
        If TabRequerimientoCompra.Tabs("Listar").Selected = True Then
            Call ListarRequerimientoCompra()
        End If
    End Sub
#End Region

#Region "Buscar"
    Public Sub Buscar()
        Try
            If CboArea.Value = 0 Then
                MsgBox("Debe seleccionar un ÁREA para continuar.", MsgBoxStyle.Critical, "Comacsa")
                Return
            End If

            With dgvDetalleRequerimiento

                Select Case .ActiveCell.Column.Key

                    Case "Codigo"
                        Dim Productos As New FrmListarProductos
                        gAlmacen = LugarEntrega.Value
                        Productos.ShowDialog()
                        dgvDetalleRequerimiento.ActiveRow.Cells("Codigo").Value = Productos.CODIGO
                        dgvDetalleRequerimiento.ActiveRow.Cells("Descripcion").Value = Productos.DESCRIPCION
                        dgvDetalleRequerimiento.ActiveRow.Cells("UM").Value = Productos.UMCOMPRA
                        dgvDetalleRequerimiento.ActiveRow.Cells("Stock").Value = Productos.STOCK

                    Case "CodigoProveedor"
                        Dim Proveedor As New FrmProveedores
                        Proveedor.ShowDialog()
                        dgvDetalleRequerimiento.ActiveRow.Cells("CodigoProveedor").Value = Proveedor.Codigo
                        dgvDetalleRequerimiento.ActiveRow.Cells("RazonSocial").Value = Proveedor.RazonSocial

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
        If Trim(Me.Tag) = "99" Then Exit Sub

        Consolidado = False
        TabRequerimientoCompra.Tabs("Detalle").Selected = True
        Call HabilitarControles(True)

        Dim dtDatosUsers As New DataTable
        With Entidad.Usuario
            .Cod_Cia = Companhia
            .Sistema = Sistema
            .Login = User_Sistema
        End With
        dtDatosUsers = Negocio.Usuario.ListarUsers(Entidad.Usuario, "DUS")

        If dtDatosUsers.Rows.Count > 0 Then
            RequeCodigoUserSolicita.Text = dtDatosUsers.Rows(0).Item("Codigo")
            RequeUserSolicita.Text = dtDatosUsers.Rows(0).Item("Nombre")
        End If

        LsDocumentosTecnicos = New List(Of ETListDocumentosTecnicos)
        LsMaestroDocumentos = New List(Of ETLisMaestroDocumentosTecnicos)

        LblEstado.Text = ""
        LblNroRequerimiento.Text = ""
        Numero_Requisicion.Clear()
        CboArea.Value = 0
        LugarEntrega.Value = 28
        RequePrioridad.Checked = False
        Dtp1.Value = Now
        Dtp2.Value = Now
        Numero_Requisicion.Text = "0000000"
        BtnConsolidar.Visible = True
        chkAplicarTodos.Visible = True
        If Trim(Me.Tag) = "98" Then
            TabReqCompraDet.Tabs("T01").Selected = True
            Dtp1.ReadOnly = False
            Dtp2.ReadOnly = False
            dgvDetalleReqConsolidado.DataSource = Negocio.Requerimiento.ListarRequerimientoCompra
            While dgvRequerimientoCompraOrigen.Rows.Count > 0
                dgvRequerimientoCompraOrigen.Rows(0).Delete()
            End While
        Else
            dgvDetalleRequerimiento.DataSource = Negocio.Requerimiento.ListarRequerimientoCompra
        End If

    End Sub
#End Region

#Region "Eliminar"
    Public Sub Eliminar()

        If TabRequerimientoCompra.Tabs("Detalle").Selected = True Then
            If ValidarAnulacionRequerimiento() = False Then Return
            If MsgBox("¿Esta Seguro de ANULAR el Requerimiento ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                Entidad.Requerimiento = New ETRequerimiento
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .NroReq = Trim(LblNroRequerimiento.Text & "")
                    .NumDocOri = Trim(Numero_Requisicion.Text & "")
                    .User_Crea = User_Sistema
                End With

                If Trim(Me.Tag) = "99" Then
                    Entidad.Resultado = Negocio.Requerimiento.EliminarRequerimientoCompraDistribuir(Entidad.Requerimiento)
                Else
                    Entidad.Resultado = Negocio.Requerimiento.AnularRequerimientoLogistica(Entidad.Requerimiento)
                End If

                If Entidad.Resultado.Realizo = True Then
                    MsgBox("La ANULACIÓN del requerimiento " & Trim(LblNroRequerimiento.Text & "") & " se realizó con éxito.", MsgBoxStyle.Information, "Comacsa")
                    Call ListarRequerimientoCompra()
                    TabRequerimientoCompra.Tabs("Listar").Selected = True
                End If
            End If
        End If
    End Sub
#End Region

#Region "Reporte"
    Public Sub Reporte()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Try

            If Trim(LblNroRequerimiento.Text & "") = "" Then Exit Try

            StrucForm.FxRequerimientoCompra = New Rpt_Requerimiento

            gRequerimiento = Trim(dgvRequerimientoCompra.ActiveRow.Cells("Requerimiento").Value & "")

            StrucForm.FxRequerimientoCompra.NombreReporte = "Requerimiento [" & Trim(dgvRequerimientoCompra.ActiveRow.Cells("Requerimiento").Value & "") & "]"
            StrucForm.FxRequerimientoCompra.MdiParent = MdiParent
            StrucForm.FxRequerimientoCompra.Show()

        Catch EX As Exception
            MsgBox(EX.Message)
            MessageBox.Show("Error: Problemas al Generar el Reporte", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub




#End Region

#Region "Cancelar"
    Public Sub Cancelar()
        If TabRequerimientoCompra.Tabs("Detalle").Selected = True Then
            With Entidad.Requerimiento
                .Cod_Cia = Companhia
                .NroReq = dgvRequerimientoCompra.ActiveRow.Cells("Requerimiento").Value
                .Lugar_Ent = dgvRequerimientoCompra.ActiveRow.Cells("CodigoLugarEntrega").Value
            End With
            dgvDetalleRequerimiento.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "DET")
        End If

        '   *****   Documentos Tecnicos *****
        LsMaestroDocumentos = New List(Of ETLisMaestroDocumentosTecnicos)

        Dim DtDocTec As New DataTable
        With Entidad.Pedido
            .Numero_Doc = Trim(dgvRequerimientoCompra.ActiveRow.Cells("Requerimiento").Value & "")
            .Cod_Cia = Companhia
        End With
        DtDocTec = Negocio.PedidoBL.Listar_DocTec(Entidad.Pedido, "LRDT")
        If DtDocTec.Rows.Count > 0 Then
            For i As Integer = 0 To DtDocTec.Rows.Count - 1
                Maestro = New ETLisMaestroDocumentosTecnicos
                With Maestro
                    .Item = DtDocTec.Rows(i).Item("Item")
                    .Codigo_Producto = DtDocTec.Rows(i).Item("Codigo")
                    .Producto = DtDocTec.Rows(i).Item("Producto")
                    .Cod_DocTecnico = DtDocTec.Rows(i).Item("Documento")
                    .Estado = "A"
                End With
                LsMaestroDocumentos.Add(Maestro)
            Next
        End If
    End Sub
#End Region

#Region "Procesar"
    Public Sub Procesar()
        If Trim(Me.Tag) = "98" Then
            If TabRequerimientoCompra.Tabs("Detalle").Selected = True Then
                If LblNroRequerimiento.Text = "" Then
                    Consolidado = False
                    Call ListarRequerimientoCompraOrigen()
                End If
               
            End If
        End If
    End Sub
#End Region

#End Region      'Funciones Publicas

#Region "Funciones Locales"

#Region "Configurar Formulario"
    Private Sub ConfigurarFormulario()
        If Trim(Me.Tag) = "46" Then
            TabReqCompraDet.Tabs("T01").Visible = False
            TabReqCompraDet.Tabs("T03").Visible = False
            dgvDetalleReqConsolidado.Visible = False
            dgvDetalleAtendido.Visible = False
            dgvDetalleRequerimiento.Visible = True
        ElseIf Trim(Me.Tag) = "98" Then
            dgvDetalleRequerimiento.Visible = False
            dgvDetalleAtendido.Visible = False
            dgvDetalleReqConsolidado.Visible = True
            TabReqCompraDet.Tabs("T03").Visible = False
        Else
            dgvDetalleRequerimiento.Visible = False
            dgvDetalleReqConsolidado.Visible = False
            dgvDetalleAtendido.Visible = True
        End If
    End Sub
#End Region
#Region "Listar Requerimiento"
    Private Sub ListarRequerimientoCompra()
        Dim FechaInicio As DateTime
        Dim FechaFin As DateTime
        Entidad.Requerimiento = New ETRequerimiento
        Negocio.Requerimiento = New NGRequerimiento

        FechaInicio = Mid(dtpInicio.Value.ToString, 1, 10) & " 00:00:00"
        FechaFin = Mid(dtpFin.Value.ToString, 1, 10) & " 23:59:59"

        With Entidad.Requerimiento
            .Cod_Cia = Companhia
            .User_Crea = User_Sistema
            .FechaEmision = FechaInicio
            .Fec_Aprob = FechaFin
        End With
        If Trim(Me.Tag) = "46" Then
            dgvRequerimientoCompra.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "CAB0")
        Else
            dgvRequerimientoCompra.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "CAB2")
        End If

    End Sub

    Private Sub ListarRequerimientoCompraOrigen()
        Dim FechaInicio As DateTime
        Dim FechaFin As DateTime

        If String.IsNullOrEmpty(Trim(LugarEntrega.Value)) Then
            MsgBox("Seleccione el Lugar de Entrega", MsgBoxStyle.Critical, msgComacsa)
            LugarEntrega.Focus()
            Exit Sub
        End If
        Entidad.Requerimiento = New ETRequerimiento
        Negocio.Requerimiento = New NGRequerimiento
        FechaInicio = Mid(Dtp1.Value.ToString, 1, 10) & " 00:00:00"
        FechaFin = Mid(Dtp2.Value.ToString, 1, 10) & " 23:59:59"
        With Entidad.Requerimiento
            .Cod_Cia = Companhia
            .User_Crea = User_Sistema
            .FechaEmision = FechaInicio
            .Fec_Aprob = FechaFin
            .Lugar_Ent = LugarEntrega.Value
        End With
        dgvRequerimientoCompraOrigen.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "CAB1")
    End Sub

#End Region

#Region "Listar Documentos Tecnicos"
    Private Sub ListarDocumentos(ByVal Grilla As UltraGrid)
        'Inicio
        If Grilla.ActiveRow Is Nothing Then Exit Sub
        dgvDocumentosTecnicos.DataSource = Nothing
        TxtCodigoProductoDocTec.Text = Grilla.ActiveRow.Cells("Codigo").Value
        TxtDescripcionDocTec.Text = Grilla.ActiveRow.Cells("Descripcion").Value


        Dim dtDocTec As New DataTable
        Negocio.Maestros2 = New NGMaestros2
        dtDocTec = Negocio.Maestros2.ListarDocumentosTecnicos


        LsDocumentosTecnicos.Clear()
        If dtDocTec.Rows.Count > 0 Then
            For i As Integer = 0 To dtDocTec.Rows.Count - 1
                Doc = New ETListDocumentosTecnicos
                With Doc
                    .Codigo = dtDocTec.Rows(i).Item("Codigo")
                    .Descripcion = dtDocTec.Rows(i).Item("Descripcion")


                    Dim x = LsMaestroDocumentos.FindAll(Function(b) b.Codigo_Producto = TxtCodigoProductoDocTec.Text And _
                                                                    b.Cod_DocTecnico = .Codigo And _
                                                                    b.Estado = "A" And _
                                                                    b.Producto = TxtDescripcionDocTec.Text)
                    If x.Count > 0 Then
                        .Seleccionar = True
                    Else
                        .Seleccionar = False
                    End If
                End With
                LsDocumentosTecnicos.Add(Doc)
            Next

            dgvDocumentosTecnicos.DataSource = LsDocumentosTecnicos
            Call ColumnasDocumentosTecnicos()
        End If
        'Fin
    End Sub
#End Region

#Region "Asignar al Requerimiento"
    Private Function Asignar_Requerimiento(ByVal Documentos As ETLisMaestroDocumentosTecnicos, ByVal Cod_Cia As String, ByVal Nro_Requi As String, ByVal User_Crea As String)
        Documentos.Cod_Cia = Cod_Cia
        Documentos.Nro_Requi = Trim(Nro_Requi & "")
        Documentos.User_Crea = User_Crea
        Return ""
    End Function
#End Region

#Region "Nuevox"
    Private Sub Nuevox()
        LsDocumentosTecnicos = New List(Of ETListDocumentosTecnicos)
        LsMaestroDocumentos = New List(Of ETLisMaestroDocumentosTecnicos)
        Requerimiento = New List(Of ETRequerimiento)



        LblEstado.Text = ""
        LblNroRequerimiento.Text = ""
        Numero_Requisicion.Clear()
        CboArea.Value = 0
        LugarEntrega.Value = 28
        RequePrioridad.Checked = False
    End Sub
#End Region

#Region "Validar Documentos Requeridos"
    Private Function DocumentosRequeridos() As Boolean
        Dim numero As Integer
        numero = 0
        If GrpDocTecnicos.Visible = True Then
            For i As Integer = 0 To dgvDocumentosTecnicos.Rows.Count - 1
                If dgvDocumentosTecnicos.Rows(i).Cells("Seleccionar").Value = True Then
                    numero = numero + 1
                End If
            Next
        End If

        If numero = 0 Then
            MsgBox("Debe seleccionar un documento para continuar.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Return True

    End Function
#End Region

#Region "Validar GRABAR y/o MODIFICAR"
    Private Function ValidarGrabar() As Boolean
        Dim Req_Union As String = String.Empty
        Dim lResult As Boolean = True

        If Not (String.IsNullOrEmpty(Trim(LblNroRequerimiento.Text))) Then
            Entidad.Requerimiento = New ETRequerimiento
            With Entidad.Requerimiento
                .Cod_Cia = Companhia
                .NroReq = Trim(LblNroRequerimiento.Text)
            End With
            Negocio.Requerimiento = New NGRequerimiento

            Req_Union = Trim(Negocio.Requerimiento.ValidarRequerimientoOrigen(Entidad.Requerimiento))
            If Not (String.IsNullOrEmpty(Trim(Req_Union))) Then
                MsgBox("No puede modificar el Requerimiento porque esta consolidado en el Nro. Req: " & Req_Union, MsgBoxStyle.Critical, msgComacsa)
                lResult = False
            End If
        End If
       


        If LblEstado.Text = "APROBADA" Then
            MsgBox("NO se puede modificar un requerimiento ya aprobado.", MsgBoxStyle.Critical, "Comacsa")
            lResult = False
        End If

        Return lResult
    End Function
#End Region

#Region "Validar Anulacion Requerimiento"
    Private Function ValidarAnulacionRequerimiento()
        Dim Req_Union As String = String.Empty
        Dim dtUsuarioCreador As New DataTable
        Dim dtAnexoOC As New DataTable

        With Entidad.Requerimiento
            .Cod_Cia = Companhia
            .NroReq = Trim(LblNroRequerimiento.Text & "")
        End With
        dtUsuarioCreador = Negocio.Requerimiento.UsuarioRequerimiento(Entidad.Requerimiento, "UCR")

        If Trim(dtUsuarioCreador.Rows(0).Item("Usuario") & "") <> User_Sistema Then
            MsgBox("No está autorizado a eliminar un Requerimento de otro usuario", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If Not (String.IsNullOrEmpty(Trim(LblNroRequerimiento.Text))) Then
            Req_Union = Trim(Negocio.Requerimiento.ValidarRequerimientoOrigen(Entidad.Requerimiento))
            If Not (String.IsNullOrEmpty(Trim(Req_Union))) Then
                MsgBox("No puede Eliminar el Requerimiento porque esta consolidado en el Nro. Req: " & Req_Union, MsgBoxStyle.Critical, msgComacsa)
                Return False
            End If
        End If

        dtAnexoOC = Negocio.Requerimiento.UsuarioRequerimiento(Entidad.Requerimiento, "UPV")
        If dtAnexoOC.Rows.Count > 0 Then
            Dim NumOC As String
            NumOC = ""
            For i As Integer = 0 To dtAnexoOC.Rows.Count - 1
                NumOC = NumOC & dtAnexoOC.Rows(i).Item("nro_oc") & vbCrLf
            Next

            MsgBox("El Requerimiento Nº " & Trim(LblNroRequerimiento.Text & "") & " No se puede anular. " & vbCrLf & "Ha sido aplicado a la(s) Orden de Compra " & vbCrLf & NumOC, MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If


        Return True
    End Function
#End Region

#Region "Habilitar Controles"
    Private Sub HabilitarControles(ByVal xBol As Boolean)
        CboArea.ReadOnly = Not xBol
        LugarEntrega.ReadOnly = Not xBol
        RequeEntrega.ReadOnly = Not xBol
    End Sub
#End Region
#End Region       'Funciones Locales

#Region "Evento Controles"

#Region "TabMovimientosAlmacen - SelectedTabChanged"
    Private Sub TabMovimientosAlmacen_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabRequerimientoCompra.SelectedTabChanged
        If TabRequerimientoCompra.Tabs("Listar").Selected = True Then
            TabRequerimientoCompra.Tabs("Detalle").Enabled = False
            TabRequerimientoCompra.Tabs("Documentos").Enabled = False
            Call Nuevox()
        Else
            TabRequerimientoCompra.Tabs("Detalle").Enabled = True
            TabRequerimientoCompra.Tabs("Documentos").Enabled = True
            If TabRequerimientoCompra.Tabs("Documentos").Selected = True Then
                If Trim(Me.Tag) = "46" Then
                    Call ListarDocumentos(dgvDetalleRequerimiento)
                Else
                    Call ListarDocumentos(dgvDetalleReqConsolidado)
                End If

            End If
        End If
    End Sub
#End Region


#Region "DgvRequerimientoCompra - DoubleClickRow"
    Private Sub dgvRequerimientoCompra_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvRequerimientoCompra.DoubleClickRow
        If dgvRequerimientoCompra.Rows.Count = 0 Then
            Return
        End If

        Entidad.Requerimiento = New ETRequerimiento
        With Entidad.Requerimiento
            .Cod_Cia = Companhia
            .NroReq = e.Row.Cells("Requerimiento").Value
            .Lugar_Ent = e.Row.Cells("CodigoLugarEntrega").Value
        End With


        'dgvDetalleRequerimiento.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "DET")

        If Trim(Me.Tag) = "98" Then
            dgvDetalleReqConsolidado.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "DET")
            dgvRequerimientoCompraOrigen.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "CAB3")
            dgvDetalleRequerimiento.Visible = False
            dgvDetalleAtendido.Visible = False
            dgvDetalleReqConsolidado.Visible = True
            TabReqCompraDet.Tabs("T01").Selected = True
            Call HabilitarControles(False)

        ElseIf Trim(Me.Tag) = "46" Then
            dgvDetalleRequerimiento.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "DET")
            dgvDetalleReqConsolidado.Visible = False
            dgvDetalleAtendido.Visible = False
            dgvDetalleRequerimiento.Visible = True
            TabReqCompraDet.Tabs("T02").Selected = True
        Else
            dgvDetalleAtendido.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "DET3")
            dgvDetalleAdquisicion.DataSource = Negocio.Requerimiento.ListarRequerimientoCompra_Consolidado_Distribuir(Entidad.Requerimiento, "4")
            dgvRequerimientoCompraOrigen.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "CAB3")
            dgvDetalleRequerimiento.Visible = False
            dgvDetalleReqConsolidado.Visible = False
            dgvDetalleAtendido.Visible = True
            Call HabilitarControles(False)
            TabReqCompraDet.Tabs("T01").Selected = True
            LstDetalleAquisicion = Nothing
            LstDetalleAtendido = Nothing
            LstDetalleAquisicion = New List(Of ETListDetalleRequerimiento)
            LstDetalleAtendido = New List(Of ETListDetalleRequerimiento)

        End If

        Numero_Requisicion.Text = dgvRequerimientoCompra.ActiveRow.Cells("Requisicion").Value
        LblNroRequerimiento.Text = dgvRequerimientoCompra.ActiveRow.Cells("Requerimiento").Value
        LblEstado.Text = dgvRequerimientoCompra.ActiveRow.Cells("Estado").Value
        TabRequerimientoCompra.Tabs("Detalle").Selected = True
        RequeFeStringegistro.Value = dgvRequerimientoCompra.ActiveRow.Cells("Fecha").Value
        RequeEntrega.Value = dgvRequerimientoCompra.ActiveRow.Cells("Entrega").Value
        RequeCodigoUserSolicita.Text = Trim(dgvRequerimientoCompra.ActiveRow.Cells("CodigoUsuario").Value & "")
        RequeUserSolicita.Text = Trim(dgvRequerimientoCompra.ActiveRow.Cells("NombreUsuario").Value & "")
        LugarEntrega.Value = dgvRequerimientoCompra.ActiveRow.Cells("CodigoLugarEntrega").Value
        CboArea.Value = dgvRequerimientoCompra.ActiveRow.Cells("CodigoArea").Value

        'If Trim(Me.Tag) = "98" Then
        '    dgvDetalleReqConsolidado.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "CAB3")
        'End If

        BtnConsolidar.Visible = False
        chkAplicarTodos.Visible = False

        If IsDBNull(e.Row.Cells("Prioridad").Value) = True Then
            RequePrioridad.Checked = False
        Else
            If e.Row.Cells("Prioridad").Value = "N" Then
                RequePrioridad.Checked = False
            Else
                RequePrioridad.Checked = True
            End If
        End If

        LsMaestroDocumentos = New List(Of ETLisMaestroDocumentosTecnicos)

        '   *****   Documentos Tecnicos *****

        Dim DtDocTec As New DataTable
        With Entidad.Pedido
            .Numero_Doc = Trim(dgvRequerimientoCompra.ActiveRow.Cells("Requerimiento").Value & "")
            .Cod_Cia = Companhia
        End With
        DtDocTec = Negocio.PedidoBL.Listar_DocTec(Entidad.Pedido, "LRDT")
        If DtDocTec.Rows.Count > 0 Then
            For i As Integer = 0 To DtDocTec.Rows.Count - 1
                Maestro = New ETLisMaestroDocumentosTecnicos
                With Maestro
                    .Item = DtDocTec.Rows(i).Item("Item")
                    .Codigo_Producto = DtDocTec.Rows(i).Item("Codigo")
                    .Producto = DtDocTec.Rows(i).Item("Producto")
                    .Cod_DocTecnico = DtDocTec.Rows(i).Item("Documento")
                    .Estado = "A"
                End With
                LsMaestroDocumentos.Add(Maestro)
            Next
        End If

    End Sub
#End Region

#Region "Boton Guardar - Documentos Tecnicos"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Numero_Requisicion.Focus()
        If DocumentosRequeridos() = False Then Return
        If ValidarGrabar() = False Then Return

        Dim x As New List(Of ETLisMaestroDocumentosTecnicos)

        If dgvDocumentosTecnicos.Rows.Count > 0 Then
            For i As Integer = 0 To dgvDocumentosTecnicos.Rows.Count - 1
                '   x = LsMaestroDocumentos.FindAll(Function(b) b.Cod_DocTecnico = dgvDocumentosTecnicos.Rows(i).Cells("Codigo").Value And b.Codigo_Producto = TxtCodigoProductoDocTec.Text)

                If dgvDocumentosTecnicos.Rows(i).Cells("Seleccionar").Value = True And x.Count = 0 Then

                    Maestro = New ETLisMaestroDocumentosTecnicos
                    With Maestro
                        .Codigo_Producto = Trim(TxtCodigoProductoDocTec.Text & "")
                        .Producto = Trim(TxtDescripcionDocTec.Text & "")
                        If LblNroRequerimiento.Text <> "" Then
                            If IsDBNull(dgvDetalleRequerimiento.ActiveRow.Cells("Item").Value) = True Then
                                .Item = 0
                            Else
                                .Item = dgvDetalleRequerimiento.ActiveRow.Cells("Item").Value
                            End If
                        Else
                            .Item = 0
                        End If
                        .Cod_DocTecnico = dgvDocumentosTecnicos.Rows(i).Cells("Codigo").Value
                        .Estado = "A"
                    End With
                    LsMaestroDocumentos.Add(Maestro)

                ElseIf (x.Count > 0 And dgvDocumentosTecnicos.Rows(i).Cells("Seleccionar").Value = False) Then
                    '   LsMaestroDocumentos.ForEach(Function(b) LsMaestroDocumentos_Estado(b, "D", TxtCodigoProductoDocTec.Text, dgvDocumentosTecnicos.Rows(i).Cells("Codigo").Value, TxtDescripcionDocTec.Text))
                ElseIf (x.Count > 0 And dgvDocumentosTecnicos.Rows(i).Cells("Seleccionar").Value = True) Then
                    '  LsMaestroDocumentos.ForEach(Function(b) LsMaestroDocumentos_Estado(b, "A", TxtCodigoProductoDocTec.Text, dgvDocumentosTecnicos.Rows(i).Cells("Codigo").Value, TxtDescripcionDocTec.Text))
                End If
            Next
        End If

        If Trim(Me.Tag) = "46" Then
            Call ListarDocumentos(dgvDetalleRequerimiento)
        Else
            Call ListarDocumentos(dgvDetalleReqConsolidado)
        End If

        TabRequerimientoCompra.Tabs("Detalle").Selected = True
    End Sub

    Private Function LsMaestroDocumentos_Estado(ByVal b As ETLisMaestroDocumentosTecnicos, ByVal Estado As String, ByVal codigoProducto As String, ByVal DocumentoTecnico As String, ByVal Producto As String) As String
        If b.Codigo_Producto = codigoProducto And b.Producto = Producto And b.Cod_DocTecnico = DocumentoTecnico Then
            b.Estado = Estado
        End If

        Return ""
    End Function

#End Region

#Region "BtnSalir - Click"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        TabRequerimientoCompra.Tabs("Detalle").Selected = True
    End Sub
#End Region

#Region "dgvDetalleRequerimiento - KeyPress"
    Private Sub dgvDetalleRequerimiento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDetalleRequerimiento.KeyPress
        If CboArea.Value = 0 Then
            MsgBox("Debe seleccionar un ÁREA para continuar.", MsgBoxStyle.Critical, "Comacsa")
            Return
        End If

        Try
            With dgvDetalleRequerimiento
                Select Case .ActiveCell.Column.Key
                    Case "Codigo"
                        Select Case Asc(e.KeyChar)
                            Case 13
                                Dim DtProducto As New DataTable
                                With Entidad.Producto
                                    .Cod_Cia = Companhia
                                    .CodAlmacen = LugarEntrega.Value
                                    .CodProducto = Trim(dgvDetalleRequerimiento.ActiveCell.Text & "")
                                End With
                                DtProducto = Negocio.Producto.ListarProductos(Entidad.Producto, "LX2")
                                If DtProducto.Rows.Count > 0 Then
                                    dgvDetalleRequerimiento.ActiveRow.Cells("Codigo").Value = DtProducto.Rows(0).Item("Codigo")
                                    dgvDetalleRequerimiento.ActiveRow.Cells("Descripcion").Value = DtProducto.Rows(0).Item("Descripcion")
                                    dgvDetalleRequerimiento.ActiveRow.Cells("Stock").Value = DtProducto.Rows(0).Item("Stock")
                                    dgvDetalleRequerimiento.ActiveRow.Cells("UM").Value = DtProducto.Rows(0).Item("UM")
                                Else
                                    MsgBox("NO hay producto para este código.", MsgBoxStyle.Critical, "Comacsa")
                                    dgvDetalleRequerimiento.ActiveRow.Cells("Codigo").Value = ""
                                    Return
                                End If
                        End Select

                    Case "CodigoProveedor"
                        Select Case Asc(e.KeyChar)
                            Case 13
                                Dim dtProveedor As New DataTable

                                With Entidad.Requerimiento
                                    .Cod_Prov = dgvDetalleRequerimiento.ActiveRow.Cells("CodigoProveedor").Value
                                    .Cod_Cia = Companhia
                                End With
                                dtProveedor = Negocio.Requerimiento.ListarNombreCorto(Entidad.Requerimiento, "LXP")

                                If dtProveedor.Rows.Count > 0 Then
                                    dgvDetalleRequerimiento.ActiveRow.Cells("CodigoProveedor").Value = dtProveedor.Rows(0).Item("Codigo")
                                    dgvDetalleRequerimiento.ActiveRow.Cells("RazonSocial").Value = dtProveedor.Rows(0).Item("RazonSocial")
                                Else
                                    MsgBox("No hay PROVEEDOR con este codigo: " & dgvDetalleRequerimiento.ActiveRow.Cells("CodigoEmpleo").Value, MsgBoxStyle.Critical, "Comacsa")
                                    dgvDetalleRequerimiento.ActiveRow.Cells("CodigoProveedor").Value = ""
                                    dgvDetalleRequerimiento.ActiveRow.Cells("RazonSocial").Value = ""
                                    Return
                                End If
                        End Select

                End Select
            End With
        Catch ex As Exception
        End Try

    End Sub
#End Region

#Region "dgvDetalleRequerimiento - BeforeRowsDeleted"
    Private Sub dgvDetalleRequerimiento_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvDetalleRequerimiento.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
#End Region

#Region "dgvDetalleRequerimiento - AfterCellUpdate"
    Dim Tarea As Boolean = False

    Private Sub dgvDetalleRequerimiento_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvDetalleRequerimiento.AfterCellUpdate
        If Tarea = True Then Return
        If e.Cell.Column.Key = "CodigoEmpleo" Then
            If Len(e.Cell.Row.Cells("CodigoEmpleo").Value) <> 3 Then
                Tarea = True
                e.Cell.Row.Cells("Empleo").Value = ""
                e.Cell.Row.Cells("Codigo").Value = "" '
                e.Cell.Row.Cells("Descripcion").Value = ""
                e.Cell.Row.Cells("UM").Value = ""
                e.Cell.Row.Cells("UMStock").Value = ""
                e.Cell.Row.Cells("Stock").Value = 0
                e.Cell.Row.Cells("CantidadRequerida").Value = 0
                e.Cell.Row.Cells("Observaciones").Value = ""
                e.Cell.Row.Cells("CodigoProveedor").Value = ""
                e.Cell.Row.Cells("RazonSocial").Value = ""
                Tarea = False
            End If
        End If

        If e.Cell.Column.Key = "Codigo" Then
            If Len(e.Cell.Row.Cells("Codigo").Value) <> 8 Then
                Tarea = True
                e.Cell.Row.Cells("Descripcion").Value = ""
                e.Cell.Row.Cells("UM").Value = ""
                e.Cell.Row.Cells("UMStock").Value = ""
                e.Cell.Row.Cells("Stock").Value = ""
                e.Cell.Row.Cells("CantidadRequerida").Value = 0
                e.Cell.Row.Cells("Observaciones").Value = ""
                e.Cell.Row.Cells("CodigoProveedor").Value = ""
                e.Cell.Row.Cells("RazonSocial").Value = ""
                Tarea = False
            End If
        End If

        If e.Cell.Column.Key = "CodigoProveedor" Then
            If Len(e.Cell.Row.Cells("CodigoProveedor").Value) <> 5 Then
                Tarea = True
                e.Cell.Row.Cells("RazonSocial").Value = ""
                Tarea = False
            End If
        End If

    End Sub

#End Region

#Region "Evento Activated"
    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub
#End Region

#End Region        'Evento Controles

#Region "Load"

#Region "Load"
    Private Sub FrmRequerimientoCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarAreaUsuario(CboArea, "")
        Call ListarAlmacenUsuarios(LugarEntrega, "28")
        RequeFeStringegistro.Value = Now
        RequeEntrega.Value = Now
        dtpInicio.Value = DateAdd(DateInterval.Day, ((-1) * (Now.Day) + 1), Now)
        dtpFin.Value = Now
        Call ConfigurarFormulario()
        Call ListarRequerimientoCompra()
    End Sub
#End Region

#Region "Columnas Documentos Tecnicos"
    Private Sub ColumnasDocumentosTecnicos()
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Codigo").Hidden = True

        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Descripcion").Width = 475
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.TextHAlign = HAlign.Left
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.TextVAlign = HAlign.Center
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Descripcion").CellActivation = Activation.ActivateOnly
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.FontData.SizeInPoints = 8
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción"
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Descripcion").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Descripcion").Header.Appearance.FontData.SizeInPoints = 9


        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Seleccionar").Width = 45
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Seleccionar").CellAppearance.TextHAlign = HAlign.Center
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Seleccionar").CellAppearance.TextVAlign = HAlign.Center
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = "X"
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Appearance.FontData.SizeInPoints = 9
    End Sub
#End Region

#Region "Efectos"
    Private Sub Efectos(ByVal DetalleRequerimiento As UltraGrid)


        DetalleRequerimiento.DisplayLayout.Bands(0).Columns.Add("Item")
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Item").Hidden = True

        DetalleRequerimiento.DisplayLayout.Bands(0).Columns.Add("CodigoEmpleo")
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoEmpleo").Width = 75
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoEmpleo").CellAppearance.TextHAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoEmpleo").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoEmpleo").CellAppearance.FontData.Bold = DefaultableBoolean.False
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoEmpleo").CellAppearance.FontData.SizeInPoints = 8
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoEmpleo").Header.Appearance.FontData.SizeInPoints = 9
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoEmpleo").Header.Appearance.FontData.Bold = DefaultableBoolean.True

        DetalleRequerimiento.DisplayLayout.Bands(0).Columns.Add("Empleo")
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Empleo").Width = 180
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.TextHAlign = HAlign.Left
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Empleo").CellActivation = Activation.ActivateOnly
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.FontData.Bold = DefaultableBoolean.False
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.FontData.SizeInPoints = 8
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Empleo").Header.Appearance.FontData.SizeInPoints = 9
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Empleo").Header.Appearance.FontData.Bold = DefaultableBoolean.True


        DetalleRequerimiento.DisplayLayout.Bands(0).Columns.Add("Codigo")
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Codigo").Width = 85
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.TextHAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Codigo").CellActivation = Activation.ActivateOnly
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.FontData.Bold = DefaultableBoolean.False
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.FontData.SizeInPoints = 8
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Codigo").Header.Appearance.FontData.SizeInPoints = 9
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Codigo").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Codigo").Header.Caption = "Código"

        DetalleRequerimiento.DisplayLayout.Bands(0).Columns.Add("Descripcion")
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Descripcion").Width = 200
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Descripcion").CellActivation = Activation.ActivateOnly
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.FontData.Bold = DefaultableBoolean.False
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.FontData.SizeInPoints = 8
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Descripcion").Header.Appearance.FontData.SizeInPoints = 9
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Descripcion").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción"

        DetalleRequerimiento.DisplayLayout.Bands(0).Columns.Add("UM")
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("UM").Width = 45
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("UM").CellAppearance.TextHAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("UM").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("UM").CellActivation = Activation.ActivateOnly
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("UM").CellAppearance.FontData.Bold = DefaultableBoolean.False
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("UM").CellAppearance.FontData.SizeInPoints = 8
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("UM").Header.Appearance.FontData.SizeInPoints = 9
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("UM").Header.Appearance.FontData.Bold = DefaultableBoolean.True

        DetalleRequerimiento.DisplayLayout.Bands(0).Columns.Add("CantidadSolicitada")
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Width = 75
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.BackColor = Color.LemonChiffon
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.ForeColor = Color.Blue
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.TextHAlign = HAlign.Right
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellActivation = Activation.ActivateOnly
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.FontData.Bold = DefaultableBoolean.False
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.FontData.SizeInPoints = 8
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Format = "n4"
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Header.Appearance.FontData.SizeInPoints = 9
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Header.Appearance.FontData.Bold = DefaultableBoolean.True

        DetalleRequerimiento.DisplayLayout.Bands(0).Columns.Add("CantidadRequerida")
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadRequerida").Width = 75
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadRequerida").CellAppearance.BackColor = Color.LemonChiffon
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadRequerida").CellAppearance.ForeColor = Color.Blue
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadRequerida").CellAppearance.TextHAlign = HAlign.Right
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadRequerida").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadRequerida").CellActivation = Activation.ActivateOnly
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadRequerida").CellAppearance.FontData.Bold = DefaultableBoolean.False
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadRequerida").CellAppearance.FontData.SizeInPoints = 8
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadRequerida").Format = "n4"
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadRequerida").Header.Appearance.FontData.SizeInPoints = 9
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CantidadRequerida").Header.Appearance.FontData.Bold = DefaultableBoolean.True

        DetalleRequerimiento.DisplayLayout.Bands(0).Columns.Add("Observaciones")
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Observaciones").Width = 180
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Observaciones").CellAppearance.TextHAlign = HAlign.Left
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Observaciones").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Observaciones").CellActivation = Activation.ActivateOnly
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Observaciones").CellAppearance.FontData.Bold = DefaultableBoolean.False
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Observaciones").CellAppearance.FontData.SizeInPoints = 8
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Observaciones").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Observaciones").Header.Appearance.FontData.SizeInPoints = 9
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("Observaciones").Header.Appearance.FontData.Bold = DefaultableBoolean.True

        DetalleRequerimiento.DisplayLayout.Bands(0).Columns.Add("CodigoProveedor")
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoProveedor").Width = 100
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoProveedor").CellAppearance.TextHAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoProveedor").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoProveedor").CellActivation = Activation.ActivateOnly
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoProveedor").CellAppearance.FontData.Bold = DefaultableBoolean.False
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoProveedor").CellAppearance.FontData.SizeInPoints = 8
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoProveedor").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoProveedor").Header.Appearance.FontData.SizeInPoints = 9
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("CodigoProveedor").Header.Appearance.FontData.Bold = DefaultableBoolean.True

        DetalleRequerimiento.DisplayLayout.Bands(0).Columns.Add("RazonSocial")
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("RazonSocial").Width = 210
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("RazonSocial").CellAppearance.TextHAlign = HAlign.Left
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("RazonSocial").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("RazonSocial").CellActivation = Activation.ActivateOnly
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("RazonSocial").CellAppearance.FontData.Bold = DefaultableBoolean.False
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("RazonSocial").CellAppearance.FontData.SizeInPoints = 8
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("RazonSocial").CellAppearance.TextVAlign = HAlign.Center
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("RazonSocial").Header.Appearance.FontData.SizeInPoints = 9
        DetalleRequerimiento.DisplayLayout.Bands(0).Columns("RazonSocial").Header.Appearance.FontData.Bold = DefaultableBoolean.True

    End Sub
#End Region

#End Region                    'Load

#Region "Eventos consolidar"
    Private Sub chkAplicarTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAplicarTodos.CheckedChanged
        If dgvRequerimientoCompraOrigen.Rows.Count > 0 Then
            For Each xRow As UltraGridRow In dgvRequerimientoCompraOrigen.Rows
                xRow.Cells("Action").Value = chkAplicarTodos.Checked
                Consolidado = False
            Next
            dgvRequerimientoCompraOrigen.UpdateData()
        End If
    End Sub


    Private Sub BtnConsolidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsolidar.Click
        Entidad.Requerimiento = New ETRequerimiento
        Consolidado = True
        Dim Nro_Req As String = String.Empty
        dgvRequerimientoCompraOrigen.UpdateData()
        If dgvRequerimientoCompraOrigen.Rows.Count > 0 Then
            For Each xRow As UltraGridRow In dgvRequerimientoCompraOrigen.Rows
                If xRow.Cells("Action").Value = True Then
                    If String.IsNullOrEmpty(Trim(Nro_Req)) Then
                        'Nro_Req = "'''" & Trim(xRow.Cells("Requerimiento").Value) & "''"
                        Nro_Req = "'" & Trim(xRow.Cells("Requerimiento").Value) & "'"
                    Else
                        'Nro_Req = Nro_Req & ",''" & Trim(xRow.Cells("Requerimiento").Value) & "''"
                        Nro_Req = Nro_Req & ",'" & Trim(xRow.Cells("Requerimiento").Value) & "'"
                    End If
                End If
            Next
        End If

        If String.IsNullOrEmpty(Trim(Nro_Req)) Then
            MsgBox("Debe Checkear al menos un Requerimiento de Compra", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        Else
            ' Nro_Req = Nro_Req & "'"
            With Entidad.Requerimiento
                .Cod_Cia = Companhia
                .NroReq = ""
                .Nro_Req_Origen = Nro_Req
                .Lugar_Ent = LugarEntrega.Value
                .FechaEmision = Now
                .Fec_Aprob = Now
            End With
            dgvDetalleReqConsolidado.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "DET2")
            TabReqCompraDet.Tabs("T02").Selected = True

            LsMaestroDocumentos = New List(Of ETLisMaestroDocumentosTecnicos)

            '   *****   Documentos Tecnicos *****

            If dgvDetalleReqConsolidado.Rows.Count > 0 Then

                Dim DtDocTec As New DataTable
                With Entidad.Pedido
                    .Numero_Doc = ""
                    .Requerimiento = Nro_Req
                    .Cod_Cia = Companhia
                End With
                DtDocTec = Negocio.PedidoBL.Listar_DocTec(Entidad.Pedido, "RODT")
                If DtDocTec.Rows.Count > 0 Then
                    For i As Integer = 0 To DtDocTec.Rows.Count - 1
                        Maestro = New ETLisMaestroDocumentosTecnicos
                        With Maestro
                            For Each xRow As UltraGridRow In dgvDetalleReqConsolidado.Rows
                                If Trim(xRow.Cells("Codigo").Value) = DtDocTec.Rows(i).Item("Codigo") Then
                                    .Item = xRow.Cells("Item").Value
                                    .Codigo_Producto = DtDocTec.Rows(i).Item("Codigo")
                                    .Producto = DtDocTec.Rows(i).Item("Producto")
                                    .Cod_DocTecnico = DtDocTec.Rows(i).Item("Documento")
                                    .Estado = "A"
                                    LsMaestroDocumentos.Add(Maestro)
                                    Exit For
                                End If
                            Next

                        End With

                    Next
                End If
            End If
        End If



    End Sub

#End Region
    

#Region "Grilla"

    Private Sub dgvDetalleReqConsolidado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalleReqConsolidado.InitializeLayout
        If e Is Nothing Then Exit Sub

        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If xCol.Key = "Codigo" OrElse xCol.Key = "Descripcion" _
               OrElse xCol.Key = "UMStock" OrElse xCol.Key = "Stock" _
               OrElse xCol.Key = "UM" OrElse xCol.Key = "CantidadRequerida" _
               OrElse xCol.Key = "Empleo" OrElse xCol.Key = "Observaciones" _
               OrElse xCol.Key = "CodigoProveedor" OrElse xCol.Key = "RazonSocial" _
               Then
                If xCol.Key = "UMStock" Then
                    xCol.MaxWidth = 45
                    xCol.MinWidth = 45
                    xCol.CellAppearance.FontData.Bold = DefaultableBoolean.False
                    xCol.CellAppearance.FontData.SizeInPoints = 8
                    xCol.Header.Caption = "UM" & Chr(13) & "Stock"
                End If
                xCol.Hidden = False
                xCol.CellActivation = Activation.ActivateOnly
            Else
                xCol.Hidden = True
            End If
        Next
    End Sub

    Private Sub dgvRequerimientoCompraOrigen_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvRequerimientoCompraOrigen.AfterCellUpdate
        Consolidado = False
    End Sub

    Private Sub dgvRequerimientoCompraOrigen_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvRequerimientoCompraOrigen.BeforeRowsDeleted
        If e Is Nothing Then Exit Sub
        e.DisplayPromptMsg = False
    End Sub

    Private Sub dgvDetalleAtendido_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvDetalleAtendido.DoubleClickRow
        If e Is Nothing Then Exit Sub
        If dgvDetalleAtendido.Rows.Count <= 0 Then Exit Sub
        If dgvDetalleAtendido.ActiveRow.Cells("CantidadOC").Value <= 0 Then Exit Sub
        TxtCodigo.Text = Trim(dgvDetalleAtendido.ActiveRow.Cells("Codigo").Value)
        TxtProducto.Text = Trim(dgvDetalleAtendido.ActiveRow.Cells("Descripcion").Value)
        TxtUnd.Text = Trim(dgvDetalleAtendido.ActiveRow.Cells("UM").Value)
        TxtCantidadRequerida.Text = dgvDetalleAtendido.ActiveRow.Cells("CantidadRequerida").Value
        TxtCantidadOrdenCompra.Text = dgvDetalleAtendido.ActiveRow.Cells("CantidadOC").Value
        TxtItem.Text = dgvDetalleAtendido.ActiveRow.Cells("Item").Value
        TxtDecimal.Text = dgvDetalleAtendido.ActiveRow.Cells("Decimal").Value
        Entidad.Requerimiento = New ETRequerimiento
        With Entidad.Requerimiento
            .Cod_Cia = Companhia
            .NroReq = Trim(LblNroRequerimiento.Text)
            .CodigoProducto = Trim(TxtCodigo.Text)
            .Item = TxtItem.Text
        End With

        dgvDetalleAdquisicion.DataSource = Negocio.Requerimiento.ListarRequerimientoCompra_Consolidado_Distribuir(Entidad.Requerimiento, "4")
        TabReqCompraDet.Tabs("T03").Enabled = True
        TabReqCompraDet.Tabs("T03").Selected = True
    End Sub

    Private Sub dgvDetalleAdquisicion_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvDetalleAdquisicion.AfterCellUpdate
        If e.Cell.Column.Key = "CantidadDist" Then
            If e.Cell.Row.Cells("CantidadReq").Value < Val(e.Cell.Value) Then
                MsgBox("Excede la Cantidad del Nro. Req.: " & e.Cell.Row.Cells("Nro_Requi_Orig").Value, MsgBoxStyle.Critical, msgComacsa)
                e.Cell.Value = 0
            ElseIf e.Cell.Row.Cells("CantidadOC").Value < Val(e.Cell.Value) Then
                MsgBox("Excede de la Cantidad O/C: " & e.Cell.Row.Cells("NRO_OC").Value, MsgBoxStyle.Critical, msgComacsa)
                e.Cell.Value = 0
            End If
        End If
        
    End Sub


    Private Sub Grilla_Consolidado_Distribuido_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalleAtendido.InitializeLayout, dgvDetalleAdquisicion.InitializeLayout

        If e Is Nothing Then Exit Sub

        If sender Is dgvDetalleAtendido Then
            For Each xRow As UltraGridRow In dgvDetalleAtendido.Rows
                If xRow.Cells("CantidadOC").Value > 0 Then
                    xRow.CellAppearance.BackColor = Color.LightYellow
                End If
            Next
        End If

        If sender Is dgvDetalleAdquisicion Then
            For Each xCol As UltraGridColumn In dgvDetalleAdquisicion.DisplayLayout.Bands(0).Columns
                If xCol.Key = "CantidadDist" Then
                    If Val(TxtDecimal.Text) = 0 Then
                        xCol.Style = UltraWinGrid.ColumnStyle.IntegerNonNegative
                        xCol.Format = "n"
                    Else
                        xCol.Style = UltraWinGrid.ColumnStyle.DoubleNonNegative
                        xCol.Format = "n4"
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub dgvDetalleAdquisicion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalleAdquisicion.KeyDown
        Try
            Dim f As System.EventArgs = Nothing
            With dgvDetalleAdquisicion
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(AboveCell, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Down
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(BelowCell, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Right
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(NextCellByTab, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Left
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(PrevCellByTab, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Return
                        .PerformAction(ExitEditMode, False, False)
                        e.Handled = True
                        .PerformAction(NextRow, False, False)
                        .ActiveRow.Cells("CantidadDist").Activate()
                        .PerformAction(EnterEditMode, False, False)
                End Select
            End With
        Catch
            Exit Sub
        End Try
    End Sub
#End Region

#Region "Evento Distribuir"

    Private Sub TabReqCompraDet_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabReqCompraDet.SelectedTabChanged
        If Not (TabReqCompraDet.Tabs("T03").Selected = True) Then
            TabReqCompraDet.Tabs("T03").Enabled = False
        End If
    End Sub

    Private Sub btnGrabarReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarReq.Click
        Dim Suma As Double = 0
        Dim i As Integer = 0
        Dim Er As Integer = 0
        Dim Existe As Integer = 0

        dgvDetalleAdquisicion.UpdateData()
        If dgvDetalleAdquisicion.Rows.Count < 0 Then Exit Sub
        If Val(TxtCantidadOrdenCompra.Text) <= 0 Then
            MsgBox("No hay Cantidad a Distribuir", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        Dim ListaTemp As New List(Of ETListDetalleRequerimiento)

        For Each xRow As UltraGridRow In dgvDetalleAdquisicion.Rows
            Suma = Suma + Val(xRow.Cells("CantidadDist").Value)
            If Val(xRow.Cells("CantidadReq").Value) < Val(xRow.Cells("CantidadDist").Value) Then
                xRow.CellAppearance.BackColor = Color.Red
                Er = Er + 1
            ElseIf xRow.Cells("CantidadOC").Value < Val(xRow.Cells("CantidadDist").Value) Then
                xRow.CellAppearance.BackColor = Color.Orange
                Er = Er + 1
            ElseIf Val(TxtCantidadOrdenCompra.Text) < Val(Suma) Then
                xRow.CellAppearance.BackColor = Color.Yellow
                Er = Er + 1
            Else
                xRow.CellAppearance.BackColor = Color.White
            End If

            Entidad.RequerimientoDetalle = Nothing
            Entidad.RequerimientoDetalle = New ETListDetalleRequerimiento
            With Entidad.RequerimientoDetalle
                .Nro_Req = Trim(LblNroRequerimiento.Text)
                .Codigo = Trim(TxtCodigo.Text)
                .Item = Trim(TxtItem.Text)
                .Nro_Req_Orig = Trim(xRow.Cells("Nro_Requi_Orig").Value)
                .Item_Req_Orig = Trim(xRow.Cells("Item_Orig").Value)
                .Nro_OC = Trim(xRow.Cells("NRO_OC").Value)
                .Item_OC = Trim(xRow.Cells("Item").Value)
                .CantidadDist = Val(xRow.Cells("CantidadDist").Value)
                .Usuario = User_Sistema
            End With
            ListaTemp.Add(Entidad.RequerimientoDetalle)
        Next

        If Suma <> Val(TxtCantidadOrdenCompra.Text) Then
            MsgBox("Debe Distribuir todo los Adquirido(Cant. Distribuida: " & FormatNumber(Suma, 4) & ")", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If Er = 0 Then
            i = 0
            If LstDetalleAquisicion.Count > 0 Then
                While i < LstDetalleAquisicion.Count
                    If Trim(LstDetalleAquisicion(i).Codigo) = Trim(TxtCodigo.Text) And _
                       Val(LstDetalleAquisicion(i).Item) = Val(TxtItem.Text) Then
                    Else
                        i = i + 1
                    End If
                End While
            End If
            i = 0
            Existe = 0
            If LstDetalleAtendido.Count > 0 Then
                While i < LstDetalleAtendido.Count
                    If Trim(LstDetalleAtendido(i).Codigo) = Trim(TxtCodigo.Text) And _
                       Val(LstDetalleAtendido(i).Item) = Val(TxtItem.Text) Then
                        Existe = Existe + 1
                        i = i + LstDetalleAtendido.Count
                    Else
                        i = i + 1
                    End If
                End While
            End If

            If Existe = 0 Then
                Entidad.RequerimientoDetalle = Nothing
                Entidad.RequerimientoDetalle = New ETListDetalleRequerimiento
                With Entidad.RequerimientoDetalle
                    .Nro_Req = Trim(LblNroRequerimiento.Text)
                    .Codigo = Trim(TxtCodigo.Text)
                    .Item = Trim(TxtItem.Text)
                    .Usuario = User_Sistema
                End With
                LstDetalleAtendido.Add(Entidad.RequerimientoDetalle)
            End If

            i = 0
            While i < ListaTemp.Count
                LstDetalleAquisicion.Add(ListaTemp(i))
                i = i + 1
            End While

        End If

    End Sub

    Private Sub BtnSalirAdq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalirAdq.Click
        TabReqCompraDet.Tabs("T02").Selected = True
    End Sub
#End Region

    Private Sub dgvRequerimientoCompraOrigen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvRequerimientoCompraOrigen.InitializeLayout

    End Sub
End Class