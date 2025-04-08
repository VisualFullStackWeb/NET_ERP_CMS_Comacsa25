<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCCosteoProduccion
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
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Grb1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Clb1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Grb4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Txt4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Lbl2 = New Infragistics.Win.Misc.UltraLabel
        Me.Lbl1 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt5 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Rbt5 = New System.Windows.Forms.RadioButton
        Me.Rbt4 = New System.Windows.Forms.RadioButton
        Me.Rbt3 = New System.Windows.Forms.RadioButton
        Me.Chk1 = New System.Windows.Forms.CheckBox
        Me.Grb3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.lblDetalle = New Infragistics.Win.Misc.UltraLabel
        Me.lblCosteo = New Infragistics.Win.Misc.UltraLabel
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel
        Me.Grb2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Rbt2 = New System.Windows.Forms.RadioButton
        Me.Rbt1 = New System.Windows.Forms.RadioButton
        Me.Txt2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        CType(Me.Grb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grb1.SuspendLayout()
        CType(Me.Clb1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grb4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grb4.SuspendLayout()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grb3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grb3.SuspendLayout()
        CType(Me.Grb2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grb2.SuspendLayout()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grb1
        '
        Appearance74.BackColor = System.Drawing.Color.White
        Me.Grb1.ContentAreaAppearance = Appearance74
        Me.Grb1.Controls.Add(Me.Clb1)
        Me.Grb1.Controls.Add(Me.Grb4)
        Me.Grb1.Controls.Add(Me.Chk1)
        Me.Grb1.Controls.Add(Me.Grb3)
        Me.Grb1.Controls.Add(Me.Grb2)
        Me.Grb1.Controls.Add(Me.Txt2)
        Me.Grb1.Controls.Add(Me.Txt1)
        Me.Grb1.Controls.Add(Me.UltraLabel1)
        Me.Grb1.Controls.Add(Me.UltraLabel3)
        Me.Grb1.Dock = System.Windows.Forms.DockStyle.Fill
        Appearance78.FontData.BoldAsString = "True"
        Appearance78.FontData.Name = "Arial Narrow"
        Appearance78.FontData.SizeInPoints = 10.0!
        Me.Grb1.HeaderAppearance = Appearance78
        Me.Grb1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Grb1.Location = New System.Drawing.Point(0, 0)
        Me.Grb1.Name = "Grb1"
        Me.Grb1.Size = New System.Drawing.Size(428, 396)
        Me.Grb1.TabIndex = 132
        Me.Grb1.Text = "COSTEO DE PRODUCCIÓN"
        Me.Grb1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Clb1
        '
        Me.Clb1.DateTime = New Date(2012, 1, 26, 0, 0, 0, 0)
        Me.Clb1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Clb1.FormatString = "MMMM/yyyy"
        Me.Clb1.Location = New System.Drawing.Point(95, 38)
        Me.Clb1.MaskInput = ""
        Me.Clb1.Name = "Clb1"
        Me.Clb1.Size = New System.Drawing.Size(120, 21)
        Me.Clb1.TabIndex = 31
        Me.Clb1.Value = New Date(2012, 1, 26, 0, 0, 0, 0)
        '
        'Grb4
        '
        Me.Grb4.Controls.Add(Me.Txt4)
        Me.Grb4.Controls.Add(Me.Txt3)
        Me.Grb4.Controls.Add(Me.Lbl2)
        Me.Grb4.Controls.Add(Me.Lbl1)
        Me.Grb4.Controls.Add(Me.Txt5)
        Me.Grb4.Controls.Add(Me.Rbt5)
        Me.Grb4.Controls.Add(Me.Rbt4)
        Me.Grb4.Controls.Add(Me.Rbt3)
        Me.Grb4.Location = New System.Drawing.Point(95, 142)
        Me.Grb4.Name = "Grb4"
        Me.Grb4.Size = New System.Drawing.Size(306, 144)
        Me.Grb4.TabIndex = 30
        Me.Grb4.Text = "Tipo de Procesamiento"
        Me.Grb4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003
        '
        'Txt4
        '
        Me.Txt4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt4.Location = New System.Drawing.Point(161, 87)
        Me.Txt4.Name = "Txt4"
        Me.Txt4.ReadOnly = True
        Me.Txt4.Size = New System.Drawing.Size(140, 21)
        Me.Txt4.TabIndex = 27
        Me.Txt4.Visible = False
        '
        'Txt3
        '
        Me.Txt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt3.Location = New System.Drawing.Point(94, 87)
        Me.Txt3.Name = "Txt3"
        Me.Txt3.ReadOnly = True
        Me.Txt3.Size = New System.Drawing.Size(61, 21)
        Me.Txt3.TabIndex = 26
        Me.Txt3.Visible = False
        '
        'Lbl2
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.FontData.BoldAsString = "True"
        Me.Lbl2.Appearance = Appearance7
        Me.Lbl2.Location = New System.Drawing.Point(9, 91)
        Me.Lbl2.Name = "Lbl2"
        Me.Lbl2.Size = New System.Drawing.Size(77, 19)
        Me.Lbl2.TabIndex = 5
        Me.Lbl2.Text = "Molino:"
        Me.Lbl2.Visible = False
        '
        'Lbl1
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.FontData.BoldAsString = "True"
        Me.Lbl1.Appearance = Appearance8
        Me.Lbl1.Location = New System.Drawing.Point(9, 120)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(77, 19)
        Me.Lbl1.TabIndex = 4
        Me.Lbl1.Text = "Cant. (TON):"
        Me.Lbl1.Visible = False
        '
        'Txt5
        '
        Me.Txt5.Location = New System.Drawing.Point(92, 118)
        Me.Txt5.MaskInput = "{double:9.4}"
        Me.Txt5.Name = "Txt5"
        Me.Txt5.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.Txt5.Size = New System.Drawing.Size(106, 21)
        Me.Txt5.TabIndex = 3
        Me.Txt5.Visible = False
        '
        'Rbt5
        '
        Me.Rbt5.AutoSize = True
        Me.Rbt5.BackColor = System.Drawing.SystemColors.Window
        Me.Rbt5.Location = New System.Drawing.Point(9, 68)
        Me.Rbt5.Name = "Rbt5"
        Me.Rbt5.Size = New System.Drawing.Size(100, 17)
        Me.Rbt5.TabIndex = 2
        Me.Rbt5.Text = "Proyectar Costo"
        Me.Rbt5.UseVisualStyleBackColor = False
        '
        'Rbt4
        '
        Me.Rbt4.AutoSize = True
        Me.Rbt4.BackColor = System.Drawing.SystemColors.Window
        Me.Rbt4.Location = New System.Drawing.Point(9, 45)
        Me.Rbt4.Name = "Rbt4"
        Me.Rbt4.Size = New System.Drawing.Size(146, 17)
        Me.Rbt4.TabIndex = 1
        Me.Rbt4.Text = "Procesar Periodo Cerrado"
        Me.Rbt4.UseVisualStyleBackColor = False
        '
        'Rbt3
        '
        Me.Rbt3.AutoSize = True
        Me.Rbt3.BackColor = System.Drawing.SystemColors.Window
        Me.Rbt3.Checked = True
        Me.Rbt3.Location = New System.Drawing.Point(9, 21)
        Me.Rbt3.Name = "Rbt3"
        Me.Rbt3.Size = New System.Drawing.Size(103, 17)
        Me.Rbt3.TabIndex = 0
        Me.Rbt3.TabStop = True
        Me.Rbt3.Text = "Procesar Costeo"
        Me.Rbt3.UseVisualStyleBackColor = False
        '
        'Chk1
        '
        Me.Chk1.AutoSize = True
        Me.Chk1.BackColor = System.Drawing.Color.Transparent
        Me.Chk1.Location = New System.Drawing.Point(95, 119)
        Me.Chk1.Name = "Chk1"
        Me.Chk1.Size = New System.Drawing.Size(240, 17)
        Me.Chk1.TabIndex = 29
        Me.Chk1.Text = "Detallar Mano de Obra - Distrib. Entre Plantas"
        Me.Chk1.UseVisualStyleBackColor = False
        '
        'Grb3
        '
        Me.Grb3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.Grb3.Appearance = Appearance2
        Me.Grb3.Controls.Add(Me.lblDetalle)
        Me.Grb3.Controls.Add(Me.lblCosteo)
        Me.Grb3.Controls.Add(Me.lblEstado)
        Me.Grb3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grb3.Location = New System.Drawing.Point(20, 292)
        Me.Grb3.Name = "Grb3"
        Me.Grb3.Size = New System.Drawing.Size(396, 92)
        Me.Grb3.TabIndex = 28
        Me.Grb3.Text = "Estado"
        Me.Grb3.Visible = False
        '
        'lblDetalle
        '
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.ForeColor = System.Drawing.Color.Navy
        Me.lblDetalle.Appearance = Appearance6
        Me.lblDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetalle.Location = New System.Drawing.Point(9, 61)
        Me.lblDetalle.Name = "lblDetalle"
        Me.lblDetalle.Size = New System.Drawing.Size(378, 18)
        Me.lblDetalle.TabIndex = 2
        Me.lblDetalle.Text = "A"
        '
        'lblCosteo
        '
        Me.lblCosteo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.ForeColor = System.Drawing.Color.Olive
        Me.lblCosteo.Appearance = Appearance4
        Me.lblCosteo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCosteo.Location = New System.Drawing.Point(9, 40)
        Me.lblCosteo.Name = "lblCosteo"
        Me.lblCosteo.Size = New System.Drawing.Size(378, 18)
        Me.lblCosteo.TabIndex = 1
        Me.lblCosteo.Text = "A"
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblEstado.Appearance = Appearance3
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(9, 19)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(378, 18)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "A"
        '
        'Grb2
        '
        Me.Grb2.Controls.Add(Me.Rbt2)
        Me.Grb2.Controls.Add(Me.Rbt1)
        Me.Grb2.Location = New System.Drawing.Point(20, 397)
        Me.Grb2.Name = "Grb2"
        Me.Grb2.Size = New System.Drawing.Size(402, 71)
        Me.Grb2.TabIndex = 27
        Me.Grb2.Text = "Tipo de Costeo"
        Me.Grb2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003
        Me.Grb2.Visible = False
        '
        'Rbt2
        '
        Me.Rbt2.AutoSize = True
        Me.Rbt2.BackColor = System.Drawing.SystemColors.Window
        Me.Rbt2.Checked = True
        Me.Rbt2.Location = New System.Drawing.Point(192, 32)
        Me.Rbt2.Name = "Rbt2"
        Me.Rbt2.Size = New System.Drawing.Size(122, 17)
        Me.Rbt2.TabIndex = 1
        Me.Rbt2.TabStop = True
        Me.Rbt2.Text = "Costeo por Producto"
        Me.Rbt2.UseVisualStyleBackColor = False
        '
        'Rbt1
        '
        Me.Rbt1.AutoSize = True
        Me.Rbt1.BackColor = System.Drawing.SystemColors.Window
        Me.Rbt1.Location = New System.Drawing.Point(49, 32)
        Me.Rbt1.Name = "Rbt1"
        Me.Rbt1.Size = New System.Drawing.Size(110, 17)
        Me.Rbt1.TabIndex = 0
        Me.Rbt1.Text = "Costeo por Molino"
        Me.Rbt1.UseVisualStyleBackColor = False
        '
        'Txt2
        '
        Me.Txt2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt2.Location = New System.Drawing.Point(95, 92)
        Me.Txt2.Name = "Txt2"
        Me.Txt2.ReadOnly = True
        Me.Txt2.Size = New System.Drawing.Size(321, 21)
        Me.Txt2.TabIndex = 26
        '
        'Txt1
        '
        Me.Txt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt1.Location = New System.Drawing.Point(95, 66)
        Me.Txt1.Name = "Txt1"
        Me.Txt1.ReadOnly = True
        Me.Txt1.Size = New System.Drawing.Size(120, 21)
        Me.Txt1.TabIndex = 25
        '
        'UltraLabel1
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance5
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(14, 69)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel1.TabIndex = 24
        Me.UltraLabel1.Text = "Producto :"
        '
        'UltraLabel3
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance1
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(14, 40)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel3.TabIndex = 23
        Me.UltraLabel3.Text = "* Mes / Año :"
        '
        'frmCCosteoProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 396)
        Me.Controls.Add(Me.Grb1)
        Me.Name = "frmCCosteoProduccion"
        Me.Text = "Costeo de Producción"
        CType(Me.Grb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grb1.ResumeLayout(False)
        Me.Grb1.PerformLayout()
        CType(Me.Clb1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grb4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grb4.ResumeLayout(False)
        Me.Grb4.PerformLayout()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grb3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grb3.ResumeLayout(False)
        CType(Me.Grb2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grb2.ResumeLayout(False)
        Me.Grb2.PerformLayout()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grb1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Grb2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Rbt2 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt1 As System.Windows.Forms.RadioButton
    Friend WithEvents Grb3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblDetalle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblCosteo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Chk1 As System.Windows.Forms.CheckBox
    Friend WithEvents Grb4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Rbt4 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt3 As System.Windows.Forms.RadioButton
    Friend WithEvents Clb1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Rbt5 As System.Windows.Forms.RadioButton
    Friend WithEvents Lbl1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt5 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Txt4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Lbl2 As Infragistics.Win.Misc.UltraLabel
End Class
