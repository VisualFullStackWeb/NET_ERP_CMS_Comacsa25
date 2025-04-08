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

Public Class FrmLStockMinimo

#Region "Variables"

    Private Ls_StockProduccion As List(Of ETProducto) = Nothing
    Private Lista As List(Of ETProducto) = Nothing
    Private Apariencia As New Infragistics.Win.Appearance
    Public CodProducto As String = String.Empty
    Public Descripcion As String = String.Empty
    Public Cantidad As Decimal = Decimal.Zero

#End Region

#Region "Eventos"

    Sub Evento_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Apariencia.FontData.Bold = DefaultableBoolean.True
        Apariencia.ForeColor = Color.Red

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()

    End Sub

    Sub Evento_ClickCellButton(ByVal sender As Object, ByVal e As CellEventArgs) Handles Grid1.ClickCellButton

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Cell.Column.Key <> "DifMinxVenta" Then Return

        If MessageBox.Show(" ¿ Desea Generar una Orden de Producción para " & vbNewLine & _
                           e.Cell.Row.Cells("Descripcion").Value & " ? ", _
                           Mensaje.Comacsa, MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question) = Forms.DialogResult.No Then Return

        e.Cell.Row.Appearance = Apariencia

        Call Transferir_Formulario(e.Cell.Row)

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles _
                                Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        With e.Layout.Bands(0)
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "CodProducto" OrElse uColumn.Key = "Descripcion" OrElse _
                        uColumn.Key = "Unidad" OrElse uColumn.Key = "StockDespacho" OrElse _
                        uColumn.Key = "StockVenta" OrElse uColumn.Key = "Stock" OrElse _
                        uColumn.Key = "StockMinimo" OrElse uColumn.Key = "DifMinxVenta") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With

    End Sub

#End Region

#Region "Procedimiento"

    Sub Iniciar()

        Entidad.Producto = New ETProducto
        Entidad.MyLista = New ETMyLista
        Negocio.Producto = New NGProducto

        Entidad.Producto.Tipo = 3
        Entidad.Producto.Fecha = Now
        Entidad.Producto.Anho = Year(Now)
        Entidad.Producto.Mes = Month(Now)
        Entidad.Producto.CodAlmacen = strAlmacen
        Entidad.Producto.TipoProducto = strTipoProd

        Entidad.MyLista = Negocio.Producto.ConsultarProductoxStock(Entidad.Producto)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_StockProduccion = New List(Of ETProducto)
        Ls_StockProduccion = Entidad.MyLista.Ls_Producto

        Ls_StockProduccion = Ls_StockProduccion.Where(AddressOf Where_StockMinimo).ToList

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_StockProduccion)

    End Sub

#End Region

#Region "Funciones"

    Function Where_StockMinimo(ByVal Rpt As ETProducto) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.DifMinxVenta > 0 Then lResult = Boolean.TrueString

        Return lResult

    End Function

    Function Where_Contar(ByVal Rpt As ETProducto) As Boolean

        Dim lResult As Boolean = Boolean.FalseString

        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.Update Then lResult = Boolean.TrueString

        Return lResult

    End Function

#End Region

    Sub Transferir_Formulario(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        StrucForm.FxLxOrdenProduccion = New FrmLOrdenProduccion
        StrucForm.FxLxOrdenProduccion.MdiParent = MdiParent
        StrucForm.FxLxOrdenProduccion.CodProducto = uRow.Cells("CodProducto").Value
        StrucForm.FxLxOrdenProduccion.Descripcion = uRow.Cells("Descripcion").Value
        StrucForm.FxLxOrdenProduccion.Cantidad = uRow.Cells("DifMinxVenta").Value
        StrucForm.FxLxOrdenProduccion.Text = "Stock Mínimo (" & uRow.Cells("Descripcion").Value & ")"
        StrucForm.FxLxOrdenProduccion.EjecutarxStockMinimo = Boolean.TrueString
        StrucForm.FxLxOrdenProduccion.Show()
        StrucForm.FxLxOrdenProduccion = Nothing

    End Sub

End Class