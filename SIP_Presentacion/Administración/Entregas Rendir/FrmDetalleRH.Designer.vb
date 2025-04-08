<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetalleRH
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDetalleRH))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Concepto", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 2)
        Dim Appearance153 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance154 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("montoTotal", 3)
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fila", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idComp", 5)
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Descripcion", 2, False)
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "montoTotal", 3, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "montoTotal", 3, False)
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(838)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.chkDirecto = New System.Windows.Forms.CheckBox
        Me.chkIndirecto = New System.Windows.Forms.CheckBox
        Me.txtnumero = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtserie = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txttd = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtruc = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtrazon = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.gridConceptos = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraLabel19 = New Infragistics.Win.Misc.UltraLabel
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.txtnumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtserie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtrazon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkDirecto
        '
        Me.chkDirecto.AutoSize = True
        Me.chkDirecto.Location = New System.Drawing.Point(33, 35)
        Me.chkDirecto.Name = "chkDirecto"
        Me.chkDirecto.Size = New System.Drawing.Size(60, 17)
        Me.chkDirecto.TabIndex = 148
        Me.chkDirecto.Text = "Directo"
        Me.chkDirecto.UseVisualStyleBackColor = True
        '
        'chkIndirecto
        '
        Me.chkIndirecto.AutoSize = True
        Me.chkIndirecto.Location = New System.Drawing.Point(93, 35)
        Me.chkIndirecto.Name = "chkIndirecto"
        Me.chkIndirecto.Size = New System.Drawing.Size(67, 17)
        Me.chkIndirecto.TabIndex = 149
        Me.chkIndirecto.Text = "Indirecto"
        Me.chkIndirecto.UseVisualStyleBackColor = True
        '
        'txtnumero
        '
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.TextHAlignAsString = "Left"
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtnumero.Appearance = Appearance4
        Me.txtnumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumero.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtnumero.Location = New System.Drawing.Point(602, 162)
        Me.txtnumero.MaxLength = 8
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.ReadOnly = True
        Me.txtnumero.Size = New System.Drawing.Size(141, 21)
        Me.txtnumero.TabIndex = 154
        Me.txtnumero.TabStop = False
        '
        'txtserie
        '
        Appearance10.FontData.BoldAsString = "False"
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.TextHAlignAsString = "Left"
        Appearance10.TextVAlignAsString = "Middle"
        Me.txtserie.Appearance = Appearance10
        Me.txtserie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtserie.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtserie.Location = New System.Drawing.Point(530, 162)
        Me.txtserie.MaxLength = 8
        Me.txtserie.Name = "txtserie"
        Me.txtserie.ReadOnly = True
        Me.txtserie.Size = New System.Drawing.Size(66, 21)
        Me.txtserie.TabIndex = 153
        Me.txtserie.TabStop = False
        '
        'txttd
        '
        Appearance9.FontData.BoldAsString = "False"
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.TextHAlignAsString = "Left"
        Appearance9.TextVAlignAsString = "Middle"
        Me.txttd.Appearance = Appearance9
        Me.txttd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttd.Location = New System.Drawing.Point(144, 162)
        Me.txttd.MaxLength = 8
        Me.txttd.Name = "txttd"
        Me.txttd.ReadOnly = True
        Me.txttd.Size = New System.Drawing.Size(100, 21)
        Me.txttd.TabIndex = 152
        Me.txttd.TabStop = False
        '
        'txtruc
        '
        Appearance1.FontData.BoldAsString = "False"
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.TextHAlignAsString = "Left"
        Appearance1.TextVAlignAsString = "Middle"
        Me.txtruc.Appearance = Appearance1
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtruc.Location = New System.Drawing.Point(38, 162)
        Me.txtruc.MaxLength = 8
        Me.txtruc.Name = "txtruc"
        Me.txtruc.ReadOnly = True
        Me.txtruc.Size = New System.Drawing.Size(100, 21)
        Me.txtruc.TabIndex = 151
        Me.txtruc.TabStop = False
        '
        'txtrazon
        '
        Appearance42.TextHAlignAsString = "Left"
        Appearance42.TextVAlignAsString = "Middle"
        Me.txtrazon.Appearance = Appearance42
        Me.txtrazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrazon.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtrazon.Location = New System.Drawing.Point(250, 162)
        Me.txtrazon.Name = "txtrazon"
        Me.txtrazon.ReadOnly = True
        Me.txtrazon.Size = New System.Drawing.Size(274, 21)
        Me.txtrazon.TabIndex = 150
        Me.txtrazon.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(763, 449)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(108, 23)
        Me.btnAceptar.TabIndex = 155
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'gridConceptos
        '
        Me.gridConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridConceptos.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance56.BackColor = System.Drawing.SystemColors.Window
        Appearance56.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridConceptos.DisplayLayout.Appearance = Appearance56
        Me.gridConceptos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance57.Image = CType(resources.GetObject("Appearance57.Image"), Object)
        Appearance57.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance57.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance57
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 3
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 25
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit
        UltraGridColumn1.Width = 25
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn2.Header.VisiblePosition = 0
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.MaskInput = ""
        UltraGridColumn2.MaxWidth = 30
        UltraGridColumn2.MinWidth = 30
        UltraGridColumn2.Nullable = Infragistics.Win.UltraWinGrid.Nullable.EmptyString
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.Width = 30
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn3.Header.Caption = "CONCEPTO"
        UltraGridColumn3.Header.VisiblePosition = 1
        UltraGridColumn3.MaskInput = ""
        UltraGridColumn3.MinWidth = 108
        UltraGridColumn3.Nullable = Infragistics.Win.UltraWinGrid.Nullable.EmptyString
        UltraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.Width = 136
        Appearance153.FontData.SizeInPoints = 8.0!
        Appearance153.TextHAlignAsString = "Left"
        UltraGridColumn4.CellAppearance = Appearance153
        UltraGridColumn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn4.Format = ""
        Appearance154.TextHAlignAsString = "Center"
        UltraGridColumn4.Header.Appearance = Appearance154
        UltraGridColumn4.Header.Caption = "DESCRIPCION"
        UltraGridColumn4.Header.VisiblePosition = 2
        UltraGridColumn4.MaskInput = ""
        UltraGridColumn4.MinWidth = 85
        UltraGridColumn4.Nullable = Infragistics.Win.UltraWinGrid.Nullable.EmptyString
        UltraGridColumn4.NullText = ""
        UltraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn4.Width = 581
        Appearance63.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance63
        UltraGridColumn5.Format = "#####0.00 "
        Appearance64.TextHAlignAsString = "Center"
        UltraGridColumn5.Header.Appearance = Appearance64
        UltraGridColumn5.Header.Caption = "TOTAL"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.MaskInput = "{double:8.2}"
        UltraGridColumn5.MaxValue = "999999.99"
        UltraGridColumn5.MaxWidth = 83
        UltraGridColumn5.MinValue = "0.00"
        UltraGridColumn5.MinWidth = 63
        UltraGridColumn5.Nullable = Infragistics.Win.UltraWinGrid.Nullable.[Nothing]
        UltraGridColumn5.NullText = "0.00"
        UltraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn5.Width = 83
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 180
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 56
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7})
        UltraGridBand1.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.DefaultRowHeight = 20
        UltraGridBand1.Override.MinRowHeight = 40
        UltraGridBand1.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Free
        UltraGridBand1.Override.RowSizingArea = Infragistics.Win.UltraWinGrid.RowSizingArea.EntireRow
        UltraGridBand1.Override.RowSizingAutoMaxLines = 4
        Appearance5.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance5
        SummarySettings1.DisplayFormat = "Total"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance2
        Appearance6.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance6
        SummarySettings2.DisplayFormat = "{0}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance3
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
        UltraGridBand1.SummaryFooterCaption = ""
        Me.gridConceptos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridConceptos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridConceptos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridConceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridConceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridConceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridConceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridConceptos.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance65.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance65.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance65.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance65.BorderColor = System.Drawing.SystemColors.Window
        Me.gridConceptos.DisplayLayout.GroupByBox.Appearance = Appearance65
        Appearance66.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridConceptos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance66
        Me.gridConceptos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridConceptos.DisplayLayout.GroupByBox.Hidden = True
        Appearance69.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance69.BackColor2 = System.Drawing.SystemColors.Control
        Appearance69.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance69.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridConceptos.DisplayLayout.GroupByBox.PromptAppearance = Appearance69
        Me.gridConceptos.DisplayLayout.MaxColScrollRegions = 1
        Me.gridConceptos.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridConceptos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridConceptos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridConceptos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance70.BackColor = System.Drawing.SystemColors.Window
        Me.gridConceptos.DisplayLayout.Override.CardAreaAppearance = Appearance70
        Appearance71.BorderColor = System.Drawing.Color.Silver
        Appearance71.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridConceptos.DisplayLayout.Override.CellAppearance = Appearance71
        Me.gridConceptos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridConceptos.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridConceptos.DisplayLayout.Override.CellPadding = 0
        Me.gridConceptos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridConceptos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridConceptos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridConceptos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance72.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridConceptos.DisplayLayout.Override.FilterRowAppearance = Appearance72
        Me.gridConceptos.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridConceptos.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance73.BackColor = System.Drawing.SystemColors.Control
        Appearance73.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance73.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance73.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance73.BorderColor = System.Drawing.SystemColors.Window
        Me.gridConceptos.DisplayLayout.Override.GroupByRowAppearance = Appearance73
        Appearance74.FontData.Name = "Arial Narrow"
        Appearance74.FontData.SizeInPoints = 10.0!
        Appearance74.TextHAlignAsString = "Left"
        Me.gridConceptos.DisplayLayout.Override.HeaderAppearance = Appearance74
        Me.gridConceptos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridConceptos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridConceptos.DisplayLayout.Override.MinRowHeight = 24
        Appearance75.BackColor = System.Drawing.SystemColors.Window
        Appearance75.BorderColor = System.Drawing.Color.Silver
        Appearance75.TextVAlignAsString = "Middle"
        Me.gridConceptos.DisplayLayout.Override.RowAppearance = Appearance75
        Me.gridConceptos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridConceptos.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridConceptos.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance76.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridConceptos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance76
        Me.gridConceptos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridConceptos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridConceptos.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridConceptos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridConceptos.Location = New System.Drawing.Point(31, 62)
        Me.gridConceptos.Name = "gridConceptos"
        Me.gridConceptos.Size = New System.Drawing.Size(840, 381)
        Me.gridConceptos.TabIndex = 157
        Me.gridConceptos.Text = "UltraGrid1"
        '
        'UltraLabel19
        '
        Me.UltraLabel19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance45.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance45.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance45.ForeColor = System.Drawing.Color.White
        Appearance45.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance45.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance45.TextHAlignAsString = "Left"
        Appearance45.TextVAlignAsString = "Middle"
        Me.UltraLabel19.Appearance = Appearance45
        Me.UltraLabel19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel19.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption
        Me.UltraLabel19.Location = New System.Drawing.Point(0, 3)
        Me.UltraLabel19.Name = "UltraLabel19"
        Me.UltraLabel19.Size = New System.Drawing.Size(899, 25)
        Me.UltraLabel19.TabIndex = 158
        Me.UltraLabel19.Text = "  Detalle de Recibo Honorario"
        '
        'FrmDetalleRH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(897, 480)
        Me.Controls.Add(Me.UltraLabel19)
        Me.Controls.Add(Me.gridConceptos)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.chkIndirecto)
        Me.Controls.Add(Me.chkDirecto)
        Me.Controls.Add(Me.txtnumero)
        Me.Controls.Add(Me.txtserie)
        Me.Controls.Add(Me.txttd)
        Me.Controls.Add(Me.txtruc)
        Me.Controls.Add(Me.txtrazon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDetalleRH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.txtnumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtserie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtrazon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkDirecto As System.Windows.Forms.CheckBox
    Friend WithEvents chkIndirecto As System.Windows.Forms.CheckBox
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtnumero As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtserie As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txttd As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtruc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtrazon As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents gridConceptos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel19 As Infragistics.Win.Misc.UltraLabel
End Class
