<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporteCosteo
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
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem13 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem14 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem15 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem16 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem17 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem18 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem19 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem20 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem21 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem22 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem23 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem24 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReporteCosteo))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodCuenta", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuenta", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodCantera", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantera", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe", 5)
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Auxiliar", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Documento", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Lote", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Asiento", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Referencia", 10)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Refe2", 11)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Toneladas", 12)
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idconmay", 13)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Conceptos", 14)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(801)
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
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AYO", 0)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MESNRO", 1)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES", 2)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PLACOD", 3)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TRABAJADOR", 4)
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SEGURO", 5)
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO", 6)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(324)
        Dim ColScrollRegion13 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(290)
        Dim ColScrollRegion14 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion16 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion17 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion18 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion19 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion20 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion21 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion22 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion23 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion24 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AYO", 0)
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MESNRO", 1)
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES", 2)
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DIAS", 3)
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion25 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(449)
        Dim ColScrollRegion26 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion27 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion28 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion29 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion30 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion31 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion32 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion33 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion34 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion35 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion36 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion37 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(818)
        Dim ColScrollRegion38 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion39 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion40 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion41 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion42 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion43 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion44 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion45 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion46 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion47 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion48 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance126 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance129 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance130 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance131 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbMes = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.txtayo = New System.Windows.Forms.NumericUpDown
        Me.btncierre = New System.Windows.Forms.Button
        Me.btncosto = New System.Windows.Forms.Button
        Me.btnrevision = New System.Windows.Forms.Button
        Me.btnmanoobra = New System.Windows.Forms.Button
        Me.gbrevision = New System.Windows.Forms.GroupBox
        Me.chkCuenta9 = New System.Windows.Forms.CheckBox
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.btnimportar = New System.Windows.Forms.Button
        Me.btnexportar = New System.Windows.Forms.Button
        Me.gridRevision = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.gbmanoobra = New System.Windows.Forms.GroupBox
        Me.btnreplica = New System.Windows.Forms.Button
        Me.btneliminard = New System.Windows.Forms.Button
        Me.btnnuevos = New System.Windows.Forms.Button
        Me.btneliminars = New System.Windows.Forms.Button
        Me.btnnuevod = New System.Windows.Forms.Button
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.gridSeguro = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.gridDias = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.gridcostomin = New Infragistics.Win.UltraWinGrid.UltraGrid
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
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbrevision.SuspendLayout()
        CType(Me.gridRevision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbmanoobra.SuspendLayout()
        CType(Me.gridSeguro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridDias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridcostomin, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 34)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1067, 554)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.UltraLabel16)
        Me.Panel1.Controls.Add(Me.cmbMes)
        Me.Panel1.Controls.Add(Me.UltraLabel6)
        Me.Panel1.Controls.Add(Me.txtayo)
        Me.Panel1.Controls.Add(Me.btncierre)
        Me.Panel1.Controls.Add(Me.btncosto)
        Me.Panel1.Controls.Add(Me.btnrevision)
        Me.Panel1.Controls.Add(Me.btnmanoobra)
        Me.Panel1.Controls.Add(Me.gbrevision)
        Me.Panel1.Controls.Add(Me.gbmanoobra)
        Me.Panel1.Controls.Add(Me.gridcostomin)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1067, 554)
        Me.Panel1.TabIndex = 176
        '
        'Button1
        '
        Me.Button1.Image = Global.SIP_Presentacion.My.Resources.Resources.page_excel
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(20, 285)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 37)
        Me.Button1.TabIndex = 198
        Me.Button1.Text = "Reporte comparativo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UltraLabel16
        '
        Appearance33.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel16.Appearance = Appearance33
        Me.UltraLabel16.AutoSize = True
        Me.UltraLabel16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel16.Location = New System.Drawing.Point(20, 54)
        Me.UltraLabel16.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(30, 17)
        Me.UltraLabel16.TabIndex = 193
        Me.UltraLabel16.Text = "Mes"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMes.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem13.DataValue = "1"
        ValueListItem13.DisplayText = "ENERO"
        ValueListItem14.DataValue = "2"
        ValueListItem14.DisplayText = "FEBRERO"
        ValueListItem15.DataValue = "3"
        ValueListItem15.DisplayText = "MARZO"
        ValueListItem16.DataValue = "4"
        ValueListItem16.DisplayText = "ABRIL"
        ValueListItem17.DataValue = "5"
        ValueListItem17.DisplayText = "MAYO"
        ValueListItem18.DataValue = "6"
        ValueListItem18.DisplayText = "JUNIO"
        ValueListItem19.DataValue = "7"
        ValueListItem19.DisplayText = "JULIO"
        ValueListItem20.DataValue = "8"
        ValueListItem20.DisplayText = "AGOSTO"
        ValueListItem21.DataValue = "9"
        ValueListItem21.DisplayText = "SETIEMBRE"
        ValueListItem22.DataValue = "10"
        ValueListItem22.DisplayText = "OCTUBRE"
        ValueListItem23.DataValue = "11"
        ValueListItem23.DisplayText = "NOVIEMBRE"
        ValueListItem24.DataValue = "12"
        ValueListItem24.DisplayText = "DICIEMBRE"
        Me.cmbMes.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem13, ValueListItem14, ValueListItem15, ValueListItem16, ValueListItem17, ValueListItem18, ValueListItem19, ValueListItem20, ValueListItem21, ValueListItem22, ValueListItem23, ValueListItem24})
        Me.cmbMes.Location = New System.Drawing.Point(54, 52)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(150, 21)
        Me.cmbMes.TabIndex = 192
        '
        'UltraLabel6
        '
        Appearance38.BackColor = System.Drawing.Color.Transparent
        Appearance38.TextHAlignAsString = "Center"
        Appearance38.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance38
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(20, 21)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(24, 14)
        Me.UltraLabel6.TabIndex = 191
        Me.UltraLabel6.Text = "Año"
        '
        'txtayo
        '
        Me.txtayo.Location = New System.Drawing.Point(54, 19)
        Me.txtayo.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtayo.Name = "txtayo"
        Me.txtayo.Size = New System.Drawing.Size(57, 20)
        Me.txtayo.TabIndex = 190
        Me.txtayo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtayo.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'btncierre
        '
        Me.btncierre.Image = Global.SIP_Presentacion.My.Resources.Resources.Settings
        Me.btncierre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncierre.Location = New System.Drawing.Point(20, 343)
        Me.btncierre.Name = "btncierre"
        Me.btncierre.Size = New System.Drawing.Size(191, 37)
        Me.btncierre.TabIndex = 3
        Me.btncierre.Text = "Cierre Mes"
        Me.btncierre.UseVisualStyleBackColor = True
        '
        'btncosto
        '
        Me.btncosto.Image = Global.SIP_Presentacion.My.Resources.Resources.page_excel
        Me.btncosto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncosto.Location = New System.Drawing.Point(20, 226)
        Me.btncosto.Name = "btncosto"
        Me.btncosto.Size = New System.Drawing.Size(191, 37)
        Me.btncosto.TabIndex = 2
        Me.btncosto.Text = "Costo Mineral"
        Me.btncosto.UseVisualStyleBackColor = True
        '
        'btnrevision
        '
        Me.btnrevision.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.btnrevision.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrevision.Location = New System.Drawing.Point(20, 167)
        Me.btnrevision.Name = "btnrevision"
        Me.btnrevision.Size = New System.Drawing.Size(191, 37)
        Me.btnrevision.TabIndex = 1
        Me.btnrevision.Text = "Revision de Canteras"
        Me.btnrevision.UseVisualStyleBackColor = True
        '
        'btnmanoobra
        '
        Me.btnmanoobra.Image = Global.SIP_Presentacion.My.Resources.Resources.page_excel
        Me.btnmanoobra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnmanoobra.Location = New System.Drawing.Point(20, 108)
        Me.btnmanoobra.Name = "btnmanoobra"
        Me.btnmanoobra.Size = New System.Drawing.Size(191, 37)
        Me.btnmanoobra.TabIndex = 0
        Me.btnmanoobra.Text = "Mano de Obra"
        Me.btnmanoobra.UseVisualStyleBackColor = True
        '
        'gbrevision
        '
        Me.gbrevision.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbrevision.Controls.Add(Me.chkCuenta9)
        Me.gbrevision.Controls.Add(Me.lblmensaje)
        Me.gbrevision.Controls.Add(Me.btnimportar)
        Me.gbrevision.Controls.Add(Me.btnexportar)
        Me.gbrevision.Controls.Add(Me.gridRevision)
        Me.gbrevision.Location = New System.Drawing.Point(232, 44)
        Me.gbrevision.Name = "gbrevision"
        Me.gbrevision.Size = New System.Drawing.Size(826, 491)
        Me.gbrevision.TabIndex = 195
        Me.gbrevision.TabStop = False
        Me.gbrevision.Text = "Revision de Canteras"
        Me.gbrevision.Visible = False
        '
        'chkCuenta9
        '
        Me.chkCuenta9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkCuenta9.AutoSize = True
        Me.chkCuenta9.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chkCuenta9.Location = New System.Drawing.Point(12, 455)
        Me.chkCuenta9.Name = "chkCuenta9"
        Me.chkCuenta9.Size = New System.Drawing.Size(176, 17)
        Me.chkCuenta9.TabIndex = 198
        Me.chkCuenta9.Text = "Aplica solo Exportar (inc. Cta. 9)"
        Me.chkCuenta9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkCuenta9.UseVisualStyleBackColor = True
        Me.chkCuenta9.Visible = False
        '
        'lblmensaje
        '
        Me.lblmensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance53.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Appearance53.FontData.BoldAsString = "True"
        Appearance53.FontData.SizeInPoints = 10.0!
        Appearance53.ForeColor = System.Drawing.Color.SteelBlue
        Appearance53.TextHAlignAsString = "Center"
        Appearance53.TextVAlignAsString = "Middle"
        Me.lblmensaje.Appearance = Appearance53
        Me.lblmensaje.Location = New System.Drawing.Point(-230, 182)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(1071, 39)
        Me.lblmensaje.TabIndex = 167
        Me.lblmensaje.Text = "Procesando Datos..."
        Me.lblmensaje.Visible = False
        '
        'btnimportar
        '
        Me.btnimportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnimportar.Image = Global.SIP_Presentacion.My.Resources.Resources.page_excel
        Me.btnimportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnimportar.Location = New System.Drawing.Point(515, 444)
        Me.btnimportar.Name = "btnimportar"
        Me.btnimportar.Size = New System.Drawing.Size(147, 37)
        Me.btnimportar.TabIndex = 196
        Me.btnimportar.Text = "Importar canteras"
        Me.btnimportar.UseVisualStyleBackColor = True
        '
        'btnexportar
        '
        Me.btnexportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexportar.Image = Global.SIP_Presentacion.My.Resources.Resources.page_excel
        Me.btnexportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnexportar.Location = New System.Drawing.Point(667, 444)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(147, 37)
        Me.btnexportar.TabIndex = 195
        Me.btnexportar.Text = "Exportar"
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'gridRevision
        '
        Me.gridRevision.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.SystemColors.Window
        Appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridRevision.DisplayLayout.Appearance = Appearance3
        Me.gridRevision.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
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
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.Width = 8
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 1
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.Width = 64
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn4.Width = 110
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn5.Width = 122
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn6.Width = 65
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance5
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn7.Width = 82
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn8.Width = 46
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn9.Width = 81
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn10.Width = 66
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn11.Width = 74
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn12.Width = 98
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn13.Width = 60
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance6
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn14.Width = 78
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn15.Width = 45
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 93
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16})
        Me.gridRevision.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridRevision.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridRevision.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridRevision.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridRevision.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridRevision.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridRevision.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridRevision.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridRevision.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridRevision.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridRevision.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridRevision.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridRevision.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridRevision.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridRevision.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.SystemColors.Window
        Me.gridRevision.DisplayLayout.GroupByBox.Appearance = Appearance7
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridRevision.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
        Me.gridRevision.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridRevision.DisplayLayout.GroupByBox.Hidden = True
        Appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance10.BackColor2 = System.Drawing.SystemColors.Control
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridRevision.DisplayLayout.GroupByBox.PromptAppearance = Appearance10
        Me.gridRevision.DisplayLayout.MaxColScrollRegions = 1
        Me.gridRevision.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridRevision.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridRevision.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridRevision.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Me.gridRevision.DisplayLayout.Override.CardAreaAppearance = Appearance11
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridRevision.DisplayLayout.Override.CellAppearance = Appearance12
        Me.gridRevision.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridRevision.DisplayLayout.Override.CellPadding = 0
        Me.gridRevision.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridRevision.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridRevision.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridRevision.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance13.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridRevision.DisplayLayout.Override.FilterRowAppearance = Appearance13
        Me.gridRevision.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridRevision.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridRevision.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance14.BackColor = System.Drawing.SystemColors.Control
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.gridRevision.DisplayLayout.Override.GroupByRowAppearance = Appearance14
        Appearance15.FontData.Name = "Arial Narrow"
        Appearance15.FontData.SizeInPoints = 10.0!
        Appearance15.TextHAlignAsString = "Left"
        Me.gridRevision.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.gridRevision.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridRevision.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridRevision.DisplayLayout.Override.MinRowHeight = 24
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.TextVAlignAsString = "Middle"
        Me.gridRevision.DisplayLayout.Override.RowAppearance = Appearance16
        Me.gridRevision.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridRevision.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridRevision.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridRevision.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
        Me.gridRevision.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridRevision.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridRevision.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridRevision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridRevision.Location = New System.Drawing.Point(11, 19)
        Me.gridRevision.Name = "gridRevision"
        Me.gridRevision.Size = New System.Drawing.Size(803, 419)
        Me.gridRevision.TabIndex = 194
        '
        'gbmanoobra
        '
        Me.gbmanoobra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbmanoobra.Controls.Add(Me.btnreplica)
        Me.gbmanoobra.Controls.Add(Me.btneliminard)
        Me.gbmanoobra.Controls.Add(Me.btnnuevos)
        Me.gbmanoobra.Controls.Add(Me.btneliminars)
        Me.gbmanoobra.Controls.Add(Me.btnnuevod)
        Me.gbmanoobra.Controls.Add(Me.UltraLabel2)
        Me.gbmanoobra.Controls.Add(Me.UltraLabel1)
        Me.gbmanoobra.Controls.Add(Me.gridSeguro)
        Me.gbmanoobra.Controls.Add(Me.gridDias)
        Me.gbmanoobra.Location = New System.Drawing.Point(232, 44)
        Me.gbmanoobra.Name = "gbmanoobra"
        Me.gbmanoobra.Size = New System.Drawing.Size(826, 491)
        Me.gbmanoobra.TabIndex = 197
        Me.gbmanoobra.TabStop = False
        Me.gbmanoobra.Text = "Mano de Obra"
        Me.gbmanoobra.Visible = False
        '
        'btnreplica
        '
        Me.btnreplica.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnreplica.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.btnreplica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnreplica.Location = New System.Drawing.Point(515, 450)
        Me.btnreplica.Name = "btnreplica"
        Me.btnreplica.Size = New System.Drawing.Size(127, 25)
        Me.btnreplica.TabIndex = 205
        Me.btnreplica.Text = "Replica mes anterior"
        Me.btnreplica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnreplica.UseVisualStyleBackColor = True
        '
        'btneliminard
        '
        Me.btneliminard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btneliminard.Image = Global.SIP_Presentacion.My.Resources.Resources.cancel
        Me.btneliminard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btneliminard.Location = New System.Drawing.Point(282, 450)
        Me.btneliminard.Name = "btneliminard"
        Me.btneliminard.Size = New System.Drawing.Size(80, 25)
        Me.btneliminard.TabIndex = 204
        Me.btneliminard.Text = "Eliminar"
        Me.btneliminard.UseVisualStyleBackColor = True
        '
        'btnnuevos
        '
        Me.btnnuevos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnnuevos.Image = Global.SIP_Presentacion.My.Resources.Resources.table
        Me.btnnuevos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnnuevos.Location = New System.Drawing.Point(648, 450)
        Me.btnnuevos.Name = "btnnuevos"
        Me.btnnuevos.Size = New System.Drawing.Size(80, 25)
        Me.btnnuevos.TabIndex = 203
        Me.btnnuevos.Text = "Nuevo"
        Me.btnnuevos.UseVisualStyleBackColor = True
        '
        'btneliminars
        '
        Me.btneliminars.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btneliminars.Image = Global.SIP_Presentacion.My.Resources.Resources.cancel
        Me.btneliminars.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btneliminars.Location = New System.Drawing.Point(734, 450)
        Me.btneliminars.Name = "btneliminars"
        Me.btneliminars.Size = New System.Drawing.Size(80, 25)
        Me.btneliminars.TabIndex = 202
        Me.btneliminars.Text = "Eliminar"
        Me.btneliminars.UseVisualStyleBackColor = True
        '
        'btnnuevod
        '
        Me.btnnuevod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnnuevod.Image = Global.SIP_Presentacion.My.Resources.Resources.table
        Me.btnnuevod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnnuevod.Location = New System.Drawing.Point(196, 450)
        Me.btnnuevod.Name = "btnnuevod"
        Me.btnnuevod.Size = New System.Drawing.Size(80, 25)
        Me.btnnuevod.TabIndex = 201
        Me.btnnuevod.Text = "Nuevo"
        Me.btnnuevod.UseVisualStyleBackColor = True
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Center"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance9
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(488, 29)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(130, 14)
        Me.UltraLabel2.TabIndex = 199
        Me.UltraLabel2.Text = "Seguro de Vida Personal"
        '
        'UltraLabel1
        '
        Appearance39.BackColor = System.Drawing.Color.Transparent
        Appearance39.TextHAlignAsString = "Center"
        Appearance39.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance39
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 29)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(66, 14)
        Me.UltraLabel1.TabIndex = 198
        Me.UltraLabel1.Text = "Dias habiles"
        '
        'gridSeguro
        '
        Me.gridSeguro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridSeguro.DisplayLayout.Appearance = Appearance1
        Me.gridSeguro.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn17.Header.Appearance = Appearance2
        UltraGridColumn17.Header.Caption = ""
        UltraGridColumn17.Header.VisiblePosition = 0
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.MaxWidth = 25
        UltraGridColumn17.MinWidth = 20
        UltraGridColumn17.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn17.Width = 20
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn18.Header.VisiblePosition = 1
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn18.Width = 25
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn19.Header.VisiblePosition = 2
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn19.Width = 76
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn20.Header.VisiblePosition = 3
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn20.Width = 100
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn21.Header.VisiblePosition = 4
        UltraGridColumn21.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn21.Width = 23
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn22.Header.VisiblePosition = 5
        UltraGridColumn22.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn22.Width = 204
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance21
        UltraGridColumn23.Header.VisiblePosition = 6
        UltraGridColumn23.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn23.Width = 59
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn24.Header.VisiblePosition = 7
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn24.Width = 104
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24})
        Me.gridSeguro.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridSeguro.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridSeguro.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion16)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion17)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion18)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion19)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion20)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion21)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion22)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion23)
        Me.gridSeguro.DisplayLayout.ColScrollRegions.Add(ColScrollRegion24)
        Me.gridSeguro.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSeguro.DisplayLayout.GroupByBox.Appearance = Appearance23
        Appearance25.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSeguro.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance25
        Me.gridSeguro.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridSeguro.DisplayLayout.GroupByBox.Hidden = True
        Appearance27.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance27.BackColor2 = System.Drawing.SystemColors.Control
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSeguro.DisplayLayout.GroupByBox.PromptAppearance = Appearance27
        Me.gridSeguro.DisplayLayout.MaxColScrollRegions = 1
        Me.gridSeguro.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridSeguro.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridSeguro.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridSeguro.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Me.gridSeguro.DisplayLayout.Override.CardAreaAppearance = Appearance28
        Appearance29.BorderColor = System.Drawing.Color.Silver
        Appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridSeguro.DisplayLayout.Override.CellAppearance = Appearance29
        Me.gridSeguro.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridSeguro.DisplayLayout.Override.CellPadding = 0
        Me.gridSeguro.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridSeguro.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridSeguro.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridSeguro.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance30.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance30.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridSeguro.DisplayLayout.Override.FilterRowAppearance = Appearance30
        Me.gridSeguro.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridSeguro.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridSeguro.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance31.BackColor = System.Drawing.SystemColors.Control
        Appearance31.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance31.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSeguro.DisplayLayout.Override.GroupByRowAppearance = Appearance31
        Appearance32.FontData.Name = "Arial Narrow"
        Appearance32.FontData.SizeInPoints = 10.0!
        Appearance32.TextHAlignAsString = "Left"
        Me.gridSeguro.DisplayLayout.Override.HeaderAppearance = Appearance32
        Me.gridSeguro.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridSeguro.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridSeguro.DisplayLayout.Override.MinRowHeight = 24
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Appearance34.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance34.TextVAlignAsString = "Middle"
        Me.gridSeguro.DisplayLayout.Override.RowAppearance = Appearance34
        Me.gridSeguro.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridSeguro.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridSeguro.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance35.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridSeguro.DisplayLayout.Override.TemplateAddRowAppearance = Appearance35
        Me.gridSeguro.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridSeguro.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridSeguro.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridSeguro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridSeguro.Location = New System.Drawing.Point(488, 49)
        Me.gridSeguro.Name = "gridSeguro"
        Me.gridSeguro.Size = New System.Drawing.Size(326, 389)
        Me.gridSeguro.TabIndex = 197
        '
        'gridDias
        '
        Me.gridDias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance36.BackColor = System.Drawing.SystemColors.Window
        Appearance36.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridDias.DisplayLayout.Appearance = Appearance36
        Me.gridDias.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn25.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance37.Image = CType(resources.GetObject("Appearance37.Image"), Object)
        Appearance37.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance37.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn25.Header.Appearance = Appearance37
        UltraGridColumn25.Header.Caption = ""
        UltraGridColumn25.Header.VisiblePosition = 0
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.MaxWidth = 25
        UltraGridColumn25.MinWidth = 20
        UltraGridColumn25.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn25.Width = 20
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn26.Header.VisiblePosition = 1
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn26.Width = 26
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn27.Header.Caption = "N° MES"
        UltraGridColumn27.Header.VisiblePosition = 2
        UltraGridColumn27.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn27.Width = 39
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn28.Header.VisiblePosition = 3
        UltraGridColumn28.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn28.Width = 215
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance22
        UltraGridColumn29.Header.Caption = "N° DIAS"
        UltraGridColumn29.Header.VisiblePosition = 4
        UltraGridColumn29.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn29.Width = 157
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29})
        Me.gridDias.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.gridDias.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDias.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion25)
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion26)
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion27)
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion28)
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion29)
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion30)
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion31)
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion32)
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion33)
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion34)
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion35)
        Me.gridDias.DisplayLayout.ColScrollRegions.Add(ColScrollRegion36)
        Me.gridDias.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance41.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance41.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance41.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDias.DisplayLayout.GroupByBox.Appearance = Appearance41
        Appearance42.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDias.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance42
        Me.gridDias.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDias.DisplayLayout.GroupByBox.Hidden = True
        Appearance44.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance44.BackColor2 = System.Drawing.SystemColors.Control
        Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance44.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDias.DisplayLayout.GroupByBox.PromptAppearance = Appearance44
        Me.gridDias.DisplayLayout.MaxColScrollRegions = 1
        Me.gridDias.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridDias.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDias.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridDias.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance45.BackColor = System.Drawing.SystemColors.Window
        Me.gridDias.DisplayLayout.Override.CardAreaAppearance = Appearance45
        Appearance46.BorderColor = System.Drawing.Color.Silver
        Appearance46.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridDias.DisplayLayout.Override.CellAppearance = Appearance46
        Me.gridDias.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridDias.DisplayLayout.Override.CellPadding = 0
        Me.gridDias.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridDias.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridDias.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridDias.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance47.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance47.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridDias.DisplayLayout.Override.FilterRowAppearance = Appearance47
        Me.gridDias.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridDias.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridDias.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance48.BackColor = System.Drawing.SystemColors.Control
        Appearance48.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance48.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance48.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDias.DisplayLayout.Override.GroupByRowAppearance = Appearance48
        Appearance49.FontData.Name = "Arial Narrow"
        Appearance49.FontData.SizeInPoints = 10.0!
        Appearance49.TextHAlignAsString = "Left"
        Me.gridDias.DisplayLayout.Override.HeaderAppearance = Appearance49
        Me.gridDias.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridDias.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridDias.DisplayLayout.Override.MinRowHeight = 24
        Appearance51.BackColor = System.Drawing.SystemColors.Window
        Appearance51.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance51.TextVAlignAsString = "Middle"
        Me.gridDias.DisplayLayout.Override.RowAppearance = Appearance51
        Me.gridDias.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridDias.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridDias.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance52.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridDias.DisplayLayout.Override.TemplateAddRowAppearance = Appearance52
        Me.gridDias.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridDias.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridDias.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDias.Location = New System.Drawing.Point(12, 49)
        Me.gridDias.Name = "gridDias"
        Me.gridDias.Size = New System.Drawing.Size(451, 389)
        Me.gridDias.TabIndex = 196
        '
        'gridcostomin
        '
        Me.gridcostomin.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance40.BackColor = System.Drawing.SystemColors.Window
        Appearance40.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridcostomin.DisplayLayout.Appearance = Appearance40
        Me.gridcostomin.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn30.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance50.Image = CType(resources.GetObject("Appearance50.Image"), Object)
        Appearance50.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance50.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn30.Header.Appearance = Appearance50
        UltraGridColumn30.Header.Caption = ""
        UltraGridColumn30.Header.VisiblePosition = 0
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.MaxWidth = 25
        UltraGridColumn30.MinWidth = 20
        UltraGridColumn30.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn30.Width = 20
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn30})
        Me.gridcostomin.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.gridcostomin.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridcostomin.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion37)
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion38)
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion39)
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion40)
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion41)
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion42)
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion43)
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion44)
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion45)
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion46)
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion47)
        Me.gridcostomin.DisplayLayout.ColScrollRegions.Add(ColScrollRegion48)
        Me.gridcostomin.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance122.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance122.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance122.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance122.BorderColor = System.Drawing.SystemColors.Window
        Me.gridcostomin.DisplayLayout.GroupByBox.Appearance = Appearance122
        Appearance123.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridcostomin.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance123
        Me.gridcostomin.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridcostomin.DisplayLayout.GroupByBox.Hidden = True
        Appearance124.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance124.BackColor2 = System.Drawing.SystemColors.Control
        Appearance124.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance124.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridcostomin.DisplayLayout.GroupByBox.PromptAppearance = Appearance124
        Me.gridcostomin.DisplayLayout.MaxColScrollRegions = 1
        Me.gridcostomin.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridcostomin.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridcostomin.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridcostomin.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance125.BackColor = System.Drawing.SystemColors.Window
        Me.gridcostomin.DisplayLayout.Override.CardAreaAppearance = Appearance125
        Appearance126.BorderColor = System.Drawing.Color.Silver
        Appearance126.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridcostomin.DisplayLayout.Override.CellAppearance = Appearance126
        Me.gridcostomin.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridcostomin.DisplayLayout.Override.CellPadding = 0
        Me.gridcostomin.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridcostomin.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridcostomin.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridcostomin.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance127.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance127.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridcostomin.DisplayLayout.Override.FilterRowAppearance = Appearance127
        Me.gridcostomin.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridcostomin.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridcostomin.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance128.BackColor = System.Drawing.SystemColors.Control
        Appearance128.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance128.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance128.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance128.BorderColor = System.Drawing.SystemColors.Window
        Me.gridcostomin.DisplayLayout.Override.GroupByRowAppearance = Appearance128
        Appearance129.FontData.Name = "Arial Narrow"
        Appearance129.FontData.SizeInPoints = 10.0!
        Appearance129.TextHAlignAsString = "Left"
        Me.gridcostomin.DisplayLayout.Override.HeaderAppearance = Appearance129
        Me.gridcostomin.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridcostomin.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridcostomin.DisplayLayout.Override.MinRowHeight = 24
        Appearance130.BackColor = System.Drawing.SystemColors.Window
        Appearance130.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance130.TextVAlignAsString = "Middle"
        Me.gridcostomin.DisplayLayout.Override.RowAppearance = Appearance130
        Me.gridcostomin.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridcostomin.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridcostomin.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance131.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridcostomin.DisplayLayout.Override.TemplateAddRowAppearance = Appearance131
        Me.gridcostomin.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridcostomin.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridcostomin.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridcostomin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridcostomin.Location = New System.Drawing.Point(232, 63)
        Me.gridcostomin.Name = "gridcostomin"
        Me.gridcostomin.Size = New System.Drawing.Size(820, 123)
        Me.gridcostomin.TabIndex = 196
        Me.gridcostomin.Visible = False
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
        Me.Tab1.Size = New System.Drawing.Size(1071, 591)
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
        UltraTab3.Text = "REPORTES"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1067, 554)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmReporteCosteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1071, 591)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmReporteCosteo"
        Me.Text = "FrmReporteCosteo"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbrevision.ResumeLayout(False)
        Me.gbrevision.PerformLayout()
        CType(Me.gridRevision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbmanoobra.ResumeLayout(False)
        Me.gbmanoobra.PerformLayout()
        CType(Me.gridSeguro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridDias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridcostomin, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btncierre As System.Windows.Forms.Button
    Friend WithEvents btncosto As System.Windows.Forms.Button
    Friend WithEvents btnrevision As System.Windows.Forms.Button
    Friend WithEvents btnmanoobra As System.Windows.Forms.Button
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtayo As System.Windows.Forms.NumericUpDown
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbMes As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents gridRevision As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gbrevision As System.Windows.Forms.GroupBox
    Friend WithEvents btnexportar As System.Windows.Forms.Button
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents gridcostomin As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Source2 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents gbmanoobra As System.Windows.Forms.GroupBox
    Friend WithEvents gridDias As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridSeguro As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Source3 As System.Windows.Forms.BindingSource
    Friend WithEvents Source4 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnnuevos As System.Windows.Forms.Button
    Friend WithEvents btneliminars As System.Windows.Forms.Button
    Friend WithEvents btnnuevod As System.Windows.Forms.Button
    Friend WithEvents btneliminard As System.Windows.Forms.Button
    Friend WithEvents btnreplica As System.Windows.Forms.Button
    Friend WithEvents btnimportar As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkCuenta9 As System.Windows.Forms.CheckBox
End Class
