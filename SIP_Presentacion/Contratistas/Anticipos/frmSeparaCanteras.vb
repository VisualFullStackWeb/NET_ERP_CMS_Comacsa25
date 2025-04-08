Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmSeparaCanteras
    Public codprov As String
    Public montoAnticipo As Double
    Public dtCanteras As New DataTable
    Public Sub CargarDatos()
        Try
            Dim objNegocio As NGContratista = Nothing
            Dim objEntidad As ETContratista = Nothing
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._codprov = codprov
            Dim dtContratista As New DataTable
            dtContratista = objNegocio.ListarCanteraAnticipo(objEntidad)
            If dtCanteras.Rows.Count > 0 Then
                Call CargarUltraGridxBinding(gridcontratista, Source1, dtCanteras)
            Else
                Call CargarUltraGridxBinding(gridcontratista, Source1, dtContratista)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmSeparaCanteras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    End Sub

    Private Sub frmSeparaCanteras_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub
    Private Sub gridcontratista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridcontratista.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridcontratista) Then Return
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
                        'If gridconceptos.ActiveRow.Cells(gridconceptos.ActiveCell.Column.Index).Column.Key = "TOTAL" Then
                        'End If
                        If gridcontratista.ActiveRow.Cells("MONTO").Value <> 0 Then
                            gridcontratista.ActiveRow.Cells("Action").Value = True
                        Else
                            gridcontratista.ActiveRow.Cells("Action").Value = False
                        End If

                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        'CalcularTotalComprobantes()
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        'If Not validarCanteras() Then Exit Sub
        'dtCanteras = New DataTable
        'If dtCanteras.Columns.Count <= 0 Then
        '    dtCanteras.Columns.Add("Action")
        '    dtCanteras.Columns.Add("CODCANTERA")
        '    dtCanteras.Columns.Add("DESCRIPCION")
        '    dtCanteras.Columns.Add("MONTO")
        'End If
        'Dim dr As DataRow
        'For i As Int32 = 0 To gridcontratista.Rows.Count - 1
        '    dr = dtCanteras.NewRow
        '    dr(0) = gridcontratista.Rows(i).Cells("Action").Value 'IIf(gridcontratista.Rows(i).Cells("Action").Value.ToString = "True", 1, 0)
        '    dr(1) = gridcontratista.Rows(i).Cells("CODCANTERA").Value
        '    dr(2) = gridcontratista.Rows(i).Cells("DESCRIPCION").Value
        '    dr(3) = gridcontratista.Rows(i).Cells("MONTO").Value
        '    dtCanteras.Rows.Add(dr)
        'Next
        Me.Close()
    End Sub
    Function validarCanteras() As Boolean
        gridcontratista.PerformAction(ExitEditMode)
        Dim monto As Double = 0
        Dim cont As Int32 = 0
        For i As Int32 = 0 To gridcontratista.Rows.Count - 1
            'If gridcontratista.Rows(i).Cells("Action").Value.ToString = "True" Then
            cont = cont + 1
            If gridcontratista.Rows(i).Cells("MONTO").Value <> 0 Then
                gridcontratista.Rows(i).Cells("Action").Value = True
            Else
                gridcontratista.Rows(i).Cells("Action").Value = False
            End If
            monto = monto + CDbl(gridcontratista.Rows(i).Cells("MONTO").Value)
            monto = Math.Round(monto, 2)
            'If gridcontratista.Rows(i).Cells("MONTO").Value <= 0 Then
            '    MsgBox("Debe ingresar monto válido en la fila " & i + 1, MsgBoxStyle.Exclamation, msgComacsa)
            '    Return False
            'Else
            '    monto = monto + gridcontratista.Rows(i).Cells("MONTO").Value
            'End If
            'End If
        Next
        'If cont > 0 Then
        If Math.Abs(CDbl(montoAnticipo - monto)) > 0.0 Then
            MsgBox("El monto disgregado debe ser igual al monto total del anticipo " & _
                   vbCrLf & "Monto anticipo      :  " & CDbl(montoAnticipo).ToString("###0.00") & _
                   vbCrLf & "Monto disgregado :  " & CDbl(monto).ToString("###0.00"), MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If
        'End If
        Return True
    End Function

    Private Sub frmSeparaCanteras_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not validarCanteras() Then e.Cancel = True
        dtCanteras = New DataTable
        If dtCanteras.Columns.Count <= 0 Then
            dtCanteras.Columns.Add("Action")
            dtCanteras.Columns.Add("CODCANTERA")
            dtCanteras.Columns.Add("DESCRIPCION")
            dtCanteras.Columns.Add("MONTO")
            dtCanteras.Columns.Add("ID_SUPERVISOR")
        End If
        Dim dr As DataRow
        For i As Int32 = 0 To gridcontratista.Rows.Count - 1
            dr = dtCanteras.NewRow
            dr(0) = gridcontratista.Rows(i).Cells("Action").Value 'IIf(gridcontratista.Rows(i).Cells("Action").Value.ToString = "True", 1, 0)
            dr(1) = gridcontratista.Rows(i).Cells("CODCANTERA").Value
            dr(2) = gridcontratista.Rows(i).Cells("DESCRIPCION").Value
            dr(3) = gridcontratista.Rows(i).Cells("MONTO").Value
            dr(4) = gridcontratista.Rows(i).Cells("ID_SUPERVISOR").Value
            dtCanteras.Rows.Add(dr)
        Next
    End Sub
End Class