Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmDatosAuxiliares

    '   *****   VARIABLES   *****
    Dim Productos As New DataTable
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Publicas"

#Region "Consultar"
    Public Sub Procesar()
        Call ListarProductosAlmacen()
    End Sub
#End Region

#End Region  'Funciones Publicas

#Region "Funciones Locales"

#Region "Listar Productos"
    Private Sub ListarProductosAlmacen()
        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodAlmacen = CboAlmacen.Value
        End With
        Productos = Negocio.Producto.ListarProductos(Entidad.Producto, "LX3")
        DgvListarProductos.DataSource = Productos
    End Sub
#End Region

#End Region   'Funciones Locales

#Region "Eventos Controles"

#Region "DgvListarProductos - DoubleClickRow"
    Private Sub DgvListarProductos_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvListarProductos.DoubleClickRow
        TabProductos.Tabs("Datos").Selected = True
        TxtCodigo.Text = Trim(e.Row.Cells("Codigo").Value & "")
        TxtDescripcion.Text = Trim(e.Row.Cells("Descripcion").Value & "")
        TxtUM.Text = Trim(e.Row.Cells("UM").Value & "")

        LstDet.Items.Clear()
        LblDetalleMensaje.Text = ""
        LstDet.Items.Add("Promedio de Consumo Mensual")
        LstDet.Items.Add("Consumo del Area en los 2 últimos Años")
        LstDet.Items.Add("Consumo de todas las Areas en los últimos 2 años")
        LstDet.Items.Add("Ultimo proveedor al que se le compró")
        LstDet.Items.Add("Dias que se demoró en su último pedido")
        LstDet.Items.Add("Ultimo despacho que se solicitó en el Area")
        LstDet.Items.Add("Stock del Mes anterior")
        LstDet.Items.Add("Consumo del Mes")
        LstDet.Items.Add("Ingreso del Mes")
        LstDet.Items.Add("Stock Actual")
        LstDet.Items.Add("Ultimo Pedido que se solicitó en el Area")
        LstDet.Items.Add("Número de Requerimientos de Compra en el mes")
        LstDet.SelectedIndex = 0

    End Sub
#End Region

#Region "LstDet - DoubleClick"
    Private Sub LstDet_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstDet.DoubleClick
        Dim DtMensaje As New DataTable
        Dim Cantidad As Decimal
        Dim xFechaInicio As DateTime
        Dim xFechaFin As DateTime
        Dim xMes As String
        Dim año As Integer
        Dim Mes As String
        Dim Mov As String
        Dim Doc As String
        Dim Tipo As String

        Select Case LstDet.SelectedIndex
            Case 0  '   Promedio de Consumo Mensual
                Entidad.Requerimiento = New ETRequerimiento
                Negocio.Requerimiento = New NGRequerimiento
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CboAlmacen.Value
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigo.Text & "")
                    .Unidad = TxtUM.Text
                    .Ano = Year(Now)
                End With
                DtMensaje = Negocio.Requerimiento.ListarPromedioConsumoMensual(Entidad.Requerimiento)

                If DtMensaje.Rows.Count > 0 Then
                    If IsDBNull(DtMensaje.Rows(0).Item("Cantidad")) = True Then
                        Cantidad = 0
                    Else
                        Cantidad = DtMensaje.Rows(0).Item("Cantidad")
                    End If
                    LblDetalleMensaje.Text = "Promedio del Consumo Mensual: " & (Cantidad / 12)
                Else
                    LblDetalleMensaje.Text = "Promedio del Consumo Mensual: 0"
                End If

            Case 1  '   Consumo del Area en los 2 últimos Años
                Entidad.Requerimiento = New ETRequerimiento
                Negocio.Requerimiento = New NGRequerimiento
                If CboArea.Value = 0 Then
                    MsgBox("Debe seleccionar un área de consulta.", MsgBoxStyle.Critical, "Comacsa")
                    CboArea.Focus()
                    Return
                End If

                xFechaInicio = Now
                xFechaFin = DateAdd(DateInterval.Year, -2, Now.Date)


                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CboAlmacen.Value
                    .Area = CboArea.Value
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigo.Text & "")
                    .Unidad = Trim(TxtUM.Text & "")
                    .Inicio = xFechaInicio
                    .Fin = xFechaFin
                End With
                DtMensaje = Negocio.Requerimiento.ConsumoAreaUltimosAños(Entidad.Requerimiento)

                If DtMensaje.Rows.Count > 0 Then
                    If IsDBNull(DtMensaje.Rows(0).Item("Cantidad")) = True Then
                        Cantidad = 0
                    Else
                        Cantidad = DtMensaje.Rows(0).Item("Cantidad")
                    End If
                    LblDetalleMensaje.Text = "Consumo del Area: " & Cantidad
                End If

            Case 2  '   Consumo de todas las Areas en los últimos 2 años
                Entidad.Requerimiento = New ETRequerimiento
                Negocio.Requerimiento = New NGRequerimiento
                xFechaInicio = Now
                xFechaFin = DateAdd(DateInterval.Year, -2, Now.Date)

                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CboAlmacen.Value
                    .Area = ""
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigo.Text & "")
                    .Unidad = Trim(TxtUM.Text & "")
                    .Inicio = xFechaInicio
                    .Fin = xFechaFin
                End With
                DtMensaje = Negocio.Requerimiento.ConsumoAreaUltimosAños(Entidad.Requerimiento)

                If DtMensaje.Rows.Count > 0 Then

                    If IsDBNull(DtMensaje.Rows(0).Item("Cantidad")) = True Then
                        Cantidad = 0
                    Else
                        Cantidad = DtMensaje.Rows(0).Item("Cantidad")
                    End If

                    LblDetalleMensaje.Text = "Consumo Total: " & Cantidad
                End If

            Case 3  '   Ultimo proveedor al que se le compró
                Entidad.Requerimiento = New ETRequerimiento
                Negocio.Requerimiento = New NGRequerimiento
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CboAlmacen.Value
                    .CodigoProducto = Trim(TxtCodigo.Text & "")
                End With
                DtMensaje = Negocio.Requerimiento.UltimoProveedorCompra(Entidad.Requerimiento)


                If DtMensaje.Rows.Count > 0 Then
                    LblDetalleMensaje.Text = "Proveedor: " & Trim(DtMensaje.Rows(0).Item("RAZSOC") & "") & vbCrLf _
                                            & "Cantidad: " & Trim(DtMensaje.Rows(0).Item("CANT_ING")) & vbCrLf _
                                            & "Precio:   " & Trim(DtMensaje.Rows(0).Item("MONEDA")) & Space(1) & Trim(DtMensaje.Rows(0).Item("Precio"))
                Else
                    LblDetalleMensaje.Text = "Nunca se compró."
                End If

            Case 4  '   Dias que se demoró en su último pedido
                Entidad.Requerimiento = New ETRequerimiento
                Negocio.Requerimiento = New NGRequerimiento
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CboAlmacen.Value
                    .FechaEmision = Now
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigo.Text & "")
                    .Unidad = Trim(TxtUM.Text & "")
                End With
                DtMensaje = Negocio.Requerimiento.DiasUltimoPedido(Entidad.Requerimiento)


                If DtMensaje.Rows.Count > 0 Then
                    If DtMensaje.Rows(0).Item("Dias") >= 1 Then
                        LblDetalleMensaje.Text = "Demora en la entrega: " & DtMensaje.Rows(0).Item("Dias") & " día(s)."
                    Else
                        LblDetalleMensaje.Text = "La entrega fue antes del día estipulado."
                    End If
                Else
                    LblDetalleMensaje.Text = "Nunca se solicitó."
                End If

            Case 5  '   Último despacho que se solicitó en el Area
                Entidad.Requerimiento = New ETRequerimiento
                Negocio.Requerimiento = New NGRequerimiento

                If CboArea.Value = 0 Then
                    MsgBox("Debe seleccionar un área para continuar.", MsgBoxStyle.Critical, "Comacsa")
                    CboArea.Focus()
                    Return
                End If

                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CboAlmacen.Value
                    .FechaEmision = Now
                    .Area = CboArea.Value
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigo.Text & "")
                    .Unidad = Trim(TxtUM.Text & "")
                End With
                DtMensaje = Negocio.Requerimiento.UltimoDespachoArea(Entidad.Requerimiento)

                If DtMensaje.Rows.Count > 0 Then
                    LblDetalleMensaje.Text = "Día: " & DtMensaje.Rows(0).Item("Fecha")
                Else
                    LblDetalleMensaje.Text = "Nunca se solicitó."
                End If

            Case 6  '   Stock del Mes anterior
                Entidad.Requerimiento = New ETRequerimiento
                Negocio.Requerimiento = New NGRequerimiento
                xMes = Month(Now)
                año = Year(Now)
                Mes = ""

                If xMes = 1 Then
                    Mes = "12"
                Else
                    xMes = CInt(xMes) - 1
                    If xMes.Length = 1 Then
                        Mes = "0" & xMes
                    End If
                End If

                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CboAlmacen.Value
                    .CodigoProducto = Trim(TxtCodigo.Text & "")
                    .Ano = año
                    .Mes = Mes
                    .TipoProducto = "01"
                    .Inicio = ""
                    .Fin = ""
                End With

                Tipo = "1"

                Entidad.Resultado = Negocio.Requerimiento.StockMesAnterior(Entidad.Requerimiento, Tipo)
                If Entidad.Resultado.Realizo = True Then
                    LblDetalleMensaje.Text = "Stock Mes Anterior: " & Entidad.Resultado.Mensaje
                End If

            Case 7  '   Consumo del Mes
                Entidad.Requerimiento = New ETRequerimiento
                Negocio.Requerimiento = New NGRequerimiento
                Mov = "18"
                Doc = "SO"
                año = Year(Now)
                Mes = Month(Now)
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CboAlmacen.Value
                    .Mes = Mes
                    .Ano = año
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigo.Text & "")
                    .Unidad = Trim(TxtUM.Text & "")
                End With
                DtMensaje = Negocio.Requerimiento.Consumo_Ingreso_Mes(Entidad.Requerimiento, Mov, Doc)

                If DtMensaje.Rows.Count > 0 Then
                    If IsDBNull(DtMensaje.Rows(0).Item("Cantidad")) = True Then
                        Cantidad = 0
                    Else
                        Cantidad = DtMensaje.Rows(0).Item("Cantidad")
                    End If
                    LblDetalleMensaje.Text = "Consumo del Mes: " & Cantidad
                End If

            Case 8  'Ingreso del Mes
                Entidad.Requerimiento = New ETRequerimiento
                Negocio.Requerimiento = New NGRequerimiento

                Mov = "01"
                Doc = "IO"
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CboAlmacen.Value
                    .Ano = Year(Now)
                    .Mes = Month(Now)
                    .Unidad = Trim(TxtUM.Text & "")
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigo.Text & "")
                End With
                DtMensaje = Negocio.Requerimiento.Consumo_Ingreso_Mes(Entidad.Requerimiento, Mov, Doc)

                If DtMensaje.Rows.Count > 0 Then
                    If IsDBNull(DtMensaje.Rows(0).Item("Cantidad")) = True Then
                        Cantidad = 0
                    Else
                        Cantidad = DtMensaje.Rows(0).Item("Cantidad")
                    End If
                    LblDetalleMensaje.Text = "Ingreso del Mes: " & Cantidad
                End If

            Case 9  ' Stock Actual
                Entidad.Requerimiento = New ETRequerimiento
                Negocio.Requerimiento = New NGRequerimiento

                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CboAlmacen.Value
                    .CodigoProducto = TxtCodigo.Text
                End With
                Tipo = "5"

                Entidad.Resultado = Negocio.Requerimiento.StockMesAnterior(Entidad.Requerimiento, Tipo)
                If Entidad.Resultado.Realizo = True Then
                    LblDetalleMensaje.Text = "Stock Actual: " & Entidad.Resultado.Mensaje
                Else
                    LblDetalleMensaje.Text = "Stock Agotado."
                End If


            Case 10  ' Ultimo Pedio
                Entidad.Pedido = New ETPedido
                Negocio.PedidoBL = New NGPedido

                With Entidad.Pedido
                    .Cod_Cia = Companhia
                    .Codigo_Producto = TxtCodigo.Text
                    .Codigo_Area = CboArea.Value
                End With
                Dim dt As New DataTable
                dt = Negocio.PedidoBL.Consulta_Pedido(Entidad.Pedido, 1)

                If dt.Rows.Count > 0 Then
                    LblDetalleMensaje.Text = "El último pedido se realizó el: " + dt.Rows(0).Item("Fecha") + " para el equipo " + dt.Rows(0).Item("Activo")
                Else
                    LblDetalleMensaje.Text = "No se ha registrado ningun pedido."
                End If

            Case 11  ' Ultimo Pedio
                Entidad.Pedido = New ETPedido
                Negocio.PedidoBL = New NGPedido

                With Entidad.Pedido
                    .Cod_Cia = Companhia
                    .Codigo_Producto = TxtCodigo.Text
                    .Codigo_Area = CboArea.Value
                    .Mes = Month(Now)
                End With
                Dim dt As New DataTable
                dt = Negocio.PedidoBL.Consulta_Pedido(Entidad.Pedido, 2)

                If dt.Rows.Count > 0 Then
                    Dim num As Integer
                    num = dt.Rows.Count

                    LblDetalleMensaje.Text = "Se han generado " & num & " Requerimiento de Compra en el mes."
                Else
                    LblDetalleMensaje.Text = "No se han generado requerimientos de compra."
                End If

            Case Else
                Return
        End Select
    End Sub
#End Region

#End Region   'Eventos Controles

#Region "Load"
    Private Sub FrmDatosAuxiliares_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarAlmacen_General(CboAlmacen)
        Call ListarArea_General(CboArea)

        Call ListarProductosAlmacen()
    End Sub
#End Region                'Load

End Class