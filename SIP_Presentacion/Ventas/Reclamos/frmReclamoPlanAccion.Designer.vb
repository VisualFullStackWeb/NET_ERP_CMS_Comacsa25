<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReclamoPlanAccion
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel23 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpPlanFechaPropuesta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.btnSalir = New Infragistics.Win.Misc.UltraButton
        Me.btnGuardar = New Infragistics.Win.Misc.UltraButton
        Me.cboParticipantes = New System.Windows.Forms.ComboBox
        Me.UltraLabel33 = New Infragistics.Win.Misc.UltraLabel
        Me.lblPlanEncargado = New Infragistics.Win.Misc.UltraLabel
        Me.txtAccion = New System.Windows.Forms.TextBox
        Me.UltraLabel32 = New Infragistics.Win.Misc.UltraLabel
        Me.txtEncargadoOpcional = New System.Windows.Forms.TextBox
        Me.cboCausaPorque = New System.Windows.Forms.ComboBox
        Me.cboCausaPlanAccion = New System.Windows.Forms.ComboBox
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel29 = New Infragistics.Win.Misc.UltraLabel
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.dtpPlanFechaPropuesta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel23)
        Me.UltraGroupBox1.Controls.Add(Me.dtpPlanFechaPropuesta)
        Me.UltraGroupBox1.Controls.Add(Me.btnSalir)
        Me.UltraGroupBox1.Controls.Add(Me.btnGuardar)
        Me.UltraGroupBox1.Controls.Add(Me.cboParticipantes)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel33)
        Me.UltraGroupBox1.Controls.Add(Me.lblPlanEncargado)
        Me.UltraGroupBox1.Controls.Add(Me.txtAccion)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel32)
        Me.UltraGroupBox1.Controls.Add(Me.txtEncargadoOpcional)
        Me.UltraGroupBox1.Controls.Add(Me.cboCausaPorque)
        Me.UltraGroupBox1.Controls.Add(Me.cboCausaPlanAccion)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel29)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(678, 223)
        Me.UltraGroupBox1.TabIndex = 0
        '
        'UltraLabel23
        '
        Me.UltraLabel23.Location = New System.Drawing.Point(6, 151)
        Me.UltraLabel23.Name = "UltraLabel23"
        Me.UltraLabel23.Size = New System.Drawing.Size(73, 26)
        Me.UltraLabel23.TabIndex = 12
        Me.UltraLabel23.Text = "Fecha Propuesta"
        '
        'dtpPlanFechaPropuesta
        '
        Me.dtpPlanFechaPropuesta.DateTime = New Date(2018, 7, 17, 0, 0, 0, 0)
        Me.dtpPlanFechaPropuesta.Location = New System.Drawing.Point(82, 156)
        Me.dtpPlanFechaPropuesta.MaskInput = "{date} {time}"
        Me.dtpPlanFechaPropuesta.Name = "dtpPlanFechaPropuesta"
        Me.dtpPlanFechaPropuesta.Size = New System.Drawing.Size(117, 21)
        Me.dtpPlanFechaPropuesta.TabIndex = 13
        Me.dtpPlanFechaPropuesta.Value = New Date(2018, 7, 17, 0, 0, 0, 0)
        '
        'btnSalir
        '
        Appearance1.Image = Global.SIP_Presentacion.My.Resources.Resources._Exit
        Me.btnSalir.Appearance = Appearance1
        Me.btnSalir.Location = New System.Drawing.Point(568, 177)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(104, 40)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "Salir"
        '
        'btnGuardar
        '
        Appearance2.Image = Global.SIP_Presentacion.My.Resources.Resources.guardar2
        Me.btnGuardar.Appearance = Appearance2
        Me.btnGuardar.Location = New System.Drawing.Point(458, 177)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(104, 40)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.Text = "Guardar"
        '
        'cboParticipantes
        '
        Me.cboParticipantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParticipantes.FormattingEnabled = True
        Me.cboParticipantes.Location = New System.Drawing.Point(82, 128)
        Me.cboParticipantes.Name = "cboParticipantes"
        Me.cboParticipantes.Size = New System.Drawing.Size(313, 21)
        Me.cboParticipantes.TabIndex = 10
        '
        'UltraLabel33
        '
        Me.UltraLabel33.Location = New System.Drawing.Point(6, 64)
        Me.UltraLabel33.Name = "UltraLabel33"
        Me.UltraLabel33.Size = New System.Drawing.Size(60, 58)
        Me.UltraLabel33.TabIndex = 8
        Me.UltraLabel33.Text = "Accion a Realizar:"
        '
        'lblPlanEncargado
        '
        Me.lblPlanEncargado.Location = New System.Drawing.Point(401, 132)
        Me.lblPlanEncargado.Name = "lblPlanEncargado"
        Me.lblPlanEncargado.Size = New System.Drawing.Size(65, 18)
        Me.lblPlanEncargado.TabIndex = 8
        Me.lblPlanEncargado.Text = "Especificar"
        Me.lblPlanEncargado.Visible = False
        '
        'txtAccion
        '
        Me.txtAccion.Location = New System.Drawing.Point(82, 61)
        Me.txtAccion.Multiline = True
        Me.txtAccion.Name = "txtAccion"
        Me.txtAccion.Size = New System.Drawing.Size(579, 61)
        Me.txtAccion.TabIndex = 9
        '
        'UltraLabel32
        '
        Me.UltraLabel32.Location = New System.Drawing.Point(6, 130)
        Me.UltraLabel32.Name = "UltraLabel32"
        Me.UltraLabel32.Size = New System.Drawing.Size(73, 15)
        Me.UltraLabel32.TabIndex = 7
        Me.UltraLabel32.Text = "Encargado:"
        '
        'txtEncargadoOpcional
        '
        Me.txtEncargadoOpcional.Location = New System.Drawing.Point(473, 129)
        Me.txtEncargadoOpcional.Name = "txtEncargadoOpcional"
        Me.txtEncargadoOpcional.Size = New System.Drawing.Size(188, 20)
        Me.txtEncargadoOpcional.TabIndex = 9
        Me.txtEncargadoOpcional.Visible = False
        '
        'cboCausaPorque
        '
        Me.cboCausaPorque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCausaPorque.FormattingEnabled = True
        Me.cboCausaPorque.Location = New System.Drawing.Point(82, 35)
        Me.cboCausaPorque.Name = "cboCausaPorque"
        Me.cboCausaPorque.Size = New System.Drawing.Size(579, 21)
        Me.cboCausaPorque.TabIndex = 7
        '
        'cboCausaPlanAccion
        '
        Me.cboCausaPlanAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCausaPlanAccion.FormattingEnabled = True
        Me.cboCausaPlanAccion.Location = New System.Drawing.Point(105, 9)
        Me.cboCausaPlanAccion.Name = "cboCausaPlanAccion"
        Me.cboCausaPlanAccion.Size = New System.Drawing.Size(556, 21)
        Me.cboCausaPlanAccion.TabIndex = 7
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(6, 38)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(81, 20)
        Me.UltraLabel1.TabIndex = 2
        Me.UltraLabel1.Text = "Causa Raiz:"
        '
        'UltraLabel29
        '
        Me.UltraLabel29.Location = New System.Drawing.Point(6, 12)
        Me.UltraLabel29.Name = "UltraLabel29"
        Me.UltraLabel29.Size = New System.Drawing.Size(93, 20)
        Me.UltraLabel29.TabIndex = 2
        Me.UltraLabel29.Text = "Causa Inmediata"
        '
        'frmReclamoPlanAccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 262)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "frmReclamoPlanAccion"
        Me.Text = "Agregar Plan de Acción"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.dtpPlanFechaPropuesta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel29 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboCausaPlanAccion As System.Windows.Forms.ComboBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboCausaPorque As System.Windows.Forms.ComboBox
    Friend WithEvents UltraLabel33 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAccion As System.Windows.Forms.TextBox
    Friend WithEvents cboParticipantes As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlanEncargado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel32 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtEncargadoOpcional As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSalir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel23 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpPlanFechaPropuesta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
End Class
