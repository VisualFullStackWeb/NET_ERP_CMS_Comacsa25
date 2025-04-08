<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitud
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
        Me.ReporteSolicitud = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'ReporteSolicitud
        '
        Me.ReporteSolicitud.ActiveViewIndex = -1
        Me.ReporteSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ReporteSolicitud.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReporteSolicitud.Location = New System.Drawing.Point(0, 0)
        Me.ReporteSolicitud.Name = "ReporteSolicitud"
        Me.ReporteSolicitud.ShowCloseButton = False
        Me.ReporteSolicitud.ShowGroupTreeButton = False
        Me.ReporteSolicitud.ShowParameterPanelButton = False
        Me.ReporteSolicitud.ShowRefreshButton = False
        Me.ReporteSolicitud.ShowTextSearchButton = False
        Me.ReporteSolicitud.Size = New System.Drawing.Size(550, 462)
        Me.ReporteSolicitud.TabIndex = 0
        Me.ReporteSolicitud.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmSolicitud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 462)
        Me.Controls.Add(Me.ReporteSolicitud)
        Me.KeyPreview = True
        Me.Name = "FrmSolicitud"
        Me.Text = "Solicitud"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReporteSolicitud As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
