Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class frmProgramacionCamion
#Region "Declarar Variables"
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private TipoG As sTate
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
#End Region
    Dim posGrid As Int32
    Dim numpedido As String
    Dim cliente As String
    Dim distrito As String
    Dim direccion As String
    Dim referencia As String
    Dim hora As String
    Dim placa As String
    Dim COD_PROGRAMACION As Int32
    Dim nroviaje As Int32
    Dim tonelada As Double
    Dim dtProgramacion As New DataTable
    Dim dtCamion As New DataTable
    Dim dtDatosProg As New DataTable
    Private Sub gridDisponibilidad_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridDisponibilidad.ClickCell
        Try
            'MsgBox("hacer un click en el Picture, mantenerlo presionado y mover el mouse")
            If gridDisponibilidad.ActiveRow.Index < 0 Then Exit Sub
            If gridCamiones.Rows.Count <= 0 Then Exit Sub
            If gridDisponibilidad.ActiveRow.Cells(gridDisponibilidad.ActiveCell.Column.Index).Column.Key = "NUMPEDIDO" Then
                numpedido = gridDisponibilidad.ActiveRow.Cells("NUMPEDIDO").Value.ToString.Trim
                cliente = gridDisponibilidad.ActiveRow.Cells("RAZSOC").Value.ToString.Trim
                distrito = gridDisponibilidad.ActiveRow.Cells("DISTRITO").Value.ToString.Trim
                direccion = gridDisponibilidad.ActiveRow.Cells("DIRECCION").Value.ToString.Trim
                referencia = gridDisponibilidad.ActiveRow.Cells("REFERENCIA").Value.ToString.Trim
                hora = gridDisponibilidad.ActiveRow.Cells("HORA").Value.ToString.Trim
                COD_PROGRAMACION = gridDisponibilidad.ActiveRow.Cells("COD_PROGRAMACION").Value
                tonelada = CDbl(gridDisponibilidad.ActiveRow.Cells("CANT_DESPACHO").Value).ToString("##0.0000")
                Label1.Text = "N° DE PEDIDO: " & numpedido & ""
                If gridDisponibilidad.ActiveRow.Cells("FLGUSO").Value = 1 Then
                    MsgBox("El pedido ya fue programado", MsgBoxStyle.Exclamation, msgComacsa)
                    limpiarlinea()
                    numpedido = ""
                    tonelada = 0
                    Exit Sub
                End If
                dibujar = False
                dibujando = False
                dibujar = True
                myLine = New Linea(0, 0, 0, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridDisponibilidad_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridDisponibilidad.MouseDown
        posGrid = e.Y
    End Sub

    Private Sub frmProgramacionCamion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = "N° DE PEDIDO: "
        dtpFecha.Value = DateAdd(DateInterval.Day, 1, Now.Date)
        'dtpFecha.Value = Now.Date
    End Sub
    Sub Procesar()
        Try
            Entidad.Contratista = New ETContratista
            Entidad.Contratista.TipoOperacion = Ope
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Entidad.Contratista.Fecha = dtpFecha.Value
            Entidad.Contratista.NroViaje = nupviaje.Value
            dtCamion = Negocio.NContratista.Listar_PRO_CamionDisponible(Entidad.Contratista)
            Call CargarUltraGridxBinding(Me.gridCamiones, Source2, dtCamion)
            Entidad.Contratista = New ETContratista
            Entidad.Contratista.TipoOperacion = Ope
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Entidad.Contratista.Fecha = dtpFecha.Value
            Entidad.Contratista.NroViaje = nupviaje.Value
            Entidad.Contratista._codprov = txtcodprov.Text
            dtDatosProg = Negocio.NContratista.Listar_PRO_Programacion(Entidad.Contratista)
            Call CargarUltraGridxBinding(Me.gridDisponibilidad, Source1, dtDatosProg)
            dtProgramacion = New DataTable

            For i As Int32 = 0 To dtDatosProg.Rows.Count - 1
                If dtDatosProg.Rows(i)("FLGUSO") = 1 Then
                    gridDisponibilidad.Rows(i).Appearance.BackColor = Color.Yellow
                End If
            Next

            Entidad.Contratista = New ETContratista
            Entidad.Contratista.TipoOperacion = Ope
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Entidad.Contratista.Fecha = dtpFecha.Value
            Entidad.Contratista.NroViaje = nupviaje.Value
            dtProgramacion = Negocio.NContratista.Listar_PRO_ProgramacionCamion(Entidad.Contratista)
            limpiarlinea()
        Catch ex As Exception

        End Try
    End Sub
    Sub limpiar()
        dtProgramacion = New DataTable
        dtCamion = New DataTable
        dtDatosProg = New DataTable
    End Sub
    Sub Buscar()
        Dim frm As New FrmListaTransportista
        frm.ShowDialog()
        txtcodprov.Text = codMotivodetalle.Trim
        txtproveedor.Text = Motivodetalle.Trim
        Procesar()
        'txtruc.Text = Ruc.Trim
    End Sub
#Region "variables de sergioman"

    'Flags
    Private dibujar As Boolean = False
    Private dibujando As Boolean = False
    Private mover As Boolean = False

    'mi linea
    Private myLine As Linea

    'mi objeto para dibujar
    Private g As Graphics
#End Region

#Region "mis funciones"
    Public Sub DrawMyLine()

        'creando el objeto
        g = Panel1.CreateGraphics()

        g.Clear(Color.White)
        'ahora dibujando la lina
        g.DrawLine(myLine.Pincel, myLine.pIniX, myLine.pIniY, myLine.pFinX, myLine.pFinY)
    End Sub
#End Region

    Private Sub PicFondo_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        If dibujar Then
            If Not dibujando Then
                myLine.pIniX = e.X
                myLine.pIniY = e.Y
                'ya se hizo el primer punto
                dibujando = True
            End If
        End If
    End Sub

    Private Sub PicFondo_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If dibujar Then
            If Not dibujando Then
                'MsgBox(posGrid)
                'MsgBox(Panel1.Height)
                'MsgBox(Control.MousePosition.Y)
                myLine.pIniX = gridDisponibilidad.Width + 15
                myLine.pIniY = gridDisponibilidad.Location.Y + posGrid
                'Control.MousePosition.Y 'e.Y
                dibujando = True
                dibujar = False
            End If
        End If

        If dibujando Then
            myLine.pFinX = e.X
            myLine.pFinY = e.Y
            Me.DrawMyLine()
        End If
    End Sub

    Private Sub PicFondo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'se termino de dibujar la linea
        dibujando = False
        'ahora mover la linea
        'Me.Panel1.Visible = True
    End Sub

    Private Sub UltraGrid1_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridCamiones.ClickCell
        Try
            If gridCamiones.ActiveRow.Index < 0 Then Exit Sub
            placa = gridCamiones.ActiveRow.Cells("PLACA").Value.ToString.Trim
            Dim ingresado As Double = CDbl(gridCamiones.ActiveRow.Cells("PESOINGRESADO").Value).ToString("##0.0000")
            Dim pesomaximo As Double = CDbl(gridCamiones.ActiveRow.Cells("PESOMAXIMO").Value).ToString("##0.0000")
           
            If gridCamiones.ActiveRow.Cells(gridCamiones.ActiveCell.Column.Index).Column.Key = "PLACA" Then
                If numpedido <> "" And tonelada <> 0 Then
                    Dim result As New DialogResult
                    Dim frm As New frmIngresoTonelada
                    frm.toneladamaxima = tonelada
                    frm.numpedido = numpedido
                    frm.cod_programacion = COD_PROGRAMACION
                    frm.dtProgramado = dtProgramacion
                    frm.numviaje = nupviaje.Value
                    result = frm.ShowDialog
                    If result = Windows.Forms.DialogResult.Cancel Then limpiarlinea() : Exit Sub
                    'frm.ShowDialog()
                    'MsgBox(frm.gridProducto.Rows.Count)
                    tonelada = CDbl(frm.tonelada_nueva).ToString("##0.0000")
                    'nroviaje = frm.numviaje
                    For i As Int32 = 0 To dtCamion.Rows.Count - 1
                        If dtCamion.Rows(i)("PLACA").ToString.Trim = placa Then
                            If CDbl(ingresado + tonelada) > pesomaximo Then
                                If MsgBox("La carga es mayor al máximo de toneladas permitidas. Desea continuar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                                    limpiarlinea()
                                    Exit Sub
                                End If
                            End If
                            dtCamion.Rows(i)("PESOINGRESADO") = CDbl(ingresado + tonelada)
                            Exit For
                        End If
                    Next
                    Dim cant_despacho As Double
                    Dim tonelada_producto As Double
                    Dim codprod As String = ""
                    Dim producto As String = ""
                    Dim item As Int32 = 0
                    For tot As Int32 = 0 To frm.gridProducto.Rows.Count - 1
                        tonelada_producto = CDbl(frm.gridProducto.Rows(tot).Cells("TONELADA").Value).ToString("##0.0000")
                        codprod = frm.gridProducto.Rows(tot).Cells("COD_PROD").Value.ToString.Trim
                        producto = frm.gridProducto.Rows(tot).Cells("PRODUCTO").Value.ToString.Trim
                        item = frm.gridProducto.Rows(tot).Cells("ITEM").Value.ToString.Trim
                        nroviaje = frm.gridProducto.Rows(tot).Cells("NVIAJE").Value
                        If tonelada_producto > 0 Then
                            For i As Int32 = 0 To dtDatosProg.Rows.Count - 1
                                If dtDatosProg.Rows(i)("NUMPEDIDO").ToString.Trim = numpedido.Trim Then
                                    cant_despacho = CDbl(dtDatosProg.Rows(i)("CANT_DESPACHO")).ToString("##0.0000")
                                    dtDatosProg.Rows(i)("CANT_DESPACHO") = CDbl(cant_despacho - tonelada_producto).ToString("##0.0000")
                                    llenarProgramacion(tonelada_producto, codprod, producto, item)
                                    If dtDatosProg.Rows(i)("CANT_DESPACHO") = 0 Then
                                        dtDatosProg.Rows(i)("FLGUSO") = 1
                                        gridDisponibilidad.Rows(i).Appearance.BackColor = Color.Yellow
                                        numpedido = ""
                                        tonelada = 0
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    Next

                End If
                dibujar = False
                dibujando = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub llenarProgramacion(ByVal tonelada As Double, ByVal codprod As String, ByVal producto As String, ByVal item As Int32)
        If dtProgramacion.Columns.Count <= 1 Then
            dtProgramacion.Columns.Add("NUMPEDIDO")
            dtProgramacion.Columns.Add("CLIENTE")
            dtProgramacion.Columns.Add("DISTRITO")
            dtProgramacion.Columns.Add("TONELADA")
            dtProgramacion.Columns.Add("PLACA")
            dtProgramacion.Columns.Add("HORA")
            dtProgramacion.Columns.Add("COD_PROGRAMACION")
            dtProgramacion.Columns.Add("DIRECCION")
            dtProgramacion.Columns.Add("REFERENCIA")
            dtProgramacion.Columns.Add("ORDEN")
            dtProgramacion.Columns.Add("COD_PROD")
            dtProgramacion.Columns.Add("PRODUCTO")
            dtProgramacion.Columns.Add("ITEM")
            dtProgramacion.Columns.Add("IDPROGRAMACION")
            dtProgramacion.Columns.Add("EXISTE")
            dtProgramacion.Columns.Add("NROVIAJE")
        End If
        Dim cont As Int32 = 1
        For i As Int32 = 0 To dtProgramacion.Rows.Count - 1
            If dtProgramacion.Rows(i)("PLACA") = placa Then
                cont += 1
            End If
        Next
        Dim dr As DataRow
        dr = dtProgramacion.NewRow
        dr(0) = numpedido
        dr(1) = cliente
        dr(2) = distrito
        dr(3) = tonelada
        dr(4) = placa
        dr(5) = hora
        dr(6) = COD_PROGRAMACION
        dr(7) = direccion
        dr(8) = referencia
        dr(9) = cont 'dtProgramacion.Rows.Count + 1
        dr(10) = codprod
        dr(11) = producto
        dr(12) = item
        dr(13) = 0
        dr(14) = 0
        dr(15) = nroviaje
        dtProgramacion.Rows.Add(dr)
        'MsgBox(dtProgramacion.Rows.Count)
    End Sub
    Sub limpiarlinea()
        myLine.pFinX = 0
        myLine.pFinY = 0
        myLine.pIniX = 0
        myLine.pIniY = 0
        Me.DrawMyLine()
        dibujar = False
        dibujando = False
        numpedido = ""
        tonelada = 0
    End Sub
    Private Sub gridCamiones_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridCamiones.MouseMove
        Try
            If dibujando Then
                myLine.pFinX = gridCamiones.Location.X
                myLine.pFinY = gridCamiones.Location.Y + e.Y
                Me.DrawMyLine()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Try
            Procesar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcodprov_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodprov.KeyDown
        If e.KeyData = Keys.Return Then
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NContratista.Listar_PRO_Prov_Codigo(Entidad.Contratista)
            If dtDatos.Rows.Count > 0 Then
                txtcodprov.Text = dtDatos.Rows(0)("COD_PROV")
                txtproveedor.Text = dtDatos.Rows(0)("PROVEEDOR")
            Else
                MsgBox("El código no existe", MsgBoxStyle.Exclamation, msgComacsa)
                txtproveedor.Clear()
            End If
            Procesar()
        End If
    End Sub

    Private Sub gridCamiones_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridCamiones.DoubleClickRow
        Try
            Dim dtTemporal As New DataTable
            If dtTemporal.Columns.Count <= 1 Then
                dtTemporal.Columns.Add("NUMPEDIDO")
                dtTemporal.Columns.Add("CLIENTE")
                dtTemporal.Columns.Add("DISTRITO")
                dtTemporal.Columns.Add("TONELADA")
                dtTemporal.Columns.Add("PLACA")
                dtTemporal.Columns.Add("ELIMINAR")
                dtTemporal.Columns.Add("HORA")
                dtTemporal.Columns.Add("DIRECCION")
                dtTemporal.Columns.Add("REFERENCIA")
                dtTemporal.Columns.Add("ORDEN")
                dtTemporal.Columns.Add("COD_PROD")
                dtTemporal.Columns.Add("PRODUCTO")
                dtTemporal.Columns.Add("ITEM")
                dtTemporal.Columns.Add("IDPROGRAMACION")
                dtTemporal.Columns.Add("EXISTE")
                dtTemporal.Columns.Add("NROVIAJE")
            End If
            Dim view As DataView = New DataView(dtProgramacion)
            view.Sort = "ORDEN"
            dtProgramacion = view.ToTable("TABLA", True, "NUMPEDIDO", "CLIENTE", "DISTRITO", "TONELADA", "PLACA", "HORA", "COD_PROGRAMACION", "DIRECCION", "REFERENCIA", "ORDEN", "COD_PROD", "PRODUCTO", "ITEM", "IDPROGRAMACION", "EXISTE", "NROVIAJE")

            For i As Int32 = 0 To dtProgramacion.Rows.Count - 1
                If dtProgramacion.Rows(i)("PLACA").ToString.Trim = gridCamiones.ActiveRow.Cells("PLACA").Value.ToString.Trim Then
                    Dim dr As DataRow
                    dr = dtTemporal.NewRow
                    dr(0) = dtProgramacion.Rows(i)("NUMPEDIDO").ToString.Trim
                    dr(1) = dtProgramacion.Rows(i)("CLIENTE").ToString.Trim
                    dr(2) = dtProgramacion.Rows(i)("DISTRITO").ToString.Trim
                    dr(3) = CDbl(dtProgramacion.Rows(i)("TONELADA")).ToString("##0.0000")
                    dr(4) = dtProgramacion.Rows(i)("PLACA").ToString.Trim
                    dr(5) = "Eliminar"
                    dr(6) = dtProgramacion.Rows(i)("HORA").ToString.Trim
                    dr(7) = dtProgramacion.Rows(i)("DIRECCION").ToString.Trim
                    dr(8) = dtProgramacion.Rows(i)("REFERENCIA").ToString.Trim
                    dr(9) = dtProgramacion.Rows(i)("ORDEN").ToString.Trim
                    dr(10) = dtProgramacion.Rows(i)("COD_PROD").ToString.Trim
                    dr(11) = dtProgramacion.Rows(i)("PRODUCTO").ToString.Trim
                    dr(12) = dtProgramacion.Rows(i)("ITEM")
                    dr(13) = dtProgramacion.Rows(i)("IDPROGRAMACION")
                    dr(14) = dtProgramacion.Rows(i)("EXISTE")
                    dr(15) = dtProgramacion.Rows(i)("NROVIAJE")
                    dtTemporal.Rows.Add(dr)
                End If
            Next
            If dtTemporal.Rows.Count <= 0 Then
                MsgBox("No existe programación para este vehiculo", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            Dim frm As New frmdetalleProgramacion
            frm.dtDatosProg = dtTemporal

            frm.ShowDialog()
            eliminaProgramacion(frm.dtEliminados)
            cambiarOrden(frm.dtDatosProg)
            limpiarlinea()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub cambiarOrden(ByVal dtCambio As DataTable)
        For elim As Int32 = 0 To dtCambio.Rows.Count - 1
            Dim pedido As String = dtCambio.Rows(elim)("NUMPEDIDO").ToString.Trim
            Dim placa As String = dtCambio.Rows(elim)("PLACA").ToString.Trim
            Dim codprod As String = dtCambio.Rows(elim)("COD_PROD").ToString.Trim
            Dim nroviaje As String = dtCambio.Rows(elim)("NROVIAJE").ToString.Trim
            For i As Int32 = 0 To dtProgramacion.Rows.Count - 1
                If dtProgramacion.Rows(i)("NUMPEDIDO").ToString.Trim = pedido And dtProgramacion.Rows(i)("PLACA").ToString.Trim = placa And dtProgramacion.Rows(i)("COD_PROD").ToString.Trim = codprod And dtProgramacion.Rows(i)("NROVIAJE").ToString.Trim = nroviaje Then
                    dtProgramacion.Rows(i)("ORDEN") = elim + 1
                End If
            Next

        Next
    End Sub

    Sub eliminaProgramacion(ByVal dtEliminados As DataTable)
        For elim As Int32 = 0 To dtEliminados.Rows.Count - 1
            Dim pedido_eliminado As String = dtEliminados.Rows(elim)("PEDIDO").ToString.Trim
            Dim placa_eliminado As String = dtEliminados.Rows(elim)("PLACA").ToString.Trim
            Dim nroviaje_eliminado As String = dtEliminados.Rows(elim)("NROVIAJE").ToString.Trim
            Dim tonelada_eliminado As Double = CDbl(dtEliminados.Rows(elim)("TONELADA")).ToString("##0.0000")
            For i As Int32 = 0 To dtCamion.Rows.Count - 1
                Dim ingresado As Double = CDbl(dtCamion.Rows(i)("PESOINGRESADO")).ToString("##0.0000")
                If dtCamion.Rows(i)("PLACA").ToString.Trim = placa_eliminado Then
                    dtCamion.Rows(i)("PESOINGRESADO") = CDbl(ingresado - tonelada_eliminado)
                    Exit For
                End If
            Next
            For i As Int32 = 0 To dtProgramacion.Rows.Count - 1
                If dtProgramacion.Rows(i)("PLACA").ToString.Trim = placa_eliminado And dtProgramacion.Rows(i)("NUMPEDIDO").ToString.Trim = pedido_eliminado And dtProgramacion.Rows(i)("NROVIAJE").ToString.Trim = nroviaje_eliminado Then
                    dtProgramacion.Rows.RemoveAt(i)
                    Exit For
                End If
            Next
            For i As Int32 = 0 To dtDatosProg.Rows.Count - 1
                If dtDatosProg.Rows(i)("NUMPEDIDO").ToString.Trim = pedido_eliminado Then
                    dtDatosProg.Rows(i)("CANT_DESPACHO") = dtDatosProg.Rows(i)("CANT_DESPACHO") + tonelada_eliminado
                    dtDatosProg.Rows(i)("FLGUSO") = 0
                    gridDisponibilidad.Rows(i).Appearance.BackColor = Color.White
                    Exit For
                End If
            Next
        Next
    End Sub
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nupviaje.ValueChanged
        Procesar()
    End Sub

    Sub Grabar()
        Try
            If dtProgramacion.Rows.Count > 0 Then
                If MsgBox("¿Seguro desea guardar la programación?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Return
                End If

                Dim view As DataView = New DataView(dtProgramacion)
                view.Sort = "ORDEN"
                dtProgramacion = view.ToTable("TABLA", True, "NUMPEDIDO", "CLIENTE", "DISTRITO", "TONELADA", "PLACA", "HORA", "COD_PROGRAMACION", "DIRECCION", "REFERENCIA", "ORDEN", "COD_PROD", "PRODUCTO", "ITEM", "IDPROGRAMACION", "EXISTE", "NROVIAJE")

                Entidad.Contratista = New ETContratista
                Negocio.NContratista = New NGContratista
                Entidad.MyLista = New ETMyLista
                Entidad.Contratista.Tipo = 1
                Entidad.Contratista._codprov = txtcodprov.Text
                Entidad.Contratista.NroViaje = nupviaje.Value
                Entidad.Contratista.Fecha = dtpFecha.Value
                Entidad.Contratista.Usuario = User_Sistema
                Dim dtDatos As New DataTable
                dtDatos = Negocio.NContratista.Elimina_Programacion(Entidad.Contratista)
                If dtDatos.Rows(0)(0) <> "OK" Then
                    MsgBox(dtDatos.Rows(0)(0), MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
                For i As Int32 = 0 To dtProgramacion.Rows.Count - 1
                    Entidad.Contratista = New ETContratista
                    Entidad.Contratista.TipoOperacion = Ope
                    Negocio.NContratista = New NGContratista
                    Entidad.MyLista = New ETMyLista
                    Entidad.Contratista.Tipo = 1
                    Entidad.Contratista._codprov = txtcodprov.Text
                    'Entidad.Contratista.NroViaje = nupviaje.Value
                    Entidad.Contratista.NroViaje = dtProgramacion.Rows(i)("NROVIAJE")
                    Entidad.Contratista.Fecha = dtpFecha.Value
                    Entidad.Contratista.ID = dtProgramacion.Rows(i)("IDPROGRAMACION")
                    Entidad.Contratista._numorden = dtProgramacion.Rows(i)("NUMPEDIDO")
                    Entidad.Contratista._codprog = dtProgramacion.Rows(i)("COD_PROGRAMACION")
                    Entidad.Contratista._placa = dtProgramacion.Rows(i)("PLACA")
                    Entidad.Contratista._toneladas = dtProgramacion.Rows(i)("TONELADA")
                    Entidad.Contratista._orden = dtProgramacion.Rows(i)("ORDEN")
                    Entidad.Contratista._codprod = dtProgramacion.Rows(i)("COD_PROD")
                    Entidad.Contratista._descripcion = dtProgramacion.Rows(i)("PRODUCTO")
                    Entidad.Contratista._item = dtProgramacion.Rows(i)("ITEM")
                    Entidad.Contratista.Usuario = User_Sistema
                    dtDatos = New DataTable
                    dtDatos = Negocio.NContratista.Registra_Programacion(Entidad.Contratista)
                Next
                MsgBox("Programación grabada correctamente", MsgBoxStyle.Information, msgComacsa)
                Procesar()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub Eliminar()
        Try
            If dtProgramacion.Rows.Count > 0 Then
                If MsgBox("¿Seguro desea eliminar la programación?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Return
                End If
                Entidad.Contratista = New ETContratista
                Negocio.NContratista = New NGContratista
                Entidad.MyLista = New ETMyLista
                Entidad.Contratista.Tipo = 3
                Entidad.Contratista._codprov = txtcodprov.Text
                Entidad.Contratista.NroViaje = nupviaje.Value
                Entidad.Contratista.Fecha = dtpFecha.Value
                Entidad.Contratista.Usuario = User_Sistema
                Dim dtDatos As New DataTable
                dtDatos = Negocio.NContratista.Elimina_Programacion(Entidad.Contratista)
                If dtDatos.Rows(0)(0) <> "OK" Then
                    MsgBox(dtDatos.Rows(0)(0), MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
                MsgBox("Programación eliminada correctamente", MsgBoxStyle.Exclamation, msgComacsa)
                Procesar()
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Sub cargaProgramacion(ByVal dtEliminados As DataTable)
    '    For elim As Int32 = 0 To dtEliminados.Rows.Count - 1
    '        Dim pedido_eliminado As String = dtEliminados.Rows(elim)("PEDIDO").ToString.Trim
    '        Dim placa_eliminado As String = dtEliminados.Rows(elim)("PLACA").ToString.Trim
    '        Dim tonelada_eliminado As Double = CDbl(dtEliminados.Rows(elim)("TONELADA")).ToString("##0.00")
    '        For i As Int32 = 0 To dtCamion.Rows.Count - 1
    '            Dim ingresado As Double = CDbl(dtCamion.Rows(i)("PESOINGRESADO")).ToString("##0.00")
    '            If dtCamion.Rows(i)("PLACA").ToString.Trim = placa_eliminado Then
    '                dtCamion.Rows(i)("PESOINGRESADO") = CDbl(ingresado - tonelada_eliminado)
    '                Exit For
    '            End If
    '        Next
    '        For i As Int32 = 0 To dtProgramacion.Rows.Count - 1
    '            If dtProgramacion.Rows(i)("PLACA").ToString.Trim = placa_eliminado And dtProgramacion.Rows(i)("NUMPEDIDO").ToString.Trim = pedido_eliminado Then
    '                dtProgramacion.Rows.RemoveAt(i)
    '                Exit For
    '            End If
    '        Next
    '        For i As Int32 = 0 To dtDatosProg.Rows.Count - 1
    '            If dtDatosProg.Rows(i)("NUMPEDIDO").ToString.Trim = pedido_eliminado Then
    '                dtDatosProg.Rows(i)("FLGUSO") = 0
    '                gridDisponibilidad.Rows(i).Appearance.BackColor = Color.White
    '                Exit For
    '            End If
    '        Next
    '    Next
    'End Sub

    Private Sub gridCamiones_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridCamiones.InitializeLayout

    End Sub

    Private Sub gridDisponibilidad_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDisponibilidad.InitializeLayout

    End Sub
End Class