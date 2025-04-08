<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCOrden
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCOrden))
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance141 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodProducto", 0)
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocumento", 1)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha", 3)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 4)
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Status", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesStatus", 6)
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance116 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Me.Stb1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar
        Me.Gbp1 = New Infragistics.Win.Misc.UltraExpandableGroupBox
        Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Txt2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Dt2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.Dt1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Iml1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Grid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Navigator1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Stb1.SuspendLayout()
        CType(Me.Gbp1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gbp1.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Navigator1
        '
        Me.Navigator1.AddNewItem = Nothing
        Me.Navigator1.BackColor = System.Drawing.Color.Transparent
        Me.Navigator1.BindingSource = Me.Source1
        Me.Navigator1.CountItem = Me.BindingNavigatorCountItem
        Me.Navigator1.DeleteItem = Nothing
        Me.Navigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Navigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorSeparator, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorMoveNextItem, Me.ToolStripSeparator5, Me.BindingNavigatorCountItem, Me.BindingNavigatorPositionItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorMoveFirstItem, Me.ToolStripSeparator6, Me.Btn1, Me.ToolStripSeparator2})
        Me.Navigator1.Location = New System.Drawing.Point(0, 0)
        Me.Navigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Navigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Navigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Navigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Navigator1.Name = "Navigator1"
        Me.Navigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.Navigator1.Size = New System.Drawing.Size(665, 25)
        Me.Navigator1.Stretch = True
        Me.Navigator1.TabIndex = 142
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
        'Stb1
        '
        Me.Stb1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Stb1.Controls.Add(Me.Navigator1)
        Me.Stb1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Stb1.Location = New System.Drawing.Point(0, 0)
        Me.Stb1.Name = "Stb1"
        UltraStatusPanel1.Control = Me.Navigator1
        UltraStatusPanel1.Key = "Nav1"
        UltraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        Me.Stb1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1})
        Me.Stb1.Size = New System.Drawing.Size(665, 24)
        Me.Stb1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Stb1.TabIndex = 147
        Me.Stb1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'Gbp1
        '
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Gbp1.ContentAreaAppearance = Appearance8
        Me.Gbp1.Controls.Add(Me.UltraExpandableGroupBoxPanel1)
        Me.Gbp1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Gbp1.Expanded = False
        Me.Gbp1.ExpandedSize = New System.Drawing.Size(665, 133)
        Appearance7.FontData.BoldAsString = "True"
        Appearance7.FontData.Name = "Arial Narrow"
        Appearance7.FontData.SizeInPoints = 10.0!
        Me.Gbp1.HeaderAppearance = Appearance7
        Me.Gbp1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Gbp1.Location = New System.Drawing.Point(0, 24)
        Me.Gbp1.Name = "Gbp1"
        Me.Gbp1.Size = New System.Drawing.Size(665, 30)
        Me.Gbp1.TabIndex = 149
        Me.Gbp1.Text = "    .: Opciones de Busqueda :."
        Me.Gbp1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraGroupBox3)
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(659, 106)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        Me.UltraExpandableGroupBoxPanel1.Visible = False
        '
        'UltraGroupBox3
        '
        Appearance21.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox3.ContentAreaAppearance = Appearance21
        Me.UltraGroupBox3.Controls.Add(Me.Txt2)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox3.Controls.Add(Me.Txt1)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox3.Controls.Add(Me.Dt2)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox3.Controls.Add(Me.Dt1)
        Me.UltraGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Appearance52.FontData.BoldAsString = "True"
        Appearance52.FontData.Name = "Arial Narrow"
        Appearance52.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox3.HeaderAppearance = Appearance52
        Me.UltraGroupBox3.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(659, 106)
        Me.UltraGroupBox3.TabIndex = 3
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Txt2
        '
        Appearance141.TextHAlignAsString = "Center"
        Me.Txt2.Appearance = Appearance141
        Me.Txt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt2.Location = New System.Drawing.Point(172, 44)
        Me.Txt2.MaxLength = 8
        Me.Txt2.Name = "Txt2"
        Me.Txt2.Size = New System.Drawing.Size(89, 21)
        Me.Txt2.TabIndex = 99
        '
        'UltraLabel4
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance9
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(10, 44)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(156, 22)
        Me.UltraLabel4.TabIndex = 98
        Me.UltraLabel4.Text = "&Código del Producto :"
        '
        'Txt1
        '
        Appearance11.TextHAlignAsString = "Center"
        Me.Txt1.Appearance = Appearance11
        Me.Txt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt1.Location = New System.Drawing.Point(172, 17)
        Me.Txt1.MaxLength = 10
        Me.Txt1.Name = "Txt1"
        Me.Txt1.Size = New System.Drawing.Size(89, 21)
        Me.Txt1.TabIndex = 97
        '
        'UltraLabel3
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance12
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(39, 17)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(127, 22)
        Me.UltraLabel3.TabIndex = 96
        Me.UltraLabel3.Text = "&Nro Documento :"
        '
        'UltraLabel1
        '
        Appearance37.BackColor = System.Drawing.Color.Transparent
        Appearance37.TextHAlignAsString = "Right"
        Appearance37.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance37
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(267, 71)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(32, 22)
        Me.UltraLabel1.TabIndex = 95
        Me.UltraLabel1.Text = "hasta"
        '
        'Dt2
        '
        Me.Dt2.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.Dt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Dt2.Location = New System.Drawing.Point(305, 71)
        Me.Dt2.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.Dt2.Name = "Dt2"
        Me.Dt2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Dt2.Size = New System.Drawing.Size(89, 21)
        Me.Dt2.TabIndex = 94
        Me.Dt2.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'UltraLabel2
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextHAlignAsString = "Right"
        Appearance13.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance13
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(39, 71)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(127, 22)
        Me.UltraLabel2.TabIndex = 93
        Me.UltraLabel2.Text = "&Rango de Fechas :"
        '
        'Dt1
        '
        Me.Dt1.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.Dt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Dt1.Location = New System.Drawing.Point(172, 71)
        Me.Dt1.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.Dt1.Name = "Dt1"
        Me.Dt1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Dt1.Size = New System.Drawing.Size(89, 21)
        Me.Dt1.TabIndex = 83
        Me.Dt1.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'Iml1
        '
        Me.Iml1.ImageStream = CType(resources.GetObject("Iml1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Iml1.TransparentColor = System.Drawing.Color.Transparent
        Me.Iml1.Images.SetKeyName(0, "Filtro.png")
        '
        'Ep1
        '
        Me.Ep1.ContainerControl = Me
        '
        'Grid1
        '
        Appearance58.BackColor = System.Drawing.SystemColors.Window
        Appearance58.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid1.DisplayLayout.Appearance = Appearance58
        Me.Grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance59.Image = CType(resources.GetObject("Appearance59.Image"), Object)
        Appearance59.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance59.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance59
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance60.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance60
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance62.TextHAlignAsString = "Center"
        UltraGridColumn2.Header.Appearance = Appearance62
        UltraGridColumn2.Header.Caption = "Código"
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.MaxWidth = 90
        UltraGridColumn2.MinWidth = 90
        UltraGridColumn2.Width = 90
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance1.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance1
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn3.Header.Appearance = Appearance4
        UltraGridColumn3.Header.VisiblePosition = 1
        UltraGridColumn3.MaxWidth = 90
        UltraGridColumn3.MinWidth = 90
        UltraGridColumn3.Width = 90
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.MinWidth = 265
        UltraGridColumn4.Width = 265
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn5.CellAppearance = Appearance2
        UltraGridColumn5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn5.DataType = GetType(Date)
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn5.Header.Appearance = Appearance5
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.MaxWidth = 90
        UltraGridColumn5.MinWidth = 90
        UltraGridColumn5.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        UltraGridColumn5.Width = 90
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn6.CellAppearance = Appearance3
        UltraGridColumn6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn6.Header.Appearance = Appearance6
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 73
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 8
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance18.TextHAlignAsString = "Center"
        UltraGridColumn8.Header.Appearance = Appearance18
        UltraGridColumn8.Header.Caption = "Estado"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.MaxWidth = 90
        UltraGridColumn8.MinWidth = 90
        UltraGridColumn8.Width = 90
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8})
        Me.Grid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance90.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance90.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance90.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance90.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.GroupByBox.Appearance = Appearance90
        Appearance92.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance92
        Me.Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance93.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance93.BackColor2 = System.Drawing.SystemColors.Control
        Appearance93.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance93.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance93
        Me.Grid1.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid1.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance96.BackColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.CardAreaAppearance = Appearance96
        Appearance97.BorderColor = System.Drawing.Color.Silver
        Appearance97.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid1.DisplayLayout.Override.CellAppearance = Appearance97
        Me.Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid1.DisplayLayout.Override.CellPadding = 0
        Me.Grid1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance98.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance98.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Grid1.DisplayLayout.Override.FilterRowAppearance = Appearance98
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance99.BackColor = System.Drawing.SystemColors.Control
        Appearance99.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance99.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance99.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance99.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.GroupByRowAppearance = Appearance99
        Appearance115.FontData.Name = "Arial Narrow"
        Appearance115.FontData.SizeInPoints = 10.0!
        Appearance115.TextHAlignAsString = "Left"
        Me.Grid1.DisplayLayout.Override.HeaderAppearance = Appearance115
        Me.Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid1.DisplayLayout.Override.MinRowHeight = 24
        Appearance116.BackColor = System.Drawing.SystemColors.Window
        Appearance116.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance116.TextVAlignAsString = "Middle"
        Me.Grid1.DisplayLayout.Override.RowAppearance = Appearance116
        Me.Grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance117.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance117
        Me.Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.Location = New System.Drawing.Point(0, 54)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(665, 431)
        Me.Grid1.TabIndex = 151
        '
        'FrmCOrden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(665, 485)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.Gbp1)
        Me.Controls.Add(Me.Stb1)
        Me.Name = "FrmCOrden"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "C09"
        Me.Text = "ORDENES DE PRODUCCIÓN"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Navigator1.ResumeLayout(False)
        Me.Navigator1.PerformLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Stb1.ResumeLayout(False)
        Me.Stb1.PerformLayout()
        CType(Me.Gbp1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gbp1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ep1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents Gbp1 As Infragistics.Win.Misc.UltraExpandableGroupBox
    Friend WithEvents UltraExpandableGroupBoxPanel1 As Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Dt2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Dt1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Iml1 As System.Windows.Forms.ImageList
    Friend WithEvents Ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents Grid1 As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
