Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms

Public Class FrmFacturasTelefonicas

    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Dim objNegocio As NGFacturaTelefonica

    Private Sub FrmFacturasTelefonicas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            objNegocio = New NGFacturaTelefonica

            Dim objEntidad As New ETFacturaTelefonica
            objEntidad.CodCia = Companhia

            CargarListado()
            CargarListaTipoDoc()
            CargarListaProveedores()
            CargarListaGrupos()

            tabPrincipal.SelectedTab = tabPrincipal.Tabs("T01")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "Comunes"

    Public Sub LimpiarControles()
        txtid.Text = "0"
        txtProvCodigo.Text = ""
        txtSerie.Text = "F001"
        txtNumDoc.Value = 0
        txtEmpCodigo.Text = ""
        txtEmpleado.Text = ""
        cmbGrupo.SelectedIndex = 0
        cmbProveedor.SelectedIndex = 0
        cmbTipoDoc.SelectedIndex = 0
    End Sub

    Public Sub HabilitarControles(ByVal pHabilitar As Boolean)
        txtProvCodigo.Enabled = pHabilitar
        txtSerie.Enabled = pHabilitar
        txtNumDoc.Enabled = pHabilitar
        txtEmpCodigo.Enabled = pHabilitar
        txtEmpleado.Enabled = pHabilitar

        cmbProveedor.Enabled = pHabilitar
        cmbTipoDoc.Enabled = pHabilitar
        cmbGrupo.Enabled = pHabilitar
    End Sub

#End Region

#Region "Datos"

    Public Sub CargarListaProveedores()
        Try
            Dim dt As DataTable = objNegocio.ListarProveedores(Companhia)
            Dim row As DataRow = dt.NewRow
            row("Cod_Prov") = "0"
            row("RazSoc") = "-- SELECCIONE --"

            dt.Rows.InsertAt(row, 0)

            cmbProveedor.DisplayMember = "RazSoc"
            cmbProveedor.ValueMember = "Cod_Prov"
            cmbProveedor.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CargarListaTipoDoc()
        Try
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
    Public Sub CargarListaGrupos()
        Try
            Dim dt As DataTable = objNegocio.ListarGrupos(Companhia)
            Dim row As DataRow = dt.NewRow
            row("cod_maestro2") = "0"
            row("descrip") = "-- SELECCIONE --"

            dt.Rows.InsertAt(row, 0)

            cmbGrupo.DisplayMember = "descrip"
            cmbGrupo.ValueMember = "cod_maestro2"
            cmbGrupo.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CargarDatos(ByVal ID As Integer)
        Dim objEntidad As New ETFacturaTelefonica
        objEntidad.CodCia = Companhia
        objEntidad.ID = ID

        Try
            LimpiarControles()

            Dim dt As DataTable = objNegocio.Obtener(objEntidad)

            If dt.Rows.Count > 0 Then

                txtid.Text = Trim(Convert.ToString(dt.Rows(0)("ID")))
                txtProvCodigo.Text = Trim(Convert.ToString(dt.Rows(0)("codprov")))
                cmbProveedor.Value = txtProvCodigo.Text.Trim()

                Dim numdoc As String = Trim(Convert.ToString(dt.Rows(0)("numdoc")))

                txtSerie.Text = numdoc.Substring(0, 4)
                txtNumDoc.Value = numdoc.Substring(4)
                txtEmpCodigo.Text = Trim(Convert.ToString(dt.Rows(0)("placod")))
                txtEmpleado.Text = Trim(Convert.ToString(dt.Rows(0)("persona")))

                If txtEmpCodigo.Text.Trim.Length > 0 Then
                    rbtEmpleado.Checked = True
                End If

                cmbGrupo.Value = Trim(Convert.ToString(dt.Rows(0)("grupo")))

                If cmbGrupo.SelectedIndex >= 0 Then
                    rbtGrupo.Checked = True
                End If

                cmbProveedor.Value = Trim(Convert.ToString(dt.Rows(0)("codprov")))
                cmbTipoDoc.Value = Trim(Convert.ToString(dt.Rows(0)("tipodoc")))

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub BuscarEmpleado()
        Dim frm As New FrmListarPlanilla
        frm.ShowDialog()

        txtEmpCodigo.Text = Trim(frm.CODIGO)
        txtEmpleado.Text = frm.EMPLEADO
    End Sub

    Public Sub CargarListado()
        Try
            Dim objEntidad As New ETFacturaTelefonica
            objEntidad.CodCia = Companhia

            CargarUltraGridxBinding(GrdDatos, Source1, objNegocio.Listar(objEntidad))

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function Validar() As Boolean
        Try
            Ep1.Clear()

            Dim lResult As Boolean
            lResult = True

            If Not rbtEmpleado.Checked And Not rbtGrupo.Checked Then
                MessageBox.Show("Debe elegir si la factura se vinculara a una persona o a una bolsa", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                lResult = False
            End If
            If rbtEmpleado.Checked AndAlso String.IsNullOrEmpty(txtEmpCodigo.Text.Trim()) Then
                Ep1.SetError(txtEmpCodigo, "Seleccione la persona asignada a la factura")
                lResult = False
            End If
            If rbtGrupo.Checked AndAlso cmbGrupo.SelectedIndex < 0 Then
                Ep1.SetError(cmbGrupo, "Seleccione la bolsa asignada a la factura")
                lResult = False
            End If

            If String.IsNullOrEmpty(txtProvCodigo.Text.Trim()) Then
                Ep1.SetError(txtProvCodigo, "Seleccione el Proveedor de la Factura")
                lResult = False
            End If
            If cmbTipoDoc.SelectedIndex < 0 OrElse cmbTipoDoc.Value.ToString() = "0" Then
                Ep1.SetError(cmbTipoDoc, "Seleccione el tipo de documento")
                lResult = False
            End If
            If String.IsNullOrEmpty(txtSerie.Text.Trim()) Then
                Ep1.SetError(txtSerie, "Ingrese la serie del documento")
                lResult = False
            End If

            If txtNumDoc.Value Is Nothing OrElse String.IsNullOrEmpty(txtNumDoc.Value.ToString()) Then
                Ep1.SetError(txtNumDoc, "Ingrese el número del documento")
                lResult = False
            End If

            Return lResult
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
#End Region

#Region "Eventos MDI"

    Public Sub Buscar()
        If tabPrincipal.SelectedTab.Key = "T01" Then
            CargarListado()
        End If
        If tabPrincipal.SelectedTab.Key = "T02" And rbtEmpleado.Checked Then
            BuscarEmpleado()
        End If
    End Sub

    Public Sub Nuevo()
        HabilitarControles(True)
        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
        LimpiarControles()
        txtProvCodigo.Focus()
    End Sub

    Public Sub Grabar()
        If Not Validar() Then Return
        Dim Id As Integer = Convert.ToInt32(txtid.Text)
        Dim resp As DialogResult = Windows.Forms.DialogResult.No
        Dim op As Integer = 0

        If Id = 0 Then
            resp = MessageBox.Show("¿Desea Registrar la Factura Telefónica?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 1
        Else
            resp = MessageBox.Show("¿Desea Modificar la Factura Telefónica?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 2
        End If

        If resp = Windows.Forms.DialogResult.No Then Return

        Try
            Dim objEntidad As New ETFacturaTelefonica
            objEntidad.CodCia = Companhia
            objEntidad.CodProv = cmbProveedor.Value

            If rbtEmpleado.Checked Then
                objEntidad.PlaCod = txtEmpCodigo.Text.Trim()            
            End If
            If rbtGrupo.Checked Then
                objEntidad.Grupo = cmbGrupo.Value
            Else
                objEntidad.Grupo = "0"
            End If

            objEntidad.ID = Id
            objEntidad.TipoDoc = cmbTipoDoc.Value            
            objEntidad.NroDoc = txtSerie.Text.Trim().PadLeft(4, "0") & txtNumDoc.Value.ToString().Trim().PadLeft(16, "0")
            objEntidad.Usuario = User_Sistema

            Dim resultado As ETResultado = objNegocio.Mantenimiento(objEntidad, op)

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

    Public Sub Modificar()
        Try
            Dim Id As Integer = Convert.ToInt32(txtid.Text)

            If Id = 0 Then
                MessageBox.Show("Debe seleccionar un registro para modificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            HabilitarControles(True)

            txtNumDoc.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Eliminar()
        Try
            Dim objEntidad As New ETFacturaTelefonica
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

            Dim resultado As ETResultado = objNegocio.Mantenimiento(objEntidad, 3)

            If resultado.Realizo Then
                MessageBox.Show("Se Eliminó la asignación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarControles()
                HabilitarControles(False)
                tabPrincipal.SelectedTab = tabPrincipal.Tabs("T01")
            End If

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
            ruta = Application.StartupPath & String.Format("\{0}_{1}", DateTime.Now.ToString("yyyyMMddss"), "FACTURAS_TELEFONICAS.xls")

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
#End Region

    Private Sub GrdDatos_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GrdDatos.DoubleClickRow
        If e.Row.IsFilterRow Then Return

        Dim objEntidad As New ETFacturaTelefonica
        objEntidad.ID = Convert.ToInt32(e.Row.Cells("ID").Value)
        objEntidad.CodCia = Companhia

        HabilitarControles(False)
        CargarDatos(objEntidad.ID)
        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
    End Sub

    Private Sub Exportador_BeginExport(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.BeginExportEventArgs) Handles Exportador.BeginExport
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        e.CurrentRowIndex += 1
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).Value = "FACTURAS TELEFONICAS"
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        e.CurrentRowIndex += 2
    End Sub

    Private Sub btnBuscarEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarEmpleado.Click        
        BuscarEmpleado()
    End Sub

    Private Sub rbtGrupo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtGrupo.CheckedChanged
        pnlBolsa.Enabled = rbtGrupo.Checked
        cmbGrupo.Enabled = rbtGrupo.Checked
    End Sub

    Private Sub rbtEmpleado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtEmpleado.CheckedChanged
        pnlEmpleado.Enabled = rbtEmpleado.Checked
        txtEmpCodigo.Enabled = rbtEmpleado.Checked
        txtEmpleado.Enabled = rbtEmpleado.Checked
    End Sub

    Private Sub txtSerie_AfterEnterEditMode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerie.AfterEnterEditMode
        txtSerie.SelectAll()
    End Sub

    Private Sub cmbProveedor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProveedor.ValueChanged
        If cmbProveedor.Value Is Nothing Then
            txtProvCodigo.Text = ""
        Else
            txtProvCodigo.Text = cmbProveedor.Value.ToString().Trim()
        End If
    End Sub

    Private Sub txtNumDoc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumDoc.Enter
        txtNumDoc.SelectAll()
    End Sub
End Class