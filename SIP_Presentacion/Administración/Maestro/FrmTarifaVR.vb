Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics
Public Class FrmTarifaVR
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim objNegocio As NGConsumoCentroCosto

    Private Sub FrmTarifaVR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargaDatos()
        'LISTAR PAIS
        ListarUbigeo(1, cmbpaiso, "", "")
        ListarUbigeo(1, cmbpaisd, "", "")
        cmbpaiso.Value = "001" : cmbpaisd.Value = "001"
        'LISTAR DPTO
        ListarUbigeo(2, cmbdptoo, "", "")
        ListarUbigeo(2, cmbdptod, "", "")
        cmbdptod.Value = "15"
    End Sub

    Sub Nuevo()
        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
        limpiar()
    End Sub

    Sub limpiar()
        txttarifa.Text = "0.00"
        cmbdptoo.Value = ""
        cmbprovo.Value = ""
        cmbdisto.Value = ""
        txtid.Text = 0
    End Sub

    Sub CargaDatos()
        Try
            Dim ET_ConsumoCC As New ETConsumoCentroCosto
            objNegocio = New NGConsumoCentroCosto
            Dim dtUbigeo As New DataTable
            dtUbigeo = objNegocio.ListarTarifaUbigeo(ET_ConsumoCC)
            CargarUltraGridxBinding(GrdDatos, Source1, dtUbigeo)
        Catch ex As Exception

        End Try

    End Sub

    Sub ListarUbigeo(ByVal tipo As Int32, ByVal cmb As Infragistics.Win.UltraWinGrid.UltraCombo, ByVal coddep As String, ByVal codprov As String)
        Try
            Dim ET_ConsumoCC As New ETConsumoCentroCosto
            objNegocio = New NGConsumoCentroCosto
            ET_ConsumoCC.tipo = tipo
            ET_ConsumoCC.coddpto = coddep
            ET_ConsumoCC.codprov = codprov
            Dim dtUbigeo As New DataTable
            dtUbigeo = objNegocio.ListarUbigeo(ET_ConsumoCC)

            cmb.DisplayMember = "DESCRIPCION"
            cmb.ValueMember = "CODIGO"
            cmb.DataSource = dtUbigeo

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbdptoo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdptoo.ValueChanged
        Try
            'LISTAR PROV
            ListarUbigeo(3, cmbprovo, cmbdptoo.Value, "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbdptod_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdptod.ValueChanged
        Try
            'LISTAR PROV
            ListarUbigeo(3, cmbprovd, cmbdptod.Value, "")
            cmbprovd.Value = "01"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbprovo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprovo.ValueChanged
        Try
            'LISTAR DIST
            ListarUbigeo(4, cmbdisto, cmbdptoo.Value, cmbprovo.Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbprovd_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprovd.ValueChanged
        Try
            'LISTAR DIST
            ListarUbigeo(4, cmbdistd, cmbdptod.Value, cmbprovd.Value)
            cmbdistd.Value = "001150101"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbdptoo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbdptoo.InitializeLayout, cmbdptod.InitializeLayout, cmbprovo.InitializeLayout, cmbprovd.InitializeLayout, cmbdisto.InitializeLayout, cmbdistd.InitializeLayout
        With sender.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("DESCRIPCION").Width = sender.Width
            .Columns("CODIGO").Hidden = Boolean.TrueString
            'For Each uColumn As UltraGrid In .Columns
            '    If Not (uColumn.Key = "DESCRIPCION") Then
            '        uColumn.Hidden = Boolean.TrueString
            '    Else
            '        uColumn.Hidden = Boolean.FalseString
            '    End If
            'Next
        End With
    End Sub

    Private Sub GrdDatos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GrdDatos.DoubleClickRow
        Try
            cmbdptoo.Value = GrdDatos.ActiveRow.Cells("COD_UBI_ORI").Value.ToString.Substring(3, 2)
            cmbprovo.Value = GrdDatos.ActiveRow.Cells("COD_UBI_ORI").Value.ToString.Substring(5, 2)
            cmbprovo.Text = GrdDatos.ActiveRow.Cells("PROV").Value.ToString
            cmbdisto.Value = GrdDatos.ActiveRow.Cells("COD_UBI_ORI").Value.ToString
            txttarifa.Text = GrdDatos.ActiveRow.Cells("PRECIO").Value
            txtid.Text = GrdDatos.ActiveRow.Cells("ID").Value
            tabPrincipal.SelectedTab = tabPrincipal.Tabs("T02")
        Catch ex As Exception

        End Try
    End Sub

    Sub Grabar()
        Try
            If tabPrincipal.Tabs("T02").Selected = False Then Exit Sub
            If txttarifa.Text = "" Then txttarifa.Text = "0.00"
            If MsgBox("Desea grabar registro", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            Dim ET_ConsumoCC As New ETConsumoCentroCosto
            objNegocio = New NGConsumoCentroCosto
            ET_ConsumoCC.opcion = 1
            ET_ConsumoCC.Id = txtid.Text
            ET_ConsumoCC.coddisto = cmbdisto.Value
            ET_ConsumoCC.coddistd = "001150101"
            ET_ConsumoCC.precio = txttarifa.Text
            ET_ConsumoCC.Usuario = User_Sistema
            Dim dtRespuesta As New DataTable
            dtRespuesta = objNegocio.MantTarifaUbigeo(ET_ConsumoCC)
            If dtRespuesta.Rows.Count > 0 Then
                If dtRespuesta.Rows(0)(0) = "OK" Then
                    MsgBox("Registro grabado correctamente", MsgBoxStyle.Information, msgComacsa)
                    CargaDatos()
                    Limpiar()
                    tabPrincipal.SelectedTab = tabPrincipal.Tabs("T01")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Eliminar()
        Try
            If tabPrincipal.Tabs("T02").Selected = False Then Exit Sub
            If txttarifa.Text = "" Then txttarifa.Text = "0.00"
            If MsgBox("Desea eliminar registro", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            Dim ET_ConsumoCC As New ETConsumoCentroCosto
            objNegocio = New NGConsumoCentroCosto
            ET_ConsumoCC.opcion = 3
            ET_ConsumoCC.Id = txtid.Text
            ET_ConsumoCC.coddisto = cmbdisto.Value
            ET_ConsumoCC.coddistd = "001150101"
            ET_ConsumoCC.precio = txttarifa.Text
            ET_ConsumoCC.Usuario = User_Sistema
            Dim dtRespuesta As New DataTable
            dtRespuesta = objNegocio.MantTarifaUbigeo(ET_ConsumoCC)
            If dtRespuesta.Rows.Count > 0 Then
                If dtRespuesta.Rows(0)(0) = "OK" Then
                    MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
                    Procesar()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Procesar()
        CargaDatos()
        limpiar()
        tabPrincipal.SelectedTab = tabPrincipal.Tabs("T01")
    End Sub

End Class