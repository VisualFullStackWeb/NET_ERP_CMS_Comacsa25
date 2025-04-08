Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows
Imports System.Windows.Forms
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Configuration
Public Class FrmCExportacion

#Region "Declaraciones"

    Private Ls_Combo As List(Of ETCliente) = Nothing
    Private Tabla As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)

#End Region

#Region "Publicos"

    Public Sub Procesar()

        If Not VerificarControl(4, Cbo2) Then
            Return
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Cliente = New ETCliente
        Negocio.Cliente = New NGCliente

        Entidad.Cliente.Anho = Year(Clb1.Value)
        Entidad.Cliente.Mes = Month(Clb1.Value)
        Entidad.Cliente.Tipo = IIf(Cbo2.Value = "1", 4, 5)
        Entidad.Cliente.Codigo = Cbo3.Value

        Tabla = New DataTable
        Tabla = Negocio.Cliente.ConsultaProduccion(Entidad.Cliente)

        Call CargarUltraGridxBinding(Grid1, Source1, Tabla)

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Reporte()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Try

            If Not VerificacionProforma() Then Exit Try

            StrucForm.FxRxReporte = New FrmBReporte
            Entidad.Proforma = New ETProforma
            Entidad.Proforma.NumPedido = Txt1.Value

            StrucForm.FxRxReporte.NumReporte = VarReporte.Exportacion
            StrucForm.FxRxReporte.DatosReporte = Entidad.Proforma
            StrucForm.FxRxReporte.TextReporte = "Proforma [" & Txt1.Value & "]"
            StrucForm.FxRxReporte.MdiParent = MdiParent
            StrucForm.FxRxReporte.Show()

        Catch
            MessageBox.Show("Error: Problemas al Generar el Reporte", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Excel()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Try

            If Not VerificacionProforma() Then Exit Try

            Call Exportar_Proforma(ExpArchivo.Excel)

        Catch
            MessageBox.Show("Error: Problemas al Generar el Reporte", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Word()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Try

            If Not VerificacionProforma() Then Exit Try

            Call Exportar_Proforma(ExpArchivo.Word)

        Catch
            MessageBox.Show("Error: Problemas al Generar el Reporte", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Pdf()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Try

            If Not VerificacionProforma() Then Exit Try

            Call Exportar_Proforma(ExpArchivo.Pdf)

        Catch
            MessageBox.Show("Error: Problemas al Generar el Reporte", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

#Region "Eventos"

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Combo Is Nothing Then Ls_Combo = Nothing
        If Tabla Is Nothing Then Tabla = Nothing
        If MdiOperaciones Is Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Cbo2.Value = "1"

    End Sub

    Sub Evento_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
                            Handles Cbo2.ValueChanged

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Cbo2 Then Return

        If Not VerificarControl(4, sender) Then Return

        Entidad.Cliente = New ETCliente
        Negocio.Cliente = New NGCliente
        Ls_Combo = New List(Of ETCliente)

        Entidad.Cliente.Tipo = sender.Value

        Ls_Combo = Negocio.Cliente.ListarExportacion(Entidad.Cliente)

        Entidad.Cliente = New ETCliente

        Entidad.Cliente.Codigo = String.Empty
        Entidad.Cliente.Descripcion = " << TODOS LOS " & Cbo2.Text & " >> "

        Ls_Combo.Insert(0, Entidad.Cliente)

        Call CargarUltraCombo(Cbo3, Ls_Combo, "Codigo", "Descripcion", String.Empty)

    End Sub

    Sub Evento_DoubleClickCell(ByVal sender As Object, ByVal e As DoubleClickCellEventArgs) _
                                Handles Grid1.DoubleClickCell

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If Cbo2.Value <> 1 Then Return

        If (e.Cell.Column.Key = "Codigo" OrElse e.Cell.Column.Key = "Descripcion" OrElse _
            e.Cell.Column.Key = "Stock" OrElse e.Cell.Column.Key = "CantidadActual" OrElse _
            e.Cell.Column.Key = "CantidadPosterior") Then Return

        If e.Cell.Column.Key <> "CantidadAnterior" AndAlso e.Cell.Value = 0 Then Return

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        StrucForm.FxCxDetallada = New FrmCDetallada
        StrucForm.FxCxDetallada.MdiParent = MdiParent
        StrucForm.FxCxDetallada.CodProducto = e.Cell.Row.Cells("Codigo").Value
        StrucForm.FxCxDetallada.Descripcion = e.Cell.Row.Cells("Descripcion").Value
        StrucForm.FxCxDetallada.Anho = e.Cell.Row.Cells("Anho").Value
        StrucForm.FxCxDetallada.Mes = e.Cell.Row.Cells("Mes").Value
        StrucForm.FxCxDetallada.Fecha = Clb1.Value

        If e.Cell.Column.Key = "CantidadAnterior" Then
            StrucForm.FxCxDetallada.Caso = 8
        Else
            StrucForm.FxCxDetallada.Caso = 1
            StrucForm.FxCxDetallada.Semana = (e.Cell.Column.Key).Substring(3)
        End If

        StrucForm.FxCxDetallada.Show()
        StrucForm.FxCxDetallada = Nothing

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Sub Evento_Resize(ByVal sender As Object, ByVal e As EventArgs) _
                      Handles Cbo3.Resize

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Cbo3 Then Return

        Try
            Cbo3.DisplayLayout.Bands(0).Columns("Descripcion").Width = Cbo3.Width
        Catch
        End Try

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Cbo3.InitializeLayout, Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        With sender.DisplayLayout.Bands(0)
            If sender Is Cbo3 Then
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Descripcion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
                .ColHeadersVisible = Boolean.FalseString
                .Columns("Descripcion").Width = sender.Width
            End If
            If sender Is Grid1 Then
                Dim i As Int16 = 3
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Codigo" Or uColumn.Key = "Descripcion" Or _
                            uColumn.Key = "CantidadAnterior" Or uColumn.Key = "CantidadPosterior" Or _
                            uColumn.Key = "CantidadActual" Or Mid(uColumn.Key, 1, 3) = "Sem" Or _
                            uColumn.Key = "Stock" Or uColumn.Key = "Action") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                        If Mid(uColumn.Key, 1, 3) = "Sem" Then
                            uColumn.MaxWidth = 100 : uColumn.MinWidth = 100
                            uColumn.CellActivation = Activation.ActivateOnly
                            uColumn.CellAppearance.TextHAlign = HAlign.Center
                            uColumn.Header.Appearance.TextHAlign = HAlign.Center
                            uColumn.NullText = "0.000"
                            uColumn.Format = "n3"
                            uColumn.Header.VisiblePosition = i
                            i += 1
                        End If
                    End If
                Next


            End If

        End With

    End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
                          Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
    '                     Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Procesar)
    '    MdiOperaciones.Add(StrucOperaciones._Reporte)
    '    MdiOperaciones.Add(StrucOperaciones._Excel)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
                       Handles Txt1.KeyDown, Grid1.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Try
            If sender Is Txt1 AndAlso e.KeyCode = Keys.Enter Then
                Call Reporte()
            End If
            If sender Is Grid1 Then
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
                            .PerformAction(BelowCell)
                            e.Handled = Boolean.TrueString
                            .PerformAction(EnterEditMode)
                    End Select
                End With
            End If
        Catch
            Exit Sub
        End Try
    End Sub

    Sub Evento_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) _
                        Handles Txt1.KeyPress

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Txt1 Then Return

        If Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57 OrElse Asc(e.KeyChar) = Keys.Back Then
            e.Handled = Boolean.FalseString
        Else
            e.Handled = Boolean.TrueString
        End If

    End Sub

#End Region

#Region "Funciones"

    Function VerificacionProforma() As Boolean

        Dim lResult As Boolean = Boolean.FalseString

        If Not VerificarControl(4, Cbo2) Then
            Txt1.Focus()
            Txt1.SelectAll()
            MessageBox.Show("Ingrese el Nro Proforma", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return lResult
        End If

        Entidad.Proforma = New ETProforma
        Entidad.Cliente = New ETCliente
        Negocio.Cliente = New NGCliente

        Entidad.Proforma.NumPedido = Txt1.Value
        Entidad.Cliente = Negocio.Cliente.VerificarProforma(Entidad.Proforma)

        If Entidad.Cliente.Validacion Then lResult = Boolean.TrueString

        Return lResult

    End Function

#End Region

#Region "Procedimientos"

    Sub Exportar_Proforma(ByVal TipoDoc As Short)

        Try
            Entidad.Proforma = New ETProforma
            Entidad.Proforma.NumPedido = Txt1.Value

            Call Visor_Crystal_Reporte(VarReporte.Exportacion, Entidad.Proforma, TipoDoc, Txt1.Value, VarReporte.Exportacion)

        Catch
        End Try

    End Sub

#End Region

End Class