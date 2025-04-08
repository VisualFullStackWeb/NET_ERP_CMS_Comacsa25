Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Math
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRegistrar

#Region "Declarar Variables"
    '   *****   VARIABLES   *****
    Private Ope As Int32 = 0

    '   *****   LISTAS  *****
    Dim Pedido As New List(Of ETPedido)
    Dim Ped As New ETPedido

    Private _OrdenTrabajo As Long = 0
    Private _Fecha1 As Date = Date.Today
    Private _Fecha2 As Date = Date.Today

    Dim lstdet As New List(Of ETListDetRequisicionAlmacen)
    Dim lob As ETListDetRequisicionAlmacen

    Dim LsDocumentosTecnicos As New List(Of ETListDocumentosTecnicos)
    Dim Doc As ETListDocumentosTecnicos

    Dim LsMaestroDocumentos As New List(Of ETLisMaestroDocumentosTecnicos)
    Dim Maestro As ETLisMaestroDocumentosTecnicos

    Public Ls_Permisos As New List(Of Integer)
#End Region
#Region "Propiedades"
    Private Property OrdenTrabajo() As Long
        Get
            Return _OrdenTrabajo
        End Get
        Set(ByVal value As Long)
            _OrdenTrabajo = value
        End Set
    End Property
    Private Property Fecha1() As Date
        Get
            Return _Fecha1
        End Get
        Set(ByVal value As Date)
            _Fecha1 = value
        End Set
    End Property
    Private Property Fecha2() As Date
        Get
            Return _Fecha2
        End Get
        Set(ByVal value As Date)
            _Fecha2 = value
        End Set
    End Property
#End Region

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Locales"

#Region "Documentos Tecnicos"
    Private Sub ListarDocumentos()
        dgvDocumentosTecnicos.DataSource = Nothing
        TxtCodigoProductoDocTec.Text = TxtCodigoProducto.Text
        TxtDescripcionDocTec.Text = TxtProducto.Text
        GrpDocTecnicos.Visible = True

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

                    Dim x = LsMaestroDocumentos.FindAll(Function(b) b.Codigo_Producto = TxtCodigoProductoDocTec.Text _
                                                 And b.Cod_DocTecnico = .Codigo And b.Estado = "A" And b.Producto = TxtProducto.Text)
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

    End Sub
#End Region

#Region "Listar Equipo"
    Private Sub ListarEquipo()
        Dim DtActivo As New DataTable
        With Entidad.EmpleoLabor
            .Cod_Cia = Companhia
            .Cod_Empleo = TxtCodigoEmpleo.Text
            .Cod_Activo = TxtCodigoActivo.Text
        End With
        DtActivo = Negocio.EmpleoLabor.ListarActivo(Entidad.EmpleoLabor, "LxC")
        If DtActivo.Rows.Count > 0 Then
            If Trim(DtActivo.Rows(0).Item("Modelo") & "") = "" And Trim(DtActivo.Rows(0).Item("Codigo") & "") <> "" Then
                TxtActivo.Text = Trim(DtActivo.Rows(0).Item("Codigo") & "")
            Else
                TxtActivo.Text = Trim(DtActivo.Rows(0).Item("Modelo") & "")
            End If
        Else
            TxtCodigoActivo.Clear()
            TxtCodigoActivo.Focus()
            Return
        End If
    End Sub

#End Region

#Region "Listar Requisicion"
    Private Sub ListarRequisicion()
        DgvListarRequisiciones.DataSource = Negocio.PedidoBL.Listar_PedidoPendiente(Entidad.Pedido, "LX")
    End Sub

#End Region

#Region "Validar Agregar"
    Private Function ValidarAgregar() As Boolean

        If TxtCodigoEmpleo.Text = "" Or (TxtCodigoEmpleo.Text <> "" And TxtEmpleo.Text = "") Then
            MsgBox("Debe seleccionar un EMPLEO.", MsgBoxStyle.Critical, "Comacsa")
            TxtCodigoEmpleo.Focus()
            Return False
        End If

        If TxtCodigoProducto.Text = "" Or (TxtCodigoProducto.Text <> "" And TxtProducto.Text = "") Then
            MsgBox("Debe de seleccionar un producto.", MsgBoxStyle.Critical, "Comacsa")
            TxtCodigoProducto.Focus()
            Return False
        End If

        If IsDBNull(Txtcantidad.Value) = True Then Txtcantidad.Value = 0

        If Txtcantidad.Value = 0 Then
            MsgBox("Debe ingresar una cantidad.", MsgBoxStyle.Critical, "Comacsa")
            Txtcantidad.Focus()
            Return False
        End If

        If TxtCodigoActivo.Enabled = True Then
            If TxtActivo.Text = "" Then
                MsgBox("Debe seleccionar un Equipo.", MsgBoxStyle.Critical, "Comacsa")
                TxtCodigoActivo.Focus()
                Return False
            End If
        End If

        If CboArea.Value <> 22 Then
            If TxtCodigoCantera.Enabled = True Then
                If TxtCodigoCantera.Text = "" Then
                    MsgBox("Debe seleccionar una CANTERA para realizar el registro.", MsgBoxStyle.Critical, "Comacsa")
                    TxtCodigoCantera.Focus()
                    Return False
                End If
            End If
        End If


        Return True
    End Function
#End Region

#Region "Validar Grabar"
    Private Function ValidarGrabar() As Boolean
        If CboAlmacen.Value = 0 Then
            MsgBox("Debe seleccionar un Almacén", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If CboArea.Value = 0 Then
            MsgBox("Debe Seleccionar un Area", MsgBoxStyle.Critical, "Comacsa")
        End If

        If TxtCodigoCantera.Enabled = True Then
            If TxtCantera.Text = "" Then
                MsgBox("Debe seleccionar una cantera.", MsgBoxStyle.Critical, "Comacsa")
                TxtCodigoCantera.Focus()
                Return False
            End If
        End If

        If dgvProductos.Rows.Count = 0 Then
            MsgBox("No hay detalle para GRABAR", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If GrpDocTecnicos.Visible = True Then
            MsgBox("Debe cerrar la ventana de documentos tecnicos.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If ChkOT.Checked = True Then
            If String.IsNullOrEmpty(TxtOT.Text.Trim) Then
                MsgBox("Seleccione la Orden de Trabajo", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If

            If Me.OrdenTrabajo <= 0 Then
                TxtOT.Clear()
                MsgBox("Seleccione la Orden de Trabajo", MsgBoxStyle.Critical, "Comacsa")
                Return False
            Else
                If CDate(Fecha1) > CDate(dtFechaEntrega.Value) OrElse CDate(Fecha2) < CDate(dtFechaEntrega.Value) Then
                    MsgBox("La Fecha de Entrega esta fuera del Rango de la O/T" & Chr(13) & "Desde: " & Fecha1.ToShortDateString & " Al " & Fecha2.ToShortDateString, MsgBoxStyle.Critical, "Comacsa")
                    Return False
                End If

            End If

        End If
        Return True
    End Function
#End Region

#Region "Limpiar"
    Private Sub Limpiar()
        TxtCodigoProducto.Clear()
        TxtProducto.Clear()
        TxtStock.Value = 0
        Txtcantidad.Value = 0
        TxtUm.Clear()
        TxtCondiciones.Clear()
        TxtCodigoActivo.Clear()
        TxtActivo.Clear()
        TxtImagenes.Clear()
        CboAplicacion.SelectedIndex = -1
        TxtObservaciones.Clear()
        TxtUMCompra.Clear()

    End Sub
#End Region

#Region "Validar Registro"
    Private Sub RegistroValidar()
        If dgvProductos.Rows.Count > 0 Then
            For i As Integer = 0 To dgvProductos.Rows.Count - 1
                If Trim(TxtCodigoProducto.Text & "") = dgvProductos.Rows(i).Cells("Codigo").Value And Trim(TxtProducto.Text & "") = dgvProductos.Rows(i).Cells("Descripcion").Value And Trim(TxtCodigoActivo.Text & "") = dgvProductos.Rows(i).Cells("CodigoActivo").Value Then
                    dgvProductos.Rows(i).Delete()
                    Exit For
                End If
            Next
        End If
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

#Region "Numero de Canteras"
    Private Sub NumeroCantera()
        Dim dtNumeroCantera As New DataTable
        With Entidad.EmpleoLabor
            .Cod_Cia = Companhia
            .Cod_Empleo = TxtCodigoEmpleo.Text
        End With
        dtNumeroCantera = Negocio.EmpleoLabor.ListarCantera(Entidad.EmpleoLabor, "LIS")

        If dtNumeroCantera.Rows.Count = 1 Then
            TxtCodigoCantera.Text = Trim(dtNumeroCantera.Rows(0).Item("Codigo"))
            TxtCodigoCantera.Enabled = True
            TxtCantera.Text = Trim(dtNumeroCantera.Rows(0).Item("Cantera"))
            TxtCantera.Enabled = True
            btnCantera.Enabled = True
            CboContratista.Enabled = True
            Call ContratistaCantera(CboContratista, TxtCodigoCantera.Text, CboArea.Value)

        ElseIf dtNumeroCantera.Rows.Count > 1 Then
            TxtCodigoCantera.Enabled = True
            TxtCantera.Enabled = True
            btnCantera.Enabled = True
            CboContratista.Enabled = True
        ElseIf dtNumeroCantera.Rows.Count = 0 Then
            TxtCodigoCantera.Enabled = False
            TxtCantera.Enabled = False
            btnCantera.Enabled = False
            CboContratista.Enabled = False
        End If


    End Sub

#End Region

#Region "Numero de Equipos"
    Private Sub NumeroEquipos()
        Dim dtNumeroEquipo As New DataTable
        With Entidad.EmpleoLabor
            .Cod_Cia = Companhia
            .Cod_Empleo = TxtCodigoEmpleo.Text
            .Cod_Cantera = TxtCodigoCantera.Text
        End With
        dtNumeroEquipo = Negocio.EmpleoLabor.ListarActivo(Entidad.EmpleoLabor, "LIS")

        If dtNumeroEquipo.Rows.Count = 1 Then
            TxtCodigoActivo.Text = Trim(dtNumeroEquipo.Rows(0).Item("Codigo"))
            TxtCodigoActivo.Enabled = True
            TxtActivo.Text = Trim(dtNumeroEquipo.Rows(0).Item("Modelo"))

            If TxtActivo.Text = "" Then
                TxtActivo.Text = Trim(dtNumeroEquipo.Rows(0).Item("Codigo"))
            End If

            TxtActivo.Enabled = True
            btnActivo.Enabled = True
        ElseIf dtNumeroEquipo.Rows.Count > 1 Then
            TxtCodigoActivo.Enabled = True
            TxtActivo.Enabled = True
            btnActivo.Enabled = True
        ElseIf dtNumeroEquipo.Rows.Count = 0 Then
            TxtCodigoActivo.Enabled = False
            TxtActivo.Enabled = False
            btnActivo.Enabled = False
        End If


    End Sub
#End Region

#Region "Numero de Empleo - Labor"
    Private Sub NumeroEmpleoLabor()
        Dim dtEmpleoLabor As New DataTable
        With Entidad.EmpleoLabor
            .Cod_Cia = Companhia
            .Cod_Area = CboArea.Value
        End With
        dtEmpleoLabor = Negocio.EmpleoLabor.ListarEmpleoLabor(Entidad.EmpleoLabor, "LT2")

        If dtEmpleoLabor.Rows.Count = 1 Then
            TxtCodigoEmpleo.Text = Trim(dtEmpleoLabor.Rows(0).Item("Codigo"))
            TxtCodigoEmpleo.Enabled = True
            TxtEmpleo.Text = Trim(dtEmpleoLabor.Rows(0).Item("Empleo"))
            TxtEmpleo.Enabled = True
            btnEmpleo.Enabled = True
            Call NumeroCantera()
            Call NumeroEquipos()
            Call AplicacionAreaEmpleo()

        ElseIf dtEmpleoLabor.Rows.Count > 1 Then
            TxtCodigoEmpleo.Clear()
            TxtCodigoEmpleo.Enabled = True
            TxtEmpleo.Clear()
            TxtEmpleo.Enabled = True
            btnEmpleo.Enabled = True
        ElseIf dtEmpleoLabor.Rows.Count = 0 Then
            TxtCodigoEmpleo.Clear()
            TxtCodigoEmpleo.Enabled = False
            TxtEmpleo.Clear()
            TxtEmpleo.Enabled = False
            btnEmpleo.Enabled = False
        End If
    End Sub
#End Region

#Region "Listar Aplicacion Area Empleo"
    Private Sub AplicacionAreaEmpleo()
        With Entidad.Pedido
            .Cod_Cia = Companhia
            .Codigo_Area = Trim(CboArea.Value & "")
            .Codigo_Empleo = Trim(TxtCodigoEmpleo.Text & "")
        End With
        CboAplicacion.DataSource = Negocio.PedidoBL.ListarAplicacion(Entidad.Pedido)
        CboAplicacion.DisplayMember = "Descripcion"
        CboAplicacion.ValueMember = "Codigo"
        CboAplicacion.SelectedIndex = -1
    End Sub
#End Region

#End Region   '   Funciones Locales

#Region "Funciones Publicas"

#Region "Grabar"
    Public Sub Grabar()
        If ValidarGrabar() = False Then Return
        If dgvProductos.Rows.Count > 0 Then
            If MsgBox("¿Esta Seguro de GRABAR el Requerimiento ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                Try
                    With Entidad.Pedido
                        If CboArea.Value = 22 Then
                            .Codigo_Empleo = TxtCodigoEmpleo.Text
                            .Codigo_Cantera = TxtCodigoCantera.Text
                            .Codigo_Proveedor = CboContratista.Value
                            .Razon_Social = CboContratista.Text
                        Else
                            .Codigo_Empleo = ""
                            .Codigo_Cantera = ""
                            .Codigo_Proveedor = ""
                            .Razon_Social = ""
                        End If
                        .OrdenTrabajo = Me.OrdenTrabajo
                        .Cod_OrdenTrabajo = TxtOT.Text
                        .Fecha1 = Fecha1
                        .Fecha2 = Fecha2
                        .Cod_Cia = Companhia
                        .Numero_Doc = TxtNumeroRequisicion.Text
                        .Tipo_Doc = "RAL"
                        .Codigo_Area = CboArea.Value
                        .Codigo_Almacen = CboAlmacen.Value
                        .Fecha = dtFechaEntrega.Value
                        .User = User_Sistema
                        If ChkUrgente.Checked = True Then
                            .Urgente = "U"
                        Else
                            .Urgente = "N"
                        End If

                        If gAdmin = 0 Then
                            .Estado = "P"
                        Else
                            .Estado = "A"
                        End If

                    End With

                    For i As Integer = 0 To dgvProductos.Rows.Count - 1
                        Ped = New ETPedido
                        With Ped
                            .Cod_Cia = Companhia
                            .Tipo_Doc = "RAL"
                            .Codigo_Producto = dgvProductos.Rows(i).Cells("Codigo").Value
                            .Descripcion_Producto = dgvProductos.Rows(i).Cells("Descripcion").Value
                            .Unidad = dgvProductos.Rows(i).Cells("UM").Value
                            .Cantidad_Solicitada = dgvProductos.Rows(i).Cells("Cantidad").Value
                            .Cod_Activo = dgvProductos.Rows(i).Cells("CodigoActivo").Value
                            .Ruta_CondTecnicas = dgvProductos.Rows(i).Cells("Tecnicas").Value
                            .Ruta_Imagenes = dgvProductos.Rows(i).Cells("Imagenes").Value
                            .Codigo_Aplicacion = dgvProductos.Rows(i).Cells("CodigoAplicacion").Value
                            .Aplicacion = dgvProductos.Rows(i).Cells("Aplicacion").Value
                            .Observaciones = dgvProductos.Rows(i).Cells("Observaciones").Value
                            .UMCompra = dgvProductos.Rows(i).Cells("UMCompra").Value
                            .Item = i + 1
                            If gAdmin = 1 Then
                                .Cantidad_Autorizada = dgvProductos.Rows(i).Cells("Cantidad").Value
                            Else
                                .Cantidad_Autorizada = 0
                            End If
                            If CboArea.Value <> 22 Then
                                .Codigo_Cantera = Trim(dgvProductos.Rows(i).Cells("CodigoCantera").Value & "")
                                .Codigo_Empleo = Trim(dgvProductos.Rows(i).Cells("CodigoEmpleo").Value & "")
                            Else
                                .Codigo_Cantera = ""
                                .Codigo_Empleo = ""
                            End If
                        End With
                        Pedido.Add(Ped)
                    Next

                    If TxtNumeroRequisicion.Text = "" Then
                        Entidad.Resultado = Negocio.PedidoBL.GrabarPedido(Entidad.Pedido, Pedido, LsMaestroDocumentos, "AGR")
                        If Entidad.Resultado.Realizo = True Then MsgBox("La Requisicion se Guardo con éxito, con el numero: " + Entidad.Resultado.Mensaje, MsgBoxStyle.Information, "Comacsa")
                    Else
                        Entidad.Resultado = Negocio.PedidoBL.GrabarPedido(Entidad.Pedido, Pedido, LsMaestroDocumentos, "MODI")
                        If Entidad.Resultado.Realizo = True Then MsgBox("La Requisicion : " + Entidad.Resultado.Mensaje + " se MODIFICÓ con éxito", MsgBoxStyle.Information, "Comacsa")
                    End If


                    Call Nuevo()
                    Call ListarRequisicion()
                    TabRequisicion.Tabs("Listar").Selected = True

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Else
            MsgBox("NO hay producto(s) por registrar", MsgBoxStyle.Critical, "Comacsa")
            Return
        End If
    End Sub
#End Region

#Region "Cancelar"
    Public Sub Cancelar()
        TxtCodigoProducto.Clear()
        TxtProducto.Clear()
        TxtCondiciones.Clear()
        TxtImagenes.Clear()
        TxtCodigoActivo.Clear()
        TxtActivo.Clear()
        If TxtCantera.Text = "" Then
            TxtCodigoCantera.ReadOnly = False
        End If
    End Sub
#End Region

#Region "Nuevo"

    Public Sub Nuevo()
        lstdet = New List(Of ETListDetRequisicionAlmacen)
        LsDocumentosTecnicos = New List(Of ETListDocumentosTecnicos)
        LsMaestroDocumentos = New List(Of ETLisMaestroDocumentosTecnicos)
        Pedido = New List(Of ETPedido)

        btnEmpleo.Enabled = True

        dgvProductos.DataSource = lstdet

        TabRequisicion.Tabs("Registrar").Enabled = True
        TabRequisicion.Tabs("Registrar").Selected = True

        dtFechaEntrega.Value = Now
        dtFechaEntrega.ReadOnly = False

        CboAlmacen.Value = "28"
        CboAlmacen.ReadOnly = False

        CboArea.Value = gAreaUsuario
        CboArea.ReadOnly = False

        TxtCodigoEmpleo.Clear()
        TxtCodigoEmpleo.ReadOnly = False
        TxtEmpleo.Clear()

        TxtCodigoProducto.Clear()
        TxtCodigoProducto.ReadOnly = False
        TxtProducto.Clear()

        Txtcantidad.Value = 0
        Txtcantidad.ReadOnly = False
        TxtStock.Value = 0

        TxtCodigoActivo.Clear()
        TxtCodigoActivo.ReadOnly = False
        TxtActivo.Clear()

        TxtCodigoCantera.Clear()
        TxtCodigoCantera.ReadOnly = False
        TxtCantera.Clear()

        TxtUm.Clear()
        TxtCondiciones.Clear()
        TxtImagenes.Clear()
        TxtNumeroRequisicion.Clear()

        TxtOT.Clear()
        ChkOT.Checked = False
        _OrdenTrabajo = 0
        _Fecha1 = Date.Today
        _Fecha2 = Date.Today


    End Sub
#End Region

#Region "Eliminar"
    Public Sub Eliminar()
        If Me.TabRequisicion.Tabs("Listar").Selected = True Then
            If DgvListarRequisiciones.Rows.Count > 0 Then
                If MsgBox("¿Esta Seguro de ANULAR el Requerimiento ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                    With Entidad.Pedido
                        .Cod_Cia = Companhia
                        .Tipo_Doc = "RAL"
                        .Numero_Doc = DgvListarRequisiciones.ActiveRow.Cells("Codigo").Value
                        .User = User_Sistema

                        Entidad.Resultado = Negocio.PedidoBL.EliminarPedido(Entidad.Pedido)
                        If Entidad.Resultado.Realizo = True Then
                            MsgBox("La ANULACIÓN del Requerimiento " + .Numero_Doc + "se realizó con éxito", MsgBoxStyle.Information, "Comacsa")
                            Call ListarRequisicion()
                        End If
                    End With
                Else
                    Return
                End If
            End If
        End If

        If Me.TabRequisicion.Tabs("Registrar").Selected = True Then
            If dgvProductos.ActiveRow.Cells("Codigo").Value <> "" Then
                If MsgBox("¿Esta Seguro de ELIMINAR el registro Seleccionado?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                    dgvProductos.ActiveRow.Delete()
                Else
                    Return
                End If
            End If

        End If


    End Sub
#End Region

#Region "Modificar"
    Public Sub Modificar()
        If TxtEmpleo.Text <> "" And CboArea.Value <> 0 And CboAplicacion.SelectedIndex <> -1 Then
            GrpDetalleRegistro.Visible = False
            GrpAplicacionNuevo.Visible = True
            TxtCodigoArea.Text = CboArea.Value
            TxtArea.Text = CboArea.Text
            TxtAplicacionCodigoEmpleo.Text = TxtCodigoEmpleo.Text
            TxtAplicacionEmpleo.Text = TxtEmpleo.Text
            TxtDescripcionAplicacion.Text = CboAplicacion.Text
            TxtCodigoAplicacion.Text = CboAplicacion.Value
        ElseIf TxtEmpleo.Text = "" Then
            MsgBox("Debe seleccionar un empleo para continuar.", MsgBoxStyle.Critical, "Comacsa")
            TxtCodigoEmpleo.Focus()
        ElseIf CboArea.Value = 0 Then
            MsgBox("Debe seleccionar un Area para continuar.", MsgBoxStyle.Critical, "Comacsa")
            CboArea.Focus()
        ElseIf CboAplicacion.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una Aplicación para continuar.", MsgBoxStyle.Critical, "Comacsa")
            CboAplicacion.Focus()
        End If
    End Sub
#End Region

#End Region  '   Funciones Publicas

#Region "Eventos Controles"

#Region "Boton Condiciones Tecnicas"
    Private Sub btnCondicionesTecnicas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCondicionesTecnicas.Click
        If TxtCodigoProducto.Text <> "" Then
            Try
                OpenFile.CheckFileExists = True
                OpenFile.CheckPathExists = True
                OpenFile.DereferenceLinks = True
                OpenFile.ValidateNames = True
                OpenFile.Multiselect = False
                OpenFile.RestoreDirectory = True
                OpenFile.ShowHelp = True
                OpenFile.ShowReadOnly = False
                OpenFile.DefaultExt = "doc"
                OpenFile.Title = "Seleccione Archivo"
                OpenFile.Filter = "Microsoft Word Files (*.doc)|*.doc|Adobe Acrobat files (*.pdf)|*.pdf"
                If OpenFile.ShowDialog() = 1 Then
                    TxtCondiciones.Text = OpenFile.FileName
                End If

            Catch objException As Exception
                MsgBox("Error: Cargar Arhivo()" & vbCrLf & objException.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            MsgBox("Debe seleccionar un PRODUCTO", MsgBoxStyle.Critical, "Comacsa")
            TxtCodigoProducto.Focus()
            Return
        End If

    End Sub
#End Region

#Region "Boton Imagenes"
    Private Sub btnImagenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImagenes.Click
        If TxtCodigoProducto.Text <> "" Then
            Try
                OpenFile.CheckFileExists = True
                OpenFile.CheckPathExists = True
                OpenFile.DereferenceLinks = True
                OpenFile.ValidateNames = True
                OpenFile.Multiselect = False
                OpenFile.RestoreDirectory = True
                OpenFile.ShowHelp = True
                OpenFile.ShowReadOnly = False
                OpenFile.DefaultExt = "jpg"
                OpenFile.Title = "Seleccione Imagen"
                OpenFile.Filter = "Microsoft Picture Files (*.jpg)|*.jpg|Microsoft Picture Files (*.gif)|*.gif"
                If OpenFile.ShowDialog() = 1 Then
                    TxtImagenes.Text = OpenFile.FileName
                End If
            Catch objException As Exception
                MsgBox("Error: Cargar Imagen()" & vbCrLf & objException.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            MsgBox("Debe seleccionar un PRODUCTO", MsgBoxStyle.Critical, "Comacsa")
            TxtCodigoProducto.Focus()
            Return
        End If
    End Sub
#End Region

#Region "Boton Producto"
    Private Sub btnProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProducto.Click
        If TxtCodigoEmpleo.Text <> "" Then
            Companhia = Companhia
            gAlmacen = CboAlmacen.Value
            gEmpleo = TxtCodigoEmpleo.Text
            Dim ListarProductos As New FrmListarProductos
            ListarProductos.ShowDialog()
            TxtCodigoProducto.Text = ListarProductos.CODIGO
            TxtProducto.Text = ListarProductos.DESCRIPCION
            TxtStock.Value = ListarProductos.STOCK
            TxtUm.Text = ListarProductos.UNIDADMEDIDA
            TxtUMCompra.Text = ListarProductos.UMCOMPRA

            If TxtCodigoProducto.Text = "00000000" Then
                Txtcantidad.Value = TxtStock.Value
                Txtcantidad.ReadOnly = True
                TxtStock.Value = 0
            Else
                Txtcantidad.Focus()
                Txtcantidad.SelectAll()
                Txtcantidad.ReadOnly = False
            End If
        Else
            MsgBox("Debe seleccionar un Empleo.", MsgBoxStyle.Critical, "Comacsa")
            TxtCodigoEmpleo.Focus()
            Return
        End If
    End Sub
#End Region

#Region "Boton Empleo"
    Private Sub btnEmpleo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleo.Click
        If CboArea.Value <> 0 Then

            TxtCodigoProducto.Clear()
            TxtProducto.Clear()
            TxtStock.Value = 0
            Txtcantidad.Value = 0
            TxtUm.Clear()
            TxtCodigoActivo.Clear()
            TxtActivo.Clear()
            TxtCodigoCantera.Clear()
            TxtCantera.Clear()
            Companhia = Companhia
            gArea = CboArea.Value

            Dim EmpleoLabor As New FrmListarEmpleoLabor
            EmpleoLabor.ShowDialog()

            TxtCodigoEmpleo.Text = EmpleoLabor.CODIGO
            TxtEmpleo.Text = EmpleoLabor.EMPLEO

            Call NumeroCantera()
            Call NumeroEquipos()
            Call AplicacionAreaEmpleo()

        Else
            MsgBox("Debe seleccionar un Area", MsgBoxStyle.Critical, "Comacsa")
            CboArea.Focus()
            Return
        End If
    End Sub
#End Region

#Region "Boton Cantera"
    Private Sub btnCantera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCantera.Click
        If TxtCodigoEmpleo.Text <> "" Then
            Companhia = Companhia
            gEmpleo = TxtCodigoEmpleo.Text
            Dim Cantera As New FrmListarCantera
            Cantera.ShowDialog()
            TxtCodigoCantera.Text = Cantera.CODIGO
            TxtCantera.Text = Cantera.CANTERA
            Call ContratistaCantera(CboContratista, TxtCodigoCantera.Text, CboArea.Value)
        Else
            MsgBox("Debe seleccionar un Empleo", MsgBoxStyle.Information, "Comacsa")
            TxtCodigoEmpleo.Focus()
            Return
        End If
    End Sub
#End Region

#Region "Boton Activo"
    Private Sub btnActivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivo.Click
        If TxtCodigoEmpleo.Text <> "" Then
            Companhia = Companhia
            gEmpleo = TxtCodigoEmpleo.Text

            Dim Activo As New FrmListarActivo
            Activo.ShowDialog()
            TxtCodigoActivo.Text = Trim(Activo.CODIGO & "")

            If Trim(Activo.CODIGO & "") <> "" And Trim(Activo.ACTIVO & "") = "" Then
                TxtActivo.Text = Trim(Activo.CODIGO & "")
            Else
                TxtActivo.Text = Trim(Activo.ACTIVO & "")
            End If

        Else
            MsgBox("Debe seleccionar un Empleo", MsgBoxStyle.Critical, "Comacsa")
            TxtCodigoEmpleo.Focus()
            Return
        End If
    End Sub
#End Region

#Region "Grilla DgvListarRequisiciones DoubleClickRow"
    Private Sub DgvListarRequisiciones_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvListarRequisiciones.DoubleClickRow
        If DgvListarRequisiciones.Rows.Count = 0 Then
            Return
        End If

        Dim DtModificar As New DataTable
        Dim DtDocTec As New DataTable

        TabRequisicion.Tabs("Registrar").Enabled = True
        TabRequisicion.Tabs("Registrar").Selected = True
        TxtNumeroRequisicion.Text = e.Row.Cells("Codigo").Value

        TxtCodigoEmpleo.Text = Trim(e.Row.Cells("CodigoEmpleo").Value & "")
        TxtEmpleo.Text = Trim(e.Row.Cells("EmpleoLabor").Value & "")
        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        CboArea.Value = e.Row.Cells("CodigoArea").Value
        TxtCodigoCantera.Text = Trim(e.Row.Cells("CodigoCantera").Value & "")
        TxtCantera.Text = Trim(e.Row.Cells("Cantera").Value & "")
        If e.Row.Cells("OrdenTrabajo").Value = 0 Then
            ChkOT.Checked = False
            TxtOT.Clear()
            OrdenTrabajo = 0
        Else
            ChkOT.Checked = True
            OrdenTrabajo = e.Row.Cells("OrdenTrabajo").Value
            TxtOT.Text = e.Row.Cells("Cod_OrdenTrabajo").Value
            Fecha1 = e.Row.Cells("Fecha1").Value
            Fecha2 = e.Row.Cells("Fecha2").Value
        End If
        Call ContratistaCantera(CboContratista, TxtCodigoCantera.Text, CboArea.Value)


        If e.Row.Cells("Urgente").Value = "N" Then
            ChkUrgente.Checked = False
        Else
            ChkUrgente.Checked = True
        End If

        CboContratista.Value = e.Row.Cells("CodigoProveedor").Value
        dtFechaEntrega.Value = e.Row.Cells("Entrega").Value

        btnEmpleo.Enabled = False
        TxtCodigoEmpleo.ReadOnly = True

        With Entidad.Pedido
            .Numero_Doc = TxtNumeroRequisicion.Text
            .Tipo_Doc = "RAL"
            .Cod_Cia = Companhia
        End With
        DtModificar = Negocio.PedidoBL.ListarDetallePedido(Entidad.Pedido, "LP")
        DtDocTec = Negocio.PedidoBL.Listar_DocTec(Entidad.Pedido, "LIS")

        dgvProductos.DataSource = Nothing
        Efectos()
        If DtModificar.Rows.Count > 0 Then
            For i As Integer = 0 To DtModificar.Rows.Count - 1
                lob = New ETListDetRequisicionAlmacen
                With lob
                    .CodigoEmpleo = Trim(DtModificar.Rows(i).Item("CodigoEmpleo") & "")
                    .Empleo = Trim(DtModificar.Rows(i).Item("Empleo") & "")
                    .Codigo = Trim(DtModificar.Rows(i).Item("Codigo") & "")
                    .Descripcion = Trim(DtModificar.Rows(i).Item("Descripcion") & "")
                    .Cantidad = Trim(DtModificar.Rows(i).Item("Cantidad") & "")
                    .UM = Trim(DtModificar.Rows(i).Item("UM") & "")
                    .Tecnicas = Trim(DtModificar.Rows(i).Item("Tecnicas") & "")
                    .CodigoActivo = Trim(DtModificar.Rows(i).Item("CodigoActivo") & "")
                    .Activo = Trim(DtModificar.Rows(i).Item("Activo") & "")
                    .CodigoCantera = Trim(DtModificar.Rows(i).Item("CodigoCantera") & "")
                    .Cantera = Trim(DtModificar.Rows(i).Item("Cantera") & "")
                    .Imagenes = Trim(DtModificar.Rows(i).Item("Imagenes") & "")
                    .CodigoAplicacion = Trim(DtModificar.Rows(i).Item("CodigoAplicacion") & "")
                    .Aplicacion = Trim(DtModificar.Rows(i).Item("Aplicacion") & "")
                    .Observaciones = Trim(DtModificar.Rows(i).Item("Observaciones") & "")
                    .UMCOMPRA = Trim(DtModificar.Rows(i).Item("UMCompra"))
                End With
                lstdet.Add(lob)
            Next
            dgvProductos.DataSource = lstdet
            dgvProductos.Refresh()
        End If

        If DtDocTec.Rows.Count > 0 Then
            For i As Integer = 0 To DtDocTec.Rows.Count - 1
                Maestro = New ETLisMaestroDocumentosTecnicos
                With Maestro
                    .Codigo_Producto = DtDocTec.Rows(i).Item("Codigo")
                    .Producto = DtDocTec.Rows(i).Item("Producto")
                    .Cod_DocTecnico = DtDocTec.Rows(i).Item("Documento")
                    .Estado = "A"
                End With
                LsMaestroDocumentos.Add(Maestro)
            Next

        End If

        If CboArea.Value = 22 Then
            btnCantera.Enabled = True
            TxtCodigoCantera.Enabled = True
            TxtCantera.Enabled = True
            TxtCodigoActivo.Enabled = True
            TxtActivo.Enabled = True
            btnActivo.Enabled = True
        Else
            btnEmpleo.Enabled = True
            TxtCodigoEmpleo.ReadOnly = False
        End If
    End Sub
#End Region

#Region "Grilla dgvProductos DoubleClickRow "
    Private Sub dgvProductos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvProductos.DoubleClickRow
        Dim Dt As New DataTable
        TxtCodigoProducto.Text = Trim(e.Row.Cells("Codigo").Value & "")
        TxtProducto.Text = Trim(e.Row.Cells("Descripcion").Value & "")
        Txtcantidad.Text = Trim(e.Row.Cells("Cantidad").Value & "")
        TxtUm.Text = Trim(e.Row.Cells("UM").Value & "")
        TxtUMCompra.Text = Trim(e.Row.Cells("UMCOMPRA").Value & "")
        TxtCondiciones.Text = Trim(e.Row.Cells("Tecnicas").Value & "" & "")
        TxtCodigoActivo.Text = Trim(e.Row.Cells("CodigoActivo").Value & "")
        TxtActivo.Text = Trim(e.Row.Cells("Activo").Value & "")
        TxtImagenes.Text = Trim(e.Row.Cells("Imagenes").Value & "")
        Call AplicacionAreaEmpleo()
        CboAplicacion.Value = Trim(e.Row.Cells("CodigoAplicacion").Value & "")
        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodAlmacen = CboAlmacen.Value
            .CodProducto = e.Row.Cells("Codigo").Value
            .Empleo = Trim(TxtCodigoEmpleo.Text & "")
        End With
        Dt = Negocio.Producto.ListarProductos(Entidad.Producto, "LCO")

        If Dt.Rows.Count > 0 Then
            TxtStock.Text = Dt.Rows(0).Item("Stock")
        End If
        Txtcantidad.ReadOnly = False

        If CboArea.Value <> 22 Then
            TxtCodigoEmpleo.Text = e.Row.Cells("CodigoEmpleo").Value
            TxtEmpleo.Text = e.Row.Cells("Empleo").Value
            TxtCodigoCantera.Text = e.Row.Cells("CodigoCantera").Value
            TxtCantera.Text = e.Row.Cells("Cantera").Value
            btnEmpleo.Enabled = True
            TxtCodigoActivo.Enabled = True
            TxtActivo.Enabled = True
            btnActivo.Enabled = True
            TxtCodigoCantera.Enabled = True
            TxtCantera.Enabled = True
            btnCantera.Enabled = True
            Call NumeroCantera()
            Call NumeroEquipos()
        End If
    End Sub
#End Region

#Region "Grilla dgvProducto BeforeRowsDeleted"
    Private Sub dgvProductos_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvProductos.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
#End Region

#Region "Boton Agregar Fila"
    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ValidarAgregar() = False Then Return
        If CDbl(Txtcantidad.Value) > CDbl(TxtStock.Text) Then Call ListarDocumentos()
        Call RegistroValidar()
        TxtCodigoEmpleo.ReadOnly = False

        If TxtCodigoActivo.Text <> "" And TxtActivo.Text = "" Then
            TxtCodigoActivo.Clear()
        End If

        If TxtCodigoCantera.Text <> "" And TxtCantera.Text = "" Then
            TxtCantera.Clear()
        End If

        lob = New ETListDetRequisicionAlmacen
        dgvProductos.DataSource = Nothing
        Efectos()

        With lob
            .Codigo = TxtCodigoProducto.Text
            .Descripcion = TxtProducto.Text
            .Cantidad = Txtcantidad.Value
            .UM = TxtUm.Text
            .Tecnicas = TxtCondiciones.Text
            .CodigoActivo = TxtCodigoActivo.Text
            .Activo = TxtActivo.Text
            .Imagenes = TxtImagenes.Text
            .Aplicacion = Trim(CboAplicacion.Text & "")
            .CodigoAplicacion = Trim(CboAplicacion.Value & "")
            .Observaciones = Trim(TxtObservaciones.Text & "")
            .UMCOMPRA = Trim(TxtUMCompra.Text & "")
            If CboArea.Value <> 22 Then
                .CodigoEmpleo = TxtCodigoEmpleo.Text
                .Empleo = TxtEmpleo.Text
                .CodigoCantera = TxtCodigoCantera.Text
                .Cantera = TxtCantera.Text
            End If
        End With
        lstdet.Add(lob)
        dgvProductos.DataSource = lstdet
        dgvProductos.Refresh()
        Call Limpiar()
        Call NumeroEquipos()
    End Sub
#End Region

#Region "TabRequisicion SelectedTabChanged"
    Private Sub TabRequisicion_SelectedTabChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabRequisicion.SelectedTabChanged
        If TabRequisicion.Tabs("Registrar").Selected = False Then
            TabRequisicion.Tabs("Registrar").Enabled = False

            lstdet = New List(Of ETListDetRequisicionAlmacen)
            LsDocumentosTecnicos = New List(Of ETListDocumentosTecnicos)
            LsMaestroDocumentos = New List(Of ETLisMaestroDocumentosTecnicos)
            Call Limpiar()

        End If

    End Sub
#End Region

#Region "TxtCodigoEmpleo - ValueChanged"
    Private Sub TxtCodigoEmpleo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoEmpleo.ValueChanged
        If CboArea.Value = 22 Then
            If Len(TxtCodigoEmpleo.Text) <> 3 Then
                TxtEmpleo.Clear()
                TxtCodigoCantera.Clear()
                TxtCodigoCantera.Enabled = False

                TxtCantera.Enabled = False
                TxtCantera.Clear()

                btnCantera.Enabled = False
                CboContratista.Enabled = False

                TxtCodigoActivo.Clear()
                TxtCodigoActivo.Enabled = False

                TxtActivo.Clear()
                TxtActivo.Enabled = False

                btnActivo.Enabled = False

                lstdet = New List(Of ETListDetRequisicionAlmacen)
                LsDocumentosTecnicos = New List(Of ETListDocumentosTecnicos)
                LsMaestroDocumentos = New List(Of ETLisMaestroDocumentosTecnicos)
                dgvProductos.DataSource = lstdet
            End If
        End If
    End Sub
#End Region

#Region "TxtCodigoEmpleo - KeyPress"
    Private Sub TxtCodigoEmpleo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoEmpleo.KeyPress
        Dim DtEmpleo As New DataTable
        Select Case Asc(e.KeyChar)
            Case "13"
                With Entidad.EmpleoLabor
                    .Cod_Cia = Companhia
                    .Cod_Area = CboArea.Value
                    .Cod_Empleo = TxtCodigoEmpleo.Text
                End With
                DtEmpleo = Negocio.EmpleoLabor.ListarEmpleoLabor(Entidad.EmpleoLabor, "LT3")
                If DtEmpleo.Rows.Count > 0 Then
                    TxtEmpleo.Text = DtEmpleo.Rows(0).Item("Empleo")
                    Call NumeroCantera()
                    Call NumeroEquipos()
                    Call AplicacionAreaEmpleo()
                Else
                    MsgBox("No hay EMPLEO con este codigo: " & TxtCodigoEmpleo.Text, MsgBoxStyle.Information, "Comacsa")
                    TxtCodigoEmpleo.Clear()
                    TxtCodigoEmpleo.Focus()
                    Return
                End If
        End Select
    End Sub
#End Region

#Region "TxtCodigoProducto - ValueChanged"
    Private Sub TxtCodigoProducto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoProducto.ValueChanged
        If Len(TxtCodigoProducto.Text) <> 8 Then
            TxtProducto.Clear()
            TxtStock.Value = 0
            TxtUm.Clear()
            Txtcantidad.Value = 0
        End If
    End Sub
#End Region

#Region "TxtCodigoProducto - KeyPress"
    Private Sub TxtCodigoProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoProducto.KeyPress
        Dim DtProducto As New DataTable
        Select Case Asc(e.KeyChar)
            Case "13"
                With Entidad.Producto
                    .Cod_Cia = Companhia
                    .CodAlmacen = CboAlmacen.Value
                    .CodProducto = Trim(TxtCodigoProducto.Text & "")
                    .Empleo = Trim(TxtCodigoEmpleo.Text & "")
                End With

                DtProducto = Negocio.Producto.ListarProductos(Entidad.Producto, "LCO")
                If DtProducto.Rows.Count > 0 Then
                    TxtProducto.Text = DtProducto.Rows(0).Item("Descripcion")
                    TxtStock.Text = DtProducto.Rows(0).Item("Stock")
                    TxtUm.Text = DtProducto.Rows(0).Item("UM")
                    TxtUMCompra.Text = DtProducto.Rows(0).Item("UMCompra")
                    Txtcantidad.Focus()
                    Txtcantidad.SelectAll()
                Else
                    MsgBox("NO hay producto para este código.", MsgBoxStyle.Critical, "Comacsa")
                    Return
                End If
        End Select

    End Sub
#End Region

#Region "TxtCodigoActivo - ValueChanged"
    Private Sub TxtCodigoActivo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoActivo.ValueChanged
        If Len(TxtCodigoActivo.Text) <> 10 Then
            TxtActivo.Clear()
        End If
    End Sub
#End Region

#Region "TxtCodigoActivo - KeyPress"
    Private Sub TxtCodigoActivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoActivo.KeyPress
        Dim DtActivo As New DataTable
        Select Case Asc(e.KeyChar)
            Case "13"
                Call ListarEquipo()
        End Select
    End Sub
#End Region

#Region "TxtCodigoCantera - ValueChanged"
    Private Sub TxtCodigoCantera_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoCantera.ValueChanged
        If Len(Trim(TxtCodigoCantera.Text & "")) <> 5 Then
            TxtCantera.Clear()
            Call ContratistaCantera(CboContratista, TxtCodigoCantera.Text, CboArea.Value)
        End If
    End Sub
#End Region

#Region "TxtCodigoCantera - KeyPress"
    Private Sub TxtCodigoCantera_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoCantera.KeyPress
        Dim DtCantera As New DataTable
        Select Case Asc(e.KeyChar)
            Case "13"
                With Entidad.EmpleoLabor
                    .Cod_Cia = Companhia
                    .Cod_Cantera = TxtCodigoCantera.Text
                    .Cod_Empleo = TxtCodigoEmpleo.Text
                End With
                DtCantera = Negocio.EmpleoLabor.ListarCantera(Entidad.EmpleoLabor, "LxC")
                If DtCantera.Rows.Count > 0 Then
                    TxtCantera.Text = DtCantera.Rows(0).Item("Cantera")
                    Call ContratistaCantera(CboContratista, TxtCodigoCantera.Text, CboArea.Value)
                Else
                    MsgBox("NO hay CANTERA con este código: " & TxtCodigoCantera.Text, MsgBoxStyle.Information, "Comacsa")
                    TxtCodigoCantera.Clear()
                    TxtCodigoCantera.Focus()
                    Return
                End If
        End Select
    End Sub
#End Region

#Region "Boton Salir - Documentos Tecnicos"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click

        If MsgBox("¿Esta Seguro de cerrar la ventana.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            GrpDocTecnicos.Visible = False
        End If

    End Sub
#End Region

#Region "Boton Guardar - Documentos Tecnicos"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If DocumentosRequeridos() = False Then Return

        Dim x As New List(Of ETLisMaestroDocumentosTecnicos)

        If dgvDocumentosTecnicos.Rows.Count > 0 Then
            For i As Integer = 0 To dgvDocumentosTecnicos.Rows.Count - 1
                '  x = LsMaestroDocumentos.FindAll(Function(b) b.Cod_DocTecnico = dgvDocumentosTecnicos.Rows(i).Cells("Codigo").Value And b.Codigo_Producto = TxtCodigoProductoDocTec.Text)

                If dgvDocumentosTecnicos.Rows(i).Cells("Seleccionar").Value = True And x.Count = 0 Then

                    Maestro = New ETLisMaestroDocumentosTecnicos
                    With Maestro
                        .Codigo_Producto = Trim(TxtCodigoProductoDocTec.Text & "")
                        .Producto = Trim(TxtDescripcionDocTec.Text & "")
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
        Call ListarDocumentos()
        GrpDocTecnicos.Visible = False

    End Sub

    Private Function LsMaestroDocumentos_Estado(ByVal b As ETLisMaestroDocumentosTecnicos, ByVal Estado As String, ByVal codigoProducto As String, ByVal DocumentoTecnico As String, ByVal Producto As String) As String
        If b.Codigo_Producto = codigoProducto And b.Producto = Producto And b.Cod_DocTecnico = DocumentoTecnico Then
            b.Estado = Estado
        End If
        Return ""
    End Function

#End Region

#Region "CboArea - ValueChanged"
    Private Sub CboArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboArea.ValueChanged
        Dim xValor As String
        xValor = CboArea.Value
        If dgvProductos.Rows.Count > 0 And CboArea.Value <> xValor Then
            If MsgBox("Desea continuar, se borrarán todos los registros?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            Else
                CboArea.Value = xValor
                Return
            End If
        End If

        TxtCodigoCantera.Clear()
        TxtCantera.Clear()
        TxtCodigoActivo.Clear()
        TxtActivo.Clear()
        TxtOT.Clear()
        OrdenTrabajo = 0
        Fecha1 = Date.Today
        Fecha2 = Date.Today
        Call NumeroEmpleoLabor()

        lstdet = New List(Of ETListDetRequisicionAlmacen)
        LsDocumentosTecnicos = New List(Of ETListDocumentosTecnicos)
        LsMaestroDocumentos = New List(Of ETLisMaestroDocumentosTecnicos)
        dgvProductos.DataSource = lstdet
    End Sub
#End Region

#Region "BtnNuevoAplicacion - Click"
    Private Sub BtnNuevoAplicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevoAplicacion.Click
        If TxtEmpleo.Text <> "" And CboArea.Value <> 0 Then
            GrpDetalleRegistro.Visible = False
            GrpAplicacionNuevo.Visible = True
            TxtCodigoArea.Text = CboArea.Value
            TxtArea.Text = CboArea.Text
            TxtAplicacionCodigoEmpleo.Text = TxtCodigoEmpleo.Text
            TxtAplicacionEmpleo.Text = TxtEmpleo.Text
            TxtCodigoAplicacion.Clear()
            TxtDescripcionAplicacion.Clear()
            TxtDescripcionAplicacion.Focus()
        Else
            MsgBox("Debe seleccionar un empleo para continuar.", MsgBoxStyle.Critical, "Comacsa")
            TxtCodigoEmpleo.Focus()
        End If

    End Sub
#End Region

#Region "BtnAplicacionGrabar - Click"
    Private Sub BtnAplicacionGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAplicacionGrabar.Click
        If TxtDescripcionAplicacion.Text = "" Then
            MsgBox("Debe escribir una descripción para la aplicación.", MsgBoxStyle.Critical, "Comacsa")
            TxtDescripcionAplicacion.Focus()
            Return
        End If

        With Entidad.Pedido
            .Cod_Cia = Companhia
            .Codigo_Area = Trim(TxtCodigoArea.Text & "")
            .Codigo_Empleo = Trim(TxtAplicacionCodigoEmpleo.Text & "")
            .Aplicacion = Trim(TxtDescripcionAplicacion.Text & "")
            .Codigo_Aplicacion = Trim(TxtCodigoAplicacion.Text & "")
            .User = User_Sistema
        End With

        If MsgBox("¿Esta seguro de GRABAR la descripción.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

            If TxtCodigoAplicacion.Text = "" Then
                Entidad.Resultado = Negocio.PedidoBL.GrabarAplicacion(Entidad.Pedido, "AGR")
            Else
                Entidad.Resultado = Negocio.PedidoBL.GrabarAplicacion(Entidad.Pedido, "MOD")
            End If

            If Entidad.Resultado.Realizo = True Then
                MsgBox("Se guardaron correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
            End If

            GrpAplicacionNuevo.Visible = False
            Call AplicacionAreaEmpleo()
            GrpDetalleRegistro.Visible = True
            CboAplicacion.Text = Trim(TxtDescripcionAplicacion.Text & "")
        End If

    End Sub
#End Region

#Region "BtnAplicacionSalir - Click"
    Private Sub BtnAplicacionSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAplicacionSalir.Click
        GrpAplicacionNuevo.Visible = False
        Call AplicacionAreaEmpleo()
        GrpDetalleRegistro.Visible = True
    End Sub
#End Region

    Private Sub ChkOT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkOT.CheckedChanged
        TxtOT.Clear()
        _OrdenTrabajo = 0
        TxtOT.ReadOnly = True
        BtnOT.Enabled = ChkOT.Checked
        If ChkOT.Checked = True Then
            BtnOT.Focus()
        End If

    End Sub
#End Region   '   Eventos Controles

#Region "Load"

#Region "Load"
    Private Sub FrmRegistrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarAlmacenUsuarios(CboAlmacen, "28")
        Call ListarAreaUsuario(CboArea, "")
        Call ListarRequisicion()
        DgvListarRequisiciones.DisplayLayout.Bands(0).Columns("Entrega").CellAppearance.BackColor = Color.Lavender
        DgvListarRequisiciones.DisplayLayout.Bands(0).Columns("Entrega").CellAppearance.ForeColor = Color.Blue
        TabRequisicion.Tabs("Registrar").Enabled = False
        GrpDocTecnicos.Visible = False
        dtFecha.Value = Now
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
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción Documento"

        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Seleccionar").Width = 45
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Seleccionar").CellAppearance.TextHAlign = HAlign.Center
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Seleccionar").CellAppearance.TextVAlign = HAlign.Center
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Seleccionar").CellAppearance.FontData.SizeInPoints = 8
        dgvDocumentosTecnicos.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = "X"

    End Sub
#End Region

#Region "Efectos"
    Private Sub Efectos()
        dgvProductos.DisplayLayout.Bands(0).ColHeaderLines = 2

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("CodigoEmpleo")
        dgvProductos.DisplayLayout.Bands(0).Columns("CodigoEmpleo").Hidden = True

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("Empleo")
        If CboArea.Value = 22 Then
            dgvProductos.DisplayLayout.Bands(0).Columns("Empleo").Hidden = True
        Else
            dgvProductos.DisplayLayout.Bands(0).Columns("Empleo").Hidden = False
            dgvProductos.DisplayLayout.Bands(0).Columns("Empleo").Width = 250
            dgvProductos.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.TextHAlign = HAlign.Left
            dgvProductos.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.TextVAlign = HAlign.Center
            dgvProductos.DisplayLayout.Bands(0).Columns("Empleo").CellActivation = Activation.ActivateOnly
            dgvProductos.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.FontData.Bold = DefaultableBoolean.False
            dgvProductos.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.FontData.SizeInPoints = 8
            dgvProductos.DisplayLayout.Bands(0).Columns("Empleo").Header.Appearance.FontData.SizeInPoints = 8
            dgvProductos.DisplayLayout.Bands(0).Columns("Empleo").Header.Appearance.FontData.Bold = DefaultableBoolean.False
        End If

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("Codigo")
        dgvProductos.DisplayLayout.Bands(0).Columns("Codigo").Width = 75
        dgvProductos.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.TextHAlign = HAlign.Center
        dgvProductos.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.TextVAlign = HAlign.Center
        dgvProductos.DisplayLayout.Bands(0).Columns("Codigo").CellActivation = Activation.ActivateOnly
        dgvProductos.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Codigo").Header.Appearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Codigo").Header.Appearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Codigo").Header.Caption = "Código"

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("Descripcion")
        dgvProductos.DisplayLayout.Bands(0).Columns("Descripcion").Width = 250
        dgvProductos.DisplayLayout.Bands(0).Columns("Descripcion").CellActivation = Activation.ActivateOnly
        dgvProductos.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.TextVAlign = HAlign.Center
        dgvProductos.DisplayLayout.Bands(0).Columns("Descripcion").Header.Appearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Descripcion").Header.Appearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción"

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("UM")
        dgvProductos.DisplayLayout.Bands(0).Columns("UM").Width = 45
        dgvProductos.DisplayLayout.Bands(0).Columns("UM").CellAppearance.TextHAlign = HAlign.Center
        dgvProductos.DisplayLayout.Bands(0).Columns("UM").CellAppearance.TextVAlign = HAlign.Center
        dgvProductos.DisplayLayout.Bands(0).Columns("UM").CellActivation = Activation.ActivateOnly
        dgvProductos.DisplayLayout.Bands(0).Columns("UM").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("UM").CellAppearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("UM").Header.Appearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("UM").Header.Appearance.FontData.Bold = DefaultableBoolean.False

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("UMCompra")
        dgvProductos.DisplayLayout.Bands(0).Columns("UMCompra").Hidden = True

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("Cantidad")
        dgvProductos.DisplayLayout.Bands(0).Columns("Cantidad").Width = 75
        dgvProductos.DisplayLayout.Bands(0).Columns("Cantidad").CellAppearance.BackColor = Color.LemonChiffon
        dgvProductos.DisplayLayout.Bands(0).Columns("Cantidad").CellAppearance.ForeColor = Color.Blue
        dgvProductos.DisplayLayout.Bands(0).Columns("Cantidad").CellAppearance.TextHAlign = HAlign.Right
        dgvProductos.DisplayLayout.Bands(0).Columns("Cantidad").CellAppearance.TextVAlign = HAlign.Center
        dgvProductos.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Activation.ActivateOnly
        dgvProductos.DisplayLayout.Bands(0).Columns("Cantidad").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Cantidad").CellAppearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Cantidad").Format = "n4"
        dgvProductos.DisplayLayout.Bands(0).Columns("Cantidad").Header.Appearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Cantidad").Header.Appearance.FontData.Bold = DefaultableBoolean.False

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("CodigoAplicacion")
        dgvProductos.DisplayLayout.Bands(0).Columns("CodigoAplicacion").Hidden = True

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("Aplicacion")
        dgvProductos.DisplayLayout.Bands(0).Columns("Aplicacion").Width = 200
        dgvProductos.DisplayLayout.Bands(0).Columns("Aplicacion").CellActivation = Activation.ActivateOnly
        dgvProductos.DisplayLayout.Bands(0).Columns("Aplicacion").CellAppearance.TextHAlign = HAlign.Left
        dgvProductos.DisplayLayout.Bands(0).Columns("Aplicacion").CellAppearance.TextVAlign = HAlign.Center
        dgvProductos.DisplayLayout.Bands(0).Columns("Aplicacion").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Aplicacion").CellAppearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Aplicacion").Header.Appearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Aplicacion").Header.Appearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Aplicacion").Header.Caption = "Aplicación"

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("CodigoActivo")
        dgvProductos.DisplayLayout.Bands(0).Columns("CodigoActivo").Hidden = True

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("Activo")
        dgvProductos.DisplayLayout.Bands(0).Columns("Activo").Width = 150
        dgvProductos.DisplayLayout.Bands(0).Columns("Activo").CellActivation = Activation.ActivateOnly
        dgvProductos.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.TextHAlign = HAlign.Center
        dgvProductos.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.TextVAlign = HAlign.Center
        dgvProductos.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Activo").Header.Appearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Activo").Header.Appearance.FontData.Bold = DefaultableBoolean.False

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("CodigoCantera")
        dgvProductos.DisplayLayout.Bands(0).Columns("CodigoCantera").Hidden = True


        dgvProductos.DisplayLayout.Bands(0).Columns.Add("Cantera")
        If CboArea.Value = 22 Then
            dgvProductos.DisplayLayout.Bands(0).Columns("Cantera").Hidden = True
        Else
            dgvProductos.DisplayLayout.Bands(0).Columns("Cantera").Hidden = False
            dgvProductos.DisplayLayout.Bands(0).Columns("Cantera").Width = 150
            dgvProductos.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.TextHAlign = HAlign.Left
            dgvProductos.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.TextVAlign = HAlign.Center
            dgvProductos.DisplayLayout.Bands(0).Columns("Cantera").CellActivation = Activation.ActivateOnly
            dgvProductos.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.FontData.Bold = DefaultableBoolean.False
            dgvProductos.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.FontData.SizeInPoints = 8
            dgvProductos.DisplayLayout.Bands(0).Columns("Cantera").Header.Appearance.FontData.SizeInPoints = 8
            dgvProductos.DisplayLayout.Bands(0).Columns("Cantera").Header.Appearance.FontData.Bold = DefaultableBoolean.False
        End If

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("Tecnicas")
        dgvProductos.DisplayLayout.Bands(0).Columns("Tecnicas").Width = 150
        dgvProductos.DisplayLayout.Bands(0).Columns("Tecnicas").CellActivation = Activation.ActivateOnly
        dgvProductos.DisplayLayout.Bands(0).Columns("Tecnicas").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Tecnicas").CellAppearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Tecnicas").Header.Appearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Tecnicas").Header.Appearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Tecnicas").Header.Caption = "Descripción" & vbNewLine & "Técnica"

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("Imagenes")
        dgvProductos.DisplayLayout.Bands(0).Columns("Imagenes").Width = 150
        dgvProductos.DisplayLayout.Bands(0).Columns("Imagenes").CellActivation = Activation.ActivateOnly
        dgvProductos.DisplayLayout.Bands(0).Columns("Imagenes").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Imagenes").CellAppearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Imagenes").Header.Appearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Imagenes").Header.Appearance.FontData.Bold = DefaultableBoolean.False

        dgvProductos.DisplayLayout.Bands(0).Columns.Add("Observaciones")
        dgvProductos.DisplayLayout.Bands(0).Columns("Observaciones").Width = 250
        dgvProductos.DisplayLayout.Bands(0).Columns("Observaciones").CellActivation = Activation.ActivateOnly
        dgvProductos.DisplayLayout.Bands(0).Columns("Observaciones").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvProductos.DisplayLayout.Bands(0).Columns("Observaciones").CellAppearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Observaciones").Header.Appearance.FontData.SizeInPoints = 8
        dgvProductos.DisplayLayout.Bands(0).Columns("Observaciones").Header.Appearance.FontData.Bold = DefaultableBoolean.False


    End Sub
#End Region

#End Region                '   Load

    
    Private Sub BtnOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOT.Click
        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_OTs_EnEjecucion
        frmHijo.FechaInput = Me.dtFechaEntrega.Value
        frmHijo.Codigo_Input = Me.CboArea.Value
        frmHijo.ShowDialog()
        Me.TxtOT.Text = frmHijo.Flag2
        Fecha1 = frmHijo.Flag8
        Fecha2 = frmHijo.Flag9

        OrdenTrabajo = frmHijo.ID

        frmHijo = Nothing
    End Sub

    Private Sub DgvListarRequisiciones_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DgvListarRequisiciones.InitializeLayout

    End Sub

    Private Sub CboArea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles CboArea.InitializeLayout

    End Sub
End Class
