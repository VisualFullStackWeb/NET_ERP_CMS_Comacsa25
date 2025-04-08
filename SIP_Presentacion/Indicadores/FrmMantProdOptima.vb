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
Public Class FrmMantProdOptima
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
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista
    Private Sub FrmMantProdOptima_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Procesar()
    End Sub
    Public Sub Procesar()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.ListarProdOptima(objEntidad)
            Call CargarUltraGridxBinding(gridProduccion, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub Nuevo()
        Me.Tab1.Tabs("T02").Selected = True
        Ope = 1
        limpiar()
        txtcodequipo.Focus()
    End Sub

    Sub limpiar()
        txtcodequipo.Clear()
        txtequipo.Clear()
        txtcodproducto.Clear()
        txtproducto.Clear()
        txttonhora.Clear()
    End Sub

    Private Sub gridProduccion_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridProduccion.DoubleClickRow
        Try
            Ope = 2
            txtcodequipo.Text = gridProduccion.ActiveRow.Cells("PLACA").Value.ToString.Trim
            txtequipo.Text = gridProduccion.ActiveRow.Cells("MODELO").Value.ToString.Trim
            txtcodproducto.Text = gridProduccion.ActiveRow.Cells("COD_PROD").Value.ToString.Trim
            txtproducto.Text = gridProduccion.ActiveRow.Cells("PRODUCTO").Value.ToString.Trim
            txttonhora.Text = gridProduccion.ActiveRow.Cells("TONXHORA").Value.ToString.Trim
            Me.Tab1.Tabs("T02").Selected = True
            txttonhora.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Sub buscar()
        If Ope = 2 Then
            Exit Sub
        End If
        If txtcodequipo.Focused = True Then
            Dim frmEquipo As New frmBuscar
            frmEquipo.Formulario = frmBuscar.eState.frm_Catalogo_molino
            frmEquipo.ShowDialog()
            txtcodequipo.Text = frmEquipo.Flag2
            txtequipo.Text = frmEquipo.Descripcion
            frmEquipo = Nothing
            txtcodproducto.Focus()
            Exit Sub
        End If
        If txtcodproducto.Focused = True Then
            Dim frm As New FrmListaProductos
            frm.ShowDialog()
            If Not codProducto = "" Then
                txtcodproducto.Text = codProducto
                txtproducto.Text = Producto
                codProducto = ""
                Producto = ""
                txttonhora.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txttonhora_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttonhora.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Sub Grabar()
        If Me.Tab1.Tabs("T02").Selected = True Then
            Try
                If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Return
                End If
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                objNegocio = New NGContratista
                objEntidad = New ETContratista
                objEntidad._placa = txtcodequipo.Text
                objEntidad._cod_prod = txtcodproducto.Text
                objEntidad._tonxhora = txttonhora.Text
                Dim dtDatos As New DataTable
                dtDatos = objNegocio.MantProdOptima(objEntidad)
                Dim Mensaje As String = "Se grabó con éxito el registro"
                MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
                Call Procesar()
                Me.Tab1.Tabs("T01").Selected = True
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            End Try
        End If
    End Sub
End Class