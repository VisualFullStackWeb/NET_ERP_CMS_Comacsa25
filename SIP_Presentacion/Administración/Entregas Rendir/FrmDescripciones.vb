Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmDescripciones
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
        Call LimpiarDatos()
        Call HabilitarControles(False)
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        Ope = 1
        Me.TxtDescripcion.Focus()
        'Dim codigo As String = ""
        'codigo = Me.gridConceptos.Rows(gridConceptos.Rows.Count - 1).Cells("codConcepto").Value.ToString.Trim
        CodigoDescripcion()
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

    Public Sub Grabar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Entidad.Entregas.TipoOperacion = Ope
        Entidad.Entregas.codConcepto = IIf(TxtCodigo.Value Is Nothing, String.Empty, TxtCodigo.Value.ToString.Trim)
        Entidad.Entregas.Descripcion = IIf(TxtDescripcion.Value Is Nothing, String.Empty, TxtDescripcion.Value.ToString.Trim)

        Dim tipoDescripcion As String = String.Empty
        'If cmbTipo.Value = "VIÁTICOS" Then
        tipoDescripcion = "A"
        'Else
        'tipoDescripcion = "B"
        'End If
        Entidad.Entregas.tipoconcepto = tipoDescripcion.ToString.Trim

        Entidad.Entregas.Usuario = User_Sistema

        Entidad.Entregas = Negocio.NEntregas.MantenimientoDescripciones(Entidad.Entregas)

        If Entidad.Entregas.Validacion Then
            Call actualizar()
        End If
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

        'If String.IsNullOrEmpty(cmbTipo.Value) Then
        '    Ep1.SetError(cmbTipo, "Seleccione tipo")
        '    lResult = Boolean.FalseString
        'End If

        Return lResult

    End Function

    Private Sub gridConceptos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConceptos.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot gridConceptos Then Return

        If e.Row.IsFilterRow Then Return

        'e.Row.Fixed = Boolean.TrueString

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
        HabilitarControles(False)
        Me.TxtDescripcion.Focus()
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
End Class