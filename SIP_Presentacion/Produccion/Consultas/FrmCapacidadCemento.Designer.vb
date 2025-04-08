<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCapacidadCemento
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
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Dim ValueListItem37 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.btnReporte = New System.Windows.Forms.Button
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbMesDesde = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.txtayo = New System.Windows.Forms.NumericUpDown
        Me.btnrevision = New System.Windows.Forms.Button
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cmbMesDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(769, 358)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.lblmensaje)
        Me.Panel1.Controls.Add(Me.btnReporte)
        Me.Panel1.Controls.Add(Me.UltraLabel16)
        Me.Panel1.Controls.Add(Me.cmbMesDesde)
        Me.Panel1.Controls.Add(Me.UltraLabel6)
        Me.Panel1.Controls.Add(Me.txtayo)
        Me.Panel1.Controls.Add(Me.btnrevision)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(769, 358)
        Me.Panel1.TabIndex = 176
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
        Me.lblmensaje.Location = New System.Drawing.Point(-1, 148)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(770, 39)
        Me.lblmensaje.TabIndex = 166
        Me.lblmensaje.Text = "Procesando Datos..."
        Me.lblmensaje.Visible = False
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.SIP_Presentacion.My.Resources.Resources.page_excel
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(75, 101)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(191, 37)
        Me.btnReporte.TabIndex = 199
        Me.btnReporte.Text = "Generar Reporte"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'UltraLabel16
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel16.Appearance = Appearance2
        Me.UltraLabel16.AutoSize = True
        Me.UltraLabel16.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel16.Location = New System.Drawing.Point(30, 64)
        Me.UltraLabel16.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(26, 17)
        Me.UltraLabel16.TabIndex = 193
        Me.UltraLabel16.Text = "Mes"
        '
        'cmbMesDesde
        '
        Me.cmbMesDesde.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMesDesde.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem26.DataValue = "1"
        ValueListItem26.DisplayText = "ENERO"
        ValueListItem27.DataValue = "2"
        ValueListItem27.DisplayText = "FEBRERO"
        ValueListItem28.DataValue = "3"
        ValueListItem28.DisplayText = "MARZO"
        ValueListItem29.DataValue = "4"
        ValueListItem29.DisplayText = "ABRIL"
        ValueListItem30.DataValue = "5"
        ValueListItem30.DisplayText = "MAYO"
        ValueListItem31.DataValue = "6"
        ValueListItem31.DisplayText = "JUNIO"
        ValueListItem32.DataValue = "7"
        ValueListItem32.DisplayText = "JULIO"
        ValueListItem33.DataValue = "8"
        ValueListItem33.DisplayText = "AGOSTO"
        ValueListItem34.DataValue = "9"
        ValueListItem34.DisplayText = "SETIEMBRE"
        ValueListItem35.DataValue = "10"
        ValueListItem35.DisplayText = "OCTUBRE"
        ValueListItem36.DataValue = "11"
        ValueListItem36.DisplayText = "NOVIEMBRE"
        ValueListItem37.DataValue = "12"
        ValueListItem37.DisplayText = "DICIEMBRE"
        Me.cmbMesDesde.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem26, ValueListItem27, ValueListItem28, ValueListItem29, ValueListItem30, ValueListItem31, ValueListItem32, ValueListItem33, ValueListItem34, ValueListItem35, ValueListItem36, ValueListItem37})
        Me.cmbMesDesde.Location = New System.Drawing.Point(75, 62)
        Me.cmbMesDesde.Name = "cmbMesDesde"
        Me.cmbMesDesde.Size = New System.Drawing.Size(150, 21)
        Me.cmbMesDesde.TabIndex = 192
        '
        'UltraLabel6
        '
        Appearance38.BackColor = System.Drawing.Color.Transparent
        Appearance38.TextHAlignAsString = "Center"
        Appearance38.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance38
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(41, 26)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(24, 14)
        Me.UltraLabel6.TabIndex = 191
        Me.UltraLabel6.Text = "Año"
        '
        'txtayo
        '
        Me.txtayo.Location = New System.Drawing.Point(75, 24)
        Me.txtayo.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtayo.Name = "txtayo"
        Me.txtayo.Size = New System.Drawing.Size(57, 20)
        Me.txtayo.TabIndex = 190
        Me.txtayo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtayo.Value = New Decimal(New Integer() {2017, 0, 0, 0})
        '
        'btnrevision
        '
        Me.btnrevision.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.btnrevision.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrevision.Location = New System.Drawing.Point(565, 375)
        Me.btnrevision.Name = "btnrevision"
        Me.btnrevision.Size = New System.Drawing.Size(191, 37)
        Me.btnrevision.TabIndex = 1
        Me.btnrevision.Text = "Revision de Canteras"
        Me.btnrevision.UseVisualStyleBackColor = True
        Me.btnrevision.Visible = False
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
        Me.Tab1.Size = New System.Drawing.Size(773, 396)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance19.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance19
        Me.Tab1.TabIndex = 14
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
        UltraTab3.Text = "CAPACIDAD DE PRODUCCION DE CEMENTO BLANCO"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(769, 358)
        '
        'FrmCapacidadCemento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 396)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmCapacidadCemento"
        Me.Text = "FrmCapacidadCemento"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmbMesDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbMesDesde As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtayo As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnrevision As System.Windows.Forms.Button
End Class
