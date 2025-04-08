Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmListadoCombustible
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private TipoG As sTate
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
    Private tipo As Int32 = 0
#End Region

    Private Sub frmListadoCombustible_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarDatos()
        Dim fila As Int32 = 0
    End Sub
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarCombustibleMant()
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
        SubProceso_Combustible(e.Row)
    End Sub
    Sub SubProceso_Combustible(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If
        combustible = uRow.Cells("Combustible").Value
        Me.Close()

    End Sub

    Private Sub gridConceptos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Combustible") Then
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
                        If gridConceptos.ActiveRow.Index < 0 Then MsgBox("Seleccione registro", MsgBoxStyle.Exclamation, msgComacsa) : Return
                        combustible = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("Combustible").Value
                        Me.Close()
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class