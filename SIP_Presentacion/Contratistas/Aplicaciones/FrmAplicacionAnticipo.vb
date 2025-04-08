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
Imports Infragistics

Public Class FrmAplicacionAnticipo
    Dim dtDetalle As DataTable
    Dim estadoContable As Int32 = 0
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
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
    Public tipoconsulta As Int32 = 0
#End Region
    Dim cant_supervisor As Int32 = 0
    Private Sub FrmAplicacionAnticipo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtfecha.Value = Now.Date
        dtpfechaini.Value = "01/" & Month(Now.Date).ToString & "/" & Year(Now.Date).ToString
        dtpfechafin.Value = Now.Date
        dtDetalle = New DataTable
        If dtDetalle.Columns.Count <= 1 Then
            creaTablaDetalle()
        End If
    End Sub

    Sub creaTablaDetalle()
        dtDetalle.Columns.Add("TIPO_DOC")
        dtDetalle.Columns.Add("SERIE")
        dtDetalle.Columns.Add("NUMDOC")
        dtDetalle.Columns.Add("MONEDA")
        dtDetalle.Columns.Add("SALDO")
        dtDetalle.Columns.Add("IMPORTE")
        dtDetalle.Columns.Add("IMPORTE_ANTICIPO")
        dtDetalle.Columns.Add("COD_PROV")
        dtDetalle.Columns.Add("TCAMBIO")
        dtDetalle.Columns.Add("COD_TIPODOC")
        dtDetalle.Columns.Add("FECHA_DOC")
    End Sub

    Sub Procesar()

        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DsDatos As DataSet = Nothing
        Dim DtConsulta As DataTable = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .FechIniVig = dtpfechaini.Value
                .FechFinVig = dtpfechafin.Value
                .User_Crea = User_Sistema
            End With

            DsDatos = oPrvFisN.ConsultaCTRAplicaciones(oPrvFisE)
            DtConsulta = DsDatos.Tables(0)
            Call CargarUltraGridxBinding(Grid1, Source1, DtConsulta)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Sub Nuevo()
        Me.Tab1.Tabs("T02").Selected = True
        limpiar()
    End Sub

    Sub limpiar()
        txtcodcantera.Clear()
        txtcantera.Clear()
        txtsupervisor.Clear()
        txtidcontratista.Text = 0
        txtidsupervisor.Text = 0
        txttotalanti.Text = "0.00"
        txttotaldoc.Text = "0.00"
        ListaAnticipo(txtidcontratista.Text)
        dtDetalle.Rows.Clear()
    End Sub

    Sub Buscar()
        If Me.Tab1.Tabs("T01").Selected = True Then Exit Sub
        If Ope = 2 Then Exit Sub
        If txtcodcontratista.Focused = True Then
            limpiar()
            Dim frm As New frmBuscarContratista
            frm.ShowDialog()
            txtcodcontratista.Text = frm.gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            txtcontratista.Text = frm.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
        End If

        If txtcodcantera.Focused = True Then
            limpiar()
            If txtcodcontratista.Text.Trim = "" Then
                MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            Dim frm As New frmBuscarCantera
            frm.codprov = txtcodcontratista.Text
            frm.ShowDialog()
            txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            txtcodcantera.Text = frm.gridcontratista.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcantera.Text = frm.gridcontratista.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
            ' VER LA CANTIDAD DE SUPERVISORES QUE HAY POR CANTERA
            Supervisor_Cantera(txtcodcontratista.Text, txtcodcantera.Text)
            ListaAnticipo(txtidcontratista.Text)
        End If

        If txtsupervisor.Focused = True Then
            If txtcodcantera.Text.Trim = "" Then
                MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            Dim frm As New frmBuscarSupervisor
            frm.codprov = txtcodcontratista.Text
            frm.cod_cantera = txtcodcantera.Text
            frm.ShowDialog()
            If frm.gridcontratista.Rows.Count = 0 Then
                txtidsupervisor.Text = 0
                txtsupervisor.Text = ""
            Else
                txtidsupervisor.Text = frm.gridcontratista.ActiveRow.Cells("ID_SUPERVISOR").Value
                txtsupervisor.Text = frm.gridcontratista.ActiveRow.Cells("SUPERVISOR").Value.ToString.Trim
            End If
        End If
    End Sub

    'Sub comboMoneda()
    '    Dim valueList = New ValueList()
    '    valueList.ValueListItems.Add("S", "S/.")
    '    valueList.ValueListItems.Add("D", "US$")
    '    gridDocumento.DisplayLayout.Bands(0).Columns("moneda").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
    '    gridDocumento.DisplayLayout.Bands(0).Columns("moneda").ValueList = valueList
    '    gridDocumento.DisplayLayout.Bands(0).Columns("moneda").ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
    'End Sub

    Sub ListaAnticipo(ByVal idcontratista As Int32)
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DsDatos As DataSet = Nothing
        Dim DtConsulta As DataTable = Nothing
        oPrvFisN = New NGProveedorFiscalizado
        oPrvFisE = New ETProveedorFiscalizado

        With oPrvFisE
            .Fecha = dtfecha.Value
            .id = idcontratista
            .User_Crea = User_Sistema
        End With

        DsDatos = oPrvFisN.ConsultaCTRListaAnticipo(oPrvFisE)
        DtConsulta = DsDatos.Tables(0)
        Call CargarUltraGridxBinding(gridconceptos, Source2, DtConsulta)
        dtDetalle.Rows.Clear()
        AgregarDocumento()
        'comboMoneda()
    End Sub

    Sub AgregarDocumento()
        Dim dr As DataRow
        dr = dtDetalle.NewRow
        dr(0) = ""
        dr(1) = ""
        dr(2) = ""
        dr(3) = ""
        dr(4) = "0.00"
        dr(5) = "0.00"
        dr(6) = ""
        dr(7) = ""
        dr(8) = "0.00"
        dr(9) = ""
        dtDetalle.Rows.Add(dr)
        Call CargarUltraGridxBinding(gridDocumento, Source3, dtDetalle)
    End Sub
    Sub ElimnaDocumento()
        gridDocumento.ActiveRow.Delete()
        Total()
    End Sub
    Sub Supervisor_Cantera(ByVal codprov As String, ByVal cod_cantera As String)
        Try
            Dim objNegocio As NGContratista = Nothing
            Dim objEntidad As ETContratista = Nothing
            objNegocio = New NGContratista
            objEntidad = New ETContratista

            objEntidad._codprov = codprov
            objEntidad._codcantera = cod_cantera
            Dim dtContratista As New DataTable
            dtContratista = objNegocio.ListarSupervisor_Contratista(objEntidad)
            cant_supervisor = dtContratista.Rows.Count
            If cant_supervisor = 1 Then
                txtidsupervisor.Text = dtContratista.Rows(0)(0)
                txtsupervisor.Text = dtContratista.Rows(0)(1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub gridconceptos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridconceptos.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridconceptos) Then Return
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

                        If gridconceptos.ActiveRow.Cells(gridconceptos.ActiveCell.Column.Index).Column.Key = "IMPORTE" Then
                            Total()
                        End If

                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        'btnAgregar.Enabled = True
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridDocumento_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridDocumento.ClickCellButton
        Try
            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            Dim DsDatos As DataSet = Nothing
            Dim DtConsulta As DataTable = Nothing
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            With oPrvFisE
                .Fecha = dtfecha.Value
                .id = txtidcontratista.Text
                .User_Crea = User_Sistema
            End With
            DsDatos = oPrvFisN.ConsultaCTRListaDocumento(oPrvFisE)
            DtConsulta = DsDatos.Tables(0)

            Dim frm As New FrmFacturasCTR
            frm.dtFacturaCTR = DtConsulta
            frm.ShowDialog()
            gridDocumento.ActiveRow.Cells("TIPO_DOC").Value = frm.tipo_doc
            gridDocumento.ActiveRow.Cells("SERIE").Value = frm.numdoc.Substring(0, 4)
            gridDocumento.ActiveRow.Cells("NUMDOC").Value = frm.numdoc

            If Not ValidarDocumentoRepetido(gridDocumento.ActiveRow.Index) Then
                gridDocumento.ActiveRow.Cells("TIPO_DOC").Value = ""
                gridDocumento.ActiveRow.Cells("SERIE").Value = ""
                gridDocumento.ActiveRow.Cells("NUMDOC").Value = ""
                gridDocumento.PerformAction(FirstCellInRow)
                gridDocumento.PerformAction(EnterEditMode)
                Return
            End If

            gridDocumento.ActiveRow.Cells("SALDO").Value = frm.saldo
            gridDocumento.ActiveRow.Cells("MONEDA").Value = frm.moneda
            gridDocumento.ActiveRow.Cells("IMPORTE").Value = frm.saldo
            gridDocumento.ActiveRow.Cells("COD_TIPODOC").Value = frm.cod_tipodoc
            gridDocumento.ActiveRow.Cells("FECHA_DOC").Value = frm.fecha
            gridDocumento.ActiveRow.Cells("COD_PROV").Value = txtcodcontratista.Text
            AgregarDocumento()
            Total()
            'gridDocumento.PerformAction(LastCellInRow)
            gridDocumento.PerformAction(NextCellByTab)
            gridDocumento.PerformAction(NextCellByTab)
            gridDocumento.PerformAction(NextCellByTab)
            gridDocumento.PerformAction(NextCellByTab)
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub gridDocumento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDocumento.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If e.KeyValue = "46" Then
                Dim fila As Int32 = gridDocumento.ActiveRow.Index
                ElimnaDocumento()
                'gridDocumento.PerformAction(FirstCellInRow)
                'gridDocumento.PerformAction(AboveRow)
                e.Handled = True
                Return
            End If
            If Not (sender Is gridDocumento) Then Return
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
                        If gridDocumento.ActiveRow.Cells(gridDocumento.ActiveCell.Column.Index).Column.Key = "IMPORTE" Then
                            Total()
                        End If
                        If gridDocumento.ActiveRow.Cells(gridDocumento.ActiveCell.Column.Index).Column.Key = "SERIE" Then
                            If Not ValidarDocumentoRepetido(gridDocumento.ActiveRow.Index) Then gridDocumento.ActiveRow.Cells("SERIE").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                            gridDocumento.ActiveRow.Cells("SERIE").Value = gridDocumento.ActiveRow.Cells("SERIE").Value.ToString.Trim.PadLeft(4, "0")
                        End If

                        If gridDocumento.ActiveRow.Cells(gridDocumento.ActiveCell.Column.Index).Column.Key = "NUMDOC" Then
                            If Not ValidarDocumentoRepetido(gridDocumento.ActiveRow.Index) Then gridDocumento.ActiveRow.Cells("NUMDOC").Value = "" : e.Handled = True : .PerformAction(EnterEditMode) : Return
                            gridDocumento.ActiveRow.Cells("NUMDOC").Value = gridDocumento.ActiveRow.Cells("NUMDOC").Value.ToString.Trim.PadLeft(16, "0")
                        End If

                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        'btnAgregar.Enabled = True
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub

    Function ValidarDocumentoRepetido(ByVal fila As Integer) As Boolean
        Try
            If gridDocumento.Rows.Count > 0 Then
                Me.gridDocumento.PerformAction(ExitEditMode)
                Dim tipdoc As String = Me.gridDocumento.Rows(fila).Cells("TIPO_DOC").Value.ToString.Trim
                Dim serdoc As String = Me.gridDocumento.Rows(fila).Cells("SERIE").Value.ToString.PadLeft(4, "0")
                Dim numdoc As String = Me.gridDocumento.Rows(fila).Cells("NUMDOC").Value.ToString.PadLeft(16, "0")                
                Dim cadenavalidar = tipdoc + serdoc + numdoc
                Dim cadenacomparar As String = String.Empty
                For i As Int32 = 0 To gridDocumento.Rows.Count - 1
                    cadenacomparar = Me.gridDocumento.Rows(i).Cells("TIPO_DOC").Value.ToString.Trim + Me.gridDocumento.Rows(i).Cells("SERIE").Value.ToString.PadLeft(4, "0") + Me.gridDocumento.Rows(i).Cells("NUMDOC").Value.ToString.PadLeft(16, "0")
                    If Not i = fila Then
                        If cadenavalidar = cadenacomparar Then
                            MsgBox("El documento " & numdoc & " ya fue registrado", MsgBoxStyle.Exclamation, msgComacsa)
                            Me.gridDocumento.PerformAction(EnterEditMode)
                            Return False
                        End If
                    End If
                Next
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function

    Private Sub gridDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridDocumento.KeyPress
        Try
            If e.KeyChar = "+" Then
                AgregarDocumento()
                gridDocumento.PerformAction(LastCellInRow)
                gridDocumento.PerformAction(NextCellByTab)
                e.Handled = True
                Return
            End If
            If e.KeyChar = "-" Then
                Dim fila As Int32 = gridDocumento.ActiveRow.Index
                ElimnaDocumento()
                'gridDocumento.PerformAction(FirstCellInRow)
                'gridDocumento.PerformAction(AboveRow)
                e.Handled = True
                Return
            End If
            If e.KeyChar = ChrW(Keys.Escape) Then Return
            If e.KeyChar = ChrW(Keys.Delete) Then Return
            If e.KeyChar = ChrW(Keys.Return) Then Return
            If e.KeyChar = ChrW(Keys.Back) Then Return
            If e.KeyChar.ToString.Trim = "" Then Return

            'If gridDocumento.ActiveRow.Cells(gridDocumento.ActiveCell.Column.Index).Column.Key = "TIPO_DOC" Then
            '    If e.KeyChar.ToString.Trim = "" Then Return
            '    Dim frm As New FrmListadoDocumentos
            '    frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
            '    frm.ShowDialog()
            '    If codTipoDoc.Trim = "" Then e.Handled = True : Return
            '    gridDocumento.Rows(gridDocumento.ActiveRow.Index).Cells("TIPO_DOC").Value = TipoDoc
            '    codTipoDoc = ""
            '    TipoDoc = ""
            '    gridDocumento.PerformAction(NextCellByTab)
            '    e.Handled = True
            '    Exit Sub
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridDocumento_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridDocumento.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridDocumento Then Return
        e.DisplayPromptMsg = Boolean.FalseString
    End Sub

    Sub Total()
        Dim total_aticipo As Double = 0
        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            total_aticipo = total_aticipo + gridconceptos.Rows(i).Cells("IMPORTE").Value
        Next
        txttotalanti.Text = total_aticipo.ToString("###,##0.00")

        Dim total_documento As Double = 0
        For i As Int32 = 0 To gridDocumento.Rows.Count - 1
            If gridDocumento.Rows(i).Cells("NUMDOC").Value <> "" Then
                total_documento = total_documento + gridDocumento.Rows(i).Cells("IMPORTE").Value
            End If
        Next
        txttotaldoc.Text = total_documento.ToString("###,##0.00")
    End Sub

    Sub Grabar()
        verificaestadoContable()
        If estadoContable = 1 Then
            MsgBox("El mes ya se encuentra cerrado", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        If estadoContable = 3 Or estadoContable = 5 Then
            MsgBox("El mes no se encuentra aperturado", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If CDbl(txttotalanti.Text) + CDbl(txttotaldoc.Text) = 0 Then
            MsgBox("El importe aplicado debe ser mayor a Cero", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If CDbl(txttotalanti.Text) <> CDbl(txttotaldoc.Text) Then
            MsgBox("Totales no son iguales", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return
        End If

        'GRABAMOS LOS ANTICIPOS
        Dim oPrvFisN As NGContratista = Nothing
        Dim oPrvFisE As ETContratista = Nothing

        oPrvFisN = New NGContratista
        oPrvFisE = New ETContratista

        oPrvFisE.Anho = Year(dtfecha.Value)
        Dim dtNumVoucher As New DataTable
        dtNumVoucher = oPrvFisN.CTR_ANT_NUMERO_VOUCHER(oPrvFisE)
        Dim Numero_Voucher As String = ""
        If dtNumVoucher.Rows.Count > 0 Then
            Numero_Voucher = dtNumVoucher.Rows(0)(0)
        End If

        Dim DsDatos As DataSet = Nothing
        Dim DtConsulta As DataTable = Nothing
        Dim importe_anticipo As Double = 0
        Dim cont As Int32 = 0
        For i As Int32 = 0 To gridconceptos.Rows.Count - 1
            importe_anticipo = gridconceptos.Rows(i).Cells("IMPORTE").Value
            If importe_anticipo <> 0 Then
                cont += 1
                oPrvFisN = New NGContratista
                oPrvFisE = New ETContratista
                With oPrvFisE
                    .COD_PROCESO = "55"
                    ._codprov = txtcodcontratista.Text
                    .TIPO_ANT = gridconceptos.Rows(i).Cells("TIPO_DOC").Value
                    .nrodoc = gridconceptos.Rows(i).Cells("NUM_DOC").Value
                    .Fecha = gridconceptos.Rows(i).Cells("FECHA_DOC").Value
                    .FechaHora = dtfecha.Value
                    .codbanco = gridconceptos.Rows(i).Cells("COD_BANCO").Value
                    .NROASIGNADO = gridconceptos.Rows(i).Cells("NROASIGNADO").Value
                    .PLANILLA = Numero_Voucher
                    .moneda = gridconceptos.Rows(i).Cells("MONEDA").Value
                    ._importe_NC = importe_anticipo
                    ._item = cont
                    ._razon = txtcontratista.Text
                    .TCAMBIO = gridconceptos.Rows(i).Cells("T_CAMBIO").Value
                    .VOUCHER = Numero_Voucher
                    .TIPO_DOC_CAN = "AN"
                    .Usuario = User_Sistema
                    DtConsulta = oPrvFisN.CTR_INSERTA_CTAPAGKARDEX(oPrvFisE)
                End With
            End If
        Next


        DtConsulta = New DataTable
        Dim importe_documento As Double = 0
        cont = 0
        For i As Int32 = 0 To gridDocumento.Rows.Count - 1
            importe_documento = gridDocumento.Rows(i).Cells("IMPORTE").Value
            If importe_documento <> 0 Then
                cont += 1
                oPrvFisN = New NGContratista
                oPrvFisE = New ETContratista
                With oPrvFisE
                    .COD_PROCESO = "55"
                    ._codprov = txtcodcontratista.Text
                    .TIPO_ANT = gridDocumento.Rows(i).Cells("COD_TIPODOC").Value
                    .nrodoc = gridDocumento.Rows(i).Cells("NUMDOC").Value
                    .Fecha = gridDocumento.Rows(i).Cells("FECHA_DOC").Value
                    .FechaHora = dtfecha.Value
                    .codbanco = ""
                    .NROASIGNADO = ""
                    .PLANILLA = Numero_Voucher
                    .moneda = gridDocumento.Rows(i).Cells("MONEDA").Value
                    ._importe_NC = importe_documento
                    ._item = cont
                    ._razon = txtcontratista.Text
                    .TCAMBIO = 0 'gridDocumento.Rows(i).Cells("TCAMBIO").Value
                    .VOUCHER = Numero_Voucher
                    .TIPO_DOC_CAN = "DC"
                    .Usuario = User_Sistema
                    DtConsulta = oPrvFisN.CTR_INSERTA_CTAPAGKARDEX(oPrvFisE)
                End With
            End If
        Next

        ' GENERAMOS EL ASISENTO CONTABLE
        oPrvFisN = New NGContratista
        oPrvFisE = New ETContratista

        oPrvFisE.Anho = Year(dtfecha.Value)
        oPrvFisE.Mes = Month(dtfecha.Value)
        oPrvFisE.Fecha = dtfecha.Value
        oPrvFisE.VOUCHER = Numero_Voucher
        oPrvFisE.Usuario = User_Sistema
        dtNumVoucher = New DataTable
        dtNumVoucher = oPrvFisN.CTR_ANT_GENERA_ASIENTO(oPrvFisE)
        Dim VoucherConta As String = ""
        If dtNumVoucher.Rows.Count > 0 Then
            VoucherConta = dtNumVoucher.Rows(0)(0)
        End If

        ' IMPRIMIMOS EL ASISENTO CONTABLE

        MsgBox("N° de registro generado : " & VoucherConta, MsgBoxStyle.Exclamation, msgComacsa)
        lblmensaje.Text = "Generando Reporte de Asiento..."
        lblmensaje.Refresh()
        lblmensaje.Update()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Refresh()
        lblmensaje.Update()
        StrucForm.FxRxCancelacionAnt = New FrmRptCancelacionAnt
        StrucForm.FxRxCancelacionAnt.MdiParent = MdiParent
        StrucForm.FxRxCancelacionAnt.flgprovision = "0"
        StrucForm.FxRxCancelacionAnt.ayo = Year(dtfecha.Value)
        StrucForm.FxRxCancelacionAnt.mes = Month(dtfecha.Value)
        StrucForm.FxRxCancelacionAnt.cgvoucher = Numero_Voucher
        StrucForm.FxRxCancelacionAnt.voucherconta = VoucherConta
        StrucForm.FxRxCancelacionAnt.Show()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Me.Tab1.Tabs("T01").Selected = True
        limpiar()
        'Call LimpiarDatos()
        'lblmoneda.Visible = False
        Exit Sub

    End Sub

    Sub verificaestadoContable()
        Entidad.Entregas.añocontable = Convert.ToInt32(Year(dtfecha.Value))
        Entidad.Entregas.mescontable = Convert.ToInt32(Month(dtfecha.Value))
        Entidad.MyLista = Negocio.NEntregas.VerificaCierreContable(Entidad.Entregas)
        lResult = New ETMyLista
        lResult = Entidad.MyLista

        If Entidad.MyLista.Ls_Entrega.Count = 0 Then
            estadoContable = 5
        Else
            estadoContable = Entidad.MyLista.Ls_Entrega.Item(0).estadocontable
        End If

    End Sub

    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow
        Try
            Me.Tab1.Tabs("T02").Selected = True
        Catch ex As Exception

        End Try
    End Sub

End Class