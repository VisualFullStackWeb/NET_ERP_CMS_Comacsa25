Imports SIP_Entidad
Imports SIP_Negocio

Public Class frmAgregarFactura
    Public mes As String
    Public ayo As String
    Dim dtFactura As DataTable

    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Anticipo As List(Of ETContratista) = Nothing
    Dim dtDatos As New DataTable

    Private Sub frmAgregarFactura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFactura = New DataTable
        dtfecha.Value = "01/" & mes & "/" & ayo
        dtpreal.Value = "01/" & mes & "/" & ayo
        cargarDatos()
    End Sub
    Sub cargarDatos()
        Entidad.Contratista = New ETContratista
        Negocio.NContratista = New NGContratista
        Entidad.Contratista._codprov = txtcodcontratista.Text
        Entidad.Contratista._ayo = ayo
        Entidad.Contratista._mes = mes
        dtFactura = Negocio.NContratista.ListarOtraFactura(Entidad.Contratista)
        Call CargarUltraGridxBinding(gridImpuestos, Source1, dtFactura)
    End Sub
    Private Sub UltraTextEditor1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtserie.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        txtserie.Text = txtserie.Text.ToString.PadLeft(3, "0")
        txtnumero.Focus()
    End Sub
    Private Sub txtserie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtserie.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub
    Private Sub txtnumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnumero.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        txtnumero.Text = txtnumero.Text.ToString.PadLeft(7, "0")
        dtfecha.Focus()
    End Sub
    Sub agregarFactura()
        'If Year(dtfecha.Value) <> ayo Or Month(dtfecha.Value) <> mes Then
        '    MsgBox("La fecha de factura debe pertenecer al período " & mes & " - " & ayo, MsgBoxStyle.Exclamation, msgComacsa)
        '    Exit Sub
        'End If
        If dtFactura.Columns.Count <= 0 Then
            dtFactura.Columns.Add("TIPO_COMPROB")
            dtFactura.Columns.Add("NUMDOC")
            dtFactura.Columns.Add("FECHA")
            dtFactura.Columns.Add("TIPO")
            dtFactura.Columns.Add("VALORVTA")
            dtFactura.Columns.Add("IGV")
            dtFactura.Columns.Add("VALOR")
            dtFactura.Columns.Add("COD_CLI")
            dtFactura.Columns.Add("RAZON")
            dtFactura.Columns.Add("RUC")
            dtFactura.Columns.Add("FECHAREAL")
        End If
        txtigv.Text = CDbl(txtigv.Text).ToString("##0.00")
        Dim fecha As Date
        Dim fechareal As Date
        fecha = dtfecha.Value
        fechareal = dtpreal.Value
        Dim valor As Double = 0
        valor = CDbl(txtvalorvta.Text) + CDbl(txtigv.Text)
        Dim dr As DataRow
        dr = dtFactura.NewRow
        dr(0) = "FA"
        dr(1) = txtserie.Text & txtnumero.Text
        dr(2) = fecha 'Format(fecha, "dd/MM/yyyy")
        If rdbcompra.Checked = True Then
            dr(3) = "COMPRA"
        End If
        If rdbventa.Checked = True Then
            dr(3) = "VENTA"
        End If

        dr(4) = CDbl(txtvalorvta.Text).ToString("##0.00")
        dr(5) = CDbl(txtigv.Text).ToString("##0.00")
        dr(6) = CDbl(valor).ToString("##0.00")
        dr(7) = txtcodcontratista.Text
        dr(8) = txtcontratista.Text
        dr(9) = txtruc.Text
        dr(10) = fechareal
        dtFactura.Rows.Add(dr)
        Call CargarUltraGridxBinding(gridImpuestos, Source1, dtFactura)
    End Sub
    Private Sub txtmonto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtigv.KeyDown
        If Not (e.KeyValue = Keys.Enter) Then Return
        If Not validaFactura(txtserie.Text & txtnumero.Text, txtruc.Text) Then
            Exit Sub
        End If
        agregarFactura()
        limpiar()
    End Sub
    Sub limpiar()
        txtserie.Clear()
        txtnumero.Clear()
        txtvalorvta.Clear()
        txtigv.Clear()
        txtruc.Clear()
        txtserie.Focus()
    End Sub
    Function validaFactura(ByVal numero As String, ByVal ruc As String) As Boolean
        If txtvalorvta.Text.ToString.Trim = "" Then txtvalorvta.Text = "0.00"
        If txtigv.Text.ToString.Trim = "" Then txtigv.Text = "0.00"
        txtserie.Text = txtserie.Text.ToString.PadLeft(3, "0")
        txtnumero.Text = txtnumero.Text.ToString.PadLeft(7, "0")
        If txtserie.Text.ToString.Trim = "" Or txtserie.Text = "000" Then
            MsgBox("Ingrese serie de factura", MsgBoxStyle.Exclamation, msgComacsa)
            txtserie.Focus()
            Return False
        End If
        If txtnumero.Text.ToString.Trim = "" Or txtnumero.Text = "0000000" Then
            MsgBox("Ingrese número de factura", MsgBoxStyle.Exclamation, msgComacsa)
            txtnumero.Focus()
            Return False
        End If
        If txtvalorvta.Text = 0 Then
            MsgBox("Ingrese valor vta.", MsgBoxStyle.Exclamation, msgComacsa)
            txtvalorvta.Focus()
            Return False
        End If
        If txtigv.Text = 0 Then
            MsgBox("Ingrese monto de IGV", MsgBoxStyle.Exclamation, msgComacsa)
            txtigv.Focus()
            Return False
        End If
        If Year(dtfecha.Value) <> ayo Or Month(dtfecha.Value) - mes > 1 Then
            MsgBox("Ingrese fecha correspondiente al período  " & mes & "/" & ayo & " o un mes anterior", MsgBoxStyle.Exclamation, msgComacsa)
            dtfecha.Focus()
            Return False
        End If
        For i As Int32 = 0 To gridImpuestos.Rows.Count - 1
            If gridImpuestos.Rows(i).Cells("NUMDOC").Value.ToString.Trim = numero And gridImpuestos.Rows(i).Cells("RUC").Value.ToString.Trim = ruc Then
                MsgBox("La factura N° " & numero & " ya se encuentra registrada", MsgBoxStyle.Exclamation, msgComacsa)
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub dtfecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtfecha.KeyDown
        If Not (e.KeyValue = Keys.Enter) Then Return
        txtruc.Focus()
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        If Me.gridImpuestos.ActiveRow Is Nothing Then Exit Sub
        If Me.gridImpuestos.ActiveRow.Index < 0 Then Exit Sub
        'dtFactura.Rows.RemoveAt(Me.gridImpuestos.ActiveRow.Index)

        'Ls_Anticipo = New List(Of ETContratista)

        Entidad.Contratista = New ETContratista
        Negocio.NContratista = New NGContratista
        Entidad.Contratista._codprov = txtcodcontratista.Text
        Entidad.Contratista._ruc = gridImpuestos.ActiveRow.Cells("RUC").Value
        Entidad.Contratista._tipodocumento = gridImpuestos.ActiveRow.Cells("TIPO_COMPROB").Value
        Entidad.Contratista._documento = gridImpuestos.ActiveRow.Cells("NUMDOC").Value        
        'Ls_Anticipo.Add(Entidad.Contratista)

        Entidad.Contratista = Negocio.NContratista.EliminaOtraFactura(Entidad.Contratista)
        If Entidad.Contratista.Validacion Then
            cargarDatos()
        End If
        'If Entidad.Contratista.Validacion Then

        'End If

    End Sub
    Private Sub gridImpuestos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridImpuestos.KeyDown
        If e.KeyCode = 46 Then
            btneliminar_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        If gridImpuestos.Rows.Count <= 0 Then
            Exit Sub
        End If
        Ls_Anticipo = New List(Of ETContratista)
        For i As Int32 = 0 To gridImpuestos.Rows.Count - 1
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.Contratista._codprov = txtcodcontratista.Text
            Entidad.Contratista._ruc = gridImpuestos.Rows(i).Cells("RUC").Value
            Entidad.Contratista._tipodocumento = gridImpuestos.Rows(i).Cells("TIPO_COMPROB").Value
            'Entidad.Contratista._ayo = gridImpuestos.Rows(i).Cells("").Value
            'Entidad.Contratista._serie = gridImpuestos.Rows(i).Cells("").Value
            Entidad.Contratista._documento = gridImpuestos.Rows(i).Cells("NUMDOC").Value
            Entidad.Contratista.Fecha = gridImpuestos.Rows(i).Cells("FECHA").Value
            Entidad.Contratista._valorvta = gridImpuestos.Rows(i).Cells("VALORVTA").Value
            Entidad.Contratista._igv = gridImpuestos.Rows(i).Cells("IGV").Value
            Entidad.Contratista._valor = gridImpuestos.Rows(i).Cells("VALOR").Value
            Entidad.Contratista.FechaIngreso = gridImpuestos.Rows(i).Cells("FECHAREAL").Value
            If gridImpuestos.Rows(i).Cells("TIPO").Value = "COMPRA" Then
                Entidad.Contratista._tipo_fact = "C"
            End If
            If gridImpuestos.Rows(i).Cells("TIPO").Value = "VENTA" Then
                Entidad.Contratista._tipo_fact = "V"
            End If
            'Entidad.Contratista._tipo_fact = IIf(rdbcompra.Checked = True, "C", "V")
            Ls_Anticipo.Add(Entidad.Contratista)
        Next

        Entidad.Contratista = Negocio.NContratista.MantenimientoOtraFactura(Ls_Anticipo)
        If Entidad.Contratista.Validacion Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

        'MsgBox(dtFactura.Rows.Count)
    End Sub
    Private Sub txtvalorvta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtvalorvta.KeyDown
        If Not (e.KeyValue = Keys.Enter) Then Return
        If txtvalorvta.Text.Trim = "" Then txtvalorvta.Text = 0
        txtigv.Text = CDbl(txtvalorvta.Text) * 0.18
        txtigv.Focus()
    End Sub
    Private Sub txtnumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumero.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtvalorvta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvalorvta.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtigv_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtigv.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtruc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtruc.KeyDown
        If Not (e.KeyValue = Keys.Enter) Then Return
        txtvalorvta.Focus()
    End Sub

    Private Sub txtruc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtruc.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub dtfecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtfecha.ValueChanged
        Try
            dtpreal.Value = dtfecha.Value
        Catch ex As Exception

        End Try
    End Sub
End Class