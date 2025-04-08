Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms

Public Class FrmAsigTarjetasConsumo

    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim objNegocio As NGTarjetaConsumo
    Dim objEntidad As ETTarjetaConsumo
    Public lgCrud = ""

    Private Sub FrmAsigTarjetasConsumo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        HabilitarControles(False)

        objNegocio = New NGTarjetaConsumo
        Dim objEntidad As New ETTarjetaConsumo
        objEntidad.CodCia = Companhia

        Try

            ' Deshabilitar la pestaña "T02" al cargar el formulario
            tabPrincipal.Tabs("T02").Enabled = False

            CargarListado()
            CargaTipoTarjeta()
            CargaMonedaTarjeta()
            CargaEstadoTarjeta()

            ' CargarlistaBolsas()

            ' CargarGrillaBolsas()

            tabPrincipal.SelectedTab = tabPrincipal.Tabs("T01")

            With GrdDatos.DisplayLayout
                ' Configuración general del grid
                .Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
                .Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False
                .Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.Never
                .Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False

                ' Manejo de las regiones de desplazamiento
                If .RowScrollRegions.Count > 0 Then
                    For i As Integer = 0 To .RowScrollRegions.Count - 1
                        With .RowScrollRegions(i)
                            ' Desactivar las barras de desplazamiento
                            .Scrollbar = ScrollBars.None

                            ' Establecer la altura en 0 para ocultar la región
                            .Height = 0

                            ' Asegurarse de que no esté oculta de forma incorrecta
                            .ResetHidden()
                        End With
                    Next
                End If

            End With


            ' Desactivar la agrupación automática
            GrdDatos.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False
            ' Desactivar la capacidad de arrastrar columnas para agrupar
            GrdDatos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
            ' Asegurarse de que los encabezados no se superpongan
            GrdDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub txtEmpleadoCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmpleadoCodigo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BuscarEmpleado()
        End If
    End Sub


    Private Sub CargaTipoTarjeta()
        objNegocio = New NGTarjetaConsumo
        objEntidad = New ETTarjetaConsumo
        Dim dt As New DataTable
        dt = objNegocio.CargarTipoTarjeta()
        Call CargarUltraCombo(cmb_tip_tarjeta, dt, "CODIGO", "DESCRIPCION")
    End Sub
    Private Sub CargaMonedaTarjeta()
        objNegocio = New NGTarjetaConsumo
        objEntidad = New ETTarjetaConsumo
        Dim dt As New DataTable
        dt = objNegocio.CargarMonedaTarjeta()
        Call CargarUltraCombo(cmb_mon_tarjeta, dt, "CODIGO", "DESCRIPCION")
    End Sub

    Private Sub CargaEstadoTarjeta()
        objNegocio = New NGTarjetaConsumo
        objEntidad = New ETTarjetaConsumo
        Dim dt As New DataTable
        dt = objNegocio.CargaEstadoTarjeta()
        Call CargarUltraCombo(cmb_est_tarjeta, dt, "CODIGO", "DESCRIPCION")
    End Sub

    Private Sub BuscarEmpleado()
        Dim frm As New FrmListarPlanilla
        frm.ShowDialog()

        txtEmpleadoCodigo.Text = Trim(frm.CODIGO)
        txtEmpleado.Text = frm.EMPLEADO
    End Sub

    Private Sub BuscarBanco()
        Dim frm As New FrmListarBanco
        frm.ShowDialog()

        txt_ds_banco.Text = Trim(frm.CODIGO)
        txt_des_ds_banco.Text = frm.DESBANCO
    End Sub


    Private Sub btnBuscarEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarEmpleado.Click
        BuscarEmpleado()
    End Sub

    Private Sub btn_ds_banco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ds_banco.Click
        BuscarBanco()
    End Sub

    Public Sub Nuevo()
        lgCrud = "N"
        HabilitarControles(True)
        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
        tabPrincipal.Tabs("T02").Enabled = True
        LimpiarControles()
        txtEmpleadoCodigo.Focus()
        lvw_HistorialTC.Enabled = True

    End Sub

    Public Sub Grabar()
        If Not Validar() Then Return
        Dim Id As Integer = Convert.ToInt32(txtid.Text)
        Dim resp As DialogResult = Windows.Forms.DialogResult.No
        Dim op As Integer = 0

        If lgCrud = "M" And Id = 0 Then
            Id = Convert.ToInt32(GrdDatos.ActiveRow.Cells("ID").Value)
            op = 2
        End If

        If Id = 0 Then
            resp = MessageBox.Show("¿Desea Registrar la Asignación de Tarjeta de Consumo al Personal?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 1
        Else
            resp = MessageBox.Show("¿Desea Modificar la Tarjeta de Consumo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 2
        End If

        If resp = Windows.Forms.DialogResult.No Then Return

        Try

            Dim objEntidad As New ETTarjetaConsumo

            objEntidad.Estado_Tarjeta = cmb_est_tarjeta.Value
            objEntidad.Moneda_Tarjeta = cmb_mon_tarjeta.Value
            'objEntidad.Tipo_Tarjeta = cmb_tip_tarjeta.Value

            objEntidad.Codigo_Empleado = txtEmpleadoCodigo.Text
            objEntidad.Codigo_Banco = txt_ds_banco.Text


            objEntidad.Ciclo_De = num_ciclodel.Value
            objEntidad.Ciclo_Hasta = num_cicloal.Value

            ' Obtener el mes y año actuales
            Dim currentYear As Integer = DateTime.Now.Year
            Dim currentMonth As Integer = DateTime.Now.Month

            ' Validar que los valores de num_ciclodel.Value y num_cicloal.Value sean enteros válidos
            If IsNumeric(num_ciclodel.Value) AndAlso IsNumeric(num_cicloal.Value) Then
                ' Convertir los valores a enteros
                Dim dayEmision As Integer = Convert.ToInt32(num_ciclodel.Value)
                Dim dayVcmto As Integer = Convert.ToInt32(num_cicloal.Value)

                ' Crear las fechas completas usando el año y mes actuales
                Dim fechaEmision As New DateTime(currentYear, currentMonth, dayEmision)
                'Dim fechaVcmto As New DateTime(currentYear, currentMonth, dayVcmto)
                Dim fechaVcmto As DateTime = New DateTime(currentYear, currentMonth, dayVcmto).AddMonths(1)

                ' Asignar las fechas al objeto objEntidad
                objEntidad.Fecha_Emision = fechaEmision
                objEntidad.Fecha_Vcmto = fechaVcmto
            End If


            objEntidad.Saldo_Inicial = txt_saldo_ini.Text
            objEntidad.Saldo_Inicial1 = txt_saldo_ini1.Text

            objEntidad.PlaCod = txtEmpleadoCodigo.Text

            objEntidad.Nro_Tarjeta = txt_nro_tarjeta.Text.Replace("-", "")
            objEntidad.CodCia = Companhia
            objEntidad.ID = Id
            objEntidad.Usuario = User_Sistema

            ' Validar resultado
            Dim validaTarjeta As ETResultado = objNegocio.ValidaTarjetaConsumoAsignado(objEntidad, op)

            If validaTarjeta.Realizo Then

                Dim resultado As ETResultado = objNegocio.MantenimientoTarjetaConsumoAsignado(objEntidad, op)

                If resultado.Realizo Then

                    If op = 1 Then
                        MessageBox.Show("Se Registró la asignación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Se Modificó la asignación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    HabilitarControles(False)
                    'CargarDatos(resultado.Valor)
                Else

                    MessageBox.Show("Se han presentado problemas a registrar la tarjeta de consumo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If
            CargarListado()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Buscar()
        If tabPrincipal.SelectedTab.Key = "T01" Then
            CargarListado()
        End If
        If tabPrincipal.SelectedTab.Key = "T02" Then
            BuscarEmpleado()
        End If
    End Sub

    Public Sub Cancelar()
        If tabPrincipal.SelectedTab.Key = "T02" Then
            tabPrincipal.SelectedTab = tabPrincipal.Tabs("T01")
            CargarListado()
            tabPrincipal.Tabs("T02").Enabled = False
            tabPrincipal.Tabs("T01").Enabled = True
        End If
    End Sub
    Public Sub Actualizar()
        If tabPrincipal.SelectedTab.Key = "T01" Then
            CargarListado()
        End If
    End Sub
    Public Sub Eliminar()
        Try
            Dim objEntidad As New ETTarjetaConsumo
            objEntidad.ID = 0

            If tabPrincipal.SelectedTab.Key = "T01" Then 'listado
                objEntidad.ID = Convert.ToInt32(GrdDatos.ActiveRow.Cells("ID").Value)
            Else
                objEntidad.ID = Convert.ToInt32(txtid.Text)
            End If

            If objEntidad.ID = 0 Then
                MessageBox.Show("Debe seleccionar un registro para eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If MessageBox.Show("¿Desea eliminar la asignación de la Tarjeta de Consumo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Dim resultado As ETResultado = objNegocio.MantenimientoTarjetaConsumoAsignado(objEntidad, 3)

            If resultado.Realizo Then
                MessageBox.Show("Se Eliminó la asignación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarControles()
                HabilitarControles(False)
                tabPrincipal.SelectedTab = tabPrincipal.Tabs("T01")
            End If

            CargarListado()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Modificar()
        lgCrud = "M"
        If GrdDatos.Rows.Count = 0 Then
            MessageBox.Show("No hay registros en la grilla.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Verificar si hay una fila activa seleccionada
        If GrdDatos.ActiveRow Is Nothing OrElse GrdDatos.ActiveRow.IsFilteredOut Then
            MessageBox.Show("Debe seleccionar un registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        HabilitarControles(True)
        LlenarControles()

        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
        tabPrincipal.Tabs("T02").Enabled = True

        txtEmpleadoCodigo.Focus()
        'hvilela

    End Sub
    Public Sub Reporte()
        Try

            If GrdDatos.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron datos para exportar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim ruta As String
            ruta = Application.StartupPath & String.Format("\{0}_{1}", DateTime.Now.ToString("yyyyMMddss"), "ASIGNACION_CELULARES.xls")

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

    Public Sub CargarListado()
        Try

            Dim objEntidad As New ETTarjetaConsumo
            objEntidad.CodCia = Companhia
            CargarUltraGridxBinding(GrdDatos, Source1, objNegocio.ListarTarjetasConsumo(objEntidad))
            GrdDatos.DisplayLayout.Bands(0).Columns("nro_tarjeta").Format = "####-####-####-####"
            GrdDatos.DisplayLayout.Bands(0).Columns("nro_tarjeta").MaskInput = "####-####-####-####"

            ' Ocultar las columnas específicas
            GrdDatos.DisplayLayout.Bands(0).Columns("cod_ds_banco").Hidden = True
            GrdDatos.DisplayLayout.Bands(0).Columns("cod_mon_tarjeta").Hidden = True
            GrdDatos.DisplayLayout.Bands(0).Columns("cod_est_tarjeta").Hidden = True
            'GrdDatos.DisplayLayout.Bands(0).Columns("cod_tip_tarjeta").Hidden = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrdDatos_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles GrdDatos.InitializeRow
        If Not IsDBNull(e.Row.Cells("nro_tarjeta").Value) Then
            Dim numeroTarjeta As String = e.Row.Cells("nro_tarjeta").Value.ToString()
            If numeroTarjeta.Length = 16 Then
                e.Row.Cells("nro_tarjeta").Value = String.Format("{0:####-####-####-####}", Convert.ToInt64(numeroTarjeta))
            End If
        End If
    End Sub


    Public Function Validar() As Boolean
        Ep1.Clear()

        Dim lResult As Boolean
        lResult = True

        If String.IsNullOrEmpty(txtEmpleadoCodigo.Text.Trim()) Then
            Ep1.SetError(txtEmpleadoCodigo, "Seleccione el Personal que se asignara a la Tarjeta de Consumo")
            lResult = False
        End If

        If String.IsNullOrEmpty(txt_ds_banco.Text.Trim()) Then
            Ep1.SetError(txt_ds_banco, "Seleccione el Banco asignado para la Tarjeta")
            lResult = False
        End If

        If String.IsNullOrEmpty(num_ciclodel.Value.ToString()) Then
            Ep1.SetError(num_ciclodel, "Ingrese el dia de ciclo inicial de la Tarjeta")
            lResult = False
        End If

        If String.IsNullOrEmpty(num_cicloal.Value.ToString()) Then
            Ep1.SetError(num_cicloal, "Ingrese el dia de ciclo final de la Tarjeta")
            lResult = False
        End If


        'If String.IsNullOrEmpty(txt_fec_emision.Text.Trim()) Then
        'Ep1.SetError(txt_fec_emision, "Ingrese la Fecha de Emisión de la Tarjeta")
        'lResult = False
        'End If

        'If String.IsNullOrEmpty(txt_fec_vcmto.Text.Trim()) Then
        'Ep1.SetError(txt_fec_vcmto, "Ingrese la Fecha de Vencimiento de la Tarjeta")
        'lResult = False
        'End If

        ' Si ambos campos tienen valores, proceder con las validaciones adicionales

        'If Not String.IsNullOrEmpty(txt_fec_emision.Text.Trim()) AndAlso Not String.IsNullOrEmpty(txt_fec_vcmto.Text.Trim()) Then
        '    Dim fecEmision As DateTime
        '    Dim fecVcmto As DateTime

        '    ' Intentar convertir las fechas ingresadas a tipo DateTime
        '    If DateTime.TryParse(txt_fec_emision.Text.Trim(), fecEmision) AndAlso DateTime.TryParse(txt_fec_vcmto.Text.Trim(), fecVcmto) Then
        '        ' Validar que la fecha de emisión y la fecha de vencimiento no sean iguales
        '        If fecEmision = fecVcmto Then
        '            Ep1.SetError(txt_fec_vcmto, "La Fecha de Vencimiento no puede ser igual a la Fecha de Emisión")
        '            lResult = False
        '        Else
        '            Ep1.SetError(txt_fec_vcmto, "") ' Limpia el error si ya no aplica
        '        End If

        '        ' Validar que la fecha de vencimiento sea mayor que la fecha de emisión
        '        If fecVcmto <= fecEmision Then
        '            Ep1.SetError(txt_fec_vcmto, "La Fecha de Vencimiento debe ser mayor que la Fecha de Emisión")
        '            lResult = False
        '        Else
        '            Ep1.SetError(txt_fec_vcmto, "") ' Limpia el error si ya no aplica
        '        End If

        '        ' Validar que la fecha de vencimiento no sea una fecha anterior a la fecha actual
        '        'If fecVcmto < DateTime.Today Then
        '        'Ep1.SetError(txt_fec_vcmto, "La Fecha de Vencimiento no puede ser una fecha anterior a hoy")
        '        'lResult = False
        '        'Else
        '        'Ep1.SetError(txt_fec_vcmto, "") ' Limpia el error si ya no aplica
        '        'End If
        '    Else
        '        ' Si las fechas no son válidas, mostrar un mensaje de error
        '        Ep1.SetError(txt_fec_emision, "La Fecha de Emisión ingresada no es válida")
        '        Ep1.SetError(txt_fec_vcmto, "La Fecha de Vencimiento ingresada no es válida")
        '        lResult = False
        '    End If
        'End If

        If String.IsNullOrEmpty(txt_saldo_ini.Text) Then
            Ep1.SetError(txt_saldo_ini, "Ingrese el Importe inicial de la Tarjeta T&E asignada")
            lResult = False
        End If

        If String.IsNullOrEmpty(txt_saldo_ini1.Text) Then
            Ep1.SetError(txt_saldo_ini1, "Ingrese el Importe inicial de la Tarjeta P-Card asignada")
            lResult = False
        End If

        If String.IsNullOrEmpty(cmb_est_tarjeta.Value) Then
            Ep1.SetError(cmb_est_tarjeta, "Seleccione el Estado de la Tarjeta asignada")
            lResult = False
        End If

        If String.IsNullOrEmpty(cmb_mon_tarjeta.Value) Then
            Ep1.SetError(cmb_mon_tarjeta, "Seleccione la Moneda de la Tarjeta asignada")
            lResult = False
        End If

        'If String.IsNullOrEmpty(cmb_tip_tarjeta.Value) Then
        '  Ep1.SetError(cmb_tip_tarjeta, "Seleccione el Tipo de la Tarjeta asignada")
        '  lResult = False
        'End If

        Dim numeroTarjeta As String = txt_nro_tarjeta.Text.Replace("-", "")
        ' Verificar que la longitud sea exactamente 16
        If numeroTarjeta.Length <> 16 Then
            Ep1.SetError(txt_nro_tarjeta, "El número de tarjeta debe contener exactamente 16 dígitos")
            lResult = False
        End If

        Return lResult

    End Function

    Public Sub LimpiarControles()

        txtEmpleado.Text = ""
        txtEmpleadoCodigo.Text = ""

        txt_nro_tarjeta.Text = ""
        txt_nro_tarjeta.InputMask = "####-####-####-####"
        txt_nro_tarjeta.PromptChar = " "

        txt_des_ds_banco.Text = ""
        txt_ds_banco.Text = ""

        txt_fec_emision.Text = ""
        txt_fec_vcmto.Text = ""

        'txt_saldo_fin.Text = 0.0
        ' txt_consumo.Text = 0.0
        ' txt_saldo_ini.Text = 0.0

        txt_saldo_ini.Text = CDbl("0.00").ToString("#,###,##0.00")
        txt_saldo_ini1.Text = CDbl("0.00").ToString("#,###,##0.00")

        num_ciclodel.Text = CDbl("0").ToString("0")
        num_cicloal.Text = CDbl("0").ToString("0")

        txt_consumo.Text = CDbl("0.00").ToString("#,###,##0.00")
        txt_saldo_fin.Text = CDbl("0.00").ToString("#,###,##0.00")

        txt_consumo1.Text = CDbl("0.00").ToString("#,###,##0.00")
        txt_saldo_fin1.Text = CDbl("0.00").ToString("#,###,##0.00")

        txt_consumo.ReadOnly = True
        txt_saldo_fin.ReadOnly = True

        cmb_est_tarjeta.Value = "01"
        lvw_HistorialTC.Items.Clear()

    End Sub
    Public Sub HabilitarControles(ByVal pHabilitar)

        txtEmpleado.Enabled = pHabilitar
        txtEmpleadoCodigo.Enabled = pHabilitar

        txt_nro_tarjeta.Enabled = pHabilitar
        txt_nro_tarjeta.ReadOnly = (Not pHabilitar)

        txt_des_ds_banco.Enabled = pHabilitar
        txt_ds_banco.Enabled = pHabilitar


        txt_fec_emision.Enabled = pHabilitar
        txt_fec_vcmto.Enabled = pHabilitar

        txt_saldo_fin.Enabled = pHabilitar
        txt_consumo.Enabled = pHabilitar
        txt_saldo_ini.Enabled = pHabilitar

        cmb_est_tarjeta.Enabled = pHabilitar
        cmb_mon_tarjeta.Enabled = pHabilitar
        cmb_tip_tarjeta.Enabled = pHabilitar

        '--  Habilitar botones 
        btnBuscarEmpleado.Enabled = pHabilitar
        btn_ds_banco.Enabled = pHabilitar

    End Sub

    'Private Sub GrdDatos_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs)
    '    If e.Row.IsFilterRow Then Return

    '    Dim objEntidad As New ETAsigCelular
    '    objEntidad.ID = Convert.ToInt32(e.Row.Cells("ID").Value)
    '    objEntidad.CodCia = Companhia

    '    HabilitarControles(False)
    '    CargarDatos(objEntidad.ID)
    '    tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
    'End Sub

    Private Sub Exportador_BeginExport(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.BeginExportEventArgs) Handles Exportador.BeginExport
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        e.CurrentRowIndex += 1
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).Value = "ASIGNACIÓN DE CELULARES"
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        e.CurrentRowIndex += 2
    End Sub



    Private Sub GrdDatos_DoubleClickRow(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrdDatos.DoubleClick
        LlenarControles()
        HabilitarControles(False)
        'CargarDatos(objEntidad.ID)
        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
    End Sub




    Public Sub LlenarControles()

        Try

            cmb_est_tarjeta.Value = GrdDatos.ActiveRow.Cells("cod_est_tarjeta").Value.ToString
            cmb_mon_tarjeta.Value = GrdDatos.ActiveRow.Cells("cod_mon_tarjeta").Value.ToString ' Moneda

            'cmb_tip_tarjeta.Value = GrdDatos.ActiveRow.Cells("cod_tip_tarjeta").Value.ToString

            'cmb_tip_tarjeta.Value = GrdDatos.ActiveRow.Cells("cod_tip_tarjeta").Value.ToString
            'cmb_tip_tarjeta.Value = CDbl(GrdDatos.ActiveRow.Cells("cod_tip_tarjeta").Value).ToString("###,##0.00")

            txtEmpleado.Text = GrdDatos.ActiveRow.Cells("nombres").Value.ToString
            txtEmpleadoCodigo.Text = GrdDatos.ActiveRow.Cells("placod").Value.ToString

            'txt_consumo.Text = CDbl(GrdDatos.ActiveRow.Cells("consumo").Value).ToString("###,##0.00")

            txt_des_ds_banco.Text = GrdDatos.ActiveRow.Cells("ds_banco").Value.ToString
            txt_ds_banco.Text = GrdDatos.ActiveRow.Cells("cod_ds_banco").Value.ToString

            txt_fec_emision.Text = GrdDatos.ActiveRow.Cells("fec_emision").Value.ToString
            txt_fec_vcmto.Text = GrdDatos.ActiveRow.Cells("fec_vcmto").Value.ToString

            txt_nro_tarjeta.Text = GrdDatos.ActiveRow.Cells("nro_tarjeta").Value.ToString
            txt_nro_tarjeta.InputMask = "####-####-####-####"
            txt_nro_tarjeta.PromptChar = " "
            txt_nro_tarjeta.ReadOnly = True

            txt_saldo_ini.Text = CDbl(GrdDatos.ActiveRow.Cells("saldo_ini").Value).ToString("###,##0.00")
            txt_saldo_ini1.Text = CDbl(GrdDatos.ActiveRow.Cells("saldo_ini1").Value).ToString("###,##0.00")

            num_ciclodel.Text = GrdDatos.ActiveRow.Cells("fec_emision").Value
            num_cicloal.Text = GrdDatos.ActiveRow.Cells("fec_vcmto").Value

            idTarjetaConsumo = GrdDatos.ActiveRow.Cells("id").Value
            idTipoTarjetaConsumo = 1

            Dim lResultDt As DataTable = objNegocio.ListarLimiteTarjetasConsumo(idTarjetaConsumo, idTipoTarjetaConsumo)

            ' Verificar si el DataTable tiene datos
            If lResultDt IsNot Nothing AndAlso lResultDt.Rows.Count > 0 Then
                ' Recorrer cada fila del DataTable
                For Each row As DataRow In lResultDt.Rows
                    ' Acceder a los valores de las columnas específicas
                    txt_consumo.Text = Convert.ToDecimal(row("TotalConsumido")) ' Reemplaza "NombreColumnaLimite1" con el nombre real de la columna
                    txt_saldo_fin.Text = Convert.ToDecimal(row("SaldoDisponible")) ' Reemplaza "NombreColumnaLimite2" con el nombre real de la columna
                Next
            End If

            idTipoTarjetaConsumo = 2

            Dim lResultDt1 As DataTable = objNegocio.ListarLimiteTarjetasConsumo(idTarjetaConsumo, idTipoTarjetaConsumo)

            ' Verificar si el DataTable tiene datos
            If lResultDt1 IsNot Nothing AndAlso lResultDt1.Rows.Count > 0 Then
                ' Recorrer cada fila del DataTable
                For Each row As DataRow In lResultDt1.Rows
                    ' Acceder a los valores de las columnas específicas
                    txt_consumo1.Text = Convert.ToDecimal(row("TotalConsumido")) ' Reemplaza "NombreColumnaLimite1" con el nombre real de la columna
                    txt_saldo_fin1.Text = Convert.ToDecimal(row("SaldoDisponible")) ' Reemplaza "NombreColumnaLimite2" con el nombre real de la columna
                Next
            End If


            'Public Class ETM_Data
            '            Public Id As Integer
            '            Public Nombre As String
            '            Public Limite As Decimal
            '            Public IdTarjetaConsumo As Integer
            '            Public FechaInicioPeriodo As Date
            '            Public FechaFinPeriodo As Date
            '            Public DiasPeriodo As Integer
            '            Public LimiteCredito As Decimal
            '            Public TotalConsumido As Decimal
            '            Public SaldoDisponible As Decimal
            '            Public EstadoCredito As Integer

            'End Class

        Catch ex As Exception

        End Try

    End Sub



    Private Sub UltraTabPageControl2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraTabPageControl2.Paint

    End Sub

    Private Sub btn_HistorialTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HistorialTC.Click
        objEntidad.CodCia = Companhia
        objEntidad.Codigo_Empleado = txtEmpleadoCodigo.Text
        objEntidad.PlaCod = txtEmpleadoCodigo.Text

        If Not String.IsNullOrEmpty(txtEmpleadoCodigo.Text.Trim()) Then
            'If txtEmpleadoCodigo.Text.Trim.Length <> 0 Then
            lvw_HistorialTC.Visible = True
            lvw_HistorialTC.Enabled = True

            Try
                '  Deshabilitar la pestaña "T02" al cargar el formulario
                '  tabPrincipal.Tabs("T02").Enabled = False
                CargarHistorial()
            Catch ex As Exception
            End Try
        Else
            'Debere seleccionar un personal 
            lvw_HistorialTC.Visible = False
            lvw_HistorialTC.Enabled = False
            lvw_HistorialTC.Clear()
            If String.IsNullOrEmpty(txtEmpleadoCodigo.Text.Trim()) Then
                Ep1.SetError(txtEmpleadoCodigo, "Seleccione el Personal que se asignara a la Tarjeta de Consumo")
            End If
        End If


    End Sub


    Public Sub CargarHistorial()
        Try
            ' Crear instancia del objeto de datos
            Dim objNegocio = New NGTarjetaConsumo
            objEntidad.CodCia = Companhia
            objEntidad.Codigo_Empleado = txtEmpleadoCodigo.Text
            objEntidad.PlaCod = txtEmpleadoCodigo.Text

            ' Limpiar el ListView antes de cargar los datos
            lvw_HistorialTC.Items.Clear()

            ' Obtener los datos de la base de datos
            Dim dt As DataTable = objNegocio.spTarjetaConsumo_Historial(objEntidad)

            If dt.Rows.Count() <> 0 Then
                ' Configurar las columnas del ListView si aún no están configuradas
                If lvw_HistorialTC.Columns.Count = 0 Then
                    lvw_HistorialTC.View = View.Details
                    lvw_HistorialTC.FullRowSelect = True
                    lvw_HistorialTC.GridLines = True

                    lvw_HistorialTC.Columns.Add("Moneda", 80)
                    lvw_HistorialTC.Columns.Add("Saldo Inicial", 90)
                    lvw_HistorialTC.Columns.Add("Fec. Emisión", 90)
                    lvw_HistorialTC.Columns.Add("Fec. Vcmto.", 90)
                    lvw_HistorialTC.Columns.Add("Estado", 80)
                    lvw_HistorialTC.Columns.Add("Usu. Modifica", 90)
                    lvw_HistorialTC.Columns.Add("Fec. Modifica", 100)
                End If


                ' Agregar los datos al ListView
                For Each row As DataRow In dt.Rows
                    ' Crear el ListViewItem con el primer valor
                    Dim item As New ListViewItem(row("mon_tarjeta").ToString())
                    ' Agregar los subelementos al ListViewItem
                    item.SubItems.Add(row("saldo_ini").ToString())
                    item.SubItems.Add(row("fec_emision").ToString())
                    item.SubItems.Add(row("fec_vcmto").ToString())
                    item.SubItems.Add(row("est_tarjeta").ToString())
                    item.SubItems.Add(row("usuario_modifica").ToString())
                    item.SubItems.Add(row("fecha_modifica").ToString())

                    ' Agregar el item al ListView
                    lvw_HistorialTC.Items.Add(item)
                Next
            Else
                lvw_HistorialTC.Visible = False
                lvw_HistorialTC.Enabled = False
                lvw_HistorialTC.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show("Error al cargar historial: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Función para formatear el número de tarjeta en grupos de 4 dígitos
    Private Function FormatCardNumber(ByVal cardNumber As String) As String
        ' Verificar que el número tenga al menos 16 dígitos
        If Not String.IsNullOrEmpty(cardNumber) AndAlso cardNumber.Length = 16 Then
            Return cardNumber.Insert(4, "-").Insert(9, "-").Insert(14, "-")
        Else
            Return cardNumber ' Si no tiene 16 dígitos, se deja como está
        End If
    End Function


End Class


