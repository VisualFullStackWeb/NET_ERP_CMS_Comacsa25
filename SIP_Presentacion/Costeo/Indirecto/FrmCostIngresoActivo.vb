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
Public Class FrmCostIngresoActivo
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
#End Region
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Public _idtipo As Int32
    Dim dtDetalle As New DataTable
    Private Sub FrmCostIngresoActivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargaCombo()
        Procesar()
        cmbtipo.Value = _idtipo
    End Sub
    Sub cargaCombo()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            Dim dtDatos As New DataTable
            _objEntidad.Placa = txtplaca.Text
            dtDatos = _objNegocio.Costo_ListaTipoComb(_objEntidad)
            Call CargarUltraCombo(cmbtipo, dtDatos, "idtipo", "descripcion")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Procesar()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Placa = txtplaca.Text
            dtDetalle = _objNegocio.Costo_ListaActivoClase(_objEntidad)
            Call CargarUltraGridxBinding(Me.gridporcentaje, Source1, dtDetalle)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbtipo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbtipo.InitializeLayout
        With cmbtipo.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descripcion").Width = sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descripcion") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub gridporcentaje_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridporcentaje.InitializeLayout

    End Sub

    Private Sub gridporcentaje_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridporcentaje.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridporcentaje) Then Return
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
                        If Not validaProcentaje() Then
                            e.Handled = True
                            Exit Sub
                        End If
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            If cmbtipo.Value Is Nothing Then
                MsgBox("Seleccione tipo de combustible", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If Not validaProcentaje() Then
                Exit Sub
            End If
            'MsgBox(dtDetalle.Rows.Count)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Placa = txtplaca.Text
            _objEntidad.ID = cmbtipo.Value
            _objEntidad.Usuario = User_Sistema
            Dim dtResultado As New DataTable
            dtResultado = _objNegocio.Costo_MantActivos(_objEntidad, dtDetalle)
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Function validaProcentaje() As Boolean
        gridporcentaje.PerformAction(ExitEditMode)
        Dim porc As Double
        For i As Int32 = 0 To gridporcentaje.Rows.Count - 1
            porc = porc + gridporcentaje.Rows(i).Cells("porcentaje").Value
        Next
        If porc <> 100 Then
            MsgBox("Porcentaje a ingresar es 100%", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
            'ElseIf porc <= 0 Then
            '    MsgBox("Ingrese porcentaje correcto", MsgBoxStyle.Exclamation, msgComacsa)
            '    Return False
        Else
            Return True
        End If
    End Function
End Class