Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmCanterasUEA
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
    Public UEA As String = String.Empty
    Dim fila As Int32 = 0
#End Region
    Private Sub FrmCanteras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarDatos()
        'Dim arrayCantera As String() = cadena.Split(",")
        'VerificarCantera(arrayCantera)
        'If tipo = 1 Then FiltrarCantera(arrayCantera)
        If gridConceptos.Rows.Count > 0 Then
            For i As Int32 = 0 To gridConceptos.Rows.Count - 1
                Dim inicioDescripcion As String = String.Empty
                inicioDescripcion = Me.gridConceptos.Rows(i).Cells("Cantera").Value.ToString.Substring(0, 1)
                If inicioDescripcion = filtroDescripcion Then
                    fila = i
                    Exit For
                End If
            Next
            Me.gridConceptos.ActiveRow = Me.gridConceptos.Rows(fila)
        End If
    End Sub
    Sub VerificarCantera(ByVal arrayCantera As String())
        If arrayCantera.Count > 0 Then
            For i As Int32 = 0 To gridConceptos.Rows.Count - 1
                For j As Int32 = 0 To arrayCantera.Count - 1
                    If Me.gridConceptos.Rows(i).Cells("codCantera").Value.ToString.Trim = arrayCantera(j).ToString.Trim Then
                        Me.gridConceptos.Rows(i).Cells("Action").Value = True
                    End If
                Next
            Next
        End If
    End Sub
    Sub FiltrarCantera(ByVal arrayCantera As String())
        Ls_Entrega = New List(Of ETEntregas)
        If arrayCantera.Count > 0 Then
            For i As Int32 = gridConceptos.Rows.Count - 1 To 0 Step -1
                For j As Int32 = 0 To arrayCantera.Count - 1
                    If Me.gridConceptos.Rows(i).Cells("codCantera").Value.ToString.Trim = arrayCantera(j).ToString.Trim Then
                        Entidad.Entregas = New ETEntregas
                        Entidad.Entregas.codCantera = Me.gridConceptos.Rows(i).Cells("codCantera").Value.ToString.Trim
                        Entidad.Entregas.Cantera = Me.gridConceptos.Rows(i).Cells("Cantera").Value.ToString.Trim
                        Entidad.Entregas.Region = Me.gridConceptos.Rows(i).Cells("Region").Value.ToString.Trim
                        Ls_Entrega.Add(Entidad.Entregas)
                        Me.gridConceptos.Rows(i).Delete()
                    End If
                Next
            Next
        End If
        Call CargarUltraGrid(gridConceptos, Ls_Entrega)
        Dim array As String() = cadenaDetalle.Split(",")
        VerificarCantera(array)
    End Sub
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.codConcepto = UEA
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarCanterasUEA(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridConceptos, Source1, Ls_Entrega)
    End Sub

    Private Sub gridConceptos_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridConceptos.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridConceptos Then Return
        e.DisplayPromptMsg = Boolean.FalseString
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
        codCantera = uRow.Cells("codCantera").Value
        Cantera = uRow.Cells("Cantera").Value
        'Region = uRow.Cells("Region").Value
        Me.Close()
    End Sub

    Private Sub gridConceptos_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "codCantera" OrElse uColumn.Key = "Cantera" OrElse uColumn.Key = "Region") Then
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
                        If gridConceptos.ActiveRow.Index < 0 Then MsgBox("Seleccione una cantera", MsgBoxStyle.Exclamation, msgComacsa) : Return
                        gridConceptos.PerformAction(ExitEditMode)
                        gridConceptos.PerformAction(EnterEditMode)
                        SeleccionarCanteras()
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        gridConceptos.PerformAction(ExitEditMode)
        gridConceptos.PerformAction(EnterEditMode)
        SeleccionarCanteras()
    End Sub
    Sub SeleccionarCanteras()
        Try
            Dim cont As Int32 = 0
            Dim cadCantera As String = String.Empty
            Dim cadcodCantera As String = String.Empty
            Dim cadRegion As String = String.Empty
            For i As Integer = 0 To gridConceptos.Rows.Count - 1
                If gridConceptos.Rows(i).Cells("Action").Value = True Then
                    cont += 1
                    cadCantera = cadCantera + gridConceptos.Rows(i).Cells("Cantera").Value.ToString.Trim
                    cadcodCantera = cadcodCantera + gridConceptos.Rows(i).Cells("codCantera").Value.ToString.Trim
                    cadRegion = cadRegion + gridConceptos.Rows(i).Cells("Region").Value.ToString.Trim
                    cadCantera = cadCantera + ", "
                    cadcodCantera = cadcodCantera + ", "
                    cadRegion = cadRegion + ", "
                End If
            Next
            If cont = 0 Then
                codCantera = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("codCantera").Value
                Cantera = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("Cantera").Value
                Region = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("Region").Value
            Else
                Cantera = cadCantera.Substring(0, cadCantera.Length - 2)
                codCantera = cadcodCantera.Substring(0, cadcodCantera.Length - 2)
                ModVariable.Region = cadRegion.Substring(0, cadRegion.Length - 2)
            End If
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmCanteras_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'Try
        '    filtroDescripcion = filtroDescripcion & e.KeyData.ToString
        '    If gridConceptos.Rows.Count > 0 Then
        '        For i As Int32 = 0 To gridConceptos.Rows.Count - 1
        '            Dim inicioDescripcion As String = String.Empty
        '            inicioDescripcion = Me.gridConceptos.Rows(i).Cells("Cantera").Value.ToString.Substring(0, filtroDescripcion.Length)
        '            If inicioDescripcion = filtroDescripcion Then
        '                fila = i
        '                Exit For
        '            End If
        '        Next
        '        Me.gridConceptos.ActiveRow = Me.gridConceptos.Rows(fila)
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
End Class