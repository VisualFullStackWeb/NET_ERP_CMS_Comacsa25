<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCantDiasPersonas
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel
        Me.txtdias = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.txtpersonas = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnguardar = New System.Windows.Forms.Button
        Me.btncancelar = New System.Windows.Forms.Button
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        CType(Me.txtdias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpersonas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraLabel18
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel18.Appearance = Appearance3
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Location = New System.Drawing.Point(41, 44)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(86, 14)
        Me.UltraLabel18.TabIndex = 16
        Me.UltraLabel18.Text = "CANT. DE DIAS"
        '
        'txtdias
        '
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.TextHAlignAsString = "Right"
        Appearance2.TextVAlignAsString = "Middle"
        Me.txtdias.Appearance = Appearance2
        Me.txtdias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdias.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtdias.Location = New System.Drawing.Point(175, 37)
        Me.txtdias.MaxLength = 8
        Me.txtdias.Name = "txtdias"
        Me.txtdias.Size = New System.Drawing.Size(81, 21)
        Me.txtdias.TabIndex = 1
        Me.txtdias.Text = "1"
        '
        'UltraLabel1
        '
        Appearance44.BackColor = System.Drawing.Color.Transparent
        Appearance44.TextHAlignAsString = "Center"
        Appearance44.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance44
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(41, 77)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(123, 14)
        Me.UltraLabel1.TabIndex = 18
        Me.UltraLabel1.Text = "CANT. DE PERSONAS"
        '
        'txtpersonas
        '
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtpersonas.Appearance = Appearance4
        Me.txtpersonas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpersonas.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtpersonas.Location = New System.Drawing.Point(175, 73)
        Me.txtpersonas.MaxLength = 8
        Me.txtpersonas.Name = "txtpersonas"
        Me.txtpersonas.Size = New System.Drawing.Size(81, 21)
        Me.txtpersonas.TabIndex = 2
        Me.txtpersonas.Text = "1"
        '
        'btnguardar
        '
        Me.btnguardar.Location = New System.Drawing.Point(89, 117)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(75, 23)
        Me.btnguardar.TabIndex = 3
        Me.btnguardar.Text = "Ok"
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.Location = New System.Drawing.Point(181, 117)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(75, 23)
        Me.btncancelar.TabIndex = 4
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'UltraLabel2
        '
        Appearance1.BackColor = System.Drawing.Color.SteelBlue
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance1
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(-1, 0)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(290, 17)
        Me.UltraLabel2.TabIndex = 22
        Me.UltraLabel2.Text = "INGRESE CANTIDAD DE DIAS Y PERSONAS"
        '
        'frmCantDiasPersonas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(289, 159)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.txtpersonas)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.txtdias)
        Me.Controls.Add(Me.UltraLabel18)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCantDiasPersonas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.txtdias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpersonas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtdias As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtpersonas As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
End Class
