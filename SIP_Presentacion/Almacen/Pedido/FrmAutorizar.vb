Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Windows.Forms
Imports System.Math
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmAutorizar

    '   *****   VARIABLES   *****
    Dim Codigo As String = ""
    Dim Almacen As String = ""
    Dim Area As String = ""
    Dim Cia As String = ""

    '   *****   LISTAS  *****   
    Dim Pedido As New List(Of ETPedido)
    Dim ped As ETPedido
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Locales"

#Region "Listar Requisicion"
    Private Sub ListarRequisicion()
        With Entidad.Pedido
            .Sistema = gSistema
        End With
        dgvAutorizar1.DataSource = Negocio.PedidoBL.Listar_PedidoAutorizado(Entidad.Pedido, "LA")
    End Sub

#End Region

#Region "Solo Numeros"
    Private Sub SoloNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 13 Or AscW(e.KeyChar) = 8) Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "Abrir Documento Word"
    Private Sub AbrirDocumento(ByVal Ruta As String)
        Dim wordapp As Object
        On Error Resume Next
        wordapp = CreateObject("WORD.APPLICATION")
        wordapp.Documents.Open(FileName:=Ruta, ReadOnly:=True)
        wordapp.Visible = True
    End Sub
#End Region

#Region "Comprobar si el archivo existe"
    Private Function IsFile(ByVal Filename As String) As Boolean
        On Error Resume Next
        IsFile = (GetAttr(Filename) And Not vbDirectory)
    End Function
#End Region

#Region "Validar"
    Private Function Validar() As Boolean
        For m As Integer = 0 To dgvAutorizar3.Rows.Count - 1
            If IsDBNull(dgvAutorizar3.Rows(m).Cells("CantidadAutorizada").Value) = True Then
                MsgBox("Ingrese una Cantidad Autorizada NO puede estar en Blanco.", MsgBoxStyle.Information, "Comacsa")
                Return False
            End If
            If dgvAutorizar3.Rows(m).Cells("CantidadAutorizada").Value = 0 Then
                MsgBox("La Cantidad Autorizada del Producto " + dgvAutorizar3.Rows(m).Cells("Descripcion").Value + " debe ser mayor a 0", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If
        Next

        If Not dgvAutorizar3.Rows.Count > 0 Then
            MsgBox("No hay detalle para AUTORIZAR", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Return True
    End Function
#End Region

#End Region   'Funciones Locales

#Region "Funciones Publicas"

#Region "Grabar"
    Public Sub Grabar()
        If TabAutorizar.Tabs("Autorizar").Selected = True Then
            If Validar() = False Then Return
            TxtNumeroRequisicion.Focus()
            If MsgBox("¿Esta Seguro de AUTORIZAR el Requerimiento ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                Try
                    With Entidad.Pedido
                        .Cod_Cia = Companhia
                        .Tipo_Doc = "RAL"
                        .Numero_Doc = TxtNumeroRequisicion.Text
                        .Fecha = dtFechaEntrega.Value
                        .User = User_Sistema
                        .Estado = "A"
                        If ChkUrgente.Checked = True Then
                            .Urgente = "U"
                        Else
                            .Urgente = "N"
                        End If

                        For n As Integer = 0 To dgvAutorizar3.Rows.Count - 1
                            ped = New ETPedido
                            With ped
                                .Codigo_Producto = dgvAutorizar3.Rows(n).Cells("Codigo").Value
                                .Cantidad_Autorizada = dgvAutorizar3.Rows(n).Cells("CantidadAutorizada").Value
                                .Item = dgvAutorizar3.Rows(n).Cells("Item").Value
                            End With
                            Pedido.Add(ped)
                        Next


                        Entidad.Resultado = Negocio.PedidoBL.GrabarAutorizacion(Entidad.Pedido, Pedido)

                        If Entidad.Resultado.Realizo = True Then
                            MsgBox("La AUTORIZACIÓN del Requerimiento " + .Numero_Doc + " se realizó con éxito.", MsgBoxStyle.Information, "Comacsa")
                            CboArea.Value = 0
                        End If

                        Pedido = New List(Of ETPedido)

                        TabAutorizar.Tabs("Listar").Selected = True
                        Call ListarRequisicion()
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub
#End Region

#Region "Cancelar"
    Public Sub Cancelar()

        If dgvAutorizar1.ActiveRow.Cells("Estado").Value = "AUTORIZADO" Then
            If MsgBox("¿Esta seguro de cancelar la AUTORIZACIÓN de la Requisición.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                Try
                    With Entidad.Pedido
                        .Cod_Cia = Companhia
                        .Tipo_Doc = "RAL"
                        .Numero_Doc = dgvAutorizar1.ActiveRow.Cells("Codigo").Value
                        .Fecha = dtFechaEntrega.Value
                        .User = User_Sistema
                    End With

                    Entidad.Resultado = Negocio.PedidoBL.CancelarAutorizacion(Entidad.Pedido)
                    If Entidad.Resultado.Realizo = True Then
                        MsgBox("La Requisición " + dgvAutorizar1.ActiveRow.Cells("Codigo").Value + " está pendiente.", MsgBoxStyle.Information, "Comacsa")
                    End If
                    TabAutorizar.Tabs("Listar").Selected = True
                    Call ListarRequisicion()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If

    End Sub
#End Region

#Region "Eliminar"
    Public Sub Eliminar()
        If Me.TabAutorizar.Tabs("Listar").Selected = True Then
            If dgvAutorizar1.Rows.Count > 0 Then
                If MsgBox("¿Esta Seguro de ANULAR el registro ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

                    Try
                        With Entidad.Pedido
                            .Cod_Cia = Companhia
                            .Tipo_Doc = "RAL"
                            .Numero_Doc = dgvAutorizar1.ActiveRow.Cells("Codigo").Value
                            .User = User_Sistema
                            Entidad.Resultado = Negocio.PedidoBL.EliminarPedido(Entidad.Pedido)
                            If Entidad.Resultado.Realizo = True Then
                                MsgBox("La ANULACIÓN del documento " + .Numero_Doc + "se realizó con exito", MsgBoxStyle.Information, "Comacsa")
                            End If
                            Call ListarRequisicion()
                        End With
                    Catch ex As Exception

                    End Try

                Else
                    Return
                End If
            End If
        End If
    End Sub
#End Region

#End Region  'Funciones Publicas

#Region "Eventos Controles"

#Region "Grilla dgvAutorizar1 DoubleClickRow"
    Private Sub dgvAutorizar1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvAutorizar1.DoubleClickRow
        If dgvAutorizar1.Rows.Count = 0 Then
            Return
        End If

        Dim Estado As String
        TabAutorizar.Tabs("Autorizar").Enabled = True
        TabAutorizar.Tabs("Autorizar").Selected = True
        dtFechaHoy.Value = Now
        dtFecha.Value = e.Row.Cells("Fecha").Value
        dtFechaEntrega.Value = e.Row.Cells("Entrega").Value
        TxtNumeroRequisicion.Text = e.Row.Cells("Codigo").Value
        TxtUserSolicita.Text = e.Row.Cells("CodigoUsuario").Value
        CboArea.Value = e.Row.Cells("CodigoArea").Value
        Estado = e.Row.Cells("CodigoEstado").Value
        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        TxtOT.Text = e.Row.Cells("Cod_OrdenTrabajo").Value
        If e.Row.Cells("Urgente").Value = "N" Then
            ChkUrgente.Checked = False
        Else
            ChkUrgente.Checked = True
        End If

        If Estado = "P" Then
            LblEstado.Text = "PENDIENTE"
        Else
            LblEstado.Text = "AUTORIZADO"
        End If

        If CboArea.Value = 22 Then
            TxtCodigoCantera.Visible = True
            TxtCantera.Visible = True
            CboContratista.Visible = True
            LblContratista.Visible = True
            LblCantera.Visible = True
            TxtCodigoCantera.Text = Trim(e.Row.Cells("CodigoCantera").Value & "")
            TxtCantera.Text = Trim(e.Row.Cells("Cantera").Value & "")
            Call ContratistaCantera(CboContratista, TxtCodigoCantera.Text, CboArea.Value)
            CboContratista.Value = e.Row.Cells("CodigoProveedor").Value
            TxtNombreSolicita.Text = e.Row.Cells("NombreUsuario").Value
        Else
            TxtCodigoCantera.Visible = False
            TxtCantera.Visible = False
            CboContratista.Visible = False
            LblContratista.Visible = False
            LblCantera.Visible = False
        End If

        With Entidad.Pedido
            .Numero_Doc = TxtNumeroRequisicion.Text
            .Tipo_Doc = "RAL"
            .Cod_Cia = Companhia
        End With

        dgvAutorizar3.DataSource = Negocio.PedidoBL.ListarDetallePedido(Entidad.Pedido, "LA")

        If dgvAutorizar1.ActiveRow.Cells("Estado").Value = "PENDIENTE" Then
            For j As Integer = 0 To dgvAutorizar3.Rows.Count - 1
                dgvAutorizar3.Rows(j).Cells("CantidadAutorizada").Value = dgvAutorizar3.Rows(j).Cells("CantidadSolicitada").Value
            Next
        End If

    End Sub

#End Region

#Region "Grilla dgvAutorizar3 KeyPress "
    Private Sub dgvAutorizar3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvAutorizar3.KeyPress
        Try
            Select Case dgvAutorizar3.ActiveCell.Column.Key
                Case "Tecnicas"
                    Select Case Asc(e.KeyChar)
                        Case 13
                            If IsFile(dgvAutorizar3.ActiveRow.Cells("Tecnicas").Value) = False Then
                                MsgBox("El archivo NO existe", MsgBoxStyle.Information, "Comacsa")
                                Return
                            Else
                                Call AbrirDocumento(dgvAutorizar3.ActiveRow.Cells("Tecnicas").Value)
                            End If
                    End Select

                Case "Imagenes"
                    Select Case Asc(e.KeyChar)
                        Case 13
                            If IsFile(dgvAutorizar3.ActiveRow.Cells("Imagenes").Value) = False Then
                                MsgBox("La imagen NO existe", MsgBoxStyle.Information, "Comacsa")
                                Return
                            Else
                                TabAutorizar.Tabs("Imagen").Selected = True
                                TabAutorizar.Tabs("Imagen").Enabled = True
                                TabAutorizar.Tabs("Listar").Enabled = False
                                TabAutorizar.Tabs("Autorizar").Enabled = False
                                PictureBox1.Load(dgvAutorizar3.ActiveRow.Cells("Imagenes").Value)
                            End If
                    End Select
            End Select
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "TabAutorizar SelectedTabChanged"
    Private Sub TabAutorizar_SelectedTabChanged(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabAutorizar.SelectedTabChanged
        If TabAutorizar.Tabs("Listar").Selected = True Then
            TabAutorizar.Tabs("Autorizar").Enabled = False
            TabAutorizar.Tabs("Imagen").Enabled = False
        End If

        If TabAutorizar.Tabs("Autorizar").Selected = True Then
            TabAutorizar.Tabs("Imagen").Enabled = False
        End If

    End Sub
#End Region

#Region "Boton Close"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        TabAutorizar.Tabs("Autorizar").Selected = True
        TabAutorizar.Tabs("Imagen").Enabled = False
        TabAutorizar.Tabs("Listar").Enabled = True
        TabAutorizar.Tabs("Autorizar").Enabled = True
    End Sub
#End Region

#End Region   'Eventos Controles

#Region "Load"

#Region "Load"
    Private Sub FrmAutorizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabAutorizar.Tabs("Autorizar").Enabled = False
        TabAutorizar.Tabs("Imagen").Enabled = False

        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarArea_General(CboArea)
        Call ListarAlmacen_General(CboAlmacen)
        Call ListarRequisicion()
        dgvAutorizar1.DisplayLayout.Bands(0).Columns("Entrega").CellAppearance.BackColor = Color.Lavender
        dgvAutorizar1.DisplayLayout.Bands(0).Columns("Entrega").CellAppearance.ForeColor = Color.Blue

    End Sub
#End Region

#Region "Efectos"
    Private Sub Efectos()

        dgvAutorizar3.DisplayLayout.Bands(0).ColHeaderLines = 2

        If CboArea.Value <> 22 Then
            dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("CodigoEmpleo")
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("CodigoEmpleo").Hidden = True

            dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("Empleo")
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Empleo").Width = 250
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.TextHAlign = HAlign.Left
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.TextVAlign = HAlign.Center
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Empleo").CellActivation = Activation.ActivateOnly
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.FontData.Bold = DefaultableBoolean.False
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.FontData.SizeInPoints = 8
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Empleo").Header.Appearance.FontData.SizeInPoints = 9
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Empleo").Header.Appearance.FontData.Bold = DefaultableBoolean.True
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.BackColor = Color.Gainsboro
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.ForeColor = Color.Blue
        End If

        dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("Codigo")
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Codigo").Width = 75
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.TextHAlign = HAlign.Center
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.TextVAlign = HAlign.Center
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Codigo").CellActivation = Activation.ActivateOnly
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.FontData.SizeInPoints = 8
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Codigo").Header.Appearance.FontData.SizeInPoints = 9
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Codigo").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Codigo").Header.Caption = "Código"

        dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("Descripcion")
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Descripcion").Width = 250
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Descripcion").CellActivation = Activation.ActivateOnly
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.FontData.SizeInPoints = 8
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.TextVAlign = HAlign.Center
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Descripcion").Header.Appearance.FontData.SizeInPoints = 9
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Descripcion").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción"

        dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("UM")
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("UM").Width = 45
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("UM").CellAppearance.TextHAlign = HAlign.Center
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("UM").CellAppearance.TextVAlign = HAlign.Center
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("UM").CellActivation = Activation.ActivateOnly
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("UM").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("UM").CellAppearance.FontData.SizeInPoints = 8
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("UM").Header.Appearance.FontData.SizeInPoints = 9
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("UM").Header.Appearance.FontData.Bold = DefaultableBoolean.True

        dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("CantidadSolicitada")
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Width = 75
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.BackColor = Color.LemonChiffon
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.ForeColor = Color.Blue
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.TextHAlign = HAlign.Right
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.TextVAlign = HAlign.Center
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellActivation = Activation.ActivateOnly
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.FontData.SizeInPoints = 8
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Format = "n4"
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Header.Appearance.FontData.SizeInPoints = 9
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.BackColor = Color.LemonChiffon
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.ForeColor = Color.Blue
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Header.Caption = "Cantidad" & vbNewLine & "Solicitada"

        dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("CantidadAutorizada")
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").Width = 75
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").CellAppearance.BackColor = Color.LemonChiffon
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").CellAppearance.ForeColor = Color.Blue
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").CellAppearance.TextHAlign = HAlign.Right
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").CellAppearance.TextVAlign = HAlign.Center
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").CellActivation = Activation.ActivateOnly
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").CellAppearance.FontData.SizeInPoints = 8
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").Format = "n4"
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").Header.Appearance.FontData.SizeInPoints = 9
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").CellAppearance.BackColor = Color.LightBlue
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").CellAppearance.ForeColor = Color.Blue
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").Header.Caption = "Cantidad" & vbNewLine & "Autorizada"

        dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("Aplicacion")
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Aplicacion").Width = 200
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Aplicacion").CellActivation = Activation.ActivateOnly
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Aplicacion").CellAppearance.TextHAlign = HAlign.Left
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Aplicacion").CellAppearance.TextVAlign = HAlign.Center
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Aplicacion").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Aplicacion").CellAppearance.FontData.SizeInPoints = 8
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Aplicacion").Header.Appearance.FontData.SizeInPoints = 9
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Aplicacion").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Aplicacion").Header.Caption = "Aplicación"

        If CboArea.Value <> 22 Then
            dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("CodigoCantera")
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("CodigoCantera").Hidden = True

            dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("Cantera")
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Cantera").Width = 150
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.TextHAlign = HAlign.Left
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.TextVAlign = HAlign.Center
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Cantera").CellActivation = Activation.ActivateOnly
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.FontData.Bold = DefaultableBoolean.False
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.FontData.SizeInPoints = 8
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Cantera").Header.Appearance.FontData.SizeInPoints = 9
            dgvAutorizar3.DisplayLayout.Bands(0).Columns("Cantera").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        End If

        dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("CodigoActivo")
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("CodigoActivo").Hidden = True

        dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("Activo")
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Activo").Width = 150
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Activo").CellActivation = Activation.ActivateOnly
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.TextHAlign = HAlign.Center
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.TextVAlign = HAlign.Center
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.FontData.SizeInPoints = 8
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Activo").Header.Appearance.FontData.SizeInPoints = 9
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Activo").Header.Appearance.FontData.Bold = DefaultableBoolean.True

        dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("Tecnicas")
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Tecnicas").Width = 150
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Tecnicas").CellActivation = Activation.ActivateOnly
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Tecnicas").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Tecnicas").CellAppearance.FontData.SizeInPoints = 8
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Tecnicas").Header.Appearance.FontData.SizeInPoints = 9
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Tecnicas").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Tecnicas").Header.Caption = "Descripción" & vbNewLine & "Técnica"

        dgvAutorizar3.DisplayLayout.Bands(0).Columns.Add("Imagenes")
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Imagenes").Width = 150
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Imagenes").CellActivation = Activation.ActivateOnly
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Imagenes").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Imagenes").CellAppearance.FontData.SizeInPoints = 8
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Imagenes").Header.Appearance.FontData.SizeInPoints = 9
        dgvAutorizar3.DisplayLayout.Bands(0).Columns("Imagenes").Header.Appearance.FontData.Bold = DefaultableBoolean.True

    End Sub
#End Region

#End Region                'Load

    Private Sub dgvAutorizar1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvAutorizar1.InitializeLayout

    End Sub
End Class