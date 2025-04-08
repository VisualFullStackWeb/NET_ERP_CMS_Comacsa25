Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmListaProductos
    Public tipo_prod As String = ""
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
    Public cadena As String = String.Empty
    Public tipo As Int32 = 0
    Public cadenaDetalle As String = String.Empty
    Dim fila As Int32 = 0
#End Region

    Private Sub FrmListaProductos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        If tipo_prod = "V" Then
            Entidad.MyLista = Negocio.NEntregas.ListarProductosVTA()
        Else
            Entidad.MyLista = Negocio.NEntregas.ListarProductos()
        End If
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridConceptos, Source1, Ls_Entrega)
    End Sub

    Private Sub gridConceptos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConceptos.DoubleClickRow
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If sender IsNot gridConceptos Then Return
            If e.Row.IsFilterRow Then Return
            SeleccionarConcepto(e.Row)
        Catch ex As Exception

        End Try
    End Sub

    Sub SeleccionarConcepto(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If
        codProducto = uRow.Cells("CodProducto").Value
        Producto = uRow.Cells("Producto").Value
        Me.Close()
    End Sub

    Private Sub gridConceptos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "CodProducto" OrElse uColumn.Key = "Producto") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
End Class