<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCostoPromedio
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
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCostoPromedio))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_prod", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Min_Var_D", 1)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Min_Var_I", 2)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Min_fij_D", 3)
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Min_Fij_I", 4)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Min_Fij_O", 5)
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cha_Var_D", 6)
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cha_Var_I", 7)
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cha_fij_D", 8)
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cha_Fij_I", 9)
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Mol_Var_D", 10)
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Mol_Var_I", 11)
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Mol_fij_D", 12)
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Mol_Fij_I", 13)
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Envases", 14)
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Gto_Adm", 15)
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Gto_Vta", 16)
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cod_prodRef", 17)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tipoRegistro", 18)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Producto", 19)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(939)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(731)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(731)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(731)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(390)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(290)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion13 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion14 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion16 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion17 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem25 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem26 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem27 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem28 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem29 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem30 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem31 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem32 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem33 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem34 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem35 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem36 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.Button1 = New System.Windows.Forms.Button
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbMes1 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.btneliminar = New System.Windows.Forms.Button
        Me.btnnuevo = New System.Windows.Forms.Button
        Me.btnReporte = New System.Windows.Forms.Button
        Me.btnduplicar = New System.Windows.Forms.Button
        Me.gridcostopromedio = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbMes = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.txtayo = New System.Windows.Forms.NumericUpDown
        Me.btnCalcular = New System.Windows.Forms.Button
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cmbMes1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridcostopromedio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1160, 541)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.lblmensaje)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.UltraLabel1)
        Me.Panel1.Controls.Add(Me.cmbMes1)
        Me.Panel1.Controls.Add(Me.btneliminar)
        Me.Panel1.Controls.Add(Me.btnnuevo)
        Me.Panel1.Controls.Add(Me.btnReporte)
        Me.Panel1.Controls.Add(Me.btnduplicar)
        Me.Panel1.Controls.Add(Me.gridcostopromedio)
        Me.Panel1.Controls.Add(Me.UltraLabel16)
        Me.Panel1.Controls.Add(Me.cmbMes)
        Me.Panel1.Controls.Add(Me.UltraLabel6)
        Me.Panel1.Controls.Add(Me.txtayo)
        Me.Panel1.Controls.Add(Me.btnCalcular)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1160, 541)
        Me.Panel1.TabIndex = 176
        '
        'Button4
        '
        Me.Button4.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(20, 419)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(184, 37)
        Me.Button4.TabIndex = 211
        Me.Button4.Text = "Abrir Mes"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(20, 376)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(184, 37)
        Me.Button3.TabIndex = 210
        Me.Button3.Text = "Procesar Márgenes"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(20, 248)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(184, 37)
        Me.Button2.TabIndex = 209
        Me.Button2.Text = "Clonar Costos de Envase"
        Me.Button2.UseVisualStyleBackColor = True
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
        Me.lblmensaje.Location = New System.Drawing.Point(2, 183)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(1160, 39)
        Me.lblmensaje.TabIndex = 166
        Me.lblmensaje.Text = "Procesando Datos..."
        Me.lblmensaje.Visible = False
        '
        'Button1
        '
        Me.Button1.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(20, 205)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(184, 37)
        Me.Button1.TabIndex = 208
        Me.Button1.Text = "Importar Productos a Clonar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UltraLabel1
        '
        Appearance33.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance33
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(246, 39)
        Me.UltraLabel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(32, 17)
        Me.UltraLabel1.TabIndex = 207
        Me.UltraLabel1.Text = "hasta"
        '
        'cmbMes1
        '
        Me.cmbMes1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMes1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "1"
        ValueListItem1.DisplayText = "ENERO"
        ValueListItem2.DataValue = "2"
        ValueListItem2.DisplayText = "FEBRERO"
        ValueListItem3.DataValue = "3"
        ValueListItem3.DisplayText = "MARZO"
        ValueListItem4.DataValue = "4"
        ValueListItem4.DisplayText = "ABRIL"
        ValueListItem5.DataValue = "5"
        ValueListItem5.DisplayText = "MAYO"
        ValueListItem6.DataValue = "6"
        ValueListItem6.DisplayText = "JUNIO"
        ValueListItem7.DataValue = "7"
        ValueListItem7.DisplayText = "JULIO"
        ValueListItem8.DataValue = "8"
        ValueListItem8.DisplayText = "AGOSTO"
        ValueListItem9.DataValue = "9"
        ValueListItem9.DisplayText = "SETIEMBRE"
        ValueListItem10.DataValue = "10"
        ValueListItem10.DisplayText = "OCTUBRE"
        ValueListItem11.DataValue = "11"
        ValueListItem11.DisplayText = "NOVIEMBRE"
        ValueListItem12.DataValue = "12"
        ValueListItem12.DisplayText = "DICIEMBRE"
        Me.cmbMes1.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3, ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7, ValueListItem8, ValueListItem9, ValueListItem10, ValueListItem11, ValueListItem12})
        Me.cmbMes1.Location = New System.Drawing.Point(284, 37)
        Me.cmbMes1.Name = "cmbMes1"
        Me.cmbMes1.Size = New System.Drawing.Size(150, 21)
        Me.cmbMes1.TabIndex = 206
        '
        'btneliminar
        '
        Me.btneliminar.Image = Global.SIP_Presentacion.My.Resources.Resources.delete_icon
        Me.btneliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btneliminar.Location = New System.Drawing.Point(20, 291)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(184, 37)
        Me.btneliminar.TabIndex = 205
        Me.btneliminar.Text = "Eliminar Registro"
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Image = Global.SIP_Presentacion.My.Resources.Resources.table
        Me.btnnuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnnuevo.Location = New System.Drawing.Point(20, 118)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(184, 37)
        Me.btnnuevo.TabIndex = 204
        Me.btnnuevo.Text = "Nuevo Registro"
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.SIP_Presentacion.My.Resources.Resources.page_excel
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(20, 334)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(184, 37)
        Me.btnReporte.TabIndex = 202
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'btnduplicar
        '
        Me.btnduplicar.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.btnduplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnduplicar.Location = New System.Drawing.Point(20, 162)
        Me.btnduplicar.Name = "btnduplicar"
        Me.btnduplicar.Size = New System.Drawing.Size(184, 37)
        Me.btnduplicar.TabIndex = 203
        Me.btnduplicar.Text = "Clonar Registro"
        Me.btnduplicar.UseVisualStyleBackColor = True
        '
        'gridcostopromedio
        '
        Me.gridcostopromedio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance69.BackColor = System.Drawing.SystemColors.Window
        Appearance69.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridcostopromedio.DisplayLayout.Appearance = Appearance69
        Me.gridcostopromedio.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance70.Image = CType(resources.GetObject("Appearance70.Image"), Object)
        Appearance70.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance70.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance70
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.Width = 31
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance1.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance1
        UltraGridColumn3.Header.Caption = "Var_D"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.Width = 109
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance2
        UltraGridColumn4.Header.Caption = "Var_I"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn4.Width = 81
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance3
        UltraGridColumn5.Header.Caption = "Fijo_D"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn5.Width = 89
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance4
        UltraGridColumn6.Header.Caption = "Fijo_I"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn6.Width = 63
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance5
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 26
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance6
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn8.Width = 80
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance7
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn9.Width = 60
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance8
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn10.Width = 53
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance9
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn11.Width = 47
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance10
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn12.Width = 54
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance11
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn13.Width = 51
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance12
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn14.Width = 48
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance13
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn15.Width = 47
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance14
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn16.Width = 51
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance15
        UltraGridColumn17.Header.VisiblePosition = 16
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn17.Width = 22
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance16
        UltraGridColumn18.Header.VisiblePosition = 17
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn18.Width = 24
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn19.Header.VisiblePosition = 18
        UltraGridColumn19.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn19.Width = 37
        UltraGridColumn20.Header.VisiblePosition = 19
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 88
        UltraGridColumn21.Header.VisiblePosition = 20
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 92
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21})
        Me.gridcostopromedio.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridcostopromedio.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridcostopromedio.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion16)
        Me.gridcostopromedio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion17)
        Me.gridcostopromedio.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance72.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance72.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance72.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance72.BorderColor = System.Drawing.SystemColors.Window
        Me.gridcostopromedio.DisplayLayout.GroupByBox.Appearance = Appearance72
        Appearance73.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridcostopromedio.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance73
        Me.gridcostopromedio.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridcostopromedio.DisplayLayout.GroupByBox.Hidden = True
        Appearance74.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance74.BackColor2 = System.Drawing.SystemColors.Control
        Appearance74.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance74.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridcostopromedio.DisplayLayout.GroupByBox.PromptAppearance = Appearance74
        Me.gridcostopromedio.DisplayLayout.MaxColScrollRegions = 1
        Me.gridcostopromedio.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridcostopromedio.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridcostopromedio.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridcostopromedio.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance75.BackColor = System.Drawing.SystemColors.Window
        Me.gridcostopromedio.DisplayLayout.Override.CardAreaAppearance = Appearance75
        Appearance76.BorderColor = System.Drawing.Color.Silver
        Appearance76.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridcostopromedio.DisplayLayout.Override.CellAppearance = Appearance76
        Me.gridcostopromedio.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridcostopromedio.DisplayLayout.Override.CellPadding = 0
        Me.gridcostopromedio.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridcostopromedio.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridcostopromedio.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridcostopromedio.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance77.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance77.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridcostopromedio.DisplayLayout.Override.FilterRowAppearance = Appearance77
        Me.gridcostopromedio.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridcostopromedio.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridcostopromedio.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance78.BackColor = System.Drawing.SystemColors.Control
        Appearance78.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance78.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance78.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance78.BorderColor = System.Drawing.SystemColors.Window
        Me.gridcostopromedio.DisplayLayout.Override.GroupByRowAppearance = Appearance78
        Appearance79.FontData.Name = "Arial Narrow"
        Appearance79.FontData.SizeInPoints = 10.0!
        Appearance79.TextHAlignAsString = "Left"
        Me.gridcostopromedio.DisplayLayout.Override.HeaderAppearance = Appearance79
        Me.gridcostopromedio.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridcostopromedio.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridcostopromedio.DisplayLayout.Override.MinRowHeight = 24
        Appearance80.BackColor = System.Drawing.SystemColors.Window
        Appearance80.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance80.TextVAlignAsString = "Middle"
        Me.gridcostopromedio.DisplayLayout.Override.RowAppearance = Appearance80
        Me.gridcostopromedio.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridcostopromedio.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridcostopromedio.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance81.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridcostopromedio.DisplayLayout.Override.TemplateAddRowAppearance = Appearance81
        Me.gridcostopromedio.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridcostopromedio.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridcostopromedio.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridcostopromedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridcostopromedio.Location = New System.Drawing.Point(210, 75)
        Me.gridcostopromedio.Name = "gridcostopromedio"
        Me.gridcostopromedio.Size = New System.Drawing.Size(941, 457)
        Me.gridcostopromedio.TabIndex = 201
        '
        'UltraLabel16
        '
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel16.Appearance = Appearance20
        Me.UltraLabel16.AutoSize = True
        Me.UltraLabel16.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel16.Location = New System.Drawing.Point(20, 39)
        Me.UltraLabel16.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(59, 17)
        Me.UltraLabel16.TabIndex = 193
        Me.UltraLabel16.Text = "Mes desde"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMes.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem25.DataValue = "1"
        ValueListItem25.DisplayText = "ENERO"
        ValueListItem26.DataValue = "2"
        ValueListItem26.DisplayText = "FEBRERO"
        ValueListItem27.DataValue = "3"
        ValueListItem27.DisplayText = "MARZO"
        ValueListItem28.DataValue = "4"
        ValueListItem28.DisplayText = "ABRIL"
        ValueListItem29.DataValue = "5"
        ValueListItem29.DisplayText = "MAYO"
        ValueListItem30.DataValue = "6"
        ValueListItem30.DisplayText = "JUNIO"
        ValueListItem31.DataValue = "7"
        ValueListItem31.DisplayText = "JULIO"
        ValueListItem32.DataValue = "8"
        ValueListItem32.DisplayText = "AGOSTO"
        ValueListItem33.DataValue = "9"
        ValueListItem33.DisplayText = "SETIEMBRE"
        ValueListItem34.DataValue = "10"
        ValueListItem34.DisplayText = "OCTUBRE"
        ValueListItem35.DataValue = "11"
        ValueListItem35.DisplayText = "NOVIEMBRE"
        ValueListItem36.DataValue = "12"
        ValueListItem36.DisplayText = "DICIEMBRE"
        Me.cmbMes.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem25, ValueListItem26, ValueListItem27, ValueListItem28, ValueListItem29, ValueListItem30, ValueListItem31, ValueListItem32, ValueListItem33, ValueListItem34, ValueListItem35, ValueListItem36})
        Me.cmbMes.Location = New System.Drawing.Point(85, 37)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.ReadOnly = True
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
        Me.UltraLabel6.Location = New System.Drawing.Point(20, 13)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(24, 14)
        Me.UltraLabel6.TabIndex = 191
        Me.UltraLabel6.Text = "Año"
        '
        'txtayo
        '
        Me.txtayo.Location = New System.Drawing.Point(54, 11)
        Me.txtayo.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtayo.Name = "txtayo"
        Me.txtayo.Size = New System.Drawing.Size(57, 20)
        Me.txtayo.TabIndex = 190
        Me.txtayo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtayo.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'btnCalcular
        '
        Me.btnCalcular.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.btnCalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCalcular.Location = New System.Drawing.Point(20, 75)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(184, 37)
        Me.btnCalcular.TabIndex = 0
        Me.btnCalcular.Text = "Calcular"
        Me.btnCalcular.UseVisualStyleBackColor = True
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
        Me.Tab1.Size = New System.Drawing.Size(1164, 579)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance19.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance19
        Me.Tab1.TabIndex = 11
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
        UltraTab3.Text = "COSTOS PROMEDIOS"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1160, 541)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmCostoPromedio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1164, 579)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmCostoPromedio"
        Me.Text = "FrmCostoPromedio"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmbMes1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridcostopromedio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbMes As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtayo As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents gridcostopromedio As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents btnduplicar As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbMes1 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
