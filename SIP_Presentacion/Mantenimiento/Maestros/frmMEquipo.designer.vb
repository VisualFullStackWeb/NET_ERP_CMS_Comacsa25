<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMEquipo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMEquipo))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo", 0)
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LinNeg", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FamiliaEq", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Status", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FamiliaEqId", 6)
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo", 0)
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Atributo", 1)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Valor", 2)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Und", 3, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDato", 4)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Longitud", 5)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Decimal", 6)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Oblig", 7)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Control", 8)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NomEq", 9)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("status", 10)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDCatalogo", 11)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDCatalogoOrigen", 12)
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodAtrib", 0)
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Atributo", 1)
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Valor", 2)
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Und", 3, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDato", 4)
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Longitud", 5)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Decimal", 6)
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Oblig", 7)
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("status", 8)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDComponente", 9)
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAtributo", 10)
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDFamiliaEquipo", 11)
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTreeColumnSet1 As Infragistics.Win.UltraWinTree.UltraTreeColumnSet = New Infragistics.Win.UltraWinTree.UltraTreeColumnSet
        Dim UltraTreeNodeColumn1 As Infragistics.Win.UltraWinTree.UltraTreeNodeColumn = New Infragistics.Win.UltraWinTree.UltraTreeNodeColumn
        Dim UltraTreeNodeColumn2 As Infragistics.Win.UltraWinTree.UltraTreeNodeColumn = New Infragistics.Win.UltraWinTree.UltraTreeNodeColumn
        Dim UltraTreeNodeColumn3 As Infragistics.Win.UltraWinTree.UltraTreeNodeColumn = New Infragistics.Win.UltraWinTree.UltraTreeNodeColumn
        Dim UltraTreeNodeColumn4 As Infragistics.Win.UltraWinTree.UltraTreeNodeColumn = New Infragistics.Win.UltraWinTree.UltraTreeNodeColumn
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo", 0)
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 1)
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EncagadoArea", 2)
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoMantto", 3)
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_Presp", 4, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda", 5)
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoPresup", 6)
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoTotal", 7)
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaInicio", 8)
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTerminacion", 9)
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado", 10)
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.Btn5 = New Infragistics.Win.Misc.UltraButton
        Me.Txt7 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.Cbo1 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Cbo2 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Btn4 = New Infragistics.Win.Misc.UltraButton
        Me.Txt6 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.Btn3 = New Infragistics.Win.Misc.UltraButton
        Me.Txt5 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.Btn1 = New Infragistics.Win.Misc.UltraButton
        Me.Txt3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.Btn2 = New Infragistics.Win.Misc.UltraButton
        Me.Cbo3 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid3 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton
        Me.UltraTextEditor1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.Tree1 = New Infragistics.Win.UltraWinTree.UltraTree
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Ptb1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Ptb2 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid4 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Ofd1 = New System.Windows.Forms.OpenFileDialog
        Me.Ofd2 = New System.Windows.Forms.OpenFileDialog
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraStatusBar1.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.Txt7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.Grid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tree1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl4.SuspendLayout()
        Me.UltraTabPageControl5.SuspendLayout()
        Me.UltraTabPageControl6.SuspendLayout()
        CType(Me.Grid4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BackColor = System.Drawing.Color.Transparent
        Me.BindingNavigator1.BindingSource = Me.Source1
        Me.BindingNavigator1.CountItem = Me.ToolStripLabel1
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.ToolStripTextBox1, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator7, Me.ToolStripButton5, Me.ToolStripSeparator8})
        Me.BindingNavigator1.Location = New System.Drawing.Point(2, 4)
        Me.BindingNavigator1.MoveFirstItem = Me.ToolStripButton4
        Me.BindingNavigator1.MoveLastItem = Me.ToolStripButton1
        Me.BindingNavigator1.MoveNextItem = Me.ToolStripButton2
        Me.BindingNavigator1.MovePreviousItem = Me.ToolStripButton3
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.ToolStripTextBox1
        Me.BindingNavigator1.Size = New System.Drawing.Size(337, 25)
        Me.BindingNavigator1.TabIndex = 141
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(38, 22)
        Me.ToolStripLabel1.Text = "de {0}"
        Me.ToolStripLabel1.ToolTipText = "Número total de elementos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Mover último"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Mover siguiente"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Posición"
        Me.ToolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripTextBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 23)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolStripTextBox1.ToolTipText = "Posición actual"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Mover anterior"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Mover primero"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(122, 22)
        Me.ToolStripButton5.Text = "SELECCIONAR"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Grid1)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraStatusBar1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(743, 413)
        '
        'Grid1
        '
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid1.DisplayLayout.Appearance = Appearance4
        Me.Grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance24.Image = CType(resources.GetObject("Appearance24.Image"), Object)
        Appearance24.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance24.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance24
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance30.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance30
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance34.TextHAlignAsString = "Center"
        UltraGridColumn2.Header.Appearance = Appearance34
        UltraGridColumn2.Header.Caption = "Código"
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.MaxWidth = 80
        UltraGridColumn2.MinWidth = 80
        UltraGridColumn2.Width = 80
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn3.Header.Caption = "Descripción"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.MinWidth = 250
        UltraGridColumn3.Width = 331
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn4.Header.Caption = "Lin.Neg."
        UltraGridColumn4.Header.VisiblePosition = 1
        UltraGridColumn4.MinWidth = 45
        UltraGridColumn4.Width = 46
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn5.Header.Caption = "Familia Eq."
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.MinWidth = 100
        UltraGridColumn5.Width = 165
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 81
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 89
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 92
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8})
        Me.Grid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance35.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance35.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance35.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.GroupByBox.Appearance = Appearance35
        Appearance36.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance36
        Me.Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance37.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance37.BackColor2 = System.Drawing.SystemColors.Control
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance37.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance37
        Me.Grid1.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid1.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.CardAreaAppearance = Appearance38
        Appearance39.BorderColor = System.Drawing.Color.Silver
        Appearance39.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid1.DisplayLayout.Override.CellAppearance = Appearance39
        Me.Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid1.DisplayLayout.Override.CellPadding = 0
        Me.Grid1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance40.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance40.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Grid1.DisplayLayout.Override.FilterRowAppearance = Appearance40
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance41.BackColor = System.Drawing.SystemColors.Control
        Appearance41.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance41.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance41.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.GroupByRowAppearance = Appearance41
        Appearance42.FontData.Name = "Arial Narrow"
        Appearance42.FontData.SizeInPoints = 10.0!
        Appearance42.TextHAlignAsString = "Left"
        Me.Grid1.DisplayLayout.Override.HeaderAppearance = Appearance42
        Me.Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid1.DisplayLayout.Override.MinRowHeight = 24
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Appearance43.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance43.TextVAlignAsString = "Middle"
        Me.Grid1.DisplayLayout.Override.RowAppearance = Appearance43
        Me.Grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance44.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance44
        Me.Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.Location = New System.Drawing.Point(0, 24)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(743, 389)
        Me.Grid1.TabIndex = 140
        Me.Grid1.Text = "UltraGrid1"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraStatusBar1.Controls.Add(Me.BindingNavigator1)
        Me.UltraStatusBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 0)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        UltraStatusPanel1.Control = Me.BindingNavigator1
        UltraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        Me.UltraStatusBar1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1})
        Me.UltraStatusBar1.Size = New System.Drawing.Size(743, 24)
        Me.UltraStatusBar1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraStatusBar1.TabIndex = 1
        Me.UltraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.Grid2)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(2, 35)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(743, 413)
        '
        'Grid2
        '
        Me.Grid2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance45.BackColor = System.Drawing.SystemColors.Window
        Appearance45.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid2.DisplayLayout.Appearance = Appearance45
        Me.Grid2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance46.Image = CType(resources.GetObject("Appearance46.Image"), Object)
        Appearance46.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance46.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn9.Header.Appearance = Appearance46
        UltraGridColumn9.Header.Caption = ""
        UltraGridColumn9.Header.VisiblePosition = 0
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.MaxWidth = 25
        UltraGridColumn9.MinWidth = 20
        UltraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn9.Width = 20
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance47.TextHAlignAsString = "Center"
        UltraGridColumn10.CellAppearance = Appearance47
        UltraGridColumn10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance48.TextHAlignAsString = "Center"
        UltraGridColumn10.Header.Appearance = Appearance48
        UltraGridColumn10.Header.Caption = "Código"
        UltraGridColumn10.Header.VisiblePosition = 1
        UltraGridColumn10.MaxWidth = 100
        UltraGridColumn10.MinWidth = 60
        UltraGridColumn10.Width = 62
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn11.Header.VisiblePosition = 2
        UltraGridColumn11.MinWidth = 200
        UltraGridColumn11.Width = 389
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn12.Header.VisiblePosition = 3
        UltraGridColumn12.MaxWidth = 150
        UltraGridColumn12.MinWidth = 80
        UltraGridColumn12.Width = 150
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn13.Header.VisiblePosition = 4
        UltraGridColumn13.MaxWidth = 80
        UltraGridColumn13.MinWidth = 60
        UltraGridColumn13.Width = 80
        UltraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn14.Header.VisiblePosition = 5
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.Width = 43
        UltraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn15.Header.VisiblePosition = 6
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 44
        UltraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn16.Header.VisiblePosition = 7
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 39
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn17.Header.VisiblePosition = 8
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 45
        UltraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn18.Header.VisiblePosition = 9
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 49
        UltraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn19.Header.VisiblePosition = 10
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.Width = 54
        UltraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn20.Header.VisiblePosition = 11
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 59
        UltraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn21.Header.VisiblePosition = 12
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 89
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn22.Header.VisiblePosition = 13
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 84
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22})
        Me.Grid2.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.Grid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance49.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance49.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance49.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.GroupByBox.Appearance = Appearance49
        Appearance50.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance50
        Me.Grid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid2.DisplayLayout.GroupByBox.Hidden = True
        Appearance51.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance51.BackColor2 = System.Drawing.SystemColors.Control
        Appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.PromptAppearance = Appearance51
        Me.Grid2.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid2.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.CardAreaAppearance = Appearance52
        Appearance53.BorderColor = System.Drawing.Color.Silver
        Appearance53.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid2.DisplayLayout.Override.CellAppearance = Appearance53
        Me.Grid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid2.DisplayLayout.Override.CellPadding = 0
        Me.Grid2.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid2.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid2.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid2.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance54.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance54.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Grid2.DisplayLayout.Override.FilterRowAppearance = Appearance54
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid2.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance55.BackColor = System.Drawing.SystemColors.Control
        Appearance55.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance55.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance55.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.GroupByRowAppearance = Appearance55
        Appearance56.FontData.Name = "Arial Narrow"
        Appearance56.FontData.SizeInPoints = 10.0!
        Appearance56.TextHAlignAsString = "Left"
        Me.Grid2.DisplayLayout.Override.HeaderAppearance = Appearance56
        Me.Grid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid2.DisplayLayout.Override.MinRowHeight = 24
        Appearance57.BackColor = System.Drawing.SystemColors.Window
        Appearance57.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance57.TextVAlignAsString = "Middle"
        Me.Grid2.DisplayLayout.Override.RowAppearance = Appearance57
        Me.Grid2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid2.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid2.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance58.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid2.DisplayLayout.Override.TemplateAddRowAppearance = Appearance58
        Me.Grid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid2.Location = New System.Drawing.Point(13, 223)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Size = New System.Drawing.Size(721, 186)
        Me.Grid2.TabIndex = 148
        Me.Grid2.Text = "UltraGrid2"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance18.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance18
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel13)
        Me.UltraGroupBox1.Controls.Add(Me.Btn5)
        Me.UltraGroupBox1.Controls.Add(Me.Txt7)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox1.Controls.Add(Me.Cbo1)
        Me.UltraGroupBox1.Controls.Add(Me.Cbo2)
        Me.UltraGroupBox1.Controls.Add(Me.Btn4)
        Me.UltraGroupBox1.Controls.Add(Me.Txt6)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel8)
        Me.UltraGroupBox1.Controls.Add(Me.Btn3)
        Me.UltraGroupBox1.Controls.Add(Me.Txt5)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBox1.Controls.Add(Me.Btn1)
        Me.UltraGroupBox1.Controls.Add(Me.Txt3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.Btn2)
        Me.UltraGroupBox1.Controls.Add(Me.Cbo3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel9)
        Me.UltraGroupBox1.Controls.Add(Me.Txt4)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.Txt2)
        Me.UltraGroupBox1.Controls.Add(Me.Txt1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Appearance25.FontData.BoldAsString = "True"
        Appearance25.FontData.Name = "Arial Narrow"
        Appearance25.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox1.HeaderAppearance = Appearance25
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox1.Location = New System.Drawing.Point(13, 17)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(721, 200)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "EQUIPO"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'UltraLabel13
        '
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Appearance20.FontData.BoldAsString = "True"
        Appearance20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance20.TextVAlignAsString = "Middle"
        Me.UltraLabel13.Appearance = Appearance20
        Me.UltraLabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel13.Location = New System.Drawing.Point(225, 26)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(408, 27)
        Me.UltraLabel13.TabIndex = 55
        Me.UltraLabel13.Text = "HAY NUEVOS COMPONENTES EN LA FAMILIA DEL EQUIPO, PRESIONAR GRABAR PARA QUE SE ACT" & _
            "UALICE LOS COMPONENTES EN EL EQUIPO"
        Me.UltraLabel13.Visible = False
        '
        'Btn5
        '
        Me.Btn5.Location = New System.Drawing.Point(329, 166)
        Me.Btn5.Name = "Btn5"
        Me.Btn5.Size = New System.Drawing.Size(24, 23)
        Me.Btn5.TabIndex = 54
        Me.Btn5.Text = "..."
        '
        'Txt7
        '
        Appearance62.Image = "Consultar.png"
        Appearance62.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt7.Appearance = Appearance62
        Me.Txt7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt7.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt7.Location = New System.Drawing.Point(106, 168)
        Me.Txt7.MaxLength = 10
        Me.Txt7.Name = "Txt7"
        Me.Txt7.ReadOnly = True
        Me.Txt7.Size = New System.Drawing.Size(217, 21)
        Me.Txt7.TabIndex = 53
        '
        'UltraLabel12
        '
        Appearance61.BackColor = System.Drawing.Color.Transparent
        Appearance61.TextHAlignAsString = "Right"
        Appearance61.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance61
        Me.UltraLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel12.Location = New System.Drawing.Point(7, 168)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(95, 22)
        Me.UltraLabel12.TabIndex = 52
        Me.UltraLabel12.Text = "* Código Antiguo :"
        '
        'Cbo1
        '
        Me.Cbo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cbo1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cbo1.Location = New System.Drawing.Point(106, 87)
        Me.Cbo1.Name = "Cbo1"
        Me.Cbo1.Size = New System.Drawing.Size(246, 22)
        Me.Cbo1.TabIndex = 51
        '
        'Cbo2
        '
        Me.Cbo2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cbo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.Cbo2.DisplayLayout.Override.FilterEvaluationTrigger = Infragistics.Win.UltraWinGrid.FilterEvaluationTrigger.OnEnterKeyOrLeaveRow
        Me.Cbo2.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cbo2.Location = New System.Drawing.Point(464, 88)
        Me.Cbo2.Name = "Cbo2"
        Me.Cbo2.ReadOnly = True
        Me.Cbo2.Size = New System.Drawing.Size(247, 22)
        Me.Cbo2.TabIndex = 50
        '
        'Btn4
        '
        Me.Btn4.Location = New System.Drawing.Point(687, 144)
        Me.Btn4.Name = "Btn4"
        Me.Btn4.Size = New System.Drawing.Size(24, 23)
        Me.Btn4.TabIndex = 48
        Me.Btn4.Text = "..."
        '
        'Txt6
        '
        Appearance3.Image = "Consultar.png"
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt6.Appearance = Appearance3
        Me.Txt6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt6.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt6.Location = New System.Drawing.Point(464, 143)
        Me.Txt6.MaxLength = 10
        Me.Txt6.Name = "Txt6"
        Me.Txt6.ReadOnly = True
        Me.Txt6.Size = New System.Drawing.Size(217, 21)
        Me.Txt6.TabIndex = 47
        '
        'UltraLabel8
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel8.Appearance = Appearance5
        Me.UltraLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel8.Location = New System.Drawing.Point(370, 143)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(88, 22)
        Me.UltraLabel8.TabIndex = 46
        Me.UltraLabel8.Text = "* Manipulador :"
        '
        'Btn3
        '
        Me.Btn3.Location = New System.Drawing.Point(328, 141)
        Me.Btn3.Name = "Btn3"
        Me.Btn3.Size = New System.Drawing.Size(24, 23)
        Me.Btn3.TabIndex = 45
        Me.Btn3.Text = "..."
        '
        'Txt5
        '
        Appearance65.Image = "Consultar.png"
        Appearance65.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt5.Appearance = Appearance65
        Me.Txt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt5.Location = New System.Drawing.Point(105, 141)
        Me.Txt5.MaxLength = 10
        Me.Txt5.Name = "Txt5"
        Me.Txt5.ReadOnly = True
        Me.Txt5.Size = New System.Drawing.Size(217, 21)
        Me.Txt5.TabIndex = 44
        '
        'UltraLabel7
        '
        Appearance66.BackColor = System.Drawing.Color.Transparent
        Appearance66.TextHAlignAsString = "Right"
        Appearance66.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance66
        Me.UltraLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel7.Location = New System.Drawing.Point(6, 140)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(96, 22)
        Me.UltraLabel7.TabIndex = 43
        Me.UltraLabel7.Text = "* Responsable  :"
        '
        'Btn1
        '
        Me.Btn1.Location = New System.Drawing.Point(328, 114)
        Me.Btn1.Name = "Btn1"
        Me.Btn1.Size = New System.Drawing.Size(24, 23)
        Me.Btn1.TabIndex = 42
        Me.Btn1.Text = "..."
        '
        'Txt3
        '
        Appearance32.Image = "Consultar.png"
        Appearance32.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt3.Appearance = Appearance32
        Me.Txt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt3.Location = New System.Drawing.Point(105, 114)
        Me.Txt3.MaxLength = 10
        Me.Txt3.Name = "Txt3"
        Me.Txt3.ReadOnly = True
        Me.Txt3.Size = New System.Drawing.Size(217, 21)
        Me.Txt3.TabIndex = 41
        '
        'UltraLabel5
        '
        Appearance31.BackColor = System.Drawing.Color.Transparent
        Appearance31.TextHAlignAsString = "Right"
        Appearance31.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance31
        Me.UltraLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel5.Location = New System.Drawing.Point(6, 113)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(96, 22)
        Me.UltraLabel5.TabIndex = 40
        Me.UltraLabel5.Text = "* Foto :"
        '
        'UltraLabel4
        '
        Appearance59.BackColor = System.Drawing.Color.Transparent
        Appearance59.TextHAlignAsString = "Right"
        Appearance59.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance59
        Me.UltraLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(366, 86)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(94, 22)
        Me.UltraLabel4.TabIndex = 38
        Me.UltraLabel4.Text = "* Familia Equipo :"
        '
        'Btn2
        '
        Me.Btn2.Location = New System.Drawing.Point(687, 116)
        Me.Btn2.Name = "Btn2"
        Me.Btn2.Size = New System.Drawing.Size(24, 23)
        Me.Btn2.TabIndex = 36
        Me.Btn2.Text = "..."
        '
        'Cbo3
        '
        Me.Cbo3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cbo3.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "K1"
        ValueListItem1.DisplayText = "ACTIVO"
        ValueListItem2.DataValue = "K2"
        ValueListItem2.DisplayText = "EN MANTENIMIENTO"
        ValueListItem4.DataValue = "K3"
        ValueListItem4.DisplayText = "DADO DE BAJA"
        ValueListItem3.DataValue = "K4"
        ValueListItem3.DisplayText = "ANULADO"
        Me.Cbo3.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem4, ValueListItem3})
        Me.Cbo3.Location = New System.Drawing.Point(464, 170)
        Me.Cbo3.Name = "Cbo3"
        Me.Cbo3.ReadOnly = True
        Me.Cbo3.Size = New System.Drawing.Size(149, 21)
        Me.Cbo3.TabIndex = 35
        '
        'UltraLabel9
        '
        Appearance127.BackColor = System.Drawing.Color.Transparent
        Appearance127.TextHAlignAsString = "Right"
        Appearance127.TextVAlignAsString = "Middle"
        Me.UltraLabel9.Appearance = Appearance127
        Me.UltraLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel9.Location = New System.Drawing.Point(370, 170)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(88, 22)
        Me.UltraLabel9.TabIndex = 34
        Me.UltraLabel9.Text = "* Estado :"
        '
        'Txt4
        '
        Appearance60.Image = "Consultar.png"
        Appearance60.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt4.Appearance = Appearance60
        Me.Txt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt4.Location = New System.Drawing.Point(464, 116)
        Me.Txt4.MaxLength = 10
        Me.Txt4.Name = "Txt4"
        Me.Txt4.ReadOnly = True
        Me.Txt4.Size = New System.Drawing.Size(217, 21)
        Me.Txt4.TabIndex = 32
        '
        'UltraLabel6
        '
        Appearance69.BackColor = System.Drawing.Color.Transparent
        Appearance69.TextHAlignAsString = "Right"
        Appearance69.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance69
        Me.UltraLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(370, 115)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(88, 22)
        Me.UltraLabel6.TabIndex = 27
        Me.UltraLabel6.Text = "* Plano :"
        '
        'UltraLabel3
        '
        Appearance22.BackColor = System.Drawing.Color.Transparent
        Appearance22.TextHAlignAsString = "Right"
        Appearance22.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance22
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(6, 86)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(96, 22)
        Me.UltraLabel3.TabIndex = 25
        Me.UltraLabel3.Text = "* Linea Negocio :"
        '
        'UltraLabel1
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance6
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(6, 31)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(96, 22)
        Me.UltraLabel1.TabIndex = 24
        Me.UltraLabel1.Text = "* Código :"
        '
        'Txt2
        '
        Me.Txt2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance21.Image = "Crystal_Clear_kdm_user_male[1].png"
        Appearance21.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt2.Appearance = Appearance21
        Me.Txt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt2.Location = New System.Drawing.Point(105, 59)
        Me.Txt2.MaxLength = 3000
        Me.Txt2.Name = "Txt2"
        Me.Txt2.ReadOnly = True
        Me.Txt2.Size = New System.Drawing.Size(606, 21)
        Me.Txt2.TabIndex = 6
        '
        'Txt1
        '
        Appearance33.Image = "Consultar.png"
        Appearance33.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt1.Appearance = Appearance33
        Me.Txt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt1.Location = New System.Drawing.Point(105, 31)
        Me.Txt1.MaxLength = 8
        Me.Txt1.Name = "Txt1"
        Me.Txt1.ReadOnly = True
        Me.Txt1.Size = New System.Drawing.Size(100, 21)
        Me.Txt1.TabIndex = 5
        '
        'UltraLabel2
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Appearance23.TextHAlignAsString = "Right"
        Appearance23.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance23
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(6, 58)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(96, 22)
        Me.UltraLabel2.TabIndex = 1
        Me.UltraLabel2.Text = "* Descripción:"
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Grid3)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraButton1)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraTextEditor1)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel11)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel10)
        Me.UltraTabPageControl1.Controls.Add(Me.Tree1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(743, 413)
        '
        'Grid3
        '
        Me.Grid3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance67.BackColor = System.Drawing.SystemColors.Window
        Appearance67.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid3.DisplayLayout.Appearance = Appearance67
        Me.Grid3.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn23.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance68.Image = CType(resources.GetObject("Appearance68.Image"), Object)
        Appearance68.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance68.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn23.Header.Appearance = Appearance68
        UltraGridColumn23.Header.Caption = ""
        UltraGridColumn23.Header.VisiblePosition = 0
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.MaxWidth = 25
        UltraGridColumn23.MinWidth = 20
        UltraGridColumn23.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn23.Width = 20
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn24.Header.Caption = "Cod. Atrib."
        UltraGridColumn24.Header.VisiblePosition = 1
        UltraGridColumn24.MaxWidth = 60
        UltraGridColumn24.MinWidth = 60
        UltraGridColumn24.Width = 60
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn25.Header.VisiblePosition = 2
        UltraGridColumn25.MinWidth = 140
        UltraGridColumn25.Width = 140
        UltraGridColumn26.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn26.Header.VisiblePosition = 3
        UltraGridColumn26.MinWidth = 100
        UltraGridColumn26.Width = 100
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn27.Header.VisiblePosition = 4
        UltraGridColumn27.MinWidth = 50
        UltraGridColumn27.Width = 50
        UltraGridColumn28.Header.VisiblePosition = 5
        UltraGridColumn28.Hidden = True
        UltraGridColumn28.Width = 60
        UltraGridColumn29.Header.VisiblePosition = 6
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.Width = 64
        UltraGridColumn30.Header.VisiblePosition = 7
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 66
        UltraGridColumn31.Header.VisiblePosition = 8
        UltraGridColumn31.Hidden = True
        UltraGridColumn31.Width = 72
        UltraGridColumn32.Header.VisiblePosition = 9
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.Width = 78
        UltraGridColumn33.Header.VisiblePosition = 10
        UltraGridColumn33.Hidden = True
        UltraGridColumn33.Width = 82
        UltraGridColumn34.Header.VisiblePosition = 11
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.Width = 88
        UltraGridColumn35.Header.VisiblePosition = 12
        UltraGridColumn35.Hidden = True
        UltraGridColumn35.Width = 94
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35})
        Me.Grid3.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.Grid3.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid3.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid3.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance73.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance73.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance73.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance73.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid3.DisplayLayout.GroupByBox.Appearance = Appearance73
        Appearance74.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid3.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance74
        Me.Grid3.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid3.DisplayLayout.GroupByBox.Hidden = True
        Appearance75.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance75.BackColor2 = System.Drawing.SystemColors.Control
        Appearance75.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance75.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid3.DisplayLayout.GroupByBox.PromptAppearance = Appearance75
        Me.Grid3.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid3.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid3.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid3.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid3.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance76.BackColor = System.Drawing.SystemColors.Window
        Me.Grid3.DisplayLayout.Override.CardAreaAppearance = Appearance76
        Appearance77.BorderColor = System.Drawing.Color.Silver
        Appearance77.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid3.DisplayLayout.Override.CellAppearance = Appearance77
        Me.Grid3.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid3.DisplayLayout.Override.CellPadding = 0
        Me.Grid3.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid3.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid3.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid3.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance78.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance78.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Grid3.DisplayLayout.Override.FilterRowAppearance = Appearance78
        Me.Grid3.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid3.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid3.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance79.BackColor = System.Drawing.SystemColors.Control
        Appearance79.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance79.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance79.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance79.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid3.DisplayLayout.Override.GroupByRowAppearance = Appearance79
        Appearance80.FontData.Name = "Arial Narrow"
        Appearance80.FontData.SizeInPoints = 10.0!
        Appearance80.TextHAlignAsString = "Left"
        Me.Grid3.DisplayLayout.Override.HeaderAppearance = Appearance80
        Me.Grid3.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid3.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid3.DisplayLayout.Override.MinRowHeight = 24
        Appearance81.BackColor = System.Drawing.SystemColors.Window
        Appearance81.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance81.TextVAlignAsString = "Middle"
        Me.Grid3.DisplayLayout.Override.RowAppearance = Appearance81
        Me.Grid3.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid3.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid3.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance82.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid3.DisplayLayout.Override.TemplateAddRowAppearance = Appearance82
        Me.Grid3.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.Grid3.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid3.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid3.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid3.Enabled = False
        Me.Grid3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid3.Location = New System.Drawing.Point(359, 49)
        Me.Grid3.Name = "Grid3"
        Me.Grid3.Size = New System.Drawing.Size(381, 363)
        Me.Grid3.TabIndex = 149
        Me.Grid3.Text = "Grid3"
        '
        'UltraButton1
        '
        Me.UltraButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraButton1.Location = New System.Drawing.Point(557, 49)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(24, 23)
        Me.UltraButton1.TabIndex = 154
        Me.UltraButton1.Text = "..."
        '
        'UltraTextEditor1
        '
        Me.UltraTextEditor1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance63.Image = "Consultar.png"
        Appearance63.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.UltraTextEditor1.Appearance = Appearance63
        Me.UltraTextEditor1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.UltraTextEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraTextEditor1.Location = New System.Drawing.Point(454, 49)
        Me.UltraTextEditor1.MaxLength = 10
        Me.UltraTextEditor1.Name = "UltraTextEditor1"
        Me.UltraTextEditor1.ReadOnly = True
        Me.UltraTextEditor1.Size = New System.Drawing.Size(97, 21)
        Me.UltraTextEditor1.TabIndex = 153
        '
        'UltraLabel11
        '
        Me.UltraLabel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance64.BackColor = System.Drawing.Color.Transparent
        Appearance64.TextHAlignAsString = "Right"
        Appearance64.TextVAlignAsString = "Middle"
        Me.UltraLabel11.Appearance = Appearance64
        Me.UltraLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel11.Location = New System.Drawing.Point(359, 49)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(88, 22)
        Me.UltraLabel11.TabIndex = 152
        Me.UltraLabel11.Text = "* Cantidad :"
        '
        'UltraLabel10
        '
        Me.UltraLabel10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel10.Appearance = Appearance19
        Me.UltraLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel10.Location = New System.Drawing.Point(359, 10)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(381, 33)
        Me.UltraLabel10.TabIndex = 151
        '
        'Tree1
        '
        Me.Tree1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        UltraTreeNodeColumn1.Key = "Componente"
        UltraTreeNodeColumn2.Key = "Item"
        UltraTreeNodeColumn3.Key = "ComponenteOrigen"
        UltraTreeNodeColumn4.Key = "ItemOrigen"
        UltraTreeColumnSet1.Columns.Add(UltraTreeNodeColumn1)
        UltraTreeColumnSet1.Columns.Add(UltraTreeNodeColumn2)
        UltraTreeColumnSet1.Columns.Add(UltraTreeNodeColumn3)
        UltraTreeColumnSet1.Columns.Add(UltraTreeNodeColumn4)
        UltraTreeColumnSet1.Key = "Componentes"
        Me.Tree1.ColumnSettings.ColumnSets.Add(UltraTreeColumnSet1)
        Me.Tree1.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.Tree1.Location = New System.Drawing.Point(3, 10)
        Me.Tree1.Name = "Tree1"
        Me.Tree1.NodeConnectorColor = System.Drawing.SystemColors.ControlDark
        Me.Tree1.Size = New System.Drawing.Size(350, 402)
        Me.Tree1.TabIndex = 150
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.Ptb1)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(743, 413)
        '
        'Ptb1
        '
        Me.Ptb1.BorderShadowColor = System.Drawing.Color.Empty
        Me.Ptb1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ptb1.Location = New System.Drawing.Point(0, 0)
        Me.Ptb1.Name = "Ptb1"
        Me.Ptb1.Size = New System.Drawing.Size(743, 413)
        Me.Ptb1.TabIndex = 0
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.Ptb2)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(743, 413)
        '
        'Ptb2
        '
        Me.Ptb2.BorderShadowColor = System.Drawing.Color.Empty
        Me.Ptb2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ptb2.Location = New System.Drawing.Point(0, 0)
        Me.Ptb2.Name = "Ptb2"
        Me.Ptb2.Size = New System.Drawing.Size(743, 413)
        Me.Ptb2.TabIndex = 1
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.Grid4)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(743, 413)
        '
        'Grid4
        '
        Appearance85.BackColor = System.Drawing.SystemColors.Window
        Appearance85.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid4.DisplayLayout.Appearance = Appearance85
        Me.Grid4.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn36.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance86.Image = CType(resources.GetObject("Appearance86.Image"), Object)
        Appearance86.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance86.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn36.Header.Appearance = Appearance86
        UltraGridColumn36.Header.Caption = ""
        UltraGridColumn36.Header.VisiblePosition = 0
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.MaxWidth = 25
        UltraGridColumn36.MinWidth = 20
        UltraGridColumn36.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn36.Width = 20
        UltraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance87.TextHAlignAsString = "Center"
        UltraGridColumn37.CellAppearance = Appearance87
        UltraGridColumn37.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance88.TextHAlignAsString = "Center"
        UltraGridColumn37.Header.Appearance = Appearance88
        UltraGridColumn37.Header.Caption = "Código"
        UltraGridColumn37.Header.VisiblePosition = 1
        UltraGridColumn37.MaxWidth = 100
        UltraGridColumn37.MinWidth = 100
        UltraGridColumn37.RowLayoutColumnInfo.OriginX = 0
        UltraGridColumn37.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn37.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn37.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn37.Width = 100
        UltraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn38.Header.VisiblePosition = 2
        UltraGridColumn38.MaxWidth = 200
        UltraGridColumn38.MinWidth = 200
        UltraGridColumn38.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn38.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn38.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(200, 0)
        UltraGridColumn38.RowLayoutColumnInfo.SpanX = 4
        UltraGridColumn38.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn38.Width = 200
        UltraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn39.Header.Caption = "Encargado Mantto."
        UltraGridColumn39.Header.VisiblePosition = 3
        UltraGridColumn39.Hidden = True
        UltraGridColumn39.MinWidth = 150
        UltraGridColumn39.Width = 150
        UltraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn40.Header.Caption = "Tipo Mantto"
        UltraGridColumn40.Header.VisiblePosition = 4
        UltraGridColumn40.MaxWidth = 200
        UltraGridColumn40.MinWidth = 200
        UltraGridColumn40.RowLayoutColumnInfo.OriginX = 6
        UltraGridColumn40.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn40.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(227, 0)
        UltraGridColumn40.RowLayoutColumnInfo.SpanX = 4
        UltraGridColumn40.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn40.Width = 200
        UltraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn41.Header.Caption = "Presupuesto"
        UltraGridColumn41.Header.VisiblePosition = 5
        UltraGridColumn41.MaxWidth = 80
        UltraGridColumn41.MinWidth = 80
        UltraGridColumn41.RowLayoutColumnInfo.OriginX = 10
        UltraGridColumn41.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn41.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn41.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn41.Width = 80
        UltraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance89.TextHAlignAsString = "Center"
        UltraGridColumn42.CellAppearance = Appearance89
        UltraGridColumn42.Header.Caption = "Mon"
        UltraGridColumn42.Header.VisiblePosition = 6
        UltraGridColumn42.MaxWidth = 40
        UltraGridColumn42.MinWidth = 40
        UltraGridColumn42.RowLayoutColumnInfo.OriginX = 0
        UltraGridColumn42.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn42.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn42.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn42.Width = 40
        UltraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance90.TextHAlignAsString = "Right"
        UltraGridColumn43.CellAppearance = Appearance90
        UltraGridColumn43.DataType = GetType(Double)
        UltraGridColumn43.Format = "n4"
        UltraGridColumn43.Header.Caption = "Costo Presup."
        UltraGridColumn43.Header.VisiblePosition = 7
        UltraGridColumn43.MaxWidth = 100
        UltraGridColumn43.MinWidth = 100
        UltraGridColumn43.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn43.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn43.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn43.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn43.Width = 100
        UltraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance91.TextHAlignAsString = "Right"
        UltraGridColumn44.CellAppearance = Appearance91
        UltraGridColumn44.DataType = GetType(Double)
        UltraGridColumn44.Format = "n4"
        UltraGridColumn44.Header.Caption = "Costo Total"
        UltraGridColumn44.Header.VisiblePosition = 8
        UltraGridColumn44.MaxWidth = 100
        UltraGridColumn44.MinWidth = 100
        UltraGridColumn44.RowLayoutColumnInfo.OriginX = 4
        UltraGridColumn44.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn44.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn44.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn44.Width = 100
        UltraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance92.TextHAlignAsString = "Center"
        UltraGridColumn45.CellAppearance = Appearance92
        UltraGridColumn45.DataType = GetType(Date)
        UltraGridColumn45.Header.Caption = "Fecha Inicio"
        UltraGridColumn45.Header.VisiblePosition = 9
        UltraGridColumn45.MaxWidth = 100
        UltraGridColumn45.MinWidth = 100
        UltraGridColumn45.RowLayoutColumnInfo.OriginX = 6
        UltraGridColumn45.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn45.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn45.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn45.Width = 100
        UltraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance93.TextHAlignAsString = "Center"
        UltraGridColumn46.CellAppearance = Appearance93
        UltraGridColumn46.DataType = GetType(Date)
        UltraGridColumn46.Header.Caption = "Fecha Termino"
        UltraGridColumn46.Header.VisiblePosition = 10
        UltraGridColumn46.MaxWidth = 100
        UltraGridColumn46.MinWidth = 100
        UltraGridColumn46.RowLayoutColumnInfo.OriginX = 8
        UltraGridColumn46.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn46.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn46.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn46.Width = 100
        UltraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn47.Header.VisiblePosition = 11
        UltraGridColumn47.MaxWidth = 100
        UltraGridColumn47.MinWidth = 100
        UltraGridColumn47.RowLayoutColumnInfo.OriginX = 10
        UltraGridColumn47.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn47.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn47.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn47.Width = 100
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47})
        UltraGridBand4.UseRowLayout = True
        Me.Grid4.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.Grid4.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid4.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid4.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance94.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance94.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance94.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance94.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid4.DisplayLayout.GroupByBox.Appearance = Appearance94
        Appearance95.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid4.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance95
        Me.Grid4.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid4.DisplayLayout.GroupByBox.Hidden = True
        Appearance96.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance96.BackColor2 = System.Drawing.SystemColors.Control
        Appearance96.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance96.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid4.DisplayLayout.GroupByBox.PromptAppearance = Appearance96
        Me.Grid4.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid4.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid4.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid4.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid4.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance97.BackColor = System.Drawing.SystemColors.Window
        Me.Grid4.DisplayLayout.Override.CardAreaAppearance = Appearance97
        Appearance98.BorderColor = System.Drawing.Color.Silver
        Appearance98.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid4.DisplayLayout.Override.CellAppearance = Appearance98
        Me.Grid4.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid4.DisplayLayout.Override.CellPadding = 0
        Me.Grid4.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid4.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid4.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid4.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance99.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance99.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Grid4.DisplayLayout.Override.FilterRowAppearance = Appearance99
        Me.Grid4.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid4.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid4.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance100.BackColor = System.Drawing.SystemColors.Control
        Appearance100.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance100.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance100.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance100.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid4.DisplayLayout.Override.GroupByRowAppearance = Appearance100
        Appearance101.FontData.Name = "Arial Narrow"
        Appearance101.FontData.SizeInPoints = 10.0!
        Appearance101.TextHAlignAsString = "Left"
        Me.Grid4.DisplayLayout.Override.HeaderAppearance = Appearance101
        Me.Grid4.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid4.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid4.DisplayLayout.Override.MinRowHeight = 24
        Appearance102.BackColor = System.Drawing.SystemColors.Window
        Appearance102.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance102.TextVAlignAsString = "Middle"
        Me.Grid4.DisplayLayout.Override.RowAppearance = Appearance102
        Me.Grid4.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid4.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid4.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance103.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid4.DisplayLayout.Override.TemplateAddRowAppearance = Appearance103
        Me.Grid4.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.Grid4.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid4.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid4.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid4.Location = New System.Drawing.Point(0, 0)
        Me.Grid4.Name = "Grid4"
        Me.Grid4.Size = New System.Drawing.Size(743, 413)
        Me.Grid4.TabIndex = 150
        Me.Grid4.Text = "UltraGrid4"
        '
        'Tab1
        '
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.Name = "Arial Narrow"
        Appearance1.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance1
        Appearance2.FontData.Name = "Arial Narrow"
        Appearance2.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance2
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl2)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl3)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl4)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl5)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl6)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(747, 450)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance26.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance26
        Me.Tab1.TabIndex = 7
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance27.Cursor = System.Windows.Forms.Cursors.Default
        Appearance27.FontData.BoldAsString = "True"
        Appearance27.FontData.Name = "Arial Narrow"
        Appearance27.FontData.SizeInPoints = 16.0!
        UltraTab2.ActiveAppearance = Appearance27
        Appearance28.FontData.Name = "Arial Narrow"
        Appearance28.FontData.SizeInPoints = 10.0!
        UltraTab2.Appearance = Appearance28
        UltraTab2.Key = "T01"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "EQUIPO"
        Appearance29.Cursor = System.Windows.Forms.Cursors.Default
        Appearance29.FontData.BoldAsString = "True"
        Appearance29.FontData.Name = "Arial Narrow"
        Appearance29.FontData.SizeInPoints = 16.0!
        UltraTab5.ActiveAppearance = Appearance29
        UltraTab5.Key = "T02"
        UltraTab5.TabPage = Me.UltraTabPageControl3
        UltraTab5.Text = "DESCRIPCION"
        UltraTab1.Key = "T03"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "COMPONENTES"
        UltraTab3.Key = "T04"
        UltraTab3.TabPage = Me.UltraTabPageControl4
        UltraTab3.Text = "FOTO"
        UltraTab4.Key = "T05"
        UltraTab4.TabPage = Me.UltraTabPageControl5
        UltraTab4.Text = "PLANO"
        UltraTab6.Key = "T06"
        UltraTab6.TabPage = Me.UltraTabPageControl6
        UltraTab6.Text = "MANTENIMIENTOS"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2, UltraTab5, UltraTab1, UltraTab3, UltraTab4, UltraTab6})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(743, 413)
        '
        'frmMEquipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 450)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "frmMEquipo"
        Me.Tag = "M48"
        Me.Text = "Equipo"
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraStatusBar1.ResumeLayout(False)
        Me.UltraStatusBar1.PerformLayout()
        Me.UltraTabPageControl3.ResumeLayout(False)
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.Txt7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.Grid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tree1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.UltraTabPageControl5.ResumeLayout(False)
        Me.UltraTabPageControl6.ResumeLayout(False)
        CType(Me.Grid4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Grid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Grid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Btn2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Cbo3 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Grid3 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Btn3 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Txt5 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Btn1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Txt3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Btn4 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Txt6 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Ptb1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Ptb2 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Grid4 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Cbo2 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Tree1 As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTextEditor1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents Ofd1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Ofd2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Cbo1 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Btn5 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Txt7 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
End Class
