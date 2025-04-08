<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresoReciboAgua
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance116 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem13 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.txtobservacion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtimporte = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcantidad = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtnumero = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.cmbtipodoc = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.txtserie = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.btngrabarrecibo = New System.Windows.Forms.Button
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbtipo = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        CType(Me.txtobservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtimporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbtipodoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtserie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbtipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtobservacion
        '
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.txtobservacion.Appearance = Appearance2
        Me.txtobservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobservacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtobservacion.Location = New System.Drawing.Point(94, 165)
        Me.txtobservacion.MaxLength = 100
        Me.txtobservacion.Multiline = True
        Me.txtobservacion.Name = "txtobservacion"
        Me.txtobservacion.Size = New System.Drawing.Size(297, 61)
        Me.txtobservacion.TabIndex = 224
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 231
        Me.Label2.Text = "Observacion"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(46, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 230
        Me.Label5.Text = "Importe"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 229
        Me.Label4.Text = "Cantidad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 228
        Me.Label1.Text = "Numero"
        '
        'txtimporte
        '
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtimporte.Appearance = Appearance4
        Me.txtimporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtimporte.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtimporte.Location = New System.Drawing.Point(94, 135)
        Me.txtimporte.MaxLength = 17
        Me.txtimporte.Name = "txtimporte"
        Me.txtimporte.Size = New System.Drawing.Size(152, 21)
        Me.txtimporte.TabIndex = 223
        '
        'txtcantidad
        '
        Appearance1.FontData.BoldAsString = "False"
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.txtcantidad.Appearance = Appearance1
        Me.txtcantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcantidad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcantidad.Location = New System.Drawing.Point(94, 108)
        Me.txtcantidad.MaxLength = 17
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(152, 21)
        Me.txtcantidad.TabIndex = 222
        '
        'txtnumero
        '
        Appearance5.FontData.BoldAsString = "False"
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.TextHAlignAsString = "Left"
        Appearance5.TextVAlignAsString = "Middle"
        Me.txtnumero.Appearance = Appearance5
        Me.txtnumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumero.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtnumero.Location = New System.Drawing.Point(160, 81)
        Me.txtnumero.MaxLength = 16
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(231, 21)
        Me.txtnumero.TabIndex = 221
        '
        'cmbtipodoc
        '
        Me.cmbtipodoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance100.BackColor = System.Drawing.SystemColors.Window
        Appearance100.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmbtipodoc.DisplayLayout.Appearance = Appearance100
        Me.cmbtipodoc.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmbtipodoc.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance111.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance111.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance111.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance111.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbtipodoc.DisplayLayout.GroupByBox.Appearance = Appearance111
        Appearance74.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbtipodoc.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance74
        Appearance73.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance73.BackColor2 = System.Drawing.SystemColors.Control
        Appearance73.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance73.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbtipodoc.DisplayLayout.GroupByBox.PromptAppearance = Appearance73
        Me.cmbtipodoc.DisplayLayout.MaxColScrollRegions = 1
        Me.cmbtipodoc.DisplayLayout.MaxRowScrollRegions = 1
        Appearance115.BackColor = System.Drawing.SystemColors.Highlight
        Appearance115.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmbtipodoc.DisplayLayout.Override.ActiveRowAppearance = Appearance115
        Appearance116.BackColor = System.Drawing.Color.Transparent
        Me.cmbtipodoc.DisplayLayout.Override.CardAreaAppearance = Appearance116
        Appearance117.BorderColor = System.Drawing.Color.Silver
        Appearance117.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmbtipodoc.DisplayLayout.Override.CellAppearance = Appearance117
        Me.cmbtipodoc.DisplayLayout.Override.CellPadding = 0
        Appearance118.TextHAlignAsString = "Left"
        Me.cmbtipodoc.DisplayLayout.Override.HeaderAppearance = Appearance118
        Me.cmbtipodoc.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbtipodoc.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance119.BackColor = System.Drawing.SystemColors.Window
        Appearance119.BorderColor = System.Drawing.Color.Silver
        Me.cmbtipodoc.DisplayLayout.Override.RowAppearance = Appearance119
        Appearance120.BorderColor = System.Drawing.Color.White
        Appearance120.ForeColor = System.Drawing.Color.White
        Me.cmbtipodoc.DisplayLayout.Override.RowSelectorAppearance = Appearance120
        Me.cmbtipodoc.DisplayLayout.Override.RowSpacingAfter = 4
        Me.cmbtipodoc.DisplayLayout.Override.RowSpacingBefore = 2
        Me.cmbtipodoc.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmbtipodoc.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmbtipodoc.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmbtipodoc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbtipodoc.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbtipodoc.Location = New System.Drawing.Point(94, 49)
        Me.cmbtipodoc.Name = "cmbtipodoc"
        Me.cmbtipodoc.Size = New System.Drawing.Size(152, 22)
        Me.cmbtipodoc.TabIndex = 219
        '
        'txtserie
        '
        Appearance3.FontData.BoldAsString = "False"
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.TextHAlignAsString = "Left"
        Appearance3.TextVAlignAsString = "Middle"
        Me.txtserie.Appearance = Appearance3
        Me.txtserie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtserie.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtserie.Location = New System.Drawing.Point(94, 81)
        Me.txtserie.MaxLength = 4
        Me.txtserie.Name = "txtserie"
        Me.txtserie.Size = New System.Drawing.Size(60, 21)
        Me.txtserie.TabIndex = 220
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 227
        Me.Label3.Text = "Tipo Doc."
        '
        'btngrabarrecibo
        '
        Me.btngrabarrecibo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btngrabarrecibo.Image = Global.SIP_Presentacion.My.Resources.Resources.guardar2
        Me.btngrabarrecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btngrabarrecibo.Location = New System.Drawing.Point(311, 241)
        Me.btngrabarrecibo.Name = "btngrabarrecibo"
        Me.btngrabarrecibo.Size = New System.Drawing.Size(80, 25)
        Me.btngrabarrecibo.TabIndex = 225
        Me.btngrabarrecibo.Text = "Grabar"
        Me.btngrabarrecibo.UseVisualStyleBackColor = True
        '
        'UltraLabel16
        '
        Appearance33.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel16.Appearance = Appearance33
        Me.UltraLabel16.AutoSize = True
        Me.UltraLabel16.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel16.Location = New System.Drawing.Point(62, 22)
        Me.UltraLabel16.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(26, 17)
        Me.UltraLabel16.TabIndex = 226
        Me.UltraLabel16.Text = "Tipo"
        '
        'cmbtipo
        '
        Me.cmbtipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbtipo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbtipo.Enabled = False
        ValueListItem13.DataValue = "A"
        ValueListItem13.DisplayText = "AGUA"
        Me.cmbtipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem13})
        Me.cmbtipo.Location = New System.Drawing.Point(94, 20)
        Me.cmbtipo.Name = "cmbtipo"
        Me.cmbtipo.Size = New System.Drawing.Size(152, 21)
        Me.cmbtipo.TabIndex = 218
        '
        'FrmIngresoReciboAgua
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 287)
        Me.Controls.Add(Me.txtobservacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtimporte)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.txtnumero)
        Me.Controls.Add(Me.cmbtipodoc)
        Me.Controls.Add(Me.txtserie)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btngrabarrecibo)
        Me.Controls.Add(Me.UltraLabel16)
        Me.Controls.Add(Me.cmbtipo)
        Me.Name = "FrmIngresoReciboAgua"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmIngresoReciboAgua"
        CType(Me.txtobservacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtimporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbtipodoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtserie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbtipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtobservacion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtimporte As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcantidad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtnumero As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cmbtipodoc As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtserie As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btngrabarrecibo As System.Windows.Forms.Button
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbtipo As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
