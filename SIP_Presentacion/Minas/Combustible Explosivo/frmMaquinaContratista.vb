Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class frmMaquinaContratista
#Region "Variables"
    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private ListModulos As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Dim Ope = 1
#End Region
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.auxi = "AC"
        Entidad.Entregas.tipprod = "03"
        Entidad.MyLista = Negocio.NEntregas.ListarAuxiliar(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridConceptos, Source1, Ls_Entrega)
    End Sub

    Private Sub gridConceptos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConceptos.DoubleClickRow
        Try
            txtplaca.Text = gridConceptos.ActiveRow.Cells("codAuxiliar").Value.ToString.Trim
            txtequipo.Value = gridConceptos.ActiveRow.Cells("Auxiliar").Value.Trim
            Me.Tab1.Tabs("T02").Selected = True
            CargarContratista()
            'txtequipo.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridConceptos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "codAuxiliar" OrElse uColumn.Key = "Auxiliar") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub frmMaquinaContratista_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmMaquinaContratista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        Me.cmbMes.Value = Convert.ToInt32(Month(Now.Date))
        CargarDatos()
    End Sub
    Sub CargarContratista()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._placa = txtplaca.Text
        objEntidad._ayo = txtAño.Value
        objEntidad._mes = cmbMes.Value
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarActivoContratista(objEntidad)
        Call CargarUltraGridxBinding(gridcontratista, Source2, dtDatos)
    End Sub
    Sub Grabar()
        Try
            If Tab1.SelectedTab.Key <> "T02" Then Return
            If txtplaca.Text.ToString.Trim = "" Then
                MsgBox("Seleccione un equipo", MsgBoxStyle.Exclamation, msgComacsa)
                txtplaca.Focus()
                Return
            End If
            gridcontratista.PerformAction(ExitEditMode)
            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Return
            End If
            For i As Int32 = 0 To gridcontratista.Rows.Count - 1
                Entidad.Contratista = New ETContratista
                Negocio.NContratista = New NGContratista
                Entidad.Contratista._check = IIf(gridcontratista.Rows(i).Cells("ACTIVO").Value.ToString = "True", 1, 0)
                Entidad.Contratista._placa = txtplaca.Text
                Entidad.Contratista._codprov = gridcontratista.Rows(i).Cells("COD_PROV").Value.ToString.Trim
                Entidad.Contratista._ayo = txtAño.Value
                Entidad.Contratista._mes = cmbMes.Value
                'MsgBox(gridcontratista.Rows(i).Cells("ACTIVO").Value)
                Entidad.Contratista._usuario = User_Sistema
                Entidad.Contratista = Negocio.NContratista.Mant_ActivoContratista(Entidad.Contratista)
            Next
            Dim Mensaje As String = "Se grabó con éxito el registro"
            MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
            CargarContratista()
        Catch ex As Exception

        End Try

    End Sub
    Sub VerificaActivoContratistaMes()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._placa = txtplaca.Text
        objEntidad._ayo = txtAño.Value
        objEntidad._mes = cmbMes.Value
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.VerificaActivoContratistaMes(objEntidad)
        If dtDatos.Rows(0)(0) = 0 And dtDatos.Rows(1)(0) > 0 Then
            MsgBox("Necesita aperturar el mes", MsgBoxStyle.Information, msgComacsa)
            btnApertura.Visible = True
        Else
            btnApertura.Visible = False
        End If
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            VerificaActivoContratistaMes()
        Catch ex As Exception

        End Try
    End Sub

    Sub AperturaActivoContratistaMes()
        Try
            If MsgBox("¿Seguro desea aperturar mes?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Return
            End If
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._placa = txtplaca.Text
            objEntidad._ayo = txtAño.Value
            objEntidad._mes = cmbMes.Value
            objEntidad._usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.AperturaActivoContratistaMes(objEntidad)
            If dtDatos.Rows.Count > 0 Then
                MsgBox("Se aperturó correctamente el mes", MsgBoxStyle.Information, msgComacsa)
                btnApertura.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApertura.Click
        AperturaActivoContratistaMes()
    End Sub
End Class