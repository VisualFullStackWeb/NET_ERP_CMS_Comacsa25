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
Public Class FrmMesesProduccion
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
    Private Sub txtcodProd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodProd.KeyDown
        Try
            If e.KeyValue = 13 Then
                Procesar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub Procesar()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.CodProducto = txtcodProd.Text
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Costo_MesesProduccion(_objEntidad)
        Call CargarUltraGridxBinding(gridProduccion, Source1, dtDatos)
    End Sub
    Sub Buscar()
        Dim frm As New FrmListaProductos
        frm.ShowDialog()
        If Not codProducto = "" Then
            txtcodProd.Text = codProducto
            Procesar()
        End If
    End Sub

    Private Sub txtcodProd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodProd.ValueChanged

    End Sub
End Class