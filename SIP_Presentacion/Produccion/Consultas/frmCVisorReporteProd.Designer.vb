<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCVisorReporteProd
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
        Me.CRView = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRView
        '
        Me.CRView.ActiveViewIndex = -1
        Me.CRView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRView.Location = New System.Drawing.Point(0, 0)
        Me.CRView.Name = "CRView"
        Me.CRView.ShowGroupTreeButton = False
        Me.CRView.ShowParameterPanelButton = False
        Me.CRView.ShowTextSearchButton = False
        Me.CRView.Size = New System.Drawing.Size(468, 395)
        Me.CRView.TabIndex = 1
        Me.CRView.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmCVisorReporteProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 395)
        Me.Controls.Add(Me.CRView)
        Me.Name = "frmCVisorReporteProd"
        Me.Text = "frmCVisorReporteProd"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRView As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
