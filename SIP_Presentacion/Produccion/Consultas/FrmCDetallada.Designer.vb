<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCDetallada
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
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCDetallada))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumPedido", 0)
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision", 1)
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaRequerida", 2)
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodCliente", 3)
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesCliente", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DocExt", 5)
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 6)
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, "Pais", -2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Cantidad", 6, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Cantidad", 6, False)
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(728)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(643)
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance112 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance113 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumPedido", 0)
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesCliente", 1)
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision", 2)
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaRequerida", 3)
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cotizado", 4)
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Despachado1", 5)
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pendiente1", 6)
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Despachado2", 7)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pendiente2", 8)
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings3 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Pendiente1", 6, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Pendiente1", 6, False)
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings4 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Pendiente2", 8, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Pendiente2", 8, False)
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim DateButton3 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.Clb1 = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.Info1 = New Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(Me.components)
        Me.Look1 = New Infragistics.Win.UltraWinSchedule.UltraCalendarLook(Me.components)
        Me.Txt1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Grid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraPictureBox4 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.UltraPictureBox5 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.UltraPictureBox3 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.UltraPictureBox2 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.Grid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.Clb2 = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt5 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraCalendarCombo2 = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.UltraTextEditor2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTextEditor3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraTextEditor4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.Clb1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.Clb2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.UltraCalendarCombo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(759, 481)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance74.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance74
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.Clb1)
        Me.UltraGroupBox1.Controls.Add(Me.Txt1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox1.Controls.Add(Me.Txt3)
        Me.UltraGroupBox1.Controls.Add(Me.Txt2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Appearance78.FontData.BoldAsString = "True"
        Appearance78.FontData.Name = "Arial Narrow"
        Appearance78.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox1.HeaderAppearance = Appearance78
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox1.Location = New System.Drawing.Point(11, 17)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(736, 148)
        Me.UltraGroupBox1.TabIndex = 131
        Me.UltraGroupBox1.Text = "DETALLADO POR PRODUCTOS"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'UltraLabel3
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance5
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(69, 33)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel3.TabIndex = 23
        Me.UltraLabel3.Text = "Mes / Año :"
        '
        'Clb1
        '
        Me.Clb1.BackColor = System.Drawing.SystemColors.Window
        Me.Clb1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Clb1.BorderStyleMonthHeader = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.Clb1.CalendarInfo = Me.Info1
        Me.Clb1.CalendarLook = Me.Look1
        Me.Clb1.DateButtons.Add(DateButton1)
        Me.Clb1.DayOfWeekCaptionStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekCaptionStyle.ShortDescription
        Me.Clb1.DayOfWeekDisplayStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekDisplayStyle.FirstRow
        Me.Clb1.Format = "y"
        Me.Clb1.Location = New System.Drawing.Point(150, 32)
        Me.Clb1.Name = "Clb1"
        Me.Clb1.NonAutoSizeHeight = 21
        Me.Clb1.ReadOnly = True
        Me.Clb1.Size = New System.Drawing.Size(125, 21)
        Me.Clb1.TabIndex = 22
        Me.Clb1.TrailingDaysVisible = False
        Me.Clb1.Value = New Date(2011, 1, 23, 0, 0, 0, 0)
        Me.Clb1.WeekNumbersVisible = True
        '
        'Info1
        '
        Me.Info1.MaxAlternateSelectedDays = 1
        Me.Info1.MaxDate = New Date(2020, 12, 31, 0, 0, 0, 0)
        Me.Info1.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.Info1.WeekRule = System.Globalization.CalendarWeekRule.FirstFullWeek
        '
        'Look1
        '
        Appearance14.BackHatchStyle = Infragistics.Win.BackHatchStyle.None
        Me.Look1.ActiveDayAppearance = Appearance14
        Me.Look1.ViewStyle = Infragistics.Win.UltraWinSchedule.ViewStyle.Office2007
        '
        'Txt1
        '
        Me.Txt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt1.Location = New System.Drawing.Point(150, 59)
        Me.Txt1.MaxLength = 10
        Me.Txt1.Name = "Txt1"
        Me.Txt1.ReadOnly = True
        Me.Txt1.Size = New System.Drawing.Size(95, 21)
        Me.Txt1.TabIndex = 14
        '
        'UltraLabel1
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance6
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(69, 62)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel1.TabIndex = 13
        Me.UltraLabel1.Text = "Nro Semana :"
        '
        'UltraLabel5
        '
        Appearance76.BackColor = System.Drawing.Color.Transparent
        Appearance76.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance76
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel5.Location = New System.Drawing.Point(69, 115)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel5.TabIndex = 12
        Me.UltraLabel5.Text = "Descripción :"
        '
        'Txt3
        '
        Me.Txt3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt3.Location = New System.Drawing.Point(150, 113)
        Me.Txt3.MaxLength = 3000
        Me.Txt3.Name = "Txt3"
        Me.Txt3.ReadOnly = True
        Me.Txt3.Size = New System.Drawing.Size(484, 21)
        Me.Txt3.TabIndex = 11
        '
        'Txt2
        '
        Me.Txt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt2.Location = New System.Drawing.Point(150, 86)
        Me.Txt2.MaxLength = 10
        Me.Txt2.Name = "Txt2"
        Me.Txt2.ReadOnly = True
        Me.Txt2.Size = New System.Drawing.Size(95, 21)
        Me.Txt2.TabIndex = 10
        '
        'UltraLabel2
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance3
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(69, 89)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel2.TabIndex = 9
        Me.UltraLabel2.Text = "Código :"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance79.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox2.ContentAreaAppearance = Appearance79
        Me.UltraGroupBox2.Controls.Add(Me.Grid1)
        Appearance111.FontData.BoldAsString = "True"
        Appearance111.FontData.Name = "Arial Narrow"
        Appearance111.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox2.HeaderAppearance = Appearance111
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox2.Location = New System.Drawing.Point(11, 171)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(736, 301)
        Me.UltraGroupBox2.TabIndex = 132
        Me.UltraGroupBox2.Text = "LISTADO DE PROFORMAS"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Grid1
        '
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Appearance33.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid1.DisplayLayout.Appearance = Appearance33
        Me.Grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance34.Image = CType(resources.GetObject("Appearance34.Image"), Object)
        Appearance34.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance34.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance34
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance37.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance37
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance40.TextHAlignAsString = "Center"
        UltraGridColumn2.Header.Appearance = Appearance40
        UltraGridColumn2.Header.Caption = "Nro Proforma"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.MaxWidth = 125
        UltraGridColumn2.MinWidth = 125
        UltraGridColumn2.Width = 125
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance41.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance41
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn3.DataType = GetType(Date)
        Appearance42.TextHAlignAsString = "Center"
        UltraGridColumn3.Header.Appearance = Appearance42
        UltraGridColumn3.Header.VisiblePosition = 4
        UltraGridColumn3.MaxWidth = 80
        UltraGridColumn3.MinWidth = 80
        UltraGridColumn3.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        UltraGridColumn3.Width = 80
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance43.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance43
        UltraGridColumn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn4.DataType = GetType(Date)
        Appearance44.TextHAlignAsString = "Center"
        UltraGridColumn4.Header.Appearance = Appearance44
        UltraGridColumn4.Header.Caption = "Fec Req."
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.MaxWidth = 80
        UltraGridColumn4.MinWidth = 80
        UltraGridColumn4.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        UltraGridColumn4.Width = 80
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance45.TextHAlignAsString = "Center"
        UltraGridColumn5.CellAppearance = Appearance45
        UltraGridColumn5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance46.TextHAlignAsString = "Center"
        UltraGridColumn5.Header.Appearance = Appearance46
        UltraGridColumn5.Header.Caption = "Codigo"
        UltraGridColumn5.Header.VisiblePosition = 2
        UltraGridColumn5.MaxWidth = 90
        UltraGridColumn5.MinWidth = 90
        UltraGridColumn5.Width = 90
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn6.Header.Caption = "Descripción"
        UltraGridColumn6.Header.VisiblePosition = 3
        UltraGridColumn6.MinWidth = 200
        UltraGridColumn6.Width = 200
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance47.TextHAlignAsString = "Center"
        UltraGridColumn7.CellAppearance = Appearance47
        UltraGridColumn7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance49.TextHAlignAsString = "Center"
        UltraGridColumn7.Header.Appearance = Appearance49
        UltraGridColumn7.Header.Caption = "Doc Ext"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.MaxWidth = 90
        UltraGridColumn7.MinWidth = 90
        UltraGridColumn7.Width = 90
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance50.TextHAlignAsString = "Center"
        UltraGridColumn8.CellAppearance = Appearance50
        UltraGridColumn8.DataType = GetType(Decimal)
        UltraGridColumn8.Format = "###,##0.00 ""Ton"""
        Appearance51.TextHAlignAsString = "Center"
        UltraGridColumn8.Header.Appearance = Appearance51
        UltraGridColumn8.Header.Caption = "Toneladas"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.MaxWidth = 90
        UltraGridColumn8.MinWidth = 90
        UltraGridColumn8.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        UltraGridColumn8.Width = 90
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8})
        Appearance52.BackColor = System.Drawing.Color.White
        Appearance52.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance52
        SummarySettings1.DisplayFormat = "TOTAL :"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance53
        Appearance54.BackColor = System.Drawing.Color.White
        Appearance54.TextHAlignAsString = "Center"
        SummarySettings2.Appearance = Appearance54
        SummarySettings2.DisplayFormat = "{0} Ton"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance55
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
        UltraGridBand1.SummaryFooterCaption = ""
        Me.Grid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.Grid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.Grid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance56.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance56.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance56.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.GroupByBox.Appearance = Appearance56
        Appearance58.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance58
        Me.Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance59.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance59.BackColor2 = System.Drawing.SystemColors.Control
        Appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance59.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance59
        Me.Grid1.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid1.DisplayLayout.MaxRowScrollRegions = 1
        Appearance60.BackColor = System.Drawing.SystemColors.Window
        Appearance60.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid1.DisplayLayout.Override.ActiveCellAppearance = Appearance60
        Me.Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance61.BackColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.CardAreaAppearance = Appearance61
        Appearance62.BorderColor = System.Drawing.Color.Silver
        Appearance62.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid1.DisplayLayout.Override.CellAppearance = Appearance62
        Me.Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid1.DisplayLayout.Override.CellPadding = 0
        Me.Grid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance73.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance73.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Grid1.DisplayLayout.Override.FilterRowAppearance = Appearance73
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance106.BackColor = System.Drawing.SystemColors.Control
        Appearance106.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance106.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance106.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance106.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.GroupByRowAppearance = Appearance106
        Appearance107.FontData.Name = "Arial Narrow"
        Appearance107.FontData.SizeInPoints = 10.0!
        Appearance107.TextHAlignAsString = "Left"
        Me.Grid1.DisplayLayout.Override.HeaderAppearance = Appearance107
        Me.Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid1.DisplayLayout.Override.MinRowHeight = 24
        Appearance112.BackColor = System.Drawing.SystemColors.Window
        Appearance112.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance112.TextVAlignAsString = "Middle"
        Me.Grid1.DisplayLayout.Override.RowAppearance = Appearance112
        Me.Grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance113.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance113
        Me.Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.Location = New System.Drawing.Point(3, 23)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(730, 275)
        Me.Grid1.TabIndex = 130
        Me.Grid1.Text = " "
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox4)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox3)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(759, 481)
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance20.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance20
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox4)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox5)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox3)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox2)
        Me.UltraGroupBox4.Controls.Add(Me.UltraPictureBox1)
        Me.UltraGroupBox4.Controls.Add(Me.Grid2)
        Appearance119.FontData.BoldAsString = "True"
        Appearance119.FontData.Name = "Arial Narrow"
        Appearance119.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox4.HeaderAppearance = Appearance119
        Me.UltraGroupBox4.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox4.Location = New System.Drawing.Point(11, 143)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(736, 329)
        Me.UltraGroupBox4.TabIndex = 133
        Me.UltraGroupBox4.Text = "LISTADO DE PROFORMAS"
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'UltraPictureBox4
        '
        Me.UltraPictureBox4.BackColor = System.Drawing.Color.Beige
        Me.UltraPictureBox4.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox4.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraPictureBox4.Location = New System.Drawing.Point(13, 75)
        Me.UltraPictureBox4.Name = "UltraPictureBox4"
        Me.UltraPictureBox4.Size = New System.Drawing.Size(24, 14)
        Me.UltraPictureBox4.TabIndex = 138
        '
        'UltraPictureBox5
        '
        Me.UltraPictureBox5.BackColor = System.Drawing.Color.OldLace
        Me.UltraPictureBox5.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox5.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraPictureBox5.Location = New System.Drawing.Point(13, 90)
        Me.UltraPictureBox5.Name = "UltraPictureBox5"
        Me.UltraPictureBox5.Size = New System.Drawing.Size(24, 14)
        Me.UltraPictureBox5.TabIndex = 137
        '
        'UltraPictureBox3
        '
        Me.UltraPictureBox3.BackColor = System.Drawing.Color.AliceBlue
        Me.UltraPictureBox3.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox3.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraPictureBox3.Location = New System.Drawing.Point(13, 45)
        Me.UltraPictureBox3.Name = "UltraPictureBox3"
        Me.UltraPictureBox3.Size = New System.Drawing.Size(24, 14)
        Me.UltraPictureBox3.TabIndex = 136
        '
        'UltraPictureBox2
        '
        Me.UltraPictureBox2.BackColor = System.Drawing.Color.MistyRose
        Me.UltraPictureBox2.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraPictureBox2.Location = New System.Drawing.Point(13, 60)
        Me.UltraPictureBox2.Name = "UltraPictureBox2"
        Me.UltraPictureBox2.Size = New System.Drawing.Size(24, 14)
        Me.UltraPictureBox2.TabIndex = 135
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.BackColor = System.Drawing.Color.LightYellow
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraPictureBox1.Location = New System.Drawing.Point(13, 30)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(24, 14)
        Me.UltraPictureBox1.TabIndex = 134
        '
        'Grid2
        '
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid2.DisplayLayout.Appearance = Appearance21
        Me.Grid2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance22.Image = CType(resources.GetObject("Appearance22.Image"), Object)
        Appearance22.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance22.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn9.Header.Appearance = Appearance22
        UltraGridColumn9.Header.Caption = ""
        UltraGridColumn9.Header.VisiblePosition = 0
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.MaxWidth = 25
        UltraGridColumn9.MinWidth = 20
        UltraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn9.Width = 20
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance23.TextHAlignAsString = "Center"
        UltraGridColumn10.CellAppearance = Appearance23
        UltraGridColumn10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance24.TextHAlignAsString = "Center"
        UltraGridColumn10.Header.Appearance = Appearance24
        UltraGridColumn10.Header.Caption = "Nro Proforma"
        UltraGridColumn10.Header.VisiblePosition = 1
        UltraGridColumn10.MaxWidth = 100
        UltraGridColumn10.MinWidth = 100
        UltraGridColumn10.Width = 100
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn11.Header.Caption = "Cliente"
        UltraGridColumn11.Header.VisiblePosition = 2
        Appearance25.TextVAlignAsString = "Middle"
        UltraGridColumn11.MergedCellAppearance = Appearance25
        UltraGridColumn11.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
        UltraGridColumn11.MinWidth = 250
        UltraGridColumn11.Width = 250
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance26.TextHAlignAsString = "Center"
        UltraGridColumn12.CellAppearance = Appearance26
        UltraGridColumn12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn12.DataType = GetType(Date)
        Appearance27.TextHAlignAsString = "Center"
        UltraGridColumn12.Header.Appearance = Appearance27
        UltraGridColumn12.Header.Caption = "Fecha Emisión"
        UltraGridColumn12.Header.VisiblePosition = 3
        UltraGridColumn12.MaxWidth = 90
        UltraGridColumn12.MinWidth = 90
        UltraGridColumn12.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        UltraGridColumn12.Width = 90
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance28.TextHAlignAsString = "Center"
        UltraGridColumn13.CellAppearance = Appearance28
        UltraGridColumn13.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn13.DataType = GetType(Date)
        Appearance29.TextHAlignAsString = "Center"
        UltraGridColumn13.Header.Appearance = Appearance29
        UltraGridColumn13.Header.Caption = "Fec. Requerida"
        UltraGridColumn13.Header.VisiblePosition = 4
        UltraGridColumn13.MaxWidth = 90
        UltraGridColumn13.MinWidth = 90
        UltraGridColumn13.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        UltraGridColumn13.Width = 90
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance30.BackColor = System.Drawing.SystemColors.Info
        Appearance30.TextHAlignAsString = "Center"
        UltraGridColumn14.CellAppearance = Appearance30
        UltraGridColumn14.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn14.DataType = GetType(Decimal)
        Appearance31.TextHAlignAsString = "Center"
        UltraGridColumn14.Header.Appearance = Appearance31
        UltraGridColumn14.Header.VisiblePosition = 5
        UltraGridColumn14.MaxWidth = 95
        UltraGridColumn14.MinWidth = 95
        UltraGridColumn14.Width = 95
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance32.BackColor = System.Drawing.Color.AliceBlue
        Appearance32.TextHAlignAsString = "Center"
        UltraGridColumn15.CellAppearance = Appearance32
        UltraGridColumn15.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn15.DataType = GetType(Decimal)
        Appearance35.TextHAlignAsString = "Center"
        UltraGridColumn15.Header.Appearance = Appearance35
        UltraGridColumn15.Header.Caption = "Despachado ( 1 )"
        UltraGridColumn15.Header.VisiblePosition = 6
        UltraGridColumn15.MaxWidth = 95
        UltraGridColumn15.MinWidth = 95
        UltraGridColumn15.Width = 95
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance36.BackColor = System.Drawing.Color.MistyRose
        Appearance36.TextHAlignAsString = "Center"
        UltraGridColumn16.CellAppearance = Appearance36
        UltraGridColumn16.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn16.DataType = GetType(Decimal)
        Appearance48.TextHAlignAsString = "Center"
        UltraGridColumn16.Header.Appearance = Appearance48
        UltraGridColumn16.Header.Caption = "Pendiente ( 1 )"
        UltraGridColumn16.Header.VisiblePosition = 7
        UltraGridColumn16.MaxWidth = 95
        UltraGridColumn16.MinWidth = 95
        UltraGridColumn16.Width = 95
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.BackColor = System.Drawing.Color.Beige
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn17.CellAppearance = Appearance2
        UltraGridColumn17.DataType = GetType(Decimal)
        Appearance75.TextHAlignAsString = "Center"
        UltraGridColumn17.Header.Appearance = Appearance75
        UltraGridColumn17.Header.Caption = "Despachado ( 2 )"
        UltraGridColumn17.Header.VisiblePosition = 8
        UltraGridColumn17.MaxWidth = 95
        UltraGridColumn17.MinWidth = 95
        UltraGridColumn17.Width = 95
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance8.BackColor = System.Drawing.Color.OldLace
        Appearance8.TextHAlignAsString = "Center"
        UltraGridColumn18.CellAppearance = Appearance8
        UltraGridColumn18.DataType = GetType(Decimal)
        Appearance77.TextHAlignAsString = "Center"
        UltraGridColumn18.Header.Appearance = Appearance77
        UltraGridColumn18.Header.Caption = "Pendiente ( 2 )"
        UltraGridColumn18.Header.VisiblePosition = 9
        UltraGridColumn18.MaxWidth = 95
        UltraGridColumn18.MinWidth = 95
        UltraGridColumn18.Width = 95
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18})
        Appearance15.BackColor = System.Drawing.SystemColors.Info
        Appearance15.ForeColor = System.Drawing.Color.Red
        Appearance15.TextHAlignAsString = "Center"
        SummarySettings3.Appearance = Appearance15
        SummarySettings3.DisplayFormat = "{0}"
        SummarySettings3.GroupBySummaryValueAppearance = Appearance1
        Appearance17.BackColor = System.Drawing.SystemColors.Info
        Appearance17.ForeColor = System.Drawing.Color.Red
        Appearance17.TextHAlignAsString = "Center"
        SummarySettings4.Appearance = Appearance17
        SummarySettings4.DisplayFormat = "{0}"
        SummarySettings4.GroupBySummaryValueAppearance = Appearance4
        UltraGridBand2.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings3, SummarySettings4})
        UltraGridBand2.SummaryFooterCaption = ""
        Me.Grid2.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.Grid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance120.FontData.Name = "Arial Narrow"
        Appearance120.FontData.SizeInPoints = 10.0!
        Appearance120.TextHAlignAsString = "Left"
        Me.Grid2.DisplayLayout.CaptionAppearance = Appearance120
        Me.Grid2.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance57.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance57.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.GroupByBox.Appearance = Appearance57
        Appearance63.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance63
        Me.Grid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid2.DisplayLayout.GroupByBox.Hidden = True
        Appearance64.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance64.BackColor2 = System.Drawing.SystemColors.Control
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance64.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.PromptAppearance = Appearance64
        Me.Grid2.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid2.DisplayLayout.MaxRowScrollRegions = 1
        Appearance65.BackColor = System.Drawing.SystemColors.Window
        Appearance65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid2.DisplayLayout.Override.ActiveCellAppearance = Appearance65
        Me.Grid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance66.BackColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.CardAreaAppearance = Appearance66
        Appearance67.BorderColor = System.Drawing.Color.Silver
        Appearance67.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid2.DisplayLayout.Override.CellAppearance = Appearance67
        Me.Grid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid2.DisplayLayout.Override.CellPadding = 0
        Me.Grid2.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance68.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance68.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Grid2.DisplayLayout.Override.FilterRowAppearance = Appearance68
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid2.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance69.BackColor = System.Drawing.SystemColors.Control
        Appearance69.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance69.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance69.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance69.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.GroupByRowAppearance = Appearance69
        Appearance70.TextHAlignAsString = "Left"
        Me.Grid2.DisplayLayout.Override.HeaderAppearance = Appearance70
        Me.Grid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance71.BackColor = System.Drawing.SystemColors.Window
        Appearance71.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.Grid2.DisplayLayout.Override.RowAppearance = Appearance71
        Me.Grid2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid2.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid2.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance72.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid2.DisplayLayout.Override.TemplateAddRowAppearance = Appearance72
        Me.Grid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid2.Location = New System.Drawing.Point(3, 23)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Size = New System.Drawing.Size(730, 303)
        Me.Grid2.TabIndex = 133
        Me.Grid2.Text = resources.GetString("Grid2.Text")
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox3.ContentAreaAppearance = Appearance7
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBox3.Controls.Add(Me.Clb2)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox3.Controls.Add(Me.Txt5)
        Me.UltraGroupBox3.Controls.Add(Me.Txt4)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel6)
        Appearance12.FontData.BoldAsString = "True"
        Appearance12.FontData.Name = "Arial Narrow"
        Appearance12.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox3.HeaderAppearance = Appearance12
        Me.UltraGroupBox3.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox3.Location = New System.Drawing.Point(11, 12)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(736, 125)
        Me.UltraGroupBox3.TabIndex = 132
        Me.UltraGroupBox3.Text = "ACUMULADO POR PRODUCTOS"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'UltraLabel7
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Me.UltraLabel7.Appearance = Appearance9
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel7.Location = New System.Drawing.Point(76, 36)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel7.TabIndex = 26
        Me.UltraLabel7.Text = "Mes / Año :"
        '
        'Clb2
        '
        Me.Clb2.BackColor = System.Drawing.SystemColors.Window
        Me.Clb2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Clb2.BorderStyleMonthHeader = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.Clb2.CalendarInfo = Me.Info1
        Me.Clb2.CalendarLook = Me.Look1
        Me.Clb2.DateButtons.Add(DateButton2)
        Me.Clb2.DayOfWeekCaptionStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekCaptionStyle.ShortDescription
        Me.Clb2.DayOfWeekDisplayStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekDisplayStyle.FirstRow
        Me.Clb2.Format = "y"
        Me.Clb2.Location = New System.Drawing.Point(157, 35)
        Me.Clb2.Name = "Clb2"
        Me.Clb2.NonAutoSizeHeight = 21
        Me.Clb2.ReadOnly = True
        Me.Clb2.Size = New System.Drawing.Size(125, 21)
        Me.Clb2.TabIndex = 25
        Me.Clb2.TrailingDaysVisible = False
        Me.Clb2.Value = New Date(2011, 1, 23, 0, 0, 0, 0)
        Me.Clb2.WeekNumbersVisible = True
        '
        'UltraLabel4
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Right"
        Me.UltraLabel4.Appearance = Appearance10
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(76, 92)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel4.TabIndex = 12
        Me.UltraLabel4.Text = "Descripción :"
        '
        'Txt5
        '
        Me.Txt5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt5.Location = New System.Drawing.Point(157, 90)
        Me.Txt5.MaxLength = 3000
        Me.Txt5.Name = "Txt5"
        Me.Txt5.ReadOnly = True
        Me.Txt5.Size = New System.Drawing.Size(484, 21)
        Me.Txt5.TabIndex = 11
        '
        'Txt4
        '
        Me.Txt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt4.Location = New System.Drawing.Point(157, 62)
        Me.Txt4.MaxLength = 10
        Me.Txt4.Name = "Txt4"
        Me.Txt4.ReadOnly = True
        Me.Txt4.Size = New System.Drawing.Size(95, 21)
        Me.Txt4.TabIndex = 10
        '
        'UltraLabel6
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Right"
        Me.UltraLabel6.Appearance = Appearance11
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(76, 65)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel6.TabIndex = 9
        Me.UltraLabel6.Text = "Código :"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(759, 481)
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl2)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(763, 507)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Me.Tab1.TabIndex = 133
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance38.FontData.BoldAsString = "True"
        Appearance38.FontData.SizeInPoints = 12.0!
        UltraTab3.ActiveAppearance = Appearance38
        UltraTab3.Key = "T01"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "DETALLADO"
        Appearance39.FontData.BoldAsString = "True"
        Appearance39.FontData.SizeInPoints = 12.0!
        UltraTab4.ActiveAppearance = Appearance39
        UltraTab4.Key = "T02"
        UltraTab4.TabPage = Me.UltraTabPageControl2
        UltraTab4.Text = "ACUMULADO"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3, UltraTab4})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(759, 481)
        '
        'UltraLabel9
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextHAlignAsString = "Right"
        Me.UltraLabel9.Appearance = Appearance13
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel9.Location = New System.Drawing.Point(76, 62)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel9.TabIndex = 27
        Me.UltraLabel9.Text = "Nro Semana :"
        '
        'UltraLabel10
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Appearance16.TextHAlignAsString = "Right"
        Me.UltraLabel10.Appearance = Appearance16
        Me.UltraLabel10.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel10.Location = New System.Drawing.Point(76, 36)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel10.TabIndex = 26
        Me.UltraLabel10.Text = "Mes / Año :"
        '
        'UltraCalendarCombo2
        '
        Me.UltraCalendarCombo2.BackColor = System.Drawing.SystemColors.Window
        Me.UltraCalendarCombo2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraCalendarCombo2.BorderStyleMonthHeader = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.UltraCalendarCombo2.CalendarInfo = Me.Info1
        Me.UltraCalendarCombo2.CalendarLook = Me.Look1
        Me.UltraCalendarCombo2.DateButtons.Add(DateButton3)
        Me.UltraCalendarCombo2.DayOfWeekCaptionStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekCaptionStyle.ShortDescription
        Me.UltraCalendarCombo2.DayOfWeekDisplayStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekDisplayStyle.FirstRow
        Me.UltraCalendarCombo2.Format = "y"
        Me.UltraCalendarCombo2.Location = New System.Drawing.Point(157, 35)
        Me.UltraCalendarCombo2.Name = "UltraCalendarCombo2"
        Me.UltraCalendarCombo2.NonAutoSizeHeight = 21
        Me.UltraCalendarCombo2.ReadOnly = True
        Me.UltraCalendarCombo2.Size = New System.Drawing.Size(125, 21)
        Me.UltraCalendarCombo2.TabIndex = 25
        Me.UltraCalendarCombo2.TrailingDaysVisible = False
        Me.UltraCalendarCombo2.Value = New Date(2011, 1, 23, 0, 0, 0, 0)
        Me.UltraCalendarCombo2.WeekNumbersVisible = True
        '
        'UltraTextEditor2
        '
        Me.UltraTextEditor2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.UltraTextEditor2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraTextEditor2.Location = New System.Drawing.Point(157, 62)
        Me.UltraTextEditor2.MaxLength = 10
        Me.UltraTextEditor2.Name = "UltraTextEditor2"
        Me.UltraTextEditor2.ReadOnly = True
        Me.UltraTextEditor2.Size = New System.Drawing.Size(95, 21)
        Me.UltraTextEditor2.TabIndex = 24
        '
        'UltraLabel11
        '
        Appearance18.BackColor = System.Drawing.Color.Transparent
        Appearance18.TextHAlignAsString = "Right"
        Me.UltraLabel11.Appearance = Appearance18
        Me.UltraLabel11.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel11.Location = New System.Drawing.Point(76, 119)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel11.TabIndex = 12
        Me.UltraLabel11.Text = "Descripción :"
        '
        'UltraTextEditor3
        '
        Me.UltraTextEditor3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraTextEditor3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.UltraTextEditor3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraTextEditor3.Location = New System.Drawing.Point(157, 117)
        Me.UltraTextEditor3.MaxLength = 3000
        Me.UltraTextEditor3.Name = "UltraTextEditor3"
        Me.UltraTextEditor3.ReadOnly = True
        Me.UltraTextEditor3.Size = New System.Drawing.Size(484, 21)
        Me.UltraTextEditor3.TabIndex = 11
        '
        'UltraTextEditor4
        '
        Me.UltraTextEditor4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.UltraTextEditor4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraTextEditor4.Location = New System.Drawing.Point(157, 89)
        Me.UltraTextEditor4.MaxLength = 10
        Me.UltraTextEditor4.Name = "UltraTextEditor4"
        Me.UltraTextEditor4.ReadOnly = True
        Me.UltraTextEditor4.Size = New System.Drawing.Size(95, 21)
        Me.UltraTextEditor4.TabIndex = 10
        '
        'UltraLabel12
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Appearance19.TextHAlignAsString = "Right"
        Me.UltraLabel12.Appearance = Appearance19
        Me.UltraLabel12.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel12.Location = New System.Drawing.Point(76, 92)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(75, 23)
        Me.UltraLabel12.TabIndex = 9
        Me.UltraLabel12.Text = "Código :"
        '
        'FrmCDetallada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(763, 507)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmCDetallada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EXPORTACIÓN (DETALLADO)"
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.Clb1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.Clb2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.UltraCalendarCombo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Grid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Txt1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt5 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Grid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Look1 As Infragistics.Win.UltraWinSchedule.UltraCalendarLook
    Friend WithEvents Info1 As Infragistics.Win.UltraWinSchedule.UltraCalendarInfo
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Clb1 As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Clb2 As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraCalendarCombo2 As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents UltraTextEditor2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTextEditor3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraTextEditor4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraPictureBox3 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraPictureBox2 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraPictureBox4 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraPictureBox5 As Infragistics.Win.UltraWinEditors.UltraPictureBox
End Class
