<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresaCampaña
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.txtnumero = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpInicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpFin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.btnReporte = New System.Windows.Forms.Button
        Me.txtid = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcodequipo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.txtequipo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        CType(Me.txtnumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodequipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtequipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtnumero
        '
        Appearance4.TextHAlignAsString = "Left"
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtnumero.Appearance = Appearance4
        Me.txtnumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumero.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtnumero.Location = New System.Drawing.Point(39, 28)
        Me.txtnumero.MaxLength = 20
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(85, 21)
        Me.txtnumero.TabIndex = 1
        '
        'UltraLabel7
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Center"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance5
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Location = New System.Drawing.Point(39, 12)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(85, 14)
        Me.UltraLabel7.TabIndex = 166
        Me.UltraLabel7.Text = "N° de Campaña"
        '
        'dtpInicio
        '
        Me.dtpInicio.AutoSize = False
        Me.dtpInicio.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtpInicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpInicio.Location = New System.Drawing.Point(39, 75)
        Me.dtpInicio.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpInicio.Size = New System.Drawing.Size(147, 18)
        Me.dtpInicio.TabIndex = 2
        Me.dtpInicio.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'UltraLabel5
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance1
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(39, 61)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(81, 14)
        Me.UltraLabel5.TabIndex = 169
        Me.UltraLabel5.Text = "Fecha de Inicio"
        '
        'dtpFin
        '
        Me.dtpFin.AutoSize = False
        Me.dtpFin.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtpFin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpFin.Location = New System.Drawing.Point(39, 118)
        Me.dtpFin.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpFin.Size = New System.Drawing.Size(147, 18)
        Me.dtpFin.TabIndex = 3
        Me.dtpFin.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'UltraLabel1
        '
        Appearance39.BackColor = System.Drawing.Color.Transparent
        Appearance39.TextHAlignAsString = "Center"
        Appearance39.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance39
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(39, 103)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(76, 14)
        Me.UltraLabel1.TabIndex = 171
        Me.UltraLabel1.Text = "Fecha de Fina"
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.SIP_Presentacion.My.Resources.Resources.guardar2
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(216, 158)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(112, 29)
        Me.btnReporte.TabIndex = 200
        Me.btnReporte.Text = "Grabar"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'txtid
        '
        Appearance33.TextHAlignAsString = "Left"
        Appearance33.TextVAlignAsString = "Middle"
        Me.txtid.Appearance = Appearance33
        Me.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtid.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtid.Location = New System.Drawing.Point(130, 28)
        Me.txtid.MaxLength = 20
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(85, 21)
        Me.txtid.TabIndex = 201
        Me.txtid.Visible = False
        '
        'txtcodequipo
        '
        Appearance3.TextHAlignAsString = "Left"
        Appearance3.TextVAlignAsString = "Middle"
        Me.txtcodequipo.Appearance = Appearance3
        Me.txtcodequipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodequipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodequipo.Location = New System.Drawing.Point(224, 28)
        Me.txtcodequipo.MaxLength = 20
        Me.txtcodequipo.Name = "txtcodequipo"
        Me.txtcodequipo.ReadOnly = True
        Me.txtcodequipo.Size = New System.Drawing.Size(10, 21)
        Me.txtcodequipo.TabIndex = 202
        Me.txtcodequipo.Visible = False
        '
        'UltraLabel2
        '
        Appearance32.BackColor = System.Drawing.Color.Transparent
        Appearance32.TextHAlignAsString = "Center"
        Appearance32.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance32
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(224, 12)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(40, 14)
        Me.UltraLabel2.TabIndex = 203
        Me.UltraLabel2.Text = "Equipo"
        Me.UltraLabel2.Visible = False
        '
        'txtequipo
        '
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.txtequipo.Appearance = Appearance2
        Me.txtequipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtequipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtequipo.Location = New System.Drawing.Point(240, 28)
        Me.txtequipo.MaxLength = 20
        Me.txtequipo.Name = "txtequipo"
        Me.txtequipo.ReadOnly = True
        Me.txtequipo.Size = New System.Drawing.Size(10, 21)
        Me.txtequipo.TabIndex = 204
        Me.txtequipo.Visible = False
        '
        'FrmIngresaCampaña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 195)
        Me.Controls.Add(Me.txtequipo)
        Me.Controls.Add(Me.txtcodequipo)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.dtpFin)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.dtpInicio)
        Me.Controls.Add(Me.UltraLabel5)
        Me.Controls.Add(Me.txtnumero)
        Me.Controls.Add(Me.UltraLabel7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmIngresaCampaña"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmIngresaCampaña"
        CType(Me.txtnumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodequipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtequipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtnumero As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpInicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpFin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents txtid As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcodequipo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtequipo As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
