<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEntIngresoAjuste
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
        Dim ValueListItem19 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem24 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.btnnuevo = New System.Windows.Forms.Button
        Me.cmbMovimiento = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.txtimporte = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        CType(Me.cmbMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtimporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnnuevo
        '
        Me.btnnuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnnuevo.Image = Global.SIP_Presentacion.My.Resources.Resources.guardar2
        Me.btnnuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnnuevo.Location = New System.Drawing.Point(198, 109)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnnuevo.TabIndex = 159
        Me.btnnuevo.Text = "Grabar"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'cmbMovimiento
        '
        Me.cmbMovimiento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMovimiento.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem19.DataValue = "1"
        ValueListItem19.DisplayText = "DIFERENCIA DE CAMBIO"
        ValueListItem24.DataValue = "2"
        ValueListItem24.DisplayText = "AJUSTE DE CENTIMOS"
        Me.cmbMovimiento.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem19, ValueListItem24})
        Me.cmbMovimiento.Location = New System.Drawing.Point(126, 49)
        Me.cmbMovimiento.Name = "cmbMovimiento"
        Me.cmbMovimiento.Size = New System.Drawing.Size(147, 21)
        Me.cmbMovimiento.TabIndex = 160
        '
        'UltraLabel1
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(32, 49)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(62, 14)
        Me.UltraLabel1.TabIndex = 161
        Me.UltraLabel1.Text = "Movimiento"
        '
        'UltraLabel5
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance1
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(32, 21)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(36, 14)
        Me.UltraLabel5.TabIndex = 163
        Me.UltraLabel5.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.AutoSize = False
        Me.dtpFecha.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpFecha.Location = New System.Drawing.Point(126, 19)
        Me.dtpFecha.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpFecha.ReadOnly = True
        Me.dtpFecha.Size = New System.Drawing.Size(147, 22)
        Me.dtpFecha.TabIndex = 162
        Me.dtpFecha.TabStop = False
        Me.dtpFecha.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'UltraLabel4
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Center"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance6
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(32, 81)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(43, 14)
        Me.UltraLabel4.TabIndex = 167
        Me.UltraLabel4.Text = "Importe"
        '
        'txtimporte
        '
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtimporte.Appearance = Appearance4
        Me.txtimporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtimporte.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtimporte.Location = New System.Drawing.Point(126, 78)
        Me.txtimporte.MaxLength = 18
        Me.txtimporte.Name = "txtimporte"
        Me.txtimporte.Size = New System.Drawing.Size(147, 21)
        Me.txtimporte.TabIndex = 166
        Me.txtimporte.TabStop = False
        '
        'FrmEntIngresoAjuste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 144)
        Me.Controls.Add(Me.UltraLabel4)
        Me.Controls.Add(Me.txtimporte)
        Me.Controls.Add(Me.UltraLabel5)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.cmbMovimiento)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.btnnuevo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEntIngresoAjuste"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de ajuste de saldo"
        CType(Me.cmbMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtimporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents cmbMovimiento As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtimporte As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
