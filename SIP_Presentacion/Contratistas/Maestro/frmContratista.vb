Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmContratista
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

    Private Sub frmContratista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Actualizar()
    End Sub
    Sub Actualizar()
        CargarDatos()
        CargarFrecuencia()
        CargarBancos()
        limpiar()
        Me.TabMaestro.Tabs("Lista").Selected = True
    End Sub
    Sub limpiar()
        txtid.Clear()
        txtcantera.Clear()
        txtcodcontratista.Clear()
        txtcontratista.Clear()
        txtruc.Clear()
        cmbtipopago.SelectedIndex = -1
        txtctabenef.Clear()
        txtsupervisor.Clear()
        txtcontador.Clear()
    End Sub
    Sub CargarDatos()
        Try
            Dim objNegocio As NGContratista = Nothing
            objNegocio = New NGContratista
            Dim dtContratista As New DataTable
            dtContratista = objNegocio.ListarContratista(Companhia)
            Call CargarUltraGridxBinding(gridContratista, Source1, dtContratista)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CargarFrecuencia()
        Try
            objNegocio = New NGContratista
            Dim dtFrecuencia As New DataTable
            dtFrecuencia = objNegocio.ListarFrecuencia(Companhia)
            Call CargarUltraCombo(cmbfrecuencia, dtFrecuencia, "IDFRECPAGO", "DESCRIPCION")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbfrecuencia_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbfrecuencia.InitializeLayout
        With cmbfrecuencia.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("DESCRIPCION").Width = 200 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "DESCRIPCION") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub gridContratista_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridcontratista.DoubleClickRow
        Try
            txtcodcontratista.Text = gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            txtcontratista.Text = gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            txtruc.Text = gridcontratista.ActiveRow.Cells("RUC").Value.ToString.Trim
            txtid.Text = gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            txtcodcantera.Text = gridcontratista.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcantera.Text = gridcontratista.ActiveRow.Cells("CANTERA").Value.ToString.Trim
            cmbbanco.Value = gridcontratista.ActiveRow.Cells("CODBANCO").Value.ToString.Trim
            txtctabenef.Text = gridcontratista.ActiveRow.Cells("NROCTA").Value.ToString.Trim
            txtsupervisor.Text = gridcontratista.ActiveRow.Cells("SUPERVISOR").Value.ToString.Trim
            txtcontador.Text = gridcontratista.ActiveRow.Cells("CONTADOR").Value.ToString.Trim
            txtcorreo.Text = gridcontratista.ActiveRow.Cells("CORREO").Value.ToString.Trim
            If gridcontratista.ActiveRow.Cells("RENTA").Value = 0 Then
                chkrenta.Checked = False
            Else
                chkrenta.Checked = True
            End If
            If gridcontratista.ActiveRow.Cells("TIPOPAGO").Value.ToString.Trim = "" Then
                cmbtipopago.SelectedIndex = -1
            Else
                cmbtipopago.Value = gridcontratista.ActiveRow.Cells("TIPOPAGO").Value.ToString.Trim
            End If
            cmbfrecuencia.Value = gridcontratista.ActiveRow.Cells("IDFRECPAGO").Value.ToString.Trim
            CargarMineral(txtcodcontratista.Text, txtcodcantera.Text)
            Me.TabMaestro.Tabs("Registro").Selected = True
        Catch ex As Exception

        End Try

        'txtcodcontratista.Text = gridContratista.ActiveRow.Cells("COD_PROV")
    End Sub

    Sub CargarMineral(ByVal codprov As String, ByVal codcantera As String)
        Try
            Dim objNegocio As NGContratista = Nothing
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._codprov = codprov
            objEntidad._codcantera = codcantera
            Dim dtContratista As New DataTable
            dtContratista = objNegocio.ListarMineralContratista(objEntidad)
            Call CargarUltraGridxBinding(gridmineral, Source2, dtContratista)
            Call CargarUltraGridxBinding(gridConfiguracion, Source2, dtContratista)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Grabar()
        Try
            If txtcodcontratista.Text.Trim = "" Then
                MsgBox("Seleccione contratista válido", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If cmbtipopago.SelectedIndex < 0 Then
                MsgBox("Seleccione tipo de pago", MsgBoxStyle.Exclamation, msgComacsa)
                cmbtipopago.Focus()
                Exit Sub
            End If
            If cmbfrecuencia.Value Is Nothing Then
                MsgBox("Seleccione frecuencia de pago", MsgBoxStyle.Exclamation, msgComacsa)
                cmbtipopago.Focus()
                Exit Sub
            End If
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._codprov = txtcodcontratista.Text
            objEntidad._idcontratista = 0 'txtid.Text
            objEntidad._tipopago = cmbtipopago.Value
            objEntidad._idfrecpago = cmbfrecuencia.Value
            objEntidad._nrocta = txtctabenef.Text
            objEntidad._banco = cmbbanco.Value
            objEntidad._ruc = txtruc.Text
            objEntidad._codcantera = txtcodcantera.Text
            objEntidad.supervisor = txtsupervisor.Text
            objEntidad.contador = txtcontador.Text
            objEntidad.Email = txtcorreo.Text
            objEntidad.renta = IIf(chkrenta.Checked = True, 1, 0)
            objEntidad._usuario = User_Sistema

            If objNegocio.ActualizaContratista(objEntidad) > 0 Then
                MsgBox("Guardado correctamente", MsgBoxStyle.Information, msgComacsa)
                Actualizar()
            Else
                MsgBox("Error al guardar", MsgBoxStyle.Exclamation, msgComacsa)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarBancos()
        Dim objNegocio As NGContratista = Nothing
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtBanco As New DataTable
        dtBanco = objNegocio.ListarBanco()
        Call CargarUltraCombo(cmbbanco, dtBanco, "cod_maestro2", "descrip")
    End Sub

    Private Sub gridmineral_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridmineral.InitializeLayout
        Try
            With e.Layout
                '.Bands(0).Columns("CANTERA").LockedWidth = False
                .Bands(0).Columns("CANTERA").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbbanco_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbbanco.InitializeLayout
        'Try
        With cmbbanco.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("descrip").Width = 200 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "descrip") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
        'Catch ex As Exception

        'End Try
    End Sub
    Sub buscar()
        'If txtcodcantera.Focused = True Then
        '    If txtcodcontratista.Text.Trim = "" Then
        '        MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
        '        Exit Sub
        '    End If
        '    Dim frm As New frmBuscarCantera
        '    frm.codprov = txtcodcontratista.Text
        '    frm.ShowDialog()
        '    txtcodcantera.Text = frm.gridcontratista.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
        '    txtcantera.Text = frm.gridcontratista.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
        'End If
    End Sub
End Class