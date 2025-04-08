Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class FrmPedidoSuministro
    Public Ls_Permisos As New List(Of Integer)
    Dim procesado As Int32
    Dim _objNegocio As NGInsumosFiscalizados
    Dim _objEntidad As ETInsumosFiscalizados
    Dim cierre As Int32 = 0
    Private Ls_RumaSuministro As List(Of ETRuma) = Nothing
    Private CodRuma As String = String.Empty
    Dim _objNegocio_ As NGProducto
    Dim _objEntidad_ As ETProducto
    Public Lista As List(Of ETRuma) = Nothing
    Sub Nuevo()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Limpiar()
        CboArea_ValueChanged(Nothing, Nothing)

        Limpiar_GRE()
        UTabDetalle.Tabs("detalle").Selected = Boolean.TrueString
        OptConsumoInterno.Checked = True

    End Sub

    Sub Limpiar()
        chkproduccion.Checked = False
        chkproduccion.Visible = False
        txtcodcantera.Clear()
        txtcantera.Clear()
        txtcodequipo.Clear()
        txtequipo.Clear()
        TxtCodigoTrabajador.Clear()
        txtcomentario.Clear()
        TxtNombresTrabajador.Clear()
        chkAprobar.Checked = False
        chkAnulado.Checked = False
        chkAnulado.Visible = False

        txtid.Text = 0

        'Grid4.Update()
        'Grid4.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpRow)
        Grid4.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

        For i As Int32 = Grid4.Rows.Count - 1 To 0 Step -1
            Grid4.Rows(i).Delete()
        Next
        UltraGroupBox2.Enabled = True
        chkurgente.Enabled = True
        CboArea.Enabled = True
        TxtCodigoTrabajador.Enabled = True
        txtcomentario.Enabled = True
        TxtCodigoTrabajador.Text = codTrabajadorInicio.Trim
        TxtNombresTrabajador.Text = nomTrabajadorInicio.Trim

        UltraLabel6.Visible = False
        cmbmant.Visible = False
        UltraLabel8.Visible = False

        UCboAlmSol.Enabled = True
        Limpiar_GRE()
        'cmbAlmacen.Visible = False
        'add jcms 260423
        'cmbAlmacen.Visible = True

    End Sub

    Private Sub FrmPedidoSuministro_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'If sender Is Nothing OrElse e Is Nothing Then
        '    Return
        'End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub FrmPedidoSuministro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario
        Dim dtValores As New DataTable
        dtValores = Negocio.Usuario.Area_Usuario(User_Sistema)
        Call CargarUltraCombo(CboArea, dtValores, "cod_maestro2", "descrip")


       


        CargaDatos()
        userAprueba()
        TxtCodigoTrabajador.Text = codTrabajadorInicio.Trim
        TxtNombresTrabajador.Text = nomTrabajadorInicio.Trim
        cargaAlmacen()
        cargaAlmacen_Solicitante()
        CboArea_ValueChanged(Nothing, Nothing)

    End Sub
    Sub CargaDatosMaestros_GRE()
        'add jcms 170723
        Dim dtDocIde As New DataTable
        dtDocIde = Negocio.Usuario.DocIdentidad_Usuario(User_Sistema)
        Call CargarUltraCombo(UCboDest_TipoDocIde, dtDocIde, "cod_maestro2", "descrip")
        Call CargarUltraCombo(UCboChofer_DocIde, dtDocIde, "cod_maestro2", "descrip")

        'motivo traslado
        Dim dtMotTras As New DataTable
        dtMotTras = Negocio.Usuario.MotivoTraslado_Usuario(User_Sistema)
        Call CargarUltraCombo(UcboMotivoTraslado, dtMotTras, "cod_maestro2", "descrip")


    End Sub
    Sub cargaAlmacen()
        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario
        Dim dtValores As New DataTable
        dtValores = Negocio.Usuario.ListarAlmacen(User_Sistema)
        Call CargarUltraCombo(cmbAlmacen, dtValores, "cod_alm", "descrip")
        'add jcms se desactiva para el ingreso de alam. intermedios
        cmbAlmacen.Value = "07" 'PASTAS
    End Sub
    Sub cargaAlmacen_Solicitante()
        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario
        Dim dtValoresSolicitante As New DataTable
        dtValoresSolicitante = Negocio.Usuario.ListarAlmacenSolicitante(User_Sistema)
        Call CargarUltraCombo(UCboAlmSol, dtValoresSolicitante, "cod_alm", "descrip")
        'add jcms se desactiva para el ingreso de alam. intermedios
        UCboAlmSol.Value = "28" 'defecto alm. central suministros
    End Sub

    Sub CargaDatos()
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        Dim dt As New DataTable
        dt = _objNegocio_.ListaPedidosSuministro(User_Sistema)
        Call CargarUltraGridxBinding(Grid1, Source1, dt)
        UTabDetalle.Tabs("detalle").Selected = Boolean.TrueString

    End Sub

    Sub userAprueba()
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        Dim dt As New DataTable
        dt = _objNegocio_.userapruebaSuministro(User_Sistema)
        If dt.Rows.Count > 0 Then
            chkAprobar.Visible = True
            chkAnulado.Visible = True
        Else
            chkAprobar.Visible = False
            chkAnulado.Visible = False
        End If
    End Sub

    Private Sub CboArea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles CboArea.InitializeLayout
        With CboArea.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descrip").Width = 500 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descrip") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    'Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If
    '    If CboArea.Value Is Nothing Then MsgBox("Debe seleccionar área", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
    '    If UCboAlmSol.Value Is Nothing Then MsgBox("Elija almacen solicitante.", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
    '    If sender Is Btn7 Then
    '        'Grid1.PerformAction(ExitEditMode)

    '        StrucForm.FxListaSuministro = New frmListaSuministro
    '        StrucForm.FxListaSuministro.ls_IdAlmacenSolicitante = UCboAlmSol.Value
    '        AddHandler StrucForm.FxListaSuministro.Closing, AddressOf Cargar_RumaxSuministro
    '        StrucForm.FxListaSuministro.MdiParent = MdiParent
    '        StrucForm.FxListaSuministro.L = Boolean.TrueString
    '        StrucForm.FxListaSuministro.Show()
    '        StrucForm.FxListaSuministro = Nothing
    '        UCboAlmSol.Enabled = False
    '        Return
    '    End If
    'End Sub

    Sub Cargar_RumaxSuministro(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If Ls_RumaSuministro Is Nothing Then Ls_RumaSuministro = New List(Of ETRuma)

        For Each W As ETRuma In sender.Lista
            CodRuma = String.Empty : CodRuma = W.CodRuma

            'Este seccion de codigo se modifica por que en el caso de Amelia 
            'requiere de ingresar varias unidades del mismo consumo como es el caso de petroleo 
            'solo se asigna para el caso de KTELLO
            '----------------------------------------------------
            If User_Sistema = "AMELIAA" Then
                ' Verifica si el código ya existe en la lista
                If Ls_RumaSuministro.Exists(AddressOf Existe_Ruma) Then
                    ' Pregunta al usuario si desea permitir el código repetido
                    Dim respuesta As DialogResult = MessageBox.Show("El código " & CodRuma & " ya existe. ¿Desea permitir agregarlo de todos modos?", "Código Repetido", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    ' Si el usuario elige "No", se omite este elemento y se continúa con el siguiente
                    If respuesta = DialogResult.No Then
                        Continue For
                    End If
                End If
                ' Si el código no existe o el usuario permite agregarlo, se añade a la lista
                Ls_RumaSuministro.Add(W)
            Else
                If Not Ls_RumaSuministro.Exists(AddressOf Existe_Ruma) Then Ls_RumaSuministro.Add(W)
            End If
            '----------------------------------------------------

        Next

        Call CargarUltraGrid(Grid4, Ls_RumaSuministro)

        Dim dtAuxi3 As New DataTable
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.codArea = CboArea.Value
        Entidad.Entregas.codConcepto = ""
        Entidad.Entregas.Anho = Year(Now.Date)
        dtAuxi3 = Negocio.NEntregas.VerAuxi3Log(Entidad.Entregas)
        If dtAuxi3.Rows.Count = 1 Then
            For I As Int32 = 0 To Grid4.Rows.Count - 1
                Grid4.Rows(I).Cells("codAnexo3").Value = dtAuxi3.Rows(0)(0)
            Next
        End If
        If dtAuxi3.Rows.Count = 0 Then
            For I As Int32 = 0 To Grid4.Rows.Count - 1
                Grid4.Rows(I).Cells("codAnexo3").Value = CboArea.Value
            Next
        End If
    End Sub

    Function Existe_Ruma(ByVal Rpt As ETRuma) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.CodRuma = CodRuma Then
            lResult = Boolean.TrueString
        End If

        Return lResult

    End Function

    Private Sub Grid4_BeforeRowsDeleted1(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles Grid4.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        'If sender IsNot Grid2 And sender IsNot Grid4 And sender IsNot Grid4 Then Return

        e.DisplayPromptMsg = Boolean.FalseString
    End Sub

    'Private Sub Grid4_BeforeRowsDeleted1(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles Grid4.BeforeRowsDeleted

    'End Sub

    Private Sub Grid4_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid4.InitializeLayout
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender Is Grid4 Then

            'If Tag = StrucToolTag.Nulo Then Return

            'If Tag = StrucToolTag.MProductoRuma OrElse Tag = StrucToolTag.MFormula Then
            Call ProductoTerminado_InitializeLayout(e) : Return
            'End If

        End If
    End Sub

    Sub ProductoTerminado_InitializeLayout(ByVal e As InitializeLayoutEventArgs)

        If e Is Nothing Then
            Return
        End If

        With e.Layout.Bands(0)

            If Tag = StrucToolTag.MProductoRuma Then
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "CodRuma" Or uColumn.Key = "Descripcion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            Else
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Descripcion" OrElse _
                            uColumn.Key = "CodRuma" OrElse _
                            uColumn.Key = "StockD" OrElse uColumn.Key = "codAnexo3" OrElse uColumn.Key = "Cantidad" OrElse uColumn.Key = "Cantera" OrElse uColumn.Key = "Equipo" OrElse uColumn.Key = "Trabajador") Then
                        'uColumn.Key = "StockD" OrElse _uColumn.Key = "PartidaPresupuestal" OrElse uColumn.Key = "codAnexo3" OrElse uColumn.Key = "Cantidad" OrElse uColumn.Key = "Cantera" OrElse uColumn.Key = "Equipo" OrElse uColumn.Key = "Trabajador") Then

                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End If

            .Columns("CodRuma").Header.VisiblePosition = 0
            .Columns("Descripcion").Header.VisiblePosition = 1
            .Columns("Cantera").Header.VisiblePosition = 2
            .Columns("Equipo").Header.VisiblePosition = 3
            .Columns("Trabajador").Header.VisiblePosition = 4
            .Columns("codAnexo3").Header.VisiblePosition = 5
            .Columns("StockD").Header.VisiblePosition = 6
            .Columns("Cantidad").Header.VisiblePosition = 7
            '.Columns("TipoEnlace").Header.VisiblePosition = 8
            '.Columns("Merma").Header.VisiblePosition = 4

        End With

    End Sub

    Sub Reporte()
        StrucForm.FxRxRptPedido = New FrmRptPedido
        StrucForm.FxRxRptPedido.MdiParent = MdiParent
        StrucForm.FxRxRptPedido.id = txtid.Text
        StrucForm.FxRxRptPedido.Show()
    End Sub
    Sub ConfirmarGrabar(ByVal mensaje As String)
        If MsgBox("Desea grabar pedido?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
            If txtid.Text = "" Then txtid.Text = 0
            Dim idpedido As Int32 = txtid.Text

            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .Cod_Cia = Companhia
                .Ope = 1
                .id = idpedido
                .cod_area = CboArea.Value
                .cod_labor = CboEmpleo.Value
                .cod_cantera = txtcodcantera.Text
                .cod_equipo = txtcodequipo.Text
                .cod_trabajador = TxtCodigoTrabajador.Text
                .aprobado = IIf(chkAprobar.Checked = True, 1, 0)
                .urgente = IIf(chkurgente.Checked = True, 1, 0)
                .anulado = IIf(chkAnulado.Checked = True, 1, 0)
                .Observacion = txtcomentario.Text
                .T_Mantenimiento = cmbmant.Text
                .cod_Almacen = IIf(chkproduccion.Checked = True, cmbAlmacen.Value, "")
                .User_Crea = User_Sistema
                .cod_Almacen_Solicitante = UCboAlmSol.Value

                .gre_id_motivo_traslado = UcboMotivoTraslado.Value
                .gre_id_modalidad_traslado = IIf(OptTransp_Publico.Checked = True, "01", "02")
                .gre_dest_id_doc_identidad = UCboDest_TipoDocIde.Value
                .gre_dest_nro_doc_identidad = UTxtDestino_DocIde.Text.Trim
                .gre_dest_nombre = UTxtDestino_ApeNom.Text.Trim
                .gre_ptollegada_direccion = UTxtLlegada_Direccion.Text.Trim
                .gre_ptollegada_codubigeo = UTxtLlegada_Ubigeo.Tag.TRIM
                .gre_ptollegada_ruc_establecimiento = UTxtLlegada_RucEstablecimiento.Text.Trim
                .gre_ptollegada_codestablecimiento = UTxtLlegada_CodEstab.Text.Trim
                .gre_transp_ruc = UTxtTransp_Ruc.Text.Trim
                .gre_transp_nombre = UTxtTransp_Razsoc.Text.Trim
                .gre_chofer_id_doc_identidad = UCboChofer_DocIde.Value
                .gre_chofer_nro_doc_identidad = UTxtChofer_NroDocIde.Text.Trim
                .gre_chofer_apellidos = UTxtChofer_Apellidos.Text.Trim
                .gre_chofer_nombres = UTxtChofer_Nombres.Text.Trim
                .gre_chofer_nro_licencia = UTxtChofer_NroLicencia.Text.Trim
                .gre_vehiculo_indicador_traslado_M1 = UChkIndicadorM1.Checked
                .gre_vehiculo_pri_placa = UTxtChofer_NroPlacaPri.Text.Trim
                .gre_vehiculo_pri_nrotarjeta_circulacion = ""
                .gre_vehiculo_sec_placa = ""
                .gre_vehiculo_sec_nrotarjeta_circulacion = ""
                .gre_envio_nro_bultos = UTxtEnvio_NroBultos.Text
                .gre_envio_peso_bruto_carga_kgs = UTxtEnvio_PesoBruto.Text.Trim
                .gre_observacion = UTxtEnvio_Obs.Text.Trim
                .nroorden_trabajo = UTxtNroOT.Text.Trim
            End With
            idpedido = oPrvFisN.PedidoSuministro(oPrvFisE).Rows(0)(0)
            Dim DTDETALLE As New DataTable
            'Dim parpre As String = ""

            If idpedido <> 0 Then

                For i As Int32 = 0 To Grid4.Rows.Count - 1

                    oPrvFisN = New NGProveedorFiscalizado
                    oPrvFisE = New ETProveedorFiscalizado
                    DTDETALLE = New DataTable
                    With oPrvFisE
                        .id = idpedido
                        .Cod_Prod = Grid4.Rows(i).Cells("CodRuma").Value
                        .Cantidad = Grid4.Rows(i).Cells("Cantidad").Value
                        .cod_cantera = Grid4.Rows(i).Cells("CANTERA").Value
                        .cod_equipo = Grid4.Rows(i).Cells("EQUIPO").Value
                        .cod_trabajador = Grid4.Rows(i).Cells("TRABAJADOR").Value
                        .Stock = Grid4.Rows(i).Cells("STOCKD").Value
                        .cod_anexo3 = Grid4.Rows(i).Cells("codAnexo3").Value
                        'If Trim(Grid4.Rows(i).Cells("PartidaPresupuestal").Value) = "" Then
                        '    parpre = 0
                        'Else
                        '    parpre = Trim(Grid4.Rows(i).Cells("PartidaPresupuestal").Value)
                        'End If
                        '.iduso = Convert.ToInt16(parpre)
                    End With

                    DTDETALLE = oPrvFisN.PedidoSuministro_Det(oPrvFisE)

                Next
            End If
            MsgBox(mensaje, MsgBoxStyle.Information, msgComacsa)
            Procesar()
            'Limpiar()
            'CargaDatos()
            'Tab1.Tabs("T01").Selected = Boolean.TrueString
        End If
    End Sub


    Sub Grabar()

        Try
            'Grid4.PerformAction(ExitEditMode)

            Grid4.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpRow)
            Grid4.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

            'If CboArea.Value = "44" Then
            '    UltraLabel6.Visible = True
            '    cmbmant.Visible = True
            'Else
            '    UltraLabel6.Visible = False
            '    cmbmant.Visible = False
            'End If
            If CboArea.Value = "44" And cmbmant.SelectedIndex < 0 Then
                MsgBox("Ingrese tipo de mantenimiento", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            End If

            If CboArea.Value = "35" And cmbAlmacen.Value Is Nothing Then
                MsgBox("Ingrese almacén de destino", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            End If
            'add jcms 260423
            If UCboAlmSol.Value Is Nothing Then
                MsgBox("Elija almacén solicitante", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            End If


            For i As Int32 = 0 To Grid4.Rows.Count - 1
                If Grid4.Rows(i).Cells("codAnexo3").Value = "" Then
                    MsgBox("Ingrese anexo 3 en la fila " & i + 1, MsgBoxStyle.Information, msgComacsa) : Exit Sub
                End If
                If CboArea.Value = "44" And Grid4.Rows(i).Cells("Equipo").Value = "" Then
                    MsgBox("Ingrese equipo en la fila " & i + 1, MsgBoxStyle.Information, msgComacsa) : Exit Sub
                End If
                If CboArea.Value = "28" And Grid4.Rows(i).Cells("Cantera").Value = "" Then
                    MsgBox("Ingrese cantera en la fila " & i + 1, MsgBoxStyle.Information, msgComacsa) : Exit Sub
                End If
            Next

            If CboArea.Value Is Nothing Then MsgBox("Debe ingresar área", MsgBoxStyle.Information, msgComacsa) : Exit Sub

            If CboEmpleo.Rows.Count > 0 Then
                If CboEmpleo.Value Is Nothing Then MsgBox("Debe ingresar labor/empleo", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            End If

            If Grid4.Rows.Count = 0 Then MsgBox("Debe ingresar mínimo un producto", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            If TxtCodigoTrabajador.Text = "" Then MsgBox("Debe ingresar trabajador solicitante", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            Dim cantidad As Double = 0
            Dim stock As Double = 0
            Dim equipo As String = ""
            For i As Int32 = 0 To Grid4.Rows.Count - 1
                cantidad = Grid4.Rows(i).Cells("CANTIDAD").Value
                stock = Grid4.Rows(i).Cells("STOCKD").Value
                equipo = Grid4.Rows(i).Cells("EQUIPO").Value
                If cantidad = 0 Then MsgBox("No puede ingresar una cantidad en 0", MsgBoxStyle.Information, msgComacsa) : Exit Sub
                If cantidad > stock Then MsgBox("No puede ingresar una cantidad mayor al stock", MsgBoxStyle.Information, msgComacsa) : Exit Sub
                If equipo = "" Then MsgBox("Debe ingresar una unidad de Producción", MsgBoxStyle.Information, msgComacsa) : Exit Sub
                'If Grid4.Rows(i).Cells("TipoEnlace").Value <> "001" And (Trim(Grid4.Rows(i).Cells("PartidaPresupuestal").Value) = "" Or Trim(Grid4.Rows(i).Cells("PartidaPresupuestal").Value) = "0") Then MsgBox("Debe ingresar una Partida presupuestal", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            Next
            Dim mensaje As String
            If chkAnulado.Checked = True Then
                If MsgBox("Desea anular pedido?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                    mensaje = "Pedido Anulado Exitosamente"
                    ConfirmarGrabar(mensaje)
                End If
            Else
                If OptGRE.Checked Then
                    If Not ValidarGRE() Then Exit Sub
                End If
                mensaje = "Pedido generado exitosamente"
                '--------------------------------
                ConfirmarGrabar(mensaje)
                '--------------------------------
            End If


        Catch ex As Exception

        End Try
    End Sub

    Sub Eliminar()
        Try
            Grid4.PerformAction(ExitEditMode)

            'For i As Int32 = 0 To Grid4.Rows.Count - 1
            '    If Grid4.Rows(i).Cells("codAnexo3").Value = "" Then
            '        MsgBox("Ingrese anexo 3 en la fila " & i + 1, MsgBoxStyle.Information, msgComacsa) : Exit Sub
            '    End If
            'Next
            If txtid.Text = "" Then txtid.Text = 0
            If txtid.Text = 0 Then MsgBox("Seleccione pedido a eliminar", MsgBoxStyle.Information, msgComacsa) : Exit Sub

            'Condicional para que no se puedan eliminar pedidos anulados o aprobados
            If chkAnulado.Checked = True Then
                MsgBox("No puede eliminar un pedido anulado", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            ElseIf chkAprobar.Checked = True Then
                MsgBox("No puede eliminar un pedido aprobado", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            End If
            

            If CboArea.Value Is Nothing Then MsgBox("Debe ingresar área", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            If Grid4.Rows.Count = 0 Then MsgBox("Debe ingresar mínimo un producto", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            If TxtCodigoTrabajador.Text = "" Then MsgBox("Debe ingresar trabajador solicitante", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            Dim cantidad As Double = 0
            Dim stock As Double = 0
            For i As Int32 = 0 To Grid4.Rows.Count - 1
                cantidad = Grid4.Rows(i).Cells("CANTIDAD").Value
                stock = Grid4.Rows(i).Cells("STOCKD").Value
                If cantidad = 0 Then MsgBox("No puede ingresar una cantidad en 0", MsgBoxStyle.Information, msgComacsa) : Exit Sub
                If cantidad > stock Then MsgBox("No puede ingresar una cantidad mayor al stock", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            Next

            If MsgBox("Desea eliminar pedido?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                If txtid.Text = "" Then txtid.Text = 0
                Dim idpedido As Int32 = txtid.Text

                Dim oPrvFisN As NGProveedorFiscalizado = Nothing
                Dim oPrvFisE As ETProveedorFiscalizado = Nothing

                oPrvFisN = New NGProveedorFiscalizado
                oPrvFisE = New ETProveedorFiscalizado

                With oPrvFisE
                    .Cod_Cia = Companhia
                    .Ope = 3
                    .id = idpedido
                    .cod_area = CboArea.Value
                    .cod_cantera = txtcodcantera.Text
                    .cod_equipo = txtcodequipo.Text
                    .cod_trabajador = TxtCodigoTrabajador.Text
                    .aprobado = IIf(chkAprobar.Checked = True, 1, 0)
                    .urgente = IIf(chkurgente.Checked = True, 1, 0)
                    .anulado = IIf(chkAnulado.Checked = True, 1, 0)
                    .Observacion = txtcomentario.Text
                    .T_Mantenimiento = cmbmant.Text
                    .User_Crea = User_Sistema
                End With
                idpedido = oPrvFisN.PedidoSuministro(oPrvFisE).Rows(0)(0)

                'Dim DTDETALLE As New DataTable
                'If idpedido <> 0 Then

                '    For i As Int32 = 0 To Grid4.Rows.Count - 1

                '        oPrvFisN = New NGProveedorFiscalizado
                '        oPrvFisE = New ETProveedorFiscalizado
                '        DTDETALLE = New DataTable
                '        With oPrvFisE
                '            .id = idpedido
                '            .Cod_Prod = Grid4.Rows(i).Cells("CodRuma").Value
                '            .Cantidad = Grid4.Rows(i).Cells("Cantidad").Value
                '            .cod_cantera = Grid4.Rows(i).Cells("CANTERA").Value
                '            .cod_equipo = Grid4.Rows(i).Cells("EQUIPO").Value
                '            .cod_trabajador = Grid4.Rows(i).Cells("TRABAJADOR").Value
                '            .Stock = Grid4.Rows(i).Cells("STOCKD").Value
                '            .cod_anexo3 = Grid4.Rows(i).Cells("codAnexo3").Value
                '        End With
                '        DTDETALLE = oPrvFisN.PedidoSuministro_Det(oPrvFisE)

                '    Next
                'End If
                MsgBox("Pedido eliminado exitosamente", MsgBoxStyle.Information, msgComacsa)
                Procesar()
                'Limpiar()
                'CargaDatos()
                'Tab1.Tabs("T01").Selected = Boolean.TrueString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Procesar()
        Limpiar()
        CargaDatos()
        Tab1.Tabs("T01").Selected = Boolean.TrueString
    End Sub
    Sub Buscar()
        If txtcodequipo.Focused = True Then
            txtequipo.Clear()
            txtcodequipo.Clear()
            Dim frm As New FrmBuscarMquina
            frm.ShowDialog()
            txtequipo.Text = frm.gridMaquina.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
            txtcodequipo.Text = frm.gridMaquina.ActiveRow.Cells("PLACA").Value.ToString.Trim
            TxtCodigoTrabajador.Focus()
            Exit Sub
        End If
        If txtcodcantera.Focused = True Then
            Dim frm As New FrmCosto_ListaCantera
            frm.ShowDialog()
            If Not codProducto = "" Then
                txtcodcantera.Text = codProducto
                txtcantera.Text = Producto
                codProducto = ""
                Producto = ""
            End If
            txtcodequipo.Focus()
            Exit Sub
        End If
        If TxtCodigoTrabajador.Focused = True Then
            Dim FRM As New FrmListadoPersonal
            FRM.ShowDialog()
            If codTrabajador.ToString.Trim = "" Then Return
            TxtCodigoTrabajador.Text = codTrabajador.ToString.Trim
            TxtNombresTrabajador.Text = nomTrabajador.ToString.Trim
            Exit Sub
        End If
    End Sub

    Private Sub txtcodequipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Buscar()
    End Sub

    Private Sub txtcodcantera_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Buscar()
    End Sub

    'Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If sender Is Btn8 Then

    '        If Not VerificarControl(5, Grid4) Then
    '            MessageBox.Show("No tiene producto para quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Return
    '        End If

    '        If Grid4.ActiveRow Is Nothing Then
    '            MessageBox.Show("No tiene un producto seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Return
    '        End If
    '        Grid4.ActiveRow.Delete()
    '    End If
    'End Sub

    Private Sub Grid4_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles Grid4.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid4 Then Return

        e.DisplayPromptMsg = Boolean.FalseString
    End Sub

    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow

        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If

            If sender IsNot Grid1 Then Return

            Limpiar()

            chkAnulado.Visible = False
            chkAprobar.Enabled = True
            Tab1.Tabs("T02").Selected = Boolean.TrueString
            CboArea.Value = Grid1.ActiveRow.Cells("COD_AREA").Value
            If CboArea.Value = "44" Then
                UltraLabel6.Visible = True
                cmbmant.Visible = True
            Else
                UltraLabel6.Visible = False
                cmbmant.Visible = False
            End If
            txtid.Text = Grid1.ActiveRow.Cells("ID").Value
            txtcodcantera.Text = Grid1.ActiveRow.Cells("COD_CANTERA").Value
            txtcantera.Text = Grid1.ActiveRow.Cells("CANTERA").Value
            txtcodequipo.Text = Grid1.ActiveRow.Cells("COD_EQUIPO").Value
            txtequipo.Text = Grid1.ActiveRow.Cells("EQUIPO").Value
            TxtCodigoTrabajador.Text = Grid1.ActiveRow.Cells("COD_TRABAJADOR").Value
            TxtNombresTrabajador.Text = Grid1.ActiveRow.Cells("TRABAJADOR").Value
            txtcomentario.Text = Grid1.ActiveRow.Cells("OBSERVACION").Value
            chkAprobar.Checked = IIf(Grid1.ActiveRow.Cells("APROBADO").Value = 1, True, False)
            chkurgente.Checked = IIf(Grid1.ActiveRow.Cells("URGENTE").Value = 1, True, False)
            chkAnulado.Checked = IIf(Grid1.ActiveRow.Cells("ESTADO").Value = "ANULADO", True, False)
            cmbmant.Text = Grid1.ActiveRow.Cells("MANTENIMIENTO").Value
            CboEmpleo.Value = Grid1.ActiveRow.Cells("COD_LABOR").Value

            UCboAlmSol.Value = Grid1.ActiveRow.Cells("COD_ALM_SOLICITANTE").Value
            'Dim ls_IdMotivo As String =t( Grid1.ActiveRow.Cells("gre_id_motivo_traslado").Value
            If Not IsDBNull(Grid1.ActiveRow.Cells("gre_id_motivo_traslado").Value) Then
                If Grid1.ActiveRow.Cells("gre_id_motivo_traslado").Value <> "00" Then
                    OptGRE.Checked = True
                    UcboMotivoTraslado.Value = Grid1.ActiveRow.Cells("gre_id_motivo_traslado").Value

                    If Grid1.ActiveRow.Cells("gre_id_modalidad_traslado").Value = "01" Then OptTransp_Publico.Checked = True
                    If Grid1.ActiveRow.Cells("gre_id_modalidad_traslado").Value = "02" Then OptTransp_Privado.Checked = True

                    '.gre_id_modalidad_traslado = IIf(OptTransp_Publico.Checked = True, "01", "02")

                    UCboDest_TipoDocIde.Value = Grid1.ActiveRow.Cells("gre_dest_id_doc_identidad").Value
                    UTxtDestino_DocIde.Text = Grid1.ActiveRow.Cells("gre_dest_nro_doc_identidad").Value.ToString().Trim
                    UTxtDestino_ApeNom.Text = Grid1.ActiveRow.Cells("gre_dest_nombre").Value.ToString().Trim

                    UTxtLlegada_Direccion.Text = Grid1.ActiveRow.Cells("gre_ptollegada_direccion").Value.ToString().Trim
                    UTxtLlegada_Ubigeo.Tag = Grid1.ActiveRow.Cells("gre_ptollegada_codubigeo").Value.ToString().Trim

                    UTxtLlegada_RucEstablecimiento.Text = Grid1.ActiveRow.Cells("gre_ptollegada_ruc_establecimiento").Value.ToString().Trim
                    UTxtLlegada_CodEstab.Text = Grid1.ActiveRow.Cells("gre_ptollegada_codestablecimiento").Value.ToString().Trim
                    UTxtTransp_Ruc.Text = Grid1.ActiveRow.Cells("gre_transp_ruc").Value.ToString().Trim
                    UTxtTransp_Razsoc.Text = Grid1.ActiveRow.Cells("gre_transp_nombre").Value.ToString().Trim
                    UCboChofer_DocIde.Value = Grid1.ActiveRow.Cells("gre_chofer_id_doc_identidad").Value.ToString().Trim
                    UTxtChofer_NroDocIde.Text = Grid1.ActiveRow.Cells("gre_chofer_nro_doc_identidad").Value.ToString().Trim
                    UTxtChofer_Apellidos.Text = Grid1.ActiveRow.Cells("gre_chofer_apellidos").Value.ToString().Trim
                    UTxtChofer_Nombres.Text = Grid1.ActiveRow.Cells("gre_chofer_nombres").Value.ToString().Trim
                    UTxtChofer_NroLicencia.Text = Grid1.ActiveRow.Cells("gre_chofer_nro_licencia").Value.ToString().Trim

                    If Grid1.ActiveRow.Cells("gre_vehiculo_indicador_traslado_M1").Value = True Then
                        UChkIndicadorM1.Checked = True
                    Else
                        UChkIndicadorM1.Checked = False
                    End If

                    UTxtChofer_NroPlacaPri.Text = Grid1.ActiveRow.Cells("gre_vehiculo_pri_placa").Value.ToString().Trim
                    'UTxtChofer_NroPlacaPri.Text = Grid1.ActiveRow.Cells("gre_vehiculo_pri_nrotarjeta_circulacion").Value
                    'UTxtChofer_NroPlacaPri.Text = Grid1.ActiveRow.Cells("gre_vehiculo_sec_placa").Value
                    'UTxtChofer_NroPlacaPri.Text = Grid1.ActiveRow.Cells("gre_vehiculo_sec_nrotarjeta_circulacion").Value
                    '.gre_vehiculo_pri_nrotarjeta_circulacion = ""
                    '.gre_vehiculo_sec_placa = ""
                    '.gre_vehiculo_sec_nrotarjeta_circulacion = ""
                    UTxtEnvio_NroBultos.Text = Grid1.ActiveRow.Cells("gre_envio_nro_bultos").Value
                    UTxtEnvio_PesoBruto.Text = Grid1.ActiveRow.Cells("gre_envio_peso_bruto_carga_kgs").Value
                    UTxtEnvio_Obs.Text = Grid1.ActiveRow.Cells("gre_observacion").Value.ToString().Trim
                    UTxtLlegada_Ubigeo.Text = Grid1.ActiveRow.Cells("NomUbigeo").Value.ToString().Trim
                    UTxtNroOT.Text = Grid1.ActiveRow.Cells("nroorden_trabajo").Value.ToString().Trim
                Else
                    OptGRE.Checked = False
                End If
            Else
                OptGRE.Checked = False
            End If








            If chkAprobar.Checked = True Then
                UltraGroupBox2.Enabled = False
                chkurgente.Enabled = False
                CboArea.Enabled = False
                CboEmpleo.Enabled = False
                TxtCodigoTrabajador.Enabled = False
                txtcomentario.Enabled = False
                chkAprobar.Enabled = True
                'chkAnulado.Visible = True
                userAprueba()
            Else
                UltraGroupBox2.Enabled = True
                chkurgente.Enabled = True
                CboArea.Enabled = True
                CboEmpleo.Enabled = True
                TxtCodigoTrabajador.Enabled = True
                txtcomentario.Enabled = True

            End If
            If chkAnulado.Checked = True Then
                chkAprobar.Enabled = False
                chkAnulado.Enabled = False
            End If

            Dim dtDetalle As New DataTable
            _objNegocio_ = New NGProducto
            _objEntidad_ = New ETProducto

            'hvilela - obs - 24/03/2025
            dtDetalle = _objNegocio_.ListaPedidosSuministroID(txtid.Text)

            Lista = New List(Of ETRuma)

            For i As Int32 = 0 To dtDetalle.Rows.Count - 1
                Entidad.Ruma = New ETRuma
                Entidad.Ruma.CodRuma = dtDetalle.Rows(i)("COD_PROD")
                Entidad.Ruma.Descripcion = dtDetalle.Rows(i)("PRODUCTO")
                Entidad.Ruma.Cantidad = dtDetalle.Rows(i)("CANTIDAD")
                Entidad.Ruma.Cantera = dtDetalle.Rows(i)("CANTERA")
                Entidad.Ruma.Equipo = dtDetalle.Rows(i)("EQUIPO")
                Entidad.Ruma.Trabajador = dtDetalle.Rows(i)("TRABAJADOR")
                Entidad.Ruma.StockD = dtDetalle.Rows(i)("STOCK")
                Entidad.Ruma.codAnexo3 = dtDetalle.Rows(i)("ANEXO3")
                'Entidad.Ruma.PartidaPresupuestal = dtDetalle.Rows(i)("partidapresupuestal")
                Lista.Add(Entidad.Ruma)
            Next
            CargarRumaxSuministro(Lista)
            UTabDetalle.Tabs("detalle").Selected = Boolean.TrueString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar")
        End Try
    End Sub
    Sub CargarRumaxSuministro(ByVal sender As Object)

        If sender Is Nothing Then
            Return
        End If

        'If Not sender.vCargar Then Return

        If Ls_RumaSuministro Is Nothing Then Ls_RumaSuministro = New List(Of ETRuma)
        'hvilela 3/03
        For Each W As ETRuma In Lista
            CodRuma = String.Empty : CodRuma = W.CodRuma

            'If Not Ls_RumaSuministro.Exists(AddressOf Existe_Ruma) Then Ls_RumaSuministro.Add(W)

            'Este seccion de codigo se modifica por que en el caso de Amelia 
            'requiere de ingresar varias unidades del mismo consumo como es el caso de petroleo 
            'solo se asigna para el caso de KTELLO
            'hvilela - obs - 24/03/2025
            '----------------------------------------------------
            'If User_Sistema = "AMELIAA" Then
            ' Verifica si el código ya existe en la lista
            If Ls_RumaSuministro.Exists(AddressOf Existe_Ruma) Then
                ' Pregunta al usuario si desea permitir el código repetido
                'Dim respuesta As DialogResult = MessageBox.Show("El código " & CodRuma & " ya existe. ¿Desea permitir agregarlo de todos modos?", "Código Repetido", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                ' Si el usuario elige "No", se omite este elemento y se continúa con el siguiente
                'If respuesta = DialogResult.No Then
                'Continue For
                'End If
            End If
            ' Si el código no existe o el usuario permite agregarlo, se añade a la lista
            Ls_RumaSuministro.Add(W)
            'Else
            'If Not Ls_RumaSuministro.Exists(AddressOf Existe_Ruma) Then Ls_RumaSuministro.Add(W)
            'End If
            '----------------------------------------------------

        Next

        Call CargarUltraGrid(Grid4, Ls_RumaSuministro)

    End Sub

    Private Sub Grid4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid4.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is Grid4) Then Return
            With sender
                Select Case e.KeyValue
                    'Case 45
                    '    Btn3_Click(Nothing, Nothing)
                    '    e.Handled = True
                    '    Return
                    'Case 46
                    '    If Not validarImportesAsociados() Then e.Handled = True : Return
                    'Case 8
                    '    If Not validarImportesAsociados() Then e.Handled = True : Return
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
                        .PerformAction(NextCellByTab)
                        .PerformAction(NextCellByTab)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select

            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Grid4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid4.KeyPress
        Try
            If Grid4.ActiveRow.Cells(Grid4.ActiveCell.Column.Index).Column.Key = "Equipo" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                'flgauxi = 1
                'auxi = "AC"
                Dim frm As New FrmAuxiliar
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.auxi = "AC"
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.cadena = Grid4.ActiveRow.Cells("Equipo").Value.ToString
                frm.ShowDialog()
                If codAuxiliar.Trim = "" Then e.Handled = True : Return
                'Grid4.Rows(Grid4.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
                Grid4.Rows(Grid4.ActiveRow.Index).Cells("Equipo").Value = Auxiliar
                codAuxiliar = ""
                Auxiliar = ""
                Grid4.PerformAction(NextCellByTab)
                e.Handled = True
                Exit Sub
            End If
            If Grid4.ActiveRow.Cells(Grid4.ActiveCell.Column.Index).Column.Key = "Trabajador" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                'flgauxi = 1
                'auxi = "AC"
                Dim frm As New FrmAuxiliar
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.auxi = "PL"
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.cadena = Grid4.ActiveRow.Cells("Trabajador").Value.ToString
                frm.ShowDialog()
                If codAuxiliar.Trim = "" Then e.Handled = True : Return
                'Grid4.Rows(Grid4.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
                Grid4.Rows(Grid4.ActiveRow.Index).Cells("Trabajador").Value = Auxiliar
                codAuxiliar = ""
                Auxiliar = ""
                Grid4.PerformAction(NextCellByTab)
                e.Handled = True
                Exit Sub
            End If
            'If Grid4.ActiveRow.Cells(Grid4.ActiveCell.Column.Index).Column.Key = "PartidaPresupuestal" Then
            '    If e.KeyChar.ToString.Trim = "" Then Return
            '    Dim frm As New FrmAuxiliar
            '    frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
            '    frm.auxi = "PP"
            '    frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
            '    'frm.cadena = Grid4.ActiveRow.Cells("PartidaPresupuestal").Value.ToString
            '    frm.ShowDialog()
            '    If codAuxiliar.Trim = "" Then e.Handled = True : Return
            '    'Grid4.Rows(Grid4.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
            '    Grid4.Rows(Grid4.ActiveRow.Index).Cells("PartidaPresupuestal").Value = Auxiliar
            '    codAuxiliar = ""
            '    Auxiliar = ""
            '    Grid4.PerformAction(NextCellByTab)
            '    e.Handled = True
            '    Exit Sub
            'End If
            If Grid4.ActiveRow.Cells(Grid4.ActiveCell.Column.Index).Column.Key = "Cantera" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                'flgauxi = 1
                'auxi = "AC"
                Dim frm As New FrmAuxiliar
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.auxi = "CA"
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.cadena = Grid4.ActiveRow.Cells("Cantera").Value.ToString
                frm.ShowDialog()
                If codAuxiliar.Trim = "" Then e.Handled = True : Return
                'Grid4.Rows(Grid4.ActiveRow.Index).Cells("codAuxiliar").Value = codAuxiliar
                Grid4.Rows(Grid4.ActiveRow.Index).Cells("Cantera").Value = Auxiliar
                codAuxiliar = ""
                Auxiliar = ""
                Grid4.PerformAction(NextCellByTab)
                e.Handled = True
                Exit Sub
            End If
            If Grid4.ActiveRow.Cells(Grid4.ActiveCell.Column.Index).Column.Key = "codAnexo3" Then
                Dim dtAuxi3 As New DataTable
                Entidad.Entregas = New ETEntregas
                Entidad.Entregas.codArea = CboArea.Value
                Entidad.Entregas.codConcepto = ""
                Entidad.Entregas.Anho = Year(Now.Date)
                dtAuxi3 = Negocio.NEntregas.VerAuxi3Log(Entidad.Entregas)
                'Grid4.ActiveRow.Cells("codAnexo3").Value = dtAuxi3.Rows(0)(0)
                If dtAuxi3.Rows.Count > 0 Then
                    Dim ccosto As String = dtAuxi3.Rows(0)(2)
                    Dim frm As New FrmAuxi3
                    frm.tipo = 1 'Grid4.ActiveRow.Cells("codAnexo3").Value
                    frm.codarea = ccosto.Trim
                    frm.ShowDialog()
                    If codAuxiliar.Trim = "" Then e.Handled = True : Return
                    Grid4.Rows(Grid4.ActiveRow.Index).Cells("codAnexo3").Value = codAuxiliar
                    'gridDetalle.Rows(gridDetalle.ActiveRow.Index).Cells("Descripcion").Value = Auxiliar
                End If
                e.Handled = True
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Try
            Dim cantera As String = ""
            Dim trabajador As String = ""
            Dim equipo As String = ""
            Dim anexo3 As String = ""
            If CheckBox1.Checked = True Then
                If Grid4.Rows.Count <= 0 Then
                    MessageBox.Show("No existen datos a replicar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    CheckBox1.Checked = False
                    Exit Sub
                End If
                cantera = ""
                trabajador = ""
                equipo = ""
                anexo3 = ""
                For i As Int32 = 0 To Grid4.Rows.Count - 1
                    If i = 0 Then
                        cantera = Grid4.Rows(i).Cells("Cantera").Value.ToString.Trim
                        trabajador = Grid4.Rows(i).Cells("Trabajador").Value.ToString.Trim
                        equipo = Grid4.Rows(i).Cells("Equipo").Value.ToString.Trim
                        anexo3 = Grid4.Rows(i).Cells("codAnexo3").Value.ToString.Trim
                        If cantera = "" And trabajador = "" And equipo = "" And anexo3 = "" Then
                            MessageBox.Show("No existen datos a replicar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            CheckBox1.Checked = False
                            Exit Sub
                        End If
                    Else
                        Grid4.Rows(i).Cells("Cantera").Value = cantera
                        Grid4.Rows(i).Cells("Trabajador").Value = trabajador
                        Grid4.Rows(i).Cells("Equipo").Value = equipo
                        Grid4.Rows(i).Cells("codAnexo3").Value = anexo3
                    End If
                Next
                'cantera = ""
                'trabajador = ""
                'equipo = ""
                'anexo3 = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CboArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboArea.ValueChanged
        Try
            If CboArea.Value = "44" Then
                UltraLabel6.Visible = True
                cmbmant.Visible = True
            Else
                UltraLabel6.Visible = False
                cmbmant.Visible = False
            End If

            If CboArea.Value = "35" Then
                UltraLabel8.Visible = True
                cmbAlmacen.Visible = True
                chkproduccion.Visible = True
            Else
                UltraLabel8.Visible = False
                cmbAlmacen.Visible = False
                chkproduccion.Visible = False
            End If

            'add jcms 260423 para alamcenes intermedios
            'cmbAlmacen.Visible = True

            Entidad.Usuario = New ETUsuario
            Negocio.Usuario = New NGUsuario
            Dim dtValores As New DataTable
            dtValores = Negocio.Usuario.Carga_Empleo(CboArea.Value)
            Call CargarUltraCombo(CboEmpleo, dtValores, "codigo", "descripcion")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CboEmpleo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles CboEmpleo.InitializeLayout
        With CboEmpleo.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descripcion").Width = 500 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descripcion") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    

    Private Sub UCboAlmSol_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UCboAlmSol.InitializeLayout
        With UCboAlmSol.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descrip").Width = 500 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descrip") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub



    Private Sub chkAnulado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAnulado.CheckedChanged
        If chkAnulado.Checked = True Then chkAprobar.Enabled = False
        If chkAnulado.Checked = False Then chkAprobar.Enabled = True
    End Sub

    Private Sub chkAprobar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAprobar.CheckedChanged
        If chkAprobar.Checked = True Then chkAnulado.Enabled = True
        If chkAprobar.Checked = False Then chkAnulado.Enabled = False
    End Sub

    Private Sub chkurgente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UltraGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        With e.Layout.Bands(0)
            'e.Layout.Bands(0)
            .ColHeaderLines = 3

            'IdCodEstab,denominacion,domicilio,nombre_ubigeo,Codigo_Ubigeo

            '.Columns("IdCodEstab").Header.Caption = "Cod. Establecimiento"
            '.Columns("IdCodEstab").Width = 60

            '.Columns("denominacion").Header.Caption = "Denominación Estab."
            '.Columns("denominacion").Width = 100

            '.Columns("domicilio").Header.Caption = "Domicilio"
            '.Columns("domicilio").Width = 160

            '.Columns("nombre_ubigeo").Header.Caption = "Ubigeo"
            '.Columns("nombre_ubigeo").Width = 160

            '.Columns("Codigo_Ubigeo").Header.Caption = "Cod. Ubigeo Sunat"
            '.Columns("Codigo_Ubigeo").Width = 60

            .Columns("gre_id_motivo_traslado").Hidden = True
            .Columns("gre_id_modalidad_traslado").Hidden = True
            .Columns("gre_dest_id_doc_identidad").Hidden = True
            .Columns("gre_dest_nro_doc_identidad").Hidden = True
            .Columns("gre_dest_nombre").Hidden = True

            .Columns("gre_ptollegada_direccion").Hidden = True
            .Columns("gre_ptollegada_codubigeo").Hidden = True

            .Columns("gre_ptollegada_ruc_establecimiento").Hidden = True
            .Columns("gre_ptollegada_codestablecimiento").Hidden = True

            .Columns("gre_transp_ruc").Hidden = True
            .Columns("gre_transp_nombre").Hidden = True
            .Columns("gre_chofer_id_doc_identidad").Hidden = True

            .Columns("gre_chofer_nro_doc_identidad").Hidden = True
            .Columns("gre_chofer_apellidos").Hidden = True
            .Columns("gre_chofer_nombres").Hidden = True

            .Columns("gre_chofer_nro_licencia").Hidden = True
            .Columns("gre_vehiculo_indicador_traslado_M1").Hidden = True

            .Columns("gre_vehiculo_pri_placa").Hidden = True
            .Columns("gre_vehiculo_indicador_traslado_M1").Hidden = True


            .Columns("gre_vehiculo_pri_nrotarjeta_circulacion").Hidden = True
            .Columns("gre_vehiculo_sec_placa").Hidden = True
            .Columns("gre_vehiculo_sec_nrotarjeta_circulacion").Hidden = True


            .Columns("gre_envio_nro_bultos").Hidden = True
            .Columns("gre_envio_peso_bruto_carga_kgs").Hidden = True
            .Columns("gre_observacion").Hidden = True
            .Columns("NomUbigeo").Hidden = True
            .Columns("nroorden_trabajo").Hidden = True


        End With
    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged

    End Sub

    Private Sub OptGRE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptGRE.CheckedChanged
        UTabDetalle.Tabs("gre").Selected = Boolean.TrueString
        CargaDatosMaestros_GRE()
        Habilita_Controles_CiaEstablecimiento()
    End Sub

    Private Sub OptConsumoInterno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptConsumoInterno.CheckedChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        'If UTabDetalle.Visible Then UTabDetalle.Tabs("detalle").Selected = Boolean.TrueString
        Limpiar_GRE()
        'UTabDetalle.Tabs("gre").Selected = Boolean.TrueString
    End Sub

  

    Private Sub UCboDest_TipoDocIde_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UCboDest_TipoDocIde.InitializeLayout
        With UCboDest_TipoDocIde.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descrip").Width = 500 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descrip") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub UCboChofer_DocIde_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UCboChofer_DocIde.InitializeLayout
        With UCboChofer_DocIde.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descrip").Width = 500 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descrip") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub UcboMotivoTraslado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UcboMotivoTraslado.InitializeLayout
        With UcboMotivoTraslado.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descrip").Width = 500 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descrip") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub UBtnUbigeos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UBtnUbigeos.Click
        Dim FrmUbi As New FrmUbigeos
        FrmUbi.ShowDialog()

        Dim Resultado As DialogResult
        Resultado = FrmUbi.DialogResult
        If Resultado = DialogResult.OK Then

            UTxtLlegada_Ubigeo.Value = FrmUbi.udgUbigeo.Tag
            UTxtLlegada_Ubigeo.Tag = FrmUbi.Codigo_Ubigeo_Sunat.Trim
            UTxtLlegada_CodEstab.Value = "0000"

        End If
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UBtnCiaEstb.Click
        Dim FrmCiaEstb As New FrmCiaEstablecimientos
        FrmCiaEstb.ShowDialog()

        Dim Resultado As DialogResult
        Resultado = FrmCiaEstb.DialogResult
        If Resultado = DialogResult.OK Then
            UTxtLlegada_Direccion.Value = FrmCiaEstb.udgCiaEstablecimiento.Tag.ToString()
            UTxtLlegada_CodEstab.Value = FrmCiaEstb.IdCodEstablecimiento
            UTxtLlegada_Ubigeo.Value = FrmCiaEstb.Nombre_Ubigeo_Establecimiento.Trim
            UTxtLlegada_Ubigeo.Tag = FrmCiaEstb.Codigo_Ubigeo_Establecimiento.Trim
            DesHabilita_Controles_CiaEstablecimiento()
        End If
    End Sub
    Private Sub Habilita_Controles_CiaEstablecimiento()
        UTxtLlegada_Direccion.ReadOnly = False
        UTxtLlegada_CodEstab.ReadOnly = False
        UTxtLlegada_Ubigeo.ReadOnly = False
        UTxtLlegada_RucEstablecimiento.ReadOnly = False
        UBtnUbigeos.Enabled = True
    End Sub
    Private Sub DesHabilita_Controles_CiaEstablecimiento()
        UTxtLlegada_Direccion.ReadOnly = True
        UTxtLlegada_CodEstab.ReadOnly = True
        UTxtLlegada_Ubigeo.ReadOnly = True
        UTxtLlegada_RucEstablecimiento.ReadOnly = True
        UBtnUbigeos.Enabled = False
    End Sub
    Private Sub Limpiar_GRE()

        UcboMotivoTraslado.Value = Nothing '"04"
        OptTransp_Publico.Checked = True
        UCboDest_TipoDocIde.Value = "01"
        UTxtDestino_DocIde.Text = ""
        UTxtDestino_ApeNom.Text = ""
        UTxtLlegada_Direccion.Text = ""
        UTxtLlegada_Direccion.Tag = ""
        UTxtLlegada_Ubigeo.Text = ""
        UTxtLlegada_Ubigeo.Tag = ""
        UTxtLlegada_RucEstablecimiento.Text = ""
        UTxtLlegada_CodEstab.Text = ""
        UTxtTransp_Ruc.Text = ""
        UTxtTransp_Razsoc.Text = ""
        UCboChofer_DocIde.Value = "01"
        UTxtChofer_NroDocIde.Text = ""
        UTxtChofer_Apellidos.Text = ""
        UTxtChofer_Nombres.Text = ""
        UTxtChofer_NroLicencia.Text = ""
        UChkIndicadorM1.Checked = False
        UTxtChofer_NroPlacaPri.Text = ""
        UTxtEnvio_NroBultos.Text = "0"
        UTxtEnvio_PesoBruto.Text = "0.00"
        UTxtEnvio_Obs.Text = ""
    End Sub

    Private Sub UTabDetalle_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles UTabDetalle.SelectedTabChanged
        If OptConsumoInterno.Checked = True Then
            UTabDetalle.Tabs("detalle").Selected = Boolean.TrueString
            Return
        End If
    End Sub

    Private Sub CargaDatos_xMotivo()
        UCboDest_TipoDocIde.Enabled = False
        UTxtDestino_DocIde.ReadOnly = False
        UTxtDestino_ApeNom.ReadOnly = False
        UBtnCiaEstb.Enabled = False
        UCboDest_TipoDocIde.Enabled = True
        UCboChofer_DocIde.Value = "01"
        UBtnUbigeos.Enabled = True
        Habilita_Controles_CiaEstablecimiento()


        Select Case UcboMotivoTraslado.Value
            Case "04"
                'Av. Universitaria Norte Nro. 5140 - LOS OLIVOS-LIMA-LIMA
                UCboDest_TipoDocIde.Value = "09"
                UTxtDestino_DocIde.Text = "20100037689"
                UTxtLlegada_RucEstablecimiento.Text = "20100037689"
                UTxtDestino_ApeNom.Text = "CIA. MINERA AGREGADOS CALCAREOS S.A."

                UCboDest_TipoDocIde.Enabled = False
                UTxtDestino_DocIde.ReadOnly = True
                UTxtDestino_ApeNom.ReadOnly = True

                UBtnCiaEstb.Enabled = True
                UBtnUbigeos.Enabled = False

                DesHabilita_Controles_CiaEstablecimiento()
            Case "13"
                UCboDest_TipoDocIde.Value = "09"
                UTxtDestino_DocIde.Text = ""
                UTxtLlegada_RucEstablecimiento.Text = ""
                UTxtDestino_ApeNom.Text = ""

                UCboDest_TipoDocIde.Enabled = True
                UTxtDestino_DocIde.ReadOnly = False
                UTxtDestino_ApeNom.ReadOnly = False

                UBtnCiaEstb.Enabled = True
                UBtnUbigeos.Enabled = False

                Habilita_Controles_CiaEstablecimiento()
                UTxtDestino_DocIde.Focus()
        End Select

    End Sub

    Private Sub UcboMotivoTraslado_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcboMotivoTraslado.ValueChanged

        CargaDatos_xMotivo()


    End Sub


    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If CboArea.Value Is Nothing Then MsgBox("Debe seleccionar área", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
        If UCboAlmSol.Value Is Nothing Then MsgBox("Elija almacen solicitante.", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
        If sender Is Btn7 Then
            'Grid1.PerformAction(ExitEditMode)

            StrucForm.FxListaSuministro = New frmListaSuministro
            StrucForm.FxListaSuministro.ls_IdAlmacenSolicitante = UCboAlmSol.Value
            AddHandler StrucForm.FxListaSuministro.Closing, AddressOf Cargar_RumaxSuministro
            StrucForm.FxListaSuministro.MdiParent = MdiParent
            StrucForm.FxListaSuministro.L = Boolean.TrueString
            StrucForm.FxListaSuministro.Show()
            StrucForm.FxListaSuministro = Nothing
            UCboAlmSol.Enabled = False
            Return
        End If
    End Sub

    
    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        If sender Is Btn8 Then

            If Not VerificarControl(5, Grid4) Then
                MessageBox.Show("No tiene producto para quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If Grid4.ActiveRow Is Nothing Then
                MessageBox.Show("No tiene un producto seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            Grid4.ActiveRow.Delete()
        End If
    End Sub
    Private Function ValidarGRE() As Boolean
        UTabDetalle.Tabs("gre").Selected = Boolean.TrueString
        If UcboMotivoTraslado.Value = "" Then
            MessageBox.Show("Elija motivo de traslado de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            UcboMotivoTraslado.Focus()
            ValidarGRE = False
            Exit Function
        ElseIf OptTransp_Publico.Checked = False And OptTransp_Privado.Checked = False Then
            MessageBox.Show("Elija modalidad de transporte de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'UcboMotivoTraslado.Focus()
            ValidarGRE = False
            Exit Function
        ElseIf UCboDest_TipoDocIde.Value = "" Then
            MessageBox.Show("Elija tipo de documento del destinatario de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            UCboDest_TipoDocIde.Focus()
            ValidarGRE = False
            Exit Function
        ElseIf UCboDest_TipoDocIde.Value = "01" And (UTxtDestino_DocIde.Text.Trim = "" Or UTxtDestino_DocIde.Text.Trim.Length <> 8) Then
            MessageBox.Show("Ingrese número de documento del destinatario correctamente", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            UTxtDestino_DocIde.Focus()
            ValidarGRE = False
            Exit Function
        ElseIf UCboDest_TipoDocIde.Value = "09" And (UTxtDestino_DocIde.Text.Trim = "" Or UTxtDestino_DocIde.Text.Trim.Length <> 11) Then
            MessageBox.Show("Ingrese número de RUC del destinatario correctamente", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            UTxtDestino_DocIde.Focus()
            ValidarGRE = False
            Exit Function

        ElseIf UTxtDestino_ApeNom.Text.Trim = "" Then
            MessageBox.Show("Ingrese Apellidos y nombres o Razón social del destinatario de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            UTxtDestino_ApeNom.Focus()
            ValidarGRE = False
            Exit Function

        ElseIf UTxtLlegada_Direccion.Text.Trim = "" Then
            MessageBox.Show("Ingrese dirección del Pto. de llegada de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            UTxtLlegada_Direccion.Focus()
            ValidarGRE = False
            Exit Function
        ElseIf UTxtLlegada_Ubigeo.Text.Trim = "" Or UTxtLlegada_Ubigeo.Tag.trim = "" Or UTxtLlegada_Ubigeo.Tag.ToString.Trim.Length <> 6 Then
            MessageBox.Show("Ingrese ubigeo del Pto. de llegada de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            UTxtLlegada_Ubigeo.Focus()
            ValidarGRE = False
            Exit Function
        ElseIf UTxtLlegada_RucEstablecimiento.Text.Trim = "" Or UTxtLlegada_RucEstablecimiento.Text.Trim.Length <> 11 Then
            MessageBox.Show("Ingrese Ruc del establecimiento del Pto. de llegada de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            UTxtLlegada_RucEstablecimiento.Focus()
            ValidarGRE = False
            Exit Function
        ElseIf UTxtLlegada_CodEstab.Text.Trim = "" Or UTxtLlegada_CodEstab.Text.Trim.Length <> 4 Then
            MessageBox.Show("Ingrese Cod. del establecimiento del Pto. de llegada de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            UTxtLlegada_CodEstab.Focus()
            ValidarGRE = False
            Exit Function

        End If


        If UcboMotivoTraslado.Value = "04" Or UcboMotivoTraslado.Value = "13" Then 'entre establecimientos , otros
            If OptTransp_Privado.Checked = True Then



                If UTxtTransp_Ruc.Text.Trim <> "" Then
                    MessageBox.Show("NO debe indicar Ruc del transportista.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    UTxtTransp_Ruc.Focus()
                    ValidarGRE = False
                    Exit Function
                ElseIf UTxtTransp_Razsoc.Text.Trim <> "" Then
                    MessageBox.Show("NO debe indicar  Apellidos  y nombres o Razón social del transportista de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    UTxtTransp_Razsoc.Focus()
                    ValidarGRE = False
                    Exit Function
                End If


                If UChkIndicadorM1.Checked = False Then

                    If UCboChofer_DocIde.Value = "" Then
                        MessageBox.Show("Ingrese número de documento del chofer.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UCboChofer_DocIde.Focus()
                        ValidarGRE = False
                        Exit Function
                    ElseIf UCboChofer_DocIde.Value = "01" And (UTxtChofer_NroDocIde.Text.Trim = "" Or UTxtChofer_NroDocIde.Text.Trim.Length <> 8) Then
                        MessageBox.Show("Ingrese número de documento DNI del chofer.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_NroDocIde.Focus()
                        ValidarGRE = False
                        Exit Function
                    ElseIf UCboChofer_DocIde.Value = "09" And (UTxtChofer_NroDocIde.Text.Trim = "" Or UTxtChofer_NroDocIde.Text.Trim.Length <> 11) Then
                        MessageBox.Show("Ingrese número de documento RUC.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_NroDocIde.Focus()
                        ValidarGRE = False
                        Exit Function
                    ElseIf UTxtChofer_Apellidos.Text.Trim = "" Then
                        MessageBox.Show("Ingrese Apellidos del chofer.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_Apellidos.Focus()
                        ValidarGRE = False
                        Exit Function
                    ElseIf UTxtChofer_Nombres.Text.Trim = "" Then
                        MessageBox.Show("Ingrese Nombres del chofer.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_Nombres.Focus()
                        ValidarGRE = False
                        Exit Function
                    ElseIf UTxtChofer_NroLicencia.Text.Trim = "" Or UTxtChofer_NroLicencia.Text.Trim.Length < 9 Then
                        MessageBox.Show("Ingrese Nro. de licencia del chofer.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_NroLicencia.Focus()
                        ValidarGRE = False
                        Exit Function
                    ElseIf UCboDest_TipoDocIde.Value = "01" And UTxtChofer_NroLicencia.Text.Trim.Substring(1, 8) <> UTxtChofer_NroDocIde.Text.Trim And UTxtChofer_NroDocIde.Text.Trim.Length = 8 Then
                        MessageBox.Show("Ingrese correctamente Nro. de licencia del chofer.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_NroLicencia.Focus()
                        ValidarGRE = False
                        Exit Function
                    ElseIf UTxtChofer_NroPlacaPri.Text.Trim = "" Or UTxtChofer_NroPlacaPri.Text.Trim.Length < 6 Then
                        MessageBox.Show("Ingrese Nro. de Placa principal del vehículo correctamente. (6 a 8 caracteres)", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_NroPlacaPri.Focus()
                        ValidarGRE = False
                        Exit Function
                    End If

                End If


                If UChkIndicadorM1.Checked = True Then
                    If UTxtChofer_NroPlacaPri.Text.Trim = "" Then
                        MessageBox.Show("Ingrese Nro. de Placa principal del vehículo.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_NroPlacaPri.Focus()
                        ValidarGRE = False
                        Exit Function
                    End If
                End If

            End If



            If OptTransp_Publico.Checked = True Then

                If UChkIndicadorM1.Checked = False Then

                    If UTxtTransp_Ruc.Text.Trim = "" Or UTxtTransp_Ruc.Text.Trim.Length <> 11 Then
                        MessageBox.Show("Ingrese Ruc del transportista correctamente. (11 Digitos)", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtTransp_Ruc.Focus()
                        ValidarGRE = False
                        Exit Function
                    ElseIf (UCboDest_TipoDocIde.Value = "09") And (UTxtTransp_Ruc.Text.Trim = UTxtDestino_DocIde.Text.Trim) Then
                        MessageBox.Show("El Ruc del destinatario y transportista deben ser distintos.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtTransp_Ruc.Focus()
                        ValidarGRE = False
                        Exit Function
                    ElseIf UTxtTransp_Razsoc.Text.Trim = "" Then
                        MessageBox.Show("Ingrese Apellidos  y nombres o Razón social del transportista de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtTransp_Razsoc.Focus()
                        ValidarGRE = False
                        Exit Function
                    End If
                End If

                If UTxtChofer_NroDocIde.Text.Trim <> "" Then

                    If UTxtChofer_Apellidos.Text.Trim = "" Then
                        MessageBox.Show("Ingrese Apellidos del chofer.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_Apellidos.Focus()
                        ValidarGRE = False
                        Exit Function
                    ElseIf UTxtChofer_Nombres.Text.Trim = "" Then
                        MessageBox.Show("Ingrese Nombres del chofer.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_Nombres.Focus()
                        ValidarGRE = False
                        Exit Function
                    ElseIf UTxtChofer_NroLicencia.Text.Trim = "" Or UTxtChofer_NroLicencia.Text.Trim.Length < 9 Then
                        MessageBox.Show("Ingrese Nro. de licencia del chofer correctamente.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_NroLicencia.Focus()
                        ValidarGRE = False
                        Exit Function

                    ElseIf UCboChofer_DocIde.Value = "01" And UTxtChofer_NroLicencia.Text.Trim.Substring(1, 8) <> UTxtChofer_NroDocIde.Text.Trim And UTxtChofer_NroDocIde.Text.Trim.Length = 8 Then
                        MessageBox.Show("Ingrese correctamente Nro. de licencia del chofer correctamente.", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_NroLicencia.Focus()
                        ValidarGRE = False
                        Exit Function

                    ElseIf UTxtChofer_NroPlacaPri.Text.Trim = "" Or UTxtChofer_NroPlacaPri.Text.Trim.Length < 6 Then
                        MessageBox.Show("Ingrese Nro. de Placa principal del vehículo correctamente. (6 a 8 caracteres)", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_NroPlacaPri.Focus()
                        ValidarGRE = False
                        Exit Function
                    End If
                End If


                If UChkIndicadorM1.Checked = True Then
                    If UTxtChofer_NroPlacaPri.Text.Trim = "" Then
                        MessageBox.Show("Ingrese Nro. de Placa principal del vehículo de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        UTxtChofer_NroPlacaPri.Focus()
                        ValidarGRE = False
                        Exit Function
                    End If
                End If

            End If


            If Convert.ToDecimal(UTxtEnvio_NroBultos.Text) = 0 Then
                MessageBox.Show("Ingrese Nro. de Bultos a enviar de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                UTxtEnvio_NroBultos.Focus()
                ValidarGRE = False
                Exit Function
            ElseIf Convert.ToDecimal(UTxtEnvio_PesoBruto.Text) = 0 Then
                MessageBox.Show("Ingrese el Peso Bruto en Kilogramos a enviar de la Guía Electrónica", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                UTxtEnvio_PesoBruto.Focus()
                ValidarGRE = False
                Exit Function
            End If


        End If









        UTabDetalle.Tabs("detalle").Selected = Boolean.TrueString



        'UChkIndicadorM1.Checked = False
        'UTxtChofer_NroPlacaPri.Text = ""
        'UTxtEnvio_NroBultos.Text = "0"
        'UTxtEnvio_PesoBruto.Text = "0.00"
        'UTxtEnvio_Obs.Text = ""

        ValidarGRE = True
    End Function
    Function ObtenerNombreProveedor(ByVal xObj As ETProveedor) As String
        Dim oDat As New NGProveedor
        ObtenerNombreProveedor = oDat.ConsultarProveedor(xObj).Trim
        oDat = Nothing
    End Function

    Private Sub UTxtTransp_Ruc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)


    End Sub

    Private Sub UTxtTransp_Ruc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UTxtTransp_Ruc.KeyPress
        If UChkIndicadorM1.Checked Then
            e.Handled = True
        End If

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub UTxtTransp_Ruc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UTxtTransp_Ruc.ValueChanged
        If UTxtTransp_Ruc.Text.Trim.Length = 11 Then
            Dim oDat As New ETProveedor
            oDat.CodCiaProveedor = "01"
            oDat.RucProveedor = UTxtTransp_Ruc.Text.Trim
            UTxtTransp_Razsoc.Text = Negocio.Proveedor.ConsultarProveedor(oDat).Trim
            oDat = Nothing
        Else
            UTxtTransp_Razsoc.Text = ""
        End If


    End Sub

    Private Sub UTxtDestino_DocIde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UTxtDestino_DocIde.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And UTxtDestino_DocIde.Text.Trim <> "" Then
            UTxtDestino_ApeNom.Focus()
        End If


        If UTxtDestino_DocIde.Value = "01" Or UTxtDestino_DocIde.Value = "09" Then
            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub UTxtDestino_DocIde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UTxtDestino_DocIde.ValueChanged
        If UCboDest_TipoDocIde.Value = "09" Then
            If UTxtDestino_DocIde.Text.Trim.Length = 11 Then
                Dim oDat As New ETProveedor
                oDat.CodCiaProveedor = "01"
                oDat.RucProveedor = UTxtDestino_DocIde.Text.Trim
                UTxtDestino_ApeNom.Text = Negocio.Proveedor.ConsultarProveedor(oDat).Trim
                oDat = Nothing
                'Else
                '    UTxtDestino_DocIde.Text = ""
            End If
        End If
    End Sub

    Private Sub Limpiar_M1L1()
        UTxtTransp_Ruc.Text = ""
        UTxtTransp_Razsoc.Text = ""
        UCboChofer_DocIde.Value = "01"
        UTxtChofer_NroDocIde.Text = ""
        UTxtChofer_Apellidos.Text = ""
        UTxtChofer_Nombres.Text = ""
        UTxtChofer_NroLicencia.Text = ""                      
    End Sub



    Private Sub UChkIndicadorM1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Limpiar_M1L1()
    End Sub

    Private Sub UTxtEnvio_PesoBruto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UTxtEnvio_PesoBruto.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." Then
            e.Handled = False

        Else
            e.Handled = True
        End If
        If e.KeyChar = ChrW(Keys.Enter) And UTxtEnvio_PesoBruto.Text.Trim <> "" Then
            UTxtEnvio_Obs.Focus()
        End If
    End Sub

    Private Sub UTxtEnvio_PesoBruto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UTxtEnvio_PesoBruto.LostFocus
        If UTxtEnvio_PesoBruto.Text.Trim = "" Then
            UTxtEnvio_PesoBruto.Text = "0"
        End If
    End Sub

    Private Sub UTxtEnvio_NroBultos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UTxtEnvio_NroBultos.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If e.KeyChar = ChrW(Keys.Enter) And UTxtEnvio_NroBultos.Text.Trim <> "" Then
            UTxtEnvio_PesoBruto.Focus()
        End If
    End Sub



    Private Sub UTxtEnvio_NroBultos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UTxtEnvio_NroBultos.LostFocus
        If UTxtEnvio_NroBultos.Text.Trim = "" Then
            UTxtEnvio_NroBultos.Text = "0"
        End If
    End Sub

   

    Private Sub UTxtEnvio_NroBultos_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UTxtEnvio_NroBultos.ValueChanged
        If UTxtEnvio_NroBultos.Text.Trim = "" Then
            UTxtEnvio_NroBultos.Text = "0"
        End If
    End Sub

    Private Sub UTxtEnvio_PesoBruto_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UTxtEnvio_PesoBruto.ValueChanged
        If UTxtEnvio_PesoBruto.Text.Trim = "" Then
            UTxtEnvio_PesoBruto.Text = "0"
        End If



    End Sub

    Private Sub UTxtTransp_Razsoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UTxtTransp_Razsoc.KeyPress
        If UChkIndicadorM1.Checked Then
            e.Handled = True
        End If
    End Sub

    Private Sub UTxtTransp_Razsoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UTxtChofer_NroDocIde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UTxtChofer_NroDocIde.KeyPress
        If UChkIndicadorM1.Checked Then
            e.Handled = True
        End If
        If UTxtChofer_NroDocIde.Value = "01" Or UTxtChofer_NroDocIde.Value = "09" Then
            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If

        If e.KeyChar = ChrW(Keys.Enter) And UTxtChofer_NroDocIde.Text.Trim <> "" Then
            UTxtChofer_Apellidos.Focus()
        End If
    End Sub

    Private Sub UTxtChofer_NroDocIde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UTxtChofer_Apellidos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UTxtChofer_Apellidos.KeyPress
        If UChkIndicadorM1.Checked Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(Keys.Enter) And UTxtChofer_Apellidos.Text.Trim <> "" Then
            UTxtChofer_Nombres.Focus()
        End If

    End Sub

    Private Sub UTxtChofer_Apellidos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UTxtChofer_Nombres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UTxtChofer_Nombres.KeyPress
        If UChkIndicadorM1.Checked Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(Keys.Enter) And UTxtChofer_Nombres.Text.Trim <> "" Then
            UTxtChofer_NroLicencia.Focus()
        End If
    End Sub

    Private Sub UTxtChofer_Nombres_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UTxtChofer_NroLicencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UTxtChofer_NroLicencia.KeyPress
        If UChkIndicadorM1.Checked Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(Keys.Enter) And UTxtChofer_NroLicencia.Text.Trim <> "" Then
            UTxtChofer_NroPlacaPri.Focus()
        End If
    End Sub

    Private Sub UTxtLlegada_Ubigeo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UTxtLlegada_Ubigeo.KeyPress
        If UcboMotivoTraslado.Value = "13" Then
            e.Handled = True
        End If
    End Sub

    
  
    
   
    Private Sub UTxtLlegada_Ubigeo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UTxtLlegada_Ubigeo.ValueChanged
       
    End Sub

    Private Sub Navigator4_RefreshItems(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Navigator4.RefreshItems

    End Sub

    Private Sub UltraGroupBox1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGroupBox1.Click

    End Sub
End Class