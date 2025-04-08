Imports System
Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Drawing
Imports System.Windows
Imports System.Windows.Forms
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmCDetallada

#Region "Variables"

    Public Caso As Int16 = 0
    Public Fecha As Date = Date.Now
    Public Semana As Int32 = 0
    Public Anho As Int32 = 0
    Public Mes As Int32 = 0
    Private Ls_Detalle As ETObjecto
    Private Ls_Acumulado As ETObjecto
    Public CodProducto As String = String.Empty
    Public Descripcion As String = String.Empty

#End Region

#Region "Eventos"




    Sub Evento_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) _
                       Handles Me.FormClosing

        Ls_Detalle = Nothing
        Ls_Acumulado = Nothing

    End Sub
    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) _
                    Handles Me.Load

        If Not (Caso = 1 OrElse Caso = 8) Then Exit Sub

        If Caso = 1 Then
            Detallado()
        Else
            Acumulado()
        End If

    End Sub
    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout

        With sender.DisplayLayout.Bands(0)

            If sender Is Grid1 Then
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "NumPedido" Or uColumn.Key = "CodCliente" Or _
                            uColumn.Key = "DesCliente" Or uColumn.Key = "DocExt" Or _
                            uColumn.Key = "FechaEmision" Or uColumn.Key = "FechaRequerida" Or _
                            uColumn.Key = "Cantidad") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End If

            If sender Is Grid2 Then
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "NumPedido" Or uColumn.Key = "DesCliente" Or _
                            uColumn.Key = "FechaEmision" Or uColumn.Key = "FechaRequerida" Or _
                            uColumn.Key = "Cotizado" Or _
                            uColumn.Key = "Despachado1" Or uColumn.Key = "Pendiente1" Or _
                            uColumn.Key = "Despachado2" Or uColumn.Key = "Pendiente2") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End If

        End With

    End Sub
    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
                       Handles Grid1.KeyDown, Grid2.KeyDown
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
            Exit Sub
        End Try
    End Sub
#End Region

#Region "Metodos Locales"


    Sub Detallado()

        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Tab1.Tabs("T02").Visible = Boolean.FalseString

        Clb1.Value = Fecha
        Txt1.Value = Semana
        Txt2.Value = CodProducto
        Txt3.Value = Descripcion

        Negocio.Cliente = New NGCliente
        Entidad.Cliente = New ETCliente
        Ls_Detalle = New ETObjecto

        Entidad.Cliente.Codigo = CodProducto
        Entidad.Cliente.Anho = Anho
        Entidad.Cliente.Mes = Mes
        Entidad.Cliente.Semana = Semana

        Ls_Detalle = Negocio.Cliente.ConsultaProduccionDetallada(Entidad.Cliente)

        If Not Ls_Detalle.Validacion Then Exit Sub

        CargarUltraGrid(Grid1, Ls_Detalle.Datos)


    End Sub

    Sub Acumulado()

        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Tab1.Tabs("T01").Visible = Boolean.FalseString

        Clb2.Value = Fecha
        Txt4.Value = CodProducto
        Txt5.Value = Descripcion

        Negocio.Cliente = New NGCliente
        Entidad.Cliente = New ETCliente
        Ls_Acumulado = New ETObjecto

        Entidad.Cliente.Codigo = CodProducto
        Entidad.Cliente.Anho = Anho
        Entidad.Cliente.Mes = Mes
        Entidad.Cliente.Tipo = 8

        Ls_Acumulado = Negocio.Cliente.ConsultaProduccionAcumulado(Entidad.Cliente)

        If Not Ls_Acumulado.Validacion Then Exit Sub

        CargarUltraGrid(Grid2, Ls_Acumulado.Datos)

    End Sub

 


#End Region

End Class