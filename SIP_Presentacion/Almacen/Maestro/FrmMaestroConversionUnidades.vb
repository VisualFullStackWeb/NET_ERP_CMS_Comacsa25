Imports SIP_Negocio
Imports SIP_Entidad

Public Class FrmMaestroConversionUnidades

    '   *****   VARIABLES   *****
    Dim Conversion As New List(Of ETProducto)
    Dim conver As ETProducto
    Dim Peso As Decimal = 0
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Load"
    Private Sub FrmMaestroConversionUnidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(CboCia)
        Call ListarUM()
    End Sub
#End Region                '   Load

#Region "Funciones Locales"

#Region "Listar UM"
    Private Sub ListarUM()
        Negocio.Maestros2 = New NGMaestros2

        Cbo_UM.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LUD", "", Now.ToShortDateString, Now)
        Cbo_UM.DisplayMember = "Descripcion"
        Cbo_UM.ValueMember = "UM"
    End Sub
#End Region

#Region "Buscar Peso Producto"
    Public Sub BuscarPeso()
        Dim Peso_Producto As New DataTable
        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodProducto = TxtCodigo.Text
        End With
        Peso_Producto = Negocio.Producto.ListarConversionProducto(Entidad.Producto, "L4")

        If Not IsDBNull(Peso_Producto.Rows(0).Item("Peso")) Then
            Peso = Peso_Producto.Rows(0).Item("Peso")
        End If
    End Sub
#End Region

#Region "Listar Datos Conversion"
    Public Sub ListarDatosConversion(ByVal Producto As String)
        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodProducto = Producto
        End With
        DgvConversionProductos.DataSource = Negocio.Producto.ListarConversionProducto(Entidad.Producto, "L3")

        If DgvConversionProductos.Rows.Count > 0 Then
            TxtCodigoConversion.Text = Trim(DgvConversionProductos.Rows(0).Cells("Codigo").Value & "")
        Else
            TxtCodigoConversion.Clear()
        End If

    End Sub
#End Region

#Region "Validar Grabar"

    Private Function ValidarGrabar() As Boolean
        If DgvConversionProductos.Rows.Count = 0 Then
            MsgBox("NO hay detalle para grabar.", MsgBoxStyle.Critical, "Comacsa")
        End If


        For i As Integer = 0 To DgvConversionProductos.Rows.Count - 1
            If IsDBNull(DgvConversionProductos.Rows(i).Cells("UM_Origen").Value) = True Then
                MsgBox("Elija Unidad de Origen de conversión.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If

            If IsDBNull(DgvConversionProductos.Rows(i).Cells("UM_Destino").Value) = True Then
                MsgBox("Elija Unidad de Destino de conversión.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If

            If IsDBNull(DgvConversionProductos.Rows(i).Cells("Operacion").Value) = True Then
                MsgBox("Elija operación de conversión.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If

            If IsDBNull(DgvConversionProductos.Rows(i).Cells("Entero").Value) = True Then
                MsgBox("Elija si es valor entero.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If

            If IsDBNull(DgvConversionProductos.Rows(i).Cells("Factor").Value) = True Then
                MsgBox("Ingrese factor de conversión  correctamente, mayor a CERO.", MsgBoxStyle.Critical, "Comacsa")
                Return False
            End If
        Next
        Return True
    End Function
#End Region

#End Region   '   Funciones Locales

#Region "Funciones Publicas"

#Region "Buscar"
    Public Sub Buscar()
        Dim Productos As New FrmListarProductos
        gEmpleo = ""
        gAlmacen = "28"
        Productos.ShowDialog()
        TxtCodigo.Text = Trim(Productos.CODIGO & "")
        TxtProducto.Text = Trim(Productos.DESCRIPCION & "")
        Call ListarDatosConversion(Trim(TxtCodigo.Text & ""))
    End Sub
#End Region

#Region "Nuevo"
    Public Sub Nuevo()
        Conversion = New List(Of ETProducto)
        TxtCodigoConversion.Clear()
        TxtCodigo.Clear()
        TxtProducto.Clear()
        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodProducto = Trim(TxtCodigo.Text & "")
            .Cod_Conversion = Trim(TxtCodigoConversion.Text & "")
        End With

    End Sub
#End Region

#Region "Grabar"
    Public Sub Grabar()

        TxtCodigo.Focus()
        If ValidarGrabar() = False Then Return
        If MsgBox("¿Esta seguro de crear las conversiones equivalentes del producto.?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            With Entidad.Producto
                .Cod_Cia = Companhia
                .CodProducto = TxtCodigo.Text
            End With

            For j As Integer = 0 To DgvConversionProductos.Rows.Count - 1
                conver = New ETProducto

                With conver
                    .Cod_Cia = Companhia
                    .CodProducto = Trim(TxtCodigo.Text & "")
                    .User_Crea = User_Sistema
                    .Unidad = DgvConversionProductos.Rows(j).Cells("UM_Origen").Value
                    .UnidadDesp = DgvConversionProductos.Rows(j).Cells("UM_Destino").Value
                    .Factor = DgvConversionProductos.Rows(j).Cells("Factor").Value
                    .Operacion = DgvConversionProductos.Rows(j).Cells("Operacion").Value
                    .Entero = DgvConversionProductos.Rows(j).Cells("Entero").Value
                End With
                Conversion.Add(conver)
            Next

            Entidad.Resultado = Negocio.Producto.ProductoConversion(Entidad.Producto, Conversion)
            Conversion = New List(Of ETProducto)

            If Entidad.Resultado.Realizo = True Then
                MsgBox("Los datos se guardaron correctamente.", MsgBoxStyle.Information, "Comacsa")
            End If

            Call ListarDatosConversion(Trim(TxtCodigo.Text & ""))
        End If

    End Sub
#End Region

#End Region  '   Funciones Publicas

#Region "Evento Controles"

#Region "TxtCodigo - KeyPress"
    Private Sub TxtCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        Select Case Asc(e.KeyChar)
            Case "13"
                Dim Producto As New DataTable

                Entidad.Producto = New ETProducto
                Negocio.Producto = New NGProducto
                With Entidad.Producto
                    .Cod_Cia = Companhia
                    .CodProducto = TxtCodigo.Text
                    .CodAlmacen = "28"
                End With
                Producto = Negocio.Producto.ListarProductos(Entidad.Producto, "LX2")

                If Producto.Rows.Count > 0 Then
                    TxtCodigo.Text = Producto.Rows(0).Item("Codigo")
                    TxtProducto.Text = Producto.Rows(0).Item("Descripcion")
                    Call BuscarPeso()
                Else
                    MsgBox("El código del producto NO existe.", MsgBoxStyle.Critical, "Comacsa")
                    TxtCodigo.Clear()
                    TxtProducto.Clear()
                End If

                Call ListarDatosConversion(Trim(TxtCodigo.Text & ""))
        End Select
    End Sub
#End Region

#Region "TxtCodigo - ValueChanged"
    Private Sub TxtCodigo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigo.ValueChanged
        If Len(TxtCodigo.Text) <> 8 Then
            TxtCodigoConversion.Clear()
            TxtProducto.Clear()
            Call ListarDatosConversion(Trim(TxtCodigo.Text & ""))
        End If
    End Sub
#End Region

#Region "btnGuardar - Click"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If TxtCodigo.Text = "" Then
            MsgBox("Debe Seleccionar el codigo de un Producto", MsgBoxStyle.Critical, "Comacsa")
            Return
        End If

        If MsgBox("¿Esta seguro de crear las conversiones equivalentes del producto?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            Call BuscarPeso()

            With Entidad.Producto
                .Cod_Cia = Companhia
                .CodProducto = TxtCodigo.Text
                .FactorConversion = Peso
                .User_Crea = User_Sistema
            End With

            If Peso > 0 Then
                Entidad.Resultado = Negocio.Producto.ConversionProducto(Entidad.Producto, "L2")
            Else
                Entidad.Resultado = Negocio.Producto.ConversionProducto(Entidad.Producto, "L1")
            End If

            Call ListarDatosConversion(Trim(TxtCodigo.Text & ""))

        End If
    End Sub
#End Region

#End Region    '   Evento Controles

End Class