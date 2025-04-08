<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCambioPassword
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
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.TxtConfirmarPassword = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.TxtPasswordNuevo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.TxtPasswordActual = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.TxtLogin = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.TxtConfirmarPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPasswordNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPasswordActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBox1.Controls.Add(Me.TxtConfirmarPassword)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.TxtPasswordNuevo)
        Me.UltraGroupBox1.Controls.Add(Me.TxtPasswordActual)
        Me.UltraGroupBox1.Controls.Add(Me.TxtLogin)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(424, 152)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel7
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel7.Appearance = Appearance7
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Location = New System.Drawing.Point(300, 123)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(107, 14)
        Me.UltraLabel7.TabIndex = 13
        Me.UltraLabel7.Text = "(Max 10 Cáracteres)"
        '
        'TxtConfirmarPassword
        '
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.TxtConfirmarPassword.Appearance = Appearance2
        Me.TxtConfirmarPassword.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtConfirmarPassword.Location = New System.Drawing.Point(130, 120)
        Me.TxtConfirmarPassword.Name = "TxtConfirmarPassword"
        Me.TxtConfirmarPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirmarPassword.Size = New System.Drawing.Size(168, 21)
        Me.TxtConfirmarPassword.TabIndex = 12
        '
        'UltraLabel6
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.FontData.BoldAsString = "True"
        Me.UltraLabel6.Appearance = Appearance8
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(6, 121)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(111, 14)
        Me.UltraLabel6.TabIndex = 11
        Me.UltraLabel6.Text = "Confirmar Password"
        '
        'UltraLabel5
        '
        Appearance1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 12.0!
        Appearance1.ForeColor = System.Drawing.Color.White
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance1
        Me.UltraLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(0, 10)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(422, 25)
        Me.UltraLabel5.TabIndex = 10
        Me.UltraLabel5.Text = "PASSWORD"
        '
        'UltraLabel4
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel4.Appearance = Appearance11
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(300, 98)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(107, 14)
        Me.UltraLabel4.TabIndex = 6
        Me.UltraLabel4.Text = "(Max 10 Cáracteres)"
        '
        'TxtPasswordNuevo
        '
        Appearance9.TextHAlignAsString = "Center"
        Appearance9.TextVAlignAsString = "Middle"
        Me.TxtPasswordNuevo.Appearance = Appearance9
        Me.TxtPasswordNuevo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtPasswordNuevo.Location = New System.Drawing.Point(130, 95)
        Me.TxtPasswordNuevo.Name = "TxtPasswordNuevo"
        Me.TxtPasswordNuevo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPasswordNuevo.Size = New System.Drawing.Size(168, 21)
        Me.TxtPasswordNuevo.TabIndex = 5
        '
        'TxtPasswordActual
        '
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.TxtPasswordActual.Appearance = Appearance3
        Me.TxtPasswordActual.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtPasswordActual.Location = New System.Drawing.Point(130, 70)
        Me.TxtPasswordActual.Name = "TxtPasswordActual"
        Me.TxtPasswordActual.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPasswordActual.Size = New System.Drawing.Size(168, 21)
        Me.TxtPasswordActual.TabIndex = 4
        '
        'TxtLogin
        '
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        Me.TxtLogin.Appearance = Appearance4
        Me.TxtLogin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtLogin.Location = New System.Drawing.Point(130, 45)
        Me.TxtLogin.Name = "TxtLogin"
        Me.TxtLogin.ReadOnly = True
        Me.TxtLogin.Size = New System.Drawing.Size(100, 21)
        Me.TxtLogin.TabIndex = 3
        '
        'UltraLabel3
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.FontData.BoldAsString = "True"
        Me.UltraLabel3.Appearance = Appearance10
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(25, 96)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(93, 14)
        Me.UltraLabel3.TabIndex = 2
        Me.UltraLabel3.Text = "Password Nuevo"
        '
        'UltraLabel2
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.FontData.BoldAsString = "True"
        Me.UltraLabel2.Appearance = Appearance5
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(22, 70)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(92, 14)
        Me.UltraLabel2.TabIndex = 1
        Me.UltraLabel2.Text = "Password Actual"
        '
        'UltraLabel1
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.FontData.BoldAsString = "True"
        Me.UltraLabel1.Appearance = Appearance6
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(72, 45)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(45, 14)
        Me.UltraLabel1.TabIndex = 0
        Me.UltraLabel1.Text = "Usuario"
        '
        'FrmCambioPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 152)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCambioPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Cambio Password"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.TxtConfirmarPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPasswordNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPasswordActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtPasswordNuevo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents TxtPasswordActual As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents TxtLogin As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtConfirmarPassword As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
End Class
