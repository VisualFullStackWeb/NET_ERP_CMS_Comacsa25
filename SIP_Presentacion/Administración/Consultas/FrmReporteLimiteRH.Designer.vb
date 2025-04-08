<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporteLimiteRH
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
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbMes = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txtAño = New System.Windows.Forms.NumericUpDown
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.Tab1.Size = New System.Drawing.Size(833, 443)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance13
        Me.Tab1.TabIndex = 11
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
        UltraTab6.Text = "Reporte de Limite de RH Liquidados"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab6})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(829, 405)
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.lblmensaje)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel15)
        Me.UltraTabPageControl2.Controls.Add(Me.cmbMes)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl2.Controls.Add(Me.txtAño)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(829, 405)
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
        Me.lblmensaje.Location = New System.Drawing.Point(0, 159)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(832, 39)
        Me.lblmensaje.TabIndex = 163
        Me.lblmensaje.Text = "Procesando Datos..."
        Me.lblmensaje.Visible = False
        '
        'UltraLabel15
        '
        Appearance114.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel15.Appearance = Appearance114
        Me.UltraLabel15.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel15.Location = New System.Drawing.Point(236, 31)
        Me.UltraLabel15.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(27, 16)
        Me.UltraLabel15.TabIndex = 164
        Me.UltraLabel15.Text = "Año"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMes.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
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
        Me.cmbMes.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3, ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7, ValueListItem8, ValueListItem9, ValueListItem10, ValueListItem11, ValueListItem12})
        Me.cmbMes.Location = New System.Drawing.Point(67, 29)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(150, 21)
        Me.cmbMes.TabIndex = 161
        '
        'UltraLabel3
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Appearance16.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance16
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(29, 30)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(35, 17)
        Me.UltraLabel3.TabIndex = 162
        Me.UltraLabel3.Text = "MES :"
        '
        'txtAño
        '
        Me.txtAño.Location = New System.Drawing.Point(269, 30)
        Me.txtAño.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtAño.Name = "txtAño"
        Me.txtAño.Size = New System.Drawing.Size(84, 20)
        Me.txtAño.TabIndex = 163
        Me.txtAño.Value = New Decimal(New Integer() {2017, 0, 0, 0})
        '
        'FrmReporteLimiteRH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 443)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmReporteLimiteRH"
        Me.Text = "FrmReporteLimiteRH"
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbMes As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAño As System.Windows.Forms.NumericUpDown
End Class
