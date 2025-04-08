<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPPresupuesto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPPresupuesto))
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Area", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Area_Abrev", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_Presup", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoCli", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cliente", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AreaInterna", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Equipo", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoMantto", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Atributo", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorControl", 10)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UniMed", 11)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Prioridad", 12)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda", 13)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total", 14)
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoCambio", 15)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaInicio", 16)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTerminacion", 17)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado", 18, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_Area", 19)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_Cli", 20)
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_ClienteInt", 21)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_AreaInt", 22)
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EquipoID", 23)
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoProceso", 24)
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AtributoControl", 25)
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_UniMed", 26)
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDato", 27)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Longitud", 28)
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Decimales", 29)
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_Prioridad", 30)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Status", 31)
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Presupuesto", 32)
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim DateButton3 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Item", 0)
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UniMed", 2)
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Metrado", 3)
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio", 4)
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Parcial", 5)
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaInicio", 6)
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTerminacion", 7)
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoFactor", 8)
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Factor", 9)
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Jornada", 10)
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Status", 11)
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_UniMed", 12)
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Partida", 13)
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Presupuesto", 14)
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PresupuestoDet", 15)
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Contar", 16)
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grb1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Txt20 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt8 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Txt7 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Chk1 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.Cbo1 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Cbo3 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Txt3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Dtp3 = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.Label12 = New Infragistics.Win.Misc.UltraLabel
        Me.Dtp2 = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.Label11 = New Infragistics.Win.Misc.UltraLabel
        Me.Label9 = New Infragistics.Win.Misc.UltraLabel
        Me.Label8 = New Infragistics.Win.Misc.UltraLabel
        Me.Cbo5 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label7 = New Infragistics.Win.Misc.UltraLabel
        Me.Cbo4 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Grb2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Rbn6 = New System.Windows.Forms.RadioButton
        Me.Rbn3 = New System.Windows.Forms.RadioButton
        Me.Rbn5 = New System.Windows.Forms.RadioButton
        Me.Rbn2 = New System.Windows.Forms.RadioButton
        Me.Rbn4 = New System.Windows.Forms.RadioButton
        Me.Rbn1 = New System.Windows.Forms.RadioButton
        Me.Label10 = New Infragistics.Win.Misc.UltraLabel
        Me.Label6 = New Infragistics.Win.Misc.UltraLabel
        Me.Dtp1 = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.Btn1 = New Infragistics.Win.Misc.UltraButton
        Me.Txt4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Btn2 = New Infragistics.Win.Misc.UltraButton
        Me.Label5 = New Infragistics.Win.Misc.UltraLabel
        Me.Label4 = New Infragistics.Win.Misc.UltraLabel
        Me.Cbo2 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt5 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt6 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cmnut1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnu1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnu2 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnu3 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnu4 = New System.Windows.Forms.ToolStripSeparator
        Me.cmnu5 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnu6 = New System.Windows.Forms.ToolStripMenuItem
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraStatusBar1.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.Grb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grb1.SuspendLayout()
        CType(Me.Txt20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtp2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grb2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grb2.SuspendLayout()
        CType(Me.Dtp1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmnut1.SuspendLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BackColor = System.Drawing.Color.Transparent
        Me.BindingNavigator1.CountItem = Me.ToolStripLabel1
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.ToolStripTextBox1, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator7, Me.ToolStripButton5, Me.ToolStripSeparator8})
        Me.BindingNavigator1.Location = New System.Drawing.Point(2, 4)
        Me.BindingNavigator1.MoveFirstItem = Me.ToolStripButton4
        Me.BindingNavigator1.MoveLastItem = Me.ToolStripButton1
        Me.BindingNavigator1.MoveNextItem = Me.ToolStripButton2
        Me.BindingNavigator1.MovePreviousItem = Me.ToolStripButton3
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.ToolStripTextBox1
        Me.BindingNavigator1.Size = New System.Drawing.Size(297, 25)
        Me.BindingNavigator1.TabIndex = 141
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel1.Text = "de {0}"
        Me.ToolStripLabel1.ToolTipText = "Número total de elementos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Mover último"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Mover siguiente"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Posición"
        Me.ToolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripTextBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 23)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolStripTextBox1.ToolTipText = "Posición actual"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Mover anterior"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Mover primero"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripButton5.Text = "SELECCIONAR"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Grid1)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraStatusBar1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(755, 441)
        '
        'Grid1
        '
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid1.DisplayLayout.Appearance = Appearance49
        Me.Grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance50.Image = CType(resources.GetObject("Appearance50.Image"), Object)
        Appearance50.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance50.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance50
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.DataType = GetType(Date)
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.MaxWidth = 65
        UltraGridColumn2.MinWidth = 65
        UltraGridColumn2.RowLayoutColumnInfo.OriginX = 0
        UltraGridColumn2.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn2.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn2.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn2.Width = 65
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.Caption = "AreaName"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 102
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.Header.Caption = "Area"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.MaxWidth = 40
        UltraGridColumn4.MinWidth = 40
        UltraGridColumn4.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn4.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn4.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn4.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn4.Width = 40
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.Header.Caption = "Código"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.MaxWidth = 60
        UltraGridColumn5.MinWidth = 60
        UltraGridColumn5.RowLayoutColumnInfo.OriginX = 4
        UltraGridColumn5.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn5.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn5.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn5.Width = 60
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.Header.Caption = "Tipo"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.MaxWidth = 50
        UltraGridColumn6.MinWidth = 50
        UltraGridColumn6.RowLayoutColumnInfo.OriginX = 6
        UltraGridColumn6.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn6.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn6.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn6.Width = 50
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.MinWidth = 150
        UltraGridColumn7.RowLayoutColumnInfo.OriginX = 8
        UltraGridColumn7.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn7.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn7.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn7.Width = 150
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 15
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.MinWidth = 150
        UltraGridColumn9.RowLayoutColumnInfo.OriginX = 10
        UltraGridColumn9.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(192, 0)
        UltraGridColumn9.RowLayoutColumnInfo.SpanX = 4
        UltraGridColumn9.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn9.Width = 154
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.Header.Caption = "Mantenimiento"
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.MinWidth = 85
        UltraGridColumn10.RowLayoutColumnInfo.OriginX = 0
        UltraGridColumn10.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(110, 0)
        UltraGridColumn10.RowLayoutColumnInfo.SpanX = 4
        UltraGridColumn10.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn10.Width = 86
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.MaxWidth = 60
        UltraGridColumn11.MinWidth = 60
        UltraGridColumn11.RowLayoutColumnInfo.OriginX = 4
        UltraGridColumn11.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn11.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(94, 0)
        UltraGridColumn11.RowLayoutColumnInfo.SpanX = 4
        UltraGridColumn11.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn11.Width = 60
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.Header.Caption = "Valor"
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.MaxWidth = 50
        UltraGridColumn12.MinWidth = 50
        UltraGridColumn12.RowLayoutColumnInfo.OriginX = 9
        UltraGridColumn12.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn12.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(150, 0)
        UltraGridColumn12.RowLayoutColumnInfo.SpanX = 4
        UltraGridColumn12.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn12.Width = 50
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.Header.Caption = "Und"
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.MaxWidth = 30
        UltraGridColumn13.MinWidth = 30
        UltraGridColumn13.RowLayoutColumnInfo.OriginX = 13
        UltraGridColumn13.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn13.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(160, 0)
        UltraGridColumn13.RowLayoutColumnInfo.SpanX = 1
        UltraGridColumn13.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn13.Width = 30
        UltraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.MaxWidth = 40
        UltraGridColumn14.MinWidth = 40
        UltraGridColumn14.RowLayoutColumnInfo.OriginX = 6
        UltraGridColumn14.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn14.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn14.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn14.Width = 40
        UltraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn15.Header.Caption = "Mon"
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.MaxWidth = 30
        UltraGridColumn15.MinWidth = 30
        UltraGridColumn15.RowLayoutColumnInfo.OriginX = 14
        UltraGridColumn15.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn15.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(60, 0)
        UltraGridColumn15.RowLayoutColumnInfo.SpanX = 1
        UltraGridColumn15.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn15.Width = 30
        UltraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance53.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance53
        UltraGridColumn16.DataType = GetType(Double)
        UltraGridColumn16.Format = "n4"
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.MaxWidth = 70
        UltraGridColumn16.MinWidth = 70
        UltraGridColumn16.RowLayoutColumnInfo.OriginX = 15
        UltraGridColumn16.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn16.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(127, 0)
        UltraGridColumn16.RowLayoutColumnInfo.SpanX = 5
        UltraGridColumn16.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn16.Width = 70
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.DataType = GetType(Double)
        UltraGridColumn17.Header.VisiblePosition = 16
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 19
        UltraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn18.DataType = GetType(Date)
        UltraGridColumn18.Header.Caption = "F. Inicio"
        UltraGridColumn18.Header.VisiblePosition = 17
        UltraGridColumn18.MaxWidth = 65
        UltraGridColumn18.MinWidth = 65
        UltraGridColumn18.RowLayoutColumnInfo.OriginX = 14
        UltraGridColumn18.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn18.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn18.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn18.Width = 65
        UltraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn19.DataType = GetType(Date)
        UltraGridColumn19.Header.Caption = "F. Termino"
        UltraGridColumn19.Header.VisiblePosition = 18
        UltraGridColumn19.MaxWidth = 65
        UltraGridColumn19.MinWidth = 65
        UltraGridColumn19.RowLayoutColumnInfo.OriginX = 17
        UltraGridColumn19.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn19.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(70, 0)
        UltraGridColumn19.RowLayoutColumnInfo.SpanX = 1
        UltraGridColumn19.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn19.Width = 65
        UltraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn20.Header.VisiblePosition = 19
        UltraGridColumn20.MaxWidth = 80
        UltraGridColumn20.MinWidth = 80
        UltraGridColumn20.RowLayoutColumnInfo.OriginX = 18
        UltraGridColumn20.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn20.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn20.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn20.Width = 80
        UltraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn21.Header.VisiblePosition = 20
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 42
        UltraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn22.Header.VisiblePosition = 21
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 43
        UltraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn23.Header.VisiblePosition = 22
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 44
        UltraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn24.Header.VisiblePosition = 23
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.Width = 50
        UltraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn25.Header.VisiblePosition = 24
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 51
        UltraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn26.Header.VisiblePosition = 25
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.Width = 52
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn27.Header.VisiblePosition = 26
        UltraGridColumn27.Hidden = True
        UltraGridColumn27.Width = 55
        UltraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn28.Header.VisiblePosition = 27
        UltraGridColumn28.Hidden = True
        UltraGridColumn28.Width = 39
        UltraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn29.Header.VisiblePosition = 28
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.Width = 43
        UltraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn30.Header.VisiblePosition = 29
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 56
        UltraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn31.Header.VisiblePosition = 30
        UltraGridColumn31.Hidden = True
        UltraGridColumn31.Width = 69
        UltraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn32.Header.VisiblePosition = 31
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.Width = 86
        UltraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn33.Header.VisiblePosition = 32
        UltraGridColumn33.Hidden = True
        UltraGridColumn33.Width = 136
        UltraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn34.Header.VisiblePosition = 33
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.Width = 93
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34})
        Me.Grid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance54.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance54.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance54.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.GroupByBox.Appearance = Appearance54
        Appearance55.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance55
        Me.Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance56.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance56.BackColor2 = System.Drawing.SystemColors.Control
        Appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance56.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance56
        Me.Grid1.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid1.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance57.BackColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.CardAreaAppearance = Appearance57
        Appearance58.BorderColor = System.Drawing.Color.Silver
        Appearance58.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid1.DisplayLayout.Override.CellAppearance = Appearance58
        Me.Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid1.DisplayLayout.Override.CellPadding = 0
        Me.Grid1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance59.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance59.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Grid1.DisplayLayout.Override.FilterRowAppearance = Appearance59
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance60.BackColor = System.Drawing.SystemColors.Control
        Appearance60.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance60.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance60.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.GroupByRowAppearance = Appearance60
        Appearance67.FontData.Name = "Arial Narrow"
        Appearance67.FontData.SizeInPoints = 10.0!
        Appearance67.TextHAlignAsString = "Left"
        Me.Grid1.DisplayLayout.Override.HeaderAppearance = Appearance67
        Me.Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid1.DisplayLayout.Override.MinRowHeight = 24
        Appearance68.BackColor = System.Drawing.SystemColors.Window
        Appearance68.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance68.TextVAlignAsString = "Middle"
        Me.Grid1.DisplayLayout.Override.RowAppearance = Appearance68
        Me.Grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance69.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance69
        Me.Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.Location = New System.Drawing.Point(0, 24)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(755, 417)
        Me.Grid1.TabIndex = 140
        Me.Grid1.Text = "UltraGrid1"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraStatusBar1.Controls.Add(Me.BindingNavigator1)
        Me.UltraStatusBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 0)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        UltraStatusPanel1.Control = Me.BindingNavigator1
        UltraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        Me.UltraStatusBar1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1})
        Me.UltraStatusBar1.Size = New System.Drawing.Size(755, 24)
        Me.UltraStatusBar1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraStatusBar1.TabIndex = 1
        Me.UltraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.Grb1)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(755, 441)
        '
        'Grb1
        '
        Me.Grb1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance43.BackColor = System.Drawing.Color.White
        Me.Grb1.ContentAreaAppearance = Appearance43
        Me.Grb1.Controls.Add(Me.Txt20)
        Me.Grb1.Controls.Add(Me.UltraLabel9)
        Me.Grb1.Controls.Add(Me.Txt8)
        Me.Grb1.Controls.Add(Me.Txt7)
        Me.Grb1.Controls.Add(Me.Chk1)
        Me.Grb1.Controls.Add(Me.Cbo1)
        Me.Grb1.Controls.Add(Me.Cbo3)
        Me.Grb1.Controls.Add(Me.Txt3)
        Me.Grb1.Controls.Add(Me.Dtp3)
        Me.Grb1.Controls.Add(Me.Label12)
        Me.Grb1.Controls.Add(Me.Dtp2)
        Me.Grb1.Controls.Add(Me.Label11)
        Me.Grb1.Controls.Add(Me.Label9)
        Me.Grb1.Controls.Add(Me.Label8)
        Me.Grb1.Controls.Add(Me.Cbo5)
        Me.Grb1.Controls.Add(Me.Label7)
        Me.Grb1.Controls.Add(Me.Cbo4)
        Me.Grb1.Controls.Add(Me.Grb2)
        Me.Grb1.Controls.Add(Me.Label10)
        Me.Grb1.Controls.Add(Me.Label6)
        Me.Grb1.Controls.Add(Me.Dtp1)
        Me.Grb1.Controls.Add(Me.Btn1)
        Me.Grb1.Controls.Add(Me.Txt4)
        Me.Grb1.Controls.Add(Me.Btn2)
        Me.Grb1.Controls.Add(Me.Label5)
        Me.Grb1.Controls.Add(Me.Label4)
        Me.Grb1.Controls.Add(Me.Cbo2)
        Me.Grb1.Controls.Add(Me.Label1)
        Me.Grb1.Controls.Add(Me.UltraLabel1)
        Me.Grb1.Controls.Add(Me.Txt2)
        Me.Grb1.Controls.Add(Me.Txt1)
        Me.Grb1.Controls.Add(Me.Label3)
        Me.Grb1.Controls.Add(Me.Txt5)
        Me.Grb1.Controls.Add(Me.Txt6)
        Appearance25.FontData.BoldAsString = "True"
        Appearance25.FontData.Name = "Arial Narrow"
        Appearance25.FontData.SizeInPoints = 10.0!
        Me.Grb1.HeaderAppearance = Appearance25
        Me.Grb1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Grb1.Location = New System.Drawing.Point(11, 14)
        Me.Grb1.Name = "Grb1"
        Me.Grb1.Size = New System.Drawing.Size(733, 418)
        Me.Grb1.TabIndex = 0
        Me.Grb1.Text = "GENERALIDADES"
        Me.Grb1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Txt20
        '
        Me.Txt20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance18.Image = "Crystal_Clear_kdm_user_male[1].png"
        Appearance18.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt20.Appearance = Appearance18
        Me.Txt20.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt20.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt20.Location = New System.Drawing.Point(118, 114)
        Me.Txt20.MaxLength = 3000
        Me.Txt20.Name = "Txt20"
        Me.Txt20.ReadOnly = True
        Me.Txt20.Size = New System.Drawing.Size(541, 21)
        Me.Txt20.TabIndex = 198
        '
        'UltraLabel9
        '
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Appearance20.TextHAlignAsString = "Right"
        Appearance20.TextVAlignAsString = "Middle"
        Me.UltraLabel9.Appearance = Appearance20
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel9.Location = New System.Drawing.Point(6, 111)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(106, 25)
        Me.UltraLabel9.TabIndex = 197
        Me.UltraLabel9.Text = "* Encargado del Área :"
        '
        'Txt8
        '
        Me.Txt8.FormatString = "n4"
        Me.Txt8.Location = New System.Drawing.Point(353, 279)
        Me.Txt8.Name = "Txt8"
        Me.Txt8.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.Txt8.ReadOnly = True
        Me.Txt8.Size = New System.Drawing.Size(100, 21)
        Me.Txt8.TabIndex = 170
        '
        'Txt7
        '
        Me.Txt7.FormatString = "n4"
        Me.Txt7.Location = New System.Drawing.Point(118, 279)
        Me.Txt7.Name = "Txt7"
        Me.Txt7.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.Txt7.ReadOnly = True
        Me.Txt7.Size = New System.Drawing.Size(100, 21)
        Me.Txt7.TabIndex = 169
        '
        'Chk1
        '
        Appearance32.TextHAlignAsString = "Right"
        Me.Chk1.Appearance = Appearance32
        Me.Chk1.BackColor = System.Drawing.Color.White
        Me.Chk1.BackColorInternal = System.Drawing.Color.White
        Me.Chk1.Location = New System.Drawing.Point(40, 142)
        Me.Chk1.Name = "Chk1"
        Me.Chk1.Size = New System.Drawing.Size(72, 20)
        Me.Chk1.TabIndex = 167
        Me.Chk1.Text = "* Cliente :"
        '
        'Cbo1
        '
        Me.Cbo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cbo1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.Cbo1.DisplayLayout.Override.FilterEvaluationTrigger = Infragistics.Win.UltraWinGrid.FilterEvaluationTrigger.OnLeaveRow
        Me.Cbo1.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.AppearancesOnly
        Me.Cbo1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cbo1.Location = New System.Drawing.Point(118, 58)
        Me.Cbo1.Name = "Cbo1"
        Me.Cbo1.ReadOnly = True
        Me.Cbo1.Size = New System.Drawing.Size(335, 22)
        Me.Cbo1.TabIndex = 166
        '
        'Cbo3
        '
        Me.Cbo3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cbo3.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cbo3.Enabled = False
        Me.Cbo3.Location = New System.Drawing.Point(459, 226)
        Me.Cbo3.Name = "Cbo3"
        Me.Cbo3.Size = New System.Drawing.Size(102, 22)
        Me.Cbo3.TabIndex = 165
        '
        'Txt3
        '
        Appearance33.Image = "Consultar.png"
        Appearance33.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt3.Appearance = Appearance33
        Me.Txt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt3.Location = New System.Drawing.Point(118, 168)
        Me.Txt3.MaxLength = 10
        Me.Txt3.Name = "Txt3"
        Me.Txt3.ReadOnly = True
        Me.Txt3.Size = New System.Drawing.Size(335, 21)
        Me.Txt3.TabIndex = 74
        '
        'Dtp3
        '
        Me.Dtp3.BackColor = System.Drawing.SystemColors.Window
        Me.Dtp3.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Dtp3.BorderStyleMonthHeader = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.Dtp3.DateButtons.Add(DateButton1)
        Me.Dtp3.DayOfWeekCaptionStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekCaptionStyle.ShortDescription
        Me.Dtp3.DayOfWeekDisplayStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekDisplayStyle.FirstRow
        Me.Dtp3.Location = New System.Drawing.Point(353, 307)
        Me.Dtp3.Name = "Dtp3"
        Me.Dtp3.NonAutoSizeHeight = 21
        Me.Dtp3.Size = New System.Drawing.Size(100, 21)
        Me.Dtp3.TabIndex = 73
        Me.Dtp3.TrailingDaysVisible = False
        Me.Dtp3.Value = New Date(2011, 6, 7, 0, 0, 0, 0)
        '
        'Label12
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Appearance23.TextHAlignAsString = "Right"
        Appearance23.TextVAlignAsString = "Middle"
        Me.Label12.Appearance = Appearance23
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label12.Location = New System.Drawing.Point(245, 306)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 22)
        Me.Label12.TabIndex = 72
        Me.Label12.Text = "* Fecha Termino:"
        '
        'Dtp2
        '
        Me.Dtp2.BackColor = System.Drawing.SystemColors.Window
        Me.Dtp2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Dtp2.BorderStyleMonthHeader = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.Dtp2.DateButtons.Add(DateButton2)
        Me.Dtp2.DayOfWeekCaptionStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekCaptionStyle.ShortDescription
        Me.Dtp2.DayOfWeekDisplayStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekDisplayStyle.FirstRow
        Me.Dtp2.Location = New System.Drawing.Point(118, 310)
        Me.Dtp2.Name = "Dtp2"
        Me.Dtp2.NonAutoSizeHeight = 21
        Me.Dtp2.Size = New System.Drawing.Size(100, 21)
        Me.Dtp2.TabIndex = 71
        Me.Dtp2.TrailingDaysVisible = False
        Me.Dtp2.Value = New Date(2011, 6, 7, 0, 0, 0, 0)
        '
        'Label11
        '
        Appearance37.BackColor = System.Drawing.Color.Transparent
        Appearance37.TextHAlignAsString = "Right"
        Appearance37.TextVAlignAsString = "Middle"
        Me.Label11.Appearance = Appearance37
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label11.Location = New System.Drawing.Point(26, 307)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 22)
        Me.Label11.TabIndex = 70
        Me.Label11.Text = "* Fecha Inicio:"
        '
        'Label9
        '
        Appearance127.BackColor = System.Drawing.Color.Transparent
        Appearance127.TextHAlignAsString = "Right"
        Appearance127.TextVAlignAsString = "Middle"
        Me.Label9.Appearance = Appearance127
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(26, 278)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 22)
        Me.Label9.TabIndex = 68
        Me.Label9.Text = "* Tipo Cambio :"
        '
        'Label8
        '
        Appearance22.BackColor = System.Drawing.Color.Transparent
        Appearance22.TextHAlignAsString = "Right"
        Appearance22.TextVAlignAsString = "Middle"
        Me.Label8.Appearance = Appearance22
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label8.Location = New System.Drawing.Point(261, 254)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 22)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "* Moneda :"
        '
        'Cbo5
        '
        Me.Cbo5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cbo5.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem3.DataValue = "S/."
        ValueListItem3.DisplayText = "S/."
        ValueListItem4.DataValue = "US$"
        ValueListItem4.DisplayText = "US$"
        Me.Cbo5.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4})
        Me.Cbo5.Location = New System.Drawing.Point(353, 254)
        Me.Cbo5.Name = "Cbo5"
        Me.Cbo5.ReadOnly = True
        Me.Cbo5.Size = New System.Drawing.Size(100, 21)
        Me.Cbo5.TabIndex = 66
        '
        'Label7
        '
        Appearance35.BackColor = System.Drawing.Color.Transparent
        Appearance35.TextHAlignAsString = "Right"
        Appearance35.TextVAlignAsString = "Middle"
        Me.Label7.Appearance = Appearance35
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(26, 252)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 22)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "* Prioridad :"
        '
        'Cbo4
        '
        Me.Cbo4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cbo4.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem5.DataValue = "1"
        ValueListItem5.DisplayText = "NORMAL"
        ValueListItem6.DataValue = "2"
        ValueListItem6.DisplayText = "URGENTE"
        Me.Cbo4.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem5, ValueListItem6})
        Me.Cbo4.Location = New System.Drawing.Point(118, 252)
        Me.Cbo4.Name = "Cbo4"
        Me.Cbo4.ReadOnly = True
        Me.Cbo4.Size = New System.Drawing.Size(100, 21)
        Me.Cbo4.TabIndex = 64
        '
        'Grb2
        '
        Me.Grb2.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.Grb2.Controls.Add(Me.Rbn6)
        Me.Grb2.Controls.Add(Me.Rbn3)
        Me.Grb2.Controls.Add(Me.Rbn5)
        Me.Grb2.Controls.Add(Me.Rbn2)
        Me.Grb2.Controls.Add(Me.Rbn4)
        Me.Grb2.Controls.Add(Me.Rbn1)
        Me.Grb2.Location = New System.Drawing.Point(118, 337)
        Me.Grb2.Name = "Grb2"
        Me.Grb2.Size = New System.Drawing.Size(571, 62)
        Me.Grb2.TabIndex = 63
        Me.Grb2.Text = "Estado"
        Me.Grb2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003
        '
        'Rbn6
        '
        Me.Rbn6.AutoSize = True
        Me.Rbn6.BackColor = System.Drawing.Color.White
        Me.Rbn6.Location = New System.Drawing.Point(110, 30)
        Me.Rbn6.Name = "Rbn6"
        Me.Rbn6.Size = New System.Drawing.Size(81, 17)
        Me.Rbn6.TabIndex = 5
        Me.Rbn6.TabStop = True
        Me.Rbn6.Text = "Por Aprobar"
        Me.Rbn6.UseVisualStyleBackColor = False
        '
        'Rbn3
        '
        Me.Rbn3.AutoSize = True
        Me.Rbn3.BackColor = System.Drawing.Color.White
        Me.Rbn3.Location = New System.Drawing.Point(305, 30)
        Me.Rbn3.Name = "Rbn3"
        Me.Rbn3.Size = New System.Drawing.Size(80, 17)
        Me.Rbn3.TabIndex = 4
        Me.Rbn3.TabStop = True
        Me.Rbn3.Text = "En Proceso"
        Me.Rbn3.UseVisualStyleBackColor = False
        '
        'Rbn5
        '
        Me.Rbn5.AutoSize = True
        Me.Rbn5.BackColor = System.Drawing.Color.White
        Me.Rbn5.Location = New System.Drawing.Point(502, 30)
        Me.Rbn5.Name = "Rbn5"
        Me.Rbn5.Size = New System.Drawing.Size(64, 17)
        Me.Rbn5.TabIndex = 3
        Me.Rbn5.TabStop = True
        Me.Rbn5.Text = "Anulado"
        Me.Rbn5.UseVisualStyleBackColor = False
        '
        'Rbn2
        '
        Me.Rbn2.AutoSize = True
        Me.Rbn2.BackColor = System.Drawing.Color.White
        Me.Rbn2.Location = New System.Drawing.Point(217, 30)
        Me.Rbn2.Name = "Rbn2"
        Me.Rbn2.Size = New System.Drawing.Size(71, 17)
        Me.Rbn2.TabIndex = 2
        Me.Rbn2.TabStop = True
        Me.Rbn2.Text = "Aprobado"
        Me.Rbn2.UseVisualStyleBackColor = False
        '
        'Rbn4
        '
        Me.Rbn4.AutoSize = True
        Me.Rbn4.BackColor = System.Drawing.Color.White
        Me.Rbn4.Location = New System.Drawing.Point(412, 30)
        Me.Rbn4.Name = "Rbn4"
        Me.Rbn4.Size = New System.Drawing.Size(72, 17)
        Me.Rbn4.TabIndex = 1
        Me.Rbn4.TabStop = True
        Me.Rbn4.Text = "Concluido"
        Me.Rbn4.UseVisualStyleBackColor = False
        '
        'Rbn1
        '
        Me.Rbn1.AutoSize = True
        Me.Rbn1.BackColor = System.Drawing.Color.White
        Me.Rbn1.Location = New System.Drawing.Point(5, 30)
        Me.Rbn1.Name = "Rbn1"
        Me.Rbn1.Size = New System.Drawing.Size(88, 17)
        Me.Rbn1.TabIndex = 0
        Me.Rbn1.TabStop = True
        Me.Rbn1.Text = "En Desarrollo"
        Me.Rbn1.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Appearance39.BackColor = System.Drawing.Color.Transparent
        Appearance39.TextHAlignAsString = "Right"
        Appearance39.TextVAlignAsString = "Middle"
        Me.Label10.Appearance = Appearance39
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label10.Location = New System.Drawing.Point(261, 280)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 22)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "* Presupuesto :"
        '
        'Label6
        '
        Appearance47.BackColor = System.Drawing.Color.Transparent
        Appearance47.TextHAlignAsString = "Right"
        Appearance47.TextVAlignAsString = "Middle"
        Me.Label6.Appearance = Appearance47
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(261, 226)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 22)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "* Valor :"
        '
        'Dtp1
        '
        Me.Dtp1.BackColor = System.Drawing.SystemColors.Window
        Me.Dtp1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Dtp1.BorderStyleMonthHeader = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.Dtp1.DateButtons.Add(DateButton3)
        Me.Dtp1.DayOfWeekCaptionStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekCaptionStyle.ShortDescription
        Me.Dtp1.DayOfWeekDisplayStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekDisplayStyle.FirstRow
        Me.Dtp1.Location = New System.Drawing.Point(353, 86)
        Me.Dtp1.Name = "Dtp1"
        Me.Dtp1.NonAutoSizeHeight = 21
        Me.Dtp1.Size = New System.Drawing.Size(100, 21)
        Me.Dtp1.TabIndex = 55
        Me.Dtp1.TrailingDaysVisible = False
        Me.Dtp1.Value = New Date(2011, 6, 7, 0, 0, 0, 0)
        '
        'Btn1
        '
        Me.Btn1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance41.Image = Global.SIP_Presentacion.My.Resources.Resources.BINOCULAR
        Me.Btn1.Appearance = Appearance41
        Me.Btn1.Location = New System.Drawing.Point(665, 140)
        Me.Btn1.Name = "Btn1"
        Me.Btn1.Size = New System.Drawing.Size(24, 23)
        Me.Btn1.TabIndex = 48
        '
        'Txt4
        '
        Me.Txt4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance21.Image = "Crystal_Clear_kdm_user_male[1].png"
        Appearance21.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt4.Appearance = Appearance21
        Me.Txt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt4.Location = New System.Drawing.Point(118, 197)
        Me.Txt4.MaxLength = 3000
        Me.Txt4.Name = "Txt4"
        Me.Txt4.ReadOnly = True
        Me.Txt4.Size = New System.Drawing.Size(541, 21)
        Me.Txt4.TabIndex = 47
        '
        'Btn2
        '
        Me.Btn2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance38.Image = Global.SIP_Presentacion.My.Resources.Resources.BINOCULAR
        Me.Btn2.Appearance = Appearance38
        Me.Btn2.Location = New System.Drawing.Point(665, 196)
        Me.Btn2.Name = "Btn2"
        Me.Btn2.Size = New System.Drawing.Size(24, 23)
        Me.Btn2.TabIndex = 46
        '
        'Label5
        '
        Appearance44.BackColor = System.Drawing.Color.Transparent
        Appearance44.TextHAlignAsString = "Right"
        Appearance44.TextVAlignAsString = "Middle"
        Me.Label5.Appearance = Appearance44
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(26, 226)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 22)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "* Tipo Mantto :"
        '
        'Label4
        '
        Appearance30.BackColor = System.Drawing.Color.Transparent
        Appearance30.TextHAlignAsString = "Right"
        Appearance30.TextVAlignAsString = "Middle"
        Me.Label4.Appearance = Appearance30
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(26, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 22)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "* Equipo :"
        '
        'Cbo2
        '
        Me.Cbo2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cbo2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "1"
        ValueListItem1.DisplayText = "PREVENTIVO"
        ValueListItem2.DataValue = "2"
        ValueListItem2.DisplayText = "CORRECTIVO"
        ValueListItem7.DataValue = "3"
        ValueListItem7.DisplayText = "OPORTUNIDAD"
        ValueListItem8.DataValue = "4"
        ValueListItem8.DisplayText = "INSTALACIONES"
        Me.Cbo2.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem7, ValueListItem8})
        Me.Cbo2.Location = New System.Drawing.Point(118, 225)
        Me.Cbo2.Name = "Cbo2"
        Me.Cbo2.ReadOnly = True
        Me.Cbo2.Size = New System.Drawing.Size(137, 21)
        Me.Cbo2.TabIndex = 28
        '
        'Label1
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Appearance19.TextHAlignAsString = "Right"
        Appearance19.TextVAlignAsString = "Middle"
        Me.Label1.Appearance = Appearance19
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(26, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 22)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "* Área :"
        '
        'UltraLabel1
        '
        Appearance24.BackColor = System.Drawing.Color.Transparent
        Appearance24.TextHAlignAsString = "Right"
        Appearance24.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance24
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(26, 86)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(86, 22)
        Me.UltraLabel1.TabIndex = 24
        Me.UltraLabel1.Text = "* Código :"
        '
        'Txt2
        '
        Me.Txt2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.Image = "Crystal_Clear_kdm_user_male[1].png"
        Appearance4.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt2.Appearance = Appearance4
        Me.Txt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt2.Location = New System.Drawing.Point(118, 141)
        Me.Txt2.MaxLength = 3000
        Me.Txt2.Name = "Txt2"
        Me.Txt2.ReadOnly = True
        Me.Txt2.Size = New System.Drawing.Size(541, 21)
        Me.Txt2.TabIndex = 6
        '
        'Txt1
        '
        Appearance36.Image = "Consultar.png"
        Appearance36.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt1.Appearance = Appearance36
        Me.Txt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt1.Location = New System.Drawing.Point(118, 86)
        Me.Txt1.MaxLength = 10
        Me.Txt1.Name = "Txt1"
        Me.Txt1.ReadOnly = True
        Me.Txt1.Size = New System.Drawing.Size(100, 21)
        Me.Txt1.TabIndex = 5
        '
        'Label3
        '
        Appearance40.BackColor = System.Drawing.Color.Transparent
        Appearance40.TextHAlignAsString = "Right"
        Appearance40.TextVAlignAsString = "Middle"
        Me.Label3.Appearance = Appearance40
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(261, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 22)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "* Fecha:"
        '
        'Txt5
        '
        Appearance46.Image = "Consultar.png"
        Appearance46.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt5.Appearance = Appearance46
        Me.Txt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt5.Location = New System.Drawing.Point(353, 228)
        Me.Txt5.MaxLength = 10
        Me.Txt5.Name = "Txt5"
        Me.Txt5.ReadOnly = True
        Me.Txt5.Size = New System.Drawing.Size(100, 21)
        Me.Txt5.TabIndex = 58
        '
        'Txt6
        '
        Me.Txt6.Location = New System.Drawing.Point(353, 228)
        Me.Txt6.Name = "Txt6"
        Me.Txt6.Size = New System.Drawing.Size(100, 20)
        Me.Txt6.TabIndex = 168
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Grid2)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(755, 441)
        '
        'Grid2
        '
        Me.Grid2.ContextMenuStrip = Me.cmnut1
        Appearance51.BackColor = System.Drawing.SystemColors.Window
        Appearance51.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid2.DisplayLayout.Appearance = Appearance51
        Me.Grid2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn35.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance52.Image = CType(resources.GetObject("Appearance52.Image"), Object)
        Appearance52.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance52.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn35.Header.Appearance = Appearance52
        UltraGridColumn35.Header.Caption = ""
        UltraGridColumn35.Header.VisiblePosition = 0
        UltraGridColumn35.Hidden = True
        UltraGridColumn35.MaxWidth = 25
        UltraGridColumn35.MinWidth = 20
        UltraGridColumn35.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn35.Width = 20
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn36.Header.VisiblePosition = 1
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.MaxWidth = 80
        UltraGridColumn36.MinWidth = 80
        UltraGridColumn36.Width = 80
        UltraGridColumn37.Header.Caption = "Partida"
        UltraGridColumn37.Header.VisiblePosition = 2
        UltraGridColumn37.MinWidth = 200
        UltraGridColumn37.Width = 228
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance31.TextHAlignAsString = "Center"
        UltraGridColumn38.CellAppearance = Appearance31
        UltraGridColumn38.Header.Caption = "Und"
        UltraGridColumn38.Header.VisiblePosition = 3
        UltraGridColumn38.MaxWidth = 50
        UltraGridColumn38.MinWidth = 50
        UltraGridColumn38.Width = 50
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn39.CellAppearance = Appearance6
        UltraGridColumn39.DataType = GetType(Double)
        UltraGridColumn39.Format = "n4"
        UltraGridColumn39.Header.VisiblePosition = 4
        UltraGridColumn39.MinWidth = 60
        UltraGridColumn39.Width = 86
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn40.CellAppearance = Appearance7
        UltraGridColumn40.DataType = GetType(Double)
        UltraGridColumn40.Format = "n4"
        UltraGridColumn40.Header.VisiblePosition = 5
        UltraGridColumn40.MinWidth = 60
        UltraGridColumn40.Width = 88
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance42.TextHAlignAsString = "Right"
        UltraGridColumn41.CellAppearance = Appearance42
        UltraGridColumn41.DataType = GetType(Double)
        UltraGridColumn41.Format = "n4"
        UltraGridColumn41.Header.VisiblePosition = 6
        UltraGridColumn41.MinWidth = 80
        UltraGridColumn41.Width = 96
        Appearance45.TextVAlignAsString = "Middle"
        UltraGridColumn42.CellButtonAppearance = Appearance45
        UltraGridColumn42.DataType = GetType(Date)
        UltraGridColumn42.Header.Caption = "Fec. Inicio"
        UltraGridColumn42.Header.VisiblePosition = 7
        UltraGridColumn42.MaxWidth = 75
        UltraGridColumn42.MinWidth = 75
        UltraGridColumn42.Width = 75
        Appearance34.TextVAlignAsString = "Middle"
        UltraGridColumn43.CellButtonAppearance = Appearance34
        UltraGridColumn43.DataType = GetType(Date)
        UltraGridColumn43.Header.Caption = "Fec. Termino"
        UltraGridColumn43.Header.VisiblePosition = 8
        UltraGridColumn43.MaxWidth = 75
        UltraGridColumn43.MinWidth = 75
        UltraGridColumn43.Width = 75
        UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn44.Header.VisiblePosition = 9
        UltraGridColumn44.Hidden = True
        UltraGridColumn44.Width = 85
        UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn45.DataType = GetType(Double)
        UltraGridColumn45.Header.VisiblePosition = 10
        UltraGridColumn45.Hidden = True
        UltraGridColumn45.Width = 87
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn46.DataType = GetType(Double)
        UltraGridColumn46.Header.VisiblePosition = 11
        UltraGridColumn46.Hidden = True
        UltraGridColumn46.Width = 87
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn47.Header.VisiblePosition = 12
        UltraGridColumn47.Hidden = True
        UltraGridColumn47.Width = 87
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn48.Header.VisiblePosition = 13
        UltraGridColumn48.Hidden = True
        UltraGridColumn48.Width = 8
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn49.DataType = GetType(Integer)
        UltraGridColumn49.Header.VisiblePosition = 14
        UltraGridColumn49.Hidden = True
        UltraGridColumn49.Width = 8
        UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn50.DataType = GetType(Integer)
        UltraGridColumn50.Header.VisiblePosition = 15
        UltraGridColumn50.Hidden = True
        UltraGridColumn50.Width = 9
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn51.DataType = GetType(Integer)
        UltraGridColumn51.Header.VisiblePosition = 16
        UltraGridColumn51.Hidden = True
        UltraGridColumn51.Width = 10
        UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn52.DataType = GetType(Integer)
        UltraGridColumn52.Header.VisiblePosition = 17
        UltraGridColumn52.Hidden = True
        UltraGridColumn52.Width = 90
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52})
        Me.Grid2.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.Grid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance61.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance61.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance61.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.GroupByBox.Appearance = Appearance61
        Appearance62.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance62
        Me.Grid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid2.DisplayLayout.GroupByBox.Hidden = True
        Appearance63.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance63.BackColor2 = System.Drawing.SystemColors.Control
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance63.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.PromptAppearance = Appearance63
        Me.Grid2.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid2.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance64.BackColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.CardAreaAppearance = Appearance64
        Appearance65.BorderColor = System.Drawing.Color.Silver
        Appearance65.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid2.DisplayLayout.Override.CellAppearance = Appearance65
        Me.Grid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid2.DisplayLayout.Override.CellPadding = 0
        Appearance66.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance66.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Grid2.DisplayLayout.Override.FilterRowAppearance = Appearance66
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance83.BackColor = System.Drawing.SystemColors.Control
        Appearance83.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance83.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance83.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance83.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.GroupByRowAppearance = Appearance83
        Appearance84.FontData.Name = "Arial Narrow"
        Appearance84.FontData.SizeInPoints = 10.0!
        Appearance84.TextHAlignAsString = "Left"
        Me.Grid2.DisplayLayout.Override.HeaderAppearance = Appearance84
        Me.Grid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid2.DisplayLayout.Override.MinRowHeight = 24
        Appearance85.BackColor = System.Drawing.SystemColors.Window
        Appearance85.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance85.TextVAlignAsString = "Middle"
        Me.Grid2.DisplayLayout.Override.RowAppearance = Appearance85
        Me.Grid2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid2.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid2.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance86.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid2.DisplayLayout.Override.TemplateAddRowAppearance = Appearance86
        Me.Grid2.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.Grid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid2.Location = New System.Drawing.Point(0, 0)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Size = New System.Drawing.Size(755, 441)
        Me.Grid2.TabIndex = 150
        Me.Grid2.Text = "UltraGrid3"
        '
        'cmnut1
        '
        Me.cmnut1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnu1, Me.cmnu2, Me.cmnu3, Me.cmnu4, Me.cmnu5, Me.cmnu6})
        Me.cmnut1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.cmnut1.Name = "cmnut1"
        Me.cmnut1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.cmnut1.Size = New System.Drawing.Size(174, 120)
        '
        'cmnu1
        '
        Me.cmnu1.Name = "cmnu1"
        Me.cmnu1.Size = New System.Drawing.Size(173, 22)
        Me.cmnu1.Text = "Add Partida"
        '
        'cmnu2
        '
        Me.cmnu2.Name = "cmnu2"
        Me.cmnu2.Size = New System.Drawing.Size(173, 22)
        Me.cmnu2.Text = "Edit Partida"
        '
        'cmnu3
        '
        Me.cmnu3.Name = "cmnu3"
        Me.cmnu3.Size = New System.Drawing.Size(173, 22)
        Me.cmnu3.Text = "Delete Partida"
        '
        'cmnu4
        '
        Me.cmnu4.Name = "cmnu4"
        Me.cmnu4.Size = New System.Drawing.Size(170, 6)
        '
        'cmnu5
        '
        Me.cmnu5.Name = "cmnu5"
        Me.cmnu5.Size = New System.Drawing.Size(173, 22)
        Me.cmnu5.Text = "Planificar Periodo"
        '
        'cmnu6
        '
        Me.cmnu6.Name = "cmnu6"
        Me.cmnu6.Size = New System.Drawing.Size(173, 22)
        Me.cmnu6.Text = "Planificar Recursos"
        '
        'Tab1
        '
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.Name = "Arial Narrow"
        Appearance1.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance1
        Appearance2.FontData.Name = "Arial Narrow"
        Appearance2.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance2
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl2)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl3)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(759, 479)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance26.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance26
        Me.Tab1.TabIndex = 7
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance27.Cursor = System.Windows.Forms.Cursors.Default
        Appearance27.FontData.BoldAsString = "True"
        Appearance27.FontData.Name = "Arial Narrow"
        Appearance27.FontData.SizeInPoints = 16.0!
        UltraTab2.ActiveAppearance = Appearance27
        Appearance28.FontData.Name = "Arial Narrow"
        Appearance28.FontData.SizeInPoints = 10.0!
        UltraTab2.Appearance = Appearance28
        UltraTab2.Key = "T01"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "PRESUPUESTO"
        Appearance29.Cursor = System.Windows.Forms.Cursors.Default
        Appearance29.FontData.BoldAsString = "True"
        Appearance29.FontData.Name = "Arial Narrow"
        Appearance29.FontData.SizeInPoints = 16.0!
        UltraTab5.ActiveAppearance = Appearance29
        UltraTab5.Key = "T02"
        UltraTab5.TabPage = Me.UltraTabPageControl3
        UltraTab5.Text = "GENERALIDADES"
        UltraTab1.Key = "T03"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "DETALLE"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2, UltraTab5, UltraTab1})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(755, 441)
        '
        'frmPPresupuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 479)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "frmPPresupuesto"
        Me.Tag = "P04"
        Me.Text = "Presupuesto"
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraStatusBar1.ResumeLayout(False)
        Me.UltraStatusBar1.PerformLayout()
        Me.UltraTabPageControl3.ResumeLayout(False)
        CType(Me.Grb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grb1.ResumeLayout(False)
        Me.Grb1.PerformLayout()
        CType(Me.Txt20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtp2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grb2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grb2.ResumeLayout(False)
        Me.Grb2.PerformLayout()
        CType(Me.Dtp1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmnut1.ResumeLayout(False)
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Grid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Grb1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Btn1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Txt4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Btn2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Label4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Cbo2 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Grid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Dtp1 As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents Txt5 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Label10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Grb2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Rbn2 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbn4 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbn1 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbn5 As System.Windows.Forms.RadioButton
    Friend WithEvents cmnut1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnu1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnu2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnu3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnu4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnu5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnu6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Cbo5 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Cbo4 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Rbn3 As System.Windows.Forms.RadioButton
    Friend WithEvents Dtp3 As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents Label12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Dtp2 As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents Label11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Label9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Cbo3 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Cbo1 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Chk1 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents Txt6 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents Txt7 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Txt8 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Txt20 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Rbn6 As System.Windows.Forms.RadioButton
End Class
