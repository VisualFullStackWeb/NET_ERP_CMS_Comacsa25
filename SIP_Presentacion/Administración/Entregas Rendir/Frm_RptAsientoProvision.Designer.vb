<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RptAsientoProvision
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
        Me.ReporteReintegro = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'ReporteReintegro
        '
        Me.ReporteReintegro.ActiveViewIndex = -1
        Me.ReporteReintegro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ReporteReintegro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReporteReintegro.Location = New System.Drawing.Point(0, 0)
        Me.ReporteReintegro.Name = "ReporteReintegro"
        Me.ReporteReintegro.ShowCloseButton = False
        Me.ReporteReintegro.ShowGroupTreeButton = False
        Me.ReporteReintegro.ShowParameterPanelButton = False
        Me.ReporteReintegro.ShowRefreshButton = False
        Me.ReporteReintegro.ShowTextSearchButton = False
        Me.ReporteReintegro.Size = New System.Drawing.Size(578, 426)
        Me.ReporteReintegro.TabIndex = 4
        Me.ReporteReintegro.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Frm_RptAsientoProvision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 426)
        Me.Controls.Add(Me.ReporteReintegro)
        Me.Name = "Frm_RptAsientoProvision"
        Me.Text = "Frm_RptAsientoProvision"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReporteReintegro As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
