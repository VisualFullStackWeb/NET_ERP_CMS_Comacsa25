Imports Infragistics.Win.UltraWinGrid.UltraGridAction
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLCronograma
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
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance144 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance146 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance153 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance147 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance149 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance148 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem23 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem24 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem26 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem25 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLCronograma))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodClase", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodTipo", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Placa", 2)
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Turno1", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Turno2", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Turno3", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Turno4", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesTurno1", 8)
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesTurno2", 9)
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesTurno3", 10)
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesTurno4", 11)
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesTipo", 12)
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 13)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha", 14)
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance110 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodPersonal", 0)
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance112 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesPersonal", 1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim Appearance113 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance126 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance137 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance129 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance130 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance131 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance132 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance133 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance134 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance135 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem17 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance136 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab7 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance150 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab8 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance151 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance152 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance154 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance141 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance142 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance143 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl8 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox6 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt9 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt8 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt7 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.NumU3 = New System.Windows.Forms.NumericUpDown
        Me.NumU2 = New System.Windows.Forms.NumericUpDown
        Me.NumU1 = New System.Windows.Forms.NumericUpDown
        Me.UltraTabPageControl9 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox7 = New Infragistics.Win.Misc.UltraGroupBox
        Me.NumE1 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl10 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox8 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel17 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Ops1 = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Tab3 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage3 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Grid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Navigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.Cbo1 = New System.Windows.Forms.ToolStripComboBox
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Gpb1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Grid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Tool1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Chk2 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.Chk1 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.dTxt3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt6 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt5 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Cbo3 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.Cbo2 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Tab2 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Grb1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.dTxt2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.dTxt1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Dt1 = New System.Windows.Forms.DateTimePicker
        Me.Txt2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraTabPageControl7 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraTabPageControl8.SuspendLayout()
        CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox6.SuspendLayout()
        CType(Me.Txt9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumU3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumU2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumU1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl9.SuspendLayout()
        CType(Me.UltraGroupBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox7.SuspendLayout()
        CType(Me.NumE1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl10.SuspendLayout()
        CType(Me.UltraGroupBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox8.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.Ops1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl6.SuspendLayout()
        CType(Me.Tab3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab3.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Navigator1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl5.SuspendLayout()
        CType(Me.Gpb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gpb1.SuspendLayout()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.dTxt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab2.SuspendLayout()
        CType(Me.Grb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grb1.SuspendLayout()
        CType(Me.dTxt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTxt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl8
        '
        Me.UltraTabPageControl8.Controls.Add(Me.UltraGroupBox6)
        Me.UltraTabPageControl8.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl8.Name = "UltraTabPageControl8"
        Me.UltraTabPageControl8.Size = New System.Drawing.Size(799, 226)
        '
        'UltraGroupBox6
        '
        Appearance14.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox6.ContentAreaAppearance = Appearance14
        Me.UltraGroupBox6.Controls.Add(Me.UltraLabel15)
        Me.UltraGroupBox6.Controls.Add(Me.UltraLabel14)
        Me.UltraGroupBox6.Controls.Add(Me.Txt9)
        Me.UltraGroupBox6.Controls.Add(Me.Txt8)
        Me.UltraGroupBox6.Controls.Add(Me.Txt7)
        Me.UltraGroupBox6.Controls.Add(Me.UltraLabel13)
        Me.UltraGroupBox6.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox6.Controls.Add(Me.NumU3)
        Me.UltraGroupBox6.Controls.Add(Me.NumU2)
        Me.UltraGroupBox6.Controls.Add(Me.NumU1)
        Appearance26.FontData.BoldAsString = "True"
        Appearance26.FontData.Name = "Arial Narrow"
        Appearance26.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox6.HeaderAppearance = Appearance26
        Me.UltraGroupBox6.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox6.Location = New System.Drawing.Point(5, 9)
        Me.UltraGroupBox6.Name = "UltraGroupBox6"
        Me.UltraGroupBox6.Size = New System.Drawing.Size(641, 189)
        Me.UltraGroupBox6.TabIndex = 3
        Me.UltraGroupBox6.Text = "INGRESE LOS TURNOS A ROTAR"
        Me.UltraGroupBox6.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'UltraLabel15
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel15.Appearance = Appearance15
        Me.UltraLabel15.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel15.Location = New System.Drawing.Point(20, 67)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(262, 66)
        Me.UltraLabel15.TabIndex = 120
        Me.UltraLabel15.Text = "1.- Ingrese la rotación del turno según  corresponda.  2.- Las rotaciones a ingre" & _
            "sar no pueden ser iguales.    3.- Las rotaciones a ingresar se aplicarán a la se" & _
            "mana anterior."
        '
        'UltraLabel14
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel14.Appearance = Appearance16
        Me.UltraLabel14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.UltraLabel14.Location = New System.Drawing.Point(20, 46)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.Size = New System.Drawing.Size(245, 18)
        Me.UltraLabel14.TabIndex = 130
        Me.UltraLabel14.Text = "NOTA"
        '
        'Txt9
        '
        Appearance17.BackColor = System.Drawing.Color.White
        Appearance17.FontData.Name = "Arial"
        Appearance17.FontData.SizeInPoints = 9.0!
        Appearance17.TextHAlignAsString = "Center"
        Me.Txt9.Appearance = Appearance17
        Me.Txt9.AutoSize = False
        Me.Txt9.BackColor = System.Drawing.Color.White
        Me.Txt9.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt9.Location = New System.Drawing.Point(314, 113)
        Me.Txt9.Name = "Txt9"
        Me.Txt9.ReadOnly = True
        Me.Txt9.Size = New System.Drawing.Size(41, 20)
        Me.Txt9.TabIndex = 129
        Me.Txt9.Text = "3"
        '
        'Txt8
        '
        Appearance18.BackColor = System.Drawing.Color.White
        Appearance18.FontData.Name = "Arial"
        Appearance18.FontData.SizeInPoints = 9.0!
        Appearance18.TextHAlignAsString = "Center"
        Me.Txt8.Appearance = Appearance18
        Me.Txt8.AutoSize = False
        Me.Txt8.BackColor = System.Drawing.Color.White
        Me.Txt8.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt8.Location = New System.Drawing.Point(314, 90)
        Me.Txt8.Name = "Txt8"
        Me.Txt8.ReadOnly = True
        Me.Txt8.Size = New System.Drawing.Size(41, 20)
        Me.Txt8.TabIndex = 128
        Me.Txt8.Text = "2"
        '
        'Txt7
        '
        Appearance19.BackColor = System.Drawing.Color.White
        Appearance19.FontData.Name = "Arial"
        Appearance19.FontData.SizeInPoints = 9.0!
        Appearance19.TextHAlignAsString = "Center"
        Me.Txt7.Appearance = Appearance19
        Me.Txt7.AutoSize = False
        Me.Txt7.BackColor = System.Drawing.Color.White
        Me.Txt7.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt7.Location = New System.Drawing.Point(314, 67)
        Me.Txt7.Name = "Txt7"
        Me.Txt7.ReadOnly = True
        Me.Txt7.Size = New System.Drawing.Size(41, 20)
        Me.Txt7.TabIndex = 126
        Me.Txt7.Text = "1"
        '
        'UltraLabel13
        '
        Appearance22.BackColor = System.Drawing.Color.Transparent
        Appearance22.TextHAlignAsString = "Center"
        Me.UltraLabel13.Appearance = Appearance22
        Me.UltraLabel13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.UltraLabel13.Location = New System.Drawing.Point(381, 31)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(66, 35)
        Me.UltraLabel13.TabIndex = 127
        Me.UltraLabel13.Text = "Turnos a Rotar"
        '
        'UltraLabel12
        '
        Appearance25.BackColor = System.Drawing.Color.Transparent
        Appearance25.TextHAlignAsString = "Center"
        Me.UltraLabel12.Appearance = Appearance25
        Me.UltraLabel12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.UltraLabel12.Location = New System.Drawing.Point(306, 31)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(58, 35)
        Me.UltraLabel12.TabIndex = 126
        Me.UltraLabel12.Text = "Turnos Actuales"
        '
        'NumU3
        '
        Me.NumU3.Location = New System.Drawing.Point(393, 113)
        Me.NumU3.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumU3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumU3.Name = "NumU3"
        Me.NumU3.Size = New System.Drawing.Size(44, 20)
        Me.NumU3.TabIndex = 124
        Me.NumU3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumU3.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumU2
        '
        Me.NumU2.Location = New System.Drawing.Point(393, 90)
        Me.NumU2.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumU2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumU2.Name = "NumU2"
        Me.NumU2.Size = New System.Drawing.Size(44, 20)
        Me.NumU2.TabIndex = 122
        Me.NumU2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumU2.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'NumU1
        '
        Me.NumU1.Location = New System.Drawing.Point(393, 67)
        Me.NumU1.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumU1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumU1.Name = "NumU1"
        Me.NumU1.Size = New System.Drawing.Size(44, 20)
        Me.NumU1.TabIndex = 120
        Me.NumU1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumU1.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'UltraTabPageControl9
        '
        Me.UltraTabPageControl9.Controls.Add(Me.UltraGroupBox7)
        Me.UltraTabPageControl9.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl9.Name = "UltraTabPageControl9"
        Me.UltraTabPageControl9.Size = New System.Drawing.Size(799, 226)
        '
        'UltraGroupBox7
        '
        Appearance11.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox7.ContentAreaAppearance = Appearance11
        Me.UltraGroupBox7.Controls.Add(Me.NumE1)
        Me.UltraGroupBox7.Controls.Add(Me.UltraLabel16)
        Appearance28.FontData.BoldAsString = "True"
        Appearance28.FontData.Name = "Arial Narrow"
        Appearance28.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox7.HeaderAppearance = Appearance28
        Me.UltraGroupBox7.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox7.Location = New System.Drawing.Point(5, 8)
        Me.UltraGroupBox7.Name = "UltraGroupBox7"
        Me.UltraGroupBox7.Size = New System.Drawing.Size(641, 189)
        Me.UltraGroupBox7.TabIndex = 4
        Me.UltraGroupBox7.Text = "INGRESE LA SEMANA A IMPORTAR"
        Me.UltraGroupBox7.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'NumE1
        '
        Appearance21.TextHAlignAsString = "Center"
        Me.NumE1.Appearance = Appearance21
        Me.NumE1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.NumE1.FormatString = "#0"
        Me.NumE1.Location = New System.Drawing.Point(208, 44)
        Me.NumE1.MaskInput = "nn"
        Me.NumE1.Name = "NumE1"
        Me.NumE1.NullText = "0"
        Me.NumE1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.NumE1.Size = New System.Drawing.Size(51, 21)
        Me.NumE1.TabIndex = 131
        '
        'UltraLabel16
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel16.Appearance = Appearance23
        Me.UltraLabel16.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel16.Location = New System.Drawing.Point(40, 46)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(171, 19)
        Me.UltraLabel16.TabIndex = 120
        Me.UltraLabel16.Text = " Ingrese la Semana a Importar. "
        '
        'UltraTabPageControl10
        '
        Me.UltraTabPageControl10.Controls.Add(Me.UltraGroupBox8)
        Me.UltraTabPageControl10.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl10.Name = "UltraTabPageControl10"
        Me.UltraTabPageControl10.Size = New System.Drawing.Size(799, 226)
        '
        'UltraGroupBox8
        '
        Appearance144.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox8.ContentAreaAppearance = Appearance144
        Me.UltraGroupBox8.Controls.Add(Me.UltraLabel17)
        Appearance146.FontData.BoldAsString = "True"
        Appearance146.FontData.Name = "Arial Narrow"
        Appearance146.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox8.HeaderAppearance = Appearance146
        Me.UltraGroupBox8.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox8.Location = New System.Drawing.Point(5, 8)
        Me.UltraGroupBox8.Name = "UltraGroupBox8"
        Me.UltraGroupBox8.Size = New System.Drawing.Size(641, 189)
        Me.UltraGroupBox8.TabIndex = 5
        Me.UltraGroupBox8.Text = "INGRESE LA SEMANA A IMPORTAR"
        Me.UltraGroupBox8.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'UltraLabel17
        '
        Appearance153.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel17.Appearance = Appearance153
        Me.UltraLabel17.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel17.Location = New System.Drawing.Point(40, 46)
        Me.UltraLabel17.Name = "UltraLabel17"
        Me.UltraLabel17.Size = New System.Drawing.Size(171, 19)
        Me.UltraLabel17.TabIndex = 120
        Me.UltraLabel17.Text = " En Construccion"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox4)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(803, 249)
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance147.BackColor = System.Drawing.Color.White
        Appearance147.BackColor2 = System.Drawing.Color.White
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance147
        Me.UltraGroupBox4.Controls.Add(Me.Ops1)
        Appearance149.FontData.BoldAsString = "True"
        Appearance149.FontData.Name = "Arial Narrow"
        Appearance149.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox4.HeaderAppearance = Appearance149
        Me.UltraGroupBox4.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox4.Location = New System.Drawing.Point(8, 14)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(788, 206)
        Me.UltraGroupBox4.TabIndex = 118
        Me.UltraGroupBox4.Text = "SELECCIONE UNA OPCION"
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Ops1
        '
        Appearance148.FontData.Name = "Arial Narrow"
        Appearance148.FontData.SizeInPoints = 10.0!
        Me.Ops1.Appearance = Appearance148
        Me.Ops1.BackColor = System.Drawing.Color.White
        Me.Ops1.BackColorInternal = System.Drawing.Color.White
        Me.Ops1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Ops1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ops1.ItemOrigin = New System.Drawing.Point(10, 10)
        ValueListItem23.DataValue = "Chk1"
        ValueListItem23.DisplayText = "Opción 1 : Usar la Programación de la Semana anterior rotando Turnos"
        ValueListItem24.DataValue = "Chk2"
        ValueListItem24.DisplayText = "Opción 2 : Usar la Programación de la Semana anterior"
        ValueListItem26.DataValue = "Chk3"
        ValueListItem26.DisplayText = "Opción 3 : Usar la Programación de otra Semana pasada"
        ValueListItem25.DataValue = "Chk4"
        ValueListItem25.DisplayText = "Opción 4 : Usar la Programación de la Plantilla"
        Me.Ops1.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem23, ValueListItem24, ValueListItem26, ValueListItem25})
        Me.Ops1.ItemSpacingHorizontal = 2
        Me.Ops1.ItemSpacingVertical = 8
        Me.Ops1.Location = New System.Drawing.Point(3, 23)
        Me.Ops1.Name = "Ops1"
        Me.Ops1.Size = New System.Drawing.Size(782, 180)
        Me.Ops1.TabIndex = 117
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.Tab3)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(803, 249)
        '
        'Tab3
        '
        Me.Tab3.Controls.Add(Me.UltraTabSharedControlsPage3)
        Me.Tab3.Controls.Add(Me.UltraTabPageControl8)
        Me.Tab3.Controls.Add(Me.UltraTabPageControl9)
        Me.Tab3.Controls.Add(Me.UltraTabPageControl10)
        Me.Tab3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab3.Location = New System.Drawing.Point(0, 0)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.SharedControlsPage = Me.UltraTabSharedControlsPage3
        Me.Tab3.Size = New System.Drawing.Size(803, 249)
        Me.Tab3.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.Tab3.TabIndex = 128
        Me.Tab3.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowTabsPerRow
        Appearance88.FontData.BoldAsString = "True"
        Appearance88.FontData.SizeInPoints = 10.0!
        UltraTab1.ActiveAppearance = Appearance88
        UltraTab1.Key = "T01"
        UltraTab1.TabPage = Me.UltraTabPageControl8
        UltraTab1.Text = "OPCION 1"
        Appearance10.FontData.BoldAsString = "True"
        Appearance10.FontData.SizeInPoints = 10.0!
        UltraTab5.ActiveAppearance = Appearance10
        UltraTab5.Key = "T02"
        UltraTab5.TabPage = Me.UltraTabPageControl9
        UltraTab5.Text = "OPCION 3"
        UltraTab2.Key = "T03"
        UltraTab2.TabPage = Me.UltraTabPageControl10
        UltraTab2.Text = "OPCION 4"
        Me.Tab3.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab5, UltraTab2})
        Me.Tab3.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        Me.Tab3.Visible = False
        '
        'UltraTabSharedControlsPage3
        '
        Me.UltraTabSharedControlsPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage3.Name = "UltraTabSharedControlsPage3"
        Me.UltraTabSharedControlsPage3.Size = New System.Drawing.Size(799, 226)
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(807, 272)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance45.BorderColor = System.Drawing.Color.Transparent
        Appearance45.BorderColor2 = System.Drawing.Color.Transparent
        Me.UltraGroupBox1.Appearance = Appearance45
        Appearance46.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance46
        Me.UltraGroupBox1.Controls.Add(Me.Grid1)
        Me.UltraGroupBox1.Controls.Add(Me.Navigator1)
        Appearance105.FontData.BoldAsString = "True"
        Appearance105.FontData.Name = "Arial Narrow"
        Appearance105.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox1.HeaderAppearance = Appearance105
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox1.Location = New System.Drawing.Point(9, 6)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(790, 261)
        Me.UltraGroupBox1.TabIndex = 3
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Grid1
        '
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Appearance47.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid1.DisplayLayout.Appearance = Appearance47
        Me.Grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance55.Image = CType(resources.GetObject("Appearance55.Image"), Object)
        Appearance55.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance55.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance55
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 201
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 46
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance56.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance56
        UltraGridColumn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance58.TextHAlignAsString = "Center"
        UltraGridColumn4.Header.Appearance = Appearance58
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.MaxWidth = 80
        UltraGridColumn4.MinWidth = 80
        UltraGridColumn4.Width = 80
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.MinWidth = 250
        UltraGridColumn5.Width = 250
        UltraGridColumn6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn6.DataType = GetType(Boolean)
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 56
        UltraGridColumn7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn7.DataType = GetType(Boolean)
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 65
        UltraGridColumn8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn8.DataType = GetType(Boolean)
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 76
        UltraGridColumn9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn9.DataType = GetType(Boolean)
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 92
        UltraGridColumn10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate
        Appearance59.BackColor = System.Drawing.Color.White
        Appearance59.BackColor2 = System.Drawing.Color.LightGray
        Appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Appearance59.TextHAlignAsString = "Center"
        UltraGridColumn10.CellAppearance = Appearance59
        Appearance60.ForeColor = System.Drawing.SystemColors.Highlight
        UltraGridColumn10.CellButtonAppearance = Appearance60
        Appearance61.TextHAlignAsString = "Center"
        UltraGridColumn10.Header.Appearance = Appearance61
        UltraGridColumn10.Header.Caption = "Turno Nro 1"
        UltraGridColumn10.Header.VisiblePosition = 10
        UltraGridColumn10.MaxWidth = 100
        UltraGridColumn10.MinWidth = 100
        UltraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn10.Width = 100
        UltraGridColumn11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate
        Appearance62.BackColor = System.Drawing.Color.White
        Appearance62.BackColor2 = System.Drawing.Color.LightGray
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Appearance62.TextHAlignAsString = "Center"
        UltraGridColumn11.CellAppearance = Appearance62
        Appearance63.ForeColor = System.Drawing.SystemColors.Highlight
        UltraGridColumn11.CellButtonAppearance = Appearance63
        Appearance64.TextHAlignAsString = "Center"
        UltraGridColumn11.Header.Appearance = Appearance64
        UltraGridColumn11.Header.Caption = "Turno Nro 2"
        UltraGridColumn11.Header.VisiblePosition = 11
        UltraGridColumn11.MaxWidth = 100
        UltraGridColumn11.MinWidth = 100
        UltraGridColumn11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn11.Width = 100
        UltraGridColumn12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate
        Appearance65.BackColor = System.Drawing.Color.White
        Appearance65.BackColor2 = System.Drawing.Color.LightGray
        Appearance65.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Appearance65.TextHAlignAsString = "Center"
        UltraGridColumn12.CellAppearance = Appearance65
        Appearance66.ForeColor = System.Drawing.SystemColors.Highlight
        UltraGridColumn12.CellButtonAppearance = Appearance66
        Appearance69.TextHAlignAsString = "Center"
        UltraGridColumn12.Header.Appearance = Appearance69
        UltraGridColumn12.Header.Caption = "Turno Nro 3"
        UltraGridColumn12.Header.VisiblePosition = 12
        UltraGridColumn12.MaxWidth = 100
        UltraGridColumn12.MinWidth = 100
        UltraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn12.Width = 100
        UltraGridColumn13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate
        Appearance81.BackColor = System.Drawing.Color.White
        Appearance81.BackColor2 = System.Drawing.Color.LightGray
        Appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Appearance81.TextHAlignAsString = "Center"
        UltraGridColumn13.CellAppearance = Appearance81
        Appearance82.ForeColor = System.Drawing.SystemColors.Highlight
        UltraGridColumn13.CellButtonAppearance = Appearance82
        Appearance83.TextHAlignAsString = "Center"
        UltraGridColumn13.Header.Appearance = Appearance83
        UltraGridColumn13.Header.Caption = "Horario Normal"
        UltraGridColumn13.Header.VisiblePosition = 13
        UltraGridColumn13.MaxWidth = 100
        UltraGridColumn13.MinWidth = 100
        UltraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn13.Width = 100
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance84.FontData.BoldAsString = "True"
        Appearance84.ForeColor = System.Drawing.Color.White
        UltraGridColumn14.CellAppearance = Appearance84
        UltraGridColumn14.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance85.TextHAlignAsString = "Center"
        UltraGridColumn14.Header.Appearance = Appearance85
        UltraGridColumn14.Header.Caption = "Tipo"
        UltraGridColumn14.Header.VisiblePosition = 0
        UltraGridColumn14.MaxWidth = 120
        UltraGridColumn14.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
        UltraGridColumn14.MinWidth = 120
        UltraGridColumn14.Width = 120
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 8
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 8
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16})
        Me.Grid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance86.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance86.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance86.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance86.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.GroupByBox.Appearance = Appearance86
        Appearance87.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance87
        Me.Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance89.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance89.BackColor2 = System.Drawing.SystemColors.Control
        Appearance89.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance89.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance89
        Me.Grid1.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid1.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid1.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Appearance91.BackColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.CardAreaAppearance = Appearance91
        Appearance94.BorderColor = System.Drawing.Color.Silver
        Appearance94.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid1.DisplayLayout.Override.CellAppearance = Appearance94
        Appearance95.FontData.BoldAsString = "True"
        Appearance95.ForeColor = System.Drawing.Color.White
        Me.Grid1.DisplayLayout.Override.CellButtonAppearance = Appearance95
        Me.Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid1.DisplayLayout.Override.CellDisplayStyle = Infragistics.Win.UltraWinGrid.CellDisplayStyle.FormattedText
        Me.Grid1.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance100.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance100.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.Grid1.DisplayLayout.Override.FilterRowAppearance = Appearance100
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance101.BackColor = System.Drawing.SystemColors.Control
        Appearance101.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance101.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance101.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance101.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.GroupByRowAppearance = Appearance101
        Appearance102.FontData.Name = "Arial Narrow"
        Appearance102.FontData.SizeInPoints = 10.0!
        Appearance102.TextHAlignAsString = "Left"
        Me.Grid1.DisplayLayout.Override.HeaderAppearance = Appearance102
        Me.Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid1.DisplayLayout.Override.MinRowHeight = 24
        Appearance103.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance103.TextVAlignAsString = "Middle"
        Me.Grid1.DisplayLayout.Override.RowAppearance = Appearance103
        Me.Grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.Location = New System.Drawing.Point(3, 29)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(784, 229)
        Me.Grid1.TabIndex = 144
        Me.Grid1.Text = "UltraGrid1"
        '
        'Navigator1
        '
        Me.Navigator1.AddNewItem = Nothing
        Me.Navigator1.BackColor = System.Drawing.Color.Transparent
        Me.Navigator1.BindingSource = Me.Source1
        Me.Navigator1.CountItem = Me.BindingNavigatorCountItem
        Me.Navigator1.DeleteItem = Nothing
        Me.Navigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Navigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorSeparator, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorMoveNextItem, Me.ToolStripSeparator2, Me.BindingNavigatorCountItem, Me.BindingNavigatorPositionItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorMoveFirstItem, Me.ToolStripSeparator3, Me.ToolStripLabel3, Me.ToolStripSeparator8, Me.Cbo1})
        Me.Navigator1.Location = New System.Drawing.Point(3, 4)
        Me.Navigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Navigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Navigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Navigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Navigator1.Name = "Navigator1"
        Me.Navigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.Navigator1.Size = New System.Drawing.Size(784, 25)
        Me.Navigator1.Stretch = True
        Me.Navigator1.TabIndex = 143
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel3.Text = "          "
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'Cbo1
        '
        Me.Cbo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo1.Items.AddRange(New Object() {"Miercoles", "Jueves", "Viernes", "Sabado", "Domingo", "Lunes", "Martes"})
        Me.Cbo1.Name = "Cbo1"
        Me.Cbo1.Size = New System.Drawing.Size(121, 25)
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.Gpb1)
        Me.UltraTabPageControl5.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(807, 272)
        '
        'Gpb1
        '
        Me.Gpb1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance108.BackColor = System.Drawing.Color.White
        Me.Gpb1.ContentAreaAppearance = Appearance108
        Me.Gpb1.Controls.Add(Me.Grid2)
        Me.Gpb1.Controls.Add(Me.Tool1)
        Appearance125.FontData.BoldAsString = "True"
        Appearance125.FontData.Name = "Arial Narrow"
        Appearance125.FontData.SizeInPoints = 10.0!
        Me.Gpb1.HeaderAppearance = Appearance125
        Me.Gpb1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Gpb1.Location = New System.Drawing.Point(9, 151)
        Me.Gpb1.Name = "Gpb1"
        Me.Gpb1.Size = New System.Drawing.Size(790, 111)
        Me.Gpb1.TabIndex = 126
        Me.Gpb1.Text = "LISTADO DEL PERSONAL"
        Me.Gpb1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Grid2
        '
        Appearance109.BackColor = System.Drawing.SystemColors.Window
        Appearance109.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid2.DisplayLayout.Appearance = Appearance109
        Me.Grid2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance110.Image = CType(resources.GetObject("Appearance110.Image"), Object)
        Appearance110.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance110.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn17.Header.Appearance = Appearance110
        UltraGridColumn17.Header.Caption = ""
        UltraGridColumn17.Header.VisiblePosition = 0
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.MaxWidth = 25
        UltraGridColumn17.MinWidth = 25
        UltraGridColumn17.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn17.Width = 25
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance111.TextHAlignAsString = "Center"
        UltraGridColumn18.CellAppearance = Appearance111
        UltraGridColumn18.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance112.TextHAlignAsString = "Center"
        UltraGridColumn18.Header.Appearance = Appearance112
        UltraGridColumn18.Header.Caption = "Codigo"
        UltraGridColumn18.Header.VisiblePosition = 1
        UltraGridColumn18.Width = 120
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn19.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn19.Header.Caption = "Descripcion"
        UltraGridColumn19.Header.VisiblePosition = 2
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn17, UltraGridColumn18, UltraGridColumn19})
        Me.Grid2.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.Grid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance113.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance113.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance113.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance113.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.GroupByBox.Appearance = Appearance113
        Appearance114.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance114
        Me.Grid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid2.DisplayLayout.GroupByBox.Hidden = True
        Appearance117.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance117.BackColor2 = System.Drawing.SystemColors.Control
        Appearance117.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance117.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.PromptAppearance = Appearance117
        Me.Grid2.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid2.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance118.BackColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.CardAreaAppearance = Appearance118
        Appearance119.BorderColor = System.Drawing.Color.Silver
        Appearance119.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid2.DisplayLayout.Override.CellAppearance = Appearance119
        Me.Grid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid2.DisplayLayout.Override.CellPadding = 0
        Me.Grid2.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance120.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid2.DisplayLayout.Override.FilterRowAppearance = Appearance120
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid2.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance121.BackColor = System.Drawing.SystemColors.Control
        Appearance121.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance121.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance121.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance121.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.GroupByRowAppearance = Appearance121
        Appearance122.FontData.Name = "Arial Narrow"
        Appearance122.FontData.SizeInPoints = 10.0!
        Appearance122.TextHAlignAsString = "Left"
        Me.Grid2.DisplayLayout.Override.HeaderAppearance = Appearance122
        Me.Grid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid2.DisplayLayout.Override.MinRowHeight = 24
        Appearance123.BackColor = System.Drawing.SystemColors.Window
        Appearance123.BorderColor = System.Drawing.Color.Silver
        Appearance123.TextVAlignAsString = "Middle"
        Me.Grid2.DisplayLayout.Override.RowAppearance = Appearance123
        Me.Grid2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid2.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid2.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance124.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid2.DisplayLayout.Override.TemplateAddRowAppearance = Appearance124
        Me.Grid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid2.Location = New System.Drawing.Point(3, 48)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Size = New System.Drawing.Size(784, 60)
        Me.Grid2.TabIndex = 132
        Me.Grid2.Text = "UltraGrid1"
        '
        'Tool1
        '
        Me.Tool1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tool1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator4, Me.Btn1, Me.ToolStripSeparator5, Me.Btn2, Me.ToolStripSeparator6})
        Me.Tool1.Location = New System.Drawing.Point(3, 23)
        Me.Tool1.Name = "Tool1"
        Me.Tool1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Tool1.Size = New System.Drawing.Size(784, 25)
        Me.Tool1.TabIndex = 131
        Me.Tool1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(34, 22)
        Me.ToolStripLabel1.Text = "         "
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'Btn1
        '
        Me.Btn1.Enabled = False
        Me.Btn1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn1.Image = Global.SIP_Presentacion.My.Resources.Resources.Add
        Me.Btn1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn1.Name = "Btn1"
        Me.Btn1.Size = New System.Drawing.Size(76, 22)
        Me.Btn1.Text = "AGREGAR"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'Btn2
        '
        Me.Btn2.Enabled = False
        Me.Btn2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn2.Image = Global.SIP_Presentacion.My.Resources.Resources.Delete1
        Me.Btn2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn2.Name = "Btn2"
        Me.Btn2.Size = New System.Drawing.Size(67, 22)
        Me.Btn2.Text = "QUITAR"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance126.BackColor = System.Drawing.Color.White
        Appearance126.BackColor2 = System.Drawing.Color.White
        Me.UltraGroupBox2.ContentAreaAppearance = Appearance126
        Me.UltraGroupBox2.Controls.Add(Me.Chk2)
        Me.UltraGroupBox2.Controls.Add(Me.Chk1)
        Me.UltraGroupBox2.Controls.Add(Me.dTxt3)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel10)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox2.Controls.Add(Me.Txt6)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox2.Controls.Add(Me.Txt5)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox2.Controls.Add(Me.Txt4)
        Me.UltraGroupBox2.Controls.Add(Me.Txt3)
        Me.UltraGroupBox2.Controls.Add(Me.Cbo3)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox2.Controls.Add(Me.Cbo2)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Appearance137.FontData.BoldAsString = "True"
        Appearance137.FontData.Name = "Arial Narrow"
        Appearance137.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox2.HeaderAppearance = Appearance137
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox2.Location = New System.Drawing.Point(9, 7)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(790, 140)
        Me.UltraGroupBox2.TabIndex = 114
        Me.UltraGroupBox2.Text = "DESCRIPCION DEL TURNO"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Chk2
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Me.Chk2.Appearance = Appearance3
        Me.Chk2.BackColor = System.Drawing.Color.White
        Me.Chk2.BackColorInternal = System.Drawing.Color.White
        Me.Chk2.Location = New System.Drawing.Point(580, 30)
        Me.Chk2.Name = "Chk2"
        Me.Chk2.Size = New System.Drawing.Size(160, 20)
        Me.Chk2.TabIndex = 128
        Me.Chk2.Text = "Incluir Todo el Personal"
        '
        'Chk1
        '
        Appearance4.BackColor = System.Drawing.Color.White
        Me.Chk1.Appearance = Appearance4
        Me.Chk1.BackColor = System.Drawing.Color.White
        Me.Chk1.BackColorInternal = System.Drawing.Color.White
        Me.Chk1.Location = New System.Drawing.Point(414, 30)
        Me.Chk1.Name = "Chk1"
        Me.Chk1.Size = New System.Drawing.Size(160, 20)
        Me.Chk1.TabIndex = 127
        Me.Chk1.Text = "Aplicar en Toda la Semana"
        '
        'dTxt3
        '
        Appearance127.FontData.Name = "Arial"
        Appearance127.FontData.SizeInPoints = 9.0!
        Me.dTxt3.Appearance = Appearance127
        Me.dTxt3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dTxt3.Location = New System.Drawing.Point(154, 28)
        Me.dTxt3.Name = "dTxt3"
        Me.dTxt3.ReadOnly = True
        Me.dTxt3.Size = New System.Drawing.Size(243, 22)
        Me.dTxt3.TabIndex = 126
        '
        'UltraLabel10
        '
        Appearance128.BackColor = System.Drawing.Color.Transparent
        Appearance128.TextHAlignAsString = "Right"
        Me.UltraLabel10.Appearance = Appearance128
        Me.UltraLabel10.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel10.Location = New System.Drawing.Point(100, 29)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(48, 21)
        Me.UltraLabel10.TabIndex = 125
        Me.UltraLabel10.Text = "Fecha :"
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance129.BackColor = System.Drawing.Color.Transparent
        Appearance129.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance129
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel5.Location = New System.Drawing.Point(548, 83)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(77, 21)
        Me.UltraLabel5.TabIndex = 124
        Me.UltraLabel5.Text = "Hora Final :"
        '
        'Txt6
        '
        Me.Txt6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance130.TextHAlignAsString = "Center"
        Me.Txt6.Appearance = Appearance130
        Me.Txt6.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt6.Location = New System.Drawing.Point(631, 83)
        Me.Txt6.Name = "Txt6"
        Me.Txt6.ReadOnly = True
        Me.Txt6.Size = New System.Drawing.Size(77, 21)
        Me.Txt6.TabIndex = 123
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance131.BackColor = System.Drawing.Color.Transparent
        Appearance131.TextHAlignAsString = "Right"
        Me.UltraLabel4.Appearance = Appearance131
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(548, 56)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(77, 21)
        Me.UltraLabel4.TabIndex = 122
        Me.UltraLabel4.Text = "Hora Inicio :"
        '
        'Txt5
        '
        Me.Txt5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance132.TextHAlignAsString = "Center"
        Me.Txt5.Appearance = Appearance132
        Me.Txt5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt5.Location = New System.Drawing.Point(631, 56)
        Me.Txt5.Name = "Txt5"
        Me.Txt5.ReadOnly = True
        Me.Txt5.Size = New System.Drawing.Size(77, 21)
        Me.Txt5.TabIndex = 121
        '
        'UltraLabel3
        '
        Appearance133.BackColor = System.Drawing.Color.Transparent
        Appearance133.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance133
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(100, 110)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(48, 21)
        Me.UltraLabel3.TabIndex = 120
        Me.UltraLabel3.Text = "Unidad :"
        '
        'Txt4
        '
        Me.Txt4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt4.Location = New System.Drawing.Point(238, 110)
        Me.Txt4.Name = "Txt4"
        Me.Txt4.ReadOnly = True
        Me.Txt4.Size = New System.Drawing.Size(470, 21)
        Me.Txt4.TabIndex = 119
        '
        'Txt3
        '
        Appearance134.TextHAlignAsString = "Center"
        Me.Txt3.Appearance = Appearance134
        Me.Txt3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt3.Location = New System.Drawing.Point(154, 110)
        Me.Txt3.Name = "Txt3"
        Me.Txt3.ReadOnly = True
        Me.Txt3.Size = New System.Drawing.Size(78, 21)
        Me.Txt3.TabIndex = 118
        '
        'Cbo3
        '
        Me.Cbo3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cbo3.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem4.DataValue = "02"
        ValueListItem4.DisplayText = "Chancadora"
        ValueListItem9.DataValue = "01"
        ValueListItem9.DisplayText = "Molino"
        Me.Cbo3.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem4, ValueListItem9})
        Me.Cbo3.Location = New System.Drawing.Point(154, 83)
        Me.Cbo3.Name = "Cbo3"
        Me.Cbo3.ReadOnly = True
        Me.Cbo3.Size = New System.Drawing.Size(119, 21)
        Me.Cbo3.TabIndex = 117
        '
        'UltraLabel2
        '
        Appearance135.BackColor = System.Drawing.Color.Transparent
        Appearance135.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance135
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(100, 83)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(48, 21)
        Me.UltraLabel2.TabIndex = 116
        Me.UltraLabel2.Text = "Tipo :"
        '
        'Cbo2
        '
        Me.Cbo2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cbo2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem10.DataValue = "1"
        ValueListItem10.DisplayText = "Primero"
        ValueListItem11.DataValue = "2"
        ValueListItem11.DisplayText = "Segundo"
        ValueListItem12.DataValue = "3"
        ValueListItem12.DisplayText = "Tercero"
        ValueListItem17.DataValue = "4"
        ValueListItem17.DisplayText = "Horario Normal"
        Me.Cbo2.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem10, ValueListItem11, ValueListItem12, ValueListItem17})
        Me.Cbo2.Location = New System.Drawing.Point(154, 56)
        Me.Cbo2.Name = "Cbo2"
        Me.Cbo2.ReadOnly = True
        Me.Cbo2.Size = New System.Drawing.Size(119, 21)
        Me.Cbo2.TabIndex = 115
        '
        'UltraLabel1
        '
        Appearance136.BackColor = System.Drawing.Color.Transparent
        Appearance136.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance136
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(100, 56)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(48, 21)
        Me.UltraLabel1.TabIndex = 114
        Me.UltraLabel1.Text = "Turno :"
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Tab2)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(807, 272)
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab2.Controls.Add(Me.UltraTabPageControl2)
        Me.Tab2.Controls.Add(Me.UltraTabPageControl6)
        Me.Tab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab2.Location = New System.Drawing.Point(0, 0)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab2.Size = New System.Drawing.Size(807, 272)
        Me.Tab2.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.Tab2.TabIndex = 127
        Me.Tab2.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance150.FontData.BoldAsString = "True"
        Appearance150.FontData.SizeInPoints = 10.0!
        UltraTab7.ActiveAppearance = Appearance150
        UltraTab7.Key = "T01"
        UltraTab7.TabPage = Me.UltraTabPageControl2
        UltraTab7.Text = "OPCION"
        Appearance151.FontData.BoldAsString = "True"
        Appearance151.FontData.SizeInPoints = 10.0!
        UltraTab8.ActiveAppearance = Appearance151
        UltraTab8.Key = "T02"
        UltraTab8.TabPage = Me.UltraTabPageControl6
        UltraTab8.Text = "DESCRIPCION"
        Me.Tab2.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab7, UltraTab8})
        Me.Tab2.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(803, 249)
        '
        'Grb1
        '
        Me.Grb1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance152.BackColor = System.Drawing.Color.White
        Me.Grb1.ContentAreaAppearance = Appearance152
        Me.Grb1.Controls.Add(Me.dTxt2)
        Me.Grb1.Controls.Add(Me.UltraLabel6)
        Me.Grb1.Controls.Add(Me.dTxt1)
        Me.Grb1.Controls.Add(Me.Dt1)
        Me.Grb1.Controls.Add(Me.Txt2)
        Me.Grb1.Controls.Add(Me.Txt1)
        Me.Grb1.Controls.Add(Me.UltraLabel11)
        Me.Grb1.Controls.Add(Me.UltraLabel9)
        Me.Grb1.Controls.Add(Me.UltraLabel8)
        Me.Grb1.Controls.Add(Me.UltraLabel7)
        Appearance154.FontData.BoldAsString = "True"
        Appearance154.FontData.Name = "Arial Narrow"
        Appearance154.FontData.SizeInPoints = 10.0!
        Me.Grb1.HeaderAppearance = Appearance154
        Me.Grb1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Grb1.Location = New System.Drawing.Point(12, 6)
        Me.Grb1.Name = "Grb1"
        Me.Grb1.Size = New System.Drawing.Size(798, 178)
        Me.Grb1.TabIndex = 2
        Me.Grb1.Text = "DATOS DE BUSQUEDA"
        Me.Grb1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'dTxt2
        '
        Appearance44.BackColor = System.Drawing.Color.White
        Appearance44.FontData.Name = "Arial"
        Appearance44.FontData.SizeInPoints = 9.0!
        Me.dTxt2.Appearance = Appearance44
        Me.dTxt2.BackColor = System.Drawing.Color.White
        Me.dTxt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dTxt2.Location = New System.Drawing.Point(276, 135)
        Me.dTxt2.Name = "dTxt2"
        Me.dTxt2.ReadOnly = True
        Me.dTxt2.Size = New System.Drawing.Size(243, 22)
        Me.dTxt2.TabIndex = 125
        '
        'UltraLabel6
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextHAlignAsString = "Right"
        Me.UltraLabel6.Appearance = Appearance13
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(50, 36)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(220, 22)
        Me.UltraLabel6.TabIndex = 119
        Me.UltraLabel6.Text = "Ingrese Fecha Referencial de Busqueda :"
        '
        'dTxt1
        '
        Appearance43.BackColor = System.Drawing.Color.White
        Appearance43.FontData.Name = "Arial"
        Appearance43.FontData.SizeInPoints = 9.0!
        Me.dTxt1.Appearance = Appearance43
        Me.dTxt1.BackColor = System.Drawing.Color.White
        Me.dTxt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dTxt1.Location = New System.Drawing.Point(276, 108)
        Me.dTxt1.Name = "dTxt1"
        Me.dTxt1.ReadOnly = True
        Me.dTxt1.Size = New System.Drawing.Size(243, 22)
        Me.dTxt1.TabIndex = 124
        '
        'Dt1
        '
        Me.Dt1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dt1.Location = New System.Drawing.Point(276, 33)
        Me.Dt1.MaxDate = New Date(2020, 12, 31, 0, 0, 0, 0)
        Me.Dt1.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.Dt1.Name = "Dt1"
        Me.Dt1.Size = New System.Drawing.Size(243, 21)
        Me.Dt1.TabIndex = 116
        '
        'Txt2
        '
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.FontData.Name = "Arial"
        Appearance7.FontData.SizeInPoints = 9.0!
        Appearance7.TextHAlignAsString = "Center"
        Me.Txt2.Appearance = Appearance7
        Me.Txt2.BackColor = System.Drawing.Color.White
        Me.Txt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt2.Location = New System.Drawing.Point(463, 80)
        Me.Txt2.Name = "Txt2"
        Me.Txt2.ReadOnly = True
        Me.Txt2.Size = New System.Drawing.Size(56, 22)
        Me.Txt2.TabIndex = 123
        '
        'Txt1
        '
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.FontData.Name = "Arial"
        Appearance8.FontData.SizeInPoints = 9.0!
        Appearance8.TextHAlignAsString = "Center"
        Me.Txt1.Appearance = Appearance8
        Me.Txt1.BackColor = System.Drawing.Color.White
        Me.Txt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt1.Location = New System.Drawing.Point(276, 80)
        Me.Txt1.Name = "Txt1"
        Me.Txt1.ReadOnly = True
        Me.Txt1.Size = New System.Drawing.Size(56, 22)
        Me.Txt1.TabIndex = 122
        '
        'UltraLabel11
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Right"
        Me.UltraLabel11.Appearance = Appearance1
        Me.UltraLabel11.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel11.Location = New System.Drawing.Point(194, 82)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(76, 23)
        Me.UltraLabel11.TabIndex = 0
        Me.UltraLabel11.Text = "Nro Semana :"
        '
        'UltraLabel9
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Right"
        Me.UltraLabel9.Appearance = Appearance12
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel9.Location = New System.Drawing.Point(50, 138)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(220, 22)
        Me.UltraLabel9.TabIndex = 121
        Me.UltraLabel9.Text = "Fecha de Cierre de Semana :"
        '
        'UltraLabel8
        '
        Appearance30.BackColor = System.Drawing.Color.Transparent
        Appearance30.TextHAlignAsString = "Right"
        Me.UltraLabel8.Appearance = Appearance30
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel8.Location = New System.Drawing.Point(50, 111)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(220, 22)
        Me.UltraLabel8.TabIndex = 119
        Me.UltraLabel8.Text = "Fecha de Inicio de Semana :"
        '
        'UltraLabel7
        '
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Appearance20.TextHAlignAsString = "Right"
        Me.UltraLabel7.Appearance = Appearance20
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel7.Location = New System.Drawing.Point(423, 80)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(34, 23)
        Me.UltraLabel7.TabIndex = 114
        Me.UltraLabel7.Text = "Año :"
        '
        'Tab1
        '
        Me.Tab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl3)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl5)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Location = New System.Drawing.Point(1, 190)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.Tab1.Size = New System.Drawing.Size(811, 295)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Appearance2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance2
        Me.Tab1.TabIndex = 126
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance141.Cursor = System.Windows.Forms.Cursors.Default
        Appearance141.FontData.BoldAsString = "True"
        Appearance141.FontData.SizeInPoints = 10.0!
        UltraTab3.ActiveAppearance = Appearance141
        UltraTab3.Key = "T01"
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "DETALLE"
        Appearance142.Cursor = System.Windows.Forms.Cursors.Default
        Appearance142.FontData.BoldAsString = "True"
        Appearance142.FontData.SizeInPoints = 10.0!
        UltraTab4.ActiveAppearance = Appearance142
        UltraTab4.Key = "T02"
        UltraTab4.TabPage = Me.UltraTabPageControl5
        UltraTab4.Text = "CONSULTAS"
        Appearance143.Cursor = System.Windows.Forms.Cursors.Default
        Appearance143.FontData.BoldAsString = "True"
        Appearance143.FontData.SizeInPoints = 10.0!
        UltraTab6.ActiveAppearance = Appearance143
        UltraTab6.Key = "T03"
        UltraTab6.TabPage = Me.UltraTabPageControl1
        UltraTab6.Text = "IMPORTAR"
        UltraTab6.Visible = False
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3, UltraTab4, UltraTab6})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(807, 272)
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(658, 329)
        '
        'UltraTabPageControl7
        '
        Me.UltraTabPageControl7.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl7.Name = "UltraTabPageControl7"
        Me.UltraTabPageControl7.Size = New System.Drawing.Size(604, 102)
        '
        'FrmLCronograma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(814, 485)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.Grb1)
        Me.HelpButton = True
        Me.Name = "FrmLCronograma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "L03"
        Me.Text = "CRONOGRAMA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.UltraTabPageControl8.ResumeLayout(False)
        CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox6.ResumeLayout(False)
        CType(Me.Txt9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumU3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumU2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumU1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl9.ResumeLayout(False)
        CType(Me.UltraGroupBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox7.ResumeLayout(False)
        Me.UltraGroupBox7.PerformLayout()
        CType(Me.NumE1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl10.ResumeLayout(False)
        CType(Me.UltraGroupBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox8.ResumeLayout(False)
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        CType(Me.Ops1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl6.ResumeLayout(False)
        CType(Me.Tab3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab3.ResumeLayout(False)
        Me.UltraTabPageControl3.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Navigator1.ResumeLayout(False)
        Me.Navigator1.PerformLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl5.ResumeLayout(False)
        CType(Me.Gpb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gpb1.ResumeLayout(False)
        Me.Gpb1.PerformLayout()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool1.ResumeLayout(False)
        Me.Tool1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.dTxt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab2.ResumeLayout(False)
        CType(Me.Grb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grb1.ResumeLayout(False)
        Me.Grb1.PerformLayout()
        CType(Me.dTxt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTxt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grb1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Gpb1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Cbo2 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Cbo3 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt6 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt5 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Ops1 As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Dt1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dTxt1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dTxt2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dTxt3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Tab2 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl7 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Tab3 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage3 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl8 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl9 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox6 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents NumU1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumU3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumU2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt9 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt8 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt7 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox7 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents NumE1 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents UltraTabPageControl10 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox8 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel17 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Tool1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Grid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents Navigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cbo1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Grid1 As Infragistics.Win.UltraWinGrid.UltraGrid

    Sub Evento_KeyDown_Grillla(ByVal sender As Object, ByVal e As KeyEventArgs) Handles _
                               Grid1.KeyDown, Grid2.KeyDown

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
                    .PerformAction(BelowCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
            End Select
        End With
        
    End Sub
    Friend WithEvents Chk1 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents Chk2 As Infragistics.Win.UltraWinEditors.UltraCheckEditor


End Class
