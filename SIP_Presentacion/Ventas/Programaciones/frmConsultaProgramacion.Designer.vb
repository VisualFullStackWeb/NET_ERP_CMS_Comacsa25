<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaProgramacion
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
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaProgramacion))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUMPEDIDO", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TONELADA", 1)
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CLIENTE", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DISTRITO", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PLACA", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HORA", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROGRAMACION", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DESCRIPCION", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DIRECCION", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("REFERENCIA", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROD", 10)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PRODUCTO", 11)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NROVIAJE", 12)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPROGRAMACION", 13)
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "HORA", 5, False)
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TONELADA", 1, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TONELADA", 1, False)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(726)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(840)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(234)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(737)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(992)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion13 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion14 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.nupviaje = New System.Windows.Forms.NumericUpDown
        Me.gridProgramacion = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.txtproveedor = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtcodprov = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.nupviaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridProgramacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtproveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodprov, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(772, 388)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.UltraLabel1)
        Me.Panel1.Controls.Add(Me.nupviaje)
        Me.Panel1.Controls.Add(Me.gridProgramacion)
        Me.Panel1.Controls.Add(Me.txtproveedor)
        Me.Panel1.Controls.Add(Me.UltraLabel8)
        Me.Panel1.Controls.Add(Me.UltraLabel7)
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.txtcodprov)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(772, 388)
        Me.Panel1.TabIndex = 176
        '
        'UltraLabel1
        '
        Appearance54.BackColor = System.Drawing.Color.Transparent
        Appearance54.TextHAlignAsString = "Center"
        Appearance54.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance54
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(202, 46)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(54, 14)
        Me.UltraLabel1.TabIndex = 211
        Me.UltraLabel1.Text = "Nro. Viaje"
        Me.UltraLabel1.Visible = False
        '
        'nupviaje
        '
        Me.nupviaje.Location = New System.Drawing.Point(266, 44)
        Me.nupviaje.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nupviaje.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupviaje.Name = "nupviaje"
        Me.nupviaje.ReadOnly = True
        Me.nupviaje.Size = New System.Drawing.Size(60, 20)
        Me.nupviaje.TabIndex = 212
        Me.nupviaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nupviaje.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupviaje.Visible = False
        '
        'gridProgramacion
        '
        Me.gridProgramacion.AllowDrop = True
        Me.gridProgramacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Appearance31.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridProgramacion.DisplayLayout.Appearance = Appearance31
        Me.gridProgramacion.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
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
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.Caption = "N° PEDIDO"
        UltraGridColumn2.Header.VisiblePosition = 3
        UltraGridColumn2.MaxWidth = 70
        UltraGridColumn2.MinWidth = 70
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.Width = 70
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance35.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance35
        UltraGridColumn3.Format = "##0.00"
        UltraGridColumn3.Header.VisiblePosition = 10
        UltraGridColumn3.MaskInput = "{double:8.2}"
        UltraGridColumn3.MaxWidth = 80
        UltraGridColumn3.MinWidth = 80
        UltraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.Width = 80
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn4.Width = 84
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn5.Width = 70
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.VisiblePosition = 1
        UltraGridColumn6.MaxWidth = 60
        UltraGridColumn6.MinWidth = 60
        UltraGridColumn6.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn6.Width = 60
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.VisiblePosition = 9
        UltraGridColumn7.MaxWidth = 100
        UltraGridColumn7.MinWidth = 100
        UltraGridColumn7.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn7.Width = 100
        UltraGridColumn8.Header.VisiblePosition = 11
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 82
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.VisiblePosition = 2
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.MaxWidth = 100
        UltraGridColumn9.MinWidth = 100
        UltraGridColumn9.Width = 100
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.VisiblePosition = 7
        UltraGridColumn10.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn10.Width = 66
        UltraGridColumn11.Header.VisiblePosition = 12
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 79
        UltraGridColumn12.Header.VisiblePosition = 13
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 61
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.VisiblePosition = 8
        UltraGridColumn13.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn13.Width = 103
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn14.Header.Caption = "N° VIAJE"
        UltraGridColumn14.Header.VisiblePosition = 4
        UltraGridColumn14.MaxWidth = 55
        UltraGridColumn14.MinWidth = 55
        UltraGridColumn14.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn14.Width = 55
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 85
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15})
        SummarySettings1.DisplayFormat = "Total"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance36
        Appearance4.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance4
        SummarySettings2.DisplayFormat = "{0}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance2
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
        UltraGridBand1.SummaryFooterCaption = ""
        Me.gridProgramacion.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridProgramacion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridProgramacion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridProgramacion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridProgramacion.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance40.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance40.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance40.BorderColor = System.Drawing.SystemColors.Window
        Me.gridProgramacion.DisplayLayout.GroupByBox.Appearance = Appearance40
        Appearance41.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridProgramacion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance41
        Me.gridProgramacion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridProgramacion.DisplayLayout.GroupByBox.Hidden = True
        Appearance42.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance42.BackColor2 = System.Drawing.SystemColors.Control
        Appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance42.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridProgramacion.DisplayLayout.GroupByBox.PromptAppearance = Appearance42
        Me.gridProgramacion.DisplayLayout.MaxColScrollRegions = 1
        Me.gridProgramacion.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridProgramacion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridProgramacion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridProgramacion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Me.gridProgramacion.DisplayLayout.Override.CardAreaAppearance = Appearance43
        Appearance44.BorderColor = System.Drawing.Color.Silver
        Appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridProgramacion.DisplayLayout.Override.CellAppearance = Appearance44
        Me.gridProgramacion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridProgramacion.DisplayLayout.Override.CellPadding = 0
        Me.gridProgramacion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridProgramacion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridProgramacion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridProgramacion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance45.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance45.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridProgramacion.DisplayLayout.Override.FilterRowAppearance = Appearance45
        Me.gridProgramacion.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridProgramacion.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridProgramacion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance46.BackColor = System.Drawing.SystemColors.Control
        Appearance46.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance46.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance46.BorderColor = System.Drawing.SystemColors.Window
        Me.gridProgramacion.DisplayLayout.Override.GroupByRowAppearance = Appearance46
        Appearance47.FontData.Name = "Arial Narrow"
        Appearance47.FontData.SizeInPoints = 10.0!
        Appearance47.TextHAlignAsString = "Left"
        Me.gridProgramacion.DisplayLayout.Override.HeaderAppearance = Appearance47
        Me.gridProgramacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridProgramacion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridProgramacion.DisplayLayout.Override.MinRowHeight = 24
        Appearance48.BackColor = System.Drawing.SystemColors.Window
        Appearance48.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance48.TextVAlignAsString = "Middle"
        Me.gridProgramacion.DisplayLayout.Override.RowAppearance = Appearance48
        Me.gridProgramacion.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridProgramacion.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridProgramacion.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance49.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridProgramacion.DisplayLayout.Override.TemplateAddRowAppearance = Appearance49
        Me.gridProgramacion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridProgramacion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridProgramacion.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridProgramacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridProgramacion.Location = New System.Drawing.Point(23, 83)
        Me.gridProgramacion.Name = "gridProgramacion"
        Me.gridProgramacion.Size = New System.Drawing.Size(728, 296)
        Me.gridProgramacion.TabIndex = 173
        Me.gridProgramacion.Text = "UltraGrid1"
        '
        'txtproveedor
        '
        Appearance50.FontData.BoldAsString = "False"
        Appearance50.ForeColor = System.Drawing.Color.Black
        Appearance50.TextHAlignAsString = "Left"
        Appearance50.TextVAlignAsString = "Middle"
        Me.txtproveedor.Appearance = Appearance50
        Me.txtproveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtproveedor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtproveedor.Location = New System.Drawing.Point(202, 17)
        Me.txtproveedor.MaxLength = 20
        Me.txtproveedor.Name = "txtproveedor"
        Me.txtproveedor.ReadOnly = True
        Me.txtproveedor.Size = New System.Drawing.Size(273, 21)
        Me.txtproveedor.TabIndex = 206
        Me.txtproveedor.TabStop = False
        '
        'UltraLabel8
        '
        Appearance53.BackColor = System.Drawing.Color.Transparent
        Appearance53.TextHAlignAsString = "Center"
        Appearance53.TextVAlignAsString = "Middle"
        Me.UltraLabel8.Appearance = Appearance53
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Location = New System.Drawing.Point(51, 47)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(36, 14)
        Me.UltraLabel8.TabIndex = 210
        Me.UltraLabel8.Text = "Fecha"
        '
        'UltraLabel7
        '
        Appearance52.BackColor = System.Drawing.Color.Transparent
        Appearance52.TextHAlignAsString = "Right"
        Me.UltraLabel7.Appearance = Appearance52
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel7.Location = New System.Drawing.Point(27, 18)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(59, 17)
        Me.UltraLabel7.TabIndex = 208
        Me.UltraLabel7.Text = "& Proveedor"
        '
        'dtpFecha
        '
        Me.dtpFecha.AutoSize = False
        Me.dtpFecha.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpFecha.Location = New System.Drawing.Point(94, 44)
        Me.dtpFecha.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpFecha.Size = New System.Drawing.Size(103, 18)
        Me.dtpFecha.TabIndex = 209
        Me.dtpFecha.TabStop = False
        Me.dtpFecha.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'txtcodprov
        '
        Appearance51.FontData.BoldAsString = "False"
        Appearance51.ForeColor = System.Drawing.Color.Black
        Appearance51.TextHAlignAsString = "Left"
        Appearance51.TextVAlignAsString = "Middle"
        Me.txtcodprov.Appearance = Appearance51
        Me.txtcodprov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodprov.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodprov.Location = New System.Drawing.Point(94, 17)
        Me.txtcodprov.MaxLength = 8
        Me.txtcodprov.Name = "txtcodprov"
        Me.txtcodprov.Size = New System.Drawing.Size(102, 21)
        Me.txtcodprov.TabIndex = 207
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
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(776, 426)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance11
        Me.Tab1.TabIndex = 213
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
        UltraTab3.Text = "CONSULTA DE PROGRAMACIONES"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(772, 388)
        '
        'frmConsultaProgramacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(776, 426)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "frmConsultaProgramacion"
        Me.Text = "frmConsultaProgramacion"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nupviaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridProgramacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtproveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodprov, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridProgramacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtproveedor As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcodprov As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents nupviaje As System.Windows.Forms.NumericUpDown
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
