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

Public Class FrmCambiaCantera
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Public idconmay As Integer
    Public ayo As Int32
    Public mes As Int32
    Private Sub FrmCambiaCantera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            'lblmensaje.Text = "Procesando Datos..."
            'lblmensaje.Visible = True
            'lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = ayo
            _objEntidad.Mes = mes
            _objEntidad.ID = idconmay
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RevisionCanteraID(_objEntidad)
            Call CargarUltraGridxBinding(Me.gridRevision, Source1, dtDatos)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'lblmensaje.Visible = False
            'lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            If MsgBox("Desea realizar cambio de canteras?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            Dim cadOrden As String = ""
            For i As Int32 = 0 To gridRevision.Rows.Count - 1
                cadOrden = cadOrden & gridRevision.Rows(i).Cells("CodCantera").Value & ","
            Next
            cadOrden = cadOrden.Substring(0, cadOrden.Length - 1)
            'MsgBox(cadOrden)

            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.ID = idconmay
            _objEntidad.Cod_Cantera = cadOrden
            _objEntidad.Anho = ayo
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_ActualizaCantera(_objEntidad)
            MsgBox("Cambios realizados correctamente", MsgBoxStyle.Information, msgComacsa)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridRevision_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridRevision.KeyPress
        Try
            If gridRevision.ActiveRow.Cells(gridRevision.ActiveCell.Column.Index).Column.Key = "CodCantera" Then
                Dim frm As New FrmCanteras
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.cadena = gridRevision.ActiveRow.Cells("CodCantera").Value
                frm.tipo = 0
                frm.ShowDialog()
                codCantera = codCantera.Replace(" ", "")
                If Not codCantera = "" Then
                    gridRevision.ActiveRow.Cells("CodCantera").Value = codCantera
                    gridRevision.ActiveRow.Cells("Cantera").Value = Cantera
                    codCantera = ""
                    Cantera = ""
                    'Dim array As String() = gridRevision.ActiveRow.Cells("CodCantera").Value.Split(",")
                    'If array.Count = 1 Then
                    '    If Me.gridRevision.Rows.Count > 0 Then
                    '        For i As Int32 = 0 To gridRevision.Rows.Count - 1
                    '            gridDetalle.Rows(i).Cells("Cantera").Value = txtcodCantera.Text
                    '        Next
                    '    End If
                    'End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Try
            If MsgBox("Desea eliminar la cantera?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            gridRevision.ActiveRow.Delete()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridRevision_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridRevision.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridRevision Then Return
        e.DisplayPromptMsg = Boolean.FalseString
    End Sub
End Class