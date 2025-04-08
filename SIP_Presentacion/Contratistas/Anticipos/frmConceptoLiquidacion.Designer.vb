<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConceptoLiquidacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConceptoLiquidacion))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONCEPTO", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOTAL", 2)
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHACESE", 3)
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CONCEPTO", 1, False)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TOTAL", 2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TOTAL", 2, False)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(614)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.dtcese = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.gridconceptos = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnaceptar = New System.Windows.Forms.Button
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtcese, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridconceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraLabel3
        '
        Appearance83.BackColor = System.Drawing.Color.Transparent
        Appearance83.TextHAlignAsString = "Center"
        Appearance83.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance83
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(12, 22)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(63, 14)
        Me.UltraLabel3.TabIndex = 210
        Me.UltraLabel3.Text = "Fecha cese"
        '
        'dtcese
        '
        Me.dtcese.AutoSize = False
        Me.dtcese.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtcese.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtcese.Location = New System.Drawing.Point(81, 18)
        Me.dtcese.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtcese.Name = "dtcese"
        Me.dtcese.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtcese.Size = New System.Drawing.Size(110, 21)
        Me.dtcese.TabIndex = 209
        Me.dtcese.TabStop = False
        Me.dtcese.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'gridconceptos
        '
        Me.gridconceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridconceptos.DisplayLayout.Appearance = Appearance16
        Me.gridconceptos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance20.Image = CType(resources.GetObject("Appearance20.Image"), Object)
        Appearance20.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance20.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance20
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance25.TextHAlignAsString = "Left"
        UltraGridColumn2.CellAppearance = Appearance25
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.MinWidth = 8
        UltraGridColumn2.Width = 76
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 415
        Appearance54.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance54
        UltraGridColumn4.Format = "#####0.00 "
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.MaskInput = "{double:8.2}"
        UltraGridColumn4.Width = 161
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 91
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Appearance1.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance1
        SummarySettings1.DisplayFormat = "Total"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance3
        Appearance4.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance4
        SummarySettings2.DisplayFormat = "{0}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance5
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
        UltraGridBand1.SummaryFooterCaption = ""
        Me.gridconceptos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridconceptos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridconceptos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridconceptos.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance27.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance27.BorderColor = System.Drawing.SystemColors.Window
        Me.gridconceptos.DisplayLayout.GroupByBox.Appearance = Appearance27
        Appearance32.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridconceptos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance32
        Me.gridconceptos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridconceptos.DisplayLayout.GroupByBox.Hidden = True
        Appearance33.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance33.BackColor2 = System.Drawing.SystemColors.Control
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridconceptos.DisplayLayout.GroupByBox.PromptAppearance = Appearance33
        Me.gridconceptos.DisplayLayout.MaxColScrollRegions = 1
        Me.gridconceptos.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridconceptos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridconceptos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridconceptos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Me.gridconceptos.DisplayLayout.Override.CardAreaAppearance = Appearance34
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Appearance35.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridconceptos.DisplayLayout.Override.CellAppearance = Appearance35
        Me.gridconceptos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridconceptos.DisplayLayout.Override.CellPadding = 0
        Me.gridconceptos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridconceptos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridconceptos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridconceptos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance40.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance40.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridconceptos.DisplayLayout.Override.FilterRowAppearance = Appearance40
        Me.gridconceptos.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridconceptos.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance44.BackColor = System.Drawing.SystemColors.Control
        Appearance44.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance44.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance44.BorderColor = System.Drawing.SystemColors.Window
        Me.gridconceptos.DisplayLayout.Override.GroupByRowAppearance = Appearance44
        Appearance45.FontData.Name = "Arial Narrow"
        Appearance45.FontData.SizeInPoints = 10.0!
        Appearance45.TextHAlignAsString = "Left"
        Me.gridconceptos.DisplayLayout.Override.HeaderAppearance = Appearance45
        Me.gridconceptos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridconceptos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridconceptos.DisplayLayout.Override.MinRowHeight = 24
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Appearance47.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance47.TextVAlignAsString = "Middle"
        Me.gridconceptos.DisplayLayout.Override.RowAppearance = Appearance47
        Me.gridconceptos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridconceptos.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridconceptos.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance48.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridconceptos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance48
        Me.gridconceptos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridconceptos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridconceptos.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridconceptos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridconceptos.Location = New System.Drawing.Point(12, 45)
        Me.gridconceptos.Name = "gridconceptos"
        Me.gridconceptos.Size = New System.Drawing.Size(616, 237)
        Me.gridconceptos.TabIndex = 211
        Me.gridconceptos.Text = "UltraGrid1"
        '
        'btnaceptar
        '
        Me.btnaceptar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnaceptar.Location = New System.Drawing.Point(508, 288)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(120, 21)
        Me.btnaceptar.TabIndex = 212
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'frmConceptoLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(640, 313)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.gridconceptos)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.dtcese)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConceptoLiquidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidacion de Trabajador"
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtcese, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridconceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtcese As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents gridconceptos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
End Class
