<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBLogueo
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBLogueo))
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.pic1 = New System.Windows.Forms.PictureBox
        Me.btn2 = New Infragistics.Win.Misc.UltraButton
        Me.iml1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn1 = New Infragistics.Win.Misc.UltraButton
        Me.Txt2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.lblVersion = New System.Windows.Forms.Label
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularDoubleSolid
        Me.UltraGroupBox1.Controls.Add(Me.pic1)
        Me.UltraGroupBox1.Controls.Add(Me.btn2)
        Me.UltraGroupBox1.Controls.Add(Me.btn1)
        Me.UltraGroupBox1.Controls.Add(Me.Txt2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.Txt1)
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Microsoft Sans Serif"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.UltraGroupBox1.HeaderAppearance = Appearance3
        Me.UltraGroupBox1.Location = New System.Drawing.Point(6, 18)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(422, 166)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'pic1
        '
        Me.pic1.BackColor = System.Drawing.Color.White
        Me.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic1.Dock = System.Windows.Forms.DockStyle.Left
        Me.pic1.Image = Global.SIP_Presentacion.My.Resources.Resources.Candado___Close
        Me.pic1.Location = New System.Drawing.Point(4, 5)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(164, 157)
        Me.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic1.TabIndex = 6
        Me.pic1.TabStop = False
        '
        'btn2
        '
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.ForeColor = System.Drawing.Color.MidnightBlue
        Appearance6.Image = "Close 2.png"
        Appearance6.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance6.TextHAlignAsString = "Center"
        Me.btn2.Appearance = Appearance6
        Me.btn2.ImageList = Me.iml1
        Me.btn2.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn2.Location = New System.Drawing.Point(296, 104)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(111, 51)
        Me.btn2.TabIndex = 5
        Me.btn2.Text = "SALIR"
        '
        'iml1
        '
        Me.iml1.ImageStream = CType(resources.GetObject("iml1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml1.TransparentColor = System.Drawing.Color.Transparent
        Me.iml1.Images.SetKeyName(0, "Aceptar.png")
        Me.iml1.Images.SetKeyName(1, "Close 2.png")
        '
        'btn1
        '
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.ForeColor = System.Drawing.Color.MidnightBlue
        Appearance5.Image = "Aceptar.png"
        Me.btn1.Appearance = Appearance5
        Me.btn1.ImageList = Me.iml1
        Me.btn1.ImageSize = New System.Drawing.Size(32, 32)
        Me.btn1.Location = New System.Drawing.Point(179, 104)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(111, 51)
        Me.btn1.TabIndex = 4
        Me.btn1.Text = "INGRESAR"
        '
        'Txt2
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.Txt2.Appearance = Appearance1
        Me.Txt2.BackColor = System.Drawing.Color.White
        Me.Txt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt2.Location = New System.Drawing.Point(179, 77)
        Me.Txt2.Name = "Txt2"
        Me.Txt2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt2.Size = New System.Drawing.Size(228, 21)
        Me.Txt2.TabIndex = 3
        '
        'UltraLabel2
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.Name = "Microsoft Sans Serif"
        Appearance4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.UltraLabel2.Appearance = Appearance4
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(179, 59)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(111, 16)
        Me.UltraLabel2.TabIndex = 2
        Me.UltraLabel2.Text = "CONTRASEÑA :"
        '
        'UltraLabel1
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.Name = "Microsoft Sans Serif"
        Appearance2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(179, 13)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(83, 14)
        Me.UltraLabel1.TabIndex = 1
        Me.UltraLabel1.Text = "USUARIO :"
        '
        'Txt1
        '
        Appearance7.BackColor = System.Drawing.Color.White
        Me.Txt1.Appearance = Appearance7
        Me.Txt1.BackColor = System.Drawing.Color.White
        Me.Txt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt1.Location = New System.Drawing.Point(179, 31)
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Size = New System.Drawing.Size(228, 21)
        Me.Txt1.TabIndex = 0
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rounded
        Me.UltraGroupBox2.Controls.Add(Me.lblVersion)
        Me.UltraGroupBox2.Controls.Add(Me.UltraGroupBox1)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 4)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(438, 190)
        Me.UltraGroupBox2.TabIndex = 7
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(7, 5)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(163, 13)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Version : 00000000.000000"
        '
        'FrmBLogueo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 200)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmBLogueo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btn2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btn1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents pic1 As System.Windows.Forms.PictureBox
    Friend WithEvents iml1 As System.Windows.Forms.ImageList
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label

End Class
