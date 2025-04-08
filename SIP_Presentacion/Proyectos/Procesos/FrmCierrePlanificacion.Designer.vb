<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCierrePlanificacion
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
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCierrePlanificacion))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_PLANIFICACION", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_PROYECTO", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_TALLER", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PROYECTO", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TALLER", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_EQUIPO", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EQUIPO", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EJECUCION", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COSTO", 10)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FLGCIERRE", 11)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHACIERRE", 12)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("REAL", 13)
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1124)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1124)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(800)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(308)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion13 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion14 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.panel = New System.Windows.Forms.Panel
        Me.gridProyecto = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.rdbCore = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txtcierretaller = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcierre = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txthoraejecucion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.btncierretaller = New System.Windows.Forms.Button
        Me.txtcostotaller = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.txtnumoperario = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.dtfintaller = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.dtiniciotaller = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbTaller = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.dtFechacierre = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.btncierre = New System.Windows.Forms.Button
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcostoreal = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcostototal = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.dtFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtproyecto = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.txtidproyecto = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl1.SuspendLayout()
        Me.panel.SuspendLayout()
        CType(Me.gridProyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rdbCore.SuspendLayout()
        CType(Me.txtcierretaller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txthoraejecucion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostotaller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnumoperario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtfintaller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtiniciotaller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTaller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechacierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoreal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostototal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtproyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidproyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.panel)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1126, 430)
        '
        'panel
        '
        Me.panel.BackColor = System.Drawing.Color.Transparent
        Me.panel.Controls.Add(Me.gridProyecto)
        Me.panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel.Location = New System.Drawing.Point(0, 0)
        Me.panel.Name = "panel"
        Me.panel.Size = New System.Drawing.Size(1126, 430)
        Me.panel.TabIndex = 176
        '
        'gridProyecto
        '
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridProyecto.DisplayLayout.Appearance = Appearance28
        Me.gridProyecto.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance29.Image = CType(resources.GetObject("Appearance29.Image"), Object)
        Appearance29.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance29.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance29
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 84
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 108
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 116
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 779
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 287
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 72
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 303
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 126
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 79
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 190
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance2
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.MaskInput = "{double:9.2}"
        UltraGridColumn12.Width = 82
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 96
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.Width = 99
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance23
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.MaskInput = "{double:9.2}"
        UltraGridColumn15.Width = 99
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15})
        Me.gridProyecto.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridProyecto.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridProyecto.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridProyecto.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance30.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance30.BorderColor = System.Drawing.SystemColors.Window
        Me.gridProyecto.DisplayLayout.GroupByBox.Appearance = Appearance30
        Appearance31.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridProyecto.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance31
        Me.gridProyecto.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridProyecto.DisplayLayout.GroupByBox.Hidden = True
        Appearance32.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance32.BackColor2 = System.Drawing.SystemColors.Control
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance32.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridProyecto.DisplayLayout.GroupByBox.PromptAppearance = Appearance32
        Me.gridProyecto.DisplayLayout.MaxColScrollRegions = 1
        Me.gridProyecto.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridProyecto.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridProyecto.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridProyecto.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Me.gridProyecto.DisplayLayout.Override.CardAreaAppearance = Appearance33
        Appearance34.BorderColor = System.Drawing.Color.Silver
        Appearance34.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridProyecto.DisplayLayout.Override.CellAppearance = Appearance34
        Me.gridProyecto.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridProyecto.DisplayLayout.Override.CellPadding = 0
        Me.gridProyecto.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridProyecto.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridProyecto.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridProyecto.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance35.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance35.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridProyecto.DisplayLayout.Override.FilterRowAppearance = Appearance35
        Me.gridProyecto.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridProyecto.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridProyecto.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance36.BackColor = System.Drawing.SystemColors.Control
        Appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance36.BorderColor = System.Drawing.SystemColors.Window
        Me.gridProyecto.DisplayLayout.Override.GroupByRowAppearance = Appearance36
        Appearance37.FontData.Name = "Arial Narrow"
        Appearance37.FontData.SizeInPoints = 10.0!
        Appearance37.TextHAlignAsString = "Left"
        Me.gridProyecto.DisplayLayout.Override.HeaderAppearance = Appearance37
        Me.gridProyecto.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridProyecto.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridProyecto.DisplayLayout.Override.MinRowHeight = 24
        Appearance83.BackColor = System.Drawing.SystemColors.Window
        Appearance83.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance83.TextVAlignAsString = "Middle"
        Me.gridProyecto.DisplayLayout.Override.RowAppearance = Appearance83
        Me.gridProyecto.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridProyecto.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridProyecto.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance39.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridProyecto.DisplayLayout.Override.TemplateAddRowAppearance = Appearance39
        Me.gridProyecto.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridProyecto.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridProyecto.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridProyecto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridProyecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridProyecto.Location = New System.Drawing.Point(0, 0)
        Me.gridProyecto.Name = "gridProyecto"
        Me.gridProyecto.Size = New System.Drawing.Size(1126, 430)
        Me.gridProyecto.TabIndex = 195
        '
        'rdbCore
        '
        Me.rdbCore.Controls.Add(Me.txtcierretaller)
        Me.rdbCore.Controls.Add(Me.txtcierre)
        Me.rdbCore.Controls.Add(Me.txthoraejecucion)
        Me.rdbCore.Controls.Add(Me.UltraLabel11)
        Me.rdbCore.Controls.Add(Me.btncierretaller)
        Me.rdbCore.Controls.Add(Me.txtcostotaller)
        Me.rdbCore.Controls.Add(Me.UltraLabel10)
        Me.rdbCore.Controls.Add(Me.txtnumoperario)
        Me.rdbCore.Controls.Add(Me.dtfintaller)
        Me.rdbCore.Controls.Add(Me.dtiniciotaller)
        Me.rdbCore.Controls.Add(Me.UltraLabel9)
        Me.rdbCore.Controls.Add(Me.UltraLabel8)
        Me.rdbCore.Controls.Add(Me.UltraLabel7)
        Me.rdbCore.Controls.Add(Me.cmbTaller)
        Me.rdbCore.Controls.Add(Me.UltraLabel13)
        Me.rdbCore.Controls.Add(Me.UltraLabel6)
        Me.rdbCore.Controls.Add(Me.dtFechacierre)
        Me.rdbCore.Controls.Add(Me.btncierre)
        Me.rdbCore.Controls.Add(Me.UltraLabel5)
        Me.rdbCore.Controls.Add(Me.UltraLabel3)
        Me.rdbCore.Controls.Add(Me.txtcostoreal)
        Me.rdbCore.Controls.Add(Me.txtcostototal)
        Me.rdbCore.Controls.Add(Me.UltraLabel1)
        Me.rdbCore.Controls.Add(Me.UltraLabel2)
        Me.rdbCore.Controls.Add(Me.dtFecha)
        Me.rdbCore.Controls.Add(Me.txtproyecto)
        Me.rdbCore.Controls.Add(Me.UltraLabel4)
        Me.rdbCore.Controls.Add(Me.txtidproyecto)
        Me.rdbCore.Location = New System.Drawing.Point(-10000, -10000)
        Me.rdbCore.Name = "rdbCore"
        Me.rdbCore.Size = New System.Drawing.Size(1126, 430)
        '
        'txtcierretaller
        '
        Appearance81.TextHAlignAsString = "Left"
        Appearance81.TextVAlignAsString = "Middle"
        Me.txtcierretaller.Appearance = Appearance81
        Me.txtcierretaller.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcierretaller.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcierretaller.Location = New System.Drawing.Point(11, 278)
        Me.txtcierretaller.Name = "txtcierretaller"
        Me.txtcierretaller.ReadOnly = True
        Me.txtcierretaller.Size = New System.Drawing.Size(129, 21)
        Me.txtcierretaller.TabIndex = 277
        Me.txtcierretaller.TabStop = False
        Me.txtcierretaller.Visible = False
        '
        'txtcierre
        '
        Appearance22.TextHAlignAsString = "Left"
        Appearance22.TextVAlignAsString = "Middle"
        Me.txtcierre.Appearance = Appearance22
        Me.txtcierre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcierre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcierre.Location = New System.Drawing.Point(11, 27)
        Me.txtcierre.Name = "txtcierre"
        Me.txtcierre.ReadOnly = True
        Me.txtcierre.Size = New System.Drawing.Size(129, 21)
        Me.txtcierre.TabIndex = 276
        Me.txtcierre.TabStop = False
        Me.txtcierre.Visible = False
        '
        'txthoraejecucion
        '
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.txthoraejecucion.Appearance = Appearance7
        Me.txthoraejecucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txthoraejecucion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txthoraejecucion.Location = New System.Drawing.Point(710, 159)
        Me.txthoraejecucion.Name = "txthoraejecucion"
        Me.txthoraejecucion.ReadOnly = True
        Me.txthoraejecucion.Size = New System.Drawing.Size(85, 21)
        Me.txthoraejecucion.TabIndex = 275
        Me.txthoraejecucion.TabStop = False
        '
        'UltraLabel11
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Appearance16.TextHAlignAsString = "Left"
        Me.UltraLabel11.Appearance = Appearance16
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel11.Location = New System.Drawing.Point(565, 161)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(143, 17)
        Me.UltraLabel11.TabIndex = 274
        Me.UltraLabel11.Text = "Horas de ejecución del taller"
        '
        'btncierretaller
        '
        Me.btncierretaller.Location = New System.Drawing.Point(620, 225)
        Me.btncierretaller.Name = "btncierretaller"
        Me.btncierretaller.Size = New System.Drawing.Size(175, 23)
        Me.btncierretaller.TabIndex = 273
        Me.btncierretaller.Text = "Cierre de taller"
        Me.btncierretaller.UseVisualStyleBackColor = True
        '
        'txtcostotaller
        '
        Appearance11.TextHAlignAsString = "Right"
        Appearance11.TextVAlignAsString = "Middle"
        Me.txtcostotaller.Appearance = Appearance11
        Me.txtcostotaller.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostotaller.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostotaller.Location = New System.Drawing.Point(710, 132)
        Me.txtcostotaller.Name = "txtcostotaller"
        Me.txtcostotaller.ReadOnly = True
        Me.txtcostotaller.Size = New System.Drawing.Size(85, 21)
        Me.txtcostotaller.TabIndex = 272
        Me.txtcostotaller.TabStop = False
        '
        'UltraLabel10
        '
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Appearance20.TextHAlignAsString = "Left"
        Me.UltraLabel10.Appearance = Appearance20
        Me.UltraLabel10.AutoSize = True
        Me.UltraLabel10.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel10.Location = New System.Drawing.Point(605, 134)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(103, 17)
        Me.UltraLabel10.TabIndex = 271
        Me.UltraLabel10.Text = "Costo total por taller"
        '
        'txtnumoperario
        '
        Appearance15.TextHAlignAsString = "Right"
        Appearance15.TextVAlignAsString = "Middle"
        Me.txtnumoperario.Appearance = Appearance15
        Me.txtnumoperario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumoperario.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtnumoperario.Location = New System.Drawing.Point(372, 183)
        Me.txtnumoperario.Name = "txtnumoperario"
        Me.txtnumoperario.ReadOnly = True
        Me.txtnumoperario.Size = New System.Drawing.Size(147, 21)
        Me.txtnumoperario.TabIndex = 270
        Me.txtnumoperario.TabStop = False
        '
        'dtfintaller
        '
        Me.dtfintaller.AutoSize = False
        Me.dtfintaller.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtfintaller.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtfintaller.Location = New System.Drawing.Point(372, 233)
        Me.dtfintaller.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtfintaller.Name = "dtfintaller"
        Me.dtfintaller.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtfintaller.Size = New System.Drawing.Size(147, 18)
        Me.dtfintaller.TabIndex = 269
        Me.dtfintaller.TabStop = False
        Me.dtfintaller.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'dtiniciotaller
        '
        Me.dtiniciotaller.AutoSize = False
        Me.dtiniciotaller.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtiniciotaller.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtiniciotaller.Location = New System.Drawing.Point(372, 210)
        Me.dtiniciotaller.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtiniciotaller.Name = "dtiniciotaller"
        Me.dtiniciotaller.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtiniciotaller.ReadOnly = True
        Me.dtiniciotaller.Size = New System.Drawing.Size(147, 18)
        Me.dtiniciotaller.TabIndex = 268
        Me.dtiniciotaller.TabStop = False
        Me.dtiniciotaller.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'UltraLabel9
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Left"
        Me.UltraLabel9.Appearance = Appearance3
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel9.Location = New System.Drawing.Point(215, 231)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(115, 17)
        Me.UltraLabel9.TabIndex = 267
        Me.UltraLabel9.Text = "Fecha de Finalización:"
        '
        'UltraLabel8
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextHAlignAsString = "Left"
        Me.UltraLabel8.Appearance = Appearance4
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel8.Location = New System.Drawing.Point(215, 208)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(82, 17)
        Me.UltraLabel8.TabIndex = 266
        Me.UltraLabel8.Text = "Fecha de Inicio:"
        '
        'UltraLabel7
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Left"
        Me.UltraLabel7.Appearance = Appearance6
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel7.Location = New System.Drawing.Point(215, 185)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(138, 17)
        Me.UltraLabel7.TabIndex = 265
        Me.UltraLabel7.Text = "N° de operarios asignados:"
        '
        'cmbTaller
        '
        Me.cmbTaller.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance69.BackColor = System.Drawing.SystemColors.Window
        Appearance69.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmbTaller.DisplayLayout.Appearance = Appearance69
        Me.cmbTaller.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmbTaller.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance70.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance70.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance70.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance70.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbTaller.DisplayLayout.GroupByBox.Appearance = Appearance70
        Appearance72.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbTaller.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance72
        Appearance73.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance73.BackColor2 = System.Drawing.SystemColors.Control
        Appearance73.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance73.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbTaller.DisplayLayout.GroupByBox.PromptAppearance = Appearance73
        Me.cmbTaller.DisplayLayout.MaxColScrollRegions = 1
        Me.cmbTaller.DisplayLayout.MaxRowScrollRegions = 1
        Appearance74.BackColor = System.Drawing.SystemColors.Highlight
        Appearance74.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmbTaller.DisplayLayout.Override.ActiveRowAppearance = Appearance74
        Appearance75.BackColor = System.Drawing.Color.Transparent
        Me.cmbTaller.DisplayLayout.Override.CardAreaAppearance = Appearance75
        Appearance76.BorderColor = System.Drawing.Color.Silver
        Appearance76.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmbTaller.DisplayLayout.Override.CellAppearance = Appearance76
        Me.cmbTaller.DisplayLayout.Override.CellPadding = 0
        Appearance77.TextHAlignAsString = "Left"
        Me.cmbTaller.DisplayLayout.Override.HeaderAppearance = Appearance77
        Me.cmbTaller.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbTaller.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance78.BackColor = System.Drawing.SystemColors.Window
        Appearance78.BorderColor = System.Drawing.Color.Silver
        Me.cmbTaller.DisplayLayout.Override.RowAppearance = Appearance78
        Me.cmbTaller.DisplayLayout.Override.RowSpacingAfter = 4
        Me.cmbTaller.DisplayLayout.Override.RowSpacingBefore = 2
        Me.cmbTaller.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmbTaller.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmbTaller.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmbTaller.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbTaller.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbTaller.Location = New System.Drawing.Point(136, 136)
        Me.cmbTaller.Name = "cmbTaller"
        Me.cmbTaller.Size = New System.Drawing.Size(383, 22)
        Me.cmbTaller.TabIndex = 264
        Me.cmbTaller.TabStop = False
        '
        'UltraLabel13
        '
        Appearance156.BackColor = System.Drawing.Color.Transparent
        Appearance156.TextHAlignAsString = "Left"
        Me.UltraLabel13.Appearance = Appearance156
        Me.UltraLabel13.AutoSize = True
        Me.UltraLabel13.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel13.Location = New System.Drawing.Point(95, 138)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(38, 17)
        Me.UltraLabel13.TabIndex = 263
        Me.UltraLabel13.Text = "Taller :"
        '
        'UltraLabel6
        '
        Appearance17.BackColor = System.Drawing.Color.Transparent
        Appearance17.TextHAlignAsString = "Left"
        Me.UltraLabel6.Appearance = Appearance17
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(300, 86)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(71, 17)
        Me.UltraLabel6.TabIndex = 261
        Me.UltraLabel6.Text = "Fecha Cierre:"
        '
        'dtFechacierre
        '
        Me.dtFechacierre.AutoSize = False
        Me.dtFechacierre.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtFechacierre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFechacierre.Location = New System.Drawing.Point(372, 85)
        Me.dtFechacierre.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtFechacierre.Name = "dtFechacierre"
        Me.dtFechacierre.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtFechacierre.Size = New System.Drawing.Size(147, 18)
        Me.dtFechacierre.TabIndex = 260
        Me.dtFechacierre.TabStop = False
        Me.dtFechacierre.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'btncierre
        '
        Me.btncierre.Location = New System.Drawing.Point(621, 80)
        Me.btncierre.Name = "btncierre"
        Me.btncierre.Size = New System.Drawing.Size(175, 23)
        Me.btncierre.TabIndex = 259
        Me.btncierre.Text = "Cierre de planificación"
        Me.btncierre.UseVisualStyleBackColor = True
        '
        'UltraLabel5
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Center"
        Me.UltraLabel5.Appearance = Appearance12
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel5.Location = New System.Drawing.Point(801, 29)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(85, 17)
        Me.UltraLabel5.TabIndex = 258
        Me.UltraLabel5.Text = "Real"
        Me.UltraLabel5.Visible = False
        '
        'UltraLabel3
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextHAlignAsString = "Center"
        Me.UltraLabel3.Appearance = Appearance13
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(710, 29)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(85, 17)
        Me.UltraLabel3.TabIndex = 257
        Me.UltraLabel3.Text = "Planificado"
        Me.UltraLabel3.Visible = False
        '
        'txtcostoreal
        '
        Appearance14.TextHAlignAsString = "Right"
        Appearance14.TextVAlignAsString = "Middle"
        Me.txtcostoreal.Appearance = Appearance14
        Me.txtcostoreal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoreal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoreal.Location = New System.Drawing.Point(801, 52)
        Me.txtcostoreal.Name = "txtcostoreal"
        Me.txtcostoreal.ReadOnly = True
        Me.txtcostoreal.Size = New System.Drawing.Size(85, 21)
        Me.txtcostoreal.TabIndex = 256
        Me.txtcostoreal.TabStop = False
        Me.txtcostoreal.Visible = False
        '
        'txtcostototal
        '
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.txtcostototal.Appearance = Appearance9
        Me.txtcostototal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostototal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostototal.Location = New System.Drawing.Point(710, 52)
        Me.txtcostototal.Name = "txtcostototal"
        Me.txtcostototal.ReadOnly = True
        Me.txtcostototal.Size = New System.Drawing.Size(85, 21)
        Me.txtcostototal.TabIndex = 255
        Me.txtcostototal.TabStop = False
        '
        'UltraLabel1
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Left"
        Me.UltraLabel1.Appearance = Appearance10
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(588, 54)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(120, 17)
        Me.UltraLabel1.TabIndex = 254
        Me.UltraLabel1.Text = "Costo total del proyecto"
        '
        'UltraLabel2
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Left"
        Me.UltraLabel2.Appearance = Appearance8
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(51, 86)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(82, 17)
        Me.UltraLabel2.TabIndex = 253
        Me.UltraLabel2.Text = "Fecha de Inicio:"
        '
        'dtFecha
        '
        Me.dtFecha.AutoSize = False
        Me.dtFecha.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFecha.Location = New System.Drawing.Point(136, 85)
        Me.dtFecha.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtFecha.ReadOnly = True
        Me.dtFecha.Size = New System.Drawing.Size(147, 18)
        Me.dtFecha.TabIndex = 252
        Me.dtFecha.TabStop = False
        Me.dtFecha.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'txtproyecto
        '
        Appearance18.TextHAlignAsString = "Left"
        Appearance18.TextVAlignAsString = "Middle"
        Me.txtproyecto.Appearance = Appearance18
        Me.txtproyecto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtproyecto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtproyecto.Location = New System.Drawing.Point(136, 53)
        Me.txtproyecto.Name = "txtproyecto"
        Me.txtproyecto.ReadOnly = True
        Me.txtproyecto.Size = New System.Drawing.Size(383, 21)
        Me.txtproyecto.TabIndex = 251
        Me.txtproyecto.TabStop = False
        '
        'UltraLabel4
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Appearance19.TextHAlignAsString = "Left"
        Me.UltraLabel4.Appearance = Appearance19
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(80, 55)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(54, 17)
        Me.UltraLabel4.TabIndex = 250
        Me.UltraLabel4.Text = "Proyecto :"
        '
        'txtidproyecto
        '
        Appearance21.TextHAlignAsString = "Left"
        Appearance21.TextVAlignAsString = "Middle"
        Me.txtidproyecto.Appearance = Appearance21
        Me.txtidproyecto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidproyecto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtidproyecto.Location = New System.Drawing.Point(11, 3)
        Me.txtidproyecto.Name = "txtidproyecto"
        Me.txtidproyecto.ReadOnly = True
        Me.txtidproyecto.Size = New System.Drawing.Size(129, 21)
        Me.txtidproyecto.TabIndex = 249
        Me.txtidproyecto.TabStop = False
        Me.txtidproyecto.Visible = False
        '
        'Tab1
        '
        Appearance99.FontData.BoldAsString = "True"
        Appearance99.FontData.Name = "Arial Narrow"
        Appearance99.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance99
        Appearance100.FontData.Name = "Arial Narrow"
        Appearance100.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance100
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Controls.Add(Me.rdbCore)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(1130, 468)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance101.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance101
        Me.Tab1.TabIndex = 16
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance102.Cursor = System.Windows.Forms.Cursors.Default
        Appearance102.FontData.BoldAsString = "True"
        Appearance102.FontData.Name = "Arial Narrow"
        Appearance102.FontData.SizeInPoints = 16.0!
        UltraTab6.ActiveAppearance = Appearance102
        Appearance103.FontData.Name = "Arial Narrow"
        Appearance103.FontData.SizeInPoints = 10.0!
        UltraTab6.Appearance = Appearance103
        UltraTab6.Key = "T01"
        UltraTab6.TabPage = Me.UltraTabPageControl1
        UltraTab6.Text = "LISTADO DE PROYECTOS"
        Appearance1.FontData.Name = "Arial Narrow"
        Appearance1.FontData.SizeInPoints = 16.0!
        UltraTab1.ActiveAppearance = Appearance1
        Appearance5.FontData.Name = "Arial Narrow"
        Appearance5.FontData.SizeInPoints = 10.0!
        UltraTab1.Appearance = Appearance5
        UltraTab1.Key = "T02"
        UltraTab1.TabPage = Me.rdbCore
        UltraTab1.Text = "CIERRE DE PLANIFICACION"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab6, UltraTab1})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1126, 430)
        '
        'FrmCierrePlanificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 468)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmCierrePlanificacion"
        Me.Text = "FrmCierrePlanificacion"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.panel.ResumeLayout(False)
        CType(Me.gridProyecto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rdbCore.ResumeLayout(False)
        Me.rdbCore.PerformLayout()
        CType(Me.txtcierretaller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txthoraejecucion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostotaller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnumoperario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtfintaller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtiniciotaller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTaller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechacierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoreal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostototal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtproyecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidproyecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents panel As System.Windows.Forms.Panel
    Friend WithEvents gridProyecto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents rdbCore As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostoreal As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcostototal As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtproyecto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtidproyecto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btncierre As System.Windows.Forms.Button
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtFechacierre As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cmbTaller As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtnumoperario As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dtfintaller As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dtiniciotaller As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostotaller As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btncierretaller As System.Windows.Forms.Button
    Friend WithEvents txthoraejecucion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcierre As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcierretaller As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
