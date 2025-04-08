Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class FrmCostoProm_NuevoReg
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
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Public ayo As Int32
    Public mes As Int32
    Public mes1 As Int32
    Private Sub TxtCodigoTrabajador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        Dim frm As New FrmCosto_ListaProducto
        Dim resul As DialogResult
        frm.ayo = ayo
        frm.mes = mes
        resul = frm.ShowDialog
        If resul = Windows.Forms.DialogResult.OK Then
            txtcodigo.Text = frm.gridcostoproducto.ActiveRow.Cells("COD_PROD").Value.trim
            txtproducto.Text = frm.gridcostoproducto.ActiveRow.Cells("PRODUCTO").Value.trim
        End If
    End Sub

    Private Sub FrmCostoProm_NuevoReg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = ayo
        _objEntidad.Mes = mes
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Costo_ListaConcepto(_objEntidad)
        Call CargarUltraGridxBinding(Me.gridcostoconcepto, Source1, dtDatos)
    End Sub

    Private Sub gridcostoconcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridcostoconcepto.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridcostoconcepto) Then Return
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
                        If gridcostoconcepto.ActiveRow.Cells(gridcostoconcepto.ActiveCell.Column.Index).Column.Key = "IMPORTE" Then
                            .PerformAction(NextCellByTab)
                            .PerformAction(NextCellByTab)
                        Else
                            .PerformAction(NextCellByTab)
                        End If
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            If txtcodigo.Text.Trim = "" Then
                MsgBox("Debe ingresar código de producto", MsgBoxStyle.Exclamation, msgComacsa)
                txtcodigo.Focus()
                Exit Sub
            End If
            If MsgBox("Desea registrar producto?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = ayo
            _objEntidad.Mes = mes
            _objEntidad.Mes1 = mes1
            _objEntidad.CodProducto = txtcodigo.Text.Trim
            _objEntidad.MinVarD = gridcostoconcepto.Rows(0).Cells("IMPORTE").Value
            _objEntidad.MinVarI = gridcostoconcepto.Rows(1).Cells("IMPORTE").Value
            _objEntidad.MinFijD = gridcostoconcepto.Rows(2).Cells("IMPORTE").Value
            _objEntidad.MinFijI = gridcostoconcepto.Rows(3).Cells("IMPORTE").Value
            _objEntidad.MinFijO = gridcostoconcepto.Rows(4).Cells("IMPORTE").Value
            _objEntidad.ChaVarD = gridcostoconcepto.Rows(5).Cells("IMPORTE").Value
            _objEntidad.ChaVarI = gridcostoconcepto.Rows(6).Cells("IMPORTE").Value
            _objEntidad.ChaFijD = gridcostoconcepto.Rows(7).Cells("IMPORTE").Value
            _objEntidad.ChaFijI = gridcostoconcepto.Rows(8).Cells("IMPORTE").Value
            _objEntidad.MolVarD = gridcostoconcepto.Rows(9).Cells("IMPORTE").Value
            _objEntidad.MolVarI = gridcostoconcepto.Rows(10).Cells("IMPORTE").Value
            _objEntidad.MolFijD = gridcostoconcepto.Rows(11).Cells("IMPORTE").Value
            _objEntidad.MolFijI = gridcostoconcepto.Rows(12).Cells("IMPORTE").Value
            _objEntidad.Envases = gridcostoconcepto.Rows(13).Cells("IMPORTE").Value
            _objEntidad.GastoAdm = gridcostoconcepto.Rows(14).Cells("IMPORTE").Value
            _objEntidad.GastoVta = gridcostoconcepto.Rows(15).Cells("IMPORTE").Value
            Dim dtResul As New DataTable
            dtResul = _objNegocio.Costo_Prom_IngresoRegistro_Rango(_objEntidad)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class