Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Excel
Imports Infragistics.Excel.Workbook

Public Class FrmCategoriaTrabajador
    Public dtData As New DataTable
    Dim obj As New ETCanteraCosteo
    Private Sub FrmCategoriaTrabajador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gridData.Visible = True
        gridData.DataSource = dtData
    End Sub

    Private Sub gridData_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridData.DoubleClickRow
        Try
            Dim placod As String = gridData.ActiveRow.Cells("PLACOD").Value
            Dim trabajador As String = gridData.ActiveRow.Cells("TRABAJADOR").Value
            Dim idCategoria As String = gridData.ActiveRow.Cells("IDCATEGORIA").Value
            txtplacod.Text = placod
            txtrab.Text = trabajador
            If idCategoria = 0 Then
                cboCategoria.SelectedIndex = -1
            Else
                cboCategoria.Value = idCategoria
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            If txtplacod.Text = "" Then
                Exit Sub
            End If
            If cboCategoria.SelectedIndex < 0 Then
                Exit Sub
            End If

            Dim dtResult As New DataTable
            obj = New ETCanteraCosteo
            obj.CodEmpleado = txtplacod.Text
            obj.ID = cboCategoria.Value
            obj.User = userLogin
            dtResult = Negocio.Activo.ListarCategoriaTrabajadorMant(obj)
            If dtResult.Rows.Count > 0 Then
                If dtResult.Rows(0)(0) = "OK" Then
                    MsgBox("registro grabado correctamente", MsgBoxStyle.Information, "Sistemas")
                End If
            Else
                Exit Sub
            End If

            gridData.ActiveRow.Cells("IDCATEGORIA").Value = cboCategoria.Value
            gridData.ActiveRow.Cells("CATEGORIA").Value = cboCategoria.Text.Trim
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class