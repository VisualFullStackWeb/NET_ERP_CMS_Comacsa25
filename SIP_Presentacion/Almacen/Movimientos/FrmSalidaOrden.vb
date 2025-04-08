Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Windows.Forms
Imports System.Math
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmSalidaOrden

    '   *****   VARIABLES   *****
    Dim NumeroSalidaOrdenInterno As String

    '   *****   LISTAS     *****
    Dim DetalleGuia As New List(Of ETGuia)
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Locales"

#Region "Listar Salida Orden"
    Private Sub ListarSalidaOrden()
        With Entidad.Pedido
            .Cod_Cia = Companhia
        End With
        dgvSalidaOrden.DataSource = Negocio.PedidoBL.Listar_SalidaOrden(Entidad.Pedido, "LIS")
    End Sub
#End Region

#Region "Validar Modificar Salida Orden"
    Private Function ValidarModificarSalidaOrden() As Boolean

        If LblEstado.Text <> "EN PROCESO" Then
            MsgBox("NO se puede modificar la Salida x Orden." & vbCrLf & "Su estado es: " & Trim(LblEstado.Text), MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If dgvDetalleSalidaOrden.Rows.Count > 0 Then
            Dim xItem As Integer
            xItem = 0
            For i As Integer = 0 To dgvDetalleSalidaOrden.Rows.Count - 1
                If (dgvDetalleSalidaOrden.Rows(i).Cells("CantidadAtendida").Value > 0) Then
                    xItem = xItem + 1
                End If

                If (dgvDetalleSalidaOrden.Rows(i).Cells("CantidadAtendida").Value > (dgvDetalleSalidaOrden.Rows(i).Cells("Stock").Value + dgvDetalleSalidaOrden.Rows(i).Cells("Cantidad2").Value)) Then
                    MsgBox("La Cantidad Atendida NO puede ser mayor que el Stock para el producto " + dgvDetalleSalidaOrden.Rows(i).Cells("Descripcion").Value, MsgBoxStyle.Critical, "Comacsa")
                    Return False
                End If
            Next

            If xItem = 0 Then
                MsgBox("NO se puede dejar sin atención la Salida x Orden: " & TxtSalidaOrden.Text & vbCrLf & "Caso contrario ANULE la Salida x Orden.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If
        End If
        Return True
    End Function
#End Region

#Region "Validar Stock Salida Orden"
    Private Function ValidarStockSalidaOrden() As Boolean
        Dim Stock As Double
        Dim CantidadAtendida As Double
        Dim Cantidad As Double
        If dgvDetalleSalidaOrden.Rows.Count > 0 Then
            For i As Integer = 0 To dgvDetalleSalidaOrden.Rows.Count - 1
                Stock = dgvDetalleSalidaOrden.Rows(i).Cells("Stock").Value
                CantidadAtendida = dgvDetalleSalidaOrden.Rows(i).Cells("CantidadAtendida").Value
                Cantidad = dgvDetalleSalidaOrden.Rows(i).Cells("Cantidad2").Value
                If CDbl(CantidadAtendida) > (CDbl(Stock) + CDbl(Cantidad)) Then
                    MsgBox("La cantidad Atendida NO puede ser mayor que el STOCK", MsgBoxStyle.Information, "Comacsa")
                    Return False
                End If
            Next
            Return True
        End If
    End Function
#End Region

#Region "validar Atención de Salida x Orden"
    Private Function ValidarAtencionSalidaOrden() As Boolean
        If dgvSalidaOrden.ActiveRow.Cells("Estado").Value = "LISTO PARA RECOJO" Then
            MsgBox("Debe ANULAR la atención para poder modificar.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Validar Anulación de Salida X Orden"
    Private Function ValidarAnulacionSalidaOrden() As Boolean
        If LblEstado.Text = "ENTREGADO" Then
            MsgBox("NO se puede eliminar la Salida x Orden " & Trim(TxtSalidaOrden.Text & "") & " por que ya ha sido ENTREGADO.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        If CboAnulacion.Value = 0 Then
            GrpAnulacion.Visible = True
            MsgBox("Seleccione un motivo para la ANULACIÓN.", MsgBoxStyle.Information, "Comacsa")
            Return False
        End If
        Return True
    End Function
#End Region

#End Region       '   FUNCIONES LOCALES

#Region "Load"

#Region "Load"
    Private Sub FrmSalidaOrden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarArea_General(CboArea)
        Call ListarAlmacenUsuarios(CboAlmacen, "28")
        Call ListarSalidaOrden()
        Call ListarMotivoAnulacion(CboAnulacion)
    End Sub
#End Region

#Region "Efectos"
    Private Sub Efectos()
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).ColHeaderLines = 2

        If CboArea.Value <> 22 Then
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("CodigoEmpleo")
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CodigoEmpleo").Hidden = True

            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("Empleo")
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Empleo").Width = 250
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.TextHAlign = HAlign.Left
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.TextVAlign = HAlign.Center
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Empleo").CellActivation = Activation.ActivateOnly
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.FontData.Bold = DefaultableBoolean.False
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.FontData.SizeInPoints = 8
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Empleo").Header.Appearance.FontData.SizeInPoints = 9
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Empleo").Header.Appearance.FontData.Bold = DefaultableBoolean.True
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.BackColor = Color.Gainsboro
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Empleo").CellAppearance.ForeColor = Color.Blue

        End If

        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("Codigo")
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Codigo").Width = 75
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.TextHAlign = HAlign.Center
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.TextVAlign = HAlign.Center
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Codigo").CellActivation = Activation.ActivateOnly
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Codigo").CellAppearance.FontData.SizeInPoints = 8
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Codigo").Header.Appearance.FontData.SizeInPoints = 9
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Codigo").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Codigo").Header.Caption = "Código"

        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("Descripcion")
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Descripcion").Width = 250
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Descripcion").CellActivation = Activation.ActivateOnly
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.FontData.SizeInPoints = 8
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Descripcion").CellAppearance.TextVAlign = HAlign.Center
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Descripcion").Header.Appearance.FontData.SizeInPoints = 9
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Descripcion").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción"

        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("UM")
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("UM").Width = 45
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("UM").CellAppearance.TextHAlign = HAlign.Center
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("UM").CellAppearance.TextVAlign = HAlign.Center
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("UM").CellActivation = Activation.ActivateOnly
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("UM").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("UM").CellAppearance.FontData.SizeInPoints = 8
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("UM").Header.Appearance.FontData.SizeInPoints = 9
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("UM").Header.Appearance.FontData.Bold = DefaultableBoolean.True

        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("Stock")
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").Width = 75
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").CellAppearance.BackColor = Color.LemonChiffon
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").CellAppearance.ForeColor = Color.Blue
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").CellAppearance.TextHAlign = HAlign.Right
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").CellAppearance.TextVAlign = HAlign.Center
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").CellActivation = Activation.ActivateOnly
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").CellAppearance.FontData.SizeInPoints = 8
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").Format = "n4"
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").Header.Appearance.FontData.SizeInPoints = 9
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").CellAppearance.BackColor = Color.LemonChiffon
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").CellAppearance.ForeColor = Color.Blue
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").Header.Caption = "Stock"
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").CellAppearance.BackColor = Color.NavajoWhite
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Stock").CellAppearance.ForeColor = Color.Blue

        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("CantidadSolicitada")
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Width = 75
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.BackColor = Color.LemonChiffon
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.ForeColor = Color.Blue
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.TextHAlign = HAlign.Right
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.TextVAlign = HAlign.Center
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellActivation = Activation.ActivateOnly
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.FontData.SizeInPoints = 8
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Format = "n4"
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Header.Appearance.FontData.SizeInPoints = 9
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.BackColor = Color.LemonChiffon
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.ForeColor = Color.Blue
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").Header.Caption = "Cantidad" & vbNewLine & "Solicitada"
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.BackColor = Color.LemonChiffon
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.ForeColor = Color.Blue

        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("CantidadAtendida")
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").Width = 75
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.BackColor = Color.LemonChiffon
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.ForeColor = Color.Blue
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.TextHAlign = HAlign.Right
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.TextVAlign = HAlign.Center
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.FontData.SizeInPoints = 8
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").Format = "n4"
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").Header.Appearance.FontData.SizeInPoints = 9
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.BackColor = Color.LightBlue
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.ForeColor = Color.Blue
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").Header.Caption = "Cantidad" & vbNewLine & "Atendida"
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.BackColor = Color.LightCyan
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.ForeColor = Color.Blue

        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("Cantidad2")
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Cantidad2").Hidden = True

        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("CodigoActivo")
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CodigoActivo").Hidden = True

        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("Activo")
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Activo").Width = 150
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Activo").CellActivation = Activation.ActivateOnly
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.TextHAlign = HAlign.Center
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.TextVAlign = HAlign.Center
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Activo").CellAppearance.FontData.SizeInPoints = 8
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Activo").Header.Appearance.FontData.SizeInPoints = 9
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Activo").Header.Appearance.FontData.Bold = DefaultableBoolean.True

        If CboArea.Value <> 22 Then
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("CodigoCantera")
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("CodigoCantera").Hidden = True

            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("Cantera")
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Cantera").Width = 150
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.TextHAlign = HAlign.Left
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.TextVAlign = HAlign.Center
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Cantera").CellActivation = Activation.ActivateOnly
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.FontData.Bold = DefaultableBoolean.False
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Cantera").CellAppearance.FontData.SizeInPoints = 8
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Cantera").Header.Appearance.FontData.SizeInPoints = 9
            dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Cantera").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        End If

        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns.Add("Observacion")
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Observacion").Width = 200
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Observacion").CellActivation = Activation.ActivateOnly
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Observacion").CellAppearance.FontData.Bold = DefaultableBoolean.False
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Observacion").CellAppearance.FontData.SizeInPoints = 8
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Observacion").CellAppearance.TextVAlign = HAlign.Center
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Observacion").Header.Appearance.FontData.SizeInPoints = 9
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Observacion").Header.Appearance.FontData.Bold = DefaultableBoolean.True
        dgvDetalleSalidaOrden.DisplayLayout.Bands(0).Columns("Observacion").Header.Caption = "Observaciones"

    End Sub
#End Region

#End Region                    '   LOAD

#Region "Eventos Controles"

#Region "DgvSalidaOrden - DoubleClickRow"
    Private Sub dgvSalidaOrden_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvSalidaOrden.DoubleClickRow

        If e Is Nothing Then
            Exit Sub
        End If
        If dgvSalidaOrden.Rows.Count = 0 Then
            Return
        End If

        With Entidad.Pedido
            .Cod_Cia = Companhia
            .SalidaOrden = e.Row.Cells("SalidaOrden").Value
            .Codigo_Almacen = e.Row.Cells("CodigoAlmacen").Value
        End With

        dgvDetalleSalidaOrden.DataSource = Negocio.PedidoBL.ListarDetallePedido(Entidad.Pedido, "DS")

        If dgvDetalleSalidaOrden.Rows.Count > 0 Then
            TabSalidaOrden.Tabs("Detalle").Selected = True
            TxtRequisicionSalidaOrden.Text = e.Row.Cells("Requisicion").Value
            TxtSalidaOrden.Text = e.Row.Cells("SalidaOrden").Value
            FeStringegistro.Value = e.Row.Cells("Fecha").Value
            FechaEntrega.Value = e.Row.Cells("Entrega").Value
            CodigoUserSolicita.Text = e.Row.Cells("CodigoUsuario").Value
            UserSolicita.Text = e.Row.Cells("NombreUsuario").Value
            CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
            CboArea.Value = e.Row.Cells("CodigoArea").Value
            CodigoCantera.Text = Trim(e.Row.Cells("CodigoCantera").Value & "")
            Cantera.Text = Trim(e.Row.Cells("Cantera").Value & "")
            LblEstado.Text = Trim(e.Row.Cells("Estado").Value & "")

            Call ContratistaCantera(CboContratista, CodigoCantera.Text, CboArea.Value)
            CboContratista.Value = e.Row.Cells("Proveedor").Value
        Else
            MsgBox("NO hay detalle para mostrar.", MsgBoxStyle.Critical, "Comacsa")
        End If

        If CboArea.Value = 22 Then
            CodigoCantera.Visible = True
            Cantera.Visible = True
            CboContratista.Visible = True
            LblContratista.Visible = True
            LblCantera.Visible = True
        Else
            CodigoCantera.Visible = False
            Cantera.Visible = False
            CboContratista.Visible = False
            LblContratista.Visible = False
            LblCantera.Visible = False

        End If

    End Sub
#End Region

#Region "TabSalidaOrden - SelectedTabChanged"
    Private Sub TabSalidaOrden_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabSalidaOrden.SelectedTabChanged
        If TabSalidaOrden.Tabs("Detalle").Selected = True Then
            TabSalidaOrden.Tabs("Detalle").Enabled = True
        Else
            TabSalidaOrden.Tabs("Detalle").Enabled = False
            GrpAnulacion.Visible = False
        End If
    End Sub
#End Region

#End Region       '   EVENTOS CONTROLES

#Region "Funciones Globales"

#Region "Grabar"
    Public Sub Grabar()
        Dim listDetSalOrden As New List(Of ETPedido)
        Dim SalOrden As ETPedido = Nothing
        Dim i As Integer = 0
        dgvDetalleSalidaOrden.UpdateData()
        If ValidarAtencionSalidaOrden() = False Then Return
        If MsgBox("¿Esta seguro de ATENDER la Salida x Orden " & TxtSalidaOrden.Text & " ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            With Entidad.Pedido
                .Cod_Cia = Companhia
                .SalidaOrden = dgvSalidaOrden.ActiveRow.Cells("SalidaOrden").Value
                .Numero_Doc = TxtRequisicionSalidaOrden.Text
                .User = User_Sistema
            End With


            For i = 0 To dgvDetalleSalidaOrden.Rows.Count - 1
                SalOrden = New ETPedido
                With SalOrden
                    .Cod_Cia = Companhia
                    .SalidaOrden = dgvSalidaOrden.ActiveRow.Cells("SalidaOrden").Value
                    .Tipo_Doc = "SO"
                    .Tipo_Mov = dgvDetalleSalidaOrden.ActiveRow.Cells("Tipo_Mov").Value
                    .Codigo_Producto = dgvDetalleSalidaOrden.Rows(i).Cells("Codigo").Value
                    .Cantidad_Atendida = dgvDetalleSalidaOrden.Rows(i).Cells("CantidadAtendida").Value
                    .Observaciones = dgvDetalleSalidaOrden.Rows(i).Cells("Observacion").Value
                    .Item = dgvDetalleSalidaOrden.Rows(i).Cells("Item").Value
                    .User = User_Sistema
                End With
                listDetSalOrden.Add(SalOrden)
            Next

            Entidad.Resultado = Negocio.PedidoBL.Grabar_SalidaOrden(Entidad.Pedido, listDetSalOrden)

            If Entidad.Resultado.Realizo = True Then
                MsgBox("La ATENCIÓN de la Salida x Orden " & dgvSalidaOrden.ActiveRow.Cells("SalidaOrden").Value & " se realizó con éxito.", MsgBoxStyle.Information, "Comacsa")
            End If

            TabSalidaOrden.Tabs("Listar").Selected = True
            Call ListarSalidaOrden()

        End If

    End Sub

#End Region

#Region "Reporte"
    Public Sub Reporte()

        Dim Reporte As New Rpt_SalidaAlmacen
        StrucForm.FxSalidaOrden = New Rpt_SalidaAlmacen
        gDocumentoAtender = dgvSalidaOrden.ActiveRow.Cells("Requisicion").Value
        gDocumentoSalidaOrden = dgvSalidaOrden.ActiveRow.Cells("SalidaOrden").Value
      
        StrucForm.FxSalidaOrden.NombreReporte = "Salida x Orden [" & Trim(dgvSalidaOrden.ActiveRow.Cells("SalidaOrden").Value) & "]"
        StrucForm.FxSalidaOrden.MdiParent = MdiParent
        StrucForm.FxSalidaOrden.Show()

    End Sub
#End Region

#Region "Eliminar"
    Public Sub Eliminar()
        If TabSalidaOrden.Tabs("Detalle").Selected = True Then
            If ValidarAnulacionSalidaOrden() = False Then Return
            If MsgBox("¿Esta seguro de ANULAR la Salida x Orden " & TxtSalidaOrden.Text & " ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                With Entidad.Guia
                    .Cod_Cia = Companhia
                    .NumDoc = Trim(TxtSalidaOrden.Text & "")
                    .Motivo = CboAnulacion.Value
                    .User_Crea = User_Sistema
                    .Tipo_Doc = "SO"
                    .Tipo_Mov = "18"
                End With
                Entidad.Resultado = Negocio.Guia.EliminarMovimiento(Entidad.Guia, DetalleGuia)

                If Entidad.Resultado.Realizo = True Then
                    MsgBox("La anulación de la Salida x Orden " & Trim(TxtSalidaOrden.Text & "") & " se realizó con éxito.", MsgBoxStyle.Information, "Comacsa")
                End If

                DetalleGuia = New List(Of ETGuia)


                TabSalidaOrden.Tabs("Listar").Selected = True
                Call ListarSalidaOrden()
                CboAnulacion.Value = 0
            End If
        End If

    End Sub
#End Region

#End Region      '   FUNCIONES GLOBALES

    Private Sub dgvSalidaOrden_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvSalidaOrden.InitializeLayout

    End Sub

    Private Sub dgvDetalleSalidaOrden_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalleSalidaOrden.InitializeLayout

    End Sub
End Class