<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresoAjuste
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
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance110 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance113 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroDocumento")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoTipoMovimiento")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoMovimiento")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoAlmacen")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Almacen")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroMovimientoInterno")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoMotivo")
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance104 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroDocumento")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoTipoMovimiento")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoMovimiento")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoAlmacen")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Almacen")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Estado")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroMovimientoInterno")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoMotivo")
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance143 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIngresoAjuste))
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UM")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoProducto")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance157 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance158 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance159 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance160 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descripcion")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UM")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoProducto")
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo", 0)
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 1)
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Cia1 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.DgvIngresoAjuste = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.DtFechaConsulta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.TxtNumeroDocumento = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.GrpAnulacion = New Infragistics.Win.Misc.UltraGroupBox
        Me.CmbAnulacion = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Chk_Total = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.BtCancelar = New Infragistics.Win.Misc.UltraButton
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.Cia2 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.dtFeStringegistro = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.dgvDetalleIngresoAjuste = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraLabel29 = New Infragistics.Win.Misc.UltraLabel
        Me.TxtNumeroMovimiento = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.GrpDatosMovimiento = New Infragistics.Win.Misc.UltraGroupBox
        Me.CboTipoMovimiento = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.CboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.GrpOC = New Infragistics.Win.Misc.UltraGroupBox
        Me.CboMotivo = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel
        Me.LblEstado = New Infragistics.Win.Misc.UltraLabel
        Me.TabIngresoAjuste = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.btnCancelar = New Infragistics.Win.Misc.UltraButton
        Me.CboAnulacion = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel36 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.Cia1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvIngresoAjuste, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtFechaConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumeroDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.GrpAnulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpAnulacion.SuspendLayout()
        CType(Me.CmbAnulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cia2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFeStringegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalleIngresoAjuste, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumeroMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrpDatosMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDatosMovimiento.SuspendLayout()
        CType(Me.CboTipoMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrpOC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpOC.SuspendLayout()
        CType(Me.CboMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabIngresoAjuste, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabIngresoAjuste.SuspendLayout()
        CType(Me.CboAnulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Cia1)
        Me.UltraTabPageControl1.Controls.Add(Me.DgvIngresoAjuste)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl1.Controls.Add(Me.DtFechaConsulta)
        Me.UltraTabPageControl1.Controls.Add(Me.TxtNumeroDocumento)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel14)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(812, 464)
        '
        'Cia1
        '
        Me.Cia1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance102.BackColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Appearance = Appearance102
        Me.Cia1.DisplayLayout.InterBandSpacing = 18
        Appearance109.BackColor = System.Drawing.Color.Transparent
        Me.Cia1.DisplayLayout.Override.CardAreaAppearance = Appearance109
        Appearance110.FontData.BoldAsString = "True"
        Appearance110.FontData.SizeInPoints = 9.0!
        Appearance110.ForeColor = System.Drawing.Color.Navy
        Me.Cia1.DisplayLayout.Override.CellAppearance = Appearance110
        Appearance111.BackColor = System.Drawing.Color.Navy
        Appearance111.FontData.BoldAsString = "True"
        Appearance111.FontData.ItalicAsString = "True"
        Appearance111.FontData.SizeInPoints = 10.0!
        Appearance111.ForeColor = System.Drawing.Color.White
        Appearance111.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.Cia1.DisplayLayout.Override.HeaderAppearance = Appearance111
        Appearance113.BackColor = System.Drawing.Color.Navy
        Appearance113.BorderColor = System.Drawing.Color.White
        Appearance113.ForeColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Override.RowSelectorAppearance = Appearance113
        Me.Cia1.DisplayLayout.Override.RowSpacingAfter = 4
        Me.Cia1.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance114.BackColor = System.Drawing.Color.Navy
        Appearance114.ForeColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Override.SelectedRowAppearance = Appearance114
        Me.Cia1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.Cia1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.Cia1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cia1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cia1.Location = New System.Drawing.Point(60, 10)
        Me.Cia1.Name = "Cia1"
        Me.Cia1.ReadOnly = True
        Me.Cia1.Size = New System.Drawing.Size(270, 22)
        Me.Cia1.TabIndex = 91
        '
        'DgvIngresoAjuste
        '
        Me.DgvIngresoAjuste.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvIngresoAjuste.DataSource = Me.UltraDataSource1
        Appearance51.BackColor = System.Drawing.Color.White
        Me.DgvIngresoAjuste.DisplayLayout.Appearance = Appearance51
        Me.DgvIngresoAjuste.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.ColHeaderLines = 2
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.FontData.SizeInPoints = 8.0!
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        UltraGridColumn1.CellAppearance = Appearance2
        Appearance3.FontData.BoldAsString = "False"
        Appearance3.FontData.SizeInPoints = 8.0!
        UltraGridColumn1.Header.Appearance = Appearance3
        UltraGridColumn1.Header.Caption = "Nro" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Documento"
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.MaxWidth = 100
        UltraGridColumn1.MinWidth = 100
        UltraGridColumn1.Width = 100
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.FontData.SizeInPoints = 8.0!
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        UltraGridColumn2.CellAppearance = Appearance4
        Appearance5.FontData.BoldAsString = "False"
        Appearance5.FontData.SizeInPoints = 8.0!
        UltraGridColumn2.Header.Appearance = Appearance5
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 45
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.FontData.BoldAsString = "False"
        Appearance6.FontData.SizeInPoints = 8.0!
        Appearance6.TextHAlignAsString = "Center"
        Appearance6.TextVAlignAsString = "Middle"
        UltraGridColumn3.CellAppearance = Appearance6
        Appearance7.FontData.BoldAsString = "False"
        Appearance7.FontData.SizeInPoints = 8.0!
        UltraGridColumn3.Header.Appearance = Appearance7
        UltraGridColumn3.Header.Caption = "Tipo de Movimiento"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.MaxWidth = 240
        UltraGridColumn3.MinWidth = 240
        UltraGridColumn3.Width = 240
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance8.FontData.BoldAsString = "False"
        Appearance8.FontData.SizeInPoints = 8.0!
        UltraGridColumn4.Header.Appearance = Appearance8
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 60
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.FontData.BoldAsString = "False"
        Appearance9.FontData.SizeInPoints = 8.0!
        Appearance9.TextHAlignAsString = "Center"
        Appearance9.TextVAlignAsString = "Middle"
        UltraGridColumn5.CellAppearance = Appearance9
        Appearance10.FontData.BoldAsString = "False"
        Appearance10.FontData.SizeInPoints = 8.0!
        UltraGridColumn5.Header.Appearance = Appearance10
        UltraGridColumn5.Header.Caption = "Almacén"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.MaxWidth = 240
        UltraGridColumn5.MinWidth = 240
        UltraGridColumn5.Width = 240
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance11.FontData.BoldAsString = "False"
        Appearance11.FontData.SizeInPoints = 8.0!
        Appearance11.TextHAlignAsString = "Center"
        Appearance11.TextVAlignAsString = "Middle"
        UltraGridColumn6.CellAppearance = Appearance11
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.FontData.SizeInPoints = 8.0!
        UltraGridColumn6.Header.Appearance = Appearance12
        UltraGridColumn6.Header.VisiblePosition = 0
        UltraGridColumn6.MaxWidth = 85
        UltraGridColumn6.MinWidth = 85
        UltraGridColumn6.Width = 85
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.FontData.BoldAsString = "False"
        Appearance13.FontData.SizeInPoints = 8.0!
        Appearance13.TextHAlignAsString = "Center"
        Appearance13.TextVAlignAsString = "Middle"
        UltraGridColumn7.CellAppearance = Appearance13
        Appearance14.FontData.BoldAsString = "False"
        Appearance14.FontData.SizeInPoints = 8.0!
        UltraGridColumn7.Header.Appearance = Appearance14
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.MinWidth = 84
        UltraGridColumn7.Width = 89
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 8
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 8
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9})
        Me.DgvIngresoAjuste.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.DgvIngresoAjuste.DisplayLayout.InterBandSpacing = 18
        Me.DgvIngresoAjuste.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.DgvIngresoAjuste.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance103.BackColor = System.Drawing.Color.Transparent
        Me.DgvIngresoAjuste.DisplayLayout.Override.CardAreaAppearance = Appearance103
        Appearance104.FontData.BoldAsString = "True"
        Appearance104.FontData.SizeInPoints = 9.0!
        Appearance104.ForeColor = System.Drawing.Color.Navy
        Me.DgvIngresoAjuste.DisplayLayout.Override.CellAppearance = Appearance104
        Me.DgvIngresoAjuste.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance105.BackColor = System.Drawing.Color.Navy
        Appearance105.FontData.BoldAsString = "True"
        Appearance105.FontData.ItalicAsString = "False"
        Appearance105.FontData.SizeInPoints = 10.0!
        Appearance105.ForeColor = System.Drawing.Color.White
        Appearance105.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.DgvIngresoAjuste.DisplayLayout.Override.HeaderAppearance = Appearance105
        Appearance106.TextHAlignAsString = "Center"
        Appearance106.TextVAlignAsString = "Middle"
        Me.DgvIngresoAjuste.DisplayLayout.Override.RowPreviewAppearance = Appearance106
        Appearance107.BackColor = System.Drawing.Color.Navy
        Appearance107.BorderColor = System.Drawing.Color.White
        Appearance107.FontData.BoldAsString = "True"
        Appearance107.ForeColor = System.Drawing.Color.White
        Appearance107.TextHAlignAsString = "Center"
        Appearance107.TextVAlignAsString = "Middle"
        Me.DgvIngresoAjuste.DisplayLayout.Override.RowSelectorAppearance = Appearance107
        Me.DgvIngresoAjuste.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.DgvIngresoAjuste.DisplayLayout.Override.RowSpacingAfter = 4
        Me.DgvIngresoAjuste.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance108.BackColor = System.Drawing.Color.Navy
        Appearance108.ForeColor = System.Drawing.Color.White
        Me.DgvIngresoAjuste.DisplayLayout.Override.SelectedRowAppearance = Appearance108
        Me.DgvIngresoAjuste.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.DgvIngresoAjuste.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.DgvIngresoAjuste.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.DgvIngresoAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgvIngresoAjuste.Location = New System.Drawing.Point(10, 40)
        Me.DgvIngresoAjuste.Name = "DgvIngresoAjuste"
        Me.DgvIngresoAjuste.Size = New System.Drawing.Size(795, 410)
        Me.DgvIngresoAjuste.TabIndex = 83
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9})
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(620, 14)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(83, 14)
        Me.UltraLabel2.TabIndex = 82
        Me.UltraLabel2.Text = "Fecha Consulta"
        '
        'DtFechaConsulta
        '
        Me.DtFechaConsulta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance49.BackColor = System.Drawing.Color.Navy
        Appearance49.FontData.BoldAsString = "True"
        Appearance49.ForeColor = System.Drawing.Color.White
        Appearance49.TextHAlignAsString = "Center"
        Appearance49.TextVAlignAsString = "Middle"
        Me.DtFechaConsulta.Appearance = Appearance49
        Me.DtFechaConsulta.BackColor = System.Drawing.Color.Navy
        Me.DtFechaConsulta.DateTime = New Date(2011, 1, 16, 0, 0, 0, 0)
        Me.DtFechaConsulta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.DtFechaConsulta.FormatProvider = New System.Globalization.CultureInfo("es-PE")
        Me.DtFechaConsulta.Location = New System.Drawing.Point(706, 10)
        Me.DtFechaConsulta.Name = "DtFechaConsulta"
        Me.DtFechaConsulta.Size = New System.Drawing.Size(94, 21)
        Me.DtFechaConsulta.TabIndex = 81
        Me.DtFechaConsulta.Value = New Date(2011, 1, 16, 0, 0, 0, 0)
        '
        'TxtNumeroDocumento
        '
        Me.TxtNumeroDocumento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Appearance55.TextHAlignAsString = "Center"
        Appearance55.TextVAlignAsString = "Middle"
        Me.TxtNumeroDocumento.Appearance = Appearance55
        Me.TxtNumeroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumeroDocumento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtNumeroDocumento.Location = New System.Drawing.Point(470, 10)
        Me.TxtNumeroDocumento.MaxLength = 10
        Me.TxtNumeroDocumento.Name = "TxtNumeroDocumento"
        Me.TxtNumeroDocumento.Size = New System.Drawing.Size(120, 21)
        Me.TxtNumeroDocumento.TabIndex = 80
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(381, 10)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(83, 14)
        Me.UltraLabel1.TabIndex = 79
        Me.UltraLabel1.Text = "Nro Documento"
        '
        'UltraLabel14
        '
        Me.UltraLabel14.AutoSize = True
        Me.UltraLabel14.Location = New System.Drawing.Point(10, 10)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.Size = New System.Drawing.Size(49, 14)
        Me.UltraLabel14.TabIndex = 76
        Me.UltraLabel14.Text = "Empresa"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.GrpAnulacion)
        Me.UltraTabPageControl2.Controls.Add(Me.Cia2)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl2.Controls.Add(Me.dtFeStringegistro)
        Me.UltraTabPageControl2.Controls.Add(Me.dgvDetalleIngresoAjuste)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel29)
        Me.UltraTabPageControl2.Controls.Add(Me.TxtNumeroMovimiento)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel4)
        Me.UltraTabPageControl2.Controls.Add(Me.GrpDatosMovimiento)
        Me.UltraTabPageControl2.Controls.Add(Me.GrpOC)
        Me.UltraTabPageControl2.Controls.Add(Me.LblEstado)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 27)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(812, 464)
        '
        'GrpAnulacion
        '
        Me.GrpAnulacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpAnulacion.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.GrpAnulacion.Controls.Add(Me.CmbAnulacion)
        Me.GrpAnulacion.Controls.Add(Me.Chk_Total)
        Me.GrpAnulacion.Controls.Add(Me.BtCancelar)
        Me.GrpAnulacion.Controls.Add(Me.UltraLabel7)
        Me.GrpAnulacion.Controls.Add(Me.UltraLabel8)
        Me.GrpAnulacion.Location = New System.Drawing.Point(10, 40)
        Me.GrpAnulacion.Name = "GrpAnulacion"
        Me.GrpAnulacion.Size = New System.Drawing.Size(795, 85)
        Me.GrpAnulacion.TabIndex = 150
        Me.GrpAnulacion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        Me.GrpAnulacion.Visible = False
        '
        'CmbAnulacion
        '
        Me.CmbAnulacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance115.BackColor = System.Drawing.Color.White
        Me.CmbAnulacion.DisplayLayout.Appearance = Appearance115
        Me.CmbAnulacion.DisplayLayout.InterBandSpacing = 18
        Appearance119.BackColor = System.Drawing.Color.Transparent
        Me.CmbAnulacion.DisplayLayout.Override.CardAreaAppearance = Appearance119
        Appearance120.FontData.BoldAsString = "True"
        Appearance120.FontData.SizeInPoints = 9.0!
        Appearance120.ForeColor = System.Drawing.Color.Navy
        Me.CmbAnulacion.DisplayLayout.Override.CellAppearance = Appearance120
        Appearance121.BackColor = System.Drawing.Color.Navy
        Appearance121.FontData.BoldAsString = "True"
        Appearance121.FontData.ItalicAsString = "True"
        Appearance121.FontData.SizeInPoints = 10.0!
        Appearance121.ForeColor = System.Drawing.Color.White
        Appearance121.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.CmbAnulacion.DisplayLayout.Override.HeaderAppearance = Appearance121
        Appearance122.BackColor = System.Drawing.Color.Navy
        Appearance122.BorderColor = System.Drawing.Color.White
        Appearance122.ForeColor = System.Drawing.Color.White
        Me.CmbAnulacion.DisplayLayout.Override.RowSelectorAppearance = Appearance122
        Me.CmbAnulacion.DisplayLayout.Override.RowSpacingAfter = 4
        Me.CmbAnulacion.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance123.BackColor = System.Drawing.Color.Navy
        Appearance123.ForeColor = System.Drawing.Color.White
        Me.CmbAnulacion.DisplayLayout.Override.SelectedRowAppearance = Appearance123
        Me.CmbAnulacion.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.CmbAnulacion.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.CmbAnulacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CmbAnulacion.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.CmbAnulacion.Location = New System.Drawing.Point(120, 55)
        Me.CmbAnulacion.Name = "CmbAnulacion"
        Me.CmbAnulacion.ReadOnly = True
        Me.CmbAnulacion.Size = New System.Drawing.Size(380, 22)
        Me.CmbAnulacion.TabIndex = 152
        '
        'Chk_Total
        '
        Me.Chk_Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 9.0!
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.Chk_Total.Appearance = Appearance1
        Me.Chk_Total.BackColor = System.Drawing.Color.Transparent
        Me.Chk_Total.BackColorInternal = System.Drawing.Color.Transparent
        Me.Chk_Total.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
        Me.Chk_Total.Location = New System.Drawing.Point(693, 48)
        Me.Chk_Total.Name = "Chk_Total"
        Me.Chk_Total.Size = New System.Drawing.Size(93, 28)
        Me.Chk_Total.TabIndex = 105
        Me.Chk_Total.Text = "Eliminación Total"
        Me.Chk_Total.Visible = False
        '
        'BtCancelar
        '
        Me.BtCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance143.Image = CType(resources.GetObject("Appearance143.Image"), Object)
        Appearance143.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance143.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance143.TextHAlignAsString = "Right"
        Appearance143.TextVAlignAsString = "Middle"
        Me.BtCancelar.Appearance = Appearance143
        Me.BtCancelar.Location = New System.Drawing.Point(710, 15)
        Me.BtCancelar.Name = "BtCancelar"
        Me.BtCancelar.Size = New System.Drawing.Size(76, 30)
        Me.BtCancelar.TabIndex = 103
        Me.BtCancelar.Text = "Cancelar"
        '
        'UltraLabel7
        '
        Me.UltraLabel7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance15.ForeColor = System.Drawing.Color.White
        Appearance15.TextHAlignAsString = "Center"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance15
        Me.UltraLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel7.Location = New System.Drawing.Point(0, 15)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(795, 30)
        Me.UltraLabel7.TabIndex = 99
        Me.UltraLabel7.Text = "Motivo de Anulación"
        '
        'UltraLabel8
        '
        Appearance90.BackColor = System.Drawing.Color.Transparent
        Appearance90.TextHAlignAsString = "Center"
        Appearance90.TextVAlignAsString = "Top"
        Me.UltraLabel8.Appearance = Appearance90
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Location = New System.Drawing.Point(10, 55)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(106, 14)
        Me.UltraLabel8.TabIndex = 96
        Me.UltraLabel8.Text = "Motivo de Anulación"
        '
        'Cia2
        '
        Me.Cia2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance30.BackColor = System.Drawing.Color.White
        Me.Cia2.DisplayLayout.Appearance = Appearance30
        Me.Cia2.DisplayLayout.InterBandSpacing = 18
        Appearance31.BackColor = System.Drawing.Color.Transparent
        Me.Cia2.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.FontData.BoldAsString = "True"
        Appearance32.FontData.SizeInPoints = 9.0!
        Appearance32.ForeColor = System.Drawing.Color.Navy
        Me.Cia2.DisplayLayout.Override.CellAppearance = Appearance32
        Appearance33.BackColor = System.Drawing.Color.Navy
        Appearance33.FontData.BoldAsString = "True"
        Appearance33.FontData.ItalicAsString = "True"
        Appearance33.FontData.SizeInPoints = 10.0!
        Appearance33.ForeColor = System.Drawing.Color.White
        Appearance33.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.Cia2.DisplayLayout.Override.HeaderAppearance = Appearance33
        Appearance34.BackColor = System.Drawing.Color.Navy
        Appearance34.BorderColor = System.Drawing.Color.White
        Appearance34.ForeColor = System.Drawing.Color.White
        Me.Cia2.DisplayLayout.Override.RowSelectorAppearance = Appearance34
        Me.Cia2.DisplayLayout.Override.RowSpacingAfter = 4
        Me.Cia2.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance35.BackColor = System.Drawing.Color.Navy
        Appearance35.ForeColor = System.Drawing.Color.White
        Me.Cia2.DisplayLayout.Override.SelectedRowAppearance = Appearance35
        Me.Cia2.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.Cia2.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.Cia2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cia2.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cia2.Location = New System.Drawing.Point(60, 10)
        Me.Cia2.Name = "Cia2"
        Me.Cia2.ReadOnly = True
        Me.Cia2.Size = New System.Drawing.Size(270, 22)
        Me.Cia2.TabIndex = 151
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(625, 14)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(81, 14)
        Me.UltraLabel3.TabIndex = 142
        Me.UltraLabel3.Text = "Fecha Registro"
        '
        'dtFeStringegistro
        '
        Me.dtFeStringegistro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance87.BackColor = System.Drawing.Color.Navy
        Appearance87.FontData.BoldAsString = "True"
        Appearance87.ForeColor = System.Drawing.Color.White
        Appearance87.TextHAlignAsString = "Center"
        Appearance87.TextVAlignAsString = "Middle"
        Me.dtFeStringegistro.Appearance = Appearance87
        Me.dtFeStringegistro.BackColor = System.Drawing.Color.Navy
        Me.dtFeStringegistro.DateTime = New Date(2011, 1, 16, 0, 0, 0, 0)
        Me.dtFeStringegistro.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFeStringegistro.FormatProvider = New System.Globalization.CultureInfo("es-PE")
        Me.dtFeStringegistro.Location = New System.Drawing.Point(711, 10)
        Me.dtFeStringegistro.Name = "dtFeStringegistro"
        Me.dtFeStringegistro.Size = New System.Drawing.Size(94, 21)
        Me.dtFeStringegistro.TabIndex = 141
        Me.dtFeStringegistro.Value = New Date(2011, 1, 16, 0, 0, 0, 0)
        '
        'dgvDetalleIngresoAjuste
        '
        Me.dgvDetalleIngresoAjuste.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleIngresoAjuste.DataSource = Me.UltraDataSource2
        Appearance68.BackColor = System.Drawing.Color.White
        Me.dgvDetalleIngresoAjuste.DisplayLayout.Appearance = Appearance68
        Me.dgvDetalleIngresoAjuste.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance16.FontData.BoldAsString = "False"
        Appearance16.FontData.SizeInPoints = 8.0!
        Appearance16.TextHAlignAsString = "Center"
        Appearance16.TextVAlignAsString = "Middle"
        UltraGridColumn10.CellAppearance = Appearance16
        Appearance17.FontData.BoldAsString = "False"
        Appearance17.FontData.SizeInPoints = 8.0!
        UltraGridColumn10.Header.Appearance = Appearance17
        UltraGridColumn10.Header.Caption = "Código"
        UltraGridColumn10.Header.VisiblePosition = 0
        UltraGridColumn10.MaxLength = 8
        UltraGridColumn10.MinWidth = 85
        UltraGridColumn10.RowLayoutColumnInfo.OriginX = 0
        UltraGridColumn10.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn10.Width = 115
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance18.FontData.BoldAsString = "False"
        Appearance18.FontData.SizeInPoints = 8.0!
        UltraGridColumn11.CellAppearance = Appearance18
        UltraGridColumn11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance19.FontData.BoldAsString = "False"
        Appearance19.FontData.SizeInPoints = 8.0!
        UltraGridColumn11.Header.Appearance = Appearance19
        UltraGridColumn11.Header.Caption = "Descripción"
        UltraGridColumn11.Header.VisiblePosition = 1
        UltraGridColumn11.MinWidth = 350
        UltraGridColumn11.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn11.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn11.Width = 481
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance20.FontData.BoldAsString = "False"
        Appearance20.FontData.SizeInPoints = 8.0!
        Appearance20.TextHAlignAsString = "Center"
        Appearance20.TextVAlignAsString = "Middle"
        UltraGridColumn12.CellAppearance = Appearance20
        UltraGridColumn12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance21.FontData.BoldAsString = "False"
        Appearance21.FontData.SizeInPoints = 8.0!
        UltraGridColumn12.Header.Appearance = Appearance21
        UltraGridColumn12.Header.VisiblePosition = 2
        UltraGridColumn12.MinWidth = 60
        UltraGridColumn12.RowLayoutColumnInfo.OriginX = 4
        UltraGridColumn12.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn12.Width = 68
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance22.FontData.BoldAsString = "False"
        Appearance22.FontData.SizeInPoints = 8.0!
        Appearance22.TextHAlignAsString = "Right"
        Appearance22.TextVAlignAsString = "Middle"
        UltraGridColumn13.CellAppearance = Appearance22
        UltraGridColumn13.Format = "n4"
        Appearance23.FontData.BoldAsString = "False"
        Appearance23.FontData.SizeInPoints = 8.0!
        UltraGridColumn13.Header.Appearance = Appearance23
        UltraGridColumn13.Header.Caption = "Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        UltraGridColumn13.Header.VisiblePosition = 4
        UltraGridColumn13.MinWidth = 110
        UltraGridColumn13.RowLayoutColumnInfo.OriginX = 8
        UltraGridColumn13.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoubleNonNegative
        UltraGridColumn13.Width = 110
        UltraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.FontData.SizeInPoints = 8.0!
        Appearance24.TextHAlignAsString = "Right"
        Appearance24.TextVAlignAsString = "Middle"
        UltraGridColumn14.CellAppearance = Appearance24
        UltraGridColumn14.Format = "n4"
        Appearance38.FontData.BoldAsString = "False"
        Appearance38.FontData.SizeInPoints = 8.0!
        UltraGridColumn14.Header.Appearance = Appearance38
        UltraGridColumn14.Header.VisiblePosition = 3
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.MinWidth = 85
        UltraGridColumn14.RowLayoutColumnInfo.OriginX = 6
        UltraGridColumn14.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoubleNonNegative
        UltraGridColumn14.Width = 133
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14})
        Me.dgvDetalleIngresoAjuste.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.dgvDetalleIngresoAjuste.DisplayLayout.InterBandSpacing = 18
        Me.dgvDetalleIngresoAjuste.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.dgvDetalleIngresoAjuste.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Appearance156.BackColor = System.Drawing.Color.Transparent
        Me.dgvDetalleIngresoAjuste.DisplayLayout.Override.CardAreaAppearance = Appearance156
        Appearance157.FontData.BoldAsString = "True"
        Appearance157.FontData.SizeInPoints = 9.0!
        Appearance157.ForeColor = System.Drawing.Color.Navy
        Me.dgvDetalleIngresoAjuste.DisplayLayout.Override.CellAppearance = Appearance157
        Appearance158.BackColor = System.Drawing.Color.Navy
        Appearance158.FontData.BoldAsString = "True"
        Appearance158.FontData.ItalicAsString = "False"
        Appearance158.FontData.SizeInPoints = 10.0!
        Appearance158.ForeColor = System.Drawing.Color.White
        Appearance158.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvDetalleIngresoAjuste.DisplayLayout.Override.HeaderAppearance = Appearance158
        Appearance159.BackColor = System.Drawing.Color.Navy
        Appearance159.BorderColor = System.Drawing.Color.White
        Appearance159.ForeColor = System.Drawing.Color.White
        Appearance159.TextHAlignAsString = "Center"
        Appearance159.TextVAlignAsString = "Middle"
        Me.dgvDetalleIngresoAjuste.DisplayLayout.Override.RowSelectorAppearance = Appearance159
        Me.dgvDetalleIngresoAjuste.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvDetalleIngresoAjuste.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance160.BackColor = System.Drawing.Color.Navy
        Appearance160.ForeColor = System.Drawing.Color.White
        Me.dgvDetalleIngresoAjuste.DisplayLayout.Override.SelectedRowAppearance = Appearance160
        Me.dgvDetalleIngresoAjuste.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvDetalleIngresoAjuste.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvDetalleIngresoAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDetalleIngresoAjuste.Location = New System.Drawing.Point(10, 130)
        Me.dgvDetalleIngresoAjuste.Name = "dgvDetalleIngresoAjuste"
        Me.dgvDetalleIngresoAjuste.Size = New System.Drawing.Size(795, 325)
        Me.dgvDetalleIngresoAjuste.TabIndex = 140
        '
        'UltraDataSource2
        '
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14})
        '
        'UltraLabel29
        '
        Me.UltraLabel29.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel29.AutoSize = True
        Me.UltraLabel29.Location = New System.Drawing.Point(385, 10)
        Me.UltraLabel29.Name = "UltraLabel29"
        Me.UltraLabel29.Size = New System.Drawing.Size(83, 14)
        Me.UltraLabel29.TabIndex = 139
        Me.UltraLabel29.Text = "Nro Movimiento"
        '
        'TxtNumeroMovimiento
        '
        Me.TxtNumeroMovimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance36.ForeColor = System.Drawing.Color.Red
        Appearance36.TextHAlignAsString = "Center"
        Appearance36.TextVAlignAsString = "Middle"
        Me.TxtNumeroMovimiento.Appearance = Appearance36
        Me.TxtNumeroMovimiento.BorderStyle = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.TxtNumeroMovimiento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtNumeroMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroMovimiento.Location = New System.Drawing.Point(475, 10)
        Me.TxtNumeroMovimiento.Name = "TxtNumeroMovimiento"
        Me.TxtNumeroMovimiento.ReadOnly = True
        Me.TxtNumeroMovimiento.Size = New System.Drawing.Size(130, 21)
        Me.TxtNumeroMovimiento.TabIndex = 138
        '
        'UltraLabel4
        '
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(10, 10)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(49, 14)
        Me.UltraLabel4.TabIndex = 78
        Me.UltraLabel4.Text = "Empresa"
        '
        'GrpDatosMovimiento
        '
        Me.GrpDatosMovimiento.Controls.Add(Me.CboTipoMovimiento)
        Me.GrpDatosMovimiento.Controls.Add(Me.CboAlmacen)
        Me.GrpDatosMovimiento.Controls.Add(Me.UltraLabel6)
        Me.GrpDatosMovimiento.Controls.Add(Me.UltraLabel5)
        Me.GrpDatosMovimiento.Location = New System.Drawing.Point(10, 40)
        Me.GrpDatosMovimiento.Name = "GrpDatosMovimiento"
        Me.GrpDatosMovimiento.Size = New System.Drawing.Size(405, 85)
        Me.GrpDatosMovimiento.TabIndex = 80
        Me.GrpDatosMovimiento.Text = "Datos del Movimiento"
        Me.GrpDatosMovimiento.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'CboTipoMovimiento
        '
        Me.CboTipoMovimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance39.BackColor = System.Drawing.Color.White
        Me.CboTipoMovimiento.DisplayLayout.Appearance = Appearance39
        Me.CboTipoMovimiento.DisplayLayout.InterBandSpacing = 18
        Appearance40.BackColor = System.Drawing.Color.Transparent
        Me.CboTipoMovimiento.DisplayLayout.Override.CardAreaAppearance = Appearance40
        Appearance41.FontData.BoldAsString = "True"
        Appearance41.FontData.SizeInPoints = 9.0!
        Appearance41.ForeColor = System.Drawing.Color.Navy
        Me.CboTipoMovimiento.DisplayLayout.Override.CellAppearance = Appearance41
        Appearance42.BackColor = System.Drawing.Color.Navy
        Appearance42.FontData.BoldAsString = "True"
        Appearance42.FontData.ItalicAsString = "True"
        Appearance42.FontData.SizeInPoints = 10.0!
        Appearance42.ForeColor = System.Drawing.Color.White
        Appearance42.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.CboTipoMovimiento.DisplayLayout.Override.HeaderAppearance = Appearance42
        Appearance44.BackColor = System.Drawing.Color.Navy
        Appearance44.BorderColor = System.Drawing.Color.White
        Appearance44.ForeColor = System.Drawing.Color.White
        Me.CboTipoMovimiento.DisplayLayout.Override.RowSelectorAppearance = Appearance44
        Me.CboTipoMovimiento.DisplayLayout.Override.RowSpacingAfter = 4
        Me.CboTipoMovimiento.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance45.BackColor = System.Drawing.Color.Navy
        Appearance45.ForeColor = System.Drawing.Color.White
        Me.CboTipoMovimiento.DisplayLayout.Override.SelectedRowAppearance = Appearance45
        Me.CboTipoMovimiento.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.CboTipoMovimiento.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.CboTipoMovimiento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CboTipoMovimiento.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.CboTipoMovimiento.Location = New System.Drawing.Point(100, 25)
        Me.CboTipoMovimiento.Name = "CboTipoMovimiento"
        Me.CboTipoMovimiento.ReadOnly = True
        Me.CboTipoMovimiento.Size = New System.Drawing.Size(295, 22)
        Me.CboTipoMovimiento.TabIndex = 92
        '
        'CboAlmacen
        '
        Appearance82.FontData.BoldAsString = "False"
        Appearance82.FontData.ItalicAsString = "False"
        Appearance82.FontData.SizeInPoints = 8.0!
        Appearance82.TextHAlignAsString = "Left"
        Appearance82.TextVAlignAsString = "Middle"
        Me.CboAlmacen.Appearance = Appearance82
        Me.CboAlmacen.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Me.CboAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance76.BackColor = System.Drawing.Color.White
        Me.CboAlmacen.DisplayLayout.Appearance = Appearance76
        Appearance98.FontData.BoldAsString = "False"
        Appearance98.FontData.ItalicAsString = "False"
        Appearance98.FontData.SizeInPoints = 8.0!
        UltraGridColumn15.CellAppearance = Appearance98
        Appearance99.FontData.BoldAsString = "False"
        Appearance99.FontData.ItalicAsString = "False"
        Appearance99.FontData.SizeInPoints = 8.0!
        UltraGridColumn15.Header.Appearance = Appearance99
        UltraGridColumn15.Header.Caption = "Código"
        UltraGridColumn15.Header.VisiblePosition = 0
        UltraGridColumn15.Hidden = True
        Appearance100.FontData.BoldAsString = "False"
        Appearance100.FontData.ItalicAsString = "False"
        Appearance100.FontData.SizeInPoints = 8.0!
        UltraGridColumn16.CellAppearance = Appearance100
        UltraGridColumn16.ColSpan = CType(2, Short)
        Appearance101.FontData.BoldAsString = "False"
        Appearance101.FontData.ItalicAsString = "False"
        Appearance101.FontData.SizeInPoints = 8.0!
        UltraGridColumn16.Header.Appearance = Appearance101
        UltraGridColumn16.Header.Caption = "Descripción"
        UltraGridColumn16.Header.VisiblePosition = 1
        UltraGridColumn16.Width = 305
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn15, UltraGridColumn16})
        Me.CboAlmacen.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.CboAlmacen.DisplayLayout.InterBandSpacing = 18
        Appearance77.BackColor = System.Drawing.Color.Transparent
        Me.CboAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance77
        Appearance78.FontData.BoldAsString = "True"
        Appearance78.FontData.SizeInPoints = 9.0!
        Appearance78.ForeColor = System.Drawing.Color.Navy
        Me.CboAlmacen.DisplayLayout.Override.CellAppearance = Appearance78
        Appearance79.BackColor = System.Drawing.Color.Navy
        Appearance79.FontData.BoldAsString = "True"
        Appearance79.FontData.ItalicAsString = "True"
        Appearance79.FontData.SizeInPoints = 10.0!
        Appearance79.ForeColor = System.Drawing.Color.White
        Appearance79.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.CboAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance79
        Appearance80.BackColor = System.Drawing.Color.Navy
        Appearance80.BorderColor = System.Drawing.Color.White
        Appearance80.ForeColor = System.Drawing.Color.White
        Me.CboAlmacen.DisplayLayout.Override.RowSelectorAppearance = Appearance80
        Me.CboAlmacen.DisplayLayout.Override.RowSpacingAfter = 4
        Me.CboAlmacen.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance81.BackColor = System.Drawing.Color.Navy
        Appearance81.ForeColor = System.Drawing.Color.White
        Me.CboAlmacen.DisplayLayout.Override.SelectedRowAppearance = Appearance81
        Me.CboAlmacen.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.CboAlmacen.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.CboAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CboAlmacen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.CboAlmacen.Location = New System.Drawing.Point(100, 50)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(295, 22)
        Me.CboAlmacen.TabIndex = 91
        '
        'UltraLabel6
        '
        Appearance58.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel6.Appearance = Appearance58
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(49, 50)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(48, 14)
        Me.UltraLabel6.TabIndex = 87
        Me.UltraLabel6.Text = "Almacén"
        '
        'UltraLabel5
        '
        Appearance37.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel5.Appearance = Appearance37
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(10, 25)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(87, 14)
        Me.UltraLabel5.TabIndex = 85
        Me.UltraLabel5.Text = "Tipo Movimiento"
        '
        'GrpOC
        '
        Me.GrpOC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpOC.Controls.Add(Me.CboMotivo)
        Me.GrpOC.Controls.Add(Me.UltraLabel18)
        Me.GrpOC.Location = New System.Drawing.Point(420, 40)
        Me.GrpOC.Name = "GrpOC"
        Me.GrpOC.Size = New System.Drawing.Size(385, 85)
        Me.GrpOC.TabIndex = 81
        Me.GrpOC.Text = "Referencia del Documento"
        Me.GrpOC.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'CboMotivo
        '
        Me.CboMotivo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CboMotivo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.CboMotivo.Location = New System.Drawing.Point(70, 35)
        Me.CboMotivo.Name = "CboMotivo"
        Me.CboMotivo.Size = New System.Drawing.Size(290, 21)
        Me.CboMotivo.TabIndex = 98
        '
        'UltraLabel18
        '
        Appearance25.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel18.Appearance = Appearance25
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Location = New System.Drawing.Point(25, 35)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(38, 14)
        Me.UltraLabel18.TabIndex = 97
        Me.UltraLabel18.Text = "Motivo"
        '
        'LblEstado
        '
        Me.LblEstado.Location = New System.Drawing.Point(575, 40)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(228, 23)
        Me.LblEstado.TabIndex = 99
        Me.LblEstado.Visible = False
        '
        'TabIngresoAjuste
        '
        Me.TabIngresoAjuste.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.TabIngresoAjuste.Controls.Add(Me.UltraTabPageControl1)
        Me.TabIngresoAjuste.Controls.Add(Me.UltraTabPageControl2)
        Me.TabIngresoAjuste.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabIngresoAjuste.Location = New System.Drawing.Point(0, 0)
        Me.TabIngresoAjuste.Name = "TabIngresoAjuste"
        Appearance29.FontData.SizeInPoints = 12.0!
        Me.TabIngresoAjuste.SelectedTabAppearance = Appearance29
        Me.TabIngresoAjuste.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.TabIngresoAjuste.Size = New System.Drawing.Size(814, 492)
        Me.TabIngresoAjuste.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon
        Me.TabIngresoAjuste.TabIndex = 1
        Me.TabIngresoAjuste.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab1.Key = "Listar"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Listado Ingreso Por Ajuste"
        UltraTab2.Key = "Ingreso"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Ingreso Por Ajuste"
        Me.TabIngresoAjuste.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        Me.TabIngresoAjuste.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(812, 464)
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance26.Image = CType(resources.GetObject("Appearance26.Image"), Object)
        Appearance26.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance26.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance26.TextHAlignAsString = "Right"
        Appearance26.TextVAlignAsString = "Middle"
        Me.btnCancelar.Appearance = Appearance26
        Me.btnCancelar.Location = New System.Drawing.Point(675, 60)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
        Me.btnCancelar.TabIndex = 103
        Me.btnCancelar.Text = "Cancelar"
        '
        'CboAnulacion
        '
        Appearance43.BackColor = System.Drawing.Color.Red
        Me.CboAnulacion.Appearance = Appearance43
        Me.CboAnulacion.BackColor = System.Drawing.Color.Red
        Me.CboAnulacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CboAnulacion.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.CboAnulacion.Location = New System.Drawing.Point(10, 250)
        Me.CboAnulacion.Name = "CboAnulacion"
        Me.CboAnulacion.Size = New System.Drawing.Size(536, 21)
        Me.CboAnulacion.TabIndex = 102
        '
        'UltraLabel16
        '
        Me.UltraLabel16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance27.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance27.ForeColor = System.Drawing.Color.White
        Appearance27.TextHAlignAsString = "Center"
        Appearance27.TextVAlignAsString = "Middle"
        Me.UltraLabel16.Appearance = Appearance27
        Me.UltraLabel16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel16.Location = New System.Drawing.Point(0, 10)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(769, 40)
        Me.UltraLabel16.TabIndex = 99
        Me.UltraLabel16.Text = "Motivo de Anulación"
        '
        'UltraLabel36
        '
        Appearance28.BackColor = System.Drawing.Color.Transparent
        Appearance28.TextHAlignAsString = "Center"
        Appearance28.TextVAlignAsString = "Top"
        Me.UltraLabel36.Appearance = Appearance28
        Me.UltraLabel36.AutoSize = True
        Me.UltraLabel36.Location = New System.Drawing.Point(10, 65)
        Me.UltraLabel36.Name = "UltraLabel36"
        Me.UltraLabel36.Size = New System.Drawing.Size(106, 14)
        Me.UltraLabel36.TabIndex = 96
        Me.UltraLabel36.Text = "Motivo de Anulación"
        '
        'FrmIngresoAjuste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 492)
        Me.Controls.Add(Me.TabIngresoAjuste)
        Me.Name = "FrmIngresoAjuste"
        Me.Text = " Ingreso Por Ajuste"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.Cia1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvIngresoAjuste, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtFechaConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumeroDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.GrpAnulacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpAnulacion.ResumeLayout(False)
        Me.GrpAnulacion.PerformLayout()
        CType(Me.CmbAnulacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cia2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFeStringegistro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalleIngresoAjuste, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumeroMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrpDatosMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDatosMovimiento.ResumeLayout(False)
        Me.GrpDatosMovimiento.PerformLayout()
        CType(Me.CboTipoMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrpOC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpOC.ResumeLayout(False)
        Me.GrpOC.PerformLayout()
        CType(Me.CboMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabIngresoAjuste, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabIngresoAjuste.ResumeLayout(False)
        CType(Me.CboAnulacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabIngresoAjuste As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DtFechaConsulta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents TxtNumeroDocumento As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel29 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtNumeroMovimiento As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GrpDatosMovimiento As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GrpOC As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents CboMotivo As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DgvIngresoAjuste As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents dgvDetalleIngresoAjuste As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtFeStringegistro As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents LblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents CboAnulacion As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel36 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GrpAnulacion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents BtCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Cia1 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Cia2 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents CboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents CboTipoMovimiento As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Chk_Total As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents CmbAnulacion As Infragistics.Win.UltraWinGrid.UltraCombo
End Class
