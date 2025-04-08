Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmPlanillaContratista
#Region "Declarar Variables"
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private TipoG As sTate
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
#End Region
    Sub CargarAfp()
        Try
            objNegocio = New NGContratista
            Dim dtFrecuencia As New DataTable
            dtFrecuencia = objNegocio.ListarAfp(Companhia)
            Call CargarUltraCombo(cmbtipoafp, dtFrecuencia, "CODAFP", "DESCRIP")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CargarTipodoc()
        Try
            objNegocio = New NGContratista
            Dim dtFrecuencia As New DataTable
            dtFrecuencia = objNegocio.ListarTipodoc(Companhia)
            Call CargarUltraCombo(cmbtipodoc, dtFrecuencia, "COD_MAESTRO2", "DESCRIP")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmPlanillaContratista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarContratista()
        CargarAfp()
        CargarTipodoc()
    End Sub
    Sub CargarContratista()
        Try
            Dim objNegocio As NGContratista = Nothing
            objNegocio = New NGContratista
            Dim dtContratista As New DataTable
            dtContratista = objNegocio.ListarContratistaConsulta(Companhia, "")
            Call CargarUltraGridxBinding(gridcontratista, Source1, dtContratista)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CargarDatos(ByVal cod_prov As String)
        Try
            objNegocio = New NGContratista
            Dim dtPlanilla As New DataTable
            dtPlanilla = objNegocio.ListarPlanilla(Companhia, cod_prov)
            Call CargarUltraGridxBinding(GridPlanilla, Source2, dtPlanilla)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cmbtipodoc_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbtipodoc.InitializeLayout
        With cmbtipodoc.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("DESCRIP").Width = 300 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "DESCRIP") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbtipoafp_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbtipoafp.InitializeLayout
        With cmbtipoafp.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("DESCRIP").Width = 300 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "DESCRIP") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Sub Buscar()
        If Me.TabMaestroEntregas.Tabs("Lista").Selected = True Then Exit Sub
        If txtcodcontratista.Focused = True Then
            limpiar()
            Dim frm As New frmBuscarContratista
            frm.ShowDialog()
            txtcodcontratista.Text = frm.gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            txtcontratista.Text = frm.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            Dim idtipopago As String = frm.gridcontratista.ActiveRow.Cells("TIPOPAGO").Value
            Dim idfrecuenia As Int32 = frm.gridcontratista.ActiveRow.Cells("IDFRECPAGO").Value
            'txtcodcantera.Focus()
        End If
        If txtcodcantera.Focused = True Then
            If txtcodcontratista.Text.Trim = "" Then
                MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            Dim frm As New frmBuscarCantera
            frm.codprov = txtcodcontratista.Text
            frm.ShowDialog()
            txtcodcantera.Text = frm.gridcontratista.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcantera.Text = frm.gridcontratista.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
        End If

    End Sub
    Sub limpiar()
        txtcodcantera.Clear()
        txtcantera.Clear()
        cmbtipodoc.Value = ""
        txtnumdoc.Clear()
        txtapepat.Clear()
        txtapemat.Clear()
        txtnombres.Clear()
        txtsueldo.Text = 0
        txtbonificacion.Text = 0
        txtidtrabajador.Text = 0
        cmbtipoafp.Value = ""
        chkcese.Checked = False
        dtcese.Enabled = False
        chkcese.Enabled = False
        chkcese.Checked = False
        chkessalud.Checked = False
        txtcodcantera.Focus()
    End Sub

    Private Sub txtsueldo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsueldo.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub txtbonificacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbonificacion.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub
    Sub Nuevo()
        Ope = 1
        'txtcodcontratista.Clear()
        'txtcontratista.Clear()
        limpiar()
        Me.TabMaestroEntregas.Tabs("Registro").Selected = True
    End Sub

    Private Sub chkcese_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcese.CheckedChanged
        If chkcese.Checked = True Then
            dtcese.Enabled = True
            dtcese.ReadOnly = False
        Else
            dtcese.Enabled = False
            dtcese.ReadOnly = True
        End If
    End Sub
    Sub Grabar()
        Try
            If Me.TabMaestroEntregas.Tabs("Lista").Selected = True Then Exit Sub
            If Not Validar() Then Exit Sub
            If MsgBox("¿Seguro de grabar registro?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._tipo = Ope
            objEntidad._usuario = User_Sistema
            objEntidad._flgcese = IIf(chkcese.Checked = True, 1, 0)
            objEntidad._idtrabajador = txtidtrabajador.Text
            objEntidad._codprov = txtcodcontratista.Text
            objEntidad._codcantera = txtcodcantera.Text
            objEntidad._tipodocumento = cmbtipodoc.Value
            objEntidad._documento = txtnumdoc.Text
            objEntidad._apepat = txtapepat.Text
            objEntidad._apemat = txtapemat.Text
            objEntidad._nombres = txtnombres.Text
            objEntidad._fechaingreso = dtingreso.Value
            objEntidad._fechacese = dtcese.Value
            objEntidad._sueldo = txtsueldo.Text
            objEntidad._bonificacion = txtbonificacion.Text
            objEntidad._codafp = cmbtipoafp.Value
            objEntidad._flgessalud = IIf(chkessalud.Checked = True, 1, 0)

            Dim dtGrabacion As New DataTable
            dtGrabacion = objNegocio.Mant_Planilla(objEntidad)
            If dtGrabacion.Rows.Count > 0 Then
                If dtGrabacion.Rows(0)(0).ToString.ToUpper.Trim = "OK" Then
                    MsgBox("Grabado correctamente", MsgBoxStyle.Information, msgComacsa)
                    CargarDatos(txtcodcontratista.Text)
                    limpiar()
                    Ope = 1
                    'Me.TabMaestroEntregas.Tabs("Lista").Selected = True
                Else
                    MsgBox(dtGrabacion.Rows(0)(0).ToString.Trim, MsgBoxStyle.Exclamation, msgComacsa)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub
    Sub eliminar()
        Try
            If Me.TabMaestroEntregas.Tabs("Lista").Selected = True Then Exit Sub
            If txtidtrabajador.Text = 0 Then MsgBox("Seleccione registro a eliminar", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
            If Not Validar() Then Exit Sub
            If MsgBox("¿Seguro de eliminar registro?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            Ope = 3
            objEntidad._tipo = Ope
            objEntidad._usuario = User_Sistema
            objEntidad._flgcese = IIf(chkcese.Checked = True, 1, 0)
            objEntidad._idtrabajador = txtidtrabajador.Text
            objEntidad._codprov = txtcodcontratista.Text
            objEntidad._codcantera = txtcodcantera.Text
            objEntidad._tipodocumento = cmbtipodoc.Value
            objEntidad._documento = txtnumdoc.Text
            objEntidad._apepat = txtapepat.Text
            objEntidad._apemat = txtapemat.Text
            objEntidad._nombres = txtnombres.Text
            objEntidad._fechaingreso = dtingreso.Value
            objEntidad._fechacese = dtcese.Value
            objEntidad._sueldo = txtsueldo.Text
            objEntidad._bonificacion = txtbonificacion.Text
            objEntidad._codafp = cmbtipoafp.Value
            objEntidad._flgessalud = IIf(chkessalud.Checked = True, 1, 0)

            Dim dtGrabacion As New DataTable
            dtGrabacion = objNegocio.Mant_Planilla(objEntidad)
            If dtGrabacion.Rows.Count > 0 Then
                If dtGrabacion.Rows(0)(0).ToString.ToUpper.Trim = "OK" Then
                    MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
                    CargarDatos(txtcodcontratista.Text)
                    limpiar()
                    'Me.TabMaestroEntregas.Tabs("Lista").Selected = True
                Else
                    MsgBox(dtGrabacion.Rows(0)(0).ToString.Trim, MsgBoxStyle.Exclamation, msgComacsa)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function Validar() As Boolean
        If txtcodcontratista.Text.Trim = "" Then
            MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcontratista.Focus()
            Return False
        End If
        If txtcodcantera.Text.Trim = "" Then
            MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcantera.Focus()
            Return False
        End If

        If cmbtipodoc.Value Is Nothing Then
            MsgBox("Ingrese tipo documento", MsgBoxStyle.Exclamation, msgComacsa)
            cmbtipodoc.Focus()
            Return False
        End If

        If txtnumdoc.Text.Trim = "" Then
            MsgBox("Ingrese N° documento", MsgBoxStyle.Exclamation, msgComacsa)
            txtnumdoc.Focus()
            Return False
        End If

        If txtapepat.Text.Trim = "" Then
            MsgBox("Ingrese apellido paterno", MsgBoxStyle.Exclamation, msgComacsa)
            txtapepat.Focus()
            Return False
        End If
        If txtapemat.Text.Trim = "" Then
            MsgBox("Ingrese apellido materno", MsgBoxStyle.Exclamation, msgComacsa)
            txtapemat.Focus()
            Return False
        End If
        If txtnombres.Text.Trim = "" Then
            MsgBox("Ingrese nombres", MsgBoxStyle.Exclamation, msgComacsa)
            txtnombres.Focus()
            Return False
        End If
        If txtsueldo.Text.ToString.Trim = "" Then txtsueldo.Text = 0
        If txtbonificacion.Text.ToString.Trim = "" Then txtbonificacion.Text = 0

        If txtsueldo.Text <= 0 Then
            MsgBox("Ingrese sueldo mayor a 0", MsgBoxStyle.Exclamation, msgComacsa)
            txtsueldo.Focus()
            Return False
        End If

        If cmbtipoafp.Value Is Nothing Then
            MsgBox("Ingrese tipo de afp", MsgBoxStyle.Exclamation, msgComacsa)
            cmbtipoafp.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub GridPlanilla_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridPlanilla.DoubleClickRow
        Try
            Dim idtrabajador As Int32
            idtrabajador = GridPlanilla.ActiveRow.Cells("IDTRABAJADOR").Value
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._idtrabajador = idtrabajador
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.ListarPlanillaTrabajador(objEntidad)
            If dtDatos.Rows.Count > 0 Then
                Me.TabMaestroEntregas.Tabs("Registro").Selected = True
                Ope = 2
                txtidtrabajador.Text = dtDatos.Rows(0)("IDTRABAJADOR")
                txtcodcontratista.Text = dtDatos.Rows(0)("COD_PROV")
                txtcontratista.Text = dtDatos.Rows(0)("CONTRATISTA")
                txtcodcantera.Text = dtDatos.Rows(0)("CODCANTERA")
                txtcantera.Text = dtDatos.Rows(0)("CANTERA")
                cmbtipodoc.Value = dtDatos.Rows(0)("COD_MAESTRO2")
                txtapepat.Text = dtDatos.Rows(0)("AP_PAT")
                txtapemat.Text = dtDatos.Rows(0)("AP_MAT")
                txtnombres.Text = dtDatos.Rows(0)("NOMBRES")
                txtnumdoc.Text = dtDatos.Rows(0)("NRODOCUMENTO")
                dtingreso.Value = dtDatos.Rows(0)("FECHAINGRESO")
                txtsueldo.Text = dtDatos.Rows(0)("SUELDOBASICO")
                txtbonificacion.Text = dtDatos.Rows(0)("BONIFICACION")
                cmbtipoafp.Value = dtDatos.Rows(0)("COD_AFP")
                If dtDatos.Rows(0)("FLAGESSALUD") = 1 Then
                    chkessalud.Checked = True
                Else
                    chkessalud.Checked = False
                End If
                chkcese.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridcontratista_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridcontratista.DoubleClickRow
        Try
            Ope = 1
            txtcodcontratista.Text = Me.gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            txtcontratista.Text = Me.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            Gpb1.Text = "REGISTRO DE PERSONAL:   " & Me.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            CargarDatos(Me.gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim)
            'txtidtrabajador.Text = Me.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            Me.TabMaestroEntregas.Tabs("Registro").Selected = True
        Catch ex As Exception

        End Try
    End Sub
End Class