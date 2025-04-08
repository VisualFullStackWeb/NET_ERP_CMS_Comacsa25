Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMProyVentas
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub


#Region "Variables"

    Private Ls_Proyeccion As List(Of ETProducto) = Nothing
    Private MdiOperaciones As List(Of String) = Nothing

#End Region

#Region "Publicos"

    Public Sub Modificar()

        Call Emitar_Grilla(Boolean.TrueString)

    End Sub

    Public Sub Cancelar()

        Call Emitar_Grilla()

    End Sub

    Public Sub Grabar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Grabar_Proyeccion()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Actualizar()

        If Cbo1.SelectedItem Is Nothing Then Return
        If Cbo2.SelectedItem Is Nothing Then Return

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Consultar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

#Region "Eventos"

    Sub Evento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _
                                    Cbo1.SelectedIndexChanged, Cbo2.SelectedIndexChanged

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Cbo1.SelectedItem Is Nothing Then Return
        If Cbo2.SelectedItem Is Nothing Then Return

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Consultar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing
        If Ls_Proyeccion IsNot Nothing Then Ls_Proyeccion = Nothing

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles _
                      Grid1.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

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
                    .PerformAction(NextCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
            End Select
        End With

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles _
                                Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        With e.Layout.Bands(0)
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "CodProducto" OrElse _
                        uColumn.Key = "Descripcion" OrElse _
                        uColumn.Key = "Cantidad") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With

    End Sub

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Modificar)
    '    MdiOperaciones.Add(StrucOperaciones._Cancelar)
    '    MdiOperaciones.Add(StrucOperaciones._Actualizar)
    '    MdiOperaciones.Add(StrucOperaciones._Grabar)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

#End Region

#Region "Procedimientos"

    Sub Grabar_Proyeccion()

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        Entidad.Producto.Usuario = User_Sistema
        Entidad.Producto.Anho = Cbo1.SelectedItem
        Entidad.Producto.Mes = Cbo2.SelectedIndex + 1

        Entidad.Producto = Negocio.Producto.MantenimientoProyeccion(Entidad.Producto, Ls_Proyeccion)

        If Not Entidad.Producto.Validacion Then Return

        If Entidad.Producto.Validacion Then Call Cancelar()

    End Sub

    Sub Emitar_Grilla(Optional ByVal _Tipo As Boolean = True)

        If _Tipo Then
            Grid1.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Activation.AllowEdit
        Else
            Grid1.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Activation.ActivateOnly
        End If

    End Sub

    Sub Consultar()

        Negocio.Producto = New NGProducto
        Entidad.MyLista = New ETMyLista
        Entidad.Producto = New ETProducto

        Entidad.Producto.Anho = Cbo1.SelectedItem
        Entidad.Producto.Mes = Cbo2.SelectedIndex + 1

        Entidad.MyLista = Negocio.Producto.ConsultarProyeccion_1(Entidad.Producto)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Proyeccion = New List(Of ETProducto)
        Ls_Proyeccion = Entidad.MyLista.Ls_Producto

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Proyeccion)

    End Sub

#End Region

End Class