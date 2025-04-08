<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBAyuda
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
        Me.components = New System.ComponentModel.Container
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBAyuda))
        Me.Ftxt1 = New Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor
        Me.Iml1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'Ftxt1
        '
        Me.Ftxt1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.FontData.BoldAsString = "False"
        Appearance1.FontData.ItalicAsString = "False"
        Appearance1.FontData.Name = "Microsoft Sans Serif"
        Appearance1.FontData.SizeInPoints = 8.25!
        Appearance1.FontData.StrikeoutAsString = "False"
        Appearance1.FontData.UnderlineAsString = "False"
        Me.Ftxt1.Appearance = Appearance1
        Me.Ftxt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Ftxt1.ImageList = Me.Iml1
        Me.Ftxt1.Location = New System.Drawing.Point(12, 12)
        Me.Ftxt1.Name = "Ftxt1"
        Me.Ftxt1.ReadOnly = True
        Me.Ftxt1.Size = New System.Drawing.Size(641, 334)
        Me.Ftxt1.TabIndex = 0
        Me.Ftxt1.Value = ""
        Me.Ftxt1.WrapText = False
        '
        'Iml1
        '
        Me.Iml1.ImageStream = CType(resources.GetObject("Iml1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Iml1.TransparentColor = System.Drawing.Color.Transparent
        Me.Iml1.Images.SetKeyName(0, "Hand.png")
        Me.Iml1.Images.SetKeyName(1, "Delete1.png")
        '
        'FrmBAyuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 358)
        Me.Controls.Add(Me.Ftxt1)
        Me.Name = "FrmBAyuda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".: Ayuda del Sistema :."
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ftxt1 As Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor
    Friend WithEvents Iml1 As System.Windows.Forms.ImageList
End Class
