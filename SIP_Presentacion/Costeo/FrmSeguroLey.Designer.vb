<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeguroLey
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
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.btnnuevod = New System.Windows.Forms.Button
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbMes = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.txtayo = New System.Windows.Forms.NumericUpDown
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.TxtCodigoTrabajador = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.TxtNombresTrabajador = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtseguro = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodigoTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNombresTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtseguro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnnuevod
        '
        Me.btnnuevod.Image = Global.SIP_Presentacion.My.Resources.Resources.guardar2
        Me.btnnuevod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnnuevod.Location = New System.Drawing.Point(135, 194)
        Me.btnnuevod.Name = "btnnuevod"
        Me.btnnuevod.Size = New System.Drawing.Size(80, 25)
        Me.btnnuevod.TabIndex = 209
        Me.btnnuevod.Text = "Grabar"
        Me.btnnuevod.UseVisualStyleBackColor = True
        '
        'UltraLabel1
        '
        Appearance33.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance33
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(9, 158)
        Me.UltraLabel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(72, 17)
        Me.UltraLabel1.TabIndex = 208
        Me.UltraLabel1.Text = "Monto seguro"
        '
        'UltraLabel16
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel16.Appearance = Appearance1
        Me.UltraLabel16.AutoSize = True
        Me.UltraLabel16.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel16.Location = New System.Drawing.Point(55, 56)
        Me.UltraLabel16.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(26, 17)
        Me.UltraLabel16.TabIndex = 207
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
        Me.cmbMes.Location = New System.Drawing.Point(89, 54)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.ReadOnly = True
        Me.cmbMes.Size = New System.Drawing.Size(126, 21)
        Me.cmbMes.TabIndex = 203
        Me.cmbMes.TabStop = False
        '
        'UltraLabel6
        '
        Appearance38.BackColor = System.Drawing.Color.Transparent
        Appearance38.TextHAlignAsString = "Center"
        Appearance38.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance38
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(55, 23)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(24, 14)
        Me.UltraLabel6.TabIndex = 206
        Me.UltraLabel6.Text = "Año"
        '
        'txtayo
        '
        Me.txtayo.Enabled = False
        Me.txtayo.Location = New System.Drawing.Point(89, 21)
        Me.txtayo.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtayo.Name = "txtayo"
        Me.txtayo.Size = New System.Drawing.Size(57, 20)
        Me.txtayo.TabIndex = 204
        Me.txtayo.TabStop = False
        Me.txtayo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtayo.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'UltraLabel2
        '
        Appearance101.BackColor = System.Drawing.Color.Transparent
        Appearance101.TextHAlignAsString = "Center"
        Appearance101.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance101
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(22, 128)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(59, 14)
        Me.UltraLabel2.TabIndex = 213
        Me.UltraLabel2.Text = "Trabajador"
        '
        'TxtCodigoTrabajador
        '
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.TextHAlignAsString = "Left"
        Appearance12.TextVAlignAsString = "Middle"
        Me.TxtCodigoTrabajador.Appearance = Appearance12
        Me.TxtCodigoTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodigoTrabajador.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtCodigoTrabajador.Location = New System.Drawing.Point(89, 93)
        Me.TxtCodigoTrabajador.MaxLength = 8
        Me.TxtCodigoTrabajador.Name = "TxtCodigoTrabajador"
        Me.TxtCodigoTrabajador.ReadOnly = True
        Me.TxtCodigoTrabajador.Size = New System.Drawing.Size(126, 21)
        Me.TxtCodigoTrabajador.TabIndex = 211
        Me.TxtCodigoTrabajador.TabStop = False
        '
        'TxtNombresTrabajador
        '
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.TxtNombresTrabajador.Appearance = Appearance2
        Me.TxtNombresTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombresTrabajador.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtNombresTrabajador.Location = New System.Drawing.Point(89, 124)
        Me.TxtNombresTrabajador.Name = "TxtNombresTrabajador"
        Me.TxtNombresTrabajador.ReadOnly = True
        Me.TxtNombresTrabajador.Size = New System.Drawing.Size(272, 21)
        Me.TxtNombresTrabajador.TabIndex = 210
        Me.TxtNombresTrabajador.TabStop = False
        '
        'UltraLabel18
        '
        Appearance21.BackColor = System.Drawing.Color.Transparent
        Appearance21.TextHAlignAsString = "Center"
        Appearance21.TextVAlignAsString = "Middle"
        Me.UltraLabel18.Appearance = Appearance21
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Location = New System.Drawing.Point(39, 97)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(40, 14)
        Me.UltraLabel18.TabIndex = 212
        Me.UltraLabel18.Text = "Codigo"
        '
        'Button1
        '
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(221, 93)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 21)
        Me.Button1.TabIndex = 214
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtseguro
        '
        Appearance20.TextHAlignAsString = "Right"
        Appearance20.TextVAlignAsString = "Middle"
        Me.txtseguro.Appearance = Appearance20
        Me.txtseguro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtseguro.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtseguro.Location = New System.Drawing.Point(89, 156)
        Me.txtseguro.Name = "txtseguro"
        Me.txtseguro.Size = New System.Drawing.Size(126, 21)
        Me.txtseguro.TabIndex = 1
        '
        'FrmSeguroLey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 239)
        Me.Controls.Add(Me.txtseguro)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.TxtCodigoTrabajador)
        Me.Controls.Add(Me.TxtNombresTrabajador)
        Me.Controls.Add(Me.UltraLabel18)
        Me.Controls.Add(Me.btnnuevod)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.UltraLabel16)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.UltraLabel6)
        Me.Controls.Add(Me.txtayo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSeguroLey"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSeguroLey"
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodigoTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNombresTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtseguro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnnuevod As System.Windows.Forms.Button
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbMes As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtayo As System.Windows.Forms.NumericUpDown
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtCodigoTrabajador As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents TxtNombresTrabajador As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtseguro As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
