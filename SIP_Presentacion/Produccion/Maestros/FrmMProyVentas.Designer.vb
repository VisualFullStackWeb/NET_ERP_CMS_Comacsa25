<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMProyVentas
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
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance162 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMProyVentas))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodProducto", 0)
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 2)
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Update", 3)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(640)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(612)
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Grid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Navigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.StripLbl1 = New System.Windows.Forms.ToolStripLabel
        Me.Separator7 = New System.Windows.Forms.ToolStripSeparator
        Me.StripBtn4 = New System.Windows.Forms.ToolStripButton
        Me.StripBtn3 = New System.Windows.Forms.ToolStripButton
        Me.Separator6 = New System.Windows.Forms.ToolStripSeparator
        Me.StripTxt1 = New System.Windows.Forms.ToolStripTextBox
        Me.Separator5 = New System.Windows.Forms.ToolStripSeparator
        Me.StripBtn2 = New System.Windows.Forms.ToolStripButton
        Me.StripBtn1 = New System.Windows.Forms.ToolStripButton
        Me.Separator4 = New System.Windows.Forms.ToolStripSeparator
        Me.StripLbl5 = New System.Windows.Forms.ToolStripLabel
        Me.Separator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.Cbo1 = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.Cbo2 = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Navigator1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance156.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance156
        Me.UltraGroupBox1.Controls.Add(Me.Grid1)
        Me.UltraGroupBox1.Controls.Add(Me.Navigator1)
        Appearance162.FontData.BoldAsString = "True"
        Appearance162.FontData.Name = "Arial Narrow"
        Appearance162.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox1.HeaderAppearance = Appearance162
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 13)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(648, 407)
        Me.UltraGroupBox1.TabIndex = 1
        Me.UltraGroupBox1.Text = "PROYECCIONES MENSUALES"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Grid1
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid1.DisplayLayout.Appearance = Appearance1
        Me.Grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn1.Format = ""
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance2
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 25
        UltraGridColumn1.Width = 25
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn2.Header.Appearance = Appearance4
        UltraGridColumn2.Header.Caption = "Codigo"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.MaxWidth = 90
        UltraGridColumn2.MinWidth = 90
        UltraGridColumn2.Width = 90
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.MinWidth = 200
        UltraGridColumn3.Width = 422
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance5
        UltraGridColumn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn4.DataType = GetType(Decimal)
        UltraGridColumn4.Format = "n2"
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn4.Header.Appearance = Appearance6
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.MaskInput = ""
        UltraGridColumn4.MaxWidth = 90
        UltraGridColumn4.MinWidth = 90
        UltraGridColumn4.NullText = "0"
        UltraGridColumn4.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        UltraGridColumn4.Width = 90
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.DataType = GetType(Boolean)
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 71
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.Grid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.Grid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.Grid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.GroupByBox.Appearance = Appearance7
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
        Me.Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance9.BackColor2 = System.Drawing.SystemColors.Control
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
        Me.Grid1.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid1.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid1.DisplayLayout.Override.CellAppearance = Appearance11
        Me.Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid1.DisplayLayout.Override.CellPadding = 0
        Me.Grid1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid1.DisplayLayout.Override.FilterRowAppearance = Appearance12
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance13.BackColor = System.Drawing.SystemColors.Control
        Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.GroupByRowAppearance = Appearance13
        Appearance14.FontData.Name = "Arial Narrow"
        Appearance14.FontData.SizeInPoints = 10.0!
        Appearance14.TextHAlignAsString = "Left"
        Me.Grid1.DisplayLayout.Override.HeaderAppearance = Appearance14
        Me.Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid1.DisplayLayout.Override.MinRowHeight = 24
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextVAlignAsString = "Middle"
        Me.Grid1.DisplayLayout.Override.RowAppearance = Appearance15
        Me.Grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.Location = New System.Drawing.Point(3, 48)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(642, 356)
        Me.Grid1.TabIndex = 147
        Me.Grid1.Text = "UltraGrid1"
        '
        'Navigator1
        '
        Me.Navigator1.AddNewItem = Nothing
        Me.Navigator1.BackColor = System.Drawing.SystemColors.Control
        Me.Navigator1.BindingSource = Me.Source1
        Me.Navigator1.CountItem = Me.StripLbl1
        Me.Navigator1.DeleteItem = Nothing
        Me.Navigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Navigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Separator7, Me.StripBtn4, Me.StripBtn3, Me.Separator6, Me.StripLbl1, Me.StripTxt1, Me.Separator5, Me.StripBtn2, Me.StripBtn1, Me.Separator4, Me.StripLbl5, Me.Separator1, Me.ToolStripLabel1, Me.Cbo1, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.Cbo2, Me.ToolStripSeparator2})
        Me.Navigator1.Location = New System.Drawing.Point(3, 23)
        Me.Navigator1.MoveFirstItem = Me.StripBtn1
        Me.Navigator1.MoveLastItem = Me.StripBtn4
        Me.Navigator1.MoveNextItem = Me.StripBtn3
        Me.Navigator1.MovePreviousItem = Me.StripBtn2
        Me.Navigator1.Name = "Navigator1"
        Me.Navigator1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.Navigator1.PositionItem = Me.StripTxt1
        Me.Navigator1.Size = New System.Drawing.Size(642, 25)
        Me.Navigator1.TabIndex = 146
        Me.Navigator1.Text = "BindingNavigator1"
        '
        'StripLbl1
        '
        Me.StripLbl1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripLbl1.Name = "StripLbl1"
        Me.StripLbl1.Size = New System.Drawing.Size(37, 22)
        Me.StripLbl1.Text = "de {0}"
        Me.StripLbl1.ToolTipText = "Número total de elementos"
        '
        'Separator7
        '
        Me.Separator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator7.Name = "Separator7"
        Me.Separator7.Size = New System.Drawing.Size(6, 25)
        '
        'StripBtn4
        '
        Me.StripBtn4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn4.Image = CType(resources.GetObject("StripBtn4.Image"), System.Drawing.Image)
        Me.StripBtn4.Name = "StripBtn4"
        Me.StripBtn4.RightToLeftAutoMirrorImage = True
        Me.StripBtn4.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn4.Text = "Mover último"
        '
        'StripBtn3
        '
        Me.StripBtn3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn3.Image = CType(resources.GetObject("StripBtn3.Image"), System.Drawing.Image)
        Me.StripBtn3.Name = "StripBtn3"
        Me.StripBtn3.RightToLeftAutoMirrorImage = True
        Me.StripBtn3.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn3.Text = "Mover siguiente"
        '
        'Separator6
        '
        Me.Separator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator6.Name = "Separator6"
        Me.Separator6.Size = New System.Drawing.Size(6, 25)
        '
        'StripTxt1
        '
        Me.StripTxt1.AccessibleName = "Posición"
        Me.StripTxt1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripTxt1.AutoSize = False
        Me.StripTxt1.BackColor = System.Drawing.Color.White
        Me.StripTxt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StripTxt1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.StripTxt1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StripTxt1.Name = "StripTxt1"
        Me.StripTxt1.Size = New System.Drawing.Size(50, 23)
        Me.StripTxt1.Text = "0"
        Me.StripTxt1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.StripTxt1.ToolTipText = "Posición actual"
        '
        'Separator5
        '
        Me.Separator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator5.Name = "Separator5"
        Me.Separator5.Size = New System.Drawing.Size(6, 25)
        '
        'StripBtn2
        '
        Me.StripBtn2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn2.Image = CType(resources.GetObject("StripBtn2.Image"), System.Drawing.Image)
        Me.StripBtn2.Name = "StripBtn2"
        Me.StripBtn2.RightToLeftAutoMirrorImage = True
        Me.StripBtn2.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn2.Text = "Mover anterior"
        '
        'StripBtn1
        '
        Me.StripBtn1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn1.Image = CType(resources.GetObject("StripBtn1.Image"), System.Drawing.Image)
        Me.StripBtn1.Name = "StripBtn1"
        Me.StripBtn1.RightToLeftAutoMirrorImage = True
        Me.StripBtn1.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn1.Text = "Mover primero"
        '
        'Separator4
        '
        Me.Separator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator4.Name = "Separator4"
        Me.Separator4.Size = New System.Drawing.Size(6, 25)
        '
        'StripLbl5
        '
        Me.StripLbl5.Name = "StripLbl5"
        Me.StripLbl5.Size = New System.Drawing.Size(40, 22)
        Me.StripLbl5.Text = "           "
        '
        'Separator1
        '
        Me.Separator1.Name = "Separator1"
        Me.Separator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel1.Text = "Año :"
        '
        'Cbo1
        '
        Me.Cbo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo1.Items.AddRange(New Object() {"2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Cbo1.Name = "Cbo1"
        Me.Cbo1.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel2.Text = "Mes :"
        '
        'Cbo2
        '
        Me.Cbo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo2.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.Cbo2.Name = "Cbo2"
        Me.Cbo2.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'FrmMProyVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(672, 433)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmMProyVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "M06"
        Me.Text = "Proyecciones de Ventas"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Navigator1.ResumeLayout(False)
        Me.Navigator1.PerformLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Grid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Navigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents StripLbl1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Separator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StripBtn4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StripBtn3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StripTxt1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Separator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StripBtn2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StripBtn1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StripLbl5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Separator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Cbo1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Cbo2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
