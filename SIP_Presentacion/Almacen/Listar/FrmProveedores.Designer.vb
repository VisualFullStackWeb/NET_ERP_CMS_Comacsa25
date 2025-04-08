<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProveedores
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
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProveedores))
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RazonSocial")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCorto")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ruc")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PersonaNatural")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("RazonSocial")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCorto")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Ruc")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Estado")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PersonaNatural")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.btnGuardar = New Infragistics.Win.Misc.UltraButton
        Me.TxtNombreCorto = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.dgvProveedores = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.TxtNombreCorto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.btnGuardar)
        Me.UltraGroupBox1.Controls.Add(Me.TxtNombreCorto)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.dgvProveedores)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(734, 449)
        Me.UltraGroupBox1.TabIndex = 8
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnGuardar
        '
        Appearance124.Image = CType(resources.GetObject("Appearance124.Image"), Object)
        Appearance124.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance124.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance124.TextHAlignAsString = "Right"
        Appearance124.TextVAlignAsString = "Middle"
        Me.btnGuardar.Appearance = Appearance124
        Me.btnGuardar.Location = New System.Drawing.Point(648, 410)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(72, 30)
        Me.btnGuardar.TabIndex = 101
        Me.btnGuardar.Text = "Guardar"
        '
        'TxtNombreCorto
        '
        Me.TxtNombreCorto.Location = New System.Drawing.Point(110, 415)
        Me.TxtNombreCorto.Name = "TxtNombreCorto"
        Me.TxtNombreCorto.Size = New System.Drawing.Size(513, 21)
        Me.TxtNombreCorto.TabIndex = 87
        '
        'UltraLabel1
        '
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Appearance20.FontData.BoldAsString = "True"
        Me.UltraLabel1.Appearance = Appearance20
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(10, 415)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(78, 14)
        Me.UltraLabel1.TabIndex = 86
        Me.UltraLabel1.Text = "Nombre Corto"
        '
        'dgvProveedores
        '
        Me.dgvProveedores.DataSource = Me.UltraDataSource1
        Appearance2.BackColor = System.Drawing.Color.White
        Me.dgvProveedores.DisplayLayout.Appearance = Appearance2
        Me.dgvProveedores.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.ColHeaderLines = 2
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance1.FontData.BoldAsString = "False"
        Appearance1.FontData.SizeInPoints = 8.0!
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        UltraGridColumn1.CellAppearance = Appearance1
        Appearance3.FontData.BoldAsString = "False"
        Appearance3.FontData.SizeInPoints = 8.0!
        UltraGridColumn1.Header.Appearance = Appearance3
        UltraGridColumn1.Header.Caption = "Código"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 69
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.FontData.BoldAsString = "False"
        Appearance9.FontData.SizeInPoints = 8.0!
        UltraGridColumn2.CellAppearance = Appearance9
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance10.FontData.BoldAsString = "False"
        Appearance10.FontData.SizeInPoints = 8.0!
        UltraGridColumn2.Header.Appearance = Appearance10
        UltraGridColumn2.Header.Caption = "Razón Social"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 200
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance11.FontData.BoldAsString = "False"
        Appearance11.FontData.SizeInPoints = 8.0!
        UltraGridColumn3.CellAppearance = Appearance11
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.FontData.SizeInPoints = 8.0!
        UltraGridColumn3.Header.Appearance = Appearance12
        UltraGridColumn3.Header.Caption = "Nombre Corto"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 165
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance13.FontData.BoldAsString = "False"
        Appearance13.FontData.SizeInPoints = 8.0!
        UltraGridColumn4.CellAppearance = Appearance13
        Appearance14.FontData.BoldAsString = "False"
        Appearance14.FontData.SizeInPoints = 8.0!
        UltraGridColumn4.Header.Appearance = Appearance14
        UltraGridColumn4.Header.Caption = "RUC"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 96
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance16.FontData.BoldAsString = "False"
        Appearance16.FontData.SizeInPoints = 8.0!
        UltraGridColumn5.CellAppearance = Appearance16
        UltraGridColumn5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance17.FontData.BoldAsString = "False"
        Appearance17.FontData.SizeInPoints = 8.0!
        UltraGridColumn5.Header.Appearance = Appearance17
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 99
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance18.FontData.BoldAsString = "False"
        Appearance18.FontData.SizeInPoints = 8.0!
        Appearance18.TextHAlignAsString = "Center"
        Appearance18.TextVAlignAsString = "Middle"
        UltraGridColumn6.CellAppearance = Appearance18
        UltraGridColumn6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance19.FontData.BoldAsString = "False"
        Appearance19.FontData.SizeInPoints = 8.0!
        UltraGridColumn6.Header.Appearance = Appearance19
        UltraGridColumn6.Header.Caption = "Persona Natural"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 65
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
        Me.dgvProveedores.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvProveedores.DisplayLayout.InterBandSpacing = 18
        Me.dgvProveedores.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvProveedores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.dgvProveedores.DisplayLayout.Override.CardAreaAppearance = Appearance4
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.FontData.SizeInPoints = 9.0!
        Appearance5.ForeColor = System.Drawing.Color.Navy
        Me.dgvProveedores.DisplayLayout.Override.CellAppearance = Appearance5
        Me.dgvProveedores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.dgvProveedores.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance6.BackColor = System.Drawing.Color.Navy
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.ItalicAsString = "False"
        Appearance6.FontData.SizeInPoints = 10.0!
        Appearance6.ForeColor = System.Drawing.Color.White
        Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvProveedores.DisplayLayout.Override.HeaderAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.Color.Navy
        Appearance7.BorderColor = System.Drawing.Color.White
        Appearance7.ForeColor = System.Drawing.Color.White
        Me.dgvProveedores.DisplayLayout.Override.RowSelectorAppearance = Appearance7
        Me.dgvProveedores.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvProveedores.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance8.BackColor = System.Drawing.Color.Navy
        Appearance8.ForeColor = System.Drawing.Color.White
        Me.dgvProveedores.DisplayLayout.Override.SelectedRowAppearance = Appearance8
        Me.dgvProveedores.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvProveedores.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvProveedores.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvProveedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvProveedores.Location = New System.Drawing.Point(10, 45)
        Me.dgvProveedores.Name = "dgvProveedores"
        Me.dgvProveedores.Size = New System.Drawing.Size(715, 360)
        Me.dgvProveedores.TabIndex = 85
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12})
        '
        'UltraLabel4
        '
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance15.ForeColor = System.Drawing.Color.White
        Appearance15.TextHAlignAsString = "Center"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance15
        Me.UltraLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(0, 10)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(734, 25)
        Me.UltraLabel4.TabIndex = 82
        Me.UltraLabel4.Text = "Lista de Proveedores"
        '
        'FrmProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 449)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmProveedores"
        Me.Text = " Lista de Proveedores"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.TxtNombreCorto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvProveedores As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents TxtNombreCorto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnGuardar As Infragistics.Win.Misc.UltraButton
End Class
