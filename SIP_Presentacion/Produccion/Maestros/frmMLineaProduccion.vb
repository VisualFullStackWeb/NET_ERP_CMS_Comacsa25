Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmMLineaProduccion

#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)

    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private TipoG As sTate
    Private Ls_LineaProduccion As List(Of ETLineaNegocio) = Nothing
    Private Ls_Productos As List(Of ETLineaNegocio) = Nothing
    Private Ls_Proceso As List(Of ETLineaNegocio) = Nothing
    Private _LineaProduccion As Long = 0
    Private OrdenProceso As Integer = 0

#End Region

#Region "Propiedades"
    Public Property LineaProduccion() As Long
        Get
            Return _LineaProduccion
        End Get
        Set(ByVal value As Long)
            _LineaProduccion = value
        End Set
    End Property
#End Region

#Region "Formulario"

    Private Sub frmMLineaProduccion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmMLineaProduccion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Ls_LineaProduccion = Nothing
        Ls_Proceso = Nothing
        Ls_Productos = Nothing
    End Sub
    Private Sub frmMLineaProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
#End Region

#Region "Procedimientos Privados"
    Private Sub Inicio()
        TipoG = sTate.eView
        Call LimpiarDatos()
        Call HabilitarControles(False)

        Call CargarDatos()

        Tab1.Tabs("T01").Selected = True
    End Sub

    Private Sub CargarDatos()
        Select Case Me.Tag.ToString.Trim
            Case "87"
                Call CargarDatos_LineaProd()
            Case "116"
                Call CargarDatos_ProcesoProd()
                Tab1.Tabs("T01").Text = "PROCESO PROD."
                Tab1.Tabs("T03").Visible = False
                Tab1.Tabs("T04").Visible = False
                UltraGroupBox1.Text = "PROCESO PRODUCTIVO"
        End Select
    End Sub

    Private Sub CargarDatos_LineaProd()
        Negocio.LineaProduccion = New NGLineaProduccion
        Entidad.MyLista = New ETMyLista

        Ls_LineaProduccion = Nothing
        Ls_LineaProduccion = New List(Of ETLineaNegocio)

        Entidad.MyLista = Negocio.LineaProduccion.ConsultarLineaProduccion

        If Entidad.MyLista.Validacion Then
            Ls_LineaProduccion = Entidad.MyLista.Ls_Linea_Produccion
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_LineaProduccion)
    End Sub

    Private Sub CargarDatos_ProcesoProd()
        Negocio.LineaProduccion = New NGLineaProduccion
        Entidad.MyLista = New ETMyLista

        Ls_LineaProduccion = Nothing
        Ls_LineaProduccion = New List(Of ETLineaNegocio)

        Entidad.MyLista = Negocio.LineaProduccion.Consultar_ProcesoProductivo

        If Entidad.MyLista.Validacion Then
            Ls_LineaProduccion = Entidad.MyLista.Ls_Linea_Produccion
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_LineaProduccion)
    End Sub

    Private Sub CargarProductos()

        Ls_Productos = Nothing
        Ls_Productos = New List(Of ETLineaNegocio)

        Negocio.LineaProduccion = New NGLineaProduccion

        Entidad.LineaProduccion = New ETLineaNegocio
        Entidad.LineaProduccion.IDCatalogo = Me.LineaProduccion
        Entidad.LineaProduccion.Usuario = User_Sistema
        Entidad.LineaProduccion.Tipo = 4

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.LineaProduccion.ConsultarLineaProduccion_Productos(Entidad.LineaProduccion)

        If Entidad.MyLista.Validacion Then
            Ls_Productos = Entidad.MyLista.Ls_LineaProduccion_Productos
        End If

        Call CargarUltraGrid(Grid2, Ls_Productos)
    End Sub

    Private Sub CargarProcesos()

        Ls_Proceso = Nothing
        Ls_Proceso = New List(Of ETLineaNegocio)

        Negocio.LineaProduccion = New NGLineaProduccion

        Entidad.LineaProduccion = New ETLineaNegocio
        Entidad.LineaProduccion.IDCatalogo = Me.LineaProduccion
        Entidad.LineaProduccion.Usuario = User_Sistema
        Entidad.LineaProduccion.Tipo = 5

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.LineaProduccion.ConsultarLineaProduccion_Procesos(Entidad.LineaProduccion)

        If Entidad.MyLista.Validacion Then
            Ls_Proceso = Entidad.MyLista.Ls_LineaProduccion_Proceso
        End If

        Call CargarUltraGrid(Grid3, Ls_Proceso)
    End Sub



    Private Sub HabilitarControles(ByVal D As Boolean)
        Me.Txt1.ReadOnly = True
        Me.Txt2.ReadOnly = Not D
        Me.Cbo1.ReadOnly = True
    End Sub

    Private Sub LimpiarDatos()
        Me.Txt1.Clear()
        Me.Txt2.Clear()
        Me.Cbo1.Value = "K01"
        _LineaProduccion = 0
        OrdenProceso = 0
        Ls_Productos = Nothing
        Ls_Productos = New List(Of ETLineaNegocio)
        Call CargarUltraGrid(Grid2, Ls_Productos)
    End Sub

    Private Function ValidarLista() As Boolean
        ValidarLista = True
        Dim Checkeado As Long = 0
        If Ls_Productos IsNot Nothing Then
            For Each xRow As ETLineaNegocio In Ls_Productos
                If xRow.Action = True Then
                    Checkeado = Checkeado + 1
                End If
            Next
        End If

        If Checkeado = 0 Then
            MsgBox("Debe Checkear al menos un Producto", MsgBoxStyle.Critical, msgComacsa)
            ValidarLista = False
        End If

        Checkeado = 0
        If Ls_Proceso IsNot Nothing Then
            For Each xRow As ETLineaNegocio In Ls_Proceso
                If xRow.Action = True Then
                    Checkeado = Checkeado + 1
                End If
            Next
        End If

        If Checkeado = 0 Then
            MsgBox("Debe Checkear al menos un Proceso Productivo", MsgBoxStyle.Critical, msgComacsa)
            ValidarLista = False
        End If

    End Function


    Private Sub Grabar_LineaProd()
        If Me.Cbo1.Value = "K02" Then
            MsgBox("La Linea de Producción esta Anulada", MsgBoxStyle.Exclamation, msgComacsa)
            Call Inicio()
            Exit Sub
        End If

        Grid2.UpdateData()
        Grid3.UpdateData()

        If ValidarLista() = False Then
            Exit Sub
        End If

        Entidad.LineaProduccion = New ETLineaNegocio
        Negocio.LineaProduccion = New NGLineaProduccion
        With Entidad.LineaProduccion
            .Cod_Cia = Companhia
            .Codigo = Me.Txt1.Text.Trim
            .Descripcion = Me.Txt2.Text.Trim
            .Status = IIf(Me.Cbo1.Value = "K01", "", "*")
            .Tipo = TipoG
            .Usuario = User_Sistema
            .IDCatalogo = Me.LineaProduccion
        End With

        If Negocio.LineaProduccion.Mantto_LineaProduccion(Entidad.LineaProduccion, Ls_Productos, Ls_Proceso) > 0 Then
            Call Inicio()
        End If
    End Sub

    Private Sub Grabar_ProcesoProd()
        If Me.Cbo1.Value = "K02" Then
            MsgBox("El Proceso Productivo esta Anulada", MsgBoxStyle.Exclamation, msgComacsa)
            Call Inicio()
            Exit Sub
        End If

        Entidad.LineaProduccion = New ETLineaNegocio
        Negocio.LineaProduccion = New NGLineaProduccion
        With Entidad.LineaProduccion
            .Cod_Cia = Companhia
            .Codigo = Me.Txt1.Text.Trim
            .Descripcion = Me.Txt2.Text.Trim
            .Status = IIf(Me.Cbo1.Value = "K01", "", "*")
            .Tipo = TipoG
            .Usuario = User_Sistema
            .IDCatalogo = Me.LineaProduccion
        End With

        If Negocio.LineaProduccion.Mantto_ProcesoProductivo(Entidad.LineaProduccion) > 0 Then
            Call Inicio()
        End If
    End Sub

    Private Sub Eliminar_LineaProd()
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay Registros a Eliminar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If Grid1.ActiveRow Is Nothing Then
            MsgBox("Seleccione la Linea de Producción a Eliminar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        TipoG = sTate.eDel

        Entidad.LineaProduccion = New ETLineaNegocio
        Negocio.LineaProduccion = New NGLineaProduccion
        With Entidad.LineaProduccion
            .Cod_Cia = Companhia
            .Codigo = Grid1.ActiveRow.Cells("Codigo").Value
            .Descripcion = Grid1.ActiveRow.Cells("Descripcion").Value
            .Status = IIf(Me.Cbo1.Value = "K01", "", "*")
            .Tipo = TipoG
            .Usuario = User_Sistema
            .IDCatalogo = Grid1.ActiveRow.Cells("IDCatalogo").Value
        End With

        If Negocio.LineaProduccion.Mantto_LineaProduccion(Entidad.LineaProduccion, Nothing, Nothing) > 0 Then
            Call Inicio()
        End If
    End Sub

    Private Sub Eliminar_ProcesoProd()
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay Registros a Eliminar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If Grid1.ActiveRow Is Nothing Then
            MsgBox("Seleccione el Proceso Productivo a Eliminar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        TipoG = sTate.eDel

        Entidad.LineaProduccion = New ETLineaNegocio
        Negocio.LineaProduccion = New NGLineaProduccion
        With Entidad.LineaProduccion
            .Cod_Cia = Companhia
            .Codigo = Grid1.ActiveRow.Cells("Codigo").Value
            .Descripcion = Grid1.ActiveRow.Cells("Descripcion").Value
            .Status = IIf(Me.Cbo1.Value = "K01", "", "*")
            .Tipo = TipoG
            .Usuario = User_Sistema
            .IDCatalogo = Grid1.ActiveRow.Cells("IDCatalogo").Value
        End With

        If Negocio.LineaProduccion.Mantto_ProcesoProductivo(Entidad.LineaProduccion) > 0 Then
            Call Inicio()
        End If
    End Sub
#End Region

#Region "Procedimientos Publicos"

    Public Sub Nuevo()
        Call HabilitarControles(True)
        Call LimpiarDatos()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Call CargarProductos()
        Me.Txt2.Focus()
        TipoG = sTate.eNew
    End Sub

    Public Sub Grabar()

        If Not (TipoG = sTate.eEdit OrElse TipoG = sTate.eNew) Then
            MsgBox("Antes de Grabar debe presionar el evento Nuevo o Modificar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If


        Select Case Me.Tag.ToString.Trim
            Case "87"
                Call Grabar_LineaProd()
            Case "116"
                Call Grabar_ProcesoProd()
        End Select

    End Sub

    Public Sub Modificar()
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay Registros que Editar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If Grid1.ActiveRow Is Nothing Then
            MsgBox("Seleccione la Linea de Producción a Editar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        TipoG = sTate.eEdit
        Call LimpiarDatos()
        Call HabilitarControles(True)
        Me.Txt1.Text = Me.Grid1.ActiveRow.Cells("Codigo").Value
        Me.Txt2.Text = Me.Grid1.ActiveRow.Cells("Descripcion").Value
        Me.LineaProduccion = Me.Grid1.ActiveRow.Cells("IDCatalogo").Value
        If Me.Grid1.ActiveRow.Cells("Status").Value.ToString.Trim = "*" Then
            Me.Cbo1.Value = "K02"
        Else
            Me.Cbo1.Value = "K01"
        End If

        If Me.Tag.ToString.Trim = "87" Then
            Call CargarProductos()
            Call CargarProcesos()
        End If
        
        Tab1.Tabs("T02").Selected = True
        Me.Txt2.Focus()
    End Sub

    Public Sub Eliminar()

        Select Case Me.Tag.ToString.Trim
            Case "87"
                Call Eliminar_LineaProd()
            Case "116"
                Call Eliminar_ProcesoProd()
        End Select

    End Sub

    Public Sub Cancelar()
        Call Inicio()
    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        If Tab1.Tabs("T01").Selected = True Then
            Call Inicio()
        Else
            If Me.Tag.ToString.Trim = "87" Then
                If TipoG = sTate.eNew OrElse TipoG = sTate.eEdit Then
                    Call CargarProductos()
                Else
                    Call Inicio()
                End If
            Else
                Call Inicio()
            End If
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
#End Region

#Region "Grillas"

    Private Sub Grid3_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid3.AfterCellUpdate
        If e Is Nothing Then Exit Sub
        If sender Is Nothing Then Exit Sub

        If e.Cell.Column.Key = "Action" Then
            If e.Cell.Row.Cells("Action").Value = Boolean.TrueString Then
                OrdenProceso = OrdenProceso + 1
                e.Cell.Row.Cells("Orden").Value = OrdenProceso
            Else
                OrdenProceso = OrdenProceso - 1
                Dim Valor As Integer
                Valor = e.Cell.Row.Cells("Orden").Value
                e.Cell.Row.Cells("Orden").Value = 0
                If Grid3.Rows.Count > 0 Then
                    For Each xRow As UltraGridRow In Grid3.Rows
                        If xRow.Cells("Action").Value = Boolean.TrueString Then
                            If xRow.Cells("Orden").Value > Valor And Valor > 0 Then
                                xRow.Cells("Orden").Value = CInt(xRow.Cells("Orden").Value) - 1
                            End If
                        End If
                    Next
                    Grid3.Update()
                End If
            End If

        End If
    End Sub

    Private Sub Grid3_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles Grid3.ClickCell
        If e Is Nothing Then Exit Sub
        If sender Is Nothing Then Exit Sub

        Grid3.PerformAction(ExitEditMode)
        Grid3.PerformAction(NextRow)

    End Sub


   
    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout, Grid3.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" OrElse _
                        uColumn.Key = "Estado") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" OrElse _
                        uColumn.Key = "Action") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Grid3 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" OrElse _
                        uColumn.Key = "Action" OrElse uColumn.Key = "Orden") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

    End Sub
#End Region

   
End Class