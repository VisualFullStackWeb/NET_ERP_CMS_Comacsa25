<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRangosAprobacion
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
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem13 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem14 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem15 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem16 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem17 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem18 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem19 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem20 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem21 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalDesde")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Signo")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Band 1")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalHasta", 0)
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SignoHasta", 1)
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 1", 0)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Firma")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataBand1 As Infragistics.Win.UltraWinDataSource.UltraDataBand = New Infragistics.Win.UltraWinDataSource.UltraDataBand("Band 1")
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Firma")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Moneda")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TotalDesde")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Signo")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Importe")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance104 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario", 0)
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Firma", 1)
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance110 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance112 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance113 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance116 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda")
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalDesde")
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Signo")
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Band 1")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalHasta", 0)
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SignoHasta", 1)
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 1", -1)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Firma")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance126 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance129 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance130 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance131 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraComboEditor2 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraComboEditor1 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraComboEditor3 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.CmbUsuario = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraComboEditor4 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraComboEditor5 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraComboEditor6 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.DgvRangoAprobacion = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Cia1 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.CodigoAprobacion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.TxtDesde = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.TxtHasta = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.CboMoneda = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.CboSigno = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.dgvFirmaUsuario = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource3 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.dgvRanApro = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.TabRangoAprobacion = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraLabel19 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        CType(Me.UltraComboEditor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraComboEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraComboEditor3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraComboEditor4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraComboEditor5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraComboEditor6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.DgvRangoAprobacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.Cia1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CodigoAprobacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSigno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFirmaUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.dgvRanApro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.TabRangoAprobacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabRangoAprobacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraComboEditor2
        '
        Me.UltraComboEditor2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraComboEditor2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem2.DataValue = "S/."
        ValueListItem2.DisplayText = "S/."
        ValueListItem3.DataValue = "US$"
        ValueListItem3.DisplayText = "US$"
        Me.UltraComboEditor2.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem2, ValueListItem3})
        Me.UltraComboEditor2.Location = New System.Drawing.Point(215, 346)
        Me.UltraComboEditor2.Name = "UltraComboEditor2"
        Me.UltraComboEditor2.Size = New System.Drawing.Size(92, 21)
        Me.UltraComboEditor2.TabIndex = 71
        Me.UltraComboEditor2.Visible = False
        '
        'UltraComboEditor1
        '
        Me.UltraComboEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraComboEditor1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem5.DataValue = ">"
        ValueListItem5.DisplayText = ">"
        ValueListItem11.DataValue = "<"
        ValueListItem11.DisplayText = "<"
        ValueListItem12.DataValue = ">="
        ValueListItem12.DisplayText = ">="
        ValueListItem13.DataValue = "<="
        ValueListItem13.DisplayText = "<="
        ValueListItem14.DataValue = "="
        ValueListItem14.DisplayText = "="
        Me.UltraComboEditor1.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem5, ValueListItem11, ValueListItem12, ValueListItem13, ValueListItem14})
        Me.UltraComboEditor1.Location = New System.Drawing.Point(112, 346)
        Me.UltraComboEditor1.Name = "UltraComboEditor1"
        Me.UltraComboEditor1.Size = New System.Drawing.Size(76, 21)
        Me.UltraComboEditor1.TabIndex = 70
        Me.UltraComboEditor1.Visible = False
        '
        'UltraComboEditor3
        '
        Me.UltraComboEditor3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraComboEditor3.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.UltraComboEditor3.Location = New System.Drawing.Point(336, 346)
        Me.UltraComboEditor3.Name = "UltraComboEditor3"
        Me.UltraComboEditor3.Size = New System.Drawing.Size(92, 21)
        Me.UltraComboEditor3.TabIndex = 72
        Me.UltraComboEditor3.Visible = False
        '
        'CmbUsuario
        '
        Me.CmbUsuario.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CmbUsuario.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.CmbUsuario.Location = New System.Drawing.Point(363, 295)
        Me.CmbUsuario.Name = "CmbUsuario"
        Me.CmbUsuario.Size = New System.Drawing.Size(92, 21)
        Me.CmbUsuario.TabIndex = 90
        Me.CmbUsuario.Visible = False
        '
        'UltraComboEditor4
        '
        Me.UltraComboEditor4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraComboEditor4.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem15.DataValue = "S/."
        ValueListItem15.DisplayText = "S/."
        ValueListItem16.DataValue = "US $"
        ValueListItem16.DisplayText = "US $"
        Me.UltraComboEditor4.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem15, ValueListItem16})
        Me.UltraComboEditor4.Location = New System.Drawing.Point(346, 324)
        Me.UltraComboEditor4.Name = "UltraComboEditor4"
        Me.UltraComboEditor4.Size = New System.Drawing.Size(92, 21)
        Me.UltraComboEditor4.TabIndex = 76
        Me.UltraComboEditor4.Visible = False
        '
        'UltraComboEditor5
        '
        Me.UltraComboEditor5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraComboEditor5.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem17.DataValue = ">"
        ValueListItem17.DisplayText = ">"
        ValueListItem18.DataValue = "<"
        ValueListItem18.DisplayText = "<"
        ValueListItem19.DataValue = ">="
        ValueListItem19.DisplayText = ">="
        ValueListItem20.DataValue = "<="
        ValueListItem20.DisplayText = "<="
        ValueListItem21.DataValue = "="
        ValueListItem21.DisplayText = "="
        Me.UltraComboEditor5.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem17, ValueListItem18, ValueListItem19, ValueListItem20, ValueListItem21})
        Me.UltraComboEditor5.Location = New System.Drawing.Point(245, 324)
        Me.UltraComboEditor5.Name = "UltraComboEditor5"
        Me.UltraComboEditor5.Size = New System.Drawing.Size(76, 21)
        Me.UltraComboEditor5.TabIndex = 75
        Me.UltraComboEditor5.Visible = False
        '
        'UltraComboEditor6
        '
        Me.UltraComboEditor6.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraComboEditor6.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.UltraComboEditor6.Location = New System.Drawing.Point(467, 324)
        Me.UltraComboEditor6.Name = "UltraComboEditor6"
        Me.UltraComboEditor6.Size = New System.Drawing.Size(92, 21)
        Me.UltraComboEditor6.TabIndex = 77
        Me.UltraComboEditor6.Visible = False
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.DgvRangoAprobacion)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraComboEditor1)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraComboEditor2)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraComboEditor3)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 27)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(820, 404)
        '
        'DgvRangoAprobacion
        '
        Me.DgvRangoAprobacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvRangoAprobacion.DataSource = Me.UltraDataSource2
        Appearance61.BackColor = System.Drawing.Color.White
        Me.DgvRangoAprobacion.DisplayLayout.Appearance = Appearance61
        Me.DgvRangoAprobacion.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 54
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Width = 59
        UltraGridColumn3.Header.VisiblePosition = 4
        UltraGridColumn3.Width = 59
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.Width = 59
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 59
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance98.FontData.BoldAsString = "False"
        Appearance98.FontData.SizeInPoints = 8.0!
        Appearance98.TextHAlignAsString = "Center"
        Appearance98.TextVAlignAsString = "Middle"
        UltraGridColumn7.CellAppearance = Appearance98
        UltraGridColumn7.Format = "n4"
        Appearance99.FontData.BoldAsString = "False"
        Appearance99.FontData.SizeInPoints = 8.0!
        UltraGridColumn7.Header.Appearance = Appearance99
        UltraGridColumn7.Header.Caption = "Total Hasta"
        UltraGridColumn7.Header.VisiblePosition = 3
        UltraGridColumn7.Width = 330
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance100.FontData.BoldAsString = "False"
        Appearance100.FontData.SizeInPoints = 8.0!
        Appearance100.TextHAlignAsString = "Center"
        Appearance100.TextVAlignAsString = "Middle"
        UltraGridColumn8.CellAppearance = Appearance100
        UltraGridColumn8.EditorControl = Me.UltraComboEditor1
        Appearance101.FontData.BoldAsString = "False"
        Appearance101.FontData.SizeInPoints = 8.0!
        UltraGridColumn8.Header.Appearance = Appearance101
        UltraGridColumn8.Header.Caption = "Signo Hasta"
        UltraGridColumn8.Header.VisiblePosition = 1
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn8.Width = 74
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8})
        UltraGridColumn9.Header.VisiblePosition = 0
        UltraGridColumn9.Width = 201
        UltraGridColumn10.Header.VisiblePosition = 1
        UltraGridColumn10.Width = 200
        UltraGridColumn11.Header.VisiblePosition = 2
        UltraGridColumn11.Width = 200
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn9, UltraGridColumn10, UltraGridColumn11})
        Me.DgvRangoAprobacion.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.DgvRangoAprobacion.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.DgvRangoAprobacion.DisplayLayout.InterBandSpacing = 18
        Me.DgvRangoAprobacion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.DgvRangoAprobacion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.DgvRangoAprobacion.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Appearance72.BackColor = System.Drawing.Color.Transparent
        Me.DgvRangoAprobacion.DisplayLayout.Override.CardAreaAppearance = Appearance72
        Appearance73.FontData.BoldAsString = "True"
        Appearance73.FontData.SizeInPoints = 9.0!
        Appearance73.ForeColor = System.Drawing.Color.Navy
        Me.DgvRangoAprobacion.DisplayLayout.Override.CellAppearance = Appearance73
        Me.DgvRangoAprobacion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance74.BackColor = System.Drawing.Color.Navy
        Appearance74.FontData.BoldAsString = "True"
        Appearance74.FontData.ItalicAsString = "False"
        Appearance74.FontData.SizeInPoints = 10.0!
        Appearance74.ForeColor = System.Drawing.Color.White
        Appearance74.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.DgvRangoAprobacion.DisplayLayout.Override.HeaderAppearance = Appearance74
        Appearance75.FontData.BoldAsString = "True"
        Appearance75.FontData.SizeInPoints = 9.0!
        Appearance75.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance75.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.DgvRangoAprobacion.DisplayLayout.Override.RowPreviewAppearance = Appearance75
        Appearance76.BackColor = System.Drawing.Color.Navy
        Appearance76.BorderColor = System.Drawing.Color.White
        Appearance76.FontData.BoldAsString = "True"
        Appearance76.ForeColor = System.Drawing.Color.White
        Appearance76.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance76.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance76.TextHAlignAsString = "Center"
        Appearance76.TextVAlignAsString = "Middle"
        Me.DgvRangoAprobacion.DisplayLayout.Override.RowSelectorAppearance = Appearance76
        Me.DgvRangoAprobacion.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None
        Me.DgvRangoAprobacion.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.DgvRangoAprobacion.DisplayLayout.Override.RowSpacingAfter = 4
        Me.DgvRangoAprobacion.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance77.BackColor = System.Drawing.Color.Navy
        Appearance77.ForeColor = System.Drawing.Color.White
        Me.DgvRangoAprobacion.DisplayLayout.Override.SelectedRowAppearance = Appearance77
        Me.DgvRangoAprobacion.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.DgvRangoAprobacion.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.DgvRangoAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgvRangoAprobacion.Location = New System.Drawing.Point(85, 20)
        Me.DgvRangoAprobacion.Name = "DgvRangoAprobacion"
        Me.DgvRangoAprobacion.Size = New System.Drawing.Size(680, 373)
        Me.DgvRangoAprobacion.TabIndex = 69
        '
        'UltraDataSource2
        '
        UltraDataBand1.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3})
        Me.UltraDataSource2.Band.ChildBands.AddRange(New Object() {UltraDataBand1})
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8})
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(820, 404)
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.UltraGroupBox2.Controls.Add(Me.Cia1)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox2.Controls.Add(Me.CodigoAprobacion)
        Me.UltraGroupBox2.Controls.Add(Me.TxtDesde)
        Me.UltraGroupBox2.Controls.Add(Me.TxtHasta)
        Me.UltraGroupBox2.Controls.Add(Me.CboMoneda)
        Me.UltraGroupBox2.Controls.Add(Me.CboSigno)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox2.Controls.Add(Me.CmbUsuario)
        Me.UltraGroupBox2.Controls.Add(Me.dgvFirmaUsuario)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(140, 28)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(560, 345)
        Me.UltraGroupBox2.TabIndex = 86
        Me.UltraGroupBox2.Text = "Datos de Aprobación"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'Cia1
        '
        Me.Cia1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance13.BackColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Appearance = Appearance13
        Me.Cia1.DisplayLayout.InterBandSpacing = 18
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Me.Cia1.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance35.FontData.BoldAsString = "True"
        Appearance35.FontData.SizeInPoints = 9.0!
        Appearance35.ForeColor = System.Drawing.Color.Navy
        Me.Cia1.DisplayLayout.Override.CellAppearance = Appearance35
        Appearance54.BackColor = System.Drawing.Color.Navy
        Appearance54.FontData.BoldAsString = "True"
        Appearance54.FontData.ItalicAsString = "True"
        Appearance54.FontData.SizeInPoints = 10.0!
        Appearance54.ForeColor = System.Drawing.Color.White
        Appearance54.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.Cia1.DisplayLayout.Override.HeaderAppearance = Appearance54
        Appearance57.BackColor = System.Drawing.Color.Navy
        Appearance57.BorderColor = System.Drawing.Color.White
        Appearance57.ForeColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Override.RowSelectorAppearance = Appearance57
        Me.Cia1.DisplayLayout.Override.RowSpacingAfter = 4
        Me.Cia1.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance65.BackColor = System.Drawing.Color.Navy
        Appearance65.ForeColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Override.SelectedRowAppearance = Appearance65
        Me.Cia1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.Cia1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.Cia1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cia1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cia1.Location = New System.Drawing.Point(60, 30)
        Me.Cia1.Name = "Cia1"
        Me.Cia1.ReadOnly = True
        Me.Cia1.Size = New System.Drawing.Size(270, 22)
        Me.Cia1.TabIndex = 92
        '
        'UltraLabel5
        '
        Appearance55.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel5.Appearance = Appearance55
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(10, 30)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(49, 14)
        Me.UltraLabel5.TabIndex = 86
        Me.UltraLabel5.Text = "Empresa"
        '
        'CodigoAprobacion
        '
        Me.CodigoAprobacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CodigoAprobacion.Location = New System.Drawing.Point(81, 30)
        Me.CodigoAprobacion.Name = "CodigoAprobacion"
        Me.CodigoAprobacion.Size = New System.Drawing.Size(85, 21)
        Me.CodigoAprobacion.TabIndex = 84
        Me.CodigoAprobacion.Visible = False
        '
        'TxtDesde
        '
        Me.TxtDesde.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtDesde.Location = New System.Drawing.Point(180, 60)
        Me.TxtDesde.MaskInput = "{double:-9.4}"
        Me.TxtDesde.Name = "TxtDesde"
        Me.TxtDesde.Nullable = True
        Me.TxtDesde.NullText = "0"
        Me.TxtDesde.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.TxtDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtDesde.Size = New System.Drawing.Size(100, 21)
        Me.TxtDesde.TabIndex = 83
        '
        'TxtHasta
        '
        Me.TxtHasta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtHasta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtHasta.Location = New System.Drawing.Point(447, 60)
        Me.TxtHasta.MaskInput = "{double:-9.4}"
        Me.TxtHasta.Name = "TxtHasta"
        Me.TxtHasta.Nullable = True
        Me.TxtHasta.NullText = "0"
        Me.TxtHasta.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Double]
        Me.TxtHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtHasta.Size = New System.Drawing.Size(100, 21)
        Me.TxtHasta.TabIndex = 82
        '
        'CboMoneda
        '
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.CboMoneda.Appearance = Appearance3
        Me.CboMoneda.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CboMoneda.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "S/."
        ValueListItem1.DisplayText = "S/."
        ValueListItem4.DataValue = "US$"
        ValueListItem4.DisplayText = "US$"
        Me.CboMoneda.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem4})
        Me.CboMoneda.Location = New System.Drawing.Point(60, 60)
        Me.CboMoneda.Name = "CboMoneda"
        Me.CboMoneda.Size = New System.Drawing.Size(70, 21)
        Me.CboMoneda.TabIndex = 79
        '
        'CboSigno
        '
        Me.CboSigno.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        Me.CboSigno.Appearance = Appearance4
        Me.CboSigno.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CboSigno.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem6.DataValue = ">"
        ValueListItem6.DisplayText = ">"
        ValueListItem7.DataValue = "<"
        ValueListItem7.DisplayText = "<"
        ValueListItem8.DataValue = ">="
        ValueListItem8.DisplayText = ">="
        ValueListItem9.DataValue = "<="
        ValueListItem9.DisplayText = "<="
        ValueListItem10.DataValue = "="
        ValueListItem10.DisplayText = "="
        Me.CboSigno.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem6, ValueListItem7, ValueListItem8, ValueListItem9, ValueListItem10})
        Me.CboSigno.Location = New System.Drawing.Point(331, 57)
        Me.CboSigno.Name = "CboSigno"
        Me.CboSigno.Size = New System.Drawing.Size(70, 21)
        Me.CboSigno.TabIndex = 78
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance52.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel4.Appearance = Appearance52
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(410, 60)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(34, 14)
        Me.UltraLabel4.TabIndex = 3
        Me.UltraLabel4.Text = "Hasta"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance53.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel3.Appearance = Appearance53
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(292, 60)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(33, 14)
        Me.UltraLabel3.TabIndex = 2
        Me.UltraLabel3.Text = "Signo"
        '
        'UltraLabel2
        '
        Appearance27.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance27
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(140, 60)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(37, 14)
        Me.UltraLabel2.TabIndex = 1
        Me.UltraLabel2.Text = "Desde"
        '
        'UltraLabel1
        '
        Appearance56.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance56
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(10, 60)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(45, 14)
        Me.UltraLabel1.TabIndex = 0
        Me.UltraLabel1.Text = "Moneda"
        '
        'dgvFirmaUsuario
        '
        Me.dgvFirmaUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFirmaUsuario.DataSource = Me.UltraDataSource3
        Appearance104.BackColor = System.Drawing.Color.White
        Me.dgvFirmaUsuario.DisplayLayout.Appearance = Appearance104
        Me.dgvFirmaUsuario.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance102.FontData.BoldAsString = "False"
        Appearance102.FontData.SizeInPoints = 8.0!
        Appearance102.TextHAlignAsString = "Center"
        Appearance102.TextVAlignAsString = "Middle"
        UltraGridColumn12.CellAppearance = Appearance102
        UltraGridColumn12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn12.EditorControl = Me.CmbUsuario
        Appearance103.FontData.BoldAsString = "False"
        Appearance103.FontData.SizeInPoints = 8.0!
        UltraGridColumn12.Header.Appearance = Appearance103
        UltraGridColumn12.Header.VisiblePosition = 0
        UltraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn12.Width = 220
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance106.FontData.BoldAsString = "False"
        Appearance106.FontData.SizeInPoints = 8.0!
        Appearance106.TextHAlignAsString = "Center"
        Appearance106.TextVAlignAsString = "Middle"
        UltraGridColumn13.CellAppearance = Appearance106
        Appearance107.FontData.BoldAsString = "False"
        Appearance107.FontData.SizeInPoints = 8.0!
        UltraGridColumn13.Header.Appearance = Appearance107
        UltraGridColumn13.Header.VisiblePosition = 1
        UltraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn13.Width = 79
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn12, UltraGridColumn13})
        Me.dgvFirmaUsuario.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.dgvFirmaUsuario.DisplayLayout.InterBandSpacing = 18
        Me.dgvFirmaUsuario.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.FixedAddRowOnTop
        Me.dgvFirmaUsuario.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvFirmaUsuario.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvFirmaUsuario.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Appearance108.BackColor = System.Drawing.Color.Transparent
        Me.dgvFirmaUsuario.DisplayLayout.Override.CardAreaAppearance = Appearance108
        Appearance109.FontData.BoldAsString = "True"
        Appearance109.FontData.SizeInPoints = 9.0!
        Appearance109.ForeColor = System.Drawing.Color.Navy
        Me.dgvFirmaUsuario.DisplayLayout.Override.CellAppearance = Appearance109
        Me.dgvFirmaUsuario.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance110.BackColor = System.Drawing.Color.Navy
        Appearance110.FontData.BoldAsString = "True"
        Appearance110.FontData.ItalicAsString = "False"
        Appearance110.FontData.SizeInPoints = 10.0!
        Appearance110.ForeColor = System.Drawing.Color.White
        Appearance110.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvFirmaUsuario.DisplayLayout.Override.HeaderAppearance = Appearance110
        Appearance111.FontData.BoldAsString = "True"
        Appearance111.FontData.SizeInPoints = 9.0!
        Appearance111.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance111.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.dgvFirmaUsuario.DisplayLayout.Override.RowPreviewAppearance = Appearance111
        Appearance112.BackColor = System.Drawing.Color.Navy
        Appearance112.BorderColor = System.Drawing.Color.White
        Appearance112.FontData.BoldAsString = "True"
        Appearance112.ForeColor = System.Drawing.Color.White
        Appearance112.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance112.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance112.TextHAlignAsString = "Center"
        Appearance112.TextVAlignAsString = "Middle"
        Me.dgvFirmaUsuario.DisplayLayout.Override.RowSelectorAppearance = Appearance112
        Me.dgvFirmaUsuario.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None
        Me.dgvFirmaUsuario.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.dgvFirmaUsuario.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvFirmaUsuario.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance113.BackColor = System.Drawing.Color.Navy
        Appearance113.ForeColor = System.Drawing.Color.White
        Me.dgvFirmaUsuario.DisplayLayout.Override.SelectedRowAppearance = Appearance113
        Me.dgvFirmaUsuario.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvFirmaUsuario.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvFirmaUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvFirmaUsuario.Location = New System.Drawing.Point(121, 90)
        Me.dgvFirmaUsuario.Name = "dgvFirmaUsuario"
        Me.dgvFirmaUsuario.Size = New System.Drawing.Size(340, 240)
        Me.dgvFirmaUsuario.TabIndex = 89
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraComboEditor4)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraComboEditor5)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraComboEditor6)
        Me.UltraTabPageControl2.Controls.Add(Me.dgvRanApro)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(820, 389)
        '
        'dgvRanApro
        '
        Me.dgvRanApro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRanApro.DataSource = Me.UltraDataSource2
        Appearance116.BackColor = System.Drawing.Color.White
        Me.dgvRanApro.DisplayLayout.Appearance = Appearance116
        Me.dgvRanApro.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance117.FontData.BoldAsString = "False"
        Appearance117.FontData.SizeInPoints = 8.0!
        Appearance117.TextHAlignAsString = "Center"
        Appearance117.TextVAlignAsString = "Middle"
        UltraGridColumn14.CellAppearance = Appearance117
        UltraGridColumn14.EditorControl = Me.UltraComboEditor4
        UltraGridColumn14.Header.VisiblePosition = 1
        UltraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn14.Width = 81
        UltraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance118.FontData.BoldAsString = "False"
        Appearance118.TextHAlignAsString = "Center"
        Appearance118.TextVAlignAsString = "Middle"
        UltraGridColumn15.CellAppearance = Appearance118
        UltraGridColumn15.Header.VisiblePosition = 0
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 54
        UltraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance119.FontData.BoldAsString = "False"
        Appearance119.FontData.SizeInPoints = 8.0!
        Appearance119.TextHAlignAsString = "Center"
        Appearance119.TextVAlignAsString = "Middle"
        UltraGridColumn16.CellAppearance = Appearance119
        UltraGridColumn16.Header.Caption = "Total Desde"
        UltraGridColumn16.Header.VisiblePosition = 2
        UltraGridColumn16.Width = 224
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance120.FontData.BoldAsString = "False"
        Appearance120.FontData.SizeInPoints = 8.0!
        Appearance120.TextHAlignAsString = "Center"
        Appearance120.TextVAlignAsString = "Middle"
        UltraGridColumn17.CellAppearance = Appearance120
        UltraGridColumn17.EditorControl = Me.UltraComboEditor5
        Appearance121.TextHAlignAsString = "Center"
        Appearance121.TextVAlignAsString = "Middle"
        UltraGridColumn17.Header.Appearance = Appearance121
        UltraGridColumn17.Header.TextOrientation = New Infragistics.Win.TextOrientationInfo(0, Infragistics.Win.TextFlowDirection.Horizontal)
        UltraGridColumn17.Header.VisiblePosition = 3
        UltraGridColumn17.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn17.Width = 87
        UltraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance122.FontData.BoldAsString = "False"
        Appearance122.FontData.SizeInPoints = 8.0!
        Appearance122.TextHAlignAsString = "Center"
        Appearance122.TextVAlignAsString = "Middle"
        UltraGridColumn18.CellAppearance = Appearance122
        UltraGridColumn18.Header.VisiblePosition = 4
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 154
        UltraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn19.Header.VisiblePosition = 7
        UltraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance123.FontData.BoldAsString = "False"
        Appearance123.FontData.SizeInPoints = 8.0!
        Appearance123.TextHAlignAsString = "Center"
        Appearance123.TextVAlignAsString = "Middle"
        UltraGridColumn20.CellAppearance = Appearance123
        UltraGridColumn20.Header.VisiblePosition = 6
        UltraGridColumn20.Width = 228
        UltraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance124.FontData.BoldAsString = "False"
        Appearance124.FontData.SizeInPoints = 8.0!
        Appearance124.TextHAlignAsString = "Center"
        Appearance124.TextVAlignAsString = "Middle"
        UltraGridColumn21.CellAppearance = Appearance124
        UltraGridColumn21.EditorControl = Me.UltraComboEditor1
        UltraGridColumn21.Header.VisiblePosition = 5
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn21.Width = 74
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21})
        UltraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn22.Header.VisiblePosition = 0
        UltraGridColumn22.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn22.Width = 108
        UltraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance125.FontData.BoldAsString = "False"
        Appearance125.FontData.SizeInPoints = 8.0!
        Appearance125.TextHAlignAsString = "Center"
        Appearance125.TextVAlignAsString = "Middle"
        UltraGridColumn23.CellAppearance = Appearance125
        UltraGridColumn23.EditorControl = Me.UltraComboEditor6
        UltraGridColumn23.Header.VisiblePosition = 1
        UltraGridColumn23.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn23.Width = 493
        UltraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn24.Header.VisiblePosition = 2
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.Width = 94
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn22, UltraGridColumn23, UltraGridColumn24})
        Me.dgvRanApro.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.dgvRanApro.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.dgvRanApro.DisplayLayout.InterBandSpacing = 18
        Me.dgvRanApro.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.FixedAddRowOnTop
        Me.dgvRanApro.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvRanApro.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvRanApro.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Appearance126.BackColor = System.Drawing.Color.Transparent
        Me.dgvRanApro.DisplayLayout.Override.CardAreaAppearance = Appearance126
        Appearance127.FontData.BoldAsString = "True"
        Appearance127.FontData.SizeInPoints = 9.0!
        Appearance127.ForeColor = System.Drawing.Color.Navy
        Me.dgvRanApro.DisplayLayout.Override.CellAppearance = Appearance127
        Me.dgvRanApro.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance128.BackColor = System.Drawing.Color.Navy
        Appearance128.FontData.BoldAsString = "True"
        Appearance128.FontData.ItalicAsString = "False"
        Appearance128.FontData.SizeInPoints = 10.0!
        Appearance128.ForeColor = System.Drawing.Color.White
        Appearance128.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvRanApro.DisplayLayout.Override.HeaderAppearance = Appearance128
        Appearance129.FontData.BoldAsString = "True"
        Appearance129.FontData.SizeInPoints = 9.0!
        Appearance129.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance129.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.dgvRanApro.DisplayLayout.Override.RowPreviewAppearance = Appearance129
        Appearance130.BackColor = System.Drawing.Color.Navy
        Appearance130.BorderColor = System.Drawing.Color.White
        Appearance130.FontData.BoldAsString = "True"
        Appearance130.ForeColor = System.Drawing.Color.White
        Appearance130.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance130.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance130.TextHAlignAsString = "Center"
        Appearance130.TextVAlignAsString = "Middle"
        Me.dgvRanApro.DisplayLayout.Override.RowSelectorAppearance = Appearance130
        Me.dgvRanApro.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None
        Me.dgvRanApro.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.dgvRanApro.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvRanApro.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance131.BackColor = System.Drawing.Color.Navy
        Appearance131.ForeColor = System.Drawing.Color.White
        Me.dgvRanApro.DisplayLayout.Override.SelectedRowAppearance = Appearance131
        Me.dgvRanApro.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvRanApro.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvRanApro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvRanApro.Location = New System.Drawing.Point(85, 20)
        Me.dgvRanApro.Name = "dgvRanApro"
        Me.dgvRanApro.Size = New System.Drawing.Size(680, 358)
        Me.dgvRanApro.TabIndex = 70
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.TabRangoAprobacion)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel19)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(822, 492)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'TabRangoAprobacion
        '
        Me.TabRangoAprobacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabRangoAprobacion.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.TabRangoAprobacion.Controls.Add(Me.UltraTabPageControl1)
        Me.TabRangoAprobacion.Controls.Add(Me.UltraTabPageControl3)
        Me.TabRangoAprobacion.Location = New System.Drawing.Point(0, 60)
        Me.TabRangoAprobacion.Name = "TabRangoAprobacion"
        Appearance105.FontData.SizeInPoints = 12.0!
        Me.TabRangoAprobacion.SelectedTabAppearance = Appearance105
        Me.TabRangoAprobacion.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.TabRangoAprobacion.Size = New System.Drawing.Size(822, 432)
        Me.TabRangoAprobacion.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon
        Me.TabRangoAprobacion.TabIndex = 74
        Me.TabRangoAprobacion.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab1.Key = "Consulta"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Consulta de Rangos de Aprobación"
        UltraTab3.Key = "Registrar"
        UltraTab3.TabPage = Me.UltraTabPageControl3
        UltraTab3.Text = "Registrar Rango de Aprobación"
        Me.TabRangoAprobacion.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab3})
        Me.TabRangoAprobacion.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(820, 404)
        '
        'UltraLabel19
        '
        Me.UltraLabel19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance66.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance66.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance66.ForeColor = System.Drawing.Color.White
        Appearance66.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance66.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance66.TextHAlignAsString = "Center"
        Appearance66.TextVAlignAsString = "Middle"
        Me.UltraLabel19.Appearance = Appearance66
        Me.UltraLabel19.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel19.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption
        Me.UltraLabel19.Location = New System.Drawing.Point(0, 10)
        Me.UltraLabel19.Name = "UltraLabel19"
        Me.UltraLabel19.Size = New System.Drawing.Size(822, 40)
        Me.UltraLabel19.TabIndex = 15
        Me.UltraLabel19.Text = "RANGOS DE APROBACIÓN"
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(677, 222)
        '
        'FrmRangosAprobacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 492)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmRangosAprobacion"
        Me.Text = " Maestro - Rangos de Aprobación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UltraComboEditor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraComboEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraComboEditor3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraComboEditor4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraComboEditor5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraComboEditor6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.DgvRangoAprobacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.Cia1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CodigoAprobacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSigno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFirmaUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.dgvRanApro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.TabRangoAprobacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabRangoAprobacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel19 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DgvRangoAprobacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraComboEditor1 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraComboEditor2 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraComboEditor3 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraDataSource2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents TabRangoAprobacion As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraComboEditor4 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraComboEditor5 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraComboEditor6 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents dgvRanApro As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents CboMoneda As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents CboSigno As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtDesde As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents TxtHasta As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents CodigoAprobacion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvFirmaUsuario As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource3 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents CmbUsuario As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Cia1 As Infragistics.Win.UltraWinGrid.UltraCombo
End Class
