<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExamenesMedicos
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
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExamenesMedicos))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROV", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUC", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODCANTERA", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTERA", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHADEPOSITO", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUMSOLICITUD", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FORMA", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NOPERACION", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DESCRIPCION", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTMINERAL", 9)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DEBE", 10)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HABER", 11)
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SALDO", 12)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDCONTRATISTA", 13)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SUPERVISOR", 14)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONTADOR", 15)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SALDOINI", 16)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1154)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1006)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.TabMaestroEntregas = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.GridAnticipo = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.txtidcontratista = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcantera = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcodcantera = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcodcontratista = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcontratista = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel17 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpHasta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpDesde = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        CType(Me.TabMaestroEntregas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabMaestroEntregas.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.GridAnticipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidcontratista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcantera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodcantera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodcontratista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcontratista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMaestroEntregas
        '
        Appearance98.FontData.BoldAsString = "True"
        Appearance98.FontData.Name = "Arial Narrow"
        Appearance98.FontData.SizeInPoints = 16.0!
        Me.TabMaestroEntregas.ActiveTabAppearance = Appearance98
        Appearance68.FontData.Name = "Arial Narrow"
        Appearance68.FontData.SizeInPoints = 10.0!
        Me.TabMaestroEntregas.Appearance = Appearance68
        Me.TabMaestroEntregas.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.TabMaestroEntregas.Controls.Add(Me.UltraTabPageControl1)
        Me.TabMaestroEntregas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMaestroEntregas.Location = New System.Drawing.Point(0, 0)
        Me.TabMaestroEntregas.MinTabWidth = 0
        Me.TabMaestroEntregas.Name = "TabMaestroEntregas"
        Appearance52.FontData.SizeInPoints = 12.0!
        Me.TabMaestroEntregas.SelectedTabAppearance = Appearance52
        Me.TabMaestroEntregas.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.TabMaestroEntregas.Size = New System.Drawing.Size(805, 382)
        Me.TabMaestroEntregas.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance51.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TabMaestroEntregas.TabHeaderAreaAppearance = Appearance51
        Me.TabMaestroEntregas.TabIndex = 14
        Me.TabMaestroEntregas.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab2.Key = "Lista"
        UltraTab2.TabPage = Me.UltraTabPageControl1
        UltraTab2.Text = "Reporte de control de exámenes médicos"
        Me.TabMaestroEntregas.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2})
        Me.TabMaestroEntregas.TabStop = False
        Me.TabMaestroEntregas.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(801, 344)
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.lblmensaje)
        Me.UltraTabPageControl1.Controls.Add(Me.GridAnticipo)
        Me.UltraTabPageControl1.Controls.Add(Me.txtidcontratista)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel11)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcantera)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcodcantera)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel7)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcodcontratista)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcontratista)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel17)
        Me.UltraTabPageControl1.Controls.Add(Me.dtpHasta)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel8)
        Me.UltraTabPageControl1.Controls.Add(Me.dtpDesde)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(801, 344)
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
        Me.lblmensaje.Location = New System.Drawing.Point(-1, 147)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(805, 39)
        Me.lblmensaje.TabIndex = 169
        Me.lblmensaje.Text = "Buscando Datos en Sunat..."
        Me.lblmensaje.Visible = False
        '
        'GridAnticipo
        '
        Me.GridAnticipo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridAnticipo.DisplayLayout.Appearance = Appearance11
        Me.GridAnticipo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
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
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.Width = 88
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.Width = 36
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn4.Width = 40
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn5.Width = 27
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.Caption = "FECHA DEPOSITO"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn6.Width = 101
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.Caption = "N° SOLICITUD"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn7.Width = 70
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.Caption = "F. DESEMBOLSO"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn8.Width = 86
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.Caption = "N° OPERACION"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn9.Width = 91
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn10.Width = 111
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance1.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance1
        UltraGridColumn11.Header.Caption = "CANT. MINERAL"
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn11.Width = 52
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance2
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn12.Width = 42
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance3
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn13.Width = 45
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance4
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn14.Width = 127
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 95
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn16.Width = 64
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.Header.VisiblePosition = 16
        UltraGridColumn17.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn17.Width = 72
        UltraGridColumn18.Header.VisiblePosition = 17
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 95
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18})
        Me.GridAnticipo.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridAnticipo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridAnticipo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridAnticipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.GridAnticipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.GridAnticipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.GridAnticipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.GridAnticipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.GridAnticipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.GridAnticipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.GridAnticipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.GridAnticipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.GridAnticipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.GridAnticipo.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance19.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance19.BorderColor = System.Drawing.SystemColors.Window
        Me.GridAnticipo.DisplayLayout.GroupByBox.Appearance = Appearance19
        Appearance82.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridAnticipo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance82
        Me.GridAnticipo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridAnticipo.DisplayLayout.GroupByBox.Hidden = True
        Appearance22.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance22.BackColor2 = System.Drawing.SystemColors.Control
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance22.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridAnticipo.DisplayLayout.GroupByBox.PromptAppearance = Appearance22
        Me.GridAnticipo.DisplayLayout.MaxColScrollRegions = 1
        Me.GridAnticipo.DisplayLayout.MaxRowScrollRegions = 1
        Me.GridAnticipo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridAnticipo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridAnticipo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Me.GridAnticipo.DisplayLayout.Override.CardAreaAppearance = Appearance23
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridAnticipo.DisplayLayout.Override.CellAppearance = Appearance24
        Me.GridAnticipo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridAnticipo.DisplayLayout.Override.CellPadding = 0
        Me.GridAnticipo.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.GridAnticipo.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.GridAnticipo.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.GridAnticipo.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance38.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance38.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GridAnticipo.DisplayLayout.Override.FilterRowAppearance = Appearance38
        Me.GridAnticipo.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.GridAnticipo.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.GridAnticipo.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance28.BackColor = System.Drawing.SystemColors.Control
        Appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance28.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.GridAnticipo.DisplayLayout.Override.GroupByRowAppearance = Appearance28
        Appearance29.FontData.Name = "Arial Narrow"
        Appearance29.FontData.SizeInPoints = 10.0!
        Appearance29.TextHAlignAsString = "Left"
        Me.GridAnticipo.DisplayLayout.Override.HeaderAppearance = Appearance29
        Me.GridAnticipo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.GridAnticipo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.GridAnticipo.DisplayLayout.Override.MinRowHeight = 24
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance30.TextVAlignAsString = "Middle"
        Me.GridAnticipo.DisplayLayout.Override.RowAppearance = Appearance30
        Me.GridAnticipo.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.GridAnticipo.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.GridAnticipo.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridAnticipo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance31
        Me.GridAnticipo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridAnticipo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridAnticipo.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.GridAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridAnticipo.Location = New System.Drawing.Point(0, 108)
        Me.GridAnticipo.Name = "GridAnticipo"
        Me.GridAnticipo.Size = New System.Drawing.Size(801, 236)
        Me.GridAnticipo.TabIndex = 158
        Me.GridAnticipo.Text = "UltraGrid1"
        Me.GridAnticipo.Visible = False
        '
        'txtidcontratista
        '
        Appearance65.FontData.BoldAsString = "False"
        Appearance65.ForeColor = System.Drawing.Color.Black
        Appearance65.TextHAlignAsString = "Left"
        Appearance65.TextVAlignAsString = "Middle"
        Me.txtidcontratista.Appearance = Appearance65
        Me.txtidcontratista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidcontratista.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtidcontratista.Location = New System.Drawing.Point(561, 72)
        Me.txtidcontratista.MaxLength = 8
        Me.txtidcontratista.Name = "txtidcontratista"
        Me.txtidcontratista.ReadOnly = True
        Me.txtidcontratista.Size = New System.Drawing.Size(69, 21)
        Me.txtidcontratista.TabIndex = 221
        Me.txtidcontratista.TabStop = False
        Me.txtidcontratista.Visible = False
        '
        'UltraLabel11
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Center"
        Appearance8.TextVAlignAsString = "Middle"
        Me.UltraLabel11.Appearance = Appearance8
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Location = New System.Drawing.Point(508, 112)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(44, 14)
        Me.UltraLabel11.TabIndex = 172
        Me.UltraLabel11.Text = "Cantera"
        Me.UltraLabel11.Visible = False
        '
        'txtcantera
        '
        Appearance46.FontData.BoldAsString = "False"
        Appearance46.ForeColor = System.Drawing.Color.Black
        Appearance46.TextHAlignAsString = "Left"
        Appearance46.TextVAlignAsString = "Middle"
        Me.txtcantera.Appearance = Appearance46
        Me.txtcantera.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcantera.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcantera.Location = New System.Drawing.Point(689, 108)
        Me.txtcantera.MaxLength = 8
        Me.txtcantera.Name = "txtcantera"
        Me.txtcantera.ReadOnly = True
        Me.txtcantera.Size = New System.Drawing.Size(73, 21)
        Me.txtcantera.TabIndex = 171
        Me.txtcantera.TabStop = False
        Me.txtcantera.Visible = False
        '
        'txtcodcantera
        '
        Appearance7.FontData.BoldAsString = "False"
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.TextHAlignAsString = "Left"
        Appearance7.TextVAlignAsString = "Middle"
        Me.txtcodcantera.Appearance = Appearance7
        Me.txtcodcantera.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodcantera.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodcantera.Location = New System.Drawing.Point(561, 108)
        Me.txtcodcantera.MaxLength = 8
        Me.txtcodcantera.Name = "txtcodcantera"
        Me.txtcodcantera.ReadOnly = True
        Me.txtcodcantera.Size = New System.Drawing.Size(122, 21)
        Me.txtcodcantera.TabIndex = 170
        Me.txtcodcantera.TabStop = False
        Me.txtcodcantera.Visible = False
        '
        'UltraLabel7
        '
        Appearance63.BackColor = System.Drawing.Color.Transparent
        Appearance63.TextHAlignAsString = "Center"
        Appearance63.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance63
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Location = New System.Drawing.Point(29, 43)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(59, 14)
        Me.UltraLabel7.TabIndex = 169
        Me.UltraLabel7.Text = "Contratista"
        '
        'txtcodcontratista
        '
        Appearance32.FontData.BoldAsString = "False"
        Appearance32.ForeColor = System.Drawing.Color.Black
        Appearance32.TextHAlignAsString = "Left"
        Appearance32.TextVAlignAsString = "Middle"
        Me.txtcodcontratista.Appearance = Appearance32
        Me.txtcodcontratista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodcontratista.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodcontratista.Location = New System.Drawing.Point(97, 39)
        Me.txtcodcontratista.MaxLength = 8
        Me.txtcodcontratista.Name = "txtcodcontratista"
        Me.txtcodcontratista.ReadOnly = True
        Me.txtcodcontratista.Size = New System.Drawing.Size(122, 21)
        Me.txtcodcontratista.TabIndex = 167
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
        Me.txtcontratista.Location = New System.Drawing.Point(225, 39)
        Me.txtcontratista.MaxLength = 8
        Me.txtcontratista.Name = "txtcontratista"
        Me.txtcontratista.ReadOnly = True
        Me.txtcontratista.Size = New System.Drawing.Size(330, 21)
        Me.txtcontratista.TabIndex = 168
        Me.txtcontratista.TabStop = False
        '
        'UltraLabel17
        '
        Appearance39.BackColor = System.Drawing.Color.Transparent
        Appearance39.TextHAlignAsString = "Center"
        Appearance39.TextVAlignAsString = "Middle"
        Me.UltraLabel17.Appearance = Appearance39
        Me.UltraLabel17.AutoSize = True
        Me.UltraLabel17.Location = New System.Drawing.Point(225, 75)
        Me.UltraLabel17.Name = "UltraLabel17"
        Me.UltraLabel17.Size = New System.Drawing.Size(34, 14)
        Me.UltraLabel17.TabIndex = 166
        Me.UltraLabel17.Text = "Hasta"
        '
        'dtpHasta
        '
        Me.dtpHasta.AutoSize = False
        Me.dtpHasta.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpHasta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpHasta.Location = New System.Drawing.Point(265, 73)
        Me.dtpHasta.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpHasta.Size = New System.Drawing.Size(122, 18)
        Me.dtpHasta.TabIndex = 165
        Me.dtpHasta.TabStop = False
        Me.dtpHasta.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'UltraLabel8
        '
        Appearance58.BackColor = System.Drawing.Color.Transparent
        Appearance58.TextHAlignAsString = "Center"
        Appearance58.TextVAlignAsString = "Middle"
        Me.UltraLabel8.Appearance = Appearance58
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Location = New System.Drawing.Point(51, 74)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(37, 14)
        Me.UltraLabel8.TabIndex = 164
        Me.UltraLabel8.Text = "Desde"
        '
        'dtpDesde
        '
        Me.dtpDesde.AutoSize = False
        Me.dtpDesde.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpDesde.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpDesde.Location = New System.Drawing.Point(97, 73)
        Me.dtpDesde.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpDesde.Size = New System.Drawing.Size(122, 18)
        Me.dtpDesde.TabIndex = 163
        Me.dtpDesde.TabStop = False
        Me.dtpDesde.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'frmExamenesMedicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 382)
        Me.Controls.Add(Me.TabMaestroEntregas)
        Me.Name = "frmExamenesMedicos"
        Me.Text = "frmExamenesMedicos"
        CType(Me.TabMaestroEntregas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabMaestroEntregas.ResumeLayout(False)
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.GridAnticipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidcontratista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcantera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodcantera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodcontratista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcontratista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMaestroEntregas As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GridAnticipo As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtidcontratista As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcantera As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcodcantera As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcodcontratista As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcontratista As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel17 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpHasta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpDesde As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
End Class
