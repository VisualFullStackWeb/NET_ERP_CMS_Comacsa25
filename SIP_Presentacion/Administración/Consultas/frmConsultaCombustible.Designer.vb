<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaCombustible
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaCombustible))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDoc", 0)
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumSolicitud", 1)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Galones", 2)
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NomTrabajador", 4)
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Combustible", 5)
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumDoc", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantera", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Auxiliar", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Proveedor", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("montoTotal", 10)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("montoParcial", 11)
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 12)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("numinterno", 13)
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpfin = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpinicio = New System.Windows.Forms.DateTimePicker
        Me.GridConsultaDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.TxtCodigoTrabajador = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.TxtNombresTrabajador = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.GridConsultaDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodigoTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNombresTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(236, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Hasta:"
        '
        'dtpfin
        '
        Me.dtpfin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfin.Location = New System.Drawing.Point(288, 19)
        Me.dtpfin.Name = "dtpfin"
        Me.dtpfin.Size = New System.Drawing.Size(120, 20)
        Me.dtpfin.TabIndex = 154
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(42, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Desde:"
        '
        'dtpinicio
        '
        Me.dtpinicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpinicio.Location = New System.Drawing.Point(89, 19)
        Me.dtpinicio.Name = "dtpinicio"
        Me.dtpinicio.Size = New System.Drawing.Size(120, 20)
        Me.dtpinicio.TabIndex = 153
        '
        'GridConsultaDetalle
        '
        Me.GridConsultaDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridConsultaDetalle.DisplayLayout.Appearance = Appearance2
        Me.GridConsultaDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance3
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Left"
        UltraGridColumn2.CellAppearance = Appearance6
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn2.Header.Caption = "T.Doc"
        UltraGridColumn2.Header.VisiblePosition = 4
        UltraGridColumn2.MinWidth = 8
        UltraGridColumn2.Width = 30
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance1.TextHAlignAsString = "Left"
        UltraGridColumn3.CellAppearance = Appearance1
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn3.Header.Caption = "Solicitud"
        UltraGridColumn3.Header.VisiblePosition = 1
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.MinWidth = 8
        UltraGridColumn3.Width = 27
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance64.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance64
        UltraGridColumn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn4.DataType = GetType(Double)
        UltraGridColumn4.Format = "###,##,##0.00"
        UltraGridColumn4.Header.VisiblePosition = 10
        UltraGridColumn4.MaskInput = "{double:8.2}"
        UltraGridColumn4.Width = 44
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 3
        UltraGridColumn5.Width = 49
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance40.TextHAlignAsString = "Left"
        UltraGridColumn6.CellAppearance = Appearance40
        UltraGridColumn6.Format = ""
        UltraGridColumn6.Header.Caption = "Beneficiario"
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Width = 112
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance42.TextHAlignAsString = "Left"
        UltraGridColumn7.CellAppearance = Appearance42
        UltraGridColumn7.Format = ""
        UltraGridColumn7.Header.VisiblePosition = 9
        UltraGridColumn7.Width = 70
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.Caption = "N°Doc"
        UltraGridColumn8.Header.VisiblePosition = 5
        UltraGridColumn8.Width = 72
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.Caption = "Canteras"
        UltraGridColumn9.Header.VisiblePosition = 7
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 45
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.Caption = "Maquinas"
        UltraGridColumn10.Header.VisiblePosition = 8
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 57
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.VisiblePosition = 11
        UltraGridColumn11.Width = 109
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance4
        UltraGridColumn12.Format = "###,##,##0.00"
        UltraGridColumn12.Header.Caption = "Importe"
        UltraGridColumn12.Header.VisiblePosition = 12
        UltraGridColumn12.Width = 48
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance5
        UltraGridColumn13.Format = "###,##,##0.00"
        UltraGridColumn13.Header.Caption = "Costo/Galon"
        UltraGridColumn13.Header.VisiblePosition = 13
        UltraGridColumn13.Width = 61
        UltraGridColumn14.Header.VisiblePosition = 2
        UltraGridColumn14.Width = 83
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 94
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15})
        Me.GridConsultaDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridConsultaDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridConsultaDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridConsultaDetalle.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance50.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance50.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance50.BorderColor = System.Drawing.SystemColors.Window
        Me.GridConsultaDetalle.DisplayLayout.GroupByBox.Appearance = Appearance50
        Appearance66.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridConsultaDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance66
        Me.GridConsultaDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridConsultaDetalle.DisplayLayout.GroupByBox.Hidden = True
        Appearance71.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance71.BackColor2 = System.Drawing.SystemColors.Control
        Appearance71.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance71.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridConsultaDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance71
        Me.GridConsultaDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.GridConsultaDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.GridConsultaDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridConsultaDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridConsultaDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance72.BackColor = System.Drawing.SystemColors.Window
        Me.GridConsultaDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance72
        Appearance73.BorderColor = System.Drawing.Color.Silver
        Appearance73.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridConsultaDetalle.DisplayLayout.Override.CellAppearance = Appearance73
        Me.GridConsultaDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridConsultaDetalle.DisplayLayout.Override.CellPadding = 0
        Me.GridConsultaDetalle.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.GridConsultaDetalle.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.GridConsultaDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.GridConsultaDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance74.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance74.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GridConsultaDetalle.DisplayLayout.Override.FilterRowAppearance = Appearance74
        Me.GridConsultaDetalle.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.GridConsultaDetalle.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.GridConsultaDetalle.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance75.BackColor = System.Drawing.SystemColors.Control
        Appearance75.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance75.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance75.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance75.BorderColor = System.Drawing.SystemColors.Window
        Me.GridConsultaDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance75
        Appearance76.FontData.Name = "Arial Narrow"
        Appearance76.FontData.SizeInPoints = 10.0!
        Appearance76.TextHAlignAsString = "Left"
        Me.GridConsultaDetalle.DisplayLayout.Override.HeaderAppearance = Appearance76
        Me.GridConsultaDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.GridConsultaDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.GridConsultaDetalle.DisplayLayout.Override.MinRowHeight = 24
        Appearance77.BackColor = System.Drawing.SystemColors.Window
        Appearance77.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance77.TextVAlignAsString = "Middle"
        Me.GridConsultaDetalle.DisplayLayout.Override.RowAppearance = Appearance77
        Me.GridConsultaDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.GridConsultaDetalle.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.GridConsultaDetalle.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance78.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridConsultaDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance78
        Me.GridConsultaDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridConsultaDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridConsultaDetalle.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.GridConsultaDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridConsultaDetalle.Location = New System.Drawing.Point(21, 101)
        Me.GridConsultaDetalle.Name = "GridConsultaDetalle"
        Me.GridConsultaDetalle.Size = New System.Drawing.Size(718, 301)
        Me.GridConsultaDetalle.TabIndex = 157
        Me.GridConsultaDetalle.Text = "UltraGrid1"
        '
        'UltraLabel2
        '
        Appearance101.BackColor = System.Drawing.Color.Transparent
        Appearance101.TextHAlignAsString = "Center"
        Appearance101.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance101
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(223, 58)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(59, 14)
        Me.UltraLabel2.TabIndex = 161
        Me.UltraLabel2.Text = "Trabajador"
        '
        'TxtCodigoTrabajador
        '
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.TextHAlignAsString = "Left"
        Appearance12.TextVAlignAsString = "Middle"
        Me.TxtCodigoTrabajador.Appearance = Appearance12
        Me.TxtCodigoTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodigoTrabajador.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtCodigoTrabajador.Location = New System.Drawing.Point(89, 54)
        Me.TxtCodigoTrabajador.MaxLength = 8
        Me.TxtCodigoTrabajador.Name = "TxtCodigoTrabajador"
        Me.TxtCodigoTrabajador.Size = New System.Drawing.Size(120, 21)
        Me.TxtCodigoTrabajador.TabIndex = 159
        Me.TxtCodigoTrabajador.TabStop = False
        '
        'TxtNombresTrabajador
        '
        Appearance20.TextHAlignAsString = "Left"
        Appearance20.TextVAlignAsString = "Middle"
        Me.TxtNombresTrabajador.Appearance = Appearance20
        Me.TxtNombresTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombresTrabajador.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtNombresTrabajador.Location = New System.Drawing.Point(288, 54)
        Me.TxtNombresTrabajador.Name = "TxtNombresTrabajador"
        Me.TxtNombresTrabajador.ReadOnly = True
        Me.TxtNombresTrabajador.Size = New System.Drawing.Size(451, 21)
        Me.TxtNombresTrabajador.TabIndex = 158
        Me.TxtNombresTrabajador.TabStop = False
        '
        'UltraLabel18
        '
        Appearance21.BackColor = System.Drawing.Color.Transparent
        Appearance21.TextHAlignAsString = "Center"
        Appearance21.TextVAlignAsString = "Middle"
        Me.UltraLabel18.Appearance = Appearance21
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Location = New System.Drawing.Point(43, 58)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(40, 14)
        Me.UltraLabel18.TabIndex = 160
        Me.UltraLabel18.Text = "Código"
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
        Me.lblmensaje.Location = New System.Drawing.Point(0, 190)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(764, 39)
        Me.lblmensaje.TabIndex = 168
        Me.lblmensaje.Text = "Generando Reporte..."
        Me.lblmensaje.Visible = False
        '
        'Source1
        '
        '
        'frmConsultaCombustible
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(763, 426)
        Me.Controls.Add(Me.lblmensaje)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.TxtCodigoTrabajador)
        Me.Controls.Add(Me.TxtNombresTrabajador)
        Me.Controls.Add(Me.UltraLabel18)
        Me.Controls.Add(Me.GridConsultaDetalle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpfin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpinicio)
        Me.Name = "frmConsultaCombustible"
        Me.Text = "frmConsultaCombustible"
        CType(Me.GridConsultaDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodigoTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNombresTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpfin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpinicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents GridConsultaDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtCodigoTrabajador As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents TxtNombresTrabajador As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
End Class
