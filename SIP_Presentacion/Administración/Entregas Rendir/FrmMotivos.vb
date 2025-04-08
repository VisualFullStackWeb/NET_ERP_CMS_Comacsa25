Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmMotivos
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
        codMotivodetalle = uRow.Cells("codmotivoDetalle").Value
        Motivodetalle = uRow.Cells("motivoDetalle").Value
        ConceptoSeleccionado = uRow.Cells("Descripcion").Value
        Me.Close()

    End Sub
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridMotivos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "codmotivoDetalle" OrElse uColumn.Key = "motivoDetalle") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Private Sub FrmMotivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarMotivos()
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridMotivos, Source1, Ls_Entrega)
    End Sub

    Private Sub gridMotivos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridMotivos.KeyDown
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If e.KeyValue = Keys.Return Then
            If gridMotivos.ActiveRow.Index < 0 Then MsgBox("Seleccione motivo", MsgBoxStyle.Exclamation, msgComacsa) : Return
            codMotivodetalle = gridMotivos.Rows(gridMotivos.ActiveRow.Index).Cells("codmotivoDetalle").Value
            Motivodetalle = gridMotivos.Rows(gridMotivos.ActiveRow.Index).Cells("motivoDetalle").Value
            'ConceptoSeleccionado = gridMotivos.Rows(gridMotivos.ActiveRow.Index).Cells("Descripcion").Value
            Me.Close()
        End If
    End Sub
End Class