Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class FrmIngresoReciboAgua
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Public ConceptoSeleccionado As String
    Public filtroDescripcion As String = String.Empty
#End Region
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Dim cierre As Int32
    Public ayo As Int32
    Public mes As Int32

    Private Sub FrmIngresoReciboAgua_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Costo_ListaDocumentos(_objEntidad)
        Call CargarUltraCombo(cmbtipodoc, dtDatos, "cod_maestro2", "descripcion")
        cmbtipo.SelectedIndex = 0
    End Sub

    Private Sub txtcantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcantidad.KeyDown
        If e.KeyData = Keys.Return Then
            txtimporte.Focus()
        End If
    End Sub

    Private Sub txtcantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtimporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtimporte.KeyDown
        If e.KeyData = Keys.Return Then
            txtobservacion.Focus()
        End If
    End Sub

    Private Sub txtimporte_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtimporte.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtserie_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtserie.GotFocus
        txtserie.Text = txtserie.Text.PadLeft(4, "0")
    End Sub

    Private Sub txtserie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtserie.KeyDown
        If e.KeyData = Keys.Return Then
            txtserie.Text = txtserie.Text.PadLeft(4, "0")
            txtnumero.Focus()
        End If
    End Sub

    Private Sub txtnumero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumero.GotFocus
        txtnumero.Text = txtnumero.Text.PadLeft(16, "0")
    End Sub

    Private Sub txtnumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnumero.KeyDown
        If e.KeyData = Keys.Return Then
            txtnumero.Text = txtnumero.Text.PadLeft(16, "0")
            txtcantidad.Focus()
        End If
    End Sub

    Private Sub cmbtipodoc_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbtipodoc.InitializeLayout
        With cmbtipodoc.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descripcion").Width = sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descripcion") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub btngrabarrecibo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabarrecibo.Click
        Try
            If MsgBox("Desea registrar cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            txtserie.Text = txtserie.Text.PadLeft(4, "0")
            txtnumero.Text = txtnumero.Text.PadLeft(16, "0")
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Operacion = 1
            _objEntidad.TipoRecibo = cmbtipo.Value
            _objEntidad.Anho = ayo
            _objEntidad.Mes = mes
            _objEntidad.tipodoc = cmbtipodoc.Value
            _objEntidad.seriedoc = txtserie.Text
            _objEntidad.numdoc = txtnumero.Text
            _objEntidad.Cantidad = txtcantidad.Text
            _objEntidad.Monto = txtimporte.Text
            _objEntidad.Observacion = txtobservacion.Text

            Dim dtResul As New DataTable
            dtResul = _objNegocio.Costo_IngresoEnergiaGas(_objEntidad)

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class