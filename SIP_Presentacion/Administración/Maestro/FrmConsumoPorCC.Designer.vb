<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsumoPorCC
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
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ANIO", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CENTRO_COSTO", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONSUMO", 3, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_TIPO", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_CENTRO_COSTO", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_CIA", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UNIDAD", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OBSERVACION", 10)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
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
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton("Nuevo")
        Dim EditorButton2 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton("Ayuda")
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem15 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem16 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem17 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem18 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem19 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem20 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem21 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem22 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem23 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem24 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem25 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem26 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsumoPorCC))
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbCentroCostoOri = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.txtKW = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txt_Codequipo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.chktransfer = New System.Windows.Forms.CheckBox
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txtobservacion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.cmbCentroCosto = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.cmbTipo = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.cmbMes = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.udAnio = New System.Windows.Forms.NumericUpDown
        Me.txtunidad = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtConsumo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.txtid = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtCentroCosto = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtCodCentroCosto = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.tabConsumo = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Exportador = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
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
        Me.Panel1.SuspendLayout()
        CType(Me.cmbCentroCostoOri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Codequipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtobservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtunidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabConsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabConsumo.SuspendLayout()
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
        UltraGridColumn2.Header.Caption = "AÑO"
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Width = 186
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Width = 65
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "CENTRO DE COSTO"
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.Width = 160
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 151
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 100
        UltraGridColumn7.Header.VisiblePosition = 1
        UltraGridColumn7.Width = 14
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 95
        UltraGridColumn9.Header.Caption = ""
        UltraGridColumn9.Header.VisiblePosition = 4
        UltraGridColumn9.Width = 43
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 95
        UltraGridColumn11.Header.Caption = "UND"
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Width = 47
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Width = 95
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12})
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
        Me.UltraGroupBox2.Controls.Add(Me.Panel1)
        Me.UltraGroupBox2.Controls.Add(Me.chktransfer)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox2.Controls.Add(Me.txtobservacion)
        Me.UltraGroupBox2.Controls.Add(Me.cmbCentroCosto)
        Me.UltraGroupBox2.Controls.Add(Me.cmbTipo)
        Me.UltraGroupBox2.Controls.Add(Me.cmbMes)
        Me.UltraGroupBox2.Controls.Add(Me.udAnio)
        Me.UltraGroupBox2.Controls.Add(Me.txtunidad)
        Me.UltraGroupBox2.Controls.Add(Me.txtConsumo)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox2.Controls.Add(Me.txtid)
        Me.UltraGroupBox2.Controls.Add(Me.txtCentroCosto)
        Me.UltraGroupBox2.Controls.Add(Me.txtCodCentroCosto)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel5)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.UltraLabel9)
        Me.Panel1.Controls.Add(Me.UltraLabel8)
        Me.Panel1.Controls.Add(Me.UltraLabel7)
        Me.Panel1.Controls.Add(Me.cmbCentroCostoOri)
        Me.Panel1.Controls.Add(Me.txtKW)
        Me.Panel1.Controls.Add(Me.txt_Codequipo)
        Me.Panel1.Location = New System.Drawing.Point(391, 74)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(359, 60)
        Me.Panel1.TabIndex = 190
        Me.Panel1.Visible = False
        '
        'UltraLabel9
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Appearance16.TextHAlignAsString = "Right"
        Me.UltraLabel9.Appearance = Appearance16
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel9.Location = New System.Drawing.Point(276, 11)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(20, 17)
        Me.UltraLabel9.TabIndex = 189
        Me.UltraLabel9.Text = "Kw"
        '
        'UltraLabel8
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Me.UltraLabel8.Appearance = Appearance9
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel8.Location = New System.Drawing.Point(75, 11)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(84, 17)
        Me.UltraLabel8.TabIndex = 188
        Me.UltraLabel8.Text = "C. Costo Origen"
        '
        'UltraLabel7
        '
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Appearance20.TextHAlignAsString = "Right"
        Me.UltraLabel7.Appearance = Appearance20
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel7.Location = New System.Drawing.Point(2, 11)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(39, 17)
        Me.UltraLabel7.TabIndex = 187
        Me.UltraLabel7.Text = "Equipo"
        '
        'cmbCentroCostoOri
        '
        Me.cmbCentroCostoOri.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbCentroCostoOri.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbCentroCostoOri.Location = New System.Drawing.Point(75, 32)
        Me.cmbCentroCostoOri.Name = "cmbCentroCostoOri"
        Me.cmbCentroCostoOri.ReadOnly = True
        Me.cmbCentroCostoOri.Size = New System.Drawing.Size(195, 21)
        Me.cmbCentroCostoOri.TabIndex = 186
        '
        'txtKW
        '
        Appearance15.TextHAlignAsString = "Right"
        Appearance15.TextVAlignAsString = "Middle"
        Me.txtKW.Appearance = Appearance15
        Me.txtKW.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKW.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtKW.Location = New System.Drawing.Point(276, 32)
        Me.txtKW.Name = "txtKW"
        Me.txtKW.ReadOnly = True
        Me.txtKW.Size = New System.Drawing.Size(73, 21)
        Me.txtKW.TabIndex = 185
        Me.txtKW.TabStop = False
        Me.txtKW.Text = "0"
        '
        'txt_Codequipo
        '
        Appearance60.TextHAlignAsString = "Left"
        Me.txt_Codequipo.Appearance = Appearance60
        Me.txt_Codequipo.AutoSize = False
        EditorButton1.Key = "Nuevo"
        EditorButton1.Visible = False
        Me.txt_Codequipo.ButtonsLeft.Add(EditorButton1)
        EditorButton2.Key = "Ayuda"
        Me.txt_Codequipo.ButtonsRight.Add(EditorButton2)
        Me.txt_Codequipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txt_Codequipo.Location = New System.Drawing.Point(2, 33)
        Me.txt_Codequipo.Name = "txt_Codequipo"
        Me.txt_Codequipo.ReadOnly = True
        Me.txt_Codequipo.Size = New System.Drawing.Size(67, 21)
        Me.txt_Codequipo.TabIndex = 2
        Me.txt_Codequipo.UseAppStyling = False
        Me.txt_Codequipo.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'chktransfer
        '
        Me.chktransfer.AutoSize = True
        Me.chktransfer.BackColor = System.Drawing.Color.Transparent
        Me.chktransfer.Location = New System.Drawing.Point(294, 116)
        Me.chktransfer.Name = "chktransfer"
        Me.chktransfer.Size = New System.Drawing.Size(91, 17)
        Me.chktransfer.TabIndex = 184
        Me.chktransfer.Text = "Transferencia"
        Me.chktransfer.UseVisualStyleBackColor = False
        '
        'UltraLabel3
        '
        Appearance36.BackColor = System.Drawing.Color.Transparent
        Appearance36.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance36
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(19, 240)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(66, 17)
        Me.UltraLabel3.TabIndex = 183
        Me.UltraLabel3.Text = "Observación"
        '
        'txtobservacion
        '
        Appearance10.TextHAlignAsString = "Left"
        Appearance10.TextVAlignAsString = "Middle"
        Me.txtobservacion.Appearance = Appearance10
        Me.txtobservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobservacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtobservacion.Location = New System.Drawing.Point(15, 263)
        Me.txtobservacion.Multiline = True
        Me.txtobservacion.Name = "txtobservacion"
        Me.txtobservacion.Size = New System.Drawing.Size(438, 96)
        Me.txtobservacion.TabIndex = 182
        Me.txtobservacion.TabStop = False
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbCentroCosto.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbCentroCosto.Location = New System.Drawing.Point(138, 162)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.Size = New System.Drawing.Size(315, 21)
        Me.cmbCentroCosto.TabIndex = 181
        '
        'cmbTipo
        '
        Me.cmbTipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbTipo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbTipo.Location = New System.Drawing.Point(17, 63)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(271, 21)
        Me.cmbTipo.TabIndex = 180
        '
        'cmbMes
        '
        Me.cmbMes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMes.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem15.DataValue = "1"
        ValueListItem15.DisplayText = "ENERO"
        ValueListItem16.DataValue = "2"
        ValueListItem16.DisplayText = "FEBRERO"
        ValueListItem17.DataValue = "3"
        ValueListItem17.DisplayText = "MARZO"
        ValueListItem18.DataValue = "4"
        ValueListItem18.DisplayText = "ABRIL"
        ValueListItem19.DataValue = "5"
        ValueListItem19.DisplayText = "MAYO"
        ValueListItem20.DataValue = "6"
        ValueListItem20.DisplayText = "JUNIO"
        ValueListItem21.DataValue = "7"
        ValueListItem21.DisplayText = "JULIO"
        ValueListItem22.DataValue = "8"
        ValueListItem22.DisplayText = "AGOSTO"
        ValueListItem23.DataValue = "9"
        ValueListItem23.DisplayText = "SETIEMBRE"
        ValueListItem24.DataValue = "10"
        ValueListItem24.DisplayText = "OCTUBRE"
        ValueListItem25.DataValue = "11"
        ValueListItem25.DisplayText = "NOVIEMBRE"
        ValueListItem26.DataValue = "12"
        ValueListItem26.DisplayText = "DICIEMBRE"
        Me.cmbMes.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem15, ValueListItem16, ValueListItem17, ValueListItem18, ValueListItem19, ValueListItem20, ValueListItem21, ValueListItem22, ValueListItem23, ValueListItem24, ValueListItem25, ValueListItem26})
        Me.cmbMes.Location = New System.Drawing.Point(138, 113)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(150, 21)
        Me.cmbMes.TabIndex = 179
        '
        'udAnio
        '
        Me.udAnio.Location = New System.Drawing.Point(17, 113)
        Me.udAnio.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.udAnio.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.udAnio.Name = "udAnio"
        Me.udAnio.Size = New System.Drawing.Size(102, 20)
        Me.udAnio.TabIndex = 178
        Me.udAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udAnio.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'txtunidad
        '
        Appearance5.TextHAlignAsString = "Left"
        Appearance5.TextVAlignAsString = "Middle"
        Me.txtunidad.Appearance = Appearance5
        Me.txtunidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtunidad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtunidad.Location = New System.Drawing.Point(138, 212)
        Me.txtunidad.Name = "txtunidad"
        Me.txtunidad.ReadOnly = True
        Me.txtunidad.Size = New System.Drawing.Size(43, 21)
        Me.txtunidad.TabIndex = 175
        Me.txtunidad.TabStop = False
        Me.txtunidad.Text = "M3"
        '
        'txtConsumo
        '
        Appearance8.TextHAlignAsString = "Left"
        Appearance8.TextVAlignAsString = "Middle"
        Me.txtConsumo.Appearance = Appearance8
        Me.txtConsumo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConsumo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtConsumo.Location = New System.Drawing.Point(17, 212)
        Me.txtConsumo.Name = "txtConsumo"
        Me.txtConsumo.ReadOnly = True
        Me.txtConsumo.Size = New System.Drawing.Size(104, 21)
        Me.txtConsumo.TabIndex = 174
        '
        'UltraLabel1
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance4
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(17, 189)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(52, 17)
        Me.UltraLabel1.TabIndex = 176
        Me.UltraLabel1.Text = "Consumo"
        '
        'txtid
        '
        Appearance14.TextHAlignAsString = "Left"
        Appearance14.TextVAlignAsString = "Middle"
        Me.txtid.Appearance = Appearance14
        Me.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtid.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtid.Location = New System.Drawing.Point(349, 36)
        Me.txtid.Name = "txtid"
        Me.txtid.ReadOnly = True
        Me.txtid.Size = New System.Drawing.Size(104, 21)
        Me.txtid.TabIndex = 0
        Me.txtid.TabStop = False
        Me.txtid.Text = "0"
        Me.txtid.Visible = False
        '
        'txtCentroCosto
        '
        Appearance13.TextHAlignAsString = "Left"
        Appearance13.TextVAlignAsString = "Middle"
        Me.txtCentroCosto.Appearance = Appearance13
        Me.txtCentroCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCentroCosto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtCentroCosto.Location = New System.Drawing.Point(459, 162)
        Me.txtCentroCosto.Name = "txtCentroCosto"
        Me.txtCentroCosto.ReadOnly = True
        Me.txtCentroCosto.Size = New System.Drawing.Size(315, 21)
        Me.txtCentroCosto.TabIndex = 2
        Me.txtCentroCosto.TabStop = False
        Me.txtCentroCosto.Visible = False
        '
        'txtCodCentroCosto
        '
        Appearance17.TextHAlignAsString = "Left"
        Appearance17.TextVAlignAsString = "Middle"
        Me.txtCodCentroCosto.Appearance = Appearance17
        Me.txtCodCentroCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCentroCosto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtCodCentroCosto.Location = New System.Drawing.Point(15, 162)
        Me.txtCodCentroCosto.MaxLength = 3
        Me.txtCodCentroCosto.Name = "txtCodCentroCosto"
        Me.txtCodCentroCosto.ReadOnly = True
        Me.txtCodCentroCosto.Size = New System.Drawing.Size(104, 21)
        Me.txtCodCentroCosto.TabIndex = 1
        '
        'UltraLabel2
        '
        Appearance18.BackColor = System.Drawing.Color.Transparent
        Appearance18.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance18
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(17, 139)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(85, 17)
        Me.UltraLabel2.TabIndex = 165
        Me.UltraLabel2.Text = "Centro de Costo"
        '
        'UltraLabel5
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Appearance19.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance19
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel5.Location = New System.Drawing.Point(138, 90)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(26, 17)
        Me.UltraLabel5.TabIndex = 2
        Me.UltraLabel5.Text = "Mes"
        '
        'UltraLabel6
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Me.UltraLabel6.Appearance = Appearance6
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(19, 40)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(26, 17)
        Me.UltraLabel6.TabIndex = 2
        Me.UltraLabel6.Text = "Tipo"
        '
        'UltraLabel4
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Right"
        Me.UltraLabel4.Appearance = Appearance11
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(17, 90)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(24, 17)
        Me.UltraLabel4.TabIndex = 2
        Me.UltraLabel4.Text = "Año"
        '
        'tabConsumo
        '
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.Name = "Arial Narrow"
        Appearance2.FontData.SizeInPoints = 16.0!
        Me.tabConsumo.ActiveTabAppearance = Appearance2
        Appearance3.FontData.Name = "Arial Narrow"
        Appearance3.FontData.SizeInPoints = 10.0!
        Me.tabConsumo.Appearance = Appearance3
        Me.tabConsumo.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabConsumo.Controls.Add(Me.UltraTabPageControl1)
        Me.tabConsumo.Controls.Add(Me.UltraTabPageControl2)
        Me.tabConsumo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabConsumo.Location = New System.Drawing.Point(0, 0)
        Me.tabConsumo.Name = "tabConsumo"
        Me.tabConsumo.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabConsumo.Size = New System.Drawing.Size(805, 445)
        Me.tabConsumo.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabConsumo.TabHeaderAreaAppearance = Appearance1
        Me.tabConsumo.TabIndex = 0
        Me.tabConsumo.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab1.Key = "T01"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Listado de Consumo por Centro de Costo"
        UltraTab2.Key = "T02"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Consumo por Centro de Costo"
        Me.tabConsumo.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        Me.tabConsumo.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(801, 407)
        '
        'Ep1
        '
        Me.Ep1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep1.ContainerControl = Me
        '
        'Exportador
        '
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
        'FrmConsumoPorCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 445)
        Me.Controls.Add(Me.tabConsumo)
        Me.Name = "FrmConsumoPorCC"
        Me.Text = "Consumo Por Centro de Costo"
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmbCentroCostoOri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Codequipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtobservacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtunidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabConsumo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabConsumo.ResumeLayout(False)
        CType(Me.Ep1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabConsumo As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
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
    Friend WithEvents GrdDatos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtunidad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtConsumo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtid As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtCentroCosto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtCodCentroCosto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udAnio As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbMes As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbTipo As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents Ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Exportador As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents cmbCentroCosto As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtobservacion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chktransfer As System.Windows.Forms.CheckBox
    Friend WithEvents txt_Codequipo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cmbCentroCostoOri As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents txtKW As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
