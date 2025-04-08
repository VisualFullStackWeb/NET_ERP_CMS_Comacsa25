Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Windows.Forms
Imports System.Math
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Net.Mail

Public Class FrmAprobacionOC
    '   ******  LISTAS  *****

    Dim Aprobacion As New List(Of ETAprobacionFirmaMonto)
    Dim aprob As ETAprobacionFirmaMonto

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Locales"

#Region "Listar Orden de Compra"
    Private Sub ListarOC()
        With Entidad.OrdenCompra
            .Cod_Cia = Companhia
            If RbAprobacionOC.Checked = True Then
                .Aprobada = "0"
                ChkTodos.Checked = True
            Else
                .Aprobada = "1"
                ChkTodos.Checked = False
            End If
            .Fec_Crea = DtInicio.Value
            .Fec_Entrega = DtFin.Value
            .User_Crea = User_Sistema
        End With
        dgvOC.DataSource = Negocio.OrdenCompraBL.ListarCabOrdenCompraUsuario(Entidad.OrdenCompra)
    End Sub
#End Region

#Region "Datos del Cuadro Comparativo"
    Private Sub DatosCuadroComparativo(ByVal OC As String, ByVal Producto As String, ByVal Tipo As String)
        Dim DtDatos As New DataTable

        With Entidad.OrdenCompra
            .Cod_Cia = Companhia
            .Nro_OC = OC
            .Cod_Prod = Producto
        End With

        If Tipo = "3" Then
            dgvDetalleRequerimiento.DataSource = Negocio.OrdenCompraBL.ArticulosComparados(Entidad.OrdenCompra, Tipo)
        ElseIf Tipo = "4" Then
            dgvAnalisisComparativo.DataSource = Negocio.OrdenCompraBL.ArticulosComparados(Entidad.OrdenCompra, Tipo)
        ElseIf Tipo = "2" Then
            dgvArticulosComparados.DataSource = Negocio.OrdenCompraBL.ArticulosComparados(Entidad.OrdenCompra, Tipo)
        ElseIf Tipo = "6" Then
            dgvArticulosComparadosXproducto.DataSource = Negocio.OrdenCompraBL.ArticulosComparados(Entidad.OrdenCompra, Tipo)
        Else
            DtDatos = Negocio.OrdenCompraBL.ArticulosComparados(Entidad.OrdenCompra, 5)
            If DtDatos.Rows.Count > 0 Then
                lblMonedaCuadro.Text = DtDatos.Rows(0).Item("Moneda")
                LblPrecioUltimaCompra.Text = DtDatos.Rows(0).Item("Precio")
                LblRazonSocial.Text = DtDatos.Rows(0).Item("RazonSocial")
            End If
        End If

    End Sub


#End Region

#Region "Validar Aprobar OC"
    Private Function ValidarAprobacionOC() As Boolean
        Return True
    End Function
#End Region

#Region "Validar Desaprobación OC"
    Private Function ValidarDesaprobacionOC() As Boolean
        Return True
    End Function
#End Region

#Region "Pintar Fila del Cuadro Comparativo"
    Private Sub PintarFila()
        If dgvAnalisisComparativo.Rows.Count > 0 Then
            For a As Integer = 0 To dgvAnalisisComparativo.Rows.Count - 1
                If dgvAnalisisComparativo.Rows(a).Cells("Proveedor").Value = Trim(LblRazonSocial.Text & "") Then
                    dgvAnalisisComparativo.Rows(a).CellAppearance.BackColor = Color.Brown
                    dgvAnalisisComparativo.Rows(a).CellAppearance.ForeColor = Color.White
                End If
            Next
        End If
    End Sub
#End Region

#End Region       '   Funciones Locales

#Region "Funciones Publicas"

#Region "Grabar"
    Public Sub Grabar()
        Cia1.Focus()
        If RbAprobacionOC.Checked = True And TabAprobacionOC.Tabs("Aprobar").Selected = True Then
            If MsgBox("¿Esta Seguro de APROBAR la(s) O/C?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                If dgvOC.Rows.Count > 0 Then
                    For i As Integer = 0 To dgvOC.Rows.Count - 1
                        If dgvOC.Rows(i).Cells("Action").Value = 1 Then
                            aprob = New ETAprobacionFirmaMonto
                            With Entidad.AprobacionFirmaMonto
                                .Cod_Cia = Companhia
                                .User_crea = User_Sistema
                                .Nro_OC = dgvOC.Rows(i).Cells("NroOC").Value
                            End With
                            Aprobacion.Add(aprob)
                        End If
                    Next

                    Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                    Entidad.Resultado = Negocio.AprobacionFirmaMontoBL.GrabarAprobacionOC(Aprobacion)
                    Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

                    If Entidad.Resultado.Realizo = True Then
                        MsgBox("La APROBACIÓN(es) se realizó con éxito.", MsgBoxStyle.Information, "Comacsa")
                    End If
                    Aprobacion = New List(Of ETAprobacionFirmaMonto)
                    Call Actualizar()
                End If
            End If
        ElseIf RbAnularOC.Checked = True And TabAprobacionOC.Tabs("Aprobar").Selected = True Then
            If MsgBox("¿Esta Seguro de DESAPROBAR la(s) O/C ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                For i As Integer = 0 To dgvOC.Rows.Count - 1
                    If dgvOC.Rows(i).Cells("Action").Value = 0 Then
                        aprob = New ETAprobacionFirmaMonto
                        With aprob
                            .Cod_Cia = Companhia
                            .User_crea = User_Sistema
                            .Nro_OC = dgvOC.Rows(i).Cells("NroOC").Value
                        End With
                        Aprobacion.Add(aprob)
                    End If
                Next

                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                Entidad.Resultado = Negocio.AprobacionFirmaMontoBL.GrabarAnularAprobacionOC(Aprobacion)
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

                If Entidad.Resultado.Realizo = True Then
                    MsgBox("La DESAPROBACIÓN(es) se realizó con éxito.", MsgBoxStyle.Information, "Comacsa")
                End If

                Aprobacion = New List(Of ETAprobacionFirmaMonto)

                Call Actualizar()
            End If
        End If

    End Sub


#End Region

#Region "Buscar"
    Public Sub Buscar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call ListarOC()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
#End Region

#Region "Actualizar"
    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call ListarOC()
        TabAprobacionOC.Tabs("Aprobar").Selected = True
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
#End Region

#End Region      '   Funciones Publicas

#Region "Load"
    Private Sub FrmAprobacionOC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RbAprobacionOC.Checked = True
        DtInicio.Value = Now
        DtFin.Value = Now
        Call ListarCia(Cia1)
        Call ListarOC()
    End Sub
#End Region                    '   Load

#Region "Eventos Controles"

#Region "ChkTodos - CheckedChanged"
    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If dgvOC.Rows.Count > 0 Then
            If ChkTodos.Checked = True Then
                For j As Integer = 0 To dgvOC.Rows.Count - 1
                    dgvOC.Rows(j).Cells("Action").Value = True
                Next
            Else
                For j As Integer = 0 To dgvOC.Rows.Count - 1
                    dgvOC.Rows(j).Cells("Action").Value = False
                Next
            End If
        End If
    End Sub
#End Region

#Region "RbAprobacionOC - CheckedChanged"
    Private Sub RbAprobacionOC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAprobacionOC.CheckedChanged
        LblMensaje.Appearance.BackColor = Color.LightSkyBlue
        RbAnularOC.BackColor = Color.LightSkyBlue
        RbAprobacionOC.BackColor = Color.LightSkyBlue
        ChkTodos.BackColor = Color.LightSkyBlue
        LblMensaje.Text = "APROBACIÓN DE OC"
        Call ListarOC()
        ChkTodos.Checked = False
    End Sub
#End Region

#Region "RbAnularOC - CheckedChanged"
    Private Sub RbAnularOC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbAnularOC.CheckedChanged
        LblMensaje.Appearance.BackColor = Color.RoyalBlue
        RbAnularOC.BackColor = Color.RoyalBlue
        RbAprobacionOC.BackColor = Color.RoyalBlue
        ChkTodos.BackColor = Color.RoyalBlue
        LblMensaje.Text = "ANULAR APROBACIÓN DE OC"
        Call ListarOC()
        ChkTodos.Checked = True
    End Sub
#End Region

#Region "dgvOC - DoubleClickRow"
    Private Sub dgvOC_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvOC.DoubleClickRow
        If dgvOC.Rows.Count > 0 Then
            With Entidad.OrdenCompra
                .Cod_Cia = Companhia
                .Nro_OC = e.Row.Cells("NroOC").Value
            End With
            dgvDetalleOC.DataSource = Negocio.OrdenCompraBL.ListarDetalleOC(Entidad.OrdenCompra)

            If dgvDetalleOC.Rows.Count > 0 Then
                TabAprobacionOC.Tabs("Detalle").Selected = True
                GrpCuadorComparativo.Visible = False
                LblProveedor.Text = e.Row.Cells("CodigoProveedor").Value + " - " + e.Row.Cells("Proveedor").Value
                dtFechaOC.Value = e.Row.Cells("Fecha").Value
                LblOC.Text = e.Row.Cells("NroOC").Value
                LblMoneda.Text = e.Row.Cells("Moneda").Value
                LblImporte.Text = e.Row.Cells("Importe").Value
                Call DatosCuadroComparativo(LblOC.Text, "", 2)
            Else
                MsgBox("La Orden de Compra N° " & e.Row.Cells("NroOC").Value & "  no tiene Detalle ", vbExclamation, "Comacsa")
            End If
        End If

    End Sub

#End Region

#Region "dgvDetalleOC - DoubleClickRow"
    Private Sub dgvDetalleOC_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvDetalleOC.DoubleClickRow
        If dgvDetalleOC.Rows.Count > 0 Then
            GrpTopMejores.Visible = True
            LblProducto.Text = e.Row.Cells("Descripcion").Value
            LblCodigo.Text = e.Row.Cells("Codigo").Value
            LblUM.Text = e.Row.Cells("UM").Value
            LblMonedaOC.Text = e.Row.Cells("Moneda").Value
            LblPrecioOC.Text = e.Row.Cells("Precio").Value

            With Entidad.Producto
                .Cod_Cia = Companhia
                .CodProducto = Trim(LblCodigo.Text & "")
                .Unidad = Trim(LblUM.Text & "")
                .Moneda = Trim(LblMonedaOC.Text & "")
            End With
            dgvMejoresProveedores.DataSource = Negocio.OrdenCompraBL.ListarTopMejores(Entidad.Producto)
        End If
    End Sub
#End Region

#Region "btnSalir - Click"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        GrpTopMejores.Visible = False
    End Sub
#End Region

#Region "dgvDetalleOC - Click"
    Private Sub dgvDetalleOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetalleOC.Click
        GrpCuadorComparativo.Visible = True
    End Sub
#End Region

#Region "TabAprobacionOC - SelectedTabChanged"
    Private Sub TabAprobacionOC_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabAprobacionOC.SelectedTabChanged

        If TabAprobacionOC.Tabs("CuadroComparativo").Selected = True And GrpCuadorComparativo.Visible = False Then
            MsgBox("Debe seleccionar un producto para visualizar su cuadro comparativo.", MsgBoxStyle.Critical, "Comacsa")
            TabAprobacionOC.Tabs("Detalle").Selected = True
            Return
        End If

        If TabAprobacionOC.Tabs("CuadroComparativo").Selected = True Then
            If dgvDetalleOC.Rows.Count > 0 Then
                Call DatosCuadroComparativo(LblOC.Text, dgvDetalleOC.ActiveRow.Cells("Codigo").Value, 3)
                Call DatosCuadroComparativo(LblOC.Text, dgvDetalleOC.ActiveRow.Cells("Codigo").Value, 4)
                Call DatosCuadroComparativo(LblOC.Text, dgvDetalleOC.ActiveRow.Cells("Codigo").Value, 5)
                Call DatosCuadroComparativo(LblOC.Text, dgvDetalleOC.ActiveRow.Cells("Codigo").Value, 6)

                Call PintarFila()
            End If
        End If
    End Sub
#End Region

#End Region       '   Eventos Controles

    '#Region "Enviar Correo Electronico"
    '    Private Sub CorreoElectronico()
    '        'creamos un nuevo mensaje de correo
    '        Dim correo As New MailMessage

    '        smtp()

    '        'De
    '        correo.From = New MailAddress("sistemas@comacsa.com.pe")

    '        'Para
    '        correo.To.Add("mvilca@comacsa.com.pe")

    '        'Asunto
    '        correo.Subject = "Producto Monto"

    '        'Cuerpo del correo
    '        correo.Body = "Prueba"

    '        'Mostrar como HTML
    '        correo.IsBodyHtml = False

    '        'Prioridad de el correo
    '        correo.Priority = MailPriority.Normal

    '        'acto seguido le indicamos cual servidor utilizaremos
    '        'aqu&#236; usaremos por default a gmail y su puerto SMTP
    '        'pero en una futura entrega les mostrar&#233; como hacerlo
    '        'cn cualquier servidor

    '        Dim smtp As New SmtpClient()

    '        smtp.Host = "comacsa.com.pe"

    '        smtp.Port = 25

    '        ' smtp.Credentials = New System.Net.NetworkCredential("mvilca@comacsa.com.pe", "mvilca1")


    '        ' smtp.EnableSsl = True

    '        Try

    '            'listo tenemos la estructura de nuestro mensaje armada ahora enviemosla a nuestro destinatario y listo

    '            smtp.Send(correo)

    '            MsgBox("Mensaje enviado satisfactoriamente")

    '        Catch ex As Exception

    '            MsgBox("ERROR: " & ex.Message)

    '        End Try

    '    End Sub
    '#End Region

End Class