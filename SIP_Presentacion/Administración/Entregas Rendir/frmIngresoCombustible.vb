Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmIngresoCombustible
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
    Private Ls_CombustibleAsociado As List(Of ETEntregas) = Nothing
    Dim numDoc As String = String.Empty
    Dim item As Int32 = 0

#End Region
    Private Sub frmIngresoCombustible_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Entidad.MyLista = Negocio.NEntregas.ListarCombustible()

        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        'Call CargarUltraGridxBinding(Me.gridDetalle, Source1, Ls_Entrega)

        If Ls_CombustibleAsociado Is Nothing Then
            Ls_CombustibleAsociado = New List(Of ETEntregas)
        End If
      
        If Ls_DocCombustible.Count > 0 Then
            numDoc = Me.txtserie.Text.ToString.Trim.PadLeft(4, "0") & Me.txtnumero.Text.ToString.Trim.PadLeft(16, "0") '("0000000000000000")
            For i As Int32 = 0 To Ls_DocCombustible.Count - 1
                item = i
                Dim Lista = Ls_DocCombustible.Where(Function(m) m.nroruc = Me.txtruc.Text.ToString.Trim And _
                  m.TipoDoc = Me.txttd.Text.ToString.Trim And _
                  m.NumDoc = numDoc And m.item = item).FirstOrDefault
                If Not Lista Is Nothing Then
                    Ls_CombustibleAsociado.Add(Lista)
                End If

            Next
            Call CargarUltraGrid(gridDetalle, Ls_CombustibleAsociado)
            'gridDetalle.PerformAction(FirstCellInRow)
        End If
        If Ls_CombustibleAsociado.Count = 0 Then
            For i As Int32 = 0 To Ls_Entrega.Count - 1
                Entidad.Entregas = New ETEntregas
                Entidad.Entregas.TipoOperacion = 1
                Entidad.Entregas.idComp = 0
                Entidad.Entregas.Descripcion = Ls_Entrega.Item(i).Descripcion
                Ls_CombustibleAsociado.Add(Entidad.Entregas)
            Next

            Call CargarUltraGrid(gridDetalle, Ls_CombustibleAsociado)
        End If
        CalcularTotalComprobantes()
        gridDetalle.Focus()
        gridDetalle.Rows(0).Cells(0).Activate()
        gridDetalle.PerformAction(EnterEditMode)
        gridDetalle.PerformAction(FirstCellInRow)
    End Sub

    Sub CalcularTotalComprobantes()
        txttotalliquidacion.Text = CDbl("0.00").ToString("#####0.00")
        Dim tcambio As Double = 0
        Dim importe As Double = 0
        Dim total As Double = 0
        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            tcambio = gridDetalle.Rows(i).Cells("tipocambio").Value
            importe = gridDetalle.Rows(i).Cells("montoTotalParcial").Value

            gridDetalle.Rows(i).Cells("montoTotal").Value = importe

            txttotalliquidacion.Text = CDbl(CDbl(txttotalliquidacion.Text) + CDbl(gridDetalle.Rows(i).Cells("montoTotal").Value.ToString)).ToString("#####0.00")
        Next
        'ImporteDocumento()
    End Sub

    Private Sub gridDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDetalle.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "montoTotalParcial" OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Galones" OrElse uColumn.Key = "Kilometraje") Then
                'OrElse uColumn.Key = "Motivo" OrElse uColumn.Key = "Destino" OrElse uColumn.Key = "Direccion"
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub gridDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDetalle.KeyDown
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
                            If gridDetalle.ActiveRow.Cells("montoTotalParcial").Value <= 0 Then
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
                End Select
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Not ValidarCamposDetalle() Then Return
            CalcularTotalComprobantes()
            Dim importedoc As Double = CDbl(txtimporte.Text)
            Dim importeingresado As Double = CDbl(txttotalliquidacion.Text)
            '<JOSF 26/12/2022>
            Entidad.Entregas = Negocio.NEntregas.FechaKilometraje()
            '</JOSF 26/12/2022>
            If Not importedoc = importeingresado Then
                MsgBox("El importe total debe ser igual al importe del documento original", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            Else
                For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                    item = i
                    If gridDetalle.Rows(i).Cells("montoTotal").Value.ToString > 0 Then
                        If gridDetalle.Rows(i).Cells("Galones").Value.ToString <= 0 Then
                            MsgBox("Debe ingresar cantidad de galones", MsgBoxStyle.Exclamation, msgComacsa)
                            Exit Sub
                        End If
                        '<JOSF 26/12/2022>
                        If Entidad.Entregas.ValorxEntero <= 0 Then
                            If gridDetalle.Rows(i).Cells("Kilometraje").Value.ToString <= 0 Then
                                MsgBox("Debe ingresar cantidad de Kilometraje", MsgBoxStyle.Exclamation, msgComacsa)
                                Exit Sub
                            End If
                        End If
                        '</JOSF 26/12/2022>
                    End If
                Next
                SeteoEntidad()
                'seteoAuxiliar()
                Me.Close()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Function ValidarCamposDetalle()
        Me.gridDetalle.PerformAction(ExitEditMode)
        Me.gridDetalle.PerformAction(EnterEditMode)
        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            If gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString > 0 Then
            End If
        Next
        Return True
    End Function

    Sub SeteoEntidad()
        Dim tipomoneda As String = String.Empty
        numDoc = Me.txtserie.Text.ToString.Trim.PadLeft(4, "0") & Me.txtnumero.Text.ToString.Trim.PadLeft(16, "0") '("0000000000000000")
        For x As Int32 = 0 To Ls_DocCombustible.Count - 1
            Dim Lista = Ls_DocCombustible.Where(Function(m) m.nroruc = Me.txtruc.Text.ToString.Trim And _
                                          m.TipoDoc = Me.txttd.Text.ToString.Trim And _
                                          m.NumDoc = numDoc).FirstOrDefault

            If Not Lista Is Nothing Then Ls_DocCombustible.Remove(Ls_DocCombustible.Where(Function(m) m.nroruc = Me.txtruc.Text.ToString.Trim And _
                                                 m.TipoDoc = Me.txttd.Text.ToString.Trim And _
                                                 m.NumDoc = numDoc).FirstOrDefault)
        Next

        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            item = i
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
            Entidad.Entregas.idComp = gridDetalle.Rows(i).Cells("idComp").Value.ToString
            Entidad.Entregas.Descripcion = gridDetalle.Rows(i).Cells("Descripcion").Value.ToString
            Entidad.Entregas.montoTotalParcial = gridDetalle.Rows(i).Cells("montoTotalParcial").Value.ToString
            Entidad.Entregas.Galones = gridDetalle.Rows(i).Cells("Galones").Value.ToString
            Entidad.Entregas.moneda = tipomoneda
            Entidad.Entregas.montoTotal = gridDetalle.Rows(i).Cells("montoTotal").Value.ToString
            Entidad.Entregas.TipoOperacion = gridDetalle.Rows(i).Cells("TipoOperacion").Value.ToString
            Entidad.Entregas.item = item
            '<JOSF 23112022>
            Entidad.Entregas.Kilometraje = gridDetalle.Rows(i).Cells("Kilometraje").Value.ToString
            '</JOSF 23112022>
            Ls_DocCombustible.Add(Entidad.Entregas)
        Next
    End Sub
End Class