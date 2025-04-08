Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmListaTransportista
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
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim dtDatos As New DataTable
        dtDatos = Negocio.NEntregas.ListarTransportista_()
        'Entidad.MyLista = Negocio.NEntregas.ListarTransportista()
        'If Entidad.MyLista.Validacion Then
        '    Ls_Entrega = Entidad.MyLista.Ls_Entrega
        'End If
        Call CargarUltraGridxBinding(Me.gridMotivos, Source1, dtDatos)
    End Sub

    Private Sub FrmListaTransportista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarDatos()
    End Sub

    Private Sub gridMotivos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridMotivos.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridMotivos Then Return
        If e.Row.IsFilterRow Then Return
        SeleccionarConcepto(e.Row)
    End Sub
    Sub SeleccionarConcepto(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If
        codMotivodetalle = uRow.Cells("cod_prov").Value
        Motivodetalle = uRow.Cells("razsoc").Value
        Ruc = uRow.Cells("ruc").Value
        Me.Close()

    End Sub
    Private Sub gridMotivos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridMotivos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "cod_prov" OrElse uColumn.Key = "razsoc" OrElse uColumn.Key = "ruc") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub gridMotivos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridMotivos.KeyDown
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If e.KeyValue = Keys.Return Then
            If gridMotivos.ActiveRow.Index < 0 Then MsgBox("Seleccione motivo", MsgBoxStyle.Exclamation, msgComacsa) : Return
            codMotivodetalle = gridMotivos.Rows(gridMotivos.ActiveRow.Index).Cells("cod_prov").Value
            Motivodetalle = gridMotivos.Rows(gridMotivos.ActiveRow.Index).Cells("razsoc").Value
            Ruc = gridMotivos.Rows(gridMotivos.ActiveRow.Index).Cells("ruc").Value
            Me.Close()
        End If
    End Sub
End Class