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
Public Class frmProgramacionGuia
#Region "Declarar Variables"
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
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
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
#End Region

    Private Sub frmProgramacionGuia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFecha.Value = Now.Date
    End Sub
    Sub Procesar()
        Try
            Entidad.Contratista = New ETContratista
            Entidad.Contratista.TipoOperacion = Ope
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Entidad.Contratista.Fecha = dtpFecha.Value
            Dim dtConsulta As New DataTable
            dtConsulta = Negocio.NContratista.Consulta_GuiaProgramacion(Entidad.Contratista)
            Call CargarUltraGridxBinding(Me.gridConsulta, Source1, dtConsulta)
            'Entidad.Contratista = New ETContratista
            'Entidad.Contratista.TipoOperacion = Ope
            'Negocio.NContratista = New NGContratista
            'Entidad.MyLista = New ETMyLista
            'Entidad.Contratista.Usuario = User_Sistema
            'Entidad.Contratista._codprov = txtcodprov.Text
            'Entidad.Contratista.Fecha = dtpFecha.Value
            ''Dim dtConsulta As New DataTable
            'dtConsulta = Negocio.NContratista.Consulta_GuiaProgramacion2(Entidad.Contratista)
            'Call CargarUltraGridxBinding(Me.gridConsulta2, Source2, dtConsulta)
        Catch ex As Exception

        End Try
    End Sub
    Sub Buscar()
        Dim frm As New FrmListaTransportista
        frm.ShowDialog()
        txtcodprov.Text = codMotivodetalle.Trim
        txtproveedor.Text = Motivodetalle.Trim
        Procesar()
    End Sub

    Private Sub txtcodprov_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodprov.KeyDown
        If e.KeyData = Keys.Return Then
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NContratista.Listar_PRO_Prov_Codigo(Entidad.Contratista)
            If dtDatos.Rows.Count > 0 Then
                txtcodprov.Text = dtDatos.Rows(0)("COD_PROV")
                txtproveedor.Text = dtDatos.Rows(0)("PROVEEDOR")
            Else
                MsgBox("El código no existe", MsgBoxStyle.Exclamation, msgComacsa)
                txtproveedor.Clear()
            End If
            Procesar()
        End If
    End Sub

    Private Sub gridConsulta_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridConsulta.ClickCell
        Try
            If gridConsulta.ActiveRow.Index < 0 Then Exit Sub
            If gridConsulta.ActiveRow.Cells(gridConsulta.ActiveCell.Column.Index).Column.Key = "REPROGRAMAR" Then
                If gridConsulta.ActiveRow.Cells("ESTADOORI").Value.ToString.Trim = "DESPACHADO" Then
                    MsgBox("No puede reprogramar un pedido despachado", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                Else
                    'MsgBox(gridConsulta.ActiveRow.Cells("ID").Value)
                    frmCamionReprogramacion.codprov = txtcodprov.Text
                    frmCamionReprogramacion.fecha = DateAdd(DateInterval.Day, 1, dtpFecha.Value)
                    frmCamionReprogramacion.ShowDialog()
                    'MsgBox(frmCamionReprogramacion.placa)
                    Dim placa As String = frmCamionReprogramacion.placa.Trim
                    If placa = "" Or placa Is Nothing Then Exit Sub
                    If MsgBox("Desea reprogramar el pedido al vehiculo de placa " & placa & "?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then

                        Entidad.Contratista = New ETContratista
                        Negocio.NContratista = New NGContratista
                        Entidad.MyLista = New ETMyLista
                        Entidad.Contratista.ID = gridConsulta.ActiveRow.Cells("ID").Value
                        Entidad.Contratista._placa = placa
                        Entidad.Contratista.Usuario = User_Sistema
                        Dim dtDatos As New DataTable
                        dtDatos = Negocio.NContratista.Reprogramacion_Pedido(Entidad.Contratista)
                        If dtDatos.Rows(0)(0) <> "OK" Then
                            MsgBox(dtDatos.Rows(0)(0), MsgBoxStyle.Exclamation, msgComacsa)
                            Exit Sub
                        Else
                            MsgBox("Reprogramación grabada correctamente", MsgBoxStyle.Information, msgComacsa)
                            Procesar()
                        End If

                    End If
                End If
            End If
            If gridConsulta.ActiveRow.Cells(gridConsulta.ActiveCell.Column.Index).Column.Key = "INCIDENCIAS" Then
                Dim frm As New frmProgramacion_Incidencia
                frm.ShowDialog()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gridConsulta_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConsulta.InitializeLayout
        Try
            With e.Layout
                '.Bands(0).Columns("NUMPEDIDO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                .Bands(0).Columns("NUMPEDIDO").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                '.Bands(0).Columns("CLIENTE").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                '.Bands(0).Columns("TRABAJADOR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                '.Bands(0).Columns("PROGRAMADO").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                '.Bands(0).Columns("NROVIAJE").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                '.Bands(0).Columns("PLACA").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
                '.Bands(0).Columns("AREA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                '.Bands(0).Columns("AREA").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Try
            Procesar()
        Catch ex As Exception

        End Try
    End Sub

    Sub Reporte()
        exportar()
    End Sub
    Sub exportar()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            If gridConsulta.Rows.Count > 0 Then
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\GUIA_PROGRAMACION.xls")
                File.Copy(RutaReporteERP & "GUIAPROGRAMACION.xls", path & "\GUIA_PROGRAMACION.xls")
                m_Excel.Workbooks.Open(path & "\GUIA_PROGRAMACION.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 5
                nfilaini = 5

                With objHojaExcel
                    .Activate()
                    Dim viaje As String = ""
                    .Range("B2").Value = "GUIAS PROGRAMADAS DESPACHADAS AL DIA " & dtpFecha.Value & "  -  " & txtproveedor.Text.Trim
                    .Range("B2").Font.Bold = True
                    Dim filaultima As Int32 = 0
                    Dim contactivo As Int32 = 0
                    For i As Int16 = 0 To gridConsulta.Rows.Count - 1
                        '.Range("A" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("NUMDOC").Value
                        .Range("B" & nfilaini + i).Value = gridConsulta.Rows(i).Cells("NUMPEDIDO").Value
                        .Range("C" & nfilaini + i).Value = gridConsulta.Rows(i).Cells("PRODUCTO").Value.ToString.Trim
                        .Range("D" & nfilaini + i).Value = gridConsulta.Rows(i).Cells("NROVIAJE").Value
                        .Range("E" & nfilaini + i).Value = gridConsulta.Rows(i).Cells("PLACA").Value
                        .Range("F" & nfilaini + i).Value = gridConsulta.Rows(i).Cells("NUMGUIA").Value
                        .Range("G" & nfilaini + i).Value = gridConsulta.Rows(i).Cells("CANTIDADGUIA").Value
                        .Range("H" & nfilaini + i).Value = gridConsulta.Rows(i).Cells("NROTICKET").Value
                        .Range("I" & nfilaini + i).Value = gridConsulta.Rows(i).Cells("ESTADO").Value
                        .Range("J" & nfilaini + i).Value = gridConsulta.Rows(i).Cells("ESTADOORI").Value
                        '.Range(.Cells(nfilaini + i, 2), .Cells(nfilaini + i, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfila + 1
                        filaultima = nfilaini + i
                    Next
                    filaultima += 1
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 6)).Value = "TOTAL"
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 6)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(filaultima + 1, 7), .Cells(filaultima + 1, 7)).Formula = "=SUMA(G5:G" & filaultima & ")"
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 7)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 7)).Font.Bold = True
                    filaultima = filaultima + 1
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 6)).Value = "TOTAL DESPACHADO"
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 6)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(filaultima + 1, 7), .Cells(filaultima + 1, 7)).Formula = "=SUMAR.SI.CONJUNTO(G5:G" & filaultima - 1 & ",J5:J" & filaultima - 1 & ",""DESPACHADO"")"
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 7)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                    '.Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 7)).Font.Bold = True

                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
End Class