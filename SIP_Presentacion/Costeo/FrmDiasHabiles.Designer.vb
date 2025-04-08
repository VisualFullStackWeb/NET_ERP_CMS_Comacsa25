<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDiasHabiles
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem13 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem14 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem15 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem16 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem17 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem18 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem19 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem20 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem21 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem22 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem23 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem24 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbMes = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.txtayo = New System.Windows.Forms.NumericUpDown
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.btnnuevod = New System.Windows.Forms.Button
        Me.txtdias = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraLabel16
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel16.Appearance = Appearance1
        Me.UltraLabel16.AutoSize = True
        Me.UltraLabel16.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel16.Location = New System.Drawing.Point(30, 55)
        Me.UltraLabel16.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(26, 17)
        Me.UltraLabel16.TabIndex = 197
        Me.UltraLabel16.Text = "Mes"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMes.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem13.DataValue = "1"
        ValueListItem13.DisplayText = "ENERO"
        ValueListItem14.DataValue = "2"
        ValueListItem14.DisplayText = "FEBRERO"
        ValueListItem15.DataValue = "3"
        ValueListItem15.DisplayText = "MARZO"
        ValueListItem16.DataValue = "4"
        ValueListItem16.DisplayText = "ABRIL"
        ValueListItem17.DataValue = "5"
        ValueListItem17.DisplayText = "MAYO"
        ValueListItem18.DataValue = "6"
        ValueListItem18.DisplayText = "JUNIO"
        ValueListItem19.DataValue = "7"
        ValueListItem19.DisplayText = "JULIO"
        ValueListItem20.DataValue = "8"
        ValueListItem20.DisplayText = "AGOSTO"
        ValueListItem21.DataValue = "9"
        ValueListItem21.DisplayText = "SETIEMBRE"
        ValueListItem22.DataValue = "10"
        ValueListItem22.DisplayText = "OCTUBRE"
        ValueListItem23.DataValue = "11"
        ValueListItem23.DisplayText = "NOVIEMBRE"
        ValueListItem24.DataValue = "12"
        ValueListItem24.DisplayText = "DICIEMBRE"
        Me.cmbMes.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem13, ValueListItem14, ValueListItem15, ValueListItem16, ValueListItem17, ValueListItem18, ValueListItem19, ValueListItem20, ValueListItem21, ValueListItem22, ValueListItem23, ValueListItem24})
        Me.cmbMes.Location = New System.Drawing.Point(64, 53)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.ReadOnly = True
        Me.cmbMes.Size = New System.Drawing.Size(126, 21)
        Me.cmbMes.TabIndex = 0
        Me.cmbMes.TabStop = False
        '
        'UltraLabel6
        '
        Appearance38.BackColor = System.Drawing.Color.Transparent
        Appearance38.TextHAlignAsString = "Center"
        Appearance38.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance38
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(30, 22)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(24, 14)
        Me.UltraLabel6.TabIndex = 195
        Me.UltraLabel6.Text = "Año"
        '
        'txtayo
        '
        Me.txtayo.Enabled = False
        Me.txtayo.Location = New System.Drawing.Point(64, 20)
        Me.txtayo.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtayo.Name = "txtayo"
        Me.txtayo.Size = New System.Drawing.Size(57, 20)
        Me.txtayo.TabIndex = 0
        Me.txtayo.TabStop = False
        Me.txtayo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtayo.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'UltraLabel1
        '
        Appearance33.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance33
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(28, 93)
        Me.UltraLabel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(27, 17)
        Me.UltraLabel1.TabIndex = 198
        Me.UltraLabel1.Text = "Dias"
        '
        'btnnuevod
        '
        Me.btnnuevod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnnuevod.Image = Global.SIP_Presentacion.My.Resources.Resources.guardar2
        Me.btnnuevod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnnuevod.Location = New System.Drawing.Point(110, 135)
        Me.btnnuevod.Name = "btnnuevod"
        Me.btnnuevod.Size = New System.Drawing.Size(80, 25)
        Me.btnnuevod.TabIndex = 202
        Me.btnnuevod.Text = "Grabar"
        Me.btnnuevod.UseVisualStyleBackColor = True
        '
        'txtdias
        '
        Appearance20.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance20.TextHAlignAsString = "Right"
        Appearance20.TextVAlignAsString = "Middle"
        Me.txtdias.Appearance = Appearance20
        Me.txtdias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdias.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtdias.Location = New System.Drawing.Point(64, 91)
        Me.txtdias.Name = "txtdias"
        Me.txtdias.Size = New System.Drawing.Size(126, 21)
        Me.txtdias.TabIndex = 1
        '
        'FrmDiasHabiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(236, 172)
        Me.Controls.Add(Me.txtdias)
        Me.Controls.Add(Me.btnnuevod)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.UltraLabel16)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.UltraLabel6)
        Me.Controls.Add(Me.txtayo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDiasHabiles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dias Habiles"
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbMes As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtayo As System.Windows.Forms.NumericUpDown
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnnuevod As System.Windows.Forms.Button
    Friend WithEvents txtdias As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
