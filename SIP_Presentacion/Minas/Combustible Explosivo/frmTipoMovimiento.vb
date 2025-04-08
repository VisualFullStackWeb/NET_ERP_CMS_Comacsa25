Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class frmTipoMovimiento
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

    Private Sub frmTipoMovimiento_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmTipoMovimiento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        limpiar()
        CargarDatos()
    End Sub
    Sub limpiar()
        txtdescripcion.Clear()
        cmbtipo.SelectedIndex = -1
        cmbreferencia.Value = Nothing
        chktransferencia.Checked = False
        txtid.Text = 0
        chktransferencia.Checked = False
        chkventa.Checked = False
        chkoc.Checked = False
        chkventa.Enabled = False
        chktransferencia.Enabled = False
        chkoc.Enabled = False
    End Sub
    Sub CargarDatos()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarTipoMovimiento()
        Call CargarUltraGridxBinding(gridTipoMovimiento, Source1, dtDatos)
        Call CargarUltraCombo(cmbreferencia, dtDatos, "ID", "DESCRIPCION")
    End Sub

    Sub Nuevo()
        Me.Tab1.Tabs("T02").Selected = True
        Ope = 1
        limpiar()
        txtdescripcion.Focus()
    End Sub
    Private Sub chktransferencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chktransferencia.Checked = True Then
            UltraLabel1.Visible = True
            cmbreferencia.Visible = True
        Else
            UltraLabel1.Visible = False
            cmbreferencia.Visible = False
        End If
    End Sub

    Public Sub Grabar()
        Try
            If Tab1.SelectedTab.Key <> "T02" Then Return
            If Ope = 0 Then
                MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Not validaDatos() Then
                Exit Sub
            End If
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.Contratista.TipoOperacion = Ope
            Entidad.Contratista.ID = txtid.Text
            Entidad.Contratista._movi = cmbtipo.Value
            Entidad.Contratista._idreferencia = IIf(chktransferencia.Checked = True, cmbreferencia.Value, 0)
            Entidad.Contratista._flgtrans = IIf(chktransferencia.Checked = True, 1, 0)
            Entidad.Contratista._flgventa = IIf(chkventa.Checked = True, 1, 0)
            Entidad.Contratista._flgOC = IIf(chkoc.Checked = True, 1, 0)
            Entidad.Contratista._descripcion = txtdescripcion.Text
            Entidad.Contratista._usuario = User_Sistema
            Entidad.Contratista = Negocio.NContratista.MantenimientoTipoMovimiento(Entidad.Contratista)
            If Entidad.Contratista.Validacion Then
                Call Nuevo()
                CargarDatos()
                Tab1.Tabs("T01").Selected = Boolean.TrueString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Sub Eliminar()
        Try
            If Tab1.SelectedTab.Key <> "T02" Then Return
            If txtid.Text = 0 Then MsgBox("Seleccione registro a eliminar", MsgBoxStyle.Exclamation, msgComacsa) : Return
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.Contratista.TipoOperacion = 3
            Entidad.Contratista.ID = txtid.Text
            Entidad.Contratista._movi = cmbtipo.Value
            Entidad.Contratista._idreferencia = IIf(chktransferencia.Checked = True, cmbreferencia.Value, 0)
            Entidad.Contratista._flgtrans = IIf(chktransferencia.Checked = True, 1, 0)
            Entidad.Contratista._descripcion = txtdescripcion.Text
            Entidad.Contratista._usuario = User_Sistema
            Entidad.Contratista = Negocio.NContratista.MantenimientoTipoMovimiento(Entidad.Contratista)
            If Entidad.Contratista.Validacion Then
                Call Nuevo()
                CargarDatos()
                Tab1.Tabs("T01").Selected = Boolean.TrueString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Function validaDatos() As Boolean
        If txtdescripcion.Text.ToString.Trim = "" Then
            MsgBox("Ingrese descripción", MsgBoxStyle.Exclamation, msgComacsa)
            txtdescripcion.Focus()
            Return False
        End If
        If cmbtipo.SelectedIndex < 0 Then
            MsgBox("Ingrese tipo de movimiento", MsgBoxStyle.Exclamation, msgComacsa)
            cmbtipo.Focus()
            Return False
        End If
        If chktransferencia.Checked = True And cmbtipo.Value = "S" Then
            If cmbreferencia.Value Is Nothing Then
                MsgBox("Ingrese referencia", MsgBoxStyle.Exclamation, msgComacsa)
                cmbtipo.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub cmbreferencia_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbreferencia.InitializeLayout
        With cmbreferencia.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("DESCRIPCION").Width = 350 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "DESCRIPCION") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub gridTipoMovimiento_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridTipoMovimiento.DoubleClickRow
        Try
            txtdescripcion.Text = gridTipoMovimiento.ActiveRow.Cells("DESCRIPCION").Value
            txtid.Text = gridTipoMovimiento.ActiveRow.Cells("ID").Value.ToString.Trim
            cmbtipo.Value = gridTipoMovimiento.ActiveRow.Cells("MOVI").Value
            If gridTipoMovimiento.ActiveRow.Cells("FLGTRANS").Value = 1 Then
                chktransferencia.Checked = True
                cmbreferencia.Value = gridTipoMovimiento.ActiveRow.Cells("IDREFERENCIA").Value
            Else
                chktransferencia.Checked = False
            End If
            If gridTipoMovimiento.ActiveRow.Cells("FLGVENTA").Value = 1 Then
                chkventa.Checked = True
            Else
                chkventa.Checked = False
            End If
            If gridTipoMovimiento.ActiveRow.Cells("FLGOC").Value = 1 Then
                chkoc.Checked = True
            Else
                chkoc.Checked = False
            End If
            Me.Tab1.Tabs("T02").Selected = True
            txtdescripcion.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktransferencia.CheckedChanged
        If chktransferencia.Checked = True Then
            If cmbtipo.Value = "S" Then
                UltraLabel1.Visible = True
                cmbreferencia.Visible = True
            Else
                UltraLabel1.Visible = False
                cmbreferencia.Visible = False
            End If
            chkoc.Enabled = False
            chkventa.Enabled = False
            chkoc.Checked = False
            chkventa.Checked = False
        Else
            UltraLabel1.Visible = False
            cmbreferencia.Visible = False
            chkoc.Enabled = True
            chkventa.Enabled = True
            chkoc.Checked = False
            chkventa.Checked = False
        End If
    End Sub

    Private Sub chkventa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkventa.CheckedChanged
        If chkventa.Checked = True Then
            chkoc.Enabled = False
            chktransferencia.Enabled = False
            chkoc.Checked = False
            chktransferencia.Checked = False
        Else
            chkoc.Enabled = True
            chktransferencia.Enabled = True
            chkoc.Checked = False
            chktransferencia.Checked = False
        End If
    End Sub

    Private Sub chkoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkoc.CheckedChanged
        If chkoc.Checked = True Then
            chkventa.Enabled = False
            chktransferencia.Enabled = False
            chkventa.Checked = False
            chktransferencia.Checked = False
        Else
            chkventa.Enabled = True
            chktransferencia.Enabled = True
            chkventa.Checked = False
            chktransferencia.Checked = False
        End If
    End Sub

    Private Sub cmbtipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipo.ValueChanged
        Try
            chkventa.Enabled = True
            chktransferencia.Enabled = True
            chkoc.Enabled = True
            CheckBox1_CheckedChanged(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub
End Class