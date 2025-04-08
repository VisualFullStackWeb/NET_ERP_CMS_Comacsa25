<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmValidaProduccion
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
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VALIDACION")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmValidaProduccion))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUM_DOC", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FEC_EMISION", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MODELO", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PRODPDC", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DESCRIP", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TURNO", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UNID", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANT_ING", 7)
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("estado_laboratorio", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("user_crea", 9, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fecha_crea", 10)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("observacion", 11)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("user_liberacion", 12)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fecha_liberacion", 13)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OBSERVACION_VTA", 14)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("USUARIO_VTA", 15)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FEC_VTA", 16)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(839)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(839)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1006)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1006)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.MOvta = New System.Windows.Forms.Button
        Me.chkliberado = New System.Windows.Forms.CheckBox
        Me.chktodos = New System.Windows.Forms.CheckBox
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.dtfin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.dtinicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.gridproducto = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtfin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtinicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridproducto, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(841, 487)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.MOvta)
        Me.Panel1.Controls.Add(Me.chkliberado)
        Me.Panel1.Controls.Add(Me.chktodos)
        Me.Panel1.Controls.Add(Me.UltraLabel1)
        Me.Panel1.Controls.Add(Me.dtfin)
        Me.Panel1.Controls.Add(Me.UltraLabel5)
        Me.Panel1.Controls.Add(Me.dtinicio)
        Me.Panel1.Controls.Add(Me.gridproducto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(841, 487)
        Me.Panel1.TabIndex = 176
        '
        'MOvta
        '
        Me.MOvta.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.MOvta.Location = New System.Drawing.Point(465, 35)
        Me.MOvta.Name = "MOvta"
        Me.MOvta.Size = New System.Drawing.Size(168, 23)
        Me.MOvta.TabIndex = 166
        Me.MOvta.Text = "Mostrar/Ocultar VTA"
        Me.MOvta.UseVisualStyleBackColor = True
        '
        'chkliberado
        '
        Me.chkliberado.AutoSize = True
        Me.chkliberado.Location = New System.Drawing.Point(339, 35)
        Me.chkliberado.Name = "chkliberado"
        Me.chkliberado.Size = New System.Drawing.Size(119, 17)
        Me.chkliberado.TabIndex = 165
        Me.chkliberado.Text = "Productos liberados"
        Me.chkliberado.UseVisualStyleBackColor = True
        '
        'chktodos
        '
        Me.chktodos.AutoSize = True
        Me.chktodos.Location = New System.Drawing.Point(245, 35)
        Me.chktodos.Name = "chktodos"
        Me.chktodos.Size = New System.Drawing.Size(88, 17)
        Me.chktodos.TabIndex = 164
        Me.chktodos.Text = "Marcar todos"
        Me.chktodos.UseVisualStyleBackColor = True
        '
        'UltraLabel1
        '
        Appearance39.BackColor = System.Drawing.Color.Transparent
        Appearance39.TextHAlignAsString = "Center"
        Appearance39.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance39
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(128, 13)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(34, 14)
        Me.UltraLabel1.TabIndex = 163
        Me.UltraLabel1.Text = "Hasta"
        '
        'dtfin
        '
        Me.dtfin.AutoSize = False
        Me.dtfin.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtfin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtfin.Location = New System.Drawing.Point(128, 33)
        Me.dtfin.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtfin.Name = "dtfin"
        Me.dtfin.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtfin.Size = New System.Drawing.Size(111, 18)
        Me.dtfin.TabIndex = 162
        Me.dtfin.TabStop = False
        Me.dtfin.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'UltraLabel5
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance1
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(11, 13)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(37, 14)
        Me.UltraLabel5.TabIndex = 161
        Me.UltraLabel5.Text = "Desde"
        '
        'dtinicio
        '
        Me.dtinicio.AutoSize = False
        Me.dtinicio.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtinicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtinicio.Location = New System.Drawing.Point(11, 33)
        Me.dtinicio.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtinicio.Name = "dtinicio"
        Me.dtinicio.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtinicio.Size = New System.Drawing.Size(111, 18)
        Me.dtinicio.TabIndex = 160
        Me.dtinicio.TabStop = False
        Me.dtinicio.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'gridproducto
        '
        Me.gridproducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridproducto.DisplayLayout.Appearance = Appearance25
        Me.gridproducto.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance22.Image = CType(resources.GetObject("Appearance22.Image"), Object)
        Appearance22.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance22.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance22
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 25
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.Caption = "BILLETE"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.Width = 62
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "FEC. E."
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.Width = 64
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "MOLINO"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn4.Width = 41
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.Caption = "CODIGO"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn5.Width = 22
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.Caption = "PRODUCTO"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn6.Width = 54
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn7.Width = 9
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn8.Width = 10
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance5
        UltraGridColumn9.Header.Caption = "CANTIDAD"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn9.Width = 30
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.Caption = "ESTADO LAB"
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 52
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.Caption = "USUARIO CREA."
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Width = 57
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.Header.Caption = "FEC. CREACION"
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Width = 38
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.Caption = "OBS. LIB."
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Width = 78
        UltraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn14.Header.Caption = "USER LIB."
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.Width = 41
        UltraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.Header.Caption = "FEC. LIB."
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Width = 36
        UltraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn16.Header.Caption = "OBS. VTA."
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.Width = 74
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.Header.Caption = "USUARIO VTA"
        UltraGridColumn17.Header.VisiblePosition = 16
        UltraGridColumn17.Width = 62
        UltraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn18.Header.Caption = "FEC. VTA."
        UltraGridColumn18.Header.VisiblePosition = 17
        UltraGridColumn18.Width = 46
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18})
        Me.gridproducto.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridproducto.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridproducto.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridproducto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridproducto.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance27.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance27.BorderColor = System.Drawing.SystemColors.Window
        Me.gridproducto.DisplayLayout.GroupByBox.Appearance = Appearance27
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridproducto.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance11
        Me.gridproducto.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridproducto.DisplayLayout.GroupByBox.Hidden = True
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance19.BackColor2 = System.Drawing.SystemColors.Control
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridproducto.DisplayLayout.GroupByBox.PromptAppearance = Appearance19
        Me.gridproducto.DisplayLayout.MaxColScrollRegions = 1
        Me.gridproducto.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridproducto.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridproducto.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridproducto.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Me.gridproducto.DisplayLayout.Override.CardAreaAppearance = Appearance34
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Appearance35.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridproducto.DisplayLayout.Override.CellAppearance = Appearance35
        Me.gridproducto.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridproducto.DisplayLayout.Override.CellPadding = 0
        Me.gridproducto.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridproducto.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridproducto.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridproducto.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance36.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance36.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridproducto.DisplayLayout.Override.FilterRowAppearance = Appearance36
        Me.gridproducto.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridproducto.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridproducto.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance37.BackColor = System.Drawing.SystemColors.Control
        Appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance37.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance37.BorderColor = System.Drawing.SystemColors.Window
        Me.gridproducto.DisplayLayout.Override.GroupByRowAppearance = Appearance37
        Appearance2.FontData.Name = "Arial Narrow"
        Appearance2.FontData.SizeInPoints = 10.0!
        Appearance2.TextHAlignAsString = "Left"
        Me.gridproducto.DisplayLayout.Override.HeaderAppearance = Appearance2
        Me.gridproducto.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridproducto.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridproducto.DisplayLayout.Override.MinRowHeight = 24
        Appearance40.BackColor = System.Drawing.SystemColors.Window
        Appearance40.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance40.TextVAlignAsString = "Middle"
        Me.gridproducto.DisplayLayout.Override.RowAppearance = Appearance40
        Me.gridproducto.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridproducto.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridproducto.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance41.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridproducto.DisplayLayout.Override.TemplateAddRowAppearance = Appearance41
        Me.gridproducto.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridproducto.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridproducto.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridproducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridproducto.Location = New System.Drawing.Point(0, 68)
        Me.gridproducto.Name = "gridproducto"
        Me.gridproducto.Size = New System.Drawing.Size(841, 419)
        Me.gridproducto.TabIndex = 159
        Me.gridproducto.Text = "UltraGrid1"
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
        Me.Tab1.Size = New System.Drawing.Size(845, 525)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance3
        Me.Tab1.TabIndex = 14
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance4.Cursor = System.Windows.Forms.Cursors.Default
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.Name = "Arial Narrow"
        Appearance4.FontData.SizeInPoints = 16.0!
        UltraTab3.ActiveAppearance = Appearance4
        Appearance43.FontData.Name = "Arial Narrow"
        Appearance43.FontData.SizeInPoints = 10.0!
        UltraTab3.Appearance = Appearance43
        UltraTab3.Key = "T01"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "VALIDACION DE PRODUCTOS TERMINADOS"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(841, 487)
        '
        'Source1
        '
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
        Me.lblmensaje.Location = New System.Drawing.Point(2, 243)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(841, 39)
        Me.lblmensaje.TabIndex = 159
        Me.lblmensaje.Text = "Procesando Datos..."
        Me.lblmensaje.Visible = False
        '
        'FrmValidaProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 525)
        Me.Controls.Add(Me.lblmensaje)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmValidaProduccion"
        Me.Text = "FrmValidaProduccion"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtfin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtinicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridproducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gridproducto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents dtinicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtfin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents chktodos As System.Windows.Forms.CheckBox
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkliberado As System.Windows.Forms.CheckBox
    Friend WithEvents MOvta As System.Windows.Forms.Button
End Class
