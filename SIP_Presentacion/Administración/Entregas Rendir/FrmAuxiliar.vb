Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmAuxiliar
    Public placa_tercero As String = ""
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
    Public auxi As String = String.Empty
    Public codconcepto As String = String.Empty
    Public cadena As String = String.Empty
#End Region

    Private Sub FrmAuxiliar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        placa_tercero = " "
        Call CargarDatos()
        Dim arrayAuxiliar As String() = cadena.Split(",")
        Dim fila As Int32 = 0
        'If gridConceptos.Rows.Count > 0 Then
        '    For i As Int32 = 0 To gridConceptos.Rows.Count - 1
        '        Dim inicioDescripcion As String = String.Empty
        '        inicioDescripcion = Me.gridConceptos.Rows(i).Cells("Auxiliar").Value.ToString.Substring(0, 1)
        '        If inicioDescripcion = filtroDescripcion Then
        '            fila = i
        '            Exit For
        '        End If
        '    Next
        '    Me.gridConceptos.ActiveRow = Me.gridConceptos.Rows(fila)
        'End If
        VerificarAuxiliar(arrayAuxiliar)
        Select Case (auxi.ToString.Trim)
            Case "AC"
                Me.Text = "SELECCIÓN DE ACTIVOS"
            Case "CA"
                Me.Text = "SELECCIÓN DE CANTERAS"
            Case "CL"
                Me.Text = "SELECCIÓN DE CLIENTES"
            Case "MP"
                Me.Text = "SELECCIÓN DE PRODUCTOS MATERIA PRIMA"
            Case "PL"
                Me.Text = "SELECCIÓN DE PLANILLAS"
            Case "PR"
                Me.Text = "SELECCIÓN DE PROVEEDORES"
            Case "AL"
                Me.Text = "SELECCIÓN DE VEHICULOS ALQUILADOS"
                'Case "PP"
                '    Me.Text = "PARTIDA PRESUPUESTAL"
            Case Else
                Me.Text = ""
        End Select
        'gridConceptos.Focus()
        'txtescripcion.Text = filtroDescripcion
        'txtescripcion.Focus()
        gridConceptos.Rows(0).Cells("codAuxiliar").Activate()
        gridConceptos.PerformAction(EnterEditMode)
        'gridConceptos.PerformAction(FirstCellInRow)
        'gridConceptos.PerformAction(PrevCellByTab)
        'gridConceptos.PerformAction(PrevCellByTab)
        gridConceptos.PerformAction(NextCellByTab)
    End Sub

    Sub VerificarAuxiliar(ByVal arrayAuxiliar As String())
        If arrayAuxiliar.Count > 0 Then
            For i As Int32 = 0 To gridConceptos.Rows.Count - 1
                For j As Int32 = 0 To arrayAuxiliar.Count - 1
                    If Me.gridConceptos.Rows(i).Cells("codAuxiliar").Value.ToString.Trim = arrayAuxiliar(j).ToString.Trim Then
                        Me.gridConceptos.Rows(i).Cells("Action").Value = True
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.auxi = auxi
        Entidad.Entregas.codConcepto = codconcepto
        Entidad.Entregas.tipprod = "03"
        Entidad.MyLista = Negocio.NEntregas.ListarAuxiliar(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridConceptos, Source1, Ls_Entrega)
    End Sub

    Private Sub gridConceptos_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Action" OrElse uColumn.Key = "codAuxiliar" OrElse uColumn.Key = "Auxiliar") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        gridConceptos.PerformAction(ExitEditMode)
        gridConceptos.PerformAction(EnterEditMode)
        SeleccionarAuxiliares()
    End Sub

    Private Sub gridConceptos_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConceptos.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridConceptos Then Return
        If e.Row.IsFilterRow Then Return
        SeleccionarConcepto(e.Row)
    End Sub
    Sub SeleccionarConcepto(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If
        Auxiliar = uRow.Cells("codAuxiliar").Value
        codAuxiliar = uRow.Cells("codAuxiliar").Value
        Me.Close()
    End Sub

    Private Sub gridConceptos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridConceptos.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            With sender
                Select Case e.KeyValue
                    Case Nothing
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case 32
                        If Me.gridConceptos.ActiveRow.Cells("Action").Value = True Then
                            Me.gridConceptos.ActiveRow.Cells("Action").Value = False
                        Else
                            Me.gridConceptos.ActiveRow.Cells("Action").Value = True
                        End If
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
                        'Case Keys.Up
                        'Case Keys.Down
                        '    If Me.gridConceptos.ActiveRow.Index < 0 Then
                        '        Me.gridConceptos.ActiveRow = Me.gridConceptos.Rows(0)
                        '        e.Handled = Boolean.TrueString
                        '    End If
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
                        If gridConceptos.ActiveRow.Index < 0 Then MsgBox("Seleccione una cantera", MsgBoxStyle.Exclamation, msgComacsa) : Return
                        gridConceptos.PerformAction(ExitEditMode)
                        gridConceptos.PerformAction(EnterEditMode)
                        SeleccionarAuxiliares()
                End Select
            End With


        Catch ex As Exception

        End Try
    End Sub
    Sub SeleccionarAuxiliares()
        Try
            Dim cont As Int32 = 0
            Dim cadAuxi As String = String.Empty
            Dim cadcodAuxi As String = String.Empty
            Dim cont_varios As Int32 = 0
            For i As Integer = 0 To gridConceptos.Rows.Count - 1
                If gridConceptos.Rows(i).Cells("Action").Value = True Then
                    cont += 1
                    cadAuxi = cadAuxi + gridConceptos.Rows(i).Cells("Auxiliar").Value.ToString.Trim
                    cadcodAuxi = cadcodAuxi + gridConceptos.Rows(i).Cells("codAuxiliar").Value.ToString.Trim
                    cadAuxi = cadAuxi + ", "
                    cadcodAuxi = cadcodAuxi + ", "
                    If gridConceptos.Rows(i).Cells("codAuxiliar").Value.ToString.Trim = "00000000" Then
                        cont_varios += 1
                    End If
                End If
            Next
            If cont = 0 Then
                MsgBox("Debe seleccionar un código Auxiliar", MsgBoxStyle.Exclamation, msgComacsa) : Return
            Else
                Auxiliar = cadcodAuxi.Substring(0, cadcodAuxi.Length - 2)
                codAuxiliar = cadcodAuxi.Substring(0, cadcodAuxi.Length - 2)
            End If
            If cont_varios > 0 Then
                MsgBox("Ingrese placa de vehículo", MsgBoxStyle.Information, "Sistema")
                txtplaca.Text = ""
                pnlplaca.Visible = True
                txtplaca.Focus()
            Else
                Me.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtplaca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtplaca.KeyDown
        If e.KeyData = 13 Then
            If txtplaca.Text = "" Then MsgBox("Ingrese placa válida", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
            If txtplaca.Text.Length < 6 Then MsgBox("Ingrese placa válida", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
            pnlplaca.Visible = False
            placa_tercero = txtplaca.Text
            Me.Close()
        End If
    End Sub

    Private Sub txtplaca_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtplaca.ValueChanged

    End Sub

    'Private Sub FrmAuxiliar_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    '    If Me.Text = "PARTIDA PRESUPUESTAL" And Auxiliar = "" Then
    '        Auxiliar = 0
    '        codAuxiliar = "0"
    '    End If
    'End Sub
End Class