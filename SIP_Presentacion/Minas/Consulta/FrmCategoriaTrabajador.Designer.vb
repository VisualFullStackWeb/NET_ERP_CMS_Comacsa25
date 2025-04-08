<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCategoriaTrabajador
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("centroCosto", 0)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PLACOD", 1)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TRABAJADOR", 2)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDCATEGORIA", 3)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CATEGORIA", 4)
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.gridData = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cboCategoria = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txtrab = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtplacod = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnGrabar = New System.Windows.Forms.Button
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtrab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtplacod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridData
        '
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridData.DisplayLayout.Appearance = Appearance2
        UltraGridBand1.ColHeaderLines = 2
        UltraGridColumn1.Header.Caption = "CENTRO COSTO"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 180
        UltraGridColumn2.Header.Caption = "CODIGO"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 259
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 95
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 212
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.gridData.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridData.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridData.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance50.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance50.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance50.BorderColor = System.Drawing.SystemColors.Window
        Me.gridData.DisplayLayout.GroupByBox.Appearance = Appearance50
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridData.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance51
        Me.gridData.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridData.DisplayLayout.GroupByBox.Hidden = True
        Appearance52.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance52.BackColor2 = System.Drawing.SystemColors.Control
        Appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance52.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridData.DisplayLayout.GroupByBox.PromptAppearance = Appearance52
        Me.gridData.DisplayLayout.MaxColScrollRegions = 1
        Me.gridData.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridData.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridData.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridData.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Me.gridData.DisplayLayout.Override.CardAreaAppearance = Appearance53
        Appearance54.BorderColor = System.Drawing.Color.Silver
        Appearance54.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridData.DisplayLayout.Override.CellAppearance = Appearance54
        Me.gridData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridData.DisplayLayout.Override.CellPadding = 0
        Me.gridData.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridData.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridData.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridData.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance56.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance56.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridData.DisplayLayout.Override.FilterRowAppearance = Appearance56
        Me.gridData.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridData.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridData.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance57.BackColor = System.Drawing.Color.LightYellow
        Me.gridData.DisplayLayout.Override.FixedRowAppearance = Appearance57
        Me.gridData.DisplayLayout.Override.FixedRowsLimit = 10
        Me.gridData.DisplayLayout.Override.FixedRowStyle = Infragistics.Win.UltraWinGrid.FixedRowStyle.Top
        Appearance58.BackColor = System.Drawing.SystemColors.Control
        Appearance58.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance58.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance58.BorderColor = System.Drawing.SystemColors.Window
        Me.gridData.DisplayLayout.Override.GroupByRowAppearance = Appearance58
        Appearance59.FontData.Name = "Arial Narrow"
        Appearance59.FontData.SizeInPoints = 10.0!
        Appearance59.TextHAlignAsString = "Left"
        Me.gridData.DisplayLayout.Override.HeaderAppearance = Appearance59
        Me.gridData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridData.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridData.DisplayLayout.Override.MinRowHeight = 24
        Appearance60.BackColor = System.Drawing.SystemColors.Window
        Appearance60.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance60.TextVAlignAsString = "Middle"
        Me.gridData.DisplayLayout.Override.RowAppearance = Appearance60
        Me.gridData.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridData.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridData.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridData.DisplayLayout.Override.SpecialRowSeparator = Infragistics.Win.UltraWinGrid.SpecialRowSeparator.FixedRows
        Appearance70.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.gridData.DisplayLayout.Override.SpecialRowSeparatorAppearance = Appearance70
        Me.gridData.DisplayLayout.Override.SpecialRowSeparatorHeight = 10
        Me.gridData.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Appearance71.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridData.DisplayLayout.Override.TemplateAddRowAppearance = Appearance71
        Me.gridData.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridData.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridData.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridData.Location = New System.Drawing.Point(89, 44)
        Me.gridData.Name = "gridData"
        Me.gridData.Size = New System.Drawing.Size(790, 313)
        Me.gridData.TabIndex = 161
        Me.gridData.Text = "UltraGrid1"
        Me.gridData.Visible = False
        '
        'cboCategoria
        '
        Me.cboCategoria.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboCategoria.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem4.DataValue = "1"
        ValueListItem4.DisplayText = "ADMINISTRATIVO"
        ValueListItem5.DataValue = "6"
        ValueListItem5.DisplayText = "EXPLORACION - GEOLOGIA"
        ValueListItem6.DataValue = "8"
        ValueListItem6.DisplayText = "SEGURIDAD"
        ValueListItem7.DataValue = "7"
        ValueListItem7.DisplayText = "OPERACIONES"
        ValueListItem8.DataValue = "9"
        ValueListItem8.DisplayText = "MAQUINARIA PESADA"
        ValueListItem9.DataValue = "10"
        ValueListItem9.DisplayText = "MECANICOS"
        Me.cboCategoria.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7, ValueListItem8, ValueListItem9})
        Me.cboCategoria.Location = New System.Drawing.Point(185, 436)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(253, 21)
        Me.cboCategoria.TabIndex = 163
        '
        'UltraLabel2
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance3
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(96, 434)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(72, 23)
        Me.UltraLabel2.TabIndex = 162
        Me.UltraLabel2.Text = "Categoria :"
        '
        'UltraLabel1
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance4
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(96, 405)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(72, 23)
        Me.UltraLabel1.TabIndex = 164
        Me.UltraLabel1.Text = "Trabajador :"
        '
        'UltraLabel3
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance1
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(96, 376)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(72, 23)
        Me.UltraLabel3.TabIndex = 165
        Me.UltraLabel3.Text = "Código :"
        '
        'txtrab
        '
        Appearance5.TextHAlignAsString = "Left"
        Appearance5.TextVAlignAsString = "Middle"
        Me.txtrab.Appearance = Appearance5
        Me.txtrab.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrab.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtrab.Location = New System.Drawing.Point(185, 403)
        Me.txtrab.Name = "txtrab"
        Me.txtrab.ReadOnly = True
        Me.txtrab.Size = New System.Drawing.Size(253, 21)
        Me.txtrab.TabIndex = 201
        Me.txtrab.TabStop = False
        '
        'txtplacod
        '
        Appearance22.TextHAlignAsString = "Left"
        Appearance22.TextVAlignAsString = "Middle"
        Me.txtplacod.Appearance = Appearance22
        Me.txtplacod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtplacod.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtplacod.Location = New System.Drawing.Point(185, 376)
        Me.txtplacod.Name = "txtplacod"
        Me.txtplacod.ReadOnly = True
        Me.txtplacod.Size = New System.Drawing.Size(253, 21)
        Me.txtplacod.TabIndex = 202
        Me.txtplacod.TabStop = False
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(185, 470)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(253, 39)
        Me.btnGrabar.TabIndex = 203
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'FrmCategoriaTrabajador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(979, 535)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.txtplacod)
        Me.Controls.Add(Me.txtrab)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.cboCategoria)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.gridData)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCategoriaTrabajador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCategoriaTrabajador"
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtrab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtplacod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridData As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cboCategoria As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtrab As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtplacod As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
End Class
