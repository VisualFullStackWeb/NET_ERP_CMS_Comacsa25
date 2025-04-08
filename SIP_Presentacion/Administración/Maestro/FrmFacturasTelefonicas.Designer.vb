<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFacturasTelefonicas
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
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codprov", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("proveedor", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("numdoc", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("anio", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("mes", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("placod", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("persona", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("dscgrupo", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tipodoc", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("documento", 10)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("grupo", 11)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacturasTelefonicas))
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.GrdDatos = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Stb1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtNumDoc = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.rbtEmpleado = New System.Windows.Forms.RadioButton
        Me.rbtGrupo = New System.Windows.Forms.RadioButton
        Me.pnlEmpleado = New System.Windows.Forms.Panel
        Me.txtEmpCodigo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtEmpleado = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnBuscarEmpleado = New Infragistics.Win.Misc.UltraButton
        Me.pnlBolsa = New System.Windows.Forms.Panel
        Me.cmbGrupo = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.cmbTipoDoc = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.cmbProveedor = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.txtid = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtProvCodigo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtSerie = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.tabPrincipal = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Exportador = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.Ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.Btn1 = New System.Windows.Forms.ToolStripButton
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.GrdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Stb1.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.txtNumDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEmpleado.SuspendLayout()
        CType(Me.txtEmpCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBolsa.SuspendLayout()
        CType(Me.cmbGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProvCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPrincipal.SuspendLayout()
        CType(Me.Ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BackColor = System.Drawing.Color.Transparent
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorSeparator, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorMoveNextItem, Me.ToolStripSeparator5, Me.BindingNavigatorCountItem, Me.BindingNavigatorPositionItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorMoveFirstItem, Me.ToolStripSeparator6, Me.Btn1, Me.ToolStripSeparator2})
        Me.BindingNavigator1.Location = New System.Drawing.Point(2, 4)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(314, 25)
        Me.BindingNavigator1.TabIndex = 141
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.BackColor = System.Drawing.Color.White
        Me.BindingNavigatorPositionItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BindingNavigatorPositionItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.GrdDatos)
        Me.UltraTabPageControl1.Controls.Add(Me.Stb1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(801, 407)
        '
        'GrdDatos
        '
        Me.GrdDatos.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance105.BackColor = System.Drawing.SystemColors.Window
        Appearance105.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GrdDatos.DisplayLayout.Appearance = Appearance105
        Me.GrdDatos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance106.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance106.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance106
        UltraGridColumn1.Header.Caption = " "
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 25
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 25
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.Caption = "CODPROV"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 37
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "PROVEEDOR"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 225
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "NRO.DOCUMENTO"
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.Width = 45
        UltraGridColumn5.Header.Caption = "AÑO"
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 27
        UltraGridColumn6.Header.Caption = "MES"
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn6.Width = 40
        UltraGridColumn7.Header.Caption = "PLACOD"
        UltraGridColumn7.Header.VisiblePosition = 9
        UltraGridColumn7.Width = 52
        UltraGridColumn8.Header.Caption = "PERSONA"
        UltraGridColumn8.Header.VisiblePosition = 10
        UltraGridColumn8.Width = 95
        UltraGridColumn9.Header.Caption = "GRUPO"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 120
        UltraGridColumn10.Header.VisiblePosition = 11
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 50
        UltraGridColumn11.Header.Caption = "TIPODOC"
        UltraGridColumn11.Header.VisiblePosition = 3
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 46
        UltraGridColumn12.Header.Caption = "TIPO.DOC"
        UltraGridColumn12.Header.VisiblePosition = 4
        UltraGridColumn12.Width = 103
        UltraGridColumn13.Header.Caption = "COD_GRUPO"
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 95
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13})
        Me.GrdDatos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GrdDatos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GrdDatos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.GrdDatos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.GrdDatos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.GrdDatos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.GrdDatos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.GrdDatos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.GrdDatos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.GrdDatos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.GrdDatos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.GrdDatos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.GrdDatos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.GrdDatos.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance76.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance76.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance76.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance76.BorderColor = System.Drawing.SystemColors.Window
        Me.GrdDatos.DisplayLayout.GroupByBox.Appearance = Appearance76
        Appearance77.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GrdDatos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance77
        Me.GrdDatos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GrdDatos.DisplayLayout.GroupByBox.Hidden = True
        Appearance78.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance78.BackColor2 = System.Drawing.SystemColors.Control
        Appearance78.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance78.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GrdDatos.DisplayLayout.GroupByBox.PromptAppearance = Appearance78
        Me.GrdDatos.DisplayLayout.MaxColScrollRegions = 1
        Me.GrdDatos.DisplayLayout.MaxRowScrollRegions = 1
        Me.GrdDatos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GrdDatos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GrdDatos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance80.BackColor = System.Drawing.SystemColors.Window
        Me.GrdDatos.DisplayLayout.Override.CardAreaAppearance = Appearance80
        Appearance81.BorderColor = System.Drawing.Color.Silver
        Appearance81.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GrdDatos.DisplayLayout.Override.CellAppearance = Appearance81
        Me.GrdDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GrdDatos.DisplayLayout.Override.CellPadding = 0
        Me.GrdDatos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.GrdDatos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.GrdDatos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.GrdDatos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance82.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GrdDatos.DisplayLayout.Override.FilterRowAppearance = Appearance82
        Me.GrdDatos.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.GrdDatos.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.GrdDatos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance83.BackColor = System.Drawing.SystemColors.Control
        Appearance83.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance83.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance83.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance83.BorderColor = System.Drawing.SystemColors.Window
        Me.GrdDatos.DisplayLayout.Override.GroupByRowAppearance = Appearance83
        Appearance84.FontData.Name = "Arial Narrow"
        Appearance84.FontData.SizeInPoints = 10.0!
        Appearance84.TextHAlignAsString = "Left"
        Me.GrdDatos.DisplayLayout.Override.HeaderAppearance = Appearance84
        Me.GrdDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.GrdDatos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.GrdDatos.DisplayLayout.Override.MinRowHeight = 24
        Appearance85.BackColor = System.Drawing.SystemColors.Window
        Appearance85.BorderColor = System.Drawing.Color.Silver
        Appearance85.TextVAlignAsString = "Middle"
        Me.GrdDatos.DisplayLayout.Override.RowAppearance = Appearance85
        Me.GrdDatos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.GrdDatos.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.GrdDatos.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance86.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GrdDatos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance86
        Me.GrdDatos.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Both
        Me.GrdDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GrdDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GrdDatos.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.GrdDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdDatos.Location = New System.Drawing.Point(0, 30)
        Me.GrdDatos.Name = "GrdDatos"
        Me.GrdDatos.Size = New System.Drawing.Size(801, 377)
        Me.GrdDatos.TabIndex = 172
        Me.GrdDatos.Text = "UltraGrid1"
        '
        'Stb1
        '
        Me.Stb1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Stb1.Controls.Add(Me.BindingNavigator1)
        Me.Stb1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Stb1.Location = New System.Drawing.Point(0, 0)
        Me.Stb1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Stb1.Name = "Stb1"
        UltraStatusPanel1.Control = Me.BindingNavigator1
        UltraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        Me.Stb1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1})
        Me.Stb1.Size = New System.Drawing.Size(801, 30)
        Me.Stb1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Stb1.TabIndex = 171
        Me.Stb1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(801, 407)
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox2.ContentAreaAppearance = Appearance7
        Me.UltraGroupBox2.Controls.Add(Me.txtNumDoc)
        Me.UltraGroupBox2.Controls.Add(Me.rbtEmpleado)
        Me.UltraGroupBox2.Controls.Add(Me.rbtGrupo)
        Me.UltraGroupBox2.Controls.Add(Me.pnlEmpleado)
        Me.UltraGroupBox2.Controls.Add(Me.pnlBolsa)
        Me.UltraGroupBox2.Controls.Add(Me.cmbTipoDoc)
        Me.UltraGroupBox2.Controls.Add(Me.cmbProveedor)
        Me.UltraGroupBox2.Controls.Add(Me.txtid)
        Me.UltraGroupBox2.Controls.Add(Me.txtProvCodigo)
        Me.UltraGroupBox2.Controls.Add(Me.txtSerie)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel4)
        Appearance12.FontData.BoldAsString = "True"
        Appearance12.FontData.Name = "Arial Narrow"
        Appearance12.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox2.HeaderAppearance = Appearance12
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox2.Location = New System.Drawing.Point(10, 13)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(781, 380)
        Me.UltraGroupBox2.TabIndex = 10
        Me.UltraGroupBox2.Text = "Ingreso de Datos"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'txtNumDoc
        '
        Appearance10.TextHAlignAsString = "Left"
        Appearance10.TextVAlignAsString = "Middle"
        Me.txtNumDoc.Appearance = Appearance10
        Me.txtNumDoc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNumDoc.FormatString = "0000000000000000"
        Me.txtNumDoc.Location = New System.Drawing.Point(111, 163)
        Me.txtNumDoc.MinValue = 0
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(232, 21)
        Me.txtNumDoc.TabIndex = 5
        '
        'rbtEmpleado
        '
        Me.rbtEmpleado.AutoSize = True
        Me.rbtEmpleado.BackColor = System.Drawing.Color.Transparent
        Me.rbtEmpleado.Location = New System.Drawing.Point(17, 257)
        Me.rbtEmpleado.Name = "rbtEmpleado"
        Me.rbtEmpleado.Size = New System.Drawing.Size(72, 17)
        Me.rbtEmpleado.TabIndex = 8
        Me.rbtEmpleado.TabStop = True
        Me.rbtEmpleado.Text = "Empleado"
        Me.rbtEmpleado.UseVisualStyleBackColor = False
        '
        'rbtGrupo
        '
        Me.rbtGrupo.AutoSize = True
        Me.rbtGrupo.BackColor = System.Drawing.Color.Transparent
        Me.rbtGrupo.Checked = True
        Me.rbtGrupo.Location = New System.Drawing.Point(17, 203)
        Me.rbtGrupo.Name = "rbtGrupo"
        Me.rbtGrupo.Size = New System.Drawing.Size(51, 17)
        Me.rbtGrupo.TabIndex = 6
        Me.rbtGrupo.TabStop = True
        Me.rbtGrupo.Text = "Bolsa"
        Me.rbtGrupo.UseVisualStyleBackColor = False
        '
        'pnlEmpleado
        '
        Me.pnlEmpleado.Controls.Add(Me.txtEmpCodigo)
        Me.pnlEmpleado.Controls.Add(Me.txtEmpleado)
        Me.pnlEmpleado.Controls.Add(Me.btnBuscarEmpleado)
        Me.pnlEmpleado.Enabled = False
        Me.pnlEmpleado.Location = New System.Drawing.Point(111, 240)
        Me.pnlEmpleado.Name = "pnlEmpleado"
        Me.pnlEmpleado.Size = New System.Drawing.Size(490, 47)
        Me.pnlEmpleado.TabIndex = 186
        '
        'txtEmpCodigo
        '
        Appearance13.TextHAlignAsString = "Left"
        Appearance13.TextVAlignAsString = "Middle"
        Me.txtEmpCodigo.Appearance = Appearance13
        Me.txtEmpCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpCodigo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtEmpCodigo.Enabled = False
        Me.txtEmpCodigo.Location = New System.Drawing.Point(3, 11)
        Me.txtEmpCodigo.MaxLength = 500
        Me.txtEmpCodigo.Name = "txtEmpCodigo"
        Me.txtEmpCodigo.Size = New System.Drawing.Size(88, 21)
        Me.txtEmpCodigo.TabIndex = 9
        '
        'txtEmpleado
        '
        Appearance17.TextHAlignAsString = "Left"
        Appearance17.TextVAlignAsString = "Middle"
        Me.txtEmpleado.Appearance = Appearance17
        Me.txtEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpleado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtEmpleado.Enabled = False
        Me.txtEmpleado.Location = New System.Drawing.Point(97, 11)
        Me.txtEmpleado.MaxLength = 500
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.Size = New System.Drawing.Size(340, 21)
        Me.txtEmpleado.TabIndex = 10
        '
        'btnBuscarEmpleado
        '
        Appearance14.Image = Global.SIP_Presentacion.My.Resources.Resources.AYUDA3
        Appearance14.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnBuscarEmpleado.Appearance = Appearance14
        Me.btnBuscarEmpleado.Location = New System.Drawing.Point(443, 11)
        Me.btnBuscarEmpleado.Name = "btnBuscarEmpleado"
        Me.btnBuscarEmpleado.Size = New System.Drawing.Size(31, 23)
        Me.btnBuscarEmpleado.TabIndex = 11
        '
        'pnlBolsa
        '
        Me.pnlBolsa.Controls.Add(Me.cmbGrupo)
        Me.pnlBolsa.Location = New System.Drawing.Point(111, 190)
        Me.pnlBolsa.Name = "pnlBolsa"
        Me.pnlBolsa.Size = New System.Drawing.Size(490, 44)
        Me.pnlBolsa.TabIndex = 185
        '
        'cmbGrupo
        '
        Me.cmbGrupo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbGrupo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbGrupo.Location = New System.Drawing.Point(3, 13)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(434, 21)
        Me.cmbGrupo.TabIndex = 7
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbTipoDoc.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbTipoDoc.Location = New System.Drawing.Point(17, 113)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(326, 21)
        Me.cmbTipoDoc.TabIndex = 3
        '
        'cmbProveedor
        '
        Me.cmbProveedor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbProveedor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbProveedor.Location = New System.Drawing.Point(111, 63)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(437, 21)
        Me.cmbProveedor.TabIndex = 2
        '
        'txtid
        '
        Appearance15.TextHAlignAsString = "Left"
        Appearance15.TextVAlignAsString = "Middle"
        Me.txtid.Appearance = Appearance15
        Me.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtid.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtid.Location = New System.Drawing.Point(671, 36)
        Me.txtid.Name = "txtid"
        Me.txtid.ReadOnly = True
        Me.txtid.Size = New System.Drawing.Size(104, 21)
        Me.txtid.TabIndex = 0
        Me.txtid.TabStop = False
        Me.txtid.Text = "0"
        Me.txtid.Visible = False
        '
        'txtProvCodigo
        '
        Appearance4.TextHAlignAsString = "Left"
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtProvCodigo.Appearance = Appearance4
        Me.txtProvCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProvCodigo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtProvCodigo.Location = New System.Drawing.Point(17, 63)
        Me.txtProvCodigo.MaxLength = 8
        Me.txtProvCodigo.Name = "txtProvCodigo"
        Me.txtProvCodigo.Size = New System.Drawing.Size(88, 21)
        Me.txtProvCodigo.TabIndex = 1
        '
        'txtSerie
        '
        Appearance19.TextHAlignAsString = "Left"
        Appearance19.TextVAlignAsString = "Middle"
        Me.txtSerie.Appearance = Appearance19
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtSerie.Location = New System.Drawing.Point(17, 163)
        Me.txtSerie.MaxLength = 4
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(88, 21)
        Me.txtSerie.TabIndex = 4
        '
        'UltraLabel5
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance9
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel5.Location = New System.Drawing.Point(111, 140)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(85, 17)
        Me.UltraLabel5.TabIndex = 2
        Me.UltraLabel5.Text = "Nro. Documento"
        '
        'UltraLabel1
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance6
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(17, 90)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(101, 17)
        Me.UltraLabel1.TabIndex = 2
        Me.UltraLabel1.Text = "Tipo de Documento"
        '
        'UltraLabel6
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Right"
        Me.UltraLabel6.Appearance = Appearance5
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(21, 40)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(55, 17)
        Me.UltraLabel6.TabIndex = 2
        Me.UltraLabel6.Text = "Proveedor"
        '
        'UltraLabel4
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Right"
        Me.UltraLabel4.Appearance = Appearance11
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(21, 140)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(30, 17)
        Me.UltraLabel4.TabIndex = 2
        Me.UltraLabel4.Text = "Serie"
        '
        'tabPrincipal
        '
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.Name = "Arial Narrow"
        Appearance2.FontData.SizeInPoints = 16.0!
        Me.tabPrincipal.ActiveTabAppearance = Appearance2
        Appearance3.FontData.Name = "Arial Narrow"
        Appearance3.FontData.SizeInPoints = 10.0!
        Me.tabPrincipal.Appearance = Appearance3
        Me.tabPrincipal.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabPrincipal.Controls.Add(Me.UltraTabPageControl1)
        Me.tabPrincipal.Controls.Add(Me.UltraTabPageControl2)
        Me.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tabPrincipal.Name = "tabPrincipal"
        Me.tabPrincipal.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabPrincipal.Size = New System.Drawing.Size(805, 445)
        Me.tabPrincipal.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabPrincipal.TabHeaderAreaAppearance = Appearance1
        Me.tabPrincipal.TabIndex = 2
        Me.tabPrincipal.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab1.Key = "T01"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Listado de Facturas"
        UltraTab2.Key = "T02"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Registro de Facturas"
        Me.tabPrincipal.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        Me.tabPrincipal.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(801, 407)
        '
        'Exportador
        '
        '
        'Ep1
        '
        Me.Ep1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep1.ContainerControl = Me
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'Btn1
        '
        Me.Btn1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Btn1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn1.Image = Global.SIP_Presentacion.My.Resources.Resources.Hand
        Me.Btn1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn1.Name = "Btn1"
        Me.Btn1.Size = New System.Drawing.Size(99, 22)
        Me.Btn1.Text = "SELECCIONAR"
        '
        'FrmFacturasTelefonicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 445)
        Me.Controls.Add(Me.tabPrincipal)
        Me.Name = "FrmFacturasTelefonicas"
        Me.Text = "FrmFacturasTelefonicas"
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.GrdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Stb1.ResumeLayout(False)
        Me.Stb1.PerformLayout()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.txtNumDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEmpleado.ResumeLayout(False)
        Me.pnlEmpleado.PerformLayout()
        CType(Me.txtEmpCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBolsa.ResumeLayout(False)
        Me.pnlBolsa.PerformLayout()
        CType(Me.cmbGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProvCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPrincipal.ResumeLayout(False)
        CType(Me.Ep1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabPrincipal As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents GrdDatos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Stb1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cmbProveedor As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents txtid As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtEmpCodigo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtProvCodigo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtSerie As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Exportador As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbTipoDoc As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbGrupo As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents txtEmpleado As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnBuscarEmpleado As Infragistics.Win.Misc.UltraButton
    Friend WithEvents rbtEmpleado As System.Windows.Forms.RadioButton
    Friend WithEvents rbtGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents pnlBolsa As System.Windows.Forms.Panel
    Friend WithEvents pnlEmpleado As System.Windows.Forms.Panel
    Friend WithEvents txtNumDoc As Infragistics.Win.UltraWinEditors.UltraNumericEditor
End Class
