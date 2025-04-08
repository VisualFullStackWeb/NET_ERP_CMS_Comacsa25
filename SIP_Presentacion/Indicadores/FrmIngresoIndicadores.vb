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
Public Class FrmIngresoIndicadores
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
    Private Sub FrmIngresoIndicadores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
        CargarArea()
    End Sub
    Sub CargarArea()
        Dim dtArea As New DataTable
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Usuario = User_Sistema
        dtArea = _objNegocio.LISTAR_AREA(_objEntidad)
        Call CargarUltraCombo(cmbArea, dtArea, "IDAREA", "AREA")
    End Sub
    Sub CargarIndPrincipal()
        Dim dtIndicador As New DataTable
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.ID = cmbArea.Value
        _objEntidad.Usuario = User_Sistema
        dtIndicador = _objNegocio.LISTAR_INDPRINCIPAL(_objEntidad)
        Call CargarUltraCombo(cmbindicador, dtIndicador, "INDICADOR_PRINCIPAL", "INDICADOR_PRINCIPAL")
    End Sub

    Private Sub gridIndicadores_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridIndicadores.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridIndicadores Then Return
        e.DisplayPromptMsg = Boolean.FalseString
    End Sub
    Private Sub gridProduccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridIndicadores.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridIndicadores) Then Return
            With sender
                Select Case e.KeyValue
                    Case 45
                        e.Handled = True
                        Return
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
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbArea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbArea.InitializeLayout
        With cmbArea.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("AREA").Width = 300 ' sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "AREA") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub


    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try
            For I As Int32 = gridIndicadores.Rows.Count - 1 To 0 Step -1
                gridIndicadores.Rows(I).Delete()
            Next
            CargarIndPrincipal()
            'Procesar()
        Catch ex As Exception

        End Try
    End Sub
    Sub Procesar()
        If cmbArea.Text = "" Or cmbindicador.Text = "" Then Exit Sub
        If chkfinal.Checked = True Then
            ListaIndicadores_finales()
        Else
            ListaIndicadores()
        End If
    End Sub

    Sub Nuevo()
        ListaIndicadores()
    End Sub

    Sub ListaIndicadores()
        Dim dtValores As New DataTable
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.ID = cmbArea.Value
        _objEntidad.Descripcion = cmbindicador.Text.Trim
        dtValores = _objNegocio.LISTAR_INDICADORES(_objEntidad)
        Call CargarUltraGridxBinding(gridIndicadores, Source1, dtValores)
    End Sub

    Sub ListaIndicadores_finales()
        Dim dtValores As New DataTable
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.ID = cmbArea.Value
        dtValores = _objNegocio.LISTAR_INDICADORES_FINAL(_objEntidad)
        Call CargarUltraGridxBinding(gridIndicadores, Source1, dtValores)
    End Sub

    Sub grabar()
        Try
            gridIndicadores.PerformAction(ExitEditMode)
            For fila As Int32 = 0 To gridIndicadores.Rows.Count - 1

                For col As Int32 = 2 To 13
                    Dim dtValores As New DataTable
                    _objNegocio = New NGProducto
                    _objEntidad = New ETProducto
                    _objEntidad.Anho = txtayo.Value
                    _objEntidad.Mes = (col - 1)
                    _objEntidad.ID = gridIndicadores.Rows(fila).Cells("IDINDICADOR").Value
                    _objEntidad.ValorxDecimal = gridIndicadores.Rows(fila).Cells(col).Value
                    _objEntidad.Usuario = User_Sistema
                    dtValores = _objNegocio.INSERTA_INDICADORES(_objEntidad)
                Next

            Next
            Procesar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkfinal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkfinal.CheckedChanged
        Procesar()
    End Sub

    Private Sub txtayo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtayo.ValueChanged
        Try
            Procesar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbindicador_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbindicador.InitializeLayout
        With cmbindicador.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("INDICADOR_PRINCIPAL").Width = sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "INDICADOR_PRINCIPAL") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbindicador_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbindicador.ValueChanged
        Try
            Procesar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtValores As New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Descripcion = cmbindicador.Text.Trim
            dtValores = _objNegocio.CARGA_INDICADORES(_objEntidad)
            Procesar()
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridIndicadores_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridIndicadores.InitializeLayout

    End Sub
End Class