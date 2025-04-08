Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb

Public Class FrmActivaEmpleados
#Region "Declarar Variables"
    Dim _objNegocio As NGEmpleado
    Dim _objEntidad As ETEmpelado

    Dim dtMotivo As DataTable
    Dim dtMotivo2 As DataTable
    Dim dtTipo As DataTable
    Dim dtTipo2 As DataTable
    Dim ETMaestros2 = New ETMaestos2

    Dim Accion As String
    Dim Opcion As String
    Dim Sec As String

#End Region

#Region "FuncionesBasicas"
    Sub CargarComboTipo()
        'Llenar Combos de motivo
        ETMaestros2 = New ETMaestos2

        Negocio.Maestro = New NGMaestro

        dtTipo = Negocio.Maestro.ConsultasTipoPago(ETMaestros2)
        dtTipo2 = Negocio.Maestro.ConsultasTipoPago(ETMaestros2)

        Try


            cboTipo.DisplayMember = "TipoPago"
            cboTipo.ValueMember = "Codigo"
            cboTipo.DataSource = dtTipo

        Catch ex As Exception
            MsgBox(ex.Message, "Tipo de pago no encontrado")
        End Try

        Try
            cboTipo2.DisplayMember = "TipoPago"
            cboTipo2.ValueMember = "Codigo"
            cboTipo2.DataSource = dtTipo2

        Catch ex As Exception
            MsgBox(ex.Message, "Tipo de pago no encontrado")
        End Try

        cboTipo.SelectedValue = 1
        cboTipo2.SelectedValue = 1
        CargarComboMotivo()
    End Sub
    Sub CargarComboMotivo()
        'Llenar Combos de motivo
        ETMaestros2 = New ETMaestos2

        ETMaestros2.Codigo = cboTipo.SelectedValue
        ETMaestros2.Usuario = User_Sistema
        Negocio.Maestro = New NGMaestro

        dtMotivo = Negocio.Maestro.ConsultasMaestros3(ETMaestros2)
        dtMotivo2 = Negocio.Maestro.ConsultasMaestros3(ETMaestros2)
        Try


            cboMotivo.DisplayMember = "Descripcion"
            cboMotivo.ValueMember = "Cod_Maestro3"
            cboMotivo.DataSource = dtMotivo

        Catch ex As Exception
            MsgBox(ex.Message, "Motivos no encontrados")
        End Try

        Try
            cboMotivo2.DisplayMember = "Descripcion"
            cboMotivo2.ValueMember = "Cod_Maestro3"
            cboMotivo2.DataSource = dtMotivo2

        Catch ex As Exception
            MsgBox(ex.Message, "Motivos no encontrados")
        End Try

    End Sub

    Sub Limpiar()
        'En Blanco Todo

        TxtPlacod.Text = ""
        txtPlacod2.Text = ""
        dtpFecha.Value = Date.Now
        dtpFecha2.Value = Date.Now
        txtObservaciones.Text = ""

    End Sub

    Function Validar() As Boolean

        If txtPlacod2.Value = "" Then
            MessageBox.Show("Debe ingresar un Codigo de Trabajador", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPlacod2.Focus()
            Return False
        ElseIf cboMotivo2.SelectedValue = Nothing Then
            MessageBox.Show("Debe ingresar un Motivo valido", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMotivo2.Focus()
            Return False
        Else
            Return True
        End If

    End Function

    Sub cargarDtg()
        'Cargar Grilla
        Dim dtDatos As DataTable


        _objNegocio = New NGEmpleado
        _objEntidad = New ETEmpelado

        _objEntidad.Opcion = Opcion
        _objEntidad.CodPla = TxtPlacod.Text
        _objEntidad.TipoPago = cboTipo.SelectedValue.ToString()
        Try
            _objEntidad.Motivo = cboMotivo.SelectedValue.ToString()
        Catch ex As Exception
            _objEntidad.Motivo = ""
        End Try

        _objEntidad.Fecha = dtpFecha.Value

        dtDatos = _objNegocio.ConsultarPagoTrabajador(_objEntidad)

        Call CargarUltraGridxBinding(grdEmpleados, Source1, dtDatos)

    End Sub

#End Region

#Region "Filtros"



#End Region

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Private Sub FrmActivaEmpleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Limpiar()
        CargarComboTipo()
        '        _objEntidad = New ETEmpelado

        'Cargar la Grilla con Fecha de Hoy
        Opcion = "3"
        cargarDtg()
    End Sub


    Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
        Limpiar()
        rbtFecha.Enabled = False
        rbtMotivo.Enabled = False
        rbtPlaCod.Enabled = False
        pnlRegistrar.Visible = True

        Sec = ""
        Accion = "I"
        grdEmpleados.Enabled = False
        TxtPlacod.Enabled = False
        cboTipo.Enabled = False
        cboMotivo.Enabled = False
        dtpFecha.Enabled = False
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim exito As Int16

        If Validar() = False Then Return
        _objEntidad = New ETEmpelado
        _objNegocio = New NGEmpleado

        _objEntidad.Accion = Accion
        _objEntidad.Usuario = User_Sistema
        _objEntidad.Terminal = Terminal
        _objEntidad.Sec = Sec
        _objEntidad.CodPla = txtPlacod2.Text
        _objEntidad.TipoPago = cboTipo2.SelectedValue
        _objEntidad.Motivo = cboMotivo2.SelectedValue
        _objEntidad.Fecha = dtpFecha2.Value
        _objEntidad.Observaciones = txtObservaciones.Text

        exito = _objNegocio.MantPagoTrabajador(_objEntidad)

        If (exito <> 1) Then Return

        MessageBox.Show("Registro Guardado Exitosamente", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Limpiar()
        Opcion = "3"
        cargarDtg()


        txtPlacod2.Enabled = True
        dtpFecha2.Enabled = True
        cboTipo.Enabled = True
        cboMotivo2.Enabled = True

        pnlRegistrar.Visible = False
        grdEmpleados.Enabled = True
        TxtPlacod.Enabled = True
        cboMotivo.Enabled = True
        dtpFecha.Enabled = True
        pnlRegistrar.Visible = False
        rbtFecha.Enabled = True
        rbtMotivo.Enabled = True
        rbtPlaCod.Enabled = True

    End Sub

    Private Sub grdEmpleados_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdEmpleados.DoubleClickRow
        Dim uRow As UltraGridRow
        uRow = e.Row

        Accion = "U"

        Sec = uRow.Cells("Sec").Value.ToString()
        txtPlacod2.Text = uRow.Cells("Codigo").Value.ToString()
        cboMotivo2.SelectedValue = uRow.Cells("CodMotivo").Value.ToString()
        dtpFecha2.Value = Convert.ToDateTime(uRow.Cells("FechaPago").Value)
        txtObservaciones.Text = uRow.Cells("Observacion").Value.ToString()

        txtPlacod2.Enabled = False
        dtpFecha2.Enabled = False
        cboMotivo2.Enabled = False

        pnlRegistrar.Visible = True
        grdEmpleados.Enabled = False
        TxtPlacod.Enabled = False
        cboMotivo.Enabled = False
        dtpFecha.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        grdEmpleados.Enabled = True
        TxtPlacod.Enabled = True
        cboTipo.Enabled = True
        cboMotivo.Enabled = True
        dtpFecha.Enabled = True

        txtPlacod2.Enabled = True
        dtpFecha2.Enabled = True
        cboMotivo2.Enabled = True

        rbtFecha.Enabled = True
        rbtMotivo.Enabled = True
        rbtPlaCod.Enabled = True

        pnlRegistrar.Visible = False

        Limpiar()

    End Sub

    Private Sub rbtFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtFecha.CheckedChanged
        If rbtFecha.Checked = True Then
            rbtMotivo.Checked = False
            rbtPlaCod.Checked = False

            TxtPlacod.Text = ""

            dtpFecha.Visible = True
            cboMotivo.Visible = False
            TxtPlacod.Visible = False

            Opcion = "3"
        End If
    End Sub

    Private Sub rbtPlaCod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPlaCod.CheckedChanged
        If rbtPlaCod.Checked = True Then
            rbtMotivo.Checked = False
            rbtFecha.Checked = False

            dtpFecha.Value = Date.Now

            dtpFecha.Visible = False
            cboMotivo.Visible = False
            TxtPlacod.Visible = True

            Opcion = "1"
        End If
    End Sub

    Private Sub rbtMotivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMotivo.CheckedChanged
        If rbtMotivo.Checked = True Then
            rbtPlaCod.Checked = False
            rbtFecha.Checked = False

            TxtPlacod.Text = ""
            dtpFecha.Value = Date.Now

            dtpFecha.Visible = False
            cboMotivo.Visible = True
            TxtPlacod.Visible = False

            Opcion = "2"
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        cargarDtg()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        CargarComboMotivo()
    End Sub
    'Borrrar desde aqui----------------------------------------------------------------------------------------------------------
    '
    '
    '
    '
    '
    '


    Private Sub btnPrueba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrueba.Click
        Dim tablaPrueba As DataTable
        Dim tablaTexto As String = ""
        _objNegocio = New NGEmpleado
        tablaPrueba = _objNegocio.Prueba(_objEntidad)
        Dim x As Int16 = 0
        x = tablaPrueba.Columns.Count

        Dim registro(x) As String


        'For i = 0 To tablaPrueba.Columns.Count - 1 Step 1
        '    tablaTexto = tablaTexto + RTrim(LTrim(tablaPrueba.Rows(0)(i).ToString()))
        '    If i <> tablaPrueba.Columns.Count - 1 Then
        '        tablaTexto = tablaTexto + ","
        '    End If
        'Next
        'txtPrueba.Text = tablaTexto

        For i = 0 To tablaPrueba.Columns.Count - 1 Step 1
            registro(i) = RTrim(LTrim(tablaPrueba.Rows(0)(i).ToString()))
        Next

        Dim csv As String = String.Join(",", registro)
        txtPrueba.Text = csv

        Dim ruta As String = "D:\DEV\NET_2008\erp\erp_comacsa\Prueba.csv"
        File.AppendAllText(ruta, csv)
    End Sub
End Class