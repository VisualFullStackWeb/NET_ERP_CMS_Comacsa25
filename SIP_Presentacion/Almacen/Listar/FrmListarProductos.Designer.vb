<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListarProductos
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
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UM")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UMCompra")
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoProducto")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Origen", 0)
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descripcion")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UM")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Stock")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UMCompra")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoProducto")
        Dim Appearance110 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListarProductos))
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.DgvListaProductos = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.TxtDescripcionProducto = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.TxtCodigoProducto = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.BtNuevo = New Infragistics.Win.Misc.UltraButton
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.GrpProductoNuevo = New Infragistics.Win.Misc.UltraGroupBox
        Me.CmbUM = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.btnSalir = New Infragistics.Win.Misc.UltraButton
        Me.btnGuardar = New Infragistics.Win.Misc.UltraButton
        Me.TxtStock = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.TxtDescripcion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.TxtCodigo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.DgvListaProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDescripcionProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodigoProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrpProductoNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpProductoNuevo.SuspendLayout()
        CType(Me.CmbUM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.DgvListaProductos)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox1.Controls.Add(Me.TxtDescripcionProducto)
        Me.UltraGroupBox1.Controls.Add(Me.TxtCodigoProducto)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel8)
        Me.UltraGroupBox1.Controls.Add(Me.BtNuevo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.GrpProductoNuevo)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(734, 423)
        Me.UltraGroupBox1.TabIndex = 7
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'DgvListaProductos
        '
        Me.DgvListaProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvListaProductos.DataSource = Me.UltraDataSource1
        Appearance44.BackColor = System.Drawing.Color.White
        Me.DgvListaProductos.DisplayLayout.Appearance = Appearance44
        Me.DgvListaProductos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.ColHeaderLines = 2
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance19.FontData.BoldAsString = "False"
        Appearance19.FontData.SizeInPoints = 8.0!
        Appearance19.TextHAlignAsString = "Center"
        Appearance19.TextVAlignAsString = "Middle"
        UltraGridColumn1.CellAppearance = Appearance19
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance21.FontData.BoldAsString = "False"
        Appearance21.FontData.SizeInPoints = 8.0!
        UltraGridColumn1.Header.Appearance = Appearance21
        UltraGridColumn1.Header.Caption = "Código"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.MaxWidth = 90
        UltraGridColumn1.MinWidth = 90
        UltraGridColumn1.Width = 90
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance22.FontData.BoldAsString = "False"
        Appearance22.FontData.SizeInPoints = 8.0!
        UltraGridColumn2.CellAppearance = Appearance22
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance23.FontData.BoldAsString = "False"
        Appearance23.FontData.SizeInPoints = 8.0!
        UltraGridColumn2.Header.Appearance = Appearance23
        UltraGridColumn2.Header.Caption = "Descripción"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.MinWidth = 385
        UltraGridColumn2.Width = 404
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance24.FontData.BoldAsString = "False"
        Appearance24.FontData.SizeInPoints = 8.0!
        Appearance24.TextHAlignAsString = "Center"
        Appearance24.TextVAlignAsString = "Middle"
        UltraGridColumn3.CellAppearance = Appearance24
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance25.FontData.BoldAsString = "False"
        Appearance25.FontData.SizeInPoints = 8.0!
        UltraGridColumn3.Header.Appearance = Appearance25
        UltraGridColumn3.Header.VisiblePosition = 4
        UltraGridColumn3.MaxWidth = 50
        UltraGridColumn3.MinWidth = 50
        UltraGridColumn3.Width = 50
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance26.FontData.BoldAsString = "False"
        Appearance26.FontData.SizeInPoints = 8.0!
        Appearance26.TextHAlignAsString = "Right"
        Appearance26.TextVAlignAsString = "Middle"
        UltraGridColumn4.CellAppearance = Appearance26
        UltraGridColumn4.Format = "n4"
        Appearance27.FontData.BoldAsString = "False"
        Appearance27.FontData.SizeInPoints = 8.0!
        UltraGridColumn4.Header.Appearance = Appearance27
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.MaxWidth = 100
        UltraGridColumn4.MinWidth = 100
        UltraGridColumn4.Width = 100
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance28.FontData.BoldAsString = "False"
        Appearance28.FontData.SizeInPoints = 8.0!
        Appearance28.TextHAlignAsString = "Center"
        Appearance28.TextVAlignAsString = "Middle"
        UltraGridColumn5.CellAppearance = Appearance28
        UltraGridColumn5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance29.FontData.BoldAsString = "False"
        Appearance29.FontData.SizeInPoints = 8.0!
        UltraGridColumn5.Header.Appearance = Appearance29
        UltraGridColumn5.Header.Caption = "UM Compra"
        UltraGridColumn5.Header.VisiblePosition = 2
        UltraGridColumn5.MaxWidth = 50
        UltraGridColumn5.MinWidth = 50
        UltraGridColumn5.Width = 50
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.Header.Caption = "T. Prod"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 19
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance30.FontData.BoldAsString = "False"
        UltraGridColumn7.CellAppearance = Appearance30
        UltraGridColumn7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.MaxWidth = 100
        UltraGridColumn7.MinWidth = 100
        UltraGridColumn7.Width = 100
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7})
        Me.DgvListaProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.DgvListaProductos.DisplayLayout.InterBandSpacing = 18
        Me.DgvListaProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.DgvListaProductos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Appearance45.BackColor = System.Drawing.Color.Transparent
        Me.DgvListaProductos.DisplayLayout.Override.CardAreaAppearance = Appearance45
        Appearance46.FontData.BoldAsString = "True"
        Appearance46.FontData.SizeInPoints = 9.0!
        Appearance46.ForeColor = System.Drawing.Color.Navy
        Me.DgvListaProductos.DisplayLayout.Override.CellAppearance = Appearance46
        Me.DgvListaProductos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.DgvListaProductos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance47.BackColor = System.Drawing.Color.Navy
        Appearance47.FontData.BoldAsString = "True"
        Appearance47.FontData.ItalicAsString = "False"
        Appearance47.FontData.SizeInPoints = 10.0!
        Appearance47.ForeColor = System.Drawing.Color.White
        Appearance47.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.DgvListaProductos.DisplayLayout.Override.HeaderAppearance = Appearance47
        Appearance48.BackColor = System.Drawing.Color.Navy
        Appearance48.BorderColor = System.Drawing.Color.White
        Appearance48.ForeColor = System.Drawing.Color.White
        Me.DgvListaProductos.DisplayLayout.Override.RowSelectorAppearance = Appearance48
        Me.DgvListaProductos.DisplayLayout.Override.RowSpacingAfter = 4
        Me.DgvListaProductos.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance49.BackColor = System.Drawing.Color.Navy
        Appearance49.ForeColor = System.Drawing.Color.White
        Me.DgvListaProductos.DisplayLayout.Override.SelectedRowAppearance = Appearance49
        Me.DgvListaProductos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.DgvListaProductos.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.DgvListaProductos.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.DgvListaProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgvListaProductos.Location = New System.Drawing.Point(10, 80)
        Me.DgvListaProductos.Name = "DgvListaProductos"
        Me.DgvListaProductos.Size = New System.Drawing.Size(715, 335)
        Me.DgvListaProductos.TabIndex = 83
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6})
        '
        'UltraLabel6
        '
        Appearance110.BackColor = System.Drawing.Color.Transparent
        Appearance110.TextHAlignAsString = "Center"
        Appearance110.TextVAlignAsString = "Top"
        Me.UltraLabel6.Appearance = Appearance110
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(167, 50)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(63, 14)
        Me.UltraLabel6.TabIndex = 88
        Me.UltraLabel6.Text = "Descripción"
        '
        'TxtDescripcionProducto
        '
        Appearance56.TextHAlignAsString = "Left"
        Appearance56.TextVAlignAsString = "Middle"
        Me.TxtDescripcionProducto.Appearance = Appearance56
        Me.TxtDescripcionProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcionProducto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtDescripcionProducto.Location = New System.Drawing.Point(235, 50)
        Me.TxtDescripcionProducto.MaxLength = 0
        Me.TxtDescripcionProducto.Name = "TxtDescripcionProducto"
        Me.TxtDescripcionProducto.Size = New System.Drawing.Size(490, 21)
        Me.TxtDescripcionProducto.TabIndex = 87
        '
        'TxtCodigoProducto
        '
        Appearance20.TextHAlignAsString = "Center"
        Appearance20.TextVAlignAsString = "Middle"
        Me.TxtCodigoProducto.Appearance = Appearance20
        Me.TxtCodigoProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodigoProducto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtCodigoProducto.Location = New System.Drawing.Point(65, 50)
        Me.TxtCodigoProducto.MaxLength = 8
        Me.TxtCodigoProducto.Name = "TxtCodigoProducto"
        Me.TxtCodigoProducto.Size = New System.Drawing.Size(85, 21)
        Me.TxtCodigoProducto.TabIndex = 86
        '
        'UltraLabel8
        '
        Appearance33.BackColor = System.Drawing.Color.Transparent
        Appearance33.TextHAlignAsString = "Center"
        Appearance33.TextVAlignAsString = "Top"
        Me.UltraLabel8.Appearance = Appearance33
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Location = New System.Drawing.Point(10, 50)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(40, 14)
        Me.UltraLabel8.TabIndex = 85
        Me.UltraLabel8.Text = "Código"
        '
        'BtNuevo
        '
        Me.BtNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance11.Image = CType(resources.GetObject("Appearance11.Image"), Object)
        Appearance11.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance11.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance11.TextHAlignAsString = "Right"
        Appearance11.TextVAlignAsString = "Middle"
        Me.BtNuevo.Appearance = Appearance11
        Me.BtNuevo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtNuevo.Location = New System.Drawing.Point(660, 11)
        Me.BtNuevo.Name = "BtNuevo"
        Me.BtNuevo.Size = New System.Drawing.Size(64, 27)
        Me.BtNuevo.TabIndex = 84
        Me.BtNuevo.Text = "Nuevo"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance15.ForeColor = System.Drawing.Color.White
        Appearance15.TextHAlignAsString = "Center"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance15
        Me.UltraLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(0, 10)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(734, 29)
        Me.UltraLabel4.TabIndex = 82
        Me.UltraLabel4.Text = "Lista de Productos"
        '
        'GrpProductoNuevo
        '
        Me.GrpProductoNuevo.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.GrpProductoNuevo.Controls.Add(Me.CmbUM)
        Me.GrpProductoNuevo.Controls.Add(Me.btnSalir)
        Me.GrpProductoNuevo.Controls.Add(Me.btnGuardar)
        Me.GrpProductoNuevo.Controls.Add(Me.TxtStock)
        Me.GrpProductoNuevo.Controls.Add(Me.TxtDescripcion)
        Me.GrpProductoNuevo.Controls.Add(Me.TxtCodigo)
        Me.GrpProductoNuevo.Controls.Add(Me.UltraLabel5)
        Me.GrpProductoNuevo.Controls.Add(Me.UltraLabel3)
        Me.GrpProductoNuevo.Controls.Add(Me.UltraLabel2)
        Me.GrpProductoNuevo.Controls.Add(Me.UltraLabel1)
        Me.GrpProductoNuevo.Location = New System.Drawing.Point(128, 146)
        Me.GrpProductoNuevo.Name = "GrpProductoNuevo"
        Me.GrpProductoNuevo.Size = New System.Drawing.Size(438, 162)
        Me.GrpProductoNuevo.TabIndex = 8
        Me.GrpProductoNuevo.Text = "PRODUCTO NUEVO"
        Me.GrpProductoNuevo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        Me.GrpProductoNuevo.Visible = False
        '
        'CmbUM
        '
        Me.CmbUM.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CmbUM.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.CmbUM.Location = New System.Drawing.Point(100, 95)
        Me.CmbUM.Name = "CmbUM"
        Me.CmbUM.Size = New System.Drawing.Size(150, 21)
        Me.CmbUM.TabIndex = 105
        '
        'btnSalir
        '
        Appearance125.Image = CType(resources.GetObject("Appearance125.Image"), Object)
        Appearance125.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance125.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance125.TextHAlignAsString = "Right"
        Appearance125.TextVAlignAsString = "Middle"
        Me.btnSalir.Appearance = Appearance125
        Me.btnSalir.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnSalir.Location = New System.Drawing.Point(360, 113)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(60, 30)
        Me.btnSalir.TabIndex = 104
        Me.btnSalir.Text = "Salir"
        '
        'btnGuardar
        '
        Appearance124.Image = CType(resources.GetObject("Appearance124.Image"), Object)
        Appearance124.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance124.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance124.TextHAlignAsString = "Right"
        Appearance124.TextVAlignAsString = "Middle"
        Me.btnGuardar.Appearance = Appearance124
        Me.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.btnGuardar.Location = New System.Drawing.Point(282, 113)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(72, 30)
        Me.btnGuardar.TabIndex = 103
        Me.btnGuardar.Text = "Guardar"
        '
        'TxtStock
        '
        Me.TxtStock.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtStock.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtStock.Location = New System.Drawing.Point(100, 125)
        Me.TxtStock.MaskInput = "{double:-9.4}"
        Me.TxtStock.Name = "TxtStock"
        Me.TxtStock.Nullable = True
        Me.TxtStock.NullText = "0"
        Me.TxtStock.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.TxtStock.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtStock.Size = New System.Drawing.Size(80, 21)
        Me.TxtStock.TabIndex = 19
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtDescripcion.Location = New System.Drawing.Point(100, 65)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(320, 21)
        Me.TxtDescripcion.TabIndex = 5
        '
        'TxtCodigo
        '
        Appearance9.TextHAlignAsString = "Center"
        Appearance9.TextVAlignAsString = "Middle"
        Me.TxtCodigo.Appearance = Appearance9
        Me.TxtCodigo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtCodigo.Location = New System.Drawing.Point(100, 36)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.ReadOnly = True
        Me.TxtCodigo.Size = New System.Drawing.Size(80, 21)
        Me.TxtCodigo.TabIndex = 4
        Me.TxtCodigo.Text = "00000000"
        '
        'UltraLabel5
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel5.Appearance = Appearance5
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(41, 125)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(56, 14)
        Me.UltraLabel5.TabIndex = 3
        Me.UltraLabel5.Text = "Cantidad :"
        '
        'UltraLabel3
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel3.Appearance = Appearance6
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(66, 95)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(28, 14)
        Me.UltraLabel3.TabIndex = 2
        Me.UltraLabel3.Text = "UM :"
        '
        'UltraLabel2
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance7
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(29, 65)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(70, 14)
        Me.UltraLabel2.TabIndex = 1
        Me.UltraLabel2.Text = "Descripción :"
        '
        'UltraLabel1
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance8
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(51, 35)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(46, 14)
        Me.UltraLabel1.TabIndex = 0
        Me.UltraLabel1.Text = "Código :"
        '
        'FrmListarProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(734, 423)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmListarProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Lista de Productos"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.DgvListaProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDescripcionProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodigoProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrpProductoNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpProductoNuevo.ResumeLayout(False)
        Me.GrpProductoNuevo.PerformLayout()
        CType(Me.CmbUM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DgvListaProductos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents BtNuevo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GrpProductoNuevo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents TxtCodigo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtDescripcion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents TxtStock As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents btnSalir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGuardar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents CmbUM As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtDescripcionProducto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents TxtCodigoProducto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
End Class
