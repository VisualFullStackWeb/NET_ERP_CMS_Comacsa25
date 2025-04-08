<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresoBarbotina
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
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresoBarbotina))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("transaccion", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("presentacion", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("cantidad", 2)
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fecha", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("numasociado", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("observacion", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codincidencia", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("id", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Producto", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadProduccion", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codProducto", 10)
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(875)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(898)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(898)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(896)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(723)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(656)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(-7)
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Grid4 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btngrabar = New System.Windows.Forms.Button
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.Grid4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid4
        '
        Me.Grid4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance75.BackColor = System.Drawing.SystemColors.Window
        Appearance75.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid4.DisplayLayout.Appearance = Appearance75
        Me.Grid4.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance76.Image = CType(resources.GetObject("Appearance76.Image"), Object)
        Appearance76.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance76.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance76
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 32
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "Presentación"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.MaxWidth = 650
        UltraGridColumn3.MinWidth = 80
        UltraGridColumn3.Width = 196
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance6
        UltraGridColumn4.Header.Caption = "Cantidad"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.MaskInput = "{double:8.2}"
        UltraGridColumn4.MaxWidth = 70
        UltraGridColumn4.MinWidth = 70
        UltraGridColumn4.Width = 70
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.Caption = "Fecha"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.MaxWidth = 70
        UltraGridColumn5.MinWidth = 70
        UltraGridColumn5.Width = 70
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.Caption = "N° de guía"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.MaxWidth = 100
        UltraGridColumn6.MinWidth = 100
        UltraGridColumn6.Width = 100
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.Caption = "Observación"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 140
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 84
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 67
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 95
        UltraGridColumn11.Format = "#####0.00 "
        UltraGridColumn11.Header.Caption = "Cantidad Producción"
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoubleNonNegative
        UltraGridColumn11.Width = 99
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 83
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12})
        Appearance90.TextVAlignAsString = "Middle"
        UltraGridBand1.Override.RowAppearance = Appearance90
        Me.Grid4.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.Grid4.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid4.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid4.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.Grid4.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.Grid4.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.Grid4.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.Grid4.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.Grid4.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.Grid4.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.Grid4.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance91.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance91.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance91.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance91.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid4.DisplayLayout.GroupByBox.Appearance = Appearance91
        Appearance92.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid4.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance92
        Me.Grid4.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid4.DisplayLayout.GroupByBox.Hidden = True
        Appearance93.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance93.BackColor2 = System.Drawing.SystemColors.Control
        Appearance93.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance93.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid4.DisplayLayout.GroupByBox.PromptAppearance = Appearance93
        Me.Grid4.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid4.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid4.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid4.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid4.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance94.BackColor = System.Drawing.SystemColors.Window
        Me.Grid4.DisplayLayout.Override.CardAreaAppearance = Appearance94
        Appearance95.BorderColor = System.Drawing.Color.Silver
        Appearance95.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid4.DisplayLayout.Override.CellAppearance = Appearance95
        Me.Grid4.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid4.DisplayLayout.Override.CellPadding = 0
        Me.Grid4.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid4.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid4.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid4.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance96.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid4.DisplayLayout.Override.FilterRowAppearance = Appearance96
        Me.Grid4.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid4.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid4.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance97.BackColor = System.Drawing.SystemColors.Control
        Appearance97.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance97.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance97.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance97.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid4.DisplayLayout.Override.GroupByRowAppearance = Appearance97
        Appearance98.FontData.Name = "Arial Narrow"
        Appearance98.FontData.SizeInPoints = 10.0!
        Appearance98.TextHAlignAsString = "Left"
        Me.Grid4.DisplayLayout.Override.HeaderAppearance = Appearance98
        Me.Grid4.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid4.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid4.DisplayLayout.Override.MinRowHeight = 24
        Appearance99.BackColor = System.Drawing.SystemColors.Window
        Appearance99.BorderColor = System.Drawing.Color.Silver
        Me.Grid4.DisplayLayout.Override.RowAppearance = Appearance99
        Me.Grid4.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid4.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid4.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance100.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid4.DisplayLayout.Override.TemplateAddRowAppearance = Appearance100
        Me.Grid4.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid4.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid4.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid4.Location = New System.Drawing.Point(0, 0)
        Me.Grid4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grid4.Name = "Grid4"
        Me.Grid4.Size = New System.Drawing.Size(877, 407)
        Me.Grid4.TabIndex = 154
        Me.Grid4.Text = "UltraGrid1"
        '
        'btngrabar
        '
        Me.btngrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btngrabar.Location = New System.Drawing.Point(677, 427)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(188, 20)
        Me.btngrabar.TabIndex = 162
        Me.btngrabar.Text = "Guardar cambios"
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'frmIngresoBarbotina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 459)
        Me.Controls.Add(Me.btngrabar)
        Me.Controls.Add(Me.Grid4)
        Me.Name = "frmIngresoBarbotina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Producción de Barbotina"
        CType(Me.Grid4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grid4 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents btngrabar As System.Windows.Forms.Button
End Class
