Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class frmIngresoTonelada
    Public toneladamaxima As Double
    Public numpedido As String
    Public cod_programacion As Int32
    Public tonelada_nueva As Double
    Public dtProgramado As New DataTable
    Public numviaje As Int32
    Private Sub txttonelada_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttonelada.KeyDown
        If e.KeyData = Keys.Return Then
            Me.Close()
        End If
    End Sub

    Private Sub frmIngresoTonelada_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            gridProducto.PerformAction(ExitEditMode)
            If txttonelada.Text.Trim = "" Then txttonelada.Text = 0
            If txttonelada.Text <= 0 Then
                MsgBox("Ingrese cantidad de toneladas válidas", MsgBoxStyle.Exclamation, msgComacsa)
                e.Cancel = True
            End If
            For i As Int32 = 0 To gridProducto.Rows.Count - 1
                Dim tonpendiente As Double = CDbl(gridProducto.Rows(i).Cells("cantDespacho").Value).ToString("##0.0000")

                Dim toningresado As Double = CDbl(gridProducto.Rows(i).Cells("TONELADA").Value).ToString("##0.0000")
                Dim nviaje As Int32 = CInt(gridProducto.Rows(i).Cells("NVIAJE").Value)
                Dim peso As Double = CDbl(gridProducto.Rows(i).Cells("PESO").Value).ToString("##0.0000")
                Dim producto As String = gridProducto.Rows(i).Cells("PRODUCTO").Value.ToString
                If toningresado > tonpendiente Then
                    MsgBox("No puede ingresar una cantidad mayor a la permitida para el producto " & gridProducto.Rows(i).Cells("PRODUCTO").Value, MsgBoxStyle.Exclamation, msgComacsa)
                    e.Cancel = True
                    Exit Sub
                End If
                If nviaje <> 1 And nviaje <> 2 And nviaje <> 3 Then
                    MsgBox("Ingrese N° de viaje correcto", MsgBoxStyle.Exclamation, msgComacsa)
                    e.Cancel = True
                    Exit Sub
                End If
                Dim xPesoAprox As Double = 0
                If IsNumeric(peso) And CDbl(peso) > 0 Then
                    xPesoAprox = CalculoBolsasAprox(toningresado, peso)
                    If xPesoAprox <> CDbl(toningresado) Then
                        'MsgBox("La cantidad a facturar no es multiplo del peso del producto con item:  KG.", vbExclamation, msgComacsa)
                        MsgBox("La cantidad a facturar no es multiplo del peso del producto: " & producto.Trim & Chr(13) & "Peso: " & peso & " KG.", vbExclamation, msgComacsa)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If

            Next

            tonelada_nueva = CDbl(txttonelada.Text).ToString("##0.0000")
            tonelada_nueva = 0
            For i As Int32 = 0 To gridProducto.Rows.Count - 1
                tonelada_nueva = tonelada_nueva + gridProducto.Rows(i).Cells("TONELADA").Value
            Next
            tonelada_nueva = CDbl(tonelada_nueva).ToString("##0.0000")

            If CDbl(tonelada_nueva) > CDbl(toneladamaxima) Then
                MsgBox("No puede ingresar una cantidad mayor a las toneladas permitidas", MsgBoxStyle.Exclamation, msgComacsa)
                e.Cancel = True
            End If
        End If
    End Sub

    Function CalculoBolsasAprox(ByVal pCant As String, ByVal pPeso As String) As String
        Dim xKLS As Double
        Dim xBolsas As Long
        Dim xcal As Double
        If pPeso = 0 Or Val(pCant) = 0 Then xBolsas = 0 : CalculoBolsasAprox = pCant : Exit Function
        xKLS = Math.Round(CDbl(pCant) * 1000, 4)
        xBolsas = Int(xKLS / pPeso)
        xcal = Math.Round((xBolsas * pPeso) / 1000, 4)
        If (CDbl(pCant) - xcal) > 0 Then ' And xOpcprod <> "E"
            'MsgBox "Se aplicó cálculo aproximando para " & Format(xBolsas, "###,###,###") & " Bolsa(s) de " & Format(xPeso, "###,###,##0.000") & " (Kgs)", vbInformation, "Cálculo de Bolsas Aproximado"
            CalculoBolsasAprox = CStr(xcal)
        Else
            CalculoBolsasAprox = pCant
        End If
    End Function

    Private Sub frmIngresoTonelada_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Procesar()
        txttonelada.Text = toneladamaxima
    End Sub

    Private Sub txttonelada_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttonelada.KeyPress
        e.Handled = txtNumericoForm(sender, e.KeyChar, True)
    End Sub

    Sub Procesar()
        Entidad.Contratista = New ETContratista
        Negocio.NContratista = New NGContratista
        Entidad.Contratista.Usuario = User_Sistema
        Entidad.Contratista._numorden = numpedido
        Entidad.Contratista._codprog = cod_programacion
        Entidad.Contratista.NroViaje = numviaje
        Dim dtDatos As New DataTable
        dtDatos = Negocio.NContratista.Listar_PRO_Prod_Programacion(Entidad.Contratista)

        Dim pedido_programado As String = ""
        Dim cod_programado As String = ""
        Dim prod_programado As String = ""
        Dim ton_programado As Double = 0
        Dim item_programado As Int32 = 0
        For i As Int32 = 0 To dtDatos.Rows.Count - 1
            For j As Int32 = 0 To dtProgramado.Rows.Count - 1
                pedido_programado = dtProgramado.Rows(j)("NUMPEDIDO")
                cod_programado = dtProgramado.Rows(j)("COD_PROGRAMACION")
                prod_programado = dtProgramado.Rows(j)("COD_PROD")
                ton_programado = dtProgramado.Rows(j)("TONELADA")
                item_programado = dtProgramado.Rows(j)("ITEM")
                dtDatos.Rows(i)("TONELADA") = dtDatos.Rows(i)("cantDespacho")
                If pedido_programado = numpedido And cod_programado And dtDatos.Rows(i)("COD_PROD") = prod_programado And dtDatos.Rows(i)("ITEM") = item_programado Then
                    'If dtDatos.Rows(i)("cantDespacho") > 0 Then
                    dtDatos.Rows(i)("cantDespacho") = dtDatos.Rows(i)("cantDespacho") - ton_programado
                    dtDatos.Rows(i)("TONELADA") = dtDatos.Rows(i)("TONELADA") - ton_programado
                    'End If
                End If
            Next
        Next


        Call CargarUltraGridxBinding(Me.gridProducto, Source1, dtDatos)

        gridProducto.Rows(0).Cells("CANTDESPACHO").Activate()
        gridProducto.PerformAction(ExitEditMode)
        gridProducto.PerformAction(EnterEditMode)

        Try

            For I As Int32 = 0 To gridProducto.Rows.Count - 1
                If gridProducto.Rows(I).Cells("cantDespacho").Value.ToString <= 0 Then
                    gridProducto.Rows(I).Cells("TONELADA").Activation = Activation.ActivateOnly
                Else
                    gridProducto.Rows(I).Cells("TONELADA").Activation = Activation.AllowEdit
                End If
            Next

            'Dim aCell As UltraGridCell
            'aCell = Me.gridProducto.Rows(0).Cells("CANTDESPACHO")

            'Me.gridProducto.ActiveCell = aCell
            'Me.gridProducto.Focus()
            'gridProducto.PerformAction(NextCell)
            'Me.gridProducto.PerformAction(UltraGridAction.EnterEditMode, True, True)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub gridProducto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridProducto.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If

            If Not (sender Is gridProducto) Then Return
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
                        Dim toningresado As Double = 0
                        Dim tonpendiente As Double = 0
                        If gridProducto.ActiveRow.Cells(gridProducto.ActiveCell.Column.Index).Column.Key = "NVIAJE" Then
                            tonpendiente = CDbl(gridProducto.ActiveRow.Cells("cantDespacho").Value).ToString("##0.0000")
                            toningresado = CDbl(gridProducto.ActiveRow.Cells("TONELADA").Value).ToString("##0.0000")
                            If toningresado > tonpendiente Then
                                MsgBox("No puede ingresar una cantidad mayor a la permitida para el producto " & gridProducto.ActiveRow.Cells("PRODUCTO").Value, MsgBoxStyle.Exclamation, msgComacsa)
                                e.Handled = False
                                .PerformAction(EnterEditMode)
                                Exit Sub
                            End If
                            'cantDespacho
                            If gridProducto.ActiveRow.Index = gridProducto.Rows.Count - 1 Then
                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()
                            End If
                            .PerformAction(NextCellByTab)
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

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub gridProducto_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridProducto.InitializeLayout

    End Sub
End Class