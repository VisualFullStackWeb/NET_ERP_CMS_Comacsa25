Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FrmEntregar

    Public Ls_Permisos As New List(Of Integer)


#Region "Load"
    Private Sub FrmEntregar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarArea_General(CboArea)
        Call ListarAlmacen_General(CboAlmacen)
        Call ListarRequisicion()
        TabEntregar.Tabs("Entregar").Enabled = False

        dgvEntregar1.DisplayLayout.Bands(0).Columns("Entrega").CellAppearance.BackColor = Color.Lavender
        dgvEntregar1.DisplayLayout.Bands(0).Columns("Entrega").CellAppearance.ForeColor = Color.Blue

        dgvEntregar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.BackColor = Color.LemonChiffon
        dgvEntregar3.DisplayLayout.Bands(0).Columns("CantidadSolicitada").CellAppearance.ForeColor = Color.Blue

        dgvEntregar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").CellAppearance.BackColor = Color.LightBlue
        dgvEntregar3.DisplayLayout.Bands(0).Columns("CantidadAutorizada").CellAppearance.ForeColor = Color.Blue

        dgvEntregar3.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.BackColor = Color.LightCyan
        dgvEntregar3.DisplayLayout.Bands(0).Columns("CantidadAtendida").CellAppearance.ForeColor = Color.Blue

        dgvEntregar3.DisplayLayout.Bands(0).Columns("CantidadRequerida").CellAppearance.BackColor = Color.Linen
        dgvEntregar3.DisplayLayout.Bands(0).Columns("CantidadRequerida").CellAppearance.ForeColor = Color.Blue


    End Sub
#End Region                'Load

#Region "Funciones Locales"

#Region "Imprimir Salida Orden"

    Private Sub ImprimirSalidaOrden()

        Dim Reporte As New Rpt_SalidaAlmacen
        StrucForm.FxSalidaOrden = New Rpt_SalidaAlmacen
        gDocumentoAtender = Trim(TxtNumeroRequisicion.Text & "")
        gDocumentoSalidaOrden = Trim(TxtSalidaOrden.Text & "")
        If TxtNumeroRequisicion.Text = "" Then
            gDocumentoAtender = dgvEntregar1.ActiveRow.Cells("Codigo").Value
        End If
        If TxtSalidaOrden.Text = "" Then
            gDocumentoSalidaOrden = dgvEntregar1.ActiveRow.Cells("SalidaOrden").Value
        End If

        StrucForm.FxSalidaOrden.NombreReporte = "Salida x Orden [" & Trim(dgvEntregar1.ActiveRow.Cells("SalidaOrden").Value) & "]"
        StrucForm.FxSalidaOrden.MdiParent = MdiParent
        StrucForm.FxSalidaOrden.Show()

    End Sub

#End Region

#Region "Validar para Grabar"
    Private Function Validar() As Boolean
        If TxtNombreUsuarioRecojo.Text = "" Then
            MsgBox("Debe de VALIDAR el Usuario de Recojo para continuar.", MsgBoxStyle.Critical, "Comacsa")
            BtnUserRecojo.Focus()
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Listar Requisicion"
    Private Sub ListarRequisicion()
        With Entidad.Pedido
            .Sistema = gSistema
        End With
        Dim dx As New DataTable
        dx = Negocio.PedidoBL.Listar_PedidoEntregar(Entidad.Pedido, "LE")

        If dx.Rows.Count > 0 Then
            dgvEntregar1.DataSource = dx
        End If
    End Sub

#End Region

#Region "Solo Numeros"
    Private Sub SoloNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 13 Or AscW(e.KeyChar) = 8) Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "Limpiar"
    Private Sub Limpiar()
        TxtCodigoUserRecojo.Clear()
        TxtNombreUsuarioRecojo.Clear()
        txtObservaciones.Clear()
    End Sub
#End Region

#End Region   'Funciones Locales

#Region "Funciones Globales"

#Region "Grabar"
    Public Sub Grabar()
        If Validar() = False Then Return
        If MsgBox("¿Esta Seguro de ENTREGAR el Requerimiento ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            Try
                With Entidad.Pedido
                    .Cod_Cia = Companhia
                    .Tipo_Doc = "RAL"
                    .Numero_Doc = TxtNumeroRequisicion.Text
                    .Estado = "E"
                    .Observaciones = Trim(txtObservaciones.Text & "")

                    With Entidad.Pedido
                        .Cod_Cia = Companhia
                        .Numero_Doc = Trim(TxtNumeroRequisicion.Text & "")
                        .SalidaOrden = Trim(TxtSalidaOrden.Text & "")
                        .User_Recibe = Trim(TxtCodigoUserRecojo.Text & "")
                        .User = User_Sistema
                    End With

                    Entidad.Resultado = Negocio.PedidoBL.GrabarEntrega(Entidad.Pedido)


                    If Entidad.Resultado.Realizo = True Then
                        MsgBox("La ENTREGA de la Requisición " + TxtSalidaOrden.Text + " se realizo con éxito.", MsgBoxStyle.Information, "Comacsa")
                    Else
                        MsgBox("La ENTREGA de la Requisición " + TxtSalidaOrden.Text + " NO se pudo realizar.", MsgBoxStyle.Critical, "Comacsa")
                        Return
                    End If


                    If dgvEntregar1.ActiveRow.Cells("SalidaOrden").Value = "" Then
                        MsgBox("NO hay Salida de Orden x Imprimir.", MsgBoxStyle.Information, "Comacsa")
                    Else
                        Call ImprimirSalidaOrden()
                    End If

                End With
                Call ListarRequisicion()
                TabEntregar.Tabs("Listar").Selected = True
                Call Limpiar()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            Return
        End If
    End Sub
#End Region

#Region "Reporte"
    Public Sub Reporte()
        If dgvEntregar1.ActiveRow.Cells("Estado").Value = "ENTREGADO" Then
            If dgvEntregar1.ActiveRow.Cells("SalidaOrden").Value = "" Then
                MsgBox("NO hay Salida de Orden x Imprimir.", MsgBoxStyle.Information, "Comacsa")
            Else
                Call ImprimirSalidaOrden()
            End If
        Else
            MsgBox("El Requerimiento debe estar ENTREGADO para poder IMPRIMIR.", MsgBoxStyle.Critical, "Comacsa")
            Return
        End If
    End Sub
#End Region

#End Region  'Funciones Globales

#Region "Eventos Controles"

#Region "Grilla dgvEntregar1 DoubleClickRow"
    Private Sub dgvEntregar1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvEntregar1.DoubleClickRow
        If dgvEntregar1.Rows.Count = 0 Then
            Return
        End If

        TabEntregar.Tabs("Entregar").Selected = True
        TabEntregar.Tabs("Entregar").Enabled = True

        dtRegistro.Value = e.Row.Cells("Fecha").Value
        TxtNumeroRequisicion.Text = e.Row.Cells("Codigo").Value
        TxtUserSolicita.Text = e.Row.Cells("CodigoUsuario").Value
        TxtNombreSolicita.Text = e.Row.Cells("NombreUsuario").Value
        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        CboArea.Text = e.Row.Cells("CodigoArea").Value
        dtEntrega.Value = e.Row.Cells("Entrega").Value
        TxtNombreUsuarioRecojo.Text = e.Row.Cells("NombreRecibe").Value
        TxtCodigoUserRecojo.Text = e.Row.Cells("UserRecibe").Value
        txtObservaciones.Text = Trim(e.Row.Cells("Observaciones").Value & "")
        TxtSalidaOrden.Text = Trim(e.Row.Cells("SalidaOrden").Value & "")

        If e.Row.Cells("CodigoEstado").Value = "LR" Then
            LblEstado.Text = "LISTO PARA RECOJO"
        Else
            LblEstado.Text = "ENTREGADO"
        End If

        With Entidad.Pedido
            .Numero_Doc = Trim(TxtNumeroRequisicion.Text & "")
            .SalidaOrden = Trim(TxtSalidaOrden.Text & "")
        End With

        dgvEntregar3.DataSource = Negocio.PedidoBL.ListarDetallePedido(Entidad.Pedido, "LENT")

    End Sub

#End Region

#Region "Boton User Recojo"
    Private Sub BtnUserRecojo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUserRecojo.Click
        If CboArea.Value <> 0 Then
            Companhia = Companhia
            gArea = CboArea.Value
            Dim UserRecojo As New FrmValidarUsuarioRecojo
            UserRecojo.ShowDialog()
            TxtCodigoUserRecojo.Text = Trim(GCodigoUsuarioRecojo & "")
            TxtNombreUsuarioRecojo.Text = Trim(GUsuarioRecojo & "")
        Else
            MsgBox("Debe seleccionar un Area", MsgBoxStyle.Information, "Comacsa")
            CboArea.Focus()
            Return
        End If
    End Sub
#End Region

#Region "Tab SelectedTabChanged"
    Private Sub TabEntregar_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabEntregar.SelectedTabChanged
        If TabEntregar.Tabs("Listar").Selected = True Then
            TabEntregar.Tabs("Entregar").Enabled = False
        End If
    End Sub
#End Region

#Region "Evento_Activated"
    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub
#End Region

#End Region   'Eventos Controles

End Class