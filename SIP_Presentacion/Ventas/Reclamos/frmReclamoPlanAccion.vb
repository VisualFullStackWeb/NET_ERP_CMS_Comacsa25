Imports SIP_Entidad

Public Class frmReclamoPlanAccion

    Public LstCausasOrigen As List(Of ETReclamoCausa)
    Public LstParticipantes As List(Of ETReclamoPersona)
    Public oPlanAccion As New ETReclamoPlanAccion

    Private Sub cboCausaPlanAccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCausaPlanAccion.SelectedIndexChanged, cboCausaPorque.SelectedIndexChanged

        Dim oReclamoCausa As ETReclamoCausa = LstCausasOrigen.FirstOrDefault(Function(p) p.Item = cboCausaPlanAccion.SelectedValue)

        Dim maxItem As Integer = 0

        If oReclamoCausa IsNot Nothing Then
            If oReclamoCausa.Detalles.Count > 0 Then
                maxItem = (oReclamoCausa.Detalles.Max(Function(p As ETReclamoCausaDetalle) p.Item))
            End If
        End If

        cboCausaPorque.DisplayMember = "Descripcion"
        cboCausaPorque.ValueMember = "Item"
        cboCausaPorque.DataSource = oReclamoCausa.Detalles.FindAll(Function(p) p.Item = maxItem)

    End Sub

    Private Sub frmReclamoPlanAccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _ReclamoCausa As New ETReclamoCausa
        _ReclamoCausa.Item = 0
        _ReclamoCausa.CausaOrigen = "-- Seleccione --"

        LstCausasOrigen.Insert(0, _ReclamoCausa)

        cboCausaPlanAccion.DisplayMember = "CausaOrigen"
        cboCausaPlanAccion.ValueMember = "Item"
        cboCausaPlanAccion.DataSource = LstCausasOrigen

        Dim _Persona As New ETReclamoPersona
        _Persona.Codigo = "0"
        _Persona.Nombre = "-- Seleccione --"

        LstParticipantes.Insert(0, _Persona)

        cboParticipantes.DisplayMember = "Nombre"
        cboParticipantes.ValueMember = "Codigo"
        cboParticipantes.DataSource = LstParticipantes

        dtpPlanFechaPropuesta.Value = DateTime.Now.Date

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If cboParticipantes.SelectedValue = "0" Then
            MsgBox("Seleccione un participante")
            Return
        End If
        If cboCausaPlanAccion.SelectedValue = "0" Then
            MsgBox("Seleccione una causa")
            Return
        End If
        If cboCausaPorque.SelectedValue = "0" Then
            MsgBox("Seleccione un motivo")
            Return
        End If
        If txtAccion.Text.Trim.Length() = 0 Then
            MsgBox("Ingrese la acción a realizar")
            Return
        End If

        oPlanAccion = New ETReclamoPlanAccion

        Dim oCausa As ETReclamoCausa = TryCast(cboCausaPlanAccion.SelectedItem, ETReclamoCausa)
        If oCausa IsNot Nothing Then
            oPlanAccion.ItemCausa = oCausa.Item
        Else
            oPlanAccion.ItemCausa = cboCausaPlanAccion.SelectedValue
        End If

        Dim oCausaDetalle As ETReclamoCausaDetalle = TryCast(cboCausaPorque.SelectedItem, ETReclamoCausaDetalle)
        If oCausaDetalle IsNot Nothing Then
            oPlanAccion.Item = oCausaDetalle.Item
        Else
            oPlanAccion.Item = cboCausaPorque.SelectedValue
        End If

        Dim oParticipante As ETReclamoPersona = TryCast(cboParticipantes.SelectedItem, ETReclamoPersona)
        If oParticipante IsNot Nothing Then
            oPlanAccion.ETEncargado.Codigo = oParticipante.Codigo
            oPlanAccion.ETEncargado.Nombre = oParticipante.Nombre
            oPlanAccion.ETEncargado.Correo = oParticipante.Correo
        Else
            oPlanAccion.ETEncargado.Codigo = cboParticipantes.SelectedValue
            oPlanAccion.ETEncargado.Nombre = cboParticipantes.SelectedText
        End If

        oPlanAccion.AccionPorRealizar = txtAccion.Text.Trim
        oPlanAccion.FechaPropuesta = dtpPlanFechaPropuesta.Value
        oPlanAccion.Notifica = False

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub cboParticipantes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboParticipantes.SelectedIndexChanged
        'If cboParticipantes.SelectedValue IsNot Nothing AndAlso cboParticipantes.SelectedValue = "0" Then
        '    txtEncargadoOpcional.Visible = True
        '    lblPlanEncargado.Visible = True
        'End If
    End Sub
End Class