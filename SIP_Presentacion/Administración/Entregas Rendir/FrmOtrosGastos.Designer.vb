<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOtrosGastos
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
        Dim Appearance139 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance140 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOtrosGastos))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("descripcion", 0)
        Dim Appearance153 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance154 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("importe", 1)
        Dim Appearance155 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance157 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codConcepto", 2)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(535)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(523)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(572)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(512)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance158 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance159 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance163 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance164 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance165 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance166 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance167 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance168 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance169 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance170 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.gridDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnaceptar = New System.Windows.Forms.Button
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridDetalle
        '
        Me.gridDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance139.BackColor = System.Drawing.SystemColors.Window
        Appearance139.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridDetalle.DisplayLayout.Appearance = Appearance139
        Me.gridDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance140.Image = CType(resources.GetObject("Appearance140.Image"), Object)
        Appearance140.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance140.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance140.TextHAlignAsString = "Center"
        UltraGridColumn1.Header.Appearance = Appearance140
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 25
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit
        UltraGridColumn1.Width = 25
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance153.FontData.SizeInPoints = 8.0!
        Appearance153.TextHAlignAsString = "Left"
        UltraGridColumn2.CellAppearance = Appearance153
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn2.Format = ""
        Appearance154.TextHAlignAsString = "Center"
        UltraGridColumn2.Header.Appearance = Appearance154
        UltraGridColumn2.Header.Caption = "Descripción"
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.MaskInput = ""
        UltraGridColumn2.NullText = ""
        UltraGridColumn2.Width = 302
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance155.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance155
        UltraGridColumn3.Format = "#####0.00 "
        Appearance157.TextHAlignAsString = "Center"
        UltraGridColumn3.Header.Appearance = Appearance157
        UltraGridColumn3.Header.Caption = "Importe"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.MaskInput = "{double:8.2}"
        UltraGridColumn3.MaxValue = "999999.99"
        UltraGridColumn3.MinValue = "0.00"
        UltraGridColumn3.Nullable = Infragistics.Win.UltraWinGrid.Nullable.[Nothing]
        UltraGridColumn3.NullText = ""
        UltraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoubleNonNegative
        UltraGridColumn3.Width = 139
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "Código"
        UltraGridColumn4.Header.VisiblePosition = 1
        UltraGridColumn4.Width = 56
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4})
        Me.gridDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridDetalle.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance158.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance158.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance158.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance158.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.GroupByBox.Appearance = Appearance158
        Appearance159.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance159
        Me.gridDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDetalle.DisplayLayout.GroupByBox.Hidden = True
        Appearance163.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance163.BackColor2 = System.Drawing.SystemColors.Control
        Appearance163.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance163.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance163
        Me.gridDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.gridDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance164.BackColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance164
        Appearance165.BorderColor = System.Drawing.Color.Silver
        Appearance165.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridDetalle.DisplayLayout.Override.CellAppearance = Appearance165
        Me.gridDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridDetalle.DisplayLayout.Override.CellPadding = 0
        Me.gridDetalle.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridDetalle.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance166.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridDetalle.DisplayLayout.Override.FilterRowAppearance = Appearance166
        Me.gridDetalle.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridDetalle.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance167.BackColor = System.Drawing.SystemColors.Control
        Appearance167.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance167.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance167.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance167.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance167
        Appearance168.FontData.Name = "Arial Narrow"
        Appearance168.FontData.SizeInPoints = 10.0!
        Appearance168.TextHAlignAsString = "Left"
        Me.gridDetalle.DisplayLayout.Override.HeaderAppearance = Appearance168
        Me.gridDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridDetalle.DisplayLayout.Override.MinRowHeight = 24
        Appearance169.BackColor = System.Drawing.SystemColors.Window
        Appearance169.BorderColor = System.Drawing.Color.Silver
        Appearance169.TextVAlignAsString = "Middle"
        Me.gridDetalle.DisplayLayout.Override.RowAppearance = Appearance169
        Me.gridDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridDetalle.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridDetalle.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance170.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance170
        Me.gridDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridDetalle.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDetalle.Location = New System.Drawing.Point(24, 36)
        Me.gridDetalle.Name = "gridDetalle"
        Me.gridDetalle.Size = New System.Drawing.Size(537, 274)
        Me.gridDetalle.TabIndex = 170
        Me.gridDetalle.Text = "UltraGrid1"
        '
        'btnaceptar
        '
        Me.btnaceptar.Location = New System.Drawing.Point(476, 316)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(85, 23)
        Me.btnaceptar.TabIndex = 171
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'FrmOtrosGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 349)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.gridDetalle)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOtrosGastos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmOtrosGastos"
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
End Class
