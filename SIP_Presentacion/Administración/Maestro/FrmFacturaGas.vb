Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmFacturaGas
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim objNegocio As NGFacturaTelefonica

    Private Sub FrmFacturaGas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFecha.Value = Now.Date
        CargarListaTipoDoc()
        CargarListado()
    End Sub
    Public Sub CargarListaTipoDoc()
        Try
            objNegocio = New NGFacturaTelefonica
            Dim dt As DataTable = objNegocio.ListarTipoDocumentos(Companhia)
            Dim row As DataRow = dt.NewRow
            row("cod_maestro2") = "0"
            row("descrip") = "-- SELECCIONE --"

            dt.Rows.InsertAt(row, 0)

            cmbTipoDoc.DisplayMember = "descrip"
            cmbTipoDoc.ValueMember = "cod_maestro2"
            cmbTipoDoc.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Nuevo()
        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
        LimpiarControles()
        txtProvCodigo.Focus()
    End Sub

    Public Sub LimpiarControles()
        txtid.Text = "0"
        CargarConsumo()
        txtProvCodigo.Text = ""
        txtSerie.Text = ""
        txtnumero.Text = ""
        cmbTipoDoc.SelectedIndex = 0
        txtsubtotal.Text = "0.00"
        txtigv.Text = "0.00"
        txttotal.Text = "0.00"
        For Each txt As Control In GroupBox1.Controls
            If (TypeOf txt Is Infragistics.Win.UltraWinEditors.UltraTextEditor) Then
                txt.Text = "0.00"
            End If
        Next

        For Each txt As Control In GroupBox2.Controls
            If (TypeOf txt Is Infragistics.Win.UltraWinEditors.UltraTextEditor) Then
                txt.Text = "0.00"
            End If
        Next
        txtProvCodigo.Focus()
    End Sub

    Private Sub txtProvCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProvCodigo.KeyDown
        If e.KeyData = Keys.Return Then
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtProvCodigo.Text
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NContratista.Listar_PRO_Prov_Codigo(Entidad.Contratista)
            If dtDatos.Rows.Count > 0 Then
                txtProvCodigo.Text = dtDatos.Rows(0)("COD_PROV")
                txtProveedor.Text = dtDatos.Rows(0)("PROVEEDOR")
            Else
                MsgBox("El código no existe", MsgBoxStyle.Exclamation, msgComacsa)
                txtproveedor.Clear()
            End If
        End If
    End Sub
    Sub Buscar()
        Dim frm As New FrmListaTransportista
        frm.ShowDialog()
        txtProvCodigo.Text = codMotivodetalle.Trim
        txtProveedor.Text = Motivodetalle.Trim
    End Sub

    Public Sub CargarListado()
        Try
            Dim objEntidad As New ETFacturaTelefonica
            objEntidad.CodCia = Companhia
            objNegocio = New NGFacturaTelefonica
            CargarUltraGridxBinding(GrdDatos, Source1, objNegocio.ListarFactGas(objEntidad))

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CargarConsumo()
        Try
            If txtid.Text = "" Then txtid.Text = 0
            Dim objEntidad As New ETFacturaTelefonica
            objNegocio = New NGFacturaTelefonica
            objEntidad.ID = txtid.Text
            objEntidad.fecha = dtFecha.Value

            CargarUltraGridxBinding(GrdConsumo, Source2, objNegocio.ListarFactGasCONSUMO(objEntidad))

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Grabar()
        If tabPrincipal.Tabs("T01").Selected = True Then Exit Sub
        For Each txt As Control In GroupBox1.Controls
            If (TypeOf txt Is Infragistics.Win.UltraWinEditors.UltraTextEditor) Then
                If txt.Text = "" Then txt.Text = "0.00"
            End If
        Next

        For Each txt As Control In GroupBox2.Controls
            If (TypeOf txt Is Infragistics.Win.UltraWinEditors.UltraTextEditor) Then
                If txt.Text = "" Then txt.Text = "0.00"
            End If
        Next

        If Not Validar() Then Return
        Dim Id As Integer = Convert.ToInt32(txtid.Text)
        Dim resp As DialogResult = Windows.Forms.DialogResult.No
        Dim op As Integer = 0

        If Id = 0 Then
            resp = MessageBox.Show("¿Desea Registrar la Factura?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 1
        Else
            resp = MessageBox.Show("¿Desea Modificar la Factura?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 2
        End If

        If resp = Windows.Forms.DialogResult.No Then Return

        Try
            Dim objEntidad As New ETFacturaTelefonica
            objEntidad.CodCia = Companhia
            objEntidad.Ope = 1
            objEntidad.ID = Id
            objEntidad.CodProv = txtProvCodigo.Text
            objEntidad.TipoDoc = cmbTipoDoc.Value
            objEntidad.NroDoc = txtSerie.Text.Trim().PadLeft(4, "0") & txtnumero.Value.ToString().Trim().PadLeft(16, "0")
            objEntidad.fecha = dtFecha.Value
            objEntidad.subtotal = txtsubtotal.Text
            objEntidad.igv = txtigv.Text
            objEntidad.total = txttotal.Text
            objEntidad.lecturaant = txtlectant.Text
            objEntidad.lecturaact = txtlectact.Text
            objEntidad.volconsumido = txtconsumido.Text
            objEntidad.factcorrecion = txtcorreccion.Text
            objEntidad.condestandar = txtestandar.Text
            objEntidad.volfacturado = txtfacturado.Text
            objEntidad.podcalorifico = txtcalorifico.Text
            objEntidad.mindiario = txtminimo.Text
            objEntidad.gasnatural = txtgas.Text
            objEntidad.servtransporte = txttransporte.Text
            objEntidad.distvariable = txtvariable.Text
            objEntidad.distfijo = txtfijo.Text
            objEntidad.comercializacion = txtcomercializacion.Text
            objEntidad.otros = txtotros.Text
            objEntidad.redondeoant = txtredondeoant.Text
            objEntidad.redondeoact = txtredondeoact.Text
            objEntidad.Usuario = User_Sistema

            Dim dtResult As New DataTable
            dtResult = objNegocio.MantenimientoFactGas(objEntidad, op)

            If dtResult.Rows.Count > 0 Then
                If dtResult.Rows(0)(0) = "OK" Then
                    'GRABAMOS LOS CONSUMO SI SON INGRESADOS
                    Dim objEntidad_CC As New ETConsumoCentroCosto
                    Dim objNegocio_CC As New NGConsumoCentroCosto
                    GrdConsumo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
                    For I As Int32 = 0 To GrdConsumo.Rows.Count - 1
                        objEntidad_CC = New ETConsumoCentroCosto
                        objEntidad_CC.CodCia = Companhia
                        objEntidad_CC.CodTipo = "01"
                        objEntidad_CC.CodCentroCosto = GrdConsumo.Rows(I).Cells("CODCENCOS").Value
                        objEntidad_CC.Anio = CDate(dtFecha.Value).Year
                        objEntidad_CC.Mes = CDate(dtFecha.Value).Month
                        objEntidad_CC.Consumo = Convert.ToDecimal(GrdConsumo.Rows(I).Cells("CONSUMO").Value)
                        objEntidad_CC.Observacion = ""
                        objEntidad_CC.Id = Convert.ToInt32(GrdConsumo.Rows(I).Cells("ID").Value)
                        objEntidad_CC.Usuario = User_Sistema
                        objEntidad_CC.Codequipo = ""
                        objEntidad_CC.CodCentroCostoIni = ""
                        objEntidad_CC.CodCentroCostoFin = ""
                        objNegocio_CC = New NGConsumoCentroCosto
                        If Convert.ToInt32(GrdConsumo.Rows(I).Cells("ID").Value) = 0 Then
                            op = 1
                        Else
                            op = 2
                        End If
                        Dim dt As DataTable = objNegocio_CC.MantenimientoConsumoCentroCosto(objEntidad_CC, op)
                    Next
                    MessageBox.Show("Proceso realizado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LimpiarControles()
                Else
                    MessageBox.Show(dtResult.Rows(0)(0), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            'If resultado.Realizo Then

            '    If op = 1 Then
            '        MessageBox.Show("Se Registró la asignación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Else
            '        MessageBox.Show("Se Modificó la asignación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            '    'CargarDatos(resultado.Valor)
            'End If

            CargarListado()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub Eliminar()
        'If tabPrincipal.Tabs("T01").Selected = True Then Exit Sub
        For Each txt As Control In GroupBox1.Controls
            If (TypeOf txt Is Infragistics.Win.UltraWinEditors.UltraTextEditor) Then
                If txt.Text = "" Then txt.Text = "0.00"
            End If
        Next

        For Each txt As Control In GroupBox2.Controls
            If (TypeOf txt Is Infragistics.Win.UltraWinEditors.UltraTextEditor) Then
                If txt.Text = "" Then txt.Text = "0.00"
            End If
        Next

        Dim Id As Integer = 0
        Id = Convert.ToInt32(GrdDatos.ActiveRow.Cells("ID").Value)
        If Id = 0 Then Id = Convert.ToInt32(txtid.Text)
        If Id = 0 Then MsgBox("Seleccione registro a eliminar", MsgBoxStyle.Information, "Sistema") : Exit Sub
        Dim resp As DialogResult = Windows.Forms.DialogResult.No
        Dim op As Integer = 0

        resp = MessageBox.Show("¿Desea Eliminar la Factura?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        op = 3

        If resp = Windows.Forms.DialogResult.No Then Return

        Try
            Dim objEntidad As New ETFacturaTelefonica
            objEntidad.CodCia = Companhia
            objEntidad.Ope = 3
            objEntidad.ID = Id
            objEntidad.CodProv = txtProvCodigo.Text
            objEntidad.TipoDoc = cmbTipoDoc.Value
            objEntidad.NroDoc = txtSerie.Text.Trim().PadLeft(4, "0") & txtnumero.Value.ToString().Trim().PadLeft(16, "0")
            objEntidad.fecha = dtFecha.Value
            objEntidad.subtotal = txtsubtotal.Text
            objEntidad.igv = txtigv.Text
            objEntidad.total = txttotal.Text
            objEntidad.lecturaant = txtlectant.Text
            objEntidad.lecturaact = txtlectact.Text
            objEntidad.volconsumido = txtconsumido.Text
            objEntidad.factcorrecion = txtcorreccion.Text
            objEntidad.condestandar = txtestandar.Text
            objEntidad.volfacturado = txtfacturado.Text
            objEntidad.podcalorifico = txtcalorifico.Text
            objEntidad.mindiario = txtminimo.Text
            objEntidad.gasnatural = txtgas.Text
            objEntidad.servtransporte = txttransporte.Text
            objEntidad.distvariable = txtvariable.Text
            objEntidad.distfijo = txtfijo.Text
            objEntidad.comercializacion = txtcomercializacion.Text
            objEntidad.otros = txtotros.Text
            objEntidad.redondeoant = txtredondeoant.Text
            objEntidad.redondeoact = txtredondeoact.Text
            objEntidad.Usuario = User_Sistema

            Dim dtResult As New DataTable
            dtResult = objNegocio.MantenimientoFactGas(objEntidad, op)

            If dtResult.Rows.Count > 0 Then
                If dtResult.Rows(0)(0) = "OK" Then
                    MessageBox.Show("Registro eliminado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LimpiarControles()
                Else
                    MessageBox.Show(dtResult.Rows(0)(0), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            CargarListado()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function Validar() As Boolean
        If txtProvCodigo.Text = "" Then
            MsgBox("Ingrese codigo de proveedor", MsgBoxStyle.Exclamation, "Sistema")
            Return False
        End If
        If txtProvCodigo.Text = "" Then
            MsgBox("Ingrese codigo de proveedor", MsgBoxStyle.Exclamation, "Sistema")
            txtProvCodigo.Focus()
            Return False
        End If
        If txtSerie.Text = "" Or txtSerie.Text = "0000" Then
            MsgBox("Ingres serie correcta", MsgBoxStyle.Exclamation, "Sistema")
            txtSerie.Focus()
            Return False
        End If
        If txtnumero.Text = "" Or txtnumero.Text = "0000000000000000" Then
            MsgBox("Ingrese numero de documento correcto", MsgBoxStyle.Exclamation, "Sistema")
            txtnumero.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub cmbTipoDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoDoc.ValueChanged
        Try
            txtSerie.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyData = 13 Then
            txtSerie.Text = txtSerie.Text.PadLeft(4, "0")
            txtnumero.Focus()
        End If
    End Sub

    Private Sub txtnumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnumero.KeyDown
        If e.KeyData = 13 Then
            txtnumero.Text = txtnumero.Text.PadLeft(16, "0")
            txtlectant.Focus()
        End If
    End Sub

    Private Sub txtlectant_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlectant.KeyDown, txtlectact.KeyDown, txtconsumido.KeyDown, txtcorreccion.KeyDown, txtestandar.KeyDown, txtfacturado.KeyDown, txtcalorifico.KeyDown, txtminimo.KeyDown, txtgas.KeyDown, txttransporte.KeyDown, txtvariable.KeyDown, txtfijo.KeyDown, txtotros.KeyDown, txtredondeoact.KeyDown, txtredondeoant.KeyDown, txtcomercializacion.KeyDown
        If e.KeyData = 13 Then
            e.Handled = True
            sender.text = CDbl(sender.text).ToString("#,#0.00")
            sender.focus()
            'SendKeys.Send("{TAB}")
            If sender.name = "txtlectact" Then
                Dim lectura_ant As Double = txtlectant.Text
                Dim lectura_act As Double = txtlectact.Text
                Dim consumido As Double = lectura_act - lectura_ant
                txtconsumido.Text = CDbl(consumido).ToString("#,#0.00")
                txtcorreccion.Focus()
            End If
            If sender.name = "txtestandar" Then
                txtfacturado.Text = CDbl(txtestandar.Text).ToString("#,#0.00")
                txtcalorifico.Focus()
            End If
            calculatotal()
        End If
    End Sub

    Private Sub txtlectant_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlectant.KeyPress, txtlectact.KeyPress, txtconsumido.KeyPress, txtcorreccion.KeyPress, txtestandar.KeyPress, txtfacturado.KeyPress, txtcalorifico.KeyPress, txtminimo.KeyPress, txtgas.KeyPress, txttransporte.KeyPress, txtvariable.KeyPress, txtfijo.KeyPress, txtotros.KeyPress, txtredondeoact.KeyPress, txtredondeoant.KeyPress, txtcomercializacion.KeyPress
        Tabular(e)
        DecimalPosit(sender, e)
    End Sub

    Public Sub Tabular(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Sub DecimalPosit(ByVal obj As Infragistics.Win.UltraWinEditors.UltraTextEditor, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Key As Integer
        Key = Asc(UCase(e.KeyChar))
        Dim StrCad As String
        StrCad = "0123465789.-"
        If Key > 26 Then
            If InStr(StrCad, Chr(Key)) = 0 Then
                e.Handled = True
            Else
                If Key = 46 Then
                    If InStr(obj.Text, Chr(Key)) = 0 Then
                        obj.MaxLength = obj.TextLength + 3
                    Else
                        e.Handled = True
                    End If
                End If
            End If
        End If
    End Sub

    Sub calculatotal()
        Dim gasnatural As Double = txtgas.Text
        Dim serv_transporte As Double = txttransporte.Text
        Dim serv_variable As Double = txtvariable.Text
        Dim serv_fijo As Double = txtfijo.Text
        Dim serv_comercializacion As Double = txtcomercializacion.Text
        Dim otros As Double = txtotros.Text
        Dim redondeo_ant As Double = txtredondeoant.Text
        Dim redondeo_act As Double = txtredondeoact.Text

        Dim subtotal As Double = CDbl(gasnatural + serv_transporte + serv_variable + serv_fijo + serv_comercializacion + otros)
        Dim igv As Double = CDbl(subtotal * 0.18)
        Dim total As Double = CDbl(subtotal + igv + redondeo_ant + redondeo_act)

        txtsubtotal.Text = subtotal.ToString("#,#0.00")
        txtigv.Text = igv.ToString("#,#0.00")
        txttotal.Text = total.ToString("#,#0.00")
    End Sub

    Private Sub GrdDatos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GrdDatos.DoubleClickRow
        Try
            tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
            CargarDetalle(GrdDatos.ActiveRow.Cells("ID").Value)
            CargarConsumo()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarDetalle(ByVal id As Int32)
        Try
            Dim objEntidad As New ETFacturaTelefonica
            objEntidad.ID = id
            Dim dtdatos As New DataTable
            dtdatos = objNegocio.ListarFactGasID(objEntidad)
            If dtdatos.Rows.Count > 0 Then
                txtid.Text = dtdatos.Rows(0)("ID")
                txtProvCodigo.Text = dtdatos.Rows(0)("COD_PROV")
                txtProveedor.Text = dtdatos.Rows(0)("RAZON")
                dtFecha.Value = dtdatos.Rows(0)("FECHA")
                cmbTipoDoc.Value = dtdatos.Rows(0)("TIPO_DOC")
                txtSerie.Text = dtdatos.Rows(0)("NUMERO").ToString.Substring(0, 4)
                txtnumero.Text = dtdatos.Rows(0)("NUMERO").ToString.Substring(4, 16)
                txtsubtotal.Text = dtdatos.Rows(0)("SUBTOTAL")
                txtigv.Text = dtdatos.Rows(0)("IGV")
                txttotal.Text = dtdatos.Rows(0)("TOTAL")

                txtlectant.Text = dtdatos.Rows(0)("LECTURA_ANT")
                txtlectact.Text = dtdatos.Rows(0)("LECTURA_ACT")
                txtconsumido.Text = dtdatos.Rows(0)("VOL_CONSUMIDO")
                txtcorreccion.Text = dtdatos.Rows(0)("FACT_CORRECCION")
                txtestandar.Text = dtdatos.Rows(0)("VOL_COND_ESTANDAR")
                txtfacturado.Text = dtdatos.Rows(0)("VOL_FACTURADO")
                txtcalorifico.Text = dtdatos.Rows(0)("PODER_CALORIFICO")
                txtminimo.Text = dtdatos.Rows(0)("VALOR_MIN_DIARIO")
                txtgas.Text = dtdatos.Rows(0)("GAS_NATURAL")
                txttransporte.Text = dtdatos.Rows(0)("SERVICIO_TRANSPORTE")
                txtvariable.Text = dtdatos.Rows(0)("DISTRIBUCION_VARIABLE")
                txtfijo.Text = dtdatos.Rows(0)("DISTRIBUCION_FIJO")
                txtcomercializacion.Text = dtdatos.Rows(0)("COMERCIALIZACION_FIJO")
                txtotros.Text = dtdatos.Rows(0)("OTROS_CONCEPTOS")
                txtredondeoant.Text = dtdatos.Rows(0)("REDONDEO_ANTERIOR")
                txtredondeoact.Text = dtdatos.Rows(0)("REDONDEO_ACT")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFecha.ValueChanged
        Try
            CargarConsumo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GrdConsumo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdConsumo.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is GrdConsumo) Then Return
            With sender
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Down
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Right
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Left
                        .PerformAction(ExitEditMode)
                        .PerformAction(PrevCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Return
                        If GrdConsumo.ActiveRow.Cells(GrdConsumo.ActiveCell.Column.Index).Column.Key = "CONSUMO" Then
                            GrdConsumo.PerformAction(BelowCell)
                            'GrdConsumo.PerformAction(NextCellByTab)
                            e.Handled = Boolean.TrueString
                            GrdConsumo.PerformAction(EnterEditMode)
                        End If

                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class