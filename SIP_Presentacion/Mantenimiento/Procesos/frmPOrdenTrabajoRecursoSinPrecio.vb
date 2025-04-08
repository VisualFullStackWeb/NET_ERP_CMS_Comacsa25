Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmPOrdenTrabajoRecursoSinPrecio
#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private _OrdenTrabajo As Long = 0
    Private _Moneda As String = String.Empty
    Private Ls_NuevosPrecios As List(Of ETOrdenTrabajo_Recursos) = Nothing
    Private Ls_PreciosHistoricos As List(Of ETOrdenTrabajo_Recursos) = Nothing
    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eSelect = 4
    End Enum
    Private TipoG As State
#End Region

#Region "Propiedades"
    Private Property OrdenTrabajo() As Long
        Get
            Return _OrdenTrabajo
        End Get
        Set(ByVal value As Long)
            _OrdenTrabajo = value
        End Set
    End Property
    Private Property Moneda() As String
        Get
            Return _Moneda
        End Get
        Set(ByVal value As String)
            _Moneda = value
        End Set
    End Property
    
#End Region

#Region "Formulario"
    Private Sub frmPOrdenTrabajoRecursoSinPrecio_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub
    Private Sub frmPOrdenTrabajoRecursoSinPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
#End Region

#Region "Procedimientos Privados"
    Private Sub Inicio()
        Tab1.Tabs("T01").Selected = True
        Call Cargar_Grilla()
        Call Limpiar()
        TipoG = State.eSelect
    End Sub
    Private Sub Limpiar()

        Ls_PreciosHistoricos = Nothing
        Ls_NuevosPrecios = Nothing

        Ls_PreciosHistoricos = New List(Of ETOrdenTrabajo_Recursos)
        Ls_NuevosPrecios = New List(Of ETOrdenTrabajo_Recursos)

        _OrdenTrabajo = 0

        Call CargarUltraGrid(Grid2, Ls_NuevosPrecios)
        Call CargarUltraGrid(Grid3, Ls_PreciosHistoricos)

    End Sub
    Private Sub Cargar_Grilla()
        Dim Ls_OrdenTrabajo As New List(Of ETOrdenTrabajo_Mantto)
        Entidad.MyLista = New ETMyLista
        Negocio.Orden_Trabajo = New NGOrdenTrabajo_Mantto

        Entidad.MyLista = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_Recurso_Sin_Precio
        If Entidad.MyLista.Validacion Then
            Ls_OrdenTrabajo = Entidad.MyLista.Ls_Orden_Trabajo_Mantto
        End If
        Call CargarUltraGridxBinding(Grid1, Source1, Ls_OrdenTrabajo)

    End Sub
    Private Sub Cargar_Detalle()

        Ls_PreciosHistoricos = New List(Of ETOrdenTrabajo_Recursos)
        Ls_NuevosPrecios = New List(Of ETOrdenTrabajo_Recursos)
        Entidad.OrdenTrabajo.OrdenTrabajo = Me.OrdenTrabajo
        Entidad.OrdenTrabajo.Moneda = Moneda

        Entidad.OrdenTrabajo.Tipo = 4
        Entidad.MyLista = Negocio.Orden_Trabajo_Recurso_Sin_Precio.Consultar_OrdenTrabajo(Entidad.OrdenTrabajo)
        If Entidad.MyLista.Validacion Then
            Ls_PreciosHistoricos = Entidad.MyLista.Ls_OrdenTrabajo_Recursos
        End If

        Entidad.OrdenTrabajo.Tipo = 5
        Entidad.MyLista = Negocio.Orden_Trabajo_Recurso_Sin_Precio.Consultar_OrdenTrabajo(Entidad.OrdenTrabajo)
        If Entidad.MyLista.Validacion Then
            Ls_NuevosPrecios = Entidad.MyLista.Ls_OrdenTrabajo_Recursos
        End If

        For Each xRow As ETOrdenTrabajo_Recursos In Ls_NuevosPrecios
            xRow.Usuario = User_Sistema
        Next

        For Each xRow As ETOrdenTrabajo_Recursos In Ls_PreciosHistoricos
            xRow.Usuario = User_Sistema
        Next

        Call CargarUltraGrid(Grid2, Ls_NuevosPrecios)
        Call CargarUltraGrid(Grid3, Ls_PreciosHistoricos)

    End Sub

    Private Function ValidarLista() As Boolean
        ValidarLista = True
        For Each xRow As ETOrdenTrabajo_Recursos In Ls_NuevosPrecios
            If Val(xRow.Precio) <= 0 Then
                ValidarLista = False
                Return ValidarLista
            End If
        Next
        Return ValidarLista
    End Function
#End Region

#Region "Procedimientos Publicos"
    Public Sub Grabar()
        If Not (TipoG = State.eEdit) Then
            Return
        End If

        If ValidarLista() = False Then
            MsgBox("El Precio Debe Ser Mayor a Cero", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        Grid2.UpdateData()
        Grid3.UpdateData()

        If Negocio.Orden_Trabajo_Recurso_Sin_Precio.Mantenedor_Orden_Trabajo_Mantto(Ls_NuevosPrecios, Ls_PreciosHistoricos) IsNot Nothing Then
            Call Inicio()
        End If
    End Sub

    Public Sub Modificar()
        If Grid1.Rows.Count <= 0 Then
            Return
        End If

        If Grid1.ActiveRow Is Nothing Then
            Return
        End If
        TipoG = State.eEdit
        Call Limpiar()
        OrdenTrabajo = Grid1.ActiveRow.Cells("OrdenTrabajo").Value
        Moneda = Grid1.ActiveRow.Cells("Moneda").Value
        Call Cargar_Detalle()

        Tab1.Tabs("T02").Selected = True
    End Sub

    Public Sub Cancelar()
        Call Inicio()
    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
#End Region
#Region "Grilla"
    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout, Grid3.InitializeLayout
        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Abrev" OrElse uColumn.Key = "Codigo" _
                   OrElse uColumn.Key = "Cod_Presp" OrElse uColumn.Key = "OTOrigen" _
                   OrElse uColumn.Key = "Cliente" OrElse uColumn.Key = "Equipo" _
                   OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Moneda" _
                   OrElse uColumn.Key = "CostoPresup" OrElse uColumn.Key = "CostoTotal" _
                   OrElse uColumn.Key = "Estado") Then
                    uColumn.Hidden = True
                Else
                    uColumn.Hidden = False
                End If
            Next
        ElseIf sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Recurso" OrElse uColumn.Key = "Codigo" _
                   OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "UniMed" _
                   OrElse uColumn.Key = "Moneda" OrElse uColumn.Key = "Precio") Then
                    uColumn.Hidden = True
                Else
                    uColumn.Hidden = False
                End If
            Next

        Else
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Recurso" OrElse uColumn.Key = "Codigo" _
                   OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "UniMed" _
                   OrElse uColumn.Key = "Moneda" OrElse uColumn.Key = "Precio" _
                   OrElse uColumn.Key = "Action") Then
                    uColumn.Hidden = True
                Else
                    uColumn.Hidden = False
                End If
            Next
        End If

    End Sub

    Private Sub Grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid2.KeyDown
        Try
            Dim f As System.EventArgs = Nothing
            With Grid2
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(AboveCell, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Down
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(BelowCell, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Right
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(NextCellByTab, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Left
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(PrevCellByTab, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Return
                        .PerformAction(ExitEditMode, False, False)
                        e.Handled = True
                        .PerformAction(NextRow, False, False)
                        .ActiveRow.Cells("Valor").Activate()
                        .PerformAction(PrevRow, False, False)
                        .ActiveRow.Cells("Valor").Activate()
                        .PerformAction(EnterEditMode, False, False)
                        '.PerformAction(ExitEditMode, False, False)
                        e.Handled = True
                        .PerformAction(NextRow, False, False)
                        .ActiveRow.Cells("Valor").Activate()
                        .PerformAction(EnterEditMode, False, False)
                End Select
            End With
        Catch
            Exit Sub
        End Try
    End Sub
#End Region

    
End Class