Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmCProductos

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub


#Region "Declaraciones"

    Public vCargar As Boolean = Boolean.FalseString
    Public CodProducto As String = String.Empty
    Public Descripcion As String = String.Empty
    Public L As Boolean = Boolean.FalseString
    Public RumaProd As Boolean = Boolean.FalseString
    Public Orden As Boolean = Boolean.FalseString
    Private Ls_Producto As List(Of ETProducto) = Nothing
    Public Lista As List(Of ETRuma) = Nothing
    Private MdiOperaciones As List(Of String) = Nothing

#End Region

#Region "Eventos"

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
    '                     Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Actualizar)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
                          Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Producto IsNot Nothing Then Ls_Producto = Nothing
        If Lista IsNot Nothing Then Lista = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) _
                                Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If Not L Then Return

        If Not VerificarControl(5, Grid1) Then Return

        If e.Row.IsFilterRow Then Return

        e.Row.Fixed = Not e.Row.Fixed

        If RumaProd = False Then
            Call Cargar_Producto(e.Row)
        End If


    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        For Each uColumn As UltraGridColumn In Grid1.DisplayLayout.Bands(0).Columns
            If Not (uColumn.Key = "CodProducto" OrElse uColumn.Key = "Descripcion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
                         Handles Grid1.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        Try
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
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch
        End Try
    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()

    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn1.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Btn1 Then Return

        If Not L Then Return

        If Not VerificarControl(5, Grid1) Then Return

        If Grid1.ActiveRow.IsFilterRow Then Return

        If RumaProd = False Then
            Call Cargar_Producto(Grid1.ActiveRow)
        Else
            If Grid1.Rows.FixedRows.Count = 0 Then
                MessageBox.Show("Seleccione al menos una Ruma", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            Lista = New List(Of ETRuma)

            For Each uRow As UltraGridRow In Grid1.Rows.FixedRows
                Entidad.Ruma = New ETRuma
                Entidad.Ruma.CodRuma = uRow.Cells("CodProducto").Value
                Entidad.Ruma.Descripcion = uRow.Cells("Descripcion").Value
                Lista.Add(Entidad.Ruma)
            Next

            vCargar = Boolean.TrueString

            If L Then Close()
        End If


    End Sub

#End Region

#Region "Procedimientos"

    Sub Iniciar()

        If L Then
            Btn1.Enabled = Boolean.TrueString
        Else
            Btn1.Enabled = Boolean.FalseString
        End If


        vCargar = Boolean.FalseString

        Entidad.Producto = New ETProducto
        Entidad.MyLista = New ETMyLista
        Negocio.Producto = New NGProducto
        Entidad.Producto.Tipo = 10

        Ls_Producto = New List(Of ETProducto)
        Dim dtDatos As New DataTable
        dtDatos = Negocio.Producto.ConsultarProducto(Entidad.Producto)
        'Entidad.MyLista = Negocio.Producto.ConsultarProducto(Entidad.Producto)

        'If Entidad.MyLista.Validacion Then
        '    Ls_Producto = Entidad.MyLista.Ls_Producto
        'End If

        Call CargarUltraGridxBinding(Grid1, Source1, dtDatos)

    End Sub

    Sub Cargar_Producto(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        If Orden AndAlso Not Validar_Orden(uRow) Then Return

        vCargar = Boolean.TrueString
        CodProducto = uRow.Cells("CodProducto").Value
        Descripcion = uRow.Cells("Descripcion").Value

        If L Then Close()

    End Sub

#End Region

#Region "Públicos"

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

#Region "Function"

    Function Validar_Orden(ByVal uRow As UltraGridRow) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If uRow Is Nothing Then
            Return lResult
        End If

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        Entidad.Producto.CodProducto = uRow.Cells("CodProducto").Value
        Entidad.Producto = Negocio.Producto.ValidarProductoOrden(Entidad.Producto)

        lResult = Entidad.Producto.Validacion

        Return lResult

    End Function

#End Region

End Class