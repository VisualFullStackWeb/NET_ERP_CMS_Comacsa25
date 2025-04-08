Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms

Public Class FrmAsignacionCelulares

    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Dim objNegocio As NGAsigCelular

    Private Sub txtEmpleadoCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmpleadoCodigo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BuscarEmpleado()
        End If
    End Sub

    Private Sub BuscarEmpleado()
        Dim frm As New FrmListarPlanilla
        frm.ShowDialog()

        txtEmpleadoCodigo.Text = Trim(frm.CODIGO)
        txtEmpleado.Text = frm.EMPLEADO
    End Sub

    Private Sub txtTarifa_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTarifa.Enter
        txtTarifa.SelectAll()
    End Sub

    Private Sub txtTarifa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTarifa.Leave
        Dim consumo As Decimal = 0

        If Not Decimal.TryParse(txtTarifa.Text.Trim(), consumo) Then
            MessageBox.Show("Ingrese una consumo valido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTarifa.SelectAll()
        Else
            txtTarifa.Text = consumo.ToString("###,###,##0.00")
        End If
    End Sub

    Private Sub btnBuscarEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarEmpleado.Click
        BuscarEmpleado()
    End Sub

    Private Sub FrmAsignacionCelulares_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        HabilitarControles(False)

        objNegocio = New NGAsigCelular

        Dim objEntidad As New ETAsigCelular
        objEntidad.CodCia = Companhia

        Try
            CargarListado()

            CargarlistaBolsas()

            CargarGrillaBolsas()

            tabPrincipal.SelectedTab = tabPrincipal.Tabs("T01")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CargarlistaBolsas()
        Try
            Dim objEntidad As New ETAsigCelular
            objEntidad.CodCia = Companhia
            Dim dt As New DataTable
            dt = objNegocio.ListarBolsas(objEntidad)
            Dim row As DataRow = dt.NewRow
            row("cod_maestro2") = "0"
            row("descrip") = "-- Seleccione --"

            dt.Rows.InsertAt(row, 0)

            cmbGrupo.DisplayMember = "descrip"
            cmbGrupo.ValueMember = "cod_maestro2"
            cmbGrupo.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CargarGrillaBolsas()
        Try
            Dim dt As DataTable = New NGBolsaFactTelefonica().Listar(Companhia)
            GrdBolsas.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Nuevo()
        HabilitarControles(True)
        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
        LimpiarControles()
        txtEmpleadoCodigo.Focus()
    End Sub
    Public Sub Grabar()
        If Not Validar() Then Return
        Dim Id As Integer = Convert.ToInt32(txtid.Text)
        Dim resp As DialogResult = Windows.Forms.DialogResult.No
        Dim op As Integer = 0

        If Id = 0 Then
            resp = MessageBox.Show("¿Desea Registrar la Asignación de Celular?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 1
        Else
            resp = MessageBox.Show("¿Desea Modificar la Asignación de Celular?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 2
        End If

        If resp = Windows.Forms.DialogResult.No Then Return

        Try
            Dim objEntidad As New ETAsigCelular
            objEntidad.CodCia = Companhia
            objEntidad.CodBolsa = cmbGrupo.Value
            objEntidad.PlaCod = txtEmpleadoCodigo.Text.Trim
            objEntidad.ID = Id
            objEntidad.NroCelular = txtCelular.Text.Trim()
            objEntidad.Tarifa = Convert.ToDecimal(txtTarifa.Text)
            objEntidad.Usuario = User_Sistema

            Dim resultado As ETResultado = objNegocio.MantenimientoCelularesAsignados(objEntidad, op)

            If resultado.Realizo Then

                If op = 1 Then
                    MessageBox.Show("Se Registró la asignación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Se Modificó la asignación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                HabilitarControles(False)
                CargarDatos(resultado.Valor)
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
    Public Sub Actualizar()
        If tabPrincipal.SelectedTab.Key = "T01" Then
            CargarListado()
        End If
    End Sub
    Public Sub Eliminar()
        Try
            Dim objEntidad As New ETAsigCelular
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

            If MessageBox.Show("¿Desea eliminar la asignación del número de celular?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Dim resultado As ETResultado = objNegocio.MantenimientoCelularesAsignados(objEntidad, 3)

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
        Dim Id As Integer = Convert.ToInt32(txtid.Text)

        If Id = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        HabilitarControles(True)

        txtTarifa.Focus()
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
    Public Sub CargarDatos(ByVal Id As Integer)

        Dim objEntidad As New ETAsigCelular
        objEntidad.ID = Id

        Try
            LimpiarControles()

            Dim dt As DataTable = objNegocio.Obtener(objEntidad)

            If dt.Rows.Count > 0 Then

                txtid.Text = Trim(Convert.ToString(dt.Rows(0)("ID")))
                txtEmpleadoCodigo.Text = Trim(Convert.ToString(dt.Rows(0)("placod")))
                txtEmpleado.Text = Trim(Convert.ToString(dt.Rows(0)("nombres")))
                txtCelular.Text = Trim(Convert.ToString(dt.Rows(0)("celular")))
                txtTarifa.Text = Convert.ToDecimal(dt.Rows(0)("tarifa"))
                cmbGrupo.Value = Trim(Convert.ToString(dt.Rows(0)("grupo")))

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub CargarListado()
        Try
            Dim objEntidad As New ETAsigCelular
            objEntidad.CodCia = Companhia

            CargarUltraGridxBinding(GrdDatos, Source1, objNegocio.ListarCelularesAsignados(objEntidad))
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function Validar() As Boolean
        Ep1.Clear()

        Dim lResult As Boolean
        lResult = True

        If cmbGrupo.SelectedIndex < 0 Then
            Ep1.SetError(cmbGrupo, "Seleccione la Bolsa a la que estará asignada la Persona")
            lResult = False
        End If

        If String.IsNullOrEmpty(txtCelular.Text.Trim()) Then
            Ep1.SetError(txtCelular, "Ingrese el celular por Asignar")
            lResult = False
        End If
        If String.IsNullOrEmpty(txtEmpleadoCodigo.Text.Trim()) Then
            Ep1.SetError(txtEmpleadoCodigo, "Ingrese el Código de la Persona")
            lResult = False
        End If

        Dim pPrecio As Decimal = 0
        Decimal.TryParse(txtTarifa.Text.Trim(), pPrecio)

        If pPrecio = 0 Then
            Ep1.SetError(txtTarifa, "Ingrese un Precio Válido")
            lResult = False
        End If

        Return lResult
    End Function
    Public Sub LimpiarControles()
        cmbGrupo.SelectedIndex = 0
        txtEmpleado.Text = ""
        txtEmpleadoCodigo.Text = ""
        txtCelular.Text = ""
        txtTarifa.Text = "0.00"
        txtid.Text = "0"
    End Sub
    Public Sub HabilitarControles(ByVal pHabilitar)
        cmbGrupo.Enabled = pHabilitar
        txtEmpleado.Enabled = pHabilitar
        txtEmpleadoCodigo.Enabled = pHabilitar
        txtCelular.Enabled = pHabilitar
        txtTarifa.Enabled = pHabilitar
    End Sub

    Private Sub GrdDatos_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GrdDatos.DoubleClickRow
        If e.Row.IsFilterRow Then Return

        Dim objEntidad As New ETAsigCelular
        objEntidad.Id = Convert.ToInt32(e.Row.Cells("ID").Value)
        objEntidad.CodCia = Companhia

        HabilitarControles(False)
        CargarDatos(objEntidad.ID)
        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
    End Sub

    Private Sub Exportador_BeginExport(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.BeginExportEventArgs) Handles Exportador.BeginExport
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        e.CurrentRowIndex += 1
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).Value = "ASIGNACIÓN DE CELULARES"
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        e.CurrentRowIndex += 2
    End Sub

    Private Sub btnNuevaBolsa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaBolsa.Click
        Try
            Dim objBolsa As New ETBolsaFactTelefonica
            Dim nombre_bolsa As String = InputBox("Ingrese el nombre de la nueva bolsa", "Nueva Bolsa")

            If nombre_bolsa.Length = 0 Then
                MessageBox.Show("Debe ingresar el nombre para la nueva bolsa", "Nueva Bolsa", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                objBolsa.CodCia = Companhia
                objBolsa.Bolsa = nombre_bolsa
                objBolsa.Usuario = User_Sistema

                Dim BolsaNG As New NGBolsaFactTelefonica
                Dim resultado As ETResultado = BolsaNG.Mantenimiento(objBolsa, 1)

                If resultado.Realizo Then
                    MessageBox.Show("Se registró la bolsa" & nombre_bolsa, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargarlistaBolsas()
                    CargarGrillaBolsas()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEditarBolsa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarBolsa.Click
        Try
            Dim objBolsa As New ETBolsaFactTelefonica

            If cmbGrupo.SelectedIndex < 0 OrElse cmbGrupo.Value.ToString() = "0" Then
                MessageBox.Show("Debe seleccionar una bolsa", "Editar Bolsa", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbGrupo.Focus()
                Exit Sub
            End If

            Dim nombre_bolsa As String = InputBox("Ingrese el nuevo nombre para la bolsa", "Editar Bolsa")

            If nombre_bolsa.Length = 0 Then
                MessageBox.Show("Debe ingresar el nuevo nombre para la bolsa", "Editar Bolsa", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                objBolsa.CodCia = Companhia
                objBolsa.CodBolsa = cmbGrupo.Value.ToString().Trim()
                objBolsa.Bolsa = nombre_bolsa
                objBolsa.Usuario = User_Sistema

                Dim BolsaNG As New NGBolsaFactTelefonica
                Dim resultado As ETResultado = BolsaNG.Mantenimiento(objBolsa, 2)

                If resultado.Realizo Then
                    MessageBox.Show("Se actualizó la bolsa" & nombre_bolsa, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargarlistaBolsas()
                    CargarGrillaBolsas()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrdDatos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GrdDatos.InitializeLayout

    End Sub
End Class