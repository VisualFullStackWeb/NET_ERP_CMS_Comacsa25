Imports SIP_Negocio
Imports SIP_Entidad
Imports Infragistics.Win.UltraWinGrid

Public Class frmSeleccionGuia    
    Private _NroGuia As String
    Public Property NroGuia() As String
        Get
            Return _NroGuia
        End Get
        Set(ByVal value As String)
            _NroGuia = value
        End Set
    End Property

    Private _dtCabGuia As DataTable
    Public Property dtCabGuia() As DataTable
        Get
            Return _dtCabGuia
        End Get
        Set(ByVal value As DataTable)
            _dtCabGuia = value
        End Set
    End Property

    Private _dtDetGuia As DataTable
    Public Property dtDetGuia() As DataTable
        Get
            Return _dtDetGuia
        End Get
        Set(ByVal value As DataTable)
            _dtDetGuia = value
        End Set
    End Property

    Private _ClienteCodigo As String
    Public Property ClienteCodigo() As String
        Get
            Return _ClienteCodigo
        End Get
        Set(ByVal value As String)
            _ClienteCodigo = value
        End Set
    End Property

    Private _Cliente As String
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

    Private _ListaDetallesProducto As List(Of ETReclamoProductoDetalle)
    Public Property ListaDetallesProducto() As List(Of ETReclamoProductoDetalle)
        Get
            Return _ListaDetallesProducto
        End Get
        Set(ByVal value As List(Of ETReclamoProductoDetalle))
            _ListaDetallesProducto = value
        End Set
    End Property



    Private Sub frmSeleccionGuia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' iniciamos la tabla
        dtDetGuia = New DataTable("DET_GUIA")
        dtDetGuia.Columns.Add("NRO_FACT", GetType(String))
        dtDetGuia.Columns.Add("NRO_GUIA", GetType(String))
        dtDetGuia.Columns.Add("FECHA", GetType(DateTime))
        dtDetGuia.Columns.Add("COD_PRODUCTO", GetType(String))
        dtDetGuia.Columns.Add("PRODUCTO", GetType(String))
        dtDetGuia.Columns.Add("UNIDAD", GetType(String))
        dtDetGuia.Columns.Add("LOTE", GetType(String))
        dtDetGuia.Columns.Add("NRO_BOLSAS", GetType(String))
        dtDetGuia.Columns.Add("NRO_BOLSAS_RECLAMADAS", GetType(String))
        dtDetGuia.Columns.Add("CANT_ING", GetType(Decimal))
        dtDetGuia.Columns.Add("CANT_DESP", GetType(Decimal))
        dtDetGuia.Columns.Add("CANT_FACT", GetType(Decimal))

        ugDetGuia.DataSource = dtDetGuia
        ugDetGuia.DataBind()

        txtClienteCodigo.Text = _ClienteCodigo
        txtCliente.Text = _Cliente

        dtpFin.Value = DateTime.Now.Date
        dtpInicio.Value = DateTime.Now.Date



    End Sub

    Sub ConfigurarGridGuias()
        Dim band As UltraGridBand = ugDetGuia.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2

        band.Columns("COD_PRODUCTO").Width = 100
        band.Columns("COD_PRODUCTO").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("COD_PRODUCTO").Header.Caption = "CODIGO." & Environment.NewLine & "PRODUCTO"

        band.Columns("PRODUCTO").Width = 250
        band.Columns("PRODUCTO").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("PRODUCTO").Header.Caption = "PRODUCTO"

        band.Columns("NRO_BOLSAS").Width = 130
        band.Columns("NRO_BOLSAS").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("NRO_BOLSAS").Header.Caption = "CANTIDAD BOLSAS" & Environment.NewLine & "VENDIDAS"

        band.Columns("CANT_FACTURADA").Width = 100
        band.Columns("CANT_FACTURADA").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("CANT_FACTURADA").Header.Caption = "CANTIDAD" & Environment.NewLine & "FACTURADA"

        band.Columns("COD_PRODUCCION").Width = 120
        band.Columns("COD_PRODUCCION").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("COD_PRODUCCION").Header.Caption = "CODIGO." & Environment.NewLine & "PRODUCCIÓN"

    End Sub

    Sub BuscarDocumento()
        Try
            Dim dsSource As DataSet = BuscarGuiaPorNro(txtNroGuia.Text.Trim(), _
                                                       txtNroFactura.Text.Trim(), _
                                                       txtClienteCodigo.Text.Trim(), _
                                                       chkFechas.Checked, _
                                                       dtpInicio.Value.Date, _
                                                       dtpFin.Value.Date)

            If dsSource.Tables(0).Rows.Count = 0 Then
                MsgBox("El Nro de documento no existe", MsgBoxStyle.OkOnly, msgComacsa)
                Return
            End If

            ugDetGuia.DataSource = dsSource.Tables(1)
            ugDetGuia.DataBind()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, msgComacsa)
        End Try
    End Sub
    Private Sub txtNroGuia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroGuia.KeyDown, txtNroFactura.KeyDown
        If e.KeyCode = Keys.Enter Then
            BuscarDocumento()
        End If
    End Sub

    Public Function BuscarGuiaPorNro(ByVal NroGuia As String, ByVal NroFact As String, _
                                     ByVal CodCli As String, ByVal PorFechas As Boolean, ByVal Inicio As DateTime, ByVal Fin As DateTime) As DataSet

        Dim NReclamo As New NGReclamo
        Dim dsSource As DataSet = NReclamo.ObtenerGuia(NroGuia, NroFact, CodCli, PorFechas, Inicio, Fin)
        Return dsSource
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        ugDetGuia.UpdateData()

        Dim dt As DataTable = TryCast(ugDetGuia.DataSource, DataTable)

        If dt IsNot Nothing Then
            ListaDetallesProducto = New List(Of ETReclamoProductoDetalle)
            Dim oProductoDetalle As ETReclamoProductoDetalle = Nothing

            For Each row As DataRow In dt.Rows
                If Convert.ToBoolean(row("SELECCIONAR")) Then
                    oProductoDetalle = New ETReclamoProductoDetalle
                    oProductoDetalle.NRO_FACT = row("NRO_FACT").ToString().Trim()
                    oProductoDetalle.NRO_GUIA = row("NRO_GUIA").ToString().Trim()
                    oProductoDetalle.FECHA = Convert.ToDateTime(row("FECHA"))
                    oProductoDetalle.COD_PRODUCTO = row("COD_PRODUCTO").ToString().Trim()
                    oProductoDetalle.PRODUCTO = row("PRODUCTO").ToString().Trim()
                    oProductoDetalle.UNIDAD = row("UNIDAD").ToString().Trim()
                    oProductoDetalle.CANT_FACTURADA = Convert.ToDecimal(row("CANT_FACT"))
                    oProductoDetalle.CANT_INGRESADA = Convert.ToDecimal(row("CANT_ING"))
                    oProductoDetalle.LOTE = row("LOTE").ToString().Trim()
                    oProductoDetalle.NRO_BOLSAS = row("NRO_BOLSAS").ToString().Trim()
                    oProductoDetalle.NRO_BOLSAS_RECLAMADAS = row("NRO_BOLSAS_RECLAMADAS").ToString().Trim()
                    ListaDetallesProducto.Add(oProductoDetalle)
                End If
            Next
        End If

        If ListaDetallesProducto.Count = 0 Then
            If MessageBox.Show("¿No ha seleccionado ninguna guìa , esta seguro de salir?", _
                            msgComacsa, MessageBoxButtons.YesNo, _
                            MessageBoxIcon.Question, _
                            MessageBoxDefaultButton.Button1, _
                            MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

    End Sub

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged


        Dim dt As DataTable = TryCast(ugDetGuia.DataSource, DataTable)

        If dt IsNot Nothing Then
            For Each row As DataRow In dt.Rows
                row("SELECCIONAR") = chkTodos.Checked
            Next
        End If


    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarDocumento()
    End Sub


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub chkFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFechas.CheckedChanged
        gbFechas.Enabled = chkFechas.Checked
    End Sub
End Class
