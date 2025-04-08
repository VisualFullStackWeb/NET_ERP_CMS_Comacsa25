<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFechaGasto
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.dtFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.chktercero = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtdias = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcomentario = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcomentario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtFecha
        '
        Me.dtFecha.AutoSize = False
        Me.dtFecha.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFecha.Location = New System.Drawing.Point(47, 38)
        Me.dtFecha.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtFecha.Size = New System.Drawing.Size(147, 18)
        Me.dtFecha.TabIndex = 101
        Me.dtFecha.TabStop = False
        Me.dtFecha.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'UltraLabel5
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance1
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(47, 18)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(69, 14)
        Me.UltraLabel5.TabIndex = 102
        Me.UltraLabel5.Text = "Fecha Gasto"
        '
        'chktercero
        '
        Me.chktercero.BackColor = System.Drawing.Color.Transparent
        Me.chktercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chktercero.Location = New System.Drawing.Point(47, 213)
        Me.chktercero.Name = "chktercero"
        Me.chktercero.Size = New System.Drawing.Size(147, 25)
        Me.chktercero.TabIndex = 147
        Me.chktercero.Text = "GASTO DE TERCERO"
        Me.chktercero.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(228, 230)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 23)
        Me.Button1.TabIndex = 148
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtdias
        '
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.txtdias.Appearance = Appearance2
        Me.txtdias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdias.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtdias.Location = New System.Drawing.Point(47, 86)
        Me.txtdias.MaxLength = 8
        Me.txtdias.Name = "txtdias"
        Me.txtdias.Size = New System.Drawing.Size(147, 21)
        Me.txtdias.TabIndex = 149
        Me.txtdias.TabStop = False
        '
        'txtcomentario
        '
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.TextHAlignAsString = "Left"
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtcomentario.Appearance = Appearance4
        Me.txtcomentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcomentario.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcomentario.Location = New System.Drawing.Point(47, 135)
        Me.txtcomentario.MaxLength = 8
        Me.txtcomentario.Multiline = True
        Me.txtcomentario.Name = "txtcomentario"
        Me.txtcomentario.Size = New System.Drawing.Size(261, 64)
        Me.txtcomentario.TabIndex = 150
        Me.txtcomentario.TabStop = False
        '
        'UltraLabel1
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance3
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(47, 66)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(27, 14)
        Me.UltraLabel1.TabIndex = 151
        Me.UltraLabel1.Text = "Días"
        '
        'UltraLabel2
        '
        Appearance39.BackColor = System.Drawing.Color.Transparent
        Appearance39.TextHAlignAsString = "Center"
        Appearance39.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance39
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(47, 115)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(63, 14)
        Me.UltraLabel2.TabIndex = 152
        Me.UltraLabel2.Text = "Comentario"
        '
        'frmFechaGasto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(359, 265)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.txtcomentario)
        Me.Controls.Add(Me.txtdias)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chktercero)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.UltraLabel5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFechaGasto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmFechaGasto"
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcomentario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chktercero As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtdias As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcomentario As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
End Class
