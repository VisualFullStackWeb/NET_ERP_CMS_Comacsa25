<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitudPlanilla
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
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitudPlanilla))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nro_Solicitud", 0)
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("motivo", 1)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("estado", 2)
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nomTrabajador", 3)
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total", 4)
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fechacrea", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codarea", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("usuario", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("moneda", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fec_limite", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codtrabajador", 10)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("area", 11, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("jefeArea", 12)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("cod_estado", 13)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("cod_moneda", 14)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TesoreriaAprueba", 15)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fechaApruebaTeso", 16)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("jefaturaAprueba", 17)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fechaApruebaJefa", 18)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codjefe", 19)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("usuarioJefe", 20)
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("beneficiario", 21)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nomBanco", 22)
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nroDNI", 23)
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nroCuenta", 24)
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance126 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance129 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance130 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance183 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance208 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance184 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance185 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("codConcepto", 0)
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("concepto", 1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("montototal", 2)
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("descripcion", 3)
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("iddetalle", 4)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("total", 5)
        Dim Appearance190 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance191 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance192 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance193 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance194 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance195 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance196 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance197 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance198 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance199 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance200 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance201 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance202 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance203 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance204 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance205 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance206 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance207 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance131 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance132 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance133 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance134 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance135 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance136 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.GridSolicitudes = New Infragistics.Win.UltraWinGrid.UltraGrid
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
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.pnlRegistrar = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblIdDetalle = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboConcepto = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDescripción = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.txtMonto = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label12 = New System.Windows.Forms.Label
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel
        Me.txtNroCuenta = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel
        Me.txtDNI = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.txtNomBanco = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.txtBeneficiario = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnAddPDFP = New System.Windows.Forms.Button
        Me.btnvisualizarP = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnAddPDF = New System.Windows.Forms.Button
        Me.btnvisualizar = New System.Windows.Forms.Button
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.btnClose = New System.Windows.Forms.Button
        Me.ckbTesoreria = New System.Windows.Forms.CheckBox
        Me.ckbJefatura = New System.Windows.Forms.CheckBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.cboEstado = New System.Windows.Forms.ComboBox
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.lblNroSolicitud = New System.Windows.Forms.Label
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.grdDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Navigator4 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.StripLbl3 = New System.Windows.Forms.ToolStripLabel
        Me.Separator21 = New System.Windows.Forms.ToolStripSeparator
        Me.StripBtn12 = New System.Windows.Forms.ToolStripButton
        Me.StripBtn11 = New System.Windows.Forms.ToolStripButton
        Me.Separator20 = New System.Windows.Forms.ToolStripSeparator
        Me.StripTxt3 = New System.Windows.Forms.ToolStripTextBox
        Me.Separator19 = New System.Windows.Forms.ToolStripSeparator
        Me.StripBtn10 = New System.Windows.Forms.ToolStripButton
        Me.StripBtn9 = New System.Windows.Forms.ToolStripButton
        Me.Separator18 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.Separator15 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn7 = New System.Windows.Forms.ToolStripButton
        Me.Separator16 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn8 = New System.Windows.Forms.ToolStripButton
        Me.Separator17 = New System.Windows.Forms.ToolStripSeparator
        Me.txtcodequipo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcodcantera = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.txtid = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcantera = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtequipo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.dtpIni = New System.Windows.Forms.DateTimePicker
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.cbMoneda = New System.Windows.Forms.ComboBox
        Me.cbArea = New System.Windows.Forms.ComboBox
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.txttotal = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.dtFechaCrea = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel39 = New Infragistics.Win.Misc.UltraLabel
        Me.dtFechaLimite = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.txtMotivo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.txtJefeArea = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.TxtCodigoTrabajador = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel21 = New Infragistics.Win.Misc.UltraLabel
        Me.TxtNombresTrabajador = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel19 = New Infragistics.Win.Misc.UltraLabel
        Me.lblnSolicitud = New Infragistics.Win.Misc.UltraLabel
        Me.printPDF = New System.Windows.Forms.WebBrowser
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.TabMaestroEntregas = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
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
        Me.cmbArea = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.cmbMoneda = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.Source2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source4 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BtnReporte = New System.Windows.Forms.Button
        Me.btnAnular = New System.Windows.Forms.Button
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.GridSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl4.SuspendLayout()
        Me.pnlRegistrar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBeneficiario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Navigator4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Navigator4.SuspendLayout()
        CType(Me.txtcodequipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodcantera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcantera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtequipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaCrea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaLimite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJefeArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodigoTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNombresTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraLabel19.SuspendLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabMaestroEntregas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabMaestroEntregas.SuspendLayout()
        Me.pnlRegistrar2.SuspendLayout()
        CType(Me.dtpFecha2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlacod2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.GridSolicitudes)
        Me.UltraTabPageControl1.Controls.Add(Me.BindingNavigator1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1088, 533)
        '
        'GridSolicitudes
        '
        Me.GridSolicitudes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance122.BackColor = System.Drawing.SystemColors.Window
        Appearance122.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.GridSolicitudes.DisplayLayout.Appearance = Appearance122
        Me.GridSolicitudes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance35.Image = CType(resources.GetObject("Appearance35.Image"), Object)
        Appearance35.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance35.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance35
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance123.TextHAlignAsString = "Left"
        UltraGridColumn2.CellAppearance = Appearance123
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance36.TextHAlignAsString = "Center"
        UltraGridColumn2.Header.Appearance = Appearance36
        UltraGridColumn2.Header.Caption = "N° Solicitud"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.MaxWidth = 78
        UltraGridColumn2.MinWidth = 78
        UltraGridColumn2.Width = 78
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance1.TextHAlignAsString = "Left"
        UltraGridColumn3.CellAppearance = Appearance1
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn3.Header.VisiblePosition = 9
        UltraGridColumn3.MaxWidth = 250
        UltraGridColumn3.MinWidth = 186
        UltraGridColumn3.Width = 248
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance30.TextHAlignAsString = "Left"
        UltraGridColumn4.CellAppearance = Appearance30
        UltraGridColumn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn4.Header.VisiblePosition = 6
        UltraGridColumn4.MaxWidth = 180
        UltraGridColumn4.MinWidth = 120
        UltraGridColumn4.Width = 174
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance46.TextHAlignAsString = "Left"
        UltraGridColumn5.CellAppearance = Appearance46
        UltraGridColumn5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn5.Header.Caption = "Nombre Trabajador"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.MaxWidth = 300
        UltraGridColumn5.MinWidth = 250
        UltraGridColumn5.Width = 299
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance96.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance96
        UltraGridColumn6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn6.DataType = GetType(Double)
        UltraGridColumn6.Format = "#####,###.00"
        UltraGridColumn6.Header.Caption = "Monto"
        UltraGridColumn6.Header.VisiblePosition = 8
        UltraGridColumn6.MaxWidth = 72
        UltraGridColumn6.MinWidth = 72
        UltraGridColumn6.Width = 72
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.Caption = "Fecha"
        UltraGridColumn7.Header.VisiblePosition = 2
        UltraGridColumn7.MaxWidth = 86
        UltraGridColumn7.MinWidth = 86
        UltraGridColumn7.Width = 86
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.VisiblePosition = 10
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 95
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.VisiblePosition = 11
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 95
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn10.Header.Caption = "Moneda"
        UltraGridColumn10.Header.VisiblePosition = 7
        UltraGridColumn10.MaxWidth = 98
        UltraGridColumn10.Width = 10
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.Caption = "Fecha Limite Pago"
        UltraGridColumn11.Header.VisiblePosition = 3
        UltraGridColumn11.Width = 27
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.Header.VisiblePosition = 12
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 14
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.Caption = "Area"
        UltraGridColumn13.Header.VisiblePosition = 5
        UltraGridColumn13.Width = 54
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.Width = 25
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 81
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 86
        UltraGridColumn17.Header.VisiblePosition = 16
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 17
        UltraGridColumn18.Header.VisiblePosition = 17
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 36
        UltraGridColumn19.Header.VisiblePosition = 18
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.Width = 41
        UltraGridColumn20.Header.VisiblePosition = 19
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 90
        UltraGridColumn21.Header.VisiblePosition = 20
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 87
        UltraGridColumn22.Header.VisiblePosition = 21
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 108
        UltraGridColumn23.Header.VisiblePosition = 22
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 37
        UltraGridColumn24.Header.VisiblePosition = 23
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.Width = 41
        UltraGridColumn25.Header.VisiblePosition = 24
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 93
        UltraGridColumn26.Header.VisiblePosition = 25
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.Width = 92
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26})
        Me.GridSolicitudes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GridSolicitudes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridSolicitudes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridSolicitudes.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance124.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance124.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance124.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance124.BorderColor = System.Drawing.SystemColors.Window
        Me.GridSolicitudes.DisplayLayout.GroupByBox.Appearance = Appearance124
        Appearance125.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridSolicitudes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance125
        Me.GridSolicitudes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.GridSolicitudes.DisplayLayout.GroupByBox.Hidden = True
        Appearance126.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance126.BackColor2 = System.Drawing.SystemColors.Control
        Appearance126.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance126.ForeColor = System.Drawing.SystemColors.GrayText
        Me.GridSolicitudes.DisplayLayout.GroupByBox.PromptAppearance = Appearance126
        Me.GridSolicitudes.DisplayLayout.MaxColScrollRegions = 1
        Me.GridSolicitudes.DisplayLayout.MaxRowScrollRegions = 1
        Me.GridSolicitudes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.GridSolicitudes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.GridSolicitudes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance127.BackColor = System.Drawing.SystemColors.Window
        Me.GridSolicitudes.DisplayLayout.Override.CardAreaAppearance = Appearance127
        Appearance128.BorderColor = System.Drawing.Color.Silver
        Appearance128.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.GridSolicitudes.DisplayLayout.Override.CellAppearance = Appearance128
        Me.GridSolicitudes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.GridSolicitudes.DisplayLayout.Override.CellPadding = 0
        Me.GridSolicitudes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.GridSolicitudes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.GridSolicitudes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.GridSolicitudes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance129.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance129.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GridSolicitudes.DisplayLayout.Override.FilterRowAppearance = Appearance129
        Me.GridSolicitudes.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.GridSolicitudes.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.GridSolicitudes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance130.BackColor = System.Drawing.SystemColors.Control
        Appearance130.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance130.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance130.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance130.BorderColor = System.Drawing.SystemColors.Window
        Me.GridSolicitudes.DisplayLayout.Override.GroupByRowAppearance = Appearance130
        Appearance13.FontData.Name = "Arial Narrow"
        Appearance13.FontData.SizeInPoints = 10.0!
        Appearance13.TextHAlignAsString = "Left"
        Me.GridSolicitudes.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.GridSolicitudes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.GridSolicitudes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.GridSolicitudes.DisplayLayout.Override.MinRowHeight = 24
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Appearance38.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance38.TextVAlignAsString = "Middle"
        Me.GridSolicitudes.DisplayLayout.Override.RowAppearance = Appearance38
        Me.GridSolicitudes.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.GridSolicitudes.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.GridSolicitudes.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GridSolicitudes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.GridSolicitudes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.GridSolicitudes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.GridSolicitudes.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.GridSolicitudes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSolicitudes.Location = New System.Drawing.Point(-3, 13)
        Me.GridSolicitudes.Name = "GridSolicitudes"
        Me.GridSolicitudes.Size = New System.Drawing.Size(1088, 508)
        Me.GridSolicitudes.TabIndex = 141
        Me.GridSolicitudes.Text = "UltraGrid1"
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BackColor = System.Drawing.Color.Transparent
        Me.BindingNavigator1.BindingSource = Me.Source1
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
        Me.BindingNavigator1.Size = New System.Drawing.Size(1088, 25)
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
        Me.UltraTabPageControl4.AutoScroll = True
        Me.UltraTabPageControl4.Controls.Add(Me.pnlRegistrar)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel15)
        Me.UltraTabPageControl4.Controls.Add(Me.txtNroCuenta)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel14)
        Me.UltraTabPageControl4.Controls.Add(Me.txtDNI)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel12)
        Me.UltraTabPageControl4.Controls.Add(Me.txtNomBanco)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel11)
        Me.UltraTabPageControl4.Controls.Add(Me.txtBeneficiario)
        Me.UltraTabPageControl4.Controls.Add(Me.GroupBox2)
        Me.UltraTabPageControl4.Controls.Add(Me.GroupBox1)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel10)
        Me.UltraTabPageControl4.Controls.Add(Me.btnClose)
        Me.UltraTabPageControl4.Controls.Add(Me.ckbTesoreria)
        Me.UltraTabPageControl4.Controls.Add(Me.ckbJefatura)
        Me.UltraTabPageControl4.Controls.Add(Me.Button4)
        Me.UltraTabPageControl4.Controls.Add(Me.cboEstado)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel9)
        Me.UltraTabPageControl4.Controls.Add(Me.lblNroSolicitud)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl4.Controls.Add(Me.cbMoneda)
        Me.UltraTabPageControl4.Controls.Add(Me.cbArea)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel6)
        Me.UltraTabPageControl4.Controls.Add(Me.txttotal)
        Me.UltraTabPageControl4.Controls.Add(Me.dtFechaCrea)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel4)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel39)
        Me.UltraTabPageControl4.Controls.Add(Me.dtFechaLimite)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel5)
        Me.UltraTabPageControl4.Controls.Add(Me.txtMotivo)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl4.Controls.Add(Me.txtJefeArea)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl4.Controls.Add(Me.TxtCodigoTrabajador)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel21)
        Me.UltraTabPageControl4.Controls.Add(Me.TxtNombresTrabajador)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel18)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel19)
        Me.UltraTabPageControl4.Controls.Add(Me.printPDF)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(1088, 533)
        '
        'pnlRegistrar
        '
        Me.pnlRegistrar.BackColor = System.Drawing.Color.DimGray
        Me.pnlRegistrar.Controls.Add(Me.Panel1)
        Me.pnlRegistrar.Location = New System.Drawing.Point(377, 90)
        Me.pnlRegistrar.Name = "pnlRegistrar"
        Me.pnlRegistrar.Size = New System.Drawing.Size(373, 344)
        Me.pnlRegistrar.TabIndex = 212
        Me.pnlRegistrar.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblIdDetalle)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboConcepto)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtDescripción)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.txtMonto)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(368, 340)
        Me.Panel1.TabIndex = 195
        '
        'lblIdDetalle
        '
        Me.lblIdDetalle.AutoSize = True
        Me.lblIdDetalle.Location = New System.Drawing.Point(7, 10)
        Me.lblIdDetalle.Name = "lblIdDetalle"
        Me.lblIdDetalle.Size = New System.Drawing.Size(0, 13)
        Me.lblIdDetalle.TabIndex = 218
        Me.lblIdDetalle.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 213
        Me.Label2.Text = "Concepto"
        '
        'cboConcepto
        '
        Me.cboConcepto.BackColor = System.Drawing.Color.White
        Me.cboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConcepto.FormattingEnabled = True
        Me.cboConcepto.Location = New System.Drawing.Point(164, 53)
        Me.cboConcepto.Name = "cboConcepto"
        Me.cboConcepto.Size = New System.Drawing.Size(164, 21)
        Me.cboConcepto.TabIndex = 212
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(39, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 208
        Me.Label8.Text = "Descripción"
        '
        'txtDescripción
        '
        Me.txtDescripción.Location = New System.Drawing.Point(42, 157)
        Me.txtDescripción.Multiline = True
        Me.txtDescripción.Name = "txtDescripción"
        Me.txtDescripción.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDescripción.Size = New System.Drawing.Size(286, 119)
        Me.txtDescripción.TabIndex = 209
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Tai Le", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(82, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(212, 27)
        Me.Label9.TabIndex = 205
        Me.Label9.Text = "DETALLE SOLICITUD"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(227, 297)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 28)
        Me.Button1.TabIndex = 211
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(42, 297)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 28)
        Me.Button3.TabIndex = 210
        Me.Button3.Text = "Grabar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtMonto
        '
        Appearance3.Image = "Consultar.png"
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.txtMonto.Appearance = Appearance3
        Me.txtMonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMonto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtMonto.Location = New System.Drawing.Point(164, 87)
        Me.txtMonto.MaxLength = 10
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(162, 21)
        Me.txtMonto.TabIndex = 207
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(39, 91)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 202
        Me.Label12.Text = "Monto"
        '
        'UltraLabel15
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Center"
        Appearance7.TextVAlignAsString = "Middle"
        Me.UltraLabel15.Appearance = Appearance7
        Me.UltraLabel15.AutoSize = True
        Me.UltraLabel15.Location = New System.Drawing.Point(564, 225)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(78, 14)
        Me.UltraLabel15.TabIndex = 236
        Me.UltraLabel15.Text = "Nro. de cuenta"
        '
        'txtNroCuenta
        '
        Appearance6.TextHAlignAsString = "Left"
        Appearance6.TextVAlignAsString = "Middle"
        Me.txtNroCuenta.Appearance = Appearance6
        Me.txtNroCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroCuenta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNroCuenta.Location = New System.Drawing.Point(645, 221)
        Me.txtNroCuenta.Name = "txtNroCuenta"
        Me.txtNroCuenta.Size = New System.Drawing.Size(345, 21)
        Me.txtNroCuenta.TabIndex = 235
        Me.txtNroCuenta.TabStop = False
        '
        'UltraLabel14
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.TextHAlignAsString = "Center"
        Appearance14.TextVAlignAsString = "Middle"
        Me.UltraLabel14.Appearance = Appearance14
        Me.UltraLabel14.AutoSize = True
        Me.UltraLabel14.Location = New System.Drawing.Point(562, 198)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.Size = New System.Drawing.Size(24, 14)
        Me.UltraLabel14.TabIndex = 234
        Me.UltraLabel14.Text = "DNI"
        '
        'txtDNI
        '
        Appearance12.TextHAlignAsString = "Left"
        Appearance12.TextVAlignAsString = "Middle"
        Me.txtDNI.Appearance = Appearance12
        Me.txtDNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDNI.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtDNI.Location = New System.Drawing.Point(645, 195)
        Me.txtDNI.MaxLength = 8
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(345, 21)
        Me.txtDNI.TabIndex = 233
        Me.txtDNI.TabStop = False
        '
        'UltraLabel12
        '
        Appearance101.BackColor = System.Drawing.Color.Transparent
        Appearance101.TextHAlignAsString = "Center"
        Appearance101.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance101
        Me.UltraLabel12.AutoSize = True
        Me.UltraLabel12.Location = New System.Drawing.Point(23, 225)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(95, 14)
        Me.UltraLabel12.TabIndex = 232
        Me.UltraLabel12.Text = "Nombre de Banco"
        '
        'txtNomBanco
        '
        Appearance20.TextHAlignAsString = "Left"
        Appearance20.TextVAlignAsString = "Middle"
        Me.txtNomBanco.Appearance = Appearance20
        Me.txtNomBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomBanco.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtNomBanco.Location = New System.Drawing.Point(135, 221)
        Me.txtNomBanco.Name = "txtNomBanco"
        Me.txtNomBanco.Size = New System.Drawing.Size(421, 21)
        Me.txtNomBanco.TabIndex = 231
        Me.txtNomBanco.TabStop = False
        '
        'UltraLabel11
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Center"
        Appearance8.TextVAlignAsString = "Middle"
        Me.UltraLabel11.Appearance = Appearance8
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Location = New System.Drawing.Point(23, 198)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(64, 14)
        Me.UltraLabel11.TabIndex = 230
        Me.UltraLabel11.Text = "Beneficiario"
        '
        'txtBeneficiario
        '
        Appearance9.TextHAlignAsString = "Left"
        Appearance9.TextVAlignAsString = "Middle"
        Me.txtBeneficiario.Appearance = Appearance9
        Me.txtBeneficiario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBeneficiario.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtBeneficiario.Location = New System.Drawing.Point(135, 194)
        Me.txtBeneficiario.Name = "txtBeneficiario"
        Me.txtBeneficiario.Size = New System.Drawing.Size(421, 21)
        Me.txtBeneficiario.TabIndex = 229
        Me.txtBeneficiario.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAddPDFP)
        Me.GroupBox2.Controls.Add(Me.btnvisualizarP)
        Me.GroupBox2.Location = New System.Drawing.Point(388, 130)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(217, 47)
        Me.GroupBox2.TabIndex = 228
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Procesar"
        '
        'btnAddPDFP
        '
        Me.btnAddPDFP.Location = New System.Drawing.Point(10, 15)
        Me.btnAddPDFP.Name = "btnAddPDFP"
        Me.btnAddPDFP.Size = New System.Drawing.Size(78, 26)
        Me.btnAddPDFP.TabIndex = 219
        Me.btnAddPDFP.Text = "Adjuntar PDF"
        Me.btnAddPDFP.UseVisualStyleBackColor = True
        '
        'btnvisualizarP
        '
        Me.btnvisualizarP.Location = New System.Drawing.Point(94, 15)
        Me.btnvisualizarP.Name = "btnvisualizarP"
        Me.btnvisualizarP.Size = New System.Drawing.Size(87, 26)
        Me.btnvisualizarP.TabIndex = 221
        Me.btnvisualizarP.Text = "Visualizar PDF"
        Me.btnvisualizarP.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAddPDF)
        Me.GroupBox1.Controls.Add(Me.btnvisualizar)
        Me.GroupBox1.Location = New System.Drawing.Point(159, 130)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(212, 47)
        Me.GroupBox1.TabIndex = 227
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Solicitante"
        '
        'btnAddPDF
        '
        Me.btnAddPDF.Location = New System.Drawing.Point(10, 15)
        Me.btnAddPDF.Name = "btnAddPDF"
        Me.btnAddPDF.Size = New System.Drawing.Size(78, 26)
        Me.btnAddPDF.TabIndex = 219
        Me.btnAddPDF.Text = "Adjuntar PDF"
        Me.btnAddPDF.UseVisualStyleBackColor = True
        '
        'btnvisualizar
        '
        Me.btnvisualizar.Location = New System.Drawing.Point(94, 15)
        Me.btnvisualizar.Name = "btnvisualizar"
        Me.btnvisualizar.Size = New System.Drawing.Size(87, 26)
        Me.btnvisualizar.TabIndex = 221
        Me.btnvisualizar.Text = "Visualizar PDF"
        Me.btnvisualizar.UseVisualStyleBackColor = True
        '
        'UltraLabel10
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.TextHAlignAsString = "Left"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel10.Appearance = Appearance5
        Me.UltraLabel10.Location = New System.Drawing.Point(24, 146)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(174, 21)
        Me.UltraLabel10.TabIndex = 224
        Me.UltraLabel10.Text = "Peso Maximo PFD : 1MB"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(1065, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(23, 19)
        Me.btnClose.TabIndex = 223
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = True
        Me.btnClose.Visible = False
        '
        'ckbTesoreria
        '
        Me.ckbTesoreria.AutoSize = True
        Me.ckbTesoreria.Enabled = False
        Me.ckbTesoreria.Location = New System.Drawing.Point(765, 148)
        Me.ckbTesoreria.Name = "ckbTesoreria"
        Me.ckbTesoreria.Size = New System.Drawing.Size(104, 17)
        Me.ckbTesoreria.TabIndex = 218
        Me.ckbTesoreria.Text = "Aprobacion GAF"
        Me.ckbTesoreria.UseVisualStyleBackColor = True
        '
        'ckbJefatura
        '
        Me.ckbJefatura.AutoSize = True
        Me.ckbJefatura.Enabled = False
        Me.ckbJefatura.Location = New System.Drawing.Point(630, 148)
        Me.ckbJefatura.Name = "ckbJefatura"
        Me.ckbJefatura.Size = New System.Drawing.Size(121, 17)
        Me.ckbJefatura.TabIndex = 217
        Me.ckbJefatura.Text = "Aprobacion Jefatura"
        Me.ckbJefatura.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(923, 142)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(119, 28)
        Me.Button4.TabIndex = 216
        Me.Button4.Text = "Grabar"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'cboEstado
        '
        Me.cboEstado.BackColor = System.Drawing.Color.AliceBlue
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.Enabled = False
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"PENDIENTE", "APROBADO", "PROCESADO", "ANULADO"})
        Me.cboEstado.Location = New System.Drawing.Point(923, 96)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(119, 21)
        Me.cboEstado.TabIndex = 215
        '
        'UltraLabel9
        '
        Appearance97.BackColor = System.Drawing.Color.Transparent
        Appearance97.ForeColor = System.Drawing.Color.Black
        Appearance97.TextHAlignAsString = "Left"
        Appearance97.TextVAlignAsString = "Middle"
        Me.UltraLabel9.Appearance = Appearance97
        Me.UltraLabel9.Location = New System.Drawing.Point(779, 33)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(139, 21)
        Me.UltraLabel9.TabIndex = 214
        Me.UltraLabel9.Text = "Moneda"
        '
        'lblNroSolicitud
        '
        Me.lblNroSolicitud.AutoSize = True
        Me.lblNroSolicitud.Location = New System.Drawing.Point(788, 11)
        Me.lblNroSolicitud.Name = "lblNroSolicitud"
        Me.lblNroSolicitud.Size = New System.Drawing.Size(0, 13)
        Me.lblNroSolicitud.TabIndex = 213
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance183.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox2.ContentAreaAppearance = Appearance183
        Me.UltraGroupBox2.Controls.Add(Me.grdDetalle)
        Me.UltraGroupBox2.Controls.Add(Me.Navigator4)
        Me.UltraGroupBox2.Controls.Add(Me.txtcodequipo)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBox2.Controls.Add(Me.txtcodcantera)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel13)
        Me.UltraGroupBox2.Controls.Add(Me.txtid)
        Me.UltraGroupBox2.Controls.Add(Me.txtcantera)
        Me.UltraGroupBox2.Controls.Add(Me.txtequipo)
        Me.UltraGroupBox2.Controls.Add(Me.dtpIni)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel8)
        Appearance208.FontData.BoldAsString = "True"
        Appearance208.FontData.Name = "Arial Narrow"
        Appearance208.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox2.HeaderAppearance = Appearance208
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox2.Location = New System.Drawing.Point(24, 325)
        Me.UltraGroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(1038, 207)
        Me.UltraGroupBox2.TabIndex = 211
        Me.UltraGroupBox2.Text = "LISTADO DE SUMINISTROS"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'grdDetalle
        '
        Me.grdDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance184.BackColor = System.Drawing.SystemColors.Window
        Appearance184.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdDetalle.DisplayLayout.Appearance = Appearance184
        Me.grdDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn27.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance185.Image = CType(resources.GetObject("Appearance185.Image"), Object)
        Appearance185.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance185.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn27.Header.Appearance = Appearance185
        UltraGridColumn27.Header.Caption = ""
        UltraGridColumn27.Header.VisiblePosition = 0
        UltraGridColumn27.Hidden = True
        UltraGridColumn27.MaxWidth = 25
        UltraGridColumn27.MinWidth = 25
        UltraGridColumn27.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit
        UltraGridColumn27.Width = 25
        UltraGridColumn28.Header.Caption = "codconcepto"
        UltraGridColumn28.Header.VisiblePosition = 1
        UltraGridColumn28.Hidden = True
        UltraGridColumn28.Width = 271
        UltraGridColumn29.Header.VisiblePosition = 2
        UltraGridColumn29.Width = 228
        UltraGridColumn30.Header.Caption = "monto total"
        UltraGridColumn30.Header.VisiblePosition = 3
        UltraGridColumn30.Width = 377
        UltraGridColumn31.Header.VisiblePosition = 4
        UltraGridColumn31.Width = 387
        UltraGridColumn32.Header.VisiblePosition = 5
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.Width = 98
        UltraGridColumn33.Header.VisiblePosition = 6
        UltraGridColumn33.Hidden = True
        UltraGridColumn33.Width = 98
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33})
        Me.grdDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.grdDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDetalle.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance190.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance190.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance190.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance190.BorderColor = System.Drawing.SystemColors.Window
        Me.grdDetalle.DisplayLayout.GroupByBox.Appearance = Appearance190
        Appearance191.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance191
        Me.grdDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdDetalle.DisplayLayout.GroupByBox.Hidden = True
        Appearance192.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance192.BackColor2 = System.Drawing.SystemColors.Control
        Appearance192.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance192.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance192
        Me.grdDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.grdDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.grdDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance193.BackColor = System.Drawing.SystemColors.Window
        Me.grdDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance193
        Appearance194.BorderColor = System.Drawing.Color.Silver
        Appearance194.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdDetalle.DisplayLayout.Override.CellAppearance = Appearance194
        Me.grdDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdDetalle.DisplayLayout.Override.CellPadding = 0
        Me.grdDetalle.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.grdDetalle.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.grdDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance195.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdDetalle.DisplayLayout.Override.FilterRowAppearance = Appearance195
        Me.grdDetalle.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.grdDetalle.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance196.BackColor = System.Drawing.SystemColors.Control
        Appearance196.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance196.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance196.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance196.BorderColor = System.Drawing.SystemColors.Window
        Me.grdDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance196
        Appearance197.FontData.Name = "Arial Narrow"
        Appearance197.FontData.SizeInPoints = 10.0!
        Appearance197.TextHAlignAsString = "Left"
        Me.grdDetalle.DisplayLayout.Override.HeaderAppearance = Appearance197
        Me.grdDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.grdDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.grdDetalle.DisplayLayout.Override.MinRowHeight = 24
        Appearance198.BackColor = System.Drawing.SystemColors.Window
        Appearance198.BorderColor = System.Drawing.Color.Silver
        Appearance198.TextVAlignAsString = "Middle"
        Me.grdDetalle.DisplayLayout.Override.RowAppearance = Appearance198
        Me.grdDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdDetalle.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.grdDetalle.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance199.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance199
        Me.grdDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdDetalle.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.Location = New System.Drawing.Point(3, 48)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.Size = New System.Drawing.Size(1032, 156)
        Me.grdDetalle.TabIndex = 144
        Me.grdDetalle.Text = "UltraGrid1"
        '
        'Navigator4
        '
        Me.Navigator4.AddNewItem = Nothing
        Me.Navigator4.BackColor = System.Drawing.SystemColors.Control
        Me.Navigator4.CountItem = Me.StripLbl3
        Me.Navigator4.DeleteItem = Nothing
        Me.Navigator4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Navigator4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Separator21, Me.StripBtn12, Me.StripBtn11, Me.Separator20, Me.StripLbl3, Me.StripTxt3, Me.Separator19, Me.StripBtn10, Me.StripBtn9, Me.Separator18, Me.ToolStripLabel3, Me.Separator15, Me.Btn7, Me.Separator16, Me.Btn8, Me.Separator17})
        Me.Navigator4.Location = New System.Drawing.Point(3, 23)
        Me.Navigator4.MoveFirstItem = Me.StripBtn9
        Me.Navigator4.MoveLastItem = Me.StripBtn12
        Me.Navigator4.MoveNextItem = Me.StripBtn11
        Me.Navigator4.MovePreviousItem = Me.StripBtn10
        Me.Navigator4.Name = "Navigator4"
        Me.Navigator4.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.Navigator4.PositionItem = Me.StripTxt3
        Me.Navigator4.Size = New System.Drawing.Size(1032, 25)
        Me.Navigator4.TabIndex = 143
        Me.Navigator4.Text = "BindingNavigator1"
        '
        'StripLbl3
        '
        Me.StripLbl3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripLbl3.Name = "StripLbl3"
        Me.StripLbl3.Size = New System.Drawing.Size(35, 22)
        Me.StripLbl3.Text = "of {0}"
        Me.StripLbl3.ToolTipText = "Número total de elementos"
        '
        'Separator21
        '
        Me.Separator21.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator21.Name = "Separator21"
        Me.Separator21.Size = New System.Drawing.Size(6, 25)
        '
        'StripBtn12
        '
        Me.StripBtn12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn12.Image = CType(resources.GetObject("StripBtn12.Image"), System.Drawing.Image)
        Me.StripBtn12.Name = "StripBtn12"
        Me.StripBtn12.RightToLeftAutoMirrorImage = True
        Me.StripBtn12.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn12.Text = "Mover último"
        '
        'StripBtn11
        '
        Me.StripBtn11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn11.Image = CType(resources.GetObject("StripBtn11.Image"), System.Drawing.Image)
        Me.StripBtn11.Name = "StripBtn11"
        Me.StripBtn11.RightToLeftAutoMirrorImage = True
        Me.StripBtn11.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn11.Text = "Mover siguiente"
        '
        'Separator20
        '
        Me.Separator20.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator20.Name = "Separator20"
        Me.Separator20.Size = New System.Drawing.Size(6, 25)
        '
        'StripTxt3
        '
        Me.StripTxt3.AccessibleName = "Posición"
        Me.StripTxt3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripTxt3.AutoSize = False
        Me.StripTxt3.BackColor = System.Drawing.Color.White
        Me.StripTxt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StripTxt3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.StripTxt3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StripTxt3.Name = "StripTxt3"
        Me.StripTxt3.Size = New System.Drawing.Size(50, 23)
        Me.StripTxt3.Text = "0"
        Me.StripTxt3.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.StripTxt3.ToolTipText = "Posición actual"
        '
        'Separator19
        '
        Me.Separator19.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator19.Name = "Separator19"
        Me.Separator19.Size = New System.Drawing.Size(6, 25)
        '
        'StripBtn10
        '
        Me.StripBtn10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn10.Image = CType(resources.GetObject("StripBtn10.Image"), System.Drawing.Image)
        Me.StripBtn10.Name = "StripBtn10"
        Me.StripBtn10.RightToLeftAutoMirrorImage = True
        Me.StripBtn10.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn10.Text = "Mover anterior"
        '
        'StripBtn9
        '
        Me.StripBtn9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn9.Image = CType(resources.GetObject("StripBtn9.Image"), System.Drawing.Image)
        Me.StripBtn9.Name = "StripBtn9"
        Me.StripBtn9.RightToLeftAutoMirrorImage = True
        Me.StripBtn9.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn9.Text = "Mover primero"
        '
        'Separator18
        '
        Me.Separator18.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator18.Name = "Separator18"
        Me.Separator18.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(34, 22)
        Me.ToolStripLabel3.Text = "         "
        '
        'Separator15
        '
        Me.Separator15.Name = "Separator15"
        Me.Separator15.Size = New System.Drawing.Size(6, 25)
        '
        'Btn7
        '
        Me.Btn7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn7.Image = CType(resources.GetObject("Btn7.Image"), System.Drawing.Image)
        Me.Btn7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn7.Name = "Btn7"
        Me.Btn7.Size = New System.Drawing.Size(76, 22)
        Me.Btn7.Text = "&AGREGAR"
        '
        'Separator16
        '
        Me.Separator16.Name = "Separator16"
        Me.Separator16.Size = New System.Drawing.Size(6, 25)
        '
        'Btn8
        '
        Me.Btn8.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn8.Image = CType(resources.GetObject("Btn8.Image"), System.Drawing.Image)
        Me.Btn8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn8.Name = "Btn8"
        Me.Btn8.Size = New System.Drawing.Size(67, 22)
        Me.Btn8.Text = "&QUITAR"
        '
        'Separator17
        '
        Me.Separator17.Name = "Separator17"
        Me.Separator17.Size = New System.Drawing.Size(6, 25)
        '
        'txtcodequipo
        '
        Appearance200.FontData.BoldAsString = "False"
        Appearance200.ForeColor = System.Drawing.Color.Black
        Appearance200.TextHAlignAsString = "Left"
        Appearance200.TextVAlignAsString = "Middle"
        Me.txtcodequipo.Appearance = Appearance200
        Me.txtcodequipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodequipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodequipo.Location = New System.Drawing.Point(935, 222)
        Me.txtcodequipo.MaxLength = 100
        Me.txtcodequipo.Name = "txtcodequipo"
        Me.txtcodequipo.ReadOnly = True
        Me.txtcodequipo.Size = New System.Drawing.Size(10, 21)
        Me.txtcodequipo.TabIndex = 232
        Me.txtcodequipo.TabStop = False
        Me.txtcodequipo.Visible = False
        '
        'UltraLabel7
        '
        Appearance201.BackColor = System.Drawing.Color.Transparent
        Appearance201.TextHAlignAsString = "Left"
        Appearance201.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance201
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Location = New System.Drawing.Point(938, 161)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(44, 14)
        Me.UltraLabel7.TabIndex = 228
        Me.UltraLabel7.Text = "Cantera"
        Me.UltraLabel7.Visible = False
        '
        'txtcodcantera
        '
        Appearance202.TextHAlignAsString = "Left"
        Appearance202.TextVAlignAsString = "Middle"
        Me.txtcodcantera.Appearance = Appearance202
        Me.txtcodcantera.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodcantera.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodcantera.Location = New System.Drawing.Point(935, 178)
        Me.txtcodcantera.Name = "txtcodcantera"
        Me.txtcodcantera.ReadOnly = True
        Me.txtcodcantera.Size = New System.Drawing.Size(10, 21)
        Me.txtcodcantera.TabIndex = 229
        Me.txtcodcantera.TabStop = False
        Me.txtcodcantera.Visible = False
        '
        'UltraLabel13
        '
        Appearance203.BackColor = System.Drawing.Color.Transparent
        Appearance203.TextHAlignAsString = "Left"
        Me.UltraLabel13.Appearance = Appearance203
        Me.UltraLabel13.AutoSize = True
        Me.UltraLabel13.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel13.Location = New System.Drawing.Point(938, 202)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(45, 17)
        Me.UltraLabel13.TabIndex = 230
        Me.UltraLabel13.Text = "Equipo :"
        Me.UltraLabel13.Visible = False
        '
        'txtid
        '
        Appearance204.FontData.BoldAsString = "False"
        Appearance204.ForeColor = System.Drawing.Color.Black
        Appearance204.TextHAlignAsString = "Left"
        Appearance204.TextVAlignAsString = "Middle"
        Me.txtid.Appearance = Appearance204
        Me.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtid.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtid.Location = New System.Drawing.Point(789, 222)
        Me.txtid.MaxLength = 300
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(66, 21)
        Me.txtid.TabIndex = 226
        Me.txtid.TabStop = False
        Me.txtid.Visible = False
        '
        'txtcantera
        '
        Appearance205.TextHAlignAsString = "Left"
        Appearance205.TextVAlignAsString = "Middle"
        Me.txtcantera.Appearance = Appearance205
        Me.txtcantera.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcantera.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcantera.Location = New System.Drawing.Point(789, 145)
        Me.txtcantera.Name = "txtcantera"
        Me.txtcantera.ReadOnly = True
        Me.txtcantera.Size = New System.Drawing.Size(66, 21)
        Me.txtcantera.TabIndex = 227
        Me.txtcantera.TabStop = False
        Me.txtcantera.Visible = False
        '
        'txtequipo
        '
        Appearance206.FontData.BoldAsString = "False"
        Appearance206.ForeColor = System.Drawing.Color.Black
        Appearance206.TextHAlignAsString = "Left"
        Appearance206.TextVAlignAsString = "Middle"
        Me.txtequipo.Appearance = Appearance206
        Me.txtequipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtequipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtequipo.Location = New System.Drawing.Point(789, 187)
        Me.txtequipo.MaxLength = 100
        Me.txtequipo.Name = "txtequipo"
        Me.txtequipo.ReadOnly = True
        Me.txtequipo.Size = New System.Drawing.Size(66, 21)
        Me.txtequipo.TabIndex = 231
        Me.txtequipo.TabStop = False
        Me.txtequipo.Visible = False
        '
        'dtpIni
        '
        Me.dtpIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIni.Location = New System.Drawing.Point(9180, 8892)
        Me.dtpIni.Name = "dtpIni"
        Me.dtpIni.Size = New System.Drawing.Size(104, 20)
        Me.dtpIni.TabIndex = 6
        Me.dtpIni.Visible = False
        '
        'UltraLabel8
        '
        Appearance207.BackColor = System.Drawing.Color.Transparent
        Appearance207.TextHAlignAsString = "Right"
        Me.UltraLabel8.Appearance = Appearance207
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel8.Location = New System.Drawing.Point(3, 138)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(37, 17)
        Me.UltraLabel8.TabIndex = 2
        Me.UltraLabel8.Text = "Desde"
        Me.UltraLabel8.Visible = False
        '
        'cbMoneda
        '
        Me.cbMoneda.BackColor = System.Drawing.Color.AliceBlue
        Me.cbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Location = New System.Drawing.Point(923, 32)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(119, 21)
        Me.cbMoneda.TabIndex = 210
        '
        'cbArea
        '
        Me.cbArea.BackColor = System.Drawing.Color.AliceBlue
        Me.cbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbArea.Enabled = False
        Me.cbArea.FormattingEnabled = True
        Me.cbArea.Location = New System.Drawing.Point(344, 96)
        Me.cbArea.Name = "cbArea"
        Me.cbArea.Size = New System.Drawing.Size(429, 21)
        Me.cbArea.TabIndex = 209
        '
        'UltraLabel6
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance2
        Me.UltraLabel6.Location = New System.Drawing.Point(779, 62)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(139, 21)
        Me.UltraLabel6.TabIndex = 176
        Me.UltraLabel6.Text = "Total"
        '
        'txttotal
        '
        Appearance105.TextHAlignAsString = "Right"
        Me.txttotal.Appearance = Appearance105
        Me.txttotal.AutoSize = False
        Me.txttotal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttotal.Location = New System.Drawing.Point(923, 64)
        Me.txttotal.MaxLength = 10
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(119, 22)
        Me.txttotal.TabIndex = 175
        Me.txttotal.TabStop = False
        '
        'dtFechaCrea
        '
        Me.dtFechaCrea.AutoSize = False
        Me.dtFechaCrea.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtFechaCrea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFechaCrea.Location = New System.Drawing.Point(68, 63)
        Me.dtFechaCrea.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtFechaCrea.Name = "dtFechaCrea"
        Me.dtFechaCrea.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtFechaCrea.Size = New System.Drawing.Size(147, 24)
        Me.dtFechaCrea.TabIndex = 173
        Me.dtFechaCrea.TabStop = False
        Me.dtFechaCrea.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'UltraLabel4
        '
        Appearance39.BackColor = System.Drawing.Color.Transparent
        Appearance39.TextHAlignAsString = "Center"
        Appearance39.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance39
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(3, 67)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(63, 14)
        Me.UltraLabel4.TabIndex = 174
        Me.UltraLabel4.Text = "F. Creación"
        '
        'UltraLabel39
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.TextHAlignAsString = "Left"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel39.Appearance = Appearance4
        Me.UltraLabel39.Location = New System.Drawing.Point(779, 99)
        Me.UltraLabel39.Name = "UltraLabel39"
        Me.UltraLabel39.Size = New System.Drawing.Size(139, 21)
        Me.UltraLabel39.TabIndex = 167
        Me.UltraLabel39.Text = "Estado de Solicitud"
        '
        'dtFechaLimite
        '
        Me.dtFechaLimite.AutoSize = False
        Me.dtFechaLimite.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtFechaLimite.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFechaLimite.Location = New System.Drawing.Point(68, 93)
        Me.dtFechaLimite.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtFechaLimite.Name = "dtFechaLimite"
        Me.dtFechaLimite.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtFechaLimite.Size = New System.Drawing.Size(147, 24)
        Me.dtFechaLimite.TabIndex = 0
        Me.dtFechaLimite.TabStop = False
        Me.dtFechaLimite.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'UltraLabel5
        '
        Appearance22.BackColor = System.Drawing.Color.Transparent
        Appearance22.TextHAlignAsString = "Center"
        Appearance22.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance22
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(14, 93)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(48, 27)
        Me.UltraLabel5.TabIndex = 100
        Me.UltraLabel5.Text = "F. Límite" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pago"
        '
        'txtMotivo
        '
        Appearance17.TextHAlignAsString = "Left"
        Appearance17.TextVAlignAsString = "Middle"
        Me.txtMotivo.Appearance = Appearance17
        Me.txtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotivo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtMotivo.Location = New System.Drawing.Point(67, 252)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(975, 66)
        Me.txtMotivo.TabIndex = 0
        Me.txtMotivo.TabStop = False
        '
        'UltraLabel3
        '
        Appearance156.BackColor = System.Drawing.Color.Transparent
        Appearance156.TextHAlignAsString = "Center"
        Appearance156.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance156
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(272, 67)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(68, 14)
        Me.UltraLabel3.TabIndex = 96
        Me.UltraLabel3.Text = "Jefe de Área"
        '
        'UltraLabel2
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Center"
        Appearance10.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance10
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(232, 36)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(108, 14)
        Me.UltraLabel2.TabIndex = 95
        Me.UltraLabel2.Text = "Nombres y Apellidos"
        '
        'txtJefeArea
        '
        Appearance67.TextHAlignAsString = "Left"
        Appearance67.TextVAlignAsString = "Middle"
        Me.txtJefeArea.Appearance = Appearance67
        Me.txtJefeArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJefeArea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtJefeArea.Location = New System.Drawing.Point(343, 63)
        Me.txtJefeArea.Name = "txtJefeArea"
        Me.txtJefeArea.ReadOnly = True
        Me.txtJefeArea.Size = New System.Drawing.Size(430, 21)
        Me.txtJefeArea.TabIndex = 0
        Me.txtJefeArea.TabStop = False
        '
        'UltraLabel1
        '
        Appearance24.BackColor = System.Drawing.Color.Transparent
        Appearance24.TextHAlignAsString = "Center"
        Appearance24.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance24
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(309, 99)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(28, 14)
        Me.UltraLabel1.TabIndex = 93
        Me.UltraLabel1.Text = "Área"
        '
        'TxtCodigoTrabajador
        '
        Appearance28.FontData.BoldAsString = "False"
        Appearance28.ForeColor = System.Drawing.Color.Black
        Appearance28.TextHAlignAsString = "Left"
        Appearance28.TextVAlignAsString = "Middle"
        Me.TxtCodigoTrabajador.Appearance = Appearance28
        Me.TxtCodigoTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodigoTrabajador.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtCodigoTrabajador.Location = New System.Drawing.Point(67, 32)
        Me.TxtCodigoTrabajador.MaxLength = 8
        Me.TxtCodigoTrabajador.Name = "TxtCodigoTrabajador"
        Me.TxtCodigoTrabajador.Size = New System.Drawing.Size(147, 21)
        Me.TxtCodigoTrabajador.TabIndex = 0
        Me.TxtCodigoTrabajador.TabStop = False
        '
        'UltraLabel21
        '
        Appearance31.BackColor = System.Drawing.Color.Transparent
        Appearance31.TextHAlignAsString = "Center"
        Appearance31.TextVAlignAsString = "Middle"
        Me.UltraLabel21.Appearance = Appearance31
        Me.UltraLabel21.AutoSize = True
        Me.UltraLabel21.Location = New System.Drawing.Point(26, 254)
        Me.UltraLabel21.Name = "UltraLabel21"
        Me.UltraLabel21.Size = New System.Drawing.Size(38, 14)
        Me.UltraLabel21.TabIndex = 17
        Me.UltraLabel21.Text = "Motivo"
        '
        'TxtNombresTrabajador
        '
        Appearance11.TextHAlignAsString = "Left"
        Appearance11.TextVAlignAsString = "Middle"
        Me.TxtNombresTrabajador.Appearance = Appearance11
        Me.TxtNombresTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombresTrabajador.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.TxtNombresTrabajador.Location = New System.Drawing.Point(344, 32)
        Me.TxtNombresTrabajador.Name = "TxtNombresTrabajador"
        Me.TxtNombresTrabajador.ReadOnly = True
        Me.TxtNombresTrabajador.Size = New System.Drawing.Size(430, 21)
        Me.TxtNombresTrabajador.TabIndex = 0
        Me.TxtNombresTrabajador.TabStop = False
        '
        'UltraLabel18
        '
        Appearance21.BackColor = System.Drawing.Color.Transparent
        Appearance21.TextHAlignAsString = "Center"
        Appearance21.TextVAlignAsString = "Middle"
        Me.UltraLabel18.Appearance = Appearance21
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Location = New System.Drawing.Point(21, 36)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(40, 14)
        Me.UltraLabel18.TabIndex = 15
        Me.UltraLabel18.Text = "Código"
        '
        'UltraLabel19
        '
        Me.UltraLabel19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance41.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance41.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance41.ForeColor = System.Drawing.Color.White
        Appearance41.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance41.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance41.TextHAlignAsString = "Left"
        Appearance41.TextVAlignAsString = "Middle"
        Me.UltraLabel19.Appearance = Appearance41
        Me.UltraLabel19.Controls.Add(Me.lblnSolicitud)
        Me.UltraLabel19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel19.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption
        Me.UltraLabel19.Location = New System.Drawing.Point(0, 2)
        Me.UltraLabel19.Name = "UltraLabel19"
        Me.UltraLabel19.Size = New System.Drawing.Size(1133, 25)
        Me.UltraLabel19.TabIndex = 14
        Me.UltraLabel19.Text = "I. DATOS DEL TRABAJADOR"
        '
        'lblnSolicitud
        '
        Appearance121.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance121.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance121.ForeColor = System.Drawing.Color.White
        Appearance121.TextHAlignAsString = "Right"
        Appearance121.TextVAlignAsString = "Middle"
        Me.lblnSolicitud.Appearance = Appearance121
        Me.lblnSolicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnSolicitud.Location = New System.Drawing.Point(550, 6)
        Me.lblnSolicitud.Name = "lblnSolicitud"
        Me.lblnSolicitud.Size = New System.Drawing.Size(223, 16)
        Me.lblnSolicitud.TabIndex = 138
        Me.lblnSolicitud.Text = "N° Solicitud:"
        '
        'printPDF
        '
        Me.printPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.printPDF.Location = New System.Drawing.Point(0, 0)
        Me.printPDF.MinimumSize = New System.Drawing.Size(20, 20)
        Me.printPDF.Name = "printPDF"
        Me.printPDF.Size = New System.Drawing.Size(1088, 533)
        Me.printPDF.TabIndex = 222
        Me.printPDF.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabMaestroEntregas
        '
        Appearance98.FontData.BoldAsString = "True"
        Appearance98.FontData.Name = "Arial Narrow"
        Appearance98.FontData.SizeInPoints = 16.0!
        Me.TabMaestroEntregas.ActiveTabAppearance = Appearance98
        Me.TabMaestroEntregas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance68.FontData.Name = "Arial Narrow"
        Appearance68.FontData.SizeInPoints = 10.0!
        Me.TabMaestroEntregas.Appearance = Appearance68
        Me.TabMaestroEntregas.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.TabMaestroEntregas.Controls.Add(Me.UltraTabPageControl4)
        Me.TabMaestroEntregas.Controls.Add(Me.UltraTabPageControl1)
        Me.TabMaestroEntregas.Location = New System.Drawing.Point(1, 42)
        Me.TabMaestroEntregas.MinTabWidth = 0
        Me.TabMaestroEntregas.Name = "TabMaestroEntregas"
        Appearance52.FontData.SizeInPoints = 12.0!
        Me.TabMaestroEntregas.SelectedTabAppearance = Appearance52
        Me.TabMaestroEntregas.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.TabMaestroEntregas.Size = New System.Drawing.Size(1092, 571)
        Me.TabMaestroEntregas.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance51.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TabMaestroEntregas.TabHeaderAreaAppearance = Appearance51
        Me.TabMaestroEntregas.TabIndex = 4
        Me.TabMaestroEntregas.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab2.Key = "Lista"
        UltraTab2.TabPage = Me.UltraTabPageControl1
        UltraTab2.Text = "Listado de Solicitudes"
        Appearance43.FontData.SizeInPoints = 8.0!
        UltraTab1.Appearance = Appearance43
        UltraTab1.Key = "Registro"
        UltraTab1.TabPage = Me.UltraTabPageControl4
        UltraTab1.Text = "Solicitud"
        Me.TabMaestroEntregas.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2, UltraTab1})
        Me.TabMaestroEntregas.TabStop = False
        Me.TabMaestroEntregas.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1088, 533)
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
        Appearance29.Image = "Consultar.png"
        Appearance29.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.txtPlacod2.Appearance = Appearance29
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
        'cmbArea
        '
        Me.cmbArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance42.BackColor = System.Drawing.SystemColors.Window
        Appearance42.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmbArea.DisplayLayout.Appearance = Appearance42
        Me.cmbArea.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmbArea.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance44.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance44.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance44.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbArea.DisplayLayout.GroupByBox.Appearance = Appearance44
        Appearance45.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbArea.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance45
        Appearance47.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance47.BackColor2 = System.Drawing.SystemColors.Control
        Appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance47.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbArea.DisplayLayout.GroupByBox.PromptAppearance = Appearance47
        Me.cmbArea.DisplayLayout.MaxColScrollRegions = 1
        Me.cmbArea.DisplayLayout.MaxRowScrollRegions = 1
        Appearance48.BackColor = System.Drawing.SystemColors.Highlight
        Appearance48.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmbArea.DisplayLayout.Override.ActiveRowAppearance = Appearance48
        Appearance49.BackColor = System.Drawing.Color.Transparent
        Me.cmbArea.DisplayLayout.Override.CardAreaAppearance = Appearance49
        Appearance50.BorderColor = System.Drawing.Color.Silver
        Appearance50.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmbArea.DisplayLayout.Override.CellAppearance = Appearance50
        Me.cmbArea.DisplayLayout.Override.CellPadding = 0
        Appearance23.TextHAlignAsString = "Left"
        Me.cmbArea.DisplayLayout.Override.HeaderAppearance = Appearance23
        Me.cmbArea.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbArea.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.BorderColor = System.Drawing.Color.Silver
        Me.cmbArea.DisplayLayout.Override.RowAppearance = Appearance53
        Me.cmbArea.DisplayLayout.Override.RowSpacingAfter = 4
        Me.cmbArea.DisplayLayout.Override.RowSpacingBefore = 2
        Me.cmbArea.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmbArea.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmbArea.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmbArea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbArea.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbArea.Location = New System.Drawing.Point(67, 58)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.ReadOnly = True
        Me.cmbArea.Size = New System.Drawing.Size(147, 22)
        Me.cmbArea.TabIndex = 0
        Me.cmbArea.TabStop = False
        '
        'cmbMoneda
        '
        Me.cmbMoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance37.BackColor = System.Drawing.SystemColors.Window
        Appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmbMoneda.DisplayLayout.Appearance = Appearance37
        Me.cmbMoneda.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmbMoneda.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance40.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance40.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance40.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbMoneda.DisplayLayout.GroupByBox.Appearance = Appearance40
        Appearance131.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbMoneda.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance131
        Appearance132.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance132.BackColor2 = System.Drawing.SystemColors.Control
        Appearance132.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance132.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbMoneda.DisplayLayout.GroupByBox.PromptAppearance = Appearance132
        Me.cmbMoneda.DisplayLayout.MaxColScrollRegions = 1
        Me.cmbMoneda.DisplayLayout.MaxRowScrollRegions = 1
        Appearance133.BackColor = System.Drawing.SystemColors.Highlight
        Appearance133.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmbMoneda.DisplayLayout.Override.ActiveRowAppearance = Appearance133
        Appearance134.BackColor = System.Drawing.Color.Transparent
        Me.cmbMoneda.DisplayLayout.Override.CardAreaAppearance = Appearance134
        Appearance135.BorderColor = System.Drawing.Color.Silver
        Appearance135.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmbMoneda.DisplayLayout.Override.CellAppearance = Appearance135
        Me.cmbMoneda.DisplayLayout.Override.CellPadding = 0
        Appearance136.TextHAlignAsString = "Left"
        Me.cmbMoneda.DisplayLayout.Override.HeaderAppearance = Appearance136
        Me.cmbMoneda.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbMoneda.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.cmbMoneda.DisplayLayout.Override.RowAppearance = Appearance18
        Appearance19.BorderColor = System.Drawing.Color.White
        Appearance19.ForeColor = System.Drawing.Color.White
        Me.cmbMoneda.DisplayLayout.Override.RowSelectorAppearance = Appearance19
        Me.cmbMoneda.DisplayLayout.Override.RowSpacingAfter = 4
        Me.cmbMoneda.DisplayLayout.Override.RowSpacingBefore = 2
        Me.cmbMoneda.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmbMoneda.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmbMoneda.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmbMoneda.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMoneda.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbMoneda.Location = New System.Drawing.Point(783, 59)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(108, 22)
        Me.cmbMoneda.TabIndex = 157
        Me.cmbMoneda.TabStop = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(12, 9)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(152, 27)
        Me.btnNuevo.TabIndex = 170
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'BtnReporte
        '
        Me.BtnReporte.Image = Global.SIP_Presentacion.My.Resources.Resources.table
        Me.BtnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReporte.Location = New System.Drawing.Point(170, 9)
        Me.BtnReporte.Name = "BtnReporte"
        Me.BtnReporte.Size = New System.Drawing.Size(152, 27)
        Me.BtnReporte.TabIndex = 171
        Me.BtnReporte.Text = "Imprimir"
        Me.BtnReporte.UseVisualStyleBackColor = True
        Me.BtnReporte.Visible = False
        '
        'btnAnular
        '
        Me.btnAnular.Image = Global.SIP_Presentacion.My.Resources.Resources.delete_icon
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnular.Location = New System.Drawing.Point(328, 9)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(152, 27)
        Me.btnAnular.TabIndex = 172
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.UseVisualStyleBackColor = True
        Me.btnAnular.Visible = False
        '
        'FrmSolicitudPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1092, 610)
        Me.Controls.Add(Me.btnAnular)
        Me.Controls.Add(Me.BtnReporte)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.TabMaestroEntregas)
        Me.Name = "FrmSolicitudPlanilla"
        Me.Text = "FrmSolicitudPlanilla"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.GridSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.UltraTabPageControl4.PerformLayout()
        Me.pnlRegistrar.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBeneficiario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Navigator4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Navigator4.ResumeLayout(False)
        Me.Navigator4.PerformLayout()
        CType(Me.txtcodequipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodcantera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcantera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtequipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaCrea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaLimite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJefeArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodigoTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNombresTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraLabel19.ResumeLayout(False)
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabMaestroEntregas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabMaestroEntregas.ResumeLayout(False)
        Me.pnlRegistrar2.ResumeLayout(False)
        Me.pnlRegistrar2.PerformLayout()
        CType(Me.dtpFecha2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlacod2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents Source2 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Source3 As System.Windows.Forms.BindingSource
    Friend WithEvents Source4 As System.Windows.Forms.BindingSource
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents TabMaestroEntregas As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents GridSolicitudes As Infragistics.Win.UltraWinGrid.UltraGrid
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
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel39 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtFechaLimite As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtMotivo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtJefeArea As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtCodigoTrabajador As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel21 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtNombresTrabajador As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel19 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblnSolicitud As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents pnlRegistrar2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipo2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboMotivo2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents dtpFecha2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPlacod2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbMoneda As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents dtFechaCrea As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txttotal As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cbArea As System.Windows.Forms.ComboBox
    Friend WithEvents cbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grdDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Navigator4 As System.Windows.Forms.BindingNavigator
    Friend WithEvents StripLbl3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Separator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StripBtn12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StripBtn11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StripTxt3 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Separator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StripBtn10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StripBtn9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Separator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtcodequipo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcodcantera As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtid As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcantera As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtequipo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dtpIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents pnlRegistrar As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDescripción As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtMonto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblNroSolicitud As System.Windows.Forms.Label
    Friend WithEvents lblIdDetalle As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ckbTesoreria As System.Windows.Forms.CheckBox
    Friend WithEvents ckbJefatura As System.Windows.Forms.CheckBox
    Friend WithEvents btnAddPDF As System.Windows.Forms.Button
    Friend WithEvents btnvisualizar As System.Windows.Forms.Button
    Friend WithEvents printPDF As System.Windows.Forms.WebBrowser
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddPDFP As System.Windows.Forms.Button
    Friend WithEvents btnvisualizarP As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnReporte As System.Windows.Forms.Button
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtDNI As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtNomBanco As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtBeneficiario As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtNroCuenta As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnAnular As System.Windows.Forms.Button
End Class
