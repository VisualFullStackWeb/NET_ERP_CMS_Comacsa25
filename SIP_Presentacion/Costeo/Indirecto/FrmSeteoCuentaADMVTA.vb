Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmSeteoCuentaADMVTA
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Public ayo As Integer
    Private Sub FrmSeteoCuentaADMVTA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        comboTipo()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = ayo
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Costo_ListaSeteoVTAADM(_objEntidad)
        gridDetalle.DataSource = dtDatos
    End Sub
    Sub comboTipo()
        Dim valueList = New ValueList()
        valueList.ValueListItems.Add("1", "NACIONAL")
        valueList.ValueListItems.Add("2", "EXPORTACIÓN")
        valueList.ValueListItems.Add("3", "EXCLUSIÓN")
        valueList.ValueListItems.Add("4", "PRORRATA")
        gridDetalle.DisplayLayout.Bands(0).Columns("TIPO").Style = ColumnStyle.DropDownList
        gridDetalle.DisplayLayout.Bands(0).Columns("TIPO").ValueList = valueList
        gridDetalle.DisplayLayout.Bands(0).Columns("TIPO").ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        Try
            If MsgBox("Seguro registrar los datos?", MsgBoxStyle.YesNo, "Pregunta") = MsgBoxResult.No Then Exit Sub
            Dim porc_nac As Double = 0
            Dim porc_ext As Double = 0
            Dim tipo As String = ""
            Dim dt As New DataTable
            dt.Columns.Add("CUENTA")
            dt.Columns.Add("PORC_NACIONAL")
            dt.Columns.Add("PORC_EXTERIOR")
            dt.Columns.Add("TIPO")
            For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                porc_nac = gridDetalle.Rows(i).Cells("PORC_NACIONAL").Value
                porc_ext = gridDetalle.Rows(i).Cells("PORC_EXTERIOR").Value
                tipo = gridDetalle.Rows(i).Cells("TIPO").Value
                If porc_nac + porc_ext <> 100 And tipo <> "3" Then MsgBox("El % Nacional y Exterior deben sumar 100% en la fila " & i + 1) : Exit Sub
                If tipo = "" Then MsgBox("Debe seleccionar tipo en la fila " & i + 1) : Exit Sub
                Dim dr As DataRow
                dr = dt.NewRow
                dr(0) = gridDetalle.Rows(i).Cells("CUENTA").Value
                dr(1) = porc_nac
                dr(2) = porc_ext
                dr(3) = tipo
                dt.Rows.Add(dr)
            Next
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = ayo
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_MantSeteoVTAADM(dt)
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub gridDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDetalle.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridDetalle) Then Return
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
                        'If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "Importe" Then
                        '    If gridDetalle.ActiveRow.Cells("Importe").Value <= 0 Then
                        '        MsgBox("Ingrese importe válido")
                        '        '.PerformAction(PrevCellByTab)
                        '        'Else
                        '        '.PerformAction(NextCellByTab)
                        '    End If
                        'End If
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With

        Catch ex As Exception

        End Try
    End Sub
End Class