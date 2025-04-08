<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarFactura
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgregarFactura))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO_COMPROB", 0)
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUMDOC", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IGV", 4)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_CLI", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RAZON", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VALORVTA", 7)
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VALOR", 8)
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUC", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHAREAL", 10)
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TIPO", 3, False)
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, "", "IGV", 4, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "IGV", 4, False)
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings3 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "VALORVTA", 7, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "VALORVTA", 7, False)
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings4 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "VALOR", 8, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "VALOR", 8, False)
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(695)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(475)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(492)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(901)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcodcontratista = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcontratista = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel19 = New Infragistics.Win.Misc.UltraLabel
        Me.gridImpuestos = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.txtserie = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtigv = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.dtfecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txtnumero = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btneliminar = New System.Windows.Forms.Button
        Me.btngrabar = New System.Windows.Forms.Button
        Me.txtvalorvta = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.txtidcontratista = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.txtruc = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpreal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.rdbcompra = New System.Windows.Forms.RadioButton
        Me.rdbventa = New System.Windows.Forms.RadioButton
        CType(Me.txtcodcontratista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcontratista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtserie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtigv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtfecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtvalorvta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidcontratista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpreal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraLabel7
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance1
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Location = New System.Drawing.Point(21, 46)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(59, 14)
        Me.UltraLabel7.TabIndex = 157
        Me.UltraLabel7.Text = "Contratista"
        '
        'txtcodcontratista
        '
        Appearance21.FontData.BoldAsString = "False"
        Appearance21.ForeColor = System.Drawing.Color.Black
        Appearance21.TextHAlignAsString = "Left"
        Appearance21.TextVAlignAsString = "Middle"
        Me.txtcodcontratista.Appearance = Appearance21
        Me.txtcodcontratista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodcontratista.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodcontratista.Location = New System.Drawing.Point(109, 43)
        Me.txtcodcontratista.MaxLength = 8
        Me.txtcodcontratista.Name = "txtcodcontratista"
        Me.txtcodcontratista.ReadOnly = True
        Me.txtcodcontratista.Size = New System.Drawing.Size(115, 21)
        Me.txtcodcontratista.TabIndex = 0
        Me.txtcodcontratista.TabStop = False
        '
        'txtcontratista
        '
        Appearance66.FontData.BoldAsString = "False"
        Appearance66.ForeColor = System.Drawing.Color.Black
        Appearance66.TextHAlignAsString = "Left"
        Appearance66.TextVAlignAsString = "Middle"
        Me.txtcontratista.Appearance = Appearance66
        Me.txtcontratista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontratista.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcontratista.Location = New System.Drawing.Point(230, 43)
        Me.txtcontratista.MaxLength = 8
        Me.txtcontratista.Name = "txtcontratista"
        Me.txtcontratista.ReadOnly = True
        Me.txtcontratista.Size = New System.Drawing.Size(277, 21)
        Me.txtcontratista.TabIndex = 0
        Me.txtcontratista.TabStop = False
        '
        'UltraLabel19
        '
        Me.UltraLabel19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance35.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance35.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance35.ForeColor = System.Drawing.Color.White
        Appearance35.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance35.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance35.TextHAlignAsString = "Left"
        Appearance35.TextVAlignAsString = "Middle"
        Me.UltraLabel19.Appearance = Appearance35
        Me.UltraLabel19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel19.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption
        Me.UltraLabel19.Location = New System.Drawing.Point(0, 2)
        Me.UltraLabel19.Name = "UltraLabel19"
        Me.UltraLabel19.Size = New System.Drawing.Size(740, 25)
        Me.UltraLabel19.TabIndex = 180
        Me.UltraLabel19.Text = "AGREGAR FACTURA"
        '
        'gridImpuestos
        '
        Me.gridImpuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance54.BackColor = System.Drawing.SystemColors.Window
        Appearance54.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridImpuestos.DisplayLayout.Appearance = Appearance54
        Me.gridImpuestos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance57.Image = CType(resources.GetObject("Appearance57.Image"), Object)
        Appearance57.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance57.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance57
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance40.TextHAlignAsString = "Left"
        UltraGridColumn2.CellAppearance = Appearance40
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn2.Header.Caption = "T.D."
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.MinWidth = 8
        UltraGridColumn2.Width = 18
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "N° DOCUMENTO"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 151
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.MaskInput = ""
        UltraGridColumn4.Width = 80
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.Caption = "OPERACION"
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 88
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance2
        UltraGridColumn6.Header.VisiblePosition = 8
        UltraGridColumn6.Width = 75
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.VisiblePosition = 4
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 99
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.VisiblePosition = 5
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 297
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance14
        UltraGridColumn9.Header.Caption = "VALOR VTA."
        UltraGridColumn9.Header.VisiblePosition = 7
        UltraGridColumn9.Width = 70
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance15
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 82
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 93
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn12.Width = 93
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12})
        Appearance11.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance11
        SummarySettings1.DisplayFormat = "Total"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance8
        Appearance10.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance10
        SummarySettings2.DisplayFormat = "{0}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance9
        Appearance17.TextHAlignAsString = "Right"
        SummarySettings3.Appearance = Appearance17
        SummarySettings3.DisplayFormat = "{0}"
        SummarySettings3.GroupBySummaryValueAppearance = Appearance18
        Appearance19.TextHAlignAsString = "Right"
        SummarySettings4.Appearance = Appearance19
        SummarySettings4.DisplayFormat = "{0}"
        SummarySettings4.GroupBySummaryValueAppearance = Appearance20
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2, SummarySettings3, SummarySettings4})
        UltraGridBand1.SummaryFooterCaption = ""
        Me.gridImpuestos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridImpuestos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridImpuestos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridImpuestos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridImpuestos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridImpuestos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridImpuestos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridImpuestos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridImpuestos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridImpuestos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridImpuestos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridImpuestos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridImpuestos.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance33.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.gridImpuestos.DisplayLayout.GroupByBox.Appearance = Appearance33
        Appearance34.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridImpuestos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance34
        Me.gridImpuestos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridImpuestos.DisplayLayout.GroupByBox.Hidden = True
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridImpuestos.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.gridImpuestos.DisplayLayout.MaxColScrollRegions = 1
        Me.gridImpuestos.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridImpuestos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridImpuestos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridImpuestos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Me.gridImpuestos.DisplayLayout.Override.CardAreaAppearance = Appearance47
        Appearance48.BorderColor = System.Drawing.Color.Silver
        Appearance48.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridImpuestos.DisplayLayout.Override.CellAppearance = Appearance48
        Me.gridImpuestos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridImpuestos.DisplayLayout.Override.CellPadding = 0
        Me.gridImpuestos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridImpuestos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridImpuestos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridImpuestos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance49.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance49.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridImpuestos.DisplayLayout.Override.FilterRowAppearance = Appearance49
        Me.gridImpuestos.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridImpuestos.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridImpuestos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance55.BackColor = System.Drawing.SystemColors.Control
        Appearance55.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance55.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance55.BorderColor = System.Drawing.SystemColors.Window
        Me.gridImpuestos.DisplayLayout.Override.GroupByRowAppearance = Appearance55
        Appearance56.FontData.Name = "Arial Narrow"
        Appearance56.FontData.SizeInPoints = 10.0!
        Appearance56.TextHAlignAsString = "Left"
        Me.gridImpuestos.DisplayLayout.Override.HeaderAppearance = Appearance56
        Me.gridImpuestos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridImpuestos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridImpuestos.DisplayLayout.Override.MinRowHeight = 24
        Appearance58.BackColor = System.Drawing.SystemColors.Window
        Appearance58.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance58.TextVAlignAsString = "Middle"
        Me.gridImpuestos.DisplayLayout.Override.RowAppearance = Appearance58
        Me.gridImpuestos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridImpuestos.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridImpuestos.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance60.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridImpuestos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance60
        Me.gridImpuestos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridImpuestos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridImpuestos.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridImpuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridImpuestos.Location = New System.Drawing.Point(21, 221)
        Me.gridImpuestos.Name = "gridImpuestos"
        Me.gridImpuestos.Size = New System.Drawing.Size(697, 274)
        Me.gridImpuestos.TabIndex = 5
        Me.gridImpuestos.Text = "UltraGrid1"
        '
        'txtserie
        '
        Appearance7.FontData.BoldAsString = "False"
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.TextHAlignAsString = "Left"
        Appearance7.TextVAlignAsString = "Middle"
        Me.txtserie.Appearance = Appearance7
        Me.txtserie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtserie.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtserie.Location = New System.Drawing.Point(109, 73)
        Me.txtserie.MaxLength = 3
        Me.txtserie.Name = "txtserie"
        Me.txtserie.Size = New System.Drawing.Size(35, 21)
        Me.txtserie.TabIndex = 1
        '
        'txtigv
        '
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.txtigv.Appearance = Appearance12
        Me.txtigv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtigv.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtigv.Location = New System.Drawing.Point(109, 184)
        Me.txtigv.MaxLength = 8
        Me.txtigv.Name = "txtigv"
        Me.txtigv.Size = New System.Drawing.Size(115, 21)
        Me.txtigv.TabIndex = 6
        '
        'UltraLabel1
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Center"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance6
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(21, 77)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(58, 14)
        Me.UltraLabel1.TabIndex = 192
        Me.UltraLabel1.Text = "N° Factura"
        '
        'UltraLabel2
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextHAlignAsString = "Center"
        Appearance13.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance13
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(21, 188)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(65, 14)
        Me.UltraLabel2.TabIndex = 193
        Me.UltraLabel2.Text = "IGV Factura"
        '
        'dtfecha
        '
        Me.dtfecha.AutoSize = False
        Me.dtfecha.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtfecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtfecha.Location = New System.Drawing.Point(109, 101)
        Me.dtfecha.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtfecha.Name = "dtfecha"
        Me.dtfecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtfecha.Size = New System.Drawing.Size(115, 21)
        Me.dtfecha.TabIndex = 3
        Me.dtfecha.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'UltraLabel3
        '
        Appearance24.BackColor = System.Drawing.Color.Transparent
        Appearance24.TextHAlignAsString = "Center"
        Appearance24.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance24
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(21, 105)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(80, 14)
        Me.UltraLabel3.TabIndex = 195
        Me.UltraLabel3.Text = "Fecha Proceso"
        '
        'txtnumero
        '
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.TextHAlignAsString = "Left"
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtnumero.Appearance = Appearance4
        Me.txtnumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumero.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtnumero.Location = New System.Drawing.Point(150, 73)
        Me.txtnumero.MaxLength = 10
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(74, 21)
        Me.txtnumero.TabIndex = 2
        '
        'btneliminar
        '
        Me.btneliminar.Location = New System.Drawing.Point(310, 184)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(74, 21)
        Me.btneliminar.TabIndex = 8
        Me.btneliminar.Text = "Eliminar"
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Location = New System.Drawing.Point(231, 184)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(74, 21)
        Me.btngrabar.TabIndex = 7
        Me.btngrabar.Text = "Grabar"
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'txtvalorvta
        '
        Appearance22.FontData.BoldAsString = "False"
        Appearance22.ForeColor = System.Drawing.Color.Black
        Appearance22.TextHAlignAsString = "Right"
        Appearance22.TextVAlignAsString = "Middle"
        Me.txtvalorvta.Appearance = Appearance22
        Me.txtvalorvta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtvalorvta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtvalorvta.Location = New System.Drawing.Point(109, 157)
        Me.txtvalorvta.MaxLength = 8
        Me.txtvalorvta.Name = "txtvalorvta"
        Me.txtvalorvta.Size = New System.Drawing.Size(115, 21)
        Me.txtvalorvta.TabIndex = 5
        '
        'UltraLabel4
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Appearance23.TextHAlignAsString = "Center"
        Appearance23.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance23
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(21, 157)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(54, 14)
        Me.UltraLabel4.TabIndex = 199
        Me.UltraLabel4.Text = "Valor Vta."
        '
        'txtidcontratista
        '
        Appearance3.FontData.BoldAsString = "False"
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.TextHAlignAsString = "Left"
        Appearance3.TextVAlignAsString = "Middle"
        Me.txtidcontratista.Appearance = Appearance3
        Me.txtidcontratista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidcontratista.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtidcontratista.Location = New System.Drawing.Point(513, 43)
        Me.txtidcontratista.MaxLength = 8
        Me.txtidcontratista.Name = "txtidcontratista"
        Me.txtidcontratista.ReadOnly = True
        Me.txtidcontratista.Size = New System.Drawing.Size(115, 21)
        Me.txtidcontratista.TabIndex = 200
        Me.txtidcontratista.TabStop = False
        Me.txtidcontratista.Visible = False
        '
        'UltraLabel5
        '
        Appearance63.BackColor = System.Drawing.Color.Transparent
        Appearance63.TextHAlignAsString = "Center"
        Appearance63.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance63
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(21, 133)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(27, 14)
        Me.UltraLabel5.TabIndex = 202
        Me.UltraLabel5.Text = "Ruc."
        '
        'txtruc
        '
        Appearance32.FontData.BoldAsString = "False"
        Appearance32.ForeColor = System.Drawing.Color.Black
        Appearance32.TextHAlignAsString = "Right"
        Appearance32.TextVAlignAsString = "Middle"
        Me.txtruc.Appearance = Appearance32
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtruc.Location = New System.Drawing.Point(109, 129)
        Me.txtruc.MaxLength = 11
        Me.txtruc.Name = "txtruc"
        Me.txtruc.Size = New System.Drawing.Size(115, 21)
        Me.txtruc.TabIndex = 4
        '
        'UltraLabel6
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Center"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance5
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(236, 105)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(77, 14)
        Me.UltraLabel6.TabIndex = 204
        Me.UltraLabel6.Text = "Fecha Factura"
        '
        'dtpreal
        '
        Me.dtpreal.AutoSize = False
        Me.dtpreal.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtpreal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpreal.Location = New System.Drawing.Point(324, 101)
        Me.dtpreal.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpreal.Name = "dtpreal"
        Me.dtpreal.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpreal.Size = New System.Drawing.Size(115, 21)
        Me.dtpreal.TabIndex = 203
        Me.dtpreal.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'rdbcompra
        '
        Me.rdbcompra.AutoSize = True
        Me.rdbcompra.Checked = True
        Me.rdbcompra.Location = New System.Drawing.Point(236, 77)
        Me.rdbcompra.Name = "rdbcompra"
        Me.rdbcompra.Size = New System.Drawing.Size(61, 17)
        Me.rdbcompra.TabIndex = 205
        Me.rdbcompra.TabStop = True
        Me.rdbcompra.Text = "Compra"
        Me.rdbcompra.UseVisualStyleBackColor = True
        '
        'rdbventa
        '
        Me.rdbventa.AutoSize = True
        Me.rdbventa.Location = New System.Drawing.Point(310, 78)
        Me.rdbventa.Name = "rdbventa"
        Me.rdbventa.Size = New System.Drawing.Size(53, 17)
        Me.rdbventa.TabIndex = 206
        Me.rdbventa.Text = "Venta"
        Me.rdbventa.UseVisualStyleBackColor = True
        '
        'frmAgregarFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(740, 507)
        Me.Controls.Add(Me.rdbventa)
        Me.Controls.Add(Me.rdbcompra)
        Me.Controls.Add(Me.UltraLabel6)
        Me.Controls.Add(Me.dtpreal)
        Me.Controls.Add(Me.UltraLabel5)
        Me.Controls.Add(Me.txtruc)
        Me.Controls.Add(Me.txtidcontratista)
        Me.Controls.Add(Me.UltraLabel4)
        Me.Controls.Add(Me.txtvalorvta)
        Me.Controls.Add(Me.btngrabar)
        Me.Controls.Add(Me.btneliminar)
        Me.Controls.Add(Me.txtnumero)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.dtfecha)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.txtigv)
        Me.Controls.Add(Me.txtserie)
        Me.Controls.Add(Me.gridImpuestos)
        Me.Controls.Add(Me.UltraLabel19)
        Me.Controls.Add(Me.UltraLabel7)
        Me.Controls.Add(Me.txtcodcontratista)
        Me.Controls.Add(Me.txtcontratista)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregarFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.txtcodcontratista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcontratista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtserie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtigv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtfecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtvalorvta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidcontratista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpreal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcodcontratista As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcontratista As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel19 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents gridImpuestos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtserie As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtigv As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtfecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtnumero As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents txtvalorvta As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtidcontratista As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtruc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpreal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents rdbcompra As System.Windows.Forms.RadioButton
    Friend WithEvents rdbventa As System.Windows.Forms.RadioButton
End Class
