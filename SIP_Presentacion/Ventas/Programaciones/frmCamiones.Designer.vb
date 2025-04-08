<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCamiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCamiones))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PLACA", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DESCRIPCION", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MARCA", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MODELO", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AYOFABRICACION", 5)
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PESOMAXIMO", 6)
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROV", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PROVEEDOR", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONFIGVEH", 9)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(992)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ConfigVeh")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cargautil")
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ScrollBarLook1 As Infragistics.Win.UltraWinScrollBar.ScrollBarLook = New Infragistics.Win.UltraWinScrollBar.ScrollBarLook
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Navigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.gridCamiones = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Stb1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txtConfigVehCargaUtil = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.cboConfigVeh = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.txtid = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtproveedor = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcodprov = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.txtayo = New System.Windows.Forms.NumericUpDown
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.txtpeso = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.txtmodelo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txtmarca = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.txtdescripcion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.txtplaca = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Navigator1.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.gridCamiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Stb1.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.txtConfigVehCargaUtil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboConfigVeh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtproveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodprov, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpeso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmodelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtplaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Navigator1
        '
        Me.Navigator1.AddNewItem = Nothing
        Me.Navigator1.BackColor = System.Drawing.Color.Transparent
        Me.Navigator1.CountItem = Me.BindingNavigatorCountItem
        Me.Navigator1.DeleteItem = Nothing
        Me.Navigator1.Dock = System.Windows.Forms.DockStyle.None
        Me.Navigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Navigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorSeparator, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorMoveNextItem, Me.ToolStripSeparator5, Me.BindingNavigatorCountItem, Me.BindingNavigatorPositionItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorMoveFirstItem, Me.ToolStripSeparator6, Me.Btn1, Me.ToolStripSeparator2})
        Me.Navigator1.Location = New System.Drawing.Point(2, 4)
        Me.Navigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Navigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Navigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Navigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Navigator1.Name = "Navigator1"
        Me.Navigator1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.Navigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.Navigator1.Size = New System.Drawing.Size(314, 25)
        Me.Navigator1.TabIndex = 141
        Me.Navigator1.Text = "BindingNavigator1"
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.gridCamiones)
        Me.UltraTabPageControl1.Controls.Add(Me.Stb1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(798, 346)
        '
        'gridCamiones
        '
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridCamiones.DisplayLayout.Appearance = Appearance4
        Me.gridCamiones.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance27.Image = CType(resources.GetObject("Appearance27.Image"), Object)
        Appearance27.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance27.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance27
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.Width = 45
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.Width = 146
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn4.Width = 163
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn5.Width = 108
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn6.Width = 92
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance20
        UltraGridColumn7.Header.Caption = "AÑO FABRICA"
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn7.Width = 90
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance22
        UltraGridColumn8.Header.Caption = "PESO MAXIMO"
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn8.Width = 85
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn9.Width = 85
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.VisiblePosition = 2
        UltraGridColumn10.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn10.Width = 74
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 95
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11})
        Me.gridCamiones.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridCamiones.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridCamiones.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridCamiones.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridCamiones.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridCamiones.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridCamiones.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridCamiones.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridCamiones.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridCamiones.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridCamiones.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridCamiones.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridCamiones.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridCamiones.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridCamiones.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance29.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCamiones.DisplayLayout.GroupByBox.Appearance = Appearance29
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCamiones.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance30
        Me.gridCamiones.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridCamiones.DisplayLayout.GroupByBox.Hidden = True
        Appearance56.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance56.BackColor2 = System.Drawing.SystemColors.Control
        Appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance56.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCamiones.DisplayLayout.GroupByBox.PromptAppearance = Appearance56
        Me.gridCamiones.DisplayLayout.MaxColScrollRegions = 1
        Me.gridCamiones.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridCamiones.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridCamiones.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridCamiones.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Me.gridCamiones.DisplayLayout.Override.CardAreaAppearance = Appearance32
        Appearance33.BorderColor = System.Drawing.Color.Silver
        Appearance33.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridCamiones.DisplayLayout.Override.CellAppearance = Appearance33
        Me.gridCamiones.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridCamiones.DisplayLayout.Override.CellPadding = 0
        Me.gridCamiones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridCamiones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridCamiones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridCamiones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance57.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance57.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridCamiones.DisplayLayout.Override.FilterRowAppearance = Appearance57
        Me.gridCamiones.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridCamiones.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridCamiones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance59.BackColor = System.Drawing.SystemColors.Control
        Appearance59.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance59.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance59.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCamiones.DisplayLayout.Override.GroupByRowAppearance = Appearance59
        Appearance38.FontData.Name = "Arial Narrow"
        Appearance38.FontData.SizeInPoints = 10.0!
        Appearance38.TextHAlignAsString = "Left"
        Me.gridCamiones.DisplayLayout.Override.HeaderAppearance = Appearance38
        Me.gridCamiones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridCamiones.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridCamiones.DisplayLayout.Override.MinRowHeight = 24
        Appearance62.BackColor = System.Drawing.SystemColors.Window
        Appearance62.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance62.TextVAlignAsString = "Middle"
        Me.gridCamiones.DisplayLayout.Override.RowAppearance = Appearance62
        Me.gridCamiones.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridCamiones.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridCamiones.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance63.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridCamiones.DisplayLayout.Override.TemplateAddRowAppearance = Appearance63
        Me.gridCamiones.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridCamiones.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridCamiones.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridCamiones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridCamiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridCamiones.Location = New System.Drawing.Point(0, 30)
        Me.gridCamiones.Name = "gridCamiones"
        Me.gridCamiones.Size = New System.Drawing.Size(798, 316)
        Me.gridCamiones.TabIndex = 151
        Me.gridCamiones.Text = "UltraGrid1"
        '
        'Stb1
        '
        Me.Stb1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Stb1.Controls.Add(Me.Navigator1)
        Me.Stb1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Stb1.Location = New System.Drawing.Point(0, 0)
        Me.Stb1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Stb1.Name = "Stb1"
        UltraStatusPanel1.Control = Me.Navigator1
        UltraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        Me.Stb1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1})
        Me.Stb1.Size = New System.Drawing.Size(798, 30)
        Me.Stb1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Stb1.TabIndex = 150
        Me.Stb1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.txtConfigVehCargaUtil)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel9)
        Me.UltraTabPageControl2.Controls.Add(Me.cboConfigVeh)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel8)
        Me.UltraTabPageControl2.Controls.Add(Me.txtid)
        Me.UltraTabPageControl2.Controls.Add(Me.txtproveedor)
        Me.UltraTabPageControl2.Controls.Add(Me.txtcodprov)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel7)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel6)
        Me.UltraTabPageControl2.Controls.Add(Me.txtayo)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel5)
        Me.UltraTabPageControl2.Controls.Add(Me.txtpeso)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel4)
        Me.UltraTabPageControl2.Controls.Add(Me.txtmodelo)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl2.Controls.Add(Me.txtmarca)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl2.Controls.Add(Me.txtdescripcion)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl2.Controls.Add(Me.txtplaca)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(798, 346)
        '
        'txtConfigVehCargaUtil
        '
        Appearance21.FontData.BoldAsString = "False"
        Appearance21.ForeColor = System.Drawing.Color.Black
        Appearance21.TextHAlignAsString = "Left"
        Appearance21.TextVAlignAsString = "Middle"
        Me.txtConfigVehCargaUtil.Appearance = Appearance21
        Me.txtConfigVehCargaUtil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConfigVehCargaUtil.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtConfigVehCargaUtil.Location = New System.Drawing.Point(557, 194)
        Me.txtConfigVehCargaUtil.MaxLength = 20
        Me.txtConfigVehCargaUtil.Name = "txtConfigVehCargaUtil"
        Me.txtConfigVehCargaUtil.ReadOnly = True
        Me.txtConfigVehCargaUtil.Size = New System.Drawing.Size(51, 21)
        Me.txtConfigVehCargaUtil.TabIndex = 203
        Me.txtConfigVehCargaUtil.Text = "0"
        '
        'UltraLabel9
        '
        Appearance17.BackColor = System.Drawing.Color.Transparent
        Appearance17.TextHAlignAsString = "Right"
        Me.UltraLabel9.Appearance = Appearance17
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel9.Location = New System.Drawing.Point(614, 196)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(19, 17)
        Me.UltraLabel9.TabIndex = 204
        Me.UltraLabel9.Text = "TN"
        '
        'cboConfigVeh
        '
        Me.cboConfigVeh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance66.BackColor = System.Drawing.Color.White
        Appearance66.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(221, Byte), Integer))
        Appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance66.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.cboConfigVeh.DisplayLayout.AddNewBox.Appearance = Appearance66
        Me.cboConfigVeh.DisplayLayout.AddNewBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Appearance67.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance67.ImageBackground = CType(resources.GetObject("Appearance67.ImageBackground"), System.Drawing.Image)
        Appearance67.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        Appearance67.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3)
        Appearance67.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        Me.cboConfigVeh.DisplayLayout.AddNewBox.ButtonAppearance = Appearance67
        Me.cboConfigVeh.DisplayLayout.AddNewBox.ButtonConnectorColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.cboConfigVeh.DisplayLayout.AddNewBox.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Appearance68.BackColor = System.Drawing.Color.White
        Me.cboConfigVeh.DisplayLayout.Appearance = Appearance68
        Me.cboConfigVeh.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.Header.VisiblePosition = 0
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.Header.VisiblePosition = 1
        UltraGridColumn13.Width = 100
        UltraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn14.Header.VisiblePosition = 2
        UltraGridColumn14.Width = 50
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn12, UltraGridColumn13, UltraGridColumn14})
        Me.cboConfigVeh.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.cboConfigVeh.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance69.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance69.FontData.Name = "Trebuchet MS"
        Appearance69.FontData.SizeInPoints = 9.0!
        Appearance69.ForeColor = System.Drawing.Color.White
        Appearance69.TextHAlignAsString = "Right"
        Me.cboConfigVeh.DisplayLayout.CaptionAppearance = Appearance69
        Me.cboConfigVeh.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.cboConfigVeh.DisplayLayout.FixedHeaderOffImage = CType(resources.GetObject("cboConfigVeh.DisplayLayout.FixedHeaderOffImage"), System.Drawing.Image)
        Me.cboConfigVeh.DisplayLayout.FixedHeaderOnImage = CType(resources.GetObject("cboConfigVeh.DisplayLayout.FixedHeaderOnImage"), System.Drawing.Image)
        Me.cboConfigVeh.DisplayLayout.FixedRowOffImage = CType(resources.GetObject("cboConfigVeh.DisplayLayout.FixedRowOffImage"), System.Drawing.Image)
        Me.cboConfigVeh.DisplayLayout.FixedRowOnImage = CType(resources.GetObject("cboConfigVeh.DisplayLayout.FixedRowOnImage"), System.Drawing.Image)
        Appearance70.FontData.BoldAsString = "True"
        Appearance70.FontData.Name = "Trebuchet MS"
        Appearance70.FontData.SizeInPoints = 10.0!
        Appearance70.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(177, Byte), Integer))
        Appearance70.ImageBackground = CType(resources.GetObject("Appearance70.ImageBackground"), System.Drawing.Image)
        Appearance70.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(0, 2, 0, 3)
        Appearance70.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        Me.cboConfigVeh.DisplayLayout.GroupByBox.Appearance = Appearance70
        Appearance71.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboConfigVeh.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance71
        Me.cboConfigVeh.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cboConfigVeh.DisplayLayout.GroupByBox.ButtonBorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Appearance72.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance72.BackColor2 = System.Drawing.SystemColors.Control
        Appearance72.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance72.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cboConfigVeh.DisplayLayout.GroupByBox.PromptAppearance = Appearance72
        Me.cboConfigVeh.DisplayLayout.MaxColScrollRegions = 1
        Me.cboConfigVeh.DisplayLayout.MaxRowScrollRegions = 1
        Appearance76.BackColor = System.Drawing.SystemColors.Window
        Appearance76.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboConfigVeh.DisplayLayout.Override.ActiveCellAppearance = Appearance76
        Appearance77.BackColor = System.Drawing.SystemColors.Highlight
        Appearance77.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cboConfigVeh.DisplayLayout.Override.ActiveRowAppearance = Appearance77
        Me.cboConfigVeh.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.cboConfigVeh.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None
        Me.cboConfigVeh.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None
        Me.cboConfigVeh.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
        Me.cboConfigVeh.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless
        Appearance78.BackColor = System.Drawing.Color.Transparent
        Me.cboConfigVeh.DisplayLayout.Override.CardAreaAppearance = Appearance78
        Appearance80.BorderColor = System.Drawing.Color.Transparent
        Appearance80.FontData.Name = "Verdana"
        Me.cboConfigVeh.DisplayLayout.Override.CellAppearance = Appearance80
        Appearance81.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance81.ImageBackground = CType(resources.GetObject("Appearance81.ImageBackground"), System.Drawing.Image)
        Appearance81.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3)
        Appearance81.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        Me.cboConfigVeh.DisplayLayout.Override.CellButtonAppearance = Appearance81
        Me.cboConfigVeh.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cboConfigVeh.DisplayLayout.Override.CellPadding = 0
        Appearance82.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.cboConfigVeh.DisplayLayout.Override.FilterCellAppearance = Appearance82
        Appearance83.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance83.ImageBackground = CType(resources.GetObject("Appearance83.ImageBackground"), System.Drawing.Image)
        Appearance83.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(6, 3, 6, 3)
        Me.cboConfigVeh.DisplayLayout.Override.FilterClearButtonAppearance = Appearance83
        Appearance84.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Appearance84.BackColorAlpha = Infragistics.Win.Alpha.Opaque
        Me.cboConfigVeh.DisplayLayout.Override.FilterRowPromptAppearance = Appearance84
        Appearance85.BackColor = System.Drawing.SystemColors.Control
        Appearance85.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance85.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance85.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance85.BorderColor = System.Drawing.SystemColors.Window
        Me.cboConfigVeh.DisplayLayout.Override.GroupByRowAppearance = Appearance85
        Appearance86.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Appearance86.FontData.BoldAsString = "True"
        Appearance86.FontData.Name = "Trebuchet MS"
        Appearance86.FontData.SizeInPoints = 10.0!
        Appearance86.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance86.ImageBackground = CType(resources.GetObject("Appearance86.ImageBackground"), System.Drawing.Image)
        Appearance86.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled
        Appearance86.TextHAlignAsString = "Left"
        Appearance86.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.cboConfigVeh.DisplayLayout.Override.HeaderAppearance = Appearance86
        Me.cboConfigVeh.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cboConfigVeh.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed
        Appearance87.BorderColor = System.Drawing.Color.Transparent
        Me.cboConfigVeh.DisplayLayout.Override.RowAppearance = Appearance87
        Appearance88.BackColor = System.Drawing.Color.White
        Me.cboConfigVeh.DisplayLayout.Override.RowSelectorAppearance = Appearance88
        Me.cboConfigVeh.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance89.BorderColor = System.Drawing.Color.Transparent
        Appearance89.ForeColor = System.Drawing.Color.Black
        Me.cboConfigVeh.DisplayLayout.Override.SelectedCellAppearance = Appearance89
        Appearance90.BorderColor = System.Drawing.Color.Transparent
        Appearance90.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance90.ImageBackground = CType(resources.GetObject("Appearance90.ImageBackground"), System.Drawing.Image)
        Appearance90.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(1, 1, 1, 4)
        Appearance90.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        Me.cboConfigVeh.DisplayLayout.Override.SelectedRowAppearance = Appearance90
        Appearance91.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cboConfigVeh.DisplayLayout.Override.TemplateAddRowAppearance = Appearance91
        Appearance101.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(2, 4, 2, 4)
        Appearance101.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        ScrollBarLook1.Appearance = Appearance101
        Appearance103.ImageBackground = CType(resources.GetObject("Appearance103.ImageBackground"), System.Drawing.Image)
        Appearance103.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(3, 2, 3, 2)
        ScrollBarLook1.AppearanceHorizontal = Appearance103
        Appearance105.ImageBackground = CType(resources.GetObject("Appearance105.ImageBackground"), System.Drawing.Image)
        Appearance105.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(2, 3, 2, 3)
        Appearance105.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        ScrollBarLook1.AppearanceVertical = Appearance105
        Appearance106.ImageBackground = CType(resources.GetObject("Appearance106.ImageBackground"), System.Drawing.Image)
        Appearance106.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(0, 2, 0, 1)
        ScrollBarLook1.TrackAppearanceHorizontal = Appearance106
        Appearance107.ImageBackground = CType(resources.GetObject("Appearance107.ImageBackground"), System.Drawing.Image)
        Appearance107.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(2, 0, 1, 0)
        Appearance107.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
        ScrollBarLook1.TrackAppearanceVertical = Appearance107
        Me.cboConfigVeh.DisplayLayout.ScrollBarLook = ScrollBarLook1
        Me.cboConfigVeh.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cboConfigVeh.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cboConfigVeh.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cboConfigVeh.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboConfigVeh.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cboConfigVeh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboConfigVeh.Location = New System.Drawing.Point(408, 193)
        Me.cboConfigVeh.Name = "cboConfigVeh"
        Me.cboConfigVeh.Size = New System.Drawing.Size(143, 22)
        Me.cboConfigVeh.TabIndex = 202
        Me.cboConfigVeh.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'UltraLabel8
        '
        Appearance45.BackColor = System.Drawing.Color.Transparent
        Appearance45.TextHAlignAsString = "Right"
        Me.UltraLabel8.Appearance = Appearance45
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel8.Location = New System.Drawing.Point(278, 196)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(124, 17)
        Me.UltraLabel8.TabIndex = 200
        Me.UltraLabel8.Text = "& Configuración Vehicular"
        '
        'txtid
        '
        Appearance15.TextHAlignAsString = "Left"
        Appearance15.TextVAlignAsString = "Middle"
        Me.txtid.Appearance = Appearance15
        Me.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtid.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtid.Location = New System.Drawing.Point(170, 17)
        Me.txtid.Name = "txtid"
        Me.txtid.ReadOnly = True
        Me.txtid.Size = New System.Drawing.Size(104, 21)
        Me.txtid.TabIndex = 0
        Me.txtid.TabStop = False
        Me.txtid.Text = "0"
        Me.txtid.Visible = False
        '
        'txtproveedor
        '
        Appearance16.FontData.BoldAsString = "False"
        Appearance16.ForeColor = System.Drawing.Color.Black
        Appearance16.TextHAlignAsString = "Left"
        Appearance16.TextVAlignAsString = "Middle"
        Me.txtproveedor.Appearance = Appearance16
        Me.txtproveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtproveedor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtproveedor.Location = New System.Drawing.Point(278, 46)
        Me.txtproveedor.MaxLength = 20
        Me.txtproveedor.Name = "txtproveedor"
        Me.txtproveedor.ReadOnly = True
        Me.txtproveedor.Size = New System.Drawing.Size(273, 21)
        Me.txtproveedor.TabIndex = 0
        Me.txtproveedor.TabStop = False
        '
        'txtcodprov
        '
        Appearance6.FontData.BoldAsString = "False"
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.TextHAlignAsString = "Left"
        Appearance6.TextVAlignAsString = "Middle"
        Me.txtcodprov.Appearance = Appearance6
        Me.txtcodprov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodprov.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodprov.Location = New System.Drawing.Point(170, 46)
        Me.txtcodprov.MaxLength = 8
        Me.txtcodprov.Name = "txtcodprov"
        Me.txtcodprov.Size = New System.Drawing.Size(102, 21)
        Me.txtcodprov.TabIndex = 1
        '
        'UltraLabel7
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Right"
        Me.UltraLabel7.Appearance = Appearance7
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel7.Location = New System.Drawing.Point(103, 47)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(59, 17)
        Me.UltraLabel7.TabIndex = 199
        Me.UltraLabel7.Text = "& Proveedor"
        '
        'UltraLabel6
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Appearance19.TextHAlignAsString = "Right"
        Me.UltraLabel6.Appearance = Appearance19
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(78, 224)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(84, 17)
        Me.UltraLabel6.TabIndex = 198
        Me.UltraLabel6.Text = "& Año fabricación"
        '
        'txtayo
        '
        Me.txtayo.Location = New System.Drawing.Point(170, 222)
        Me.txtayo.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtayo.Name = "txtayo"
        Me.txtayo.Size = New System.Drawing.Size(102, 20)
        Me.txtayo.TabIndex = 7
        Me.txtayo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtayo.Value = New Decimal(New Integer() {2014, 0, 0, 0})
        '
        'UltraLabel5
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Appearance23.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance23
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel5.Location = New System.Drawing.Point(54, 196)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(108, 17)
        Me.UltraLabel5.TabIndex = 196
        Me.UltraLabel5.Text = "& Peso máximo (TON)"
        '
        'txtpeso
        '
        Appearance79.FontData.BoldAsString = "False"
        Appearance79.ForeColor = System.Drawing.Color.Black
        Appearance79.TextHAlignAsString = "Right"
        Appearance79.TextVAlignAsString = "Middle"
        Me.txtpeso.Appearance = Appearance79
        Me.txtpeso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpeso.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtpeso.Location = New System.Drawing.Point(170, 193)
        Me.txtpeso.MaxLength = 16
        Me.txtpeso.Name = "txtpeso"
        Me.txtpeso.Size = New System.Drawing.Size(102, 21)
        Me.txtpeso.TabIndex = 6
        Me.txtpeso.Text = "0.00"
        '
        'UltraLabel4
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Right"
        Me.UltraLabel4.Appearance = Appearance5
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(118, 166)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(44, 17)
        Me.UltraLabel4.TabIndex = 194
        Me.UltraLabel4.Text = "& Modelo"
        '
        'txtmodelo
        '
        Appearance8.FontData.BoldAsString = "False"
        Appearance8.ForeColor = System.Drawing.Color.Black
        Appearance8.TextHAlignAsString = "Left"
        Appearance8.TextVAlignAsString = "Middle"
        Me.txtmodelo.Appearance = Appearance8
        Me.txtmodelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmodelo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtmodelo.Location = New System.Drawing.Point(170, 164)
        Me.txtmodelo.MaxLength = 60
        Me.txtmodelo.Name = "txtmodelo"
        Me.txtmodelo.Size = New System.Drawing.Size(381, 21)
        Me.txtmodelo.TabIndex = 5
        '
        'UltraLabel3
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance10
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(124, 137)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(38, 17)
        Me.UltraLabel3.TabIndex = 192
        Me.UltraLabel3.Text = "& Marca"
        '
        'txtmarca
        '
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.TextHAlignAsString = "Left"
        Appearance12.TextVAlignAsString = "Middle"
        Me.txtmarca.Appearance = Appearance12
        Me.txtmarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmarca.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtmarca.Location = New System.Drawing.Point(170, 135)
        Me.txtmarca.MaxLength = 60
        Me.txtmarca.Name = "txtmarca"
        Me.txtmarca.Size = New System.Drawing.Size(381, 21)
        Me.txtmarca.TabIndex = 4
        '
        'UltraLabel1
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance13
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(97, 108)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(65, 17)
        Me.UltraLabel1.TabIndex = 190
        Me.UltraLabel1.Text = "& Descripción"
        '
        'txtdescripcion
        '
        Appearance14.FontData.BoldAsString = "False"
        Appearance14.ForeColor = System.Drawing.Color.Black
        Appearance14.TextHAlignAsString = "Left"
        Appearance14.TextVAlignAsString = "Middle"
        Me.txtdescripcion.Appearance = Appearance14
        Me.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescripcion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtdescripcion.Location = New System.Drawing.Point(170, 106)
        Me.txtdescripcion.MaxLength = 100
        Me.txtdescripcion.Multiline = True
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(381, 21)
        Me.txtdescripcion.TabIndex = 3
        '
        'UltraLabel2
        '
        Appearance18.BackColor = System.Drawing.Color.Transparent
        Appearance18.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance18
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(127, 79)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(35, 17)
        Me.UltraLabel2.TabIndex = 188
        Me.UltraLabel2.Text = "& Placa"
        '
        'txtplaca
        '
        Appearance44.FontData.BoldAsString = "False"
        Appearance44.ForeColor = System.Drawing.Color.Black
        Appearance44.TextHAlignAsString = "Left"
        Appearance44.TextVAlignAsString = "Middle"
        Me.txtplaca.Appearance = Appearance44
        Me.txtplaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtplaca.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtplaca.Location = New System.Drawing.Point(170, 77)
        Me.txtplaca.MaxLength = 20
        Me.txtplaca.Name = "txtplaca"
        Me.txtplaca.Size = New System.Drawing.Size(102, 21)
        Me.txtplaca.TabIndex = 2
        '
        'Tab1
        '
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial Narrow"
        Appearance3.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance3
        Appearance1.FontData.Name = "Arial Narrow"
        Appearance1.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance1
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl2)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(802, 384)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance11
        Me.Tab1.TabIndex = 3
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance24.Cursor = System.Windows.Forms.Cursors.Default
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.FontData.Name = "Arial Narrow"
        Appearance24.FontData.SizeInPoints = 16.0!
        UltraTab3.ActiveAppearance = Appearance24
        Appearance9.FontData.Name = "Arial Narrow"
        Appearance9.FontData.SizeInPoints = 10.0!
        UltraTab3.Appearance = Appearance9
        UltraTab3.Key = "T01"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "LISTADO DE CAMIONES"
        Appearance25.Cursor = System.Windows.Forms.Cursors.Default
        Appearance25.FontData.BoldAsString = "True"
        Appearance25.FontData.Name = "Arial Narrow"
        Appearance25.FontData.SizeInPoints = 16.0!
        UltraTab4.ActiveAppearance = Appearance25
        Appearance2.FontData.Name = "Arial Narrow"
        Appearance2.FontData.SizeInPoints = 10.0!
        UltraTab4.Appearance = Appearance2
        UltraTab4.Key = "T02"
        UltraTab4.TabPage = Me.UltraTabPageControl2
        UltraTab4.Text = "REGISTRO DE CAMIONES"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3, UltraTab4})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(798, 346)
        '
        'frmCamiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 384)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "frmCamiones"
        Me.Text = "frmCamiones"
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Navigator1.ResumeLayout(False)
        Me.Navigator1.PerformLayout()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.gridCamiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Stb1.ResumeLayout(False)
        Me.Stb1.PerformLayout()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.txtConfigVehCargaUtil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboConfigVeh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtproveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodprov, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpeso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmodelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtplaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents gridCamiones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Stb1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents Navigator1 As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtpeso As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtmodelo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtmarca As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtdescripcion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtplaca As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtayo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtcodprov As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtproveedor As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtid As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboConfigVeh As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents txtConfigVehCargaUtil As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
End Class
