Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmDatosComprobantes
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
    Public cod_Area As String = String.Empty
#End Region
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "codConcepto" OrElse uColumn.Key = "Descripcion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub FrmDatosComprobantes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarDatos()
        Dim fila As Int32 = 0
        If gridConceptos.Rows.Count > 0 Then
            For i As Int32 = 0 To gridConceptos.Rows.Count - 1
                Dim inicioDescripcion As String = String.Empty
                inicioDescripcion = Me.gridConceptos.Rows(i).Cells("Descripcion").Value.ToString.Substring(0, 1)
                If inicioDescripcion = filtroDescripcion Then
                    fila = i
                    Exit For
                End If
            Next
            Me.gridConceptos.ActiveRow = Me.gridConceptos.Rows(fila)
        End If

    End Sub
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.codArea = cod_Area
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarConceptosxArea(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridConceptos, Source1, Ls_Entrega)
    End Sub

    Private Sub gridConceptos_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConceptos.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridConceptos Then Return
        If e.Row.IsFilterRow Then Return
        SeleccionarConcepto(e.Row)
    End Sub
    Sub SeleccionarConcepto(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If
        codConcepto = uRow.Cells("codConcepto").Value
        Concepto = uRow.Cells("Descripcion").Value
        ConceptoSeleccionado = uRow.Cells("Descripcion").Value
        Me.Close()
    End Sub

    Private Sub gridConceptos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridConceptos.KeyDown
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If e.KeyValue = Keys.Return Then
            If gridConceptos.ActiveRow.Index < 0 Then MsgBox("Seleccione un concepto", MsgBoxStyle.Exclamation, msgComacsa) : Return
            codConcepto = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("codConcepto").Value
            Concepto = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("Descripcion").Value
            ConceptoSeleccionado = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("Descripcion").Value
            Me.Close()
        End If
    End Sub
End Class