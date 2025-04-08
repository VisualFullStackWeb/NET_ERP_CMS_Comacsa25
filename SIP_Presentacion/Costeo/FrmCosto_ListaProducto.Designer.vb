<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCosto_ListaProducto
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
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCosto_ListaProducto))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROD", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PRODUCTO", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UNIDAD", 2)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(535)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(492)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(731)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(731)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(731)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(390)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(290)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion13 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion14 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion16 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion17 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion18 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.gridcostoproducto = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.gridcostoproducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridcostoproducto
        '
        Appearance69.BackColor = System.Drawing.SystemColors.Window
        Appearance69.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridcostoproducto.DisplayLayout.Appearance = Appearance69
        Me.gridcostoproducto.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance70.Image = CType(resources.GetObject("Appearance70.Image"), Object)
        Appearance70.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance70.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance70
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.Caption = "CODIGO"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.Width = 99
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.Width = 306
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn4.Width = 92
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4})
        Me.gridcostoproducto.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridcostoproducto.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridcostoproducto.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion16)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion17)
        Me.gridcostoproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion18)
        Me.gridcostoproducto.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance72.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance72.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance72.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance72.BorderColor = System.Drawing.SystemColors.Window
        Me.gridcostoproducto.DisplayLayout.GroupByBox.Appearance = Appearance72
        Appearance73.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridcostoproducto.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance73
        Me.gridcostoproducto.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridcostoproducto.DisplayLayout.GroupByBox.Hidden = True
        Appearance74.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance74.BackColor2 = System.Drawing.SystemColors.Control
        Appearance74.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance74.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridcostoproducto.DisplayLayout.GroupByBox.PromptAppearance = Appearance74
        Me.gridcostoproducto.DisplayLayout.MaxColScrollRegions = 1
        Me.gridcostoproducto.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridcostoproducto.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridcostoproducto.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridcostoproducto.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance75.BackColor = System.Drawing.SystemColors.Window
        Me.gridcostoproducto.DisplayLayout.Override.CardAreaAppearance = Appearance75
        Appearance76.BorderColor = System.Drawing.Color.Silver
        Appearance76.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridcostoproducto.DisplayLayout.Override.CellAppearance = Appearance76
        Me.gridcostoproducto.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridcostoproducto.DisplayLayout.Override.CellPadding = 0
        Me.gridcostoproducto.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridcostoproducto.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridcostoproducto.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridcostoproducto.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance77.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance77.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridcostoproducto.DisplayLayout.Override.FilterRowAppearance = Appearance77
        Me.gridcostoproducto.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridcostoproducto.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridcostoproducto.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance78.BackColor = System.Drawing.SystemColors.Control
        Appearance78.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance78.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance78.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance78.BorderColor = System.Drawing.SystemColors.Window
        Me.gridcostoproducto.DisplayLayout.Override.GroupByRowAppearance = Appearance78
        Appearance79.FontData.Name = "Arial Narrow"
        Appearance79.FontData.SizeInPoints = 10.0!
        Appearance79.TextHAlignAsString = "Left"
        Me.gridcostoproducto.DisplayLayout.Override.HeaderAppearance = Appearance79
        Me.gridcostoproducto.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridcostoproducto.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridcostoproducto.DisplayLayout.Override.MinRowHeight = 24
        Appearance80.BackColor = System.Drawing.SystemColors.Window
        Appearance80.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance80.TextVAlignAsString = "Middle"
        Me.gridcostoproducto.DisplayLayout.Override.RowAppearance = Appearance80
        Me.gridcostoproducto.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridcostoproducto.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridcostoproducto.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance81.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridcostoproducto.DisplayLayout.Override.TemplateAddRowAppearance = Appearance81
        Me.gridcostoproducto.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridcostoproducto.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridcostoproducto.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridcostoproducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridcostoproducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridcostoproducto.Location = New System.Drawing.Point(0, 0)
        Me.gridcostoproducto.Name = "gridcostoproducto"
        Me.gridcostoproducto.Size = New System.Drawing.Size(537, 495)
        Me.gridcostoproducto.TabIndex = 202
        '
        'FrmCosto_ListaProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 495)
        Me.Controls.Add(Me.gridcostoproducto)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCosto_ListaProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCosto_ListaProducto"
        CType(Me.gridcostoproducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridcostoproducto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
End Class
