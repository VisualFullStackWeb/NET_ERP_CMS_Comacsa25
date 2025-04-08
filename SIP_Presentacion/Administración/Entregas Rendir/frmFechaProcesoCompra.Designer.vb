<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFechaProcesoCompra
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
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Button1 = New System.Windows.Forms.Button
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.dtFechaProceso = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        CType(Me.dtFechaProceso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(170, 58)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UltraLabel5
        '
        Appearance59.BackColor = System.Drawing.Color.Transparent
        Appearance59.TextHAlignAsString = "Center"
        Appearance59.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance59
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(12, 30)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(80, 14)
        Me.UltraLabel5.TabIndex = 102
        Me.UltraLabel5.Text = "Fecha Proceso"
        '
        'dtFechaProceso
        '
        Me.dtFechaProceso.AutoSize = False
        Me.dtFechaProceso.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtFechaProceso.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFechaProceso.Location = New System.Drawing.Point(100, 28)
        Me.dtFechaProceso.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtFechaProceso.Name = "dtFechaProceso"
        Me.dtFechaProceso.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtFechaProceso.ReadOnly = True
        Me.dtFechaProceso.Size = New System.Drawing.Size(147, 18)
        Me.dtFechaProceso.TabIndex = 101
        Me.dtFechaProceso.TabStop = False
        Me.dtFechaProceso.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'frmFechaProcesoCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 95)
        Me.ControlBox = False
        Me.Controls.Add(Me.UltraLabel5)
        Me.Controls.Add(Me.dtFechaProceso)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFechaProcesoCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmFechaProcesoCompra"
        CType(Me.dtFechaProceso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtFechaProceso As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
End Class
