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
Public Class FrmCosto_ListaCantera
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
    Public ayo As Int32
    Public mes As Int32

    Private Sub FrmCosto_ListaCantera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = ayo
        _objEntidad.Mes = mes
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Costo_ListaCantera(_objEntidad)
        Call CargarUltraGridxBinding(Me.gridcostoproducto, Source1, dtDatos)
    End Sub

    Private Sub gridcostoproducto_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridcostoproducto.DoubleClickRow
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If sender IsNot gridcostoproducto Then Return
            If e.Row.IsFilterRow Then Return
            SeleccionarConcepto(e.Row)
        Catch ex As Exception

        End Try
    End Sub
    Sub SeleccionarConcepto(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If
        codProducto = uRow.Cells("COD_CANTERA").Value
        Producto = uRow.Cells("CANTERA").Value
        Me.Close()
    End Sub

End Class