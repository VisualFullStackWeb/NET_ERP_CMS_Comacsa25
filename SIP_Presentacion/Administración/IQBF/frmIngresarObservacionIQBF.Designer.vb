<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresarObservacionIQBF
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
        Me.Txtobservacion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel
        Me.btnProcesar = New System.Windows.Forms.Button
        CType(Me.Txtobservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Txtobservacion.Location = New System.Drawing.Point(33, 43)
        Me.Txtobservacion.MaxLength = 150
        Me.Txtobservacion.Multiline = True
        Me.Txtobservacion.Name = "Txtobservacion"
        Me.Txtobservacion.Size = New System.Drawing.Size(284, 64)
        Me.Txtobservacion.TabIndex = 1
        '
        'UltraLabel18
        '
        Appearance21.BackColor = System.Drawing.Color.Transparent
        Appearance21.TextHAlignAsString = "Center"
        Appearance21.TextVAlignAsString = "Middle"
        Me.UltraLabel18.Appearance = Appearance21
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Location = New System.Drawing.Point(33, 23)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(68, 14)
        Me.UltraLabel18.TabIndex = 17
        Me.UltraLabel18.Text = "Observación"
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(228, 113)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(89, 20)
        Me.btnProcesar.TabIndex = 2
        Me.btnProcesar.Text = "Guardar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'frmIngresarObservacionIQBF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 149)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Txtobservacion)
        Me.Controls.Add(Me.UltraLabel18)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIngresarObservacionIQBF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Observación"
        CType(Me.Txtobservacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txtobservacion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
End Class
