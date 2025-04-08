Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms

Public Class FrmRegistroSOAT

    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim objNegocio As NGRegistroSOAT
    Private Sub txtTarifa_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTarifa.Enter
        txtTarifa.SelectAll()
    End Sub

    Private Sub txtTarifa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTarifa.Leave
        Dim consumo As Decimal = 0

        If Not Decimal.TryParse(txtTarifa.Text.Trim(), consumo) Then
            MessageBox.Show("Ingrese un precio válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTarifa.SelectAll()
        Else
            txtTarifa.Text = consumo.ToString("###,###,##0.00")
        End If
    End Sub

    Private Sub FrmRegistroSOAT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            objNegocio = New NGRegistroSOAT

            CargarListado()

            HabilitarControles(False)
            tabPrincipal.SelectedTab = tabPrincipal.Tabs("T01")

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub LimpiarControles()
        txtPlaca.Text = ""
        txtSOAT.Text = ""
        txtTarifa.Text = "0.00"
        txtid.Text = "0"
    End Sub

    Public Sub HabilitarControles(ByVal pHabilitar)
        txtPlaca.Enabled = pHabilitar
        txtSOAT.Enabled = pHabilitar
        txtTarifa.Enabled = pHabilitar
    End Sub

    Public Function Validar() As Boolean
        Ep1.Clear()

        Dim lResult As Boolean
        lResult = True

        If String.IsNullOrEmpty(txtPlaca.Text.Trim()) Then
            Ep1.SetError(txtPlaca, "Ingrese la placa")
            lResult = False
        End If
        If String.IsNullOrEmpty(txtSOAT.Text.Trim()) Then
            Ep1.SetError(txtSOAT, "Ingrese el SOAT")
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

    Public Sub Nuevo()
        HabilitarControles(True)
        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
        LimpiarControles()
        txtPlaca.Focus()
    End Sub

    Public Sub Grabar()
        If Not Validar() Then Return
        Dim Id As Integer = Convert.ToInt32(txtid.Text)
        Dim resp As DialogResult = Windows.Forms.DialogResult.No
        Dim op As Integer = 0

        If Id = 0 Then
            resp = MessageBox.Show("¿Desea Registrar el SOAT?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 1
        Else
            resp = MessageBox.Show("¿Desea Modificar el SOAT?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            op = 2
        End If

        If resp = Windows.Forms.DialogResult.No Then Return

        Try
            Dim objEntidad As New ETRegistroSOAT
            objEntidad.CodCia = Companhia
            objEntidad.placa = txtPlaca.Text.Trim
            objEntidad.soat = txtSOAT.Text.Trim
            objEntidad.ID = Id            
            objEntidad.precio = Convert.ToDecimal(txtTarifa.Text)
            objEntidad.Usuario = User_Sistema

            Dim resultado As ETResultado = objNegocio.Mantenimiento(objEntidad, op)

            If resultado.Realizo Then

                If op = 1 Then
                    MessageBox.Show("Se Registró el SOAT", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Se Modificó el SOAT", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    End Sub
    Public Sub Actualizar()
        Buscar()
    End Sub
    Public Sub Eliminar()
        Try
            Dim objEntidad As New ETRegistroSOAT
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

            If MessageBox.Show("¿Desea eliminar el SOAT registrado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Dim resultado As ETResultado = objNegocio.Mantenimiento(objEntidad, 3)

            If resultado.Realizo Then
                MessageBox.Show("Se Eliminó la asignación de SOAT", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        If tabPrincipal.SelectedTab.Key = "T01" Then 'listado
            Id = Convert.ToInt32(GrdDatos.ActiveRow.Cells("ID").Value)
        Else
            Id = Convert.ToInt32(txtid.Text)
        End If

        If Id = 0 Then
            MessageBox.Show("Debe seleccionar un registro para modificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If tabPrincipal.SelectedTab.Key = "T01" Then 'listado
            CargarDatos(Id)
            tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
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
            ruta = Application.StartupPath & String.Format("\{0}_{1}", DateTime.Now.ToString("yyyyMMddss"), "REGISTRO_SOAT.xls")

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

        Dim objEntidad As New ETRegistroSOAT
        objEntidad.codcia = Companhia
        objEntidad.ID = Id

        Try
            LimpiarControles()

            Dim dt As DataTable = objNegocio.Listar(objEntidad)

            If dt.Rows.Count > 0 Then

                txtid.Text = Trim(Convert.ToString(dt.Rows(0)("ID")))
                txtPlaca.Text = Trim(Convert.ToString(dt.Rows(0)("placa")))                
                txtSOAT.Text = Trim(Convert.ToString(dt.Rows(0)("nro_soat")))
                txtTarifa.Text = Convert.ToDecimal(dt.Rows(0)("precio"))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub CargarListado()
        Try
            Dim objEntidad As New ETRegistroSOAT
            objEntidad.codcia = Companhia
            objEntidad.ID = 0

            CargarUltraGridxBinding(GrdDatos, Source1, objNegocio.Listar(objEntidad))
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GrdDatos_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GrdDatos.DoubleClickRow
        If e.Row.IsFilterRow Then Return

        Dim objEntidad As New ETRegistroSOAT
        objEntidad.ID = Convert.ToInt32(e.Row.Cells("ID").Value)
        objEntidad.CodCia = Companhia

        HabilitarControles(False)
        CargarDatos(objEntidad.ID)
        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
    End Sub

    Private Sub Exportador_BeginExport(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.BeginExportEventArgs) Handles Exportador.BeginExport
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).Value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        e.CurrentRowIndex += 1
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).Value = "REGISTRO DE SOAT"
        e.CurrentWorksheet.Rows(e.CurrentRowIndex).Cells(0).CellFormat.Font.Bold = Infragistics.Excel.ExcelDefaultableBoolean.True
        e.CurrentRowIndex += 2
    End Sub
End Class