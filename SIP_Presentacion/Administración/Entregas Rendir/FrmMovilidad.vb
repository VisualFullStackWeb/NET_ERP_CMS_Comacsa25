Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Imports System.IO
'Imports Microsoft.Office.Interop.Excel
Public Class FrmMovilidad
    Public codtrabajador As String
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
    Public NumSolicitud As String = String.Empty
    Private TipoG As sTate
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_MovilidadAsociada As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private columna As String
    Private filtroConcepto As String = String.Empty
    Dim esDevolucion As Int32 = 0
    Dim totalPend As Double = 0
    Dim numInterno As String = String.Empty
    Public moneda As String = String.Empty
    Dim tipmon As String = String.Empty
    Dim estado As String = String.Empty
    Public mon As String = String.Empty
    Dim numDoc As String = String.Empty
    Dim item As Int32 = 0
    Public auxi As String = String.Empty
    Public codArea As String = String.Empty
    Public flgcompra As String = String.Empty
    Public cadena As String = String.Empty
    Public flgauxi As Int32 = 0
    Public fechaSalida As DateTime
    Public fechaRetorno As DateTime
#End Region

    Private Sub FrmMovilidad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Ls_MovilidadAsociada Is Nothing Then
            Ls_MovilidadAsociada = New List(Of ETEntregas)
        End If
        If moneda = "NUEVOS SOLES" Then
            UltraLabel6.Text = "Importe  S/."
            UltraLabel5.Text = "IMPORTE TOTAL  S/."
        Else
            UltraLabel6.Text = "Importe  US$"
            UltraLabel5.Text = "IMPORTE TOTAL  US$"
        End If
        If Ls_DocMovilidad.Count > 0 Then
            numDoc = Me.txtserie.Text.ToString.Trim.PadLeft(4, "0") & Me.txtnumero.Text.ToString.Trim.PadLeft(16, "0") '("0000000000000000")
            For i As Int32 = 0 To Ls_DocMovilidad.Count - 1
                item = i
                Dim Lista = Ls_DocMovilidad.Where(Function(m) m.nroruc = Me.txtruc.Text.ToString.Trim And _
                  m.TipoDoc = Me.txttd.Text.ToString.Trim And _
                  m.NumDoc = numDoc And m.item = item).FirstOrDefault
                If Not Lista Is Nothing Then
                    Ls_MovilidadAsociada.Add(Lista)
                End If
            Next
            Call CargarUltraGrid(gridDetalle, Ls_MovilidadAsociada)
            'gridDetalle.PerformAction(FirstCellInRow)
        End If
        If Ls_MovilidadAsociada.Count = 0 Then
            cargarFechas()
        End If
        CalcularTotalComprobantes()
        gridDetalle.Focus()
        gridDetalle.Rows(0).Cells(0).Activate()
        gridDetalle.PerformAction(EnterEditMode)
        gridDetalle.PerformAction(FirstCellInRow)
    End Sub

    Sub cargarFechas()
        Dim fechaMovilidad As DateTime = fechaSalida
        Dim dias As Int32 = 0
        dias = (fechaRetorno - fechaSalida).TotalDays
        For i As Int32 = 0 To dias
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.Fecha = fechaMovilidad.AddDays(i)
            Entidad.Entregas.montoTotalParcial = 0.0
            Entidad.Entregas.montoTotal = 0.0
            Entidad.Entregas.idComp = 0
            Entidad.Entregas.TipoOperacion = 1
            Ls_MovilidadAsociada.Add(Entidad.Entregas)
        Next
        Call CargarUltraGrid(gridDetalle, Ls_MovilidadAsociada)
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not ValidarCamposDetalle() Then Return
        CalcularTotalComprobantes()
        numDoc = Me.txtserie.Text.ToString.Trim.PadLeft(4, "0") & Me.txtnumero.Text.ToString.Trim.PadLeft(16, "0") '("0000000000000000")
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.fechaComp = Now.Date
        Entidad.Entregas.TipoDoc = txttd.Text.ToString.Trim
        Entidad.Entregas.NumDoc = numDoc
        Entidad.Entregas.nroruc = txtruc.Text.ToString.Trim
        Entidad.Entregas.Razon = txtrazon.Text.ToString.Trim
        Entidad.Entregas.Descripcion = String.Empty
        Entidad.Entregas.codConcepto = String.Empty
        Entidad.Entregas.Serie = String.Empty
        Entidad.Entregas.codAuxiliar = String.Empty
        Entidad.Entregas.tipocambio = 1.0
        If gridDetalle.Rows.Count > 0 Then
            Entidad.Entregas.codmotivoDetalle = gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("codMotivodetalle").Value.ToString.Trim
            Entidad.Entregas.motivoDetalle = gridDetalle.Rows(gridDetalle.Rows.Count - 1).Cells("motivoDetalle").Value.ToString.Trim
        Else
            Entidad.Entregas.motivoDetalle = String.Empty
        End If
        Entidad.Entregas.TipoOperacion = 1
        Entidad.Entregas.idComp = 0
        Ls_MovilidadAsociada.Add(Entidad.Entregas)
        Call CargarUltraGrid(gridDetalle, Ls_MovilidadAsociada)
    End Sub

    Function ValidarCamposDetalle()
        Me.gridDetalle.PerformAction(ExitEditMode)
        Me.gridDetalle.PerformAction(EnterEditMode)
        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            If gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString > 30 Then
                If gridDetalle.Rows(i).Cells("Motivo").Value.ToString.Trim = "" Then
                    MsgBox("El monto supero el monto de S/30 diarios, indicar el motivo", MsgBoxStyle.Exclamation, msgComacsa)
                    Return False
                End If
            End If

            If gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString > 0 Then
                'VALIDAR QUE NO EXISTA UNA PLANILLA DE MOVILIDAD EN LA MISMA FECHA
                Dim dtMovilidad As New DataTable
                Entidad.Entregas = New ETEntregas
                Negocio.NEntregas = New NGEntregas
                Entidad.Entregas.CodTrabajador = codtrabajador
                Entidad.Entregas.NumSolicitud = NumSolicitud
                Entidad.Entregas.Fecha = gridDetalle.Rows(i).Cells("Fecha").Value
                dtMovilidad = Negocio.NEntregas.Movilidad_Fecha(Entidad.Entregas)
                If dtMovilidad.Rows.Count > 0 Then
                    MsgBox("Ya existe un vale de movilidad para la fecha seleccionada", MsgBoxStyle.Exclamation, msgComacsa)
                    Return False
                End If
                'If gridDetalle.Rows(i).Cells("Motivo").Value.ToString = "" Then MsgBox("Ingrese Motivo", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                'If gridDetalle.Rows(i).Cells("Destino").Value.ToString = "" Then MsgBox("Ingrese Destino", MsgBoxStyle.Exclamation, msgComacsa) : Return False
                'If gridDetalle.Rows(i).Cells("Direccion").Value.ToString = "" Then MsgBox("Ingrese Dirección", MsgBoxStyle.Exclamation, msgComacsa) : Return False
            End If
        Next
        Return True
    End Function
    Sub CalcularTotalComprobantes()
        txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
        Dim tcambio As Double = 0
        Dim importe As Double = 0
        Dim total As Double = 0

        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            tcambio = gridDetalle.Rows(i).Cells("tipocambio").Value
            importe = gridDetalle.Rows(i).Cells("montoTotalParcial").Value
            'mon = gridDetalle.Rows(i).Cells("moneda").Value.ToString.Trim
            If moneda = "NUEVOS SOLES" Then
                If mon = "S" Or mon = "S/." Then
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe
                Else
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe * CDbl(txtcambio.Text.Trim)
                End If
            Else
                If mon = "S" Or mon = "S/." Then
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe / CDbl(txtcambio.Text.Trim)
                Else
                    gridDetalle.Rows(i).Cells("montoTotal").Value = importe
                End If
            End If
            txttotalliquidacion.Text = CDbl(CDbl(txttotalliquidacion.Text) + CDbl(gridDetalle.Rows(i).Cells("montoTotal").Value.ToString)).ToString("#####0.00")
        Next

        'ImporteDocumento()
    End Sub

    Private Sub gridDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDetalle.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "montoTotal" OrElse _
                    uColumn.Key = "Fecha" OrElse uColumn.Key = "Motivo") Then
                'OrElse uColumn.Key = "Motivo" OrElse uColumn.Key = "Destino" OrElse uColumn.Key = "Direccion"
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not ValidarCamposDetalle() Then Return
        CalcularTotalComprobantes()
        Dim importedoc As Double = CDbl(txtimporte.Text)
        Dim importeingresado As Double = CDbl(txttotalliquidacion.Text)
        If Not importedoc = importeingresado Then
            MsgBox("El importe total debe ser igual al importe del documento original", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        Else
            SeteoEntidad()
            'seteoAuxiliar()
            Me.Close()
        End If
    End Sub

    Sub seteoAuxiliar()
        Me.gridDetalle.PerformAction(ExitEditMode)
        Me.gridDetalle.PerformAction(EnterEditMode)
        Dim cont As Int32 = 0
        Dim cadAuxi As String = String.Empty
        Dim cadcodAuxi As String = String.Empty
        For i As Integer = 0 To Me.gridDetalle.Rows.Count - 1
            If Not Me.gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString.Trim = "" Then
                cont += 1
                cadAuxi = cadAuxi + Me.gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString.Trim
                cadcodAuxi = cadcodAuxi + Me.gridDetalle.Rows(i).Cells("codAuxiliar").Value.ToString.Trim
                cadAuxi = cadAuxi + ","
                cadcodAuxi = cadcodAuxi + ","
            End If
        Next
        If cadcodAuxi.Length > 0 Then
            Auxiliar = cadcodAuxi.Substring(0, cadcodAuxi.Length - 1)
            codAuxiliar = cadcodAuxi.Substring(0, cadcodAuxi.Length - 1)
        Else
            Auxiliar = String.Empty
            codAuxiliar = String.Empty
        End If
        Me.Close()
    End Sub

    Sub SeteoEntidad()
        Dim tipomoneda As String = String.Empty
        numDoc = Me.txtserie.Text.ToString.Trim.PadLeft(4, "0") & Me.txtnumero.Text.ToString.Trim.PadLeft(16, "0") '("0000000000000000")

        For x As Int32 = 0 To Ls_DocMovilidad.Count - 1
            Dim Lista = Ls_DocMovilidad.Where(Function(m) m.nroruc = Me.txtruc.Text.ToString.Trim And _
                                          m.TipoDoc = Me.txttd.Text.ToString.Trim And _
                                          m.NumDoc = numDoc).FirstOrDefault

            If Not Lista Is Nothing Then Ls_DocMovilidad.Remove(Ls_DocMovilidad.Where(Function(m) m.nroruc = Me.txtruc.Text.ToString.Trim And _
                                                 m.TipoDoc = Me.txttd.Text.ToString.Trim And _
                                                 m.NumDoc = numDoc).FirstOrDefault)
        Next

        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            item = i
            tipomoneda = mon
            If tipomoneda = "S/." Then tipomoneda = "S"
            If tipomoneda = "US$" Then tipomoneda = "D"
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.TipoOperacion = 1
            Entidad.Entregas.NumSolicitud = nroSolicitud
            Entidad.Entregas.fechaComp = Now.Date
            Entidad.Entregas.TipoDoc = Me.txttd.Text.ToString.Trim
            Entidad.Entregas.NumDoc = numDoc
            Entidad.Entregas.nroruc = Me.txtruc.Text.ToString.Trim
            Entidad.Entregas.Razon = Me.txtrazon.Text.ToString.Trim
            Entidad.Entregas.codmotivoDetalle = ""
            Entidad.Entregas.motivoDetalle = ""
            Entidad.Entregas.Fecha = gridDetalle.Rows(i).Cells("Fecha").Value.ToString
            Entidad.Entregas.Motivo = gridDetalle.Rows(i).Cells("Motivo").Value.ToString
            Entidad.Entregas.Destino = gridDetalle.Rows(i).Cells("Destino").Value.ToString
            Entidad.Entregas.Direccion = gridDetalle.Rows(i).Cells("Direccion").Value.ToString
            Entidad.Entregas.montoTotalParcial = gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString
            Entidad.Entregas.idComp = gridDetalle.Rows(i).Cells("idComp").Value.ToString
            Entidad.Entregas.TipoOperacion = gridDetalle.Rows(i).Cells("TipoOperacion").Value.ToString
            Entidad.Entregas.codAuxiliar = gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString
            Entidad.Entregas.Auxiliar = gridDetalle.Rows(i).Cells("Auxiliar").Value.ToString
            Entidad.Entregas.moneda = tipomoneda
            Entidad.Entregas.tipocambio = gridDetalle.Rows(i).Cells("tipocambio").Value.ToString
            Entidad.Entregas.montoTotal = gridDetalle.Rows(i).Cells("montoTotal").Value.ToString
            Entidad.Entregas.item = item
            Ls_DocMovilidad.Add(Entidad.Entregas)
        Next
    End Sub

    Private Sub gridDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDetalle.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridDetalle) Then Return
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
                        If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "montoTotalParcial" Then
                            If gridDetalle.ActiveRow.Cells("montoTotalParcial").Value < 0 Then
                                MsgBox("Ingrese importe válido")
                                .PerformAction(PrevCellByTab)
                            Else
                                .PerformAction(NextCellByTab)
                            End If
                        End If
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        CalcularTotalComprobantes()
                        'btnAgregar.Enabled = True
                End Select
            End With

        Catch ex As Exception

        End Try
    End Sub
End Class