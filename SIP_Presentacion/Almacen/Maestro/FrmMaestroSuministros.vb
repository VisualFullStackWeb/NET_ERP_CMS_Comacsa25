Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmMaestroSuministros

    '   *****   VARIABLES *****
    Dim Codigo As String
    Dim Codigo1 As String

    Dim dtCODUNIDCPA As New DataTable
    Dim xValidar As String = "1"

    Public CodigoProducto As String = ""
    Public DescripcionProducto As String = ""
    Public UMProducto As String = ""

    Public Ls_Permisos As New List(Of Integer)

#Region "Funciones Locales"

#Region "Listar Unidad de Despacho"
    Private Sub ListarUM()
        Negocio.Maestros2 = New NGMaestros2
        CmbUnidadDespacho.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LUD", "", Now.ToShortDateString, Now)
        CmbUnidadDespacho.DisplayMember = "Descripcion"
        CmbUnidadDespacho.ValueMember = "UM"
        CmbUnidadDespacho.SelectedIndex = -1
    End Sub
#End Region

#Region "Listar Tipo de Productos"
    Private Sub ListarTipoProductos()
        Negocio.Maestros2 = New NGMaestros2
        CmbTipoProducto.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LTP", "", Now.ToShortDateString, Now)
        CmbTipoProducto.DisplayMember = "Descripcion"
        CmbTipoProducto.ValueMember = "Codigo"
        CmbTipoProducto.SelectedIndex = -1
    End Sub
#End Region

#Region "Listar Mes"
    Private Sub ListarMes()
        Negocio.Maestros2 = New NGMaestros2
        CmbStockSeguridad.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LME", "", Now.ToShortDateString, Now)
        CmbStockSeguridad.DisplayMember = "Descripcion"
        CmbStockSeguridad.ValueMember = "Codigo"
        CmbStockSeguridad.SelectedIndex = 0

        Negocio.Maestros2 = New NGMaestros2
        CmbTiempoEspera.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LME", "", Now.ToShortDateString, Now)
        CmbTiempoEspera.DisplayMember = "Descripcion"
        CmbTiempoEspera.ValueMember = "Codigo"
        CmbTiempoEspera.SelectedIndex = 0

    End Sub
#End Region

#Region "Listar Linea de Productos"
    Private Sub ListarLineaProductos()
        Negocio.Maestros2 = New NGMaestros2

        CmbLinea.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LLI", "", Now.ToShortDateString, Now)
        CmbLinea.DisplayMember = "Linea"
        CmbLinea.ValueMember = "Codigo"
        CmbLinea.SelectedIndex = -1
    End Sub
#End Region

#Region "Listar Sub-Linea de Productos"
    Private Sub ListarSubLineaProductos(ByVal Linea As String)
        Negocio.Maestros2 = New NGMaestros2
        CmbSubLinea.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, Linea, "", "", "LSL", "", Now.ToShortDateString, Now)
        CmbSubLinea.DisplayMember = "SubLinea"
        CmbSubLinea.ValueMember = "Codigo"
        CmbSubLinea.SelectedIndex = -1
    End Sub
#End Region

#Region "Listar Caracteristicas"
    Private Sub ListarCaracteristica(ByVal Linea As String, ByVal SubLinea As String)
        Negocio.Maestros2 = New NGMaestros2
        CmbCaracteristicas.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, Linea, SubLinea, "", "LCA", "", Now.ToShortDateString, Now)
        CmbCaracteristicas.DisplayMember = "Caracteristica"
        CmbCaracteristicas.ValueMember = "Codigo"
        CmbCaracteristicas.SelectedIndex = -1
    End Sub
#End Region

#Region "Listar Nombre de Productos"
    Private Sub ListarNombreProductos()
        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        With Entidad.Producto
            .Cod_Cia = Companhia
        End With

        CmbNombreComercial.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "LNO")
        CmbNombreComercial.DisplayMember = "Descripcion"
        CmbNombreComercial.ValueMember = "Codigo"
        CmbNombreComercial.SelectedIndex = -1

    End Sub
#End Region

#Region "Listar Descripcion Tecnica de Productos GENERAL"
    Private Sub ListarDescripcionTecnicaProductos()
        With Entidad.Producto
            .Cod_Cia = Companhia
        End With

        CmbNombreTecnico.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "LDT")
        CmbNombreTecnico.DisplayMember = "Descripcion"
        CmbNombreTecnico.ValueMember = "Codigo"
        CmbNombreTecnico.SelectedIndex = -1

    End Sub
#End Region

#Region "Listar Descripcion Tecnica x Productos"
    Private Sub ListarDescripcionTecnica()
        Dim DtDescTec As New DataTable
        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodProducto = Trim(TxtCodigo.Text & "")
        End With
        DtDescTec = Negocio.Producto.ListarProductos(Entidad.Producto, "DTP")

        If DtDescTec.Rows.Count > 0 Then
            CmbNombreTecnico.DisplayMember = DtDescTec.Rows(0).Item(0)
            CmbNombreTecnico.ValueMember = DtDescTec.Rows(0).Item(0)
            CmbNombreTecnico.Text = Trim(DtDescTec.Rows(0).Item(0))
        Else
            CmbNombreTecnico.SelectedIndex = -1
        End If
    End Sub
#End Region

#Region "Listar Productos Maestro"
    Private Sub ListarProductoMaestro()
        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodAlmacen = Trim(CboAlmacen.Value & "")
        End With
        DgvListarMaestroProductos.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "LMA")
    End Sub
#End Region

#Region "Listar Clasificacion Contable"
    Private Sub ListarClasificacionContable()
        Negocio.Maestros2 = New NGMaestros2
        CmbClasificacionContable.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LCT", "", Now.ToShortDateString, Now)
        CmbClasificacionContable.DisplayMember = "Descripcion"
        CmbClasificacionContable.ValueMember = "Codigo"
        CmbClasificacionContable.SelectedIndex = -1

    End Sub
#End Region

#Region "Validar"
    Private Function Validar() As Boolean
        Dim dtValidar As New DataTable

        If TabMaestroSumunistros.Tabs("Consulta").Selected = True Then
            Return False
        End If

        If TxtCodigo.Text <> "" And CmbNombreComercial.Text = "" Then
            MsgBox("Ingrese Nombre Comercial de Suministro.", MsgBoxStyle.Critical, "Comacsa")
            CmbNombreComercial.Focus()
            Return False
        End If

        If Len(Trim(CmbNombreComercial.Text)) > 120 Then
            MsgBox("La longitud máxima del nombre es 100 caracteres.", MsgBoxStyle.Critical, "Comacsa")
            CmbNombreComercial.Focus()
            Return False
        End If

        If Trim(CmbNombreTecnico.Text) <> "" And Len(Trim(CmbNombreTecnico.Text)) > 120 Then
            MsgBox("La longitud máxima del nombre técnico es 100 caracteres.", MsgBoxStyle.Critical, "Comacsa")
            CmbNombreTecnico.Focus()
            Return False
        End If

        If CmbUnidadDespacho.Text = "" Then
            MsgBox("Ingrese Unidad de medida.", MsgBoxStyle.Critical, "Comacsa")
            CmbUnidadDespacho.Focus()
            Return False
        End If

        If CmbTipoProducto.Text = "" Then
            MsgBox("Elija tipo de producto.", MsgBoxStyle.Critical, "Comacsa")
            CmbTipoProducto.Focus()
            Return False
        End If

        If TiempoStockNumero.Value > 0 And CmbStockSeguridad.Text = "" Then
            MsgBox("Elija el tiempo de duración del STOCK DE SEGURIDAD.", MsgBoxStyle.Critical, "Comacsa")
            CmbStockSeguridad.Focus()
            Return False
        End If

        If TiempoEsperaNumero.Value > 0 And CmbTiempoEspera.Text = "" Then
            MsgBox("Elija el tiempo de duración del TIEMPO DE ESPERA DE LA IMPORTACION.", MsgBoxStyle.Critical, "Comacsa")
            CmbStockSeguridad.Focus()
            CmbTiempoEspera.Focus()
            Return False
        End If

        If CmbLinea.Text = "" Then
            MsgBox("Elija Linea de producto.", MsgBoxStyle.Critical, "Comacsa")
            CmbLinea.Focus()
            Return False
        End If

        If Companhia = "03" And CmbClasificacionContable.Items.Count > 0 And CmbClasificacionContable.Text = "" Then
            MsgBox("Elija Clasificación Contable.", MsgBoxStyle.Critical, "Comacsa")
            CmbClasificacionContable.Focus()
            Return False
        End If

        If RbAnulado.Checked = True Then
            With Entidad.Producto
                .Cod_Cia = Companhia
                .CodProducto = Trim(TxtCodigo.Text & "")
            End With
            dtValidar = Negocio.Producto.ProductoValidar(Entidad.Producto, "LRA")

            If dtValidar.Rows.Count > 0 Then
                MsgBox("El código no podrá ser ANULADO,porque forma parte de un REQUERIMIENTO." & Chr(13) & "Utilice la opción INACTIVO,si desea que no este disponible para los usuarios.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If

            With Entidad.Producto
                .Cod_Cia = Companhia
                .CodProducto = Trim(TxtCodigo.Text & "")
            End With
            dtValidar = Negocio.Producto.ProductoValidar(Entidad.Producto, "LRO")

            If dtValidar.Rows.Count > 0 Then
                MsgBox("El código no podrá ser ANULADO,porque forma parte de una BILLETE DE ALMACEN." & Chr(13) & "Utilice la opción INACTIVO,si desea que no este disponible para los usuarios.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If

            With Entidad.Producto
                .Cod_Cia = Companhia
                .CodProducto = Trim(TxtCodigo.Text & "")
            End With
            dtValidar = Negocio.Producto.ProductoValidar(Entidad.Producto, "LRE")

            If dtValidar.Rows.Count > 0 Then
                MsgBox("El código no podrá ser ANULADO,porque forma parte de una COTIZACION" & Chr(13) & "Utilice la opción INACTIVO,si desea que no este disponible para los usuarios.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If

            With Entidad.Producto
                .Cod_Cia = Companhia
                .CodProducto = Trim(TxtCodigo.Text & "")
            End With
            dtValidar = Negocio.Producto.ProductoValidar(Entidad.Producto, "LRI")
            If dtValidar.Rows.Count > 0 Then
                MsgBox("El código no podrá ser ANULADO,porque forma parte de una COTIZACION" & Chr(13) & "Utilice la opción INACTIVO,si desea que no este disponible para los usuarios.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If
        End If


        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodProducto = TxtCodigo.Text
            .Descripcion = CmbNombreComercial.Text
            .TipoProducto = CmbTipoProducto.Value
        End With

        If TxtCodigo.Text = "" Then
            dtValidar = Negocio.Producto.ProductoValidar(Entidad.Producto, "LRU")
            If dtValidar.Rows.Count > 0 Then
                MsgBox("La Descripción del Producto ya Existe.", MsgBoxStyle.Critical, "Comacsa")
                CmbNombreComercial.Focus()
                Return False
            End If
        Else
            dtValidar = Negocio.Producto.ProductoValidar(Entidad.Producto, "LRX")
            If dtValidar.Rows.Count > 1 Then
                MsgBox("La Descripción del Producto ya Existe.", MsgBoxStyle.Critical, "Comacsa")
                CmbNombreComercial.Focus()
                Return False
            End If
        End If

        xValidar = "0"
        Return True


    End Function

#End Region

#Region "Actualizar Unidad Despacho"
    Private Sub ActualizarUnidadDespacho()
        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodProducto = TxtCodigo.Text
            .UnidadDesp = CmbUnidadDespacho.Value
            .Unidad = DgvListarMaestroProductos.ActiveRow.Cells("UM").Value
        End With
        Entidad.Resultado = Negocio.Producto.Update_Producto_UD(Entidad.Producto)
    End Sub
#End Region

#End Region   '   Funciones Locales

#Region "Funciones Globales"

#Region "Nuevo"
    Public Sub Nuevo()
        TabMaestroSumunistros.Tabs("Registro").Selected = True

        TxtCodigo.Clear()
        TxtUbicacionAlmacen.Clear()

        CmbNombreComercial.Clear()
        CmbNombreComercial.SelectedIndex = -1

        CmbNombreTecnico.Clear()
        CmbNombreTecnico.SelectedIndex = -1
        CmbUnidadDespacho.SelectedIndex = -1
        CmbTipoProducto.Value = "01"
        CmbClasificacionContable.SelectedIndex = -1
        CmbLinea.SelectedIndex = -1
        CmbSubLinea.SelectedIndex = -1
        CmbCaracteristicas.SelectedIndex = -1
        CmbTiempoEspera.SelectedIndex = 0
        CmbStockSeguridad.SelectedIndex = 0

        TxtStock.Value = 0
        TiempoEsperaNumero.Value = 0
        TiempoStockNumero.Value = 0

        ChkCompraVolumen.Checked = False
        ChkConsumoFrecuente.Checked = False
        ChkControlDUA.Checked = False
        ChkNumeracionBolsas.Checked = False
        ChkSuministroCritico.Checked = False

        RbActivo.Checked = True
        RbAnulado.Enabled = False
        RbInactivo.Enabled = False

        RbNacional.Checked = True

    End Sub

#End Region

#Region "Grabar"

    Public Sub Grabar()
        If Validar() = False Then Return

        If MsgBox("¿Esta Seguro de GRABAR el Producto ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            TxtCodigo.Focus()
            With Entidad.Producto
                .CodProducto = Trim(TxtCodigo.Text & "")
                .CodUnidCpa = CmbUnidadDespacho.Value
                .Cod_Cia = Companhia
                .Descripcion = Trim(CmbNombreComercial.Text & "")
                .DesTecnica = Trim(CmbNombreTecnico.Text & "")
                .UbiAlm = Trim(TxtUbicacionAlmacen.Text & "")
                .CodLinea = Trim(CmbLinea.Value & "")
                .CodNat = Trim(CmbSubLinea.Value & "")
                .CodCaract = Trim(CmbCaracteristicas.Value & "")
                .UnidadDesp = CmbUnidadDespacho.Value
                .TipoProducto = CmbTipoProducto.Value
                .Cod_Tiempo_Importacion = CmbTiempoEspera.Value
                .Cod_Tiempo_Stock_Seguridad = CmbStockSeguridad.Value
                .Cod_ClasConta = Trim(CmbClasificacionContable.Value & "")
                .User_Crea = User_Sistema
                .Tiempo_Importacion = TiempoEsperaNumero.Value
                .Tiempo_Stock_Seguridad = TiempoStockNumero.Value
                .StkMin = TxtStock.Value

                If ChkSuministroCritico.Checked = True Then
                    .Sumi_Critico = "1"
                Else
                    .Sumi_Critico = "0"
                End If

                If ChkControlDUA.Checked = True Then
                    .Control_Dua = "1"
                Else
                    .Control_Dua = "0"
                End If

                If ChkConsumoFrecuente.Checked = True Then
                    .Sumi_Consu = "1"
                Else
                    .Sumi_Consu = "0"
                End If

                If ChkNumeracionBolsas.Checked = True Then
                    .Control_Num = "1"
                Else
                    .Control_Num = "0"
                End If

                If ChkCompraVolumen.Checked = True Then
                    .CpaxVol = "1"
                Else
                    .CpaxVol = "0"
                End If

                If RbNacional.Checked = True Then
                    .OpcProd = "N"
                Else
                    .OpcProd = "E"
                End If

                If RbActivo.Checked = True Then
                    .Status = ""
                ElseIf RbInactivo.Checked = True Then
                    .Status = "I"
                Else
                    .Status = "*"
                End If
            End With

            If TxtCodigo.Text = "" Then
                Entidad.Resultado = Negocio.Producto.AgregarProducto(Entidad.Producto, "AGR")
                If Entidad.Resultado.Realizo = True Then
                    MsgBox("Se guardó correctamento los datos.", MsgBoxStyle.Information, "Comacsa")
                    TabMaestroSumunistros.Tabs("Consulta").Selected = True
                    CodigoProducto = Entidad.Resultado.Mensaje
                End If
            Else
                Entidad.Resultado = Negocio.Producto.AgregarProducto(Entidad.Producto, "MOD")
                If Entidad.Resultado.Realizo = True Then
                    MsgBox("Se modificó correctamento los datos.", MsgBoxStyle.Information, "Comacsa")
                    CodigoProducto = Entidad.Resultado.Mensaje
                    Call ActualizarUnidadDespacho()
                    TabMaestroSumunistros.Tabs("Consulta").Selected = True
                End If
            End If

            UMProducto = CmbUnidadDespacho.Value
            DescripcionProducto = CmbNombreComercial.Text
            Call Nuevo()
            Call ListarProductoMaestro()
        End If
    End Sub
#End Region

#End Region         '   Funciones Publicas

#Region "Eventos Botones"

#Region "CmbAlmacen - ValueChanged"
    Private Sub CboAlmacen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAlmacen.ValueChanged

        Call ListarProductoMaestro()
    End Sub
#End Region

#Region "CmbLinea - ValueChanged"
    Private Sub CmbLinea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbLinea.ValueChanged
        Call ListarSubLineaProductos(CmbLinea.Value)
    End Sub
#End Region

#Region "DgvListarMaestroProductos - DoubleClickRow"

    Private Sub DgvListarMaestroProductos_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvListarMaestroProductos.DoubleClickRow
        If DgvListarMaestroProductos.Rows.Count > 0 Then
            TabMaestroSumunistros.Tabs("Registro").Selected = True
            TxtCodigo.Text = e.Row.Cells("Codigo").Value
            CmbNombreComercial.Value = e.Row.Cells("Codigo").Value
            ' Call ListarDescripcionTecnica()
            CmbNombreTecnico.Text = e.Row.Cells("DesTecnica").Value
            CmbUnidadDespacho.Value = e.Row.Cells("UM").Value
            Call ListarLineaProductos()
            CmbLinea.Text = e.Row.Cells("Linea").Value
            CmbSubLinea.Text = e.Row.Cells("SubLinea").Value
            If e.Row.Cells("Status").Value = "ACTIVO" Then
                RbActivo.Checked = True
            ElseIf e.Row.Cells("Status").Value = "INACTIVO" Then
                RbInactivo.Checked = True
            Else
                RbAnulado.Checked = True
            End If

            Dim dtProducto As New DataTable
            With Entidad.Producto
                .Cod_Cia = Companhia
                .CodProducto = Trim(TxtCodigo.Text & "")
            End With
            dtProducto = Negocio.Producto.ListarProductos(Entidad.Producto, "DET")

            If dtProducto.Rows.Count > 0 Then
                CmbTipoProducto.Value = dtProducto.Rows(0).Item("TipoProducto")
                CmbCaracteristicas.Value = dtProducto.Rows(0).Item("Caracteristica")
                TxtUbicacionAlmacen.Text = dtProducto.Rows(0).Item("UbicacionAlmacen")
                TiempoStockNumero.Value = dtProducto.Rows(0).Item("TipoStockSeguridad")
                CmbStockSeguridad.Value = dtProducto.Rows(0).Item("CodigoStockSeguridad")
                TiempoEsperaNumero.Value = dtProducto.Rows(0).Item("TiempoImportancion")
                CmbTiempoEspera.Value = dtProducto.Rows(0).Item("CodigoTiempoImportancion")
                CmbClasificacionContable.Value = dtProducto.Rows(0).Item("ClasificacionContable")
                TxtStock.Value = dtProducto.Rows(0).Item("StockMinimo")

                If dtProducto.Rows(0).Item("SuministroConsumible") = "1" Then
                    ChkConsumoFrecuente.Checked = True
                Else
                    ChkConsumoFrecuente.Checked = False
                End If

                If dtProducto.Rows(0).Item("SuministroCritico") = "1" Then
                    ChkSuministroCritico.Checked = True
                Else
                    ChkSuministroCritico.Checked = False
                End If

                If dtProducto.Rows(0).Item("ControlDua") = "1" Then
                    ChkControlDUA.Checked = True
                Else
                    ChkControlDUA.Checked = False
                End If

                If dtProducto.Rows(0).Item("NumeroBolsas") = "1" Then
                    ChkNumeracionBolsas.Checked = True
                Else
                    ChkNumeracionBolsas.Checked = False
                End If

                If dtProducto.Rows(0).Item("CompraVolumen") = "1" Then
                    ChkCompraVolumen.Checked = True
                Else
                    ChkCompraVolumen.Checked = False
                End If

                If dtProducto.Rows(0).Item("Origen") = "E" Then
                    RbImportado.Checked = True
                Else
                    RbNacional.Checked = True
                End If
            End If
        End If
    End Sub
#End Region

#Region "BtnGuardar - Click"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Call Grabar()
        ' MsgBox(xValidar)
        If xValidar = "0" Then
            Me.Close()
        End If

    End Sub
#End Region

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                             Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)


    End Sub

#End Region     '   Eventos Controles

#Region "Load"
    Private Sub FrmMaestroSuministros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarAlmacen_General(CboAlmacen)

        Call ListarProductoMaestro()
        Call ListarNombreProductos()
        Call ListarDescripcionTecnicaProductos()
        Call ListarUM()
        Call ListarLineaProductos()
        Call ListarMes()
        Call ListarTipoProductos()
        Call ListarClasificacionContable()
        CmbTipoProducto.Value = "01"
    End Sub
#End Region                '   Load

End Class