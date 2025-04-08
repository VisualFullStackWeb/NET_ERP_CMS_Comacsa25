Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinDataSource

Public Class frmMCostosIndirectos
    Private C As List(Of ETCosto)
    Private List As List(Of ETCosto)

#Region "UltraGrid1_InitializeLayout"

    'Private Sub UltraGrid1_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
    '    ' ------------------------------------------------------------------------
    '    ' To allow the user to be able to add/remove summaries set the 
    '    ' AllowRowSummaries property. This does not have to be set to summarize
    '    ' data in code.
    '    e.Layout.Override.AllowRowSummaries = AllowRowSummaries.True

    '    ' Here is how you can add summary of a column in code. The retruned 
    '    ' SummarySettings object has properties for specifying the appearance,
    '    ' visibility and where it's displayed among other settings.
    '    Dim columnToSummarize As UltraGridColumn = e.Layout.Bands(0).Columns("Total")
    '    Dim summary As SummarySettings = e.Layout.Bands(0).Summaries.Add("GrandTotal", SummaryType.Sum, columnToSummarize)
    '    summary.DisplayFormat = "Total = {0:c}"
    '    summary.Appearance.TextHAlign = HAlign.Right

    '    ' Add summary of Price column.
    '    columnToSummarize = e.Layout.Bands(0).Columns("Price")
    '    summary = e.Layout.Bands(0).Summaries.Add("PriceAvg", SummaryType.Average, columnToSummarize)
    '    summary.DisplayFormat = "Avg = {0:c}"
    '    summary.Appearance.TextHAlign = HAlign.Right

    '    ' To display summary footer on the top of the row collections set the 
    '    ' SummaryDisplayArea property to a value that has the Top or TopFixed flag
    '    ' set. TopFixed will make the summary fixed (non-scrolling). Note that 
    '    ' summaries are not fixed in the child rows. TopFixed setting behaves
    '    ' the same way as Top in child rows. Default is resolved to Bottom (and
    '    ' InGroupByRows more about which follows).
    '    e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed

    '    ' By default UltraGrid does not display summary footers or headers of
    '    ' group-by row islands. To display summary footers or headers of group-by row
    '    ' islands set the SummaryDisplayArea to a value that has GroupByRowsFooter
    '    ' flag set.
    '    e.Layout.Override.SummaryDisplayArea = e.Layout.Override.SummaryDisplayArea Or SummaryDisplayAreas.GroupByRowsFooter

    '    ' If you want to to display summaries of child rows in each group-by row
    '    ' set the SummaryDisplayArea to a value that has SummaryDisplayArea flag
    '    ' set. If SummaryDisplayArea is left to Default then the UltraGrid by
    '    ' default displays summaries in group-by rows.
    '    e.Layout.Override.SummaryDisplayArea = e.Layout.Override.SummaryDisplayArea Or SummaryDisplayAreas.InGroupByRows

    '    ' By default any summaries to be displayed in the group-by rows are displayed
    '    ' as text appended to the group-by row's description. You can set the 
    '    ' GroupBySummaryDisplayStyle property to SummaryCells or 
    '    ' SummaryCellsAlwaysBelowDescription to display summary values as a separate
    '    ' ui element (cell like element with border, to which the summary value related
    '    ' appearances are applied). Default value of GroupBySummaryDisplayStyle is resolved
    '    ' to Text.
    '    e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells

    '    ' Appearance of the summary area can be controlled using the 
    '    ' SummaryFooterAppearance. Even though the property's name contains the
    '    ' word 'footer', this appearance applies to summary area that is displayed
    '    ' on top as well (summary headers).
    '    e.Layout.Override.SummaryFooterAppearance.BackColor = SystemColors.Info

    '    ' Appearance of summary values can be controlled using the 
    '    ' SummaryValueAppearance property.
    '    e.Layout.Override.SummaryValueAppearance.BackColor = SystemColors.Window
    '    e.Layout.Override.SummaryValueAppearance.FontData.Bold = DefaultableBoolean.True

    '    ' Appearance of summary values that are displayed inside of group-by rows can 
    '    ' be controlled using the GroupBySummaryValueAppearance property.
    '    e.Layout.Override.GroupBySummaryValueAppearance.BackColor = SystemColors.Window
    '    e.Layout.Override.GroupBySummaryValueAppearance.TextHAlign = HAlign.Right

    '    ' Caption of the summary area can be set using the SummaryFooterCaption
    '    ' proeprty of the band.
    '    e.Layout.Bands(0).SummaryFooterCaption = "Grand Totals:"

    '    ' Caption's appearance can be controlled using the SummaryFooterCaptionAppearance
    '    ' property.
    '    e.Layout.Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True

    '    ' By default summary footer caption is visible. You can hide it using the
    '    ' SummaryFooterCaptionVisible property.
    '    e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False

    '    ' Display a separator between summary rows and scrolling rows.
    '    ' SpecialRowSeparator property can be used to display separators between
    '    ' various 'special' rows, including filer row, add-row, summary row and
    '    ' fixed rows. This property is a flagged enum property so it can take 
    '    ' multiple values.
    '    e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

    '    ' Appearance of the separator can be controlled using the 
    '    ' SpecialRowSeparatorAppearance property.
    '    e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

    '    ' Height of the separator can be controlled as well using the 
    '    ' SpecialRowSeparatorHeight property.
    '    e.Layout.Override.SpecialRowSeparatorHeight = 6

    '    ' Border style of the separator can be controlled using the 
    '    ' BorderStyleSpecialRowSeparator property.
    '    e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
    '    ' ------------------------------------------------------------------------

    '    ' OTHER MISCELLANEOUS ULTRAGRID SETTINGS
    '    ' ------------------------------------------------------------------------
    '    ' Set the view style to SingleBand.
    '    e.Layout.ViewStyle = ViewStyle.SingleBand

    '    ' Set the view style band to OutlookGroupBy.
    '    e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

    '    ' Group rows by Category 1 column.
    '    e.Layout.Bands(0).SortedColumns.Add("Category 1", False, True)
    '    ' ------------------------------------------------------------------------

    'End Sub

#End Region

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Entidad.Costo = New ETCosto
        Negocio.Costo = New NGCosto

        Entidad.Costo.Tipo = 1

        C = New List(Of ETCosto)

        C = Negocio.Costo.Consulta(Entidad.Costo)

        CargarUltraCombo(Combo1, C, "ID", "Descripcion")

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles Combo1.InitializeLayout, Grid1.InitializeLayout

        If sender Is Combo1 Then

            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Descripcion") Then
                    uColumn.Hidden = True
                End If
            Next
            With sender.DisplayLayout.Bands(0)
                .ColHeadersVisible = False
                .Columns("Descripcion").Width = sender.Width
            End With

        End If

        If sender Is Grid1 Then

            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Descripcion" OrElse uColumn.Key = "ID") Then
                    uColumn.Hidden = True
                End If
            Next

        End If

    End Sub


    Sub Evento_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Combo1.ValueChanged

        If sender Is Combo1 Then

            If Combo1.Value = Nothing Then
                Exit Sub
            End If

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

            Entidad.Costo = New ETCosto
            Negocio.Costo = New NGCosto

            Entidad.Costo.Tipo = 2
            Entidad.Costo.ID = Combo1.Value

            List = New List(Of ETCosto)
            List = Negocio.Costo.Consulta(Entidad.Costo)

            Call CargarUltraGrid(Grid1, List)

            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

        End If

    End Sub

    Public Sub Nuevo()

        If List Is Nothing Then
            Exit Sub
        End If

        Entidad.Costo = New ETCosto
        Entidad.Costo.ID = Nothing
        Entidad.Costo.Descripcion = String.Empty

        List.Add(Entidad.Costo)

        CargarUltraGrid(Grid1, List)

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) Handles Grid1.InitializeRow

        If sender Is Grid1 Then

            If e.Row.Cells("ID").Value = 0 Then
                e.Row.Cells("Descripcion").Appearance.ForeColor = Color.Red
                Combo1.Refresh()
            End If

        End If

    End Sub


End Class