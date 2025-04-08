Imports Infragistics.Win.UltraWinGrid.UltraGridAction
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMUsuarios))
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario", 1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Encargado", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesEstado", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Contrasenha", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PlaCod", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Admin", 6)
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem35 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem36 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem37 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem38 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem39 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem40 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem41 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Formulario", 0)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Operacion", 1)
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance162 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance157 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance163 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance159 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance160 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_MAESTRO2", 0)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DESCRIP", 1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FLAG1", 2)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FLAG2", 3)
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.Navigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Grid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Stb1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.cboSistema = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.ChkMarcarTodo = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.Cbo3 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.Cbo2 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.Grid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkVerPedido = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.chkAprobPedido = New System.Windows.Forms.CheckBox
        Me.txtuserclonar = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Iml1 = New System.Windows.Forms.ImageList(Me.components)
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.ChkAdmin = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.Txt3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Lbl1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.Btn2 = New Infragistics.Win.Misc.UltraButton
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.Cbo1 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Txt5 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.gridArea = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Ep2 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Navigator1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Stb1.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.cboSistema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtuserclonar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.gridArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.Ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ep2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Navigator1
        '
        Me.Navigator1.AddNewItem = Nothing
        Me.Navigator1.BackColor = System.Drawing.Color.Transparent
        Me.Navigator1.BindingSource = Me.Source1
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
        Me.Navigator1.Size = New System.Drawing.Size(312, 25)
        Me.Navigator1.TabIndex = 141
        Me.Navigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
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
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox3)
        Me.UltraTabPageControl1.Controls.Add(Me.Stb1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1024, 572)
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None
        Me.UltraGroupBox3.Controls.Add(Me.Grid1)
        Me.UltraGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox3.Location = New System.Drawing.Point(0, 30)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(1024, 542)
        Me.UltraGroupBox3.TabIndex = 151
        '
        'Grid1
        '
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid1.DisplayLayout.Appearance = Appearance12
        Me.Grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance26.Image = CType(resources.GetObject("Appearance26.Image"), Object)
        Appearance26.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance26.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance26
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.MaxWidth = 150
        UltraGridColumn3.MinWidth = 150
        UltraGridColumn3.Width = 150
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn5.Header.Caption = "Estado"
        UltraGridColumn5.Header.VisiblePosition = 0
        UltraGridColumn5.MaxWidth = 100
        UltraGridColumn5.MinWidth = 100
        UltraGridColumn5.Width = 100
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8})
        Appearance27.TextVAlignAsString = "Middle"
        UltraGridBand1.Override.RowAppearance = Appearance27
        Me.Grid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance28.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.GroupByBox.Appearance = Appearance28
        Appearance29.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance29
        Me.Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance30.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance30.BackColor2 = System.Drawing.SystemColors.Control
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance30
        Me.Grid1.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid1.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid1.DisplayLayout.Override.CellAppearance = Appearance32
        Me.Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid1.DisplayLayout.Override.CellPadding = 0
        Me.Grid1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance33.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid1.DisplayLayout.Override.FilterRowAppearance = Appearance33
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance34.BackColor = System.Drawing.SystemColors.Control
        Appearance34.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance34.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance34.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.GroupByRowAppearance = Appearance34
        Appearance35.FontData.Name = "Arial Narrow"
        Appearance35.FontData.SizeInPoints = 10.0!
        Appearance35.TextHAlignAsString = "Left"
        Me.Grid1.DisplayLayout.Override.HeaderAppearance = Appearance35
        Me.Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid1.DisplayLayout.Override.MinRowHeight = 24
        Appearance36.BackColor = System.Drawing.SystemColors.Window
        Appearance36.BorderColor = System.Drawing.Color.Silver
        Me.Grid1.DisplayLayout.Override.RowAppearance = Appearance36
        Me.Grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance37.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance37
        Me.Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.Location = New System.Drawing.Point(1, 0)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(1022, 541)
        Me.Grid1.TabIndex = 149
        Me.Grid1.Text = "UltraGrid1"
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
        Me.Stb1.Size = New System.Drawing.Size(1024, 30)
        Me.Stb1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Stb1.TabIndex = 150
        Me.Stb1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(1024, 572)
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance107.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox2.ContentAreaAppearance = Appearance107
        Me.UltraGroupBox2.Controls.Add(Me.cboSistema)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel10)
        Me.UltraGroupBox2.Controls.Add(Me.ChkMarcarTodo)
        Me.UltraGroupBox2.Controls.Add(Me.Cbo3)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel8)
        Me.UltraGroupBox2.Controls.Add(Me.Cbo2)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox2.Controls.Add(Me.Grid2)
        Appearance106.FontData.BoldAsString = "True"
        Appearance106.FontData.Name = "Arial Narrow"
        Appearance106.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox2.HeaderAppearance = Appearance106
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox2.Location = New System.Drawing.Point(11, 211)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(1002, 350)
        Me.UltraGroupBox2.TabIndex = 124
        Me.UltraGroupBox2.Text = "MODULOS DE ACCESO"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'cboSistema
        '
        Me.cboSistema.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cboSistema.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem8.DataValue = "1"
        ValueListItem8.DisplayText = "ERP COMACSA"
        ValueListItem35.DataValue = "2"
        ValueListItem35.DisplayText = "BANCOS"
        ValueListItem36.DataValue = "3"
        ValueListItem36.DisplayText = "FACTURACION"
        ValueListItem37.DataValue = "4"
        ValueListItem37.DisplayText = "EXPORTACIONES"
        ValueListItem38.DataValue = "4"
        ValueListItem38.DisplayText = "CUENTA CORRIENTE"
        ValueListItem39.DataValue = "5"
        ValueListItem39.DisplayText = "LOGISTICA"
        ValueListItem40.DataValue = "6"
        ValueListItem40.DisplayText = "MINAS"
        ValueListItem41.DataValue = "7"
        ValueListItem41.DisplayText = "ALMACEN"
        Me.cboSistema.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem8, ValueListItem35, ValueListItem36, ValueListItem37, ValueListItem38, ValueListItem39, ValueListItem40, ValueListItem41})
        Me.cboSistema.Location = New System.Drawing.Point(122, 33)
        Me.cboSistema.Name = "cboSistema"
        Me.cboSistema.Size = New System.Drawing.Size(185, 21)
        Me.cboSistema.TabIndex = 137
        Me.cboSistema.Visible = False
        '
        'UltraLabel10
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Right"
        Me.UltraLabel10.Appearance = Appearance8
        Me.UltraLabel10.AutoSize = True
        Me.UltraLabel10.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel10.Location = New System.Drawing.Point(69, 36)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(51, 17)
        Me.UltraLabel10.TabIndex = 136
        Me.UltraLabel10.Text = "Sistema :"
        Me.UltraLabel10.Visible = False
        '
        'ChkMarcarTodo
        '
        Me.ChkMarcarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkMarcarTodo.BackColor = System.Drawing.Color.Transparent
        Me.ChkMarcarTodo.BackColorInternal = System.Drawing.Color.Transparent
        Me.ChkMarcarTodo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
        Me.ChkMarcarTodo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkMarcarTodo.Location = New System.Drawing.Point(896, 35)
        Me.ChkMarcarTodo.Name = "ChkMarcarTodo"
        Me.ChkMarcarTodo.Size = New System.Drawing.Size(86, 24)
        Me.ChkMarcarTodo.TabIndex = 135
        Me.ChkMarcarTodo.Text = "Marcar Todo"
        '
        'Cbo3
        '
        Me.Cbo3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cbo3.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.Cbo3.Location = New System.Drawing.Point(364, 33)
        Me.Cbo3.Name = "Cbo3"
        Me.Cbo3.Size = New System.Drawing.Size(199, 21)
        Me.Cbo3.TabIndex = 129
        '
        'UltraLabel8
        '
        Appearance38.BackColor = System.Drawing.Color.Transparent
        Appearance38.TextHAlignAsString = "Right"
        Me.UltraLabel8.Appearance = Appearance38
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel8.Location = New System.Drawing.Point(314, 36)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(47, 17)
        Me.UltraLabel8.TabIndex = 128
        Me.UltraLabel8.Text = "Módulo :"
        '
        'Cbo2
        '
        Me.Cbo2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cbo2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem4.DataValue = "M"
        ValueListItem4.DisplayText = "MAESTRO"
        ValueListItem5.DataValue = "L"
        ValueListItem5.DisplayText = "PLANEAMIENTO"
        ValueListItem6.DataValue = "C"
        ValueListItem6.DisplayText = "CONSULTAS"
        Me.Cbo2.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem4, ValueListItem5, ValueListItem6})
        Me.Cbo2.Location = New System.Drawing.Point(615, 34)
        Me.Cbo2.Name = "Cbo2"
        Me.Cbo2.Size = New System.Drawing.Size(196, 21)
        Me.Cbo2.TabIndex = 10
        '
        'UltraLabel6
        '
        Appearance17.BackColor = System.Drawing.Color.Transparent
        Appearance17.TextHAlignAsString = "Right"
        Me.UltraLabel6.Appearance = Appearance17
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(571, 37)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(41, 17)
        Me.UltraLabel6.TabIndex = 9
        Me.UltraLabel6.Text = "Grupo :"
        '
        'Grid2
        '
        Me.Grid2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid2.DisplayLayout.Appearance = Appearance49
        Me.Grid2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance52.Image = CType(resources.GetObject("Appearance52.Image"), Object)
        Appearance52.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance52.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn9.Header.Appearance = Appearance52
        UltraGridColumn9.Header.Caption = ""
        UltraGridColumn9.Header.VisiblePosition = 1
        UltraGridColumn9.MaxWidth = 40
        UltraGridColumn9.MinWidth = 40
        UltraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn9.Width = 40
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 13.0!
        Appearance1.ForeColorDisabled = System.Drawing.SystemColors.ControlText
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        UltraGridColumn10.CellAppearance = Appearance1
        UltraGridColumn10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance18.TextHAlignAsString = "Center"
        Appearance18.TextVAlignAsString = "Middle"
        UltraGridColumn10.Header.Appearance = Appearance18
        UltraGridColumn10.Header.VisiblePosition = 0
        Appearance2.TextVAlignAsString = "Middle"
        UltraGridColumn10.MergedCellAppearance = Appearance2
        UltraGridColumn10.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
        UltraGridColumn10.MinWidth = 315
        UltraGridColumn10.Width = 699
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance19.TextHAlignAsString = "Center"
        Appearance19.TextVAlignAsString = "Middle"
        UltraGridColumn11.Header.Appearance = Appearance19
        UltraGridColumn11.Header.Caption = "Operación"
        UltraGridColumn11.Header.VisiblePosition = 2
        UltraGridColumn11.MaxWidth = 200
        UltraGridColumn11.MinWidth = 200
        UltraGridColumn11.Width = 200
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn9, UltraGridColumn10, UltraGridColumn11})
        Me.Grid2.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.Grid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance53.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance53.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.GroupByBox.Appearance = Appearance53
        Appearance54.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance54
        Me.Grid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid2.DisplayLayout.GroupByBox.Hidden = True
        Appearance55.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance55.BackColor2 = System.Drawing.SystemColors.Control
        Appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance55.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.PromptAppearance = Appearance55
        Me.Grid2.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid2.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance58.BackColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.CardAreaAppearance = Appearance58
        Appearance59.BorderColor = System.Drawing.Color.Silver
        Appearance59.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid2.DisplayLayout.Override.CellAppearance = Appearance59
        Me.Grid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid2.DisplayLayout.Override.CellPadding = 0
        Me.Grid2.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance60.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid2.DisplayLayout.Override.FilterRowAppearance = Appearance60
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid2.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance61.BackColor = System.Drawing.SystemColors.Control
        Appearance61.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance61.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance61.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.GroupByRowAppearance = Appearance61
        Appearance62.FontData.Name = "Arial Narrow"
        Appearance62.FontData.SizeInPoints = 10.0!
        Appearance62.TextHAlignAsString = "Left"
        Me.Grid2.DisplayLayout.Override.HeaderAppearance = Appearance62
        Me.Grid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid2.DisplayLayout.Override.MinRowHeight = 24
        Appearance63.BackColor = System.Drawing.SystemColors.Window
        Appearance63.BorderColor = System.Drawing.Color.Silver
        Appearance63.TextVAlignAsString = "Middle"
        Me.Grid2.DisplayLayout.Override.RowAppearance = Appearance63
        Me.Grid2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid2.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid2.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance64.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid2.DisplayLayout.Override.TemplateAddRowAppearance = Appearance64
        Me.Grid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid2.Location = New System.Drawing.Point(3, 63)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Size = New System.Drawing.Size(996, 284)
        Me.Grid2.TabIndex = 127
        Me.Grid2.Text = "UltraGrid1"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance156.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance156
        Me.UltraGroupBox1.Controls.Add(Me.GroupBox1)
        Me.UltraGroupBox1.Controls.Add(Me.txtuserclonar)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel9)
        Me.UltraGroupBox1.Controls.Add(Me.ChkAdmin)
        Me.UltraGroupBox1.Controls.Add(Me.Txt3)
        Me.UltraGroupBox1.Controls.Add(Me.Lbl1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBox1.Controls.Add(Me.Btn2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox1.Controls.Add(Me.Cbo1)
        Me.UltraGroupBox1.Controls.Add(Me.Txt5)
        Me.UltraGroupBox1.Controls.Add(Me.Txt4)
        Me.UltraGroupBox1.Controls.Add(Me.Txt2)
        Me.UltraGroupBox1.Controls.Add(Me.Txt1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Appearance162.FontData.BoldAsString = "True"
        Appearance162.FontData.Name = "Arial Narrow"
        Appearance162.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox1.HeaderAppearance = Appearance162
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox1.Location = New System.Drawing.Point(11, 9)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1002, 196)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "DATOS GENERALES"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkVerPedido)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.chkAprobPedido)
        Me.GroupBox1.Location = New System.Drawing.Point(757, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(230, 100)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Permiso de aprobaciones"
        '
        'chkVerPedido
        '
        Me.chkVerPedido.AutoSize = True
        Me.chkVerPedido.Location = New System.Drawing.Point(16, 45)
        Me.chkVerPedido.Name = "chkVerPedido"
        Me.chkVerPedido.Size = New System.Drawing.Size(152, 17)
        Me.chkVerPedido.TabIndex = 2
        Me.chkVerPedido.Text = "Vizualizar pedidos por area"
        Me.chkVerPedido.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(16, 68)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(139, 17)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "Conformidad de servicio"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'chkAprobPedido
        '
        Me.chkAprobPedido.AutoSize = True
        Me.chkAprobPedido.Location = New System.Drawing.Point(16, 24)
        Me.chkAprobPedido.Name = "chkAprobPedido"
        Me.chkAprobPedido.Size = New System.Drawing.Size(179, 17)
        Me.chkAprobPedido.TabIndex = 0
        Me.chkAprobPedido.Text = "Aprobacion pedido de suministro"
        Me.chkAprobPedido.UseVisualStyleBackColor = True
        '
        'txtuserclonar
        '
        Appearance20.Image = "User.png"
        Appearance20.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.txtuserclonar.Appearance = Appearance20
        Me.txtuserclonar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtuserclonar.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtuserclonar.ImageList = Me.Iml1
        Me.txtuserclonar.Location = New System.Drawing.Point(606, 147)
        Me.txtuserclonar.MaxLength = 10
        Me.txtuserclonar.Name = "txtuserclonar"
        Me.txtuserclonar.ReadOnly = True
        Me.txtuserclonar.Size = New System.Drawing.Size(122, 22)
        Me.txtuserclonar.TabIndex = 18
        '
        'Iml1
        '
        Me.Iml1.ImageStream = CType(resources.GetObject("Iml1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Iml1.TransparentColor = System.Drawing.Color.Transparent
        Me.Iml1.Images.SetKeyName(0, "Crystal_Clear_kdm_user_male[1].png")
        Me.Iml1.Images.SetKeyName(1, "Administrator.png")
        Me.Iml1.Images.SetKeyName(2, "User.png")
        Me.Iml1.Images.SetKeyName(3, "Consultar.png")
        Me.Iml1.Images.SetKeyName(4, "email.png")
        Me.Iml1.Images.SetKeyName(5, "Find.png")
        '
        'UltraLabel9
        '
        Appearance21.BackColor = System.Drawing.Color.Transparent
        Appearance21.TextHAlignAsString = "Left"
        Me.UltraLabel9.Appearance = Appearance21
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel9.Location = New System.Drawing.Point(606, 121)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(95, 23)
        Me.UltraLabel9.TabIndex = 17
        Me.UltraLabel9.Text = "Usuario a clonar"
        '
        'ChkAdmin
        '
        Me.ChkAdmin.BackColor = System.Drawing.Color.Transparent
        Me.ChkAdmin.BackColorInternal = System.Drawing.Color.Transparent
        Me.ChkAdmin.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
        Me.ChkAdmin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkAdmin.Location = New System.Drawing.Point(290, 90)
        Me.ChkAdmin.Name = "ChkAdmin"
        Me.ChkAdmin.Size = New System.Drawing.Size(97, 18)
        Me.ChkAdmin.TabIndex = 16
        Me.ChkAdmin.Text = "Jefe de Area"
        '
        'Txt3
        '
        Appearance6.Image = "Crystal_Clear_kdm_user_male[1].png"
        Appearance6.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance6.TextHAlignAsString = "Center"
        Appearance6.TextVAlignAsString = "Middle"
        Me.Txt3.Appearance = Appearance6
        Me.Txt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt3.Location = New System.Drawing.Point(150, 120)
        Me.Txt3.MaxLength = 60
        Me.Txt3.Name = "Txt3"
        Me.Txt3.ReadOnly = True
        Me.Txt3.Size = New System.Drawing.Size(70, 21)
        Me.Txt3.TabIndex = 15
        '
        'Lbl1
        '
        Appearance157.BackColor = System.Drawing.Color.Transparent
        Appearance157.FontData.BoldAsString = "True"
        Appearance157.FontData.ItalicAsString = "True"
        Appearance157.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Lbl1.Appearance = Appearance157
        Me.Lbl1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Lbl1.Location = New System.Drawing.Point(150, 175)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(198, 21)
        Me.Lbl1.TabIndex = 14
        '
        'UltraLabel7
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.ForeColor = System.Drawing.Color.MidnightBlue
        Appearance13.TextHAlignAsString = "Center"
        Me.UltraLabel7.Appearance = Appearance13
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel7.Location = New System.Drawing.Point(319, 24)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(73, 36)
        Me.UltraLabel7.TabIndex = 11
        Me.UltraLabel7.Text = "Verificar disponibilidad"
        '
        'Btn2
        '
        Appearance14.Image = "Find.png"
        Appearance14.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.Btn2.Appearance = Appearance14
        Me.Btn2.Enabled = False
        Me.Btn2.ImageList = Me.Iml1
        Me.Btn2.Location = New System.Drawing.Point(290, 29)
        Me.Btn2.Name = "Btn2"
        Me.Btn2.Size = New System.Drawing.Size(31, 22)
        Me.Btn2.TabIndex = 10
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.Location = New System.Drawing.Point(472, 30)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(99, 77)
        Me.UltraPictureBox1.TabIndex = 9
        '
        'UltraLabel5
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance15
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel5.Location = New System.Drawing.Point(69, 90)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel5.TabIndex = 8
        Me.UltraLabel5.Text = "& * Estado :"
        '
        'Cbo1
        '
        Me.Cbo1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cbo1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "A"
        ValueListItem1.DisplayText = "ACTIVO"
        ValueListItem2.DataValue = "I"
        ValueListItem2.DisplayText = "INACTIVO"
        ValueListItem3.DataValue = "E"
        ValueListItem3.DisplayText = "ELIMINADO"
        Me.Cbo1.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.Cbo1.Location = New System.Drawing.Point(150, 90)
        Me.Cbo1.Name = "Cbo1"
        Me.Cbo1.ReadOnly = True
        Me.Cbo1.Size = New System.Drawing.Size(122, 21)
        Me.Cbo1.TabIndex = 1
        '
        'Txt5
        '
        Appearance7.Image = "email.png"
        Appearance7.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt5.Appearance = Appearance7
        Me.Txt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt5.ImageList = Me.Iml1
        Me.Txt5.Location = New System.Drawing.Point(150, 150)
        Me.Txt5.MaxLength = 60
        Me.Txt5.Name = "Txt5"
        Me.Txt5.ReadOnly = True
        Me.Txt5.Size = New System.Drawing.Size(421, 22)
        Me.Txt5.TabIndex = 7
        '
        'Txt4
        '
        Appearance16.Image = "Crystal_Clear_kdm_user_male[1].png"
        Appearance16.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt4.Appearance = Appearance16
        Me.Txt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt4.ImageList = Me.Iml1
        Me.Txt4.Location = New System.Drawing.Point(225, 120)
        Me.Txt4.MaxLength = 60
        Me.Txt4.Name = "Txt4"
        Me.Txt4.Size = New System.Drawing.Size(345, 22)
        Me.Txt4.TabIndex = 6
        '
        'Txt2
        '
        Appearance4.Image = "Consultar.png"
        Appearance4.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt2.Appearance = Appearance4
        Me.Txt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt2.ImageList = Me.Iml1
        Me.Txt2.Location = New System.Drawing.Point(150, 60)
        Me.Txt2.MaxLength = 100
        Me.Txt2.Name = "Txt2"
        Me.Txt2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt2.ReadOnly = True
        Me.Txt2.Size = New System.Drawing.Size(122, 22)
        Me.Txt2.TabIndex = 5
        '
        'Txt1
        '
        Appearance22.Image = "User.png"
        Appearance22.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt1.Appearance = Appearance22
        Me.Txt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt1.ImageList = Me.Iml1
        Me.Txt1.Location = New System.Drawing.Point(150, 30)
        Me.Txt1.MaxLength = 8
        Me.Txt1.Name = "Txt1"
        Me.Txt1.ReadOnly = True
        Me.Txt1.Size = New System.Drawing.Size(122, 22)
        Me.Txt1.TabIndex = 4
        '
        'UltraLabel4
        '
        Appearance163.BackColor = System.Drawing.Color.Transparent
        Appearance163.TextHAlignAsString = "Right"
        Me.UltraLabel4.Appearance = Appearance163
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(69, 150)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel4.TabIndex = 3
        Me.UltraLabel4.Text = "& Email :"
        '
        'UltraLabel3
        '
        Appearance159.BackColor = System.Drawing.Color.Transparent
        Appearance159.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance159
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(44, 120)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel3.TabIndex = 2
        Me.UltraLabel3.Text = "& * Colaborador :"
        '
        'UltraLabel2
        '
        Appearance160.BackColor = System.Drawing.Color.Transparent
        Appearance160.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance160
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(20, 60)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(124, 23)
        Me.UltraLabel2.TabIndex = 1
        Me.UltraLabel2.Text = "& * Contraseña :"
        '
        'UltraLabel1
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Appearance23.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance23
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(69, 30)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel1.TabIndex = 0
        Me.UltraLabel1.Text = "& * Usuario :"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.gridArea)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(1024, 572)
        '
        'gridArea
        '
        Appearance46.BackColor = System.Drawing.SystemColors.Window
        Appearance46.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridArea.DisplayLayout.Appearance = Appearance46
        Me.gridArea.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance47.Image = CType(resources.GetObject("Appearance47.Image"), Object)
        Appearance47.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance47.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn12.Header.Appearance = Appearance47
        UltraGridColumn12.Header.Caption = ""
        UltraGridColumn12.Header.VisiblePosition = 0
        UltraGridColumn12.MaxWidth = 100
        UltraGridColumn12.MinWidth = 20
        UltraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn12.Width = 62
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.Caption = "CODIGO"
        UltraGridColumn13.Header.VisiblePosition = 1
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 123
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn14.Header.Caption = "AREA"
        UltraGridColumn14.Header.VisiblePosition = 2
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.Header.VisiblePosition = 3
        UltraGridColumn15.Hidden = True
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn16.Header.VisiblePosition = 4
        UltraGridColumn16.Hidden = True
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16})
        Appearance57.TextVAlignAsString = "Middle"
        UltraGridBand3.Override.RowAppearance = Appearance57
        Me.gridArea.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.gridArea.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridArea.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridArea.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance65.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance65.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance65.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance65.BorderColor = System.Drawing.SystemColors.Window
        Me.gridArea.DisplayLayout.GroupByBox.Appearance = Appearance65
        Appearance66.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridArea.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance66
        Me.gridArea.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridArea.DisplayLayout.GroupByBox.Hidden = True
        Appearance67.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance67.BackColor2 = System.Drawing.SystemColors.Control
        Appearance67.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance67.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridArea.DisplayLayout.GroupByBox.PromptAppearance = Appearance67
        Me.gridArea.DisplayLayout.MaxColScrollRegions = 1
        Me.gridArea.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridArea.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridArea.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridArea.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance68.BackColor = System.Drawing.SystemColors.Window
        Me.gridArea.DisplayLayout.Override.CardAreaAppearance = Appearance68
        Appearance69.BorderColor = System.Drawing.Color.Silver
        Appearance69.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridArea.DisplayLayout.Override.CellAppearance = Appearance69
        Me.gridArea.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridArea.DisplayLayout.Override.CellPadding = 0
        Me.gridArea.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridArea.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridArea.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridArea.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance70.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridArea.DisplayLayout.Override.FilterRowAppearance = Appearance70
        Me.gridArea.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridArea.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridArea.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance71.BackColor = System.Drawing.SystemColors.Control
        Appearance71.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance71.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance71.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance71.BorderColor = System.Drawing.SystemColors.Window
        Me.gridArea.DisplayLayout.Override.GroupByRowAppearance = Appearance71
        Appearance72.FontData.Name = "Arial Narrow"
        Appearance72.FontData.SizeInPoints = 10.0!
        Appearance72.TextHAlignAsString = "Left"
        Me.gridArea.DisplayLayout.Override.HeaderAppearance = Appearance72
        Me.gridArea.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridArea.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridArea.DisplayLayout.Override.MinRowHeight = 24
        Appearance73.BackColor = System.Drawing.SystemColors.Window
        Appearance73.BorderColor = System.Drawing.Color.Silver
        Me.gridArea.DisplayLayout.Override.RowAppearance = Appearance73
        Me.gridArea.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridArea.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridArea.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance74.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridArea.DisplayLayout.Override.TemplateAddRowAppearance = Appearance74
        Me.gridArea.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridArea.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridArea.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridArea.Location = New System.Drawing.Point(0, 0)
        Me.gridArea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gridArea.Name = "gridArea"
        Me.gridArea.Size = New System.Drawing.Size(1024, 572)
        Me.gridArea.TabIndex = 150
        Me.gridArea.Text = "UltraGrid1"
        '
        'Tab1
        '
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial Narrow"
        Appearance3.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance3
        Appearance5.FontData.Name = "Arial Narrow"
        Appearance5.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance5
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl2)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl3)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(1028, 610)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance11
        Me.Tab1.TabIndex = 0
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
        UltraTab3.Text = "USUARIOS"
        Appearance25.Cursor = System.Windows.Forms.Cursors.Default
        Appearance25.FontData.BoldAsString = "True"
        Appearance25.FontData.Name = "Arial Narrow"
        Appearance25.FontData.SizeInPoints = 16.0!
        UltraTab4.ActiveAppearance = Appearance25
        Appearance10.FontData.Name = "Arial Narrow"
        Appearance10.FontData.SizeInPoints = 10.0!
        UltraTab4.Appearance = Appearance10
        UltraTab4.Key = "T02"
        UltraTab4.TabPage = Me.UltraTabPageControl2
        UltraTab4.Text = "DESCRIPCION"
        UltraTab1.Key = "T03"
        UltraTab1.TabPage = Me.UltraTabPageControl3
        UltraTab1.Text = "AREAS POR USUARIO"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3, UltraTab4, UltraTab1})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1024, 572)
        '
        'Ep1
        '
        Me.Ep1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep1.ContainerControl = Me
        '
        'Ep2
        '
        Me.Ep2.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep2.ContainerControl = Me
        Me.Ep2.Icon = CType(resources.GetObject("Ep2.Icon"), System.Drawing.Icon)
        '
        'FrmMUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 610)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmMUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "M01"
        Me.Text = "Usuarios"
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Navigator1.ResumeLayout(False)
        Me.Navigator1.PerformLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Stb1.ResumeLayout(False)
        Me.Stb1.PerformLayout()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.cboSistema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtuserclonar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        CType(Me.gridArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.Ep1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ep2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt5 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Cbo1 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Cbo2 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Iml1 As System.Windows.Forms.ImageList
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents Grid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents Grid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Btn2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Ep2 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Lbl1 As Infragistics.Win.Misc.UltraLabel

    Sub Evento_KeyDown_Grilla(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Grid1.KeyDown, Grid2.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid1 OrElse sender Is Grid2) Then Return

        With sender
            Select Case e.KeyValue
                Case Keys.Up
                    .PerformAction(ExitEditMode)
                    .PerformAction(AboveCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Down
                    .PerformAction(ExitEditMode)
                    .PerformAction(BelowCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Right
                    .PerformAction(ExitEditMode)
                    .PerformAction(NextCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Left
                    .PerformAction(ExitEditMode)
                    .PerformAction(PrevCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Return
                    .PerformAction(ExitEditMode)
                    .PerformAction(NextCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
            End Select
        End With




    End Sub
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
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Txt3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Cbo3 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ChkMarcarTodo As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents ChkAdmin As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents txtuserclonar As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAprobPedido As System.Windows.Forms.CheckBox
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents gridArea As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cboSistema As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkVerPedido As System.Windows.Forms.CheckBox


End Class
