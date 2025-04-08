Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows
Imports System.Windows.Forms
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Win.UltraWinSchedule

Public Class FrmCStock

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub


#Region "Variables"

    Private App_SotckMinimo As New Infragistics.Win.Appearance
    Private App_Recomendado As New Infragistics.Win.Appearance
    Private Ls_Almacen As List(Of ETProducto) = Nothing
    Private Ls_TipProd As List(Of ETProducto) = Nothing
    Private Ls_StockProduccion As List(Of ETProducto) = Nothing
    Public vCargar As Boolean = Boolean.FalseString
    Private Enum FilterCombo
        Todos = 0
        MinxVenta = 1
        VentaxMin = 2
        Recomendada = 3
    End Enum

#End Region

#Region "Procedimientos"

    Sub Iniciar()

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        Entidad.Producto.Usuario = User_Sistema

        Ls_Almacen = New List(Of ETProducto)
        Ls_Almacen = Negocio.Producto.ConsultarFactor1(Entidad.Producto)

        Ls_TipProd = New List(Of ETProducto)
        Ls_TipProd = Negocio.Producto.ConsultarFactor2

        Call CargarUltraCombo(Cbo1, Ls_Almacen, "CodAlmacen", "Descripcion", strAlmacen)
        Call CargarUltraCombo(Cbo2, Ls_TipProd, "TipoProducto", "Descripcion", strTipoProd)

    End Sub

    Sub Consultar_Stock(ByVal _Tipo As Int16)

        Entidad.Producto = New ETProducto
        Entidad.MyLista = New ETMyLista
        Negocio.Producto = New NGProducto

        Entidad.Producto.Tipo = _Tipo
        Entidad.Producto.Fecha = Clb1.Value
        Entidad.Producto.Anho = Microsoft.VisualBasic.DateAndTime.Year(Clb1.Value)
        Entidad.Producto.Mes = Microsoft.VisualBasic.DateAndTime.Month(Clb1.Value)
        Entidad.Producto.CodProducto = Txt1.Value
        Entidad.Producto.Descripcion = Txt2.Value
        Entidad.Producto.CodAlmacen = Cbo1.Value
        Entidad.Producto.TipoProducto = Cbo2.Value

        Entidad.MyLista = Negocio.Producto.ConsultarProductoxStock(Entidad.Producto)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_StockProduccion = New List(Of ETProducto)
        Ls_StockProduccion = Entidad.MyLista.Ls_Producto

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_StockProduccion)

    End Sub

    Sub Format_SotckMinimo(ByVal e As InitializeRowEventArgs)

        If e Is Nothing Then
            Return
        End If

        If e.Row.Cells("StockMinimo").Value > e.Row.Cells("StockVenta").Value Then
            e.Row.Cells("StockMinimo").Appearance = App_SotckMinimo
        End If

        If e.Row.Cells("CantidadRecomendada").Value > Decimal.Zero Then
            e.Row.Cells("CantidadRecomendada").Appearance = App_Recomendado
        End If


    End Sub

    Sub Filtar_Combo()

        If Ls_StockProduccion Is Nothing Then Return

        Select Case Cbo3.SelectedIndex
            Case FilterCombo.MinxVenta
                For Each uRow As UltraGridRow In Grid1.Rows
                    If uRow.Cells("StockVenta").Value < uRow.Cells("StockMinimo").Value Then
                        uRow.Hidden = Boolean.FalseString
                    Else
                        uRow.Hidden = Boolean.TrueString
                    End If
                Next
            Case FilterCombo.VentaxMin
                For Each uRow As UltraGridRow In Grid1.Rows
                    If uRow.Cells("StockVenta").Value < uRow.Cells("StockMinimo").Value Then
                        uRow.Hidden = Boolean.TrueString
                    Else
                        uRow.Hidden = Boolean.FalseString
                    End If
                Next
            Case FilterCombo.Recomendada
                For Each uRow As UltraGridRow In Grid1.Rows
                    If uRow.Cells("CantidadRecomendada").Value = Decimal.Zero Then
                        uRow.Hidden = Boolean.TrueString
                    Else
                        uRow.Hidden = Boolean.FalseString
                    End If
                Next
            Case Else
                For Each uRow As UltraGridRow In Grid1.Rows
                    uRow.Hidden = Boolean.FalseString
                Next
        End Select
    End Sub

#End Region

#Region "Eventos"

    Sub Evento_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Cbo3.SelectedIndexChanged

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Cbo3 Then Return

        If Cbo3.SelectedIndex = -1 Then Return

        Call Filtar_Combo()

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Almacen IsNot Nothing Then Ls_Almacen = Nothing
        If Ls_TipProd IsNot Nothing Then Ls_TipProd = Nothing
        If Ls_StockProduccion IsNot Nothing Then Ls_StockProduccion = Nothing
        If App_SotckMinimo IsNot Nothing Then App_SotckMinimo = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles _
                                Cbo1.InitializeLayout, Cbo2.InitializeLayout, Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Cbo1 OrElse sender Is Cbo2 Then
            With e.Layout.Bands(0)
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Descripcion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
                .Columns("Descripcion").Width = sender.Width
                .ColHeadersVisible = Boolean.FalseString
            End With
            Return
        End If

        If sender Is Grid1 Then
            With e.Layout.Bands(0)
                For Each uColumn As UltraGridColumn In .Columns

                    'If Not (uColumn.Key = "CodProducto" OrElse uColumn.Key = "Descripcion" OrElse _
                    '        uColumn.Key = "Unidad" OrElse uColumn.Key = "StockDespacho" OrElse _
                    '        uColumn.Key = "StockVenta" OrElse uColumn.Key = "Stock") Then

                    '    uColumn.Hidden = Boolean.TrueString
                    '    Call VisualizarColumna(uColumn)
                    'Else
                    '    uColumn.Hidden = Boolean.FalseString  
                    'End If

                    If Not (uColumn.Key = "CodProducto" OrElse uColumn.Key = "Descripcion" OrElse _
                            uColumn.Key = "Unidad" OrElse uColumn.Key = "StockDespacho" OrElse _
                            uColumn.Key = "StockVenta" OrElse uColumn.Key = "Stock" OrElse _
                            uColumn.Key = "StockMinimo" OrElse _
                            uColumn.Key = "Proyeccion" OrElse uColumn.Key = "CantidadDespachada" OrElse _
                            uColumn.Key = "CantidadRecomendada") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If

                Next
            End With
        End If

    End Sub

    Sub Evento_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) _
                  Handles Txt1.KeyPress

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Txt1 Then Return

        If Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57 OrElse Asc(e.KeyChar) = Keys.Back Then
            e.Handled = Boolean.FalseString
        Else
            e.Handled = Boolean.TrueString
        End If

    End Sub

    Sub Evento_BeforeAlternateSelectedDateRangeChange(ByVal sender As Object, ByVal e As BeforeSelectedDateRangeChangeEventArgs) Handles _
                                                     Info1.BeforeAlternateSelectedDateRangeChange

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Info1 Then Return

        If Not e.WasMaxSelectedDaysExceeded Then Return

        e.DisplayMaxSelectedDaysErrorMsg = Boolean.FalseString

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles _
                       Txt1.KeyDown, Txt2.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Txt1 OrElse sender Is Txt2) Then Return

        If e.KeyValue <> Keys.Enter Then Return

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        If String.IsNullOrEmpty(sender.Value) Then
            Call Consultar_Stock(3)
        Else
            If sender Is Txt1 Then Call Consultar_Stock(1)
            If sender Is Txt2 Then Call Consultar_Stock(2)
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) Handles _
                             Grid1.InitializeRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        Call Format_SotckMinimo(e)

    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        App_SotckMinimo.FontData.Bold = DefaultableBoolean.True
        App_SotckMinimo.ForeColor = Color.White
        App_SotckMinimo.BackColor = Color.Red

        App_Recomendado.FontData.Bold = DefaultableBoolean.True
        App_Recomendado.ForeColor = Color.Yellow
        App_Recomendado.BackColor = Color.Red

    End Sub

#End Region

End Class