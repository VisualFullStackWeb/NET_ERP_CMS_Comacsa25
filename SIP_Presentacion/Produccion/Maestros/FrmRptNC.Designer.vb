<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptNC
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
        Me.ReporteProductoNC = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'ReporteProductoNC
        '
        Me.ReporteProductoNC.ActiveViewIndex = -1
        Me.ReporteProductoNC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ReporteProductoNC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReporteProductoNC.Location = New System.Drawing.Point(0, 0)
        Me.ReporteProductoNC.Name = "ReporteProductoNC"
        Me.ReporteProductoNC.ShowCloseButton = False
        Me.ReporteProductoNC.ShowGroupTreeButton = False
        Me.ReporteProductoNC.ShowParameterPanelButton = False
        Me.ReporteProductoNC.ShowRefreshButton = False
        Me.ReporteProductoNC.ShowTextSearchButton = False
        Me.ReporteProductoNC.Size = New System.Drawing.Size(550, 462)
        Me.ReporteProductoNC.TabIndex = 3
        Me.ReporteProductoNC.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmRptNC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 462)
        Me.Controls.Add(Me.ReporteProductoNC)
        Me.Name = "FrmRptNC"
        Me.Text = "FrmRptNC"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReporteProductoNC As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
