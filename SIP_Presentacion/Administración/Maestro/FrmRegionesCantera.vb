Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmRegionesCantera
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
#End Region

    Private Sub FrmRegionesCantera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarDatos()
        Dim fila As Int32 = 0
        If gridConceptos.Rows.Count > 0 Then
            For i As Int32 = 0 To gridConceptos.Rows.Count - 1
                Dim inicioDescripcion As String = String.Empty
                inicioDescripcion = Me.gridConceptos.Rows(i).Cells("Cantera").Value.ToString.Substring(0, 1)
            Next
            Me.gridConceptos.ActiveRow = Me.gridConceptos.Rows(fila)
        End If
    End Sub

    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarCanteras()
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridConceptos, Source1, Ls_Entrega)
    End Sub

    Private Sub gridConceptos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConceptos.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridConceptos Then Return
        If e.Row.IsFilterRow Then Return
        SubProceso_RegionCantera(e.Row)
    End Sub
    Sub SubProceso_RegionCantera(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If
        txtCodigo.Clear()
        txtCantera.Clear()
        txtRegion.Clear()
        Ope = 2
        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.MyLista = New ETMyLista

        txtCodigo.Text = uRow.Cells("codCantera").Value.ToString.Trim
        txtCantera.Text = uRow.Cells("Cantera").Value.ToString.Trim
        txtRegion.Text = uRow.Cells("Region").Value.ToString.Trim
        txtRegion.Focus()

        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Private Sub gridConceptos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "codCantera" OrElse uColumn.Key = "Cantera" OrElse uColumn.Key = "Region") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
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
        Entidad.Entregas.codCantera = IIf(txtCodigo.Value Is Nothing, String.Empty, txtCodigo.Value)
        Entidad.Entregas.Region = IIf(txtRegion.Value Is Nothing, String.Empty, txtRegion.Value)
        Entidad.Entregas = Negocio.NEntregas.ActualizaRegion(Entidad.Entregas)
        If Entidad.Entregas.Validacion Then
            Call actualizar()
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Sub actualizar()
        txtCodigo.Clear()
        txtCantera.Clear()
        txtRegion.Clear()
        Call CargarDatos()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
    End Sub
End Class