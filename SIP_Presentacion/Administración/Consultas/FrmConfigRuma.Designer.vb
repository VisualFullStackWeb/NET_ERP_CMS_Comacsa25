<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigRuma
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
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SEL")
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_ALM", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ALMACEN", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_RUMA", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUMA", 3)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(544)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(544)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(182)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.gridRuma = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnguardar = New System.Windows.Forms.Button
        Me.lblid = New Infragistics.Win.Misc.UltraLabel
        Me.lbldescrip = New Infragistics.Win.Misc.UltraLabel
        Me.lblmesini = New Infragistics.Win.Misc.UltraLabel
        Me.lblmesfin = New Infragistics.Win.Misc.UltraLabel
        CType(Me.gridRuma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridRuma
        '
        Me.gridRuma.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridRuma.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance36.BackColor = System.Drawing.SystemColors.Window
        Appearance36.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridRuma.DisplayLayout.Appearance = Appearance36
        Me.gridRuma.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance37.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance37.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance37
        UltraGridColumn1.Header.Caption = " "
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 25
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 25
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 101
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 156
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "CODIGO"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 106
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 223
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.gridRuma.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridRuma.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridRuma.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridRuma.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance38.BorderColor = System.Drawing.SystemColors.Window
        Me.gridRuma.DisplayLayout.GroupByBox.Appearance = Appearance38
        Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridRuma.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance39
        Me.gridRuma.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridRuma.DisplayLayout.GroupByBox.Hidden = True
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance40.BackColor2 = System.Drawing.SystemColors.Control
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridRuma.DisplayLayout.GroupByBox.PromptAppearance = Appearance40
        Me.gridRuma.DisplayLayout.MaxColScrollRegions = 1
        Me.gridRuma.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridRuma.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridRuma.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridRuma.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Me.gridRuma.DisplayLayout.Override.CardAreaAppearance = Appearance41
        Appearance42.BorderColor = System.Drawing.Color.Silver
        Appearance42.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridRuma.DisplayLayout.Override.CellAppearance = Appearance42
        Me.gridRuma.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridRuma.DisplayLayout.Override.CellPadding = 0
        Me.gridRuma.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridRuma.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridRuma.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridRuma.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance44.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridRuma.DisplayLayout.Override.FilterRowAppearance = Appearance44
        Me.gridRuma.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridRuma.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridRuma.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance45.BackColor = System.Drawing.SystemColors.Control
        Appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance45.BorderColor = System.Drawing.SystemColors.Window
        Me.gridRuma.DisplayLayout.Override.GroupByRowAppearance = Appearance45
        Appearance46.FontData.Name = "Arial Narrow"
        Appearance46.FontData.SizeInPoints = 10.0!
        Appearance46.TextHAlignAsString = "Left"
        Me.gridRuma.DisplayLayout.Override.HeaderAppearance = Appearance46
        Me.gridRuma.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridRuma.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridRuma.DisplayLayout.Override.MinRowHeight = 24
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.BorderColor = System.Drawing.Color.Silver
        Appearance53.TextVAlignAsString = "Middle"
        Me.gridRuma.DisplayLayout.Override.RowAppearance = Appearance53
        Me.gridRuma.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridRuma.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridRuma.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance54.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridRuma.DisplayLayout.Override.TemplateAddRowAppearance = Appearance54
        Me.gridRuma.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridRuma.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridRuma.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridRuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridRuma.Location = New System.Drawing.Point(56, 76)
        Me.gridRuma.Name = "gridRuma"
        Me.gridRuma.Size = New System.Drawing.Size(546, 306)
        Me.gridRuma.TabIndex = 176
        Me.gridRuma.Text = "UltraGrid1"
        '
        'btnguardar
        '
        Me.btnguardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnguardar.Image = Global.SIP_Presentacion.My.Resources.Resources.guardar2
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnguardar.Location = New System.Drawing.Point(527, 401)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(75, 23)
        Me.btnguardar.TabIndex = 177
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'lblid
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        Me.lblid.Appearance = Appearance4
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(12, 22)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(0, 0)
        Me.lblid.TabIndex = 192
        Me.lblid.Visible = False
        '
        'lbldescrip
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance5.TextHAlignAsString = "Left"
        Appearance5.TextVAlignAsString = "Middle"
        Me.lbldescrip.Appearance = Appearance5
        Me.lbldescrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldescrip.Location = New System.Drawing.Point(56, 22)
        Me.lbldescrip.Name = "lbldescrip"
        Me.lbldescrip.Size = New System.Drawing.Size(181, 14)
        Me.lbldescrip.TabIndex = 193
        Me.lbldescrip.Text = "Descripción"
        '
        'lblmesini
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Center"
        Appearance6.TextVAlignAsString = "Middle"
        Me.lblmesini.Appearance = Appearance6
        Me.lblmesini.AutoSize = True
        Me.lblmesini.Location = New System.Drawing.Point(233, 22)
        Me.lblmesini.Name = "lblmesini"
        Me.lblmesini.Size = New System.Drawing.Size(47, 14)
        Me.lblmesini.TabIndex = 194
        Me.lblmesini.Text = "Mes min"
        '
        'lblmesfin
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.lblmesfin.Appearance = Appearance3
        Me.lblmesfin.AutoSize = True
        Me.lblmesfin.Location = New System.Drawing.Point(272, 22)
        Me.lblmesfin.Name = "lblmesfin"
        Me.lblmesfin.Size = New System.Drawing.Size(50, 14)
        Me.lblmesfin.TabIndex = 195
        Me.lblmesfin.Text = "Mes máx"
        '
        'FrmConfigRuma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(659, 447)
        Me.Controls.Add(Me.lblmesfin)
        Me.Controls.Add(Me.lblmesini)
        Me.Controls.Add(Me.lbldescrip)
        Me.Controls.Add(Me.lblid)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.gridRuma)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConfigRuma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmConfigRuma"
        CType(Me.gridRuma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents gridRuma As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblid As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbldescrip As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblmesini As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblmesfin As Infragistics.Win.Misc.UltraLabel
End Class
