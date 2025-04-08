Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class FrmConsultas
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
    Private Sub FrmConsultas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpinicio.Value = "01/01/2014"
        Me.dtpfin.Value = Now.Date
        Call CargarDatos()
    End Sub
    Private Sub CargarDatos()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.TipoOperacion = Ope
        Entidad.Entregas.Usuario = User_Sistema
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Ls_EntregaDetalle = Nothing
        Ls_EntregaDetalle = New List(Of ETEntregas)
        Ls_DetalleComp = New List(Of ETEntregas)
        Call CargarUltraGrid(gridDetalle, Ls_DetalleComp)
        Call CargarUltraGrid(GridConsultaDetalle, Ls_Entrega)
        Gpb1.Text = "DETALLE DE COMPROBANTES DE PAGO"
        Entidad.MyLista = Negocio.NEntregas.ConsultaEntregas(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.GridConsultas, Source1, Ls_Entrega)
    End Sub

    Private Sub GridConsultas_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridConsultas.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "CodTrabajador" OrElse uColumn.Key = "Motivo" _
                    OrElse uColumn.Key = "NomTrabajador" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "Action") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Sub actualizar()
        Call CargarDatos()
    End Sub
    Sub cancelar()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.TipoOperacion = Ope
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Ls_EntregaDetalle = Nothing
        Ls_EntregaDetalle = New List(Of ETEntregas)
        Ls_DetalleComp = New List(Of ETEntregas)
        Call CargarUltraGrid(gridDetalle, Ls_DetalleComp)
        Call CargarUltraGrid(GridConsultaDetalle, Ls_Entrega)
        Gpb1.Text = "DETALLE DE COMPROBANTES DE PAGO"
    End Sub

    Private Sub GridConsultas_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridConsultas.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot GridConsultas Then Return

        If e.Row.IsFilterRow Then Return

        Me.dtpinicio.Value = "01/01/2016"
        Me.dtpfin.Value = Now.Date
        Me.rdbxrendir.Checked = True
        SubProceso_Entregas(e.Row)
    End Sub
    Sub PROCESAR()
        SubProceso_Entregas(GridConsultas.ActiveRow)
    End Sub
    Private Function ValidaLineacredito(ByVal codTrabajador As String) As Boolean
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.CodTrabajador = codTrabajador
        Entidad.MyLista = Negocio.NEntregas.ValidaLineacredito(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Ls_Entrega.Count > 0 Then
            lineacredito = Entidad.MyLista.Ls_Entrega.Item(0).lineacredito
            Return True
        Else
            Return False
        End If
    End Function
    'Dim disponible As Double
    Sub SubProceso_Entregas(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.MyLista = New ETMyLista
        Entidad.Entregas.CodTrabajador = uRow.Cells("CodTrabajador").Value
        Entidad.Entregas.FechaInicio = dtpinicio.Value.ToString("dd/MM/yyyy")
        Entidad.Entregas.FechaTerminacion = dtpfin.Value.ToString("dd/MM/yyyy")
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.Entregas.Tipo = 1
        If ValidaLineacredito(Entidad.Entregas.CodTrabajador) And rdbxrendir.Checked = True Then txtlineacredito.Text = lineacredito.ToString("0.00") : txtdisponible.Text = lineacredito.ToString("0.00")

        If Me.rdbxrendir.Checked = True Then
            Entidad.Entregas.tipofiltro = "PR"
        End If
        If Me.rdbrendida.Checked = True Then
            Entidad.Entregas.tipofiltro = "R"
        End If
        If Me.rdbtotal.Checked = True Then
            Entidad.Entregas.tipofiltro = "T"
        End If
        Entidad.Entregas.NumSolicitud = ""
        Entidad.Entregas.TipoImpresion = 0
        lbltrabajador.Text = uRow.Cells("NomTrabajador").Value.ToString.ToUpper
        lblcodigo.Text = uRow.Cells("CodTrabajador").Value.ToString.Trim
        Entidad.MyLista = Negocio.NEntregas.ConsultaEntregasDetalle(Entidad.Entregas)

        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If

        If Entidad.MyLista.Validacion Then TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString : Call CargarUltraGridxBinding(Me.GridConsultaDetalle, Source2, Ls_Entrega) ' : CargarDatos()
        Ls_DetalleComp = New List(Of ETEntregas)
        Call CargarUltraGrid(gridDetalle, Ls_DetalleComp)
        Dim solicitado As Double = 0
        Dim liquidado As Double = 0

        txtsolicitado.Text = solicitado.ToString("0.00")
        txtliquidado.Text = liquidado.ToString("0.00")

        If GridConsultaDetalle.Rows.Count > 0 Then
            For i As Int32 = 0 To GridConsultaDetalle.Rows.Count - 1
                If Not GridConsultaDetalle.Rows(i).Cells("NumSolicitud").Value.ToString.Substring(0, 1) = "S" Then
                    solicitado = solicitado + GridConsultaDetalle.Rows(i).Cells("montoParcial").Value
                End If
                liquidado = liquidado + GridConsultaDetalle.Rows(i).Cells("montoTotalParcial").Value
            Next
            txtsolicitado.Text = solicitado.ToString("0.00")
            txtliquidado.Text = liquidado.ToString("0.00")
        End If
        If uRow.Cells("Motivo").Value.ToString.Trim = "PENDIENTE" Then
            txtxrendir.Text = uRow.Cells("montoTotal").Value
            txtdisponible.Text = lineacredito - uRow.Cells("montoTotal").Value
            txtdisponible.Text = CDbl(txtdisponible.Text).ToString("0.00")
        Else
            txtxrendir.Text = "0.00"
            txtdisponible.Text = lineacredito.ToString("0.00")
        End If
        If Math.Round(CDbl(uRow.Cells("montoTotal").Value), 2) < 0 Then
            txtreintegrar.Text = CDbl(uRow.Cells("montoTotal").Value).ToString("0.00")
        Else
            txtreintegrar.Text = "0.00"
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Private Sub GridConsultaDetalle_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridConsultaDetalle.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot GridConsultaDetalle Then Return
        If e.Row.IsFilterRow Then Return
        SubProceso_Detalle(e.Row)
    End Sub

    Private Sub GridConsultaDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridConsultaDetalle.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "NumSolicitud" OrElse uColumn.Key = "Fecha" OrElse uColumn.Key = "montoParcial" _
                    OrElse uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "Motivo" OrElse uColumn.Key = "montoTotal" OrElse uColumn.Key = "moneda" OrElse uColumn.Key = "tipodeposito" OrElse uColumn.Key = "Cantera" OrElse uColumn.Key = "dias") Then 'OrElse uColumn.Key = "NumDoc"
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Sub SubProceso_Detalle(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If

        'Gpb1.Enabled = False

        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista

        Entidad.MyLista = Negocio.NEntregas.UsuarioAprobacion(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        nroSolicitud = uRow.Cells("NumSolicitud").Value
        Gpb1.Text = "DETALLE DE COMPROBANTES DE PAGO - SOLICITUD N° " & nroSolicitud
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        If Entidad.MyLista.Validacion Then Call cargarValoresDetalle(nroSolicitud)
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Sub cargarValoresDetalle(ByVal numsolicitud As String)
        Entidad.Entregas.NumSolicitud = NumSolicitud
        Entidad.MyLista = Negocio.NEntregas.Listar_DetalleLiquidacion(Entidad.Entregas)
        Ls_DetalleComp = New List(Of ETEntregas)

        If Entidad.MyLista.Validacion Then
            Ls_DetalleComp = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGrid(gridDetalle, Ls_DetalleComp)

    End Sub

    Private Sub gridDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDetalle.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "fechaComp" OrElse uColumn.Key = "TipoDoc" OrElse uColumn.Key = "NumDoc" OrElse _
                    uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Razon" OrElse uColumn.Key = "Serie") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Sub Reporte()
        Try
            lblmensaje.Visible = True
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            If TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString Then
                ReporteGeneral()
            Else
                ReporteDetalle()
            End If
        Catch ex As Exception
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End Try
    End Sub

    Sub ReporteGeneral()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
        
            If GridConsultas.Rows.Count > 0 Then

                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTESALDOS.xls")
                File.Copy(RutaReporteERP & "PLANTILLASALDOS.xls", path & "\REPORTESALDOS.xls")
                m_Excel.Workbooks.Open(path & "\REPORTESALDOS.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 13
                nfilaini = 13

                With objHojaExcel
                    .Activate()
                    .Range("A2").Value = "SALDOS POR TRABAJADOR AL " & Now.Date.ToString("dd/MM/yyyy")
                    .Range("A2").Font.Bold = True
                    Dim filaultima As Int32 = 0

                    For i As Int16 = 0 To GridConsultas.Rows.Count - 1
                        .Range("A" & 5 + i).Value = GridConsultas.Rows(i).Cells("CodTrabajador")
                        .Range("B" & 5 + i).Value = GridConsultas.Rows(i).Cells("NomTrabajador")
                        .Range("C" & 5 + i).Value = GridConsultas.Rows(i).Cells("motivo")
                        .Range("D" & 5 + i).Value = GridConsultas.Rows(i).Cells("montoTotal")

                        .Range(.Cells(5 + i, 1), .Cells(5 + i, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                        nfila = nfila + 1
                        filaultima = 5 + i
                    Next
                    .Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 3)).Value = "Total"
                    .Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 4)).Formula = "=SUMA(D5:D" & filaultima & ")"
                    .Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 4)).Font.Bold = True
                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub ReporteDetalle()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            Dim cadenaSolicitud As String = String.Empty
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Entidad.MyLista = New ETMyLista
            Entidad.Entregas.CodTrabajador = lblcodigo.Text
            Entidad.Entregas.FechaInicio = dtpinicio.Value.ToString("dd/MM/yyyy")
            Entidad.Entregas.FechaTerminacion = dtpfin.Value.ToString("dd/MM/yyyy")
            Entidad.Entregas.Usuario = User_Sistema
            Entidad.Entregas.Tipo = 2
            If ValidaLineacredito(Entidad.Entregas.CodTrabajador) Then txtlineacredito.Text = lineacredito.ToString("0.00")
            If Me.rdbxrendir.Checked = True Then
                Entidad.Entregas.tipofiltro = "PR"
            End If
            If Me.rdbrendida.Checked = True Then
                Entidad.Entregas.tipofiltro = "R"
            End If
            If Me.rdbtotal.Checked = True Then
                Entidad.Entregas.tipofiltro = "T"
            End If
            Entidad.Entregas.NumSolicitud = ""
            Entidad.Entregas.TipoImpresion = 0
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NEntregas.ConsultaReporte(Entidad.Entregas)
            Entidad.Entregas.Tipo = 3
            Dim dtDatos2 As New DataTable
            dtDatos2 = Negocio.NEntregas.ConsultaReporte(Entidad.Entregas)
            If dtDatos.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                lblmensaje.Update()
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTE.xls")
                File.Copy(RutaReporteERP & "PLANTILLA CONSULTA ENTREGAS.xls", path & "\REPORTE.xls")
                m_Excel.Workbooks.Open(path & "\REPORTE.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 13
                nfilaini = 13

                With objHojaExcel
                    .Activate()
                    .Range("B6").Value = lblcodigo.Text
                    .Range("F6").Value = lbltrabajador.Text
                    .Range("K6").Value = dtDatos.Rows(0)("AREA")
                    Dim filaultima As Int32 = 0
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("A" & 13 + i).Value = dtDatos.Rows(i)("FECHAEMISION")
                        .Range("B" & 13 + i).Value = dtDatos.Rows(i)("TIPODEPOSITO")
                        .Range("C" & 13 + i).Value = dtDatos.Rows(i)("NUMSOLICITUD")
                        .Range("D" & 13 + i).Value = dtDatos.Rows(i)("CANTERA")
                        .Range("E" & 13 + i).Value = dtDatos.Rows(i)("MOTIVO")
                        .Range("F" & 13 + i).Value = dtDatos.Rows(i)("MONTOSOLICITUD")
                        .Range("G" & 13 + i).Value = dtDatos.Rows(i)("FECHALIQUIDACION")
                        .Range("H" & 13 + i).Value = dtDatos.Rows(i)("NUMEROLIQUI")
                        .Range("I" & 13 + i).Value = dtDatos.Rows(i)("MONTOLIQUIDACION")
                        .Range("J" & 13 + i).Value = dtDatos.Rows(i)("SALDO")
                        .Range("K" & 13 + i).Value = dtDatos.Rows(i)("MONTOAPLICADO")
                        .Range("L" & 13 + i).Value = dtDatos.Rows(i)("MONTOREINTEGRADO")
                        .Range("M" & 13 + i).Value = dtDatos.Rows(i)("DIASMOROSIDAD")
                        .Range(.Cells(13 + i, 1), .Cells(13 + i, 13)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                        If .Cells(nfilaini, 3).Value = .Cells(nfila, 3).Value Then
                            nfilault = nfila
                        Else
                            .Range(.Cells(nfilaini, 1), .Cells(nfilault, 1)).Merge()
                            .Range(.Cells(nfilaini, 2), .Cells(nfilault, 2)).Merge()
                            .Range(.Cells(nfilaini, 3), .Cells(nfilault, 3)).Merge()
                            .Range(.Cells(nfilaini, 4), .Cells(nfilault, 4)).Merge()
                            .Range(.Cells(nfilaini, 5), .Cells(nfilault, 5)).Merge()
                            .Range(.Cells(nfilaini, 6), .Cells(nfilault, 6)).Merge()
                            .Range(.Cells(nfilaini, 10), .Cells(nfilault, 10)).Merge()
                            .Range(.Cells(nfilaini, 10), .Cells(nfilault, 10)).Formula = "=SUMA(F" & nfilaini & ":F" & nfilault & ")-SUMA(I" & nfilaini & ":I" & nfilault & ")+ SUMA(K" & nfilaini & ":K" & nfilault & ")" & "+ SUMA(L" & nfilaini & ":L" & nfilault & ")"
                            nfilaini = nfila
                            nfilault = nfila
                        End If
                        nfila = nfila + 1
                        filaultima = 12 + i
                    Next
                    .Range(.Cells(nfilaini, 1), .Cells(nfilault, 1)).Merge()
                    .Range(.Cells(nfilaini, 2), .Cells(nfilault, 2)).Merge()
                    .Range(.Cells(nfilaini, 3), .Cells(nfilault, 3)).Merge()
                    .Range(.Cells(nfilaini, 4), .Cells(nfilault, 4)).Merge()
                    .Range(.Cells(nfilaini, 5), .Cells(nfilault, 5)).Merge()
                    .Range(.Cells(nfilaini, 6), .Cells(nfilault, 6)).Merge()
                    .Range(.Cells(nfilaini, 10), .Cells(nfilault, 10)).Merge()
                    .Range(.Cells(nfilaini, 10), .Cells(nfilault, 10)).Formula = "=SUMA(F" & nfilaini & ":F" & nfilault & ")-SUMA(I" & nfilaini & ":I" & nfilault & ")+ SUMA(K" & nfilaini & ":K" & nfilault & ")" & "+ SUMA(L" & nfilaini & ":L" & nfilault & ")"

                    .Range(.Cells(filaultima + 2, 8), .Cells(filaultima + 2, 9)).Merge()
                    .Range(.Cells(filaultima + 3, 8), .Cells(filaultima + 3, 9)).Merge()

                    .Range(.Cells(filaultima + 2, 8), .Cells(filaultima + 2, 8)).Value = "Saldo por rendir"
                    .Range(.Cells(filaultima + 2, 10), .Cells(filaultima + 2, 10)).Formula = txtxrendir.Text
                    .Range(.Cells(filaultima + 2, 10), .Cells(filaultima + 2, 10)).Interior.Color = 65535
                    .Range(.Cells(filaultima + 3, 8), .Cells(filaultima + 3, 8)).Value = "Línea de crédito disponible"
                    .Range(.Cells(filaultima + 3, 10), .Cells(filaultima + 3, 10)).Formula = txtdisponible.Text
                    .Range(.Cells(filaultima + 3, 10), .Cells(filaultima + 3, 10)).Interior.Color = 65535
                    .Rows(filaultima + 2 & ":" & filaultima + 2).RowHeight = 22.5
                    .Rows(filaultima + 3 & ":" & filaultima + 3).RowHeight = 22.5
                    .Range(.Cells(filaultima + 2, 8), .Cells(filaultima + 3, 10)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 2, 8), .Cells(filaultima + 3, 10)).Font.Bold = True

                    If CDbl(txtreintegrar.Text) <> 0 Then
                        .Range(.Cells(filaultima + 4, 8), .Cells(filaultima + 4, 9)).Merge()
                        .Range(.Cells(filaultima + 4, 8), .Cells(filaultima + 4, 8)).Value = "Saldo por reintegrar"
                        .Range(.Cells(filaultima + 4, 10), .Cells(filaultima + 4, 10)).Formula = txtreintegrar.Text
                        .Rows(filaultima + 4 & ":" & filaultima + 4).RowHeight = 22.5
                        .Range(.Cells(filaultima + 4, 8), .Cells(filaultima + 4, 10)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range(.Cells(filaultima + 4, 8), .Cells(filaultima + 4, 10)).Font.Bold = True
                        .Range(.Cells(filaultima + 4, 10), .Cells(filaultima + 4, 10)).Interior.Color = 65535
                    End If
                End With

                Dim objHojaExcel2 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                'Dim nfila As Integer
                'Dim nfilaini As Integer
                'Dim nfilault As Integer = 0

                nfila = 13
                nfilaini = 13

                With objHojaExcel2
                    '.Activate()
                    .Range("B6").Value = lblcodigo.Text
                    .Range("F6").Value = lbltrabajador.Text
                    .Range("K6").Value = dtDatos2.Rows(0)("AREA")
                    Dim filaultima As Int32 = 0
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("A" & 13 + i).Value = dtDatos2.Rows(i)("FECHAEMISION")
                        .Range("B" & 13 + i).Value = dtDatos2.Rows(i)("TIPODEPOSITO")
                        .Range("C" & 13 + i).Value = dtDatos2.Rows(i)("NUMSOLICITUD")
                        .Range("D" & 13 + i).Value = dtDatos2.Rows(i)("CANTERA")
                        .Range("E" & 13 + i).Value = dtDatos2.Rows(i)("MOTIVO")
                        .Range("F" & 13 + i).Value = dtDatos2.Rows(i)("MONTOSOLICITUD")
                        .Range("G" & 13 + i).Value = dtDatos2.Rows(i)("FECHALIQUIDACION")
                        .Range("H" & 13 + i).Value = dtDatos2.Rows(i)("NUMEROLIQUI")
                        .Range("I" & 13 + i).Value = dtDatos2.Rows(i)("MONTOLIQUIDACION")
                        .Range("J" & 13 + i).Value = dtDatos2.Rows(i)("SALDO")
                        .Range("K" & 13 + i).Value = dtDatos2.Rows(i)("MONTOAPLICADO")
                        .Range("L" & 13 + i).Value = dtDatos2.Rows(i)("MONTOREINTEGRADO")
                        .Range("M" & 13 + i).Value = dtDatos2.Rows(i)("DIASMOROSIDAD")
                        .Range(.Cells(13 + i, 1), .Cells(13 + i, 13)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        If .Cells(nfilaini, 3).Value = .Cells(nfila, 3).Value Then
                            nfilault = nfila
                        Else
                            .Range(.Cells(nfilaini, 1), .Cells(nfilault, 1)).Merge()
                            .Range(.Cells(nfilaini, 2), .Cells(nfilault, 2)).Merge()
                            .Range(.Cells(nfilaini, 3), .Cells(nfilault, 3)).Merge()
                            .Range(.Cells(nfilaini, 4), .Cells(nfilault, 4)).Merge()
                            .Range(.Cells(nfilaini, 5), .Cells(nfilault, 5)).Merge()
                            .Range(.Cells(nfilaini, 6), .Cells(nfilault, 6)).Merge()
                            .Range(.Cells(nfilaini, 10), .Cells(nfilault, 10)).Merge()
                            .Range(.Cells(nfilaini, 10), .Cells(nfilault, 10)).Formula = "=SUMA(F" & nfilaini & ":F" & nfilault & ")-SUMA(I" & nfilaini & ":I" & nfilault & ")+ SUMA(K" & nfilaini & ":K" & nfilault & ")" & "+ SUMA(L" & nfilaini & ":L" & nfilault & ")"
                            nfilaini = nfila
                            nfilault = nfila
                        End If
                        nfila = nfila + 1
                        filaultima = 12 + i
                    Next
                    .Range(.Cells(nfilaini, 1), .Cells(nfilault, 1)).Merge()
                    .Range(.Cells(nfilaini, 2), .Cells(nfilault, 2)).Merge()
                    .Range(.Cells(nfilaini, 3), .Cells(nfilault, 3)).Merge()
                    .Range(.Cells(nfilaini, 4), .Cells(nfilault, 4)).Merge()
                    .Range(.Cells(nfilaini, 5), .Cells(nfilault, 5)).Merge()
                    .Range(.Cells(nfilaini, 6), .Cells(nfilault, 6)).Merge()
                    .Range(.Cells(nfilaini, 10), .Cells(nfilault, 10)).Merge()
                    .Range(.Cells(nfilaini, 10), .Cells(nfilault, 10)).Formula = "=SUMA(F" & nfilaini & ":F" & nfilault & ")-SUMA(I" & nfilaini & ":I" & nfilault & ")+ SUMA(K" & nfilaini & ":K" & nfilault & ")" & "+ SUMA(L" & nfilaini & ":L" & nfilault & ")"
                    .Range(.Cells(filaultima + 2, 8), .Cells(filaultima + 2, 9)).Merge()
                    .Range(.Cells(filaultima + 3, 8), .Cells(filaultima + 3, 9)).Merge()
                    .Range(.Cells(filaultima + 2, 8), .Cells(filaultima + 2, 8)).Value = "Saldo por rendir"
                    .Range(.Cells(filaultima + 2, 10), .Cells(filaultima + 2, 10)).Formula = txtxrendir.Text
                    .Range(.Cells(filaultima + 2, 10), .Cells(filaultima + 2, 10)).Interior.Color = 65535
                    .Range(.Cells(filaultima + 3, 8), .Cells(filaultima + 3, 8)).Value = "Línea de crédito disponible"
                    .Range(.Cells(filaultima + 3, 10), .Cells(filaultima + 3, 10)).Formula = txtdisponible.Text
                    .Range(.Cells(filaultima + 3, 10), .Cells(filaultima + 3, 10)).Interior.Color = 65535
                    .Rows(filaultima + 2 & ":" & filaultima + 2).RowHeight = 22.5
                    .Rows(filaultima + 3 & ":" & filaultima + 3).RowHeight = 22.5
                    .Range(.Cells(filaultima + 2, 8), .Cells(filaultima + 3, 10)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 2, 8), .Cells(filaultima + 3, 10)).Font.Bold = True

                    If CDbl(txtreintegrar.Text) <> 0 Then
                        .Range(.Cells(filaultima + 4, 8), .Cells(filaultima + 4, 9)).Merge()
                        .Range(.Cells(filaultima + 4, 8), .Cells(filaultima + 4, 8)).Value = "Saldo por reintegrar"
                        .Range(.Cells(filaultima + 4, 10), .Cells(filaultima + 4, 10)).Formula = txtreintegrar.Text
                        .Rows(filaultima + 4 & ":" & filaultima + 4).RowHeight = 22.5
                        .Range(.Cells(filaultima + 4, 8), .Cells(filaultima + 4, 10)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        .Range(.Cells(filaultima + 4, 8), .Cells(filaultima + 4, 10)).Font.Bold = True
                        .Range(.Cells(filaultima + 4, 10), .Cells(filaultima + 4, 10)).Interior.Color = 65535
                    End If

                End With


                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub


    Private Sub btnVerAsiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerAsiento.Click
        Try
            If GridConsultaDetalle.ActiveRow Is Nothing Then MsgBox("Debe seleccionar un registro", MsgBoxStyle.Information, msgComacsa) : Return
            nroSolicitud = Me.GridConsultaDetalle.ActiveRow.Cells("NumSolicitud").Value.ToString
            If nroSolicitud.ToString.Trim = "" Then Return
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            StrucForm.FxRxSolicitud = New FrmSolicitud
            StrucForm.FxRxSolicitud.MdiParent = MdiParent
            StrucForm.FxRxSolicitud.Show()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
            'StrucForm.FxRxSolicitud.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If GridConsultaDetalle.ActiveRow Is Nothing Then MsgBox("Debe seleccionar un registro", MsgBoxStyle.Information, msgComacsa) : Return
            nroSolicitud = Me.GridConsultaDetalle.ActiveRow.Cells("NumSolicitud").Value.ToString
            If nroSolicitud.ToString.Trim = "" Then Return
            If Not GridConsultaDetalle.ActiveRow.Cells("NumSolicitud").Value.ToString.Substring(0, 4) = "PEND" Then
                esDevolucion = 0
            Else
                esDevolucion = 1

            End If
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            StrucForm.FxRxLiquidacion = New FrmRptLiquidacion
            StrucForm.FxRxLiquidacion.MdiParent = MdiParent
            StrucForm.FxRxLiquidacion.esDevolucion = esDevolucion
            StrucForm.FxRxLiquidacion.Show()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub Manual()
        If Not TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString Then Exit Sub
        GridConsultas.PerformAction(ExitEditMode)
        lblmensaje.Visible = True
        lblmensaje.Text = "Enviado Correo..."
        lblmensaje.Refresh()
        lblmensaje.Update()
        Dim codtrabajador As String = ""
        Dim dt As New DataTable
        'ConsultaReporte()
        For i As Int32 = 0 To GridConsultas.Rows.Count - 1
            If GridConsultas.Rows(i).Cells("Action").Value = True Then
                codtrabajador = GridConsultas.Rows(i).Cells("CodTrabajador").Value.ToString
                Entidad.Entregas = New ETEntregas
                Negocio.NEntregas = New NGEntregas
                dt = Negocio.NEntregas.CorreoSaldo(codtrabajador)
            End If
            'MsgBox(GridConsultas.Rows(i).Cells("Action").Value.ToString)
        Next
        lblmensaje.Visible = False
        lblmensaje.Refresh()
        lblmensaje.Update()
    End Sub

    Private Sub TabMaestroEntregas_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabMaestroEntregas.SelectedTabChanged

    End Sub
End Class