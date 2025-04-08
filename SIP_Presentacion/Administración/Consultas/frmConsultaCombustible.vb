Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class frmConsultaCombustible
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
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
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private lineacredito As Double = 0
    Dim esDevolucion As Int32 = 0
#End Region
    Private Sub frmConsultaCombustible_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpinicio.Value = "01/01/" & CStr(Now.Date.Year)
        Me.dtpfin.Value = Now.Date
        Call CargarDatos()
    End Sub
    Dim dtResumen As DataTable
    Private Sub CargarDatos()
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.Entregas.FechaInicio = dtpinicio.Value
        Entidad.Entregas.FechaTerminacion = dtpfin.Value
        Entidad.Entregas.CodTrabajador = TxtCodigoTrabajador.Text.ToString.Trim
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Ls_EntregaDetalle = Nothing
        Ls_EntregaDetalle = New List(Of ETEntregas)
        Ls_DetalleComp = New List(Of ETEntregas)

        Call CargarUltraGrid(GridConsultaDetalle, Ls_DetalleComp)
        Call CargarUltraGrid(GridConsultaDetalle, Ls_Entrega)
        Entidad.MyLista = Negocio.NEntregas.ConsultaCombustible(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.GridConsultaDetalle, Source1, Ls_Entrega)
        Resumen()
    End Sub
    Sub Resumen()
        dtResumen = New DataTable
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.Entregas.FechaInicio = dtpinicio.Value
        Entidad.Entregas.FechaTerminacion = dtpfin.Value
        Entidad.Entregas.CodTrabajador = TxtCodigoTrabajador.Text.ToString.Trim

        Negocio.NEntregas = New NGEntregas

        'Call CargarUltraGrid(GridConsultaDetalle, Ls_DetalleComp)
        'Call CargarUltraGrid(GridConsultaDetalle, Ls_Entrega)
        dtResumen = Negocio.NEntregas.CombustibleResumen(Entidad.Entregas)
    End Sub
    Private Sub GridConsultaDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridConsultaDetalle.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Fecha" OrElse uColumn.Key = "TipoDoc" OrElse uColumn.Key = "NumDoc" OrElse uColumn.Key = "montoParcial" OrElse uColumn.Key = "Proveedor" _
                    OrElse uColumn.Key = "NomTrabajador" OrElse uColumn.Key = "Combustible" _
                    OrElse uColumn.Key = "Galones" OrElse uColumn.Key = "montoTotal" _
                    OrElse uColumn.Key = "Kilometraje") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Sub procesar()
        CargarDatos()
    End Sub

    Private Sub TxtCodigoTrabajador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoTrabajador.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If TxtCodigoTrabajador.Text.ToString.Trim = "" Then
            TxtCodigoTrabajador.Focus()
            Exit Sub
        End If
        CargarTrabajadoresxCodigo(Me.TxtCodigoTrabajador.Text)
        If lResult.Ls_Entrega.Count > 0 Then
            TxtNombresTrabajador.Text = lResult.Ls_Entrega.Item(0).NomTrabajador
        Else
            MsgBox("Código de trabajador no existe", MsgBoxStyle.Exclamation, msgComacsa)
            TxtCodigoTrabajador.Clear()
            TxtNombresTrabajador.Clear()
            TxtCodigoTrabajador.Focus()
        End If
    End Sub
    Private Sub CargarTrabajadoresxCodigo(ByVal codTrabajador As String)
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.CodTrabajador = codTrabajador
        Entidad.MyLista = Negocio.NEntregas.ListarTrabajadorxCodigo(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
    End Sub
    Sub buscar()

        If TxtCodigoTrabajador.Focused = True Then

            Dim FRM As New FrmListadoPersonal
            FRM.ShowDialog()
            If codTrabajador.ToString.Trim = "" Then Return
            TxtCodigoTrabajador.Text = codTrabajador.ToString.Trim
            TxtNombresTrabajador.Text = nomTrabajador.ToString.Trim
        End If

    End Sub

    Sub Reporte()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            If GridConsultaDetalle.Rows.Count > 0 Then
                lblmensaje.Visible = True
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                lblmensaje.Update()
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTECOMBUSTIBLE.xls")
                File.Copy(RutaReporteERP & "PLANTILLA COMBUSTIBLE.xls", path & "\REPORTECOMBUSTIBLE.xls")
                m_Excel.Workbooks.Open(path & "\REPORTECOMBUSTIBLE.xls")
                Dim objHojaExcelResumen As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
                objHojaExcel.Name = "COMBUSTIBLE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim filault As Integer
                '<JOSF 28/12/2022>
                'nfila = 13
                'nfilaini = 13
                nfila = 14
                nfilaini = 14
                '</JOSF 28/12/2022>
                'm_Excel.Visible = True
                With objHojaExcel
                    .Activate()
                    For i As Int16 = 0 To GridConsultaDetalle.Rows.Count - 1
                        .Range("A" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("NumSolicitud").Value
                        .Range("B" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("numinterno").Value
                        .Range("C" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("Fecha").Value
                        .Range("D" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("TipoDoc").Value
                        .Range("E" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("NumDoc").Value
                        .Range("F" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("NomTrabajador").Value
                        .Range("G" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("Cantera").Value
                        .Range("H" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("Auxiliar").Value
                        .Range("I" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("Combustible").Value
                        .Range("J" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("Galones").Value
                        .Range("K" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("Proveedor").Value
                        .Range("L" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("montoTotal").Value
                        .Range("M" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("montoParcial").Value
                        '.Range(.Cells(13 + i, 1), .Cells(13 + i, 9)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        '<JOSF 28/12/2022>
                        '.Range("N" & 2 + i).Value = GridConsultaDetalle.Rows(i).Cells("Kilometraje").Value
                        '</JOSF 28/12/2022>
                        nfila = nfila + 1
                    Next
                End With

                With objHojaExcelResumen
                    .Activate()
                    .Range("A2").Value = "REPORTE DE COMBUSTIBLE MES DEL " & dtpinicio.Value & " AL " & dtpfin.Value
                    For i As Int16 = 0 To dtResumen.Rows.Count - 1
                        .Range("A" & 7 + i).Value = i + 1
                        .Range("B" & 7 + i).Value = dtResumen.Rows(i)("nomTrabajador")
                        .Range("C" & 7 + i).Value = dtResumen.Rows(i)("area")
                        .Range("D" & 7 + i).Value = dtResumen.Rows(i)("galondiesel")
                        .Range("E" & 7 + i).Value = dtResumen.Rows(i)("galongasohol")
                        .Range("F" & 7 + i).Value = dtResumen.Rows(i)("galongasolina")
                        .Range("G" & 7 + i).Value = dtResumen.Rows(i)("galonglp")
                        .Range("H" & 7 + i).Value = dtResumen.Rows(i)("totaldiesel")
                        .Range("I" & 7 + i).Value = dtResumen.Rows(i)("totalgasohol")
                        .Range("J" & 7 + i).Value = dtResumen.Rows(i)("totalgasolina")
                        .Range("K" & 7 + i).Value = dtResumen.Rows(i)("totalglp")
                        .Range("L" & 7 + i).Value = "=SUMA(D" & 7 + i & ":G" & 7 + i & ")"
                        .Range("M" & 7 + i).Value = "=SUMA(H" & 7 + i & ":K" & 7 + i & ")"
                        .Range(.Cells(7 + i, 1), .Cells(7 + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfila + 1
                        filault = 8 + i
                    Next
                    .Range("C" & filault + 1).Value = "TOTALES"
                    .Range("D" & filault + 1).Value = "=SUMA(D7:D" & filault - 1 & ")"
                    .Range("E" & filault + 1).Value = "=SUMA(E7:E" & filault - 1 & ")"
                    .Range("F" & filault + 1).Value = "=SUMA(F7:F" & filault - 1 & ")"
                    .Range("G" & filault + 1).Value = "=SUMA(G7:G" & filault - 1 & ")"
                    .Range("H" & filault + 1).Value = "=SUMA(H7:H" & filault - 1 & ")"
                    .Range("I" & filault + 1).Value = "=SUMA(I7:I" & filault - 1 & ")"
                    .Range("J" & filault + 1).Value = "=SUMA(J7:J" & filault - 1 & ")"
                    .Range("K" & filault + 1).Value = "=SUMA(K7:K" & filault - 1 & ")"
                    .Range("L" & filault + 1).Value = "=SUMA(L7:L" & filault - 1 & ")"
                    .Range("M" & filault + 1).Value = "=SUMA(M7:M" & filault - 1 & ")"
                    .Range(.Cells(filault + 1, 3), .Cells(filault + 1, 13)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filault + 1, 3), .Cells(filault + 1, 13)).Font.Bold = True
                    .Range(.Cells(filault + 1, 3), .Cells(filault + 1, 13)).Font.Size = 10
                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End Try
    End Sub

    Private Sub TxtCodigoTrabajador_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoTrabajador.ValueChanged

    End Sub

    Private Sub GridConsultaDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridConsultaDetalle.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is GridConsultaDetalle) Then Return
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
                        If GridConsultaDetalle.ActiveRow.Cells(GridConsultaDetalle.ActiveCell.Column.Index).Column.Key = "Galones" Then
                            If GridConsultaDetalle.ActiveRow.Cells("Galones").Value <= 0 Then
                                MsgBox("Ingrese cantidad válida")
                                .PerformAction(PrevCellByTab)
                            Else
                                .PerformAction(NextCellByTab)
                            End If
                        End If
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        CalcularTotalComprobantes()
                End Select
            End With

        Catch ex As Exception

        End Try
    End Sub

    Sub CalcularTotalComprobantes()
        'txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
        Dim tcambio As Double = 0
        Dim importe As Double = 0
        Dim total As Double = 0
        Dim ngalones As Double = 0
        GridConsultaDetalle.PerformAction(ExitEditMode)
        For i As Int32 = 0 To GridConsultaDetalle.Rows.Count - 1
            'tcambio = GridConsultaDetalle.Rows(i).Cells("tipocambio").Value
            ngalones = GridConsultaDetalle.Rows(i).Cells("Galones").Value
            importe = GridConsultaDetalle.Rows(i).Cells("montoTotal").Value
            GridConsultaDetalle.Rows(i).Cells("montoParcial").Value = importe / ngalones
        Next
    End Sub


    Private Sub GridConsultaDetalle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridConsultaDetalle.KeyPress
        Try
            If e.KeyChar = "+" Then
                e.Handled = True
                Return
            End If
            If e.KeyChar = "-" Then
                e.Handled = True
                Return
            End If
            If Me.GridConsultaDetalle.ActiveRow.Index < 0 Then Exit Sub
            If e.KeyChar = ChrW(Keys.Escape) Then Return
            If e.KeyChar = ChrW(Keys.Delete) Then Return
            If e.KeyChar = ChrW(Keys.Return) Then Return
            If e.KeyChar = ChrW(Keys.Back) Then Return
            If e.KeyChar.ToString.Trim = "" Then Return

            If GridConsultaDetalle.ActiveRow.Cells(GridConsultaDetalle.ActiveCell.Column.Index).Column.Key = "Combustible" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                Dim frm As New frmListadoCombustible
                frm.ShowDialog()
                GridConsultaDetalle.Rows(GridConsultaDetalle.ActiveRow.Index).Cells("Combustible").Value = combustible
                'GridConsultaDetalle.Rows(GridConsultaDetalle.ActiveRow.Index).Cells("motivoDetalle").Value = Motivodetalle
                GridConsultaDetalle.PerformAction(NextCellByTab)
                e.Handled = True
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Grabar()
        Try
            CalcularTotalComprobantes()
            If GridConsultaDetalle.Rows.Count > 0 Then
                Dim combustible As String = String.Empty

                If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub

                Dim galones As Double = 0
                Dim id As Int32 = 0
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                Entidad.Entregas = New ETEntregas
                Negocio.NEntregas = New NGEntregas
                For i As Int32 = 0 To GridConsultaDetalle.Rows.Count - 1
                    combustible = GridConsultaDetalle.Rows(i).Cells("Combustible").Value
                    galones = GridConsultaDetalle.Rows(i).Cells("Galones").Value
                    id = GridConsultaDetalle.Rows(i).Cells("ID").Value
                    Entidad.Entregas.ID = id
                    Entidad.Entregas.Combustible = combustible
                    Entidad.Entregas.Galones = galones
                    Entidad.Entregas = Negocio.NEntregas.ActualizaCombustible(Entidad.Entregas)
                Next
                MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
                Call CargarDatos()
                'MsgBox("Grabado")
            End If
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Private Sub Source1_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Source1.CurrentChanged

    End Sub
End Class