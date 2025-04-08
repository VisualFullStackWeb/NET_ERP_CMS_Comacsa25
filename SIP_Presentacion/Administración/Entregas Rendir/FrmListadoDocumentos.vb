Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmListadoDocumentos
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
    Private Sub FrmListadoDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarDatos()
        Dim fila As Int32 = 0
        If gridDocumentos.Rows.Count > 0 Then
            For i As Int32 = 0 To gridDocumentos.Rows.Count - 1
                Dim inicioDescripcion As String = String.Empty
                inicioDescripcion = Me.gridDocumentos.Rows(i).Cells("Descripcion").Value.ToString.Substring(0, 1)
                If inicioDescripcion = filtroDescripcion Then
                    fila = i
                    Exit For
                End If
            Next
            Me.gridDocumentos.ActiveRow = Me.gridDocumentos.Rows(fila)
        End If
    End Sub

    Private Sub CargarDatos()
        'Entidad.Entregas = New ETEntregas
        'Entidad.Entregas.TipoOperacion = Ope
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarDocumentos()
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridDocumentos, Source1, Ls_Entrega)
    End Sub

    Private Sub gridDocumentos_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridDocumentos.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridDocumentos Then Return
        If e.Row.IsFilterRow Then Return
        SeleccionarDocumento(e.Row)
    End Sub

    Sub SeleccionarDocumento(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If
        codTipoDoc = uRow.Cells("codTipoDoc").Value
        TipoDoc = uRow.Cells("TipoDoc").Value
        TipoDoc = uRow.Cells("TipoDoc").Value
        flgcompra = uRow.Cells("flgcompra").Value
        'ConceptoSeleccionado = uRow.Cells("TipoDoc").Value
        Me.Close()

    End Sub

    Private Sub gridDocumentos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDocumentos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "codTipoDoc" OrElse uColumn.Key = "TipoDoc" OrElse uColumn.Key = "Descripcion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub gridDocumentos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDocumentos.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            With sender
                Select Case e.KeyValue
                    Case 32
                        If Me.gridDocumentos.ActiveRow.Cells("Action").Value = True Then
                            Me.gridDocumentos.ActiveRow.Cells("Action").Value = False
                        Else
                            Me.gridDocumentos.ActiveRow.Cells("Action").Value = True
                        End If
                    Case Keys.Up
                    Case Keys.Down
                        If Me.gridDocumentos.ActiveRow.Index < 0 Then
                            Me.gridDocumentos.ActiveRow = Me.gridDocumentos.Rows(0)
                            e.Handled = Boolean.TrueString
                        End If
                    Case Keys.Right
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Left
                        .PerformAction(ExitEditMode)
                        .PerformAction(PrevCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Return
                        If gridDocumentos.ActiveRow.Index < 0 Then MsgBox("Seleccione documento", MsgBoxStyle.Exclamation, msgComacsa) : Return
                        codTipoDoc = gridDocumentos.Rows(gridDocumentos.ActiveRow.Index).Cells("codTipoDoc").Value
                        TipoDoc = gridDocumentos.Rows(gridDocumentos.ActiveRow.Index).Cells("TipoDoc").Value
                        flgcompra = gridDocumentos.Rows(gridDocumentos.ActiveRow.Index).Cells("flgcompra").Value
                        Me.Close()
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class