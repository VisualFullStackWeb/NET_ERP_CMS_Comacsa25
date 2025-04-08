Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmAreas
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
    Private Sub FrmAreas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarDatos()
        Dim fila As Int32 = 0
        If gridConceptos.Rows.Count > 0 Then
            For i As Int32 = 0 To gridConceptos.Rows.Count - 1
                Dim inicioDescripcion As String = String.Empty
                inicioDescripcion = Me.gridConceptos.Rows(i).Cells("Area").Value.ToString.Substring(0, 1)
                If inicioDescripcion = filtroDescripcion Then
                    fila = i
                    Exit For
                End If
            Next
            Me.gridConceptos.ActiveRow = Me.gridConceptos.Rows(fila)
            'gridConceptos.PerformAction(ExitEditMode)
            'gridConceptos.PerformAction(AboveCell)
            'gridConceptos.PerformAction(EnterEditMode)
        End If
    End Sub
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarCentroCosto()
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridConceptos, Source1, Ls_Entrega)
    End Sub

    Private Sub gridConceptos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConceptos.DoubleClickRow
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
        codArea = uRow.Cells("codArea").Value
        Area = uRow.Cells("Area").Value
        Me.Close()

    End Sub

    Private Sub gridConceptos_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "codArea" OrElse uColumn.Key = "Area") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub gridConceptos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridConceptos.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            With sender
                Select Case e.KeyValue
                    Case 32
                        If Me.gridConceptos.ActiveRow.Cells("Action").Value = True Then
                            Me.gridConceptos.ActiveRow.Cells("Action").Value = False
                        Else
                            Me.gridConceptos.ActiveRow.Cells("Action").Value = True
                        End If
                    Case Keys.Up
                    Case Keys.Down
                        If Me.gridConceptos.ActiveRow.Index < 0 Then
                            Me.gridConceptos.ActiveRow = Me.gridConceptos.Rows(0)
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
                        If gridConceptos.ActiveRow.Index < 0 Then MsgBox("Seleccione un Área", MsgBoxStyle.Exclamation, msgComacsa) : Return
                        codArea = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("codArea").Value
                        Area = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("Area").Value
                        Me.Close()
                End Select
            End With
        Catch ex As Exception

        End Try

    End Sub
End Class