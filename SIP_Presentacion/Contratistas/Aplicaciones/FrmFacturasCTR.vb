Public Class FrmFacturasCTR
    Public dtFacturaCTR As New DataTable
    Public tipo_doc As String
    Public numdoc As String
    Public saldo As Double
    Public moneda As String
    Public cod_tipodoc As String
    Public fecha As Date

    Private Sub FrmFacturasCTR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarUltraGridxBinding(gridBillete, Source1, dtFacturaCTR)
    End Sub

    Private Sub gridBillete_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridBillete.DoubleClickRow
        Try
            tipo_doc = gridBillete.ActiveRow.Cells("TIPO_DOC").Value
            numdoc = gridBillete.ActiveRow.Cells("NUM_DOC").Value
            saldo = gridBillete.ActiveRow.Cells("SALDO").Value
            moneda = gridBillete.ActiveRow.Cells("MONEDA").Value
            cod_tipodoc = gridBillete.ActiveRow.Cells("COD_TIPODOC").Value
            fecha = gridBillete.ActiveRow.Cells("FECHA_DOC").Value
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class