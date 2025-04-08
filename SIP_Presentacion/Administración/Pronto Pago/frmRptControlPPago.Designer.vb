<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptControlPPago
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
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptControlPPago))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("REG_COMP", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODIGO", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_PROC", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_DOC", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_VTO", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FORMA_PAGO", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_RECEPCION", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_CANCELA", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DIASADELANTO", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TASA", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NRO_COMP", 10)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RAZSOC", 11)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MONEDA", 12)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VALOR_VTA", 13)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IGV", 14)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOTAL", 15)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NC", 16)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IMPORTE", 17)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("USUARIO", 18)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO_CAMBIO", 19)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(923)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(702)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(702)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(668)
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
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtpHasta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpDesde = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.gridReporte = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtpHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(945, 381)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.dtpHasta)
        Me.Panel1.Controls.Add(Me.UltraLabel1)
        Me.Panel1.Controls.Add(Me.dtpDesde)
        Me.Panel1.Controls.Add(Me.UltraLabel5)
        Me.Panel1.Controls.Add(Me.lblmensaje)
        Me.Panel1.Controls.Add(Me.gridReporte)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(945, 381)
        Me.Panel1.TabIndex = 176
        '
        'dtpHasta
        '
        Me.dtpHasta.AutoSize = False
        Me.dtpHasta.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtpHasta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpHasta.Location = New System.Drawing.Point(218, 20)
        Me.dtpHasta.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpHasta.Size = New System.Drawing.Size(98, 18)
        Me.dtpHasta.TabIndex = 198
        Me.dtpHasta.TabStop = False
        Me.dtpHasta.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'UltraLabel1
        '
        Appearance39.BackColor = System.Drawing.Color.Transparent
        Appearance39.TextHAlignAsString = "Center"
        Appearance39.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance39
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(178, 22)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(34, 14)
        Me.UltraLabel1.TabIndex = 199
        Me.UltraLabel1.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.AutoSize = False
        Me.dtpDesde.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtpDesde.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpDesde.Location = New System.Drawing.Point(67, 20)
        Me.dtpDesde.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpDesde.Size = New System.Drawing.Size(98, 18)
        Me.dtpDesde.TabIndex = 196
        Me.dtpDesde.TabStop = False
        Me.dtpDesde.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'UltraLabel5
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextHAlignAsString = "Center"
        Appearance13.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance13
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(26, 22)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(37, 14)
        Me.UltraLabel5.TabIndex = 197
        Me.UltraLabel5.Text = "Desde"
        '
        'lblmensaje
        '
        Me.lblmensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance26.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Appearance26.FontData.BoldAsString = "True"
        Appearance26.FontData.SizeInPoints = 10.0!
        Appearance26.ForeColor = System.Drawing.Color.SteelBlue
        Appearance26.TextHAlignAsString = "Center"
        Appearance26.TextVAlignAsString = "Middle"
        Me.lblmensaje.Appearance = Appearance26
        Me.lblmensaje.Location = New System.Drawing.Point(-1, 198)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(949, 39)
        Me.lblmensaje.TabIndex = 165
        Me.lblmensaje.Text = "Buscando Datos en Sunat..."
        Me.lblmensaje.Visible = False
        '
        'gridReporte
        '
        Me.gridReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.SystemColors.Window
        Appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridReporte.DisplayLayout.Appearance = Appearance3
        Me.gridReporte.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        Appearance4.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance4
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 51
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 51
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 50
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 47
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 65
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 44
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 17
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 18
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 36
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Width = 38
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Width = 79
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Width = 83
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.Width = 44
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Width = 66
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.Width = 55
        UltraGridColumn17.Header.VisiblePosition = 16
        UltraGridColumn17.Width = 66
        UltraGridColumn18.Header.VisiblePosition = 17
        UltraGridColumn18.Width = 47
        UltraGridColumn19.Header.VisiblePosition = 18
        UltraGridColumn19.Width = 63
        UltraGridColumn20.Header.VisiblePosition = 19
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 53
        UltraGridColumn21.Header.VisiblePosition = 20
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 71
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21})
        Me.gridReporte.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridReporte.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridReporte.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.SystemColors.Window
        Me.gridReporte.DisplayLayout.GroupByBox.Appearance = Appearance7
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridReporte.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
        Me.gridReporte.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridReporte.DisplayLayout.GroupByBox.Hidden = True
        Appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance10.BackColor2 = System.Drawing.SystemColors.Control
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridReporte.DisplayLayout.GroupByBox.PromptAppearance = Appearance10
        Me.gridReporte.DisplayLayout.MaxColScrollRegions = 1
        Me.gridReporte.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridReporte.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridReporte.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridReporte.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Me.gridReporte.DisplayLayout.Override.CardAreaAppearance = Appearance11
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridReporte.DisplayLayout.Override.CellAppearance = Appearance12
        Me.gridReporte.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridReporte.DisplayLayout.Override.CellPadding = 0
        Me.gridReporte.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridReporte.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridReporte.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridReporte.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance2.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridReporte.DisplayLayout.Override.FilterRowAppearance = Appearance2
        Me.gridReporte.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridReporte.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance14.BackColor = System.Drawing.SystemColors.Control
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.gridReporte.DisplayLayout.Override.GroupByRowAppearance = Appearance14
        Appearance15.FontData.Name = "Arial Narrow"
        Appearance15.FontData.SizeInPoints = 10.0!
        Appearance15.TextHAlignAsString = "Left"
        Me.gridReporte.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.gridReporte.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridReporte.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridReporte.DisplayLayout.Override.MinRowHeight = 24
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.TextVAlignAsString = "Middle"
        Me.gridReporte.DisplayLayout.Override.RowAppearance = Appearance16
        Me.gridReporte.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridReporte.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridReporte.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridReporte.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
        Me.gridReporte.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridReporte.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridReporte.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridReporte.Location = New System.Drawing.Point(11, 64)
        Me.gridReporte.Name = "gridReporte"
        Me.gridReporte.Size = New System.Drawing.Size(925, 308)
        Me.gridReporte.TabIndex = 194
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
        Me.Tab1.Size = New System.Drawing.Size(949, 419)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance19.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance19
        Me.Tab1.TabIndex = 13
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance24.Cursor = System.Windows.Forms.Cursors.Default
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.FontData.Name = "Arial Narrow"
        Appearance24.FontData.SizeInPoints = 16.0!
        UltraTab3.ActiveAppearance = Appearance24
        Appearance43.FontData.Name = "Arial Narrow"
        Appearance43.FontData.SizeInPoints = 10.0!
        UltraTab3.Appearance = Appearance43
        UltraTab3.Key = "T01"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "CONTROL DE DESCUENTOS POR PRONTO PAGO"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(945, 381)
        '
        'frmRptControlPPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 419)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "frmRptControlPPago"
        Me.Text = "frmRptControlPPago"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtpHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents gridReporte As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents dtpDesde As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpHasta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
End Class
