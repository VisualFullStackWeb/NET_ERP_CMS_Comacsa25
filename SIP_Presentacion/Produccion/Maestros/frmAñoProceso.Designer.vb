<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAñoProceso
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
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel
        Me.txtAño = New System.Windows.Forms.NumericUpDown
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        CType(Me.txtAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraLabel15
        '
        Appearance114.BackColor = System.Drawing.Color.Transparent
        Appearance114.FontData.BoldAsString = "True"
        Me.UltraLabel15.Appearance = Appearance114
        Me.UltraLabel15.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel15.Location = New System.Drawing.Point(71, 45)
        Me.UltraLabel15.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(184, 16)
        Me.UltraLabel15.TabIndex = 160
        Me.UltraLabel15.Text = "SELECCIONE AÑO A PROCESAR"
        '
        'txtAño
        '
        Me.txtAño.Location = New System.Drawing.Point(67, 79)
        Me.txtAño.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtAño.Name = "txtAño"
        Me.txtAño.Size = New System.Drawing.Size(84, 20)
        Me.txtAño.TabIndex = 159
        Me.txtAño.Value = New Decimal(New Integer() {2014, 0, 0, 0})
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(167, 80)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(84, 19)
        Me.btnProcesar.TabIndex = 161
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'lblmensaje
        '
        Me.lblmensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance26.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Appearance26.FontData.BoldAsString = "True"
        Appearance26.FontData.SizeInPoints = 10.0!
        Appearance26.ForeColor = System.Drawing.Color.SteelBlue
        Appearance26.TextHAlignAsString = "Center"
        Appearance26.TextVAlignAsString = "Middle"
        Me.lblmensaje.Appearance = Appearance26
        Me.lblmensaje.Location = New System.Drawing.Point(-1, 124)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(327, 24)
        Me.lblmensaje.TabIndex = 165
        Me.lblmensaje.Text = "Procesando Datos..."
        Me.lblmensaje.Visible = False
        '
        'frmAñoProceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 160)
        Me.Controls.Add(Me.lblmensaje)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.UltraLabel15)
        Me.Controls.Add(Me.txtAño)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAñoProceso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAñoProceso"
        CType(Me.txtAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAño As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
End Class
