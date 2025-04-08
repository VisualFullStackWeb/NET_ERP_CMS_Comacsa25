Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmSeteoContable
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
    Private Sub FrmDescripciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarDatos()
        Call LlenarTipo()
    End Sub
    Private Sub CargarDatos()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarConceptos()
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridConceptos, Source1, Ls_Entrega)
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Private Sub CargarAreas()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.codConcepto = TxtCodigo.Text.ToString.Trim
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarAreasCuenta(Entidad.Entregas)
        Call CargarUltraGridxBinding(Me.gridAreaCuenta, Source2, Entidad.MyLista.Ls_Entrega)
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Sub SubProceso_Descripciones(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If
        Ope = 2
        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista

        Call HabilitarControles(True)

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.MyLista = New ETMyLista
        TxtCodigo.Text = uRow.Cells("codConcepto").Value.ToString.Trim
        TxtDescripcion.Text = uRow.Cells("Descripcion").Value.ToString.Trim
        cmbTipo.Value = uRow.Cells("tipoconcepto").Value.ToString.Trim
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        Call CargarAreas()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Sub LlenarTipo()
        Dim dtTipo As New DataTable
        dtTipo.Columns.Add("DESCRIPCION")
        Dim dr As DataRow
        dr = dtTipo.NewRow
        dr(0) = "VIÁTICOS"
        dtTipo.Rows.Add(dr)
        dr = dtTipo.NewRow
        dr(0) = "TRÁMITES VARIOS"
        dtTipo.Rows.Add(dr)
        cmbTipo.DataSource = dtTipo
    End Sub

    Public Sub Nuevo()
    End Sub

    Sub CodigoDescripcion()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Entidad.MyLista = Negocio.NEntregas.CodigoDescripcion()
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Validacion Then
            If Not Entidad.MyLista.Ls_Entrega.Count > 0 Then Return
            TxtCodigo.Text = Entidad.MyLista.Ls_Entrega.Item(0).codConcepto
        End If
    End Sub

    Private Sub LimpiarDatos()
        Me.TxtCodigo.Clear()
        Me.TxtDescripcion.Clear()
        cmbTipo.Value = 0
        Ep1.Clear()
        Ope = 0
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Call CargarUltraGridxBinding(Me.gridAreaCuenta, Source2, Ls_Entrega)
    End Sub
    Private Sub HabilitarControles(ByVal D As Boolean)
        Me.TxtDescripcion.ReadOnly = D
        Me.cmbTipo.ReadOnly = D
    End Sub

    Private Sub cmbTipo_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbTipo.InitializeLayout
        With cmbTipo.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("DESCRIPCION").Width = 220 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "DESCRIPCION") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(TxtCodigo.Value) Then
            Ep1.SetError(TxtCodigo, "Ingrese código")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(TxtDescripcion.Value) Then
            Ep1.SetError(TxtDescripcion, "Ingrese descripción")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(cmbTipo.Value) Then
            Ep1.SetError(cmbTipo, "Seleccione tipo")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function

    Private Sub gridConceptos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConceptos.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot gridConceptos Then Return

        If e.Row.IsFilterRow Then Return

        SubProceso_Descripciones(e.Row)
    End Sub

    Private Sub gridConceptos_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "codConcepto" OrElse uColumn.Key = "Descripcion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Sub modificar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        Ope = 2
    End Sub
    Sub cancelar()
        LimpiarDatos()
        HabilitarControles(True)
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
    End Sub
    Sub actualizar()
        LimpiarDatos()
        HabilitarControles(True)
        CargarDatos()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
    End Sub

    Private Sub gridAreaCuenta_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridAreaCuenta.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Area" OrElse uColumn.Key = "codCuenta" OrElse uColumn.Key = "Cuenta" OrElse uColumn.Key = "codCuentaBoleta" OrElse uColumn.Key = "CuentaBoleta") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub gridAreaCuenta_DoubleClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles gridAreaCuenta.DoubleClickCell
        If e.Cell.Column.Key = "codCuenta" Then
            Dim frm As New FrmCuentaContable
            frm.ShowDialog()
            gridAreaCuenta.Rows(e.Cell.Row.Index).Cells("codCuenta").Value = codCuenta
            gridAreaCuenta.Rows(e.Cell.Row.Index).Cells("Cuenta").Value = Cuenta

            gridAreaCuenta.PerformAction(NextCellByTab)
        End If
    End Sub

    Sub grabar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas

        Ls_Entrega = New List(Of ETEntregas)
        gridAreaCuenta.PerformAction(EnterEditMode)
        gridAreaCuenta.PerformAction(ExitEditMode)
        For i As Int32 = 0 To gridAreaCuenta.Rows.Count - 1
            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.codArea = gridAreaCuenta.Rows(i).Cells("codArea").Value.ToString
            Entidad.Entregas.codConcepto = TxtCodigo.Text.ToString.Trim
            Entidad.Entregas.codCuenta = gridAreaCuenta.Rows(i).Cells("codCuenta").Value.ToString
            Entidad.Entregas.codCuentaBoleta = gridAreaCuenta.Rows(i).Cells("codCuentaBoleta").Value.ToString
            Ls_Entrega.Add(Entidad.Entregas)
        Next

        Entidad.Entregas = Negocio.NEntregas.MantenimientoSeteContable(Entidad.Entregas, Ls_Entrega)

        If Entidad.Entregas.Validacion Then
            Call actualizar()
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Sub eliminar()
    End Sub
    Sub reporte()
    End Sub

    Private Sub gridAreaCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridAreaCuenta.KeyPress
        Try
            If Me.gridAreaCuenta.ActiveRow.Cells(gridAreaCuenta.ActiveCell.Column.Index).Column.Key = "codCuenta" Then                
                If e.KeyChar.ToString.Trim = "" Then Return
                If e.KeyChar = ChrW(Keys.Escape) Then Return
                If e.KeyChar = ChrW(Keys.Delete) Then Return
                If e.KeyChar = ChrW(Keys.Return) Then Return
                If e.KeyChar = ChrW(Keys.Back) Then Return
                If e.KeyChar.ToString.Trim = "" Then Return
                Dim frm As New FrmCuentaContable
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.ShowDialog()
                gridAreaCuenta.Rows(gridAreaCuenta.ActiveRow.Index).Cells("codCuenta").Value = codCuenta
                gridAreaCuenta.Rows(gridAreaCuenta.ActiveRow.Index).Cells("Cuenta").Value = Cuenta
                gridAreaCuenta.PerformAction(NextCellByTab)
                gridAreaCuenta.PerformAction(EnterEditMode)
                e.Handled = True
                Exit Sub
            End If

            If Me.gridAreaCuenta.ActiveRow.Cells(gridAreaCuenta.ActiveCell.Column.Index).Column.Key = "codCuentaBoleta" Then
                If e.KeyChar.ToString.Trim = "" Then Return
                If e.KeyChar = ChrW(Keys.Escape) Then Return
                If e.KeyChar = ChrW(Keys.Delete) Then Return
                If e.KeyChar = ChrW(Keys.Return) Then Return
                If e.KeyChar = ChrW(Keys.Back) Then Return
                If e.KeyChar.ToString.Trim = "" Then Return
                Dim frm As New FrmCuentaContable
                frm.filtroDescripcion = e.KeyChar.ToString.ToUpper.Trim
                frm.ShowDialog()
                gridAreaCuenta.Rows(gridAreaCuenta.ActiveRow.Index).Cells("codCuentaBoleta").Value = codCuenta
                gridAreaCuenta.Rows(gridAreaCuenta.ActiveRow.Index).Cells("CuentaBoleta").Value = Cuenta
                gridAreaCuenta.PerformAction(NextCellByTab)
                gridAreaCuenta.PerformAction(EnterEditMode)
                e.Handled = True
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridAreaCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridAreaCuenta.KeyDown
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If Not (sender Is gridAreaCuenta) Then Return
        With sender
                Select e.KeyValue
                Case 46
                    e.Handled = True
                    Return
                Case 8
                    If gridAreaCuenta.ActiveRow.Cells(gridAreaCuenta.ActiveCell.Column.Index).Column.Key = "codCuenta" Then
                        gridAreaCuenta.ActiveRow.Cells("codCuenta").Value = ""
                        gridAreaCuenta.ActiveRow.Cells("Cuenta").Value = ""
                    End If
                    If gridAreaCuenta.ActiveRow.Cells(gridAreaCuenta.ActiveCell.Column.Index).Column.Key = "codCuentaBoleta" Then
                        gridAreaCuenta.ActiveRow.Cells("codCuentaBoleta").Value = ""
                        gridAreaCuenta.ActiveRow.Cells("CuentaBoleta").Value = ""
                    End If
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
            End Select
        End With
    End Sub
End Class