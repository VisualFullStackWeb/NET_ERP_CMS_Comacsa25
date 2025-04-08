<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptLiquidacion
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
        Me.ReporteLiquidacion = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'ReporteLiquidacion
        '
        Me.ReporteLiquidacion.ActiveViewIndex = -1
        Me.ReporteLiquidacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ReporteLiquidacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReporteLiquidacion.Location = New System.Drawing.Point(0, 0)
        Me.ReporteLiquidacion.Name = "ReporteLiquidacion"
        Me.ReporteLiquidacion.ShowCloseButton = False
        Me.ReporteLiquidacion.ShowGroupTreeButton = False
        Me.ReporteLiquidacion.ShowParameterPanelButton = False
        Me.ReporteLiquidacion.ShowRefreshButton = False
        Me.ReporteLiquidacion.ShowTextSearchButton = False
        Me.ReporteLiquidacion.Size = New System.Drawing.Size(550, 462)
        Me.ReporteLiquidacion.TabIndex = 1
        Me.ReporteLiquidacion.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmRptLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 462)
        Me.Controls.Add(Me.ReporteLiquidacion)
        Me.KeyPreview = True
        Me.Name = "FrmRptLiquidacion"
        Me.Text = "Liquidación"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReporteLiquidacion As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
