Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Math
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmAprobacionRequerimiento

    '    *****   Listas  *****
    Dim Requerimiento As New List(Of ETRequerimiento)
    Dim Reque As ETRequerimiento
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub


#Region "Funciones Locales"

#Region "Listar Lugar Entrega"
    Private Sub ListarLugarEntrega()
        Entidad.Almacen = New ETAlmacen
        Negocio.Almacen = New NGAlmacen

        With Entidad.Almacen
            .Cod_Cia = Companhia
        End With
        CmbAlmacen.DataSource = Negocio.Almacen.Listar_Almacen(Entidad.Almacen, "LIS")
        CmbAlmacen.DisplayMember = "descrip"
        CmbAlmacen.ValueMember = "cod_alm"
        CmbAlmacen.Text = "SUMINISTROS INFANTAS"
    End Sub
#End Region

#Region "Listar Requerimiento"
    Private Sub ListarRequerimiento()
        Entidad.Requerimiento = New ETRequerimiento
        Negocio.Requerimiento = New NGRequerimiento

        With Entidad.Requerimiento
            .FechaEmision = DtInicio.Value
            .Fec_Aprob = DtFin.Value
            If RbAprobacion.Checked = True Then
                .Aprobada = "1"
            Else
                .Aprobada = "0"
            End If
            .Cod_Cia = Companhia
            .User_Crea = User_Sistema
        End With
        dgvRequerimiento.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "CAB")
    End Sub
#End Region

#Region "Validar Aprobacion Requerimiento"
    Private Function ValidarAprobacion() As Boolean

    End Function
#End Region

#Region "Validar Anular - aprobacion Requerimiento"
    Private Function ValidarAnulacionAprobacionRequerimiento() As Boolean
        Dim xnumero As Integer
        For j As Integer = 0 To dgvRequerimiento.Rows.Count - 1
            If dgvRequerimiento.Rows(j).Cells("Action").Value = 0 Then
                Dim dtReque As New DataTable
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .NroReq = dgvRequerimiento.Rows(j).Cells("NroRequerimiento").Value
                End With
                dtReque = Negocio.Requerimiento.ListarRequerimientoLogistica(Entidad.Requerimiento, "ARE")

                If dtReque.Rows.Count > 0 Then
                    MsgBox("El requerimiento " & Trim(dgvRequerimiento.Rows(j).Cells("NroRequerimiento").Value & "") & " ya tiene O/C, no podrá desaprobarse.", MsgBoxStyle.Critical, "Comacsa")
                    dgvRequerimiento.Rows(j).Cells("Action").Value = 1
                    Return False
                End If
                xnumero = j + 1
            End If
        Next
        If xnumero > 0 Then
            Return True
        End If
    End Function
#End Region

#End Region   '   Funciones Locales

#Region "Funciones Globales"

#Region "Grabar"
    Public Sub Grabar()
        Cia1.Focus()
        If RbAprobacion.Checked = True And TabAprobacionRequerimiento.Tabs("Aprobar").Selected = True Then
            If Not MsgBox("¿Esta Seguro de APROBAR el Requerimiento(s)?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then Return
        Else
            If Not MsgBox("¿Esta Seguro de DESAPROBAR el Requerimiento(s) ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then Return
        End If

        If dgvRequerimiento.Rows.Count > 0 Then
            For i As Integer = 0 To dgvRequerimiento.Rows.Count - 1
                If dgvRequerimiento.Rows(i).Cells("Action").Value = 1 Then
                    Reque = New ETRequerimiento
                    With Reque
                        .Cod_Cia = Companhia
                        .User_Crea = User_Sistema
                        .NroReq = dgvRequerimiento.Rows(i).Cells("NroRequerimiento").Value
                        If RbAprobacion.Checked = True And TabAprobacionRequerimiento.Tabs("Aprobar").Selected = True Then
                            .Aprobada = 1
                        Else
                            .Aprobada = 0
                        End If

                    End With
                    Requerimiento.Add(Reque)
                End If
            Next
            Entidad.Resultado = Negocio.Requerimiento.AprobarRequerimiento(Requerimiento)

            If Entidad.Resultado.Realizo = True Then
                MsgBox("Los datos se guardarón correctamente.", MsgBoxStyle.Information, "Comacsa")
            End If

            Requerimiento = New List(Of ETRequerimiento)
            TabAprobacionRequerimiento.Tabs("Aprobar").Selected = True
            Call ListarRequerimiento()
        End If
    End Sub


#End Region

#Region "Buscar"
    Public Sub Buscar()
        Call ListarRequerimiento()
    End Sub
#End Region

#End Region  '   Funciones Globales

#Region "Eventos Controles"

#Region "dgvRequerimiento - DoubleClickRow"
    Private Sub dgvRequerimiento_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvRequerimiento.DoubleClickRow
        With Entidad.Requerimiento
            .Cod_Cia = Companhia
            .NroReq = e.Row.Cells("NroRequerimiento").Value
        End With
        DgvDetalleRequerimiento.DataSource = Negocio.Requerimiento.ListarRequerimiento(Entidad.Requerimiento, "DET1")

        If DgvDetalleRequerimiento.Rows.Count > 0 Then
            TabAprobacionRequerimiento.Tabs("Detalle").Selected = True
            TabAprobacionRequerimiento.Tabs("Detalle").Enabled = True
        Else
            MsgBox("NO hay detalle para mostrar.", MsgBoxStyle.Critical, "Comacsa")
        End If
    End Sub

#End Region

#Region "TabAprobacionRequerimiento - SelectedTabChanged"
    Private Sub TabAprobacionRequerimiento_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabAprobacionRequerimiento.SelectedTabChanged
        If TabAprobacionRequerimiento.Tabs("Aprobar").Selected = True Then
            TabAprobacionRequerimiento.Tabs("Detalle").Enabled = False
            TabAprobacionRequerimiento.Tabs("DatosAuxiliares").Enabled = False

        ElseIf TabAprobacionRequerimiento.Tabs("Detalle").Selected = True Then
            TabAprobacionRequerimiento.Tabs("DatosAuxiliares").Enabled = True

        ElseIf TabAprobacionRequerimiento.Tabs("DatosAuxiliares").Selected = True Then
            LblDetalleMensaje.Text = ""
            TxtCodigoArticulo.Text = ""
            TxtDescripcionArticulo.Text = ""
            TxtUMArticulo.Text = ""
            LstDet.Items.Clear()

            TxtCodigoArticulo.Text = DgvDetalleRequerimiento.ActiveRow.Cells("Codigo").Value
            TxtDescripcionArticulo.Text = DgvDetalleRequerimiento.ActiveRow.Cells("Descripcion").Value
            TxtUMArticulo.Text = DgvDetalleRequerimiento.ActiveRow.Cells("UM").Value

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
            LstDet.SelectedIndex = 0
        End If
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
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CmbAlmacen.Value
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigoArticulo.Text & "")
                    .Unidad = TxtUMArticulo.Text
                    .Ano = Year(Now)
                End With
                DtMensaje = Negocio.Requerimiento.ListarPromedioConsumoMensual(Entidad.Requerimiento)

                If DtMensaje.Rows.Count > 0 Then
                    Cantidad = DtMensaje.Rows(0).Item("Cantidad")
                    LblDetalleMensaje.Text = "Promedio del Consumo Mensual: " & (Cantidad / 12)
                End If

            Case 1  '   Consumo del Area en los 2 últimos Años

                xFechaInicio = Now
                xFechaFin = DateAdd(DateInterval.Year, -2, Now.Date)


                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CmbAlmacen.Value
                    .Area = dgvRequerimiento.ActiveRow.Cells("CodigoArea").Value
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigoArticulo.Text & "")
                    .Unidad = Trim(TxtUMArticulo.Text & "")
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

                xFechaInicio = Now
                xFechaFin = DateAdd(DateInterval.Year, -2, Now.Date)

                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CmbAlmacen.Value
                    .Area = ""
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigoArticulo.Text & "")
                    .Unidad = Trim(TxtUMArticulo.Text & "")
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
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CmbAlmacen.Value
                    .CodigoProducto = Trim(TxtCodigoArticulo.Text & "")
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
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CmbAlmacen.Value
                    .FechaEmision = Now
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigoArticulo.Text & "")
                    .Unidad = Trim(TxtUMArticulo.Text & "")
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
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CmbAlmacen.Value
                    .FechaEmision = Now
                    .Area = dgvRequerimiento.ActiveRow.Cells("CodigoArea").Value
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigoArticulo.Text & "")
                    .Unidad = Trim(TxtUMArticulo.Text & "")
                End With
                DtMensaje = Negocio.Requerimiento.UltimoDespachoArea(Entidad.Requerimiento)

                If DtMensaje.Rows.Count > 0 Then
                    LblDetalleMensaje.Text = "Día: " & DtMensaje.Rows(0).Item("Fecha")
                Else
                    LblDetalleMensaje.Text = "Nunca se solicitó."
                End If

            Case 6  '   Stock del Mes anterior

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
                    .Lugar_Ent = CmbAlmacen.Value
                    .CodigoProducto = Trim(TxtCodigoArticulo.Text & "")
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
                Mov = "18"
                Doc = "SO"
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CmbAlmacen.Value
                    .Ano = Year(Now)
                    .Mes = Month(Now)
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigoArticulo.Text & "")
                    .Unidad = Trim(TxtUMArticulo.Text & "")
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
                Mov = "01"
                Doc = "IO"
                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CmbAlmacen.Value
                    .Ano = Year(Now)
                    .Mes = Month(Now)
                    .Unidad = Trim(TxtUMArticulo.Text & "")
                    .TipoProducto = "01"
                    .CodigoProducto = Trim(TxtCodigoArticulo.Text & "")
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

                xMes = Month(Now)
                año = Year(Now)
                Mes = ""

                If xMes = 1 Then
                    Mes = "12"
                Else
                    xMes = CInt(xMes)
                    If xMes.Length = 1 Then
                        Mes = "0" & xMes
                    End If
                End If

                With Entidad.Requerimiento
                    .Cod_Cia = Companhia
                    .Lugar_Ent = CmbAlmacen.Value
                    .CodigoProducto = TxtCodigoArticulo.Text
                    .Ano = año
                    .TipoProducto = "01"
                    .Mes = Mes
                    .Inicio = ""
                    .Fin = ""
                End With
                Tipo = "2"

                Entidad.Resultado = Negocio.Requerimiento.StockMesAnterior(Entidad.Requerimiento, Tipo)
                If Entidad.Resultado.Realizo = True Then
                    LblDetalleMensaje.Text = "Stock Actual: " & Entidad.Resultado.Mensaje
                Else
                    LblDetalleMensaje.Text = "Stock Agotado."
                End If

            Case Else
                Return
        End Select
    End Sub
#End Region

#Region "RbAprobacion - CheckedChanged"
    Private Sub RbAprobacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAprobacion.CheckedChanged
        LblMensaje.Appearance.BackColor = Color.LightSkyBlue
        RbAnular.BackColor = Color.LightSkyBlue
        RbAprobacion.BackColor = Color.LightSkyBlue
        ChkTodos.BackColor = Color.LightSkyBlue
        LblMensaje.Text = "APROBACIÓN DE REQUERIMIENTO"
        Call ListarRequerimiento()
        ChkTodos.Checked = False
    End Sub
#End Region

#Region "RbAnular - CheckedChanged"
    Private Sub RbAnular_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAnular.CheckedChanged
        LblMensaje.Appearance.BackColor = Color.RoyalBlue
        RbAnular.BackColor = Color.RoyalBlue
        RbAprobacion.BackColor = Color.RoyalBlue
        ChkTodos.BackColor = Color.RoyalBlue
        LblMensaje.Text = "ANULAR APROBACIÓN DE REQUERIMIENTO"
        Call ListarRequerimiento()
        ChkTodos.Checked = True
    End Sub
#End Region

#Region "ChkTodos - CheckedChanged"
    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If dgvRequerimiento.Rows.Count > 0 Then
            If ChkTodos.Checked = True Then
                For j As Integer = 0 To dgvRequerimiento.Rows.Count - 1
                    dgvRequerimiento.Rows(j).Cells("Action").Value = True
                Next
            Else
                For j As Integer = 0 To dgvRequerimiento.Rows.Count - 1
                    dgvRequerimiento.Rows(j).Cells("Action").Value = False
                Next
            End If
        End If
    End Sub
#End Region

#End Region   '   Eventos Controles

#Region "Load"
    Private Sub FrmAprobacionRequerimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        DtInicio.Value = Now
        DtFin.Value = Now
        RbAprobacion.Checked = True
        Call ListarRequerimiento()
        Call ListarLugarEntrega()
    End Sub
#End Region                '   Load

End Class