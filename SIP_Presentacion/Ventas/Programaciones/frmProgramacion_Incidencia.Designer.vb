<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramacion_Incidencia
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramacion_Incidencia))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUMPEDIDO", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NROVIAJE", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PLACA", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUMGUIA", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTIDADGUIA", 5)
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NROTICKET", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ESTADO", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("REPROGRAMAR", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROD", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PRODUCTO", 10)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ESTADOORI", 11)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CLIENTE", 12)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPROGRAMACION", 13)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("INCIDENCIAS", 14)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(775)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(760)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(284)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(737)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(992)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion13 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion14 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ESTADO", 1)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHAMOVIMIENTO", 2)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HORA", 3)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDCONCEPTO", 4)
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MOTIVO", 5)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OBSERVACION", 6)
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ELIMINAR", 7)
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ORDEN", 8)
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHACREA", 9)
        Dim ColScrollRegion16 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(775)
        Dim ColScrollRegion17 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(355)
        Dim ColScrollRegion18 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(348)
        Dim ColScrollRegion19 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(284)
        Dim ColScrollRegion20 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(737)
        Dim ColScrollRegion21 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion22 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(992)
        Dim ColScrollRegion23 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion24 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion25 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion26 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion27 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion28 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion29 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion30 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion31 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnincidencia = New System.Windows.Forms.Button
        Me.gridConsulta = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.nupviaje = New System.Windows.Forms.NumericUpDown
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.txtproveedor = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcodprov = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.gridDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupviaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtproveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodprov, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(828, 486)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnincidencia)
        Me.Panel1.Controls.Add(Me.gridConsulta)
        Me.Panel1.Controls.Add(Me.nupviaje)
        Me.Panel1.Controls.Add(Me.UltraLabel1)
        Me.Panel1.Controls.Add(Me.txtproveedor)
        Me.Panel1.Controls.Add(Me.txtcodprov)
        Me.Panel1.Controls.Add(Me.UltraLabel7)
        Me.Panel1.Controls.Add(Me.UltraLabel8)
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.gridDetalle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(828, 486)
        Me.Panel1.TabIndex = 176
        '
        'btnincidencia
        '
        Me.btnincidencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnincidencia.Location = New System.Drawing.Point(694, 39)
        Me.btnincidencia.Name = "btnincidencia"
        Me.btnincidencia.Size = New System.Drawing.Size(111, 22)
        Me.btnincidencia.TabIndex = 209
        Me.btnincidencia.Text = "Incidencias"
        Me.btnincidencia.UseVisualStyleBackColor = True
        '
        'gridConsulta
        '
        Me.gridConsulta.AllowDrop = True
        Me.gridConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridConsulta.DisplayLayout.Appearance = Appearance4
        Me.gridConsulta.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance8.Image = CType(resources.GetObject("Appearance8.Image"), Object)
        Appearance8.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance8
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 53
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "N° PEDIDO"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.Width = 46
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "VIAJE"
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn4.Width = 35
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn5.Width = 59
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.Caption = "N° GUIA"
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn6.Width = 62
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance36.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance36
        UltraGridColumn7.Header.Caption = "CANTIDAD"
        UltraGridColumn7.Header.VisiblePosition = 8
        UltraGridColumn7.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn7.Width = 66
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.Caption = "N° BILLETE"
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridColumn8.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn8.Width = 75
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.VisiblePosition = 10
        UltraGridColumn9.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn9.Width = 117
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.VisiblePosition = 11
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.URL
        UltraGridColumn10.Width = 67
        UltraGridColumn11.Header.VisiblePosition = 12
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 82
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.Header.VisiblePosition = 4
        UltraGridColumn12.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn12.Width = 160
        UltraGridColumn13.Header.VisiblePosition = 13
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 94
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn14.Header.VisiblePosition = 3
        UltraGridColumn14.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn14.Width = 190
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 94
        UltraGridColumn16.Header.Caption = ""
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn16.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn16.Width = 24
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16})
        Me.gridConsulta.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridConsulta.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridConsulta.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridConsulta.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridConsulta.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.gridConsulta.DisplayLayout.GroupByBox.Appearance = Appearance10
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridConsulta.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance20
        Me.gridConsulta.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridConsulta.DisplayLayout.GroupByBox.Hidden = True
        Appearance22.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance22.BackColor2 = System.Drawing.SystemColors.Control
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance22.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridConsulta.DisplayLayout.GroupByBox.PromptAppearance = Appearance22
        Me.gridConsulta.DisplayLayout.MaxColScrollRegions = 1
        Me.gridConsulta.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridConsulta.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridConsulta.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridConsulta.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Me.gridConsulta.DisplayLayout.Override.CardAreaAppearance = Appearance27
        Appearance29.BorderColor = System.Drawing.Color.Silver
        Appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridConsulta.DisplayLayout.Override.CellAppearance = Appearance29
        Me.gridConsulta.DisplayLayout.Override.CellPadding = 0
        Me.gridConsulta.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridConsulta.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridConsulta.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridConsulta.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance30.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance30.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridConsulta.DisplayLayout.Override.FilterRowAppearance = Appearance30
        Me.gridConsulta.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridConsulta.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridConsulta.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance31.BackColor = System.Drawing.SystemColors.Control
        Appearance31.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance31.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.BorderColor = System.Drawing.SystemColors.Window
        Me.gridConsulta.DisplayLayout.Override.GroupByRowAppearance = Appearance31
        Appearance32.FontData.Name = "Arial Narrow"
        Appearance32.FontData.SizeInPoints = 10.0!
        Appearance32.TextHAlignAsString = "Left"
        Me.gridConsulta.DisplayLayout.Override.HeaderAppearance = Appearance32
        Me.gridConsulta.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridConsulta.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridConsulta.DisplayLayout.Override.MinRowHeight = 24
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Appearance33.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance33.TextVAlignAsString = "Middle"
        Me.gridConsulta.DisplayLayout.Override.RowAppearance = Appearance33
        Me.gridConsulta.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridConsulta.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridConsulta.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance35.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridConsulta.DisplayLayout.Override.TemplateAddRowAppearance = Appearance35
        Me.gridConsulta.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridConsulta.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridConsulta.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridConsulta.Location = New System.Drawing.Point(29, 66)
        Me.gridConsulta.Name = "gridConsulta"
        Me.gridConsulta.Size = New System.Drawing.Size(777, 234)
        Me.gridConsulta.TabIndex = 171
        Me.gridConsulta.Text = "UltraGrid1"
        '
        'nupviaje
        '
        Me.nupviaje.Location = New System.Drawing.Point(240, 39)
        Me.nupviaje.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nupviaje.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupviaje.Name = "nupviaje"
        Me.nupviaje.ReadOnly = True
        Me.nupviaje.Size = New System.Drawing.Size(60, 20)
        Me.nupviaje.TabIndex = 207
        Me.nupviaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nupviaje.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupviaje.Visible = False
        '
        'UltraLabel1
        '
        Appearance58.BackColor = System.Drawing.Color.Transparent
        Appearance58.TextHAlignAsString = "Center"
        Appearance58.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance58
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(180, 42)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(54, 14)
        Me.UltraLabel1.TabIndex = 206
        Me.UltraLabel1.Text = "Nro. Viaje"
        Me.UltraLabel1.Visible = False
        '
        'txtproveedor
        '
        Appearance16.FontData.BoldAsString = "False"
        Appearance16.ForeColor = System.Drawing.Color.Black
        Appearance16.TextHAlignAsString = "Left"
        Appearance16.TextVAlignAsString = "Middle"
        Me.txtproveedor.Appearance = Appearance16
        Me.txtproveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtproveedor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtproveedor.Location = New System.Drawing.Point(180, 8)
        Me.txtproveedor.MaxLength = 20
        Me.txtproveedor.Name = "txtproveedor"
        Me.txtproveedor.ReadOnly = True
        Me.txtproveedor.Size = New System.Drawing.Size(273, 21)
        Me.txtproveedor.TabIndex = 203
        Me.txtproveedor.TabStop = False
        '
        'txtcodprov
        '
        Appearance6.FontData.BoldAsString = "False"
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.TextHAlignAsString = "Left"
        Appearance6.TextVAlignAsString = "Middle"
        Me.txtcodprov.Appearance = Appearance6
        Me.txtcodprov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodprov.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodprov.Location = New System.Drawing.Point(72, 8)
        Me.txtcodprov.MaxLength = 8
        Me.txtcodprov.Name = "txtcodprov"
        Me.txtcodprov.Size = New System.Drawing.Size(102, 21)
        Me.txtcodprov.TabIndex = 204
        '
        'UltraLabel7
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Right"
        Me.UltraLabel7.Appearance = Appearance7
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel7.Location = New System.Drawing.Point(5, 9)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(59, 17)
        Me.UltraLabel7.TabIndex = 205
        Me.UltraLabel7.Text = "& Proveedor"
        '
        'UltraLabel8
        '
        Appearance28.BackColor = System.Drawing.Color.Transparent
        Appearance28.TextHAlignAsString = "Center"
        Appearance28.TextVAlignAsString = "Middle"
        Me.UltraLabel8.Appearance = Appearance28
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Location = New System.Drawing.Point(29, 42)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(36, 14)
        Me.UltraLabel8.TabIndex = 175
        Me.UltraLabel8.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.AutoSize = False
        Me.dtpFecha.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpFecha.Location = New System.Drawing.Point(72, 39)
        Me.dtpFecha.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpFecha.Size = New System.Drawing.Size(103, 18)
        Me.dtpFecha.TabIndex = 174
        Me.dtpFecha.TabStop = False
        Me.dtpFecha.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-1, 307)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(829, 18)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "       DETALLE DE INCIDENCIAS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gridDetalle
        '
        Me.gridDetalle.AllowDrop = True
        Me.gridDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridDetalle.DisplayLayout.Appearance = Appearance2
        Me.gridDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Appearance5.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn17.Header.Appearance = Appearance5
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
        UltraGridColumn18.Width = 108
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn19.Header.VisiblePosition = 2
        UltraGridColumn19.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn19.Width = 129
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn20.Header.Caption = "FECHA INCIDENCIA"
        UltraGridColumn20.Header.VisiblePosition = 3
        UltraGridColumn20.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn20.Width = 128
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn21.Header.VisiblePosition = 4
        UltraGridColumn21.MaskInput = ""
        UltraGridColumn21.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn21.Width = 110
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn22.Header.VisiblePosition = 5
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn22.Width = 125
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn23.Header.VisiblePosition = 6
        UltraGridColumn23.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn23.Width = 127
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn24.Header.VisiblePosition = 7
        UltraGridColumn24.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn24.Width = 145
        UltraGridColumn25.Header.VisiblePosition = 8
        UltraGridColumn25.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.URL
        UltraGridColumn25.Width = 98
        UltraGridColumn26.Header.VisiblePosition = 9
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.Width = 95
        UltraGridColumn27.Header.VisiblePosition = 10
        UltraGridColumn27.Hidden = True
        UltraGridColumn27.Width = 95
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27})
        Me.gridDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion16)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion17)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion18)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion19)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion20)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion21)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion22)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion23)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion24)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion25)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion26)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion27)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion28)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion29)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion30)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion31)
        Me.gridDetalle.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance12.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.GroupByBox.Appearance = Appearance12
        Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance13
        Me.gridDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDetalle.DisplayLayout.GroupByBox.Hidden = True
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance14.BackColor2 = System.Drawing.SystemColors.Control
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance14
        Me.gridDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.gridDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance15
        Appearance17.BorderColor = System.Drawing.Color.Silver
        Appearance17.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridDetalle.DisplayLayout.Override.CellAppearance = Appearance17
        Me.gridDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridDetalle.DisplayLayout.Override.CellPadding = 0
        Me.gridDetalle.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridDetalle.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance18.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridDetalle.DisplayLayout.Override.FilterRowAppearance = Appearance18
        Me.gridDetalle.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridDetalle.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance19.BackColor = System.Drawing.SystemColors.Control
        Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance19.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance19
        Appearance21.FontData.Name = "Arial Narrow"
        Appearance21.FontData.SizeInPoints = 10.0!
        Appearance21.TextHAlignAsString = "Left"
        Me.gridDetalle.DisplayLayout.Override.HeaderAppearance = Appearance21
        Me.gridDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridDetalle.DisplayLayout.Override.MinRowHeight = 24
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance23.TextVAlignAsString = "Middle"
        Me.gridDetalle.DisplayLayout.Override.RowAppearance = Appearance23
        Me.gridDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridDetalle.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridDetalle.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance26.BackColor = System.Drawing.Color.Transparent
        Appearance26.ForeColor = System.Drawing.Color.Black
        Me.gridDetalle.DisplayLayout.Override.SelectedRowAppearance = Appearance26
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance25
        Me.gridDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridDetalle.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDetalle.Location = New System.Drawing.Point(29, 333)
        Me.gridDetalle.Name = "gridDetalle"
        Me.gridDetalle.Size = New System.Drawing.Size(777, 145)
        Me.gridDetalle.TabIndex = 208
        Me.gridDetalle.Text = "UltraGrid1"
        '
        'Tab1
        '
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial Narrow"
        Appearance3.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance3
        Appearance1.FontData.Name = "Arial Narrow"
        Appearance1.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance1
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(832, 524)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance11
        Me.Tab1.TabIndex = 7
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance24.Cursor = System.Windows.Forms.Cursors.Default
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.FontData.Name = "Arial Narrow"
        Appearance24.FontData.SizeInPoints = 16.0!
        UltraTab3.ActiveAppearance = Appearance24
        Appearance9.FontData.Name = "Arial Narrow"
        Appearance9.FontData.SizeInPoints = 10.0!
        UltraTab3.Appearance = Appearance9
        UltraTab3.Key = "T01"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "REGISTRO DE INCIDENCIAS"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(828, 486)
        '
        'frmProgramacion_Incidencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 524)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "frmProgramacion_Incidencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmProgramacion_Incidencia"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gridConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupviaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtproveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodprov, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gridConsulta As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents nupviaje As System.Windows.Forms.NumericUpDown
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtproveedor As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcodprov As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents btnincidencia As System.Windows.Forms.Button
    Friend WithEvents Source2 As System.Windows.Forms.BindingSource
End Class
