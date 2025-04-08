<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmActivaEmpleados
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
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre", 0)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo", 1)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPago", 2, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo", 3)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sec", 4)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha_Creacion", 5)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion", 6)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codMotivo", 7)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1033)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.gbrevision = New System.Windows.Forms.GroupBox
        Me.txtPrueba = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnPrueba = New System.Windows.Forms.Button
        Me.pnlRegistrar = New System.Windows.Forms.Panel
        Me.pnlRegistrar2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboTipo2 = New System.Windows.Forms.ComboBox
        Me.cboMotivo2 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.dtpFecha2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPlacod2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.grdEmpleados = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cboTipo = New System.Windows.Forms.ComboBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.rbtMotivo = New System.Windows.Forms.RadioButton
        Me.rbtPlaCod = New System.Windows.Forms.RadioButton
        Me.cboMotivo = New System.Windows.Forms.ComboBox
        Me.rbtFecha = New System.Windows.Forms.RadioButton
        Me.dtpFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.TxtPlacod = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnAdicionar = New System.Windows.Forms.Button
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source4 = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbrevision.SuspendLayout()
        CType(Me.txtPrueba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRegistrar.SuspendLayout()
        Me.pnlRegistrar2.SuspendLayout()
        CType(Me.dtpFecha2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlacod2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPlacod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1088, 572)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.gbrevision)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1088, 572)
        Me.Panel1.TabIndex = 176
        '
        'gbrevision
        '
        Me.gbrevision.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbrevision.Controls.Add(Me.txtPrueba)
        Me.gbrevision.Controls.Add(Me.btnPrueba)
        Me.gbrevision.Controls.Add(Me.pnlRegistrar)
        Me.gbrevision.Controls.Add(Me.grdEmpleados)
        Me.gbrevision.Controls.Add(Me.Panel2)
        Me.gbrevision.Controls.Add(Me.btnAdicionar)
        Me.gbrevision.Location = New System.Drawing.Point(-1, 3)
        Me.gbrevision.Name = "gbrevision"
        Me.gbrevision.Size = New System.Drawing.Size(1092, 566)
        Me.gbrevision.TabIndex = 195
        Me.gbrevision.TabStop = False
        Me.gbrevision.Text = "Empleados"
        '
        'txtPrueba
        '
        Appearance55.Image = "Consultar.png"
        Appearance55.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.txtPrueba.Appearance = Appearance55
        Me.txtPrueba.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrueba.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPrueba.Location = New System.Drawing.Point(236, 523)
        Me.txtPrueba.MaxLength = 10
        Me.txtPrueba.Multiline = True
        Me.txtPrueba.Name = "txtPrueba"
        Me.txtPrueba.Size = New System.Drawing.Size(805, 37)
        Me.txtPrueba.TabIndex = 214
        Me.txtPrueba.Visible = False
        '
        'btnPrueba
        '
        Me.btnPrueba.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.btnPrueba.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrueba.Location = New System.Drawing.Point(39, 523)
        Me.btnPrueba.Name = "btnPrueba"
        Me.btnPrueba.Size = New System.Drawing.Size(191, 23)
        Me.btnPrueba.TabIndex = 213
        Me.btnPrueba.Text = "Prueba"
        Me.btnPrueba.UseVisualStyleBackColor = True
        Me.btnPrueba.Visible = False
        '
        'pnlRegistrar
        '
        Me.pnlRegistrar.BackColor = System.Drawing.Color.DimGray
        Me.pnlRegistrar.Controls.Add(Me.pnlRegistrar2)
        Me.pnlRegistrar.Location = New System.Drawing.Point(357, 109)
        Me.pnlRegistrar.Name = "pnlRegistrar"
        Me.pnlRegistrar.Size = New System.Drawing.Size(375, 391)
        Me.pnlRegistrar.TabIndex = 211
        Me.pnlRegistrar.Visible = False
        '
        'pnlRegistrar2
        '
        Me.pnlRegistrar2.BackColor = System.Drawing.Color.White
        Me.pnlRegistrar2.Controls.Add(Me.Label1)
        Me.pnlRegistrar2.Controls.Add(Me.cboTipo2)
        Me.pnlRegistrar2.Controls.Add(Me.cboMotivo2)
        Me.pnlRegistrar2.Controls.Add(Me.Label7)
        Me.pnlRegistrar2.Controls.Add(Me.txtObservaciones)
        Me.pnlRegistrar2.Controls.Add(Me.dtpFecha2)
        Me.pnlRegistrar2.Controls.Add(Me.Label6)
        Me.pnlRegistrar2.Controls.Add(Me.Button2)
        Me.pnlRegistrar2.Controls.Add(Me.btnGrabar)
        Me.pnlRegistrar2.Controls.Add(Me.Label5)
        Me.pnlRegistrar2.Controls.Add(Me.Label4)
        Me.pnlRegistrar2.Controls.Add(Me.txtPlacod2)
        Me.pnlRegistrar2.Controls.Add(Me.Label3)
        Me.pnlRegistrar2.Location = New System.Drawing.Point(4, 3)
        Me.pnlRegistrar2.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlRegistrar2.Name = "pnlRegistrar2"
        Me.pnlRegistrar2.Size = New System.Drawing.Size(368, 385)
        Me.pnlRegistrar2.TabIndex = 195
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 213
        Me.Label1.Text = "Tipo de Pago"
        '
        'cboTipo2
        '
        Me.cboTipo2.BackColor = System.Drawing.Color.White
        Me.cboTipo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo2.FormattingEnabled = True
        Me.cboTipo2.Location = New System.Drawing.Point(164, 53)
        Me.cboTipo2.Name = "cboTipo2"
        Me.cboTipo2.Size = New System.Drawing.Size(164, 21)
        Me.cboTipo2.TabIndex = 212
        '
        'cboMotivo2
        '
        Me.cboMotivo2.BackColor = System.Drawing.Color.White
        Me.cboMotivo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivo2.FormattingEnabled = True
        Me.cboMotivo2.Location = New System.Drawing.Point(42, 168)
        Me.cboMotivo2.Name = "cboMotivo2"
        Me.cboMotivo2.Size = New System.Drawing.Size(284, 21)
        Me.cboMotivo2.TabIndex = 208
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(43, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 208
        Me.Label7.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(46, 208)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtObservaciones.Size = New System.Drawing.Size(282, 119)
        Me.txtObservaciones.TabIndex = 209
        '
        'dtpFecha2
        '
        Me.dtpFecha2.DateTime = New Date(2011, 3, 10, 0, 0, 0, 0)
        Me.dtpFecha2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpFecha2.Location = New System.Drawing.Point(166, 80)
        Me.dtpFecha2.Name = "dtpFecha2"
        Me.dtpFecha2.Size = New System.Drawing.Size(162, 21)
        Me.dtpFecha2.TabIndex = 206
        Me.dtpFecha2.Value = New Date(2011, 3, 10, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Tai Le", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(82, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(203, 27)
        Me.Label6.TabIndex = 205
        Me.Label6.Text = "Registrar Empleado"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(64, 344)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 28)
        Me.Button2.TabIndex = 211
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(200, 344)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(101, 28)
        Me.btnGrabar.TabIndex = 210
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 202
        Me.Label5.Text = "Fecha de Pago"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Motivo"
        '
        'txtPlacod2
        '
        Appearance13.Image = "Consultar.png"
        Appearance13.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.txtPlacod2.Appearance = Appearance13
        Me.txtPlacod2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlacod2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtPlacod2.Location = New System.Drawing.Point(164, 116)
        Me.txtPlacod2.MaxLength = 10
        Me.txtPlacod2.Name = "txtPlacod2"
        Me.txtPlacod2.Size = New System.Drawing.Size(162, 21)
        Me.txtPlacod2.TabIndex = 207
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 202
        Me.Label3.Text = "Codigo Trabajador"
        '
        'grdEmpleados
        '
        Me.grdEmpleados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEmpleados.DataSource = Me.UltraDataSource1
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdEmpleados.DisplayLayout.Appearance = Appearance2
        Me.grdEmpleados.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.Header.Caption = "Nombre Completo"
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn1.Width = 275
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Width = 319
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "Fecha"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Width = 129
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.VisiblePosition = 0
        UltraGridColumn4.Width = 53
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 91
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 90
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 219
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 96
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8})
        Me.grdEmpleados.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.grdEmpleados.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdEmpleados.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdEmpleados.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.grdEmpleados.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.grdEmpleados.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.grdEmpleados.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.grdEmpleados.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.grdEmpleados.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.grdEmpleados.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.grdEmpleados.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.grdEmpleados.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.grdEmpleados.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.grdEmpleados.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.grdEmpleados.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.grdEmpleados.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdEmpleados.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.grdEmpleados.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdEmpleados.DisplayLayout.GroupByBox.Hidden = True
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdEmpleados.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.grdEmpleados.DisplayLayout.MaxColScrollRegions = 1
        Me.grdEmpleados.DisplayLayout.MaxRowScrollRegions = 1
        Me.grdEmpleados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdEmpleados.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdEmpleados.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Me.grdEmpleados.DisplayLayout.Override.CardAreaAppearance = Appearance6
        Appearance7.BorderColor = System.Drawing.Color.Silver
        Appearance7.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdEmpleados.DisplayLayout.Override.CellAppearance = Appearance7
        Me.grdEmpleados.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdEmpleados.DisplayLayout.Override.CellPadding = 0
        Me.grdEmpleados.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.grdEmpleados.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdEmpleados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.grdEmpleados.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance8.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.grdEmpleados.DisplayLayout.Override.FilterRowAppearance = Appearance8
        Me.grdEmpleados.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.grdEmpleados.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.grdEmpleados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.grdEmpleados.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.FontData.Name = "Arial Narrow"
        Appearance10.FontData.SizeInPoints = 10.0!
        Appearance10.TextHAlignAsString = "Left"
        Me.grdEmpleados.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.grdEmpleados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.grdEmpleados.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.grdEmpleados.DisplayLayout.Override.MinRowHeight = 24
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance11.TextVAlignAsString = "Middle"
        Me.grdEmpleados.DisplayLayout.Override.RowAppearance = Appearance11
        Me.grdEmpleados.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdEmpleados.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.grdEmpleados.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdEmpleados.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.grdEmpleados.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdEmpleados.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdEmpleados.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.grdEmpleados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdEmpleados.Location = New System.Drawing.Point(39, 109)
        Me.grdEmpleados.Name = "grdEmpleados"
        Me.grdEmpleados.Size = New System.Drawing.Size(1035, 345)
        Me.grdEmpleados.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.cboTipo)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Controls.Add(Me.rbtMotivo)
        Me.Panel2.Controls.Add(Me.rbtPlaCod)
        Me.Panel2.Controls.Add(Me.cboMotivo)
        Me.Panel2.Controls.Add(Me.rbtFecha)
        Me.Panel2.Controls.Add(Me.dtpFecha)
        Me.Panel2.Controls.Add(Me.TxtPlacod)
        Me.Panel2.Location = New System.Drawing.Point(39, 19)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1035, 84)
        Me.Panel2.TabIndex = 212
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(186, 7)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(269, 21)
        Me.cboTipo.TabIndex = 211
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(711, 10)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(102, 21)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'rbtMotivo
        '
        Me.rbtMotivo.AutoSize = True
        Me.rbtMotivo.Location = New System.Drawing.Point(39, 57)
        Me.rbtMotivo.Name = "rbtMotivo"
        Me.rbtMotivo.Size = New System.Drawing.Size(57, 17)
        Me.rbtMotivo.TabIndex = 2
        Me.rbtMotivo.Text = "Motivo"
        Me.rbtMotivo.UseVisualStyleBackColor = True
        '
        'rbtPlaCod
        '
        Me.rbtPlaCod.AutoSize = True
        Me.rbtPlaCod.Location = New System.Drawing.Point(39, 33)
        Me.rbtPlaCod.Name = "rbtPlaCod"
        Me.rbtPlaCod.Size = New System.Drawing.Size(112, 17)
        Me.rbtPlaCod.TabIndex = 1
        Me.rbtPlaCod.Text = "Codigo Trabajador"
        Me.rbtPlaCod.UseVisualStyleBackColor = True
        '
        'cboMotivo
        '
        Me.cboMotivo.BackColor = System.Drawing.Color.White
        Me.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivo.FormattingEnabled = True
        Me.cboMotivo.Location = New System.Drawing.Point(186, 32)
        Me.cboMotivo.Name = "cboMotivo"
        Me.cboMotivo.Size = New System.Drawing.Size(269, 21)
        Me.cboMotivo.TabIndex = 210
        Me.cboMotivo.Visible = False
        '
        'rbtFecha
        '
        Me.rbtFecha.AutoSize = True
        Me.rbtFecha.Checked = True
        Me.rbtFecha.Location = New System.Drawing.Point(39, 10)
        Me.rbtFecha.Name = "rbtFecha"
        Me.rbtFecha.Size = New System.Drawing.Size(55, 17)
        Me.rbtFecha.TabIndex = 0
        Me.rbtFecha.TabStop = True
        Me.rbtFecha.Text = "Fecha"
        Me.rbtFecha.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.DateTime = New Date(2011, 3, 10, 0, 0, 0, 0)
        Me.dtpFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpFecha.Location = New System.Drawing.Point(186, 33)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(162, 21)
        Me.dtpFecha.TabIndex = 207
        Me.dtpFecha.Value = New Date(2011, 3, 10, 0, 0, 0, 0)
        '
        'TxtPlacod
        '
        Appearance1.Image = "Consultar.png"
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.TxtPlacod.Appearance = Appearance1
        Me.TxtPlacod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPlacod.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtPlacod.Location = New System.Drawing.Point(186, 34)
        Me.TxtPlacod.MaxLength = 10
        Me.TxtPlacod.Name = "TxtPlacod"
        Me.TxtPlacod.Size = New System.Drawing.Size(162, 21)
        Me.TxtPlacod.TabIndex = 197
        Me.TxtPlacod.Visible = False
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.btnAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdicionar.Location = New System.Drawing.Point(39, 471)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(191, 37)
        Me.btnAdicionar.TabIndex = 6
        Me.btnAdicionar.Text = "Adicionar"
        Me.btnAdicionar.UseVisualStyleBackColor = True
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
        Me.Tab1.Size = New System.Drawing.Size(1092, 610)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance19.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance19
        Me.Tab1.TabIndex = 9
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
        UltraTab3.Text = "Activador de Empleados"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1088, 572)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmActivaEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1092, 610)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmActivaEmpleados"
        Me.Text = "FrmReporteCosteo"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.gbrevision.ResumeLayout(False)
        Me.gbrevision.PerformLayout()
        CType(Me.txtPrueba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRegistrar.ResumeLayout(False)
        Me.pnlRegistrar2.ResumeLayout(False)
        Me.pnlRegistrar2.PerformLayout()
        CType(Me.dtpFecha2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlacod2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPlacod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAdicionar As System.Windows.Forms.Button
    Friend WithEvents grdEmpleados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gbrevision As System.Windows.Forms.GroupBox
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents Source2 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Source3 As System.Windows.Forms.BindingSource
    Friend WithEvents Source4 As System.Windows.Forms.BindingSource
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents TxtPlacod As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents pnlRegistrar2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPlacod2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dtpFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dtpFecha2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents cboMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents cboMotivo2 As System.Windows.Forms.ComboBox
    Friend WithEvents pnlRegistrar As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbtMotivo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPlaCod As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFecha As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipo2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtPrueba As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnPrueba As System.Windows.Forms.Button
End Class
