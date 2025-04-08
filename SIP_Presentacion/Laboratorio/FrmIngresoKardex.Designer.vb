<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresoKardex
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
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem19 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem24 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.dtFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.txtobservacion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcantidad = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.btnaceptar = New System.Windows.Forms.Button
        Me.cmbMovimiento = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.txtmarca = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.txtconcentracion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtobservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtconcentracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraLabel5
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance1
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(18, 30)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(36, 14)
        Me.UltraLabel5.TabIndex = 102
        Me.UltraLabel5.Text = "Fecha"
        '
        'dtFecha
        '
        Me.dtFecha.AutoSize = False
        Me.dtFecha.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFecha.Location = New System.Drawing.Point(112, 28)
        Me.dtFecha.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtFecha.Size = New System.Drawing.Size(147, 22)
        Me.dtFecha.TabIndex = 1
        Me.dtFecha.TabStop = False
        Me.dtFecha.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'UltraLabel1
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(18, 60)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(62, 14)
        Me.UltraLabel1.TabIndex = 159
        Me.UltraLabel1.Text = "Movimiento"
        '
        'txtobservacion
        '
        Appearance17.TextHAlignAsString = "Left"
        Appearance17.TextVAlignAsString = "Middle"
        Me.txtobservacion.Appearance = Appearance17
        Me.txtobservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobservacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtobservacion.Location = New System.Drawing.Point(112, 180)
        Me.txtobservacion.MaxLength = 300
        Me.txtobservacion.Multiline = True
        Me.txtobservacion.Name = "txtobservacion"
        Me.txtobservacion.Size = New System.Drawing.Size(236, 103)
        Me.txtobservacion.TabIndex = 6
        Me.txtobservacion.TabStop = False
        '
        'txtcantidad
        '
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtcantidad.Appearance = Appearance4
        Me.txtcantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcantidad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcantidad.Location = New System.Drawing.Point(112, 148)
        Me.txtcantidad.MaxLength = 18
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(147, 21)
        Me.txtcantidad.TabIndex = 5
        Me.txtcantidad.TabStop = False
        '
        'UltraLabel2
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Center"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance5
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(18, 151)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(85, 14)
        Me.UltraLabel2.TabIndex = 162
        Me.UltraLabel2.Text = "Cantidad (Kilos)"
        '
        'UltraLabel3
        '
        Appearance39.BackColor = System.Drawing.Color.Transparent
        Appearance39.TextHAlignAsString = "Center"
        Appearance39.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance39
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(18, 180)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(68, 14)
        Me.UltraLabel3.TabIndex = 163
        Me.UltraLabel3.Text = "Observación"
        '
        'btnaceptar
        '
        Me.btnaceptar.Location = New System.Drawing.Point(238, 294)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(109, 23)
        Me.btnaceptar.TabIndex = 7
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'cmbMovimiento
        '
        Me.cmbMovimiento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMovimiento.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem19.DataValue = "I"
        ValueListItem19.DisplayText = "INGRESO"
        ValueListItem24.DataValue = "S"
        ValueListItem24.DisplayText = "SALIDA"
        Me.cmbMovimiento.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem19, ValueListItem24})
        Me.cmbMovimiento.Location = New System.Drawing.Point(112, 60)
        Me.cmbMovimiento.Name = "cmbMovimiento"
        Me.cmbMovimiento.Size = New System.Drawing.Size(147, 21)
        Me.cmbMovimiento.TabIndex = 2
        '
        'UltraLabel4
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Center"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance6
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(18, 90)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(61, 14)
        Me.UltraLabel4.TabIndex = 165
        Me.UltraLabel4.Text = "Marca/Lote"
        '
        'txtmarca
        '
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.txtmarca.Appearance = Appearance7
        Me.txtmarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmarca.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtmarca.Location = New System.Drawing.Point(112, 87)
        Me.txtmarca.MaxLength = 18
        Me.txtmarca.Name = "txtmarca"
        Me.txtmarca.ReadOnly = True
        Me.txtmarca.Size = New System.Drawing.Size(147, 21)
        Me.txtmarca.TabIndex = 3
        Me.txtmarca.TabStop = False
        '
        'UltraLabel6
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance3
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(18, 120)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(92, 14)
        Me.UltraLabel6.TabIndex = 167
        Me.UltraLabel6.Text = "Concetración (%)"
        '
        'txtconcentracion
        '
        Appearance33.TextHAlignAsString = "Right"
        Appearance33.TextVAlignAsString = "Middle"
        Me.txtconcentracion.Appearance = Appearance33
        Me.txtconcentracion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtconcentracion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtconcentracion.Location = New System.Drawing.Point(112, 117)
        Me.txtconcentracion.MaxLength = 18
        Me.txtconcentracion.Name = "txtconcentracion"
        Me.txtconcentracion.ReadOnly = True
        Me.txtconcentracion.Size = New System.Drawing.Size(147, 21)
        Me.txtconcentracion.TabIndex = 4
        Me.txtconcentracion.TabStop = False
        '
        'FrmIngresoKardex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 330)
        Me.Controls.Add(Me.UltraLabel6)
        Me.Controls.Add(Me.txtconcentracion)
        Me.Controls.Add(Me.UltraLabel4)
        Me.Controls.Add(Me.txtmarca)
        Me.Controls.Add(Me.cmbMovimiento)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.txtobservacion)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.UltraLabel5)
        Me.Controls.Add(Me.dtFecha)
        Me.Name = "FrmIngresoKardex"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmIngresoKardex"
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtobservacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtconcentracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtobservacion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcantidad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    Friend WithEvents cmbMovimiento As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtmarca As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtconcentracion As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
