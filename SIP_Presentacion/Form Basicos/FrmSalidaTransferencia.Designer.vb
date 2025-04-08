<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSalidaTransferencia
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroDocumento")
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoTipoMovimiento")
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoMovimiento")
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoAlmacen")
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Almacen")
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado")
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroMovimientoInterno")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoMotivo")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroGuia")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoAlmacenDestino")
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
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroGuia")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoAlmacenDestino")
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UM")
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoProducto")
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenCompra")
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroBillete")
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance157 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance158 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance159 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance160 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descripcion")
        Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UM")
        Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Stock")
        Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoProducto")
        Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("OrdenCompra")
        Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroBillete")
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo", 0)
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 1)
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance126 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance129 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance143 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSalidaTransferencia))
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Cia1 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.DgvSalidaTransferencia = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.DtFechaConsulta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.TxtNumeroDocumento = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Cia2 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.GrpSalidaTransferencia = New Infragistics.Win.Misc.UltraGroupBox
        Me.BtnPendientes = New Infragistics.Win.Misc.UltraButton
        Me.BtnGuia = New Infragistics.Win.Misc.UltraButton
        Me.LblNumeroGuia = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.LblSerieGuia = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.LblRuc = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel20 = New Infragistics.Win.Misc.UltraLabel
        Me.LblLugarEntrega = New Infragistics.Win.Misc.UltraLabel
        Me.LblRazonSocial = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.LblCodigo = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.dtFeStringegistro = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.dgvDetalleSalidaTransferencia = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraLabel29 = New Infragistics.Win.Misc.UltraLabel
        Me.TxtNumeroMovimiento = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.GrpDatosMovimiento = New Infragistics.Win.Misc.UltraGroupBox
        Me.CboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.CboTipoMovimiento = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.RdbExterna = New System.Windows.Forms.RadioButton
        Me.RdbInterna = New System.Windows.Forms.RadioButton
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.CboAlmacenDestino = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.LblEstado = New Infragistics.Win.Misc.UltraLabel
        Me.GrpAnulacion = New Infragistics.Win.Misc.UltraGroupBox
        Me.CboAnulacion = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.BtCancelar = New Infragistics.Win.Misc.UltraButton
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.TabSalidaTransferencia = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.Cia1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvSalidaTransferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtFechaConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumeroDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.Cia2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrpSalidaTransferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSalidaTransferencia.SuspendLayout()
        CType(Me.LblNumeroGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSerieGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFeStringegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalleSalidaTransferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumeroMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrpDatosMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDatosMovimiento.SuspendLayout()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboTipoMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboAlmacenDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrpAnulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpAnulacion.SuspendLayout()
        CType(Me.CboAnulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabSalidaTransferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSalidaTransferencia.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Cia1)
        Me.UltraTabPageControl1.Controls.Add(Me.DgvSalidaTransferencia)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl1.Controls.Add(Me.DtFechaConsulta)
        Me.UltraTabPageControl1.Controls.Add(Me.TxtNumeroDocumento)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel14)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(812, 469)
        '
        'Cia1
        '
        Me.Cia1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance2.BackColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Appearance = Appearance2
        Me.Cia1.DisplayLayout.InterBandSpacing = 18
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Me.Cia1.DisplayLayout.Override.CardAreaAppearance = Appearance6
        Appearance7.FontData.BoldAsString = "True"
        Appearance7.FontData.SizeInPoints = 9.0!
        Appearance7.ForeColor = System.Drawing.Color.Navy
        Me.Cia1.DisplayLayout.Override.CellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.Color.Navy
        Appearance8.FontData.BoldAsString = "True"
        Appearance8.FontData.ItalicAsString = "True"
        Appearance8.FontData.SizeInPoints = 10.0!
        Appearance8.ForeColor = System.Drawing.Color.White
        Appearance8.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.Cia1.DisplayLayout.Override.HeaderAppearance = Appearance8
        Appearance14.BackColor = System.Drawing.Color.Navy
        Appearance14.BorderColor = System.Drawing.Color.White
        Appearance14.ForeColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Override.RowSelectorAppearance = Appearance14
        Me.Cia1.DisplayLayout.Override.RowSpacingAfter = 4
        Me.Cia1.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance16.BackColor = System.Drawing.Color.Navy
        Appearance16.ForeColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Override.SelectedRowAppearance = Appearance16
        Me.Cia1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.Cia1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.Cia1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cia1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cia1.Location = New System.Drawing.Point(60, 10)
        Me.Cia1.Name = "Cia1"
        Me.Cia1.ReadOnly = True
        Me.Cia1.Size = New System.Drawing.Size(270, 22)
        Me.Cia1.TabIndex = 97
        '
        'DgvSalidaTransferencia
        '
        Me.DgvSalidaTransferencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvSalidaTransferencia.DataSource = Me.UltraDataSource2
        Appearance1.BackColor = System.Drawing.Color.White
        Me.DgvSalidaTransferencia.DisplayLayout.Appearance = Appearance1
        Me.DgvSalidaTransferencia.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.ColHeaderLines = 2
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance54.FontData.BoldAsString = "False"
        Appearance54.FontData.SizeInPoints = 8.0!
        Appearance54.TextHAlignAsString = "Center"
        Appearance54.TextVAlignAsString = "Middle"
        UltraGridColumn1.CellAppearance = Appearance54
        Appearance56.FontData.BoldAsString = "False"
        Appearance56.FontData.SizeInPoints = 8.0!
        UltraGridColumn1.Header.Appearance = Appearance56
        UltraGridColumn1.Header.Caption = "Nro" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Documento"
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.MaxWidth = 100
        UltraGridColumn1.MinWidth = 100
        UltraGridColumn1.Width = 100
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance57.FontData.BoldAsString = "False"
        Appearance57.FontData.SizeInPoints = 8.0!
        Appearance57.TextHAlignAsString = "Center"
        Appearance57.TextVAlignAsString = "Middle"
        UltraGridColumn2.CellAppearance = Appearance57
        Appearance58.FontData.BoldAsString = "False"
        Appearance58.FontData.SizeInPoints = 8.0!
        UltraGridColumn2.Header.Appearance = Appearance58
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 45
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance60.FontData.BoldAsString = "False"
        Appearance60.FontData.SizeInPoints = 8.0!
        Appearance60.TextHAlignAsString = "Center"
        Appearance60.TextVAlignAsString = "Middle"
        UltraGridColumn3.CellAppearance = Appearance60
        Appearance65.FontData.BoldAsString = "False"
        Appearance65.FontData.SizeInPoints = 8.0!
        UltraGridColumn3.Header.Appearance = Appearance65
        UltraGridColumn3.Header.Caption = "Tipo de Movimiento"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.MaxWidth = 240
        UltraGridColumn3.MinWidth = 240
        UltraGridColumn3.Width = 240
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance66.FontData.BoldAsString = "False"
        Appearance66.FontData.SizeInPoints = 8.0!
        UltraGridColumn4.Header.Appearance = Appearance66
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 60
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance67.FontData.BoldAsString = "False"
        Appearance67.FontData.SizeInPoints = 8.0!
        Appearance67.TextHAlignAsString = "Center"
        Appearance67.TextVAlignAsString = "Middle"
        UltraGridColumn5.CellAppearance = Appearance67
        Appearance69.FontData.BoldAsString = "False"
        Appearance69.FontData.SizeInPoints = 8.0!
        UltraGridColumn5.Header.Appearance = Appearance69
        UltraGridColumn5.Header.Caption = "Almacén"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.MaxWidth = 240
        UltraGridColumn5.MinWidth = 240
        UltraGridColumn5.Width = 240
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance70.FontData.BoldAsString = "False"
        Appearance70.FontData.SizeInPoints = 8.0!
        Appearance70.TextHAlignAsString = "Center"
        Appearance70.TextVAlignAsString = "Middle"
        UltraGridColumn6.CellAppearance = Appearance70
        Appearance71.FontData.BoldAsString = "False"
        Appearance71.FontData.SizeInPoints = 8.0!
        UltraGridColumn6.Header.Appearance = Appearance71
        UltraGridColumn6.Header.VisiblePosition = 0
        UltraGridColumn6.MaxWidth = 85
        UltraGridColumn6.MinWidth = 85
        UltraGridColumn6.Width = 85
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance72.FontData.BoldAsString = "False"
        Appearance72.FontData.SizeInPoints = 8.0!
        Appearance72.TextHAlignAsString = "Center"
        Appearance72.TextVAlignAsString = "Middle"
        UltraGridColumn7.CellAppearance = Appearance72
        Appearance73.FontData.BoldAsString = "False"
        Appearance73.FontData.SizeInPoints = 8.0!
        UltraGridColumn7.Header.Appearance = Appearance73
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
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 8
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 8
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11})
        Me.DgvSalidaTransferencia.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.DgvSalidaTransferencia.DisplayLayout.InterBandSpacing = 18
        Me.DgvSalidaTransferencia.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.DgvSalidaTransferencia.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance103.BackColor = System.Drawing.Color.Transparent
        Me.DgvSalidaTransferencia.DisplayLayout.Override.CardAreaAppearance = Appearance103
        Appearance104.FontData.BoldAsString = "True"
        Appearance104.FontData.SizeInPoints = 9.0!
        Appearance104.ForeColor = System.Drawing.Color.Navy
        Me.DgvSalidaTransferencia.DisplayLayout.Override.CellAppearance = Appearance104
        Me.DgvSalidaTransferencia.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance105.BackColor = System.Drawing.Color.Navy
        Appearance105.FontData.BoldAsString = "True"
        Appearance105.FontData.ItalicAsString = "False"
        Appearance105.FontData.SizeInPoints = 10.0!
        Appearance105.ForeColor = System.Drawing.Color.White
        Appearance105.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.DgvSalidaTransferencia.DisplayLayout.Override.HeaderAppearance = Appearance105
        Appearance106.TextHAlignAsString = "Center"
        Appearance106.TextVAlignAsString = "Middle"
        Me.DgvSalidaTransferencia.DisplayLayout.Override.RowPreviewAppearance = Appearance106
        Appearance107.BackColor = System.Drawing.Color.Navy
        Appearance107.BorderColor = System.Drawing.Color.White
        Appearance107.FontData.BoldAsString = "True"
        Appearance107.ForeColor = System.Drawing.Color.White
        Appearance107.TextHAlignAsString = "Center"
        Appearance107.TextVAlignAsString = "Middle"
        Me.DgvSalidaTransferencia.DisplayLayout.Override.RowSelectorAppearance = Appearance107
        Me.DgvSalidaTransferencia.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.DgvSalidaTransferencia.DisplayLayout.Override.RowSpacingAfter = 4
        Me.DgvSalidaTransferencia.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance108.BackColor = System.Drawing.Color.Navy
        Appearance108.ForeColor = System.Drawing.Color.White
        Me.DgvSalidaTransferencia.DisplayLayout.Override.SelectedRowAppearance = Appearance108
        Me.DgvSalidaTransferencia.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.DgvSalidaTransferencia.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.DgvSalidaTransferencia.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.DgvSalidaTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgvSalidaTransferencia.Location = New System.Drawing.Point(10, 40)
        Me.DgvSalidaTransferencia.Name = "DgvSalidaTransferencia"
        Me.DgvSalidaTransferencia.Size = New System.Drawing.Size(795, 415)
        Me.DgvSalidaTransferencia.TabIndex = 83
        '
        'UltraDataSource2
        '
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11})
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
        Me.UltraTabPageControl2.Controls.Add(Me.Cia2)
        Me.UltraTabPageControl2.Controls.Add(Me.GrpSalidaTransferencia)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl2.Controls.Add(Me.dtFeStringegistro)
        Me.UltraTabPageControl2.Controls.Add(Me.dgvDetalleSalidaTransferencia)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel29)
        Me.UltraTabPageControl2.Controls.Add(Me.TxtNumeroMovimiento)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel4)
        Me.UltraTabPageControl2.Controls.Add(Me.GrpDatosMovimiento)
        Me.UltraTabPageControl2.Controls.Add(Me.LblEstado)
        Me.UltraTabPageControl2.Controls.Add(Me.GrpAnulacion)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(812, 469)
        '
        'Cia2
        '
        Me.Cia2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance3.BackColor = System.Drawing.Color.White
        Me.Cia2.DisplayLayout.Appearance = Appearance3
        Me.Cia2.DisplayLayout.InterBandSpacing = 18
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Me.Cia2.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.FontData.BoldAsString = "True"
        Appearance10.FontData.SizeInPoints = 9.0!
        Appearance10.ForeColor = System.Drawing.Color.Navy
        Me.Cia2.DisplayLayout.Override.CellAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.Color.Navy
        Appearance11.FontData.BoldAsString = "True"
        Appearance11.FontData.ItalicAsString = "True"
        Appearance11.FontData.SizeInPoints = 10.0!
        Appearance11.ForeColor = System.Drawing.Color.White
        Appearance11.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.Cia2.DisplayLayout.Override.HeaderAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.Navy
        Appearance12.BorderColor = System.Drawing.Color.White
        Appearance12.ForeColor = System.Drawing.Color.White
        Me.Cia2.DisplayLayout.Override.RowSelectorAppearance = Appearance12
        Me.Cia2.DisplayLayout.Override.RowSpacingAfter = 4
        Me.Cia2.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance13.BackColor = System.Drawing.Color.Navy
        Appearance13.ForeColor = System.Drawing.Color.White
        Me.Cia2.DisplayLayout.Override.SelectedRowAppearance = Appearance13
        Me.Cia2.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.Cia2.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.Cia2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cia2.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cia2.Location = New System.Drawing.Point(60, 10)
        Me.Cia2.Name = "Cia2"
        Me.Cia2.ReadOnly = True
        Me.Cia2.Size = New System.Drawing.Size(270, 22)
        Me.Cia2.TabIndex = 152
        '
        'GrpSalidaTransferencia
        '
        Me.GrpSalidaTransferencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSalidaTransferencia.Controls.Add(Me.BtnPendientes)
        Me.GrpSalidaTransferencia.Controls.Add(Me.BtnGuia)
        Me.GrpSalidaTransferencia.Controls.Add(Me.LblNumeroGuia)
        Me.GrpSalidaTransferencia.Controls.Add(Me.LblSerieGuia)
        Me.GrpSalidaTransferencia.Controls.Add(Me.LblRuc)
        Me.GrpSalidaTransferencia.Controls.Add(Me.UltraLabel20)
        Me.GrpSalidaTransferencia.Controls.Add(Me.LblLugarEntrega)
        Me.GrpSalidaTransferencia.Controls.Add(Me.LblRazonSocial)
        Me.GrpSalidaTransferencia.Controls.Add(Me.UltraLabel15)
        Me.GrpSalidaTransferencia.Controls.Add(Me.UltraLabel13)
        Me.GrpSalidaTransferencia.Controls.Add(Me.UltraLabel12)
        Me.GrpSalidaTransferencia.Controls.Add(Me.LblCodigo)
        Me.GrpSalidaTransferencia.Controls.Add(Me.UltraLabel10)
        Me.GrpSalidaTransferencia.Location = New System.Drawing.Point(385, 40)
        Me.GrpSalidaTransferencia.Name = "GrpSalidaTransferencia"
        Me.GrpSalidaTransferencia.Size = New System.Drawing.Size(420, 145)
        Me.GrpSalidaTransferencia.TabIndex = 151
        Me.GrpSalidaTransferencia.Text = "Datos del Cliente"
        Me.GrpSalidaTransferencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'BtnPendientes
        '
        Me.BtnPendientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.BorderAlpha = Infragistics.Win.Alpha.Transparent
        Appearance5.FontData.BoldAsString = "False"
        Appearance5.FontData.SizeInPoints = 8.0!
        Appearance5.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance5.TextVAlignAsString = "Bottom"
        Me.BtnPendientes.Appearance = Appearance5
        Me.BtnPendientes.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.BtnPendientes.Location = New System.Drawing.Point(280, 110)
        Me.BtnPendientes.Name = "BtnPendientes"
        Me.BtnPendientes.Size = New System.Drawing.Size(72, 32)
        Me.BtnPendientes.TabIndex = 95
        Me.BtnPendientes.Text = "Pendientes"
        Me.BtnPendientes.Visible = False
        '
        'BtnGuia
        '
        Me.BtnGuia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.FontData.SizeInPoints = 8.0!
        Appearance4.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance4.TextVAlignAsString = "Bottom"
        Me.BtnGuia.Appearance = Appearance4
        Me.BtnGuia.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton
        Me.BtnGuia.Location = New System.Drawing.Point(355, 110)
        Me.BtnGuia.Name = "BtnGuia"
        Me.BtnGuia.Size = New System.Drawing.Size(56, 32)
        Me.BtnGuia.TabIndex = 94
        Me.BtnGuia.Text = "Guia"
        Me.BtnGuia.Visible = False
        '
        'LblNumeroGuia
        '
        Me.LblNumeroGuia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance28.FontData.BoldAsString = "False"
        Appearance28.FontData.SizeInPoints = 8.0!
        Appearance28.TextHAlignAsString = "Center"
        Appearance28.TextVAlignAsString = "Middle"
        Me.LblNumeroGuia.Appearance = Appearance28
        Me.LblNumeroGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.LblNumeroGuia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.LblNumeroGuia.Location = New System.Drawing.Point(110, 110)
        Me.LblNumeroGuia.MaxLength = 20
        Me.LblNumeroGuia.Name = "LblNumeroGuia"
        Me.LblNumeroGuia.Size = New System.Drawing.Size(160, 21)
        Me.LblNumeroGuia.TabIndex = 93
        '
        'LblSerieGuia
        '
        Appearance59.FontData.BoldAsString = "False"
        Appearance59.FontData.SizeInPoints = 8.0!
        Appearance59.TextHAlignAsString = "Center"
        Appearance59.TextVAlignAsString = "Middle"
        Me.LblSerieGuia.Appearance = Appearance59
        Me.LblSerieGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.LblSerieGuia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.LblSerieGuia.Location = New System.Drawing.Point(60, 110)
        Me.LblSerieGuia.MaxLength = 10
        Me.LblSerieGuia.Name = "LblSerieGuia"
        Me.LblSerieGuia.Size = New System.Drawing.Size(45, 21)
        Me.LblSerieGuia.TabIndex = 92
        '
        'LblRuc
        '
        Me.LblRuc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance34.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance34.FontData.BoldAsString = "False"
        Appearance34.FontData.SizeInPoints = 8.0!
        Appearance34.TextHAlignAsString = "Center"
        Appearance34.TextVAlignAsString = "Middle"
        Me.LblRuc.Appearance = Appearance34
        Me.LblRuc.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblRuc.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblRuc.Location = New System.Drawing.Point(300, 24)
        Me.LblRuc.Name = "LblRuc"
        Me.LblRuc.Size = New System.Drawing.Size(110, 21)
        Me.LblRuc.TabIndex = 91
        '
        'UltraLabel20
        '
        Me.UltraLabel20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance61.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel20.Appearance = Appearance61
        Me.UltraLabel20.AutoSize = True
        Me.UltraLabel20.Location = New System.Drawing.Point(260, 27)
        Me.UltraLabel20.Name = "UltraLabel20"
        Me.UltraLabel20.Size = New System.Drawing.Size(35, 14)
        Me.UltraLabel20.TabIndex = 90
        Me.UltraLabel20.Text = "R.U.C"
        '
        'LblLugarEntrega
        '
        Me.LblLugarEntrega.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance62.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance62.FontData.BoldAsString = "False"
        Appearance62.FontData.SizeInPoints = 8.0!
        Appearance62.TextHAlignAsString = "Center"
        Appearance62.TextVAlignAsString = "Middle"
        Me.LblLugarEntrega.Appearance = Appearance62
        Me.LblLugarEntrega.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblLugarEntrega.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblLugarEntrega.Location = New System.Drawing.Point(60, 85)
        Me.LblLugarEntrega.Name = "LblLugarEntrega"
        Me.LblLugarEntrega.Size = New System.Drawing.Size(350, 21)
        Me.LblLugarEntrega.TabIndex = 87
        '
        'LblRazonSocial
        '
        Me.LblRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance63.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance63.FontData.BoldAsString = "False"
        Appearance63.FontData.SizeInPoints = 8.0!
        Appearance63.TextHAlignAsString = "Center"
        Appearance63.TextVAlignAsString = "Middle"
        Me.LblRazonSocial.Appearance = Appearance63
        Me.LblRazonSocial.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblRazonSocial.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblRazonSocial.Location = New System.Drawing.Point(60, 50)
        Me.LblRazonSocial.Name = "LblRazonSocial"
        Me.LblRazonSocial.Size = New System.Drawing.Size(350, 30)
        Me.LblRazonSocial.TabIndex = 86
        '
        'UltraLabel15
        '
        Appearance26.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel15.Appearance = Appearance26
        Me.UltraLabel15.Location = New System.Drawing.Point(10, 80)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(55, 31)
        Me.UltraLabel15.TabIndex = 85
        Me.UltraLabel15.Text = "Lugar Entrega"
        '
        'UltraLabel13
        '
        Appearance29.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel13.Appearance = Appearance29
        Me.UltraLabel13.AutoSize = True
        Me.UltraLabel13.Location = New System.Drawing.Point(10, 112)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(49, 14)
        Me.UltraLabel13.TabIndex = 84
        Me.UltraLabel13.Text = "Nro Guia"
        '
        'UltraLabel12
        '
        Appearance30.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel12.Appearance = Appearance30
        Me.UltraLabel12.Location = New System.Drawing.Point(10, 50)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(41, 25)
        Me.UltraLabel12.TabIndex = 83
        Me.UltraLabel12.Text = "Razón Social"
        '
        'LblCodigo
        '
        Me.LblCodigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance31.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance31.FontData.BoldAsString = "False"
        Appearance31.FontData.SizeInPoints = 8.0!
        Appearance31.TextHAlignAsString = "Center"
        Appearance31.TextVAlignAsString = "Middle"
        Me.LblCodigo.Appearance = Appearance31
        Me.LblCodigo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblCodigo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblCodigo.Location = New System.Drawing.Point(60, 25)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(100, 21)
        Me.LblCodigo.TabIndex = 82
        '
        'UltraLabel10
        '
        Appearance64.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel10.Appearance = Appearance64
        Me.UltraLabel10.AutoSize = True
        Me.UltraLabel10.Location = New System.Drawing.Point(10, 27)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(40, 14)
        Me.UltraLabel10.TabIndex = 81
        Me.UltraLabel10.Text = "Código"
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
        'dgvDetalleSalidaTransferencia
        '
        Me.dgvDetalleSalidaTransferencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleSalidaTransferencia.DataSource = Me.UltraDataSource1
        Appearance68.BackColor = System.Drawing.Color.White
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.Appearance = Appearance68
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand2.ColHeaderLines = 2
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance74.FontData.BoldAsString = "False"
        Appearance74.FontData.SizeInPoints = 8.0!
        Appearance74.TextHAlignAsString = "Center"
        Appearance74.TextVAlignAsString = "Middle"
        UltraGridColumn12.CellAppearance = Appearance74
        Appearance75.FontData.BoldAsString = "False"
        Appearance75.FontData.SizeInPoints = 8.0!
        UltraGridColumn12.Header.Appearance = Appearance75
        UltraGridColumn12.Header.Caption = "Código"
        UltraGridColumn12.Header.VisiblePosition = 0
        UltraGridColumn12.MaxLength = 8
        UltraGridColumn12.MinWidth = 85
        UltraGridColumn12.RowLayoutColumnInfo.OriginX = 0
        UltraGridColumn12.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn12.Width = 93
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance83.FontData.BoldAsString = "False"
        Appearance83.FontData.SizeInPoints = 8.0!
        UltraGridColumn13.CellAppearance = Appearance83
        UltraGridColumn13.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance84.FontData.BoldAsString = "False"
        Appearance84.FontData.SizeInPoints = 8.0!
        UltraGridColumn13.Header.Appearance = Appearance84
        UltraGridColumn13.Header.Caption = "Descripción"
        UltraGridColumn13.Header.VisiblePosition = 1
        UltraGridColumn13.MinWidth = 290
        UltraGridColumn13.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn13.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn13.Width = 309
        UltraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance85.FontData.BoldAsString = "False"
        Appearance85.FontData.SizeInPoints = 8.0!
        Appearance85.TextHAlignAsString = "Center"
        Appearance85.TextVAlignAsString = "Middle"
        UltraGridColumn14.CellAppearance = Appearance85
        UltraGridColumn14.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance86.FontData.BoldAsString = "False"
        Appearance86.FontData.SizeInPoints = 8.0!
        UltraGridColumn14.Header.Appearance = Appearance86
        UltraGridColumn14.Header.VisiblePosition = 2
        UltraGridColumn14.MaxWidth = 50
        UltraGridColumn14.MinWidth = 50
        UltraGridColumn14.RowLayoutColumnInfo.OriginX = 4
        UltraGridColumn14.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn14.Width = 50
        UltraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance88.FontData.BoldAsString = "False"
        Appearance88.FontData.SizeInPoints = 8.0!
        Appearance88.TextHAlignAsString = "Right"
        Appearance88.TextVAlignAsString = "Middle"
        UltraGridColumn15.CellAppearance = Appearance88
        UltraGridColumn15.Format = "N4"
        Appearance89.FontData.BoldAsString = "False"
        Appearance89.FontData.SizeInPoints = 8.0!
        UltraGridColumn15.Header.Appearance = Appearance89
        UltraGridColumn15.Header.VisiblePosition = 3
        UltraGridColumn15.MinWidth = 100
        UltraGridColumn15.Width = 106
        UltraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance91.FontData.BoldAsString = "False"
        Appearance91.FontData.SizeInPoints = 8.0!
        Appearance91.TextHAlignAsString = "Right"
        Appearance91.TextVAlignAsString = "Middle"
        UltraGridColumn16.CellAppearance = Appearance91
        UltraGridColumn16.Format = "N4"
        Appearance92.FontData.BoldAsString = "False"
        Appearance92.FontData.SizeInPoints = 8.0!
        UltraGridColumn16.Header.Appearance = Appearance92
        UltraGridColumn16.Header.Caption = "Cantidad a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Transferir"
        UltraGridColumn16.Header.VisiblePosition = 5
        UltraGridColumn16.MinWidth = 100
        UltraGridColumn16.RowLayoutColumnInfo.OriginX = 8
        UltraGridColumn16.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn16.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoubleNonNegative
        UltraGridColumn16.Width = 106
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance93.FontData.BoldAsString = "True"
        Appearance93.FontData.SizeInPoints = 8.0!
        Appearance93.TextHAlignAsString = "Right"
        Appearance93.TextVAlignAsString = "Middle"
        UltraGridColumn17.CellAppearance = Appearance93
        UltraGridColumn17.Format = "n4"
        Appearance94.FontData.BoldAsString = "False"
        Appearance94.FontData.SizeInPoints = 8.0!
        UltraGridColumn17.Header.Appearance = Appearance94
        UltraGridColumn17.Header.VisiblePosition = 4
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.MinWidth = 85
        UltraGridColumn17.RowLayoutColumnInfo.OriginX = 6
        UltraGridColumn17.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn17.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoubleNonNegative
        UltraGridColumn17.Width = 133
        UltraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance95.FontData.BoldAsString = "False"
        Appearance95.FontData.SizeInPoints = 8.0!
        Appearance95.TextHAlignAsString = "Center"
        Appearance95.TextVAlignAsString = "Middle"
        UltraGridColumn18.CellAppearance = Appearance95
        Appearance96.FontData.BoldAsString = "False"
        Appearance96.FontData.SizeInPoints = 8.0!
        UltraGridColumn18.Header.Appearance = Appearance96
        UltraGridColumn18.Header.Caption = "Orden" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Compra"
        UltraGridColumn18.Header.VisiblePosition = 6
        UltraGridColumn18.MaxWidth = 110
        UltraGridColumn18.MinWidth = 110
        UltraGridColumn18.Width = 110
        UltraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn19.Header.VisiblePosition = 7
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.Width = 39
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19})
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.InterBandSpacing = 18
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Appearance156.BackColor = System.Drawing.Color.Transparent
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.Override.CardAreaAppearance = Appearance156
        Appearance157.FontData.BoldAsString = "True"
        Appearance157.FontData.SizeInPoints = 9.0!
        Appearance157.ForeColor = System.Drawing.Color.Navy
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.Override.CellAppearance = Appearance157
        Appearance158.BackColor = System.Drawing.Color.Navy
        Appearance158.FontData.BoldAsString = "True"
        Appearance158.FontData.ItalicAsString = "False"
        Appearance158.FontData.SizeInPoints = 10.0!
        Appearance158.ForeColor = System.Drawing.Color.White
        Appearance158.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.Override.HeaderAppearance = Appearance158
        Appearance159.BackColor = System.Drawing.Color.Navy
        Appearance159.BorderColor = System.Drawing.Color.White
        Appearance159.ForeColor = System.Drawing.Color.White
        Appearance159.TextHAlignAsString = "Center"
        Appearance159.TextVAlignAsString = "Middle"
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.Override.RowSelectorAppearance = Appearance159
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance160.BackColor = System.Drawing.Color.Navy
        Appearance160.ForeColor = System.Drawing.Color.White
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.Override.SelectedRowAppearance = Appearance160
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvDetalleSalidaTransferencia.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvDetalleSalidaTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDetalleSalidaTransferencia.Location = New System.Drawing.Point(10, 190)
        Me.dgvDetalleSalidaTransferencia.Name = "dgvDetalleSalidaTransferencia"
        Me.dgvDetalleSalidaTransferencia.Size = New System.Drawing.Size(795, 270)
        Me.dgvDetalleSalidaTransferencia.TabIndex = 140
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19})
        '
        'UltraLabel29
        '
        Me.UltraLabel29.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel29.AutoSize = True
        Me.UltraLabel29.Location = New System.Drawing.Point(385, 10)
        Me.UltraLabel29.Name = "UltraLabel29"
        Me.UltraLabel29.Size = New System.Drawing.Size(83, 14)
        Me.UltraLabel29.TabIndex = 139
        Me.UltraLabel29.Text = "Nro Documento"
        '
        'TxtNumeroMovimiento
        '
        Me.TxtNumeroMovimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance111.ForeColor = System.Drawing.Color.Red
        Appearance111.TextHAlignAsString = "Center"
        Appearance111.TextVAlignAsString = "Middle"
        Me.TxtNumeroMovimiento.Appearance = Appearance111
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
        Me.GrpDatosMovimiento.Controls.Add(Me.CboAlmacen)
        Me.GrpDatosMovimiento.Controls.Add(Me.CboTipoMovimiento)
        Me.GrpDatosMovimiento.Controls.Add(Me.RdbExterna)
        Me.GrpDatosMovimiento.Controls.Add(Me.RdbInterna)
        Me.GrpDatosMovimiento.Controls.Add(Me.UltraLabel11)
        Me.GrpDatosMovimiento.Controls.Add(Me.CboAlmacenDestino)
        Me.GrpDatosMovimiento.Controls.Add(Me.UltraLabel6)
        Me.GrpDatosMovimiento.Controls.Add(Me.UltraLabel5)
        Me.GrpDatosMovimiento.Location = New System.Drawing.Point(10, 40)
        Me.GrpDatosMovimiento.Name = "GrpDatosMovimiento"
        Me.GrpDatosMovimiento.Size = New System.Drawing.Size(370, 145)
        Me.GrpDatosMovimiento.TabIndex = 80
        Me.GrpDatosMovimiento.Text = "Datos del Movimiento"
        Me.GrpDatosMovimiento.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
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
        UltraGridColumn20.CellAppearance = Appearance98
        Appearance99.FontData.BoldAsString = "False"
        Appearance99.FontData.ItalicAsString = "False"
        Appearance99.FontData.SizeInPoints = 8.0!
        UltraGridColumn20.Header.Appearance = Appearance99
        UltraGridColumn20.Header.Caption = "Código"
        UltraGridColumn20.Header.VisiblePosition = 0
        UltraGridColumn20.Hidden = True
        Appearance100.FontData.BoldAsString = "False"
        Appearance100.FontData.ItalicAsString = "False"
        Appearance100.FontData.SizeInPoints = 8.0!
        UltraGridColumn21.CellAppearance = Appearance100
        UltraGridColumn21.ColSpan = CType(2, Short)
        Appearance101.FontData.BoldAsString = "False"
        Appearance101.FontData.ItalicAsString = "False"
        Appearance101.FontData.SizeInPoints = 8.0!
        UltraGridColumn21.Header.Appearance = Appearance101
        UltraGridColumn21.Header.Caption = "Descripción"
        UltraGridColumn21.Header.VisiblePosition = 1
        UltraGridColumn21.Width = 305
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn20, UltraGridColumn21})
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
        Me.CboAlmacen.Location = New System.Drawing.Point(70, 55)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(290, 22)
        Me.CboAlmacen.TabIndex = 100
        '
        'CboTipoMovimiento
        '
        Me.CboTipoMovimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance124.BackColor = System.Drawing.Color.White
        Me.CboTipoMovimiento.DisplayLayout.Appearance = Appearance124
        Me.CboTipoMovimiento.DisplayLayout.InterBandSpacing = 18
        Appearance125.BackColor = System.Drawing.Color.Transparent
        Me.CboTipoMovimiento.DisplayLayout.Override.CardAreaAppearance = Appearance125
        Appearance126.FontData.BoldAsString = "True"
        Appearance126.FontData.SizeInPoints = 9.0!
        Appearance126.ForeColor = System.Drawing.Color.Navy
        Me.CboTipoMovimiento.DisplayLayout.Override.CellAppearance = Appearance126
        Appearance127.BackColor = System.Drawing.Color.Navy
        Appearance127.FontData.BoldAsString = "True"
        Appearance127.FontData.ItalicAsString = "True"
        Appearance127.FontData.SizeInPoints = 10.0!
        Appearance127.ForeColor = System.Drawing.Color.White
        Appearance127.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.CboTipoMovimiento.DisplayLayout.Override.HeaderAppearance = Appearance127
        Appearance128.BackColor = System.Drawing.Color.Navy
        Appearance128.BorderColor = System.Drawing.Color.White
        Appearance128.ForeColor = System.Drawing.Color.White
        Me.CboTipoMovimiento.DisplayLayout.Override.RowSelectorAppearance = Appearance128
        Me.CboTipoMovimiento.DisplayLayout.Override.RowSpacingAfter = 4
        Me.CboTipoMovimiento.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance129.BackColor = System.Drawing.Color.Navy
        Appearance129.ForeColor = System.Drawing.Color.White
        Me.CboTipoMovimiento.DisplayLayout.Override.SelectedRowAppearance = Appearance129
        Me.CboTipoMovimiento.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.CboTipoMovimiento.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.CboTipoMovimiento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CboTipoMovimiento.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.CboTipoMovimiento.Location = New System.Drawing.Point(70, 25)
        Me.CboTipoMovimiento.Name = "CboTipoMovimiento"
        Me.CboTipoMovimiento.ReadOnly = True
        Me.CboTipoMovimiento.Size = New System.Drawing.Size(290, 22)
        Me.CboTipoMovimiento.TabIndex = 99
        '
        'RdbExterna
        '
        Me.RdbExterna.AutoSize = True
        Me.RdbExterna.BackColor = System.Drawing.Color.Transparent
        Me.RdbExterna.Location = New System.Drawing.Point(303, 85)
        Me.RdbExterna.Name = "RdbExterna"
        Me.RdbExterna.Size = New System.Drawing.Size(61, 17)
        Me.RdbExterna.TabIndex = 98
        Me.RdbExterna.TabStop = True
        Me.RdbExterna.Text = "Externa"
        Me.RdbExterna.UseVisualStyleBackColor = False
        '
        'RdbInterna
        '
        Me.RdbInterna.AutoSize = True
        Me.RdbInterna.BackColor = System.Drawing.Color.Transparent
        Me.RdbInterna.Location = New System.Drawing.Point(238, 85)
        Me.RdbInterna.Name = "RdbInterna"
        Me.RdbInterna.Size = New System.Drawing.Size(58, 17)
        Me.RdbInterna.TabIndex = 97
        Me.RdbInterna.TabStop = True
        Me.RdbInterna.Text = "Interna"
        Me.RdbInterna.UseVisualStyleBackColor = False
        '
        'UltraLabel11
        '
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel11.Appearance = Appearance20
        Me.UltraLabel11.Location = New System.Drawing.Point(10, 107)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(49, 33)
        Me.UltraLabel11.TabIndex = 96
        Me.UltraLabel11.Text = "Almacén Destino"
        '
        'CboAlmacenDestino
        '
        Me.CboAlmacenDestino.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CboAlmacenDestino.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.CboAlmacenDestino.Location = New System.Drawing.Point(70, 114)
        Me.CboAlmacenDestino.Name = "CboAlmacenDestino"
        Me.CboAlmacenDestino.Size = New System.Drawing.Size(290, 21)
        Me.CboAlmacenDestino.TabIndex = 95
        '
        'UltraLabel6
        '
        Appearance53.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel6.Appearance = Appearance53
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(10, 57)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(48, 14)
        Me.UltraLabel6.TabIndex = 87
        Me.UltraLabel6.Text = "Almacén"
        '
        'UltraLabel5
        '
        Appearance37.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel5.Appearance = Appearance37
        Me.UltraLabel5.Location = New System.Drawing.Point(10, 20)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(64, 29)
        Me.UltraLabel5.TabIndex = 85
        Me.UltraLabel5.Text = "Tipo Movimiento"
        '
        'LblEstado
        '
        Me.LblEstado.Location = New System.Drawing.Point(159, 40)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(228, 23)
        Me.LblEstado.TabIndex = 99
        Me.LblEstado.Visible = False
        '
        'GrpAnulacion
        '
        Me.GrpAnulacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpAnulacion.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.GrpAnulacion.Controls.Add(Me.CboAnulacion)
        Me.GrpAnulacion.Controls.Add(Me.BtCancelar)
        Me.GrpAnulacion.Controls.Add(Me.UltraLabel7)
        Me.GrpAnulacion.Controls.Add(Me.UltraLabel8)
        Me.GrpAnulacion.Location = New System.Drawing.Point(10, 40)
        Me.GrpAnulacion.Name = "GrpAnulacion"
        Me.GrpAnulacion.Size = New System.Drawing.Size(795, 145)
        Me.GrpAnulacion.TabIndex = 150
        Me.GrpAnulacion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        Me.GrpAnulacion.Visible = False
        '
        'CboAnulacion
        '
        Me.CboAnulacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance115.BackColor = System.Drawing.Color.White
        Me.CboAnulacion.DisplayLayout.Appearance = Appearance115
        Me.CboAnulacion.DisplayLayout.InterBandSpacing = 18
        Appearance119.BackColor = System.Drawing.Color.Transparent
        Me.CboAnulacion.DisplayLayout.Override.CardAreaAppearance = Appearance119
        Appearance120.FontData.BoldAsString = "True"
        Appearance120.FontData.SizeInPoints = 9.0!
        Appearance120.ForeColor = System.Drawing.Color.Navy
        Me.CboAnulacion.DisplayLayout.Override.CellAppearance = Appearance120
        Appearance121.BackColor = System.Drawing.Color.Navy
        Appearance121.FontData.BoldAsString = "True"
        Appearance121.FontData.ItalicAsString = "True"
        Appearance121.FontData.SizeInPoints = 10.0!
        Appearance121.ForeColor = System.Drawing.Color.White
        Appearance121.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.CboAnulacion.DisplayLayout.Override.HeaderAppearance = Appearance121
        Appearance122.BackColor = System.Drawing.Color.Navy
        Appearance122.BorderColor = System.Drawing.Color.White
        Appearance122.ForeColor = System.Drawing.Color.White
        Me.CboAnulacion.DisplayLayout.Override.RowSelectorAppearance = Appearance122
        Me.CboAnulacion.DisplayLayout.Override.RowSpacingAfter = 4
        Me.CboAnulacion.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance123.BackColor = System.Drawing.Color.Navy
        Appearance123.ForeColor = System.Drawing.Color.White
        Me.CboAnulacion.DisplayLayout.Override.SelectedRowAppearance = Appearance123
        Me.CboAnulacion.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.CboAnulacion.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.CboAnulacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CboAnulacion.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.CboAnulacion.Location = New System.Drawing.Point(120, 90)
        Me.CboAnulacion.Name = "CboAnulacion"
        Me.CboAnulacion.ReadOnly = True
        Me.CboAnulacion.Size = New System.Drawing.Size(380, 22)
        Me.CboAnulacion.TabIndex = 152
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
        Me.BtCancelar.Location = New System.Drawing.Point(700, 90)
        Me.BtCancelar.Name = "BtCancelar"
        Me.BtCancelar.Size = New System.Drawing.Size(85, 30)
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
        Me.UltraLabel7.Location = New System.Drawing.Point(0, 30)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(795, 25)
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
        Me.UltraLabel8.Location = New System.Drawing.Point(10, 90)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(106, 14)
        Me.UltraLabel8.TabIndex = 96
        Me.UltraLabel8.Text = "Motivo de Anulación"
        '
        'TabSalidaTransferencia
        '
        Me.TabSalidaTransferencia.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.TabSalidaTransferencia.Controls.Add(Me.UltraTabPageControl1)
        Me.TabSalidaTransferencia.Controls.Add(Me.UltraTabPageControl2)
        Me.TabSalidaTransferencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabSalidaTransferencia.Location = New System.Drawing.Point(0, 0)
        Me.TabSalidaTransferencia.Name = "TabSalidaTransferencia"
        Me.TabSalidaTransferencia.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.TabSalidaTransferencia.Size = New System.Drawing.Size(814, 492)
        Me.TabSalidaTransferencia.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon
        Me.TabSalidaTransferencia.TabIndex = 3
        Me.TabSalidaTransferencia.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab1.Key = "Listar"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Listado Salida Por Transferencia"
        UltraTab2.Key = "Salida"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Salida Por Transferencia"
        Me.TabSalidaTransferencia.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        Me.TabSalidaTransferencia.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(812, 469)
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "BINOCULAR.ICO")
        '
        'FrmSalidaTransferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 492)
        Me.Controls.Add(Me.TabSalidaTransferencia)
        Me.Name = "FrmSalidaTransferencia"
        Me.Text = "Salida Por Transferencia"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.Cia1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvSalidaTransferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtFechaConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumeroDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.Cia2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrpSalidaTransferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSalidaTransferencia.ResumeLayout(False)
        Me.GrpSalidaTransferencia.PerformLayout()
        CType(Me.LblNumeroGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSerieGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFeStringegistro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalleSalidaTransferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumeroMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrpDatosMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDatosMovimiento.ResumeLayout(False)
        Me.GrpDatosMovimiento.PerformLayout()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboTipoMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboAlmacenDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrpAnulacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpAnulacion.ResumeLayout(False)
        Me.GrpAnulacion.PerformLayout()
        CType(Me.CboAnulacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabSalidaTransferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSalidaTransferencia.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabSalidaTransferencia As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents DgvSalidaTransferencia As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DtFechaConsulta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents TxtNumeroDocumento As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtFeStringegistro As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dgvDetalleSalidaTransferencia As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel29 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtNumeroMovimiento As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GrpDatosMovimiento As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GrpAnulacion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents BtCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents RdbExterna As System.Windows.Forms.RadioButton
    Friend WithEvents RdbInterna As System.Windows.Forms.RadioButton
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents CboAlmacenDestino As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents GrpSalidaTransferencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LblNumeroGuia As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents LblSerieGuia As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents LblRuc As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel20 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblLugarEntrega As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblRazonSocial As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblCodigo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BtnGuia As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents BtnPendientes As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents UltraDataSource2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents Cia1 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Cia2 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents CboAnulacion As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents CboTipoMovimiento As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents CboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
End Class
