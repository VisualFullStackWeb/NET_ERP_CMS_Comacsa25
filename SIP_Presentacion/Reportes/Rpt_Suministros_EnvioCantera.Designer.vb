<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Suministros_EnvioCantera
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
        Me.ReporteListarProductos = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'ReporteListarProductos
        '
        Me.ReporteListarProductos.ActiveViewIndex = -1
        Me.ReporteListarProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ReporteListarProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReporteListarProductos.Location = New System.Drawing.Point(0, 0)
        Me.ReporteListarProductos.Name = "ReporteListarProductos"
        Me.ReporteListarProductos.SelectionFormula = ""
        Me.ReporteListarProductos.Size = New System.Drawing.Size(707, 540)
        Me.ReporteListarProductos.TabIndex = 0
        Me.ReporteListarProductos.ViewTimeSelectionFormula = ""
        '
        'RptListarProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 540)
        Me.Controls.Add(Me.ReporteListarProductos)
        Me.Name = "RptListarProducto"
        Me.Text = "RptListarProducto"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReporteListarProductos As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
