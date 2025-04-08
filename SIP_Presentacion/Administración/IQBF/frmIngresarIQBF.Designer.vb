<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresarIQBF
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
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance141 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance142 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance143 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance144 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance145 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance146 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance147 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance148 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.Txtobservacion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.dtFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.cmbPresentacion = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.rdbNacional = New System.Windows.Forms.RadioButton
        Me.rdbExterior = New System.Windows.Forms.RadioButton
        Me.rdbRecirculado = New System.Windows.Forms.RadioButton
        Me.rdbEgreso = New System.Windows.Forms.RadioButton
        Me.rdbProduccion = New System.Windows.Forms.RadioButton
        CType(Me.Txtobservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPresentacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(327, 244)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(89, 20)
        Me.btnAceptar.TabIndex = 19
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Txtobservacion
        '
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.TextHAlignAsString = "Left"
        Appearance12.TextVAlignAsString = "Middle"
        Me.Txtobservacion.Appearance = Appearance12
        Me.Txtobservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtobservacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txtobservacion.Location = New System.Drawing.Point(27, 168)
        Me.Txtobservacion.MaxLength = 150
        Me.Txtobservacion.Multiline = True
        Me.Txtobservacion.Name = "Txtobservacion"
        Me.Txtobservacion.Size = New System.Drawing.Size(389, 64)
        Me.Txtobservacion.TabIndex = 0
        Me.Txtobservacion.TabStop = False
        '
        'UltraLabel18
        '
        Appearance21.BackColor = System.Drawing.Color.Transparent
        Appearance21.TextHAlignAsString = "Center"
        Appearance21.TextVAlignAsString = "Middle"
        Me.UltraLabel18.Appearance = Appearance21
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Location = New System.Drawing.Point(30, 151)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(68, 14)
        Me.UltraLabel18.TabIndex = 20
        Me.UltraLabel18.Text = "Observación"
        '
        'UltraLabel3
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance1
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(30, 96)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(36, 14)
        Me.UltraLabel3.TabIndex = 212
        Me.UltraLabel3.Text = "Fecha"
        '
        'dtFecha
        '
        Me.dtFecha.AutoSize = False
        Me.dtFecha.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFecha.Location = New System.Drawing.Point(27, 113)
        Me.dtFecha.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtFecha.Size = New System.Drawing.Size(119, 21)
        Me.dtFecha.TabIndex = 211
        Me.dtFecha.TabStop = False
        Me.dtFecha.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'cmbPresentacion
        '
        Me.cmbPresentacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance141.BackColor = System.Drawing.SystemColors.Window
        Appearance141.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmbPresentacion.DisplayLayout.Appearance = Appearance141
        Me.cmbPresentacion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmbPresentacion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance142.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance142.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance142.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance142.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbPresentacion.DisplayLayout.GroupByBox.Appearance = Appearance142
        Appearance143.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbPresentacion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance143
        Appearance144.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance144.BackColor2 = System.Drawing.SystemColors.Control
        Appearance144.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance144.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbPresentacion.DisplayLayout.GroupByBox.PromptAppearance = Appearance144
        Me.cmbPresentacion.DisplayLayout.MaxColScrollRegions = 1
        Me.cmbPresentacion.DisplayLayout.MaxRowScrollRegions = 1
        Appearance145.BackColor = System.Drawing.SystemColors.Highlight
        Appearance145.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmbPresentacion.DisplayLayout.Override.ActiveRowAppearance = Appearance145
        Appearance146.BackColor = System.Drawing.Color.Transparent
        Me.cmbPresentacion.DisplayLayout.Override.CardAreaAppearance = Appearance146
        Appearance147.BorderColor = System.Drawing.Color.Silver
        Appearance147.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmbPresentacion.DisplayLayout.Override.CellAppearance = Appearance147
        Me.cmbPresentacion.DisplayLayout.Override.CellPadding = 0
        Appearance148.TextHAlignAsString = "Left"
        Me.cmbPresentacion.DisplayLayout.Override.HeaderAppearance = Appearance148
        Me.cmbPresentacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbPresentacion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Appearance4.BorderColor = System.Drawing.Color.Silver
        Me.cmbPresentacion.DisplayLayout.Override.RowAppearance = Appearance4
        Appearance5.BorderColor = System.Drawing.Color.White
        Appearance5.ForeColor = System.Drawing.Color.White
        Me.cmbPresentacion.DisplayLayout.Override.RowSelectorAppearance = Appearance5
        Me.cmbPresentacion.DisplayLayout.Override.RowSpacingAfter = 4
        Me.cmbPresentacion.DisplayLayout.Override.RowSpacingBefore = 2
        Me.cmbPresentacion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmbPresentacion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmbPresentacion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmbPresentacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbPresentacion.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbPresentacion.Location = New System.Drawing.Point(27, 63)
        Me.cmbPresentacion.Name = "cmbPresentacion"
        Me.cmbPresentacion.Size = New System.Drawing.Size(389, 22)
        Me.cmbPresentacion.TabIndex = 213
        Me.cmbPresentacion.TabStop = False
        '
        'UltraLabel1
        '
        Appearance83.BackColor = System.Drawing.Color.Transparent
        Appearance83.TextHAlignAsString = "Center"
        Appearance83.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance83
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(30, 46)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(70, 14)
        Me.UltraLabel1.TabIndex = 214
        Me.UltraLabel1.Text = "Presentación"
        '
        'rdbNacional
        '
        Me.rdbNacional.AutoSize = True
        Me.rdbNacional.Location = New System.Drawing.Point(175, 116)
        Me.rdbNacional.Name = "rdbNacional"
        Me.rdbNacional.Size = New System.Drawing.Size(67, 17)
        Me.rdbNacional.TabIndex = 215
        Me.rdbNacional.TabStop = True
        Me.rdbNacional.Text = "Nacional"
        Me.rdbNacional.UseVisualStyleBackColor = True
        '
        'rdbExterior
        '
        Me.rdbExterior.AutoSize = True
        Me.rdbExterior.Location = New System.Drawing.Point(250, 116)
        Me.rdbExterior.Name = "rdbExterior"
        Me.rdbExterior.Size = New System.Drawing.Size(60, 17)
        Me.rdbExterior.TabIndex = 216
        Me.rdbExterior.TabStop = True
        Me.rdbExterior.Text = "Exterior"
        Me.rdbExterior.UseVisualStyleBackColor = True
        '
        'rdbRecirculado
        '
        Me.rdbRecirculado.AutoSize = True
        Me.rdbRecirculado.Location = New System.Drawing.Point(239, 117)
        Me.rdbRecirculado.Name = "rdbRecirculado"
        Me.rdbRecirculado.Size = New System.Drawing.Size(82, 17)
        Me.rdbRecirculado.TabIndex = 218
        Me.rdbRecirculado.TabStop = True
        Me.rdbRecirculado.Text = "Recirculado"
        Me.rdbRecirculado.UseVisualStyleBackColor = True
        Me.rdbRecirculado.Visible = False
        '
        'rdbEgreso
        '
        Me.rdbEgreso.AutoSize = True
        Me.rdbEgreso.Location = New System.Drawing.Point(175, 117)
        Me.rdbEgreso.Name = "rdbEgreso"
        Me.rdbEgreso.Size = New System.Drawing.Size(58, 17)
        Me.rdbEgreso.TabIndex = 217
        Me.rdbEgreso.TabStop = True
        Me.rdbEgreso.Text = "Egreso"
        Me.rdbEgreso.UseVisualStyleBackColor = True
        Me.rdbEgreso.Visible = False
        '
        'rdbProduccion
        '
        Me.rdbProduccion.AutoSize = True
        Me.rdbProduccion.Location = New System.Drawing.Point(327, 117)
        Me.rdbProduccion.Name = "rdbProduccion"
        Me.rdbProduccion.Size = New System.Drawing.Size(79, 17)
        Me.rdbProduccion.TabIndex = 219
        Me.rdbProduccion.TabStop = True
        Me.rdbProduccion.Text = "Producción"
        Me.rdbProduccion.UseVisualStyleBackColor = True
        Me.rdbProduccion.Visible = False
        '
        'frmIngresarIQBF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 282)
        Me.Controls.Add(Me.rdbProduccion)
        Me.Controls.Add(Me.rdbRecirculado)
        Me.Controls.Add(Me.rdbEgreso)
        Me.Controls.Add(Me.rdbExterior)
        Me.Controls.Add(Me.rdbNacional)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.cmbPresentacion)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Txtobservacion)
        Me.Controls.Add(Me.UltraLabel18)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIngresarIQBF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmIngresarIQBF"
        CType(Me.Txtobservacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPresentacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Txtobservacion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cmbPresentacion As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents rdbNacional As System.Windows.Forms.RadioButton
    Friend WithEvents rdbExterior As System.Windows.Forms.RadioButton
    Friend WithEvents rdbRecirculado As System.Windows.Forms.RadioButton
    Friend WithEvents rdbEgreso As System.Windows.Forms.RadioButton
    Friend WithEvents rdbProduccion As System.Windows.Forms.RadioButton
End Class
