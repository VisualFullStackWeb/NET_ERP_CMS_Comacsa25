<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReclamoInputBox
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
        Me.grpComentario = New System.Windows.Forms.GroupBox
        Me.txtComentario = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.grpComentario.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpComentario
        '
        Me.grpComentario.Controls.Add(Me.btnGuardar)
        Me.grpComentario.Controls.Add(Me.txtComentario)
        Me.grpComentario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpComentario.Location = New System.Drawing.Point(0, 0)
        Me.grpComentario.Name = "grpComentario"
        Me.grpComentario.Size = New System.Drawing.Size(494, 191)
        Me.grpComentario.TabIndex = 0
        Me.grpComentario.TabStop = False
        '
        'txtComentario
        '
        Me.txtComentario.Location = New System.Drawing.Point(12, 12)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(476, 144)
        Me.txtComentario.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIP_Presentacion.My.Resources.Resources.guardar2
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(418, 162)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(70, 23)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmReclamoInputBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 191)
        Me.Controls.Add(Me.grpComentario)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReclamoInputBox"
        Me.Text = "Ingreso de Comentarios"
        Me.grpComentario.ResumeLayout(False)
        Me.grpComentario.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpComentario As System.Windows.Forms.GroupBox
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
End Class
