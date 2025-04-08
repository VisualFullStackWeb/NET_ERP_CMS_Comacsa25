<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpEtiquetaQR
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Accion")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImpEtiquetaQR))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_Prod", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descrip", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Unidad", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ubicacion", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Almacen", 4)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1141)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1141)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(839)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(839)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1006)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1006)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.chk_ListarSinStock = New System.Windows.Forms.CheckBox
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.gridproducto = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtCodProd = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.lblFiltros = New System.Windows.Forms.Label
        Me.rbtListaProducto = New System.Windows.Forms.RadioButton
        Me.rbtProducto = New System.Windows.Forms.RadioButton
        Me.cboProductos = New System.Windows.Forms.ComboBox
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridproducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.txtCodProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 34)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1146, 530)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.chk_ListarSinStock)
        Me.Panel1.Controls.Add(Me.btnImprimir)
        Me.Panel1.Controls.Add(Me.gridproducto)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1146, 530)
        Me.Panel1.TabIndex = 176
        '
        'chk_ListarSinStock
        '
        Me.chk_ListarSinStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk_ListarSinStock.Location = New System.Drawing.Point(164, 489)
        Me.chk_ListarSinStock.Name = "chk_ListarSinStock"
        Me.chk_ListarSinStock.Size = New System.Drawing.Size(172, 23)
        Me.chk_ListarSinStock.TabIndex = 170
        Me.chk_ListarSinStock.Text = "Listar Productos SIN Stock"
        Me.chk_ListarSinStock.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Location = New System.Drawing.Point(11, 481)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(122, 31)
        Me.btnImprimir.TabIndex = 168
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'gridproducto
        '
        Me.gridproducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridproducto.DisplayLayout.Appearance = Appearance1
        Me.gridproducto.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance5
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.Caption = "COD. PROD."
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.Width = 110
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "PRODUCTO"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.Width = 410
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "UNIDAD"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn4.Width = 136
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.Caption = "UBICACIÓN"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn5.Width = 231
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.Caption = "ALMACÉN"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn6.Width = 196
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
        Me.gridproducto.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridproducto.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridproducto.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridproducto.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance8.BorderColor = System.Drawing.SystemColors.Window
        Me.gridproducto.DisplayLayout.GroupByBox.Appearance = Appearance8
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridproducto.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance11
        Me.gridproducto.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridproducto.DisplayLayout.GroupByBox.Hidden = True
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance19.BackColor2 = System.Drawing.SystemColors.Control
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridproducto.DisplayLayout.GroupByBox.PromptAppearance = Appearance19
        Me.gridproducto.DisplayLayout.MaxColScrollRegions = 1
        Me.gridproducto.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridproducto.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridproducto.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridproducto.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Me.gridproducto.DisplayLayout.Override.CardAreaAppearance = Appearance22
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridproducto.DisplayLayout.Override.CellAppearance = Appearance24
        Me.gridproducto.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridproducto.DisplayLayout.Override.CellPadding = 0
        Me.gridproducto.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridproducto.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridproducto.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridproducto.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance25.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance25.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridproducto.DisplayLayout.Override.FilterRowAppearance = Appearance25
        Me.gridproducto.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridproducto.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridproducto.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance26.BackColor = System.Drawing.SystemColors.Control
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.gridproducto.DisplayLayout.Override.GroupByRowAppearance = Appearance26
        Appearance27.FontData.Name = "Arial Narrow"
        Appearance27.FontData.SizeInPoints = 10.0!
        Appearance27.TextHAlignAsString = "Left"
        Me.gridproducto.DisplayLayout.Override.HeaderAppearance = Appearance27
        Me.gridproducto.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridproducto.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridproducto.DisplayLayout.Override.MinRowHeight = 24
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance28.TextVAlignAsString = "Middle"
        Me.gridproducto.DisplayLayout.Override.RowAppearance = Appearance28
        Me.gridproducto.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridproducto.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridproducto.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance29.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridproducto.DisplayLayout.Override.TemplateAddRowAppearance = Appearance29
        Me.gridproducto.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridproducto.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridproducto.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridproducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridproducto.Location = New System.Drawing.Point(3, 41)
        Me.gridproducto.Name = "gridproducto"
        Me.gridproducto.Size = New System.Drawing.Size(1143, 430)
        Me.gridproducto.TabIndex = 159
        Me.gridproducto.Text = "UltraGrid1"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.txtCodProd)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Controls.Add(Me.lblFiltros)
        Me.Panel2.Controls.Add(Me.rbtListaProducto)
        Me.Panel2.Controls.Add(Me.rbtProducto)
        Me.Panel2.Controls.Add(Me.cboProductos)
        Me.Panel2.Location = New System.Drawing.Point(0, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1146, 36)
        Me.Panel2.TabIndex = 167
        Me.Panel2.Visible = False
        '
        'txtCodProd
        '
        Appearance20.TextHAlignAsString = "Left"
        Appearance20.TextVAlignAsString = "Middle"
        Me.txtCodProd.Appearance = Appearance20
        Me.txtCodProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodProd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtCodProd.Location = New System.Drawing.Point(637, 8)
        Me.txtCodProd.Name = "txtCodProd"
        Me.txtCodProd.ReadOnly = True
        Me.txtCodProd.Size = New System.Drawing.Size(179, 21)
        Me.txtCodProd.TabIndex = 235
        Me.txtCodProd.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(1015, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(122, 31)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblFiltros
        '
        Me.lblFiltros.AutoSize = True
        Me.lblFiltros.Location = New System.Drawing.Point(34, 12)
        Me.lblFiltros.Name = "lblFiltros"
        Me.lblFiltros.Size = New System.Drawing.Size(34, 13)
        Me.lblFiltros.TabIndex = 2
        Me.lblFiltros.Text = "Filtros"
        '
        'rbtListaProducto
        '
        Me.rbtListaProducto.AutoSize = True
        Me.rbtListaProducto.Location = New System.Drawing.Point(523, 10)
        Me.rbtListaProducto.Name = "rbtListaProducto"
        Me.rbtListaProducto.Size = New System.Drawing.Size(113, 17)
        Me.rbtListaProducto.TabIndex = 1
        Me.rbtListaProducto.Text = "Lista de Productos"
        Me.rbtListaProducto.UseVisualStyleBackColor = True
        '
        'rbtProducto
        '
        Me.rbtProducto.AutoSize = True
        Me.rbtProducto.Checked = True
        Me.rbtProducto.Location = New System.Drawing.Point(79, 10)
        Me.rbtProducto.Name = "rbtProducto"
        Me.rbtProducto.Size = New System.Drawing.Size(119, 17)
        Me.rbtProducto.TabIndex = 0
        Me.rbtProducto.TabStop = True
        Me.rbtProducto.Text = "Codigo de Producto"
        Me.rbtProducto.UseVisualStyleBackColor = True
        '
        'cboProductos
        '
        Me.cboProductos.BackColor = System.Drawing.Color.White
        Me.cboProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProductos.FormattingEnabled = True
        Me.cboProductos.Location = New System.Drawing.Point(201, 8)
        Me.cboProductos.Name = "cboProductos"
        Me.cboProductos.Size = New System.Drawing.Size(279, 21)
        Me.cboProductos.TabIndex = 236
        Me.cboProductos.Visible = False
        '
        'Tab1
        '
        Appearance17.FontData.BoldAsString = "True"
        Appearance17.FontData.Name = "Arial Narrow"
        Appearance17.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance17
        Appearance18.FontData.Name = "Arial Narrow"
        Appearance18.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance18
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(1150, 567)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance3
        Me.Tab1.TabIndex = 16
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance4.Cursor = System.Windows.Forms.Cursors.Default
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.Name = "Arial Narrow"
        Appearance4.FontData.SizeInPoints = 16.0!
        UltraTab3.ActiveAppearance = Appearance4
        Appearance43.FontData.Name = "Arial Narrow"
        Appearance43.FontData.SizeInPoints = 10.0!
        UltraTab3.Appearance = Appearance43
        UltraTab3.Key = "T01"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "IMPRIMIR ETIQUETA QR"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1146, 530)
        '
        'FrmImpEtiquetaQR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1150, 567)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmImpEtiquetaQR"
        Me.Text = "frmSustentoProducción"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.gridproducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.txtCodProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents gridproducto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtCodProd As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblFiltros As System.Windows.Forms.Label
    Friend WithEvents rbtListaProducto As System.Windows.Forms.RadioButton
    Friend WithEvents rbtProducto As System.Windows.Forms.RadioButton
    Friend WithEvents cboProductos As System.Windows.Forms.ComboBox
    Friend WithEvents chk_ListarSinStock As System.Windows.Forms.CheckBox
End Class
