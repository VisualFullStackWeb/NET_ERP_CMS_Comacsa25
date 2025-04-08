<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFormatoReporte
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
        Me.chkcontable = New System.Windows.Forms.RadioButton
        Me.chkadministrativo = New System.Windows.Forms.RadioButton
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'chkcontable
        '
        Me.chkcontable.AutoSize = True
        Me.chkcontable.Checked = True
        Me.chkcontable.Location = New System.Drawing.Point(65, 14)
        Me.chkcontable.Name = "chkcontable"
        Me.chkcontable.Size = New System.Drawing.Size(67, 17)
        Me.chkcontable.TabIndex = 0
        Me.chkcontable.TabStop = True
        Me.chkcontable.Text = "Contable"
        Me.chkcontable.UseVisualStyleBackColor = True
        '
        'chkadministrativo
        '
        Me.chkadministrativo.AutoSize = True
        Me.chkadministrativo.Location = New System.Drawing.Point(150, 14)
        Me.chkadministrativo.Name = "chkadministrativo"
        Me.chkadministrativo.Size = New System.Drawing.Size(90, 17)
        Me.chkadministrativo.TabIndex = 1
        Me.chkadministrativo.Text = "Administrativo"
        Me.chkadministrativo.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(95, 37)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmFormatoReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(300, 74)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chkadministrativo)
        Me.Controls.Add(Me.chkcontable)
        Me.Name = "frmFormatoReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkcontable As System.Windows.Forms.RadioButton
    Friend WithEvents chkadministrativo As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
