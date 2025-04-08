<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultas
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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultas))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo", 0)
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NomTrabajador", 1)
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("montoTotal", 2)
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodTrabajador", 3)
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Motivo", 0, False)
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "montoTotal", 2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "montoTotal", 2, False)
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDoc", 0)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumDoc", 1)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fechaComp", 2)
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Razon", 3)
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 4)
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("montoTotalParcial", 5)
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("item", 6)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nroruc", 7)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Auxiliar", 8)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codConcepto", 9)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion", 10)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idComp", 11)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codTipoDoc", 12)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Serie", 13)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("motivoDetalle", 14)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codmotivoDetalle", 15)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(915)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo", 0)
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha", 1)
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("montoTotal", 2)
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumSolicitud", 3)
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("montoParcial", 4)
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("montoTotalParcial", 5)
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("moneda", 6)
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fechaComp", 7)
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumDoc", 8)
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tipodeposito", 9)
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantera", 10)
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("dias", 11)
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance138 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.GridConsultas = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.lblcodigo = New Infragistics.Win.Misc.UltraLabel
        Me.Gpb1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.gridDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.lbltrabajador = New Infragistics.Win.Misc.UltraLabel
        Me.GridConsultaDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtreintegrar = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnVerAsiento = New System.Windows.Forms.Button
        Me.txtsolicitado = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtdisponible = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txtliquidado = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtxrendir = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.txtlineacredito = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.rdbxrendir = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.rdbrendida = New System.Windows.Forms.RadioButton
        Me.rdbtotal = New System.Windows.Forms.RadioButton
        Me.dtpfin = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpinicio = New System.Windows.Forms.DateTimePicker
        Me.TabMaestroEntregas = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.GridConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.Gpb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gpb1.SuspendLayout()
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridConsultaDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.txtreintegrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsolicitado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtliquidado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtxrendir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtlineacredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabMaestroEntregas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabMaestroEntregas.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.GridConsultas)
        Me.UltraTabPageControl1.Controls.Add(Me.BindingNavigator1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(928, 573)
        '
        'GridConsultas
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridConsultas.DisplayLayout.Appearance = Appearance1
        Me.GridConsultas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance5
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance11.TextHAlignAsString = "Left"
        UltraGridColumn2.CellAppearance = Appearance11
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn2.Header.Caption = "Estado"
        UltraGridColumn2.Header.VisiblePosition = 3
        UltraGridColumn2.MinWidth = 180
        UltraGridColumn2.Width = 210
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance15.TextHAlignAsString = "Left"
        UltraGridColumn3.CellAppearance = Appearance15
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn3.Header.Caption = "Nombre Trabajador"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.MinWidth = 180
        UltraGridColumn3.Width = 396
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance18
        UltraGridColumn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn4.DataType = GetType(Double)
        UltraGridColumn4.Format = "###,##,##0.00"
        UltraGridColumn4.Header.Caption = "Monto S/."
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 163
        UltraGridColumn5.Header.Caption = "Código"
        UltraGridColumn5.Header.VisiblePosition = 1
        UltraGridColumn5.Width = 99
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Appearance79.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance79
        SummarySettings1.DisplayFormat = "Total"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance81
        Appearance82.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance82
        SummarySettings2.DisplayFormat = "{0:###,##0.00}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance83
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
        UltraGridBand1.SummaryFooterCaption = ""
        Me.GridConsultas.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridConsultas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridConsultas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridConsultas.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance19.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance19.BorderColor = System.Drawing.SystemColors.Window
        Me.GridConsultas.DisplayLayout.GroupByBox.Appearance = Appearance19
        Appearance21.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridConsultas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance21
        Me.GridConsultas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridConsultas.DisplayLayout.GroupByBox.Hidden = True
        Appearance32.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance32.BackColor2 = System.Drawing.SystemColors.Control
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance32.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridConsultas.DisplayLayout.GroupByBox.PromptAppearance = Appearance32
        Me.GridConsultas.DisplayLayout.MaxColScrollRegions = 1
        Me.GridConsultas.DisplayLayout.MaxRowScrollRegions = 1
        Me.GridConsultas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridConsultas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridConsultas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Me.GridConsultas.DisplayLayout.Override.CardAreaAppearance = Appearance24
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Appearance25.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridConsultas.DisplayLayout.Override.CellAppearance = Appearance25
        Me.GridConsultas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridConsultas.DisplayLayout.Override.CellPadding = 0
        Me.GridConsultas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.GridConsultas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.GridConsultas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.GridConsultas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance37.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance37.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GridConsultas.DisplayLayout.Override.FilterRowAppearance = Appearance37
        Me.GridConsultas.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.GridConsultas.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.GridConsultas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance27.BackColor = System.Drawing.SystemColors.Control
        Appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance27.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance27.BorderColor = System.Drawing.SystemColors.Window
        Me.GridConsultas.DisplayLayout.Override.GroupByRowAppearance = Appearance27
        Appearance28.FontData.Name = "Arial Narrow"
        Appearance28.FontData.SizeInPoints = 10.0!
        Appearance28.TextHAlignAsString = "Left"
        Me.GridConsultas.DisplayLayout.Override.HeaderAppearance = Appearance28
        Me.GridConsultas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.GridConsultas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.GridConsultas.DisplayLayout.Override.MinRowHeight = 24
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance30.TextVAlignAsString = "Middle"
        Me.GridConsultas.DisplayLayout.Override.RowAppearance = Appearance30
        Me.GridConsultas.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.GridConsultas.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.GridConsultas.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridConsultas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance31
        Me.GridConsultas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridConsultas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridConsultas.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.GridConsultas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridConsultas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridConsultas.Location = New System.Drawing.Point(0, 25)
        Me.GridConsultas.Name = "GridConsultas"
        Me.GridConsultas.Size = New System.Drawing.Size(928, 548)
        Me.GridConsultas.TabIndex = 141
        Me.GridConsultas.Text = "UltraGrid1"
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BackColor = System.Drawing.Color.Transparent
        Me.BindingNavigator1.CountItem = Me.ToolStripLabel1
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.ToolStripTextBox1, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator7, Me.ToolStripButton5, Me.ToolStripSeparator8})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Me.ToolStripButton4
        Me.BindingNavigator1.MoveLastItem = Me.ToolStripButton1
        Me.BindingNavigator1.MoveNextItem = Me.ToolStripButton2
        Me.BindingNavigator1.MovePreviousItem = Me.ToolStripButton3
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.ToolStripTextBox1
        Me.BindingNavigator1.Size = New System.Drawing.Size(928, 25)
        Me.BindingNavigator1.TabIndex = 142
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel1.Text = "of {0}"
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
        Me.ToolStripButton5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton5.Image = Global.SIP_Presentacion.My.Resources.Resources.Hand
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(99, 22)
        Me.ToolStripButton5.Text = "SELECCIONAR"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel5)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel4)
        Me.UltraTabPageControl4.Controls.Add(Me.lblcodigo)
        Me.UltraTabPageControl4.Controls.Add(Me.Gpb1)
        Me.UltraTabPageControl4.Controls.Add(Me.lbltrabajador)
        Me.UltraTabPageControl4.Controls.Add(Me.GridConsultaDetalle)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(928, 573)
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance23.BackColor = System.Drawing.Color.White
        Appearance23.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance23.ForeColor = System.Drawing.Color.Black
        Appearance23.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance23.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance23.TextHAlignAsString = "Center"
        Appearance23.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance23
        Me.UltraLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.ImageTransparentColor = System.Drawing.Color.Wheat
        Me.UltraLabel5.Location = New System.Drawing.Point(511, 153)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(415, 25)
        Me.UltraLabel5.TabIndex = 157
        Me.UltraLabel5.Text = "LIQUIDACIÓN"
        '
        'UltraLabel4
        '
        Appearance69.BackColor = System.Drawing.Color.White
        Appearance69.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance69.ForeColor = System.Drawing.Color.Black
        Appearance69.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance69.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance69.TextHAlignAsString = "Center"
        Appearance69.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance69
        Me.UltraLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption
        Me.UltraLabel4.Location = New System.Drawing.Point(5, 153)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(506, 25)
        Me.UltraLabel4.TabIndex = 156
        Me.UltraLabel4.Text = "SOLICITUD"
        '
        'lblcodigo
        '
        Me.lblcodigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance70.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance70.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance70.ForeColor = System.Drawing.Color.White
        Appearance70.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance70.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance70.TextHAlignAsString = "Left"
        Appearance70.TextVAlignAsString = "Middle"
        Me.lblcodigo.Appearance = Appearance70
        Me.lblcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcodigo.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblcodigo.Location = New System.Drawing.Point(5, 302)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(305, 25)
        Me.lblcodigo.TabIndex = 155
        Me.lblcodigo.Text = "CODIGO DEL TRABAJADOR"
        Me.lblcodigo.Visible = False
        '
        'Gpb1
        '
        Me.Gpb1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.BackColor = System.Drawing.Color.White
        Me.Gpb1.ContentAreaAppearance = Appearance7
        Me.Gpb1.Controls.Add(Me.gridDetalle)
        Appearance60.FontData.BoldAsString = "True"
        Appearance60.FontData.Name = "Arial Narrow"
        Appearance60.FontData.SizeInPoints = 10.0!
        Me.Gpb1.HeaderAppearance = Appearance60
        Me.Gpb1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Gpb1.Location = New System.Drawing.Point(2, 553)
        Me.Gpb1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Gpb1.Name = "Gpb1"
        Me.Gpb1.Size = New System.Drawing.Size(923, 19)
        Me.Gpb1.TabIndex = 144
        Me.Gpb1.Text = "DETALLE DE COMPROBANTES DE PAGO"
        Me.Gpb1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        Me.Gpb1.Visible = False
        '
        'gridDetalle
        '
        Me.gridDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridDetalle.DisplayLayout.Appearance = Appearance8
        Me.gridDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance9.Image = CType(resources.GetObject("Appearance9.Image"), Object)
        Appearance9.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance9.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn6.Header.Appearance = Appearance9
        UltraGridColumn6.Header.Caption = ""
        UltraGridColumn6.Header.VisiblePosition = 8
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.MaxWidth = 25
        UltraGridColumn6.MinWidth = 25
        UltraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit
        UltraGridColumn6.Width = 25
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn7.Header.Caption = "TD"
        UltraGridColumn7.Header.VisiblePosition = 3
        UltraGridColumn7.MaskInput = ""
        UltraGridColumn7.Width = 50
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn8.Header.Caption = "Nro. Documento"
        UltraGridColumn8.Header.VisiblePosition = 5
        UltraGridColumn8.MaskInput = "nnnnnnnnnnnnnnnn"
        UltraGridColumn8.Width = 150
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn9.CellAppearance = Appearance10
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn9.Header.Appearance = Appearance12
        UltraGridColumn9.Header.Caption = "Fecha"
        UltraGridColumn9.Header.VisiblePosition = 1
        UltraGridColumn9.MaskInput = "{LOC}dd/mm/yyyy "
        UltraGridColumn9.Width = 105
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.TextHAlignAsString = "Left"
        UltraGridColumn10.CellAppearance = Appearance13
        UltraGridColumn10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn10.Format = ""
        Appearance14.TextHAlignAsString = "Center"
        UltraGridColumn10.Header.Appearance = Appearance14
        UltraGridColumn10.Header.Caption = "Razón Social"
        UltraGridColumn10.Header.VisiblePosition = 7
        UltraGridColumn10.MaskInput = ""
        UltraGridColumn10.NullText = ""
        UltraGridColumn10.Width = 202
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance16.FontData.SizeInPoints = 8.0!
        Appearance16.TextHAlignAsString = "Left"
        UltraGridColumn11.CellAppearance = Appearance16
        UltraGridColumn11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn11.Format = ""
        Appearance29.TextHAlignAsString = "Center"
        UltraGridColumn11.Header.Appearance = Appearance29
        UltraGridColumn11.Header.Caption = "Descripción"
        UltraGridColumn11.Header.VisiblePosition = 2
        UltraGridColumn11.MaskInput = ""
        UltraGridColumn11.NullText = ""
        UltraGridColumn11.Width = 207
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance34.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance34
        UltraGridColumn12.Format = "###,##,##0.00"
        Appearance35.TextHAlignAsString = "Center"
        UltraGridColumn12.Header.Appearance = Appearance35
        UltraGridColumn12.Header.Caption = "Importe"
        UltraGridColumn12.Header.VisiblePosition = 9
        UltraGridColumn12.MaskInput = "{double:8.2}"
        UltraGridColumn12.MaxValue = "999999.99"
        UltraGridColumn12.MinValue = "0.00"
        UltraGridColumn12.NullText = "0.00"
        UltraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoubleNonNegative
        UltraGridColumn12.Width = 80
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.DataType = GetType(Integer)
        UltraGridColumn13.Header.VisiblePosition = 10
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 88
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn14.Header.Caption = "NroRuc"
        UltraGridColumn14.Header.VisiblePosition = 6
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.MaskInput = "nnnnnnnnnnn"
        UltraGridColumn14.Width = 84
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn15.Header.VisiblePosition = 11
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 72
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn16.Header.VisiblePosition = 12
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 97
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.Header.VisiblePosition = 13
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 97
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn18.Header.VisiblePosition = 14
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 96
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn19.Header.VisiblePosition = 15
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.Width = 96
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn20.Header.VisiblePosition = 4
        UltraGridColumn20.MaskInput = "nnnn"
        UltraGridColumn20.Width = 66
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn21.Header.Caption = "Motivo"
        UltraGridColumn21.Header.VisiblePosition = 0
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 84
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn22.Header.VisiblePosition = 16
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 99
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22})
        Me.gridDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridDetalle.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance36.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance36.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.GroupByBox.Appearance = Appearance36
        Appearance38.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance38
        Me.gridDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDetalle.DisplayLayout.GroupByBox.Hidden = True
        Appearance46.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance46.BackColor2 = System.Drawing.SystemColors.Control
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance46.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance46
        Me.gridDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.gridDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance53
        Appearance54.BorderColor = System.Drawing.Color.Silver
        Appearance54.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridDetalle.DisplayLayout.Override.CellAppearance = Appearance54
        Me.gridDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridDetalle.DisplayLayout.Override.CellPadding = 0
        Me.gridDetalle.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridDetalle.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance55.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridDetalle.DisplayLayout.Override.FilterRowAppearance = Appearance55
        Me.gridDetalle.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridDetalle.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance56.BackColor = System.Drawing.SystemColors.Control
        Appearance56.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance56.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance56.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance56
        Appearance57.FontData.Name = "Arial Narrow"
        Appearance57.FontData.SizeInPoints = 10.0!
        Appearance57.TextHAlignAsString = "Left"
        Me.gridDetalle.DisplayLayout.Override.HeaderAppearance = Appearance57
        Me.gridDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridDetalle.DisplayLayout.Override.MinRowHeight = 24
        Appearance58.BackColor = System.Drawing.SystemColors.Window
        Appearance58.BorderColor = System.Drawing.Color.Silver
        Appearance58.TextVAlignAsString = "Middle"
        Me.gridDetalle.DisplayLayout.Override.RowAppearance = Appearance58
        Me.gridDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridDetalle.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridDetalle.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance59.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance59
        Me.gridDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridDetalle.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDetalle.Location = New System.Drawing.Point(3, 23)
        Me.gridDetalle.Name = "gridDetalle"
        Me.gridDetalle.Size = New System.Drawing.Size(917, 0)
        Me.gridDetalle.TabIndex = 144
        Me.gridDetalle.Text = "UltraGrid1"
        '
        'lbltrabajador
        '
        Me.lbltrabajador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance67.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance67.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance67.ForeColor = System.Drawing.Color.White
        Appearance67.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance67.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance67.TextHAlignAsString = "Left"
        Appearance67.TextVAlignAsString = "Middle"
        Me.lbltrabajador.Appearance = Appearance67
        Me.lbltrabajador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltrabajador.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbltrabajador.Location = New System.Drawing.Point(0, 3)
        Me.lbltrabajador.Name = "lbltrabajador"
        Me.lbltrabajador.Size = New System.Drawing.Size(928, 25)
        Me.lbltrabajador.TabIndex = 143
        Me.lbltrabajador.Text = "DATOS DEL TRABAJADOR"
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
        UltraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn23.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn23.Header.Appearance = Appearance3
        UltraGridColumn23.Header.Caption = ""
        UltraGridColumn23.Header.VisiblePosition = 0
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.MaxWidth = 25
        UltraGridColumn23.MinWidth = 20
        UltraGridColumn23.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn23.Width = 20
        UltraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Left"
        UltraGridColumn24.CellAppearance = Appearance6
        UltraGridColumn24.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance17.BackColor = System.Drawing.Color.SkyBlue
        UltraGridColumn24.Header.Appearance = Appearance17
        UltraGridColumn24.Header.VisiblePosition = 5
        UltraGridColumn24.MinWidth = 8
        UltraGridColumn24.Width = 143
        UltraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance20.TextHAlignAsString = "Left"
        UltraGridColumn25.CellAppearance = Appearance20
        UltraGridColumn25.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance22.BackColor = System.Drawing.Color.SkyBlue
        UltraGridColumn25.Header.Appearance = Appearance22
        UltraGridColumn25.Header.VisiblePosition = 1
        UltraGridColumn25.MinWidth = 8
        UltraGridColumn25.Width = 50
        UltraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance64.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance64
        UltraGridColumn26.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn26.DataType = GetType(Double)
        UltraGridColumn26.Format = "###,##,##0.00"
        Appearance33.BackColor = System.Drawing.Color.PeachPuff
        UltraGridColumn26.Header.Appearance = Appearance33
        UltraGridColumn26.Header.Caption = "Saldo"
        UltraGridColumn26.Header.VisiblePosition = 11
        UltraGridColumn26.Width = 60
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance39.BackColor = System.Drawing.Color.SkyBlue
        UltraGridColumn27.Header.Appearance = Appearance39
        UltraGridColumn27.Header.Caption = "N° de doc."
        UltraGridColumn27.Header.VisiblePosition = 3
        UltraGridColumn27.Width = 81
        UltraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance40.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance40
        UltraGridColumn28.Format = "###,##,##0.00"
        Appearance41.BackColor = System.Drawing.Color.SkyBlue
        UltraGridColumn28.Header.Appearance = Appearance41
        UltraGridColumn28.Header.Caption = "Debe"
        UltraGridColumn28.Header.VisiblePosition = 7
        UltraGridColumn28.Width = 69
        UltraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance42.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance42
        UltraGridColumn29.Format = "###,##,##0.00"
        Appearance45.BackColor = System.Drawing.Color.PeachPuff
        UltraGridColumn29.Header.Appearance = Appearance45
        UltraGridColumn29.Header.Caption = "Haber"
        UltraGridColumn29.Header.VisiblePosition = 10
        UltraGridColumn29.Width = 60
        UltraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance47.BackColor = System.Drawing.Color.SkyBlue
        UltraGridColumn30.Header.Appearance = Appearance47
        UltraGridColumn30.Header.Caption = "Mon."
        UltraGridColumn30.Header.VisiblePosition = 6
        UltraGridColumn30.Width = 35
        UltraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance48.BackColor = System.Drawing.Color.PeachPuff
        UltraGridColumn31.Header.Appearance = Appearance48
        UltraGridColumn31.Header.Caption = "Fecha"
        UltraGridColumn31.Header.VisiblePosition = 8
        UltraGridColumn31.Width = 70
        UltraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance49.BackColor = System.Drawing.Color.PeachPuff
        UltraGridColumn32.Header.Appearance = Appearance49
        UltraGridColumn32.Header.Caption = "N° de doc."
        UltraGridColumn32.Header.VisiblePosition = 9
        UltraGridColumn32.Width = 73
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance86.BackColor = System.Drawing.Color.SkyBlue
        UltraGridColumn33.Header.Appearance = Appearance86
        UltraGridColumn33.Header.Caption = "Tipo"
        UltraGridColumn33.Header.VisiblePosition = 2
        UltraGridColumn33.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn33.Width = 69
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance87.BackColor = System.Drawing.Color.SkyBlue
        UltraGridColumn34.Header.Appearance = Appearance87
        UltraGridColumn34.Header.VisiblePosition = 4
        UltraGridColumn34.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn34.Width = 105
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance88.BackColor = System.Drawing.Color.PeachPuff
        UltraGridColumn35.Header.Appearance = Appearance88
        UltraGridColumn35.Header.Caption = "Días Demora"
        UltraGridColumn35.Header.VisiblePosition = 12
        UltraGridColumn35.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn35.Width = 68
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35})
        UltraGridBand3.SummaryFooterCaption = ""
        Me.GridConsultaDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
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
        Me.GridConsultaDetalle.Location = New System.Drawing.Point(5, 183)
        Me.GridConsultaDetalle.Name = "GridConsultaDetalle"
        Me.GridConsultaDetalle.Size = New System.Drawing.Size(923, 354)
        Me.GridConsultaDetalle.TabIndex = 142
        Me.GridConsultaDetalle.Text = "UltraGrid1"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance109.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox2.ContentAreaAppearance = Appearance109
        Me.UltraGroupBox2.Controls.Add(Me.txtreintegrar)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox2.Controls.Add(Me.Button1)
        Me.UltraGroupBox2.Controls.Add(Me.btnVerAsiento)
        Me.UltraGroupBox2.Controls.Add(Me.txtsolicitado)
        Me.UltraGroupBox2.Controls.Add(Me.txtdisponible)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox2.Controls.Add(Me.txtliquidado)
        Me.UltraGroupBox2.Controls.Add(Me.txtxrendir)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox2.Controls.Add(Me.txtlineacredito)
        Me.UltraGroupBox2.Controls.Add(Me.rdbxrendir)
        Me.UltraGroupBox2.Controls.Add(Me.Label2)
        Me.UltraGroupBox2.Controls.Add(Me.rdbrendida)
        Me.UltraGroupBox2.Controls.Add(Me.rdbtotal)
        Me.UltraGroupBox2.Controls.Add(Me.dtpfin)
        Me.UltraGroupBox2.Controls.Add(Me.Label1)
        Me.UltraGroupBox2.Controls.Add(Me.dtpinicio)
        Appearance138.FontData.BoldAsString = "True"
        Appearance138.FontData.Name = "Arial Narrow"
        Appearance138.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox2.HeaderAppearance = Appearance138
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox2.Location = New System.Drawing.Point(5, 39)
        Me.UltraGroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(908, 107)
        Me.UltraGroupBox2.TabIndex = 154
        Me.UltraGroupBox2.Text = "RANGO DE FECHAS  -  FILTRO"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'txtreintegrar
        '
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtreintegrar.Appearance = Appearance4
        Me.txtreintegrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtreintegrar.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtreintegrar.Location = New System.Drawing.Point(534, 79)
        Me.txtreintegrar.MaxLength = 8
        Me.txtreintegrar.Name = "txtreintegrar"
        Me.txtreintegrar.ReadOnly = True
        Me.txtreintegrar.Size = New System.Drawing.Size(94, 21)
        Me.txtreintegrar.TabIndex = 168
        Me.txtreintegrar.TabStop = False
        Me.txtreintegrar.Text = "0.00"
        '
        'UltraLabel2
        '
        Appearance44.BackColor = System.Drawing.Color.Transparent
        Appearance44.TextHAlignAsString = "Center"
        Appearance44.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance44
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(424, 83)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(104, 14)
        Me.UltraLabel2.TabIndex = 169
        Me.UltraLabel2.Text = "Saldo por reintegrar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(647, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 21)
        Me.Button1.TabIndex = 167
        Me.Button1.TabStop = False
        Me.Button1.Text = "Ver Liquidacion"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnVerAsiento
        '
        Me.btnVerAsiento.Location = New System.Drawing.Point(647, 37)
        Me.btnVerAsiento.Name = "btnVerAsiento"
        Me.btnVerAsiento.Size = New System.Drawing.Size(127, 21)
        Me.btnVerAsiento.TabIndex = 166
        Me.btnVerAsiento.TabStop = False
        Me.btnVerAsiento.Text = "Ver Solicitud"
        Me.btnVerAsiento.UseVisualStyleBackColor = True
        '
        'txtsolicitado
        '
        Appearance61.FontData.BoldAsString = "False"
        Appearance61.ForeColor = System.Drawing.Color.Black
        Appearance61.TextHAlignAsString = "Right"
        Appearance61.TextVAlignAsString = "Middle"
        Me.txtsolicitado.Appearance = Appearance61
        Me.txtsolicitado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsolicitado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtsolicitado.Location = New System.Drawing.Point(870, 37)
        Me.txtsolicitado.MaxLength = 8
        Me.txtsolicitado.Name = "txtsolicitado"
        Me.txtsolicitado.ReadOnly = True
        Me.txtsolicitado.Size = New System.Drawing.Size(32, 21)
        Me.txtsolicitado.TabIndex = 161
        Me.txtsolicitado.TabStop = False
        Me.txtsolicitado.Text = "0.00"
        Me.txtsolicitado.Visible = False
        '
        'txtdisponible
        '
        Appearance84.FontData.BoldAsString = "False"
        Appearance84.ForeColor = System.Drawing.Color.Black
        Appearance84.TextHAlignAsString = "Right"
        Appearance84.TextVAlignAsString = "Middle"
        Me.txtdisponible.Appearance = Appearance84
        Me.txtdisponible.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdisponible.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtdisponible.Location = New System.Drawing.Point(534, 54)
        Me.txtdisponible.MaxLength = 8
        Me.txtdisponible.Name = "txtdisponible"
        Me.txtdisponible.ReadOnly = True
        Me.txtdisponible.Size = New System.Drawing.Size(94, 21)
        Me.txtdisponible.TabIndex = 159
        Me.txtdisponible.TabStop = False
        Me.txtdisponible.Text = "0.00"
        '
        'UltraLabel3
        '
        Appearance85.BackColor = System.Drawing.Color.Transparent
        Appearance85.TextHAlignAsString = "Center"
        Appearance85.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance85
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(441, 58)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(87, 14)
        Me.UltraLabel3.TabIndex = 160
        Me.UltraLabel3.Text = "Saldo disponible"
        '
        'txtliquidado
        '
        Appearance65.FontData.BoldAsString = "False"
        Appearance65.ForeColor = System.Drawing.Color.Black
        Appearance65.TextHAlignAsString = "Right"
        Appearance65.TextVAlignAsString = "Middle"
        Me.txtliquidado.Appearance = Appearance65
        Me.txtliquidado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtliquidado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtliquidado.Location = New System.Drawing.Point(870, 63)
        Me.txtliquidado.MaxLength = 8
        Me.txtliquidado.Name = "txtliquidado"
        Me.txtliquidado.ReadOnly = True
        Me.txtliquidado.Size = New System.Drawing.Size(32, 21)
        Me.txtliquidado.TabIndex = 157
        Me.txtliquidado.TabStop = False
        Me.txtliquidado.Text = "0.00"
        Me.txtliquidado.Visible = False
        '
        'txtxrendir
        '
        Appearance80.FontData.BoldAsString = "False"
        Appearance80.ForeColor = System.Drawing.Color.Black
        Appearance80.TextHAlignAsString = "Right"
        Appearance80.TextVAlignAsString = "Middle"
        Me.txtxrendir.Appearance = Appearance80
        Me.txtxrendir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtxrendir.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtxrendir.Location = New System.Drawing.Point(534, 28)
        Me.txtxrendir.MaxLength = 8
        Me.txtxrendir.Name = "txtxrendir"
        Me.txtxrendir.ReadOnly = True
        Me.txtxrendir.Size = New System.Drawing.Size(94, 21)
        Me.txtxrendir.TabIndex = 155
        Me.txtxrendir.TabStop = False
        Me.txtxrendir.Text = "0.00"
        '
        'UltraLabel1
        '
        Appearance62.BackColor = System.Drawing.Color.Transparent
        Appearance62.TextHAlignAsString = "Center"
        Appearance62.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance62
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(443, 31)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(85, 14)
        Me.UltraLabel1.TabIndex = 156
        Me.UltraLabel1.Text = "Saldo por rendir"
        '
        'txtlineacredito
        '
        Appearance63.FontData.BoldAsString = "False"
        Appearance63.ForeColor = System.Drawing.Color.Black
        Appearance63.TextHAlignAsString = "Right"
        Appearance63.TextVAlignAsString = "Middle"
        Me.txtlineacredito.Appearance = Appearance63
        Me.txtlineacredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtlineacredito.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtlineacredito.Location = New System.Drawing.Point(828, 37)
        Me.txtlineacredito.MaxLength = 8
        Me.txtlineacredito.Name = "txtlineacredito"
        Me.txtlineacredito.ReadOnly = True
        Me.txtlineacredito.Size = New System.Drawing.Size(36, 21)
        Me.txtlineacredito.TabIndex = 153
        Me.txtlineacredito.TabStop = False
        Me.txtlineacredito.Text = "0.00"
        Me.txtlineacredito.Visible = False
        '
        'rdbxrendir
        '
        Me.rdbxrendir.AutoSize = True
        Me.rdbxrendir.BackColor = System.Drawing.Color.White
        Me.rdbxrendir.Checked = True
        Me.rdbxrendir.Location = New System.Drawing.Point(278, 31)
        Me.rdbxrendir.Name = "rdbxrendir"
        Me.rdbxrendir.Size = New System.Drawing.Size(123, 17)
        Me.rdbxrendir.TabIndex = 147
        Me.rdbxrendir.TabStop = True
        Me.rdbxrendir.Text = "Solicitudes por rendir"
        Me.rdbxrendir.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(15, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "Hasta:"
        '
        'rdbrendida
        '
        Me.rdbrendida.AutoSize = True
        Me.rdbrendida.BackColor = System.Drawing.Color.White
        Me.rdbrendida.Location = New System.Drawing.Point(278, 51)
        Me.rdbrendida.Name = "rdbrendida"
        Me.rdbrendida.Size = New System.Drawing.Size(119, 17)
        Me.rdbrendida.TabIndex = 148
        Me.rdbrendida.Text = "Solicitudes rendidas"
        Me.rdbrendida.UseVisualStyleBackColor = False
        '
        'rdbtotal
        '
        Me.rdbtotal.AutoSize = True
        Me.rdbtotal.BackColor = System.Drawing.Color.White
        Me.rdbtotal.Location = New System.Drawing.Point(278, 72)
        Me.rdbtotal.Name = "rdbtotal"
        Me.rdbtotal.Size = New System.Drawing.Size(116, 17)
        Me.rdbtotal.TabIndex = 149
        Me.rdbtotal.Text = "Total de solicitudes"
        Me.rdbtotal.UseVisualStyleBackColor = False
        '
        'dtpfin
        '
        Me.dtpfin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfin.Location = New System.Drawing.Point(86, 65)
        Me.dtpfin.Name = "dtpfin"
        Me.dtpfin.Size = New System.Drawing.Size(120, 20)
        Me.dtpfin.TabIndex = 146
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 150
        Me.Label1.Text = "Desde:"
        '
        'dtpinicio
        '
        Me.dtpinicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpinicio.Location = New System.Drawing.Point(86, 39)
        Me.dtpinicio.Name = "dtpinicio"
        Me.dtpinicio.Size = New System.Drawing.Size(120, 20)
        Me.dtpinicio.TabIndex = 145
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
        Me.TabMaestroEntregas.Controls.Add(Me.UltraTabPageControl4)
        Me.TabMaestroEntregas.Controls.Add(Me.UltraTabPageControl1)
        Me.TabMaestroEntregas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMaestroEntregas.Location = New System.Drawing.Point(0, 0)
        Me.TabMaestroEntregas.MinTabWidth = 0
        Me.TabMaestroEntregas.Name = "TabMaestroEntregas"
        Appearance52.FontData.SizeInPoints = 12.0!
        Me.TabMaestroEntregas.SelectedTabAppearance = Appearance52
        Me.TabMaestroEntregas.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.TabMaestroEntregas.Size = New System.Drawing.Size(932, 611)
        Me.TabMaestroEntregas.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance51.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TabMaestroEntregas.TabHeaderAreaAppearance = Appearance51
        Me.TabMaestroEntregas.TabIndex = 4
        Me.TabMaestroEntregas.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab2.Key = "Lista"
        UltraTab2.TabPage = Me.UltraTabPageControl1
        UltraTab2.Text = "Listado de Pendientes"
        Appearance43.FontData.SizeInPoints = 8.0!
        UltraTab1.Appearance = Appearance43
        UltraTab1.Key = "Registro"
        UltraTab1.TabPage = Me.UltraTabPageControl4
        UltraTab1.Text = "Detalle"
        Me.TabMaestroEntregas.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2, UltraTab1})
        Me.TabMaestroEntregas.TabStop = False
        Me.TabMaestroEntregas.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(928, 573)
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
        Me.lblmensaje.Location = New System.Drawing.Point(0, 285)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(932, 39)
        Me.lblmensaje.TabIndex = 168
        Me.lblmensaje.Text = "Generando Reporte..."
        Me.lblmensaje.Visible = False
        '
        'FrmConsultas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 611)
        Me.Controls.Add(Me.lblmensaje)
        Me.Controls.Add(Me.TabMaestroEntregas)
        Me.Name = "FrmConsultas"
        Me.Text = "FrmConsultas"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.GridConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.UltraTabPageControl4.ResumeLayout(False)
        CType(Me.Gpb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gpb1.ResumeLayout(False)
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridConsultaDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.txtreintegrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsolicitado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtliquidado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtxrendir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtlineacredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabMaestroEntregas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabMaestroEntregas.ResumeLayout(False)
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMaestroEntregas As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents GridConsultas As Infragistics.Win.UltraWinGrid.UltraGrid
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
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents lbltrabajador As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Source2 As System.Windows.Forms.BindingSource
    Friend WithEvents Source3 As System.Windows.Forms.BindingSource
    Friend WithEvents Gpb1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents gridDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblcodigo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GridConsultaDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtsolicitado As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtdisponible As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtliquidado As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtxrendir As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtlineacredito As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents rdbxrendir As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdbrendida As System.Windows.Forms.RadioButton
    Friend WithEvents rdbtotal As System.Windows.Forms.RadioButton
    Friend WithEvents dtpfin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpinicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnVerAsiento As System.Windows.Forms.Button
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtreintegrar As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
End Class
