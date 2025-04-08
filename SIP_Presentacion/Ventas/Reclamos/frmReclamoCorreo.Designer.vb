<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReclamoCorreo
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
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReclamoCorreo))
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Correo")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Area")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ELIMINAR", 0)
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ScrollBarLook1 As Infragistics.Win.UltraWinScrollBar.ScrollBarLook = New Infragistics.Win.UltraWinScrollBar.ScrollBarLook
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.ugCorreos = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        CType(Me.ugCorreos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugCorreos
        '
        Appearance28.BackColor = System.Drawing.Color.White
        Appearance28.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer))
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.ugCorreos.DisplayLayout.AddNewBox.Appearance = Appearance28
        Me.ugCorreos.DisplayLayout.AddNewBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Appearance29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance29.ImageBackground = CType(resources.GetObject("Appearance29.ImageBackground"), System.Drawing.Image)
        Appearance29.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Appearance29.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3)
        Appearance29.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        Me.ugCorreos.DisplayLayout.AddNewBox.ButtonAppearance = Appearance29
        Me.ugCorreos.DisplayLayout.AddNewBox.ButtonConnectorColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.ugCorreos.DisplayLayout.AddNewBox.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Appearance30.BackColor = System.Drawing.Color.White
        Me.ugCorreos.DisplayLayout.Appearance = Appearance30
        Me.ugCorreos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.Header.Caption = "DESTINATARIO"
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.Header.Caption = "CORREO"
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance55.Image = Global.SIP_Presentacion.My.Resources.Resources.cancel
        UltraGridColumn5.CellButtonAppearance = Appearance55
        UltraGridColumn5.Header.Caption = ""
        UltraGridColumn5.Header.VisiblePosition = 0
        UltraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn5.Width = 18
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.ugCorreos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugCorreos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance31.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance31.FontData.Name = "Trebuchet MS"
        Appearance31.FontData.SizeInPoints = 9.0!
        Appearance31.ForeColor = System.Drawing.Color.White
        Appearance31.TextHAlignAsString = "Right"
        Me.ugCorreos.DisplayLayout.CaptionAppearance = Appearance31
        Me.ugCorreos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugCorreos.DisplayLayout.FixedHeaderOffImage = CType(resources.GetObject("ugCorreos.DisplayLayout.FixedHeaderOffImage"), System.Drawing.Image)
        Me.ugCorreos.DisplayLayout.FixedHeaderOnImage = CType(resources.GetObject("ugCorreos.DisplayLayout.FixedHeaderOnImage"), System.Drawing.Image)
        Me.ugCorreos.DisplayLayout.FixedRowOffImage = CType(resources.GetObject("ugCorreos.DisplayLayout.FixedRowOffImage"), System.Drawing.Image)
        Me.ugCorreos.DisplayLayout.FixedRowOnImage = CType(resources.GetObject("ugCorreos.DisplayLayout.FixedRowOnImage"), System.Drawing.Image)
        Appearance32.FontData.BoldAsString = "True"
        Appearance32.FontData.Name = "Trebuchet MS"
        Appearance32.FontData.SizeInPoints = 10.0!
        Appearance32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(177, Byte), Integer))
        Appearance32.ImageBackground = CType(resources.GetObject("Appearance32.ImageBackground"), System.Drawing.Image)
        Appearance32.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(0, 2, 0, 3)
        Appearance32.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        Me.ugCorreos.DisplayLayout.GroupByBox.Appearance = Appearance32
        Appearance33.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCorreos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance33
        Me.ugCorreos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugCorreos.DisplayLayout.GroupByBox.ButtonBorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Appearance34.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance34.BackColor2 = System.Drawing.SystemColors.Control
        Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance34.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCorreos.DisplayLayout.GroupByBox.PromptAppearance = Appearance34
        Me.ugCorreos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugCorreos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugCorreos.DisplayLayout.Override.ActiveCellAppearance = Appearance35
        Appearance36.BackColor = System.Drawing.SystemColors.Highlight
        Appearance36.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugCorreos.DisplayLayout.Override.ActiveRowAppearance = Appearance36
        Me.ugCorreos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.FixedAddRowOnTop
        Me.ugCorreos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugCorreos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugCorreos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None
        Me.ugCorreos.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None
        Me.ugCorreos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
        Me.ugCorreos.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Appearance37.BackColor = System.Drawing.Color.Transparent
        Me.ugCorreos.DisplayLayout.Override.CardAreaAppearance = Appearance37
        Appearance38.BorderColor = System.Drawing.Color.Transparent
        Appearance38.FontData.Name = "Verdana"
        Me.ugCorreos.DisplayLayout.Override.CellAppearance = Appearance38
        Appearance39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance39.ImageBackground = CType(resources.GetObject("Appearance39.ImageBackground"), System.Drawing.Image)
        Appearance39.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3)
        Appearance39.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        Me.ugCorreos.DisplayLayout.Override.CellButtonAppearance = Appearance39
        Me.ugCorreos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugCorreos.DisplayLayout.Override.CellPadding = 0
        Appearance40.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ugCorreos.DisplayLayout.Override.FilterCellAppearance = Appearance40
        Appearance41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance41.ImageBackground = CType(resources.GetObject("Appearance41.ImageBackground"), System.Drawing.Image)
        Appearance41.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3)
        Me.ugCorreos.DisplayLayout.Override.FilterClearButtonAppearance = Appearance41
        Appearance42.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Appearance42.BackColorAlpha = Infragistics.Win.Alpha.Opaque
        Me.ugCorreos.DisplayLayout.Override.FilterRowPromptAppearance = Appearance42
        Appearance43.BackColor = System.Drawing.SystemColors.Control
        Appearance43.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance43.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance43.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCorreos.DisplayLayout.Override.GroupByRowAppearance = Appearance43
        Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Appearance44.FontData.BoldAsString = "True"
        Appearance44.FontData.Name = "Trebuchet MS"
        Appearance44.FontData.SizeInPoints = 10.0!
        Appearance44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance44.ImageBackground = CType(resources.GetObject("Appearance44.ImageBackground"), System.Drawing.Image)
        Appearance44.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled
        Appearance44.TextHAlignAsString = "Left"
        Appearance44.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugCorreos.DisplayLayout.Override.HeaderAppearance = Appearance44
        Me.ugCorreos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugCorreos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed
        Appearance45.BorderColor = System.Drawing.Color.Transparent
        Me.ugCorreos.DisplayLayout.Override.RowAppearance = Appearance45
        Appearance46.BackColor = System.Drawing.Color.White
        Me.ugCorreos.DisplayLayout.Override.RowSelectorAppearance = Appearance46
        Me.ugCorreos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance47.BorderColor = System.Drawing.Color.Transparent
        Appearance47.ForeColor = System.Drawing.Color.Black
        Me.ugCorreos.DisplayLayout.Override.SelectedCellAppearance = Appearance47
        Appearance48.BorderColor = System.Drawing.Color.Transparent
        Appearance48.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance48.ImageBackground = CType(resources.GetObject("Appearance48.ImageBackground"), System.Drawing.Image)
        Appearance48.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(1, 1, 1, 4)
        Appearance48.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        Me.ugCorreos.DisplayLayout.Override.SelectedRowAppearance = Appearance48
        Appearance49.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugCorreos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance49
        Appearance50.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(2, 4, 2, 4)
        Appearance50.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        ScrollBarLook1.Appearance = Appearance50
        Appearance51.ImageBackground = CType(resources.GetObject("Appearance51.ImageBackground"), System.Drawing.Image)
        Appearance51.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(3, 2, 3, 2)
        ScrollBarLook1.AppearanceHorizontal = Appearance51
        Appearance52.ImageBackground = CType(resources.GetObject("Appearance52.ImageBackground"), System.Drawing.Image)
        Appearance52.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(2, 3, 2, 3)
        Appearance52.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        ScrollBarLook1.AppearanceVertical = Appearance52
        Appearance53.ImageBackground = CType(resources.GetObject("Appearance53.ImageBackground"), System.Drawing.Image)
        Appearance53.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(0, 2, 0, 1)
        ScrollBarLook1.TrackAppearanceHorizontal = Appearance53
        Appearance54.ImageBackground = CType(resources.GetObject("Appearance54.ImageBackground"), System.Drawing.Image)
        Appearance54.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(2, 0, 1, 0)
        Appearance54.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        ScrollBarLook1.TrackAppearanceVertical = Appearance54
        Me.ugCorreos.DisplayLayout.ScrollBarLook = ScrollBarLook1
        Me.ugCorreos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugCorreos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ugCorreos.Location = New System.Drawing.Point(2, 3)
        Me.ugCorreos.Name = "ugCorreos"
        Me.ugCorreos.Size = New System.Drawing.Size(534, 196)
        Me.ugCorreos.TabIndex = 0
        Me.ugCorreos.Text = "Grid Caption Area"
        Me.ugCorreos.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIP_Presentacion.My.Resources.Resources.guardar2
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(385, 205)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 35)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIP_Presentacion.My.Resources.Resources.cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(460, 205)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(76, 35)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmReclamoCorreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 243)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.ugCorreos)
        Me.Name = "frmReclamoCorreo"
        Me.Text = "Destinatarios"
        CType(Me.ugCorreos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugCorreos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
