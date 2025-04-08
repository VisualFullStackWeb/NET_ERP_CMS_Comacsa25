Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmListarProductos

    '   *****   VARIABLES   *****                                               
    Public CODIGO As String = ""
    Public DESCRIPCION As String = ""
    Public UNIDADMEDIDA As String = ""
    Public UMCOMPRA As String = ""
    Public STOCK As String
    Public TIPO_PRODUCTO As String = ""
    Public COD_CANTERA As String = ""


#Region "Load"
    Private Sub FrmListarProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarProductos()
        TxtDescripcion.SelectAll()
    End Sub
#End Region                'Load

#Region "Eventos Controles"

#Region "Grilla DgvListaProductos DoubleClickRow "
    Private Sub DgvListaProductos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvListaProductos.DoubleClickRow

        CODIGO = Trim(e.Row.Cells("Codigo").Value & "")
        DESCRIPCION = Trim(e.Row.Cells("Descripcion").Value & "")
        UNIDADMEDIDA = Trim(e.Row.Cells("UM").Value & "")

        If Not (xFormulario = "Lista_Precio_FletexMineral" Or xFormulario = "Cantera_Contratista") Then
            UMCOMPRA = Trim(e.Row.Cells("UMCOMPRA").Value & "")
            STOCK = Trim(e.Row.Cells("STOCK").Value & "")
            TIPO_PRODUCTO = Trim(e.Row.Cells("TipoProducto").Value & "")
        End If


        gAlmacen = ""
        Close()
    End Sub
#End Region

#Region "BtNuevo - Click"
    Private Sub BtNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNuevo.Click
        DgvListaProductos.Visible = False
        GrpProductoNuevo.Visible = True
    End Sub
#End Region

#Region "BtnGuardar - Click"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Validar() = False Then Return
        CODIGO = Trim(TxtCodigo.Text & "")
        DESCRIPCION = Trim(TxtDescripcion.Text & "")
        UNIDADMEDIDA = CmbUM.Value
        UMCOMPRA = CmbUM.Value
        STOCK = CDbl(Trim(TxtStock.Value & ""))
        gAlmacen = ""
        Close()
    End Sub
#End Region

#Region "BtnSalir - Click"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        DgvListaProductos.Visible = True
        GrpProductoNuevo.Visible = False
    End Sub
#End Region

#Region "TxtCodigoProducto - ValueChanged"
    Private Sub TxtCodigoProducto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoProducto.ValueChanged
        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodProducto = Trim(TxtCodigoProducto.Text & "")
            .CodAlmacen = gAlmacen
            .Empleo = gEmpleo
        End With

        If gEmpleo = "" Then
            DgvListaProductos.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "LX1C")
            BtNuevo.Visible = False
        Else
            DgvListaProductos.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "LIS1")
            BtNuevo.Visible = True
        End If
    End Sub
#End Region

#Region "TxtDescripcionProducto - ValueChanged"
    Private Sub TxtDescripcionProducto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcionProducto.ValueChanged
        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodAlmacen = gAlmacen
            .Empleo = gEmpleo
            .Descripcion = Trim(TxtDescripcionProducto.Text & "")
        End With

        If gEmpleo = "" Then
            DgvListaProductos.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "LX1D")
            BtNuevo.Visible = False
        Else
            DgvListaProductos.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "LIS2")
            BtNuevo.Visible = True
        End If
    End Sub
#End Region

#End Region   'Eventos Controles

#Region "Funciones Locales"

#Region "Listar UM"
    Private Sub ListarUM()
        CmbUM.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LUD", "", Now.ToShortDateString, Now)
        CmbUM.DisplayMember = "Descripcion"
        CmbUM.ValueMember = "UM"
    End Sub
#End Region

#Region "Cargar Tabla"
    Private Sub CargarTabla()
        Dim ds As New DataSet

        Dim dx As New DataTable
        Dim dz As New DataTable

        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodAlmacen = gAlmacen
            .Empleo = gEmpleo
            .CodProducto = Trim(DgvListaProductos.ActiveRow.Cells("Codigo").Value & "")
        End With

        dx = Negocio.Producto.ListarProductos(Entidad.Producto, "LIS")
        dz = Negocio.Producto.ListarProductos(Entidad.Producto, "LPS")

        dx.TableName = "PADRE"
        dz.TableName = "HIJO"

        ds.Tables.Add(dx)
        ds.Tables.Add(dz)


        Dim Producto As DataColumn = ds.Tables("PADRE").Columns("Codigo")
        Dim ProductoSustituto As DataColumn = ds.Tables("HIJO").Columns("CodigoProducto")

        ' Create DataRelation.
        Dim Productos As DataRelation
        Productos = New DataRelation("CustomersOrders", Producto, ProductoSustituto)

        ' Add the relation to the DataSet.
        ds.Relations.Add(Productos)

        DgvListaProductos.DataSource = ds

    End Sub
#End Region

#Region "Validar"
    Private Function Validar() As Boolean
        If TxtDescripcion.Text = "" Then
            MsgBox("Debe escribir la descripción del producto.", MsgBoxStyle.Critical, "Comacsa")
            TxtDescripcion.Focus()
            Return False
        End If

        If CmbUM.SelectedIndex = -1 Then
            MsgBox("Debe escribir la unidad de medida del producto.", MsgBoxStyle.Critical, "Comacsa")
            CmbUM.Focus()
            Return False
        End If

        If TxtStock.Value = 0 Then
            MsgBox("Debe escribir una cantidad mayor a 0", MsgBoxStyle.Critical, "Comacsa")
            TxtStock.Focus()
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Listar Productos"
    Public Sub ListarProductos()
        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodAlmacen = gAlmacen
            .Cod_Cantera = COD_CANTERA
            .Empleo = gEmpleo
        End With

        If xFormulario <> "" Then
            If xFormulario = "Cantera_Combustible" Then
                DgvListaProductos.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "UNO")
                BtNuevo.Visible = False
            ElseIf xFormulario = "Cantera_Explosivo" Then
                DgvListaProductos.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "DOS")
                BtNuevo.Visible = False
            ElseIf xFormulario = "Lista_Precio_FletexMineral" Or xFormulario = "Cantera_Contratista" Then
                DgvListaProductos.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "MIN")
                BtNuevo.Visible = False
            End If
        Else

            If gEmpleo = "" Then
                DgvListaProductos.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "LX1")
                BtNuevo.Visible = False
            Else
                DgvListaProductos.DataSource = Negocio.Producto.ListarProductos(Entidad.Producto, "LIS")
                BtNuevo.Visible = True
            End If

        End If


        Call ListarUM()
    End Sub
#End Region

#End Region   'Funciones Locales

    Private Sub DgvListaProductos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DgvListaProductos.InitializeLayout
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If xFormulario = "Lista_Precio_FletexMineral" Or xFormulario = "Cantera_Contratista" Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" Or uColumn.Key = "Descripcion" Or _
                        uColumn.Key = "UMCompra" Or uColumn.Key = "UM" Or _
                        uColumn.Key = "Origen") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        Else
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" Or uColumn.Key = "Descripcion" Or _
                        uColumn.Key = "UMCompra" Or uColumn.Key = "UM" Or _
                        uColumn.Key = "Stock") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

    End Sub
End Class