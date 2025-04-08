Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmCuentaContable
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
        codCuenta = uRow.Cells("codCuenta").Value
        Cuenta = uRow.Cells("Cuenta").Value
        Me.Close()

    End Sub

    Private Sub gridConceptos_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "codCuenta" OrElse uColumn.Key = "Cuenta") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
        'e.Layout.Bands(0).ColumnFilters("codCuenta").FilterConditions.Add(FilterComparisionOperator.Equals, filtroDescripcion)
    End Sub

    Private Sub FrmCuentaContable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarDatos()
        Dim fila As Int32 = 0
        If gridConceptos.Rows.Count > 0 Then
            For i As Int32 = 0 To gridConceptos.Rows.Count - 1
                Dim inicioDescripcion As String = String.Empty
                inicioDescripcion = Me.gridConceptos.Rows(i).Cells("codCuenta").Value.ToString.Substring(0, 1)
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
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarCuentaContable()
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridConceptos, Source1, Ls_Entrega)
    End Sub

    Private Sub gridConceptos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridConceptos.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If e.KeyValue = Keys.Return Then
                If gridConceptos.ActiveRow.Index < 0 Then MsgBox("Seleccione cuenta", MsgBoxStyle.Exclamation, msgComacsa) : Return
                codCuenta = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("codCuenta").Value
                Cuenta = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("Cuenta").Value
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class