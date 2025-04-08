Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class frmIngresoBarbotina
    Public mes As Int32
    Public año As Int32
    Private Sub frmIngresoBarbotina_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing

        oPrvFisN = New NGProveedorFiscalizado
        oPrvFisE = New ETProveedorFiscalizado

        With oPrvFisE
            .Cod_Cia = Companhia
            .mes = mes
            .año = año
        End With

        Dim DtUso As DataTable = Nothing
        DtUso = oPrvFisN.DatosUsoBarbotinaIQBF(oPrvFisE)
        Call CargarUltraGridxBinding(Grid4, Source1, DtUso)
    End Sub


    Private Sub Grid4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid4.KeyPress
        Try
            If Grid4.ActiveRow.Cells(Grid4.ActiveCell.Column.Index).Column.Key = "Producto" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                Dim frm As New frmProductobarbotina
                'frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.ShowDialog()
                If codProducto.Trim = "" Then e.Handled = True : Return
                Grid4.Rows(Grid4.ActiveRow.Index).Cells("codProducto").Value = codProducto
                Grid4.Rows(Grid4.ActiveRow.Index).Cells("Producto").Value = Producto
                codProducto = ""
                Producto = ""
                Grid4.PerformAction(NextCellByTab)
                e.Handled = True
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            Dim iduso As Int32 = 0
            Dim cod_producto As String = String.Empty
            Dim producto As String = String.Empty
            Dim cantidad As Double = 0
            For i As Int32 = 0 To Grid4.Rows.Count - 1

                oPrvFisN = New NGProveedorFiscalizado
                oPrvFisE = New ETProveedorFiscalizado

                iduso = Grid4.Rows(i).Cells("id").Value.ToString
                cod_producto = Grid4.Rows(i).Cells("codProducto").Value.ToString
                producto = Grid4.Rows(i).Cells("Producto").Value.ToString
                cantidad = Grid4.Rows(i).Cells("CantidadProduccion").Value.ToString
                With oPrvFisE
                    .Cod_Cia = Companhia
                    .iduso = iduso
                    .Cod_Prod = cod_producto
                    .Produdcto = producto
                    .Cantidad = cantidad
                End With

                oPrvFisN.INSERTA_USOBARBOTINA(oPrvFisE)

            Next
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class