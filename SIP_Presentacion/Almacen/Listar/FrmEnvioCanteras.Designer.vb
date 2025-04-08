<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnvioCanteras
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
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("cod_cantera")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nomcantera")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("numdoc")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fec_emision")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Action")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("cod_cantera")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("nomcantera")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("numdoc")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("fec_emision")
        Dim Appearance143 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEnvioCanteras))
        Dim Appearance144 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.dgvBilletesPendientes = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.btnCerrar = New Infragistics.Win.Misc.UltraButton
        Me.btnGuardar = New Infragistics.Win.Misc.UltraButton
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.dgvBilletesPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.dgvBilletesPendientes)
        Me.UltraGroupBox1.Controls.Add(Me.btnCerrar)
        Me.UltraGroupBox1.Controls.Add(Me.btnGuardar)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(604, 376)
        Me.UltraGroupBox1.TabIndex = 1
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'dgvBilletesPendientes
        '
        Me.dgvBilletesPendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBilletesPendientes.DataSource = Me.UltraDataSource1
        Appearance51.BackColor = System.Drawing.Color.White
        Me.dgvBilletesPendientes.DisplayLayout.Appearance = Appearance51
        Me.dgvBilletesPendientes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.ColHeaderLines = 2
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.FontData.SizeInPoints = 8.0!
        UltraGridColumn1.Header.Appearance = Appearance12
        UltraGridColumn1.Header.Caption = "X"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.MaxWidth = 35
        UltraGridColumn1.MinWidth = 35
        UltraGridColumn1.RowLayoutColumnInfo.OriginX = 0
        UltraGridColumn1.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 35
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.FontData.BoldAsString = "False"
        Appearance13.FontData.SizeInPoints = 8.0!
        Appearance13.TextHAlignAsString = "Center"
        Appearance13.TextVAlignAsString = "Middle"
        UltraGridColumn2.CellAppearance = Appearance13
        Appearance14.FontData.BoldAsString = "False"
        Appearance14.FontData.SizeInPoints = 8.0!
        UltraGridColumn2.Header.Appearance = Appearance14
        UltraGridColumn2.Header.Caption = "Código" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cantera"
        UltraGridColumn2.Header.VisiblePosition = 3
        UltraGridColumn2.MaxWidth = 80
        UltraGridColumn2.MinWidth = 80
        UltraGridColumn2.Width = 80
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance16.FontData.BoldAsString = "False"
        Appearance16.FontData.SizeInPoints = 8.0!
        Appearance16.TextHAlignAsString = "Left"
        Appearance16.TextVAlignAsString = "Middle"
        UltraGridColumn3.CellAppearance = Appearance16
        Appearance17.FontData.BoldAsString = "False"
        Appearance17.FontData.SizeInPoints = 8.0!
        UltraGridColumn3.Header.Appearance = Appearance17
        UltraGridColumn3.Header.Caption = "Cantera"
        UltraGridColumn3.Header.VisiblePosition = 4
        UltraGridColumn3.MinWidth = 250
        UltraGridColumn3.RowLayoutColumnInfo.OriginX = 8
        UltraGridColumn3.RowLayoutColumnInfo.OriginY = 4
        UltraGridColumn3.RowLayoutColumnInfo.SpanX = 4
        UltraGridColumn3.Width = 254
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance18.FontData.BoldAsString = "False"
        Appearance18.FontData.SizeInPoints = 8.0!
        Appearance18.TextHAlignAsString = "Center"
        Appearance18.TextVAlignAsString = "Middle"
        UltraGridColumn4.CellAppearance = Appearance18
        Appearance19.TextHAlignAsString = "Center"
        Appearance19.TextVAlignAsString = "Middle"
        UltraGridColumn4.CellButtonAppearance = Appearance19
        Appearance20.FontData.BoldAsString = "False"
        Appearance20.FontData.SizeInPoints = 8.0!
        UltraGridColumn4.Header.Appearance = Appearance20
        UltraGridColumn4.Header.Caption = "Nro Billete"
        UltraGridColumn4.Header.VisiblePosition = 1
        UltraGridColumn4.MaxWidth = 95
        UltraGridColumn4.MinWidth = 95
        UltraGridColumn4.Width = 95
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance21.FontData.BoldAsString = "False"
        Appearance21.FontData.SizeInPoints = 8.0!
        Appearance21.TextHAlignAsString = "Center"
        Appearance21.TextVAlignAsString = "Middle"
        UltraGridColumn5.CellAppearance = Appearance21
        Appearance22.FontData.BoldAsString = "False"
        Appearance22.FontData.SizeInPoints = 8.0!
        UltraGridColumn5.Header.Appearance = Appearance22
        UltraGridColumn5.Header.Caption = "Fecha de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Emisión"
        UltraGridColumn5.Header.VisiblePosition = 2
        UltraGridColumn5.MaxWidth = 100
        UltraGridColumn5.MinWidth = 100
        UltraGridColumn5.Width = 100
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Appearance23.FontData.BoldAsString = "True"
        Appearance23.FontData.SizeInPoints = 9.0!
        UltraGridBand1.Header.Appearance = Appearance23
        Me.dgvBilletesPendientes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvBilletesPendientes.DisplayLayout.InterBandSpacing = 18
        Me.dgvBilletesPendientes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance86.BackColor = System.Drawing.Color.Transparent
        Me.dgvBilletesPendientes.DisplayLayout.Override.CardAreaAppearance = Appearance86
        Appearance89.FontData.BoldAsString = "True"
        Appearance89.FontData.SizeInPoints = 9.0!
        Appearance89.ForeColor = System.Drawing.Color.Navy
        Me.dgvBilletesPendientes.DisplayLayout.Override.CellAppearance = Appearance89
        Appearance91.BackColor = System.Drawing.Color.Navy
        Appearance91.FontData.BoldAsString = "True"
        Appearance91.FontData.ItalicAsString = "False"
        Appearance91.FontData.SizeInPoints = 10.0!
        Appearance91.ForeColor = System.Drawing.Color.White
        Appearance91.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvBilletesPendientes.DisplayLayout.Override.HeaderAppearance = Appearance91
        Appearance94.BackColor = System.Drawing.Color.Navy
        Appearance94.BorderColor = System.Drawing.Color.White
        Appearance94.ForeColor = System.Drawing.Color.White
        Me.dgvBilletesPendientes.DisplayLayout.Override.RowSelectorAppearance = Appearance94
        Me.dgvBilletesPendientes.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvBilletesPendientes.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance95.BackColor = System.Drawing.Color.Navy
        Appearance95.ForeColor = System.Drawing.Color.White
        Me.dgvBilletesPendientes.DisplayLayout.Override.SelectedRowAppearance = Appearance95
        Me.dgvBilletesPendientes.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvBilletesPendientes.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvBilletesPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvBilletesPendientes.Location = New System.Drawing.Point(10, 45)
        Me.dgvBilletesPendientes.Name = "dgvBilletesPendientes"
        Me.dgvBilletesPendientes.Size = New System.Drawing.Size(585, 285)
        Me.dgvBilletesPendientes.TabIndex = 104
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5})
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance143.Image = CType(resources.GetObject("Appearance143.Image"), Object)
        Appearance143.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance143.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance143.TextHAlignAsString = "Right"
        Appearance143.TextVAlignAsString = "Middle"
        Me.btnCerrar.Appearance = Appearance143
        Me.btnCerrar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnCerrar.Location = New System.Drawing.Point(535, 336)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(60, 30)
        Me.btnCerrar.TabIndex = 103
        Me.btnCerrar.Text = "Salir"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance144.Image = CType(resources.GetObject("Appearance144.Image"), Object)
        Appearance144.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance144.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance144.TextHAlignAsString = "Right"
        Appearance144.TextVAlignAsString = "Middle"
        Me.btnGuardar.Appearance = Appearance144
        Me.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnGuardar.Location = New System.Drawing.Point(460, 336)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(72, 30)
        Me.btnGuardar.TabIndex = 102
        Me.btnGuardar.Text = "Guardar"
        '
        'UltraLabel4
        '
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance15.FontData.BoldAsString = "True"
        Appearance15.ForeColor = System.Drawing.Color.White
        Appearance15.TextHAlignAsString = "Center"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance15
        Me.UltraLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(0, 10)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(604, 25)
        Me.UltraLabel4.TabIndex = 84
        Me.UltraLabel4.Text = "Billetes de Alm. de Suministro Pendientes de envío a Canteras"
        '
        'FrmEnvioCanteras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 376)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEnvioCanteras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Billetes de Alm. de Suministro Pendientes de envío a Canteras"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.dgvBilletesPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnCerrar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGuardar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvBilletesPendientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
End Class
