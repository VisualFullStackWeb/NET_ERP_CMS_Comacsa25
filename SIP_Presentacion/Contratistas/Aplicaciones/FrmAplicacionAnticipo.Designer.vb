<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAplicacionAnticipo
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
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAplicacionAnticipo))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANILLA", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PROVEEDOR", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RAZSOC", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RETENCION", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DOCUMENTO", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MONEDA", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IMPORTE", 6)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHAEMISION", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHAPROC", 8)
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CONCEPTO", -2, False)
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "MONTOTOTAL", -2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "MONTOTOTAL", -2, False)
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1016)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(897)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(726)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(446)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(788)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(788)
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO_DOC", 0)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SERIE", 1)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUMDOC", 2)
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MONEDA", 3)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SALDO", 4)
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IMPORTE", 5)
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IMPORTE_ANTICIPO", 6)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROV", 7)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TCAMBIO", 8)
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_TIPODOC", 9)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_DOC", 10)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(504)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(504)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion13 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion14 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion16 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUMSOLICITUD", 0)
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_SUPERVISOR", 1)
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROV", 2)
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUM_DOC", 3)
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_DOC", 4)
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MONEDA", 5)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SALDO", 6)
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IMPORTE", 7)
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BANCO", 8)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NROASIGNADO", 9)
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_PROC", 10)
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("T_CAMBIO", 11)
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("INDANTICIDETRAC", 12)
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PERIODOANTIDETRAC", 13)
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO_DOC", 14)
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_BANCO", 15)
        Dim ColScrollRegion17 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(504)
        Dim ColScrollRegion18 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion19 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion20 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion21 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion22 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion23 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion24 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion25 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.dtpfechaini = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.dtpfechafin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Grid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txttotaldoc = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txttotalanti = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel19 = New Infragistics.Win.Misc.UltraLabel
        Me.lblnSolicitud = New Infragistics.Win.Misc.UltraLabel
        Me.gridDocumento = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.gridconceptos = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.dtfecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.txtsupervisor = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtidsupervisor = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtidcontratista = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcantera = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcodcantera = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcodcontratista = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcontratista = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.dtpfechaini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpfechafin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.txttotaldoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttotalanti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraLabel4.SuspendLayout()
        Me.UltraLabel19.SuspendLayout()
        CType(Me.gridDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridconceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtfecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsupervisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidsupervisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidcontratista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcantera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodcantera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodcontratista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcontratista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.dtpfechaini)
        Me.UltraTabPageControl2.Controls.Add(Me.dtpfechafin)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl2.Controls.Add(Me.Grid1)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(1039, 443)
        '
        'dtpfechaini
        '
        Me.dtpfechaini.AutoSize = False
        Me.dtpfechaini.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpfechaini.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpfechaini.Location = New System.Drawing.Point(66, 31)
        Me.dtpfechaini.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpfechaini.Name = "dtpfechaini"
        Me.dtpfechaini.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpfechaini.Size = New System.Drawing.Size(147, 18)
        Me.dtpfechaini.TabIndex = 177
        Me.dtpfechaini.TabStop = False
        Me.dtpfechaini.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'dtpfechafin
        '
        Me.dtpfechafin.AutoSize = False
        Me.dtpfechafin.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpfechafin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpfechafin.Location = New System.Drawing.Point(66, 57)
        Me.dtpfechafin.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpfechafin.Size = New System.Drawing.Size(147, 18)
        Me.dtpfechafin.TabIndex = 176
        Me.dtpfechafin.TabStop = False
        Me.dtpfechafin.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'UltraLabel1
        '
        Appearance69.BackColor = System.Drawing.Color.Transparent
        Appearance69.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance69
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 58)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(48, 17)
        Me.UltraLabel1.TabIndex = 175
        Me.UltraLabel1.Text = "HASTA :"
        '
        'Grid1
        '
        Me.Grid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid1.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance70.BackColor = System.Drawing.SystemColors.Window
        Appearance70.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid1.DisplayLayout.Appearance = Appearance70
        Me.Grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn1.Format = ""
        Appearance6.Image = CType(resources.GetObject("Appearance6.Image"), Object)
        Appearance6.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance6
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Nullable = Infragistics.Win.UltraWinGrid.Nullable.[Nothing]
        UltraGridColumn1.NullText = "0.000"
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 43
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "CODIGO"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 108
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "CONTRATISTA"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 203
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.Caption = "COMP. RETENCION"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 116
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 153
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.Caption = "MON."
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 45
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance4
        UltraGridColumn8.Format = "###,##0.00"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Width = 98
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.Caption = "FECHA DOC."
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 107
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.Caption = "FECHA PROC."
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 105
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10})
        Appearance15.TextVAlignAsString = "Middle"
        UltraGridBand1.Override.RowAppearance = Appearance15
        Appearance9.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance9
        SummarySettings1.DisplayFormat = "Total"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance5
        Appearance71.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance71
        SummarySettings2.DisplayFormat = "{0:###,##0.00}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance11
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
        UltraGridBand1.SummaryFooterCaption = ""
        Me.Grid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.Grid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.Grid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.Grid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.Grid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.Grid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.Grid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance72.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance72.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance72.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance72.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.GroupByBox.Appearance = Appearance72
        Appearance73.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance73
        Me.Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.Grid1.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid1.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.CardAreaAppearance = Appearance29
        Appearance55.BorderColor = System.Drawing.Color.Silver
        Appearance55.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid1.DisplayLayout.Override.CellAppearance = Appearance55
        Me.Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid1.DisplayLayout.Override.CellPadding = 0
        Me.Grid1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance56.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid1.DisplayLayout.Override.FilterRowAppearance = Appearance56
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance57.BackColor = System.Drawing.SystemColors.Control
        Appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance57.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance57.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.GroupByRowAppearance = Appearance57
        Appearance58.FontData.Name = "Arial Narrow"
        Appearance58.FontData.SizeInPoints = 10.0!
        Appearance58.TextHAlignAsString = "Left"
        Me.Grid1.DisplayLayout.Override.HeaderAppearance = Appearance58
        Me.Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid1.DisplayLayout.Override.MinRowHeight = 24
        Appearance59.BackColor = System.Drawing.SystemColors.Window
        Appearance59.BorderColor = System.Drawing.Color.Silver
        Me.Grid1.DisplayLayout.Override.RowAppearance = Appearance59
        Me.Grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance60.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance60
        Me.Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.Location = New System.Drawing.Point(12, 86)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(1018, 279)
        Me.Grid1.TabIndex = 168
        Me.Grid1.Text = "UltraGrid1"
        '
        'UltraLabel3
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Appearance19.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance19
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(12, 31)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(49, 17)
        Me.UltraLabel3.TabIndex = 162
        Me.UltraLabel3.Text = "DESDE :"
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.txttotaldoc)
        Me.UltraTabPageControl1.Controls.Add(Me.txttotalanti)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel4)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel19)
        Me.UltraTabPageControl1.Controls.Add(Me.gridDocumento)
        Me.UltraTabPageControl1.Controls.Add(Me.gridconceptos)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl1.Controls.Add(Me.dtfecha)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel10)
        Me.UltraTabPageControl1.Controls.Add(Me.txtsupervisor)
        Me.UltraTabPageControl1.Controls.Add(Me.txtidsupervisor)
        Me.UltraTabPageControl1.Controls.Add(Me.txtidcontratista)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel11)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcantera)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcodcantera)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel7)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcodcontratista)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcontratista)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1039, 443)
        '
        'txttotaldoc
        '
        Me.txttotaldoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.txttotaldoc.Appearance = Appearance12
        Me.txttotaldoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotaldoc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttotaldoc.Location = New System.Drawing.Point(913, 413)
        Me.txttotaldoc.MaxLength = 8
        Me.txttotaldoc.Name = "txttotaldoc"
        Me.txttotaldoc.ReadOnly = True
        Me.txttotaldoc.Size = New System.Drawing.Size(118, 21)
        Me.txttotaldoc.TabIndex = 248
        Me.txttotaldoc.TabStop = False
        '
        'txttotalanti
        '
        Me.txttotalanti.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance23.FontData.BoldAsString = "False"
        Appearance23.ForeColor = System.Drawing.Color.Black
        Appearance23.TextHAlignAsString = "Right"
        Appearance23.TextVAlignAsString = "Middle"
        Me.txttotalanti.Appearance = Appearance23
        Me.txttotalanti.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotalanti.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttotalanti.Location = New System.Drawing.Point(397, 413)
        Me.txttotalanti.MaxLength = 8
        Me.txttotalanti.Name = "txttotalanti"
        Me.txttotalanti.ReadOnly = True
        Me.txttotalanti.Size = New System.Drawing.Size(118, 21)
        Me.txttotalanti.TabIndex = 247
        Me.txttotalanti.TabStop = False
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance84.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance84.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance84.ForeColor = System.Drawing.Color.White
        Appearance84.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance84.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance84.TextHAlignAsString = "Left"
        Appearance84.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance84
        Me.UltraLabel4.Controls.Add(Me.UltraLabel5)
        Me.UltraLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption
        Me.UltraLabel4.Location = New System.Drawing.Point(525, 135)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(506, 25)
        Me.UltraLabel4.TabIndex = 246
        Me.UltraLabel4.Text = "COMPROBANTE DE PAGO"
        '
        'UltraLabel5
        '
        Appearance121.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance121.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance121.ForeColor = System.Drawing.Color.White
        Appearance121.TextHAlignAsString = "Right"
        Appearance121.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance121
        Me.UltraLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(550, 6)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(223, 16)
        Me.UltraLabel5.TabIndex = 138
        Me.UltraLabel5.Text = "N° Solicitud:"
        Me.UltraLabel5.Visible = False
        '
        'UltraLabel19
        '
        Me.UltraLabel19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance1.ForeColor = System.Drawing.Color.White
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance1.TextHAlignAsString = "Left"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel19.Appearance = Appearance1
        Me.UltraLabel19.Controls.Add(Me.lblnSolicitud)
        Me.UltraLabel19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel19.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption
        Me.UltraLabel19.Location = New System.Drawing.Point(9, 135)
        Me.UltraLabel19.Name = "UltraLabel19"
        Me.UltraLabel19.Size = New System.Drawing.Size(506, 25)
        Me.UltraLabel19.TabIndex = 245
        Me.UltraLabel19.Text = " ANTICIPOS"
        '
        'lblnSolicitud
        '
        Appearance7.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance7.ForeColor = System.Drawing.Color.White
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblnSolicitud.Appearance = Appearance7
        Me.lblnSolicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnSolicitud.Location = New System.Drawing.Point(550, 6)
        Me.lblnSolicitud.Name = "lblnSolicitud"
        Me.lblnSolicitud.Size = New System.Drawing.Size(223, 16)
        Me.lblnSolicitud.TabIndex = 138
        Me.lblnSolicitud.Text = "N° Solicitud:"
        Me.lblnSolicitud.Visible = False
        '
        'gridDocumento
        '
        Me.gridDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Appearance43.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridDocumento.DisplayLayout.Appearance = Appearance43
        Me.gridDocumento.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance44.Image = CType(resources.GetObject("Appearance44.Image"), Object)
        Appearance44.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance44.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn11.Header.Appearance = Appearance44
        UltraGridColumn11.Header.Caption = ""
        UltraGridColumn11.Header.VisiblePosition = 0
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.MaxWidth = 25
        UltraGridColumn11.MinWidth = 20
        UltraGridColumn11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn11.Width = 20
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.Header.Caption = "TD"
        UltraGridColumn12.Header.VisiblePosition = 2
        UltraGridColumn12.Width = 25
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.VisiblePosition = 3
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.MaxLength = 4
        UltraGridColumn13.Width = 58
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance18.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        UltraGridColumn14.CellButtonAppearance = Appearance18
        UltraGridColumn14.Header.VisiblePosition = 1
        UltraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton
        UltraGridColumn14.Width = 152
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.Header.Caption = "MON"
        UltraGridColumn15.Header.VisiblePosition = 4
        UltraGridColumn15.Width = 47
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance21
        UltraGridColumn16.Format = "#####0.00"
        UltraGridColumn16.Header.VisiblePosition = 5
        UltraGridColumn16.Width = 78
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance22
        UltraGridColumn17.Format = "#####0.00"
        UltraGridColumn17.Header.VisiblePosition = 6
        UltraGridColumn17.MaskInput = "{double:8.2}"
        UltraGridColumn17.Width = 79
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn18.Header.VisiblePosition = 7
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 61
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn19.Header.VisiblePosition = 8
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.Width = 52
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance25.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance25
        UltraGridColumn20.Header.VisiblePosition = 9
        UltraGridColumn20.Width = 68
        UltraGridColumn21.Header.VisiblePosition = 10
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 88
        UltraGridColumn22.Header.VisiblePosition = 11
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 88
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22})
        Me.gridDocumento.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridDocumento.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDocumento.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDocumento.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridDocumento.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridDocumento.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridDocumento.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridDocumento.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridDocumento.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridDocumento.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridDocumento.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridDocumento.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridDocumento.DisplayLayout.ColScrollRegions.Add(ColScrollRegion16)
        Me.gridDocumento.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance48.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance48.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance48.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDocumento.DisplayLayout.GroupByBox.Appearance = Appearance48
        Appearance49.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDocumento.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance49
        Me.gridDocumento.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDocumento.DisplayLayout.GroupByBox.Hidden = True
        Appearance51.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance51.BackColor2 = System.Drawing.SystemColors.Control
        Appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDocumento.DisplayLayout.GroupByBox.PromptAppearance = Appearance51
        Me.gridDocumento.DisplayLayout.MaxColScrollRegions = 1
        Me.gridDocumento.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridDocumento.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDocumento.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridDocumento.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Me.gridDocumento.DisplayLayout.Override.CardAreaAppearance = Appearance52
        Appearance54.BorderColor = System.Drawing.Color.Silver
        Appearance54.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridDocumento.DisplayLayout.Override.CellAppearance = Appearance54
        Me.gridDocumento.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridDocumento.DisplayLayout.Override.CellPadding = 0
        Me.gridDocumento.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridDocumento.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridDocumento.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridDocumento.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance61.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance61.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridDocumento.DisplayLayout.Override.FilterRowAppearance = Appearance61
        Me.gridDocumento.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridDocumento.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance62.BackColor = System.Drawing.SystemColors.Control
        Appearance62.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance62.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance62.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDocumento.DisplayLayout.Override.GroupByRowAppearance = Appearance62
        Appearance66.FontData.Name = "Arial Narrow"
        Appearance66.FontData.SizeInPoints = 10.0!
        Appearance66.TextHAlignAsString = "Left"
        Me.gridDocumento.DisplayLayout.Override.HeaderAppearance = Appearance66
        Me.gridDocumento.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridDocumento.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridDocumento.DisplayLayout.Override.MinRowHeight = 24
        Appearance67.BackColor = System.Drawing.SystemColors.Window
        Appearance67.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance67.TextVAlignAsString = "Middle"
        Me.gridDocumento.DisplayLayout.Override.RowAppearance = Appearance67
        Me.gridDocumento.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridDocumento.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridDocumento.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance68.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridDocumento.DisplayLayout.Override.TemplateAddRowAppearance = Appearance68
        Me.gridDocumento.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridDocumento.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridDocumento.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDocumento.Location = New System.Drawing.Point(525, 166)
        Me.gridDocumento.Name = "gridDocumento"
        Me.gridDocumento.Size = New System.Drawing.Size(506, 237)
        Me.gridDocumento.TabIndex = 244
        Me.gridDocumento.Text = "UltraGrid1"
        '
        'gridconceptos
        '
        Me.gridconceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance74.BackColor = System.Drawing.SystemColors.Window
        Appearance74.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridconceptos.DisplayLayout.Appearance = Appearance74
        Me.gridconceptos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn23.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance75.Image = CType(resources.GetObject("Appearance75.Image"), Object)
        Appearance75.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance75.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn23.Header.Appearance = Appearance75
        UltraGridColumn23.Header.Caption = ""
        UltraGridColumn23.Header.VisiblePosition = 0
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.MaxWidth = 25
        UltraGridColumn23.MinWidth = 20
        UltraGridColumn23.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn23.Width = 20
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn24.Header.VisiblePosition = 1
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.Width = 30
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn25.Header.VisiblePosition = 2
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 14
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn26.Header.VisiblePosition = 3
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.Width = 13
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn27.Header.VisiblePosition = 4
        UltraGridColumn27.Width = 105
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn28.Header.Caption = "FECHA"
        UltraGridColumn28.Header.VisiblePosition = 5
        UltraGridColumn28.Width = 79
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn29.Header.Caption = "MON"
        UltraGridColumn29.Header.VisiblePosition = 6
        UltraGridColumn29.Width = 37
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance14
        UltraGridColumn30.Header.VisiblePosition = 7
        UltraGridColumn30.Width = 57
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance16
        UltraGridColumn31.Format = "#####0.00"
        UltraGridColumn31.Header.VisiblePosition = 8
        UltraGridColumn31.MaskInput = "{double:8.2}"
        UltraGridColumn31.Width = 62
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn32.Header.VisiblePosition = 9
        UltraGridColumn32.Width = 62
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn33.Header.VisiblePosition = 10
        UltraGridColumn33.Hidden = True
        UltraGridColumn33.Width = 88
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn34.Header.VisiblePosition = 11
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.Width = 54
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance17
        UltraGridColumn35.Header.Caption = "TC"
        UltraGridColumn35.Header.VisiblePosition = 12
        UltraGridColumn35.Width = 47
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn36.Header.VisiblePosition = 13
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.Width = 93
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn37.Header.VisiblePosition = 14
        UltraGridColumn37.Hidden = True
        UltraGridColumn37.Width = 144
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn38.Header.VisiblePosition = 15
        UltraGridColumn38.Hidden = True
        UltraGridColumn38.Width = 88
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn39.Header.VisiblePosition = 16
        UltraGridColumn39.Hidden = True
        UltraGridColumn39.Width = 88
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39})
        Me.gridconceptos.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.gridconceptos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridconceptos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion17)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion18)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion19)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion20)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion21)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion22)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion23)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion24)
        Me.gridconceptos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion25)
        Me.gridconceptos.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance79.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance79.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance79.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance79.BorderColor = System.Drawing.SystemColors.Window
        Me.gridconceptos.DisplayLayout.GroupByBox.Appearance = Appearance79
        Appearance80.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridconceptos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance80
        Me.gridconceptos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridconceptos.DisplayLayout.GroupByBox.Hidden = True
        Appearance81.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance81.BackColor2 = System.Drawing.SystemColors.Control
        Appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance81.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridconceptos.DisplayLayout.GroupByBox.PromptAppearance = Appearance81
        Me.gridconceptos.DisplayLayout.MaxColScrollRegions = 1
        Me.gridconceptos.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridconceptos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridconceptos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridconceptos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance82.BackColor = System.Drawing.SystemColors.Window
        Me.gridconceptos.DisplayLayout.Override.CardAreaAppearance = Appearance82
        Appearance83.BorderColor = System.Drawing.Color.Silver
        Appearance83.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridconceptos.DisplayLayout.Override.CellAppearance = Appearance83
        Me.gridconceptos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridconceptos.DisplayLayout.Override.CellPadding = 0
        Me.gridconceptos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridconceptos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridconceptos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridconceptos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance10.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridconceptos.DisplayLayout.Override.FilterRowAppearance = Appearance10
        Me.gridconceptos.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridconceptos.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance87.BackColor = System.Drawing.SystemColors.Control
        Appearance87.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance87.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance87.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance87.BorderColor = System.Drawing.SystemColors.Window
        Me.gridconceptos.DisplayLayout.Override.GroupByRowAppearance = Appearance87
        Appearance88.FontData.Name = "Arial Narrow"
        Appearance88.FontData.SizeInPoints = 10.0!
        Appearance88.TextHAlignAsString = "Left"
        Me.gridconceptos.DisplayLayout.Override.HeaderAppearance = Appearance88
        Me.gridconceptos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridconceptos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridconceptos.DisplayLayout.Override.MinRowHeight = 24
        Appearance89.BackColor = System.Drawing.SystemColors.Window
        Appearance89.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance89.TextVAlignAsString = "Middle"
        Me.gridconceptos.DisplayLayout.Override.RowAppearance = Appearance89
        Me.gridconceptos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridconceptos.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridconceptos.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance90.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridconceptos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance90
        Me.gridconceptos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridconceptos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridconceptos.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridconceptos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridconceptos.Location = New System.Drawing.Point(9, 166)
        Me.gridconceptos.Name = "gridconceptos"
        Me.gridconceptos.Size = New System.Drawing.Size(506, 237)
        Me.gridconceptos.TabIndex = 243
        Me.gridconceptos.Text = "UltraGrid1"
        '
        'UltraLabel2
        '
        Appearance86.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance86
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(44, 103)
        Me.UltraLabel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(35, 17)
        Me.UltraLabel2.TabIndex = 242
        Me.UltraLabel2.Text = "Fecha"
        '
        'dtfecha
        '
        Me.dtfecha.AutoSize = False
        Me.dtfecha.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtfecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtfecha.Location = New System.Drawing.Point(105, 101)
        Me.dtfecha.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtfecha.Name = "dtfecha"
        Me.dtfecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtfecha.Size = New System.Drawing.Size(147, 21)
        Me.dtfecha.TabIndex = 241
        Me.dtfecha.TabStop = False
        Me.dtfecha.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'UltraLabel10
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Center"
        Appearance8.TextVAlignAsString = "Middle"
        Me.UltraLabel10.Appearance = Appearance8
        Me.UltraLabel10.AutoSize = True
        Me.UltraLabel10.Location = New System.Drawing.Point(23, 74)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(58, 14)
        Me.UltraLabel10.TabIndex = 240
        Me.UltraLabel10.Text = "Supervisor"
        '
        'txtsupervisor
        '
        Appearance50.FontData.BoldAsString = "False"
        Appearance50.ForeColor = System.Drawing.Color.Black
        Appearance50.TextHAlignAsString = "Left"
        Appearance50.TextVAlignAsString = "Middle"
        Me.txtsupervisor.Appearance = Appearance50
        Me.txtsupervisor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsupervisor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtsupervisor.Location = New System.Drawing.Point(105, 73)
        Me.txtsupervisor.MaxLength = 8
        Me.txtsupervisor.Name = "txtsupervisor"
        Me.txtsupervisor.ReadOnly = True
        Me.txtsupervisor.Size = New System.Drawing.Size(430, 21)
        Me.txtsupervisor.TabIndex = 239
        Me.txtsupervisor.TabStop = False
        '
        'txtidsupervisor
        '
        Appearance65.FontData.BoldAsString = "False"
        Appearance65.ForeColor = System.Drawing.Color.Black
        Appearance65.TextHAlignAsString = "Left"
        Appearance65.TextVAlignAsString = "Middle"
        Me.txtidsupervisor.Appearance = Appearance65
        Me.txtidsupervisor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidsupervisor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtidsupervisor.Location = New System.Drawing.Point(567, 43)
        Me.txtidsupervisor.MaxLength = 8
        Me.txtidsupervisor.Name = "txtidsupervisor"
        Me.txtidsupervisor.ReadOnly = True
        Me.txtidsupervisor.Size = New System.Drawing.Size(64, 21)
        Me.txtidsupervisor.TabIndex = 238
        Me.txtidsupervisor.TabStop = False
        Me.txtidsupervisor.Visible = False
        '
        'txtidcontratista
        '
        Appearance53.FontData.BoldAsString = "False"
        Appearance53.ForeColor = System.Drawing.Color.Black
        Appearance53.TextHAlignAsString = "Left"
        Appearance53.TextVAlignAsString = "Middle"
        Me.txtidcontratista.Appearance = Appearance53
        Me.txtidcontratista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidcontratista.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtidcontratista.Location = New System.Drawing.Point(567, 16)
        Me.txtidcontratista.MaxLength = 8
        Me.txtidcontratista.Name = "txtidcontratista"
        Me.txtidcontratista.ReadOnly = True
        Me.txtidcontratista.Size = New System.Drawing.Size(64, 21)
        Me.txtidcontratista.TabIndex = 237
        Me.txtidcontratista.TabStop = False
        Me.txtidcontratista.Visible = False
        '
        'UltraLabel11
        '
        Appearance99.BackColor = System.Drawing.Color.Transparent
        Appearance99.TextHAlignAsString = "Center"
        Appearance99.TextVAlignAsString = "Middle"
        Me.UltraLabel11.Appearance = Appearance99
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Location = New System.Drawing.Point(35, 50)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(44, 14)
        Me.UltraLabel11.TabIndex = 236
        Me.UltraLabel11.Text = "Cantera"
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
        Me.txtcantera.Location = New System.Drawing.Point(258, 46)
        Me.txtcantera.MaxLength = 8
        Me.txtcantera.Name = "txtcantera"
        Me.txtcantera.ReadOnly = True
        Me.txtcantera.Size = New System.Drawing.Size(277, 21)
        Me.txtcantera.TabIndex = 235
        Me.txtcantera.TabStop = False
        '
        'txtcodcantera
        '
        Appearance101.FontData.BoldAsString = "False"
        Appearance101.ForeColor = System.Drawing.Color.Black
        Appearance101.TextHAlignAsString = "Left"
        Appearance101.TextVAlignAsString = "Middle"
        Me.txtcodcantera.Appearance = Appearance101
        Me.txtcodcantera.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodcantera.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodcantera.Location = New System.Drawing.Point(105, 46)
        Me.txtcodcantera.MaxLength = 8
        Me.txtcodcantera.Name = "txtcodcantera"
        Me.txtcodcantera.ReadOnly = True
        Me.txtcodcantera.Size = New System.Drawing.Size(147, 21)
        Me.txtcodcantera.TabIndex = 234
        Me.txtcodcantera.TabStop = False
        '
        'UltraLabel7
        '
        Appearance63.BackColor = System.Drawing.Color.Transparent
        Appearance63.TextHAlignAsString = "Center"
        Appearance63.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance63
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Location = New System.Drawing.Point(22, 20)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(59, 14)
        Me.UltraLabel7.TabIndex = 233
        Me.UltraLabel7.Text = "Contratista"
        '
        'txtcodcontratista
        '
        Appearance24.FontData.BoldAsString = "False"
        Appearance24.ForeColor = System.Drawing.Color.Black
        Appearance24.TextHAlignAsString = "Left"
        Appearance24.TextVAlignAsString = "Middle"
        Me.txtcodcontratista.Appearance = Appearance24
        Me.txtcodcontratista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodcontratista.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodcontratista.Location = New System.Drawing.Point(105, 17)
        Me.txtcodcontratista.MaxLength = 8
        Me.txtcodcontratista.Name = "txtcodcontratista"
        Me.txtcodcontratista.ReadOnly = True
        Me.txtcodcontratista.Size = New System.Drawing.Size(147, 21)
        Me.txtcodcontratista.TabIndex = 231
        Me.txtcodcontratista.TabStop = False
        '
        'txtcontratista
        '
        Appearance85.FontData.BoldAsString = "False"
        Appearance85.ForeColor = System.Drawing.Color.Black
        Appearance85.TextHAlignAsString = "Left"
        Appearance85.TextVAlignAsString = "Middle"
        Me.txtcontratista.Appearance = Appearance85
        Me.txtcontratista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontratista.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcontratista.Location = New System.Drawing.Point(258, 17)
        Me.txtcontratista.MaxLength = 8
        Me.txtcontratista.Name = "txtcontratista"
        Me.txtcontratista.ReadOnly = True
        Me.txtcontratista.Size = New System.Drawing.Size(277, 21)
        Me.txtcontratista.TabIndex = 232
        Me.txtcontratista.TabStop = False
        '
        'Tab1
        '
        Appearance124.FontData.BoldAsString = "True"
        Appearance124.FontData.Name = "Arial Narrow"
        Appearance124.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance124
        Appearance125.FontData.Name = "Arial Narrow"
        Appearance125.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance125
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl2)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.Tab1.Size = New System.Drawing.Size(1043, 481)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance13
        Me.Tab1.TabIndex = 10
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance2.Cursor = System.Windows.Forms.Cursors.Default
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.Name = "Arial Narrow"
        Appearance2.FontData.SizeInPoints = 16.0!
        UltraTab6.ActiveAppearance = Appearance2
        Appearance3.FontData.Name = "Arial Narrow"
        Appearance3.FontData.SizeInPoints = 10.0!
        UltraTab6.Appearance = Appearance3
        UltraTab6.Key = "T01"
        UltraTab6.TabPage = Me.UltraTabPageControl2
        UltraTab6.Text = "Relación de Aplicaciones"
        Appearance91.Cursor = System.Windows.Forms.Cursors.Default
        Appearance91.FontData.BoldAsString = "True"
        Appearance91.FontData.Name = "Arial Narrow"
        Appearance91.FontData.SizeInPoints = 16.0!
        UltraTab1.ActiveAppearance = Appearance91
        Appearance20.FontData.Name = "Arial Narrow"
        Appearance20.FontData.SizeInPoints = 10.0!
        UltraTab1.Appearance = Appearance20
        UltraTab1.Key = "T02"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Aplicación de Anticipos"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab6, UltraTab1})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(1039, 443)
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
        Me.lblmensaje.Location = New System.Drawing.Point(0, 160)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(1043, 39)
        Me.lblmensaje.TabIndex = 174
        Me.lblmensaje.Text = "Procesando Datos..."
        Me.lblmensaje.Visible = False
        '
        'FrmAplicacionAnticipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 481)
        Me.Controls.Add(Me.lblmensaje)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmAplicacionAnticipo"
        Me.Text = "FrmAplicacionAnticipo"
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.dtpfechaini, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpfechafin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.txttotaldoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttotalanti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraLabel4.ResumeLayout(False)
        Me.UltraLabel19.ResumeLayout(False)
        CType(Me.gridDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridconceptos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtfecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsupervisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidsupervisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidcontratista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcantera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodcantera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodcontratista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcontratista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Grid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents dtpfechaini As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dtpfechafin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtsupervisor As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtidsupervisor As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtidcontratista As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcantera As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcodcantera As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcodcontratista As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcontratista As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtfecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents gridDocumento As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridconceptos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel19 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblnSolicitud As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Source2 As System.Windows.Forms.BindingSource
    Friend WithEvents Source3 As System.Windows.Forms.BindingSource
    Friend WithEvents txttotaldoc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txttotalanti As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
