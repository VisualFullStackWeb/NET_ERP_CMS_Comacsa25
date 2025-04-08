Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmConceptoLiquidacion
#Region "Declarar Variables"
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
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
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
#End Region
    Public total As Double
    Private Ls_Anticipo As List(Of ETContratista) = Nothing
    Public idtrabajador As Int32
    Private Sub frmConceptoLiquidacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtcese.Value = Now.Date
        CargarConceptos()
        gridconceptos.Rows(0).Cells("CONCEPTO").Activate()
        gridconceptos.PerformAction(EnterEditMode)
        'gridconceptos.PerformAction(NextCellByTab)
        'gridconceptos.PerformAction(FirstCellInGrid)
        'gridconceptos.PerformAction(NextCellByTab)
    End Sub
    Sub CargarConceptos()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        objEntidad._idtrabajador = idtrabajador
        dtDatos = objNegocio.ListarConceptoLiquidacion(objEntidad)
        If dtDatos.Rows.Count > 0 Then
            dtcese.Value = dtDatos.Rows(0)("FECHACESE")
            Call CargarUltraGridxBinding(gridconceptos, Source1, dtDatos)
        End If
    End Sub

    Private Sub gridconceptos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridconceptos.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridconceptos) Then Return
            With sender
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Down
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
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
                        .PerformAction(ExitEditMode)
                        'txttotalotros.Text = 0
                        'If gridconceptos.ActiveRow.Cells(gridconceptos.ActiveCell.Column.Index).Column.Key = "TOTAL" Then
                        'calcularTotal()
                        'End If
                        .PerformAction(NextCellByTab)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        'CalcularTotalComprobantes()
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        total = 0
        Ls_Anticipo = New List(Of ETContratista)
        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            'If gridconceptos.Rows(i).Cells("TOTAL").Value > 0 Then
            Entidad.Contratista = New ETContratista
            Entidad.Contratista._idtrabajador = idtrabajador
            Entidad.Contratista._idconcepto = gridconceptos.Rows(i).Cells("ID").Value
            Entidad.Contratista._fechacese = dtcese.Value
            Entidad.Contratista.montoTotal = gridconceptos.Rows(i).Cells("TOTAL").Value
            Ls_Anticipo.Add(Entidad.Contratista)
            'End If
            total = total + gridconceptos.Rows(i).Cells("TOTAL").Value
        Next
        Entidad.Contratista = Negocio.NContratista.InsertaLiquidacionTrabajador(Ls_Anticipo)
        Me.Close()
    End Sub
End Class