
Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmCRumaxMineral

    Private Almacen As List(Of ETProducto)
    Private Planta As List(Of ETProducto)
    Private dt As DataTable

    Sub Evento_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        Almacen = Nothing
        Planta = Nothing
        dt = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        Entidad.Producto.Tipo = 3

        Almacen = New List(Of ETProducto)
        Almacen = Negocio.Producto.ConsultarAlmacen(Entidad.Producto)

        CargarUltraCombo(cbo1, Almacen, "CodAlmacen", "Descripcion", "02")

    End Sub

    Sub Evento_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo1.ValueChanged, cbo2.ValueChanged

        If sender.value = Nothing Then
            Exit Sub
        End If


        If CType(sender, UltraCombo) Is cbo1 Then

            Entidad.Producto = New ETProducto
            Negocio.Producto = New NGProducto

            Entidad.Producto.Tipo = 4
            Entidad.Producto.CodPlanta = sender.Value

            Planta = New List(Of ETProducto)
            Planta = Negocio.Producto.ConsultarAlmacen(Entidad.Producto)

            CargarUltraCombo(cbo2, Planta, "CodAlmacen", "Descripcion", strAlmacen)

            If cbo2.Rows.Count = 1 Then
                cbo2.Value = cbo2.Rows(0).Cells("CodAlmacen").Value
            End If


        End If

        If CType(sender, UltraCombo) Is cbo2 Then

            Entidad.Producto = New ETProducto
            Negocio.Ruma = New NGRuma

            Entidad.Producto.CodPlanta = cbo1.Value
            Entidad.Producto.CodAlmacen = cbo2.Value

            dt = New DataTable
            dt = Negocio.Ruma.ConsultarRuma2(Entidad.Producto)

            CargarUltraGrid(Grid1, dt)

        End If

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles cbo1.InitializeLayout, cbo2.InitializeLayout

        If sender IsNot Grid1 Then

            With sender.DisplayLayout.Bands(0)

                .ColHeadersVisible = False
                .Columns("Descripcion").Width = sender.Width

                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Descripcion") Then
                        uColumn.Hidden = True
                    End If
                Next

            End With

        End If

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Grid1.KeyDown
        Try
            With sender
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = True
                        .PerformAction(EnterEditMode)
                    Case Keys.Down
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = True
                        .PerformAction(EnterEditMode)
                    Case Keys.Right
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = True
                        .PerformAction(EnterEditMode)
                    Case Keys.Left
                        .PerformAction(ExitEditMode)
                        .PerformAction(PrevCellByTab)
                        e.Handled = True
                        .PerformAction(EnterEditMode)
                    Case Keys.Return
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = True
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch
            Exit Sub
        End Try
    End Sub

End Class