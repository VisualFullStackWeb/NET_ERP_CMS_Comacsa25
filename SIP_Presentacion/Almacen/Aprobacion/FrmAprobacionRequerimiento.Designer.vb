<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAprobacionRequerimiento
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
        Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Area")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroRequerimiento")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserCrea")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoArea")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LugarEntrega")
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoLugarEntrega")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Action")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Area")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroRequerimiento")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UserCrea")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoArea")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("LugarEntrega")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaEntrega")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoLugarEntrega")
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UM")
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Item")
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Empleo")
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observaciones")
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descripcion")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UM")
        Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Item")
        Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Empleo")
        Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observaciones")
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance139 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.DtFin = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.DtInicio = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.RbAnular = New System.Windows.Forms.RadioButton
        Me.RbAprobacion = New System.Windows.Forms.RadioButton
        Me.dgvRequerimiento = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel
        Me.ChkTodos = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.LblMensaje = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.DgvDetalleRequerimiento = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LstDet = New System.Windows.Forms.ListBox
        Me.LblDetalleMensaje = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.CmbAlmacen = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtUMArticulo = New Infragistics.Win.Misc.UltraLabel
        Me.TxtDescripcionArticulo = New Infragistics.Win.Misc.UltraLabel
        Me.TxtCodigoArticulo = New Infragistics.Win.Misc.UltraLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabAprobacionRequerimiento = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Cia1 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Cia2 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.DtFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRequerimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.DgvDetalleRequerimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.CmbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabAprobacionRequerimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAprobacionRequerimiento.SuspendLayout()
        CType(Me.Cia1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cia2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Cia1)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl1.Controls.Add(Me.DtFin)
        Me.UltraTabPageControl1.Controls.Add(Me.DtInicio)
        Me.UltraTabPageControl1.Controls.Add(Me.RbAnular)
        Me.UltraTabPageControl1.Controls.Add(Me.RbAprobacion)
        Me.UltraTabPageControl1.Controls.Add(Me.dgvRequerimiento)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel14)
        Me.UltraTabPageControl1.Controls.Add(Me.ChkTodos)
        Me.UltraTabPageControl1.Controls.Add(Me.LblMensaje)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(812, 464)
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(670, 10)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(40, 14)
        Me.UltraLabel2.TabIndex = 139
        Me.UltraLabel2.Text = "Hasta :"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(480, 10)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(43, 14)
        Me.UltraLabel1.TabIndex = 138
        Me.UltraLabel1.Text = "Desde :"
        '
        'DtFin
        '
        Me.DtFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtFin.BackColor = System.Drawing.SystemColors.Window
        Me.DtFin.DateButtons.Add(DateButton1)
        Me.DtFin.Location = New System.Drawing.Point(713, 10)
        Me.DtFin.Name = "DtFin"
        Me.DtFin.NonAutoSizeHeight = 21
        Me.DtFin.Size = New System.Drawing.Size(90, 21)
        Me.DtFin.SpinButtonsVisible = True
        Me.DtFin.TabIndex = 137
        Me.DtFin.Value = "11/02/2011 11:59:59 pm"
        '
        'DtInicio
        '
        Me.DtInicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtInicio.BackColor = System.Drawing.SystemColors.Window
        Me.DtInicio.DateButtons.Add(DateButton2)
        Me.DtInicio.Location = New System.Drawing.Point(525, 10)
        Me.DtInicio.Name = "DtInicio"
        Me.DtInicio.NonAutoSizeHeight = 21
        Me.DtInicio.Size = New System.Drawing.Size(92, 21)
        Me.DtInicio.SpinButtonsVisible = True
        Me.DtInicio.TabIndex = 136
        Me.DtInicio.Value = "11/02/2011 12:00:00 am"
        '
        'RbAnular
        '
        Me.RbAnular.AutoSize = True
        Me.RbAnular.BackColor = System.Drawing.Color.Transparent
        Me.RbAnular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbAnular.Location = New System.Drawing.Point(103, 43)
        Me.RbAnular.Name = "RbAnular"
        Me.RbAnular.Size = New System.Drawing.Size(125, 19)
        Me.RbAnular.TabIndex = 135
        Me.RbAnular.TabStop = True
        Me.RbAnular.Text = "Anular Aprobación"
        Me.RbAnular.UseVisualStyleBackColor = False
        '
        'RbAprobacion
        '
        Me.RbAprobacion.AutoSize = True
        Me.RbAprobacion.BackColor = System.Drawing.Color.Transparent
        Me.RbAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbAprobacion.Location = New System.Drawing.Point(10, 43)
        Me.RbAprobacion.Name = "RbAprobacion"
        Me.RbAprobacion.Size = New System.Drawing.Size(87, 19)
        Me.RbAprobacion.TabIndex = 134
        Me.RbAprobacion.TabStop = True
        Me.RbAprobacion.Text = "Aprobación"
        Me.RbAprobacion.UseVisualStyleBackColor = False
        '
        'dgvRequerimiento
        '
        Me.dgvRequerimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRequerimiento.DataSource = Me.UltraDataSource1
        Appearance45.BackColor = System.Drawing.Color.White
        Me.dgvRequerimiento.DisplayLayout.Appearance = Appearance45
        Me.dgvRequerimiento.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand1.ColHeaderLines = 2
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance11.FontData.BoldAsString = "False"
        Appearance11.FontData.SizeInPoints = 8.0!
        UltraGridColumn1.Header.Appearance = Appearance11
        UltraGridColumn1.Header.Caption = "Aprobar"
        UltraGridColumn1.Header.VisiblePosition = 6
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 65
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.FontData.SizeInPoints = 8.0!
        Appearance12.TextHAlignAsString = "Center"
        Appearance12.TextVAlignAsString = "Middle"
        UltraGridColumn2.CellAppearance = Appearance12
        Appearance15.FontData.BoldAsString = "False"
        Appearance15.FontData.SizeInPoints = 8.0!
        UltraGridColumn2.Header.Appearance = Appearance15
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 85
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance16.FontData.BoldAsString = "False"
        Appearance16.FontData.SizeInPoints = 8.0!
        UltraGridColumn3.CellAppearance = Appearance16
        Appearance17.FontData.BoldAsString = "False"
        Appearance17.FontData.SizeInPoints = 8.0!
        UltraGridColumn3.Header.Appearance = Appearance17
        UltraGridColumn3.Header.VisiblePosition = 7
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 72
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance18.FontData.BoldAsString = "False"
        Appearance18.FontData.SizeInPoints = 8.0!
        Appearance18.TextHAlignAsString = "Center"
        Appearance18.TextVAlignAsString = "Middle"
        UltraGridColumn4.CellAppearance = Appearance18
        UltraGridColumn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance19.FontData.BoldAsString = "False"
        Appearance19.FontData.SizeInPoints = 8.0!
        UltraGridColumn4.Header.Appearance = Appearance19
        UltraGridColumn4.Header.VisiblePosition = 2
        UltraGridColumn4.Width = 170
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance20.FontData.BoldAsString = "False"
        Appearance20.FontData.SizeInPoints = 8.0!
        Appearance20.TextHAlignAsString = "Center"
        Appearance20.TextVAlignAsString = "Middle"
        UltraGridColumn5.CellAppearance = Appearance20
        Appearance21.FontData.BoldAsString = "False"
        Appearance21.FontData.SizeInPoints = 8.0!
        UltraGridColumn5.Header.Appearance = Appearance21
        UltraGridColumn5.Header.Caption = "Nro" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Requerimiento"
        UltraGridColumn5.Header.VisiblePosition = 0
        UltraGridColumn5.Width = 87
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance22.FontData.BoldAsString = "False"
        Appearance22.FontData.SizeInPoints = 8.0!
        Appearance22.TextHAlignAsString = "Center"
        Appearance22.TextVAlignAsString = "Middle"
        UltraGridColumn6.CellAppearance = Appearance22
        UltraGridColumn6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance23.FontData.BoldAsString = "False"
        Appearance23.FontData.SizeInPoints = 8.0!
        UltraGridColumn6.Header.Appearance = Appearance23
        UltraGridColumn6.Header.Caption = "User" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Creador"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 85
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance24.FontData.BoldAsString = "False"
        Appearance24.FontData.SizeInPoints = 8.0!
        UltraGridColumn7.Header.Appearance = Appearance24
        UltraGridColumn7.Header.VisiblePosition = 8
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 99
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance25.FontData.BoldAsString = "False"
        Appearance25.FontData.SizeInPoints = 8.0!
        UltraGridColumn8.CellAppearance = Appearance25
        UltraGridColumn8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance26.FontData.BoldAsString = "False"
        Appearance26.FontData.SizeInPoints = 8.0!
        UltraGridColumn8.Header.Appearance = Appearance26
        UltraGridColumn8.Header.Caption = "Lugar Entrega"
        UltraGridColumn8.Header.VisiblePosition = 3
        UltraGridColumn8.Width = 170
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance27.FontData.BoldAsString = "False"
        Appearance27.FontData.SizeInPoints = 8.0!
        Appearance27.TextHAlignAsString = "Center"
        Appearance27.TextVAlignAsString = "Middle"
        UltraGridColumn9.CellAppearance = Appearance27
        Appearance28.FontData.BoldAsString = "False"
        Appearance28.FontData.SizeInPoints = 8.0!
        UltraGridColumn9.Header.Appearance = Appearance28
        UltraGridColumn9.Header.Caption = "Fecha" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Entrega"
        UltraGridColumn9.Header.VisiblePosition = 4
        UltraGridColumn9.Width = 90
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance29.FontData.BoldAsString = "False"
        Appearance29.FontData.SizeInPoints = 8.0!
        UltraGridColumn10.Header.Appearance = Appearance29
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 99
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10})
        Me.dgvRequerimiento.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvRequerimiento.DisplayLayout.InterBandSpacing = 18
        Me.dgvRequerimiento.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvRequerimiento.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance36.BackColor = System.Drawing.Color.Transparent
        Me.dgvRequerimiento.DisplayLayout.Override.CardAreaAppearance = Appearance36
        Appearance37.FontData.BoldAsString = "True"
        Appearance37.FontData.SizeInPoints = 9.0!
        Appearance37.ForeColor = System.Drawing.Color.Navy
        Me.dgvRequerimiento.DisplayLayout.Override.CellAppearance = Appearance37
        Me.dgvRequerimiento.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance38.BackColor = System.Drawing.Color.Navy
        Appearance38.FontData.BoldAsString = "True"
        Appearance38.FontData.ItalicAsString = "False"
        Appearance38.FontData.SizeInPoints = 10.0!
        Appearance38.ForeColor = System.Drawing.Color.White
        Appearance38.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvRequerimiento.DisplayLayout.Override.HeaderAppearance = Appearance38
        Appearance39.TextHAlignAsString = "Center"
        Appearance39.TextVAlignAsString = "Middle"
        Me.dgvRequerimiento.DisplayLayout.Override.RowPreviewAppearance = Appearance39
        Appearance40.BackColor = System.Drawing.Color.Navy
        Appearance40.BorderColor = System.Drawing.Color.White
        Appearance40.FontData.BoldAsString = "True"
        Appearance40.ForeColor = System.Drawing.Color.White
        Appearance40.TextHAlignAsString = "Center"
        Appearance40.TextVAlignAsString = "Middle"
        Me.dgvRequerimiento.DisplayLayout.Override.RowSelectorAppearance = Appearance40
        Me.dgvRequerimiento.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.dgvRequerimiento.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvRequerimiento.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance41.BackColor = System.Drawing.Color.Navy
        Appearance41.ForeColor = System.Drawing.Color.White
        Me.dgvRequerimiento.DisplayLayout.Override.SelectedRowAppearance = Appearance41
        Me.dgvRequerimiento.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvRequerimiento.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvRequerimiento.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvRequerimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvRequerimiento.Location = New System.Drawing.Point(10, 75)
        Me.dgvRequerimiento.Name = "dgvRequerimiento"
        Me.dgvRequerimiento.Size = New System.Drawing.Size(793, 380)
        Me.dgvRequerimiento.TabIndex = 132
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10})
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
        'ChkTodos
        '
        Me.ChkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance42.FontData.SizeInPoints = 9.0!
        Me.ChkTodos.Appearance = Appearance42
        Me.ChkTodos.BackColor = System.Drawing.Color.Transparent
        Me.ChkTodos.BackColorInternal = System.Drawing.Color.Transparent
        Me.ChkTodos.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.ChkTodos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkTodos.Location = New System.Drawing.Point(705, 43)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(98, 20)
        Me.ChkTodos.TabIndex = 78
        Me.ChkTodos.Text = "Marcar Todos"
        '
        'LblMensaje
        '
        Me.LblMensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance43.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance43.ForeColor = System.Drawing.Color.White
        Appearance43.TextHAlignAsString = "Center"
        Appearance43.TextVAlignAsString = "Middle"
        Me.LblMensaje.Appearance = Appearance43
        Me.LblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.Location = New System.Drawing.Point(0, 40)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(812, 25)
        Me.LblMensaje.TabIndex = 133
        Me.LblMensaje.Text = "                    APROBACIÓN DE REQUERIMIENTOS"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.Cia2)
        Me.UltraTabPageControl3.Controls.Add(Me.DgvDetalleRequerimiento)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel9)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(1, 27)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(812, 464)
        '
        'DgvDetalleRequerimiento
        '
        Me.DgvDetalleRequerimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvDetalleRequerimiento.DataSource = Me.UltraDataSource2
        Appearance44.BackColor = System.Drawing.Color.White
        Me.DgvDetalleRequerimiento.DisplayLayout.Appearance = Appearance44
        Me.DgvDetalleRequerimiento.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance30.FontData.BoldAsString = "False"
        Appearance30.FontData.SizeInPoints = 8.0!
        Appearance30.TextHAlignAsString = "Center"
        Appearance30.TextVAlignAsString = "Middle"
        UltraGridColumn11.CellAppearance = Appearance30
        Appearance31.FontData.BoldAsString = "False"
        Appearance31.FontData.SizeInPoints = 8.0!
        UltraGridColumn11.Header.Appearance = Appearance31
        UltraGridColumn11.Header.Caption = "Código"
        UltraGridColumn11.Header.VisiblePosition = 1
        UltraGridColumn11.MaxWidth = 85
        UltraGridColumn11.MinWidth = 85
        UltraGridColumn11.RowLayoutColumnInfo.OriginX = 0
        UltraGridColumn11.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn11.Width = 85
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance32.FontData.BoldAsString = "False"
        Appearance32.FontData.SizeInPoints = 8.0!
        Appearance32.TextHAlignAsString = "Left"
        Appearance32.TextVAlignAsString = "Middle"
        UltraGridColumn12.CellAppearance = Appearance32
        UltraGridColumn12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance33.FontData.BoldAsString = "False"
        Appearance33.FontData.SizeInPoints = 8.0!
        UltraGridColumn12.Header.Appearance = Appearance33
        UltraGridColumn12.Header.Caption = "Descripción"
        UltraGridColumn12.Header.VisiblePosition = 2
        UltraGridColumn12.MinWidth = 300
        UltraGridColumn12.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn12.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn12.Width = 300
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance34.FontData.BoldAsString = "False"
        Appearance34.FontData.SizeInPoints = 8.0!
        Appearance34.TextHAlignAsString = "Center"
        Appearance34.TextVAlignAsString = "Middle"
        UltraGridColumn13.CellAppearance = Appearance34
        UltraGridColumn13.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance47.FontData.BoldAsString = "False"
        Appearance47.FontData.SizeInPoints = 8.0!
        UltraGridColumn13.Header.Appearance = Appearance47
        UltraGridColumn13.Header.VisiblePosition = 3
        UltraGridColumn13.MaxWidth = 45
        UltraGridColumn13.MinWidth = 45
        UltraGridColumn13.RowLayoutColumnInfo.OriginX = 4
        UltraGridColumn13.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn13.Width = 45
        UltraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance48.FontData.BoldAsString = "False"
        Appearance48.FontData.SizeInPoints = 8.0!
        UltraGridColumn14.Header.Appearance = Appearance48
        UltraGridColumn14.Header.VisiblePosition = 0
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.Width = 99
        UltraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance49.FontData.BoldAsString = "False"
        Appearance49.FontData.SizeInPoints = 8.0!
        Appearance49.TextHAlignAsString = "Right"
        Appearance49.TextVAlignAsString = "Middle"
        UltraGridColumn15.CellAppearance = Appearance49
        UltraGridColumn15.Format = "n4"
        Appearance50.FontData.BoldAsString = "False"
        Appearance50.FontData.SizeInPoints = 8.0!
        UltraGridColumn15.Header.Appearance = Appearance50
        UltraGridColumn15.Header.VisiblePosition = 4
        UltraGridColumn15.MinWidth = 85
        UltraGridColumn15.RowLayoutColumnInfo.OriginX = 6
        UltraGridColumn15.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn15.Width = 85
        UltraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance51.FontData.BoldAsString = "False"
        Appearance51.FontData.SizeInPoints = 8.0!
        Appearance51.TextHAlignAsString = "Left"
        Appearance51.TextVAlignAsString = "Middle"
        UltraGridColumn16.CellAppearance = Appearance51
        UltraGridColumn16.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance52.FontData.BoldAsString = "False"
        Appearance52.FontData.SizeInPoints = 8.0!
        UltraGridColumn16.Header.Appearance = Appearance52
        UltraGridColumn16.Header.VisiblePosition = 5
        UltraGridColumn16.MinWidth = 240
        UltraGridColumn16.RowLayoutColumnInfo.OriginX = 8
        UltraGridColumn16.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn16.Width = 240
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance53.FontData.BoldAsString = "False"
        Appearance53.FontData.SizeInPoints = 8.0!
        Appearance53.TextHAlignAsString = "Left"
        Appearance53.TextVAlignAsString = "Middle"
        UltraGridColumn17.CellAppearance = Appearance53
        Appearance55.FontData.BoldAsString = "False"
        Appearance55.FontData.SizeInPoints = 8.0!
        UltraGridColumn17.Header.Appearance = Appearance55
        UltraGridColumn17.Header.VisiblePosition = 6
        UltraGridColumn17.MinWidth = 240
        UltraGridColumn17.RowLayoutColumnInfo.OriginX = 8
        UltraGridColumn17.RowLayoutColumnInfo.OriginY = 3
        UltraGridColumn17.Width = 240
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17})
        UltraGridBand2.UseRowLayout = True
        Me.DgvDetalleRequerimiento.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.DgvDetalleRequerimiento.DisplayLayout.InterBandSpacing = 18
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance78.BackColor = System.Drawing.Color.Transparent
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.CardAreaAppearance = Appearance78
        Appearance79.FontData.BoldAsString = "True"
        Appearance79.FontData.SizeInPoints = 9.0!
        Appearance79.ForeColor = System.Drawing.Color.Navy
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.CellAppearance = Appearance79
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance80.BackColor = System.Drawing.Color.Navy
        Appearance80.FontData.BoldAsString = "True"
        Appearance80.FontData.ItalicAsString = "False"
        Appearance80.FontData.SizeInPoints = 10.0!
        Appearance80.ForeColor = System.Drawing.Color.White
        Appearance80.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.HeaderAppearance = Appearance80
        Appearance81.TextHAlignAsString = "Center"
        Appearance81.TextVAlignAsString = "Middle"
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.RowPreviewAppearance = Appearance81
        Appearance82.BackColor = System.Drawing.Color.Navy
        Appearance82.BorderColor = System.Drawing.Color.White
        Appearance82.FontData.BoldAsString = "True"
        Appearance82.ForeColor = System.Drawing.Color.White
        Appearance82.TextHAlignAsString = "Center"
        Appearance82.TextVAlignAsString = "Middle"
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.RowSelectorAppearance = Appearance82
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.RowSpacingAfter = 4
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance88.BackColor = System.Drawing.Color.Navy
        Appearance88.ForeColor = System.Drawing.Color.White
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.SelectedRowAppearance = Appearance88
        Me.DgvDetalleRequerimiento.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.DgvDetalleRequerimiento.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.DgvDetalleRequerimiento.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.DgvDetalleRequerimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgvDetalleRequerimiento.Location = New System.Drawing.Point(10, 40)
        Me.DgvDetalleRequerimiento.Name = "DgvDetalleRequerimiento"
        Me.DgvDetalleRequerimiento.Size = New System.Drawing.Size(795, 420)
        Me.DgvDetalleRequerimiento.TabIndex = 136
        '
        'UltraDataSource2
        '
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17})
        '
        'UltraLabel9
        '
        Appearance46.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel9.Appearance = Appearance46
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.Location = New System.Drawing.Point(10, 10)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(49, 14)
        Me.UltraLabel9.TabIndex = 134
        Me.UltraLabel9.Text = "Empresa"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Label4)
        Me.UltraTabPageControl2.Controls.Add(Me.Label3)
        Me.UltraTabPageControl2.Controls.Add(Me.LstDet)
        Me.UltraTabPageControl2.Controls.Add(Me.LblDetalleMensaje)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel6)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel5)
        Me.UltraTabPageControl2.Controls.Add(Me.CmbAlmacen)
        Me.UltraTabPageControl2.Controls.Add(Me.Label2)
        Me.UltraTabPageControl2.Controls.Add(Me.TxtUMArticulo)
        Me.UltraTabPageControl2.Controls.Add(Me.TxtDescripcionArticulo)
        Me.UltraTabPageControl2.Controls.Add(Me.TxtCodigoArticulo)
        Me.UltraTabPageControl2.Controls.Add(Me.Label1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(812, 464)
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(760, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = "UM"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(350, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 13)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "D E S C R I P C I Ó N"
        '
        'LstDet
        '
        Me.LstDet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LstDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstDet.FormattingEnabled = True
        Me.LstDet.ItemHeight = 15
        Me.LstDet.Location = New System.Drawing.Point(10, 130)
        Me.LstDet.Name = "LstDet"
        Me.LstDet.Size = New System.Drawing.Size(344, 304)
        Me.LstDet.TabIndex = 142
        '
        'LblDetalleMensaje
        '
        Me.LblDetalleMensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.BackColor = System.Drawing.Color.White
        Me.LblDetalleMensaje.Appearance = Appearance5
        Me.LblDetalleMensaje.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid
        Me.LblDetalleMensaje.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid
        Me.LblDetalleMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDetalleMensaje.Location = New System.Drawing.Point(375, 130)
        Me.LblDetalleMensaje.Name = "LblDetalleMensaje"
        Me.LblDetalleMensaje.Size = New System.Drawing.Size(430, 171)
        Me.LblDetalleMensaje.TabIndex = 141
        '
        'UltraLabel6
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.SizeInPoints = 12.0!
        Appearance4.ForeColor = System.Drawing.Color.Red
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance4
        Me.UltraLabel6.Location = New System.Drawing.Point(375, 335)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(267, 21)
        Me.UltraLabel6.TabIndex = 140
        Me.UltraLabel6.Text = "<<<< Doble Click Para Consultar"
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.SizeInPoints = 12.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance3
        Me.UltraLabel5.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.UltraLabel5.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.UltraLabel5.Location = New System.Drawing.Point(375, 95)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(430, 25)
        Me.UltraLabel5.TabIndex = 138
        Me.UltraLabel5.Text = "Resultados"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.CmbAlmacen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.CmbAlmacen.Location = New System.Drawing.Point(115, 95)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(238, 21)
        Me.CmbAlmacen.TabIndex = 136
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Consultar Almacén"
        '
        'TxtUMArticulo
        '
        Me.TxtUMArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance98.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance98.FontData.BoldAsString = "True"
        Appearance98.FontData.SizeInPoints = 9.0!
        Appearance98.TextHAlignAsString = "Center"
        Appearance98.TextVAlignAsString = "Middle"
        Me.TxtUMArticulo.Appearance = Appearance98
        Me.TxtUMArticulo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.TxtUMArticulo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.TxtUMArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUMArticulo.Location = New System.Drawing.Point(750, 35)
        Me.TxtUMArticulo.Name = "TxtUMArticulo"
        Me.TxtUMArticulo.Size = New System.Drawing.Size(50, 45)
        Me.TxtUMArticulo.TabIndex = 12
        '
        'TxtDescripcionArticulo
        '
        Me.TxtDescripcionArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance139.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance139.FontData.BoldAsString = "True"
        Appearance139.FontData.SizeInPoints = 9.0!
        Appearance139.TextHAlignAsString = "Center"
        Appearance139.TextVAlignAsString = "Middle"
        Me.TxtDescripcionArticulo.Appearance = Appearance139
        Me.TxtDescripcionArticulo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.TxtDescripcionArticulo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.TxtDescripcionArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcionArticulo.Location = New System.Drawing.Point(120, 35)
        Me.TxtDescripcionArticulo.Name = "TxtDescripcionArticulo"
        Me.TxtDescripcionArticulo.Size = New System.Drawing.Size(620, 45)
        Me.TxtDescripcionArticulo.TabIndex = 11
        '
        'TxtCodigoArticulo
        '
        Appearance2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 9.0!
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.TxtCodigoArticulo.Appearance = Appearance2
        Me.TxtCodigoArticulo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.TxtCodigoArticulo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.TxtCodigoArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoArticulo.Location = New System.Drawing.Point(10, 35)
        Me.TxtCodigoArticulo.Name = "TxtCodigoArticulo"
        Me.TxtCodigoArticulo.Size = New System.Drawing.Size(100, 45)
        Me.TxtCodigoArticulo.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CÓDIGO"
        '
        'TabAprobacionRequerimiento
        '
        Me.TabAprobacionRequerimiento.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.TabAprobacionRequerimiento.Controls.Add(Me.UltraTabPageControl1)
        Me.TabAprobacionRequerimiento.Controls.Add(Me.UltraTabPageControl3)
        Me.TabAprobacionRequerimiento.Controls.Add(Me.UltraTabPageControl2)
        Me.TabAprobacionRequerimiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabAprobacionRequerimiento.Location = New System.Drawing.Point(0, 0)
        Me.TabAprobacionRequerimiento.Name = "TabAprobacionRequerimiento"
        Appearance95.FontData.SizeInPoints = 12.0!
        Me.TabAprobacionRequerimiento.SelectedTabAppearance = Appearance95
        Me.TabAprobacionRequerimiento.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.TabAprobacionRequerimiento.Size = New System.Drawing.Size(814, 492)
        Me.TabAprobacionRequerimiento.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon
        Me.TabAprobacionRequerimiento.TabIndex = 1
        Me.TabAprobacionRequerimiento.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab4.Key = "Aprobar"
        UltraTab4.TabPage = Me.UltraTabPageControl1
        UltraTab4.Text = "Aprobación de Requerimiento"
        UltraTab5.Key = "Detalle"
        Appearance97.FontData.SizeInPoints = 12.0!
        UltraTab5.SelectedAppearance = Appearance97
        UltraTab5.TabPage = Me.UltraTabPageControl3
        UltraTab5.Text = "Detalle de Requerimiento"
        UltraTab3.Key = "DatosAuxiliares"
        UltraTab3.TabPage = Me.UltraTabPageControl2
        UltraTab3.Text = "Datos Auxiliares"
        Me.TabAprobacionRequerimiento.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab4, UltraTab5, UltraTab3})
        Me.TabAprobacionRequerimiento.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(812, 464)
        '
        'Cia1
        '
        Me.Cia1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance1.BackColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Appearance = Appearance1
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
        Appearance9.BackColor = System.Drawing.Color.Navy
        Appearance9.BorderColor = System.Drawing.Color.White
        Appearance9.ForeColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Override.RowSelectorAppearance = Appearance9
        Me.Cia1.DisplayLayout.Override.RowSpacingAfter = 4
        Me.Cia1.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance10.BackColor = System.Drawing.Color.Navy
        Appearance10.ForeColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Override.SelectedRowAppearance = Appearance10
        Me.Cia1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.Cia1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.Cia1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cia1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cia1.Location = New System.Drawing.Point(60, 10)
        Me.Cia1.Name = "Cia1"
        Me.Cia1.ReadOnly = True
        Me.Cia1.Size = New System.Drawing.Size(270, 22)
        Me.Cia1.TabIndex = 140
        '
        'Cia2
        '
        Me.Cia2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance13.BackColor = System.Drawing.Color.White
        Me.Cia2.DisplayLayout.Appearance = Appearance13
        Me.Cia2.DisplayLayout.InterBandSpacing = 18
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Me.Cia2.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance35.FontData.BoldAsString = "True"
        Appearance35.FontData.SizeInPoints = 9.0!
        Appearance35.ForeColor = System.Drawing.Color.Navy
        Me.Cia2.DisplayLayout.Override.CellAppearance = Appearance35
        Appearance54.BackColor = System.Drawing.Color.Navy
        Appearance54.FontData.BoldAsString = "True"
        Appearance54.FontData.ItalicAsString = "True"
        Appearance54.FontData.SizeInPoints = 10.0!
        Appearance54.ForeColor = System.Drawing.Color.White
        Appearance54.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.Cia2.DisplayLayout.Override.HeaderAppearance = Appearance54
        Appearance57.BackColor = System.Drawing.Color.Navy
        Appearance57.BorderColor = System.Drawing.Color.White
        Appearance57.ForeColor = System.Drawing.Color.White
        Me.Cia2.DisplayLayout.Override.RowSelectorAppearance = Appearance57
        Me.Cia2.DisplayLayout.Override.RowSpacingAfter = 4
        Me.Cia2.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance65.BackColor = System.Drawing.Color.Navy
        Appearance65.ForeColor = System.Drawing.Color.White
        Me.Cia2.DisplayLayout.Override.SelectedRowAppearance = Appearance65
        Me.Cia2.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.Cia2.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.Cia2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cia2.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cia2.Location = New System.Drawing.Point(60, 10)
        Me.Cia2.Name = "Cia2"
        Me.Cia2.ReadOnly = True
        Me.Cia2.Size = New System.Drawing.Size(270, 22)
        Me.Cia2.TabIndex = 137
        '
        'FrmAprobacionRequerimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 492)
        Me.Controls.Add(Me.TabAprobacionRequerimiento)
        Me.Name = "FrmAprobacionRequerimiento"
        Me.Text = " Aprobación - Requerimiento Compra"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.DtFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRequerimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.DgvDetalleRequerimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.CmbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabAprobacionRequerimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAprobacionRequerimiento.ResumeLayout(False)
        CType(Me.Cia1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cia2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabAprobacionRequerimiento As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DtFin As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents DtInicio As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents RbAnular As System.Windows.Forms.RadioButton
    Friend WithEvents RbAprobacion As System.Windows.Forms.RadioButton
    Friend WithEvents dgvRequerimiento As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ChkTodos As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblMensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraDataSource2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents DgvDetalleRequerimiento As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtUMArticulo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtDescripcionArticulo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TxtCodigoArticulo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents CmbAlmacen As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LstDet As System.Windows.Forms.ListBox
    Friend WithEvents LblDetalleMensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cia1 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Cia2 As Infragistics.Win.UltraWinGrid.UltraCombo
End Class
