<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptOperaciones
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
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grupo = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.dtfin = New System.Windows.Forms.DateTimePicker
        Me.dtinicio = New System.Windows.Forms.DateTimePicker
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.Grupo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grupo.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Grupo)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(2, 35)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(801, 320)
        '
        'Grupo
        '
        Me.Grupo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance15.BackColor = System.Drawing.Color.White
        Me.Grupo.ContentAreaAppearance = Appearance15
        Me.Grupo.Controls.Add(Me.UltraLabel3)
        Me.Grupo.Controls.Add(Me.UltraGroupBox1)
        Appearance17.FontData.BoldAsString = "True"
        Appearance17.FontData.Name = "Arial Narrow"
        Appearance17.FontData.SizeInPoints = 10.0!
        Me.Grupo.HeaderAppearance = Appearance17
        Me.Grupo.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.Grupo.Location = New System.Drawing.Point(3, 3)
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Size = New System.Drawing.Size(789, 313)
        Me.Grupo.TabIndex = 0
        Me.Grupo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'UltraLabel3
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Appearance16.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance16
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(25, 64)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(44, 17)
        Me.UltraLabel3.TabIndex = 2
        Me.UltraLabel3.Text = "Desde"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance7
        Me.UltraGroupBox1.Controls.Add(Me.lblmensaje)
        Me.UltraGroupBox1.Controls.Add(Me.dtfin)
        Me.UltraGroupBox1.Controls.Add(Me.dtinicio)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel15)
        Appearance12.FontData.BoldAsString = "True"
        Appearance12.FontData.Name = "Arial Narrow"
        Appearance12.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox1.HeaderAppearance = Appearance12
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox1.Location = New System.Drawing.Point(7, 26)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(775, 163)
        Me.UltraGroupBox1.TabIndex = 7
        Me.UltraGroupBox1.Text = "Reporte de Operaciones"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
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
        Me.lblmensaje.Location = New System.Drawing.Point(-7, 97)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(805, 39)
        Me.lblmensaje.TabIndex = 157
        Me.lblmensaje.Text = "Procesando Datos..."
        Me.lblmensaje.Visible = False
        '
        'dtfin
        '
        Me.dtfin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfin.Location = New System.Drawing.Point(138, 58)
        Me.dtfin.Name = "dtfin"
        Me.dtfin.Size = New System.Drawing.Size(104, 20)
        Me.dtfin.TabIndex = 162
        '
        'dtinicio
        '
        Me.dtinicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtinicio.Location = New System.Drawing.Point(17, 58)
        Me.dtinicio.Name = "dtinicio"
        Me.dtinicio.Size = New System.Drawing.Size(104, 20)
        Me.dtinicio.TabIndex = 161
        '
        'UltraLabel15
        '
        Appearance114.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel15.Appearance = Appearance114
        Me.UltraLabel15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel15.Location = New System.Drawing.Point(138, 40)
        Me.UltraLabel15.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(47, 16)
        Me.UltraLabel15.TabIndex = 160
        Me.UltraLabel15.Text = "Hasta"
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
        Me.Tab1.Size = New System.Drawing.Size(805, 357)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance13
        Me.Tab1.TabIndex = 6
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
        UltraTab6.Text = "Registro de Operaciones"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab6})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(801, 320)
        '
        'frmRptOperaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 357)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "frmRptOperaciones"
        Me.Text = "frmRptOperaciones"
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.Grupo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grupo.ResumeLayout(False)
        Me.Grupo.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Grupo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dtinicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtfin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
End Class
