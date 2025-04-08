Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms

Public Class FrmConsumoPorCC
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim formatoMoneda As String = "#####0.00"
    Dim objNegocio As NGConsumoCentroCosto
    Dim dtTipos As DataTable

    Private Sub FrmConsumoPorCC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objNegocio = New NGConsumoCentroCosto()

        CargarListaConsumoCentroCosto()
        CargarComboTipo()

        tabConsumo.SelectedTab = tabConsumo.Tabs("T01")

    End Sub

    Sub Procesar()
        CargarListaConsumoCentroCosto()
    End Sub

    Public Sub CargarListaConsumoCentroCosto()
        Try
            Dim ET_ConsumoCC As New ETConsumoCentroCosto
            ET_ConsumoCC.CodCia = Companhia
            ET_ConsumoCC.Anio = 0
            ET_ConsumoCC.Mes = 0

            CargarUltraGridxBinding(GrdDatos, Source1, objNegocio.ListarConsumoCentroCosto(ET_ConsumoCC))
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CargarComboTipo()
        Try
            Dim ET_ConsumoCC As New ETConsumoCentroCosto
            ET_ConsumoCC.CodCia = Companhia
            dtTipos = objNegocio.ListarTipoConsumoCentroCosto(ET_ConsumoCC)

            cmbTipo.DisplayMember = "descrip"
            cmbTipo.ValueMember = "cod_maestro2"
            cmbTipo.DataSource = dtTipos

            cmbCentroCosto.DisplayMember = "descripcion"
            cmbCentroCosto.ValueMember = "codcencos"

            cmbCentroCostoOri.DisplayMember = "descripcion"
            cmbCentroCostoOri.ValueMember = "codcencos"

            ET_ConsumoCC.CodTipo = ""
            ET_ConsumoCC.CodCentroCosto = ""
            cmbCentroCosto.DataSource = objNegocio.ListarCentroCosto(ET_ConsumoCC)
            cmbCentroCostoOri.DataSource = objNegocio.ListarCentroCosto(ET_ConsumoCC)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub HabilitarControles(ByVal pHabilitar As Boolean)
        cmbTipo.ReadOnly = Not pHabilitar
        cmbMes.ReadOnly = Not pHabilitar
        udAnio.ReadOnly = Not pHabilitar
        txtConsumo.ReadOnly = Not pHabilitar
        txtCodCentroCosto.ReadOnly = Not pHabilitar
        cmbCentroCosto.ReadOnly = Not pHabilitar
        txtCodCentroCosto.ReadOnly = Not pHabilitar
    End Sub
    Private Sub LimpiarControles()
        cmbTipo.SelectedIndex = 0
        udAnio.Value = Now.Year
        cmbMes.Value = Now.Month
        txtConsumo.Text = "0.00"
        txtCodCentroCosto.Text = String.Empty
        txtCentroCosto.Text = String.Empty
        txtid.Text = "0"
        txtobservacion.Text = ""
        If cmbCentroCosto.Items.Count > 0 Then
            cmbCentroCosto.SelectedIndex = -1
        End If
        chktransfer.Checked = False
        txt_Codequipo.Text = ""
        cmbCentroCostoOri.Value = Nothing
        txtKW.Text = "0.00"
    End Sub
    Public Sub Buscar()
        CargarListaConsumoCentroCosto()
    End Sub
    Public Sub Eliminar()
        If MessageBox.Show("¿Desea eliminar el consumo del centro de costo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Try
            Dim Id As Integer = Convert.ToInt32(txtid.Text)

            Dim objEntidad As New ETConsumoCentroCosto
            objEntidad.Id = Id

            Dim dt As DataTable = objNegocio.MantenimientoConsumoCentroCosto(objEntidad, 3)

            If dt.Rows.Count > 0 Then
                Procesar()
                LimpiarControles()
                HabilitarControles(False)
                tabConsumo.SelectedTab = tabConsumo.Tabs("T01")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Modificar()

        Dim Id As Integer = Convert.ToInt32(txtid.Text)

        If Id = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'consumo de luz solo se puede visualizar
        If Id = -1 Then
            MessageBox.Show("El registro no se puede modificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        HabilitarControles(True)

        txtConsumo.Focus()

    End Sub

    Public Sub Nuevo()

        HabilitarControles(True)
        cmbTipo.Focus()

        LimpiarControles()

        tabConsumo.SelectedTab = tabConsumo.Tabs("T02")

    End Sub

    Public Sub Grabar()

        If Not Validar() Then Return

        Dim Id As Integer = Convert.ToInt32(txtid.Text)
        Dim resp As DialogResult = Windows.Forms.DialogResult.No
        Dim op As Integer = 0

        If Id = 0 Then
            resp = MessageBox.Show("¿Desea Registrar el Consumo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 1
        Else
            resp = MessageBox.Show("¿Desea Modificar el Consumo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 2
        End If

        If resp = Windows.Forms.DialogResult.No Then Return

        Dim objEntidad As New ETConsumoCentroCosto
        objEntidad.CodCia = Companhia
        objEntidad.CodTipo = cmbTipo.Value
        objEntidad.CodCentroCosto = txtCodCentroCosto.Text.Trim()
        objEntidad.Anio = udAnio.Value
        objEntidad.Mes = cmbMes.Value
        objEntidad.Consumo = Convert.ToDecimal(txtConsumo.Text.Trim())
        objEntidad.Observacion = txtobservacion.Text.Trim()
        objEntidad.Id = Convert.ToInt32(txtid.Text)
        objEntidad.Usuario = User_Sistema

        objEntidad.Transferencia = IIf(chktransfer.Checked = True, "1", "0")
        If chktransfer.Checked = True Then
            objEntidad.Codequipo = txt_Codequipo.Text
            objEntidad.CodCentroCostoIni = cmbCentroCostoOri.Value
            objEntidad.CodCentroCostoFin = cmbCentroCosto.Value
        Else
            objEntidad.Codequipo = ""
            objEntidad.CodCentroCostoIni = ""
            objEntidad.CodCentroCostoFin = ""
        End If

        objEntidad.Usuario = User_Sistema

        Try

            Dim dt As DataTable = objNegocio.MantenimientoConsumoCentroCosto(objEntidad, op)

            If dt.Rows.Count > 0 Then
                CargarDatos(dt.Rows(0))
                LimpiarControles()
                HabilitarControles(False)
            End If

            CargarListaConsumoCentroCosto()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Public Sub Reporte()
        Try
            If GrdDatos.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron datos para exportar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim ruta As String
            ruta = Application.StartupPath & String.Format("\{0}_{1}_{2}", udAnio.Value, cmbMes.Text, "CONSUMO_POR_CENTRO_COSTO.xls")

            If System.IO.File.Exists(ruta) AndAlso MsgBox("El reporte ya existe , desea reemplazarlo?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                Exit Sub
            End If

            Exportador.Export(GrdDatos, ruta)

            MessageBox.Show("Exportado" & Environment.NewLine & ruta, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            System.Diagnostics.Process.Start(ruta)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub CargarDatos(ByVal dr As DataRow)

        LimpiarControles()

        If dr Is Nothing Then Return

        txtid.Text = Convert.ToInt32(dr("ID"))
        cmbTipo.Value = Convert.ToString(dr("COD_TIPO"))
        udAnio.Value = Convert.ToInt32(dr("ANIO"))
        cmbMes.Value = Convert.ToInt32(dr("MES"))
        txtCodCentroCosto.Text = Convert.ToString(dr("COD_CENTRO_COSTO"))
        txtCentroCosto.Text = Convert.ToString(dr("CENTRO_COSTO"))
        txtConsumo.Text = Convert.ToDecimal(dr("CONSUMO")).ToString(formatoMoneda)
        txtobservacion.Text = Convert.ToString(dr("OBSERVACION"))

        cmbCentroCosto.Value = Convert.ToString(dr("COD_CENTRO_COSTO"))

    End Sub

    Private Function Validar() As Boolean
        Ep1.Clear()

        Dim lResult As Boolean
        lResult = True

        If cmbTipo.SelectedIndex < 0 Then
            Ep1.SetError(cmbTipo, "Seleccione el Tipo de Consumo")
            lResult = False
        End If

        If cmbMes.SelectedIndex < 0 Then
            Ep1.SetError(cmbMes, "Seleccione el Mes de Consumo")
            lResult = False
        End If

        If String.IsNullOrEmpty(txtConsumo.Text.Trim()) Then
            Ep1.SetError(txtConsumo, "Ingrese el Consumo para el Centro de Costo")
            lResult = False
        End If

        Dim pConsumo As Decimal = 0
        Decimal.TryParse(txtConsumo.Text.Trim(), pConsumo)

        If pConsumo = 0 Then
            Ep1.SetError(txtConsumo, "Ingrese un Consumo Válido para el Centro de Costo")
            lResult = False
        End If

        If String.IsNullOrEmpty(txtCodCentroCosto.Text.Trim()) Then
            Ep1.SetError(txtCodCentroCosto, "Ingrese el Centro de Costo")
            lResult = False
        End If

        Return lResult
    End Function

    Private Sub cmbTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.ValueChanged
        If cmbTipo.Value Is Nothing Then Return
        Try
            'unidad de medida
            Dim row() As DataRow = dtTipos.Select("cod_maestro2=" & cmbTipo.Value)

            If row.Length > 0 Then
                txtunidad.Text = row(0)("flag2")
            End If

            'filtrar centros de costos por tipo de registro
            txtCodCentroCosto.Text = String.Empty
            cmbCentroCosto.SelectedIndex = -1

            Dim objEntidad As New ETConsumoCentroCosto
            objEntidad.CodCia = Companhia
            objEntidad.CodTipo = cmbTipo.Value.ToString()
            objEntidad.CodCentroCosto = ""

            cmbCentroCosto.DataSource = objNegocio.ListarCentroCosto(objEntidad)
            If cmbTipo.Value = "03" Then
                chktransfer.Visible = True
                chktransfer.Checked = False
                Panel1.Visible = False
            Else
                chktransfer.Visible = False
                chktransfer.Checked = False
                Panel1.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtConsumo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsumo.Enter
        txtConsumo.SelectAll()
    End Sub

    Private Sub txtConsumo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsumo.Leave
        Dim consumo As Decimal = 0

        If Not Decimal.TryParse(txtConsumo.Text.Trim(), consumo) Then
            MessageBox.Show("Ingrese una consumo valido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtConsumo.SelectAll()
        Else
            txtConsumo.Text = consumo.ToString(formatoMoneda)
        End If
    End Sub

    Private Sub GrdDatos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrdDatos.DoubleClick

    End Sub

    Private Sub GrdDatos_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GrdDatos.DoubleClickRow
        If e.Row.IsFilterRow Then Return

        Dim objEntidad As New ETConsumoCentroCosto
        objEntidad.Id = Convert.ToInt32(e.Row.Cells("ID").Value)
        objEntidad.CodCia = Companhia

        If objEntidad.Id = -1 Then
            MsgBox("El registro no puede ser modificado", MsgBoxStyle.OkOnly, Me.Text)
            Exit Sub
        End If

        Dim dt As DataTable = objNegocio.ObtenerConsumoCentroCosto(objEntidad)

        If dt.Rows.Count > 0 Then
            HabilitarControles(False)
            CargarDatos(dt.Rows(0))
            tabConsumo.SelectedTab = tabConsumo.Tabs("T02")
        End If

    End Sub

    Private Sub Exportador_EndExport(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.EndExportEventArgs) Handles Exportador.EndExport

    End Sub

    Private Sub Exportador_BeginExport(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.BeginExportEventArgs) Handles Exportador.BeginExport
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        e.CurrentRowIndex += 1
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).Value = "CONSUMO POR CENTRO DE COSTO"
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True        
        e.CurrentRowIndex += 2
    End Sub

    Private Sub Exportador_HeaderCellExported(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.HeaderCellExportedEventArgs) Handles Exportador.HeaderCellExported

    End Sub

    Private Sub Exportador_HeaderRowExported(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.HeaderRowExportedEventArgs) Handles Exportador.HeaderRowExported

    End Sub

    Private Sub cmbCentroCosto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCentroCosto.ValueChanged
        If cmbCentroCosto.Value Is Nothing Then
            txtCodCentroCosto.Text = ""
        Else
            txtCodCentroCosto.Text = cmbCentroCosto.Value.ToString().Trim()
        End If
    End Sub

    Private Sub txtCodCentroCosto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodCentroCosto.KeyPress
        'If e.KeyChar = "13" Then

        'End If        
    End Sub

    Private Sub txtCodCentroCosto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCentroCosto.KeyDown
        Dim Encontrado As Boolean = False
        If e.KeyCode = Keys.Enter Then
            For Each item As Infragistics.Win.ValueListItem In cmbCentroCosto.Items
                If Convert.ToString(item.DataValue).Trim() = txtCodCentroCosto.Text.Trim Then
                    cmbCentroCosto.SelectedIndex = item.ListIndex
                    Encontrado = True
                End If
            Next
            If Not Encontrado Then
                MessageBox.Show("No se pudo encontrar un centro de costo con el codigo: " & txtCodCentroCosto.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCentroCosto.SelectedIndex = -1
                txtCodCentroCosto.SelectAll()
            End If
        End If
    End Sub

    Private Sub txt_Codequipo_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles txt_Codequipo.EditorButtonClick
        Try
            Dim frm As New frmConsumoEne
            frm.ayo = udAnio.Value
            frm.mes = cmbMes.Value
            Dim placa As String = ""
            Dim cencosori As String = ""
            Dim KW As Double = 0
            frm.ShowDialog()
            placa = frm.gridCuenta.ActiveRow.Cells("PLACA").Value
            cencosori = frm.gridCuenta.ActiveRow.Cells("CODCENCOS").Value
            KW = frm.gridCuenta.ActiveRow.Cells("KW_PROM").Value
            txt_Codequipo.Text = placa.ToString.Trim
            cmbCentroCostoOri.Value = cencosori.ToString
            txtKW.Text = CDbl(KW).ToString("#,##0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chktransfer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktransfer.CheckedChanged
        Try
            txt_Codequipo.Text = ""
            cmbCentroCostoOri.Value = Nothing
            txtKW.Text = "0.00"
            If chktransfer.Checked = True Then
                Panel1.Visible = True
            Else
                Panel1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GrdDatos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GrdDatos.InitializeLayout

    End Sub
End Class